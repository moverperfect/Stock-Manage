namespace Stock_Manage_Client.Forms
{
    partial class AddChangeOrder
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
            this.dgdSuppliers = new System.Windows.Forms.DataGridView();
            this.dgdProducts = new System.Windows.Forms.DataGridView();
            this.cmdAddOrder = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblTotalCost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgdSuppliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgdSuppliers
            // 
            this.dgdSuppliers.AllowUserToAddRows = false;
            this.dgdSuppliers.AllowUserToDeleteRows = false;
            this.dgdSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdSuppliers.Location = new System.Drawing.Point(12, 12);
            this.dgdSuppliers.MultiSelect = false;
            this.dgdSuppliers.Name = "dgdSuppliers";
            this.dgdSuppliers.ReadOnly = true;
            this.dgdSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdSuppliers.Size = new System.Drawing.Size(288, 330);
            this.dgdSuppliers.TabIndex = 0;
            this.dgdSuppliers.SelectionChanged += new System.EventHandler(this.dgdSuppliers_SelectionChanged);
            // 
            // dgdProducts
            // 
            this.dgdProducts.AllowUserToAddRows = false;
            this.dgdProducts.AllowUserToDeleteRows = false;
            this.dgdProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgdProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdProducts.Location = new System.Drawing.Point(307, 12);
            this.dgdProducts.MultiSelect = false;
            this.dgdProducts.Name = "dgdProducts";
            this.dgdProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdProducts.Size = new System.Drawing.Size(915, 331);
            this.dgdProducts.TabIndex = 1;
            // 
            // cmdAddOrder
            // 
            this.cmdAddOrder.Location = new System.Drawing.Point(1147, 349);
            this.cmdAddOrder.Name = "cmdAddOrder";
            this.cmdAddOrder.Size = new System.Drawing.Size(75, 23);
            this.cmdAddOrder.TabIndex = 2;
            this.cmdAddOrder.Text = "Add Order";
            this.cmdAddOrder.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(1066, 349);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel Order";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(12, 354);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(61, 13);
            this.lblTotalCost.TabIndex = 4;
            this.lblTotalCost.Text = "Total Cost: ";
            // 
            // AddChangeOrder
            // 
            this.AcceptButton = this.cmdAddOrder;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(1234, 382);
            this.Controls.Add(this.lblTotalCost);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdAddOrder);
            this.Controls.Add(this.dgdProducts);
            this.Controls.Add(this.dgdSuppliers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddChangeOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add or Change Order";
            ((System.ComponentModel.ISupportInitialize)(this.dgdSuppliers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgdProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgdSuppliers;
        private System.Windows.Forms.DataGridView dgdProducts;
        private System.Windows.Forms.Button cmdAddOrder;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblTotalCost;
    }
}