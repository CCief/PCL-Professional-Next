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
public class MyCheckBox : Grid, IComponentConnector
{
	public delegate void ChangeEventHandler(object sender, bool user);

	public delegate void PreviewChangeEventHandler(object sender, ModBase.RouteEventArgs e);

	public int Uuid;

	[CompilerGenerated]
	private ChangeEventHandler ChangeEvent;

	[CompilerGenerated]
	private PreviewChangeEventHandler PreviewChangeEvent;

	public static readonly DependencyProperty CheckedProperty = DependencyProperty.Register("Checked", typeof(bool?), typeof(MyCheckBox), new PropertyMetadata((object)false, (PropertyChangedCallback)([SpecialName] (DependencyObject a0, DependencyPropertyChangedEventArgs a1) =>
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		((VB_0024AnonymousDelegate_2<MyCheckBox, DependencyPropertyChangedEventArgs>)([SpecialName] (MyCheckBox d, DependencyPropertyChangedEventArgs e) =>
		{
			if (!((FrameworkElement)d).IsLoaded)
			{
				d.SyncUI();
			}
		}))((MyCheckBox)(object)a0, a1);
	})));

	public static readonly DependencyProperty IsThreeStateProperty = DependencyProperty.Register("IsThreeState", typeof(bool), typeof(MyCheckBox), new PropertyMetadata((object)false));

	private const int AnimationTimeOfCheck = 150;

	private bool? _previousState;

	public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(MyCheckBox), new PropertyMetadata((PropertyChangedCallback)([SpecialName] (DependencyObject sender, DependencyPropertyChangedEventArgs e) =>
	{
		if (!Information.IsNothing((object)sender))
		{
			((MyCheckBox)(object)sender).LabText.Text = Conversions.ToString(e.NewValue);
		}
	})));

	private bool MouseDowned;

	private bool AllowMouseDown;

	private const int AnimationTimeOfMouseIn = 100;

	private const int AnimationTimeOfMouseOut = 200;

	private bool _contentLoaded;

	public bool? Checked
	{
		get
		{
			return (bool?)base.GetValue(CheckedProperty);
		}
		set
		{
			SetChecked(value, user: false);
		}
	}

	public bool IsThreeState
	{
		get
		{
			return Conversions.ToBoolean(base.GetValue(IsThreeStateProperty));
		}
		set
		{
			base.SetValue(IsThreeStateProperty, (object)value);
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
	internal virtual MyCheckBox PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabText")]
	public virtual TextBlock LabText
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ShapeBorder")]
	internal virtual Border ShapeBorder
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ShapeCheck")]
	internal virtual Path ShapeCheck
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ShapeIndeterminate")]
	internal virtual Border ShapeIndeterminate
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

	public MyCheckBox()
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
			Checkbox_MouseUp();
		});
		((UIElement)this).MouseLeftButtonDown += (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
		{
			Checkbox_MouseDown();
		});
		((UIElement)this).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			Checkbox_MouseLeave();
		});
		((UIElement)this).IsEnabledChanged += (DependencyPropertyChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, DependencyPropertyChangedEventArgs a1) =>
		{
			Checkbox_IsEnabledChanged();
		});
		((UIElement)this).MouseEnter += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			Checkbox_MouseEnterAnimation();
		});
		((UIElement)this).MouseLeave += (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
		{
			Checkbox_MouseLeaveAnimation();
		});
		Uuid = ModBase.GetUuid();
		_previousState = false;
		MouseDowned = false;
		AllowMouseDown = true;
		InitializeComponent();
	}

	public void RaiseChange()
	{
		ChangeEvent?.Invoke(this, user: false);
	}

	public void SetChecked(bool? value, bool user)
	{
		try
		{
			bool? flag = value;
			bool? @checked = Checked;
			if (((flag.HasValue & @checked.HasValue) ? new bool?(flag.GetValueOrDefault() == @checked.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				return;
			}
			@checked = value;
			if ((@checked ?? true) && user && @checked.HasValue)
			{
				ModBase.RouteEventArgs routeEventArgs = new ModBase.RouteEventArgs(user);
				PreviewChangeEvent?.Invoke(this, routeEventArgs);
				if (routeEventArgs.Handled)
				{
					MouseDowned = true;
					Checkbox_MouseLeave();
					MouseDowned = false;
					return;
				}
			}
			bool? finalState = GetFinalState(value, IsThreeState);
			_previousState = Checked;
			base.SetValue(CheckedProperty, (object)finalState);
			if (((FrameworkElement)this).IsLoaded)
			{
				ChangeEvent?.Invoke(this, user);
			}
			SyncUI();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "设置 Checked 失败");
			ProjectData.ClearProjectError();
		}
	}

	private void SyncUI()
	{
		//IL_047d: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_043a: Unknown result type (might be due to invalid IL or missing references)
		if (ModAnimation.AniControlEnabled == 0 && ((FrameworkElement)this).IsLoaded)
		{
			AllowMouseDown = false;
			bool? finalState = GetFinalState(Checked, IsThreeState);
			bool flag = true;
			bool flag2 = flag;
			bool? flag3 = finalState;
			bool? flag4 = flag3;
			bool flag5;
			if ((flag4.HasValue ? new bool?(flag2 == flag4.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				flag2 = true;
				flag5 = flag2;
				flag4 = !_previousState;
				if ((flag4.HasValue ? new bool?(flag5 == flag4.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					AniBackgroundScale();
					AniCheckShow();
					AniColorChecked();
					AniAllowMouseDown();
				}
				else if (flag2 == !_previousState.HasValue)
				{
					AniBackgroundScale();
					AniIndeterminateHide();
					AniCheckShow();
					AniColorChecked();
					AniAllowMouseDown();
				}
				return;
			}
			flag5 = flag;
			flag4 = !finalState;
			if ((flag4.HasValue ? new bool?(flag5 == flag4.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				flag5 = true;
				bool flag6 = flag5;
				flag3 = _previousState;
				flag4 = flag3;
				if ((flag4.HasValue ? new bool?(flag6 == flag4.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					AniBackgroundScale();
					AniCheckHide();
					AniColorUnchecked();
					AniAllowMouseDown();
				}
				else if (flag5 == !_previousState.HasValue)
				{
					AniBackgroundScale();
					AniIndeterminateHide();
					AniCheckHide();
					AniColorUnchecked();
					AniAllowMouseDown();
				}
			}
			else
			{
				if (flag != !finalState.HasValue)
				{
					return;
				}
				bool flag6 = true;
				bool flag7 = flag6;
				flag3 = _previousState;
				flag4 = flag3;
				if ((flag4.HasValue ? new bool?(flag7 == flag4.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					AniBackgroundScale();
					AniCheckHide();
					AniIndeterminateShow();
					AniColorUnchecked();
					AniAllowMouseDown();
					return;
				}
				flag7 = flag6;
				flag4 = !_previousState;
				if ((flag4.HasValue ? new bool?(flag7 == flag4.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					AniBackgroundScale();
					AniIndeterminateShow();
					AniColorUnchecked();
					AniAllowMouseDown();
				}
			}
		}
		else
		{
			ModAnimation.AniStop("MyCheckBox Background Scale " + Conversions.ToString(Uuid));
			ModAnimation.AniStop("MyCheckBox Check Scale Show" + Conversions.ToString(Uuid));
			ModAnimation.AniStop("MyCheckBox Check Scale Hide" + Conversions.ToString(Uuid));
			ModAnimation.AniStop("MyCheckBox Indeterminate Scale Show" + Conversions.ToString(Uuid));
			ModAnimation.AniStop("MyCheckBox Indeterminate Scale Hide" + Conversions.ToString(Uuid));
			ModAnimation.AniStop("MyCheckBox BorderColor " + Conversions.ToString(Uuid));
			ModAnimation.AniStop("MyCheckBox AllowMouseDown " + Conversions.ToString(Uuid));
			if (Checked.GetValueOrDefault())
			{
				((ScaleTransform)((UIElement)ShapeCheck).RenderTransform).ScaleX = 1.0;
				((ScaleTransform)((UIElement)ShapeCheck).RenderTransform).ScaleY = 1.0;
				((FrameworkElement)ShapeBorder).SetResourceReference(Border.BorderBrushProperty, (object)(((UIElement)this).IsEnabled ? "ColorBrush2" : "ColorBrushGray4"));
			}
			else
			{
				((ScaleTransform)((UIElement)ShapeCheck).RenderTransform).ScaleX = 0.0;
				((ScaleTransform)((UIElement)ShapeCheck).RenderTransform).ScaleY = 0.0;
				((FrameworkElement)ShapeBorder).SetResourceReference(Border.BorderBrushProperty, (object)(((UIElement)this).IsEnabled ? "ColorBrush1" : "ColorBrushGray4"));
			}
		}
	}

	private void Checkbox_MouseUp()
	{
		if (!MouseDowned)
		{
			return;
		}
		bool? @checked = Checked;
		ModBase.Log("[Control] 按下复选框（" + ((object)((!@checked) ?? @checked)).ToString() + "）：" + Text);
		MouseDowned = false;
		if (IsThreeState)
		{
			bool flag = true;
			bool flag2 = flag;
			bool? checked2 = Checked;
			@checked = checked2;
			if ((@checked.HasValue ? new bool?(flag2 == @checked.GetValueOrDefault()) : null).GetValueOrDefault())
			{
				SetChecked(null, user: true);
			}
			else
			{
				flag2 = flag;
				@checked = !Checked;
				if ((@checked.HasValue ? new bool?(flag2 == @checked.GetValueOrDefault()) : null).GetValueOrDefault())
				{
					SetChecked(true, user: true);
				}
				else if (flag == !Checked.HasValue)
				{
					SetChecked(false, user: true);
				}
			}
			ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Border.BackgroundProperty, "ColorBrushHalfWhite", 100), "MyCheckBox Background " + Conversions.ToString(Uuid));
		}
		else
		{
			@checked = Checked;
			SetChecked((!@checked) ?? @checked, user: true);
			ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Border.BackgroundProperty, "ColorBrushHalfWhite", 100), "MyCheckBox Background " + Conversions.ToString(Uuid));
		}
	}

	private void Checkbox_MouseDown()
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		if (AllowMouseDown)
		{
			MouseDowned = true;
			base.Focus();
			ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Border.BackgroundProperty, "ColorBrushBg1", 100), "MyCheckBox Background " + Conversions.ToString(Uuid));
			if (Checked.GetValueOrDefault())
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaScale(ShapeBorder, 16.5 - ((FrameworkElement)ShapeBorder).Width, 1000, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong), After: false, Absolute: true),
					ModAnimation.AaScaleTransform(ShapeCheck, 0.9 - ((ScaleTransform)((UIElement)ShapeCheck).RenderTransform).ScaleX, 1000, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong))
				}, "MyCheckBox Scale " + Conversions.ToString(Uuid));
			}
			else
			{
				ModAnimation.AniStart(ModAnimation.AaScale(ShapeBorder, 16.5 - ((FrameworkElement)ShapeBorder).Width, 1000, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong), After: false, Absolute: true), "MyCheckBox Scale " + Conversions.ToString(Uuid));
			}
		}
	}

	private void Checkbox_MouseLeave()
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		if (MouseDowned)
		{
			MouseDowned = false;
			ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Border.BackgroundProperty, "ColorBrushHalfWhite", 100), "MyCheckBox Background " + Conversions.ToString(Uuid));
			if (Checked.GetValueOrDefault())
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaScale(ShapeBorder, 18.0 - ((FrameworkElement)ShapeBorder).Width, 400, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong), After: false, Absolute: true),
					ModAnimation.AaScaleTransform(ShapeCheck, 1.0 - ((ScaleTransform)((UIElement)ShapeCheck).RenderTransform).ScaleX, 500, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong))
				}, "MyCheckBox Scale " + Conversions.ToString(Uuid));
			}
			else
			{
				ModAnimation.AniStart(ModAnimation.AaScale(ShapeBorder, 18.0 - ((FrameworkElement)ShapeBorder).Width, 400, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong), After: false, Absolute: true), "MyCheckBox Scale " + Conversions.ToString(Uuid));
			}
		}
	}

	private void Checkbox_IsEnabledChanged()
	{
		if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
		{
			if (((UIElement)this).IsEnabled)
			{
				Checkbox_MouseLeaveAnimation();
				return;
			}
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Border.BorderBrushProperty, ModSecret.ColorGray4 - ShapeBorder.BorderBrush, 200) }, "MyCheckBox BorderColor " + Conversions.ToString(Uuid));
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, ModSecret.ColorGray4 - LabText.Foreground, 200) }, "MyCheckBox TextColor " + Conversions.ToString(Uuid));
		}
		else
		{
			ModAnimation.AniStop("MyCheckBox TextColor " + Conversions.ToString(Uuid));
			ModAnimation.AniStop("MyCheckBox BorderColor " + Conversions.ToString(Uuid));
			((FrameworkElement)LabText).SetResourceReference(TextBlock.ForegroundProperty, (object)(((UIElement)this).IsEnabled ? "ColorBrush1" : "ColorBrushGray4"));
			((FrameworkElement)ShapeBorder).SetResourceReference(Border.BorderBrushProperty, (object)((!((UIElement)this).IsEnabled) ? "ColorBrushGray4" : (Checked.GetValueOrDefault() ? "ColorBrush2" : "ColorBrush1")));
		}
	}

	private void Checkbox_MouseEnterAnimation()
	{
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, "ColorBrush3", 100) }, "MyCheckBox TextColor " + Conversions.ToString(Uuid));
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Border.BorderBrushProperty, "ColorBrush3", 100) }, "MyCheckBox BorderColor " + Conversions.ToString(Uuid));
	}

	private void Checkbox_MouseLeaveAnimation()
	{
		if (((UIElement)this).IsEnabled)
		{
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)LabText, TextBlock.ForegroundProperty, ((UIElement)this).IsEnabled ? "ColorBrush1" : "ColorBrushGray4", 200) }, "MyCheckBox TextColor " + Conversions.ToString(Uuid));
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Border.BorderBrushProperty, (!((UIElement)this).IsEnabled) ? "ColorBrushGray4" : (Checked.GetValueOrDefault() ? "ColorBrush2" : "ColorBrush1"), 200) }, "MyCheckBox BorderColor " + Conversions.ToString(Uuid));
		}
	}

	private void AniBackgroundScale()
	{
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
		{
			ModAnimation.AaScale(ShapeBorder, 12.0 - ((FrameworkElement)ShapeBorder).Width, 150, 0, new ModAnimation.AniEaseOutFluent(), After: false, Absolute: true),
			ModAnimation.AaScale(ShapeBorder, 6.0, 300, 105, new ModAnimation.AniEaseOutBack(), After: false, Absolute: true)
		}, "MyCheckBox Background Scale " + Conversions.ToString(Uuid));
	}

	private void AniCheckShow()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(ShapeCheck, 1.0 - ((ScaleTransform)((UIElement)ShapeCheck).RenderTransform).ScaleX, 300, 105, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)) }, "MyCheckBox Check Scale Show" + Conversions.ToString(Uuid));
	}

	private void AniCheckHide()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(ShapeCheck, 0.0 - ((ScaleTransform)((UIElement)ShapeCheck).RenderTransform).ScaleX, 135, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)) }, "MyCheckBox Check Scale Hide" + Conversions.ToString(Uuid));
	}

	private void AniIndeterminateShow()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(ShapeIndeterminate, 1.0 - ((ScaleTransform)((UIElement)ShapeIndeterminate).RenderTransform).ScaleX, 300, 105, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)) }, "MyCheckBox Indeterminate Scale Show" + Conversions.ToString(Uuid));
	}

	private void AniIndeterminateHide()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaScaleTransform(ShapeIndeterminate, 0.0 - ((ScaleTransform)((UIElement)ShapeIndeterminate).RenderTransform).ScaleX, 135, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)) }, "MyCheckBox Indeterminate Scale Hide" + Conversions.ToString(Uuid));
	}

	private void AniAllowMouseDown()
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
		{
			AllowMouseDown = true;
		}), 300) }, "MyCheckBox AllowMouseDown " + Conversions.ToString(Uuid));
	}

	private void AniColorChecked()
	{
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Border.BorderBrushProperty, (!((UIElement)this).IsEnabled) ? "ColorBrushGray4" : (((UIElement)this).IsMouseOver ? "ColorBrush3" : "ColorBrush2"), 150) }, "MyCheckBox BorderColor " + Conversions.ToString(Uuid));
	}

	private void AniColorUnchecked()
	{
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)ShapeBorder, Border.BorderBrushProperty, (!((UIElement)this).IsEnabled) ? "ColorBrushGray4" : (((UIElement)this).IsMouseOver ? "ColorBrush3" : "ColorBrush1"), 150) }, "MyCheckBox BorderColor " + Conversions.ToString(Uuid));
	}

	private bool? GetFinalState(bool? value, bool isThreeState)
	{
		bool? result;
		if (isThreeState)
		{
			bool? flag = value;
			flag = flag;
			result = (flag.GetValueOrDefault() ? new bool?(true) : ((!(!value).GetValueOrDefault()) ? null : new bool?(false)));
		}
		else
		{
			result = value.GetValueOrDefault();
		}
		return result;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/mycheckbox.xaml", (UriKind)2);
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
		switch (connectionId)
		{
		case 1:
			PanBack = (MyCheckBox)target;
			break;
		case 2:
			LabText = (TextBlock)target;
			break;
		case 3:
			ShapeBorder = (Border)target;
			break;
		case 4:
			ShapeCheck = (Path)target;
			break;
		case 5:
			ShapeIndeterminate = (Border)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
