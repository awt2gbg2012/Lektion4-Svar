using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lektion4.View.Abstract;
using Lektion4.Model;

namespace Lektion4.View
{
    public class PostView : IView
    {
        public List<Post> Posts { get; set; }
        public PostView(List<Post> posts) { Posts = posts; }

        public string Render()
        {
            string resultString = "\n\nPosts:";
            if (Posts.Count < 1)
                resultString += "\tNo Posts Found!";

            foreach (var post in Posts)
            {
                resultString += "\n\t" + post.ToString(true);
            }

            return resultString;
        }
    }
}
