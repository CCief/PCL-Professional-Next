using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class InverseBooleanToVisibilityConverter : IValueConverter
{
	public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
	{
		if (value == null)
		{
			return (object)(Visibility)0;
		}
		bool flag = default(bool);
		return (object)(Visibility)(bool.TryParse(value.ToString(), out flag) ? (flag ? 2 : 0) : 0);
	}

	public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
	{
		if (value == null)
		{
			return false;
		}
		return (value is Visibility) ? Operators.CompareObjectNotEqual(value, (object)(Visibility)0, false) : ((object)false);
	}
}
