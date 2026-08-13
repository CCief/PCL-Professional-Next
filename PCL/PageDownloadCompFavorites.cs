using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.UI;

namespace PCL;

[DesignerGenerated]
public class PageDownloadCompFavorites : MyPageRight, IComponentConnector
{
	public class CompListItemContainer
	{
		[field: CompilerGenerated]
		public MyCard Card
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public StackPanel ContentList
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string Title
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public int CompType
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<CompListItemContainer, bool> _0024I15_002D1;

		public static Func<CompListItemContainer, bool> _0024I15_002D2;

		public static Func<MyListItem, string> _0024I24_002D0;

		public static VB_0024AnonymousDelegate_16<List<List<string>>, List<string>> _0024I25_002D1;

		public static Func<ModComp.CompFile, List<string>> _0024I25_002D4;

		public static ModBase.ComparisonBoolean<ModComp.CompFile> _0024I25_002D7;

		public static Func<MyListItem, string> _0024I25_002D8;

		public static Func<MyListItem, bool> _0024I26_002D0;

		public static Func<ModComp.CompProject, string> _0024I31_002D0;

		public static Func<ModBase.SearchEntry<MyListItem>, MyListItem> _0024I36_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal bool _Lambda_0024__15_002D1(CompListItemContainer e)
		{
			return e.CompType.Equals(-1);
		}

		[SpecialName]
		internal bool _Lambda_0024__15_002D2(CompListItemContainer e)
		{
			return e.CompType.Equals(-1);
		}

		[SpecialName]
		internal string _Lambda_0024__24_002D0(MyListItem i)
		{
			return ((ModComp.CompProject)((FrameworkElement)i).Tag).Id;
		}

		[SpecialName]
		internal List<string> _Lambda_0024__25_002D1(List<List<string>> Ls)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			List<string> val = new List<string>();
			System.Collections.Generic.IEnumerator<List<string>> enumerator = default(System.Collections.Generic.IEnumerator<List<string>>);
			try
			{
				enumerator = Ls.GetEnumerator();
				while (enumerator.MoveNext())
				{
					List<string> current = enumerator.Current;
					val.AddRange((System.Collections.Generic.IEnumerable<string>)current);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			return Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val));
		}

		[SpecialName]
		internal List<string> _Lambda_0024__25_002D4(ModComp.CompFile i)
		{
			return i.GameVersions;
		}

		[SpecialName]
		internal bool _Lambda_0024__25_002D7(ModComp.CompFile a, ModComp.CompFile b)
		{
			return System.DateTime.Compare(a.ReleaseDate, b.ReleaseDate) > 0;
		}

		[SpecialName]
		internal string _Lambda_0024__25_002D8(MyListItem i)
		{
			return ((ModComp.CompProject)((FrameworkElement)i).Tag).Id;
		}

		[SpecialName]
		internal bool _Lambda_0024__26_002D0(MyListItem e)
		{
			return e.Checked;
		}

		[SpecialName]
		internal string _Lambda_0024__31_002D0(ModComp.CompProject i)
		{
			return i.Id;
		}

