using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Commands
{
    public class GetCategoryListCommand : AsyncCommandBase
    {
        private readonly UserViewModel _userViewModel;
        private readonly ICategoryService _categoryService;

        public GetCategoryListCommand(UserViewModel userViewModel, ICategoryService categoryService)
        {
            this._userViewModel = userViewModel;
            this._categoryService = categoryService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _userViewModel.ErrorMessage = string.Empty;

            try
            {
                _userViewModel.GetCollection = await _categoryService.GetAll();

                /*IEnumerable<Category> categoryEnumerable = await _categoryService.GetAll();

                List<string> list = new List<string>();

                foreach (object item in categoryEnumerable)
                    list.Add(item.ToString());

                _adminViewModel.GetCollection = list;*/
            }
            catch (Exception)
            {
                _userViewModel.ErrorMessage = "Get command fail";
            }

        }
    }
}
