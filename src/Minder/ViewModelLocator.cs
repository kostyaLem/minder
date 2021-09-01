using Minder.ViewModels;

namespace Minder
{
    public class ViewModelLocator
    {
        public static EquipmentViewModel EquipmentViewModel => App.Resolve<EquipmentViewModel>();
        public static SoftwareViewModel SoftwareViewModel => App.Resolve<SoftwareViewModel>();
        public static StaffViewModel StaffViewModel => App.Resolve<StaffViewModel>();

        public static MainViewModel MainViewModel => App.Resolve<MainViewModel>();
    }
}
