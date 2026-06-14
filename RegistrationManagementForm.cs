using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace EventManagementSystem
{
    public partial class RegistrationManagementForm : Form
    {
        private string userFilter = null;
        private int selectedRegistrationId = -1;

        /// <summary>
        /// Constructor. By default, loads in Admin mode.
        /// If a username is provided, loads in User Mode (read-only and filtered).
        /// </summary>
        public RegistrationManagementForm(string usernameFilter = null)
        {
            InitializeComponent();
            
            this.userFilter = usernameFilter;
            this.Load += new EventHandler(RegistrationManagementForm_Load);
        }

        private void RegistrationManagementForm_Load(object sender, EventArgs e)
        {
            // Apply theme styling
            FormStyle.StyleForm(this);
            FormStyle.StyleDataGridView(dgvRegistrations);

            // Conditional rendering based on role (Admin vs User)
            if (userFilter != null)
            {
                // User Mode: Hide administrative action panel
                panelActions.Visible = false;
                lblGridHeader.Text = "Event Registrations for user '" + userFilter + "'";
            }
            else
            {
                // Admin Mode: Style the administrative action buttons
                FormStyle.StyleButton(btnApprove, FormStyle.SuccessColor, FormStyle.LightText);
                FormStyle.StyleButton(btnReject, Color.FromArgb(230, 126, 34), FormStyle.LightText); // Orange for reject
                FormStyle.StyleButton(btnDelete, FormStyle.DangerColor, FormStyle.LightText);
                
                lblGridHeader.Text = "All Student Event Registrations";
            }

            Display();
        }

        /// <summary>
        /// Binds data to the Grid, using Generics for filtering in User mode.
        /// </summary>
        public void Display()
        {
            try
            {
                dgvRegistrations.DataSource = null;
                
                if (userFilter != null)
                {
                    // Use the C# Generics method from Database class to filter list
                    List<Registration> filteredList = Database.FindItems(
                        Database.Registrations, 
                        r => r.Username.Equals(userFilter, StringComparison.OrdinalIgnoreCase)
                    );
                    
                    dgvRegistrations.DataSource = filteredList;
                }
                else
                {
                    // Admin Mode: Load all records
                    dgvRegistrations.DataSource = Database.Registrations;
                }

                // Format columns
                if (dgvRegistrations.Columns.Count > 0)
                {
                    dgvRegistrations.Columns["RegistrationId"].HeaderText = "Registration ID";
                    dgvRegistrations.Columns["Username"].HeaderText = "Student User";
                    dgvRegistrations.Columns["EventName"].HeaderText = "Event Title";
                    dgvRegistrations.Columns["Status"].HeaderText = "Approval Status";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying registrations: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateRegistrationStatus(string newStatus)
        {
            try
            {
                if (selectedRegistrationId == -1)
                {
                    throw new ArgumentException("Please select a registration row from the table first.");
                }

                Registration reg = Database.Registrations.Find(r => r.RegistrationId == selectedRegistrationId);
                if (reg == null)
                {
                    throw new InvalidOperationException("Selected registration could not be found.");
                }

                reg.Status = newStatus;
                MessageBox.Show("Registration status updated to '" + newStatus + "' successfully!", "Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Clear selection
                ResetSelection();
                Display();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetSelection()
        {
            selectedRegistrationId = -1;
            lblSelectedId.Text = "None";
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            UpdateRegistrationStatus("Approved");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            UpdateRegistrationStatus("Rejected");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedRegistrationId == -1)
                {
                    throw new ArgumentException("Please select a registration row from the table first to delete.");
                }

                Registration reg = Database.Registrations.Find(r => r.RegistrationId == selectedRegistrationId);
                if (reg == null)
                {
                    throw new InvalidOperationException("Selected registration not found.");
                }

                DialogResult result = MessageBox.Show("Are you sure you want to delete registration ID " + reg.RegistrationId + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    Database.Registrations.Remove(reg);
                    MessageBox.Show("Registration record deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetSelection();
                    Display();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRegistrations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvRegistrations.Rows[e.RowIndex];
                selectedRegistrationId = Convert.ToInt32(row.Cells["RegistrationId"].Value);
                lblSelectedId.Text = selectedRegistrationId.ToString();
            }
        }
    }
}
