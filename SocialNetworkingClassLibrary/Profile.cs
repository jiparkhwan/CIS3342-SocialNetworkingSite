using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkingClassLibrary
{
    public class Profile
    {

        public User User { get; set; }

        public List<Photo> Photos { get; set; }

        public List<Post> Posts { get; set; }

        public List<User> Friends { get; set; }

        public Profile()
        {

        }

    }
}
