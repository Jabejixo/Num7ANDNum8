using System;
using System.Globalization;
using System.Windows.Data;

namespace MyConverters;

public class EnumToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || !value.GetType().IsEnum)
            return null;

        return value.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || parameter == null)
            return null;

        var enumType = targetType.IsNullableType() ? Nullable.GetUnderlyingType(targetType) : targetType;
        return Enum.Parse(enumType, value.ToString());
    }
}