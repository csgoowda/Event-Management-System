namespace EventManagementSystem
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblHeader = new System.Windows.Forms.Label();
            this.panelUsersCard = new System.Windows.Forms.Panel();
            this.panelUsersBar = new System.Windows.Forms.Panel();
            this.lblUsersTitle = new System.Windows.Forms.Label();
            this.lblUsersVal = new System.Windows.Forms.Label();
            
            this.panelEventsCard = new System.Windows.Forms.Panel();
            this.panelEventsBar = new System.Windows.Forms.Panel();
            this.lblEventsTitle = new System.Windows.Forms.Label();
            this.lblEventsVal = new System.Windows.Forms.Label();
            
            this.panelPartsCard = new System.Windows.Forms.Panel();
            this.panelPartsBar = new System.Windows.Forms.Panel();
            this.lblPartsTitle = new System.Windows.Forms.Label();
            this.lblPartsVal = new System.Windows.Forms.Label();
            
            this.panelRegsCard = new System.Windows.Forms.Panel();
            this.panelRegsBar = new System.Windows.Forms.Panel();
            this.lblRegsTitle = new System.Windows.Forms.Label();
            this.lblRegsVal = new System.Windows.Forms.Label();
            
            this.lblSubHeader = new System.Windows.Forms.Label();
            
            this.panelUsersCard.SuspendLayout();
            this.panelEventsCard.SuspendLayout();
            this.panelPartsCard.SuspendLayout();
            this.panelRegsCard.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblHeader.Location = new System.Drawing.Point(50, 30);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(199, 30);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "System Analytics";
            // 
            // lblSubHeader
            // 
            this.lblSubHeader.AutoSize = true;
            this.lblSubHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblSubHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblSubHeader.Location = new System.Drawing.Point(52, 63);
            this.lblSubHeader.Name = "lblSubHeader";
            this.lblSubHeader.Size = new System.Drawing.Size(317, 17);
            this.lblSubHeader.TabIndex = 5;
            this.lblSubHeader.Text = "Real-time summary statistics of system in-memory data.";
            // 
            // panelUsersCard
            // 
            this.panelUsersCard.BackColor = System.Drawing.Color.White;
            this.panelUsersCard.Controls.Add(this.lblUsersVal);
            this.panelUsersCard.Controls.Add(this.lblUsersTitle);
            this.panelUsersCard.Controls.Add(this.panelUsersBar);
            this.panelUsersCard.Location = new System.Drawing.Point(100, 110);
            this.panelUsersCard.Name = "panelUsersCard";
            this.panelUsersCard.Size = new System.Drawing.Size(250, 150);
            this.panelUsersCard.TabIndex = 1;
            // 
            // panelUsersBar
            // 
            this.panelUsersBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelUsersBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUsersBar.Location = new System.Drawing.Point(0, 0);
            this.panelUsersBar.Name = "panelUsersBar";
            this.panelUsersBar.Size = new System.Drawing.Size(250, 6);
            this.panelUsersBar.TabIndex = 0;
            // 
            // lblUsersTitle
            // 
            this.lblUsersTitle.AutoSize = true;
            this.lblUsersTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblUsersTitle.Location = new System.Drawing.Point(20, 25);
            this.lblUsersTitle.Name = "lblUsersTitle";
            this.lblUsersTitle.Size = new System.Drawing.Size(126, 15);
            this.lblUsersTitle.TabIndex = 1;
            this.lblUsersTitle.Text = "REGISTERED USERS";
            // 
            // lblUsersVal
            // 
            this.lblUsersVal.Font = new System.Drawing.Font("Segoe UI Semibold", 28F, System.Drawing.FontStyle.Bold);
            this.lblUsersVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblUsersVal.Location = new System.Drawing.Point(15, 50);
            this.lblUsersVal.Name = "lblUsersVal";
            this.lblUsersVal.Size = new System.Drawing.Size(220, 75);
            this.lblUsersVal.TabIndex = 2;
            this.lblUsersVal.Text = "0";
            this.lblUsersVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelEventsCard
            // 
            this.panelEventsCard.BackColor = System.Drawing.Color.White;
            this.panelEventsCard.Controls.Add(this.lblEventsVal);
            this.panelEventsCard.Controls.Add(this.lblEventsTitle);
            this.panelEventsCard.Controls.Add(this.panelEventsBar);
            this.panelEventsCard.Location = new System.Drawing.Point(420, 110);
            this.panelEventsCard.Name = "panelEventsCard";
            this.panelEventsCard.Size = new System.Drawing.Size(250, 150);
            this.panelEventsCard.TabIndex = 2;
            // 
            // panelEventsBar
            // 
            this.panelEventsBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.panelEventsBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEventsBar.Location = new System.Drawing.Point(0, 0);
            this.panelEventsBar.Name = "panelEventsBar";
            this.panelEventsBar.Size = new System.Drawing.Size(250, 6);
            this.panelEventsBar.TabIndex = 0;
            // 
            // lblEventsTitle
            // 
            this.lblEventsTitle.AutoSize = true;
            this.lblEventsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblEventsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblEventsTitle.Location = new System.Drawing.Point(20, 25);
            this.lblEventsTitle.Name = "lblEventsTitle";
            this.lblEventsTitle.Size = new System.Drawing.Size(124, 15);
            this.lblEventsTitle.TabIndex = 1;
            this.lblEventsTitle.Text = "SCHEDULED EVENTS";
            // 
            // lblEventsVal
            // 
            this.lblEventsVal.Font = new System.Drawing.Font("Segoe UI Semibold", 28F, System.Drawing.FontStyle.Bold);
            this.lblEventsVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblEventsVal.Location = new System.Drawing.Point(15, 50);
            this.lblEventsVal.Name = "lblEventsVal";
            this.lblEventsVal.Size = new System.Drawing.Size(220, 75);
            this.lblEventsVal.TabIndex = 2;
            this.lblEventsVal.Text = "0";
            this.lblEventsVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelPartsCard
            // 
            this.panelPartsCard.BackColor = System.Drawing.Color.White;
            this.panelPartsCard.Controls.Add(this.lblPartsVal);
            this.panelPartsCard.Controls.Add(this.lblPartsTitle);
            this.panelPartsCard.Controls.Add(this.panelPartsBar);
            this.panelPartsCard.Location = new System.Drawing.Point(100, 310);
            this.panelPartsCard.Name = "panelPartsCard";
            this.panelPartsCard.Size = new System.Drawing.Size(250, 150);
            this.panelPartsCard.TabIndex = 3;
            // 
            // panelPartsBar
            // 
            this.panelPartsBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.panelPartsBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPartsBar.Location = new System.Drawing.Point(0, 0);
            this.panelPartsBar.Name = "panelPartsBar";
            this.panelPartsBar.Size = new System.Drawing.Size(250, 6);
            this.panelPartsBar.TabIndex = 0;
            // 
            // lblPartsTitle
            // 
            this.lblPartsTitle.AutoSize = true;
            this.lblPartsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblPartsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblPartsTitle.Location = new System.Drawing.Point(20, 25);
            this.lblPartsTitle.Name = "lblPartsTitle";
            this.lblPartsTitle.Size = new System.Drawing.Size(126, 15);
            this.lblPartsTitle.TabIndex = 1;
            this.lblPartsTitle.Text = "TOTAL PARTICIPANTS";
            // 
            // lblPartsVal
            // 
            this.lblPartsVal.Font = new System.Drawing.Font("Segoe UI Semibold", 28F, System.Drawing.FontStyle.Bold);
            this.lblPartsVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblPartsVal.Location = new System.Drawing.Point(15, 50);
            this.lblPartsVal.Name = "lblPartsVal";
            this.lblPartsVal.Size = new System.Drawing.Size(220, 75);
            this.lblPartsVal.TabIndex = 2;
            this.lblPartsVal.Text = "0";
            this.lblPartsVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelRegsCard
            // 
            this.panelRegsCard.BackColor = System.Drawing.Color.White;
            this.panelRegsCard.Controls.Add(this.lblRegsVal);
            this.panelRegsCard.Controls.Add(this.lblRegsTitle);
            this.panelRegsCard.Controls.Add(this.panelRegsBar);
            this.panelRegsCard.Location = new System.Drawing.Point(420, 310);
            this.panelRegsCard.Name = "panelRegsCard";
            this.panelRegsCard.Size = new System.Drawing.Size(250, 150);
            this.panelRegsCard.TabIndex = 4;
            // 
            // panelRegsBar
            // 
            this.panelRegsBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.panelRegsBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRegsBar.Location = new System.Drawing.Point(0, 0);
            this.panelRegsBar.Name = "panelRegsBar";
            this.panelRegsBar.Size = new System.Drawing.Size(250, 6);
            this.panelRegsBar.TabIndex = 0;
            // 
            // lblRegsTitle
            // 
            this.lblRegsTitle.AutoSize = true;
            this.lblRegsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.lblRegsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblRegsTitle.Location = new System.Drawing.Point(20, 25);
            this.lblRegsTitle.Name = "lblRegsTitle";
            this.lblRegsTitle.Size = new System.Drawing.Size(135, 15);
            this.lblRegsTitle.TabIndex = 1;
            this.lblRegsTitle.Text = "TOTAL REGISTRATIONS";
            // 
            // lblRegsVal
            // 
            this.lblRegsVal.Font = new System.Drawing.Font("Segoe UI Semibold", 28F, System.Drawing.FontStyle.Bold);
            this.lblRegsVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblRegsVal.Location = new System.Drawing.Point(15, 50);
            this.lblRegsVal.Name = "lblRegsVal";
            this.lblRegsVal.Size = new System.Drawing.Size(220, 75);
            this.lblRegsVal.TabIndex = 2;
            this.lblRegsVal.Text = "0";
            this.lblRegsVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 570);
            this.Controls.Add(this.lblSubHeader);
            this.Controls.Add(this.panelRegsCard);
            this.Controls.Add(this.panelPartsCard);
            this.Controls.Add(this.panelEventsCard);
            this.Controls.Add(this.panelUsersCard);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportsForm";
            this.Text = "ReportsForm";
            this.panelUsersCard.ResumeLayout(false);
            this.panelUsersCard.PerformLayout();
            this.panelEventsCard.ResumeLayout(false);
            this.panelEventsCard.PerformLayout();
            this.panelPartsCard.ResumeLayout(false);
            this.panelPartsCard.PerformLayout();
            this.panelRegsCard.ResumeLayout(false);
            this.panelRegsCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panelUsersCard;
        private System.Windows.Forms.Panel panelUsersBar;
        private System.Windows.Forms.Label lblUsersTitle;
        private System.Windows.Forms.Label lblUsersVal;
        private System.Windows.Forms.Panel panelEventsCard;
        private System.Windows.Forms.Panel panelEventsBar;
        private System.Windows.Forms.Label lblEventsTitle;
        private System.Windows.Forms.Label lblEventsVal;
        private System.Windows.Forms.Panel panelPartsCard;
        private System.Windows.Forms.Panel panelPartsBar;
        private System.Windows.Forms.Label lblPartsTitle;
        private System.Windows.Forms.Label lblPartsVal;
        private System.Windows.Forms.Panel panelRegsCard;
        private System.Windows.Forms.Panel panelRegsBar;
        private System.Windows.Forms.Label lblRegsTitle;
        private System.Windows.Forms.Label lblRegsVal;
        private System.Windows.Forms.Label lblSubHeader;
    }
}
