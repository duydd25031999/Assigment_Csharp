using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class TermEdit : System.Web.UI.Page
    {
        public SearchWebService.SearchService searchService;
        public NoteWebService.NoteService noteService;
        protected void Page_Load(object sender, EventArgs e)
        {
            searchService = new SearchWebService.SearchService();
            noteService = new NoteWebService.NoteService();
            getUserInfo();
            getTerm();
        }

        protected void EditNote(object sender, EventArgs e)
        {
            int userid = (int)Session["userid"];
            int termid = Convert.ToInt32(Request["term"]);
            string note = txtNote.Value;
            noteService.UpdateNote(termid, userid, note);
            Response.Redirect("Dictionary.aspx");
        }

        protected void CancelEdit(object sender, EventArgs e)
        {
            Response.Redirect("Dictionary.aspx");
        }

        protected void getUserInfo()
        {
            object userid = Session["userid"];
            string username = (string)Session["username"];
            lblUsername.Visible = true;
            lblUsername.InnerText = "Hello " + username;
            btnUserChange.InnerText = "Logout";
        }

        protected void ChangeUser(object sender, EventArgs e)
        {
            Session.Remove("userid");
            Session.Remove("username");
            Response.Redirect("Dictionary.aspx");
        }



        protected void getTerm()
        {
            int userid = (int)Session["userid"];
            int termid = Convert.ToInt32(Request["term"]);
            SearchWebService.Term term = searchService.getTermByIdWithUser(termid, userid);
            kindOfDictionary.InnerText = term.Content;
            getNote(term);
            showDefinition(term);
        }



        protected void getNote(SearchWebService.Term term)
        {
            txtNote.InnerText = term.Note;
        }

        protected void showDefinition(SearchWebService.Term term)
        {
            var html = "";
            html += "<table>";
            foreach (SearchWebService.Definition d in term.Definitions)
            {
                html += "<tr>";
                if (d.Type == "word-class")
                {
                    html += "<td class=\"word-class\">* " + d.Content + "</td>";
                }
                else if (d.Type == "meaning")
                {
                    html += "<td class=\"meaning\">&emsp;" + d.Content + "</td>";
                }
                else if (d.Type == "header")
                {
                    html += "<td class=\"header\">" + d.Content + "</td>";
                }
                else if (d.Type == "example")
                {
                    html += "<td class=\"example\">-&emsp;&emsp;" + d.Content + "</td>";
                }
                else if (d.Type == "explain")
                {
                    html += "<td class=\"explain\">&emsp;&emsp;" + d.Content + "</td>";
                }
                else if (d.Type == "other")
                {
                    html += "<td class=\"other\">" + d.Content + "</td>";
                }

                // more cells here as needed
                html += "</tr>";
            }
            html += "</table>";
            demo.InnerHtml = html;
        }
    }
}