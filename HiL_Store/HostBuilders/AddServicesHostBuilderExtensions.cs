using HiL_Store.Domain.Entities;
using HiL_Store.Domain.Entities.QuizEntities;
using HiL_Store.Domain.Interfaces;
using HiL_Store.Domain.Interfaces.Authentication;
using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.Domain.Services;
using HiL_Store.Domain.Services.Authentication;
using HiL_Store.Domain.Services.CreationService;
using HiL_Store.EntityFramework.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
             host.ConfigureServices((context, services) =>
             {

                 services.AddSingleton<IPasswordHasher, PasswordHasher>();

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

             });

             return host;
        }      
    }
}
