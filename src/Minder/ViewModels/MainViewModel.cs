using DevExpress.Mvvm;
using Minder.Models;
using Minder.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Minder.ViewModels
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public string Title => "test";
        public ObservableCollection<PartModel> PartModels { get; }

        public TitleViewModel SelectedPartViewModel
        {
            get { return GetValue<TitleViewModel>(nameof(SelectedPartViewModel)); }
            set { SetValue(value, nameof(SelectedPartViewModel)); }
        }

        public MainViewModel(IEnumerable<TitleViewModel> viewModels)
        {
            PartModels = new ObservableCollection<PartModel>
            (
                viewModels.Select(vm => new PartModel(this, vm))
            );
            PartModels[0].IsSelected = true;
        }
    }
}
