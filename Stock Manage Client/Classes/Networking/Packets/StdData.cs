using System;
using System.Text;

namespace Stock_Manage_Client.Classes.Networking.Packets
{
    public class StdData : PacketStructure
    {
        public StdData(String message, ushort machineId, ushort userId)
            : base((ushort) (8 + Encoding.UTF8.GetByteCount(message)), machineId, userId)
        {
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
                default:
                    WriteUShort(2000, 2);
                    break;
            }
            Text = message;
        }

        public StdData(byte[] packet)
            : base(packet)
        {
        }

        public string Text
        {
            get { return ReadString(8, Data.Length - 8); }
            set { WriteString(value, 8); }
        }

        private void WriteString(String value, int offset)
        {
            var tempBuffer = Encoding.UTF8.GetBytes(value);
            Array.Copy(tempBuffer, 0, Buffer, offset, value.Length);
        }

        private string ReadString(int offset, int count)
        {
            return Encoding.UTF8.GetString(Buffer, offset, count);
        }
    }
}