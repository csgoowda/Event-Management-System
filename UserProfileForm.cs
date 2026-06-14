using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManagementSystem
{
    public partial class UserProfileForm : Form
    {
        public UserProfileForm()
        {
            InitializeComponent();
            
            this.Load += new EventHandler(UserProfileForm_Load);
        }

        private void UserProfileForm_Load(object sender, EventArgs e)
        {
            FormStyle.StyleForm(this);
            FormStyle.StyleTextBox(txtCurrentPass);
            FormStyle.StyleTextBox(txtNewPass);
            FormStyle.StyleTextBox(txtConfirmPass);
            
            FormStyle.StyleButton(btnUpdatePassword, FormStyle.AccentColor, FormStyle.LightText);

            // Display current logged in user details
            lblUsernameValue.Text = Database.CurrentUsername;
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            try
            {
                string currentPass = txtCurrentPass.Text;
                string newPass = txtNewPass.Text;
                string confirmPass = txtConfirmPass.Text;

                // 1. Validate empty inputs
                if (string.IsNullOrEmpty(currentPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
                {
                    throw new ArgumentException("Please fill in all the password fields.");
                }

                // 2. Fetch logged in User
                User currentUser = Database.Users.Find(u => u.Username.Equals(Database.CurrentUsername, StringComparison.OrdinalIgnoreCase));
                if (currentUser == null)
                {
                    throw new InvalidOperationException("Active session user not found in registry.");
                }

                // 3. Verify current password
                if (currentUser.Password != currentPass)
                {
                    throw new UnauthorizedAccessException("Current Password verification failed. Incorrect password.");
                }

                // 4. Validate new password match
                if (newPass != confirmPass)
                {
                    throw new ArgumentException("New Password and Confirm New Password do not match.");
                }

                // 5. Success: Commit to memory database
                currentUser.Password = newPass;

                MessageBox.Show("Password updated successfully!", "Profile Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Input Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtCurrentPass.Text = "";
            txtNewPass.Text = "";
            txtConfirmPass.Text = "";
        }
    }
}
