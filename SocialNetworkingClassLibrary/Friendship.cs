using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkingClassLibrary
{
    public class Friendship
    {
        public int VerificationToken { get; set; }
        public string UserEmail { get; set; }
        public string FriendEmail { get; set; }
        public int Status { get; set; }
        public int Subscription { get; set; }

        public Friendship()
        {

        }
    }
}
