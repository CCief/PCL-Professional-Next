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
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[ContentProperty("Inlines")]
[DesignerGenerated]
public class MyExtraTextButton : Grid, IComponentConnector
{
	public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

	[CompilerGenerated]
	private ClickEventHandler ClickEvent;

	public int Uuid;

	private string _Logo;

	private double _LogoScale;

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyExtraTextButton), new PropertyMetadata((PropertyChangedCallback)([SpecialName] (DependencyObject sender, DependencyPropertyChangedEventArgs e) =>
	{
		if (sender != null)
		{
			((MyExtraTextButton)(object)sender).LabText.Text = Conversions.ToString(e.NewValue);
		}
	})));

	private bool _Show;

	private bool IsLeftMouseHeld;

	private const int AnimationColorIn = 120;

	private const int AnimationColorOut = 150;

	[CompilerGenerated]
	[AccessedThroughProperty("PanClick")]
	private Border _PanClick;

	private bool _contentLoaded;

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
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Expected O, but got Unknown
			_LogoScale = value;
			if (Path != null)
			{
				((UIElement)Path).RenderTransform = (Transform)new ScaleTransform
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
				//IL_0119: Unknown result type (might be due to invalid IL or missing references)
				//IL_006e: Unknown result type (might be due to invalid IL or missing references)
				if (value)
				{
					((UIElement)this).Opacity = 0.0;
					ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
					{
						ModAnimation.AaOpacity(this, 1.0 - ((UIElement)this).Opacity, 80, 50),
						ModAnimation.AaScaleTransform(this, 0.15 - ((ScaleTransform)((UIElement)this).RenderTransform).ScaleX, 400, 50, new ModAnimation.AniEaseOutBack()),
						ModAnimation.AaScaleTransform(this, 0.85, 160, 50, new ModAnimation.AniEaseOutFluent())
					}, "MyExtraTextButton MainScale " + Conversions.ToString(Uuid));
				}
				else
				{
					ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
					{
						ModAnimation.AaOpacity(this, 0.0 - ((UIElement)this).Opacity, 50, 50),
						ModAnimation.AaScaleTransform(this, 0.0 - ((ScaleTransform)((UIElement)this).RenderTransform).ScaleX, 100, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak))
					}, "MyExtraTextButton MainScale " + Conversions.ToString(Uuid));
				}
				((UIElement)this).IsHitTestVisible = value;
			}));
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual MyExtraTextButton PanBack
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
			MouseButtonEventHandler val = new MouseButtonEventHandler(Button_LeftMouseUp);
			MouseButtonEventHandler val2 = new MouseButtonEventHandler(Button_LeftMouseDown);
			MouseButtonEventHandler val3 = (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				Button_LeftMouseUp();
			});
			MouseButtonEventHandler val4 = (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				Button_RightMouseUp();
			});
			MouseEventHandler val5 = (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
			{
				Button_MouseLeave();
			});
			MouseEventHandler val6 = (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
			{
				RefreshColor();
			});
			MouseEventHandler val7 = (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
			{
				RefreshColor();
			});
			Border panClick = _PanClick;
			if (panClick != null)
			{
				((UIElement)panClick).MouseLeftButtonUp -= val;
				((UIElement)panClick).MouseLeftButtonDown -= val2;
				((UIElement)panClick).MouseLeftButtonUp -= val3;
				((UIElement)panClick).MouseRightButtonUp -= val4;
				((UIElement)panClick).MouseLeave -= val5;
				((UIElement)panClick).MouseEnter -= val6;
				((UIElement)panClick).MouseLeave -= val7;
			}
			_PanClick = value;
			panClick = _PanClick;
			if (panClick != null)
			{
				((UIElement)panClick).MouseLeftButtonUp += val;
				((UIElement)panClick).MouseLeftButtonDown += val2;
				((UIElement)panClick).MouseLeftButtonUp += val3;
				((UIElement)panClick).MouseRightButtonUp += val4;
				((UIElement)panClick).MouseLeave += val5;
				((UIElement)panClick).MouseEnter += val6;
				((UIElement)panClick).MouseLeave += val7;
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
	[field: AccessedThroughProperty("Path")]
	internal virtual Path Path
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

	public MyExtraTextButton()
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
		Uuid = ModBase.GetUuid();
		_Logo = "";
		_LogoScale = 1.0;
		_Show = false;
		IsLeftMouseHeld = false;
		InitializeComponent();
	}

	private void Button_LeftMouseUp(object sender, MouseButtonEventArgs e)
	{
		if (IsLeftMouseHeld)
		{
			ModBase.Log("[Control] 按下附加图标按钮：" + Text);
			ClickEvent?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
			((RoutedEventArgs)e).Handled = true;
			Button_LeftMouseUp();
		}
	}

	private void Button_LeftMouseDown(object sender, MouseButtonEventArgs e)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		if (!IsLeftMouseHeld)
		{
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
			{
				ModAnimation.AaScaleTransform(PanScale, 0.85 - ((ScaleTransform)((UIElement)PanScale).RenderTransform).ScaleX, 800, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong)),
				ModAnimation.AaScaleTransform(PanScale, -0.05, 60, 0, new ModAnimation.AniEaseOutFluent())
			}, "MyExtraTextButton Scale " + Conversions.ToString(Uuid));
		}
		IsLeftMouseHeld = true;
		base.Focus();
	}

	private void Button_LeftMouseUp()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(PanScale, 1.0 - ((ScaleTransform)((UIElement)PanScale).RenderTransform).ScaleX, 300, 0, new ModAnimation.AniEaseOutBack()) }, "MyExtraTextButton Scale " + Conversions.ToString(Uuid));
		IsLeftMouseHeld = false;
		RefreshColor();
	}

	private void Button_RightMouseUp()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (!IsLeftMouseHeld)
		{
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(PanScale, 1.0 - ((ScaleTransform)((UIElement)PanScale).RenderTransform).ScaleX, 300, 0, new ModAnimation.AniEaseOutBack()) }, "MyExtraTextButton Scale " + Conversions.ToString(Uuid));
		}
		RefreshColor();
	}

	private void Button_MouseLeave()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		IsLeftMouseHeld = false;
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(PanScale, 1.0 - ((ScaleTransform)((UIElement)PanScale).RenderTransform).ScaleX, 500, 0, new ModAnimation.AniEaseOutFluent()) }, "MyExtraTextButton Scale " + Conversions.ToString(Uuid));
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
					ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)PanColor, Panel.BackgroundProperty, "ColorBrushGray4", 120), "MyExtraTextButton Color " + Conversions.ToString(Uuid));
				}
				else if (((UIElement)this).IsMouseOver)
				{
					ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)PanColor, Panel.BackgroundProperty, "ColorBrush4", 120), "MyExtraTextButton Color " + Conversions.ToString(Uuid));
				}
				else
				{
					ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)PanColor, Panel.BackgroundProperty, "ColorBrush3", 150), "MyExtraTextButton Color " + Conversions.ToString(Uuid));
				}
				return;
			}
			ModAnimation.AniStop("MyExtraTextButton Color " + Conversions.ToString(Uuid));
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
			ModBase.Log(ex2, "刷新附加图标按钮颜色出错");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/myextratextbutton.xaml", (UriKind)2);
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
		switch (connectionId)
		{
		case 1:
			PanBack = (MyExtraTextButton)target;
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
			Path = (Path)target;
			break;
		case 6:
			LabText = (TextBlock)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
