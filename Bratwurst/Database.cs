using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Bratwurst
{
    public class Database
    {
        private MySqlConnection connection;

        public Database()
        {
            string connString = "Server=sql11.freemysqlhosting.net;Port=3306;Database=sql11196548;Uid=sql11196548;Pwd=mdCRa8s4tj;";
            connection = new MySqlConnection(connString);
        }

        public MySqlConnection getConnection()
        {
            return this.connection;
        }

    }
}