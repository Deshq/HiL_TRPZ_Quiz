using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HiL_Store.Domain.Entities
{
    public class DomainObject
    {
        [Key]
        public int Id { get; set; }
    }
}
