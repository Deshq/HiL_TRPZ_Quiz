using HiL_Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.State.Accounts
{
    public interface IAccountStore
    {
        Account CurrentAccount { get; set; }
        event Action StateChanged;
    }
}
