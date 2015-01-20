using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Manage_Client.Forms
{
    public partial class ChangeQuantity : Form
    {
        public ChangeQuantity(int productId, int currentQuantity)
        {
            InitializeComponent();
            ProductId = productId;
            updQuantity.Value = currentQuantity;
        }

        private int ProductId { get; set; }

        private void cmdChangeQuantity_Click(object sender, EventArgs e)
        {
            PacketHandler.DataRecieved += cmdChangeQuantity_DataRecieved;
            Program.SendData("UPDATE tbl_products SET Quantity = '" + updQuantity.Value + "' WHERE PK_ProductId = '" + ProductId + "';");
        }

        private void cmdChangeQuantity_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= cmdChangeQuantity_DataRecieved;
            Invoke((MethodInvoker)Close);
        }
    }
}
