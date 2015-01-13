using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Stock_Manage_Server
{
    internal class SqlConnecter
    {
        /// <summary>
        ///     The main connection object
        /// </summary>
        private MySqlConnection _connection;

        /// <summary>
        ///     Create a database connector object with the default options for server name, user id and password
        /// </summary>
        /// <param name="db">The database name</param>
        public SqlConnecter(String db)
        {
            Initialize(db, "localhost", "root", "");
        }

        /// <summary>
        ///     Creates a database object with defined properties
        /// </summary>
        /// <param name="db">Database name</param>
        /// <param name="server">Sever location</param>
        /// <param name="uid">User ID</param>
        /// <param name="password">Password for user</param>
        public SqlConnecter(String db, String server, String uid, String password)
        {
            Initialize(db, server, uid, password);
        }

        /// <summary>
        ///     Initializes the SQL connection object
        /// </summary>
        private void Initialize(String database, String server, String uid, String password)
        {
            string connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" +
                                      password + ";";

            _connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        ///     Test the connection to the SQL Sever
        /// </summary>
        /// <returns>True if successful connection</returns>
        public bool TestConnection()
        {
            bool open = OpenConnection();
            try
            {
                CloseConnection();
            }
            catch
            {
            }
            return open;
        }

        /// <summary>
        ///     Opens the connection to the database
        /// </summary>
        /// <returns>True if successful connection</returns>
        private bool OpenConnection()
        {
            try
            {
                _connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server. Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        /// <summary>
        ///     Closes the connection to the server, true if successful
        /// </summary>
        /// <returns>If successful</returns>
        private bool CloseConnection()
        {
            try
            {
                _connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        ///     Execute a NonQuery to the server
        /// </summary>
        /// <param name="query">The query to be sent</param>
        public void NonQuery(String query)
        {
            if (OpenConnection())
            {
                var cmd = new MySqlCommand(query, _connection);

                cmd.ExecuteNonQuery();

                CloseConnection();
            }
        }

        /// <summary>
        ///     Execute a Select statement to the sql server
        /// </summary>
        /// <param name="query">The select statement</param>
        /// <returns>The datatable containing the data</returns>
        public Object Select(String query)
        {
            try
            {
                var dt = new DataTable();

                if (OpenConnection())
                {
                    var cmd = new MySqlCommand(query, _connection);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    DataTable schemaTable = dr.GetSchemaTable();
                    foreach (DataRowView row in schemaTable.DefaultView)
                    {
                        var columnName = (string) row["ColumnName"];
                        var type = (Type) row["DataType"];
                        dt.Columns.Add(columnName, type);
                    }


                    dt.Load(dr);

                    dr.Close();

                    return dt;
                }
                string error =
                    "ERROR: Connection to database could not be established, please contact an administrator!";
                return error;
            }
            catch (Exception e)
            {
                Console.WriteLine(query);
                Console.WriteLine(e.Message);
            }
            finally
            {
                CloseConnection();
            }
            return null;
        }

        /// <summary>
        ///     Executes a count query
        /// </summary>
        /// <param name="query">The SQL query</param>
        /// <returns>The counted amount</returns>
        public int Count(String query)
        {
            int count = 0;

            if (OpenConnection())
            {
                var cmd = new MySqlCommand(query, _connection);

                count = int.Parse(cmd.ExecuteScalar().ToString());

                CloseConnection();

                return count;
            }
            return count;
        }
    }
}