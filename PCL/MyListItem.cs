using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
public class MyListItem : Grid, IMyRadio, IComponentConnector
{
	public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

	public delegate void LogoClickEventHandler(object sender, MouseButtonEventArgs e);

	public enum CheckType
	{
		None,
		Clickable,
		RadioBox,
		CheckBox
	}

	[CompilerGenerated]
	private ClickEventHandler ClickEvent;

	[CompilerGenerated]
	private LogoClickEventHandler LogoClickEvent;

	[CompilerGenerated]
	private IMyRadio.CheckEventHandler CheckEvent;

	[CompilerGenerated]
	private IMyRadio.ChangedEventHandler ChangedEvent;

	private Border _RectBack;

	public FrameworkElement ButtonStack;

	public FrameworkElement PathLogo;

	public Border RectCheck;

	public StackPanel _PanTags;

	private TextBlock _LabInfo;

	public int Uuid;

	private bool _IsScaleAnimationEnabled;

	private System.Collections.Generic.IEnumerable<MyIconButton> _Buttons;

	public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(MyListItem));

	public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register("FontSize", typeof(double), typeof(MyListItem), new PropertyMetadata((object)14.0));

	public static readonly DependencyProperty InfoProperty = DependencyProperty.Register("Info", typeof(string), typeof(MyListItem), new PropertyMetadata((object)"", new PropertyChangedCallback(OnInfoChanged)));

	public static readonly DependencyProperty LogoProperty = DependencyProperty.Register("Logo", typeof(string), typeof(MyListItem), new PropertyMetadata((object)"", new PropertyChangedCallback(OnLogoChanged)));

	private double _LogoScale;

	private bool IsLogoDown;

	private CheckType _Type;

	private bool _Checked;

	public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register("Foreground", typeof(Brush), typeof(MyListItem), new PropertyMetadata((object)ModSecret.DynamicColors.Color1Brush));

	private bool IsMouseDown;

	public static readonly DependencyProperty EventTypeProperty = DependencyProperty.Register("EventType", typeof(string), typeof(MyListItem), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty EventDataProperty = DependencyProperty.Register("EventData", typeof(string), typeof(MyListItem), new PropertyMetadata((PropertyChangedCallback)null));

	private string StateLast;

	public bool IsMouseOverAnimationEnabled;

	private bool _contentLoaded;

	public Border RectBack
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Expected O, but got Unknown
			if (_RectBack == null)
			{
				Border val = new Border
				{
					Name = "RectBack",
					CornerRadius = new CornerRadius((double)((IsScaleAnimationEnabled || ((FrameworkElement)this).Height > 40.0) ? 6 : 0)),
					RenderTransform = (Transform)((!IsScaleAnimationEnabled) ? ((ScaleTransform)null) : new ScaleTransform(0.8, 0.8)),
					RenderTransformOrigin = new Point(0.5, 0.5),
					BorderThickness = new Thickness(ModBase.GetWPFSize(1.0)),
					SnapsToDevicePixels = true,
					IsHitTestVisible = false,
					Opacity = 0.0
				};
				((FrameworkElement)val).SetResourceReference(Border.BackgroundProperty, (object)"ColorBrush7");
				((FrameworkElement)val).SetResourceReference(Border.BorderBrushProperty, (object)"ColorBrush6");
				Grid.SetColumnSpan((UIElement)(object)val, 999);
				Grid.SetRowSpan((UIElement)(object)val, 999);
				((Panel)this).Children.Insert(0, (UIElement)(object)val);
				_RectBack = val;
			}
			return _RectBack;
		}
	}

	public StackPanel PanTags
	{
		get
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Expected O, but got Unknown
			if (_PanTags != null)
			{
				return _PanTags;
			}
			StackPanel val = new StackPanel
			{
				IsHitTestVisible = false,
				Orientation = (Orientation)0,
				VerticalAlignment = (VerticalAlignment)2,
				Margin = new Thickness(3.5, 0.0, -3.0, 0.0)
			};
			Grid.SetColumn((UIElement)(object)val, 3);
			Grid.SetRow((UIElement)(object)val, 2);
			((Panel)PanBack).Children.Add((UIElement)(object)val);
			_PanTags = val;
			return _PanTags;
		}
	}

	public object Tags
	{
		set
		{
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Expected O, but got Unknown
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Expected O, but got Unknown
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Expected O, but got Unknown
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Expected O, but got Unknown
			List<string> val = new List<string>();
			if (value is string)
			{
				val = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)Conversions.ToString(value).Split("|", (StringSplitOptions)0));
			}
			if (value is List<string>)
			{
				val = (List<string>)value;
			}
			((Panel)PanTags).Children.Clear();
			((UIElement)PanTags).Visibility = (Visibility)((!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val)) ? 2 : 0);
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = val.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					Border val2 = new Border
					{
						Background = (Brush)new SolidColorBrush(Color.FromArgb((byte)17, (byte)0, (byte)0, (byte)0)),
						Padding = new Thickness(3.0, 1.0, 3.0, 1.0),
						CornerRadius = new CornerRadius(3.0),
						Margin = new Thickness(0.0, 0.0, 3.0, 0.0),
						SnapsToDevicePixels = true,
						UseLayoutRounding = false
					};
					TextBlock child = new TextBlock
					{
						Text = current,
						Foreground = (Brush)new SolidColorBrush(Color.FromRgb((byte)134, (byte)134, (byte)134)),
						FontSize = 11.0
					};
					((Decorator)val2).Child = (UIElement)(object)child;
					((Panel)PanTags).Children.Add((UIElement)(object)val2);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
	}

	public TextBlock LabInfo
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			if (_LabInfo == null)
			{
				TextBlock val = new TextBlock
				{
					Name = "LabInfo",
					SnapsToDevicePixels = false,
					UseLayoutRounding = false,
					HorizontalAlignment = (HorizontalAlignment)0,
					IsHitTestVisible = false,
					TextTrimming = (TextTrimming)1,
					Visibility = (Visibility)2,
					FontSize = 12.0,
					Margin = new Thickness(4.0, 0.0, 0.0, 0.0),
					Opacity = 0.6
				};
				Grid.SetColumn((UIElement)(object)val, 4);
				Grid.SetRow((UIElement)(object)val, 2);
				((Panel)PanBack).Children.Add((UIElement)(object)val);
				_LabInfo = val;
			}
			return _LabInfo;
		}
	}

	public bool IsScaleAnimationEnabled
	{
		get
		{
			return _IsScaleAnimationEnabled;
		}
		set
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			_IsScaleAnimationEnabled = value;
			if (_RectBack != null)
			{
				RectBack.CornerRadius = new CornerRadius((double)(value ? 6 : 0));
			}
		}
	}

	public int PaddingLeft
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			GridLength width = ColumnPaddingLeft.Width;
			return checked((int)Math.Round(width.Value));
		}
		set
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			ColumnPaddingLeft.Width = new GridLength((double)value);
		}
	}

	[field: CompilerGenerated]
	public int MinPaddingRight
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public System.Collections.Generic.IEnumerable<MyIconButton> Buttons
	{
		get
		{
			return _Buttons;
		}
		set
		{
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Expected O, but got Unknown
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			_Buttons = value;
			if (ButtonStack != null)
			{
				((Panel)this).Children.Remove((UIElement)(object)ButtonStack);
				ButtonStack = null;
			}
			switch (Enumerable.Count<MyIconButton>(value))
			{
			case 1:
			{
				System.Collections.Generic.IEnumerator<MyIconButton> enumerator = default(System.Collections.Generic.IEnumerator<MyIconButton>);
				try
				{
					enumerator = value.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						MyIconButton current = enumerator.Current;
						if (((FrameworkElement)current).Height.Equals(0.0 / 0.0))
						{
							((FrameworkElement)current).Height = 25.0;
						}
						if (((FrameworkElement)current).Width.Equals(0.0 / 0.0))
						{
							((FrameworkElement)current).Width = 25.0;
						}
						((UIElement)current).Opacity = 0.0;
						((FrameworkElement)current).Margin = new Thickness(0.0, 0.0, 5.0, 0.0);
						((UIElement)current).SnapsToDevicePixels = false;
						((FrameworkElement)current).HorizontalAlignment = (HorizontalAlignment)2;
						((FrameworkElement)current).VerticalAlignment = (VerticalAlignment)1;
						((UIElement)current).SnapsToDevicePixels = false;
						((FrameworkElement)current).UseLayoutRounding = false;
						Grid.SetColumnSpan((UIElement)(object)current, 10);
						Grid.SetRowSpan((UIElement)(object)current, 10);
						((Panel)this).Children.Add((UIElement)(object)current);
						ButtonStack = (FrameworkElement)(object)current;
					}
					return;
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
			}
			case 0:
				return;
			}
			ButtonStack = (FrameworkElement)new StackPanel
			{
				Opacity = 0.0,
				Margin = new Thickness(0.0, 0.0, 5.0, 0.0),
				SnapsToDevicePixels = false,
				Orientation = (Orientation)0,
				HorizontalAlignment = (HorizontalAlignment)2,
				VerticalAlignment = (VerticalAlignment)1,
				UseLayoutRounding = false
			};
			Grid.SetColumnSpan((UIElement)(object)ButtonStack, 10);
			Grid.SetRowSpan((UIElement)(object)ButtonStack, 10);
			System.Collections.Generic.IEnumerator<MyIconButton> enumerator2 = default(System.Collections.Generic.IEnumerator<MyIconButton>);
			try
			{
				enumerator2 = value.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator2).MoveNext())
				{
					MyIconButton current2 = enumerator2.Current;
					if (((FrameworkElement)current2).Height.Equals(0.0 / 0.0))
					{
						((FrameworkElement)current2).Height = 25.0;
					}
					if (((FrameworkElement)current2).Width.Equals(0.0 / 0.0))
					{
						((FrameworkElement)current2).Width = 25.0;
					}
					((Panel)(StackPanel)ButtonStack).Children.Add((UIElement)(object)current2);
				}
			}
			finally
			{
				((System.IDisposable)enumerator2)?.Dispose();
			}
			((Panel)this).Children.Add((UIElement)(object)ButtonStack);
		}
	}

	public InlineCollection Inlines => LabTitle.Inlines;

	public string Title
	{
		get
		{
			return Conversions.ToString(base.GetValue(TitleProperty));
		}
		set
		{
			base.SetValue(TitleProperty, (object)value.Replace("\r", "").Replace("\n", ""));
		}
	}

	public double FontSize
	{
		get
		{
			return Conversions.ToDouble(base.GetValue(FontSizeProperty));
		}
		set
		{
			base.SetValue(FontSizeProperty, (object)value);
		}
	}

	public string Info
	{
		get
		{
			return Conversions.ToString(base.GetValue(InfoProperty));
		}
		set
		{
			if (Operators.CompareString(Info, value, false) != 0)
			{
				value = value.Replace("\r", "").Replace("\n", "");
				base.SetValue(InfoProperty, (object)value);
			}
		}
	}

	public string Logo
	{
		get
		{
			return Conversions.ToString(base.GetValue(LogoProperty));
		}
		set
		{
			if (Operators.CompareString(Logo, value, false) != 0)
			{
				base.SetValue(LogoProperty, (object)value);
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
			if (!Information.IsNothing((object)PathLogo))
			{
				((UIElement)PathLogo).RenderTransform = (Transform)new ScaleTransform
				{
					ScaleX = LogoScale,
					ScaleY = LogoScale
				};
			}
		}
	}

	[field: CompilerGenerated]
	public bool LogoClickable
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public CheckType Type
	{
		get
		{
			return _Type;
		}
		set
		{
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Expected O, but got Unknown
			if (_Type == value)
			{
				return;
			}
			_Type = value;
			ColumnCheck.Width = new GridLength((double)((_Type != 0 && _Type != CheckType.Clickable) ? 6 : ((((FrameworkElement)this).Height < 40.0) ? 4 : 2)));
			if (_Type == CheckType.None || _Type == CheckType.Clickable)
			{
				if (!Information.IsNothing((object)RectCheck))
				{
					((Panel)this).Children.Remove((UIElement)(object)RectCheck);
					RectCheck = null;
				}
				SetChecked(value: false, user: false, anime: false);
			}
			else if (Information.IsNothing((object)RectCheck))
			{
				RectCheck = new Border
				{
					Width = 5.0,
					Height = (Checked ? (0.0 / 0.0) : 0.0),
					CornerRadius = new CornerRadius(2.0, 2.0, 2.0, 2.0),
					VerticalAlignment = (VerticalAlignment)((!Checked) ? 1 : 3),
					HorizontalAlignment = (HorizontalAlignment)0,
					UseLayoutRounding = false,
					SnapsToDevicePixels = false,
					Margin = (Checked ? new Thickness(-1.0, 6.0, 0.0, 6.0) : new Thickness(-1.0, 0.0, 0.0, 0.0))
				};
				((FrameworkElement)RectCheck).SetResourceReference(Border.BackgroundProperty, (object)"ColorBrush3");
				Grid.SetRowSpan((UIElement)(object)RectCheck, 4);
				((Panel)this).Children.Add((UIElement)(object)RectCheck);
			}
		}
	}

	public bool Checked
	{
		get
		{
			return _Checked;
		}
		set
		{
			SetChecked(value, user: false, value != _Checked);
		}
	}

	public Brush Foreground
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (Brush)base.GetValue(ForegroundProperty);
		}
		set
		{
			base.SetValue(ForegroundProperty, (object)value);
		}
	}

	[field: CompilerGenerated]
	public Action<MyListItem, EventArgs> ContentHandler
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
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
	internal virtual MyListItem PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnCheck")]
	internal virtual ColumnDefinition ColumnCheck
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnPaddingLeft")]
	internal virtual ColumnDefinition ColumnPaddingLeft
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnLogo")]
	internal virtual ColumnDefinition ColumnLogo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnPaddingRight")]
	internal virtual ColumnDefinition ColumnPaddingRight
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabTitle")]
	internal virtual TextBlock LabTitle
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

	public event LogoClickEventHandler LogoClick
	{
		[CompilerGenerated]
		add
		{
			LogoClickEventHandler logoClickEventHandler = LogoClickEvent;
			LogoClickEventHandler logoClickEventHandler2;
			do
			{
				logoClickEventHandler2 = logoClickEventHandler;
				LogoClickEventHandler logoClickEventHandler3 = (LogoClickEventHandler)System.Delegate.Combine((System.Delegate)logoClickEventHandler2, (System.Delegate)value);
				logoClickEventHandler = Interlocked.CompareExchange<LogoClickEventHandler>(ref LogoClickEvent, logoClickEventHandler3, logoClickEventHandler2);
			}
			while (logoClickEventHandler != logoClickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			LogoClickEventHandler logoClickEventHandler = LogoClickEvent;
			LogoClickEventHandler logoClickEventHandler2;
			do
			{
				logoClickEventHandler2 = logoClickEventHandler;
				LogoClickEventHandler logoClickEventHandler3 = (LogoClickEventHandler)System.Delegate.Remove((System.Delegate)logoClickEventHandler2, (System.Delegate)value);
				logoClickEventHandler = Interlocked.CompareExchange<LogoClickEventHandler>(ref LogoClickEvent, logoClickEventHandler3, logoClickEventHandler2);
			}
			while (logoClickEventHandler != logoClickEventHandler2);
		}
	}

	public event IMyRadio.CheckEventHandler Check
	{
		[CompilerGenerated]
		add
		{
			IMyRadio.CheckEventHandler checkEventHandler = CheckEvent;
			IMyRadio.CheckEventHandler checkEventHandler2;
			do
			{
				checkEventHandler2 = checkEventHandler;
				IMyRadio.CheckEventHandler checkEventHandler3 = (IMyRadio.CheckEventHandler)System.Delegate.Combine((System.Delegate)checkEventHandler2, (System.Delegate)value);
				checkEventHandler = Interlocked.CompareExchange<IMyRadio.CheckEventHandler>(ref CheckEvent, checkEventHandler3, checkEventHandler2);
			}
			while (checkEventHandler != checkEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			IMyRadio.CheckEventHandler checkEventHandler = CheckEvent;
			IMyRadio.CheckEventHandler checkEventHandler2;
			do
			{
				checkEventHandler2 = checkEventHandler;
				IMyRadio.CheckEventHandler checkEventHandler3 = (IMyRadio.CheckEventHandler)System.Delegate.Remove((System.Delegate)checkEventHandler2, (System.Delegate)value);
				checkEventHandler = Interlocked.CompareExchange<IMyRadio.CheckEventHandler>(ref CheckEvent, checkEventHandler3, checkEventHandler2);
			}
			while (checkEventHandler != checkEventHandler2);
		}
	}

	public event IMyRadio.ChangedEventHandler Changed
	{
		[CompilerGenerated]
		add
		{
			IMyRadio.ChangedEventHandler changedEventHandler = ChangedEvent;
			IMyRadio.ChangedEventHandler changedEventHandler2;
			do
			{
				changedEventHandler2 = changedEventHandler;
				IMyRadio.ChangedEventHandler changedEventHandler3 = (IMyRadio.ChangedEventHandler)System.Delegate.Combine((System.Delegate)changedEventHandler2, (System.Delegate)value);
				changedEventHandler = Interlocked.CompareExchange<IMyRadio.ChangedEventHandler>(ref ChangedEvent, changedEventHandler3, changedEventHandler2);
			}
			while (changedEventHandler != changedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			IMyRadio.ChangedEventHandler changedEventHandler = ChangedEvent;
			IMyRadio.ChangedEventHandler changedEventHandler2;
			do
			{
				changedEventHandler2 = changedEventHandler;
				IMyRadio.ChangedEventHandler changedEventHandler3 = (IMyRadio.ChangedEventHandler)System.Delegate.Remove((System.Delegate)changedEventHandler2, (System.Delegate)value);
				changedEventHandler = Interlocked.CompareExchange<IMyRadio.ChangedEventHandler>(ref ChangedEvent, changedEventHandler3, changedEventHandler2);
			}
			while (changedEventHandler != changedEventHandler2);
		}
	}

	public MyListItem()
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
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		((FrameworkElement)this).SizeChanged += (SizeChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, SizeChangedEventArgs a1) =>
		{
			OnSizeChanged();
		});
		((UIElement)this).PreviewMouseLeftButtonUp += new MouseButtonEventHandler(Button_MouseUp);
		((UIElement)this).PreviewMouseLeftButtonDown += new MouseButtonEventHandler(Button_MouseDown);
		((UIElement)this).MouseLeave += new MouseEventHandler(Button_MouseLeave);
		((UIElement)this).PreviewMouseLeftButtonUp += new MouseButtonEventHandler(Button_MouseLeave);
		((UIElement)this).MouseEnter += new MouseEventHandler(RefreshColor);
		((UIElement)this).MouseLeave += new MouseEventHandler(RefreshColor);
		((UIElement)this).MouseLeftButtonDown += new MouseButtonEventHandler(RefreshColor);
		((UIElement)this).MouseLeftButtonUp += new MouseButtonEventHandler(RefreshColor);
		((FrameworkElement)this).Loaded += new RoutedEventHandler(MyListItem_Loaded);
		_RectBack = null;
		_LabInfo = null;
		Uuid = ModBase.GetUuid();
		_IsScaleAnimationEnabled = true;
		MinPaddingRight = 4;
		_LogoScale = 1.0;
		LogoClickable = false;
		IsLogoDown = false;
		_Type = CheckType.None;
		_Checked = false;
		IsMouseDown = false;
		IsMouseOverAnimationEnabled = true;
		InitializeComponent();
	}

	private static void OnInfoChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		MyListItem obj = (MyListItem)(object)d;
		string text = Conversions.ToString(e.NewValue);
		obj.LabInfo.Text = text;
		((UIElement)obj.LabInfo).Visibility = (Visibility)((Operators.CompareString(text, "", false) == 0) ? 2 : 0);
	}

	private static void OnLogoChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		MyListItem obj = (MyListItem)(object)d;
		string logo = Conversions.ToString(e.NewValue);
		obj.UpdateLogo(logo);
	}

	private void UpdateLogo(string _Logo)
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Expected O, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		if (!Information.IsNothing((object)PathLogo))
		{
			((Panel)this).Children.Remove((UIElement)(object)PathLogo);
		}
		if (Operators.CompareString(_Logo, "", false) != 0)
		{
			if (ModBase.StartsWithF(_Logo, "http", IgnoreCase: true))
			{
				MyImage myImage = new MyImage();
				((FrameworkElement)myImage).Tag = this;
				((UIElement)myImage).IsHitTestVisible = LogoClickable;
				myImage.Source = _Logo;
				((UIElement)myImage).RenderTransformOrigin = new Point(0.5, 0.5);
				((UIElement)myImage).RenderTransform = (Transform)new ScaleTransform
				{
					ScaleX = LogoScale,
					ScaleY = LogoScale
				};
				((UIElement)myImage).SnapsToDevicePixels = true;
				((FrameworkElement)myImage).UseLayoutRounding = false;
				PathLogo = (FrameworkElement)(object)myImage;
				RenderOptions.SetBitmapScalingMode((DependencyObject)(object)PathLogo, (BitmapScalingMode)1);
			}
			else if (ModBase.EndsWithF(_Logo, ".png", IgnoreCase: true) || ModBase.EndsWithF(_Logo, ".jpg", IgnoreCase: true) || ModBase.EndsWithF(_Logo, ".webp", IgnoreCase: true))
			{
				PathLogo = (FrameworkElement)new Canvas
				{
					Tag = this,
					IsHitTestVisible = LogoClickable,
					Background = (Brush)(object)(ImageBrush)new MyBitmap(_Logo),
					RenderTransformOrigin = new Point(0.5, 0.5),
					RenderTransform = (Transform)new ScaleTransform
					{
						ScaleX = LogoScale,
						ScaleY = LogoScale
					},
					SnapsToDevicePixels = true,
					UseLayoutRounding = false,
					HorizontalAlignment = (HorizontalAlignment)3,
					VerticalAlignment = (VerticalAlignment)3
				};
				if (_Logo.Contains(ModBase.PathTemp + "Cache\\Skin\\Head") || _Logo.Contains(ModBase.PathTemp + "Cache\\Cape"))
				{
					RenderOptions.SetBitmapScalingMode((DependencyObject)(object)PathLogo, (BitmapScalingMode)3);
				}
				else
				{
					RenderOptions.SetBitmapScalingMode((DependencyObject)(object)PathLogo, (BitmapScalingMode)1);
				}
			}
			else
			{
				PathLogo = (FrameworkElement)new Path
				{
					Tag = this,
					IsHitTestVisible = LogoClickable,
					HorizontalAlignment = (HorizontalAlignment)1,
					VerticalAlignment = (VerticalAlignment)1,
					Stretch = (Stretch)2,
					Data = (Geometry)((TypeConverter)new GeometryConverter()).ConvertFromString(_Logo),
					RenderTransformOrigin = new Point(0.5, 0.5),
					RenderTransform = (Transform)new ScaleTransform
					{
						ScaleX = LogoScale,
						ScaleY = LogoScale
					},
					SnapsToDevicePixels = false,
					UseLayoutRounding = false
				};
				PathLogo.SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
				{
					Source = this
				});
			}
			Grid.SetColumn((UIElement)(object)PathLogo, 2);
			Grid.SetRowSpan((UIElement)(object)PathLogo, 4);
			OnSizeChanged();
			((Panel)this).Children.Add((UIElement)(object)PathLogo);
			if (LogoClickable)
			{
				((UIElement)PathLogo).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object sender, MouseEventArgs e) =>
				{
					IsLogoDown = false;
				});
				((UIElement)PathLogo).MouseLeftButtonDown += (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object sender, MouseButtonEventArgs e) =>
				{
					IsLogoDown = true;
				});
				((UIElement)PathLogo).MouseLeftButtonUp += (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object sender, MouseButtonEventArgs e) =>
				{
					if (IsLogoDown)
					{
						IsLogoDown = false;
						LogoClickEvent?.Invoke(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)), e);
					}
				});
			}
		}
		ColumnLogo.Width = new GridLength((double)checked(((Operators.CompareString(_Logo, "", false) != 0) ? 34 : 0) + ((!(((FrameworkElement)this).Height < 40.0)) ? 4 : 0)));
	}

	private void OnSizeChanged()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		string logo = Logo;
		ColumnCheck.Width = new GridLength((double)((_Type != 0 && _Type != CheckType.Clickable) ? 6 : ((((FrameworkElement)this).Height < 40.0) ? 4 : 2)));
		ColumnLogo.Width = new GridLength((double)checked(((Operators.CompareString(logo, "", false) != 0) ? 34 : 0) + ((!(((FrameworkElement)this).Height < 40.0)) ? 4 : 0)));
		if (PathLogo != null)
		{
			if (ModBase.EndsWithF(logo, ".png", IgnoreCase: true) || ModBase.EndsWithF(logo, ".jpg", IgnoreCase: true) || ModBase.EndsWithF(logo, ".webp", IgnoreCase: true))
			{
				PathLogo.Margin = new Thickness(4.0, 5.0, 3.0, 5.0);
			}
			else
			{
				PathLogo.Margin = new Thickness((double)((((FrameworkElement)this).Height < 40.0) ? 6 : 8), 8.0, (double)((((FrameworkElement)this).Height < 40.0) ? 4 : 6), 8.0);
			}
		}
		((FrameworkElement)LabTitle).Margin = new Thickness(4.0, 0.0, 0.0, (double)((!(((FrameworkElement)this).Height < 40.0)) ? 2 : 0));
	}

	public void SetChecked(bool value, bool user, bool anime)
	{
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ModBase.RouteEventArgs routeEventArgs = new ModBase.RouteEventArgs(user);
			bool @checked = _Checked;
			if (Type == CheckType.RadioBox)
			{
				if (((FrameworkElement)this).IsInitialized && value != _Checked)
				{
					_Checked = value;
					ChangedEvent?.Invoke(this, routeEventArgs);
					if (routeEventArgs.Handled)
					{
						_Checked = @checked;
						return;
					}
				}
				_Checked = value;
			}
			else
			{
				if (value == _Checked)
				{
					return;
				}
				_Checked = value;
				if (((FrameworkElement)this).IsInitialized)
				{
					ChangedEvent?.Invoke(this, routeEventArgs);
					if (routeEventArgs.Handled)
					{
						_Checked = @checked;
						return;
					}
				}
			}
			if (value)
			{
				ModBase.RouteEventArgs routeEventArgs2 = new ModBase.RouteEventArgs(user);
				CheckEvent?.Invoke(this, routeEventArgs2);
				if (routeEventArgs2.Handled)
				{
					return;
				}
			}
			if (Type == CheckType.RadioBox)
			{
				if (Information.IsNothing((object)((FrameworkElement)this).Parent))
				{
					return;
				}
				List<MyListItem> val = new List<MyListItem>();
				int num = 0;
				foreach (object item in (System.Collections.IEnumerable)NewLateBinding.LateGet((object)((FrameworkElement)this).Parent, (System.Type)null, "Children", new object[0], (string[])null, (System.Type[])null, (bool[])null))
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					if (objectValue is MyListItem && ((MyListItem)objectValue).Type == CheckType.RadioBox)
					{
						val.Add((MyListItem)objectValue);
						if (Conversions.ToBoolean(NewLateBinding.LateGet(objectValue, (System.Type)null, "Checked", new object[0], (string[])null, (System.Type[])null, (bool[])null)))
						{
							num = checked(num + 1);
						}
					}
				}
				int num2 = num;
				if (num2 == 0)
				{
					val[0].Checked = true;
				}
				else if (num2 > 1)
				{
					if (Checked)
					{
						System.Collections.Generic.IEnumerator<MyListItem> enumerator2 = default(System.Collections.Generic.IEnumerator<MyListItem>);
						try
						{
							enumerator2 = val.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								MyListItem current = enumerator2.Current;
								if (current.Checked && !((DependencyObject)current).Equals((object)this))
								{
									current.Checked = false;
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator2).Dispose();
						}
					}
					else
					{
						bool flag = false;
						System.Collections.Generic.IEnumerator<MyListItem> enumerator3 = default(System.Collections.Generic.IEnumerator<MyListItem>);
						try
						{
							enumerator3 = val.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								MyListItem current2 = enumerator3.Current;
								if (current2.Checked)
								{
									if (flag)
									{
										current2.Checked = false;
									}
									else
									{
										flag = true;
									}
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator3).Dispose();
						}
					}
				}
			}
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0 && anime)
			{
				List<ModAnimation.AniData> val2 = new List<ModAnimation.AniData>();
				if (Checked)
				{
					if (!Information.IsNothing((object)RectCheck))
					{
						double num3 = ((FrameworkElement)this).ActualHeight - ((FrameworkElement)RectCheck).ActualHeight - 12.0;
						val2.Add(ModAnimation.AaHeight(RectCheck, num3 * 0.4, 200, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)));
						val2.Add(ModAnimation.AaHeight(RectCheck, num3 * 0.6, 300, 0, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)));
						val2.Add(ModAnimation.AaOpacity(RectCheck, 1.0 - ((UIElement)RectCheck).Opacity, 30));
						((FrameworkElement)RectCheck).VerticalAlignment = (VerticalAlignment)1;
						((FrameworkElement)RectCheck).Margin = new Thickness(-1.0, 0.0, 0.0, 0.0);
					}
					val2.Add(ModAnimation.AaColor((FrameworkElement)(object)this, ForegroundProperty, (((FrameworkElement)this).Height < 40.0) ? "ColorBrush3" : "ColorBrush2", 200));
				}
				else
				{
					if (!Information.IsNothing((object)RectCheck))
					{
						val2.Add(ModAnimation.AaHeight(RectCheck, 0.0 - ((FrameworkElement)RectCheck).ActualHeight, 120, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)));
						val2.Add(ModAnimation.AaOpacity(RectCheck, 0.0 - ((UIElement)RectCheck).Opacity, 70, 40));
						((FrameworkElement)RectCheck).VerticalAlignment = (VerticalAlignment)1;
					}
					val2.Add(ModAnimation.AaColor((FrameworkElement)(object)this, ForegroundProperty, "ColorBrush1", 120));
				}
				ModAnimation.AniStart((System.Collections.IList)val2, "MyListItem Checked " + Conversions.ToString(Uuid));
				return;
			}
			ModAnimation.AniStop("MyListItem Checked " + Conversions.ToString(Uuid));
			if (Checked)
			{
				if (!Information.IsNothing((object)RectCheck))
				{
					((FrameworkElement)RectCheck).Height = 0.0 / 0.0;
					((FrameworkElement)RectCheck).Margin = new Thickness(-1.0, 6.0, 0.0, 6.0);
					((UIElement)RectCheck).Opacity = 1.0;
					((FrameworkElement)RectCheck).VerticalAlignment = (VerticalAlignment)3;
				}
				base.SetResourceReference(ForegroundProperty, (object)((((FrameworkElement)this).Height < 40.0) ? "ColorBrush3" : "ColorBrush2"));
			}
			else
			{
				if (!Information.IsNothing((object)RectCheck))
				{
					((FrameworkElement)RectCheck).Height = 0.0;
					((FrameworkElement)RectCheck).Margin = new Thickness(-1.0, 0.0, 0.0, 0.0);
					((UIElement)RectCheck).Opacity = 0.0;
					((FrameworkElement)RectCheck).VerticalAlignment = (VerticalAlignment)1;
				}
				base.SetResourceReference(ForegroundProperty, (object)"ColorBrush1");
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "设置 Checked 失败");
			ProjectData.ClearProjectError();
		}
	}

	private void Button_MouseUp(object sender, MouseButtonEventArgs e)
	{
		if (!IsMouseDown)
		{
			return;
		}
		ClickEvent?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
		if (((RoutedEventArgs)e).Handled)
		{
			return;
		}
		if (!string.IsNullOrEmpty(EventType))
		{
			ModEvent.TryStartEvent(EventType, EventData);
			((RoutedEventArgs)e).Handled = true;
		}
		if (((RoutedEventArgs)e).Handled)
		{
			return;
		}
		switch (Type)
		{
		case CheckType.Clickable:
			ModBase.Log("[Control] 按下单击列表项：" + Title);
			break;
		case CheckType.RadioBox:
			ModBase.Log("[Control] 按下单选列表项：" + Title);
			if (!Checked)
			{
				SetChecked(value: true, user: true, anime: true);
			}
			break;
		case CheckType.CheckBox:
			ModBase.Log("[Control] 按下复选列表项（" + !Checked + "）：" + Title);
			SetChecked(!Checked, user: true, anime: true);
			break;
		}
	}

	private void Button_MouseDown(object sender, MouseButtonEventArgs e)
	{
		if (((UIElement)this).IsMouseDirectlyOver && Type != 0)
		{
			IsMouseDown = true;
			if (ButtonStack != null)
			{
				((UIElement)ButtonStack).IsHitTestVisible = false;
			}
		}
	}

	private void Button_MouseLeave(object sender, object e)
	{
		IsMouseDown = false;
		if (ButtonStack != null)
		{
			((UIElement)ButtonStack).IsHitTestVisible = true;
		}
	}

	public void RefreshColor(object sender, EventArgs e)
	{
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0577: Expected O, but got Unknown
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Expected O, but got Unknown
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Expected O, but got Unknown
		//IL_04b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a9: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		if (ContentHandler != null)
		{
			ContentHandler.Invoke((MyListItem)sender, e);
			ContentHandler = null;
		}
		string text;
		int num;
		if (IsMouseDown && (Type != CheckType.RadioBox || !Checked))
		{
			text = "MouseDown";
			num = 120;
		}
		else if (((UIElement)this).IsMouseOver && IsMouseOverAnimationEnabled)
		{
			text = "MouseOver";
			num = 120;
		}
		else
		{
			text = "Idle";
			num = 180;
		}
		if (Operators.CompareString(StateLast, text, false) == 0)
		{
			return;
		}
		StateLast = text;
		checked
		{
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				List<ModAnimation.AniData> val = new List<ModAnimation.AniData>();
				GridLength width;
				if (((UIElement)this).IsMouseOver && IsMouseOverAnimationEnabled)
				{
					if (ButtonStack != null)
					{
						val.Add(ModAnimation.AaOpacity(ButtonStack, 1.0 - ((UIElement)ButtonStack).Opacity, (int)Math.Round((double)num * 0.7), (int)Math.Round((double)num * 0.3)));
						ParameterizedThreadStart val2 = [SpecialName] [CompilerGenerated] (object i) =>
						{
							//IL_002d: Unknown result type (might be due to invalid IL or missing references)
							//IL_0032: Unknown result type (might be due to invalid IL or missing references)
							//IL_0053: Unknown result type (might be due to invalid IL or missing references)
							ColumnDefinition columnPaddingRight2 = ColumnPaddingRight;
							System.Type typeFromHandle2 = typeof(Math);
							object[] obj2 = new object[] { 0, null };
							GridLength width3 = ColumnPaddingRight.Width;
							obj2[1] = Operators.AddObject((object)width3.Value, i);
							columnPaddingRight2.Width = new GridLength(Conversions.ToDouble(NewLateBinding.LateGet((object)null, typeFromHandle2, "Max", obj2, (string[])null, (System.Type[])null, (bool[])null)));
						};
						double num2 = Math.Max(MinPaddingRight, 5 + Enumerable.Count<MyIconButton>(Buttons) * 25);
						width = ColumnPaddingRight.Width;
						val.Add(ModAnimation.AaDouble(val2, num2 - width.Value, (int)Math.Round((double)num * 0.3), (int)Math.Round((double)num * 0.7)));
					}
					val.AddRange((System.Collections.Generic.IEnumerable<ModAnimation.AniData>)new ModAnimation.AniData[2]
					{
						ModAnimation.AaColor((FrameworkElement)(object)RectBack, Border.BackgroundProperty, IsMouseDown ? "ColorBrush6" : "ColorBrushBg1", num),
						ModAnimation.AaOpacity(RectBack, 1.0 - ((UIElement)RectBack).Opacity, num, 0, new ModAnimation.AniEaseOutFluent())
					});
					if (IsScaleAnimationEnabled)
					{
						val.Add(ModAnimation.AaScaleTransform(RectBack, 1.0 - ((ScaleTransform)((UIElement)RectBack).RenderTransform).ScaleX, (int)Math.Round((double)num * 1.6), 0, new ModAnimation.AniEaseOutFluent()));
						if (IsMouseDown)
						{
							val.Add(ModAnimation.AaScaleTransform(this, 0.98 - ((ScaleTransform)((UIElement)this).RenderTransform).ScaleX, (int)Math.Round((double)num * 0.9), 0, new ModAnimation.AniEaseOutFluent()));
						}
						else
						{
							val.Add(ModAnimation.AaScaleTransform(this, 1.0 - ((ScaleTransform)((UIElement)this).RenderTransform).ScaleX, (int)Math.Round((double)num * 1.2), 0, new ModAnimation.AniEaseOutFluent()));
						}
					}
				}
				else
				{
					if (ButtonStack != null)
					{
						val.Add(ModAnimation.AaOpacity(ButtonStack, 0.0 - ((UIElement)ButtonStack).Opacity, (int)Math.Round((double)num * 0.4)));
						ParameterizedThreadStart val3 = [SpecialName] [CompilerGenerated] (object i) =>
						{
							//IL_002d: Unknown result type (might be due to invalid IL or missing references)
							//IL_0032: Unknown result type (might be due to invalid IL or missing references)
							//IL_0053: Unknown result type (might be due to invalid IL or missing references)
							ColumnDefinition columnPaddingRight = ColumnPaddingRight;
							System.Type typeFromHandle = typeof(Math);
							object[] obj = new object[] { 0, null };
							GridLength width2 = ColumnPaddingRight.Width;
							obj[1] = Operators.AddObject((object)width2.Value, i);
							columnPaddingRight.Width = new GridLength(Conversions.ToDouble(NewLateBinding.LateGet((object)null, typeFromHandle, "Max", obj, (string[])null, (System.Type[])null, (bool[])null)));
						};
						double num3 = MinPaddingRight;
						width = ColumnPaddingRight.Width;
						val.Add(ModAnimation.AaDouble(val3, num3 - width.Value, (int)Math.Round((double)num * 0.4)));
					}
					val.Add(ModAnimation.AaOpacity(RectBack, 0.0 - ((UIElement)RectBack).Opacity, num));
					if (IsScaleAnimationEnabled)
					{
						val.AddRange((System.Collections.Generic.IEnumerable<ModAnimation.AniData>)new ModAnimation.AniData[4]
						{
							ModAnimation.AaColor((FrameworkElement)(object)RectBack, Border.BackgroundProperty, IsMouseDown ? "ColorBrush6" : "ColorBrush7", num),
							ModAnimation.AaScaleTransform(this, 1.0 - ((ScaleTransform)((UIElement)this).RenderTransform).ScaleX, num * 3, 0, new ModAnimation.AniEaseOutFluent()),
							ModAnimation.AaScaleTransform(RectBack, 0.996 - ((ScaleTransform)((UIElement)RectBack).RenderTransform).ScaleX, num, 0, new ModAnimation.AniEaseOutFluent()),
							ModAnimation.AaScaleTransform(RectBack, -0.246, 1, 0, null, After: true)
						});
					}
				}
				ModAnimation.AniStart((System.Collections.IList)val, "ListItem Color " + Conversions.ToString(Uuid));
				return;
			}
			if (((UIElement)this).IsMouseOver && IsMouseOverAnimationEnabled)
			{
				if (ButtonStack != null)
				{
					((UIElement)ButtonStack).Opacity = 1.0;
					ColumnPaddingRight.Width = new GridLength((double)Math.Max(MinPaddingRight, 5 + Enumerable.Count<MyIconButton>(Buttons) * 25));
				}
				RectBack.Background = (Brush)(object)ModSecret.DynamicColors.ColorBg1Brush;
				((UIElement)RectBack).Opacity = 1.0;
				((UIElement)RectBack).RenderTransform = (Transform)new ScaleTransform(1.0, 1.0);
				((UIElement)this).RenderTransform = (Transform)new ScaleTransform(1.0, 1.0);
			}
			else
			{
				if (ButtonStack != null)
				{
					((UIElement)ButtonStack).Opacity = 0.0;
					ColumnPaddingRight.Width = new GridLength((double)MinPaddingRight);
				}
				((UIElement)this).RenderTransform = (Transform)new ScaleTransform(1.0, 1.0);
				if (_RectBack != null)
				{
					if (IsScaleAnimationEnabled)
					{
						((UIElement)RectBack).RenderTransform = (Transform)new ScaleTransform(0.75, 0.75);
					}
					RectBack.Background = (Brush)(object)ModSecret.DynamicColors.Color7Brush;
					((UIElement)RectBack).Opacity = 0.0;
				}
			}
			ModAnimation.AniStop("ListItem Color " + Conversions.ToString(Uuid));
		}
	}

	private void MyListItem_Loaded(object sender, RoutedEventArgs e)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		if (Checked)
		{
			base.SetResourceReference(ForegroundProperty, (object)((((FrameworkElement)this).Height < 40.0) ? "ColorBrush3" : "ColorBrush2"));
		}
		else
		{
			base.SetResourceReference(ForegroundProperty, (object)"ColorBrush1");
		}
		ColumnPaddingRight.Width = new GridLength((double)MinPaddingRight);
		if (Operators.CompareString(EventType, "打开帮助", false) == 0 && (Operators.CompareString(Title, "", false) == 0 || Operators.CompareString(Info, "", false) == 0))
		{
			try
			{
				new ModMain.HelpEntry(ModEvent.GetEventAbsoluteUrls(EventData, EventType)[0]).SetToListItem(this);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "设置帮助 MyListItem 失败", ModBase.LogLevel.Msgbox);
				EventType = null;
				EventData = null;
				ProjectData.ClearProjectError();
			}
		}
	}

	public override string ToString()
	{
		return Title;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/mylistitem.xaml", (UriKind)2);
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
			PanBack = (MyListItem)target;
			break;
		case 2:
			ColumnCheck = (ColumnDefinition)target;
			break;
		case 3:
			ColumnPaddingLeft = (ColumnDefinition)target;
			break;
		case 4:
			ColumnLogo = (ColumnDefinition)target;
			break;
		case 5:
			ColumnPaddingRight = (ColumnDefinition)target;
			break;
		case 6:
			LabTitle = (TextBlock)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
