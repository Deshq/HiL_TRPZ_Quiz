using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.Domain.Exeptions
{
    public class UserNotAdminException : Exception
    {
        public string Username { get; set; }
        public string UserRole { get; set; }

        public UserNotAdminException(string username, string userRole)
        {
            Username = username;
            UserRole = userRole;
        }

        public UserNotAdminException(string message, string username, string userRole) : base(message)
        {
            Username = username;
            UserRole = userRole;
        }

        public UserNotAdminException(string message, Exception innerException, string username, string userRole) : base(message, innerException)
        {
            Username = username;
            UserRole = userRole;
        }
    }
}
