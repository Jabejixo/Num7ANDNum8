using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MyConverters;

public class BooleanToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool boolValue = (bool)value;

        if (boolValue)
        {
            // Return a green color if the boolean value is true
            return Brushes.Green;
        }
        else
        {
            // Return a red color if the boolean value is false
            return Brushes.Red;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // We do not need to implement this method for this converter
        throw new NotImplementedException();
    }
}