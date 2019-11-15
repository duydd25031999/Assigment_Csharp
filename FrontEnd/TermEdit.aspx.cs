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
            if(IsPostBack)
            {
                return;
            }
            getUserInfo();
            getTerm();
        }

        protected void EditNote(object sender, EventArgs e)
        {
            if(txtNote2.Enabled)
            {
                int userid = (int)Session["userid"];
                int termid = Convert.ToInt32(Request["term"]);
                string note = txtNote2.Text;
                noteService.UpdateNote(termid, userid, note);
                txtNote2.Enabled = false;
                btnCancel.Visible = false;
            } else
            {
                txtNote2.Enabled = true;
                btnCancel.Visible = true;
            }
           
            //Response.Redirect("Dictionary.aspx");
        }

        protected void CancelEdit(object sender, EventArgs e)
        {
            getTerm();
        }

        protected void getUserInfo()
        {
            object userid = Session["userid"];
            string username = (string)Session["username"];
            lblUsername.Visible = true;
            lblUsername.InnerText = "Hello " + username;
            lblUsername.HRef = "MyPage.aspx";
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
            txtNote2.Enabled = false;
            btnCancel.Visible = false;
            int userid = (int)Session["userid"];
            int termid = Convert.ToInt32(Request["term"]);
            SearchWebService.Term term = searchService.getTermByIdWithUser(termid, userid);
            kindOfDictionary.InnerText = term.Content;
            getNote(term);
            showDefinition(term);
        }



        protected void getNote(SearchWebService.Term term)
        {
            //txtNote.InnerText = term.Note;
            txtNote2.Text = term.Note;
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