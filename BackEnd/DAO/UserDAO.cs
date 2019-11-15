using System.Data.SqlClient;
using System.Web.Configuration;
using System;
using Entity;

namespace BackEnd.DAO
{
    public class UserDAO
    {
        string conn = WebConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
        public User login(string username, string password)
        {
            User u = null;
            string sql = "select * from [user] where [username] like N'" + username + "' and [password] like N'" + password + "'";
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(sql, contr);
            contr.Open();
            //Read data form SQL and add to list
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                u = new User();
                u.ID = (int) dr["id"];
                u.Username = (string) dr["username"];
                u.Password = (string) dr["password"];
                u.Email = (string) dr["email"];
                object tmp = dr["dob"];
                DateTime date = (DateTime)Convert.ToDateTime(tmp);
                u.DateOfBirth = date;
            }
            contr.Close();
            return u;
        }
        public void createUser(string username, string password, string email, DateTime dob)
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            string date = dob.ToString(format);
            string query = "INSERT INTO [user] (username, password, email, dob) VALUES (N'" + username + "', '" + password + "', '" + email + "', '" + date + "')";
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand(query, contr);
            contr.Open();
            cmd.ExecuteNonQuery();
            contr.Close();
        }

        public User getUserByUsername(string username)
        {
            User u = null;
            string sql = "select * from [user] where [username] like N'" + username + "'";
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(sql, contr);
            contr.Open();
            //Read data form SQL and add to list
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                u = new User();
                u.ID = (int)dr["id"];
                u.Username = (string)dr["username"];
                u.Password = (string)dr["password"];
                u.Email = (string)dr["email"];
                object tmp = dr["dob"];
                DateTime date = (DateTime) Convert.ToDateTime(tmp);
                u.DateOfBirth = date;
            }
            contr.Close();
            return u;
        }
    }
}