using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkingClassLibrary
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }

        public Photo()
        {

        }
    }
}
