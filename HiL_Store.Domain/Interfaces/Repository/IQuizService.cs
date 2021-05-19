using HiL_Store.Domain.Entities.QuizEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Domain.Interfaces.Repository
{
    public interface IQuizService : IGenericDataService<Quiz>
    {
        Task<Quiz> GetByQuestion(string question);

    }
}
