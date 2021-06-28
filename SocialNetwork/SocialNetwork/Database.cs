using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminNamespace;
using PostNamespace;
using UserNamespace;
using NotificationNamespace;
using ExceptionNamespace;
using System.Threading;
using SocialNetwork;

namespace DatabaseNamespace
{
    class Database
    {
        public Admin Admin { get; private set; }
        public int AdminCount { get; private set; }
        public User[] Users { get; set; }
        public Post[] Posts { get; set; }
        public Notification[] Notifications { get; set; }
        public void AddAdmin(in Admin admin)
        {
            if (AdminCount == 0)
            {
                Admin = admin;
                AdminCount = 1;
            }
            else throw new AdminException("Only one admin can be!");


        }

        #region User methods
        public void AddUser(in User newUser)
        {
            if (newUser == null) throw new UserException("User null!");
            else
            {
                int count = (Users == null) ? 1 : Users.Length + 1;
                User[] newUsers = new User[count];
                if (Users != null) Array.Copy(Users, newUsers, Users.Length);
                newUsers[count - 1] = newUser;
                Users = newUsers;
            }
        }
        public void SignUp()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            User newUser = new(name, surname, age, email, password);
            if (newUser == null) throw new UserException("User null!");
            else
            {
                AddUser(newUser);
                Console.WriteLine("Successfully registered.");
                Console.ReadLine();
            }
        }
        public void DeleteUserById(int id)
        {
            if (id <= 0) throw new UserException("User id must be greater than 0!");
            else
            {
                if (Array.Exists(Users, user => user.UserId == id))
                {
                    int findIndex = Array.FindIndex(Users, user => user.UserId == id);

                    User[] newUsers = new User[Users.Length - 1];
                    if (newUsers != null)
                    {
                        Array.Copy(Users, newUsers, findIndex);
                        Array.Copy(Users, findIndex + 1, newUsers, findIndex, Users.Length - 1 - findIndex);
                    }
                    Users = newUsers;

                }
                else Console.WriteLine("Not find user!");
            }
        }
        public void ShowAllUsers()
        {
            Console.WriteLine("----------- ALL USERS -----------");
            if (Users != null)
            {
                foreach (var user in Users)
                    user.Show();
            }
            else Console.WriteLine("There are currently no users.");
            Console.ReadLine();
        }
        #endregion

        #region Notifications methods
        public void AddNotf(in Notification newNotf)
        {
            if (newNotf == null) throw new NotificationException("Notification null!");
            else
            {
                int count = (Notifications == null) ? 1 : Notifications.Length + 1;
                Notification[] newNotfs = new Notification[count];
                if (Notifications != null) Array.Copy(Notifications, newNotfs, Notifications.Length);
                newNotfs[count - 1] = newNotf;
                Notifications = newNotfs;
            }
        }
        public void DeleteAllNotf()
        {
            if (Notifications != null)
            {
                Notification[] newNotifications = new Notification[0];
                Notifications = newNotifications;
            }
            else
                throw new NotificationException("Notifications null!");


        }
        public void ShowAllNotfs()
        {
            Console.WriteLine("------- ALL NOTIFICATIONS -------");
            Console.WriteLine($"Notifications count: {Notifications.Length}");
            foreach (var notf in Notifications)
                notf.Show();
            Console.ReadLine();
        }
        #endregion

        #region Post methods
        public void AddPost()
        {
            Console.Write("Write post content: ");
            string content = Console.ReadLine();
            Post newPost = new(content);
            if (newPost == null) throw new PostException("Post null!");
            else
            {
                int count = (Posts == null) ? 1 : Posts.Length + 1;
                Post[] newPosts = new Post[count];
                if (Posts != null) Array.Copy(Posts, newPosts, Posts.Length);
                newPosts[count - 1] = newPost;
                Posts = newPosts;
                Thread.Sleep(1000);
                Console.WriteLine("The post was successfully added.");
                Console.ReadLine();
            }
        }
        public void DeletePostById()
        {
            Console.Write("Select the id of the post you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            if (id <= 0) throw new PostException("Post id must be greater than 0!");
            else
            {
                if (Array.Exists(Posts, post => post.PostId == id))
                {
                    int findIndex = Array.FindIndex(Posts, post => post.PostId == id);

                    Post[] newPosts = new Post[Posts.Length - 1];
                    if (newPosts != null)
                    {
                        Array.Copy(Posts, newPosts, findIndex);
                        Array.Copy(Posts, findIndex + 1, newPosts, findIndex, Posts.Length - 1 - findIndex);
                    }
                    Posts = newPosts;
                    Thread.Sleep(1000);
                    Console.WriteLine("The post you selected has been successfully deleted.");
                    Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("Not find post!");
                    Console.ReadLine();
                }
            }

        }
        public void UpdatePostById()
        {
            Console.Write("Select the id of the post you want to update: ");
            int id = int.Parse(Console.ReadLine());
            if (id <= 0) throw new PostException("Post id must be greater than 0!");
            else
            {
                if (Array.Exists(Posts, post => post.PostId == id))
                {
                    int findIndex = Array.FindIndex(Posts, post => post.PostId == id);
                    Console.Write("Enter new content: ");
                    string content = Console.ReadLine().Trim();
                    Posts[findIndex].Content = content;
                    Thread.Sleep(1000);
                    Console.WriteLine("The post you selected has been successfully updated.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Not find post!");
                    Console.ReadLine();
                }
            }
        }
        public void ShowAllPosts()
        {
            Console.WriteLine("----------- ALL POSTS -----------");
            if (Posts != null)
            {
                foreach (var post in Posts)
                    post.Show();
            }
            else
            {
                Console.WriteLine("There are currently no posts.");
                Console.ReadLine();
            }
        }
        public void ViewPost(in User user,in Database database)
        {
            Console.Write("Select the id of the post you want to view: ");
            int id = int.Parse(Console.ReadLine());
            if (id <= 0) throw new PostException("Post id must be greater than 0!");
            else
            {
                if (Array.Exists(Posts, post => post.PostId == id))
                {
                    int findIndex = Array.FindIndex(Posts, post => post.PostId == id);
                    Posts[findIndex].ViewCount += 1;
                    Console.Clear();
                    Posts[findIndex].Show();
                    Network network = new();
                    Notification notf = new($"The post was viewed by {user.Name} {user.Surname}", user);
                    AddNotf(notf);
                    network.SendNotf(user,database,notf);
                }
                else
                {
                    Console.WriteLine("Post not found!");
                    Console.ReadLine();
                }
            }
        }
        public void LikePost(in User user,in Database database)
        {
            Console.Write("Select the id of the post you want to like: ");
            int id = int.Parse(Console.ReadLine());
            if (id <= 0) throw new PostException("Post id must be greater than 0!");
            else
            {
                if (Array.Exists(Posts, post => post.PostId == id))
                {
                    int findIndex = Array.FindIndex(Posts, post => post.PostId == id);
                    Posts[findIndex].LikeCount += 1;
                    Console.Clear();
                    Posts[findIndex].Show();
                    Network network = new();
                    Notification notf = new($"The post was liked by {user.Name} {user.Surname}", user);
                    AddNotf(notf);
                    network.SendNotf(user, database, notf);
                }
                else
                {
                    Console.WriteLine("Post not found!");
                    Console.ReadLine();
                }
            }
        }
        #endregion

        public Admin GetAdmin()
        {
            return Admin;
        }
    }
}



