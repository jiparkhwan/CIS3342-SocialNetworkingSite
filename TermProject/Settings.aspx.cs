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
    public partial class Settings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Email"] == null)
            {
                Response.Redirect("Default.aspx");
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
                Response.Write("<script>alert('Data updated successfully')</script>");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //Delete cookies
            HttpCookie myCookie = Request.Cookies["Login"];
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
            Response.Redirect("Default.aspx");
        }
    }
}