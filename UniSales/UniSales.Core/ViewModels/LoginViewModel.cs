using System.Windows.Input;
using UniSales.Core.Contracts.Services.Data;
using UniSales.Core.Contracts.Services.General;
using UniSales.Core.ViewModels.Base;
using Xamarin.Forms;

namespace UniSales.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ISettingsService _settingsService;

        private string _userName;
        private string _password;

        public LoginViewModel(IConnectionService connectionService, ISettingsService settingsService,
            INavigationService navigationService,
            IAuthenticationService authenticationService,
            IDialogService dialogService)
            : base(connectionService, navigationService, dialogService)
        {
            _authenticationService = authenticationService;
            _settingsService = settingsService;
        }

        public ICommand LoginCommand => new Command(OnLogin);
        public ICommand RegisterCommand => new Command(OnRegister);

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private async void OnLogin()
        {
            IsBusy = true;
            if (ConnectionService.IsConnected)
            {
                var authenticationResponse = await _authenticationService.Authenticate(UserName, Password);

                if (authenticationResponse.IsAuthenticated)
                {
                    // we store the Id to know if the user is already logged in to the application
                    _settingsService.UserIdSetting = authenticationResponse.User.Id;
                    _settingsService.UserNameSetting = authenticationResponse.User.FirstName;

                    IsBusy = false;
                    await NavigationService.NavigateToAsync<MainViewModel>();
                }
            }
            else
            {
                await DialogService.ShowDialog(
                    "This username/password combination isn't known",
                    "Error logging you in",
                    "OK");
            }
        }

        private void OnRegister()
        {
            NavigationService.NavigateToAsync<RegistrationViewModel>();
        }
    }
}