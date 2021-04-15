using HiL_Store.Domain.Entities.QuizEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Domain.Interfaces
{
    public interface ICategoryQuizService : IGenericDataService<CategoryQuiz>
    {
        Task<CategoryQuiz> GetQuizByCategory(Category entity);

        List<CategoryQuiz> GetQuizByCategory2(Category entity);
    }
}
