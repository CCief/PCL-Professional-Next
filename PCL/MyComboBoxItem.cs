using System.Collections;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class MyComboBoxItem : ComboBoxItem
{
	public int Uuid;

	private const int AnimationTimeIn = 100;

	private const int AnimationTimeOut = 300;

	private string BackColorName;

	private double FontOpacity;

	public MyComboBoxItem()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		((ListBoxItem)this).Unselected += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).MouseMove += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		});
		((ListBoxItem)this).Selected += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).IsEnabledChanged += (DependencyPropertyChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, DependencyPropertyChangedEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).MouseLeftButtonUp += new MouseButtonEventHandler(MyComboBoxItem_MouseLeftButtonUp);
		Uuid = ModBase.GetUuid();
		((FrameworkElement)this).Style = (Style)base.FindResource((object)"MyComboBoxItem");
	}

	private void RefreshColor()
	{
		string text;
		double num;
		int time;
		if (((ListBoxItem)this).IsSelected)
		{
			text = "ColorBrush6";
			num = 1.0;
			time = 100;
		}
		else if (((UIElement)this).IsMouseOver)
		{
			text = "ColorBrush8";
			num = 1.0;
			time = 100;
		}
		else if (((UIElement)this).IsEnabled)
		{
			text = "ColorBrushTransparent";
			num = 1.0;
			time = 300;
		}
		else
		{
			text = "ColorBrushTransparent";
			num = 0.4;
			time = 300;
		}
		if (Operators.CompareString(BackColorName, text, false) != 0 || FontOpacity != num)
		{
			BackColorName = text;
			FontOpacity = num;
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaColor((FrameworkElement)(object)this, Control.BackgroundProperty, BackColorName, time),
					ModAnimation.AaOpacity(this, FontOpacity - ((UIElement)this).Opacity, time)
				}, "ComboBoxItem Color " + Conversions.ToString(Uuid));
			}
			else
			{
				ModAnimation.AniStop("ComboBoxItem Color " + Conversions.ToString(Uuid));
				base.SetResourceReference(Control.BackgroundProperty, (object)BackColorName);
				((UIElement)this).Opacity = FontOpacity;
			}
		}
	}

	public override string ToString()
	{
		return ((ContentControl)this).Content.ToString();
	}

	public static implicit operator string(MyComboBoxItem Value)
	{
		return ((ContentControl)Value).Content.ToString();
	}

	private void MyComboBoxItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		ModBase.Log("[Control] 选择下拉列表项：" + ToString());
	}
}
