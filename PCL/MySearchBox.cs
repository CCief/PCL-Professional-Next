using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class MySearchBox : MyCard, IComponentConnector
{
	public delegate void TextChangedEventHandler(object sender, EventArgs e);

	public delegate void SearchEventHandler(object sender, EventArgs e);

	[CompilerGenerated]
	private TextChangedEventHandler TextChangedEvent;

	[CompilerGenerated]
	private SearchEventHandler SearchEvent;

	[CompilerGenerated]
	[AccessedThroughProperty("TextBox")]
	private MyTextBox _TextBox;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnClear")]
	private MyIconButton _BtnClear;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSearch")]
	private MyButton _BtnSearch;

	private bool _contentLoaded;

	public string HintText
	{
		get
		{
			return TextBox.HintText;
		}
		set
		{
			TextBox.HintText = value;
		}
	}

	public string Text
	{
		get
		{
			return ((TextBox)TextBox).Text;
		}
		set
		{
			((TextBox)TextBox).Text = value;
		}
	}

	public Visibility SearchButtonVisibility
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Invalid comparison between Unknown and I4
			return (Visibility)(byte)(0 - (((int)((UIElement)BtnSearch).Visibility == 0) ? 1 : 0));
		}
		set
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			((FrameworkElement)BtnClear).Margin = new Thickness(0.0, 0.0, (double)(((int)value == 0) ? 70 : 10), 0.0);
			((UIElement)BtnSearch).Visibility = value;
		}
	}

	internal virtual MyTextBox TextBox
	{
		[CompilerGenerated]
		get
		{
			return _TextBox;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			System.Windows.Controls.TextChangedEventHandler val = new System.Windows.Controls.TextChangedEventHandler(Text_TextChanged);
			MyTextBox textBox = _TextBox;
			if (textBox != null)
			{
				((TextBoxBase)textBox).TextChanged -= val;
			}
			_TextBox = value;
			textBox = _TextBox;
			if (textBox != null)
			{
				((TextBoxBase)textBox).TextChanged += val;
			}
		}
	}

	internal virtual MyIconButton BtnClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = BtnClear_Click;
			MyIconButton btnClear = _BtnClear;
			if (btnClear != null)
			{
				btnClear.Click -= obj;
			}
			_BtnClear = value;
			btnClear = _BtnClear;
			if (btnClear != null)
			{
				btnClear.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnSearch
	{
		[CompilerGenerated]
		get
		{
			return _BtnSearch;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnSearch_Click;
			MyButton btnSearch = _BtnSearch;
			if (btnSearch != null)
			{
				btnSearch.Click -= obj;
			}
			_BtnSearch = value;
			btnSearch = _BtnSearch;
			if (btnSearch != null)
			{
				btnSearch.Click += obj;
			}
		}
	}

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

	public event SearchEventHandler Search
	{
		[CompilerGenerated]
		add
		{
			SearchEventHandler searchEventHandler = SearchEvent;
			SearchEventHandler searchEventHandler2;
			do
			{
				searchEventHandler2 = searchEventHandler;
				SearchEventHandler searchEventHandler3 = (SearchEventHandler)System.Delegate.Combine((System.Delegate)searchEventHandler2, (System.Delegate)value);
				searchEventHandler = Interlocked.CompareExchange<SearchEventHandler>(ref SearchEvent, searchEventHandler3, searchEventHandler2);
			}
			while (searchEventHandler != searchEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SearchEventHandler searchEventHandler = SearchEvent;
			SearchEventHandler searchEventHandler2;
			do
			{
				searchEventHandler2 = searchEventHandler;
				SearchEventHandler searchEventHandler3 = (SearchEventHandler)System.Delegate.Remove((System.Delegate)searchEventHandler2, (System.Delegate)value);
				searchEventHandler = Interlocked.CompareExchange<SearchEventHandler>(ref SearchEvent, searchEventHandler3, searchEventHandler2);
			}
			while (searchEventHandler != searchEventHandler2);
		}
	}

	public MySearchBox()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(MySearchBox_Loaded);
		InitializeComponent();
	}

	private void MySearchBox_Loaded(object sender, RoutedEventArgs e)
	{
		((UIElement)TextBox).Focus();
	}

	private void Text_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (string.IsNullOrEmpty(((TextBox)TextBox).Text))
		{
			ModAnimation.AniStart(ModAnimation.AaOpacity(BtnClear, 0.0 - ((UIElement)BtnClear).Opacity, 90), "MySearchBox ClearBtn " + Conversions.ToString(Uuid));
			((UIElement)BtnClear).IsHitTestVisible = false;
		}
		else
		{
			ModAnimation.AniStart(ModAnimation.AaOpacity(BtnClear, 1.0 - ((UIElement)BtnClear).Opacity, 90), "MySearchBox ClearBtn " + Conversions.ToString(Uuid));
			((UIElement)BtnClear).IsHitTestVisible = true;
		}
		TextChangedEvent?.Invoke(RuntimeHelpers.GetObjectValue(sender), (EventArgs)(object)e);
	}

	private void BtnClear_Click(object sender, EventArgs e)
	{
		((TextBox)TextBox).Text = "";
		((UIElement)TextBox).Focus();
	}

	private void BtnSearch_Click(object sender, EventArgs e)
	{
		SearchEvent?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/mysearchbox.xaml", (UriKind)2);
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
		switch (connectionId)
		{
		case 1:
			TextBox = (MyTextBox)target;
			break;
		case 2:
			BtnClear = (MyIconButton)target;
			break;
		case 3:
			BtnSearch = (MyButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
