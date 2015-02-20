namespace Stock_Manage_Client.Forms
{
    partial class InputNumberPad
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
            this.updInput = new System.Windows.Forms.NumericUpDown();
            this.cmdSeven = new System.Windows.Forms.Button();
            this.cmdEight = new System.Windows.Forms.Button();
            this.cmdNine = new System.Windows.Forms.Button();
            this.cmdSix = new System.Windows.Forms.Button();
            this.cmdFive = new System.Windows.Forms.Button();
            this.cmdFour = new System.Windows.Forms.Button();
            this.cmdThree = new System.Windows.Forms.Button();
            this.cmdTwo = new System.Windows.Forms.Button();
            this.cmdOne = new System.Windows.Forms.Button();
            this.cmdZero = new System.Windows.Forms.Button();
            this.cmdAccept = new System.Windows.Forms.Button();
            this.cmdClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.updInput)).BeginInit();
            this.SuspendLayout();
            // 
            // updInput
            // 
            this.updInput.Location = new System.Drawing.Point(12, 12);
            this.updInput.Name = "updInput";
            this.updInput.Size = new System.Drawing.Size(261, 20);
            this.updInput.TabIndex = 0;
            this.updInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmdSeven
            // 
            this.cmdSeven.Location = new System.Drawing.Point(12, 38);
            this.cmdSeven.Name = "cmdSeven";
            this.cmdSeven.Size = new System.Drawing.Size(83, 41);
            this.cmdSeven.TabIndex = 1;
            this.cmdSeven.Text = "7";
            this.cmdSeven.UseVisualStyleBackColor = true;
            this.cmdSeven.Click += new System.EventHandler(this.cmdNumber_Click);
            // 
            // cmdEight
            // 
            this.cmdEight.Location = new System.Drawing.Point(101, 38);
            this.cmdEight.Name = "cmdEight";
            this.cmdEight.Size = new System.Drawing.Size(83, 41);
            this.cmdEight.TabIndex = 2;
            this.cmdEight.Text = "8";
            this.cmdEight.UseVisualStyleBackColor = true;
            this.cmdEight.Click += new System.EventHandler(this.cmdNumber_Click);
            // 
            // cmdNine
            // 
            this.cmdNine.Location = new System.Drawing.Point(190, 38);
            this.cmdNine.Name = "cmdNine";
            this.cmdNine.Size = new System.Drawing.Size(83, 41);
            this.cmdNine.TabIndex = 3;
            this.cmdNine.Text = "9";
            this.cmdNine.UseVisualStyleBackColor = true;
            this.cmdNine.Click += new System.EventHandler(this.cmdNumber_Click);
            // 
            // cmdSix
            // 
            this.cmdSix.Location = new System.Drawing.Point(190, 85);
            this.cmdSix.Name = "cmdSix";
            this.cmdSix.Size = new System.Drawing.Size(83, 41);
            this.cmdSix.TabIndex = 4;
            this.cmdSix.Text = "6";
            this.cmdSix.UseVisualStyleBackColor = true;
            this.cmdSix.Click += new System.EventHandler(this.cmdNumber_Click);
            // 
            // cmdFive
            // 
            this.cmdFive.Location = new System.Drawing.Point(101, 85);
            this.cmdFive.Name = "cmdFive";
            this.cmdFive.Size = new System.Drawing.Size(83, 41);
            this.cmdFive.TabIndex = 5;
            this.cmdFive.Text = "5";
            this.cmdFive.UseVisualStyleBackColor = true;
            this.cmdFive.Click += new System.EventHandler(this.cmdNumber_Click);
            // 
            // cmdFour
            // 
            this.cmdFour.Location = new System.Drawing.Point(12, 85);
            this.cmdFour.Name = "cmdFour";
            this.cmdFour.Size = new System.Drawing.Size(83, 41);
            this.cmdFour.TabIndex = 6;
            this.cmdFour.Text = "4";
            this.cmdFour.UseVisualStyleBackColor = true;
            this.cmdFour.Click += new System.EventHandler(this.cmdNumber_Click);
            // 
            // cmdThree
            // 
            this.cmdThree.Location = new System.Drawing.Point(190, 132);
            this.cmdThree.Name = "cmdThree";
            this.cmdThree.Size = new System.Drawing.Size(83, 41);
            this.cmdThree.TabIndex = 7;
            this.cmdThree.Text = "3";
            this.cmdThree.UseVisualStyleBackColor = true;
            this.cmdThree.Click += new System.EventHandler(this.cmdNumber_Click);
            // 
            // cmdTwo
            // 
            this.cmdTwo.Location = new System.Drawing.Point(101, 132);
            this.cmdTwo.Name = "cmdTwo";
            this.cmdTwo.Size = new System.Drawing.Size(83, 41);
            this.cmdTwo.TabIndex = 8;
            this.cmdTwo.Text = "2";
            this.cmdTwo.UseVisualStyleBackColor = true;
            this.cmdTwo.Click += new System.EventHandler(this.cmdNumber_Click);
            // 
            // cmdOne
            // 
            this.cmdOne.Location = new System.Drawing.Point(12, 132);
            this.cmdOne.Name = "cmdOne";
            this.cmdOne.Size = new System.Drawing.Size(83, 41);
            this.cmdOne.TabIndex = 9;
            this.cmdOne.Text = "1";
            this.cmdOne.UseVisualStyleBackColor = true;
            this.cmdOne.Click += new System.EventHandler(this.cmdNumber_Click);
            // 
            // cmdZero
            // 
            this.cmdZero.Location = new System.Drawing.Point(12, 179);
            this.cmdZero.Name = "cmdZero";
            this.cmdZero.Size = new System.Drawing.Size(83, 41);
            this.cmdZero.TabIndex = 10;
            this.cmdZero.Text = "0";
            this.cmdZero.UseVisualStyleBackColor = true;
            this.cmdZero.Click += new System.EventHandler(this.cmdNumber_Click);
            // 
            // cmdAccept
            // 
            this.cmdAccept.Location = new System.Drawing.Point(189, 179);
            this.cmdAccept.Name = "cmdAccept";
            this.cmdAccept.Size = new System.Drawing.Size(83, 41);
            this.cmdAccept.TabIndex = 11;
            this.cmdAccept.Text = "Accept";
            this.cmdAccept.UseVisualStyleBackColor = true;
            this.cmdAccept.Click += new System.EventHandler(this.cmdAccept_Click);
            // 
            // cmdClear
            // 
            this.cmdClear.Location = new System.Drawing.Point(101, 179);
            this.cmdClear.Name = "cmdClear";
            this.cmdClear.Size = new System.Drawing.Size(83, 41);
            this.cmdClear.TabIndex = 12;
            this.cmdClear.Text = "Clear";
            this.cmdClear.UseVisualStyleBackColor = true;
            this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
            // 
            // InputNumberPad
            // 
            this.AcceptButton = this.cmdAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 230);
            this.Controls.Add(this.cmdClear);
            this.Controls.Add(this.cmdAccept);
            this.Controls.Add(this.cmdZero);
            this.Controls.Add(this.cmdOne);
            this.Controls.Add(this.cmdTwo);
            this.Controls.Add(this.cmdThree);
            this.Controls.Add(this.cmdFour);
            this.Controls.Add(this.cmdFive);
            this.Controls.Add(this.cmdSix);
            this.Controls.Add(this.cmdNine);
            this.Controls.Add(this.cmdEight);
            this.Controls.Add(this.cmdSeven);
            this.Controls.Add(this.updInput);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputNumberPad";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InputNumberPad";
            ((System.ComponentModel.ISupportInitialize)(this.updInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown updInput;
        private System.Windows.Forms.Button cmdSeven;
        private System.Windows.Forms.Button cmdEight;
        private System.Windows.Forms.Button cmdNine;
        private System.Windows.Forms.Button cmdSix;
        private System.Windows.Forms.Button cmdFive;
        private System.Windows.Forms.Button cmdFour;
        private System.Windows.Forms.Button cmdThree;
        private System.Windows.Forms.Button cmdTwo;
        private System.Windows.Forms.Button cmdOne;
        private System.Windows.Forms.Button cmdZero;
        private System.Windows.Forms.Button cmdAccept;
        private System.Windows.Forms.Button cmdClear;
    }
}