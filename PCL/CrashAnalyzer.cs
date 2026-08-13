using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Logging;
using PCL.Core.UI;
using PCL.Core.Utils;
using PCL.Core.Utils.Codecs;
using PCL.Core.Utils.Exts;

namespace PCL;

public class CrashAnalyzer
{
	public enum AnalyzeFileType
	{
		HsErr,
		MinecraftLog,
		ExtraLogFile,
		ExtraReportFile,
		CrashReport
	}

	private enum CrashReason
	{
		Mod文件被解压,
		MixinBootstrap缺失,
		内存不足,
		使用JDK,
		显卡不支持OpenGL,
		使用OpenJ9,
		Java版本过高,
		Java版本不兼容,
		Mod名称包含特殊字符,
		显卡驱动不支持导致无法设置像素格式,
		极短的程序输出,
		Intel驱动不兼容导致EXCEPTION_ACCESS_VIOLATION,
		AMD驱动不兼容导致EXCEPTION_ACCESS_VIOLATION,
		Nvidia驱动不兼容导致EXCEPTION_ACCESS_VIOLATION,
		玩家手动触发调试崩溃,
		光影或资源包导致OpenGL1282错误,
		文件或内容校验失败,
		确定Mod导致游戏崩溃,
		怀疑Mod导致游戏崩溃,
		Mod配置文件导致游戏崩溃,
		ModMixin失败,
		Mod加载器报错,
		Mod初始化失败,
		堆栈分析发现关键字,
		堆栈分析发现Mod名称,
		OptiFine导致无法加载世界,
		特定方块导致崩溃,
		特定实体导致崩溃,
		材质过大或显卡配置不足,
		没有可用的分析文件,
		使用32位Java导致JVM无法分配足够多的内存,
		Mod重复安装,
		Mod互不兼容,
		OptiFine与Forge不兼容,
		Fabric报错,
		Fabric报错并给出解决方案,
		Forge报错,
		低版本Forge与高版本Java不兼容,
		实例Json中存在多个Forge,
		Mod过多导致超出ID限制,
		NightConfig的Bug,
		ShadersMod与OptiFine同时安装,
		Forge安装不完整,
		Mod需要Java11,
		Mod缺少前置或MC版本错误
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<string, bool> _0024I7_002D0;

		public static Func<KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>, bool> _0024I7_002D1;

		public static Func<KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>, KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>> _0024I7_002D2;

		public static Func<string, string> _0024I20_002D0;

		public static Func<string, string> _0024I23_002D0;

		public static Action _0024I28_002D1;

		public static Func<string, bool> _0024I29_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal bool _Lambda_0024__7_002D0(string s)
		{
			return s.Contains("以下为游戏输出的最后一段内容");
		}

		[SpecialName]
		internal bool _Lambda_0024__7_002D1(KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>> p)
		{
			return p.Key == AnalyzeFileType.ExtraLogFile;
		}

		[SpecialName]
		internal KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>> _Lambda_0024__7_002D2(KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>> p)
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return new KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>(AnalyzeFileType.MinecraftLog, p.Value);
		}

		[SpecialName]
		internal string _Lambda_0024__20_002D0(string s)
		{
			return s.Trim("\r\n\t ".ToCharArray());
		}

		[SpecialName]
		internal string _Lambda_0024__23_002D0(string s)
		{
			return s.Replace("$", ".");
		}

