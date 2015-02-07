using System;
using System.Windows.Forms;
using Stock_Manage_Client.Classes.TabPages;

namespace Stock_Manage_Client.Forms
{
    public partial class Ordering : Form
    {
        public Ordering()
        {
            InitializeComponent();
        }

        private void btn_CloseTab_Click(object sender, System.EventArgs e)
        {
            tc_MainControl.TabPages.Remove(tc_MainControl.SelectedTab);
        }

        private void cmdManageProducts_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new ManageProductsTab());
        }

        private void cmdManageSuppliers_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new ManageSuppliersTab());
        }

        private void cmdManageOrders_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new ManageOrdersTab());
        }
    }
}