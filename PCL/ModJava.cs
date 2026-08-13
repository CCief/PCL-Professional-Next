using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.Core.Minecraft;

namespace PCL;

[StandardModule]
public sealed class ModJava
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__11_002D0
	{
		public JProperty _0024VB_0024Local_e;

		public _Closure_0024__11_002D0(_Closure_0024__11_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_e = arg0._0024VB_0024Local_e;
			}
		}

		[SpecialName]
		internal KeyValuePair<string, JObject> _Lambda_0024__1(JToken v)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			return new KeyValuePair<string, JObject>(_0024VB_0024Local_e.Name, (JObject)v);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__11_002D1
	{
		public ModLoader.LoaderTask<int, List<ModNet.NetFile>> _0024VB_0024Local_Loader;

		public _Closure_0024__11_002D1(_Closure_0024__11_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__2(KeyValuePair<string, JObject> t)
		{
			return ModBase.StartsWithF(t.Value["version"]["name"].ToString(), Conversions.ToString(_0024VB_0024Local_Loader.Input));
		}
	}

	public static int JavaListCacheVersion = 7;

	public static object JavaLock = RuntimeHelpers.GetObjectValue(new object());

	private static string LastJavaBaseDir = null;

	public static JavaManager Javas => JavaService.JavaManager;

	public static JavaInfo JavaSelect(string CancelException, Version MinVersion = null, Version MaxVersion = null, ModMinecraft.McInstance RelatedVersion = null)
	{
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		ModBase.Log(string.Format("[Java] 要求选择合适 Java，要求最低版本 {0}，要求选择的最高版本 {1}，关联实例 {2}", (object)((MinVersion != null) ? MinVersion.ToString() : "未指定"), (object)((MaxVersion != null) ? MaxVersion.ToString() : "未指定"), (object)(((object)RelatedVersion != null) ? RelatedVersion.Name : "未指定")));
		VB_0024AnonymousDelegate_9<Version, bool> vB_0024AnonymousDelegate_ = [SpecialName] (Version ver) => ver >= MinVersion && ver <= MaxVersion;
		if ((object)RelatedVersion != null)
		{
			JavaInfo versionUserSetJava = GetVersionUserSetJava(RelatedVersion);
			if (versionUserSetJava != null)
			{
				if (!vB_0024AnonymousDelegate_(versionUserSetJava.Version))
				{
					ModMain.Hint("当前实例所指定的 Java 可能不合适，容易导致游戏崩溃");
				}
				ModBase.Log($"[Java] 返回实例 {RelatedVersion.Name} 指定的 Java {versionUserSetJava.ToString()}");
				return versionUserSetJava;
			}
		}
		JavaInfo javaInfo = JavaInfo.Parse(Conversions.ToString(ModBase.Setup.Get("LaunchArgumentJavaSelect")));
		if (javaInfo != null)
		{
			ModBase.Log($"[Java] 返回全局指定的 Java {javaInfo}");
			return javaInfo;
		}
		Javas.CheckJavaAvailability();
		Version minVersion = (Version)(((object)MinVersion) ?? ((object)new Version(1, 0, 0)));
		Version maxVersion = (Version)(((object)MaxVersion) ?? ((object)new Version(999, 999, 999)));
		JavaInfo javaInfo2 = Enumerable.FirstOrDefault<JavaInfo>((System.Collections.Generic.IEnumerable<JavaInfo>)Javas.SelectSuitableJava(minVersion, maxVersion).Result);
		if (javaInfo2 == null)
		{
			ModBase.Log("[Java] 没有找到合适的 Java 开始尝试重新搜索后选择");
			TaskAwaiter awaiter = Javas.ScanJavaAsync().GetAwaiter();
			awaiter.GetResult();
			javaInfo2 = Enumerable.FirstOrDefault<JavaInfo>((System.Collections.Generic.IEnumerable<JavaInfo>)Javas.SelectSuitableJava(minVersion, maxVersion).Result);
		}
		ModBase.Log(string.Format("[Java] 返回自动选择的 Java {0}", (object)((javaInfo2 != null) ? javaInfo2.ToString() : "无结果")));
		return javaInfo2;
	}

	public static JavaInfo GetVersionUserSetJava(ModMinecraft.McInstance Mc)
	{
		if ((object)Mc == null)
		{
			return null;
		}
		string text = Conversions.ToString(ModBase.Setup.Get("VersionArgumentJavaSelect", Mc));
		if (Operators.CompareString(text, "使用全局设置", false) == 0)
		{
			return null;
		}
		return JavaInfo.Parse(text);
	}

	public static bool IsGameSet64BitJava(ModMinecraft.McInstance RelatedVersion = null)
	{
		try
		{
			string text = Conversions.ToString(ModBase.Setup.Get("LaunchArgumentJavaSelect"));
			if (text.StartsWith("{"))
			{
				JToken jToken = JToken.Parse(text);
				text = string.Format("{0}java.exe", (object)jToken["Path"]);
				ModBase.Setup.Set("LaunchArgumentJavaSelect", text);
			}
			if ((object)RelatedVersion != null)
			{
				string text2 = Conversions.ToString(ModBase.Setup.Get("VersionArgumentJavaSelect", RelatedVersion));
				if (Operators.CompareString(text2, "使用全局设置", false) != 0)
				{
					if (File.Exists(text2))
					{
						return JavaInfo.Parse(text2)?.Is64Bit ?? false;
					}
					ModBase.Setup.Reset("VersionArgumentJavaSelect", forceReload: false, RelatedVersion);
				}
			}
			if (!string.IsNullOrEmpty(text) && !File.Exists(text))
			{
				ModBase.Setup.Set("LaunchArgumentJavaSelect", "");
				text = string.Empty;
			}
			if (string.IsNullOrEmpty(text))
			{
				return Enumerable.Any<JavaInfo>((System.Collections.Generic.IEnumerable<JavaInfo>)Javas.JavaList, (Func<JavaInfo, bool>)([SpecialName] (JavaInfo x) => x.Is64Bit));
			}
			return JavaInfo.Parse(text)?.Is64Bit ?? false;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "检查 Java 类别时出错", ModBase.LogLevel.Feedback);
			if ((object)RelatedVersion != null)
			{
				ModBase.Setup.Reset("VersionArgumentJavaSelect", forceReload: false, RelatedVersion);
			}
			ModBase.Setup.Set("LaunchArgumentJavaSelect", "");
			ProjectData.ClearProjectError();
		}
		return true;
	}

	public static bool JavaDownloadConfirm(string VersionDescription, bool ForcedManualDownload = false)
	{
		if (ForcedManualDownload)
		{
			ModMain.MyMsgBox($"PCL 未找到 {VersionDescription}。" + "\r\n" + $"请自行搜索并安装 {VersionDescription}，安装后在 设置 → 启动选项 → 游戏 Java 中重新搜索或导入。", "未找到 Java");
			return false;
		}
		return ModMain.MyMsgBox($"PCL 未找到 {VersionDescription}，是否需要 PCL 自动下载？" + "\r\n" + $"如果你已经安装了 {VersionDescription}，可以在 设置 → 启动选项 → 游戏 Java 中手动导入。", "自动下载 Java？", "自动下载", "取消") == 1;
	}

	public static ModLoader.LoaderCombo<int> JavaFixLoaders(int Version)
	{
		ModNet.LoaderDownload loaderDownload = new ModNet.LoaderDownload("下载 Java 文件", new List<ModNet.NetFile>())
		{
			ProgressWeight = 10.0
		};
		ModLoader.LoaderCombo<int> result = new ModLoader.LoaderCombo<int>($"下载 Java {Version}", new ModLoader.LoaderBase[2]
		{
			new ModLoader.LoaderTask<int, List<ModNet.NetFile>>("获取 Java 下载信息", JavaFileList, null, (ThreadPriority)2)
			{
				ProgressWeight = 2.0
			},
			loaderDownload
		});
		loaderDownload.OnStateChangedThread += [SpecialName] (ModLoader.LoaderBase Raw, ModBase.LoadState NewState, ModBase.LoadState OldState) =>
		{
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			if ((NewState == ModBase.LoadState.Failed || NewState == ModBase.LoadState.Aborted) && LastJavaBaseDir != null)
			{
				ModBase.Log($"[Java] 由于下载未完成，清理未下载完成的 Java 文件：{LastJavaBaseDir}", ModBase.LogLevel.Debug);
				ModBase.DeleteDirectory(LastJavaBaseDir);
			}
			else if (NewState == ModBase.LoadState.Finished)
			{
				TaskAwaiter awaiter = Javas.ScanJavaAsync().GetAwaiter();
				awaiter.GetResult();
				LastJavaBaseDir = null;
			}
		};
		loaderDownload.HasOnStateChangedThread = true;
		return result;
	}

	private static void JavaFileList(ModLoader.LoaderTask<int, List<ModNet.NetFile>> Loader)
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		_Closure_0024__11_002D1 arg = default(_Closure_0024__11_002D1);
		_Closure_0024__11_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__11_002D1(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader = Loader;
		ModBase.Log("[Java] 开始获取 Java 下载信息");
		KeyValuePair<string, JObject> val = Enumerable.First<KeyValuePair<string, JObject>>(Enumerable.SelectMany<JToken, KeyValuePair<string, JObject>>(Enumerable.Reverse<JToken>((System.Collections.Generic.IEnumerable<JToken>)((JObject)((JObject)ModBase.GetJson(ModNet.NetGetCodeByLoader(ModDownload.DlVersionListOrder(new string[] { "https://piston-meta.mojang.com/v1/products/java-runtime/2ec0cc96c44e5a76b9c8b7c39df7210883d12871/all.json" }, new string[] { "https://bmclapi2.bangbang93.com/v1/products/java-runtime/2ec0cc96c44e5a76b9c8b7c39df7210883d12871/all.json" }), 45000, IsJson: true)))[string.Format("windows-x{0}", (object)(ModBase.Is32BitSystem ? "86" : "64"))]).Children()), (Func<JToken, System.Collections.Generic.IEnumerable<KeyValuePair<string, JObject>>>)([SpecialName] (JToken a0) => ((VB_0024AnonymousDelegate_10<JProperty, System.Collections.Generic.IEnumerable<KeyValuePair<string, JObject>>>)([SpecialName] (JProperty e) =>
		{
			_Closure_0024__11_002D0 arg2 = default(_Closure_0024__11_002D0);
			_Closure_0024__11_002D0 CS_0024_003C_003E8__locals1 = new _Closure_0024__11_002D0(null);
			CS_0024_003C_003E8__locals1._0024VB_0024Local_e = e;
			return Enumerable.Select<JToken, KeyValuePair<string, JObject>>((System.Collections.Generic.IEnumerable<JToken>)(JArray)CS_0024_003C_003E8__locals1._0024VB_0024Local_e.Value, (Func<JToken, KeyValuePair<string, JObject>>)([SpecialName] (JToken v) => new KeyValuePair<string, JObject>(CS_0024_003C_003E8__locals1._0024VB_0024Local_e.Name, (JObject)v)));
		}))((JProperty)a0))), (Func<KeyValuePair<string, JObject>, bool>)([SpecialName] (KeyValuePair<string, JObject> t) => ModBase.StartsWithF(t.Value["version"]["name"].ToString(), Conversions.ToString(CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input))));
		string text = (string?)val.Value["manifest"]["url"];
		ModBase.Log(string.Format("[Java] 准备下载 Java {0}（{1}）：{2}", (object)val.Value["version"]["name"], (object)val.Key, (object)text));
		string data = ModNet.NetGetCodeByLoader(ModDownload.DlSourceOrder(new string[] { text }, new string[] { text.Replace("piston-meta.mojang.com", "bmclapi2.bangbang93.com") }), 45000, IsJson: true);
		LastJavaBaseDir = Environment.GetFolderPath((System.Environment.SpecialFolder)26) + "\\.minecraft\\runtime\\" + val.Key + "\\";
		List<ModNet.NetFile> val2 = new List<ModNet.NetFile>();
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator = ((System.Collections.Generic.IEnumerable<JToken>)((JObject)ModBase.GetJson(data))["files"]).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				JProperty jProperty = (JProperty)enumerator.Current;
				if (((JObject)jProperty.Value)["downloads"]?["raw"] != null)
				{
					JObject jObject = (JObject)((JObject)jProperty.Value)["downloads"]["raw"];
					ModBase.FileChecker fileChecker = new ModBase.FileChecker(-1L, (long)jObject["size"], (string?)jObject["sha1"]);
					if (Operators.CompareString(fileChecker.Hash, "12976a6c2b227cbac58969c1455444596c894656", false) != 0 && Operators.CompareString(fileChecker.Hash, "c80e4bab46e34d02826eab226a4441d0970f2aba", false) != 0 && Operators.CompareString(fileChecker.Hash, "84d2102ad171863db04e7ee22a259d1f6c5de4a5", false) != 0 && fileChecker.Check(LastJavaBaseDir + jProperty.Name) != null)
					{
						string text2 = (string?)jObject["url"];
						val2.Add(new ModNet.NetFile(ModDownload.DlSourceOrder(new string[] { text2 }, new string[] { text2.Replace("piston-data.mojang.com", "bmclapi2.bangbang93.com") }), LastJavaBaseDir + jProperty.Name, fileChecker));
					}
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Output = val2;
		ModBase.Log($"[Java] 需要下载 {val2.Count} 个文件，目标文件夹：{LastJavaBaseDir}");
	}
}
