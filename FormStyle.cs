using System;
using System.Drawing;
using System.Windows.Forms;

namespace EventManagementSystem
{
    /// <summary>
    /// Static helper class containing UI styles, colors, and styling functions.
    /// Helps apply a modern theme consistently across all Forms.
    /// </summary>
    public static class FormStyle
    {
        // Modern Color Palette (Slate Navy & Emerald Green Accent)
        public static readonly Color PrimaryColor = Color.FromArgb(44, 62, 80);      // Dark slate navy
        public static readonly Color SecondaryColor = Color.FromArgb(52, 73, 94);   // Lighter slate
        public static readonly Color AccentColor = Color.FromArgb(26, 188, 156);     // Turquoise / Emerald
        public static readonly Color DangerColor = Color.FromArgb(231, 76, 60);      // Soft Red
        public static readonly Color SuccessColor = Color.FromArgb(46, 204, 113);    // Soft Green
        public static readonly Color BackgroundColor = Color.FromArgb(236, 240, 241); // Light Gray
        public static readonly Color PanelColor = Color.FromArgb(52, 73, 94);        // Panel sidebar background
        public static readonly Color ContentBgColor = Color.White;                  // Card backgrounds
        public static readonly Color PrimaryText = Color.FromArgb(44, 62, 80);        // Text navy
        public static readonly Color SecondaryText = Color.FromArgb(127, 140, 141);  // Text gray
        public static readonly Color LightText = Color.White;

        // Fonts
        public static readonly Font TitleFont = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
        public static readonly Font HeaderFont = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
        public static readonly Font BodyFont = new Font("Segoe UI", 9.75F, FontStyle.Regular);
        public static readonly Font ButtonFont = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
        public static readonly Font SmallFont = new Font("Segoe UI", 8.25F, FontStyle.Regular);

        /// <summary>
        /// Styles a standard Form with default background and font.
        /// </summary>
        public static void StyleForm(Form form)
        {
            form.BackColor = BackgroundColor;
            form.Font = BodyFont;
            form.ForeColor = PrimaryText;
        }

        /// <summary>
        /// Programmatically styles a button with modern colors, flat borders, hand cursors, and hover transitions.
        /// </summary>
        public static void StyleButton(Button btn, Color backColor, Color foreColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = ButtonFont;
            btn.Cursor = Cursors.Hand;
            btn.Height = 35;

            // Simple micro-animation on hover
            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(
                    Math.Max(0, backColor.R - 25),
                    Math.Max(0, backColor.G - 25),
                    Math.Max(0, backColor.B - 25)
                );
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = backColor;
            };
        }

        /// <summary>
        /// Styles a text box with thin borders and clean padding.
        /// </summary>
        public static void StyleTextBox(TextBox txt)
        {
            txt.Font = BodyFont;
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = Color.White;
            txt.ForeColor = PrimaryText;
        }

        /// <summary>
        /// Formats a DataGridView to look clean, readable, and flat.
        /// </summary>
        public static void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            
            // Header Styles
            dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = HeaderFont;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = PrimaryColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            dgv.ColumnHeadersHeight = 38;
            dgv.EnableHeadersVisualStyles = false;

            // Row Styles
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = PrimaryText;
            dgv.DefaultCellStyle.Font = BodyFont;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219); // Modern soft blue selection
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250); // Alternating light gray blue
            
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowTemplate.Height = 30;
            dgv.GridColor = Color.FromArgb(220, 224, 230);
        }
    }
}
