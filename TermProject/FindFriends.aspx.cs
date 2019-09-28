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
    public partial class FindFriends : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            {
                Server.Transfer("Default.aspx", false);
            }
            else
            {
                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                string email = Session["Email"].ToString();
                WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/CheckSentFriendRequest/" + email);
                //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/CheckSentFriendRequest/" + Session["Email"].ToString());
                WebResponse response = request.GetResponse();
                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                // Deserialize a JSON string into a Team object.
                JavaScriptSerializer js = new JavaScriptSerializer();
                User[] users = js.Deserialize<User[]>(data);
                gvFriendRequested.DataSource = users;
                gvFriendRequested.DataBind();

                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/CheckReceivedFriendRequest/" + Session["Email"].ToString());
                //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/CheckReceivedFriendRequest/" + Session["Email"].ToString());
                response = request.GetResponse();
                // Read the data from the Web Response, which requires working with streams.
                theDataStream = response.GetResponseStream();
                reader = new StreamReader(theDataStream);
                data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                // Deserialize a JSON string into a Team object.
                js = new JavaScriptSerializer();
                users = js.Deserialize<User[]>(data);
                gvFriendRequests.DataSource = users;
                gvFriendRequests.DataBind();

                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/GetFriendsOfFriends/" + Session["Email"].ToString());
                //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/GetFriendsOfFriends/" + Session["Email"].ToString());
                response = request.GetResponse();
                // Read the data from the Web Response, which requires working with streams.
                theDataStream = response.GetResponseStream();
                reader = new StreamReader(theDataStream);
                data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                // Deserialize a JSON string into a Team object.
                js = new JavaScriptSerializer();
                users = js.Deserialize<User[]>(data);
                gvPeopleYouMayKnow.DataSource = users;
                gvPeopleYouMayKnow.DataBind();
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
            //Delete cookies
            Session.Clear();
            HttpCookie myCookie = Request.Cookies["Login"];
            if (myCookie != null)
            {
                myCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(myCookie);
                Response.Redirect("Default.aspx", false);
            }
            Server.Transfer("Default.aspx", false);
        }

        protected void btnFindName_Click(object sender, EventArgs e)
        {
            Session.Add("Action", 1);
            pnlFindFriendsName.Visible = true;
            pnlFindFriendsLocation.Visible = false;
            txtCity.Text = "";
            pnlFindFriendsOrganization.Visible = false;
            txtOrganization.Text = "";
        }
        protected void btnFindLocation_Click(object sender, EventArgs e)
        {
            Session.Add("Action", 2);
            pnlFindFriendsLocation.Visible = true;
            pnlFindFriendsName.Visible = false;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            pnlFindFriendsOrganization.Visible = false;
            txtOrganization.Text = "";
        }
        protected void btnFindOrganization_Click(object sender, EventArgs e)
        {
            Session.Add("Action", 3);
            pnlFindFriendsOrganization.Visible = true;
            pnlFindFriendsName.Visible = false;
            txtFirstName.Text = "";
            txtLastName.Text = "";
            pnlFindFriendsLocation.Visible = false;
            txtCity.Text = "";
        }
        protected void btnFindFriendsName_Click(object sender, EventArgs e)
        {
            //VALIDATE THE API REQUEST!!!//

            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/FindUserByName/" + Session["Email"].ToString() + "/" + txtFirstName.Text + "/" + txtLastName.Text);
            //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/FindUserByName/"+ Session["Email"].ToString() + "/" + txtFirstName.Text + "/" + txtLastName.Text);
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            User[] users = js.Deserialize<User[]>(data);
            gvResults.DataSource = users;
            gvResults.DataBind();
            lblFindFriendsErrorMessage.Text = "";

            //string lastName = txtLastName.Text;
            //string firstName = txtFirstName.Text;
            //DBConnect objDB = new DBConnect();
            //SqlCommand objCommand = new SqlCommand();
            //objCommand.CommandType = CommandType.StoredProcedure;
            //objCommand.CommandText = "TP_FindUserByName";
            //objCommand.Parameters.AddWithValue("@firstName", txtFirstName.Text);
            //objCommand.Parameters.AddWithValue("@lastName", txtLastName.Text);
            //DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            //gvResults.DataSource = ds;
            //gvResults.DataBind();
        }

        protected void btnFindFriendsLocation_Click(object sender, EventArgs e)
        {
            //VALIDATE THE API REQUEST!!!//

            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/FindUserByLocation/" + Session["Email"].ToString() + "/" + txtCity.Text + "/" + ddlState.SelectedValue);
            //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/FindUserByLocation/" + Session["Email"].ToString() + "/" + txtCity.Text + "/" + ddlState.SelectedValue);
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            User[] users = js.Deserialize<User[]>(data);
            gvResults.DataSource = users;
            gvResults.DataBind();
            lblFindFriendsErrorMessage.Text = "";


            //string state = ddlState.SelectedValue;
            //string city = txtCity.Text;
            //DBConnect objDB = new DBConnect();
            //SqlCommand objCommand = new SqlCommand();
            //objCommand.CommandType = CommandType.StoredProcedure;
            //objCommand.CommandText = "TP_FindUserByLocation";
            //objCommand.Parameters.AddWithValue("@state", state);
            //objCommand.Parameters.AddWithValue("@city", city);
            //DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            //gvResults.DataSource = ds;
            //gvResults.DataBind();
        }
        protected void btnFindFriendsOrganization_Click(object sender, EventArgs e)
        {
            //VALIDATE THE API REQUEST!!!//

            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/FindUserByOrganization/" + Session["Email"].ToString() + "/" + txtOrganization.Text);
            //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/FindUserByOrganization/" + Session["Email"].ToString() + "/" + txtOrganization.Text);
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            JavaScriptSerializer js = new JavaScriptSerializer();
            User[] users = js.Deserialize<User[]>(data);
            gvResults.DataSource = users;
            gvResults.DataBind();
            lblFindFriendsErrorMessage.Text = "";

            //string organization = txtOrganization.Text;
            //DBConnect objDB = new DBConnect();
            //SqlCommand objCommand = new SqlCommand();
            //objCommand.CommandType = CommandType.StoredProcedure;
            //objCommand.CommandText = "TP_FindUserByOrganization";
            //objCommand.Parameters.AddWithValue("@organization", organization);
            //DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            //gvResults.DataSource = ds;
            //gvResults.DataBind();
        }

        protected void gvResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "viewProfile")
            {
                int rowNum = int.Parse(e.CommandArgument.ToString());
                Session.Add("TargetEmail", gvResults.DataKeys[rowNum]["Email"].ToString());
                Server.Transfer("ViewProfile.aspx");
            }
            else if(e.CommandName == "sendRequest")
            {
                //VALIDATE THE API REQUEST!!!//

                // Retrieve and display the value contained in the
                // BoundField for ProductNumber (column index 0) of the row the button was clicked
                string friendEmail = gvResults.DataKeys[Convert.ToInt32(e.CommandArgument)]["Email"].ToString();
                string userEmail = Session["Email"].ToString();
                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/SendFriendRequest/" + userEmail + "/" + friendEmail);
                //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/SendFriendRequest/" + userEmail + "/" + friendEmail);
                request.Method = "POST";
                request.ContentLength = 0;
                WebResponse response = request.GetResponse();
                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Boolean success = js.Deserialize<Boolean>(data);
                if (success == true)
                {
                    lblFindFriendsErrorMessage.Text = "Friend request sent.";
                }
                else
                {
                    lblFindFriendsErrorMessage.Text = "Cannot send request.";
                }
                if (Convert.ToInt32(Session["Action"]) == 1)
                {
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/FindUserByName/" + Session["Email"].ToString() + "/" + txtFirstName.Text + "/" + txtLastName.Text);
                    //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/FindUserByName/" + Session["Email"].ToString() + "/" + txtFirstName.Text + "/" + txtLastName.Text);
                    response = request.GetResponse();
                    // Read the data from the Web Response, which requires working with streams.
                    theDataStream = response.GetResponseStream();
                    reader = new StreamReader(theDataStream);
                    data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    // Deserialize a JSON string into a Team object.
                    js = new JavaScriptSerializer();
                    User[] users = js.Deserialize<User[]>(data);
                    gvResults.DataSource = users;
                    gvResults.DataBind();
                    lblFindFriendsErrorMessage.Text = "";
                }
                if (Convert.ToInt32(Session["Action"]) == 2)
                {
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/FindUserByLocation/" + Session["Email"].ToString() + "/" + txtCity.Text + "/" + ddlState.SelectedValue);
                    //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/FindUserByLocation/" + Session["Email"].ToString() + "/" + txtCity.Text + "/" + ddlState.SelectedValue);
                    response = request.GetResponse();
                    // Read the data from the Web Response, which requires working with streams.
                    theDataStream = response.GetResponseStream();
                    reader = new StreamReader(theDataStream);
                    data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    // Deserialize a JSON string into a Team object.
                    js = new JavaScriptSerializer();
                    User[] users = js.Deserialize<User[]>(data);
                    gvResults.DataSource = users;
                    gvResults.DataBind();
                    lblFindFriendsErrorMessage.Text = "";
                }
                if (Convert.ToInt32(Session["Action"]) == 3)
                {
                    // Create an HTTP Web Request and get the HTTP Web Response from the server.
                    request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/FindUserByOrganization/" + Session["Email"].ToString() + "/" + txtOrganization.Text);
                    //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/FindUserByOrganization/" + Session["Email"].ToString() + "/" + txtOrganization.Text);
                    response = request.GetResponse();
                    // Read the data from the Web Response, which requires working with streams.
                    theDataStream = response.GetResponseStream();
                    reader = new StreamReader(theDataStream);
                    data = reader.ReadToEnd();
                    reader.Close();
                    response.Close();
                    // Deserialize a JSON string into a Team object.
                    js = new JavaScriptSerializer();
                    User[] users = js.Deserialize<User[]>(data);
                    gvResults.DataSource = users;
                    gvResults.DataBind();
                    lblFindFriendsErrorMessage.Text = "";
                }
            }
        }

        protected void gvPeopleYouMayKnow_SelectedIndexChanged(object sender, EventArgs e)
        {
            //VALIDATE THE API REQUEST!!!//

            // Retrieve and display the value contained in the
            // BoundField for ProductNumber (column index 0) of the row the button was clicked
            string friendEmail = gvPeopleYouMayKnow.DataKeys[gvPeopleYouMayKnow.SelectedIndex]["Email"].ToString();
            string userEmail = Session["Email"].ToString();
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/SendFriendRequest/" + userEmail + "/" + friendEmail);
            //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/SendFriendRequest/" + userEmail + "/" + friendEmail);
            request.Method = "POST";
            request.ContentLength = 0;
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Boolean success = js.Deserialize<Boolean>(data);
            if (success == true)
            {
                lblPeopleYouMayKnowErrorMessage.Text = "Friend request sent.";
            }
            else
            {
                lblPeopleYouMayKnowErrorMessage.Text = "Cannot send request.";
            }
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/GetFriendsOfFriends/" + Session["Email"].ToString());
            //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/SocialNetworkService/GetFriendsOfFriends/" + Session["Email"].ToString());
            response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            theDataStream = response.GetResponseStream();
            reader = new StreamReader(theDataStream);
            data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            // Deserialize a JSON string into a Team object.
            js = new JavaScriptSerializer();
            User[] users = js.Deserialize<User[]>(data);
            gvPeopleYouMayKnow.DataSource = users;
            gvPeopleYouMayKnow.DataBind();

        }

        protected void gvFriendRequested_SelectedIndexChanged(object sender, EventArgs e)
        {
            string friendEmail = gvFriendRequested.DataKeys[gvFriendRequested.SelectedIndex]["Email"].ToString();
            string userEmail = Session["Email"].ToString();
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/DenyFriendRequest/" + userEmail + "/" + friendEmail);
            //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/DenyFriendRequest/" + userEmail + "/" + friendEmail);
            request.Method = "POST";
            request.ContentLength = 0;
            WebResponse response = request.GetResponse();
            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();
            reader.Close();
            response.Close();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Boolean success = js.Deserialize<Boolean>(data);
            if (success == true)
            {
                lblFriendRequestedErrorMessage.Text = "Friend request denied.";
            }
            else
            {
                lblFriendRequestedErrorMessage.Text = "Cannot deny friend request.";
            }
        }
        protected void gvFriendRequests_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "viewProfile")
            {
                int rowNum = int.Parse(e.CommandArgument.ToString());
                Session.Add("TargetEmail", gvResults.DataKeys[rowNum]["Email"].ToString());
                Server.Transfer("ViewProfile.aspx");
            }
            else if(e.CommandName == "acceptRequest")
            {
                //VALIDATE THE API REQUEST!!!//

                // Retrieve and display the value contained in the
                // BoundField for ProductNumber (column index 0) of the row the button was clicked
                string friendEmail = gvFriendRequests.DataKeys[Convert.ToInt32(e.CommandArgument)]["Email"].ToString();
                string userEmail = Session["Email"].ToString();
                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/AcceptFriendRequest/" + userEmail + "/" + friendEmail);
                //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/AcceptFriendRequest/" + userEmail + "/" + friendEmail);
                request.Method = "POST";
                request.ContentLength = 0;
                WebResponse response = request.GetResponse();
                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Boolean success = js.Deserialize<Boolean>(data);
                if (success == true)
                {
                    lblFriendRequestsErrorMessage.Text = "Friend request accepted.";
                }
                else
                {
                    lblFriendRequestsErrorMessage.Text = "Cannot accept friend request.";
                }
            }
            else if(e.CommandName == "denyRequest")
            {
                string senderEmail = gvFriendRequests.DataKeys[Convert.ToInt32(e.CommandArgument)]["Email"].ToString();
                string recieverEmail = Session["Email"].ToString();
                // Create an HTTP Web Request and get the HTTP Web Response from the server.
                WebRequest request = WebRequest.Create("http://localhost:35664/api/SocialNetworkService/DenyFriendRequest/" + senderEmail + "/" + recieverEmail);
                //WebRequest request = WebRequest.Create("http://cis-iis2.temple.edu/fall2018/cis3342_tug26951/TermProjectWS/api/DenyFriendRequest/" + userEmail + "/" + friendEmail);
                request.Method = "POST";
                request.ContentLength = 0;
                WebResponse response = request.GetResponse();
                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();
                reader.Close();
                response.Close();
                JavaScriptSerializer js = new JavaScriptSerializer();
                Boolean success = js.Deserialize<Boolean>(data);
                if (success == true)
                {
                    lblFriendRequestedErrorMessage.Text = "Friend request denied.";
                }
                else
                {
                    lblFriendRequestedErrorMessage.Text = "Cannot deny friend request.";
                }
            }
        }
    }
}