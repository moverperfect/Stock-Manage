using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Stock_Manage_Client.Classes.Networking.Packets
{
    /// <summary>
    /// A Table object for byte arrays
    /// </summary>
    public class Table : PacketStructure
    {
        /// <summary>
        /// The DataTable data
        /// </summary>
        private DataTable _table;

        /// <summary>
        /// Create a new Table with a DataTable
        /// </summary>
        /// <param name="tmpTable">The table to be stored in the byte array</param>
        /// <param name="machineId">The machine id of the machine that created the packet</param>
        /// <param name="userId">The user id of the user who created the packet</param>
        public Table(DataTable tmpTable, ushort machineId, ushort userId)
        {
            TableData = tmpTable;
            TableToByteArray(tmpTable);
            WriteUShort(1001, 2);
            WriteUShort(machineId, 4);
            WriteUShort(userId, 6);
        }

        /// <summary>
        /// Create a new Table with byte array already
        /// </summary>
        /// <param name="bytes">The byte array to be made with</param>
        public Table(Byte[] bytes)
            : base(bytes)
        {
            var tempBytes = new Byte[bytes.Length - 8];
            Array.Copy(bytes, 8, tempBytes, 0, tempBytes.Length);
            ByteArrayToTable(tempBytes);
        }

        /// <summary>
        /// Create a empty Table packet
        /// </summary>
        public Table()
        {
            _table = new DataTable();
        }

        /// <summary>
        /// The Datatable
        /// </summary>
        public DataTable TableData
        {
            get { return _table; }
            private set
            {
                _table = value;
                TableToByteArray(value);
            }
        }

        /// <summary>
        /// Turns a DataTable into a byte array
        /// </summary>
        /// <param name="tmpList"></param>
        public void TableToByteArray(DataTable tmpList)
        {
            byte[] binaryDataResult;
            // Serializing the DataTable
            using (var memStream = new MemoryStream())
            {
                var brFormatter = new BinaryFormatter();
                brFormatter.Serialize(memStream, tmpList);
                binaryDataResult = memStream.ToArray();
            }
            Buffer = new Byte[binaryDataResult.Length + 8];
            WriteUShort((ushort) Buffer.Length, 0);
            Array.Copy(binaryDataResult, 0, Buffer, 8, binaryDataResult.Length);
        }

        /// <summary>
        /// Turns the byte array into a DataTable
        /// </summary>
        /// <param name="arrayBytes">The byte array to be turned into a byte array</param>
        public void ByteArrayToTable(Byte[] arrayBytes)
        {
            Buffer = arrayBytes;
            DataTable dt;
            // Deserializing into datatable    
            using (var stream = new MemoryStream(arrayBytes))
            {
                var bformatter = new BinaryFormatter();
                dt = (DataTable) bformatter.Deserialize(stream);
            }
            // Adding DataTable into DataSet    
            _table = dt;
        }
    }
}