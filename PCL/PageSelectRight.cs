using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using PCL.Core.App;

namespace PCL;

[DesignerGenerated]
public class PageSelectRight : MyPageRight, IComponentConnector
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__13_002D0
	{
		public string _0024VB_0024Local_searchText;

		public Func<ModMinecraft.McInstance, bool> _0024I1;

		public _Closure_0024__13_002D0(_Closure_0024__13_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_searchText = arg0._0024VB_0024Local_searchText;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__1(ModMinecraft.McInstance v)
		{
			if (string.IsNullOrEmpty(_0024VB_0024Local_searchText))
			{
				return true;
			}
			return v.Name.ToLower().Contains(_0024VB_0024Local_searchText) || (v.Info != null && v.Info.ToLower().Contains(_0024VB_0024Local_searchText)) || v.GetDefaultDescription().Replace(",", "").ToLower()
				.Trim()
				.Contains(_0024VB_0024Local_searchText);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__15_002D0
	{
		public ModMinecraft.McInstance _0024VB_0024Local_Version;

		public MyListItem _0024VB_0024Local_sender;

		[SpecialName]
		internal void _Lambda_0024__R5(object a0, EventArgs a1)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			Config.Instance.Starred[_0024VB_0024Local_Version.Path] = !_0024VB_0024Local_Version.IsStar;
			ModMinecraft.McInstanceListForceRefresh = true;
			ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
		}

		[SpecialName]
		internal void _Lambda_0024__R6(object a0, EventArgs a1)
		{
			_Lambda_0024__1();
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			DeleteVersion(_0024VB_0024Local_sender, _0024VB_0024Local_Version);
		}

		[SpecialName]
		internal void _Lambda_0024__R7(object a0, EventArgs a1)
		{
			_Lambda_0024__2();
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			PageInstanceLeft.Instance = _0024VB_0024Local_Version;
			ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSetup);
		}

		[SpecialName]
		internal void _Lambda_0024__R8(object a0, MouseButtonEventArgs a1)
		{
			_Lambda_0024__3();
		}

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			PageInstanceLeft.Instance = _0024VB_0024Local_Version;
			ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSetup);
		}

		[SpecialName]
		internal void _Lambda_0024__R9(object a0, EventArgs a1)
		{
			_Lambda_0024__4();
		}

		[SpecialName]
		internal void _Lambda_0024__4()
		{
			PageInstanceOverall.OpenVersionFolder(_0024VB_0024Local_Version);
		}

		[SpecialName]
		internal void _Lambda_0024__R10(object a0, MouseButtonEventArgs a1)
		{
			_Lambda_0024__5();
		}

		[SpecialName]
		internal void _Lambda_0024__5()
		{
			PageInstanceOverall.OpenVersionFolder(_0024VB_0024Local_Version);
		}
	}

	private System.DateTime LastInputTime;

	private DispatcherTimer ReloadTimer;

	private const int NormalDelay = 75;

	private const int QuickDelay = 50;

	private bool IsRefreshing;

	public bool ShowHidden;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnEmptyDownload")]
	private MyButton _BtnEmptyDownload;

	[CompilerGenerated]
	[AccessedThroughProperty("Load")]
	private MyLoading _Load;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanAllBack")]
	internal virtual Grid PanAllBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanVerSearchBox")]
	internal virtual MySearchBox PanVerSearchBox
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

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

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabEmptyTitle")]
	internal virtual TextBlock LabEmptyTitle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabEmptyContent")]
	internal virtual TextBlock LabEmptyContent
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnEmptyDownload
	{
		[CompilerGenerated]
		get
		{
			return _BtnEmptyDownload;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MyButton.ClickEventHandler obj = BtnDownload_Click;
			RoutedEventHandler val = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				BtnEmptyDownload_Loaded();
			});
			MyButton btnEmptyDownload = _BtnEmptyDownload;
			if (btnEmptyDownload != null)
			{
				btnEmptyDownload.Click -= obj;
				((FrameworkElement)btnEmptyDownload).Loaded -= val;
			}
			_BtnEmptyDownload = value;
			btnEmptyDownload = _BtnEmptyDownload;
			if (btnEmptyDownload != null)
			{
				btnEmptyDownload.Click += obj;
				((FrameworkElement)btnEmptyDownload).Loaded += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanEmptySearch")]
	internal virtual MyCard PanEmptySearch
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabEmptySearchTitle")]
	internal virtual TextBlock LabEmptySearchTitle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabEmptySearchContent")]
	internal virtual TextBlock LabEmptySearchContent
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
			MyLoading.ClickEventHandler obj = Load_Click;
			MyLoading load = _Load;
			if (load != null)
			{
				load.Click -= obj;
			}
			_Load = value;
			load = _Load;
			if (load != null)
			{
				load.Click += obj;
			}
		}
	}

	public PageSelectRight()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageSelectRight_Loaded);
		((FrameworkElement)this).Unloaded += new RoutedEventHandler(PageSelectRight_Unloaded);
		((FrameworkElement)this).Initialized += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			LoaderInit();
		});
		LastInputTime = System.DateTime.MinValue;
		IsRefreshing = false;
		ShowHidden = false;
		InitializeComponent();
	}

	private void PageSelectRight_Loaded(object sender, RoutedEventArgs e)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.RunOnUpdated, 1, "versions\\");
		((ScrollViewer)PanBack).ScrollToHome();
		PanVerSearchBox.TextChanged += [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			PanVerSearchBox_TextChanged(RuntimeHelpers.GetObjectValue(a0), (TextChangedEventArgs)a1);
		};
		ReloadTimer = new DispatcherTimer
		{
			Interval = TimeSpan.FromMilliseconds(75.0)
		};
		ReloadTimer.Tick += new EventHandler(ReloadTimer_Tick);
	}

	private void PanVerSearchBox_TextChanged(object sender, TextChangedEventArgs e)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		LastInputTime = System.DateTime.Now;
		IsRefreshing = false;
		TimeSpan interval;
		if (string.IsNullOrWhiteSpace(PanVerSearchBox.Text))
		{
			interval = ReloadTimer.Interval;
			if (interval.TotalMilliseconds != 50.0)
			{
				ReloadTimer.Interval = TimeSpan.FromMilliseconds(50.0);
			}
		}
		else
		{
			interval = ReloadTimer.Interval;
			if (interval.TotalMilliseconds != 75.0)
			{
				ReloadTimer.Interval = TimeSpan.FromMilliseconds(75.0);
			}
		}
		if (!ReloadTimer.IsEnabled)
		{
			ReloadTimer.Start();
		}
	}

	private void ReloadTimer_Tick(object sender, EventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		TimeSpan val = System.DateTime.Now - LastInputTime;
		double totalMilliseconds = val.TotalMilliseconds;
		val = ReloadTimer.Interval;
		double totalMilliseconds2 = val.TotalMilliseconds;
		if (totalMilliseconds >= totalMilliseconds2 && ModMinecraft.McInstanceListLoader.State == ModBase.LoadState.Finished && !IsRefreshing)
		{
			IsRefreshing = true;
			((DispatcherObject)this).Dispatcher.BeginInvoke((System.Delegate)(VB_0024AnonymousDelegate_8)([SpecialName] [CompilerGenerated] () =>
			{
				McInstanceListUI(ModMinecraft.McInstanceListLoader);
				IsRefreshing = false;
			}), new object[0]);
			ReloadTimer.Stop();
		}
	}

	private void PageSelectRight_Unloaded(object sender, RoutedEventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		if (ReloadTimer != null)
		{
			ReloadTimer.Stop();
			ReloadTimer.Tick -= new EventHandler(ReloadTimer_Tick);
			ReloadTimer = null;
		}
	}

	private void LoaderInit()
	{
		PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanAllBack, null, ModMinecraft.McInstanceListLoader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
		{
			McInstanceListUI((ModLoader.LoaderTask<string, int>)a0);
		}, null, AutoRun: false);
	}

	private void Load_Click(object sender, MouseButtonEventArgs e)
	{
		if (ModMinecraft.McInstanceListLoader.State == ModBase.LoadState.Failed)
		{
			ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
		}
	}

	private void McInstanceListUI(ModLoader.LoaderTask<string, int> Loader)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Expected O, but got Unknown
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Expected O, but got Unknown
		try
		{
			_Closure_0024__13_002D0 arg = default(_Closure_0024__13_002D0);
			_Closure_0024__13_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__13_002D0(null);
			_ = Loader.Input;
			((Panel)PanMain).Children.Clear();
			bool flag = false;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_searchText = PanVerSearchBox.Text.Trim().ToLower();
			bool flag2 = false;
			bool flag3 = Enumerable.Any<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>((System.Collections.Generic.IEnumerable<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>)Enumerable.ToArray<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>((System.Collections.Generic.IEnumerable<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>)ModMinecraft.McInstanceList), (Func<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>, bool>)([SpecialName] (KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>> c) => c.Value.Count > 0));
			((UIElement)PanEmptySearch).Visibility = (Visibility)2;
			KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>[] array = Enumerable.ToArray<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>((System.Collections.Generic.IEnumerable<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>)ModMinecraft.McInstanceList);
			System.Collections.Generic.IEnumerator<ModMinecraft.McInstance> enumerator = default(System.Collections.Generic.IEnumerator<ModMinecraft.McInstance>);
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>> val = array[i];
				if ((val.Key == ModMinecraft.McInstanceCardType.Hidden) ^ ShowHidden)
				{
					continue;
				}
				List<ModMinecraft.McInstance> val2 = Enumerable.ToList<ModMinecraft.McInstance>(Enumerable.Where<ModMinecraft.McInstance>((System.Collections.Generic.IEnumerable<ModMinecraft.McInstance>)val.Value, (Func<ModMinecraft.McInstance, bool>)([SpecialName] (ModMinecraft.McInstance v) => string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Local_searchText) || v.Name.ToLower().Contains(CS_0024_003C_003E8__locals0._0024VB_0024Local_searchText) || (v.Info != null && v.Info.ToLower().Contains(CS_0024_003C_003E8__locals0._0024VB_0024Local_searchText)) || v.GetDefaultDescription().Replace(",", "").ToLower()
					.Trim()
					.Contains(CS_0024_003C_003E8__locals0._0024VB_0024Local_searchText))));
				if (val2.Count == 0)
				{
					continue;
				}
				flag = true;
				flag2 = true;
				if (val2.Count == 0)
				{
					continue;
				}
				flag = true;
				string text = "";
				switch (val.Key)
				{
				case ModMinecraft.McInstanceCardType.OriginalLike:
					text = "常规实例";
					break;
				case ModMinecraft.McInstanceCardType.API:
				{
					bool flag4 = false;
					bool flag5 = false;
					bool flag6 = false;
					bool flag7 = false;
					bool flag8 = false;
					bool flag9 = false;
					bool flag10 = false;
					try
					{
						enumerator = val.Value.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ModMinecraft.McInstance current = enumerator.Current;
							if (current.Version.HasFabric)
							{
								flag6 = true;
							}
							if (current.Version.HasQuilt)
							{
								flag7 = true;
							}
							if (current.Version.HasLiteLoader)
							{
								flag8 = true;
							}
							if (current.Version.HasForge)
							{
								flag4 = true;
							}
							if (current.Version.HasNeoForge)
							{
								flag5 = true;
							}
							if (current.Version.HasCleanroom)
							{
								flag9 = true;
							}
							if (current.Version.HasLabyMod)
							{
								flag10 = true;
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator).Dispose();
					}
					text = ((checked((flag8 ? 1 : 0) + (flag4 ? 1 : 0) + (flag6 ? 1 : 0) + (flag5 ? 1 : 0) + (flag7 ? 1 : 0) + (flag9 ? 1 : 0) + (flag10 ? 1 : 0)) <= 1) ? ((!flag4) ? ((!flag5) ? ((!flag9) ? ((!flag10) ? ((!flag8) ? ((!flag7) ? "Fabric 实例" : "Quilt 实例") : "LiteLoader 实例") : "LabyMod 实例") : "Cleanroom 实例") : "NeoForge 实例") : "Forge 实例") : "可安装 Mod");
					break;
				}
				case ModMinecraft.McInstanceCardType.Error:
					text = "错误的实例";
					break;
				case ModMinecraft.McInstanceCardType.Hidden:
					text = "隐藏的实例";
					break;
				case ModMinecraft.McInstanceCardType.Rubbish:
					text = "不常用实例";
					break;
				case ModMinecraft.McInstanceCardType.Star:
					text = "收藏夹";
					break;
				case ModMinecraft.McInstanceCardType.Fool:
					text = "愚人节版本";
					break;
				default:
					throw new ArgumentException("未知的卡片种类（" + Conversions.ToString((int)val.Key) + "）");
				}
				string title = text + ((Operators.CompareString(text, "收藏夹", false) == 0) ? "" : (" (" + Conversions.ToString(val2.Count) + ")"));
				MyCard obj = new MyCard
				{
					Title = title
				};
				((FrameworkElement)obj).Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
				MyCard myCard = obj;
				StackPanel Stack2 = new StackPanel
				{
					Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
					VerticalAlignment = (VerticalAlignment)0,
					RenderTransform = (Transform)new TranslateTransform(0.0, 0.0),
					Tag = val2
				};
				((Panel)myCard).Children.Add((UIElement)(object)Stack2);
				myCard.SwapControl = Stack2;
				((Panel)PanMain).Children.Add((UIElement)(object)myCard);
				VB_0024AnonymousDelegate_15<StackPanel> vB_0024AnonymousDelegate_ = [SpecialName] (StackPanel Stack) =>
				{
					foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(item);
						((Panel)Stack).Children.Add((UIElement)(object)McVersionListItem((ModMinecraft.McInstance)objectValue));
					}
				};
				if (val.Key == ModMinecraft.McInstanceCardType.Rubbish || val.Key == ModMinecraft.McInstanceCardType.Error || val.Key == ModMinecraft.McInstanceCardType.Fool)
				{
					myCard.IsSwapped = true;
					VB_0024AnonymousDelegate_15<StackPanel> vB_0024AnonymousDelegate_2 = vB_0024AnonymousDelegate_;
					myCard.InstallMethod = ((vB_0024AnonymousDelegate_2 == null) ? null : new Action<StackPanel>(vB_0024AnonymousDelegate_2.Invoke));
				}
				else
				{
					VB_0024AnonymousDelegate_15<StackPanel> vB_0024AnonymousDelegate_2 = vB_0024AnonymousDelegate_;
					MyCard.StackInstall(ref Stack2, (vB_0024AnonymousDelegate_2 == null) ? null : new Action<StackPanel>(vB_0024AnonymousDelegate_2.Invoke));
				}
			}
			if (((Panel)PanMain).Children.Count == 1 && ((MyCard)(object)((Panel)PanMain).Children[0]).IsSwapped)
			{
				((MyCard)(object)((Panel)PanMain).Children[0]).IsSwapped = false;
			}
			((UIElement)PanVerSearchBox).Visibility = (Visibility)((!flag) ? 2 : 0);
			if (!flag2)
			{
				if (!flag3)
				{
					((UIElement)PanEmpty).Visibility = (Visibility)0;
					((UIElement)PanBack).Visibility = (Visibility)2;
					if (ShowHidden)
					{
						LabEmptyTitle.Text = "无隐藏实例";
						LabEmptyContent.Text = "没有实例被隐藏，你可以在实例设置的实例分类选项中隐藏实例。\r\n再次按下 F11 即可退出隐藏实例查看模式。";
						((UIElement)BtnEmptyDownload).Visibility = (Visibility)2;
					}
					else
					{
						LabEmptyTitle.Text = "无可用实例";
						LabEmptyContent.Text = "未找到任何游戏实例，请先下载一个游戏实例。\r\n若有已存在的实例，请在左边的列表中选择添加文件夹，选择 .minecraft 文件夹将其导入。";
						((UIElement)BtnEmptyDownload).Visibility = (Visibility)(Conversions.ToBoolean((object)(Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenPageDownload")) && !PageSetupUI.HiddenForceShow)) ? 2 : 0);
					}
				}
				else if (ShowHidden && Enumerable.Any<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>((System.Collections.Generic.IEnumerable<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>)Enumerable.ToArray<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>((System.Collections.Generic.IEnumerable<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>)ModMinecraft.McInstanceList), (Func<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>, bool>)([SpecialName] (KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>> c) => c.Key == ModMinecraft.McInstanceCardType.Hidden && c.Value.Count > 0)))
				{
					((UIElement)PanVerSearchBox).Visibility = (Visibility)0;
					((UIElement)PanEmpty).Visibility = (Visibility)2;
					((UIElement)PanBack).Visibility = (Visibility)0;
					((UIElement)PanEmptySearch).Visibility = (Visibility)0;
					LabEmptySearchTitle.Text = "无匹配的隐藏实例";
					LabEmptySearchContent.Text = (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0._0024VB_0024Local_searchText) ? "请输入搜索内容" : $"没有找到与 '{CS_0024_003C_003E8__locals0._0024VB_0024Local_searchText}' 匹配的隐藏实例");
				}
				else if (ShowHidden)
				{
					((UIElement)PanEmpty).Visibility = (Visibility)0;
					((UIElement)PanBack).Visibility = (Visibility)2;
					LabEmptyTitle.Text = "无隐藏实例";
					LabEmptyContent.Text = "没有实例被隐藏，你可以在实例设置的实例分类选项中隐藏实例。\r\n再次按下 F11 即可退出隐藏实例查看模式。";
					((UIElement)BtnEmptyDownload).Visibility = (Visibility)2;
					((UIElement)PanVerSearchBox).Visibility = (Visibility)2;
				}
				else
				{
					((UIElement)PanVerSearchBox).Visibility = (Visibility)0;
					((UIElement)PanEmpty).Visibility = (Visibility)2;
					((UIElement)PanBack).Visibility = (Visibility)0;
					((UIElement)PanEmptySearch).Visibility = (Visibility)0;
					LabEmptySearchTitle.Text = "无匹配的游戏实例";
					LabEmptySearchContent.Text = (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0._0024VB_0024Local_searchText) ? "请输入搜索内容" : $"没有找到与 '{CS_0024_003C_003E8__locals0._0024VB_0024Local_searchText}' 匹配的实例");
				}
			}
			else
			{
				((UIElement)PanBack).Visibility = (Visibility)0;
				((UIElement)PanEmpty).Visibility = (Visibility)2;
				((UIElement)PanEmptySearch).Visibility = (Visibility)2;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "将实例列表转换显示时失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public static MyListItem McVersionListItem(ModMinecraft.McInstance instance)
	{
		MyListItem obj = new MyListItem
		{
			Title = instance.Name,
			Info = instance.Info
		};
		((FrameworkElement)obj).Height = 42.0;
		((FrameworkElement)obj).Tag = instance;
		((UIElement)obj).SnapsToDevicePixels = true;
		obj.Type = MyListItem.CheckType.Clickable;
		MyListItem myListItem = obj;
		ModMinecraft.McInstanceInfo version = instance.Version;
		List<string> val = new List<string>();
		val.Add(version.McName);
		if (version.HasForge)
		{
			val.Add("Forge " + version.ForgeVersion);
		}
		else if (version.HasNeoForge)
		{
			val.Add("NeoForge " + version.NeoForgeVersion);
		}
		else if (version.HasCleanroom)
		{
			val.Add("Cleanroom " + version.CleanroomVersion);
		}
		else if (version.HasLabyMod)
		{
			val.Add("LabyMod " + version.LabyModVersion);
		}
		else if (version.HasQuilt)
		{
			val.Add("Quilt " + version.QuiltVersion);
		}
		else if (version.HasFabric)
		{
			val.Add("Fabric " + version.FabricVersion);
		}
		if (version.HasLiteLoader)
		{
			val.Add("LiteLoader");
		}
		if (version.HasOptiFine)
		{
			val.Add("OptiFine " + version.OptiFineVersion);
		}
		myListItem.Tags = val;
		try
		{
			if (instance.Logo.EndsWith("PCL\\Logo.png"))
			{
				myListItem.Logo = instance.Path + "PCL\\Logo.png";
			}
			else
			{
				myListItem.Logo = instance.Logo;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "加载实例图标失败", ModBase.LogLevel.Hint);
			myListItem.Logo = "pack://application:,,,/images/Blocks/RedstoneBlock.png";
			ProjectData.ClearProjectError();
		}
		myListItem.ContentHandler = McVersionListContent;
		return myListItem;
	}

	private static void McVersionListContent(MyListItem sender, EventArgs e)
	{
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		_Closure_0024__15_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__15_002D0();
		CS_0024_003C_003E8__locals0._0024VB_0024Local_sender = sender;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Version = (ModMinecraft.McInstance)((FrameworkElement)CS_0024_003C_003E8__locals0._0024VB_0024Local_sender).Tag;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_sender.Click += [SpecialName] (object a0, MouseButtonEventArgs a1) =>
		{
			Item_Click((MyListItem)a0, (EventArgs)(object)a1);
		};
		MyIconButton myIconButton = new MyIconButton();
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Version.IsStar)
		{
			((FrameworkElement)myIconButton).ToolTip = "取消收藏";
			ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
			ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
			ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
			myIconButton.LogoScale = 1.1;
			myIconButton.Logo = "M700.856 155.543c-74.769 0-144.295 72.696-190.046 127.26-45.737-54.576-115.247-127.26-190.056-127.26-134.79 0-244.443 105.78-244.443 235.799 0 77.57 39.278 131.988 70.845 175.713C238.908 694.053 469.62 852.094 479.39 858.757c9.41 6.414 20.424 9.629 31.401 9.629 11.006 0 21.998-3.215 31.398-9.63 9.782-6.662 240.514-164.703 332.238-291.701 31.587-43.724 70.874-98.143 70.874-175.713-0.001-130.02-109.656-235.8-244.445-235.8z m0 0";
		}
		else
		{
			((FrameworkElement)myIconButton).ToolTip = "收藏";
			ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
			ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
			ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
			myIconButton.LogoScale = 1.1;
			myIconButton.Logo = "M512 896a42.666667 42.666667 0 0 1-30.293333-12.373333l-331.52-331.946667a224.426667 224.426667 0 0 1 0-315.733333 223.573333 223.573333 0 0 1 315.733333 0L512 282.026667l46.08-46.08a223.573333 223.573333 0 0 1 315.733333 0 224.426667 224.426667 0 0 1 0 315.733333l-331.52 331.946667A42.666667 42.666667 0 0 1 512 896zM308.053333 256a136.533333 136.533333 0 0 0-97.28 40.106667 138.24 138.24 0 0 0 0 194.986666L512 792.746667l301.226667-301.653334a138.24 138.24 0 0 0 0-194.986666 141.653333 141.653333 0 0 0-194.56 0l-76.373334 76.8a42.666667 42.666667 0 0 1-60.586666 0L405.333333 296.106667A136.533333 136.533333 0 0 0 308.053333 256z";
		}
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			CS_0024_003C_003E8__locals0._Lambda_0024__0();
		};
		MyIconButton myIconButton2 = new MyIconButton
		{
			LogoScale = 1.1,
			Logo = "M520.192 0C408.43 0 317.44 82.87 313.563 186.734H52.736c-29.038 0-52.663 21.943-52.663 49.079s23.625 49.152 52.663 49.152h58.075v550.473c0 103.35 75.118 187.757 167.717 187.757h472.43c92.599 0 167.716-83.894 167.716-187.757V285.477h52.59c29.038 0 52.59-21.943 52.663-49.08-0.073-27.135-23.625-49.151-52.663-49.151H726.235C723.237 83.017 631.955 0 520.192 0zM404.846 177.957c3.803-50.03 50.176-89.015 107.447-89.015 57.197 0 103.57 38.985 106.788 89.015H404.92zM284.379 933.669c-33.353 0-69.997-39.351-69.997-95.525v-549.01H833.39v549.522c0 56.247-36.645 95.525-69.998 95.525H284.379v-0.512z M357.23 800.695a48.274 48.274 0 0 0 47.616-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.69 49.006V751.69c0 27.282 20.846 49.006 47.617 49.006z m166.62 0a48.274 48.274 0 0 0 47.688-49.006V471.7a48.274 48.274 0 0 0-47.689-49.08 48.274 48.274 0 0 0-47.543 49.006V751.69c0 27.282 21.431 49.006 47.543 49.006z m142.92 0a48.274 48.274 0 0 0 47.543-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.616 49.006V751.69c0 27.282 20.773 49.006 47.543 49.006z"
		};
		((FrameworkElement)myIconButton2).ToolTip = "删除";
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton2, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton2, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton2, 2.0);
		myIconButton2.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			CS_0024_003C_003E8__locals0._Lambda_0024__1();
		};
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Version.State != 0)
		{
			MyIconButton myIconButton3 = new MyIconButton
			{
				LogoScale = 1.1,
				Logo = "M651.946667 1001.813333c-22.186667 0-42.666667-10.24-61.44-27.306666-23.893333-23.893333-49.493333-35.84-75.093334-35.84-29.013333 0-56.32 11.946667-73.386666 30.72v3.413333c-17.066667 17.066667-42.666667 27.306667-66.56 27.306667h-6.826667c-6.826667 0-11.946667-1.706667-15.36-1.706667l-6.826667-1.706667c-64.853333-20.48-121.173333-54.613333-168.96-98.986666-29.013333-23.893333-37.546667-63.146667-25.6-95.573334 8.533333-23.893333 5.12-51.2-10.24-75.093333-15.36-27.306667-34.133333-40.96-59.733333-47.786667h-1.706667l-5.12-1.706666c-35.84-8.533333-61.44-34.133333-66.56-69.973334C1.706667 575.146667 0 537.6 0 512c0-32.426667 3.413333-63.146667 8.533333-93.866667v-6.826666l3.413334-8.533334c10.24-23.893333 23.893333-40.96 44.373333-51.2 5.12-3.413333 11.946667-6.826667 20.48-8.533333 27.306667-8.533333 51.2-25.6 63.146667-44.373333 13.653333-23.893333 17.066667-52.906667 10.24-81.92-11.946667-34.133333 0-71.68 30.72-93.866667 44.373333-37.546667 97.28-68.266667 158.72-93.866667l3.413333-1.706666c44.373333-13.653333 75.093333 3.413333 92.16 20.48 23.893333 23.893333 49.493333 35.84 75.093333 35.84 30.72 0 56.32-10.24 71.68-30.72l3.413334-3.413334c27.306667-27.306667 63.146667-35.84 93.866666-22.186666 63.146667 22.186667 117.76 54.613333 165.546667 97.28 29.013333 23.893333 37.546667 63.146667 25.6 95.573333-8.533333 23.893333-5.12 51.2 10.24 75.093333 15.36 27.306667 34.133333 40.96 59.733333 47.786667h1.706667l5.12 1.706667c35.84 8.533333 61.44 34.133333 66.56 71.68 6.826667 30.72 10.24 63.146667 11.946667 93.866666v3.413334c0 32.426667-3.413333 63.146667-8.533334 93.866666v6.826667l-3.413333 8.533333c-10.24 23.893333-23.893333 40.96-44.373333 51.2-5.12 3.413333-11.946667 6.826667-20.48 8.533334-27.306667 8.533333-51.2 25.6-63.146667 46.08-13.653333 23.893333-17.066667 52.906667-10.24 81.92 11.946667 35.84-1.706667 75.093333-30.72 95.573333-44.373333 35.84-95.573333 66.56-157.013333 92.16-15.36 3.413333-27.306667 3.413333-35.84 3.413333z m3.413333-83.626666z m1.706667 0zM517.12 853.333333c47.786667 0 93.866667 20.48 134.826667 59.733334 1.706667 1.706667 3.413333 1.706667 3.413333 3.413333 52.906667-22.186667 97.28-49.493333 136.533333-80.213333l1.706667-1.706667v-3.413333c-13.653333-52.906667-8.533333-104.106667 17.066667-148.48 23.893333-39.253333 64.853333-69.973333 114.346666-85.333334 1.706667 0 3.413333-1.706667 6.826667-6.826666 5.12-25.6 8.533333-51.2 8.533333-78.506667-1.706667-29.013333-3.413333-56.32-10.24-81.92v-5.12h-1.706666c-51.2-11.946667-90.453333-39.253333-119.466667-87.04-27.306667-44.373333-34.133333-100.693333-17.066667-148.48l-1.706666-1.706667h-3.413334c-39.253333-35.84-85.333333-63.146667-136.533333-80.213333H648.533333s-1.706667 1.706667-3.413333 1.706667c-32.426667 39.253333-80.213333 59.733333-136.533333 59.733333-47.786667 0-93.866667-20.48-134.826667-59.733333l-1.706667-1.706667h-1.706666c-54.613333 22.186667-98.986667 49.493333-136.533334 80.213333l-1.706666 1.706667v3.413333c13.653333 52.906667 8.533333 104.106667-17.066667 148.48-23.893333 39.253333-64.853333 69.973333-114.346667 85.333334-1.706667 0-3.413333 1.706667-6.826666 6.826666-6.826667 25.6-8.533333 51.2-8.533334 78.506667 0 30.72 3.413333 58.026667 6.826667 76.8l1.706667 5.12h1.706666c51.2 11.946667 90.453333 39.253333 119.466667 87.04 27.306667 44.373333 34.133333 100.693333 17.066667 148.48l1.706666 1.706667 1.706667 1.706666c37.546667 35.84 83.626667 63.146667 134.826667 80.213334 1.706667 0 3.413333 0 3.413333 1.706666h1.706667s1.706667 0 5.12-1.706666c34.133333-37.546667 81.92-59.733333 136.533333-59.733334z m-6.826667-146.773333c-110.933333 0-199.68-85.333333-199.68-196.266667 0-109.226667 87.04-196.266667 199.68-196.266666s199.68 85.333333 199.68 196.266666c-1.706667 109.226667-88.746667 196.266667-199.68 196.266667z m0-307.2c-63.146667 0-114.346667 49.493333-114.346666 110.933333 0 63.146667 49.493333 110.933333 114.346666 110.933334 30.72 0 59.733333-11.946667 80.213334-32.426667 20.48-20.48 32.426667-49.493333 32.426666-78.506667 0-63.146667-49.493333-110.933333-112.64-110.933333z"
			};
			((FrameworkElement)myIconButton3).ToolTip = "设置";
			ToolTipService.SetPlacement((DependencyObject)(object)myIconButton3, (PlacementMode)3);
			ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton3, 30.0);
			ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton3, 2.0);
			myIconButton3.Click += [SpecialName] (object a0, EventArgs a1) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__2();
			};
			((UIElement)CS_0024_003C_003E8__locals0._0024VB_0024Local_sender).MouseRightButtonUp += (MouseButtonEventHandler)([SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__3();
			});
			CS_0024_003C_003E8__locals0._0024VB_0024Local_sender.Buttons = new MyIconButton[] { myIconButton, myIconButton2, myIconButton3 };
		}
		else
		{
			MyIconButton myIconButton4 = new MyIconButton
			{
				LogoScale = 1.15,
				Logo = "M889.018182 418.909091H884.363636V316.509091a93.090909 93.090909 0 0 0-99.607272-89.832727h-302.545455l-93.090909-76.334546A46.545455 46.545455 0 0 0 358.865455 139.636364H146.152727A93.090909 93.090909 0 0 0 46.545455 229.469091V837.818182a46.545455 46.545455 0 0 0 46.545454 46.545454 46.545455 46.545455 0 0 0 16.756364-3.258181 109.381818 109.381818 0 0 0 25.134545 3.258181h586.472727a85.178182 85.178182 0 0 0 87.04-63.301818l163.374546-302.545454a46.545455 46.545455 0 0 0 5.585454-21.876364A82.385455 82.385455 0 0 0 889.018182 418.909091z m-744.727273-186.181818h198.283636l93.09091 76.334545a46.545455 46.545455 0 0 0 29.323636 10.705455h319.301818a12.101818 12.101818 0 0 1 6.516364 0V418.909091H302.545455a85.178182 85.178182 0 0 0-87.04 63.301818L139.636364 622.778182V232.727273a19.549091 19.549091 0 0 1 6.516363 0z m578.094546 552.029091a27.461818 27.461818 0 0 0-2.792728 6.516363H154.530909l147.083636-272.290909a27.461818 27.461818 0 0 0 2.792728-6.981818h565.061818z"
			};
			((FrameworkElement)myIconButton4).ToolTip = "打开文件夹";
			ToolTipService.SetPlacement((DependencyObject)(object)myIconButton4, (PlacementMode)3);
			ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton4, 30.0);
			ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton4, 2.0);
			myIconButton4.Click += [SpecialName] (object a0, EventArgs a1) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__4();
			};
			((UIElement)CS_0024_003C_003E8__locals0._0024VB_0024Local_sender).MouseRightButtonUp += (MouseButtonEventHandler)([SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__5();
			});
			CS_0024_003C_003E8__locals0._0024VB_0024Local_sender.Buttons = new MyIconButton[] { myIconButton, myIconButton2, myIconButton4 };
		}
	}

	public static void Item_Click(MyListItem sender, EventArgs e)
	{
		ModMinecraft.McInstance mcInstance = (ModMinecraft.McInstance)((FrameworkElement)sender).Tag;
		if (new ModMinecraft.McInstance(mcInstance.Path).Check())
		{
			ModMinecraft.McInstanceCurrent = mcInstance;
			ModBase.Setup.Set("LaunchInstanceSelect", ModMinecraft.McInstanceCurrent.Name);
			ModMain.FrmMain.PageBack();
		}
		else
		{
			PageInstanceOverall.OpenVersionFolder(mcInstance);
		}
	}

	private void BtnDownload_Click(object sender, EventArgs e)
	{
		ModMain.FrmMain.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadInstall);
	}

	public static void DeleteVersion(MyListItem Item, ModMinecraft.McInstance Version)
	{
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Expected O, but got Unknown
		//IL_0218: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		try
		{
			bool flag = Keyboard.IsKeyDown((Key)116) || Keyboard.IsKeyDown((Key)117);
			bool flag2 = Version.State != 0 && Operators.CompareString(Version.PathIndie, ModMinecraft.PathMcFolder, false) != 0;
			switch (ModMain.MyMsgBox(string.Format("你确定要{0}删除实例 {1} 吗？", (object)(flag ? "永久" : ""), (object)Version.Name) + (flag2 ? "\r\n由于该实例开启了版本隔离，删除时该实例对应的存档、资源包、Mod 等文件也将被一并删除！" : ""), "实例删除确认", "确定", "取消", "", IsWarn: true))
			{
			case 1:
				ModBase.IniClearCache(Version.PathIndie + "options.txt");
				if (flag)
				{
					ModBase.DeleteDirectory(Version.Path);
					ModMain.Hint("实例 " + Version.Name + " 已永久删除！", ModMain.HintType.Finish);
				}
				else
				{
					FileSystem.DeleteDirectory(Version.Path, (UIOption)3, (RecycleOption)3);
					ModMain.Hint("实例 " + Version.Name + " 已删除到回收站！", ModMain.HintType.Finish);
				}
				break;
			case 2:
				return;
			}
			if (Version.DisplayType == ModMinecraft.McInstanceCardType.Hidden || !Version.IsStar)
			{
				StackPanel val = (StackPanel)((FrameworkElement)Item).Parent;
				if (((Panel)val).Children.Count > 2)
				{
					MyCard obj = (MyCard)(object)((FrameworkElement)val).Parent;
					obj.Title = checked(obj.Title.Replace(Conversions.ToString(((Panel)val).Children.Count - 1), Conversions.ToString(((Panel)val).Children.Count - 2)));
					((Panel)val).Children.Remove((UIElement)(object)Item);
					if ((object)ModMinecraft.McInstanceCurrent != null && Operators.CompareString(Version.Path, ModMinecraft.McInstanceCurrent.Path, false) == 0)
					{
						ModMinecraft.McInstanceCurrent = (ModMinecraft.McInstance)((FrameworkElement)(MyListItem)(object)((Panel)val).Children[0]).Tag;
					}
					ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.UpdateOnly, 1, "versions\\");
				}
				else
				{
					ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
				}
			}
			else
			{
				ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
			}
		}
		catch (OperationCanceledException val2)
		{
			ProjectData.SetProjectError((System.Exception)val2);
			OperationCanceledException ex = val2;
			ModBase.Log((System.Exception)(object)ex, "删除实例 " + Version.Name + " 被主动取消");
			ProjectData.ClearProjectError();
		}
		catch (System.Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			System.Exception ex3 = ex2;
			ModBase.Log(ex3, "删除实例 " + Version.Name + " 失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	public void BtnEmptyDownload_Loaded()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		Visibility val = (Visibility)(Conversions.ToBoolean((object)((Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenPageDownload")) && !PageSetupUI.HiddenForceShow) || ShowHidden)) ? 2 : 0);
		if (((UIElement)BtnEmptyDownload).Visibility != val)
		{
			((UIElement)BtnEmptyDownload).Visibility = val;
			PanLoad.TriggerForceResize();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageselectright.xaml", (UriKind)2);
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
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanAllBack = (Grid)target;
			break;
		case 2:
			PanVerSearchBox = (MySearchBox)target;
			break;
		case 3:
			PanBack = (MyScrollViewer)target;
			break;
		case 4:
			PanMain = (StackPanel)target;
			break;
		case 5:
			PanEmpty = (MyCard)target;
			break;
		case 6:
			LabEmptyTitle = (TextBlock)target;
			break;
		case 7:
			LabEmptyContent = (TextBlock)target;
			break;
		case 8:
			BtnEmptyDownload = (MyButton)target;
			break;
		case 9:
			PanEmptySearch = (MyCard)target;
			break;
		case 10:
			LabEmptySearchTitle = (TextBlock)target;
			break;
		case 11:
			LabEmptySearchContent = (TextBlock)target;
			break;
		case 12:
			PanLoad = (MyCard)target;
			break;
		case 13:
			Load = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
