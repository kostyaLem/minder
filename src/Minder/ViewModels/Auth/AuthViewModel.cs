using DevExpress.Mvvm;
using Minder.Core.Services.Auth;
using System;
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

        public AccountType AccountType
        {
            get { return GetValue<AccountType>(); }
            set { SetValue(value); }
        }

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
                await _authService.TryLoginAsync(UserName, Password, AccountType.Admin);
            }
            catch (Exception)
            {
                HandyControl.Controls.MessageBox.Show("Message box text", "Caption", MessageBoxButton.OK, MessageBoxImage.Question, MessageBoxResult.OK);
            }
        }
    }
}
