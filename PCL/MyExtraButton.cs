using System;
using System.CodeDom.Compiler;
using System.Collections;
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
public class MyExtraButton : Grid, IComponentConnector
{
	public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

	public delegate void RightClickEventHandler(object sender, MouseButtonEventArgs e);

	public delegate bool ShowCheckDelegate();

	[CompilerGenerated]
	private ClickEventHandler ClickEvent;

	[CompilerGenerated]
	private RightClickEventHandler RightClickEvent;

	private double _Progress;

	public int Uuid;

	private string _Logo;

	private double _LogoScale;

	private bool _Show;

	public ShowCheckDelegate ShowCheck;

	private bool _CanRightClick;

	private bool IsLeftMouseHeld;

	private bool IsRightMouseHeld;

	private const int AnimationColorIn = 120;

	private const int AnimationColorOut = 150;

	[CompilerGenerated]
	[AccessedThroughProperty("PanClick")]
	private Border _PanClick;

	private bool _contentLoaded;

	public double Progress
	{
		get
		{
			return _Progress;
		}
		set
		{
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			if (_Progress != value)
			{
				_Progress = value;
				if (value < 0.0001)
				{
					((UIElement)PanProgress).Visibility = (Visibility)2;
					return;
				}
				((UIElement)PanProgress).Visibility = (Visibility)0;
				RectProgress.Rect = new Rect(0.0, 40.0 * (1.0 - value), 40.0, 40.0 * value);
			}
		}
	}

