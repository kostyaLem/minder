using DevExpress.Mvvm;
using System.Windows.Media;

namespace Minder.ViewModels.Base
{
    public abstract class TitleViewModel : ViewModelBase
    {
        public abstract ImageSource Icon { get; }
        public abstract string Title { get; }
    }
}
