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
public class MyRadioButton : Border, IComponentConnector
{
	public delegate void CheckEventHandler(object sender, bool raiseByMouse);

	public delegate void ChangeEventHandler(object sender, bool raiseByMouse);

	public enum ColorState
	{
		White,
		Highlight
	}

	public delegate void PreviewClickEventHandler(object sender, ModBase.RouteEventArgs e);

	public int Uuid;

	[CompilerGenerated]
	private CheckEventHandler CheckEvent;

	[CompilerGenerated]
	private ChangeEventHandler ChangeEvent;

	private double _LogoScale;

	private bool _Checked;

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyRadioButton), new PropertyMetadata((PropertyChangedCallback)([SpecialName] (DependencyObject sender, DependencyPropertyChangedEventArgs e) =>
	{
		if (sender != null)
		{
			((MyRadioButton)(object)sender).LabText.Text = Conversions.ToString(e.NewValue);
		}
	})));

	private ColorState _ColorType;

	[CompilerGenerated]
	private PreviewClickEventHandler PreviewClickEvent;

	private bool IsMouseDown;

	private const int AnimationTimeOfMouseIn = 90;

	private const int AnimationTimeOfMouseOut = 150;

	private const int AnimationTimeOfCheck = 120;

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

	public bool Checked
	{
		get
		{
			return _Checked;
		}
		set
		{
			SetChecked(value, user: false, anime: true);
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
			return _ColorType;
		}
		set
		{
			_ColorType = value;
			RefreshColor();
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual MyRadioButton PanBack
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

	public event PreviewClickEventHandler PreviewClick
	{
		[CompilerGenerated]
		add
		{
			PreviewClickEventHandler previewClickEventHandler = PreviewClickEvent;
			PreviewClickEventHandler previewClickEventHandler2;
			do
			{
				previewClickEventHandler2 = previewClickEventHandler;
				PreviewClickEventHandler previewClickEventHandler3 = (PreviewClickEventHandler)System.Delegate.Combine((System.Delegate)previewClickEventHandler2, (System.Delegate)value);
				previewClickEventHandler = Interlocked.CompareExchange<PreviewClickEventHandler>(ref PreviewClickEvent, previewClickEventHandler3, previewClickEventHandler2);
			}
			while (previewClickEventHandler != previewClickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PreviewClickEventHandler previewClickEventHandler = PreviewClickEvent;
			PreviewClickEventHandler previewClickEventHandler2;
			do
			{
				previewClickEventHandler2 = previewClickEventHandler;
				PreviewClickEventHandler previewClickEventHandler3 = (PreviewClickEventHandler)System.Delegate.Remove((System.Delegate)previewClickEventHandler2, (System.Delegate)value);
				previewClickEventHandler = Interlocked.CompareExchange<PreviewClickEventHandler>(ref PreviewClickEvent, previewClickEventHandler3, previewClickEventHandler2);
			}
			while (previewClickEventHandler != previewClickEventHandler2);
		}
	}

	public MyRadioButton()
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
			Radiobox_MouseUp();
		});
		((UIElement)this).MouseLeftButtonDown += (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
		{
			Radiobox_MouseDown();
		});
		((UIElement)this).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			Radiobox_MouseLeave();
		});
		((UIElement)this).MouseEnter += new MouseEventHandler(RefreshColor);
		((UIElement)this).MouseLeave += new MouseEventHandler(RefreshColor);
		((FrameworkElement)this).Loaded += new RoutedEventHandler(RefreshColor);
		Uuid = ModBase.GetUuid();
		_LogoScale = 1.0;
		_Checked = false;
		_ColorType = ColorState.White;
		IsMouseDown = false;
		InitializeComponent();
	}

	public void RaiseChange()
	{
		ChangeEvent?.Invoke(this, raiseByMouse: false);
	}

	public void SetChecked(bool value, bool user, bool anime)
	{
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			bool flag = false;
			if (((FrameworkElement)this).IsLoaded && value != _Checked)
			{
				ChangeEvent?.Invoke(this, user);
			}
			if (value != _Checked)
			{
				_Checked = value;
				flag = true;
			}
			if (Information.IsNothing((object)((FrameworkElement)this).Parent))
			{
				return;
			}
			List<MyRadioButton> val = new List<MyRadioButton>();
			int num = 0;
			foreach (object item in (System.Collections.IEnumerable)NewLateBinding.LateGet((object)((FrameworkElement)this).Parent, (System.Type)null, "Children", new object[0], (string[])null, (System.Type[])null, (bool[])null))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				if (objectValue is MyRadioButton)
				{
					val.Add((MyRadioButton)objectValue);
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
					System.Collections.Generic.IEnumerator<MyRadioButton> enumerator2 = default(System.Collections.Generic.IEnumerator<MyRadioButton>);
					try
					{
						enumerator2 = val.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							MyRadioButton current = enumerator2.Current;
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
					bool flag2 = false;
					System.Collections.Generic.IEnumerator<MyRadioButton> enumerator3 = default(System.Collections.Generic.IEnumerator<MyRadioButton>);
					try
					{
						enumerator3 = val.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							MyRadioButton current2 = enumerator3.Current;
							if (current2.Checked)
							{
								if (flag2)
								{
									current2.Checked = false;
								}
								else
								{
									flag2 = true;
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
			if (flag)
			{
				RefreshColor(null, anime);
				if (Checked)
				{
					CheckEvent?.Invoke(this, user);
				}
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "单选按钮勾选改变错误", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private void Radiobox_MouseUp()
	{
		if (!Checked && IsMouseDown)
		{
			ModBase.Log("[Control] 按下单选按钮：" + Text);
			IsMouseDown = false;
			ModBase.RouteEventArgs routeEventArgs = new ModBase.RouteEventArgs(RaiseByMouse: true);
			PreviewClickEvent?.Invoke(this, routeEventArgs);
			if (!routeEventArgs.Handled)
			{
				SetChecked(value: true, user: true, anime: true);
			}
		}
	}

	private void Radiobox_MouseDown()
	{
		if (!Checked)
		{
			IsMouseDown = true;
			RefreshColor();
		}
	}

	private void Radiobox_MouseLeave()
	{
		IsMouseDown = false;
	}

	private void RefreshColor(object obj = null, object e = null)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0 && !false.Equals(RuntimeHelpers.GetObjectValue(e)))
			{
				switch (ColorType)
				{
				case ColorState.White:
					if (Checked)
					{
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
						{
							ModAnimation.AaColor((FrameworkElement)(object)ShapeLogo, Shape.FillProperty, new ModBase.MyColor(ModSecret.DynamicColors.Color3) - ((Shape)ShapeLogo).Fill, 120),
							ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, new ModBase.MyColor(ModSecret.DynamicColors.Color3) - LabText.Foreground, 120)
						}, "MyRadioButton Checked " + Conversions.ToString(Uuid));
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - ((Border)this).Background, 120), "MyRadioButton Color " + Conversions.ToString(Uuid));
					}
					else if (IsMouseDown)
					{
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, new ModBase.MyColor(120.0, ModSecret.DynamicColors.Color8) - ((Border)this).Background, 60), "MyRadioButton Color " + Conversions.ToString(Uuid));
					}
					else if (((UIElement)this).IsMouseOver)
					{
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
						{
							ModAnimation.AaColor((FrameworkElement)(object)ShapeLogo, Shape.FillProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - ((Shape)ShapeLogo).Fill, 90),
							ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - LabText.Foreground, 90)
						}, "MyRadioButton Checked " + Conversions.ToString(Uuid));
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, new ModBase.MyColor(50.0, ModSecret.DynamicColors.Color8) - ((Border)this).Background, 90), "MyRadioButton Color " + Conversions.ToString(Uuid));
					}
					else
					{
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
						{
							ModAnimation.AaColor((FrameworkElement)(object)ShapeLogo, Shape.FillProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - ((Shape)ShapeLogo).Fill, 150),
							ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - LabText.Foreground, 150)
						}, "MyRadioButton Checked " + Conversions.ToString(Uuid));
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, ModSecret.ColorSemiTransparent - ((Border)this).Background, 150), "MyRadioButton Color " + Conversions.ToString(Uuid));
					}
					break;
				case ColorState.Highlight:
					if (Checked)
					{
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
						{
							ModAnimation.AaColor((FrameworkElement)(object)ShapeLogo, Shape.FillProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - ((Shape)ShapeLogo).Fill, 120),
							ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, new ModBase.MyColor(255.0, 255.0, 255.0) - LabText.Foreground, 120)
						}, "MyRadioButton Checked " + Conversions.ToString(Uuid));
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, "ColorBrush3", 120), "MyRadioButton Color " + Conversions.ToString(Uuid));
					}
					else if (IsMouseDown)
					{
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, "ColorBrush6", 90), "MyRadioButton Color " + Conversions.ToString(Uuid));
					}
					else if (((UIElement)this).IsMouseOver)
					{
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
						{
							ModAnimation.AaColor((FrameworkElement)(object)ShapeLogo, Shape.FillProperty, "ColorBrush3", 90),
							ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, "ColorBrush3", 90)
						}, "MyRadioButton Checked " + Conversions.ToString(Uuid));
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, "ColorBrush7", 90), "MyRadioButton Color " + Conversions.ToString(Uuid));
					}
					else
					{
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
						{
							ModAnimation.AaColor((FrameworkElement)(object)ShapeLogo, Shape.FillProperty, "ColorBrush3", 150),
							ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, "ColorBrush3", 150)
						}, "MyRadioButton Checked " + Conversions.ToString(Uuid));
						ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)this, Border.BackgroundProperty, ModSecret.ColorSemiTransparent - ((Border)this).Background, 150), "MyRadioButton Color " + Conversions.ToString(Uuid));
					}
					break;
				}
				return;
			}
			ModAnimation.AniStop("MyRadioButton Checked " + Conversions.ToString(Uuid));
			ModAnimation.AniStop("MyRadioButton Color " + Conversions.ToString(Uuid));
			switch (ColorType)
			{
			case ColorState.White:
				if (Checked)
				{
					((Border)this).Background = new ModBase.MyColor(255.0, 255.0, 255.0);
					((FrameworkElement)ShapeLogo).SetResourceReference(Shape.FillProperty, (object)"ColorBrush3");
					((FrameworkElement)LabText).SetResourceReference(TextBlock.ForegroundProperty, (object)"ColorBrush3");
				}
				else
				{
					((Border)this).Background = ModSecret.ColorSemiTransparent;
					((Shape)ShapeLogo).Fill = new ModBase.MyColor(255.0, 255.0, 255.0);
					LabText.Foreground = new ModBase.MyColor(255.0, 255.0, 255.0);
				}
				break;
			case ColorState.Highlight:
				if (Checked)
				{
					base.SetResourceReference(Border.BackgroundProperty, (object)"ColorBrush3");
					((Shape)ShapeLogo).Fill = new ModBase.MyColor(255.0, 255.0, 255.0);
					LabText.Foreground = new ModBase.MyColor(255.0, 255.0, 255.0);
				}
				else
				{
					((Border)this).Background = ModSecret.ColorSemiTransparent;
					((FrameworkElement)ShapeLogo).SetResourceReference(Shape.FillProperty, (object)"ColorBrush3");
					((FrameworkElement)LabText).SetResourceReference(TextBlock.ForegroundProperty, (object)"ColorBrush3");
				}
				break;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "刷新单选按钮颜色出错");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/myradiobutton.xaml", (UriKind)2);
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
			PanBack = (MyRadioButton)target;
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
