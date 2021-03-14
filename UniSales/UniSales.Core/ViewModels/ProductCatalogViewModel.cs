using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UniSales.Core.Contracts.Services.Data;
using UniSales.Core.Contracts.Services.General;
using UniSales.Core.Extensions;
using UniSales.Core.Models;
using UniSales.Core.ViewModels.Base;
using Xamarin.Forms;

namespace UniSales.Core.ViewModels
{
    public class ProductCatalogViewModel : ViewModelBase
    {
        private readonly ICatalogDataService _catalogDataService;

        private ObservableCollection<Product> _products;

        public ProductCatalogViewModel(IConnectionService connectionService,
            INavigationService navigationService, IDialogService dialogService,
            ICatalogDataService catalogDataService)
            : base(connectionService, navigationService, dialogService)
        {
            _catalogDataService = catalogDataService;
        }

        public ICommand ProductTappedCommand => new Command<Product>(OnProductTapped);

        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }

        private void OnProductTapped(Product selectedProduct)
        {
            _navigationService.NavigateToAsync<ProductDetailViewModel>(selectedProduct);
        }

        public override async Task InitializeAsync(object data)
        {
            IsBusy = true;

            Products = (await _catalogDataService.GetAllProductsAsync()).ToObservableCollection();

            IsBusy = false;
        }
    }
}