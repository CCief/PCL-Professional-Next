using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class MyTextBox : TextBox
{
	public delegate void ValidateChangedEventHandler(object sender, EventArgs e);

	private enum ValidateState
	{
		NotInited,
		Success,
		FailedButTextNotChanged,
		FailedAndShowDetail,
		FailedAndHideDetail,
		NotLoaded
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__44_002D0
	{
		public bool _0024VB_0024Local_IsFinished;

		public MyTextBox _0024VB_0024Me;

		public _Closure_0024__44_002D0(_Closure_0024__44_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_IsFinished = arg0._0024VB_0024Local_IsFinished;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			if (_0024VB_0024Me.labWrong != null)
			{
				_0024VB_0024Me.labWrong.Text = _0024VB_0024Me.ValidateResult;
				_0024VB_0024Local_IsFinished = true;
			}
			if (!((FrameworkElement)_0024VB_0024Me).IsLoaded)
			{
				_0024VB_0024Local_IsFinished = true;
			}
		}
	}

	public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(MyTextBox), new PropertyMetadata((object)new CornerRadius(3.0)));

	private TextBlock _labWrong;

	private TextBlock _labHint;

	public int Uuid;

	[CompilerGenerated]
	private static ValidateChangedEventHandler ValidateChangedEvent;

	public List<RoutedEventHandler> ChangedEventList;

	public static readonly DependencyProperty ValidateResultProperty = DependencyProperty.Register("ValidateResult", typeof(string), typeof(MyTextBox), new PropertyMetadata((object)"", (PropertyChangedCallback)([SpecialName] (DependencyObject a0, DependencyPropertyChangedEventArgs a1) =>
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		((VB_0024AnonymousDelegate_2<MyTextBox, DependencyPropertyChangedEventArgs>)([SpecialName] (MyTextBox d, DependencyPropertyChangedEventArgs e) =>
		{
			((DependencyObject)d).SetValue(IsValidatedPropertyKey, (object)string.IsNullOrEmpty(Conversions.ToString(e.NewValue)));
		}))((MyTextBox)(object)a0, a1);
	})));

	private static readonly DependencyPropertyKey IsValidatedPropertyKey = DependencyProperty.RegisterReadOnly("IsValidated", typeof(bool), typeof(MyTextBox), new PropertyMetadata((object)true));

	public static readonly DependencyProperty IsValidatedProperty = IsValidatedPropertyKey.DependencyProperty;

	private Collection<Validate> _ValidateRules;

	private ValidateState ShownValidateResult;

	private bool IsTextChanged;

	public static readonly DependencyProperty HintTextProperty = DependencyProperty.Register("HintText", typeof(string), typeof(MyTextBox), new PropertyMetadata((object)"", (PropertyChangedCallback)([SpecialName] (DependencyObject a0, DependencyPropertyChangedEventArgs a1) =>
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		((VB_0024AnonymousDelegate_3<MyTextBox, DependencyPropertyChangedEventArgs>)([SpecialName] (MyTextBox t, DependencyPropertyChangedEventArgs e) =>
		{
			if (t.labHint != null)
			{
				t.labHint.Text = ((Operators.CompareString(((TextBox)t).Text, "", false) == 0) ? t.HintText : "");
			}
		}))((MyTextBox)(object)a0, a1);
	})));

	[field: CompilerGenerated]
	public bool HasBackground
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public bool ShowValidateResult
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public CornerRadius CornerRadius
	{
		get
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			object value = base.GetValue(CornerRadiusProperty);
			if (value == null)
			{
				return default(CornerRadius);
			}
			return (CornerRadius)value;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			base.SetValue(CornerRadiusProperty, (object)value);
		}
	}

	private TextBlock labWrong
	{
		get
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			if (((Control)this).Template == null)
			{
				return null;
			}
			if (_labWrong == null)
			{
				_labWrong = (TextBlock)((FrameworkTemplate)((Control)this).Template).FindName("labWrong", (FrameworkElement)(object)this);
			}
			return _labWrong;
		}
	}

	private TextBlock labHint
	{
		get
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			if (((Control)this).Template == null)
			{
				return null;
			}
			if (_labHint == null)
			{
				_labHint = (TextBlock)((FrameworkTemplate)((Control)this).Template).FindName("labHint", (FrameworkElement)(object)this);
			}
			return _labHint;
		}
	}

	public string ValidateResult
	{
		get
		{
			return Conversions.ToString(base.GetValue(ValidateResultProperty));
		}
		set
		{
			base.SetValue(ValidateResultProperty, (object)value);
		}
	}

	public bool IsValidated => Conversions.ToBoolean(base.GetValue(IsValidatedProperty));

	public Collection<Validate> ValidateRules
	{
		get
		{
			return _ValidateRules;
		}
		set
		{
			_ValidateRules = value;
			Validate();
		}
	}

	public string HintText
	{
		get
		{
			return Conversions.ToString(base.GetValue(HintTextProperty));
		}
		set
		{
			base.SetValue(HintTextProperty, (object)value);
		}
	}

	public static event ValidateChangedEventHandler ValidateChanged
	{
		[CompilerGenerated]
		add
		{
			ValidateChangedEventHandler validateChangedEventHandler = ValidateChangedEvent;
			ValidateChangedEventHandler validateChangedEventHandler2;
			do
			{
				validateChangedEventHandler2 = validateChangedEventHandler;
				ValidateChangedEventHandler validateChangedEventHandler3 = (ValidateChangedEventHandler)System.Delegate.Combine((System.Delegate)validateChangedEventHandler2, (System.Delegate)value);
				validateChangedEventHandler = Interlocked.CompareExchange<ValidateChangedEventHandler>(ref ValidateChangedEvent, validateChangedEventHandler3, validateChangedEventHandler2);
			}
			while (validateChangedEventHandler != validateChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ValidateChangedEventHandler validateChangedEventHandler = ValidateChangedEvent;
			ValidateChangedEventHandler validateChangedEventHandler2;
			do
			{
				validateChangedEventHandler2 = validateChangedEventHandler;
				ValidateChangedEventHandler validateChangedEventHandler3 = (ValidateChangedEventHandler)System.Delegate.Remove((System.Delegate)validateChangedEventHandler2, (System.Delegate)value);
				validateChangedEventHandler = Interlocked.CompareExchange<ValidateChangedEventHandler>(ref ValidateChangedEvent, validateChangedEventHandler3, validateChangedEventHandler2);
			}
			while (validateChangedEventHandler != validateChangedEventHandler2);
		}
	}

	public event RoutedEventHandler ValidatedTextChanged
	{
		add
		{
			ChangedEventList.Add(value);
		}
		remove
		{
			ChangedEventList.Remove(value);
		}
	}

	public MyTextBox()
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
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Validate();
		});
		((TextBoxBase)this).TextChanged += (TextChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, TextChangedEventArgs a1) =>
		{
			MyTextBox_TextChanged((MyTextBox)a0, a1);
		});
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
		((UIElement)this).GotFocus += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).LostFocus += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).IsEnabledChanged += (DependencyPropertyChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, DependencyPropertyChangedEventArgs a1) =>
		{
			RefreshTextColor();
		});
		HasBackground = true;
		ShowValidateResult = true;
		_labWrong = null;
		_labHint = null;
		Uuid = ModBase.GetUuid();
		ChangedEventList = new List<RoutedEventHandler>();
		_ValidateRules = new Collection<Validate>();
		ShownValidateResult = ValidateState.NotInited;
		IsTextChanged = false;
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		if (Operators.CompareString(HintText, "", false) != 0 && Operators.CompareString(labHint.Text, "", false) == 0)
		{
			labHint.Text = ((Operators.CompareString(((TextBox)this).Text, "", false) == 0) ? HintText : "");
		}
	}

	[SpecialName]
	private void raise_ValidatedTextChanged(object sender, TextChangedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		System.Collections.Generic.IEnumerator<RoutedEventHandler> enumerator = default(System.Collections.Generic.IEnumerator<RoutedEventHandler>);
		try
		{
			enumerator = ChangedEventList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				RoutedEventHandler current = enumerator.Current;
				if (!Information.IsNothing((object)current))
				{
					current.Invoke(RuntimeHelpers.GetObjectValue(sender), (RoutedEventArgs)(object)e);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	public void Validate()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		ValidateResult = ModValidate.Validate(((TextBox)this).Text, (System.Collections.Generic.IEnumerable<Validate>)ValidateRules);
		if (ShownValidateResult != (ValidateState)(IsValidated ? 1 : 3))
		{
			if (((FrameworkElement)this).IsLoaded && labWrong != null)
			{
				ChangeValidateResult(IsValidated, IsLoaded: true);
			}
			else
			{
				ModBase.RunInNewThread((Action)([SpecialName] [CompilerGenerated] () =>
				{
					//IL_000e: Unknown result type (might be due to invalid IL or missing references)
					//IL_0019: Expected O, but got Unknown
					Thread.Sleep(30);
					ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
					{
						ChangeValidateResult(IsValidated, IsLoaded: false);
					}));
				}), "DelayedValidate Change", (ThreadPriority)2);
			}
		}
		if (!ShowValidateResult || IsValidated)
		{
			return;
		}
		if (((FrameworkElement)this).IsLoaded && labWrong != null)
		{
			labWrong.Text = ValidateResult;
			return;
		}
		ModBase.RunInNewThread((Action)([SpecialName] [CompilerGenerated] () =>
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			_Closure_0024__44_002D0 arg = default(_Closure_0024__44_002D0);
			_Closure_0024__44_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__44_002D0(null);
			CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_IsFinished = false;
			while (!CS_0024_003C_003E8__locals0._0024VB_0024Local_IsFinished)
			{
				Thread.Sleep(20);
				ModBase.RunInUiWait((Action)([SpecialName] () =>
				{
					if (CS_0024_003C_003E8__locals0._0024VB_0024Me.labWrong != null)
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Me.labWrong.Text = CS_0024_003C_003E8__locals0._0024VB_0024Me.ValidateResult;
						CS_0024_003C_003E8__locals0._0024VB_0024Local_IsFinished = true;
					}
					if (!((FrameworkElement)CS_0024_003C_003E8__locals0._0024VB_0024Me).IsLoaded)
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Local_IsFinished = true;
					}
				}));
			}
		}), "DelayedValidate Text", (ThreadPriority)2);
	}

	public void ForceShowAsSuccess()
	{
		IsTextChanged = false;
		ChangeValidateResult(IsValidated, IsLoaded: true);
	}

	private void ChangeValidateResult(bool IsSuccessful, bool IsLoaded)
	{
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		if (IsLoaded && ModAnimation.AniControlEnabled == 0 && labWrong != null)
		{
			if (IsSuccessful || !IsTextChanged)
			{
				ShownValidateResult = (IsSuccessful ? ValidateState.Success : ValidateState.FailedButTextNotChanged);
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
				{
					ModAnimation.AaOpacity(labWrong, 0.0 - ((UIElement)labWrong).Opacity, 150),
					ModAnimation.AaHeight(labWrong, 0.0 - ((FrameworkElement)labWrong).Height, 150, 0, new ModAnimation.AniEaseOutFluent()),
					ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
					{
						((UIElement)labWrong).Visibility = (Visibility)2;
					}), 0, After: true)
				}, "MyTextBox Validate " + Conversions.ToString(Uuid));
			}
			else if (ShowValidateResult)
			{
				ShownValidateResult = ValidateState.FailedAndShowDetail;
				((UIElement)labWrong).Visibility = (Visibility)0;
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaOpacity(labWrong, 1.0 - ((UIElement)labWrong).Opacity, 150),
					ModAnimation.AaHeight(labWrong, 21.0 - ((FrameworkElement)labWrong).Height, 150, 0, new ModAnimation.AniEaseOutFluent())
				}, "MyTextBox Validate " + Conversions.ToString(Uuid));
			}
			else
			{
				ShownValidateResult = ValidateState.FailedAndHideDetail;
			}
		}
		else
		{
			ShownValidateResult = ValidateState.NotLoaded;
		}
		RefreshColor();
		ValidateChangedEvent?.Invoke(this, new EventArgs());
	}

	private void MyTextBox_TextChanged(MyTextBox sender, TextChangedEventArgs e)
	{
		try
		{
			if (labHint != null)
			{
				labHint.Text = ((Operators.CompareString(((TextBox)this).Text, "", false) == 0) ? HintText : "");
			}
			IsTextChanged = ((FrameworkElement)this).IsLoaded;
			Validate();
			if (IsValidated)
			{
				raise_ValidatedTextChanged(sender, e);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "进行输入验证时出错", ModBase.LogLevel.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void RefreshColor()
	{
		try
		{
			if (((FrameworkElement)this).TemplatedParent != null && ((FrameworkElement)this).TemplatedParent is MyComboBox)
			{
				return;
			}
			string text;
			string text2;
			int time;
			if (((UIElement)this).IsEnabled)
			{
				if (IsValidated || !IsTextChanged)
				{
					if (((UIElement)this).IsFocused)
					{
						text = "ColorBrush3";
						text2 = "ColorBrush7";
						time = 10;
					}
					else if (((UIElement)this).IsMouseOver)
					{
						text = "ColorBrush4";
						text2 = "ColorBrush7";
						time = 100;
					}
					else
					{
						text = "ColorBrushBg0";
						text2 = "ColorBrushHalfWhite";
						time = 100;
					}
				}
				else
				{
					text = "ColorBrushRedLight";
					text2 = "ColorBrushRedBack";
					time = 200;
				}
			}
			else
			{
				text = "ColorBrushGray5";
				text2 = "ColorBrushGray6";
				time = 200;
			}
			if (!HasBackground)
			{
				text2 = "ColorBrushTransparent";
			}
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaColor((FrameworkElement)(object)this, Control.BorderBrushProperty, text, time),
					ModAnimation.AaColor((FrameworkElement)(object)this, Control.BackgroundProperty, text2, time)
				}, "MyTextBox Color " + Conversions.ToString(Uuid));
			}
			else
			{
				ModAnimation.AniStop("MyTextBox Color " + Conversions.ToString(Uuid));
				base.SetResourceReference(Control.BorderBrushProperty, (object)text);
				base.SetResourceReference(Control.BackgroundProperty, (object)text2);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "文本框颜色改变出错");
			ProjectData.ClearProjectError();
		}
	}

	private void RefreshTextColor()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		ModBase.MyColor myColor = (((UIElement)this).IsEnabled ? ModSecret.ColorGray1 : ModSecret.ColorGray4);
		Color color = ((SolidColorBrush)((Control)this).Foreground).Color;
		if ((double)(int)color.R != myColor.R)
		{
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0 && Operators.CompareString(((TextBox)this).Text, "", false) != 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)this, Control.ForegroundProperty, ((UIElement)this).IsEnabled ? "ColorBrushGray1" : "ColorBrushGray4", 200) }, "MyTextBox TextColor " + Conversions.ToString(Uuid));
			}
			else
			{
				ModAnimation.AniStop("MyTextBox TextColor " + Conversions.ToString(Uuid));
				((Control)this).Foreground = myColor;
			}
		}
	}
}
