using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;

namespace PCL;

[DesignerGenerated]
public class PageInstanceSaves : MyPageRight, IRefreshable, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action _0024I14_002D1;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__14_002D1()
		{
			ModMain.FrmInstanceSaves?.RefreshUI();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__11_002D0
	{
		public string _0024VB_0024Local_tmpCurFolder;

		public MyListItem _0024VB_0024Local_worldItem;

		public PageInstanceSaves _0024VB_0024Me;

		public Action _0024I4;

		public Action _0024I3;

		public _Closure_0024__11_002D0(_Closure_0024__11_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_tmpCurFolder = arg0._0024VB_0024Local_tmpCurFolder;
				_0024VB_0024Local_worldItem = arg0._0024VB_0024Local_worldItem;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R1(object a0, MouseButtonEventArgs a1)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			ModMain.FrmMain.PageChange(new FormMain.PageStackData
			{
				Page = FormMain.PageType.VersionSaves,
				Additional = _0024VB_0024Local_tmpCurFolder
			});
		}

		[SpecialName]
		internal void _Lambda_0024__R2(object a0, EventArgs a1)
		{
			_Lambda_0024__1();
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			ModBase.OpenExplorer(_0024VB_0024Local_tmpCurFolder);
		}

		[SpecialName]
		internal void _Lambda_0024__R3(object a0, EventArgs a1)
		{
			_Lambda_0024__2();
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Expected O, but got Unknown
			//IL_0040: Expected O, but got Unknown
			((UIElement)_0024VB_0024Local_worldItem).IsEnabled = false;
			_0024VB_0024Local_worldItem.Info = "删除中……";
			Action action;
			if (_0024I3 != null)
			{
				action = _0024I3;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					//IL_0031: Unknown result type (might be due to invalid IL or missing references)
					//IL_0036: Unknown result type (might be due to invalid IL or missing references)
					//IL_0038: Expected O, but got Unknown
					//IL_003d: Expected O, but got Unknown
					try
					{
						FileSystem.DeleteDirectory(_0024VB_0024Local_tmpCurFolder, (UIOption)2, (RecycleOption)3);
						ModMain.Hint("已将存档移至回收站！");
						Action action2;
						if (_0024I4 != null)
						{
							action2 = _0024I4;
						}
						else
						{
							Action val3 = [SpecialName] () =>
							{
								_0024VB_0024Me.RemoveItem(_0024VB_0024Local_worldItem);
							};
							Action val4 = val3;
							_0024I4 = val3;
							action2 = val4;
						}
						ModBase.RunInUiWait(action2);
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "删除存档失败！", ModBase.LogLevel.Hint);
						ProjectData.ClearProjectError();
					}
				};
				Action val2 = val;
				_0024I3 = val;
				action = val2;
			}
			ModBase.RunInNewThread(action, null, (ThreadPriority)2);
		}

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Expected O, but got Unknown
			//IL_003d: Expected O, but got Unknown
			try
			{
				FileSystem.DeleteDirectory(_0024VB_0024Local_tmpCurFolder, (UIOption)2, (RecycleOption)3);
				ModMain.Hint("已将存档移至回收站！");
				Action action;
				if (_0024I4 != null)
				{
					action = _0024I4;
				}
				else
				{
					Action val = [SpecialName] () =>
					{
						_0024VB_0024Me.RemoveItem(_0024VB_0024Local_worldItem);
					};
					Action val2 = val;
					_0024I4 = val;
					action = val2;
				}
				ModBase.RunInUiWait(action);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "删除存档失败！", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__4()
		{
			_0024VB_0024Me.RemoveItem(_0024VB_0024Local_worldItem);
		}

		[SpecialName]
		internal void _Lambda_0024__R4(object a0, EventArgs a1)
		{
			_Lambda_0024__5();
		}

		[SpecialName]
		internal void _Lambda_0024__5()
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			try
			{
				if (Directory.Exists(_0024VB_0024Local_tmpCurFolder))
				{
					StringCollection val = new StringCollection();
					val.Add(_0024VB_0024Local_tmpCurFolder);
					Clipboard.SetFileDropList(val);
					ModMain.Hint("已复制存档文件夹到剪贴板！");
					ModMain.Hint("注意！在粘贴之前进行删除操作会导致存档丢失！");
				}
				else
				{
					ModMain.Hint("存档文件夹不存在！");
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "复制失败……", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R5(object a0, EventArgs a1)
		{
			_Lambda_0024__6();
		}

		[SpecialName]
		internal void _Lambda_0024__6()
		{
			ModMain.FrmMain.PageChange(new FormMain.PageStackData
			{
				Page = FormMain.PageType.VersionSaves,
				Additional = _0024VB_0024Local_tmpCurFolder
			});
		}

		[SpecialName]
		internal void _Lambda_0024__R6(object a0, EventArgs a1)
		{
			_Lambda_0024__7();
		}

		[SpecialName]
		internal void _Lambda_0024__7()
		{
			string fileNameFromPath = ModBase.GetFileNameFromPath(_0024VB_0024Local_tmpCurFolder);
			ModLaunch.McLaunchStart(new ModLaunch.McLaunchOptions
			{
				WorldName = fileNameFromPath
			});
			ModMain.FrmMain.PageChange(new FormMain.PageStackData
			{
				Page = FormMain.PageType.Launch
			});
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__14_002D0
	{
		public StringCollection _0024VB_0024Local_files;

		public PageInstanceSaves _0024VB_0024Me;

		public _Closure_0024__14_002D0(_Closure_0024__14_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_files = arg0._0024VB_0024Local_files;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R7(ModLoader.LoaderTask<int, int> a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Expected O, but got Unknown
			int num = 0;
			StringEnumerator enumerator = _0024VB_0024Local_files.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				try
				{
					if (Directory.Exists(current))
					{
						if (Directory.Exists(_0024VB_0024Me.WorldPath + ModBase.GetFolderNameFromPath(current)))
						{
							ModMain.Hint("发现同名文件夹，无法粘贴：" + ModBase.GetFolderNameFromPath(current));
							continue;
						}
						ModBase.CopyDirectory(current, _0024VB_0024Me.WorldPath + ModBase.GetFolderNameFromPath(current));
						num = checked(num + 1);
					}
					else
					{
						ModMain.Hint("源文件夹不存在或源目标不是文件夹");
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "粘贴存档文件夹失败", ModBase.LogLevel.Hint);
					ProjectData.ClearProjectError();
				}
			}
			if (num > 0)
			{
				ModMain.Hint("已粘贴 " + Conversions.ToString(num) + " 个文件夹", ModMain.HintType.Finish);
			}
			object action;
			if (_Closure_0024__._0024I14_002D1 != null)
			{
				action = _Closure_0024__._0024I14_002D1;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					ModMain.FrmInstanceSaves?.RefreshUI();
				};
				_Closure_0024__._0024I14_002D1 = val;
				action = (object)val;
			}
			ModBase.RunInUi((Action)action);
		}
	}

	private object QuickPlayFeature;

	private bool IsLoad;

	private List<string> saveFolders;

	private string WorldPath;

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
	[field: AccessedThroughProperty("PanNoWorld")]
	internal virtual MyCard PanNoWorld
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanContent")]
	internal virtual StackPanel PanContent
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanCard")]
	internal virtual MyCard PanCard
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

	public PageInstanceSaves()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageSetupLaunch_Loaded);
		QuickPlayFeature = false;
		IsLoad = false;
		saveFolders = new List<string>();
		InitializeComponent();
	}

	private void RefreshSelf()
	{
		Refresh();
		CheckQuickPlay();
	}

	void IRefreshable.Refresh()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RefreshSelf
		this.RefreshSelf();
	}

	public static void Refresh()
	{
		if (ModMain.FrmInstanceSaves != null)
		{
			ModMain.FrmInstanceSaves.Reload();
		}
		ModMain.FrmInstanceLeft.ItemWorld.Checked = true;
		ModMain.Hint("正在刷新……", ModMain.HintType.Info, Log: false);
	}

	private void PageSetupLaunch_Loaded(object sender, RoutedEventArgs e)
	{
		((ScrollViewer)PanBack).ScrollToHome();
		WorldPath = PageInstanceLeft.Instance.PathIndie + "saves\\";
		if (!Directory.Exists(WorldPath))
		{
			Directory.CreateDirectory(WorldPath);
		}
		Reload();
		if (!IsLoad)
		{
			IsLoad = true;
			CheckQuickPlay();
		}
	}

	public void Reload()
	{
		checked
		{
			ModAnimation.AniControlEnabled++;
			((ScrollViewer)PanBack).ScrollToHome();
			LoadFileList();
			ModAnimation.AniControlEnabled--;
		}
	}

	private void RefreshUI()
	{
		PanCard.Title = $"存档列表 ({saveFolders.Count})";
		if (saveFolders.Count.Equals(0))
		{
			((UIElement)PanNoWorld).Visibility = (Visibility)0;
			((UIElement)PanContent).Visibility = (Visibility)2;
			((UIElement)PanNoWorld).UpdateLayout();
		}
		else
		{
			((UIElement)PanNoWorld).Visibility = (Visibility)2;
			((UIElement)PanContent).Visibility = (Visibility)0;
			((UIElement)PanContent).UpdateLayout();
		}
	}

	private void CheckQuickPlay()
	{
		try
		{
			ModLaunch.LaunchArgument launchArgument = new ModLaunch.LaunchArgument(PageInstanceLeft.Instance);
			QuickPlayFeature = RuntimeHelpers.GetObjectValue(launchArgument.HasArguments("--quickPlaySingleplayer"));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "检查存档快捷启动失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private void LoadFileList()
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ModBase.Log("[World] 刷新存档文件");
			saveFolders.Clear();
			saveFolders = Enumerable.ToList<string>(Directory.EnumerateDirectories(WorldPath));
			if (ModBase.ModeDebug)
			{
				ModBase.Log("[World] 共发现 " + Conversions.ToString(saveFolders.Count) + " 个存档文件夹", ModBase.LogLevel.Debug);
			}
			((Panel)PanList).Children.Clear();
			CheckQuickPlay();
			if (ModBase.ModeDebug)
			{
				if (Conversions.ToBoolean(QuickPlayFeature))
				{
					ModBase.Log("[World] 该实例支持存档快捷启动", ModBase.LogLevel.Debug);
				}
				else
				{
					ModBase.Log("[World] 该实例不支持存档快捷启动", ModBase.LogLevel.Debug);
				}
			}
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = saveFolders.GetEnumerator();
				_Closure_0024__11_002D0 closure_0024__11_002D = default(_Closure_0024__11_002D0);
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					closure_0024__11_002D = new _Closure_0024__11_002D0(closure_0024__11_002D);
					closure_0024__11_002D._0024VB_0024Me = this;
					string text = current + "\\icon.png";
					closure_0024__11_002D._0024VB_0024Local_tmpCurFolder = current;
					if (File.Exists(text))
					{
						string text2 = $"{PageInstanceLeft.Instance.Path}PCL\\ImgCache\\{ModBase.GetStringMD5(text)}.png";
						ModBase.CopyFile(text, text2);
						text = text2;
					}
					else
					{
						text = ModBase.PathImage + "Icons/NoIcon.png";
					}
					closure_0024__11_002D._0024VB_0024Local_worldItem = new MyListItem
					{
						Logo = text,
						Title = ModBase.GetFolderNameFromPath(current),
						Info = string.Format("创建时间：{0}，最后修改时间：{1}", (object)Directory.GetCreationTime(current).ToString("yyyy'/'MM'/'dd"), (object)Directory.GetLastWriteTime(current).ToString("yyyy'/'MM'/'dd")),
						Type = MyListItem.CheckType.Clickable
					};
					closure_0024__11_002D._0024VB_0024Local_worldItem.Click += closure_0024__11_002D._Lambda_0024__R1;
					MyIconButton obj = new MyIconButton
					{
						Logo = "M889.018182 418.909091H884.363636V316.509091a93.090909 93.090909 0 0 0-99.607272-89.832727h-302.545455l-93.090909-76.334546A46.545455 46.545455 0 0 0 358.865455 139.636364H146.152727A93.090909 93.090909 0 0 0 46.545455 229.469091V837.818182a46.545455 46.545455 0 0 0 46.545454 46.545454 46.545455 46.545455 0 0 0 16.756364-3.258181 109.381818 109.381818 0 0 0 25.134545 3.258181h586.472727a85.178182 85.178182 0 0 0 87.04-63.301818l163.374546-302.545454a46.545455 46.545455 0 0 0 5.585454-21.876364A82.385455 82.385455 0 0 0 889.018182 418.909091z m-744.727273-186.181818h198.283636l93.09091 76.334545a46.545455 46.545455 0 0 0 29.323636 10.705455h319.301818a12.101818 12.101818 0 0 1 6.516364 0V418.909091H302.545455a85.178182 85.178182 0 0 0-87.04 63.301818L139.636364 622.778182V232.727273a19.549091 19.549091 0 0 1 6.516363 0z m578.094546 552.029091a27.461818 27.461818 0 0 0-2.792728 6.516363H154.530909l147.083636-272.290909a27.461818 27.461818 0 0 0 2.792728-6.981818h565.061818z"
					};
					((FrameworkElement)obj).ToolTip = "打开";
					MyIconButton myIconButton = obj;
					myIconButton.Click += closure_0024__11_002D._Lambda_0024__R2;
					MyIconButton obj2 = new MyIconButton
					{
						Logo = "M520.192 0C408.43 0 317.44 82.87 313.563 186.734H52.736c-29.038 0-52.663 21.943-52.663 49.079s23.625 49.152 52.663 49.152h58.075v550.473c0 103.35 75.118 187.757 167.717 187.757h472.43c92.599 0 167.716-83.894 167.716-187.757V285.477h52.59c29.038 0 52.59-21.943 52.663-49.08-0.073-27.135-23.625-49.151-52.663-49.151H726.235C723.237 83.017 631.955 0 520.192 0zM404.846 177.957c3.803-50.03 50.176-89.015 107.447-89.015 57.197 0 103.57 38.985 106.788 89.015H404.92zM284.379 933.669c-33.353 0-69.997-39.351-69.997-95.525v-549.01H833.39v549.522c0 56.247-36.645 95.525-69.998 95.525H284.379v-0.512z M357.23 800.695a48.274 48.274 0 0 0 47.616-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.69 49.006V751.69c0 27.282 20.846 49.006 47.617 49.006z m166.62 0a48.274 48.274 0 0 0 47.688-49.006V471.7a48.274 48.274 0 0 0-47.689-49.08 48.274 48.274 0 0 0-47.543 49.006V751.69c0 27.282 21.431 49.006 47.543 49.006z m142.92 0a48.274 48.274 0 0 0 47.543-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.616 49.006V751.69c0 27.282 20.773 49.006 47.543 49.006z"
					};
					((FrameworkElement)obj2).ToolTip = "删除";
					MyIconButton myIconButton2 = obj2;
					myIconButton2.Click += closure_0024__11_002D._Lambda_0024__R3;
					MyIconButton obj3 = new MyIconButton
					{
						Logo = "M394.666667 106.666667h448a74.666667 74.666667 0 0 1 74.666666 74.666666v448a74.666667 74.666667 0 0 1-74.666666 74.666667H394.666667a74.666667 74.666667 0 0 1-74.666667-74.666667V181.333333a74.666667 74.666667 0 0 1 74.666667-74.666666z m0 64a10.666667 10.666667 0 0 0-10.666667 10.666666v448a10.666667 10.666667 0 0 0 10.666667 10.666667h448a10.666667 10.666667 0 0 0 10.666666-10.666667V181.333333a10.666667 10.666667 0 0 0-10.666666-10.666666H394.666667z m245.333333 597.333333a32 32 0 0 1 64 0v74.666667a74.666667 74.666667 0 0 1-74.666667 74.666666H181.333333a74.666667 74.666667 0 0 1-74.666666-74.666666V394.666667a74.666667 74.666667 0 0 1 74.666666-74.666667h74.666667a32 32 0 0 1 0 64h-74.666667a10.666667 10.666667 0 0 0-10.666666 10.666667v448a10.666667 10.666667 0 0 0 10.666666 10.666666h448a10.666667 10.666667 0 0 0 10.666667-10.666666v-74.666667z"
					};
					((FrameworkElement)obj3).ToolTip = "复制";
					MyIconButton myIconButton3 = obj3;
					myIconButton3.Click += closure_0024__11_002D._Lambda_0024__R4;
					MyIconButton obj4 = new MyIconButton
					{
						Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
					};
					((FrameworkElement)obj4).ToolTip = "详情";
					MyIconButton myIconButton4 = obj4;
					myIconButton4.Click += closure_0024__11_002D._Lambda_0024__R5;
					MyIconButton obj5 = new MyIconButton
					{
						Logo = "M213.333333 65.386667a85.333333 85.333333 0 0 1 43.904 12.16L859.370667 438.826667a85.333333 85.333333 0 0 1 0 146.346666L257.237333 946.453333A85.333333 85.333333 0 0 1 128 873.28V150.72a85.333333 85.333333 0 0 1 85.333333-85.333333z m0 64a21.333333 21.333333 0 0 0-21.184 18.837333L192 150.72v722.56a21.333333 21.333333 0 0 0 30.101333 19.456l2.197334-1.152L826.453333 530.282667a21.333333 21.333333 0 0 0 2.048-35.178667l-2.048-1.386667L224.298667 132.416A21.333333 21.333333 0 0 0 213.333333 129.386667z"
					};
					((FrameworkElement)obj5).ToolTip = "快捷启动";
					MyIconButton myIconButton5 = obj5;
					myIconButton5.Click += closure_0024__11_002D._Lambda_0024__R6;
					if (Conversions.ToBoolean(QuickPlayFeature))
					{
						closure_0024__11_002D._0024VB_0024Local_worldItem.Buttons = new MyIconButton[] { myIconButton, myIconButton2, myIconButton3, myIconButton4, myIconButton5 };
					}
					else
					{
						closure_0024__11_002D._0024VB_0024Local_worldItem.Buttons = new MyIconButton[] { myIconButton, myIconButton2, myIconButton3, myIconButton4 };
					}
					((Panel)PanList).Children.Add((UIElement)(object)closure_0024__11_002D._0024VB_0024Local_worldItem);
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
			ModBase.Log(ex2, "载入存档列表失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
		RefreshUI();
	}

	private void RemoveItem(MyListItem item)
	{
		if (((Panel)PanList).Children.IndexOf((UIElement)(object)item) != -1)
		{
			((Panel)PanList).Children.Remove((UIElement)(object)item);
			RefreshUI();
		}
	}

	private void BtnOpenFolder_Click(object sender, MouseButtonEventArgs e)
	{
		ModBase.OpenExplorer(WorldPath);
	}

	private void BtnPaste_Click(object sender, MouseButtonEventArgs e)
	{
		_Closure_0024__14_002D0 arg = default(_Closure_0024__14_002D0);
		_Closure_0024__14_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__14_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_files = Clipboard.GetFileDropList();
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("Copy saves", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
		{
			CS_0024_003C_003E8__locals0._Lambda_0024__0();
		}, null, (ThreadPriority)2));
		ModLoader.LoaderCombo<int> loaderCombo = new ModLoader.LoaderCombo<int>($"{PageInstanceLeft.Instance.Name} - 复制存档", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/pageinstancesaves.xaml", (UriKind)2);
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanNoWorld = (MyCard)target;
			break;
		case 3:
			PanContent = (StackPanel)target;
			break;
		case 4:
			PanCard = (MyCard)target;
			break;
		case 5:
			PanList = (StackPanel)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
