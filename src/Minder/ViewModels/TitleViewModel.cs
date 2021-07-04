using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Minder.ViewModels
{
    public abstract class TitleViewModel : ViewModelBase
    {
        // Иконка модели
        public abstract ImageSource Icon { get; }

        // Заголовок вкладки
        public abstract string Title { get; }
    }
}
