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

namespace PCL;

[DesignerGenerated]
public class PageSetupLeft : MyPageLeft, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static ThreadStart _0024I9_002D0;

		public static ThreadStart _0024I9_002D1;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__9_002D0()
		{
			((MyPageRight)(object)((Decorator)ModMain.FrmMain.PanMainRight).Child).PageOnForceExit();
			((Decorator)ModMain.FrmMain.PanMainRight).Child = (UIElement)(object)ModMain.FrmMain.PageRight;
			((UIElement)ModMain.FrmMain.PageRight).Opacity = 0.0;
		}

		[SpecialName]
		internal void _Lambda_0024__9_002D1()
		{
			((UIElement)ModMain.FrmMain.PageRight).Opacity = 1.0;
			ModMain.FrmMain.PageRight.PageOnEnter();
		}
	}

	private bool IsLoad;

	private bool IsPageSwitched;

	public FormMain.PageSubType PageID;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemLaunch")]
	private MyListItem _ItemLaunch;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemUI")]
	private MyListItem _ItemUI;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemSystem")]
	private MyListItem _ItemSystem;

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

	internal virtual MyListItem ItemLaunch
	{
		[CompilerGenerated]
		get
		{
			return _ItemLaunch;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, (EventArgs)(object)a1);
			};
			MyListItem itemLaunch = _ItemLaunch;
			if (itemLaunch != null)
			{
				itemLaunch.Check -= obj;
			}
			_ItemLaunch = value;
			itemLaunch = _ItemLaunch;
			if (itemLaunch != null)
			{
				itemLaunch.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemUI
	{
		[CompilerGenerated]
		get
		{
			return _ItemUI;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, (EventArgs)(object)a1);
			};
			MyListItem itemUI = _ItemUI;
			if (itemUI != null)
			{
				itemUI.Check -= obj;
			}
			_ItemUI = value;
			itemUI = _ItemUI;
			if (itemUI != null)
			{
				itemUI.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemSystem
	{
		[CompilerGenerated]
		get
		{
			return _ItemSystem;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, (EventArgs)(object)a1);
			};
			MyListItem itemSystem = _ItemSystem;
			if (itemSystem != null)
			{
				itemSystem.Check -= obj;
			}
			_ItemSystem = value;
			itemSystem = _ItemSystem;
			if (itemSystem != null)
			{
				itemSystem.Check += obj;
			}
		}
	}

	private void PageSetupLeft_Loaded(object sender, RoutedEventArgs e)
	{
		bool flag = false;
		if (Conversions.ToBoolean((object)(ItemLaunch.Checked && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenSetupLaunch")))))
		{
			flag = true;
		}
		if (Conversions.ToBoolean((object)(ItemUI.Checked && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenSetupUi")))))
		{
			flag = true;
		}
		if (Conversions.ToBoolean((object)(ItemSystem.Checked && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenSetupSystem")))))
		{
			flag = true;
		}
		if (PageSetupUI.HiddenForceShow)
		{
			flag = false;
		}
		if (IsLoad && !flag)
		{
			return;
		}
		IsLoad = true;
		PageSetupUI.HiddenRefresh();
		if (!IsPageSwitched)
		{
			if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenSetupLaunch"))))
			{
				ItemLaunch.SetChecked(value: true, user: false, anime: false);
			}
			else if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenSetupUi"))))
			{
				ItemUI.SetChecked(value: true, user: false, anime: false);
			}
			else if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenSetupSystem"))))
			{
				ItemSystem.SetChecked(value: true, user: false, anime: false);
			}
			else
			{
				ItemLaunch.SetChecked(value: true, user: false, anime: false);
			}
		}
	}

	private void PageOtherLeft_Unloaded(object sender, RoutedEventArgs e)
	{
		IsPageSwitched = false;
	}

	public PageSetupLeft()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageSetupLeft_Loaded);
		((FrameworkElement)this).Unloaded += new RoutedEventHandler(PageOtherLeft_Unloaded);
		IsLoad = false;
		IsPageSwitched = false;
		InitializeComponent();
		if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenSetupLaunch"))))
		{
			PageID = FormMain.PageSubType.Default;
		}
		else if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenSetupUi"))))
		{
			PageID = FormMain.PageSubType.DownloadInstall;
		}
		else if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenSetupSystem"))))
		{
			PageID = FormMain.PageSubType.DownloadMod;
		}
		else
		{
			PageID = FormMain.PageSubType.Default;
		}
	}

	private void PageCheck(MyListItem sender, EventArgs e)
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
			if (ModMain.FrmSetupLaunch == null)
			{
				ModMain.FrmSetupLaunch = new PageSetupLaunch();
			}
			return ModMain.FrmSetupLaunch;
		case FormMain.PageSubType.DownloadInstall:
			if (ModMain.FrmSetupUI == null)
			{
				ModMain.FrmSetupUI = new PageSetupUI();
			}
			return ModMain.FrmSetupUI;
		case FormMain.PageSubType.DownloadMod:
			if (ModMain.FrmSetupSystem == null)
			{
				ModMain.FrmSetupSystem = new PageSetupSystem();
			}
			return ModMain.FrmSetupSystem;
		default:
			throw new System.Exception("未知的设置子页面种类：" + Conversions.ToString((int)ID));
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
			IsPageSwitched = true;
		}
		try
		{
			switch (ID)
			{
			case FormMain.PageSubType.Default:
				if (Information.IsNothing((object)ModMain.FrmSetupLaunch))
				{
					ModMain.FrmSetupLaunch = new PageSetupLaunch();
				}
				PageChangeRun(ModMain.FrmSetupLaunch);
				break;
			case FormMain.PageSubType.DownloadInstall:
				if (Information.IsNothing((object)ModMain.FrmSetupUI))
				{
					ModMain.FrmSetupUI = new PageSetupUI();
				}
				PageChangeRun(ModMain.FrmSetupUI);
				break;
			case FormMain.PageSubType.DownloadMod:
				if (Information.IsNothing((object)ModMain.FrmSetupSystem))
				{
					ModMain.FrmSetupSystem = new PageSetupSystem();
				}
				PageChangeRun(ModMain.FrmSetupSystem);
				break;
			default:
				throw new System.Exception("未知的设置子页面种类：" + Conversions.ToString((int)ID));
			}
			PageID = ID;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "切换分页面失败（ID " + Conversions.ToString((int)ID) + "）", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
		finally
		{
			checked
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
		if (_Closure_0024__._0024I9_002D0 != null)
		{
			code = _Closure_0024__._0024I9_002D0;
		}
		else
		{
			ThreadStart val = [SpecialName] () =>
			{
				((MyPageRight)(object)((Decorator)ModMain.FrmMain.PanMainRight).Child).PageOnForceExit();
				((Decorator)ModMain.FrmMain.PanMainRight).Child = (UIElement)(object)ModMain.FrmMain.PageRight;
				((UIElement)ModMain.FrmMain.PageRight).Opacity = 0.0;
			};
			_Closure_0024__._0024I9_002D0 = val;
			code = (object)val;
		}
		array[0] = ModAnimation.AaCode((ThreadStart)code, 130);
		object code2;
		if (_Closure_0024__._0024I9_002D1 != null)
		{
			code2 = _Closure_0024__._0024I9_002D1;
		}
		else
		{
			ThreadStart val2 = [SpecialName] () =>
			{
				((UIElement)ModMain.FrmMain.PageRight).Opacity = 1.0;
				ModMain.FrmMain.PageRight.PageOnEnter();
			};
			_Closure_0024__._0024I9_002D1 = val2;
			code2 = (object)val2;
		}
		array[1] = ModAnimation.AaCode((ThreadStart)code2, 30, After: true);
		ModAnimation.AniStart((System.Collections.IList)(object)array, "PageLeft PageChange");
	}

	public void Reset(object sender, EventArgs e)
	{
		double num = ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		if (num == 0.0)
		{
			if (ModMain.MyMsgBox("是否要初始化 启动 页面的所有设置？该操作不可撤销。", "初始化确认", "确定", "取消", "", IsWarn: true) == 1)
			{
				if (Information.IsNothing((object)ModMain.FrmSetupLaunch))
				{
					ModMain.FrmSetupLaunch = new PageSetupLaunch();
				}
				ModMain.FrmSetupLaunch.Reset();
				ItemLaunch.Checked = true;
			}
		}
		else if (num == 1.0)
		{
			if (ModMain.MyMsgBox("是否要初始化 个性化 页面的所有设置？该操作不可撤销。\r\n（背景图片与音乐、主页等外部文件不会被删除）", "初始化确认", "确定", "取消", "", IsWarn: true) == 1)
			{
				if (Information.IsNothing((object)ModMain.FrmSetupUI))
				{
					ModMain.FrmSetupUI = new PageSetupUI();
				}
				ModMain.FrmSetupUI.Reset();
				ItemUI.Checked = true;
			}
		}
		else if (num == 2.0 && ModMain.MyMsgBox("是否要初始化 其他 页面的所有设置？该操作不可撤销。", "初始化确认", "确定", "取消", "", IsWarn: true) == 1)
		{
			if (Information.IsNothing((object)ModMain.FrmSetupSystem))
			{
				ModMain.FrmSetupSystem = new PageSetupSystem();
			}
			ModMain.FrmSetupSystem.Reset();
			ItemSystem.Checked = true;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagesetup/pagesetupleft.xaml", (UriKind)2);
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
			ItemLaunch = (MyListItem)target;
			break;
		case 3:
			ItemUI = (MyListItem)target;
			break;
		case 4:
			ItemSystem = (MyListItem)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
