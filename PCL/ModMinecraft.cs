using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.Core.App;
using PCL.Core.UI;
using PCL.Core.Utils;

namespace PCL;

[StandardModule]
public sealed class ModMinecraft
{
	public class McFolder
	{
		public string Name;

		public string Path;

		public McFolderType Type;

		public virtual bool Equals(object obj)
		{
			if (!(obj is McFolder))
			{
				return false;
			}
			McFolder mcFolder = (McFolder)obj;
			return Operators.CompareString(Name, mcFolder.Name, false) == 0 && Operators.CompareString(Path, mcFolder.Path, false) == 0 && Type == mcFolder.Type;
		}

		public virtual string ToString()
		{
			return Path;
		}
	}

	public enum McFolderType
	{
		Original,
		RenamedOriginal,
		Custom
	}

	public class McInstance
	{
		private string _Name;

		public string Info;

		public McInstanceState State;

		public string Logo;

		public bool IsStar;

		public McInstanceCardType DisplayType;

		private McInstanceInfo _Version;

		public System.DateTime ReleaseTime;

		private string _JsonText;

		private JObject _JsonObject;

		private bool JsonVersionInited;

		private JObject _JsonVersion;

		private string _InheritVersion;

		public bool IsLoaded;

		[field: CompilerGenerated]
		public string Path
		{
			[CompilerGenerated]
			get;
		}

		public string PathIndie
		{
			get
			{
				if (ModBase.Setup.IsUnset("VersionArgumentIndieV2", this))
				{
					if (!IsLoaded)
					{
						Load();
					}
					VB_0024AnonymousDelegate_0<bool> vB_0024AnonymousDelegate_ = [SpecialName] [CompilerGenerated] () =>
					{
						//IL_007d: Unknown result type (might be due to invalid IL or missing references)
						//IL_0083: Expected O, but got Unknown
						//IL_0093: Unknown result type (might be due to invalid IL or missing references)
						//IL_0099: Expected O, but got Unknown
						if (!ModBase.Setup.IsUnset("VersionArgumentIndie", this) && Operators.ConditionalCompareObjectGreater(ModBase.Setup.Get("VersionArgumentIndie", this), (object)0, false))
						{
							ModBase.Log($"[Minecraft] 版本隔离初始化（{Name}）：从老的实例独立设置中迁移");
							return Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("VersionArgumentIndie", this), (object)1, false);
						}
						DirectoryInfo val = new DirectoryInfo(Path + "mods\\");
						DirectoryInfo val2 = new DirectoryInfo(Path + "saves\\");
						if ((val.Exists && Enumerable.Any<FileInfo>(val.EnumerateFiles())) || (val2.Exists && Enumerable.Any<DirectoryInfo>(val2.EnumerateDirectories())))
						{
							ModBase.Log($"[Minecraft] 版本隔离初始化（{Name}）：实例文件夹下存在 mods 或 saves 文件夹，自动开启");
							return true;
						}
						bool flag = State != McInstanceState.Fool && State != McInstanceState.Old && State != McInstanceState.Snapshot;
						ModBase.Log(string.Format("[Minecraft] 版本隔离初始化（{0}）：从全局默认设置中（{1}）判断，State {2}，IsRelease {3}，Modable {4}", new object[5]
						{
							Name,
							ModBase.Setup.Get("LaunchArgumentIndieV2"),
							ModBase.GetStringFromEnum(State),
							flag,
							Modable
						}));
						object obj = ModBase.Setup.Get("LaunchArgumentIndieV2");
						if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
						{
							return false;
						}
						if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
						{
							return Version.HasLabyMod || Modable;
						}
						if (Operators.ConditionalCompareObjectEqual(obj, (object)2, false))
						{
							return !flag;
						}
						return !Operators.ConditionalCompareObjectEqual(obj, (object)3, false) || Version.HasLabyMod || Modable || !flag;
					};
					ModBase.Setup.Set("VersionArgumentIndieV2", vB_0024AnonymousDelegate_(), forceReload: false, this);
				}
				if (!Conversions.ToBoolean(ModBase.Setup.Get("VersionArgumentIndieV2", this)))
				{
					return PathMcFolder;
				}
				return Path;
			}
		}

		public string Name
		{
			get
			{
				if (_Name == null && Operators.CompareString(Path, "", false) != 0)
				{
					_Name = ModBase.GetFolderNameFromPath(Path);
				}
				return _Name;
			}
		}

		public bool Modable
		{
			get
			{
				if (!IsLoaded)
				{
					Load();
				}
				if (!Version.HasFabric && !Version.HasLegacyFabric && !Version.HasQuilt && !Version.HasForge && !Version.HasLiteLoader && !Version.HasNeoForge && !Version.HasCleanroom)
				{
					return DisplayType == McInstanceCardType.API;
				}
				return true;
			}
		}

