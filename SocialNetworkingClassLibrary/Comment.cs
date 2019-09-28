using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkingClassLibrary
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int PostID { get; set; }
        public string CommenterEmail { get; set; }
        public string Message { get; set; }

        public Comment()
        {

        }
    }
}
