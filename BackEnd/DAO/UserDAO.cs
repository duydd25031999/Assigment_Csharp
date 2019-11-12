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
            string sql = "select * from [user] where cast(" + username + " as nvarchar) = N'user1' and cast([" + password + "] as nvarchar) = N'123'";
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(sql, contr);
            contr.Open();
            //Read data form SQL and add to list
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                /*To Do
                 * fill data in db into correct field in entity
                 */
                u = new User();
                u.ID = 0;
                u.Username = (string)dr["username"];
                u.Password = (string)dr["password"];
                u.Email = null;
                u.DateOfBirth = new DateTime();
            }
            contr.Close();
            return u;
        }
        public void createUser(User newUser)
        {
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[user] (username, password, email, dob) VALUES (" +  newUser.Username + "', '" + newUser.Password + "', '" + newUser.Email + "', '" + newUser.DateOfBirth.ToString() + "')");
            contr.Open();
            cmd.ExecuteNonQuery();
            contr.Close();
        }

        public User getUserByUsername(string username)
        {
            /*To Do
                * get user by user name
                * to support login check password
                * to signup check existed user
            */
            return null;
        }
    }
}