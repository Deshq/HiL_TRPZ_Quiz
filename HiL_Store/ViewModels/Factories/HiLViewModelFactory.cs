using HiL_Store.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.ViewModels.Factories
{
    public class HiLViewModelFactory : IHiLViewModelFactory
    {
        private readonly CreateViewModel<MainViewModel> _createHomeViewModel;

        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        private readonly CreateViewModel<AdminViewModel> _createAdminViewModel;

        private readonly CreateViewModel<UserViewModel> _createUserViewModel;

        public HiLViewModelFactory(CreateViewModel<MainViewModel> createHomeViewModel, CreateViewModel<LoginViewModel> createLoginViewModel, 
            CreateViewModel<AdminViewModel> createAdminViewModel, CreateViewModel<UserViewModel> createUserViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createLoginViewModel = createLoginViewModel;
            _createAdminViewModel = createAdminViewModel;
            _createUserViewModel = createUserViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.HomeAdmin:
                    return _createAdminViewModel();
                case ViewType.HomeUser:
                    return _createUserViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
