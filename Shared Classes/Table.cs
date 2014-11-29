using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Stock_Manage.Networking.Packets
{
    public class Table : PacketStructure
    {
        private DataTable _table;

        public DataTable TableData
        {
            get { return _table; }
        }

        public Table(DataTable tmpList)
        {
            _table = tmpList;
        }

        public Table(Byte[] bytes)
        {
            // TODO When increase the packet change this
            Byte[] tempBytes = new Byte[bytes.Length - 4];
            Array.Copy(bytes,4,tempBytes,0,tempBytes.Length);
            ByteArrayToTable(tempBytes);
        }

        public Table()
        {
            _table = new DataTable();
        }


        public void TableToByteArray(DataTable tmpList)
        {
            byte[] binaryDataResult = null;
            using (var memStream = new MemoryStream())
            {
                var brFormatter = new BinaryFormatter();
                brFormatter.Serialize(memStream, tmpList);
                binaryDataResult = memStream.ToArray();
            }
            // TODO CHANGE THIS WHEN CHANGE PACKET STRUCTURE
            _buffer = new Byte[binaryDataResult.Length + 4];
            WriteUShort((ushort)binaryDataResult.Length, 0);
            WriteUShort((ushort)1001, 2);
            Array.Copy(binaryDataResult, 0, _buffer, 4, binaryDataResult.Length);
        }

        public void ByteArrayToTable(Byte[] arrayBytes)
        {
            _buffer = arrayBytes;
            DataTable dt = null;
            // Deserializing into datatable    
            using (var stream = new MemoryStream(arrayBytes))
            {
                var bformatter = new BinaryFormatter();
                dt = (DataTable)bformatter.Deserialize(stream);
            }
            // Adding DataTable into DataSet    
            _table = dt;
        }
    }
}