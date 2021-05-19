using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HiL_Store.Domain.Entities.QuizEntities
{
    public class Category : DomainObject
    {        
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
