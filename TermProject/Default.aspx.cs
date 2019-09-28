using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Security.Cryptography;     // needed for the encryption classes
using System.IO;                        // needed for the MemoryStream
using System.Text;                      // needed for the UTF8 encoding
using System.Net;                       // needed for the cookie
namespace TermProject
{
    public partial class Index : System.Web.UI.Page
    {
        private Byte[] key = { 250, 101, 18, 76, 45, 135, 207, 118, 4, 171, 3, 168, 202, 241, 37, 199 };

        private Byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 252, 112, 79, 32, 114, 156 };
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Login"] != null)
                {
                    HttpCookie myCookie = Request.Cookies["Login"];
                    txtLoginEmail.Text = myCookie["Email"];
                    String encryptedPassword = myCookie.Values["Password"];
                    //txtLoginPassword.Text = myCookie["Password"];

                    Byte[] encryptedPasswordBytes = Convert.FromBase64String(encryptedPassword);
                    Byte[] textBytes;
                    String plainTextPassword;
                    UTF8Encoding encoder = new UTF8Encoding();

                    // Perform Decryption
                    //-------------------
                    // Create an instances of the decryption algorithm (Rinjdael AES) for the encryption to perform,
                    // a memory stream used to store the decrypted data temporarily, and
                    // a crypto stream that performs the decryption algorithm.
                    RijndaelManaged rmEncryption = new RijndaelManaged();
                    MemoryStream myMemoryStream = new MemoryStream();
                    CryptoStream myDecryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateDecryptor(key, vector), CryptoStreamMode.Write);

                    // Use the crypto stream to perform the decryption on the encrypted data in the byte array.
                    myDecryptionStream.Write(encryptedPasswordBytes, 0, encryptedPasswordBytes.Length);
                    myDecryptionStream.FlushFinalBlock();

                    // Retrieve the decrypted data from the memory stream, and write it to a separate byte array.
                    myMemoryStream.Position = 0;
                    textBytes = new Byte[myMemoryStream.Length];
                    myMemoryStream.Read(textBytes, 0, textBytes.Length);

                    // Close all the streams.
                    myDecryptionStream.Close();
                    myMemoryStream.Close();

                    // Convert the bytes to a string and display it.
                    plainTextPassword = encoder.GetString(textBytes);
                    txtLoginPassword.Text = plainTextPassword;

                    DBConnect objDB = new DBConnect();
                    SqlCommand objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_CheckAutoSignIn";
                    objCommand.Parameters.AddWithValue("@email", myCookie["Email"]);
                    DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
                    if (Convert.ToInt32(ds.Tables[0].Rows[0]["AutoSignIn"].ToString()) == 1)
                    {
                        Session.Add("Email", txtLoginEmail.Text);
                        Session.Add("Password", plainTextPassword);
                        //Session.Add("Password", txtLoginPassword.Text);
                        Session.Add("VerificationToken", myCookie["VerificationToken"]);
                        Server.Transfer("Profile.aspx", false);
                    }
                    else
                    {
                        Session.Add("Email", txtLoginEmail.Text);
                        Session.Add("Password", plainTextPassword);
                        //Session.Add("Password", txtLoginPassword.Text);
                        Session.Add("VerificationToken", myCookie["VerificationToken"]);
                        txtLoginEmail.Text = myCookie["Email"];
                        txtLoginPassword.Text = plainTextPassword;
                        //txtLoginPassword.Text = myCookie["Password"];
                    }
                }
            }
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Server.Transfer("AccountRegistration.aspx", false);
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
                        Session.Add("Password", txtLoginPassword.Text);
                        Session.Add("VerificationToken", ds.Tables[0].Rows[0]["VerificationToken"].ToString());
                        string email = txtLoginEmail.Text;
                        string plainTextPassword = txtLoginPassword.Text;
                        string encryptedPassword;
                        string verificationToken = Session["VerificationToken"].ToString();
                        UTF8Encoding encoder = new UTF8Encoding();      // used to convert bytes to characters, and back
                        Byte[] textBytes;                               // stores the plain text data as bytes

                        // Perform Encryption
                        //-------------------
                        // Convert a string to a byte array, which will be used in the encryption process.
                        textBytes = encoder.GetBytes(plainTextPassword);

                        // Create an instances of the encryption algorithm (Rinjdael AES) for the encryption to perform,
                        // a memory stream used to store the encrypted data temporarily, and
                        // a crypto stream that performs the encryption algorithm.

                        RijndaelManaged rmEncryption = new RijndaelManaged();
                        MemoryStream myMemoryStream = new MemoryStream();
                        CryptoStream myEncryptionStream = new CryptoStream(myMemoryStream, rmEncryption.CreateEncryptor(key, vector), CryptoStreamMode.Write);

                        // Use the crypto stream to perform the encryption on the plain text byte array.
                        myEncryptionStream.Write(textBytes, 0, textBytes.Length);
                        myEncryptionStream.FlushFinalBlock();

                        // Retrieve the encrypted data from the memory stream, and write it to a separate byte array.
                        myMemoryStream.Position = 0;
                        Byte[] encryptedBytes = new Byte[myMemoryStream.Length];
                        myMemoryStream.Read(encryptedBytes, 0, encryptedBytes.Length);

                        // Close all the streams.
                        myEncryptionStream.Close();
                        myMemoryStream.Close();

                        // Convert the bytes to a string and display it.
                        encryptedPassword = Convert.ToBase64String(encryptedBytes);

                        // Write encrypted password to a cookie
                        HttpCookie myCookie = new HttpCookie("Login");
                        myCookie.Values["Email"] = txtLoginEmail.Text;
                        myCookie.Values["Password"] = encryptedPassword;
                        //myCookie.Values["Password"] = txtLoginPassword.txt;
                        myCookie.Values["VerificationToken"] = Session["VerificationToken"].ToString();
                        myCookie.Expires = DateTime.Now.AddDays(1d);
                        Response.Cookies.Add(myCookie);
                        Server.Transfer("Profile.aspx", false);
                    }
                    else
                    {
                        Session.Add("Email", txtLoginEmail.Text);
                        Session.Add("Password", txtLoginPassword.Text);
                        Session.Add("VerificationToken", ds.Tables[0].Rows[0]["VerificationToken"].ToString());
                        Server.Transfer("Profile.aspx", false);
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