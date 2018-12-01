using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
namespace TermProject
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("AccountRegistration.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_LoginAccount";
                objCommand.Parameters.AddWithValue("@email", txtLoginEmail.Text);
                objCommand.Parameters.AddWithValue("@password", txtLoginPassword.Text);
                DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
                if (ds.Tables[0].Rows[0]["Email"].ToString() == txtLoginEmail.Text && ds.Tables[0].Rows[0]["Password"].ToString() == txtLoginPassword.Text)
                {
                    if (chkRememberMe.Checked)
                    {
                        Session.Add("Email", txtLoginEmail.Text);
                        HttpCookie myCookie = new HttpCookie("Login");
                        myCookie.Values["Email"] = txtLoginEmail.Text;
                        myCookie.Values["Password"] = txtLoginPassword.Text;
                        myCookie.Expires = DateTime.Now.AddDays(1d);
                        Response.Cookies.Add(myCookie);
                        Response.Redirect("Profile.aspx");
                    }
                    else
                    {
                        Session.Add("email", txtLoginEmail.Text);
                        Response.Redirect("Profile.aspx");
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }
    }
}