using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.Domain.Entities
{
    public class User : DomainObject
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DatedJoined { get; set; }
        public string UserRole { get; set; }
        
    }
}
