using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lektion4.View;
using Lektion4.Model.Repository;
using Lektion4.Model;
using Lektion4.View.Abstract;

namespace Lektion4.Controller
{
    public class DefaultController
    {
        private Repository Repo = new Repository();
        public bool Exit { get; set; }

        public IView handleInput(string Input) {

            var inputs = Input.Split(new char[] { ':' });
            List<User> users = new List<User>();
            User user;

            switch (inputs[0].ToLower())
            {
                case "?":
                case "help":
                    return new ListView("\n\nAvailable Commands:\n\thelp/?:\thelp\n\tlist:\tList Users\n\texit:\tExit Program\n\tadduser:[x]\tAdds a User.");
                case "list":
                    users = Repo.GetUsers().Take(10).ToList();
                    return new ListView(users);
                case "listuser":
                    if (inputs.Length < 2 || string.IsNullOrEmpty(inputs[1]))
                        return new ListView("\n\nError: You need to supply a username, [x] with listuser:[X]");
                    user = Repo.GetUserByUsername(inputs[1]);
                    if (null == user)
                        return new ListView("\n\nError: Username doesn't exist");
                    return new UserDetailsView(user);
                case "adduser":
                    if (inputs.Length < 2 || string.IsNullOrEmpty(inputs[1]))
                        return new ListView("\n\nError: You need to supply a username, [x] with adduser:[X]");
                    users = Repo.GetUsers().Where(u => u.UserName == inputs[1]).Take(1).ToList();
                    if (users.Count > 0)
                        return new ListView("\n\nError: Username already exist");
                    Repo.AddUser(new User() { UserID = Guid.NewGuid(), UserName = inputs[1], Type = User.UserType.User });
                    return new ListView("\n\nUser succesfully added!");
                case "removeuser":
                    // Implementationen för detta är väldigt lik adduser - men du kör istället Repo.RemoveUser(user) ifall användaren existerar
                    return new ListView("\n\nNot Implemented - See Implementation for adduser");
                case "exit":
                    Exit = true;
                    return new ListView("Exiting Program!");
                default:
                    return new ListView("Error! Cannot parse input!");
            }
        }
    }
}
