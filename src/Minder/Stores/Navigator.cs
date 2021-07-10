using DevExpress.Mvvm;
using Minder.ViewModels.Base;
using System;

namespace Minder.Stores
{
    /// <summary>
    /// Управление текущим окном
    /// </summary>
    public class Navigator : BindableBase, INavigator
    {
        public BaseViewModel CurrentViewModel
        {
            get => GetValue<BaseViewModel>();
            set
            {
                SetValue(value);
                StateChanged?.Invoke();
            }
        }

        public event Action StateChanged;
    }
}
