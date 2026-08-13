using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.Core.Net;
using PCL.Core.Utils;

namespace PCL;

[StandardModule]
public sealed class ModDownload
{
	public enum AssetsIndexExistsBehaviour
	{
		DontDownload,
		DownloadInBackground,
		AlwaysDownload
	}

	public struct DlClientListResult
	{
		public string SourceName;

		public bool IsOfficial;

		public JObject Value;
	}

	public struct DlOptiFineListResult
	{
		public string SourceName;

		public bool IsOfficial;

		public List<DlOptiFineListEntry> Value;
	}

	public class DlOptiFineListEntry
	{
		public string NameDisplay;

		public string NameFile;

		public string NameVersion;

		public bool IsPreview;

		private string _inherit;

		public string ReleaseTime;

		public string RequiredForgeVersion;

		public string Inherit
		{
			get
			{
				return _inherit;
			}
			set
			{
				if (ModBase.EndsWithF(value, ".0"))
				{
					value = Strings.Left(value, checked(value.Length - 2));
				}
				_inherit = value;
			}
		}
	}

	public struct DlForgeListResult
	{
		public string SourceName;

		public bool IsOfficial;

		public List<string> Value;
	}

	public abstract class DlForgelikeEntry
	{
		public enum ForgelikeType
		{
			Forge,
			NeoForge,
			Cleanroom
		}

		public ForgelikeType ForgeType;

		public Version Version;

		public string VersionName;

		public string Inherit;

		public string LoaderName
		{
			get
			{
				if (ForgeType != ForgelikeType.NeoForge)
				{
					return "Forge";
				}
				return "NeoForge";
			}
		}

		public string FileExtension
		{
			get
			{
				if (ForgeType == ForgelikeType.Forge)
				{
					return (Operators.CompareString(((DlForgeVersionEntry)this).Category, "installer", false) == 0) ? "jar" : "zip";
				}
				return "jar";
			}
		}

		public bool IsLegacy
		{
			get
			{
				if (ForgeType == ForgelikeType.Cleanroom)
				{
					return false;
				}
				return Version.Major < 20;
			}
		}
	}

	public class DlForgeVersionEntry : DlForgelikeEntry
	{
		public string ReleaseTime;

		public string Hash;

		public bool IsRecommended;

		public string Category;

		public string FileVersion;

		public DlForgeVersionEntry(string Version, string Branch, string Inherit)
		{
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Expected O, but got Unknown
			Hash = null;
			switch (Version)
			{
			case "11.15.1.2318":
			case "11.15.1.1902":
			case "11.15.1.1890":
				Branch = "1.8.9";
				break;
			}
			if (Branch == null && Operators.CompareString(Inherit, "1.7.10", false) == 0 && Conversions.ToDouble(Version.Split(".", (StringSplitOptions)0)[3]) >= 1300.0)
			{
				Branch = "1.7.10";
			}
			ForgeType = ForgelikeType.Forge;
			VersionName = Version;
			base.Version = new Version(Version);
			base.Inherit = Inherit;
			FileVersion = Version + ((Branch == null) ? "" : ("-" + Branch));
		}
	}

	public struct DlNeoForgeListResult
	{
		public string SourceName;

		public bool IsOfficial;

		public List<DlNeoForgeListEntry> Value;
	}

	public class DlNeoForgeListEntry : DlForgelikeEntry
	{
		public bool IsBeta;

		public string ApiName;

		public string UrlBase
		{
			get
			{
				string text = (base.IsLegacy ? "forge" : "neoforge");
				return string.Format("https://maven.neoforged.net/releases/net/neoforged/{0}/{1}/{2}-{3}", new object[] { text, ApiName, text, ApiName });
			}
		}

		public DlNeoForgeListEntry(string ApiName)
		{
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Expected O, but got Unknown
			ForgeType = ForgelikeType.NeoForge;
			this.ApiName = ApiName;
			IsBeta = ApiName.Contains("beta");
			if (ApiName.Contains("1.20.1"))
			{
				VersionName = ApiName.Replace("1.20.1-", "");
				Version = new Version("19." + VersionName);
				Inherit = "1.20.1";
			}
			else
			{
				VersionName = ApiName;
				Version = new Version(ModBase.BeforeFirst(ApiName, "-"));
				Inherit = $"1.{Version.Major}" + ((Version.Minor == 0) ? "" : ("." + Conversions.ToString(Version.Minor)));
			}
		}
	}

	public struct DlCleanroomListResult
	{
		public string SourceName;

		public bool IsOfficial;

		public List<DlCleanroomListEntry> Value;
	}

	public class DlCleanroomListEntry : DlForgelikeEntry
	{
		public bool IsBeta;

		public string ApiName;

		public string UrlBase => $"https://github.com/CleanroomMC/Cleanroom/releases/download/{ApiName}/cleanroom-{ApiName}";

