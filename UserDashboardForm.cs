using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManagementSystem
{
    public partial class UserDashboardForm : Form
    {
        private Form activeForm = null;

        public UserDashboardForm()
        {
            InitializeComponent();
            
            // Hook up Load event
            this.Load += new EventHandler(UserDashboardForm_Load);
        }

        private void UserDashboardForm_Load(object sender, EventArgs e)
        {
            // Apply main styles
            FormStyle.StyleForm(this);
            panelHeader.BackColor = Color.White;
            panelSidebar.BackColor = FormStyle.PrimaryColor;
            
            // Highlight the user logo in emerald
            panelLogo.BackColor = FormStyle.AccentColor;

            // Display current logged in user
            lblSessionInfo.Text = "Logged in as: " + Database.CurrentUsername;

            // Style sidebar buttons
            StyleSidebarButton(btnEvents);
            StyleSidebarButton(btnMyRegistrations);
            StyleSidebarButton(btnProfile);
            StyleSidebarButton(btnLogout);
            
            // Red button on hover for log out
            btnLogout.MouseEnter += (s, ev) => btnLogout.BackColor = FormStyle.DangerColor;
            btnLogout.MouseLeave += (s, ev) => btnLogout.BackColor = FormStyle.PrimaryColor;

            // Load default screen: View & Register Events
            LoadChildForm(new UserEventRegistrationForm(), "Explore & Register for Events", btnEvents);
        }

        private void StyleSidebarButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = FormStyle.AccentColor;
            btn.FlatAppearance.MouseOverBackColor = FormStyle.SecondaryColor;
            btn.BackColor = FormStyle.PrimaryColor;
            btn.ForeColor = Color.White;
            btn.Font = FormStyle.ButtonFont;
            btn.Cursor = Cursors.Hand;
            btn.Padding = new Padding(15, 0, 0, 0);

            btn.Click += (s, e) => ResetActiveButtonStyles();
        }

        private void ResetActiveButtonStyles()
        {
            btnEvents.BackColor = FormStyle.PrimaryColor;
            btnMyRegistrations.BackColor = FormStyle.PrimaryColor;
            btnProfile.BackColor = FormStyle.PrimaryColor;
        }

        private void LoadChildForm(Form childForm, string title, Button sidebarButton)
        {
            try
            {
                if (activeForm != null)
                {
                    activeForm.Close();
                }

                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                
                panelContent.Controls.Clear();
                panelContent.Controls.Add(childForm);
                panelContent.Tag = childForm;

                lblHeaderTitle.Text = title;
                if (sidebarButton != null)
                {
                    sidebarButton.BackColor = FormStyle.SecondaryColor;
                }

                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading panel: " + ex.Message, "UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            LoadChildForm(new UserEventRegistrationForm(), "Explore & Register for Events", btnEvents);
        }

        private void btnMyRegistrations_Click(object sender, EventArgs e)
        {
            // Reuse RegistrationManagementForm in user-specific read-only mode (passing the current username)
            LoadChildForm(new RegistrationManagementForm(Database.CurrentUsername), "My Event Registrations", btnMyRegistrations);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            LoadChildForm(new UserProfileForm(), "My User Profile", btnProfile);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out of the portal?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
