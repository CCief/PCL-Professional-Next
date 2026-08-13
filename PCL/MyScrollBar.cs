using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class MyScrollBar : ScrollBar
{
	public int Uuid;

	public MyScrollBar()
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
		((UIElement)this).IsEnabledChanged += (DependencyPropertyChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, DependencyPropertyChangedEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).GotMouseCapture += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).LostMouseCapture += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).MouseEnter += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).IsVisibleChanged += (DependencyPropertyChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, DependencyPropertyChangedEventArgs a1) =>
		{
			RefreshColor();
		});
		Uuid = ModBase.GetUuid();
	}

	private void RefreshColor()
	{
		try
		{
			double num;
			int time;
			string text;
			if (!((UIElement)this).IsVisible)
			{
				num = 0.0;
				time = 20;
				text = "ColorBrush4";
			}
			else if (((UIElement)this).IsMouseCaptureWithin)
			{
				num = 1.0;
				text = "ColorBrush4";
				time = 50;
			}
			else if (((UIElement)this).IsMouseOver)
			{
				num = 0.9;
				text = "ColorBrush3";
				time = 130;
			}
			else
			{
				num = 0.5;
				text = "ColorBrush4";
				time = 180;
			}
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaColor((FrameworkElement)(object)this, Control.ForegroundProperty, text, time),
					ModAnimation.AaOpacity(this, num - ((UIElement)this).Opacity, time)
				}, "MyScrollBar Color " + Conversions.ToString(Uuid));
			}
			else
			{
				ModAnimation.AniStop("MyScrollBar Color " + Conversions.ToString(Uuid));
				base.SetResourceReference(Control.ForegroundProperty, (object)text);
				((UIElement)this).Opacity = num;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "滚动条颜色改变出错");
			ProjectData.ClearProjectError();
		}
	}
}
