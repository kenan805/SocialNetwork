using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionNamespace;
using HumanNamespace;

namespace UserNamespace
{
    class User : Human
    {
        public static int ID { get; set; }
        public int UserId { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 3)
                {
                    throw new UserException("The name must be more than 2 letters!");
                }
                else _name = value;
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value.Length < 5)
                {
                    throw new UserException("The surname must be more than 5 letters!");
                }
                else _surname = value;
            }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                if (value <= 0)
                {
                    throw new UserException("Age should be greater than 0!");
                }
                else _age = value;
            }
        }

        public User(string name, string surname, int age, string email, string password) : base(email, password)
        {
            UserId = ++ID;
            Name = name;
            Surname = surname;
            Age = age;
        }
        public override void Show()
        {
            Console.WriteLine($"User id: {UserId}");
            Console.WriteLine($"User name: {Name}");
            Console.WriteLine($"User surname: {Surname}");
            Console.WriteLine($"User age: {Age}");
            Console.WriteLine($"User email: {Email}");
            string password = new('*', Password.Length);
            Console.Write($"User password: {password}");
            Console.WriteLine();
        }


    }
}
