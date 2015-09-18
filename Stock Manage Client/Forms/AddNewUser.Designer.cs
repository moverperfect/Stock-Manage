namespace Stock_Manage_Client.Forms
{
    partial class AddNewUser
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
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.CmdAddUser = new System.Windows.Forms.Button();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.LblPassword = new System.Windows.Forms.Label();
            this.LblSecondName = new System.Windows.Forms.Label();
            this.LblFirstName = new System.Windows.Forms.Label();
            this.CboSystemRole = new System.Windows.Forms.ComboBox();
            this.LblSystemRole = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(89, 70);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(100, 20);
            this.TxtPassword.TabIndex = 0;
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            // 
            // CmdAddUser
            // 
            this.CmdAddUser.Location = new System.Drawing.Point(9, 130);
            this.CmdAddUser.Name = "CmdAddUser";
            this.CmdAddUser.Size = new System.Drawing.Size(75, 23);
            this.CmdAddUser.TabIndex = 5;
            this.CmdAddUser.Text = "Add User";
            this.CmdAddUser.UseVisualStyleBackColor = true;
            this.CmdAddUser.Click += new System.EventHandler(this.CmdAddUser_Click);
            // 
            // TxtLastName
            // 
            this.TxtLastName.Location = new System.Drawing.Point(89, 40);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(100, 20);
            this.TxtLastName.TabIndex = 2;
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Location = new System.Drawing.Point(89, 10);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(100, 20);
            this.TxtFirstName.TabIndex = 1;
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Location = new System.Drawing.Point(6, 73);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(53, 13);
            this.LblPassword.TabIndex = 6;
            this.LblPassword.Text = "Password";
            // 
            // LblSecondName
            // 
            this.LblSecondName.AutoSize = true;
            this.LblSecondName.Location = new System.Drawing.Point(6, 43);
            this.LblSecondName.Name = "LblSecondName";
            this.LblSecondName.Size = new System.Drawing.Size(75, 13);
            this.LblSecondName.TabIndex = 7;
            this.LblSecondName.Text = "Second Name";
            // 
            // LblFirstName
            // 
            this.LblFirstName.AutoSize = true;
            this.LblFirstName.Location = new System.Drawing.Point(6, 13);
            this.LblFirstName.Name = "LblFirstName";
            this.LblFirstName.Size = new System.Drawing.Size(57, 13);
            this.LblFirstName.TabIndex = 8;
            this.LblFirstName.Text = "First Name";
            // 
            // CboSystemRole
            // 
            this.CboSystemRole.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CboSystemRole.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CboSystemRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboSystemRole.FormattingEnabled = true;
            this.CboSystemRole.Items.AddRange(new object[] {
            "Management",
            "Ordering",
            "Workshop"});
            this.CboSystemRole.Location = new System.Drawing.Point(89, 100);
            this.CboSystemRole.Name = "CboSystemRole";
            this.CboSystemRole.Size = new System.Drawing.Size(100, 21);
            this.CboSystemRole.TabIndex = 4;
            // 
            // LblSystemRole
            // 
            this.LblSystemRole.AutoSize = true;
            this.LblSystemRole.Location = new System.Drawing.Point(6, 103);
            this.LblSystemRole.Name = "LblSystemRole";
            this.LblSystemRole.Size = new System.Drawing.Size(66, 13);
            this.LblSystemRole.TabIndex = 10;
            this.LblSystemRole.Text = "System Role";
            // 
            // AddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 165);
            this.Controls.Add(this.LblSystemRole);
            this.Controls.Add(this.CboSystemRole);
            this.Controls.Add(this.LblFirstName);
            this.Controls.Add(this.LblSecondName);
            this.Controls.Add(this.LblPassword);
            this.Controls.Add(this.TxtFirstName);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.CmdAddUser);
            this.Controls.Add(this.TxtPassword);
            this.Name = "AddNewUser";
            this.Text = "AddNewUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Button CmdAddUser;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.Label LblSecondName;
        private System.Windows.Forms.Label LblFirstName;
        private System.Windows.Forms.ComboBox CboSystemRole;
        private System.Windows.Forms.Label LblSystemRole;
    }
}