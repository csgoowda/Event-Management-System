using System;
using System.Windows.Forms;

namespace EventManagementSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Initialize database with default sample data
            Database.InitializeSampleData();

            Application.Run(new LoginForm());
        }
    }
}
