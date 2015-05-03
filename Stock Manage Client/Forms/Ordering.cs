using System;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.TabPages;

namespace Stock_Manage_Client.Forms
{
    /// <summary>
    /// Main form for the ordering UI
    /// </summary>
    public partial class Ordering : Form
    {
        /// <summary>
        /// Initialises the form
        /// </summary>
        public Ordering()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes the currently selected tab
        /// </summary>
        private void btn_CloseTab_Click(object sender, EventArgs e)
        {
            TabManagement.RemoveTab(tc_MainControl, -1);
        }

        /// <summary>
        /// Adds a manage products tab to the tab control
        /// </summary>
        private void cmdManageProducts_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new ManageProductsTab());
        }

        /// <summary>
        /// Adds a manage suppliers tab to the tab control
        /// </summary>
        private void cmdManageSuppliers_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new ManageSuppliersTab());
        }

        /// <summary>
        /// Adds a Manage Orders tab to the tab control
        /// </summary>
        private void cmdManageOrders_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new ManageOrdersTab());
        }
    }
}