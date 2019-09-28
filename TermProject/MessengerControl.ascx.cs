using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialNetworkingClassLibrary;
using System.Data;

namespace TermProject
{
    public partial class MessengerControl : System.Web.UI.UserControl
    {
        StoredProcedures procedures = new StoredProcedures();
        Messaging messenger = new Messaging();
        public string userEmail = "";
        public string friendEmail = "tester@temple.edu";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet fs = procedures.FindAllFriends(Session["Email"].ToString());
                ddlFriends.DataTextField = "FirstName";
                ddlFriends.DataValueField = "FriendEmail";
                ddlFriends.DataSource = fs;
                ddlFriends.DataBind();

                friendEmail = ddlFriends.SelectedValue;
            }

            try
            {
                messenger.ConversationID = Convert.ToInt32(gvMessenger.DataKeys[0]["ConversationID"]);
            }
            catch
            {

            }
            //Create or Load messages into messenger from session e-mail and friend email
        }
        public String UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }

        public String FriendEmail
        {
            get { return friendEmail; }
            set { friendEmail = value; }
        }

        public override void DataBind()
        {
            DataSet ds = procedures.GetMessages(userEmail, friendEmail);
            gvMessenger.DataSource = ds;
            gvMessenger.DataBind();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            //Stored procedure to send message.
            string time = DateTime.Now.ToString("HH:mm:ss");
            string message = txtMessage.Text;
            txtMessage.Text = string.Empty;
            procedures.AddMessage(messenger.ConversationID, message, userEmail, time);
            DataBind();

        }

        protected void gvMessenger_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Store Procedure to delete text at row
            int messageID = Convert.ToInt32(gvMessenger.DataKeys[e.RowIndex]["MessageID"]);
            procedures.DeleteMessage(messageID);
            DataBind();
        }

        protected void ddlFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            friendEmail = ddlFriends.SelectedValue.ToString();
            //txtMessage.Text = friendEmail;
            DataBind();
            DataSet ds = procedures.GetMessages(userEmail, friendEmail);
            gvMessenger.DataSource = ds;
            gvMessenger.DataBind();

            try
            {
                messenger.ConversationID = Convert.ToInt32(gvMessenger.DataKeys[0]["ConversationID"]);
            }
            catch
            {

            }
        }
    }
}