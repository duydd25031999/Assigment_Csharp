using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class Dictionary : System.Web.UI.Page
    {

        public SearchWebService.SearchService ss;

        protected void Page_Load(object sender, EventArgs e)
        {
            ss = new SearchWebService.SearchService();
            getUserInfo();
            divNote.Visible = false;
        }

        protected void getUserInfo()
        {
            object userid = Session["userid"];
            if(userid != null)
            {
                string username = (string)Session["username"];
                lblUsername.Visible = true;
                lblUsername.InnerText = "Hello " + username;
                lblUsername.HRef = "MyPage.aspx";
                btnUserChange.InnerText = "Logout";
            } else
            {
                lblUsername.Visible = false;
                btnUserChange.InnerText = "Login";
            }
            
        }

        protected void ChangeUser(object sender, EventArgs e)
        {
            object userid = Session["userid"];
            if (userid == null)
            {
                Response.Redirect("Login.aspx");
            } else
            {
                Session.Remove("userid");
                Session.Remove("username");
                lblUsername.Visible = false;
                btnUserChange.InnerText = "Login";
            }
        }

        protected void Search(object sender, EventArgs e)
        {
            string input = Request.Form["keyWord"];
            int kindOfDictionary = Int32.Parse(kindOfDic.Value);
            getDefinitions(input, kindOfDictionary);
        }

        protected void getDefinitions(string input, int kindOfDictionary)
        {
            SearchWebService.Term term = null;
            object userid = Session["userid"];
            if (userid != null)
            {
                term = ss.getTermByStringWithUser(kindOfDictionary, input, Convert.ToInt32(userid));
                if (term.ID != -1)
                {
                    divNote.Visible = true;
                    getNote(term);
                }
            } else
            {
                term = ss.getTermByString(kindOfDictionary, input);
            }
            showDefinition(term);
        }

        

        protected void getNote(SearchWebService.Term term)
        {
            btnNote.HRef = "TermEdit.aspx?term=" + term.ID;
            if(term.Note.Length == 0)
            {
                lblNote.Visible = false;
            }
            lblNote.InnerText = term.Note;
           
            
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