using HiL_Store.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.ViewModels.Factories
{
    public interface IHiLViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
