using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace ShoppingList.Converters
{
    public class BooleanToTextDecorationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isBought)
            {
                return isBought ? TextDecorations.Strikethrough : null;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}