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
            string connString = "Server= https://klar1573.iba-abakomp.dk:8080/phpmyadmin ;Database=c1db1;Uid=c1dbu1;Pwd=GWuQMoHB5b;";
            connection = new MySqlConnection(connString);
        }

        public MySqlConnection getConnection()
        {
            return this.connection;
        }

    }
}