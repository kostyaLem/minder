using DevExpress.Mvvm;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Minder.ViewModels
{
    /// <summary>
    /// Базовая ViewModel для всех вью моделей
    /// </summary>
    public abstract class ViewModelBase : BindableBase, INotifyPropertyChanged
    {

    }
}