using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[ContentProperty("Inlines")]
[DesignerGenerated]
public class MyButton : Border, IComponentConnector
{
	public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

	public enum ColorState
	{
		Normal,
		Highlight,
		Red
	}

	[CompilerGenerated]
	private ClickEventHandler ClickEvent;

	public int Uuid;

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyButton), new PropertyMetadata((PropertyChangedCallback)([SpecialName] (DependencyObject sender, DependencyPropertyChangedEventArgs e) =>
	{
		if (sender != null)
		{
			((MyButton)(object)sender).LabText.Text = Conversions.ToString(e.NewValue);
		}
	})));

	private ColorState _ColorType;

	public static readonly DependencyProperty PaddingProperty = DependencyProperty.Register("Padding", typeof(Thickness), typeof(MyButton), new PropertyMetadata((PropertyChangedCallback)([SpecialName] (DependencyObject a0, DependencyPropertyChangedEventArgs a1) =>
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		((VB_0024AnonymousDelegate_1<MyButton, DependencyPropertyChangedEventArgs>)([SpecialName] (MyButton sender, DependencyPropertyChangedEventArgs e) =>
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			if (sender != null)
			{
				Border panFore = sender.PanFore;
				object newValue = e.NewValue;
				panFore.Padding = ((newValue != null) ? ((Thickness)newValue) : default(Thickness));
			}
		}))((MyButton)(object)a0, a1);
	})));

	private const int AnimationColorIn = 100;

	private const int AnimationColorOut = 200;

	public static readonly DependencyProperty EventTypeProperty = DependencyProperty.Register("EventType", typeof(string), typeof(MyButton), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty EventDataProperty = DependencyProperty.Register("EventData", typeof(string), typeof(MyButton), new PropertyMetadata((PropertyChangedCallback)null));

	private bool IsMouseDown;

	private bool _contentLoaded;

	public InlineCollection Inlines => LabText.Inlines;

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

	public Thickness TextPadding
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return LabText.Padding;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			LabText.Padding = value;
		}
	}

	public ColorState ColorType
	{
		get
		{
			return _ColorType;
		}
		set
		{
			_ColorType = value;
			RefreshColor();
		}
	}

	public Thickness Padding
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return PanFore.Padding;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			PanFore.Padding = value;
		}
	}

	public Transform RealRenderTransform
	{
		get
		{
			return ((UIElement)PanFore).RenderTransform;
		}
		set
		{
			((UIElement)PanFore).RenderTransform = value;
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

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual MyButton PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanFore")]
	internal virtual Border PanFore
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabText")]
	internal virtual TextBlock LabText
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
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

	public MyButton()
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
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		((UIElement)this).MouseEnter += new MouseEventHandler(RefreshColor);
		((UIElement)this).MouseLeave += new MouseEventHandler(RefreshColor);
		((FrameworkElement)this).Loaded += new RoutedEventHandler(RefreshColor);
		((UIElement)this).IsEnabledChanged += (DependencyPropertyChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, DependencyPropertyChangedEventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			RefreshColor(RuntimeHelpers.GetObjectValue(a0), a1);
		});
		((UIElement)this).MouseLeftButtonUp += new MouseButtonEventHandler(Button_MouseUp);
		((UIElement)this).MouseLeftButtonDown += new MouseButtonEventHandler(Button_MouseDown);
		((UIElement)this).MouseEnter += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			Button_MouseEnter();
		});
		((UIElement)this).MouseLeftButtonUp += (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
		{
			Button_MouseUp();
		});
		((UIElement)this).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			Button_MouseLeave();
		});
		Uuid = ModBase.GetUuid();
		_ColorType = ColorState.Normal;
		IsMouseDown = false;
		InitializeComponent();
	}

	private void RefreshColor(object obj = null, object e = null)
	{
		try
		{
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				if (((UIElement)this).IsEnabled)
				{
					switch (ColorType)
					{
					case ColorState.Normal:
						if (((UIElement)this).IsMouseOver)
						{
							ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)PanFore, Border.BorderBrushProperty, "ColorBrush3", 100) }, "MyButton Color " + Conversions.ToString(Uuid));
						}
						else
						{
							ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)PanFore, Border.BorderBrushProperty, "ColorBrush1", 200) }, "MyButton Color " + Conversions.ToString(Uuid));
						}
						break;
					case ColorState.Highlight:
						if (((UIElement)this).IsMouseOver)
						{
							ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)PanFore, Border.BorderBrushProperty, "ColorBrush3", 100) }, "MyButton Color " + Conversions.ToString(Uuid));
						}
						else
						{
							ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)PanFore, Border.BorderBrushProperty, "ColorBrush2", 200) }, "MyButton Color " + Conversions.ToString(Uuid));
						}
						break;
					case ColorState.Red:
						if (((UIElement)this).IsMouseOver)
						{
							ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)PanFore, Border.BorderBrushProperty, "ColorBrushRedLight", 100) }, "MyButton Color " + Conversions.ToString(Uuid));
						}
						else
						{
							ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)PanFore, Border.BorderBrushProperty, "ColorBrushRedDark", 200) }, "MyButton Color " + Conversions.ToString(Uuid));
						}
						break;
					}
				}
				else
				{
					ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)PanFore, Border.BorderBrushProperty, ModSecret.ColorGray4 - PanFore.BorderBrush, 200) }, "MyButton Color " + Conversions.ToString(Uuid));
				}
				return;
			}
			ModAnimation.AniStop("MyButton Color " + Conversions.ToString(Uuid));
			if (((UIElement)this).IsEnabled)
			{
				switch (ColorType)
				{
				case ColorState.Normal:
					if (((UIElement)this).IsMouseOver)
					{
						((FrameworkElement)PanFore).SetResourceReference(Border.BorderBrushProperty, (object)"ColorBrush3");
					}
					else
					{
						((FrameworkElement)PanFore).SetResourceReference(Border.BorderBrushProperty, (object)"ColorBrush1");
					}
					break;
				case ColorState.Highlight:
					if (((UIElement)this).IsMouseOver)
					{
						((FrameworkElement)PanFore).SetResourceReference(Border.BorderBrushProperty, (object)"ColorBrush3");
					}
					else
					{
						((FrameworkElement)PanFore).SetResourceReference(Border.BorderBrushProperty, (object)"ColorBrush2");
					}
					break;
				case ColorState.Red:
					if (((UIElement)this).IsMouseOver)
					{
						((FrameworkElement)PanFore).SetResourceReference(Border.BorderBrushProperty, (object)"ColorBrushRedLight");
					}
					else
					{
						((FrameworkElement)PanFore).SetResourceReference(Border.BorderBrushProperty, (object)"ColorBrushRedDark");
					}
					break;
				}
			}
			else
			{
				PanFore.BorderBrush = ModSecret.ColorGray4;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "刷新按钮颜色出错");
			ProjectData.ClearProjectError();
		}
	}

	private void Button_MouseUp(object sender, MouseButtonEventArgs e)
	{
		if (IsMouseDown)
		{
			ModBase.Log("[Control] 按下按钮：" + Text);
			ClickEvent?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
			if (!string.IsNullOrEmpty(Conversions.ToString(((FrameworkElement)this).Tag)) && (ModBase.StartsWithF(((FrameworkElement)this).Tag.ToString(), "链接-") || ModBase.StartsWithF(((FrameworkElement)this).Tag.ToString(), "启动-")))
			{
				ModMain.Hint("主页自定义按钮语法已更新，且不再兼容老版本语法，请查看新的自定义示例！");
			}
			ModEvent.TryStartEvent(EventType, EventData);
		}
	}

	private void Button_MouseDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		IsMouseDown = true;
		base.Focus();
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
		{
			ModAnimation.AaScaleTransform(PanFore, 0.955 - ((ScaleTransform)((UIElement)PanFore).RenderTransform).ScaleX, 80, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.ExtraStrong)),
			ModAnimation.AaScaleTransform(PanFore, -0.01, 700, 0, new ModAnimation.AniEaseOutFluent())
		}, "MyButton Scale " + Conversions.ToString(Uuid));
	}

	private void Button_MouseEnter()
	{
		ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)PanFore, Border.BackgroundProperty, (_ColorType == ColorState.Red) ? "ColorBrushRedBack" : "ColorBrush7", 100), "MyButton Background " + Conversions.ToString(Uuid));
	}

	private void Button_MouseUp()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		if (IsMouseDown)
		{
			IsMouseDown = false;
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(PanFore, 1.0 - ((ScaleTransform)((UIElement)PanFore).RenderTransform).ScaleX, 300, 10, new ModAnimation.AniEaseOutFluent()) }, "MyButton Scale " + Conversions.ToString(Uuid));
		}
	}

	private void Button_MouseLeave()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)PanFore, Border.BackgroundProperty, "ColorBrushHalfWhite", 200), "MyButton Background " + Conversions.ToString(Uuid));
		if (IsMouseDown)
		{
			IsMouseDown = false;
			ModAnimation.AniStart(ModAnimation.AaScaleTransform(PanFore, 1.0 - ((ScaleTransform)((UIElement)PanFore).RenderTransform).ScaleX, 800, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong)), "MyButton Scale " + Conversions.ToString(Uuid));
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	public void InitializeComponent()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/mybutton.xaml", (UriKind)2);
			Application.LoadComponent((object)this, val);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	[EditorBrowsable(/*Could not decode attribute arguments.*/)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyButton)target;
			break;
		case 2:
			PanFore = (Border)target;
			break;
		case 3:
			LabText = (TextBlock)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
