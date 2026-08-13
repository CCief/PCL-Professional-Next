using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class MyTextButton : Label
{
	public delegate void ClickEventHandler(object sender, EventArgs e);

	[CompilerGenerated]
	private ClickEventHandler ClickEvent;

	public int Uuid;

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyTextButton), new PropertyMetadata((object)"", (PropertyChangedCallback)([SpecialName] (DependencyObject a0, DependencyPropertyChangedEventArgs a1) =>
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		((VB_0024AnonymousDelegate_1<MyTextButton, DependencyPropertyChangedEventArgs>)([SpecialName] (MyTextButton sender, DependencyPropertyChangedEventArgs e) =>
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(e.OldValue, e.NewValue, false))))
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
				{
					ModAnimation.AaOpacity(sender, 0.0 - ((UIElement)sender).Opacity, 50),
					ModAnimation.AaCode((ThreadStart)([SpecialName] () =>
					{
						((ContentControl)sender).Content = RuntimeHelpers.GetObjectValue(e.NewValue);
					}), 0, After: true),
					ModAnimation.AaOpacity(sender, 1.0, 170)
				}, "MyTextButton Text " + Conversions.ToString(sender.Uuid));
			}
		}))((MyTextButton)(object)a0, a1);
	})));

	public bool IsMouseDown;

	private const int AnimationTimeIn = 100;

	private const int AnimationTimeOut = 200;

	private string ColorName;

	public static readonly DependencyProperty EventTypeProperty = DependencyProperty.Register("EventType", typeof(string), typeof(MyTextButton), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty EventDataProperty = DependencyProperty.Register("EventData", typeof(string), typeof(MyTextButton), new PropertyMetadata((PropertyChangedCallback)null));

	public string Text
	{
		get
		{
			return Conversions.ToString(base.GetValue(TextProperty));
		}
		set
		{
			base.SetValue(TextProperty, (object)value);
		}
	}

	public string EventType
	{
		get
		{
			return Conversions.ToString(base.GetValue(EventTypeProperty));
		}
		set
		{
			base.SetValue(EventTypeProperty, (object)value);
		}
	}

	public string EventData
	{
		get
		{
			return Conversions.ToString(base.GetValue(EventDataProperty));
		}
		set
		{
			base.SetValue(EventDataProperty, (object)value);
		}
	}

	public event ClickEventHandler Click
	{
		[CompilerGenerated]
		add
		{
			ClickEventHandler clickEventHandler = ClickEvent;
			ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				ClickEventHandler clickEventHandler3 = (ClickEventHandler)System.Delegate.Combine((System.Delegate)clickEventHandler2, (System.Delegate)value);
				clickEventHandler = Interlocked.CompareExchange<ClickEventHandler>(ref ClickEvent, clickEventHandler3, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ClickEventHandler clickEventHandler = ClickEvent;
			ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				ClickEventHandler clickEventHandler3 = (ClickEventHandler)System.Delegate.Remove((System.Delegate)clickEventHandler2, (System.Delegate)value);
				clickEventHandler = Interlocked.CompareExchange<ClickEventHandler>(ref ClickEvent, clickEventHandler3, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}
	}

	public MyTextButton()
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
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		((UIElement)this).PreviewMouseLeftButtonDown += new MouseButtonEventHandler(MyTextButton_MouseLeftButtonDown);
		((UIElement)this).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			MyTextButton_MouseLeave();
		});
		((UIElement)this).PreviewMouseLeftButtonUp += new MouseButtonEventHandler(MyTextButton_MouseLeftButtonUp);
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
		((UIElement)this).MouseLeftButtonDown += (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).MouseLeftButtonUp += (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
		{
			RefreshColor();
		});
		Uuid = ModBase.GetUuid();
		IsMouseDown = false;
		base.SetResourceReference(Control.ForegroundProperty, (object)"ColorBrush1");
		((Control)this).Background = ModSecret.ColorSemiTransparent;
	}

	private void MyTextButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		IsMouseDown = true;
		((RoutedEventArgs)e).Handled = true;
	}

	private void MyTextButton_MouseLeave()
	{
		IsMouseDown = false;
	}

	private void MyTextButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		if (IsMouseDown)
		{
			IsMouseDown = false;
			ModBase.Log("[Control] 按下文本按钮：" + Text);
			ClickEvent?.Invoke(this, null);
			ModEvent.TryStartEvent(EventType, EventData);
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private void RefreshColor()
	{
		string text;
		int time;
		if (IsMouseDown)
		{
			text = "ColorBrush4";
			time = 30;
		}
		else if (((UIElement)this).IsMouseOver)
		{
			text = "ColorBrush3";
			time = 100;
		}
		else
		{
			text = "ColorBrush1";
			time = 200;
		}
		if (Operators.CompareString(ColorName, text, false) != 0)
		{
			ColorName = text;
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Control.ForegroundProperty, text, time), "MyTextButton Color " + Conversions.ToString(Uuid));
				return;
			}
			ModAnimation.AniStop("MyTextButton Color " + Conversions.ToString(Uuid));
			base.SetResourceReference(Control.ForegroundProperty, (object)text);
		}
	}
}
