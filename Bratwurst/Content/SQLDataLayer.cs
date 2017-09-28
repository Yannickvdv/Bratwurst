using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using Bratwurst.Models;

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
           
            connection.Open();
            string queryString = "SELECT *, COUNT(vo.photoid) AS amount FROM photo ph LEFT JOIN vote vo ON vo.photoid = ph.id GROUP BY ph.id";

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
            connection.Close();
            
            
            return photos;
        }

        public Voter getAccount(string email, string password)
        {
            Voter voter = null;  
            connection.Open();

            string queryString = "SELECT email, firstname FROM voter WHERE email = @email AND password = @password";
            MySqlCommand cmd = new MySqlCommand(queryString, connection);
            MySqlDataReader rdr = cmd.ExecuteReader();

            cmd.Parameters.Add("@email", MySqlDbType.VarChar);
            cmd.Parameters[@email].Value = email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar);
            cmd.Parameters[@password].Value = password;

                
            while (rdr.Read())
            {
                string emaildatabase = rdr.GetString("email");
                string firstname = rdr.GetString("firstname");
                voter = new Voter(emaildatabase, firstname);
            }

            connection.Close();
            return voter;
        }

        public bool uploadImage(Photo photo)
        {
            try
            {
                connection.Open();
                string queryString = "INSERT INTO photo (id, caption, imagedata, story, tags, credit) VALUES (@id, @caption, @imagedata, @story, @tags, @credit)";

                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters["@id"].Value = photo.ID;
                cmd.Parameters["@caption"].Value = photo.caption;
                cmd.Parameters["@imagedata"].Value = photo.imageUrl;
                cmd.Parameters["@story"].Value = photo.text;
                cmd.Parameters["@tags"].Value = photo.tags;
                cmd.Parameters["@credit"].Value = photo.credit;

                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool likePicture(int photoID, string userEmail)
        {
            try
            {
                connection.Open();
                string queryString = "INSERT INTO vote (email, password) VALUES (@email, @password)";

                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters["@email"].Value = photoID;
                cmd.Parameters["@password"].Value = userEmail;

                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}