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
using System.Windows.Shapes;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[ContentProperty("Inlines")]
[DesignerGenerated]
public class MyRadioBox : Grid, IMyRadio, IComponentConnector
{
	public delegate void PreviewCheckEventHandler(object sender, ModBase.RouteEventArgs e);

	public delegate void PreviewChangeEventHandler(object sender, ModBase.RouteEventArgs e);

	public int Uuid;

	[CompilerGenerated]
	private PreviewCheckEventHandler PreviewCheckEvent;

	[CompilerGenerated]
	private PreviewChangeEventHandler PreviewChangeEvent;

	[CompilerGenerated]
	private IMyRadio.CheckEventHandler CheckEvent;

	[CompilerGenerated]
	private IMyRadio.ChangedEventHandler ChangedEvent;

	public static readonly DependencyProperty CheckedProperty = DependencyProperty.Register("Checked", typeof(bool), typeof(MyRadioBox), new PropertyMetadata((object)false, (PropertyChangedCallback)([SpecialName] (DependencyObject a0, DependencyPropertyChangedEventArgs a1) =>
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		((VB_0024AnonymousDelegate_2<MyRadioBox, DependencyPropertyChangedEventArgs>)([SpecialName] (MyRadioBox d, DependencyPropertyChangedEventArgs e) =>
		{
			if (!((FrameworkElement)d).IsLoaded)
			{
				d.SyncUI();
			}
		}))((MyRadioBox)(object)a0, a1);
	})));

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyRadioBox), new PropertyMetadata((PropertyChangedCallback)([SpecialName] (DependencyObject sender, DependencyPropertyChangedEventArgs e) =>
	{
		if (sender != null)
		{
			((MyRadioBox)(object)sender).LabText.Text = Conversions.ToString(e.NewValue);
		}
	})));

	private bool MouseDowned;

	private bool AllowMouseDown;

	private const int AnimationTimeOfMouseIn = 100;

	private const int AnimationTimeOfMouseOut = 200;

	private const int AnimationTimeOfCheck = 150;

	private bool _contentLoaded;

	public bool Checked
	{
		get
		{
			return Conversions.ToBoolean(base.GetValue(CheckedProperty));
		}
		set
		{
			SetChecked(value, user: false);
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

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual MyRadioBox PanBack
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

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ShapeBorder")]
	internal virtual Ellipse ShapeBorder
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

	public event PreviewCheckEventHandler PreviewCheck
	{
		[CompilerGenerated]
		add
		{
			PreviewCheckEventHandler previewCheckEventHandler = PreviewCheckEvent;
			PreviewCheckEventHandler previewCheckEventHandler2;
			do
			{
				previewCheckEventHandler2 = previewCheckEventHandler;
				PreviewCheckEventHandler previewCheckEventHandler3 = (PreviewCheckEventHandler)System.Delegate.Combine((System.Delegate)previewCheckEventHandler2, (System.Delegate)value);
				previewCheckEventHandler = Interlocked.CompareExchange<PreviewCheckEventHandler>(ref PreviewCheckEvent, previewCheckEventHandler3, previewCheckEventHandler2);
			}
			while (previewCheckEventHandler != previewCheckEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PreviewCheckEventHandler previewCheckEventHandler = PreviewCheckEvent;
			PreviewCheckEventHandler previewCheckEventHandler2;
			do
			{
				previewCheckEventHandler2 = previewCheckEventHandler;
				PreviewCheckEventHandler previewCheckEventHandler3 = (PreviewCheckEventHandler)System.Delegate.Remove((System.Delegate)previewCheckEventHandler2, (System.Delegate)value);
				previewCheckEventHandler = Interlocked.CompareExchange<PreviewCheckEventHandler>(ref PreviewCheckEvent, previewCheckEventHandler3, previewCheckEventHandler2);
			}
			while (previewCheckEventHandler != previewCheckEventHandler2);
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

	public MyRadioBox()
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
		((UIElement)this).IsEnabledChanged += (DependencyPropertyChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, DependencyPropertyChangedEventArgs a1) =>
		{
			Radiobox_IsEnabledChanged();
		});
		((UIElement)this).MouseEnter += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			Radiobox_MouseEnterAnimation();
		});
		((UIElement)this).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			Radiobox_MouseLeaveAnimation();
		});
		Uuid = ModBase.GetUuid();
		MouseDowned = false;
		AllowMouseDown = true;
		InitializeComponent();
	}

	public void SetChecked(bool value, bool user)
	{
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (value && user)
			{
				ModBase.RouteEventArgs routeEventArgs = new ModBase.RouteEventArgs(user);
				PreviewCheckEvent?.Invoke(this, routeEventArgs);
				if (routeEventArgs.Handled)
				{
					Radiobox_MouseLeave();
					return;
				}
			}
			bool flag = false;
			if (((FrameworkElement)this).IsLoaded && value != Checked)
			{
				PreviewChangeEvent?.Invoke(this, new ModBase.RouteEventArgs(user));
			}
			if (value != Checked)
			{
				base.SetValue(CheckedProperty, (object)value);
				flag = true;
			}
			if (((FrameworkElement)this).Parent == null)
			{
				return;
			}
			List<MyRadioBox> val = new List<MyRadioBox>();
			int num = 0;
			foreach (object item in (System.Collections.IEnumerable)NewLateBinding.LateGet((object)((FrameworkElement)this).Parent, (System.Type)null, "Children", new object[0], (string[])null, (System.Type[])null, (bool[])null))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				if (objectValue is MyRadioBox)
				{
					val.Add((MyRadioBox)objectValue);
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
					System.Collections.Generic.IEnumerator<MyRadioBox> enumerator2 = default(System.Collections.Generic.IEnumerator<MyRadioBox>);
					try
					{
						enumerator2 = val.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							MyRadioBox current = enumerator2.Current;
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
					System.Collections.Generic.IEnumerator<MyRadioBox> enumerator3 = default(System.Collections.Generic.IEnumerator<MyRadioBox>);
					try
					{
						enumerator3 = val.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							MyRadioBox current2 = enumerator3.Current;
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
				if (Checked)
				{
					CheckEvent?.Invoke(this, new ModBase.RouteEventArgs(user));
				}
				ChangedEvent?.Invoke(this, new ModBase.RouteEventArgs(user));
			}
			SyncUI();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "单选框勾选改变错误", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private void SyncUI()
	{
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		if (ModAnimation.AniControlEnabled == 0 && ((FrameworkElement)this).IsLoaded)
		{
			if (Checked)
			{
				if (((UIElement)ShapeDot).Opacity < 0.01)
				{
					((UIElement)ShapeDot).Opacity = 1.0;
				}
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaScale(ShapeBorder, 10.0 - ((FrameworkElement)ShapeBorder).Width, 150, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak), After: false, Absolute: true),
					ModAnimation.AaScale(ShapeBorder, 8.0, 300, 90, new ModAnimation.AniEaseOutBack(), After: false, Absolute: true)
				}, "MyRadioBox Border " + Conversions.ToString(Uuid));
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaScale(ShapeDot, 9.0 - ((FrameworkElement)ShapeDot).Width, 390, 0, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak), After: false, Absolute: true),
					ModAnimation.AaOpacity(ShapeDot, 1.0 - ((UIElement)ShapeDot).Opacity, 75, 90)
				}, "MyRadioBox Dot " + Conversions.ToString(Uuid));
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Shape.StrokeProperty, ((UIElement)this).IsMouseOver ? "ColorBrush3" : (((UIElement)this).IsEnabled ? "ColorBrush2" : "ColorBrushGray4"), 150) }, "MyRadioBox BorderColor " + Conversions.ToString(Uuid));
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScale(ShapeBorder, 18.0 - ((FrameworkElement)ShapeBorder).Width, 150, 0, new ModAnimation.AniEaseOutFluent(), After: false, Absolute: true) }, "MyRadioBox Border " + Conversions.ToString(Uuid));
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaScale(ShapeDot, 0.0 - ((FrameworkElement)ShapeDot).Width, 150, 0, new ModAnimation.AniEaseInFluent(), After: false, Absolute: true),
					ModAnimation.AaOpacity(ShapeDot, 0.0 - ((UIElement)ShapeDot).Opacity, 75, 30)
				}, "MyRadioBox Dot " + Conversions.ToString(Uuid));
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Shape.StrokeProperty, ((UIElement)this).IsMouseOver ? "ColorBrush3" : (((UIElement)this).IsEnabled ? "ColorBrush1" : "ColorBrushGray4"), 150) }, "MyRadioBox BorderColor " + Conversions.ToString(Uuid));
			}
		}
		else
		{
			ModAnimation.AniStop("MyRadioBox Border " + Conversions.ToString(Uuid));
			ModAnimation.AniStop("MyRadioBox Dot " + Conversions.ToString(Uuid));
			ModAnimation.AniStop("MyRadioBox BorderColor " + Conversions.ToString(Uuid));
			if (Checked)
			{
				((FrameworkElement)ShapeDot).Width = 9.0;
				((FrameworkElement)ShapeDot).Height = 9.0;
				((UIElement)ShapeDot).Opacity = 1.0;
				((FrameworkElement)ShapeDot).Margin = new Thickness(5.5, 0.0, 0.0, 0.0);
				((FrameworkElement)ShapeBorder).SetResourceReference(Shape.StrokeProperty, (object)(((UIElement)this).IsEnabled ? "ColorBrush2" : "ColorBrushGray4"));
			}
			else
			{
				((FrameworkElement)ShapeDot).Width = 0.0;
				((FrameworkElement)ShapeDot).Height = 0.0;
				((UIElement)ShapeDot).Opacity = 0.0;
				((FrameworkElement)ShapeDot).Margin = new Thickness(10.0, 0.0, 0.0, 0.0);
				((FrameworkElement)ShapeBorder).SetResourceReference(Shape.StrokeProperty, (object)(((UIElement)this).IsEnabled ? "ColorBrush1" : "ColorBrushGray4"));
			}
		}
	}

	private void Radiobox_MouseUp()
	{
		if (MouseDowned)
		{
			ModBase.Log("[Control] 按下单选框：" + Text);
			SetChecked(value: true, user: true);
			MouseDowned = false;
			ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Shape.FillProperty, "ColorBrushHalfWhite", 100), "MyRadioBox Background " + Conversions.ToString(Uuid));
		}
	}

	private void Radiobox_MouseDown()
	{
		MouseDowned = true;
		base.Focus();
		ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Shape.FillProperty, "ColorBrushBg1", 100), "MyRadioBox Background " + Conversions.ToString(Uuid));
		if (!Checked)
		{
			ModAnimation.AniStart(ModAnimation.AaScale(ShapeBorder, 16.5 - ((FrameworkElement)ShapeBorder).Width, 1000, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong), After: false, Absolute: true), "MyRadioBox Border " + Conversions.ToString(Uuid));
		}
	}

	private void Radiobox_MouseLeave()
	{
		if (MouseDowned)
		{
			MouseDowned = false;
			ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Shape.FillProperty, "ColorBrushHalfWhite", 100), "MyRadioBox Background " + Conversions.ToString(Uuid));
			if (!Checked)
			{
				ModAnimation.AniStart(ModAnimation.AaScale(ShapeBorder, 18.0 - ((FrameworkElement)ShapeBorder).Width, 400, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong), After: false, Absolute: true), "MyRadioBox Border " + Conversions.ToString(Uuid));
			}
		}
	}

	private void Radiobox_IsEnabledChanged()
	{
		if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
		{
			if (((UIElement)this).IsEnabled)
			{
				Radiobox_MouseLeaveAnimation();
				return;
			}
			ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Shape.StrokeProperty, ModSecret.ColorGray4 - ((Shape)ShapeBorder).Stroke, 200), "MyRadioBox BorderColor " + Conversions.ToString(Uuid));
			ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, ModSecret.ColorGray4 - LabText.Foreground, 200), "MyRadioBox TextColor " + Conversions.ToString(Uuid));
		}
		else
		{
			ModAnimation.AniStop("MyRadioBox BorderColor " + Conversions.ToString(Uuid));
			ModAnimation.AniStop("MyRadioBox TextColor " + Conversions.ToString(Uuid));
			((FrameworkElement)LabText).SetResourceReference(TextBlock.ForegroundProperty, (object)(((UIElement)this).IsEnabled ? "ColorBrush1" : "ColorBrushGray4"));
			((FrameworkElement)ShapeBorder).SetResourceReference(Shape.StrokeProperty, (object)((!((UIElement)this).IsEnabled) ? "ColorBrushGray4" : (Checked ? "ColorBrush2" : "ColorBrush1")));
		}
	}

	private void Radiobox_MouseEnterAnimation()
	{
		ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Shape.StrokeProperty, "ColorBrush3", 100), "MyRadioBox BorderColor " + Conversions.ToString(Uuid));
		ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, "ColorBrush3", 100), "MyRadioBox TextColor " + Conversions.ToString(Uuid));
	}

	private void Radiobox_MouseLeaveAnimation()
	{
		if (((UIElement)this).IsEnabled)
		{
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Shape.StrokeProperty, (!((UIElement)this).IsEnabled) ? "ColorBrushGray4" : (Checked ? "ColorBrush2" : "ColorBrush1"), 200), "MyRadioBox BorderColor " + Conversions.ToString(Uuid));
				ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, ((UIElement)this).IsEnabled ? "ColorBrush1" : "ColorBrushGray4", 200), "MyRadioBox TextColor " + Conversions.ToString(Uuid));
				return;
			}
			ModAnimation.AniStop("MyRadioBox BorderColor " + Conversions.ToString(Uuid));
			ModAnimation.AniStop("MyRadioBox TextColor " + Conversions.ToString(Uuid));
			((FrameworkElement)ShapeBorder).SetResourceReference(Shape.StrokeProperty, (object)((!((UIElement)this).IsEnabled) ? "ColorBrushGray4" : (Checked ? "ColorBrush2" : "ColorBrush1")));
			((FrameworkElement)LabText).SetResourceReference(TextBlock.ForegroundProperty, (object)(((UIElement)this).IsEnabled ? "ColorBrush1" : "ColorBrushGray4"));
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/myradiobox.xaml", (UriKind)2);
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
		switch (connectionId)
		{
		case 1:
			PanBack = (MyRadioBox)target;
			break;
		case 2:
			LabText = (TextBlock)target;
			break;
		case 3:
			ShapeBorder = (Ellipse)target;
			break;
		case 4:
			ShapeDot = (Ellipse)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
