using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserNamespace;

namespace NotificationNamespace
{
    class Notification
    {
        public static int ID { get; set; }
        public int NotificationId { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public User FromUser { get; set; }
        public Notification(string text,User fromUser)
        {
            NotificationId = ++ID;
            Text = text;
            DateTime = DateTime.Now;
            FromUser = fromUser;
        }
        public void Show()
        {
            Console.WriteLine($"Notification id: {NotificationId}");
            Console.WriteLine($"Notification text: {Text}");
            Console.WriteLine($"Notification from user: {FromUser.Name} {FromUser.Surname}");
            Console.WriteLine($"Notification datetime: {DateTime}");
            Console.WriteLine();
        }

    }
}