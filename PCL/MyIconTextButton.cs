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
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[ContentProperty("Inlines")]
[DesignerGenerated]
public class MyIconTextButton : Border, IComponentConnector
{
	public delegate void CheckEventHandler(object sender, bool raiseByMouse);

	public delegate void ChangeEventHandler(object sender, bool raiseByMouse);

	public enum ColorState
	{
		Black,
		Highlight
	}

	public delegate void ClickEventHandler(object sender, ModBase.RouteEventArgs e);

	public int Uuid;

	[CompilerGenerated]
	private CheckEventHandler CheckEvent;

	[CompilerGenerated]
	private ChangeEventHandler ChangeEvent;

	private double _LogoScale;

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyIconTextButton), new PropertyMetadata((PropertyChangedCallback)([SpecialName] (DependencyObject sender, DependencyPropertyChangedEventArgs e) =>
	{
		if (!Information.IsNothing((object)sender))
		{
			((MyIconTextButton)(object)sender).LabText.Text = Conversions.ToString(e.NewValue);
		}
	})));

	public static readonly DependencyProperty ColorTypeProperty = DependencyProperty.Register("ColorType", typeof(ColorState), typeof(MyIconTextButton), new PropertyMetadata((object)ColorState.Black));

	[CompilerGenerated]
	private ClickEventHandler ClickEvent;

	private bool IsMouseDown;

	public static readonly DependencyProperty EventTypeProperty = DependencyProperty.Register("EventType", typeof(string), typeof(MyIconTextButton), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty EventDataProperty = DependencyProperty.Register("EventData", typeof(string), typeof(MyIconTextButton), new PropertyMetadata((PropertyChangedCallback)null));

	private const int AnimationTimeOfMouseIn = 100;

	private const int AnimationTimeOfMouseOut = 150;

	private bool _contentLoaded;

	public string Logo
	{
		get
		{
			return ShapeLogo.Data.ToString();
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			ShapeLogo.Data = (Geometry)((TypeConverter)new GeometryConverter()).ConvertFromString(value);
		}
	}

	public double LogoScale
	{
		get
		{
			return _LogoScale;
		}
		set
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			_LogoScale = value;
			if (!Information.IsNothing((object)ShapeLogo))
			{
				((UIElement)ShapeLogo).RenderTransform = (Transform)new ScaleTransform
				{
					ScaleX = LogoScale,
					ScaleY = LogoScale
				};
			}
		}
	}

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

	public ColorState ColorType
	{
		get
		{
			return (ColorState)Conversions.ToInteger(base.GetValue(ColorTypeProperty));
		}
		set
		{
			if (ColorType != value)
			{
				base.SetValue(ColorTypeProperty, (object)value);
				RefreshColor();
			}
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
	internal virtual MyIconTextButton PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ShapeLogo")]
	internal virtual Path ShapeLogo
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

	public event CheckEventHandler Check
	{
		[CompilerGenerated]
		add
		{
			CheckEventHandler checkEventHandler = CheckEvent;
			CheckEventHandler checkEventHandler2;
			do
			{
				checkEventHandler2 = checkEventHandler;
				CheckEventHandler checkEventHandler3 = (CheckEventHandler)System.Delegate.Combine((System.Delegate)checkEventHandler2, (System.Delegate)value);
				checkEventHandler = Interlocked.CompareExchange<CheckEventHandler>(ref CheckEvent, checkEventHandler3, checkEventHandler2);
			}
			while (checkEventHandler != checkEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CheckEventHandler checkEventHandler = CheckEvent;
			CheckEventHandler checkEventHandler2;
			do
			{
				checkEventHandler2 = checkEventHandler;
				CheckEventHandler checkEventHandler3 = (CheckEventHandler)System.Delegate.Remove((System.Delegate)checkEventHandler2, (System.Delegate)value);
				checkEventHandler = Interlocked.CompareExchange<CheckEventHandler>(ref CheckEvent, checkEventHandler3, checkEventHandler2);
			}
			while (checkEventHandler != checkEventHandler2);
		}
	}

	public event ChangeEventHandler Change
	{
		[CompilerGenerated]
		add
		{
			ChangeEventHandler changeEventHandler = ChangeEvent;
			ChangeEventHandler changeEventHandler2;
			do
			{
				changeEventHandler2 = changeEventHandler;
				ChangeEventHandler changeEventHandler3 = (ChangeEventHandler)System.Delegate.Combine((System.Delegate)changeEventHandler2, (System.Delegate)value);
				changeEventHandler = Interlocked.CompareExchange<ChangeEventHandler>(ref ChangeEvent, changeEventHandler3, changeEventHandler2);
			}
			while (changeEventHandler != changeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ChangeEventHandler changeEventHandler = ChangeEvent;
			ChangeEventHandler changeEventHandler2;
			do
			{
				changeEventHandler2 = changeEventHandler;
				ChangeEventHandler changeEventHandler3 = (ChangeEventHandler)System.Delegate.Remove((System.Delegate)changeEventHandler2, (System.Delegate)value);
				changeEventHandler = Interlocked.CompareExchange<ChangeEventHandler>(ref ChangeEvent, changeEventHandler3, changeEventHandler2);
			}
			while (changeEventHandler != changeEventHandler2);
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

	public MyIconTextButton()
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
		((UIElement)this).MouseLeftButtonUp += (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
		{
			MyIconTextButton_MouseUp();
		});
		((UIElement)this).MouseLeftButtonDown += (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
		{
			MyIconTextButton_MouseDown();
		});
		((UIElement)this).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			MyIconTextButton_MouseLeave();
		});
		((UIElement)this).MouseEnter += new MouseEventHandler(RefreshColor);
		((FrameworkElement)this).Loaded += new RoutedEventHandler(RefreshColor);
		((UIElement)this).IsEnabledChanged += (DependencyPropertyChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, DependencyPropertyChangedEventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			RefreshColor(RuntimeHelpers.GetObjectValue(a0), a1);
		});
		Uuid = ModBase.GetUuid();
		_LogoScale = 1.0;
		IsMouseDown = false;
		InitializeComponent();
	}

	public void RaiseChange()
	{
		ChangeEvent?.Invoke(this, raiseByMouse: false);
	}

	private void MyIconTextButton_MouseUp()
	{
		if (IsMouseDown)
		{
			ModBase.Log("[Control] 按下带图标按钮：" + Text);
			IsMouseDown = false;
			ClickEvent?.Invoke(this, new ModBase.RouteEventArgs(RaiseByMouse: true));
			ModEvent.TryStartEvent(EventType, EventData);
			RefreshColor();
		}
	}

	private void MyIconTextButton_MouseDown()
	{
		IsMouseDown = true;
		RefreshColor();
	}

	private void MyIconTextButton_MouseLeave()
	{
		IsMouseDown = false;
		RefreshColor();
	}

	private void RefreshColor(object obj = null, object e = null)
	{
		try
		{
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0 && !false.Equals(RuntimeHelpers.GetObjectValue(e)))
			{
				switch (ColorType)
				{
				case ColorState.Black:
					if (IsMouseDown)
					{
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, "ColorBrush6", 70), "MyIconTextButton Color " + Conversions.ToString(Uuid));
					}
					else if (((UIElement)this).IsMouseOver)
					{
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
						{
							ModAnimation.AaColor((FrameworkElement)(object)ShapeLogo, Shape.FillProperty, "ColorBrush3", 100),
							ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, "ColorBrush3", 100)
						}, "MyIconTextButton Checked " + Conversions.ToString(Uuid));
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, "ColorBrushBg1", 100), "MyIconTextButton Color " + Conversions.ToString(Uuid));
					}
					else if (((UIElement)this).IsEnabled)
					{
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
						{
							ModAnimation.AaColor((FrameworkElement)(object)ShapeLogo, Shape.FillProperty, "ColorBrush1", 150),
							ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, "ColorBrush1", 150)
						}, "MyIconTextButton Checked " + Conversions.ToString(Uuid));
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, ModSecret.ColorSemiTransparent - ((Border)this).Background, 150), "MyIconTextButton Color " + Conversions.ToString(Uuid));
					}
					else
					{
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
						{
							ModAnimation.AaColor((FrameworkElement)(object)ShapeLogo, Shape.FillProperty, "ColorBrushGray5", 100),
							ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, "ColorBrushGray5", 100)
						}, "MyIconTextButton Checked " + Conversions.ToString(Uuid));
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, ModSecret.ColorSemiTransparent - ((Border)this).Background, 150), "MyIconTextButton Color " + Conversions.ToString(Uuid));
					}
					break;
				case ColorState.Highlight:
					if (IsMouseDown)
					{
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, "ColorBrush6", 70), "MyIconTextButton Color " + Conversions.ToString(Uuid));
					}
					else if (((UIElement)this).IsMouseOver)
					{
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
						{
							ModAnimation.AaColor((FrameworkElement)(object)ShapeLogo, Shape.FillProperty, "ColorBrush3", 100),
							ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, "ColorBrush3", 100)
						}, "MyIconTextButton Checked " + Conversions.ToString(Uuid));
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, "ColorBrushBg1", 100), "MyIconTextButton Color " + Conversions.ToString(Uuid));
					}
					else if (((UIElement)this).IsEnabled)
					{
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
						{
							ModAnimation.AaColor((FrameworkElement)(object)ShapeLogo, Shape.FillProperty, "ColorBrush3", 150),
							ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, "ColorBrush3", 150)
						}, "MyIconTextButton Checked " + Conversions.ToString(Uuid));
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, ModSecret.ColorSemiTransparent - ((Border)this).Background, 150), "MyIconTextButton Color " + Conversions.ToString(Uuid));
					}
					else
					{
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
						{
							ModAnimation.AaColor((FrameworkElement)(object)ShapeLogo, Shape.FillProperty, "ColorBrushGray5", 100),
							ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, "ColorBrushGray5", 100)
						}, "MyIconTextButton Checked " + Conversions.ToString(Uuid));
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, ModSecret.ColorSemiTransparent - ((Border)this).Background, 150), "MyIconTextButton Color " + Conversions.ToString(Uuid));
					}
					break;
				}
			}
			else
			{
				ModAnimation.AniStop("MyIconTextButton Checked " + Conversions.ToString(Uuid));
				ModAnimation.AniStop("MyIconTextButton Color " + Conversions.ToString(Uuid));
				switch (ColorType)
				{
				case ColorState.Black:
					((Border)this).Background = ModSecret.ColorSemiTransparent;
					((FrameworkElement)ShapeLogo).SetResourceReference(Shape.FillProperty, (object)(((UIElement)this).IsEnabled ? "ColorBrush1" : "ColorBrushGray5"));
					((FrameworkElement)LabText).SetResourceReference(TextBlock.ForegroundProperty, (object)(((UIElement)this).IsEnabled ? "ColorBrush1" : "ColorBrushGray5"));
					break;
				case ColorState.Highlight:
					((Border)this).Background = ModSecret.ColorSemiTransparent;
					((FrameworkElement)ShapeLogo).SetResourceReference(Shape.FillProperty, (object)(((UIElement)this).IsEnabled ? "ColorBrush3" : "ColorBrushGray5"));
					((FrameworkElement)LabText).SetResourceReference(TextBlock.ForegroundProperty, (object)(((UIElement)this).IsEnabled ? "ColorBrush3" : "ColorBrushGray5"));
					break;
				}
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "刷新带图标按钮颜色出错");
			ProjectData.ClearProjectError();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/myicontextbutton.xaml", (UriKind)2);
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
			PanBack = (MyIconTextButton)target;
			break;
		case 2:
			ShapeLogo = (Path)target;
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
