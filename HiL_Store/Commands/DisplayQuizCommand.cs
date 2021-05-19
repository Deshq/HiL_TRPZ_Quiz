using HiL_Store.Domain.Interfaces;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Commands
{
    public class DisplayQuizCommand : AsyncCommandBase
    {

        private readonly UserViewModel _userViewModel;
        private readonly IGetQuizService _getQuizService;
        private readonly ICountQuestionsService _countQuestionsService;


        public DisplayQuizCommand(UserViewModel userViewModel, IGetQuizService getQuizService, ICountQuestionsService countQuestionsService)
        {
            this._userViewModel = userViewModel;
            this._getQuizService = getQuizService;
            this._countQuestionsService = countQuestionsService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _userViewModel.ErrorMessage = string.Empty;

            var c = await _countQuestionsService.Get(1);

            try
            {
                _userViewModel.GetCollection2 = _getQuizService.GetQuiz(_userViewModel.Category, c.CountOfQuestions);

                _userViewModel.GetCollection2.ToString();

            }
            catch (Exception)
            {
                _userViewModel.ErrorMessage = "Fail";
            }
        }

    }
}
