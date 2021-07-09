using Minder.Stores;
using Minder.ViewModels;
using Minder.ViewModels.Auth;
using Minder.Views;
using System.Windows;

namespace Minder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new EquipmentViewModel(navigationStore);

            //MainWindow = new MainWindow
            //{
            //    WindowStartupLocation = WindowStartupLocation.CenterScreen,
            //    DataContext = new MainViewModel(navigationStore)
            //};
            //MainWindow.Show();

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
