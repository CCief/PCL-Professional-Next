using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using LiteDB;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCL.Core.Utils;

namespace PCL;

[StandardModule]
public sealed class ModComp
{
	public enum CompType
	{
		Any = -1,
		Mod,
		ModPack,
		ResourcePack,
		Shader,
		DataPack,
		Plugin,
		Schematic,
		World
	}

	public enum CompLoaderType
	{
		Any = 0,
		Forge = 1,
		LiteLoader = 3,
		Fabric = 4,
		Quilt = 5,
		NeoForge = 6,
		Minecraft = 7,
		Canvas = 8,
		Iris = 9,
		OptiFine = 10,
		Vanilla = 11,
		LabyMod = 12
	}

	[Flags]
	public enum CompSourceType
	{
		CurseForge = 1,
		Modrinth = 2,
		Any = 3
	}

	public enum CompSortType
	{
		Default = 1,
		Relevance,
		Downloads,
		Follows,
		Newest,
		Updated
	}

	private class CompDatabaseEntry
	{
		[field: CompilerGenerated]
		public int WikiId
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string ChineseName
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string CurseForgeSlug
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string ModrinthSlug
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public CompDatabaseEntry()
		{
			ChineseName = "";
			CurseForgeSlug = null;
			ModrinthSlug = null;
		}

		public virtual string ToString()
		{
			return string.Concat(new string[7]
			{
				CurseForgeSlug,
				"&",
				ModrinthSlug,
				"|",
				Conversions.ToString(WikiId),
				"|",
				ChineseName
			});
		}
	}

	public class CompProject
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine_25_GetChineseDescriptionAsync : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncTaskMethodBuilder<string> _0024Builder;

			internal CompProject _0024VB_0024Me;

			internal string _0024VB_0024ResumableLocal_CacheFilePath_00240;

			internal string _0024VB_0024ResumableLocal_DescHash_00241;

			internal string _0024VB_0024ResumableLocal_result_00242;

