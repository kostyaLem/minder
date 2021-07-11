using DevExpress.Mvvm;
using Minder.Core.Services.Auth;
using Minder.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Minder.ViewModels.Auth
{
    public class AuthViewModel : BaseViewModel
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

            LoginCommand = new AsyncCommand(Login);
        }

        private async Task Login()
        {
            await _authService.TryLoginAsync(UserName, Password, AccountType.Admin);
        }
    }
}
