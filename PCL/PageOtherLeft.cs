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
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageOtherLeft : MyPageLeft, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static ThreadStart _0024I9_002D0;

		public static ThreadStart _0024I9_002D1;

		public static Action _0024I12_002D0;

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

		[SpecialName]
		internal void _Lambda_0024__12_002D0()
		{
			if (ModBase.CanFeedback(ShowHint: true))
			{
				switch (ModMain.MyMsgBox("在提交新反馈前，建议先搜索反馈列表，以避免重复提交。\r\n如果无法打开该网页，请尝试使用加速器或 VPN。", "反馈", "提交新反馈", "查看反馈列表", "取消"))
				{
				case 1:
					ModBase.Feedback();
					break;
				case 2:
					ModBase.OpenWebsite("https://github.com/PCLPro/PCLPro/issues/");
					break;
				}
			}
		}
	}

	private bool IsLoad;

	private bool IsPageSwitched;

	public FormMain.PageSubType PageID;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemHelp")]
	private MyListItem _ItemHelp;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemAbout")]
	private MyListItem _ItemAbout;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemTest")]
	private MyListItem _ItemTest;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemFeedback")]
	private MyListItem _ItemFeedback;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemVote")]
	private MyListItem _ItemVote;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemLog")]
	private MyListItem _ItemLog;

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

	internal virtual MyListItem ItemAbout
	{
		[CompilerGenerated]
		get
		{
			return _ItemAbout;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemAbout = _ItemAbout;
			if (itemAbout != null)
			{
				itemAbout.Check -= obj;
			}
			_ItemAbout = value;
			itemAbout = _ItemAbout;
			if (itemAbout != null)
			{
				itemAbout.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemTest
	{
		[CompilerGenerated]
		get
		{
			return _ItemTest;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemTest = _ItemTest;
			if (itemTest != null)
			{
				itemTest.Check -= obj;
			}
			_ItemTest = value;
			itemTest = _ItemTest;
			if (itemTest != null)
			{
				itemTest.Check += obj;
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

	internal virtual MyListItem ItemVote
	{
		[CompilerGenerated]
		get
		{
			return _ItemVote;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemVote = _ItemVote;
			if (itemVote != null)
			{
				itemVote.Check -= obj;
			}
			_ItemVote = value;
			itemVote = _ItemVote;
			if (itemVote != null)
			{
				itemVote.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemLog
	{
		[CompilerGenerated]
		get
		{
			return _ItemLog;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemLog = _ItemLog;
			if (itemLog != null)
			{
				itemLog.Check -= obj;
			}
			_ItemLog = value;
			itemLog = _ItemLog;
			if (itemLog != null)
			{
				itemLog.Check += obj;
			}
		}
	}

	private void PageOtherLeft_Loaded(object sender, RoutedEventArgs e)
	{
		bool flag = false;
		if (Conversions.ToBoolean((object)(ItemHelp.Checked && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherHelp")))))
		{
			flag = true;
		}
		if (Conversions.ToBoolean((object)(ItemAbout.Checked && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherAbout")))))
		{
			flag = true;
		}
		if (Conversions.ToBoolean((object)(ItemTest.Checked && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherTest")))))
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
			if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenOtherHelp"))))
			{
				ItemHelp.SetChecked(value: true, user: false, anime: false);
			}
			else if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenOtherAbout"))))
			{
				ItemAbout.SetChecked(value: true, user: false, anime: false);
			}
			else
			{
				ItemTest.SetChecked(value: true, user: false, anime: false);
			}
		}
	}

	private void PageOtherLeft_Unloaded(object sender, RoutedEventArgs e)
	{
		IsPageSwitched = false;
	}

	public PageOtherLeft()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageOtherLeft_Loaded);
		((FrameworkElement)this).Unloaded += new RoutedEventHandler(PageOtherLeft_Unloaded);
		IsLoad = false;
		IsPageSwitched = false;
		InitializeComponent();
		if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenOtherHelp"))))
		{
			PageID = FormMain.PageSubType.Default;
		}
		else if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenOtherAbout"))))
		{
			PageID = FormMain.PageSubType.DownloadInstall;
		}
		else
		{
			PageID = FormMain.PageSubType.DownloadMod;
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
			if (ModMain.FrmOtherHelp == null)
			{
				ModMain.FrmOtherHelp = new PageOtherHelp();
			}
			return ModMain.FrmOtherHelp;
		case FormMain.PageSubType.DownloadInstall:
			if (ModMain.FrmOtherAbout == null)
			{
				ModMain.FrmOtherAbout = new PageOtherAbout();
			}
			return ModMain.FrmOtherAbout;
		case FormMain.PageSubType.DownloadMod:
			if (ModMain.FrmOtherTest == null)
			{
				ModMain.FrmOtherTest = new PageOtherTest();
			}
			return ModMain.FrmOtherTest;
		case FormMain.PageSubType.DownloadPack:
			if (ModMain.FrmOtherFeedback == null)
			{
				ModMain.FrmOtherFeedback = new PageOtherFeedback();
			}
			return ModMain.FrmOtherFeedback;
		case FormMain.PageSubType.DownloadDataPack:
			if (ModMain.FrmOtherVote == null)
			{
				ModMain.FrmOtherVote = new PageOtherVote();
			}
			return ModMain.FrmOtherVote;
		case FormMain.PageSubType.DownloadResourcePack:
			if (ModMain.FrmOtherLog == null)
			{
				ModMain.FrmOtherLog = new PageOtherLog();
			}
			return ModMain.FrmOtherLog;
		default:
			throw new System.Exception("未知的更多子页面种类：" + Conversions.ToString((int)ID));
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

	public void Refresh(object sender, EventArgs e)
	{
		double num = ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		if (num == 0.0)
		{
			RefreshHelp();
			ItemHelp.Checked = true;
		}
		else if (num == 3.0)
		{
			if (ModMain.FrmOtherFeedback != null)
			{
				ModMain.FrmOtherFeedback.Loader.Start(null, IsForceRestart: true);
			}
			ItemFeedback.Checked = true;
		}
		else if (num == 4.0)
		{
			if (ModMain.FrmOtherVote != null)
			{
				ModMain.FrmOtherVote.Loader.Start(null, IsForceRestart: true);
			}
			ItemVote.Checked = true;
		}
		else if (num == 5.0)
		{
			if (ModMain.FrmOtherLog != null)
			{
				ModMain.FrmOtherLog.LoadList();
			}
			ItemLog.Checked = true;
		}
		ModMain.Hint("正在刷新……", ModMain.HintType.Info, Log: false);
	}

	public static void RefreshHelp()
	{
		ModMain.FrmOtherHelp.PageLoaderRestart();
		ModMain.FrmOtherHelp.SearchBox.Text = "";
	}

	public static void TryFeedback()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I12_002D0 != null)
		{
			action = _Closure_0024__._0024I12_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				if (ModBase.CanFeedback(ShowHint: true))
				{
					switch (ModMain.MyMsgBox("在提交新反馈前，建议先搜索反馈列表，以避免重复提交。\r\n如果无法打开该网页，请尝试使用加速器或 VPN。", "反馈", "提交新反馈", "查看反馈列表", "取消"))
					{
					case 1:
						ModBase.Feedback();
						break;
					case 2:
						ModBase.OpenWebsite("https://github.com/PCLPro/PCLPro/issues/");
						break;
					}
				}
			};
			_Closure_0024__._0024I12_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInNewThread((Action)action, null, (ThreadPriority)2);
	}

	public static void TryVote()
	{
		if (ModMain.MyMsgBox("是否要打开新功能投票网页？\r\n如果无法打开该网页，请尝试使用加速器或 VPN。", "新功能投票", "打开", "取消") != 2)
		{
			ModBase.OpenWebsite("https://github.com/Meloong-Git/PCL/discussions/categories/%E5%8A%9F%E8%83%BD%E6%8A%95%E7%A5%A8?discussions_q=category%3A%E5%8A%9F%E8%83%BD%E6%8A%95%E7%A5%A8+sort%3Adate_created");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageother/pageotherleft.xaml", (UriKind)2);
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
			ItemHelp = (MyListItem)target;
			break;
		case 3:
			ItemAbout = (MyListItem)target;
			break;
		case 4:
			ItemTest = (MyListItem)target;
			break;
		case 5:
			ItemFeedback = (MyListItem)target;
			break;
		case 6:
			ItemVote = (MyListItem)target;
			break;
		case 7:
			ItemLog = (MyListItem)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
