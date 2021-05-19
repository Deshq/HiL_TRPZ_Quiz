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
    public class DisplayUserResultCommand : AsyncCommandBase
    {
        private readonly UserViewModel _userViewModel;
        private readonly IUserResultCreationService _userResultCreationService;
        private readonly IAccountStore _accountStore;
        private readonly ICountQuestionsService _countQuestionsService;
        public DisplayUserResultCommand(UserViewModel userViewModel, IUserResultCreationService userResultCreationService, 
            IAccountStore accountStore, ICountQuestionsService countQuestionsService)
        {
            this._userViewModel = userViewModel;
            this._userResultCreationService = userResultCreationService;
            this._accountStore = accountStore;
            this._countQuestionsService = countQuestionsService;
           
        }

        public async override Task ExecuteAsync(object parameter)
        {
            try
            {
                var c = await _countQuestionsService.Get(1);

                _userViewModel.UserResult = await _userResultCreationService.Creation(_accountStore.CurrentAccount,_userViewModel.CountRightAnswer, c.CountOfQuestions);

            }
            catch (Exception)
            {
                _userViewModel.ErrorMessage = "Fail";
            }
        }
    }
}
