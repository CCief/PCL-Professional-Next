using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class MySlider : Border, IComponentConnector
{
	public delegate void ChangeEventHandler(object sender, bool user);

	public delegate void PreviewChangeEventHandler(object sender, ModBase.RouteEventArgs e);

	public int Uuid;

	[CompilerGenerated]
	private ChangeEventHandler ChangeEvent;

	[CompilerGenerated]
	private PreviewChangeEventHandler PreviewChangeEvent;

	private int _MaxValue;

	private bool ChangeByKey;

	private int _Value;

	public System.Delegate GetHintText;

	private bool _contentLoaded;

	public int MaxValue
	{
		get
		{
			return _MaxValue;
		}
		set
		{
			if (value != _MaxValue)
			{
				_MaxValue = value;
				RefreshWidth(null, null);
			}
		}
	}

	public int Value
	{
		get
		{
			return _Value;
		}
		set
		{
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			checked
			{
				try
				{
					value = (int)Math.Round(ModBase.MathClamp(value, 0.0, MaxValue));
					if (_Value == value)
					{
						return;
					}
					int value2 = _Value;
					_Value = value;
					if (ModAnimation.AniControlEnabled == 0)
					{
						ModBase.RouteEventArgs routeEventArgs = new ModBase.RouteEventArgs();
						PreviewChangeEvent?.Invoke(this, routeEventArgs);
						if (routeEventArgs.Handled)
						{
							_Value = value2;
							DragStop();
							return;
						}
					}
					if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
					{
						if (((FrameworkElement)this).ActualWidth < ((FrameworkElement)ShapeDot).Width)
						{
							return;
						}
						double num = (double)_Value / (double)MaxValue * (((FrameworkElement)this).ActualWidth - ((FrameworkElement)ShapeDot).Width);
						double num2 = Math.Abs(((FrameworkElement)LineFore).Width / (((FrameworkElement)this).ActualWidth - ((FrameworkElement)ShapeDot).Width) - (double)_Value / (double)MaxValue);
						double num3 = (1.0 - Math.Pow(1.0 - num2, 3.0)) * 300.0 + (double)(ChangeByKey ? 100 : 0);
						ModAnimation.AniData[] obj = new ModAnimation.AniData[3]
						{
							ModAnimation.AaWidth(LineFore, Math.Max(0.0, num + ((num < 0.5) ? 0.0 : 0.5)) - ((FrameworkElement)LineFore).Width, (int)Math.Round(num3), 0, (num3 > 50.0) ? ((ModAnimation.AniEase)new ModAnimation.AniEaseOutFluent()) : ((ModAnimation.AniEase)new ModAnimation.AniEaseLinear())),
							ModAnimation.AaWidth(LineBack, Math.Max(0.0, ((FrameworkElement)this).ActualWidth - ((FrameworkElement)ShapeDot).Width - num + ((((FrameworkElement)this).ActualWidth - ((FrameworkElement)ShapeDot).Width - num < 0.5) ? 0.0 : 0.5)) - ((FrameworkElement)LineBack).Width, (int)Math.Round(num3), 0, (num3 > 50.0) ? ((ModAnimation.AniEase)new ModAnimation.AniEaseOutFluent()) : ((ModAnimation.AniEase)new ModAnimation.AniEaseLinear())),
							default(ModAnimation.AniData)
						};
						Ellipse shapeDot = ShapeDot;
						Thickness margin = ((FrameworkElement)ShapeDot).Margin;
						obj[2] = ModAnimation.AaX(shapeDot, num - margin.Left, (int)Math.Round(num3), 0, (num3 > 50.0) ? ((ModAnimation.AniEase)new ModAnimation.AniEaseOutFluent()) : ((ModAnimation.AniEase)new ModAnimation.AniEaseLinear()));
						ModAnimation.AniStart((System.Collections.IList)(object)obj, "MySlider Progress " + Conversions.ToString(Uuid));
					}
					else
					{
						RefreshWidth(null, null);
					}
					if (ModAnimation.AniControlEnabled == 0)
					{
						ChangeEvent?.Invoke(this, user: false);
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "滑动条进度改变出错", ModBase.LogLevel.Hint);
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	[field: CompilerGenerated]
	public uint ValueByKey
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual MySlider PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanMain")]
	internal virtual Grid PanMain
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LineBack")]
	internal virtual Line LineBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LineFore")]
	internal virtual Line LineFore
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ShapeDot")]
	internal virtual Ellipse ShapeDot
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("Popup")]
	internal virtual Popup Popup
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextHint")]
	internal virtual TextBlock TextHint
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
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

	public event PreviewChangeEventHandler PreviewChange
	{
		[CompilerGenerated]
		add
		{
			PreviewChangeEventHandler previewChangeEventHandler = PreviewChangeEvent;
			PreviewChangeEventHandler previewChangeEventHandler2;
			do
			{
				previewChangeEventHandler2 = previewChangeEventHandler;
				PreviewChangeEventHandler previewChangeEventHandler3 = (PreviewChangeEventHandler)System.Delegate.Combine((System.Delegate)previewChangeEventHandler2, (System.Delegate)value);
				previewChangeEventHandler = Interlocked.CompareExchange<PreviewChangeEventHandler>(ref PreviewChangeEvent, previewChangeEventHandler3, previewChangeEventHandler2);
			}
			while (previewChangeEventHandler != previewChangeEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PreviewChangeEventHandler previewChangeEventHandler = PreviewChangeEvent;
			PreviewChangeEventHandler previewChangeEventHandler2;
			do
			{
				previewChangeEventHandler2 = previewChangeEventHandler;
				PreviewChangeEventHandler previewChangeEventHandler3 = (PreviewChangeEventHandler)System.Delegate.Remove((System.Delegate)previewChangeEventHandler2, (System.Delegate)value);
				previewChangeEventHandler = Interlocked.CompareExchange<PreviewChangeEventHandler>(ref PreviewChangeEvent, previewChangeEventHandler3, previewChangeEventHandler2);
			}
			while (previewChangeEventHandler != previewChangeEventHandler2);
		}
	}

	public MySlider()
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
		((FrameworkElement)this).SizeChanged += new SizeChangedEventHandler(RefreshWidth);
		((UIElement)this).MouseLeftButtonDown += new MouseButtonEventHandler(DragStart);
		((UIElement)this).IsEnabledChanged += (DependencyPropertyChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, DependencyPropertyChangedEventArgs a1) =>
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
		((UIElement)this).MouseEnter += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			MySlider_MouseEnter();
		});
		((UIElement)this).KeyDown += new KeyEventHandler(MySlider_KeyDown);
		Uuid = ModBase.GetUuid();
		_MaxValue = 100;
		ChangeByKey = false;
		_Value = 0;
		ValueByKey = 1u;
		InitializeComponent();
	}

	private void RefreshWidth(object sender, SizeChangedEventArgs e)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (!Information.IsNothing((object)e))
		{
			Grid panMain = PanMain;
			Size newSize = e.NewSize;
			((FrameworkElement)panMain).Width = newSize.Width;
		}
		ModAnimation.AniStop("MySlider Progress " + Conversions.ToString(Uuid));
		double num = (double)_Value / (double)MaxValue * (((FrameworkElement)this).ActualWidth - ((FrameworkElement)ShapeDot).Width);
		((FrameworkElement)LineFore).Width = Math.Max(0.0, num + ((num < 0.5) ? 0.0 : 0.5));
		((FrameworkElement)LineBack).Width = Math.Max(0.0, ((FrameworkElement)this).ActualWidth - ((FrameworkElement)ShapeDot).Width - num + ((((FrameworkElement)this).ActualWidth - ((FrameworkElement)ShapeDot).Width - num < 0.5) ? 0.0 : 0.5));
		ModBase.SetLeft((FrameworkElement)(object)ShapeDot, num);
	}

	private void DragStart(object sender, MouseButtonEventArgs e)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		((RoutedEventArgs)e).Handled = true;
		ModMain.DragControl = this;
		RefreshColor();
		ModMain.FrmMain.DragDoing();
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(ShapeDot, 1.3 - ((ScaleTransform)((UIElement)ShapeDot).RenderTransform).ScaleX, 40, 0, new ModAnimation.AniEaseOutFluent()) }, "MySlider Scale " + Conversions.ToString(Uuid));
		RefreshPopup();
		ModAnimation.AniStop("MySlider KeyPopup " + Conversions.ToString(Uuid));
	}

	public void DragDoing()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		Point position = Mouse.GetPosition((IInputElement)(object)PanMain);
		int num = checked((int)Math.Round(ModBase.MathClamp((position.X - ((FrameworkElement)ShapeDot).Width / 2.0) / (((FrameworkElement)this).ActualWidth - ((FrameworkElement)ShapeDot).Width), 0.0, 1.0) * (double)MaxValue));
		if (num != Value)
		{
			Value = num;
		}
		RefreshPopup();
	}

	public void DragStop()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		RefreshColor();
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(ShapeDot, 1.0 - ((ScaleTransform)((UIElement)ShapeDot).RenderTransform).ScaleX, 200, 0, new ModAnimation.AniEaseOutFluent()) }, "MySlider Scale " + Conversions.ToString(Uuid));
		Popup.IsOpen = false;
	}

	public void RefreshPopup()
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		if (GetHintText != null)
		{
			Popup.IsOpen = true;
			TextHint.Text = Conversions.ToString(GetHintText.DynamicInvoke(new object[] { Value }));
			Typeface val = new Typeface(TextHint.FontFamily, TextHint.FontStyle, TextHint.FontWeight, TextHint.FontStretch);
			FormattedText val2 = new FormattedText(TextHint.Text, Thread.CurrentThread.CurrentCulture, ((FrameworkElement)TextHint).FlowDirection, val, TextHint.FontSize, TextHint.Foreground, (double)ModBase.DPI);
			((FrameworkElement)TextHint).Width = val2.Width;
		}
	}

	private void RefreshColor()
	{
		try
		{
			string text;
			string text2;
			int time;
			if (((UIElement)this).IsEnabled)
			{
				if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(ModMain.DragControl)) && ModMain.DragControl.Equals((object)this))
				{
					text = "ColorBrush3";
					text2 = "ColorBrush3";
					time = 40;
				}
				else if (((UIElement)this).IsMouseOver)
				{
					text = "ColorBrush3";
					text2 = "ColorBrush3";
					time = 40;
				}
				else
				{
					text = "ColorBrushBg0";
					text2 = "ColorBrushBg0";
					time = 100;
				}
			}
			else
			{
				text = "ColorBrushGray5";
				text2 = "ColorBrushGray5";
				time = 200;
			}
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaColor((FrameworkElement)(object)this, Border.BorderBrushProperty, text, time),
					ModAnimation.AaColor((FrameworkElement)(object)ShapeDot, Shape.FillProperty, text2, time)
				}, "MySlider Color " + Conversions.ToString(Uuid));
			}
			else
			{
				ModAnimation.AniStop("MySlider Color " + Conversions.ToString(Uuid));
				base.SetResourceReference(Border.BorderBrushProperty, (object)text);
				((FrameworkElement)ShapeDot).SetResourceReference(Shape.FillProperty, (object)text2);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "滑动条颜色改变出错");
			ProjectData.ClearProjectError();
		}
	}

	private void MySlider_MouseEnter()
	{
		base.Focus();
	}

	private void MySlider_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		if (object.ReferenceEquals((object)this, RuntimeHelpers.GetObjectValue(ModMain.DragControl)))
		{
			return;
		}
		if ((int)e.Key == 23)
		{
			ChangeByKey = true;
			Value = checked((int)(Value - ValueByKey));
			ChangeByKey = false;
			((RoutedEventArgs)e).Handled = true;
		}
		else
		{
			if ((int)e.Key != 25)
			{
				return;
			}
			ChangeByKey = true;
			Value = checked((int)(Value + ValueByKey));
			ChangeByKey = false;
			((RoutedEventArgs)e).Handled = true;
		}
		if (GetHintText != null)
		{
			RefreshPopup();
			ModAnimation.AniStop("MySlider KeyPopup " + Conversions.ToString(Uuid));
			ModAnimation.AniStart(ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
			{
				Popup.IsOpen = false;
			}), checked((int)Math.Round(700.0 * ModAnimation.AniSpeed))), "MySlider KeyPopup " + Conversions.ToString(Uuid));
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/myslider.xaml", (UriKind)2);
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
			PanBack = (MySlider)target;
			break;
		case 2:
			PanMain = (Grid)target;
			break;
		case 3:
			LineBack = (Line)target;
			break;
		case 4:
			LineFore = (Line)target;
			break;
		case 5:
			ShapeDot = (Ellipse)target;
			break;
		case 6:
			Popup = (Popup)target;
			break;
		case 7:
			TextHint = (TextBlock)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
