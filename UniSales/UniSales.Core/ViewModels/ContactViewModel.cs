﻿using System.Windows.Input;
using UniSales.Core.Contracts.Services.Data;
using UniSales.Core.Contracts.Services.General;
using UniSales.Core.Models;
using UniSales.Core.ViewModels.Base;
using Xamarin.Forms;

namespace UniSales.Core.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        private readonly IContactDataService _contactDataService;
        private readonly IPhoneService _phoneService;
        private string _email;
        private string _message;

        public ContactViewModel(IConnectionService connectionService,
            INavigationService navigationService, IDialogService dialogService,
            IContactDataService contactDataService, IPhoneService phoneService)
            : base(connectionService, navigationService, dialogService)
        {
            _contactDataService = contactDataService;
            _phoneService = phoneService;
        }

        public ICommand SubmitMessageCommand => new Command(OnSubmitMessage);
        public ICommand CallPhone => new Command(OnCallPhone);

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
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

        private async void OnSubmitMessage()
        {
            await _contactDataService.AddContactInfo(new ContactInfo() { Message = Message, Email = Email });
            await DialogService.ShowDialog("Thank you for your comment", "Thank you", "OK");
        }

        private void OnCallPhone()
        {
            _phoneService.MakePhoneCall();
        }
    }
}