		public McInstanceInfo Version
		{
			get
			{
				if (_Version == null)
				{
					_Version = new McInstanceInfo();
					try
					{
						try
						{
							if (JsonObject["releaseTime"] == null)
							{
								ReleaseTime = new System.DateTime(1970, 1, 1, 15, 0, 0);
							}
							else
							{
								ReleaseTime = JsonObject["releaseTime"].ToObject<System.DateTime>();
							}
							if (ReleaseTime.Year <= 2000 || System.DateTime.Compare(ReleaseTime, new System.DateTime(2011, 11, 16)) > 0)
							{
								goto end_IL_0016;
							}
							_Version.McName = "Old";
							goto end_IL_0016_2;
							end_IL_0016:;
						}
						catch (System.Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ReleaseTime = new System.DateTime(1970, 1, 1, 15, 0, 0);
							ProjectData.ClearProjectError();
						}
						string text2;
						if ((string?)(JsonObject["type"] ?? ((JToken)"")) == "pending")
						{
							_Version.McName = "pending";
						}
						else if (JsonObject["clientVersion"] != null)
						{
							_Version.McName = (string?)JsonObject["clientVersion"];
						}
						else
						{
							if (JsonObject["patches"] != null)
							{
								System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
								try
								{
									enumerator = ((System.Collections.Generic.IEnumerable<JToken>)JsonObject["patches"]).GetEnumerator();
									while (((System.Collections.IEnumerator)enumerator).MoveNext())
									{
										JObject jObject = (JObject)enumerator.Current;
										if (Operators.CompareString((jObject["id"] ?? ((JToken)"")).ToString(), "game", false) != 0 || jObject["version"] == null)
										{
											continue;
										}
										_Version.McName = jObject["version"].ToString();
										goto end_IL_0016_2;
									}
								}
								finally
								{
									((System.IDisposable)enumerator)?.Dispose();
								}
							}
							if (JsonObject["arguments"] != null)
							{
								if (JsonObject["arguments"]["game"] != null)
								{
									bool flag = false;
									System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
									try
									{
										enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)JsonObject["arguments"]["game"]).GetEnumerator();
										while (((System.Collections.IEnumerator)enumerator2).MoveNext())
										{
											JToken current = enumerator2.Current;
											if (!flag)
											{
												if (Operators.CompareString(current.ToString(), "--fml.mcVersion", false) == 0)
												{
													flag = true;
												}
												continue;
											}
											_Version.McName = current.ToString();
											goto end_IL_0016_2;
										}
									}
									finally
									{
										((System.IDisposable)enumerator2)?.Dispose();
									}
								}
								if (JsonObject["arguments"]["jvm"] != null)
								{
									System.Collections.Generic.IEnumerator<JToken> enumerator3 = default(System.Collections.Generic.IEnumerator<JToken>);
									try
									{
										enumerator3 = ((System.Collections.Generic.IEnumerable<JToken>)JsonObject["arguments"]["game"]).GetEnumerator();
										while (((System.Collections.IEnumerator)enumerator3).MoveNext())
										{
											string text = ModBase.RegexSeek(enumerator3.Current.ToString(), "(?<=-Dnet.labymod.running-version=)1.[0-9+.]+", (RegexOptions)0);
											if (text == null)
											{
												continue;
											}
											_Version.McName = text;
											goto end_IL_0016_2;
										}
									}
									finally
									{
										((System.IDisposable)enumerator3)?.Dispose();
									}
								}
							}
							if (Operators.CompareString(InheritInstance, "", false) != 0)
							{
								_Version.McName = (JsonObject["jar"] ?? ((JToken)"")).ToString();
								if (Operators.CompareString(_Version.McName, "", false) == 0)
								{
									_Version.McName = InheritInstance;
								}
							}
							else
							{
								text2 = ModBase.RegexSeek((JsonObject["downloads"] ?? ((JToken)"")).ToString(), "(?<=launcher.mojang.com/mc/game/)[^/]*", (RegexOptions)0);
								if (text2 != null)
								{
									_Version.McName = text2;
								}
								else
								{
									string str = JsonObject["libraries"].ToString();
									text2 = ModBase.RegexSeek(str, "(?<=net.minecraftforge:forge:)1.[0-9+.]+", (RegexOptions)0) ?? ModBase.RegexSeek(str, "(?<=net.minecraftforge:fmlloader:)1.[0-9+.]+", (RegexOptions)0);
									if (text2 != null)
									{
										_Version.McName = text2;
									}
									else
									{
										text2 = ModBase.RegexSeek(str, "(?<=optifine:OptiFine:)1.[0-9+.]+", (RegexOptions)0);
										if (text2 != null)
										{
											_Version.McName = text2;
										}
										else
										{
											text2 = ModBase.RegexSeek(str, "(?<=((fabricmc)|(quiltmc)|(legacyfabric)):intermediary:)[^\"]*", (RegexOptions)0);
											if (text2 != null)
											{
												_Version.McName = text2;
											}
											else if (JsonObject["jar"] != null)
											{
												_Version.McName = JsonObject["jar"].ToString();
											}
											else
											{
												if (JsonVersion?["name"] == null)
												{
													goto IL_04e6;
												}
												string text3 = JsonVersion["name"].ToString();
												if (text3.Length >= 32)
												{
													goto IL_04e6;
												}
												_Version.McName = text3;
												ModBase.Log("[Minecraft] 从版本 jar 中的 version.json 获取到版本号：" + text3);
											}
										}
									}
								}
							}
						}
						goto end_IL_0016_2;
						IL_04e6:
						ModBase.Log("[Minecraft] 无法完全确认 MC 版本号的实例：" + Name);
						text2 = ModBase.RegexSeek(Name, "([0-9w]{5}[a-z]{1})|(1\\.[0-9]+(\\.[0-9]+)?(-(pre|rc)[1-9]?| Pre-Release( [1-9]{1})?)?)", (RegexOptions)1);
						if (text2 != null)
						{
							_Version.McName = text2;
						}
						else
						{
							JObject obj = (JObject)JsonObject.DeepClone();
							obj.Remove("libraries");
							text2 = ModBase.RegexSeek(obj.ToString(), "([0-9w]{5}[a-z]{1})|(1\\.[0-9]+(\\.[0-9]+)?(-(pre|rc)[1-9]?| Pre-Release( [1-9]{1})?)?)", (RegexOptions)1);
							if (text2 != null)
							{
								_Version.McName = text2;
							}
							else
							{
								_Version.McName = "Unknown";
								Info = "PCL 无法识别该实例的 MC 版本号";
							}
						}
						end_IL_0016_2:;
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "识别 Minecraft 版本时出错");
						_Version.McName = "Unknown";
						Info = "无法识别：" + ex2.Message;
						ProjectData.ClearProjectError();
					}
					if (PCLVerCompat.StartsWithVerF(_Version.McName, "1.", ic: false))
					{
						string mcName = _Version.McName;
						char[] array = new char[] { '\x06', '\x00', '\x07', '\x00', '\x08', '\x00', '\t', '\x00', '\n', '\x00', '\x0b', '\x00', '\x0c', '\x00', '\r', '\x00' };
						string[] array2 = mcName.Split(array);
						string text4 = ((Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)array2) >= 2) ? array2[1] : "0");
						_Version.McCodeMain = Conversions.ToInteger((text4.Length <= 2) ? ((object)ModBase.Val(text4)) : "0");
						text4 = ((Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)array2) >= 3) ? array2[2] : "0");
						_Version.McCodeSub = Conversions.ToInteger((text4.Length <= 2) ? ((object)ModBase.Val(text4)) : "0");
					}
					else if (!IsVersionNameLikeRelease(_Version.McName) || Operators.CompareString(_Version.McName, "pending", false) == 0)
					{
						_Version.McCodeMain = 99;
						_Version.McCodeSub = 99;
					}
				}
				return _Version;
			}
			set
			{
				_Version = value;
			}
		}

		public string JsonText
		{
			get
			{
				VB_0024AnonymousDelegate_11<string, bool> vB_0024AnonymousDelegate_ = [SpecialName] (string Json) =>
				{
					string str = Json.Trim();
					return ModBase.StartsWithF(str, "{") && ModBase.EndsWithF(str, "}");
				};
				if (_JsonText == null)
				{
					string text = Path + Name + ".json";
					if (!File.Exists(text))
					{
						string[] files = Directory.GetFiles(Path, "*.json");
						if (Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)files) != 1)
						{
							throw new System.Exception($"未找到实例 JSON 文件：{Path}{Name}.json");
						}
						text = files[0];
						ModBase.Log("[Minecraft] 未找到同名实例 JSON，自动换用 " + text, ModBase.LogLevel.Debug);
					}
					_JsonText = ModBase.ReadFile(text);
					if (!vB_0024AnonymousDelegate_(_JsonText))
					{
						if (ModBase.RunInUi())
						{
							ModBase.Log("[Minecraft] 实例 JSON 文件为空或有误，由于代码在主线程运行，将不再进行重试", ModBase.LogLevel.Debug);
							ModBase.GetJson(_JsonText);
						}
						else
						{
							ModBase.Log($"[Minecraft] 实例 JSON 文件为空或有误，将在 2s 后重试读取（{text}）", ModBase.LogLevel.Debug);
							Thread.Sleep(2000);
							_JsonText = ModBase.ReadFile(text);
							if (!vB_0024AnonymousDelegate_(_JsonText))
							{
								ModBase.GetJson(_JsonText);
							}
						}
					}
				}
				return _JsonText;
			}
			set
			{
				_JsonText = value;
			}
		}

		public JObject JsonObject
		{
			get
			{
				//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
				if (_JsonObject == null)
				{
					string jsonText = JsonText;
					try
					{
						_JsonObject = (JObject)ModBase.GetJson(jsonText);
						if (_JsonObject.ContainsKey("patches") && !_JsonObject.ContainsKey("time"))
						{
							IsHmclFormatJson = true;
							JObject jObject = null;
							List<JObject> val = new List<JObject>();
							System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
							try
							{
								enumerator = ((System.Collections.Generic.IEnumerable<JToken>)_JsonObject["patches"]).GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator).MoveNext())
								{
									JObject jObject2 = (JObject)enumerator.Current;
									val.Add(jObject2);
								}
							}
							finally
							{
								((System.IDisposable)enumerator)?.Dispose();
							}
							ModBase.Sort((System.Collections.Generic.IList<JObject>)val, [SpecialName] (JObject left, JObject right) => ModBase.Val((left["priority"] ?? ((JToken)"0")).ToString()) < ModBase.Val((right["priority"] ?? ((JToken)"0")).ToString()));
							System.Collections.Generic.IEnumerator<JObject> enumerator2 = default(System.Collections.Generic.IEnumerator<JObject>);
							try
							{
								enumerator2 = val.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									JObject current = enumerator2.Current;
									string text = (string?)current["id"];
									if (text != null)
									{
										ModBase.Log("[Minecraft] 合并 HMCL 分支项：" + text);
										if (jObject != null)
										{
											jObject.Merge(current);
										}
										else
										{
											jObject = current;
										}
									}
									else
									{
										ModBase.Log("[Minecraft] 存在为空的 HMCL 分支项");
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator2).Dispose();
							}
							_JsonObject = jObject;
							_JsonObject["id"] = Name;
							if (_JsonObject.ContainsKey("inheritsFrom"))
							{
								_JsonObject.Remove("inheritsFrom");
							}
						}
						object obj = null;
						try
						{
							obj = ((_JsonObject["inheritsFrom"] == null) ? "" : _JsonObject["inheritsFrom"].ToString());
							if (Operators.ConditionalCompareObjectEqual(obj, (object)Name, false))
							{
								ModBase.Log("[Minecraft] 自引用的继承实例：" + Name, ModBase.LogLevel.Debug);
								obj = "";
							}
							else
							{
								while (Operators.ConditionalCompareObjectNotEqual(obj, (object)"", false))
								{
									McInstance mcInstance = new McInstance(Conversions.ToString(obj));
									if (Operators.ConditionalCompareObjectEqual((object)mcInstance.InheritInstance, obj, false))
									{
										throw new System.Exception(Conversions.ToString(Operators.ConcatenateObject((object)"版本依赖项出现嵌套：", obj)));
									}
									obj = mcInstance.InheritInstance;
									mcInstance.JsonObject.Merge(_JsonObject);
									_JsonObject = mcInstance.JsonObject;
								}
							}
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							ModBase.Log(ex2, "合并实例依赖项 JSON 失败（" + (obj ?? "null").ToString() + "）");
							ProjectData.ClearProjectError();
						}
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						throw new System.Exception("初始化实例 JSON 时失败（" + (Name ?? "null") + "）", ex4);
					}
				}
				return _JsonObject;
			}
			set
			{
				_JsonObject = value;
			}
		}

		public bool IsOldJson
		{
			get
			{
				if (JsonObject["minecraftArguments"] != null)
				{
					return (string?)JsonObject["minecraftArguments"] != "";
				}
				return false;
			}
		}

		[field: CompilerGenerated]
		public bool IsHmclFormatJson
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public JObject JsonVersion
		{
			get
			{
				//IL_004b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0055: Expected O, but got Unknown
				//IL_0050: Unknown result type (might be due to invalid IL or missing references)
				//IL_0056: Expected O, but got Unknown
				//IL_006b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0071: Expected O, but got Unknown
				if (!JsonVersionInited)
				{
					JsonVersionInited = true;
					if (File.Exists(Path + Name + ".jar"))
					{
						try
						{
							ZipArchive val = new ZipArchive((Stream)new FileStream(Path + Name + ".jar", (FileMode)3, (FileAccess)1, (FileShare)3));
							try
							{
								ZipArchiveEntry entry = val.GetEntry("version.json");
								if (entry != null)
								{
									StreamReader val2 = new StreamReader(entry.Open());
									try
									{
										_JsonVersion = (JObject)ModBase.GetJson(val2.ReadToEnd());
									}
									finally
									{
										((System.IDisposable)val2)?.Dispose();
									}
								}
							}
							finally
							{
								((System.IDisposable)val)?.Dispose();
							}
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							ModBase.Log(ex2, "从实例 JAR 中读取 version.json 失败");
							ProjectData.ClearProjectError();
						}
					}
				}
				return _JsonVersion;
			}
		}

		public string InheritInstance
		{
			get
			{
				if (_InheritVersion == null)
				{
					_InheritVersion = (JsonObject["inheritsFrom"] ?? ((JToken)"")).ToString();
					if (JsonText.Contains("liteloader") && Operators.CompareString(Version.McName, Name, false) != 0 && !JsonText.Contains("logging") && Operators.CompareString((JsonObject["jar"] ?? ((JToken)Version.McName)).ToString(), Version.McName, false) == 0)
					{
						_InheritVersion = Version.McName;
					}
					if (IsHmclFormatJson)
					{
						_InheritVersion = "";
					}
				}
				return _InheritVersion;
			}
		}

		public McInstance(string Path)
		{
			_Name = null;
			Info = "该实例未被加载，请向作者反馈此问题";
			State = McInstanceState.Error;
			IsStar = false;
			DisplayType = McInstanceCardType.Auto;
			_Version = null;
			ReleaseTime = new System.DateTime(1970, 1, 1, 15, 0, 0);
			_JsonText = null;
			_JsonObject = null;
			IsHmclFormatJson = false;
			JsonVersionInited = false;
			_JsonVersion = null;
			_InheritVersion = null;
			IsLoaded = false;
			this.Path = (Path.Contains(":") ? "" : (PathMcFolder + "versions\\")) + Path + (ModBase.EndsWithF(Path, "\\") ? "" : "\\");
		}

		public bool Check()
		{
			bool result;
			if (!Directory.Exists(Path))
			{
				State = McInstanceState.Error;
				Info = "未找到实例 " + Name;
				result = false;
			}
			else
			{
				try
				{
					Directory.CreateDirectory(Path + "PCL\\");
					ModBase.CheckPermissionWithException(Path + "PCL\\");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					State = McInstanceState.Error;
					Info = "PCL 没有对该文件夹的访问权限，请右键以管理员身份运行 PCL";
					ModBase.Log(ex2, "没有访问实例文件夹的权限");
					result = false;
					ProjectData.ClearProjectError();
					goto IL_01cd;
				}
				try
				{
					_ = JsonObject;
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, "实例 JSON 可用性检查失败（" + Path + "）");
					JsonText = "";
					JsonObject = null;
					Info = ex4.Message;
					State = McInstanceState.Error;
					result = false;
					ProjectData.ClearProjectError();
					goto IL_01cd;
				}
				try
				{
					if (Operators.CompareString(InheritInstance, "", false) != 0 && !File.Exists(string.Concat(new string[5]
					{
						ModBase.GetPathFromFullPath(Path),
						InheritInstance,
						"\\",
						InheritInstance,
						".json"
					})))
					{
						State = McInstanceState.Error;
						Info = "需要安装 " + InheritInstance + " 作为前置实例";
						result = false;
						goto IL_01cd;
					}
				}
				catch (System.Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					System.Exception ex6 = ex5;
					ModBase.Log(ex6, "依赖实例检查出错（" + Name + "）");
					State = McInstanceState.Error;
					Info = "未知错误：" + ex6.ToString();
					result = false;
					ProjectData.ClearProjectError();
					goto IL_01cd;
				}
				State = McInstanceState.Original;
				result = true;
			}
			goto IL_01cd;
			IL_01cd:
			return result;
		}

		public McInstance Load()
		{
			try
			{
				if (Check())
				{
					string mcName = Version.McName;
					if (Operators.CompareString(mcName, "Unknown", false) != 0)
					{
						if (Operators.CompareString(mcName, "Old", false) == 0)
						{
							State = McInstanceState.Old;
						}
						else
						{
							string text = (((object)JsonObject) ?? ((object)JsonText)).ToString();
							if (Operators.CompareString((JsonObject["type"] ?? ((JToken)"")).ToString(), "fool", false) == 0 || Operators.CompareString(GetMcFoolName(Version.McName), "", false) != 0)
							{
								State = McInstanceState.Fool;
							}
							else if (ModBase.ContainsF(Version.McName, "w", IgnoreCase: true) || ModBase.ContainsF(Name, "combat", IgnoreCase: true) || ModBase.ContainsF(Version.McName, "rc", IgnoreCase: true) || ModBase.ContainsF(Version.McName, "pre", IgnoreCase: true) || ModBase.ContainsF(Version.McName, "experimental", IgnoreCase: true) || Operators.CompareString((JsonObject["type"] ?? ((JToken)"")).ToString(), "snapshot", false) == 0 || Operators.CompareString((JsonObject["type"] ?? ((JToken)"")).ToString(), "pending", false) == 0)
							{
								State = McInstanceState.Snapshot;
							}
							if (text.Contains("optifine"))
							{
								State = McInstanceState.OptiFine;
								Version.HasOptiFine = true;
								Version.OptiFineVersion = ModBase.RegexSeek(text, "(?<=HD_U_)[^\":/]+", (RegexOptions)0) ?? "未知版本";
							}
							if (text.Contains("liteloader"))
							{
								State = McInstanceState.LiteLoader;
								Version.HasLiteLoader = true;
							}
							if (text.Contains("labymod_data"))
							{
								State = McInstanceState.LabyMod;
								Version.HasLabyMod = true;
								Version.LabyModVersion = (string?)JsonObject["labymod_data"]["version"];
							}
							else if (text.Contains("net.legacyfabric:intermediary"))
							{
								State = McInstanceState.LegacyFabric;
								Version.HasLegacyFabric = true;
								Version.LegacyFabricVersion = (ModBase.RegexSeek(text, "(?<=(net.fabricmc:fabric-loader:))[0-9\\.]+(\\+build.[0-9]+)?", (RegexOptions)0) ?? "未知版本").Replace("+build", "");
							}
							else if (text.Contains("net.fabricmc:fabric-loader"))
							{
								State = McInstanceState.Fabric;
								Version.HasFabric = true;
								Version.FabricVersion = (ModBase.RegexSeek(text, "(?<=(net.fabricmc:fabric-loader:))[0-9\\.]+(\\+build.[0-9]+)?", (RegexOptions)0) ?? "未知版本").Replace("+build", "");
							}
							else if (text.Contains("org.quiltmc:quilt-loader"))
							{
								State = McInstanceState.Quilt;
								Version.HasQuilt = true;
								Version.QuiltVersion = (ModBase.RegexSeek(text, "(?<=(org.quiltmc:quilt-loader:))[0-9\\.]+(\\+build.[0-9]+)?((-beta.)[0-9]([0-9]?))", (RegexOptions)0) ?? "未知版本").Replace("+build", "");
							}
							else if (text.Contains("com.cleanroommc:cleanroom:"))
							{
								State = McInstanceState.Cleanroom;
								Version.HasCleanroom = true;
								Version.CleanroomVersion = (ModBase.RegexSeek(text, "(?<=(com.cleanroommc:cleanroom:))[0-9\\.]+(\\+build.[0-9]+)?(-alpha)?", (RegexOptions)0) ?? "未知版本").Replace("+build", "");
							}
							else if (text.Contains("minecraftforge") && !text.Contains("net.neoforge"))
							{
								State = McInstanceState.Forge;
								Version.HasForge = true;
								Version.ForgeVersion = ModBase.RegexSeek(text, "(?<=forge:[0-9\\.]+(_pre[0-9]*)?\\-)[0-9\\.]+", (RegexOptions)0);
								if (Version.ForgeVersion == null)
								{
									Version.ForgeVersion = ModBase.RegexSeek(text, "(?<=net\\.minecraftforge:minecraftforge:)[0-9\\.]+", (RegexOptions)0);
								}
								if (Version.ForgeVersion == null)
								{
									Version.ForgeVersion = ModBase.RegexSeek(text, "(?<=net\\.minecraftforge:fmlloader:[0-9\\.]+-)[0-9\\.]+", (RegexOptions)0) ?? "未知版本";
								}
							}
							else if (text.Contains("net.neoforge"))
							{
								State = McInstanceState.NeoForge;
								Version.HasNeoForge = true;
								Version.NeoForgeVersion = ModBase.RegexSeek(text, "(?<=orgeVersion\",[^\"]*?\")[^\"]+(?=\",)", (RegexOptions)0) ?? "未知版本";
							}
							Version.IsApiLoaded = true;
						}
					}
					else
					{
						State = McInstanceState.Error;
					}
				}
				Logo = Config.Instance.LogoPath[Path];
				if (Operators.CompareString(Logo, "", false) == 0 || !Config.Instance.IsLogoCustom[Path])
				{
					switch (State)
					{
					case McInstanceState.Original:
						Logo = ModBase.PathImage + "Blocks/Grass.png";
						break;
					case McInstanceState.Snapshot:
						Logo = ModBase.PathImage + "Blocks/CommandBlock.png";
						break;
					case McInstanceState.Old:
						Logo = ModBase.PathImage + "Blocks/CobbleStone.png";
						break;
					case McInstanceState.Forge:
						Logo = ModBase.PathImage + "Blocks/Anvil.png";
						break;
					case McInstanceState.NeoForge:
						Logo = ModBase.PathImage + "Blocks/NeoForge.png";
						break;
					case McInstanceState.Cleanroom:
						Logo = ModBase.PathImage + "Blocks/Cleanroom.png";
						break;
					case McInstanceState.Fabric:
						Logo = ModBase.PathImage + "Blocks/Fabric.png";
						break;
					case McInstanceState.LegacyFabric:
						Logo = ModBase.PathImage + "Blocks/Fabric.png";
						break;
					case McInstanceState.Quilt:
						Logo = ModBase.PathImage + "Blocks/Quilt.png";
						break;
					case McInstanceState.OptiFine:
						Logo = ModBase.PathImage + "Blocks/GrassPath.png";
						break;
					case McInstanceState.LiteLoader:
						Logo = ModBase.PathImage + "Blocks/Egg.png";
						break;
					case McInstanceState.Fool:
						Logo = ModBase.PathImage + "Blocks/GoldBlock.png";
						break;
					case McInstanceState.LabyMod:
						Logo = ModBase.PathImage + "Blocks/LabyMod.png";
						break;
					default:
						Logo = ModBase.PathImage + "Blocks/RedstoneBlock.png";
						break;
					}
				}
				if (State == McInstanceState.Error)
				{
					Info = Info;
				}
				else
				{
					Info = Config.Instance.CustomInfo[Path];
					if (Operators.CompareString(Info, GetDefaultDescription(), false) == 0)
					{
						Info = "";
					}
				}
				IsStar = Config.Instance.Starred[Path];
				DisplayType = (McInstanceCardType)Config.Instance.CardType[Path];
				if (Directory.Exists(Path))
				{
					Config.Instance.State[Path] = (int)State;
					Config.Instance.Info[Path] = Info;
					Config.Instance.LogoPath[Path] = Logo;
				}
				if (State != 0)
				{
					Config.Instance.ReleaseTime[Path] = ReleaseTime.ToString("yyyy'-'MM'-'dd HH':'mm");
					Config.Instance.FabricVersion[Path] = Version.FabricVersion;
					Config.Instance.LegacyFabricVersion[Path] = Version.LegacyFabricVersion;
					Config.Instance.QuiltVersion[Path] = Version.QuiltVersion;
					Config.Instance.LabyModVersion[Path] = Version.LabyModVersion;
					Config.Instance.OptiFineVersion[Path] = Version.OptiFineVersion;
					Config.Instance.HasLiteLoader[Path] = Version.HasLiteLoader;
					Config.Instance.ForgeVersion[Path] = Version.ForgeVersion;
					Config.Instance.NeoForgeVersion[Path] = Version.NeoForgeVersion;
					Config.Instance.CleanroomVersion[Path] = Version.CleanroomVersion;
					Config.Instance.SortCode[Path] = Version.SortCode;
					Config.Instance.McVersion[Path] = Version.McName;
					Config.Instance.VersionMajor[Path] = Version.McCodeMain;
					Config.Instance.VersionMinor[Path] = Version.McCodeSub;
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				Info = "未知错误：" + ex2.ToString();
				Logo = ModBase.PathImage + "Blocks/RedstoneBlock.png";
				State = McInstanceState.Error;
				ModBase.Log(ex2, "加载实例失败（" + Name + "）", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
			finally
			{
				IsLoaded = true;
			}
			return this;
		}

		public string GetDefaultDescription()
		{
			string text = "";
			switch (State)
			{
			case McInstanceState.Snapshot:
				text = ((!ModBase.ContainsF(Version.McName, "pre", IgnoreCase: true)) ? ((!ModBase.ContainsF(Version.McName, "rc", IgnoreCase: true)) ? ((!Version.McName.Contains("experimental") && Operators.CompareString(Version.McName, "pending", false) != 0) ? ("快照 " + Version.McName) : "实验性快照") : ("发布候选 " + Version.McName)) : ("预发布版 " + Version.McName));
				break;
			case McInstanceState.Old:
				text = "远古版本";
				break;
			case McInstanceState.Original:
			case McInstanceState.OptiFine:
			case McInstanceState.Forge:
			case McInstanceState.NeoForge:
			case McInstanceState.LiteLoader:
			case McInstanceState.Fabric:
			case McInstanceState.LegacyFabric:
			case McInstanceState.Quilt:
			case McInstanceState.Cleanroom:
			case McInstanceState.LabyMod:
				text = Version.ToString();
				break;
			case McInstanceState.Fool:
				text = GetMcFoolName(Version.McName);
				break;
			case McInstanceState.Error:
				return Info;
			default:
				text = "发生了未知错误，请向作者反馈此问题";
				break;
			}
			return text;
		}

		public virtual bool Equals(object obj)
		{
			if (obj is McInstance mcInstance)
			{
				return Operators.CompareString(Path, mcInstance.Path, false) == 0;
			}
			return false;
		}

		public static bool operator ==(McInstance a, McInstance b)
		{
			if ((object)a == null && (object)b == null)
			{
				return true;
			}
			if ((object)a == null || (object)b == null)
			{
				return false;
			}
			return Operators.CompareString(a.Path, b.Path, false) == 0;
		}

		public static bool operator !=(McInstance a, McInstance b)
		{
			return !(a == b);
		}
	}

	public enum McInstanceState
	{
		Error,
		Original,
		Snapshot,
		Fool,
		OptiFine,
		Old,
		Forge,
		NeoForge,
		LiteLoader,
		Fabric,
		LegacyFabric,
		Quilt,
		Cleanroom,
		LabyMod
	}

	public class McInstanceInfo
	{
		public bool IsApiLoaded;

		public string McName;

		public int McCodeMain;

		public int McCodeSub;

		public bool HasOptiFine;

		public string OptiFineVersion;

		public bool HasForge;

		public string ForgeVersion;

		public bool HasNeoForge;

		public string NeoForgeVersion;

		public bool HasCleanroom;

		public string CleanroomVersion;

		public bool HasFabric;

		public string FabricVersion;

		public bool HasLegacyFabric;

		public string LegacyFabricVersion;

		public bool HasQuilt;

		public string QuiltVersion;

		public bool HasLabyMod;

		public string LabyModVersion;

		public bool HasLiteLoader;

		private int _SortCode;

		public bool IsStandardVersion
		{
			get
			{
				if (McCodeMain > -1 && McCodeMain < 99 && McCodeSub > -1)
				{
					return McCodeSub < 99;
				}
				return false;
			}
		}

		public Version McInstance
		{
			get
			{
				//IL_0020: Unknown result type (might be due to invalid IL or missing references)
				//IL_0026: Expected O, but got Unknown
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0011: Expected O, but got Unknown
				if (!IsStandardVersion)
				{
					return new Version(0, 0, 0);
				}
				return new Version(1, McCodeMain, McCodeSub);
			}
		}

		public int SortCode
		{
			get
			{
				checked
				{
					if (_SortCode == -2)
					{
						try
						{
							if (HasLegacyFabric)
							{
								if (Operators.CompareString(LegacyFabricVersion, "未知版本", false) == 0)
								{
									return 0;
								}
								string[] array = FabricVersion.Split(".", (StringSplitOptions)0);
								if (array.Length < 3)
								{
									throw new System.Exception("无效的 LegacyFabric 版本：" + LegacyFabricVersion);
								}
								_SortCode = (int)Math.Round(ModBase.Val(array[0]) * 10000.0 + ModBase.Val(array[1]) * 100.0 + ModBase.Val(array[2]));
							}
							else if (HasFabric)
							{
								if (Operators.CompareString(FabricVersion, "未知版本", false) == 0)
								{
									return 0;
								}
								string[] array2 = FabricVersion.Split(".", (StringSplitOptions)0);
								if (array2.Length < 3)
								{
									throw new System.Exception("无效的 Fabric 版本：" + FabricVersion);
								}
								_SortCode = (int)Math.Round(ModBase.Val(array2[0]) * 10000.0 + ModBase.Val(array2[1]) * 100.0 + ModBase.Val(array2[2]));
							}
							else if (HasQuilt)
							{
								if (Operators.CompareString(QuiltVersion, "未知版本", false) == 0)
								{
									return 0;
								}
								bool flag = QuiltVersion.Contains("-beta");
								string[] array3 = QuiltVersion.Replace("-beta", "").Split(".", (StringSplitOptions)0);
								if (array3.Length < 3)
								{
									throw new System.Exception("无效的 Quilt 版本：" + QuiltVersion);
								}
								_SortCode = (int)Math.Round(ModBase.Val(array3[0]) * 10000.0 + ModBase.Val(array3[1]) * 100.0 + ModBase.Val(array3[2]) + (double)unchecked(0 - (flag ? 1 : 0)));
							}
							else if (HasCleanroom)
							{
								if (Operators.CompareString(CleanroomVersion, "未知版本", false) == 0)
								{
									return 0;
								}
								bool flag2 = CleanroomVersion.Contains("-alpha");
								string[] array4 = CleanroomVersion.Replace("-alpha", "").Split(".", (StringSplitOptions)0);
								if (array4.Length < 3)
								{
									throw new System.Exception("无效的 Cleanroom 版本：" + CleanroomVersion);
								}
								_SortCode = (int)Math.Round(ModBase.Val(array4[0]) * 10000.0 + ModBase.Val(array4[1]) * 100.0 + ModBase.Val(array4[2]) + (double)unchecked(0 - (flag2 ? 1 : 0)));
							}
							else if (HasForge || HasNeoForge)
							{
								if (Operators.CompareString(ForgeVersion, "未知版本", false) == 0 && Operators.CompareString(NeoForgeVersion, "未知版本", false) == 0)
								{
									return 0;
								}
								string[] array5 = (HasForge ? ForgeVersion.Split(".", (StringSplitOptions)0) : NeoForgeVersion.Split(".", (StringSplitOptions)0));
								if (array5.Length == 4)
								{
									_SortCode = (int)Math.Round(ModBase.Val(array5[0]) * 1000000.0 + ModBase.Val(array5[1]) * 10000.0 + ModBase.Val(array5[3]));
								}
								else
								{
									if (array5.Length != 3)
									{
										throw new System.Exception("无效的 Neo/Forge 版本：" + ForgeVersion);
									}
									_SortCode = (int)Math.Round(ModBase.Val(array5[0]) * 1000000.0 + ModBase.Val(array5[1]) * 10000.0 + ModBase.Val(array5[2]));
								}
							}
							else if (HasLabyMod)
							{
								if (Operators.CompareString(LabyModVersion, "未知版本", false) == 0)
								{
									return 0;
								}
								string[] array6 = LabyModVersion.Split(".", (StringSplitOptions)0);
								if (array6.Length == 4)
								{
									_SortCode = (int)Math.Round(ModBase.Val(array6[0]) * 1000000.0 + ModBase.Val(array6[1]) * 10000.0 + ModBase.Val(array6[3]));
								}
								else
								{
									if (array6.Length != 3)
									{
										throw new System.Exception("无效的 LabyMod 版本：" + LabyModVersion);
									}
									_SortCode = (int)Math.Round(ModBase.Val(array6[0]) * 1000000.0 + ModBase.Val(array6[1]) * 10000.0 + ModBase.Val(array6[2]));
								}
							}
							else if (HasOptiFine)
							{
								if (Operators.CompareString(OptiFineVersion, "未知版本", false) == 0)
								{
									return 0;
								}
								_SortCode = (int)Math.Round((double)(((McCodeSub >= 0) ? McCodeSub : 0) * 1000000 + (Strings.Asc(Conversions.ToChar(Strings.Left(OptiFineVersion.ToUpper(), 1))) - 65 + 1) * 10000) + ModBase.Val(ModBase.RegexSeek(Strings.Right(OptiFineVersion, OptiFineVersion.Length - 1), "[0-9]+", (RegexOptions)0)) * 100.0);
								if (ModBase.ContainsF(OptiFineVersion, "pre", IgnoreCase: true))
								{
									_SortCode += 50;
								}
								if (ModBase.ContainsF(OptiFineVersion, "pre", IgnoreCase: true) || ModBase.ContainsF(OptiFineVersion, "beta", IgnoreCase: true))
								{
									if (ModBase.Val(Strings.Right(OptiFineVersion, 1)) == 0.0 && Operators.CompareString(Strings.Right(OptiFineVersion, 1), "0", false) != 0)
									{
										_SortCode++;
									}
									else
									{
										ref int sortCode = ref _SortCode;
										sortCode = (int)Math.Round((double)sortCode + ModBase.Val(ModBase.RegexSeek(OptiFineVersion.ToLower(), "(?<=((pre)|(beta)))[0-9]+", (RegexOptions)0)));
									}
								}
								else
								{
									_SortCode += 99;
								}
							}
							else
							{
								_SortCode = -1;
							}
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							_SortCode = -1;
							ModBase.Log(ex2, "获取 API 版本信息失败：" + ToString());
							ProjectData.ClearProjectError();
						}
					}
					return _SortCode;
				}
			}
			set
			{
				_SortCode = value;
			}
		}

		public McInstanceInfo()
		{
			IsApiLoaded = false;
			McCodeMain = -1;
			McCodeSub = -1;
			HasOptiFine = false;
			OptiFineVersion = "";
			HasForge = false;
			ForgeVersion = "";
			HasNeoForge = false;
			NeoForgeVersion = "";
			HasCleanroom = false;
			CleanroomVersion = "";
			HasFabric = false;
			FabricVersion = "";
			HasLegacyFabric = false;
			LegacyFabricVersion = "";
			HasQuilt = false;
			QuiltVersion = "";
			HasLabyMod = false;
			LabyModVersion = "";
			HasLiteLoader = false;
			_SortCode = -2;
		}

		public virtual string ToString()
		{
			string text = "";
			if (HasForge)
			{
				text = text + ", Forge" + ((Operators.CompareString(ForgeVersion, "未知版本", false) == 0) ? "" : (" " + ForgeVersion));
			}
			if (HasNeoForge)
			{
				text = text + ", NeoForge" + ((Operators.CompareString(NeoForgeVersion, "未知版本", false) == 0) ? "" : (" " + NeoForgeVersion));
			}
			if (HasCleanroom)
			{
				text = text + ", Cleanroom" + ((Operators.CompareString(CleanroomVersion, "未知版本", false) == 0) ? "" : (" " + CleanroomVersion));
			}
			if (HasFabric)
			{
				text = text + ", Fabric" + ((Operators.CompareString(FabricVersion, "未知版本", false) == 0) ? "" : (" " + FabricVersion));
			}
			if (HasLegacyFabric)
			{
				text = text + ", LegacyFabric" + ((Operators.CompareString(LegacyFabricVersion, "未知版本", false) == 0) ? "" : (" " + LegacyFabricVersion));
			}
			if (HasQuilt)
			{
				text = text + ", Quilt" + ((Operators.CompareString(QuiltVersion, "未知版本", false) == 0) ? "" : (" " + QuiltVersion));
			}
			if (HasLabyMod)
			{
				text = text + ", LabyMod" + ((Operators.CompareString(LabyModVersion, "未知版本", false) == 0) ? "" : (" " + LabyModVersion));
			}
			if (HasOptiFine)
			{
				text = text + ", OptiFine" + ((Operators.CompareString(OptiFineVersion, "未知版本", false) == 0) ? "" : (" " + OptiFineVersion));
			}
			if (HasLiteLoader)
			{
				text += ", LiteLoader";
			}
			if (Operators.CompareString(text, "", false) == 0)
			{
				return "原版 " + McName;
			}
			return McName + text + (ModBase.ModeDebug ? (" (" + Conversions.ToString(SortCode) + "#)") : "");
		}
	}

	public enum McInstanceCardType
	{
		Star = -1,
		Auto,
		Hidden,
		API,
		OriginalLike,
		Rubbish,
		Fool,
		Error
	}

	public struct McSkinInfo
	{
		public bool IsSlim;

		public string LocalFile;

		public bool IsVaild;
	}

	public class McLibToken
	{
		public string LocalPath;

		public long Size;

		public bool IsNatives;

		public string SHA1;

		public bool IsLocal;

		private string _Url;

		public string OriginalName;

		public string Url
		{
			get
			{
				return _Url;
			}
			set
			{
				_Url = (string.IsNullOrWhiteSpace(value) ? null : value);
			}
		}

		public string Name
		{
			get
			{
				if (OriginalName == null)
				{
					return null;
				}
				List<string> obj = new List<string>((System.Collections.Generic.IEnumerable<string>)OriginalName.Split(":", (StringSplitOptions)0));
				obj.RemoveAt(2);
				return ModBase.Join((System.Collections.IEnumerable)obj, ":");
			}
		}

		public McLibToken()
		{
			Size = 0L;
			IsNatives = false;
			SHA1 = null;
			IsLocal = false;
		}

		public virtual string ToString()
		{
			return (IsNatives ? "[Native] " : "") + ModBase.GetString(Size) + " | " + LocalPath;
		}
	}

	private struct McAssetsToken
	{
		public string LocalPath;

		public string SourcePath;

		public long Size;

		public string Hash;

		public string ToString()
		{
			return ModBase.GetString(Size) + " | " + LocalPath;
		}
	}

	public class VersionComparer : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			return VersionSortInteger(x, y);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__25_002D0
	{
		public McInstanceState[] _0024VB_0024Local_Formula;

		public _Closure_0024__25_002D0(_Closure_0024__25_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Formula = arg0._0024VB_0024Local_Formula;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(McInstance v)
		{
			return Enumerable.Contains<McInstanceState>((System.Collections.Generic.IEnumerable<McInstanceState>)_0024VB_0024Local_Formula, v.State);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__26_002D0
	{
		public McInstanceState[] _0024VB_0024Local_Formula;

		public _Closure_0024__26_002D0(_Closure_0024__26_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Formula = arg0._0024VB_0024Local_Formula;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(McInstance v)
		{
			return Enumerable.Contains<McInstanceState>((System.Collections.Generic.IEnumerable<McInstanceState>)_0024VB_0024Local_Formula, v.State);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__48_002D0
	{
		public JToken _0024VB_0024Local_Version;

		public _Closure_0024__48_002D0(_Closure_0024__48_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Version = arg0._0024VB_0024Local_Version;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			ModDownloadLib.McUpdateLogShow(_0024VB_0024Local_Version);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__48_002D1
	{
		public string _0024VB_0024Local_VersionName;

		public _Closure_0024__48_002D1(_Closure_0024__48_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_VersionName = arg0._0024VB_0024Local_VersionName;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			PageDownloadInstall.McVersionWaitingForSelect = _0024VB_0024Local_VersionName;
			ModMain.FrmMain.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadInstall);
		}
	}

	public static string PathMcFolder;

	public static List<McFolder> McFolderList = new List<McFolder>();

	public static ModLoader.LoaderTask<int, int> McFolderListLoader = new ModLoader.LoaderTask<int, int>("Minecraft Folder List", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
	{
		McFolderListLoadSub();
	}, null, (ThreadPriority)3);

	public const int McInstanceCacheVersion = 30;

	private static McInstance _McInstanceCurrent;

	private static object _McInstanceLast = 0;

	public static Dictionary<McInstanceCardType, List<McInstance>> McInstanceList = new Dictionary<McInstanceCardType, List<McInstance>>();

	public static bool McInstanceListForceRefresh = false;

	public static ModLoader.LoaderTask<string, int> McInstanceListLoader = new ModLoader.LoaderTask<string, int>("Minecraft Version List", McInstanceListLoad, null, (ThreadPriority)2)
	{
		ReloadTimeout = 1
	};

	private static bool IsFirstMcInstanceListLoad = true;

	private static readonly object McSkinDownloadLock = RuntimeHelpers.GetObjectValue(new object());

	private static string OSVersion = Environment.OSVersion.Version.ToString();

	public static McInstance McInstanceCurrent
	{
		get
		{
			return _McInstanceCurrent;
		}
		set
		{
			if (!object.ReferenceEquals(RuntimeHelpers.GetObjectValue(_McInstanceLast), (object)value))
			{
				_McInstanceCurrent = value;
				_McInstanceLast = value;
				if ((object)value != null)
				{
					PageDownloadCompDetail.CachedFolder.Clear();
				}
			}
		}
	}

	private static void McFolderListLoadSub()
	{
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			List<McFolder> val = new List<McFolder>();
			foreach (object item in (System.Collections.IEnumerable)NewLateBinding.LateGet(ModBase.Setup.Get("LaunchFolders"), (System.Type)null, "Split", new object[] { "|" }, (string[])null, (System.Type[])null, (bool[])null))
			{
				string text = Conversions.ToString(item);
				if (Operators.CompareString(text, "", false) == 0)
				{
					continue;
				}
				if (!text.Contains(">") || !ModBase.EndsWithF(text, "\\"))
				{
					ModMain.Hint("无效的 Minecraft 文件夹：" + text, ModMain.HintType.Critical);
					continue;
				}
				string name = text.Split(">", (StringSplitOptions)0)[0];
				string text2 = text.Split(">", (StringSplitOptions)0)[1];
				try
				{
					ModBase.CheckPermissionWithException(text2);
					val.Add(new McFolder
					{
						Name = name,
						Path = text2,
						Type = McFolderType.Custom
					});
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModMain.MyMsgBox("失效的 Minecraft 文件夹：\r\n" + text2 + "\r\n\r\n" + ex2.Message, "Minecraft 文件夹失效", "确定", "", "", IsWarn: true);
					ModBase.Log(ex2, $"无法访问 Minecraft 文件夹 {text2}");
					ProjectData.ClearProjectError();
				}
			}
			List<McFolder> val2 = new List<McFolder>();
			List<McFolder> val3 = new List<McFolder>();
			try
			{
				if (Directory.Exists(ModBase.ExePath + "versions\\"))
				{
					val3.Add(new McFolder
					{
						Name = "当前文件夹",
						Path = ModBase.ExePath,
						Type = McFolderType.Original
					});
				}
				DirectoryInfo[] directories = new DirectoryInfo(ModBase.ExePath).GetDirectories();
				foreach (DirectoryInfo val4 in directories)
				{
					if (Directory.Exists(((FileSystemInfo)val4).FullName + "versions\\") || Operators.CompareString(val4.Name, ".minecraft", false) == 0)
					{
						McFolder mcFolder = new McFolder
						{
							Name = val4.Name,
							Path = ((FileSystemInfo)val4).FullName + "\\",
							Type = McFolderType.Original
						};
						val3.Add(mcFolder);
						val2.Add(mcFolder);
					}
				}
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "扫描 PCL 所在文件夹中是否有 MC 文件夹失败");
				ProjectData.ClearProjectError();
			}
			string text3 = Environment.GetFolderPath((System.Environment.SpecialFolder)26) + "\\.minecraft\\";
			if ((!Enumerable.Any<McFolder>((System.Collections.Generic.IEnumerable<McFolder>)val2) || Operators.CompareString(text3, val2[0].Path, false) != 0) && Directory.Exists(text3 + "versions\\"))
			{
				val3.Add(new McFolder
				{
					Name = "官方启动器文件夹",
					Path = text3,
					Type = McFolderType.Original
				});
			}
			ModBase.Log(Conversions.ToString(val.Count) + " 个自定义文件夹，" + Conversions.ToString(val3.Count) + " 个原始文件夹");
			bool flag = false;
			System.Collections.Generic.IEnumerator<McFolder> enumerator2 = default(System.Collections.Generic.IEnumerator<McFolder>);
			try
			{
				enumerator2 = val3.GetEnumerator();
				System.Collections.Generic.IEnumerator<McFolder> enumerator3 = default(System.Collections.Generic.IEnumerator<McFolder>);
				while (enumerator2.MoveNext())
				{
					McFolder current = enumerator2.Current;
					try
					{
						enumerator3 = val.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							McFolder current2 = enumerator3.Current;
							if (Operators.CompareString(current2.Path, current.Path, false) == 0)
							{
								if (Operators.CompareString(current2.Name, current.Name, false) != 0)
								{
									current2.Type = McFolderType.RenamedOriginal;
								}
								else
								{
									current2.Type = McFolderType.Original;
								}
								flag = true;
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator3).Dispose();
					}
					if (!flag)
					{
						val.Add(current);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			List<string> val5 = new List<string>();
			System.Collections.Generic.IEnumerator<McFolder> enumerator4 = default(System.Collections.Generic.IEnumerator<McFolder>);
			try
			{
				enumerator4 = val.GetEnumerator();
				while (enumerator4.MoveNext())
				{
					McFolder current3 = enumerator4.Current;
					val5.Add(current3.Name + ">" + current3.Path);
				}
			}
			finally
			{
				((System.IDisposable)enumerator4).Dispose();
			}
			if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val5))
			{
				val5.Add("");
			}
			ModBase.Setup.Set("LaunchFolders", ModBase.Join((System.Collections.IEnumerable)val5, "|"));
			if (!Enumerable.Any<McFolder>((System.Collections.Generic.IEnumerable<McFolder>)val))
			{
				Directory.CreateDirectory(ModBase.ExePath + ".minecraft\\versions\\");
				val.Add(new McFolder
				{
					Name = "当前文件夹",
					Path = ModBase.ExePath + ".minecraft\\",
					Type = McFolderType.Original
				});
			}
			System.Collections.Generic.IEnumerator<McFolder> enumerator5 = default(System.Collections.Generic.IEnumerator<McFolder>);
			try
			{
				enumerator5 = val.GetEnumerator();
				while (enumerator5.MoveNext())
				{
					McFolderLauncherProfilesJsonCreate(enumerator5.Current.Path);
				}
			}
			finally
			{
				((System.IDisposable)enumerator5).Dispose();
			}
			if (Conversions.ToBoolean(ModBase.Setup.Get("SystemDebugDelay")))
			{
				Thread.Sleep(RandomUtils.NextInt(200, 2000));
			}
			McFolderList = val;
		}
		catch (System.Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			System.Exception ex6 = ex5;
			ModBase.Log(ex6, "加载 Minecraft 文件夹列表失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public static void McFolderLauncherProfilesJsonCreate(string Folder)
	{
		try
		{
			if (!File.Exists(Folder + "launcher_profiles.json"))
			{
				string text = string.Concat(new string[5]
				{
					"{\n    \"profiles\":  {\n        \"PCL\": {\n            \"icon\": \"Grass\",\n            \"name\": \"PCL\",\n            \"lastVersionId\": \"latest-release\",\n            \"type\": \"latest-release\",\n            \"lastUsed\": \"",
					System.DateTime.Now.ToString("yyyy'-'MM'-'dd"),
					"T",
					System.DateTime.Now.ToString("HH':'mm':'ss"),
					".0000Z\"\n        }\n    },\n    \"selectedProfile\": \"PCL\",\n    \"clientToken\": \"23323323323323323323323323323333\"\n}"
				});
				ModBase.WriteFile(Folder + "launcher_profiles.json", text, Append: false, Encoding.GetEncoding("GB18030"));
				ModBase.Log("[Minecraft] 已创建 launcher_profiles.json：" + Folder);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "创建 launcher_profiles.json 失败（" + Folder + "）", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public static string GetMcFoolName(string Name)
	{
		Name = Name.ToLower();
		if (ModBase.StartsWithF(Name, "2.0") || ModBase.StartsWithF(Name, "2point0"))
		{
			string text = "";
			if (Name.EndsWith("red"))
			{
				text = "（红色版本）";
			}
			else if (Name.EndsWith("blue"))
			{
				text = "（蓝色版本）";
			}
			else if (Name.EndsWith("purple"))
			{
				text = "（紫色版本）";
			}
			return "2013 | 这个秘密计划了两年的更新将游戏推向了一个新高度！" + text;
		}
		switch (Name)
		{
		case "15w14a":
			return "2015 | 作为一款全年龄向的游戏，我们需要和平，需要爱与拥抱。";
		case "1.rv-pre1":
			return "2016 | 是时候将现代科技带入 Minecraft 了！";
		case "3d shareware v1.34":
			return "2019 | 我们从地下室的废墟里找到了这个开发于 1994 年的杰作！";
		default:
			if (!ModBase.StartsWithF(Name, "20w14inf"))
			{
				switch (Name)
				{
				case "20w14∞":
					break;
				case "22w13oneblockatatime":
					return "2022 | 一次一个方块更新！迎接全新的挖掘、合成与骑乘玩法吧！";
				case "23w13a_or_b":
					return "2023 | 研究表明：玩家喜欢作出选择——越多越好！";
				case "24w14potato":
					return "2024 | 毒马铃薯一直都被大家忽视和低估，于是我们超级加强了它！";
				case "25w14craftmine":
					return "2025 | 你可以合成任何东西——包括合成你的世界！";
				default:
					return "";
				}
			}
			return "2020 | 我们加入了 20 亿个新的维度，让无限的想象变成了现实！";
		}
	}

	private static void McInstanceListLoad(ModLoader.LoaderTask<string, int> Loader)
	{
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		//IL_0383: Expected O, but got Unknown
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		string input = Loader.Input;
		try
		{
			McInstanceList = new Dictionary<McInstanceCardType, List<McInstance>>();
			List<string> val = new List<string>();
			if (Directory.Exists(input + "versions"))
			{
				try
				{
					DirectoryInfo[] directories = new DirectoryInfo(input + "versions").GetDirectories();
					foreach (DirectoryInfo val2 in directories)
					{
						val.Add(val2.Name);
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					throw new System.Exception("无法读取实例文件夹，可能是由于没有权限（" + input + "versions）", ex2);
				}
			}
			if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val))
			{
				ModBase.WriteIni(input + "PCL.ini", "InstanceCache", "");
				goto IL_016f;
			}
			int num = Convert.ToInt32(decimal.Remainder(new decimal(ModBase.GetHash(Conversions.ToString(30) + "#" + ModBase.Join((System.Collections.IEnumerable)(object)val.ToArray(), "#"))), 2147483646m));
			if (!McInstanceListForceRefresh && ModBase.Val(ModBase.ReadIni(input + "PCL.ini", "InstanceCache")) == (double)num)
			{
				Dictionary<McInstanceCardType, List<McInstance>> val3 = McInstanceListLoadCache(input);
				if (val3 != null)
				{
					McInstanceList = val3;
					goto IL_0169;
				}
			}
			McInstanceListForceRefresh = false;
			ModBase.Log("[Minecraft] 文件夹列表变更，重载所有实例");
			ModBase.WriteIni(input + "PCL.ini", "InstanceCache", Conversions.ToString(num));
			McInstanceList = McInstanceListLoadNoCache(input);
			goto IL_0169;
			IL_0169:
			IsFirstMcInstanceListLoad = false;
			goto IL_016f;
			IL_016f:
			if (Loader.IsAborted)
			{
				return;
			}
			if (Enumerable.Any<KeyValuePair<McInstanceCardType, List<McInstance>>>((System.Collections.Generic.IEnumerable<KeyValuePair<McInstanceCardType, List<McInstance>>>)McInstanceList, (Func<KeyValuePair<McInstanceCardType, List<McInstance>>, bool>)([SpecialName] (KeyValuePair<McInstanceCardType, List<McInstance>> v) => v.Key != McInstanceCardType.Error)))
			{
				string text = ModBase.ReadIni(input + "PCL.ini", "Version");
				if (Operators.CompareString(text, "", false) != 0)
				{
					System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<McInstanceCardType, List<McInstance>>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<McInstanceCardType, List<McInstance>>>);
					try
					{
						enumerator = McInstanceList.GetEnumerator();
						System.Collections.Generic.IEnumerator<McInstance> enumerator2 = default(System.Collections.Generic.IEnumerator<McInstance>);
						while (enumerator.MoveNext())
						{
							KeyValuePair<McInstanceCardType, List<McInstance>> current = enumerator.Current;
							try
							{
								enumerator2 = current.Value.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									McInstance current2 = enumerator2.Current;
									if (Operators.CompareString(current2.Name, text, false) == 0 && current2.State != 0)
									{
										McInstanceCurrent = current2;
										ModBase.Setup.Set("LaunchInstanceSelect", McInstanceCurrent.Name);
										ModBase.Log("[Minecraft] 选择该文件夹储存的 Minecraft 实例：" + McInstanceCurrent.Path);
										return;
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator2).Dispose();
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator).Dispose();
					}
				}
				if (Enumerable.First<KeyValuePair<McInstanceCardType, List<McInstance>>>((System.Collections.Generic.IEnumerable<KeyValuePair<McInstanceCardType, List<McInstance>>>)McInstanceList).Value[0].State != 0)
				{
					McInstanceCurrent = Enumerable.First<KeyValuePair<McInstanceCardType, List<McInstance>>>((System.Collections.Generic.IEnumerable<KeyValuePair<McInstanceCardType, List<McInstance>>>)McInstanceList).Value[0];
					ModBase.Setup.Set("LaunchInstanceSelect", McInstanceCurrent.Name);
					ModBase.Log("[Launch] 自动选择 Minecraft 实例：" + McInstanceCurrent.Path);
				}
			}
			else
			{
				McInstanceCurrent = null;
				ModBase.Setup.Set("LaunchInstanceSelect", "");
				ModBase.Log("[Minecraft] 未找到可用 Minecraft 实例");
			}
			if (Conversions.ToBoolean(ModBase.Setup.Get("SystemDebugDelay")))
			{
				Thread.Sleep(RandomUtils.NextInt(200, 3000));
			}
		}
		catch (ThreadInterruptedException val4)
		{
			ProjectData.SetProjectError((System.Exception)val4);
			ThreadInterruptedException val5 = val4;
			ProjectData.ClearProjectError();
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			ModBase.WriteIni(input + "PCL.ini", "InstanceCache", "");
			ModBase.Log(ex4, "加载 .minecraft 实例列表失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static Dictionary<McInstanceCardType, List<McInstance>> McInstanceListLoadCache(string Path)
	{
		Dictionary<McInstanceCardType, List<McInstance>> val = new Dictionary<McInstanceCardType, List<McInstance>>();
		Dictionary<McInstanceCardType, List<McInstance>> result;
		try
		{
			int num = Conversions.ToInteger(ModBase.ReadIni(Path + "PCL.ini", "CardCount", Conversions.ToString(-1)));
			if (num == -1)
			{
				result = null;
			}
			else
			{
				int num2 = checked(num - 1);
				int num3 = 0;
				while (true)
				{
					if (num3 <= num2)
					{
						McInstanceCardType mcInstanceCardType = (McInstanceCardType)Conversions.ToInteger(ModBase.ReadIni(Path + "PCL.ini", "CardKey" + Conversions.ToString(checked(num3 + 1)), ":"));
						List<McInstance> val2 = new List<McInstance>();
						checked
						{
							string[] array = ModBase.ReadIni(Path + "PCL.ini", "CardValue" + Conversions.ToString(num3 + 1), ":").Split(":", (StringSplitOptions)0);
							int num4 = 0;
							while (true)
							{
								unchecked
								{
									if (num4 < array.Length)
									{
										string text = array[num4];
										if (Operators.CompareString(text, "", false) != 0)
										{
											string text2 = $"{Path}versions\\{text}\\";
											if (File.Exists(text2 + ".pclignore"))
											{
												if (!IsFirstMcInstanceListLoad)
												{
													ModBase.Log("[Minecraft] 跳过要求忽略的项目：" + text2);
													goto IL_056c;
												}
												ModBase.Log("[Minecraft] 清理残留的忽略项目：" + text2);
												File.Delete(text2 + ".pclignore");
											}
											try
											{
												McInstance mcInstance = new McInstance(text2);
												val2.Add(mcInstance);
												mcInstance.Info = Config.Instance.CustomInfo[mcInstance.Path];
												Config.InstanceConfigGroup instance = Config.Instance;
												if (Operators.CompareString(mcInstance.Info, "", false) == 0)
												{
													mcInstance.Info = instance.Info[mcInstance.Path];
												}
												if (!instance.LogoPathConfig.IsDefault(mcInstance.Path))
												{
													mcInstance.Logo = instance.LogoPath[mcInstance.Path];
												}
												if (!instance.ReleaseTimeConfig.IsDefault(mcInstance.Path))
												{
													mcInstance.ReleaseTime = Conversions.ToDate(instance.ReleaseTime[mcInstance.Path]);
												}
												if (!instance.StateConfig.IsDefault(mcInstance.Path))
												{
													mcInstance.State = (McInstanceState)instance.State[mcInstance.Path];
												}
												mcInstance.IsStar = instance.Starred[mcInstance.Path];
												mcInstance.DisplayType = (McInstanceCardType)instance.CardType[mcInstance.Path];
												if (mcInstance.State != 0 && !instance.McVersionConfig.IsDefault(mcInstance.Path))
												{
													McInstanceInfo mcInstanceInfo = new McInstanceInfo
													{
														FabricVersion = instance.FabricVersion[mcInstance.Path],
														LegacyFabricVersion = instance.LegacyFabricVersion[mcInstance.Path],
														QuiltVersion = instance.QuiltVersion[mcInstance.Path],
														ForgeVersion = instance.ForgeVersion[mcInstance.Path],
														LabyModVersion = instance.LabyModVersion[mcInstance.Path],
														NeoForgeVersion = instance.NeoForgeVersion[mcInstance.Path],
														CleanroomVersion = instance.CleanroomVersion[mcInstance.Path],
														OptiFineVersion = instance.OptiFineVersion[mcInstance.Path],
														HasLiteLoader = instance.HasLiteLoader[mcInstance.Path],
														SortCode = instance.SortCode[mcInstance.Path],
														McName = instance.McVersion[mcInstance.Path],
														McCodeMain = instance.VersionMajor[mcInstance.Path],
														McCodeSub = instance.VersionMinor[mcInstance.Path],
														IsApiLoaded = true
													};
													mcInstanceInfo.HasFabric = Enumerable.Any<char>((System.Collections.Generic.IEnumerable<char>)mcInstanceInfo.FabricVersion);
													mcInstanceInfo.HasLegacyFabric = Enumerable.Any<char>((System.Collections.Generic.IEnumerable<char>)mcInstanceInfo.LegacyFabricVersion);
													mcInstanceInfo.HasQuilt = Enumerable.Any<char>((System.Collections.Generic.IEnumerable<char>)mcInstanceInfo.QuiltVersion);
													mcInstanceInfo.HasForge = Enumerable.Any<char>((System.Collections.Generic.IEnumerable<char>)mcInstanceInfo.ForgeVersion);
													mcInstanceInfo.HasNeoForge = Enumerable.Any<char>((System.Collections.Generic.IEnumerable<char>)mcInstanceInfo.NeoForgeVersion);
													mcInstanceInfo.HasCleanroom = Enumerable.Any<char>((System.Collections.Generic.IEnumerable<char>)mcInstanceInfo.CleanroomVersion);
													mcInstanceInfo.HasOptiFine = Enumerable.Any<char>((System.Collections.Generic.IEnumerable<char>)mcInstanceInfo.OptiFineVersion);
													mcInstance.Version = mcInstanceInfo;
												}
												if (mcInstance.State == McInstanceState.Error)
												{
													string info = mcInstance.Info;
													mcInstance.State = McInstanceState.Original;
													mcInstance.Check();
													string text3 = Config.Instance.CustomInfo[mcInstance.Path];
													if (mcInstance.State == McInstanceState.Original || (Operators.CompareString(text3, "", false) == 0 && Operators.CompareString(info, mcInstance.Info, false) != 0))
													{
														ModBase.Log("[Minecraft] 实例 " + mcInstance.Name + " 的错误状态已变更，新的状态为：" + mcInstance.Info);
														result = null;
														goto end_IL_0596;
													}
												}
												if (Operators.CompareString(mcInstance.Logo, "", false) == 0)
												{
													ModBase.Log("[Minecraft] 实例 " + mcInstance.Name + " 未被加载");
													result = null;
													goto end_IL_0596;
												}
											}
											catch (System.Exception ex)
											{
												ProjectData.SetProjectError(ex);
												System.Exception ex2 = ex;
												ModBase.Log(ex2, "读取实例加载缓存失败（" + text + "）");
												result = null;
												ProjectData.ClearProjectError();
												goto end_IL_0596;
											}
										}
										goto IL_056c;
									}
									if (Enumerable.Any<McInstance>((System.Collections.Generic.IEnumerable<McInstance>)val2))
									{
										val.Add(mcInstanceCardType, val2);
									}
								}
								num3++;
								break;
								IL_056c:
								num4++;
							}
							continue;
						}
					}
					result = val;
					break;
					continue;
					end_IL_0596:
					break;
				}
			}
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			ModBase.Log(ex4, "读取实例缓存失败");
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static Dictionary<McInstanceCardType, List<McInstance>> McInstanceListLoadNoCache(string Path)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_084f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0854: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_09da: Unknown result type (might be due to invalid IL or missing references)
		//IL_09df: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_0709: Unknown result type (might be due to invalid IL or missing references)
		//IL_070e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Unknown result type (might be due to invalid IL or missing references)
		//IL_071c: Unknown result type (might be due to invalid IL or missing references)
		List<McInstance> InstanceList = new List<McInstance>();
		DirectoryInfo[] directories = new DirectoryInfo(Path + "versions").GetDirectories();
		foreach (DirectoryInfo val in directories)
		{
			if (!val.Exists || !Enumerable.Any<FileInfo>(val.EnumerateFiles()))
			{
				ModBase.Log("[Minecraft] 跳过空文件夹：" + ((FileSystemInfo)val).FullName);
				continue;
			}
			if ((Operators.CompareString(val.Name, "cache", false) == 0 || Operators.CompareString(val.Name, "BLClient", false) == 0 || Operators.CompareString(val.Name, "PCL", false) == 0) && !File.Exists(((FileSystemInfo)val).FullName + "\\" + val.Name + ".json"))
			{
				ModBase.Log("[Minecraft] 跳过可能不是实例文件夹的项目：" + ((FileSystemInfo)val).FullName);
				continue;
			}
			string text = ((FileSystemInfo)val).FullName + "\\";
			if (File.Exists(text + ".pclignore"))
			{
				if (!IsFirstMcInstanceListLoad)
				{
					ModBase.Log("[Minecraft] 跳过要求忽略的项目：" + text);
					continue;
				}
				ModBase.Log("[Minecraft] 清理残留的忽略项目：" + text);
				try
				{
					File.Delete(text + ".pclignore");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "清理残留的忽略项目失败（" + text + "）", ModBase.LogLevel.Hint);
					ProjectData.ClearProjectError();
				}
			}
			McInstance mcInstance = new McInstance(text);
			InstanceList.Add(mcInstance);
			mcInstance.Load();
		}
		Dictionary<McInstanceCardType, List<McInstance>> val2 = new Dictionary<McInstanceCardType, List<McInstance>>();
		try
		{
			Dictionary<McInstanceCardType, List<McInstance>> Target = new Dictionary<McInstanceCardType, List<McInstance>>();
			List<McInstance> val3 = new List<McInstance>();
			System.Collections.Generic.IEnumerator<McInstance> enumerator = default(System.Collections.Generic.IEnumerator<McInstance>);
			try
			{
				enumerator = Enumerable.ToList<McInstance>((System.Collections.Generic.IEnumerable<McInstance>)InstanceList).GetEnumerator();
				while (enumerator.MoveNext())
				{
					McInstance current = enumerator.Current;
					if (current.IsStar && current.DisplayType != McInstanceCardType.Hidden)
					{
						val3.Add(current);
						InstanceList.Remove(current);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			if (Enumerable.Any<McInstance>((System.Collections.Generic.IEnumerable<McInstance>)val3))
			{
				Target.Add(McInstanceCardType.Star, val3);
			}
			McInstanceFilter(ref InstanceList, ref Target, new McInstanceState[1], McInstanceCardType.Error);
			McInstanceFilter(ref InstanceList, ref Target, new McInstanceState[] { McInstanceState.Fool }, McInstanceCardType.Fool);
			McInstanceState[] array = new McInstanceState[] { (McInstanceState)6, (McInstanceState)7, (McInstanceState)8, (McInstanceState)9, (McInstanceState)10, (McInstanceState)11, (McInstanceState)12, (McInstanceState)13 };
			McInstanceFilter(ref InstanceList, ref Target, array, McInstanceCardType.API);
			List<McInstance> val4 = new List<McInstance>();
			List<McInstance> KeepList = new List<McInstance>();
			McInstanceFilter(ref InstanceList, new McInstanceState[] { McInstanceState.Old }, ref KeepList);
			McInstance mcInstance2 = null;
			System.Collections.Generic.IEnumerator<McInstance> enumerator2 = default(System.Collections.Generic.IEnumerator<McInstance>);
			try
			{
				enumerator2 = InstanceList.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					McInstance current2 = enumerator2.Current;
					if ((current2.State == McInstanceState.Original || current2.State == McInstanceState.Snapshot) && ((object)mcInstance2 == null || System.DateTime.Compare(current2.ReleaseTime, mcInstance2.ReleaseTime) > 0))
					{
						mcInstance2 = current2;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			if ((object)mcInstance2 != null && mcInstance2.State == McInstanceState.Snapshot)
			{
				val4.Add(mcInstance2);
				InstanceList.Remove(mcInstance2);
			}
			McInstanceFilter(ref InstanceList, new McInstanceState[] { McInstanceState.Snapshot }, ref KeepList);
			Dictionary<string, McInstance> val5 = new Dictionary<string, McInstance>();
			List<int> val6 = new List<int>();
			System.Collections.Generic.IEnumerator<McInstance> enumerator3 = default(System.Collections.Generic.IEnumerator<McInstance>);
			try
			{
				enumerator3 = InstanceList.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					McInstance current3 = enumerator3.Current;
					if (current3.Version.McCodeMain < 2)
					{
						continue;
					}
					if (!val6.Contains(current3.Version.McCodeMain))
					{
						val6.Add(current3.Version.McCodeMain);
					}
					if (val5.ContainsKey(Conversions.ToString(current3.Version.McCodeMain) + "-" + Conversions.ToString((int)current3.State)))
					{
						if (current3.Version.HasOptiFine)
						{
							if (current3.Version.SortCode > val5[Conversions.ToString(current3.Version.McCodeMain) + "-" + Conversions.ToString((int)current3.State)].Version.SortCode)
							{
								val5[Conversions.ToString(current3.Version.McCodeMain) + "-" + Conversions.ToString((int)current3.State)] = current3;
							}
						}
						else if (System.DateTime.Compare(current3.ReleaseTime, val5[Conversions.ToString(current3.Version.McCodeMain) + "-" + Conversions.ToString((int)current3.State)].ReleaseTime) > 0)
						{
							val5[Conversions.ToString(current3.Version.McCodeMain) + "-" + Conversions.ToString((int)current3.State)] = current3;
						}
					}
					else
					{
						val5.Add(Conversions.ToString(current3.Version.McCodeMain) + "-" + Conversions.ToString((int)current3.State), current3);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator3).Dispose();
			}
			System.Collections.Generic.IEnumerator<int> enumerator4 = default(System.Collections.Generic.IEnumerator<int>);
			try
			{
				enumerator4 = val6.GetEnumerator();
				while (enumerator4.MoveNext())
				{
					int current4 = enumerator4.Current;
					if (val5.ContainsKey(Conversions.ToString(current4) + "-" + Conversions.ToString(4)) && val5.ContainsKey(Conversions.ToString(current4) + "-" + Conversions.ToString(1)))
					{
						McInstance mcInstance3 = val5[Conversions.ToString(current4) + "-" + Conversions.ToString(1)];
						McInstance mcInstance4 = val5[Conversions.ToString(current4) + "-" + Conversions.ToString(4)];
						if (mcInstance3.Version.McCodeSub > mcInstance4.Version.McCodeSub)
						{
							val4.Add(mcInstance3);
							InstanceList.Remove(mcInstance3);
						}
						val4.Add(mcInstance4);
						InstanceList.Remove(mcInstance4);
					}
					else if (val5.ContainsKey(Conversions.ToString(current4) + "-" + Conversions.ToString(4)))
					{
						val4.Add(val5[Conversions.ToString(current4) + "-" + Conversions.ToString(4)]);
						InstanceList.Remove(val5[Conversions.ToString(current4) + "-" + Conversions.ToString(4)]);
					}
					else if (val5.ContainsKey(Conversions.ToString(current4) + "-" + Conversions.ToString(1)))
					{
						val4.Add(val5[Conversions.ToString(current4) + "-" + Conversions.ToString(1)]);
						InstanceList.Remove(val5[Conversions.ToString(current4) + "-" + Conversions.ToString(1)]);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator4).Dispose();
			}
			KeepList.AddRange((System.Collections.Generic.IEnumerable<McInstance>)InstanceList);
			if (Enumerable.Any<McInstance>((System.Collections.Generic.IEnumerable<McInstance>)val4))
			{
				Target.Add(McInstanceCardType.OriginalLike, val4);
			}
			if (Enumerable.Any<McInstance>((System.Collections.Generic.IEnumerable<McInstance>)KeepList))
			{
				Target.Add(McInstanceCardType.Rubbish, KeepList);
			}
			System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<McInstanceCardType, List<McInstance>>> enumerator5 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<McInstanceCardType, List<McInstance>>>);
			try
			{
				enumerator5 = Target.GetEnumerator();
				System.Collections.Generic.IEnumerator<McInstance> enumerator6 = default(System.Collections.Generic.IEnumerator<McInstance>);
				while (enumerator5.MoveNext())
				{
					KeyValuePair<McInstanceCardType, List<McInstance>> current5 = enumerator5.Current;
					try
					{
						enumerator6 = current5.Value.GetEnumerator();
						while (enumerator6.MoveNext())
						{
							McInstance current6 = enumerator6.Current;
							McInstanceCardType mcInstanceCardType = ((current6.DisplayType == McInstanceCardType.Auto || current5.Key == McInstanceCardType.Star) ? current5.Key : current6.DisplayType);
							if (!val2.ContainsKey(mcInstanceCardType))
							{
								val2.Add(mcInstanceCardType, new List<McInstance>());
							}
							val2[mcInstanceCardType].Add(current6);
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
				((System.IDisposable)enumerator5).Dispose();
			}
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			val2.Clear();
			ModBase.Log(ex4, "分类实例列表失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
		Dictionary<McInstanceCardType, List<McInstance>> val7 = new Dictionary<McInstanceCardType, List<McInstance>>();
McInstanceCardType[] array2 = new McInstanceCardType[] { (McInstanceCardType)(-1), (McInstanceCardType)2, (McInstanceCardType)3, (McInstanceCardType)4, (McInstanceCardType)5, (McInstanceCardType)6, (McInstanceCardType)1 };
		McInstanceCardType[] array3 = array2;
		for (int j = 0; j < array3.Length; j = checked(j + 1))
		{
			string text2 = Conversions.ToString((int)array3[j]);
			if (val2.ContainsKey((McInstanceCardType)Conversions.ToInteger(text2)))
			{
				val7.Add((McInstanceCardType)Conversions.ToInteger(text2), val2[(McInstanceCardType)Conversions.ToInteger(text2)]);
			}
		}
		val2 = val7;
		if (val2.ContainsKey(McInstanceCardType.OriginalLike))
		{
			List<McInstance> val8 = val2[McInstanceCardType.OriginalLike];
			McInstance mcInstance5 = null;
			System.Collections.Generic.IEnumerator<McInstance> enumerator7 = default(System.Collections.Generic.IEnumerator<McInstance>);
			try
			{
				enumerator7 = val8.GetEnumerator();
				while (enumerator7.MoveNext())
				{
					McInstance current7 = enumerator7.Current;
					if (current7.State == McInstanceState.Snapshot)
					{
						mcInstance5 = current7;
						break;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator7).Dispose();
			}
			if (!Information.IsNothing((object)mcInstance5))
			{
				val8.Remove(mcInstance5);
			}
			List<McInstance> val9 = Enumerable.ToList<McInstance>((System.Collections.Generic.IEnumerable<McInstance>)Enumerable.OrderByDescending<McInstance, int>((System.Collections.Generic.IEnumerable<McInstance>)val8, (Func<McInstance, int>)([SpecialName] (McInstance v) => v.Version.McCodeMain)));
			if (!Information.IsNothing((object)mcInstance5))
			{
				val9.Insert(0, mcInstance5);
			}
			val2[McInstanceCardType.OriginalLike] = val9;
		}
		if (val2.ContainsKey(McInstanceCardType.Rubbish))
		{
			ModBase.Sort((System.Collections.Generic.IList<McInstance>)val2[McInstanceCardType.Rubbish], [SpecialName] (McInstance Left, McInstance Right) =>
			{
				int year = Left.ReleaseTime.Year;
				int year2 = Right.ReleaseTime.Year;
				if (year > 2000 && year2 > 2000)
				{
					if (year != year2)
					{
						return year > year2;
					}
					return System.DateTime.Compare(Left.ReleaseTime, Right.ReleaseTime) > 0;
				}
				if (year > 2000 && year2 < 2000)
				{
					return true;
				}
				return (year >= 2000 || year2 <= 2000) && Operators.CompareString(Left.Name, Right.Name, false) > 0;
			});
		}
		if (val2.ContainsKey(McInstanceCardType.API))
		{
			ModBase.Sort((System.Collections.Generic.IList<McInstance>)val2[McInstanceCardType.API], [SpecialName] (McInstance Left, McInstance Right) =>
			{
				int num2 = VersionSortInteger(Left.Version.McName, Right.Version.McName);
				if (num2 != 0)
				{
					return num2 > 0;
				}
				if (Left.Version.HasFabric ^ Right.Version.HasFabric)
				{
					return Left.Version.HasFabric;
				}
				if (Left.Version.HasQuilt ^ Right.Version.HasQuilt)
				{
					return Left.Version.HasQuilt;
				}
				if (Left.Version.HasLegacyFabric ^ Right.Version.HasLegacyFabric)
				{
					return Left.Version.HasQuilt;
				}
				if (Left.Version.HasNeoForge ^ Right.Version.HasNeoForge)
				{
					return Left.Version.HasNeoForge;
				}
				if (Left.Version.HasForge ^ Right.Version.HasForge)
				{
					return Left.Version.HasForge;
				}
				if (Left.Version.HasCleanroom ^ Right.Version.HasCleanroom)
				{
					return Left.Version.HasCleanroom;
				}
				if (Left.Version.HasLabyMod ^ Right.Version.HasLabyMod)
				{
					return Left.Version.HasLabyMod;
				}
				return (Left.Version.SortCode == Right.Version.SortCode) ? (Left.Version.SortCode > Right.Version.SortCode) : (Operators.CompareString(Left.Name, Right.Name, false) > 0);
			});
		}
		ModBase.WriteIni(Path + "PCL.ini", "CardCount", Conversions.ToString(val2.Count));
		checked
		{
			int num = val2.Count - 1;
			System.Collections.Generic.IEnumerator<McInstance> enumerator8 = default(System.Collections.Generic.IEnumerator<McInstance>);
			for (int k = 0; k <= num; k++)
			{
				ModBase.WriteIni(Path + "PCL.ini", "CardKey" + Conversions.ToString(k + 1), Conversions.ToString(unchecked((int)Enumerable.ElementAtOrDefault<McInstanceCardType>((System.Collections.Generic.IEnumerable<McInstanceCardType>)val2.Keys, k))));
				string text3 = "";
				try
				{
					enumerator8 = Enumerable.ElementAtOrDefault<List<McInstance>>((System.Collections.Generic.IEnumerable<List<McInstance>>)val2.Values, k).GetEnumerator();
					while (enumerator8.MoveNext())
					{
						McInstance current8 = enumerator8.Current;
						text3 = text3 + current8.Name + ":";
					}
				}
				finally
				{
					((System.IDisposable)enumerator8).Dispose();
				}
				ModBase.WriteIni(Path + "PCL.ini", "CardValue" + Conversions.ToString(k + 1), text3);
			}
			return val2;
		}
	}

	private static void McInstanceFilter(ref List<McInstance> InstanceList, ref Dictionary<McInstanceCardType, List<McInstance>> Target, McInstanceState[] Formula, McInstanceCardType CardType)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		_Closure_0024__25_002D0 arg = default(_Closure_0024__25_002D0);
		_Closure_0024__25_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__25_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Formula = Formula;
		List<McInstance> val = Enumerable.ToList<McInstance>(Enumerable.Where<McInstance>((System.Collections.Generic.IEnumerable<McInstance>)InstanceList, (Func<McInstance, bool>)([SpecialName] (McInstance v) => Enumerable.Contains<McInstanceState>((System.Collections.Generic.IEnumerable<McInstanceState>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Formula, v.State))));
		if (!Enumerable.Any<McInstance>((System.Collections.Generic.IEnumerable<McInstance>)val))
		{
			return;
		}
		Target.Add(CardType, val);
		System.Collections.Generic.IEnumerator<McInstance> enumerator = default(System.Collections.Generic.IEnumerator<McInstance>);
		try
		{
			enumerator = val.GetEnumerator();
			while (enumerator.MoveNext())
			{
				McInstance current = enumerator.Current;
				InstanceList.Remove(current);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	private static void McInstanceFilter(ref List<McInstance> InstanceList, McInstanceState[] Formula, ref List<McInstance> KeepList)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		_Closure_0024__26_002D0 arg = default(_Closure_0024__26_002D0);
		_Closure_0024__26_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__26_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Formula = Formula;
		KeepList.AddRange(Enumerable.Where<McInstance>((System.Collections.Generic.IEnumerable<McInstance>)InstanceList, (Func<McInstance, bool>)([SpecialName] (McInstance v) => Enumerable.Contains<McInstanceState>((System.Collections.Generic.IEnumerable<McInstanceState>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Formula, v.State))));
		if (!Enumerable.Any<McInstance>((System.Collections.Generic.IEnumerable<McInstance>)KeepList))
		{
			return;
		}
		System.Collections.Generic.IEnumerator<McInstance> enumerator = default(System.Collections.Generic.IEnumerator<McInstance>);
		try
		{
			enumerator = KeepList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				McInstance current = enumerator.Current;
				InstanceList.Remove(current);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	public static McSkinInfo McSkinSelect()
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		string text = SystemDialogs.SelectFile("皮肤文件(*.png;*.jpg;*.webp)|*.png;*.jpg;*.webp", "选择皮肤文件");
		McSkinInfo result;
		if (Operators.CompareString(text, "", false) == 0)
		{
			McSkinInfo mcSkinInfo = default(McSkinInfo);
			mcSkinInfo.IsVaild = false;
			result = mcSkinInfo;
		}
		else
		{
			try
			{
				MyBitmap myBitmap = new MyBitmap(text);
				if (((Image)myBitmap.Pic).Width != 64 || (((Image)myBitmap.Pic).Height != 32 && ((Image)myBitmap.Pic).Height != 64))
				{
					ModMain.Hint("皮肤图片大小应为 64x32 像素或 64x64 像素！", ModMain.HintType.Critical);
					McSkinInfo mcSkinInfo = default(McSkinInfo);
					mcSkinInfo.IsVaild = false;
					result = mcSkinInfo;
					goto IL_0196;
				}
				FileInfo val = new FileInfo(text);
				if (val.Length > 24576)
				{
					ModMain.Hint("皮肤文件大小需小于 24 KB，而所选文件大小为 " + Conversions.ToString(Math.Round((double)val.Length / 1024.0, 2)) + " KB", ModMain.HintType.Critical);
					McSkinInfo mcSkinInfo = default(McSkinInfo);
					mcSkinInfo.IsVaild = false;
					result = mcSkinInfo;
					goto IL_0196;
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "皮肤文件存在错误", ModBase.LogLevel.Hint);
				McSkinInfo mcSkinInfo = default(McSkinInfo);
				mcSkinInfo.IsVaild = false;
				result = mcSkinInfo;
				ProjectData.ClearProjectError();
				goto IL_0196;
			}
			int num = ModMain.MyMsgBox("此皮肤为 Steve 模型（粗手臂）还是 Alex 模型（细手臂）？", "选择皮肤种类", "Steve 模型", "Alex 模型", "我不知道", IsWarn: false, HighLight: false);
			if (num == 3)
			{
				ModMain.Hint("请在皮肤下载页面确认皮肤种类后再使用此皮肤！");
				McSkinInfo mcSkinInfo = default(McSkinInfo);
				mcSkinInfo.IsVaild = false;
				result = mcSkinInfo;
			}
			else
			{
				McSkinInfo mcSkinInfo = default(McSkinInfo);
				mcSkinInfo.IsVaild = true;
				mcSkinInfo.IsSlim = num == 2;
				mcSkinInfo.LocalFile = text;
				result = mcSkinInfo;
			}
		}
		goto IL_0196;
		IL_0196:
		return result;
	}

	public static string McSkinGetAddress(string Uuid, string Type)
	{
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(Uuid, "", false) == 0)
		{
			throw new System.Exception("Uuid 为空。");
		}
		if (ModBase.StartsWithF(Uuid, "00000"))
		{
			throw new System.Exception("离线 Uuid 无正版皮肤文件。");
		}
		string text = ModBase.ReadIni(ModBase.PathTemp + "Cache\\Skin\\Index" + Type + ".ini", Uuid);
		if (Operators.CompareString(text, "", false) != 0)
		{
			return text;
		}
		string text2;
		switch (Type)
		{
		case "Mojang":
		case "Ms":
			text2 = "https://sessionserver.mojang.com/session/minecraft/profile/";
			break;
		case "Auth":
			text2 = ModProfile.SelectedProfile.Server.Replace("/authserver", "") + "/sessionserver/session/minecraft/profile/";
			break;
		default:
			throw new ArgumentException("皮肤地址种类无效：" + (Type ?? "null"));
		}
		object objectValue = RuntimeHelpers.GetObjectValue(ModNet.NetGetCodeByRequestRetry(text2 + Uuid));
		if (Operators.ConditionalCompareObjectEqual(objectValue, (object)"", false))
		{
			throw new System.Exception("皮肤返回值为空，可能是未设置自定义皮肤的用户");
		}
		string text3;
		try
		{
			foreach (object item in (System.Collections.IEnumerable)NewLateBinding.LateIndexGet(ModBase.GetJson(Conversions.ToString(objectValue)), new object[] { "properties" }, (string[])null))
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(item);
				if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(objectValue2, new object[] { "name" }, (string[])null), (object)"textures", false))
				{
					continue;
				}
				text3 = NewLateBinding.LateIndexGet(objectValue2, new object[] { "value" }, (string[])null).ToString();
				goto end_IL_0117;
			}
			throw new System.Exception("未从皮肤返回值中找到符合条件的 Property");
			end_IL_0117:;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, Conversions.ToString(Operators.ConcatenateObject((object)"无法完成解析的皮肤返回值，可能是未设置自定义皮肤的用户：", objectValue)), ModBase.LogLevel.Developer);
			throw new System.Exception("皮肤返回值中不包含皮肤数据项，可能是未设置自定义皮肤的用户", ex2);
		}
		objectValue = Encoding.GetEncoding("utf-8").GetString(Convert.FromBase64String(text3));
		JObject jObject = (JObject)ModBase.GetJson(Conversions.ToString(NewLateBinding.LateGet(objectValue, (System.Type)null, "ToLower", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		if (jObject["textures"] == null || jObject["textures"]["skin"] == null || jObject["textures"]["skin"]["url"] == null)
		{
			throw new System.Exception("用户未设置自定义皮肤");
		}
		string text4 = jObject["textures"]["skin"]["url"].ToString();
		text3 = (text4.Contains("minecraft.net/") ? text4.Replace("http://", "https://") : text4);
		ModBase.WriteIni(ModBase.PathTemp + "Cache\\Skin\\Index" + Type + ".ini", Uuid, text3);
		ModBase.Log("[Skin] UUID " + Uuid + " 对应的皮肤文件为 " + text3);
		return text3;
	}

	[MethodImpl(72)]
	public static string McSkinDownload(string Address)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		ModBase.GetFileNameFromPath(Address);
		string text = ModBase.PathTemp + "Cache\\Skin\\" + Conversions.ToString(ModBase.GetHash(Address)) + ".png";
		object mcSkinDownloadLock = McSkinDownloadLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(mcSkinDownloadLock);
		bool flag = false;
		try
		{
			Monitor.Enter(mcSkinDownloadLock, ref flag);
			if (!File.Exists(text))
			{
				TaskAwaiter awaiter = ModNet.NetDownloadByClient(Address, text + ".PCLDownloading").GetAwaiter();
				awaiter.GetResult();
				File.Delete(text);
				FileSystem.Rename(text + ".PCLDownloading", text);
				ModBase.Log("[Minecraft] 皮肤下载成功：" + text);
			}
			return text;
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(mcSkinDownloadLock);
			}
		}
	}

	public static string McSkinSex(string Uuid)
	{
		if (Uuid.Length != 32)
		{
			return "Steve";
		}
		int num = int.Parse(Conversions.ToString(Uuid[7]), (NumberStyles)512);
		int num2 = int.Parse(Conversions.ToString(Uuid[15]), (NumberStyles)512);
		int num3 = int.Parse(Conversions.ToString(Uuid[23]), (NumberStyles)512);
		int num4 = int.Parse(Conversions.ToString(Uuid[31]), (NumberStyles)512);
		return ((num ^ num2 ^ num3 ^ num4) % 2 != 0) ? "Alex" : "Steve";
	}

	public static bool McJsonRuleCheck(JToken RuleToken)
	{
		if (RuleToken == null)
		{
			return true;
		}
		bool result = false;
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator = ((System.Collections.Generic.IEnumerable<JToken>)RuleToken).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				JToken current = enumerator.Current;
				bool flag = true;
				if (current["os"] != null)
				{
					if (current["os"]["name"] != null)
					{
						string text = current["os"]["name"].ToString();
						if (Operators.CompareString(text, "unknown", false) != 0)
						{
							if (Operators.CompareString(text, "windows", false) == 0)
							{
								if (current["os"]["version"] != null)
								{
									string regex = current["os"]["version"].ToString();
									flag = flag && ModBase.RegexCheck(OSVersion, regex, (RegexOptions)0);
								}
							}
							else
							{
								flag = false;
							}
						}
					}
					if (current["os"]["arch"] != null)
					{
						flag = flag && Operators.CompareString(current["os"]["arch"].ToString(), "x86", false) == 0 == ModBase.Is32BitSystem;
					}
				}
				if (!Information.IsNothing((object)current["features"]))
				{
					flag = flag && Information.IsNothing((object)current["features"]["is_demo_user"]);
					if (Enumerable.Any<JToken>((System.Collections.Generic.IEnumerable<JToken>)((JObject)current["features"]).Children(), (Func<JToken, bool>)([SpecialName] (JToken a0) => ((VB_0024AnonymousDelegate_12<JProperty, bool>)([SpecialName] (JProperty j) => j.Name.Contains("quick_play")))((JProperty)a0))))
					{
						flag = false;
					}
				}
				if (Operators.CompareString(current["action"].ToString(), "allow", false) == 0)
				{
					if (flag)
					{
						result = true;
					}
				}
				else if (flag)
				{
					result = false;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		return result;
	}

	public static List<McLibToken> McLibListGet(McInstance Instance, bool IncludeInstanceJar)
	{
		ModBase.Log("[Minecraft] 获取支持库列表：" + Instance.Name);
		List<McLibToken> val = McLibListGetWithJson(Instance.JsonObject, KeepSameNameDifferentVersionResult: false, null, Instance);
		if (IncludeInstanceJar)
		{
			string text = Instance.JsonObject["jar"]?.ToString();
			McInstance mcInstance2;
			if (Instance.IsHmclFormatJson || text == null)
			{
				McInstance mcInstance = Instance;
				if ((!Instance.Version.HasForge && !Instance.Version.HasNeoForge) || Instance.Version.McCodeMain < 17)
				{
					while (Operators.CompareString(mcInstance.InheritInstance, "", false) != 0 && Operators.CompareString(mcInstance.InheritInstance, mcInstance.Name, false) != 0)
					{
						mcInstance = new McInstance(PathMcFolder + "versions\\" + mcInstance.InheritInstance + "\\");
					}
				}
				mcInstance2 = new McInstance(mcInstance.Path);
			}
			else
			{
				mcInstance2 = new McInstance(text);
			}
			if (!File.Exists(mcInstance2.Path + mcInstance2.Name + ".json"))
			{
				mcInstance2 = Instance;
				ModBase.Log("[Minecraft] 可能缺少前置实例 " + mcInstance2.Name + "，找不到对应的 JSON 文件", ModBase.LogLevel.Debug);
			}
			string url;
			string sHA;
			if (mcInstance2.JsonObject["downloads"] != null && mcInstance2.JsonObject["downloads"]["client"] != null)
			{
				url = (string?)mcInstance2.JsonObject["downloads"]["client"]["url"];
				sHA = (string?)mcInstance2.JsonObject["downloads"]["client"]["sha1"];
			}
			else
			{
				url = null;
				sHA = null;
			}
			val.Add(new McLibToken
			{
				LocalPath = mcInstance2.Path + mcInstance2.Name + ".jar",
				Size = 0L,
				IsNatives = false,
				Url = url,
				SHA1 = sHA
			});
		}
		return val;
	}

	public static List<McLibToken> McLibListGetWithJson(JObject JsonObject, bool KeepSameNameDifferentVersionResult = false, string CustomMcFolder = null, McInstance TargetInstance = null)
	{
		CustomMcFolder = CustomMcFolder ?? PathMcFolder;
		List<McLibToken> val = new List<McLibToken>();
		JArray jArray = (JArray)JsonObject["libraries"];
		checked
		{
			System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator = jArray.Children().GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					JObject jObject = (JObject)enumerator.Current;
					for (int i = Enumerable.Count<JProperty>(jObject.Properties()) - 1; i >= 0; i += -1)
					{
						if (Enumerable.ElementAtOrDefault<JProperty>(jObject.Properties(), i).Value.Type == JTokenType.Null)
						{
							jObject.Remove(Enumerable.ElementAtOrDefault<JProperty>(jObject.Properties(), i).Name);
						}
					}
					if (!McJsonRuleCheck(jObject["rules"]))
					{
						continue;
					}
					string text = (string?)jObject["url"];
					if (text != null)
					{
						text += McLibGet((string?)jObject["name"], WithHead: false, IgnoreLiteLoader: true, CustomMcFolder).Replace("\\", "/");
					}
					string text2 = (string?)jObject["hint"];
					bool flag = text2 != null && Operators.CompareString(text2, "local", false) == 0;
					if (jObject["natives"] == null)
					{
						string localPath = ((!flag || (object)TargetInstance == null) ? McLibGet((string?)jObject["name"], WithHead: true, IgnoreLiteLoader: false, CustomMcFolder) : (TargetInstance.Path + "libraries\\" + ModBase.AfterFirst(jObject["name"].ToString(), ":").Replace(":", "-") + ".jar"));
						try
						{
							if (jObject["downloads"] != null && jObject["downloads"]["artifact"] != null)
							{
								val.Add(new McLibToken
								{
									OriginalName = (string?)jObject["name"],
									Url = (string?)((text != null) ? ((JToken)text) : jObject["downloads"]["artifact"]["url"]),
									LocalPath = ((jObject["downloads"]["artifact"]["path"] == null) ? McLibGet((string?)jObject["name"], WithHead: true, IgnoreLiteLoader: false, CustomMcFolder) : (CustomMcFolder + "libraries\\" + jObject["downloads"]["artifact"]["path"].ToString().Replace("/", "\\"))),
									Size = (long)Math.Round(ModBase.Val(jObject["downloads"]["artifact"]["size"].ToString())),
									IsNatives = false,
									SHA1 = jObject["downloads"]["artifact"]["sha1"]?.ToString(),
									IsLocal = flag
								});
							}
							else
							{
								val.Add(new McLibToken
								{
									OriginalName = (string?)jObject["name"],
									Url = text,
									LocalPath = localPath,
									Size = 0L,
									IsNatives = false,
									SHA1 = null,
									IsLocal = flag
								});
							}
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							ModBase.Log(ex2, "处理实际支持库列表失败（无 Natives，" + (jObject["name"] ?? ((JToken)"Nothing")).ToString() + "）");
							val.Add(new McLibToken
							{
								OriginalName = (string?)jObject["name"],
								Url = text,
								LocalPath = localPath,
								Size = 0L,
								IsNatives = false,
								SHA1 = null
							});
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						if (jObject["natives"]["windows"] == null)
						{
							continue;
						}
						try
						{
							if (jObject["downloads"] != null && jObject["downloads"]["classifiers"] != null && jObject["downloads"]["classifiers"]["natives-windows"] != null)
							{
								val.Add(new McLibToken
								{
									OriginalName = (string?)jObject["name"],
									Url = (string?)((text != null) ? ((JToken)text) : jObject["downloads"]["classifiers"]["natives-windows"]["url"]),
									LocalPath = ((jObject["downloads"]["classifiers"]["natives-windows"]["path"] == null) ? McLibGet((string?)jObject["name"], WithHead: true, IgnoreLiteLoader: false, CustomMcFolder).Replace(".jar", "-" + jObject["natives"]["windows"].ToString() + ".jar").Replace("${arch}", Environment.Is64BitOperatingSystem ? "64" : "32") : (CustomMcFolder + "libraries\\" + jObject["downloads"]["classifiers"]["natives-windows"]["path"].ToString().Replace("/", "\\"))),
									Size = (long)Math.Round(ModBase.Val(jObject["downloads"]["classifiers"]["natives-windows"]["size"].ToString())),
									IsNatives = true,
									SHA1 = jObject["downloads"]["classifiers"]["natives-windows"]["sha1"].ToString(),
									IsLocal = flag
								});
							}
							else
							{
								val.Add(new McLibToken
								{
									OriginalName = (string?)jObject["name"],
									Url = text,
									LocalPath = McLibGet((string?)jObject["name"], WithHead: true, IgnoreLiteLoader: false, CustomMcFolder).Replace(".jar", "-" + jObject["natives"]["windows"].ToString() + ".jar").Replace("${arch}", Environment.Is64BitOperatingSystem ? "64" : "32"),
									Size = 0L,
									IsNatives = true,
									SHA1 = null,
									IsLocal = flag
								});
							}
						}
						catch (System.Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							System.Exception ex4 = ex3;
							ModBase.Log(ex4, "处理实际支持库列表失败（有 Natives，" + (jObject["name"] ?? ((JToken)"Nothing")).ToString() + "）");
							val.Add(new McLibToken
							{
								OriginalName = (string?)jObject["name"],
								Url = text,
								LocalPath = McLibGet((string?)jObject["name"], WithHead: true, IgnoreLiteLoader: false, CustomMcFolder).Replace(".jar", "-" + jObject["natives"]["windows"].ToString() + ".jar").Replace("${arch}", Environment.Is64BitOperatingSystem ? "64" : "32"),
								Size = 0L,
								IsNatives = true,
								SHA1 = null,
								IsLocal = false
							});
							ProjectData.ClearProjectError();
						}
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			Dictionary<string, McLibToken> val2 = new Dictionary<string, McLibToken>();
			VB_0024AnonymousDelegate_13<McLibToken, string> vB_0024AnonymousDelegate_ = [SpecialName] (McLibToken Token) => ModBase.GetFolderNameFromPath(ModBase.GetPathFromFullPath(Token.LocalPath));
			int num = val.Count - 1;
			for (int j = 0; j <= num; j++)
			{
				string text3 = val[j].Name + val[j].IsNatives;
				if (val2.ContainsKey(text3))
				{
					string text4 = vB_0024AnonymousDelegate_(val[j]);
					string text5 = vB_0024AnonymousDelegate_(val2[text3]);
					if (Operators.CompareString(text4, text5, false) != 0 && KeepSameNameDifferentVersionResult)
					{
						ModBase.Log(string.Format("[Minecraft] 发现疑似重复的支持库：{0} ({1}) 与 {2} ({3})", new object[4]
						{
							val[j],
							text4,
							val2[text3],
							text5
						}));
						val2.Add(text3 + Conversions.ToString(ModBase.GetUuid()), val[j]);
						continue;
					}
					ModBase.Log(string.Format("[Minecraft] 发现重复的支持库：{0} ({1}) 与 {2} ({3})，已忽略其中之一", new object[4]
					{
						val[j],
						text4,
						val2[text3],
						text5
					}));
					if (VersionSortBoolean(text4, text5))
					{
						val2[text3] = val[j];
					}
				}
				else
				{
					val2.Add(text3, val[j]);
				}
			}
			return Enumerable.ToList<McLibToken>((System.Collections.Generic.IEnumerable<McLibToken>)val2.Values);
		}
	}

	public static List<ModNet.NetFile> McLibFix(McInstance Instance)
	{
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		if (!Instance.IsLoaded)
		{
			Instance.Load();
		}
		List<ModNet.NetFile> val = new List<ModNet.NetFile>();
		try
		{
			ModNet.NetFile netFile = ModDownload.DlClientJarGet(Instance, ReturnNothingOnFileUseable: true);
			if (netFile != null)
			{
				val.Add(netFile);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "实例缺失主 Jar 文件所必须的信息", ModBase.LogLevel.Developer);
			ProjectData.ClearProjectError();
		}
		val.AddRange((System.Collections.Generic.IEnumerable<ModNet.NetFile>)McLibFixFromLibToken(McLibListGet(Instance, IncludeInstanceJar: false)));
		string localPath = ModBase.PathPure + "\\authlib-injector.jar";
		JObject jObject = null;
		try
		{
			ModBase.Log("[Minecraft] 开始获取 Authlib-Injector 下载信息");
			jObject = (JObject)ModBase.GetJson(ModNet.NetGetCodeByLoader(new string[] { "https://authlib-injector.yushi.moe/artifact/latest.json", "https://bmclapi2.bangbang93.com/mirrors/authlib-injector/artifact/latest.json" }, 45000, IsJson: true));
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			ModBase.Log(ex4, "获取 Authlib-Injector 下载信息失败");
			ProjectData.ClearProjectError();
		}
		if (jObject != null && new ModBase.FileChecker(-1L, -1L, jObject["checksums"]["sha256"].ToString()).Check(localPath) != null)
		{
			string text = jObject["download_url"].ToString().Replace("bmclapi2.bangbang93.com/mirrors/authlib-injector", "authlib-injector.yushi.moe");
			ModBase.Log("[Minecraft] Authlib-Injector 需要更新：" + text, ModBase.LogLevel.Developer);
			val.Add(new ModNet.NetFile(new string[2]
			{
				text,
				text.Replace("authlib-injector.yushi.moe", "bmclapi2.bangbang93.com/mirrors/authlib-injector")
			}, localPath, new ModBase.FileChecker(-1L, -1L, jObject["checksums"]["sha256"].ToString())));
		}
		string text2 = "25.1.7";
		string text3 = ModBase.PathPure + "\\mesa-loader-windows\\" + text2 + "\\Loader.jar";
		int num = 0;
		num = ((!Operators.ConditionalCompareObjectNotEqual(ModBase.Setup.Get("VersionAdvanceRenderer", McInstanceCurrent), (object)0, false)) ? Conversions.ToInteger(ModBase.Setup.Get("LaunchAdvanceRenderer")) : Conversions.ToInteger(Operators.SubtractObject(ModBase.Setup.Get("VersionAdvanceRenderer", McInstanceCurrent), (object)1)));
		if (num != 0 && !File.Exists(text3))
		{
			string text4 = string.Concat(new string[7]
			{
				"https://mirrors.cloud.tencent.com/nexus/repository/maven-public/org/glavo/mesa-loader-windows/",
				text2,
				"/mesa-loader-windows-",
				text2,
				"-",
				ModBase.Is32BitSystem ? "x86" : (ModBase.IsArm64System ? "arm64" : "x64"),
				".jar"
			});
			val.Add(new ModNet.NetFile(new string[] { text4 }, text3));
		}
		if (Instance.Version.HasLabyMod)
		{
			if (Operators.CompareString(Instance.PathIndie, Instance.Path, false) == 0)
			{
				if (Directory.Exists(Instance.Path + "labymod-neo"))
				{
					Directory.Delete(Instance.Path + "labymod-neo", true);
				}
				ModBase.CreateSymbolicLink(Instance.Path + "labymod-neo", PathMcFolder + "labymod-neo", 2);
			}
			try
			{
				string text5 = Instance.JsonObject["labymod_data"]["channelType"].ToString();
				Directory.CreateDirectory($"{PathMcFolder}labymod-neo\\libraries");
				ModBase.Log("[Minecraft] 开始获取 LabyMod 信息");
				JObject obj = (JObject)ModNet.NetGetCodeByRequestRetry($"https://releases.r2.labymod.net/api/v1/manifest/{text5}/latest.json", null, "", IsJson: true);
				JObject jObject2 = (JObject)obj["assets"];
				string text6 = obj["commitReference"].ToString();
				System.Collections.Generic.IEnumerator<KeyValuePair<string, JToken>> enumerator = default(System.Collections.Generic.IEnumerator<KeyValuePair<string, JToken>>);
				try
				{
					enumerator = jObject2.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						KeyValuePair<string, JToken> current = enumerator.Current;
						string key = current.Key;
						string text7 = current.Value.ToString();
						string localPath2 = $"{PathMcFolder}labymod-neo\\assets\\{key}.jar";
						string text8 = string.Format("https://releases.r2.labymod.net/api/v1/download/assets/labymod4/{0}/{1}/{2}/{3}.jar", new object[] { text5, text6, key, text7 });
						ModBase.FileChecker fileChecker = new ModBase.FileChecker(-1L, -1L, text7);
						if (fileChecker.Check(localPath2) != null)
						{
							val.Add(new ModNet.NetFile(new string[] { text8 }, localPath2, fileChecker));
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
			}
			catch (System.Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				System.Exception ex6 = ex5;
				ModBase.Log(ex6, "获取 LabyMod 信息失败，跳过检查");
				ProjectData.ClearProjectError();
			}
		}
		if (Conversions.ToBoolean(ShouldIgnoreFileCheck(Instance)))
		{
			ModBase.Log("[Minecraft] 用户要求尽量忽略文件检查，这可能会保留有误的文件");
			val = Enumerable.ToList<ModNet.NetFile>(Enumerable.Where<ModNet.NetFile>((System.Collections.Generic.IEnumerable<ModNet.NetFile>)val, (Func<ModNet.NetFile, bool>)([SpecialName] (ModNet.NetFile f) =>
			{
				if (File.Exists(f.LocalPath))
				{
					ModBase.Log("[Minecraft] 跳过下载的支持库文件：" + f.LocalPath, ModBase.LogLevel.Debug);
					return false;
				}
				return true;
			})));
		}
		return val;
	}

	public static List<ModNet.NetFile> McLibFixFromLibToken(List<McLibToken> Libs, string CustomMcFolder = null)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		CustomMcFolder = CustomMcFolder ?? PathMcFolder;
		List<ModNet.NetFile> val = new List<ModNet.NetFile>();
		System.Collections.Generic.IEnumerator<McLibToken> enumerator = default(System.Collections.Generic.IEnumerator<McLibToken>);
		try
		{
			enumerator = Libs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				McLibToken current = enumerator.Current;
				ModBase.FileChecker fileChecker = new ModBase.FileChecker(-1L, (current.Size == 0L) ? (-1) : current.Size, current.SHA1);
				if (fileChecker.Check(current.LocalPath) == null)
				{
					continue;
				}
				if (current.IsLocal)
				{
					ModBase.Log("[Download] 已跳过被标记为本地文件的支持库: " + current.OriginalName);
					continue;
				}
				List<string> val2 = new List<string>();
				if (current.Url == null && Operators.CompareString(current.Name, "net.minecraftforge:forge:universal", false) == 0)
				{
					current.Url = "https://maven.minecraftforge.net" + current.LocalPath.Replace(CustomMcFolder + "libraries", "").Replace("\\", "/");
				}
				if (current.Url != null)
				{
					val2.Add(current.Url);
					if (current.Url.Contains("launcher.mojang.com/v1/objects") || current.Url.Contains("client.txt") || current.Url.Contains(".tsrg"))
					{
						val2.AddRange(ModDownload.DlSourceLauncherOrMetaGet(current.Url));
					}
					if (current.Url.Contains("maven"))
					{
						string text = current.Url.Replace(Strings.Mid(current.Url, 1, ModBase.IndexOfF(current.Url, "maven")), "https://bmclapi2.bangbang93.com/").Replace("maven.fabricmc.net", "maven").Replace("maven.minecraftforge.net", "maven")
							.Replace("maven.neoforged.net/releases", "maven");
						if (ModDownload.DlSourcePreferMojang)
						{
							val2.Add(text);
						}
						else
						{
							val2.Insert(0, text);
						}
					}
				}
				if (current.LocalPath.Contains("transformer-discovery-service"))
				{
					if (!File.Exists(current.LocalPath))
					{
						ModBase.WriteFile(current.LocalPath, ModBase.GetResourceStream("Resources/transformer.jar"));
					}
					ModBase.Log("[Download] 已自动释放 Transformer Discovery Service", ModBase.LogLevel.Developer);
					continue;
				}
				if (current.LocalPath.Contains("optifine\\OptiFine"))
				{
					string text2 = current.LocalPath.Replace(CustomMcFolder + "libraries\\optifine\\OptiFine\\", "").Split("_", (StringSplitOptions)0)[0] + "/" + ModBase.GetFileNameFromPath(current.LocalPath).Replace("-", "_");
					text2 = "/maven/com/optifine/" + text2;
					if (text2.Contains("_pre"))
					{
						text2 = text2.Replace("com/optifine/", "com/optifine/preview_");
					}
					val2.Add("https://bmclapi2.bangbang93.com" + text2);
				}
				else if (current.Name.Contains("LabyMod"))
				{
					val2.Add(current.Url);
					ModBase.Log($"[Download] 获取到 LabyMod 主要库文件的 Size = {current.Size},SHA1 = {current.SHA1}，由于 LabyMod 乱写 Size，已忽略 Size");
					fileChecker = new ModBase.FileChecker(-1L, -1L, current.SHA1);
				}
				else if (val2.Count <= 2)
				{
					val2.AddRange(ModDownload.DlSourceLibraryGet("https://libraries.minecraft.net" + current.LocalPath.Replace(CustomMcFolder + "libraries", "").Replace("\\", "/")));
				}
				val.Add(new ModNet.NetFile(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val2), current.LocalPath, fileChecker));
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		return ModBase.Distinct((System.Collections.Generic.ICollection<ModNet.NetFile>)val, [SpecialName] (ModNet.NetFile a, ModNet.NetFile b) => Operators.CompareString(a.LocalPath, b.LocalPath, false) == 0);
	}

	public static string McLibGet(string Original, bool WithHead = true, bool IgnoreLiteLoader = false, string CustomMcFolder = null)
	{
		CustomMcFolder = CustomMcFolder ?? PathMcFolder;
		string[] array = Original.Split(":", (StringSplitOptions)0);
		string text = string.Concat(new string[11]
		{
			WithHead ? (CustomMcFolder + "libraries\\") : "",
			array[0].Replace(".", "\\"),
			"\\",
			array[1],
			"\\",
			array[2],
			"\\",
			array[1],
			"-",
			array[2],
			".jar"
		});
		checked
		{
			if (text.Contains("optifine\\OptiFine\\1.") && Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)array[2].Split(".", (StringSplitOptions)0)) > 1)
			{
				int num = (int)Math.Round(ModBase.Val(ModBase.BeforeFirst(array[2].Split(".", (StringSplitOptions)0)[1], "_")));
				int num2 = (int)Math.Round((Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)array[2].Split(".", (StringSplitOptions)0)) > 2) ? ModBase.Val(ModBase.BeforeFirst(array[2].Split(".", (StringSplitOptions)0)[2], "_")) : 0.0);
				if ((num == 12 || (num == 20 && num2 >= 4) || num >= 21) && File.Exists(string.Format("{0}libraries\\{1}\\{2}\\{3}\\{4}-{5}-installer.jar", new object[6]
				{
					CustomMcFolder,
					array[0].Replace(".", "\\"),
					array[1],
					array[2],
					array[1],
					array[2]
				})))
				{
					ModLaunch.McLaunchLog("已将 " + Original + " 替换为对应的 Installer 文件");
					text = text.Replace(".jar", "-installer.jar");
				}
			}
			return text;
		}
	}

	public static object ShouldIgnoreFileCheck(McInstance Version)
	{
		return Conversions.ToBoolean(ModBase.Setup.Get("VersionAdvanceAssetsV2", Version)) || Conversions.ToBoolean(Operators.CompareObjectEqual(ModBase.Setup.Get("VersionAdvanceAssets", Version), (object)2, false));
	}

	public static JToken McAssetsGetIndex(McInstance Instance, bool ReturnLegacyOnError = false, bool CheckURLEmpty = false)
	{
		try
		{
			while (true)
			{
				JToken jToken = Instance.JsonObject["assetIndex"];
				if (jToken != null && jToken["id"] != null)
				{
					return jToken;
				}
				if (Instance.JsonObject["assets"] != null)
				{
					Instance.JsonObject["assets"].ToString();
				}
				if (CheckURLEmpty && jToken["url"] != null)
				{
					return jToken;
				}
				if (Operators.CompareString(Instance.InheritInstance, "", false) != 0)
				{
					Instance = new McInstance(PathMcFolder + "versions\\" + Instance.InheritInstance);
					continue;
				}
				break;
			}
		}
		catch (System.Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		if (ReturnLegacyOnError)
		{
			ModBase.Log("[Minecraft] 无法获取资源文件索引下载地址，使用默认的 legacy 下载地址");
			return (JToken)ModBase.GetJson("{\n                \"id\": \"legacy\",\n                \"sha1\": \"c0fd82e8ce9fbc93119e40d96d5a4e62cfa3f729\",\n                \"size\": 134284,\n                \"url\": \"https://launchermeta.mojang.com/mc-staging/assets/legacy/c0fd82e8ce9fbc93119e40d96d5a4e62cfa3f729/legacy.json\",\n                \"totalSize\": 111220701\n            }");
		}
		throw new System.Exception("该实例不存在资源文件索引信息");
	}

	public static string McAssetsGetIndexName(McInstance Instance)
	{
		try
		{
			while (true)
			{
				if (Instance.JsonObject["assetIndex"] != null && Instance.JsonObject["assetIndex"]["id"] != null)
				{
					return Instance.JsonObject["assetIndex"]["id"].ToString();
				}
				if (Instance.JsonObject["assets"] != null)
				{
					return Instance.JsonObject["assets"].ToString();
				}
				if (Operators.CompareString(Instance.InheritInstance, "", false) != 0)
				{
					Instance = new McInstance(PathMcFolder + "versions\\" + Instance.InheritInstance);
					continue;
				}
				break;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "获取资源文件索引名失败");
			ProjectData.ClearProjectError();
		}
		return "legacy";
	}

	private static List<McAssetsToken> McAssetsListGet(McInstance Instance)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		string text = McAssetsGetIndexName(Instance);
		try
		{
			if (!File.Exists($"{PathMcFolder}assets\\indexes\\{text}.json"))
			{
				throw new FileNotFoundException("未找到 Asset Index", PathMcFolder + "assets\\indexes\\" + text + ".json");
			}
			List<McAssetsToken> val = new List<McAssetsToken>();
			JsonObject val2 = (JsonObject)JsonNode.Parse(ModBase.ReadFile($"{PathMcFolder}assets\\indexes\\{text}.json"), (JsonNodeOptions?)null, default(JsonDocumentOptions));
			System.Collections.Generic.IEnumerator<KeyValuePair<string, JsonNode>> enumerator = default(System.Collections.Generic.IEnumerator<KeyValuePair<string, JsonNode>>);
			try
			{
				enumerator = ((JsonNode)val2)["objects"].AsObject().GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					KeyValuePair<string, JsonNode> current = enumerator.Current;
					string localPath = ((((JsonNode)val2)["map_to_resources"] != null && ((JsonNode)val2)["map_to_resources"].GetValue<bool>()) ? (Instance.PathIndie + "resources\\" + current.Key.Replace("/", "\\")) : ((((JsonNode)val2)["virtual"] == null || !((JsonNode)val2)["virtual"].GetValue<bool>()) ? string.Concat(new string[5]
					{
						PathMcFolder,
						"assets\\objects\\",
						Strings.Left(current.Value["hash"].ToString(), 2),
						"\\",
						current.Value["hash"].ToString()
					}) : (PathMcFolder + "assets\\virtual\\legacy\\" + current.Key.Replace("/", "\\"))));
					val.Add(new McAssetsToken
					{
						LocalPath = localPath,
						SourcePath = current.Key,
						Hash = current.Value["hash"].ToString(),
						Size = Conversions.ToLong(current.Value["size"].ToString())
					});
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			return val;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "获取资源文件列表失败：" + text);
			throw;
		}
	}

	public static List<ModNet.NetFile> McAssetsFixList(McInstance Instance, bool CheckHash, [Optional][DefaultParameterValue(null)] ref ModLoader.LoaderBase ProgressFeed)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		List<ModNet.NetFile> val = new List<ModNet.NetFile>();
		checked
		{
			try
			{
				List<McAssetsToken> val2 = McAssetsListGet(Instance);
				if (ProgressFeed != null)
				{
					ProgressFeed.Progress = 0.04;
				}
				int num = val2.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					McAssetsToken mcAssetsToken = val2[i];
					if (ProgressFeed != null)
					{
						ProgressFeed.Progress = 0.05 + 0.94 * (double)i / (double)val2.Count;
					}
					FileInfo val3 = new FileInfo(mcAssetsToken.LocalPath);
					if (!val3.Exists || (mcAssetsToken.Size != 0L && mcAssetsToken.Size != val3.Length) || (CheckHash && mcAssetsToken.Hash != null && Operators.CompareString(mcAssetsToken.Hash, ModBase.GetFileSHA1(mcAssetsToken.LocalPath), false) != 0))
					{
						val.Add(new ModNet.NetFile(ModDownload.DlSourceAssetsGet($"https://resources.download.minecraft.net/{Strings.Left(mcAssetsToken.Hash, 2)}/{mcAssetsToken.Hash}"), mcAssetsToken.LocalPath, new ModBase.FileChecker(-1L, (mcAssetsToken.Size == 0L) ? (-1) : mcAssetsToken.Size, mcAssetsToken.Hash)));
					}
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "获取实例缺失的资源文件下载列表失败");
				ProjectData.ClearProjectError();
			}
			if (ProgressFeed != null)
			{
				ProgressFeed.Progress = 0.99;
			}
			return val;
		}
	}

	public static void McDownloadClientUpdateHint(string VersionName, JObject Json)
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		_Closure_0024__48_002D1 arg = default(_Closure_0024__48_002D1);
		_Closure_0024__48_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__48_002D1(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionName = VersionName;
		try
		{
			_Closure_0024__48_002D0 arg2 = default(_Closure_0024__48_002D0);
			_Closure_0024__48_002D0 CS_0024_003C_003E8__locals1 = new _Closure_0024__48_002D0(null);
			CS_0024_003C_003E8__locals1._0024VB_0024Local_Version = null;
			System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator = ((System.Collections.Generic.IEnumerable<JToken>)Json["versions"]).GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					JToken current = enumerator.Current;
					if (current["id"] != null && Operators.CompareString(current["id"].ToString(), CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionName, false) == 0)
					{
						CS_0024_003C_003E8__locals1._0024VB_0024Local_Version = current;
						break;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			if (CS_0024_003C_003E8__locals1._0024VB_0024Local_Version == null)
			{
				return;
			}
			System.DateTime dateTime = (System.DateTime)CS_0024_003C_003E8__locals1._0024VB_0024Local_Version["releaseTime"];
			string text = string.Format("新版本：{0}{1}", (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionName, (object)"\r\n");
			TimeSpan val = System.DateTime.Now - dateTime;
			string caption = text + ((val.TotalDays > 1.0) ? ("更新时间：" + dateTime.ToString()) : ("更新于：" + TimeUtils.GetTimeSpanString(dateTime - System.DateTime.Now, isShortForm: false)));
			val = System.DateTime.Now - dateTime;
			if (ModMain.MyMsgBox(caption, "Minecraft 更新提示", "确定", "下载", (val.TotalHours > 3.0) ? "更新日志" : "", IsWarn: false, HighLight: true, ForceWait: false, null, null, (Action)([SpecialName] () =>
			{
				ModDownloadLib.McUpdateLogShow(CS_0024_003C_003E8__locals1._0024VB_0024Local_Version);
			})) == 2)
			{
				ModBase.RunInUi((Action)([SpecialName] () =>
				{
					PageDownloadInstall.McVersionWaitingForSelect = CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionName;
					ModMain.FrmMain.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadInstall);
				}));
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "Minecraft 更新提示发送失败（" + (CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionName ?? "Nothing") + "）", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public static bool VersionSortBoolean(string Left, string Right)
	{
		return VersionSortInteger(Left, Right) >= 0;
	}

	public static int VersionSortInteger(string Left, string Right)
	{
		if (Operators.CompareString(Left, "未知版本", false) == 0 || Operators.CompareString(Right, "未知版本", false) == 0)
		{
			if (Operators.CompareString(Left, "未知版本", false) == 0 && Operators.CompareString(Right, "未知版本", false) != 0)
			{
				return 1;
			}
			if (Operators.CompareString(Left, "未知版本", false) == 0 && Operators.CompareString(Right, "未知版本", false) == 0)
			{
				return 0;
			}
			if (Operators.CompareString(Left, "未知版本", false) != 0 && Operators.CompareString(Right, "未知版本", false) == 0)
			{
				return -1;
			}
		}
		Left = Left.ToLowerInvariant();
		Right = Right.ToLowerInvariant();
		List<string> val = ModBase.RegexSearch(Left.Replace("快照", "snapshot").Replace("预览版", "pre"), "[a-z]+|[0-9]+", (RegexOptions)0);
		List<string> val2 = ModBase.RegexSearch(Right.Replace("快照", "snapshot").Replace("预览版", "pre"), "[a-z]+|[0-9]+", (RegexOptions)0);
		int num = 0;
		checked
		{
			while (true)
			{
				if (val.Count - 1 < num && val2.Count - 1 < num)
				{
					if (Operators.CompareString(Left, Right, false) > 0)
					{
						return 1;
					}
					if (Operators.CompareString(Left, Right, false) < 0)
					{
						return -1;
					}
					return 0;
				}
				string text = ((val.Count - 1 < num) ? "-1" : val[num]);
				string text2 = ((val2.Count - 1 < num) ? "-1" : val2[num]);
				if (Operators.CompareString(text, text2, false) != 0)
				{
					if (Operators.CompareString(text, "pre", false) == 0 || Operators.CompareString(text, "snapshot", false) == 0)
					{
						text = "-3";
					}
					if (Operators.CompareString(text, "rc", false) == 0)
					{
						text = "-2";
					}
					if (Operators.CompareString(text, "experimental", false) == 0)
					{
						text = "-4";
					}
					double num2 = ModBase.Val(text);
					if (Operators.CompareString(text2, "pre", false) == 0 || Operators.CompareString(text2, "snapshot", false) == 0)
					{
						text2 = "-3";
					}
					if (Operators.CompareString(text2, "rc", false) == 0)
					{
						text2 = "-2";
					}
					if (Operators.CompareString(text2, "experimental", false) == 0)
					{
						text2 = "-4";
					}
					double num3 = ModBase.Val(text2);
					if (num2 == 0.0 && num3 == 0.0)
					{
						if (Operators.CompareString(text, text2, false) > 0)
						{
							return 1;
						}
						if (Operators.CompareString(text, text2, false) < 0)
						{
							return -1;
						}
					}
					else
					{
						if (num2 > num3)
						{
							return 1;
						}
						if (num2 < num3)
						{
							break;
						}
					}
				}
				num++;
			}
			return -1;
		}
	}

	public static bool IsVersionNameLikeRelease(string VerName)
	{
		if (PCLVerCompat.StartsWithVerF(VerName, "1.", ic: false))
		{
			if (!VerName.Contains("w") && !VerName.Contains("pre") && !VerName.Contains("rc"))
			{
				return !VerName.Contains("-");
			}
			return false;
		}
		return false;
	}

	public static string FilterAccessToken(string Raw, char FilterChar)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (Raw.Contains("accessToken "))
		{
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = ModBase.RegexSearch(Raw, "(?<=accessToken ([^ ]{5}))[^ ]+(?=[^ ]{5})", (RegexOptions)0).GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					Raw = Raw.Replace(current, new string(FilterChar, Enumerable.Count<char>((System.Collections.Generic.IEnumerable<char>)current)));
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		string accessToken = ModLaunch.McLoginLoader.Output.AccessToken;
		if (accessToken != null && accessToken.Length >= 10 && ModBase.ContainsF(Raw, accessToken, IgnoreCase: true) && Operators.CompareString(ModLaunch.McLoginLoader.Output.Uuid, ModLaunch.McLoginLoader.Output.AccessToken, false) != 0)
		{
			Raw = Raw.Replace(accessToken, Strings.Left(accessToken, 5) + new string(FilterChar, checked(accessToken.Length - 10)) + Strings.Right(accessToken, 5));
		}
		return Raw;
	}

	public static string FilterUserName(string Raw, char FilterChar)
	{
		string folderPath = Environment.GetFolderPath((System.Environment.SpecialFolder)40);
		string text = Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)folderPath.Split("\\", (StringSplitOptions)0));
		string text2 = folderPath.Replace(text, new string(FilterChar, text.Length));
		return Raw.Replace(folderPath, text2);
	}
}
