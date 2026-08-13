using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageHomepageMarket : MyPageRight, IRefreshable, IComponentConnector
{
	private object RefreshLock;

	private object LoadContentLock;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnManualRefresh")]
	protected virtual Button BtnManualRefresh
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
	[field: AccessedThroughProperty("PanCustom")]
	internal virtual StackPanel PanCustom
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

	public PageHomepageMarket()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(Page_Loaded);
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Refresh();
		});
		RefreshLock = RuntimeHelpers.GetObjectValue(new object());
		LoadContentLock = RuntimeHelpers.GetObjectValue(new object());
		InitializeComponent();
	}

	private void Page_Loaded(object sender, RoutedEventArgs e)
	{
		Load.TextErrorInherit = false;
		Load.TextError = "加载失败，点击重试";
		UpdateLoadingState("正在加载主页市场", MyLoading.MyLoadingState.Run);
		Load.Click += OnLoadingClick;
		InitRefreshButton();
		Refresh();
	}

	private void UpdateLoadingState(string text, MyLoading.MyLoadingState state)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		ModBase.RunInUi((Action)([SpecialName] () =>
		{
			Load.Text = text;
			Load.State.LoadingState = state;
		}));
	}

	private void OnLoadingClick(object sender, MouseButtonEventArgs e)
	{
		if (Load.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			UpdateLoadingState("正在重新加载...", MyLoading.MyLoadingState.Run);
			Refresh();
		}
	}

	private void InitRefreshButton()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		foreach (UIElement child in ((Panel)PanCustom).Children)
		{
			UIElement val = child;
			if (val is Button && Operators.CompareString(((FrameworkElement)(Button)val).Name, "BtnManualRefresh", false) == 0)
			{
				BtnManualRefresh = (Button)val;
				return;
			}
		}
		BtnManualRefresh = new Button
		{
			Name = "BtnManualRefresh",
			Content = "刷新",
			Width = 80.0,
			Height = 30.0,
			Margin = new Thickness(0.0, 10.0, 15.0, 0.0),
			HorizontalAlignment = (HorizontalAlignment)2,
			VerticalAlignment = (VerticalAlignment)0,
			Visibility = (Visibility)2
		};
		((ButtonBase)BtnManualRefresh).Click += new RoutedEventHandler(BtnManualRefresh_Click);
		Panel.SetZIndex((UIElement)(object)BtnManualRefresh, 999);
		((Panel)PanCustom).Children.Add((UIElement)(object)BtnManualRefresh);
	}

	private void BtnManualRefresh_Click(object sender, RoutedEventArgs e)
	{
		ForceRefresh();
	}

	private void Refresh()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		ModBase.RunInNewThread((Action)([SpecialName] [CompilerGenerated] () =>
		{
			try
			{
				object refreshLock = RefreshLock;
				ObjectFlowControl.CheckForSyncLockOnValueType(refreshLock);
				bool flag = false;
				try
				{
					Monitor.Enter(refreshLock, ref flag);
					RefreshReal();
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(refreshLock);
					}
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "加载主页市场失败", ModBase.ModeDebug ? ModBase.LogLevel.Msgbox : ModBase.LogLevel.Hint);
				UpdateLoadingState("加载失败，点击重试", MyLoading.MyLoadingState.Error);
				ProjectData.ClearProjectError();
			}
		}), $"刷新主页市场 #{ModBase.GetUuid()}", (ThreadPriority)2);
	}

	private void RefreshReal()
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		string text = "https://pclhomeplazaoss.lingyunawa.top:26994/d/Homepages/JingHai-Lingyun/Custom.xaml";
		try
		{
			string text2 = Conversions.ToString(ModNet.NetGetCodeByRequestRetry(text));
			ModBase.Setup.Set("CacheSavedPageUrl", text);
			ModBase.WriteFile(ModBase.PathTemp + "Cache\\Custom.xaml", text2);
			ModBase.RunInUi((Action)([SpecialName] () =>
			{
				LoadContent(text2);
			}));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, $"加载主页市场失败 ({text})", ModBase.LogLevel.Hint);
			UpdateLoadingState("加载失败，点击重试", MyLoading.MyLoadingState.Error);
			ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
			{
				((UIElement)PanMain).Visibility = (Visibility)0;
			}));
			ProjectData.ClearProjectError();
		}
	}

	private void LoadContent(string content)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		object loadContentLock = LoadContentLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(loadContentLock);
		bool flag = false;
		try
		{
			Monitor.Enter(loadContentLock, ref flag);
			try
			{
				object objectValue = RuntimeHelpers.GetObjectValue(ModBase.GetObjectFromXML("<StackPanel xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' xmlns:local='clr-namespace:PCL;assembly=Plain Craft Launcher 2' xmlns:sys='clr-namespace:System;assembly=System.Runtime'>" + content + "</StackPanel>"));
				((Panel)PanCustom).Children.Clear();
				((Panel)PanCustom).Children.Add((UIElement)objectValue);
				Load.State.LoadingState = MyLoading.MyLoadingState.Stop;
				ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
				{
					((UIElement)PanMain).Visibility = (Visibility)0;
				}));
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "解析XAML失败", ModBase.LogLevel.Msgbox);
				UpdateLoadingState("解析失败，点击重试", MyLoading.MyLoadingState.Error);
				ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
				{
					((UIElement)PanMain).Visibility = (Visibility)0;
				}));
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(loadContentLock);
			}
		}
	}

	public void ForceRefresh()
	{
		ClearCache();
		ModMain.Hint("正在手动刷新...");
		Refresh();
	}

	void IRefreshable.Refresh()
	{
		//ILSpy generated this explicit interface implementation from .override directive in ForceRefresh
		this.ForceRefresh();
	}

	private void ClearCache()
	{
		ModBase.Setup.Set("CacheSavedPageUrl", "");
		ModBase.Setup.Set("CacheSavedPageVersion", "");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagesetup/pagehomepagemarket.xaml", (UriKind)2);
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
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanCustom = (StackPanel)target;
			break;
		case 3:
			PanLoad = (MyCard)target;
			break;
		case 4:
			Load = (MyLoading)target;
			break;
		case 5:
			PanMain = (StackPanel)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
