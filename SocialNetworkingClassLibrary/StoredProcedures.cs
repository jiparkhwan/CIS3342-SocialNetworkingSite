using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization.Formatters.Binary;       //needed for BinaryFormatter
using System.IO;                                            //needed for the MemoryStream

namespace SocialNetworkingClassLibrary
{
    public class StoredProcedures
    {
        public Boolean AddUser(string Email, string FirstName, string LastName, string PhoneNumber, string Address, string City, string State, string Zip, string Password)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddUser";
            SqlParameter emailParameter = new SqlParameter("@Email", Email);
            emailParameter.Direction = ParameterDirection.Input;
            emailParameter.SqlDbType = SqlDbType.VarChar;
            emailParameter.Size = 50;
            SqlParameter firstNameParamter = new SqlParameter("@FirstName", FirstName);
            firstNameParamter.Direction = ParameterDirection.Input;
            firstNameParamter.SqlDbType = SqlDbType.VarChar;
            firstNameParamter.Size = 50;
            SqlParameter lastNameParameter = new SqlParameter("@LastName", LastName);
            lastNameParameter.Direction = ParameterDirection.Input;
            lastNameParameter.SqlDbType = SqlDbType.VarChar;
            lastNameParameter.Size = 50;
            SqlParameter phoneNumberParamter = new SqlParameter("@PhoneNumber", PhoneNumber);
            phoneNumberParamter.Direction = ParameterDirection.Input;
            phoneNumberParamter.SqlDbType = SqlDbType.VarChar;
            phoneNumberParamter.Size = 10;
            SqlParameter addressParameter = new SqlParameter("@Address", Address);
            addressParameter.Direction = ParameterDirection.Input;
            addressParameter.SqlDbType = SqlDbType.VarChar;
            addressParameter.Size = 50;
            SqlParameter cityParameter = new SqlParameter("@City", City);
            cityParameter.Direction = ParameterDirection.Input;
            cityParameter.SqlDbType = SqlDbType.VarChar;
            cityParameter.Size = 50;
            SqlParameter stateParameter = new SqlParameter("@State", State);
            stateParameter.Direction = ParameterDirection.Input;
            stateParameter.SqlDbType = SqlDbType.VarChar;
            stateParameter.Size = 2;
            SqlParameter zipParameter = new SqlParameter("@Zip", Zip);
            zipParameter.Direction = ParameterDirection.Input;
            zipParameter.SqlDbType = SqlDbType.VarChar;
            zipParameter.Size = 5;
            SqlParameter passwordParameter = new SqlParameter("@Password", Password);
            passwordParameter.Direction = ParameterDirection.Input;
            passwordParameter.SqlDbType = SqlDbType.VarChar;
            passwordParameter.Size = 50;
            objCommand.Parameters.Add(emailParameter);
            objCommand.Parameters.Add(firstNameParamter);
            objCommand.Parameters.Add(lastNameParameter);
            objCommand.Parameters.Add(phoneNumberParamter);
            objCommand.Parameters.Add(addressParameter);
            objCommand.Parameters.Add(cityParameter);
            objCommand.Parameters.Add(stateParameter);
            objCommand.Parameters.Add(zipParameter);
            objCommand.Parameters.Add(passwordParameter);
            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean DeleteMessage(int MessageID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DeleteMessage";

            SqlParameter messageParameter = new SqlParameter("@MessageID", MessageID);
            messageParameter.Direction = ParameterDirection.Input;
            messageParameter.SqlDbType = SqlDbType.Int;

            objCommand.Parameters.Add(messageParameter);

            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
                return true;
            }
            return false;
        }

