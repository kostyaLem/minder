using Minder.ViewModels;
using Minder.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Minder.Stores
{
    public enum ViewType
    {
        EquipmentView,
        SoftwareView,
        StaffView
    }

    public class Navigator : INavigator
    {


        public ViewModelBase CurrentViewModel => throw new NotImplementedException();

        public ICommand UpdateCurrentViewModelCommand => throw new NotImplementedException();
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; }

        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
