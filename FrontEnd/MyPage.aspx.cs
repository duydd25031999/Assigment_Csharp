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
        public NoteWebService.NoteService noteService;

        protected void Page_Load(object sender, EventArgs e)
        {
            ss = new SearchWebService.SearchService();
            noteService = new NoteWebService.NoteService();
            if(IsPostBack)
            {
                return;
            }
            getUserInfo();
            getNote();
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

        protected void getNote()
        {
            object user = Session["userid"];
            int userid = Convert.ToInt32(user);
            NoteWebService.Note[] list = noteService.getNoteByUser(userid);
            string html = "";
            foreach(NoteWebService.Note i in list)
            {
                string note = "<div class=\"card\">";
                    note += "<div class=\"card-header\"><a href=\"TermEdit.aspx?term=" + i.TermID + "\">" + i.TermContent + "</a></div>";
                    note += "<div class=\"card-main\">";
                        note += "<div class=\"main-description\">" + i.Content  + "</div>" ;
                    note += "</div>";
                note += "</div>";
                html += note;
            }
            page_content.InnerHtml = html;
        }
        
    }
}