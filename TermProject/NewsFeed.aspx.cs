using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialNetworkingClassLibrary;

namespace TermProject
{
    public partial class NewsFeed : System.Web.UI.Page
    {
        StoredProcedures procedures = new StoredProcedures();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            {
                Server.Transfer("Default.aspx", false);
            }

            string email = Session["Email"].ToString();
            int verificationToken = Convert.ToInt32(Session["VerificationToken"].ToString());
            WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/GetNewsFeed/" + email + "/" + verificationToken);
            //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/GetNewsFeed/" + email + "/" + password);
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();
            SocialNetworkingClassLibrary.NewsFeed newsFeed = js.Deserialize<SocialNetworkingClassLibrary.NewsFeed>(data);

            int count = newsFeed.Posts.Count;
            PostControl ctrl;
            for (int i = 0; i < count; i++)
            {
                ctrl = (PostControl)LoadControl("PostControl.ascx");
                String name = newsFeed.Posts[i].FirstName + " " + newsFeed.Posts[i].LastName;
                ctrl.ImageURL = newsFeed.Posts[i].PhotoUrl;
                ctrl.PosterName = name;
                ctrl.Time = newsFeed.Posts[i].dateOfPost.ToString();
                ctrl.Post = newsFeed.Posts[i].Message.ToString();
                previousPostColumn.Controls.Add(ctrl);
            }
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
        protected void btnMessenger_Click(object sender, EventArgs e)
        {
            Server.Transfer("Messenger.aspx", false);
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