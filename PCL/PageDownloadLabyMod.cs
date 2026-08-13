using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace PCL;

[DesignerGenerated]
public class PageDownloadLabyMod : MyPageRight, IComponentConnector
{
	[CompilerGenerated]
	[AccessedThroughProperty("BtnWeb")]
	private MyButton _BtnWeb;

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
	[field: AccessedThroughProperty("CardTip")]
	internal virtual MyCard CardTip
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnWeb
	{
		[CompilerGenerated]
		get
		{
			return _BtnWeb;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnWeb_Click;
			MyButton btnWeb = _BtnWeb;
			if (btnWeb != null)
			{
				btnWeb.Click -= obj;
			}
			_BtnWeb = value;
			btnWeb = _BtnWeb;
			if (btnWeb != null)
			{
				btnWeb.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardVersions")]
	internal virtual MyCard CardVersions
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanVersions")]
	internal virtual StackPanel PanVersions
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLoad")]
	internal virtual MyCard PanLoad
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("Load")]
	internal virtual MyLoading Load
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageDownloadLabyMod()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Initialized += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			LoaderInit();
		});
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Init();
		});
		InitializeComponent();
	}

	private void LoaderInit()
	{
		PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)CardVersions, (FrameworkElement)(object)CardTip, ModDownload.DlLabyModListLoader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
		{
			Load_OnFinish();
		});
	}

	private void Init()
	{
		((ScrollViewer)PanBack).ScrollToHome();
	}

	private void Load_OnFinish()
	{
		try
		{
			JObject value = ModDownload.DlLabyModListLoader.Output.Value;
			if (value != null)
			{
				JObject jObject = new JObject();
				jObject.Add("channel", "production");
				jObject.Add("version", value["production"]["labyModVersion"].ToString());
				JObject jObject2 = new JObject();
				jObject2.Add("channel", "snapshot");
				jObject2.Add("version", value["snapshot"]["labyModVersion"].ToString());
				((Panel)PanVersions).Children.Clear();
				((Panel)PanVersions).Children.Add((UIElement)(object)ModDownloadLib.LabyModDownloadListItem(jObject, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
				{
					LabyMod_Production_Selected((MyListItem)a0, (EventArgs)(object)a1);
				}));
				((Panel)PanVersions).Children.Add((UIElement)(object)ModDownloadLib.LabyModDownloadListItem(jObject2, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
				{
					LabyMod_Snapshot_Selected((MyListItem)a0, (EventArgs)(object)a1);
				}));
				CardVersions.Title = "版本列表 (" + Conversions.ToString(value.Count) + ")";
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化 LabyMod 版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void LabyMod_Production_Selected(MyListItem sender, EventArgs e)
	{
		ModDownloadLib.McDownloadLabyModProductionLoaderSave();
	}

	private void LabyMod_Snapshot_Selected(MyListItem sender, EventArgs e)
	{
		ModDownloadLib.McDownloadLabyModSnapshotLoaderSave();
	}

	private void BtnWeb_Click(object sender, EventArgs e)
	{
		ModBase.OpenWebsite("https://labymod.net");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagedownload/pagedownloadlabymod.xaml", (UriKind)2);
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
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			CardTip = (MyCard)target;
			break;
		case 3:
			BtnWeb = (MyButton)target;
			break;
		case 4:
			CardVersions = (MyCard)target;
			break;
		case 5:
			PanVersions = (StackPanel)target;
			break;
		case 6:
			PanLoad = (MyCard)target;
			break;
		case 7:
			Load = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
