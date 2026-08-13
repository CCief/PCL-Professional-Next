using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Utils;

namespace PCL;

[DesignerGenerated]
public class PageLaunchLeft : MyPageLeft, IComponentConnector
{
	private enum PageType
	{
		None,
		Auth,
		Ms,
		Profile,
		ProfileSkin,
		Offline
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action _0024I14_002D0;

		public static Action _0024I17_002D0;

		public static Action _0024I17_002D1;

		public static Action _0024I20_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__14_002D0()
		{
			if (ModMain.FrmLoginProfileSkin != null && ModMain.FrmLoginProfileSkin.Skin != null)
			{
				ModMain.FrmLoginProfileSkin.Skin.Clear();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__17_002D0()
		{
			if (ModMain.FrmLoginProfileSkin != null && ModMain.FrmLoginProfileSkin.Skin != null)
			{
				ModMain.FrmLoginProfileSkin.Skin.Clear();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__17_002D1()
		{
			ModMain.FrmLoginProfileSkin.Skin.Load();
		}

		[SpecialName]
		internal void _Lambda_0024__20_002D0()
		{
			if (ModMain.FrmLoginProfileSkin != null && ModMain.FrmLoginProfileSkin.Skin != null)
			{
				ModMain.FrmLoginProfileSkin.Skin.Clear();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__29_002D0
	{
		public bool _0024VB_0024Local_HasLaunchDownloader;

		public PageLaunchLeft _0024VB_0024Me;

		public _Closure_0024__29_002D0(_Closure_0024__29_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_HasLaunchDownloader = arg0._0024VB_0024Local_HasLaunchDownloader;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			if (!_0024VB_0024Local_HasLaunchDownloader)
			{
				((UIElement)_0024VB_0024Me.LabLaunchingDownload).Visibility = (Visibility)2;
				((UIElement)_0024VB_0024Me.LabLaunchingDownloadLeft).Visibility = (Visibility)2;
			}
		}
	}

	private bool IsLoad;

	private bool IsLoadFinished;

	private PageType PageCurrent;

	public static ModLoader.LoaderTask<ModBase.EqualableList<string>, string> SkinMs = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>("Loader Skin Ms", SkinMsLoad, SkinMsInput, (ThreadPriority)3);

	public static ModLoader.LoaderTask<ModBase.EqualableList<string>, string> SkinLegacy = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>("Loader Skin Legacy", SkinLegacyLoad, SkinLegacyInput, (ThreadPriority)3);

	public static ModLoader.LoaderTask<ModBase.EqualableList<string>, string> SkinAuth = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>("Loader Skin Auth", SkinAuthLoad, SkinAuthInput, (ThreadPriority)3);

	public static List<ModLoader.LoaderTask<ModBase.EqualableList<string>, string>> SkinLoaders;

	private int BtnLaunchState;

	private ModMinecraft.McInstance BtnLaunchVersion;

	private double ShowProgress;

	private bool IsWidthAnimating;

	private double ActualUsedWidth;

	private bool IsHeightAnimating;

	private double ActualUsedHeight;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnInstance")]
	private MyButton _BtnInstance;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnMore")]
	private MyButton _BtnMore;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnLaunch")]
	private MyButton _BtnLaunch;

	[CompilerGenerated]
	[AccessedThroughProperty("PanLaunchingInfo")]
	private Grid _PanLaunchingInfo;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnCancel")]
	private MyButton _BtnCancel;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual PageLaunchLeft PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanInput")]
	internal virtual Grid PanInput
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnInstance
	{
		[CompilerGenerated]
		get
		{
			return _BtnInstance;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnInstance_Click;
			MyButton btnInstance = _BtnInstance;
			if (btnInstance != null)
			{
				btnInstance.Click -= obj;
			}
			_BtnInstance = value;
			btnInstance = _BtnInstance;
			if (btnInstance != null)
			{
				btnInstance.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnMore
	{
		[CompilerGenerated]
		get
		{
			return _BtnMore;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnMore_Click;
			MyButton btnMore = _BtnMore;
			if (btnMore != null)
			{
				btnMore.Click -= obj;
			}
			_BtnMore = value;
			btnMore = _BtnMore;
			if (btnMore != null)
			{
				btnMore.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLogin")]
	internal virtual Grid PanLogin
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("AprilScaleTrans")]
	internal virtual ScaleTransform AprilScaleTrans
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("AprilPosTrans")]
	internal virtual TranslateTransform AprilPosTrans
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnLaunch
	{
		[CompilerGenerated]
		get
		{
			return _BtnLaunch;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				LaunchButtonClick();
			};
			RoutedEventHandler val = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				RefreshButtonsUI();
			});
			MyButton btnLaunch = _BtnLaunch;
			if (btnLaunch != null)
			{
				btnLaunch.Click -= obj;
				((FrameworkElement)btnLaunch).Loaded -= val;
			}
			_BtnLaunch = value;
			btnLaunch = _BtnLaunch;
			if (btnLaunch != null)
			{
				btnLaunch.Click += obj;
				((FrameworkElement)btnLaunch).Loaded += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabVersion")]
	internal virtual TextBlock LabVersion
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLaunching")]
	internal virtual Grid PanLaunching
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LoadLaunching")]
	internal virtual MyLoading LoadLaunching
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLaunchingTitle")]
	internal virtual TextBlock LabLaunchingTitle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLaunchingName")]
	internal virtual TextBlock LabLaunchingName
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ProgressLaunchingFinished")]
	internal virtual ColumnDefinition ProgressLaunchingFinished
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ProgressLaunchingUnfinished")]
	internal virtual ColumnDefinition ProgressLaunchingUnfinished
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid PanLaunchingInfo
	{
		[CompilerGenerated]
		get
		{
			return _PanLaunchingInfo;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			SizeChangedEventHandler val = new SizeChangedEventHandler(PanLaunchingInfo_SizeChangedW);
			SizeChangedEventHandler val2 = new SizeChangedEventHandler(PanLaunchingInfo_SizeChangedH);
			Grid panLaunchingInfo = _PanLaunchingInfo;
			if (panLaunchingInfo != null)
			{
				((FrameworkElement)panLaunchingInfo).SizeChanged -= val;
				((FrameworkElement)panLaunchingInfo).SizeChanged -= val2;
			}
			_PanLaunchingInfo = value;
			panLaunchingInfo = _PanLaunchingInfo;
			if (panLaunchingInfo != null)
			{
				((FrameworkElement)panLaunchingInfo).SizeChanged += val;
				((FrameworkElement)panLaunchingInfo).SizeChanged += val2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLaunchingStage")]
	internal virtual TextBlock LabLaunchingStage
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLaunchingMethod")]
	internal virtual TextBlock LabLaunchingMethod
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLaunchingProgressLeft")]
	internal virtual TextBlock LabLaunchingProgressLeft
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLaunchingProgress")]
	internal virtual TextBlock LabLaunchingProgress
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLaunchingDownloadLeft")]
	internal virtual TextBlock LabLaunchingDownloadLeft
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLaunchingDownload")]
	internal virtual TextBlock LabLaunchingDownload
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnCancel
	{
		[CompilerGenerated]
		get
		{
			return _BtnCancel;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnCancel_Click();
			};
			MyButton btnCancel = _BtnCancel;
			if (btnCancel != null)
			{
				btnCancel.Click -= obj;
			}
			_BtnCancel = value;
			btnCancel = _BtnCancel;
			if (btnCancel != null)
			{
				btnCancel.Click += obj;
			}
		}
	}

	static PageLaunchLeft()
	{
		List<ModLoader.LoaderTask<ModBase.EqualableList<string>, string>> obj = new List<ModLoader.LoaderTask<ModBase.EqualableList<string>, string>>();
		obj.Add(SkinMs);
		obj.Add(SkinLegacy);
		obj.Add(SkinAuth);
		SkinLoaders = obj;
	}

	public PageLaunchLeft()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			PageLaunchLeft_Loaded();
		});
		IsLoad = false;
		IsLoadFinished = false;
		PageCurrent = PageType.None;
		BtnLaunchState = 0;
		BtnLaunchVersion = null;
		ShowProgress = 0.0;
		IsWidthAnimating = false;
		IsHeightAnimating = false;
		InitializeComponent();
	}

	public void PageLaunchLeft_Loaded()
	{
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		if (IsLoad)
		{
			RefreshPage(Anim: false);
		}
		AprilPosTrans.X = 0.0;
		AprilPosTrans.Y = 0.0;
		if (IsLoad)
		{
			return;
		}
		IsLoad = true;
		checked
		{
			ModAnimation.AniControlEnabled++;
			ModMinecraft.McInstanceListLoader.LoadingStateChanged += [SpecialName] [CompilerGenerated] (MyLoading.MyLoadingState a0, MyLoading.MyLoadingState a1) =>
			{
				RefreshButtonsUI();
			};
			ModMinecraft.McFolderListLoader.LoadingStateChanged += [SpecialName] [CompilerGenerated] (MyLoading.MyLoadingState a0, MyLoading.MyLoadingState a1) =>
			{
				RefreshButtonsUI();
			};
			RefreshButtonsUI();
			ModProfile.GetProfile();
			if (ModProfile.ProfileList.Count != 0 && ModProfile.LastUsedProfile >= 0 && ModProfile.LastUsedProfile < ModProfile.ProfileList.Count)
			{
				ModProfile.SelectedProfile = ModProfile.ProfileList[ModProfile.LastUsedProfile];
			}
			ModBase.RunInNewThread((Action)([SpecialName] [CompilerGenerated] () =>
			{
				//IL_044b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0456: Expected O, but got Unknown
				//IL_0395: Unknown result type (might be due to invalid IL or missing references)
				//IL_039a: Unknown result type (might be due to invalid IL or missing references)
				//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
				//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
				string text = null;
				if (File.Exists(ModBase.ExePath + "modpack.zip"))
				{
					text = ModBase.ExePath + "modpack.zip";
				}
				if (File.Exists(ModBase.ExePath + "modpack.mrpack"))
				{
					text = ModBase.ExePath + "modpack.mrpack";
				}
				if (text != null)
				{
					ModBase.Log("[Launch] 需自动安装整合包：" + text, ModBase.LogLevel.Debug);
					ModBase.Setup.Set("LaunchFolderSelect", "$.minecraft\\");
					if (!Directory.Exists(ModBase.ExePath + ".minecraft\\"))
					{
						Directory.CreateDirectory(ModBase.ExePath + ".minecraft\\");
						Directory.CreateDirectory(ModBase.ExePath + ".minecraft\\versions\\");
						ModMinecraft.McFolderLauncherProfilesJsonCreate(ModBase.ExePath + ".minecraft\\");
					}
					PageSelectLeft.AddFolder(ModBase.ExePath + ".minecraft\\", ModBase.GetFolderNameFromPath(ModBase.ExePath), ShowHint: false);
					ModMinecraft.McFolderListLoader.WaitForExit();
				}
				ModMinecraft.PathMcFolder = ModBase.Setup.Get("LaunchFolderSelect").ToString().Replace("$", ModBase.ExePath);
				if (Operators.CompareString(ModMinecraft.PathMcFolder, "", false) == 0 || !Directory.Exists(ModMinecraft.PathMcFolder))
				{
					if (Operators.CompareString(ModMinecraft.PathMcFolder, "", false) == 0)
					{
						ModBase.Log("[Launch] 没有已储存的 Minecraft 文件夹");
					}
					else
					{
						ModBase.Log("[Launch] Minecraft 文件夹无效，该文件夹已不存在：" + ModMinecraft.PathMcFolder, ModBase.LogLevel.Debug);
					}
					ModMinecraft.McFolderListLoader.WaitForExit(null, null, IsForceRestart: true);
					ModBase.Setup.Set("LaunchFolderSelect", ModMinecraft.McFolderList[0].Path.Replace(ModBase.ExePath, "$"));
				}
				ModBase.Log("[Launch] Minecraft 文件夹：" + ModMinecraft.PathMcFolder);
				if (Conversions.ToBoolean(ModBase.Setup.Get("SystemDebugDelay")))
				{
					Thread.Sleep(RandomUtils.NextInt(500, 3000));
				}
				if (text != null)
				{
					try
					{
						ModLoader.LoaderCombo<string> loaderCombo = ModModpack.ModpackInstall(text);
						ModBase.Log("[Launch] 自动安装整合包已开始：" + text);
						loaderCombo.WaitForExit();
						if (loaderCombo.State == ModBase.LoadState.Finished)
						{
							ModBase.Log("[Launch] 自动安装整合包成功，清理安装包：" + text);
							if (File.Exists(text))
							{
								File.Delete(text);
							}
						}
					}
					catch (ModBase.CancelledException ex)
					{
						ProjectData.SetProjectError((System.Exception)ex);
						ModBase.CancelledException ex2 = ex;
						ModBase.Log(ex2, "自动安装整合包被用户取消：" + text);
						ProjectData.ClearProjectError();
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						ModBase.Log(ex4, "自动安装整合包失败：" + text, ModBase.LogLevel.Msgbox);
						ProjectData.ClearProjectError();
					}
				}
				string text2 = Conversions.ToString(ModBase.Setup.Get("LaunchInstanceSelect"));
				ModMinecraft.McInstance mcInstance = ((Operators.CompareString(text2, "", false) == 0) ? null : new ModMinecraft.McInstance(text2));
				if ((object)mcInstance == null || !ModBase.StartsWithF(mcInstance.Path, ModMinecraft.PathMcFolder) || !mcInstance.Check())
				{
					ModBase.Log("[Launch] 当前选择的 Minecraft 实例无效：" + (((object)mcInstance == null) ? "null" : mcInstance.Path), (!Information.IsNothing((object)mcInstance)) ? ModBase.LogLevel.Debug : ModBase.LogLevel.Normal);
					if (ModMinecraft.McInstanceListLoader.State != ModBase.LoadState.Finished)
					{
						ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", WaitForExit: true);
					}
					if (!Enumerable.Any<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>((System.Collections.Generic.IEnumerable<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>)ModMinecraft.McInstanceList) || Enumerable.First<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>((System.Collections.Generic.IEnumerable<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>)ModMinecraft.McInstanceList).Value[0].Logo.Contains("RedstoneBlock"))
					{
						mcInstance = null;
						ModBase.Setup.Set("LaunchInstanceSelect", "");
						ModBase.Log("[Launch] 无可用 Minecraft 实例");
					}
					else
					{
						mcInstance = Enumerable.First<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>((System.Collections.Generic.IEnumerable<KeyValuePair<ModMinecraft.McInstanceCardType, List<ModMinecraft.McInstance>>>)ModMinecraft.McInstanceList).Value[0];
						ModBase.Setup.Set("LaunchInstanceSelect", mcInstance.Name);
						ModBase.Log("[Launch] 自动选择 Minecraft 实例：" + mcInstance.Path);
					}
				}
				ModBase.RunInUi((Action)([SpecialName] () =>
				{
					ModMinecraft.McInstanceCurrent = mcInstance;
					IsLoadFinished = true;
					RefreshButtonsUI();
					RefreshPage(Anim: false);
				}));
			}), "Instance Check", (ThreadPriority)3);
			RefreshPage(Anim: false);
			ModAnimation.AniControlEnabled--;
		}
	}

	public void PageChangeToLaunching()
	{
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		switch (ModProfile.SelectedProfile.Type)
		{
		case ModLaunch.McLoginType.Legacy:
			LabLaunchingMethod.Text = "离线验证";
			break;
		case ModLaunch.McLoginType.Ms:
			LabLaunchingMethod.Text = "正版验证";
			break;
		case ModLaunch.McLoginType.Auth:
			LabLaunchingMethod.Text = "第三方验证" + ((Operators.CompareString(ModProfile.SelectedProfile.ServerName, "", false) != 0) ? (" / " + ModProfile.SelectedProfile.ServerName) : "");
			break;
		}
		LabLaunchingName.Text = ModMinecraft.McInstanceCurrent.Name;
		LabLaunchingStage.Text = "初始化";
		LabLaunchingTitle.Text = ((ModLaunch.CurrentLaunchOptions?.SaveBatch == null) ? "正在启动游戏" : "正在导出启动脚本");
		LabLaunchingProgress.Text = "0.00 %";
		((UIElement)LabLaunchingProgress).Opacity = 1.0;
		((UIElement)LabLaunchingDownload).Visibility = (Visibility)0;
		((UIElement)LabLaunchingProgressLeft).Opacity = 0.6;
		((UIElement)LabLaunchingDownload).Visibility = (Visibility)0;
		LabLaunchingDownload.Text = "0 B/s";
		((UIElement)LabLaunchingDownload).Opacity = 0.0;
		((UIElement)LabLaunchingDownload).Visibility = (Visibility)2;
		((UIElement)LabLaunchingDownloadLeft).Opacity = 0.0;
		((UIElement)LabLaunchingDownloadLeft).Visibility = (Visibility)2;
		ProgressLaunchingFinished.Width = new GridLength(0.0, (GridUnitType)2);
		ProgressLaunchingUnfinished.Width = new GridLength(1.0, (GridUnitType)2);
		((FrameworkElement)PanLaunchingInfo).Width = 0.0 / 0.0;
		ModLaunch.McLaunchProcess = null;
		ModLaunch.McLaunchWatcher = null;
		((UIElement)PanInput).IsHitTestVisible = false;
		((UIElement)PanLaunching).IsHitTestVisible = false;
		LoadLaunching.State.LoadingState = MyLoading.MyLoadingState.Run;
		((UIElement)PanLaunching).Visibility = (Visibility)0;
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[6]
		{
			ModAnimation.AaOpacity(PanInput, 0.0, 50),
			ModAnimation.AaOpacity(PanInput, 0.0 - ((UIElement)PanInput).Opacity, 110, 0, new ModAnimation.AniEaseInFluent(), After: true),
			ModAnimation.AaScaleTransform(PanInput, 1.2 - ((ScaleTransform)((UIElement)PanInput).RenderTransform).ScaleX, 160),
			ModAnimation.AaOpacity(PanLaunching, 1.0 - ((UIElement)PanLaunching).Opacity, 150, 100),
			ModAnimation.AaScaleTransform(PanLaunching, 1.0 - ((ScaleTransform)((UIElement)PanLaunching).RenderTransform).ScaleX, 500, 100, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)),
			ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
			{
				((UIElement)PanLaunching).IsHitTestVisible = true;
			}), 150)
		}, "Launch State Page");
	}

	public void PageChangeToLogin()
	{
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		NewLateBinding.LateCall(PageGet(PageCurrent), (System.Type)null, "Reload", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
		((UIElement)PanInput).IsHitTestVisible = false;
		((UIElement)PanLaunching).IsHitTestVisible = false;
		LoadLaunching.State.LoadingState = MyLoading.MyLoadingState.Stop;
		((UIElement)PanInput).Visibility = (Visibility)0;
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[5]
		{
			ModAnimation.AaOpacity(PanLaunching, 0.0 - ((UIElement)PanLaunching).Opacity, 150),
			ModAnimation.AaScaleTransform(PanLaunching, 0.8 - ((ScaleTransform)((UIElement)PanLaunching).RenderTransform).ScaleX, 150, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)),
			ModAnimation.AaOpacity(PanInput, 1.0 - ((UIElement)PanInput).Opacity, 250, 50),
			ModAnimation.AaScaleTransform(PanInput, 1.0 - ((ScaleTransform)((UIElement)PanInput).RenderTransform).ScaleX, 300, 50, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)),
			ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
			{
				((UIElement)PanInput).IsHitTestVisible = true;
			}), 200)
		}, "Launch State Page", RefreshTime: true);
	}

	private object PageGet(PageType Type)
	{
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		switch (Type)
		{
		case PageType.Auth:
			if (Information.IsNothing((object)ModMain.FrmLoginAuth))
			{
				ModMain.FrmLoginAuth = new PageLoginAuth();
			}
			return ModMain.FrmLoginAuth;
		case PageType.Ms:
			if (Information.IsNothing((object)ModMain.FrmLoginMs))
			{
				ModMain.FrmLoginMs = new PageLoginMs();
			}
			return ModMain.FrmLoginMs;
		case PageType.Profile:
			if (Information.IsNothing((object)ModMain.FrmLoginProfile))
			{
				ModMain.FrmLoginProfile = new PageLoginProfile();
			}
			return ModMain.FrmLoginProfile;
		case PageType.ProfileSkin:
			if (Information.IsNothing((object)ModMain.FrmLoginProfileSkin))
			{
				ModMain.FrmLoginProfileSkin = new PageLoginProfileSkin();
			}
			return ModMain.FrmLoginProfileSkin;
		case PageType.Offline:
			if (Information.IsNothing((object)ModMain.FrmLoginOffline))
			{
				ModMain.FrmLoginOffline = new PageLoginOffline();
			}
			return ModMain.FrmLoginOffline;
		default:
			throw new ArgumentOutOfRangeException("Type", "即将切换的登录分页编号越界");
		}
	}

	private object PageChange(PageType Type, bool Anim)
	{
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		object obj = ModMain.FrmLoginMs;
		checked
		{
			object result;
			try
			{
				if (PageCurrent == Type)
				{
					result = obj;
				}
				else
				{
					obj = RuntimeHelpers.GetObjectValue(PageGet(Type));
					ModAnimation.AniStop("FrmLogin PageChange");
					if (!Information.IsNothing(RuntimeHelpers.GetObjectValue(obj)) && !Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null))))
					{
						NewLateBinding.LateCall(obj, (System.Type)null, "SetValue", new object[2]
						{
							ContentPresenter.ContentProperty,
							null
						}, (string[])null, (System.Type[])null, (bool[])null, true);
					}
					if (Anim)
					{
						ThreadStart val = default(ThreadStart);
						((DispatcherObject)this).Dispatcher.Invoke((Action)([SpecialName] () =>
						{
							//IL_0052: Unknown result type (might be due to invalid IL or missing references)
							//IL_0057: Unknown result type (might be due to invalid IL or missing references)
							//IL_0059: Expected O, but got Unknown
							//IL_005e: Expected O, but got Unknown
							ModAnimation.AniData[] obj2 = new ModAnimation.AniData[3]
							{
								ModAnimation.AaOpacity(PanLogin, 0.0 - ((UIElement)PanLogin).Opacity, 100, 0, new ModAnimation.AniEaseOutFluent()),
								default(ModAnimation.AniData),
								default(ModAnimation.AniData)
							};
							ThreadStart code;
							if (val != null)
							{
								code = val;
							}
							else
							{
								ThreadStart val2 = [SpecialName] () =>
								{
									//IL_0037: Unknown result type (might be due to invalid IL or missing references)
									//IL_0041: Expected O, but got Unknown
									ModAnimation.AniControlEnabled++;
									((Panel)PanLogin).Children.Clear();
									((Panel)PanLogin).Children.Add((UIElement)obj);
									ModAnimation.AniControlEnabled--;
								};
								ThreadStart val3 = val2;
								val = val2;
								code = val3;
							}
							obj2[1] = ModAnimation.AaCode(code, 100);
							obj2[2] = ModAnimation.AaOpacity(PanLogin, 1.0, 100, 120, new ModAnimation.AniEaseInFluent());
							ModAnimation.AniStart((System.Collections.IList)(object)obj2, "FrmLogin PageChange");
						}), (DispatcherPriority)7);
					}
					else
					{
						ModAnimation.AniControlEnabled++;
						((Panel)PanLogin).Children.Clear();
						((Panel)PanLogin).Children.Add((UIElement)obj);
						ModAnimation.AniControlEnabled--;
					}
					PageCurrent = Type;
					result = obj;
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "切换登录分页失败（" + ModBase.GetStringFromEnum(Type) + "）", ModBase.LogLevel.Feedback);
				result = obj;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public void RefreshPage(bool Anim, ModLaunch.McLoginType TargetLoginType = (ModLaunch.McLoginType)0)
	{
		PageType pageType = default(PageType);
		if (TargetLoginType != 0)
		{
			if (TargetLoginType == ModLaunch.McLoginType.Ms)
			{
				pageType = PageType.Ms;
			}
			if (TargetLoginType == ModLaunch.McLoginType.Auth)
			{
				pageType = PageType.Auth;
			}
			if (TargetLoginType == ModLaunch.McLoginType.Legacy)
			{
				pageType = PageType.Offline;
			}
		}
		else if (ModProfile.SelectedProfile != null)
		{
			pageType = PageType.ProfileSkin;
			((UIElement)BtnLaunch).IsEnabled = true;
		}
		else
		{
			pageType = PageType.Profile;
			if (Operators.CompareString(BtnLaunch.Text, "下载游戏", false) != 0)
			{
				((UIElement)BtnLaunch).IsEnabled = false;
			}
		}
		if (PageCurrent != pageType)
		{
			PageChange(pageType, Anim);
		}
	}

	private static ModBase.EqualableList<string> SkinMsInput()
	{
		ModBase.EqualableList<string> equalableList = new ModBase.EqualableList<string>();
		((List<string>)equalableList).Add(ModProfile.SelectedProfile.Username);
		((List<string>)equalableList).Add(ModProfile.SelectedProfile.Uuid);
		return equalableList;
	}

	private static void SkinMsLoad(ModLoader.LoaderTask<ModBase.EqualableList<string>, string> Data)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		object action;
		if (_Closure_0024__._0024I14_002D0 != null)
		{
			action = _Closure_0024__._0024I14_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				if (ModMain.FrmLoginProfileSkin != null && ModMain.FrmLoginProfileSkin.Skin != null)
				{
					ModMain.FrmLoginProfileSkin.Skin.Clear();
				}
			};
			_Closure_0024__._0024I14_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
		string text = ((List<string>)Data.Input)[0];
		string uuid = ((List<string>)Data.Input)[1];
		if (ModProfile.SelectedProfile != null)
		{
			text = ModProfile.SelectedProfile.Username;
			uuid = ModProfile.SelectedProfile.Uuid;
		}
		if (Operators.CompareString(text, "", false) == 0)
		{
			Data.Output = ModBase.PathImage + "Skins/" + ModMinecraft.McSkinSex(ModProfile.GetOfflineUuid(text)) + ".png";
			ModBase.Log("[Minecraft] 获取微软正版皮肤失败，ID 为空");
		}
		else
		{
			try
			{
				string address = ModMinecraft.McSkinGetAddress(uuid, "Ms");
				if (Data.IsAborted)
				{
					throw new ThreadInterruptedException("当前任务已取消：" + text);
				}
				address = ModMinecraft.McSkinDownload(address);
				if (Data.IsAborted)
				{
					throw new ThreadInterruptedException("当前任务已取消：" + text);
				}
				Data.Output = address;
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				if (Operators.CompareString(((MemberInfo)ex2.GetType()).Name, "ThreadInterruptedException", false) == 0)
				{
					Data.Output = "";
					ModBase.Log("[Minecraft] 已取消皮肤获取：" + text);
					ProjectData.ClearProjectError();
					return;
				}
				if (ex2.ToString().Contains("429"))
				{
					Data.Output = ModBase.PathImage + "Skins/" + ModMinecraft.McSkinSex(ModProfile.GetOfflineUuid(text)) + ".png";
					ModBase.Log("[Minecraft] 获取正版皮肤失败（" + text + "）：获取皮肤太过频繁，请 5 分钟后再试！", ModBase.LogLevel.Hint);
				}
				else if (ex2.ToString().Contains("未设置自定义皮肤"))
				{
					Data.Output = ModBase.PathImage + "Skins/" + ModMinecraft.McSkinSex(ModProfile.GetOfflineUuid(text)) + ".png";
					ModBase.Log("[Minecraft] 用户未设置自定义皮肤，跳过皮肤加载");
				}
				else
				{
					Data.Output = ModBase.PathImage + "Skins/" + ModMinecraft.McSkinSex(ModProfile.GetOfflineUuid(text)) + ".png";
					ModBase.Log(ex2, "获取微软正版皮肤失败（" + text + "）", ModBase.LogLevel.Hint);
				}
				ProjectData.ClearProjectError();
			}
		}
		if (ModMain.FrmLoginProfileSkin != null && ModMain.FrmLoginProfileSkin.Skin.Loader == Data)
		{
			ModBase.RunInUi(new Action(ModMain.FrmLoginProfileSkin.Skin.Load));
		}
		else if (!Data.IsAborted)
		{
			Data.Input = null;
		}
	}

