using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace SocialNetworkingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialNetworkServiceController : ControllerBase
    {
        // GET api/SocialNetworkService/FindUserByName
        [HttpGet("FindUserByName")]
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

        // GET api/SocialNetworkService
        [HttpGet]
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
    }
}
