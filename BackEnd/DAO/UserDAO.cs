using System.Data.SqlClient;
using System.Web.Configuration;
using Entity;

namespace BackEnd.DAO
{
    public class UserDAO
    {
        string conn = WebConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
        public User getUser(string username, string password)
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
                u = new User();
                u.Username = (string)dr["username"];
                u.Password = (string)dr["password"];
            }
            contr.Close();
            return u;
        }
    }
}