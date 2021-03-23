using System.Threading.Tasks;
using System.Windows.Input;
using UniSales.Core.Constants;
using UniSales.Core.Contracts.Services.General;
using UniSales.Core.Models;
using UniSales.Core.ViewModels.Base;
using Xamarin.Forms;

namespace UniSales.Core.ViewModels
{
    public class ProductDetailViewModel : ViewModelBase
    {
        private Product _selectedProduct;

        public ProductDetailViewModel(IConnectionService connectionService,
            INavigationService navigationService, IDialogService dialogService)
            : base(connectionService, navigationService, dialogService)
        { }

        public ICommand AddToCartCommand => new Command(OnAddToCart);
        public ICommand ReadDescriptionCommand => new Command(OnReadDescription);

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public override async Task InitializeAsync(object data)
        {
            SelectedProduct = (Product)data;
        }

        private async void OnAddToCart()
        {
            MessagingCenter.Send(this, MessagingConstants.AddProductToBasket, SelectedProduct);
            await DialogService.ShowDialog("Product added to your cart", "Success", "OK");
        }

        private void OnReadDescription()
        {
            DependencyService.Get<ITextToSpeech>().ReadText(SelectedProduct.LongDescription);
        }
    }
}