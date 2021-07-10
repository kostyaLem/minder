using Minder.Core.Services.Auth;
using Minder.ViewModels.Base;
using System;
using System.Windows.Input;

namespace Minder.ViewModels.Auth
{
    public class AuthViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;

        public string UserName
        {
            get { return GetValue<string>(); }
            set { SetValue(value, NotifyInputChanged); }
        }

        public string Password
        {
            get { return GetValue<string>(); }
            set { SetValue(value, NotifyInputChanged); }
        }

        public bool CanLogin { get; private set; }

        public ICommand LoginCommand { get; }

        public AuthViewModel()
        {

        }

        public AuthViewModel(IAuthService authService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        private void NotifyInputChanged()
        {
            CanLogin = !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);

            RaisePropertiesChanged(nameof(CanLogin));
        }
    }
}
