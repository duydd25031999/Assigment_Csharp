using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class MyPage : System.Web.UI.Page
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
            if (userid != null)
            {
                string username = (string)Session["username"];
                lblUsername.Visible = true;
                lblUsername.InnerText = "Hello " + username;
                btnUserChange.InnerText = "Logout";
            }
            else
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
            }
            else
            {
                Session.Remove("userid");
                Session.Remove("username");
                lblUsername.Visible = false;
                btnUserChange.InnerText = "Login";
            }
        }
        
    }
}