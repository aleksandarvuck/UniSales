using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UniSales.Core.Constants;
using UniSales.Core.Contracts.Services.Data;
using UniSales.Core.Contracts.Services.General;
using UniSales.Core.Extensions;
using UniSales.Core.Models;
using UniSales.Core.ViewModels.Base;
using Xamarin.Forms;

namespace UniSales.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly ICatalogDataService _catalogDataService;
        private ObservableCollection<Product> _productsOfTheWeek;

        public HomeViewModel(IConnectionService connectionService,
            INavigationService navigationService,
            IDialogService dialogService,
            ICatalogDataService catalogDataService) : base(connectionService, navigationService, dialogService)
        {
            _catalogDataService = catalogDataService;

            ProductsOfTheWeek = new ObservableCollection<Product>();
        }

        public ICommand ProductTappedCommand => new Command<Product>(OnProductTapped);
        public ICommand AddToCartCommand => new Command<Product>(OnAddToCart);

        public ObservableCollection<Product> ProductsOfTheWeek
        {
            get => _productsOfTheWeek;
            set
            {
                _productsOfTheWeek = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object data)
        {
            ProductsOfTheWeek = (await _catalogDataService.GetProductsOfTheWeekAsync()).ToObservableCollection();
        }

        private void OnProductTapped(Product selectedProduct)
        {
            _navigationService.NavigateToAsync<ProductDetailViewModel>(selectedProduct);
        }

        private async void OnAddToCart(Product selectedProduct)
        {
            MessagingCenter.Send(this, MessagingConstants.AddProductToBasket, selectedProduct);
            await _dialogService.ShowDialog("Product added to your cart", "Success", "OK");
        }
    }
}