using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Minder.ViewModels
{
    /// <summary>
    /// Базовая ViewModel для всех вью моделей
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        // Событие уведомления об изменении свойств
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string param = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(param));
        }
    }
}