using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManagementSystem
{
    /// <summary>
    /// Participant Management subform.
    /// Implements the IManage interface.
    /// Demonstrates Inheritance (Participant inherits Name from Person) and Polymorphism.
    /// </summary>
    public partial class ParticipantManagementForm : Form, IManage
    {
        public ParticipantManagementForm()
        {
            InitializeComponent();
            
            // Register Load event
            this.Load += new EventHandler(ParticipantManagementForm_Load);
        }

        private void ParticipantManagementForm_Load(object sender, EventArgs e)
        {
            // Apply theme styling
            FormStyle.StyleForm(this);
            FormStyle.StyleTextBox(txtParticipantId);
            FormStyle.StyleTextBox(txtName);
            FormStyle.StyleTextBox(txtPhoneNumber);
            
            FormStyle.StyleButton(btnAdd, FormStyle.AccentColor, FormStyle.LightText);
            FormStyle.StyleButton(btnUpdate, FormStyle.SecondaryColor, FormStyle.LightText);
            FormStyle.StyleButton(btnDelete, FormStyle.DangerColor, FormStyle.LightText);
            FormStyle.StyleButton(btnClear, Color.FromArgb(220, 224, 230), FormStyle.PrimaryColor);

            FormStyle.StyleDataGridView(dgvParticipants);

            // Display initially loaded records
            Display();
        }

        #region IManage Implementation

        public void Display()
        {
            try
            {
                dgvParticipants.DataSource = null;
                dgvParticipants.DataSource = Database.Participants;

                if (dgvParticipants.Columns.Count > 0)
                {
                    dgvParticipants.Columns["ParticipantId"].HeaderText = "ID";
                    dgvParticipants.Columns["Name"].HeaderText = "Full Name";
                    dgvParticipants.Columns["PhoneNumber"].HeaderText = "Phone Number";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to display participants: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Add()
        {
            try
            {
                string name = txtName.Text.Trim();
                string phone = txtPhoneNumber.Text.Trim();

                if (string.IsNullOrEmpty(txtParticipantId.Text))
                    throw new ArgumentException("Participant ID is required.");
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException("Participant Name is required.");
                if (string.IsNullOrEmpty(phone))
                    throw new ArgumentException("Phone number is required.");

                int id;
                if (!int.TryParse(txtParticipantId.Text, out id) || id <= 0)
                {
                    throw new FormatException("Participant ID must be a positive integer.");
                }

                // Check duplicate ID
                bool exists = Database.Participants.Exists(p => p.ParticipantId == id);
                if (exists)
                {
                    throw new InvalidOperationException("A participant with ID " + id + " already exists.");
                }

                // Create and insert (Inheritance used: Participant extends Person)
                Participant newPart = new Participant(id, name, phone);
                Database.Participants.Add(newPart);

                // Show polymorphism in action in console / message (viva-voce demonstration)
                string polyDemo = newPart.DisplayInfo(); // Overridden method

                MessageBox.Show("Participant added successfully!\nDetails: " + polyDemo, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                Display();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Delete()
        {
            try
            {
                if (string.IsNullOrEmpty(txtParticipantId.Text))
                    throw new ArgumentException("Please select or specify a Participant ID to delete.");

                int id;
                if (!int.TryParse(txtParticipantId.Text, out id))
                    throw new FormatException("ID must be an integer.");

                Participant found = Database.Participants.Find(p => p.ParticipantId == id);
                if (found == null)
                {
                    throw new InvalidOperationException("Participant with ID " + id + " not found.");
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete participant '" + found.Name + "'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Database.Participants.Remove(found);
                    MessageBox.Show("Participant deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(ex.Message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void UpdateParticipant()
        {
            try
            {
                string name = txtName.Text.Trim();
                string phone = txtPhoneNumber.Text.Trim();

                if (string.IsNullOrEmpty(txtParticipantId.Text))
                    throw new ArgumentException("Please select which Participant ID to update.");
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException("Name is required.");
                if (string.IsNullOrEmpty(phone))
                    throw new ArgumentException("Phone number is required.");

                int id;
                if (!int.TryParse(txtParticipantId.Text, out id))
                    throw new FormatException("ID must be an integer.");

                Participant found = Database.Participants.Find(p => p.ParticipantId == id);
                if (found == null)
                {
                    throw new InvalidOperationException("Participant with ID " + id + " not found. Cannot update.");
                }

                // Apply updates (updates inherited property 'Name' as well)
                found.Name = name;
                found.PhoneNumber = phone;

                MessageBox.Show("Participant details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtParticipantId.Text = "";
            txtName.Text = "";
            txtPhoneNumber.Text = "";
            txtParticipantId.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateParticipant();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvParticipants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvParticipants.Rows[e.RowIndex];
                txtParticipantId.Text = row.Cells["ParticipantId"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtPhoneNumber.Text = row.Cells["PhoneNumber"].Value.ToString();
                
                txtParticipantId.Enabled = false; // Disable ID field while editing
            }
        }
    }
}
