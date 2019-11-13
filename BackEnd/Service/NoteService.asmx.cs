using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BackEnd.DAO;

namespace BackEnd.Service
{
    /// <summary>
    /// Summary description for NoteService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NoteService : System.Web.Services.WebService
    {
        NoteDAO noteDAO = new NoteDAO();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool UpdateNote(int termid, int userid, string newNote)
        {
            string oldNote = noteDAO.getNote(termid, userid);
            if(oldNote == null)
            {
                if(newNote.Length > 0)
                {
                    noteDAO.createNote(termid, userid, newNote);
                }
            } else
            {
                if (newNote.Length == 0)
                {
                    noteDAO.deleteNote(termid, userid);
                } else
                {
                    noteDAO.updateNote(termid, userid, newNote);
                }
            }
            return true;
        }
    }
}
