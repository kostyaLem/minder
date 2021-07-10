using Minder.ViewModels.Base;
using System;
using System.Windows.Input;

namespace Minder.Stores
{
    /// <summary>
    /// Интерфейс управления текущим окном
    /// </summary>
    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }

        event Action StateChanged;
    }
}
