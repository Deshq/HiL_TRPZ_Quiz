using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HiL_Store.Domain.Entities.QuizEntities
{
    public class CategoryQuiz : DomainObject
    {
        public int? CategoryID { get; set; }

        [ForeignKey(nameof(CategoryID))]
        public Category Category { get; set; }

        public int? QuizID { get; set; }

        [ForeignKey(nameof(QuizID))]
        public Quiz Quiz { get; set; }


        public override string ToString()
        {
            return Quiz.Question;
        }

    }
}
