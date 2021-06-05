using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HiL_Store.Domain.Entities.QuizEntities
{
    public class Quiz : DomainObject
    {
        public string Question { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string CorrectAnswer { get; set; }


        public override string ToString()
        {
            return "№: " + Id + "\nQuestion: " + Question;
        }

    }
}