	private static ModBase.EqualableList<string> SkinLegacyInput()
	{
		ModBase.EqualableList<string> equalableList = new ModBase.EqualableList<string>();
		((List<string>)equalableList).Add(ModProfile.SelectedProfile.Username);
		((List<string>)equalableList).Add(ModProfile.SelectedProfile.Uuid);
		return equalableList;
	}

	private static void SkinLegacyLoad(ModLoader.LoaderTask<ModBase.EqualableList<string>, string> Data)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I17_002D0 != null)
		{
			action = _Closure_0024__._0024I17_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				if (ModMain.FrmLoginProfileSkin != null && ModMain.FrmLoginProfileSkin.Skin != null)
				{
					ModMain.FrmLoginProfileSkin.Skin.Clear();
				}
			};
			_Closure_0024__._0024I17_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
		Data.Output = ModBase.PathImage + "Skins/" + ModMinecraft.McSkinSex(((List<string>)Data.Input)[1]) + ".png";
		if (ModMain.FrmLoginProfileSkin != null && ModMain.FrmLoginProfileSkin.Skin.Loader == Data)
		{
			object action2;
			if (_Closure_0024__._0024I17_002D1 != null)
			{
				action2 = _Closure_0024__._0024I17_002D1;
			}
			else
			{
				Action val2 = [SpecialName] () =>
				{
					ModMain.FrmLoginProfileSkin.Skin.Load();
				};
				_Closure_0024__._0024I17_002D1 = val2;
				action2 = (object)val2;
			}
			ModBase.RunInUi((Action)action2);
		}
		else if (!Data.IsAborted)
		{
			Data.Input = null;
		}
	}

	private static ModBase.EqualableList<string> SkinAuthInput()
	{
		ModBase.EqualableList<string> equalableList = new ModBase.EqualableList<string>();
		((List<string>)equalableList).Add(ModProfile.SelectedProfile.Username);
		((List<string>)equalableList).Add(ModProfile.SelectedProfile.Uuid);
		return equalableList;
	}

	private static void SkinAuthLoad(ModLoader.LoaderTask<ModBase.EqualableList<string>, string> Data)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I20_002D0 != null)
		{
			action = _Closure_0024__._0024I20_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				if (ModMain.FrmLoginProfileSkin != null && ModMain.FrmLoginProfileSkin.Skin != null)
				{
					ModMain.FrmLoginProfileSkin.Skin.Clear();
				}
			};
			_Closure_0024__._0024I20_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
		string text = ((List<string>)Data.Input)[0];
		string uuid = ((List<string>)Data.Input)[1];
		if (Operators.CompareString(text, "", false) == 0)
		{
			Data.Output = ModBase.PathImage + "Skins/Steve.png";
			ModBase.Log("[Minecraft] 获取 Authlib-Injector 皮肤失败，ID 为空");
		}
		else
		{
			try
			{
				string address = ModMinecraft.McSkinGetAddress(uuid, "Auth");
				if (Data.IsAborted)
				{
					throw new ThreadInterruptedException("当前任务已取消：" + text);
				}
				address = ModMinecraft.McSkinDownload(address);
				if (Data.IsAborted)
				{
					throw new ThreadInterruptedException("当前任务已取消：" + text);
				}
				Data.Output = address;
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				if (Operators.CompareString(((MemberInfo)ex2.GetType()).Name, "ThreadInterruptedException", false) == 0)
				{
					Data.Output = "";
					ProjectData.ClearProjectError();
					return;
				}
				if (ex2.ToString().Contains("429"))
				{
					Data.Output = ModBase.PathImage + "Skins/Steve.png";
					ModBase.Log("[Minecraft] 获取 Authlib-Injector 皮肤失败（" + text + "）：获取皮肤太过频繁，请 5 分钟后再试！", ModBase.LogLevel.Hint);
				}
				else if (ex2.ToString().Contains("未设置自定义皮肤"))
				{
					Data.Output = ModBase.PathImage + "Skins/Steve.png";
					ModBase.Log("[Minecraft] 用户未设置自定义皮肤，跳过皮肤加载");
				}
				else
				{
					Data.Output = ModBase.PathImage + "Skins/Steve.png";
					ModBase.Log(ex2, "获取 Authlib-Injector 皮肤失败（" + text + "）", ModBase.LogLevel.Hint);
				}
				ProjectData.ClearProjectError();
			}
		}
		if (ModMain.FrmLoginProfileSkin != null && ModMain.FrmLoginProfileSkin.Skin.Loader == Data)
		{
			ModBase.RunInUi(new Action(ModMain.FrmLoginProfileSkin.Skin.Load));
		}
		else if (!Data.IsAborted)
		{
			Data.Input = null;
		}
	}

	private void BtnInstance_Click(object sender, EventArgs e)
	{
		if (ModLaunch.McLaunchLoader.State != ModBase.LoadState.Loading)
		{
			ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSelect);
		}
	}

	public void LaunchButtonClick()
	{
		if (ModLaunch.McLaunchLoader.State == ModBase.LoadState.Loading || !((UIElement)BtnLaunch).IsEnabled || (ModMain.FrmMain.PageRight != null && ModMain.FrmMain.PageRight.PageState != MyPageRight.PageStates.ContentStay && ModMain.FrmMain.PageRight.PageState != MyPageRight.PageStates.ContentEnter))
		{
			return;
		}
		if (ModMain.IsAprilEnabled && !ModMain.IsAprilGiveup)
		{
			ModSecret.ThemeUnlock(12, ShowDoubleHint: false, "隐藏主题 滑稽彩 已解锁！");
			ModMain.IsAprilGiveup = true;
			ModMain.FrmLaunchLeft.AprilScaleTrans.ScaleX = 1.0;
			ModMain.FrmLaunchLeft.AprilScaleTrans.ScaleY = 1.0;
			ModMain.FrmLaunchLeft.AprilPosTrans.X = 0.0;
			ModMain.FrmLaunchLeft.AprilPosTrans.Y = 0.0;
			ModMain.FrmMain.BtnExtraApril.ShowRefresh();
		}
		if (Operators.CompareString(BtnLaunch.Text, "启动游戏", false) == 0)
		{
			if (File.Exists(ModMinecraft.McInstanceCurrent.Path + ".pclignore"))
			{
				ModMain.Hint("当前实例正在安装，无法启动！", ModMain.HintType.Critical);
			}
			else
			{
				ModLaunch.McLaunchStart();
			}
		}
		else if (Operators.CompareString(BtnLaunch.Text, "下载游戏", false) == 0)
		{
			ModMain.FrmMain.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadInstall);
		}
	}

	public void RefreshButtonsUI()
	{
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		if (!((FrameworkElement)BtnLaunch).IsLoaded)
		{
			return;
		}
		int num = ((IsLoadFinished && ModMinecraft.McInstanceListLoader.State != ModBase.LoadState.Loading && ModMinecraft.McFolderListLoader.State != ModBase.LoadState.Loading) ? (((object)ModMinecraft.McInstanceCurrent != null) ? 3 : (Conversions.ToBoolean((object)(Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenPageDownload")) && !PageSetupUI.HiddenForceShow)) ? 1 : 2)) : 0);
		if (num != BtnLaunchState || Operators.CompareString(((object)ModMinecraft.McInstanceCurrent == null) ? "" : ModMinecraft.McInstanceCurrent.Path, ((object)BtnLaunchVersion == null) ? "" : BtnLaunchVersion.Path, false) != 0)
		{
			BtnLaunchVersion = ModMinecraft.McInstanceCurrent;
			BtnLaunchState = num;
			switch (num)
			{
			case 0:
				ModBase.Log("[Minecraft] 启动按钮：正在加载 Minecraft 实例");
				ModMain.FrmLaunchLeft.BtnLaunch.Text = "正在加载";
				((UIElement)ModMain.FrmLaunchLeft.BtnLaunch).IsEnabled = false;
				ModMain.FrmLaunchLeft.LabVersion.Text = "正在加载中，请稍候";
				((UIElement)ModMain.FrmLaunchLeft.BtnInstance).IsEnabled = false;
				((UIElement)ModMain.FrmLaunchLeft.BtnMore).Visibility = (Visibility)2;
				break;
			case 1:
				ModBase.Log("[Minecraft] 启动按钮：无 Minecraft 实例，下载已禁用");
				ModMain.FrmLaunchLeft.BtnLaunch.Text = "启动游戏";
				((UIElement)ModMain.FrmLaunchLeft.BtnLaunch).IsEnabled = false;
				ModMain.FrmLaunchLeft.LabVersion.Text = "未找到可用的游戏实例";
				((UIElement)ModMain.FrmLaunchLeft.BtnInstance).IsEnabled = true;
				((UIElement)ModMain.FrmLaunchLeft.BtnMore).Visibility = (Visibility)2;
				break;
			case 2:
				ModBase.Log("[Minecraft] 启动按钮：无 Minecraft 实例，要求下载");
				ModMain.FrmLaunchLeft.BtnLaunch.Text = "下载游戏";
				((UIElement)ModMain.FrmLaunchLeft.BtnLaunch).IsEnabled = true;
				ModMain.FrmLaunchLeft.LabVersion.Text = "未找到可用的游戏实例";
				((UIElement)ModMain.FrmLaunchLeft.BtnInstance).IsEnabled = true;
				((UIElement)ModMain.FrmLaunchLeft.BtnMore).Visibility = (Visibility)2;
				break;
			case 3:
				ModBase.Log("[Minecraft] 启动按钮：Minecraft 实例：" + ModMinecraft.McInstanceCurrent.Path);
				ModMain.FrmLaunchLeft.BtnLaunch.Text = "启动游戏";
				((UIElement)ModMain.FrmLaunchLeft.BtnInstance).IsEnabled = true;
				ModMain.FrmLaunchLeft.LabVersion.Text = ModMinecraft.McInstanceCurrent.Name;
				break;
			}
		}
		((UIElement)ModMain.FrmLaunchLeft.BtnInstance).Visibility = (Visibility)(Conversions.ToBoolean((object)(!PageSetupUI.HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenFunctionSelect")))) ? 2 : 0);
		if (num == 3)
		{
			((UIElement)ModMain.FrmLaunchLeft.BtnMore).Visibility = ((UIElement)ModMain.FrmLaunchLeft.BtnInstance).Visibility;
		}
	}

	private void BtnCancel_Click()
	{
		if (ModLaunch.McLaunchLoaderReal == null)
		{
			return;
		}
		ModLaunch.McLaunchLoaderReal.Abort();
		ModLaunch.McLaunchLog("已取消启动");
		try
		{
			if (ModLaunch.McLaunchWatcher != null)
			{
				ModLaunch.McLaunchWatcher.Kill();
			}
			else if (ModLaunch.McLaunchProcess != null && !ModLaunch.McLaunchProcess.HasExited)
			{
				ModLaunch.McLaunchProcess.Kill();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "取消启动结束进程失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnMore_Click(object sender, EventArgs e)
	{
		if (ModLaunch.McLaunchLoader.State != ModBase.LoadState.Loading)
		{
			ModMinecraft.McInstanceCurrent.Load();
			PageInstanceLeft.Instance = ModMinecraft.McInstanceCurrent;
			if (File.Exists(ModMinecraft.McInstanceCurrent.Path + ".pclignore"))
			{
				ModMain.Hint("当前实例正在安装，暂无法进行实例设置！", ModMain.HintType.Critical);
			}
			else
			{
				ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSetup);
			}
		}
	}

	public void LaunchingRefresh()
	{
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Invalid comparison between Unknown and I4
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Expected O, but got Unknown
		try
		{
			_Closure_0024__29_002D0 arg = default(_Closure_0024__29_002D0);
			_Closure_0024__29_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__29_002D0(null);
			CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
			if (ModLaunch.McLaunchLoaderReal.State == ModBase.LoadState.Aborted)
			{
				return;
			}
			bool flag = false;
			try
			{
				System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
				try
				{
					enumerator = ModLaunch.McLaunchLoaderReal.GetLoaderList(RequireShow: false).GetEnumerator();
					while (enumerator.MoveNext())
					{
						ModLoader.LoaderBase current = enumerator.Current;
						if (current.State != ModBase.LoadState.Loading && current.State != 0)
						{
							continue;
						}
						LabLaunchingStage.Text = current.Name;
						flag = Operators.CompareString(current.Name, "等待游戏窗口出现", false) == 0 || Operators.CompareString(current.Name, "结束处理", false) == 0;
						goto end_IL_0022;
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				LabLaunchingStage.Text = "已完成";
				end_IL_0022:;
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "获取是否启动完成失败，可能是由于启动状态改变导致集合已修改");
				ProjectData.ClearProjectError();
				return;
			}
			if (ModAnimation.AniIsRun("Launch State Page"))
			{
				flag = false;
			}
			double progress = ModLaunch.McLaunchLoaderReal.Progress;
			if (progress >= ShowProgress)
			{
				ShowProgress += (progress - ShowProgress) * 0.2 + 0.005;
			}
			if (progress <= ShowProgress)
			{
				ShowProgress = progress;
			}
			if (flag)
			{
				ShowProgress = 1.0;
			}
			LabLaunchingTitle.Text = (flag ? "已启动游戏" : ((ModLaunch.CurrentLaunchOptions.SaveBatch == null) ? "正在启动游戏" : "正在导出启动脚本"));
			LabLaunchingProgress.Text = ModBase.StrFillNum(ShowProgress * 100.0, 2) + " %";
			CS_0024_003C_003E8__locals0._0024VB_0024Local_HasLaunchDownloader = false;
			try
			{
				System.Collections.Generic.IEnumerator<ModNet.LoaderDownload> enumerator2 = default(System.Collections.Generic.IEnumerator<ModNet.LoaderDownload>);
				try
				{
					enumerator2 = ModNet.NetManager.Tasks.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator2).MoveNext())
					{
						ModNet.LoaderDownload current2 = enumerator2.Current;
						if (current2.RealParent != null && Operators.CompareString(current2.RealParent.Name, "Minecraft 启动", false) == 0 && current2.State == ModBase.LoadState.Loading)
						{
							CS_0024_003C_003E8__locals0._0024VB_0024Local_HasLaunchDownloader = true;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator2)?.Dispose();
				}
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "获取 Minecraft 启动下载器失败，可能是因为启动被取消");
				CS_0024_003C_003E8__locals0._0024VB_0024Local_HasLaunchDownloader = false;
				ProjectData.ClearProjectError();
			}
			LabLaunchingDownload.Text = ModBase.GetString(ModNet.NetManager.Speed) + "/s";
			List<ModAnimation.AniData> obj = new List<ModAnimation.AniData>();
			ColumnDefinition progressLaunchingFinished = ProgressLaunchingFinished;
			double showProgress = ShowProgress;
			GridLength width = ProgressLaunchingFinished.Width;
			obj.Add(ModAnimation.AaGridLengthWidth(progressLaunchingFinished, showProgress - width.Value, 260, 0, new ModAnimation.AniEaseOutFluent()));
			ColumnDefinition progressLaunchingUnfinished = ProgressLaunchingUnfinished;
			double num = 1.0 - ShowProgress;
			width = ProgressLaunchingUnfinished.Width;
			obj.Add(ModAnimation.AaGridLengthWidth(progressLaunchingUnfinished, num - width.Value, 260, 0, new ModAnimation.AniEaseOutFluent()));
			List<ModAnimation.AniData> val = obj;
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_HasLaunchDownloader == ((int)((UIElement)LabLaunchingDownload).Visibility == 2))
			{
				((UIElement)LabLaunchingDownload).Visibility = (Visibility)0;
				((UIElement)LabLaunchingDownloadLeft).Visibility = (Visibility)0;
				val.AddRange((System.Collections.Generic.IEnumerable<ModAnimation.AniData>)new ModAnimation.AniData[3]
				{
					ModAnimation.AaOpacity(LabLaunchingDownload, (double)(CS_0024_003C_003E8__locals0._0024VB_0024Local_HasLaunchDownloader ? 1 : 0) - ((UIElement)LabLaunchingDownload).Opacity, 100),
					ModAnimation.AaOpacity(LabLaunchingDownloadLeft, (CS_0024_003C_003E8__locals0._0024VB_0024Local_HasLaunchDownloader ? 0.5 : 0.0) - ((UIElement)LabLaunchingDownloadLeft).Opacity, 100),
					ModAnimation.AaCode((ThreadStart)([SpecialName] () =>
					{
						if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_HasLaunchDownloader)
						{
							((UIElement)CS_0024_003C_003E8__locals0._0024VB_0024Me.LabLaunchingDownload).Visibility = (Visibility)2;
							((UIElement)CS_0024_003C_003E8__locals0._0024VB_0024Me.LabLaunchingDownloadLeft).Visibility = (Visibility)2;
						}
					}), 110)
				});
			}
			if (!flag == ((int)((UIElement)LabLaunchingProgress).Visibility == 2))
			{
				((UIElement)LabLaunchingProgress).Visibility = (Visibility)0;
				((UIElement)LabLaunchingProgressLeft).Visibility = (Visibility)0;
				val.AddRange((System.Collections.Generic.IEnumerable<ModAnimation.AniData>)new ModAnimation.AniData[2]
				{
					ModAnimation.AaOpacity(LabLaunchingProgress, (double)((!flag) ? 1 : 0) - ((UIElement)LabLaunchingProgress).Opacity, 100),
					ModAnimation.AaOpacity(LabLaunchingProgressLeft, ((!flag) ? 0.5 : 0.0) - ((UIElement)LabLaunchingProgressLeft).Opacity, 100)
				});
			}
			ModAnimation.AniStart((System.Collections.IList)val, "Launching Progress");
		}
		catch (System.Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			System.Exception ex6 = ex5;
			ModBase.Log(ex6, "刷新启动信息失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void PanLaunchingInfo_SizeChangedW(object sender, SizeChangedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		Size val = e.NewSize;
		double width = val.Width;
		val = e.PreviousSize;
		double num = width - val.Width;
		val = e.PreviousSize;
		if (val.Width != 0.0 && !IsWidthAnimating && !(Math.Abs(num) < 1.0) && ((FrameworkElement)PanLaunchingInfo).ActualWidth != 0.0)
		{
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
			{
				ModAnimation.AaWidth(PanLaunchingInfo, num, 180, 0, new ModAnimation.AniEaseOutFluent()),
				ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
				{
					IsWidthAnimating = false;
					((FrameworkElement)PanLaunchingInfo).Width = ActualUsedWidth;
				}), 0, After: true)
			}, "Launching Info Width");
			IsWidthAnimating = true;
			ActualUsedWidth = ((FrameworkElement)PanLaunchingInfo).Width;
			Grid panLaunchingInfo = PanLaunchingInfo;
			val = e.PreviousSize;
			((FrameworkElement)panLaunchingInfo).Width = val.Width;
		}
	}

	private void PanLaunchingInfo_SizeChangedH(object sender, SizeChangedEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		Size val = e.NewSize;
		double height = val.Height;
		val = e.PreviousSize;
		double num = height - val.Height;
		val = e.PreviousSize;
		if (val.Height != 0.0 && !IsHeightAnimating && !(Math.Abs(num) < 1.0) && ((FrameworkElement)PanLaunchingInfo).ActualHeight != 0.0)
		{
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
			{
				ModAnimation.AaHeight(PanLaunchingInfo, num, 180, 0, new ModAnimation.AniEaseOutFluent()),
				ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
				{
					IsHeightAnimating = false;
					((FrameworkElement)PanLaunchingInfo).Height = ActualUsedHeight;
				}), 0, After: true)
			}, "Launching Info Height");
			IsHeightAnimating = true;
			ActualUsedHeight = ((FrameworkElement)PanLaunchingInfo).Height;
			Grid panLaunchingInfo = PanLaunchingInfo;
			val = e.PreviousSize;
			((FrameworkElement)panLaunchingInfo).Height = val.Height;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelaunch/pagelaunchleft.xaml", (UriKind)2);
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
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (PageLaunchLeft)target;
			break;
		case 2:
			PanInput = (Grid)target;
			break;
		case 3:
			BtnInstance = (MyButton)target;
			break;
		case 4:
			BtnMore = (MyButton)target;
			break;
		case 5:
			PanLogin = (Grid)target;
			break;
		case 6:
			AprilScaleTrans = (ScaleTransform)target;
			break;
		case 7:
			AprilPosTrans = (TranslateTransform)target;
			break;
		case 8:
			BtnLaunch = (MyButton)target;
			break;
		case 9:
			LabVersion = (TextBlock)target;
			break;
		case 10:
			PanLaunching = (Grid)target;
			break;
		case 11:
			LoadLaunching = (MyLoading)target;
			break;
		case 12:
			LabLaunchingTitle = (TextBlock)target;
			break;
		case 13:
			LabLaunchingName = (TextBlock)target;
			break;
		case 14:
			ProgressLaunchingFinished = (ColumnDefinition)target;
			break;
		case 15:
			ProgressLaunchingUnfinished = (ColumnDefinition)target;
			break;
		case 16:
			PanLaunchingInfo = (Grid)target;
			break;
		case 17:
			LabLaunchingStage = (TextBlock)target;
			break;
		case 18:
			LabLaunchingMethod = (TextBlock)target;
			break;
		case 19:
			LabLaunchingProgressLeft = (TextBlock)target;
			break;
		case 20:
			LabLaunchingProgress = (TextBlock)target;
			break;
		case 21:
			LabLaunchingDownloadLeft = (TextBlock)target;
			break;
		case 22:
			LabLaunchingDownload = (TextBlock)target;
			break;
		case 23:
			BtnCancel = (MyButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
