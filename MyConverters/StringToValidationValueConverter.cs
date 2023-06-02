using System;
using System.Globalization;
using System.Windows.Data;

namespace MyConverters;

public class StringToValidationValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value?.ToString() ?? "";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var stringValue = value as string;

        if (string.IsNullOrEmpty(stringValue))
            return null;

        var targetTypeUnderlyingType = Nullable.GetUnderlyingType(targetType) ?? targetType;

        try
        {
            return System.ComponentModel.TypeDescriptor.GetConverter(targetTypeUnderlyingType).ConvertFromString(stringValue);
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Invalid value '{stringValue}'", ex);
        }
    }
}