using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Stock_Manage_Client.Classes
{
    internal static class Utilities
    {
        public static string GenerateSaltValue()
        {
            // TODO Clean up this code a lot
            //var utf16 = new UTF8Encoding();


            // Create a random number object seeded from the value
            // of the last random seed value. This is done
            // interlocked because it is a static value and we want
            // it to roll forward safely.

            var random = new Random(unchecked((int) DateTime.Now.Ticks));


            // Create an array of random values.

            var saltValue = new byte[4];

            random.NextBytes(saltValue);

            // Convert the salt value to a string. Note that the resulting string
            // will still be an array of binary values and not a printable string. 
            // Also it does not convert each byte to a double byte.

            var saltValueString = Convert.ToBase64String(saltValue);

            // Return the salt value as a string.

            return saltValueString;
        }

        public static string HashPassword(string clearData, string saltValue, HashAlgorithm hash)
        {
            var encoding = new UTF8Encoding();

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

                var binarySaltValue = new byte[saltValue.Length];
                Buffer.BlockCopy(saltValue.ToCharArray(), 0, binarySaltValue, 0, binarySaltValue.Length);

                var valueToHash = new byte[4 + encoding.GetByteCount(clearData)];
                var binaryPassword = encoding.GetBytes(clearData);

                // Copy the salt value and the password to the hash buffer.

                binarySaltValue.CopyTo(valueToHash, 0);
                binaryPassword.CopyTo(valueToHash, 2);

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