namespace Stock_Manage_Client.Forms
{
    partial class Management
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
            this.btn_newUser = new System.Windows.Forms.Button();
            this.tc_MainControl = new System.Windows.Forms.TabControl();
            this.btn_CloseTab = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_newUser
            // 
            this.btn_newUser.Location = new System.Drawing.Point(5, 40);
            this.btn_newUser.Name = "btn_newUser";
            this.btn_newUser.Size = new System.Drawing.Size(104, 23);
            this.btn_newUser.TabIndex = 7;
            this.btn_newUser.Text = "Add New User";
            this.btn_newUser.UseVisualStyleBackColor = true;
            this.btn_newUser.Click += new System.EventHandler(this.btn_newUser_Click);
            // 
            // tc_MainControl
            // 
            this.tc_MainControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tc_MainControl.Location = new System.Drawing.Point(115, 12);
            this.tc_MainControl.Name = "tc_MainControl";
            this.tc_MainControl.SelectedIndex = 0;
            this.tc_MainControl.Size = new System.Drawing.Size(1079, 842);
            this.tc_MainControl.TabIndex = 6;
            // 
            // btn_CloseTab
            // 
            this.btn_CloseTab.Location = new System.Drawing.Point(5, 12);
            this.btn_CloseTab.Name = "btn_CloseTab";
            this.btn_CloseTab.Size = new System.Drawing.Size(104, 23);
            this.btn_CloseTab.TabIndex = 8;
            this.btn_CloseTab.Text = "Close Current Tab";
            this.btn_CloseTab.UseVisualStyleBackColor = true;
            this.btn_CloseTab.Click += new System.EventHandler(this.btn_CloseTab_Click);
            // 
            // Management
            // 
            this.ClientSize = new System.Drawing.Size(1206, 866);
            this.Controls.Add(this.btn_CloseTab);
            this.Controls.Add(this.btn_newUser);
            this.Controls.Add(this.tc_MainControl);
            this.Name = "Management";
            this.Tag = "";
            this.Text = "Management Control";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_newUser;
        private System.Windows.Forms.TabControl tc_MainControl;
        private System.Windows.Forms.Button btn_CloseTab;



    }
}

