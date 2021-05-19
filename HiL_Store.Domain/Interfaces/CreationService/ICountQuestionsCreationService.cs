using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Domain.Interfaces.CreationService
{

    public enum CreationCountQuestionsResult
    {
        SuccessCreation,
        EmptyData
    }

    public interface ICountQuestionsCreationService
    {
        Task<CreationCountQuestionsResult> Creation(string countOfQuestions);
    }

}
