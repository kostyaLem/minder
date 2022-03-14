using Minder.Helpers.Models;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace Minder.Helpers.Services
{
    internal static class EnumProvider
    {
        public static IEnumerable<DescriptionItemPart> GetSupportedAccountTypes() =>
            new[]
            {
                new DescriptionItemPart
                {
                    AccountType = Core.Services.Auth.AccountType.Admin,
                    Caption = "Администратор",
                    Image = new BitmapImage(new Uri("pack://application:,,,/Minder;component/Resources/Images/admin.png"))
                },
                new DescriptionItemPart
                {
                    AccountType = Core.Services.Auth.AccountType.Employee,
                    Caption = "Пользователь",
                    Image = new BitmapImage(new Uri("pack://application:,,,/Minder;component/Resources/Images/researcher.png"))
                }
            };
    }
}
