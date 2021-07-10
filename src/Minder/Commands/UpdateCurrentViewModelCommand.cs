using Minder.Stores;
using System;
using System.Windows.Input;

namespace Minder.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly INavigator _navigator;

        public event EventHandler CanExecuteChanged;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var viewType = (ViewType)parameter;

            _navigator.CurrentViewModel = App.ViewModelLocator[viewType];                  
        }
    }
}