        public DataSet GetUserByEmail(string email)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindUserByEmail";
            objCommand.Parameters.AddWithValue("@email", email);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public DataSet FindAllFriends(string email)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindAllFriends";
            objCommand.Parameters.AddWithValue("@email", email);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public DataSet GetSecurityQuestions(string email)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetSecurityQuestions";
            objCommand.Parameters.AddWithValue("@email", email);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public DataSet GetPassword(string email)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetPassword";
            objCommand.Parameters.AddWithValue("@Email", email);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public DataSet GetMessages(string userEmail, string friendEmail)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetMessages";
            objCommand.Parameters.AddWithValue("@UserEmail", userEmail);
            objCommand.Parameters.AddWithValue("@FriendEmail", friendEmail);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public Boolean Login(string Email, string Password)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_LoginAccount";
            objCommand.Parameters.AddWithValue("@email", Email);
            objCommand.Parameters.AddWithValue("@password", Password);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            if (ds.ToString() != "")
            {
                return true;
            }
            return false;
        }

        public Boolean AddPreference(string Email)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddPreference";
            SqlParameter emailParameter = new SqlParameter("@Email", Email);
            emailParameter.Direction = ParameterDirection.Input;
            emailParameter.SqlDbType = SqlDbType.VarChar;
            emailParameter.Size = 50;
            objCommand.Parameters.Add(emailParameter);
            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
                return true;
            }
            return false;
        }
        
        public DataSet GetProfilePosts(string postLocation)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetProfilePosts";
            objCommand.Parameters.AddWithValue("@PostLocation", postLocation);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public DataSet GetNewsFeedPosts(string UserEmail, int @VerificationToken)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "[TP_GetNewsFeedPosts]";
            objCommand.Parameters.AddWithValue("@UserEmail", UserEmail);
            objCommand.Parameters.AddWithValue("@VerificationToken", VerificationToken);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            return ds;
        }

        public Boolean AddSerialPreference(Preferences serialPreference)
        {
            // Serialize the Preference object
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            Byte[] byteArray;
            serializer.Serialize(memStream, serialPreference);
            byteArray = memStream.ToArray();

            // Update the account to store the serialized object (binary data) in the database
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddSerialPreferences";
            objCommand.Parameters.AddWithValue("@email", serialPreference.Email);
            objCommand.Parameters.AddWithValue("@serial", byteArray);
            int retVal = objDB.DoUpdateUsingCmdObj(objCommand);

            // Check to see whether the update was successful
            if (retVal > 0) { 
                return true;
            }
            else { 
                return false;
            }
        }

        public Boolean AddMessage(int ConversationID, string Message, string Email, string Time)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddMessage";
            SqlParameter conversationParameter = new SqlParameter("@ConversationID", ConversationID);
            conversationParameter.Direction = ParameterDirection.Input;
            conversationParameter.SqlDbType = SqlDbType.Int;
            SqlParameter mesageParameter = new SqlParameter("@Message", Message);
            mesageParameter.Direction = ParameterDirection.Input;
            mesageParameter.SqlDbType = SqlDbType.VarChar;
            mesageParameter.Size = 100;
            SqlParameter emailParameter = new SqlParameter("@Email", Email);
            emailParameter.Direction = ParameterDirection.Input;
            emailParameter.SqlDbType = SqlDbType.VarChar;
            emailParameter.Size = 50;
            SqlParameter timeParameter = new SqlParameter("@Time", Time);
            timeParameter.Direction = ParameterDirection.Input;
            timeParameter.SqlDbType = SqlDbType.VarChar;
            timeParameter.Size = 50;
            objCommand.Parameters.Add(conversationParameter);
            objCommand.Parameters.Add(mesageParameter);
            objCommand.Parameters.Add(emailParameter);
            objCommand.Parameters.Add(timeParameter);
            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean AddPhoto(string Email, string PhotoURL, string Description, int VerificationToken)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddPhoto";
            SqlParameter conversationParameter = new SqlParameter("@email", Email);
            conversationParameter.Direction = ParameterDirection.Input;
            conversationParameter.SqlDbType = SqlDbType.VarChar;
            conversationParameter.Size = 50;
            SqlParameter mesageParameter = new SqlParameter("@photoURL", PhotoURL);
            mesageParameter.Direction = ParameterDirection.Input;
            mesageParameter.SqlDbType = SqlDbType.VarChar;
            mesageParameter.Size = 50;
            SqlParameter emailParameter = new SqlParameter("@description", Description);
            emailParameter.Direction = ParameterDirection.Input;
            emailParameter.SqlDbType = SqlDbType.VarChar;
            emailParameter.Size = 100;
            SqlParameter timeParameter = new SqlParameter("@verificationToken", VerificationToken);
            timeParameter.Direction = ParameterDirection.Input;
            timeParameter.SqlDbType = SqlDbType.Int;
            objCommand.Parameters.Add(conversationParameter);
            objCommand.Parameters.Add(mesageParameter);
            objCommand.Parameters.Add(emailParameter);
            objCommand.Parameters.Add(timeParameter);
            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean AddSecurityQuestions(string Email, string Question1, string Answer1, string Question2, string Answer2, string Question3, string Answer3)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AddSecurityQuestion";
            SqlParameter emailParameter = new SqlParameter("@Email", Email);
            emailParameter.Direction = ParameterDirection.Input;
            emailParameter.SqlDbType = SqlDbType.VarChar;
            emailParameter.Size = 50;
            SqlParameter questionOneParamter = new SqlParameter("@Question1", Question1);
            questionOneParamter.Direction = ParameterDirection.Input;
            questionOneParamter.SqlDbType = SqlDbType.VarChar;
            questionOneParamter.Size = 100;
            SqlParameter answerOneParameter = new SqlParameter("@Answer1", Answer1);
            answerOneParameter.Direction = ParameterDirection.Input;
            answerOneParameter.SqlDbType = SqlDbType.VarChar;
            answerOneParameter.Size = 50;
            SqlParameter questionTwoParamter = new SqlParameter("@Question2", Question2);
            questionTwoParamter.Direction = ParameterDirection.Input;
            questionTwoParamter.SqlDbType = SqlDbType.VarChar;
            questionTwoParamter.Size = 100;
            SqlParameter answerTwoParameter = new SqlParameter("@Answer2", Answer2);
            answerTwoParameter.Direction = ParameterDirection.Input;
            answerTwoParameter.SqlDbType = SqlDbType.VarChar;
            answerTwoParameter.Size = 50;
            SqlParameter questionThreeParameter = new SqlParameter("@Question3", Question3);
            questionThreeParameter.Direction = ParameterDirection.Input;
            questionThreeParameter.SqlDbType = SqlDbType.VarChar;
            questionThreeParameter.Size = 100;
            SqlParameter answerThreeParameter = new SqlParameter("@Answer3", Answer3);
            answerThreeParameter.Direction = ParameterDirection.Input;
            answerThreeParameter.SqlDbType = SqlDbType.VarChar;
            answerThreeParameter.Size = 50;
            objCommand.Parameters.Add(emailParameter);
            objCommand.Parameters.Add(questionOneParamter);
            objCommand.Parameters.Add(answerOneParameter);
            objCommand.Parameters.Add(questionTwoParamter);
            objCommand.Parameters.Add(answerTwoParameter);
            objCommand.Parameters.Add(questionThreeParameter);
            objCommand.Parameters.Add(answerThreeParameter);
            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
                return true;
            }
            return false;
        }

        public Boolean EditUser(string Email, string PhotoUrl, string FirstName, string LastName, string PhoneNumber, string Address, string City, string State, string Zip, string Organization)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_UpdateUser";          
            SqlParameter emailParameter = new SqlParameter("@email", Email);
            emailParameter.Direction = ParameterDirection.Input;
            emailParameter.SqlDbType = SqlDbType.VarChar;
            emailParameter.Size = 50;
            SqlParameter photoParameter = new SqlParameter("@profilePhotoUrl", PhotoUrl);
            photoParameter.Direction = ParameterDirection.Input;
            photoParameter.SqlDbType = SqlDbType.VarChar;
            photoParameter.Size = 50;
            SqlParameter firstNameParamter = new SqlParameter("@firstName", FirstName);
            firstNameParamter.Direction = ParameterDirection.Input;
            firstNameParamter.SqlDbType = SqlDbType.VarChar;
            firstNameParamter.Size = 50;
            SqlParameter lastNameParameter = new SqlParameter("@lastName", LastName);
            lastNameParameter.Direction = ParameterDirection.Input;
            lastNameParameter.SqlDbType = SqlDbType.VarChar;
            lastNameParameter.Size = 50;
            SqlParameter phoneNumberParamter = new SqlParameter("@phoneNumber", PhoneNumber);
            phoneNumberParamter.Direction = ParameterDirection.Input;
            phoneNumberParamter.SqlDbType = SqlDbType.VarChar;
            phoneNumberParamter.Size = 10;
            SqlParameter addressParameter = new SqlParameter("@address", Address);
            addressParameter.Direction = ParameterDirection.Input;
            addressParameter.SqlDbType = SqlDbType.VarChar;
            addressParameter.Size = 50;
            SqlParameter cityParameter = new SqlParameter("@city", City);
            cityParameter.Direction = ParameterDirection.Input;
            cityParameter.SqlDbType = SqlDbType.VarChar;
            cityParameter.Size = 50;
            SqlParameter stateParameter = new SqlParameter("@state", State);
            stateParameter.Direction = ParameterDirection.Input;
            stateParameter.SqlDbType = SqlDbType.VarChar;
            stateParameter.Size = 2;
            SqlParameter zipParameter = new SqlParameter("@zip", Zip);
            zipParameter.Direction = ParameterDirection.Input;
            zipParameter.SqlDbType = SqlDbType.VarChar;
            zipParameter.Size = 5;
            SqlParameter organizationParameter = new SqlParameter("@organization", Organization);
            organizationParameter.Direction = ParameterDirection.Input;
            organizationParameter.SqlDbType = SqlDbType.VarChar;
            organizationParameter.Size = 50;

            objCommand.Parameters.Add(emailParameter);
            objCommand.Parameters.Add(firstNameParamter);
            objCommand.Parameters.Add(lastNameParameter);
            objCommand.Parameters.Add(phoneNumberParamter);
            objCommand.Parameters.Add(addressParameter);
            objCommand.Parameters.Add(cityParameter);
            objCommand.Parameters.Add(stateParameter);
            objCommand.Parameters.Add(zipParameter);
            objCommand.Parameters.Add(photoParameter);
            objCommand.Parameters.Add(organizationParameter);

            if (objDB.DoUpdateUsingCmdObj(objCommand) > 0)
            {
                return true;
            }
            return false;
        }
    }
}
