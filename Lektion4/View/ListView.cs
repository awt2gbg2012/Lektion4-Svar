using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lektion4.Model;

namespace Lektion4.View
{
    public class ListView
    {
        private string Message { get; set; }
        private List<User> Users { get; set; }
        public ListView(List<User> users) { Users = users; }
        public ListView(string msg) { Message = msg; }

        internal string Render()
        {
            string returnString = "";
            if (!string.IsNullOrEmpty(Message))
                return Message;

            if (Users.Count > 0)
            {
                foreach (var user in Users)
                {
                    returnString += string.Format("\nName: {0} ID: {1}", user.FullName, user.UserID.ToString());
                }
            }

            return returnString;
        }
    }
}