using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class Login : System.Web.UI.Page
    {
        UserWebService.UserService service = new UserWebService.UserService();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginSubmit(object sender, EventArgs e)
        {
            UserWebService.User user = service.login(txtUsername.Value, txtPassword.Value);
            if (user != null)
            {
                Session["username"] = user.Username;
                Session["userid"] = user.ID;
                Response.Redirect("Dictionary.aspx");
            } else
            {
                pWarning.InnerText = "Username or Password is wrong";
            }
        }
    }
}