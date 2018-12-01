using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Data;
using System.Data.SqlClient;

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
    }
}
