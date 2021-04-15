using HiL_Store.Domain.Entities;
using HiL_Store.Domain.Entities.QuizEntities;
using HiL_Store.Domain.Interfaces;
using HiL_Store.Domain.Services;
using HiL_Store.EntityFramework;
using HiL_Store.EntityFramework.Services;
using HiL_Store.State.Accounts;
using HiL_Store.State.Authenticators;
using HiL_Store.State.Navigators;
using HiL_Store.ViewModels;
using HiL_Store.ViewModels.Factories;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HiL_Store
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }
        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
           return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(c =>
                {
                     c.AddJsonFile("appsettings.json");
                     c.AddEnvironmentVariables();
                })
                .ConfigureServices((context, services) =>
                {
                    string connectionString = context.Configuration.GetConnectionString("default");
                    services.AddDbContext<HiLDbContext>(o => o.UseSqlServer(connectionString));
                    services.AddSingleton<HiLDbContextCreate>(new HiLDbContextCreate(connectionString));

                    services.AddSingleton<IAuthenticationService, AuthenticationService>();
                    services.AddSingleton<ICategoryCreationService, CategoryCreationService>();
                    services.AddSingleton<IQuizCreationService, QuizCreationService>();
                    services.AddSingleton<IGetQuizService, GetQuizService>();
                    services.AddSingleton<ICountQuestionsCreationService, CountQuestionsCreationService>();
                    services.AddSingleton<IUserResultCreationService, UserResultCreationService>();

                    services.AddSingleton<IGenericDataService<Category>, CategoryDataService>();
                    services.AddSingleton<ICategoryService, CategoryDataService>();
                    services.AddSingleton<IGenericDataService<Quiz>, QuizDataService>();
                    services.AddSingleton<IQuizService, QuizDataService>();
                    services.AddSingleton<IGenericDataService<UserResult>, UserResultDataService>();
                    services.AddSingleton<IUserResultService, UserResultDataService>();

                    services.AddSingleton<IGenericDataService<CategoryQuiz>, CategoryQuizDataService>();
                    services.AddSingleton<ICategoryQuizService, CategoryQuizDataService>();
                    services.AddSingleton<IGenericDataService<CountQuestions>, CountQuestionsDataService>();
                    services.AddSingleton<ICountQuestionsService, CountQuestionsDataService>();
                    services.AddSingleton<IGenericDataService<Account>, AccountDataService>();
                    services.AddSingleton<IAccountService, AccountDataService>();

                    services.AddSingleton<IPasswordHasher, PasswordHasher>();
                    services.AddSingleton<IHiLViewModelFactory, HiLViewModelFactory>();


                    services.AddSingleton<CreateViewModel<MainViewModel>>(services =>
                    {
                        return () => services.GetRequiredService<MainViewModel>();
                    });

                    services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                    services.AddSingleton<ViewModelDelegateRenavigator<MainViewModel>>();
                    services.AddSingleton<ViewModelDelegateRenavigator<AdminViewModel>>();
                    services.AddSingleton<ViewModelDelegateRenavigator<UserViewModel>>();

                    services.AddSingleton<CreateViewModel<UserViewModel>>(services =>
                    {
                        return () => new UserViewModel(
                            services.GetRequiredService<ICategoryService>(),
                            services.GetRequiredService<IGetQuizService>(),
                            services.GetRequiredService<ICountQuestionsService>(),
                            services.GetRequiredService<IUserResultCreationService>(),
                            services.GetRequiredService<IAccountStore>());
                    });

                    services.AddSingleton<CreateViewModel<AdminViewModel>>(services =>
                    {
                         return () => new AdminViewModel(
                             services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                             services.GetRequiredService<ICategoryCreationService>(),
                             services.GetRequiredService<IQuizCreationService>(),
                             services.GetRequiredService<ICountQuestionsCreationService>(),
                             services.GetRequiredService<ICategoryService>());
                     });

                     services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
                     {
                         return () => new LoginViewModel(
                             services.GetRequiredService<IAuthenticator>(),
                             services.GetRequiredService<ViewModelDelegateRenavigator<UserViewModel>>(), //MainViewModel
                             services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                             services.GetRequiredService<ViewModelDelegateRenavigator<AdminViewModel>>());
                     });

                     services.AddSingleton<INavigator, Navigator>();
                     services.AddSingleton<IAuthenticator, Authenticator>();
                     services.AddSingleton<IAccountStore, AccountStore>();
                     services.AddScoped<MainViewModel>();

                     services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

                });

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            Window window = _host.Services.GetRequiredService<MainWindow>();

            window.Show();

            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
