using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkingClassLibrary
{
    [Serializable()]
    public class Preferences 
    {
        public string Email { get; set; } 
        public string Privacy { get; set; }
        public string Theme { get; set; }
        public int AutoSignIn { get; set; }
    }
}
