using System.Windows.Media;

namespace Minder.ViewModels.Base
{
    public abstract class TitleViewModel : BaseViewModel
    {
        // Иконка модели
        public abstract ImageSource Icon { get; }

        // Заголовок вкладки
        public abstract string Title { get; }
    }
}
