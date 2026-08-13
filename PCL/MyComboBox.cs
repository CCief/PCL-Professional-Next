using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class MyComboBox : ComboBox
{
	public delegate void TextChangedEventHandler(object sender, TextChangedEventArgs e);

	[CompilerGenerated]
	private TextChangedEventHandler TextChangedEvent;

	public int Uuid;

	private MyTextBox TextBox;

	private string _Text;

	private bool IsMouseDown;

	private double RealWidth;

	private bool IsTextChanging;

	[field: CompilerGenerated]
	public string HintText
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public string Text
	{
		get
		{
			if (((ComboBox)this).IsEditable)
			{
				if (TextBox == null)
				{
					return _Text ?? "";
				}
				return ((TextBox)TextBox).Text ?? "";
			}
			return (((Selector)this).SelectedItem ?? "").ToString();
		}
		set
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			if (((ComboBox)this).IsEditable)
			{
				if (Information.IsNothing((object)TextBox))
				{
					_Text = value;
				}
				else
				{
					((TextBox)TextBox).Text = value;
				}
				return;
			}
			throw new NotSupportedException("该 ComboBox 不支持修改文本。");
		}
	}

	[field: CompilerGenerated]
	public bool DropDownWidthSync
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public ContentPresenter ContentPresenter => (ContentPresenter)((FrameworkTemplate)((Control)this).Template).FindName("PART_Content", (FrameworkElement)(object)this);

	public event TextChangedEventHandler TextChanged
	{
		[CompilerGenerated]
		add
		{
			TextChangedEventHandler textChangedEventHandler = TextChangedEvent;
			TextChangedEventHandler textChangedEventHandler2;
			do
			{
				textChangedEventHandler2 = textChangedEventHandler;
				TextChangedEventHandler textChangedEventHandler3 = (TextChangedEventHandler)System.Delegate.Combine((System.Delegate)textChangedEventHandler2, (System.Delegate)value);
				textChangedEventHandler = Interlocked.CompareExchange<TextChangedEventHandler>(ref TextChangedEvent, textChangedEventHandler3, textChangedEventHandler2);
			}
			while (textChangedEventHandler != textChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			TextChangedEventHandler textChangedEventHandler = TextChangedEvent;
			TextChangedEventHandler textChangedEventHandler2;
			do
			{
				textChangedEventHandler2 = textChangedEventHandler;
				TextChangedEventHandler textChangedEventHandler3 = (TextChangedEventHandler)System.Delegate.Remove((System.Delegate)textChangedEventHandler2, (System.Delegate)value);
				textChangedEventHandler = Interlocked.CompareExchange<TextChangedEventHandler>(ref TextChangedEvent, textChangedEventHandler3, textChangedEventHandler2);
			}
			while (textChangedEventHandler != textChangedEventHandler2);
		}
	}

	public MyComboBox()
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
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		((UIElement)this).PreviewMouseLeftButtonDown += new MouseButtonEventHandler(MyComboBox_PreviewMouseLeftButtonDown);
		((UIElement)this).PreviewMouseLeftButtonUp += new MouseButtonEventHandler(MyComboBox_PreviewMouseLeftButtonUp);
		((UIElement)this).MouseLeave += new MouseEventHandler(MyComboBox_PreviewMouseLeftButtonUp);
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
		((UIElement)this).PreviewMouseLeftButtonDown += (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).PreviewMouseLeftButtonUp += (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
		{
			RefreshColor();
		});
		((UIElement)this).GotKeyboardFocus += (KeyboardFocusChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, KeyboardFocusChangedEventArgs a1) =>
		{
			RefreshColor();
		});
		((ComboBox)this).DropDownOpened += new EventHandler(MyComboBox_DropDownOpened);
		((ComboBox)this).DropDownClosed += new EventHandler(MyComboBox_DropDownClosed);
		TextChanged += MyComboBox_TextChanged;
		Uuid = ModBase.GetUuid();
		HintText = "";
		_Text = Conversions.ToString(((Selector)this).SelectedItem);
		IsMouseDown = false;
		DropDownWidthSync = true;
		IsTextChanging = false;
	}

	public override void OnApplyTemplate()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		base.OnApplyTemplate();
		if (!((ComboBox)this).IsEditable)
		{
			return;
		}
		try
		{
			TextBox = (MyTextBox)((FrameworkTemplate)((Control)this).Template).FindName("PART_EditableTextBox", (FrameworkElement)(object)this);
			((UIElement)TextBox).AddHandler(UIElement.LostFocusEvent, (System.Delegate)(RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				RefreshColor();
			}));
			TextBox.ChangedEventList.Add((RoutedEventHandler)([SpecialName] [CompilerGenerated] (object sender, RoutedEventArgs e) =>
			{
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				//IL_001c: Expected O, but got Unknown
				TextChangedEvent?.Invoke(RuntimeHelpers.GetObjectValue(sender), (TextChangedEventArgs)e);
			}));
			((FrameworkElement)TextBox).Tag = RuntimeHelpers.GetObjectValue(((FrameworkElement)this).Tag);
			if (Operators.CompareString(Text, "", false) == 0)
			{
				((TextBox)TextBox).Text = _Text;
			}
			else
			{
				TextChangedEvent?.Invoke(this, null);
			}
			if (HintText.Length > 0)
			{
				TextBox.HintText = HintText;
			}
			((FrameworkElement)TextBox).SetResourceReference(TextBoxBase.CaretBrushProperty, (object)"ColorBrushGray1");
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "初始化可编辑文本框失败（" + ((FrameworkElement)this).Name + "）", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void MyComboBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		IsMouseDown = true;
	}

	private void MyComboBox_PreviewMouseLeftButtonUp(object sender, EventArgs e)
	{
		IsMouseDown = false;
	}

	public void RefreshColor()
	{
		string text;
		string text2;
		int time;
		if (((UIElement)this).IsEnabled)
		{
			if (Conversions.ToBoolean((object)(IsMouseDown || ((ComboBox)this).IsDropDownOpen || (((ComboBox)this).IsEditable && Conversions.ToBoolean(NewLateBinding.LateGet(((FrameworkTemplate)((Control)this).Template).FindName("PART_EditableTextBox", (FrameworkElement)(object)this), (System.Type)null, "IsFocused", new object[0], (string[])null, (System.Type[])null, (bool[])null))))))
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
			text = "ColorBrushGray5";
			text2 = "ColorBrushGray6";
			time = 200;
		}
		if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
		{
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
			{
				ModAnimation.AaColor((FrameworkElement)(object)this, Control.ForegroundProperty, text, time),
				ModAnimation.AaColor((FrameworkElement)(object)this, Control.BackgroundProperty, text2, time)
			}, "MyComboBox Color " + Conversions.ToString(Uuid));
		}
		else
		{
			ModAnimation.AniStop("MyComboBox Color " + Conversions.ToString(Uuid));
			base.SetResourceReference(Control.ForegroundProperty, (object)text);
			base.SetResourceReference(Control.BackgroundProperty, (object)text2);
		}
	}

	private void MyComboBox_DropDownOpened(object sender, EventArgs e)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		RealWidth = ((FrameworkElement)this).Width;
		if (DropDownWidthSync)
		{
			((FrameworkElement)this).Width = ((FrameworkElement)this).ActualWidth;
		}
		try
		{
			Grid val = (Grid)((FrameworkTemplate)((Control)this).Template).FindName("PanPopup", (FrameworkElement)(object)this);
			((UIElement)val).Opacity = ((UIElement)ModMain.FrmMain).Opacity;
			if (!DropDownWidthSync)
			{
				((FrameworkElement)val).MinWidth = ((FrameworkElement)this).ActualWidth;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "设置下拉框属性失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void MyComboBox_DropDownClosed(object sender, EventArgs e)
	{
		((FrameworkElement)this).Width = RealWidth;
	}

	private void MyComboBox_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (!IsTextChanging && ((ComboBox)this).IsEditable && ((Selector)this).SelectedItem != null && Operators.CompareString(Text, ((Selector)this).SelectedItem.ToString(), false) != 0)
		{
			string text = Text;
			int selectionStart = ((TextBox)TextBox).SelectionStart;
			IsTextChanging = true;
			((Selector)this).SelectedItem = null;
			Text = text;
			((TextBox)TextBox).SelectionStart = selectionStart;
			IsTextChanging = false;
		}
	}

	protected override DependencyObject GetContainerForItemOverride()
	{
		return (DependencyObject)(object)new MyComboBoxItem();
	}

	protected override bool IsItemItsOwnContainerOverride(object item)
	{
		if (!(item is MyComboBoxItem))
		{
			return base.IsItemItsOwnContainerOverride(RuntimeHelpers.GetObjectValue(item));
		}
		return true;
	}
}
