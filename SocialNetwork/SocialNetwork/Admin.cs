using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumanNamespace;
using PostNamespace;
using NotificationNamespace;

namespace AdminNamespace
{
    class Admin : Human
    {
        public static int ID { get; set; }
        public int AdminId { get; set; }
        public string Username { get; set; }

        public Admin(string username, string email, string password) : base(email, password)
        {
            AdminId = ++ID;
            Username = username;
        }
        public override void Show()
        {
            Console.WriteLine($"Admin id: {AdminId}");
            Console.WriteLine($"Admin username: {Username}");
            Console.WriteLine($"Admin email: {Email}");
            string password = new('*', Password.Length);
            Console.Write($"User password: {password}");
            Console.WriteLine();
        }



    }
}