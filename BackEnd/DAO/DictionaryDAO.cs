using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using Entity;
namespace BackEnd.DAO
{
    public class DictionaryDAO
    {
        string conn = WebConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
        /*
         * List<Definition> list = new List<Definition>();
            string sql = "SELECTd.[index], d.termid, d.id, d.[type],d.content FROM dbo.def d, dbo.dictionary dic, dbo.term t WHERE dic.id = t.dictionaryid AND d.termid = t.id AND dic.id = " + dicID + " AND t.content LIKE N'" + search.ToLower().IsNormalized() + "'";
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
                def.Content= (string)dr["content"];
                list.Add(def);
            }
         */
        public List<Definition> getListDefByString(int dicID, string search)
        {
            //dicID is dictionaryID which gotten by droplist in search
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
            return list;
        }

    }
}
