using DevExpress.Mvvm;
using Minder.Core.Services.Auth;
using Minder.Helpers.Models;
using Minder.Helpers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

        public string Password
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

        public ICommand LoginCommand { get; }

        public AuthViewModel(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));

            LoginCommand = new AsyncCommand(LoginAsync);
        }

        private async Task LoginAsync()
        {
            try
            {
                await _authService.TryLoginAsync(UserName, Password, SelectedAccountType.AccountType);
            }
            catch (Exception exc)
            {
                HandyControl.Controls.MessageBox.Show(exc.Message, "Caption", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
            }
        }
    }
}
