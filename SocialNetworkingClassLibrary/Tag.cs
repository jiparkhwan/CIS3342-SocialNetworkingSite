using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkingClassLibrary
{
    public class Tag
    {
        public int TagID { get; set; }
        public int PhotoID { get; set; }
        public string TaggedUser { get; set; }

        public Tag()
        {

        }
    }
}
