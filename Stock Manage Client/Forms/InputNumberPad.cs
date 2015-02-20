using System;
using System.Windows.Forms;

namespace Stock_Manage_Client.Forms
{
    /// <summary>
    /// Allows the user to enter numbers into the program via a virtual number pad
    /// </summary>
    public partial class InputNumberPad : Form
    {
        /// <summary>
        /// The quantity of the number pad, used when the form is closed
        /// </summary>
        public int Quantity;

        /// <summary>
        /// Initialise the number pad form
        /// </summary>
        public InputNumberPad()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Happens when any number button gets clicked, adds the number as the unit of the displayed quantity
        /// </summary>
        /// <param name="sender">The button that called the function</param>
        /// <param name="e">Unused</param>
        private void cmdNumber_Click(object sender, EventArgs e)
        {
            // Declare the button that called the function
            var btn = sender as Button;
            // Set the display box equal to 10*the current quantity add the number on the button that was clicked
            if (btn != null)
            {
                updInput.Text = ((int.Parse(updInput.Text)*10) + int.Parse(btn.Text)).ToString();
            }
        }

        /// <summary>
        /// Happens when the clear button is clicked, clears the display box to 0
        /// </summary>
        private void cmdClear_Click(object sender, EventArgs e)
        {
            updInput.Text = "0";
        }

        /// <summary>
        /// Set the quantity varible to the number that the user entered and is on the display box and closes the form
        /// </summary>
        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Quantity = int.Parse(updInput.Text);
            Close();
        }
    }
}