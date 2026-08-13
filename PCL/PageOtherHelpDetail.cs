using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageOtherHelpDetail : MyPageRight, IRefreshable, IComponentConnector
{
	public ModMain.HelpEntry Entry;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual MyScrollViewer PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanCustom")]
	internal virtual StackPanel PanCustom
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageOtherHelpDetail()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageOtherHelpDetail_Loaded);
		InitializeComponent();
	}

	public void Refresh()
	{
		Init(new ModMain.HelpEntry(Entry.RawPath));
	}

	void IRefreshable.Refresh()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Refresh
		this.Refresh();
	}

	private void PageOtherHelpDetail_Loaded(object sender, RoutedEventArgs e)
	{
		((ScrollViewer)PanBack).ScrollToTop();
	}

	public bool Init(ModMain.HelpEntry Entry)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		string text = Entry.XamlContent ?? "";
		if (Operators.CompareString(text, "", false) == 0)
		{
			throw new System.Exception("帮助 xaml 文件为空");
		}
		bool result;
		try
		{
			text = ModMain.HelpArgumentReplace(text);
			if (text.Contains("xmlns"))
			{
				text = ModBase.RegexReplace(text, "xmlns[^\"']*(\"|')[^\"']*(\"|')", "", (RegexOptions)0).Replace("xmlns", "");
			}
			text = "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:sys=\"clr-namespace:System;assembly=System.Runtime\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:PCL;assembly=Plain Craft Launcher 2\">" + text + "</StackPanel>";
			this.Entry = Entry;
			((Panel)PanCustom).Children.Clear();
			((Panel)PanCustom).Children.Add((UIElement)ModBase.GetObjectFromXML(text));
			result = true;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log("[System] 自定义信息内容：\r\n" + text);
			ModBase.Log(ex2, "加载帮助 XAML 文件失败", ModBase.LogLevel.Msgbox);
			result = false;
			ProjectData.ClearProjectError();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageother/pageotherhelpdetail.xaml", (UriKind)2);
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
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanCustom = (StackPanel)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