		[SpecialName]
		internal void _Lambda_0024__28_002D1()
		{
			ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSetup, FormMain.PageSubType.VersionInstall);
		}

		[SpecialName]
		internal bool _Lambda_0024__29_002D0(string r)
		{
			return ModBase.EndsWithF(r, "\\h");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__28_002D0
	{
		public string _0024VB_0024Local_FileAddress;

		public _Closure_0024__28_002D0(_Closure_0024__28_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_FileAddress = arg0._0024VB_0024Local_FileAddress;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			_0024VB_0024Local_FileAddress = SystemDialogs.SelectSaveFile("选择保存位置", "错误报告-" + System.DateTime.Now.ToString("G").Replace("/", "-").Replace(":", ".")
				.Replace(" ", "_") + ".zip", "Minecraft 错误报告(*.zip)|*.zip");
		}
	}

	private string TempFolder;

	private List<KeyValuePair<string, string[]>> AnalyzeRawFiles;

	private KeyValuePair<string, string[]>? DirectFile;

	private string LogMc;

	private string LogMcDebug;

	private string LogHs;

	private string LogCrash;

	private string LogAll;

	private Dictionary<CrashReason, List<string>> CrashReasons;

	private ModMinecraft.McInstance _version;

	private List<string> OutputFiles;

	public CrashAnalyzer(int UUID)
	{
		AnalyzeRawFiles = new List<KeyValuePair<string, string[]>>();
		DirectFile = null;
		LogMc = null;
		LogMcDebug = null;
		LogHs = null;
		LogCrash = null;
		CrashReasons = new Dictionary<CrashReason, List<string>>();
		_version = null;
		OutputFiles = new List<string>();
		TempFolder = ModMain.RequestTaskTempFolder();
		Directory.CreateDirectory(TempFolder + "Temp\\");
		Directory.CreateDirectory(TempFolder + "Report\\");
		ModBase.Log("[Crash] 崩溃分析暂存文件夹：" + TempFolder);
	}

	public void Collect(string VersionPathIndie, System.Collections.Generic.IList<string> LatestLog = null)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		ModBase.Log("[Crash] 步骤 1：收集日志文件");
		List<string> val = new List<string>();
		try
		{
			DirectoryInfo val2 = new DirectoryInfo(VersionPathIndie + "crash-reports\\");
			if (val2.Exists)
			{
				System.Collections.Generic.IEnumerator<FileInfo> enumerator = default(System.Collections.Generic.IEnumerator<FileInfo>);
				try
				{
					enumerator = val2.EnumerateFiles().GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						FileInfo current = enumerator.Current;
						val.Add(((FileSystemInfo)current).FullName);
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "收集 Minecraft 崩溃日志文件夹下的日志失败");
			ProjectData.ClearProjectError();
		}
		try
		{
			System.Collections.Generic.IEnumerator<FileInfo> enumerator2 = default(System.Collections.Generic.IEnumerator<FileInfo>);
			try
			{
				enumerator2 = new DirectoryInfo(VersionPathIndie).Parent.Parent.EnumerateFiles().GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator2).MoveNext())
				{
					FileInfo current2 = enumerator2.Current;
					if (Operators.CompareString(((FileSystemInfo)current2).Extension ?? "", ".log", false) == 0)
					{
						val.Add(((FileSystemInfo)current2).FullName);
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
			ModBase.Log(ex4, "收集 Minecraft 主文件夹下的日志失败");
			ProjectData.ClearProjectError();
		}
		try
		{
			System.Collections.Generic.IEnumerator<FileInfo> enumerator3 = default(System.Collections.Generic.IEnumerator<FileInfo>);
			try
			{
				enumerator3 = new DirectoryInfo(VersionPathIndie).EnumerateFiles().GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator3).MoveNext())
				{
					FileInfo current3 = enumerator3.Current;
					if (Operators.CompareString(((FileSystemInfo)current3).Extension ?? "", ".log", false) == 0)
					{
						val.Add(((FileSystemInfo)current3).FullName);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator3)?.Dispose();
			}
		}
		catch (System.Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			System.Exception ex6 = ex5;
			ModBase.Log(ex6, "收集 Minecraft 隔离文件夹下的日志失败");
			ProjectData.ClearProjectError();
		}
		val.Add(VersionPathIndie + "logs\\latest.log");
		if (ModBase.ContainsF(ModBase.ReadFile(ModBase.ExePath + "PCL\\LatestLaunch.bat"), "-Dlog4j2.formatMsgNoLookups=false"))
		{
			val.Add(VersionPathIndie + "logs\\debug.log");
		}
		val = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val));
		List<string> val3 = new List<string>();
		System.Collections.Generic.IEnumerator<string> enumerator4 = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator4 = val.GetEnumerator();
			while (enumerator4.MoveNext())
			{
				string current4 = enumerator4.Current;
				try
				{
					FileInfo val4 = new FileInfo(current4);
					if (val4.Exists)
					{
						TimeSpan val5 = ((FileSystemInfo)val4).LastWriteTime - System.DateTime.Now;
						double num = Math.Abs(val5.TotalMinutes);
						if (num < 3.0 && val4.Length > 0)
						{
							val3.Add(current4);
							ModBase.Log(string.Concat(new string[5]
							{
								"[Crash] 可能可用的日志文件：",
								current4,
								"（",
								Conversions.ToString(Math.Round(num, 1)),
								" 分钟）"
							}));
						}
					}
				}
				catch (System.Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					System.Exception ex8 = ex7;
					ModBase.Log(ex8, "确认崩溃日志时间失败（" + current4 + "）");
					ProjectData.ClearProjectError();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator4).Dispose();
		}
		if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val3))
		{
			ModBase.Log("[Crash] 未发现可能可用的日志文件");
		}
		System.Collections.Generic.IEnumerator<string> enumerator5 = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator5 = val3.GetEnumerator();
			while (enumerator5.MoveNext())
			{
				string current5 = enumerator5.Current;
				try
				{
					AnalyzeRawFiles.Add(new KeyValuePair<string, string[]>(current5, ModBase.ReadFile(current5).Split("\r\n".ToCharArray())));
				}
				catch (System.Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					System.Exception ex10 = ex9;
					ModBase.Log(ex10, "读取可能的崩溃日志文件失败（" + current5 + "）");
					ProjectData.ClearProjectError();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator5).Dispose();
		}
		if (LatestLog != null && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)LatestLog))
		{
			string text = ModBase.Join((System.Collections.IEnumerable)LatestLog, "\r\n");
			ModBase.Log("[Crash] 以下为游戏输出的最后一段内容：\r\n" + text);
			ModBase.WriteFile(TempFolder + "RawOutput.log", text);
			AnalyzeRawFiles.Add(new KeyValuePair<string, string[]>(TempFolder + "RawOutput.log", Enumerable.ToArray<string>((System.Collections.Generic.IEnumerable<string>)LatestLog)));
			((System.Collections.Generic.ICollection<string>)LatestLog).Clear();
		}
		ModBase.Log("[Crash] 步骤 1：收集日志文件完成，收集到 " + Conversions.ToString(AnalyzeRawFiles.Count) + " 个文件");
	}

	public void Import(string FilePath)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		ModBase.Log("[Crash] 步骤 1：自主导入日志文件");
		try
		{
			FileInfo val = new FileInfo(FilePath);
			if (val.Exists && val.Length > 0 && !ModBase.EndsWithF(FilePath, ".jar", IgnoreCase: true))
			{
				ModBase.ExtractFile(FilePath, TempFolder + "Temp\\");
				ModBase.Log("[Crash] 已解压导入的日志文件：" + FilePath);
				goto IL_00a8;
			}
		}
		catch (System.Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		ModBase.CopyFile(FilePath, TempFolder + "Temp\\" + ModBase.GetFileNameFromPath(FilePath));
		ModBase.Log("[Crash] 已复制导入的日志文件：" + FilePath);
		goto IL_00a8;
		IL_00a8:
		System.Collections.Generic.IEnumerator<FileInfo> enumerator = default(System.Collections.Generic.IEnumerator<FileInfo>);
		try
		{
			enumerator = Enumerable.ToList<FileInfo>(new DirectoryInfo(TempFolder + "Temp\\").EnumerateFiles()).GetEnumerator();
			while (enumerator.MoveNext())
			{
				FileInfo current = enumerator.Current;
				try
				{
					if (current.Exists && current.Length != 0L)
					{
						string text = ((FileSystemInfo)current).Extension.ToLower();
						if (Operators.CompareString(text, ".log", false) == 0 || Operators.CompareString(text, ".txt", false) == 0)
						{
							AnalyzeRawFiles.Add(new KeyValuePair<string, string[]>(((FileSystemInfo)current).FullName, ModBase.ReadFile(((FileSystemInfo)current).FullName).Split("\r\n".ToCharArray())));
						}
						else
						{
							File.Delete(((FileSystemInfo)current).FullName);
						}
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "导入单个日志文件失败");
					ProjectData.ClearProjectError();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		ModBase.Log("[Crash] 步骤 1：自主导入日志文件，收集到 " + Conversions.ToString(AnalyzeRawFiles.Count) + " 个文件");
	}

	public bool Prepare()
	{
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_0517: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_0527: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0718: Unknown result type (might be due to invalid IL or missing references)
		//IL_071d: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_084b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_0854: Unknown result type (might be due to invalid IL or missing references)
		//IL_0859: Unknown result type (might be due to invalid IL or missing references)
		ModBase.Log("[Crash] 步骤 2：准备日志文本");
		DirectFile = null;
		List<KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>> val = new List<KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>>();
		System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string[]>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string[]>>);
		try
		{
			enumerator = AnalyzeRawFiles.GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, string[]> current = enumerator.Current;
				string text = ModBase.GetFileNameFromPath(current.Key).ToLower();
				AnalyzeFileType analyzeFileType;
				if (ModBase.StartsWithF(text, "hs_err"))
				{
					analyzeFileType = AnalyzeFileType.HsErr;
					DirectFile = current;
				}
				else if (ModBase.StartsWithF(text, "crash-"))
				{
					analyzeFileType = AnalyzeFileType.CrashReport;
					DirectFile = current;
				}
				else
				{
					switch (text)
					{
					case "latest.log":
					case "latest log.txt":
					case "debug.log":
					case "debug log.txt":
					case "游戏崩溃前的输出.txt":
					case "rawoutput.log":
						analyzeFileType = AnalyzeFileType.MinecraftLog;
						if (!DirectFile.HasValue)
						{
							DirectFile = current;
						}
						break;
					case "启动器日志.txt":
					case "PCL2 启动器日志.txt":
					case "PCL 启动器日志.txt":
					case "log1.txt":
					case "log-ce1.log":
						if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)current.Value, (Func<string, bool>)([SpecialName] (string s) => s.Contains("以下为游戏输出的最后一段内容"))))
						{
							analyzeFileType = AnalyzeFileType.MinecraftLog;
							if (!DirectFile.HasValue)
							{
								DirectFile = current;
							}
						}
						else
						{
							analyzeFileType = AnalyzeFileType.ExtraLogFile;
						}
						break;
					default:
						if (ModBase.EndsWithF(text, ".log", IgnoreCase: true))
						{
							analyzeFileType = AnalyzeFileType.ExtraLogFile;
							break;
						}
						if (ModBase.EndsWithF(text, ".txt", IgnoreCase: true))
						{
							analyzeFileType = AnalyzeFileType.ExtraReportFile;
							break;
						}
						ModBase.Log("[Crash] " + text + " 分类为 Ignore");
						continue;
					}
				}
				if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)current.Value))
				{
					val.Add(new KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>(analyzeFileType, current));
					ModBase.Log("[Crash] " + text + " 分类为 " + ModBase.GetStringFromEnum(analyzeFileType));
				}
				else
				{
					ModBase.Log("[Crash] " + text + " 由于内容为空跳过");
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		if (Enumerable.Any<KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>>((System.Collections.Generic.IEnumerable<KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>>)val) && Enumerable.All<KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>>((System.Collections.Generic.IEnumerable<KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>>)val, (Func<KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>, bool>)([SpecialName] (KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>> p) => p.Key == AnalyzeFileType.ExtraLogFile)))
		{
			ModBase.Log("[Crash] 由于仅发现了额外日志，将它们视作 Minecraft 日志进行分析");
			val = Enumerable.ToList<KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>>(Enumerable.Select<KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>, KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>>((System.Collections.Generic.IEnumerable<KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>>)val, (Func<KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>, KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>>)([SpecialName] (KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>> p) => new KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>(AnalyzeFileType.MinecraftLog, p.Value))));
		}
		AnalyzeFileType[] array = new AnalyzeFileType[] { (AnalyzeFileType)1, (AnalyzeFileType)0, (AnalyzeFileType)2, (AnalyzeFileType)4 };
		AnalyzeFileType[] array2 = array;
		System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>> enumerator2 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>>>);
		System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string[]>> enumerator5 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string[]>>);
		System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string[]>> enumerator4 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string[]>>);
		System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string[]>> enumerator3 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string[]>>);
		foreach (AnalyzeFileType analyzeFileType2 in array2)
		{
			List<KeyValuePair<string, string[]>> val2 = new List<KeyValuePair<string, string[]>>();
			try
			{
				enumerator2 = val.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					KeyValuePair<AnalyzeFileType, KeyValuePair<string, string[]>> current2 = enumerator2.Current;
					if (analyzeFileType2 == current2.Key)
					{
						val2.Add(current2.Value);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			if (!Enumerable.Any<KeyValuePair<string, string[]>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, string[]>>)val2))
			{
				continue;
			}
			try
			{
				switch (analyzeFileType2)
				{
				case AnalyzeFileType.HsErr:
				case AnalyzeFileType.CrashReport:
				{
					SortedList<System.DateTime, KeyValuePair<string, string[]>> val7 = new SortedList<System.DateTime, KeyValuePair<string, string[]>>();
					try
					{
						enumerator5 = val2.GetEnumerator();
						while (enumerator5.MoveNext())
						{
							KeyValuePair<string, string[]> current5 = enumerator5.Current;
							try
							{
								val7.Add(((FileSystemInfo)new FileInfo(current5.Key)).LastWriteTime, current5);
							}
							catch (System.Exception ex)
							{
								ProjectData.SetProjectError(ex);
								System.Exception ex2 = ex;
								ModBase.Log(ex2, "获取日志文件修改时间失败");
								val7.Add(new System.DateTime(1900, 1, 1), current5);
								ProjectData.ClearProjectError();
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator5).Dispose();
					}
					KeyValuePair<string, string[]> value3 = Enumerable.Last<KeyValuePair<System.DateTime, KeyValuePair<string, string[]>>>((System.Collections.Generic.IEnumerable<KeyValuePair<System.DateTime, KeyValuePair<string, string[]>>>)val7).Value;
					OutputFiles.Add(value3.Key);
					if (analyzeFileType2 == AnalyzeFileType.HsErr)
					{
						LogHs = GetHeadTailLines(value3.Value, 200, 100);
						ModBase.Log("[Crash] 输出报告：" + value3.Key + "，作为虚拟机错误信息");
						ModBase.Log("[Crash] 导入分析：" + value3.Key + "，作为虚拟机错误信息");
					}
					else
					{
						LogCrash = GetHeadTailLines(value3.Value, 300, 700);
						ModBase.Log("[Crash] 输出报告：" + value3.Key + "，作为 Minecraft 崩溃报告");
						ModBase.Log("[Crash] 导入分析：" + value3.Key + "，作为 Minecraft 崩溃报告");
					}
					break;
				}
				case AnalyzeFileType.MinecraftLog:
				{
					LogMc = "";
					LogMcDebug = "";
					Dictionary<string, KeyValuePair<string, string[]>> val3 = new Dictionary<string, KeyValuePair<string, string[]>>();
					try
					{
						enumerator4 = val2.GetEnumerator();
						while (enumerator4.MoveNext())
						{
							KeyValuePair<string, string[]> current4 = enumerator4.Current;
							val3[ModBase.GetFileNameFromPath(current4.Key).ToLower()] = current4;
							OutputFiles.Add(current4.Key);
							ModBase.Log("[Crash] 输出报告：" + current4.Key + "，作为 Minecraft 或启动器日志");
						}
					}
					finally
					{
						((System.IDisposable)enumerator4).Dispose();
					}
					string[] array3 = new string[] { "rawoutput.log", "启动器日志.txt", "log1.txt", "log-ce1.log", "游戏崩溃前的输出.txt", "PCL2 启动器日志.txt", "PCL 启动器日志.txt" };
					foreach (string text2 in array3)
					{
						if (!val3.ContainsKey(text2))
						{
							continue;
						}
						KeyValuePair<string, string[]> val4 = val3[text2];
						bool flag = false;
						string[] value = val4.Value;
						foreach (string text3 in value)
						{
							if (flag)
							{
								ref string logMc = ref LogMc;
								logMc = logMc + text3 + "\n";
							}
							else if (text3.Contains("以下为游戏输出的最后一段内容"))
							{
								flag = true;
								ModBase.Log("[Crash] 找到 PCL 输出的游戏实时日志头");
							}
						}
						if (!flag)
						{
							LogMc += GetHeadTailLines(val4.Value, 0, 500);
						}
						LogMc = LogMc.TrimEnd("\r\n".ToCharArray());
						ModBase.Log("[Crash] 导入分析：" + val4.Key + "，作为启动器日志");
						break;
					}
					string[] array4 = new string[] { "latest.log", "latest log.txt", "debug.log", "debug log.txt" };
					foreach (string text4 in array4)
					{
						if (val3.ContainsKey(text4))
						{
							KeyValuePair<string, string[]> val5 = val3[text4];
							LogMc += GetHeadTailLines(val5.Value, 1500, 500);
							ModBase.Log("[Crash] 导入分析：" + val5.Key + "，作为 Minecraft 日志");
							break;
						}
					}
					string[] array5 = new string[] { "debug.log", "debug log.txt" };
					foreach (string text5 in array5)
					{
						if (val3.ContainsKey(text5))
						{
							KeyValuePair<string, string[]> val6 = val3[text5];
							LogMcDebug += GetHeadTailLines(val6.Value, 1000, 0);
							ModBase.Log("[Crash] 导入分析：" + val6.Key + "，作为 Minecraft Debug 日志");
							break;
						}
					}
					if (Operators.CompareString(LogMc, "", false) == 0)
					{
						if (Operators.CompareString(LogMcDebug, "", false) != 0)
						{
							LogMc = LogMcDebug;
						}
						else
						{
							if (!Enumerable.Any<KeyValuePair<string, KeyValuePair<string, string[]>>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, KeyValuePair<string, string[]>>>)val3))
							{
								LogMc = null;
								throw new System.Exception("无法找到匹配的 Minecraft Log");
							}
							KeyValuePair<string, string[]> value2 = Enumerable.First<KeyValuePair<string, KeyValuePair<string, string[]>>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, KeyValuePair<string, string[]>>>)val3).Value;
							LogMc += GetHeadTailLines(value2.Value, 1500, 500);
							ModBase.Log("[Crash] 导入分析：" + value2.Key + "，作为兜底日志");
						}
					}
					if (Operators.CompareString(LogMcDebug, "", false) == 0)
					{
						LogMcDebug = null;
					}
					break;
				}
				case AnalyzeFileType.ExtraLogFile:
				case AnalyzeFileType.ExtraReportFile:
					try
					{
						enumerator3 = val2.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							KeyValuePair<string, string[]> current3 = enumerator3.Current;
							OutputFiles.Add(current3.Key);
							ModBase.Log("[Crash] 输出报告：" + current3.Key + "，不用作分析");
						}
					}
					finally
					{
						((System.IDisposable)enumerator3).Dispose();
					}
					break;
				}
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "分类处理日志文件时出错");
				ProjectData.ClearProjectError();
			}
		}
		bool flag2 = LogMc != null || LogHs != null || LogCrash != null;
		if (flag2)
		{
			ModBase.Log(string.Concat(new string[5]
			{
				"[Crash] 步骤 2：准备日志文本完成，找到",
				(LogMc == null) ? "" : "游戏日志、",
				(LogMcDebug == null) ? "" : "游戏 Debug 日志、",
				(LogHs == null) ? "" : "虚拟机日志、",
				(LogCrash == null) ? "" : "崩溃日志、"
			}).TrimEnd('、') + "用作分析");
		}
		else
		{
			ModBase.Log("[Crash] 步骤 2：准备日志文本完成，没有任何可供分析的日志");
		}
		return flag2;
	}

	private string GetHeadTailLines(string[] Raw, int HeadLines, int TailLines)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Raw.Length <= HeadLines + TailLines)
			{
				return ModBase.Join((System.Collections.IEnumerable)Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)Raw), "\n");
			}
			List<string> val = new List<string>();
			int num = 0;
			int num2 = Raw.Length - 1;
			int i;
			for (i = 0; i <= num2; i++)
			{
				if (!val.Contains(Raw[i]))
				{
					num++;
					val.Add(Raw[i]);
					if (num >= HeadLines)
					{
						break;
					}
				}
			}
			int num3 = 0;
			int num4 = Raw.Length - 1;
			int num5 = i;
			for (int j = num4; j >= num5; j += -1)
			{
				if (!val.Contains(Raw[j]))
				{
					num3++;
					val.Insert(num, Raw[j]);
					if (num3 >= TailLines)
					{
						break;
					}
				}
			}
			StringBuilder val2 = new StringBuilder();
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = val.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					if (Operators.CompareString(current, "", false) != 0)
					{
						val2.Append(current);
						val2.Append("\n");
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			return val2.ToString();
		}
	}

	public void Analyze(ModMinecraft.McInstance version = null)
	{
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		_version = version;
		ModBase.Log("[Crash] 步骤 3：分析崩溃原因");
		LogAll = (LogMc ?? LogMcDebug ?? "") + LogHs + LogCrash;
		if (LogAll.Contains("quilt") && LogAll.Contains("Mod Table Version"))
		{
			ModBase.Log("[Crash] 处理 Quilt Mod Table 后再继续分析");
			string text = ModBase.BeforeFirst(LogAll, "| Index");
			string text2 = ModBase.AfterFirst(LogAll, "Mod Table Version:");
			LogAll = text + text2;
		}
		AnalyzeCrit1();
		if (!Enumerable.Any<KeyValuePair<CrashReason, List<string>>>((System.Collections.Generic.IEnumerable<KeyValuePair<CrashReason, List<string>>>)CrashReasons))
		{
			AnalyzeCrit2();
			if (!Enumerable.Any<KeyValuePair<CrashReason, List<string>>>((System.Collections.Generic.IEnumerable<KeyValuePair<CrashReason, List<string>>>)CrashReasons))
			{
				if (LogAll.Contains("orge") || LogAll.Contains("abric") || LogAll.Contains("uilt") || LogAll.Contains("iteloader"))
				{
					List<string> val = new List<string>();
					if (LogCrash != null)
					{
						ModBase.Log("[Crash] 开始进行崩溃日志堆栈分析");
						val.AddRange((System.Collections.Generic.IEnumerable<string>)AnalyzeStackKeyword(ModBase.BeforeFirst(LogCrash, "System Details")));
					}
					if (LogMc != null)
					{
						List<string> val2 = ModBase.RegexSearch(LogMc, "/FATAL] .+?(?=[\\n]+\\[)", (RegexOptions)0);
						if (LogMc.Contains("Unreported exception thrown!"))
						{
							val2.Add(ModBase.Between(LogMc, "Unreported exception thrown!", "at oolloo.jlw.Wrapper"));
						}
						ModBase.Log("[Crash] 开始进行 Minecraft 日志堆栈分析，发现 " + Conversions.ToString(val2.Count) + " 个报错项");
						System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
						try
						{
							enumerator = val2.GetEnumerator();
							while (enumerator.MoveNext())
							{
								string current = enumerator.Current;
								val.AddRange((System.Collections.Generic.IEnumerable<string>)AnalyzeStackKeyword(current));
							}
						}
						finally
						{
							((System.IDisposable)enumerator).Dispose();
						}
					}
					if (LogHs != null)
					{
						ModBase.Log("[Crash] 开始进行虚拟机堆栈分析");
						string errorStack = ModBase.Between(LogHs, "T H R E A D", "Registers:");
						val.AddRange((System.Collections.Generic.IEnumerable<string>)AnalyzeStackKeyword(errorStack));
					}
					if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val))
					{
						List<string> val3 = AnalyzeModName(val);
						if (val3 == null)
						{
							AppendReason(CrashReason.堆栈分析发现关键字, (System.Collections.Generic.ICollection<string>)val);
						}
						else
						{
							AppendReason(CrashReason.堆栈分析发现Mod名称, (System.Collections.Generic.ICollection<string>)val3);
						}
						goto IL_0288;
					}
				}
				else
				{
					ModBase.Log("[Crash] 可能并未安装 Mod，不进行堆栈分析");
				}
				AnalyzeCrit3();
			}
		}
		goto IL_0288;
		IL_0288:
		if (!Enumerable.Any<KeyValuePair<CrashReason, List<string>>>((System.Collections.Generic.IEnumerable<KeyValuePair<CrashReason, List<string>>>)CrashReasons))
		{
			ModBase.Log("[Crash] 步骤 3：分析崩溃原因完成，未找到可能的原因");
			return;
		}
		ModBase.Log("[Crash] 步骤 3：分析崩溃原因完成，找到 " + Conversions.ToString(CrashReasons.Count) + " 条可能的原因");
		System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<CrashReason, List<string>>> enumerator2 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<CrashReason, List<string>>>);
		try
		{
			enumerator2 = CrashReasons.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				KeyValuePair<CrashReason, List<string>> current2 = enumerator2.Current;
				ModBase.Log("[Crash]  - " + ModBase.GetStringFromEnum(current2.Key) + (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)current2.Value) ? ("（" + ModBase.Join((System.Collections.IEnumerable)current2.Value, "；") + "）") : ""));
			}
		}
		finally
		{
			((System.IDisposable)enumerator2).Dispose();
		}
	}

	private void AppendReason(CrashReason Reason, System.Collections.Generic.ICollection<string> Additional = null)
	{
		if (CrashReasons.ContainsKey(Reason))
		{
			if (Additional != null)
			{
				CrashReasons[Reason].AddRange((System.Collections.Generic.IEnumerable<string>)Additional);
				CrashReasons[Reason] = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)CrashReasons[Reason]));
			}
		}
		else
		{
			CrashReasons.Add(Reason, new List<string>((System.Collections.Generic.IEnumerable<string>)(Additional ?? new string[0])));
		}
		ModBase.Log("[Crash] 可能的崩溃原因：" + ModBase.GetStringFromEnum(Reason) + ((Additional != null && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)Additional)) ? ("（" + ModBase.Join((System.Collections.IEnumerable)Additional, "；") + "）") : ""));
	}

	private void AppendReason(CrashReason Reason, string Additional)
	{
		object obj;
		if (!string.IsNullOrEmpty(Additional))
		{
			obj = new List<string>();
			((List<string>)obj).Add(Additional);
		}
		else
		{
			obj = null;
		}
		AppendReason(Reason, (System.Collections.Generic.ICollection<string>)obj);
	}

	private void AnalyzeCrit1()
	{
		if (LogMc == null && LogHs == null && LogCrash == null)
		{
			AppendReason(CrashReason.没有可用的分析文件);
			return;
		}
		if (LogCrash != null && LogCrash.Contains("Unable to make protected final java.lang.Class java.lang.ClassLoader.defineClass"))
		{
			AppendReason(CrashReason.Java版本过高);
		}
		if (LogMc != null)
		{
			if (LogMc.Contains("Found multiple arguments for option fml.forgeVersion, but you asked for only one"))
			{
				AppendReason(CrashReason.实例Json中存在多个Forge);
			}
			if (LogMc.Contains("The driver does not appear to support OpenGL"))
			{
				AppendReason(CrashReason.显卡不支持OpenGL);
			}
			if (LogMc.Contains("java.lang.ClassCastException: java.base/jdk"))
			{
				AppendReason(CrashReason.使用JDK);
			}
			if (LogMc.Contains("java.lang.ClassCastException: class jdk."))
			{
				AppendReason(CrashReason.使用JDK);
			}
			if (LogMc.Contains("TRANSFORMER/net.optifine/net.optifine.reflect.Reflector.<clinit>(Reflector.java"))
			{
				AppendReason(CrashReason.OptiFine与Forge不兼容);
			}
			if (LogMc.Contains("java.lang.NoSuchMethodError: 'void net.minecraft.client.renderer.texture.SpriteContents.<init>"))
			{
				AppendReason(CrashReason.OptiFine与Forge不兼容);
			}
			if (LogMc.Contains("java.lang.NoSuchMethodError: 'java.lang.String com.mojang.blaze3d.systems.RenderSystem.getBackendDescription"))
			{
				AppendReason(CrashReason.OptiFine与Forge不兼容);
			}
			if (LogMc.Contains("java.lang.NoSuchMethodError: 'void net.minecraft.client.renderer.block.model.BakedQuad.<init>"))
			{
				AppendReason(CrashReason.OptiFine与Forge不兼容);
			}
			if (LogMc.Contains("java.lang.NoSuchMethodError: 'void net.minecraftforge.client.gui.overlay.ForgeGui.renderSelectedItemName"))
			{
				AppendReason(CrashReason.OptiFine与Forge不兼容);
			}
			if (LogMc.Contains("java.lang.NoSuchMethodError: 'void net.minecraft.server.level.DistanceManager"))
			{
				AppendReason(CrashReason.OptiFine与Forge不兼容);
			}
			if (LogMc.Contains("java.lang.NoSuchMethodError: 'net.minecraft.network.chat.FormattedText net.minecraft.client.gui.Font.ellipsize"))
			{
				AppendReason(CrashReason.OptiFine与Forge不兼容);
			}
			if (LogMc.Contains("Open J9 is not supported") || LogMc.Contains("OpenJ9 is incompatible") || LogMc.Contains(".J9VMInternals."))
			{
				AppendReason(CrashReason.使用OpenJ9);
			}
			if (LogMc.Contains("java.lang.NoSuchFieldException: ucp"))
			{
				AppendReason(CrashReason.Java版本过高);
			}
			if (LogMc.Contains("because module java.base does not export"))
			{
				AppendReason(CrashReason.Java版本过高);
			}
			if (LogMc.Contains("java.lang.ClassNotFoundException: jdk.nashorn.api.scripting.NashornScriptEngineFactory"))
			{
				AppendReason(CrashReason.Java版本过高);
			}
			if (LogMc.Contains("java.lang.ClassNotFoundException: java.lang.invoke.LambdaMetafactory"))
			{
				AppendReason(CrashReason.Java版本过高);
			}
			if (LogMc.Contains("The directories below appear to be extracted jar files. Fix this before you continue."))
			{
				AppendReason(CrashReason.Mod文件被解压);
			}
			if (LogMc.Contains("Extracted mod jars found, loading will NOT continue"))
			{
				AppendReason(CrashReason.Mod文件被解压);
			}
			if (LogMc.Contains("java.lang.ClassNotFoundException: org.spongepowered.asm.launch.MixinTweaker"))
			{
				AppendReason(CrashReason.MixinBootstrap缺失);
			}
			if (LogMc.Contains("Couldn't set pixel format"))
			{
				AppendReason(CrashReason.显卡驱动不支持导致无法设置像素格式);
			}
			if (LogMc.Contains("java.lang.OutOfMemoryError") || LogMc.Contains("an out of memory error"))
			{
				AppendReason(CrashReason.内存不足);
			}
			if (LogMc.Contains("java.lang.RuntimeException: Shaders Mod detected. Please remove it, OptiFine has built-in support for shaders."))
			{
				AppendReason(CrashReason.ShadersMod与OptiFine同时安装);
			}
			if (LogMc.Contains("java.lang.NoSuchMethodError: sun.security.util.ManifestEntryVerifier"))
			{
				AppendReason(CrashReason.低版本Forge与高版本Java不兼容);
			}
			if (LogMc.Contains("1282: Invalid operation"))
			{
				AppendReason(CrashReason.光影或资源包导致OpenGL1282错误);
			}
			if (LogMc.Contains("signer information does not match signer information of other classes in the same package"))
			{
				AppendReason(CrashReason.文件或内容校验失败, (ModBase.RegexSeek(LogMc, "(?<=class \")[^']+(?=\"'s signer information)", (RegexOptions)0) ?? "").TrimEnd('\r'));
			}
			if (LogMc.Contains("Maybe try a lower resolution resourcepack?"))
			{
				AppendReason(CrashReason.材质过大或显卡配置不足);
			}
			if (LogMc.Contains("java.lang.NoSuchMethodError: net.minecraft.world.server.ChunkManager$ProxyTicketManager.shouldForceTicks(J)Z") && LogMc.Contains("OptiFine"))
			{
				AppendReason(CrashReason.OptiFine导致无法加载世界);
			}
			if (LogMc.Contains("Unsupported class file major version"))
			{
				AppendReason(CrashReason.Java版本不兼容);
			}
			if (LogMc.Contains("com.electronwill.nightconfig.core.io.ParsingException: Not enough data available"))
			{
				AppendReason(CrashReason.NightConfig的Bug);
			}
			if (LogMc.Contains("Cannot find launch target fmlclient, unable to launch"))
			{
				AppendReason(CrashReason.Forge安装不完整);
			}
			if (LogMc.Contains("Invalid paths argument, contained no existing paths") && LogMc.Contains("libraries\\net\\minecraftforge\\fmlcore"))
			{
				AppendReason(CrashReason.Forge安装不完整);
			}
			if (LogMc.Contains("Invalid module name: '' is not a Java identifier"))
			{
				AppendReason(CrashReason.Mod名称包含特殊字符);
			}
			if (LogMc.Contains("has been compiled by a more recent version of the Java Runtime (class file version 55.0), this version of the Java Runtime only recognizes class file versions up to"))
			{
				AppendReason(CrashReason.Mod需要Java11);
			}
			if (LogMc.Contains("java.lang.RuntimeException: java.lang.NoSuchMethodException: no such method: sun.misc.Unsafe.defineAnonymousClass(Class,byte[],Object[])Class/invokeVirtual"))
			{
				AppendReason(CrashReason.Mod需要Java11);
			}
			if (LogMc.Contains("java.lang.IllegalArgumentException: The requested compatibility level JAVA_11 could not be set. Level is not supported by the active JRE or ASM version"))
			{
				AppendReason(CrashReason.Mod需要Java11);
			}
			if (LogMc.Contains("Unsupported major.minor version"))
			{
				AppendReason(CrashReason.Java版本不兼容);
			}
			if (LogMc.Contains("Invalid maximum heap size"))
			{
				AppendReason(CrashReason.使用32位Java导致JVM无法分配足够多的内存);
			}
			if (LogMc.Contains("Could not reserve enough space"))
			{
				if (LogMc.Contains("for 1048576KB object heap"))
				{
					AppendReason(CrashReason.使用32位Java导致JVM无法分配足够多的内存);
				}
				else
				{
					AppendReason(CrashReason.内存不足);
				}
			}
			if (LogMc.Contains("Caught exception from "))
			{
				AppendReason(CrashReason.确定Mod导致游戏崩溃, (System.Collections.Generic.ICollection<string>)TryAnalyzeModName(ModBase.RegexSeek(LogMc, "(?<=Caught exception from )[^\\n]+?", (RegexOptions)0)?.TrimEnd("\r\n ".ToCharArray())));
			}
			if (LogMc.Contains("DuplicateModsFoundException"))
			{
				AppendReason(CrashReason.Mod重复安装, (System.Collections.Generic.ICollection<string>)ModBase.RegexSearch(LogMc, "(?<=\\n\\t[\\w]+ : [A-Z]{1}:[^\\n]+(/|\\\\))[^/\\\\\\n]+?.jar", (RegexOptions)1));
			}
			if (LogMc.Contains("Found a duplicate mod"))
			{
				AppendReason(CrashReason.Mod重复安装, (System.Collections.Generic.ICollection<string>)ModBase.RegexSearch(ModBase.RegexSeek(LogMc, "Found a duplicate mod[^\\n]+", (RegexOptions)0) ?? "", "[^\\\\/]+.jar", (RegexOptions)1));
			}
			if (LogMc.Contains("Found duplicate mods"))
			{
				AppendReason(CrashReason.Mod重复安装, (System.Collections.Generic.ICollection<string>)Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)ModBase.RegexSearch(LogMc, "(?<=Mod ID: ')\\w+?(?=' from mod files:)", (RegexOptions)0))));
			}
			if (LogMc.Contains("ModResolutionException: Duplicate"))
			{
				AppendReason(CrashReason.Mod重复安装, (System.Collections.Generic.ICollection<string>)ModBase.RegexSearch(ModBase.RegexSeek(LogMc, "ModResolutionException: Duplicate[^\\n]+", (RegexOptions)0) ?? "", "[^\\\\/]+.jar", (RegexOptions)1));
			}
			if (LogMc.Contains("Incompatible mods found!"))
			{
				AppendReason(CrashReason.Mod互不兼容, ModBase.RegexSeek(LogMc, "(?<=Incompatible mods found![\\s\\S]+: )[\\s\\S]+?(?=\\tat )", (RegexOptions)0) ?? "");
			}
			if (LogMc.Contains("Missing or unsupported mandatory dependencies:"))
			{
				AppendReason(CrashReason.Mod缺少前置或MC版本错误, (System.Collections.Generic.ICollection<string>)Enumerable.ToList<string>(Enumerable.Distinct<string>(Enumerable.Select<string, string>((System.Collections.Generic.IEnumerable<string>)ModBase.RegexSearch(LogMc, "(?<=Missing or unsupported mandatory dependencies:)([\\n\\r]+\\t(.*))+", (RegexOptions)1), (Func<string, string>)([SpecialName] (string s) => s.Trim("\r\n\t ".ToCharArray()))))));
			}
		}
		if (LogHs != null)
		{
			if (LogHs.Contains("The system is out of physical RAM or swap space"))
			{
				AppendReason(CrashReason.内存不足);
			}
			if (LogHs.Contains("Out of Memory Error"))
			{
				AppendReason(CrashReason.内存不足);
			}
			if (LogHs.Contains("EXCEPTION_ACCESS_VIOLATION"))
			{
				if (LogHs.Contains("# C  [ig"))
				{
					AppendReason(CrashReason.Intel驱动不兼容导致EXCEPTION_ACCESS_VIOLATION);
				}
				if (LogHs.Contains("# C  [atio"))
				{
					AppendReason(CrashReason.AMD驱动不兼容导致EXCEPTION_ACCESS_VIOLATION);
				}
				if (LogHs.Contains("# C  [nvoglv"))
				{
					AppendReason(CrashReason.Nvidia驱动不兼容导致EXCEPTION_ACCESS_VIOLATION);
				}
			}
		}
		if (LogCrash == null)
		{
			return;
		}
		if (LogCrash.Contains("maximum id range exceeded"))
		{
			AppendReason(CrashReason.Mod过多导致超出ID限制);
		}
		if (LogCrash.Contains("java.lang.OutOfMemoryError"))
		{
			AppendReason(CrashReason.内存不足);
		}
		if (LogCrash.Contains("Pixel format not accelerated"))
		{
			AppendReason(CrashReason.显卡驱动不支持导致无法设置像素格式);
		}
		if (LogCrash.Contains("Manually triggered debug crash"))
		{
			AppendReason(CrashReason.玩家手动触发调试崩溃);
		}
		if (LogCrash.Contains("has mods that were not found") && ModBase.RegexCheck(LogCrash, "The Mod File [^\\n]+optifine\\\\OptiFine[^\\n]+ has mods that were not found", (RegexOptions)0))
		{
			AppendReason(CrashReason.OptiFine与Forge不兼容);
		}
		if (LogCrash.Contains("-- MOD "))
		{
			string str = ModBase.Between(LogCrash, "-- MOD ", "Failure message:");
			if (ModBase.ContainsF(str, ".jar", IgnoreCase: true))
			{
				AppendReason(CrashReason.确定Mod导致游戏崩溃, (ModBase.RegexSeek(str, "(?<=Mod File: ).+", (RegexOptions)0) ?? "").TrimEnd("\r\n ".ToCharArray()));
			}
			else
			{
				AppendReason(CrashReason.Mod加载器报错, (ModBase.RegexSeek(LogCrash, "(?<=Failure message: )[\\w\\W]+?(?=\\tMod)", (RegexOptions)0) ?? "").Replace("\t", " ").TrimEnd("\r\n ".ToCharArray()));
			}
		}
		if (LogCrash.Contains("Multiple entries with same key: "))
		{
			AppendReason(CrashReason.确定Mod导致游戏崩溃, (System.Collections.Generic.ICollection<string>)TryAnalyzeModName((ModBase.RegexSeek(LogCrash, "(?<=Multiple entries with same key: )[^=]+", (RegexOptions)0) ?? "").TrimEnd("\r\n ".ToCharArray())));
		}
		if (LogCrash.Contains("LoaderExceptionModCrash: Caught exception from "))
		{
			AppendReason(CrashReason.确定Mod导致游戏崩溃, (System.Collections.Generic.ICollection<string>)TryAnalyzeModName((ModBase.RegexSeek(LogCrash, "(?<=LoaderExceptionModCrash: Caught exception from )[^\\n]+", (RegexOptions)0) ?? "").TrimEnd("\r\n ".ToCharArray())));
		}
		if (LogCrash.Contains("Failed loading config file "))
		{
			AppendReason(CrashReason.Mod配置文件导致游戏崩溃, new string[2]
			{
				Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)TryAnalyzeModName((ModBase.RegexSeek(LogCrash, "(?<=Failed loading config file .+ for modid )[^\\n]+", (RegexOptions)0) ?? "").TrimEnd('\r'))),
				(ModBase.RegexSeek(LogCrash, "(?<=Failed loading config file ).+(?= of type)", (RegexOptions)0) ?? "").TrimEnd('\r')
			});
		}
	}

	private void AnalyzeCrit2()
	{
		VB_0024AnonymousDelegate_7<string, bool> vB_0024AnonymousDelegate_ = [SpecialName] [CompilerGenerated] (string LogText) =>
		{
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			if (!LogText.Contains("Mixin prepare failed ") && !LogText.Contains("Mixin apply failed ") && !LogText.Contains("MixinApplyError") && !LogText.Contains("MixinTransformerError") && !LogText.Contains("mixin.injection.throwables.") && !LogText.Contains(".json] FAILED during )"))
			{
				return false;
			}
			string text = ModBase.RegexSeek(LogText, "(?<=from mod )[^.\\/ ]+(?=\\] from)", (RegexOptions)0);
			if (text == null)
			{
				text = ModBase.RegexSeek(LogText, "(?<=for mod )[^.\\/ ]+(?= failed)", (RegexOptions)0);
			}
			if (text != null)
			{
				AppendReason(CrashReason.ModMixin失败, (System.Collections.Generic.ICollection<string>)TryAnalyzeModName(text.TrimEnd("\r\n ".ToCharArray())));
				return true;
			}
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = ModBase.RegexSearch(LogText, "(?<=^[^\\t]+[ \\[{(]{1})[^ \\[{(]+\\.[^ ]+(?=\\.json)", (RegexOptions)2).GetEnumerator();
				if (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					AppendReason(CrashReason.ModMixin失败, (System.Collections.Generic.ICollection<string>)TryAnalyzeModName(current.Replace("mixins", "mixin").Replace(".mixin", "").Replace("mixin.", "")));
					return true;
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			AppendReason(CrashReason.ModMixin失败);
			return true;
		};
		if (LogMc != null)
		{
			bool flag = vB_0024AnonymousDelegate_(LogMc);
			if (LogMc.Contains("An exception was thrown, the game will display an error screen and halt."))
			{
				AppendReason(CrashReason.Forge报错, ModBase.RegexSeek(LogMc, "(?<=the game will display an error screen and halt.[\\n\\r]+[^\\n]+?Exception: )[\\s\\S]+?(?=\\n\\tat)", (RegexOptions)0)?.Trim('\r'));
			}
			if (LogMc.Contains("A potential solution has been determined:"))
			{
				AppendReason(CrashReason.Fabric报错并给出解决方案, ModBase.Join((System.Collections.IEnumerable)ModBase.RegexSearch(ModBase.RegexSeek(LogMc, "(?<=A potential solution has been determined:\\n)(\\s+ - [^\\n]+\\n)+", (RegexOptions)0) ?? "", "(?<=\\s+)[^\\n]+", (RegexOptions)0), "\n"));
			}
			if (LogMc.Contains("A potential solution has been determined, this may resolve your problem:"))
			{
				AppendReason(CrashReason.Fabric报错并给出解决方案, ModBase.Join((System.Collections.IEnumerable)ModBase.RegexSearch(ModBase.RegexSeek(LogMc, "(?<=A potential solution has been determined, this may resolve your problem:\\n)(\\s+ - [^\\n]+\\n)+", (RegexOptions)0) ?? "", "(?<=\\s+)[^\\n]+", (RegexOptions)0), "\n"));
			}
			if (LogMc.Contains("确定了一种可能的解决方法，这样做可能会解决你的问题："))
			{
				AppendReason(CrashReason.Fabric报错并给出解决方案, ModBase.Join((System.Collections.IEnumerable)ModBase.RegexSearch(ModBase.RegexSeek(LogMc, "(?<=确定了一种可能的解决方法，这样做可能会解决你的问题：\\n)(\\s+ - [^\\n]+\\n)+", (RegexOptions)0) ?? "", "(?<=\\s+)[^\\n]+", (RegexOptions)0), "\n"));
			}
			if (!flag && LogMc.Contains("due to errors, provided by "))
			{
				AppendReason(CrashReason.确定Mod导致游戏崩溃, (System.Collections.Generic.ICollection<string>)TryAnalyzeModName((ModBase.RegexSeek(LogMc, "(?<=due to errors, provided by ')[^']+", (RegexOptions)0) ?? "").TrimEnd("\r\n ".ToCharArray())));
			}
		}
		if (LogCrash == null)
		{
			return;
		}
		vB_0024AnonymousDelegate_(LogCrash);
		if (!LogCrash.Contains("Suspected Mod"))
		{
			return;
		}
		string str = ModBase.Between(LogCrash, "Suspected Mod", "Stacktrace");
		if (!ModBase.StartsWithF(str, "s: None"))
		{
			List<string> val = ModBase.RegexSearch(str, "(?<=\\n\\t[^(\\t]+\\()[^)\\n]+", (RegexOptions)0);
			if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val))
			{
				AppendReason(CrashReason.怀疑Mod导致游戏崩溃, (System.Collections.Generic.ICollection<string>)TryAnalyzeModName(val));
			}
		}
	}

	private void AnalyzeCrit3()
	{
		if (LogMc != null)
		{
			if (!LogMc.Contains("at net.") && !LogMc.Contains("INFO]") && LogHs == null && LogCrash == null && LogMc.Length < 100)
			{
				AppendReason(CrashReason.极短的程序输出, LogMc);
			}
			if (LogMc.Contains("Mod resolution failed"))
			{
				AppendReason(CrashReason.Mod加载器报错);
			}
			if (LogMc.Contains("Failed to create mod instance."))
			{
				AppendReason(CrashReason.Mod初始化失败, (System.Collections.Generic.ICollection<string>)TryAnalyzeModName((ModBase.RegexSeek(LogMc, "(?<=Failed to create mod instance. ModID: )[^,]+", (RegexOptions)0) ?? ModBase.RegexSeek(LogMc, "(?<=Failed to create mod instance. ModId )[^\\n]+(?= for )", (RegexOptions)0) ?? "").TrimEnd('\r')));
			}
		}
		if (LogCrash != null)
		{
			if (LogCrash.Contains("\tBlock location: World: "))
			{
				AppendReason(CrashReason.特定方块导致崩溃, ModBase.RegexSeek(LogCrash, "(?<=\\tBlock: Block\\{)[^\\}]+", (RegexOptions)0) + " " + ModBase.RegexSeek(LogCrash, "(?<=\\tBlock location: World: )\\([^\\)]+\\)", (RegexOptions)0));
			}
			if (LogCrash.Contains("\tEntity's Exact location: "))
			{
				AppendReason(CrashReason.特定实体导致崩溃, ModBase.RegexSeek(LogCrash, "(?<=\\tEntity Type: )[^\\n]+(?= \\()", (RegexOptions)0) + " (" + (ModBase.RegexSeek(LogCrash, "(?<=\\tEntity's Exact location: )[^\\n]+", (RegexOptions)0) ?? "").TrimEnd("\r\n".ToCharArray()) + ")");
			}
		}
	}

	private List<string> AnalyzeStackKeyword(string ErrorStack)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		ErrorStack = "\n" + ErrorStack + "\n";
		List<string> val = new List<string>();
		val.AddRange((System.Collections.Generic.IEnumerable<string>)ModBase.RegexSearch(ErrorStack, "(?<=\\n[^{]+)[a-zA-Z_]+\\w+\\.[a-zA-Z_]+[\\w\\.]+(?=\\.[\\w\\.$]+\\.)", (RegexOptions)0));
		val.AddRange(Enumerable.Select<string, string>((System.Collections.Generic.IEnumerable<string>)ModBase.RegexSearch(ErrorStack, "(?<=at [^(]+?\\.\\w+\\$\\w+\\$)[\\w\\$]+?(?=\\$\\w+\\()", (RegexOptions)0), (Func<string, string>)([SpecialName] (string s) => s.Replace("$", "."))));
		val = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val));
		List<string> val2 = new List<string>();
		checked
		{
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = val.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					string[] array = new string[21]
					{
						"java", "sun", "javax", "jdk", "oolloo", "org.lwjgl", "com.sun", "net.minecraftforge", "paulscode.sound", "com.mojang",
						"net.minecraft", "cpw.mods", "com.google", "org.apache", "org.spongepowered", "net.fabricmc", "com.mumfrey", "org.quiltmc", "com.electronwill.nightconfig", "it.unimi.dsi",
						"MojangTricksIntelDriversForPerformance_javaw"
					};
					int num = 0;
					while (true)
					{
						if (num < array.Length)
						{
							string prefix = array[num];
							if (ModBase.StartsWithF(current, prefix))
							{
								break;
							}
							num++;
							continue;
						}
						val2.Add(current.Trim());
						break;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			val2 = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val2));
			ModBase.Log("[Crash] 找到 " + Conversions.ToString(val2.Count) + " 条可能的堆栈信息");
			if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2))
			{
				return new List<string>();
			}
			System.Collections.Generic.IEnumerator<string> enumerator2 = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator2 = val2.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					string current2 = enumerator2.Current;
					ModBase.Log("[Crash]  - " + current2);
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			List<string> val3 = new List<string>();
			System.Collections.Generic.IEnumerator<string> enumerator3 = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator3 = val2.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					string[] array2 = enumerator3.Current.Split(".", (StringSplitOptions)0);
					int num2 = Math.Min(3, Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)array2) - 1);
					for (int i = 0; i <= num2; i++)
					{
						string text = array2[i];
						if (text.Length > 2 && !ModBase.StartsWithF(text, "func_") && !Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[98]
						{
							"com", "org", "net", "asm", "fml", "mod", "jar", "sun", "lib", "map",
							"gui", "dev", "nio", "api", "dsi", "top", "mcp", "core", "init", "mods",
							"main", "file", "game", "load", "read", "done", "util", "tile", "item", "base",
							"oshi", "impl", "data", "pool", "task", "forge", "setup", "block", "model", "mixin",
							"event", "unimi", "netty", "world", "lwjgl", "gitlab", "common", "server", "config", "mixins",
							"compat", "loader", "launch", "entity", "assist", "client", "plugin", "modapi", "mojang", "shader",
							"events", "github", "recipe", "render", "packet", "events", "preinit", "preload", "machine", "reflect",
							"channel", "general", "handler", "content", "systems", "modules", "service", "fastutil", "optifine", "internal",
							"platform", "override", "fabricmc", "neoforge", "injection", "listeners", "scheduler", "minecraft", "universal", "multipart",
							"neoforged", "microsoft", "transformer", "transformers", "minecraftforge", "blockentity", "spongepowered", "electronwill"
						}, text.ToLower()))
						{
							val3.Add(text.Trim());
						}
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator3).Dispose();
			}
			val3 = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val3));
			ModBase.Log("[Crash] 从堆栈信息中找到 " + Conversions.ToString(val3.Count) + " 个可能的 Mod ID 关键词");
			if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val3))
			{
				ModBase.Log("[Crash]  - " + ModBase.Join((System.Collections.IEnumerable)val3, ", "));
			}
			if (val3.Count > 10)
			{
				ModBase.Log("[Crash] 关键词过多，考虑匹配出错，不纳入考虑");
				return new List<string>();
			}
			return val3;
		}
	}

	private List<string> AnalyzeModName(List<string> Keywords)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		List<string> val = new List<string>();
		List<string> val2 = new List<string>();
		System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator = Keywords.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string[] array = enumerator.Current.Split("(", (StringSplitOptions)0);
				foreach (string text in array)
				{
					val2.Add(text.Trim(" )".ToCharArray()));
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		Keywords = val2;
		if (LogCrash != null && LogCrash.Contains("A detailed walkthrough of the error"))
		{
			string text2 = LogCrash.Replace("A detailed walkthrough of the error", "\u00a8");
			bool flag = text2.Contains("Fabric Mods");
			if (flag)
			{
				text2 = text2.Replace("Fabric Mods", "\u00a8");
				ModBase.Log("[Crash] 崩溃报告中检测到 Fabric Mod 信息格式");
			}
			if (text2.Contains("quilt-loader"))
			{
				text2 = text2.Replace("Mod Table Version", "\u00a8");
				ModBase.Log("[Crash] 崩溃报告中检测到 Quilt Mod 信息格式");
			}
			text2 = ModBase.AfterLast(text2, "\u00a8");
			List<string> val3 = new List<string>();
			string[] array2 = text2.Split("\n", (StringSplitOptions)0);
			foreach (string text3 in array2)
			{
				if ((ModBase.ContainsF(text3, ".jar", IgnoreCase: true) && checked(text3.Length - text3.Replace(".jar", "").Length) == 4) || (flag && ModBase.StartsWithF(text3, "\t\t") && !ModBase.RegexCheck(text3, "\\t\\tfabric[\\w-]*: Fabric", (RegexOptions)0)))
				{
					val3.Add(text3);
				}
			}
			ModBase.Log("[Crash] 崩溃报告中找到 " + Conversions.ToString(val3.Count) + " 个可能的 Mod 项目行");
			List<string> val4 = new List<string>();
			System.Collections.Generic.IEnumerator<string> enumerator2 = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator2 = Keywords.GetEnumerator();
				System.Collections.Generic.IEnumerator<string> enumerator3 = default(System.Collections.Generic.IEnumerator<string>);
				while (enumerator2.MoveNext())
				{
					string current = enumerator2.Current;
					try
					{
						enumerator3 = val3.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							string current2 = enumerator3.Current;
							string text4 = current2.ToLower().Replace("_", "");
							if (text4.Contains(current.ToLower().Replace("_", "")) && !text4.Contains("minecraft.jar") && !text4.Contains(" forge-") && !text4.Contains(" mixin-"))
							{
								val4.Add(current2.Trim("\r\n".ToCharArray()));
								break;
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator3).Dispose();
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			val4 = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val4));
			ModBase.Log("[Crash] 崩溃报告中找到 " + Conversions.ToString(val4.Count) + " 个可能的崩溃 Mod 匹配行");
			System.Collections.Generic.IEnumerator<string> enumerator4 = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator4 = val4.GetEnumerator();
				while (enumerator4.MoveNext())
				{
					string current3 = enumerator4.Current;
					ModBase.Log("[Crash]  - " + current3);
				}
			}
			finally
			{
				((System.IDisposable)enumerator4).Dispose();
			}
			System.Collections.Generic.IEnumerator<string> enumerator5 = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator5 = val4.GetEnumerator();
				while (enumerator5.MoveNext())
				{
					string current4 = enumerator5.Current;
					string text5 = ((!flag) ? ModBase.RegexSeek(current4, "(?<=\\()[^\\t]+.jar(?=\\))|(?<=(\\t\\t)|(\\| ))[^\\t\\|]+.jar", (RegexOptions)1) : ModBase.RegexSeek(current4, "(?<=: )[^\\n]+(?= [^\\n]+)", (RegexOptions)0));
					if (text5 != null)
					{
						val.Add(text5);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator5).Dispose();
			}
		}
		if (LogMcDebug != null)
		{
			List<string> val5 = ModBase.RegexSearch(LogMcDebug, "(?<=valid mod file ).*", (RegexOptions)2);
			ModBase.Log("[Crash] Debug 信息中找到 " + Conversions.ToString(val5.Count) + " 个可能的 Mod 项目行");
			List<string> val6 = new List<string>();
			System.Collections.Generic.IEnumerator<string> enumerator6 = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator6 = Keywords.GetEnumerator();
				System.Collections.Generic.IEnumerator<string> enumerator7 = default(System.Collections.Generic.IEnumerator<string>);
				while (enumerator6.MoveNext())
				{
					string current5 = enumerator6.Current;
					try
					{
						enumerator7 = val5.GetEnumerator();
						while (enumerator7.MoveNext())
						{
							string current6 = enumerator7.Current;
							if (current6.Contains($"{{{current5}}}"))
							{
								val6.Add(current6);
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator7).Dispose();
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator6).Dispose();
			}
			val6 = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val6));
			ModBase.Log("[Crash] Debug 信息中找到 " + Conversions.ToString(val6.Count) + " 个可能的崩溃 Mod 匹配行");
			System.Collections.Generic.IEnumerator<string> enumerator8 = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator8 = val6.GetEnumerator();
				while (enumerator8.MoveNext())
				{
					string current7 = enumerator8.Current;
					ModBase.Log("[Crash]  - " + current7);
				}
			}
			finally
			{
				((System.IDisposable)enumerator8).Dispose();
			}
			System.Collections.Generic.IEnumerator<string> enumerator9 = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator9 = val6.GetEnumerator();
				while (enumerator9.MoveNext())
				{
					string text6 = ModBase.RegexSeek(enumerator9.Current, ".*(?= with)", (RegexOptions)0);
					if (text6 != null)
					{
						val.Add(text6);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator9).Dispose();
			}
		}
		val = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val));
		if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val))
		{
			return null;
		}
		ModBase.Log("[Crash] 找到 " + Conversions.ToString(val.Count) + " 个可能的崩溃 Mod 文件名");
		System.Collections.Generic.IEnumerator<string> enumerator10 = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator10 = val.GetEnumerator();
			while (enumerator10.MoveNext())
			{
				string current8 = enumerator10.Current;
				ModBase.Log("[Crash]  - " + current8);
			}
		}
		finally
		{
			((System.IDisposable)enumerator10).Dispose();
		}
		return val;
	}

	private List<string> TryAnalyzeModName(string Keyword)
	{
		List<string> obj = new List<string>();
		obj.Add(Keyword ?? "");
		List<string> val = obj;
		if (string.IsNullOrEmpty(Keyword))
		{
			return val;
		}
		return AnalyzeModName(val) ?? val;
	}

	private List<string> TryAnalyzeModName(List<string> Keywords)
	{
		if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)Keywords))
		{
			return Keywords;
		}
		return AnalyzeModName(Keywords) ?? Keywords;
	}

	public void Output(bool IsHandAnalyze, List<string> ExtraFiles = null)
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_054c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0551: Unknown result type (might be due to invalid IL or missing references)
		ModMain.FrmMain.ShowWindowToTop();
		string analyzeResult = GetAnalyzeResult(IsHandAnalyze);
		bool flag = (object)_version != null && analyzeResult.StartsWith("Mod 加载器版本与 Mod 不兼容");
		string title = (IsHandAnalyze ? "错误报告分析结果" : "Minecraft 出现错误");
		string button = ((IsHandAnalyze || !DirectFile.HasValue) ? "" : (flag ? "前往修改" : "查看日志"));
		string button2 = (IsHandAnalyze ? "" : "导出错误报告");
		VB_0024AnonymousDelegate_8 vB_0024AnonymousDelegate_ = ((IsHandAnalyze || !DirectFile.HasValue || flag) ? null : ((VB_0024AnonymousDelegate_8)([SpecialName] [CompilerGenerated] () =>
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			if (File.Exists(DirectFile.Value.Key))
			{
				ModBase.ShellOnly(DirectFile.Value.Key);
			}
			else
			{
				string text4 = ModBase.PathTemp + "Crash.txt";
				ModBase.WriteFile(text4, ModBase.Join((System.Collections.IEnumerable)(object)DirectFile.Value.Value, "\r\n"));
				ModBase.ShellOnly(text4);
			}
		})));
		switch (ModMain.MyMsgBox(analyzeResult, title, "确定", button, button2, IsWarn: false, HighLight: true, ForceWait: false, null, (vB_0024AnonymousDelegate_ == null) ? ((Action)null) : new Action(vB_0024AnonymousDelegate_.Invoke)))
		{
		case 2:
		{
			PageInstanceLeft.Instance = _version;
			object action;
			if (_Closure_0024__._0024I28_002D1 != null)
			{
				action = _Closure_0024__._0024I28_002D1;
			}
			else
			{
				Action val2 = [SpecialName] () =>
				{
					ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSetup, FormMain.PageSubType.VersionInstall);
				};
				_Closure_0024__._0024I28_002D1 = val2;
				action = (object)val2;
			}
			ModBase.RunInUi((Action)action);
			break;
		}
		case 3:
		{
			_Closure_0024__28_002D0 arg = default(_Closure_0024__28_002D0);
			_Closure_0024__28_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__28_002D0(null);
			CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress = null;
			try
			{
				ModBase.RunInUiWait((Action)([SpecialName] () =>
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress = SystemDialogs.SelectSaveFile("选择保存位置", "错误报告-" + System.DateTime.Now.ToString("G").Replace("/", "-").Replace(":", ".")
						.Replace(" ", "_") + ".zip", "Minecraft 错误报告(*.zip)|*.zip");
				}));
				if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress))
				{
					break;
				}
				Directory.CreateDirectory(ModBase.GetPathFromFullPath(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress));
				if (File.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress))
				{
					File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress);
				}
				ModBase.FeedbackInfo();
				if (ExtraFiles != null)
				{
					OutputFiles.AddRange((System.Collections.Generic.IEnumerable<string>)ExtraFiles);
				}
				System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
				try
				{
					enumerator = OutputFiles.GetEnumerator();
					while (enumerator.MoveNext())
					{
						string current = enumerator.Current;
						string text = ModBase.GetFileNameFromPath(current);
						Encoding val = null;
						if (Operators.CompareString(text, "LatestLaunch.bat", false) != 0)
						{
							if (Operators.CompareString(text, "RawOutput.log", false) == 0)
							{
								text = "游戏崩溃前的输出.txt";
								val = Encoding.UTF8;
							}
						}
						else
						{
							text = "启动脚本.bat";
						}
						if (Operators.CompareString(ModBase.AfterLast(Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)LogWrapper.CurrentLogger.LogFiles), "\\"), text, false) == 0)
						{
							text = "PCL 启动器日志.txt";
							val = Encoding.UTF8;
						}
						if (File.Exists(current))
						{
							if (val == null)
							{
								val = EncodingDetector.DetectEncoding(ModBase.ReadFileBytes(current));
							}
							string raw = ModBase.ReadFile(current, val);
							raw = ModMinecraft.FilterAccessToken(raw, Conversions.ToChar((Operators.CompareString(text, "启动脚本.bat", false) == 0) ? "F" : "*"));
							raw = ModMinecraft.FilterUserName(raw, '*');
							ModBase.WriteFile(TempFolder + "Report\\" + text, raw, Append: false, val);
							ModBase.Log($"[Crash] 导出文件：{text}，编码：{val.HeaderName}");
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				string text2 = null;
				string text3 = null;
				text3 = ModBase.BeforeFirst(ModBase.AfterLast(ModBase.ReadFile(TempFolder + "Report\\PCL 启动器日志.txt"), "[Launch] ~ 基础参数 ~"), "开始 Minecraft 日志监控");
				string str = ModBase.ReadFile(TempFolder + "Report\\启动脚本.bat");
				text2 += string.Format("PCL Pro-N 版本：{0} {1}", (object)"2.13.3", (object)"\r\n");
				text2 += string.Format("识别码：{0}{1}", (object)ModBase.UniqueAddress, (object)"\r\n");
				text2 += string.Format("{0}- 档案信息 -{1}", (object)"\r\n", (object)"\r\n");
				text2 += string.Format("档案名称：{0} (验证方式：{1}){2}", (object)ModBase.Between(text3, "玩家用户名：", "[").TrimEnd('[').Trim(), (object)ModBase.Between(text3, "验证方式：", "[").TrimEnd('[').Trim(), (object)"\r\n");
				text2 += string.Format("{0}- 实例信息 -{1}", (object)"\r\n", (object)"\r\n");
				text2 += string.Format("选定的 Java 虚拟机：{0}{1}", (object)ModBase.Between(text3, "Java 信息：", "[").TrimEnd('[').Trim(), (object)"\r\n");
				text2 += string.Format("Log4j2 NoLookups：{0}{1}", (object)(!ModBase.ContainsF(str, "-Dlog4j2.formatMsgNoLookups=false")), (object)"\r\n");
				text2 += string.Format("MC 文件夹：{0}{1}", (object)ModBase.Between(text3, "MC 文件夹：", "[").TrimEnd('[').Trim(), (object)"\r\n");
				text2 += string.Format("{0}- 环境信息 -{1}", (object)"\r\n", (object)"\r\n");
				text2 += string.Format("操作系统：{0}（64 位：{1}, ARM64: {2}）{3}", new object[4]
				{
					ModSecret.OSInfo,
					!ModBase.Is32BitSystem,
					ModBase.IsArm64System,
					"\r\n"
				});
				text2 += string.Format("CPU：{0}{1}", (object)ModSecret.CPUName, (object)"\r\n");
				text2 += string.Format("内存分配 (分配的内存 / 已安装物理内存)：{0} / {1} GB ({2} MB){3}", new object[4]
				{
					ModBase.Between(text3, "分配的内存：", "[").TrimEnd('[').Trim(),
					Math.Round((double)ModSecret.SystemMemorySize / 1024.0, 2),
					ModSecret.SystemMemorySize,
					"\r\n"
				});
				System.Collections.Generic.IEnumerator<ModSecret.GPUInfo> enumerator2 = default(System.Collections.Generic.IEnumerator<ModSecret.GPUInfo>);
				try
				{
					enumerator2 = ModSecret.GPUs.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						ModSecret.GPUInfo current2 = enumerator2.Current;
						text2 += string.Format("显卡 {0}：{1} ({2} MB, {3})", new object[4]
						{
							ModSecret.GPUs.IndexOf(current2),
							current2.Name,
							(current2.Memory >= 4095) ? (">= " + Conversions.ToString(current2.Memory)) : ((object)current2.Memory),
							current2.DriverVersion
						});
						text2 += "\r\n";
					}
				}
				finally
				{
					((System.IDisposable)enumerator2).Dispose();
				}
				File.CreateText(TempFolder + "Report\\环境与启动信息.txt").Close();
				ModBase.WriteFile(TempFolder + "Report\\环境与启动信息.txt", text2, Append: false, Encoding.UTF8);
				ZipFile.CreateFromDirectory(TempFolder + "Report\\", CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress);
				ModBase.DeleteDirectory(TempFolder + "Report\\");
				ModMain.Hint("错误报告已导出！", ModMain.HintType.Finish);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "导出错误报告失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
				break;
			}
			ModBase.OpenExplorer(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress);
			break;
		}
		}
	}

	private string GetAnalyzeResult(bool IsHandAnalyze)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		if (!Enumerable.Any<KeyValuePair<CrashReason, List<string>>>((System.Collections.Generic.IEnumerable<KeyValuePair<CrashReason, List<string>>>)CrashReasons))
		{
			if (IsHandAnalyze)
			{
				return "很抱歉，PCL 无法确定错误原因。";
			}
			return string.Format("很抱歉，你的游戏出现了一些问题……{0}如果要寻求帮助，请把错误报告文件发给对方，而不是发送这个窗口的照片或者截图。", (object)"\r\n");
		}
		List<string> val = new List<string>();
		System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<CrashReason, List<string>>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<CrashReason, List<string>>>);
		try
		{
			enumerator = CrashReasons.GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<CrashReason, List<string>> current = enumerator.Current;
				List<string> value = current.Value;
				switch (current.Key)
				{
				case CrashReason.Mod文件被解压:
					val.Add("由于 Mod 文件被解压了，导致游戏无法继续运行。\\n直接把整个 Mod 文件放进 Mod 文件夹中即可，若解压就会导致游戏出错。\\n\\n请删除 Mod 文件夹中已被解压的 Mod，然后再启动游戏。");
					break;
				case CrashReason.内存不足:
					val.Add("Minecraft 内存不足，导致其无法继续运行。\\n这很可能是因为电脑内存不足、游戏分配的内存不足，或是配置要求过高。\\n\\n你可以尝试在 更多 → 百宝箱 中选择 内存优化，然后再启动游戏。\\n如果还是不行，请在启动设置中增加为游戏分配的内存，并删除配置要求较高的材质、Mod、光影。\\n如果依然不奏效，请在开始游戏前尽量关闭其他软件，或者……换台电脑？\\h");
					break;
				case CrashReason.使用OpenJ9:
					val.Add("游戏因为使用 OpenJ9 而崩溃了。\\n请在启动设置的 Java 选择一项中改用非 OpenJ9 的 Java，然后再启动游戏。");
					break;
				case CrashReason.使用JDK:
					val.Add("游戏似乎因为使用 JDK，或 Java 版本过高而崩溃了。\\n请在启动设置的 Java 选择一项中改用 JRE 8（Java 8），然后再启动游戏。\\n如果你没有安装 JRE 8，你可以从网络中下载、安装一个。");
					break;
				case CrashReason.Java版本过高:
					val.Add("游戏似乎因为你所使用的 Java 版本过高而崩溃了。\\n请在启动设置的 Java 选择一项中改用较低版本的 Java，然后再启动游戏。\\n如果没有，可以从网络中下载、安装一个。");
					break;
				case CrashReason.Java版本不兼容:
					val.Add("游戏不兼容你当前使用的 Java。\\n如果没有合适的 Java，可以从网络中下载、安装一个。");
					break;
				case CrashReason.Mod名称包含特殊字符:
					val.Add("由于有 Mod 的名称包含特殊字符，导致游戏崩溃。\\n请尝试修改 Mod 文件名，让它只包含英文字母、数字、减号（-）、下划线（_）和小数点，然后再启动游戏。");
					break;
				case CrashReason.MixinBootstrap缺失:
					val.Add("由于缺失 MixinBootstrap，导致游戏崩溃。\\n请尝试安装 MixinBootstrap。若安装后依然崩溃，可以尝试在文件名前添加英文感叹号。");
					break;
				case CrashReason.使用32位Java导致JVM无法分配足够多的内存:
					if (Environment.Is64BitOperatingSystem)
					{
						val.Add("你似乎正在使用 32 位 Java，这会导致 Minecraft 无法使用所需的内存，进而造成崩溃。\\n\\n请在启动设置的 Java 选择一项中改用 64 位的 Java 再启动游戏，然后再启动游戏。\\n如果你没有安装 64 位的 Java，你可以从网络中下载、安装一个。");
					}
					else
					{
						val.Add("你正在使用 32 位的操作系统，这会导致 Minecraft 无法使用所需的内存，进而造成崩溃。\\n\\n你或许只能重装 64 位的操作系统来解决此问题。\\n如果你的电脑内存在 2GB 以内，那或许只能换台电脑了……\\h");
					}
					break;
				case CrashReason.Mod缺少前置或MC版本错误:
					if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)value))
					{
						string text2 = ModBase.Join((System.Collections.IEnumerable)value, "\\n - ");
						if (text2.IsMatch(RegexPatterns.IncompatibleModLoaderErrorHint))
						{
							val.Add("Mod 加载器版本与 Mod 不兼容，请前往 实例设置 - 修改 更换加载器版本。\\n\\n详细信息：\\n" + text2);
						}
						else
						{
							val.Add("由于未安装正确的前置 Mod，导致游戏退出。\\n缺失的依赖项：\\n - " + text2 + "\\n\\n请根据上述信息进行对应处理，如果看不懂英文可以使用翻译软件。");
						}
					}
					else
					{
						val.Add("由于未安装正确的前置 Mod，导致游戏退出。\\n请根据错误报告中的日志信息进行对应处理，如果看不懂英文可以使用翻译软件。\\h");
					}
					break;
				case CrashReason.堆栈分析发现关键字:
					if (value.Count == 1)
					{
						val.Add("你的游戏遇到了一些问题，PCL 为此找到了一个可疑的关键词：" + Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value) + "。\\n\\n如果你知道某个关键词对应的 Mod，那么有可能就是它引起的错误，你也可以查看错误报告获取详情。\\h");
					}
					else
					{
						val.Add("你的游戏遇到了一些问题，PCL 为此找到了以下可疑的关键词：\\n - " + ModBase.Join((System.Collections.IEnumerable)value, ", ") + "\\n\\n如果你知道某个关键词对应的 Mod，那么有可能就是它引起的错误，你也可以查看错误报告获取详情。\\h");
					}
					break;
				case CrashReason.怀疑Mod导致游戏崩溃:
				case CrashReason.堆栈分析发现Mod名称:
					if (value.Count == 1)
					{
						val.Add("PCL 怀疑名为 " + Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value) + " 的 Mod 导致了游戏出错，但不能完全确定。\\n你可以尝试禁用此 Mod，然后观察游戏是否还会崩溃。\\n\\e\\h");
					}
					else
					{
						val.Add("PCL 怀疑以下 Mod 导致了游戏出错，但不能完全确定：\\n - " + ModBase.Join((System.Collections.IEnumerable)value, "\\n - ") + "\\n\\n你可以尝试依次禁用上述 Mod，然后观察游戏是否还会崩溃。\\n\\e\\h");
					}
					break;
				case CrashReason.确定Mod导致游戏崩溃:
					if (value.Count == 1)
					{
						val.Add("名为 " + Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value) + " 的 Mod 导致了游戏出错。\\n你可以尝试禁用此 Mod，然后观察游戏是否还会崩溃。\\n\\e\\h");
					}
					else
					{
						val.Add("以下 Mod 导致了游戏出错：\\n - " + ModBase.Join((System.Collections.IEnumerable)value, "\\n - ") + "\\n\\n你可以尝试依次禁用上述 Mod，然后观察游戏是否还会崩溃。\\n\\e\\h");
					}
					break;
				case CrashReason.ModMixin失败:
					if (value.Count == 0)
					{
						val.Add("部分 Mod 注入失败，导致游戏出错。\\n这一般代表着部分 Mod 与其他 Mod 或当前环境不兼容，或是它存在 Bug。\\n你可以尝试逐步禁用 Mod，然后观察游戏是否还会崩溃，以此定位导致崩溃的 Mod。\\n\\e\\h");
					}
					else if (value.Count == 1)
					{
						val.Add("名为 " + Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value) + " 的 Mod 注入失败，导致游戏出错。\\n这一般代表着它与其他 Mod 或当前环境不兼容，或是它存在 Bug。\\n你可以尝试禁用此 Mod，然后观察游戏是否还会崩溃。\\n\\e\\h");
					}
					else
					{
						val.Add("以下 Mod 导致了游戏出错：\\n - " + ModBase.Join((System.Collections.IEnumerable)value, "\\n - ") + "\\n这一般代表着它们与其他 Mod 或当前环境不兼容，或是它存在 Bug。\\n你可以尝试依次禁用上述 Mod，然后观察游戏是否还会崩溃。\\n\\e\\h");
					}
					break;
				case CrashReason.Mod配置文件导致游戏崩溃:
					if (value[1] == null)
					{
						val.Add("名为 " + Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value) + " 的 Mod 导致了游戏出错。\\n\\e\\h");
						break;
					}
					val.Add(string.Concat(new string[5]
					{
						"名为 ",
						Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value),
						" 的 Mod 导致了游戏出错：\\n其配置文件 ",
						value[1],
						" 存在异常，无法读取。"
					}));
					break;
				case CrashReason.Mod初始化失败:
					if (value.Count == 1)
					{
						val.Add("名为 " + Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value) + " 的 Mod 初始化失败，导致游戏无法继续加载。\\n你可以尝试禁用此 Mod，然后观察游戏是否还会崩溃。\\n\\e\\h");
					}
					else
					{
						val.Add("以下 Mod 初始化失败，导致游戏出错：\\n - " + ModBase.Join((System.Collections.IEnumerable)value, "\\n - ") + "\\n\\n你可以尝试依次禁用上述 Mod，然后观察游戏是否还会崩溃。\\n\\e\\h");
					}
					break;
				case CrashReason.特定方块导致崩溃:
					if (value.Count == 1)
					{
						val.Add("游戏似乎因为方块 " + Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value) + " 出现了问题。\\n\\n你可以创建一个新世界，并观察游戏的运行情况：\\n - 若正常运行，则是该方块导致出错，你或许需要使用一些方式删除此方块。\\n - 若仍然出错，问题就可能来自其他原因……\\h");
					}
					else
					{
						val.Add("游戏似乎因为世界中的某些方块出现了问题。\\n\\n你可以创建一个新世界，并观察游戏的运行情况：\\n - 若正常运行，则是某些方块导致出错，你或许需要删除该世界。\\n - 若仍然出错，问题就可能来自其他原因……\\h");
					}
					break;
				case CrashReason.Mod重复安装:
					if (value.Count >= 2)
					{
						val.Add("你重复安装了多个相同的 Mod：\\n - " + ModBase.Join((System.Collections.IEnumerable)value, "\\n - ") + "\\n\\n每个 Mod 只能出现一次，请删除重复的 Mod，然后再启动游戏。");
					}
					else
					{
						val.Add("你可能重复安装了多个相同的 Mod，导致游戏出错。\\n\\n每个 Mod 只能出现一次，请删除重复的 Mod，然后再启动游戏。\\e\\h");
					}
					break;
				case CrashReason.特定实体导致崩溃:
					if (value.Count == 1)
					{
						val.Add("游戏似乎因为实体 " + Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value) + " 出现了问题。\\n\\n你可以创建一个新世界，并生成一个该实体，然后观察游戏的运行情况：\\n - 若正常运行，则是该实体导致出错，你或许需要使用一些方式删除此实体。\\n - 若仍然出错，问题就可能来自其他原因……\\h");
					}
					else
					{
						val.Add("游戏似乎因为世界中的某些实体出现了问题。\\n\\n你可以创建一个新世界，并生成各种实体，观察游戏的运行情况：\\n - 若正常运行，则是某些实体导致出错，你或许需要删除该世界。\\n - 若仍然出错，问题就可能来自其他原因……\\h");
					}
					break;
				case CrashReason.OptiFine与Forge不兼容:
					val.Add("由于 OptiFine 与当前版本的 Forge 不兼容，导致了游戏崩溃。\\n\\n请前往 OptiFine 官网（https://optifine.net/downloads）查看 OptiFine 所兼容的 Forge 版本，并严格按照对应版本重新安装游戏。");
					break;
				case CrashReason.ShadersMod与OptiFine同时安装:
					val.Add("无需同时安装 OptiFine 和 Shaders Mod，OptiFine 已经集成了 Shaders Mod 的功能。\\n在删除 Shaders Mod 后，游戏即可正常运行。");
					break;
				case CrashReason.低版本Forge与高版本Java不兼容:
					val.Add("由于低版本 Forge 与当前 Java 不兼容，导致了游戏崩溃。\\n\\n请尝试以下解决方案：\\n - 更新 Forge 到 36.2.26 或更高版本\\n - 换用版本低于 1.8.0.320 的 Java");
					break;
				case CrashReason.实例Json中存在多个Forge:
					val.Add("可能由于其他启动器修改了 Forge 版本，当前实例的文件存在异常，导致了游戏崩溃。\\n请尝试重新全新安装 Forge，而非使用其他启动器修改 Forge 版本。");
					break;
				case CrashReason.玩家手动触发调试崩溃:
					val.Add("* 事实上，你的游戏没有任何问题，这是你自己触发的崩溃。\\n* 你难道没有更重要的事要做吗？");
					break;
				case CrashReason.Mod需要Java11:
					val.Add("你所安装的部分 Mod 似乎需要使用 Java 11 启动。\\n请在启动设置的 Java 选择一项中改用 Java 11，然后再启动游戏。\\n如果你没有安装 Java 11，你可以从网络中下载、安装一个。");
					break;
				case CrashReason.极短的程序输出:
					val.Add($"程序返回了以下信息：\\n{Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value)}\\n\\h");
					break;
				case CrashReason.OptiFine导致无法加载世界:
					val.Add("你所使用的 OptiFine 可能导致了你的游戏出现问题。\\n\\n该问题只在特定 OptiFine 版本中出现，你可以尝试更换 OptiFine 的版本。\\h");
					break;
				case CrashReason.显卡不支持OpenGL:
				case CrashReason.显卡驱动不支持导致无法设置像素格式:
				case CrashReason.Intel驱动不兼容导致EXCEPTION_ACCESS_VIOLATION:
				case CrashReason.AMD驱动不兼容导致EXCEPTION_ACCESS_VIOLATION:
				case CrashReason.Nvidia驱动不兼容导致EXCEPTION_ACCESS_VIOLATION:
					if (LogAll.Contains("hd graphics "))
					{
						val.Add("你的显卡驱动存在问题，或未使用独立显卡，导致游戏无法正常运行。\\n\\n如果你的电脑存在独立显卡，请使用独立显卡而非 Intel 核显启动 PCL 与 Minecraft。\\n如果问题依然存在，请尝试升级你的显卡驱动到最新版本，或回退到出厂版本。\\n如果还是不行，还可以尝试使用 8.0.51 或更低版本的 Java。\\h");
					}
					else
					{
						val.Add("你的显卡驱动存在问题，导致游戏无法正常运行。\\n\\n请尝试升级你的显卡驱动到最新版本，或回退到出厂版本，然后再启动游戏。\\n如果还是不行，可以尝试使用 8.0.51 或更低版本的 Java。\\n如果问题依然存在，那么你可能需要换个更好的显卡……\\h");
					}
					break;
				case CrashReason.材质过大或显卡配置不足:
					val.Add("你所使用的材质分辨率过高，或显卡配置不足，导致游戏无法继续运行。\\n\\n如果你正在使用高清材质，请将它移除。\\n如果你没有使用材质，那么你可能需要更新显卡驱动，或者换个更好的显卡……\\h");
					break;
				case CrashReason.NightConfig的Bug:
					val.Add("由于 Night Config 存在问题，导致了游戏崩溃。\\n你可以尝试安装 Night Config Fixes 模组，这或许能解决此问题。\\h");
					break;
				case CrashReason.光影或资源包导致OpenGL1282错误:
					val.Add("你所使用的光影或材质导致游戏出现了一些问题……\\n\\n请尝试删除你所添加的这些额外资源。\\h");
					break;
				case CrashReason.Mod过多导致超出ID限制:
					val.Add("你所安装的 Mod 过多，超出了游戏的 ID 限制，导致了游戏崩溃。\\n请尝试安装 JEID 等修复 Mod，或删除部分大型 Mod。");
					break;
				case CrashReason.文件或内容校验失败:
					val.Add("部分文件或内容校验失败，导致游戏出现了问题。\\n\\n请尝试删除游戏（包括 Mod）并重新下载，或尝试在重新下载时使用 VPN。\\h");
					break;
				case CrashReason.Forge安装不完整:
					val.Add("由于安装的 Forge 文件丢失，导致游戏无法正常运行。\\n请前往实例设置重置该实例，然后再启动游戏。\\n在打包游戏时删除 libraries 文件夹可能导致此错误。\\h");
					break;
				case CrashReason.Fabric报错:
					if (value.Count == 1)
					{
						val.Add("Fabric 提供了以下错误信息：\\n" + Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value) + "\\n\\n请根据上述信息进行对应处理，如果看不懂英文可以使用翻译软件。");
					}
					else
					{
						val.Add("Fabric 可能已经提供了错误信息，请根据错误报告中的日志信息进行对应处理，如果看不懂英文可以使用翻译软件。\\h");
					}
					break;
				case CrashReason.Mod互不兼容:
					if (value.Count == 1)
					{
						string text = Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value);
						if (text.IsMatch(RegexPatterns.IncompatibleModLoaderErrorHint))
						{
							val.Add("Mod 加载器版本与 Mod 不兼容，请前往 实例设置 - 修改 更换加载器版本。\\n\\n详细信息：\\n" + text);
						}
						else
						{
							val.Add("你所安装的 Mod 不兼容：\\n" + text + "\\n\\n请根据上述信息进行对应处理，如果看不懂英文可以使用翻译软件。");
						}
					}
					else
					{
						val.Add("你所安装的 Mod 不兼容，Mod 加载器可能已经提供了错误信息，请根据错误报告中的日志信息进行对应处理，如果看不懂英文可以使用翻译软件。\\h");
					}
					break;
				case CrashReason.Mod加载器报错:
					if (value.Count == 1)
					{
						val.Add("Mod 加载器提供了以下错误信息：\\n" + Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value) + "\\n\\n请根据上述信息进行对应处理，如果看不懂英文可以使用翻译软件。");
					}
					else
					{
						val.Add("Mod 加载器可能已经提供了错误信息，请根据错误报告中的日志信息进行对应处理，如果看不懂英文可以使用翻译软件。\\h");
					}
					break;
				case CrashReason.Fabric报错并给出解决方案:
					if (value.Count == 1)
					{
						val.Add("Fabric 提供了以下解决方案：\\n" + Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value) + "\\n\\n请根据上述信息进行对应处理，如果看不懂英文可以使用翻译软件。");
					}
					else
					{
						val.Add("Fabric 可能已经提供了解决方案，请根据错误报告中的日志信息进行对应处理，如果看不懂英文可以使用翻译软件。\\h");
					}
					break;
				case CrashReason.Forge报错:
					if (value.Count == 1)
					{
						val.Add("Forge 提供了以下错误信息：\\n" + Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)value) + "\\n\\n请根据上述信息进行对应处理，如果看不懂英文可以使用翻译软件。");
					}
					else
					{
						val.Add("Forge 可能已经提供了错误信息，请根据错误报告中的日志信息进行对应处理，如果看不懂英文可以使用翻译软件。\\h");
					}
					break;
				case CrashReason.没有可用的分析文件:
					val.Add("你的游戏出现了一些问题，但 PCL 未能找到相关记录文件，因此无法进行分析。\\h");
					break;
				default:
					val.Add("PCL 获取到了没有详细信息的错误原因（" + Conversions.ToString((int)Enumerable.First<KeyValuePair<CrashReason, List<string>>>((System.Collections.Generic.IEnumerable<KeyValuePair<CrashReason, List<string>>>)CrashReasons).Key) + "），请向 PCL 作者提交反馈以获取详情。\\h");
					break;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		return ModBase.Join((System.Collections.IEnumerable)val, "\\n\\n此外，").Replace("\\n", "\r\n").Replace("\\h", "")
			.Replace("\\e", IsHandAnalyze ? "" : "\r\n你可以查看错误报告了解错误具体是如何发生的。")
			.Replace("\r\n", "\r")
			.Replace("\n", "\r")
			.Replace("\r", "\r\n")
			.Trim("\r\n".ToCharArray()) + ((!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val, (Func<string, bool>)([SpecialName] (string r) => ModBase.EndsWithF(r, "\\h"))) || IsHandAnalyze) ? "" : ("\r\n如果要寻求帮助，请把错误报告文件发给对方，而不是发送这个窗口的照片或者截图。" + (PageSetupSystem.IsLauncherNewest().GetValueOrDefault(true) ? "" : "\r\n\r\n此外，你正在使用老版本 PCL，更新 PCL 或许也能解决这个问题。\r\n你可以点击 设置 → 启动器 → 检查更新 来更新 PCL。")));
	}
}
