namespace Stock_Manage_Client.Forms
{
    partial class ChangeUserDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblSystemRole = new System.Windows.Forms.Label();
            this.cboSystemRole = new System.Windows.Forms.ComboBox();
            this.cmdChangeUserDetails = new System.Windows.Forms.Button();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(12, 35);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(57, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "First Name";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(12, 61);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(58, 13);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(84, 32);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(121, 20);
            this.txtFirstName.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(84, 58);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(121, 20);
            this.txtLastName.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(12, 88);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(84, 85);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // lblSystemRole
            // 
            this.lblSystemRole.AutoSize = true;
            this.lblSystemRole.Location = new System.Drawing.Point(12, 114);
            this.lblSystemRole.Name = "lblSystemRole";
            this.lblSystemRole.Size = new System.Drawing.Size(66, 13);
            this.lblSystemRole.TabIndex = 6;
            this.lblSystemRole.Text = "System Role";
            // 
            // cboSystemRole
            // 
            this.cboSystemRole.FormattingEnabled = true;
            this.cboSystemRole.Items.AddRange(new object[] {
            "Management",
            "Ordering",
            "Workshop"});
            this.cboSystemRole.Location = new System.Drawing.Point(84, 111);
            this.cboSystemRole.Name = "cboSystemRole";
            this.cboSystemRole.Size = new System.Drawing.Size(121, 21);
            this.cboSystemRole.TabIndex = 7;
            // 
            // cmdChangeUserDetails
            // 
            this.cmdChangeUserDetails.Location = new System.Drawing.Point(15, 138);
            this.cmdChangeUserDetails.Name = "cmdChangeUserDetails";
            this.cmdChangeUserDetails.Size = new System.Drawing.Size(190, 23);
            this.cmdChangeUserDetails.TabIndex = 8;
            this.cmdChangeUserDetails.Text = "Change User Details";
            this.cmdChangeUserDetails.UseVisualStyleBackColor = true;
            this.cmdChangeUserDetails.Click += new System.EventHandler(this.cmdChangeUserDetails_Click);
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(12, 9);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(41, 13);
            this.lblUserId.TabIndex = 9;
            this.lblUserId.Text = "User Id";
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(84, 6);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(121, 20);
            this.txtUserId.TabIndex = 10;
            // 
            // ChangeUserDetails
            // 
            this.AcceptButton = this.cmdChangeUserDetails;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 171);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.cmdChangeUserDetails);
            this.Controls.Add(this.cboSystemRole);
            this.Controls.Add(this.lblSystemRole);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeUserDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change User Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblSystemRole;
        private System.Windows.Forms.ComboBox cboSystemRole;
        private System.Windows.Forms.Button cmdChangeUserDetails;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.TextBox txtUserId;
    }
}