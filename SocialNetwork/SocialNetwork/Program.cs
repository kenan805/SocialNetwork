using System;
using DatabaseNamespace;
using NotificationNamespace;
using PostNamespace;
using System.Threading;
using AdminNamespace;
using UserNamespace;
using System.Net.Mail;

namespace SocialNetwork
{
    class Program
    {
        static void AdminMenu(Database database)
        {
            while (true)
            {
                Console.Clear();
                string[] adminMenu = { "Add post", "Delete post", "Update post", "Show all posts", "Show all users", "Show all notificatitons", "Back to", "Exit" };
                for (int i = 0; i < adminMenu.Length; i++)
                    Console.WriteLine($"{i + 1}) {adminMenu[i]}");
                Console.Write("Make your choice: ");
                int choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        {
                            Console.Clear();
                            database.AddPost();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            database.ShowAllPosts();
                            database.DeletePostById();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            database.ShowAllPosts();
                            database.UpdatePostById();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            database.ShowAllPosts();
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            database.ShowAllUsers();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            if (database.Notifications == null)
                            {
                                Console.WriteLine("There is currently no notification.");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                database.ShowAllNotfs();
                                database.DeleteAllNotf();
                                break;
                            }
                        }
                    case 7:
                        {
                            StartMenu(database);
                            break;
                        }
                    case 8:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        Console.WriteLine("The choice is wrong!\nTry again...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        static void UserMenu(in Database database, in User user)
        {
            if (database.Posts != null)
            {
                while (true)
                {
                    Console.Clear();
                    database.ShowAllPosts();
                    string[] userMenu = { "View post", "Like post", "Back to", "Exit" };
                    for (int i = 0; i < userMenu.Length; i++)
                        Console.WriteLine($"{i + 1}) {userMenu[i]}");
                    Console.Write("Make your choice: ");
                    int choise = int.Parse(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            {
                                database.ViewPost(user, database);
                                break;
                            }
                        case 2:
                            {
                                database.LikePost(user,database);
                                break;
                            }
                        case 3:
                            {
                                StartMenu(database);
                                break;
                            }
                        case 4:
                            {
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            Console.WriteLine("The choice is wrong!\nTry again...");
                            Console.ReadLine();
                            break;
                    }
                }
            }

        }
        static void StartMenu(Database database)
        {
            while (true)
            {
                Console.Clear();
                string[] startMenu = { "Admin", "User", "Exit" };
                for (int i = 0; i < startMenu.Length; i++)
                    Console.WriteLine($"{i + 1}) {startMenu[i]}");
                Console.Write("Make your choice: ");
                int choise = int.Parse(Console.ReadLine());
                if (choise == 1)
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.Write("Enter username: ");
                        string username = Console.ReadLine();
                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();
                        if (database.Admin.Username == username && database.Admin.Password == password)
                            AdminMenu(database);
                        else
                        {
                            Console.WriteLine("Username or password incorrect!\nTry again...");
                            Console.ReadLine();
                        }
                    }
                }
                else if (choise == 2)
                {
                    while (true)
                    {
                        Console.Clear();
                        string[] userSignMenu = { "Sign in", "Sign up", "Back to", "Exit" };
                        for (int i = 0; i < userSignMenu.Length; i++)
                            Console.WriteLine($"{i + 1}) {userSignMenu[i]}");
                        Console.Write("Make your choice: ");
                        int choise2 = int.Parse(Console.ReadLine());
                        switch (choise2)
                        {
                            case 1:
                                {
                                    if (database.Users == null)
                                    {
                                        Console.WriteLine("There are currently no users!");
                                        break;
                                    }
                                    else
                                    {

                                        Console.Clear();
                                        Console.Write("Enter email: ");
                                        string email = Console.ReadLine();
                                        Console.Write("Enter password: ");
                                        string password = Console.ReadLine();
                                        bool isExistEmail = Array.Exists(database.Users, user => user.Email == email);
                                        bool isExistPassword = Array.Exists(database.Users, user => user.Password == password);
                                        if (isExistEmail == true && isExistPassword == true)
                                            UserMenu(database, Array.Find(database.Users, user => user.Email == email));
                                        else
                                        {
                                            Console.WriteLine("Username or password incorrect!\nTry again...");
                                            Console.ReadLine();
                                        }
                                        break;
                                    }
                                }
                            case 2:
                                {
                                    Console.Clear();
                                    database.SignUp();
                                    break;
                                }
                            case 3:
                                {
                                    StartMenu(database);
                                    break;
                                }
                            case 4:
                                {
                                    Environment.Exit(0);
                                    break;
                                }
                            default:
                                Console.WriteLine("The choice is wrong!\nTry again...");
                                Console.ReadLine();
                                break;
                        }
                    }
                }
                else if (choise == 3) Environment.Exit(0);
                else
                {
                    Console.WriteLine("The choice is wrong!\nTry again...");
                    Console.ReadLine();
                }
            }

        }
        static void Main(string[] args)
        {
            try
            {
                Database database = new();
                Admin admin = new("admin", "admin mail", "admin"); // admin mail hissesine mail elave edirsiz
                database.AddAdmin(admin);
                StartMenu(database);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}

//Ilk once adminin mailini yazirsiz 240ci setir.
//Sonra run edenden sonra admin hissesinde post lar elave edenden sonra user kimi qeydiyatdan kecib sonra sign in edende postlara baxib ve ya beyenenden adminin mailine mesaj gelecek.