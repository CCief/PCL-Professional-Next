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
public class PageInstanceSavesLeft : MyPageLeft, IRefreshable, IComponentConnector
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

	public static string CurrentSave;

	private bool IsLoad;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemInfo")]
	private MyListItem _ItemInfo;

	[CompilerGenerated]
	[AccessedThroughProperty("ItemBackup")]
	private MyListItem _ItemBackup;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnOpenFolder")]
	private MyListItem _BtnOpenFolder;

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

	internal virtual MyListItem ItemInfo
	{
		[CompilerGenerated]
		get
		{
			return _ItemInfo;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemInfo = _ItemInfo;
			if (itemInfo != null)
			{
				itemInfo.Check -= obj;
			}
			_ItemInfo = value;
			itemInfo = _ItemInfo;
			if (itemInfo != null)
			{
				itemInfo.Check += obj;
			}
		}
	}

	internal virtual MyListItem ItemBackup
	{
		[CompilerGenerated]
		get
		{
			return _ItemBackup;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				PageCheck((MyListItem)a0, a1);
			};
			MyListItem itemBackup = _ItemBackup;
			if (itemBackup != null)
			{
				itemBackup.Check -= obj;
			}
			_ItemBackup = value;
			itemBackup = _ItemBackup;
			if (itemBackup != null)
			{
				itemBackup.Check += obj;
			}
		}
	}

	internal virtual MyListItem BtnOpenFolder
	{
		[CompilerGenerated]
		get
		{
			return _BtnOpenFolder;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyListItem.ClickEventHandler obj = BtnOpenFolder_Click;
			MyListItem btnOpenFolder = _BtnOpenFolder;
			if (btnOpenFolder != null)
			{
				btnOpenFolder.Click -= obj;
			}
			_BtnOpenFolder = value;
			btnOpenFolder = _BtnOpenFolder;
			if (btnOpenFolder != null)
			{
				btnOpenFolder.Click += obj;
			}
		}
	}

	public PageInstanceSavesLeft()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(Page_Loaded);
		PageID = FormMain.PageSubType.Default;
		IsLoad = false;
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
		case FormMain.PageSubType.Default:
			if (ModMain.FrmInstanceSavesInfo == null)
			{
				ModMain.FrmInstanceSavesInfo = new PageInstanceSavesInfo();
			}
			return ModMain.FrmInstanceSavesInfo;
		case FormMain.PageSubType.DownloadInstall:
			if (ModMain.FrmInstanceSavesBackup == null)
			{
				ModMain.FrmInstanceSavesBackup = new PageInstanceSavesBackup();
			}
			return ModMain.FrmInstanceSavesBackup;
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
		if (SubType == FormMain.PageSubType.DownloadInstall)
		{
			if (ModMain.FrmInstanceSavesBackup == null)
			{
				ModMain.FrmInstanceSavesBackup = new PageInstanceSavesBackup();
			}
			if (ItemBackup.Checked)
			{
				ModMain.FrmInstanceSavesBackup.Refresh();
			}
			else
			{
				ItemBackup.Checked = true;
			}
		}
		ModMain.Hint("刷新中……");
	}

	private void Page_Loaded(object sender, RoutedEventArgs e)
	{
		if (!IsLoad)
		{
			IsLoad = true;
		}
	}

	private void BtnOpenFolder_Click(object sender, MouseButtonEventArgs e)
	{
		((RoutedEventArgs)e).Handled = true;
		ModBase.OpenExplorer($"{CurrentSave}\\");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/pageinstancesaves/pageinstancesavesleft.xaml", (UriKind)2);
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
			ItemInfo = (MyListItem)target;
			break;
		case 3:
			ItemBackup = (MyListItem)target;
			break;
		case 4:
			BtnOpenFolder = (MyListItem)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
