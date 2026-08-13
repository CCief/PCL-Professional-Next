using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageOtherAbout : MyPageRight, IComponentConnector
{
	private bool IsLoaded;

	[CompilerGenerated]
	[AccessedThroughProperty("ImgPCLCommunity")]
	private Image _ImgPCLCommunity;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnAboutBmclapi")]
	private MyButton _BtnAboutBmclapi;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnAboutWiki")]
	private MyButton _BtnAboutWiki;

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

	internal virtual Image ImgPCLCommunity
	{
		[CompilerGenerated]
		get
		{
			return _ImgPCLCommunity;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(ImgPCLCommunity_Click);
			Image imgPCLCommunity = _ImgPCLCommunity;
			if (imgPCLCommunity != null)
			{
				((UIElement)imgPCLCommunity).MouseLeftButtonDown -= val;
			}
			_ImgPCLCommunity = value;
			imgPCLCommunity = _ImgPCLCommunity;
			if (imgPCLCommunity != null)
			{
				((UIElement)imgPCLCommunity).MouseLeftButtonDown += val;
			}
		}
	}

	internal virtual MyButton BtnAboutBmclapi
	{
		[CompilerGenerated]
		get
		{
			return _BtnAboutBmclapi;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnAboutBmclapi_Click;
			MyButton btnAboutBmclapi = _BtnAboutBmclapi;
			if (btnAboutBmclapi != null)
			{
				btnAboutBmclapi.Click -= obj;
			}
			_BtnAboutBmclapi = value;
			btnAboutBmclapi = _BtnAboutBmclapi;
			if (btnAboutBmclapi != null)
			{
				btnAboutBmclapi.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnAboutWiki
	{
		[CompilerGenerated]
		get
		{
			return _BtnAboutWiki;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnAboutWiki_Click;
			MyButton btnAboutWiki = _BtnAboutWiki;
			if (btnAboutWiki != null)
			{
				btnAboutWiki.Click -= obj;
			}
			_BtnAboutWiki = value;
			btnAboutWiki = _BtnAboutWiki;
			if (btnAboutWiki != null)
			{
				btnAboutWiki.Click += obj;
			}
		}
	}

	public PageOtherAbout()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageOtherAbout_Loaded);
		IsLoaded = false;
		InitializeComponent();
	}

	private void PageOtherAbout_Loaded(object sender, RoutedEventArgs e)
	{
		((ScrollViewer)PanBack).ScrollToHome();
		if (!IsLoaded)
		{
			IsLoaded = true;
		}
	}

	private void BtnAboutBmclapi_Click(object sender, EventArgs e)
	{
		ModBase.OpenWebsite("https://bd.bangbang93.com/pages/rank/clusters");
	}

	private void BtnAboutWiki_Click(object sender, EventArgs e)
	{
		ModBase.OpenWebsite("https://www.mcmod.cn");
	}

	private void ImgPCLCommunity_Click(object sender, MouseButtonEventArgs e)
	{
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaRotateTransform(RuntimeHelpers.GetObjectValue(sender), 360.0) });
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageother/pageotherabout.xaml", (UriKind)2);
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanMain = (StackPanel)target;
			break;
		case 3:
			ImgPCLCommunity = (Image)target;
			break;
		case 4:
			BtnAboutBmclapi = (MyButton)target;
			break;
		case 5:
			BtnAboutWiki = (MyButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
