using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.App;
using PCL.Core.App.Configuration;
using PCL.Core.Utils;
using PCL.Core.Utils.OS;

namespace PCL;

public class Application : System.Windows.Application, IStyleConnector
{
	public class BindingErrorTraceListener : TraceListener
	{
		public override void Write(string message)
		{
			ModBase.Log($"警告，检测到 Binding 失败：{message}");
		}

		public override void WriteLine(string message)
		{
			ModBase.Log($"警告，检测到 Binding 失败：{message}");
		}
	}

	public static readonly List<Border> ShowingTooltips = new List<Border>();

	private bool _contentLoaded;

	public Application()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		((Application)this).SessionEnding += new SessionEndingCancelEventHandler(Application_SessionEnding);
		Basics.VersionName = "2.13.3";
		Basics.VersionNumber = 413;
		Lifecycle.When(LifecycleState.Loaded, new Action(Application_Startup));
	}

	private void Application_Startup()
	{
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Expected O, but got Unknown
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Expected O, but got Unknown
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected O, but got Unknown
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Expected O, but got Unknown
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Expected O, but got Unknown
		//IL_071f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected O, but got Unknown
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
				PresentationTraceSources.DataBindingSource.Listeners.Add((TraceListener)(object)new BindingErrorTraceListener());
				PresentationTraceSources.DataBindingSource.Switch.Level = (SourceLevels)3;
				ModSecret.SecretOnApplicationStart();
				string[] array = Enumerable.ToArray<string>(Enumerable.Skip<string>((System.Collections.Generic.IEnumerable<string>)Environment.GetCommandLineArgs(), 1));
				if (array.Length > 0)
				{
					if (Operators.CompareString(array[0], "--update", false) == 0)
					{
						ModSecret.UpdateReplace(Conversions.ToInteger(array[1]), array[2].Trim('"'), array[3].Trim('"'), Conversions.ToBoolean(array[4]));
						Environment.Exit(5);
					}
					else if (Operators.CompareString(array[0], "--gpu", false) == 0)
					{
						try
						{
							ModMain.SetGPUPreference(array[1].Trim('"'));
							Environment.Exit(5);
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							Environment.Exit(1);
							ProjectData.ClearProjectError();
						}
					}
					else if (ModBase.StartsWithF(array[0], "--memory"))
					{
						ulong availablePhysicalMemoryBytes = KernelInterop.GetAvailablePhysicalMemoryBytes();
						try
						{
							PageOtherTest.MemoryOptimizeInternal(ShowHint: false);
						}
						catch (System.Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							System.Exception ex4 = ex3;
							Interaction.MsgBox((object)ex4.Message, (MsgBoxStyle)16, (object)"内存优化失败");
							Environment.Exit(-1);
							ProjectData.ClearProjectError();
						}
						if (KernelInterop.GetAvailablePhysicalMemoryBytes() < availablePhysicalMemoryBytes)
						{
							Environment.Exit(0);
						}
						else
						{
							Environment.Exit((int)Math.Round((double)(KernelInterop.GetAvailablePhysicalMemoryBytes() - availablePhysicalMemoryBytes) / 1024.0));
						}
					}
				}
				Directory.CreateDirectory(ModBase.ExePath + "PCL\\Pictures");
				Directory.CreateDirectory(ModBase.ExePath + "PCL\\Musics");
				try
				{
					Directory.CreateDirectory(ModBase.PathTemp);
					if (!ModBase.CheckPermission(ModBase.PathTemp))
					{
						throw new System.Exception("PCL 没有对 " + ModBase.PathTemp + " 的访问权限");
					}
				}
				catch (System.Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					System.Exception ex6 = ex5;
					if (Operators.CompareString(ModBase.PathTemp, Path.GetTempPath() + "PCL\\", false) == 0)
					{
						ModMain.MyMsgBox("PCL 无法访问缓存文件夹，可能导致程序出错或无法正常使用！\r\n错误原因：" + ex6.ToString(), "缓存文件夹不可用");
					}
					else
					{
						ModMain.MyMsgBox("手动设置的缓存文件夹不可用，PCL 将使用默认缓存文件夹。\r\n错误原因：" + ex6.ToString(), "缓存文件夹不可用");
						ModBase.Setup.Set("SystemSystemCache", "");
						ModBase.PathTemp = Path.GetTempPath() + "PCL\\";
					}
					ProjectData.ClearProjectError();
				}
				Directory.CreateDirectory(ModBase.PathTemp + "Cache");
				Directory.CreateDirectory(ModBase.PathTemp + "Download");
				Directory.CreateDirectory(ModBase.PathAppdata);
				ToolTipService.InitialShowDelayProperty.OverrideMetadata(typeof(DependencyObject), (PropertyMetadata)new FrameworkPropertyMetadata((object)300));
				ToolTipService.BetweenShowDelayProperty.OverrideMetadata(typeof(DependencyObject), (PropertyMetadata)new FrameworkPropertyMetadata((object)400));
				ToolTipService.ShowDurationProperty.OverrideMetadata(typeof(DependencyObject), (PropertyMetadata)new FrameworkPropertyMetadata((object)9999999));
				ToolTipService.PlacementProperty.OverrideMetadata(typeof(DependencyObject), (PropertyMetadata)new FrameworkPropertyMetadata((object)(PlacementMode)2));
				ToolTipService.HorizontalOffsetProperty.OverrideMetadata(typeof(DependencyObject), (PropertyMetadata)new FrameworkPropertyMetadata((object)8.0));
				ToolTipService.VerticalOffsetProperty.OverrideMetadata(typeof(DependencyObject), (PropertyMetadata)new FrameworkPropertyMetadata((object)4.0));
				if (Conversions.ToBoolean(ModBase.Setup.Get("UiLauncherLogo")))
				{
					ModMain.FrmStart = new SplashScreen("Images\\icon.ico");
					ModMain.FrmStart.Show(false, true);
				}
				ModBase.Log(string.Format("[Start] 程序版本：{0} (Channel: {1},Code: {2}{3})", new object[4]
				{
					"2.13.3",
					"Publish",
					413,
					(Operators.CompareString(ModBase.CommitHash, "", false) == 0) ? "" : $"，#{ModBase.CommitHash}"
				}));
				ModBase.Log($"[Start] 识别码：{ModBase.UniqueAddress}");
				ModBase.Log($"[Start] 程序路径：{ModBase.ExePathWithName}");
				ModBase.Log($"[Start] 系统版本：{Environment.OSVersion.Version}, 架构：{RuntimeInformation.OSArchitecture}");
				ModBase.Log($"[Start] 系统编码：{Encoding.Default.HeaderName} ({Encoding.Default.CodePage}, GBK={ModBase.IsGBKEncoding})");
				ModBase.Log($"[Start] 管理员权限：{ProcessInterop.IsAdmin()}");
				List<string> val = new List<string>();
				if (KernelInterop.GetCurrentOSVersion().Build < 17763)
				{
					val.Add("- Windows 版本不满足推荐要求，推荐至少 Windows 10 1809，建议考虑升级 Windows 系统");
				}
				if (ModBase.Is32BitSystem)
				{
					val.Add("- 当前系统为 32 位，不受 PCL 和新版 Minecraft 支持，非常建议重装为 64 位系统后再进行游戏");
				}
				if (ModBase.ExePath.Contains(Path.GetTempPath()) || ModBase.ExePath.Contains("AppData\\Local\\Temp\\"))
				{
					val.Add("- PCL 正在临时目录运行，请将 PCL 从压缩包中解压之后再使用，否则可能导致游戏存档或设置丢失");
				}
				if (ModBase.ContainsF(ModBase.ExePath, "wechat_files", IgnoreCase: true) || ModBase.ContainsF(ModBase.ExePath, "WeChat Files", IgnoreCase: true) || ModBase.ContainsF(ModBase.ExePath, "Tencent Files", IgnoreCase: true))
				{
					val.Add("- PCL 正在 QQ、微信、TIM 等社交软件的下载目录运行，请考虑移动到其他位置，否则可能导致游戏存档或设置丢失");
				}
				if (val.Count != 0)
				{
					ModMain.MyMsgBox("PCL Pro-N 在启动时检测到环境问题：\r\n\r\n" + ModBase.Join((System.Collections.IEnumerable)val, "\r\n") + "\r\n\r\n不解决这些问题可能会导致部分功能无法正常工作……", "环境警告", "我知道了", "", "", IsWarn: true);
				}
				ModBase.Setup.Load("SystemDebugMode");
				ModBase.Setup.Load("SystemDebugAnim");
				ModBase.Setup.Load("SystemHttpProxy");
				ModBase.Setup.Load("SystemHttpProxyCustomUsername");
				ModBase.Setup.Load("SystemHttpProxyType");
				ModBase.Setup.Load("ToolDownloadThread");
				ModBase.Setup.Load("ToolDownloadSpeed");
				ModBase.Setup.Load("UiFont");
				ConfigItem<int> updateBranchConfig = Config.System.UpdateBranchConfig;
				if (updateBranchConfig.IsDefault())
				{
					updateBranchConfig.SetValue("2.13.3".Contains("beta") ? 1 : 0);
				}
				int num = 1;
				do
				{
					string text = $"{ModBase.ExePath}PCL\\Log-CE{num}.log";
					if (File.Exists(text))
					{
						File.Delete(text);
					}
					num++;
				}
				while (num <= 5);
				ModNativeInterop.StartEchoPipe();
				ModBase.Log("[Start] 第一阶段加载用时：" + Conversions.ToString(TimeUtils.GetTimeTick() - ModBase.ApplicationStartTick) + " ms");
				ModBase.ApplicationStartTick = TimeUtils.GetTimeTick();
				ModAnimation.AniControlEnabled++;
			}
			catch (System.Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				System.Exception ex8 = ex7;
				string text2 = null;
				try
				{
					text2 = ModBase.ExePathWithName;
				}
				catch (System.Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				Interaction.MsgBox((object)(ex8.ToString() + "\r\nPCL 所在路径：" + (string.IsNullOrEmpty(text2) ? "获取失败" : text2)), (MsgBoxStyle)16, (object)"PCL 初始化错误");
				FormMain.EndProgramForce(ModBase.ProcessReturnValues.Exception);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
	{
		ModMain.FrmMain.EndProgram(SendWarning: false);
	}

	private void MyIconButton_Click(object sender, EventArgs e)
	{
	}

	private void TooltipLoaded(object sender, EventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		ShowingTooltips.Add((Border)sender);
	}

	private void TooltipUnloaded(object sender, RoutedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		ShowingTooltips.Remove((Border)sender);
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/application.xaml", (UriKind)2);
			Application.LoadComponent((object)this, val);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	[EditorBrowsable(/*Could not decode attribute arguments.*/)]
	void IStyleConnector.Connect(int connectionId, object target)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		if (connectionId == 1)
		{
			((FrameworkElement)(Border)target).Loaded += new RoutedEventHandler(TooltipLoaded);
			((FrameworkElement)(Border)target).Unloaded += new RoutedEventHandler(TooltipUnloaded);
		}
		if (connectionId == 2)
		{
			((FrameworkElement)(Border)target).Loaded += new RoutedEventHandler(TooltipLoaded);
			((FrameworkElement)(Border)target).Unloaded += new RoutedEventHandler(TooltipUnloaded);
		}
	}

	
}
