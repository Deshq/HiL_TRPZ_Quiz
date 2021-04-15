using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HiL_Store.Domain.Entities
{
    public class Account : DomainObject
    {
        public int? UserID { get; set; }

        [ForeignKey(nameof(UserID))]
        public User AccountHolder { get; set; }
    }
}
