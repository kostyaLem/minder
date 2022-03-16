using DevExpress.Mvvm;
using HandyControl.Controls;
using Minder.Core.Services.Auth;
using Minder.Helpers.Models;
using Minder.Helpers.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using MessageBox = HandyControl.Controls.MessageBox;

namespace Minder.ViewModels.Auth
{
    public class AuthViewModel : ViewModelBase
    {
        private readonly IAuthService _authService;

        #region Properties

        public string UserName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public DescriptionItemPart SelectedAccountType
        {
            get { return GetValue<DescriptionItemPart>(); }
            set { SetValue(value); }
        }

        public IEnumerable<DescriptionItemPart> AccountTypes =>
            EnumProvider.GetSupportedAccountTypes();

        #endregion

        public ICommand<object> LoginCommand { get; }

        public AuthViewModel(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));

            LoginCommand = new AsyncCommand<object>(LoginAsync);
        }

        private async Task LoginAsync(object passwordControl)
        {
            var passwordBox = passwordControl as PasswordBox;
            var password = passwordBox.Password;

            try
            {
                await _authService.TryLoginAsync(UserName, password, SelectedAccountType.AccountType);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
