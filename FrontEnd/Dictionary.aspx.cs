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
        }

        protected void getUserInfo()
        {
            object userid = Session["userid"];
            if(userid != null)
            {
                string username = (string)Session["username"];
                lblUsername.InnerText = "Hello " + username;
                btnUserChange.InnerText = "Logout";
            } else
            {
                lblUsername.InnerText = "";
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
                lblUsername.InnerText = "";
                btnUserChange.InnerText = "Login";
            }
        }

        protected void Search(object sender, EventArgs e)
        {
            string input = Request.Form["keyWord"];
            
            int kindOfDictionary = Int32.Parse(kindOfDic.Value);

            SearchWebService.Term term = ss.getTermByString(kindOfDictionary, input);
            SearchWebService.Definition[] defs = ss.getListDefByString(kindOfDictionary, input);
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

            kindOfDic.SelectedIndex = kindOfDictionary-1;

        }

    }
}