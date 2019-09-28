using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SocialNetworkingClassLibrary;
 namespace TermProject
{
    public partial class AccountRegistration : System.Web.UI.Page
    {
        StoredProcedures procedures = new StoredProcedures();
         protected void Page_Load(object sender, EventArgs e)
        {
         }
         protected void btnSubmit_Click(object sender, EventArgs e)
        {
             bool flag = true;
            string email = "";
            string firstName = "";
            string lastName = "";
            string phoneNumber = "";
            string address = "";
            string city = "";
            string state = "";
            string zip = "";
            string password = "";
            string question1 = ddlSecurityQuestion1.SelectedValue;
            string answer1 = "";
            string question2 = ddlSecurityQuestion2.SelectedValue;
            string answer2 = "";
            string question3 = ddlSecurityQuestion3.SelectedValue;
            string answer3 = "";
            lblMessage.Text = "";
             if (String.IsNullOrWhiteSpace(txtRegisterEmail.Text))
            {
                lblMessage.Text += "Please fill out your e-mail address. </br>";
                flag = false;
            }
            else
            {
                email = txtRegisterEmail.Text;
            }
            if (String.IsNullOrWhiteSpace(txtRegisterPassword.Text))
            {
                lblMessage.Text += "Please fill out your password. </br>";
                flag = false;
            }
            else
            {
                password = txtRegisterPassword.Text;
            }
            if (String.IsNullOrWhiteSpace(txtRegisterFirstName.Text))
            {
                lblMessage.Text += "Please fill out your first name. </br>";
                flag = false;
            }
            else if (txtRegisterFirstName.Text.All(Char.IsLetter) == false)
            {
                lblMessage.Text += "Please enter a valid first name. </br>";
            }
            else
            {
                firstName = txtRegisterFirstName.Text;
            }
             if (String.IsNullOrWhiteSpace(txtRegisterLastName.Text))
            {
                lblMessage.Text += "Please fill out your last name. </br>";
                flag = false;
            }
            else if (txtRegisterLastName.Text.All(Char.IsLetter) == false)
            {
                lblMessage.Text += "Please enter a valid last name. </br>";
                flag = false;
            }
            else
            {
                lastName = txtRegisterLastName.Text;
            }
             if (String.IsNullOrWhiteSpace(txtRegisterAddress.Text))
            {
                lblMessage.Text += "Please fill out your address. </br>";
                flag = false;
            }
             else
            {
                address += txtRegisterAddress.Text;
            }
             if (String.IsNullOrWhiteSpace(txtRegisterCity.Text))
            {
                lblMessage.Text += "Please fill out your city. </br>";
                flag = false;
            }
            else
            {
                city = txtRegisterCity.Text;
            }
             if (String.IsNullOrWhiteSpace(txtRegisterState.Text))
            {
                lblMessage.Text += "Please fill out your state. </br>";
                flag = false;
            }
            else if (txtRegisterState.Text.Length != 2)
            {
                lblMessage.Text += "Please enter a valid state. </br>";
                flag = false;
            }
            else
            {
                state = txtRegisterState.Text;
            }
             if (String.IsNullOrWhiteSpace(txtRegisterZipCode.Text))
            {
                lblMessage.Text += "Please fill out your zip code. </br>";
                flag = false;
            }
            else if (txtRegisterZipCode.Text.Length != 5)
            {
                lblMessage.Text += "Zip code is not at valid length. </br>";
                flag = false;
            }
            else if (txtRegisterZipCode.Text.All(char.IsDigit) == false)
            {
                lblMessage.Text += "Please enter a valid zip code. </br>";
                flag = false;
            }
            else
            {
                zip = txtRegisterZipCode.Text;
            }
             if (String.IsNullOrWhiteSpace(txtRegisterPhoneNumber.Text))
            {
                lblMessage.Text += "Please fill out your phone number. </br>";
                flag = false;
            }
            else if (txtRegisterPhoneNumber.Text.Length != 10)
            {
                lblMessage.Text += "Phone number is not at valid length. </br>";
                flag = false;
            }
            else if (txtRegisterPhoneNumber.Text.All(Char.IsDigit) == false)
            {
                lblMessage.Text += "Please enter a valid phone number. </br>";
                flag = false;
            }
            else
            {
                phoneNumber = txtRegisterPhoneNumber.Text;
            }
             //Security Question validations
            if (String.IsNullOrWhiteSpace(txtSecurityAnswer1.Text))
            {
                lblMessage.Text += "Please fill out the first security question. </br>";
                flag = false;
            }
            else
            {
                answer1 = txtSecurityAnswer1.Text;
            }
            if (String.IsNullOrWhiteSpace(txtSecurityAnswer2.Text))
            {
                lblMessage.Text += "Please fill out the second security question. </br>";
                flag = false;
            }
            else
            {
                answer2 = txtSecurityAnswer2.Text;
            }
            if (String.IsNullOrWhiteSpace(txtSecurityAnswer3.Text))
            {
                lblMessage.Text += "Please fill out the third security question. </br>";
                flag = false;
            }
            else
            {
                answer3 = txtSecurityAnswer3.Text;
            }
             if (flag == true)
            {
                if (procedures.AddUser(email, firstName, lastName, phoneNumber, address, city, state, zip, password) && procedures.AddSecurityQuestions(email, question1, answer1, question2, answer2, question3, answer3) == true)
                {
                    lblMessage.Text += "New user added to OwlSpace! Hit OwlSpace on the top left to return home! </br>";
                    procedures.AddPreference(email);
                    Preferences serialPreferences = new Preferences();
                    serialPreferences.Email = email;
                    serialPreferences.AutoSignIn = 1;
                    serialPreferences.Privacy = "Everyone";
                    serialPreferences.Theme = "Normal";
                    procedures.AddSerialPreference(serialPreferences);
                }
                else
                {
                    lblMessage.Text += "There was an error creating new user. </br>";
                }
             }
        }
    }
}