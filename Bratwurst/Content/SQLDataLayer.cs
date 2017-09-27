using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using Bratwurst.Classes;

namespace Bratwurst.Content
{
    public class SQLDataLayer
    {
        private MySqlConnection connection;

        public SQLDataLayer()
        {
            Database db = new Database();
            this.connection = db.getConnection();
        }

        public List<Photo> getPictures()
        {
            List<Photo> photos = new List<Photo>();
            using (connection)
            {
                string queryString = "SELECT *, (SELECT COUNT(*) FROM vote vo2, photo ph2 WHERE vo2.photoid = ph2.id AND ph1.id = ph2.id) AS amount FROM photo ph1, vote vo1 WHERE ph1.id = vo1.photoid";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int photoid = rdr.GetInt32("id");
                    string caption = rdr.GetString("caption");
                    string image = rdr.GetString("imagedata");
                    string story = rdr.GetString("story");
                    string tags = rdr.GetString("tags");
                    string credit = rdr.GetString("credit");
                    int amountOfVoters = rdr.GetInt32("amount");
                    photos.Add(new Photo(photoid, caption, image, story, tags, credit, amountOfVoters));
                }

            }
                return photos;
        }

        public Voter getAccount(string email, string password)
        {
            using (connection)
            {
                string queryString = "SELECT email, firstname FROM voter WHERE email = @email AND password = @password";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                cmd.Parameters.Add("@email", MySqlDbType.VarChar);
                cmd.Parameters[@email].Value = email;
                cmd.Parameters.Add("@password", MySqlDbType.VarChar);
                cmd.Parameters[@password].Value = password;

                while (rdr.Read())
                {
       
                }

            }
            return null;
        }
    }
}