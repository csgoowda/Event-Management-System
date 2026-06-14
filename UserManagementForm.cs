using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManagementSystem
{
    public partial class UserManagementForm : Form
    {
        private string selectedUsername = "";

        public UserManagementForm()
        {
            InitializeComponent();
            
            this.Load += new EventHandler(UserManagementForm_Load);
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            FormStyle.StyleForm(this);
            FormStyle.StyleDataGridView(dgvUsers);
            FormStyle.StyleButton(btnDeleteUser, FormStyle.DangerColor, FormStyle.LightText);

            Display();
        }

        public void Display()
        {
            try
            {
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = Database.Users;

                if (dgvUsers.Columns.Count > 0)
                {
                    dgvUsers.Columns["Username"].HeaderText = "Username";
                    dgvUsers.Columns["Password"].HeaderText = "Password Reference";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(selectedUsername) || selectedUsername == "None")
                {
                    throw new ArgumentException("Please select a user account from the grid first.");
                }

                // Protect super admin account
                if (selectedUsername.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("The primary 'admin' account is a required system credential and cannot be deleted.");
                }

                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete user '" + selectedUsername + "'?\nAll associated event registrations will also be removed.", "Confirm Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                
                if (result == DialogResult.Yes)
                {
                    // Find and delete the User
                    User userToDelete = Database.Users.Find(u => u.Username.Equals(selectedUsername, StringComparison.OrdinalIgnoreCase));
                    if (userToDelete != null)
                    {
                        Database.Users.Remove(userToDelete);
                    }

                    // Cascade Delete: Clean up registrations for this user
                    Database.Registrations.RemoveAll(r => r.Username.Equals(selectedUsername, StringComparison.OrdinalIgnoreCase));

                    // Cascade Delete: Clean up participant profile for this username if it exists
                    Database.Participants.RemoveAll(p => p.Name.Equals(selectedUsername, StringComparison.OrdinalIgnoreCase));

                    MessageBox.Show("User account deleted successfully.", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    selectedUsername = "";
                    lblSelectedUser.Text = "None";
                    Display();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                selectedUsername = row.Cells["Username"].Value.ToString();
                lblSelectedUser.Text = selectedUsername;
            }
        }
    }
}
