using System;

namespace Stock_Manage.Networking.Packets
{
    public class StdData : PacketStructure
    {

        private string _message;

        public StdData(String message)
            : base((ushort)(4 + message.Length), message)
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
                default:
                    WriteUShort(2000,2);
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
            get { return ReadString(4, Data.Length - 4); }
            set
            {
                _message = value;
                WriteString(value, 4);
            }
        }

    }
}
