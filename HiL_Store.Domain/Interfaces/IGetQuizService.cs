using HiL_Store.Domain.Entities.QuizEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Domain.Interfaces
{
    public enum GetQuizResult
    {
        Success,
        DoNotChooseCategory
    }
    public interface IGetQuizService
    {
        List<CategoryQuiz> GetQuiz(Category entity, int count);
    }
}
