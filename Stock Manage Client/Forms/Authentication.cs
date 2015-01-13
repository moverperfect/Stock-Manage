using System;
using System.Text;
using System.Text.RegularExpressions;
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
            if (Regex.IsMatch(txt_UserId.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                txt_UserId.Text = txt_UserId.Text.Remove(txt_UserId.Text.Length - 1);
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            Program.TempReturnTable = null;

            Program.SendData("SELECT Salt,Password_Hash FROM tbl_Users WHERE PK_UserId=" + txt_UserId.Text + ";");

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
                            Close();
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
            var utf16 = new UnicodeEncoding();

            
                // Create a random number object seeded from the value
                // of the last random seed value. This is done
                // interlocked because it is a static value and we want
                // it to roll forward safely.

                var random = new Random(unchecked((int)DateTime.Now.Ticks));

                
                    // Create an array of random values.

                    var saltValue = new byte[8];

                    random.NextBytes(saltValue);

                    // Convert the salt value to a string. Note that the resulting string
                    // will still be an array of binary values and not a printable string. 
                    // Also it does not convert each byte to a double byte.

                    var saltValueString = utf16.GetString(saltValue);

                    // Return the salt value as a string.

                    return saltValueString;
        }

        private static string HashPassword(string clearData, string saltValue, HashAlgorithm hash)
        {
            var encoding = new UnicodeEncoding();

            if (clearData != null && hash != null)
            {
                // If the salt string is null or the length is invalid then
                // create a new valid salt value.

                if (saltValue == null)
                {
                    // Generate a salt string.
                    saltValue = GenerateSaltValue();
                  }

                // Convert the salt string and the password string to a single
                // array of bytes. Note that the password string is Unicode and
                // therefore may or may not have a zero in every other byte.

                var binarySaltValue = new byte[saltValue.Length * sizeof(char)];
                Buffer.BlockCopy(saltValue.ToCharArray(), 0, binarySaltValue, 0, binarySaltValue.Length);

                //byte[] binarySaltValue = new byte[4];



                //binarySaltValue[0] = byte.Parse(saltValue.Substring(0, 2));
                //binarySaltValue[1] = byte.Parse(saltValue.Substring(2, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                //binarySaltValue[2] = byte.Parse(saltValue.Substring(4, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);
                //binarySaltValue[3] = byte.Parse(saltValue.Substring(6, 2), System.Globalization.NumberStyles.HexNumber, CultureInfo.InvariantCulture.NumberFormat);

                var valueToHash = new byte[8 + encoding.GetByteCount(clearData)];
                var binaryPassword = encoding.GetBytes(clearData);

                // Copy the salt value and the password to the hash buffer.

                binarySaltValue.CopyTo(valueToHash, 0);
                binaryPassword.CopyTo(valueToHash, 4);

                var hashValue = hash.ComputeHash(valueToHash);

                // The hashed password is the salt plus the hash value (as a string).

                var hashedPassword = "";

                foreach (var hexdigit in hashValue)
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
