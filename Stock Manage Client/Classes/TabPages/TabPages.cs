using System.Drawing;
using System.Windows.Forms;

namespace Stock_Manage_Client.Classes.TabPages
{
    class AddNewUserTab : TabPage
    {
        public AddNewUserTab()
        {
            var btnExitTab = new Button
            {
                Location = new Point(114, 95),
                Name = "btn_ExitTab",
                Size = new Size(75, 23),
                TabIndex = 7,
                Text = "Exit Tab",
                UseVisualStyleBackColor = true
            };

            var btnAddUser = new Button
            {
                Location = new Point(9, 95),
                Name = "btn_AddUser",
                Size = new Size(75, 23),
                TabIndex = 6,
                Text = "Add User",
                UseVisualStyleBackColor = true
            };

            var textBox3 = new TextBox
            {
                Location = new Point(89, 63),
                Name = "textBox3",
                PasswordChar = '*',
                Size = new Size(100, 20),
                TabIndex = 5
            };

            var textBox2 = new TextBox
            {
                Location = new Point(89, 37),
                Name = "textBox2",
                Size = new Size(100, 20),
                TabIndex = 4
            };

            var textBox1 = new TextBox
            {
                Location = new Point(89, 11),
                Name = "textBox1",
                Size = new Size(100, 20),
                TabIndex = 3
            };

            var label3 = new Label
            {
                AutoSize = true,
                Location = new Point(6, 66),
                Name = "label3",
                Size = new Size(53, 13),
                TabIndex = 2,
                Text = "Password"
            };

            var label2 = new Label
            {
                AutoSize = true,
                Location = new Point(6, 40),
                Name = "label2",
                Size = new Size(75, 13),
                TabIndex = 1,
                Text = "Second Name"
            };

            var label1 = new Label
            {
                AutoSize = true,
                Location = new Point(6, 11),
                Name = "label1",
                Size = new Size(57, 13),
                TabIndex = 0,
                Text = "First Name"
            };

            Controls.Add(btnExitTab);
            Controls.Add(btnAddUser);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Location = new Point(4, 22);
            Name = "NewUserTab";
            Padding = new Padding(3);
            TabIndex = 0;
            Text = "Add New User";
            UseVisualStyleBackColor = true;
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }
    }
}
