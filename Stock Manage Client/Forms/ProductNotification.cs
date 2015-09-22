using System.Windows.Forms;
using Stock_Manage_Client.Classes.Networking.Packets;

namespace Stock_Manage_Client.Forms
{
    /// <summary>
    /// Shows the user a notification for a low product
    /// </summary>
    public partial class ProductNotification : Form
    {
        /// <summary>
        /// Stores the table data for the products
        /// </summary>
        private Table _productsTable;

        /// <summary>
        /// Initialises the form
        /// </summary>
        public ProductNotification(Table tmpTable)
        {
            _productsTable = tmpTable;
            InitializeComponent();
            dgdProducts.DataSource = _productsTable.TableData;

        }

        /// <summary>
        /// Remove the form to dismiss the notification
        /// </summary>
        private void cmdDismiss_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        private void cmdCreateOrder_Click(object sender, System.EventArgs e)
        {
            var addOrder = new AddChangeOrder((int)dgdProducts.SelectedRows[0].Cells[8].Value);
            addOrder.ShowDialog();
            dgdProducts.Rows.Remove(dgdProducts.SelectedRows[0]);
        }
    }
}
