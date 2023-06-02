using System;
using System.Globalization;
using System.Windows.Data;

namespace MyConverters;

public class CurrencyConverter : IValueConverter
{
    private const string CurrencySymbol = "\u0024";
    private const int DefaultDecimals = 2;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || !(value is double))
            return null;

        var decimals = DefaultDecimals;
        if (parameter != null && int.TryParse(parameter.ToString(), out int paramDecimals))
            decimals = paramDecimals;

        return $"{CurrencySymbol}{((double)value).ToString($"N{decimals}", culture)}";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || !(value is string))
            return null;

        string stringValue = ((string)value).Replace(CurrencySymbol, "");
        if (double.TryParse(stringValue, NumberStyles.Currency, culture, out double doubleValue))
            return doubleValue;

        return null;
    }
}