using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManagementSystem
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            
            this.Load += new EventHandler(ReportsForm_Load);
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            FormStyle.StyleForm(this);
            
            // Query counts from the central static database lists in real-time
            LoadReportStatistics();
        }

        /// <summary>
        /// Reads list sizes from the central Database class and prints them to UI labels.
        /// </summary>
        private void LoadReportStatistics()
        {
            try
            {
                int totalUsers = Database.Users.Count;
                int totalEvents = Database.Events.Count;
                int totalParticipants = Database.Participants.Count;
                int totalRegistrations = Database.Registrations.Count;

                lblUsersVal.Text = totalUsers.ToString();
                lblEventsVal.Text = totalEvents.ToString();
                lblPartsVal.Text = totalParticipants.ToString();
                lblRegsVal.Text = totalRegistrations.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error compiling report details: " + ex.Message, "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
