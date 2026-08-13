using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.UI;

namespace PCL;

[ContentProperty("Inlines")]
[DesignerGenerated]
public class MyHint : Border, IComponentConnector
{
	public enum Themes
	{
		Blue,
		Red,
		Yellow
	}

	public int Uuid;

	private Themes _ColorType;

	public static readonly DependencyProperty IsWarnProperty = DependencyProperty.Register("IsWarn", typeof(bool), typeof(MyHint), new PropertyMetadata((object)true, (PropertyChangedCallback)([SpecialName] (DependencyObject a0, DependencyPropertyChangedEventArgs a1) =>
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		((VB_0024AnonymousDelegate_2<MyHint, DependencyPropertyChangedEventArgs>)([SpecialName] (MyHint d, DependencyPropertyChangedEventArgs e) =>
		{
			d.Theme = (Conversions.ToBoolean(e.NewValue) ? Themes.Red : Themes.Blue);
		}))((MyHint)(object)a0, a1);
	})));

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyHint), new PropertyMetadata((object)"", (PropertyChangedCallback)([SpecialName] (DependencyObject a0, DependencyPropertyChangedEventArgs a1) =>
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		((VB_0024AnonymousDelegate_2<MyHint, DependencyPropertyChangedEventArgs>)([SpecialName] (MyHint d, DependencyPropertyChangedEventArgs e) =>
		{
			d.LabText.Text = Conversions.ToString(e.NewValue);
		}))((MyHint)(object)a0, a1);
	})));

	private bool IsMouseDown;

	public static readonly DependencyProperty EventTypeProperty = DependencyProperty.Register("EventType", typeof(string), typeof(MyHint), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty EventDataProperty = DependencyProperty.Register("EventData", typeof(string), typeof(MyHint), new PropertyMetadata((PropertyChangedCallback)null));

	[CompilerGenerated]
	[AccessedThroughProperty("BtnClose")]
	private MyIconButton _BtnClose;

	private bool _contentLoaded;

	public bool HasBorder
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			Thickness borderThickness = ((Border)this).BorderThickness;
			return borderThickness.Top > 0.0;
		}
		set
		{
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			if (value)
			{
				((Border)this).BorderThickness = new Thickness(3.0, ModBase.GetWPFSize(1.0), ModBase.GetWPFSize(1.0), ModBase.GetWPFSize(1.0));
			}
			else
			{
				((Border)this).BorderThickness = new Thickness(3.0, 0.0, 0.0, 0.0);
			}
		}
	}

	public Themes Theme
	{
		get
		{
			return _ColorType;
		}
		set
		{
			_ColorType = value;
			UpdateUI();
		}
	}

	[Obsolete("IsWarn 已过时。请换用 Theme 属性。")]
	public bool IsWarn
	{
		get
		{
			return Theme == Themes.Red;
		}
		set
		{
			Theme = (value ? Themes.Red : Themes.Blue);
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

	public bool CanClose
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Invalid comparison between Unknown and I4
			return (int)((UIElement)BtnClose).Visibility == 0;
		}
		set
		{
			((UIElement)BtnClose).Visibility = (Visibility)((!value) ? 2 : 0);
		}
	}

	[field: CompilerGenerated]
	public string RelativeSetup
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
	internal virtual MyHint PanBack
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

	internal virtual MyIconButton BtnClose
	{
		[CompilerGenerated]
		get
		{
			return _BtnClose;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = BtnClose_Click;
			MyIconButton btnClose = _BtnClose;
			if (btnClose != null)
			{
				btnClose.Click -= obj;
			}
			_BtnClose = value;
			btnClose = _BtnClose;
			if (btnClose != null)
			{
				btnClose.Click += obj;
			}
		}
	}

	private void UpdateUI()
	{
		double sH = default(double);
		switch (Theme)
		{
		case Themes.Blue:
			sH = 210.0;
			break;
		case Themes.Red:
			sH = 355.0;
			break;
		case Themes.Yellow:
			sH = 40.0;
			break;
		}
		GrayProfile grayProfile = ModSecret.CurrentProfile();
		((Border)this).Background = new ModBase.MyColor().FromHSL2(sH, 90.0, grayProfile.L7);
		((Border)this).BorderBrush = new ModBase.MyColor().FromHSL2(sH, 90.0, grayProfile.L2);
		LabText.Foreground = new ModBase.MyColor().FromHSL2(sH, 90.0, grayProfile.L2);
		BtnClose.Foreground = new ModBase.MyColor().FromHSL2(sH, 90.0, grayProfile.L2);
	}

	private void MyHint_Loaded(object sender, RoutedEventArgs e)
	{
		ModSecret.ThemeChanged += _ThemeChanged;
		if (Conversions.ToBoolean((object)(CanClose && Conversions.ToBoolean(ModBase.Setup.Get(RelativeSetup)))))
		{
			((UIElement)this).Visibility = (Visibility)2;
		}
	}

	private void BtnClose_Click(object sender, EventArgs e)
	{
		ModBase.Setup.Set(RelativeSetup, true);
		ModAnimation.AniDispose(this, RemoveFromChildren: false);
	}

	private void MyHint_MouseUp(object sender, MouseButtonEventArgs e)
	{
		if (IsMouseDown)
		{
			IsMouseDown = false;
			ModBase.Log("[Control] 按下提示条" + (string.IsNullOrEmpty(((FrameworkElement)this).Name) ? "" : ("：" + ((FrameworkElement)this).Name)));
			((RoutedEventArgs)e).Handled = true;
			ModEvent.TryStartEvent(EventType, EventData);
		}
	}

	private void MyHint_MouseDown(object sender, MouseButtonEventArgs e)
	{
		IsMouseDown = true;
	}

	private void MyHint_MouseLeave()
	{
		IsMouseDown = false;
	}

	private void _ThemeChanged(object sender, bool e)
	{
		UpdateUI();
	}

	public MyHint()
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
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			UpdateUI();
		});
		((FrameworkElement)this).Loaded += new RoutedEventHandler(MyHint_Loaded);
		((UIElement)this).MouseLeftButtonUp += new MouseButtonEventHandler(MyHint_MouseUp);
		((UIElement)this).MouseLeftButtonDown += new MouseButtonEventHandler(MyHint_MouseDown);
		((UIElement)this).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			MyHint_MouseLeave();
		});
		((FrameworkElement)this).Unloaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Dispose();
		});
		Uuid = ModBase.GetUuid();
		_ColorType = Themes.Red;
		RelativeSetup = "";
		IsMouseDown = false;
		InitializeComponent();
		UpdateUI();
	}

	private void Dispose()
	{
		ModSecret.ThemeChanged -= _ThemeChanged;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/myhint.xaml", (UriKind)2);
			Application.LoadComponent((object)this, val);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	internal System.Delegate _CreateDelegate(System.Type delegateType, string handler)
	{
		return System.Delegate.CreateDelegate(delegateType, (object)this, handler);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	[EditorBrowsable(/*Could not decode attribute arguments.*/)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyHint)target;
			break;
		case 2:
			LabText = (TextBlock)target;
			break;
		case 3:
			BtnClose = (MyIconButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
