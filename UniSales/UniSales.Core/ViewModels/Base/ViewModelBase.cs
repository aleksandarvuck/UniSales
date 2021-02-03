using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UniSales.Core.Contracts.Services.General;

namespace UniSales.Core.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected readonly IConnectionService ConnectionService;
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;
        private bool _isBusy;

        public ViewModelBase(IConnectionService connectionService, INavigationService navigationService,
                    IDialogService dialogService)
        {
            ConnectionService = connectionService;
            NavigationService = navigationService;
            DialogService = dialogService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public virtual Task InitializeAsync(object data)
        {
            return Task.FromResult(false);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}