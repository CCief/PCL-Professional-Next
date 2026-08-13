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
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageDownloadForge : MyPageRight, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action<StackPanel> _0024I3_002D0;

		public static ModBase.ComparisonBoolean<ModDownload.DlForgeVersionEntry> _0024I5_002D1;

		public static Action<StackPanel> _0024I5_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__3_002D0(StackPanel Stack)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			MyLoading obj = new MyLoading
			{
				Text = "正在获取版本列表"
			};
			((FrameworkElement)obj).Margin = new Thickness(5.0);
			MyLoading myLoading = obj;
			ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = (ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)(myLoading.State = new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>("DlForgeVersion Main", ModDownload.DlForgeVersionMain, null, (ThreadPriority)2));
			loaderTask.Start(RuntimeHelpers.GetObjectValue(((FrameworkElement)Stack).Tag));
			_Closure_0024__R3_002D3 arg = default(_Closure_0024__R3_002D3);
			myLoading.StateChanged += new _Closure_0024__R3_002D3(null)
			{
				_0024VB_0024NonLocal_2 = ModMain.FrmDownloadForge
			}._Lambda_0024__R6;
			_Closure_0024__R3_002D4 arg2 = default(_Closure_0024__R3_002D4);
			myLoading.Click += new _Closure_0024__R3_002D4(null)
			{
				_0024VB_0024NonLocal_3 = ModMain.FrmDownloadForge
			}._Lambda_0024__R7;
			((Panel)Stack).Children.Add((UIElement)(object)myLoading);
		}

		[SpecialName]
		internal void _Lambda_0024__5_002D0(StackPanel Stack)
		{
			((FrameworkElement)Stack).Tag = ModBase.Sort((System.Collections.Generic.IList<ModDownload.DlForgeVersionEntry>)(List<ModDownload.DlForgeVersionEntry>)((FrameworkElement)Stack).Tag, [SpecialName] (ModDownload.DlForgeVersionEntry a, ModDownload.DlForgeVersionEntry b) => a.Version > b.Version);
			ModDownloadLib.ForgeDownloadListItemPreload(Stack, (List<ModDownload.DlForgeVersionEntry>)((FrameworkElement)Stack).Tag, ModDownloadLib.ForgeSave_Click, IsSaveOnly: true);
			foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				((Panel)Stack).Children.Add((UIElement)(object)ModDownloadLib.ForgeDownloadListItem((ModDownload.DlForgeVersionEntry)objectValue, ModDownloadLib.ForgeSave_Click, IsSaveOnly: true));
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__5_002D1(ModDownload.DlForgeVersionEntry a, ModDownload.DlForgeVersionEntry b)
		{
			return a.Version > b.Version;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__R3_002D3
	{
		public PageDownloadForge _0024VB_0024NonLocal_2;

		public _Closure_0024__R3_002D3(_Closure_0024__R3_002D3 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024NonLocal_2 = arg0._0024VB_0024NonLocal_2;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R6(object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2)
		{
			_0024VB_0024NonLocal_2.Forge_StateChanged((MyLoading)a0, a1, a2);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__R3_002D4
	{
		public PageDownloadForge _0024VB_0024NonLocal_3;

		public _Closure_0024__R3_002D4(_Closure_0024__R3_002D4 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024NonLocal_3 = arg0._0024VB_0024NonLocal_3;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R7(object a0, MouseButtonEventArgs a1)
		{
			_0024VB_0024NonLocal_3.Forge_Click((MyLoading)a0, a1);
		}
	}

	[CompilerGenerated]
	[AccessedThroughProperty("BtnWeb")]
	private MyButton _BtnWeb;

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
	[field: AccessedThroughProperty("CardTip")]
	internal virtual MyCard CardTip
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabConnect")]
	internal virtual TextBlock LabConnect
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnWeb
	{
		[CompilerGenerated]
		get
		{
			return _BtnWeb;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnWeb_Click;
			MyButton btnWeb = _BtnWeb;
			if (btnWeb != null)
			{
				btnWeb.Click -= obj;
			}
			_BtnWeb = value;
			btnWeb = _BtnWeb;
			if (btnWeb != null)
			{
				btnWeb.Click += obj;
			}
		}
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

	public PageDownloadForge()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Initialized += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			LoaderInit();
		});
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Init();
		});
		InitializeComponent();
	}

	private void LoaderInit()
	{
		PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanMain, (FrameworkElement)(object)CardTip, ModDownload.DlForgeListLoader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
		{
			Load_OnFinish();
		});
	}

	private void Init()
	{
		((ScrollViewer)PanBack).ScrollToHome();
	}

	private void Load_OnFinish()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		try
		{
			((Panel)PanMain).Children.Clear();
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = ModBase.Sort((System.Collections.Generic.IList<string>)ModDownload.DlForgeListLoader.Output.Value, ModMinecraft.VersionSortBoolean).GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					MyCard obj = new MyCard
					{
						Title = current.Replace("_p", " P")
					};
					((FrameworkElement)obj).Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
					MyCard myCard = obj;
					StackPanel val = new StackPanel
					{
						Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
						VerticalAlignment = (VerticalAlignment)0,
						RenderTransform = (Transform)new TranslateTransform(0.0, 0.0),
						Tag = current
					};
					((Panel)myCard).Children.Add((UIElement)(object)val);
					myCard.SwapControl = val;
					myCard.InstallMethod = ((_Closure_0024__._0024I3_002D0 == null) ? (_Closure_0024__._0024I3_002D0 = [SpecialName] (StackPanel Stack) =>
					{
						//IL_001a: Unknown result type (might be due to invalid IL or missing references)
						MyLoading obj2 = new MyLoading
						{
							Text = "正在获取版本列表"
						};
						((FrameworkElement)obj2).Margin = new Thickness(5.0);
						MyLoading myLoading = obj2;
						ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = (ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)(myLoading.State = new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>("DlForgeVersion Main", ModDownload.DlForgeVersionMain, null, (ThreadPriority)2));
						loaderTask.Start(RuntimeHelpers.GetObjectValue(((FrameworkElement)Stack).Tag));
						_Closure_0024__R3_002D3 arg = default(_Closure_0024__R3_002D3);
						_Closure_0024__R3_002D3 CS_0024_003C_003E8__locals0 = new _Closure_0024__R3_002D3(null);
						CS_0024_003C_003E8__locals0._0024VB_0024NonLocal_2 = ModMain.FrmDownloadForge;
						myLoading.StateChanged += [SpecialName] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
						{
							CS_0024_003C_003E8__locals0._0024VB_0024NonLocal_2.Forge_StateChanged((MyLoading)a0, a1, a2);
						};
						_Closure_0024__R3_002D4 arg2 = default(_Closure_0024__R3_002D4);
						_Closure_0024__R3_002D4 CS_0024_003C_003E8__locals1 = new _Closure_0024__R3_002D4(null);
						CS_0024_003C_003E8__locals1._0024VB_0024NonLocal_3 = ModMain.FrmDownloadForge;
						myLoading.Click += [SpecialName] (object a0, MouseButtonEventArgs a1) =>
						{
							CS_0024_003C_003E8__locals1._0024VB_0024NonLocal_3.Forge_Click((MyLoading)a0, a1);
						};
						((Panel)Stack).Children.Add((UIElement)(object)myLoading);
					}) : _Closure_0024__._0024I3_002D0);
					myCard.IsSwapped = true;
					((Panel)PanMain).Children.Add((UIElement)(object)myCard);
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
			ModBase.Log(ex2, "可视化 Forge 版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public void Forge_Click(MyLoading sender, MouseButtonEventArgs e)
	{
		if (sender.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			((ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)sender.State).Start(null, IsForceRestart: true);
		}
	}

	public void Forge_StateChanged(MyLoading sender, MyLoading.MyLoadingState newState, MyLoading.MyLoadingState oldState)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		if (newState != MyLoading.MyLoadingState.Stop)
		{
			return;
		}
		MyCard myCard = (MyCard)(object)((FrameworkElement)((FrameworkElement)sender).Parent).Parent;
		ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = (ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)sender.State;
		NewLateBinding.LateCall(NewLateBinding.LateGet(myCard.SwapControl, (System.Type)null, "Children", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Clear", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
		NewLateBinding.LateSet(myCard.SwapControl, (System.Type)null, "Tag", new object[] { loaderTask.Output }, (string[])null, (System.Type[])null);
		myCard.InstallMethod = [SpecialName] (StackPanel Stack) =>
		{
			((FrameworkElement)Stack).Tag = ModBase.Sort((System.Collections.Generic.IList<ModDownload.DlForgeVersionEntry>)(List<ModDownload.DlForgeVersionEntry>)((FrameworkElement)Stack).Tag, [SpecialName] (ModDownload.DlForgeVersionEntry a, ModDownload.DlForgeVersionEntry b) => a.Version > b.Version);
			ModDownloadLib.ForgeDownloadListItemPreload(Stack, (List<ModDownload.DlForgeVersionEntry>)((FrameworkElement)Stack).Tag, ModDownloadLib.ForgeSave_Click, IsSaveOnly: true);
			foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				((Panel)Stack).Children.Add((UIElement)(object)ModDownloadLib.ForgeDownloadListItem((ModDownload.DlForgeVersionEntry)objectValue, ModDownloadLib.ForgeSave_Click, IsSaveOnly: true));
			}
		};
		myCard.StackInstall();
	}

	private void BtnWeb_Click(object sender, EventArgs e)
	{
		ModBase.OpenWebsite("https://files.minecraftforge.net");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagedownload/pagedownloadforge.xaml", (UriKind)2);
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
			CardTip = (MyCard)target;
			break;
		case 3:
			LabConnect = (TextBlock)target;
			break;
		case 4:
			BtnWeb = (MyButton)target;
			break;
		case 5:
			PanMain = (StackPanel)target;
			break;
		case 6:
			PanLoad = (MyCard)target;
			break;
		case 7:
			Load = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
