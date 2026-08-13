using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageLinkQA : MyPageRight, IComponentConnector
{
	[CompilerGenerated]
	[AccessedThroughProperty("BtnHelpDoc")]
	private MyButton _BtnHelpDoc;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnHelpForum")]
	private MyButton _BtnHelpForum;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnHelpFeedback")]
	private MyButton _BtnHelpFeedback;

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
	[field: AccessedThroughProperty("PanMain")]
	internal virtual StackPanel PanMain
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnHelpDoc
	{
		[CompilerGenerated]
		get
		{
			return _BtnHelpDoc;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnHelpDoc_Click;
			MyButton btnHelpDoc = _BtnHelpDoc;
			if (btnHelpDoc != null)
			{
				btnHelpDoc.Click -= obj;
			}
			_BtnHelpDoc = value;
			btnHelpDoc = _BtnHelpDoc;
			if (btnHelpDoc != null)
			{
				btnHelpDoc.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnHelpForum
	{
		[CompilerGenerated]
		get
		{
			return _BtnHelpForum;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnHelpForum_Click;
			MyButton btnHelpForum = _BtnHelpForum;
			if (btnHelpForum != null)
			{
				btnHelpForum.Click -= obj;
			}
			_BtnHelpForum = value;
			btnHelpForum = _BtnHelpForum;
			if (btnHelpForum != null)
			{
				btnHelpForum.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnHelpFeedback
	{
		[CompilerGenerated]
		get
		{
			return _BtnHelpFeedback;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnHelpFeedback_Click;
			MyButton btnHelpFeedback = _BtnHelpFeedback;
			if (btnHelpFeedback != null)
			{
				btnHelpFeedback.Click -= obj;
			}
			_BtnHelpFeedback = value;
			btnHelpFeedback = _BtnHelpFeedback;
			if (btnHelpFeedback != null)
			{
				btnHelpFeedback.Click += obj;
			}
		}
	}

	public PageLinkQA()
	{
		InitializeComponent();
	}

	private void BtnHelpDoc_Click(object sender, RoutedEventArgs e)
	{
		ModBase.OpenWebsite("https://github.com/PCLPro/PCLPro/wiki");
	}

	private void BtnHelpForum_Click(object sender, RoutedEventArgs e)
	{
		ModBase.OpenWebsite("https://github.com/PCLPro/PCLPro/discussions");
	}

	private void BtnHelpFeedback_Click(object sender, RoutedEventArgs e)
	{
		ModBase.OpenWebsite("https://github.com/PCLPro/PCLPro/issues");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelink/pagelinkqa.xaml", (UriKind)2);
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
			PanMain = (StackPanel)target;
			break;
		case 3:
			BtnHelpDoc = (MyButton)target;
			break;
		case 4:
			BtnHelpForum = (MyButton)target;
			break;
		case 5:
			BtnHelpFeedback = (MyButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
