using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lektion4.Model.Abstract.Repository;

namespace Lektion4.Model.Repository
{
    public class EmptyRepository : IRepository
    {
        private List<User> users;
        private List<Post> posts;

        public EmptyRepository(List<User> inputUsers, List<Post> inputPosts)
        {
            users = inputUsers;
            posts = inputPosts;
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public void AddUser(User newUser)
        {
            if (newUser.UserID == null)
                throw new Exception("UserID is not allowed to be null!");
            if (string.IsNullOrEmpty(newUser.UserName))
                throw new Exception("UserName is not allowed to be empty!");
            if (users.Any(u => u.UserID == newUser.UserID))
                throw new Exception("A User with that UserID already Exists!");
            users.Add(newUser);
        }

        public void RemoveUser(Guid userID)
        {
            if (!users.Any(u => u.UserID == userID))
                throw new Exception("User with this UserID does not exist!");
            User userToBeRemoved = users.Where(u => u.UserID == userID).FirstOrDefault();
            users.Remove(userToBeRemoved);
        }

        public List<Post> GetPosts()
        {
            return posts;
        }

        public void AddPost(Post newPost)
        {
            if (newPost.PostID == null)
                throw new Exception("PostID is not allowed to be null!");
            if (newPost.CreatedByID == null)
                throw new Exception("CreatedByID is not allowed to be null!");
            if (!users.Any(u => u.UserID == newPost.CreatedByID))
                throw new Exception("CreatedByID does not match any user!");
            if (string.IsNullOrEmpty(newPost.Body))
                throw new Exception("Body is not allowed to be empty!");
            if (newPost.CreateDate == null || newPost.CreateDate == new DateTime())
                throw new Exception("CreateDate must be set");
            if (posts.Any(p => p.PostID == newPost.PostID))
                throw new Exception("A Post with that PostID already Exists!");
            posts.Add(newPost);
        }

        public void RemovePost(Guid postID)
        {
            if (!posts.Any(p => p.PostID == postID))
                throw new Exception("Post with this PostID does not exist!");
            Post postToBeRemoved = posts.Where(p => p.PostID == postID).FirstOrDefault();
            posts.Remove(postToBeRemoved);
        }

        public List<Post> GetLatestPosts(int take)
        {
            return GetPosts().OrderBy(p => p.CreateDate).Take(take).ToList();
        }

        public User GetUserByUsername(string userName)
        {
            return GetUsers().Where(u => u.UserName == userName).FirstOrDefault();
        }
    }
}
