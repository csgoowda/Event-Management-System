using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManagementSystem
{
    public partial class AdminDashboardForm : Form
    {
        private Form activeForm = null;

        public AdminDashboardForm()
        {
            InitializeComponent();
            
            // Register load event
            this.Load += new EventHandler(AdminDashboardForm_Load);
        }

        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            // Apply main styles
            FormStyle.StyleForm(this);
            panelHeader.BackColor = Color.White;
            panelSidebar.BackColor = FormStyle.PrimaryColor;
            panelLogo.BackColor = FormStyle.SecondaryColor;

            // Customize sidebar buttons to look flat and modern
            StyleSidebarButton(btnEvents);
            StyleSidebarButton(btnParticipants);
            StyleSidebarButton(btnRegistrations);
            StyleSidebarButton(btnUsers);
            StyleSidebarButton(btnReports);
            StyleSidebarButton(btnLogout);
            
            // Set logout button background to a soft warning color on hover
            btnLogout.MouseEnter += (s, ev) => btnLogout.BackColor = FormStyle.DangerColor;
            btnLogout.MouseLeave += (s, ev) => btnLogout.BackColor = FormStyle.PrimaryColor;

            // Load the default screen: Reports & Summary Statistics
            LoadChildForm(new ReportsForm(), "Reports & System Summary", btnReports);
        }

        /// <summary>
        /// Styles a sidebar button to match the dark theme and adds hover micro-animations.
        /// </summary>
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
            
            // Force text left padding
            btn.Padding = new Padding(15, 0, 0, 0);

            // Simple visual active status tracking
            btn.Click += (s, e) => ResetActiveButtonStyles();
        }

        private void ResetActiveButtonStyles()
        {
            // Set all sidebar buttons back to primary background
            btnEvents.BackColor = FormStyle.PrimaryColor;
            btnParticipants.BackColor = FormStyle.PrimaryColor;
            btnRegistrations.BackColor = FormStyle.PrimaryColor;
            btnUsers.BackColor = FormStyle.PrimaryColor;
            btnReports.BackColor = FormStyle.PrimaryColor;
        }

        /// <summary>
        /// Dynamic Form Loader: Loads any Form inside the main content panel.
        /// This eliminates multi-window clutter and provides a clean desktop experience.
        /// </summary>
        public void LoadChildForm(Form childForm, string title, Button sidebarButton)
        {
            try
            {
                // If there's an active form, close it to free up resources
                if (activeForm != null)
                {
                    activeForm.Close();
                }

                activeForm = childForm;
                
                // Configure child form as a control
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                
                // Add to panel container
                panelContent.Controls.Clear();
                panelContent.Controls.Add(childForm);
                panelContent.Tag = childForm;
                
                // Refresh title and active button highlights
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
            LoadChildForm(new EventManagementForm(), "Manage Events", btnEvents);
        }

        private void btnParticipants_Click(object sender, EventArgs e)
        {
            LoadChildForm(new ParticipantManagementForm(), "Manage Participants", btnParticipants);
        }

        private void btnRegistrations_Click(object sender, EventArgs e)
        {
            LoadChildForm(new RegistrationManagementForm(), "Manage Registrations", btnRegistrations);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            LoadChildForm(new UserManagementForm(), "Manage System Users", btnUsers);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            LoadChildForm(new ReportsForm(), "Reports & System Summary", btnReports);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
