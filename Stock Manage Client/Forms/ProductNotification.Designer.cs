namespace Stock_Manage_Client.Forms
{
    partial class ProductNotification
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
            this.dgdProducts = new System.Windows.Forms.DataGridView();
            this.cmdCreateOrder = new System.Windows.Forms.Button();
            this.cmdDismiss = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgdProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgdProducts
            // 
            this.dgdProducts.AllowUserToAddRows = false;
            this.dgdProducts.AllowUserToDeleteRows = false;
            this.dgdProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgdProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdProducts.Location = new System.Drawing.Point(12, 12);
            this.dgdProducts.MultiSelect = false;
            this.dgdProducts.Name = "dgdProducts";
            this.dgdProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdProducts.Size = new System.Drawing.Size(1162, 150);
            this.dgdProducts.TabIndex = 0;
            // 
            // cmdCreateOrder
            // 
            this.cmdCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmdCreateOrder.Location = new System.Drawing.Point(12, 168);
            this.cmdCreateOrder.Name = "cmdCreateOrder";
            this.cmdCreateOrder.Size = new System.Drawing.Size(75, 23);
            this.cmdCreateOrder.TabIndex = 1;
            this.cmdCreateOrder.Text = "Create Order";
            this.cmdCreateOrder.UseVisualStyleBackColor = true;
            this.cmdCreateOrder.Click += new System.EventHandler(this.cmdCreateOrder_Click);
            // 
            // cmdDismiss
            // 
            this.cmdDismiss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDismiss.Location = new System.Drawing.Point(1099, 168);
            this.cmdDismiss.Name = "cmdDismiss";
            this.cmdDismiss.Size = new System.Drawing.Size(75, 23);
            this.cmdDismiss.TabIndex = 2;
            this.cmdDismiss.Text = "Dismiss";
            this.cmdDismiss.UseVisualStyleBackColor = true;
            this.cmdDismiss.Click += new System.EventHandler(this.cmdDismiss_Click);
            // 
            // ProductNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 202);
            this.Controls.Add(this.cmdDismiss);
            this.Controls.Add(this.cmdCreateOrder);
            this.Controls.Add(this.dgdProducts);
            this.Name = "ProductNotification";
            this.Text = "Low Product Notification";
            ((System.ComponentModel.ISupportInitialize)(this.dgdProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgdProducts;
        private System.Windows.Forms.Button cmdCreateOrder;
        private System.Windows.Forms.Button cmdDismiss;
    }
}