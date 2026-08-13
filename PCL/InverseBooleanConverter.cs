using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class InverseBooleanConverter : IValueConverter
{
	public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
	{
		if (value == null)
		{
			return false;
		}
		bool flag = default(bool);
		return bool.TryParse(value.ToString(), out flag) && !flag;
	}

	public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
	{
		if (value == null)
		{
			return false;
		}
		object[] array;
		bool[] array2;
		object obj = NewLateBinding.LateGet((object)null, typeof(bool), "TryParse", array = new object[2]
		{
			value.ToString(),
			value
		}, (string[])null, (System.Type[])null, array2 = new bool[] { false, true });
		if (array2[1])
		{
			value = RuntimeHelpers.GetObjectValue(array[1]);
		}
		return Conversions.ToBoolean(obj) ? Operators.NotObject(value) : ((object)false);
	}
}
