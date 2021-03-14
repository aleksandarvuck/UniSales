using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniSales.Core.Bootstrap;
using UniSales.Core.Contracts.Services.Data;
using UniSales.Core.Contracts.Services.General;
using UniSales.Core.ViewModels;
using UniSales.Core.ViewModels.Base;
using UniSales.Core.Views;
using Xamarin.Forms;

namespace UniSales.Core.Services.General
{
    public class NavigationService : INavigationService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication => Application.Current;

        public NavigationService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public async Task InitializeAsync()
        {
            if (_authenticationService.IsUserAuthenticated())
            {
                await NavigateToAsync<MainViewModel>();
            }
            else
            {
                await NavigateToAsync<LoginViewModel>();
            }
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public async Task ClearBackStack()
        {
            await CurrentApplication.MainPage.Navigation.PopToRootAsync();
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        public async Task NavigateBackAsync()
        {
            if (CurrentApplication.MainPage is MainView mainPage)
            {
                await mainPage.Detail.Navigation.PopAsync();
            }
            else if (CurrentApplication.MainPage != null)
            {
                await CurrentApplication.MainPage.Navigation.PopAsync();
            }
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            if (CurrentApplication.MainPage is MainView mainPage)
            {
                mainPage.Detail.Navigation.RemovePage(
                    mainPage.Detail.Navigation.NavigationStack[mainPage.Detail.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        public async Task PopToRootAsync()
        {
            if (CurrentApplication.MainPage is MainView mainPage)
            {
                await mainPage.Detail.Navigation.PopToRootAsync();
            }
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreateAndBindPage(viewModelType, parameter);

            switch (page)
            {
                case MainView _:
                case RegistrationView _:
                case LoginView _:
                    CurrentApplication.MainPage = page;
                    break;
                default:
                {
                    switch (CurrentApplication.MainPage)
                    {
                        case MainView _:
                        {
                            var mainPage = CurrentApplication.MainPage as MainView;

                            if (mainPage?.Detail is UniSalesNavigationPage navigationPage)
                            {
                                var currentPage = navigationPage.CurrentPage;

                                if (currentPage.GetType() != page.GetType())
                                {
                                    await navigationPage.PushAsync(page);
                                }
                            }
                            else
                            {
                                navigationPage = new UniSalesNavigationPage(page);
                                if (mainPage != null) mainPage.Detail = navigationPage;
                            }

                            if (mainPage != null) mainPage.IsPresented = false;
                            break;
                        }
                        case UniSalesNavigationPage navigationPage:
                            await navigationPage.PushAsync(page);
                            break;
                        default:
                            CurrentApplication.MainPage = new UniSalesNavigationPage(page);
                            break;
                    }

                    break;
                }
            }

            await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            ViewModelBase viewModel = AppContainer.Resolve(viewModelType) as ViewModelBase;
            page.BindingContext = viewModel;

            return page;
        }

        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(LoginViewModel), typeof(LoginView));
            _mappings.Add(typeof(MainViewModel), typeof(MainView));
            _mappings.Add(typeof(MenuViewModel), typeof(MenuView));
            _mappings.Add(typeof(HomeViewModel), typeof(HomeView));
            _mappings.Add(typeof(CheckoutViewModel), typeof(CheckoutView));
            _mappings.Add(typeof(ContactViewModel), typeof(ContactView));
            _mappings.Add(typeof(ProductCatalogViewModel), typeof(ProductCatalogView));
            _mappings.Add(typeof(ProductDetailViewModel), typeof(ProductDetailView));
            _mappings.Add(typeof(RegistrationViewModel), typeof(RegistrationView));
            _mappings.Add(typeof(ShoppingCartViewModel), typeof(ShoppingCartView));
        }
    }
}