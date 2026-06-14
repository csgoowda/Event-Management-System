using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace EventManagementSystem
{
    public partial class UserEventRegistrationForm : Form
    {
        private string selectedEventName = "";

        public UserEventRegistrationForm()
        {
            InitializeComponent();
            
            this.Load += new EventHandler(UserEventRegistrationForm_Load);
        }

        private void UserEventRegistrationForm_Load(object sender, EventArgs e)
        {
            FormStyle.StyleForm(this);
            FormStyle.StyleTextBox(txtSearch);
            
            FormStyle.StyleButton(btnSearch, FormStyle.SecondaryColor, FormStyle.LightText);
            FormStyle.StyleButton(btnReset, Color.FromArgb(220, 224, 230), FormStyle.PrimaryColor);
            FormStyle.StyleButton(btnRegister, FormStyle.AccentColor, FormStyle.LightText);
            
            FormStyle.StyleDataGridView(dgvEvents);

            Display();
        }

        /// <summary>
        /// Displays all events.
        /// </summary>
        public void Display()
        {
            try
            {
                dgvEvents.DataSource = null;
                dgvEvents.DataSource = Database.Events;

                if (dgvEvents.Columns.Count > 0)
                {
                    dgvEvents.Columns["EventId"].HeaderText = "Event ID";
                    dgvEvents.Columns["EventName"].HeaderText = "Event Name";
                    dgvEvents.Columns["EventDate"].HeaderText = "Scheduled Date";
                    dgvEvents.Columns["Venue"].HeaderText = "Venue Location";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying events: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string query = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(query))
                {
                    Display();
                    return;
                }

                // Leverage C# Generics search method from Database
                List<Event> searchResults = Database.FindItems(
                    Database.Events,
                    ev => ev.EventName.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 || 
                          ev.Venue.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0
                );

                dgvEvents.DataSource = null;
                dgvEvents.DataSource = searchResults;

                lblGridHeader.Text = "Search Results for '" + query + "' (" + searchResults.Count + " found)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            lblGridHeader.Text = "Available Events Catalog";
            ResetSelection();
            Display();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedEventName) || selectedEventName == "None Selected")
                {
                    throw new ArgumentException("Please select an event from the list to register.");
                }

                string currentUsername = Database.CurrentUsername;
                if (string.IsNullOrEmpty(currentUsername))
                {
                    throw new InvalidOperationException("Active session expired. Please log in again.");
                }

                // 1. Check if user is already registered for this specific event
                bool alreadyRegistered = Database.Registrations.Exists(reg =>
                    reg.Username.Equals(currentUsername, StringComparison.OrdinalIgnoreCase) &&
                    reg.EventName.Equals(selectedEventName, StringComparison.OrdinalIgnoreCase)
                );

                if (alreadyRegistered)
                {
                    throw new InvalidOperationException("You have already submitted a registration for '" + selectedEventName + "'.");
                }

                // 2. Determine registration ID (in-memory primary key generation)
                int nextRegId = 1;
                if (Database.Registrations.Count > 0)
                {
                    nextRegId = Database.Registrations[Database.Registrations.Count - 1].RegistrationId + 1;
                }

                // 3. Create registration with "Pending" status
                Registration newRegistration = new Registration(nextRegId, currentUsername, selectedEventName, "Pending");
                Database.Registrations.Add(newRegistration);

                MessageBox.Show("Successfully registered for '" + selectedEventName + "'!\nStatus: Pending (awaiting Admin approval).", "Registration Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetSelection();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Registration Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetSelection()
        {
            selectedEventName = "";
            lblEventNameValue.Text = "None Selected";
        }

        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEvents.Rows[e.RowIndex];
                selectedEventName = row.Cells["EventName"].Value.ToString();
                lblEventNameValue.Text = selectedEventName;
            }
        }
    }
}
