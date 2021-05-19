using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Commands
{
    public class CountQuestionsCreationCommand : AsyncCommandBase
    {
        private readonly AdminViewModel _adminViewModel;
        private readonly ICountQuestionsCreationService _countQuestionsCreationService;

        public CountQuestionsCreationCommand(AdminViewModel adminViewModel, 
            ICountQuestionsCreationService countQuestionsCreationService)
        {
            this._adminViewModel = adminViewModel;
            this._countQuestionsCreationService = countQuestionsCreationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _adminViewModel.ErrorMessage = string.Empty;

            try
            {
                CreationCountQuestionsResult result = await _countQuestionsCreationService.Creation(_adminViewModel.CountQuestions);

                switch (result)
                {
                    case CreationCountQuestionsResult.SuccessCreation:
                        _adminViewModel.ErrorMessage = "Success creation CountQuestions.";
                        break;
                    case CreationCountQuestionsResult.EmptyData:
                        _adminViewModel.ErrorMessage = "Enter the data";
                        break;
                    default:
                        _adminViewModel.ErrorMessage = "Creation CountQuestions failed.";
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
