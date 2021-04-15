﻿using HiL_Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiL_Store.Domain.Interfaces
{
    public interface IAccountService : IGenericDataService<Account>
    {
        Task<Account> GetByUsername(string username);
        Task<Account> GetByEmail(string email);
        Task<Account> GetByRole(string userRole);
    }
}
