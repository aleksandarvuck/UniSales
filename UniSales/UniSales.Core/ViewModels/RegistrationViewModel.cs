﻿using System.Windows.Input;
using UniSales.Core.Contracts.Services.Data;
using UniSales.Core.Contracts.Services.General;
using UniSales.Core.ViewModels.Base;
using Xamarin.Forms;

namespace UniSales.Core.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ISettingsService _settingsService;

        private string _userName;
        private string _firstName;
        private string _lastName;
        private string _password;
        private string _email;

        public RegistrationViewModel(IConnectionService connectionService,
            INavigationService navigationService, IDialogService dialogService,
            IAuthenticationService authenticationService, ISettingsService settingsService)
            : base(connectionService, navigationService, dialogService)
        {
            _authenticationService = authenticationService;
            _settingsService = settingsService;
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
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

        public ICommand RegisterCommand => new Command(OnRegister);
        public ICommand LoginCommand => new Command(OnLogin);

        private async void OnRegister()
        {
            if (ConnectionService.IsConnected)
            {
                var userRegistered = await
                    _authenticationService.Register(_firstName, _lastName, _email, _userName, _password);

                if (userRegistered.IsAuthenticated)
                {
                    await DialogService.ShowDialog("Registration successful", "Message", "OK");
                    _settingsService.UserIdSetting = userRegistered.User.Id;
                    await NavigationService.NavigateToAsync<LoginViewModel>();
                }
            }
        }

        private void OnLogin()
        {
            NavigationService.NavigateToAsync<LoginViewModel>();
        }
    }
}