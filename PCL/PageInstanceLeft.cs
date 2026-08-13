using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.App;

namespace PCL;

[DesignerGenerated]
public class PageInstanceLeft : MyPageLeft, IRefreshable, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static ThreadStart _0024I8_002D0;

		public static ThreadStart _0024I8_002D1;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__8_002D0()
		{
			((MyPageRight)(object)((Decorator)ModMain.FrmMain.PanMainRight).Child).PageOnForceExit();
			((Decorator)ModMain.FrmMain.PanMainRight).Child = (UIElement)(object)ModMain.FrmMain.PageRight;
			((UIElement)ModMain.FrmMain.PageRight).Opacity = 0.0;
		}

		[SpecialName]
		internal void _Lambda_0024__8_002D1()
		{
			((UIElement)ModMain.FrmMain.PageRight).Opacity = 1.0;
			ModMain.FrmMain.PageRight.PageOnEnter();
		}
	}

	public static ModMinecraft.McInstance Instance = null;

	public FormMain.PageSubType PageID;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemOverall")]
	private MyListItem _ItemOverall;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemSetup")]
	private MyListItem _ItemSetup;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemInstall")]
	private MyListItem _ItemInstall;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemExport")]
	private MyListItem _ItemExport;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemWorld")]
	private MyListItem _ItemWorld;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemScreenshot")]
	private MyListItem _ItemScreenshot;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemMod")]
	private MyListItem _ItemMod;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemModDisabled")]
	private MyListItem _ItemModDisabled;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemResourcePack")]
	private MyListItem _ItemResourcePack;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemShader")]
	private MyListItem _ItemShader;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemSchematic")]
	private MyListItem _ItemSchematic;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemServer")]
	private MyListItem _ItemServer;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanItem")]
	internal virtual StackPanel PanItem
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyListItem ItemOverall
	{
		[CompilerGenerated]
		get
		{
			return _ItemOverall;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemOverall = _ItemOverall;
			if (itemOverall != null)
			{
				itemOverall.Check -= obj;
			}
			_ItemOverall = value;
			itemOverall = _ItemOverall;
			if (itemOverall != null)
			{
				itemOverall.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemSetup
	{
		[CompilerGenerated]
		get
		{
			return _ItemSetup;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemSetup = _ItemSetup;
			if (itemSetup != null)
			{
				itemSetup.Check -= obj;
			}
			_ItemSetup = value;
			itemSetup = _ItemSetup;
			if (itemSetup != null)
			{
				itemSetup.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemInstall
	{
		[CompilerGenerated]
		get
		{
			return _ItemInstall;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemInstall = _ItemInstall;
			if (itemInstall != null)
			{
				itemInstall.Check -= obj;
			}
			_ItemInstall = value;
			itemInstall = _ItemInstall;
			if (itemInstall != null)
			{
				itemInstall.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemExport
	{
		[CompilerGenerated]
		get
		{
			return _ItemExport;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemExport = _ItemExport;
			if (itemExport != null)
			{
				itemExport.Check -= obj;
			}
			_ItemExport = value;
			itemExport = _ItemExport;
			if (itemExport != null)
			{
				itemExport.Check += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextResource")]
	internal virtual TextBlock TextResource
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyListItem ItemWorld
	{
		[CompilerGenerated]
		get
		{
			return _ItemWorld;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemWorld = _ItemWorld;
			if (itemWorld != null)
			{
				itemWorld.Check -= obj;
			}
			_ItemWorld = value;
			itemWorld = _ItemWorld;
			if (itemWorld != null)
			{
				itemWorld.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemScreenshot
	{
		[CompilerGenerated]
		get
		{
			return _ItemScreenshot;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemScreenshot = _ItemScreenshot;
			if (itemScreenshot != null)
			{
				itemScreenshot.Check -= obj;
			}
			_ItemScreenshot = value;
			itemScreenshot = _ItemScreenshot;
			if (itemScreenshot != null)
			{
				itemScreenshot.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemMod
	{
		[CompilerGenerated]
		get
		{
			return _ItemMod;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemMod = _ItemMod;
			if (itemMod != null)
			{
				itemMod.Check -= obj;
			}
			_ItemMod = value;
			itemMod = _ItemMod;
			if (itemMod != null)
			{
				itemMod.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemModDisabled
	{
		[CompilerGenerated]
		get
		{
			return _ItemModDisabled;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemModDisabled = _ItemModDisabled;
			if (itemModDisabled != null)
			{
				itemModDisabled.Check -= obj;
			}
			_ItemModDisabled = value;
			itemModDisabled = _ItemModDisabled;
			if (itemModDisabled != null)
			{
				itemModDisabled.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemResourcePack
	{
		[CompilerGenerated]
		get
		{
			return _ItemResourcePack;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemResourcePack = _ItemResourcePack;
			if (itemResourcePack != null)
			{
				itemResourcePack.Check -= obj;
			}
			_ItemResourcePack = value;
			itemResourcePack = _ItemResourcePack;
			if (itemResourcePack != null)
			{
				itemResourcePack.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemShader
	{
		[CompilerGenerated]
		get
		{
			return _ItemShader;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemShader = _ItemShader;
			if (itemShader != null)
			{
				itemShader.Check -= obj;
			}
			_ItemShader = value;
			itemShader = _ItemShader;
			if (itemShader != null)
			{
				itemShader.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemSchematic
	{
		[CompilerGenerated]
		get
		{
			return _ItemSchematic;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemSchematic = _ItemSchematic;
			if (itemSchematic != null)
			{
				itemSchematic.Check -= obj;
			}
			_ItemSchematic = value;
			itemSchematic = _ItemSchematic;
			if (itemSchematic != null)
			{
				itemSchematic.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemServer
	{
		[CompilerGenerated]
		get
		{
			return _ItemServer;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemServer = _ItemServer;
			if (itemServer != null)
			{
				itemServer.Check -= obj;
			}
			_ItemServer = value;
			itemServer = _ItemServer;
			if (itemServer != null)
			{
				itemServer.Check += obj;
			}
		}
	}

	public PageInstanceLeft()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			RefreshModDisabled();
		});
		PageID = FormMain.PageSubType.Default;
		InitializeComponent();
	}

	public void RefreshModDisabled()
	{
		if ((object)Instance != null && Instance.Modable)
		{
			((UIElement)ItemMod).Visibility = (Visibility)(Conversions.ToBoolean((object)(!PageSetupUI.HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionMod")))) ? 2 : 0);
			((UIElement)ItemModDisabled).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)ItemMod).Visibility = (Visibility)2;
			((UIElement)ItemModDisabled).Visibility = (Visibility)(Conversions.ToBoolean((object)(!PageSetupUI.HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionMod")))) ? 2 : 0);
		}
		checked
		{
			if (!PageSetupUI.HiddenForceShow)
			{
				int num = 0;
				if (Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionSave")))
				{
					num++;
				}
				if (Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionScreenshot")))
				{
					num++;
				}
				if (Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionMod")))
				{
					num++;
				}
				if (Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionResourcePack")))
				{
					num++;
				}
				if (Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionShader")))
				{
					num++;
				}
				if (Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionSchematic")))
				{
					num++;
				}
				if (Config.UI.Hide.InstanceServer)
				{
					num++;
				}
				if (num == 6)
				{
					((UIElement)TextResource).Visibility = (Visibility)2;
				}
				else
				{
					((UIElement)TextResource).Visibility = (Visibility)0;
				}
			}
			else
			{
				((UIElement)TextResource).Visibility = (Visibility)0;
			}
			((UIElement)ItemInstall).Visibility = (Visibility)(Conversions.ToBoolean((object)(!PageSetupUI.HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionEdit")))) ? 2 : 0);
			((UIElement)ItemExport).Visibility = (Visibility)(Conversions.ToBoolean((object)(!PageSetupUI.HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionExport")))) ? 2 : 0);
			((UIElement)ItemWorld).Visibility = (Visibility)(Conversions.ToBoolean((object)(!PageSetupUI.HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionSave")))) ? 2 : 0);
			((UIElement)ItemScreenshot).Visibility = (Visibility)(Conversions.ToBoolean((object)(!PageSetupUI.HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionScreenshot")))) ? 2 : 0);
			((UIElement)ItemResourcePack).Visibility = (Visibility)(Conversions.ToBoolean((object)(!PageSetupUI.HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionResourcePack")))) ? 2 : 0);
			((UIElement)ItemShader).Visibility = (Visibility)(Conversions.ToBoolean((object)(!PageSetupUI.HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionShader")))) ? 2 : 0);
			((UIElement)ItemSchematic).Visibility = (Visibility)(Conversions.ToBoolean((object)(!PageSetupUI.HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenVersionSchematic")))) ? 2 : 0);
			((UIElement)ItemServer).Visibility = (Visibility)((!PageSetupUI.HiddenForceShow && Config.UI.Hide.InstanceServer) ? 2 : 0);
		}
	}

	private void PageCheck(MyListItem sender, ModBase.RouteEventArgs e)
	{
		if (((FrameworkElement)sender).Tag != null)
		{
			PageChange((FormMain.PageSubType)checked((int)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(((FrameworkElement)sender).Tag)))));
		}
	}

	public object PageGet(FormMain.PageSubType ID = (FormMain.PageSubType)(-1))
	{
		if (ID == (FormMain.PageSubType)(-1))
		{
			ID = PageID;
		}
		switch (ID)
		{
		case FormMain.PageSubType.Default:
			if (ModMain.FrmInstanceOverall == null)
			{
				ModMain.FrmInstanceOverall = new PageInstanceOverall();
			}
			return ModMain.FrmInstanceOverall;
		case FormMain.PageSubType.DownloadResourcePack:
			if (ModMain.FrmInstanceMod == null)
			{
				ModMain.FrmInstanceMod = new PageInstanceCompResource(ModComp.CompType.Mod);
			}
			return ModMain.FrmInstanceMod;
		case FormMain.PageSubType.DownloadShader:
			if (ModMain.FrmInstanceModDisabled == null)
			{
				ModMain.FrmInstanceModDisabled = new PageInstanceModDisabled();
			}
			return ModMain.FrmInstanceModDisabled;
		case FormMain.PageSubType.DownloadInstall:
			if (Information.IsNothing((object)ModMain.FrmInstanceSetup))
			{
				ModMain.FrmInstanceSetup = new PageInstanceSetup();
			}
			return ModMain.FrmInstanceSetup;
		case FormMain.PageSubType.DownloadPack:
			if (ModMain.FrmInstanceSaves == null)
			{
				ModMain.FrmInstanceSaves = new PageInstanceSaves();
			}
			return ModMain.FrmInstanceSaves;
		case FormMain.PageSubType.DownloadDataPack:
			if (ModMain.FrmInstanceScreenshot == null)
			{
				ModMain.FrmInstanceScreenshot = new PageInstanceScreenshot();
			}
			return ModMain.FrmInstanceScreenshot;
		case FormMain.PageSubType.DownloadWorld:
			if (ModMain.FrmInstanceResourcePack == null)
			{
				ModMain.FrmInstanceResourcePack = new PageInstanceCompResource(ModComp.CompType.ResourcePack);
			}
			return ModMain.FrmInstanceResourcePack;
		case FormMain.PageSubType.DownloadSchematic:
			if (ModMain.FrmInstanceShader == null)
			{
				ModMain.FrmInstanceShader = new PageInstanceCompResource(ModComp.CompType.Shader);
			}
			return ModMain.FrmInstanceShader;
		case FormMain.PageSubType.DownloadCompFavorites:
			if (ModMain.FrmInstanceSchematic == null)
			{
				ModMain.FrmInstanceSchematic = new PageInstanceCompResource(ModComp.CompType.Schematic);
			}
			return ModMain.FrmInstanceSchematic;
		case FormMain.PageSubType.VersionInstall:
			if (ModMain.FrmInstanceInstall == null)
			{
				ModMain.FrmInstanceInstall = new PageInstanceInstall();
			}
			return ModMain.FrmInstanceInstall;
		case FormMain.PageSubType.DownloadMod:
			if (ModMain.FrmInstanceExport == null)
			{
				ModMain.FrmInstanceExport = new PageInstanceExport();
			}
			return ModMain.FrmInstanceExport;
		case FormMain.PageSubType.VersionServer:
			if (ModMain.FrmInstanceServer == null)
			{
				ModMain.FrmInstanceServer = new PageInstanceServer();
			}
			return ModMain.FrmInstanceServer;
		default:
			throw new System.Exception("未知的实例设置子页面种类：" + Conversions.ToString((int)ID));
		}
	}

	public void PageChange(FormMain.PageSubType ID)
	{
		if (PageID == ID)
		{
			return;
		}
		checked
		{
			ModAnimation.AniControlEnabled++;
			try
			{
				PageChangeRun((MyPageRight)PageGet(ID));
				PageID = ID;
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "切换分页面失败（ID " + Conversions.ToString(unchecked((int)ID)) + "）", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
			finally
			{
				ModAnimation.AniControlEnabled--;
			}
		}
	}

	private static void PageChangeRun(MyPageRight Target)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		ModAnimation.AniStop("FrmMain PageChangeRight");
		if (((FrameworkElement)Target).Parent != null)
		{
			((DependencyObject)Target).SetValue(ContentPresenter.ContentProperty, (object)null);
		}
		ModMain.FrmMain.PageRight = Target;
		((MyPageRight)(object)((Decorator)ModMain.FrmMain.PanMainRight).Child).PageOnExit();
		ModAnimation.AniData[] array = new ModAnimation.AniData[2];
		object code;
		if (_Closure_0024__._0024I8_002D0 != null)
		{
			code = _Closure_0024__._0024I8_002D0;
		}
		else
		{
			ThreadStart val = [SpecialName] () =>
			{
				((MyPageRight)(object)((Decorator)ModMain.FrmMain.PanMainRight).Child).PageOnForceExit();
				((Decorator)ModMain.FrmMain.PanMainRight).Child = (UIElement)(object)ModMain.FrmMain.PageRight;
				((UIElement)ModMain.FrmMain.PageRight).Opacity = 0.0;
			};
			_Closure_0024__._0024I8_002D0 = val;
			code = (object)val;
		}
		array[0] = ModAnimation.AaCode((ThreadStart)code, 130);
		object code2;
		if (_Closure_0024__._0024I8_002D1 != null)
		{
			code2 = _Closure_0024__._0024I8_002D1;
		}
		else
		{
			ThreadStart val2 = [SpecialName] () =>
			{
				((UIElement)ModMain.FrmMain.PageRight).Opacity = 1.0;
				ModMain.FrmMain.PageRight.PageOnEnter();
			};
			_Closure_0024__._0024I8_002D1 = val2;
			code2 = (object)val2;
		}
		array[1] = ModAnimation.AaCode((ThreadStart)code2, 30, After: true);
		ModAnimation.AniStart((System.Collections.IList)(object)array, "PageLeft PageChange");
	}

	private void RefreshButton_Click(object sender, EventArgs e)
	{
		Refresh((FormMain.PageSubType)checked((int)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))))));
	}

	public void Refresh()
	{
		Refresh(ModMain.FrmMain.PageCurrentSub);
	}

	void IRefreshable.Refresh()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Refresh
		this.Refresh();
	}

	public void Refresh(FormMain.PageSubType SubType)
	{
		switch (SubType)
		{
		case FormMain.PageSubType.DownloadResourcePack:
			PageInstanceCompResource.Refresh(ModComp.CompType.Mod);
			break;
		case FormMain.PageSubType.DownloadDataPack:
			PageInstanceScreenshot.Refresh();
			break;
		case FormMain.PageSubType.DownloadPack:
			PageInstanceSaves.Refresh();
			break;
		case FormMain.PageSubType.DownloadWorld:
			PageInstanceCompResource.Refresh(ModComp.CompType.ResourcePack);
			break;
		case FormMain.PageSubType.DownloadSchematic:
			PageInstanceCompResource.Refresh(ModComp.CompType.Shader);
			break;
		case FormMain.PageSubType.DownloadCompFavorites:
			PageInstanceCompResource.Refresh(ModComp.CompType.Schematic);
			break;
		case FormMain.PageSubType.VersionInstall:
			ModDownload.DlClientListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlOptiFineListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlForgeListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlNeoForgeListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlLiteLoaderListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlFabricListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlFabricApiLoader.Start(null, IsForceRestart: true);
			ModDownload.DlQuiltListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlQSLLoader.Start(null, IsForceRestart: true);
			ModDownload.DlOptiFabricLoader.Start(null, IsForceRestart: true);
			ModDownload.DlLabyModListLoader.Start(null, IsForceRestart: true);
			ItemInstall.Checked = true;
			ModMain.FrmInstanceInstall.GetCurrentInfo();
			break;
		case FormMain.PageSubType.DownloadMod:
			if (ModMain.FrmInstanceExport != null)
			{
				ModMain.FrmInstanceExport.RefreshAll();
			}
			ItemExport.Checked = true;
			break;
		case FormMain.PageSubType.VersionServer:
			if (ModMain.FrmInstanceServer != null)
			{
				ModMain.FrmInstanceServer.RefreshServers();
			}
			ItemServer.Checked = true;
			break;
		case FormMain.PageSubType.DownloadShader:
			break;
		}
	}

	public void Reset(object sender, EventArgs e)
	{
		if (ModMain.MyMsgBox("是否要初始化该实例的实例独立设置？该操作不可撤销。", "初始化确认", "确定", "取消", "", IsWarn: true) == 1)
		{
			if (Information.IsNothing((object)ModMain.FrmInstanceSetup))
			{
				ModMain.FrmInstanceSetup = new PageInstanceSetup();
			}
			ModMain.FrmInstanceSetup.Reset();
			ItemSetup.Checked = true;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/pageinstanceleft.xaml", (UriKind)2);
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
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanItem = (StackPanel)target;
			break;
		case 2:
			ItemOverall = (MyListItem)target;
			break;
		case 3:
			ItemSetup = (MyListItem)target;
			break;
		case 4:
			ItemInstall = (MyListItem)target;
			break;
		case 5:
			ItemExport = (MyListItem)target;
			break;
		case 6:
			TextResource = (TextBlock)target;
			break;
		case 7:
			ItemWorld = (MyListItem)target;
			break;
		case 8:
			ItemScreenshot = (MyListItem)target;
			break;
		case 9:
			ItemMod = (MyListItem)target;
			break;
		case 10:
			ItemModDisabled = (MyListItem)target;
			break;
		case 11:
			ItemResourcePack = (MyListItem)target;
			break;
		case 12:
			ItemShader = (MyListItem)target;
			break;
		case 13:
			ItemSchematic = (MyListItem)target;
			break;
		case 14:
			ItemServer = (MyListItem)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
