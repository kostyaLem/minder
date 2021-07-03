using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Minder.ViewModels
{
    /// <summary>
    /// Базовая ViewModel для всех вью моделей
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        // Иконка модели
        public abstract ImageSource PageIcon { get; }

        // Выделена ли вкладка
        public virtual bool IsSelected { get; set; }

        // Заголовок вкладки
        public abstract string PageTitle { get; }

        // Событие уведомления об изменении свойств
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string param = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(param));
        }
    }
}
