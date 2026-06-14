using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManagementSystem
{
    /// <summary>
    /// Event Management subform.
    /// Demonstrates Windows Forms Controls, DataGridView Binding, Exception Handling,
    /// and implements the IManage interface.
    /// </summary>
    public partial class EventManagementForm : Form, IManage
    {
        public EventManagementForm()
        {
            InitializeComponent();
            
            // Wire up Load event
            this.Load += new EventHandler(EventManagementForm_Load);
        }

        private void EventManagementForm_Load(object sender, EventArgs e)
        {
            // Apply theme styling
            FormStyle.StyleForm(this);
            FormStyle.StyleTextBox(txtEventId);
            FormStyle.StyleTextBox(txtEventName);
            FormStyle.StyleTextBox(txtVenue);
            
            FormStyle.StyleButton(btnAdd, FormStyle.AccentColor, FormStyle.LightText);
            FormStyle.StyleButton(btnUpdate, FormStyle.SecondaryColor, FormStyle.LightText);
            FormStyle.StyleButton(btnDelete, FormStyle.DangerColor, FormStyle.LightText);
            FormStyle.StyleButton(btnClear, Color.FromArgb(220, 224, 230), FormStyle.PrimaryColor);

            FormStyle.StyleDataGridView(dgvEvents);

            // Display initially loaded events
            Display();
        }

        #region IManage Implementation

        /// <summary>
        /// Display method to bind lists to the Grid control.
        /// </summary>
        public void Display()
        {
            try
            {
                // Reset DataSource to force refreshing grid fields
                dgvEvents.DataSource = null;
                dgvEvents.DataSource = Database.Events;
                
                // Format column headers cleanly
                if (dgvEvents.Columns.Count > 0)
                {
                    dgvEvents.Columns["EventId"].HeaderText = "ID";
                    dgvEvents.Columns["EventName"].HeaderText = "Event Name";
                    dgvEvents.Columns["EventDate"].HeaderText = "Date";
                    dgvEvents.Columns["Venue"].HeaderText = "Venue Location";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load events: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Add method to insert a new Event into the database.
        /// </summary>
        public void Add()
        {
            try
            {
                // 1. Inputs validation
                string name = txtEventName.Text.Trim();
                string venue = txtVenue.Text.Trim();
                DateTime date = dtpEventDate.Value;

                if (string.IsNullOrEmpty(txtEventId.Text))
                    throw new ArgumentException("Event ID is required.");
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException("Event Name is required.");
                if (string.IsNullOrEmpty(venue))
                    throw new ArgumentException("Venue is required.");

                int eventId;
                if (!int.TryParse(txtEventId.Text, out eventId) || eventId <= 0)
                {
                    throw new FormatException("Event ID must be a valid positive integer.");
                }

                // 2. Check duplicate Event ID
                bool exists = Database.Events.Exists(ev => ev.EventId == eventId);
                if (exists)
                {
                    throw new InvalidOperationException("An event with ID " + eventId + " already exists.");
                }

                // 3. Success: Create Event and add to list
                Event newEvent = new Event(eventId, name, date, venue);
                Database.Events.Add(newEvent);

                MessageBox.Show("Event added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                Display();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Input Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Formatting Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Data Collision", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete method to remove an Event from the list.
        /// </summary>
        public void Delete()
        {
            try
            {
                if (string.IsNullOrEmpty(txtEventId.Text))
                    throw new ArgumentException("Please select or enter the Event ID to delete.");

                int eventId;
                if (!int.TryParse(txtEventId.Text, out eventId))
                    throw new FormatException("Event ID must be an integer.");

                // Check if event exists
                Event foundEvent = Database.Events.Find(ev => ev.EventId == eventId);
                if (foundEvent == null)
                {
                    throw new InvalidOperationException("Event with ID " + eventId + " not found.");
                }

                // Confirm deletion
                DialogResult confirm = MessageBox.Show("Are you sure you want to delete event '" + foundEvent.EventName + "'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    Database.Events.Remove(foundEvent);
                    
                    // Also clean up registrations for this event to keep data clean
                    Database.Registrations.RemoveAll(r => r.EventName.Equals(foundEvent.EventName, StringComparison.OrdinalIgnoreCase));

                    MessageBox.Show("Event deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    Display();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        /// <summary>
        /// Updates the selected event's details.
        /// </summary>
        private void UpdateEvent()
        {
            try
            {
                string name = txtEventName.Text.Trim();
                string venue = txtVenue.Text.Trim();
                DateTime date = dtpEventDate.Value;

                if (string.IsNullOrEmpty(txtEventId.Text))
                    throw new ArgumentException("Please specify which Event ID to update.");
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException("Event Name is required.");
                if (string.IsNullOrEmpty(venue))
                    throw new ArgumentException("Venue is required.");

                int eventId;
                if (!int.TryParse(txtEventId.Text, out eventId))
                    throw new FormatException("Event ID must be an integer.");

                Event foundEvent = Database.Events.Find(ev => ev.EventId == eventId);
                if (foundEvent == null)
                {
                    throw new InvalidOperationException("Event with ID " + eventId + " does not exist. Cannot update.");
                }

                // Save old name to update registrations as well
                string oldName = foundEvent.EventName;

                // Apply updates
                foundEvent.EventName = name;
                foundEvent.EventDate = date;
                foundEvent.Venue = venue;

                // Sync registrations with new event name
                foreach (var reg in Database.Registrations)
                {
                    if (reg.EventName.Equals(oldName, StringComparison.OrdinalIgnoreCase))
                    {
                        reg.EventName = name;
                    }
                }

                MessageBox.Show("Event updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                Display();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtEventId.Text = "";
            txtEventName.Text = "";
            txtVenue.Text = "";
            dtpEventDate.Value = DateTime.Now;
            txtEventId.Enabled = true; // Re-enable ID field
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateEvent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Populate textboxes when user clicks a row in DataGridView
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEvents.Rows[e.RowIndex];
                txtEventId.Text = row.Cells["EventId"].Value.ToString();
                txtEventName.Text = row.Cells["EventName"].Value.ToString();
                dtpEventDate.Value = Convert.ToDateTime(row.Cells["EventDate"].Value);
                txtVenue.Text = row.Cells["Venue"].Value.ToString();

                // Keep EventId disabled during edits to prevent altering primary key
                txtEventId.Enabled = false;
            }
        }
    }
}
