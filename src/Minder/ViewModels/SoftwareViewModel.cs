using Minder.Commands;
using Minder.Stores;
using System;
using System.Windows.Input;
using System.Windows.Media;

namespace Minder.ViewModels
{
    public class SoftwareViewModel : TitleViewModel
    {
        public override ImageSource Icon => throw new NotImplementedException();

        public override string Title => "Программное обеспечение";

        public ICommand NavigationEquipmentCommand { get; }

        public SoftwareViewModel(NavigationStore navigationStore)
        {
            NavigationEquipmentCommand = new NavigateCommand<EquipmentViewModel>(navigationStore, () => new EquipmentViewModel(navigationStore));
        }

    }
}
