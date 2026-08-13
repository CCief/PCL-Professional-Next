using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public static class PCLVerCompat
{
	public static int VerToInt(string v)
	{
		if (v != null)
		{
			string[] array = v.Split(".", (StringSplitOptions)0);
			if (array.Length >= 2)
			{
				double num = ModBase.Val(array[0]);
				double num2 = ModBase.Val(ModBase.BeforeFirst(array[1], "-"));
				if (num == 1.0)
				{
					return (int)num2;
				}
				if (num >= 26.0 && num <= 99.0)
				{
					return (int)(num * 100.0 + num2);
				}
			}
		}
		return 0;
	}

	public static double VerToDouble(string v)
	{
		return VerToInt(v);
	}

	public static string VerStr(int v)
	{
		if (v >= 100)
		{
			return Conversions.ToString(v / 100) + "." + Conversions.ToString(v % 100);
		}
		return "1." + Conversions.ToString(v);
	}

	public static bool IsCal(string s)
	{
		if (VerToInt(s) < 2600)
		{
			return false;
		}
		return true;
	}

	public static bool StartsWithVerF(string s, string p, bool ic)
	{
		if (!ModBase.StartsWithF(s, p, ic))
		{
			if (p == "1.")
			{
				return IsCal(s);
			}
			return false;
		}
		return true;
	}

	public static bool StartsWithVer2(string s, string p)
	{
		return StartsWithVerF(s, p, ic: false);
	}

	public static void SetProBadge(FormMain main)
	{
		try
		{
			if (main == null)
			{
				return;
			}
			Border proLogo = main.ProLogo;
			if (proLogo != null)
			{
				((FrameworkElement)proLogo).Width = 38.0;
				UIElement child = ((Decorator)proLogo).Child;
				TextBlock val = (TextBlock)(object)((child is TextBlock) ? child : null);
				if (val != null)
				{
					val.Text = "Pro-N";
				}
			}
		}
		catch (System.Exception)
		{
		}
	}
}
