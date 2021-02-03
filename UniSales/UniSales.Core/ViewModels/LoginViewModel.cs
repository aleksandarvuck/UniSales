using UniSales.Core.Contracts.Services.General;
using UniSales.Core.ViewModels.Base;

namespace UniSales.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService) : base(connectionService, navigationService, dialogService)
        {
        }
    }
}