namespace Stock_Manage_Client.Forms
{
    partial class ChangeQuantity
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
            this.lblQuantity = new System.Windows.Forms.Label();
            this.cmdChangeQuantity = new System.Windows.Forms.Button();
            this.updQuantity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.updQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(13, 9);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(71, 13);
            this.lblQuantity.TabIndex = 1;
            this.lblQuantity.Text = "New Quantity";
            // 
            // cmdChangeQuantity
            // 
            this.cmdChangeQuantity.Location = new System.Drawing.Point(16, 32);
            this.cmdChangeQuantity.Name = "cmdChangeQuantity";
            this.cmdChangeQuantity.Size = new System.Drawing.Size(134, 23);
            this.cmdChangeQuantity.TabIndex = 3;
            this.cmdChangeQuantity.Text = "Change Quantity";
            this.cmdChangeQuantity.UseVisualStyleBackColor = true;
            this.cmdChangeQuantity.Click += new System.EventHandler(this.cmdChangeQuantity_Click);
            // 
            // updQuantity
            // 
            this.updQuantity.Location = new System.Drawing.Point(90, 7);
            this.updQuantity.Name = "updQuantity";
            this.updQuantity.Size = new System.Drawing.Size(60, 20);
            this.updQuantity.TabIndex = 4;
            this.updQuantity.ThousandsSeparator = true;
            // 
            // ChangeQuantity
            // 
            this.AcceptButton = this.cmdChangeQuantity;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(165, 60);
            this.Controls.Add(this.updQuantity);
            this.Controls.Add(this.cmdChangeQuantity);
            this.Controls.Add(this.lblQuantity);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeQuantity";
            this.Text = "Change Quantity";
            ((System.ComponentModel.ISupportInitialize)(this.updQuantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button cmdChangeQuantity;
        private System.Windows.Forms.NumericUpDown updQuantity;

    }
}