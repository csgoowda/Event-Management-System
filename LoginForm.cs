using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            
            // Wire up load event programmatically
            this.Load += new EventHandler(LoginForm_Load);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Apply theme styles
            FormStyle.StyleForm(this);
            FormStyle.StyleTextBox(txtUsername);
            FormStyle.StyleTextBox(txtPassword);
            FormStyle.StyleButton(btnLogin, FormStyle.AccentColor, FormStyle.LightText);
            
            // Style register button as an outline/lighter button
            FormStyle.StyleButton(btnRegister, Color.FromArgb(220, 230, 242), FormStyle.PrimaryColor);

            // Default role selection to User
            cmbRole.SelectedIndex = 1;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Exception Handling & Validation
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;
                string role = cmbRole.SelectedItem != null ? cmbRole.SelectedItem.ToString() : "";

                // 1. Validation for Empty Fields
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
                {
                    throw new ArgumentException("Please fill in all the fields (Username, Password, and Role).");
                }

                // 2. Authentication Logic
                if (role == "Admin")
                {
                    // Admin credentials check (Specified in requirements)
                    if (username == "admin" && password == "admin123")
                    {
                        Database.CurrentUsername = "admin";
                        Database.CurrentRole = "Admin";

                        MessageBox.Show("Welcome, Administrator!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Navigate to Admin Dashboard
                        AdminDashboardForm adminDash = new AdminDashboardForm();
                        adminDash.FormClosed += (s, args) => this.Show(); // Show login screen when dashboard closes
                        this.Hide();
                        adminDash.Show();
                    }
                    else
                    {
                        throw new UnauthorizedAccessException("Invalid Admin Credentials. Please try again.");
                    }
                }
                else if (role == "User")
                {
                    // User check from static List
                    User foundUser = Database.Users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

                    if (foundUser == null)
                    {
                        throw new InvalidOperationException("User account does not exist. Please register first.");
                    }
                    else if (foundUser.Password != password)
                    {
                        throw new UnauthorizedAccessException("Incorrect Password. Please try again.");
                    }
                    else
                    {
                        Database.CurrentUsername = foundUser.Username;
                        Database.CurrentRole = "User";

                        MessageBox.Show("Welcome back, " + foundUser.Username + "!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Navigate to User Dashboard
                        UserDashboardForm userDash = new UserDashboardForm();
                        userDash.FormClosed += (s, args) => this.Show(); // Show login screen when dashboard closes
                        this.Hide();
                        userDash.Show();
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message, "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Account Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Fallback exception handling
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Open Registration Form
            UserRegistrationForm registrationForm = new UserRegistrationForm();
            registrationForm.ShowDialog(); // Show as modal box
        }
    }
}
