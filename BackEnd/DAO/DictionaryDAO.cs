using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using Entity;
namespace BackEnd.DAO
{
    public class DictionaryDAO
    {
        string conn = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        
        public void definitionDAO(int dicID, string search)
        {
            // GET DEFINITION OF WORD
            //dicID will be gotten by droplist in search box
            List<Definition> list = new List<Definition>();
            string sql = "SELECT d.[index], d.content FROM dbo.def d, dbo.dictionary dic, dbo.term t WHERE dic.id = t.dictionaryid AND d.termid = t.id AND dic.id = " + dicID + " AND t.content LIKE N'" + search.ToLower().IsNormalized() + "'";
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(sql, contr);
            contr.Open();
            //Read data form SQL and add to list
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                Definition def = new Definition();
                def.Content= (string)dr["content"];
                list.Add(def);
            }
        }

        public void dicDAO()
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
                dic._id = (int)dr["id"];
                dic._name = (string)dr["name"];
                list.Add(dic);
            }
        }
        
    }
}
