﻿using System;
using System.Globalization;
using UniSales.Core.Enumerations;
using Xamarin.Forms;

namespace UniSales.Core.Converters
{
    public class MenuIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (MenuItemType)value;

            switch (type)
            {
                case MenuItemType.Home:
                    return "ic_home.png";

                case MenuItemType.Contact:
                    return "ic_contact.png";

                case MenuItemType.Products:
                    return "ic_products.png";

                case MenuItemType.ShoppingCart:
                    return "ic_cart.png";

                case MenuItemType.Logout:
                    return "ic_logout.png";

                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Not needed here
            throw new NotImplementedException();
        }
    }
}