using UniSales.Core.Contracts.Services.General;
using UniSales.Core.ViewModels.Base;

namespace UniSales.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel(IConnectionService connectionService, INavigationService navigationService, IDialogService dialogService) : base(connectionService, navigationService, dialogService)
        {
        }
    }
}