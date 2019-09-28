using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkingClassLibrary
{
    public class Post
    {
        public int PostID { get; set; }
        public string PosterEmail { get; set; }
        public string PostLocation { get; set; }
        public string Message { get; set; }
        public string PhotoUrl {get;set;}
        public DateTime dateOfPost { get; set; }
        public List<Comment> comments { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Post()
        {

        }
    }
}
