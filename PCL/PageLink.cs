using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageLink : MyPageLeft, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static ThreadStart _0024I10_002D0;

		public static ThreadStart _0024I10_002D1;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__10_002D0()
		{
			((MyPageRight)(object)((Decorator)ModMain.FrmMain.PanMainRight).Child).PageOnForceExit();
			((Decorator)ModMain.FrmMain.PanMainRight).Child = (UIElement)(object)ModMain.FrmMain.PageRight;
			((UIElement)ModMain.FrmMain.PageRight).Opacity = 0.0;
		}

		[SpecialName]
		internal void _Lambda_0024__10_002D1()
		{
			((UIElement)ModMain.FrmMain.PageRight).Opacity = 1.0;
			ModMain.FrmMain.PageRight.PageOnEnter();
		}
	}

	public FormMain.PageSubType PageID;

	private bool IsLoad;

	private bool IsPageSwitched;

	private readonly Dictionary<LinkProviderKind, PageLinkLobby> ProviderPages;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemJoin")]
	private MyListItem _ItemJoin;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemOpenFrp")]
	private MyListItem _ItemOpenFrp;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemMeFrp")]
	private MyListItem _ItemMeFrp;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemNatfrp")]
	private MyListItem _ItemNatfrp;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemXhFrp")]
	private MyListItem _ItemXhFrp;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemStellarfrp")]
	private MyListItem _ItemStellarfrp;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemSetup")]
	private MyListItem _ItemSetup;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemHelp")]
	private MyListItem _ItemHelp;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemFeedback")]
	private MyListItem _ItemFeedback;

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

	internal virtual MyListItem ItemJoin
	{
		[CompilerGenerated]
		get
		{
			return _ItemJoin;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemJoin = _ItemJoin;
			if (itemJoin != null)
			{
				itemJoin.Check -= obj;
			}
			_ItemJoin = value;
			itemJoin = _ItemJoin;
			if (itemJoin != null)
			{
				itemJoin.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemOpenFrp
	{
		[CompilerGenerated]
		get
		{
			return _ItemOpenFrp;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemOpenFrp = _ItemOpenFrp;
			if (itemOpenFrp != null)
			{
				itemOpenFrp.Check -= obj;
			}
			_ItemOpenFrp = value;
			itemOpenFrp = _ItemOpenFrp;
			if (itemOpenFrp != null)
			{
				itemOpenFrp.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemMeFrp
	{
		[CompilerGenerated]
		get
		{
			return _ItemMeFrp;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemMeFrp = _ItemMeFrp;
			if (itemMeFrp != null)
			{
				itemMeFrp.Check -= obj;
			}
			_ItemMeFrp = value;
			itemMeFrp = _ItemMeFrp;
			if (itemMeFrp != null)
			{
				itemMeFrp.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemNatfrp
	{
		[CompilerGenerated]
		get
		{
			return _ItemNatfrp;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemNatfrp = _ItemNatfrp;
			if (itemNatfrp != null)
			{
				itemNatfrp.Check -= obj;
			}
			_ItemNatfrp = value;
			itemNatfrp = _ItemNatfrp;
			if (itemNatfrp != null)
			{
				itemNatfrp.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemXhFrp
	{
		[CompilerGenerated]
		get
		{
			return _ItemXhFrp;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemXhFrp = _ItemXhFrp;
			if (itemXhFrp != null)
			{
				itemXhFrp.Check -= obj;
			}
			_ItemXhFrp = value;
			itemXhFrp = _ItemXhFrp;
			if (itemXhFrp != null)
			{
				itemXhFrp.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemStellarfrp
	{
		[CompilerGenerated]
		get
		{
			return _ItemStellarfrp;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemStellarfrp = _ItemStellarfrp;
			if (itemStellarfrp != null)
			{
				itemStellarfrp.Check -= obj;
			}
			_ItemStellarfrp = value;
			itemStellarfrp = _ItemStellarfrp;
			if (itemStellarfrp != null)
			{
				itemStellarfrp.Check += obj;
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

	internal virtual MyListItem ItemHelp
	{
		[CompilerGenerated]
		get
		{
			return _ItemHelp;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemHelp = _ItemHelp;
			if (itemHelp != null)
			{
				itemHelp.Check -= obj;
			}
			_ItemHelp = value;
			itemHelp = _ItemHelp;
			if (itemHelp != null)
			{
				itemHelp.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemFeedback
	{
		[CompilerGenerated]
		get
		{
			return _ItemFeedback;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemFeedback = _ItemFeedback;
			if (itemFeedback != null)
			{
				itemFeedback.Check -= obj;
			}
			_ItemFeedback = value;
			itemFeedback = _ItemFeedback;
			if (itemFeedback != null)
			{
				itemFeedback.Check += obj;
			}
		}
	}

	public PageLink()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageLink_Loaded);
		((FrameworkElement)this).Unloaded += new RoutedEventHandler(PageLink_Unloaded);
		PageID = FormMain.PageSubType.Default;
		IsLoad = false;
		IsPageSwitched = false;
		ProviderPages = new Dictionary<LinkProviderKind, PageLinkLobby>();
		InitializeComponent();
	}

	private void PageLink_Loaded(object sender, RoutedEventArgs e)
	{
		if (!IsLoad)
		{
			IsLoad = true;
			ApplyProviderVisibility();
			if (!IsPageSwitched)
			{
				ItemJoin.SetChecked(value: true, user: false, anime: false);
			}
		}
	}

	private void PageLink_Unloaded(object sender, RoutedEventArgs e)
	{
		IsPageSwitched = false;
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
			if (ModMain.FrmLinkJoin == null)
			{
				ModMain.FrmLinkJoin = new PageLinkJoin();
			}
			return ModMain.FrmLinkJoin;
		case FormMain.PageSubType.DownloadInstall:
			return GetProviderPage(LinkProviderKind.OpenFrp);
		case FormMain.PageSubType.DownloadMod:
			return GetProviderPage(LinkProviderKind.MeFrp);
		case FormMain.PageSubType.DownloadPack:
			return GetProviderPage(LinkProviderKind.Natfrp);
		case FormMain.PageSubType.DownloadDataPack:
			return GetProviderPage(LinkProviderKind.XhFrp);
		case FormMain.PageSubType.DownloadResourcePack:
			return GetProviderPage(LinkProviderKind.Stellarfrp);
		case FormMain.PageSubType.DownloadShader:
			if (ModMain.FrmSetupLink == null)
			{
				ModMain.FrmSetupLink = new PageLinkSetup();
			}
			return ModMain.FrmSetupLink;
		case FormMain.PageSubType.DownloadWorld:
			if (ModMain.FrmLinkHelp == null)
			{
				ModMain.FrmLinkHelp = new PageLinkQA();
			}
			return ModMain.FrmLinkHelp;
		case FormMain.PageSubType.DownloadSchematic:
			if (ModMain.FrmLinkFeedback == null)
			{
				ModMain.FrmLinkFeedback = new PageLinkFeedback();
			}
			return ModMain.FrmLinkFeedback;
		default:
			throw new System.Exception("未知的更多子页面种类：" + Conversions.ToString((int)ID));
		}
	}

	public void PageChange(FormMain.PageSubType ID)
	{
		checked
		{
			if (!CanNavigateTo(ID))
			{
				ModMain.Hint("该供应商已被禁用");
				ItemJoin.SetChecked(value: true, user: false, anime: false);
			}
			else
			{
				if (PageID == ID)
				{
					return;
				}
				ModAnimation.AniControlEnabled++;
				IsPageSwitched = true;
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
		if (_Closure_0024__._0024I10_002D0 != null)
		{
			code = _Closure_0024__._0024I10_002D0;
		}
		else
		{
			ThreadStart val = [SpecialName] () =>
			{
				((MyPageRight)(object)((Decorator)ModMain.FrmMain.PanMainRight).Child).PageOnForceExit();
				((Decorator)ModMain.FrmMain.PanMainRight).Child = (UIElement)(object)ModMain.FrmMain.PageRight;
				((UIElement)ModMain.FrmMain.PageRight).Opacity = 0.0;
			};
			_Closure_0024__._0024I10_002D0 = val;
			code = (object)val;
		}
		array[0] = ModAnimation.AaCode((ThreadStart)code, 130);
		object code2;
		if (_Closure_0024__._0024I10_002D1 != null)
		{
			code2 = _Closure_0024__._0024I10_002D1;
		}
		else
		{
			ThreadStart val2 = [SpecialName] () =>
			{
				((UIElement)ModMain.FrmMain.PageRight).Opacity = 1.0;
				ModMain.FrmMain.PageRight.PageOnEnter();
			};
			_Closure_0024__._0024I10_002D1 = val2;
			code2 = (object)val2;
		}
		array[1] = ModAnimation.AaCode((ThreadStart)code2, 30, After: true);
		ModAnimation.AniStart((System.Collections.IList)(object)array, "PageLink PageChange");
	}

	public void Refresh(object sender, EventArgs e)
	{
		LinkProviderKind? providerKind = GetProviderKind(PageID);
		if (providerKind.HasValue)
		{
			GetProviderPage(providerKind.Value).Reload();
		}
	}

	private LinkProviderKind? GetProviderKind(FormMain.PageSubType id)
	{
		return id switch
		{
			FormMain.PageSubType.DownloadInstall => LinkProviderKind.OpenFrp, 
			FormMain.PageSubType.DownloadMod => LinkProviderKind.MeFrp, 
			FormMain.PageSubType.DownloadPack => LinkProviderKind.Natfrp, 
			FormMain.PageSubType.DownloadDataPack => LinkProviderKind.XhFrp, 
			FormMain.PageSubType.DownloadResourcePack => LinkProviderKind.Stellarfrp, 
			_ => null, 
		};
	}

	private PageLinkLobby GetProviderPage(LinkProviderKind kind)
	{
		if (!ProviderPages.ContainsKey(kind))
		{
			ProviderPages[kind] = new PageLinkLobby
			{
				Provider = LinkProviderRegistry.GetProvider(kind)
			};
		}
		return ProviderPages[kind];
	}

	public void Reset(object sender, EventArgs e)
	{
		if (ModMain.MyMsgBox("是否要初始化联机页的所有设置？该操作不可撤销。", "初始化确认", "确定", "取消", "", IsWarn: true) == 1)
		{
			if (Information.IsNothing((object)ModMain.FrmSetupLink))
			{
				ModMain.FrmSetupLink = new PageLinkSetup();
			}
			ModMain.FrmSetupLink.Reset();
			ItemSetup.Checked = true;
		}
	}

	public void ApplyProviderVisibility()
	{
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		bool flag2 = true;
		bool flag3 = true;
		bool flag4 = true;
		bool flag5 = true;
		try
		{
			flag = Conversions.ToBoolean(ModBase.Setup.Get("LinkEnableOpenFrp") ?? ((object)true));
			ModBase.Log($"[可见性] OpenFrp 配置: {flag}");
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "读取 OpenFrp 配置失败");
			ProjectData.ClearProjectError();
		}
		try
		{
			flag2 = Conversions.ToBoolean(ModBase.Setup.Get("LinkEnableMeFrp") ?? ((object)true));
			ModBase.Log($"[可见性] MeFrp 配置: {flag2}");
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			ModBase.Log(ex4, "读取 MeFrp 配置失败");
			ProjectData.ClearProjectError();
		}
		try
		{
			flag3 = Conversions.ToBoolean(ModBase.Setup.Get("LinkEnableNatfrp") ?? ((object)true));
			ModBase.Log($"[可见性] Natfrp 配置: {flag3}");
		}
		catch (System.Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			System.Exception ex6 = ex5;
			ModBase.Log(ex6, "读取 Natfrp 配置失败");
			ProjectData.ClearProjectError();
		}
		try
		{
			flag4 = Conversions.ToBoolean(ModBase.Setup.Get("LinkEnableXhFrp") ?? ((object)true));
			ModBase.Log($"[可见性] XhFrp 配置: {flag4}");
		}
		catch (System.Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			System.Exception ex8 = ex7;
			ModBase.Log(ex8, "读取 XhFrp 配置失败");
			ProjectData.ClearProjectError();
		}
		try
		{
			flag5 = Conversions.ToBoolean(ModBase.Setup.Get("LinkEnableStellarfrp") ?? ((object)true));
			ModBase.Log($"[可见性] Stellarfrp 配置: {flag5}");
		}
		catch (System.Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			System.Exception ex10 = ex9;
			ModBase.Log(ex10, "读取 Stellarfrp 配置失败");
			ProjectData.ClearProjectError();
		}
		ModBase.Log(string.Format("[可见性] 设置前 - ItemOpenFrp.Visibility: {0}, ItemMeFrp.Visibility: {1}, ItemNatfrp.Visibility: {2}, ItemXhFrp.Visibility: {3}, ItemStellarfrp.Visibility: {4}", new object[5]
		{
			((UIElement)ItemOpenFrp).Visibility,
			((UIElement)ItemMeFrp).Visibility,
			((UIElement)ItemNatfrp).Visibility,
			((UIElement)ItemXhFrp).Visibility,
			((UIElement)ItemStellarfrp).Visibility
		}));
		((UIElement)ItemOpenFrp).Visibility = (Visibility)((!flag) ? 2 : 0);
		((UIElement)ItemMeFrp).Visibility = (Visibility)((!flag2) ? 2 : 0);
		((UIElement)ItemNatfrp).Visibility = (Visibility)((!flag3) ? 2 : 0);
		((UIElement)ItemXhFrp).Visibility = (Visibility)((!flag4) ? 2 : 0);
		((UIElement)ItemStellarfrp).Visibility = (Visibility)((!flag5) ? 2 : 0);
		ModBase.Log(string.Format("[可见性] 设置后 - ItemOpenFrp.Visibility: {0}, ItemMeFrp.Visibility: {1}, ItemNatfrp.Visibility: {2}, ItemXhFrp.Visibility: {3}, ItemStellarfrp.Visibility: {4}", new object[5]
		{
			((UIElement)ItemOpenFrp).Visibility,
			((UIElement)ItemMeFrp).Visibility,
			((UIElement)ItemNatfrp).Visibility,
			((UIElement)ItemXhFrp).Visibility,
			((UIElement)ItemStellarfrp).Visibility
		}));
		if (!flag && PageID == FormMain.PageSubType.DownloadInstall)
		{
			ItemJoin.SetChecked(value: true, user: false, anime: false);
		}
		if (!flag2 && PageID == FormMain.PageSubType.DownloadMod)
		{
			ItemJoin.SetChecked(value: true, user: false, anime: false);
		}
		if (!flag3 && PageID == FormMain.PageSubType.DownloadPack)
		{
			ItemJoin.SetChecked(value: true, user: false, anime: false);
		}
		if (!flag4 && PageID == FormMain.PageSubType.DownloadDataPack)
		{
			ItemJoin.SetChecked(value: true, user: false, anime: false);
		}
		if (!flag5 && PageID == FormMain.PageSubType.DownloadResourcePack)
		{
			ItemJoin.SetChecked(value: true, user: false, anime: false);
		}
	}

	private bool CanNavigateTo(FormMain.PageSubType id)
	{
		bool result;
		switch (id)
		{
		case FormMain.PageSubType.DownloadInstall:
			try
			{
				result = Conversions.ToBoolean(ModBase.Setup.Get("LinkEnableOpenFrp") ?? ((object)true));
			}
			catch (System.Exception projectError5)
			{
				ProjectData.SetProjectError(projectError5);
				result = true;
				ProjectData.ClearProjectError();
			}
			break;
		case FormMain.PageSubType.DownloadMod:
			try
			{
				result = Conversions.ToBoolean(ModBase.Setup.Get("LinkEnableMeFrp") ?? ((object)true));
			}
			catch (System.Exception projectError4)
			{
				ProjectData.SetProjectError(projectError4);
				result = true;
				ProjectData.ClearProjectError();
			}
			break;
		case FormMain.PageSubType.DownloadPack:
			try
			{
				result = Conversions.ToBoolean(ModBase.Setup.Get("LinkEnableNatfrp") ?? ((object)true));
			}
			catch (System.Exception projectError3)
			{
				ProjectData.SetProjectError(projectError3);
				result = true;
				ProjectData.ClearProjectError();
			}
			break;
		case FormMain.PageSubType.DownloadDataPack:
			try
			{
				result = Conversions.ToBoolean(ModBase.Setup.Get("LinkEnableXhFrp") ?? ((object)true));
			}
			catch (System.Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				result = true;
				ProjectData.ClearProjectError();
			}
			break;
		case FormMain.PageSubType.DownloadResourcePack:
			try
			{
				result = Conversions.ToBoolean(ModBase.Setup.Get("LinkEnableStellarfrp") ?? ((object)true));
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				result = true;
				ProjectData.ClearProjectError();
			}
			break;
		default:
			result = true;
			break;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelink/pagelink.xaml", (UriKind)2);
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
			ItemJoin = (MyListItem)target;
			break;
		case 3:
			ItemOpenFrp = (MyListItem)target;
			break;
		case 4:
			ItemMeFrp = (MyListItem)target;
			break;
		case 5:
			ItemNatfrp = (MyListItem)target;
			break;
		case 6:
			ItemXhFrp = (MyListItem)target;
			break;
		case 7:
			ItemStellarfrp = (MyListItem)target;
			break;
		case 8:
			ItemSetup = (MyListItem)target;
			break;
		case 9:
			ItemHelp = (MyListItem)target;
			break;
		case 10:
			ItemFeedback = (MyListItem)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
