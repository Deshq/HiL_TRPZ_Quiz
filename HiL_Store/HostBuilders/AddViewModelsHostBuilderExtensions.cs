using HiL_Store.Domain.Interfaces;
using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.State.Accounts;
using HiL_Store.State.Authenticators;
using HiL_Store.State.Navigators;
using HiL_Store.ViewModels;
using HiL_Store.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IHiLViewModelFactory, HiLViewModelFactory>();

                services.AddScoped<MainViewModel>();

                services.AddSingleton<CreateViewModel<MainViewModel>>(services => () => services.GetRequiredService<MainViewModel>());
                services.AddSingleton<ViewModelDelegateRenavigator<MainViewModel>>();

                services.AddSingleton<CreateViewModel<UserViewModel>>(services => () => CreateUserViewModel(services));
                services.AddSingleton<ViewModelDelegateRenavigator<UserViewModel>>();

                services.AddSingleton<CreateViewModel<AdminViewModel>>(services => () => CreateAdminViewModel(services));
                services.AddSingleton<ViewModelDelegateRenavigator<AdminViewModel>>();

                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();

            });

            return host;
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(
                        services.GetRequiredService<IAuthenticator>(),
                        services.GetRequiredService<ViewModelDelegateRenavigator<UserViewModel>>(),
                        services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                        services.GetRequiredService<ViewModelDelegateRenavigator<AdminViewModel>>());
        }

        private static AdminViewModel CreateAdminViewModel(IServiceProvider services)
        {
            return new AdminViewModel(
                        services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                        services.GetRequiredService<ICategoryCreationService>(),
                        services.GetRequiredService<IQuizCreationService>(),
                        services.GetRequiredService<ICountQuestionsCreationService>(),
                        services.GetRequiredService<ICategoryService>());
        }

        private static UserViewModel CreateUserViewModel(IServiceProvider services)
        {
            return new UserViewModel(
                        services.GetRequiredService<ICategoryService>(),
                        services.GetRequiredService<IGetQuizService>(),
                        services.GetRequiredService<ICountQuestionsService>(),
                        services.GetRequiredService<IUserResultCreationService>(),
                        services.GetRequiredService<IAccountStore>());
        }
    }
}
