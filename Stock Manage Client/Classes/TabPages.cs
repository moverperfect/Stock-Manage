using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_Manage_Client.Classes
{
    class AddNewUserTab : TabPage
    {
        public AddNewUserTab()
        {
            Button btn_ExitTab = new Button();
            btn_ExitTab.Location = new System.Drawing.Point(114, 95);
            btn_ExitTab.Name = "btn_ExitTab";
            btn_ExitTab.Size = new System.Drawing.Size(75, 23);
            btn_ExitTab.TabIndex = 7;
            btn_ExitTab.Text = "Exit Tab";
            btn_ExitTab.UseVisualStyleBackColor = true;

            Button btn_AddUser = new Button();
            btn_AddUser.Location = new System.Drawing.Point(9, 95);
            btn_AddUser.Name = "btn_AddUser";
            btn_AddUser.Size = new System.Drawing.Size(75, 23);
            btn_AddUser.TabIndex = 6;
            btn_AddUser.Text = "Add User";
            btn_AddUser.UseVisualStyleBackColor = true;

            TextBox textBox3 = new TextBox();
            textBox3.Location = new System.Drawing.Point(89, 63);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new System.Drawing.Size(100, 20);
            textBox3.TabIndex = 5;

            TextBox textBox2 = new TextBox();
            textBox2.Location = new System.Drawing.Point(89, 37);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(100, 20);
            textBox2.TabIndex = 4;

            TextBox textBox1 = new TextBox();
            textBox1.Location = new System.Drawing.Point(89, 11);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(100, 20);
            textBox1.TabIndex = 3;

            Label label3 = new Label();
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 66);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(53, 13);
            label3.TabIndex = 2;
            label3.Text = "Password";

            Label label2 = new Label();
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 40);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 13);
            label2.TabIndex = 1;
            label2.Text = "Second Name";

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 11);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(57, 13);
            label1.TabIndex = 0;
            label1.Text = "First Name";

            this.Controls.Add(btn_ExitTab);
            this.Controls.Add(btn_AddUser);
            this.Controls.Add(textBox3);
            this.Controls.Add(textBox2);
            this.Controls.Add(textBox1);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Location = new System.Drawing.Point(4, 22);
            this.Name = "tabPage1";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(1071, 816);
            this.TabIndex = 0;
            this.Text = "tabPage1";
            this.UseVisualStyleBackColor = true;
        }
    }
}
