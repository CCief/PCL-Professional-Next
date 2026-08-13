using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageInstanceModDisabled : MyPageRight, IComponentConnector
{
	[CompilerGenerated]
	[AccessedThroughProperty("BtnDownload")]
	private MyButton _BtnDownload;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnVersion")]
	private MyButton _BtnVersion;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanMain")]
	internal virtual MyCard PanMain
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnDownload
	{
		[CompilerGenerated]
		get
		{
			return _BtnDownload;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MyButton.ClickEventHandler obj = BtnDownload_Click;
			RoutedEventHandler val = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				BtnDownload_Loaded();
			});
			MyButton btnDownload = _BtnDownload;
			if (btnDownload != null)
			{
				btnDownload.Click -= obj;
				((FrameworkElement)btnDownload).Loaded -= val;
			}
			_BtnDownload = value;
			btnDownload = _BtnDownload;
			if (btnDownload != null)
			{
				btnDownload.Click += obj;
				((FrameworkElement)btnDownload).Loaded += val;
			}
		}
	}

	internal virtual MyButton BtnVersion
	{
		[CompilerGenerated]
		get
		{
			return _BtnVersion;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnVersion_Click;
			MyButton btnVersion = _BtnVersion;
			if (btnVersion != null)
			{
				btnVersion.Click -= obj;
			}
			_BtnVersion = value;
			btnVersion = _BtnVersion;
			if (btnVersion != null)
			{
				btnVersion.Click += obj;
			}
		}
	}

	public PageInstanceModDisabled()
	{
		InitializeComponent();
	}

	private void BtnDownload_Click(object sender, EventArgs e)
	{
		ModMain.FrmMain.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadInstall);
	}

	private void BtnVersion_Click(object sender, EventArgs e)
	{
		ModMain.FrmMain.PageChange(FormMain.PageType.Launch);
		ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSelect);
	}

	public void BtnDownload_Loaded()
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		Visibility val = (Visibility)(Conversions.ToBoolean((object)((Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenPageDownload")) && !PageSetupUI.HiddenForceShow) || (ModMain.FrmSelectRight != null && ModMain.FrmSelectRight.ShowHidden))) ? 2 : 0);
		if (((UIElement)BtnDownload).Visibility != val)
		{
			((UIElement)BtnDownload).Visibility = val;
			PanMain.TriggerForceResize();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/pageinstancemoddisabled.xaml", (UriKind)2);
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
			PanMain = (MyCard)target;
			break;
		case 2:
			BtnDownload = (MyButton)target;
			break;
		case 3:
			BtnVersion = (MyButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
