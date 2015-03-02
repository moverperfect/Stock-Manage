using System;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.Networking;

namespace Stock_Manage_Client.Forms
{
    /// <summary>
    /// Simple form with one updown box to allow the change of quantity of a product
    /// </summary>
    public partial class ChangeQuantity : Form
    {
        /// <summary>
        /// Initialises the form with the product being changed and the current quantity
        /// </summary>
        /// <param name="productId">The product id of the product being changed</param>
        /// <param name="currentQuantity">The current quantity to display to the user</param>
        public ChangeQuantity(int productId, int currentQuantity)
        {
            InitializeComponent();
            ProductId = productId;
            updQuantity.Value = currentQuantity;
        }

        /// <summary>
        /// The product id of the product being changed
        /// </summary>
        private int ProductId { get; set; }

        /// <summary>
        /// Sends the update string to the server to update the quantity of the product
        /// </summary>
        private void cmdChangeQuantity_Click(object sender, EventArgs e)
        {
            PacketHandler.DataRecieved += cmdChangeQuantity_DataRecieved;
            Program.SendData("UPDATE tbl_products SET Quantity = '" + updQuantity.Value + "' WHERE PK_ProductId = '" +
                             ProductId + "';");
        }

        /// <summary>
        /// Closes the form when message is recieved back from the server
        /// </summary>
        /// <param name="packet">Message back from the server</param>
        private void cmdChangeQuantity_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= cmdChangeQuantity_DataRecieved;
            Invoke((MethodInvoker) Close);
        }
    }
}