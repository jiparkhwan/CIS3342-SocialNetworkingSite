using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class PostControl : System.Web.UI.UserControl
    {
        string imageURL;
        string posterName;
        string time;
        string post;

        protected void Page_Load(object sender, EventArgs e)
        {
            imgPosterIcon.ImageUrl = ImageURL;
            if(PosterName != null)
            {
                imgPosterIcon.Width = 100;
                imgPosterIcon.Height = 100;
            }
            lblPosterName.Text = posterName;
            lblTime.Text = Time;
            lblPost.Text = Post;
        }

        public String ImageURL
        {
            get { return imageURL; }
            set { imageURL = value; }
        }

        public String PosterName
        {
            get { return posterName; }
            set { posterName = value; }
        }

        public String Time
        {
            get { return time; }
            set { time = value; }
        }

        public String Post
        {
            get { return post; }
            set { post = value; }
        }
    }
}