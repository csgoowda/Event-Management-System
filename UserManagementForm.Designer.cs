namespace EventManagementSystem
{
    partial class UserManagementForm
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.lblGridHeader = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.Panel();
            this.lblSelectedLabel = new System.Windows.Forms.Label();
            this.lblSelectedUser = new System.Windows.Forms.Label();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.dgvUsers);
            this.panelGrid.Controls.Add(this.lblGridHeader);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Padding = new System.Windows.Forms.Padding(20);
            this.panelGrid.Size = new System.Drawing.Size(770, 490);
            this.panelGrid.TabIndex = 0;
            
            // 
            // dgvUsers
            // 
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(20, 55);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.Size = new System.Drawing.Size(730, 415);
            this.dgvUsers.TabIndex = 1;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            
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
            this.lblGridHeader.Text = "System Registered User Accounts";
            
            // 
            // panelActions
            // 
            this.panelActions.BackColor = System.Drawing.Color.White;
            this.panelActions.Controls.Add(this.btnDeleteUser);
            this.panelActions.Controls.Add(this.lblSelectedUser);
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
            this.lblSelectedLabel.Size = new System.Drawing.Size(124, 17);
            this.lblSelectedLabel.TabIndex = 0;
            this.lblSelectedLabel.Text = "Selected Username:";
            
            // 
            // lblSelectedUser
            // 
            this.lblSelectedUser.AutoSize = true;
            this.lblSelectedUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSelectedUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblSelectedUser.Location = new System.Drawing.Point(155, 28);
            this.lblSelectedUser.Name = "lblSelectedUser";
            this.lblSelectedUser.Size = new System.Drawing.Size(53, 21);
            this.lblSelectedUser.TabIndex = 1;
            this.lblSelectedUser.Text = "None";
            
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(520, 22);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(200, 38);
            this.btnDeleteUser.TabIndex = 2;
            this.btnDeleteUser.Text = "Delete User Account";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // UserManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 570);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelActions);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserManagementForm";
            this.Text = "UserManagementForm";
            this.panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.panelActions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelGrid;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label lblGridHeader;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Label lblSelectedLabel;
        private System.Windows.Forms.Label lblSelectedUser;
        private System.Windows.Forms.Button btnDeleteUser;
    }
}
