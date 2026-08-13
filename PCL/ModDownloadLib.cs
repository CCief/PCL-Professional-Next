using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.Core.Minecraft;
using PCL.Core.Net;
using PCL.Core.UI;

namespace PCL;

[StandardModule]
public sealed class ModDownloadLib
{
	public class McInstallRequest
	{
		public string TargetInstanceName;

		public string TargetInstanceFolder;

		public string MinecraftName;

		public string MinecraftJson;

		public string OptiFineVersion;

		public ModDownload.DlOptiFineListEntry OptiFineEntry;

		public string ForgeVersion;

		public ModDownload.DlForgeVersionEntry ForgeEntry;

		public string NeoForgeVersion;

		public ModDownload.DlNeoForgeListEntry NeoForgeEntry;

		public string CleanroomVersion;

		public ModDownload.DlCleanroomListEntry CleanroomEntry;

		public string FabricVersion;

		public ModComp.CompFile FabricApi;

		public string LegacyFabricVersion;

		public ModComp.CompFile LegacyFabricApi;

		public string QuiltVersion;

		public ModComp.CompFile QSL;

		public string LabyModCommitRef;

		public string LabyModChannel;

		public ModComp.CompFile OptiFabric;

		public ModDownload.DlLiteLoaderListEntry LiteLoaderEntry;

		public ModModpack.MMCPackInfo MMCPackInfo;

