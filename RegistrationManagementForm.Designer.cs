namespace EventManagementSystem
{
    partial class RegistrationManagementForm
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
            this.panelGrid = new System.Windows.Forms.Panel();
            this.dgvRegistrations = new System.Windows.Forms.DataGridView();
            this.lblGridHeader = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.Panel();
            this.lblSelectedLabel = new System.Windows.Forms.Label();
            this.lblSelectedId = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrations)).BeginInit();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.dgvRegistrations);
            this.panelGrid.Controls.Add(this.lblGridHeader);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(20);
            this.panelGrid.Size = new System.Drawing.Size(770, 490);
            this.panelGrid.TabIndex = 0;
            
            // 
            // dgvRegistrations
            // 
            this.dgvRegistrations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegistrations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegistrations.Location = new System.Drawing.Point(20, 55);
            this.dgvRegistrations.Name = "dgvRegistrations";
            this.dgvRegistrations.Size = new System.Drawing.Size(730, 415);
            this.dgvRegistrations.TabIndex = 1;
            this.dgvRegistrations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRegistrations_CellClick);
            
            // 
            // lblGridHeader
            // 
            this.lblGridHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGridHeader.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblGridHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblGridHeader.Location = new System.Drawing.Point(20, 20);
            this.lblGridHeader.Name = "lblGridHeader";
            this.lblGridHeader.Size = new System.Drawing.Size(730, 35);
            this.lblGridHeader.TabIndex = 0;
            this.lblGridHeader.Text = "Registration Status Records";
            
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.White;
            this.panelActions.Controls.Add(this.btnDelete);
            this.panelActions.Controls.Add(this.btnReject);
            this.panelActions.Controls.Add(this.btnApprove);
            this.panelActions.Controls.Add(this.lblSelectedId);
            this.panelActions.Controls.Add(this.lblSelectedLabel);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(0, 490);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(770, 80);
            this.panelActions.TabIndex = 1;
            
            // 
            // lblSelectedLabel
            // 
            this.lblSelectedLabel.AutoSize = true;
            this.lblSelectedLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSelectedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSelectedLabel.Location = new System.Drawing.Point(22, 31);
            this.lblSelectedLabel.Name = "lblSelectedLabel";
            this.lblSelectedLabel.Size = new System.Drawing.Size(152, 17);
            this.lblSelectedLabel.TabIndex = 0;
            this.lblSelectedLabel.Text = "Selected Registration ID:";
            
            // 
            // lblSelectedId
            // 
            this.lblSelectedId.AutoSize = true;
            this.lblSelectedId.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSelectedId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSelectedId.Location = new System.Drawing.Point(175, 28);
            this.lblSelectedId.Name = "lblSelectedId";
            this.lblSelectedId.Size = new System.Drawing.Size(43, 21);
            this.lblSelectedId.TabIndex = 1;
            this.lblSelectedId.Text = "None";
            
            // 
            // btnApprove
            // 
            this.btnApprove.Location = new System.Drawing.Point(270, 22);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(140, 38);
            this.btnApprove.TabIndex = 2;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.Location = new System.Drawing.Point(425, 22);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(140, 38);
            this.btnReject.TabIndex = 3;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(580, 22);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(140, 38);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete Registration";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // RegistrationManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 570);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelActions);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistrationManagementForm";
            this.Text = "RegistrationManagementForm";
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistrations)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.panelActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView dgvRegistrations;
        private System.Windows.Forms.Label lblGridHeader;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Label lblSelectedLabel;
        private System.Windows.Forms.Label lblSelectedId;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnDelete;
    }
}
