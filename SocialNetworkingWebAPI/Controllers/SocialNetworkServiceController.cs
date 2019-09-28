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
    public class SocialNetworkServiceController : ControllerBase
    {
        // GET api/SocialNetworkService/FindUserByName/firstName/LastName
        [HttpGet("FindUserByName/{email}/{firstName}/{lastName}")]
        public List<User> FindUserByName(string email, string firstName, string lastName)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindUserByName";
            objCommand.Parameters.AddWithValue("@email", email);
            objCommand.Parameters.AddWithValue("@firstName", firstName);
            objCommand.Parameters.AddWithValue("@lastName", lastName);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            List<User> users = new List<User>();
            User user;
            foreach (DataRow record in ds.Tables[0].Rows)
            {
                user = new User();
                user.Email = record["Email"].ToString();
                user.FirstName = record["FirstName"].ToString();
                user.LastName = record["LastName"].ToString();
                user.PhoneNumber = record["PhoneNumber"].ToString();
                user.Address = record["Address"].ToString();
                user.City = record["City"].ToString();
                user.State = record["State"].ToString();
                user.Zip = record["Zip"].ToString();
                user.Password = record["Password"].ToString();
                user.ProfilePhotoUrl = record["ProfilePhotoUrl"].ToString();
                user.Organization = record["Organization"].ToString();
                users.Add(user);
            }
            return users;
        }
        // GET api/SocialNetworkService/FindUserByLocation
        [HttpGet("FindUserByLocation/{email}/{city}/{state}")]
        public List<User> FindUserByLocation(string email, string city, string state)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindUserByLocation";
            objCommand.Parameters.AddWithValue("@email", email);
            objCommand.Parameters.AddWithValue("@city", city);
            objCommand.Parameters.AddWithValue("@state", state);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            List<User> users = new List<User>();
            User user;
            foreach (DataRow record in ds.Tables[0].Rows)
            {
                user = new User();
                user.Email = record["Email"].ToString();
                user.FirstName = record["FirstName"].ToString();
                user.LastName = record["LastName"].ToString();
                user.PhoneNumber = record["PhoneNumber"].ToString();
                user.Address = record["Address"].ToString();
                user.City = record["City"].ToString();
                user.State = record["State"].ToString();
                user.Zip = record["Zip"].ToString();
                user.Password = record["Password"].ToString();
                user.ProfilePhotoUrl = record["ProfilePhotoUrl"].ToString();
                user.Organization = record["Organization"].ToString();
                users.Add(user);
            }
            return users;
        }
        // GET api/SocialNetworkService/FindUserByOrganization
        [HttpGet("FindUserByOrganization/{email}/{organization}")]
        public List<User> FindUserByOrganization(string email, string organization)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindUserByOrganization ";
            objCommand.Parameters.AddWithValue("@email", email);
            objCommand.Parameters.AddWithValue("@organization", organization);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            List<User> users = new List<User>();
            User user;
            foreach (DataRow record in ds.Tables[0].Rows)
            {
                user = new User();
                user.Email = record["Email"].ToString();
                user.FirstName = record["FirstName"].ToString();
                user.LastName = record["LastName"].ToString();
                user.PhoneNumber = record["PhoneNumber"].ToString();
                user.Address = record["Address"].ToString();
                user.City = record["City"].ToString();
                user.State = record["State"].ToString();
                user.Zip = record["Zip"].ToString();
                user.Password = record["Password"].ToString();
                user.ProfilePhotoUrl = record["ProfilePhotoUrl"].ToString();
                user.Organization = record["Organization"].ToString();
                users.Add(user);
            }
            return users;
        }
        //Requires privacy implementation
        // GET api/SocialNetworkService/GetFriends
        [HttpGet("GetFriends/{requestingUsername}/{requestedUsername}/{verificationToken}")]
        public List<User> GetFriends(string requestingUsername, string requestedUsername, string verificationToken)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetFriends";
            objCommand.Parameters.AddWithValue("@requestingUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@requestedUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@verificationToken", verificationToken);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            List<User> friends = new List<User>();
            User friend = new User();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                friend = new User();
                friend.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                friend.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                friend.ProfilePhotoUrl = ds.Tables[0].Rows[i]["ProfilePhotoUrl"].ToString();
                friends.Add(friend);
            }
            return friends;
        }
        //Requires privacy implementation
        // GET api/SocialNetworkService/GetFriendsList
        [HttpGet("GetFriendsList/{requestingUsername}/{requestedUsername}/{verificationToken}")]
        public User[] GetFriendsList(string requestingUsername, string requestedUsername, string verificationToken)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetFriends";
            objCommand.Parameters.AddWithValue("@requestingUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@requestedUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@verificationToken", verificationToken);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            User[] friends = new User[ds.Tables[0].Rows.Count];
            User friend = new User();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                friend = new User();
                friend.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                friend.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                friend.ProfilePhotoUrl = ds.Tables[0].Rows[i]["ProfilePhotoUrl"].ToString();
                friends[i] = friend;
            }
            return friends;
        }
        //Requires privacy implementation
        // GET api/SocialNetworkService/GetFriendsList
        [HttpGet("GetMyFriends/{requestingEmail}")]
        public List<User> GetMyFriends(string requestingEmail)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindAllFriends";
            objCommand.Parameters.AddWithValue("@email", requestingEmail);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            List<User> friends = new List<User>();
            User friend = new User();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                friend = new User();
                friend.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                friend.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                friend.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                friend.ProfilePhotoUrl = ds.Tables[0].Rows[i]["ProfilePhotoUrl"].ToString();
                friends.Add(friend);
            }
            return friends;
        }
        //Requires privacy implementation
        // GET api/SocialNetworkService/GetProfile/{requestingEmail}/{requestedEmail}/{verificationToken}
        [HttpGet("GetProfile/{requestingEmail}/{requestedEmail}/{verificationToken}")]
        public Profile GetProfile(string requestingEmail, string requestedEmail, string verificationToken)
        {
            Profile profile = new Profile();
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CheckFriendshipAndPrivacy";
            objCommand.Parameters.AddWithValue("@requestingEmail", requestingEmail);
            objCommand.Parameters.AddWithValue("@requestedEmail", requestedEmail);
            objCommand.Parameters.AddWithValue("@verificationToken", verificationToken);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            try
            {
                if ((Convert.ToString(ds.Tables[0].Rows[0]["Privacy"]) == "Friends" || Convert.ToString(ds.Tables[0].Rows[0]["Privacy"]) == "Everyone") && Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) == 1)
                {
                    //Find User
                    User user = new User();
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_GetUser";
                    objCommand.Parameters.AddWithValue("@requestingEmail", requestingEmail);
                    objCommand.Parameters.AddWithValue("@requestedEmail", requestedEmail);
                    objCommand.Parameters.AddWithValue("@verificationToken", verificationToken);
                    ds = objDB.GetDataSetUsingCmdObj(objCommand);
                    user.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    user.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    user.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                    user.PhoneNumber = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    user.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    user.City = ds.Tables[0].Rows[0]["City"].ToString();
                    user.State = ds.Tables[0].Rows[0]["State"].ToString();
                    user.Zip = ds.Tables[0].Rows[0]["Zip"].ToString();
                    user.ProfilePhotoUrl = ds.Tables[0].Rows[0]["ProfilePhotoUrl"].ToString();
                    user.Organization = ds.Tables[0].Rows[0]["Organization"].ToString();
                    user.verificationToken = Convert.ToInt32(ds.Tables[0].Rows[0]["VerificationToken"]);
                    profile.User = user;
                    //Find Photos
                    List<Photo> photos = new List<Photo>();
                    Photo photo;
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_FindAllPhotos";
                    objCommand.Parameters.AddWithValue("@email", requestedEmail);
                    ds = objDB.GetDataSetUsingCmdObj(objCommand);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        photo = new Photo();
                        photo.PhotoID = Convert.ToInt32(ds.Tables[0].Rows[i]["PhotoID"]);
                        photo.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                        photo.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                        photo.PhotoUrl = ds.Tables[0].Rows[i]["PhotoUrl"].ToString();
                        photos.Add(photo);
                    }
                    profile.Photos = photos;
                    //Find Posts
                    List<Post> posts = new List<Post>();
                    Post post;
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_FindAllPosts";
                    objCommand.Parameters.AddWithValue("@email", requestedEmail);
                    ds = objDB.GetDataSetUsingCmdObj(objCommand);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        post = new Post();
                        post.PostID = Convert.ToInt32(ds.Tables[0].Rows[0]["PhotoID"]);
                        post.PosterEmail = ds.Tables[0].Rows[0]["Email"].ToString();
                        post.Message = ds.Tables[0].Rows[0]["ProfilePhotoUrl"].ToString();
                        posts.Add(post);
                    }
                    profile.Posts = posts;
                    //Find Friends
                    List<User> friends = new List<User>();
                    User friend;
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_FindAllFriends";
                    objCommand.Parameters.AddWithValue("@email", requestedEmail);
                    ds = objDB.GetDataSetUsingCmdObj(objCommand);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["Email"].ToString() == requestingEmail)
                        {
                            continue;
                        }
                        else
                        {
                            friend = new User();
                            friend.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                            friend.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                            friend.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                            friend.PhoneNumber = ds.Tables[0].Rows[i]["PhoneNumber"].ToString();
                            friend.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                            friend.City = ds.Tables[0].Rows[i]["City"].ToString();
                            friend.State = ds.Tables[0].Rows[i]["State"].ToString();
                            friend.Zip = ds.Tables[0].Rows[i]["Zip"].ToString();
                            friend.ProfilePhotoUrl = ds.Tables[0].Rows[i]["ProfilePhotoUrl"].ToString();
                            friend.Organization = ds.Tables[0].Rows[i]["Organization"].ToString();
                            friends.Add(friend);
                        }
                    }
                    profile.Friends = friends;
                }
            }
            catch (ArgumentException)
            {
                if (Convert.ToString(ds.Tables[0].Rows[0]["Privacy"]) == "Friends")
                {
                    //Find User
                    User user = new User();
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_GetUser";
                    objCommand.Parameters.AddWithValue("@requestingEmail", requestingEmail);
                    objCommand.Parameters.AddWithValue("@requestedEmail", requestedEmail);
                    objCommand.Parameters.AddWithValue("@verificationToken", verificationToken);
                    ds = objDB.GetDataSetUsingCmdObj(objCommand);
                    user.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    user.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    user.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                    user.ProfilePhotoUrl = ds.Tables[0].Rows[0]["ProfilePhotoUrl"].ToString();
                    profile.User = user;
                }
                else if(Convert.ToString(ds.Tables[0].Rows[0]["Privacy"]) == "Everyone")
                {
                    //Find User
                    User user = new User();
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_GetUser";
                    objCommand.Parameters.AddWithValue("@requestingEmail", requestingEmail);
                    objCommand.Parameters.AddWithValue("@requestedEmail", requestedEmail);
                    objCommand.Parameters.AddWithValue("@verificationToken", verificationToken);
                    ds = objDB.GetDataSetUsingCmdObj(objCommand);
                    user.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    user.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    user.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                    user.PhoneNumber = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
                    user.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    user.City = ds.Tables[0].Rows[0]["City"].ToString();
                    user.State = ds.Tables[0].Rows[0]["State"].ToString();
                    user.Zip = ds.Tables[0].Rows[0]["Zip"].ToString();
                    user.ProfilePhotoUrl = ds.Tables[0].Rows[0]["ProfilePhotoUrl"].ToString();
                    user.Organization = ds.Tables[0].Rows[0]["Organization"].ToString();
                    user.verificationToken = Convert.ToInt32(ds.Tables[0].Rows[0]["VerificationToken"]);
                    profile.User = user;
                    //Find Photos
                    List<Photo> photos = new List<Photo>();
                    Photo photo;
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_FindAllPhotos";
                    objCommand.Parameters.AddWithValue("@email", requestedEmail);
                    ds = objDB.GetDataSetUsingCmdObj(objCommand);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        photo = new Photo();
                        photo.PhotoID = Convert.ToInt32(ds.Tables[0].Rows[i]["PhotoID"]);
                        photo.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                        photo.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                        photo.PhotoUrl = ds.Tables[0].Rows[i]["PhotoUrl"].ToString();
                        photos.Add(photo);
                    }
                    profile.Photos = photos;
                    //Find Posts
                    List<Post> posts = new List<Post>();
                    Post post;
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_FindAllPosts";
                    objCommand.Parameters.AddWithValue("@email", requestedEmail);
                    ds = objDB.GetDataSetUsingCmdObj(objCommand);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        post = new Post();
                        post.PostID = Convert.ToInt32(ds.Tables[0].Rows[0]["PhotoID"]);
                        post.PosterEmail = ds.Tables[0].Rows[0]["Email"].ToString();
                        post.Message = ds.Tables[0].Rows[0]["ProfilePhotoUrl"].ToString();
                        posts.Add(post);
                    }
                    profile.Posts = posts;
                    //Find Friends
                    List<User> friends = new List<User>();
                    User friend;
                    objDB = new DBConnect();
                    objCommand = new SqlCommand();
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "TP_FindAllFriends";
                    objCommand.Parameters.AddWithValue("@email", requestedEmail);
                    ds = objDB.GetDataSetUsingCmdObj(objCommand);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["Email"].ToString() == requestingEmail)
                        {
                            continue;
                        }
                        else
                        {
                            friend = new User();
                            friend.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                            friend.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                            friend.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                            friend.PhoneNumber = ds.Tables[0].Rows[i]["PhoneNumber"].ToString();
                            friend.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                            friend.City = ds.Tables[0].Rows[i]["City"].ToString();
                            friend.State = ds.Tables[0].Rows[i]["State"].ToString();
                            friend.Zip = ds.Tables[0].Rows[i]["Zip"].ToString();
                            friend.ProfilePhotoUrl = ds.Tables[0].Rows[i]["ProfilePhotoUrl"].ToString();
                            friend.Organization = ds.Tables[0].Rows[i]["Organization"].ToString();
                            friends.Add(friend);
                        }
                    }
                    profile.Friends = friends;
                }
            }
            return profile;
        }
        //Requires privacy implementation
        // GET api/SocialNetworkService/GetMyProfile
        [HttpGet("GetMyProfile/{requestingEmail}/{password}")]
        public Profile GetMyProfile(string requestingEmail, string password)
        {
            Profile profile = new Profile();
            //Find User
            User user = new User();
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_LoginAccount";
            objCommand.Parameters.AddWithValue("@email", requestingEmail);
            objCommand.Parameters.AddWithValue("@password", password);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            user.Email = ds.Tables[0].Rows[0]["Email"].ToString();
            user.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
            user.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
            user.PhoneNumber = ds.Tables[0].Rows[0]["PhoneNumber"].ToString();
            user.Address = ds.Tables[0].Rows[0]["Address"].ToString();
            user.City = ds.Tables[0].Rows[0]["City"].ToString();
            user.State = ds.Tables[0].Rows[0]["State"].ToString();
            user.Zip = ds.Tables[0].Rows[0]["Zip"].ToString();
            user.ProfilePhotoUrl = ds.Tables[0].Rows[0]["ProfilePhotoUrl"].ToString();
            user.Organization = ds.Tables[0].Rows[0]["Organization"].ToString();
            user.verificationToken = Convert.ToInt32(ds.Tables[0].Rows[0]["VerificationToken"]);
            profile.User = user;
            //Find Photos
            List<Photo> photos = new List<Photo>();
            Photo photo;
            objDB = new DBConnect();
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindAllPhotos";
            objCommand.Parameters.AddWithValue("@email", requestingEmail);
            ds = objDB.GetDataSetUsingCmdObj(objCommand);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                photo = new Photo();
                photo.PhotoID = Convert.ToInt32(ds.Tables[0].Rows[i]["PhotoID"]);
                photo.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                photo.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                photo.PhotoUrl = ds.Tables[0].Rows[i]["PhotoUrl"].ToString();
                photos.Add(photo);
            }
            profile.Photos = photos;
            //Find Posts
            List<Post> posts = new List<Post>();
            Post post;
            objDB = new DBConnect();
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindAllPosts";
            objCommand.Parameters.AddWithValue("@email", requestingEmail);
            ds = objDB.GetDataSetUsingCmdObj(objCommand);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                post = new Post();
                post.PostID = Convert.ToInt32(ds.Tables[0].Rows[0]["PhotoID"]);
                post.PosterEmail = ds.Tables[0].Rows[0]["Email"].ToString();
                post.Message = ds.Tables[0].Rows[0]["ProfilePhotoUrl"].ToString();
                posts.Add(post);
            }
            profile.Posts = posts;
            //Find Friends
            List<User> friends = new List<User>();
            User friend;
            objDB = new DBConnect();
            objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindAllFriends";
            objCommand.Parameters.AddWithValue("@email", requestingEmail);
            ds = objDB.GetDataSetUsingCmdObj(objCommand);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                friend = new User();
                friend.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                friend.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                friend.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                friend.PhoneNumber = ds.Tables[0].Rows[i]["PhoneNumber"].ToString();
                friend.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                friend.City = ds.Tables[0].Rows[i]["City"].ToString();
                friend.State = ds.Tables[0].Rows[i]["State"].ToString();
                friend.Zip = ds.Tables[0].Rows[i]["Zip"].ToString();
                friend.ProfilePhotoUrl = ds.Tables[0].Rows[i]["ProfilePhotoUrl"].ToString();
                friend.Organization = ds.Tables[0].Rows[i]["Organization"].ToString();
                friends.Add(friend);
            }
            profile.Friends = friends;
            return profile;
        }
        //Requires privacy implementation
        // GET api/SocialNetworkService/GetPhotos
        [HttpGet("GetPhotos/{requestingUsername}/{requestedUsername}/{verificationToken}")]
        public List<Photo> GetPhotos(string requestingUsername, string requestedUsername, string verificationToken)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetPhotos";
            objCommand.Parameters.AddWithValue("@requestingUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@requestedUsername", requestingUsername);
            objCommand.Parameters.AddWithValue("@verificationToken", verificationToken);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            List<Photo> photos = new List<Photo>();
            Photo photo;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                photo = new Photo();
                photo.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                photo.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                photo.PhotoID = Convert.ToInt32(ds.Tables[0].Rows[i]["PhotoID"].ToString());
                photo.PhotoUrl = ds.Tables[0].Rows[i]["PhotoUrl"].ToString();
                photos.Add(photo);
            }
            return photos;
        }
        ////Requires privacy implementation
        //// GET api/SocialNetworkService/GetNewsFeed
        [HttpGet("GetNewsFeed/{requestingUsername}/{verificationToken}")]
        public NewsFeed GetNewsFeed(string requestingUsername, string verificationToken)
        {
            NewsFeed newsfeed = new NewsFeed();
            List<Post> posts = new List<Post>();

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetNewsFeedPosts";
            objCommand.Parameters.AddWithValue("@UserEmail", requestingUsername);
            objCommand.Parameters.AddWithValue("@VerificationToken", verificationToken);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            int rows = ds.Tables[0].Rows.Count;

            for (int i = 0; i < rows; i++)
            {
                Post post = new Post();
                post.PostID = Convert.ToInt32(ds.Tables[0].Rows[i]["PostID"].ToString());
                post.PosterEmail = ds.Tables[0].Rows[i]["Email"].ToString();
                post.Message = ds.Tables[0].Rows[i]["Message"].ToString();
                post.dateOfPost = Convert.ToDateTime(ds.Tables[0].Rows[i]["Date"].ToString());
                post.PostLocation = ds.Tables[0].Rows[i]["PostLocation"].ToString();
                post.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                post.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                post.PhotoUrl = ds.Tables[0].Rows[i]["ProfilePhotoUrl"].ToString();
                posts.Add(post);
            }

            newsfeed.Posts = posts;
            return newsfeed;
        }
        // POST api/SocialNetworkService/SendFriendRequest
        [HttpPost]
        [Route("SendFriendRequest/{userEmail}/{friendEmail}")]
        public Boolean SendFriendRequest(string userEmail, string friendEmail)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_SendFriendRequest";
            objCommand.Parameters.AddWithValue("@userEmail", userEmail);
            objCommand.Parameters.AddWithValue("@friendEmail", friendEmail);
            int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);
            if (returnValue > 0)
            {
                Email objEmail = new Email();
                String strTO = userEmail;
                String strFROM = friendEmail;
                String strSubject = "New friend request.";
                String strMessage = "Someone has sent you a friend request.";
                try
                {
                    objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                }
                catch (Exception ex)
                {
                }
                return true;
            }
            else if (returnValue == 0)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        // GET api/SocialNetworkService/CheckSentFriendRequest
        [HttpGet("CheckSentFriendRequest/{email}")]
        public List<User> CheckSentFriendRequest(string email)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CheckSentFriendRequest";
            objCommand.Parameters.AddWithValue("@email", email);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            List<User> users = new List<User>();
            User user = new User();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                user = new User();
                user.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                user.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                user.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                user.ProfilePhotoUrl = ds.Tables[0].Rows[i]["ProfilePhotoUrl"].ToString();
                users.Add(user);
            }
            return users;
        }
        // GET api/SocialNetworkService/CheckRecievedFriendRequest
        [HttpGet("CheckReceivedFriendRequest/{email}")]
        public List<User> CheckRecievedFriendRequest(string email)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CheckReceivedFriendRequest";
            objCommand.Parameters.AddWithValue("@email", email);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            List<User> users = new List<User>();
            User user = new User();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                user = new User();
                user.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                user.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                user.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                user.ProfilePhotoUrl = ds.Tables[0].Rows[i]["ProfilePhotoUrl"].ToString();
                users.Add(user);
            }
            return users;
        }
        // GET api/SocialNetworkService/AcceptFriendRequest
        [HttpPost("AcceptFriendRequest/{userEmail}/{friendEmail}")]
        public Boolean AcceptFriendRequest(string userEmail, string friendEmail)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_AcceptFriendRequest";
            objCommand.Parameters.AddWithValue("@recieverEmail", userEmail);
            objCommand.Parameters.AddWithValue("@senderEmail", friendEmail);
            int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);
            if (returnValue > 0)
            {
                Email objEmail = new Email();
                String strTO = friendEmail;
                String strFROM = userEmail;
                String strSubject = "Friend request accepted.";
                String strMessage = "Someone accepted your friend request.";
                try
                {
                    objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                }
                catch (Exception ex)
                {
                }
                return true;
            }
            else if (returnValue == 0)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        // GET api/SocialNetworkService/DenyFriendRequest
        [HttpPost("DenyFriendRequest/{userEmail}/{friendEmail}")]
        public Boolean DenyFriendRequest(string userEmail, string friendEmail)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_DenyFriendRequest";
            objCommand.Parameters.AddWithValue("@recieverEmail", userEmail);
            objCommand.Parameters.AddWithValue("@senderEmail", friendEmail);
            int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);
            if (returnValue > 0)
            {
                return true;
            }
            else if (returnValue == 0)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        // GET api/SocialNetworkService/CheckRecievedFriendRequest
        [HttpGet("GetFriendsOfFriends/{userEmail}")]
        public List<User> GetFriendsOfFriends(string userEmail /*UserAccount VerificationToken*/)
        {
            List<User> friendsOfFriends = new List<User>();
            User friend;
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_FindFriendsOfFriends";
            objCommand.Parameters.AddWithValue("@userEmail", userEmail);
            DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                friend = new User();
                friend.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                friend.FirstName = ds.Tables[0].Rows[i]["FirstName"].ToString();
                friend.LastName = ds.Tables[0].Rows[i]["LastName"].ToString();
                friend.ProfilePhotoUrl = ds.Tables[0].Rows[i]["ProfilePhotoUrl"].ToString();
                friendsOfFriends.Add(friend);
            }
            return friendsOfFriends;
        }
        // GET api/SocialNetworkService/CreatePost
        [HttpPost("CreatePost")]
        public Boolean CreatePost([FromBody] Post post)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_CreatePost";
            objCommand.Parameters.AddWithValue("@email", post.PosterEmail);
            objCommand.Parameters.AddWithValue("@postLocation", post.PostLocation);
            objCommand.Parameters.AddWithValue("@message", post.Message);
            int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);
            if (returnValue > 0)
            {
                Email objEmail = new Email();
                String strTO = post.PostLocation;
                String strFROM = post.PosterEmail;
                String strSubject = "Post on your Wall.";
                String strMessage = "You have a new post on your wall from one of your friends.";
                try
                {
                    objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                }
                catch (Exception ex)
                {
                }
                return true;
            }
            else if (returnValue == 0)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
