namespace Stock_Manage_Client.Forms
{
    partial class AddChangeProduct
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.txtUnitsInCase = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.lblUnitsInCase = new System.Windows.Forms.Label();
            this.lblCriticalLevel = new System.Windows.Forms.Label();
            this.lblNominalLevel = new System.Windows.Forms.Label();
            this.txtCriticalLevel = new System.Windows.Forms.TextBox();
            this.txtNominalLevel = new System.Windows.Forms.TextBox();
            this.dgdSuppliers = new System.Windows.Forms.DataGridView();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdAddProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgdSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(104, 32);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(100, 20);
            this.txtBarcode.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(104, 58);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(100, 20);
            this.txtDescription.TabIndex = 2;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(104, 84);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(100, 20);
            this.txtLocation.TabIndex = 3;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(104, 110);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 4;
            this.txtQuantity.TextChanged += new System.EventHandler(this.ValidateText);
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Location = new System.Drawing.Point(104, 136);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(100, 20);
            this.txtPurchasePrice.TabIndex = 5;
            // 
            // txtUnitsInCase
            // 
            this.txtUnitsInCase.Location = new System.Drawing.Point(104, 162);
            this.txtUnitsInCase.Name = "txtUnitsInCase";
            this.txtUnitsInCase.Size = new System.Drawing.Size(100, 20);
            this.txtUnitsInCase.TabIndex = 6;
            this.txtUnitsInCase.TextChanged += new System.EventHandler(this.ValidateText);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name";
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(9, 35);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(47, 13);
            this.lblBarcode.TabIndex = 8;
            this.lblBarcode.Text = "Barcode";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(9, 61);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 9;
            this.lblDescription.Text = "Description";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(9, 87);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(48, 13);
            this.lblLocation.TabIndex = 10;
            this.lblLocation.Text = "Location";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(9, 113);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 11;
            this.lblQuantity.Text = "Quantity";
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new System.Drawing.Point(9, 139);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(79, 13);
            this.lblPurchasePrice.TabIndex = 12;
            this.lblPurchasePrice.Text = "Purchase Price";
            // 
            // lblUnitsInCase
            // 
            this.lblUnitsInCase.AutoSize = true;
            this.lblUnitsInCase.Location = new System.Drawing.Point(9, 165);
            this.lblUnitsInCase.Name = "lblUnitsInCase";
            this.lblUnitsInCase.Size = new System.Drawing.Size(69, 13);
            this.lblUnitsInCase.TabIndex = 13;
            this.lblUnitsInCase.Text = "Units in Case";
            // 
            // lblCriticalLevel
            // 
            this.lblCriticalLevel.AutoSize = true;
            this.lblCriticalLevel.Location = new System.Drawing.Point(9, 191);
            this.lblCriticalLevel.Name = "lblCriticalLevel";
            this.lblCriticalLevel.Size = new System.Drawing.Size(69, 13);
            this.lblCriticalLevel.TabIndex = 14;
            this.lblCriticalLevel.Text = "Ciritical Level";
            // 
            // lblNominalLevel
            // 
            this.lblNominalLevel.AutoSize = true;
            this.lblNominalLevel.Location = new System.Drawing.Point(9, 217);
            this.lblNominalLevel.Name = "lblNominalLevel";
            this.lblNominalLevel.Size = new System.Drawing.Size(74, 13);
            this.lblNominalLevel.TabIndex = 15;
            this.lblNominalLevel.Text = "Nominal Level";
            // 
            // txtCriticalLevel
            // 
            this.txtCriticalLevel.Location = new System.Drawing.Point(104, 188);
            this.txtCriticalLevel.Name = "txtCriticalLevel";
            this.txtCriticalLevel.Size = new System.Drawing.Size(100, 20);
            this.txtCriticalLevel.TabIndex = 16;
            this.txtCriticalLevel.TextChanged += new System.EventHandler(this.ValidateText);
            // 
            // txtNominalLevel
            // 
            this.txtNominalLevel.Location = new System.Drawing.Point(104, 214);
            this.txtNominalLevel.Name = "txtNominalLevel";
            this.txtNominalLevel.Size = new System.Drawing.Size(100, 20);
            this.txtNominalLevel.TabIndex = 17;
            this.txtNominalLevel.TextChanged += new System.EventHandler(this.ValidateText);
            // 
            // dgdSuppliers
            // 
            this.dgdSuppliers.AllowUserToAddRows = false;
            this.dgdSuppliers.AllowUserToDeleteRows = false;
            this.dgdSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdSuppliers.Location = new System.Drawing.Point(210, 6);
            this.dgdSuppliers.MultiSelect = false;
            this.dgdSuppliers.Name = "dgdSuppliers";
            this.dgdSuppliers.ReadOnly = true;
            this.dgdSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgdSuppliers.Size = new System.Drawing.Size(271, 257);
            this.dgdSuppliers.TabIndex = 18;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(104, 240);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(100, 23);
            this.cmdCancel.TabIndex = 19;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAddProduct
            // 
            this.cmdAddProduct.Location = new System.Drawing.Point(12, 240);
            this.cmdAddProduct.Name = "cmdAddProduct";
            this.cmdAddProduct.Size = new System.Drawing.Size(86, 23);
            this.cmdAddProduct.TabIndex = 20;
            this.cmdAddProduct.Text = "Add Product";
            this.cmdAddProduct.UseVisualStyleBackColor = true;
            this.cmdAddProduct.Click += new System.EventHandler(this.cmdAddProduct_Click);
            // 
            // AddChangeProduct
            // 
            this.AcceptButton = this.cmdAddProduct;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(488, 270);
            this.Controls.Add(this.cmdAddProduct);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.dgdSuppliers);
            this.Controls.Add(this.txtNominalLevel);
            this.Controls.Add(this.txtCriticalLevel);
            this.Controls.Add(this.lblNominalLevel);
            this.Controls.Add(this.lblCriticalLevel);
            this.Controls.Add(this.lblUnitsInCase);
            this.Controls.Add(this.lblPurchasePrice);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtUnitsInCase);
            this.Controls.Add(this.txtPurchasePrice);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddChangeProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add or Change Product";
            ((System.ComponentModel.ISupportInitialize)(this.dgdSuppliers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.TextBox txtUnitsInCase;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.Label lblUnitsInCase;
        private System.Windows.Forms.Label lblCriticalLevel;
        private System.Windows.Forms.Label lblNominalLevel;
        private System.Windows.Forms.TextBox txtCriticalLevel;
        private System.Windows.Forms.TextBox txtNominalLevel;
        private System.Windows.Forms.DataGridView dgdSuppliers;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAddProduct;
    }
}