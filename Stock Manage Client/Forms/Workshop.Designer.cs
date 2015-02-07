namespace Stock_Manage_Client.Forms
{
    partial class Workshop
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
            this.tc_MainControl = new System.Windows.Forms.TabControl();
            this.cmdManageProducts = new System.Windows.Forms.Button();
            this.btn_CloseTab = new System.Windows.Forms.Button();
            this.dgdUsers = new System.Windows.Forms.DataGridView();
            this.cmdLogOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgdUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // tc_MainControl
            // 
            this.tc_MainControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tc_MainControl.Location = new System.Drawing.Point(115, 12);
            this.tc_MainControl.Name = "tc_MainControl";
            this.tc_MainControl.SelectedIndex = 0;
            this.tc_MainControl.Size = new System.Drawing.Size(874, 705);
            this.tc_MainControl.TabIndex = 7;
            // 
            // cmdManageProducts
            // 
            this.cmdManageProducts.Location = new System.Drawing.Point(5, 41);
            this.cmdManageProducts.Name = "cmdManageProducts";
            this.cmdManageProducts.Size = new System.Drawing.Size(104, 23);
            this.cmdManageProducts.TabIndex = 16;
            this.cmdManageProducts.Text = "Manage Products";
            this.cmdManageProducts.UseVisualStyleBackColor = true;
            this.cmdManageProducts.Click += new System.EventHandler(this.cmdManageProducts_Click);
            // 
            // btn_CloseTab
            // 
            this.btn_CloseTab.Location = new System.Drawing.Point(5, 12);
            this.btn_CloseTab.Name = "btn_CloseTab";
            this.btn_CloseTab.Size = new System.Drawing.Size(104, 23);
            this.btn_CloseTab.TabIndex = 15;
            this.btn_CloseTab.Text = "Close Current Tab";
            this.btn_CloseTab.UseVisualStyleBackColor = true;
            // 
            // dgdUsers
            // 
            this.dgdUsers.AllowUserToAddRows = false;
            this.dgdUsers.AllowUserToDeleteRows = false;
            this.dgdUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgdUsers.Location = new System.Drawing.Point(995, 12);
            this.dgdUsers.MultiSelect = false;
            this.dgdUsers.Name = "dgdUsers";
            this.dgdUsers.ReadOnly = true;
            this.dgdUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdUsers.Size = new System.Drawing.Size(343, 705);
            this.dgdUsers.TabIndex = 17;
            this.dgdUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgdUsers_CellClick);
            // 
            // cmdLogOut
            // 
            this.cmdLogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdLogOut.Enabled = false;
            this.cmdLogOut.Location = new System.Drawing.Point(5, 610);
            this.cmdLogOut.Name = "cmdLogOut";
            this.cmdLogOut.Size = new System.Drawing.Size(104, 107);
            this.cmdLogOut.TabIndex = 18;
            this.cmdLogOut.Text = "Log Out";
            this.cmdLogOut.UseVisualStyleBackColor = true;
            this.cmdLogOut.Click += new System.EventHandler(this.cmdLogOut_Click);
            // 
            // Workshop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.cmdLogOut);
            this.Controls.Add(this.dgdUsers);
            this.Controls.Add(this.cmdManageProducts);
            this.Controls.Add(this.btn_CloseTab);
            this.Controls.Add(this.tc_MainControl);
            this.Name = "Workshop";
            this.Text = "Workshop Control";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgdUsers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_MainControl;
        private System.Windows.Forms.Button cmdManageProducts;
        private System.Windows.Forms.Button btn_CloseTab;
        private System.Windows.Forms.DataGridView dgdUsers;
        private System.Windows.Forms.Button cmdLogOut;

    }
}