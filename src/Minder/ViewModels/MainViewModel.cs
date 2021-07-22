using DevExpress.Mvvm;
using Minder.Commands;
using Minder.Stores;
using Minder.ViewModels.Base;
using System.ComponentModel;
using System.Windows.Input;

namespace Minder.ViewModels
{
    public class MainViewModel : BindableBase, INotifyPropertyChanged
    {
        private readonly INavigator _navigator;

        public BaseViewModel CurrentViewModel => _navigator.CurrentViewModel; 

        public ICommand UpdateCurrentViewModelCommand { get; }        
        qwe
        public MainViewModel(INavigator navigator)
        {
            _navigator = navigator ?? throw new System.ArgumentNullException(nameof(navigator));
            _navigator.StateChanged += OnCurrentViewModelChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_navigator);            
        }

        private void OnCurrentViewModelChanged()
        {
            RaisePropertyChanged(nameof(CurrentViewModel));
        }
    }
}