		public DlCleanroomListEntry(string ApiName)
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			ForgeType = ForgelikeType.Cleanroom;
			this.ApiName = ApiName;
			IsBeta = ApiName.Contains("alpha");
			VersionName = ApiName;
			Version = new Version(ModBase.BeforeFirst(ApiName, "-"));
			Inherit = "1.12.2";
		}
	}

	public struct DlLiteLoaderListResult
	{
		public string SourceName;

		public bool IsOfficial;

		public List<DlLiteLoaderListEntry> Value;

		public System.Exception OfficialError;
	}

	public class DlLiteLoaderListEntry
	{
		public string FileName;

		public bool IsPreview;

		public string Inherit;

		public bool IsLegacy;

		public string ReleaseTime;

		public string MD5;

		public JToken JsonToken;
	}

	public struct DlFabricListResult
	{
		public string SourceName;

		public bool IsOfficial;

		public JObject Value;
	}

	public struct DlQuiltListResult
	{
		public string SourceName;

		public bool IsOfficial;

		public JObject Value;
	}

	public struct DlLabyModListResult
	{
		public JObject Value;
	}

	public struct DlLegacyFabricListResult
	{
		public string SourceName;

		public bool IsOfficial;

		public JObject Value;
	}

	public static ModLoader.LoaderTask<string, DlClientListResult> DlClientListLoader = new ModLoader.LoaderTask<string, DlClientListResult>("DlClientList Main", DlClientListMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<string, DlClientListResult> DlClientListMojangLoader = new ModLoader.LoaderTask<string, DlClientListResult>("DlClientList Mojang", DlClientListMojangMain, null, (ThreadPriority)2);

	private static bool IsNewClientVersionHinted = false;

	public static ModLoader.LoaderTask<string, DlClientListResult> DlClientListBmclapiLoader = new ModLoader.LoaderTask<string, DlClientListResult>("DlClientList Bmclapi", DlClientListBmclapiMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlOptiFineListResult> DlOptiFineListLoader = new ModLoader.LoaderTask<int, DlOptiFineListResult>("DlOptiFineList Main", DlOptiFineListMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlOptiFineListResult> DlOptiFineListOfficialLoader = new ModLoader.LoaderTask<int, DlOptiFineListResult>("DlOptiFineList Official", DlOptiFineListOfficialMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlOptiFineListResult> DlOptiFineListBmclapiLoader = new ModLoader.LoaderTask<int, DlOptiFineListResult>("DlOptiFineList Bmclapi", DlOptiFineListBmclapiMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlForgeListResult> DlForgeListLoader = new ModLoader.LoaderTask<int, DlForgeListResult>("DlForgeList Main", DlForgeListMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlForgeListResult> DlForgeListOfficialLoader = new ModLoader.LoaderTask<int, DlForgeListResult>("DlForgeList Official", DlForgeListOfficialMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlForgeListResult> DlForgeListBmclapiLoader = new ModLoader.LoaderTask<int, DlForgeListResult>("DlForgeList Bmclapi", DlForgeListBmclapiMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlNeoForgeListResult> DlNeoForgeListLoader = new ModLoader.LoaderTask<int, DlNeoForgeListResult>("DlNeoForgeList Main", DlNeoForgeListMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlNeoForgeListResult> DlNeoForgeListOfficialLoader = new ModLoader.LoaderTask<int, DlNeoForgeListResult>("DlNeoForgeList Official", DlNeoForgeListOfficialMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlNeoForgeListResult> DlNeoForgeListBmclapiLoader = new ModLoader.LoaderTask<int, DlNeoForgeListResult>("DlNeoForgeList Bmclapi", DlNeoForgeListBmclapiMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlCleanroomListResult> DlCleanroomListLoader = new ModLoader.LoaderTask<int, DlCleanroomListResult>("DlCleanroomList Main", DlCleanroomListMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlCleanroomListResult> DlCleanroomListOfficialLoader = new ModLoader.LoaderTask<int, DlCleanroomListResult>("DlCleanroomList Official", DlCleanroomListOfficialMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlLiteLoaderListResult> DlLiteLoaderListLoader = new ModLoader.LoaderTask<int, DlLiteLoaderListResult>("DlLiteLoaderList Main", DlLiteLoaderListMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlLiteLoaderListResult> DlLiteLoaderListOfficialLoader = new ModLoader.LoaderTask<int, DlLiteLoaderListResult>("DlLiteLoaderList Official", DlLiteLoaderListOfficialMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlLiteLoaderListResult> DlLiteLoaderListBmclapiLoader = new ModLoader.LoaderTask<int, DlLiteLoaderListResult>("DlLiteLoaderList Bmclapi", DlLiteLoaderListBmclapiMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlFabricListResult> DlFabricListLoader = new ModLoader.LoaderTask<int, DlFabricListResult>("DlFabricList Main", DlFabricListMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlFabricListResult> DlFabricListOfficialLoader = new ModLoader.LoaderTask<int, DlFabricListResult>("DlFabricList Official", DlFabricListOfficialMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlFabricListResult> DlFabricListBmclapiLoader = new ModLoader.LoaderTask<int, DlFabricListResult>("DlFabricList Bmclapi", DlFabricListBmclapiMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, List<ModComp.CompFile>> DlFabricApiLoader = new ModLoader.LoaderTask<int, List<ModComp.CompFile>>("Fabric API List Loader", [SpecialName] (ModLoader.LoaderTask<int, List<ModComp.CompFile>> Task) =>
	{
		Task.Output = ModComp.CompFilesGet("fabric-api", FromCurseForge: false);
	}, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, List<ModComp.CompFile>> DlOptiFabricLoader = new ModLoader.LoaderTask<int, List<ModComp.CompFile>>("OptiFabric List Loader", [SpecialName] (ModLoader.LoaderTask<int, List<ModComp.CompFile>> Task) =>
	{
		Task.Output = ModComp.CompFilesGet("322385", FromCurseForge: true);
	}, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlQuiltListResult> DlQuiltListLoader = new ModLoader.LoaderTask<int, DlQuiltListResult>("DlQuiltList Main", DlQuiltListMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlQuiltListResult> DlQuiltListOfficialLoader = new ModLoader.LoaderTask<int, DlQuiltListResult>("DlQuiltList Official", DlQuiltListOfficialMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, List<ModComp.CompFile>> DlQSLLoader = new ModLoader.LoaderTask<int, List<ModComp.CompFile>>("QSL List Loader", [SpecialName] (ModLoader.LoaderTask<int, List<ModComp.CompFile>> Task) =>
	{
		Task.Output = ModComp.CompFilesGet("qsl", FromCurseForge: false);
	}, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlLabyModListResult> DlLabyModListLoader = new ModLoader.LoaderTask<int, DlLabyModListResult>("DlLabyModList Main", DlLabyModListMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlLabyModListResult> DlLabyModListOfficialLoader = new ModLoader.LoaderTask<int, DlLabyModListResult>("DlLabyModList Official", DlLabyModListOfficialMain, null, (ThreadPriority)2);

	private static bool DlPreferMojang = false;

	public static ModLoader.LoaderTask<int, DlLegacyFabricListResult> DlLegacyFabricListLoader = new ModLoader.LoaderTask<int, DlLegacyFabricListResult>("DlLegacyFabricList Main", DlLegacyFabricListMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, DlLegacyFabricListResult> DlLegacyFabricListOfficialLoader = new ModLoader.LoaderTask<int, DlLegacyFabricListResult>("DlLegacyFabricList Official", DlLegacyFabricListOfficialMain, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<int, List<ModComp.CompFile>> DlLegacyFabricApiLoader = new ModLoader.LoaderTask<int, List<ModComp.CompFile>>("Legacy Fabric API List Loader", [SpecialName] (ModLoader.LoaderTask<int, List<ModComp.CompFile>> Task) =>
	{
		Task.Output = ModComp.CompFilesGet("legacy-fabric-api", FromCurseForge: false);
	}, null, (ThreadPriority)2);

	public static bool DlSourcePreferMojang => Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.CompareObjectEqual(ModBase.Setup.Get("ToolDownloadSource"), (object)2, false)) || (Conversions.ToBoolean(Operators.CompareObjectEqual(ModBase.Setup.Get("ToolDownloadSource"), (object)1, false)) && DlPreferMojang)));

	public static bool DlVersionListPreferMojang => Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.CompareObjectEqual(ModBase.Setup.Get("ToolDownloadVersion"), (object)2, false)) || (Conversions.ToBoolean(Operators.CompareObjectEqual(ModBase.Setup.Get("ToolDownloadVersion"), (object)1, false)) && DlPreferMojang)));

	public static ModNet.NetFile DlClientJarGet(ModMinecraft.McInstance Version, bool ReturnNothingOnFileUseable)
	{
		try
		{
			while (!string.IsNullOrEmpty(Version.InheritInstance))
			{
				Version = new ModMinecraft.McInstance(Version.InheritInstance);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "获取底层继承实例失败");
			ProjectData.ClearProjectError();
		}
		if (Version.JsonObject["downloads"] == null || Version.JsonObject["downloads"]["client"] == null || Version.JsonObject["downloads"]["client"]["url"] == null)
		{
			throw new System.Exception("底层实例 " + Version.Name + " 中无 Jar 文件下载信息");
		}
		ModBase.FileChecker fileChecker = new ModBase.FileChecker(1024L, (long)(Version.JsonObject["downloads"]["client"]["size"] ?? ((JToken)(-1))), (string?)Version.JsonObject["downloads"]["client"]["sha1"]);
		if (ReturnNothingOnFileUseable && fileChecker.Check(Version.Path + Version.Name + ".jar") == null)
		{
			return null;
		}
		string original = (string?)Version.JsonObject["downloads"]["client"]["url"];
		return new ModNet.NetFile(DlSourceLauncherOrMetaGet(original), Version.Path + Version.Name + ".jar", fileChecker);
	}

	public static ModNet.NetFile DlClientAssetIndexGet(ModMinecraft.McInstance Version)
	{
		while (!string.IsNullOrEmpty(Version.InheritInstance))
		{
			Version = new ModMinecraft.McInstance(Version.InheritInstance);
		}
		JToken jToken = ModMinecraft.McAssetsGetIndex(Version, ReturnLegacyOnError: true, CheckURLEmpty: true);
		string localPath = ModMinecraft.PathMcFolder + "assets\\indexes\\" + jToken["id"].ToString() + ".json";
		ModBase.Log("[Download] 实例 " + Version.Name + " 对应的资源文件索引为 " + jToken["id"].ToString());
		string text = (string?)(jToken["url"] ?? ((JToken)""));
		if (Operators.CompareString(text, "", false) == 0)
		{
			return null;
		}
		return new ModNet.NetFile(DlSourceLauncherOrMetaGet(text), localPath, new ModBase.FileChecker(-1L, -1L, null, CanUseExistsFile: false, IsJson: true));
	}

	public static List<ModLoader.LoaderBase> DlClientFix(ModMinecraft.McInstance Version, bool CheckAssetsHash, AssetsIndexExistsBehaviour AssetsIndexBehaviour)
	{
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		if (Conversions.ToBoolean(ModMinecraft.ShouldIgnoreFileCheck(Version)))
		{
			ModBase.Log("[Download] 已跳过所有 Libraries 检查");
		}
		else
		{
			List<ModLoader.LoaderBase> obj = new List<ModLoader.LoaderBase>();
			obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析缺失支持库文件", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				Task.Output = ModMinecraft.McLibFix(Version);
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 1.0
			});
			obj.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载支持库文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 15.0
			});
			List<ModLoader.LoaderBase> loaders = obj;
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载支持库文件（主加载器）", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)loaders)
			{
				Block = false,
				Show = false,
				ProgressWeight = 16.0
			});
		}
		if (Conversions.ToBoolean(ModMinecraft.ShouldIgnoreFileCheck(Version)))
		{
			ModBase.Log("[Download] 已跳过所有 Assets 检查");
		}
		else
		{
			List<ModLoader.LoaderBase> val2 = new List<ModLoader.LoaderBase>();
			val2.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析资源文件索引地址", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				try
				{
					ModNet.NetFile netFile2 = DlClientAssetIndexGet(Version);
					new FileInfo(netFile2.LocalPath);
					if (AssetsIndexBehaviour != AssetsIndexExistsBehaviour.AlwaysDownload && netFile2.Check.Check(netFile2.LocalPath) == null)
					{
						Task.Output = new List<ModNet.NetFile>();
					}
					else
					{
						List<ModNet.NetFile> obj3 = new List<ModNet.NetFile>();
						obj3.Add(netFile2);
						Task.Output = obj3;
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					throw new System.Exception("分析资源文件索引地址失败", ex2);
				}
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 0.5,
				Show = false
			});
			val2.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载资源文件索引", new List<ModNet.NetFile>())
			{
				ProgressWeight = 2.0
			});
			if (AssetsIndexBehaviour == AssetsIndexExistsBehaviour.DownloadInBackground)
			{
				List<ModLoader.LoaderBase> val3 = new List<ModLoader.LoaderBase>();
				string text = null;
				string text2 = null;
				val3.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("后台分析资源文件索引地址", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
				{
					//IL_0083: Unknown result type (might be due to invalid IL or missing references)
					//IL_0088: Unknown result type (might be due to invalid IL or missing references)
					ModNet.NetFile netFile = DlClientAssetIndexGet(Version);
					text2 = netFile.LocalPath;
					text = ModBase.PathTemp + "Cache\\" + netFile.LocalName;
					netFile.LocalPath = text;
					List<ModNet.NetFile> obj2 = new List<ModNet.NetFile>();
					obj2.Add(netFile);
					Task.Output = obj2;
					if (File.Exists(text2))
					{
						TimeSpan val4 = File.GetLastWriteTime(text2).Date - DateAndTime.Now.Date;
						if (Math.Abs(val4.TotalDays) < 1.0)
						{
							ModBase.Log("[Download] 无需更新资源文件索引，取消");
							Task.Abort();
						}
					}
				}, null, (ThreadPriority)2));
				val3.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("后台下载资源文件索引", new List<ModNet.NetFile>()));
				val3.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<List<ModNet.NetFile>, string>("后台复制资源文件索引", [SpecialName] (ModLoader.LoaderTask<List<ModNet.NetFile>, string> Task) =>
				{
					ModBase.CopyFile(text, text2);
					ModLaunch.McLaunchLog("后台更新资源文件索引成功：" + text);
				}, null, (ThreadPriority)2));
				ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>("后台更新资源文件索引", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val3);
				ModBase.Log("[Download] 开始后台检查资源文件索引");
				loaderCombo.Start();
			}
			val2.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, List<ModNet.NetFile>>("分析缺失资源文件", [SpecialName] (ModLoader.LoaderTask<string, List<ModNet.NetFile>> Task) =>
			{
				ModLoader.LoaderTask<string, List<ModNet.NetFile>> loaderTask = Task;
				ModMinecraft.McInstance instance = Version;
				bool checkHash = CheckAssetsHash;
				ModLoader.LoaderBase ProgressFeed = Task;
				List<ModNet.NetFile> output = ModMinecraft.McAssetsFixList(instance, checkHash, ref ProgressFeed);
				Task = (ModLoader.LoaderTask<string, List<ModNet.NetFile>>)ProgressFeed;
				loaderTask.Output = output;
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 3.0
			});
			val2.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载资源文件", new List<ModNet.NetFile>())
			{
				ProgressWeight = 25.0
			});
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderCombo<string>("下载资源文件（主加载器）", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val2)
			{
				Block = false,
				Show = false,
				ProgressWeight = 30.5
			});
		}
		return val;
	}

	private static void DlClientListMain(ModLoader.LoaderTask<string, DlClientListResult> Loader)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		object obj = ModBase.Setup.Get("ToolDownloadVersion");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<string, DlClientListResult>, int>> obj2 = new List<KeyValuePair<ModLoader.LoaderTask<string, DlClientListResult>, int>>();
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<string, DlClientListResult>, int>(DlClientListBmclapiLoader, 30));
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<string, DlClientListResult>, int>(DlClientListMojangLoader, 90));
			DlSourceLoader(Loader, obj2, Loader.IsForceRestarting);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<string, DlClientListResult>, int>> obj3 = new List<KeyValuePair<ModLoader.LoaderTask<string, DlClientListResult>, int>>();
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<string, DlClientListResult>, int>(DlClientListMojangLoader, 5));
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<string, DlClientListResult>, int>(DlClientListBmclapiLoader, 35));
			DlSourceLoader(Loader, obj3, Loader.IsForceRestarting);
		}
		else
		{
			List<KeyValuePair<ModLoader.LoaderTask<string, DlClientListResult>, int>> obj4 = new List<KeyValuePair<ModLoader.LoaderTask<string, DlClientListResult>, int>>();
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<string, DlClientListResult>, int>(DlClientListMojangLoader, 60));
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<string, DlClientListResult>, int>(DlClientListBmclapiLoader, 120));
			DlSourceLoader(Loader, obj4, Loader.IsForceRestarting);
		}
	}

	private static void DlClientListMojangMain(ModLoader.LoaderTask<string, DlClientListResult> Loader)
	{
		long timeTick = TimeUtils.GetTimeTick();
		JObject jObject = (JObject)ModNet.NetGetCodeByRequestRetry("https://launchermeta.mojang.com/mc/game/version_manifest.json", null, "", IsJson: true);
		try
		{
			JArray jArray = (JArray)jObject["versions"];
			if (jArray.Count < 200)
			{
				throw new System.Exception("获取到的版本列表长度不足（" + jObject.ToString() + "）");
			}
			string text = ModBase.PathTemp + "Cache\\uvmc-download.json";
			if (!File.Exists(text))
			{
				try
				{
					JObject jObject2 = (JObject)ModNet.NetGetCodeByRequestRetry("https://alist.8mi.tech/d/mirror/unlisted-versions-of-minecraft/Auto/version_manifest.json", null, "", IsJson: true);
					File.WriteAllText(text, jObject2.ToString());
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log("[Download] 未列出的版本官方源下载失败: " + ex2.Message);
					ProjectData.ClearProjectError();
				}
			}
			try
			{
				JObject jObject3 = (JObject)ModBase.GetJson(ModBase.ReadFile(text));
				jArray.Merge(jObject3["versions"]);
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "[Download] UVMC 列表加载失败，忽略列表内容");
				ProjectData.ClearProjectError();
			}
			if (!DlPreferMojang)
			{
				long num = checked(TimeUtils.GetTimeTick() - timeTick);
				DlPreferMojang = num < 4000;
				ModBase.Log(string.Format("[Download] Mojang 官方源加载耗时：{0}ms，{1}", (object)num, (object)(DlPreferMojang ? "可优先使用官方源" : "不优先使用官方源")));
			}
			Loader.Output = new DlClientListResult
			{
				IsOfficial = true,
				SourceName = "Mojang 官方源",
				Value = jObject
			};
			string text2 = (string?)jObject["latest"]["release"];
			if (Conversions.ToBoolean((object)(Conversions.ToBoolean(ModBase.Setup.Get("ToolUpdateRelease")) && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase.Setup.Get("ToolUpdateReleaseLast"), (object)"", false))) && text2 != null && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase.Setup.Get("ToolUpdateReleaseLast"), (object)text2, false))))))
			{
				ModMinecraft.McDownloadClientUpdateHint(text2, jObject);
				IsNewClientVersionHinted = true;
			}
			ModDownloadLib.McVersionHighest = PCLVerCompat.VerToInt(text2);
			ModBase.Setup.Set("ToolUpdateReleaseLast", text2);
			text2 = (string?)jObject["latest"]["snapshot"];
			if (Conversions.ToBoolean((object)(Conversions.ToBoolean(ModBase.Setup.Get("ToolUpdateSnapshot")) && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase.Setup.Get("ToolUpdateSnapshotLast"), (object)"", false))) && text2 != null && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase.Setup.Get("ToolUpdateSnapshotLast"), (object)text2, false))) && !IsNewClientVersionHinted)))
			{
				ModMinecraft.McDownloadClientUpdateHint(text2, jObject);
			}
			ModBase.Setup.Set("ToolUpdateSnapshotLast", text2 ?? "Nothing");
		}
		catch (System.Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			System.Exception ex6 = ex5;
			throw new System.Exception("Minecraft 官方源版本列表解析失败", ex6);
		}
	}

	private static void DlClientListBmclapiMain(ModLoader.LoaderTask<string, DlClientListResult> Loader)
	{
		JObject jObject = (JObject)ModNet.NetGetCodeByRequestRetry("https://bmclapi2.bangbang93.com/mc/game/version_manifest.json", null, "", IsJson: true);
		try
		{
			JArray jArray = (JArray)jObject["versions"];
			if (jArray.Count < 200)
			{
				throw new System.Exception("获取到的版本列表长度不足（" + jObject.ToString() + "）");
			}
			string text = ModBase.PathTemp + "Cache\\uvmc-download.json";
			if (!File.Exists(text))
			{
				try
				{
					JObject jObject2 = (JObject)ModNet.NetGetCodeByRequestRetry("https://alist.8mi.tech/d/mirror/unlisted-versions-of-minecraft/Auto/version_manifest.json", null, "", IsJson: true);
					File.WriteAllText(text, jObject2.ToString());
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log("[Download] 未列出的版本镜像源下载失败: " + ex2.Message);
					ProjectData.ClearProjectError();
				}
			}
			try
			{
				JObject jObject3 = (JObject)ModBase.GetJson(ModBase.ReadFile(text));
				jArray.Merge(jObject3["versions"]);
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "[Download] UVMC 列表加载失败，忽略列表内容");
				ProjectData.ClearProjectError();
			}
			if (!string.IsNullOrEmpty(Loader.Input))
			{
				string input = Loader.Input;
				if (DlClientListLoader.Output.Value != null && !Enumerable.Any<JToken>((System.Collections.Generic.IEnumerable<JToken>)DlClientListLoader.Output.Value["versions"], (Func<JToken, bool>)([SpecialName] (JToken v) => (string?)v["id"] == input)))
				{
					throw new System.Exception("BMCLAPI 源未包含目标版本 " + input);
				}
			}
			Loader.Output = new DlClientListResult
			{
				IsOfficial = false,
				SourceName = "BMCLAPI",
				Value = jObject
			};
		}
		catch (System.Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			System.Exception ex6 = ex5;
			throw new System.Exception("Minecraft BMCLAPI 版本列表解析失败（" + jObject.ToString() + "）", ex6);
		}
	}

	public static object DlClientListGet(string Id)
	{
		object result;
		try
		{
			Id = Id.Replace("_", "-");
			if (Operators.CompareString(Id, "1.0", false) != 0 && ModBase.EndsWithF(Id, ".0"))
			{
				Id = Strings.Left(Id, checked(Id.Length - 2));
			}
			switch (DlClientListLoader.State)
			{
			case ModBase.LoadState.Finished:
			{
				System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator = ((System.Collections.Generic.IEnumerable<JToken>)DlClientListLoader.Output.Value["versions"]).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						JObject jObject = (JObject)enumerator.Current;
						if (!((string?)jObject["id"] == Id))
						{
							continue;
						}
						result = jObject["url"].ToString();
						goto end_IL_0000;
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				DlClientListLoader.WaitForExit(Id, null, IsForceRestart: true);
				break;
			}
			case ModBase.LoadState.Loading:
				DlClientListLoader.WaitForExit(Id);
				break;
			case ModBase.LoadState.Waiting:
			case ModBase.LoadState.Failed:
			case ModBase.LoadState.Aborted:
				DlClientListLoader.WaitForExit(Id, null, IsForceRestart: true);
				break;
			}
			System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)DlClientListLoader.Output.Value["versions"]).GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator2).MoveNext())
				{
					JObject jObject2 = (JObject)enumerator2.Current;
					if (!((string?)jObject2["id"] == Id))
					{
						continue;
					}
					result = jObject2["url"].ToString();
					goto end_IL_0000;
				}
			}
			finally
			{
				((System.IDisposable)enumerator2)?.Dispose();
			}
			ModBase.Log(string.Format("未发现版本 {0} 的 json 下载地址，版本列表返回为：{1}{2}", (object)Id, (object)"\r\n", (object)DlClientListLoader.Output.Value.ToString()), ModBase.LogLevel.Debug);
			result = null;
			end_IL_0000:;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, $"获取版本 {Id} 的 json 下载地址失败");
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static void DlOptiFineListMain(ModLoader.LoaderTask<int, DlOptiFineListResult> Loader)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		object obj = ModBase.Setup.Get("ToolDownloadVersion");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlOptiFineListResult>, int>> obj2 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlOptiFineListResult>, int>>();
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlOptiFineListResult>, int>(DlOptiFineListBmclapiLoader, 30));
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlOptiFineListResult>, int>(DlOptiFineListOfficialLoader, 90));
			DlSourceLoader(Loader, obj2, Loader.IsForceRestarting);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlOptiFineListResult>, int>> obj3 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlOptiFineListResult>, int>>();
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlOptiFineListResult>, int>(DlOptiFineListOfficialLoader, 5));
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlOptiFineListResult>, int>(DlOptiFineListBmclapiLoader, 35));
			DlSourceLoader(Loader, obj3, Loader.IsForceRestarting);
		}
		else
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlOptiFineListResult>, int>> obj4 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlOptiFineListResult>, int>>();
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlOptiFineListResult>, int>(DlOptiFineListOfficialLoader, 60));
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlOptiFineListResult>, int>(DlOptiFineListBmclapiLoader, 120));
			DlSourceLoader(Loader, obj4, Loader.IsForceRestarting);
		}
	}

	private static void DlOptiFineListOfficialMain(ModLoader.LoaderTask<int, DlOptiFineListResult> Loader)
	{
		string text = HttpRequestBuilder.Create("https://optifine.net/downloads", HttpMethod.Get).WithHeader("Accept", "application/json, text/javascript, */*; q=0.01").WithHeader("Accept-Language", "en-US,en;q=0.5")
			.WithHeader("X-Requested-With", "XMLHttpRequest")
			.SendAsync(throwIfNotSuccess: true)
			.Result.AsStringContent();
		if (text.Length < 200)
		{
			throw new System.Exception("获取到的版本列表长度不足（" + text + "）");
		}
		checked
		{
			try
			{
				List<string> val = ModBase.RegexSearch(text, "(?<=colForge'>)[^<]*", (RegexOptions)0);
				List<string> val2 = ModBase.RegexSearch(text, "(?<=colDate'>)[^<]+", (RegexOptions)0);
				List<string> val3 = ModBase.RegexSearch(text, "(?<=OptiFine_)[0-9A-Za-z_.]+(?=.jar\")", (RegexOptions)0);
				if (val2.Count != val3.Count)
				{
					throw new System.Exception("版本与发布时间数据无法对应");
				}
				if (val.Count != val3.Count)
				{
					throw new System.Exception("版本与 Forge 兼容数据无法对应");
				}
				if (val2.Count < 10)
				{
					throw new System.Exception("获取到的版本数量不足（" + text + "）");
				}
				List<DlOptiFineListEntry> val4 = new List<DlOptiFineListEntry>();
				int num = val2.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					val3[i] = val3[i].Replace("_", " ");
					DlOptiFineListEntry dlOptiFineListEntry = new DlOptiFineListEntry();
					dlOptiFineListEntry.NameDisplay = val3[i].Replace("HD U ", "").Replace(".0 ", " ");
					dlOptiFineListEntry.ReleaseTime = ModBase.Join((System.Collections.IEnumerable)(object)new string[3]
					{
						val2[i].Split(".", (StringSplitOptions)0)[2],
						val2[i].Split(".", (StringSplitOptions)0)[1],
						val2[i].Split(".", (StringSplitOptions)0)[0]
					}, "/");
					dlOptiFineListEntry.IsPreview = ModBase.ContainsF(val3[i], "pre", IgnoreCase: true);
					dlOptiFineListEntry.Inherit = val3[i].ToString().Split(" ", (StringSplitOptions)0)[0];
					dlOptiFineListEntry.NameFile = (ModBase.ContainsF(val3[i], "pre", IgnoreCase: true) ? "preview_" : "") + "OptiFine_" + val3[i].Replace(" ", "_") + ".jar";
					dlOptiFineListEntry.RequiredForgeVersion = val[i].Replace("Forge ", "").Replace("#", "");
					DlOptiFineListEntry dlOptiFineListEntry2 = dlOptiFineListEntry;
					if (dlOptiFineListEntry2.RequiredForgeVersion.Contains("N/A"))
					{
						dlOptiFineListEntry2.RequiredForgeVersion = null;
					}
					dlOptiFineListEntry2.NameVersion = dlOptiFineListEntry2.Inherit + "-OptiFine_" + val3[i].ToString().Replace(" ", "_").Replace(dlOptiFineListEntry2.Inherit + "_", "");
					val4.Add(dlOptiFineListEntry2);
				}
				Loader.Output = new DlOptiFineListResult
				{
					IsOfficial = true,
					SourceName = "OptiFine 官方源",
					Value = val4
				};
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				throw new System.Exception("OptiFine 官方源版本列表解析失败（" + text + "）", ex2);
			}
		}
	}

	private static void DlOptiFineListBmclapiMain(ModLoader.LoaderTask<int, DlOptiFineListResult> Loader)
	{
		JArray jArray = (JArray)ModNet.NetGetCodeByRequestRetry("https://bmclapi2.bangbang93.com/optifine/versionList", null, "", IsJson: true);
		try
		{
			List<DlOptiFineListEntry> val = new List<DlOptiFineListEntry>();
			System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator = jArray.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					JObject jObject = (JObject)enumerator.Current;
					DlOptiFineListEntry dlOptiFineListEntry = new DlOptiFineListEntry
					{
						NameDisplay = (jObject["mcversion"].ToString() + jObject["type"].ToString().Replace("HD_U", "").Replace("_", " ") + " " + jObject["patch"].ToString()).Replace(".0 ", " "),
						ReleaseTime = "",
						IsPreview = ModBase.ContainsF(jObject["patch"].ToString(), "pre", IgnoreCase: true),
						Inherit = jObject["mcversion"].ToString(),
						NameFile = jObject["filename"].ToString(),
						RequiredForgeVersion = (jObject["forge"] ?? ((JToken)"")).ToString().Replace("Forge ", "").Replace("#", "")
					};
					if (dlOptiFineListEntry.RequiredForgeVersion.Contains("N/A"))
					{
						dlOptiFineListEntry.RequiredForgeVersion = null;
					}
					dlOptiFineListEntry.NameVersion = dlOptiFineListEntry.Inherit + "-OptiFine_" + (jObject["type"].ToString() + " " + jObject["patch"].ToString()).Replace(".0 ", " ").Replace(" ", "_").Replace(dlOptiFineListEntry.Inherit + "_", "");
					val.Add(dlOptiFineListEntry);
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			Loader.Output = new DlOptiFineListResult
			{
				IsOfficial = false,
				SourceName = "BMCLAPI",
				Value = val
			};
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("OptiFine BMCLAPI 版本列表解析失败（" + jArray.ToString() + "）", ex2);
		}
	}

	private static void DlForgeListMain(ModLoader.LoaderTask<int, DlForgeListResult> Loader)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		object obj = ModBase.Setup.Get("ToolDownloadVersion");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlForgeListResult>, int>> obj2 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlForgeListResult>, int>>();
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlForgeListResult>, int>(DlForgeListBmclapiLoader, 30));
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlForgeListResult>, int>(DlForgeListOfficialLoader, 90));
			DlSourceLoader(Loader, obj2, Loader.IsForceRestarting);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlForgeListResult>, int>> obj3 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlForgeListResult>, int>>();
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlForgeListResult>, int>(DlForgeListOfficialLoader, 5));
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlForgeListResult>, int>(DlForgeListBmclapiLoader, 35));
			DlSourceLoader(Loader, obj3, Loader.IsForceRestarting);
		}
		else
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlForgeListResult>, int>> obj4 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlForgeListResult>, int>>();
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlForgeListResult>, int>(DlForgeListOfficialLoader, 60));
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlForgeListResult>, int>(DlForgeListBmclapiLoader, 120));
			DlSourceLoader(Loader, obj4, Loader.IsForceRestarting);
		}
	}

	private static void DlForgeListOfficialMain(ModLoader.LoaderTask<int, DlForgeListResult> Loader)
	{
		string text = Conversions.ToString(ModNet.NetGetCodeByRequestRetry("https://files.minecraftforge.net/maven/net/minecraftforge/forge/index_1.2.4.html", Encoding.Default, "text/html", IsJson: false, null, UseBrowserUserAgent: true));
		if (text.Length < 200)
		{
			throw new System.Exception("获取到的版本列表长度不足（" + text + "）");
		}
		List<string> val = ModBase.RegexSearch(text, "(?<=a href=\"index_)[0-9.]+(_pre[0-9]?)?(?=.html)", (RegexOptions)0);
		val.Add("1.2.4");
		if (val.Count < 10)
		{
			throw new System.Exception("获取到的版本数量不足（" + text + "）");
		}
		Loader.Output = new DlForgeListResult
		{
			IsOfficial = true,
			SourceName = "Forge 官方源",
			Value = val
		};
	}

	private static void DlForgeListBmclapiMain(ModLoader.LoaderTask<int, DlForgeListResult> Loader)
	{
		string text = Conversions.ToString(ModNet.NetGetCodeByRequestRetry("https://bmclapi2.bangbang93.com/forge/minecraft", Encoding.Default));
		if (text.Length < 200)
		{
			throw new System.Exception("获取到的版本列表长度不足（" + text + "）");
		}
		List<string> val = ModBase.RegexSearch(text, "[0-9.]+(_pre[0-9]?)?", (RegexOptions)0);
		if (val.Count < 10)
		{
			throw new System.Exception("获取到的版本数量不足（" + text + "）");
		}
		Loader.Output = new DlForgeListResult
		{
			IsOfficial = false,
			SourceName = "BMCLAPI",
			Value = val
		};
	}

	public static void DlForgeVersionMain(ModLoader.LoaderTask<string, List<DlForgeVersionEntry>> Loader)
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		ModLoader.LoaderTask<string, List<DlForgeVersionEntry>> loaderTask = new ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>("DlForgeVersion Official", DlForgeVersionOfficialMain, null, (ThreadPriority)2);
		ModLoader.LoaderTask<string, List<DlForgeVersionEntry>> loaderTask2 = new ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>("DlForgeVersion Bmclapi", DlForgeVersionBmclapiMain, null, (ThreadPriority)2);
		object obj = ModBase.Setup.Get("ToolDownloadVersion");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>, int>> obj2 = new List<KeyValuePair<ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>, int>>();
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>, int>(loaderTask2, 30));
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>, int>(loaderTask, 90));
			DlSourceLoader(Loader, obj2, Loader.IsForceRestarting);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>, int>> obj3 = new List<KeyValuePair<ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>, int>>();
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>, int>(loaderTask, 5));
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>, int>(loaderTask2, 35));
			DlSourceLoader(Loader, obj3, Loader.IsForceRestarting);
		}
		else
		{
			List<KeyValuePair<ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>, int>> obj4 = new List<KeyValuePair<ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>, int>>();
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>, int>(loaderTask, 60));
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<string, List<DlForgeVersionEntry>>, int>(loaderTask2, 120));
			DlSourceLoader(Loader, obj4, Loader.IsForceRestarting);
		}
	}

	public static void DlForgeVersionOfficialMain(ModLoader.LoaderTask<string, List<DlForgeVersionEntry>> Loader)
	{
		string text;
		try
		{
			text = ModNet.NetGetCodeByLoader("https://files.minecraftforge.net/maven/net/minecraftforge/forge/index_" + Loader.Input.Replace("-", "_") + ".html", 45000, IsJson: false, UseBrowserUserAgent: true);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			if (ex2.Message.Contains("(404)"))
			{
				throw new System.Exception("不可用");
			}
			throw;
		}
		if (text.Length < 1000)
		{
			throw new System.Exception("获取到的版本列表长度不足（" + text + "）");
		}
		List<DlForgeVersionEntry> val = new List<DlForgeVersionEntry>();
		checked
		{
			try
			{
				string[] array = Strings.Mid(text, 1, ModBase.LastIndexOfF(text, "</table>")).Split("<td class=\"download-version", (StringSplitOptions)0);
				int num = Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)array) - 1;
				for (int i = 1; i <= num; i++)
				{
					string text2 = array[i];
					try
					{
						string text3 = ModBase.RegexSeek(text2, "(?<=[^(0-9)]+)[0-9\\.]+", (RegexOptions)0);
						bool isRecommended = text2.Contains("fa promo-recommended");
						string input = Loader.Input;
						string text4 = ModBase.RegexSeek(text2, $"(?<=-{text3}-)[^-\"]+(?=-[a-z]+.[a-z]{{3}})", (RegexOptions)0);
						if (string.IsNullOrWhiteSpace(text4))
						{
							text4 = null;
						}
						string releaseTime = System.DateTime.Parse(ModBase.RegexSeek(text2, "(?<=\"download-time\" title=\")[^\"]+", (RegexOptions)0), (IFormatProvider)null, (DateTimeStyles)64).ToLocalTime().ToString("yyyy'/'MM'/'dd HH':'mm");
						string text5;
						string category;
						if (text2.Contains("classifier-installer\""))
						{
							text2 = text2.Substring(ModBase.IndexOfF(text2, "installer.jar"));
							text5 = ModBase.RegexSeek(text2, "(?<=MD5:</strong> )[^<]+", (RegexOptions)0);
							category = "installer";
							goto IL_01e4;
						}
						if (text2.Contains("classifier-universal\""))
						{
							text2 = text2.Substring(ModBase.IndexOfF(text2, "universal.zip"));
							text5 = ModBase.RegexSeek(text2, "(?<=MD5:</strong> )[^<]+", (RegexOptions)0);
							category = "universal";
							goto IL_01e4;
						}
						if (text2.Contains("client.zip"))
						{
							text2 = text2.Substring(ModBase.IndexOfF(text2, "client.zip"));
							text5 = ModBase.RegexSeek(text2, "(?<=MD5:</strong> )[^<]+", (RegexOptions)0);
							category = "client";
							goto IL_01e4;
						}
						goto end_IL_00b9;
						IL_01e4:
						val.Add(new DlForgeVersionEntry(text3, text4, input)
						{
							Category = category,
							IsRecommended = isRecommended,
							Hash = text5.Trim(new char[] { '\r', '\n' }),
							ReleaseTime = releaseTime
						});
						end_IL_00b9:;
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						throw new System.Exception("Forge 官方源版本信息提取失败（" + text2 + "）", ex4);
					}
				}
			}
			catch (System.Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				System.Exception ex6 = ex5;
				throw new System.Exception("Forge 官方源版本列表解析失败（" + text + "）", ex6);
			}
			if (!Enumerable.Any<DlForgeVersionEntry>((System.Collections.Generic.IEnumerable<DlForgeVersionEntry>)val))
			{
				throw new System.Exception("不可用");
			}
			Loader.Output = val;
		}
	}

	public static void DlForgeVersionBmclapiMain(ModLoader.LoaderTask<string, List<DlForgeVersionEntry>> Loader)
	{
		JArray jArray = (JArray)ModNet.NetGetCodeByRequestRetry("https://bmclapi2.bangbang93.com/forge/minecraft/" + Loader.Input.Replace("-", "_"), null, "", IsJson: true);
		List<DlForgeVersionEntry> val = new List<DlForgeVersionEntry>();
		try
		{
			string text = ModDownloadLib.McDownloadForgeRecommendedGet(Loader.Input);
			System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator = jArray.GetEnumerator();
				System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					JObject jObject = (JObject)enumerator.Current;
					string hash = null;
					string category = "unknown";
					int num = -1;
					try
					{
						enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)jObject["files"]).GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator2).MoveNext())
						{
							JObject jObject2 = (JObject)enumerator2.Current;
							switch (jObject2["category"].ToString())
							{
							case "installer":
								if (Operators.CompareString(jObject2["format"].ToString(), "jar", false) == 0)
								{
									hash = (string?)jObject2["hash"];
									category = "installer";
									num = 2;
								}
								break;
							case "universal":
								if (num <= 1 && Operators.CompareString(jObject2["format"].ToString(), "zip", false) == 0)
								{
									hash = (string?)jObject2["hash"];
									category = "universal";
									num = 1;
								}
								break;
							case "client":
								if (num <= 0 && Operators.CompareString(jObject2["format"].ToString(), "zip", false) == 0)
								{
									hash = (string?)jObject2["hash"];
									category = "client";
									num = 0;
								}
								break;
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator2)?.Dispose();
					}
					string branch = (string?)jObject["branch"];
					string text2 = (string?)jObject["version"];
					DlForgeVersionEntry dlForgeVersionEntry = new DlForgeVersionEntry(text2, branch, Loader.Input)
					{
						Hash = hash,
						Category = category,
						IsRecommended = (Operators.CompareString(text, text2, false) == 0)
					};
					string text3 = jObject["modified"].ToString();
					char[] array = new char[] { '-', 'T', ':', '.', ' ', '/' };
					text3.Split(array);
					dlForgeVersionEntry.ReleaseTime = jObject["modified"].ToObject<System.DateTime>().ToLocalTime().ToString("yyyy'/'MM'/'dd HH':'mm");
					val.Add(dlForgeVersionEntry);
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("Forge BMCLAPI 版本列表解析失败（" + jArray.ToString() + "）", ex2);
		}
		if (!Enumerable.Any<DlForgeVersionEntry>((System.Collections.Generic.IEnumerable<DlForgeVersionEntry>)val))
		{
			throw new System.Exception("不可用");
		}
		Loader.Output = val;
	}

	private static void DlNeoForgeListMain(ModLoader.LoaderTask<int, DlNeoForgeListResult> Loader)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		object obj = ModBase.Setup.Get("ToolDownloadVersion");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlNeoForgeListResult>, int>> obj2 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlNeoForgeListResult>, int>>();
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlNeoForgeListResult>, int>(DlNeoForgeListBmclapiLoader, 30));
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlNeoForgeListResult>, int>(DlNeoForgeListOfficialLoader, 90));
			DlSourceLoader(Loader, obj2, Loader.IsForceRestarting);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlNeoForgeListResult>, int>> obj3 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlNeoForgeListResult>, int>>();
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlNeoForgeListResult>, int>(DlNeoForgeListOfficialLoader, 5));
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlNeoForgeListResult>, int>(DlNeoForgeListBmclapiLoader, 35));
			DlSourceLoader(Loader, obj3, Loader.IsForceRestarting);
		}
		else
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlNeoForgeListResult>, int>> obj4 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlNeoForgeListResult>, int>>();
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlNeoForgeListResult>, int>(DlNeoForgeListOfficialLoader, 60));
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlNeoForgeListResult>, int>(DlNeoForgeListBmclapiLoader, 120));
			DlSourceLoader(Loader, obj4, Loader.IsForceRestarting);
		}
	}

	private static void DlNeoForgeListOfficialMain(ModLoader.LoaderTask<int, DlNeoForgeListResult> Loader)
	{
		string text = ModNet.NetGetCodeByLoader("https://maven.neoforged.net/api/maven/versions/releases/net/neoforged/neoforge", 45000, IsJson: true, UseBrowserUserAgent: true);
		string text2 = ModNet.NetGetCodeByLoader("https://maven.neoforged.net/api/maven/versions/releases/net/neoforged/forge", 45000, IsJson: true, UseBrowserUserAgent: true);
		if (text.Length < 100 || text2.Length < 100)
		{
			throw new System.Exception("获取到的版本列表长度不足（" + text + "）");
		}
		try
		{
			Loader.Output = new DlNeoForgeListResult
			{
				IsOfficial = true,
				SourceName = "NeoForge 官方源",
				Value = GetNeoForgeEntries(text, text2)
			};
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception(string.Concat(new string[] { "NeoForge 官方源版本列表解析失败（", text, "\r\n\r\n", text2, "）" }), ex2);
		}
	}

	public static void DlNeoForgeListBmclapiMain(ModLoader.LoaderTask<int, DlNeoForgeListResult> Loader)
	{
		string text = ModNet.NetGetCodeByLoader("https://bmclapi2.bangbang93.com/neoforge/meta/api/maven/details/releases/net/neoforged/neoforge", 45000, IsJson: true, UseBrowserUserAgent: true);
		string text2 = ModNet.NetGetCodeByLoader("https://bmclapi2.bangbang93.com/neoforge/meta/api/maven/details/releases/net/neoforged/forge", 45000, IsJson: true, UseBrowserUserAgent: true);
		if (text.Length < 100 || text2.Length < 100)
		{
			throw new System.Exception("获取到的版本列表长度不足（" + text + "）");
		}
		try
		{
			Loader.Output = new DlNeoForgeListResult
			{
				IsOfficial = true,
				SourceName = "BMCLAPI",
				Value = GetNeoForgeEntries(text, text2)
			};
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception(string.Concat(new string[] { "NeoForge BMCLAPI 版本列表解析失败（", text, "\r\n\r\n", text2, "）" }), ex2);
		}
	}

	private static List<DlNeoForgeListEntry> GetNeoForgeEntries(string LatestJson, string LatestLegacyJson)
	{
		List<DlNeoForgeListEntry> obj = Enumerable.ToList<DlNeoForgeListEntry>(Enumerable.Select<string, DlNeoForgeListEntry>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)ModBase.RegexSearch(LatestLegacyJson + LatestJson, "(?<=\")(1\\.20\\.1-)?\\d+\\.\\d+\\.\\d+(-beta)?(?=\")", (RegexOptions)0), (Func<string, bool>)([SpecialName] (string name) => Operators.CompareString(name, "47.1.82", false) != 0)), (Func<string, DlNeoForgeListEntry>)([SpecialName] (string name) => new DlNeoForgeListEntry(name))));
		if (!Enumerable.Any<DlNeoForgeListEntry>((System.Collections.Generic.IEnumerable<DlNeoForgeListEntry>)obj))
		{
			throw new System.Exception("不可用");
		}
		return Enumerable.ToList<DlNeoForgeListEntry>((System.Collections.Generic.IEnumerable<DlNeoForgeListEntry>)Enumerable.OrderByDescending<DlNeoForgeListEntry, Version>((System.Collections.Generic.IEnumerable<DlNeoForgeListEntry>)obj, (Func<DlNeoForgeListEntry, Version>)([SpecialName] (DlNeoForgeListEntry a) => a.Version)));
	}

	private static void DlCleanroomListMain(ModLoader.LoaderTask<int, DlCleanroomListResult> Loader)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		object obj = ModBase.Setup.Get("ToolDownloadVersion");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlCleanroomListResult>, int>> obj2 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlCleanroomListResult>, int>>();
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlCleanroomListResult>, int>(DlCleanroomListOfficialLoader, 30));
			DlSourceLoader(Loader, obj2, Loader.IsForceRestarting);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlCleanroomListResult>, int>> obj3 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlCleanroomListResult>, int>>();
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlCleanroomListResult>, int>(DlCleanroomListOfficialLoader, 5));
			DlSourceLoader(Loader, obj3, Loader.IsForceRestarting);
		}
		else
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlCleanroomListResult>, int>> obj4 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlCleanroomListResult>, int>>();
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlCleanroomListResult>, int>(DlCleanroomListOfficialLoader, 60));
			DlSourceLoader(Loader, obj4, Loader.IsForceRestarting);
		}
	}

	private static void DlCleanroomListOfficialMain(ModLoader.LoaderTask<int, DlCleanroomListResult> Loader)
	{
		string text = Conversions.ToString(ModNet.NetGetCodeByRequestRetry("https://api.github.com/repos/CleanroomMC/Cleanroom/releases", null, "", IsJson: false, null, UseBrowserUserAgent: true));
		if (text.Length < 100)
		{
			throw new System.Exception("获取到的版本列表长度不足（" + text + "）");
		}
		try
		{
			Loader.Output = new DlCleanroomListResult
			{
				IsOfficial = true,
				SourceName = "Cleanroom 官方源",
				Value = GetCleanroomEntries(text)
			};
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("Cleanroom 官方源版本列表解析失败（" + text + "）", ex2);
		}
	}

	private static List<DlCleanroomListEntry> GetCleanroomEntries(string LatestJson)
	{
		List<DlCleanroomListEntry> val = new List<DlCleanroomListEntry>();
		JArray jArray = JArray.Parse(LatestJson);
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator = jArray.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				JObject jObject = (JObject)enumerator.Current;
				val.Add(new DlCleanroomListEntry(jObject["tag_name"].ToString())
				{
					ForgeType = DlForgelikeEntry.ForgelikeType.Cleanroom
				});
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		if (!Enumerable.Any<DlCleanroomListEntry>((System.Collections.Generic.IEnumerable<DlCleanroomListEntry>)val))
		{
			throw new System.Exception("没有可用版本");
		}
		return Enumerable.ToList<DlCleanroomListEntry>((System.Collections.Generic.IEnumerable<DlCleanroomListEntry>)Enumerable.OrderByDescending<DlCleanroomListEntry, Version>((System.Collections.Generic.IEnumerable<DlCleanroomListEntry>)val, (Func<DlCleanroomListEntry, Version>)([SpecialName] (DlCleanroomListEntry a) => a.Version)));
	}

	private static void DlLiteLoaderListMain(ModLoader.LoaderTask<int, DlLiteLoaderListResult> Loader)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		object obj = ModBase.Setup.Get("ToolDownloadVersion");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlLiteLoaderListResult>, int>> obj2 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlLiteLoaderListResult>, int>>();
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLiteLoaderListResult>, int>(DlLiteLoaderListBmclapiLoader, 30));
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLiteLoaderListResult>, int>(DlLiteLoaderListOfficialLoader, 90));
			DlSourceLoader(Loader, obj2, Loader.IsForceRestarting);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlLiteLoaderListResult>, int>> obj3 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlLiteLoaderListResult>, int>>();
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLiteLoaderListResult>, int>(DlLiteLoaderListOfficialLoader, 5));
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLiteLoaderListResult>, int>(DlLiteLoaderListBmclapiLoader, 35));
			DlSourceLoader(Loader, obj3, Loader.IsForceRestarting);
		}
		else
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlLiteLoaderListResult>, int>> obj4 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlLiteLoaderListResult>, int>>();
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLiteLoaderListResult>, int>(DlLiteLoaderListOfficialLoader, 60));
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLiteLoaderListResult>, int>(DlLiteLoaderListBmclapiLoader, 120));
			DlSourceLoader(Loader, obj4, Loader.IsForceRestarting);
		}
	}

	private static void DlLiteLoaderListOfficialMain(ModLoader.LoaderTask<int, DlLiteLoaderListResult> Loader)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		JObject jObject = (JObject)ModNet.NetGetCodeByRequestRetry("https://dl.liteloader.com/versions/versions.json", null, "", IsJson: true);
		try
		{
			JObject jObject2 = (JObject)jObject["versions"];
			List<DlLiteLoaderListEntry> val = new List<DlLiteLoaderListEntry>();
			System.Collections.Generic.IEnumerator<KeyValuePair<string, JToken>> enumerator = default(System.Collections.Generic.IEnumerator<KeyValuePair<string, JToken>>);
			try
			{
				enumerator = jObject2.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					KeyValuePair<string, JToken> current = enumerator.Current;
					if (!ModBase.StartsWithF(current.Key, "1.6") && !ModBase.StartsWithF(current.Key, "1.5"))
					{
						JToken jToken = (current.Value["artefacts"] ?? current.Value["snapshots"])["com.mumfrey:liteloader"]["latest"];
						val.Add(new DlLiteLoaderListEntry
						{
							Inherit = current.Key,
							IsLegacy = (Conversions.ToDouble(current.Key.Split(".", (StringSplitOptions)0)[1]) < 8.0),
							IsPreview = (Operators.CompareString(jToken["stream"].ToString().ToLower(), "snapshot", false) == 0),
							FileName = "liteloader-installer-" + current.Key + ((Operators.CompareString(current.Key, "1.8", false) == 0 || Operators.CompareString(current.Key, "1.9", false) == 0) ? ".0" : "") + "-00-SNAPSHOT.jar",
							MD5 = (string?)jToken["md5"],
							ReleaseTime = TimeUtils.FormatUnixTimestamp((long)jToken["timestamp"]),
							JsonToken = jToken
						});
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			Loader.Output = new DlLiteLoaderListResult
			{
				IsOfficial = true,
				SourceName = "LiteLoader 官方源",
				Value = val
			};
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("LiteLoader 官方源版本列表解析失败（" + jObject.ToString() + "）", ex2);
		}
	}

	private static void DlLiteLoaderListBmclapiMain(ModLoader.LoaderTask<int, DlLiteLoaderListResult> Loader)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		JObject jObject = (JObject)ModNet.NetGetCodeByRequestRetry("https://bmclapi2.bangbang93.com/maven/com/mumfrey/liteloader/versions.json", null, "", IsJson: true);
		try
		{
			JObject jObject2 = (JObject)jObject["versions"];
			List<DlLiteLoaderListEntry> val = new List<DlLiteLoaderListEntry>();
			System.Collections.Generic.IEnumerator<KeyValuePair<string, JToken>> enumerator = default(System.Collections.Generic.IEnumerator<KeyValuePair<string, JToken>>);
			try
			{
				enumerator = jObject2.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					KeyValuePair<string, JToken> current = enumerator.Current;
					if (!ModBase.StartsWithF(current.Key, "1.6") && !ModBase.StartsWithF(current.Key, "1.5"))
					{
						JToken jToken = (current.Value["artefacts"] ?? current.Value["snapshots"])["com.mumfrey:liteloader"]["latest"];
						val.Add(new DlLiteLoaderListEntry
						{
							Inherit = current.Key,
							IsLegacy = (Conversions.ToDouble(current.Key.Split(".", (StringSplitOptions)0)[1]) < 8.0),
							IsPreview = (Operators.CompareString(jToken["stream"].ToString().ToLower(), "snapshot", false) == 0),
							FileName = "liteloader-installer-" + current.Key + ((Operators.CompareString(current.Key, "1.8", false) == 0 || Operators.CompareString(current.Key, "1.9", false) == 0) ? ".0" : "") + "-00-SNAPSHOT.jar",
							MD5 = (string?)jToken["md5"],
							ReleaseTime = TimeUtils.FormatUnixTimestamp((long)jToken["timestamp"]),
							JsonToken = jToken
						});
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			Loader.Output = new DlLiteLoaderListResult
			{
				IsOfficial = false,
				SourceName = "BMCLAPI",
				Value = val
			};
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("LiteLoader BMCLAPI 版本列表解析失败（" + jObject.ToString() + "）", ex2);
		}
	}

	private static void DlFabricListMain(ModLoader.LoaderTask<int, DlFabricListResult> Loader)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		object obj = ModBase.Setup.Get("ToolDownloadVersion");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlFabricListResult>, int>> obj2 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlFabricListResult>, int>>();
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlFabricListResult>, int>(DlFabricListBmclapiLoader, 30));
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlFabricListResult>, int>(DlFabricListOfficialLoader, 90));
			DlSourceLoader(Loader, obj2, Loader.IsForceRestarting);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlFabricListResult>, int>> obj3 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlFabricListResult>, int>>();
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlFabricListResult>, int>(DlFabricListOfficialLoader, 5));
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlFabricListResult>, int>(DlFabricListBmclapiLoader, 35));
			DlSourceLoader(Loader, obj3, Loader.IsForceRestarting);
		}
		else
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlFabricListResult>, int>> obj4 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlFabricListResult>, int>>();
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlFabricListResult>, int>(DlFabricListOfficialLoader, 60));
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlFabricListResult>, int>(DlFabricListBmclapiLoader, 120));
			DlSourceLoader(Loader, obj4, Loader.IsForceRestarting);
		}
	}

	private static void DlFabricListOfficialMain(ModLoader.LoaderTask<int, DlFabricListResult> Loader)
	{
		JObject jObject = (JObject)ModNet.NetGetCodeByRequestRetry("https://meta.fabricmc.net/v2/versions", null, "", IsJson: true);
		try
		{
			DlFabricListResult dlFabricListResult = default(DlFabricListResult);
			dlFabricListResult.IsOfficial = true;
			dlFabricListResult.SourceName = "Fabric 官方源";
			dlFabricListResult.Value = jObject;
			DlFabricListResult output = dlFabricListResult;
			if (output.Value["game"] == null || output.Value["loader"] == null || output.Value["installer"] == null)
			{
				throw new System.Exception("获取到的列表缺乏必要项");
			}
			Loader.Output = output;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("Fabric 官方源版本列表解析失败（" + jObject.ToString() + "）", ex2);
		}
	}

	private static void DlFabricListBmclapiMain(ModLoader.LoaderTask<int, DlFabricListResult> Loader)
	{
		JObject jObject = (JObject)ModNet.NetGetCodeByRequestRetry("https://bmclapi2.bangbang93.com/fabric-meta/v2/versions", null, "", IsJson: true);
		try
		{
			DlFabricListResult dlFabricListResult = default(DlFabricListResult);
			dlFabricListResult.IsOfficial = false;
			dlFabricListResult.SourceName = "BMCLAPI";
			dlFabricListResult.Value = jObject;
			DlFabricListResult output = dlFabricListResult;
			if (output.Value["game"] == null || output.Value["loader"] == null || output.Value["installer"] == null)
			{
				throw new System.Exception("获取到的列表缺乏必要项");
			}
			Loader.Output = output;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("Fabric BMCLAPI 版本列表解析失败（" + jObject.ToString() + "）", ex2);
		}
	}

	private static void DlQuiltListMain(ModLoader.LoaderTask<int, DlQuiltListResult> Loader)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		object obj = ModBase.Setup.Get("ToolDownloadVersion");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlQuiltListResult>, int>> obj2 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlQuiltListResult>, int>>();
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlQuiltListResult>, int>(DlQuiltListOfficialLoader, 30));
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlQuiltListResult>, int>(DlQuiltListOfficialLoader, 60));
			DlSourceLoader(Loader, obj2, Loader.IsForceRestarting);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlQuiltListResult>, int>> obj3 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlQuiltListResult>, int>>();
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlQuiltListResult>, int>(DlQuiltListOfficialLoader, 5));
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlQuiltListResult>, int>(DlQuiltListOfficialLoader, 35));
			DlSourceLoader(Loader, obj3, Loader.IsForceRestarting);
		}
		else
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlQuiltListResult>, int>> obj4 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlQuiltListResult>, int>>();
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlQuiltListResult>, int>(DlQuiltListOfficialLoader, 60));
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlQuiltListResult>, int>(DlQuiltListOfficialLoader, 60));
			DlSourceLoader(Loader, obj4, Loader.IsForceRestarting);
		}
	}

	private static void DlQuiltListOfficialMain(ModLoader.LoaderTask<int, DlQuiltListResult> Loader)
	{
		JObject jObject = (JObject)ModNet.NetGetCodeByRequestRetry("https://meta.quiltmc.org/v3/versions", null, "", IsJson: true);
		try
		{
			DlQuiltListResult dlQuiltListResult = default(DlQuiltListResult);
			dlQuiltListResult.IsOfficial = true;
			dlQuiltListResult.SourceName = "Quilt 官方源";
			dlQuiltListResult.Value = jObject;
			DlQuiltListResult output = dlQuiltListResult;
			if (output.Value["game"] == null || output.Value["loader"] == null || output.Value["installer"] == null)
			{
				throw new System.Exception("获取到的列表缺乏必要项");
			}
			Loader.Output = output;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("Quilt 官方源版本列表解析失败（" + jObject.ToString() + "）", ex2);
		}
	}

	private static void DlLabyModListMain(ModLoader.LoaderTask<int, DlLabyModListResult> Loader)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		object obj = ModBase.Setup.Get("ToolDownloadVersion");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlLabyModListResult>, int>> obj2 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlLabyModListResult>, int>>();
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLabyModListResult>, int>(DlLabyModListOfficialLoader, 30));
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLabyModListResult>, int>(DlLabyModListOfficialLoader, 60));
			DlSourceLoader(Loader, obj2, Loader.IsForceRestarting);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlLabyModListResult>, int>> obj3 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlLabyModListResult>, int>>();
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLabyModListResult>, int>(DlLabyModListOfficialLoader, 5));
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLabyModListResult>, int>(DlLabyModListOfficialLoader, 35));
			DlSourceLoader(Loader, obj3, Loader.IsForceRestarting);
		}
		else
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlLabyModListResult>, int>> obj4 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlLabyModListResult>, int>>();
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLabyModListResult>, int>(DlLabyModListOfficialLoader, 60));
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLabyModListResult>, int>(DlLabyModListOfficialLoader, 60));
			DlSourceLoader(Loader, obj4, Loader.IsForceRestarting);
		}
	}

	private static void DlLabyModListOfficialMain(ModLoader.LoaderTask<int, DlLabyModListResult> Loader)
	{
		JObject value;
		using (HttpResponseHandler httpResponseHandler = HttpRequestBuilder.Create("https://releases.r2.labymod.net/api/v1/manifest/production/latest.json", HttpMethod.Get).WithHttpVersionOption(HttpVersion.Version20).SendAsync(throwIfNotSuccess: true)
			.Result)
		{
			value = (JObject)ModBase.GetJson(httpResponseHandler.AsStringContent());
		}
		JObject value2;
		using (HttpResponseHandler httpResponseHandler2 = HttpRequestBuilder.Create("https://releases.r2.labymod.net/api/v1/manifest/snapshot/latest.json", HttpMethod.Get).WithHttpVersionOption(HttpVersion.Version20).SendAsync(throwIfNotSuccess: true)
			.Result)
		{
			value2 = (JObject)ModBase.GetJson(httpResponseHandler2.AsStringContent());
		}
		JObject jObject = new JObject();
		jObject.Add("production", value);
		jObject.Add("snapshot", value2);
		try
		{
			DlLabyModListResult dlLabyModListResult = default(DlLabyModListResult);
			dlLabyModListResult.Value = jObject;
			DlLabyModListResult output = dlLabyModListResult;
			if (output.Value["production"]["labyModVersion"] == null || output.Value["snapshot"]["labyModVersion"] == null)
			{
				throw new System.Exception("获取到的列表缺乏必要项");
			}
			Loader.Output = output;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("LabyMod 版本列表解析失败（" + jObject.ToString() + "）", ex2);
		}
	}

	public static object DlModRequest(string Url, bool IsJson = false)
	{
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		List<KeyValuePair<string, int>> val = new List<KeyValuePair<string, int>>();
		string text = DlSourceModGet(Url);
		if (Operators.CompareString(text, Url, false) != 0)
		{
			object obj = ModBase.Setup.Get("ToolDownloadMod");
			if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
			{
				val.Add(new KeyValuePair<string, int>(text, 5));
				val.Add(new KeyValuePair<string, int>(text, 10));
				val.Add(new KeyValuePair<string, int>(Url, 15));
			}
			else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
			{
				val.Add(new KeyValuePair<string, int>(Url, 5));
				val.Add(new KeyValuePair<string, int>(text, 5));
				val.Add(new KeyValuePair<string, int>(Url, 15));
				val.Add(new KeyValuePair<string, int>(text, 10));
			}
			else
			{
				val.Add(new KeyValuePair<string, int>(Url, 5));
				val.Add(new KeyValuePair<string, int>(Url, 15));
				val.Add(new KeyValuePair<string, int>(text, 10));
			}
		}
		string text2 = "";
		System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, int>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, int>>);
		try
		{
			enumerator = val.GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, int> current = enumerator.Current;
				try
				{
					return ModNet.NetGetCodeByRequestOnce(current.Key, Encoding.UTF8, checked(current.Value * 1000), IsJson, "", UseBrowserUserAgent: true);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					if (!ModBase.ContainsF(ex2.Message, "mcimirror"))
					{
						text2 = text2 + ex2.Message + "\r\n";
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		throw new System.Exception(text2);
	}

	public static string DlModRequest(string Url, string Method, string Data, string ContentType, bool allowMirror = false)
	{
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		List<KeyValuePair<string, int>> val = new List<KeyValuePair<string, int>>();
		string text = DlSourceModGet(Url);
		if (Operators.CompareString(text, Url, false) != 0)
		{
			object obj = (allowMirror ? ModBase.Setup.Get("ToolDownloadMod") : ((object)2));
			if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
			{
				val.Add(new KeyValuePair<string, int>(text, 5));
				val.Add(new KeyValuePair<string, int>(text, 10));
				val.Add(new KeyValuePair<string, int>(Url, 15));
			}
			else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
			{
				val.Add(new KeyValuePair<string, int>(Url, 5));
				val.Add(new KeyValuePair<string, int>(text, 5));
				val.Add(new KeyValuePair<string, int>(Url, 15));
				val.Add(new KeyValuePair<string, int>(text, 10));
			}
			else
			{
				val.Add(new KeyValuePair<string, int>(Url, 5));
				val.Add(new KeyValuePair<string, int>(Url, 15));
				val.Add(new KeyValuePair<string, int>(text, 10));
			}
		}
		string text2 = "";
		System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, int>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, int>>);
		try
		{
			enumerator = val.GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, int> current = enumerator.Current;
				try
				{
					return ModNet.NetRequestOnce(current.Key, Method, Data, ContentType, checked(current.Value * 1000));
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					if (!ModBase.ContainsF(ex2.Message, "mcimirror"))
					{
						text2 = text2 + ex2.Message + "\r\n";
					}
					ProjectData.ClearProjectError();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		throw new System.Exception(text2);
	}

	public static System.Collections.Generic.IEnumerable<string> DlSourceOrder(System.Collections.Generic.IEnumerable<string> OfficialUrls, System.Collections.Generic.IEnumerable<string> MirrorUrls)
	{
		if (!DlSourcePreferMojang)
		{
			return Enumerable.Union<string>(MirrorUrls, OfficialUrls);
		}
		return Enumerable.Union<string>(OfficialUrls, MirrorUrls);
	}

	public static System.Collections.Generic.IEnumerable<string> DlVersionListOrder(System.Collections.Generic.IEnumerable<string> OfficialUrls, System.Collections.Generic.IEnumerable<string> MirrorUrls)
	{
		if (!DlVersionListPreferMojang)
		{
			return Enumerable.Union<string>(MirrorUrls, OfficialUrls);
		}
		return Enumerable.Union<string>(OfficialUrls, MirrorUrls);
	}

	public static System.Collections.Generic.IEnumerable<string> DlSourceAssetsGet(string Original)
	{
		Original = Original.Replace("http://resources.download.minecraft.net", "https://resources.download.minecraft.net");
		return DlSourceOrder(new string[] { Original }, new string[] { Original.Replace("https://piston-data.mojang.com", "https://bmclapi2.bangbang93.com/assets").Replace("https://piston-meta.mojang.com", "https://bmclapi2.bangbang93.com/assets").Replace("https://resources.download.minecraft.net", "https://bmclapi2.bangbang93.com/assets") });
	}

	public static System.Collections.Generic.IEnumerable<string> DlSourceLibraryGet(string Original)
	{
		if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "minecraftforge", "fabricmc", "neoforged" }, (Func<string, bool>)([SpecialName] (string k) => Original.Contains(k))))
		{
			return new string[2]
			{
				Original.Replace("https://piston-data.mojang.com", "https://bmclapi2.bangbang93.com/maven").Replace("https://piston-meta.mojang.com", "https://bmclapi2.bangbang93.com/maven").Replace("https://libraries.minecraft.net", "https://bmclapi2.bangbang93.com/maven")
					.Replace("https://zkitefly.github.io/unlisted-versions-of-minecraft", "https://alist.8mi.tech/d/mirror/unlisted-versions-of-minecraft/Auto"),
				Original.Replace("https://piston-data.mojang.com", "https://bmclapi2.bangbang93.com/libraries").Replace("https://piston-meta.mojang.com", "https://bmclapi2.bangbang93.com/libraries").Replace("https://libraries.minecraft.net", "https://bmclapi2.bangbang93.com/libraries")
					.Replace("https://zkitefly.github.io/unlisted-versions-of-minecraft", "https://alist.8mi.tech/d/mirror/unlisted-versions-of-minecraft/Auto")
			};
		}
		return DlSourceOrder(new string[] { Original }, new string[3]
		{
			Original.Replace("https://piston-data.mojang.com", "https://bmclapi2.bangbang93.com/maven").Replace("https://piston-meta.mojang.com", "https://bmclapi2.bangbang93.com/maven").Replace("https://libraries.minecraft.net", "https://bmclapi2.bangbang93.com/maven")
				.Replace("https://zkitefly.github.io/unlisted-versions-of-minecraft", "https://alist.8mi.tech/d/mirror/unlisted-versions-of-minecraft/Auto"),
			Original.Replace("https://piston-data.mojang.com", "https://bmclapi2.bangbang93.com/libraries").Replace("https://piston-meta.mojang.com", "https://bmclapi2.bangbang93.com/libraries").Replace("https://libraries.minecraft.net", "https://bmclapi2.bangbang93.com/libraries")
				.Replace("https://zkitefly.github.io/unlisted-versions-of-minecraft", "https://alist.8mi.tech/d/mirror/unlisted-versions-of-minecraft/Auto"),
			Original
		});
	}

	public static System.Collections.Generic.IEnumerable<string> DlSourceLauncherOrMetaGet(string Original)
	{
		if (Original == null)
		{
			throw new System.Exception("无对应的 json 下载地址");
		}
		return DlSourceOrder(new string[] { Original }, new string[2]
		{
			Original.Replace("https://piston-data.mojang.com", "https://bmclapi2.bangbang93.com").Replace("https://piston-meta.mojang.com", "https://bmclapi2.bangbang93.com").Replace("https://launcher.mojang.com", "https://bmclapi2.bangbang93.com")
				.Replace("https://launchermeta.mojang.com", "https://bmclapi2.bangbang93.com")
				.Replace("https://zkitefly.github.io/unlisted-versions-of-minecraft", "https://alist.8mi.tech/d/mirror/unlisted-versions-of-minecraft/Auto"),
			Original
		});
	}

	public static string DlSourceModGet(string Original)
	{
		if (Original.Contains("api.curseforge.com") && ModSecret.UseCfProxy)
		{
			return Original.Replace("https://api.curseforge.com", "https://pclpro.mtr.qzz.io/curseforge/".TrimEnd('/'));
		}
		return Original.Replace("https://api.modrinth.com", "https://mod.mcimirror.top/modrinth").Replace("https://api.curseforge.com", "https://mod.mcimirror.top/curseforge");
	}

	public static List<string> DlSourceModDownloadGet(string original)
	{
		List<string> val = new List<string>();
		string text = original.Replace("https://cdn.modrinth.com", "https://mod.mcimirror.top").Replace("https://edge.forgecdn.net", "https://mod.mcimirror.top");
		object obj = ModBase.Setup.Get("ToolDownloadMod");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			val.Add(text);
			val.Add(text);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			val.Add(original);
			val.Add(text);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)2, false))
		{
			val.Add(original);
			val.Add(original);
		}
		else
		{
			ModBase.Setup.Reset("ToolDownloadMod");
			val.Add(original);
		}
		val.Add(original);
		return val;
	}

	private static void DlSourceLoader<InputType, OutputType>(ModLoader.LoaderTask<InputType, OutputType> MainLoader, List<KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>> LoaderList, bool IsForceRestart = false)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		checked
		{
			System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>>);
			System.Collections.Generic.IEnumerator<KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>> enumerator2 = default(System.Collections.Generic.IEnumerator<KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>>);
			do
			{
				bool flag = true;
				try
				{
					enumerator = LoaderList.GetEnumerator();
					while (enumerator.MoveNext())
					{
						KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int> current = enumerator.Current;
						if (num == 0)
						{
							if (IsForceRestart || ((current.Key.Input == null) ^ (MainLoader.Input == null)))
							{
								continue;
							}
							if (current.Key.Input != null)
							{
								InputType reference = current.Key.Input;
								InputType val = default(InputType);
								if (val == null)
								{
								}
								if (!((object)reference).Equals((object)MainLoader.Input))
								{
									continue;
								}
							}
						}
						if (current.Key.State != ModBase.LoadState.Failed)
						{
							flag = false;
						}
						if (current.Key.State == ModBase.LoadState.Finished)
						{
							MainLoader.Output = current.Key.Output;
							DlSourceLoaderAbort<InputType, OutputType>(LoaderList);
							return;
						}
						if (flag && num < current.Value * 100)
						{
							num = current.Value * 100;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				if (num == 0)
				{
					Enumerable.First<KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>>((System.Collections.Generic.IEnumerable<KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>>)LoaderList).Key.Start(MainLoader.Input, IsForceRestart);
					try
					{
						enumerator2 = Enumerable.Skip<KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>>((System.Collections.Generic.IEnumerable<KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>>)LoaderList, 1).GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator2).MoveNext())
						{
							enumerator2.Current.Key.State = ModBase.LoadState.Waiting;
						}
					}
					finally
					{
						((System.IDisposable)enumerator2)?.Dispose();
					}
				}
				int num2 = LoaderList.Count - 1;
				for (int i = 0; i <= num2; i++)
				{
					if (num != LoaderList[i].Value * 100)
					{
						continue;
					}
					if (i < LoaderList.Count - 1 && !Enumerable.All<KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>>((System.Collections.Generic.IEnumerable<KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>>)LoaderList, (Func<KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>, bool>)([SpecialName] (KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int> l) => l.Key.State == ModBase.LoadState.Failed)))
					{
						LoaderList[i + 1].Key.Start(MainLoader.Input, IsForceRestart);
						break;
					}
					System.Exception ex = null;
					int num3 = LoaderList.Count - 1;
					for (int j = 0; j <= num3; j++)
					{
						LoaderList[j].Key.Input = default(InputType);
						if (LoaderList[j].Key.Error != null && (ex == null || LoaderList[j].Key.Error.Message.Contains("不可用")))
						{
							ex = LoaderList[j].Key.Error;
						}
					}
					if (ex == null)
					{
						ex = (System.Exception)new TimeoutException("下载源连接超时");
					}
					DlSourceLoaderAbort<InputType, OutputType>(LoaderList);
					throw ex;
				}
				Thread.Sleep(10);
				num++;
			}
			while (!MainLoader.IsAborted);
			DlSourceLoaderAbort<InputType, OutputType>(LoaderList);
		}
	}

	private static void DlSourceLoaderAbort<InputType, OutputType>(List<KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>> LoaderList)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int>>);
		try
		{
			enumerator = LoaderList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<ModLoader.LoaderTask<InputType, OutputType>, int> current = enumerator.Current;
				if (current.Key.State == ModBase.LoadState.Loading)
				{
					current.Key.Abort();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	private static void DlLegacyFabricListMain(ModLoader.LoaderTask<int, DlLegacyFabricListResult> Loader)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		object obj = ModBase.Setup.Get("ToolDownloadVersion");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlLegacyFabricListResult>, int>> obj2 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlLegacyFabricListResult>, int>>();
			obj2.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLegacyFabricListResult>, int>(DlLegacyFabricListOfficialLoader, 30));
			DlSourceLoader(Loader, obj2, Loader.IsForceRestarting);
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlLegacyFabricListResult>, int>> obj3 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlLegacyFabricListResult>, int>>();
			obj3.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLegacyFabricListResult>, int>(DlLegacyFabricListOfficialLoader, 5));
			DlSourceLoader(Loader, obj3, Loader.IsForceRestarting);
		}
		else
		{
			List<KeyValuePair<ModLoader.LoaderTask<int, DlLegacyFabricListResult>, int>> obj4 = new List<KeyValuePair<ModLoader.LoaderTask<int, DlLegacyFabricListResult>, int>>();
			obj4.Add(new KeyValuePair<ModLoader.LoaderTask<int, DlLegacyFabricListResult>, int>(DlLegacyFabricListOfficialLoader, 60));
			DlSourceLoader(Loader, obj4, Loader.IsForceRestarting);
		}
	}

	private static void DlLegacyFabricListOfficialMain(ModLoader.LoaderTask<int, DlLegacyFabricListResult> Loader)
	{
		JObject jObject = (JObject)ModNet.NetGetCodeByRequestRetry("https://meta.legacyfabric.net/v2/versions", null, "", IsJson: true);
		try
		{
			DlLegacyFabricListResult dlLegacyFabricListResult = default(DlLegacyFabricListResult);
			dlLegacyFabricListResult.IsOfficial = true;
			dlLegacyFabricListResult.SourceName = "LegacyFabric 官方源";
			dlLegacyFabricListResult.Value = jObject;
			DlLegacyFabricListResult output = dlLegacyFabricListResult;
			if (output.Value["game"] == null || output.Value["loader"] == null || output.Value["installer"] == null)
			{
				throw new System.Exception("获取到的列表缺乏必要项");
			}
			Loader.Output = output;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception("LegacyFabric 官方源版本列表解析失败（" + jObject.ToString() + "）", ex2);
		}
	}
}
