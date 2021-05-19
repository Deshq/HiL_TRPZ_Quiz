using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HiL_Store.Domain.Entities;

namespace HiL_Store.Domain.Interfaces.Authentication
{
    public enum RegistrationResult
    {
        Success,
        SuccessAdmin,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists,
        RoleDoNotMatch,
    }

    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword, string userRole);

        Task<Account> Login(string username, string password);

        Task<Account> LoginAsAdmin(string username, string password);
    }
}
