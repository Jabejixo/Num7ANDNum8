using System;
using System.Globalization;
using System.Windows.Data;

namespace MyConverters;

public class AddDaysConverter : IValueConverter
{
    public int DaysToAdd { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        DateTime date;

        if (DateTime.TryParse(value.ToString(), out date))
            date = date.AddDays(DaysToAdd);

        return date.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        // � ������ ������ �������� �������������� �� ���������,
        // ������� ����� ������ ������� �������� ��������
        return value;
    }
}