		public McInstallRequest()
		{
			MinecraftName = null;
			MinecraftJson = null;
			OptiFineVersion = null;
			OptiFineEntry = null;
			ForgeVersion = null;
			ForgeEntry = null;
			NeoForgeVersion = null;
			NeoForgeEntry = null;
			CleanroomVersion = null;
			CleanroomEntry = null;
			FabricVersion = null;
			FabricApi = null;
			LegacyFabricVersion = null;
			LegacyFabricApi = null;
			QuiltVersion = null;
			QSL = null;
			LabyModCommitRef = null;
			LabyModChannel = null;
			OptiFabric = null;
			LiteLoaderEntry = null;
			MMCPackInfo = null;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static MyIconButton.ClickEventHandler _0024IR10_002D1;

		public static MyIconButton.ClickEventHandler _0024IR10_002D2;

		public static MyIconButton.ClickEventHandler _0024IR11_002D3;

		public static MyIconButton.ClickEventHandler _0024IR11_002D4;

		public static MyIconButton.ClickEventHandler _0024IR11_002D5;

		public static Func<ModLoader.LoaderBase, bool> _0024I19_002D2;

		public static Func<ModLoader.LoaderBase, bool> _0024I19_002D3;

		public static Func<ModLoader.LoaderBase, bool> _0024I19_002D4;

		public static MyIconButton.ClickEventHandler _0024IR22_002D8;

		public static MyIconButton.ClickEventHandler _0024IR23_002D9;

		public static MyIconButton.ClickEventHandler _0024IR23_002D10;

		public static MyIconButton.ClickEventHandler _0024IR30_002D12;

		public static MyIconButton.ClickEventHandler _0024IR31_002D13;

		public static MyIconButton.ClickEventHandler _0024IR31_002D14;

		public static Func<string, bool> _0024I35_002D2;

		public static Func<ModLoader.LoaderBase, bool> _0024I37_002D4;

		public static Func<ModLoader.LoaderBase, bool> _0024I37_002D5;

		public static Func<ModLoader.LoaderBase, bool> _0024I37_002D6;

		public static Func<DirectoryInfo, string> _0024I37_002D8;

		public static Func<DirectoryInfo, bool> _0024I37_002D10;

		public static Func<DirectoryInfo, string> _0024I37_002D11;

		public static Func<string, bool> _0024I39_002D0;

		public static MyIconButton.ClickEventHandler _0024IR40_002D17;

		public static MyIconButton.ClickEventHandler _0024IR40_002D18;

		public static MyIconButton.ClickEventHandler _0024IR41_002D19;

		public static Action _0024I44_002D0;

		public static MyIconButton.ClickEventHandler _0024IR49_002D20;

		public static MyIconButton.ClickEventHandler _0024IR49_002D21;

		public static MyIconButton.ClickEventHandler _0024IR50_002D22;

		public static MyIconButton.ClickEventHandler _0024IR55_002D23;

		public static MyIconButton.ClickEventHandler _0024IR55_002D24;

		public static MyIconButton.ClickEventHandler _0024IR56_002D25;

		public static MyIconButton.ClickEventHandler _0024IR64_002D26;

		public static MyIconButton.ClickEventHandler _0024IR73_002D27;

		public static MyIconButton.ClickEventHandler _0024IR81_002D28;

		public static MyIconButton.ClickEventHandler _0024IR81_002D29;

		public static Func<string, bool> _0024I90_002D0;

		public static Func<string, string> _0024I90_002D1;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__R10_002D1(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			McDownloadMenuLog(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R10_002D2(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			McDownloadMenuSaveServer(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R11_002D3(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			McDownloadMenuSave(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R11_002D4(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			McDownloadMenuLog(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R11_002D5(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			McDownloadMenuSaveServer(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal bool _Lambda_0024__19_002D2(ModLoader.LoaderBase l)
		{
			if (Operators.CompareString(l.Name, "下载原版支持库文件", false) != 0)
			{
				return Operators.CompareString(l.Name, "下载原版 Json 文件", false) == 0;
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda_0024__19_002D3(ModLoader.LoaderBase l)
		{
			return l.State != ModBase.LoadState.Finished;
		}

		[SpecialName]
		internal bool _Lambda_0024__19_002D4(ModLoader.LoaderBase l)
		{
			return l.State != ModBase.LoadState.Finished;
		}

		[SpecialName]
		internal void _Lambda_0024__R22_002D8(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			OptiFineLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R23_002D9(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			OptiFineSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R23_002D10(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			OptiFineLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R30_002D12(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			LiteLoaderAll_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R31_002D13(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			LiteLoaderSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R31_002D14(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			LiteLoaderAll_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal bool _Lambda_0024__35_002D2(string l)
		{
			return Operators.CompareString(l, "true", false) == 0;
		}

		[SpecialName]
		internal bool _Lambda_0024__37_002D4(ModLoader.LoaderBase l)
		{
			if (Operators.CompareString(l.Name, "下载原版支持库文件", false) != 0)
			{
				return Operators.CompareString(l.Name, "下载原版 Json 文件", false) == 0;
			}
			return true;
		}

		[SpecialName]
		internal bool _Lambda_0024__37_002D5(ModLoader.LoaderBase l)
		{
			return l.State != ModBase.LoadState.Finished;
		}

		[SpecialName]
		internal bool _Lambda_0024__37_002D6(ModLoader.LoaderBase l)
		{
			return l.State != ModBase.LoadState.Finished;
		}

		[SpecialName]
		internal string _Lambda_0024__37_002D8(DirectoryInfo i)
		{
			return ((FileSystemInfo)i).FullName;
		}

		[SpecialName]
		internal bool _Lambda_0024__37_002D10(DirectoryInfo l)
		{
			if (ModBase.ContainsF(l.Name, "forge", IgnoreCase: true))
			{
				return Enumerable.Any<FileInfo>(l.EnumerateFiles());
			}
			return false;
		}

		[SpecialName]
		internal string _Lambda_0024__37_002D11(DirectoryInfo d)
		{
			return d.Name;
		}

		[SpecialName]
		internal bool _Lambda_0024__39_002D0(string d)
		{
			return Operators.CompareString(d, "", false) != 0;
		}

		[SpecialName]
		internal void _Lambda_0024__R40_002D17(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			ForgeSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R40_002D18(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			ForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R41_002D19(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			ForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__44_002D0()
		{
			try
			{
				ModBase.Log("[Download] 刷新 Forge 推荐版本缓存开始");
				string text = ModNet.NetGetCodeByLoader("https://bmclapi2.bangbang93.com/forge/promos");
				if (text.Length < 1000)
				{
					throw new System.Exception("获取的结果过短（" + text + "）");
				}
				JContainer jContainer = (JContainer)ModBase.GetJson(text);
				List<string> val = new List<string>();
				System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator = ((System.Collections.Generic.IEnumerable<JToken>)jContainer).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						JObject jObject = (JObject)enumerator.Current;
						if (jObject["name"] != null && jObject["build"] != null)
						{
							string text2 = (string?)jObject["name"];
							if (ModBase.EndsWithF(text2, "-recommended"))
							{
								val.Add("\"" + text2.Replace("-recommended", "\":\"" + jObject["build"]["version"].ToString() + "\""));
							}
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				if (val.Count < 5)
				{
					throw new System.Exception("获取的推荐版本数过少（" + text + "）");
				}
				string text3 = "{" + ModBase.Join((System.Collections.IEnumerable)val, ",") + "}";
				ModBase.WriteFile(ModBase.PathTemp + "Cache\\ForgeRecommendedList.json", text3);
				ModBase.Log("[Download] 刷新 Forge 推荐版本缓存成功");
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "刷新 Forge 推荐版本缓存失败");
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R49_002D20(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			NeoForgeSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R49_002D21(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			NeoForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R50_002D22(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			NeoForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R55_002D23(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			CleanroomSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R55_002D24(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			CleanroomLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R56_002D25(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			CleanroomLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R64_002D26(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			FabricLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R73_002D27(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			QuiltLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R81_002D28(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			LabyModSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R81_002D29(object a0, EventArgs a1)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			LabyModLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}

		[SpecialName]
		internal bool _Lambda_0024__90_002D0(string l)
		{
			return Operators.CompareString(l, "", false) != 0;
		}

		[SpecialName]
		internal string _Lambda_0024__90_002D1(string l)
		{
			return l.Trim();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__13_002D0
	{
		public string _0024VB_0024Local_VersionFolder;

		public string _0024VB_0024Local_Id;

		public _Closure_0024__13_002D0(_Closure_0024__13_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_VersionFolder = arg0._0024VB_0024Local_VersionFolder;
				_0024VB_0024Local_Id = arg0._0024VB_0024Local_Id;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
		{
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			ModMinecraft.McInstance mcInstance = new ModMinecraft.McInstance(_0024VB_0024Local_VersionFolder);
			if (mcInstance.JsonObject["downloads"] == null || mcInstance.JsonObject["downloads"]["server"] == null || mcInstance.JsonObject["downloads"]["server"]["url"] == null)
			{
				File.Delete(_0024VB_0024Local_VersionFolder + _0024VB_0024Local_Id + ".json");
				if (!Enumerable.Any<FileSystemInfo>((System.Collections.Generic.IEnumerable<FileSystemInfo>)new DirectoryInfo(_0024VB_0024Local_VersionFolder).GetFileSystemInfos()))
				{
					Directory.Delete(_0024VB_0024Local_VersionFolder);
				}
				Task.Output = new List<ModNet.NetFile>();
				ModMain.Hint($"Mojang 没有给 Minecraft {_0024VB_0024Local_Id} 提供官方服务端下载，没法下，撤退！", ModMain.HintType.Critical);
				Thread.Sleep(2000);
				Task.Abort();
			}
			else
			{
				string original = (string?)mcInstance.JsonObject["downloads"]["server"]["url"];
				ModBase.FileChecker check = new ModBase.FileChecker(1024L, (long)(mcInstance.JsonObject["downloads"]["server"]["size"] ?? ((JToken)(-1))), (string?)mcInstance.JsonObject["downloads"]["server"]["sha1"]);
				List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
				obj.Add(new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(original), _0024VB_0024Local_VersionFolder + _0024VB_0024Local_Id + "-server.jar", check));
				Task.Output = obj;
				string text = $"@echo off\ntitle {_0024VB_0024Local_Id} 原版服务端\necho 如果服务端立即停止，请右键编辑该脚本，将下一行开头的 java 替换为适合该 Minecraft 版本的完整 java.exe 的路径。\necho 你可以在 PCL 的 [设置 → 启动选项] 中查看已安装的 java，所需的 java.exe 一般在其中的 bin 文件夹下。\necho ------------------------------\necho 如果提示 \"You need to agree to the EULA in order to run the server\"，请打开 eula.txt，按说明阅读并同意 Minecraft EULA 后，将该文件最后一行中的 eula=false 改为 eula=true。\necho ------------------------------\n\"java\" -server -XX:+UseG1GC -Xmx4096M -Xms1024M -XX:+UseCompressedOops -jar {_0024VB_0024Local_Id}-server.jar nogui\necho ----------------------\necho 服务端已停止。\npause";
				ModBase.WriteFile(_0024VB_0024Local_VersionFolder + "Launch Server.bat", text, Append: false, Encoding.Default.Equals((object)Encoding.UTF8) ? Encoding.UTF8 : Encoding.GetEncoding("GB18030"));
				File.Delete(_0024VB_0024Local_VersionFolder + _0024VB_0024Local_Id + ".json");
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__14_002D0
	{
		public string _0024VB_0024Local_VersionFolder;

		public _Closure_0024__14_002D0(_Closure_0024__14_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_VersionFolder = arg0._0024VB_0024Local_VersionFolder;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
		{
			List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
			obj.Add(ModDownload.DlClientJarGet(new ModMinecraft.McInstance(_0024VB_0024Local_VersionFolder), ReturnNothingOnFileUseable: false));
			Task.Output = obj;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__18_002D0
	{
		public AutoResetEvent _0024VB_0024Local_outputWaitHandle;

		public _Closure_0024__18_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_3;

		public _Closure_0024__18_002D0(_Closure_0024__18_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_outputWaitHandle = arg0._0024VB_0024Local_outputWaitHandle;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R6(object a0, DataReceivedEventArgs a1)
		{
			_Lambda_0024__0(RuntimeHelpers.GetObjectValue(a0), a1);
		}

		[SpecialName]
		internal object _Lambda_0024__0(object sender, DataReceivedEventArgs e)
		{
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_0096: Expected O, but got Unknown
			try
			{
				if (e.Data == null)
				{
					((EventWaitHandle)_0024VB_0024Local_outputWaitHandle).Set();
				}
				else
				{
					_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResult = e.Data;
					if (ModBase.ModeDebug)
					{
						ModBase.Log("[Installer] " + _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResult);
					}
					_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_TotalLength = checked(_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_TotalLength + 1);
					_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.Progress += 0.00012857142857142858;
				}
			}
			catch (ObjectDisposedException val)
			{
				ProjectData.SetProjectError((System.Exception)val);
				ObjectDisposedException val2 = val;
				ProjectData.ClearProjectError();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "读取 OptiFine 安装器信息失败");
				ProjectData.ClearProjectError();
			}
			try
			{
				if (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.State == ModBase.LoadState.Aborted && !_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.HasExited)
				{
					ModBase.Log("[Installer] 由于任务取消，已中止 OptiFine 安装");
					_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Kill();
				}
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return null;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__18_002D1
	{
		public string _0024VB_0024Local_LastResult;

		public int _0024VB_0024Local_TotalLength;

		public Process _0024VB_0024Local_process;

		public _Closure_0024__18_002D2 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__18_002D1(_Closure_0024__18_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_LastResult = arg0._0024VB_0024Local_LastResult;
				_0024VB_0024Local_TotalLength = arg0._0024VB_0024Local_TotalLength;
				_0024VB_0024Local_process = arg0._0024VB_0024Local_process;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__18_002D2
	{
		public ModLoader.LoaderTask<List<ModNet.NetFile>, bool> _0024VB_0024Local_Task;

		public _Closure_0024__18_002D2(_Closure_0024__18_002D2 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Task = arg0._0024VB_0024Local_Task;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__18_002D3
	{
		public AutoResetEvent _0024VB_0024Local_errorWaitHandle;

		public _Closure_0024__18_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_4;

		public _Closure_0024__18_002D3(_Closure_0024__18_002D3 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_errorWaitHandle = arg0._0024VB_0024Local_errorWaitHandle;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R7(object a0, DataReceivedEventArgs a1)
		{
			_Lambda_0024__1(RuntimeHelpers.GetObjectValue(a0), a1);
		}

		[SpecialName]
		internal object _Lambda_0024__1(object sender, DataReceivedEventArgs e)
		{
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
			//IL_00b2: Expected O, but got Unknown
			try
			{
				if (e.Data == null)
				{
					((EventWaitHandle)_0024VB_0024Local_errorWaitHandle).Set();
				}
				else
				{
					_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResult = e.Data;
					if (ModBase.ModeDebug)
					{
						ModBase.Log("[Installer] " + _0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResult);
					}
					_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_TotalLength = checked(_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_TotalLength + 1);
					_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.Progress += 0.00012857142857142858;
				}
			}
			catch (ObjectDisposedException val)
			{
				ProjectData.SetProjectError((System.Exception)val);
				ObjectDisposedException val2 = val;
				ProjectData.ClearProjectError();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "读取 OptiFine 安装器错误信息失败");
				ProjectData.ClearProjectError();
			}
			try
			{
				if (_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.State == ModBase.LoadState.Aborted && !_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.HasExited)
				{
					ModBase.Log("[Installer] 由于任务取消，已中止 OptiFine 安装");
					_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Kill();
				}
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return null;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__19_002D0
	{
		public ModLoader.LoaderCombo<string> _0024VB_0024Local_ClientDownloadLoader;

		public bool _0024VB_0024Local_IsCustomFolder;

		public ModDownload.DlOptiFineListEntry _0024VB_0024Local_DownloadInfo;

		public string _0024VB_0024Local_Target;

		public string _0024VB_0024Local_ClientFolder;

		public string _0024VB_0024Local_McFolder;

		public string _0024VB_0024Local_VersionFolder;

		public string _0024VB_0024Local_Id;

		public _Closure_0024__19_002D0(_Closure_0024__19_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ClientDownloadLoader = arg0._0024VB_0024Local_ClientDownloadLoader;
				_0024VB_0024Local_IsCustomFolder = arg0._0024VB_0024Local_IsCustomFolder;
				_0024VB_0024Local_DownloadInfo = arg0._0024VB_0024Local_DownloadInfo;
				_0024VB_0024Local_Target = arg0._0024VB_0024Local_Target;
				_0024VB_0024Local_ClientFolder = arg0._0024VB_0024Local_ClientFolder;
				_0024VB_0024Local_McFolder = arg0._0024VB_0024Local_McFolder;
				_0024VB_0024Local_VersionFolder = arg0._0024VB_0024Local_VersionFolder;
				_0024VB_0024Local_Id = arg0._0024VB_0024Local_Id;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
		{
			if (_0024VB_0024Local_ClientDownloadLoader == null)
			{
				if (_0024VB_0024Local_IsCustomFolder)
				{
					throw new System.Exception("如果没有指定原版下载器，则不能指定 MC 安装文件夹");
				}
				_0024VB_0024Local_ClientDownloadLoader = McDownloadClient(ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading, _0024VB_0024Local_DownloadInfo.Inherit);
			}
			Task.Progress = 0.1;
			List<string> val = new List<string>();
			string text = _0024VB_0024Local_DownloadInfo.Inherit;
			if (Operators.CompareString(text, "1.8", false) == 0 || Operators.CompareString(text, "1.9", false) == 0)
			{
				text += ".0";
			}
			if (_0024VB_0024Local_DownloadInfo.IsPreview)
			{
				val.Add("https://bmclapi2.bangbang93.com/optifine/" + text + "/HD_U_" + _0024VB_0024Local_DownloadInfo.NameDisplay.Replace(_0024VB_0024Local_DownloadInfo.Inherit + " ", "").Replace(" ", "/"));
			}
			else
			{
				val.Add("https://bmclapi2.bangbang93.com/optifine/" + text + "/HD_U/" + _0024VB_0024Local_DownloadInfo.NameDisplay.Replace(_0024VB_0024Local_DownloadInfo.Inherit + " ", ""));
			}
			try
			{
				string str = HttpRequestBuilder.Create("https://optifine.net/adloadx?f=" + _0024VB_0024Local_DownloadInfo.NameFile, HttpMethod.Get).WithHeader("Accept", "text/html").WithHeader("Accept-Language", "en-US,en;q=0.5")
					.WithHeader("X-Requested-With", "XMLHttpRequest")
					.SendAsync(throwIfNotSuccess: true)
					.Result.AsStringContent();
				Task.Progress = 0.8;
				val.Add("https://optifine.net/" + ModBase.RegexSearch(str, "downloadx\\?f=[^\"']+", (RegexOptions)0)[0]);
				ModBase.Log("[Download] OptiFine " + _0024VB_0024Local_DownloadInfo.NameDisplay + " 官方下载地址：" + Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)val));
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "获取 OptiFine " + _0024VB_0024Local_DownloadInfo.NameDisplay + " 官方下载地址失败");
				ProjectData.ClearProjectError();
			}
			List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
			obj.Add(new ModNet.NetFile(val.ToArray(), _0024VB_0024Local_Target, new ModBase.FileChecker(307200L, -1L)));
			Task.Output = obj;
		}

		[SpecialName]
		internal void _Lambda_0024__1(ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task)
		{
			if (_0024VB_0024Local_ClientDownloadLoader == null)
			{
				return;
			}
			List<ModLoader.LoaderBase> val = Enumerable.ToList<ModLoader.LoaderBase>(Enumerable.Where<ModLoader.LoaderBase>(Enumerable.Where<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)_0024VB_0024Local_ClientDownloadLoader.GetLoaderList(), (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => Operators.CompareString(l.Name, "下载原版支持库文件", false) == 0 || Operators.CompareString(l.Name, "下载原版 Json 文件", false) == 0)), (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => l.State != ModBase.LoadState.Finished)));
			if (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val))
			{
				ModBase.Log("[Download] OptiFine 安装正在等待原版文件下载完成");
			}
			while (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val) && !Task.IsAborted)
			{
				val = Enumerable.ToList<ModLoader.LoaderBase>(Enumerable.Where<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val, (_Closure_0024__._0024I19_002D4 == null) ? (_Closure_0024__._0024I19_002D4 = [SpecialName] (ModLoader.LoaderBase l) => l.State != ModBase.LoadState.Finished) : _Closure_0024__._0024I19_002D4));
				Thread.Sleep(50);
			}
			if (Task.IsAborted || !_0024VB_0024Local_IsCustomFolder)
			{
				return;
			}
			object vanillaSyncLock = VanillaSyncLock;
			ObjectFlowControl.CheckForSyncLockOnValueType(vanillaSyncLock);
			bool flag = false;
			try
			{
				Monitor.Enter(vanillaSyncLock, ref flag);
				string folderNameFromPath = ModBase.GetFolderNameFromPath(_0024VB_0024Local_ClientFolder);
				Directory.CreateDirectory(_0024VB_0024Local_McFolder + "versions\\" + _0024VB_0024Local_DownloadInfo.Inherit);
				if (!File.Exists(string.Concat(new string[] { _0024VB_0024Local_McFolder, "versions\\", _0024VB_0024Local_DownloadInfo.Inherit, "\\", _0024VB_0024Local_DownloadInfo.Inherit, ".json" })))
				{
					ModBase.CopyFile($"{_0024VB_0024Local_ClientFolder}{folderNameFromPath}.json", $"{_0024VB_0024Local_McFolder}versions\\{_0024VB_0024Local_DownloadInfo.Inherit}\\{_0024VB_0024Local_DownloadInfo.Inherit}.json");
				}
				if (!File.Exists(string.Concat(new string[] { _0024VB_0024Local_McFolder, "versions\\", _0024VB_0024Local_DownloadInfo.Inherit, "\\", _0024VB_0024Local_DownloadInfo.Inherit, ".jar" })))
				{
					ModBase.CopyFile($"{_0024VB_0024Local_ClientFolder}{folderNameFromPath}.jar", $"{_0024VB_0024Local_McFolder}versions\\{_0024VB_0024Local_DownloadInfo.Inherit}\\{_0024VB_0024Local_DownloadInfo.Inherit}.jar");
				}
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(vanillaSyncLock);
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__5(ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task)
		{
			string text = ModMain.RequestTaskTempFolder();
			string text2 = text + ".minecraft\\";
			try
			{
				if (Directory.Exists(text2 + "versions\\" + _0024VB_0024Local_DownloadInfo.Inherit))
				{
					ModBase.DeleteDirectory(text2 + "versions\\" + _0024VB_0024Local_DownloadInfo.Inherit);
				}
				Directory.CreateDirectory(text2 + "versions\\" + _0024VB_0024Local_DownloadInfo.Inherit + "\\");
				ModMinecraft.McFolderLauncherProfilesJsonCreate(text2);
				ModBase.CopyFile(string.Concat(new string[] { _0024VB_0024Local_McFolder, "versions\\", _0024VB_0024Local_DownloadInfo.Inherit, "\\", _0024VB_0024Local_DownloadInfo.Inherit, ".json" }), string.Concat(new string[] { text2, "versions\\", _0024VB_0024Local_DownloadInfo.Inherit, "\\", _0024VB_0024Local_DownloadInfo.Inherit, ".json" }));
				ModBase.CopyFile(string.Concat(new string[] { _0024VB_0024Local_McFolder, "versions\\", _0024VB_0024Local_DownloadInfo.Inherit, "\\", _0024VB_0024Local_DownloadInfo.Inherit, ".jar" }), string.Concat(new string[] { text2, "versions\\", _0024VB_0024Local_DownloadInfo.Inherit, "\\", _0024VB_0024Local_DownloadInfo.Inherit, ".jar" }));
				Task.Progress = 0.06;
				bool flag = ModBase.IsUtf8CodePage();
				while (true)
				{
					try
					{
						McDownloadOptiFineInstall(text, _0024VB_0024Local_Target, Task, flag);
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						if (!flag)
						{
							ModBase.Log(ex2, "不使用 JavaWrapper 安装 OptiFine 失败，将使用 JavaWrapper 并重试");
							flag = true;
							ProjectData.ClearProjectError();
							continue;
						}
						throw new System.Exception("运行 OptiFine 安装器失败", ex2);
					}
					break;
				}
				Task.Progress = 0.96;
				File.Delete(text2 + "launcher_profiles.json");
				ModBase.CopyDirectory(text2, _0024VB_0024Local_McFolder);
				Task.Progress = 0.98;
				File.Delete(_0024VB_0024Local_Target);
				ModBase.DeleteDirectory(text);
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				throw new System.Exception("安装 OptiFine（方式 A）失败", ex4);
			}
		}

		[SpecialName]
		internal void _Lambda_0024__6(ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task)
		{
			try
			{
				Directory.CreateDirectory(_0024VB_0024Local_VersionFolder);
				Task.Progress = 0.1;
				if (File.Exists(_0024VB_0024Local_VersionFolder + _0024VB_0024Local_Id + ".jar"))
				{
					File.Delete(_0024VB_0024Local_VersionFolder + _0024VB_0024Local_Id + ".jar");
				}
				ModBase.CopyFile(string.Concat(new string[] { _0024VB_0024Local_McFolder, "versions\\", _0024VB_0024Local_DownloadInfo.Inherit, "\\", _0024VB_0024Local_DownloadInfo.Inherit, ".jar" }), _0024VB_0024Local_VersionFolder + _0024VB_0024Local_Id + ".jar");
				Task.Progress = 0.7;
				ModMinecraft.McInstance mcInstance = new ModMinecraft.McInstance(_0024VB_0024Local_McFolder + "versions\\" + _0024VB_0024Local_DownloadInfo.Inherit);
				string text = string.Concat(new string[11]
				{
					"{\n    \"id\": \"",
					_0024VB_0024Local_Id,
					"\",\n    \"inheritsFrom\": \"",
					_0024VB_0024Local_DownloadInfo.Inherit,
					"\",\n    \"time\": \"",
					(Operators.CompareString(_0024VB_0024Local_DownloadInfo.ReleaseTime, "", false) == 0) ? mcInstance.ReleaseTime.ToString("yyyy'-'MM'-'dd") : _0024VB_0024Local_DownloadInfo.ReleaseTime.Replace("/", "-"),
					"T23:33:33+08:00\",\n    \"releaseTime\": \"",
					(Operators.CompareString(_0024VB_0024Local_DownloadInfo.ReleaseTime, "", false) == 0) ? mcInstance.ReleaseTime.ToString("yyyy'-'MM'-'dd") : _0024VB_0024Local_DownloadInfo.ReleaseTime.Replace("/", "-"),
					"T23:33:33+08:00\",\n    \"type\": \"release\",\n    \"libraries\": [\n        {\"name\": \"optifine:OptiFine:",
					_0024VB_0024Local_DownloadInfo.NameFile.Replace("OptiFine_", "").Replace(".jar", "").Replace("preview_", ""),
					"\"},\n        {\"name\": \"net.minecraft:launchwrapper:1.12\"}\n    ],\n    \"mainClass\": \"net.minecraft.launchwrapper.Launch\","
				});
				Task.Progress = 0.8;
				ModBase.WriteFile(Text: (!mcInstance.IsOldJson) ? (text + "\n    \"minimumLauncherVersion\": \"21\",\n    \"arguments\": {\n        \"game\": [\n            \"--tweakClass\",\n            \"optifine.OptiFineTweaker\"\n        ]\n    }\n}") : (text + "\n    \"minimumLauncherVersion\": 18,\n    \"minecraftArguments\": \"" + mcInstance.JsonObject["minecraftArguments"].ToString() + "  --tweakClass optifine.OptiFineTweaker\"\n}"), FilePath: _0024VB_0024Local_VersionFolder + _0024VB_0024Local_Id + ".json");
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				throw new System.Exception("安装 OptiFine（方式 B）失败", ex2);
			}
		}

		[SpecialName]
		internal void _Lambda_0024__7(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
		{
			Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(_0024VB_0024Local_VersionFolder));
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__28_002D0
	{
		public bool _0024VB_0024Local_IsCustomFolder;

		public ModLoader.LoaderCombo<string> _0024VB_0024Local_ClientDownloadLoader;

		public ModDownload.DlLiteLoaderListEntry _0024VB_0024Local_DownloadInfo;

		public string _0024VB_0024Local_VersionFolder;

		public string _0024VB_0024Local_VersionName;

		[SpecialName]
		internal void _Lambda_0024__R11(ModLoader.LoaderTask<string, string> a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			if (_0024VB_0024Local_IsCustomFolder)
			{
				throw new System.Exception("如果没有指定原版下载器，则不能指定 MC 安装文件夹");
			}
			_0024VB_0024Local_ClientDownloadLoader = McDownloadClient(ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading, _0024VB_0024Local_DownloadInfo.Inherit);
		}

		[SpecialName]
		internal void _Lambda_0024__1(ModLoader.LoaderTask<string, string> Task)
		{
			try
			{
				Directory.CreateDirectory(_0024VB_0024Local_VersionFolder);
				JObject jObject = new JObject
				{
					{ "id", _0024VB_0024Local_VersionName },
					{
						"time",
						System.DateTime.ParseExact(_0024VB_0024Local_DownloadInfo.ReleaseTime, "yyyy/MM/dd HH:mm", (IFormatProvider)(object)CultureInfo.CurrentCulture)
					},
					{
						"releaseTime",
						System.DateTime.ParseExact(_0024VB_0024Local_DownloadInfo.ReleaseTime, "yyyy/MM/dd HH:mm", (IFormatProvider)(object)CultureInfo.CurrentCulture)
					},
					{ "type", "release" },
					{
						"arguments",
						(JToken)ModBase.GetJson("{\"game\":[\"--tweakClass\",\"" + _0024VB_0024Local_DownloadInfo.JsonToken["tweakClass"].ToString() + "\"]}")
					},
					{
						"libraries",
						_0024VB_0024Local_DownloadInfo.JsonToken["libraries"]
					}
				};
				((JContainer)jObject["libraries"]).Add(RuntimeHelpers.GetObjectValue(ModBase.GetJson("{\"name\": \"com.mumfrey:liteloader:" + _0024VB_0024Local_DownloadInfo.JsonToken["version"].ToString() + "\",\"url\": \"https://dl.liteloader.com/versions/\"}")));
				jObject.Add("mainClass", "net.minecraft.launchwrapper.Launch");
				jObject.Add("minimumLauncherVersion", 18);
				jObject.Add("inheritsFrom", _0024VB_0024Local_DownloadInfo.Inherit);
				jObject.Add("jar", _0024VB_0024Local_DownloadInfo.Inherit);
				ModBase.WriteFile(_0024VB_0024Local_VersionFolder + _0024VB_0024Local_VersionName + ".json", jObject.ToString());
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				throw new System.Exception("安装新 LiteLoader 实例失败", ex2);
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
		{
			Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(_0024VB_0024Local_VersionFolder));
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__35_002D0
	{
		public AutoResetEvent _0024VB_0024Local_outputWaitHandle;

		public _Closure_0024__35_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_3;

		public _Closure_0024__35_002D0(_Closure_0024__35_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_outputWaitHandle = arg0._0024VB_0024Local_outputWaitHandle;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R15(object a0, DataReceivedEventArgs a1)
		{
			_Lambda_0024__0(RuntimeHelpers.GetObjectValue(a0), a1);
		}

		[SpecialName]
		internal object _Lambda_0024__0(object sender, DataReceivedEventArgs e)
		{
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected O, but got Unknown
			//IL_0075: Expected O, but got Unknown
			try
			{
				if (e.Data == null)
				{
					((EventWaitHandle)_0024VB_0024Local_outputWaitHandle).Set();
				}
				else
				{
					_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Enqueue(e.Data);
					if (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Count > 100)
					{
						_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Dequeue();
					}
					ForgelikeInjectorLine(e.Data, _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task);
				}
			}
			catch (ObjectDisposedException val)
			{
				ProjectData.SetProjectError((System.Exception)val);
				ObjectDisposedException val2 = val;
				ProjectData.ClearProjectError();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, $"读取 {_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LoaderName} 安装器信息失败");
				ProjectData.ClearProjectError();
			}
			try
			{
				if (_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.State == ModBase.LoadState.Aborted && !_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.HasExited)
				{
					ModBase.Log($"[Installer] 由于任务取消，已中止 {_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LoaderName} 安装");
					_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Kill();
				}
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return null;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__35_002D1
	{
		public Queue<string> _0024VB_0024Local_LastResults;

		public string _0024VB_0024Local_LoaderName;

		public Process _0024VB_0024Local_process;

		public _Closure_0024__35_002D2 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__35_002D1(_Closure_0024__35_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_LastResults = arg0._0024VB_0024Local_LastResults;
				_0024VB_0024Local_LoaderName = arg0._0024VB_0024Local_LoaderName;
				_0024VB_0024Local_process = arg0._0024VB_0024Local_process;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__35_002D2
	{
		public ModLoader.LoaderTask<bool, bool> _0024VB_0024Local_Task;

		public _Closure_0024__35_002D2(_Closure_0024__35_002D2 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Task = arg0._0024VB_0024Local_Task;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__35_002D3
	{
		public AutoResetEvent _0024VB_0024Local_errorWaitHandle;

		public _Closure_0024__35_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_4;

		public _Closure_0024__35_002D3(_Closure_0024__35_002D3 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_errorWaitHandle = arg0._0024VB_0024Local_errorWaitHandle;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R16(object a0, DataReceivedEventArgs a1)
		{
			_Lambda_0024__1(RuntimeHelpers.GetObjectValue(a0), a1);
		}

		[SpecialName]
		internal object _Lambda_0024__1(object sender, DataReceivedEventArgs e)
		{
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Expected O, but got Unknown
			//IL_0089: Expected O, but got Unknown
			try
			{
				if (e.Data == null)
				{
					((EventWaitHandle)_0024VB_0024Local_errorWaitHandle).Set();
				}
				else
				{
					_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Enqueue(e.Data);
					if (_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Count > 100)
					{
						_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Dequeue();
					}
					ForgelikeInjectorLine(e.Data, _0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task);
				}
			}
			catch (ObjectDisposedException val)
			{
				ProjectData.SetProjectError((System.Exception)val);
				ObjectDisposedException val2 = val;
				ProjectData.ClearProjectError();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, $"读取 {_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LoaderName} 安装器错误信息失败");
				ProjectData.ClearProjectError();
			}
			try
			{
				if (_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.State == ModBase.LoadState.Aborted && !_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.HasExited)
				{
					ModBase.Log($"[Installer] 由于任务取消，已中止 {_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LoaderName} 安装");
					_0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Kill();
				}
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return null;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__37_002D0
	{
		public string _0024VB_0024Local_Inherit;

		public string _0024VB_0024Local_LoaderVersion;

		public ModDownload.DlForgelikeEntry _0024VB_0024Local_Info;

		public string _0024VB_0024Local_LoaderName;

		public ModLoader.LoaderCombo<string> _0024VB_0024Local_ClientDownloadLoader;

		public bool _0024VB_0024Local_IsCustomFolder;

		public string _0024VB_0024Local_InstallerAddress;

		public string _0024VB_0024Local_ForgeType;

		public string _0024VB_0024Local_McFolder;

		public string _0024VB_0024Local_ClientFolder;

		public string _0024VB_0024Local_VersionFolder;

		public string _0024VB_0024Local_TargetVersion;

		public _Closure_0024__37_002D0(_Closure_0024__37_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Inherit = arg0._0024VB_0024Local_Inherit;
				_0024VB_0024Local_LoaderVersion = arg0._0024VB_0024Local_LoaderVersion;
				_0024VB_0024Local_Info = arg0._0024VB_0024Local_Info;
				_0024VB_0024Local_LoaderName = arg0._0024VB_0024Local_LoaderName;
				_0024VB_0024Local_ClientDownloadLoader = arg0._0024VB_0024Local_ClientDownloadLoader;
				_0024VB_0024Local_IsCustomFolder = arg0._0024VB_0024Local_IsCustomFolder;
				_0024VB_0024Local_InstallerAddress = arg0._0024VB_0024Local_InstallerAddress;
				_0024VB_0024Local_ForgeType = arg0._0024VB_0024Local_ForgeType;
				_0024VB_0024Local_McFolder = arg0._0024VB_0024Local_McFolder;
				_0024VB_0024Local_ClientFolder = arg0._0024VB_0024Local_ClientFolder;
				_0024VB_0024Local_VersionFolder = arg0._0024VB_0024Local_VersionFolder;
				_0024VB_0024Local_TargetVersion = arg0._0024VB_0024Local_TargetVersion;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<string, string> Task)
		{
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>("McDownloadForgeLoader " + _0024VB_0024Local_Inherit, ModDownload.DlForgeVersionMain, null, (ThreadPriority)2);
			loaderTask.WaitForExit(_0024VB_0024Local_Inherit);
			Task.Progress = 0.8;
			System.Collections.Generic.IEnumerator<ModDownload.DlForgeVersionEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModDownload.DlForgeVersionEntry>);
			try
			{
				enumerator = loaderTask.Output.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModDownload.DlForgeVersionEntry current = enumerator.Current;
					if (ModMinecraft.VersionSortInteger(current.Version.ToString(), _0024VB_0024Local_LoaderVersion) == 0)
					{
						_0024VB_0024Local_Info = current;
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			throw new System.Exception(string.Concat(new string[5]
			{
				$"未能找到 {_0024VB_0024Local_LoaderName} ",
				_0024VB_0024Local_Inherit,
				"-",
				_0024VB_0024Local_LoaderVersion,
				" 的详细信息！"
			}));
		}

		[SpecialName]
		internal void _Lambda_0024__1(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
		{
			if (_0024VB_0024Local_ClientDownloadLoader == null)
			{
				if (_0024VB_0024Local_IsCustomFolder)
				{
					throw new System.Exception("如果没有指定原版下载器，则不能指定 MC 安装文件夹");
				}
				_0024VB_0024Local_ClientDownloadLoader = McDownloadClient(ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading, _0024VB_0024Local_Inherit);
			}
			List<ModNet.NetFile> val = new List<ModNet.NetFile>();
			if (_0024VB_0024Local_Info.ForgeType == ModDownload.DlForgelikeEntry.ForgelikeType.NeoForge)
			{
				string text = ((ModDownload.DlNeoForgeListEntry)_0024VB_0024Local_Info).UrlBase + "-installer.jar";
				val.Add(new ModNet.NetFile(new string[2]
				{
					text.Replace("maven.neoforged.net/releases", "bmclapi2.bangbang93.com/maven"),
					text
				}, _0024VB_0024Local_InstallerAddress, new ModBase.FileChecker(65536L, -1L)));
			}
			else if (_0024VB_0024Local_Info.ForgeType == ModDownload.DlForgelikeEntry.ForgelikeType.Cleanroom)
			{
				string text2 = ((ModDownload.DlCleanroomListEntry)_0024VB_0024Local_Info).UrlBase + "-installer.jar";
				val.Add(new ModNet.NetFile(new string[] { text2 }, _0024VB_0024Local_InstallerAddress, new ModBase.FileChecker(65536L, -1L)));
			}
			else
			{
				ModDownload.DlForgeVersionEntry dlForgeVersionEntry = (ModDownload.DlForgeVersionEntry)_0024VB_0024Local_Info;
				string text3 = string.Format("{0}-{1}/forge-{2}-{3}-{4}.{5}", new object[6]
				{
					dlForgeVersionEntry.Inherit.Replace("-", "_"),
					dlForgeVersionEntry.FileVersion,
					dlForgeVersionEntry.Inherit.Replace("-", "_"),
					dlForgeVersionEntry.FileVersion,
					dlForgeVersionEntry.Category,
					dlForgeVersionEntry.FileExtension
				});
				val.Add(new ModNet.NetFile(new string[2]
				{
					$"https://bmclapi2.bangbang93.com/maven/net/minecraftforge/forge/{text3}",
					$"https://files.minecraftforge.net/maven/net/minecraftforge/forge/{text3}"
				}, _0024VB_0024Local_InstallerAddress, new ModBase.FileChecker(65536L, -1L, dlForgeVersionEntry.Hash)));
			}
			Task.Output = val;
		}

		[SpecialName]
		internal void _Lambda_0024__7(ModLoader.LoaderTask<bool, bool> Task)
		{
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Expected O, but got Unknown
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Expected O, but got Unknown
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			ZipArchive val = null;
			try
			{
				_Closure_0024__37_002D2 arg = default(_Closure_0024__37_002D2);
				_Closure_0024__37_002D2 CS_0024_003C_003E8__locals0 = new _Closure_0024__37_002D2(null);
				ModBase.Log("[Download] 开始进行 Forgelike 安装：" + _0024VB_0024Local_InstallerAddress);
				CS_0024_003C_003E8__locals0._0024VB_0024Local_OldList = Enumerable.ToList<string>(Enumerable.Select<DirectoryInfo, string>(new DirectoryInfo(_0024VB_0024Local_McFolder + "versions\\").EnumerateDirectories(), (Func<DirectoryInfo, string>)([SpecialName] (DirectoryInfo i) => ((FileSystemInfo)i).FullName)));
				val = new ZipArchive((Stream)new FileStream(_0024VB_0024Local_InstallerAddress, (FileMode)3));
				_ = (JObject)ModBase.GetJson(ModBase.ReadFile(val.GetEntry("install_profile.json").Open()));
				Directory.CreateDirectory(_0024VB_0024Local_VersionFolder);
				Task.Progress = 0.04;
				ModMinecraft.McFolderLauncherProfilesJsonCreate(_0024VB_0024Local_McFolder);
				Task.Progress = 0.05;
				bool flag = ModBase.IsUtf8CodePage();
				while (true)
				{
					try
					{
						ModBase.WriteFile(ModBase.PathTemp + "Cache\\forge_installer.jar", ModBase.GetResourceStream("Resources/forge-installer.jar"));
						Task.Progress = 0.06;
						ForgelikeInjector(_0024VB_0024Local_InstallerAddress, Task, _0024VB_0024Local_McFolder, flag, _0024VB_0024Local_ForgeType);
						Task.Progress = 0.97;
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						if (!flag)
						{
							ModBase.Log(ex2, $"不使用 JavaWrapper 安装 {_0024VB_0024Local_LoaderName} 失败，将使用 JavaWrapper 并重试");
							flag = true;
							ProjectData.ClearProjectError();
							continue;
						}
						throw new System.Exception($"运行 {_0024VB_0024Local_LoaderName} 安装器失败", ex2);
					}
					break;
				}
				List<DirectoryInfo> val2 = Enumerable.ToList<DirectoryInfo>(Enumerable.SkipWhile<DirectoryInfo>(new DirectoryInfo(_0024VB_0024Local_McFolder + "versions\\").EnumerateDirectories(), (Func<DirectoryInfo, bool>)([SpecialName] (DirectoryInfo i) => CS_0024_003C_003E8__locals0._0024VB_0024Local_OldList.Contains(((FileSystemInfo)i).FullName))));
				if (val2.Count > 1)
				{
					val2 = Enumerable.ToList<DirectoryInfo>(Enumerable.Where<DirectoryInfo>((System.Collections.Generic.IEnumerable<DirectoryInfo>)val2, (Func<DirectoryInfo, bool>)([SpecialName] (DirectoryInfo l) => ModBase.ContainsF(l.Name, "forge", IgnoreCase: true) && Enumerable.Any<FileInfo>(l.EnumerateFiles()))));
				}
				if (val2.Count == 1)
				{
					FileInfo val3 = Enumerable.First<FileInfo>(val2[0].EnumerateFiles());
					ModBase.WriteFile(_0024VB_0024Local_VersionFolder + _0024VB_0024Local_TargetVersion + ".json", ModBase.ReadFile(((FileSystemInfo)val3).FullName));
					ModBase.Log($"[Download] 已拷贝新增的实例 Json 文件：{((FileSystemInfo)val3).FullName} -> {_0024VB_0024Local_VersionFolder}{_0024VB_0024Local_TargetVersion}.json");
				}
				else if (val2.Count > 1)
				{
					ModBase.Log(string.Format("[Download] 有多个疑似的新增实例，无法确定：{0}", (object)ModBase.Join((System.Collections.IEnumerable)Enumerable.Select<DirectoryInfo, string>((System.Collections.Generic.IEnumerable<DirectoryInfo>)val2, (Func<DirectoryInfo, string>)([SpecialName] (DirectoryInfo d) => d.Name)), ";")));
				}
				else
				{
					ModBase.Log("[Download] 未找到新增的实例文件夹");
				}
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				throw new System.Exception($"安装新 {_0024VB_0024Local_LoaderName} 实例失败", ex4);
			}
			finally
			{
				try
				{
					if (val != null)
					{
						val.Dispose();
					}
					if (File.Exists(_0024VB_0024Local_InstallerAddress))
					{
						File.Delete(_0024VB_0024Local_InstallerAddress);
					}
				}
				catch (System.Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					System.Exception ex6 = ex5;
					ModBase.Log(ex6, $"安装 {_0024VB_0024Local_LoaderName} 清理文件时出错");
					ProjectData.ClearProjectError();
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__12(ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task)
		{
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0014: Expected O, but got Unknown
			ZipArchive val = null;
			try
			{
				val = new ZipArchive((Stream)new FileStream(_0024VB_0024Local_InstallerAddress, (FileMode)3));
				Task.Progress = 0.2;
				JObject jObject = (JObject)ModBase.GetJson(ModBase.ReadFile(val.GetEntry("install_profile.json").Open()));
				Task.Progress = 0.4;
				Directory.CreateDirectory(_0024VB_0024Local_VersionFolder);
				Task.Progress = 0.5;
				if (jObject["install"] == null)
				{
					ModBase.Log("[Download] 开始进行 Forge 安装，Legacy 方式 1：" + _0024VB_0024Local_InstallerAddress);
					JObject jObject2 = (JObject)ModBase.GetJson(ModBase.ReadFile(val.GetEntry(jObject["json"].ToString().TrimStart('/')).Open()));
					jObject2["id"] = _0024VB_0024Local_TargetVersion;
					ModBase.WriteFile(_0024VB_0024Local_VersionFolder + _0024VB_0024Local_TargetVersion + ".json", jObject2.ToString());
					Task.Progress = 0.6;
					val.Dispose();
					ModBase.ExtractFile(_0024VB_0024Local_InstallerAddress, _0024VB_0024Local_InstallerAddress + "_unrar\\");
					ModBase.CopyDirectory(_0024VB_0024Local_InstallerAddress + "_unrar\\maven\\", _0024VB_0024Local_McFolder + "libraries\\");
					ModBase.DeleteDirectory(_0024VB_0024Local_InstallerAddress + "_unrar\\");
					return;
				}
				ModBase.Log("[Download] 开始进行 Forge 安装，Legacy 方式 2：" + _0024VB_0024Local_InstallerAddress);
				string text = ModMinecraft.McLibGet((string?)jObject["install"]["path"], WithHead: true, IgnoreLiteLoader: false, _0024VB_0024Local_McFolder);
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				ModBase.WriteFile(text, val.GetEntry((string?)jObject["install"]["filePath"]).Open());
				Task.Progress = 0.9;
				jObject["versionInfo"]["id"] = _0024VB_0024Local_TargetVersion;
				if (jObject["versionInfo"]["inheritsFrom"] == null)
				{
					((JObject)jObject["versionInfo"]).Add("inheritsFrom", _0024VB_0024Local_Inherit);
				}
				ModBase.WriteFile(_0024VB_0024Local_VersionFolder + _0024VB_0024Local_TargetVersion + ".json", jObject["versionInfo"].ToString());
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				throw new System.Exception("非新版方式安装 Forge 失败", ex2);
			}
			finally
			{
				try
				{
					if (val != null)
					{
						val.Dispose();
					}
					if (File.Exists(_0024VB_0024Local_InstallerAddress))
					{
						File.Delete(_0024VB_0024Local_InstallerAddress);
					}
					if (Directory.Exists(_0024VB_0024Local_InstallerAddress + "_unrar\\"))
					{
						ModBase.DeleteDirectory(_0024VB_0024Local_InstallerAddress + "_unrar\\");
					}
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, "非新版方式安装 Forge 清理文件时出错");
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__37_002D1
	{
		public List<ModMinecraft.McLibToken> _0024VB_0024Local_Libs;

		public _Closure_0024__37_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__37_002D1(_Closure_0024__37_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Libs = arg0._0024VB_0024Local_Libs;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			Task.Output = new List<ModNet.NetFile>();
			ZipArchive val = null;
			checked
			{
				try
				{
					val = new ZipArchive((Stream)new FileStream(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_InstallerAddress, (FileMode)3));
					Task.Progress = 0.2;
					JObject jObject = (JObject)ModBase.GetJson(ModBase.ReadFile(val.GetEntry("install_profile.json").Open()));
					JObject content = (JObject)ModBase.GetJson(ModBase.ReadFile(val.GetEntry("version.json").Open()));
					jObject.Merge(content);
					if (Conversions.ToBoolean((object)(Operators.CompareString(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit, "1.16.5", false) == 0 && Conversions.ToBoolean(ModBase.Setup.Get("ToolFixAuthlib")))))
					{
						jObject = JObject.Parse(jObject.ToString().Replace("2.1.28/authlib-2.1.28.jar", "2.3.31/authlib-2.3.31.jar").Replace("com.mojang:authlib:2.1.28", "com.mojang:authlib:2.3.31")
							.Replace("ad54da276bf59983d02d5ed16fc14541354c71fd", "bbd00ca33b052f73a6312254780fc580d2da3535")
							.Replace("76328", "87662"));
					}
					_0024VB_0024Local_Libs = ModMinecraft.McLibListGetWithJson(jObject, KeepSameNameDifferentVersionResult: true);
					if (jObject["data"] != null && jObject["data"]["MOJMAPS"] != null)
					{
						Task.Progress = 0.4;
						JObject obj = (JObject)ModBase.GetJson(ModNet.NetGetCodeByLoader(ModDownload.DlSourceLauncherOrMetaGet(Conversions.ToString(ModDownload.DlClientListGet(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit))), 45000, IsJson: true));
						string text = ModBase.BeforeFirst(jObject["data"]["MOJMAPS"]["client"].ToString().Trim("[]".ToCharArray()), "@");
						string localPath = ModMinecraft.McLibGet(text).Replace(".jar", "-mappings." + jObject["data"]["MOJMAPS"]["client"].ToString().Trim("[]".ToCharArray()).Split("@", (StringSplitOptions)0)[1]);
						JToken jToken = obj["downloads"]["client_mappings"];
						_0024VB_0024Local_Libs.Add(new ModMinecraft.McLibToken
						{
							IsNatives = false,
							LocalPath = localPath,
							OriginalName = text,
							Url = (string?)jToken["url"],
							Size = (long)jToken["size"],
							SHA1 = (string?)jToken["sha1"]
						});
						ModBase.Log(string.Format("[Download] 需要下载 Mappings：{0} (SHA1: {1})", (object)jToken["url"], (object)jToken["sha1"]));
					}
					Task.Progress = 0.8;
					int num = _0024VB_0024Local_Libs.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if (ModBase.EndsWithF(_0024VB_0024Local_Libs[i].LocalPath, $"{_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName.ToLower()}-{_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit}-{_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderVersion}.jar") || ModBase.EndsWithF(_0024VB_0024Local_Libs[i].LocalPath, $"{_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName.ToLower()}-{_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit}-{_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderVersion}-client.jar"))
						{
							ModBase.Log($"[Download] 已从待下载 {_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName} 支持库中移除：" + _0024VB_0024Local_Libs[i].LocalPath, ModBase.LogLevel.Debug);
							_0024VB_0024Local_Libs.RemoveAt(i);
							break;
						}
					}
					Task.Output = ModMinecraft.McLibFixFromLibToken(_0024VB_0024Local_Libs);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					throw new System.Exception(string.Format("获取{0} 支持库列表失败", (object)((Operators.CompareString(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ForgeType, "Forge", false) == 0) ? "新版 Forge" : (" " + _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ForgeType))), ex2);
				}
				finally
				{
					if (val != null)
					{
						val.Dispose();
					}
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__3(ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			if (_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_IsCustomFolder)
			{
				System.Collections.Generic.IEnumerator<ModMinecraft.McLibToken> enumerator = default(System.Collections.Generic.IEnumerator<ModMinecraft.McLibToken>);
				try
				{
					enumerator = _0024VB_0024Local_Libs.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ModMinecraft.McLibToken current = enumerator.Current;
						string text = current.LocalPath.Replace(ModMinecraft.PathMcFolder, _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder);
						if (!File.Exists(text))
						{
							Directory.CreateDirectory(Path.GetDirectoryName(text));
							ModBase.CopyFile(current.LocalPath, text);
						}
						if (ModBase.ModeDebug)
						{
							ModBase.Log($"[Download] 复制的 {_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName} 支持库文件：" + current.LocalPath);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
			}
			if (_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ClientDownloadLoader == null)
			{
				return;
			}
			List<ModLoader.LoaderBase> val = Enumerable.ToList<ModLoader.LoaderBase>(Enumerable.Where<ModLoader.LoaderBase>(Enumerable.Where<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ClientDownloadLoader.GetLoaderList(), (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => Operators.CompareString(l.Name, "下载原版支持库文件", false) == 0 || Operators.CompareString(l.Name, "下载原版 Json 文件", false) == 0)), (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => l.State != ModBase.LoadState.Finished)));
			if (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val))
			{
				ModBase.Log($"[Download] {_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName} 安装正在等待原版文件下载完成");
			}
			while (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val) && !Task.IsAborted)
			{
				val = Enumerable.ToList<ModLoader.LoaderBase>(Enumerable.Where<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val, (_Closure_0024__._0024I37_002D6 == null) ? (_Closure_0024__._0024I37_002D6 = [SpecialName] (ModLoader.LoaderBase l) => l.State != ModBase.LoadState.Finished) : _Closure_0024__._0024I37_002D6));
				Thread.Sleep(50);
			}
			if (Task.IsAborted || !_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_IsCustomFolder)
			{
				return;
			}
			object vanillaSyncLock = VanillaSyncLock;
			ObjectFlowControl.CheckForSyncLockOnValueType(vanillaSyncLock);
			bool flag = false;
			try
			{
				Monitor.Enter(vanillaSyncLock, ref flag);
				string folderNameFromPath = ModBase.GetFolderNameFromPath(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ClientFolder);
				Directory.CreateDirectory(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder + "versions\\" + _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit);
				if (!File.Exists(string.Concat(new string[] { _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder, "versions\\", _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit, "\\", _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit, ".json" })))
				{
					ModBase.CopyFile(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ClientFolder + folderNameFromPath + ".json", string.Concat(new string[] { _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder, "versions\\", _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit, "\\", _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit, ".json" }));
				}
				if (!File.Exists(string.Concat(new string[] { _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder, "versions\\", _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit, "\\", _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit, ".jar" })))
				{
					ModBase.CopyFile(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ClientFolder + folderNameFromPath + ".jar", string.Concat(new string[] { _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder, "versions\\", _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit, "\\", _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit, ".jar" }));
				}
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(vanillaSyncLock);
				}
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__37_002D2
	{
		public List<string> _0024VB_0024Local_OldList;

		public _Closure_0024__37_002D2(_Closure_0024__37_002D2 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_OldList = arg0._0024VB_0024Local_OldList;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__9(DirectoryInfo i)
		{
			return _0024VB_0024Local_OldList.Contains(((FileSystemInfo)i).FullName);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__5_002D0
	{
		public string _0024VB_0024Local_VersionFolder;

		public _Closure_0024__5_002D0(_Closure_0024__5_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_VersionFolder = arg0._0024VB_0024Local_VersionFolder;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
		{
			Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(_0024VB_0024Local_VersionFolder));
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__89_002D0
	{
		public string _0024VB_0024Local_InstanceFolder;

		public string _0024VB_0024Local_OptiFineFolder;

		public bool _0024VB_0024Local_OptiFineAsMod;

		public string _0024VB_0024Local_ForgeFolder;

		public McInstallRequest _0024VB_0024Local_Request;

		public string _0024VB_0024Local_NeoForgeFolder;

		public string _0024VB_0024Local_CleanroomFolder;

		public string _0024VB_0024Local_FabricFolder;

		public string _0024VB_0024Local_QuiltFolder;

		public string _0024VB_0024Local_LabyModFolder;

		public string _0024VB_0024Local_LiteLoaderFolder;

		public string _0024VB_0024Local_LegacyFabricFolder;

		public string _0024VB_0024Local_TempMcFolder;

		public string _0024VB_0024Local_ModsTempFolder;

		public bool _0024VB_0024Local_Modable;

		[SpecialName]
		internal void _Lambda_0024__R30(ModLoader.LoaderTask<int, int> a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			ModBase.WriteFile(_0024VB_0024Local_InstanceFolder + ".pclignore", "用于临时地在 PCL 的实例列表中屏蔽此实例。");
		}

		[SpecialName]
		internal void _Lambda_0024__1(ModLoader.LoaderTask<string, string> Task)
		{
			MergeJson(_0024VB_0024Local_InstanceFolder, _0024VB_0024Local_InstanceFolder, _0024VB_0024Local_OptiFineFolder, _0024VB_0024Local_OptiFineAsMod, _0024VB_0024Local_ForgeFolder, _0024VB_0024Local_Request.ForgeVersion, _0024VB_0024Local_NeoForgeFolder, _0024VB_0024Local_Request.NeoForgeVersion, _0024VB_0024Local_CleanroomFolder, _0024VB_0024Local_Request.CleanroomVersion, _0024VB_0024Local_FabricFolder, _0024VB_0024Local_QuiltFolder, _0024VB_0024Local_LabyModFolder, _0024VB_0024Local_Request.LabyModChannel, _0024VB_0024Local_LiteLoaderFolder, _0024VB_0024Local_Request.MMCPackInfo, _0024VB_0024Local_LegacyFabricFolder);
			Task.Progress = 0.2;
			if (Directory.Exists(_0024VB_0024Local_TempMcFolder + "libraries"))
			{
				ModBase.CopyDirectory(_0024VB_0024Local_TempMcFolder + "libraries", ModMinecraft.PathMcFolder + "libraries");
			}
			Task.Progress = 0.8;
			string text = new ModMinecraft.McInstance(_0024VB_0024Local_InstanceFolder).PathIndie + "mods\\";
			if (Directory.Exists(_0024VB_0024Local_ModsTempFolder))
			{
				ModBase.CopyDirectory(_0024VB_0024Local_ModsTempFolder, text);
			}
			else if (_0024VB_0024Local_Modable)
			{
				Directory.CreateDirectory(text);
				ModBase.Log("[Download] 自动创建 Mod 文件夹：" + text);
			}
			string text2 = new ModMinecraft.McInstance(_0024VB_0024Local_InstanceFolder).PathIndie + "resourcepacks\\";
			Directory.CreateDirectory(text2);
			ModBase.Log("[Download] 自动创建资源包文件夹：" + text2);
		}

		[SpecialName]
		internal void _Lambda_0024__2(ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task)
		{
			Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(_0024VB_0024Local_InstanceFolder));
		}

		[SpecialName]
		internal void _Lambda_0024__R31(ModLoader.LoaderTask<int, int> a0)
		{
			_Lambda_0024__3();
		}

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			File.Delete(_0024VB_0024Local_InstanceFolder + ".pclignore");
		}
	}

	private static object InstallSyncLock = RuntimeHelpers.GetObjectValue(new object());

	private static object VanillaSyncLock = RuntimeHelpers.GetObjectValue(new object());

	public static int McVersionHighest = -1;

	private const string McDownloadClientLibName = "下载原版支持库文件";

	private const string McDownloadClientJsonName = "下载原版 Json 文件";

	private static bool IsForgeRecommendedRefreshed = false;

	public static ModLoader.LoaderCombo<string> McDownloadClient(ModNet.NetPreDownloadBehaviour Behaviour, string Id, string JsonUrl = null)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		ModLoader.LoaderCombo<string> result;
		try
		{
			string text = ModMinecraft.PathMcFolder + "versions\\" + Id + "\\";
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModLoader.LoaderBase current = enumerator.Current;
					if (Operators.CompareString(current.Name, $"Minecraft {Id} 下载", false) != 0)
					{
						continue;
					}
					if (Behaviour == ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading)
					{
						result = (ModLoader.LoaderCombo<string>)current;
					}
					else
					{
						ModMain.Hint("该实例正在下载中！", ModMain.HintType.Critical);
						result = (ModLoader.LoaderCombo<string>)current;
					}
					goto end_IL_0000;
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			if (Behaviour == ModNet.NetPreDownloadBehaviour.IgnoreCheck || !File.Exists(text + Id + ".json") || !File.Exists(text + Id + ".jar"))
			{
				goto IL_011f;
			}
			if (Behaviour == ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading)
			{
				result = null;
			}
			else
			{
				if (ModMain.MyMsgBox("实例 " + Id + " 已存在，是否重新下载？\r\n这会覆盖实例的 Json 与 Jar 文件，但不会影响版本隔离的文件。", "实例已存在", "继续", "取消") == 1)
				{
					File.Delete(text + Id + ".jar");
					File.Delete(text + Id + ".json");
					goto IL_011f;
				}
				result = null;
			}
			goto end_IL_0000;
			IL_011f:
			ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("Minecraft " + Id + " 下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadClientLoader(Id, JsonUrl));
			loaderCombo.OnStateChanged = McInstallState;
			loaderCombo.Start(text);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
			result = loaderCombo;
			end_IL_0000:;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "开始 Minecraft 下载失败", ModBase.LogLevel.Feedback);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void McDownloadClientCore(string Id, string JsonUrl, ModNet.NetPreDownloadBehaviour Behaviour)
	{
		try
		{
			_Closure_0024__5_002D0 arg = default(_Closure_0024__5_002D0);
			_Closure_0024__5_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__5_002D0(null);
			CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder = SystemDialogs.SelectFolder();
			if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder.Contains("\\"))
			{
				return;
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + Id + "\\";
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, $"Minecraft {Id} 下载", false) == 0)
					{
						if (Behaviour != ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading)
						{
							ModMain.Hint("该实例正在下载中！", ModMain.HintType.Critical);
						}
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
			List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
			obj.Add(new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(JsonUrl), CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + Id + ".json", new ModBase.FileChecker(-1L, -1L, null, CanUseExistsFile: false, IsJson: true)));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载实例 Json 文件", obj)
			{
				ProgressWeight = 2.0
			});
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析核心 Jar 文件下载地址", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder));
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 0.5,
				Show = false
			});
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载核心 Jar 文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 5.0
			});
			ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("Minecraft " + Id + " 下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
			loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
			loaderCombo.Start(Id);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "开始 Minecraft 下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static List<ModLoader.LoaderBase> McDownloadClientLoader(string Id, string JsonUrl = null, string VersionName = null)
	{
		VersionName = VersionName ?? Id;
		string text = ModMinecraft.PathMcFolder + "versions\\" + VersionName + "\\";
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		if (JsonUrl == null)
		{
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("获取原版 Json 文件下载地址", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				string original = Conversions.ToString(ModDownload.DlClientListGet(Id));
				List<ModNet.NetFile> obj3 = new List<ModNet.NetFile>();
				obj3.Add(new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(original), text + VersionName + ".json"));
				Task.Output = obj3;
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 2.0,
				Show = false
			});
		}
		List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
		obj.Add(new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(JsonUrl ?? ""), text + VersionName + ".json", new ModBase.FileChecker(-1L, -1L, null, CanUseExistsFile: false, IsJson: true)));
		val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载原版 Json 文件", obj)
		{
			ProgressWeight = 3.0
		});
		List<ModLoader.LoaderBase> val2 = new List<ModLoader.LoaderBase>();
		val2.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析原版支持库文件（副加载器）", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
		{
			Thread.Sleep(50);
			ModBase.Log("[Download] 开始分析原版支持库文件：" + text);
			if (Conversions.ToBoolean((object)(Operators.CompareString(Id, "1.16.5", false) == 0 && Conversions.ToBoolean(ModBase.Setup.Get("ToolFixAuthlib")))))
			{
				try
				{
					string text2 = ModBase.ReadFile(text + VersionName + ".json");
					text2 = text2.Replace("2.1.28/authlib-2.1.28.jar", "2.3.31/authlib-2.3.31.jar").Replace("com.mojang:authlib:2.1.28", "com.mojang:authlib:2.3.31").Replace("ad54da276bf59983d02d5ed16fc14541354c71fd", "bbd00ca33b052f73a6312254780fc580d2da3535")
						.Replace("76328", "87662");
					ModBase.WriteFile(text + VersionName + ".json", text2);
				}
				catch (System.Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					System.Exception ex6 = ex5;
					ModBase.Log("[Download] 替换 Authlib 版本失败: " + ex6.Message);
					ProjectData.ClearProjectError();
				}
			}
			Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(text));
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 1.0,
			Show = false
		});
		val2.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载原版支持库文件（副加载器）", new List<ModNet.NetFile>())
		{
			ProgressWeight = 13.0,
			Show = false
		});
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载原版支持库文件", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2)
		{
			Block = false,
			ProgressWeight = 14.0
		});
		List<ModLoader.LoaderBase> val3 = new List<ModLoader.LoaderBase>();
		val3.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析资源文件索引地址（副加载器）", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
		{
			try
			{
				ModMinecraft.McInstance version = new ModMinecraft.McInstance(text);
				List<ModNet.NetFile> obj2 = new List<ModNet.NetFile>();
				obj2.Add(ModDownload.DlClientAssetIndexGet(version));
				Task.Output = obj2;
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				throw new System.Exception("分析资源文件索引地址失败", ex2);
			}
			try
			{
				JObject jObject = (JObject)ModBase.GetJson(ModBase.ReadFile(text + VersionName + ".json"));
				jObject.Add("clientVersion", Id);
				ModBase.WriteFile(text + VersionName + ".json", jObject.ToString());
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				throw new System.Exception("添加客户端版本失败", ex4);
			}
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 1.0,
			Show = false
		});
		val3.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载资源文件索引（副加载器）", new List<ModNet.NetFile>())
		{
			ProgressWeight = 3.0,
			Show = false
		});
		val3.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析所需资源文件（副加载器）", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
		{
			ModLoader.LoaderTask<string, List<ModNet.NetFile>> loaderTask = Task;
			ModMinecraft.McInstance instance = new ModMinecraft.McInstance(text);
			ModLoader.LoaderBase ProgressFeed = Task;
			List<ModNet.NetFile> output = ModMinecraft.McAssetsFixList(instance, CheckHash: true, ref ProgressFeed);
			Task = (ModLoader.LoaderTask<string, List<ModNet.NetFile>>)ProgressFeed;
			loaderTask.Output = output;
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 3.0,
			Show = false
		});
		val3.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载资源文件（副加载器）", new List<ModNet.NetFile>())
		{
			ProgressWeight = 14.0,
			Show = false
		});
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载原版资源文件", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val3)
		{
			Block = false,
			ProgressWeight = 21.0
		});
		return val;
	}

	public static MyListItem McDownloadListItem(JObject Entry, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
	{
		JToken jToken = Entry["type"];
		string logo = (((string?)jToken == "release") ? (ModBase.PathImage + "Blocks/Grass.png") : (((string?)jToken == "snapshot" || (string?)jToken == "pending") ? (ModBase.PathImage + "Blocks/CommandBlock.png") : ((!((string?)jToken == "special")) ? (ModBase.PathImage + "Blocks/CobbleStone.png") : (ModBase.PathImage + "Blocks/GoldBlock.png"))));
		string text = McFormatter.FormatVersion(Entry["id"].ToString()).Replace("_", " ");
		MyListItem obj = new MyListItem
		{
			Logo = logo
		};
		((UIElement)obj).SnapsToDevicePixels = true;
		obj.Title = text;
		((FrameworkElement)obj).Height = 42.0;
		obj.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)obj).Tag = Entry;
		MyListItem myListItem = obj;
		if (Entry["lore"] == null)
		{
			if (text != (string?)Entry["id"])
			{
				myListItem.Info = Entry["releaseTime"].Value<System.DateTime>().ToString("yyyy'/'MM'/'dd HH':'mm") + " | " + Entry["id"].ToString();
			}
			else
			{
				myListItem.Info = Entry["releaseTime"].Value<System.DateTime>().ToString("yyyy'/'MM'/'dd HH':'mm");
			}
		}
		else if (text != (string?)Entry["id"])
		{
			myListItem.Info = Entry["lore"].ToString() + " | " + Entry["id"].ToString();
		}
		else
		{
			myListItem.Info = Entry["lore"].ToString();
		}
		if (Entry["url"].ToString().Contains("unlisted-versions-of-minecraft"))
		{
			myListItem.Tags = "UVMC特供下载";
		}
		myListItem.Click += OnClick;
		if (IsSaveOnly)
		{
			myListItem.ContentHandler = McDownloadSaveMenuBuild;
		}
		else
		{
			myListItem.ContentHandler = McDownloadMenuBuild;
		}
		return myListItem;
	}

	private static void McDownloadSaveMenuBuild(object sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj).ToolTip = "更新日志";
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			McDownloadMenuLog(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		MyIconButton obj2 = new MyIconButton
		{
			LogoScale = 1.0,
			Logo = "M224 160a64 64 0 0 0-64 64v576a64 64 0 0 0 64 64h576a64 64 0 0 0 64-64V224a64 64 0 0 0-64-64H224z m0 384h576v256H224v-256z m192 96v64h320v-64H416z m-128 0v64h64v-64H288zM224 224h576v256H224V224z m192 96v64h320v-64H416z m-128 0v64h64v-64H288z"
		};
		((FrameworkElement)obj2).ToolTip = "下载服务端";
		MyIconButton myIconButton2 = obj2;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton2, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton2, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton2, 2.0);
		myIconButton2.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			McDownloadMenuSaveServer(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		NewLateBinding.LateSet(sender, (System.Type)null, "Buttons", new object[] { new MyIconButton[] { myIconButton2, myIconButton } }, (string[])null, (System.Type[])null);
	}

	private static void McDownloadMenuBuild(object sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z"
		};
		((FrameworkElement)obj).ToolTip = "另存为";
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			McDownloadMenuSave(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		MyIconButton obj2 = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj2).ToolTip = "更新日志";
		MyIconButton myIconButton2 = obj2;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton2, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton2, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton2, 2.0);
		myIconButton2.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			McDownloadMenuLog(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		MyIconButton obj3 = new MyIconButton
		{
			LogoScale = 1.0,
			Logo = "M224 160a64 64 0 0 0-64 64v576a64 64 0 0 0 64 64h576a64 64 0 0 0 64-64V224a64 64 0 0 0-64-64H224z m0 384h576v256H224v-256z m192 96v64h320v-64H416z m-128 0v64h64v-64H288zM224 224h576v256H224V224z m192 96v64h320v-64H416z m-128 0v64h64v-64H288z"
		};
		((FrameworkElement)obj3).ToolTip = "下载服务端";
		MyIconButton myIconButton3 = obj3;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton3, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton3, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton3, 2.0);
		myIconButton3.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			McDownloadMenuSaveServer(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		NewLateBinding.LateSet(sender, (System.Type)null, "Buttons", new object[] { new MyIconButton[] { myIconButton, myIconButton2, myIconButton3 } }, (string[])null, (System.Type[])null);
	}

	private static void McDownloadMenuLog(object sender, RoutedEventArgs e)
	{
		JToken versionJson = ((NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) != null) ? ((JToken)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) == null) ? ((JToken)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((JToken)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
		McUpdateLogShow(versionJson);
	}

	private static void McDownloadMenuSaveServer(object sender, RoutedEventArgs e)
	{
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		MyListItem myListItem = ((sender is MyListItem) ? ((MyListItem)sender) : ((!(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null) is MyListItem)) ? ((MyListItem)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((MyListItem)NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
		try
		{
			_Closure_0024__13_002D0 arg = default(_Closure_0024__13_002D0);
			_Closure_0024__13_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__13_002D0(null);
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Id = myListItem.Title;
			string original = NewLateBinding.LateIndexGet(((FrameworkElement)myListItem).Tag, new object[] { "url" }, (string[])null).ToString();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder = SystemDialogs.SelectFolder();
			if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder.Contains("\\"))
			{
				return;
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_Id + "\\";
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, $"Minecraft {CS_0024_003C_003E8__locals0._0024VB_0024Local_Id} 服务端下载", false) == 0)
					{
						ModMain.Hint("该服务端正在下载中！", ModMain.HintType.Critical);
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
			List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
			obj.Add(new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(original), CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_Id + ".json", new ModBase.FileChecker(-1L, -1L, null, CanUseExistsFile: false, IsJson: true)));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载实例 JSON 文件", obj)
			{
				ProgressWeight = 2.0
			});
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("构建服务端", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				//IL_0081: Unknown result type (might be due to invalid IL or missing references)
				ModMinecraft.McInstance mcInstance = new ModMinecraft.McInstance(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder);
				if (mcInstance.JsonObject["downloads"] == null || mcInstance.JsonObject["downloads"]["server"] == null || mcInstance.JsonObject["downloads"]["server"]["url"] == null)
				{
					File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_Id + ".json");
					if (!Enumerable.Any<FileSystemInfo>((System.Collections.Generic.IEnumerable<FileSystemInfo>)new DirectoryInfo(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder).GetFileSystemInfos()))
					{
						Directory.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder);
					}
					Task.Output = new List<ModNet.NetFile>();
					ModMain.Hint($"Mojang 没有给 Minecraft {CS_0024_003C_003E8__locals0._0024VB_0024Local_Id} 提供官方服务端下载，没法下，撤退！", ModMain.HintType.Critical);
					Thread.Sleep(2000);
					Task.Abort();
				}
				else
				{
					string original2 = (string?)mcInstance.JsonObject["downloads"]["server"]["url"];
					ModBase.FileChecker check = new ModBase.FileChecker(1024L, (long)(mcInstance.JsonObject["downloads"]["server"]["size"] ?? ((JToken)(-1))), (string?)mcInstance.JsonObject["downloads"]["server"]["sha1"]);
					List<ModNet.NetFile> obj2 = new List<ModNet.NetFile>();
					obj2.Add(new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(original2), CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_Id + "-server.jar", check));
					Task.Output = obj2;
					string text = $"@echo off\ntitle {CS_0024_003C_003E8__locals0._0024VB_0024Local_Id} 原版服务端\necho 如果服务端立即停止，请右键编辑该脚本，将下一行开头的 java 替换为适合该 Minecraft 版本的完整 java.exe 的路径。\necho 你可以在 PCL 的 [设置 → 启动选项] 中查看已安装的 java，所需的 java.exe 一般在其中的 bin 文件夹下。\necho ------------------------------\necho 如果提示 \"You need to agree to the EULA in order to run the server\"，请打开 eula.txt，按说明阅读并同意 Minecraft EULA 后，将该文件最后一行中的 eula=false 改为 eula=true。\necho ------------------------------\n\"java\" -server -XX:+UseG1GC -Xmx4096M -Xms1024M -XX:+UseCompressedOops -jar {CS_0024_003C_003E8__locals0._0024VB_0024Local_Id}-server.jar nogui\necho ----------------------\necho 服务端已停止。\npause";
					ModBase.WriteFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + "Launch Server.bat", text, Append: false, Encoding.Default.Equals((object)Encoding.UTF8) ? Encoding.UTF8 : Encoding.GetEncoding("GB18030"));
					File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_Id + ".json");
				}
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 0.5,
				Show = false
			});
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载服务端文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 5.0
			});
			ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("Minecraft " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Id + " 服务端下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
			loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
			loaderCombo.Start(CS_0024_003C_003E8__locals0._0024VB_0024Local_Id);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "开始 Minecraft 服务端下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public static void McDownloadMenuSave(object sender, RoutedEventArgs e)
	{
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		MyListItem myListItem = ((sender is MyListItem) ? ((MyListItem)sender) : ((!(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null) is MyListItem)) ? ((MyListItem)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((MyListItem)NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
		try
		{
			_Closure_0024__14_002D0 arg = default(_Closure_0024__14_002D0);
			_Closure_0024__14_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__14_002D0(null);
			string title = myListItem.Title;
			string original = NewLateBinding.LateIndexGet(((FrameworkElement)myListItem).Tag, new object[] { "url" }, (string[])null).ToString();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder = SystemDialogs.SelectFolder();
			if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder.Contains("\\"))
			{
				return;
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + title + "\\";
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, $"Minecraft {title} 下载", false) == 0)
					{
						ModMain.Hint("该实例正在下载中！", ModMain.HintType.Critical);
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
			List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
			obj.Add(new ModNet.NetFile(ModDownload.DlSourceLauncherOrMetaGet(original), CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + title + ".json", new ModBase.FileChecker(-1L, -1L, null, CanUseExistsFile: false, IsJson: true)));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载实例 JSON 文件", obj)
			{
				ProgressWeight = 2.0
			});
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析核心 JAR 文件下载地址", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				List<ModNet.NetFile> obj2 = new List<ModNet.NetFile>();
				obj2.Add(ModDownload.DlClientJarGet(new ModMinecraft.McInstance(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder), ReturnNothingOnFileUseable: false));
				Task.Output = obj2;
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 0.5,
				Show = false
			});
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载核心 JAR 文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 5.0
			});
			ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("Minecraft " + title + " 下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
			loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
			loaderCombo.Start(title);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "开始 Minecraft 下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public static void McUpdateLogShow(JToken VersionJson)
	{
		string wikiUrlSuffix = McFormatter.GetWikiUrlSuffix(VersionJson["id"].ToString());
		ModBase.OpenWebsite("https://zh.minecraft.wiki/w/Special:Search?search=" + wikiUrlSuffix);
	}

	public static void McDownloadOptiFine(ModDownload.DlOptiFineListEntry DownloadInfo)
	{
		try
		{
			string nameVersion = DownloadInfo.NameVersion;
			string text = ModMinecraft.PathMcFolder + "versions\\" + nameVersion + "\\";
			if (!(ModBase.Val(DownloadInfo.Inherit.Split(".", (StringSplitOptions)0)[1]) >= 14.0))
			{
				string.Concat(new string[5]
				{
					ModMinecraft.PathMcFolder,
					"libraries\\optifine\\OptiFine\\",
					DownloadInfo.NameFile.Replace("OptiFine_", "").Replace(".jar", "").Replace("preview_", ""),
					"\\",
					DownloadInfo.NameFile.Replace("OptiFine_", "OptiFine-").Replace("preview_", "")
				});
			}
			else
			{
				string.Concat(new string[5]
				{
					ModBase.PathTemp,
					"Cache\\Code\\",
					DownloadInfo.NameVersion,
					"_",
					Conversions.ToString(ModBase.GetUuid())
				});
			}
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, $"OptiFine {DownloadInfo.NameDisplay} 下载", false) == 0)
					{
						ModMain.Hint("该实例正在下载中！", ModMain.HintType.Critical);
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			if (File.Exists(text + nameVersion + ".json"))
			{
				if (ModMain.MyMsgBox("实例 " + nameVersion + " 已存在，是否重新下载？\r\n这会覆盖实例的 Json 和 Jar 文件，但不会影响版本隔离的文件。", "实例已存在", "继续", "取消") != 1)
				{
					return;
				}
				File.Delete(text + nameVersion + ".jar");
				File.Delete(text + nameVersion + ".json");
			}
			ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("OptiFine " + DownloadInfo.NameDisplay + " 下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadOptiFineLoader(DownloadInfo));
			loaderCombo.OnStateChanged = McInstallState;
			loaderCombo.Start(text);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "开始 OptiFine 下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static void McDownloadOptiFineSave(ModDownload.DlOptiFineListEntry DownloadInfo)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			_ = DownloadInfo.NameVersion;
			string text = SystemDialogs.SelectSaveFile("选择保存位置", DownloadInfo.NameFile, "OptiFine Jar (*.jar)|*.jar");
			if (!text.Contains("\\"))
			{
				return;
			}
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, $"OptiFine {DownloadInfo.NameDisplay} 下载", false) == 0)
					{
						ModMain.Hint("该实例正在下载中！", ModMain.HintType.Critical);
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			ModLoader.LoaderCombo<ModDownload.DlOptiFineListEntry> loaderCombo = new ModLoader.LoaderCombo<ModDownload.DlOptiFineListEntry>("OptiFine " + DownloadInfo.NameDisplay + " 下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadOptiFineSaveLoader(DownloadInfo, text));
			loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
			loaderCombo.Start(DownloadInfo);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "开始 OptiFine 下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static void McDownloadOptiFineInstall(string BaseMcFolderHome, string Target, ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task, bool UseJavaWrapper)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Expected O, but got Unknown
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		_Closure_0024__18_002D2 arg = new _Closure_0024__18_002D2(null);
		arg._0024VB_0024Local_Task = Task;
		object javaLock = ModJava.JavaLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(javaLock);
		bool flag = false;
		JavaInfo javaInfo;
		try
		{
			Monitor.Enter(javaLock, ref flag);
			javaInfo = ModJava.JavaSelect("已取消安装。", new Version(1, 8, 0, 0));
			if (javaInfo == null)
			{
				if (!ModJava.JavaDownloadConfirm("Java 8 或更高版本"))
				{
					throw new System.Exception("由于未找到 Java，已取消安装。");
				}
				ModLoader.LoaderCombo<int> loaderCombo = ModJava.JavaFixLoaders(17);
				try
				{
					loaderCombo.Start(17, IsForceRestart: true);
					while (loaderCombo.State == ModBase.LoadState.Loading && !arg._0024VB_0024Local_Task.IsAborted)
					{
						Thread.Sleep(10);
					}
				}
				finally
				{
					loaderCombo.Abort();
				}
				javaInfo = ModJava.JavaSelect("已取消安装。", new Version(1, 8, 0, 0));
				if (arg._0024VB_0024Local_Task.IsAborted)
				{
					return;
				}
				if (javaInfo == null)
				{
					throw new System.Exception("由于未找到 Java，已取消安装。");
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
		string text = ((!Conversions.ToBoolean((object)(UseJavaWrapper && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("LaunchAdvanceDisableJLW")))))) ? $"-Duser.home=\"{BaseMcFolderHome.TrimEnd('\\')}\" -cp \"{Target}\" optifine.Installer" : string.Format("-Doolloo.jlw.tmpdir=\"{0}\" -Duser.home=\"{1}\" -cp \"{2}\" -jar \"{3}\" optifine.Installer", new object[4]
		{
			ModBase.PathPure.TrimEnd('\\'),
			BaseMcFolderHome.TrimEnd('\\'),
			Target,
			ModLaunch.ExtractJavaWrapper()
		}));
		if (javaInfo.JavaMajorVersion >= 9)
		{
			text = "--add-exports cpw.mods.bootstraplauncher/cpw.mods.bootstraplauncher=ALL-UNNAMED " + text;
		}
		object installSyncLock = InstallSyncLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(installSyncLock);
		bool flag2 = false;
		try
		{
			Monitor.Enter(installSyncLock, ref flag2);
			_Closure_0024__18_002D1 arg2 = new _Closure_0024__18_002D1(null);
			arg2._0024VB_0024NonLocal__0024VB_0024Closure_2 = arg;
			ProcessStartInfo val = new ProcessStartInfo
			{
				FileName = javaInfo.JavawExePath,
				Arguments = text,
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardError = true,
				RedirectStandardOutput = true,
				WorkingDirectory = ModBase.ShortenPath(BaseMcFolderHome)
			};
			if (val.EnvironmentVariables.ContainsKey("appdata"))
			{
				val.EnvironmentVariables["appdata"] = BaseMcFolderHome;
			}
			else
			{
				val.EnvironmentVariables.Add("appdata", BaseMcFolderHome);
			}
			ModBase.Log("[Download] 开始安装 OptiFine：" + Target);
			arg2._0024VB_0024Local_TotalLength = 0;
			arg2._0024VB_0024Local_process = new Process
			{
				StartInfo = val
			};
			arg2._0024VB_0024Local_LastResult = "";
			_Closure_0024__18_002D0 arg3 = new _Closure_0024__18_002D0(null);
			arg3._0024VB_0024NonLocal__0024VB_0024Closure_3 = arg2;
			arg3._0024VB_0024Local_outputWaitHandle = new AutoResetEvent(false);
			try
			{
				_Closure_0024__18_002D3 arg4 = default(_Closure_0024__18_002D3);
				_Closure_0024__18_002D3 CS_0024_003C_003E8__locals0 = new _Closure_0024__18_002D3(null);
				CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4 = arg3;
				CS_0024_003C_003E8__locals0._0024VB_0024Local_errorWaitHandle = new AutoResetEvent(false);
				try
				{
					CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.OutputDataReceived += (DataReceivedEventHandler)([SpecialName] (object a0, DataReceivedEventArgs a1) =>
					{
						CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._Lambda_0024__0(RuntimeHelpers.GetObjectValue(a0), a1);
					});
					CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.ErrorDataReceived += (DataReceivedEventHandler)([SpecialName] (object a0, DataReceivedEventArgs a1) =>
					{
						CS_0024_003C_003E8__locals0._Lambda_0024__1(RuntimeHelpers.GetObjectValue(a0), a1);
					});
					CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Start();
					CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.BeginOutputReadLine();
					CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.BeginErrorReadLine();
					while (!CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.HasExited)
					{
						Thread.Sleep(10);
					}
					((WaitHandle)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024Local_outputWaitHandle).WaitOne(10000);
					((WaitHandle)CS_0024_003C_003E8__locals0._0024VB_0024Local_errorWaitHandle).WaitOne(10000);
					((Component)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process).Dispose();
					if (CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_TotalLength < 1000 || CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResult.Contains("at "))
					{
						throw new System.Exception("安装器运行出错，末行为 " + CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResult);
					}
				}
				finally
				{
					if (CS_0024_003C_003E8__locals0._0024VB_0024Local_errorWaitHandle != null)
					{
						((System.IDisposable)CS_0024_003C_003E8__locals0._0024VB_0024Local_errorWaitHandle).Dispose();
					}
				}
			}
			finally
			{
				if (arg3._0024VB_0024Local_outputWaitHandle != null)
				{
					((System.IDisposable)arg3._0024VB_0024Local_outputWaitHandle).Dispose();
				}
			}
		}
		finally
		{
			if (flag2)
			{
				Monitor.Exit(installSyncLock);
			}
		}
	}

	private static List<ModLoader.LoaderBase> McDownloadOptiFineLoader(ModDownload.DlOptiFineListEntry DownloadInfo, string McFolder = null, ModLoader.LoaderCombo<string> ClientDownloadLoader = null, string ClientFolder = null, bool FixLibrary = true)
	{
		_Closure_0024__19_002D0 arg = default(_Closure_0024__19_002D0);
		_Closure_0024__19_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__19_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo = DownloadInfo;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder = McFolder;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientDownloadLoader = ClientDownloadLoader;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientFolder = ClientFolder;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder ?? ModMinecraft.PathMcFolder;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_IsCustomFolder = Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder, ModMinecraft.PathMcFolder, false) != 0;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Id = CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.NameVersion;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Id + "\\";
		bool flag = CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit.Contains("w") || ModBase.Val(CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit.Split(".", (StringSplitOptions)0)[1]) >= 14.0;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Target = (flag ? $"{ModMain.RequestTaskTempFolder()}OptiFine.jar" : string.Format("{0}libraries\\optifine\\OptiFine\\{1}\\{2}", (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder, (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.NameFile.Replace("OptiFine_", "").Replace(".jar", "").Replace("preview_", ""), (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.NameFile.Replace("OptiFine_", "OptiFine-").Replace("preview_", "")));
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("获取 OptiFine 主文件下载地址", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
		{
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientDownloadLoader == null)
			{
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_IsCustomFolder)
				{
					throw new System.Exception("如果没有指定原版下载器，则不能指定 MC 安装文件夹");
				}
				CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientDownloadLoader = McDownloadClient(ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading, CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit);
			}
			Task.Progress = 0.1;
			List<string> val3 = new List<string>();
			string text5 = CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit;
			if (Operators.CompareString(text5, "1.8", false) == 0 || Operators.CompareString(text5, "1.9", false) == 0)
			{
				text5 += ".0";
			}
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.IsPreview)
			{
				val3.Add("https://bmclapi2.bangbang93.com/optifine/" + text5 + "/HD_U_" + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.NameDisplay.Replace(CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit + " ", "").Replace(" ", "/"));
			}
			else
			{
				val3.Add("https://bmclapi2.bangbang93.com/optifine/" + text5 + "/HD_U/" + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.NameDisplay.Replace(CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit + " ", ""));
			}
			try
			{
				string str = HttpRequestBuilder.Create("https://optifine.net/adloadx?f=" + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.NameFile, HttpMethod.Get).WithHeader("Accept", "text/html").WithHeader("Accept-Language", "en-US,en;q=0.5")
					.WithHeader("X-Requested-With", "XMLHttpRequest")
					.SendAsync(throwIfNotSuccess: true)
					.Result.AsStringContent();
				Task.Progress = 0.8;
				val3.Add("https://optifine.net/" + ModBase.RegexSearch(str, "downloadx\\?f=[^\"']+", (RegexOptions)0)[0]);
				ModBase.Log("[Download] OptiFine " + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.NameDisplay + " 官方下载地址：" + Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)val3));
			}
			catch (System.Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				System.Exception ex8 = ex7;
				ModBase.Log(ex8, "获取 OptiFine " + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.NameDisplay + " 官方下载地址失败");
				ProjectData.ClearProjectError();
			}
			List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
			obj.Add(new ModNet.NetFile(val3.ToArray(), CS_0024_003C_003E8__locals0._0024VB_0024Local_Target, new ModBase.FileChecker(307200L, -1L)));
			Task.Output = obj;
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 8.0
		});
		val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 OptiFine 主文件", new List<ModNet.NetFile>())
		{
			ProgressWeight = 8.0
		});
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>("等待原版下载", [SpecialName] (ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task) =>
		{
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientDownloadLoader != null)
			{
				List<ModLoader.LoaderBase> val2 = Enumerable.ToList<ModLoader.LoaderBase>(Enumerable.Where<ModLoader.LoaderBase>(Enumerable.Where<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientDownloadLoader.GetLoaderList(), (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => Operators.CompareString(l.Name, "下载原版支持库文件", false) == 0 || Operators.CompareString(l.Name, "下载原版 Json 文件", false) == 0)), (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => l.State != ModBase.LoadState.Finished)));
				if (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2))
				{
					ModBase.Log("[Download] OptiFine 安装正在等待原版文件下载完成");
				}
				while (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2) && !Task.IsAborted)
				{
					val2 = Enumerable.ToList<ModLoader.LoaderBase>(Enumerable.Where<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2, (_Closure_0024__._0024I19_002D4 == null) ? (_Closure_0024__._0024I19_002D4 = [SpecialName] (ModLoader.LoaderBase l) => l.State != ModBase.LoadState.Finished) : _Closure_0024__._0024I19_002D4));
					Thread.Sleep(50);
				}
				if (!Task.IsAborted && CS_0024_003C_003E8__locals0._0024VB_0024Local_IsCustomFolder)
				{
					object vanillaSyncLock = VanillaSyncLock;
					ObjectFlowControl.CheckForSyncLockOnValueType(vanillaSyncLock);
					bool flag3 = false;
					try
					{
						Monitor.Enter(vanillaSyncLock, ref flag3);
						string folderNameFromPath = ModBase.GetFolderNameFromPath(CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientFolder);
						Directory.CreateDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit);
						if (!File.Exists(string.Concat(new string[6]
						{
							CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder,
							"versions\\",
							CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
							"\\",
							CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
							".json"
						})))
						{
							ModBase.CopyFile($"{CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientFolder}{folderNameFromPath}.json", $"{CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit}\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit}.json");
						}
						if (!File.Exists(string.Concat(new string[6]
						{
							CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder,
							"versions\\",
							CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
							"\\",
							CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
							".jar"
						})))
						{
							ModBase.CopyFile($"{CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientFolder}{folderNameFromPath}.jar", $"{CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit}\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit}.jar");
						}
					}
					finally
					{
						if (flag3)
						{
							Monitor.Exit(vanillaSyncLock);
						}
					}
				}
			}
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 0.1,
			Show = false
		});
		if (flag)
		{
			ModBase.Log("[Download] 检测为新版 OptiFine：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit);
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>("安装 OptiFine（方式 A）", [SpecialName] (ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task) =>
			{
				string text3 = ModMain.RequestTaskTempFolder();
				string text4 = text3 + ".minecraft\\";
				try
				{
					if (Directory.Exists(text4 + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit))
					{
						ModBase.DeleteDirectory(text4 + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit);
					}
					Directory.CreateDirectory(text4 + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit + "\\");
					ModMinecraft.McFolderLauncherProfilesJsonCreate(text4);
					ModBase.CopyFile(string.Concat(new string[6]
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder,
						"versions\\",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
						"\\",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
						".json"
					}), string.Concat(new string[6]
					{
						text4,
						"versions\\",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
						"\\",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
						".json"
					}));
					ModBase.CopyFile(string.Concat(new string[6]
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder,
						"versions\\",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
						"\\",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
						".jar"
					}), string.Concat(new string[6]
					{
						text4,
						"versions\\",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
						"\\",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
						".jar"
					}));
					Task.Progress = 0.06;
					bool flag2 = ModBase.IsUtf8CodePage();
					while (true)
					{
						try
						{
							McDownloadOptiFineInstall(text3, CS_0024_003C_003E8__locals0._0024VB_0024Local_Target, Task, flag2);
						}
						catch (System.Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							System.Exception ex4 = ex3;
							if (flag2)
							{
								throw new System.Exception("运行 OptiFine 安装器失败", ex4);
							}
							ModBase.Log(ex4, "不使用 JavaWrapper 安装 OptiFine 失败，将使用 JavaWrapper 并重试");
							flag2 = true;
							ProjectData.ClearProjectError();
							continue;
						}
						break;
					}
					Task.Progress = 0.96;
					File.Delete(text4 + "launcher_profiles.json");
					ModBase.CopyDirectory(text4, CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder);
					Task.Progress = 0.98;
					File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_Target);
					ModBase.DeleteDirectory(text3);
				}
				catch (System.Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					System.Exception ex6 = ex5;
					throw new System.Exception("安装 OptiFine（方式 A）失败", ex6);
				}
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 8.0
			});
		}
		else
		{
			ModBase.Log("[Download] 检测为旧版 OptiFine：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit);
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>("安装 OptiFine（方式 B）", [SpecialName] (ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task) =>
			{
				try
				{
					Directory.CreateDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder);
					Task.Progress = 0.1;
					if (File.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_Id + ".jar"))
					{
						File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_Id + ".jar");
					}
					ModBase.CopyFile(string.Concat(new string[6]
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder,
						"versions\\",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
						"\\",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
						".jar"
					}), CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_Id + ".jar");
					Task.Progress = 0.7;
					ModMinecraft.McInstance mcInstance = new ModMinecraft.McInstance(CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit);
					string text = string.Concat(new string[11]
					{
						"{\n    \"id\": \"",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_Id,
						"\",\n    \"inheritsFrom\": \"",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit,
						"\",\n    \"time\": \"",
						(Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.ReleaseTime, "", false) == 0) ? mcInstance.ReleaseTime.ToString("yyyy'-'MM'-'dd") : CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.ReleaseTime.Replace("/", "-"),
						"T23:33:33+08:00\",\n    \"releaseTime\": \"",
						(Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.ReleaseTime, "", false) == 0) ? mcInstance.ReleaseTime.ToString("yyyy'-'MM'-'dd") : CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.ReleaseTime.Replace("/", "-"),
						"T23:33:33+08:00\",\n    \"type\": \"release\",\n    \"libraries\": [\n        {\"name\": \"optifine:OptiFine:",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.NameFile.Replace("OptiFine_", "").Replace(".jar", "").Replace("preview_", ""),
						"\"},\n        {\"name\": \"net.minecraft:launchwrapper:1.12\"}\n    ],\n    \"mainClass\": \"net.minecraft.launchwrapper.Launch\","
					});
					Task.Progress = 0.8;
					ModBase.WriteFile(Text: (!mcInstance.IsOldJson) ? (text + "\n    \"minimumLauncherVersion\": \"21\",\n    \"arguments\": {\n        \"game\": [\n            \"--tweakClass\",\n            \"optifine.OptiFineTweaker\"\n        ]\n    }\n}") : (text + "\n    \"minimumLauncherVersion\": 18,\n    \"minecraftArguments\": \"" + mcInstance.JsonObject["minecraftArguments"].ToString() + "  --tweakClass optifine.OptiFineTweaker\"\n}"), FilePath: CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_Id + ".json");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					throw new System.Exception("安装 OptiFine（方式 B）失败", ex2);
				}
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 1.0
			});
		}
		if (FixLibrary)
		{
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析 OptiFine 支持库文件", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder));
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 1.0,
				Show = false
			});
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 OptiFine 支持库文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 4.0
			});
		}
		return val;
	}

	private static List<ModLoader.LoaderBase> McDownloadOptiFineSaveLoader(ModDownload.DlOptiFineListEntry DownloadInfo, string TargetFolder)
	{
		List<ModLoader.LoaderBase> obj = new List<ModLoader.LoaderBase>();
		obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<ModDownload.DlOptiFineListEntry, List<ModNet.NetFile>>("获取 OptiFine 下载地址", [SpecialName] (ModLoader.LoaderTask<ModDownload.DlOptiFineListEntry, List<ModNet.NetFile>> Task) =>
		{
			List<string> val = new List<string>();
			string text = DownloadInfo.Inherit;
			if (Operators.CompareString(text, "1.8", false) == 0 || Operators.CompareString(text, "1.9", false) == 0)
			{
				text += ".0";
			}
			if (DownloadInfo.IsPreview)
			{
				val.Add("https://bmclapi2.bangbang93.com/optifine/" + text + "/HD_U_" + DownloadInfo.NameDisplay.Replace(DownloadInfo.Inherit + " ", "").Replace(" ", "/"));
			}
			else
			{
				val.Add("https://bmclapi2.bangbang93.com/optifine/" + text + "/HD_U/" + DownloadInfo.NameDisplay.Replace(DownloadInfo.Inherit + " ", ""));
			}
			try
			{
				string str = HttpRequestBuilder.Create("https://optifine.net/adloadx?f=" + DownloadInfo.NameFile, HttpMethod.Get).WithHeader("Accept", "text/html").WithHeader("Accept-Language", "en-US,en;q=0.5")
					.WithHeader("X-Requested-With", "XMLHttpRequest")
					.SendAsync(throwIfNotSuccess: true)
					.Result.AsStringContent();
				Task.Progress = 0.8;
				val.Add("https://optifine.net/" + ModBase.RegexSearch(str, "downloadx\\?f=[^\"']+", (RegexOptions)0)[0]);
				ModBase.Log("[Download] OptiFine " + DownloadInfo.NameDisplay + " 官方下载地址：" + Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)val));
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "获取 OptiFine " + DownloadInfo.NameDisplay + " 官方下载地址失败");
				ProjectData.ClearProjectError();
			}
			Task.Progress = 0.9;
			List<ModNet.NetFile> obj2 = new List<ModNet.NetFile>();
			obj2.Add(new ModNet.NetFile(val.ToArray(), TargetFolder, new ModBase.FileChecker(65536L, -1L)));
			Task.Output = obj2;
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 6.0
		});
		obj.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 OptiFine 主文件", new List<ModNet.NetFile>())
		{
			ProgressWeight = 10.0,
			Block = true
		});
		return obj;
	}

	public static MyListItem OptiFineDownloadListItem(ModDownload.DlOptiFineListEntry Entry, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
	{
		MyListItem obj = new MyListItem
		{
			Title = Entry.NameDisplay
		};
		((UIElement)obj).SnapsToDevicePixels = true;
		((FrameworkElement)obj).Height = 42.0;
		obj.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)obj).Tag = Entry;
		obj.Info = (Entry.IsPreview ? "测试版" : "正式版") + ((Operators.CompareString(Entry.ReleaseTime, "", false) == 0) ? "" : ("，发布于 " + Entry.ReleaseTime)) + ((Entry.RequiredForgeVersion == null) ? "，不兼容 Forge" : ((Operators.CompareString(Entry.RequiredForgeVersion, "", false) == 0) ? "" : ("，兼容 Forge " + Entry.RequiredForgeVersion)));
		obj.Logo = ModBase.PathImage + "Blocks/GrassPath.png";
		MyListItem myListItem = obj;
		myListItem.Click += OnClick;
		if (IsSaveOnly)
		{
			myListItem.ContentHandler = OptiFineSaveContMenuBuild;
		}
		else
		{
			myListItem.ContentHandler = OptiFineContMenuBuild;
		}
		return myListItem;
	}

	private static void OptiFineSaveContMenuBuild(object sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj).ToolTip = "更新日志";
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			OptiFineLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		NewLateBinding.LateSet(sender, (System.Type)null, "Buttons", new object[] { new MyIconButton[] { myIconButton } }, (string[])null, (System.Type[])null);
	}

	private static void OptiFineContMenuBuild(object sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z"
		};
		((FrameworkElement)obj).ToolTip = "另存为";
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			OptiFineSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		MyIconButton obj2 = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj2).ToolTip = "更新日志";
		MyIconButton myIconButton2 = obj2;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton2, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton2, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton2, 2.0);
		myIconButton2.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			OptiFineLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		NewLateBinding.LateSet(sender, (System.Type)null, "Buttons", new object[] { new MyIconButton[] { myIconButton, myIconButton2 } }, (string[])null, (System.Type[])null);
	}

	private static void OptiFineLog_Click(object sender, RoutedEventArgs e)
	{
		ModDownload.DlOptiFineListEntry dlOptiFineListEntry = ((NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) != null) ? ((ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) == null) ? ((ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
		ModBase.OpenWebsite("https://optifine.net/changelog?f=" + dlOptiFineListEntry.NameFile);
	}

	public static void OptiFineSave_Click(object sender, RoutedEventArgs e)
	{
		ModDownload.DlOptiFineListEntry downloadInfo = ((NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) != null) ? ((ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) == null) ? ((ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((ModDownload.DlOptiFineListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
		McDownloadOptiFineSave(downloadInfo);
	}

	public static void McDownloadLiteLoader(ModDownload.DlLiteLoaderListEntry DownloadInfo)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string inherit = DownloadInfo.Inherit;
			_ = ModBase.PathTemp + "Download\\" + inherit + "-Liteloader.jar";
			string text = DownloadInfo.Inherit + "-LiteLoader";
			string text2 = ModMinecraft.PathMcFolder + "versions\\" + text + "\\";
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, $"LiteLoader {inherit} 下载", false) == 0)
					{
						ModMain.Hint("该实例正在下载中！", ModMain.HintType.Critical);
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			if (File.Exists(text2 + text + ".json"))
			{
				if (ModMain.MyMsgBox("实例 " + text + " 已存在，是否重新下载？\r\n这会覆盖实例的 Json 和 Jar 文件，但不会影响版本隔离的文件。", "实例已存在", "继续", "取消") != 1)
				{
					return;
				}
				File.Delete(text2 + text + ".jar");
				File.Delete(text2 + text + ".json");
			}
			ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("LiteLoader " + inherit + " 下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadLiteLoaderLoader(DownloadInfo));
			loaderCombo.OnStateChanged = McInstallState;
			loaderCombo.Start(text2);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "开始 LiteLoader 下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static void McDownloadLiteLoaderSave(ModDownload.DlLiteLoaderListEntry DownloadInfo)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string inherit = DownloadInfo.Inherit;
			string text = SystemDialogs.SelectSaveFile("选择保存位置", DownloadInfo.FileName.Replace("-SNAPSHOT", ""), "LiteLoader 安装器 (*.jar)|*.jar");
			if (!text.Contains("\\"))
			{
				return;
			}
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, $"LiteLoader {inherit} 下载", false) == 0)
					{
						ModMain.Hint("该实例正在下载中！", ModMain.HintType.Critical);
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
			List<string> val2 = new List<string>();
			if (DownloadInfo.IsLegacy)
			{
				switch (DownloadInfo.Inherit)
				{
				case "1.7.10":
					val2.Add("https://dl.liteloader.com/redist/1.7.10/liteloader-installer-1.7.10-04.jar");
					break;
				case "1.7.2":
					val2.Add("https://dl.liteloader.com/redist/1.7.2/liteloader-installer-1.7.2-04.jar");
					break;
				case "1.6.4":
					val2.Add("https://dl.liteloader.com/redist/1.6.4/liteloader-installer-1.6.4-01.jar");
					break;
				case "1.6.2":
					val2.Add("https://dl.liteloader.com/redist/1.6.2/liteloader-installer-1.6.2-04.jar");
					break;
				case "1.5.2":
					val2.Add("https://dl.liteloader.com/redist/1.5.2/liteloader-installer-1.5.2-01.jar");
					break;
				default:
					throw new NotSupportedException("未知的 Minecraft 版本（" + DownloadInfo.Inherit + "）");
				}
			}
			else
			{
				val2.Add(string.Concat(new string[5]
				{
					"http://jenkins.liteloader.com/job/LiteLoaderInstaller%20",
					DownloadInfo.Inherit,
					"/lastSuccessfulBuild/artifact/",
					(Operators.CompareString(DownloadInfo.Inherit, "1.8", false) == 0) ? "ant/dist/" : "build/libs/",
					DownloadInfo.FileName
				}));
			}
			List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
			obj.Add(new ModNet.NetFile(val2.ToArray(), text, new ModBase.FileChecker(1048576L, -1L)));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载主文件", obj)
			{
				ProgressWeight = 15.0
			});
			ModLoader.LoaderCombo<ModDownload.DlLiteLoaderListEntry> loaderCombo = new ModLoader.LoaderCombo<ModDownload.DlLiteLoaderListEntry>("LiteLoader " + inherit + " 安装器下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
			loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
			loaderCombo.Start(DownloadInfo);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "开始 LiteLoader 安装器下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static List<ModLoader.LoaderBase> McDownloadLiteLoaderLoader(ModDownload.DlLiteLoaderListEntry DownloadInfo, string McFolder = null, ModLoader.LoaderCombo<string> ClientDownloadLoader = null, bool FixLibrary = true)
	{
		_Closure_0024__28_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__28_002D0();
		CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo = DownloadInfo;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientDownloadLoader = ClientDownloadLoader;
		McFolder = McFolder ?? ModMinecraft.PathMcFolder;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_IsCustomFolder = Operators.CompareString(McFolder, ModMinecraft.PathMcFolder, false) != 0;
		string inherit = CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit;
		_ = ModBase.PathTemp + "Download\\" + inherit + "-Liteloader.jar";
		CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionName = CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit + "-LiteLoader";
		CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder = McFolder + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionName + "\\";
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientDownloadLoader == null)
		{
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, string>("启动 LiteLoader 依赖实例下载", [SpecialName] (ModLoader.LoaderTask<string, string> a0) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__0();
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 0.2,
				Show = false,
				Block = false
			});
		}
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, string>("安装 LiteLoader", [SpecialName] (ModLoader.LoaderTask<string, string> Task) =>
		{
			try
			{
				Directory.CreateDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder);
				JObject jObject = new JObject
				{
					{ "id", CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionName },
					{
						"time",
						System.DateTime.ParseExact(CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.ReleaseTime, "yyyy/MM/dd HH:mm", (IFormatProvider)(object)CultureInfo.CurrentCulture)
					},
					{
						"releaseTime",
						System.DateTime.ParseExact(CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.ReleaseTime, "yyyy/MM/dd HH:mm", (IFormatProvider)(object)CultureInfo.CurrentCulture)
					},
					{ "type", "release" },
					{
						"arguments",
						(JToken)ModBase.GetJson("{\"game\":[\"--tweakClass\",\"" + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.JsonToken["tweakClass"].ToString() + "\"]}")
					},
					{
						"libraries",
						CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.JsonToken["libraries"]
					}
				};
				((JContainer)jObject["libraries"]).Add(RuntimeHelpers.GetObjectValue(ModBase.GetJson("{\"name\": \"com.mumfrey:liteloader:" + CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.JsonToken["version"].ToString() + "\",\"url\": \"https://dl.liteloader.com/versions/\"}")));
				jObject.Add("mainClass", "net.minecraft.launchwrapper.Launch");
				jObject.Add("minimumLauncherVersion", 18);
				jObject.Add("inheritsFrom", CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit);
				jObject.Add("jar", CS_0024_003C_003E8__locals0._0024VB_0024Local_DownloadInfo.Inherit);
				ModBase.WriteFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionName + ".json", jObject.ToString());
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				throw new System.Exception("安装新 LiteLoader 实例失败", ex2);
			}
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 1.0
		});
		if (FixLibrary)
		{
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析 LiteLoader 支持库文件", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder));
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 1.0,
				Show = false
			});
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 LiteLoader 支持库文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 6.0
			});
		}
		return val;
	}

	public static MyListItem LiteLoaderDownloadListItem(ModDownload.DlLiteLoaderListEntry Entry, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
	{
		MyListItem obj = new MyListItem
		{
			Title = Entry.Inherit
		};
		((UIElement)obj).SnapsToDevicePixels = true;
		((FrameworkElement)obj).Height = 42.0;
		obj.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)obj).Tag = Entry;
		obj.Info = (Entry.IsPreview ? "测试版" : "稳定版") + ((Operators.CompareString(Entry.ReleaseTime, "", false) == 0) ? "" : ("，发布于 " + Entry.ReleaseTime));
		obj.Logo = ModBase.PathImage + "Blocks/Egg.png";
		MyListItem myListItem = obj;
		myListItem.Click += OnClick;
		if (IsSaveOnly)
		{
			myListItem.ContentHandler = LiteLoaderSaveContMenuBuild;
		}
		else
		{
			myListItem.ContentHandler = LiteLoaderContMenuBuild;
		}
		return myListItem;
	}

	private static void LiteLoaderSaveContMenuBuild(MyListItem sender, EventArgs e)
	{
		if (Conversions.ToBoolean(NewLateBinding.LateGet(((FrameworkElement)sender).Tag, (System.Type)null, "IsLegacy", new object[0], (string[])null, (System.Type[])null, (bool[])null)))
		{
			sender.Buttons = new MyIconButton[0];
			return;
		}
		MyIconButton obj = new MyIconButton
		{
			Logo = "M384 128h640v128H384zM160 192m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0ZM384 448h640v128H384zM160 512m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0ZM384 768h640v128H384zM160 832m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0Z"
		};
		((FrameworkElement)obj).ToolTip = "查看全部版本";
		((FrameworkElement)obj).Tag = sender;
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			LiteLoaderAll_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		sender.Buttons = new MyIconButton[] { myIconButton };
	}

	private static void LiteLoaderContMenuBuild(MyListItem sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z"
		};
		((FrameworkElement)obj).ToolTip = "保存安装器";
		((FrameworkElement)obj).Tag = sender;
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			LiteLoaderSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		if (Conversions.ToBoolean(NewLateBinding.LateGet(((FrameworkElement)sender).Tag, (System.Type)null, "IsLegacy", new object[0], (string[])null, (System.Type[])null, (bool[])null)))
		{
			sender.Buttons = new MyIconButton[] { myIconButton };
			return;
		}
		MyIconButton obj2 = new MyIconButton
		{
			Logo = "M384 128h640v128H384zM160 192m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0ZM384 448h640v128H384zM160 512m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0ZM384 768h640v128H384zM160 832m-96 0a96 96 0 1 0 192 0 96 96 0 1 0-192 0Z"
		};
		((FrameworkElement)obj2).ToolTip = "查看全部版本";
		((FrameworkElement)obj2).Tag = sender;
		MyIconButton myIconButton2 = obj2;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton2, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton2, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton2, 2.0);
		myIconButton2.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			LiteLoaderAll_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		sender.Buttons = new MyIconButton[] { myIconButton, myIconButton2 };
	}

	private static void LiteLoaderAll_Click(object sender, RoutedEventArgs e)
	{
		ModDownload.DlLiteLoaderListEntry dlLiteLoaderListEntry = ((!(NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) is ModDownload.DlLiteLoaderListEntry)) ? ((ModDownload.DlLiteLoaderListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((ModDownload.DlLiteLoaderListEntry)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		ModBase.OpenWebsite("https://jenkins.liteloader.com/view/" + dlLiteLoaderListEntry.Inherit);
	}

	public static void LiteLoaderSave_Click(object sender, RoutedEventArgs e)
	{
		ModDownload.DlLiteLoaderListEntry downloadInfo = ((!(NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) is ModDownload.DlLiteLoaderListEntry)) ? ((ModDownload.DlLiteLoaderListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((ModDownload.DlLiteLoaderListEntry)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		McDownloadLiteLoaderSave(downloadInfo);
	}

	public static void McDownloadForgelikeSave(ModDownload.DlForgelikeEntry Info)
	{
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string text = SystemDialogs.SelectSaveFile("选择保存位置", string.Format("{0}-{1}-{2}.{3}", new object[] { Info.LoaderName, Info.Inherit, Info.VersionName, Info.FileExtension }), $"{Info.LoaderName} 安装器 (*.{Info.FileExtension})|*.{Info.FileExtension}");
			string text2 = $"{Info.LoaderName} {Info.Inherit} - {Info.VersionName}";
			if (!text.Contains("\\"))
			{
				return;
			}
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, $"{text2} 下载", false) == 0)
					{
						ModMain.Hint("该实例正在下载中！", ModMain.HintType.Critical);
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			List<ModNet.NetFile> val = new List<ModNet.NetFile>();
			if (Info.ForgeType == ModDownload.DlForgelikeEntry.ForgelikeType.NeoForge)
			{
				string text3 = ((ModDownload.DlNeoForgeListEntry)Info).UrlBase + "-installer.jar";
				val.Add(new ModNet.NetFile(new string[2]
				{
					text3.Replace("maven.neoforged.net/releases", "bmclapi2.bangbang93.com/maven"),
					text3
				}, text, new ModBase.FileChecker(65536L, -1L)));
			}
			else
			{
				ModDownload.DlForgeVersionEntry dlForgeVersionEntry = (ModDownload.DlForgeVersionEntry)Info;
				val.Add(new ModNet.NetFile(new string[2]
				{
					string.Format("https://bmclapi2.bangbang93.com/maven/net/minecraftforge/forge/{0}-{1}/forge-{2}-{3}-{4}.{5}", new object[] { dlForgeVersionEntry.Inherit, dlForgeVersionEntry.FileVersion, dlForgeVersionEntry.Inherit, dlForgeVersionEntry.FileVersion, dlForgeVersionEntry.Category, dlForgeVersionEntry.FileExtension }),
					string.Format("https://files.minecraftforge.net/maven/net/minecraftforge/forge/{0}-{1}/forge-{2}-{3}-{4}.{5}", new object[] { dlForgeVersionEntry.Inherit, dlForgeVersionEntry.FileVersion, dlForgeVersionEntry.Inherit, dlForgeVersionEntry.FileVersion, dlForgeVersionEntry.Category, dlForgeVersionEntry.FileExtension })
				}, text, new ModBase.FileChecker(65536L, -1L, dlForgeVersionEntry.Hash)));
			}
			List<ModLoader.LoaderBase> val2 = new List<ModLoader.LoaderBase>();
			val2.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载主文件", val)
			{
				ProgressWeight = 6.0
			});
			ModLoader.LoaderCombo<ModDownload.DlForgelikeEntry> loaderCombo = new ModLoader.LoaderCombo<ModDownload.DlForgelikeEntry>(text2 + " 下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2);
			loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
			loaderCombo.Start(Info);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, $"开始 {Info.LoaderName} 安装器下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static void ForgelikeInjector(string Target, ModLoader.LoaderTask<bool, bool> Task, string McFolder, bool UseJavaWrapper, string ForgeType)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected O, but got Unknown
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Expected O, but got Unknown
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		_Closure_0024__35_002D2 arg = new _Closure_0024__35_002D2(null);
		arg._0024VB_0024Local_Task = Task;
		object javaLock = ModJava.JavaLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(javaLock);
		bool flag = false;
		JavaInfo javaInfo;
		try
		{
			Monitor.Enter(javaLock, ref flag);
			javaInfo = ModJava.JavaSelect("已取消安装。", new Version(1, 8, 0, 60));
			if (javaInfo == null)
			{
				if (!ModJava.JavaDownloadConfirm("Java 8 或更高版本"))
				{
					throw new System.Exception("由于未找到 Java，已取消安装。");
				}
				ModLoader.LoaderCombo<int> loaderCombo = ModJava.JavaFixLoaders(17);
				try
				{
					loaderCombo.Start(17, IsForceRestart: true);
					while (loaderCombo.State == ModBase.LoadState.Loading && !arg._0024VB_0024Local_Task.IsAborted)
					{
						Thread.Sleep(10);
					}
				}
				finally
				{
					loaderCombo.Abort();
				}
				javaInfo = ModJava.JavaSelect("已取消安装。", new Version(1, 8, 0, 60));
				if (arg._0024VB_0024Local_Task.IsAborted)
				{
					return;
				}
				if (javaInfo == null)
				{
					throw new System.Exception("由于未找到 Java，已取消安装。");
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
		string text = ((!Conversions.ToBoolean((object)(UseJavaWrapper && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("LaunchAdvanceDisableJLW")))))) ? $"-cp \"{ModBase.PathTemp}Cache\\forge_installer.jar;{Target}\" com.bangbang93.ForgeInstaller \"{McFolder}" : string.Format("-Doolloo.jlw.tmpdir=\"{0}\" -cp \"{1}Cache\\forge_installer.jar;{2}\" -jar \"{3}\" com.bangbang93.ForgeInstaller \"{4}", new object[5]
		{
			ModBase.PathPure.TrimEnd('\\'),
			ModBase.PathTemp,
			Target,
			ModLaunch.ExtractJavaWrapper(),
			McFolder
		}));
		if (javaInfo.JavaMajorVersion >= 9)
		{
			text = "--add-exports cpw.mods.bootstraplauncher/cpw.mods.bootstraplauncher=ALL-UNNAMED " + text;
		}
		object installSyncLock = InstallSyncLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(installSyncLock);
		bool flag2 = false;
		checked
		{
			try
			{
				Monitor.Enter(installSyncLock, ref flag2);
				_Closure_0024__35_002D1 arg2 = new _Closure_0024__35_002D1(null);
				arg2._0024VB_0024NonLocal__0024VB_0024Closure_2 = arg;
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					FileName = javaInfo.JavawExePath,
					Arguments = text,
					UseShellExecute = false,
					CreateNoWindow = true,
					RedirectStandardError = true,
					RedirectStandardOutput = true
				};
				arg2._0024VB_0024Local_LoaderName = ForgeType;
				ModBase.Log($"[Download] 开始安装 {arg2._0024VB_0024Local_LoaderName}：" + text);
				arg2._0024VB_0024Local_process = new Process
				{
					StartInfo = startInfo
				};
				arg2._0024VB_0024Local_LastResults = new Queue<string>();
				_Closure_0024__35_002D0 arg3 = new _Closure_0024__35_002D0(null);
				arg3._0024VB_0024NonLocal__0024VB_0024Closure_3 = arg2;
				arg3._0024VB_0024Local_outputWaitHandle = new AutoResetEvent(false);
				try
				{
					_Closure_0024__35_002D3 arg4 = default(_Closure_0024__35_002D3);
					_Closure_0024__35_002D3 CS_0024_003C_003E8__locals0 = new _Closure_0024__35_002D3(null);
					CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4 = arg3;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_errorWaitHandle = new AutoResetEvent(false);
					try
					{
						CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.OutputDataReceived += (DataReceivedEventHandler)([SpecialName] (object a0, DataReceivedEventArgs a1) =>
						{
							CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._Lambda_0024__0(RuntimeHelpers.GetObjectValue(a0), a1);
						});
						CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.ErrorDataReceived += (DataReceivedEventHandler)([SpecialName] (object a0, DataReceivedEventArgs a1) =>
						{
							CS_0024_003C_003E8__locals0._Lambda_0024__1(RuntimeHelpers.GetObjectValue(a0), a1);
						});
						CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.Start();
						CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.BeginOutputReadLine();
						CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.BeginErrorReadLine();
						while (!CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process.HasExited)
						{
							Thread.Sleep(10);
						}
						((WaitHandle)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024Local_outputWaitHandle).WaitOne(10000);
						((WaitHandle)CS_0024_003C_003E8__locals0._0024VB_0024Local_errorWaitHandle).WaitOne(10000);
						((Component)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_process).Dispose();
						if (Enumerable.Any<string>(Enumerable.Take<string>(Enumerable.Reverse<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults), 5), (Func<string, bool>)([SpecialName] (string l) => Operators.CompareString(l, "true", false) == 0)))
						{
							return;
						}
						ModBase.Log(ModBase.Join((System.Collections.IEnumerable)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults, "\r\n"));
						string text2 = "";
						int num = Math.Max(0, CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Count - 5);
						int num2 = CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults.Count - 1;
						for (int i = num; i <= num2; i++)
						{
							text2 = text2 + "\r\n" + Enumerable.ElementAtOrDefault<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LastResults, i);
						}
						throw new System.Exception($"{CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_4._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_LoaderName} 安装器出错，日志结束部分为：" + text2);
					}
					finally
					{
						if (CS_0024_003C_003E8__locals0._0024VB_0024Local_errorWaitHandle != null)
						{
							((System.IDisposable)CS_0024_003C_003E8__locals0._0024VB_0024Local_errorWaitHandle).Dispose();
						}
					}
				}
				finally
				{
					if (arg3._0024VB_0024Local_outputWaitHandle != null)
					{
						((System.IDisposable)arg3._0024VB_0024Local_outputWaitHandle).Dispose();
					}
				}
			}
			finally
			{
				if (flag2)
				{
					Monitor.Exit(installSyncLock);
				}
			}
		}
	}

	private static void ForgelikeInjectorLine(string Content, ModLoader.LoaderTask<bool, bool> Task)
	{
		switch (Content)
		{
		case "Extracting json":
			ModBase.Log("[Installer] " + Content);
			Task.Progress = 0.07;
			goto IL_03cc;
		case "Downloading libraries":
			ModBase.Log("[Installer] " + Content);
			Task.Progress = 0.08;
			goto IL_03cc;
		case "  File exists: Checksum validated.":
			if (ModBase.ModeDebug)
			{
				ModBase.Log("[Installer] " + Content);
			}
			Task.Progress += 0.003;
			goto IL_03cc;
		case "Building Processors":
			Task.Progress = 0.18;
			goto IL_03cc;
		case "Task: DOWNLOAD_MOJMAPS":
			Task.Progress = 0.2;
			goto IL_03cc;
		case "Task: MERGE_MAPPING":
			Task.Progress = 0.3;
			goto IL_03cc;
		case "Splitting: ":
			Task.Progress = 0.35;
			goto IL_03cc;
		case "Parameter Annotations":
			Task.Progress = 0.4;
			goto IL_03cc;
		case "Processing Complete":
			Task.Progress = 0.5;
			goto IL_03cc;
		case "log: null":
			Task.Progress = 0.5;
			goto IL_03cc;
		case "Sorting":
			Task.Progress = 0.65;
			goto IL_03cc;
		case "Remapping final jar":
			Task.Progress = 0.72;
			goto IL_03cc;
		case "Remapping jar... 50%":
			Task.Progress = 0.76;
			goto IL_03cc;
		case "Remapping jar... 100%":
			Task.Progress = 0.81;
			goto IL_03cc;
		case "Injecting profile":
			Task.Progress = 0.91;
			goto IL_03cc;
		default:
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log("[Installer] " + Content);
				}
				break;
			}
			IL_03cc:
			ModBase.Log("[Installer] " + Content);
			break;
		}
	}

	private static List<ModLoader.LoaderBase> McDownloadForgelikeLoader(string ForgeType, string LoaderVersion, string TargetVersion, string Inherit, ModDownload.DlForgelikeEntry Info = null, string McFolder = null, ModLoader.LoaderCombo<string> ClientDownloadLoader = null, string ClientFolder = null)
	{
		_Closure_0024__37_002D0 arg = default(_Closure_0024__37_002D0);
		_Closure_0024__37_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__37_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ForgeType = ForgeType;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion = LoaderVersion;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetVersion = TargetVersion;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Inherit = Inherit;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Info = Info;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder = McFolder;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientDownloadLoader = ClientDownloadLoader;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientFolder = ClientFolder;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder ?? ModMinecraft.PathMcFolder;
		if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_ForgeType, "NeoForge", false) == 0 && CS_0024_003C_003E8__locals0._0024VB_0024Local_Info == null)
		{
			if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_Inherit, "1.20.1", false) == 0 && !ModBase.StartsWithF(CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion, "1.20.1-"))
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Info = new ModDownload.DlNeoForgeListEntry("1.20.1-" + CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion);
			}
			else
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Info = new ModDownload.DlNeoForgeListEntry(CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion);
			}
		}
		if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_ForgeType, "Cleanroom", false) == 0 && CS_0024_003C_003E8__locals0._0024VB_0024Local_Info == null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Info = new ModDownload.DlCleanroomListEntry(CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion);
		}
		if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_ForgeType, "NeoForge", false) != 0 && PCLVerCompat.StartsWithVerF(CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion, "1.", ic: false) && CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion.Contains("-"))
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Inherit = ModBase.BeforeFirst(CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion, "-");
			CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion = ModBase.AfterLast(CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion, "-");
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName = CS_0024_003C_003E8__locals0._0024VB_0024Local_ForgeType;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_IsCustomFolder = Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder, ModMinecraft.PathMcFolder, false) != 0;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress = ModMain.RequestTaskTempFolder() + "forge_installer.jar";
		CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder = $"{CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetVersion}\\";
		_ = $"{CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName} {CS_0024_003C_003E8__locals0._0024VB_0024Local_Inherit} - {CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion}";
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		_ = $"{ModMinecraft.PathMcFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetVersion}\\";
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Info == null)
		{
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, string>($"获取 {CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName} 详细信息", [SpecialName] (ModLoader.LoaderTask<string, string> Task) =>
			{
				//IL_0047: Unknown result type (might be due to invalid IL or missing references)
				//IL_004c: Unknown result type (might be due to invalid IL or missing references)
				ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>("McDownloadForgeLoader " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Inherit, ModDownload.DlForgeVersionMain, null, (ThreadPriority)2);
				loaderTask.WaitForExit(CS_0024_003C_003E8__locals0._0024VB_0024Local_Inherit);
				Task.Progress = 0.8;
				System.Collections.Generic.IEnumerator<ModDownload.DlForgeVersionEntry> enumerator2 = default(System.Collections.Generic.IEnumerator<ModDownload.DlForgeVersionEntry>);
				try
				{
					enumerator2 = loaderTask.Output.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						ModDownload.DlForgeVersionEntry current2 = enumerator2.Current;
						if (ModMinecraft.VersionSortInteger(current2.Version.ToString(), CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion) == 0)
						{
							CS_0024_003C_003E8__locals0._0024VB_0024Local_Info = current2;
							return;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator2).Dispose();
				}
				throw new System.Exception(string.Concat(new string[5]
				{
					$"未能找到 {CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName} ",
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Inherit,
					"-",
					CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion,
					" 的详细信息！"
				}));
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 3.0
			});
		}
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>($"准备下载 {CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName}", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
		{
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientDownloadLoader == null)
			{
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_IsCustomFolder)
				{
					throw new System.Exception("如果没有指定原版下载器，则不能指定 MC 安装文件夹");
				}
				CS_0024_003C_003E8__locals0._0024VB_0024Local_ClientDownloadLoader = McDownloadClient(ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading, CS_0024_003C_003E8__locals0._0024VB_0024Local_Inherit);
			}
			List<ModNet.NetFile> val8 = new List<ModNet.NetFile>();
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Info.ForgeType == ModDownload.DlForgelikeEntry.ForgelikeType.NeoForge)
			{
				string text4 = ((ModDownload.DlNeoForgeListEntry)CS_0024_003C_003E8__locals0._0024VB_0024Local_Info).UrlBase + "-installer.jar";
				val8.Add(new ModNet.NetFile(new string[2]
				{
					text4.Replace("maven.neoforged.net/releases", "bmclapi2.bangbang93.com/maven"),
					text4
				}, CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress, new ModBase.FileChecker(65536L, -1L)));
			}
			else if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Info.ForgeType == ModDownload.DlForgelikeEntry.ForgelikeType.Cleanroom)
			{
				string text5 = ((ModDownload.DlCleanroomListEntry)CS_0024_003C_003E8__locals0._0024VB_0024Local_Info).UrlBase + "-installer.jar";
				val8.Add(new ModNet.NetFile(new string[] { text5 }, CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress, new ModBase.FileChecker(65536L, -1L)));
			}
			else
			{
				ModDownload.DlForgeVersionEntry dlForgeVersionEntry = (ModDownload.DlForgeVersionEntry)CS_0024_003C_003E8__locals0._0024VB_0024Local_Info;
				string text6 = string.Format("{0}-{1}/forge-{2}-{3}-{4}.{5}", new object[6]
				{
					dlForgeVersionEntry.Inherit.Replace("-", "_"),
					dlForgeVersionEntry.FileVersion,
					dlForgeVersionEntry.Inherit.Replace("-", "_"),
					dlForgeVersionEntry.FileVersion,
					dlForgeVersionEntry.Category,
					dlForgeVersionEntry.FileExtension
				});
				val8.Add(new ModNet.NetFile(new string[2]
				{
					$"https://bmclapi2.bangbang93.com/maven/net/minecraftforge/forge/{text6}",
					$"https://files.minecraftforge.net/maven/net/minecraftforge/forge/{text6}"
				}, CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress, new ModBase.FileChecker(65536L, -1L, dlForgeVersionEntry.Hash)));
			}
			Task.Output = val8;
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 0.5,
			Show = false
		});
		val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload($"下载 {CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName} 主文件", new List<ModNet.NetFile>())
		{
			ProgressWeight = 9.0
		});
		if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_ForgeType, "NeoForge", false) == 0 || Conversions.ToDouble(ModBase.BeforeFirst(CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion, ".")) >= 20.0)
		{
			_Closure_0024__37_002D1 arg2 = default(_Closure_0024__37_002D1);
			_Closure_0024__37_002D1 CS_0024_003C_003E8__locals1 = new _Closure_0024__37_002D1(null);
			CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals0;
			ModBase.Log(string.Format("[Download] 检测为{0}：", (object)((Operators.CompareString(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ForgeType, "Forge", false) == 0) ? "新版 Forge" : (" " + CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ForgeType))) + CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderVersion);
			CS_0024_003C_003E8__locals1._0024VB_0024Local_Libs = null;
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>($"分析 {CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName} 支持库文件", checked([SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_0023: Expected O, but got Unknown
				//IL_001e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0024: Expected O, but got Unknown
				Task.Output = new List<ModNet.NetFile>();
				ZipArchive val7 = null;
				try
				{
					val7 = new ZipArchive((Stream)new FileStream(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_InstallerAddress, (FileMode)3));
					Task.Progress = 0.2;
					JObject jObject3 = (JObject)ModBase.GetJson(ModBase.ReadFile(val7.GetEntry("install_profile.json").Open()));
					JObject content = (JObject)ModBase.GetJson(ModBase.ReadFile(val7.GetEntry("version.json").Open()));
					jObject3.Merge(content);
					if (Conversions.ToBoolean((object)(Operators.CompareString(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit, "1.16.5", false) == 0 && Conversions.ToBoolean(ModBase.Setup.Get("ToolFixAuthlib")))))
					{
						jObject3 = JObject.Parse(jObject3.ToString().Replace("2.1.28/authlib-2.1.28.jar", "2.3.31/authlib-2.3.31.jar").Replace("com.mojang:authlib:2.1.28", "com.mojang:authlib:2.3.31")
							.Replace("ad54da276bf59983d02d5ed16fc14541354c71fd", "bbd00ca33b052f73a6312254780fc580d2da3535")
							.Replace("76328", "87662"));
					}
					CS_0024_003C_003E8__locals1._0024VB_0024Local_Libs = ModMinecraft.McLibListGetWithJson(jObject3, KeepSameNameDifferentVersionResult: true);
					if (jObject3["data"] != null && jObject3["data"]["MOJMAPS"] != null)
					{
						Task.Progress = 0.4;
						JObject obj = (JObject)ModBase.GetJson(ModNet.NetGetCodeByLoader(ModDownload.DlSourceLauncherOrMetaGet(Conversions.ToString(ModDownload.DlClientListGet(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit))), 45000, IsJson: true));
						string text3 = ModBase.BeforeFirst(jObject3["data"]["MOJMAPS"]["client"].ToString().Trim("[]".ToCharArray()), "@");
						string localPath = ModMinecraft.McLibGet(text3).Replace(".jar", "-mappings." + jObject3["data"]["MOJMAPS"]["client"].ToString().Trim("[]".ToCharArray()).Split("@", (StringSplitOptions)0)[1]);
						JToken jToken = obj["downloads"]["client_mappings"];
						CS_0024_003C_003E8__locals1._0024VB_0024Local_Libs.Add(new ModMinecraft.McLibToken
						{
							IsNatives = false,
							LocalPath = localPath,
							OriginalName = text3,
							Url = (string?)jToken["url"],
							Size = (long)jToken["size"],
							SHA1 = (string?)jToken["sha1"]
						});
						ModBase.Log(string.Format("[Download] 需要下载 Mappings：{0} (SHA1: {1})", (object)jToken["url"], (object)jToken["sha1"]));
					}
					Task.Progress = 0.8;
					int num = CS_0024_003C_003E8__locals1._0024VB_0024Local_Libs.Count - 1;
					for (int j = 0; j <= num; j++)
					{
						if (ModBase.EndsWithF(CS_0024_003C_003E8__locals1._0024VB_0024Local_Libs[j].LocalPath, $"{CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName.ToLower()}-{CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit}-{CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderVersion}.jar") || ModBase.EndsWithF(CS_0024_003C_003E8__locals1._0024VB_0024Local_Libs[j].LocalPath, $"{CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName.ToLower()}-{CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit}-{CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderVersion}-client.jar"))
						{
							ModBase.Log($"[Download] 已从待下载 {CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName} 支持库中移除：" + CS_0024_003C_003E8__locals1._0024VB_0024Local_Libs[j].LocalPath, ModBase.LogLevel.Debug);
							CS_0024_003C_003E8__locals1._0024VB_0024Local_Libs.RemoveAt(j);
							break;
						}
					}
					Task.Output = ModMinecraft.McLibFixFromLibToken(CS_0024_003C_003E8__locals1._0024VB_0024Local_Libs);
				}
				catch (System.Exception ex11)
				{
					ProjectData.SetProjectError(ex11);
					System.Exception ex12 = ex11;
					throw new System.Exception(string.Format("获取{0} 支持库列表失败", (object)((Operators.CompareString(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ForgeType, "Forge", false) == 0) ? "新版 Forge" : (" " + CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ForgeType))), ex12);
				}
				finally
				{
					if (val7 != null)
					{
						val7.Dispose();
					}
				}
			}), null, (ThreadPriority)2)
			{
				ProgressWeight = 2.0
			});
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload($"下载 {CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName} 支持库文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 12.0
			});
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>($"获取 {CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName} 支持库文件", [SpecialName] (ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task) =>
			{
				//IL_0016: Unknown result type (might be due to invalid IL or missing references)
				//IL_001b: Unknown result type (might be due to invalid IL or missing references)
				if (CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_IsCustomFolder)
				{
					System.Collections.Generic.IEnumerator<ModMinecraft.McLibToken> enumerator = default(System.Collections.Generic.IEnumerator<ModMinecraft.McLibToken>);
					try
					{
						enumerator = CS_0024_003C_003E8__locals1._0024VB_0024Local_Libs.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ModMinecraft.McLibToken current = enumerator.Current;
							string text2 = current.LocalPath.Replace(ModMinecraft.PathMcFolder, CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder);
							if (!File.Exists(text2))
							{
								Directory.CreateDirectory(Path.GetDirectoryName(text2));
								ModBase.CopyFile(current.LocalPath, text2);
							}
							if (ModBase.ModeDebug)
							{
								ModBase.Log($"[Download] 复制的 {CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName} 支持库文件：" + current.LocalPath);
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator).Dispose();
					}
				}
				if (CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ClientDownloadLoader != null)
				{
					List<ModLoader.LoaderBase> val6 = Enumerable.ToList<ModLoader.LoaderBase>(Enumerable.Where<ModLoader.LoaderBase>(Enumerable.Where<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ClientDownloadLoader.GetLoaderList(), (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => Operators.CompareString(l.Name, "下载原版支持库文件", false) == 0 || Operators.CompareString(l.Name, "下载原版 Json 文件", false) == 0)), (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => l.State != ModBase.LoadState.Finished)));
					if (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val6))
					{
						ModBase.Log($"[Download] {CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName} 安装正在等待原版文件下载完成");
					}
					while (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val6) && !Task.IsAborted)
					{
						val6 = Enumerable.ToList<ModLoader.LoaderBase>(Enumerable.Where<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val6, (_Closure_0024__._0024I37_002D6 == null) ? (_Closure_0024__._0024I37_002D6 = [SpecialName] (ModLoader.LoaderBase l) => l.State != ModBase.LoadState.Finished) : _Closure_0024__._0024I37_002D6));
						Thread.Sleep(50);
					}
					if (!Task.IsAborted && CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_IsCustomFolder)
					{
						object vanillaSyncLock = VanillaSyncLock;
						ObjectFlowControl.CheckForSyncLockOnValueType(vanillaSyncLock);
						bool flag2 = false;
						try
						{
							Monitor.Enter(vanillaSyncLock, ref flag2);
							string folderNameFromPath = ModBase.GetFolderNameFromPath(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ClientFolder);
							Directory.CreateDirectory(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder + "versions\\" + CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit);
							if (!File.Exists(string.Concat(new string[6]
							{
								CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder,
								"versions\\",
								CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit,
								"\\",
								CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit,
								".json"
							})))
							{
								ModBase.CopyFile(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ClientFolder + folderNameFromPath + ".json", string.Concat(new string[6]
								{
									CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder,
									"versions\\",
									CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit,
									"\\",
									CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit,
									".json"
								}));
							}
							if (!File.Exists(string.Concat(new string[6]
							{
								CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder,
								"versions\\",
								CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit,
								"\\",
								CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit,
								".jar"
							})))
							{
								ModBase.CopyFile(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ClientFolder + folderNameFromPath + ".jar", string.Concat(new string[6]
								{
									CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder,
									"versions\\",
									CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit,
									"\\",
									CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Inherit,
									".jar"
								}));
							}
						}
						finally
						{
							if (flag2)
							{
								Monitor.Exit(vanillaSyncLock);
							}
						}
					}
				}
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 0.1,
				Show = false
			});
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<bool, bool>((Operators.CompareString(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ForgeType, "Forge", false) == 0) ? "安装 Forge（方式 A）" : ("安装 " + CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ForgeType), [SpecialName] (ModLoader.LoaderTask<bool, bool> Task) =>
			{
				//IL_0035: Unknown result type (might be due to invalid IL or missing references)
				//IL_0079: Unknown result type (might be due to invalid IL or missing references)
				//IL_0083: Expected O, but got Unknown
				//IL_007e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0084: Expected O, but got Unknown
				//IL_0195: Unknown result type (might be due to invalid IL or missing references)
				ZipArchive val3 = null;
				try
				{
					_Closure_0024__37_002D2 arg3 = default(_Closure_0024__37_002D2);
					_Closure_0024__37_002D2 CS_0024_003C_003E8__locals2 = new _Closure_0024__37_002D2(null);
					ModBase.Log("[Download] 开始进行 Forgelike 安装：" + CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_InstallerAddress);
					CS_0024_003C_003E8__locals2._0024VB_0024Local_OldList = Enumerable.ToList<string>(Enumerable.Select<DirectoryInfo, string>(new DirectoryInfo(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder + "versions\\").EnumerateDirectories(), (Func<DirectoryInfo, string>)([SpecialName] (DirectoryInfo i) => ((FileSystemInfo)i).FullName)));
					val3 = new ZipArchive((Stream)new FileStream(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_InstallerAddress, (FileMode)3));
					_ = (JObject)ModBase.GetJson(ModBase.ReadFile(val3.GetEntry("install_profile.json").Open()));
					Directory.CreateDirectory(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_VersionFolder);
					Task.Progress = 0.04;
					ModMinecraft.McFolderLauncherProfilesJsonCreate(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder);
					Task.Progress = 0.05;
					bool flag = ModBase.IsUtf8CodePage();
					while (true)
					{
						try
						{
							ModBase.WriteFile(ModBase.PathTemp + "Cache\\forge_installer.jar", ModBase.GetResourceStream("Resources/forge-installer.jar"));
							Task.Progress = 0.06;
							ForgelikeInjector(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_InstallerAddress, Task, CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder, flag, CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ForgeType);
							Task.Progress = 0.97;
						}
						catch (System.Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							System.Exception ex6 = ex5;
							if (flag)
							{
								throw new System.Exception($"运行 {CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName} 安装器失败", ex6);
							}
							ModBase.Log(ex6, $"不使用 JavaWrapper 安装 {CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName} 失败，将使用 JavaWrapper 并重试");
							flag = true;
							ProjectData.ClearProjectError();
							continue;
						}
						break;
					}
					List<DirectoryInfo> val4 = Enumerable.ToList<DirectoryInfo>(Enumerable.SkipWhile<DirectoryInfo>(new DirectoryInfo(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_McFolder + "versions\\").EnumerateDirectories(), (Func<DirectoryInfo, bool>)([SpecialName] (DirectoryInfo i) => CS_0024_003C_003E8__locals2._0024VB_0024Local_OldList.Contains(((FileSystemInfo)i).FullName))));
					if (val4.Count > 1)
					{
						val4 = Enumerable.ToList<DirectoryInfo>(Enumerable.Where<DirectoryInfo>((System.Collections.Generic.IEnumerable<DirectoryInfo>)val4, (Func<DirectoryInfo, bool>)([SpecialName] (DirectoryInfo l) => ModBase.ContainsF(l.Name, "forge", IgnoreCase: true) && Enumerable.Any<FileInfo>(l.EnumerateFiles()))));
					}
					if (val4.Count == 1)
					{
						FileInfo val5 = Enumerable.First<FileInfo>(val4[0].EnumerateFiles());
						ModBase.WriteFile(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_VersionFolder + CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_TargetVersion + ".json", ModBase.ReadFile(((FileSystemInfo)val5).FullName));
						ModBase.Log($"[Download] 已拷贝新增的实例 Json 文件：{((FileSystemInfo)val5).FullName} -> {CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_VersionFolder}{CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_TargetVersion}.json");
					}
					else if (val4.Count > 1)
					{
						ModBase.Log(string.Format("[Download] 有多个疑似的新增实例，无法确定：{0}", (object)ModBase.Join((System.Collections.IEnumerable)Enumerable.Select<DirectoryInfo, string>((System.Collections.Generic.IEnumerable<DirectoryInfo>)val4, (Func<DirectoryInfo, string>)([SpecialName] (DirectoryInfo d) => d.Name)), ";")));
					}
					else
					{
						ModBase.Log("[Download] 未找到新增的实例文件夹");
					}
				}
				catch (System.Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					System.Exception ex8 = ex7;
					throw new System.Exception($"安装新 {CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName} 实例失败", ex8);
				}
				finally
				{
					try
					{
						if (val3 != null)
						{
							val3.Dispose();
						}
						if (File.Exists(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_InstallerAddress))
						{
							File.Delete(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_InstallerAddress);
						}
					}
					catch (System.Exception ex9)
					{
						ProjectData.SetProjectError(ex9);
						System.Exception ex10 = ex9;
						ModBase.Log(ex10, $"安装 {CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_LoaderName} 清理文件时出错");
						ProjectData.ClearProjectError();
					}
				}
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 10.0
			});
		}
		else
		{
			ModBase.Log("[Download] 检测为非新版 Forge：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderVersion);
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<List<ModNet.NetFile>, bool>(string.Format("安装 {0}", (object)((Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_ForgeType, "Forge", false) == 0) ? "Forge（方式 B）" : CS_0024_003C_003E8__locals0._0024VB_0024Local_ForgeType)), [SpecialName] (ModLoader.LoaderTask<List<ModNet.NetFile>, bool> Task) =>
			{
				//IL_0009: Unknown result type (might be due to invalid IL or missing references)
				//IL_0013: Expected O, but got Unknown
				//IL_000e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0014: Expected O, but got Unknown
				ZipArchive val2 = null;
				try
				{
					val2 = new ZipArchive((Stream)new FileStream(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress, (FileMode)3));
					Task.Progress = 0.2;
					JObject jObject = (JObject)ModBase.GetJson(ModBase.ReadFile(val2.GetEntry("install_profile.json").Open()));
					Task.Progress = 0.4;
					Directory.CreateDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder);
					Task.Progress = 0.5;
					if (jObject["install"] == null)
					{
						ModBase.Log("[Download] 开始进行 Forge 安装，Legacy 方式 1：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress);
						JObject jObject2 = (JObject)ModBase.GetJson(ModBase.ReadFile(val2.GetEntry(jObject["json"].ToString().TrimStart('/')).Open()));
						jObject2["id"] = CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetVersion;
						ModBase.WriteFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetVersion + ".json", jObject2.ToString());
						Task.Progress = 0.6;
						val2.Dispose();
						ModBase.ExtractFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress, CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress + "_unrar\\");
						ModBase.CopyDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress + "_unrar\\maven\\", CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder + "libraries\\");
						ModBase.DeleteDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress + "_unrar\\");
					}
					else
					{
						ModBase.Log("[Download] 开始进行 Forge 安装，Legacy 方式 2：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress);
						string text = ModMinecraft.McLibGet((string?)jObject["install"]["path"], WithHead: true, IgnoreLiteLoader: false, CS_0024_003C_003E8__locals0._0024VB_0024Local_McFolder);
						if (File.Exists(text))
						{
							File.Delete(text);
						}
						ModBase.WriteFile(text, val2.GetEntry((string?)jObject["install"]["filePath"]).Open());
						Task.Progress = 0.9;
						jObject["versionInfo"]["id"] = CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetVersion;
						if (jObject["versionInfo"]["inheritsFrom"] == null)
						{
							((JObject)jObject["versionInfo"]).Add("inheritsFrom", CS_0024_003C_003E8__locals0._0024VB_0024Local_Inherit);
						}
						ModBase.WriteFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetVersion + ".json", jObject["versionInfo"].ToString());
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					throw new System.Exception("非新版方式安装 Forge 失败", ex2);
				}
				finally
				{
					try
					{
						if (val2 != null)
						{
							val2.Dispose();
						}
						if (File.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress))
						{
							File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress);
						}
						if (Directory.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress + "_unrar\\"))
						{
							ModBase.DeleteDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallerAddress + "_unrar\\");
						}
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						ModBase.Log(ex4, "非新版方式安装 Forge 清理文件时出错");
						ProjectData.ClearProjectError();
					}
				}
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 1.0
			});
		}
		return val;
	}

	public static void ForgeDownloadListItemPreload(StackPanel Stack, List<ModDownload.DlForgeVersionEntry> Entries, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		if (Entries.Count == 1)
		{
			return;
		}
		ModDownload.DlForgeVersionEntry dlForgeVersionEntry = null;
		if (Enumerable.Any<ModDownload.DlForgeVersionEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlForgeVersionEntry>)Entries))
		{
			dlForgeVersionEntry = Entries[0];
		}
		else
		{
			ModBase.Log("[System] 未找到可用的 Forge 版本", ModBase.LogLevel.Debug);
		}
		ModDownload.DlForgeVersionEntry dlForgeVersionEntry2 = null;
		System.Collections.Generic.IEnumerator<ModDownload.DlForgeVersionEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModDownload.DlForgeVersionEntry>);
		try
		{
			enumerator = Entries.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ModDownload.DlForgeVersionEntry current = enumerator.Current;
				if (current.IsRecommended)
				{
					dlForgeVersionEntry2 = current;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		if (dlForgeVersionEntry != null && dlForgeVersionEntry == dlForgeVersionEntry2)
		{
			dlForgeVersionEntry = null;
		}
		if (dlForgeVersionEntry2 != null)
		{
			MyListItem myListItem = ForgeDownloadListItem(dlForgeVersionEntry2, OnClick, IsSaveOnly);
			myListItem.Info = "推荐版" + ((Operators.CompareString(myListItem.Info, "", false) == 0) ? "" : ("，" + myListItem.Info));
			((Panel)Stack).Children.Add((UIElement)(object)myListItem);
		}
		if (dlForgeVersionEntry != null)
		{
			MyListItem myListItem2 = ForgeDownloadListItem(dlForgeVersionEntry, OnClick, IsSaveOnly);
			myListItem2.Info = "最新版" + ((Operators.CompareString(myListItem2.Info, "", false) == 0) ? "" : ("，" + myListItem2.Info));
			((Panel)Stack).Children.Add((UIElement)(object)myListItem2);
		}
		((Panel)Stack).Children.Add((UIElement)new TextBlock
		{
			Text = "全部版本 (" + Conversions.ToString(Entries.Count) + ")",
			HorizontalAlignment = (HorizontalAlignment)0,
			Margin = new Thickness(6.0, 13.0, 0.0, 4.0)
		});
	}

	public static MyListItem ForgeDownloadListItem(ModDownload.DlForgeVersionEntry Entry, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
	{
		MyListItem myListItem = new MyListItem();
		myListItem.Title = Entry.VersionName;
		((UIElement)myListItem).SnapsToDevicePixels = true;
		((FrameworkElement)myListItem).Height = 42.0;
		myListItem.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)myListItem).Tag = Entry;
		myListItem.Info = ModBase.Join((System.Collections.IEnumerable)Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)new string[2]
		{
			(Operators.CompareString(Entry.ReleaseTime, "", false) == 0) ? "" : ("发布于 " + Entry.ReleaseTime),
			ModBase.ModeDebug ? ("种类：" + Entry.Category) : ""
		}, (Func<string, bool>)([SpecialName] (string d) => Operators.CompareString(d, "", false) != 0)), "，");
		myListItem.Logo = ModBase.PathImage + "Blocks/Anvil.png";
		MyListItem myListItem2 = myListItem;
		myListItem2.Click += OnClick;
		if (IsSaveOnly)
		{
			myListItem2.ContentHandler = ForgeSaveContMenuBuild;
		}
		else
		{
			myListItem2.ContentHandler = ForgeContMenuBuild;
		}
		return myListItem2;
	}

	private static void ForgeContMenuBuild(MyListItem sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z"
		};
		((FrameworkElement)obj).ToolTip = "另存为";
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			ForgeSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		MyIconButton obj2 = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj2).ToolTip = "更新日志";
		MyIconButton myIconButton2 = obj2;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton2, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton2, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton2, 2.0);
		myIconButton2.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			ForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		sender.Buttons = new MyIconButton[] { myIconButton, myIconButton2 };
	}

	private static void ForgeSaveContMenuBuild(MyListItem sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj).ToolTip = "更新日志";
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			ForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		sender.Buttons = new MyIconButton[] { myIconButton };
	}

	private static void ForgeLog_Click(object sender, RoutedEventArgs e)
	{
		ModDownload.DlForgeVersionEntry dlForgeVersionEntry = ((NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) != null) ? ((ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) == null) ? ((ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
		ModBase.OpenWebsite(string.Format("https://files.minecraftforge.net/maven/net/minecraftforge/forge/{0}-{1}/forge-{2}-{3}-changelog.txt", new object[] { dlForgeVersionEntry.Inherit, dlForgeVersionEntry.VersionName, dlForgeVersionEntry.Inherit, dlForgeVersionEntry.VersionName }));
	}

	public static void ForgeSave_Click(object sender, RoutedEventArgs e)
	{
		ModDownload.DlForgeVersionEntry info = ((NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) != null) ? ((ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) == null) ? ((ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((ModDownload.DlForgeVersionEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
		McDownloadForgelikeSave(info);
	}

	public static void McDownloadForgeRecommendedRefresh()
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		if (IsForgeRecommendedRefreshed)
		{
			return;
		}
		IsForgeRecommendedRefreshed = true;
		object action;
		if (_Closure_0024__._0024I44_002D0 != null)
		{
			action = _Closure_0024__._0024I44_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				try
				{
					ModBase.Log("[Download] 刷新 Forge 推荐版本缓存开始");
					string text = ModNet.NetGetCodeByLoader("https://bmclapi2.bangbang93.com/forge/promos");
					if (text.Length < 1000)
					{
						throw new System.Exception("获取的结果过短（" + text + "）");
					}
					JContainer jContainer = (JContainer)ModBase.GetJson(text);
					List<string> val2 = new List<string>();
					System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
					try
					{
						enumerator = ((System.Collections.Generic.IEnumerable<JToken>)jContainer).GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator).MoveNext())
						{
							JObject jObject = (JObject)enumerator.Current;
							if (jObject["name"] != null && jObject["build"] != null)
							{
								string text2 = (string?)jObject["name"];
								if (ModBase.EndsWithF(text2, "-recommended"))
								{
									val2.Add("\"" + text2.Replace("-recommended", "\":\"" + jObject["build"]["version"].ToString() + "\""));
								}
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator)?.Dispose();
					}
					if (val2.Count < 5)
					{
						throw new System.Exception("获取的推荐版本数过少（" + text + "）");
					}
					string text3 = "{" + ModBase.Join((System.Collections.IEnumerable)val2, ",") + "}";
					ModBase.WriteFile(ModBase.PathTemp + "Cache\\ForgeRecommendedList.json", text3);
					ModBase.Log("[Download] 刷新 Forge 推荐版本缓存成功");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "刷新 Forge 推荐版本缓存失败");
					ProjectData.ClearProjectError();
				}
			};
			_Closure_0024__._0024I44_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInNewThread((Action)action, "ForgeRecommendedRefresh", (ThreadPriority)2);
	}

	public static string McDownloadForgeRecommendedGet(string McInstance)
	{
		string result;
		try
		{
			if (McInstance == null)
			{
				result = null;
			}
			else
			{
				string text = ModBase.ReadFile(ModBase.PathTemp + "Cache\\ForgeRecommendedList.json");
				if (text == null || Operators.CompareString(text, "", false) == 0)
				{
					ModBase.Log("[Download] 没有 Forge 推荐版本缓存文件");
					result = null;
				}
				else
				{
					JObject jObject = (JObject)ModBase.GetJson(text);
					result = ((jObject != null && (McInstance ?? "null").Contains(".") && jObject.ContainsKey(McInstance)) ? (jObject[McInstance] ?? ((JToken)"")).ToString() : null);
				}
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "获取 Forge 推荐版本失败（" + (McInstance ?? "null") + "）", ModBase.LogLevel.Feedback);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void NeoForgeDownloadListItemPreload(StackPanel Stack, List<ModDownload.DlNeoForgeListEntry> Entries, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		if (Entries.Count == 1)
		{
			return;
		}
		ModDownload.DlNeoForgeListEntry dlNeoForgeListEntry = null;
		ModDownload.DlNeoForgeListEntry dlNeoForgeListEntry2 = null;
		if (Enumerable.Any<ModDownload.DlNeoForgeListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlNeoForgeListEntry>)Entries))
		{
			System.Collections.Generic.IEnumerator<ModDownload.DlNeoForgeListEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModDownload.DlNeoForgeListEntry>);
			try
			{
				enumerator = Enumerable.ToList<ModDownload.DlNeoForgeListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlNeoForgeListEntry>)Entries).GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModDownload.DlNeoForgeListEntry current = enumerator.Current;
					if (current.IsBeta)
					{
						if (dlNeoForgeListEntry2 == null)
						{
							dlNeoForgeListEntry2 = current;
						}
						continue;
					}
					dlNeoForgeListEntry = current;
					break;
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		else
		{
			ModBase.Log("[System] 未找到可用的 NeoForge 版本", ModBase.LogLevel.Debug);
		}
		if (dlNeoForgeListEntry != null)
		{
			MyListItem myListItem = NeoForgeDownloadListItem(dlNeoForgeListEntry, OnClick, IsSaveOnly);
			myListItem.Info = ((Operators.CompareString(myListItem.Info, "", false) == 0) ? "最新稳定版" : ("最新" + myListItem.Info));
			((Panel)Stack).Children.Add((UIElement)(object)myListItem);
		}
		if (dlNeoForgeListEntry2 != null)
		{
			MyListItem myListItem2 = NeoForgeDownloadListItem(dlNeoForgeListEntry2, OnClick, IsSaveOnly);
			myListItem2.Info = ((Operators.CompareString(myListItem2.Info, "", false) == 0) ? "最新测试版" : ("最新" + myListItem2.Info));
			((Panel)Stack).Children.Add((UIElement)(object)myListItem2);
		}
		((Panel)Stack).Children.Add((UIElement)new TextBlock
		{
			Text = "全部版本 (" + Conversions.ToString(Entries.Count) + ")",
			HorizontalAlignment = (HorizontalAlignment)0,
			Margin = new Thickness(6.0, 13.0, 0.0, 4.0)
		});
	}

	public static MyListItem NeoForgeDownloadListItem(ModDownload.DlNeoForgeListEntry Info, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
	{
		MyListItem obj = new MyListItem
		{
			Title = Info.VersionName
		};
		((UIElement)obj).SnapsToDevicePixels = true;
		((FrameworkElement)obj).Height = 42.0;
		obj.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)obj).Tag = Info;
		obj.Info = (Info.IsBeta ? "测试版" : "稳定版");
		obj.Logo = ModBase.PathImage + "Blocks/NeoForge.png";
		MyListItem myListItem = obj;
		myListItem.Click += OnClick;
		if (IsSaveOnly)
		{
			myListItem.ContentHandler = NeoForgeSaveContMenuBuild;
		}
		else
		{
			myListItem.ContentHandler = NeoForgeContMenuBuild;
		}
		return myListItem;
	}

	private static void NeoForgeContMenuBuild(MyListItem sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z"
		};
		((FrameworkElement)obj).ToolTip = "另存为";
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			NeoForgeSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		MyIconButton obj2 = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj2).ToolTip = "更新日志";
		MyIconButton myIconButton2 = obj2;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton2, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton2, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton2, 2.0);
		myIconButton2.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			NeoForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		sender.Buttons = new MyIconButton[] { myIconButton, myIconButton2 };
	}

	private static void NeoForgeSaveContMenuBuild(MyListItem sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj).ToolTip = "更新日志";
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			NeoForgeLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		sender.Buttons = new MyIconButton[] { myIconButton };
	}

	private static void NeoForgeLog_Click(object sender, RoutedEventArgs e)
	{
		ModDownload.DlNeoForgeListEntry dlNeoForgeListEntry = ((NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) != null) ? ((ModDownload.DlNeoForgeListEntry)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) == null) ? ((ModDownload.DlNeoForgeListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((ModDownload.DlNeoForgeListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
		ModBase.OpenWebsite(dlNeoForgeListEntry.UrlBase + "-changelog.txt");
	}

	public static void NeoForgeSave_Click(object sender, RoutedEventArgs e)
	{
		ModDownload.DlNeoForgeListEntry info = ((NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) != null) ? ((ModDownload.DlNeoForgeListEntry)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) == null) ? ((ModDownload.DlNeoForgeListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((ModDownload.DlNeoForgeListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
		McDownloadForgelikeSave(info);
	}

	public static void CleanroomDownloadListItemPreload(StackPanel Stack, List<ModDownload.DlCleanroomListEntry> Entries, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		ModDownload.DlCleanroomListEntry dlCleanroomListEntry = null;
		if (Enumerable.Any<ModDownload.DlCleanroomListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlCleanroomListEntry>)Entries))
		{
			dlCleanroomListEntry = Entries[0];
		}
		else
		{
			ModBase.Log("[System] 未找到可用的 Cleanroom 版本", ModBase.LogLevel.Debug);
		}
		if (dlCleanroomListEntry != null)
		{
			MyListItem myListItem = CleanroomDownloadListItem(dlCleanroomListEntry, OnClick, IsSaveOnly);
			myListItem.Info = ((Operators.CompareString(myListItem.Info, "", false) == 0) ? "最新测试版" : ("最新" + myListItem.Info));
			((Panel)Stack).Children.Add((UIElement)(object)myListItem);
		}
		((Panel)Stack).Children.Add((UIElement)new TextBlock
		{
			Text = "全部版本 (" + Conversions.ToString(Entries.Count) + ")",
			HorizontalAlignment = (HorizontalAlignment)0,
			Margin = new Thickness(6.0, 13.0, 0.0, 4.0)
		});
	}

	public static MyListItem CleanroomDownloadListItem(ModDownload.DlCleanroomListEntry Info, MyListItem.ClickEventHandler OnClick, bool IsSaveOnly)
	{
		MyListItem obj = new MyListItem
		{
			Title = Info.VersionName
		};
		((UIElement)obj).SnapsToDevicePixels = true;
		((FrameworkElement)obj).Height = 42.0;
		obj.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)obj).Tag = Info;
		obj.Info = (Info.IsBeta ? "测试版" : "稳定版");
		obj.Logo = ModBase.PathImage + "Blocks/Cleanroom.png";
		MyListItem myListItem = obj;
		myListItem.Click += OnClick;
		if (IsSaveOnly)
		{
			myListItem.ContentHandler = CleanroomSaveContMenuBuild;
		}
		else
		{
			myListItem.ContentHandler = CleanroomContMenuBuild;
		}
		return myListItem;
	}

	private static void CleanroomContMenuBuild(MyListItem sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z"
		};
		((FrameworkElement)obj).ToolTip = "另存为";
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			CleanroomSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		MyIconButton obj2 = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj2).ToolTip = "更新日志";
		MyIconButton myIconButton2 = obj2;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton2, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton2, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton2, 2.0);
		myIconButton2.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			CleanroomLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		sender.Buttons = new MyIconButton[] { myIconButton, myIconButton2 };
	}

	private static void CleanroomSaveContMenuBuild(MyListItem sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj).ToolTip = "更新日志";
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			CleanroomLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		sender.Buttons = new MyIconButton[] { myIconButton };
	}

	private static void CleanroomLog_Click(object sender, RoutedEventArgs e)
	{
		ModDownload.DlCleanroomListEntry dlCleanroomListEntry = ((NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) != null) ? ((ModDownload.DlCleanroomListEntry)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) == null) ? ((ModDownload.DlCleanroomListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((ModDownload.DlCleanroomListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
		ModBase.OpenWebsite(dlCleanroomListEntry.UrlBase + "-changelog.txt");
	}

	public static void CleanroomSave_Click(object sender, RoutedEventArgs e)
	{
		ModDownload.DlCleanroomListEntry info = ((NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) != null) ? ((ModDownload.DlCleanroomListEntry)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) == null) ? ((ModDownload.DlCleanroomListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((ModDownload.DlCleanroomListEntry)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
		McDownloadForgelikeSave(info);
	}

	public static void McDownloadFabricLoaderSave(JObject DownloadInfo)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string text = DownloadInfo["url"].ToString();
			string fileNameFromPath = ModBase.GetFileNameFromPath(text);
			string fileNameFromPath2 = ModBase.GetFileNameFromPath(DownloadInfo["version"].ToString());
			string text2 = SystemDialogs.SelectSaveFile("选择保存位置", fileNameFromPath, "Fabric 安装器 (*.jar)|*.jar");
			if (!text2.Contains("\\"))
			{
				return;
			}
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, $"Fabric {fileNameFromPath2} 安装器下载", false) == 0)
					{
						ModMain.Hint("该实例正在下载中！", ModMain.HintType.Critical);
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
			List<string> val2 = new List<string>();
			val2.Add(text);
			List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
			obj.Add(new ModNet.NetFile(val2.ToArray(), text2, new ModBase.FileChecker(65536L, -1L)));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载主文件", obj)
			{
				ProgressWeight = 15.0
			});
			ModLoader.LoaderCombo<JObject> loaderCombo = new ModLoader.LoaderCombo<JObject>("Fabric " + fileNameFromPath2 + " 安装器下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
			loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
			loaderCombo.Start(DownloadInfo);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "开始 Fabric 安装器下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static List<ModLoader.LoaderBase> McDownloadFabricLoader(string FabricVersion, string MinecraftName, string McFolder = null, bool FixLibrary = true)
	{
		McFolder = McFolder ?? ModMinecraft.PathMcFolder;
		Operators.CompareString(McFolder, ModMinecraft.PathMcFolder, false);
		string text = "fabric-loader-" + FabricVersion + "-" + MinecraftName;
		string text2 = McFolder + "versions\\" + text + "\\";
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		MinecraftName = MinecraftName.Replace("∞", "infinite");
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("获取 Fabric 主文件下载地址", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
		{
			if (FixLibrary)
			{
				McDownloadClient(ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading, MinecraftName);
			}
			Task.Progress = 0.5;
			List<ModNet.NetFile> val2 = new List<ModNet.NetFile>();
			val2.Add(new ModNet.NetFile(new string[2]
			{
				string.Concat(new string[] { "https://bmclapi2.bangbang93.com/fabric-meta/v2/versions/loader/", MinecraftName, "/", FabricVersion, "/profile/json" }),
				string.Concat(new string[] { "https://meta.fabricmc.net/v2/versions/loader/", MinecraftName, "/", FabricVersion, "/profile/json" })
			}, text2 + text + ".json", new ModBase.FileChecker(-1L, -1L, null, CanUseExistsFile: true, IsJson: true)));
			Task.Output = val2;
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 0.5
		});
		val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 Fabric 主文件", new List<ModNet.NetFile>())
		{
			ProgressWeight = 2.5
		});
		if (FixLibrary)
		{
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析 Fabric 支持库文件", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(text2));
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 1.0,
				Show = false
			});
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 Fabric 支持库文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 8.0
			});
		}
		return val;
	}

	public static void McDownloadLegacyFabricLoaderSave(JObject DownloadInfo)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string text = DownloadInfo["url"].ToString();
			string fileNameFromPath = ModBase.GetFileNameFromPath(text);
			string fileNameFromPath2 = ModBase.GetFileNameFromPath(DownloadInfo["version"].ToString());
			string text2 = SystemDialogs.SelectSaveFile("选择保存位置", fileNameFromPath, "LegacyFabric 安装器 (*.jar)|*.jar");
			if (!text2.Contains("\\"))
			{
				return;
			}
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, $"Legacy Fabric {fileNameFromPath2} 安装器下载", false) == 0)
					{
						ModMain.Hint("该实例正在下载中！", ModMain.HintType.Critical);
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
			List<string> val2 = new List<string>();
			val2.Add(text);
			List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
			obj.Add(new ModNet.NetFile(val2.ToArray(), text2, new ModBase.FileChecker(65536L, -1L)));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载主文件", obj)
			{
				ProgressWeight = 15.0
			});
			ModLoader.LoaderCombo<JObject> loaderCombo = new ModLoader.LoaderCombo<JObject>("Legacy Fabric " + fileNameFromPath2 + " 安装器下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
			loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
			loaderCombo.Start(DownloadInfo);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "开始 Legacy Fabric 安装器下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static List<ModLoader.LoaderBase> McDownloadLegacyFabricLoader(string LegacyFabricVersion, string MinecraftName, string McFolder = null, bool FixLibrary = true)
	{
		McFolder = McFolder ?? ModMinecraft.PathMcFolder;
		Operators.CompareString(McFolder, ModMinecraft.PathMcFolder, false);
		string text = "legacy-fabric-loader-" + LegacyFabricVersion + "-" + MinecraftName;
		string text2 = McFolder + "versions\\" + text + "\\";
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("获取 Legacy Fabric 主文件下载地址", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
		{
			if (FixLibrary)
			{
				McDownloadClient(ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading, MinecraftName);
			}
			Task.Progress = 0.5;
			List<ModNet.NetFile> val2 = new List<ModNet.NetFile>();
			val2.Add(new ModNet.NetFile(new string[] { string.Concat(new string[] { "https://meta.legacyfabric.net/v2/versions/loader/", MinecraftName, "/", LegacyFabricVersion, "/profile/json" }) }, text2 + text + ".json", new ModBase.FileChecker(-1L, -1L, null, CanUseExistsFile: true, IsJson: true)));
			Task.Output = val2;
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 0.5
		});
		val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 Legacy Fabric 主文件", new List<ModNet.NetFile>())
		{
			ProgressWeight = 2.5
		});
		if (FixLibrary)
		{
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析 Legacy Fabric 支持库文件", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(text2));
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 1.0,
				Show = false
			});
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 Legacy Fabric 支持库文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 8.0
			});
		}
		return val;
	}

	public static MyListItem FabricDownloadListItem(JObject Entry, MyListItem.ClickEventHandler OnClick)
	{
		MyListItem obj = new MyListItem
		{
			Title = Entry["version"].ToString().Replace("+build", "")
		};
		((UIElement)obj).SnapsToDevicePixels = true;
		((FrameworkElement)obj).Height = 42.0;
		obj.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)obj).Tag = Entry;
		obj.Info = (Entry["stable"].ToObject<bool>() ? "稳定版" : "测试版");
		obj.Logo = ModBase.PathImage + "Blocks/Fabric.png";
		obj.Click += OnClick;
		obj.ContentHandler = FabricContMenuBuild;
		return obj;
	}

	private static void FabricContMenuBuild(object sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj).ToolTip = "更新日志";
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			FabricLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		NewLateBinding.LateSet(sender, (System.Type)null, "Buttons", new object[] { new MyIconButton[] { myIconButton } }, (string[])null, (System.Type[])null);
	}

	private static void FabricLog_Click(object sender, RoutedEventArgs e)
	{
		ModBase.OpenWebsite("https://fabricmc.net/blog");
	}

	public static MyListItem FabricApiDownloadListItem(ModComp.CompFile Entry, MyListItem.ClickEventHandler OnClick)
	{
		MyListItem obj = new MyListItem
		{
			Title = ModBase.BeforeFirst(Entry.DisplayName.Split("]", (StringSplitOptions)0)[1].Replace("Fabric API ", "").Replace(" build ", "."), "+").Trim()
		};
		((UIElement)obj).SnapsToDevicePixels = true;
		((FrameworkElement)obj).Height = 42.0;
		obj.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)obj).Tag = Entry;
		obj.Info = Entry.StatusDescription + "，发布于 " + Entry.ReleaseDate.ToString("yyyy'/'MM'/'dd HH':'mm");
		obj.Logo = ModBase.PathImage + "Blocks/Fabric.png";
		obj.Click += OnClick;
		return obj;
	}

	public static MyListItem OptiFabricDownloadListItem(ModComp.CompFile Entry, MyListItem.ClickEventHandler OnClick)
	{
		MyListItem obj = new MyListItem
		{
			Title = Entry.DisplayName.ToLower().Replace("optifabric-", "").Replace(".jar", "")
				.Trim()
				.TrimStart('v')
		};
		((UIElement)obj).SnapsToDevicePixels = true;
		((FrameworkElement)obj).Height = 42.0;
		obj.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)obj).Tag = Entry;
		obj.Info = Entry.StatusDescription + "，发布于 " + Entry.ReleaseDate.ToString("yyyy'/'MM'/'dd HH':'mm");
		obj.Logo = ModBase.PathImage + "Blocks/OptiFabric.png";
		obj.Click += OnClick;
		return obj;
	}

	public static MyListItem LegacyFabricDownloadListItem(JObject Entry, MyListItem.ClickEventHandler OnClick)
	{
		MyListItem obj = new MyListItem
		{
			Title = Entry["version"].ToString()
		};
		((UIElement)obj).SnapsToDevicePixels = true;
		((FrameworkElement)obj).Height = 42.0;
		obj.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)obj).Tag = Entry;
		obj.Info = (Entry["stable"].ToObject<bool>() ? "稳定版" : "测试版");
		obj.Logo = ModBase.PathImage + "Blocks/Fabric.png";
		obj.Click += OnClick;
		return obj;
	}

	public static MyListItem LegacyFabricApiDownloadListItem(ModComp.CompFile Entry, MyListItem.ClickEventHandler OnClick)
	{
		MyListItem obj = new MyListItem
		{
			Title = Entry.DisplayName.Replace("Legacy Fabric API ", "")
		};
		((UIElement)obj).SnapsToDevicePixels = true;
		((FrameworkElement)obj).Height = 42.0;
		obj.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)obj).Tag = Entry;
		obj.Info = Entry.StatusDescription + "，发布于 " + Entry.ReleaseDate.ToString("yyyy'/'MM'/'dd HH':'mm");
		obj.Logo = ModBase.PathImage + "Blocks/Fabric.png";
		obj.Click += OnClick;
		return obj;
	}

	public static void McDownloadQuiltLoaderSave(JObject DownloadInfo)
	{
		try
		{
			string text = DownloadInfo["url"].ToString();
			string fileNameFromPath = ModBase.GetFileNameFromPath(text);
			string fileNameFromPath2 = ModBase.GetFileNameFromPath(DownloadInfo["version"].ToString());
			string text2 = SystemDialogs.SelectSaveFile("选择保存位置", fileNameFromPath, "Quilt 安装器 (*.jar)|*.jar");
			if (!text2.Contains("\\"))
			{
				return;
			}
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, $"Quilt {fileNameFromPath2} 安装器下载", false) == 0)
					{
						ModMain.Hint("该实例正在下载中！", ModMain.HintType.Critical);
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
			List<string> val2 = new List<string>();
			val2.Add(text);
			List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
			obj.Add(new ModNet.NetFile(val2.ToArray(), text2, new ModBase.FileChecker(65536L, -1L)));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载主文件", obj)
			{
				ProgressWeight = 15.0
			});
			ModLoader.LoaderCombo<JObject> loaderCombo = new ModLoader.LoaderCombo<JObject>("Quilt " + fileNameFromPath2 + " 安装器下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
			loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
			loaderCombo.Start(DownloadInfo);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "开始 Quilt 安装器下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static List<ModLoader.LoaderBase> McDownloadQuiltLoader(string QuiltVersion, string MinecraftName, string McFolder = null, bool FixLibrary = true)
	{
		McFolder = McFolder ?? ModMinecraft.PathMcFolder;
		Operators.CompareString(McFolder, ModMinecraft.PathMcFolder, false);
		string text = "quilt-loader-" + QuiltVersion + "-" + MinecraftName;
		string text2 = McFolder + "versions\\" + text + "\\";
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		MinecraftName = MinecraftName.Replace("∞", "infinite");
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("获取 Quilt 主文件下载地址", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
		{
			if (FixLibrary)
			{
				McDownloadClient(ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading, MinecraftName);
			}
			Task.Progress = 0.5;
			List<ModNet.NetFile> val2 = new List<ModNet.NetFile>();
			val2.Add(new ModNet.NetFile(new string[] { string.Concat(new string[] { "https://meta.quiltmc.org/v3/versions/loader/", MinecraftName, "/", QuiltVersion, "/profile/json" }) }, text2 + text + ".json", new ModBase.FileChecker(-1L, -1L, null, CanUseExistsFile: true, IsJson: true)));
			Task.Output = val2;
			Directory.CreateDirectory($"{McFolder ?? ModMinecraft.PathMcFolder}mods\\");
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 0.5
		});
		val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 Quilt 主文件", new List<ModNet.NetFile>())
		{
			ProgressWeight = 2.5
		});
		if (FixLibrary)
		{
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析 Quilt 支持库文件", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(text2));
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 1.0,
				Show = false
			});
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 Quilt 支持库文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 8.0
			});
		}
		return val;
	}

	public static MyListItem QuiltDownloadListItem(JObject Entry, MyListItem.ClickEventHandler OnClick)
	{
		MyListItem obj = new MyListItem
		{
			Title = Entry["version"].ToString()
		};
		((UIElement)obj).SnapsToDevicePixels = true;
		((FrameworkElement)obj).Height = 42.0;
		obj.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)obj).Tag = Entry;
		obj.Info = (Entry["maven"].ToString().Contains("installer") ? "安装器" : ((Entry["version"].ToString().Contains("beta") || Entry["version"].ToString().Contains("pre")) ? "测试版" : "稳定版"));
		obj.Logo = ModBase.PathImage + "Blocks/Quilt.png";
		obj.Click += OnClick;
		obj.ContentHandler = QuiltContMenuBuild;
		return obj;
	}

	private static void QuiltContMenuBuild(object sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj).ToolTip = "更新日志";
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			QuiltLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		NewLateBinding.LateSet(sender, (System.Type)null, "Buttons", new object[] { new MyIconButton[] { myIconButton } }, (string[])null, (System.Type[])null);
	}

	private static void QuiltLog_Click(object sender, RoutedEventArgs e)
	{
		ModBase.OpenWebsite("https://quiltmc.org/en/blog/1/");
	}

	public static MyListItem QSLDownloadListItem(ModComp.CompFile Entry, MyListItem.ClickEventHandler OnClick)
	{
		MyListItem obj = new MyListItem
		{
			Title = Entry.DisplayName.Split("]", (StringSplitOptions)0)[1].Replace(" build ", ".").Split("+", (StringSplitOptions)0)[0].Trim()
		};
		((UIElement)obj).SnapsToDevicePixels = true;
		((FrameworkElement)obj).Height = 42.0;
		obj.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)obj).Tag = Entry;
		obj.Info = Entry.StatusDescription + "，发布于 " + Entry.ReleaseDate.ToString("yyyy'/'MM'/'dd HH':'mm");
		obj.Logo = ModBase.PathImage + "Blocks/Quilt.png";
		obj.Click += OnClick;
		return obj;
	}

	public static void McDownloadLabyModProductionLoaderSave()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string text = "https://releases.labymod.net/api/v1/installer/production/java";
			string fileName = "LabyMod4ProductionInstaller.jar";
			string text2 = SystemDialogs.SelectSaveFile("选择保存位置", fileName, "LabyMod 安装器 (*.jar)|*.jar");
			if (!text2.Contains("\\"))
			{
				return;
			}
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, "LabyMod 安装器下载", false) == 0)
					{
						ModMain.Hint("该实例正在下载中！", ModMain.HintType.Critical);
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
			List<string> val2 = new List<string>();
			val2.Add(text);
			List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
			obj.Add(new ModNet.NetFile(val2.ToArray(), text2, new ModBase.FileChecker(65536L, -1L)));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载主文件", obj)
			{
				ProgressWeight = 15.0
			});
			ModLoader.LoaderCombo<JObject> loaderCombo = new ModLoader.LoaderCombo<JObject>("LabyMod 安装器下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
			loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
			loaderCombo.Start();
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "开始 LabyMod 安装器下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public static void McDownloadLabyModSnapshotLoaderSave()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string text = "https://releases.labymod.net/api/v1/installer/snapshot/java";
			string fileName = "LabyMod4SnapshotInstaller.jar";
			string text2 = SystemDialogs.SelectSaveFile("选择保存位置", fileName, "LabyMod 安装器 (*.jar)|*.jar");
			if (!text2.Contains("\\"))
			{
				return;
			}
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, "LabyMod 安装器下载", false) == 0)
					{
						ModMain.Hint("该实例正在下载中！", ModMain.HintType.Critical);
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
			List<string> val2 = new List<string>();
			val2.Add(text);
			List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
			obj.Add(new ModNet.NetFile(val2.ToArray(), text2, new ModBase.FileChecker(65536L, -1L)));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载主文件", obj)
			{
				ProgressWeight = 15.0
			});
			ModLoader.LoaderCombo<JObject> loaderCombo = new ModLoader.LoaderCombo<JObject>("LabyMod 安装器下载", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
			loaderCombo.OnStateChanged = LoaderStateChangedHintOnly;
			loaderCombo.Start();
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "开始 LabyMod 安装器下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static List<ModLoader.LoaderBase> McDownloadLabyModLoader(string LabyModCommitRef, string LabyModChannel, string MinecraftName, string McFolder = null, bool FixLibrary = true)
	{
		McFolder = McFolder ?? ModMinecraft.PathMcFolder;
		Operators.CompareString(McFolder, ModMinecraft.PathMcFolder, false);
		string text = "labymod-" + LabyModCommitRef + "-" + MinecraftName;
		string text2 = McFolder + "versions\\" + text + "\\";
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		MinecraftName = MinecraftName.Replace("∞", "infinite");
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("获取 LabyMod 客户端文件下载地址", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
		{
			if (FixLibrary)
			{
				McDownloadClient(ModNet.NetPreDownloadBehaviour.ExitWhileExistsOrDownloading, MinecraftName, $"https://releases.r2.labymod.net/api/v1/download/manifest/labymod4/{LabyModChannel}/{MinecraftName}/{LabyModCommitRef}.json");
			}
			Task.Progress = 0.5;
			List<ModNet.NetFile> val2 = new List<ModNet.NetFile>();
			val2.Add(new ModNet.NetFile(new string[] { $"https://releases.r2.labymod.net/api/v1/download/manifest/labymod4/{LabyModChannel}/{MinecraftName}/{LabyModCommitRef}.json" }, text2 + text + ".json", new ModBase.FileChecker(-1L, -1L, null, CanUseExistsFile: true, IsJson: true)));
			Task.Output = val2;
			Task.Progress = 1.0;
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 2.0
		});
		val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 LabyMod 客户端 Json 文件", new List<ModNet.NetFile>())
		{
			ProgressWeight = 10.0
		});
		if (FixLibrary)
		{
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析 LabyMod 支持库文件", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(text2));
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 1.0,
				Show = false
			});
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 LabyMod 支持库文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 8.0
			});
		}
		return val;
	}

	private static List<ModLoader.LoaderBase> McDownloadLabyModClientLoader(string Id, string LabyChannel, string LabyCommitRef, string VersionName = null)
	{
		VersionName = VersionName ?? Id;
		string text = ModMinecraft.PathMcFolder + "versions\\" + VersionName + "\\";
		List<ModLoader.LoaderBase> obj = new List<ModLoader.LoaderBase>();
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析原版与 LabyMod 支持库文件（副加载器）", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
		{
			Thread.Sleep(50);
			ModBase.Log("[Download] 开始分析原版与 LabyMod 支持库文件：" + text);
			Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(text));
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 1.0,
			Show = false
		});
		val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载原版与 LabyMod 支持库文件（副加载器）", new List<ModNet.NetFile>())
		{
			ProgressWeight = 13.0,
			Show = false
		});
		obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载原版支持库文件", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val)
		{
			Block = false,
			ProgressWeight = 14.0
		});
		List<ModLoader.LoaderBase> val2 = new List<ModLoader.LoaderBase>();
		val2.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析资源文件索引地址（副加载器）", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
		{
			try
			{
				ModMinecraft.McInstance version = new ModMinecraft.McInstance(text);
				List<ModNet.NetFile> obj2 = new List<ModNet.NetFile>();
				obj2.Add(ModDownload.DlClientAssetIndexGet(version));
				Task.Output = obj2;
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				throw new System.Exception("分析资源文件索引地址失败", ex2);
			}
			try
			{
				JObject jObject = (JObject)ModBase.GetJson(ModBase.ReadFile(text + VersionName + ".json"));
				jObject.Add("clientVersion", Id);
				ModBase.WriteFile(text + VersionName + ".json", jObject.ToString());
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				throw new System.Exception("添加客户端版本失败", ex4);
			}
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 1.0,
			Show = false
		});
		val2.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载资源文件索引（副加载器）", new List<ModNet.NetFile>())
		{
			ProgressWeight = 3.0,
			Show = false
		});
		val2.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析所需资源文件（副加载器）", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
		{
			ModLoader.LoaderTask<string, List<ModNet.NetFile>> loaderTask = Task;
			ModMinecraft.McInstance instance = new ModMinecraft.McInstance(text);
			ModLoader.LoaderBase ProgressFeed = Task;
			List<ModNet.NetFile> output = ModMinecraft.McAssetsFixList(instance, CheckHash: true, ref ProgressFeed);
			Task = (ModLoader.LoaderTask<string, List<ModNet.NetFile>>)ProgressFeed;
			loaderTask.Output = output;
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 3.0,
			Show = false
		});
		val2.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载资源文件（副加载器）", new List<ModNet.NetFile>())
		{
			ProgressWeight = 14.0,
			Show = false
		});
		obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载原版资源文件", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2)
		{
			Block = false,
			ProgressWeight = 21.0
		});
		return obj;
	}

	public static MyListItem LabyModDownloadListItem(JObject Entry, MyListItem.ClickEventHandler OnClick)
	{
		MyListItem obj = new MyListItem
		{
			Title = Entry["version"].ToString() + (Entry["channel"].ToString().Contains("snapshot") ? " 快照版" : " 稳定版")
		};
		((UIElement)obj).SnapsToDevicePixels = true;
		((FrameworkElement)obj).Height = 42.0;
		obj.Type = MyListItem.CheckType.Clickable;
		((FrameworkElement)obj).Tag = Entry;
		obj.Info = (Entry["channel"].ToString().Contains("snapshot") ? "快照版" : "稳定版");
		obj.Logo = ModBase.PathImage + "Blocks/LabyMod.png";
		obj.Click += OnClick;
		obj.ContentHandler = LabyModContMenuBuild;
		return obj;
	}

	private static void LabyModContMenuBuild(object sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z"
		};
		((FrameworkElement)obj).ToolTip = "另存为";
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			LabyModSave_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		MyIconButton obj2 = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj2).ToolTip = "更新日志";
		MyIconButton myIconButton2 = obj2;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton2, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton2, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton2, 2.0);
		myIconButton2.Click += [SpecialName] (object a0, EventArgs a1) =>
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			LabyModLog_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		};
		NewLateBinding.LateSet(sender, (System.Type)null, "Buttons", new object[] { new MyIconButton[] { myIconButton, myIconButton2 } }, (string[])null, (System.Type[])null);
	}

	private static void LabyModLog_Click(object sender, RoutedEventArgs e)
	{
		ModBase.OpenWebsite("https://www.labymod.net/zh_Hans/download");
	}

	private static void LabyModSave_Click(object sender, RoutedEventArgs e)
	{
		JObject jObject = ((NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) != null) ? ((JObject)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) == null) ? ((JObject)NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)) : ((JObject)NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
		if ((string?)jObject["channel"] == "snapshot")
		{
			McDownloadLabyModSnapshotLoaderSave();
		}
		else
		{
			McDownloadLabyModProductionLoaderSave();
		}
	}

	public static void LoaderStateChangedHintOnly(object Loader)
	{
		object obj = NewLateBinding.LateGet(Loader, (System.Type)null, "State", new object[0], (string[])null, (System.Type[])null, (bool[])null);
		if (Operators.ConditionalCompareObjectEqual(obj, (object)ModBase.LoadState.Finished, false))
		{
			ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Name", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"成功！")), ModMain.HintType.Finish);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)ModBase.LoadState.Failed, false))
		{
			ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Name", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"失败："), NewLateBinding.LateGet(NewLateBinding.LateGet(Loader, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null))), ModMain.HintType.Critical);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)ModBase.LoadState.Aborted, false))
		{
			ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Name", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"已取消！")));
		}
	}

	public static void McInstallState(object Loader)
	{
		object obj = NewLateBinding.LateGet(Loader, (System.Type)null, "State", new object[0], (string[])null, (System.Type[])null, (bool[])null);
		if (Operators.ConditionalCompareObjectEqual(obj, (object)ModBase.LoadState.Finished, false))
		{
			if (Conversions.ToBoolean(ModBase.Setup.Get("ToolDownloadAutoSelectVersion")))
			{
				string text = NewLateBinding.LateGet(Loader, (System.Type)null, "Name", new object[0], (string[])null, (System.Type[])null, (bool[])null).ToString();
				ModBase.WriteIni(ModMinecraft.PathMcFolder + "PCL.ini", "Version", text.Remove(checked(text.Length - 3), 3));
			}
			ModBase.WriteIni(ModMinecraft.PathMcFolder + "PCL.ini", "InstanceCache", "");
			ModBase.DeleteDirectory(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Input", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"PCLInstallBackups\\")));
			ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Name", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"成功！")), ModMain.HintType.Finish);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)ModBase.LoadState.Failed, false))
		{
			ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Name", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"失败："), NewLateBinding.LateGet(NewLateBinding.LateGet(Loader, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null))), ModMain.HintType.Critical);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)ModBase.LoadState.Aborted, false))
		{
			ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Name", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"已取消！")));
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)ModBase.LoadState.Loading, false))
		{
			return;
		}
		if (Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(NewLateBinding.LateGet(Loader, (System.Type)null, "State", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)ModBase.LoadState.Finished, false))) && Directory.Exists(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Input", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"PCLInstallBackups\\"))))))
		{
			ModBase.CopyDirectory(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Input", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"PCLInstallBackups\\")), Conversions.ToString(NewLateBinding.LateGet(Loader, (System.Type)null, "Input", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
			File.Delete(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Input", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)".pclignore")));
			ModBase.DeleteDirectory(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Input", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"PCLInstallBackups\\")));
		}
		else
		{
			McInstallFailedClearFolder(RuntimeHelpers.GetObjectValue(Loader));
		}
		ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
	}

	public static void McInstallFailedClearFolder(object Loader)
	{
		try
		{
			Thread.Sleep(1000);
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(Loader, (System.Type)null, "State", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)ModBase.LoadState.Failed, false) || Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(Loader, (System.Type)null, "State", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)ModBase.LoadState.Aborted, false))
			{
				if (Directory.Exists(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Input", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"saves\\"))) || Directory.Exists(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Input", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"versions\\"))) || Directory.Exists(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Input", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"mods\\"))) || File.Exists(Conversions.ToString(Operators.ConcatenateObject(NewLateBinding.LateGet(Loader, (System.Type)null, "Input", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"server.dat"))))
				{
					ModBase.Log(Conversions.ToString(Operators.ConcatenateObject((object)"[Download] 由于实例已被独立启动，不清理实例文件夹：", NewLateBinding.LateGet(Loader, (System.Type)null, "Input", new object[0], (string[])null, (System.Type[])null, (bool[])null))), ModBase.LogLevel.Developer);
					return;
				}
				ModBase.Log(Conversions.ToString(Operators.ConcatenateObject((object)"[Download] 由于下载失败或取消，清理实例文件夹：", NewLateBinding.LateGet(Loader, (System.Type)null, "Input", new object[0], (string[])null, (System.Type[])null, (bool[])null))), ModBase.LogLevel.Developer);
				ModBase.DeleteDirectory(Conversions.ToString(NewLateBinding.LateGet(Loader, (System.Type)null, "Input", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "下载失败或取消后清理实例文件夹失败");
			ProjectData.ClearProjectError();
		}
	}

	public static bool McInstall(McInstallRequest Request, string Type = "安装")
	{
		bool result;
		try
		{
			List<ModLoader.LoaderBase> val = McInstallLoader(Request, DontFixLibraries: false, Operators.CompareString(Type, "安装", false) != 0);
			if (val == null)
			{
				result = false;
			}
			else
			{
				ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(Request.TargetInstanceName + " " + Type, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
				loaderCombo.OnStateChanged = McInstallState;
				loaderCombo.Start(Request.TargetInstanceFolder);
				ModLoader.LoaderTaskbarAdd(loaderCombo);
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
				ModMain.FrmMain.BtnExtraDownload.Ribble();
				result = true;
			}
		}
		catch (ModBase.CancelledException ex)
		{
			ProjectData.SetProjectError((System.Exception)ex);
			ModBase.CancelledException ex2 = ex;
			result = false;
			ProjectData.ClearProjectError();
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			ModBase.Log(ex4, "开始合并安装失败", ModBase.LogLevel.Feedback);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static List<ModLoader.LoaderBase> McInstallLoader(McInstallRequest Request, bool DontFixLibraries = false, bool IgnoreDump = false)
	{
		_Closure_0024__89_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__89_002D0();
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Request = Request;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder = ModMain.RequestTaskTempFolder(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineEntry != null || CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeEntry != null || CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeEntry != null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceFolder = ModMinecraft.PathMcFolder + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetInstanceName + "\\";
		if (Directory.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder))
		{
			ModBase.DeleteDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder);
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_OptiFineFolder = null;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineVersion != null)
		{
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineVersion.Contains("_HD_U_"))
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineVersion = "HD_U_" + ModBase.AfterLast(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineVersion, "_HD_U_");
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineEntry = new ModDownload.DlOptiFineListEntry
			{
				NameDisplay = CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName + " " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineVersion.Replace("HD_U_", "").Replace("_", "").Replace("pre", " pre"),
				Inherit = CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName,
				IsPreview = ModBase.ContainsF(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineVersion, "pre", IgnoreCase: true),
				NameVersion = CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName + "-OptiFine_" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineVersion,
				NameFile = string.Concat(new string[6]
				{
					ModBase.ContainsF(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineVersion, "pre", IgnoreCase: true) ? "preview_" : "",
					"OptiFine_",
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName,
					"_",
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineVersion,
					".jar"
				})
			};
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineEntry != null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_OptiFineFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineEntry.NameVersion;
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ForgeFolder = null;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeEntry != null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion = CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion ?? CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeEntry.VersionName;
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion != null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_ForgeFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder + "versions\\forge-" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion;
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_NeoForgeFolder = null;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeEntry != null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeVersion = CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeVersion ?? CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeEntry.VersionName;
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeVersion != null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_NeoForgeFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder + "versions\\neoforge-" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeVersion;
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_CleanroomFolder = null;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomEntry != null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomVersion = CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomVersion ?? CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomEntry.VersionName;
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomVersion != null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_CleanroomFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder + "versions\\cleanroom-" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomVersion;
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_FabricFolder = null;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion != null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_FabricFolder = string.Concat(new string[5]
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder,
				"versions\\fabric-loader-",
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion,
				"-",
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName
			});
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_LegacyFabricFolder = null;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LegacyFabricVersion != null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_LegacyFabricFolder = string.Concat(new string[5]
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder,
				"versions\\legacy-fabric-loader-",
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LegacyFabricVersion,
				"-",
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName
			});
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_QuiltFolder = null;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.QuiltVersion != null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_QuiltFolder = string.Concat(new string[5]
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder,
				"versions\\quilt-loader-",
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.QuiltVersion,
				"-",
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName
			});
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_LabyModFolder = null;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LabyModCommitRef != null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_LabyModFolder = string.Concat(new string[5]
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder,
				"versions\\labymod-",
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LabyModCommitRef,
				"-",
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName
			});
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_LiteLoaderFolder = null;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LiteLoaderEntry != null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_LiteLoaderFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName + "-LiteLoader";
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Modable = CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion != null || CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LegacyFabricVersion != null || CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeEntry != null || CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeEntry != null || CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LiteLoaderEntry != null;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ModsTempFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder + "mods\\";
		CS_0024_003C_003E8__locals0._0024VB_0024Local_OptiFineAsMod = CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineEntry != null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Modable;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_OptiFineAsMod)
		{
			ModBase.Log("[Download] OptiFine 将作为 Mod 进行下载");
			CS_0024_003C_003E8__locals0._0024VB_0024Local_OptiFineFolder = CS_0024_003C_003E8__locals0._0024VB_0024Local_ModsTempFolder;
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_OptiFineFolder != null)
		{
			ModBase.Log("[Download] OptiFine 缓存：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_OptiFineFolder);
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_ForgeFolder != null)
		{
			ModBase.Log("[Download] Forge 缓存：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_ForgeFolder);
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_NeoForgeFolder != null)
		{
			ModBase.Log("[Download] NeoForge 缓存：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_NeoForgeFolder);
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_CleanroomFolder != null)
		{
			ModBase.Log("[Download] Cleanroom 缓存：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_CleanroomFolder);
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_FabricFolder != null)
		{
			ModBase.Log("[Download] Fabric 缓存：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_FabricFolder);
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_LegacyFabricFolder != null)
		{
			ModBase.Log("[Download] LegacyFabric 缓存：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_LegacyFabricFolder);
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_QuiltFolder != null)
		{
			ModBase.Log("[Download] Quilt 缓存：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_QuiltFolder);
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_LabyModFolder != null)
		{
			ModBase.Log("[Download] LabyMod 缓存：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_LabyModFolder);
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_LiteLoaderFolder != null)
		{
			ModBase.Log("[Download] LiteLoader 缓存：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_LiteLoaderFolder);
		}
		ModBase.Log("[Download] 对应的原版版本：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName);
		if (File.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetInstanceName + ".json") && !IgnoreDump)
		{
			ModMain.Hint("实例 " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetInstanceName + " 已经存在！", ModMain.HintType.Critical);
			throw new ModBase.CancelledException();
		}
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("添加忽略标识", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
		{
			CS_0024_003C_003E8__locals0._Lambda_0024__0();
		}, null, (ThreadPriority)2)
		{
			Show = false,
			Block = false
		});
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricApi != null)
		{
			List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
			obj.Add(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricApi.ToNetFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_ModsTempFolder));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 Fabric API", obj)
			{
				ProgressWeight = 3.0,
				Block = false
			});
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LegacyFabricApi != null)
		{
			List<ModNet.NetFile> obj2 = new List<ModNet.NetFile>();
			obj2.Add(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LegacyFabricApi.ToNetFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_ModsTempFolder));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 Legacy Fabric API", obj2)
			{
				ProgressWeight = 3.0,
				Block = false
			});
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.QSL != null)
		{
			List<ModNet.NetFile> obj3 = new List<ModNet.NetFile>();
			obj3.Add(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.QSL.ToNetFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_ModsTempFolder));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 QFAPI / QSL", obj3)
			{
				ProgressWeight = 3.0,
				Block = false
			});
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFabric != null)
		{
			List<ModNet.NetFile> obj4 = new List<ModNet.NetFile>();
			obj4.Add(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFabric.ToNetFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_ModsTempFolder));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 OptiFabric", obj4)
			{
				ProgressWeight = 3.0,
				Block = false
			});
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LabyModCommitRef != null)
		{
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载 LabyMod " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LabyModCommitRef, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadLabyModLoader(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LabyModCommitRef, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LabyModChannel, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName, CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder, FixLibrary: false))
			{
				Show = false,
				ProgressWeight = 10.0,
				Block = true
			});
		}
		else
		{
			ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("下载原版 " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadClientLoader(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftJson, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetInstanceName))
			{
				Show = false,
				ProgressWeight = 39.0,
				Block = (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeVersion == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineEntry == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LiteLoaderEntry == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.QuiltVersion == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomEntry == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LegacyFabricVersion == null)
			};
			val.Add((ModLoader.LoaderBase)loaderCombo);
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineEntry != null)
			{
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_OptiFineAsMod)
				{
					val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载 OptiFine " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineEntry.NameDisplay, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadOptiFineSaveLoader(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineEntry, CS_0024_003C_003E8__locals0._0024VB_0024Local_OptiFineFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineEntry.NameFile))
					{
						Show = false,
						ProgressWeight = 16.0,
						Block = (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeVersion == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LiteLoaderEntry == null)
					});
				}
				else
				{
					val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载 OptiFine " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineEntry.NameDisplay, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadOptiFineLoader(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineEntry, CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder, loaderCombo, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetInstanceFolder, FixLibrary: false))
					{
						Show = false,
						ProgressWeight = 24.0,
						Block = (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeVersion == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LiteLoaderEntry == null)
					});
				}
			}
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion != null)
			{
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载 Forge " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadForgelikeLoader("Forge", CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion, "forge-" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeEntry, CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder, loaderCombo, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetInstanceFolder))
				{
					Show = false,
					ProgressWeight = 25.0,
					Block = (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LiteLoaderEntry == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeEntry == null)
				});
			}
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeVersion != null)
			{
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载 NeoForge " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeVersion, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadForgelikeLoader("NeoForge", CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeVersion, "neoforge-" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeVersion, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeEntry, CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder, loaderCombo, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetInstanceFolder))
				{
					Show = false,
					ProgressWeight = 25.0,
					Block = (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeEntry == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LiteLoaderEntry == null)
				});
			}
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomVersion != null)
			{
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载 Cleanroom " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomVersion, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadForgelikeLoader("Cleanroom", CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomVersion, "cleanroom-" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomVersion, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomEntry, CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder, loaderCombo, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetInstanceFolder))
				{
					Show = false,
					ProgressWeight = 25.0,
					Block = (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeEntry == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion == null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LiteLoaderEntry == null)
				});
			}
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LiteLoaderEntry != null)
			{
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载 LiteLoader " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadLiteLoaderLoader(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LiteLoaderEntry, CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder, loaderCombo, FixLibrary: false))
				{
					Show = false,
					ProgressWeight = 1.0,
					Block = (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion == null)
				});
			}
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion != null)
			{
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载 Fabric " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadFabricLoader(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName, CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder, FixLibrary: false))
				{
					Show = false,
					ProgressWeight = 2.0,
					Block = true
				});
			}
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LegacyFabricVersion != null)
			{
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载 Legacy Fabric " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LegacyFabricVersion, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadLegacyFabricLoader(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LegacyFabricVersion, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName, CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder, FixLibrary: false))
				{
					Show = false,
					ProgressWeight = 2.0,
					Block = true
				});
			}
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.QuiltVersion != null)
			{
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载 Quilt " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.QuiltVersion, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadQuiltLoader(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.QuiltVersion, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName, CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder, FixLibrary: false))
				{
					Show = false,
					ProgressWeight = 2.0,
					Block = true
				});
			}
		}
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, string>("安装游戏", [SpecialName] (ModLoader.LoaderTask<string, string> Task) =>
		{
			MergeJson(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceFolder, CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceFolder, CS_0024_003C_003E8__locals0._0024VB_0024Local_OptiFineFolder, CS_0024_003C_003E8__locals0._0024VB_0024Local_OptiFineAsMod, CS_0024_003C_003E8__locals0._0024VB_0024Local_ForgeFolder, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion, CS_0024_003C_003E8__locals0._0024VB_0024Local_NeoForgeFolder, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeVersion, CS_0024_003C_003E8__locals0._0024VB_0024Local_CleanroomFolder, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomVersion, CS_0024_003C_003E8__locals0._0024VB_0024Local_FabricFolder, CS_0024_003C_003E8__locals0._0024VB_0024Local_QuiltFolder, CS_0024_003C_003E8__locals0._0024VB_0024Local_LabyModFolder, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LabyModChannel, CS_0024_003C_003E8__locals0._0024VB_0024Local_LiteLoaderFolder, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MMCPackInfo, CS_0024_003C_003E8__locals0._0024VB_0024Local_LegacyFabricFolder);
			Task.Progress = 0.2;
			if (Directory.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder + "libraries"))
			{
				ModBase.CopyDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempMcFolder + "libraries", ModMinecraft.PathMcFolder + "libraries");
			}
			Task.Progress = 0.8;
			string text = new ModMinecraft.McInstance(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceFolder).PathIndie + "mods\\";
			if (Directory.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_ModsTempFolder))
			{
				ModBase.CopyDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_ModsTempFolder, text);
			}
			else if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Modable)
			{
				Directory.CreateDirectory(text);
				ModBase.Log("[Download] 自动创建 Mod 文件夹：" + text);
			}
			string text2 = new ModMinecraft.McInstance(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceFolder).PathIndie + "resourcepacks\\";
			Directory.CreateDirectory(text2);
			ModBase.Log("[Download] 自动创建资源包文件夹：" + text2);
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 2.0,
			Block = true
		});
		if (!DontFixLibraries && (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.OptiFineEntry != null || (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion != null && Conversions.ToDouble(ModBase.BeforeFirst(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ForgeVersion, ".")) >= 20.0) || CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.NeoForgeVersion != null || CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.FabricVersion != null || CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.QuiltVersion != null || CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CleanroomVersion != null || CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LiteLoaderEntry != null || CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LabyModCommitRef != null))
		{
			List<ModLoader.LoaderBase> val2 = new List<ModLoader.LoaderBase>();
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LabyModCommitRef != null)
			{
				ModLoader.LoaderCombo<string> loaderCombo2 = new ModLoader.LoaderCombo<string>("下载原版 " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)McDownloadLabyModClientLoader(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.MinecraftName, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LabyModChannel, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.LabyModCommitRef, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetInstanceName))
				{
					Show = false,
					ProgressWeight = 39.0,
					Block = false
				};
				val.Add((ModLoader.LoaderBase)loaderCombo2);
			}
			else
			{
				val2.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析游戏支持库文件（副加载器）", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
				{
					Task.Output = ModMinecraft.McLibFix(new ModMinecraft.McInstance(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceFolder));
				}, null, (ThreadPriority)2)
				{
					ProgressWeight = 1.0,
					Show = false
				});
				val2.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载游戏支持库文件（副加载器）", new List<ModNet.NetFile>())
				{
					ProgressWeight = 7.0,
					Show = false
				});
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载游戏支持库文件", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2)
				{
					ProgressWeight = 8.0
				});
			}
		}
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("删除忽略标识", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
		{
			CS_0024_003C_003E8__locals0._Lambda_0024__3();
		}, null, (ThreadPriority)2)
		{
			Show = false
		});
		return val;
	}

	private static void MergeJson(string OutputFolder, string MinecraftFolder, string OptiFineFolder = null, bool OptiFineAsMod = false, string ForgeFolder = null, string ForgeVersion = null, string NeoForgeFolder = null, string NeoForgeVersion = null, string CleanroomFolder = null, string CleanroomVersion = null, string FabricFolder = null, string QuiltFolder = null, string LabyModFolder = null, string LabyModChannel = null, string LiteLoaderFolder = null, ModModpack.MMCPackInfo MMCPackInfo = null, string LegacyFabricFolder = null)
	{
		//IL_0d75: Unknown result type (might be due to invalid IL or missing references)
		ModBase.Log(string.Concat(new string[13]
		{
			"[Download] 开始进行实例合并，输出：",
			OutputFolder,
			"，Minecraft：",
			MinecraftFolder,
			(OptiFineFolder != null) ? ("，OptiFine：" + OptiFineFolder) : "",
			(ForgeFolder != null) ? ("，Forge：" + ForgeFolder) : "",
			(NeoForgeFolder != null) ? ("，NeoForge：" + NeoForgeFolder) : "",
			(CleanroomFolder != null) ? ("，Cleanroom：" + CleanroomFolder) : "",
			(LiteLoaderFolder != null) ? ("，LiteLoader：" + LiteLoaderFolder) : "",
			(FabricFolder != null) ? ("，Fabric：" + FabricFolder) : "",
			(LegacyFabricFolder != null) ? ("，LegacyFabric：" + LegacyFabricFolder) : "",
			(QuiltFolder != null) ? ("，Quilt：" + QuiltFolder) : "",
			(LabyModFolder != null) ? ("，LabyMod：" + LabyModFolder) : ""
		}));
		Directory.CreateDirectory(OutputFolder);
		bool flag = OptiFineFolder != null && !OptiFineAsMod;
		bool flag2 = ForgeFolder != null;
		bool flag3 = LegacyFabricFolder != null;
		bool flag4 = NeoForgeFolder != null;
		bool flag5 = CleanroomFolder != null;
		bool flag6 = LiteLoaderFolder != null;
		bool flag7 = FabricFolder != null;
		bool flag8 = QuiltFolder != null;
		bool flag9 = LabyModFolder != null;
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		string text5 = null;
		string text6 = null;
		string text7 = null;
		string text8 = null;
		string filePath = null;
		if (!ModBase.EndsWithF(OutputFolder, "\\"))
		{
			OutputFolder += "\\";
		}
		string folderNameFromPath = ModBase.GetFolderNameFromPath(OutputFolder);
		string filePath2 = OutputFolder + folderNameFromPath + ".json";
		string text9 = OutputFolder + folderNameFromPath + ".jar";
		if (!ModBase.EndsWithF(MinecraftFolder, "\\"))
		{
			MinecraftFolder += "\\";
		}
		string folderNameFromPath2 = ModBase.GetFolderNameFromPath(MinecraftFolder);
		string text10 = MinecraftFolder + folderNameFromPath2 + ".json";
		string text11 = MinecraftFolder + folderNameFromPath2 + ".jar";
		if (flag)
		{
			if (!ModBase.EndsWithF(OptiFineFolder, "\\"))
			{
				OptiFineFolder += "\\";
			}
			string folderNameFromPath3 = ModBase.GetFolderNameFromPath(OptiFineFolder);
			text = OptiFineFolder + folderNameFromPath3 + ".json";
		}
		if (flag2)
		{
			if (!ModBase.EndsWithF(ForgeFolder, "\\"))
			{
				ForgeFolder += "\\";
			}
			string folderNameFromPath4 = ModBase.GetFolderNameFromPath(ForgeFolder);
			text2 = ForgeFolder + folderNameFromPath4 + ".json";
		}
		if (flag4)
		{
			if (!ModBase.EndsWithF(NeoForgeFolder, "\\"))
			{
				NeoForgeFolder += "\\";
			}
			string folderNameFromPath5 = ModBase.GetFolderNameFromPath(NeoForgeFolder);
			text3 = NeoForgeFolder + folderNameFromPath5 + ".json";
		}
		if (flag5)
		{
			if (!ModBase.EndsWithF(CleanroomFolder, "\\"))
			{
				CleanroomFolder += "\\";
			}
			string folderNameFromPath6 = ModBase.GetFolderNameFromPath(CleanroomFolder);
			text4 = CleanroomFolder + folderNameFromPath6 + ".json";
		}
		if (flag6)
		{
			if (!ModBase.EndsWithF(LiteLoaderFolder, "\\"))
			{
				LiteLoaderFolder += "\\";
			}
			string folderNameFromPath7 = ModBase.GetFolderNameFromPath(LiteLoaderFolder);
			text5 = LiteLoaderFolder + folderNameFromPath7 + ".json";
		}
		if (flag7)
		{
			if (!ModBase.EndsWithF(FabricFolder, "\\"))
			{
				FabricFolder += "\\";
			}
			string folderNameFromPath8 = ModBase.GetFolderNameFromPath(FabricFolder);
			text6 = FabricFolder + folderNameFromPath8 + ".json";
		}
		if (flag3)
		{
			if (!ModBase.EndsWithF(LegacyFabricFolder, "\\"))
			{
				LegacyFabricFolder += "\\";
			}
			string folderNameFromPath9 = ModBase.GetFolderNameFromPath(LegacyFabricFolder);
			filePath = LegacyFabricFolder + folderNameFromPath9 + ".json";
		}
		if (flag8)
		{
			if (!ModBase.EndsWithF(QuiltFolder, "\\"))
			{
				QuiltFolder += "\\";
			}
			string folderNameFromPath10 = ModBase.GetFolderNameFromPath(QuiltFolder);
			text7 = QuiltFolder + folderNameFromPath10 + ".json";
		}
		if (flag9)
		{
			if (!ModBase.EndsWithF(LabyModFolder, "\\"))
			{
				LabyModFolder += "\\";
			}
			string folderNameFromPath11 = ModBase.GetFolderNameFromPath(LabyModFolder);
			text8 = LabyModFolder + folderNameFromPath11 + ".json";
		}
		JObject jObject = null;
		JObject jObject2 = null;
		JObject jObject3 = null;
		JObject jObject4 = null;
		JObject jObject5 = null;
		JObject jObject6 = null;
		JObject jObject7 = null;
		JObject jObject8 = null;
		JObject jObject9 = null;
		JObject jObject10 = null;
		string text12 = ModBase.ReadFile(text10);
		if (!flag9)
		{
			if (!ModBase.StartsWithF(text12, "{"))
			{
				throw new System.Exception("Minecraft Json 有误，地址：" + text10 + "，前段内容：" + text12.Substring(0, Math.Min(text12.Length, 1000)));
			}
			jObject = (JObject)ModBase.GetJson(text12);
		}
		if (flag)
		{
			string text13 = ModBase.ReadFile(text);
			if (!ModBase.StartsWithF(text13, "{"))
			{
				throw new System.Exception("OptiFine Json 有误，地址：" + text + "，前段内容：" + text13.Substring(0, Math.Min(text13.Length, 1000)));
			}
			jObject2 = (JObject)ModBase.GetJson(text13);
		}
		if (flag2)
		{
			string text14 = ModBase.ReadFile(text2);
			if (!ModBase.StartsWithF(text14, "{"))
			{
				throw new System.Exception("Forge Json 有误，地址：" + text2 + "，前段内容：" + text14.Substring(0, Math.Min(text14.Length, 1000)));
			}
			jObject3 = (JObject)ModBase.GetJson(text14);
		}
		if (flag4)
		{
			string text15 = ModBase.ReadFile(text3);
			if (!ModBase.StartsWithF(text15, "{"))
			{
				throw new System.Exception("NeoForge Json 有误，地址：" + text3 + "，前段内容：" + text15.Substring(0, Math.Min(text15.Length, 1000)));
			}
			jObject4 = (JObject)ModBase.GetJson(text15);
		}
		if (flag5)
		{
			string text16 = ModBase.ReadFile(text4);
			if (!ModBase.StartsWithF(text16, "{"))
			{
				throw new System.Exception("Cleanroom Json 有误，地址：" + text4 + "，前段内容：" + text16.Substring(0, Math.Min(text16.Length, 1000)));
			}
			jObject6 = (JObject)ModBase.GetJson(text16);
		}
		if (flag6)
		{
			string text17 = ModBase.ReadFile(text5);
			if (!ModBase.StartsWithF(text17, "{"))
			{
				throw new System.Exception("LiteLoader Json 有误，地址：" + text5 + "，前段内容：" + text17.Substring(0, Math.Min(text17.Length, 1000)));
			}
			jObject7 = (JObject)ModBase.GetJson(text17);
		}
		if (flag7)
		{
			string text18 = ModBase.ReadFile(text6);
			if (!ModBase.StartsWithF(text18, "{"))
			{
				throw new System.Exception("Fabric Json 有误，地址：" + text6 + "，前段内容：" + text18.Substring(0, Math.Min(text18.Length, 1000)));
			}
			jObject8 = (JObject)ModBase.GetJson(text18);
		}
		if (flag3)
		{
			string text19 = ModBase.ReadFile(filePath);
			if (!ModBase.StartsWithF(text19, "{"))
			{
				throw new System.Exception("Legacy Fabric Json 有误，地址：" + text6 + "，前段内容：" + text19.Substring(0, Math.Min(text19.Length, 1000)));
			}
			jObject5 = (JObject)ModBase.GetJson(text19);
		}
		if (flag8)
		{
			string text20 = ModBase.ReadFile(text7);
			if (!ModBase.StartsWithF(text20, "{"))
			{
				throw new System.Exception("Quilt Json 有误，地址：" + text7 + "，前段内容：" + text20.Substring(0, Math.Min(text20.Length, 1000)));
			}
			jObject9 = (JObject)ModBase.GetJson(text20);
		}
		if (flag9)
		{
			string text21 = ModBase.ReadFile(text8);
			if (!ModBase.StartsWithF(text21, "{"))
			{
				throw new System.Exception("LabyMod Json 有误，地址：" + text8 + "，前段内容：" + text21.Substring(0, Math.Min(text21.Length, 1000)));
			}
			jObject10 = (JObject)ModBase.GetJson(text21);
		}
		List<string> val = Enumerable.ToList<string>(Enumerable.Select<string, string>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)string.Concat(new string[13]
		{
			((jObject != null) ? (jObject["minecraftArguments"] ?? ((JToken)" ")).ToString() : " ").ToString(),
			" ",
			(jObject10 != null) ? (jObject10["minecraftArguments"] ?? ((JToken)" ")).ToString() : " ",
			" ",
			(jObject2 != null) ? (jObject2["minecraftArguments"] ?? ((JToken)" ")).ToString() : " ",
			" ",
			(jObject3 != null) ? (jObject3["minecraftArguments"] ?? ((JToken)" ")).ToString() : " ",
			" ",
			(jObject4 != null) ? (jObject4["minecraftArguments"] ?? ((JToken)" ")).ToString() : " ",
			" ",
			(jObject7 != null) ? (jObject7["minecraftArguments"] ?? ((JToken)" ")).ToString() : " ",
			" ",
			(jObject6 != null) ? (jObject6["minecraftArguments"] ?? ((JToken)" ")).ToString() : " "
		}).Split(" ", (StringSplitOptions)0), (Func<string, bool>)([SpecialName] (string l) => Operators.CompareString(l, "", false) != 0)), (Func<string, string>)([SpecialName] (string l) => l.Trim())));
		List<string> val2 = new List<string>();
		checked
		{
			int num = val.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (ModBase.StartsWithF(val[i], "-"))
				{
					val2.Add(val[i]);
				}
				else if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2) && ModBase.StartsWithF(Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)val2), "-") && !Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)val2).Contains(" "))
				{
					val2[val2.Count - 1] = Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)val2) + " " + val[i];
				}
				else
				{
					val2.Add(val[i]);
				}
			}
			string text22 = ModBase.Join((System.Collections.IEnumerable)Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val2)), " ");
			JObject jObject11;
			if (MMCPackInfo != null)
			{
				if (MMCPackInfo.IsMinecraftOverrided)
				{
					ModBase.Log("[Download] 当前实例的 MC 核心已被修改，使用对应的 MMC 整合包参数");
					jObject11 = MMCPackInfo.OverridedJson;
				}
				else
				{
					ModBase.Log("[Download] 存在无修改 MC 核心文件的 MMC 整合包信息，应用相关参数");
					jObject11 = jObject;
					jObject11.Merge(MMCPackInfo.OverridedJson);
				}
			}
			else
			{
				jObject11 = jObject;
			}
			if (flag)
			{
				jObject2.Remove("releaseTime");
				jObject2.Remove("time");
				jObject11.Merge(jObject2);
			}
			if (flag2 && (MMCPackInfo == null || !MMCPackInfo.IsForgeOverrided))
			{
				jObject3.Remove("releaseTime");
				jObject3.Remove("time");
				jObject11.Merge(jObject3);
			}
			if (flag4 && (MMCPackInfo == null || !MMCPackInfo.IsNeoForgeOverrided))
			{
				jObject4.Remove("releaseTime");
				jObject4.Remove("time");
				jObject11.Merge(jObject4);
			}
			if (flag5 && (MMCPackInfo == null || !MMCPackInfo.IsCleanroomOverrided))
			{
				jObject6.Remove("releaseTime");
				jObject6.Remove("time");
				jObject11.Merge(jObject6);
			}
			if (flag6)
			{
				jObject7.Remove("releaseTime");
				jObject7.Remove("time");
				jObject11.Merge(jObject7);
			}
			if (flag7 && (MMCPackInfo == null || !MMCPackInfo.IsFabricOverrided))
			{
				jObject8.Remove("releaseTime");
				jObject8.Remove("time");
				jObject11.Merge(jObject8);
			}
			if (flag3 && (MMCPackInfo == null || !MMCPackInfo.IsFabricOverrided))
			{
				jObject5.Remove("releaseTime");
				jObject5.Remove("time");
				jObject11.Merge(jObject5);
			}
			if (flag8 && (MMCPackInfo == null || !MMCPackInfo.IsQuiltOverrided))
			{
				jObject9.Remove("releaseTime");
				jObject9.Remove("time");
				jObject11.Merge(jObject9);
			}
			if (flag9)
			{
				jObject10.Remove("releaseTime");
				jObject10.Remove("time");
				if (jObject11 == null)
				{
					jObject11 = new JObject();
				}
				jObject11.Merge(jObject10);
				JObject jObject12 = (JObject)ModNet.NetGetCodeByRequestRetry($"https://releases.r2.labymod.net/api/v1/libraries/{LabyModChannel}.json", null, "", IsJson: true);
				JObject jObject13 = (JObject)ModNet.NetGetCodeByRequestRetry($"https://releases.r2.labymod.net/api/v1/manifest/{LabyModChannel}/latest.json", null, "", IsJson: true);
				JArray jArray = new JArray();
				Dictionary<string, bool> val3 = new Dictionary<string, bool>();
				JToken item = jObject10["_minecraftVersion"];
				System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator = ((System.Collections.Generic.IEnumerable<JToken>)jObject12["isolated_libraries"]).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						JToken current = enumerator.Current;
						if (((JArray)current["versions"]).Contains(item))
						{
							val3.Add(current["name"].ToString(), true);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)jObject10["libraries"]).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator2).MoveNext())
					{
						JToken current2 = enumerator2.Current;
						string text23 = ModBase.RegexSeek(current2["name"].ToString(), "(?<=org.lwjgl:)lwjgl(-[a-z._.\\-.0-9]*)(?=(:[0-9].[0-9].[0-9](-[a-z.0-9._.\\-]*)?:([a-z._.\\-.0-9]*)?))", (RegexOptions)0);
						if (text23 == null || !Enumerable.Contains<KeyValuePair<string, bool>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, bool>>)val3, new KeyValuePair<string, bool>(text23, true)))
						{
							jArray.Add(current2);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator2)?.Dispose();
				}
				System.Collections.Generic.IEnumerator<JToken> enumerator3 = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator3 = ((System.Collections.Generic.IEnumerable<JToken>)jObject12["libraries"]).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator3).MoveNext())
					{
						JToken current3 = enumerator3.Current;
						jArray.Add(JObject.Parse(string.Format("{{\n                    \"name\": \"{0}\",\n                    \"downloads\": {{\n                        \"artifact\": {{\n                            \"path\": \"{1}\",\n                            \"sha1\": \"{2}\",\n                            \"size\": {3},\n                            \"url\": \"{4}\"\n                        }}\n                    }}\n                }}", new object[5]
						{
							current3["name"],
							current3["url"].ToString().Substring(ModBase.LastIndexOfF(current3["url"].ToString(), "https://releases.r2.labymod.net/libraries/") + 42),
							current3["sha1"],
							current3["size"],
							current3["url"]
						})));
					}
				}
				finally
				{
					((System.IDisposable)enumerator3)?.Dispose();
				}
				jArray.Add(JObject.Parse(string.Format("{{\n                    \"name\": \"net.labymod:LabyMod:4\",\n                    \"downloads\": {{\n                        \"artifact\": {{\n                            \"path\": \"net/labymod/LabyMod/4/LabyMod-4.jar\",\n                            \"sha1\": \"{0}\",\n                            \"size\": {1},\n                            \"url\": \"https://releases.r2.labymod.net/api/v1/download/labymod4/{2}/{3}.jar\"\n                        }}\n                    }}\n                }}", new object[4]
				{
					jObject13["sha1"],
					jObject13["size"],
					LabyModChannel.ToString(),
					jObject13["commitReference"].ToString()
				})));
				jObject11["libraries"] = jArray;
				jObject11.Add("labymod_data", JObject.Parse(string.Format("{{\n                \"channelType\": \"{0}\",\n                \"commitReference\": \"{1}\",\n                \"version\": \"{2}\",\n                \"versionType\": \"release\"\n            }}", (object)LabyModChannel, (object)jObject13["commitReference"], (object)jObject13["labyModVersion"])));
			}
			if (text22 != null && Operators.CompareString(text22.Replace(" ", ""), "", false) != 0)
			{
				jObject11["minecraftArguments"] = text22;
			}
			if (MMCPackInfo != null && MMCPackInfo.IsMcArgsEdited)
			{
				jObject11.Remove("minecraftArguments");
			}
			jObject11.Remove("_comment_");
			jObject11.Remove("inheritsFrom");
			jObject11.Remove("jar");
			jObject11["id"] = folderNameFromPath;
			ModBase.WriteFile(filePath2, jObject11.ToString());
			if (Operators.CompareString(text11, text9, false) != 0)
			{
				if (File.Exists(text9))
				{
					File.Delete(text9);
				}
				ModBase.CopyFile(text11, text9);
			}
			ModBase.Log("[Download] 实例合并 " + folderNameFromPath + " 完成");
		}
	}
}
