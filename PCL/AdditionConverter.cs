using System;
using System.Globalization;
using System.Windows.Data;

namespace PCL;

public class AdditionConverter : IValueConverter
{
	public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
	{
		if (value == null)
		{
			return 0;
		}
		double num = default(double);
		if (!double.TryParse(value.ToString(), out num))
		{
			return 0;
		}
		double num2 = 1.0;
		if (parameter != null)
		{
			double.TryParse(parameter.ToString(), out num2);
		}
		return num + num2;
	}

	public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
	{
		if (value == null)
		{
			return Binding.DoNothing;
		}
		double num = default(double);
		if (!double.TryParse(value.ToString(), out num))
		{
			return Binding.DoNothing;
		}
		double num2 = 1.0;
		if (parameter != null)
		{
			double.TryParse(parameter.ToString(), out num2);
		}
		if (num2 == 0.0)
		{
			return Binding.DoNothing;
		}
		return num - num2;
	}
}
