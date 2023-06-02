using System;
using System.Globalization;
using System.Windows.Data;

namespace MyConverters;

public class BooleanToStringConverter : IValueConverter
{
    public string TrueString { get; set; } = "Yes";
    public string FalseString { get; set; } = "No";

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool booleanValue;

        if (bool.TryParse(value.ToString(), out booleanValue))
            return booleanValue ? TrueString : FalseString;

        return FalseString;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string stringValue = value.ToString();

        if (stringValue == TrueString)
            return true;
        else if (stringValue == FalseString)
            return false;

        throw new ArgumentException($"Invalid string value: {value}");
    }
}