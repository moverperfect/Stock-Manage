namespace Stock_Manage_Client.Forms
{
    partial class Authentication
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
            this.lbl_Login = new System.Windows.Forms.Label();
            this.txt_UserId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Psswrd = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Login
            // 
            this.lbl_Login.AutoSize = true;
            this.lbl_Login.Location = new System.Drawing.Point(13, 13);
            this.lbl_Login.Name = "lbl_Login";
            this.lbl_Login.Size = new System.Drawing.Size(44, 13);
            this.lbl_Login.TabIndex = 0;
            this.lbl_Login.Text = "User Id:";
            // 
            // txt_UserId
            // 
            this.txt_UserId.Location = new System.Drawing.Point(13, 30);
            this.txt_UserId.Name = "txt_UserId";
            this.txt_UserId.Size = new System.Drawing.Size(100, 20);
            this.txt_UserId.TabIndex = 1;
            this.txt_UserId.TextChanged += new System.EventHandler(this.txt_UserId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Password:";
            // 
            // txt_Psswrd
            // 
            this.txt_Psswrd.Location = new System.Drawing.Point(13, 74);
            this.txt_Psswrd.Name = "txt_Psswrd";
            this.txt_Psswrd.Size = new System.Drawing.Size(100, 20);
            this.txt_Psswrd.TabIndex = 3;
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(38, 100);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            // 
            // Authentication
            // 
            this.AcceptButton = this.btn_Login;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(124, 132);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.txt_Psswrd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_UserId);
            this.Controls.Add(this.lbl_Login);
            this.Name = "Authentication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please enter login information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Login;
        private System.Windows.Forms.TextBox txt_UserId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Psswrd;
        private System.Windows.Forms.Button btn_Login;
    }
}