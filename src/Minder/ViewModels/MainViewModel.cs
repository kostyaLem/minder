using Minder.Stores;
using Minder.ViewModels.Base;

namespace Minder.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly Navigator _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(Navigator navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            RaisePropertiesChanged(nameof(CurrentViewModel));
        }
    }
}
