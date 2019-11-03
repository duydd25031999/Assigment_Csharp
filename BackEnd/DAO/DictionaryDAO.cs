using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BackEnd.Entity;
namespace BackEnd.DAO
{
    public class DictionaryDAO
    {
        string conn = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
        Definition dr = new Definition();
        public void dic(int dicID, string search)
        {
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

    }
}