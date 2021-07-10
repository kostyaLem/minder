using System.Windows;

namespace Minder
{
    public partial class MainWindow : Window
    {
        public MainWindow(object context)
        {
            InitializeComponent();
            DataContext = context;
        }
    }
}
