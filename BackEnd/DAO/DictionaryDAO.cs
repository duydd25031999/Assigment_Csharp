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
            term.Definitions = list;
            return list;
        }

        public Term getTermByString(int dicID, string search)
        {
            //get top 5 term contains user input
            Term term = new Term();
            string sql = "select * from term where content like N'" + search + "' and dictionaryid = " + dicID;
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(sql, contr);
            contr.Open();
            //Read data form SQL and add to list
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                term.ID = (int)dr["id"];
                term.Content = (string)dr["content"];
                term.DictionaryID = (int)dr["dictionaryid"];
            }
            contr.Close();
            if(term.ID != -1)
            {
                getDefinitionByTerm(term);
            }
            return term;
        }

        public Term getTermById(int termid)
        {
            //get top 5 term contains user input
            Term term = new Term();
            string sql = "select * from term where id = " + termid;
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(sql, contr);
            contr.Open();
            //Read data form SQL and add to list
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                term.ID = (int)dr["id"];
                term.Content = (string)dr["content"];
                term.DictionaryID = (int)dr["dictionaryid"];
            }
            contr.Close();
            if (term.ID != -1)
            {
                getDefinitionByTerm(term);
            }
            return term;
        }
    }
}
