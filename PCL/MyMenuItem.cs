using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class MyMenuItem : MenuItem
{
	public int Uuid;

	private const int AnimationTimeIn = 100;

	private const int AnimationTimeOut = 200;

	private string ColorName;

	public MyMenuItem()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(MyMenuItem_Loaded);
		((UIElement)this).MouseEnter += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).IsEnabledChanged += (DependencyPropertyChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, DependencyPropertyChangedEventArgs a1) =>
		{
			RefreshColor();
		});
		Uuid = ModBase.GetUuid();
	}

	private void MyMenuItem_Loaded(object sender, RoutedEventArgs e)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		if (((MenuItem)this).Icon != null)
		{
			Path val = (Path)base.GetTemplateChild("Icon");
			if (val != null)
			{
				val.Data = (Geometry)((TypeConverter)new GeometryConverter()).ConvertFromString(Conversions.ToString(((MenuItem)this).Icon));
			}
		}
		((UIElement)(ContextMenu)((FrameworkElement)this).Parent).Opacity = Conversions.ToDouble(Operators.AddObject(Operators.DivideObject(ModBase.Setup.Get("UiLauncherTransparent"), (object)1000), (object)0.4));
	}

	private void RefreshColor()
	{
		string text;
		string text2;
		int time;
		if (!((UIElement)this).IsEnabled)
		{
			text = "ColorBrushTransparent";
			text2 = "ColorBrushGray5";
			time = 200;
		}
		else if (((UIElement)this).IsMouseOver)
		{
			text = "ColorBrush6";
			text2 = "ColorBrush2";
			time = 100;
		}
		else
		{
			text = "ColorBrushTransparent";
			text2 = "ColorBrush1";
			time = 200;
		}
		if (Operators.CompareString(ColorName, text, false) != 0)
		{
			ColorName = text;
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaColor((FrameworkElement)(object)this, Control.BackgroundProperty, text, time),
					ModAnimation.AaColor((FrameworkElement)(object)this, Control.ForegroundProperty, text2, time)
				}, "MyMenuItem Color " + Conversions.ToString(Uuid));
			}
			else
			{
				ModAnimation.AniStop("MyMenuItem Color " + Conversions.ToString(Uuid));
				base.SetResourceReference(Control.BackgroundProperty, (object)text);
				base.SetResourceReference(Control.ForegroundProperty, (object)text2);
			}
		}
	}
}
