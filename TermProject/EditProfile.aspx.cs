using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialNetworkingClassLibrary;
namespace TermProject
{
    public partial class EditProfile : System.Web.UI.Page
    {
        StoredProcedures procedures = new StoredProcedures();
        User user = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            {
                Server.Transfer("Default.aspx", false);
            }

            if (!IsPostBack)
            {
                //Stored Procedure to get user object
                //Fills textbox with user data to edit

                DataSet ds = procedures.GetUserByEmail(Session["Email"].ToString());
                user.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                user.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                user.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                user.State = ds.Tables[0].Rows[0]["State"].ToString();
                user.City = ds.Tables[0].Rows[0]["City"].ToString();
                user.Zip = ds.Tables[0].Rows[0]["Zip"].ToString();
                user.PhoneNumber = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                user.Organization = ds.Tables[0].Rows[0]["Organization"].ToString();

                txtEditFirstName.Text = user.FirstName;
                txtEditLastName.Text = user.LastName;
                txtEditAddress.Text = user.Address;
                txtEditState.Text = user.State;
                txtEditCity.Text = user.City;
                txtEditZipCode.Text = user.Zip;
                txtEditPhoneNumber.Text = user.PhoneNumber;
                txtEditOrganization.Text = user.Organization;

                //Should we change the way profile picture is edited?
                //Because this way is just uploading a new image for them to use as their profile pic.
                //Shouldn't we have it so that they can choose a different image from their gallary?
                //Maybe we can make them choose their profile picture when they're viewing their gallary...
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Checking if user uploads jpeg file    

            string photoURL = "images/placeholder.jpg";
            if (fupProfilePhoto.HasFile)
            {
                try
                {
                    if (fupProfilePhoto.PostedFile.ContentLength < 512000)
                    {
                        //Need to think of another photo name because we can't use email address
                        string fileName = Session["Email"].ToString();
                        string extension = Path.GetExtension(fupProfilePhoto.PostedFile.FileName);
                        fupProfilePhoto.SaveAs(Server.MapPath("~/Storage//") + fileName + fupProfilePhoto.PostedFile.FileName + extension);
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
            if (procedures.EditUser(Session["Email"].ToString(), photoURL, txtEditFirstName.Text, txtEditLastName.Text, txtEditPhoneNumber.Text, txtEditAddress.Text, txtEditCity.Text, txtEditState.Text, txtEditZipCode.Text, txtEditOrganization.Text) == true)
            {
                lblMessage.Text = "Profile successfully updated.";
            }
            else
            {
                lblMessage.Text = "Unable to update profile.";
            }
            //Validation for changed in user profile
            //Stored Procedures to update the database with new user information 
        }
    }
}