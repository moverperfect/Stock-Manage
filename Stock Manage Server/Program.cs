using System;
using System.Data;
using System.Security.Cryptography;
using Stock_Manage_Client.Classes;
using Stock_Manage_Server.Networking;
using System.Collections.Generic;

namespace Stock_Manage_Server
{
    /// <summary>
    /// Main entry point into the server
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The socket used to communicate with the client machines
        /// </summary>
        public static ServerSocket Serversocket = new ServerSocket();

        /// <summary>
        /// The machine id of the machine, mainly used when creating packets
        /// </summary>
        public static ushort MachineId = 0;

        /// <summary>
        /// The user id of the machine, mainly used when creating packets
        /// </summary>
        public static ushort UserId = 0;

        /// <summary>
        /// Main entry point into the program, starts listening for connections
        /// </summary>
        private static void Main(string[] args)
        {
            SetupSql();

            // Open the server and listen to connections
            Serversocket.Bind(8221);
            Serversocket.Listen(500);
            Serversocket.Accept();

            Console.ReadLine();
        }

        /// <summary>
        /// Sets up the MySql server with the correct tables
        /// </summary>
        private static void SetupSql()
        {
            var sqlconnector = new SqlConnecter("db_inventorymanagement");
            if (!sqlconnector.TestConnection()) // If we are not able to connect with that database name
            {
                // Set up the entire database if able to connect
                sqlconnector = new SqlConnecter("");
                if (sqlconnector.TestConnection())
                {
                    sqlconnector.NonQuery(ServerResources.CreateSqlDatabase);
                    Console.WriteLine("MySql Server has been setup, please ignore previous messages");
                }
                else
                {
                    Console.WriteLine("Unable to connect to the database, please start MySql and reopen this program.");
                    return;
                }
            }
            else
            {
                // Get the tables in the database
                var tables = (DataTable) sqlconnector.Select("SHOW TABLES");
                var list = new List<String>();
                for (int i = 0; i < tables.Rows.Count; i++)
                {
                    // If we have not found a table
                    if ((tables.Rows[i][0].ToString() == "tbl_orders" || tables.Rows[i][0].ToString() == "tbl_products" ||
                          tables.Rows[i][0].ToString() == "tbl_purchase_orders" ||
                          tables.Rows[i][0].ToString() == "tbl_suppliers" ||
                          tables.Rows[i][0].ToString() == "tbl_users"))
                    {
                        list.Add(tables.Rows[i][0].ToString());
                    }
                }

                // If we havent found a table then run the sql to create the tables
                if (list.Count != 5)
                {
                    sqlconnector.NonQuery(ServerResources.CreateSqlDatabase);
                }

            }

            // Get the users in the database
            var users = (DataTable)sqlconnector.Select("SELECT * FROM tbl_users");

            // If there are no users then ask to setup a management user
            if (users.Rows.Count == 0)
            {
                Console.WriteLine("There are no users in the database, please enter a 4 digit UserID");
                var userid = Console.ReadLine();
                Console.WriteLine("Please enter the 4 digit password");
                var password = Console.ReadLine();

                // Create salt and hash
                var salt = Utilities.GenerateSaltValue();
                var passwordhash = Utilities.HashPassword(password, salt, MD5.Create());

                sqlconnector.NonQuery("INSERT INTO tbl_Users(PK_UserId, System_Role, First_Name, Second_Name, Password_Hash, Salt) VALUES ('" +
                userid + "','Management','','','" + passwordhash + "','" + salt +
                "');");
            }
        }
    }
}