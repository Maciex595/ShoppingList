using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace ShoppingList.Converters
{
    public class ProductStateConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return (bool?)value == true ? Colors.Green : Colors.Red;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}