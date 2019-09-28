using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Runtime.Serialization.Formatters.Binary;       //needed for BinaryFormatter
using System.IO;                                            //needed for the MemoryStream
using SocialNetworkingClassLibrary;

namespace TermProject
{
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            {
                Server.Transfer("Default.aspx", false);
            }
            else
            {
                if (!IsPostBack)
                {
                    DBConnect objDB = new DBConnect();
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_GetSerializablePreferences";
                    objCommand.Parameters.AddWithValue("@email", Session["Email"].ToString());
                    objCommand.Parameters.AddWithValue("@verificationToken", Session["VerificationToken"].ToString());
                    DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
                    // De-serialize the binary data to reconstruct the CreditCard object retrieved
                    // from the database
                    Byte[] byteArray = (Byte[])objDB.GetField("SerialPreferences", 0);
                    BinaryFormatter deSerializer = new BinaryFormatter();
                    MemoryStream memStream = new MemoryStream(byteArray);
                    memStream.Position = 0;
                    var preferences = (Preferences)deSerializer.Deserialize(memStream);
                    for (int i = 0; i < ddlAutoSignIn.Items.Count; i++)
                    {
                        ddlAutoSignIn.SelectedIndex = i;
                        if (ddlAutoSignIn.SelectedValue == preferences.AutoSignIn.ToString())
                        {
                            ddlAutoSignIn.SelectedIndex = i;
                            break;
                        }
                    }
                    for (int i = 0; i < ddlProfileView.Items.Count; i++)
                    {
                        ddlProfileView.SelectedIndex = i;
                        if (ddlProfileView.SelectedValue == preferences.Privacy.ToString())
                        {
                            ddlProfileView.SelectedIndex = i;
                            break;
                        }
                    }
                    for (int i = 0; i < ddlColorStyle.Items.Count; i++)
                    {
                        ddlColorStyle.SelectedIndex = i;
                        if (ddlColorStyle.SelectedValue == preferences.Theme.ToString())
                        {
                            ddlColorStyle.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
        }

        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdatePreferences";
            objCommand.Parameters.AddWithValue("@email", Session["Email"].ToString());
            objCommand.Parameters.AddWithValue("@privacy", ddlProfileView.SelectedValue);
            objCommand.Parameters.AddWithValue("@theme", ddlColorStyle.SelectedValue);
            objCommand.Parameters.AddWithValue("@autoSignIn", ddlAutoSignIn.SelectedValue);
            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
            }
            objDB = new DBConnect();
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateSerialPreferences";
            objCommand.Parameters.AddWithValue("@email", Session["Email"].ToString());
            Preferences serialPreferences = new Preferences();
            serialPreferences.AutoSignIn = Convert.ToInt32(ddlAutoSignIn.SelectedValue);
            serialPreferences.Email = Session["Email"].ToString();
            serialPreferences.Privacy = ddlProfileView.SelectedValue;
            serialPreferences.Theme = ddlColorStyle.SelectedValue;
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            Byte[] byteArray;
            serializer.Serialize(memStream, serialPreferences);
            byteArray = memStream.ToArray();
            objCommand.Parameters.AddWithValue("@serial", byteArray);
            objCommand.Parameters.AddWithValue("@verificationToken", Session["VerificationToken"].ToString());
            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
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
    }
}