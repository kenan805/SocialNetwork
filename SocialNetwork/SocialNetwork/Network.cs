using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using UserNamespace;
using AdminNamespace;
using DatabaseNamespace;
using NotificationNamespace;

namespace SocialNetwork
{
    class Network
    {
        public Network()
        {

        }
        public void SendNotf(in User user,in Database database,in Notification notification)
        {
            SmtpClient client = new("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(user.Email, user.Password);
            try
            {
                client.Send(user.Email, database.GetAdmin().Email, "New notification!", $"{notification.Text}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
