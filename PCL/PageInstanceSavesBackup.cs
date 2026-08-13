using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.IO;
using PCL.Core.UI;
using PCL.Core.Utils.VersionControl;

namespace PCL;

[DesignerGenerated]
public class PageInstanceSavesBackup : MyPageRight, IRefreshable, IComponentConnector
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__5_002D0
	{
		public VersionData _0024VB_0024Local_item;

		public PageInstanceSavesBackup _0024VB_0024Me;

		public Action<ModLoader.LoaderTask<int, int>> _0024I1;

		public _Closure_0024__5_002D0(_Closure_0024__5_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_item = arg0._0024VB_0024Local_item;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R2(object a0, EventArgs a1)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			try
			{
				if (ModMain.MyMsgBox("确定要应用此备份吗？请确保当前的存档已完成备份或者十分确定不再使用！", "提示", "确定", "取消") == 2)
				{
					return;
				}
				ModMain.Hint("应用快照中，请勿执行其他操作！");
				List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("搜寻并应用文件", [SpecialName] (ModLoader.LoaderTask<int, int> load) =>
				{
					//IL_002b: Unknown result type (might be due to invalid IL or missing references)
					//IL_0030: Unknown result type (might be due to invalid IL or missing references)
					load.Progress = 0.2;
					using (SnapLiteVersionControl snapLiteVersionControl = new SnapLiteVersionControl(PageInstanceSavesLeft.CurrentSave))
					{
						TaskAwaiter awaiter = snapLiteVersionControl.ApplyPastVersion(_0024VB_0024Local_item.NodeId).GetAwaiter();
						awaiter.GetResult();
					}
					load.Progress = 1.0;
				}, null, (ThreadPriority)2));
				ModLoader.LoaderCombo<int> loaderCombo = new ModLoader.LoaderCombo<int>($"{_0024VB_0024Local_item.Name} - 备份应用", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
				loaderCombo.OnStateChanged = ModDownloadLib.LoaderStateChangedHintOnly;
				loaderCombo.Start(1);
				ModLoader.LoaderTaskbarAdd(loaderCombo);
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
				ModMain.FrmMain.BtnExtraDownload.Ribble();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "应用快照过程中出现错误", ModBase.LogLevel.Msgbox);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1(ModLoader.LoaderTask<int, int> load)
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			load.Progress = 0.2;
			using (SnapLiteVersionControl snapLiteVersionControl = new SnapLiteVersionControl(PageInstanceSavesLeft.CurrentSave))
			{
				TaskAwaiter awaiter = snapLiteVersionControl.ApplyPastVersion(_0024VB_0024Local_item.NodeId).GetAwaiter();
				awaiter.GetResult();
			}
			load.Progress = 1.0;
		}

		[SpecialName]
		internal void _Lambda_0024__R3(object a0, EventArgs a1)
		{
			_Lambda_0024__2();
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			try
			{
				_Closure_0024__5_002D1 arg = default(_Closure_0024__5_002D1);
				_Closure_0024__5_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__5_002D1(null)
				{
					_0024VB_0024NonLocal__0024VB_0024Closure_2 = this,
					_0024VB_0024Local_savePath = SystemDialogs.SelectSaveFile("选择保存备份导出的位置", $"{_0024VB_0024Local_item.Name}.zip", "压缩文件(*.zip)|*.zip", ModBase.ExePath)
				};
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Local_savePath))
				{
					return;
				}
				ModMain.Hint("快照导出中，请勿执行其他操作！");
				List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("制作压缩包", [SpecialName] (ModLoader.LoaderTask<int, int> load) =>
				{
					//IL_0036: Unknown result type (might be due to invalid IL or missing references)
					//IL_003b: Unknown result type (might be due to invalid IL or missing references)
					load.Progress = 0.2;
					using (SnapLiteVersionControl snapLiteVersionControl = new SnapLiteVersionControl(PageInstanceSavesLeft.CurrentSave))
					{
						TaskAwaiter awaiter = snapLiteVersionControl.Export(CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.NodeId, CS_0024_003C_003E8__locals0._0024VB_0024Local_savePath).GetAwaiter();
						awaiter.GetResult();
					}
					load.Progress = 1.0;
				}, null, (ThreadPriority)2));
				ModLoader.LoaderCombo<int> loaderCombo = new ModLoader.LoaderCombo<int>($"{_0024VB_0024Local_item.Name} - 导出备份", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
				loaderCombo.OnStateChanged = ModDownloadLib.LoaderStateChangedHintOnly;
				loaderCombo.Start(1);
				ModLoader.LoaderTaskbarAdd(loaderCombo);
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
				ModMain.FrmMain.BtnExtraDownload.Ribble();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "备份导出过程中出现错误", ModBase.LogLevel.Msgbox);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R4(object a0, EventArgs a1)
		{
			_Lambda_0024__4();
		}

		[SpecialName]
		internal void _Lambda_0024__4()
		{
			try
			{
				if (ModMain.MyMsgBox(string.Format("你确定要删除备份 {0} 吗？{1}描述：{2}{3}创建时间：{4}", new object[] { _0024VB_0024Local_item.Name, "\r\n", _0024VB_0024Local_item.Desc, "\r\n", _0024VB_0024Local_item.Created }), "删除确认", "确认", "取消") != 2)
				{
					using (SnapLiteVersionControl snapLiteVersionControl = new SnapLiteVersionControl(PageInstanceSavesLeft.CurrentSave))
					{
						snapLiteVersionControl.DeleteVersion(_0024VB_0024Local_item.NodeId);
					}
					_0024VB_0024Me.RefreshList();
					ModMain.Hint("已删除！", ModMain.HintType.Finish);
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "执行删除任务失败");
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R5(object a0, EventArgs a1)
		{
			_Lambda_0024__5();
		}

		[SpecialName]
		internal void _Lambda_0024__5()
		{
			try
			{
				List<FileVersionObjects> nodeObjects;
				using (SnapLiteVersionControl snapLiteVersionControl = new SnapLiteVersionControl(PageInstanceSavesLeft.CurrentSave))
				{
					nodeObjects = snapLiteVersionControl.GetNodeObjects(_0024VB_0024Local_item.NodeId);
				}
				long length = Enumerable.Sum(Enumerable.Select<FileVersionObjects, long>((System.Collections.Generic.IEnumerable<FileVersionObjects>)nodeObjects, (Func<FileVersionObjects, long>)([SpecialName] (FileVersionObjects x) => x.Length)));
				ModMain.MyMsgBox(string.Format("描述: {0}\n创建时间: {1}\n存档大小: {2} ({3} 个对象)", new object[4]
				{
					_0024VB_0024Local_item.Desc,
					_0024VB_0024Local_item.Created,
					ByteStream.GetReadableLength(length),
					nodeObjects.Count
				}), _0024VB_0024Local_item.Name);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "执行删除任务失败");
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__5_002D1
	{
		public string _0024VB_0024Local_savePath;

		public _Closure_0024__5_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__5_002D1(_Closure_0024__5_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_savePath = arg0._0024VB_0024Local_savePath;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__3(ModLoader.LoaderTask<int, int> load)
		{
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			load.Progress = 0.2;
			using (SnapLiteVersionControl snapLiteVersionControl = new SnapLiteVersionControl(PageInstanceSavesLeft.CurrentSave))
			{
				TaskAwaiter awaiter = snapLiteVersionControl.Export(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.NodeId, _0024VB_0024Local_savePath).GetAwaiter();
				awaiter.GetResult();
			}
			load.Progress = 1.0;
		}
	}

	private bool _loaded;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnClean")]
	private MyIconTextButton _BtnClean;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnCreate")]
	private MyIconTextButton _BtnCreate;

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

	internal virtual MyIconTextButton BtnClean
	{
		[CompilerGenerated]
		get
		{
			return _BtnClean;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnClean_Click();
			};
			MyIconTextButton btnClean = _BtnClean;
			if (btnClean != null)
			{
				btnClean.Click -= obj;
			}
			_BtnClean = value;
			btnClean = _BtnClean;
			if (btnClean != null)
			{
				btnClean.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnCreate
	{
		[CompilerGenerated]
		get
		{
			return _BtnCreate;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnCreate_Click();
			};
			MyIconTextButton btnCreate = _BtnCreate;
			if (btnCreate != null)
			{
				btnCreate.Click -= obj;
			}
			_BtnCreate = value;
			btnCreate = _BtnCreate;
			if (btnCreate != null)
			{
				btnCreate.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanDisplay")]
	internal virtual MyCard PanDisplay
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanList")]
	internal virtual StackPanel PanList
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanEmpty")]
	internal virtual MyCard PanEmpty
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageInstanceSavesBackup()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Init();
		});
		InitializeComponent();
	}

	private void IRefreshable_Refresh()
	{
		Refresh();
	}

	void IRefreshable.Refresh()
	{
		//ILSpy generated this explicit interface implementation from .override directive in IRefreshable_Refresh
		this.IRefreshable_Refresh();
	}

	public void Refresh()
	{
		RefreshList();
	}

	private void Init()
	{
		((ScrollViewer)PanBack).ScrollToHome();
		RefreshList();
		_loaded = true;
		_ = _loaded;
	}

	private void RefreshList()
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			((Panel)PanList).Children.Clear();
			List<VersionData> versions;
			using (SnapLiteVersionControl snapLiteVersionControl = new SnapLiteVersionControl(PageInstanceSavesLeft.CurrentSave))
			{
				versions = snapLiteVersionControl.GetVersions();
				if (Enumerable.Any<VersionData>((System.Collections.Generic.IEnumerable<VersionData>)versions))
				{
					((UIElement)PanDisplay).Visibility = (Visibility)0;
					((UIElement)PanEmpty).Visibility = (Visibility)2;
				}
				else
				{
					((UIElement)PanDisplay).Visibility = (Visibility)2;
					((UIElement)PanEmpty).Visibility = (Visibility)0;
				}
			}
			if (versions == null || !Enumerable.Any<VersionData>((System.Collections.Generic.IEnumerable<VersionData>)versions))
			{
				return;
			}
			System.Collections.Generic.IEnumerator<VersionData> enumerator = default(System.Collections.Generic.IEnumerator<VersionData>);
			try
			{
				enumerator = versions.GetEnumerator();
				_Closure_0024__5_002D0 closure_0024__5_002D = default(_Closure_0024__5_002D0);
				while (enumerator.MoveNext())
				{
					closure_0024__5_002D = new _Closure_0024__5_002D0(closure_0024__5_002D);
					closure_0024__5_002D._0024VB_0024Me = this;
					closure_0024__5_002D._0024VB_0024Local_item = enumerator.Current;
					MyListItem myListItem = new MyListItem();
					myListItem.Title = closure_0024__5_002D._0024VB_0024Local_item.Name;
					myListItem.Info = closure_0024__5_002D._0024VB_0024Local_item.Desc;
					myListItem.Tags = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)new string[] { closure_0024__5_002D._0024VB_0024Local_item.Created.ToString() });
					MyListItem myListItem2 = myListItem;
					MyIconButton obj = new MyIconButton
					{
						Logo = "M213.333333 65.386667a85.333333 85.333333 0 0 1 43.904 12.16L859.370667 438.826667a85.333333 85.333333 0 0 1 0 146.346666L257.237333 946.453333A85.333333 85.333333 0 0 1 128 873.28V150.72a85.333333 85.333333 0 0 1 85.333333-85.333333z m0 64a21.333333 21.333333 0 0 0-21.184 18.837333L192 150.72v722.56a21.333333 21.333333 0 0 0 30.101333 19.456l2.197334-1.152L826.453333 530.282667a21.333333 21.333333 0 0 0 2.048-35.178667l-2.048-1.386667L224.298667 132.416A21.333333 21.333333 0 0 0 213.333333 129.386667z"
					};
					((FrameworkElement)obj).ToolTip = "回到到此快照";
					MyIconButton myIconButton = obj;
					myIconButton.Click += closure_0024__5_002D._Lambda_0024__R2;
					MyIconButton obj2 = new MyIconButton
					{
						Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z"
					};
					((FrameworkElement)obj2).ToolTip = "导出到压缩包";
					MyIconButton myIconButton2 = obj2;
					myIconButton2.Click += closure_0024__5_002D._Lambda_0024__R3;
					MyIconButton obj3 = new MyIconButton
					{
						Logo = "M520.192 0C408.43 0 317.44 82.87 313.563 186.734H52.736c-29.038 0-52.663 21.943-52.663 49.079s23.625 49.152 52.663 49.152h58.075v550.473c0 103.35 75.118 187.757 167.717 187.757h472.43c92.599 0 167.716-83.894 167.716-187.757V285.477h52.59c29.038 0 52.59-21.943 52.663-49.08-0.073-27.135-23.625-49.151-52.663-49.151H726.235C723.237 83.017 631.955 0 520.192 0zM404.846 177.957c3.803-50.03 50.176-89.015 107.447-89.015 57.197 0 103.57 38.985 106.788 89.015H404.92zM284.379 933.669c-33.353 0-69.997-39.351-69.997-95.525v-549.01H833.39v549.522c0 56.247-36.645 95.525-69.998 95.525H284.379v-0.512z M357.23 800.695a48.274 48.274 0 0 0 47.616-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.69 49.006V751.69c0 27.282 20.846 49.006 47.617 49.006z m166.62 0a48.274 48.274 0 0 0 47.688-49.006V471.7a48.274 48.274 0 0 0-47.689-49.08 48.274 48.274 0 0 0-47.543 49.006V751.69c0 27.282 21.431 49.006 47.543 49.006z m142.92 0a48.274 48.274 0 0 0 47.543-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.616 49.006V751.69c0 27.282 20.773 49.006 47.543 49.006z"
					};
					((FrameworkElement)obj3).ToolTip = "删除";
					MyIconButton myIconButton3 = obj3;
					myIconButton3.Click += closure_0024__5_002D._Lambda_0024__R4;
					MyIconButton obj4 = new MyIconButton
					{
						Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
					};
					((FrameworkElement)obj4).ToolTip = "信息";
					MyIconButton myIconButton4 = obj4;
					myIconButton4.Click += closure_0024__5_002D._Lambda_0024__R5;
					myListItem2.Buttons = new MyIconButton[] { myIconButton3, myIconButton2, myIconButton4, myIconButton };
					((Panel)PanList).Children.Add((UIElement)(object)myListItem2);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "获取备份信息失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnCreate_Click()
	{
		try
		{
			string text = ModMain.MyMsgBoxInput("请输入名称", "", $"{System.DateTime.Now:yyyy/dd/MM-HH:mm:ss}");
			if (text == null)
			{
				return;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text = null;
			}
			if (ModMain.MyMsgBox("备份功能不具备热备份功能，请确你没有在使用存档内的任何文件！", "请注意！", "继续", "返回") == 2)
			{
				return;
			}
			((UIElement)BtnCreate).IsEnabled = false;
			ModMain.Hint("开始备份任务，请勿执行其他操作！");
			List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("搜寻并制作备份", [SpecialName] (ModLoader.LoaderTask<int, int> load) =>
			{
				//IL_0027: Unknown result type (might be due to invalid IL or missing references)
				//IL_002c: Unknown result type (might be due to invalid IL or missing references)
				//IL_005c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0067: Expected O, but got Unknown
				load.Progress = 0.2;
				using (SnapLiteVersionControl snapLiteVersionControl = new SnapLiteVersionControl(PageInstanceSavesLeft.CurrentSave))
				{
					snapLiteVersionControl.CreateNewVersion(text).GetAwaiter().GetResult();
				}
				load.Progress = 1.0;
				ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
				{
					RefreshList();
				}));
			}, null, (ThreadPriority)2));
			ModLoader.LoaderCombo<int> loaderCombo = new ModLoader.LoaderCombo<int>($"{text} - 制作备份", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
			loaderCombo.OnStateChanged = ModDownloadLib.LoaderStateChangedHintOnly;
			loaderCombo.Start(1);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
			((UIElement)BtnCreate).IsEnabled = true;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "备份过程中出现错误", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnClean_Click()
	{
		if (ModMain.MyMsgBox("此功能可以清理备份文件中已不再需要的文件，建议在发生备份删除后使用。", "确定使用吗？", "确定", "返回") == 2)
		{
			return;
		}
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("寻找并清理备份文件", [SpecialName] (ModLoader.LoaderTask<int, int> load) =>
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			load.Progress = 0.2;
			using (SnapLiteVersionControl snapLiteVersionControl = new SnapLiteVersionControl(PageInstanceSavesLeft.CurrentSave))
			{
				TaskAwaiter awaiter = snapLiteVersionControl.CleanUnrecordObjects().GetAwaiter();
				awaiter.GetResult();
			}
			load.Progress = 1.0;
		}, null, (ThreadPriority)2));
		ModLoader.LoaderCombo<int> loaderCombo = new ModLoader.LoaderCombo<int>($"{ModBase.GetFolderNameFromPath(PageInstanceSavesLeft.CurrentSave)} - 备份清理", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
		loaderCombo.OnStateChanged = ModDownloadLib.LoaderStateChangedHintOnly;
		loaderCombo.Start(1);
		ModLoader.LoaderTaskbarAdd(loaderCombo);
		ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
		ModMain.FrmMain.BtnExtraDownload.Ribble();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/pageinstancesaves/pageinstancesavesbackup.xaml", (UriKind)2);
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
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanMain = (StackPanel)target;
			break;
		case 3:
			BtnClean = (MyIconTextButton)target;
			break;
		case 4:
			BtnCreate = (MyIconTextButton)target;
			break;
		case 5:
			PanDisplay = (MyCard)target;
			break;
		case 6:
			PanList = (StackPanel)target;
			break;
		case 7:
			PanEmpty = (MyCard)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
