using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCL.Core.App;
using PCL.Core.Minecraft;
using PCL.Core.Net;
using PCL.Core.Utils;
using PCL.Core.Utils.OS;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace PCL;

[StandardModule]
public sealed class ModLaunch
{
	public class McLaunchOptions
	{
		public string ServerIp;

		public string WorldName;

		public string SaveBatch;

		public ModMinecraft.McInstance Version;

		public List<string> ExtraArgs;

		public bool Test;

		public McLaunchOptions()
		{
			ServerIp = null;
			WorldName = null;
			SaveBatch = null;
			Version = null;
			ExtraArgs = new List<string>();
			Test = false;
		}
	}

	public enum McLoginType
	{
		Legacy = 1,
		Auth,
		Ms
	}

	public abstract class McLoginData
	{
		public McLoginType Type;

		public virtual bool Equals(object obj)
		{
			if (obj != null)
			{
				return obj.GetHashCode() == base.GetHashCode();
			}
			return false;
		}
	}

	public class McLoginServer : McLoginData
	{
		public string UserName;

		public string Password;

		public string BaseUrl;

		public string Description;

		public bool ForceReselectProfile;

		public bool IsExist;

		public McLoginServer(McLoginType Type)
		{
			ForceReselectProfile = false;
			IsExist = false;
			base.Type = Type;
		}

		public virtual int GetHashCode()
		{
			return Convert.ToInt32(decimal.Remainder(new decimal(ModBase.GetHash(UserName + Password + BaseUrl + Conversions.ToString((int)Type))), 2147483647m));
		}
	}

	public class McLoginMs : McLoginData
	{
		public string OAuthRefreshToken;

		public string AccessToken;

		public string Uuid;

		public string UserName;

		public string ProfileJson;

		public McLoginMs()
		{
			OAuthRefreshToken = "";
			AccessToken = "";
			Uuid = "";
			UserName = "";
			ProfileJson = "";
			Type = McLoginType.Ms;
		}

		public virtual int GetHashCode()
		{
			return Convert.ToInt32(decimal.Remainder(new decimal(ModBase.GetHash(string.Concat(new string[] { OAuthRefreshToken, AccessToken, Uuid, UserName, ProfileJson }))), 2147483647m));
		}
	}

	public class McLoginLegacy : McLoginData
	{
		public string UserName;

		public int SkinType;

		public string SkinName;

		public string Uuid;

		public McLoginLegacy()
		{
			Type = McLoginType.Legacy;
		}

		public virtual int GetHashCode()
		{
			return Convert.ToInt32(decimal.Remainder(new decimal(ModBase.GetHash(UserName + Conversions.ToString(SkinType) + SkinName + Conversions.ToString((int)Type))), 2147483647m));
		}
	}

	public struct McLoginResult
	{
		public string Name;

		public string Uuid;

		public string AccessToken;

		public string Type;

		public string ClientToken;

		public string ProfileJson;
	}

	private class XBLTokenRequestData
	{
		public class PropertiesData
		{
			[field: CompilerGenerated]
			public string AuthMethod
			{
				[CompilerGenerated]
				get;
				[CompilerGenerated]
				set;
			}

			[field: CompilerGenerated]
			public string SiteName
			{
				[CompilerGenerated]
				get;
				[CompilerGenerated]
				set;
			}

			[field: CompilerGenerated]
			public string RpsTicket
			{
				[CompilerGenerated]
				get;
				[CompilerGenerated]
				set;
			}
		}

