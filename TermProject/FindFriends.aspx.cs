using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class FindFriends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            if (Session["RememberMe"] != null)
            {
                //Delete cookies
                HttpCookie myCookie = Request.Cookies["Login"];
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnSettings_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Settings.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        protected void btnFindFriends_Click(object sender, EventArgs e)
        {
            Response.Redirect("FindFriends.aspx");
        }
    }
}