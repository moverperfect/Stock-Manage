using System;

namespace Stock_Manage_Server.Networking.Packets
{
    /// <summary>
    ///     Standard Packet structure
    ///     0-1 - Packet Length
    ///     2-3 - Packet Type
    ///     4-5 - Machine ID // Currently not in use
    ///     6-7 - User ID // Currently not in use
    /// </summary>
    public abstract class PacketStructure
    {
        public byte[] Buffer;

        protected PacketStructure(ushort length, ushort machineId, ushort userId)
        {
            Buffer = new byte[length];
            WriteUShort(length, 0);
            WriteUShort(machineId, 4);
            WriteUShort(userId, 6);
        }

        protected PacketStructure(byte[] packet)
        {
            Buffer = packet;
        }

        protected PacketStructure()
        {

        }

        public byte[] Data
        {
            get { return Buffer; }
        }

        public ushort MachineId
        {
            get { return ReadUShort(4); }
        }

        public ushort UserId
        {
            get { return ReadUShort(6); }
        }

        public void WriteUShort(ushort value, int offset)
        {
            var tempBuffer = BitConverter.GetBytes(value);
            Array.Copy(tempBuffer, 0, Buffer, offset, 2);
        }

        public ushort ReadUShort(int offset)
        {
            return BitConverter.ToUInt16(Buffer, offset);
        }
    }
}