	public string Logo
	{
		get
		{
			return _Logo;
		}
		set
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			if (Operators.CompareString(value, _Logo, false) != 0)
			{
				_Logo = value;
				Path.Data = (Geometry)((TypeConverter)new GeometryConverter()).ConvertFromString(value);
			}
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

	public bool Show
	{
		get
		{
			return _Show;
		}
		set
		{
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Expected O, but got Unknown
			if (_Show == value)
			{
				return;
			}
			_Show = value;
			ModBase.RunInUi((Action)([SpecialName] () =>
			{
				//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
				//IL_0150: Unknown result type (might be due to invalid IL or missing references)
				//IL_015c: Expected O, but got Unknown
				//IL_0039: Unknown result type (might be due to invalid IL or missing references)
				if (value)
				{
					((UIElement)this).Visibility = (Visibility)0;
					ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
					{
						ModAnimation.AaScaleTransform(this, 0.3 - ((ScaleTransform)((UIElement)this).RenderTransform).ScaleX, 500, 60, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)),
						ModAnimation.AaScaleTransform(this, 0.7, 500, 60, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)),
						ModAnimation.AaHeight(this, 50.0 - ((FrameworkElement)this).Height, 200, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak))
					}, "MyExtraButton MainScale " + Conversions.ToString(Uuid));
				}
				else
				{
					ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
					{
						ModAnimation.AaScaleTransform(this, 0.0 - ((ScaleTransform)((UIElement)this).RenderTransform).ScaleX, 100, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)),
						ModAnimation.AaHeight(this, 0.0 - ((FrameworkElement)this).Height, 400, 100, new ModAnimation.AniEaseOutFluent()),
						ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
						{
							((UIElement)this).Visibility = (Visibility)2;
						}), 0, After: true)
					}, "MyExtraButton MainScale " + Conversions.ToString(Uuid));
				}
				((UIElement)this).IsHitTestVisible = value;
			}));
		}
	}

	public bool CanRightClick
	{
		get
		{
			return _CanRightClick;
		}
		set
		{
			_CanRightClick = value;
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual MyExtraButton PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Border PanClick
	{
		[CompilerGenerated]
		get
		{
			return _PanClick;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Expected O, but got Unknown
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(Button_LeftMouseUp);
			MouseButtonEventHandler val2 = new MouseButtonEventHandler(Button_RightMouseUp);
			MouseButtonEventHandler val3 = new MouseButtonEventHandler(Button_LeftMouseDown);
			MouseButtonEventHandler val4 = new MouseButtonEventHandler(Button_RightMouseDown);
			MouseButtonEventHandler val5 = (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				Button_LeftMouseUp();
			});
			MouseButtonEventHandler val6 = (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				Button_RightMouseUp();
			});
			MouseEventHandler val7 = (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
			{
				Button_MouseLeave();
			});
			MouseEventHandler val8 = (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
			{
				RefreshColor();
			});
			MouseEventHandler val9 = (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
			{
				RefreshColor();
			});
			Border panClick = _PanClick;
			if (panClick != null)
			{
				((UIElement)panClick).MouseLeftButtonUp -= val;
				((UIElement)panClick).MouseRightButtonUp -= val2;
				((UIElement)panClick).MouseLeftButtonDown -= val3;
				((UIElement)panClick).MouseRightButtonDown -= val4;
				((UIElement)panClick).MouseLeftButtonUp -= val5;
				((UIElement)panClick).MouseRightButtonUp -= val6;
				((UIElement)panClick).MouseLeave -= val7;
				((UIElement)panClick).MouseEnter -= val8;
				((UIElement)panClick).MouseLeave -= val9;
			}
			_PanClick = value;
			panClick = _PanClick;
			if (panClick != null)
			{
				((UIElement)panClick).MouseLeftButtonUp += val;
				((UIElement)panClick).MouseRightButtonUp += val2;
				((UIElement)panClick).MouseLeftButtonDown += val3;
				((UIElement)panClick).MouseRightButtonDown += val4;
				((UIElement)panClick).MouseLeftButtonUp += val5;
				((UIElement)panClick).MouseRightButtonUp += val6;
				((UIElement)panClick).MouseLeave += val7;
				((UIElement)panClick).MouseEnter += val8;
				((UIElement)panClick).MouseLeave += val9;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanScale")]
	internal virtual Grid PanScale
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanColor")]
	internal virtual Border PanColor
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanProgress")]
	internal virtual Border PanProgress
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("RectProgress")]
	internal virtual RectangleGeometry RectProgress
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

	public event RightClickEventHandler RightClick
	{
		[CompilerGenerated]
		add
		{
			RightClickEventHandler rightClickEventHandler = RightClickEvent;
			RightClickEventHandler rightClickEventHandler2;
			do
			{
				rightClickEventHandler2 = rightClickEventHandler;
				RightClickEventHandler rightClickEventHandler3 = (RightClickEventHandler)System.Delegate.Combine((System.Delegate)rightClickEventHandler2, (System.Delegate)value);
				rightClickEventHandler = Interlocked.CompareExchange<RightClickEventHandler>(ref RightClickEvent, rightClickEventHandler3, rightClickEventHandler2);
			}
			while (rightClickEventHandler != rightClickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			RightClickEventHandler rightClickEventHandler = RightClickEvent;
			RightClickEventHandler rightClickEventHandler2;
			do
			{
				rightClickEventHandler2 = rightClickEventHandler;
				RightClickEventHandler rightClickEventHandler3 = (RightClickEventHandler)System.Delegate.Remove((System.Delegate)rightClickEventHandler2, (System.Delegate)value);
				rightClickEventHandler = Interlocked.CompareExchange<RightClickEventHandler>(ref RightClickEvent, rightClickEventHandler3, rightClickEventHandler2);
			}
			while (rightClickEventHandler != rightClickEventHandler2);
		}
	}

	public MyExtraButton()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).IsEnabledChanged += (DependencyPropertyChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, DependencyPropertyChangedEventArgs a1) =>
		{
			RefreshColor();
		});
		_Progress = 0.0;
		Uuid = ModBase.GetUuid();
		_Logo = "";
		_LogoScale = 1.0;
		_Show = false;
		ShowCheck = null;
		_CanRightClick = false;
		IsLeftMouseHeld = false;
		IsRightMouseHeld = false;
		InitializeComponent();
	}

	public void ShowRefresh()
	{
		if (ShowCheck != null)
		{
			Show = ShowCheck();
		}
	}

	private void Button_LeftMouseUp(object sender, MouseButtonEventArgs e)
	{
		if (IsLeftMouseHeld)
		{
			ModBase.Log("[Control] 按下附加按钮" + (Operators.ConditionalCompareObjectEqual(((FrameworkElement)this).ToolTip, (object)"", false) ? "" : ("：" + ((FrameworkElement)this).ToolTip.ToString())));
			ClickEvent?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
			((RoutedEventArgs)e).Handled = true;
			Button_LeftMouseUp();
		}
	}

	private void Button_RightMouseUp(object sender, MouseButtonEventArgs e)
	{
		if (IsRightMouseHeld)
		{
			ModBase.Log("[Control] 右键按下附加按钮" + (Operators.ConditionalCompareObjectEqual(((FrameworkElement)this).ToolTip, (object)"", false) ? "" : ("：" + ((FrameworkElement)this).ToolTip.ToString())));
			RightClickEvent?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
			((RoutedEventArgs)e).Handled = true;
			Button_RightMouseUp();
		}
	}

	private void Button_LeftMouseDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (!IsLeftMouseHeld && !IsRightMouseHeld)
		{
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
			{
				ModAnimation.AaScaleTransform(PanScale, 0.85 - ((ScaleTransform)((UIElement)PanScale).RenderTransform).ScaleX, 800, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong)),
				ModAnimation.AaScaleTransform(PanScale, -0.05, 60, 0, new ModAnimation.AniEaseOutFluent())
			}, "MyExtraButton Scale " + Conversions.ToString(Uuid));
		}
		IsLeftMouseHeld = true;
		base.Focus();
	}

	private void Button_RightMouseDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		if (CanRightClick)
		{
			if (!IsLeftMouseHeld && !IsRightMouseHeld)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaScaleTransform(PanScale, 0.85 - ((ScaleTransform)((UIElement)PanScale).RenderTransform).ScaleX, 800, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong)),
					ModAnimation.AaScaleTransform(PanScale, -0.05, 60, 0, new ModAnimation.AniEaseOutFluent())
				}, "MyExtraButton Scale " + Conversions.ToString(Uuid));
			}
			IsRightMouseHeld = true;
			base.Focus();
		}
	}

	private void Button_LeftMouseUp()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (!IsRightMouseHeld)
		{
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(PanScale, 1.0 - ((ScaleTransform)((UIElement)PanScale).RenderTransform).ScaleX, 300, 0, new ModAnimation.AniEaseOutBack()) }, "MyExtraButton Scale " + Conversions.ToString(Uuid));
		}
		IsLeftMouseHeld = false;
		RefreshColor();
	}

	private void Button_RightMouseUp()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (CanRightClick)
		{
			if (!IsLeftMouseHeld)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(PanScale, 1.0 - ((ScaleTransform)((UIElement)PanScale).RenderTransform).ScaleX, 300, 0, new ModAnimation.AniEaseOutBack()) }, "MyExtraButton Scale " + Conversions.ToString(Uuid));
			}
			IsRightMouseHeld = false;
			RefreshColor();
		}
	}

	private void Button_MouseLeave()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		IsLeftMouseHeld = false;
		IsRightMouseHeld = false;
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(PanScale, 1.0 - ((ScaleTransform)((UIElement)PanScale).RenderTransform).ScaleX, 500, 0, new ModAnimation.AniEaseOutFluent()) }, "MyExtraButton Scale " + Conversions.ToString(Uuid));
		RefreshColor();
	}

	public void RefreshColor()
	{
		try
		{
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				if (!((UIElement)this).IsEnabled)
				{
					ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)PanColor, Panel.BackgroundProperty, "ColorBrushGray4", 120), "MyExtraButton Color " + Conversions.ToString(Uuid));
				}
				else if (((UIElement)this).IsMouseOver)
				{
					ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)PanColor, Panel.BackgroundProperty, "ColorBrush4", 120), "MyExtraButton Color " + Conversions.ToString(Uuid));
				}
				else
				{
					ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)PanColor, Panel.BackgroundProperty, "ColorBrush3", 150), "MyExtraButton Color " + Conversions.ToString(Uuid));
				}
				return;
			}
			ModAnimation.AniStop("MyExtraButton Color " + Conversions.ToString(Uuid));
			if (!((UIElement)this).IsEnabled)
			{
				((FrameworkElement)PanColor).SetResourceReference(Panel.BackgroundProperty, (object)"ColorBrushGray4");
			}
			else if (((UIElement)this).IsMouseOver)
			{
				((FrameworkElement)PanColor).SetResourceReference(Panel.BackgroundProperty, (object)"ColorBrush4");
			}
			else
			{
				((FrameworkElement)PanColor).SetResourceReference(Panel.BackgroundProperty, (object)"ColorBrush3");
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "刷新图标按钮颜色出错");
			ProjectData.ClearProjectError();
		}
	}

	public void Ribble()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			//IL_0077: Expected O, but got Unknown
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Expected O, but got Unknown
			Border val = new Border
			{
				CornerRadius = new CornerRadius(1000.0),
				BorderThickness = new Thickness(0.001),
				Opacity = 0.5,
				RenderTransformOrigin = new Point(0.5, 0.5),
				RenderTransform = (Transform)new ScaleTransform()
			};
			((FrameworkElement)val).SetResourceReference(Border.BackgroundProperty, (object)"ColorBrush5");
			((Panel)PanScale).Children.Insert(0, (UIElement)(object)val);
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
			{
				ModAnimation.AaScaleTransform(val, 13.0, 1000, 0, new ModAnimation.AniEaseInoutFluent(ModAnimation.AniEasePower.Strong, 0.3)),
				ModAnimation.AaOpacity(val, 0.0 - ((UIElement)val).Opacity, 1000),
				ModAnimation.AaCode((ThreadStart)([SpecialName] () =>
				{
					((Panel)PanScale).Children.Remove((UIElement)(object)val);
				}), 0, After: true)
			}, "ExtraButton Ribble " + Conversions.ToString(ModBase.GetUuid()));
		}));
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/myextrabutton.xaml", (UriKind)2);
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
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyExtraButton)target;
			break;
		case 2:
			PanClick = (Border)target;
			break;
		case 3:
			PanScale = (Grid)target;
			break;
		case 4:
			PanColor = (Border)target;
			break;
		case 5:
			PanProgress = (Border)target;
			break;
		case 6:
			RectProgress = (RectangleGeometry)target;
			break;
		case 7:
			Path = (Path)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
