using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stock_Manage_Client.Classes;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;

namespace Stock_Manage_Client.Forms
{
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
        }

        private void txt_UserId_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_UserId.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txt_UserId.Text = txt_UserId.Text.Remove(txt_UserId.Text.Length - 1);
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Program.TempReturnTable = null;

            HashPassword(txt_Psswrd.Text, null, MD5.Create());

            Program.SendData("SELECT Salt,Password_Hash FROM tbl_Users WHERE PK_UserId=" + this.txt_UserId.Text + ";");

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < 3000)
            {
                try
                {
                    if (Program.TempReturnTable.TableData.Rows.Count > 0)
                    {
                        var password = HashPassword(txt_Psswrd.Text, Program.TempReturnTable.TableData.Rows[0]["Salt"].ToString(), MD5.Create());
                        if (password == Program.TempReturnTable.TableData.Rows[0]["Password_Hash"].ToString())
                        {
                            Program.UserId = txt_UserId.Text;
                            this.Close();
                            return;
                        }
                    }
                }
                catch (Exception ex) { }
            }

            if (Program.TempReturnTable != null)
            {
                MessageBox.Show("Login failed, username or password is incorrect");
            }
            else
            {
                MessageBox.Show("Timeout to the server, please try again");
            }
        }

        private static string GenerateSaltValue()
        {
            UnicodeEncoding utf16 = new UnicodeEncoding();

            if (utf16 != null)
            {
                // Create a random number object seeded from the value
                // of the last random seed value. This is done
                // interlocked because it is a static value and we want
                // it to roll forward safely.

                Random random = new Random(unchecked((int)DateTime.Now.Ticks));

                if (random != null)
                {
                    // Create an array of random values.

                    byte[] saltValue = new byte[8];

                    random.NextBytes(saltValue);

                    // Convert the salt value to a string. Note that the resulting string
                    // will still be an array of binary values and not a printable string. 
                    // Also it does not convert each byte to a double byte.

                    string saltValueString = utf16.GetString(saltValue);

                    // Return the salt value as a string.

                    return saltValueString;
                }
            }

            return null;
        }

        private static string HashPassword(string clearData, string saltValue, HashAlgorithm hash)
        {
            UnicodeEncoding encoding = new UnicodeEncoding();

            if (clearData != null && hash != null && encoding != null)
            {
                // If the salt string is null or the length is invalid then
                // create a new valid salt value.

                if (saltValue == null)
                {
                    // Generate a salt string.
                    saltValue = GenerateSaltValue();
                    Program.SendData("UPDATE tbl_users SET Salt='" + saltValue + "' WHERE PK_UserId='1';");
                  }

                // Convert the salt string and the password string to a single
                // array of bytes. Note that the password string is Unicode and
                // therefore may or may not have a zero in every other byte.

                byte[] binarySaltValue = new byte[saltValue.Length * sizeof(char)];
                System.Buffer.BlockCopy(saltValue.ToCharArray(), 0, binarySaltValue, 0, binarySaltValue.Length);

                //byte[] binarySaltValue = new byte[4];



                //binarySaltValue[0] = byte.Parse(saltValue.Substring(0, 2));
                //binarySaltValue[1] = byte.Parse(saltValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                //binarySaltValue[2] = byte.Parse(saltValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                //binarySaltValue[3] = byte.Parse(saltValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);

                byte[] valueToHash = new byte[8 + encoding.GetByteCount(clearData)];
                byte[] binaryPassword = encoding.GetBytes(clearData);

                // Copy the salt value and the password to the hash buffer.

                binarySaltValue.CopyTo(valueToHash, 0);
                binaryPassword.CopyTo(valueToHash, 4);

                byte[] hashValue = hash.ComputeHash(valueToHash);

                // The hashed password is the salt plus the hash value (as a string).

                string hashedPassword = "";

                foreach (byte hexdigit in hashValue)
                {
                    hashedPassword += hexdigit.ToString("X2", CultureInfo.InvariantCulture.NumberFormat);
                }

                // Return the hashed password as a string.

                return hashedPassword;
            }

            return null;
        }
    }
}