		[field: CompilerGenerated]
		public PropertiesData Properties
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string RelyingParty
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string TokenType
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}
	}

	private class XSTSTokenRequestData
	{
		public class PropertiesData
		{
			[field: CompilerGenerated]
			public string SandboxId
			{
				[CompilerGenerated]
				get;
				[CompilerGenerated]
				set;
			}

			[field: CompilerGenerated]
			public List<string> UserTokens
			{
				[CompilerGenerated]
				get;
				[CompilerGenerated]
				set;
			}
		}

		[field: CompilerGenerated]
		public PropertiesData Properties
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string RelyingParty
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string TokenType
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}
	}

	public class LaunchArgument
	{
		private List<string> _features;

		public LaunchArgument(ModMinecraft.McInstance Minecraft)
		{
			_features = new List<string>();
			_ = string.Empty;
			if (Minecraft.IsOldJson)
			{
				_features = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)Minecraft.JsonObject["minecraftArguments"].ToString().Split(' ', (StringSplitOptions)0));
				return;
			}
			System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator = ((System.Collections.Generic.IEnumerable<JToken>)Minecraft.JsonObject["arguments"]["game"]).GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					JToken current = enumerator.Current;
					if (current.Type == JTokenType.String)
					{
						_features.Add(current.ToString());
					}
					else if (current.Type == JTokenType.Object)
					{
						_features.AddRange(Enumerable.Select<JToken, string>((System.Collections.Generic.IEnumerable<JToken>)current["value"], (Func<JToken, string>)([SpecialName] (JToken x) => x.ToString())));
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
		}

		public object HasArguments(string key)
		{
			return _features.Contains(key);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<FormMain.PageStackData, bool> _0024I4_002D0;

		public static Action<ModLoader.LoaderTask<int, int>> _0024IR12_002D2;

		public static Action<ModLoader.LoaderTask<int, int>> _0024IR12_002D3;

		public static Action _0024I14_002D1;

		public static Action _0024I14_002D2;

		public static Action _0024I23_002D0;

		public static Action _0024I29_002D0;

		public static Func<JToken, bool> _0024I36_002D0;

		public static Action _0024I37_002D0;

		public static Func<string, string> _0024I59_002D1;

		public static Action _0024I65_002D0;

		public static Action _0024I65_002D1;

		public static Action _0024I66_002D0;

		public static Action _0024I66_002D1;

		public static Action _0024I66_002D2;

		public static Action _0024I66_002D3;

		public static Action _0024I66_002D4;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__R0_002D1(ModLoader.LoaderBase a0)
		{
			McLaunchState((ModLoader.LoaderTask<McLaunchOptions, object>)a0);
		}

		[SpecialName]
		internal bool _Lambda_0024__4_002D0(FormMain.PageStackData p)
		{
			return p.Page != FormMain.PageType.InstanceSelect;
		}

		[SpecialName]
		internal void _Lambda_0024__R12_002D2(ModLoader.LoaderTask<int, int> a0)
		{
			McLaunchPrerun();
		}

		[SpecialName]
		internal void _Lambda_0024__R12_002D3(ModLoader.LoaderTask<int, int> a0)
		{
			McLaunchEnd();
		}

		[SpecialName]
		internal void _Lambda_0024__14_002D1()
		{
			object obj = ModBase.Setup.Get("SystemLaunchCount");
			if (Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)3, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)8, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)15, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)30, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)50, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)70, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)90, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)110, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)130, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)180, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)220, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)280, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)330, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)380, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)450, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)550, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)660, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)750, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)880, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)950, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)1100, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)1300, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)1500, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)1700, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)1900, false)))) && ModMain.MyMsgBox(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"你已经启动了 ", ModBase.Setup.Get("SystemLaunchCount")), (object)" 次 Minecraft 啦！"), (object)"\r\n"), (object)"如果觉得 Minecraft 还不错，可以购买正版支持一下，毕竟开发游戏也真的很不容易……不要一直白嫖啦。"), (object)"\r\n"), (object)"\r\n"), (object)"在登录一次正版账号后，就不会再出现这个提示了！")), "考虑一下正版？", "支持正版游戏！", "下次一定") == 1)
			{
				ModBase.OpenWebsite("https://www.xbox.com/zh-cn/games/store/minecraft-java-bedrock-edition-for-pc/9nxp44l49shj");
			}
		}

		[SpecialName]
		internal void _Lambda_0024__14_002D2()
		{
			ModBase.OpenWebsite("https://www.xbox.com/zh-cn/games/store/minecraft-java-bedrock-edition-for-pc/9nxp44l49shj");
		}

		[SpecialName]
		internal void _Lambda_0024__23_002D0()
		{
			ModMain.FrmLaunchLeft.RefreshPage(Anim: false);
		}

		[SpecialName]
		internal void _Lambda_0024__29_002D0()
		{
			ModBase.OpenWebsite("https://account.live.com/password/Change");
		}

		[SpecialName]
		internal bool _Lambda_0024__36_002D0(JToken x)
		{
			if (Operators.CompareString(x["name"]?.ToString(), "product_minecraft", false) != 0)
			{
				return Operators.CompareString(x["name"]?.ToString(), "game_minecraft", false) == 0;
			}
			return true;
		}

		[SpecialName]
		internal void _Lambda_0024__37_002D0()
		{
			int num = ModMain.MyMsgBox("请先创建 Minecraft 玩家档案，然后再重新登录。", "登录失败", "创建档案", "取消");
			if (num == 1)
			{
				ModBase.OpenWebsite("https://www.minecraft.net/zh-hans/msaprofile/mygames/editprofile");
			}
		}

		[SpecialName]
		internal string _Lambda_0024__59_002D1(string c)
		{
			return ModBase.ShortenPath(c);
		}

		[SpecialName]
		internal void _Lambda_0024__65_002D0()
		{
			ModMain.FrmLogLeft = new PageLogLeft();
		}

		[SpecialName]
		internal void _Lambda_0024__65_002D1()
		{
			checked
			{
				ModAnimation.AniControlEnabled++;
				ModMain.FrmLogRight = new PageLogRight();
				ModAnimation.AniControlEnabled--;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__66_002D0()
		{
			if (ModMusic.MusicPause())
			{
				ModBase.Log("[Music] 已根据设置，在启动后暂停音乐播放");
			}
		}

		[SpecialName]
		internal void _Lambda_0024__66_002D1()
		{
			if (ModMusic.MusicResume())
			{
				ModBase.Log("[Music] 已根据设置，在启动后开始音乐播放");
			}
		}

		[SpecialName]
		internal void _Lambda_0024__66_002D2()
		{
			ModMain.FrmMain.EndProgram(SendWarning: false);
		}

		[SpecialName]
		internal void _Lambda_0024__66_002D3()
		{
			ModMain.FrmMain.Hidden = true;
		}

		[SpecialName]
		internal void _Lambda_0024__66_002D4()
		{
			((Window)ModMain.FrmMain).WindowState = (WindowState)1;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__13_002D0
	{
		public bool _0024VB_0024Local_Finished;

		public _Closure_0024__13_002D0(_Closure_0024__13_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Finished = arg0._0024VB_0024Local_Finished;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			PageOtherTest.MemoryOptimize(ShowHint: false);
			_0024VB_0024Local_Finished = true;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__41_002D0
	{
		public JObject _0024VB_0024Local_LoginJson;

		public string _0024VB_0024Local_SelectedName;

		public string _0024VB_0024Local_SelectedId;

		public _Closure_0024__41_002D0(_Closure_0024__41_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_LoginJson = arg0._0024VB_0024Local_LoginJson;
				_0024VB_0024Local_SelectedName = arg0._0024VB_0024Local_SelectedName;
				_0024VB_0024Local_SelectedId = arg0._0024VB_0024Local_SelectedId;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			List<IMyRadio> val = new List<IMyRadio>();
			List<JToken> val2 = new List<JToken>();
			System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator = ((System.Collections.Generic.IEnumerable<JToken>)_0024VB_0024Local_LoginJson["availableProfiles"]).GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					JToken current = enumerator.Current;
					val.Add((IMyRadio)new MyRadioBox
					{
						Text = current["name"].ToString()
					});
					val2.Add(current);
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			int value = ModMain.MyMsgBoxSelect(val, "选择使用的角色").Value;
			_0024VB_0024Local_SelectedName = val2[value]["name"].ToString();
			_0024VB_0024Local_SelectedId = val2[value]["id"].ToString();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__59_002D0
	{
		public Size _0024VB_0024Local_Result;

		public _Closure_0024__59_002D0(_Closure_0024__59_002D0 arg0)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			if (arg0 != null)
			{
				_0024VB_0024Local_Result = arg0._0024VB_0024Local_Result;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			_0024VB_0024Local_Result = new Size(ModBase.GetPixelSize(((FrameworkElement)ModMain.FrmMain.PanForm).ActualWidth), ModBase.GetPixelSize(((FrameworkElement)ModMain.FrmMain.PanForm).ActualHeight));
		}
	}

	public static bool IsLaunching = false;

	public static McLaunchOptions CurrentLaunchOptions = null;

	public static ModLoader.LoaderTask<McLaunchOptions, object> McLaunchLoader = new ModLoader.LoaderTask<McLaunchOptions, object>("Loader Launch", McLaunchStart, null, (ThreadPriority)2)
	{
		OnStateChanged = [SpecialName] (ModLoader.LoaderBase a0) =>
		{
			McLaunchState((ModLoader.LoaderTask<McLaunchOptions, object>)a0);
		}
	};

	public static ModLoader.LoaderCombo<object> McLaunchLoaderReal;

	public static Process McLaunchProcess;

	public static ModWatcher.Watcher McLaunchWatcher;

	private static string AbortHint = null;

	public static ModLoader.LoaderTask<McLoginData, McLoginResult> McLoginLoader = new ModLoader.LoaderTask<McLoginData, McLoginResult>("登录", McLoginStart, McLoginInput, (ThreadPriority)1)
	{
		ReloadTimeout = 1,
		ProgressWeight = 15.0,
		Block = false
	};

	public static ModLoader.LoaderTask<McLoginMs, McLoginResult> McLoginMsLoader = new ModLoader.LoaderTask<McLoginMs, McLoginResult>("Loader Login Ms", McLoginMsStart, null, (ThreadPriority)2)
	{
		ReloadTimeout = 1
	};

	public static ModLoader.LoaderTask<McLoginLegacy, McLoginResult> McLoginLegacyLoader = new ModLoader.LoaderTask<McLoginLegacy, McLoginResult>("Loader Login Legacy", McLoginLegacyStart, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<McLoginServer, McLoginResult> McLoginAuthLoader = new ModLoader.LoaderTask<McLoginServer, McLoginResult>("Loader Login Auth", McLoginServerStart, null, (ThreadPriority)2)
	{
		ReloadTimeout = 600000
	};

	private static long McLoginMsRefreshTime = 0L;

	public static JavaInfo McLaunchJavaSelected = null;

	private static string McLaunchArgument;

	private static object ExtractJavaWrapperLock = RuntimeHelpers.GetObjectValue(new object());

	private static object ExtractLinkDLock = RuntimeHelpers.GetObjectValue(new object());

	public static bool McLaunchStart(McLaunchOptions Options = null)
	{
		IsLaunching = true;
		CurrentLaunchOptions = Options ?? new McLaunchOptions();
		if (!ModBase.RunInUi())
		{
			throw new System.Exception("McLaunchStart 必须在 UI 线程调用！");
		}
		if (McLaunchLoader.State == ModBase.LoadState.Loading)
		{
			ModMain.Hint("已有游戏正在启动中！", ModMain.HintType.Critical);
			IsLaunching = false;
			return false;
		}
		if ((object)CurrentLaunchOptions.Version != null && ModMinecraft.McInstanceCurrent != CurrentLaunchOptions.Version)
		{
			McLaunchLog("在启动前切换到实例 " + CurrentLaunchOptions.Version.Name);
			CurrentLaunchOptions.Version.Load();
			if (CurrentLaunchOptions.Version.State == ModMinecraft.McInstanceState.Error)
			{
				ModMain.Hint("无法启动 Minecraft：" + CurrentLaunchOptions.Version.Info, ModMain.HintType.Critical);
				IsLaunching = false;
				return false;
			}
			ModMinecraft.McInstanceCurrent = CurrentLaunchOptions.Version;
			ModBase.Setup.Set("LaunchInstanceSelect", ModMinecraft.McInstanceCurrent.Name);
			ModMain.FrmLaunchLeft.RefreshButtonsUI();
			ModMain.FrmLaunchLeft.RefreshPage(Anim: false);
		}
		ModMain.FrmMain.AprilGiveup();
		ModMain.FrmMain.PageStack = Enumerable.ToList<FormMain.PageStackData>(Enumerable.Where<FormMain.PageStackData>((System.Collections.Generic.IEnumerable<FormMain.PageStackData>)ModMain.FrmMain.PageStack, (Func<FormMain.PageStackData, bool>)([SpecialName] (FormMain.PageStackData p) => p.Page != FormMain.PageType.InstanceSelect)));
		McLaunchLoader.Start(Options, IsForceRestart: true);
		return true;
	}

	public static void McLaunchLog(string Text)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		Text = ModMinecraft.FilterUserName(ModMinecraft.FilterAccessToken(Text, '*'), '*');
		ModBase.RunInUi((Action)([SpecialName] () =>
		{
			TextBlock labLog;
			(labLog = ModMain.FrmLaunchRight.LabLog).Text = string.Concat(new string[5]
			{
				labLog.Text,
				"\r\n[",
				TimeUtils.GetTimeNow(),
				"] ",
				Text
			});
		}));
		ModBase.Log("[Launch] " + Text);
	}

	private static void McLaunchState(ModLoader.LoaderTask<McLaunchOptions, object> Loader)
	{
		switch (McLaunchLoader.State)
		{
		case ModBase.LoadState.Waiting:
		case ModBase.LoadState.Finished:
		case ModBase.LoadState.Failed:
		case ModBase.LoadState.Aborted:
			ModMain.FrmLaunchLeft.PageChangeToLogin();
			break;
		case ModBase.LoadState.Loading:
			ModMain.FrmLaunchRight.LabLog.Text = "";
			break;
		}
	}

	private static void McLaunchStart(ModLoader.LoaderTask<McLaunchOptions, object> Loader)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Expected O, but got Unknown
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Expected O, but got Unknown
		ModBase.RunInUiWait(new Action(ModMain.FrmLaunchLeft.PageChangeToLaunching));
		try
		{
			McLaunchPrecheck();
			McLaunchLog("预检测已通过");
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			if (!ModBase.StartsWithF(ex2.Message, "$$"))
			{
				ModMain.Hint(ex2.Message, ModMain.HintType.Critical);
			}
			throw;
		}
		try
		{
			List<ModLoader.LoaderBase> obj = new List<ModLoader.LoaderBase>();
			obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("获取 Java", McLaunchJava, null, (ThreadPriority)2)
			{
				ProgressWeight = 4.0,
				Block = false
			});
			obj.Add((ModLoader.LoaderBase)McLoginLoader);
			obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("补全文件", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)ModDownload.DlClientFix(ModMinecraft.McInstanceCurrent, CheckAssetsHash: false, ModDownload.AssetsIndexExistsBehaviour.DownloadInBackground))
			{
				ProgressWeight = 15.0,
				Show = false
			});
			obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModMinecraft.McLibToken>>("获取启动参数", McLaunchArgumentMain, null, (ThreadPriority)2)
			{
				ProgressWeight = 2.0
			});
			obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<List<ModMinecraft.McLibToken>, int>("解压文件", McLaunchNatives, null, (ThreadPriority)2)
			{
				ProgressWeight = 2.0
			});
			obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("预启动处理", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
			{
				McLaunchPrerun();
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 1.0
			});
			obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("执行自定义命令", McLaunchCustom, null, (ThreadPriority)2)
			{
				ProgressWeight = 1.0
			});
			obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, Process>("启动进程", McLaunchRun, null, (ThreadPriority)2)
			{
				ProgressWeight = 2.0
			});
			obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<Process, int>("等待游戏窗口出现", McLaunchWait, null, (ThreadPriority)2)
			{
				ProgressWeight = 1.0
			});
			obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("结束处理", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
			{
				McLaunchEnd();
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 1.0
			});
			List<ModLoader.LoaderBase> val = obj;
			object obj2 = ModBase.Setup.Get("VersionRamOptimize", ModMinecraft.McInstanceCurrent);
			if (Operators.ConditionalCompareObjectEqual(obj2, (object)0, false))
			{
				if (Conversions.ToBoolean(ModBase.Setup.Get("LaunchArgumentRam")))
				{
					((ModLoader.LoaderCombo<string>)val[2]).Block = false;
					val.Insert(3, (ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("内存优化", McLaunchMemoryOptimize, null, (ThreadPriority)2)
					{
						ProgressWeight = 30.0
					});
				}
			}
			else if (Operators.ConditionalCompareObjectEqual(obj2, (object)1, false))
			{
				((ModLoader.LoaderCombo<string>)val[2]).Block = false;
				val.Insert(3, (ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("内存优化", McLaunchMemoryOptimize, null, (ThreadPriority)2)
				{
					ProgressWeight = 30.0
				});
			}
			else
			{
				Operators.ConditionalCompareObjectEqual(obj2, (object)2, false);
			}
			ModLoader.LoaderCombo<object> loaderCombo = new ModLoader.LoaderCombo<object>("Minecraft 启动", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val)
			{
				Show = false
			};
			if (McLoginLoader.State == ModBase.LoadState.Finished)
			{
				McLoginLoader.State = ModBase.LoadState.Waiting;
			}
			McLaunchLoaderReal = loaderCombo;
			AbortHint = null;
			loaderCombo.Start();
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			while (loaderCombo.State == ModBase.LoadState.Loading)
			{
				((DispatcherObject)ModMain.FrmLaunchLeft).Dispatcher.Invoke(new Action(ModMain.FrmLaunchLeft.LaunchingRefresh));
				Thread.Sleep(200);
			}
			((DispatcherObject)ModMain.FrmLaunchLeft).Dispatcher.Invoke(new Action(ModMain.FrmLaunchLeft.LaunchingRefresh));
			switch (loaderCombo.State)
			{
			case ModBase.LoadState.Finished:
				ModMain.Hint(ModMinecraft.McInstanceCurrent.Name + " 启动成功！", ModMain.HintType.Finish);
				break;
			case ModBase.LoadState.Aborted:
				if (AbortHint == null)
				{
					ModMain.Hint((CurrentLaunchOptions?.SaveBatch == null) ? "已取消启动！" : "已取消导出启动脚本！");
				}
				else
				{
					ModMain.Hint(AbortHint, ModMain.HintType.Finish);
				}
				break;
			case ModBase.LoadState.Failed:
				throw loaderCombo.Error;
			default:
				throw new System.Exception("错误的状态改变：" + ModBase.GetStringFromEnum(loaderCombo.State));
			}
			IsLaunching = false;
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			System.Exception ex5 = ex4;
			while (true)
			{
				if (ModBase.StartsWithF(ex5.Message, "$"))
				{
					if (Operators.CompareString(ex5.Message, "$$", false) != 0)
					{
						ModMain.MyMsgBox(ex5.Message.TrimStart('$'), (CurrentLaunchOptions?.SaveBatch == null) ? "启动失败" : "导出启动脚本失败");
					}
					throw;
				}
				if (ex5.InnerException == null)
				{
					break;
				}
				ex5 = ex5.InnerException;
			}
			McLaunchLog("错误：" + ex4.ToString());
			ModBase.Log(ex4, (CurrentLaunchOptions?.SaveBatch == null) ? "Minecraft 启动失败" : "导出启动脚本失败", ModBase.LogLevel.Msgbox, (CurrentLaunchOptions?.SaveBatch == null) ? "启动失败" : "导出启动脚本失败");
			throw;
		}
	}

	private static void McLaunchMemoryOptimize(ModLoader.LoaderTask<int, int> Loader)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		_Closure_0024__13_002D0 arg = default(_Closure_0024__13_002D0);
		_Closure_0024__13_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__13_002D0(null);
		McLaunchLog("内存优化开始");
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Finished = false;
		ModBase.RunInNewThread((Action)([SpecialName] () =>
		{
			PageOtherTest.MemoryOptimize(ShowHint: false);
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Finished = true;
		}), "Launch Memory Optimize", (ThreadPriority)2);
		while (!CS_0024_003C_003E8__locals0._0024VB_0024Local_Finished && !Loader.IsAborted)
		{
			if (Loader.Progress < 0.7)
			{
				Loader.Progress += 0.007;
			}
			else
			{
				Loader.Progress += (0.95 - Loader.Progress) * 0.02;
			}
			Thread.Sleep(100);
		}
	}

	private static void McLaunchPrecheck()
	{
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Expected O, but got Unknown
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected O, but got Unknown
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Expected O, but got Unknown
		if (Conversions.ToBoolean(ModBase.Setup.Get("SystemDebugDelay")))
		{
			Thread.Sleep(RandomUtils.NextInt(100, 2000));
		}
		if (ModMinecraft.McInstanceCurrent.PathIndie.Contains("!") || ModMinecraft.McInstanceCurrent.PathIndie.Contains(";"))
		{
			throw new System.Exception("游戏路径中不可包含 ! 或 ;（" + ModMinecraft.McInstanceCurrent.PathIndie + "）");
		}
		if (ModMinecraft.McInstanceCurrent.Path.Contains("!") || ModMinecraft.McInstanceCurrent.Path.Contains(";"))
		{
			throw new System.Exception("游戏路径中不可包含 ! 或 ;（" + ModMinecraft.McInstanceCurrent.Path + "）");
		}
		if (Conversions.ToBoolean((object)(ModBase.IsUtf8CodePage() && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("HintDisableGamePathCheckTip"))) && !ModBase.IsASCII(ModMinecraft.McInstanceCurrent.Path))))
		{
			switch (ModMain.MyMsgBox(string.Format("欲启动实例 \"{0}\" 的路径中存在可能影响游戏正常运行的字符（非 ASCII 字符），是否仍旧启动游戏？{1}{2}如果不清楚具体作用，你可以先选择 \"继续\"，发现游戏在启动后很快出现崩溃的情况后再尝试修改游戏路径等操作", (object)ModMinecraft.McInstanceCurrent.Name, (object)"\r\n", (object)"\r\n"), "游戏路径检查", "继续", "返回处理", "不再提示"))
			{
			case 2:
				throw new System.Exception("$$");
			case 3:
				ModBase.Setup.Set("HintDisableGamePathCheckTip", true);
				break;
			}
		}
		if ((object)ModMinecraft.McInstanceCurrent == null)
		{
			throw new System.Exception("未选择 Minecraft 实例！");
		}
		ModMinecraft.McInstanceCurrent.Load();
		if (ModMinecraft.McInstanceCurrent.State == ModMinecraft.McInstanceState.Error)
		{
			throw new System.Exception("Minecraft 存在问题：" + ModMinecraft.McInstanceCurrent.Info);
		}
		string text = "";
		ModBase.RunInUiWait((Action)([SpecialName] () =>
		{
			text = Conversions.ToString(ModProfile.IsProfileValid());
		}));
		if (ModProfile.SelectedProfile == null)
		{
			text = "请先选择一个档案再启动游戏！";
		}
		else if (ModMinecraft.McInstanceCurrent.Version.HasLabyMod || Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("VersionServerLoginRequire", ModMinecraft.McInstanceCurrent), (object)1, false))
		{
			if (ModProfile.SelectedProfile.Type != McLoginType.Ms)
			{
				text = "当前实例要求使用正版验证，请使用正版验证档案启动游戏！";
			}
		}
		else if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("VersionServerLoginRequire", ModMinecraft.McInstanceCurrent), (object)2, false))
		{
			if (ModProfile.SelectedProfile.Type != McLoginType.Auth)
			{
				text = "当前实例要求使用第三方验证，请使用第三方验证档案启动游戏！";
			}
			else if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual((object)ModBase.BeforeLast(ModProfile.SelectedProfile.Server, "/authserver"), ModBase.Setup.Get("VersionServerAuthServer", ModMinecraft.McInstanceCurrent), false))))
			{
				text = "当前档案使用的第三方验证服务器与实例要求使用的不一致，请使用符合要求的档案启动游戏！";
			}
		}
		else if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("VersionServerLoginRequire", ModMinecraft.McInstanceCurrent), (object)3, false))
		{
			if (ModProfile.SelectedProfile.Type == McLoginType.Legacy)
			{
				text = "当前实例要求使用正版验证或第三方验证，请使用符合要求的档案启动游戏！";
			}
			else if (Conversions.ToBoolean((object)(ModProfile.SelectedProfile.Type == McLoginType.Auth && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual((object)ModBase.BeforeLast(ModProfile.SelectedProfile.Server, "/authserver"), ModBase.Setup.Get("VersionServerAuthServer", ModMinecraft.McInstanceCurrent), false))))))
			{
				text = "当前档案使用的第三方验证服务器与实例要求使用的不一致，请使用符合要求的档案启动游戏！";
			}
		}
		if (Operators.CompareString(text, "", false) != 0)
		{
			throw new ArgumentException(text);
		}
		if (!Conversions.ToBoolean((object)(CurrentLaunchOptions?.SaveBatch == null && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("HintBuy"))) && ModProfile.SelectedProfile.Type != McLoginType.Ms)))
		{
			return;
		}
		if (ModBase.IsRestrictedFeatAllowed)
		{
			object action;
			if (_Closure_0024__._0024I14_002D1 != null)
			{
				action = _Closure_0024__._0024I14_002D1;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					object obj = ModBase.Setup.Get("SystemLaunchCount");
					if (Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)3, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)8, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)15, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)30, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)50, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)70, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)90, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)110, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)130, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)180, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)220, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)280, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)330, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)380, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)450, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)550, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)660, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)750, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)880, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)950, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)1100, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)1300, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)1500, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)1700, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)1900, false)))) && ModMain.MyMsgBox(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"你已经启动了 ", ModBase.Setup.Get("SystemLaunchCount")), (object)" 次 Minecraft 啦！"), (object)"\r\n"), (object)"如果觉得 Minecraft 还不错，可以购买正版支持一下，毕竟开发游戏也真的很不容易……不要一直白嫖啦。"), (object)"\r\n"), (object)"\r\n"), (object)"在登录一次正版账号后，就不会再出现这个提示了！")), "考虑一下正版？", "支持正版游戏！", "下次一定") == 1)
					{
						ModBase.OpenWebsite("https://www.xbox.com/zh-cn/games/store/minecraft-java-bedrock-edition-for-pc/9nxp44l49shj");
					}
				};
				_Closure_0024__._0024I14_002D1 = val;
				action = (object)val;
			}
			ModBase.RunInNewThread((Action)action, "Buy Minecraft", (ThreadPriority)2);
			return;
		}
		object button1Action;
		if (_Closure_0024__._0024I14_002D2 != null)
		{
			button1Action = _Closure_0024__._0024I14_002D2;
		}
		else
		{
			Action val2 = [SpecialName] () =>
			{
				ModBase.OpenWebsite("https://www.xbox.com/zh-cn/games/store/minecraft-java-bedrock-edition-for-pc/9nxp44l49shj");
			};
			_Closure_0024__._0024I14_002D2 = val2;
			button1Action = (object)val2;
		}
		switch (ModMain.MyMsgBox("你必须先登录正版账号才能启动游戏！", "正版验证", "购买正版", "试玩", "返回", IsWarn: false, HighLight: true, ForceWait: false, (Action)button1Action))
		{
		case 2:
			ModMain.Hint("游戏将以试玩模式启动！", ModMain.HintType.Critical);
			CurrentLaunchOptions.ExtraArgs.Add("--demo");
			break;
		case 3:
			throw new System.Exception("$$");
		}
	}

	public static McLoginData McLoginInput()
	{
		McLoginData result = null;
		try
		{
			result = ModProfile.GetLoginData();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "获取登录输入信息失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static void McLoginStart(ModLoader.LoaderTask<McLoginData, McLoginResult> Data)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		ModBase.Log("[Profile] 开始加载选定档案");
		string text = Conversions.ToString(ModProfile.IsProfileValid());
		if (Operators.CompareString(text, "", false) != 0)
		{
			throw new ArgumentException(text);
		}
		ModLoader.LoaderBase loaderBase = null;
		switch (Data.Input.Type)
		{
		case McLoginType.Ms:
			loaderBase = McLoginMsLoader;
			break;
		case McLoginType.Legacy:
			loaderBase = McLoginLegacyLoader;
			break;
		case McLoginType.Auth:
			loaderBase = McLoginAuthLoader;
			break;
		}
		loaderBase.WaitForExit(Data.Input, McLoginLoader, Data.IsForceRestarting);
		object obj = NewLateBinding.LateGet((object)loaderBase, (System.Type)null, "Output", new object[0], (string[])null, (System.Type[])null, (bool[])null);
		Data.Output = ((obj != null) ? ((McLoginResult)obj) : default(McLoginResult));
		object action;
		if (_Closure_0024__._0024I23_002D0 != null)
		{
			action = _Closure_0024__._0024I23_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				ModMain.FrmLaunchLeft.RefreshPage(Anim: false);
			};
			_Closure_0024__._0024I23_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
		ModBase.Log("[Profile] 选定档案加载完成");
	}

	private static void McLoginMsStart(ModLoader.LoaderTask<McLoginMs, McLoginResult> Data)
	{
		bool flag2 = false;
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		McLoginMs input = Data.Input;
		string userName = input.UserName;
		bool flag = true;
		ModProfile.ProfileLog("验证方式：正版（" + (string.IsNullOrEmpty(userName) ? "尚未登录" : userName) + "）");
		Data.Progress = 0.05;
		if (!Data.IsForceRestarting && !string.IsNullOrEmpty(input.AccessToken) && McLoginMsRefreshTime > 0 && checked(TimeUtils.GetTimeTick() - McLoginMsRefreshTime) < 600000)
		{
			Data.Output = new McLoginResult
			{
				AccessToken = input.AccessToken,
				Name = input.UserName,
				Uuid = input.Uuid,
				Type = "Microsoft",
				ClientToken = input.Uuid,
				ProfileJson = input.ProfileJson
			};
			goto IL_0435;
		}
		string[] array;
		if (!string.IsNullOrEmpty(input.OAuthRefreshToken))
		{
			array = MsLoginStep1Refresh(input.OAuthRefreshToken);
			if (Operators.CompareString(array[0], "Relogin", false) != 0)
			{
				goto IL_0111;
			}
		}
		array = MsLoginStep1New(Data);
		goto IL_0111;
		IL_0111:
		if (Operators.CompareString(array[0], "Ignore", false) != 0)
		{
			string accessToken = array[0];
			string refreshToken = array[1];
			if (Data.IsAborted)
			{
				throw new ThreadInterruptedException();
			}
			Data.Progress = 0.25;
			if (Data.IsAborted)
			{
				throw new ThreadInterruptedException();
			}
			string text = MsLoginStep2(accessToken);
			if (Operators.CompareString(text, "Ignore", false) != 0)
			{
				Data.Progress = 0.4;
				if (Data.IsAborted)
				{
					throw new ThreadInterruptedException();
				}
				string[] array2 = MsLoginStep3(text);
				if (Operators.CompareString(array2[1], "Ignore", false) != 0)
				{
					Data.Progress = 0.55;
					if (Data.IsAborted)
					{
						throw new ThreadInterruptedException();
					}
					string text2 = MsLoginStep4(array2);
					if (Operators.CompareString(text2, "Ignore", false) != 0)
					{
						Data.Progress = 0.7;
						if (Data.IsAborted)
						{
							throw new ThreadInterruptedException();
						}
						MsLoginStep5(text2);
						Data.Progress = 0.85;
						if (Data.IsAborted)
						{
							throw new ThreadInterruptedException();
						}
						string[] array3 = MsLoginStep6(text2);
						if (Operators.CompareString(array3[2], "Ignore", false) != 0)
						{
							Data.Progress = 0.98;
							System.Collections.Generic.IEnumerator<ModProfile.McProfile> enumerator = default(System.Collections.Generic.IEnumerator<ModProfile.McProfile>);
							try
							{
								enumerator = ModProfile.ProfileList.GetEnumerator();
								while (enumerator.MoveNext())
								{
									ModProfile.McProfile current = enumerator.Current;
									if (current.Type != McLoginType.Ms || Operators.CompareString(current.Username, array3[1], false) != 0 || Operators.CompareString(current.Uuid, array3[0], false) != 0)
									{
										continue;
									}
									flag = false;
									if (!ModProfile.IsCreatingProfile)
									{
										continue;
									}
									int num = ModProfile.ProfileList.IndexOf(current);
									ModProfile.ProfileList[num].Username = array3[1];
									ModProfile.ProfileList[num].AccessToken = text2;
									ModProfile.ProfileList[num].RefreshToken = refreshToken;
									ModMain.Hint("你已经添加了这个档案...");
									goto IL_0435;
								}
							}
							finally
							{
								((System.IDisposable)enumerator).Dispose();
							}
							if (flag)
							{
								ModProfile.McProfile mcProfile = new ModProfile.McProfile
								{
									Type = McLoginType.Ms,
									Uuid = array3[0],
									Username = array3[1],
									AccessToken = text2,
									RefreshToken = refreshToken,
									Expires = 1743779140286L,
									Desc = "",
									RawJson = array3[2]
								};
								ModProfile.ProfileList.Add(mcProfile);
								ModProfile.SelectedProfile = mcProfile;
								ModProfile.IsCreatingProfile = false;
							}
							else
							{
								int num2 = ModProfile.ProfileList.IndexOf(ModProfile.SelectedProfile);
								ModProfile.ProfileList[num2].Username = array3[1];
								ModProfile.ProfileList[num2].AccessToken = text2;
								ModProfile.ProfileList[num2].RefreshToken = refreshToken;
							}
							ModProfile.SaveProfile();
							Data.Output = new McLoginResult
							{
								AccessToken = text2,
								Name = array3[1],
								Uuid = array3[0],
								Type = "Microsoft",
								ClientToken = array3[0],
								ProfileJson = array3[2]
							};
						}
					}
				}
			}
		}
		goto IL_0435;
		IL_0435:
		McLoginMsRefreshTime = TimeUtils.GetTimeTick();
		ModProfile.ProfileLog("正版验证完成");
		ModBase.Setup.Set("HintBuy", true);
		if (flag2)
		{
			Data.Progress = 0.99;
			Data.Output = new McLoginResult
			{
				AccessToken = ModProfile.SelectedProfile.AccessToken,
				Name = ModProfile.SelectedProfile.Username,
				Uuid = ModProfile.SelectedProfile.Uuid,
				Type = "Microsoft"
			};
		}
	}

	private static string[] MsLoginStep1New(ModLoader.LoaderTask<McLoginMs, McLoginResult> Data)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		ModMain.MyMsgBoxConverter myMsgBoxConverter;
		while (true)
		{
			McLaunchLog("开始正版验证 Step 1/6（原始登录）");
			JObject jObject;
			using (HttpResponseHandler httpResponseHandler = HttpRequestBuilder.Create("https://login.microsoftonline.com/consumers/oauth2/v2.0/devicecode", HttpMethod.Post).WithContent((HttpContent)new ByteArrayContent(Encoding.UTF8.GetBytes($"client_id={ModSecret.EffectiveOAuthClientId}&tenant=/consumers&scope=XboxLive.signin%20offline_access")), "application/x-www-form-urlencoded").SendAsync(throwIfNotSuccess: true)
				.Result)
			{
				jObject = (JObject)ModBase.GetJson(httpResponseHandler.AsStringContent());
			}
			McLaunchLog("网页登录地址：" + jObject["verification_uri"].ToString());
			myMsgBoxConverter = new ModMain.MyMsgBoxConverter
			{
				Content = jObject,
				ForceWait = true,
				Type = ModMain.MyMsgBoxType.Login
			};
			ModMain.WaitingMyMsgBox.Add(myMsgBoxConverter);
			while (myMsgBoxConverter.Result == null)
			{
				Thread.Sleep(100);
			}
			if (!(myMsgBoxConverter.Result is ModBase.RestartException))
			{
				break;
			}
			string caption = string.Format("请在登录时选择 {0}其他登录方法{1}，然后选择 {2}使用我的密码{3}。{4}如果没有该选项，请选择 {5}设置密码{6}，设置完毕后再登录。", new object[7]
			{
				ModBase.vbLQ,
				ModBase.vbRQ,
				ModBase.vbLQ,
				ModBase.vbRQ,
				"\r\n",
				ModBase.vbLQ,
				ModBase.vbRQ
			});
			object button2Action;
			if (_Closure_0024__._0024I29_002D0 != null)
			{
				button2Action = _Closure_0024__._0024I29_002D0;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					ModBase.OpenWebsite("https://account.live.com/password/Change");
				};
				_Closure_0024__._0024I29_002D0 = val;
				button2Action = (object)val;
			}
			if (ModMain.MyMsgBox(caption, "需要使用密码登录", "重新登录", "设置密码", "取消", IsWarn: false, HighLight: true, ForceWait: false, null, (Action)button2Action) != 1)
			{
				throw new System.Exception("$$");
			}
		}
		if (myMsgBoxConverter.Result is System.Exception)
		{
			throw (System.Exception)myMsgBoxConverter.Result;
		}
		return (string[])myMsgBoxConverter.Result;
	}

	private static string[] MsLoginStep1Refresh(string Code)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00a5: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		McLaunchLog("开始正版验证 Step 1/6（刷新登录）");
		if (string.IsNullOrEmpty(Code))
		{
			throw new ArgumentException("传入的 Code 为空", "Code");
		}
		string data = default(string);
		string[] result;
		try
		{
			string msUrl = ModSecret.GetMsUrl("https://login.live.com/oauth20_token.srf");
			string content = (ModSecret.UseMsProxy ? $"refresh_token={Uri.EscapeDataString(Code)}&grant_type=refresh_token&scope=XboxLive.signin%20offline_access" : $"client_id={ModSecret.EffectiveOAuthClientId}&refresh_token={Uri.EscapeDataString(Code)}&grant_type=refresh_token&scope=XboxLive.signin%20offline_access");
			using HttpResponseHandler httpResponseHandler = HttpRequestBuilder.Create(msUrl, HttpMethod.Post).WithContent(content, "application/x-www-form-urlencoded").SendAsync(throwIfNotSuccess: true)
				.Result;
			data = httpResponseHandler.AsStringContent();
		}
		catch (ThreadInterruptedException val)
		{
			ProjectData.SetProjectError((System.Exception)val);
			ThreadInterruptedException ex = val;
			ModBase.Log((System.Exception)(object)ex, "加载线程已终止");
			ProjectData.ClearProjectError();
		}
		catch (System.Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			System.Exception ex3 = ex2;
			if (ModBase.ContainsF(ex3.Message, "must sign in again", IgnoreCase: true) || ModBase.ContainsF(ex3.Message, "password expired", IgnoreCase: true) || (ex3.Message.Contains("refresh_token") && ex3.Message.Contains("is not valid")))
			{
				result = new string[] { "Relogin", "" };
				ProjectData.ClearProjectError();
				goto IL_01d3;
			}
			ModProfile.ProfileLog("正版验证 Step 1/6 获取 OAuth Token 失败：" + ex3.ToString());
			bool flag = false;
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				if (IsLaunching && ModMain.MyMsgBox(string.Format("启动器在尝试刷新账号信息时遇到了网络错误。{0}你可以选择取消，检查网络后再次启动，也可以选择忽略错误继续启动，但可能无法游玩部分服务器。", (object)"\r\n"), "账号信息获取失败", "继续", "取消") == 1)
				{
					flag = true;
				}
			}));
			if (flag)
			{
				result = new string[] { "Ignore", "" };
				ProjectData.ClearProjectError();
				goto IL_01d3;
			}
			ProjectData.ClearProjectError();
		}
		JObject obj = (JObject)ModBase.GetJson(data);
		string text = obj["access_token"].ToString();
		string text2 = obj["refresh_token"].ToString();
		result = new string[] { text, text2 };
		goto IL_01d3;
		IL_01d3:
		return result;
	}

	private static string MsLoginStep2(string accessToken)
	{
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		ModProfile.ProfileLog("开始正版验证 Step 2/6: 获取 XBLToken");
		if (string.IsNullOrEmpty(accessToken))
		{
			throw new ArgumentException("传入的 AccessToken 为空", "accessToken");
		}
		XBLTokenRequestData xBLTokenRequestData = new XBLTokenRequestData
		{
			Properties = new XBLTokenRequestData.PropertiesData
			{
				AuthMethod = "RPS",
				SiteName = "user.auth.xboxlive.com",
				RpsTicket = $"d={accessToken}"
			},
			RelyingParty = "http://auth.xboxlive.com",
			TokenType = "JWT"
		};
		string data = default(string);
		string result;
		try
		{
			string content = JsonSerializer.Serialize<XBLTokenRequestData>(xBLTokenRequestData, (JsonSerializerOptions)null);
			using HttpResponseHandler httpResponseHandler = HttpRequestBuilder.Create("https://user.auth.xboxlive.com/user/authenticate", HttpMethod.Post).WithContent(content, "application/json").SendAsync(throwIfNotSuccess: true)
				.Result;
			data = httpResponseHandler.AsStringContent();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModProfile.ProfileLog("正版验证 Step 2/6 获取 XBLToken 失败：" + ex2.ToString());
			bool flag = false;
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				if (IsLaunching && ModMain.MyMsgBox(string.Format("启动器在尝试刷新账号信息时(Step 2)遇到了网络错误。{0}你可以选择取消，检查网络后再次启动，也可以选择忽略错误继续启动，但可能无法游玩部分服务器。", (object)"\r\n"), "账号信息获取失败", "继续", "取消") == 1)
				{
					flag = true;
				}
			}));
			if (flag)
			{
				result = "Ignore";
				ProjectData.ClearProjectError();
				goto IL_012c;
			}
			ProjectData.ClearProjectError();
		}
		result = ((JObject)ModBase.GetJson(data))["Token"].ToString();
		goto IL_012c;
		IL_012c:
		return result;
	}

	private static string[] MsLoginStep3(string XBLToken)
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00cd: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		ModProfile.ProfileLog("开始正版验证 Step 3/6: 获取 XSTSToken");
		if (string.IsNullOrEmpty(XBLToken))
		{
			throw new ArgumentException("XBLToken 为空，无法获取数据", "XBLToken");
		}
		XSTSTokenRequestData xSTSTokenRequestData = new XSTSTokenRequestData();
		xSTSTokenRequestData.Properties = new XSTSTokenRequestData.PropertiesData
		{
			SandboxId = "RETAIL",
			UserTokens = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)new string[] { XBLToken })
		};
		xSTSTokenRequestData.RelyingParty = "rp://api.minecraftservices.com/";
		xSTSTokenRequestData.TokenType = "JWT";
		XSTSTokenRequestData xSTSTokenRequestData2 = xSTSTokenRequestData;
		string data;
		string[] result;
		try
		{
			string content = JsonSerializer.Serialize<XSTSTokenRequestData>(xSTSTokenRequestData2, (JsonSerializerOptions)null);
			using HttpResponseHandler httpResponseHandler = HttpRequestBuilder.Create("https://xsts.auth.xboxlive.com/xsts/authorize", HttpMethod.Post).WithContent(content, "application/json").SendAsync(throwIfNotSuccess: true)
				.Result;
			data = httpResponseHandler.AsStringContent();
		}
		catch (HttpRequestException val)
		{
			ProjectData.SetProjectError((System.Exception)val);
			HttpRequestException val2 = val;
			if (((System.Exception)(object)val2).Message.Contains("2148916227"))
			{
				ModMain.MyMsgBox("该账号似乎已被微软封禁，无法登录。", "登录失败", "我知道了", "", "", IsWarn: true);
				throw new System.Exception("$$");
			}
			if (((System.Exception)(object)val2).Message.Contains("2148916233"))
			{
				if (ModMain.MyMsgBox("你尚未注册 Xbox 账户，请在注册后再登录。", "登录提示", "注册", "取消") == 1)
				{
					ModBase.OpenWebsite("https://signup.live.com/signup");
				}
				throw new System.Exception("$$");
			}
			if (((System.Exception)(object)val2).Message.Contains("2148916235"))
			{
				ModMain.MyMsgBox(string.Format("你的网络所在的国家或地区无法登录微软账号。{0}请使用加速器或 VPN。", (object)"\r\n"), "登录失败", "我知道了");
				throw new System.Exception("$$");
			}
			if (((System.Exception)(object)val2).Message.Contains("2148916238"))
			{
				if (ModMain.MyMsgBox("该账号年龄不足，你需要先修改出生日期，然后才能登录。\r\n该账号目前填写的年龄是否在 13 岁以上？", "登录提示", "13 岁以上", "12 岁以下", "我不知道") == 1)
				{
					ModBase.OpenWebsite("https://account.live.com/editprof.aspx");
					ModMain.MyMsgBox("请在打开的网页中修改账号的出生日期（至少改为 18 岁以上）。\r\n在修改成功后等待一分钟，然后再回到 PCL，就可以正常登录了！", "登录提示");
				}
				else
				{
					ModBase.OpenWebsite("https://support.microsoft.com/zh-cn/account-billing/如何更改-microsoft-帐户上的出生日期-837badbc-999e-54d2-2617-d19206b9540a");
					ModMain.MyMsgBox("请根据打开的网页的说明，修改账号的出生日期（至少改为 18 岁以上）。\r\n在修改成功后等待一分钟，然后再回到 PCL，就可以正常登录了！", "登录提示");
				}
				throw new System.Exception("$$");
			}
			ModProfile.ProfileLog("正版验证 Step 3/6 获取 XSTSToken 失败：" + ((System.Exception)(object)val2).ToString());
			bool flag = false;
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				if (IsLaunching && ModMain.MyMsgBox(string.Format("启动器在尝试刷新账号信息时(Step 3)遇到了网络错误。{0}你可以选择取消，检查网络后再次启动，也可以选择忽略错误继续启动，但可能无法游玩部分服务器。", (object)"\r\n"), "账号信息获取失败", "继续", "取消") == 1)
				{
					flag = true;
				}
			}));
			if (flag)
			{
				result = new string[2]
				{
					ModProfile.SelectedProfile.AccessToken,
					"Ignore"
				};
				ProjectData.ClearProjectError();
				goto IL_0310;
			}
			throw;
		}
		JObject obj = (JObject)ModBase.GetJson(data);
		string text = obj["Token"].ToString();
		string text2 = obj["DisplayClaims"]["xui"][0]["uhs"].ToString();
		result = new string[] { text, text2 };
		goto IL_0310;
		IL_0310:
		return result;
	}

	private static string MsLoginStep4(string[] Tokens)
	{
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00b2: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected I4, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		ModProfile.ProfileLog("开始正版验证 Step 4/6: 获取 Minecraft AccessToken");
		if (Tokens.Length < 2 || string.IsNullOrEmpty(Enumerable.ElementAt<string>((System.Collections.Generic.IEnumerable<string>)Tokens, 0)) || string.IsNullOrEmpty(Enumerable.ElementAt<string>((System.Collections.Generic.IEnumerable<string>)Tokens, 1)))
		{
			throw new ArgumentException("传入的 XSTSToken 或者 UHS 错误", "Tokens");
		}
		Dictionary<string, string> obj = new Dictionary<string, string>();
		obj.Add("identityToken", $"XBL3.0 x={Tokens[1]};{Tokens[0]}");
		Dictionary<string, string> val = obj;
		string data;
		string result;
		try
		{
			string content = JsonSerializer.Serialize<Dictionary<string, string>>(val, (JsonSerializerOptions)null);
			using HttpResponseHandler httpResponseHandler = HttpRequestBuilder.Create("https://api.minecraftservices.com/authentication/login_with_xbox", HttpMethod.Post).WithContent(content, "application/json").SendAsync(throwIfNotSuccess: true)
				.Result;
			data = httpResponseHandler.AsStringContent();
		}
		catch (HttpRequestException val2)
		{
			ProjectData.SetProjectError((System.Exception)val2);
			HttpRequestException val3 = val2;
			_ = ((System.Exception)(object)val3).Message;
			if (((object)val3.StatusCode).Equals((object)(HttpStatusCode)429))
			{
				ModBase.Log((System.Exception)(object)val3, "正版验证 Step 4 汇报 429");
				throw new System.Exception("$登录尝试太过频繁，请等待几分钟后再试！");
			}
			int? num = (int?)val3.StatusCode;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 403) : null).GetValueOrDefault())
			{
				ModBase.Log((System.Exception)(object)val3, "正版验证 Step 4 汇报 403");
				throw new System.Exception("$当前 IP 的登录尝试异常。\r\n如果你使用了 VPN 或加速器，请把它们关掉或更换节点后再试！");
			}
			ModProfile.ProfileLog("正版验证 Step 4/6 获取 MC AccessToken 失败：" + ((System.Exception)(object)val3).ToString());
			bool flag = false;
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				if (IsLaunching && ModMain.MyMsgBox(string.Format("启动器在尝试刷新账号信息时(Step 4)遇到了网络错误。{0}你可以选择取消，检查网络后再次启动，也可以选择忽略错误继续启动，但可能无法游玩部分服务器。", (object)"\r\n"), "账号信息获取失败", "继续", "取消") == 1)
				{
					flag = true;
				}
			}));
			if (flag)
			{
				result = "Ignore";
				ProjectData.ClearProjectError();
				goto IL_01ed;
			}
			throw;
		}
		string text = ((JObject)ModBase.GetJson(data))["access_token"].ToString();
		if (string.IsNullOrWhiteSpace(text))
		{
			throw new System.Exception("获取到的 Minecraft AccessToken 为空，登录流程异常！");
		}
		result = text;
		goto IL_01ed;
		IL_01ed:
		return result;
	}

	private static void MsLoginStep5(string accessToken)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		ModProfile.ProfileLog("开始正版验证 Step 5/6: 验证账户是否持有 MC");
		if (string.IsNullOrEmpty(accessToken))
		{
			throw new ArgumentException("传入的 AccessToken 为空", "accessToken");
		}
		string text = default(string);
		try
		{
			using (HttpResponseHandler httpResponseHandler = HttpRequestBuilder.Create("https://api.minecraftservices.com/entitlements", HttpMethod.Get).WithBearerToken(accessToken).SendAsync(throwIfNotSuccess: true)
				.Result)
			{
				text = httpResponseHandler.AsStringContent();
			}
			JObject jObject = (JObject)ModBase.GetJson(text);
			if (!jObject.ContainsKey("items") || !Enumerable.Any<JToken>((System.Collections.Generic.IEnumerable<JToken>)jObject["items"], (Func<JToken, bool>)([SpecialName] (JToken x) => Operators.CompareString(x["name"]?.ToString(), "product_minecraft", false) == 0 || Operators.CompareString(x["name"]?.ToString(), "game_minecraft", false) == 0)))
			{
				int num = ModMain.MyMsgBox("暂时无法获取到此账户信息，此账户可能没有购买 Minecraft Java Edition 或者账户的 Xbox Game Pass 已过期", "登录失败", "购买 Minecraft", "取消");
				if (num == 1)
				{
					ModBase.OpenWebsite("https://www.xbox.com/zh-cn/games/store/minecraft-java-bedrock-edition-for-pc/9nxp44l49shj");
				}
				throw new System.Exception("$$");
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "正版验证 Step 5 异常：" + text);
			throw;
		}
	}

	private static string[] MsLoginStep6(string AccessToken)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_006b: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected I4, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		ModProfile.ProfileLog("开始正版验证 Step 6/6: 获取玩家 ID 与 UUID 等相关信息");
		if (string.IsNullOrEmpty(AccessToken))
		{
			throw new ArgumentException("传入的 AccessToken 为空", "AccessToken");
		}
		string text;
		string[] result;
		try
		{
			using HttpResponseHandler httpResponseHandler = HttpRequestBuilder.Create("https://api.minecraftservices.com/minecraft/profile", HttpMethod.Get).WithBearerToken(AccessToken).SendAsync(throwIfNotSuccess: true)
				.Result;
			text = httpResponseHandler.AsStringContent();
		}
		catch (HttpRequestException val)
		{
			ProjectData.SetProjectError((System.Exception)val);
			HttpRequestException val2 = val;
			_ = ((System.Exception)(object)val2).Message;
			if (((object)val2.StatusCode).Equals((object)(HttpStatusCode)429))
			{
				ModBase.Log((System.Exception)(object)val2, "正版验证 Step 6 汇报 429");
				throw new System.Exception("$登录尝试太过频繁，请等待几分钟后再试！");
			}
			int? num = (int?)val2.StatusCode;
			if ((num.HasValue ? new bool?(num.GetValueOrDefault() == 404) : null).GetValueOrDefault())
			{
				ModBase.Log((System.Exception)(object)val2, "正版验证 Step 6 汇报 404");
				object action;
				if (_Closure_0024__._0024I37_002D0 != null)
				{
					action = _Closure_0024__._0024I37_002D0;
				}
				else
				{
					Action val3 = [SpecialName] () =>
					{
						int num2 = ModMain.MyMsgBox("请先创建 Minecraft 玩家档案，然后再重新登录。", "登录失败", "创建档案", "取消");
						if (num2 == 1)
						{
							ModBase.OpenWebsite("https://www.minecraft.net/zh-hans/msaprofile/mygames/editprofile");
						}
					};
					_Closure_0024__._0024I37_002D0 = val3;
					action = (object)val3;
				}
				ModBase.RunInNewThread((Action)action, "Login Failed: Create Profile", (ThreadPriority)2);
				throw new System.Exception("$$");
			}
			ModProfile.ProfileLog("正版验证 Step 6/6 获取玩家档案信息失败：" + ((System.Exception)(object)val2).ToString());
			bool flag = false;
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				if (IsLaunching && ModMain.MyMsgBox(string.Format("启动器在尝试刷新账号信息时(Step 6)遇到了网络错误。{0}你可以选择取消，检查网络后再次启动，也可以选择忽略错误继续启动，但可能无法游玩部分服务器。", (object)"\r\n"), "账号信息获取失败", "继续", "取消") == 1)
				{
					flag = true;
				}
			}));
			if (flag)
			{
				result = new string[3]
				{
					ModProfile.SelectedProfile.Uuid,
					ModProfile.SelectedProfile.Username,
					"Ignore"
				};
				ProjectData.ClearProjectError();
				goto IL_020a;
			}
			throw;
		}
		JObject obj = (JObject)ModBase.GetJson(text);
		string text2 = obj["id"].ToString();
		string text3 = obj["name"].ToString();
		result = new string[] { text2, text3, text };
		goto IL_020a;
		IL_020a:
		return result;
	}

	private static void McLoginServerStart(ModLoader.LoaderTask<McLoginServer, McLoginResult> Data)
	{
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		McLoginServer input = Data.Input;
		bool flag = false;
		bool flag2 = false;
		ModProfile.ProfileLog("验证方式：" + input.Description);
		Data.Progress = 0.05;
		if (Data.Input.ForceReselectProfile || ModProfile.IsCreatingProfile)
		{
			goto IL_0180;
		}
		try
		{
			if (Data.IsAborted)
			{
				throw new ThreadInterruptedException();
			}
			McLoginRequestValidate(ref Data);
		}
		catch (ModNet.HttpWebException ex)
		{
			ProjectData.SetProjectError((System.Exception)(object)ex);
			ModNet.HttpWebException ex2 = ex;
			string text = ((System.Exception)(object)ex2).ToString();
			ModProfile.ProfileLog("验证登录失败：" + text);
			if ((text.Contains("超时") || text.Contains("imeout")) && !text.Contains("403"))
			{
				ModProfile.ProfileLog("已触发超时登录失败");
				throw new System.Exception("$登录失败：连接登录服务器超时。\r\n请检查你的网络状况是否良好，或尝试使用 VPN！\r\n\r\n详细信息：" + ex2.InnerHttpException.WebResponse);
			}
			ProjectData.ClearProjectError();
			goto IL_0101;
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			string text2 = ex4.ToString();
			ModProfile.ProfileLog("验证登录失败：" + text2);
			throw;
		}
		goto IL_0295;
		IL_0180:
		try
		{
			if (Data.IsAborted)
			{
				throw new ThreadInterruptedException();
			}
			flag = McLoginRequestLogin(ref Data);
		}
		catch (ModNet.HttpWebException ex5)
		{
			ProjectData.SetProjectError((System.Exception)(object)ex5);
			ModNet.HttpWebException ex6 = ex5;
			ModProfile.ProfileLog("验证失败：" + ((System.Exception)(object)ex6).ToString());
			string text3 = null;
			string webResponse = ex6.InnerHttpException.WebResponse;
			try
			{
				JsonNode val = JsonNode.Parse(webResponse, (JsonNodeOptions?)null, default(JsonDocumentOptions))["errorMessage"];
				if (val != null)
				{
					text3 = "登录失败：" + val.ToString();
				}
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			if (text3 == null)
			{
				text3 = "第三方验证登录失败，请检查你的网络状况是否良好。\r\n\r\n详细信息：" + webResponse;
			}
			throw new System.Exception("$" + text3);
		}
		catch (System.Exception ex7)
		{
			ProjectData.SetProjectError(ex7);
			System.Exception ex8 = ex7;
			ModProfile.ProfileLog("验证失败：" + ex8.ToString());
			throw new System.Exception("$第三方验证登录失败\r\n\r\n详细信息：" + ex8.ToString());
		}
		if (flag)
		{
			ModProfile.ProfileLog("重新进行刷新登录");
			flag2 = true;
			Data.Progress = 0.65;
			goto IL_0111;
		}
		goto IL_0295;
		IL_0295:
		Data.Progress = 0.95;
		return;
		IL_0101:
		Data.Progress = 0.25;
		goto IL_0111;
		IL_0111:
		try
		{
			if (Data.IsAborted)
			{
				throw new ThreadInterruptedException();
			}
			McLoginRequestRefresh(ref Data, flag);
		}
		catch (System.Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			System.Exception ex10 = ex9;
			ModProfile.ProfileLog("刷新登录失败：" + ex10.ToString());
			if (flag2)
			{
				throw new System.Exception("二轮刷新登录失败", ex10);
			}
			ProjectData.ClearProjectError();
			goto IL_0162;
		}
		goto IL_0295;
		IL_0162:
		Data.Progress = (flag ? 0.85 : 0.45);
		goto IL_0180;
	}

	private static void McLoginRequestValidate(ref ModLoader.LoaderTask<McLoginServer, McLoginResult> Data)
	{
		ModProfile.ProfileLog("验证登录开始（Validate, Authlib");
		string text = "";
		string text2 = "";
		string uuid = "";
		string name = "";
		if (ModProfile.SelectedProfile != null)
		{
			text = ModProfile.SelectedProfile.AccessToken;
			text2 = ModProfile.SelectedProfile.ClientToken;
			uuid = ModProfile.SelectedProfile.Uuid;
			name = ModProfile.SelectedProfile.Username;
		}
		JObject jObject = new JObject(new JProperty("accessToken", text), new JProperty("clientToken", text2));
		string url = Data.Input.BaseUrl + "/validate";
		string data = jObject.ToString(Formatting.None);
		Dictionary<string, string> obj = new Dictionary<string, string>();
		obj.Add("Accept-Language", "zh-CN");
		ModNet.NetRequestRetry(url, "POST", data, "application/json", DontRetryOnRefused: true, obj);
		Data.Output.AccessToken = text;
		Data.Output.ClientToken = text2;
		Data.Output.Uuid = uuid;
		Data.Output.Name = name;
		Data.Output.Type = "Auth";
		ModProfile.ProfileLog("验证登录成功（Validate, Authlib");
	}

	private static void McLoginRequestRefresh(ref ModLoader.LoaderTask<McLoginServer, McLoginResult> Data, bool RequestUser)
	{
		JObject jObject = new JObject();
		JObject value = new JObject
		{
			{
				"name",
				ModProfile.SelectedProfile.Username
			},
			{
				"id",
				ModProfile.SelectedProfile.Uuid
			}
		};
		jObject.Add("selectedProfile", value);
		jObject.Add(new JProperty("accessToken", ModProfile.SelectedProfile.AccessToken));
		jObject.Add(new JProperty("requestUser", true));
		ModProfile.ProfileLog("刷新登录开始（Refresh, Authlib");
		string url = Data.Input.BaseUrl + "/refresh";
		string data = jObject.ToString(Formatting.None);
		Dictionary<string, string> obj = new Dictionary<string, string>();
		obj.Add("Accept-Language", "zh-CN");
		JObject jObject2 = (JObject)ModBase.GetJson(ModNet.NetRequestRetry(url, "POST", data, "application/json", DontRetryOnRefused: true, obj));
		if (jObject2["selectedProfile"] == null)
		{
			throw new System.Exception("选择的角色 " + ModProfile.SelectedProfile.Username + " 无效！");
		}
		Data.Output.AccessToken = jObject2["accessToken"].ToString();
		Data.Output.ClientToken = jObject2["clientToken"].ToString();
		Data.Output.Uuid = jObject2["selectedProfile"]["id"].ToString();
		Data.Output.Name = jObject2["selectedProfile"]["name"].ToString();
		Data.Output.Type = "Auth";
		int num = ModProfile.ProfileList.IndexOf(ModProfile.SelectedProfile);
		ModProfile.ProfileList[num].Username = Data.Output.Name;
		ModProfile.ProfileList[num].AccessToken = Data.Output.AccessToken;
		ModProfile.ProfileList[num].ClientToken = Data.Output.ClientToken;
		ModProfile.ProfileList[num].Uuid = Data.Output.Uuid;
		ModProfile.ProfileList[num].Name = Data.Input.UserName;
		ModProfile.ProfileList[num].Password = Data.Input.Password;
		ModProfile.ProfileLog("刷新登录成功（Refresh, Authlib）");
	}

	private static bool McLoginRequestLogin(ref ModLoader.LoaderTask<McLoginServer, McLoginResult> Data)
	{
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected O, but got Unknown
		try
		{
			_Closure_0024__41_002D0 arg = default(_Closure_0024__41_002D0);
			_Closure_0024__41_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__41_002D0(null);
			bool result = false;
			ModProfile.ProfileLog("登录开始（Login, Authlib）");
			JObject jObject = new JObject(new JProperty("agent", new JObject(new JProperty("name", "Minecraft"), new JProperty("version", 1))), new JProperty("username", Data.Input.UserName), new JProperty("password", Data.Input.Password), new JProperty("requestUser", true));
			_Closure_0024__41_002D0 closure_0024__41_002D = CS_0024_003C_003E8__locals0;
			string url = Data.Input.BaseUrl + "/authenticate";
			string data = jObject.ToString(Formatting.None);
			Dictionary<string, string> obj = new Dictionary<string, string>();
			obj.Add("Accept-Language", "zh-CN");
			closure_0024__41_002D._0024VB_0024Local_LoginJson = (JObject)ModBase.GetJson(ModNet.NetRequestRetry(url, "POST", data, "application/json", DontRetryOnRefused: true, obj));
			if (Enumerable.Count<JToken>((System.Collections.Generic.IEnumerable<JToken>)CS_0024_003C_003E8__locals0._0024VB_0024Local_LoginJson["availableProfiles"]) == 0)
			{
				if (Data.Input.ForceReselectProfile)
				{
					ModMain.Hint("你还没有创建角色，无法更换！", ModMain.HintType.Critical);
				}
				throw new System.Exception("$你还没有创建角色，请在创建角色后再试！");
			}
			if (Data.Input.ForceReselectProfile && Enumerable.Count<JToken>((System.Collections.Generic.IEnumerable<JToken>)CS_0024_003C_003E8__locals0._0024VB_0024Local_LoginJson["availableProfiles"]) == 1)
			{
				ModMain.Hint("你的账户中只有一个角色，无法更换！", ModMain.HintType.Critical);
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedName = null;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedId = null;
			if ((CS_0024_003C_003E8__locals0._0024VB_0024Local_LoginJson["selectedProfile"] == null || Data.Input.ForceReselectProfile) && Enumerable.Count<JToken>((System.Collections.Generic.IEnumerable<JToken>)CS_0024_003C_003E8__locals0._0024VB_0024Local_LoginJson["availableProfiles"]) > 1)
			{
				result = true;
				string text = ((ModProfile.SelectedProfile != null) ? ModProfile.SelectedProfile.Uuid : "");
				System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator = ((System.Collections.Generic.IEnumerable<JToken>)CS_0024_003C_003E8__locals0._0024VB_0024Local_LoginJson["availableProfiles"]).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						JToken current = enumerator.Current;
						if (Operators.CompareString(current["id"].ToString(), text, false) == 0)
						{
							CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedName = current["name"].ToString();
							CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedId = current["id"].ToString();
							ModProfile.ProfileLog("根据缓存选择的角色：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedName);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedName == null)
				{
					ModProfile.ProfileLog("要求玩家选择角色");
					ModBase.RunInUiWait((Action)([SpecialName] () =>
					{
						List<IMyRadio> val = new List<IMyRadio>();
						List<JToken> val2 = new List<JToken>();
						System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
						try
						{
							enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)CS_0024_003C_003E8__locals0._0024VB_0024Local_LoginJson["availableProfiles"]).GetEnumerator();
							while (((System.Collections.IEnumerator)enumerator2).MoveNext())
							{
								JToken current2 = enumerator2.Current;
								val.Add((IMyRadio)new MyRadioBox
								{
									Text = current2["name"].ToString()
								});
								val2.Add(current2);
							}
						}
						finally
						{
							((System.IDisposable)enumerator2)?.Dispose();
						}
						int value = ModMain.MyMsgBoxSelect(val, "选择使用的角色").Value;
						CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedName = val2[value]["name"].ToString();
						CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedId = val2[value]["id"].ToString();
					}));
					ModProfile.ProfileLog("玩家选择的角色：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedName);
				}
			}
			else
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedName = CS_0024_003C_003E8__locals0._0024VB_0024Local_LoginJson["selectedProfile"]["name"].ToString();
				CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedId = CS_0024_003C_003E8__locals0._0024VB_0024Local_LoginJson["selectedProfile"]["id"].ToString();
			}
			Data.Output.AccessToken = CS_0024_003C_003E8__locals0._0024VB_0024Local_LoginJson["accessToken"].ToString();
			Data.Output.ClientToken = CS_0024_003C_003E8__locals0._0024VB_0024Local_LoginJson["clientToken"].ToString();
			Data.Output.Name = CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedName;
			Data.Output.Uuid = CS_0024_003C_003E8__locals0._0024VB_0024Local_SelectedId;
			Data.Output.Type = "Auth";
			string serverName = JObject.Parse(Conversions.ToString(ModNet.NetGetCodeByRequestRetry(Data.Input.BaseUrl.Replace("/authserver", ""), Encoding.UTF8)))["meta"]["serverName"].ToString();
			if (Data.Input.IsExist)
			{
				int num = ModProfile.ProfileList.IndexOf(ModProfile.SelectedProfile);
				ModProfile.ProfileList[num].Username = Data.Output.Name;
				ModProfile.ProfileList[num].Uuid = Data.Output.Uuid;
				ModProfile.ProfileList[num].ServerName = serverName;
				ModProfile.ProfileList[num].AccessToken = Data.Output.AccessToken;
				ModProfile.ProfileList[num].ClientToken = Data.Output.ClientToken;
			}
			else
			{
				ModProfile.McProfile mcProfile = new ModProfile.McProfile
				{
					Type = McLoginType.Auth,
					Uuid = Data.Output.Uuid,
					Username = Data.Output.Name,
					Server = Data.Input.BaseUrl,
					ServerName = serverName,
					Name = Data.Input.UserName,
					Password = Data.Input.Password,
					AccessToken = Data.Output.AccessToken,
					ClientToken = Data.Output.ClientToken,
					Expires = 1743779140286L,
					Desc = ""
				};
				ModProfile.ProfileList.Add(mcProfile);
				ModProfile.SelectedProfile = mcProfile;
				ModProfile.IsCreatingProfile = false;
			}
			ModProfile.SaveProfile();
			ModProfile.ProfileLog("登录成功（Login, Authlib）");
			return result;
		}
		catch (ModNet.HttpWebException ex)
		{
			ProjectData.SetProjectError((System.Exception)(object)ex);
			ModNet.HttpWebException ex2 = ex;
			throw;
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			ex4.ToString();
			ModProfile.ProfileLog("第三方验证失败: " + ex4.ToString());
			if (ModBase.StartsWithF(ex4.Message, "$"))
			{
				throw;
			}
			throw new System.Exception("登录失败：" + ex4.Message, ex4);
		}
	}

	private static void McLoginLegacyStart(ModLoader.LoaderTask<McLoginLegacy, McLoginResult> Data)
	{
		McLoginLegacy input = Data.Input;
		ModProfile.ProfileLog($"验证方式：离线（{input.UserName}, {input.Uuid}）");
		Data.Progress = 0.1;
		ref McLoginResult output = ref Data.Output;
		output.Name = input.UserName;
		output.Uuid = ModProfile.SelectedProfile.Uuid;
		output.Type = "Legacy";
		Data.Output.AccessToken = Data.Output.Uuid;
		Data.Output.ClientToken = Data.Output.Uuid;
	}

	private static void McLaunchJava(ModLoader.LoaderTask<int, int> Task)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected O, but got Unknown
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected O, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected O, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected O, but got Unknown
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Expected O, but got Unknown
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Expected O, but got Unknown
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Expected O, but got Unknown
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Expected O, but got Unknown
		//IL_075b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0766: Expected O, but got Unknown
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Expected O, but got Unknown
		//IL_0770: Unknown result type (might be due to invalid IL or missing references)
		//IL_051b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Expected O, but got Unknown
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Expected O, but got Unknown
		//IL_0872: Unknown result type (might be due to invalid IL or missing references)
		//IL_087d: Expected O, but got Unknown
		//IL_0497: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Expected O, but got Unknown
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Expected O, but got Unknown
		//IL_0887: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Expected O, but got Unknown
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Expected O, but got Unknown
		//IL_0949: Unknown result type (might be due to invalid IL or missing references)
		//IL_0954: Expected O, but got Unknown
		//IL_091d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0928: Expected O, but got Unknown
		//IL_08a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a7: Expected O, but got Unknown
		//IL_082a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0835: Expected O, but got Unknown
		//IL_07df: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ea: Expected O, but got Unknown
		//IL_05d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e4: Expected O, but got Unknown
		//IL_0568: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0963: Unknown result type (might be due to invalid IL or missing references)
		//IL_0937: Unknown result type (might be due to invalid IL or missing references)
		//IL_083f: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_058a: Expected O, but got Unknown
		//IL_0a29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a33: Expected O, but got Unknown
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_0690: Expected O, but got Unknown
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
		//IL_060f: Expected O, but got Unknown
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a72: Expected O, but got Unknown
		//IL_069d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa6: Expected O, but got Unknown
		//IL_0986: Unknown result type (might be due to invalid IL or missing references)
		//IL_098c: Expected O, but got Unknown
		//IL_0707: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Expected O, but got Unknown
		//IL_0acf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad9: Expected O, but got Unknown
		//IL_0728: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b42: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4c: Expected O, but got Unknown
		//IL_0b8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b98: Expected O, but got Unknown
		//IL_0b57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b61: Expected O, but got Unknown
		//IL_0bc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcc: Expected O, but got Unknown
		Version val = new Version(0, 0, 0, 0);
		Version val2 = new Version(999, 999, 999, 999);
		if ((!ModMinecraft.McInstanceCurrent.Version.IsStandardVersion && System.DateTime.Compare(ModMinecraft.McInstanceCurrent.ReleaseTime, new System.DateTime(2024, 4, 2)) >= 0) || (ModMinecraft.McInstanceCurrent.Version.IsStandardVersion && ModMinecraft.McInstanceCurrent.Version.McInstance >= new Version(1, 20, 5)))
		{
			if (ModBase.ModeDebug)
			{
				ModBase.Log("[Launch] [Debug] MC 1.20.5+ (24w14a+) 要求至少 Java 21");
			}
			val = new Version(21, 0, 0, 0);
		}
		else if ((!ModMinecraft.McInstanceCurrent.Version.IsStandardVersion && System.DateTime.Compare(ModMinecraft.McInstanceCurrent.ReleaseTime, new System.DateTime(2021, 11, 16)) >= 0) || (ModMinecraft.McInstanceCurrent.Version.IsStandardVersion && ModMinecraft.McInstanceCurrent.Version.McInstance >= new Version(1, 18)))
		{
			if (ModBase.ModeDebug)
			{
				ModBase.Log("[Launch] [Debug] MC 1.18 pre2+ 要求至少 Java 17");
			}
			val = new Version(17, 0, 0, 0);
		}
		else if ((!ModMinecraft.McInstanceCurrent.Version.IsStandardVersion && System.DateTime.Compare(ModMinecraft.McInstanceCurrent.ReleaseTime, new System.DateTime(2021, 5, 11)) >= 0) || (ModMinecraft.McInstanceCurrent.Version.IsStandardVersion && ModMinecraft.McInstanceCurrent.Version.McInstance >= new Version(1, 17)))
		{
			if (ModBase.ModeDebug)
			{
				ModBase.Log("[Launch] [Debug] MC 1.17+ (21w19a+) 要求至少 Java 16");
			}
			val = new Version(16, 0, 0, 0);
		}
		else if (ModMinecraft.McInstanceCurrent.ReleaseTime.Year >= 2017)
		{
			if (ModBase.ModeDebug)
			{
				ModBase.Log("[Launch] [Debug] MC 1.12+ 要求至少 Java 8");
			}
			val = new Version(1, 8, 0, 0);
		}
		else if (System.DateTime.Compare(ModMinecraft.McInstanceCurrent.ReleaseTime, new System.DateTime(2013, 5, 1)) <= 0 && ModMinecraft.McInstanceCurrent.ReleaseTime.Year >= 2001)
		{
			if (ModBase.ModeDebug)
			{
				ModBase.Log("[Launch] [Debug] MC 1.5.2- 要求最高 Java 12");
			}
			val2 = new Version(12, 999, 999, 999);
		}
		if (ModMinecraft.McInstanceCurrent.JsonVersion?["java_version"] != null)
		{
			int num = ModMinecraft.McInstanceCurrent.JsonVersion["java_version"].ToObject<int>();
			McLaunchLog("Mojang 推荐使用 Java " + Conversions.ToString(num));
			if (num >= 22)
			{
				val = new Version(num, 0, 0, 0);
			}
		}
		if (ModMinecraft.McInstanceCurrent.Version.HasOptiFine && ModMinecraft.McInstanceCurrent.Version.IsStandardVersion)
		{
			if (ModMinecraft.McInstanceCurrent.Version.McInstance < new Version(1, 7) || ModMinecraft.McInstanceCurrent.Version.McCodeMain == 12)
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log("[Launch] [Debug] OptiFine <1.7 / 1.12 要求最高 Java 8");
				}
				val2 = new Version(8, 999, 999, 999);
			}
			else if (ModMinecraft.McInstanceCurrent.Version.McInstance >= new Version(1, 8) && ModMinecraft.McInstanceCurrent.Version.McInstance < new Version(1, 12))
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log("[Launch] [Debug] OptiFine 1.8 - 1.11 要求恰好 Java 8");
				}
				val = new Version(1, 8, 0, 0);
				val2 = new Version(8, 999, 999, 999);
			}
		}
		if (ModMinecraft.McInstanceCurrent.Version.HasLiteLoader && ModMinecraft.McInstanceCurrent.Version.IsStandardVersion)
		{
			if (ModBase.ModeDebug)
			{
				ModBase.Log("[Launch] [Debug] LiteLoader 要求最高 Java 8");
			}
			val2 = (Version)((!(new Version(8, 999, 999, 999) < val2)) ? ((object)val2) : ((object)new Version(8, 999, 999, 999)));
		}
		if (ModMinecraft.McInstanceCurrent.Version.HasForge)
		{
			if (ModMinecraft.McInstanceCurrent.Version.McInstance >= new Version(1, 6, 1) && ModMinecraft.McInstanceCurrent.Version.McInstance <= new Version(1, 7, 2))
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log("[Launch] [Debug] 1.6.1 - 1.7.2 Forge 要求必须 Java 7");
				}
				val = (Version)((!(new Version(1, 7, 0, 0) > val)) ? ((object)val) : ((object)new Version(1, 7, 0, 0)));
				val2 = (Version)((!(new Version(1, 7, 999, 999) < val2)) ? ((object)val2) : ((object)new Version(1, 7, 999, 999)));
			}
			else if (ModMinecraft.McInstanceCurrent.Version.McCodeMain <= 12 || !ModMinecraft.McInstanceCurrent.Version.IsStandardVersion)
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log("[Launch] [Debug] <=1.12 Forge 要求 Java 8");
				}
				val2 = new Version(8, 999, 999, 999);
			}
			else if (ModMinecraft.McInstanceCurrent.Version.McCodeMain <= 14)
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log("[Launch] [Debug] 1.13 - 1.14 Forge 要求 Java 8 - 10");
				}
				val = (Version)((!(new Version(1, 8, 0, 0) > val)) ? ((object)val) : ((object)new Version(1, 8, 0, 0)));
				val2 = (Version)((!(new Version(10, 999, 999, 999) < val2)) ? ((object)val2) : ((object)new Version(10, 999, 999, 999)));
			}
			else if (ModMinecraft.McInstanceCurrent.Version.McCodeMain == 15)
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log("[Launch] [Debug] 1.15 Forge 要求 Java 8 - 15");
				}
				val = (Version)((!(new Version(1, 8, 0, 0) > val)) ? ((object)val) : ((object)new Version(1, 8, 0, 0)));
				val2 = (Version)((!(new Version(15, 999, 999, 999) < val2)) ? ((object)val2) : ((object)new Version(15, 999, 999, 999)));
			}
			else if (ModMinecraft.VersionSortBoolean(ModMinecraft.McInstanceCurrent.Version.ForgeVersion, "34.0.0") && ModMinecraft.VersionSortBoolean("36.2.25", ModMinecraft.McInstanceCurrent.Version.ForgeVersion))
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log("[Launch] [Debug] 1.16 Forge 34.X - 36.2.25 要求最高 Java 8u321");
				}
				val2 = (Version)((!(new Version(1, 8, 0, 321) < val2)) ? ((object)val2) : ((object)new Version(1, 8, 0, 321)));
			}
			else if (ModMinecraft.McInstanceCurrent.Version.McCodeMain >= 18 && ModMinecraft.McInstanceCurrent.Version.McCodeMain < 19 && ModMinecraft.McInstanceCurrent.Version.HasOptiFine)
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log("[Launch] [Debug] 1.18 Forge + OptiFine 要求最高 Java 18");
				}
				val2 = (Version)((!(new Version(18, 999, 999, 999) < val2)) ? ((object)val2) : ((object)new Version(18, 999, 999, 999)));
			}
		}
		if (ModMinecraft.McInstanceCurrent.Version.HasCleanroom)
		{
			if (ModBase.ModeDebug)
			{
				ModBase.Log("[Launch] [Debug] Cleanroom 要求至少 Java 21");
			}
			val = (Version)((!(new Version(21, 0, 0, 0) > val)) ? ((object)val) : ((object)new Version(21, 0, 0, 0)));
		}
		if (ModMinecraft.McInstanceCurrent.Version.HasFabric && ModMinecraft.McInstanceCurrent.Version.IsStandardVersion)
		{
			if (ModMinecraft.McInstanceCurrent.Version.McCodeMain >= 15 && ModMinecraft.McInstanceCurrent.Version.McCodeMain <= 16)
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log("[Launch] [Debug] 1.15 - 1.16 Fabric 要求至少 Java 8");
				}
				val = (Version)((!(new Version(1, 8, 0, 0) > val)) ? ((object)val) : ((object)new Version(1, 8, 0, 0)));
			}
			else if (ModMinecraft.McInstanceCurrent.Version.McCodeMain >= 18)
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log("[Launch] [Debug] 1.18+ Fabric 要求至少 Java 17");
				}
				val = (Version)((!(new Version(17, 0, 0, 0) > val)) ? ((object)val) : ((object)new Version(17, 0, 0, 0)));
			}
		}
		if (ModMinecraft.McInstanceCurrent.Version.HasLabyMod)
		{
			if (ModBase.ModeDebug)
			{
				ModBase.Log("[Launch] [Debug] LabyMod 要求至少 Java 21");
			}
			val = (Version)((!(new Version(21, 0, 0, 0) > val)) ? ((object)val) : ((object)new Version(21, 0, 0, 0)));
			val2 = new Version(999, 999, 999, 999);
		}
		if (ModMinecraft.McInstanceCurrent.JsonObject["javaVersion"] != null)
		{
			double num2 = ModBase.Val(ModMinecraft.McInstanceCurrent.JsonObject["javaVersion"]["majorVersion"]);
			if (ModBase.ModeDebug)
			{
				ModBase.Log("[Launch] [Debug] JSON 中参数要求至少 Java " + num2);
			}
			val = (Version)checked((!(num2 <= 8.0)) ? ((!(new Version((int)Math.Round(num2), 0, 0, 0) > val)) ? ((object)val) : ((object)new Version((int)Math.Round(num2), 0, 0, 0))) : ((!(new Version(1, (int)Math.Round(num2), 0, 0) > val)) ? ((object)val) : ((object)new Version(1, (int)Math.Round(num2), 0, 0))));
			if (val2 < val)
			{
				val2 = new Version(999, 999, 999, 999);
			}
		}
		object javaLock = ModJava.JavaLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(javaLock);
		bool flag = false;
		try
		{
			Monitor.Enter(javaLock, ref flag);
			McLaunchLog("Java 版本需求：最低 " + val.ToString() + "，最高 " + val2.ToString());
			McLaunchJavaSelected = ModJava.JavaSelect("$$", val, val2, ModMinecraft.McInstanceCurrent);
			if (Task.IsAborted)
			{
				return;
			}
			if (McLaunchJavaSelected != null)
			{
				McLaunchLog("选择的 Java：" + McLaunchJavaSelected.ToString());
			}
			else
			{
				if (Task.IsAborted)
				{
					return;
				}
				McLaunchLog("无合适的 Java，需要确认是否自动下载");
				string text;
				if (val >= new Version(22, 0))
				{
					text = Conversions.ToString(val.Minor);
					if (!ModJava.JavaDownloadConfirm("Java " + text))
					{
						throw new System.Exception("$$");
					}
				}
				else if (val >= new Version(21, 0))
				{
					text = Conversions.ToString(21);
					if (!ModJava.JavaDownloadConfirm("Java 21"))
					{
						throw new System.Exception("$$");
					}
				}
				else if (val >= new Version(1, 9))
				{
					text = Conversions.ToString(17);
					if (!ModJava.JavaDownloadConfirm("Java 17"))
					{
						throw new System.Exception("$$");
					}
				}
				else if (val2 < new Version(1, 8))
				{
					text = Conversions.ToString(7);
					if (ModMinecraft.McInstanceCurrent.Version.HasForge)
					{
						ModMain.MyMsgBox("你需要先安装 LegacyJavaFixer Mod，或自行安装 Java 7，然后才能启动该版本。", "未找到 Java");
					}
					else if (!ModJava.JavaDownloadConfirm("Java 7", ForcedManualDownload: true))
					{
						throw new System.Exception("$$");
					}
				}
				else if (val > new Version(1, 8, 0, 140) && val2 < new Version(1, 8, 0, 321))
				{
					text = "8u141";
					if (!ModJava.JavaDownloadConfirm("Java 8.0.141 ~ 8.0.320", ForcedManualDownload: true))
					{
						throw new System.Exception("$$");
					}
				}
				else if (val > new Version(1, 8, 0, 140))
				{
					text = "8u141";
					if (!ModJava.JavaDownloadConfirm("Java 8.0.141 或更高版本的 Java 8", ForcedManualDownload: true))
					{
						throw new System.Exception("$$");
					}
				}
				else if (val2 < new Version(1, 8, 0, 321))
				{
					text = Conversions.ToString(8);
					if (!ModJava.JavaDownloadConfirm("Java 8.0.320 或更低版本的 Java 8"))
					{
						throw new System.Exception("$$");
					}
				}
				else
				{
					text = Conversions.ToString(8);
					if (!ModJava.JavaDownloadConfirm("Java 8"))
					{
						throw new System.Exception("$$");
					}
				}
				ModLoader.LoaderCombo<int> loaderCombo = ModJava.JavaFixLoaders(Conversions.ToInteger(text));
				try
				{
					loaderCombo.Start(text, IsForceRestart: true);
					while (loaderCombo.State == ModBase.LoadState.Loading && !Task.IsAborted)
					{
						Task.Progress = loaderCombo.Progress;
						Thread.Sleep(10);
					}
				}
				finally
				{
					loaderCombo.Abort();
				}
				McLaunchJavaSelected = ModJava.JavaSelect("$$", val, val2, ModMinecraft.McInstanceCurrent);
				if (!Task.IsAborted)
				{
					if (McLaunchJavaSelected == null)
					{
						ModMain.Hint("没有可用的 Java，已取消启动！", ModMain.HintType.Critical);
						throw new System.Exception("$$");
					}
					McLaunchLog("选择的 Java：" + McLaunchJavaSelected.ToString());
				}
			}
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(javaLock);
			}
		}
	}

	public static string ExtractJavaWrapper()
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		string text = ModBase.PathPure + "JavaWrapper.jar";
		ModBase.Log("[Java] 选定的 Java Wrapper 路径：" + text);
		object extractJavaWrapperLock = ExtractJavaWrapperLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(extractJavaWrapperLock);
		bool flag = false;
		try
		{
			Monitor.Enter(extractJavaWrapperLock, ref flag);
			try
			{
				WriteJavaWrapper(text);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				if (!File.Exists(text))
				{
					throw new FileNotFoundException("释放 Java Wrapper 失败", ex2);
				}
				ModBase.Log(ex2, "Java Wrapper 文件释放失败，但文件已存在，将在删除后尝试重新生成", ModBase.LogLevel.Developer);
				try
				{
					File.Delete(text);
					WriteJavaWrapper(text);
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, "Java Wrapper 文件重新释放失败，将尝试更换文件名重新生成", ModBase.LogLevel.Developer);
					text = ModBase.PathPure + "JavaWrapper2.jar";
					try
					{
						WriteJavaWrapper(text);
					}
					catch (System.Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						System.Exception ex6 = ex5;
						throw new FileNotFoundException("释放 Java Wrapper 最终尝试失败", ex6);
					}
					ProjectData.ClearProjectError();
				}
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(extractJavaWrapperLock);
			}
		}
		return text;
	}

	private static void WriteJavaWrapper(string Path)
	{
		ModBase.WriteFile(Path, ModBase.GetResourceStream("Resources/java-wrapper.jar"));
	}

	public static string ExtractLinkD()
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		string text = ModBase.PathPure + "linkd.exe";
		object extractLinkDLock = ExtractLinkDLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(extractLinkDLock);
		bool flag = false;
		try
		{
			Monitor.Enter(extractLinkDLock, ref flag);
			try
			{
				WriteLinkD(text);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				if (!File.Exists(text))
				{
					throw new FileNotFoundException("释放 linkd 失败", ex2);
				}
				ModBase.Log(ex2, "linkd 文件释放失败，但文件已存在，将在删除后尝试重新生成", ModBase.LogLevel.Developer);
				try
				{
					File.Delete(text);
					WriteLinkD(text);
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					throw new FileNotFoundException("释放 linkd 失败", ex4);
				}
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(extractLinkDLock);
			}
		}
		return text;
	}

	private static void WriteLinkD(string Path)
	{
		ModBase.WriteFile(Path, ModBase.GetResourceStream("Resources/linkd.exe"));
	}

	private static bool McLaunchNeedsRetroWrapper(ModMinecraft.McInstance Mc)
	{
		return Conversions.ToBoolean((object)((System.DateTime.Compare(Mc.ReleaseTime, new System.DateTime(2013, 6, 25)) >= 0 && Mc.Version.McCodeMain == 99) || (Mc.Version.McCodeMain < 6 && Mc.Version.McCodeMain != 99 && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("LaunchAdvanceDisableRW"))) && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("VersionAdvanceDisableRW", Mc))))));
	}

	private static void McLaunchArgumentMain(ModLoader.LoaderTask<string, List<ModMinecraft.McLibToken>> Loader)
	{
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		McLaunchLog("开始获取 Minecraft 启动参数");
		string text;
		if (ModMinecraft.McInstanceCurrent.JsonObject["arguments"] != null && ModMinecraft.McInstanceCurrent.JsonObject["arguments"]["jvm"] != null)
		{
			McLaunchLog("获取新版 JVM 参数");
			text = McLaunchArgumentsJvmNew(ModMinecraft.McInstanceCurrent);
			McLaunchLog("新版 JVM 参数获取成功：");
			McLaunchLog(text);
		}
		else
		{
			McLaunchLog("获取旧版 JVM 参数");
			text = McLaunchArgumentsJvmOld(ModMinecraft.McInstanceCurrent);
			McLaunchLog("旧版 JVM 参数获取成功：");
			McLaunchLog(text);
		}
		if (!string.IsNullOrEmpty((string?)ModMinecraft.McInstanceCurrent.JsonObject["minecraftArguments"]))
		{
			McLaunchLog("获取旧版 Game 参数");
			text = text + " " + McLaunchArgumentsGameOld(ModMinecraft.McInstanceCurrent);
			McLaunchLog("旧版 Game 参数获取成功");
		}
		if (ModMinecraft.McInstanceCurrent.JsonObject["arguments"] != null && ModMinecraft.McInstanceCurrent.JsonObject["arguments"]["game"] != null)
		{
			McLaunchLog("获取新版 Game 参数");
			text = text + " " + McLaunchArgumentsGameNew(ModMinecraft.McInstanceCurrent);
			McLaunchLog("新版 Game 参数获取成功");
		}
		if (McLaunchJavaSelected.JavaMajorVersion > 8)
		{
			if (!text.Contains("-Dstdout.encoding="))
			{
				text = "-Dstdout.encoding=UTF-8 " + text;
			}
			if (!text.Contains("-Dstderr.encoding="))
			{
				text = "-Dstderr.encoding=UTF-8 " + text;
			}
		}
		if (McLaunchJavaSelected.JavaMajorVersion >= 18 && !text.Contains("-Dfile.encoding="))
		{
			text = "-Dfile.encoding=COMPAT " + text;
		}
		text = text.Replace(" -Dos.name=Windows 10", " -Dos.name=\"Windows 10\"");
		if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("LaunchArgumentWindowType"), (object)0, false))
		{
			text += " --fullscreen";
		}
		System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator = CurrentLaunchOptions.ExtraArgs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				text = text + " " + current.Trim();
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		string text2 = Conversions.ToString(ModBase.Setup.Get("VersionAdvanceGame", ModMinecraft.McInstanceCurrent));
		text = Conversions.ToString(Operators.AddObject((object)text, Operators.ConcatenateObject((object)" ", (Operators.CompareString(text2, "", false) == 0) ? ModBase.Setup.Get("LaunchAdvanceGame") : text2)));
		Dictionary<string, string> val = McLaunchArgumentsReplace(ModMinecraft.McInstanceCurrent, ref Loader);
		if (string.IsNullOrWhiteSpace(val["${version_type}"]))
		{
			text = text.Replace(" --versionType ${version_type}", "");
			val["${version_type}"] = "\"\"";
		}
		string text3 = "";
		string[] array = text.Split(" ", (StringSplitOptions)0);
		System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>> enumerator2 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>>);
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			string text4 = array[i];
			try
			{
				enumerator2 = val.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					KeyValuePair<string, string> current2 = enumerator2.Current;
					text4 = text4.Replace(current2.Key, current2.Value);
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			if ((text4.Contains(" ") || text4.Contains(":\\")) && !ModBase.EndsWithF(text4, "\""))
			{
				text4 = $"\"{text4}\"";
			}
			text3 = text3 + text4 + " ";
		}
		text3 = text3.TrimEnd();
		string worldName = CurrentLaunchOptions.WorldName;
		if (worldName != null)
		{
			text3 += $" --quickPlaySingleplayer \"{worldName}\"";
		}
		string text5 = Conversions.ToString(string.IsNullOrEmpty(CurrentLaunchOptions.ServerIp) ? ModBase.Setup.Get("VersionServerEnter", ModMinecraft.McInstanceCurrent) : CurrentLaunchOptions.ServerIp);
		if (string.IsNullOrWhiteSpace(worldName) && !string.IsNullOrWhiteSpace(text5))
		{
			if (System.DateTime.Compare(ModMinecraft.McInstanceCurrent.ReleaseTime, new System.DateTime(2023, 4, 4)) > 0)
			{
				text3 += $" --quickPlayMultiplayer \"{text5}\"";
			}
			else
			{
				text3 = ((!text5.Contains(":")) ? (text3 + " --server " + text5 + " --port 25565") : string.Concat(new string[5]
				{
					text3,
					" --server ",
					text5.Split(":", (StringSplitOptions)0)[0],
					" --port ",
					text5.Split(":", (StringSplitOptions)0)[1]
				}));
				if (ModMinecraft.McInstanceCurrent.Version.HasOptiFine)
				{
					ModMain.Hint("OptiFine 与自动进入服务器可能不兼容，有概率导致材质丢失甚至游戏崩溃！", ModMain.HintType.Critical);
				}
			}
		}
		McLaunchLog("Minecraft 启动参数：");
		McLaunchLog(text3);
		McLaunchArgument = text3;
	}

	private static string McLaunchArgumentsJvmOld(ModMinecraft.McInstance instance)
	{
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected O, but got Unknown
		List<string> val = new List<string>();
		val.Add("-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump");
		string text = Conversions.ToString(ModBase.Setup.Get("VersionAdvanceJvm", ModMinecraft.McInstanceCurrent));
		if (Operators.CompareString(text, "", false) == 0)
		{
			text = Conversions.ToString(ModBase.Setup.Get("LaunchAdvanceJvm"));
		}
		if (!text.Contains("-Dlog4j2.formatMsgNoLookups=true"))
		{
			text += " -Dlog4j2.formatMsgNoLookups=true";
		}
		text = text.Replace(" -XX:MaxDirectMemorySize=256M", "");
		val.Insert(0, text);
		val.Add("-Xmn" + Conversions.ToString(Math.Floor(PageInstanceSetup.GetRam(ModMinecraft.McInstanceCurrent, !McLaunchJavaSelected.Is64Bit) * 1024.0 * 0.15)) + "m");
		val.Add("-Xmx" + Conversions.ToString(Math.Floor(PageInstanceSetup.GetRam(ModMinecraft.McInstanceCurrent, !McLaunchJavaSelected.Is64Bit) * 1024.0)) + "m");
		val.Add("\"-Djava.library.path=" + GetNativesFolder() + "\"");
		val.Add("-cp ${classpath}");
		if (Operators.CompareString(McLoginLoader.Output.Type, "Auth", false) == 0)
		{
			if (McLaunchJavaSelected.JavaMajorVersion >= 6)
			{
				val.Add("-Djavax.net.ssl.trustStoreType=WINDOWS-ROOT");
			}
			string text2 = McLoginAuthLoader.Input.BaseUrl.Replace("/authserver", "");
			try
			{
				string text3 = Conversions.ToString(ModNet.NetGetCodeByRequestRetry(text2, Encoding.UTF8));
				val.Insert(0, string.Concat(new string[6]
				{
					"-javaagent:\"",
					ModBase.PathPure,
					"authlib-injector.jar\"=",
					text2,
					" -Dauthlibinjector.side=client -Dauthlibinjector.yggdrasil.prefetched=",
					Convert.ToBase64String(Encoding.UTF8.GetBytes(text3))
				}));
			}
			catch (ModNet.HttpWebException ex)
			{
				ProjectData.SetProjectError((System.Exception)(object)ex);
				ModNet.HttpWebException ex2 = ex;
				throw new System.Exception(string.Format("无法连接到第三方登录服务器（{0}）{1}详细信息：", (object)(text2 ?? null), (object)"\r\n") + ex2.InnerHttpException.WebResponse, (System.Exception)(object)ex2);
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				throw new System.Exception($"无法连接到第三方登录服务器（{text2 ?? null}）", ex4);
			}
		}
		int num = 0;
		num = ((!Operators.ConditionalCompareObjectNotEqual(ModBase.Setup.Get("VersionAdvanceRenderer", ModMinecraft.McInstanceCurrent), (object)0, false)) ? Conversions.ToInteger(ModBase.Setup.Get("LaunchAdvanceRenderer")) : Conversions.ToInteger(Operators.SubtractObject(ModBase.Setup.Get("VersionAdvanceRenderer", ModMinecraft.McInstanceCurrent), (object)1)));
		string text4 = "25.1.7";
		string text5 = ModBase.PathPure + "\\mesa-loader-windows\\" + text4 + "\\Loader.jar";
		if (num != 0)
		{
			val.Insert(0, "-javaagent:\"" + text5 + "\"=" + num switch
			{
				2 => "d3d12", 
				1 => "llvmpipe", 
				_ => "zink", 
			});
		}
		if (Config.Instance.UseProxy[instance.PathIndie] && Config.System.HttpProxy.Type.Equals(2) && !string.IsNullOrWhiteSpace(Config.System.HttpProxy.CustomAddress))
		{
			try
			{
				Uri val2 = new Uri(Conversions.ToString(ModBase.Setup.Get("SystemHttpProxy")));
				val.Add(string.Format("-D{0}.proxyHost={1}", (object)(ModBase.StartsWithF(val2.Scheme.ToString(), "https:") ? "https" : "http"), (object)val2.AbsoluteUri));
				val.Add(string.Format("-D{0}.proxyPort={1}", (object)(ModBase.StartsWithF(val2.Scheme.ToString(), "https:") ? "https" : "http"), (object)val2.Port));
			}
			catch (System.Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				System.Exception ex6 = ex5;
				ModBase.Log(ex6, "添加代理信息到游戏失败，放弃加入", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
		}
		if (Conversions.ToBoolean((object)(ModBase.IsUtf8CodePage() && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("LaunchAdvanceDisableJLW"))) && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("VersionAdvanceDisableJLW", ModMinecraft.McInstanceCurrent))))))
		{
			if (McLaunchJavaSelected.JavaMajorVersion >= 9)
			{
				val.Add("--add-exports cpw.mods.bootstraplauncher/cpw.mods.bootstraplauncher=ALL-UNNAMED");
			}
			val.Add("-Doolloo.jlw.tmpdir=\"" + ModBase.PathPure.TrimEnd('\\') + "\"");
			val.Add("-jar \"" + ExtractJavaWrapper() + "\"");
		}
		if (instance.JsonObject["mainClass"] == null)
		{
			throw new System.Exception("实例 JSON 中没有 mainClass 项！");
		}
		val.Add((string?)instance.JsonObject["mainClass"]);
		return ModBase.Join((System.Collections.IEnumerable)val, " ");
	}

	private static string McLaunchArgumentsJvmNew(ModMinecraft.McInstance instance)
	{
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected O, but got Unknown
		List<string> DataList = new List<string>();
		ModMinecraft.McInstance mcInstance = instance;
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
		while (true)
		{
			if (mcInstance.JsonObject["arguments"] != null && mcInstance.JsonObject["arguments"]["jvm"] != null)
			{
				try
				{
					enumerator = ((System.Collections.Generic.IEnumerable<JToken>)mcInstance.JsonObject["arguments"]["jvm"]).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						JToken current = enumerator.Current;
						if (current.Type == JTokenType.String)
						{
							DataList.Add(current.ToString());
						}
						else
						{
							if (!ModMinecraft.McJsonRuleCheck(current["rules"]))
							{
								continue;
							}
							if (current["value"].Type == JTokenType.String)
							{
								DataList.Add(current["value"].ToString());
								continue;
							}
							try
							{
								enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)current["value"]).GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator2).MoveNext())
								{
									JToken current2 = enumerator2.Current;
									DataList.Add(current2.ToString());
								}
							}
							finally
							{
								((System.IDisposable)enumerator2)?.Dispose();
							}
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
			}
			if (Operators.CompareString(mcInstance.InheritInstance, "", false) == 0)
			{
				break;
			}
			mcInstance = new ModMinecraft.McInstance(mcInstance.InheritInstance);
		}
		ModSecret.SecretLaunchJvmArgs(ref DataList);
		if (Operators.CompareString(McLoginLoader.Output.Type, "Auth", false) == 0)
		{
			if (McLaunchJavaSelected.JavaMajorVersion >= 6)
			{
				DataList.Add("-Djavax.net.ssl.trustStoreType=WINDOWS-ROOT");
			}
			string text = McLoginAuthLoader.Input.BaseUrl.Replace("/authserver", "");
			try
			{
				string text2 = Conversions.ToString(ModNet.NetGetCodeByRequestRetry(text, Encoding.UTF8));
				DataList.Insert(0, string.Concat(new string[6]
				{
					"-javaagent:\"",
					ModBase.PathPure,
					"authlib-injector.jar\"=",
					text,
					" -Dauthlibinjector.side=client -Dauthlibinjector.yggdrasil.prefetched=",
					Convert.ToBase64String(Encoding.UTF8.GetBytes(text2))
				}));
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				throw new System.Exception("无法连接到第三方登录服务器（" + text + "）", ex2);
			}
		}
		int num = 0;
		num = ((!Operators.ConditionalCompareObjectNotEqual(ModBase.Setup.Get("VersionAdvanceRenderer", ModMinecraft.McInstanceCurrent), (object)0, false)) ? Conversions.ToInteger(ModBase.Setup.Get("LaunchAdvanceRenderer")) : Conversions.ToInteger(Operators.SubtractObject(ModBase.Setup.Get("VersionAdvanceRenderer", ModMinecraft.McInstanceCurrent), (object)1)));
		string text3 = "25.1.7";
		string text4 = ModBase.PathPure + "\\mesa-loader-windows\\" + text3 + "\\Loader.jar";
		if (num != 0)
		{
			DataList.Insert(0, "-javaagent:\"" + text4 + "\"=" + num switch
			{
				2 => "d3d12", 
				1 => "llvmpipe", 
				_ => "zink", 
			});
		}
		if (Config.Instance.UseProxy[instance.PathIndie] && Config.System.HttpProxy.Type.Equals(2) && !string.IsNullOrWhiteSpace(Config.System.HttpProxy.CustomAddress))
		{
			try
			{
				Uri val = new Uri(Conversions.ToString(ModBase.Setup.Get("SystemHttpProxy")));
				DataList.Add(string.Format("-D{0}.proxyHost={1}", (object)(ModBase.StartsWithF(val.Scheme.ToString(), "https:") ? "https" : "http"), (object)val.AbsoluteUri));
				DataList.Add(string.Format("-D{0}.proxyPort={1}", (object)(ModBase.StartsWithF(val.Scheme.ToString(), "https:") ? "https" : "http"), (object)val.Port));
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "添加代理信息到游戏失败，放弃加入", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
		}
		if (McLaunchNeedsRetroWrapper(instance))
		{
			DataList.Add("-Dretrowrapper.doUpdateCheck=false");
		}
		if (Conversions.ToBoolean((object)(ModBase.IsUtf8CodePage() && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("LaunchAdvanceDisableJLW"))) && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("VersionAdvanceDisableJLW", ModMinecraft.McInstanceCurrent))))))
		{
			if (McLaunchJavaSelected.JavaMajorVersion >= 9)
			{
				DataList.Add("--add-exports cpw.mods.bootstraplauncher/cpw.mods.bootstraplauncher=ALL-UNNAMED");
			}
			DataList.Add("-Doolloo.jlw.tmpdir=\"" + ModBase.PathPure.TrimEnd('\\') + "\"");
			DataList.Add("-jar \"" + ExtractJavaWrapper() + "\"");
		}
		List<string> val2 = new List<string>();
		checked
		{
			int num2 = DataList.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				string text5 = DataList[i];
				if (ModBase.StartsWithF(DataList[i], "-"))
				{
					while (i < DataList.Count - 1 && !ModBase.StartsWithF(DataList[i + 1], "-"))
					{
						i++;
						text5 = text5 + " " + DataList[i];
					}
				}
				val2.Add(text5.Trim().Replace("McEmu= ", "McEmu="));
			}
			val2.Remove("-XX:MaxDirectMemorySize=256M");
			string text6 = ModBase.Join((System.Collections.IEnumerable)Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val2)), " ");
			if (instance.JsonObject["mainClass"] == null)
			{
				throw new System.Exception("实例 JSON 中没有 mainClass 项！");
			}
			return text6 + " " + instance.JsonObject["mainClass"].ToString();
		}
	}

	private static string McLaunchArgumentsGameOld(ModMinecraft.McInstance Version)
	{
		List<string> val = new List<string>();
		if (McLaunchNeedsRetroWrapper(Version))
		{
			val.Add("--tweakClass com.zero.retrowrapper.RetroTweaker");
		}
		string text = Version.JsonObject["minecraftArguments"].ToString();
		if (!text.Contains("--height"))
		{
			text += " --height ${resolution_height} --width ${resolution_width}";
		}
		val.Add(text);
		string text2 = ModBase.Join((System.Collections.IEnumerable)val, " ");
		if ((Version.Version.HasForge || Version.Version.HasLiteLoader) && Version.Version.HasOptiFine)
		{
			if (text2.Contains("--tweakClass optifine.OptiFineForgeTweaker"))
			{
				ModBase.Log("[Launch] 发现正确的 OptiFineForge TweakClass，目前参数：" + text2);
				text2 = text2.Replace(" --tweakClass optifine.OptiFineForgeTweaker", "").Replace("--tweakClass optifine.OptiFineForgeTweaker ", "") + " --tweakClass optifine.OptiFineForgeTweaker";
			}
			if (text2.Contains("--tweakClass optifine.OptiFineTweaker"))
			{
				ModBase.Log("[Launch] 发现错误的 OptiFineForge TweakClass，目前参数：" + text2);
				text2 = text2.Replace(" --tweakClass optifine.OptiFineTweaker", "").Replace("--tweakClass optifine.OptiFineTweaker ", "") + " --tweakClass optifine.OptiFineForgeTweaker";
				try
				{
					ModBase.WriteFile(Version.Path + Version.Name + ".json", ModBase.ReadFile(Version.Path + Version.Name + ".json").Replace("optifine.OptiFineTweaker", "optifine.OptiFineForgeTweaker"));
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "替换 OptiFineForge TweakClass 失败");
					ProjectData.ClearProjectError();
				}
			}
		}
		return text2;
	}

	private static string McLaunchArgumentsGameNew(ModMinecraft.McInstance instance)
	{
		List<string> val = new List<string>();
		ModMinecraft.McInstance mcInstance = instance;
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
		while (true)
		{
			if (mcInstance.JsonObject["arguments"] != null && mcInstance.JsonObject["arguments"]["game"] != null)
			{
				try
				{
					enumerator = ((System.Collections.Generic.IEnumerable<JToken>)mcInstance.JsonObject["arguments"]["game"]).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						JToken current = enumerator.Current;
						if (current.Type == JTokenType.String)
						{
							val.Add(current.ToString());
						}
						else
						{
							if (!ModMinecraft.McJsonRuleCheck(current["rules"]))
							{
								continue;
							}
							if (current["value"].Type == JTokenType.String)
							{
								val.Add(current["value"].ToString());
								continue;
							}
							try
							{
								enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)current["value"]).GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator2).MoveNext())
								{
									JToken current2 = enumerator2.Current;
									val.Add(current2.ToString());
								}
							}
							finally
							{
								((System.IDisposable)enumerator2)?.Dispose();
							}
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
			}
			if (Operators.CompareString(mcInstance.InheritInstance, "", false) == 0)
			{
				break;
			}
			mcInstance = new ModMinecraft.McInstance(mcInstance.InheritInstance);
		}
		List<string> val2 = new List<string>();
		checked
		{
			int num = val.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				string text = val[i];
				if (ModBase.StartsWithF(val[i], "-"))
				{
					while (i < val.Count - 1 && !ModBase.StartsWithF(val[i + 1], "-"))
					{
						i++;
						text = text + " " + val[i];
					}
				}
				val2.Add(text);
			}
			string text2 = ModBase.Join((System.Collections.IEnumerable)Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val2)), " ");
			if ((instance.Version.HasForge || instance.Version.HasLiteLoader) && instance.Version.HasOptiFine)
			{
				if (text2.Contains("--tweakClass optifine.OptiFineForgeTweaker"))
				{
					ModBase.Log("[Launch] 发现正确的 OptiFineForge TweakClass，目前参数：" + text2);
					text2 = text2.Replace(" --tweakClass optifine.OptiFineForgeTweaker", "").Replace("--tweakClass optifine.OptiFineForgeTweaker ", "") + " --tweakClass optifine.OptiFineForgeTweaker";
				}
				if (text2.Contains("--tweakClass optifine.OptiFineTweaker"))
				{
					ModBase.Log("[Launch] 发现错误的 OptiFineForge TweakClass，目前参数：" + text2);
					text2 = text2.Replace(" --tweakClass optifine.OptiFineTweaker", "").Replace("--tweakClass optifine.OptiFineTweaker ", "") + " --tweakClass optifine.OptiFineForgeTweaker";
					try
					{
						ModBase.WriteFile(instance.Path + instance.Name + ".json", ModBase.ReadFile(instance.Path + instance.Name + ".json").Replace("optifine.OptiFineTweaker", "optifine.OptiFineForgeTweaker"));
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "替换 OptiFineForge TweakClass 失败");
						ProjectData.ClearProjectError();
					}
				}
			}
			return text2;
		}
	}

	private static Dictionary<string, string> McLaunchArgumentsReplace(ModMinecraft.McInstance instance, ref ModLoader.LoaderTask<string, List<ModMinecraft.McLibToken>> loader)
	{
		//IL_04d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		Dictionary<string, string> val = new Dictionary<string, string>();
		val.Add("${classpath_separator}", ";");
		val.Add("${natives_directory}", ModBase.ShortenPath(GetNativesFolder()));
		val.Add("${library_directory}", ModBase.ShortenPath(ModMinecraft.PathMcFolder + "libraries"));
		val.Add("${libraries_directory}", ModBase.ShortenPath(ModMinecraft.PathMcFolder + "libraries"));
		val.Add("${launcher_name}", "PCLCE");
		val.Add("${launcher_version}", Conversions.ToString(413));
		val.Add("${version_name}", instance.Name);
		string text = Conversions.ToString(ModBase.Setup.Get("VersionArgumentInfo", ModMinecraft.McInstanceCurrent));
		val.Add("${version_type}", Conversions.ToString((Operators.CompareString(text, "", false) == 0) ? ModBase.Setup.Get("LaunchArgumentInfo") : text));
		checked
		{
			val.Add("${game_directory}", ModBase.ShortenPath(Strings.Left(ModMinecraft.McInstanceCurrent.PathIndie, Enumerable.Count<char>((System.Collections.Generic.IEnumerable<char>)ModMinecraft.McInstanceCurrent.PathIndie) - 1)));
			val.Add("${assets_root}", ModBase.ShortenPath(ModMinecraft.PathMcFolder + "assets"));
			val.Add("${user_properties}", "{}");
			val.Add("${auth_player_name}", McLoginLoader.Output.Name);
			val.Add("${auth_uuid}", McLoginLoader.Output.Uuid);
			val.Add("${auth_access_token}", McLoginLoader.Output.AccessToken);
			val.Add("${access_token}", McLoginLoader.Output.AccessToken);
			val.Add("${auth_session}", McLoginLoader.Output.AccessToken);
			val.Add("${user_type}", "msa");
			object obj = ModBase.Setup.Get("LaunchArgumentWindowType");
			Size _0024VB_0024Local_Result = default(Size);
			if (Operators.ConditionalCompareObjectEqual(obj, (object)2, false))
			{
				_Closure_0024__59_002D0 arg = default(_Closure_0024__59_002D0);
				_Closure_0024__59_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__59_002D0(null);
				ModBase.RunInUiWait((Action)([SpecialName] () =>
				{
					//IL_0029: Unknown result type (might be due to invalid IL or missing references)
					//IL_002e: Unknown result type (might be due to invalid IL or missing references)
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Result = new Size(ModBase.GetPixelSize(((FrameworkElement)ModMain.FrmMain.PanForm).ActualWidth), ModBase.GetPixelSize(((FrameworkElement)ModMain.FrmMain.PanForm).ActualHeight));
				}));
				_0024VB_0024Local_Result = CS_0024_003C_003E8__locals0._0024VB_0024Local_Result;
				_0024VB_0024Local_Result.Height = _0024VB_0024Local_Result.Height - 29.5 * (double)ModBase.DPI / 96.0;
			}
			else if (Operators.ConditionalCompareObjectEqual(obj, (object)3, false))
			{
				_0024VB_0024Local_Result = new(Conversions.ToDouble(NewLateBinding.LateGet((object)null, typeof(Math), "Max", new object[2]
				{
					100,
					ModBase.Setup.Get("LaunchArgumentWindowWidth")
				}, (string[])null, (System.Type[])null, (bool[])null)), Conversions.ToDouble(NewLateBinding.LateGet((object)null, typeof(Math), "Max", new object[2]
				{
					100,
					ModBase.Setup.Get("LaunchArgumentWindowHeight")
				}, (string[])null, (System.Type[])null, (bool[])null)));
			}
			else
			{
				_0024VB_0024Local_Result = new(854.0, 480.0);
			}
			if (ModMinecraft.McInstanceCurrent.Version.McCodeMain <= 12 && McLaunchJavaSelected.JavaMajorVersion <= 8 && McLaunchJavaSelected.Version.Revision >= 200 && McLaunchJavaSelected.Version.Revision <= 321 && !ModMinecraft.McInstanceCurrent.Version.HasOptiFine && !ModMinecraft.McInstanceCurrent.Version.HasForge)
			{
				McLaunchLog($"已应用窗口大小过大修复（{McLaunchJavaSelected.Version.Revision}）");
				_0024VB_0024Local_Result.Width = _0024VB_0024Local_Result.Width / ((double)ModBase.DPI / 96.0);
				_0024VB_0024Local_Result.Height = _0024VB_0024Local_Result.Height / ((double)ModBase.DPI / 96.0);
			}
			val.Add("${resolution_width}", Conversions.ToString(Math.Round(_0024VB_0024Local_Result.Width)));
			val.Add("${resolution_height}", Conversions.ToString(Math.Round(_0024VB_0024Local_Result.Height)));
			val.Add("${game_assets}", ModBase.ShortenPath(ModMinecraft.PathMcFolder + "assets\\virtual\\legacy"));
			val.Add("${assets_index_name}", ModMinecraft.McAssetsGetIndexName(instance));
			List<ModMinecraft.McLibToken> val2 = ModMinecraft.McLibListGet(instance, IncludeInstanceJar: true);
			loader.Output = val2;
			List<string> val3 = new List<string>();
			string text2 = null;
			if (McLaunchNeedsRetroWrapper(instance))
			{
				string text3 = ModMinecraft.PathMcFolder + "libraries\\retrowrapper\\RetroWrapper.jar";
				try
				{
					ModBase.WriteFile(text3, ModBase.GetResourceStream("Resources/retro-wrapper.jar"));
					val3.Add(text3);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "RetroWrapper 释放失败");
					ProjectData.ClearProjectError();
				}
			}
			System.Collections.Generic.IEnumerator<ModMinecraft.McLibToken> enumerator = default(System.Collections.Generic.IEnumerator<ModMinecraft.McLibToken>);
			try
			{
				enumerator = val2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModMinecraft.McLibToken current = enumerator.Current;
					if (!current.IsNatives)
					{
						if (current.Name != null && current.Name.Contains("com.cleanroommc:cleanroom:0.2"))
						{
							val3.Insert(0, current.LocalPath);
						}
						if (current.Name != null && Operators.CompareString(current.Name, "optifine:OptiFine", false) == 0)
						{
							text2 = current.LocalPath;
						}
						else
						{
							val3.Add(current.LocalPath);
						}
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			if (text2 != null)
			{
				val3.Insert(val3.Count - 2, text2);
			}
			val.Add("${classpath}", ModBase.Join((System.Collections.IEnumerable)Enumerable.Select<string, string>((System.Collections.Generic.IEnumerable<string>)val3, (Func<string, string>)([SpecialName] (string c) => ModBase.ShortenPath(c))), ";"));
			return val;
		}
	}

	private static void McLaunchNatives(ModLoader.LoaderTask<List<ModMinecraft.McLibToken>, int> Loader)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_0069: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0149: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Expected O, but got Unknown
		//IL_0219: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		string text = GetNativesFolder() + "\\";
		Directory.CreateDirectory(text);
		McLaunchLog("正在解压 Natives 文件");
		List<string> val = new List<string>();
		System.Collections.Generic.IEnumerator<ModMinecraft.McLibToken> enumerator = default(System.Collections.Generic.IEnumerator<ModMinecraft.McLibToken>);
		try
		{
			enumerator = Loader.Input.GetEnumerator();
			System.Collections.Generic.IEnumerator<ZipArchiveEntry> enumerator2 = default(System.Collections.Generic.IEnumerator<ZipArchiveEntry>);
			while (enumerator.MoveNext())
			{
				ModMinecraft.McLibToken current = enumerator.Current;
				if (!current.IsNatives)
				{
					continue;
				}
				ZipArchive val2;
				try
				{
					val2 = new ZipArchive((Stream)new FileStream(current.LocalPath, (FileMode)3));
				}
				catch (InvalidDataException val3)
				{
					ProjectData.SetProjectError((System.Exception)val3);
					InvalidDataException ex = val3;
					ModBase.Log((System.Exception)(object)ex, "打开 Natives 文件失败（" + current.LocalPath + "）");
					File.Delete(current.LocalPath);
					throw new System.Exception("无法打开 Natives 文件（" + current.LocalPath + "），该文件可能已损坏，请重新尝试启动游戏");
				}
				try
				{
					enumerator2 = val2.Entries.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator2).MoveNext())
					{
						ZipArchiveEntry current2 = enumerator2.Current;
						string fullName = current2.FullName;
						if (!ModBase.EndsWithF(fullName, ".dll", IgnoreCase: true))
						{
							continue;
						}
						string text2 = text + fullName;
						val.Add(text2);
						FileInfo val4 = new FileInfo(text2);
						if (val4.Exists)
						{
							if (val4.Length == current2.Length)
							{
								if (ModBase.ModeDebug)
								{
									McLaunchLog("无需解压：" + text2);
								}
								continue;
							}
							try
							{
								File.Delete(text2);
							}
							catch (UnauthorizedAccessException val5)
							{
								ProjectData.SetProjectError((System.Exception)val5);
								UnauthorizedAccessException val6 = val5;
								McLaunchLog("删除原 dll 访问被拒绝，这通常代表有一个 MC 正在运行，跳过解压：" + text2);
								McLaunchLog("实际的错误信息：" + ((System.Exception)(object)val6).ToString());
								ProjectData.ClearProjectError();
								break;
							}
						}
						ModBase.WriteFile(text2, current2.Open());
						McLaunchLog("已解压：" + text2);
					}
				}
				finally
				{
					((System.IDisposable)enumerator2)?.Dispose();
				}
				if (val2 != null)
				{
					val2.Dispose();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		string[] files = Directory.GetFiles(text);
		foreach (string text3 in files)
		{
			if (!val.Contains(text3))
			{
				try
				{
					McLaunchLog("删除：" + text3);
					File.Delete(text3);
				}
				catch (UnauthorizedAccessException val7)
				{
					ProjectData.SetProjectError((System.Exception)val7);
					UnauthorizedAccessException val8 = val7;
					McLaunchLog("删除多余文件访问被拒绝，跳过删除步骤");
					McLaunchLog("实际的错误信息：" + ((System.Exception)(object)val8).ToString());
					ProjectData.ClearProjectError();
					break;
				}
			}
		}
	}

	private static string GetNativesFolder()
	{
		string text = ModMinecraft.McInstanceCurrent.Path + ModMinecraft.McInstanceCurrent.Name + "-natives";
		if (ModBase.IsGBKEncoding || ModBase.IsASCII(text))
		{
			return text;
		}
		text = Environment.GetFolderPath((System.Environment.SpecialFolder)26) + "\\.minecraft\\bin\\natives";
		if (ModBase.IsASCII(text))
		{
			return text;
		}
		return ModBase.OsDrive + "ProgramData\\PCL\\natives";
	}

	private static void McLaunchPrerun()
	{
		try
		{
			ModMain.SetGPUPreference(McLaunchJavaSelected.JavawExePath, Conversions.ToBoolean(ModBase.Setup.Get("LaunchAdvanceGraphicCard")));
			ModMain.SetGPUPreference(ModBase.ExePathWithName, Conversions.ToBoolean(ModBase.Setup.Get("LaunchAdvanceGraphicCard")));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			if (ProcessInterop.IsAdmin())
			{
				ModBase.Log(ex2, "直接调整显卡设置失败");
			}
			else
			{
				ModBase.Log(ex2, "直接调整显卡设置失败，将以管理员权限重启 PCL 再次尝试");
				try
				{
					if (ProcessInterop.StartAsAdmin($"--gpu \"{McLaunchJavaSelected.JavawExePath}\"").ExitCode != 5)
					{
						throw new System.Exception("调整过程中出现异常");
					}
					McLaunchLog("以管理员权限重启 PCL 并调整显卡设置成功");
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, "调整显卡设置失败，Minecraft 可能会使用默认显卡运行", ModBase.LogLevel.Hint);
					ProjectData.ClearProjectError();
				}
			}
			ProjectData.ClearProjectError();
		}
		try
		{
			if (Operators.CompareString(McLoginLoader.Output.Type, "Microsoft", false) == 0)
			{
				ModMinecraft.McFolderLauncherProfilesJsonCreate(ModMinecraft.PathMcFolder);
				JObject content = (JObject)ModBase.GetJson(string.Concat(new string[7]
				{
					"\n            {\n              \"authenticationDatabase\": {\n                \"00000111112222233333444445555566\": {\n                  \"username\": \"",
					McLoginLoader.Output.Name.Replace("\"", "-"),
					"\",\n                  \"profiles\": {\n                    \"66666555554444433333222221111100\": {\n                        \"displayName\": \"",
					McLoginLoader.Output.Name,
					"\"\n                    }\n                  }\n                }\n              },\n              \"clientToken\": \"",
					McLoginLoader.Output.ClientToken,
					"\",\n              \"selectedUser\": {\n                \"account\": \"00000111112222233333444445555566\", \n                \"profile\": \"66666555554444433333222221111100\"\n              }\n            }"
				}));
				JObject jObject = (JObject)ModBase.GetJson(ModBase.ReadFile(ModMinecraft.PathMcFolder + "launcher_profiles.json"));
				jObject.Merge(content);
				ModBase.WriteFile(ModMinecraft.PathMcFolder + "launcher_profiles.json", jObject.ToString(), Append: false, Encoding.GetEncoding("GB18030"));
				McLaunchLog("已更新 launcher_profiles.json");
			}
		}
		catch (System.Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			System.Exception ex6 = ex5;
			ModBase.Log(ex6, "更新 launcher_profiles.json 失败，将在删除文件后重试");
			try
			{
				File.Delete(ModMinecraft.PathMcFolder + "launcher_profiles.json");
				ModMinecraft.McFolderLauncherProfilesJsonCreate(ModMinecraft.PathMcFolder);
				JObject content2 = (JObject)ModBase.GetJson(string.Concat(new string[7]
				{
					"\n                    {\n                      \"authenticationDatabase\": {\n                        \"00000111112222233333444445555566\": {\n                          \"username\": \"",
					McLoginLoader.Output.Name.Replace("\"", "-"),
					"\",\n                          \"profiles\": {\n                            \"66666555554444433333222221111100\": {\n                                \"displayName\": \"",
					McLoginLoader.Output.Name,
					"\"\n                            }\n                          }\n                        }\n                      },\n                      \"clientToken\": \"",
					McLoginLoader.Output.ClientToken,
					"\",\n                      \"selectedUser\": {\n                        \"account\": \"00000111112222233333444445555566\", \n                        \"profile\": \"66666555554444433333222221111100\"\n                      }\n                    }"
				}));
				JObject jObject2 = (JObject)ModBase.GetJson(ModBase.ReadFile(ModMinecraft.PathMcFolder + "launcher_profiles.json"));
				jObject2.Merge(content2);
				ModBase.WriteFile(ModMinecraft.PathMcFolder + "launcher_profiles.json", jObject2.ToString(), Append: false, Encoding.GetEncoding("GB18030"));
				McLaunchLog("已在删除后更新 launcher_profiles.json");
			}
			catch (System.Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				System.Exception ex8 = ex7;
				ModBase.Log(ex8, "更新 launcher_profiles.json 失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
			ProjectData.ClearProjectError();
		}
		string text = ModMinecraft.McInstanceCurrent.PathIndie + "options.txt";
		if (!File.Exists(text))
		{
			string text2 = ModMinecraft.McInstanceCurrent.PathIndie + "config\\yosbr\\options.txt";
			if (File.Exists(text2))
			{
				McLaunchLog("将修改 Yosbr Mod 中的 options.txt");
				text = text2;
				ModBase.WriteIni(text, "lang", "none");
			}
		}
		try
		{
			string text3 = ModBase.ReadIni(text, "lang", "none");
			bool flag = Directory.Exists(ModMinecraft.McInstanceCurrent.PathIndie + "saves");
			bool flag2 = Operators.CompareString(text3, "none", false) == 0 || !flag;
			System.DateTime? dateTime = ModMinecraft.McInstanceCurrent.ReleaseTime;
			System.DateTime? dateTime2 = dateTime;
			System.DateTime dateTime3 = new System.DateTime(2000, 1, 1);
			bool? flag3;
			bool? flag4 = (flag3 = (dateTime2.HasValue ? new bool?(System.DateTime.Compare(dateTime2.GetValueOrDefault(), dateTime3) > 0) : null));
			bool? obj;
			bool? flag5;
			if (!flag4.HasValue || flag3.GetValueOrDefault())
			{
				dateTime2 = dateTime;
				dateTime3 = new System.DateTime(2011, 11, 18);
				flag4 = (flag5 = (dateTime2.HasValue ? new bool?(System.DateTime.Compare(dateTime2.GetValueOrDefault(), dateTime3) <= 0) : null));
				obj = ((!flag4.HasValue) ? null : (flag5.GetValueOrDefault() & flag3));
			}
			else
			{
				obj = false;
			}
			flag5 = obj;
			string text4;
			if (flag5.Value)
			{
				text4 = "none";
			}
			else
			{
				string text5 = (Conversions.ToBoolean(ModBase.Setup.Get("ToolHelpChinese")) ? "zh_cn" : "en_us");
				text4 = (flag2 ? text5 : text3.ToLower());
				bool? obj2;
				if (!text4.StartsWith("zh_"))
				{
					obj2 = false;
				}
				else
				{
					dateTime2 = dateTime;
					dateTime3 = new System.DateTime(2012, 1, 12);
					obj2 = (dateTime2.HasValue ? new bool?(System.DateTime.Compare(dateTime2.GetValueOrDefault(), dateTime3) >= 0) : null);
				}
				flag5 = obj2;
				if (flag5 ?? true)
				{
					dateTime2 = dateTime;
					dateTime3 = new System.DateTime(2016, 6, 8);
					if ((dateTime2.HasValue ? new bool?(System.DateTime.Compare(dateTime2.GetValueOrDefault(), dateTime3) <= 0) : null).GetValueOrDefault() && flag5.HasValue)
					{
						text4 = checked(text4.Substring(0, text4.Length - 2) + text4.Substring(text4.Length - 2).ToUpper());
					}
				}
			}
			if (Operators.CompareString(text3, text4, false) == 0)
			{
				McLaunchLog($"需要的语言为 {text4}，当前语言为 {text3}，无需修改");
			}
			else
			{
				ModBase.WriteIni(text, "lang", "-");
				ModBase.WriteIni(text, "lang", text4);
				McLaunchLog($"已将语言从 {text3} 修改为 {text4}");
			}
			if (Conversions.ToBoolean((object)(Conversions.ToBoolean(ModBase.Setup.Get("ToolHelpChinese")) && (Operators.CompareString(text3, "none", false) == 0 || !Directory.Exists(ModMinecraft.McInstanceCurrent.PathIndie + "saves")))))
			{
				ModBase.WriteIni(text, "forceUnicodeFont", "true");
				McLaunchLog("已开启 forceUnicodeFont，确保中文字体正常显示");
			}
			object obj3 = ModBase.Setup.Get("LaunchArgumentWindowType");
			if (Operators.ConditionalCompareObjectEqual(obj3, (object)0, false))
			{
				ModBase.WriteIni(text, "fullscreen", "true");
			}
			else if (!Operators.ConditionalCompareObjectEqual(obj3, (object)1, false))
			{
				ModBase.WriteIni(text, "fullscreen", "false");
			}
		}
		catch (System.Exception ex9)
		{
			ProjectData.SetProjectError(ex9);
			System.Exception ex10 = ex9;
			ModBase.Log(ex10, "更新 options.txt 失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private static void McLaunchCustom(ModLoader.LoaderTask<int, int> Loader)
	{
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		string text = Conversions.ToString(ModBase.Setup.Get("LaunchAdvanceRun"));
		if (Operators.CompareString(text, "", false) != 0)
		{
			text = ArgumentReplace(text, ReplaceTimeAndDate: true);
		}
		string text2 = Conversions.ToString(ModBase.Setup.Get("VersionAdvanceRun", ModMinecraft.McInstanceCurrent));
		if (Operators.CompareString(text2, "", false) != 0)
		{
			text2 = ArgumentReplace(text2, ReplaceTimeAndDate: true);
		}
		try
		{
			string raw = string.Concat(new string[12]
			{
				string.Format("{0}", (object)((McLaunchJavaSelected.JavaMajorVersion > 8) ? "chcp 65001>nul\r\n" : "")),
				"@echo off\r\n",
				$"title 启动 - {ModMinecraft.McInstanceCurrent.Name}",
				"\r\necho 游戏正在启动，请稍候。\r\n",
				$"cd /D \"{ModBase.ShortenPath(ModMinecraft.McInstanceCurrent.PathIndie)}\"",
				"\r\n",
				text,
				"\r\n",
				text2,
				"\r\n",
				$"\"{McLaunchJavaSelected.JavaExePath}\" {McLaunchArgument}",
				"\r\necho 游戏已退出。\r\npause"
			});
			ModBase.WriteFile(CurrentLaunchOptions.SaveBatch ?? (ModBase.ExePath + "PCL\\LatestLaunch.bat"), ModMinecraft.FilterAccessToken(raw, 'F'), Append: false, (McLaunchJavaSelected.JavaMajorVersion > 8) ? Encoding.UTF8 : Encoding.Default);
			if (CurrentLaunchOptions.SaveBatch != null)
			{
				McLaunchLog("导出启动脚本完成，强制结束启动过程");
				AbortHint = "导出启动脚本成功！";
				ModBase.OpenExplorer(CurrentLaunchOptions.SaveBatch);
				Loader.Parent.Abort();
				return;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "输出启动脚本失败");
			if (CurrentLaunchOptions.SaveBatch != null)
			{
				throw;
			}
			ProjectData.ClearProjectError();
		}
		if (Operators.CompareString(text, "", false) != 0)
		{
			McLaunchLog("正在执行全局自定义命令：" + text);
			Process val = new Process();
			try
			{
				val.StartInfo.FileName = "cmd.exe";
				val.StartInfo.Arguments = "/c \"" + text + "\"";
				val.StartInfo.WorkingDirectory = ModBase.ShortenPath(ModMinecraft.PathMcFolder);
				val.StartInfo.UseShellExecute = false;
				val.StartInfo.CreateNoWindow = true;
				val.Start();
				if (Conversions.ToBoolean(ModBase.Setup.Get("LaunchAdvanceRunWait")))
				{
					while (!val.HasExited && !Loader.IsAborted)
					{
						Thread.Sleep(10);
					}
				}
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "执行全局自定义命令失败", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
			finally
			{
				if (!val.HasExited && Loader.IsAborted)
				{
					McLaunchLog("由于取消启动，已强制结束自定义命令 CMD 进程");
					val.Kill();
				}
			}
		}
		if (Operators.CompareString(text2, "", false) == 0)
		{
			return;
		}
		McLaunchLog("正在执行实例自定义命令：" + text2);
		Process val2 = new Process();
		try
		{
			val2.StartInfo.FileName = "cmd.exe";
			val2.StartInfo.Arguments = "/c \"" + text2 + "\"";
			val2.StartInfo.WorkingDirectory = ModBase.ShortenPath(ModMinecraft.PathMcFolder);
			val2.StartInfo.UseShellExecute = false;
			val2.StartInfo.CreateNoWindow = true;
			val2.Start();
			if (Conversions.ToBoolean(ModBase.Setup.Get("VersionAdvanceRunWait", ModMinecraft.McInstanceCurrent)))
			{
				while (!val2.HasExited && !Loader.IsAborted)
				{
					Thread.Sleep(10);
				}
			}
		}
		catch (System.Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			System.Exception ex6 = ex5;
			ModBase.Log(ex6, "执行实例自定义命令失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
		finally
		{
			if (!val2.HasExited && Loader.IsAborted)
			{
				McLaunchLog("由于取消启动，已强制结束自定义命令 CMD 进程");
				val2.Kill();
			}
		}
	}

	private static void McLaunchRun(ModLoader.LoaderTask<int, Process> Loader)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		bool flag = Conversions.ToBoolean(ModBase.Setup.Get("LaunchAdvanceNoJavaw"));
		Process val = new Process();
		ProcessStartInfo val2 = new ProcessStartInfo(flag ? McLaunchJavaSelected.JavaExePath : McLaunchJavaSelected.JavawExePath);
		List<string> val3 = new List<string>((System.Collections.Generic.IEnumerable<string>)val2.EnvironmentVariables["Path"].Split(";", (StringSplitOptions)0));
		val3.Add(ModBase.ShortenPath(McLaunchJavaSelected.JavaFolder));
		val2.EnvironmentVariables["Path"] = ModBase.Join((System.Collections.IEnumerable)Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val3)), ";");
		val2.EnvironmentVariables["appdata"] = ModBase.ShortenPath(ModMinecraft.PathMcFolder);
		val2.WorkingDirectory = ModBase.ShortenPath(ModMinecraft.McInstanceCurrent.PathIndie);
		val2.UseShellExecute = false;
		val2.RedirectStandardOutput = true;
		val2.RedirectStandardError = true;
		val2.CreateNoWindow = flag;
		val2.Arguments = McLaunchArgument;
		val.StartInfo = val2;
		val.Start();
		McLaunchLog("已启动游戏进程：" + McLaunchJavaSelected.JavawExePath);
		if (Loader.IsAborted)
		{
			McLaunchLog("由于取消启动，已强制结束游戏进程");
			val.Kill();
			return;
		}
		Loader.Output = val;
		McLaunchProcess = val;
		try
		{
			val.PriorityBoostEnabled = true;
			object obj = ModBase.Setup.Get("LaunchArgumentPriority");
			if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
			{
				val.PriorityClass = (ProcessPriorityClass)32768;
			}
			else if (Operators.ConditionalCompareObjectEqual(obj, (object)2, false))
			{
				val.PriorityClass = (ProcessPriorityClass)16384;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "设置进程优先级失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static void McLaunchWait(ModLoader.LoaderTask<Process, int> Loader)
	{
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c8: Expected O, but got Unknown
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Expected O, but got Unknown
		McLaunchLog("");
		McLaunchLog("~ 基础参数 ~");
		McLaunchLog("PCL 版本：2.13.3 (" + Conversions.ToString(413) + ")");
		McLaunchLog(string.Concat(new string[7]
		{
			"游戏版本：",
			ModMinecraft.McInstanceCurrent.Version.ToString(),
			"（识别为 1.",
			Conversions.ToString(ModMinecraft.McInstanceCurrent.Version.McCodeMain),
			".",
			Conversions.ToString(ModMinecraft.McInstanceCurrent.Version.McCodeSub),
			"）"
		}));
		McLaunchLog("资源版本：" + ModMinecraft.McAssetsGetIndexName(ModMinecraft.McInstanceCurrent));
		McLaunchLog("实例继承：" + ((Operators.CompareString(ModMinecraft.McInstanceCurrent.InheritInstance, "", false) == 0) ? "无" : ModMinecraft.McInstanceCurrent.InheritInstance));
		McLaunchLog(string.Concat(new string[5]
		{
			"分配的内存：",
			Conversions.ToString(PageInstanceSetup.GetRam(ModMinecraft.McInstanceCurrent, !McLaunchJavaSelected.Is64Bit)),
			" GB（",
			Conversions.ToString(Math.Round(PageInstanceSetup.GetRam(ModMinecraft.McInstanceCurrent, !McLaunchJavaSelected.Is64Bit) * 1024.0)),
			" MB）"
		}));
		McLaunchLog("MC 文件夹：" + ModMinecraft.PathMcFolder);
		McLaunchLog("实例文件夹：" + ModMinecraft.McInstanceCurrent.Path);
		McLaunchLog("版本隔离：" + Conversions.ToString(Operators.CompareString(ModMinecraft.McInstanceCurrent.PathIndie, ModMinecraft.McInstanceCurrent.Path, false) == 0));
		McLaunchLog("HMCL 格式：" + Conversions.ToString(ModMinecraft.McInstanceCurrent.IsHmclFormatJson));
		McLaunchLog("Java 信息：" + ((McLaunchJavaSelected != null) ? McLaunchJavaSelected.ToString() : "无可用 Java"));
		McLaunchLog("Natives 文件夹：" + GetNativesFolder());
		McLaunchLog("");
		McLaunchLog("~ 档案参数 ~");
		McLaunchLog("玩家用户名：" + McLoginLoader.Output.Name);
		McLaunchLog("AccessToken：" + McLoginLoader.Output.AccessToken);
		McLaunchLog("ClientToken：" + McLoginLoader.Output.ClientToken);
		McLaunchLog("UUID：" + McLoginLoader.Output.Uuid);
		McLaunchLog("验证方式：" + McLoginLoader.Output.Type);
		McLaunchLog("");
		string text = Conversions.ToString(ModBase.Setup.Get("VersionArgumentTitle", ModMinecraft.McInstanceCurrent));
		if (Conversions.ToBoolean((object)(Operators.CompareString(text, "", false) == 0 && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("VersionArgumentTitleEmpty", ModMinecraft.McInstanceCurrent))))))
		{
			text = Conversions.ToString(ModBase.Setup.Get("LaunchArgumentTitle"));
		}
		text = ArgumentReplace(text, ReplaceTimeAndDate: false);
		string text2 = McLaunchJavaSelected.JavaFolder + "\\jstack.exe";
		ModWatcher.Watcher watcher = (McLaunchWatcher = new ModWatcher.Watcher(Loader, ModMinecraft.McInstanceCurrent, text, File.Exists(text2) ? text2 : "", CurrentLaunchOptions.Test));
		if (CurrentLaunchOptions.Test)
		{
			if (ModMain.FrmLogLeft == null)
			{
				object action;
				if (_Closure_0024__._0024I65_002D0 != null)
				{
					action = _Closure_0024__._0024I65_002D0;
				}
				else
				{
					Action val = [SpecialName] () =>
					{
						ModMain.FrmLogLeft = new PageLogLeft();
					};
					_Closure_0024__._0024I65_002D0 = val;
					action = (object)val;
				}
				ModBase.RunInUiWait((Action)action);
			}
			if (ModMain.FrmLogRight == null)
			{
				object action2;
				if (_Closure_0024__._0024I65_002D1 != null)
				{
					action2 = _Closure_0024__._0024I65_002D1;
				}
				else
				{
					Action val2 = checked([SpecialName] () =>
					{
						ModAnimation.AniControlEnabled++;
						ModMain.FrmLogRight = new PageLogRight();
						ModAnimation.AniControlEnabled--;
					});
					_Closure_0024__._0024I65_002D1 = val2;
					action2 = (object)val2;
				}
				ModBase.RunInUiWait((Action)action2);
			}
			ModMain.FrmLogLeft.Add(watcher);
			McLaunchLog("已显示游戏实时日志");
		}
		while (watcher.State == ModWatcher.Watcher.MinecraftState.Loading)
		{
			Thread.Sleep(100);
		}
		if (watcher.State == ModWatcher.Watcher.MinecraftState.Crashed)
		{
			throw new System.Exception("$$");
		}
	}

	private static void McLaunchEnd()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected O, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		McLaunchLog("开始启动结束处理");
		if (Conversions.ToBoolean(ModBase.Setup.Get("UiMusicStop")))
		{
			object action;
			if (_Closure_0024__._0024I66_002D0 != null)
			{
				action = _Closure_0024__._0024I66_002D0;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					if (ModMusic.MusicPause())
					{
						ModBase.Log("[Music] 已根据设置，在启动后暂停音乐播放");
					}
				};
				_Closure_0024__._0024I66_002D0 = val;
				action = (object)val;
			}
			ModBase.RunInUi((Action)action);
		}
		else if (Conversions.ToBoolean(ModBase.Setup.Get("UiMusicStart")))
		{
			object action2;
			if (_Closure_0024__._0024I66_002D1 != null)
			{
				action2 = _Closure_0024__._0024I66_002D1;
			}
			else
			{
				Action val2 = [SpecialName] () =>
				{
					if (ModMusic.MusicResume())
					{
						ModBase.Log("[Music] 已根据设置，在启动后开始音乐播放");
					}
				};
				_Closure_0024__._0024I66_002D1 = val2;
				action2 = (object)val2;
			}
			ModBase.RunInUi((Action)action2);
		}
		ModVideoBack.IsGaming = true;
		ModVideoBack.VideoPause();
		McLaunchLog(Conversions.ToString(Operators.ConcatenateObject((object)"启动器可见性：", ModBase.Setup.Get("LaunchArgumentVisible"))));
		object obj = ModBase.Setup.Get("LaunchArgumentVisible");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			McLaunchLog("已根据设置，在启动后关闭启动器");
			object action3;
			if (_Closure_0024__._0024I66_002D2 != null)
			{
				action3 = _Closure_0024__._0024I66_002D2;
			}
			else
			{
				Action val3 = [SpecialName] () =>
				{
					ModMain.FrmMain.EndProgram(SendWarning: false);
				};
				_Closure_0024__._0024I66_002D2 = val3;
				action3 = (object)val3;
			}
			ModBase.RunInUi((Action)action3);
		}
		else if (Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)2, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)3, false)))))
		{
			McLaunchLog("已根据设置，在启动后隐藏启动器");
			object action4;
			if (_Closure_0024__._0024I66_002D3 != null)
			{
				action4 = _Closure_0024__._0024I66_002D3;
			}
			else
			{
				Action val4 = [SpecialName] () =>
				{
					ModMain.FrmMain.Hidden = true;
				};
				_Closure_0024__._0024I66_002D3 = val4;
				action4 = (object)val4;
			}
			ModBase.RunInUi((Action)action4);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)4, false))
		{
			McLaunchLog("已根据设置，在启动后最小化启动器");
			object action5;
			if (_Closure_0024__._0024I66_002D4 != null)
			{
				action5 = _Closure_0024__._0024I66_002D4;
			}
			else
			{
				Action val5 = [SpecialName] () =>
				{
					((Window)ModMain.FrmMain).WindowState = (WindowState)1;
				};
				_Closure_0024__._0024I66_002D4 = val5;
				action5 = (object)val5;
			}
			ModBase.RunInUi((Action)action5);
		}
		else
		{
			Operators.ConditionalCompareObjectEqual(obj, (object)5, false);
		}
		ModBase.Setup.Set("SystemLaunchCount", Operators.AddObject(ModBase.Setup.Get("SystemLaunchCount"), (object)1));
		ModBase.Setup.Set("VersionLaunchCount", Operators.AddObject(ModBase.Setup.Get("VersionLaunchCount", ModMinecraft.McInstanceCurrent), (object)1), forceReload: false, ModMinecraft.McInstanceCurrent);
	}

	private static string ArgumentReplace(string Raw, bool ReplaceTimeAndDate)
	{
		if (Raw == null)
		{
			return null;
		}
		Raw = Raw.Replace("{minecraft}", ModMinecraft.PathMcFolder);
		Raw = Raw.Replace("{verpath}", ModMinecraft.McInstanceCurrent.Path);
		Raw = Raw.Replace("{verindie}", ModMinecraft.McInstanceCurrent.PathIndie);
		Raw = Raw.Replace("{java}", McLaunchJavaSelected.JavaFolder);
		Raw = Raw.Replace("{user}", McLoginLoader.Output.Name);
		Raw = Raw.Replace("{uuid}", McLoginLoader.Output.Uuid);
		if (ReplaceTimeAndDate)
		{
			Raw = Raw.Replace("{date}", System.DateTime.Now.ToString("yyyy/M/d"));
			Raw = Raw.Replace("{time}", System.DateTime.Now.ToString("HH:mm:ss"));
		}
		switch (McLoginLoader.Input.Type)
		{
		case McLoginType.Legacy:
			Raw = Raw.Replace("{login}", "离线");
			break;
		case McLoginType.Ms:
			Raw = Raw.Replace("{login}", "正版");
			break;
		case McLoginType.Auth:
			Raw = Raw.Replace("{login}", "Authlib-Injector");
			break;
		}
		Raw = Raw.Replace("{name}", ModMinecraft.McInstanceCurrent.Name);
		Raw = ((!Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "unknown", "old", "pending" }, ModMinecraft.McInstanceCurrent.Version.McName.ToLower())) ? Raw.Replace("{version}", ModMinecraft.McInstanceCurrent.Version.McName) : Raw.Replace("{version}", ModMinecraft.McInstanceCurrent.Name));
		Raw = Raw.Replace("{path}", ModBase.ExePath);
		return Raw;
	}
}
