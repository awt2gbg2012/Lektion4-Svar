using System;
using Lektion4.Model;
using System.Collections.Generic;

namespace Lektion4.Model.Abstract.Repository
{
    public interface IRepository
    {
        void AddPost(Post newPost);
        void AddUser(User newUser);
        List<Post> GetLatestPosts(int take);
        List<Post> GetPosts();
        User GetUserByUsername(string userName);
        List<User> GetUsers();
        void RemovePost(Guid postID);
        void RemoveUser(Guid userID);
    }
}
