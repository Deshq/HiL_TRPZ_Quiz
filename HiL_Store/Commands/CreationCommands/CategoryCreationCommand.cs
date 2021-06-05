using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.State.Accounts;
using HiL_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Commands
{
    public class CategoryCreationCommand : AsyncCommandBase
    {
        private readonly AdminViewModel _adminViewModel;
        private readonly ICategoryCreationService _categoryCreationService;
        private readonly ICategoryService _categoryService;


        public CategoryCreationCommand(AdminViewModel adminViewModel, ICategoryCreationService categoryCreationService)
        {
            this._adminViewModel = adminViewModel;
            this._categoryCreationService = categoryCreationService;     
        }

        public CategoryCreationCommand(AdminViewModel adminViewModel, ICategoryCreationService categoryCreationService, ICategoryService categoryService)
        {
            this._adminViewModel = adminViewModel;
            this._categoryCreationService = categoryCreationService;
            this._categoryService = categoryService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _adminViewModel.ErrorMessage = string.Empty;

            try
            {

                CreationCategoryResult result =  await _categoryCreationService.Creation(_adminViewModel.CategoryName);

                _adminViewModel.CategoryGetCommand.Execute(_categoryService);

                switch (result)
                {
                    case CreationCategoryResult.SuccessCreation:
                        _adminViewModel.ErrorMessage = "Success creation category.";
                        break;
                    case CreationCategoryResult.EmptyData:
                        _adminViewModel.ErrorMessage = "Enter the data";
                        break;
                    case CreationCategoryResult.CategoryAlreadyExists:
                        _adminViewModel.ErrorMessage = "Category already exist.";
                        break;                  
                    default:
                        _adminViewModel.ErrorMessage = "Creation category failed.";
                        break;
                }
            }
            catch (Exception)
            {
                _adminViewModel.ErrorMessage = "Failed.";
            }
        }
    }
}
