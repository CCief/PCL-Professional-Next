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
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageOtherHelp : MyPageRight, IRefreshable, IComponentConnector
{
	[CompilerGenerated]
	[AccessedThroughProperty("SearchBox")]
	private MySearchBox _SearchBox;

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

	internal virtual MySearchBox SearchBox
	{
		[CompilerGenerated]
		get
		{
			return _SearchBox;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySearchBox.TextChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				SearchRun();
			};
			MySearchBox searchBox = _SearchBox;
			if (searchBox != null)
			{
				searchBox.TextChanged -= obj;
			}
			_SearchBox = value;
			searchBox = _SearchBox;
			if (searchBox != null)
			{
				searchBox.TextChanged += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanSearch")]
	internal virtual MyCard PanSearch
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanSearchList")]
	internal virtual StackPanel PanSearchList
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
	[field: AccessedThroughProperty("PanLoad")]
	internal virtual MyCard PanLoad
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("Load")]
	internal virtual MyLoading Load
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageOtherHelp()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageOther_Loaded);
		((FrameworkElement)this).Initialized += new EventHandler(PageOther_Inited);
		InitializeComponent();
	}

	private void PageOther_Loaded(object sender, RoutedEventArgs e)
	{
		((ScrollViewer)PanBack).ScrollToHome();
	}

	private void PageOther_Inited(object sender, EventArgs e)
	{
		PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanBack, null, ModMain.HelpLoader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
		{
			HelpListLoad((ModLoader.LoaderTask<int, List<ModMain.HelpEntry>>)a0);
		});
	}

	private void HelpListLoad(ModLoader.LoaderTask<int, List<ModMain.HelpEntry>> Loader)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		try
		{
			((Panel)PanList).Children.Clear();
			((ScrollViewer)PanBack).ScrollToHome();
			List<ModMain.HelpEntry> output = Loader.Output;
			List<string> val = new List<string>();
			System.Collections.Generic.IEnumerator<ModMain.HelpEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModMain.HelpEntry>);
			try
			{
				enumerator = output.GetEnumerator();
				System.Collections.Generic.IEnumerator<string> enumerator2 = default(System.Collections.Generic.IEnumerator<string>);
				while (enumerator.MoveNext())
				{
					ModMain.HelpEntry current = enumerator.Current;
					try
					{
						enumerator2 = current.Types.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							string current2 = enumerator2.Current;
							if (!val.Contains(current2))
							{
								val.Add(current2);
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator2).Dispose();
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			if (val.Contains("指南"))
			{
				val.Remove("指南");
				val.Insert(0, "指南");
			}
			System.Collections.Generic.IEnumerator<string> enumerator3 = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator3 = val.GetEnumerator();
				System.Collections.Generic.IEnumerator<ModMain.HelpEntry> enumerator4 = default(System.Collections.Generic.IEnumerator<ModMain.HelpEntry>);
				while (enumerator3.MoveNext())
				{
					string current3 = enumerator3.Current;
					List<ModMain.HelpEntry> val2 = new List<ModMain.HelpEntry>();
					try
					{
						enumerator4 = output.GetEnumerator();
						while (enumerator4.MoveNext())
						{
							ModMain.HelpEntry current4 = enumerator4.Current;
							if (current4.Types.Contains(current3))
							{
								val2.Add(current4);
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator4).Dispose();
					}
					MyCard obj = new MyCard
					{
						Title = current3
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
					VB_0024AnonymousDelegate_15<StackPanel> vB_0024AnonymousDelegate_ = [SpecialName] (StackPanel Stack) =>
					{
						foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(item);
							((Panel)Stack).Children.Add((UIElement)(object)((ModMain.HelpEntry)objectValue).ToListItem());
						}
					};
					VB_0024AnonymousDelegate_15<StackPanel> vB_0024AnonymousDelegate_2 = vB_0024AnonymousDelegate_;
					myCard.InstallMethod = ((vB_0024AnonymousDelegate_2 == null) ? null : new Action<StackPanel>(vB_0024AnonymousDelegate_2.Invoke));
					if (Operators.CompareString(current3, "指南", false) == 0)
					{
						vB_0024AnonymousDelegate_2 = vB_0024AnonymousDelegate_;
						MyCard.StackInstall(ref Stack2, (vB_0024AnonymousDelegate_2 == null) ? null : new Action<StackPanel>(vB_0024AnonymousDelegate_2.Invoke));
					}
					else
					{
						myCard.IsSwapped = true;
					}
					((Panel)PanList).Children.Add((UIElement)(object)myCard);
				}
			}
			finally
			{
				((System.IDisposable)enumerator3).Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "加载帮助列表 UI 失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public static void OnItemClick(ModMain.HelpEntry Entry)
	{
		try
		{
			if (Entry.IsEvent)
			{
				ModEvent.TryStartEvent(Entry.EventType, Entry.EventData);
			}
			else
			{
				EnterHelpPage(Entry);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "处理帮助项目点击时发生意外错误", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public static void EnterHelpPage(string Location)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		ModBase.RunInThread((Action)([SpecialName] () =>
		{
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Expected O, but got Unknown
			if (ModMain.HelpLoader.State != ModBase.LoadState.Finished)
			{
				ModMain.HelpLoader.WaitForExit(ModBase.GetUuid());
			}
			ModMain.HelpEntry helpEntry = new ModMain.HelpEntry(Location);
			ModBase.RunInUi((Action)([SpecialName] () =>
			{
				PageOtherHelpDetail pageOtherHelpDetail = new PageOtherHelpDetail();
				if (pageOtherHelpDetail.Init(helpEntry))
				{
					ModMain.FrmMain.PageChange(new FormMain.PageStackData
					{
						Page = FormMain.PageType.HelpDetail,
						Additional = new object[] { helpEntry, pageOtherHelpDetail }
					});
				}
				else
				{
					ModBase.Log("[Help] 已取消进入帮助项目，这一般是由于 xaml 初始化失败，且用户在弹窗中手动放弃", ModBase.LogLevel.Debug);
				}
			}));
		}));
	}

	public static void EnterHelpPage(ModMain.HelpEntry Entry)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		Action val = default(Action);
		ModBase.RunInThread((Action)([SpecialName] () =>
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_0047: Expected O, but got Unknown
			if (ModMain.HelpLoader.State != ModBase.LoadState.Finished)
			{
				ModMain.HelpLoader.WaitForExit(ModBase.GetUuid());
			}
			Action action;
			if (val != null)
			{
				action = val;
			}
			else
			{
				Action val2 = [SpecialName] () =>
				{
					PageOtherHelpDetail pageOtherHelpDetail = new PageOtherHelpDetail();
					if (pageOtherHelpDetail.Init(Entry))
					{
						ModMain.FrmMain.PageChange(new FormMain.PageStackData
						{
							Page = FormMain.PageType.HelpDetail,
							Additional = new object[] { Entry, pageOtherHelpDetail }
						});
					}
					else
					{
						ModBase.Log("[Help] 已取消进入帮助项目，这一般是由于 xaml 初始化失败，且用户在弹窗中手动放弃", ModBase.LogLevel.Debug);
					}
				};
				Action val3 = val2;
				val = val2;
				action = val3;
			}
			ModBase.RunInUi(action);
		}));
	}

	public static PageOtherHelpDetail GetHelpPage(string Location)
	{
		if (ModMain.HelpLoader.State != ModBase.LoadState.Finished)
		{
			ModMain.HelpLoader.WaitForExit(ModBase.GetUuid());
		}
		PageOtherHelpDetail pageOtherHelpDetail = new PageOtherHelpDetail();
		if (pageOtherHelpDetail.Init(new ModMain.HelpEntry(Location)))
		{
			return pageOtherHelpDetail;
		}
		throw new System.Exception("已取消进入帮助项目，这一般是由于 xaml 初始化失败，且用户在弹窗中手动放弃");
	}

	public void SearchRun()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		if (string.IsNullOrWhiteSpace(SearchBox.Text))
		{
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
			{
				ModAnimation.AaOpacity(PanSearch, 0.0 - ((UIElement)PanSearch).Opacity, 100),
				ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
				{
					((FrameworkElement)PanSearch).Height = 0.0;
					((UIElement)PanSearch).Visibility = (Visibility)2;
					((UIElement)PanList).Visibility = (Visibility)0;
				}), 0, After: true),
				ModAnimation.AaOpacity(PanList, 1.0 - ((UIElement)PanList).Opacity, 150, 30)
			}, "FrmOtherHelp Search Switch");
			return;
		}
		List<ModBase.SearchEntry<ModMain.HelpEntry>> val = new List<ModBase.SearchEntry<ModMain.HelpEntry>>();
		System.Collections.Generic.IEnumerator<ModMain.HelpEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModMain.HelpEntry>);
		try
		{
			enumerator = ModMain.HelpLoader.Output.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ModMain.HelpEntry current = enumerator.Current;
				if (current.ShowInSearch && (ModBase.Val("0") != 50.0 || current.ShowInPublic) && current.ShowInSearch && (ModBase.Val("0") == 50.0 || current.ShowInSnapshot))
				{
					ModBase.SearchEntry<ModMain.HelpEntry> obj = new ModBase.SearchEntry<ModMain.HelpEntry>
					{
						Item = current
					};
					List<KeyValuePair<string, double>> obj2 = new List<KeyValuePair<string, double>>();
					obj2.Add(new KeyValuePair<string, double>(current.Title, 1.0));
					obj2.Add(new KeyValuePair<string, double>(current.Desc, 0.5));
					obj2.Add(new KeyValuePair<string, double>(current.Search, 1.5));
					obj.SearchSource = obj2;
					val.Add(obj);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		List<ModBase.SearchEntry<ModMain.HelpEntry>> val2 = ModBase.Search<ModMain.HelpEntry>(val, SearchBox.Text, 5, 0.08);
		((Panel)PanSearchList).Children.Clear();
		if (!Enumerable.Any<ModBase.SearchEntry<ModMain.HelpEntry>>((System.Collections.Generic.IEnumerable<ModBase.SearchEntry<ModMain.HelpEntry>>)val2))
		{
			PanSearch.Title = "无搜索结果";
			((UIElement)PanSearchList).Visibility = (Visibility)2;
		}
		else
		{
			PanSearch.Title = "搜索结果";
			System.Collections.Generic.IEnumerator<ModBase.SearchEntry<ModMain.HelpEntry>> enumerator2 = default(System.Collections.Generic.IEnumerator<ModBase.SearchEntry<ModMain.HelpEntry>>);
			try
			{
				enumerator2 = val2.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ModBase.SearchEntry<ModMain.HelpEntry> current2 = enumerator2.Current;
					MyListItem myListItem = current2.Item.ToListItem();
					if (ModBase.ModeDebug)
					{
						myListItem.Info = string.Concat(new string[5]
						{
							current2.AbsoluteRight ? "完全匹配，" : "",
							"相似度：",
							Conversions.ToString(Math.Round(current2.Similarity, 3)),
							"，",
							myListItem.Info
						});
					}
					((Panel)PanSearchList).Children.Add((UIElement)(object)myListItem);
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			((UIElement)PanSearchList).Visibility = (Visibility)0;
		}
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
		{
			ModAnimation.AaOpacity(PanList, 0.0 - ((UIElement)PanList).Opacity, 100),
			ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
			{
				((UIElement)PanList).Visibility = (Visibility)2;
				((UIElement)PanSearch).Visibility = (Visibility)0;
				PanSearch.TriggerForceResize();
			}), 0, After: true),
			ModAnimation.AaOpacity(PanSearch, 1.0 - ((UIElement)PanSearch).Opacity, 150, 30)
		}, "FrmOtherHelp Search Switch");
	}

	public void Refresh()
	{
		PageOtherLeft.RefreshHelp();
	}

	void IRefreshable.Refresh()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Refresh
		this.Refresh();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageother/pageotherhelp.xaml", (UriKind)2);
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
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
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
			SearchBox = (MySearchBox)target;
			break;
		case 4:
			PanSearch = (MyCard)target;
			break;
		case 5:
			PanSearchList = (StackPanel)target;
			break;
		case 6:
			PanList = (StackPanel)target;
			break;
		case 7:
			PanLoad = (MyCard)target;
			break;
		case 8:
			Load = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
