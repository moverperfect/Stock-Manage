namespace Stock_Manage_Client.Forms
{
    partial class OrderNotification
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
            this.cmdVerify = new System.Windows.Forms.Button();
            this.cmdOrderDetails = new System.Windows.Forms.Button();
            this.dgdOrders = new System.Windows.Forms.DataGridView();
            this.cmdDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgdOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdVerify
            // 
            this.cmdVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdVerify.Location = new System.Drawing.Point(1017, 168);
            this.cmdVerify.Name = "cmdVerify";
            this.cmdVerify.Size = new System.Drawing.Size(75, 23);
            this.cmdVerify.TabIndex = 5;
            this.cmdVerify.Text = "Verify Order";
            this.cmdVerify.UseVisualStyleBackColor = true;
            // 
            // cmdOrderDetails
            // 
            this.cmdOrderDetails.Location = new System.Drawing.Point(11, 168);
            this.cmdOrderDetails.Name = "cmdOrderDetails";
            this.cmdOrderDetails.Size = new System.Drawing.Size(75, 23);
            this.cmdOrderDetails.TabIndex = 4;
            this.cmdOrderDetails.Text = "Details";
            this.cmdOrderDetails.UseVisualStyleBackColor = true;
            this.cmdOrderDetails.Click += new System.EventHandler(this.cmdOrderDetails_Click);
            // 
            // dgdOrders
            // 
            this.dgdOrders.AllowUserToAddRows = false;
            this.dgdOrders.AllowUserToDeleteRows = false;
            this.dgdOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgdOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdOrders.Location = new System.Drawing.Point(11, 12);
            this.dgdOrders.MultiSelect = false;
            this.dgdOrders.Name = "dgdOrders";
            this.dgdOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdOrders.Size = new System.Drawing.Size(1162, 150);
            this.dgdOrders.TabIndex = 3;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDelete.Location = new System.Drawing.Point(1098, 168);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 6;
            this.cmdDelete.Text = "Delete Order";
            this.cmdDelete.UseVisualStyleBackColor = true;
            // 
            // OrderNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 202);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.cmdVerify);
            this.Controls.Add(this.cmdOrderDetails);
            this.Controls.Add(this.dgdOrders);
            this.MaximumSize = new System.Drawing.Size(1200, 240);
            this.Name = "OrderNotification";
            this.Text = "OrderNotification";
            ((System.ComponentModel.ISupportInitialize)(this.dgdOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdVerify;
        private System.Windows.Forms.Button cmdOrderDetails;
        private System.Windows.Forms.DataGridView dgdOrders;
        private System.Windows.Forms.Button cmdDelete;
    }
}