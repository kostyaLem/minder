using Minder.Stores;
using Minder.ViewModels;
using Minder.ViewModels.Auth;
using Minder.ViewModels.Base;
using Minder.Views;
using System.Collections.Generic;
using System.Windows;

namespace Minder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {       
        public static ViewModelLocator ViewModelLocator { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var viewModels = new Dictionary<ViewType, TitleViewModel>
            {
                [ViewType.EquipmentView] = new EquipmentViewModel(),
                [ViewType.SoftwareView] = new SoftwareViewModel(),
                [ViewType.StaffView] = new StaffViewModel()
            };

            ViewModelLocator = new ViewModelLocator(viewModels);

            var authView = new AuthView
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                DataContext = new AuthViewModel()
            };
            authView.Show();

            base.OnStartup(e);
        }
    }
}
