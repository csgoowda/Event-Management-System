using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManagementSystem
{
    public partial class UserRegistrationForm : Form
    {
        public UserRegistrationForm()
        {
            InitializeComponent();
            
            // Hook up Load event
            this.Load += new EventHandler(UserRegistrationForm_Load);
        }

        private void UserRegistrationForm_Load(object sender, EventArgs e)
        {
            // Apply theme styles
            FormStyle.StyleForm(this);
            FormStyle.StyleTextBox(txtUsername);
            FormStyle.StyleTextBox(txtPassword);
            FormStyle.StyleTextBox(txtConfirmPassword);
            
            FormStyle.StyleButton(btnRegister, FormStyle.AccentColor, FormStyle.LightText);
            FormStyle.StyleButton(btnCancel, Color.FromArgb(220, 224, 230), FormStyle.PrimaryColor);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;
                string confirmPassword = txtConfirmPassword.Text;

                // 1. Validation: Empty Fields
                if (string.IsNullOrEmpty(username))
                {
                    throw new ArgumentException("Username is required.");
                }
                if (string.IsNullOrEmpty(password))
                {
                    throw new ArgumentException("Password is required.");
                }

                // 2. Validation: Passwords Match
                if (password != confirmPassword)
                {
                    throw new ArgumentException("Passwords do not match. Please verify your password entry.");
                }

                // 3. Validation: Reserved Username
                if (username.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException("The username 'admin' is a reserved system credential.");
                }

                // 4. Validation: Duplicate Username
                bool userExists = Database.Users.Exists(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
                if (userExists)
                {
                    throw new InvalidOperationException("The username '" + username + "' is already taken. Please choose a different one.");
                }

                // 5. Success: Create User and save in-memory
                User newUser = new User(username, password);
                Database.Users.Add(newUser);

                // Auto-create a Participant profile for them as well, matching their username
                // This will make registrations and reports load beautifully!
                int nextId = Database.Participants.Count > 0 ? Database.Participants[Database.Participants.Count - 1].ParticipantId + 1 : 1;
                Database.Participants.Add(new Participant(nextId, username.Substring(0, 1).ToUpper() + username.Substring(1), "N/A"));

                MessageBox.Show("Registration Completed successfully! You can now log in using your credentials.", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
