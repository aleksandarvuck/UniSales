using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UniSales.Core.Contracts.Services.General;

namespace UniSales.Core.ViewModels.Base
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected readonly IConnectionService ConnectionService;
        protected readonly INavigationService NavigationService;
        protected readonly IDialogService DialogService;

        public ViewModelBase(IConnectionService connectionService, INavigationService navigationService,
            IDialogService dialogService)
        {
            ConnectionService = connectionService;
            NavigationService = navigationService;
            DialogService = dialogService;
        }

        private bool _isBusy;

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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task InitializeAsync(object data)
        {
            return Task.FromResult(false);
        }
    }
}