using HiL_Store.Commands;
using HiL_Store.State.Authenticators;
using HiL_Store.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HiL_Store.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

		private string _username;
		public string Username
		{
			get
			{
				return _username;
			}
			set
			{
				_username = value;
				OnPropertyChanged(nameof(Username));
			}
		}

		private string _password;
		public string Password
		{
			get
			{
				return _password;
			}
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
			}
		}

		public MessageViewModel ErrorMessageViewModel { get; }

		public string ErrorMessage
		{
			set => ErrorMessageViewModel.Message = value;
		}

		public ICommand LoginCommand { get; }
		public ICommand ViewAdminHomeCommand { get; }

        //------------------------------Register---------------------------///


        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _username2;
        public string Username2
        {
            get
            {
                return _username2;
            }
            set
            {
                _username2 = value;
                OnPropertyChanged(nameof(Username2));
            }
        }

        private string _password2;
        public string Password2
        {
            get
            {
                return _password2;
            }
            set
            {
                _password2 = value;
                OnPropertyChanged(nameof(Password2));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        private string _userRole;
        public string UserRole
        {
            get
            {
                return _userRole;
            }
            set
            {
                _userRole = value;
                OnPropertyChanged(nameof(UserRole));
            }
        }

        public ICommand RegisterCommand { get; }

        public MessageViewModel ErrorMessageViewModel2 { get; }

        public string ErrorMessage2
        {
            set => ErrorMessageViewModel2.Message = value;
        }


        //----------------------------------///


        public LoginViewModel(IAuthenticator authenticator, IRenavigator loginRenavigatorToHome,
            IRenavigator registerRenavigator, IRenavigator loginRenavigatorToAdminHome)
        {

            //-----------Login--------//

            ErrorMessageViewModel = new MessageViewModel();

            LoginCommand = new LoginCommand(this, authenticator, loginRenavigatorToHome);
            ViewAdminHomeCommand = new LoginAdminCommand(this, authenticator, loginRenavigatorToAdminHome);

            //---Register----///

            ErrorMessageViewModel2 = new MessageViewModel();
            RegisterCommand = new RegisterCommand(this, authenticator, registerRenavigator);

        }
    }
}
