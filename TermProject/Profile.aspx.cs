using Newtonsoft.Json;
using SocialNetworkingClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;

namespace TermProject
{
    public partial class Profile : System.Web.UI.Page
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
                    string password = Session["Password"].ToString();
                    WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/GetMyProfile/" + email + "/" + password);
                    //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/GetMyProfile/" + email + "/" + password);
                    WebResponse response = request.GetResponse();
                    // Read the data from the Web Response, which requires working with streams.
                    Stream theDataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(theDataStream);
                    String data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    // Deserialize a JSON string into a Team object.
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    SocialNetworkingClassLibrary.Profile myProfile = js.Deserialize<SocialNetworkingClassLibrary.Profile>(data);
                    profileImageDiv.InnerHtml = "<br /><img src= \"" + myProfile.User.ProfilePhotoUrl + "\" style=\"width:100%; height:200px;\"></img>";
                    profileInformationDiv.InnerHtml = "<br /><br /><br /><br /><h2>" + myProfile.User.FirstName + " " + myProfile.User.LastName + "</h2>";

                    profileContactInformationDiv.InnerHtml = "<h2>Contact Information</h2>";
                    profileContactInformationDiv.InnerHtml += "<p>Organization: " + myProfile.User.Organization + "</p>";
                    profileContactInformationDiv.InnerHtml += "<p>Address: " + myProfile.User.Address + " " + myProfile.User.City + ", " + myProfile.User.State + " " + myProfile.User.Zip + "</p>";
                    profileContactInformationDiv.InnerHtml += "<p>Phone Number: " + myProfile.User.PhoneNumber;
                    gvFriends.DataSource = myProfile.Friends;
                    gvFriends.DataBind();
                    gvPhotos.DataSource = myProfile.Photos;
                    gvPhotos.DataBind();
                    //imgPosterIcon.ImageUrl = ImageURL;
                    //lblPosterName.Text = posterName;
                    //lblTime.Text = Time;
                    //lblPost.Text = Post;

                    DataSet ds = new DataSet();
                    ds = procedures.GetProfilePosts(Session["Email"].ToString());
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
        protected void btnSettings_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("Settings.aspx", false);
        }

        protected void btnMessenger_Click(object sender, EventArgs e)
        {
            Server.Transfer("Messenger.aspx", false);
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
            post.PostLocation = Session["Email"].ToString();
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
        protected void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            //Checking if user uploads jpeg file    

            string photoURL = "images/placeholder.jpg";
            if (fupAddPhoto.HasFile)
            {
                try
                {
                    if (fupAddPhoto.PostedFile.ContentLength < 512000)
                    {
                        //Need to think of another photo name because we can't use email address
                        string fileName = Session["Email"].ToString();
                        string extension = Path.GetExtension(fupAddPhoto.PostedFile.FileName);
                        fupAddPhoto.SaveAs(Server.MapPath("~/Storage//") + fileName + fupAddPhoto.PostedFile.FileName + extension);
                        lblMessage.Text = "Photo uploaded!";
                        photoURL = "/Storage/" + fileName + extension;
                    }
                    else
                        lblMessage.Text = "The file has to be less than 500 kb!";

                }
                catch (Exception ex)
                {
                    lblMessage.Text = "The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            if (procedures.AddPhoto(Session["Email"].ToString(), photoURL, txtPhotoDescription.Text, Convert.ToInt32(Session["VerificationToken"])) == true)
            {
                lblMessage.Text = "Photo successfully updated.";
            }
            else
            {
                lblMessage.Text = "Unable to add photo.";
            }
            //Validation for changed in user profile
            //Stored Procedures to update the database with new user information 
        }
    }
}