using ExceptionNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanNamespace
{
    abstract class Human
    {
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (value.Length < 8)
                {
                    throw new UserException("The email must be more than 8 letters!");
                }
                else _email = value;
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                if (value.Length < 5)
                {
                    throw new UserException("The password must be more than 5 letters!");
                }
                else _password = value;
            }
        }
        protected Human(string email, string password)
        {
            Email = email;
            Password = password;
        }
        public abstract void Show();
    }
}
