using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class MyIconButton : Border, IComponentConnector
{
	public delegate void ClickEventHandler(object sender, EventArgs e);

	public enum Themes
	{
		Color,
		White,
		Black,
		Red,
		Custom
	}

	[CompilerGenerated]
	private ClickEventHandler ClickEvent;

	public int Uuid;

	private double _LogoScale;

	private SolidColorBrush _Foreground;

	public static readonly DependencyProperty EventTypeProperty = DependencyProperty.Register("EventType", typeof(string), typeof(MyIconButton), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty EventDataProperty = DependencyProperty.Register("EventData", typeof(string), typeof(MyIconButton), new PropertyMetadata((PropertyChangedCallback)null));

	private bool IsMouseDown;

	private const int AnimationColorIn = 120;

	private const int AnimationColorOut = 150;

	private bool _contentLoaded;

	public string Logo
	{
		get
		{
			return Path.Data.ToString();
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			Path.Data = (Geometry)((TypeConverter)new GeometryConverter()).ConvertFromString(value);
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
			if (!Information.IsNothing((object)Path))
			{
				((UIElement)Path).RenderTransform = (Transform)new ScaleTransform
				{
					ScaleX = LogoScale,
					ScaleY = LogoScale
				};
			}
		}
	}

	[field: CompilerGenerated]
	public Themes Theme
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public SolidColorBrush Foreground
	{
		get
		{
			return _Foreground;
		}
		set
		{
			_Foreground = value;
			checked
			{
				ModAnimation.AniControlEnabled++;
				RefreshAnim();
				ModAnimation.AniControlEnabled--;
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
	internal virtual Border PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("Path")]
	internal virtual Path Path
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

	public MyIconButton()
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
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		((UIElement)this).MouseLeftButtonUp += new MouseButtonEventHandler(Button_MouseUp);
		((UIElement)this).MouseLeftButtonDown += new MouseButtonEventHandler(Button_MouseDown);
		((UIElement)this).MouseLeftButtonUp += (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
		{
			Button_MouseUp();
		});
		((UIElement)this).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			Button_MouseLeave();
		});
		((UIElement)this).MouseEnter += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			RefreshAnim();
		});
		((UIElement)this).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			RefreshAnim();
		});
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			RefreshAnim();
		});
		Uuid = ModBase.GetUuid();
		_LogoScale = 1.0;
		Theme = Themes.Color;
		_Foreground = new SolidColorBrush(Color.FromRgb((byte)128, (byte)128, (byte)128));
		IsMouseDown = false;
		InitializeComponent();
	}

	private void Button_MouseUp(object sender, MouseButtonEventArgs e)
	{
		if (IsMouseDown)
		{
			ModBase.Log("[Control] 按下图标按钮" + (string.IsNullOrEmpty(((FrameworkElement)this).Name) ? "" : ("：" + ((FrameworkElement)this).Name)));
			ClickEvent?.Invoke(RuntimeHelpers.GetObjectValue(sender), (EventArgs)(object)e);
			((RoutedEventArgs)e).Handled = true;
			Button_MouseUp();
			ModEvent.TryStartEvent(EventType, EventData);
		}
	}

	private void Button_MouseDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		IsMouseDown = true;
		base.Focus();
		ModAnimation.AniStart(ModAnimation.AaScaleTransform(PanBack, 0.8 - ((ScaleTransform)((UIElement)PanBack).RenderTransform).ScaleX, 400, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong)), "MyIconButton Scale " + Conversions.ToString(Uuid));
	}

	private void Button_MouseUp()
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if (IsMouseDown)
		{
			IsMouseDown = false;
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
			{
				ModAnimation.AaScaleTransform(PanBack, 1.05 - ((ScaleTransform)((UIElement)PanBack).RenderTransform).ScaleX, 250, 0, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)),
				ModAnimation.AaScaleTransform(PanBack, -0.05, 250, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong))
			}, "MyIconButton Scale " + Conversions.ToString(Uuid));
		}
		RefreshAnim();
	}

	private void Button_MouseLeave()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		IsMouseDown = false;
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(PanBack, 1.0 - ((ScaleTransform)((UIElement)PanBack).RenderTransform).ScaleX, 250, 0, new ModAnimation.AniEaseOutFluent()) }, "MyIconButton Scale " + Conversions.ToString(Uuid));
		RefreshAnim();
	}

	public void RefreshAnim()
	{
		try
		{
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				if (PanBack.Background == null)
				{
					PanBack.Background = new ModBase.MyColor(0.0, 255.0, 255.0, 255.0);
				}
				if (((Shape)Path).Fill == null)
				{
					switch (Theme)
					{
					case Themes.Red:
						((Shape)Path).Fill = new ModBase.MyColor(160.0, 255.0, 76.0, 76.0);
						break;
					case Themes.Black:
						if (ModSecret.IsDarkMode)
						{
							((Shape)Path).Fill = new ModBase.MyColor(160.0, 255.0, 255.0, 255.0);
						}
						else
						{
							((Shape)Path).Fill = new ModBase.MyColor(160.0, 0.0, 0.0, 0.0);
						}
						break;
					case Themes.Custom:
						((Shape)Path).Fill = new ModBase.MyColor(160.0, Foreground);
						break;
					}
				}
				if (((UIElement)this).IsMouseOver)
				{
					List<ModAnimation.AniData> val = new List<ModAnimation.AniData>();
					switch (Theme)
					{
					case Themes.Color:
						val.Add(ModAnimation.AaColor((FrameworkElement)(object)Path, Shape.FillProperty, "ColorBrush2", 120));
						break;
					case Themes.White:
						val.Add(ModAnimation.AaColor((FrameworkElement)(object)PanBack, Border.BackgroundProperty, new ModBase.MyColor(50.0, 255.0, 255.0, 255.0) - PanBack.Background, 120));
						break;
					case Themes.Red:
						val.Add(ModAnimation.AaColor((FrameworkElement)(object)Path, Shape.FillProperty, new ModBase.MyColor(255.0, 76.0, 76.0) - ((Shape)Path).Fill, 120));
						break;
					case Themes.Black:
						val.Add(ModAnimation.AaColor((FrameworkElement)(object)Path, Shape.FillProperty, (ModSecret.IsDarkMode ? new ModBase.MyColor(230.0, 255.0, 255.0, 255.0) : new ModBase.MyColor(230.0, 0.0, 0.0, 0.0)) - ((Shape)Path).Fill, 120));
						break;
					case Themes.Custom:
						val.Add(ModAnimation.AaColor((FrameworkElement)(object)Path, Shape.FillProperty, new ModBase.MyColor(255.0, Foreground) - ((Shape)Path).Fill, 120));
						break;
					}
					ModAnimation.AniStart((System.Collections.IList)val, "MyIconButton Color " + Conversions.ToString(Uuid));
					return;
				}
				List<ModAnimation.AniData> val2 = new List<ModAnimation.AniData>();
				switch (Theme)
				{
				case Themes.Color:
					val2.Add(ModAnimation.AaColor((FrameworkElement)(object)Path, Shape.FillProperty, "ColorBrush4", 150));
					PanBack.Background = new ModBase.MyColor(0.0, 255.0, 255.0, 255.0);
					break;
				case Themes.White:
					val2.Add(ModAnimation.AaColor((FrameworkElement)(object)Path, Shape.FillProperty, new ModBase.MyColor(234.0, 242.0, 254.0), 150));
					val2.Add(ModAnimation.AaColor((FrameworkElement)(object)PanBack, Border.BackgroundProperty, new ModBase.MyColor(0.0, 255.0, 255.0, 255.0) - PanBack.Background, 150));
					break;
				case Themes.Red:
					val2.Add(ModAnimation.AaColor((FrameworkElement)(object)Path, Shape.FillProperty, new ModBase.MyColor(160.0, 255.0, 76.0, 76.0) - ((Shape)Path).Fill, 150));
					PanBack.Background = new ModBase.MyColor(0.0, 255.0, 255.0, 255.0);
					break;
				case Themes.Black:
					val2.Add(ModAnimation.AaColor((FrameworkElement)(object)Path, Shape.FillProperty, (ModSecret.IsDarkMode ? new ModBase.MyColor(160.0, 255.0, 255.0, 255.0) : new ModBase.MyColor(160.0, 0.0, 0.0, 0.0)) - ((Shape)Path).Fill, 150));
					PanBack.Background = new ModBase.MyColor(0.0, 255.0, 255.0, 255.0);
					break;
				case Themes.Custom:
					val2.Add(ModAnimation.AaColor((FrameworkElement)(object)Path, Shape.FillProperty, new ModBase.MyColor(160.0, Foreground) - ((Shape)Path).Fill, 150));
					PanBack.Background = new ModBase.MyColor(0.0, 255.0, 255.0, 255.0);
					break;
				}
				ModAnimation.AniStart((System.Collections.IList)val2, "MyIconButton Color " + Conversions.ToString(Uuid));
				return;
			}
			ModAnimation.AniStop("MyIconButton Color " + Conversions.ToString(Uuid));
			switch (Theme)
			{
			case Themes.Color:
				((FrameworkElement)Path).SetResourceReference(Shape.FillProperty, (object)"ColorBrush5");
				break;
			case Themes.White:
				((Shape)Path).Fill = new ModBase.MyColor(234.0, 242.0, 254.0);
				break;
			case Themes.Red:
				((Shape)Path).Fill = new ModBase.MyColor(160.0, 255.0, 76.0, 76.0);
				break;
			case Themes.Black:
				if (ModSecret.IsDarkMode)
				{
					((Shape)Path).Fill = new ModBase.MyColor(160.0, 255.0, 255.0, 255.0);
				}
				else
				{
					((Shape)Path).Fill = new ModBase.MyColor(160.0, 0.0, 0.0, 0.0);
				}
				break;
			case Themes.Custom:
				((Shape)Path).Fill = new ModBase.MyColor(160.0, Foreground);
				break;
			}
			PanBack.Background = new ModBase.MyColor(0.0, 255.0, 255.0, 255.0);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "刷新图标按钮动画状态出错");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/myiconbutton.xaml", (UriKind)2);
			Application.LoadComponent((object)this, val);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	[EditorBrowsable(/*Could not decode attribute arguments.*/)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (Border)target;
			break;
		case 2:
			Path = (Path)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
