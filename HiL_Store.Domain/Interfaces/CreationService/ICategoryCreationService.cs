using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Domain.Interfaces.CreationService
{
    public enum CreationCategoryResult
    {
        SuccessCreation,
        CategoryAlreadyExists,
        EmptyData
    }

    public interface ICategoryCreationService
    {
        Task<CreationCategoryResult> Creation(string categoryName);
    }

}
