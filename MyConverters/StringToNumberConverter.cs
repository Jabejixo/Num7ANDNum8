using System;
using System.Globalization;
using System.Windows.Data;

namespace MyConverters;

public class StringToNumberConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var stringValue = value as string;

        if (stringValue == null)
            return null;

        double result;
        if (double.TryParse(stringValue, out result))
            return result;

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var numberValue = value as double?;

        if (numberValue == null)
            return "";

        return numberValue.Value.ToString();
    }
}