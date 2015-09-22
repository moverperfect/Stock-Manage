using System.Drawing;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Client.Forms
{
    /// <summary>
    /// Shows the user a notification for an order that needs to be verified
    /// </summary>
    public partial class OrderNotification : Form
    {
        /// <summary>
        /// Stores the table data for the orders
        /// </summary>
        private Table _ordersTable;

        /// <summary>
        /// Initialies the form with the table data
        /// </summary>
        public OrderNotification(Table tmpTable)
        {
            _ordersTable = tmpTable;
            InitializeComponent();
            dgdOrders.DataSource = _ordersTable.TableData;
        }

        /// <summary>
        /// 
        /// </summary>
        private void cmdOrderDetails_Click(object sender, System.EventArgs e)
        {
            var res = Screen.GetWorkingArea(new Point());
            this.MaximumSize = new Size(1200, res.Height - 200);
            this.Size = new Size(1200, res.Height - 200);
        }
    }
}
