using SocialNetworkingClassLibrary;
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

namespace TermProject
{
    public partial class ViewProfile : System.Web.UI.Page
    {
        StoredProcedures procedures = new StoredProcedures();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Email"] == null)
                {
                    Server.Transfer("Default.aspx", false);
                }
                else
                {
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    string email = Session["Email"].ToString();
                    string requestingEmail = Session["TargetEmail"].ToString();
                    int verificationToken = Convert.ToInt32(Session["VerificationToken"].ToString());
                    WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/GetProfile/" + email + "/" + requestingEmail + "/" + verificationToken);
                    //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/GetProfile/" + email + "/" + requestingEmail + "/" + verificationToken);
                    WebResponse response = request.GetResponse();
                    // Read the data from the Web Response, which requires working with streams.
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    // Deserialize a JSON string into a Team object.
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    SocialNetworkingClassLibrary.Profile profile = js.Deserialize<SocialNetworkingClassLibrary.Profile>(data);
                    profileImageDiv.InnerHtml = 
                        "<br /><img src= \"" + profile.User.ProfilePhotoUrl + "\" style=\"width:200px; height:200px;\"></img>";
                    profileInformationDiv.InnerHtml = "<br /><br /><br /><br /><h2>" + profile.User.FirstName + " " + profile.User.LastName + "</h2>";
                    if (profile.Friends != null)
                    {
                        PrivacyColumn.Visible = false;
                        gvFriends.DataSource = profile.Friends;
                        gvFriends.DataBind();
                        btnSubmitPost.Click += btnSubmitPost_Click;
                        gvPhotos.DataSource = profile.Photos;
                        gvPhotos.DataBind();
                        DataSet ds = new DataSet();
                        ds = procedures.GetProfilePosts(Session["TargetEmail"].ToString());
                        int rows = ds.Tables[0].Rows.Count;
                        PostControl ctrl;
                        for (int i = 0; i < rows; i++)
                        {
                            ctrl = (PostControl)LoadControl("PostControl.ascx");
                            String name = ds.Tables[0].Rows[i]["FirstName"].ToString() + " " + ds.Tables[0].Rows[i]["LastName"].ToString();
                            ctrl.ImageURL = ds.Tables[0].Rows[i]["ProfilePhotoUrl"].ToString();
                            ctrl.PosterName = ds.Tables[0].Rows[i]["Email"].ToString();
                            ctrl.Time = ds.Tables[0].Rows[i]["Date"].ToString();
                            ctrl.Post = ds.Tables[0].Rows[i]["Message"].ToString();
                            previousPostColumn.Controls.Add(ctrl);
                        }
                    }
                    else
                    {
                        friends.Visible = false;
                        postColumn.Visible = false;
                        
                    }
                }
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
        protected void btnEditProfile_Click(object sender, EventArgs e)
        {
            Server.Transfer("EditProfile.aspx", false);
        }

        protected void btnMessenger_Click(object sender, EventArgs e)
        {
            Server.Transfer("Messenger.aspx", false);
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
        protected void gvFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Add("TargetEmail", gvFriends.DataKeys[gvFriends.SelectedIndex]["Email"].ToString());
            Server.Transfer("ViewProfile.aspx");
        }

        protected void btnSubmitPost_Click(object sender, EventArgs e)
        {
            Post post = new Post();
            post.PosterEmail = Session["Email"].ToString();
            post.PostLocation = Session["TargetEmail"].ToString();
            post.Message = txtPost.Text;

            JavaScriptSerializer js = new JavaScriptSerializer();
            String jsonPost = js.Serialize(post);
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/CreatePost/");
            request.Method = "POST";
            request.ContentLength = jsonPost.Length;
            request.ContentType = "application/json";
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(jsonPost);
            writer.Flush();
            writer.Close();
            //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/GetMyFriends/");
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            js = new JavaScriptSerializer();
            Boolean returnValue = js.Deserialize<Boolean>(data);
            if (returnValue == true)
            {
                //Success
            }
            else
            {
                //Error
            }
        }
    }
}