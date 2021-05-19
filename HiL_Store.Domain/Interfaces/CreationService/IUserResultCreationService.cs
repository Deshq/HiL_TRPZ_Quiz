using HiL_Store.Domain.Entities;
using HiL_Store.Domain.Entities.QuizEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Domain.Interfaces.CreationService
{
    public enum CreationUserResultResult
    {
        SuccessCreation,
        EmptyData
    }
    public interface IUserResultCreationService
    {
        Task<UserResult> Creation(Account account, int countCorrectAnswer, int countQuestions);
    }
}
