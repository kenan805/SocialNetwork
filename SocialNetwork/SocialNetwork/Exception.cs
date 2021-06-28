using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionNamespace
{
    class AdminException : ApplicationException
    {
        public override string Message { get; }
        public AdminException(string message)
        {
            Message = message;
        }
    }
    class UserException : ApplicationException
    {
        public override string Message { get; }
        public UserException(string message)
        {
            Message = message;
        }
    }
    class PostException : ApplicationException
    {
        public override string Message { get; }
        public PostException(string message)
        {
            Message = message;
        }
    }
    class NotificationException : ApplicationException
    {
        public override string Message { get; }
        public NotificationException(string message)
        {
            Message = message;
        }
    }
}
