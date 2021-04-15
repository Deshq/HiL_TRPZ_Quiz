using HiL_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.State.Navigators
{
    public enum ViewType
    {
        Login,
        Home,
        HomeAdmin,
        HomeUser
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
}
