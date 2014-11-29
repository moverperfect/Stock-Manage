using System;
using System.Text;

namespace Stock_Manage.Networking.Packets
{
    /// <summary>
    /// Standard Packet structure
    /// 0-1 - Packet Length
    /// 2-3 - Packet Type
    /// 4-5 - Machine ID // Currently not in use
    /// 6-7 - User ID // Currently not in use
    /// </summary>
    public abstract class PacketStructure
    {
        public byte[] _buffer;

        public PacketStructure(ushort length, String message)
        {
            _buffer = new byte[length];
            WriteUShort(length, 0);
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

            }
        }

        public PacketStructure(byte[] packet)
        {
            _buffer = packet;
        }

        public PacketStructure()
        {
            
        }

        public void WriteUShort(ushort value, int offset)
        {
            byte[] tempBuffer = new byte[2];
            tempBuffer = BitConverter.GetBytes(value);
            Array.Copy(tempBuffer, 0, _buffer, offset, 2);
        }

        public ushort ReadUShort(int offset)
        {
            return BitConverter.ToUInt16(_buffer, offset);
        }

        public void WriteString(String Value, int offset)
        {
            byte[] tempBuffer = new byte[Value.Length];
            tempBuffer = Encoding.UTF8.GetBytes(Value);
            Array.Copy(tempBuffer, 0, _buffer, offset, Value.Length);
        }

        public string ReadString(int offset, int count)
        {
            return Encoding.UTF8.GetString(_buffer, offset, count);
        }

        public byte[] Data { get { return _buffer; } }
    }
}