		[SpecialName]
		internal MyListItem _Lambda_0024__36_002D0(ModBase.SearchEntry<MyListItem> r)
		{
			return r.Item;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__15_002D0
	{
		public CompListItemContainer _0024VB_0024Local_item;

		public _Closure_0024__15_002D0(_Closure_0024__15_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_item = arg0._0024VB_0024Local_item;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(MyListItem e)
		{
			return ((ModComp.CompProject)((FrameworkElement)e).Tag).Type == (ModComp.CompType)_0024VB_0024Local_item.CompType;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__25_002D0
	{
		public List<List<ModComp.CompFile>> _0024VB_0024Local_AllFiles;

		public int _0024VB_0024Local_FinishedTasks;

		public List<string> _0024VB_0024Local_SuitVersion;

		public object _0024VB_0024Local_SelectedVersion;

		public ModLoader.LoaderTask<List<string>, List<ModNet.NetFile>> _0024VB_0024Local_Ts;

		public string _0024VB_0024Local_SelectedVersionStr;

		public _Closure_0024__25_002D2 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public Func<ModComp.CompFile, bool> _0024I6;

		public _Closure_0024__25_002D0(_Closure_0024__25_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_AllFiles = arg0._0024VB_0024Local_AllFiles;
				_0024VB_0024Local_FinishedTasks = arg0._0024VB_0024Local_FinishedTasks;
				_0024VB_0024Local_SuitVersion = arg0._0024VB_0024Local_SuitVersion;
				_0024VB_0024Local_SelectedVersion = arg0._0024VB_0024Local_SelectedVersion;
				_0024VB_0024Local_Ts = arg0._0024VB_0024Local_Ts;
				_0024VB_0024Local_SelectedVersionStr = arg0._0024VB_0024Local_SelectedVersionStr;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__5()
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			List<IMyRadio> val = new List<IMyRadio>();
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = _0024VB_0024Local_SuitVersion.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					val.Add((IMyRadio)new MyRadioBox
					{
						Text = current
					});
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			_0024VB_0024Local_SelectedVersion = ModMain.MyMsgBoxSelect(val, "选择期望的游戏版本", "确定", "取消");
			if (_0024VB_0024Local_SelectedVersion == null)
			{
				_0024VB_0024Local_Ts.Abort();
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__6(ModComp.CompFile i)
		{
			return i.GameVersions.Contains(_0024VB_0024Local_SelectedVersionStr);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__25_002D1
	{
		public string _0024VB_0024Local_Item;

		public _Closure_0024__25_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_3;

		public _Closure_0024__25_002D1(_Closure_0024__25_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Item = arg0._0024VB_0024Local_Item;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			try
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_AllFiles.Add(Enumerable.ToList<ModComp.CompFile>(Enumerable.Where<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)ModComp.CompFilesGet(_0024VB_0024Local_Item, ModComp.CompRequest.IsFromCurseForge(_0024VB_0024Local_Item)), (Func<ModComp.CompFile, bool>)([SpecialName] (ModComp.CompFile i) => i.Type != 0 || i.ModLoaders.Contains(_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_DesiredModLoader)))));
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, $"获取 {_0024VB_0024Local_Item} 的下载信息失败", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
			finally
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_FinishedTasks = checked(_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_FinishedTasks + 1);
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__25_002D2
	{
		public ModComp.CompLoaderType _0024VB_0024Local_DesiredModLoader;

		public Func<ModComp.CompFile, bool> _0024I3;

		public _Closure_0024__25_002D2(_Closure_0024__25_002D2 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_DesiredModLoader = arg0._0024VB_0024Local_DesiredModLoader;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<List<string>, List<ModNet.NetFile>> Ts)
		{
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Expected O, but got Unknown
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Unknown result type (might be due to invalid IL or missing references)
			_Closure_0024__25_002D0 arg = default(_Closure_0024__25_002D0);
			_Closure_0024__25_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__25_002D0(null)
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_2 = this,
				_0024VB_0024Local_Ts = Ts,
				_0024VB_0024Local_AllFiles = new List<List<ModComp.CompFile>>(),
				_0024VB_0024Local_SuitVersion = new List<string>()
			};
			bool flag = true;
			VB_0024AnonymousDelegate_16<List<List<string>>, List<string>> vB_0024AnonymousDelegate_ = [SpecialName] (List<List<string>> Ls) =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				List<string> val5 = new List<string>();
				System.Collections.Generic.IEnumerator<List<string>> enumerator5 = default(System.Collections.Generic.IEnumerator<List<string>>);
				try
				{
					enumerator5 = Ls.GetEnumerator();
					while (enumerator5.MoveNext())
					{
						List<string> current3 = enumerator5.Current;
						val5.AddRange((System.Collections.Generic.IEnumerable<string>)current3);
					}
				}
				finally
				{
					((System.IDisposable)enumerator5).Dispose();
				}
				return Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val5));
			};
			CS_0024_003C_003E8__locals0._0024VB_0024Local_FinishedTasks = 0;
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = CS_0024_003C_003E8__locals0._0024VB_0024Local_Ts.Input.GetEnumerator();
				_Closure_0024__25_002D1 closure_0024__25_002D = default(_Closure_0024__25_002D1);
				while (enumerator.MoveNext())
				{
					closure_0024__25_002D = new _Closure_0024__25_002D1(closure_0024__25_002D)
					{
						_0024VB_0024NonLocal__0024VB_0024Closure_3 = CS_0024_003C_003E8__locals0,
						_0024VB_0024Local_Item = enumerator.Current
					};
					ModBase.RunInNewThread(new Action(closure_0024__25_002D._Lambda_0024__2), null, (ThreadPriority)2);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			while (CS_0024_003C_003E8__locals0._0024VB_0024Local_FinishedTasks != CS_0024_003C_003E8__locals0._0024VB_0024Local_Ts.Input.Count)
			{
				Thread.Sleep(200);
			}
			System.Collections.Generic.IEnumerator<List<ModComp.CompFile>> enumerator2 = default(System.Collections.Generic.IEnumerator<List<ModComp.CompFile>>);
			try
			{
				enumerator2 = CS_0024_003C_003E8__locals0._0024VB_0024Local_AllFiles.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					List<ModComp.CompFile> current = enumerator2.Current;
					List<string> val = vB_0024AnonymousDelegate_(Enumerable.ToList<List<string>>(Enumerable.Select<ModComp.CompFile, List<string>>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)current, (Func<ModComp.CompFile, List<string>>)([SpecialName] (ModComp.CompFile i) => i.GameVersions))));
					if (flag)
					{
						flag = false;
						CS_0024_003C_003E8__locals0._0024VB_0024Local_SuitVersion = val;
					}
					else
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Local_SuitVersion = Enumerable.ToList<string>(Enumerable.Intersect<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0._0024VB_0024Local_SuitVersion, (System.Collections.Generic.IEnumerable<string>)val));
					}
					if (CS_0024_003C_003E8__locals0._0024VB_0024Local_SuitVersion.Count == 0)
					{
						ModMain.Hint("不存在指定加载器并且同版本的资源", ModMain.HintType.Critical);
						CS_0024_003C_003E8__locals0._0024VB_0024Local_Ts.Abort();
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedVersion = null;
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				List<IMyRadio> val4 = new List<IMyRadio>();
				System.Collections.Generic.IEnumerator<string> enumerator4 = default(System.Collections.Generic.IEnumerator<string>);
				try
				{
					enumerator4 = CS_0024_003C_003E8__locals0._0024VB_0024Local_SuitVersion.GetEnumerator();
					while (enumerator4.MoveNext())
					{
						string current2 = enumerator4.Current;
						val4.Add((IMyRadio)new MyRadioBox
						{
							Text = current2
						});
					}
				}
				finally
				{
					((System.IDisposable)enumerator4).Dispose();
				}
				CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedVersion = ModMain.MyMsgBoxSelect(val4, "选择期望的游戏版本", "确定", "取消");
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedVersion == null)
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Ts.Abort();
				}
			}));
			CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedVersionStr = CS_0024_003C_003E8__locals0._0024VB_0024Local_SuitVersion[Conversions.ToInteger(CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedVersion)];
			ModMain.Hint($"已选择 {CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedVersionStr} 版本，下面请选择保存位置");
			string text = SystemDialogs.SelectFolder();
			if (string.IsNullOrWhiteSpace(text))
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Ts.Abort();
				return;
			}
			List<ModNet.NetFile> val2 = new List<ModNet.NetFile>();
			System.Collections.Generic.IEnumerator<List<ModComp.CompFile>> enumerator3 = default(System.Collections.Generic.IEnumerator<List<ModComp.CompFile>>);
			try
			{
				enumerator3 = CS_0024_003C_003E8__locals0._0024VB_0024Local_AllFiles.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					List<ModComp.CompFile> val3 = Enumerable.ToList<ModComp.CompFile>(Enumerable.Where<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)enumerator3.Current, (Func<ModComp.CompFile, bool>)([SpecialName] (ModComp.CompFile i) => i.GameVersions.Contains(CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedVersionStr))));
					ModBase.Sort((System.Collections.Generic.IList<ModComp.CompFile>)val3, (_Closure_0024__._0024I25_002D7 == null) ? (_Closure_0024__._0024I25_002D7 = [SpecialName] (ModComp.CompFile a, ModComp.CompFile b) => System.DateTime.Compare(a.ReleaseDate, b.ReleaseDate) > 0) : _Closure_0024__._0024I25_002D7);
					val2.Add(Enumerable.First<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)val3).ToNetFile(text + Enumerable.First<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)val3).FileName));
				}
			}
			finally
			{
				((System.IDisposable)enumerator3).Dispose();
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Ts.Output = val2;
		}

		[SpecialName]
		internal bool _Lambda_0024__3(ModComp.CompFile i)
		{
			if (i.Type == ModComp.CompType.Mod)
			{
				return i.ModLoaders.Contains(_0024VB_0024Local_DesiredModLoader);
			}
			return true;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__31_002D0
	{
		public List<string> _0024VB_0024Local_FailIds;

		public PageDownloadCompFavorites _0024VB_0024Me;

		public _Closure_0024__31_002D0(_Closure_0024__31_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_FailIds = arg0._0024VB_0024Local_FailIds;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			ModBase.ClipboardSet(ModBase.Join((System.Collections.IEnumerable)_0024VB_0024Local_FailIds, "\r\n"));
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = _0024VB_0024Local_FailIds.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					_0024VB_0024Me.CurrentFavTarget.Favs.Remove(current);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			ModComp.CompFavorites.Save();
			ModMain.Hint("已移除相关收藏", ModMain.HintType.Finish);
		}
	}

	public ModLoader.LoaderTask<List<string>, List<ModComp.CompProject>> Loader;

	private List<MyListItem> CompItemList;

	private List<MyListItem> SelectedItemList;

	private List<CompListItemContainer> ItemList;

	private int BottomBarShownCount;

	private bool AllowSearch;

	private List<MyListItem> SearchResult;

	[CompilerGenerated]
	[AccessedThroughProperty("PanSearchBox")]
	private MySearchBox _PanSearchBox;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboTargetFav")]
	private MyComboBox _ComboTargetFav;

	[CompilerGenerated]
	[AccessedThroughProperty("HintGetFail")]
	private MyHint _HintGetFail;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn_FavoritesCancel")]
	private MyIconTextButton _Btn_FavoritesCancel;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn_FavoritesShare")]
	private MyIconTextButton _Btn_FavoritesShare;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn_FavoritesDownload")]
	private MyIconTextButton _Btn_FavoritesDownload;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn_SelectCancel")]
	private MyIconTextButton _Btn_SelectCancel;

	[CompilerGenerated]
	[AccessedThroughProperty("Load")]
	private MyLoading _Load;

	private bool _contentLoaded;

	private ModComp.CompFavorites.FavData CurrentFavTarget
	{
		get
		{
			MyComboBoxItem myComboBoxItem = (MyComboBoxItem)((Selector)ComboTargetFav).SelectedItem;
			if (myComboBoxItem == null)
			{
				ModBase.Log("[Favorites] 异常：未选择收藏夹");
				myComboBoxItem = (MyComboBoxItem)((ItemsControl)ComboTargetFav).Items.GetItemAt(0);
			}
			return Enumerable.First<ModComp.CompFavorites.FavData>(Enumerable.Where<ModComp.CompFavorites.FavData>((System.Collections.Generic.IEnumerable<ModComp.CompFavorites.FavData>)ModComp.CompFavorites.FavoritesList, (Func<ModComp.CompFavorites.FavData, bool>)([SpecialName] (ModComp.CompFavorites.FavData e) => Operators.ConditionalCompareObjectEqual((object)e.Id, ((FrameworkElement)myComboBoxItem).Tag, false))));
		}
	}

	private bool IsSearching => !string.IsNullOrWhiteSpace(PanSearchBox.Text);

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
	[field: AccessedThroughProperty("PanContent")]
	internal virtual Grid PanContent
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MySearchBox PanSearchBox
	{
		[CompilerGenerated]
		get
		{
			return _PanSearchBox;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySearchBox.TextChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				SearchRun();
			};
			MySearchBox panSearchBox = _PanSearchBox;
			if (panSearchBox != null)
			{
				panSearchBox.TextChanged -= obj;
			}
			_PanSearchBox = value;
			panSearchBox = _PanSearchBox;
			if (panSearchBox != null)
			{
				panSearchBox.TextChanged += obj;
			}
		}
	}

	internal virtual MyComboBox ComboTargetFav
	{
		[CompilerGenerated]
		get
		{
			return _ComboTargetFav;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SelectionChangedEventHandler val = new SelectionChangedEventHandler(ComboTargetFav_Selected);
			MyComboBox comboTargetFav = _ComboTargetFav;
			if (comboTargetFav != null)
			{
				((Selector)comboTargetFav).SelectionChanged -= val;
			}
			_ComboTargetFav = value;
			comboTargetFav = _ComboTargetFav;
			if (comboTargetFav != null)
			{
				((Selector)comboTargetFav).SelectionChanged += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("Btn_ManageTargetFav")]
	internal virtual MyIconButton Btn_ManageTargetFav
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyHint HintGetFail
	{
		[CompilerGenerated]
		get
		{
			return _HintGetFail;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(HintGetFail_MouseLeftButtonDown);
			MyHint hintGetFail = _HintGetFail;
			if (hintGetFail != null)
			{
				((UIElement)hintGetFail).MouseLeftButtonDown -= val;
			}
			_HintGetFail = value;
			hintGetFail = _HintGetFail;
			if (hintGetFail != null)
			{
				((UIElement)hintGetFail).MouseLeftButtonDown += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanContentList")]
	internal virtual StackPanel PanContentList
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardNoContent")]
	internal virtual MyCard CardNoContent
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardSelect")]
	internal virtual MyCard CardSelect
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TransSelect")]
	internal virtual TranslateTransform TransSelect
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabSelect")]
	internal virtual TextBlock LabSelect
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconTextButton Btn_FavoritesCancel
	{
		[CompilerGenerated]
		get
		{
			return _Btn_FavoritesCancel;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = Btn_FavoritesCancel_Clicked;
			MyIconTextButton btn_FavoritesCancel = _Btn_FavoritesCancel;
			if (btn_FavoritesCancel != null)
			{
				btn_FavoritesCancel.Click -= obj;
			}
			_Btn_FavoritesCancel = value;
			btn_FavoritesCancel = _Btn_FavoritesCancel;
			if (btn_FavoritesCancel != null)
			{
				btn_FavoritesCancel.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton Btn_FavoritesShare
	{
		[CompilerGenerated]
		get
		{
			return _Btn_FavoritesShare;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = Btn_FavoritesShare_Clicked;
			MyIconTextButton btn_FavoritesShare = _Btn_FavoritesShare;
			if (btn_FavoritesShare != null)
			{
				btn_FavoritesShare.Click -= obj;
			}
			_Btn_FavoritesShare = value;
			btn_FavoritesShare = _Btn_FavoritesShare;
			if (btn_FavoritesShare != null)
			{
				btn_FavoritesShare.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton Btn_FavoritesDownload
	{
		[CompilerGenerated]
		get
		{
			return _Btn_FavoritesDownload;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = Btn_FavoritesDownload_Clicked;
			MyIconTextButton btn_FavoritesDownload = _Btn_FavoritesDownload;
			if (btn_FavoritesDownload != null)
			{
				btn_FavoritesDownload.Click -= obj;
			}
			_Btn_FavoritesDownload = value;
			btn_FavoritesDownload = _Btn_FavoritesDownload;
			if (btn_FavoritesDownload != null)
			{
				btn_FavoritesDownload.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton Btn_SelectCancel
	{
		[CompilerGenerated]
		get
		{
			return _Btn_SelectCancel;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = Btn_SelectCancel_Clicked;
			MyIconTextButton btn_SelectCancel = _Btn_SelectCancel;
			if (btn_SelectCancel != null)
			{
				btn_SelectCancel.Click -= obj;
			}
			_Btn_SelectCancel = value;
			btn_SelectCancel = _Btn_SelectCancel;
			if (btn_SelectCancel != null)
			{
				btn_SelectCancel.Click += obj;
			}
		}
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

	internal virtual MyLoading Load
	{
		[CompilerGenerated]
		get
		{
			return _Load;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = Load_State;
			MyLoading load = _Load;
			if (load != null)
			{
				load.StateChanged -= obj;
			}
			_Load = value;
			load = _Load;
			if (load != null)
			{
				load.StateChanged += obj;
			}
		}
	}

	private void PageDownloadCompFavorites_Inited(object sender, EventArgs e)
	{
		RefreshFavTargets();
		PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanContent, null, Loader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
		{
			Load_OnFinish();
		}, LoaderInput);
	}

	private void PageDownloadCompFavorites_Loaded(object sender, EventArgs e)
	{
		Items_SetSelectAll(TargetStatus: false);
		RefreshBar();
		if (Loader.Input != null && !Loader.Input.Count.Equals(CurrentFavTarget.Favs.Count))
		{
			RefreshFavTargets();
		}
	}

	private List<string> LoaderInput()
	{
		List<string> list = null;
		try
		{
			list = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)CurrentFavTarget.Favs));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "[Favorites] 加载收藏夹列表时出错");
			ProjectData.ClearProjectError();
		}
		return (List<string>)ModBase.Clone((System.Collections.Generic.IList<string>)list);
	}

	private void CompFavoritesGet(ModLoader.LoaderTask<List<string>, List<ModComp.CompProject>> Task)
	{
		Task.Output = ModComp.CompRequest.GetCompProjectsByIds(Task.Input);
	}

	public PageDownloadCompFavorites()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		((FrameworkElement)this).Initialized += new EventHandler(PageDownloadCompFavorites_Inited);
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageDownloadCompFavorites_Loaded);
		((UIElement)this).KeyDown += new KeyEventHandler(Page_KeyDown);
		Loader = new ModLoader.LoaderTask<List<string>, List<ModComp.CompProject>>("CompProject Favorites", CompFavoritesGet, LoaderInput, (ThreadPriority)2);
		CompItemList = new List<MyListItem>();
		SelectedItemList = new List<MyListItem>();
		ItemList = new List<CompListItemContainer>();
		BottomBarShownCount = 0;
		AllowSearch = true;
		SearchResult = new List<MyListItem>();
		InitializeComponent();
		Btn_ManageTargetFav.Logo = "M651.946667 1001.813333c-22.186667 0-42.666667-10.24-61.44-27.306666-23.893333-23.893333-49.493333-35.84-75.093334-35.84-29.013333 0-56.32 11.946667-73.386666 30.72v3.413333c-17.066667 17.066667-42.666667 27.306667-66.56 27.306667h-6.826667c-6.826667 0-11.946667-1.706667-15.36-1.706667l-6.826667-1.706667c-64.853333-20.48-121.173333-54.613333-168.96-98.986666-29.013333-23.893333-37.546667-63.146667-25.6-95.573334 8.533333-23.893333 5.12-51.2-10.24-75.093333-15.36-27.306667-34.133333-40.96-59.733333-47.786667h-1.706667l-5.12-1.706666c-35.84-8.533333-61.44-34.133333-66.56-69.973334C1.706667 575.146667 0 537.6 0 512c0-32.426667 3.413333-63.146667 8.533333-93.866667v-6.826666l3.413334-8.533334c10.24-23.893333 23.893333-40.96 44.373333-51.2 5.12-3.413333 11.946667-6.826667 20.48-8.533333 27.306667-8.533333 51.2-25.6 63.146667-44.373333 13.653333-23.893333 17.066667-52.906667 10.24-81.92-11.946667-34.133333 0-71.68 30.72-93.866667 44.373333-37.546667 97.28-68.266667 158.72-93.866667l3.413333-1.706666c44.373333-13.653333 75.093333 3.413333 92.16 20.48 23.893333 23.893333 49.493333 35.84 75.093333 35.84 30.72 0 56.32-10.24 71.68-30.72l3.413334-3.413334c27.306667-27.306667 63.146667-35.84 93.866666-22.186666 63.146667 22.186667 117.76 54.613333 165.546667 97.28 29.013333 23.893333 37.546667 63.146667 25.6 95.573333-8.533333 23.893333-5.12 51.2 10.24 75.093333 15.36 27.306667 34.133333 40.96 59.733333 47.786667h1.706667l5.12 1.706667c35.84 8.533333 61.44 34.133333 66.56 71.68 6.826667 30.72 10.24 63.146667 11.946667 93.866666v3.413334c0 32.426667-3.413333 63.146667-8.533334 93.866666v6.826667l-3.413333 8.533333c-10.24 23.893333-23.893333 40.96-44.373333 51.2-5.12 3.413333-11.946667 6.826667-20.48 8.533334-27.306667 8.533333-51.2 25.6-63.146667 46.08-13.653333 23.893333-17.066667 52.906667-10.24 81.92 11.946667 35.84-1.706667 75.093333-30.72 95.573333-44.373333 35.84-95.573333 66.56-157.013333 92.16-15.36 3.413333-27.306667 3.413333-35.84 3.413333z m3.413333-83.626666z m1.706667 0zM517.12 853.333333c47.786667 0 93.866667 20.48 134.826667 59.733334 1.706667 1.706667 3.413333 1.706667 3.413333 3.413333 52.906667-22.186667 97.28-49.493333 136.533333-80.213333l1.706667-1.706667v-3.413333c-13.653333-52.906667-8.533333-104.106667 17.066667-148.48 23.893333-39.253333 64.853333-69.973333 114.346666-85.333334 1.706667 0 3.413333-1.706667 6.826667-6.826666 5.12-25.6 8.533333-51.2 8.533333-78.506667-1.706667-29.013333-3.413333-56.32-10.24-81.92v-5.12h-1.706666c-51.2-11.946667-90.453333-39.253333-119.466667-87.04-27.306667-44.373333-34.133333-100.693333-17.066667-148.48l-1.706666-1.706667h-3.413334c-39.253333-35.84-85.333333-63.146667-136.533333-80.213333H648.533333s-1.706667 1.706667-3.413333 1.706667c-32.426667 39.253333-80.213333 59.733333-136.533333 59.733333-47.786667 0-93.866667-20.48-134.826667-59.733333l-1.706667-1.706667h-1.706666c-54.613333 22.186667-98.986667 49.493333-136.533334 80.213333l-1.706666 1.706667v3.413333c13.653333 52.906667 8.533333 104.106667-17.066667 148.48-23.893333 39.253333-64.853333 69.973333-114.346667 85.333334-1.706667 0-3.413333 1.706667-6.826666 6.826666-6.826667 25.6-8.533333 51.2-8.533334 78.506667 0 30.72 3.413333 58.026667 6.826667 76.8l1.706667 5.12h1.706666c51.2 11.946667 90.453333 39.253333 119.466667 87.04 27.306667 44.373333 34.133333 100.693333 17.066667 148.48l1.706666 1.706667 1.706667 1.706666c37.546667 35.84 83.626667 63.146667 134.826667 80.213334 1.706667 0 3.413333 0 3.413333 1.706666h1.706667s1.706667 0 5.12-1.706666c34.133333-37.546667 81.92-59.733333 136.533333-59.733334z m-6.826667-146.773333c-110.933333 0-199.68-85.333333-199.68-196.266667 0-109.226667 87.04-196.266667 199.68-196.266666s199.68 85.333333 199.68 196.266666c-1.706667 109.226667-88.746667 196.266667-199.68 196.266667z m0-307.2c-63.146667 0-114.346667 49.493333-114.346666 110.933333 0 63.146667 49.493333 110.933333 114.346666 110.933334 30.72 0 59.733333-11.946667 80.213334-32.426667 20.48-20.48 32.426667-49.493333 32.426666-78.506667 0-63.146667-49.493333-110.933333-112.64-110.933333z";
		Btn_ManageTargetFav.Click += [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			Manage_Click(RuntimeHelpers.GetObjectValue(a0), (MouseButtonEventArgs)a1);
		};
	}

	private void RefreshFavTargets()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		((ItemsControl)ComboTargetFav).Items.Clear();
		System.Collections.Generic.IEnumerator<ModComp.CompFavorites.FavData> enumerator = default(System.Collections.Generic.IEnumerator<ModComp.CompFavorites.FavData>);
		try
		{
			enumerator = ModComp.CompFavorites.FavoritesList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ModComp.CompFavorites.FavData current = enumerator.Current;
				MyComboBoxItem myComboBoxItem = new MyComboBoxItem();
				((ContentControl)myComboBoxItem).Content = current.Name;
				((FrameworkElement)myComboBoxItem).Tag = current.Id;
				MyComboBoxItem myComboBoxItem2 = myComboBoxItem;
				((ItemsControl)ComboTargetFav).Items.Add((object)myComboBoxItem2);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		if (((Selector)ComboTargetFav).SelectedIndex == -1)
		{
			((Selector)ComboTargetFav).SelectedIndex = 0;
		}
	}

	private CompListItemContainer GetSuitListContainer(int Type)
	{
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		if (Enumerable.Any<CompListItemContainer>((System.Collections.Generic.IEnumerable<CompListItemContainer>)ItemList, (Func<CompListItemContainer, bool>)([SpecialName] (CompListItemContainer e) => e.CompType.Equals(Type))))
		{
			return Enumerable.First<CompListItemContainer>((System.Collections.Generic.IEnumerable<CompListItemContainer>)ItemList, (Func<CompListItemContainer, bool>)([SpecialName] (CompListItemContainer e) => e.CompType.Equals(Type)));
		}
		CompListItemContainer compListItemContainer = new CompListItemContainer();
		MyCard obj = new MyCard
		{
			CanSwap = true
		};
		((FrameworkElement)obj).Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
		compListItemContainer.Card = obj;
		compListItemContainer.ContentList = new StackPanel
		{
			Orientation = (Orientation)1,
			Margin = new Thickness(12.0, 38.0, 12.0, 12.0)
		};
		compListItemContainer.CompType = Type;
		CompListItemContainer compListItemContainer2 = compListItemContainer;
		switch (Type)
		{
		case -1:
			compListItemContainer2.Title = "搜索结果 ({0})";
			break;
		case 0:
			compListItemContainer2.Title = "Mod ({0})";
			break;
		case 1:
			compListItemContainer2.Title = "整合包 ({0})";
			break;
		case 2:
			compListItemContainer2.Title = "资源包 ({0})";
			break;
		case 3:
			compListItemContainer2.Title = "光影包 ({0})";
			break;
		case 4:
			compListItemContainer2.Title = "数据包 ({0})";
			break;
		case 5:
			compListItemContainer2.Title = "插件 ({0})";
			break;
		case 7:
			compListItemContainer2.Title = "世界 ({0})";
			break;
		default:
			compListItemContainer2.Title = "未分类类型 ({0})";
			break;
		}
		compListItemContainer2.Card.Title = string.Format(compListItemContainer2.Title, (object)0);
		((Panel)compListItemContainer2.Card).Children.Add((UIElement)(object)compListItemContainer2.ContentList);
		ItemList.Add(compListItemContainer2);
		return compListItemContainer2;
	}

	private void RefreshContent()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		System.Collections.Generic.IEnumerator<CompListItemContainer> enumerator = default(System.Collections.Generic.IEnumerator<CompListItemContainer>);
		try
		{
			enumerator = ItemList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				((Panel)enumerator.Current.ContentList).Children.Clear();
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		((Panel)PanContentList).Children.Clear();
		List<MyListItem> val = (IsSearching ? SearchResult : CompItemList);
		System.Collections.Generic.IEnumerator<MyListItem> enumerator2 = default(System.Collections.Generic.IEnumerator<MyListItem>);
		try
		{
			enumerator2 = val.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				MyListItem current = enumerator2.Current;
				((Panel)GetSuitListContainer((int)(IsSearching ? ModComp.CompType.Any : ((ModComp.CompProject)((FrameworkElement)current).Tag).Type)).ContentList).Children.Add((UIElement)(object)current);
			}
		}
		finally
		{
			((System.IDisposable)enumerator2).Dispose();
		}
		System.Collections.Generic.IEnumerator<CompListItemContainer> enumerator3 = default(System.Collections.Generic.IEnumerator<CompListItemContainer>);
		try
		{
			enumerator3 = ItemList.GetEnumerator();
			while (enumerator3.MoveNext())
			{
				CompListItemContainer current2 = enumerator3.Current;
				if (((Panel)current2.ContentList).Children.Count != 0)
				{
					((Panel)PanContentList).Children.Add((UIElement)(object)current2.Card);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator3).Dispose();
		}
	}

	private void RefreshCardTitle()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		System.Collections.Generic.IEnumerator<CompListItemContainer> enumerator = default(System.Collections.Generic.IEnumerator<CompListItemContainer>);
		try
		{
			enumerator = ItemList.GetEnumerator();
			_Closure_0024__15_002D0 closure_0024__15_002D = default(_Closure_0024__15_002D0);
			while (enumerator.MoveNext())
			{
				closure_0024__15_002D = new _Closure_0024__15_002D0(closure_0024__15_002D);
				closure_0024__15_002D._0024VB_0024Local_item = enumerator.Current;
				closure_0024__15_002D._0024VB_0024Local_item.Card.Title = string.Format(closure_0024__15_002D._0024VB_0024Local_item.Title, (object)Enumerable.Count<MyListItem>(Enumerable.Where<MyListItem>((System.Collections.Generic.IEnumerable<MyListItem>)CompItemList, (Func<MyListItem, bool>)closure_0024__15_002D._Lambda_0024__0)));
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		if (Enumerable.Any<CompListItemContainer>((System.Collections.Generic.IEnumerable<CompListItemContainer>)ItemList, (Func<CompListItemContainer, bool>)([SpecialName] (CompListItemContainer e) => e.CompType.Equals(-1))))
		{
			CompListItemContainer compListItemContainer = Enumerable.First<CompListItemContainer>((System.Collections.Generic.IEnumerable<CompListItemContainer>)ItemList, (Func<CompListItemContainer, bool>)([SpecialName] (CompListItemContainer e) => e.CompType.Equals(-1)));
			if (compListItemContainer != null)
			{
				compListItemContainer.Card.Title = string.Format(compListItemContainer.Title, (object)SearchResult.Count);
			}
		}
	}

	private void Load_OnFinish()
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		ItemList.Clear();
		try
		{
			AllowSearch = false;
			PanSearchBox.Text = string.Empty;
			AllowSearch = true;
			CompItemList.Clear();
			bool flag = Loader.Input.Count != Loader.Output.Count;
			((UIElement)HintGetFail).Visibility = (Visibility)((!flag) ? 2 : 0);
			System.Collections.Generic.IEnumerator<ModComp.CompProject> enumerator = default(System.Collections.Generic.IEnumerator<ModComp.CompProject>);
			try
			{
				enumerator = Loader.Output.GetEnumerator();
				while (enumerator.MoveNext())
				{
					MyListItem myListItem = enumerator.Current.ToListItem();
					ListItemBuild(myListItem);
					CompItemList.Add(myListItem);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			if (Enumerable.Any<MyListItem>((System.Collections.Generic.IEnumerable<MyListItem>)CompItemList))
			{
				if (!IsSearching)
				{
					((UIElement)PanSearchBox).Visibility = (Visibility)0;
					((UIElement)PanContentList).Visibility = (Visibility)0;
					((UIElement)CardNoContent).Visibility = (Visibility)2;
				}
			}
			else
			{
				((UIElement)PanSearchBox).Visibility = (Visibility)2;
				((UIElement)PanContentList).Visibility = (Visibility)2;
				((UIElement)CardNoContent).Visibility = (Visibility)0;
			}
			RefreshContent();
			RefreshCardTitle();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化收藏夹列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void ListItemBuild(MyListItem CompItem)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0089: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		CompItem.Type = MyListItem.CheckType.CheckBox;
		string id = ((ModComp.CompProject)((FrameworkElement)CompItem).Tag).Id;
		string text = "";
		CurrentFavTarget.Notes.TryGetValue(id, out text);
		Run val = new Run
		{
			Foreground = (Brush)new SolidColorBrush(Color.FromRgb((byte)0, (byte)184, (byte)148))
		};
		if (!string.IsNullOrWhiteSpace(text))
		{
			val.Text = $" ({text})";
		}
		((TextElementCollection<Inline>)(object)CompItem.LabTitle.Inlines).Add((Inline)(object)val);
		MyIconButton myIconButton = new MyIconButton();
		myIconButton.Logo = "M732.64 64.32C688.576 21.216 613.696 21.216 569.6 64.32L120.128 499.52c-17.6 12.896-26.432 30.144-30.848 51.68L32 870.048c0 25.856 8.8 56 26.432 73.248 17.632 17.216 17.632 48.704 88.64 48.704h13.248l326.08-56c22.016-4.32 39.68-12.928 52.864-30.176l449.472-435.2c22.048-21.536 35.264-47.36 35.264-77.536 0-30.176-13.216-56-35.264-77.568l-256.096-251.2zM139.712 903.776l56-326.912 311.04-295.136 267.104 269.44-310.976 295.168-323.168 57.44zM844.576 467.84l-273.984-260.672 61.856-59.84c8.832-8.512 26.528-8.512 39.776 0l234.24 226.496c4.384 4.288 8.832 12.8 8.832 17.088s-4.416 8.544-8.864 12.8l-61.856 64.128z";
		((FrameworkElement)myIconButton).ToolTip = "修改备注";
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object sender, EventArgs e) =>
		{
			CurrentFavTarget.Notes.TryGetValue(id, out text);
			string text2 = ModMain.MyMsgBoxInput("修改备注", "", text);
			if (text2 != null)
			{
				CurrentFavTarget.Notes[id] = text2;
				val.Text = (string.IsNullOrWhiteSpace(text2) ? "" : $" ({text2})");
				ModComp.CompFavorites.Save();
			}
		};
		MyIconButton myIconButton2 = new MyIconButton();
		myIconButton2.Logo = "M700.856 155.543c-74.769 0-144.295 72.696-190.046 127.26-45.737-54.576-115.247-127.26-190.056-127.26-134.79 0-244.443 105.78-244.443 235.799 0 77.57 39.278 131.988 70.845 175.713C238.908 694.053 469.62 852.094 479.39 858.757c9.41 6.414 20.424 9.629 31.401 9.629 11.006 0 21.998-3.215 31.398-9.63 9.782-6.662 240.514-164.703 332.238-291.701 31.587-43.724 70.874-98.143 70.874-175.713-0.001-130.02-109.656-235.8-244.445-235.8z m0 0";
		((FrameworkElement)myIconButton2).ToolTip = "取消收藏";
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton2, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton2, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton2, 2.0);
		myIconButton2.Click += [SpecialName] (object sender, EventArgs e) =>
		{
			Items_CancelFavorites(CompItem);
			RefreshContent();
			RefreshCardTitle();
			RefreshBar();
		};
		CompItem.Buttons = new MyIconButton[] { myIconButton, myIconButton2 };
		if (((FrameworkElement)CompItem).Tag is ModComp.CompProject)
		{
			((UIElement)CompItem).MouseRightButtonUp += (MouseButtonEventHandler)([SpecialName] (object sender, MouseButtonEventArgs e) =>
			{
				ModMain.FrmMain.PageChange(new FormMain.PageStackData
				{
					Page = FormMain.PageType.CompDetail,
					Additional = new object[5]
					{
						((FrameworkElement)CompItem).Tag,
						new List<string>(),
						string.Empty,
						ModComp.CompLoaderType.Any,
						((ModComp.CompProject)((FrameworkElement)CompItem).Tag).Type
					}
				});
			});
		}
		CompItem.Changed += ItemCheckStatusChanged;
	}

	private void RefreshBar()
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		int count = SelectedItemList.Count;
		bool flag = count > 0;
		if (flag)
		{
			LabSelect.Text = $"已选择 {count} 个收藏项目";
		}
		if (ModAnimation.AniControlEnabled == 0)
		{
			((FrameworkElement)PanContentList).Margin = new Thickness(0.0, 0.0, 0.0, (double)(flag ? 80 : 0));
			if (flag)
			{
				if (BottomBarShownCount >= count)
				{
					BottomBarShownCount = count;
					return;
				}
				BottomBarShownCount = count;
				((UIElement)CardSelect).Visibility = (Visibility)0;
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[4]
				{
					ModAnimation.AaOpacity(CardSelect, 1.0 - ((UIElement)CardSelect).Opacity, 60),
					ModAnimation.AaTranslateY(CardSelect, -27.0 - TransSelect.Y, 120, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)),
					ModAnimation.AaTranslateY(CardSelect, 3.0, 150, 120, new ModAnimation.AniEaseInoutFluent(ModAnimation.AniEasePower.Weak)),
					ModAnimation.AaTranslateY(CardSelect, -1.0, 90, 270, new ModAnimation.AniEaseInoutFluent(ModAnimation.AniEasePower.Weak))
				}, "CompFavorites Sidebar");
			}
			else if (BottomBarShownCount != 0)
			{
				BottomBarShownCount = 0;
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
				{
					ModAnimation.AaOpacity(CardSelect, 0.0 - ((UIElement)CardSelect).Opacity, 90),
					ModAnimation.AaTranslateY(CardSelect, -10.0 - TransSelect.Y, 90, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)),
					ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
					{
						((UIElement)CardSelect).Visibility = (Visibility)2;
					}), 0, After: true)
				}, "CompFavorites Sidebar");
			}
		}
		else
		{
			ModAnimation.AniStop("CompFavorites Sidebar");
			BottomBarShownCount = count;
			if (flag)
			{
				((UIElement)CardSelect).Visibility = (Visibility)0;
				((UIElement)CardSelect).Opacity = 1.0;
				TransSelect.Y = -25.0;
			}
			else
			{
				((UIElement)CardSelect).Visibility = (Visibility)2;
				((UIElement)CardSelect).Opacity = 0.0;
				TransSelect.Y = -10.0;
			}
		}
	}

	private void ItemCheckStatusChanged(object sender, ModBase.RouteEventArgs e)
	{
		MyListItem myListItem = (MyListItem)sender;
		if (SelectedItemList.Contains(myListItem))
		{
			SelectedItemList.Remove(myListItem);
		}
		if (myListItem.Checked)
		{
			SelectedItemList.Add(myListItem);
		}
		RefreshBar();
	}

	private void Load_State(object sender, MyLoading.MyLoadingState state, MyLoading.MyLoadingState oldState)
	{
		ModBase.LoadState state2 = Loader.State;
		if (state2 == ModBase.LoadState.Failed)
		{
			string text = "";
			if (Loader.Error != null)
			{
				text = Loader.Error.Message;
			}
			if (text.Contains("不是有效的 json 文件"))
			{
				ModBase.Log("[Download] 下载的工程列表 JSON 文件损坏，已自动重试", ModBase.LogLevel.Debug);
				PageLoaderRestart();
			}
		}
	}

	private void Btn_FavoritesCancel_Clicked(object sender, ModBase.RouteEventArgs e)
	{
		System.Collections.Generic.IEnumerator<MyListItem> enumerator = default(System.Collections.Generic.IEnumerator<MyListItem>);
		try
		{
			enumerator = ((System.Collections.Generic.IEnumerable<MyListItem>)ModBase.Clone((System.Collections.Generic.IList<MyListItem>)SelectedItemList)).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				MyListItem current = enumerator.Current;
				Items_CancelFavorites(current);
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		if (Enumerable.Any<MyListItem>((System.Collections.Generic.IEnumerable<MyListItem>)CompItemList))
		{
			RefreshContent();
			RefreshCardTitle();
		}
		else
		{
			Loader.Start();
		}
		RefreshBar();
	}

	private void Btn_SelectCancel_Clicked(object sender, ModBase.RouteEventArgs e)
	{
		Items_SetSelectAll(TargetStatus: false);
	}

	private void Btn_FavoritesShare_Clicked(object sender, ModBase.RouteEventArgs e)
	{
		try
		{
			ModBase.ClipboardSet(ModComp.CompFavorites.GetShareCode(Enumerable.ToList<string>(Enumerable.Select<MyListItem, string>((System.Collections.Generic.IEnumerable<MyListItem>)SelectedItemList, (Func<MyListItem, string>)([SpecialName] (MyListItem i) => ((ModComp.CompProject)((FrameworkElement)i).Tag).Id)))));
			Items_SetSelectAll(TargetStatus: false);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "[CompFavourites] 分享收藏时发生错误", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private void Btn_FavoritesDownload_Clicked(object sender, ModBase.RouteEventArgs e)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			_Closure_0024__25_002D2 arg = default(_Closure_0024__25_002D2);
			_Closure_0024__25_002D2 CS_0024_003C_003E8__locals0 = new _Closure_0024__25_002D2(null);
			if (SelectedItemList.Count == 1)
			{
				ModMain.Hint("要不……你直接进详情页里下载吧……");
			}
			else
			{
				if (1 != ModMain.MyMsgBox(string.Format("批量下载功能仍旧处于测试状态{0}使用此功能下载模组不会自动下载前置项。{1}请在下载前仔细思考自己的需求，并仔细检查自己的选择，避免下载错误导致时间和网络流量的浪费。", (object)"\r\n", (object)"\r\n"), "确定使用此功能？", "继续", "算了", "", IsWarn: true))
				{
					return;
				}
				List<ModComp.CompLoaderType> val = new List<ModComp.CompLoaderType>();
				bool flag = true;
				bool flag2 = false;
				System.Collections.Generic.IEnumerator<MyListItem> enumerator = default(System.Collections.Generic.IEnumerator<MyListItem>);
				try
				{
					enumerator = SelectedItemList.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ModComp.CompProject compProject = (ModComp.CompProject)((FrameworkElement)enumerator.Current).Tag;
						if (compProject.Type == ModComp.CompType.Mod)
						{
							flag2 = true;
							if (flag)
							{
								flag = false;
								val = compProject.ModLoaders;
							}
							else
							{
								val = Enumerable.ToList<ModComp.CompLoaderType>(Enumerable.Intersect<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)val, (System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)compProject.ModLoaders));
							}
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				if (flag2 && val.Count == 0)
				{
					ModMain.Hint("所选模组不支持相同的加载器", ModMain.HintType.Critical);
					return;
				}
				CS_0024_003C_003E8__locals0._0024VB_0024Local_DesiredModLoader = ModComp.CompLoaderType.Any;
				if (flag2 && val.Count > 0 && val.Count > 0)
				{
					List<IMyRadio> val2 = new List<IMyRadio>();
					System.Collections.Generic.IEnumerator<ModComp.CompLoaderType> enumerator2 = default(System.Collections.Generic.IEnumerator<ModComp.CompLoaderType>);
					try
					{
						enumerator2 = val.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							ModComp.CompLoaderType current = enumerator2.Current;
							val2.Add((IMyRadio)new MyRadioBox
							{
								Text = ((System.Enum)current).ToString()
							});
						}
					}
					finally
					{
						((System.IDisposable)enumerator2).Dispose();
					}
					int? num = ModMain.MyMsgBoxSelect(val2, "选择期望的加载器", "确定", "取消");
					if (!num.HasValue)
					{
						return;
					}
					CS_0024_003C_003E8__locals0._0024VB_0024Local_DesiredModLoader = val[num.Value];
				}
				ModMain.Hint("请稍后，正在查询详细版本支持中，这可能需要一段时间……");
				List<ModLoader.LoaderBase> val3 = new List<ModLoader.LoaderBase>();
				val3.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<List<string>, List<ModNet.NetFile>>("查询资源信息", [SpecialName] (ModLoader.LoaderTask<List<string>, List<ModNet.NetFile>> Ts) =>
				{
					//IL_0064: Unknown result type (might be due to invalid IL or missing references)
					//IL_0069: Unknown result type (might be due to invalid IL or missing references)
					//IL_0094: Unknown result type (might be due to invalid IL or missing references)
					//IL_00a0: Expected O, but got Unknown
					//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
					//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
					//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
					//IL_01b4: Expected O, but got Unknown
					//IL_0214: Unknown result type (might be due to invalid IL or missing references)
					//IL_0219: Unknown result type (might be due to invalid IL or missing references)
					_Closure_0024__25_002D0 arg2 = default(_Closure_0024__25_002D0);
					_Closure_0024__25_002D0 CS_0024_003C_003E8__locals1 = new _Closure_0024__25_002D0(null);
					CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals0;
					CS_0024_003C_003E8__locals1._0024VB_0024Local_Ts = Ts;
					CS_0024_003C_003E8__locals1._0024VB_0024Local_AllFiles = new List<List<ModComp.CompFile>>();
					CS_0024_003C_003E8__locals1._0024VB_0024Local_SuitVersion = new List<string>();
					bool flag3 = true;
					VB_0024AnonymousDelegate_16<List<List<string>>, List<string>> vB_0024AnonymousDelegate_ = [SpecialName] (List<List<string>> Ls) =>
					{
						//IL_0007: Unknown result type (might be due to invalid IL or missing references)
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						List<string> val8 = new List<string>();
						System.Collections.Generic.IEnumerator<List<string>> enumerator7 = default(System.Collections.Generic.IEnumerator<List<string>>);
						try
						{
							enumerator7 = Ls.GetEnumerator();
							while (enumerator7.MoveNext())
							{
								List<string> current4 = enumerator7.Current;
								val8.AddRange((System.Collections.Generic.IEnumerable<string>)current4);
							}
						}
						finally
						{
							((System.IDisposable)enumerator7).Dispose();
						}
						return Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val8));
					};
					CS_0024_003C_003E8__locals1._0024VB_0024Local_FinishedTasks = 0;
					System.Collections.Generic.IEnumerator<string> enumerator3 = default(System.Collections.Generic.IEnumerator<string>);
					try
					{
						enumerator3 = CS_0024_003C_003E8__locals1._0024VB_0024Local_Ts.Input.GetEnumerator();
						_Closure_0024__25_002D1 closure_0024__25_002D = default(_Closure_0024__25_002D1);
						while (enumerator3.MoveNext())
						{
							closure_0024__25_002D = new _Closure_0024__25_002D1(closure_0024__25_002D);
							closure_0024__25_002D._0024VB_0024NonLocal__0024VB_0024Closure_3 = CS_0024_003C_003E8__locals1;
							closure_0024__25_002D._0024VB_0024Local_Item = enumerator3.Current;
							ModBase.RunInNewThread(new Action(closure_0024__25_002D._Lambda_0024__2), null, (ThreadPriority)2);
						}
					}
					finally
					{
						((System.IDisposable)enumerator3).Dispose();
					}
					while (CS_0024_003C_003E8__locals1._0024VB_0024Local_FinishedTasks != CS_0024_003C_003E8__locals1._0024VB_0024Local_Ts.Input.Count)
					{
						Thread.Sleep(200);
					}
					System.Collections.Generic.IEnumerator<List<ModComp.CompFile>> enumerator4 = default(System.Collections.Generic.IEnumerator<List<ModComp.CompFile>>);
					try
					{
						enumerator4 = CS_0024_003C_003E8__locals1._0024VB_0024Local_AllFiles.GetEnumerator();
						while (enumerator4.MoveNext())
						{
							List<ModComp.CompFile> current2 = enumerator4.Current;
							List<string> val4 = vB_0024AnonymousDelegate_(Enumerable.ToList<List<string>>(Enumerable.Select<ModComp.CompFile, List<string>>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)current2, (Func<ModComp.CompFile, List<string>>)([SpecialName] (ModComp.CompFile i) => i.GameVersions))));
							if (flag3)
							{
								flag3 = false;
								CS_0024_003C_003E8__locals1._0024VB_0024Local_SuitVersion = val4;
							}
							else
							{
								CS_0024_003C_003E8__locals1._0024VB_0024Local_SuitVersion = Enumerable.ToList<string>(Enumerable.Intersect<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals1._0024VB_0024Local_SuitVersion, (System.Collections.Generic.IEnumerable<string>)val4));
							}
							if (CS_0024_003C_003E8__locals1._0024VB_0024Local_SuitVersion.Count == 0)
							{
								ModMain.Hint("不存在指定加载器并且同版本的资源", ModMain.HintType.Critical);
								CS_0024_003C_003E8__locals1._0024VB_0024Local_Ts.Abort();
								return;
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator4).Dispose();
					}
					CS_0024_003C_003E8__locals1._0024VB_0024Local_SelectedVersion = null;
					ModBase.RunInUiWait((Action)([SpecialName] () =>
					{
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						//IL_0011: Unknown result type (might be due to invalid IL or missing references)
						List<IMyRadio> val7 = new List<IMyRadio>();
						System.Collections.Generic.IEnumerator<string> enumerator6 = default(System.Collections.Generic.IEnumerator<string>);
						try
						{
							enumerator6 = CS_0024_003C_003E8__locals1._0024VB_0024Local_SuitVersion.GetEnumerator();
							while (enumerator6.MoveNext())
							{
								string current3 = enumerator6.Current;
								val7.Add((IMyRadio)new MyRadioBox
								{
									Text = current3
								});
							}
						}
						finally
						{
							((System.IDisposable)enumerator6).Dispose();
						}
						CS_0024_003C_003E8__locals1._0024VB_0024Local_SelectedVersion = ModMain.MyMsgBoxSelect(val7, "选择期望的游戏版本", "确定", "取消");
						if (CS_0024_003C_003E8__locals1._0024VB_0024Local_SelectedVersion == null)
						{
							CS_0024_003C_003E8__locals1._0024VB_0024Local_Ts.Abort();
						}
					}));
					CS_0024_003C_003E8__locals1._0024VB_0024Local_SelectedVersionStr = CS_0024_003C_003E8__locals1._0024VB_0024Local_SuitVersion[Conversions.ToInteger(CS_0024_003C_003E8__locals1._0024VB_0024Local_SelectedVersion)];
					ModMain.Hint($"已选择 {CS_0024_003C_003E8__locals1._0024VB_0024Local_SelectedVersionStr} 版本，下面请选择保存位置");
					string text = SystemDialogs.SelectFolder();
					if (string.IsNullOrWhiteSpace(text))
					{
						CS_0024_003C_003E8__locals1._0024VB_0024Local_Ts.Abort();
					}
					else
					{
						List<ModNet.NetFile> val5 = new List<ModNet.NetFile>();
						System.Collections.Generic.IEnumerator<List<ModComp.CompFile>> enumerator5 = default(System.Collections.Generic.IEnumerator<List<ModComp.CompFile>>);
						try
						{
							enumerator5 = CS_0024_003C_003E8__locals1._0024VB_0024Local_AllFiles.GetEnumerator();
							while (enumerator5.MoveNext())
							{
								List<ModComp.CompFile> val6 = Enumerable.ToList<ModComp.CompFile>(Enumerable.Where<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)enumerator5.Current, (Func<ModComp.CompFile, bool>)([SpecialName] (ModComp.CompFile i) => i.GameVersions.Contains(CS_0024_003C_003E8__locals1._0024VB_0024Local_SelectedVersionStr))));
								ModBase.Sort((System.Collections.Generic.IList<ModComp.CompFile>)val6, (_Closure_0024__._0024I25_002D7 == null) ? (_Closure_0024__._0024I25_002D7 = [SpecialName] (ModComp.CompFile a, ModComp.CompFile b) => System.DateTime.Compare(a.ReleaseDate, b.ReleaseDate) > 0) : _Closure_0024__._0024I25_002D7);
								val5.Add(Enumerable.First<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)val6).ToNetFile(text + Enumerable.First<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)val6).FileName));
							}
						}
						finally
						{
							((System.IDisposable)enumerator5).Dispose();
						}
						CS_0024_003C_003E8__locals1._0024VB_0024Local_Ts.Output = val5;
					}
				}, null, (ThreadPriority)2)
				{
					ProgressWeight = 2.0
				});
				val3.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("批量下载合适资源", new List<ModNet.NetFile>())
				{
					ProgressWeight = 8.0
				});
				ModLoader.LoaderCombo<List<string>> loaderCombo = new ModLoader.LoaderCombo<List<string>>($"批量下载资源({ModBase.GetUuid()})", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val3);
				loaderCombo.OnStateChanged = ModDownloadLib.LoaderStateChangedHintOnly;
				loaderCombo.Start(Enumerable.ToList<string>(Enumerable.Select<MyListItem, string>((System.Collections.Generic.IEnumerable<MyListItem>)SelectedItemList, (Func<MyListItem, string>)([SpecialName] (MyListItem i) => ((ModComp.CompProject)((FrameworkElement)i).Tag).Id))));
				ModLoader.LoaderTaskbarAdd(loaderCombo);
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
				ModMain.FrmMain.BtnExtraDownload.Ribble();
				Items_SetSelectAll(TargetStatus: false);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "批量下载收藏时发生错误", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private void Items_SetSelectAll(bool TargetStatus)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		if (IsSearching)
		{
			System.Collections.Generic.IEnumerator<MyListItem> enumerator = default(System.Collections.Generic.IEnumerator<MyListItem>);
			try
			{
				enumerator = SearchResult.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.Checked = TargetStatus;
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		else
		{
			System.Collections.Generic.IEnumerator<MyListItem> enumerator2 = default(System.Collections.Generic.IEnumerator<MyListItem>);
			try
			{
				enumerator2 = CompItemList.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					enumerator2.Current.Checked = TargetStatus;
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
		}
		SelectedItemList = Enumerable.ToList<MyListItem>(Enumerable.Where<MyListItem>((System.Collections.Generic.IEnumerable<MyListItem>)CompItemList, (Func<MyListItem, bool>)([SpecialName] (MyListItem e) => e.Checked)));
	}

	private void Items_CancelFavorites(MyListItem Item)
	{
		try
		{
			CompItemList.Remove(Item);
			if (SelectedItemList.Contains(Item))
			{
				SelectedItemList.Remove(Item);
			}
			if (SearchResult.Contains(Item))
			{
				SearchResult.Remove(Item);
			}
			CurrentFavTarget.Favs.Remove(Conversions.ToString(NewLateBinding.LateGet(((FrameworkElement)Item).Tag, (System.Type)null, "Id", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
			ModComp.CompFavorites.Save();
			if (!Enumerable.Any<MyListItem>((System.Collections.Generic.IEnumerable<MyListItem>)CompItemList))
			{
				ModMain.FrmDownloadCompFavorites.PageLoaderRestart();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "[CompFavourites] 移除收藏时发生错误");
			ProjectData.ClearProjectError();
		}
	}

	private void Page_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		if (Keyboard.IsKeyDown((Key)118) || (Keyboard.IsKeyDown((Key)119) && (int)e.Key == 44))
		{
			Items_SetSelectAll(TargetStatus: true);
		}
	}

	private void Manage_Click(object sender, MouseButtonEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		ContextMenu val = new ContextMenu();
		MyMenuItem myMenuItem = new MyMenuItem();
		((HeaderedItemsControl)myMenuItem).Header = "分享当前收藏夹";
		((MenuItem)myMenuItem).Icon = "M768.704 703.616c-35.648 0-67.904 14.72-91.136 38.304l-309.152-171.712c9.056-17.568 14.688-37.184 14.688-58.272 0-12.576-2.368-24.48-5.76-35.936l304.608-189.152c22.688 20.416 52.384 33.184 85.216 33.184 70.592 0 128-57.408 128-128s-57.408-128-128-128-128 57.408-128 128c0 14.56 2.976 28.352 7.456 41.408l-301.824 187.392c-23.136-22.784-54.784-36.928-89.728-36.928-70.592 0-128 57.408-128 128 0 70.592 57.408 128 128 128 25.664 0 49.504-7.744 69.568-20.8l321.216 178.4c-3.04 10.944-5.184 22.208-5.184 34.08 0 70.592 57.408 128 128 128s128-57.408 128-128S839.328 703.616 768.704 703.616zM767.2 128.032c35.296 0 64 28.704 64 64s-28.704 64-64 64-64-28.704-64-64S731.904 128.032 767.2 128.032zM191.136 511.936c0-35.296 28.704-64 64-64s64 28.704 64 64c0 35.296-28.704 64-64 64S191.136 547.232 191.136 511.936zM768.704 895.616c-35.296 0-64-28.704-64-64s28.704-64 64-64 64 28.704 64 64S804 895.616 768.704 895.616z";
		MyMenuItem myMenuItem2 = myMenuItem;
		((MenuItem)myMenuItem2).Click += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			_Lambda_0024__29_002D0();
		});
		((ItemsControl)val).Items.Add((object)myMenuItem2);
		MyMenuItem myMenuItem3 = new MyMenuItem();
		((HeaderedItemsControl)myMenuItem3).Header = "导入收藏";
		((MenuItem)myMenuItem3).Icon = "M512.277 954.412c-118.89 0-230.659-46.078-314.73-129.73S67.12 629.666 67.12 511.222s46.327-229.744 130.398-313.427 195.82-129.73 314.73-129.73 230.659 46.078 314.72 129.73S957.397 392.81 957.397 511.183 911.078 740.96 826.97 824.642s-195.8 129.77-314.692 129.77z m0-822.784c-101.972 0-197.809 39.494-269.865 111.222s-111.7 166.997-111.7 268.373 39.653 196.695 111.67 268.335S410.246 890.78 512.248 890.78s197.809-39.484 269.865-111.222 111.7-166.998 111.67-268.374c-0.03-101.375-39.654-196.665-111.67-268.303S614.22 131.628 512.277 131.628z m222.585 347.8H544.073V288.64c-0.76-17.561-15.613-31.18-33.173-30.419-16.495 0.714-29.704 13.924-30.419 30.419v190.787H289.703c-17.56 0.761-31.179 15.614-30.419 33.174 0.715 16.494 13.924 29.703 30.42 30.418H480.48v190.788c0.761 17.56 15.614 31.179 33.174 30.419 16.494-0.715 29.703-13.925 30.418-30.42V543.02h190.788c17.56 0.762 32.413-12.857 33.173-30.418 0.762-17.561-12.858-32.414-30.419-33.174a31.683 31.683 0 0 0-2.753 0z";
		myMenuItem2 = myMenuItem3;
		((MenuItem)myMenuItem2).Click += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			_Lambda_0024__29_002D1();
		});
		((ItemsControl)val).Items.Add((object)myMenuItem2);
		MyMenuItem myMenuItem4 = new MyMenuItem();
		((HeaderedItemsControl)myMenuItem4).Header = "新建收藏夹";
		((MenuItem)myMenuItem4).Icon = "M103.331925 384.978025l25.805736 0L129.137661 161.847132c0-18.313088 14.905478-33.718963 33.718963-33.718963l0.969071 0 253.006318 0c10.82044 0 20.218484 4.797259 26.500561 12.257162l117.579929 126.753869 297.819966 0c18.297738 0 33.736359 15.179724 33.736359 33.977859l0 0.952698 0 82.909292 25.547863 0c18.538215 0 34.187637 15.179724 34.187637 33.977859 0 2.163269-0.469698 3.617387-0.469698 5.539156l-54.437843 432.971086c-1.210571 10.382465-7.007601 19.056008-14.968923 24.352641-6.249331 5.765307-14.680351 9.624195-23.595394 9.624195l-0.969071 0-694.906773 0c-9.155521 0-17.344017-3.858888-23.626094-9.155521-8.67252-5.765307-14.453177-14.939247-15.389502-25.758664L69.597613 423.040922c-2.165316-18.313088 10.868535-35.414581 29.665647-38.062897L103.331925 384.978025 103.331925 384.978025zM196.576609 384.978025 196.576609 384.978025l627.938546 0 0-49.625234L546.461371 335.352791l0 0c-9.400091 0-18.329461-4.117784-25.048489-11.110035L402.363486 196.067514 196.576609 196.067514 196.576609 384.978025 196.576609 384.978025zM879.469767 452.916347 879.469767 452.916347l-20.267603 0-0.469698 0-0.969071 0-694.906773 0-0.984421 0-20.218484 0 45.781696 366.728382 646.218888 0L879.469767 452.916347 879.469767 452.916347z";
		myMenuItem2 = myMenuItem4;
		((MenuItem)myMenuItem2).Click += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			_Lambda_0024__29_002D2();
		});
		((ItemsControl)val).Items.Add((object)myMenuItem2);
		MyMenuItem myMenuItem5 = new MyMenuItem();
		((HeaderedItemsControl)myMenuItem5).Header = "重命名收藏夹名称";
		((MenuItem)myMenuItem5).Icon = "M732.64 64.32C688.576 21.216 613.696 21.216 569.6 64.32L120.128 499.52c-17.6 12.896-26.432 30.144-30.848 51.68L32 870.048c0 25.856 8.8 56 26.432 73.248 17.632 17.216 17.632 48.704 88.64 48.704h13.248l326.08-56c22.016-4.32 39.68-12.928 52.864-30.176l449.472-435.2c22.048-21.536 35.264-47.36 35.264-77.536 0-30.176-13.216-56-35.264-77.568l-256.096-251.2zM139.712 903.776l56-326.912 311.04-295.136 267.104 269.44-310.976 295.168-323.168 57.44zM844.576 467.84l-273.984-260.672 61.856-59.84c8.832-8.512 26.528-8.512 39.776 0l234.24 226.496c4.384 4.288 8.832 12.8 8.832 17.088s-4.416 8.544-8.864 12.8l-61.856 64.128z";
		myMenuItem2 = myMenuItem5;
		((MenuItem)myMenuItem2).Click += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			_Lambda_0024__29_002D3();
		});
		((ItemsControl)val).Items.Add((object)myMenuItem2);
		MyMenuItem myMenuItem6 = new MyMenuItem();
		((HeaderedItemsControl)myMenuItem6).Header = "删除当前收藏夹";
		((MenuItem)myMenuItem6).Icon = "M520.192 0C408.43 0 317.44 82.87 313.563 186.734H52.736c-29.038 0-52.663 21.943-52.663 49.079s23.625 49.152 52.663 49.152h58.075v550.473c0 103.35 75.118 187.757 167.717 187.757h472.43c92.599 0 167.716-83.894 167.716-187.757V285.477h52.59c29.038 0 52.59-21.943 52.663-49.08-0.073-27.135-23.625-49.151-52.663-49.151H726.235C723.237 83.017 631.955 0 520.192 0zM404.846 177.957c3.803-50.03 50.176-89.015 107.447-89.015 57.197 0 103.57 38.985 106.788 89.015H404.92zM284.379 933.669c-33.353 0-69.997-39.351-69.997-95.525v-549.01H833.39v549.522c0 56.247-36.645 95.525-69.998 95.525H284.379v-0.512z M357.23 800.695a48.274 48.274 0 0 0 47.616-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.69 49.006V751.69c0 27.282 20.846 49.006 47.617 49.006z m166.62 0a48.274 48.274 0 0 0 47.688-49.006V471.7a48.274 48.274 0 0 0-47.689-49.08 48.274 48.274 0 0 0-47.543 49.006V751.69c0 27.282 21.431 49.006 47.543 49.006z m142.92 0a48.274 48.274 0 0 0 47.543-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.616 49.006V751.69c0 27.282 20.773 49.006 47.543 49.006z";
		myMenuItem2 = myMenuItem6;
		((MenuItem)myMenuItem2).Click += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			_Lambda_0024__29_002D4();
		});
		((ItemsControl)val).Items.Add((object)myMenuItem2);
		val.PlacementTarget = (UIElement)sender;
		val.Placement = (PlacementMode)2;
		val.IsOpen = true;
	}

	private void ComboTargetFav_Selected(object sender, RoutedEventArgs e)
	{
		if (((Selector)ComboTargetFav).SelectedItem != null)
		{
			Items_SetSelectAll(TargetStatus: false);
			Loader.Start(null, IsForceRestart: true);
		}
	}

	private void HintGetFail_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00e4: Expected O, but got Unknown
		_Closure_0024__31_002D0 arg = default(_Closure_0024__31_002D0);
		_Closure_0024__31_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__31_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
		string text = "由于在线资源被删除或者网络问题等因素导致以下资源未获取成功（以资源的 ID 展示）\r\n\r\n";
		CS_0024_003C_003E8__locals0._0024VB_0024Local_FailIds = Enumerable.ToList<string>(Enumerable.Except<string>((System.Collections.Generic.IEnumerable<string>)Loader.Input, (System.Collections.Generic.IEnumerable<string>)Enumerable.ToList<string>(Enumerable.Select<ModComp.CompProject, string>((System.Collections.Generic.IEnumerable<ModComp.CompProject>)Loader.Output, (Func<ModComp.CompProject, string>)([SpecialName] (ModComp.CompProject i) => i.Id)))));
		System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator = CS_0024_003C_003E8__locals0._0024VB_0024Local_FailIds.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				text = text + $" - {current}" + "\r\n";
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		ModMain.MyMsgBox(text, "部分收藏项目获取失败", "确定", "复制这些 ID", "移除这些收藏", IsWarn: false, HighLight: true, ForceWait: false, null, (Action)([SpecialName] () =>
		{
			ModBase.ClipboardSet(ModBase.Join((System.Collections.IEnumerable)CS_0024_003C_003E8__locals0._0024VB_0024Local_FailIds, "\r\n"));
		}), (Action)([SpecialName] () =>
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			System.Collections.Generic.IEnumerator<string> enumerator2 = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator2 = CS_0024_003C_003E8__locals0._0024VB_0024Local_FailIds.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					string current2 = enumerator2.Current;
					CS_0024_003C_003E8__locals0._0024VB_0024Me.CurrentFavTarget.Favs.Remove(current2);
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			ModComp.CompFavorites.Save();
			ModMain.Hint("已移除相关收藏", ModMain.HintType.Finish);
		}));
	}

	public void SearchRun()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		if (!AllowSearch)
		{
			return;
		}
		if (IsSearching)
		{
			List<ModBase.SearchEntry<MyListItem>> val = new List<ModBase.SearchEntry<MyListItem>>();
			System.Collections.Generic.IEnumerator<MyListItem> enumerator = default(System.Collections.Generic.IEnumerator<MyListItem>);
			try
			{
				enumerator = CompItemList.GetEnumerator();
				while (enumerator.MoveNext())
				{
					MyListItem current = enumerator.Current;
					if (((FrameworkElement)current).Tag is ModComp.CompProject)
					{
						ModComp.CompProject compProject = (ModComp.CompProject)((FrameworkElement)current).Tag;
						List<KeyValuePair<string, double>> val2 = new List<KeyValuePair<string, double>>();
						val2.Add(new KeyValuePair<string, double>(compProject.RawName, 1.0));
						if (compProject.Description != null && Operators.CompareString(compProject.Description, "", false) != 0)
						{
							val2.Add(new KeyValuePair<string, double>(compProject.Description, 0.4));
						}
						if (Operators.CompareString(compProject.TranslatedName, compProject.RawName, false) != 0)
						{
							val2.Add(new KeyValuePair<string, double>(compProject.TranslatedName, 1.0));
						}
						val2.Add(new KeyValuePair<string, double>(string.Join("", (System.Collections.Generic.IEnumerable<string>)compProject.Tags), 0.2));
						val.Add(new ModBase.SearchEntry<MyListItem>
						{
							Item = current,
							SearchSource = val2
						});
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			SearchResult = Enumerable.ToList<MyListItem>(Enumerable.Select<ModBase.SearchEntry<MyListItem>, MyListItem>((System.Collections.Generic.IEnumerable<ModBase.SearchEntry<MyListItem>>)ModBase.Search<MyListItem>(val, PanSearchBox.Text, 6, 0.35), (Func<ModBase.SearchEntry<MyListItem>, MyListItem>)([SpecialName] (ModBase.SearchEntry<MyListItem> r) => r.Item)));
		}
		RefreshContent();
		RefreshCardTitle();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagedownload/pagedownloadcompfavorites.xaml", (UriKind)2);
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
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanContent = (Grid)target;
			break;
		case 3:
			PanSearchBox = (MySearchBox)target;
			break;
		case 4:
			ComboTargetFav = (MyComboBox)target;
			break;
		case 5:
			Btn_ManageTargetFav = (MyIconButton)target;
			break;
		case 6:
			HintGetFail = (MyHint)target;
			break;
		case 7:
			PanContentList = (StackPanel)target;
			break;
		case 8:
			CardNoContent = (MyCard)target;
			break;
		case 9:
			CardSelect = (MyCard)target;
			break;
		case 10:
			TransSelect = (TranslateTransform)target;
			break;
		case 11:
			LabSelect = (TextBlock)target;
			break;
		case 12:
			Btn_FavoritesCancel = (MyIconTextButton)target;
			break;
		case 13:
			Btn_FavoritesShare = (MyIconTextButton)target;
			break;
		case 14:
			Btn_FavoritesDownload = (MyIconTextButton)target;
			break;
		case 15:
			Btn_SelectCancel = (MyIconTextButton)target;
			break;
		case 16:
			PanLoad = (MyCard)target;
			break;
		case 17:
			Load = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__29_002D0()
	{
		try
		{
			if (CurrentFavTarget.Favs.Count == 0)
			{
				ModMain.Hint("分享了个寂寞啊！");
			}
			else
			{
				ModBase.ClipboardSet(ModComp.CompFavorites.GetShareCode(CurrentFavTarget.Favs));
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "[Favourites] 分享收藏时发生错误", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__29_002D1()
	{
		try
		{
			string text = ModMain.MyMsgBoxInput("输入分享的收藏", "", "", null, "例如 [\"23333\"]");
			if (string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			List<string> idsByShareCode = ModComp.CompFavorites.GetIdsByShareCode(text);
			if (idsByShareCode.Count == 0)
			{
				ModMain.Hint("分享了个寂寞啊！");
				return;
			}
			switch (ModMain.MyMsgBox("你希望将分享的收藏加入到当前收藏夹还是新的收藏夹中？", "提示", "新的收藏夹", "当前收藏夹"))
			{
			case 1:
			{
				string text2 = ModMain.MyMsgBoxInput("新收藏夹名称", "请输入新收藏夹名称");
				if (!string.IsNullOrWhiteSpace(text2))
				{
					ModComp.CompFavorites.FavoritesList.Add(ModComp.CompFavorites.GetNewFav(text2, idsByShareCode));
					ModComp.CompFavorites.Save();
					RefreshFavTargets();
					((Selector)ComboTargetFav).SelectedIndex = checked(((ItemsControl)ComboTargetFav).Items.Count - 1);
				}
				break;
			}
			case 2:
				CurrentFavTarget.Favs.AddRange((System.Collections.Generic.IEnumerable<string>)idsByShareCode);
				Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)CurrentFavTarget.Favs);
				ModComp.CompFavorites.Save();
				Loader.Start(null, IsForceRestart: true);
				break;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "解析分享数据失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__29_002D2()
	{
		string text = ModMain.MyMsgBoxInput("新建收藏夹", "请输入新收藏夹名称");
		if (!string.IsNullOrWhiteSpace(text))
		{
			ModComp.CompFavorites.FavoritesList.Add(ModComp.CompFavorites.GetNewFav(text, null));
			ModComp.CompFavorites.Save();
			RefreshFavTargets();
			((Selector)ComboTargetFav).SelectedIndex = checked(((ItemsControl)ComboTargetFav).Items.Count - 1);
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__29_002D3()
	{
		string text = ModMain.MyMsgBoxInput("输入新名称", "", CurrentFavTarget.Name);
		if (!string.IsNullOrWhiteSpace(text) && Operators.CompareString(CurrentFavTarget.Name, text, false) != 0)
		{
			CurrentFavTarget.Name = text;
			ModComp.CompFavorites.Save();
			RefreshFavTargets();
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__29_002D4()
	{
		if (ModComp.CompFavorites.FavoritesList.Count == 1)
		{
			ModMain.Hint("您不能删除最后一个收藏夹");
		}
		else if (ModMain.MyMsgBox(string.Concat(string.Concat(string.Concat($"确认删除 {CurrentFavTarget.Name} 收藏夹？" + "\r\n\r\n", $"此收藏夹有 {CurrentFavTarget.Favs.Count} 个收藏项目", "\r\n"), "收藏夹 ID 为 ", CurrentFavTarget.Id, "\r\n"), "此操作不可逆！"), "删除确认", "否", "是", "否", IsWarn: true) == 2)
		{
			ModComp.CompFavorites.FavoritesList.Remove(CurrentFavTarget);
			ModComp.CompFavorites.Save();
			ModMain.Hint("已删除收藏夹", ModMain.HintType.Finish);
			RefreshFavTargets();
			((Selector)ComboTargetFav).SelectedIndex = 0;
		}
	}
}
