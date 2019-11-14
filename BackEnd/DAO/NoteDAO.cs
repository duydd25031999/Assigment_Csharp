using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entity;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace BackEnd.DAO
{
    public class NoteDAO
    {
        string conn = WebConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
        public void createNote(int termid, int userid, string newNote)
        {
            string query = "insert into [termNote] (termid, userid, note) values (" + termid + ", " + userid + ", N'" + newNote + "')";
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand(query, contr);
            contr.Open();
            cmd.ExecuteNonQuery();
            contr.Close();
        }

        public string getNote(int termid, int userid)
        {
            string sql = "select * from termNote where termid = " + termid + " and userid = " + userid;
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(sql, contr);
            contr.Open();
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                string note = (string)dr["note"];
                return note;
            }
            contr.Close();
            return null;
        }

        public string getNoteByTerm(Term term, int userid)
        {
            string sql = "select * from termNote where termid = " + term.ID + " and userid = " + userid;
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(sql, contr);
            contr.Open();
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                string note =  (string)dr["note"];
                term.Note = note;
                return note;
            }
            contr.Close();
            return null;
        }

        public void updateNote(int termid, int userid, string newNote)
        {
            string query = "update termNote set note = N'" + newNote + "' where termid = " + termid + " and userid = " + userid;
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand(query, contr);
            contr.Open();
            cmd.ExecuteNonQuery();
            contr.Close();
        }

        public void deleteNote(int termid, int userid)
        {
            string query = "delete from termNote where termid = " + termid + " and userid = " + userid;
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand cmd = new SqlCommand(query, contr);
            contr.Open();
            cmd.ExecuteNonQuery();
            contr.Close();
        }

        public List<Note> getNoteByUser(int userid)
        {
            List<Note> list = new List<Note>();
            string query = "select termNote.termid, termNote.userid, termNote.note, term.content from termNote inner join term on termNote.termid = term.id where userid = " + userid;
            SqlConnection contr = new SqlConnection(conn);
            SqlCommand da = new SqlCommand(query, contr);
            contr.Open();
            SqlDataReader dr = da.ExecuteReader();
            while (dr.Read())
            {
                Note note = new Note();
                note.TermID = (int)dr["termid"];
                note.UserID = (int)dr["userid"];
                note.Content = (string)dr["note"];
                note.TermContent = (string)dr["content"];
                list.Add(note);
            }
            contr.Close();
            return list;
        }
    }
}