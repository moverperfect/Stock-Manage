using System;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using Stock_Manage_Client.Classes.Networking;
using Stock_Manage_Client.Classes.Networking.Packets;
using Stock_Manage_Client.Classes.TabPages;

namespace Stock_Manage_Client.Forms
{
    public partial class Workshop : Form
    {
        public Table DataGridTable;

        public Workshop()
        {
            InitializeComponent();
            Program.UserIdChanged += Program_UserIdChanged;
            RefreshUsers();
        }

        public void RefreshUsers()
        {
            PacketHandler.DataRecieved += RefreshUsers_DataRecieved;
            Program.SendData(
                "SELECT `PK_UserId` as 'User Id', `First_Name` as 'First Name', `Second_Name` as 'Second Name' FROM `tbl_users` ORDER BY FIELD(`System_Role`,'Workshop','Ordering','Management'), First_Name;");
        }

        private void RefreshUsers_DataRecieved(byte[] packet)
        {
            PacketHandler.DataRecieved -= RefreshUsers_DataRecieved;
            DataGridTable = new Table(packet);
            Invoke(new MethodInvoker(delegate { dgdUsers.DataSource = DataGridTable.TableData; }));
        }

        private void dgdUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgdUsers.SelectedRows;

            if (row.Count != 0)
            {
                var authenticate = new Authentication((int) row[0].Cells[0].Value);
                authenticate.ShowDialog();
            }
        }

        private void btn_CloseTab_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Remove(tc_MainControl.SelectedTab);
        }

        private void cmdManageProducts_Click(object sender, EventArgs e)
        {
            tc_MainControl.TabPages.Add(new WorkshopProductsTab());
        }

        private void cmdLogOut_Click(object sender, EventArgs e)
        {
            Program.UserId = "0";
            Program.OnUserIdChanged(this, EventArgs.Empty);
        }

        public void Program_UserIdChanged(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(delegate
            {
                if (Program.UserId == "0")
                {
                    cmdLogOut.Enabled = false;
                }
                else
                {
                    cmdLogOut.Enabled = true;
                }
            }));
        }
    }
}