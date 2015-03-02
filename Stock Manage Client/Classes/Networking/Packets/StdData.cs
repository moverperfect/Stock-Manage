using System;
using System.Text;

namespace Stock_Manage_Client.Classes.Networking.Packets
{
    /// <summary>
    /// A standard data packet structure that holds a string value
    /// </summary>
    public class StdData : PacketStructure
    {
        /// <summary>
        /// Initialise the standard data packet structure with a string message and a machine id and user id
        /// </summary>
        /// <param name="message">The string to be stored</param>
        /// <param name="machineId">Machine id of the machine that created the packet</param>
        /// <param name="userId">User id of the user who created the packet</param>
        public StdData(String message, ushort machineId, ushort userId)
            : base((ushort) (8 + Encoding.UTF8.GetByteCount(message)), machineId, userId)
        {
            // If it is a sql statement, express this inside the packet type
            switch (message.Split(char.Parse(" "))[0].ToLower())
            {
                case "select":
                    WriteUShort(2002, 2);
                    break;
                case "alter":
                    WriteUShort(2001, 2);
                    break;
                case "update":
                    WriteUShort(2001, 2);
                    break;
                case "insert":
                    WriteUShort(2001, 2);
                    break;
                case "delete":
                    WriteUShort(2001, 2);
                    break;
                default:
                    WriteUShort(2000, 2);
                    break;
            }
            Text = message;
        }

        /// <summary>
        /// Initialise the standard data packet structure with a pre made byte array
        /// </summary>
        /// <param name="packet"></param>
        public StdData(byte[] packet)
            : base(packet)
        {

        }

        /// <summary>
        /// Initialise the standard data packet structure with the packet type already known and insited upon
        /// </summary>
        /// <param name="message">The string message to be stored</param>
        /// <param name="machineId">The machine id of the machine that created the packet</param>
        /// <param name="userId">The user id of the user who created the packet</param>
        /// <param name="packetType">The type of the packet see Documentation files/packethandler.cs for details</param>
        public StdData(String message, ushort machineId, ushort userId, ushort packetType)
            : base((ushort) (8 + Encoding.UTF8.GetByteCount(message)), machineId, userId)
        {
            WriteUShort(packetType, 2);
            Text = message;
        }

        /// <summary>
        /// The text string that is stored in the packet
        /// </summary>
        public string Text
        {
            get { return ReadString(8, Data.Length - 8); }
            set { WriteString(value, 8); }
        }

        /// <summary>
        /// Writes a string text to the byte array
        /// </summary>
        /// <param name="value">The string value to be written</param>
        /// <param name="offset">The offset to write the data at in the byte array</param>
        private void WriteString(String value, int offset)
        {
            var tempBuffer = Encoding.UTF8.GetBytes(value);
            Array.Copy(tempBuffer, 0, Buffer, offset, value.Length);
        }

        /// <summary>
        /// Reads the string value from the byte array
        /// </summary>
        /// <param name="offset">Where to start reading from</param>
        /// <param name="count">How long to read for</param>
        /// <returns>The string value that is stored in the byte array</returns>
        private string ReadString(int offset, int count)
        {
            return Encoding.UTF8.GetString(Buffer, offset, count);
        }
    }
}