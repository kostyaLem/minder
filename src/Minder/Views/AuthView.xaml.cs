using System.Windows;

namespace Minder.Views
{
    public partial class AuthView : Window
    {
        public AuthView(object context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}
