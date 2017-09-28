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
            try
            {
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
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            
            return photos;
        }

        public Voter getAccount(string email, string password)
        {
            Voter voter = null;
            try
            {
                connection.Open();

                string queryString = "SELECT email, firstname FROM voter WHERE email = @email AND password = @password";
                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);

                while (rdr.Read())
                {
                    string emaildatabase = rdr.GetString("email");
                    string firstname = rdr.GetString("firstname");
                    voter = new Voter(emaildatabase, firstname);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                cmd.Parameters.AddWithValue("@id", photo.ID);
                cmd.Parameters.AddWithValue("@caption", photo.caption);
                cmd.Parameters.AddWithValue("@imagedata", photo.imageUrl);
                cmd.Parameters.AddWithValue("@story", photo.text);
                cmd.Parameters.AddWithValue("@tags", photo.tags);
                cmd.Parameters.AddWithValue("@credit", photo.credit);

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
                string queryString = "INSERT INTO vote (photoid, voter) VALUES (@photoid, @voter)";

                MySqlCommand cmd = new MySqlCommand(queryString, connection);
                cmd.Parameters.AddWithValue("@photoid", photoID);
                cmd.Parameters.AddWithValue("@voter", userEmail);

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