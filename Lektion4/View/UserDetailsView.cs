using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lektion4.View.Abstract;
using Lektion4.Model;

namespace Lektion4.View
{
    class UserDetailsView : IView
    {
        private User User { get; set;}
        public UserDetailsView(User user)
        {
            User = user;
        }

        public string Render()
        {
            if (User == null)
                return "No User Found!";

            return User.ToString(false);
        }
    }
}
