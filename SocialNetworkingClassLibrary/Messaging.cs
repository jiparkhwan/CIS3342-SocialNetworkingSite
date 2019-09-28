using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkingClassLibrary
{
    public class Messaging
    {
        public int ConversationID { get; set; }
        public string Message { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SenderEmail { get; set; }
        public string Time { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }

        public Messaging()
        {

        }
    }
}

