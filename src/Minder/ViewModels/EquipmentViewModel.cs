using Minder.Commands;
using Minder.Stores;
using System;
using System.Windows.Input;
using System.Windows.Media;

namespace Minder.ViewModels
{
    public class EquipmentViewModel : TitleViewModel
    {
        public override ImageSource Icon => throw new NotImplementedException();

        public override string Title => "Оборудование";

        public ICommand NavigateSoftwareCommand { get; }

        public EquipmentViewModel(NavigationStore navigationStore)
        {
            NavigateSoftwareCommand = new NavigateCommand<SoftwareViewModel>(navigationStore, () => new SoftwareViewModel(navigationStore));
        }
    }
}
