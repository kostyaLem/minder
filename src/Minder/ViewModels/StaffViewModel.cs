using Minder.ViewModels.Base;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Minder.ViewModels
{
    public class StaffViewModel : TitleViewModel
    {
        public override ImageSource Icon => new BitmapImage(new Uri("/Resources/Images/admin.png", UriKind.Relative));

        public override string Title => "Staff";
    }
}
