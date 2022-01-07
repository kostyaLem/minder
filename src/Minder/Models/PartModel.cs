using DevExpress.Mvvm;
using Minder.ViewModels;
using Minder.ViewModels.Base;

namespace Minder.Models
{
    public class PartModel : BindableBase
    {
        private readonly MainViewModel _mainViewModel;

        private TitleViewModel _partViewModel;
        public TitleViewModel PartViewModel
        {
            get => _partViewModel;
            private set
            {
                _partViewModel = value;
                RaisePropertyChanged(nameof(PartViewModel));
            }
        }

        public bool IsSelected
        {
            get { return GetValue<bool>(nameof(IsSelected)); }
            set
            {
                if (value)
                {
                    _mainViewModel.SelectedPartViewModel = PartViewModel;
                }
                SetValue(value, nameof(IsSelected));
            }
        }

        public PartModel(MainViewModel mainViewModel, TitleViewModel partViewModel)
        {
            _mainViewModel = mainViewModel;
            PartViewModel = partViewModel;
        }
    }
}
