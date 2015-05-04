namespace Stock_Manage_Client.Forms
{
    internal partial class Management
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
            this.cmdManageUsers = new System.Windows.Forms.Button();
            this.cmdManageProducts = new System.Windows.Forms.Button();
            this.cmdManageSuppliers = new System.Windows.Forms.Button();
            this.cmdManageOrders = new System.Windows.Forms.Button();
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
            this.tc_MainControl.Size = new System.Drawing.Size(1223, 705);
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
            // cmdManageUsers
            // 
            this.cmdManageUsers.Location = new System.Drawing.Point(5, 70);
            this.cmdManageUsers.Name = "cmdManageUsers";
            this.cmdManageUsers.Size = new System.Drawing.Size(104, 23);
            this.cmdManageUsers.TabIndex = 9;
            this.cmdManageUsers.Text = "Manage Users";
            this.cmdManageUsers.UseVisualStyleBackColor = true;
            this.cmdManageUsers.Click += new System.EventHandler(this.cmdManageUsers_Click);
            // 
            // cmdManageProducts
            // 
            this.cmdManageProducts.Location = new System.Drawing.Point(5, 99);
            this.cmdManageProducts.Name = "cmdManageProducts";
            this.cmdManageProducts.Size = new System.Drawing.Size(104, 23);
            this.cmdManageProducts.TabIndex = 10;
            this.cmdManageProducts.Text = "Manage Products";
            this.cmdManageProducts.UseVisualStyleBackColor = true;
            this.cmdManageProducts.Click += new System.EventHandler(this.cmdManageProducts_Click);
            // 
            // cmdManageSuppliers
            // 
            this.cmdManageSuppliers.Location = new System.Drawing.Point(5, 128);
            this.cmdManageSuppliers.Name = "cmdManageSuppliers";
            this.cmdManageSuppliers.Size = new System.Drawing.Size(104, 23);
            this.cmdManageSuppliers.TabIndex = 11;
            this.cmdManageSuppliers.Text = "Manage Suppliers";
            this.cmdManageSuppliers.UseVisualStyleBackColor = true;
            this.cmdManageSuppliers.Click += new System.EventHandler(this.cmdManageSuppliers_Click);
            // 
            // cmdManageOrders
            // 
            this.cmdManageOrders.Location = new System.Drawing.Point(5, 157);
            this.cmdManageOrders.Name = "cmdManageOrders";
            this.cmdManageOrders.Size = new System.Drawing.Size(104, 23);
            this.cmdManageOrders.TabIndex = 12;
            this.cmdManageOrders.Text = "Manage Orders";
            this.cmdManageOrders.UseVisualStyleBackColor = true;
            this.cmdManageOrders.Click += new System.EventHandler(this.cmdManageOrders_Click);
            // 
            // Management
            // 
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.cmdManageOrders);
            this.Controls.Add(this.cmdManageSuppliers);
            this.Controls.Add(this.cmdManageProducts);
            this.Controls.Add(this.cmdManageUsers);
            this.Controls.Add(this.btn_CloseTab);
            this.Controls.Add(this.btn_newUser);
            this.Controls.Add(this.tc_MainControl);
            this.Name = "Management";
            this.Tag = "";
            this.Text = "Management Control";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_newUser;
        private System.Windows.Forms.TabControl tc_MainControl;
        private System.Windows.Forms.Button btn_CloseTab;
        private System.Windows.Forms.Button cmdManageUsers;
        private System.Windows.Forms.Button cmdManageProducts;
        private System.Windows.Forms.Button cmdManageSuppliers;
        private System.Windows.Forms.Button cmdManageOrders;



    }
}

