using Stock_Manage_Client.Classes;
using System.Windows.Forms;

namespace Stock_Manage_Client.Forms
{
    public partial class Management : Form
    {
        public Management()
        {
            InitializeComponent();
        }

        private void Management_Load(object sender, System.EventArgs e)
        {

        }

        private void btn_newUser_Click(object sender, System.EventArgs e)
        {
            this.tc_MainControl.TabPages.Add(new AddNewUserTab());
        }

    }
}