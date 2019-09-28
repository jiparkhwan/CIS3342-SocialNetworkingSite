using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class Messenger : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Email"] == null)
            {
                Server.Transfer("Default.aspx", false);
            }

            MessengerControl1.UserEmail = Session["Email"].ToString();
            MessengerControl1.DataBind();
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Server.Transfer("Profile.aspx", false);
        }
        protected void btnHome_Click(object sender, EventArgs e)
        {
            Server.Transfer("NewsFeed.aspx", false);
        }
        protected void btnFindFriends_Click(object sender, EventArgs e)
        {
            Server.Transfer("FindFriends.aspx", false);
        }
        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            Server.Transfer("EditProfile.aspx", false);
        }
        protected void btnSettings_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("Settings.aspx", false);
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            //Delete cookies
            HttpCookie myCookie = Request.Cookies["Login"];
            if (myCookie != null)
            {
                myCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(myCookie);
                Response.Redirect("Default.aspx", false);
            }
            Server.Transfer("Default.aspx", false);
        }
    }
}