			internal TaskAwaiter<object> _0024A0;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
				//IL_01d3: Expected O, but got Unknown
				//IL_01d5: Expected O, but got Unknown
				//IL_0138: Unknown result type (might be due to invalid IL or missing references)
				//IL_013d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0145: Unknown result type (might be due to invalid IL or missing references)
				//IL_0154: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
				//IL_0114: Unknown result type (might be due to invalid IL or missing references)
				//IL_0116: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				string result;
				try
				{
					_Closure_0024__25_002D0 closure_0024__25_002D = new _Closure_0024__25_002D0
					{
						_0024VB_0024Me = _0024VB_0024Me,
						_0024VB_0024Local_from = (_0024VB_0024Me.FromCurseForge ? "curseforge" : "modrinth")
					};
					if (num == -3 || num == 0)

					{
						goto IL_00d1;
					}
					_ = _0024VB_0024Me.FromCurseForge;
					_0024VB_0024ResumableLocal_result_00242 = null;
					_0024VB_0024ResumableLocal_DescHash_00241 = $"{_0024VB_0024Me.Id}{ModBase.GetStringMD5(_0024VB_0024Me.Description)}";
					_0024VB_0024ResumableLocal_CacheFilePath_00240 = $"{ModBase.PathTemp}Cache\\CompTranslation.ini";
					string text = ModBase.ReadIni(_0024VB_0024ResumableLocal_CacheFilePath_00240, _0024VB_0024ResumableLocal_DescHash_00241);
					if (string.IsNullOrWhiteSpace(text))
					{
						goto IL_00d1;
					}
					_0024VB_0024ResumableLocal_result_00242 = ModBase.Base64Decode(text);
					result = _0024VB_0024ResumableLocal_result_00242;
					goto end_IL_0007;
					IL_00d1:
					try
					{
						TaskAwaiter<object> awaiter;
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return;
						default:
							awaiter = System.Threading.Tasks.Task.Run<object>((Func<object>)closure_0024__25_002D._Lambda_0024__0).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = awaiter;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<object>, VB_0024StateMachine_25_GetChineseDescriptionAsync>(ref awaiter, ref _this);
								return;
							}
							break;
						case 0:
							num = (_0024State = -1);
							awaiter = _0024A0;
							_0024A0 = default(TaskAwaiter<object>);
							break;
						}
						object result2 = awaiter.GetResult();
						awaiter = default(TaskAwaiter<object>);
						object objectValue = RuntimeHelpers.GetObjectValue(result2);
						if (Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, (System.Type)null, "ContainsKey", new object[] { "translated" }, (string[])null, (System.Type[])null, (bool[])null))))
						{
							_0024VB_0024ResumableLocal_result_00242 = NewLateBinding.LateIndexGet(objectValue, new object[] { "translated" }, (string[])null).ToString();
							ModBase.WriteIni(_0024VB_0024ResumableLocal_CacheFilePath_00240, _0024VB_0024ResumableLocal_DescHash_00241, ModBase.Base64Encode(_0024VB_0024ResumableLocal_result_00242));
						}
					}
					catch (HttpRequestException val)
					{
						ProjectData.SetProjectError((System.Exception)val);
						HttpRequestException val2 = val;
						if (!((System.Exception)(object)val2).Message.Contains("404"))
						{
							ModBase.Log((System.Exception)(object)val2, "获取中文描述时出现错误", ModBase.LogLevel.Hint);
							ProjectData.ClearProjectError();
							goto end_IL_01cd;
						}
						ModMain.MyMsgBox("当前资源的简介暂无译文", "获取译文失败", "我知道了");
						result = null;
						ProjectData.ClearProjectError();
						goto end_IL_0007;
						end_IL_01cd:;
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "获取中文描述时出现错误", ModBase.LogLevel.Hint);
						ProjectData.ClearProjectError();
					}
					result = _0024VB_0024ResumableLocal_result_00242;
					end_IL_0007:;
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception exception = ex3;
					_0024State = -2;
					_0024Builder.SetException(exception);
					ProjectData.ClearProjectError();
					return;
				}
				num = (_0024State = -2);
				_0024Builder.SetResult(result);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_0024Builder.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		internal sealed class _Closure_0024__25_002D0
		{
			public string _0024VB_0024Local_from;

			public CompProject _0024VB_0024Me;

			[SpecialName]
			internal object _Lambda_0024__0()
			{
				return ModNet.NetGetCodeByRequestOnce($"https://mod.mcimirror.top/translate/{_0024VB_0024Local_from}/{_0024VB_0024Me.Id}", Encoding.UTF8, 30000, IsJson: true);
			}
		}

		public readonly bool FromCurseForge;

		public readonly CompType Type;

		public readonly string Slug;

		public readonly string Id;

		public readonly List<int> CurseForgeFileIds;

		public readonly string RawName;

		public readonly string Description;

		public readonly string Website;

		public readonly System.DateTime? LastUpdate;

		public readonly int DownloadCount;

		public readonly List<CompLoaderType> ModLoaders;

		public readonly List<string> Tags;

		public string LogoUrl;

		public readonly List<int> GameVersions;

		private bool LoadedDatabase;

		private CompDatabaseEntry _DatabaseEntry;

		private CompDatabaseEntry DatabaseEntry
		{
			get
			{
				if (!LoadedDatabase)
				{
					LoadedDatabase = true;
					if (Type == CompType.Mod || Type == CompType.DataPack)
					{
						_DatabaseEntry = GetCompWikiEntryBySlug(Slug);
					}
				}
				return _DatabaseEntry;
			}
			set
			{
				LoadedDatabase = true;
				_DatabaseEntry = value;
			}
		}

		public int WikiId
		{
			get
			{
				if (DatabaseEntry != null)
				{
					return DatabaseEntry.WikiId;
				}
				return 0;
			}
		}

		public string TranslatedName
		{
			get
			{
				if (DatabaseEntry != null && Operators.CompareString(DatabaseEntry.ChineseName, "", false) != 0)
				{
					return DatabaseEntry.ChineseName;
				}
				return RawName;
			}
		}

		public System.Threading.Tasks.Task<string> ChineseDescription => GetChineseDescriptionAsync();

		[AsyncStateMachine(typeof(VB_0024StateMachine_25_GetChineseDescriptionAsync))]
		private async System.Threading.Tasks.Task<string> GetChineseDescriptionAsync()
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			string text = (FromCurseForge ? "curseforge" : "modrinth");
			_ = FromCurseForge;
			string text2 = null;
			string key = $"{Id}{ModBase.GetStringMD5(Description)}";
			string fileName = $"{ModBase.PathTemp}Cache\\CompTranslation.ini";
			string text3 = ModBase.ReadIni(fileName, key);
			if (!string.IsNullOrWhiteSpace(text3))
			{
				return ModBase.Base64Decode(text3);
			}
			try
			{
				object objectValue = RuntimeHelpers.GetObjectValue(await System.Threading.Tasks.Task.Run<object>((Func<object>)([SpecialName] () => ModNet.NetGetCodeByRequestOnce($"https://mod.mcimirror.top/translate/{text}/{Id}", Encoding.UTF8, 30000, IsJson: true))));
				if (Conversions.ToBoolean(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, (System.Type)null, "ContainsKey", new object[] { "translated" }, (string[])null, (System.Type[])null, (bool[])null))))
				{
					text2 = NewLateBinding.LateIndexGet(objectValue, new object[] { "translated" }, (string[])null).ToString();
					ModBase.WriteIni(fileName, key, ModBase.Base64Encode(text2));
				}
			}
			catch (HttpRequestException val)
			{
				ProjectData.SetProjectError((System.Exception)val);
				HttpRequestException val2 = val;
				if (((System.Exception)(object)val2).Message.Contains("404"))
				{
					ModMain.MyMsgBox("当前资源的简介暂无译文", "获取译文失败", "我知道了");
					string result = null;
					ProjectData.ClearProjectError();
					return result;
				}
				ModBase.Log((System.Exception)(object)val2, "获取中文描述时出现错误", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "获取中文描述时出现错误", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
			return text2;
		}

		public CompProject(JObject Data)
		{
			//IL_055b: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
			LastUpdate = null;
			LogoUrl = null;
			LoadedDatabase = false;
			_DatabaseEntry = null;
			if (Data.ContainsKey("Tags"))
			{
				FromCurseForge = (string?)Data["DataSource"] == "CurseForge";
				Type = (CompType)Data["Type"].ToObject<int>();
				Slug = (string?)Data["Slug"];
				Id = (string?)Data["Id"];
				if (Data.ContainsKey("CurseForgeFileIds"))
				{
					CurseForgeFileIds = Enumerable.ToList<int>(Enumerable.Select<JToken, int>((System.Collections.Generic.IEnumerable<JToken>)(JArray)Data["CurseForgeFileIds"], (Func<JToken, int>)([SpecialName] (JToken t) => t.ToObject<int>())));
				}
				RawName = (string?)Data["RawName"];
				Description = (string?)Data["Description"];
				Website = (string?)Data["Website"];
				if (Data.ContainsKey("LastUpdate"))
				{
					LastUpdate = (System.DateTime?)Data["LastUpdate"];
				}
				DownloadCount = (int)Data["DownloadCount"];
				if (Data.ContainsKey("ModLoaders"))
				{
					ModLoaders = Enumerable.ToList<CompLoaderType>(Enumerable.Select<JToken, CompLoaderType>((System.Collections.Generic.IEnumerable<JToken>)(JArray)Data["ModLoaders"], (Func<JToken, CompLoaderType>)([SpecialName] (JToken t) => (CompLoaderType)t.ToObject<int>())));
				}
				else
				{
					ModLoaders = new List<CompLoaderType>();
				}
				Tags = Enumerable.ToList<string>(Enumerable.Select<JToken, string>((System.Collections.Generic.IEnumerable<JToken>)(JArray)Data["Tags"], (Func<JToken, string>)([SpecialName] (JToken t) => t.ToString())));
				if (Data.ContainsKey("LogoUrl"))
				{
					LogoUrl = (string?)Data["LogoUrl"];
				}
				if (Data.ContainsKey("GameVersions"))
				{
					GameVersions = Enumerable.ToList<int>(Enumerable.Select<JToken, int>((System.Collections.Generic.IEnumerable<JToken>)(JArray)Data["GameVersions"], (Func<JToken, int>)([SpecialName] (JToken t) => t.ToObject<int>())));
				}
				else
				{
					GameVersions = new List<int>();
				}
			}
			else
			{
				FromCurseForge = Data.ContainsKey("summary");
				if (FromCurseForge)
				{
					Id = (string?)Data["id"];
					Slug = (string?)Data["slug"];
					RawName = (string?)Data["name"];
					Description = (string?)Data["summary"];
					Website = Data["links"]["websiteUrl"].ToString().TrimEnd('/');
					LastUpdate = (System.DateTime?)Data["dateReleased"];
					DownloadCount = (int)Data["downloadCount"];
					if (Enumerable.Count<JToken>((System.Collections.Generic.IEnumerable<JToken>)Data["logo"]) > 0)
					{
						if (Data["logo"]["thumbnailUrl"] == null || (string?)Data["logo"]["thumbnailUrl"] == "")
						{
							LogoUrl = (string?)Data["logo"]["url"];
						}
						else
						{
							LogoUrl = (string?)Data["logo"]["thumbnailUrl"];
						}
					}
					if (Website.Contains("/mc-mods/") || Website.Contains("/mod/"))
					{
						Type = CompType.Mod;
					}
					else if (Website.Contains("/modpacks/"))
					{
						Type = CompType.ModPack;
					}
					else if (Website.Contains("/resourcepacks/"))
					{
						Type = CompType.ResourcePack;
					}
					else if (Website.Contains("/texture-packs/"))
					{
						Type = CompType.ResourcePack;
					}
					else if (Website.Contains("/shaders/"))
					{
						Type = CompType.Shader;
					}
					else if (Website.Contains("/worlds/"))
					{
						Type = CompType.World;
					}
					else
					{
						Type = CompType.DataPack;
					}
					ModLoaders = new List<CompLoaderType>();
					List<KeyValuePair<int, List<string>>> val = new List<KeyValuePair<int, List<string>>>();
					System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
					try
					{
						enumerator = ((System.Collections.Generic.IEnumerable<JToken>)(Data["latestFiles"] ?? new JArray())).GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator).MoveNext())
						{
							JToken current = enumerator.Current;
							CompFile compFile = new CompFile((JObject)current, Type);
							if (compFile.Available)
							{
								ModLoaders.AddRange((System.Collections.Generic.IEnumerable<CompLoaderType>)compFile.ModLoaders);
								List<string> val2 = current["gameVersions"].ToObject<List<string>>();
								if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2, (Func<string, bool>)([SpecialName] (string v) => PCLVerCompat.StartsWithVerF(v, "1.", ic: false))))
								{
									val.Add(new KeyValuePair<int, List<string>>((int)current["id"], val2));
								}
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
						enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)(Data["latestFilesIndexes"] ?? new JArray())).GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator2).MoveNext())
						{
							JToken current2 = enumerator2.Current;
							if (PCLVerCompat.StartsWithVerF(current2["gameVersion"].ToString(), "1.", ic: false))
							{
								val.Add(new KeyValuePair<int, List<string>>((int)current2["fileId"], Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)new string[] { current2["gameVersion"].ToString() })));
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator2)?.Dispose();
					}
					CurseForgeFileIds = Enumerable.ToList<int>(Enumerable.Distinct<int>(Enumerable.Select<KeyValuePair<int, List<string>>, int>((System.Collections.Generic.IEnumerable<KeyValuePair<int, List<string>>>)val, (Func<KeyValuePair<int, List<string>>, int>)([SpecialName] (KeyValuePair<int, List<string>> f) => f.Key))));
					GameVersions = Enumerable.ToList<int>((System.Collections.Generic.IEnumerable<int>)Enumerable.OrderByDescending<int, int>(Enumerable.Distinct<int>(Enumerable.Where<int>(Enumerable.Select<string, int>(Enumerable.Where<string>(Enumerable.SelectMany<KeyValuePair<int, List<string>>, string>((System.Collections.Generic.IEnumerable<KeyValuePair<int, List<string>>>)val, (Func<KeyValuePair<int, List<string>>, System.Collections.Generic.IEnumerable<string>>)([SpecialName] (KeyValuePair<int, List<string>> f) => (System.Collections.Generic.IEnumerable<string>)f.Value)), (Func<string, bool>)([SpecialName] (string v) => PCLVerCompat.StartsWithVerF(v, "1.", ic: false))), (Func<string, int>)([SpecialName] (string v) => PCLVerCompat.VerToInt(v))), (Func<int, bool>)([SpecialName] (int v) => v > 0))), (Func<int, int>)([SpecialName] (int v) => v)));
					ModLoaders = Enumerable.ToList<CompLoaderType>((System.Collections.Generic.IEnumerable<CompLoaderType>)Enumerable.OrderBy<CompLoaderType, int>(Enumerable.Distinct<CompLoaderType>((System.Collections.Generic.IEnumerable<CompLoaderType>)ModLoaders), (Func<CompLoaderType, int>)([SpecialName] (CompLoaderType t) => (int)t)));
					Tags = new List<string>();
					System.Collections.Generic.IEnumerator<int> enumerator3 = default(System.Collections.Generic.IEnumerator<int>);
					try
					{
						enumerator3 = ((System.Collections.Generic.IEnumerable<int>)Enumerable.OrderByDescending<int, int>(Enumerable.Distinct<int>(Enumerable.Select<JToken, int>((System.Collections.Generic.IEnumerable<JToken>)(Data["categories"] ?? new JArray()), (Func<JToken, int>)([SpecialName] (JToken t) => (int)t["id"]))), (Func<int, int>)([SpecialName] (int c) => c))).GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator3).MoveNext())
						{
							switch (enumerator3.Current)
							{
							case 406:
								Tags.Add("世界元素");
								break;
							case 407:
								Tags.Add("生物群系");
								break;
							case 410:
								Tags.Add("维度");
								break;
							case 408:
								Tags.Add("矿物/资源");
								break;
							case 409:
								Tags.Add("天然结构");
								break;
							case 412:
								Tags.Add("科技");
								break;
							case 415:
								Tags.Add("管道/物流");
								break;
							case 4843:
								Tags.Add("自动化");
								break;
							case 417:
								Tags.Add("能源");
								break;
							case 4558:
								Tags.Add("红石");
								break;
							case 436:
								Tags.Add("食物/烹饪");
								break;
							case 416:
								Tags.Add("农业");
								break;
							case 414:
								Tags.Add("运输");
								break;
							case 420:
								Tags.Add("仓储");
								break;
							case 419:
								Tags.Add("魔法");
								break;
							case 422:
								Tags.Add("冒险");
								break;
							case 424:
								Tags.Add("装饰");
								break;
							case 411:
								Tags.Add("生物");
								break;
							case 434:
								Tags.Add("装备");
								break;
							case 423:
								Tags.Add("信息显示");
								break;
							case 435:
								Tags.Add("服务器");
								break;
							case 5191:
								Tags.Add("改良");
								break;
							case 421:
								Tags.Add("支持库");
								break;
							case 4484:
								Tags.Add("多人");
								break;
							case 4479:
								Tags.Add("硬核");
								break;
							case 4483:
								Tags.Add("战斗");
								break;
							case 4478:
								Tags.Add("任务");
								break;
							case 4472:
								Tags.Add("科技");
								break;
							case 4473:
								Tags.Add("魔法");
								break;
							case 4475:
								Tags.Add("冒险");
								break;
							case 4476:
								Tags.Add("探索");
								break;
							case 4477:
								Tags.Add("小游戏");
								break;
							case 4471:
								Tags.Add("科幻");
								break;
							case 4736:
								Tags.Add("空岛");
								break;
							case 5128:
								Tags.Add("原版改良");
								break;
							case 4487:
								Tags.Add("FTB");
								break;
							case 4480:
								Tags.Add("基于地图");
								break;
							case 4481:
								Tags.Add("轻量");
								break;
							case 4482:
								Tags.Add("大型");
								break;
							case 403:
								Tags.Add("原版风");
								break;
							case 400:
								Tags.Add("写实风");
								break;
							case 401:
								Tags.Add("现代风");
								break;
							case 402:
								Tags.Add("中世纪");
								break;
							case 399:
								Tags.Add("蒸汽朋克");
								break;
							case 5244:
								Tags.Add("含字体");
								break;
							case 404:
								Tags.Add("动态效果");
								break;
							case 4465:
								Tags.Add("兼容 Mod");
								break;
							case 393:
								Tags.Add("16x");
								break;
							case 394:
								Tags.Add("32x");
								break;
							case 395:
								Tags.Add("64x");
								break;
							case 396:
								Tags.Add("128x");
								break;
							case 397:
								Tags.Add("256x");
								break;
							case 398:
								Tags.Add("超高清");
								break;
							case 5193:
								Tags.Add("数据包");
								break;
							case 6553:
								Tags.Add("写实风");
								break;
							case 6554:
								Tags.Add("幻想风");
								break;
							case 6555:
								Tags.Add("原版风");
								break;
							case 6948:
								Tags.Add("冒险");
								break;
							case 6949:
								Tags.Add("幻想");
								break;
							case 6950:
								Tags.Add("支持库");
								break;
							case 6952:
								Tags.Add("魔法");
								break;
							case 6946:
								Tags.Add("Mod 相关");
								break;
							case 6951:
								Tags.Add("科技");
								break;
							case 6953:
								Tags.Add("实用");
								break;
							case 248:
								Tags.Add("冒险");
								break;
							case 249:
								Tags.Add("创造");
								break;
							case 250:
								Tags.Add("小游戏");
								break;
							case 251:
								Tags.Add("跑酷");
								break;
							case 252:
								Tags.Add("解谜");
								break;
							case 253:
								Tags.Add("生存");
								break;
							case 4464:
								Tags.Add("Mod 世界");
								break;
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator3)?.Dispose();
					}
				}
				else
				{
					Id = (string?)(Data["project_id"] ?? Data["id"]);
					Slug = (string?)Data["slug"];
					RawName = (string?)Data["title"];
					Description = (string?)Data["description"];
					LastUpdate = (System.DateTime?)Data["date_modified"];
					DownloadCount = (int)Data["downloads"];
					LogoUrl = (string?)Data["icon_url"];
					if (Operators.CompareString(LogoUrl, "", false) == 0)
					{
						LogoUrl = null;
					}
					Website = string.Format("https://modrinth.com/{0}/{1}", (object)Data["project_type"], (object)Slug);
					GameVersions = Enumerable.ToList<int>((System.Collections.Generic.IEnumerable<int>)Enumerable.OrderByDescending<int, int>(Enumerable.Distinct<int>(Enumerable.Where<int>(Enumerable.Select<string, int>(Enumerable.Where<string>(Enumerable.Select<JToken, string>((System.Collections.Generic.IEnumerable<JToken>)(((JArray)(Data["game_versions"] ?? Data["versions"])) ?? new JArray()), (Func<JToken, string>)([SpecialName] (JToken v) => v.ToString())), (Func<string, bool>)([SpecialName] (string v) => PCLVerCompat.StartsWithVerF(v, "1.", ic: false))), (Func<string, int>)([SpecialName] (string v) => PCLVerCompat.VerToInt(v))), (Func<int, bool>)([SpecialName] (int v) => v > 0))), (Func<int, int>)([SpecialName] (int v) => v)));
					switch (Data["project_type"].ToString())
					{
					case "modpack":
						Type = CompType.ModPack;
						break;
					case "resourcepack":
						Type = CompType.ResourcePack;
						break;
					case "shader":
						Type = CompType.Shader;
						break;
					default:
						Type = CompType.Mod;
						break;
					}
					Tags = new List<string>();
					ModLoaders = new List<CompLoaderType>();
					if (Data?["loaders"] != null)
					{
						System.Collections.Generic.IEnumerator<string> enumerator4 = default(System.Collections.Generic.IEnumerator<string>);
						try
						{
							enumerator4 = Enumerable.Select<JToken, string>((System.Collections.Generic.IEnumerable<JToken>)Data["loaders"], (Func<JToken, string>)([SpecialName] (JToken t) => t.ToString())).GetEnumerator();
							while (((System.Collections.IEnumerator)enumerator4).MoveNext())
							{
								switch (enumerator4.Current)
								{
								case "forge":
									ModLoaders.Add(CompLoaderType.Forge);
									break;
								case "fabric":
									ModLoaders.Add(CompLoaderType.Fabric);
									break;
								case "quilt":
									ModLoaders.Add(CompLoaderType.Quilt);
									break;
								case "neoforge":
									ModLoaders.Add(CompLoaderType.NeoForge);
									break;
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator4)?.Dispose();
						}
					}
					System.Collections.Generic.IEnumerator<string> enumerator5 = default(System.Collections.Generic.IEnumerator<string>);
					try
					{
						enumerator5 = Enumerable.Select<JToken, string>((System.Collections.Generic.IEnumerable<JToken>)Data["categories"], (Func<JToken, string>)([SpecialName] (JToken t) => t.ToString())).GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator5).MoveNext())
						{
							switch (enumerator5.Current)
							{
							case "forge":
								ModLoaders.Add(CompLoaderType.Forge);
								break;
							case "fabric":
								ModLoaders.Add(CompLoaderType.Fabric);
								break;
							case "quilt":
								ModLoaders.Add(CompLoaderType.Quilt);
								break;
							case "neoforge":
								ModLoaders.Add(CompLoaderType.NeoForge);
								break;
							case "datapack":
								Type = CompType.DataPack;
								break;
							case "technology":
								Tags.Add("科技");
								break;
							case "magic":
								Tags.Add("魔法");
								break;
							case "adventure":
								Tags.Add("冒险");
								break;
							case "utility":
								Tags.Add("实用");
								break;
							case "optimization":
								Tags.Add("性能优化");
								break;
							case "vanilla-like":
								Tags.Add("原版风");
								break;
							case "realistic":
								Tags.Add("写实风");
								break;
							case "worldgen":
								Tags.Add("世界元素");
								break;
							case "food":
								Tags.Add("食物/烹饪");
								break;
							case "game-mechanics":
								Tags.Add("游戏机制");
								break;
							case "transportation":
								Tags.Add("运输");
								break;
							case "storage":
								Tags.Add("仓储");
								break;
							case "decoration":
								if (Type != CompType.ResourcePack)
								{
									Tags.Add("装饰");
								}
								break;
							case "mobs":
								if (Type != CompType.ResourcePack)
								{
									Tags.Add("生物");
								}
								break;
							case "equipment":
								if (Type != CompType.ResourcePack)
								{
									Tags.Add("装备");
								}
								break;
							case "social":
								Tags.Add("服务器");
								break;
							case "library":
								Tags.Add("支持库");
								break;
							case "multiplayer":
								Tags.Add("多人");
								break;
							case "challenging":
								Tags.Add("硬核");
								break;
							case "combat":
								Tags.Add("战斗");
								break;
							case "quests":
								Tags.Add("任务");
								break;
							case "kitchen-sink":
								Tags.Add("水槽包");
								break;
							case "lightweight":
								Tags.Add("轻量");
								break;
							case "simplistic":
								Tags.Add("简洁");
								break;
							case "tweaks":
								Tags.Add("改良");
								break;
							case "8x-":
								Tags.Add("极简");
								break;
							case "16x":
								Tags.Add("16x");
								break;
							case "32x":
								Tags.Add("32x");
								break;
							case "48x":
								Tags.Add("48x");
								break;
							case "64x":
								Tags.Add("64x");
								break;
							case "128x":
								Tags.Add("128x");
								break;
							case "256x":
								Tags.Add("256x");
								break;
							case "512x+":
								Tags.Add("超高清");
								break;
							case "audio":
								Tags.Add("含声音");
								break;
							case "fonts":
								Tags.Add("含字体");
								break;
							case "models":
								Tags.Add("含模型");
								break;
							case "gui":
								Tags.Add("含 UI");
								break;
							case "locale":
								Tags.Add("含语言");
								break;
							case "core-shaders":
								Tags.Add("核心着色器");
								break;
							case "modded":
								Tags.Add("兼容 Mod");
								break;
							case "fantasy":
								Tags.Add("幻想风");
								break;
							case "semi-realistic":
								Tags.Add("半写实风");
								break;
							case "cartoon":
								Tags.Add("卡通风");
								break;
							case "colored-lighting":
								Tags.Add("彩色光照");
								break;
							case "path-tracing":
								Tags.Add("路径追踪");
								break;
							case "pbr":
								Tags.Add("PBR");
								break;
							case "reflections":
								Tags.Add("反射");
								break;
							case "iris":
								Tags.Add("Iris");
								break;
							case "optifine":
								Tags.Add("OptiFine");
								break;
							case "vanilla":
								Tags.Add("原版可用");
								break;
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator5)?.Dispose();
					}
				}
				if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)Tags))
				{
					Tags.Add("其他");
				}
				Tags.Sort();
				ModLoaders.Sort();
			}
			CompProjectCache[Id] = this;
		}

		public JObject ToJson()
		{
			JObject jObject = new JObject();
			jObject["DataSource"] = (FromCurseForge ? "CurseForge" : "Modrinth");
			jObject["Type"] = (int)Type;
			jObject["Slug"] = Slug;
			jObject["Id"] = Id;
			if (CurseForgeFileIds != null)
			{
				jObject["CurseForgeFileIds"] = new JArray(CurseForgeFileIds);
			}
			jObject["RawName"] = RawName;
			jObject["Description"] = Description;
			jObject["Website"] = Website;
			if (LastUpdate.HasValue)
			{
				jObject["LastUpdate"] = LastUpdate;
			}
			jObject["DownloadCount"] = DownloadCount;
			if (ModLoaders != null && Enumerable.Any<CompLoaderType>((System.Collections.Generic.IEnumerable<CompLoaderType>)ModLoaders))
			{
				jObject["ModLoaders"] = new JArray(Enumerable.Select<CompLoaderType, int>((System.Collections.Generic.IEnumerable<CompLoaderType>)ModLoaders, (Func<CompLoaderType, int>)([SpecialName] (CompLoaderType m) => (int)m)));
			}
			jObject["Tags"] = new JArray(Tags);
			if (!string.IsNullOrEmpty(LogoUrl))
			{
				jObject["LogoUrl"] = LogoUrl;
			}
			if (Enumerable.Any<int>((System.Collections.Generic.IEnumerable<int>)GameVersions))
			{
				jObject["GameVersions"] = new JArray(GameVersions);
			}
			jObject["CacheTime"] = System.DateTime.Now;
			return jObject;
		}

		public MyCompItem ToCompItem(bool ShowMcVersionDesc, bool ShowLoaderDesc)
		{
			//IL_0388: Unknown result type (might be due to invalid IL or missing references)
			//IL_038d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0433: Unknown result type (might be due to invalid IL or missing references)
			//IL_0455: Unknown result type (might be due to invalid IL or missing references)
			//IL_047b: Unknown result type (might be due to invalid IL or missing references)
			//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0574: Unknown result type (might be due to invalid IL or missing references)
			//IL_0582: Unknown result type (might be due to invalid IL or missing references)
			checked
			{
				string text;
				if (GameVersions == null || !Enumerable.Any<int>((System.Collections.Generic.IEnumerable<int>)GameVersions))
				{
					text = "仅快照版本";
				}
				else
				{
					List<string> val = new List<string>();
					bool flag = false;
					int num = GameVersions.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						int num2 = GameVersions[i];
						int num3 = GameVersions[i];
						if (num2 < 10)
						{
							if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val) && !flag)
							{
								break;
							}
							flag = true;
						}
						int num4 = i + 1;
						int num5 = GameVersions.Count - 1;
						for (int j = num4; j <= num5 && GameVersions[j] == num3 - 1; j++)
						{
							num3 = GameVersions[j];
							i = j;
						}
						if (num2 == num3)
						{
							val.Add("" + PCLVerCompat.VerStr(num2));
							continue;
						}
						if (ModDownloadLib.McVersionHighest > -1 && num2 >= ModDownloadLib.McVersionHighest)
						{
							if (num3 < 10)
							{
								val.Clear();
								val.Add("全版本");
								break;
							}
							val.Add("" + PCLVerCompat.VerStr(num3) + "+");
							continue;
						}
						if (num3 < 10)
						{
							val.Add("" + PCLVerCompat.VerStr(num2) + "-");
							break;
						}
						if (num2 - num3 == 1)
						{
							val.Add("" + PCLVerCompat.VerStr(num2) + ", " + PCLVerCompat.VerStr(num3));
						}
						else
						{
							val.Add("" + PCLVerCompat.VerStr(num2) + "~" + PCLVerCompat.VerStr(num3));
						}
					}
					text = ModBase.Join((System.Collections.IEnumerable)val, ", ");
				}
				List<CompLoaderType> val2 = new List<CompLoaderType>((System.Collections.Generic.IEnumerable<CompLoaderType>)ModLoaders);
				if (Conversions.ToBoolean(ModBase.Setup.Get("ToolDownloadIgnoreQuilt")))
				{
					val2.Remove(CompLoaderType.Quilt);
				}
				string text2;
				string text3;
				switch (val2.Count)
				{
				case 0:
					if (ModLoaders.Count == 1)
					{
						text2 = "仅 " + ((System.Enum)Enumerable.Single<CompLoaderType>((System.Collections.Generic.IEnumerable<CompLoaderType>)ModLoaders)).ToString();
						text3 = ((System.Enum)Enumerable.Single<CompLoaderType>((System.Collections.Generic.IEnumerable<CompLoaderType>)ModLoaders)).ToString();
					}
					else
					{
						text2 = "未知";
						text3 = "";
					}
					break;
				case 1:
					text2 = "仅 " + ((System.Enum)Enumerable.Single<CompLoaderType>((System.Collections.Generic.IEnumerable<CompLoaderType>)val2)).ToString();
					text3 = ((System.Enum)Enumerable.Single<CompLoaderType>((System.Collections.Generic.IEnumerable<CompLoaderType>)val2)).ToString();
					break;
				default:
				{
					int num6 = (Enumerable.Any<int>((System.Collections.Generic.IEnumerable<int>)GameVersions) ? Enumerable.Max((System.Collections.Generic.IEnumerable<int>)GameVersions) : 99);
					if (Conversions.ToBoolean((object)(ModLoaders.Contains(CompLoaderType.Forge) && (num6 < 14 || ModLoaders.Contains(CompLoaderType.Fabric)) && (num6 < 20 || ModLoaders.Contains(CompLoaderType.NeoForge)) && (num6 < 14 || ModLoaders.Contains(CompLoaderType.Quilt) || Conversions.ToBoolean(ModBase.Setup.Get("ToolDownloadIgnoreQuilt"))))))
					{
						text2 = "任意";
						text3 = "";
					}
					else
					{
						text2 = ModBase.Join((System.Collections.IEnumerable)val2, " / ");
						text3 = ModBase.Join((System.Collections.IEnumerable)val2, " / ");
					}
					break;
				}
				}
				MyCompItem myCompItem = new MyCompItem();
				((FrameworkElement)myCompItem).Tag = this;
				myCompItem.Logo = GetControlLogo();
				MyCompItem myCompItem2 = myCompItem;
				myCompItem2.ShowFavoriteBtn = CompFavorites.IsFavourite(Id);
				KeyValuePair<string, string> controlTitle = GetControlTitle(HasModLoaderDescription: true);
				myCompItem2.Title = controlTitle.Key;
				if (Operators.CompareString(controlTitle.Value, "", false) == 0)
				{
					((Panel)(StackPanel)((FrameworkElement)myCompItem2.LabTitleRaw).Parent).Children.Remove((UIElement)(object)myCompItem2.LabTitleRaw);
				}
				else
				{
					myCompItem2.SubTitle = controlTitle.Value;
				}
				myCompItem2.Tags = Tags;
				myCompItem2.Description = Description.Replace("\r", "").Replace("\n", "");
				if (!ShowMcVersionDesc && !ShowLoaderDesc)
				{
					((Panel)(Grid)((FrameworkElement)myCompItem2.PathVersion).Parent).Children.Remove((UIElement)(object)myCompItem2.PathVersion);
					((Panel)(Grid)((FrameworkElement)myCompItem2.LabVersion).Parent).Children.Remove((UIElement)(object)myCompItem2.LabVersion);
					myCompItem2.ColumnVersion1.Width = new GridLength(0.0);
					myCompItem2.ColumnVersion2.MaxWidth = 0.0;
					myCompItem2.ColumnVersion3.Width = new GridLength(0.0);
				}
				else if (ShowMcVersionDesc && ShowLoaderDesc)
				{
					myCompItem2.LabVersion.Text = ((Operators.CompareString(text3, "", false) == 0) ? "" : (text3 + " ")) + text;
				}
				else if (ShowMcVersionDesc)
				{
					myCompItem2.LabVersion.Text = text;
				}
				else
				{
					myCompItem2.LabVersion.Text = text2;
				}
				myCompItem2.LabSource.Text = (FromCurseForge ? "CurseForge" : "Modrinth");
				if (LastUpdate.HasValue)
				{
					TextBlock labTime = myCompItem2.LabTime;
					System.DateTime? lastUpdate = LastUpdate;
					System.DateTime now = System.DateTime.Now;
					labTime.Text = TimeUtils.GetTimeSpanString((lastUpdate.HasValue ? new TimeSpan?(lastUpdate.GetValueOrDefault() - now) : null).Value, isShortForm: true);
				}
				else
				{
					((UIElement)myCompItem2.LabTime).Visibility = (Visibility)2;
					myCompItem2.ColumnTime1.Width = new GridLength(0.0);
					myCompItem2.ColumnTime2.Width = new GridLength(0.0);
					myCompItem2.ColumnTime3.Width = new GridLength(0.0);
				}
				myCompItem2.LabDownload.Text = Conversions.ToString((DownloadCount > 100000000) ? (Conversions.ToString(Math.Round((double)DownloadCount / 100000000.0, 2)) + " 亿") : ((DownloadCount > 100000) ? (Conversions.ToString(Math.Floor((double)DownloadCount / 10000.0)) + " 万") : ((object)DownloadCount)));
				return myCompItem2;
			}
		}

		public MyListItem ToListItem()
		{
			MyListItem obj = new MyListItem
			{
				Title = TranslatedName,
				Info = Description.Replace("\r", "").Replace("\n", ""),
				Logo = LogoUrl,
				Tags = Tags
			};
			((FrameworkElement)obj).Tag = this;
			return obj;
		}

		public string GetControlLogo()
		{
			if (string.IsNullOrEmpty(LogoUrl))
			{
				return ModBase.PathImage + "Icons/NoIcon.png";
			}
			return LogoUrl;
		}

		public KeyValuePair<string, string> GetControlTitle(bool HasModLoaderDescription)
		{
			//IL_0579: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
			string text = RawName;
			List<string> val2;
			if (Operators.CompareString(TranslatedName, RawName, false) == 0)
			{
				List<string> val = Enumerable.ToList<string>(Enumerable.Where<string>(Enumerable.Select<string, string>((System.Collections.Generic.IEnumerable<string>)TranslatedName.Split(new string[] { " | ", " - ", "(", ")", "[", "]", "{", "}" }, (StringSplitOptions)1), (Func<string, string>)([SpecialName] (string s) => s.Trim(" /\\".ToCharArray()))), (Func<string, bool>)([SpecialName] (string w) => !string.IsNullOrEmpty(w))));
				if (val.Count != 1)
				{
					val2 = new List<string>();
					List<string> val3 = new List<string>();
					System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
					try
					{
						enumerator = val.GetEnumerator();
						while (enumerator.MoveNext())
						{
							string current = enumerator.Current;
							string text2 = current.ToLower();
							if (Operators.CompareString(current.ToUpper(), current, false) == 0 && Operators.CompareString(current, "FPS", false) != 0 && Operators.CompareString(current, "HUD", false) != 0)
							{
								val2.Add(current);
							}
							else if ((text2.Contains("forge") || text2.Contains("fabric") || text2.Contains("quilt")) && !ModBase.RegexCheck(text2.Replace("forge", "").Replace("fabric", "").Replace("quilt", ""), "[a-z]+", (RegexOptions)0))
							{
								val2.Add(current);
							}
							else
							{
								val3.Add(current);
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator).Dispose();
					}
					if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val3) && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2))
					{
						text = ModBase.Join((System.Collections.IEnumerable)val3, " - ");
						goto IL_03ce;
					}
				}
				goto IL_0571;
			}
			text = ModBase.BeforeFirst(ModBase.BeforeFirst(TranslatedName, " ("), " - ");
			string text3 = "";
			if (ModBase.AfterLast(TranslatedName, ")").Contains(" - "))
			{
				text3 = ModBase.AfterLast(ModBase.AfterLast(TranslatedName, ")"), " - ");
			}
			string text4 = TranslatedName;
			if (Operators.CompareString(text3, "", false) != 0)
			{
				text4 = text4.Replace(" - " + text3, "");
			}
			string text5 = text4.Replace(text, "");
			char[] array = new char[3];
			text4 = text5.Trim(array);
			val2 = Enumerable.ToList<string>(Enumerable.Where<string>(Enumerable.Select<string, string>((System.Collections.Generic.IEnumerable<string>)text4.Split(new string[] { " | ", " - ", "(", ")", "[", "]", "{", "}" }, (StringSplitOptions)1), (Func<string, string>)([SpecialName] (string s) => s.Trim(" /".ToCharArray()))), (Func<string, bool>)([SpecialName] (string w) => !string.IsNullOrEmpty(w))));
			if (val2.Count > 1 && !Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2, (Func<string, bool>)([SpecialName] (string s) => s.ToLower().Contains("forge") || s.ToLower().Contains("fabric") || s.ToLower().Contains("quilt"))) && (val2.Count != 2 || Operators.CompareString(Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)val2).ToUpper(), Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)val2), false) != 0))
			{
				List<string> obj = new List<string>();
				obj.Add(text4);
				val2 = obj;
			}
			if (Operators.CompareString(text3, "", false) != 0)
			{
				val2.Add(text3);
			}
			goto IL_03ce;
			IL_03ce:
			val2 = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val2));
			string text6 = "";
			if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2))
			{
				goto IL_0571;
			}
			System.Collections.Generic.IEnumerator<string> enumerator2 = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator2 = val2.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					string text7 = enumerator2.Current;
					bool flag = text7.ToLower().Contains("forge") || text7.ToLower().Contains("fabric") || text7.ToLower().Contains("quilt");
					if ((HasModLoaderDescription || !flag) && (text7.Length >= 16 || !text7.ToLower().Contains("fabric") || !text7.ToLower().Contains("forge")))
					{
						if (flag && !text7.Contains("版") && text7.ToLower().Replace("forge", "").Replace("fabric", "")
							.Replace("quilt", "")
							.Length <= 3)
						{
							text7 = ModBase.Capitalize(text7.Replace("Edition", "").Replace("edition", "").Trim()) + " 版";
						}
						text7 = text7.Replace("forge", "Forge").Replace("neo", "Neo").Replace("fabric", "Fabric")
							.Replace("quilt", "Quilt");
						text6 = text6 + "  |  " + text7.Trim();
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			goto IL_0577;
			IL_0571:
			text6 = "";
			goto IL_0577;
			IL_0577:
			return new KeyValuePair<string, string>(text, text6);
		}

		public bool IsLike(CompProject Project)
		{
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			if (Operators.CompareString(Id, Project.Id, false) == 0)
			{
				return true;
			}
			VB_0024AnonymousDelegate_5<string, string> vB_0024AnonymousDelegate_ = [SpecialName] (string Data) =>
			{
				//IL_0000: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Expected O, but got Unknown
				StringBuilder val = new StringBuilder();
				System.Collections.Generic.IEnumerator<char> enumerator = default(System.Collections.Generic.IEnumerator<char>);
				try
				{
					enumerator = Enumerable.Where<char>((System.Collections.Generic.IEnumerable<char>)Data, (Func<char, bool>)([SpecialName] (char c) => char.IsLetterOrDigit(c))).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						char current = enumerator.Current;
						val.Append(current);
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				return val.ToString().ToLower();
			};
			if (FromCurseForge == Project.FromCurseForge)
			{
				return false;
			}
			if (ModLoaders.Count != Project.ModLoaders.Count || Enumerable.Any<CompLoaderType>(Enumerable.Except<CompLoaderType>((System.Collections.Generic.IEnumerable<CompLoaderType>)ModLoaders, (System.Collections.Generic.IEnumerable<CompLoaderType>)Project.ModLoaders)))
			{
				return false;
			}
			if (Type != CompType.Shader && (GameVersions.Count != Project.GameVersions.Count || Enumerable.Any<int>(Enumerable.Except<int>((System.Collections.Generic.IEnumerable<int>)GameVersions, (System.Collections.Generic.IEnumerable<int>)Project.GameVersions))))
			{
				return false;
			}
			if (LastUpdate.HasValue && Project.LastUpdate.HasValue)
			{
				System.DateTime? lastUpdate = LastUpdate;
				System.DateTime? lastUpdate2 = Project.LastUpdate;
				TimeSpan value = ((lastUpdate.HasValue & lastUpdate2.HasValue) ? new TimeSpan?(lastUpdate.GetValueOrDefault() - lastUpdate2.GetValueOrDefault()) : null).Value;
				if (Math.Abs(value.TotalDays) > 7.0)
				{
					return false;
				}
			}
			if (Operators.CompareString(TranslatedName, Project.TranslatedName, false) == 0 || Operators.CompareString(RawName, Project.RawName, false) == 0 || Operators.CompareString(Description, Project.Description, false) == 0 || Operators.CompareString(vB_0024AnonymousDelegate_(Slug), vB_0024AnonymousDelegate_(Project.Slug), false) == 0)
			{
				ModBase.Log(string.Format("[Comp] 将 {0} ({1}) 与 {2} ({3}) 认定为相似工程", new object[] { RawName, Slug, Project.RawName, Project.Slug }));
				if (DatabaseEntry == null && Project.DatabaseEntry != null)
				{
					DatabaseEntry = Project.DatabaseEntry;
				}
				if (DatabaseEntry != null && Project.DatabaseEntry == null)
				{
					Project.DatabaseEntry = DatabaseEntry;
				}
				return true;
			}
			return false;
		}

		public virtual string ToString()
		{
			return $"{Id} ({Slug}): {RawName}";
		}

		public virtual bool Equals(object obj)
		{
			if (obj is CompProject compProject)
			{
				return Operators.CompareString(Id, compProject.Id, false) == 0;
			}
			return false;
		}

		public static bool operator ==(CompProject left, CompProject right)
		{
			return EqualityComparer<CompProject>.Default.Equals(left, right);
		}

		public static bool operator !=(CompProject left, CompProject right)
		{
			return !(left == right);
		}
	}

	public class CompProjectRequest
	{
		public CompProjectStorage Storage;

		public int TargetResultCount;

		public CompType Type;

		public string Tag;

		public CompLoaderType ModLoader;

		public string GameVersion;

		public string SearchText;

		public CompSourceType Source;

		public CompSortType Sort;

		public bool CanContinue
		{
			get
			{
				if (ModBase.StartsWithF(Tag, "/") || !((System.Enum)Source).HasFlag((System.Enum)CompSourceType.CurseForge))
				{
					Storage.CurseForgeTotal = 0;
				}
				if (ModBase.EndsWithF(Tag, "/") || !((System.Enum)Source).HasFlag((System.Enum)CompSourceType.Modrinth))
				{
					Storage.ModrinthTotal = 0;
				}
				if (Storage.CurseForgeTotal == -1 || Storage.ModrinthTotal == -1)
				{
					return true;
				}
				return Storage.CurseForgeOffset < Storage.CurseForgeTotal || Storage.ModrinthOffset < Storage.ModrinthTotal;
			}
		}

		public CompProjectRequest(CompType Type, CompProjectStorage Storage, int TargetResultCount)
		{
			Tag = "";
			ModLoader = CompLoaderType.Any;
			GameVersion = null;
			SearchText = null;
			Source = CompSourceType.Any;
			Sort = CompSortType.Default;
			this.Type = Type;
			this.Storage = Storage;
			this.TargetResultCount = TargetResultCount;
		}

		public string GetCurseForgeAddress()
		{
			if (!((System.Enum)Source).HasFlag((System.Enum)CompSourceType.CurseForge))
			{
				return null;
			}
			if (ModBase.StartsWithF(Tag, "/"))
			{
				Storage.CurseForgeTotal = 0;
			}
			if (Storage.CurseForgeTotal > -1 && Storage.CurseForgeTotal <= Storage.CurseForgeOffset)
			{
				return null;
			}
			string text = $"https://api.curseforge.com/v1/mods/search?gameId=432&sortOrder=desc&pageSize={40}";
			switch (Type)
			{
			case CompType.Mod:
				text += "&classId=6";
				break;
			case CompType.ModPack:
				text += "&classId=4471";
				break;
			case CompType.DataPack:
				text += "&classId=6945";
				break;
			case CompType.Shader:
				text += "&classId=6552";
				break;
			case CompType.ResourcePack:
				text += "&classId=12";
				break;
			case CompType.World:
				text += "&classId=17";
				break;
			}
			text = text + "&categoryId=" + ((Operators.CompareString(Tag, "", false) == 0) ? "0" : ModBase.BeforeFirst(Tag, "/"));
			if (ModLoader != 0)
			{
				text = text + "&modLoaderType=" + Conversions.ToString((int)ModLoader);
			}
			if (!string.IsNullOrEmpty(GameVersion))
			{
				text = text + "&gameVersion=" + GameVersion;
			}
			if (!string.IsNullOrEmpty(SearchText))
			{
				text = text + "&searchFilter=" + WebUtility.UrlEncode(SearchText);
			}
			if (Storage.CurseForgeOffset > 0)
			{
				text = text + "&index=" + Conversions.ToString(Storage.CurseForgeOffset);
			}
			return Sort switch
			{
				CompSortType.Relevance => text + "&sortField=4", 
				CompSortType.Downloads => text + "&sortField=6", 
				CompSortType.Follows => text + "&sortField=2", 
				CompSortType.Newest => text + "&sortField=11", 
				CompSortType.Updated => text + "&sortField=3", 
				_ => text + "&sortField=2", 
			};
		}

		public string GetModrinthAddress()
		{
			if (!((System.Enum)Source).HasFlag((System.Enum)CompSourceType.Modrinth))
			{
				return null;
			}
			if (ModBase.EndsWithF(Tag, "/"))
			{
				Storage.ModrinthTotal = 0;
			}
			if (Storage.ModrinthTotal > -1 && Storage.ModrinthTotal <= Storage.ModrinthOffset)
			{
				return null;
			}
			string text = $"https://api.modrinth.com/v2/search?limit={40}";
			text = Sort switch
			{
				CompSortType.Relevance => text + "&index=relevance", 
				CompSortType.Downloads => text + "&index=downloads", 
				CompSortType.Follows => text + "&index=follows", 
				CompSortType.Newest => text + "&index=newest", 
				CompSortType.Updated => text + "&index=updated", 
				_ => text + "&index=relevance", 
			};
			if (!string.IsNullOrEmpty(SearchText))
			{
				text = text + "&query=" + WebUtility.UrlEncode(SearchText);
			}
			if (Storage.ModrinthOffset > 0)
			{
				text = text + "&offset=" + Conversions.ToString(Storage.ModrinthOffset);
			}
			List<string> val = new List<string>();
			val.Add($"[\"project_type:{ModBase.GetStringFromEnum(Type).ToLower()}\"]");
			if (!string.IsNullOrEmpty(Tag))
			{
				val.Add(string.Format("[\"categories:'{0}'\"]", (object)ModBase.AfterLast(Tag, "/")));
			}
			if (ModLoader != 0)
			{
				val.Add($"[\"categories:'{ModBase.GetStringFromEnum(ModLoader).ToLower()}'\"]");
			}
			if (!string.IsNullOrEmpty(GameVersion))
			{
				val.Add($"[\"versions:'{GameVersion}'\"]");
			}
			return text + "&facets=[" + string.Join(",", (System.Collections.Generic.IEnumerable<string>)val) + "]";
		}

		public virtual bool Equals(object obj)
		{
			if (obj is CompProjectRequest compProjectRequest && Type == compProjectRequest.Type && TargetResultCount == compProjectRequest.TargetResultCount && Operators.CompareString(Tag, compProjectRequest.Tag, false) == 0 && ModLoader == compProjectRequest.ModLoader && Source == compProjectRequest.Source && Operators.CompareString(GameVersion, compProjectRequest.GameVersion, false) == 0 && Operators.CompareString(SearchText, compProjectRequest.SearchText, false) == 0)
			{
				return Sort == compProjectRequest.Sort;
			}
			return false;
		}

		public static bool operator ==(CompProjectRequest left, CompProjectRequest right)
		{
			return EqualityComparer<CompProjectRequest>.Default.Equals(left, right);
		}

		public static bool operator !=(CompProjectRequest left, CompProjectRequest right)
		{
			return !(left == right);
		}
	}

	public class CompProjectStorage
	{
		public int CurseForgeOffset;

		public int CurseForgeTotal;

		public int ModrinthOffset;

		public int ModrinthTotal;

		public List<CompProject> Results;

		public string ErrorMessage;

		public CompProjectStorage()
		{
			CurseForgeOffset = 0;
			CurseForgeTotal = -1;
			ModrinthOffset = 0;
			ModrinthTotal = -1;
			Results = new List<CompProject>();
			ErrorMessage = null;
		}
	}

	public enum CompFileStatus
	{
		Release = 1,
		Beta,
		Alpha
	}

	public class CompFile
	{
		public readonly CompType Type;

		public readonly bool FromCurseForge;

		public readonly string Id;

		public readonly string ProjectId;

		public string DisplayName;

		public readonly System.DateTime ReleaseDate;

		public readonly int DownloadCount;

		public readonly List<CompLoaderType> ModLoaders;

		public readonly List<string> GameVersions;

		public readonly CompFileStatus Status;

		public readonly string FileName;

		public List<string> DownloadUrls;

		public readonly string Hash;

		public readonly List<string> RawDependencies;

		public readonly List<string> RawOptionalDependencies;

		public readonly List<string> Dependencies;

		public readonly List<string> OptionalDependencies;

		public string StatusDescription => Status switch
		{
			CompFileStatus.Release => "正式版", 
			CompFileStatus.Beta => ModBase.ModeDebug ? "Beta 版" : "测试版", 
			_ => ModBase.ModeDebug ? "Alpha 版" : "早期测试版", 
		};

		public bool Available
		{
			get
			{
				if (FileName != null)
				{
					return DownloadUrls != null;
				}
				return false;
			}
		}

		public ModNet.NetFile ToNetFile(string LocalAddress)
		{
			return new ModNet.NetFile((System.Collections.Generic.IEnumerable<string>)DownloadUrls, LocalAddress + (ModBase.EndsWithF(LocalAddress, "\\") ? FileName : ""), new ModBase.FileChecker(-1L, -1L, Hash), UseBrowserUserAgent: true);
		}

		public CompFile(JObject Data, CompType DefaultType)
		{
			FileName = null;
			Hash = null;
			RawDependencies = new List<string>();
			RawOptionalDependencies = new List<string>();
			Dependencies = new List<string>();
			OptionalDependencies = new List<string>();
			Type = DefaultType;
			if (Data.ContainsKey("FromCurseForge"))
			{
				FromCurseForge = Data["FromCurseForge"].ToObject<bool>();
				Id = Data["Id"].ToString();
				DisplayName = Data["DisplayName"].ToString();
				ReleaseDate = Data["ReleaseDate"].ToObject<System.DateTime>();
				DownloadCount = Data["DownloadCount"].ToObject<int>();
				Status = (CompFileStatus)Data["Status"].ToObject<int>();
				if (Data.ContainsKey("FileName"))
				{
					FileName = Data["FileName"].ToString();
				}
				if (Data.ContainsKey("DownloadUrls"))
				{
					DownloadUrls = Data["DownloadUrls"].ToObject<List<string>>();
				}
				if (Data.ContainsKey("ModLoaders"))
				{
					ModLoaders = Data["ModLoaders"].ToObject<List<CompLoaderType>>();
				}
				if (Data.ContainsKey("Hash"))
				{
					Hash = Data["Hash"].ToString();
				}
				if (Data.ContainsKey("GameVersions"))
				{
					GameVersions = Data["GameVersions"].ToObject<List<string>>();
				}
				if (Data.ContainsKey("RawDependencies"))
				{
					RawDependencies = Data["RawDependencies"].ToObject<List<string>>();
				}
				if (Data.ContainsKey("Dependencies"))
				{
					Dependencies = Data["Dependencies"].ToObject<List<string>>();
				}
				if (Data.ContainsKey("RawOptionalDependencies"))
				{
					RawDependencies = Data["RawOptionalDependencies"].ToObject<List<string>>();
				}
				if (Data.ContainsKey("OptionalDependencies"))
				{
					Dependencies = Data["OptionalDependencies"].ToObject<List<string>>();
				}
				return;
			}
			FromCurseForge = Data.ContainsKey("gameId");
			if (FromCurseForge)
			{
				Id = (string?)Data["id"];
				ProjectId = (string?)Data["modId"];
				DisplayName = Data["displayName"].ToString().Replace("\t", "").Trim(' ');
				ReleaseDate = (System.DateTime)Data["fileDate"];
				Status = (CompFileStatus)Data["releaseType"].ToObject<int>();
				DownloadCount = (int)Data["downloadCount"];
				FileName = (string?)Data["fileName"];
				Hash = (string?)Enumerable.FirstOrDefault<JToken>((System.Collections.Generic.IEnumerable<JToken>)Enumerable.ToList<JToken>((System.Collections.Generic.IEnumerable<JToken>)(JArray)Data["hashes"]), (Func<JToken, bool>)([SpecialName] (JToken s) => s["algo"].ToObject<int>() == 1))?["value"];
				if (Hash == null)
				{
					Hash = (string?)Enumerable.FirstOrDefault<JToken>((System.Collections.Generic.IEnumerable<JToken>)Enumerable.ToList<JToken>((System.Collections.Generic.IEnumerable<JToken>)(JArray)Data["hashes"]), (Func<JToken, bool>)([SpecialName] (JToken s) => s["algo"].ToObject<int>() == 2))?["value"];
				}
				string text = Data["downloadUrl"].ToString();
				if (string.IsNullOrWhiteSpace(text))
				{
					text = $"https://edge.forgecdn.net/files/{Conversions.ToInteger(Id.ToString().Substring(0, 4))}/{Conversions.ToInteger(Id.ToString().Substring(4))}/{FileName}";
				}
				text = text.Replace(FileName, WebUtility.UrlEncode(FileName));
				text = text.Replace("+", "%20");
				DownloadUrls = ModDownload.DlSourceModDownloadGet(HandleCurseForgeDownloadUrls(text));
				if (Data.ContainsKey("dependencies"))
				{
					RawDependencies = Enumerable.ToList<string>(Enumerable.Select<JToken, string>(Enumerable.Where<JToken>((System.Collections.Generic.IEnumerable<JToken>)Data["dependencies"], (Func<JToken, bool>)([SpecialName] (JToken d) => d["relationType"].ToObject<int>() == 3 && d["modId"].ToObject<int>() != 306612 && d["modId"].ToObject<int>() != 634179)), (Func<JToken, string>)([SpecialName] (JToken d) => d["modId"].ToString())));
					RawOptionalDependencies = Enumerable.ToList<string>(Enumerable.Select<JToken, string>(Enumerable.Where<JToken>((System.Collections.Generic.IEnumerable<JToken>)Data["dependencies"], (Func<JToken, bool>)([SpecialName] (JToken d) => d["relationType"].ToObject<int>() == 2 && d["modId"].ToObject<int>() != 306612 && d["modId"].ToObject<int>() != 634179)), (Func<JToken, string>)([SpecialName] (JToken d) => d["modId"].ToString())));
				}
				List<string> val = Enumerable.ToList<string>(Enumerable.Select<JToken, string>((System.Collections.Generic.IEnumerable<JToken>)Data["gameVersions"], (Func<JToken, string>)([SpecialName] (JToken t) => t.ToString().Trim().ToLower())));
				GameVersions = Enumerable.ToList<string>(Enumerable.Select<string, string>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)val, (Func<string, bool>)([SpecialName] (string v) => PCLVerCompat.StartsWithVerF(v, "1.", ic: false))), (Func<string, string>)([SpecialName] (string v) => v.Replace("-snapshot", " 预览版"))));
				if (GameVersions.Count > 1)
				{
					GameVersions = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)ModBase.Sort((System.Collections.Generic.IList<string>)GameVersions, ModMinecraft.VersionSortBoolean));
					if (Type == CompType.ModPack)
					{
						List<string> obj = new List<string>();
						obj.Add(GameVersions[0]);
						GameVersions = obj;
					}
				}
				else if (GameVersions.Count == 1)
				{
					GameVersions = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)GameVersions);
				}
				else
				{
					List<string> obj2 = new List<string>();
					obj2.Add("未知版本");
					GameVersions = obj2;
				}
				ModLoaders = new List<CompLoaderType>();
				if (val.Contains("forge"))
				{
					ModLoaders.Add(CompLoaderType.Forge);
				}
				if (val.Contains("fabric"))
				{
					ModLoaders.Add(CompLoaderType.Fabric);
				}
				if (val.Contains("quilt"))
				{
					ModLoaders.Add(CompLoaderType.Quilt);
				}
				if (val.Contains("neoforge"))
				{
					ModLoaders.Add(CompLoaderType.NeoForge);
				}
				return;
			}
			Id = (string?)Data["id"];
			ProjectId = (string?)Data["project_id"];
			DisplayName = Data["name"].ToString().Replace("\t", "").Trim(' ');
			ReleaseDate = (System.DateTime)Data["date_published"];
			Status = ((Operators.CompareString(Data["version_type"].ToString(), "release", false) == 0) ? CompFileStatus.Release : ((Operators.CompareString(Data["version_type"].ToString(), "beta", false) == 0) ? CompFileStatus.Beta : CompFileStatus.Alpha));
			DownloadCount = (int)Data["downloads"];
			if (Enumerable.Any<JToken>((System.Collections.Generic.IEnumerable<JToken>)(JArray)Data["files"]))
			{
				JToken jToken = Data["files"][0];
				FileName = (string?)jToken["filename"];
				DownloadUrls = ModDownload.DlSourceModDownloadGet(jToken["url"].ToString());
				Hash = (string?)jToken["hashes"]["sha1"];
			}
			List<string> val2 = Enumerable.ToList<string>(Enumerable.Select<JToken, string>((System.Collections.Generic.IEnumerable<JToken>)Data["loaders"], (Func<JToken, string>)([SpecialName] (JToken v) => v.ToString())));
			ModLoaders = new List<CompLoaderType>();
			if (Type == CompType.Mod)
			{
				if (Enumerable.Any<string>(Enumerable.Intersect<string>((System.Collections.Generic.IEnumerable<string>)val2, (System.Collections.Generic.IEnumerable<string>)new string[] { "bukkit", "folia", "paper", "purpur", "spigot" })))
				{
					Type = CompType.Plugin;
				}
				if (val2.Contains("datapack"))
				{
					Type = CompType.DataPack;
				}
				if (val2.Contains("forge"))
				{
					ModLoaders.Add(CompLoaderType.Forge);
					Type = CompType.Mod;
				}
				if (val2.Contains("neoforge"))
				{
					ModLoaders.Add(CompLoaderType.NeoForge);
					Type = CompType.Mod;
				}
				if (val2.Contains("fabric"))
				{
					ModLoaders.Add(CompLoaderType.Fabric);
					Type = CompType.Mod;
				}
				if (val2.Contains("quilt"))
				{
					ModLoaders.Add(CompLoaderType.Quilt);
					Type = CompType.Mod;
				}
			}
			else if (Type == CompType.DataPack)
			{
				if (Enumerable.Any<string>(Enumerable.Intersect<string>((System.Collections.Generic.IEnumerable<string>)val2, (System.Collections.Generic.IEnumerable<string>)new string[] { "bukkit", "folia", "paper", "purpur", "spigot" })))
				{
					Type = CompType.Plugin;
				}
				if (val2.Contains("forge"))
				{
					ModLoaders.Add(CompLoaderType.Forge);
					Type = CompType.Mod;
				}
				if (val2.Contains("neoforge"))
				{
					ModLoaders.Add(CompLoaderType.NeoForge);
					Type = CompType.Mod;
				}
				if (val2.Contains("fabric"))
				{
					ModLoaders.Add(CompLoaderType.Fabric);
					Type = CompType.Mod;
				}
				if (val2.Contains("quilt"))
				{
					ModLoaders.Add(CompLoaderType.Quilt);
					Type = CompType.Mod;
				}
				if (val2.Contains("datapack"))
				{
					Type = CompType.DataPack;
				}
			}
			if (Data.ContainsKey("dependencies"))
			{
				RawDependencies = Enumerable.ToList<string>(Enumerable.Select<JToken, string>(Enumerable.Where<JToken>((System.Collections.Generic.IEnumerable<JToken>)Data["dependencies"], (Func<JToken, bool>)([SpecialName] (JToken d) => (string?)d["dependency_type"] == "required" && (string?)d["project_id"] != "P7dR8mSH" && (string?)d["project_id"] != "qvIfYCYJ" && d["project_id"].ToString().Length > 0)), (Func<JToken, string>)([SpecialName] (JToken d) => d["project_id"].ToString())));
				RawOptionalDependencies = Enumerable.ToList<string>(Enumerable.Select<JToken, string>(Enumerable.Where<JToken>((System.Collections.Generic.IEnumerable<JToken>)Data["dependencies"], (Func<JToken, bool>)([SpecialName] (JToken d) => (string?)d["dependency_type"] == "optional" && (string?)d["project_id"] != "P7dR8mSH" && (string?)d["project_id"] != "qvIfYCYJ" && d["project_id"].ToString().Length > 0)), (Func<JToken, string>)([SpecialName] (JToken d) => d["project_id"].ToString())));
			}
			List<string> val3 = Enumerable.ToList<string>(Enumerable.Select<JToken, string>((System.Collections.Generic.IEnumerable<JToken>)Data["game_versions"], (Func<JToken, string>)([SpecialName] (JToken t) => t.ToString().Trim().ToLower())));
			GameVersions = Enumerable.ToList<string>(Enumerable.Select<string, string>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)val3, (Func<string, bool>)([SpecialName] (string v) => PCLVerCompat.StartsWithVerF(v, "1.", ic: false) || PCLVerCompat.StartsWithVerF(v, "b1.", ic: false))), (Func<string, string>)([SpecialName] (string v) => (!v.Contains("-")) ? ((!PCLVerCompat.StartsWithVerF(v, "b1.", ic: false)) ? v : "远古版本") : (ModBase.BeforeFirst(v, "-") + " 预览版"))));
			if (GameVersions.Count > 1)
			{
				GameVersions = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)ModBase.Sort((System.Collections.Generic.IList<string>)GameVersions, ModMinecraft.VersionSortBoolean));
				if (Type == CompType.ModPack)
				{
					List<string> obj3 = new List<string>();
					obj3.Add(GameVersions[0]);
					GameVersions = obj3;
				}
			}
			else
			{
				if (GameVersions.Count == 1)
				{
					return;
				}
				if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val3, (Func<string, bool>)([SpecialName] (string v) => ModBase.RegexCheck(v, "[0-9]{2}w[0-9]{2}[a-z]{1}", (RegexOptions)0))))
				{
					GameVersions = Enumerable.ToList<string>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)val3, (Func<string, bool>)([SpecialName] (string v) => ModBase.RegexCheck(v, "[0-9]{2}w[0-9]{2}[a-z]{1}", (RegexOptions)0))));
				}
				else
				{
					List<string> obj4 = new List<string>();
					obj4.Add("未知版本");
					GameVersions = obj4;
				}
			}
		}

		public static string HandleCurseForgeDownloadUrls(string Url)
		{
			return Url.Replace("-service.overwolf.wtf", ".forgecdn.net").Replace("://media.", "://edge.").Replace("://mediafilez.", "://edge.");
		}

		public JObject ToJson()
		{
			JObject jObject = new JObject();
			jObject.Add("FromCurseForge", FromCurseForge);
			jObject.Add("Id", Id);
			jObject.Add("DisplayName", DisplayName);
			jObject.Add("ReleaseDate", ReleaseDate);
			jObject.Add("DownloadCount", DownloadCount);
			jObject.Add("ModLoaders", new JArray(Enumerable.Select<CompLoaderType, int>((System.Collections.Generic.IEnumerable<CompLoaderType>)ModLoaders, (Func<CompLoaderType, int>)([SpecialName] (CompLoaderType m) => (int)m))));
			jObject.Add("GameVersions", new JArray(GameVersions));
			jObject.Add("Status", (int)Status);
			if (FileName != null)
			{
				jObject.Add("FileName", FileName);
			}
			if (DownloadUrls != null)
			{
				jObject.Add("DownloadUrls", new JArray(DownloadUrls));
			}
			if (Hash != null)
			{
				jObject.Add("Hash", Hash);
			}
			jObject.Add("RawDependencies", new JArray(RawDependencies));
			jObject.Add("RawOptionalDependencies", new JArray(RawOptionalDependencies));
			jObject.Add("Dependencies", new JArray(Dependencies));
			jObject.Add("OptionalDependencies", new JArray(OptionalDependencies));
			return jObject;
		}

		public MyListItem ToListItem(MyListItem.ClickEventHandler OnClick, MyIconButton.ClickEventHandler OnSaveClick = null, bool BadDisplayName = false)
		{
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			string text = (BadDisplayName ? FileName : DisplayName);
			List<string> val = new List<string>();
			if (Operators.CompareString(text, ModBase.BeforeLast(FileName, "."), false) != 0)
			{
				val.Add(ModBase.BeforeLast(FileName, "."));
			}
			if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)Dependencies))
			{
				val.Add(Conversions.ToString(Dependencies.Count) + " 项前置");
			}
			if (Enumerable.All<string>((System.Collections.Generic.IEnumerable<string>)GameVersions, (Func<string, bool>)([SpecialName] (string v) => !ModMinecraft.IsVersionNameLikeRelease(v))))
			{
				val.Add(string.Format("游戏版本 {0}", (object)ModBase.Join((System.Collections.IEnumerable)GameVersions, "、")));
			}
			if (DownloadCount > 0)
			{
				val.Add("下载 " + ((DownloadCount > 100000) ? (Conversions.ToString(Math.Round((double)DownloadCount / 10000.0)) + " 万次") : (Conversions.ToString(DownloadCount) + " 次")));
			}
			val.Add("更新于 " + TimeUtils.GetTimeSpanString(ReleaseDate - System.DateTime.Now, isShortForm: false));
			if (Status != CompFileStatus.Release)
			{
				val.Add(StatusDescription);
			}
			MyListItem obj = new MyListItem
			{
				Title = text
			};
			((UIElement)obj).SnapsToDevicePixels = true;
			((FrameworkElement)obj).Height = 42.0;
			obj.Type = MyListItem.CheckType.Clickable;
			((FrameworkElement)obj).Tag = this;
			obj.Info = ModBase.Join((System.Collections.IEnumerable)val, "，");
			MyListItem myListItem = obj;
			switch (Status)
			{
			case CompFileStatus.Release:
				myListItem.Logo = ModBase.PathImage + "Icons/R.png";
				break;
			case CompFileStatus.Beta:
				myListItem.Logo = ModBase.PathImage + "Icons/B.png";
				break;
			default:
				myListItem.Logo = ModBase.PathImage + "Icons/A.png";
				break;
			}
			myListItem.Click += OnClick;
			if (OnSaveClick != null)
			{
				MyIconButton obj2 = new MyIconButton
				{
					Logo = "M819.392 0L1024 202.752v652.16a168.96 168.96 0 0 1-168.832 168.768h-104.192a47.296 47.296 0 0 1-10.752 0H283.776a47.232 47.232 0 0 1-10.752 0H168.832A168.96 168.96 0 0 1 0 854.912V168.768A168.96 168.96 0 0 1 168.832 0h650.56z m110.208 854.912V242.112l-149.12-147.776H168.896c-41.088 0-74.432 33.408-74.432 74.432v686.144c0 41.024 33.344 74.432 74.432 74.432h62.4v-190.528c0-33.408 27.136-60.544 60.544-60.544h440.448c33.408 0 60.544 27.136 60.544 60.544v190.528h62.4c41.088 0 74.432-33.408 74.432-74.432z m-604.032 74.432h372.864v-156.736H325.568v156.736z m403.52-596.48a47.168 47.168 0 1 1 0 94.336H287.872a47.168 47.168 0 1 1 0-94.336h441.216z m0-153.728a47.168 47.168 0 1 1 0 94.4H287.872a47.168 47.168 0 1 1 0-94.4h441.216z"
				};
				((FrameworkElement)obj2).ToolTip = "另存为";
				MyIconButton myIconButton = obj2;
				ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
				ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
				ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
				myIconButton.Click += OnSaveClick;
				myListItem.Buttons = new MyIconButton[] { myIconButton };
			}
			return myListItem;
		}

		public virtual string ToString()
		{
			return $"{Id}: {FileName}";
		}
	}

	public class CompFavorites
	{
		public class FavData
		{
			[field: CompilerGenerated]
			public string Name
			{
				[CompilerGenerated]
				get;
				[CompilerGenerated]
				set;
			}

			[field: CompilerGenerated]
			public string Id
			{
				[CompilerGenerated]
				get;
				[CompilerGenerated]
				set;
			}

			[field: CompilerGenerated]
			public List<string> Favs
			{
				[CompilerGenerated]
				get;
				[CompilerGenerated]
				set;
			}

			[field: CompilerGenerated]
			public Dictionary<string, string> Notes
			{
				[CompilerGenerated]
				get;
				[CompilerGenerated]
				set;
			}

			public FavData()
			{
				Favs = new List<string>();
				Notes = new Dictionary<string, string>();
			}
		}

		[Serializable]
		[CompilerGenerated]
		internal sealed class _Closure_0024__
		{
			public static readonly _Closure_0024__ _0024I;

			public static Func<CompProject, string> _0024I4_002D1;

			public static Func<KeyValuePair<string, string>, bool> _0024I9_002D0;

			public static Func<KeyValuePair<string, string>, string> _0024I9_002D1;

			public static Func<KeyValuePair<string, string>, string> _0024I9_002D2;

			static _Closure_0024__()
			{
				_0024I = new _Closure_0024__();
			}

			[SpecialName]
			internal string _Lambda_0024__4_002D1(CompProject p)
			{
				return p.Id;
			}

			[SpecialName]
			internal bool _Lambda_0024__9_002D0(KeyValuePair<string, string> n)
			{
				return !string.IsNullOrWhiteSpace(n.Value);
			}

			[SpecialName]
			internal string _Lambda_0024__9_002D1(KeyValuePair<string, string> n)
			{
				return n.Key;
			}

			[SpecialName]
			internal string _Lambda_0024__9_002D2(KeyValuePair<string, string> n)
			{
				return n.Value;
			}
		}

		[CompilerGenerated]
		internal sealed class _Closure_0024__3_002D0
		{
			public bool _0024VB_0024Local_HasFavs;

			public _Closure_0024__3_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_3;

			public _Closure_0024__3_002D0(_Closure_0024__3_002D0 arg0)
			{
				if (arg0 != null)
				{
					_0024VB_0024Local_HasFavs = arg0._0024VB_0024Local_HasFavs;
				}
			}

			[SpecialName]
			internal void _Lambda_0024__R1(object a0, RoutedEventArgs a1)
			{
				_Lambda_0024__0();
			}

			[SpecialName]
			internal void _Lambda_0024__0()
			{
				try
				{
					if (_0024VB_0024Local_HasFavs)
					{
						_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_i.Favs.Remove(_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Project.Id);
						ModMain.Hint($"已将 {_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Project.TranslatedName} 从 {_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_i.Name} 中删除", ModMain.HintType.Finish);
					}
					else
					{
						_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_i.Favs.Add(_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Project.Id);
						_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_i.Favs = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_i.Favs));
						ModMain.Hint($"已将 {_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Project.TranslatedName} 添加到 {_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_i.Name} 中", ModMain.HintType.Finish);
					}
					Save();
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "[CompFavorites] 改变收藏项出错");
					ProjectData.ClearProjectError();
				}
			}
		}

		[CompilerGenerated]
		internal sealed class _Closure_0024__3_002D1
		{
			public FavData _0024VB_0024Local_i;

			public _Closure_0024__3_002D2 _0024VB_0024NonLocal__0024VB_0024Closure_2;

			public _Closure_0024__3_002D1(_Closure_0024__3_002D1 arg0)
			{
				if (arg0 != null)
				{
					_0024VB_0024Local_i = arg0._0024VB_0024Local_i;
				}
			}
		}

		[CompilerGenerated]
		internal sealed class _Closure_0024__3_002D2
		{
			public CompProject _0024VB_0024Local_Project;

			public Action _0024VB_0024Local_ClosedCallBack;

			public _Closure_0024__3_002D2(_Closure_0024__3_002D2 arg0)
			{
				if (arg0 != null)
				{
					_0024VB_0024Local_Project = arg0._0024VB_0024Local_Project;
					_0024VB_0024Local_ClosedCallBack = arg0._0024VB_0024Local_ClosedCallBack;
				}
			}

			[SpecialName]
			internal void _Lambda_0024__R2(object a0, RoutedEventArgs a1)
			{
				_Lambda_0024__1();
			}

			[SpecialName]
			internal void _Lambda_0024__1()
			{
				Action obj = _0024VB_0024Local_ClosedCallBack;
				if (obj != null)
				{
					obj.Invoke();
				}
			}
		}

		[CompilerGenerated]
		internal sealed class _Closure_0024__4_002D0
		{
			public FavData _0024VB_0024Local_i;

			public _Closure_0024__4_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

			public _Closure_0024__4_002D0(_Closure_0024__4_002D0 arg0)
			{
				if (arg0 != null)
				{
					_0024VB_0024Local_i = arg0._0024VB_0024Local_i;
				}
			}

			[SpecialName]
			internal void _Lambda_0024__R3(object a0, RoutedEventArgs a1)
			{
				_Lambda_0024__0();
			}

			[SpecialName]
			internal void _Lambda_0024__0()
			{
				checked
				{
					try
					{
						int count = _0024VB_0024Local_i.Favs.Count;
						_0024VB_0024Local_i.Favs.AddRange(Enumerable.AsEnumerable<string>(Enumerable.Select<CompProject, string>((System.Collections.Generic.IEnumerable<CompProject>)_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Project, (Func<CompProject, string>)([SpecialName] (CompProject p) => p.Id))));
						_0024VB_0024Local_i.Favs = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)_0024VB_0024Local_i.Favs));
						Save();
						int num = _0024VB_0024Local_i.Favs.Count - count;
						int num2 = _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Project.Count - num;
						ModMain.Hint(string.Format("已将 {0} 个资源添加到 {1} 中{2}！", (object)num, (object)_0024VB_0024Local_i.Name, (object)((num2 > 0) ? $"，{num2} 个资源已添加" : "")), ModMain.HintType.Finish);
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "[CompFavorites] 改变收藏项出错");
						ProjectData.ClearProjectError();
					}
				}
			}
		}

		[CompilerGenerated]
		internal sealed class _Closure_0024__4_002D1
		{
			public List<CompProject> _0024VB_0024Local_Project;

			public Action _0024VB_0024Local_ClosedCallBack;

			public _Closure_0024__4_002D1(_Closure_0024__4_002D1 arg0)
			{
				if (arg0 != null)
				{
					_0024VB_0024Local_Project = arg0._0024VB_0024Local_Project;
					_0024VB_0024Local_ClosedCallBack = arg0._0024VB_0024Local_ClosedCallBack;
				}
			}

			[SpecialName]
			internal void _Lambda_0024__R4(object a0, RoutedEventArgs a1)
			{
				_Lambda_0024__2();
			}

			[SpecialName]
			internal void _Lambda_0024__2()
			{
				Action obj = _0024VB_0024Local_ClosedCallBack;
				if (obj != null)
				{
					obj.Invoke();
				}
			}
		}

		private static List<FavData> _FavoritesList;

		public static List<FavData> FavoritesList
		{
			get
			{
				if (_FavoritesList == null)
				{
					string json = Conversions.ToString(ModBase.Setup.Get("CompFavorites"));
					List<FavData> val = null;
					List<string> val2 = null;
					try
					{
						val2 = JArray.Parse(json).ToObject<List<string>>();
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ProjectData.ClearProjectError();
					}
					if (val2 != null)
					{
						val = new List<FavData>();
						val.Add(GetNewFav("默认", val2));
					}
					else
					{
						val = JArray.Parse(json).ToObject<List<FavData>>();
						if (val.Count == 0)
						{
							val.Add(GetNewFav("默认", null));
						}
					}
					_FavoritesList = val;
					Save();
				}
				return _FavoritesList;
			}
			set
			{
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0010: Unknown result type (might be due to invalid IL or missing references)
				_FavoritesList = value;
				System.Collections.Generic.IEnumerator<FavData> enumerator = default(System.Collections.Generic.IEnumerator<FavData>);
				try
				{
					enumerator = _FavoritesList.GetEnumerator();
					while (enumerator.MoveNext())
					{
						FavData current = enumerator.Current;
						current.Notes = Enumerable.ToDictionary<KeyValuePair<string, string>, string, string>(Enumerable.Where<KeyValuePair<string, string>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, string>>)current.Notes, (_Closure_0024__._0024I9_002D0 == null) ? (_Closure_0024__._0024I9_002D0 = [SpecialName] (KeyValuePair<string, string> n) => !string.IsNullOrWhiteSpace(n.Value)) : _Closure_0024__._0024I9_002D0), (_Closure_0024__._0024I9_002D1 == null) ? (_Closure_0024__._0024I9_002D1 = [SpecialName] (KeyValuePair<string, string> n) => n.Key) : _Closure_0024__._0024I9_002D1, (_Closure_0024__._0024I9_002D2 == null) ? (_Closure_0024__._0024I9_002D2 = [SpecialName] (KeyValuePair<string, string> n) => n.Value) : _Closure_0024__._0024I9_002D2);
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				JArray jArray = JArray.FromObject(_FavoritesList);
				ModBase.Setup.Set("CompFavorites", jArray.ToString(Formatting.None));
			}
		}

		public static string GetShareCode(List<string> Data)
		{
			try
			{
				return new JArray(Data).ToString(Formatting.None);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "[CompFavorites] 生成分享出错");
				ProjectData.ClearProjectError();
			}
			return "";
		}

		public static List<string> GetIdsByShareCode(string Code)
		{
			try
			{
				return JArray.Parse(Code).ToObject<List<string>>();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "[CompFavorites] 通过分享获取 ID 出错");
				ProjectData.ClearProjectError();
			}
			return new List<string>();
		}

		public static void ShowMenu(CompProject Project, UIElement Pos, Action ClosedCallBack = null)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Expected O, but got Unknown
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			_Closure_0024__3_002D2 arg = default(_Closure_0024__3_002D2);
			_Closure_0024__3_002D2 CS_0024_003C_003E8__locals0 = new _Closure_0024__3_002D2(null);
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Project = Project;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_ClosedCallBack = ClosedCallBack;
			ContextMenu val = new ContextMenu();
			System.Collections.Generic.IEnumerator<FavData> enumerator = default(System.Collections.Generic.IEnumerator<FavData>);
			try
			{
				enumerator = FavoritesList.GetEnumerator();
				_Closure_0024__3_002D1 closure_0024__3_002D = default(_Closure_0024__3_002D1);
				_Closure_0024__3_002D0 closure_0024__3_002D2 = default(_Closure_0024__3_002D0);
				while (enumerator.MoveNext())
				{
					closure_0024__3_002D = new _Closure_0024__3_002D1(closure_0024__3_002D);
					closure_0024__3_002D._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals0;
					closure_0024__3_002D._0024VB_0024Local_i = enumerator.Current;
					closure_0024__3_002D2 = new _Closure_0024__3_002D0(closure_0024__3_002D2);
					closure_0024__3_002D2._0024VB_0024NonLocal__0024VB_0024Closure_3 = closure_0024__3_002D;
					MyMenuItem myMenuItem = new MyMenuItem();
					((FrameworkElement)myMenuItem).MaxWidth = 240.0;
					closure_0024__3_002D2._0024VB_0024Local_HasFavs = closure_0024__3_002D2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_i.Favs.Contains(closure_0024__3_002D2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Project.Id);
					if (closure_0024__3_002D2._0024VB_0024Local_HasFavs)
					{
						((HeaderedItemsControl)myMenuItem).Header = $"取消收藏 {closure_0024__3_002D2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_i.Name}";
						((MenuItem)myMenuItem).Icon = "M700.856 155.543c-74.769 0-144.295 72.696-190.046 127.26-45.737-54.576-115.247-127.26-190.056-127.26-134.79 0-244.443 105.78-244.443 235.799 0 77.57 39.278 131.988 70.845 175.713C238.908 694.053 469.62 852.094 479.39 858.757c9.41 6.414 20.424 9.629 31.401 9.629 11.006 0 21.998-3.215 31.398-9.63 9.782-6.662 240.514-164.703 332.238-291.701 31.587-43.724 70.874-98.143 70.874-175.713-0.001-130.02-109.656-235.8-244.445-235.8z m0 0";
					}
					else
					{
						((HeaderedItemsControl)myMenuItem).Header = $"收藏到 {closure_0024__3_002D2._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_i.Name}";
						((MenuItem)myMenuItem).Icon = "M512 896a42.666667 42.666667 0 0 1-30.293333-12.373333l-331.52-331.946667a224.426667 224.426667 0 0 1 0-315.733333 223.573333 223.573333 0 0 1 315.733333 0L512 282.026667l46.08-46.08a223.573333 223.573333 0 0 1 315.733333 0 224.426667 224.426667 0 0 1 0 315.733333l-331.52 331.946667A42.666667 42.666667 0 0 1 512 896zM308.053333 256a136.533333 136.533333 0 0 0-97.28 40.106667 138.24 138.24 0 0 0 0 194.986666L512 792.746667l301.226667-301.653334a138.24 138.24 0 0 0 0-194.986666 141.653333 141.653333 0 0 0-194.56 0l-76.373334 76.8a42.666667 42.666667 0 0 1-60.586666 0L405.333333 296.106667A136.533333 136.533333 0 0 0 308.053333 256z";
					}
					((MenuItem)myMenuItem).Click += new RoutedEventHandler(closure_0024__3_002D2._Lambda_0024__R1);
					((ItemsControl)val).Items.Add((object)myMenuItem);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			val.Closed += (RoutedEventHandler)([SpecialName] (object a0, RoutedEventArgs a1) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__1();
			});
			val.Placement = (PlacementMode)2;
			val.PlacementTarget = Pos;
			val.IsOpen = true;
		}

		public static void ShowMenu(List<CompProject> Project, UIElement Pos, Action ClosedCallBack = null)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Expected O, but got Unknown
			_Closure_0024__4_002D1 arg = default(_Closure_0024__4_002D1);
			_Closure_0024__4_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__4_002D1(null);
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Project = Project;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_ClosedCallBack = ClosedCallBack;
			ContextMenu val = new ContextMenu();
			System.Collections.Generic.IEnumerator<FavData> enumerator = default(System.Collections.Generic.IEnumerator<FavData>);
			try
			{
				enumerator = FavoritesList.GetEnumerator();
				_Closure_0024__4_002D0 closure_0024__4_002D = default(_Closure_0024__4_002D0);
				while (enumerator.MoveNext())
				{
					closure_0024__4_002D = new _Closure_0024__4_002D0(closure_0024__4_002D);
					closure_0024__4_002D._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals0;
					closure_0024__4_002D._0024VB_0024Local_i = enumerator.Current;
					MyMenuItem myMenuItem = new MyMenuItem();
					((FrameworkElement)myMenuItem).MaxWidth = 240.0;
					((HeaderedItemsControl)myMenuItem).Header = $"收藏到 {closure_0024__4_002D._0024VB_0024Local_i.Name}";
					MyMenuItem myMenuItem2 = myMenuItem;
					((MenuItem)myMenuItem2).Click += new RoutedEventHandler(closure_0024__4_002D._Lambda_0024__R3);
					((ItemsControl)val).Items.Add((object)myMenuItem2);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			val.Closed += (RoutedEventHandler)([SpecialName] (object a0, RoutedEventArgs a1) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__2();
			});
			val.Placement = (PlacementMode)2;
			val.PlacementTarget = Pos;
			val.IsOpen = true;
		}

		public static void Save()
		{
			FavoritesList = _FavoritesList;
		}

		public static FavData GetNewFav(string Name, List<string> FavList)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			FavData obj = new FavData
			{
				Name = Name
			};
			Guid val = Guid.NewGuid();
			obj.Id = val.ToString();
			FavData favData = obj;
			if (FavList == null)
			{
				favData.Favs = new List<string>();
			}
			else
			{
				favData.Favs = FavList;
			}
			return favData;
		}

		public static bool IsFavourite(string Id)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			if (FavoritesList == null)
			{
				return false;
			}
			System.Collections.Generic.IEnumerator<FavData> enumerator = default(System.Collections.Generic.IEnumerator<FavData>);
			try
			{
				enumerator = FavoritesList.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Favs.Contains(Id))
					{
						return true;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			return false;
		}
	}

	public class CompRequest
	{
		[CompilerGenerated]
		internal sealed class _Closure_0024__4_002D0
		{
			public List<CompProject> _0024VB_0024Local_Res;

			public List<string> _0024VB_0024Local_CurseForgeProjectIds;

			public int _0024VB_0024Local_FinishedTask;

			public List<string> _0024VB_0024Local_ModrinthProjectIds;

			public _Closure_0024__4_002D0(_Closure_0024__4_002D0 arg0)
			{
				if (arg0 != null)
				{
					_0024VB_0024Local_Res = arg0._0024VB_0024Local_Res;
					_0024VB_0024Local_CurseForgeProjectIds = arg0._0024VB_0024Local_CurseForgeProjectIds;
					_0024VB_0024Local_FinishedTask = arg0._0024VB_0024Local_FinishedTask;
					_0024VB_0024Local_ModrinthProjectIds = arg0._0024VB_0024Local_ModrinthProjectIds;
				}
			}

			[SpecialName]
			internal void _Lambda_0024__0()
			{
				checked
				{
					try
					{
						_0024VB_0024Local_Res.AddRange((System.Collections.Generic.IEnumerable<CompProject>)GetListByIdsFromCurseforge(_0024VB_0024Local_CurseForgeProjectIds));
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "[Favorites] 获取 CurseForge 数据失败", ModBase.LogLevel.Hint);
						ProjectData.ClearProjectError();
					}
					finally
					{
						_0024VB_0024Local_FinishedTask++;
					}
				}
			}

			[SpecialName]
			internal void _Lambda_0024__1()
			{
				checked
				{
					try
					{
						_0024VB_0024Local_Res.AddRange((System.Collections.Generic.IEnumerable<CompProject>)GetListByIdsFromModrinth(_0024VB_0024Local_ModrinthProjectIds));
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "[Favorites] 获取 Modrinth 数据失败", ModBase.LogLevel.Hint);
						ProjectData.ClearProjectError();
					}
					finally
					{
						_0024VB_0024Local_FinishedTask++;
					}
				}
			}
		}

		public static bool IsFromCurseForge(string Id)
		{
			int num = 0;
			return int.TryParse(Id, out num);
		}

		public static List<CompProject> GetListByIdsFromModrinth(List<string> Ids)
		{
			List<CompProject> val = new List<CompProject>();
			object objectValue = RuntimeHelpers.GetObjectValue(ModDownload.DlModRequest(string.Format("https://api.modrinth.com/v2/projects?ids=[\"{0}\"]", (object)ModBase.Join((System.Collections.IEnumerable)Ids, "\",\"")), IsJson: true));
			foreach (object item in (System.Collections.IEnumerable)objectValue)
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(item);
				val.Add(new CompProject((JObject)objectValue2));
			}
			return val;
		}

		public static List<CompProject> GetListByIdsFromCurseforge(List<string> Ids)
		{
			List<CompProject> val = new List<CompProject>();
			object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/mods", "POST", "{\"modIds\": [" + ModBase.Join((System.Collections.IEnumerable)Ids, ",") + "]}", "application/json")), new object[] { "data" }, (string[])null));
			foreach (object item in (System.Collections.IEnumerable)objectValue)
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(item);
				val.Add(new CompProject((JObject)objectValue2));
			}
			return val;
		}

		public static List<CompProject> GetCompProjectsByIds(List<string> Input)
		{
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Expected O, but got Unknown
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			_Closure_0024__4_002D0 arg = default(_Closure_0024__4_002D0);
			_Closure_0024__4_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__4_002D0(null);
			if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)Input))
			{
				return new List<CompProject>();
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_ModrinthProjectIds = new List<string>();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_CurseForgeProjectIds = new List<string>();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Res = new List<CompProject>();
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = Input.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					if (IsFromCurseForge(current))
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Local_CurseForgeProjectIds.Add(current);
					}
					else
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Local_ModrinthProjectIds.Add(current);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_FinishedTask = 0;
			int num = 0;
			checked
			{
				if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0._0024VB_0024Local_CurseForgeProjectIds))
				{
					num++;
					ModBase.RunInNewThread((Action)([SpecialName] () =>
					{
						try
						{
							CS_0024_003C_003E8__locals0._0024VB_0024Local_Res.AddRange((System.Collections.Generic.IEnumerable<CompProject>)GetListByIdsFromCurseforge(CS_0024_003C_003E8__locals0._0024VB_0024Local_CurseForgeProjectIds));
						}
						catch (System.Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							System.Exception ex4 = ex3;
							ModBase.Log(ex4, "[Favorites] 获取 CurseForge 数据失败", ModBase.LogLevel.Hint);
							ProjectData.ClearProjectError();
						}
						finally
						{
							CS_0024_003C_003E8__locals0._0024VB_0024Local_FinishedTask++;
						}
					}), "Favorites CurseForge", (ThreadPriority)2);
				}
				if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0._0024VB_0024Local_ModrinthProjectIds))
				{
					num++;
					ModBase.RunInNewThread((Action)([SpecialName] () =>
					{
						try
						{
							CS_0024_003C_003E8__locals0._0024VB_0024Local_Res.AddRange((System.Collections.Generic.IEnumerable<CompProject>)GetListByIdsFromModrinth(CS_0024_003C_003E8__locals0._0024VB_0024Local_ModrinthProjectIds));
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							ModBase.Log(ex2, "[Favorites] 获取 Modrinth 数据失败", ModBase.LogLevel.Hint);
							ProjectData.ClearProjectError();
						}
						finally
						{
							CS_0024_003C_003E8__locals0._0024VB_0024Local_FinishedTask++;
						}
					}), "Favorites Modrinth", (ThreadPriority)2);
				}
				while (CS_0024_003C_003E8__locals0._0024VB_0024Local_FinishedTask != num)
				{
					Thread.Sleep(50);
				}
				return CS_0024_003C_003E8__locals0._0024VB_0024Local_Res;
			}
		}
	}

	public class CompClipboard
	{
		public static string CurrentText = null;

		public static void GetClipboardResource()
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Expected O, but got Unknown
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			string text = null;
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				text = Clipboard.GetText();
			}));
			if (Operators.CompareString(text, CurrentText, false) == 0)
			{
				return;
			}
			CurrentText = text;
			ModBase.RunInNewThread((Action)([SpecialName] () =>
			{
				//IL_0306: Unknown result type (might be due to invalid IL or missing references)
				//IL_0311: Expected O, but got Unknown
				try
				{
					string text2 = null;
					string text3 = null;
					string text4 = null;
					object obj = null;
					string text5 = text.Replace("https://", "").Replace("http://", "");
					if (text5.Contains("curseforge.com/minecraft/"))
					{
						List<string> obj2 = new List<string>();
						obj2.Add("6");
						obj2.Add("4471");
						obj2.Add("12");
						obj2.Add("6552");
						try
						{
							text4 = text5.Split("/", (StringSplitOptions)0)[2];
							text2 = text5.Split("/", (StringSplitOptions)0)[3];
							obj = RuntimeHelpers.GetObjectValue(ModDownload.DlModRequest("https://api.curseforge.com/v1/mods/search?gameId=432&slug=" + text2, IsJson: true));
							string text6 = Conversions.ToString(NewLateBinding.LateIndexGet(NewLateBinding.LateIndexGet(NewLateBinding.LateIndexGet(NewLateBinding.LateIndexGet(NewLateBinding.LateIndexGet(obj, new object[] { "data" }, (string[])null), new object[] { 0 }, (string[])null), new object[] { "categories" }, (string[])null), new object[] { 0 }, (string[])null), new object[] { "classId" }, (string[])null));
							bool flag = true;
							string text7 = null;
							if (Operators.CompareString(text4, "mc-mods", false) == 0 && Operators.CompareString(text6, "6", false) != 0)
							{
								flag = false;
								text7 = "6";
							}
							else if (Operators.CompareString(text4, "modpacks", false) == 0 && Operators.CompareString(text6, "4471", false) != 0)
							{
								flag = false;
								text7 = "4471";
							}
							else if (Operators.CompareString(text4, "texture-packs", false) == 0 && Operators.CompareString(text6, "12", false) != 0)
							{
								flag = false;
								text7 = "12";
							}
							else if (Operators.CompareString(text4, "shaders", false) == 0 && Operators.CompareString(text6, "6552", false) != 0)
							{
								flag = false;
								text7 = "6552";
							}
							if (!flag)
							{
								obj = RuntimeHelpers.GetObjectValue(ModDownload.DlModRequest("https://api.curseforge.com/v1/mods/search?gameId=432&slug=" + text2 + "&classId=" + text7, IsJson: true));
							}
							text3 = Conversions.ToString(NewLateBinding.LateIndexGet(NewLateBinding.LateIndexGet(NewLateBinding.LateIndexGet(obj, new object[] { "data" }, (string[])null), new object[] { 0 }, (string[])null), new object[] { "id" }, (string[])null));
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							ModBase.Log("[Clipboard] 获取剪贴板 CurseForge 资源链接 ID 失败: " + ex2.ToString());
							ProjectData.ClearProjectError();
							return;
						}
					}
					else
					{
						if (!text5.Contains("modrinth.com/"))
						{
							return;
						}
						try
						{
							text2 = text5.Split("/", (StringSplitOptions)0)[2];
							text3 = Conversions.ToString(NewLateBinding.LateIndexGet(ModDownload.DlModRequest("https://api.modrinth.com/v2/project/" + text2, IsJson: true), new object[] { "id" }, (string[])null));
						}
						catch (System.Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							System.Exception ex4 = ex3;
							ModBase.Log("[Clipboard] 获取剪贴板 Modrinth 资源链接 ID 失败: " + ex4.ToString());
							ProjectData.ClearProjectError();
							return;
						}
					}
					ModBase.Log("[Clipboard] 剪贴板资源 ProjectId: " + text3);
					ModBase.RunInUi((Action)([SpecialName] () =>
					{
						if (ModMain.MyMsgBox("PCL 在剪贴板中识别到了资源链接，是否要跳转到该资源的详细信息页面？", "识别到剪贴板资源", "确定", "取消", "", IsWarn: false, HighLight: true, ForceWait: true) == 1)
						{
							ModMain.Hint("正在获取资源信息，请稍等...");
							List<CompProject> compProjectsByIds = CompRequest.GetCompProjectsByIds(new List<string>((System.Collections.Generic.IEnumerable<string>)new string[] { text3 }));
							ModMain.FrmMain.PageChange(new FormMain.PageStackData
							{
								Page = FormMain.PageType.CompDetail,
								Additional = new object[5]
								{
									Enumerable.First<CompProject>((System.Collections.Generic.IEnumerable<CompProject>)compProjectsByIds),
									new List<string>(),
									string.Empty,
									CompLoaderType.Any,
									CompType.Any
								}
							});
						}
					}));
				}
				catch (System.Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					System.Exception ex6 = ex5;
					ModBase.Log("[Clipboard] 处理剪贴板资源时发生错误: " + ex6.ToString());
					ProjectData.ClearProjectError();
				}
			}), "Clipboard Resource Processing", (ThreadPriority)2);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__15_002D0
	{
		public string _0024VB_0024Local_CurseForgeUrl;

		public ModLoader.LoaderTask<CompProjectRequest, int> _0024VB_0024Local_Task;

		public CompProjectRequest _0024VB_0024Local_Request;

		public object _0024VB_0024Local_ResultsLock;

		public List<CompProject> _0024VB_0024Local_RawResults;

		public CompProjectStorage _0024VB_0024Local_Storage;

		public System.Exception _0024VB_0024Local_Error;

		public string _0024VB_0024Local_ModrinthUrl;

		public List<CompProject> _0024VB_0024Local_RealResults;

		public _Closure_0024__15_002D0(_Closure_0024__15_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_CurseForgeUrl = arg0._0024VB_0024Local_CurseForgeUrl;
				_0024VB_0024Local_Task = arg0._0024VB_0024Local_Task;
				_0024VB_0024Local_Request = arg0._0024VB_0024Local_Request;
				_0024VB_0024Local_ResultsLock = arg0._0024VB_0024Local_ResultsLock;
				_0024VB_0024Local_RawResults = arg0._0024VB_0024Local_RawResults;
				_0024VB_0024Local_Storage = arg0._0024VB_0024Local_Storage;
				_0024VB_0024Local_Error = arg0._0024VB_0024Local_Error;
				_0024VB_0024Local_ModrinthUrl = arg0._0024VB_0024Local_ModrinthUrl;
				_0024VB_0024Local_RealResults = arg0._0024VB_0024Local_RealResults;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__6(CompProject r)
		{
			_Closure_0024__15_002D2 arg = default(_Closure_0024__15_002D2);
			_Closure_0024__15_002D2 CS_0024_003C_003E8__locals0 = new _Closure_0024__15_002D2(null)
			{
				_0024VB_0024Local_r = r
			};
			if (!Enumerable.Any<CompProject>((System.Collections.Generic.IEnumerable<CompProject>)_0024VB_0024Local_RealResults, (Func<CompProject, bool>)([SpecialName] (CompProject b) => CS_0024_003C_003E8__locals0._0024VB_0024Local_r.IsLike(b))))
			{
				return !Enumerable.Any<CompProject>((System.Collections.Generic.IEnumerable<CompProject>)_0024VB_0024Local_Storage.Results, (Func<CompProject, bool>)([SpecialName] (CompProject b) => CS_0024_003C_003E8__locals0._0024VB_0024Local_r.IsLike(b)));
			}
			return false;
		}

		[SpecialName]
		internal double _Lambda_0024__9(CompProject Project)
		{
			switch (_0024VB_0024Local_Request.Type)
			{
			case CompType.Mod:
			case CompType.ModPack:
				return Project.FromCurseForge ? 1 : 7;
			case CompType.DataPack:
				return (!Project.FromCurseForge) ? 1 : 10;
			case CompType.ResourcePack:
			case CompType.Shader:
				return Project.FromCurseForge ? 1 : 5;
			default:
				return 1.0;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__15_002D1
	{
		public bool _0024VB_0024Local_CurseForgeFailed;

		public bool _0024VB_0024Local_ModrinthFailed;

		public _Closure_0024__15_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__15_002D1(_Closure_0024__15_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_CurseForgeFailed = arg0._0024VB_0024Local_CurseForgeFailed;
				_0024VB_0024Local_ModrinthFailed = arg0._0024VB_0024Local_ModrinthFailed;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			checked
			{
				try
				{
					ModBase.Log("[Comp] 开始从 CurseForge 获取工程列表：" + _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_CurseForgeUrl);
					JObject jObject = (JObject)ModDownload.DlModRequest(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_CurseForgeUrl, IsJson: true);
					_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.Progress += 0.2;
					List<CompProject> val = new List<CompProject>();
					System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
					try
					{
						enumerator = ((System.Collections.Generic.IEnumerable<JToken>)jObject["data"]).GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator).MoveNext())
						{
							JObject data = (JObject)enumerator.Current;
							CompProject compProject = new CompProject(data);
							if (_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Request.Type != CompType.ResourcePack || !compProject.Tags.Contains("数据包"))
							{
								val.Add(compProject);
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator)?.Dispose();
					}
					object _0024VB_0024Local_ResultsLock = _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ResultsLock;
					ObjectFlowControl.CheckForSyncLockOnValueType(_0024VB_0024Local_ResultsLock);
					bool flag = false;
					try
					{
						Monitor.Enter(_0024VB_0024Local_ResultsLock, ref flag);
						_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_RawResults.AddRange((System.Collections.Generic.IEnumerable<CompProject>)val);
					}
					finally
					{
						if (flag)
						{
							Monitor.Exit(_0024VB_0024Local_ResultsLock);
						}
					}
					_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Storage.CurseForgeOffset += val.Count;
					_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Storage.CurseForgeTotal = jObject["pagination"]["totalCount"].ToObject<int>();
					ModBase.Log($"[Comp] 从 CurseForge 获取到了 {val.Count} 个工程（已获取 {_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Storage.CurseForgeOffset} 个，共 {_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Storage.CurseForgeTotal} 个）");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "从 CurseForge 获取工程列表失败");
					_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Storage.CurseForgeTotal = -1;
					_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Error = ex2;
					_0024VB_0024Local_CurseForgeFailed = true;
					ProjectData.ClearProjectError();
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			checked
			{
				try
				{
					ModBase.Log("[Comp] 开始从 Modrinth 获取工程列表：" + _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModrinthUrl);
					JObject jObject = (JObject)ModDownload.DlModRequest(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModrinthUrl, IsJson: true);
					_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.Progress += 0.2;
					List<CompProject> val = new List<CompProject>();
					System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
					try
					{
						enumerator = ((System.Collections.Generic.IEnumerable<JToken>)jObject["hits"]).GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator).MoveNext())
						{
							JObject data = (JObject)enumerator.Current;
							val.Add(new CompProject(data));
						}
					}
					finally
					{
						((System.IDisposable)enumerator)?.Dispose();
					}
					object _0024VB_0024Local_ResultsLock = _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ResultsLock;
					ObjectFlowControl.CheckForSyncLockOnValueType(_0024VB_0024Local_ResultsLock);
					bool flag = false;
					try
					{
						Monitor.Enter(_0024VB_0024Local_ResultsLock, ref flag);
						System.Collections.Generic.IEnumerator<CompProject> enumerator2 = default(System.Collections.Generic.IEnumerator<CompProject>);
						try
						{
							enumerator2 = val.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								CompProject current = enumerator2.Current;
								_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_RawResults.Add(current);
							}
						}
						finally
						{
							((System.IDisposable)enumerator2).Dispose();
						}
					}
					finally
					{
						if (flag)
						{
							Monitor.Exit(_0024VB_0024Local_ResultsLock);
						}
					}
					_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Storage.ModrinthOffset += val.Count;
					_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Storage.ModrinthTotal = jObject["total_hits"].ToObject<int>();
					ModBase.Log($"[Comp] 从 Modrinth 获取到了 {val.Count} 个工程（已获取 {_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Storage.ModrinthOffset} 个，共 {_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Storage.ModrinthTotal} 个）");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "从 Modrinth 获取工程列表失败");
					_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Storage.ModrinthTotal = -1;
					_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Error = ex2;
					_0024VB_0024Local_ModrinthFailed = true;
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__15_002D2
	{
		public CompProject _0024VB_0024Local_r;

		public _Closure_0024__15_002D2(_Closure_0024__15_002D2 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_r = arg0._0024VB_0024Local_r;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__7(CompProject b)
		{
			return _0024VB_0024Local_r.IsLike(b);
		}

		[SpecialName]
		internal bool _Lambda_0024__8(CompProject b)
		{
			return _0024VB_0024Local_r.IsLike(b);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__19_002D0
	{
		public CompProject _0024VB_0024Local_TargetProject;

		public _Closure_0024__19_002D0(_Closure_0024__19_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_TargetProject = arg0._0024VB_0024Local_TargetProject;
			}
		}

		[SpecialName]
		internal CompFile _Lambda_0024__0(JToken a)
		{
			return new CompFile((JObject)a, _0024VB_0024Local_TargetProject.Type);
		}
	}

	private static LiteDatabase _CompDatabase = null;

	private const int CompPageSize = 40;

	public static Dictionary<string, CompProject> CompProjectCache = new Dictionary<string, CompProject>();

	public static Dictionary<string, List<CompFile>> CompFilesCache = new Dictionary<string, List<CompFile>>();

	private static LiteDatabase CompDatabase
	{
		get
		{
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Expected O, but got Unknown
			if (_CompDatabase != null)
			{
				return _CompDatabase;
			}
			string text = $"{ModBase.PathTemp}Cache\\ModData.db";
			Stream resourceStream = ModBase.GetResourceStream("Resources/ModData.dbcp");
			try
			{
				ModBase.Log("[DB] 解压 ModData 中");
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				GZipStream val = new GZipStream(resourceStream, (CompressionMode)0);
				try
				{
					FileStream val2 = new FileStream(text, (FileMode)2, (FileAccess)3, (FileShare)1);
					try
					{
						((Stream)val).CopyTo((Stream)(object)val2);
					}
					finally
					{
						((System.IDisposable)val2)?.Dispose();
					}
				}
				finally
				{
					((System.IDisposable)val)?.Dispose();
				}
				ModBase.Log($"[DB] 已更新本地 ModData {text}");
			}
			finally
			{
				((System.IDisposable)resourceStream)?.Dispose();
			}
			_CompDatabase = new LiteDatabase(text, (BsonMapper)null);
			ModBase.Log(string.Format("[DB] 已加载 ModData，共 {0} 条数据", (object)_CompDatabase.GetCollection("ModTranslation", (BsonAutoId)10).Count()));
			return _CompDatabase;
		}
	}

	private static CompDatabaseEntry GetCompWikiEntryBySlug(string slug)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		ILiteCollection<CompDatabaseEntry> collection = CompDatabase.GetCollection<CompDatabaseEntry>("ModTranslation", (BsonAutoId)10);
		BsonValue val = new BsonValue(slug);
		BsonExpression val2 = Query.Or(Query.EQ("CurseForgeSlug", val), Query.EQ("ModrinthSlug", val));
		return Enumerable.FirstOrDefault<CompDatabaseEntry>(collection.Find(val2, 0, 2147483647));
	}

	public static void CompProjectsGet(ModLoader.LoaderTask<CompProjectRequest, int> Task)
	{
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b7: Expected O, but got Unknown
		//IL_08d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e7: Expected O, but got Unknown
		//IL_0cc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc8: Unknown result type (might be due to invalid IL or missing references)
		_Closure_0024__15_002D0 arg = default(_Closure_0024__15_002D0);
		_Closure_0024__15_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__15_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Task = Task;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Request = CS_0024_003C_003E8__locals0._0024VB_0024Local_Task.Input;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Storage = CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.Storage;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.Storage.Results.Count >= CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetResultCount)
		{
			ModBase.Log($"[Comp] 已有 {CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.Storage.Results.Count} 个结果，多于所需的 {CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetResultCount} 个结果，结束处理");
			return;
		}
		if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CanContinue)
		{
			if (!Enumerable.Any<CompProject>((System.Collections.Generic.IEnumerable<CompProject>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.Storage.Results))
			{
				throw new System.Exception("没有符合条件的结果");
			}
			ModBase.Log($"[Comp] 已有 {CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.Storage.Results.Count} 个结果，少于所需的 {CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetResultCount} 个结果，但无法继续获取，结束处理");
			return;
		}
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ModLoader == CompLoaderType.Quilt && ModMinecraft.VersionSortInteger(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.GameVersion ?? "1.15", "1.14") == -1)
		{
			throw new System.Exception("Quilt 不支持 Minecraft " + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.GameVersion);
		}
		string text = (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.SearchText ?? "").Trim();
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.SearchText = text;
		text = text.ToLower();
		ModBase.Log("[Comp] 工程列表搜索原始文本：" + text);
		bool flag = RegexPatterns.HasChineseChar.IsMatch(text) && !string.IsNullOrEmpty(text);
		checked
		{
			if (flag && (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.Type == CompType.Mod || CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.Type == CompType.DataPack))
			{
				List<ModBase.SearchEntry<CompDatabaseEntry>> val = new List<ModBase.SearchEntry<CompDatabaseEntry>>();
				ILiteCollection<CompDatabaseEntry> collection = CompDatabase.GetCollection<CompDatabaseEntry>("ModTranslation", (BsonAutoId)10);
				BsonExpression val2 = Query.Or((BsonExpression[])(object)new BsonExpression[3]
				{
					Query.Contains("ChineseName", text),
					Query.Contains("CurseForgeSlug", text),
					Query.Contains("ModrinthSlug", text)
				});
				System.Collections.Generic.IEnumerable<CompDatabaseEntry> enumerable = collection.Find(val2, 0, 2147483647);
				System.Collections.Generic.IEnumerator<CompDatabaseEntry> enumerator = default(System.Collections.Generic.IEnumerator<CompDatabaseEntry>);
				try
				{
					enumerator = enumerable.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						CompDatabaseEntry current = enumerator.Current;
						if (!current.ChineseName.Contains("动态的树"))
						{
							ModBase.SearchEntry<CompDatabaseEntry> obj = new ModBase.SearchEntry<CompDatabaseEntry>
							{
								Item = current
							};
							List<KeyValuePair<string, double>> obj2 = new List<KeyValuePair<string, double>>();
							obj2.Add(new KeyValuePair<string, double>(current.ChineseName + current.CurseForgeSlug + current.ModrinthSlug, 1.0));
							obj.SearchSource = obj2;
							val.Add(obj);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				List<ModBase.SearchEntry<CompDatabaseEntry>> val3 = ModBase.Search<CompDatabaseEntry>(val, CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.SearchText, 3);
				if (!Enumerable.Any<ModBase.SearchEntry<CompDatabaseEntry>>((System.Collections.Generic.IEnumerable<ModBase.SearchEntry<CompDatabaseEntry>>)val3))
				{
					throw new System.Exception("无搜索结果，请尝试搜索英文名称");
				}
				string text2 = "";
				int num = Math.Min(4, val3.Count - 1);
				for (int i = 0; i <= num && (val3[i].AbsoluteRight || i < Math.Min(2, val3.Count - 1)); i++)
				{
					if (val3[i].Item.CurseForgeSlug != null)
					{
						text2 = text2 + val3[i].Item.CurseForgeSlug.Replace("-", " ").Replace("/", " ") + " ";
					}
					if (val3[i].Item.ModrinthSlug != null)
					{
						text2 = text2 + val3[i].Item.ModrinthSlug.Replace("-", " ").Replace("/", " ") + " ";
					}
					text2 = text2 + ModBase.BeforeFirst(ModBase.AfterLast(val3[i].Item.ChineseName, " (").TrimEnd(')'), " - ").Replace(":", "").Replace("(", "")
						.Replace(")", "")
						.ToLower()
						.Replace("/", " ") + " ";
				}
				ModBase.Log("[Comp] 中文搜索原始关键词：" + text2, ModBase.LogLevel.Developer);
				string text3 = "";
				string[] array = text2.Split(" ", (StringSplitOptions)0);
				foreach (string text4 in array)
				{
					if (!Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "the", "of", "a", "mod", "and" }, text4.ToLowerInvariant()) && !(ModBase.Val(text4) > 0.0) && (Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)text2.Split(" ", (StringSplitOptions)0)) <= 3 || !Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "ftb" }, text4.ToLower())))
					{
						text3 = text3 + text4.TrimStart('{').TrimEnd('}') + " ";
					}
				}
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.SearchText = text3;
				ModBase.Log("[Comp] 中文搜索最终关键词：" + text3, ModBase.LogLevel.Developer);
			}
			string text5 = RegexPatterns.EnglishSpacedKeywords.Replace(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.SearchText, "$& ");
			string text6 = CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.SearchText.Replace(" ", "");
			string text7 = (text5 + " " + (flag ? CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.SearchText : (text6 + " " + text))).ToLower();
			List<string> val4 = new List<string>();
			string[] array2 = text7.Split(" ", (StringSplitOptions)0);
			for (int k = 0; k < array2.Length; k++)
			{
				string text8 = array2[k];
				text8 = text8.Trim(new char[] { '[', ']' });
				if (Operators.CompareString(text8, "", false) != 0)
				{
					if (Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "forge", "fabric", "for", "mod", "quilt" }, text8))
					{
						ModBase.Log("[Comp] 已跳过搜索关键词：" + text8, ModBase.LogLevel.Developer);
					}
					else
					{
						val4.Add(text8);
					}
				}
			}
			if (text.Length > 0 && !Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val4))
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.SearchText = text;
			}
			else
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.SearchText = ModBase.Join((System.Collections.IEnumerable)Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val4)), " ").ToLower();
			}
			if (ModBase.ContainsF(text.Replace(" ", ""), "optiforge", IgnoreCase: true))
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.SearchText = "optiforge";
			}
			if (ModBase.ContainsF(text.Replace(" ", ""), "optifabric", IgnoreCase: true))
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.SearchText = "optifabric";
			}
			ModBase.Log("[Comp] 工程列表搜索最终文本：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.SearchText, ModBase.LogLevel.Debug);
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Task.Progress = 0.1;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_RealResults = new List<CompProject>();
			_Closure_0024__15_002D1 closure_0024__15_002D = default(_Closure_0024__15_002D1);
			while (true)
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_RawResults = new List<CompProject>();
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Error = null;
				Thread val5 = null;
				Thread val6 = null;
				CS_0024_003C_003E8__locals0._0024VB_0024Local_ResultsLock = RuntimeHelpers.GetObjectValue(new object());
				bool? flag2;
				bool? flag3 = (flag2 = ((CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ModLoader != CompLoaderType.Forge) ? new bool?(false) : CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.GameVersion?.Contains(".")));
				bool? obj3;
				if (!flag3.HasValue || flag2.GetValueOrDefault())
				{
					string gameVersion = CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.GameVersion;
					obj3 = (ModBase.Val((gameVersion != null) ? gameVersion.Split(".", (StringSplitOptions)0)[1] : null) < 14.0) & flag2;
				}
				else
				{
					obj3 = false;
				}
				bool? flag4 = obj3;
				if (flag4.GetValueOrDefault())
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ModLoader = CompLoaderType.Any;
				}
				CS_0024_003C_003E8__locals0._0024VB_0024Local_CurseForgeUrl = CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.GetCurseForgeAddress();
				CS_0024_003C_003E8__locals0._0024VB_0024Local_ModrinthUrl = CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.GetModrinthAddress();
				if (flag4.GetValueOrDefault())
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.ModLoader = CompLoaderType.Forge;
				}
				try
				{
					closure_0024__15_002D = new _Closure_0024__15_002D1(closure_0024__15_002D);
					closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals0;
					closure_0024__15_002D._0024VB_0024Local_CurseForgeFailed = false;
					if (closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_CurseForgeUrl != null)
					{
						val5 = ModBase.RunInNewThread(new Action(closure_0024__15_002D._Lambda_0024__0), "CurseForge Project Request", (ThreadPriority)2);
					}
					closure_0024__15_002D._0024VB_0024Local_ModrinthFailed = false;
					if (closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModrinthUrl != null)
					{
						val6 = ModBase.RunInNewThread(new Action(closure_0024__15_002D._Lambda_0024__1), "Modrinth Project Request", (ThreadPriority)2);
					}
					if (val5 != null)
					{
						val5.Join();
					}
					if (closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.IsAborted)
					{
						return;
					}
					if (val6 != null)
					{
						val6.Join();
					}
					if (closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Task.IsAborted)
					{
						return;
					}
					if (flag4.GetValueOrDefault())
					{
						closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_RawResults = Enumerable.ToList<CompProject>(Enumerable.Where<CompProject>((System.Collections.Generic.IEnumerable<CompProject>)closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_RawResults, (Func<CompProject, bool>)([SpecialName] (CompProject p) => !Enumerable.Any<CompLoaderType>((System.Collections.Generic.IEnumerable<CompLoaderType>)p.ModLoaders) || p.ModLoaders.Contains(CompLoaderType.Forge))));
					}
					closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Storage.ErrorMessage = null;
					if (!Enumerable.Any<CompProject>((System.Collections.Generic.IEnumerable<CompProject>)closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_RawResults))
					{
						if (closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Error != null)
						{
							throw closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Error;
						}
						if (flag && closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Request.Type != 0 && closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Request.Type != CompType.DataPack)
						{
							throw new System.Exception("没有搜索结果，请尝试使用英文搜索");
						}
						if (closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Request.Source == CompSourceType.CurseForge && ModBase.StartsWithF(closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Request.Tag, "/"))
						{
							throw new System.Exception("CurseForge 不兼容所选的类型");
						}
						if (closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Request.Source == CompSourceType.Modrinth && ModBase.EndsWithF(closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Request.Tag, "/"))
						{
							throw new System.Exception("Modrinth 不兼容所选的类型");
						}
						throw new System.Exception("没有搜索结果");
					}
					if (closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Error != null)
					{
						if (closure_0024__15_002D._0024VB_0024Local_CurseForgeFailed)
						{
							closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Storage.ErrorMessage = string.Format("无法连接到 CurseForge，所以目前仅显示了来自 Modrinth 的内容，搜索结果可能不全。{0}请稍后重试，或使用 VPN 以改善网络环境。", (object)"\r\n");
						}
						else
						{
							closure_0024__15_002D._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Storage.ErrorMessage = string.Format("无法连接到 Modrinth，所以目前仅显示了来自 CurseForge 的内容，搜索结果可能不全。{0}请稍后重试，或使用 VPN 以改善网络环境。", (object)"\r\n");
						}
					}
				}
				finally
				{
					if (val5 != null)
					{
						val5.Interrupt();
					}
					if (val6 != null)
					{
						val6.Interrupt();
					}
				}
				CS_0024_003C_003E8__locals0._0024VB_0024Local_RawResults = Enumerable.ToList<CompProject>(Enumerable.Concat<CompProject>(Enumerable.Where<CompProject>((System.Collections.Generic.IEnumerable<CompProject>)CS_0024_003C_003E8__locals0._0024VB_0024Local_RawResults, (Func<CompProject, bool>)([SpecialName] (CompProject x) => !x.FromCurseForge)), Enumerable.Where<CompProject>((System.Collections.Generic.IEnumerable<CompProject>)CS_0024_003C_003E8__locals0._0024VB_0024Local_RawResults, (Func<CompProject, bool>)([SpecialName] (CompProject x) => x.FromCurseForge))));
				CS_0024_003C_003E8__locals0._0024VB_0024Local_RawResults = ModBase.Distinct((System.Collections.Generic.ICollection<CompProject>)CS_0024_003C_003E8__locals0._0024VB_0024Local_RawResults, [SpecialName] (CompProject a, CompProject b) => a.IsLike(b));
				CS_0024_003C_003E8__locals0._0024VB_0024Local_RawResults = Enumerable.ToList<CompProject>(Enumerable.Where<CompProject>((System.Collections.Generic.IEnumerable<CompProject>)CS_0024_003C_003E8__locals0._0024VB_0024Local_RawResults, (Func<CompProject, bool>)([SpecialName] (CompProject r) =>
				{
					_Closure_0024__15_002D2 arg2 = default(_Closure_0024__15_002D2);
					_Closure_0024__15_002D2 CS_0024_003C_003E8__locals1 = new _Closure_0024__15_002D2(null);
					CS_0024_003C_003E8__locals1._0024VB_0024Local_r = r;
					return !Enumerable.Any<CompProject>((System.Collections.Generic.IEnumerable<CompProject>)CS_0024_003C_003E8__locals0._0024VB_0024Local_RealResults, (Func<CompProject, bool>)([SpecialName] (CompProject b) => CS_0024_003C_003E8__locals1._0024VB_0024Local_r.IsLike(b))) && !Enumerable.Any<CompProject>((System.Collections.Generic.IEnumerable<CompProject>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Storage.Results, (Func<CompProject, bool>)([SpecialName] (CompProject b) => CS_0024_003C_003E8__locals1._0024VB_0024Local_r.IsLike(b)));
				})));
				CS_0024_003C_003E8__locals0._0024VB_0024Local_RealResults.AddRange((System.Collections.Generic.IEnumerable<CompProject>)CS_0024_003C_003E8__locals0._0024VB_0024Local_RawResults);
				ModBase.Log($"[Comp] 去重、筛选后累计新增结果 {CS_0024_003C_003E8__locals0._0024VB_0024Local_RealResults.Count} 个");
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_RealResults.Count + CS_0024_003C_003E8__locals0._0024VB_0024Local_Storage.Results.Count >= CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetResultCount)
				{
					break;
				}
				ModBase.Log($"[Comp] 总结果数需求最少 {CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.TargetResultCount} 个，仅获得了 {CS_0024_003C_003E8__locals0._0024VB_0024Local_RealResults.Count + CS_0024_003C_003E8__locals0._0024VB_0024Local_Storage.Results.Count} 个");
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.CanContinue && CS_0024_003C_003E8__locals0._0024VB_0024Local_Error == null)
				{
					ModBase.Log("[Comp] 将继续尝试加载下一页");
					continue;
				}
				ModBase.Log("[Comp] 无法继续加载，将强制结束");
				break;
			}
			Dictionary<CompProject, double> val7 = new Dictionary<CompProject, double>();
			VB_0024AnonymousDelegate_6<CompProject, double> vB_0024AnonymousDelegate_ = [SpecialName] (CompProject Project) =>
			{
				switch (CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.Type)
				{
				case CompType.Mod:
				case CompType.ModPack:
					return Project.FromCurseForge ? 1 : 7;
				case CompType.DataPack:
					return (!Project.FromCurseForge) ? 1 : 10;
				case CompType.ResourcePack:
				case CompType.Shader:
					return Project.FromCurseForge ? 1 : 5;
				default:
					return 1.0;
				}
			};
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Local_Request.SearchText))
			{
				System.Collections.Generic.IEnumerator<CompProject> enumerator2 = default(System.Collections.Generic.IEnumerator<CompProject>);
				try
				{
					enumerator2 = CS_0024_003C_003E8__locals0._0024VB_0024Local_RealResults.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						CompProject current2 = enumerator2.Current;
						val7.Add(current2, (double)current2.DownloadCount * vB_0024AnonymousDelegate_(current2));
					}
				}
				finally
				{
					((System.IDisposable)enumerator2).Dispose();
				}
			}
			else
			{
				List<ModBase.SearchEntry<CompProject>> val8 = new List<ModBase.SearchEntry<CompProject>>();
				System.Collections.Generic.IEnumerator<CompProject> enumerator3 = default(System.Collections.Generic.IEnumerator<CompProject>);
				try
				{
					enumerator3 = CS_0024_003C_003E8__locals0._0024VB_0024Local_RealResults.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						CompProject current3 = enumerator3.Current;
						val7.Add(current3, ((current3.WikiId > 0) ? 0.2 : 0.0) + Math.Log10((double)Math.Max(current3.DownloadCount, 1) * vB_0024AnonymousDelegate_(current3)) / 9.0);
						ModBase.SearchEntry<CompProject> obj4 = new ModBase.SearchEntry<CompProject>
						{
							Item = current3
						};
						List<KeyValuePair<string, double>> obj5 = new List<KeyValuePair<string, double>>();
						obj5.Add(new KeyValuePair<string, double>(flag ? current3.TranslatedName : current3.RawName, 1.0));
						obj5.Add(new KeyValuePair<string, double>(current3.Description, 0.05));
						obj4.SearchSource = obj5;
						val8.Add(obj4);
					}
				}
				finally
				{
					((System.IDisposable)enumerator3).Dispose();
				}
				List<ModBase.SearchEntry<CompProject>> val9 = ModBase.Search<CompProject>(val8, text, 101, -1.0);
				System.Collections.Generic.IEnumerator<ModBase.SearchEntry<CompProject>> enumerator4 = default(System.Collections.Generic.IEnumerator<ModBase.SearchEntry<CompProject>>);
				try
				{
					enumerator4 = val9.GetEnumerator();
					while (enumerator4.MoveNext())
					{
						ModBase.SearchEntry<CompProject> current4 = enumerator4.Current;
						Dictionary<CompProject, double> val10;
						CompProject item;
						(val10 = val7)[item = current4.Item] = val10[item] + current4.Similarity / val9[0].Similarity;
					}
				}
				finally
				{
					((System.IDisposable)enumerator4).Dispose();
				}
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Storage.Results.AddRange(Enumerable.Select<KeyValuePair<CompProject, double>, CompProject>((System.Collections.Generic.IEnumerable<KeyValuePair<CompProject, double>>)Enumerable.OrderByDescending<KeyValuePair<CompProject, double>, double>((System.Collections.Generic.IEnumerable<KeyValuePair<CompProject, double>>)val7, (Func<KeyValuePair<CompProject, double>, double>)([SpecialName] (KeyValuePair<CompProject, double> s) => s.Value)), (Func<KeyValuePair<CompProject, double>, CompProject>)([SpecialName] (KeyValuePair<CompProject, double> r) => r.Key)));
		}
	}

	public static List<CompFile> CompFilesGet(string ProjectId, bool FromCurseForge)
	{
		//IL_0490: Unknown result type (might be due to invalid IL or missing references)
		//IL_0495: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
		_Closure_0024__19_002D0 arg = default(_Closure_0024__19_002D0);
		_Closure_0024__19_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__19_002D0(null);
		if (CompProjectCache.ContainsKey(ProjectId))
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetProject = CompProjectCache[ProjectId];
		}
		else if (FromCurseForge)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetProject = new CompProject((JObject)NewLateBinding.LateIndexGet(ModDownload.DlModRequest("https://api.curseforge.com/v1/mods/" + ProjectId, IsJson: true), new object[] { "data" }, (string[])null));
		}
		else
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetProject = new CompProject((JObject)ModDownload.DlModRequest("https://api.modrinth.com/v2/project/" + ProjectId, IsJson: true));
		}
		if (!CompFilesCache.ContainsKey(ProjectId))
		{
			ModBase.Log("[Comp] 开始获取文件列表：" + ProjectId);
			JArray jArray = ((!FromCurseForge) ? ((JArray)ModDownload.DlModRequest($"https://api.modrinth.com/v2/project/{ProjectId}/version", IsJson: true)) : ((JArray)NewLateBinding.LateIndexGet(ModDownload.DlModRequest($"https://api.curseforge.com/v1/mods/{ProjectId}/files?pageSize=10000", IsJson: true), new object[] { "data" }, (string[])null)));
			CompFilesCache[ProjectId] = ModBase.Distinct((System.Collections.Generic.ICollection<CompFile>)Enumerable.ToList<CompFile>(Enumerable.Where<CompFile>(Enumerable.Select<JToken, CompFile>((System.Collections.Generic.IEnumerable<JToken>)jArray, (Func<JToken, CompFile>)([SpecialName] (JToken a) => new CompFile((JObject)a, CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetProject.Type))), (Func<CompFile, bool>)([SpecialName] (CompFile a) => a.Available))), [SpecialName] (CompFile a, CompFile b) => Operators.CompareString(a.Id, b.Id, false) == 0);
		}
		List<string> val = Enumerable.ToList<string>(Enumerable.Distinct<string>(Enumerable.SelectMany<CompFile, string>((System.Collections.Generic.IEnumerable<CompFile>)CompFilesCache[ProjectId], (Func<CompFile, System.Collections.Generic.IEnumerable<string>>)([SpecialName] (CompFile f) => (System.Collections.Generic.IEnumerable<string>)f.RawDependencies))));
		List<string> val2 = Enumerable.ToList<string>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)val, (Func<string, bool>)([SpecialName] (string f) => !CompProjectCache.ContainsKey(f))));
		List<string> val3 = Enumerable.ToList<string>(Enumerable.Distinct<string>(Enumerable.SelectMany<CompFile, string>((System.Collections.Generic.IEnumerable<CompFile>)CompFilesCache[ProjectId], (Func<CompFile, System.Collections.Generic.IEnumerable<string>>)([SpecialName] (CompFile f) => (System.Collections.Generic.IEnumerable<string>)f.RawOptionalDependencies))));
		List<string> val4 = Enumerable.ToList<string>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)val, (Func<string, bool>)([SpecialName] (string f) => !CompProjectCache.ContainsKey(f))));
		if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2))
		{
			ModBase.Log(string.Format("[Comp] {0} 文件列表中还需要获取信息的必要前置：{1}", (object)ProjectId, (object)ModBase.Join((System.Collections.IEnumerable)val2, "，")));
			JArray jArray2 = ((!CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetProject.FromCurseForge) ? ((JArray)ModDownload.DlModRequest(string.Format("https://api.modrinth.com/v2/projects?ids=[\"{0}\"]", (object)ModBase.Join((System.Collections.IEnumerable)val2, "\",\"")), IsJson: true)) : ((JArray)NewLateBinding.LateIndexGet(ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/mods", "POST", "{\"modIds\": [" + ModBase.Join((System.Collections.IEnumerable)val2, ",") + "]}", "application/json")), new object[] { "data" }, (string[])null)));
			System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator = jArray2.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					JToken current = enumerator.Current;
					new CompProject((JObject)current);
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
		}
		if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val4))
		{
			ModBase.Log(string.Format("[Comp] {0} 文件列表中还需要获取信息的可选前置：{1}", (object)ProjectId, (object)ModBase.Join((System.Collections.IEnumerable)val2, "，")));
			JArray jArray3 = ((!CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetProject.FromCurseForge) ? ((JArray)ModDownload.DlModRequest(string.Format("https://api.modrinth.com/v2/projects?ids=[\"{0}\"]", (object)ModBase.Join((System.Collections.IEnumerable)val4, "\",\"")), IsJson: true)) : ((JArray)NewLateBinding.LateIndexGet(ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/mods", "POST", "{\"modIds\": [" + ModBase.Join((System.Collections.IEnumerable)val4, ",") + "]}", "application/json")), new object[] { "data" }, (string[])null)));
			System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator2 = jArray3.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator2).MoveNext())
				{
					JToken current2 = enumerator2.Current;
					new CompProject((JObject)current2);
				}
			}
			finally
			{
				((System.IDisposable)enumerator2)?.Dispose();
			}
		}
		if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val))
		{
			System.Collections.Generic.IEnumerator<CompProject> enumerator3 = default(System.Collections.Generic.IEnumerator<CompProject>);
			try
			{
				enumerator3 = Enumerable.Select<string, CompProject>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)val, (Func<string, bool>)([SpecialName] (string id) => CompProjectCache.ContainsKey(id))), (Func<string, CompProject>)([SpecialName] (string id) => CompProjectCache[id])).GetEnumerator();
				System.Collections.Generic.IEnumerator<CompFile> enumerator4 = default(System.Collections.Generic.IEnumerator<CompFile>);
				while (((System.Collections.IEnumerator)enumerator3).MoveNext())
				{
					CompProject current3 = enumerator3.Current;
					try
					{
						enumerator4 = CompFilesCache[ProjectId].GetEnumerator();
						while (enumerator4.MoveNext())
						{
							CompFile current4 = enumerator4.Current;
							if (current4.RawDependencies.Contains(current3.Id) && Operators.CompareString(current3.Id, ProjectId, false) != 0 && !current4.Dependencies.Contains(current3.Id))
							{
								current4.Dependencies.Add(current3.Id);
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator4).Dispose();
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator3)?.Dispose();
			}
		}
		if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val3))
		{
			System.Collections.Generic.IEnumerator<CompProject> enumerator5 = default(System.Collections.Generic.IEnumerator<CompProject>);
			try
			{
				enumerator5 = Enumerable.Select<string, CompProject>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)val3, (Func<string, bool>)([SpecialName] (string id) => CompProjectCache.ContainsKey(id))), (Func<string, CompProject>)([SpecialName] (string id) => CompProjectCache[id])).GetEnumerator();
				System.Collections.Generic.IEnumerator<CompFile> enumerator6 = default(System.Collections.Generic.IEnumerator<CompFile>);
				while (((System.Collections.IEnumerator)enumerator5).MoveNext())
				{
					CompProject current5 = enumerator5.Current;
					try
					{
						enumerator6 = CompFilesCache[ProjectId].GetEnumerator();
						while (enumerator6.MoveNext())
						{
							CompFile current6 = enumerator6.Current;
							if (current6.RawOptionalDependencies.Contains(current5.Id) && Operators.CompareString(current5.Id, ProjectId, false) != 0 && !current6.OptionalDependencies.Contains(current5.Id))
							{
								current6.OptionalDependencies.Add(current5.Id);
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator6).Dispose();
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator5)?.Dispose();
			}
		}
		return CompFilesCache[ProjectId];
	}

	public static void CompFilesCardPreload(StackPanel Stack, List<CompFile> Files)
	{
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Expected O, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		List<string> val = Enumerable.ToList<string>(Enumerable.Distinct<string>(Enumerable.SelectMany<CompFile, string>((System.Collections.Generic.IEnumerable<CompFile>)Files, (Func<CompFile, System.Collections.Generic.IEnumerable<string>>)([SpecialName] (CompFile f) => (System.Collections.Generic.IEnumerable<string>)f.Dependencies))));
		List<string> val2 = Enumerable.ToList<string>(Enumerable.Distinct<string>(Enumerable.SelectMany<CompFile, string>((System.Collections.Generic.IEnumerable<CompFile>)Files, (Func<CompFile, System.Collections.Generic.IEnumerable<string>>)([SpecialName] (CompFile f) => (System.Collections.Generic.IEnumerable<string>)f.OptionalDependencies))));
		if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val) && !Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2))
		{
			return;
		}
		if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val))
		{
			val.Sort();
			val = Enumerable.ToList<string>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)val, (Func<string, bool>)([SpecialName] (string dep) =>
			{
				if (!CompProjectCache.ContainsKey(dep))
				{
					ModBase.Log($"[Comp] 未找到 ID {dep} 的前置信息", ModBase.LogLevel.Debug);
				}
				return CompProjectCache.ContainsKey(dep);
			})));
			((Panel)Stack).Children.Add((UIElement)new TextBlock
			{
				Text = "必要前置资源",
				FontSize = 14.0,
				HorizontalAlignment = (HorizontalAlignment)0,
				Margin = new Thickness(6.0, 2.0, 0.0, 5.0)
			});
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = val.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					MyCompItem myCompItem = CompProjectCache[current].ToCompItem(ShowMcVersionDesc: false, ShowLoaderDesc: false);
					((Panel)Stack).Children.Add((UIElement)(object)myCompItem);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2))
		{
			val2.Sort();
			val2 = Enumerable.ToList<string>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)val2, (Func<string, bool>)([SpecialName] (string dep) =>
			{
				if (!CompProjectCache.ContainsKey(dep))
				{
					ModBase.Log($"[Comp] 未找到 ID {dep} 的前置信息", ModBase.LogLevel.Debug);
				}
				return CompProjectCache.ContainsKey(dep);
			})));
			((Panel)Stack).Children.Add((UIElement)new TextBlock
			{
				Text = "可选前置资源",
				FontSize = 14.0,
				HorizontalAlignment = (HorizontalAlignment)0,
				Margin = new Thickness(6.0, 2.0, 0.0, 5.0)
			});
			System.Collections.Generic.IEnumerator<string> enumerator2 = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator2 = val2.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					string current2 = enumerator2.Current;
					MyCompItem myCompItem2 = CompProjectCache[current2].ToCompItem(ShowMcVersionDesc: false, ShowLoaderDesc: false);
					((Panel)Stack).Children.Add((UIElement)(object)myCompItem2);
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
		}
		((Panel)Stack).Children.Add((UIElement)new TextBlock
		{
			Text = "版本列表",
			FontSize = 14.0,
			HorizontalAlignment = (HorizontalAlignment)0,
			Margin = new Thickness(6.0, 12.0, 0.0, 5.0)
		});
	}
}
