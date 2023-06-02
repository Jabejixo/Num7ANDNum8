using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MyConverters;

public class TextLengthToFontWeightConverter : IValueConverter
{
    public FontWeight FontWeightWhenShort { get; set; } = FontWeights.Normal;
    public FontWeight FontWeightWhenLong { get; set; } = FontWeights.Bold;
    public int LengthThreshold { get; set; } = 10;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return FontWeightWhenShort;

        var text = value.ToString();

        if (text.Length < LengthThreshold)
            return FontWeightWhenShort;

        return FontWeightWhenLong;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}