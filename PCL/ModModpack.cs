using FileSystem = Microsoft.VisualBasic.FileIO.FileSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using SearchOption = System.IO.SearchOption;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.Core.App;
using PCL.Core.UI;

namespace PCL;

[StandardModule]
public sealed class ModModpack
{
	public class MMCPackInfo
	{
		public JObject OverridedJson;

		public JObject AdditionalJson;

		public string Tweakers;

		public JArray JvmArgs;

		public JArray Libraries;

		public bool IsMinecraftOverrided;

		public bool IsForgeOverrided;

		public bool IsNeoForgeOverrided;

		public bool IsCleanroomOverrided;

		public bool IsFabricOverrided;

		public bool IsQuiltOverrided;

		public bool IsMcArgsEdited;

		public MMCPackInfo()
		{
			OverridedJson = new JObject();
			AdditionalJson = new JObject();
			Tweakers = null;
			JvmArgs = new JArray();
			Libraries = new JArray();
			IsMinecraftOverrided = false;
			IsForgeOverrided = false;
			IsNeoForgeOverrided = false;
			IsCleanroomOverrided = false;
			IsFabricOverrided = false;
			IsQuiltOverrided = false;
			IsMcArgsEdited = false;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<ZipArchiveEntry, bool> _0024I1_002D0;

		public static Func<JToken, string> _0024I4_002D3;

		public static Func<ModLoader.LoaderBase, double> _0024I4_002D4;

		public static Func<ModLoader.LoaderBase, double> _0024I4_002D5;

		public static Func<ModLoader.LoaderBase, double> _0024I4_002D6;

		public static Action _0024I4_002D9;

		public static Func<JToken, string> _0024I5_002D1;

		public static Func<string, System.Collections.Generic.IEnumerable<string>> _0024I5_002D2;

		public static Func<ModLoader.LoaderBase, double> _0024I5_002D3;

		public static Func<ModLoader.LoaderBase, double> _0024I5_002D4;

		public static Action _0024I5_002D7;

		public static Func<ModLoader.LoaderBase, double> _0024I6_002D1;

		public static Func<ModLoader.LoaderBase, double> _0024I6_002D2;

		public static Action _0024I6_002D4;

		public static Comparison<KeyValuePair<JObject, int>> _0024I8_002D1;

		public static Func<ModLoader.LoaderBase, double> _0024I8_002D3;

		public static Func<ModLoader.LoaderBase, double> _0024I8_002D4;

		public static Action _0024I8_002D6;

		public static Func<ModLoader.LoaderBase, double> _0024I9_002D1;

		public static Func<ModLoader.LoaderBase, double> _0024I9_002D2;

		public static Action _0024I9_002D4;

		public static Action _0024I11_002D1;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal bool _Lambda_0024__1_002D0(ZipArchiveEntry e)
		{
			return e.IsEncrypted;
		}

		[SpecialName]
		internal string _Lambda_0024__4_002D3(JToken l)
		{
			return l["name"].ToString();
		}

		[SpecialName]
		internal double _Lambda_0024__4_002D4(ModLoader.LoaderBase l)
		{
			return l.ProgressWeight;
		}

		[SpecialName]
		internal double _Lambda_0024__4_002D5(ModLoader.LoaderBase l)
		{
			return l.ProgressWeight;
		}

		[SpecialName]
		internal double _Lambda_0024__4_002D6(ModLoader.LoaderBase l)
		{
			return l.ProgressWeight;
		}

		[SpecialName]
		internal void _Lambda_0024__4_002D9()
		{
			ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
		}

		[SpecialName]
		internal string _Lambda_0024__5_002D1(JToken x)
		{
			return ModComp.CompFile.HandleCurseForgeDownloadUrls(x.ToString());
		}

		[SpecialName]
		internal System.Collections.Generic.IEnumerable<string> _Lambda_0024__5_002D2(string x)
		{
			return (System.Collections.Generic.IEnumerable<string>)ModDownload.DlSourceModDownloadGet(x);
		}

		[SpecialName]
		internal double _Lambda_0024__5_002D3(ModLoader.LoaderBase l)
		{
			return l.ProgressWeight;
		}

		[SpecialName]
		internal double _Lambda_0024__5_002D4(ModLoader.LoaderBase l)
		{
			return l.ProgressWeight;
		}

		[SpecialName]
		internal void _Lambda_0024__5_002D7()
		{
			ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
		}

		[SpecialName]
		internal double _Lambda_0024__6_002D1(ModLoader.LoaderBase l)
		{
			return l.ProgressWeight;
		}

		[SpecialName]
		internal double _Lambda_0024__6_002D2(ModLoader.LoaderBase l)
		{
			return l.ProgressWeight;
		}

		[SpecialName]
		internal void _Lambda_0024__6_002D4()
		{
			ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
		}

		[SpecialName]
		internal int _Lambda_0024__8_002D1(KeyValuePair<JObject, int> x, KeyValuePair<JObject, int> y)
		{
			return x.Value.CompareTo(y.Value);
		}

		[SpecialName]
		internal double _Lambda_0024__8_002D3(ModLoader.LoaderBase l)
		{
			return l.ProgressWeight;
		}

		[SpecialName]
		internal double _Lambda_0024__8_002D4(ModLoader.LoaderBase l)
		{
			return l.ProgressWeight;
		}

		[SpecialName]
		internal void _Lambda_0024__8_002D6()
		{
			ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
		}

		[SpecialName]
		internal double _Lambda_0024__9_002D1(ModLoader.LoaderBase l)
		{
			return l.ProgressWeight;
		}

		[SpecialName]
		internal double _Lambda_0024__9_002D2(ModLoader.LoaderBase l)
		{
			return l.ProgressWeight;
		}

		[SpecialName]
		internal void _Lambda_0024__9_002D4()
		{
			ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
		}

		[SpecialName]
		internal void _Lambda_0024__11_002D1()
		{
			ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSelect);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__10_002D0
	{
		public string _0024VB_0024Local_TargetFolder;

		public string _0024VB_0024Local_FileAddress;

		public string _0024VB_0024Local_ArchiveBaseFolder;

		public _Closure_0024__10_002D0(_Closure_0024__10_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_TargetFolder = arg0._0024VB_0024Local_TargetFolder;
				_0024VB_0024Local_FileAddress = arg0._0024VB_0024Local_FileAddress;
				_0024VB_0024Local_ArchiveBaseFolder = arg0._0024VB_0024Local_ArchiveBaseFolder;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<string, int> Task)
		{
			ExtractModpackFiles(_0024VB_0024Local_TargetFolder, _0024VB_0024Local_FileAddress, Task, 0.9);
			Thread.Sleep(400);
			string text = null;
			string[] files = Directory.GetFiles(_0024VB_0024Local_TargetFolder, "*.exe", (SearchOption)0);
			foreach (string text2 in files)
			{
				FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(text2);
				ModBase.Log($"[Modpack] 文件 {text2} 的产品名标识为 {versionInfo.ProductName}");
				if (Operators.CompareString(versionInfo.ProductName, "Plain Craft Launcher", false) == 0)
				{
					text = text2;
					ModBase.Log($"[Modpack] 发现整合包附带的 PCL 启动器：{text2}");
				}
				else if ((ModBase.ContainsF(versionInfo.ProductName, "Launcher", IgnoreCase: true) || ModBase.ContainsF(versionInfo.ProductName, "启动", IgnoreCase: true)) && Operators.CompareString(versionInfo.ProductName, "Plain Craft Launcher Admin Manager", false) != 0 && text == null)
				{
					text = text2;
					ModBase.Log($"[Modpack] 发现整合包附带的疑似第三方启动器：{text2}");
				}
			}
			Task.Progress = 0.95;
			if (text != null)
			{
				ModBase.Log("[Modpack] 找到压缩包中附带的启动器：" + text);
				if (ModMain.MyMsgBox(string.Format("整合包里似乎自带了启动器，是否换用它继续安装？{0}即将打开：{1}", (object)"\r\n", (object)text), "换用整合包启动器？", "换用", "不换用") == 1)
				{
					ModBase.OpenExplorer(_0024VB_0024Local_TargetFolder);
					ModBase.ShellOnly(text, "--wait");
					ModBase.Log("[Modpack] 为换用整合包中的启动器启动，强制结束程序");
					ModMain.FrmMain.EndProgram(SendWarning: false);
					return;
				}
			}
			else
			{
				ModBase.Log("[Modpack] 未找到压缩包中附带的启动器");
			}
			ModBase.OpenExplorer(_0024VB_0024Local_TargetFolder);
			string folderNameFromPath = ModBase.GetFolderNameFromPath(_0024VB_0024Local_TargetFolder);
			Directory.CreateDirectory(_0024VB_0024Local_TargetFolder + ".minecraft\\");
			PageSelectLeft.AddFolder(_0024VB_0024Local_TargetFolder + ".minecraft\\" + _0024VB_0024Local_ArchiveBaseFolder.Replace("/", "\\").TrimStart('\\'), folderNameFromPath, ShowHint: false);
			string text3 = Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)Directory.GetFiles(_0024VB_0024Local_TargetFolder, "modpack.*", (SearchOption)1));
			ModBase.Log("[Modpack] 调用 modpack 文件继续安装：" + text3);
			ModpackInstall(text3);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__11_002D0
	{
		public string _0024VB_0024Local_TargetFolder;

		public string _0024VB_0024Local_FileAddress;

		public string _0024VB_0024Local_ArchiveBaseFolder;

		public _Closure_0024__11_002D0(_Closure_0024__11_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_TargetFolder = arg0._0024VB_0024Local_TargetFolder;
				_0024VB_0024Local_FileAddress = arg0._0024VB_0024Local_FileAddress;
				_0024VB_0024Local_ArchiveBaseFolder = arg0._0024VB_0024Local_ArchiveBaseFolder;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<string, int> Task)
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			ExtractModpackFiles(_0024VB_0024Local_TargetFolder, _0024VB_0024Local_FileAddress, Task, 0.95);
			PageSelectLeft.AddFolder(_0024VB_0024Local_TargetFolder + _0024VB_0024Local_ArchiveBaseFolder, ModBase.GetFolderNameFromPath(_0024VB_0024Local_TargetFolder), ShowHint: false);
			Thread.Sleep(400);
			object action;
			if (_Closure_0024__._0024I11_002D1 != null)
			{
				action = _Closure_0024__._0024I11_002D1;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSelect);
				};
				_Closure_0024__._0024I11_002D1 = val;
				action = (object)val;
			}
			ModBase.RunInUi((Action)action);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__2_002D0
	{
		public ModLoader.LoaderBase _0024VB_0024Local_Loader;

		public double _0024VB_0024Local_ProgressIncrement;

		public _Closure_0024__2_002D0(_Closure_0024__2_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
				_0024VB_0024Local_ProgressIncrement = arg0._0024VB_0024Local_ProgressIncrement;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(double Delta)
		{
			_0024VB_0024Local_Loader.Progress += Delta * _0024VB_0024Local_ProgressIncrement;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__4_002D0
	{
		public string _0024VB_0024Local_InstallTemp;

		public string _0024VB_0024Local_FileAddress;

		public string _0024VB_0024Local_ArchiveBaseFolder;

		public string _0024VB_0024Local_OverrideHome;

		public string _0024VB_0024Local_InstanceName;

		public List<int> _0024VB_0024Local_ModList;

		public List<int> _0024VB_0024Local_ModOptionalList;

		public string _0024VB_0024Local_Logo;

		public JObject _0024VB_0024Local_Json;

		public string _0024VB_0024Local_resourceId;

		public string _0024VB_0024Local_LoaderName;

		public _Closure_0024__4_002D0(_Closure_0024__4_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_InstallTemp = arg0._0024VB_0024Local_InstallTemp;
				_0024VB_0024Local_FileAddress = arg0._0024VB_0024Local_FileAddress;
				_0024VB_0024Local_ArchiveBaseFolder = arg0._0024VB_0024Local_ArchiveBaseFolder;
				_0024VB_0024Local_OverrideHome = arg0._0024VB_0024Local_OverrideHome;
				_0024VB_0024Local_InstanceName = arg0._0024VB_0024Local_InstanceName;
				_0024VB_0024Local_ModList = arg0._0024VB_0024Local_ModList;
				_0024VB_0024Local_ModOptionalList = arg0._0024VB_0024Local_ModOptionalList;
				_0024VB_0024Local_Logo = arg0._0024VB_0024Local_Logo;
				_0024VB_0024Local_Json = arg0._0024VB_0024Local_Json;
				_0024VB_0024Local_resourceId = arg0._0024VB_0024Local_resourceId;
				_0024VB_0024Local_LoaderName = arg0._0024VB_0024Local_LoaderName;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<string, int> Task)
		{
			ExtractModpackFiles(_0024VB_0024Local_InstallTemp, _0024VB_0024Local_FileAddress, Task, 0.6);
			CopyOverrideDirectory(_0024VB_0024Local_InstallTemp + _0024VB_0024Local_ArchiveBaseFolder + ((Operators.CompareString(_0024VB_0024Local_OverrideHome, ".", false) == 0 || Operators.CompareString(_0024VB_0024Local_OverrideHome, "./", false) == 0) ? "" : _0024VB_0024Local_OverrideHome), $"{ModMinecraft.PathMcFolder}versions\\{_0024VB_0024Local_InstanceName}", Task, 0.4);
		}

		[SpecialName]
		internal void _Lambda_0024__1(ModLoader.LoaderTask<int, JArray> Task)
		{
			bool flag = true;
			int num = 0;
			do
			{
				num = checked(num + 1);
				JArray jArray = (JArray)NewLateBinding.LateIndexGet(ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/mods/files", "POST", "{\"fileIds\": [" + ModBase.Join((System.Collections.IEnumerable)_0024VB_0024Local_ModList, ",") + "]}", "application/json", flag)), new object[] { "data" }, (string[])null);
				if (_0024VB_0024Local_ModList.Count <= jArray.Count)
				{
					ModBase.Log("[Modpack] 已获取到的模组数量足够，开始进行下一步");
					Task.Output = jArray;
					return;
				}
				flag = false;
				ModBase.Log($"[Modpack] 获取模组数量不达标，设置镜像源允许状态为: {flag}");
			}
			while (num <= 3);
			throw new System.Exception("整合包中的部分 Mod 版本已被 Mod 作者删除，所以没法继续安装了，请向整合包作者反馈该问题");
		}

		[SpecialName]
		internal void _Lambda_0024__2(ModLoader.LoaderTask<JArray, List<ModNet.NetFile>> Task)
		{
			Dictionary<int, ModNet.NetFile> val = new Dictionary<int, ModNet.NetFile>();
			System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator = Task.Input.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					JToken current = enumerator.Current;
					int num = current["id"].ToObject<int>();
					if (val.ContainsKey(num) || (_0024VB_0024Local_ModOptionalList.Contains(num) && ModMain.MyMsgBox("是否要下载整合包中的可选文件 " + current["displayName"].ToString() + "？", "下载可选文件", "是", "否") == 2))
					{
						continue;
					}
					string text2;
					ModComp.CompType defaultType;
					if (Enumerable.Any<JToken>((System.Collections.Generic.IEnumerable<JToken>)current["modules"]))
					{
						List<string> val2 = Enumerable.ToList<string>(Enumerable.Select<JToken, string>((System.Collections.Generic.IEnumerable<JToken>)(JArray)current["modules"], (Func<JToken, string>)([SpecialName] (JToken l) => l["name"].ToString())));
						if (val2.Contains("META-INF") || val2.Contains("mcmod.info"))
						{
							goto IL_012f;
						}
						if (current != null)
						{
							JToken? jToken = current["FileName"];
							if (jToken != null)
							{
								string text = jToken.ToString();
								if (text != null && ModBase.EndsWithF(text, ".jar", IgnoreCase: true))
								{
									goto IL_012f;
								}
							}
						}
						if (val2.Contains("pack.mcmeta"))
						{
							text2 = "resourcepacks";
							defaultType = ModComp.CompType.ResourcePack;
						}
						else if (val2.Contains("level.dat"))
						{
							text2 = "saves";
							defaultType = ModComp.CompType.World;
						}
						else
						{
							text2 = "shaderpacks";
							defaultType = ModComp.CompType.Shader;
						}
					}
					else
					{
						text2 = "mods";
						defaultType = ModComp.CompType.Mod;
					}
					goto IL_0185;
					IL_012f:
					text2 = "mods";
					defaultType = ModComp.CompType.Mod;
					goto IL_0185;
					IL_0185:
					ModComp.CompFile compFile = new ModComp.CompFile((JObject)current, defaultType);
					if (compFile.Available)
					{
						val.Add(num, compFile.ToNetFile($"{ModMinecraft.PathMcFolder}versions\\{_0024VB_0024Local_InstanceName}\\{text2}\\"));
						Task.Progress += 1.0 / (double)checked(1 + _0024VB_0024Local_ModList.Count);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			Task.Output = Enumerable.ToList<ModNet.NetFile>((System.Collections.Generic.IEnumerable<ModNet.NetFile>)val.Values);
		}

		[SpecialName]
		internal void _Lambda_0024__7(ModLoader.LoaderTask<string, string> Task)
		{
			string text = $"{ModMinecraft.PathMcFolder}versions\\{_0024VB_0024Local_InstanceName}\\";
			if (_0024VB_0024Local_Logo != null && File.Exists(_0024VB_0024Local_Logo))
			{
				File.Copy(_0024VB_0024Local_Logo, text + "PCL\\Logo.png", true);
				Config.Instance.LogoPath[text] = "PCL\\Logo.png";
				Config.Instance.IsLogoCustom[text] = true;
				ModBase.Log("[ModPack] 已设置整合包 Logo：" + _0024VB_0024Local_Logo);
			}
			string[] array = new string[2]
			{
				text + "原始整合包.zip",
				text + "原始整合包.mrpack"
			};
			foreach (string text2 in array)
			{
				if (File.Exists(text2))
				{
					ModBase.Log("[ModPack] 删除原始整合包文件：" + text2);
					File.Delete(text2);
				}
			}
			if (File.Exists(_0024VB_0024Local_FileAddress) && Operators.CompareString(ModBase.GetFileNameWithoutExtentionFromPath(_0024VB_0024Local_FileAddress), "modpack", false) == 0)
			{
				ModBase.Log("[ModPack] 删除安装整合包文件：" + _0024VB_0024Local_FileAddress);
				File.Delete(_0024VB_0024Local_FileAddress);
			}
			if (_0024VB_0024Local_Json["version"] != null)
			{
				Config.Instance.ModpackVersion[text] = _0024VB_0024Local_Json["version"].ToString();
			}
			Config.Instance.ModpackSource[text] = "CurseForge";
			Config.Instance.ModpackId[text] = _0024VB_0024Local_resourceId;
			try
			{
				List<string> obj = new List<string>();
				obj.Add(_0024VB_0024Local_resourceId);
				List<ModComp.CompProject> compProjectsByIds = ModComp.CompRequest.GetCompProjectsByIds(obj);
				if (compProjectsByIds.Count != 0)
				{
					Config.Instance.CustomInfo[text] = Enumerable.First<ModComp.CompProject>((System.Collections.Generic.IEnumerable<ModComp.CompProject>)compProjectsByIds).Description;
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "[ModPack] 获取整合包描述文本失败");
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__8(ModLoader.LoaderBase l)
		{
			return Operators.CompareString(l.Name, _0024VB_0024Local_LoaderName, false) == 0;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__5_002D0
	{
		public string _0024VB_0024Local_InstallTemp;

		public string _0024VB_0024Local_FileAddress;

		public string _0024VB_0024Local_ArchiveBaseFolder;

		public string _0024VB_0024Local_InstanceName;

		public string _0024VB_0024Local_Logo;

		public JObject _0024VB_0024Local_Json;

		public string _0024VB_0024Local_resourceId;

		public string _0024VB_0024Local_LoaderName;

		public _Closure_0024__5_002D0(_Closure_0024__5_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_InstallTemp = arg0._0024VB_0024Local_InstallTemp;
				_0024VB_0024Local_FileAddress = arg0._0024VB_0024Local_FileAddress;
				_0024VB_0024Local_ArchiveBaseFolder = arg0._0024VB_0024Local_ArchiveBaseFolder;
				_0024VB_0024Local_InstanceName = arg0._0024VB_0024Local_InstanceName;
				_0024VB_0024Local_Logo = arg0._0024VB_0024Local_Logo;
				_0024VB_0024Local_Json = arg0._0024VB_0024Local_Json;
				_0024VB_0024Local_resourceId = arg0._0024VB_0024Local_resourceId;
				_0024VB_0024Local_LoaderName = arg0._0024VB_0024Local_LoaderName;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<string, int> Task)
		{
			ExtractModpackFiles(_0024VB_0024Local_InstallTemp, _0024VB_0024Local_FileAddress, Task, 0.5);
			CopyOverrideDirectory(_0024VB_0024Local_InstallTemp + _0024VB_0024Local_ArchiveBaseFolder + "overrides", ModMinecraft.PathMcFolder + "versions\\" + _0024VB_0024Local_InstanceName, Task, 0.4);
			CopyOverrideDirectory(_0024VB_0024Local_InstallTemp + _0024VB_0024Local_ArchiveBaseFolder + "client-overrides", ModMinecraft.PathMcFolder + "versions\\" + _0024VB_0024Local_InstanceName, Task, 0.1);
		}

		[SpecialName]
		internal void _Lambda_0024__5(ModLoader.LoaderTask<string, string> Task)
		{
			string text = $"{ModMinecraft.PathMcFolder}versions\\{_0024VB_0024Local_InstanceName}\\";
			if (_0024VB_0024Local_Logo != null && File.Exists(_0024VB_0024Local_Logo))
			{
				File.Copy(_0024VB_0024Local_Logo, text + "PCL\\Logo.png", true);
				Config.Instance.LogoPath[text] = "PCL\\Logo.png";
				Config.Instance.IsLogoCustom[text] = true;
				ModBase.Log("[ModPack] 已设置整合包 Logo：" + _0024VB_0024Local_Logo);
			}
			string[] array = new string[2]
			{
				text + "原始整合包.zip",
				text + "原始整合包.mrpack"
			};
			foreach (string text2 in array)
			{
				if (File.Exists(text2))
				{
					ModBase.Log("[ModPack] 删除原始整合包文件：" + text2);
					File.Delete(text2);
				}
			}
			if (File.Exists(_0024VB_0024Local_FileAddress) && Operators.CompareString(ModBase.GetFileNameWithoutExtentionFromPath(_0024VB_0024Local_FileAddress), "modpack", false) == 0)
			{
				ModBase.Log("[ModPack] 删除安装整合包文件：" + _0024VB_0024Local_FileAddress);
				File.Delete(_0024VB_0024Local_FileAddress);
			}
			if (_0024VB_0024Local_Json["versionId"] != null)
			{
				Config.Instance.ModpackVersion[text] = _0024VB_0024Local_Json["versionId"].ToString();
			}
			Config.Instance.ModpackSource[text] = "Modrinth";
			Config.Instance.ModpackId[text] = _0024VB_0024Local_resourceId;
			try
			{
				List<string> obj = new List<string>();
				obj.Add(_0024VB_0024Local_resourceId);
				List<ModComp.CompProject> compProjectsByIds = ModComp.CompRequest.GetCompProjectsByIds(obj);
				if (compProjectsByIds.Count != 0)
				{
					Config.Instance.CustomInfo[text] = Enumerable.First<ModComp.CompProject>((System.Collections.Generic.IEnumerable<ModComp.CompProject>)compProjectsByIds).Description;
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "[ModPack] 获取整合包描述文本失败");
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__6(ModLoader.LoaderBase l)
		{
			return Operators.CompareString(l.Name, _0024VB_0024Local_LoaderName, false) == 0;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__8_002D0
	{
		public string _0024VB_0024Local_ArchiveBaseFolder;

		public string _0024VB_0024Local_InstallTemp;

		public string _0024VB_0024Local_FileAddress;

		public string _0024VB_0024Local_InstanceName;

		public string _0024VB_0024Local_VersionFolder;

		public string _0024VB_0024Local_LoaderName;

		public _Closure_0024__8_002D0(_Closure_0024__8_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ArchiveBaseFolder = arg0._0024VB_0024Local_ArchiveBaseFolder;
				_0024VB_0024Local_InstallTemp = arg0._0024VB_0024Local_InstallTemp;
				_0024VB_0024Local_FileAddress = arg0._0024VB_0024Local_FileAddress;
				_0024VB_0024Local_InstanceName = arg0._0024VB_0024Local_InstanceName;
				_0024VB_0024Local_VersionFolder = arg0._0024VB_0024Local_VersionFolder;
				_0024VB_0024Local_LoaderName = arg0._0024VB_0024Local_LoaderName;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(ZipArchiveEntry e)
		{
			return e.FullName.Equals(_0024VB_0024Local_ArchiveBaseFolder + "patches/", (StringComparison)5);
		}

		[SpecialName]
		internal void _Lambda_0024__2(ModLoader.LoaderTask<string, int> Task)
		{
			ExtractModpackFiles(_0024VB_0024Local_InstallTemp, _0024VB_0024Local_FileAddress, Task, 0.55);
			CopyOverrideDirectory(_0024VB_0024Local_InstallTemp + _0024VB_0024Local_ArchiveBaseFolder + "libraries", ModMinecraft.PathMcFolder + "versions\\" + _0024VB_0024Local_InstanceName + "\\libraries", Task, 0.2);
			CopyOverrideDirectory(_0024VB_0024Local_InstallTemp + _0024VB_0024Local_ArchiveBaseFolder + ".minecraft", ModMinecraft.PathMcFolder + "versions\\" + _0024VB_0024Local_InstanceName, Task, 0.2);
			try
			{
				string text = _0024VB_0024Local_InstallTemp + _0024VB_0024Local_ArchiveBaseFolder + "instance.cfg";
				if (!File.Exists(text))
				{
					return;
				}
				List<string> val = new List<string>();
				string[] array = ModBase.ReadFile(text).Split(new string[] { "\r", "\n" }, (StringSplitOptions)1);
				foreach (string text2 in array)
				{
					if (text2.Contains("="))
					{
						val.Add(ModBase.BeforeFirst(text2, "=") + ":" + ModBase.AfterFirst(text2, "="));
					}
				}
				ModBase.WriteFile(text, ModBase.Join((System.Collections.IEnumerable)val, "\r\n"));
				if (Conversions.ToBoolean(ModBase.ReadIni(text, "OverrideCommands", Conversions.ToString(false))))
				{
					string text3 = ModBase.ReadIni(text, "PreLaunchCommand");
					if (Operators.CompareString(text3, "", false) != 0)
					{
						text3 = text3.Replace("\\\"", "\"").Replace("$INST_JAVA", "{java}javaw.exe").Replace("$INST_MC_DIR\\", "{minecraft}")
							.Replace("$INST_MC_DIR", "{minecraft}")
							.Replace("$INST_DIR\\", "{verpath}")
							.Replace("$INST_DIR", "{verpath}")
							.Replace("$INST_ID", "{name}")
							.Replace("$INST_NAME", "{name}");
						Config.Instance.PreLaunchCommand[_0024VB_0024Local_VersionFolder] = text3;
						ModBase.Log("[ModPack] 迁移 MultiMC 实例独立设置：启动前执行命令：" + text3);
					}
				}
				if (Conversions.ToBoolean(ModBase.ReadIni(text, "JoinServerOnLaunch", Conversions.ToString(false))))
				{
					string text4 = ModBase.ReadIni(text, "JoinServerOnLaunchAddress").Replace("\\\"", "\"");
					Config.Instance.ServerToEnter[_0024VB_0024Local_VersionFolder] = text4;
					ModBase.Log("[ModPack] 迁移 MultiMC 实例独立设置：自动进入服务器：" + text4);
				}
				if (Conversions.ToBoolean(ModBase.ReadIni(text, "IgnoreJavaCompatibility", Conversions.ToString(false))))
				{
					Config.Instance.IgnoreJavaCompatibility[_0024VB_0024Local_VersionFolder] = true;
					ModBase.Log("[ModPack] 迁移 MultiMC 实例独立设置：忽略 Java 兼容性警告");
				}
				string text5 = ModBase.ReadIni(text, "iconKey");
				if (Operators.CompareString(text5, "", false) != 0 && File.Exists($"{_0024VB_0024Local_InstallTemp}{_0024VB_0024Local_ArchiveBaseFolder}{text5}.png"))
				{
					Config.Instance.IsLogoCustom[_0024VB_0024Local_VersionFolder] = true;
					Config.Instance.LogoPath[_0024VB_0024Local_VersionFolder] = "PCL\\Logo.png";
					ModBase.CopyFile($"{_0024VB_0024Local_InstallTemp}{_0024VB_0024Local_ArchiveBaseFolder}{text5}.png", $"{ModMinecraft.PathMcFolder}versions\\{_0024VB_0024Local_InstanceName}\\PCL\\Logo.png");
					ModBase.Log($"[ModPack] 迁移 MultiMC 实例独立设置：实例图标（{text5}.png）");
				}
				string text6 = ModBase.ReadIni(text, "JvmArgs");
				if (Operators.CompareString(text6, "", false) != 0)
				{
					if (Conversions.ToBoolean(ModBase.ReadIni(text, "OverrideJavaArgs", Conversions.ToString(false))))
					{
						Config.Instance.JvmArgs[_0024VB_0024Local_VersionFolder] = text6;
						ModBase.Log("[ModPack] 迁移 MultiMC 实例独立设置：JVM 参数（覆盖）：" + text6);
					}
					else
					{
						text6 = Conversions.ToString(Operators.AddObject((object)text6, Operators.ConcatenateObject((object)" ", ModBase.Setup.Get("LaunchAdvanceJvm"))));
						Config.Instance.JvmArgs[_0024VB_0024Local_VersionFolder] = text6;
						ModBase.Log("[ModPack] 迁移 MultiMC 实例独立设置：JVM 参数（追加）：" + text6);
					}
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, $"读取 MMC 配置文件失败（{_0024VB_0024Local_InstallTemp}{_0024VB_0024Local_ArchiveBaseFolder}instance.cfg）");
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__5(ModLoader.LoaderBase l)
		{
			return Operators.CompareString(l.Name, _0024VB_0024Local_LoaderName, false) == 0;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__9_002D0
	{
		public string _0024VB_0024Local_InstallTemp;

		public string _0024VB_0024Local_FileAddress;

		public string _0024VB_0024Local_ArchiveBaseFolder;

		public string _0024VB_0024Local_InstanceName;

		public JObject _0024VB_0024Local_Json;

		public string _0024VB_0024Local_VersionFolder;

		public string _0024VB_0024Local_LoaderName;

		public _Closure_0024__9_002D0(_Closure_0024__9_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_InstallTemp = arg0._0024VB_0024Local_InstallTemp;
				_0024VB_0024Local_FileAddress = arg0._0024VB_0024Local_FileAddress;
				_0024VB_0024Local_ArchiveBaseFolder = arg0._0024VB_0024Local_ArchiveBaseFolder;
				_0024VB_0024Local_InstanceName = arg0._0024VB_0024Local_InstanceName;
				_0024VB_0024Local_Json = arg0._0024VB_0024Local_Json;
				_0024VB_0024Local_VersionFolder = arg0._0024VB_0024Local_VersionFolder;
				_0024VB_0024Local_LoaderName = arg0._0024VB_0024Local_LoaderName;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<string, int> Task)
		{
			ExtractModpackFiles(_0024VB_0024Local_InstallTemp, _0024VB_0024Local_FileAddress, Task, 0.6);
			CopyOverrideDirectory(_0024VB_0024Local_InstallTemp + _0024VB_0024Local_ArchiveBaseFolder + "overrides", ModMinecraft.PathMcFolder + "versions\\" + _0024VB_0024Local_InstanceName, Task, 0.4);
			if (_0024VB_0024Local_Json["launchInfo"] != null)
			{
				JObject jObject = (JObject)_0024VB_0024Local_Json["launchInfo"];
				Config.Instance.JvmArgs[_0024VB_0024Local_VersionFolder] = string.Join<JToken>(" ", (System.Collections.Generic.IEnumerable<JToken>)jObject["javaArgument"]);
				Config.Instance.GameArgs[_0024VB_0024Local_VersionFolder] = string.Join<JToken>(" ", (System.Collections.Generic.IEnumerable<JToken>)jObject["launchArgument"]);
			}
			if (_0024VB_0024Local_Json["version"] != null)
			{
				Config.Instance.ModpackVersion[_0024VB_0024Local_VersionFolder] = _0024VB_0024Local_Json["version"].ToString();
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__3(ModLoader.LoaderBase l)
		{
			return Operators.CompareString(l.Name, _0024VB_0024Local_LoaderName, false) == 0;
		}
	}

	public static void ModpackInstall()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		string text = SystemDialogs.SelectFile("整合包文件(*.rar;*.zip;*.mrpack)|*.rar;*.zip;*.mrpack", "选择整合包压缩文件");
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		ModBase.RunInThread((Action)([SpecialName] () =>
		{
			try
			{
				ModpackInstall(text);
			}
			catch (ModBase.CancelledException ex)
			{
				ProjectData.SetProjectError((System.Exception)ex);
				ModBase.CancelledException ex2 = ex;
				ProjectData.ClearProjectError();
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "手动安装整合包失败", ModBase.LogLevel.Msgbox);
				ProjectData.ClearProjectError();
			}
		}));
	}

	public static ModLoader.LoaderCombo<string> ModpackInstall(string File, string InstanceName = null, string Logo = null, string resourceId = null)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		ModBase.Log("[ModPack] 整合包安装请求：" + (File ?? "null"));
		ZipArchive val = null;
		string archiveBaseFolder = "";
		try
		{
			string text = $"{ModMinecraft.PathMcFolder}versions\\{InstanceName}\\";
			if (text.Contains("!") || text.Contains(";"))
			{
				ModMain.Hint("游戏路径中不能含有感叹号或分号：" + text, ModMain.HintType.Critical);
				throw new ModBase.CancelledException();
			}
			int num = -1;
			try
			{
				val = new ZipArchive((Stream)new FileStream(File, (FileMode)3, (FileAccess)1, (FileShare)1));
				if (Enumerable.Any<ZipArchiveEntry>((System.Collections.Generic.IEnumerable<ZipArchiveEntry>)val.Entries, (Func<ZipArchiveEntry, bool>)([SpecialName] (ZipArchiveEntry e) => e.IsEncrypted)))
				{
					throw new System.Exception("PCL 无法处理加密的压缩包，请在解压后重新压缩为不加密的 zip 格式再试");
				}
				if (val.GetEntry("mcbbs.packmeta") != null)
				{
					num = 3;
				}
				else if (val.GetEntry("mmc-pack.json") != null)
				{
					num = 2;
				}
				else if (val.GetEntry("modrinth.index.json") != null)
				{
					num = 4;
				}
				else if (val.GetEntry("manifest.json") != null)
				{
					num = ((((JObject)ModBase.GetJson(ModBase.ReadFile(val.GetEntry("manifest.json").Open(), Encoding.UTF8)))["addons"] != null) ? 3 : 0);
				}
				else if (val.GetEntry("modpack.json") != null)
				{
					num = 1;
				}
				else if (val.GetEntry("modpack.zip") != null || val.GetEntry("modpack.mrpack") != null)
				{
					num = 9;
				}
				else
				{
					System.Collections.Generic.IEnumerator<ZipArchiveEntry> enumerator = default(System.Collections.Generic.IEnumerator<ZipArchiveEntry>);
					try
					{
						enumerator = val.Entries.GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator).MoveNext())
						{
							ZipArchiveEntry current = enumerator.Current;
							string[] array = current.FullName.Split("/", (StringSplitOptions)0);
							archiveBaseFolder = array[0] + "/";
							if (Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)array) != 2)
							{
								continue;
							}
							if (Operators.CompareString(array[1], "mcbbs.packmeta", false) == 0)
							{
								num = 3;
								break;
							}
							if (Operators.CompareString(array[1], "mmc-pack.json", false) == 0)
							{
								num = 2;
								break;
							}
							if (Operators.CompareString(array[1], "modrinth.index.json", false) == 0)
							{
								num = 4;
								break;
							}
							if (Operators.CompareString(array[1], "manifest.json", false) == 0)
							{
								if (((JObject)ModBase.GetJson(ModBase.ReadFile(current.Open(), Encoding.UTF8)))["addons"] == null)
								{
									num = 0;
									break;
								}
								num = 3;
								archiveBaseFolder = "overrides/";
								break;
							}
							if (Operators.CompareString(array[1], "modpack.json", false) == 0)
							{
								num = 1;
								break;
							}
							if (Operators.CompareString(array[1], "modpack.zip", false) == 0 || Operators.CompareString(array[1], "modpack.mrpack", false) == 0)
							{
								num = 9;
								break;
							}
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
				if (ex2.Message.Contains("Error.WinIOError"))
				{
					throw new System.Exception("打开整合包文件失败", ex2);
				}
				if (ModBase.EndsWithF(File, ".rar", IgnoreCase: true))
				{
					throw new System.Exception("PCL 无法处理 rar 格式的压缩包，请在解压后重新压缩为 zip 格式再试", ex2);
				}
				throw new System.Exception("打开整合包文件失败，文件可能损坏或为不支持的压缩包格式", ex2);
			}
			switch (num)
			{
			case 0:
				ModBase.Log("[ModPack] 整合包种类：CurseForge");
				return InstallPackCurseForge(File, val, archiveBaseFolder, InstanceName, Logo, resourceId);
			case 1:
				ModBase.Log("[ModPack] 整合包种类：HMCL");
				return InstallPackHMCL(File, val, archiveBaseFolder);
			case 2:
				ModBase.Log("[ModPack] 整合包种类：MMC");
				return InstallPackMMC(File, val, archiveBaseFolder);
			case 3:
				ModBase.Log("[ModPack] 整合包种类：MCBBS");
				return InstallPackMCBBS(File, val, archiveBaseFolder, InstanceName);
			case 4:
				ModBase.Log("[ModPack] 整合包种类：Modrinth");
				return InstallPackModrinth(File, val, archiveBaseFolder, InstanceName, Logo, resourceId);
			case 9:
				ModBase.Log("[ModPack] 整合包种类：带启动器的压缩包");
				return InstallPackLauncherPack(File, val, archiveBaseFolder);
			default:
				ModBase.Log("[ModPack] 整合包种类：未能识别，假定为压缩包");
				return InstallPackCompress(File, val);
			}
		}
		finally
		{
			if (val != null)
			{
				val.Dispose();
			}
		}
	}

	private static void ExtractModpackFiles(string InstallTemp, string FileAddress, ModLoader.LoaderBase Loader, double ProgressIncrement)
	{
		_Closure_0024__2_002D0 arg = default(_Closure_0024__2_002D0);
		_Closure_0024__2_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__2_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader = Loader;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ProgressIncrement = ProgressIncrement;
		int num = 1;
		Encoding encode = Encoding.GetEncoding("GB18030");
		double progress = CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Progress;
		checked
		{
			while (true)
			{
				try
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Progress = progress;
					ModBase.DeleteDirectory(InstallTemp);
					ModBase.ExtractFile(FileAddress, InstallTemp, encode, [SpecialName] (double Delta) =>
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Progress += Delta * CS_0024_003C_003E8__locals0._0024VB_0024Local_ProgressIncrement;
					});
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "第 " + Conversions.ToString(num) + " 次解压尝试失败");
					if (ex2 is ArgumentException || ex2 is IOException)
					{
						encode = Encoding.UTF8;
						ModBase.Log("[ModPack] 已切换压缩包解压编码为 UTF8");
					}
					if (num < 5)
					{
						Thread.Sleep(num * 2000);
						if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader != null && CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.LoadingState != 0)
						{
							ProjectData.ClearProjectError();
							return;
						}
						num++;
						ProjectData.ClearProjectError();
						continue;
					}
					throw new System.Exception("解压整合包文件失败", ex2);
				}
				break;
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Progress = progress + CS_0024_003C_003E8__locals0._0024VB_0024Local_ProgressIncrement;
		}
	}

	private static void CopyOverrideDirectory(string OverridesFolder, string VersionFolder, ModLoader.LoaderBase Loader, double ProgressIncrement)
	{
		if (!ModBase.EndsWithF(OverridesFolder, "\\"))
		{
			OverridesFolder += "\\";
		}
		if (!ModBase.EndsWithF(VersionFolder, "\\"))
		{
			VersionFolder += "\\";
		}
		if (Directory.Exists(OverridesFolder))
		{
			ModBase.Log($"[ModPack] 处理整合包覆写文件夹：{OverridesFolder} → {VersionFolder}");
			ModBase.CopyDirectory(OverridesFolder, VersionFolder, [SpecialName] (double Delta) =>
			{
				Loader.Progress += Delta * ProgressIncrement;
			});
		}
		else
		{
			ModBase.Log($"[ModPack] 整合包中没有覆写文件夹：{OverridesFolder}");
			Loader.Progress += ProgressIncrement;
		}
		string text = $"{OverridesFolder}PCL\\Setup.ini";
		string text2 = $"{VersionFolder}PCL\\Setup.ini";
		if (File.Exists(text))
		{
			ModBase.WriteIni(text, "VersionArgumentIndie", Conversions.ToString(1));
			ModBase.WriteIni(text, "VersionArgumentIndieV2", Conversions.ToString(true));
			ModBase.CopyFile(text, text2);
		}
		else
		{
			ModBase.WriteIni(text2, "VersionArgumentIndie", Conversions.ToString(1));
			ModBase.WriteIni(text2, "VersionArgumentIndieV2", Conversions.ToString(true));
		}
		ModBase.IniClearCache(text2);
	}

	private static ModLoader.LoaderCombo<string> InstallPackCurseForge(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder, string InstanceName = null, string Logo = null, string resourceId = null)
	{
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0801: Unknown result type (might be due to invalid IL or missing references)
		//IL_0807: Expected O, but got Unknown
		_Closure_0024__4_002D0 arg = default(_Closure_0024__4_002D0);
		_Closure_0024__4_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__4_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress = FileAddress;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder = ArchiveBaseFolder;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName = InstanceName;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Logo = Logo;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_resourceId = resourceId;
		try
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Json = (JObject)ModBase.GetJson(ModBase.ReadFile(Archive.GetEntry(CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "manifest.json").Open()));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("CurseForge 整合包安装信息存在问题", ex2);
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["minecraft"] == null || CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["minecraft"]["version"] == null)
		{
			throw new System.Exception("CurseForge 整合包未提供 Minecraft 版本信息");
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName == null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName = (string?)(CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["name"] ?? ((JToken)""));
			ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.PathMcFolder + "versions");
			if (Operators.CompareString(validateFolderName.ValidateText(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName), "", false) != 0)
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName = "";
			}
			if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName, "", false) == 0)
			{
				_Closure_0024__4_002D0 closure_0024__4_002D = CS_0024_003C_003E8__locals0;
				Collection<Validate> obj = new Collection<Validate>();
				obj.Add((Validate)validateFolderName);
				closure_0024__4_002D._0024VB_0024Local_InstanceName = ModMain.MyMsgBoxInput("输入实例名称", "", "", obj);
			}
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName))
			{
				throw new ModBase.CancelledException();
			}
		}
		string forgeVersion = null;
		string neoForgeVersion = null;
		string fabricVersion = null;
		string quiltVersion = null;
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator = ((System.Collections.Generic.IEnumerable<JToken>)(CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["minecraft"]["modLoaders"] ?? ((JToken)new byte[0]))).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				string text = (enumerator.Current["id"] ?? ((JToken)"")).ToString().ToLower();
				if (ModBase.StartsWithF(text, "forge-"))
				{
					if (text.Contains("recommended"))
					{
						throw new System.Exception("该整合包版本过老，已不支持进行安装！");
					}
					ModBase.Log("[ModPack] 整合包 Forge 版本：" + text);
					forgeVersion = text.Replace("forge-", "");
					continue;
				}
				if (ModBase.StartsWithF(text, "neoforge-"))
				{
					ModBase.Log("[ModPack] 整合包 NeoForge 版本：" + text);
					neoForgeVersion = text.Replace("neoforge-", "");
					continue;
				}
				if (ModBase.StartsWithF(text, "fabric-"))
				{
					try
					{
						ModBase.Log("[ModPack] 整合包 Fabric 版本：" + text);
						fabricVersion = text.Replace("fabric-", "");
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						ModBase.Log(ex4, "读取整合包 Fabric 版本失败：" + text);
						ProjectData.ClearProjectError();
						continue;
					}
					break;
				}
				if (!ModBase.StartsWithF(text, "quilt-"))
				{
					continue;
				}
				try
				{
					ModBase.Log("[ModPack] 整合包 Quilt 版本：" + text);
					quiltVersion = text.Replace("quilt-", "");
				}
				catch (System.Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					System.Exception ex6 = ex5;
					ModBase.Log(ex6, "读取整合包 Quilt 版本失败：" + text);
					ProjectData.ClearProjectError();
					continue;
				}
				break;
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp = ModMain.RequestTaskTempFolder();
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		CS_0024_003C_003E8__locals0._0024VB_0024Local_OverrideHome = (string?)(CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["overrides"] ?? ((JToken)""));
		if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_OverrideHome, "", false) != 0)
		{
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, int>("解压整合包文件", [SpecialName] (ModLoader.LoaderTask<string, int> Task) =>
			{
				ExtractModpackFiles(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp, CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress, Task, 0.6);
				CopyOverrideDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp + CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + ((Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_OverrideHome, ".", false) == 0 || Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_OverrideHome, "./", false) == 0) ? "" : CS_0024_003C_003E8__locals0._0024VB_0024Local_OverrideHome), $"{ModMinecraft.PathMcFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName}", Task, 0.4);
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = (double)new FileInfo(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress).Length / 1024.0 / 1024.0 / 6.0,
				Block = false
			});
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ModList = new List<int>();
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ModOptionalList = new List<int>();
		System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)(CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["files"] ?? ((JToken)new byte[0]))).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator2).MoveNext())
			{
				JToken current = enumerator2.Current;
				if (current["projectID"] == null || current["fileID"] == null)
				{
					ModMain.Hint("某项 Mod 缺少必要信息，已跳过：" + current.ToString());
					continue;
				}
				CS_0024_003C_003E8__locals0._0024VB_0024Local_ModList.Add((int)current["fileID"]);
				if (current["required"] != null && !current["required"].ToObject<bool>())
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_ModOptionalList.Add((int)current["fileID"]);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator2)?.Dispose();
		}
		checked
		{
			if (Enumerable.Any<int>((System.Collections.Generic.IEnumerable<int>)CS_0024_003C_003E8__locals0._0024VB_0024Local_ModList))
			{
				List<ModLoader.LoaderBase> val2 = new List<ModLoader.LoaderBase>();
				val2.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, JArray>("获取 Mod 下载信息", [SpecialName] (ModLoader.LoaderTask<int, JArray> Task) =>
				{
					bool flag = true;
					int num2 = 0;
					do
					{
						num2++;
						JArray jArray = (JArray)NewLateBinding.LateIndexGet(ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/mods/files", "POST", "{\"fileIds\": [" + ModBase.Join((System.Collections.IEnumerable)CS_0024_003C_003E8__locals0._0024VB_0024Local_ModList, ",") + "]}", "application/json", flag)), new object[] { "data" }, (string[])null);
						if (CS_0024_003C_003E8__locals0._0024VB_0024Local_ModList.Count <= jArray.Count)
						{
							ModBase.Log("[Modpack] 已获取到的模组数量足够，开始进行下一步");
							Task.Output = jArray;
							return;
						}
						flag = false;
						ModBase.Log($"[Modpack] 获取模组数量不达标，设置镜像源允许状态为: {flag}");
					}
					while (num2 <= 3);
					throw new System.Exception("整合包中的部分 Mod 版本已被 Mod 作者删除，所以没法继续安装了，请向整合包作者反馈该问题");
				}, null, (ThreadPriority)2)
				{
					ProgressWeight = (double)CS_0024_003C_003E8__locals0._0024VB_0024Local_ModList.Count / 10.0
				});
				val2.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<JArray, List<ModNet.NetFile>>("构造 Mod 下载信息", [SpecialName] (ModLoader.LoaderTask<JArray, List<ModNet.NetFile>> Task) =>
				{
					Dictionary<int, ModNet.NetFile> val6 = new Dictionary<int, ModNet.NetFile>();
					System.Collections.Generic.IEnumerator<JToken> enumerator3 = default(System.Collections.Generic.IEnumerator<JToken>);
					try
					{
						enumerator3 = Task.Input.GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator3).MoveNext())
						{
							JToken current2 = enumerator3.Current;
							int num = current2["id"].ToObject<int>();
							if (val6.ContainsKey(num) || (CS_0024_003C_003E8__locals0._0024VB_0024Local_ModOptionalList.Contains(num) && ModMain.MyMsgBox("是否要下载整合包中的可选文件 " + current2["displayName"].ToString() + "？", "下载可选文件", "是", "否") == 2))
							{
								continue;
							}
							string text5;
							ModComp.CompType defaultType;
							if (Enumerable.Any<JToken>((System.Collections.Generic.IEnumerable<JToken>)current2["modules"]))
							{
								List<string> val7 = Enumerable.ToList<string>(Enumerable.Select<JToken, string>((System.Collections.Generic.IEnumerable<JToken>)(JArray)current2["modules"], (Func<JToken, string>)([SpecialName] (JToken l) => l["name"].ToString())));
								if (val7.Contains("META-INF") || val7.Contains("mcmod.info"))
								{
									goto IL_012f;
								}
								if (current2 != null)
								{
									JToken? jToken = current2["FileName"];
									if (jToken != null)
									{
										string text4 = jToken.ToString();
										if (text4 != null && ModBase.EndsWithF(text4, ".jar", IgnoreCase: true))
										{
											goto IL_012f;
										}
									}
								}
								if (val7.Contains("pack.mcmeta"))
								{
									text5 = "resourcepacks";
									defaultType = ModComp.CompType.ResourcePack;
								}
								else if (val7.Contains("level.dat"))
								{
									text5 = "saves";
									defaultType = ModComp.CompType.World;
								}
								else
								{
									text5 = "shaderpacks";
									defaultType = ModComp.CompType.Shader;
								}
							}
							else
							{
								text5 = "mods";
								defaultType = ModComp.CompType.Mod;
							}
							goto IL_0185;
							IL_012f:
							text5 = "mods";
							defaultType = ModComp.CompType.Mod;
							goto IL_0185;
							IL_0185:
							ModComp.CompFile compFile = new ModComp.CompFile((JObject)current2, defaultType);
							if (compFile.Available)
							{
								val6.Add(num, compFile.ToNetFile($"{ModMinecraft.PathMcFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName}\\{text5}\\"));
								Task.Progress += 1.0 / (double)(1 + CS_0024_003C_003E8__locals0._0024VB_0024Local_ModList.Count);
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator3)?.Dispose();
					}
					Task.Output = Enumerable.ToList<ModNet.NetFile>((System.Collections.Generic.IEnumerable<ModNet.NetFile>)val6.Values);
				}, null, (ThreadPriority)2)
				{
					ProgressWeight = (double)CS_0024_003C_003E8__locals0._0024VB_0024Local_ModList.Count / 200.0,
					Show = false
				});
				val2.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 Mod", new List<ModNet.NetFile>())
				{
					ProgressWeight = (double)CS_0024_003C_003E8__locals0._0024VB_0024Local_ModList.Count * 1.5
				});
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<int>("下载 Mod（主加载器）", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2)
				{
					Show = false,
					ProgressWeight = Enumerable.Sum<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2, (Func<ModLoader.LoaderBase, double>)([SpecialName] (ModLoader.LoaderBase l) => l.ProgressWeight))
				});
			}
			ModDownloadLib.McInstallRequest mcInstallRequest = new ModDownloadLib.McInstallRequest
			{
				TargetInstanceName = CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName,
				TargetInstanceFolder = $"{ModMinecraft.PathMcFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName}\\",
				MinecraftName = CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["minecraft"]["version"].ToString(),
				ForgeVersion = forgeVersion,
				NeoForgeVersion = neoForgeVersion,
				FabricVersion = fabricVersion,
				QuiltVersion = quiltVersion
			};
			List<ModLoader.LoaderBase> val3 = ModDownloadLib.McInstallLoader(mcInstallRequest);
			List<ModLoader.LoaderBase> val4 = new List<ModLoader.LoaderBase>();
			val4.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("整合包安装", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val)
			{
				Show = false,
				Block = false,
				ProgressWeight = Enumerable.Sum<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val, (Func<ModLoader.LoaderBase, double>)([SpecialName] (ModLoader.LoaderBase l) => l.ProgressWeight))
			});
			val4.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("游戏安装", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val3)
			{
				Show = false,
				ProgressWeight = Enumerable.Sum<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val3, (Func<ModLoader.LoaderBase, double>)([SpecialName] (ModLoader.LoaderBase l) => l.ProgressWeight))
			});
			val4.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, string>("最终整理文件", [SpecialName] (ModLoader.LoaderTask<string, string> Task) =>
			{
				string text2 = $"{ModMinecraft.PathMcFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName}\\";
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Logo != null && File.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_Logo))
				{
					File.Copy(CS_0024_003C_003E8__locals0._0024VB_0024Local_Logo, text2 + "PCL\\Logo.png", true);
					Config.Instance.LogoPath[text2] = "PCL\\Logo.png";
					Config.Instance.IsLogoCustom[text2] = true;
					ModBase.Log("[ModPack] 已设置整合包 Logo：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Logo);
				}
				string[] array = new string[2]
				{
					text2 + "原始整合包.zip",
					text2 + "原始整合包.mrpack"
				};
				foreach (string text3 in array)
				{
					if (File.Exists(text3))
					{
						ModBase.Log("[ModPack] 删除原始整合包文件：" + text3);
						File.Delete(text3);
					}
				}
				if (File.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress) && Operators.CompareString(ModBase.GetFileNameWithoutExtentionFromPath(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress), "modpack", false) == 0)
				{
					ModBase.Log("[ModPack] 删除安装整合包文件：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress);
					File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress);
				}
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["version"] != null)
				{
					Config.Instance.ModpackVersion[text2] = CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["version"].ToString();
				}
				Config.Instance.ModpackSource[text2] = "CurseForge";
				Config.Instance.ModpackId[text2] = CS_0024_003C_003E8__locals0._0024VB_0024Local_resourceId;
				try
				{
					List<string> obj2 = new List<string>();
					obj2.Add(CS_0024_003C_003E8__locals0._0024VB_0024Local_resourceId);
					List<ModComp.CompProject> compProjectsByIds = ModComp.CompRequest.GetCompProjectsByIds(obj2);
					if (compProjectsByIds.Count != 0)
					{
						Config.Instance.CustomInfo[text2] = Enumerable.First<ModComp.CompProject>((System.Collections.Generic.IEnumerable<ModComp.CompProject>)compProjectsByIds).Description;
					}
				}
				catch (System.Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					System.Exception ex8 = ex7;
					ModBase.Log(ex8, "[ModPack] 获取整合包描述文本失败");
					ProjectData.ClearProjectError();
				}
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 0.1,
				Show = false
			});
			CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName = "CurseForge 整合包安装：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName + " ";
			if (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar, (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => Operators.CompareString(l.Name, CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName, false) == 0)))
			{
				ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Critical);
				throw new ModBase.CancelledException();
			}
			ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val4);
			loaderCombo.OnStateChanged = ModDownloadLib.McInstallState;
			loaderCombo.Start(mcInstallRequest.TargetInstanceFolder);
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			object action;
			if (_Closure_0024__._0024I4_002D9 != null)
			{
				action = _Closure_0024__._0024I4_002D9;
			}
			else
			{
				Action val5 = [SpecialName] () =>
				{
					ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
				};
				_Closure_0024__._0024I4_002D9 = val5;
				action = (object)val5;
			}
			ModBase.RunInUi((Action)action);
			return loaderCombo;
		}
	}

	private static ModLoader.LoaderCombo<string> InstallPackModrinth(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder, string InstanceName = null, string Logo = null, string resourceId = null)
	{
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bd: Expected O, but got Unknown
		_Closure_0024__5_002D0 arg = default(_Closure_0024__5_002D0);
		_Closure_0024__5_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__5_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress = FileAddress;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder = ArchiveBaseFolder;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName = InstanceName;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Logo = Logo;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_resourceId = resourceId;
		try
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Json = (JObject)ModBase.GetJson(ModBase.ReadFile(Archive.GetEntry(CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "modrinth.index.json").Open()));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("Modrinth 整合包安装信息存在问题", ex2);
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["dependencies"] == null || CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["dependencies"]["minecraft"] == null)
		{
			throw new System.Exception("Modrinth 整合包未提供 Minecraft 版本信息");
		}
		string minecraftName = null;
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator = ((System.Collections.Generic.IEnumerable<JToken>)(CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["dependencies"] ?? ((JToken)new byte[0]))).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				JProperty jProperty = (JProperty)enumerator.Current;
				switch (jProperty.Name.ToLower())
				{
				case "minecraft":
					minecraftName = jProperty.Value.ToString();
					break;
				case "forge":
					text = jProperty.Value.ToString();
					ModBase.Log("[ModPack] 整合包 Forge 版本：" + text);
					break;
				case "neoforge":
				case "neo-forge":
					text2 = jProperty.Value.ToString();
					ModBase.Log("[ModPack] 整合包 NeoForge 版本：" + text2);
					break;
				case "fabric-loader":
					text3 = jProperty.Value.ToString();
					ModBase.Log("[ModPack] 整合包 Fabric 版本：" + text3);
					break;
				case "quilt-loader":
					text4 = jProperty.Value.ToString();
					ModBase.Log("[ModPack] 整合包 Quilt 版本：" + text4);
					break;
				default:
					ModMain.Hint($"无法安装整合包，其中出现了未知的 Mod 加载器 {jProperty.Name}（版本为 {jProperty.Value.ToString()}）！", ModMain.HintType.Critical);
					break;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName == null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName = (string?)(CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["name"] ?? ((JToken)""));
			ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.PathMcFolder + "versions");
			if (Operators.CompareString(validateFolderName.ValidateText(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName), "", false) != 0)
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName = "";
			}
			if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName, "", false) == 0)
			{
				_Closure_0024__5_002D0 closure_0024__5_002D = CS_0024_003C_003E8__locals0;
				Collection<Validate> obj = new Collection<Validate>();
				obj.Add((Validate)validateFolderName);
				closure_0024__5_002D._0024VB_0024Local_InstanceName = ModMain.MyMsgBoxInput("输入实例名称", "", "", obj);
			}
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName))
			{
				throw new ModBase.CancelledException();
			}
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp = ModMain.RequestTaskTempFolder();
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, int>("解压整合包文件", [SpecialName] (ModLoader.LoaderTask<string, int> Task) =>
		{
			ExtractModpackFiles(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp, CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress, Task, 0.5);
			CopyOverrideDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp + CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "overrides", ModMinecraft.PathMcFolder + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName, Task, 0.4);
			CopyOverrideDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp + CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "client-overrides", ModMinecraft.PathMcFolder + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName, Task, 0.1);
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = (double)new FileInfo(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress).Length / 1024.0 / 1024.0 / 6.0,
			Block = false
		});
		List<ModNet.NetFile> val2 = new List<ModNet.NetFile>();
		System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)(CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["files"] ?? ((JToken)new byte[0]))).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator2).MoveNext())
			{
				JToken current = enumerator2.Current;
				if (current["env"] != null)
				{
					string text5 = current["env"]["client"].ToString();
					if (Operators.CompareString(text5, "optional", false) != 0)
					{
						if (Operators.CompareString(text5, "unsupported", false) == 0)
						{
							continue;
						}
					}
					else if (ModMain.MyMsgBox("是否要下载可选文件 " + ModBase.GetFileNameFromPath(current["path"].ToString()) + "？", "下载可选文件", "是", "否") == 2)
					{
						continue;
					}
				}
				List<string> val3 = Enumerable.ToList<string>(Enumerable.Select<JToken, string>((System.Collections.Generic.IEnumerable<JToken>)current["downloads"], (Func<JToken, string>)([SpecialName] (JToken x) => ModComp.CompFile.HandleCurseForgeDownloadUrls(x.ToString()))));
				val3 = Enumerable.ToList<string>(Enumerable.SelectMany<string, string>((System.Collections.Generic.IEnumerable<string>)val3, (Func<string, System.Collections.Generic.IEnumerable<string>>)([SpecialName] (string x) => (System.Collections.Generic.IEnumerable<string>)ModDownload.DlSourceModDownloadGet(x))));
				string text6 = string.Format("{0}versions\\{1}\\{2}", (object)ModMinecraft.PathMcFolder, (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName, (object)current["path"]);
				if (!ModBase.StartsWithF(Path.GetFullPath(text6), $"{ModMinecraft.PathMcFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName}\\", IgnoreCase: true))
				{
					ModMain.MyMsgBox("整合包的文件路径超出了实例文件夹，请向整合包作者反馈此问题！\r\n错误的文件：" + text6, "文件路径校验失败", "确定", "", "", IsWarn: true);
					throw new ModBase.CancelledException();
				}
				val2.Add(new ModNet.NetFile((System.Collections.Generic.IEnumerable<string>)val3, text6, new ModBase.FileChecker(-1L, current["fileSize"].ToObject<long>(), current["hashes"]["sha1"].ToString()), UseBrowserUserAgent: true));
			}
		}
		finally
		{
			((System.IDisposable)enumerator2)?.Dispose();
		}
		if (Enumerable.Any<ModNet.NetFile>((System.Collections.Generic.IEnumerable<ModNet.NetFile>)val2))
		{
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载额外文件", val2)
			{
				ProgressWeight = (double)val2.Count * 1.5
			});
		}
		ModDownloadLib.McInstallRequest mcInstallRequest = new ModDownloadLib.McInstallRequest
		{
			TargetInstanceName = CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName,
			TargetInstanceFolder = $"{ModMinecraft.PathMcFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName}\\",
			MinecraftName = minecraftName,
			ForgeVersion = text,
			NeoForgeVersion = text2,
			FabricVersion = text3,
			QuiltVersion = text4
		};
		List<ModLoader.LoaderBase> val4 = ModDownloadLib.McInstallLoader(mcInstallRequest);
		List<ModLoader.LoaderBase> val5 = new List<ModLoader.LoaderBase>();
		val5.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("整合包安装", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val)
		{
			Show = false,
			Block = false,
			ProgressWeight = Enumerable.Sum<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val, (Func<ModLoader.LoaderBase, double>)([SpecialName] (ModLoader.LoaderBase l) => l.ProgressWeight))
		});
		val5.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("游戏安装", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val4)
		{
			Show = false,
			ProgressWeight = Enumerable.Sum<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val4, (Func<ModLoader.LoaderBase, double>)([SpecialName] (ModLoader.LoaderBase l) => l.ProgressWeight))
		});
		val5.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, string>("最终整理文件", [SpecialName] (ModLoader.LoaderTask<string, string> Task) =>
		{
			string text7 = $"{ModMinecraft.PathMcFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName}\\";
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Logo != null && File.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_Logo))
			{
				File.Copy(CS_0024_003C_003E8__locals0._0024VB_0024Local_Logo, text7 + "PCL\\Logo.png", true);
				Config.Instance.LogoPath[text7] = "PCL\\Logo.png";
				Config.Instance.IsLogoCustom[text7] = true;
				ModBase.Log("[ModPack] 已设置整合包 Logo：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Logo);
			}
			string[] array = new string[2]
			{
				text7 + "原始整合包.zip",
				text7 + "原始整合包.mrpack"
			};
			foreach (string text8 in array)
			{
				if (File.Exists(text8))
				{
					ModBase.Log("[ModPack] 删除原始整合包文件：" + text8);
					File.Delete(text8);
				}
			}
			if (File.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress) && Operators.CompareString(ModBase.GetFileNameWithoutExtentionFromPath(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress), "modpack", false) == 0)
			{
				ModBase.Log("[ModPack] 删除安装整合包文件：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress);
				File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress);
			}
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["versionId"] != null)
			{
				Config.Instance.ModpackVersion[text7] = CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["versionId"].ToString();
			}
			Config.Instance.ModpackSource[text7] = "Modrinth";
			Config.Instance.ModpackId[text7] = CS_0024_003C_003E8__locals0._0024VB_0024Local_resourceId;
			try
			{
				List<string> obj2 = new List<string>();
				obj2.Add(CS_0024_003C_003E8__locals0._0024VB_0024Local_resourceId);
				List<ModComp.CompProject> compProjectsByIds = ModComp.CompRequest.GetCompProjectsByIds(obj2);
				if (compProjectsByIds.Count != 0)
				{
					Config.Instance.CustomInfo[text7] = Enumerable.First<ModComp.CompProject>((System.Collections.Generic.IEnumerable<ModComp.CompProject>)compProjectsByIds).Description;
				}
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "[ModPack] 获取整合包描述文本失败");
				ProjectData.ClearProjectError();
			}
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = 0.1,
			Show = false
		});
		CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName = $"Modrinth 整合包安装：{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName} ";
		if (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar, (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => Operators.CompareString(l.Name, CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName, false) == 0)))
		{
			ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Critical);
			throw new ModBase.CancelledException();
		}
		ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val5);
		loaderCombo.OnStateChanged = ModDownloadLib.McInstallState;
		loaderCombo.Start(mcInstallRequest.TargetInstanceFolder);
		ModLoader.LoaderTaskbarAdd(loaderCombo);
		ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
		object action;
		if (_Closure_0024__._0024I5_002D7 != null)
		{
			action = _Closure_0024__._0024I5_002D7;
		}
		else
		{
			Action val6 = [SpecialName] () =>
			{
				ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
			};
			_Closure_0024__._0024I5_002D7 = val6;
			action = (object)val6;
		}
		ModBase.RunInUi((Action)action);
		return loaderCombo;
	}

	private static ModLoader.LoaderCombo<string> InstallPackHMCL(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder)
	{
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected O, but got Unknown
		JObject jObject;
		try
		{
			jObject = (JObject)ModBase.GetJson(ModBase.ReadFile(Archive.GetEntry(ArchiveBaseFolder + "modpack.json").Open(), Encoding.UTF8));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("HMCL 整合包安装信息存在问题", ex2);
		}
		string text = (string?)(jObject["name"] ?? ((JToken)""));
		ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.PathMcFolder + "versions");
		if (Operators.CompareString(validateFolderName.ValidateText(text), "", false) != 0)
		{
			text = "";
		}
		if (Operators.CompareString(text, "", false) == 0)
		{
			Collection<Validate> obj = new Collection<Validate>();
			obj.Add((Validate)validateFolderName);
			text = ModMain.MyMsgBoxInput("输入实例名称", "", "", obj);
		}
		if (string.IsNullOrEmpty(text))
		{
			throw new ModBase.CancelledException();
		}
		string text2 = ModMain.RequestTaskTempFolder();
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, int>("解压整合包文件", [SpecialName] (ModLoader.LoaderTask<string, int> Task) =>
		{
			ExtractModpackFiles(text2, FileAddress, Task, 0.6);
			CopyOverrideDirectory(text2 + ArchiveBaseFolder + "minecraft", ModMinecraft.PathMcFolder + "versions\\" + text, Task, 0.4);
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = (double)new FileInfo(FileAddress).Length / 1024.0 / 1024.0 / 6.0,
			Block = false
		});
		if (jObject["gameVersion"] == null)
		{
			throw new System.Exception("该 HMCL 整合包未提供游戏版本信息，无法安装！");
		}
		ModDownloadLib.McInstallRequest mcInstallRequest = new ModDownloadLib.McInstallRequest
		{
			TargetInstanceName = text,
			TargetInstanceFolder = $"{ModMinecraft.PathMcFolder}versions\\{text}\\",
			MinecraftName = jObject["gameVersion"].ToString()
		};
		List<ModLoader.LoaderBase> val2 = ModDownloadLib.McInstallLoader(mcInstallRequest);
		List<ModLoader.LoaderBase> obj2 = new List<ModLoader.LoaderBase>();
		obj2.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("整合包安装", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val)
		{
			Show = false,
			Block = false,
			ProgressWeight = Enumerable.Sum<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val, (Func<ModLoader.LoaderBase, double>)([SpecialName] (ModLoader.LoaderBase l) => l.ProgressWeight))
		});
		obj2.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("游戏安装", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2)
		{
			Show = false,
			ProgressWeight = Enumerable.Sum<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2, (Func<ModLoader.LoaderBase, double>)([SpecialName] (ModLoader.LoaderBase l) => l.ProgressWeight))
		});
		List<ModLoader.LoaderBase> loaders = obj2;
		string text3 = "HMCL 整合包安装：" + text + " ";
		if (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar, (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => Operators.CompareString(l.Name, text3, false) == 0)))
		{
			ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Critical);
			throw new ModBase.CancelledException();
		}
		ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(text3, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)loaders);
		loaderCombo.OnStateChanged = ModDownloadLib.McInstallState;
		loaderCombo.Start(mcInstallRequest.TargetInstanceFolder);
		ModLoader.LoaderTaskbarAdd(loaderCombo);
		ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
		object action;
		if (_Closure_0024__._0024I6_002D4 != null)
		{
			action = _Closure_0024__._0024I6_002D4;
		}
		else
		{
			Action val3 = [SpecialName] () =>
			{
				ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
			};
			_Closure_0024__._0024I6_002D4 = val3;
			action = (object)val3;
		}
		ModBase.RunInUi((Action)action);
		return loaderCombo;
	}

	private static ModLoader.LoaderCombo<string> InstallPackMMC(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder)
	{
		//IL_0a6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de2: Expected O, but got Unknown
		_Closure_0024__8_002D0 arg = default(_Closure_0024__8_002D0);
		_Closure_0024__8_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__8_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress = FileAddress;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder = ArchiveBaseFolder;
		MMCPackInfo mMCPackInfo = null;
		JObject jObject;
		string str;
		try
		{
			jObject = (JObject)ModBase.GetJson(ModBase.ReadFile(Archive.GetEntry(CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "mmc-pack.json").Open(), Encoding.UTF8));
			str = ModBase.ReadFile(Archive.GetEntry(CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "instance.cfg").Open(), Encoding.UTF8);
			try
			{
				if (Enumerable.Any<ZipArchiveEntry>((System.Collections.Generic.IEnumerable<ZipArchiveEntry>)Archive.Entries, (Func<ZipArchiveEntry, bool>)([SpecialName] (ZipArchiveEntry e) => e.FullName.Equals(CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "patches/", (StringComparison)5))))
				{
					ModBase.Log("[ModPack] 安装的 MultiMC 整合包存在 JSON Patches");
					List<KeyValuePair<JObject, int>> val = new List<KeyValuePair<JObject, int>>();
					System.Collections.Generic.IEnumerator<ZipArchiveEntry> enumerator = default(System.Collections.Generic.IEnumerator<ZipArchiveEntry>);
					try
					{
						enumerator = Archive.Entries.GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator).MoveNext())
						{
							ZipArchiveEntry current = enumerator.Current;
							if (!current.FullName.EndsWith("/") && current.FullName.StartsWith(CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "patches/"))
							{
								JObject jObject2 = (JObject)ModBase.GetJson(ModBase.ReadFile(Archive.GetEntry(CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "patches/" + current.Name).Open(), Encoding.UTF8));
								val.Add(new KeyValuePair<JObject, int>(jObject2, (int)((jObject2["order"] != null) ? jObject2["order"] : ((JToken)0))));
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator)?.Dispose();
					}
					JArray jArray = (JArray)jObject["components"];
					System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<JObject, int>> enumerator2 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<JObject, int>>);
					try
					{
						enumerator2 = val.GetEnumerator();
						System.Collections.Generic.IEnumerator<JToken> enumerator3 = default(System.Collections.Generic.IEnumerator<JToken>);
						while (enumerator2.MoveNext())
						{
							KeyValuePair<JObject, int> current2 = enumerator2.Current;
							bool flag = false;
							try
							{
								enumerator3 = jArray.GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator3).MoveNext())
								{
									if (Operators.CompareString(enumerator3.Current["uid"].ToString(), current2.Key["uid"].ToString(), false) == 0)
									{
										flag = true;
										break;
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator3)?.Dispose();
							}
							if (!flag)
							{
								ModBase.Log(string.Format("[ModPack] JSON-Patch {0} 未包含于 mmc-pack.json, 跳过该 Patch", (object)current2.Key["uid"]));
								val.Remove(current2);
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator2).Dispose();
					}
					val.Sort((Comparison<KeyValuePair<JObject, int>>)([SpecialName] (KeyValuePair<JObject, int> x, KeyValuePair<JObject, int> y) => x.Value.CompareTo(y.Value)));
					mMCPackInfo = new MMCPackInfo();
					string text = null;
					JObject jObject3 = null;
					JObject jObject4 = null;
					string text2 = null;
					JArray jArray2 = new JArray();
					JArray jArray3 = new JArray();
					JArray jArray4 = new JArray();
					new JArray();
					System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<JObject, int>> enumerator4 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<JObject, int>>);
					try
					{
						enumerator4 = val.GetEnumerator();
						System.Collections.Generic.IEnumerator<JToken> enumerator5 = default(System.Collections.Generic.IEnumerator<JToken>);
						System.Collections.Generic.IEnumerator<JToken> enumerator6 = default(System.Collections.Generic.IEnumerator<JToken>);
						System.Collections.Generic.IEnumerator<JToken> enumerator7 = default(System.Collections.Generic.IEnumerator<JToken>);
						while (enumerator4.MoveNext())
						{
							JObject key = enumerator4.Current.Key;
							if ((string?)key["uid"] == "net.minecraft")
							{
								mMCPackInfo.IsMinecraftOverrided = true;
							}
							else if ((string?)key["uid"] == "net.minecraftforge")
							{
								if (ModBase.StartsWithF(key["version"].ToString(), "0."))
								{
									mMCPackInfo.IsCleanroomOverrided = true;
								}
								else
								{
									mMCPackInfo.IsForgeOverrided = true;
								}
							}
							else if ((string?)key["uid"] == "net.neoforged")
							{
								mMCPackInfo.IsNeoForgeOverrided = true;
							}
							else if ((string?)key["uid"] == "net.fabricmc.fabric-loader")
							{
								mMCPackInfo.IsFabricOverrided = true;
							}
							else if ((string?)key["uid"] == "org.quiltmc.quilt-loader")
							{
								mMCPackInfo.IsQuiltOverrided = true;
							}
							if (key["+jvmArgs"] != null)
							{
								jArray3.Merge(key["+jvmArgs"]);
								ModBase.Log(string.Format("[ModPack] 已应用 JSON-Patch {0} 的 JVM 参数", (object)key["uid"]));
							}
							if (key["libraries"] != null || key["+libraries"] != null)
							{
								JArray jArray5 = new JArray();
								if (key["libraries"] != null)
								{
									try
									{
										enumerator5 = ((System.Collections.Generic.IEnumerable<JToken>)key["libraries"]).GetEnumerator();
										while (((System.Collections.IEnumerator)enumerator5).MoveNext())
										{
											JObject jObject5 = (JObject)enumerator5.Current;
											if (jObject5["MMC-hint"] != null)
											{
												jObject5.Add("hint", jObject5["MMC-hint"]);
												jObject5.Remove("MMC-hint");
											}
											jArray5.Add(jObject5);
										}
									}
									finally
									{
										((System.IDisposable)enumerator5)?.Dispose();
									}
								}
								if (key["+libraries"] != null)
								{
									try
									{
										enumerator6 = ((System.Collections.Generic.IEnumerable<JToken>)key["+libraries"]).GetEnumerator();
										while (((System.Collections.IEnumerator)enumerator6).MoveNext())
										{
											JObject jObject6 = (JObject)enumerator6.Current;
											if (jObject6["MMC-hint"] != null)
											{
												jObject6.Add("hint", jObject6["MMC-hint"]);
												jObject6.Remove("MMC-hint");
											}
											jArray5.Add(jObject6);
										}
									}
									finally
									{
										((System.IDisposable)enumerator6)?.Dispose();
									}
								}
								jArray4.Merge(jArray5);
								ModBase.Log(string.Format("[ModPack] 已应用 JSON-Patch {0} 的 Libraries", (object)key["uid"]));
							}
							if (key["+tweakers"] != null)
							{
								text = (string?)key["+tweakers"][0];
								ModBase.Log(string.Format("[ModPack] 已应用 JSON-Patch {0} 的 Tweakers", (object)key["uid"]));
							}
							if (key["assetIndex"] != null)
							{
								jObject3 = (JObject)key["assetIndex"];
								ModBase.Log(string.Format("[ModPack] 已应用 JSON-Patch {0} 的 AssetIndex", (object)key["uid"]));
							}
							if (key["minecraftArguments"] != null)
							{
								string[] array = key["minecraftArguments"].ToString().Split(" ", (StringSplitOptions)0);
								foreach (string text3 in array)
								{
									jArray2.Add(text3);
								}
								mMCPackInfo.IsMcArgsEdited = true;
								ModBase.Log(string.Format("[ModPack] 已应用 JSON-Patch {0} 的 minecraftArguments 至 arguments.game", (object)key["uid"]));
							}
							if (key["mainClass"] != null)
							{
								text2 = (string?)key["mainClass"];
								ModBase.Log(string.Format("[ModPack] 已应用 JSON-Patch {0} 的 mainClass", (object)key["uid"]));
							}
							if (key["compatibleJavaMajors"] == null)
							{
								continue;
							}
							int num = 0;
							string text4 = null;
							JArray jArray6 = (JArray)key["compatibleJavaMajors"];
							try
							{
								enumerator7 = jArray6.GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator7).MoveNext())
								{
									JToken current3 = enumerator7.Current;
									if (!((double)num > ModBase.Val(current3)))
									{
										if (ModBase.Val(current3) == 21.0)
										{
											num = 21;
											text4 = "java-runtime-delta";
										}
										else if (ModBase.Val(current3) == 17.0)
										{
											num = 17;
											text4 = "java-runtime-gamma";
										}
										else if (ModBase.Val(current3) == 11.0)
										{
											num = 11;
											text4 = null;
										}
										else if (ModBase.Val(current3) == 8.0)
										{
											num = 8;
											text4 = "jre-legacy";
										}
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator7)?.Dispose();
							}
							if (num == 0)
							{
								num = (int)jArray6[0];
								text4 = null;
							}
							jObject4 = new JObject { { "majorVersion", num } };
							if (text4 != null)
							{
								jObject4.Add("component", text4);
							}
							ModBase.Log(string.Format("[ModPack] JSON-Patch {0} 要求 Java 版本: ", (object)key["uid"]) + Conversions.ToString(num));
						}
					}
					finally
					{
						((System.IDisposable)enumerator4).Dispose();
					}
					JObject jObject7 = null;
					if (!string.IsNullOrWhiteSpace(text))
					{
						jArray2.Add("--tweakClass");
						jArray2.Add(text);
					}
					if (jArray2 != null || jArray3 != null)
					{
						jArray3.Insert(0, "-Djava.library.path=${natives_directory}");
						jArray3.Insert(1, "-Dminecraft.launcher.brand=${launcher_name}");
						jArray3.Insert(2, "-Dminecraft.launcher.version=${launcher_version}");
						jArray3.Insert(3, "-cp");
						jArray3.Insert(4, "${classpath}");
						jObject7 = new JObject
						{
							{ "game", jArray2 },
							{ "jvm", jArray3 }
						};
					}
					mMCPackInfo.OverridedJson = new JObject();
					if (jObject7 != null)
					{
						mMCPackInfo.OverridedJson.Add("arguments", jObject7);
					}
					if (text2 != null)
					{
						mMCPackInfo.OverridedJson.Add("mainClass", text2);
					}
					if (jObject3 != null)
					{
						mMCPackInfo.OverridedJson.Add("assetIndex", jObject3);
					}
					if (jObject4 != null)
					{
						mMCPackInfo.OverridedJson.Add("javaVersion", jObject4);
					}
					if (jArray4 != null)
					{
						mMCPackInfo.OverridedJson.Add("libraries", jArray4);
					}
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "应用 MMC JSON-Patches 失败");
				ProjectData.ClearProjectError();
			}
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			throw new System.Exception("MMC 整合包安装信息存在问题", ex4);
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName = ModBase.RegexSeek(str, "(?<=\\nname\\=)[^\\n]+", (RegexOptions)0) ?? "";
		ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.PathMcFolder + "versions");
		if (Operators.CompareString(validateFolderName.ValidateText(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName), "", false) != 0)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName = "";
		}
		if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName, "", false) == 0)
		{
			_Closure_0024__8_002D0 closure_0024__8_002D = CS_0024_003C_003E8__locals0;
			Collection<Validate> obj = new Collection<Validate>();
			obj.Add((Validate)validateFolderName);
			closure_0024__8_002D._0024VB_0024Local_InstanceName = ModMain.MyMsgBoxInput("输入实例名称", "", "", obj);
		}
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName))
		{
			throw new ModBase.CancelledException();
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp = ModMain.RequestTaskTempFolder();
		CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder = $"{ModMinecraft.PathMcFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName}";
		List<ModLoader.LoaderBase> val2 = new List<ModLoader.LoaderBase>();
		val2.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, int>("解压整合包文件", [SpecialName] (ModLoader.LoaderTask<string, int> Task) =>
		{
			ExtractModpackFiles(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp, CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress, Task, 0.55);
			CopyOverrideDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp + CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "libraries", ModMinecraft.PathMcFolder + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName + "\\libraries", Task, 0.2);
			CopyOverrideDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp + CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + ".minecraft", ModMinecraft.PathMcFolder + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName, Task, 0.2);
			try
			{
				string text5 = CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp + CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "instance.cfg";
				if (File.Exists(text5))
				{
					List<string> val6 = new List<string>();
					string[] array2 = ModBase.ReadFile(text5).Split(new string[] { "\r", "\n" }, (StringSplitOptions)1);
					foreach (string text6 in array2)
					{
						if (text6.Contains("="))
						{
							val6.Add(ModBase.BeforeFirst(text6, "=") + ":" + ModBase.AfterFirst(text6, "="));
						}
					}
					ModBase.WriteFile(text5, ModBase.Join((System.Collections.IEnumerable)val6, "\r\n"));
					if (Conversions.ToBoolean(ModBase.ReadIni(text5, "OverrideCommands", Conversions.ToString(false))))
					{
						string text7 = ModBase.ReadIni(text5, "PreLaunchCommand");
						if (Operators.CompareString(text7, "", false) != 0)
						{
							text7 = text7.Replace("\\\"", "\"").Replace("$INST_JAVA", "{java}javaw.exe").Replace("$INST_MC_DIR\\", "{minecraft}")
								.Replace("$INST_MC_DIR", "{minecraft}")
								.Replace("$INST_DIR\\", "{verpath}")
								.Replace("$INST_DIR", "{verpath}")
								.Replace("$INST_ID", "{name}")
								.Replace("$INST_NAME", "{name}");
							Config.Instance.PreLaunchCommand[CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder] = text7;
							ModBase.Log("[ModPack] 迁移 MultiMC 实例独立设置：启动前执行命令：" + text7);
						}
					}
					if (Conversions.ToBoolean(ModBase.ReadIni(text5, "JoinServerOnLaunch", Conversions.ToString(false))))
					{
						string text8 = ModBase.ReadIni(text5, "JoinServerOnLaunchAddress").Replace("\\\"", "\"");
						Config.Instance.ServerToEnter[CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder] = text8;
						ModBase.Log("[ModPack] 迁移 MultiMC 实例独立设置：自动进入服务器：" + text8);
					}
					if (Conversions.ToBoolean(ModBase.ReadIni(text5, "IgnoreJavaCompatibility", Conversions.ToString(false))))
					{
						Config.Instance.IgnoreJavaCompatibility[CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder] = true;
						ModBase.Log("[ModPack] 迁移 MultiMC 实例独立设置：忽略 Java 兼容性警告");
					}
					string text9 = ModBase.ReadIni(text5, "iconKey");
					if (Operators.CompareString(text9, "", false) != 0 && File.Exists($"{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp}{CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder}{text9}.png"))
					{
						Config.Instance.IsLogoCustom[CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder] = true;
						Config.Instance.LogoPath[CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder] = "PCL\\Logo.png";
						ModBase.CopyFile($"{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp}{CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder}{text9}.png", $"{ModMinecraft.PathMcFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName}\\PCL\\Logo.png");
						ModBase.Log($"[ModPack] 迁移 MultiMC 实例独立设置：实例图标（{text9}.png）");
					}
					string text10 = ModBase.ReadIni(text5, "JvmArgs");
					if (Operators.CompareString(text10, "", false) != 0)
					{
						if (Conversions.ToBoolean(ModBase.ReadIni(text5, "OverrideJavaArgs", Conversions.ToString(false))))
						{
							Config.Instance.JvmArgs[CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder] = text10;
							ModBase.Log("[ModPack] 迁移 MultiMC 实例独立设置：JVM 参数（覆盖）：" + text10);
						}
						else
						{
							text10 = Conversions.ToString(Operators.AddObject((object)text10, Operators.ConcatenateObject((object)" ", ModBase.Setup.Get("LaunchAdvanceJvm"))));
							Config.Instance.JvmArgs[CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder] = text10;
							ModBase.Log("[ModPack] 迁移 MultiMC 实例独立设置：JVM 参数（追加）：" + text10);
						}
					}
				}
			}
			catch (System.Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				System.Exception ex6 = ex5;
				ModBase.Log(ex6, $"读取 MMC 配置文件失败（{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp}{CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder}instance.cfg）");
				ProjectData.ClearProjectError();
			}
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = (double)new FileInfo(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress).Length / 1024.0 / 1024.0 / 6.0,
			Block = false
		});
		if (jObject["components"] == null)
		{
			throw new System.Exception("该 MMC 整合包未提供游戏版本信息，无法安装！");
		}
		ModDownloadLib.McInstallRequest mcInstallRequest = new ModDownloadLib.McInstallRequest
		{
			TargetInstanceName = CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName,
			TargetInstanceFolder = $"{ModMinecraft.PathMcFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName}\\"
		};
		System.Collections.Generic.IEnumerator<JToken> enumerator8 = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator8 = ((System.Collections.Generic.IEnumerable<JToken>)jObject["components"]).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator8).MoveNext())
			{
				JToken current4 = enumerator8.Current;
				switch ((current4["uid"] ?? ((JToken)"")).ToString())
				{
				case "org.lwjgl":
					ModBase.Log("[ModPack] 已跳过 LWJGL 项");
					break;
				case "net.minecraft":
					mcInstallRequest.MinecraftName = (string?)current4["version"];
					break;
				case "net.minecraftforge":
					if (ModBase.StartsWithF(current4["version"].ToString(), "0."))
					{
						mcInstallRequest.CleanroomVersion = (string?)current4["version"];
					}
					else
					{
						mcInstallRequest.ForgeVersion = (string?)current4["version"];
					}
					break;
				case "net.neoforged":
					mcInstallRequest.NeoForgeVersion = (string?)current4["version"];
					break;
				case "net.fabricmc.fabric-loader":
					mcInstallRequest.FabricVersion = (string?)current4["version"];
					break;
				case "org.quiltmc.quilt-loader":
					mcInstallRequest.QuiltVersion = (string?)current4["version"];
					break;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator8)?.Dispose();
		}
		if (mMCPackInfo != null)
		{
			mcInstallRequest.MMCPackInfo = mMCPackInfo;
		}
		List<ModLoader.LoaderBase> val3 = ModDownloadLib.McInstallLoader(mcInstallRequest);
		List<ModLoader.LoaderBase> val4 = new List<ModLoader.LoaderBase>();
		val4.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("整合包安装", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2)
		{
			Show = false,
			Block = false,
			ProgressWeight = Enumerable.Sum<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2, (Func<ModLoader.LoaderBase, double>)([SpecialName] (ModLoader.LoaderBase l) => l.ProgressWeight))
		});
		val4.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("游戏安装", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val3)
		{
			Show = false,
			ProgressWeight = Enumerable.Sum<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val3, (Func<ModLoader.LoaderBase, double>)([SpecialName] (ModLoader.LoaderBase l) => l.ProgressWeight))
		});
		CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName = "MMC 整合包安装：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName + " ";
		if (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar, (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => Operators.CompareString(l.Name, CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName, false) == 0)))
		{
			ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Critical);
			throw new ModBase.CancelledException();
		}
		ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val4);
		loaderCombo.OnStateChanged = ModDownloadLib.McInstallState;
		loaderCombo.Start(mcInstallRequest.TargetInstanceFolder);
		ModLoader.LoaderTaskbarAdd(loaderCombo);
		ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
		object action;
		if (_Closure_0024__._0024I8_002D6 != null)
		{
			action = _Closure_0024__._0024I8_002D6;
		}
		else
		{
			Action val5 = [SpecialName] () =>
			{
				ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
			};
			_Closure_0024__._0024I8_002D6 = val5;
			action = (object)val5;
		}
		ModBase.RunInUi((Action)action);
		return loaderCombo;
	}

	private static ModLoader.LoaderCombo<string> InstallPackMCBBS(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder, string InstanceName = null)
	{
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Expected O, but got Unknown
		_Closure_0024__9_002D0 arg = default(_Closure_0024__9_002D0);
		_Closure_0024__9_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__9_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress = FileAddress;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder = ArchiveBaseFolder;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName = InstanceName;
		try
		{
			ZipArchiveEntry val = Archive.GetEntry(CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "mcbbs.packmeta") ?? Archive.GetEntry(CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "manifest.json");
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Json = (JObject)ModBase.GetJson(ModBase.ReadFile(val.Open(), Encoding.UTF8));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("MCBBS 整合包安装信息存在问题", ex2);
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName == null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName = (string?)(CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["name"] ?? ((JToken)""));
			ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.PathMcFolder + "versions");
			if (Operators.CompareString(validateFolderName.ValidateText(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName), "", false) != 0)
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName = "";
			}
			if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName, "", false) == 0)
			{
				_Closure_0024__9_002D0 closure_0024__9_002D = CS_0024_003C_003E8__locals0;
				Collection<Validate> obj = new Collection<Validate>();
				obj.Add((Validate)validateFolderName);
				closure_0024__9_002D._0024VB_0024Local_InstanceName = ModMain.MyMsgBoxInput("输入实例名称", "", "", obj);
			}
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName))
			{
				throw new ModBase.CancelledException();
			}
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp = ModMain.RequestTaskTempFolder();
		CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder = $"{ModMinecraft.PathMcFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName}";
		List<ModLoader.LoaderBase> val2 = new List<ModLoader.LoaderBase>();
		val2.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, int>("解压整合包文件", [SpecialName] (ModLoader.LoaderTask<string, int> Task) =>
		{
			ExtractModpackFiles(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp, CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress, Task, 0.6);
			CopyOverrideDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstallTemp + CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "overrides", ModMinecraft.PathMcFolder + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName, Task, 0.4);
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["launchInfo"] != null)
			{
				JObject jObject = (JObject)CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["launchInfo"];
				Config.Instance.JvmArgs[CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder] = string.Join<JToken>(" ", (System.Collections.Generic.IEnumerable<JToken>)jObject["javaArgument"]);
				Config.Instance.GameArgs[CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder] = string.Join<JToken>(" ", (System.Collections.Generic.IEnumerable<JToken>)jObject["launchArgument"]);
			}
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["version"] != null)
			{
				Config.Instance.ModpackVersion[CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionFolder] = CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["version"].ToString();
			}
		}, null, (ThreadPriority)2)
		{
			ProgressWeight = (double)new FileInfo(CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress).Length / 1024.0 / 1024.0 / 6.0,
			Block = false
		});
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["addons"] == null)
		{
			throw new System.Exception("该 MCBBS 整合包未提供游戏版本附加信息，无法安装！");
		}
		Dictionary<string, string> val3 = new Dictionary<string, string>();
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator = ((System.Collections.Generic.IEnumerable<JToken>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Json["addons"]).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				JToken current = enumerator.Current;
				val3.Add((string?)current["id"], (string?)current["version"]);
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		if (!val3.ContainsKey("game"))
		{
			ModMain.Hint("该整合包未提供游戏版本信息，无法安装！", ModMain.HintType.Critical);
			return null;
		}
		ModDownloadLib.McInstallRequest mcInstallRequest = new ModDownloadLib.McInstallRequest
		{
			TargetInstanceName = CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName,
			TargetInstanceFolder = $"{ModMinecraft.PathMcFolder}versions\\{CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName}\\",
			MinecraftName = val3["game"],
			OptiFineVersion = (val3.ContainsKey("optifine") ? val3["optifine"] : null),
			ForgeVersion = (val3.ContainsKey("forge") ? val3["forge"] : null),
			NeoForgeVersion = (val3.ContainsKey("neoforge") ? val3["neoforge"] : null),
			FabricVersion = (val3.ContainsKey("fabric") ? val3["fabric"] : null),
			QuiltVersion = (val3.ContainsKey("quilt") ? val3["quilt"] : null)
		};
		List<ModLoader.LoaderBase> val4 = ModDownloadLib.McInstallLoader(mcInstallRequest);
		List<ModLoader.LoaderBase> val5 = new List<ModLoader.LoaderBase>();
		val5.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("整合包安装", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2)
		{
			Show = false,
			Block = false,
			ProgressWeight = Enumerable.Sum<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2, (Func<ModLoader.LoaderBase, double>)([SpecialName] (ModLoader.LoaderBase l) => l.ProgressWeight))
		});
		val5.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("游戏安装", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val4)
		{
			Show = false,
			ProgressWeight = Enumerable.Sum<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val4, (Func<ModLoader.LoaderBase, double>)([SpecialName] (ModLoader.LoaderBase l) => l.ProgressWeight))
		});
		CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName = "MCBBS 整合包安装：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName + " ";
		if (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar, (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => Operators.CompareString(l.Name, CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName, false) == 0)))
		{
			ModMain.Hint("该整合包正在安装中！", ModMain.HintType.Critical);
			throw new ModBase.CancelledException();
		}
		ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(CS_0024_003C_003E8__locals0._0024VB_0024Local_LoaderName, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val5);
		loaderCombo.OnStateChanged = ModDownloadLib.McInstallState;
		loaderCombo.Start(mcInstallRequest.TargetInstanceFolder);
		ModLoader.LoaderTaskbarAdd(loaderCombo);
		ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
		object action;
		if (_Closure_0024__._0024I9_002D4 != null)
		{
			action = _Closure_0024__._0024I9_002D4;
		}
		else
		{
			Action val6 = [SpecialName] () =>
			{
				ModMain.FrmMain.PageChange(FormMain.PageType.TaskManager);
			};
			_Closure_0024__._0024I9_002D4 = val6;
			action = (object)val6;
		}
		ModBase.RunInUi((Action)action);
		return loaderCombo;
	}

	private static ModLoader.LoaderCombo<string> InstallPackLauncherPack(string FileAddress, ZipArchive Archive, string ArchiveBaseFolder)
	{
		_Closure_0024__10_002D0 arg = default(_Closure_0024__10_002D0);
		_Closure_0024__10_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__10_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress = FileAddress;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder = ArchiveBaseFolder;
		ModMain.MyMsgBox("接下来请选择一个空文件夹，它会被安装到这个文件夹里。", "安装", "继续", "", "", IsWarn: false, HighLight: true, ForceWait: true);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder = SystemDialogs.SelectFolder("选择安装目标（必须是一个空文件夹）");
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder))
		{
			throw new ModBase.CancelledException();
		}
		if (Directory.GetFileSystemEntries(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder).Length > 0)
		{
			ModMain.Hint("请选择一个空文件夹作为安装目标！", ModMain.HintType.Critical);
			throw new ModBase.CancelledException();
		}
		ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("解压压缩包", new ModLoader.LoaderBase[1]
		{
			new ModLoader.LoaderTask<string, int>("解压压缩包", [SpecialName] (ModLoader.LoaderTask<string, int> Task) =>
			{
				ExtractModpackFiles(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder, CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress, Task, 0.9);
				Thread.Sleep(400);
				string text = null;
				string[] files = Directory.GetFiles(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder, "*.exe", (SearchOption)0);
				foreach (string text2 in files)
				{
					FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(text2);
					ModBase.Log($"[Modpack] 文件 {text2} 的产品名标识为 {versionInfo.ProductName}");
					if (Operators.CompareString(versionInfo.ProductName, "Plain Craft Launcher", false) == 0)
					{
						text = text2;
						ModBase.Log($"[Modpack] 发现整合包附带的 PCL 启动器：{text2}");
					}
					else if ((ModBase.ContainsF(versionInfo.ProductName, "Launcher", IgnoreCase: true) || ModBase.ContainsF(versionInfo.ProductName, "启动", IgnoreCase: true)) && Operators.CompareString(versionInfo.ProductName, "Plain Craft Launcher Admin Manager", false) != 0 && text == null)
					{
						text = text2;
						ModBase.Log($"[Modpack] 发现整合包附带的疑似第三方启动器：{text2}");
					}
				}
				Task.Progress = 0.95;
				if (text != null)
				{
					ModBase.Log("[Modpack] 找到压缩包中附带的启动器：" + text);
					if (ModMain.MyMsgBox(string.Format("整合包里似乎自带了启动器，是否换用它继续安装？{0}即将打开：{1}", (object)"\r\n", (object)text), "换用整合包启动器？", "换用", "不换用") == 1)
					{
						ModBase.OpenExplorer(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder);
						ModBase.ShellOnly(text, "--wait");
						ModBase.Log("[Modpack] 为换用整合包中的启动器启动，强制结束程序");
						ModMain.FrmMain.EndProgram(SendWarning: false);
						return;
					}
				}
				else
				{
					ModBase.Log("[Modpack] 未找到压缩包中附带的启动器");
				}
				ModBase.OpenExplorer(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder);
				string folderNameFromPath = ModBase.GetFolderNameFromPath(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder);
				Directory.CreateDirectory(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder + ".minecraft\\");
				PageSelectLeft.AddFolder(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder + ".minecraft\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder.Replace("/", "\\").TrimStart('\\'), folderNameFromPath, ShowHint: false);
				string text3 = Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)Directory.GetFiles(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder, "modpack.*", (SearchOption)1));
				ModBase.Log("[Modpack] 调用 modpack 文件继续安装：" + text3);
				ModpackInstall(text3);
			}, null, (ThreadPriority)2)
		});
		loaderCombo.Start(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder);
		ModLoader.LoaderTaskbarAdd(loaderCombo);
		ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
		ModMain.FrmMain.BtnExtraDownload.Ribble();
		return loaderCombo;
	}

	private static ModLoader.LoaderCombo<string> InstallPackCompress(string FileAddress, ZipArchive Archive)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		_Closure_0024__11_002D0 arg = default(_Closure_0024__11_002D0);
		_Closure_0024__11_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__11_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress = FileAddress;
		Match val = null;
		Regex val2 = new Regex("^.*\\/(?=versions\\/(?<ver>[^\\/]+)\\/(\\k<ver>)\\.json$)", (RegexOptions)1);
		System.Collections.Generic.IEnumerator<ZipArchiveEntry> enumerator = default(System.Collections.Generic.IEnumerator<ZipArchiveEntry>);
		try
		{
			enumerator = Archive.Entries.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				ZipArchiveEntry current = enumerator.Current;
				Match val3 = val2.Match("/" + current.FullName);
				if (((Group)val3).Success)
				{
					val = val3;
					break;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		if (val == null)
		{
			throw new System.Exception("未能找到适合的文件结构，这可能不是一个 MC 压缩包");
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder = ((Capture)val).Value.Replace("/", "\\").TrimStart('\\');
		string value = ((Capture)val.Groups[1]).Value;
		ModBase.Log("[ModPack] 检测到压缩包的 .minecraft 根目录：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder + "，命中的实例名：" + value);
		ModMain.MyMsgBox("接下来请选择一个空文件夹，它会被安装到这个文件夹里。", "安装", "继续", "", "", IsWarn: false, HighLight: true, ForceWait: true);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder = SystemDialogs.SelectFolder("选择安装目标（必须是一个空文件夹）");
		if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder))
		{
			throw new ModBase.CancelledException();
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder.Contains("!") || CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder.Contains(";"))
		{
			ModMain.Hint("Minecraft 文件夹路径中不能含有感叹号或分号！", ModMain.HintType.Critical);
			throw new ModBase.CancelledException();
		}
		if (Directory.GetFileSystemEntries(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder).Length > 0)
		{
			ModMain.Hint("请选择一个空文件夹作为安装目标！", ModMain.HintType.Critical);
			throw new ModBase.CancelledException();
		}
		ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("解压压缩包", new ModLoader.LoaderBase[1]
		{
			new ModLoader.LoaderTask<string, int>("解压压缩包", [SpecialName] (ModLoader.LoaderTask<string, int> Task) =>
			{
				//IL_0060: Unknown result type (might be due to invalid IL or missing references)
				//IL_0065: Unknown result type (might be due to invalid IL or missing references)
				//IL_006b: Expected O, but got Unknown
				ExtractModpackFiles(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder, CS_0024_003C_003E8__locals0._0024VB_0024Local_FileAddress, Task, 0.95);
				PageSelectLeft.AddFolder(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder + CS_0024_003C_003E8__locals0._0024VB_0024Local_ArchiveBaseFolder, ModBase.GetFolderNameFromPath(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder), ShowHint: false);
				Thread.Sleep(400);
				object action;
				if (_Closure_0024__._0024I11_002D1 != null)
				{
					action = _Closure_0024__._0024I11_002D1;
				}
				else
				{
					Action val4 = [SpecialName] () =>
					{
						ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSelect);
					};
					_Closure_0024__._0024I11_002D1 = val4;
					action = (object)val4;
				}
				ModBase.RunInUi((Action)action);
			}, null, (ThreadPriority)2)
		});
		loaderCombo.OnStateChanged = ModDownloadLib.McInstallState;
		loaderCombo.Start(CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetFolder);
		ModLoader.LoaderTaskbarAdd(loaderCombo);
		ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
		ModMain.FrmMain.BtnExtraDownload.Ribble();
		return loaderCombo;
	}
}
