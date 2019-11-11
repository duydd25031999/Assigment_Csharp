using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using Entity;
namespace BackEnd.DAO
{
    public class DictionaryDAO
    {
        string conn = WebConfigurationManager.ConnectionStrings["myConnectionString"].ToString();

        public List<Definition> getListDefByString(int dicID, string search)
        {
            // GET DEFINITION OF WORD
            //dicID will be gotten by droplist in search box
            List<Definition> list = new List<Definition>();
            string sql = "SELECT d.[index], d.termid, d.id, d.[type],d.content FROM dbo.def d, dbo.dictionary dic, dbo.term t WHERE dic.id = t.dictionaryid AND d.termid = t.id AND dic.id = " + dicID + " AND t.content LIKE N'" + search.ToLower() + "'";
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(sql, contr);
            contr.Open();
            //Read data form SQL and add to list
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                // index, id, term type
                Definition def = new Definition();
                def.ID = (int)dr["id"];
                def.Index = (int)dr["index"];
                def.TermID = (int)dr["termid"];
                def.TypeCode = (int)dr["type"];
                def.Content = (string)dr["content"];
                list.Add(def);
            }
            contr.Close();
            return list;
        }

        public List<Dictionary> getAllDictionary()
        {
            //GET ALL DICTIONARY
            List<Dictionary> list = new List<Dictionary>();
            string sql = "SELECT * FROM dbo.dictionary";
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(sql, contr);
            contr.Open();
            //Read data form SQL and add to list
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                Dictionary dic = new Dictionary();
                dic.ID = (int)dr["id"];
                dic.Name = (string)dr["name"];
                list.Add(dic);
            }
            contr.Close();
            return list;
        }

        public List<Term> getTop5TermByString(int dicID, string search)
        {
            //get top 5 term contains user input
            List<Term> list = new List<Term>();
            string sql = "select top (5) * from term where content like N'" + search + "%' and dictionaryid = " + dicID;
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(sql, contr);
            contr.Open();
            //Read data form SQL and add to list
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                Term term = new Term();
                term.ID = (int)dr["id"];
                term.Content = (string)dr["content"];
                term.DictionaryID = (int)dr["dictionaryid"];
                list.Add(term);
            }
            contr.Close();
            return list;
        }

        public List<Definition> getDefinitionByTerm(Term term)
        {
            List<Definition> list = new List<Definition>();
            string sql = "select * from def where termid = " + term.ID;
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(sql, contr);
            contr.Open();
            //Read data form SQL and add to list
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                // index, id, term type
                Definition def = new Definition();
                def.ID = (int)dr["id"];
                def.Index = (int)dr["index"];
                def.TermID = (int)dr["termid"];
                def.TypeCode = (int)dr["type"];
                def.Content = (string)dr["content"];
                list.Add(def);
            }
            contr.Close();
            return list;
        }
        
        public List<User> userLogin(string username, string password)
        {
            List<User> list = new List<User>();
            string sql = "SELECT u.username, u.password FROM[dbo].[user] u WHERE u.username LIKE '" + username + "' AND u.password LIKE '" + password + "'";
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(sql, contr);
            contr.Open();
            //Read data form SQL and add to list
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                // index, id, term type
                User user = new User();
                user.Username = (string)dr["username"];
                user.Password = (string)dr["password"];
                list.Add(user);
            }
            return list;
        }

        public List<User> userSignIn(int id, string username, string password, string email, string dob)
        {
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[user] (id, username, password, email, dob) VALUES (" + id + ", '" + username + "', '" + password + "', '" + email + "', '" + dob + "')");
            contr.Open();
            cmd.ExecuteNonQuery();
            contr.Close();
            return null;
        }
        
        
        
    }
}
