using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkingClassLibrary;
using Utilities;

namespace SocialNetworkingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialNetworkServiceController : ControllerBase
    {
        // GET api/SocialNetworkService/FindUserByName/firstName/LastName
        [HttpGet("FindUserByName/{firstName}/{lastName}")]
        public DataSet FindUserByName(string firstName, string lastName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindUserByName";
            objCommand.Parameters.AddWithValue("@firstName", firstName);
            objCommand.Parameters.AddWithValue("@lastName", lastName);
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        // GET api/SocialNetworkService/FindUserByLocation
        [HttpGet("FindUserByLocation/{city}/{state}")]
        public DataSet FindUserByLocation(string city, string state)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindUserByLocation";
            objCommand.Parameters.AddWithValue("@city", city);
            objCommand.Parameters.AddWithValue("@state", state);
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        // GET api/SocialNetworkService/FindUserByOrganization
        [HttpGet("FindUserByOrganization/{organization}/")]
        public DataSet FindUserByOrganization(string organization)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindUserByOrganization ";
            objCommand.Parameters.AddWithValue("@organization", organization);
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        // GET api/SocialNetworkService/GetFriends
        [HttpGet("GetFriends/{requestingUsername}/{requestedUsername}/{verificationToken}")]
        public DataSet GetFriends(string requestingUsername, string requestedUsername, string verificationToken)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetFriends";
            objCommand.Parameters.AddWithValue("@requestingUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@requestedUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@verificationToken", verificationToken);
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }
        //Requires privacy implementation

        // GET api/SocialNetworkService/GetFriends
        [HttpGet("GetFriendsList/{requestingUsername}/{requestedUsername}/{verificationToken}")]
        public Friend[] GetFriendsList(string requestingUsername, string requestedUsername, string verificationToken)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetFriends";
            objCommand.Parameters.AddWithValue("@requestingUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@requestedUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@verificationToken", verificationToken);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            Friend[] friends = new Friend[ds.Tables[0].Rows.Count];
            Friend friend = new Friend();
            for(int i = 0; i<ds.Tables[0].Rows.Count; i++)
            {
                friend = new Friend();
                friend.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                friend.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                friend.profilePhotoUrl = ds.Tables[0].Rows[0]["ProfilePhotoUrl"].ToString();
                friends[i] = friend;
            }
            return friends;
        }
        //Requires privacy implementation

        // GET api/SocialNetworkService/GetProfile
        [HttpGet("GetProfile/{requestingUsername}/{requestedUsername}/{verificationToken}")]
        public Object GetProfile(string requestingUsername, string requestedUsername, string verificationToken)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetProfile ";
            objCommand.Parameters.AddWithValue("@requestingUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@requestedUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@verificationToken", verificationToken);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            //Do this later
        }
        //Requires privacy implementation

        // GET api/SocialNetworkService/GetPhotos
        [HttpGet("GetPhotos/{requestingUsername}/{requestedUsername}/{verificationToken}")]
        public DataSet GetPhotos(string requestingUsername, string requestedUsername, string verificationToken)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetPhotos";
            objCommand.Parameters.AddWithValue("@requestingUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@requestedUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@verificationToken", verificationToken);
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }
        //Requires privacy implementation

        // GET api/SocialNetworkService/GetNewsFeed
        [HttpGet("GetNewsFeed/{requestingUsername}/{requestedUsername}/{verificationToken}")]
        public DataSet GetNewsFeed(string requestingUsername, string requestedUsername, string verificationToken)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetPhotos";
            objCommand.Parameters.AddWithValue("@requestingUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@requestedUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@verificationToken", verificationToken);
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }
        //Requires privacy implementation
    }
}
