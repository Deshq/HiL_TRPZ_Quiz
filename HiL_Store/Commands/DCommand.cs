using HiL_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Commands
{
    public class DCommand : AsyncCommandBase
    {
        private readonly UserViewModel _userViewModel;
        public DCommand(UserViewModel userViewModel)
        {
            this._userViewModel = userViewModel;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            try
            {
                if (_userViewModel.Category2.Quiz.AnswerD == _userViewModel.Category2.Quiz.CorrectAnswer)
                {
                    _userViewModel.CountRightAnswer += 1;
                }

            }
            catch (Exception)
            {
                _userViewModel.ErrorMessage = "Fail";
            }
        }
    }
}
