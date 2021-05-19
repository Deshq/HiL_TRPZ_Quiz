using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Commands
{
    public class QuizCreationCommand : AsyncCommandBase
    {

        private readonly AdminViewModel _adminViewModel;
        private readonly IQuizCreationService _quizCreationService;

        public QuizCreationCommand(AdminViewModel adminViewModel, IQuizCreationService quizCreationService)
        {
            this._adminViewModel = adminViewModel;
            this._quizCreationService = quizCreationService;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            _adminViewModel.ErrorMessage2 = string.Empty;

            try
            {
                CreationQuizResult result = await _quizCreationService.Creation(_adminViewModel.Question, _adminViewModel.AnswerA,
                    _adminViewModel.AnswerB, _adminViewModel.AnswerC, _adminViewModel.AnswerD,
                    _adminViewModel.CorrectAns, _adminViewModel.Category);

                switch (result)
                {
                    case CreationQuizResult.SuccessCreation:
                        _adminViewModel.ErrorMessage2 = "Success creation quiz.";
                        break;
                    case CreationQuizResult.EmptyData:
                        _adminViewModel.ErrorMessage2 = "Enter the data";
                        break;
                    case CreationQuizResult.QuestionAlreadyExists:
                        _adminViewModel.ErrorMessage2 = "Question already exist.";
                        break;
                    case CreationQuizResult.CorrectAnswerDoNotMatch:
                        _adminViewModel.ErrorMessage2 = "Correct answer do not match.";
                        break;
                    default:
                        _adminViewModel.ErrorMessage2 = "Creation quiz failed.";
                        break;
                }
            }
            catch (Exception)
            {
                _adminViewModel.ErrorMessage2 = "Failed";
            }
        }
    }
}
