using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageDownloadLeft : MyPageLeft, IRefreshable, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static ThreadStart _0024I5_002D0;

		public static ThreadStart _0024I5_002D1;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__5_002D0()
		{
			((MyPageRight)(object)((Decorator)ModMain.FrmMain.PanMainRight).Child).PageOnForceExit();
			((Decorator)ModMain.FrmMain.PanMainRight).Child = (UIElement)(object)ModMain.FrmMain.PageRight;
			((UIElement)ModMain.FrmMain.PageRight).Opacity = 0.0;
		}

		[SpecialName]
		internal void _Lambda_0024__5_002D1()
		{
			((UIElement)ModMain.FrmMain.PageRight).Opacity = 1.0;
			ModMain.FrmMain.PageRight.PageOnEnter();
		}
	}

	public FormMain.PageSubType PageID;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemInstall")]
	private MyListItem _ItemInstall;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemMod")]
	private MyListItem _ItemMod;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemPack")]
	private MyListItem _ItemPack;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemDataPack")]
	private MyListItem _ItemDataPack;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemResourcePack")]
	private MyListItem _ItemResourcePack;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemShader")]
	private MyListItem _ItemShader;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemWorld")]
	private MyListItem _ItemWorld;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemSchematic")]
	private MyListItem _ItemSchematic;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemFavorites")]
	private MyListItem _ItemFavorites;

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
			MyListItem.ClickEventHandler obj2 = ItemInstall_Click;
			MyListItem itemInstall = _ItemInstall;
			if (itemInstall != null)
			{
				itemInstall.Check -= obj;
				itemInstall.Click -= obj2;
			}
			_ItemInstall = value;
			itemInstall = _ItemInstall;
			if (itemInstall != null)
			{
				itemInstall.Check += obj;
				itemInstall.Click += obj2;
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

	internal virtual MyListItem ItemPack
	{
		[CompilerGenerated]
		get
		{
			return _ItemPack;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemPack = _ItemPack;
			if (itemPack != null)
			{
				itemPack.Check -= obj;
			}
			_ItemPack = value;
			itemPack = _ItemPack;
			if (itemPack != null)
			{
				itemPack.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemDataPack
	{
		[CompilerGenerated]
		get
		{
			return _ItemDataPack;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemDataPack = _ItemDataPack;
			if (itemDataPack != null)
			{
				itemDataPack.Check -= obj;
			}
			_ItemDataPack = value;
			itemDataPack = _ItemDataPack;
			if (itemDataPack != null)
			{
				itemDataPack.Check += obj;
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

	internal virtual MyListItem ItemFavorites
	{
		[CompilerGenerated]
		get
		{
			return _ItemFavorites;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemFavorites = _ItemFavorites;
			if (itemFavorites != null)
			{
				itemFavorites.Check -= obj;
			}
			_ItemFavorites = value;
			itemFavorites = _ItemFavorites;
			if (itemFavorites != null)
			{
				itemFavorites.Check += obj;
			}
		}
	}

	public PageDownloadLeft()
	{
		PageID = FormMain.PageSubType.DownloadInstall;
		InitializeComponent();
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
		case FormMain.PageSubType.DownloadInstall:
			if (ModMain.FrmDownloadInstall == null)
			{
				ModMain.FrmDownloadInstall = new PageDownloadInstall();
			}
			return ModMain.FrmDownloadInstall;
		case FormMain.PageSubType.DownloadMod:
			if (ModMain.FrmDownloadMod == null)
			{
				ModMain.FrmDownloadMod = new PageDownloadMod();
			}
			return ModMain.FrmDownloadMod;
		case FormMain.PageSubType.DownloadPack:
			if (ModMain.FrmDownloadPack == null)
			{
				ModMain.FrmDownloadPack = new PageDownloadPack();
			}
			return ModMain.FrmDownloadPack;
		case FormMain.PageSubType.DownloadDataPack:
			if (ModMain.FrmDownloadDataPack == null)
			{
				ModMain.FrmDownloadDataPack = new PageDownloadDataPack();
			}
			return ModMain.FrmDownloadDataPack;
		case FormMain.PageSubType.DownloadResourcePack:
			if (ModMain.FrmDownloadResourcePack == null)
			{
				ModMain.FrmDownloadResourcePack = new PageDownloadResourcePack();
			}
			return ModMain.FrmDownloadResourcePack;
		case FormMain.PageSubType.DownloadShader:
			if (ModMain.FrmDownloadShader == null)
			{
				ModMain.FrmDownloadShader = new PageDownloadShader();
			}
			return ModMain.FrmDownloadShader;
		case FormMain.PageSubType.DownloadWorld:
			if (ModMain.FrmDownloadWorld == null)
			{
				ModMain.FrmDownloadWorld = new PageDownloadWorld();
			}
			return ModMain.FrmDownloadWorld;
		case FormMain.PageSubType.DownloadSchematic:
			if (ModMain.FrmDownloadSchematic == null)
			{
				ModMain.FrmDownloadSchematic = new PageDownloadSchematic();
			}
			return ModMain.FrmDownloadSchematic;
		case FormMain.PageSubType.DownloadCompFavorites:
			if (ModMain.FrmDownloadCompFavorites == null)
			{
				ModMain.FrmDownloadCompFavorites = new PageDownloadCompFavorites();
			}
			return ModMain.FrmDownloadCompFavorites;
		default:
			throw new System.Exception("未知的下载子页面种类：" + Conversions.ToString((int)ID));
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
		if (_Closure_0024__._0024I5_002D0 != null)
		{
			code = _Closure_0024__._0024I5_002D0;
		}
		else
		{
			ThreadStart val = [SpecialName] () =>
			{
				((MyPageRight)(object)((Decorator)ModMain.FrmMain.PanMainRight).Child).PageOnForceExit();
				((Decorator)ModMain.FrmMain.PanMainRight).Child = (UIElement)(object)ModMain.FrmMain.PageRight;
				((UIElement)ModMain.FrmMain.PageRight).Opacity = 0.0;
			};
			_Closure_0024__._0024I5_002D0 = val;
			code = (object)val;
		}
		array[0] = ModAnimation.AaCode((ThreadStart)code, 130);
		object code2;
		if (_Closure_0024__._0024I5_002D1 != null)
		{
			code2 = _Closure_0024__._0024I5_002D1;
		}
		else
		{
			ThreadStart val2 = [SpecialName] () =>
			{
				((UIElement)ModMain.FrmMain.PageRight).Opacity = 1.0;
				ModMain.FrmMain.PageRight.PageOnEnter();
			};
			_Closure_0024__._0024I5_002D1 = val2;
			code2 = (object)val2;
		}
		array[1] = ModAnimation.AaCode((ThreadStart)code2, 30, After: true);
		ModAnimation.AniStart((System.Collections.IList)(object)array, "PageLeft PageChange");
	}

	public void RefreshButton_Click(object sender, EventArgs e)
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
		case FormMain.PageSubType.DownloadInstall:
			ModDownload.DlClientListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlOptiFineListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlForgeListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlNeoForgeListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlCleanroomListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlLiteLoaderListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlFabricListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlLegacyFabricListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlFabricApiLoader.Start(null, IsForceRestart: true);
			ModDownload.DlLegacyFabricApiLoader.Start(null, IsForceRestart: true);
			ModDownload.DlQuiltListLoader.Start(null, IsForceRestart: true);
			ModDownload.DlQSLLoader.Start(null, IsForceRestart: true);
			ModDownload.DlOptiFabricLoader.Start(null, IsForceRestart: true);
			ModDownload.DlLabyModListLoader.Start(null, IsForceRestart: true);
			ItemInstall.Checked = true;
			break;
		case FormMain.PageSubType.DownloadMod:
			ModComp.CompProjectCache.Clear();
			ModComp.CompFilesCache.Clear();
			if (ModMain.FrmDownloadMod != null)
			{
				ModMain.FrmDownloadMod.Content.Storage = new ModComp.CompProjectStorage();
				ModMain.FrmDownloadMod.Content.Page = 0;
				ModMain.FrmDownloadMod.PageLoaderRestart();
			}
			ItemMod.Checked = true;
			break;
		case FormMain.PageSubType.DownloadPack:
			ModComp.CompProjectCache.Clear();
			ModComp.CompFilesCache.Clear();
			if (ModMain.FrmDownloadPack != null)
			{
				ModMain.FrmDownloadPack.Content.Storage = new ModComp.CompProjectStorage();
				ModMain.FrmDownloadPack.Content.Page = 0;
				ModMain.FrmDownloadPack.PageLoaderRestart();
			}
			ItemPack.Checked = true;
			break;
		case FormMain.PageSubType.DownloadDataPack:
			ModComp.CompProjectCache.Clear();
			ModComp.CompFilesCache.Clear();
			if (ModMain.FrmDownloadDataPack != null)
			{
				ModMain.FrmDownloadDataPack.Content.Storage = new ModComp.CompProjectStorage();
				ModMain.FrmDownloadDataPack.Content.Page = 0;
				ModMain.FrmDownloadDataPack.PageLoaderRestart();
			}
			ItemDataPack.Checked = true;
			break;
		case FormMain.PageSubType.DownloadResourcePack:
			ModComp.CompProjectCache.Clear();
			ModComp.CompFilesCache.Clear();
			if (ModMain.FrmDownloadResourcePack != null)
			{
				ModMain.FrmDownloadResourcePack.Content.Storage = new ModComp.CompProjectStorage();
				ModMain.FrmDownloadResourcePack.Content.Page = 0;
				ModMain.FrmDownloadResourcePack.PageLoaderRestart();
			}
			ItemResourcePack.Checked = true;
			break;
		case FormMain.PageSubType.DownloadShader:
			ModComp.CompProjectCache.Clear();
			ModComp.CompFilesCache.Clear();
			if (ModMain.FrmDownloadShader != null)
			{
				ModMain.FrmDownloadShader.Content.Storage = new ModComp.CompProjectStorage();
				ModMain.FrmDownloadShader.Content.Page = 0;
				ModMain.FrmDownloadShader.PageLoaderRestart();
			}
			ItemShader.Checked = true;
			break;
		case FormMain.PageSubType.DownloadWorld:
			ModComp.CompProjectCache.Clear();
			ModComp.CompFilesCache.Clear();
			if (ModMain.FrmDownloadWorld != null)
			{
				ModMain.FrmDownloadWorld.Content.Storage = new ModComp.CompProjectStorage();
				ModMain.FrmDownloadWorld.Content.Page = 0;
				ModMain.FrmDownloadWorld.PageLoaderRestart();
			}
			ItemWorld.Checked = true;
			break;
		case FormMain.PageSubType.DownloadSchematic:
			if (ModMain.FrmDownloadSchematic != null)
			{
				ModMain.FrmDownloadSchematic.PageLoaderRestart();
			}
			ItemSchematic.Checked = true;
			break;
		case FormMain.PageSubType.DownloadCompFavorites:
			if (ModMain.FrmDownloadCompFavorites != null)
			{
				ModMain.FrmDownloadCompFavorites.PageLoaderRestart();
			}
			ItemFavorites.Checked = true;
			break;
		}
		ModMain.Hint("正在刷新……", ModMain.HintType.Info, Log: false);
	}

	private void ItemInstall_Click(object sender, MouseButtonEventArgs e)
	{
		if (ItemInstall.Checked)
		{
			ModMain.FrmDownloadInstall.ExitSelectPage();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagedownload/pagedownloadleft.xaml", (UriKind)2);
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
		switch (connectionId)
		{
		case 1:
			PanItem = (StackPanel)target;
			break;
		case 2:
			ItemInstall = (MyListItem)target;
			break;
		case 3:
			ItemMod = (MyListItem)target;
			break;
		case 4:
			ItemPack = (MyListItem)target;
			break;
		case 5:
			ItemDataPack = (MyListItem)target;
			break;
		case 6:
			ItemResourcePack = (MyListItem)target;
			break;
		case 7:
			ItemShader = (MyListItem)target;
			break;
		case 8:
			ItemWorld = (MyListItem)target;
			break;
		case 9:
			ItemSchematic = (MyListItem)target;
			break;
		case 10:
			ItemFavorites = (MyListItem)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
