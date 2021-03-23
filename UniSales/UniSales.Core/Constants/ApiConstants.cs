﻿namespace UniSales.Core.Constants
{
    public class ApiConstants
    {
        public const string BaseApiUrl = "http://192.168.0.102:5000/";
        public const string CatalogEndpoint = "api/catalog/products/";
        public const string ProductsOfTheWeekEndpoint = "api/catalog/productsoftheweek/";
        public const string ShoppingCartEndpoint = "api/shoppingcart";
        public const string AddShoppingCartItemEndpoint = "api/shoppingcart/";
        public const string AddContactInfoEndpoint = "api/contact";
        public const string PlaceOrderEndpoint = "api/order";
        public const string RegisterEndpoint = "api/authentication/register";
        public const string AuthenticateEndpoint = "api/authentication/authenticate";
    }
}