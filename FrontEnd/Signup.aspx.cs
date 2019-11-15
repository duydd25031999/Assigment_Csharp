using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class Signup : System.Web.UI.Page
    {
        UserWebService.UserService service = new UserWebService.UserService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignupExcute(object sender, EventArgs e)
        {
            string username = txtName.Value;
            if(service.userExited(username))
            {
                pWarning.InnerText = "User has exited";
                return;
            }
            string password = txtPassword.Value;
            string email = txtEmail.Value;
            string dob = txtDob.Value;
            service.signup(username, password, email, dob);
            Response.Redirect("Login.aspx");
        }
    }
}