using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using fNbt;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PCL;

[StandardModule]
public sealed class ModLocalComp
{
	public class LocalCompFile
	{
		public enum LocalFileStatus
		{
			Fine,
			Disabled,
			Unavailable
		}

		public delegate void OnCompUpdateEventHandler(LocalCompFile sender);

		public readonly string Path;

		private bool _nbtDataLoaded;

		private string _Name;

		private string _Description;

		private List<string> _tags;

		public string _Version;

		private string _ModId;

		public List<string> PossibleModId;

		private string _Url;

		private string _Authors;

		private long? _litematicTimeCreated;

		private long? _litematicTimeModified;

		private string _schemOriginalName;

		private string _litematicOriginalName;

		private int? _litematicVersion;

		private string _litematicEnclosingSize;

		private int? _litematicRegionCount;

		private int? _litematicTotalBlocks;

		private int? _litematicTotalVolume;

		private string _structureGameVersion;

		private int? _structureDataVersion;

		private string _structureAuthor;

		private int? _spongeVersion;

		private Dictionary<string, string> _Dependencies;

		private bool IsLoaded;

		private System.Exception _FileUnavailableReason;

		private bool IsInfoWithoutClassAvailable;

		private bool IsInfoWithClassLoaded;

		private bool IsInfoWithClassAvailable;

		[CompilerGenerated]
		private OnCompUpdateEventHandler OnCompUpdateEvent;

		private ModComp.CompProject _Comp;

		public ModComp.CompFile CompFile;

		private ModComp.CompFile _UpdateFile;

		public List<string> ChangelogUrls;

		public bool CompLoaded;

		private uint? _CurseForgeHash;

		private string _ModrinthHash;

		public bool IsFolder => ModBase.EndsWithF(Path, "\\__FOLDER__", IgnoreCase: true);

		public string ActualPath
		{
			get
			{
				if (IsFolder)
				{
					return Path.Replace("\\__FOLDER__", "");
				}
				return Path;
			}
		}

		public string RawPath => ModBase.GetPathFromFullPath(Path) + RawFileName;

		public string FileName
		{
			get
			{
				if (IsFolder && !string.IsNullOrEmpty(Name))
				{
					return Name;
				}
				return ModBase.GetFileNameFromPath(Path);
			}
		}

		public string RawFileName => FileName.Replace(".disabled", "").Replace(".old", "");

		public LocalFileStatus State
		{
			get
			{
				Load();
				if (!IsFileAvailable)
				{
					return LocalFileStatus.Unavailable;
				}
				if (ModBase.EndsWithF(Path, ".disabled", IgnoreCase: true) || ModBase.EndsWithF(Path, ".old", IgnoreCase: true))
				{
					return LocalFileStatus.Disabled;
				}
				return LocalFileStatus.Fine;
			}
		}

		public string Name
		{
			get
			{
				if (_Name == null)
				{
					Load();
				}
				if (_Name == null)
				{
					_Name = _ModId;
				}
				if (_Name == null)
				{
					if (IsFolder)
					{
						_Name = ModBase.GetFolderNameFromPath(ActualPath);
					}
					else
					{
						_Name = ModBase.GetFileNameWithoutExtentionFromPath(Path);
					}
				}
				return _Name;
			}
			set
			{
				if (_Name == null && value != null && !value.Contains("modname") && Operators.CompareString(value.ToLower(), "name", false) != 0 && Enumerable.Count<char>((System.Collections.Generic.IEnumerable<char>)value) > 1 && Operators.CompareString(ModBase.Val(value).ToString(), value, false) != 0)
				{
					_Name = value;
				}
			}
		}

		public string Description
		{
			get
			{
				if (_Description == null)
				{
					Load();
				}
				if (_Description == null && FileUnavailableReason != null)
				{
					_Description = FileUnavailableReason.Message;
				}
				return _Description;
			}
			set
			{
				if (_Description == null && value != null && Enumerable.Count<char>((System.Collections.Generic.IEnumerable<char>)value) > 2)
				{
					_Description = value.ToString().Trim('\n');
					if (_Description.ToLower().LastIndexOfAny(Conversions.ToCharArrayRankOne("qwertyuiopasdfghjklzxcvbnm0123456789")) == checked(Enumerable.Count<char>((System.Collections.Generic.IEnumerable<char>)_Description) - 1))
					{
						_Description += ".";
					}
				}
			}
		}

		public List<string> Tags
		{
			get
			{
				if (_tags == null)
				{
					_tags = new List<string>();
					if (IsFolder)
					{
						_tags.Add("文件夹");
					}
					else
					{
						switch (System.IO.Path.GetExtension(RawPath).ToLower())
						{
						case ".litematic":
							_tags.Add("原理图");
							break;
						case ".schem":
						case ".schematic":
							_tags.Add("Schematic结构");
							break;
						case ".nbt":
							_tags.Add("原版结构");
							break;
						}
					}
				}
				return _tags;
			}
		}

		public string Version
		{
			get
			{
				if (_Version == null)
				{
					Load();
				}
				return _Version;
			}
			set
			{
				if (_Version == null || !ModBase.RegexCheck(_Version, "[0-9.\\-]+", (RegexOptions)0))
				{
					if (value != null && ModBase.ContainsF(value, "version", IgnoreCase: true))
					{
						value = "version";
					}
					_Version = value;
				}
			}
		}

		public string ModId
		{
			get
			{
				if (_ModId == null)
				{
					Load();
				}
				return _ModId;
			}
			set
			{
				if (value == null)
				{
					return;
				}
				value = ModBase.RegexSeek(value, "[0-9a-zA-Z_-]+", (RegexOptions)0);
				if (value != null && Enumerable.Count<char>((System.Collections.Generic.IEnumerable<char>)value) > 1 && Operators.CompareString(ModBase.Val(value).ToString(), value, false) != 0 && !ModBase.ContainsF(value, "name", IgnoreCase: true) && !ModBase.ContainsF(value, "modid", IgnoreCase: true))
				{
					if (!PossibleModId.Contains(value))
					{
						PossibleModId.Add(value);
					}
					if (_ModId == null)
					{
						_ModId = value;
					}
				}
			}
		}

		public string Url
		{
			get
			{
				if (_Url == null)
				{
					Load();
				}
				return _Url;
			}
			set
			{
				if (_Url == null && value != null && ModBase.StartsWithF(value, "http"))
				{
					_Url = value;
				}
			}
		}

		public string Authors
		{
			get
			{
				if (_Authors == null)
				{
					Load();
				}
				return _Authors;
			}
			set
			{
				if (_Authors == null && !string.IsNullOrWhiteSpace(value))
				{
					_Authors = value;
				}
			}
		}

		public long? LitematicTimeCreated
		{
			get
			{
				LoadNbtDataIfNeeded();
				return _litematicTimeCreated;
			}
		}

		public long? LitematicTimeModified
		{
			get
			{
				LoadNbtDataIfNeeded();
				return _litematicTimeModified;
			}
		}

		public string SchemOriginalName
		{
			get
			{
				LoadNbtDataIfNeeded();
				return _schemOriginalName;
			}
		}

		public string LitematicOriginalName
		{
			get
			{
				LoadNbtDataIfNeeded();
				return _litematicOriginalName;
			}
		}

		public int? LitematicVersion
		{
			get
			{
				LoadNbtDataIfNeeded();
				return _litematicVersion;
			}
		}

		public string LitematicEnclosingSize
		{
			get
			{
				LoadNbtDataIfNeeded();
				return _litematicEnclosingSize;
			}
		}

		public int? LitematicRegionCount
		{
			get
			{
				LoadNbtDataIfNeeded();
				return _litematicRegionCount;
			}
		}

		public int? LitematicTotalBlocks
		{
			get
			{
				LoadNbtDataIfNeeded();
				return _litematicTotalBlocks;
			}
		}

		public int? LitematicTotalVolume
		{
			get
			{
				LoadNbtDataIfNeeded();
				return _litematicTotalVolume;
			}
		}

		public string StructureGameVersion
		{
			get
			{
				LoadNbtDataIfNeeded();
				return _structureGameVersion;
			}
		}

		public int? StructureDataVersion
		{
			get
			{
				LoadNbtDataIfNeeded();
				return _structureDataVersion;
			}
		}

		public string StructureAuthor
		{
			get
			{
				LoadNbtDataIfNeeded();
				return _structureAuthor;
			}
		}

		public int? SpongeVersion
		{
			get
			{
				LoadNbtDataIfNeeded();
				return _spongeVersion;
			}
		}

		[field: CompilerGenerated]
		public string Logo
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public Dictionary<string, string> Dependencies
		{
			get
			{
				Load();
				return _Dependencies;
			}
		}

		public bool IsFileAvailable
		{
			get
			{
				Load();
				return FileUnavailableReason == null;
			}
		}

		public System.Exception FileUnavailableReason
		{
			get
			{
				Load();
				return _FileUnavailableReason;
			}
		}

		public ModComp.CompProject Comp
		{
			get
			{
				return _Comp;
			}
			set
			{
				_Comp = value;
				OnCompUpdateEvent?.Invoke(this);
			}
		}

		public ModComp.CompFile UpdateFile
		{
			get
			{
				return _UpdateFile;
			}
			set
			{
				_UpdateFile = value;
				OnCompUpdateEvent?.Invoke(this);
			}
		}

		public bool CanUpdate => Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenFunctionModUpdate"))) && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)ChangelogUrls)));

		public uint CurseForgeHash
		{
			get
			{
				//IL_0016: Unknown result type (might be due to invalid IL or missing references)
				//IL_001c: Expected O, but got Unknown
				checked
				{
					if (!_CurseForgeHash.HasValue)
					{
						FileInfo val = new FileInfo(Path);
						string key = Conversions.ToString(ModBase.GetHash($"{RawPath}-{((FileSystemInfo)val).LastWriteTime.ToLongTimeString()}-{val.Length}-C"));
						string text = ModBase.ReadIni(ModBase.PathTemp + "Cache\\CompHash.ini", key);
						if (Operators.CompareString(text, "", false) != 0 && ModBase.RegexCheck(text, "^\\d+$", (RegexOptions)0))
						{
							_CurseForgeHash = Conversions.ToUInteger(text);
							return _CurseForgeHash.Value;
						}
						List<byte> val2 = new List<byte>();
						byte[] array = ModBase.ReadFileBytes(Path);
						foreach (byte b in array)
						{
							if (b != 9 && b != 10 && b != 13 && b != 32)
							{
								val2.Add(b);
							}
						}
						int count = val2.Count;
						uint num = (uint)(1 ^ count);
						int num2 = count - 4;
						int j;
						for (j = 0; j <= num2; j += 4)
						{
							uint num3;
							unchecked
							{
								num3 = (uint)checked(val2[j] | (val2[j + 1] << 8) | (val2[j + 2] << 16) | (val2[j + 3] << 24));
							}
							num3 = (uint)((unchecked((long)num3) * 1540483477L) & 0xFFFFFFFFu);
							num3 ^= num3 >> 24;
							num3 = (uint)((unchecked((long)num3) * 1540483477L) & 0xFFFFFFFFu);
							num = (uint)((unchecked((long)num) * 1540483477L) & 0xFFFFFFFFu);
							num ^= num3;
						}
						switch (count - j)
						{
						case 3:
							unchecked
							{
								num ^= (uint)(val2[j] | (val2[checked(j + 1)] << 8));
								num ^= (uint)(val2[checked(j + 2)] << 16);
							}
							num = (uint)((unchecked((long)num) * 1540483477L) & 0xFFFFFFFFu);
							break;
						case 2:
							unchecked
							{
								num ^= (uint)(val2[j] | (val2[checked(j + 1)] << 8));
							}
							num = (uint)((unchecked((long)num) * 1540483477L) & 0xFFFFFFFFu);
							break;
						case 1:
							num ^= val2[j];
							num = (uint)((unchecked((long)num) * 1540483477L) & 0xFFFFFFFFu);
							break;
						}
						num ^= num >> 13;
						num = (uint)((unchecked((long)num) * 1540483477L) & 0xFFFFFFFFu);
						num ^= num >> 15;
						_CurseForgeHash = num;
						ModBase.WriteIni(ModBase.PathTemp + "Cache\\CompHash.ini", key, num.ToString());
					}
					return _CurseForgeHash.Value;
				}
			}
		}

		public string ModrinthHash
		{
			get
			{
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				//IL_0017: Expected O, but got Unknown
				if (_ModrinthHash == null)
				{
					FileInfo val = new FileInfo(Path);
					string key = Conversions.ToString(ModBase.GetHash($"{RawPath}-{((FileSystemInfo)val).LastWriteTime.ToLongTimeString()}-{val.Length}-M"));
					string text = ModBase.ReadIni(ModBase.PathTemp + "Cache\\CompHash.ini", key);
					if (Operators.CompareString(text, "", false) != 0)
					{
						_ModrinthHash = text;
						return _ModrinthHash;
					}
					_ModrinthHash = ModBase.GetFileSHA1(Path);
					ModBase.WriteIni(ModBase.PathTemp + "Cache\\CompHash.ini", key, _ModrinthHash);
				}
				return _ModrinthHash;
			}
		}

		public event OnCompUpdateEventHandler OnCompUpdate
		{
			[CompilerGenerated]
			add
			{
				OnCompUpdateEventHandler onCompUpdateEventHandler = OnCompUpdateEvent;
				OnCompUpdateEventHandler onCompUpdateEventHandler2;
				do
				{
					onCompUpdateEventHandler2 = onCompUpdateEventHandler;
					OnCompUpdateEventHandler onCompUpdateEventHandler3 = (OnCompUpdateEventHandler)System.Delegate.Combine((System.Delegate)onCompUpdateEventHandler2, (System.Delegate)value);
					onCompUpdateEventHandler = Interlocked.CompareExchange<OnCompUpdateEventHandler>(ref OnCompUpdateEvent, onCompUpdateEventHandler3, onCompUpdateEventHandler2);
				}
				while (onCompUpdateEventHandler != onCompUpdateEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				OnCompUpdateEventHandler onCompUpdateEventHandler = OnCompUpdateEvent;
				OnCompUpdateEventHandler onCompUpdateEventHandler2;
				do
				{
					onCompUpdateEventHandler2 = onCompUpdateEventHandler;
					OnCompUpdateEventHandler onCompUpdateEventHandler3 = (OnCompUpdateEventHandler)System.Delegate.Remove((System.Delegate)onCompUpdateEventHandler2, (System.Delegate)value);
					onCompUpdateEventHandler = Interlocked.CompareExchange<OnCompUpdateEventHandler>(ref OnCompUpdateEvent, onCompUpdateEventHandler3, onCompUpdateEventHandler2);
				}
				while (onCompUpdateEventHandler != onCompUpdateEventHandler2);
			}
		}

		public LocalCompFile(string Path)
		{
			_nbtDataLoaded = false;
			_Name = null;
			_Description = null;
			_tags = null;
			_Version = null;
			_ModId = null;
			PossibleModId = new List<string>();
			_Url = null;
			_Authors = null;
			_Dependencies = new Dictionary<string, string>();
			IsLoaded = false;
			_FileUnavailableReason = null;
			IsInfoWithoutClassAvailable = false;
			IsInfoWithClassLoaded = false;
			IsInfoWithClassAvailable = false;
			ChangelogUrls = new List<string>();
			CompLoaded = false;
			this.Path = Path ?? "";
		}

		private void AddDependency(string ModID, string VersionRequirement = null)
		{
			if (ModID == null || Enumerable.Count<char>((System.Collections.Generic.IEnumerable<char>)ModID) < 2)
			{
				return;
			}
			ModID = ModID.ToLower();
			if (Operators.CompareString(ModID, "name", false) == 0 || Operators.CompareString(ModBase.Val(ModID).ToString(), ModID, false) == 0)
			{
				return;
			}
			if (VersionRequirement == null || (!VersionRequirement.Contains(".") && !VersionRequirement.Contains("-")) || VersionRequirement.Contains("$"))
			{
				VersionRequirement = null;
			}
			else if (!ModBase.StartsWithF(VersionRequirement, "[") && !ModBase.StartsWithF(VersionRequirement, "(") && !ModBase.EndsWithF(VersionRequirement, "]") && !ModBase.EndsWithF(VersionRequirement, ")"))
			{
				VersionRequirement = "[" + VersionRequirement + ",)";
			}
			if (_Dependencies.ContainsKey(ModID))
			{
				if (_Dependencies[ModID] == null)
				{
					_Dependencies[ModID] = VersionRequirement;
				}
			}
			else
			{
				_Dependencies.Add(ModID, VersionRequirement);
			}
		}

		private void Init()
		{
			_Name = null;
			_Description = null;
			_Version = null;
			_ModId = null;
			PossibleModId = new List<string>();
			_Dependencies = new Dictionary<string, string>();
			IsLoaded = false;
			_FileUnavailableReason = null;
			IsInfoWithClassLoaded = false;
			IsInfoWithClassAvailable = false;
		}

		public void LoadBasicInfo()
		{
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			try
			{
				if (IsFolder)
				{
					IsLoaded = true;
				}
				else if (!File.Exists(Path))
				{
					_FileUnavailableReason = (System.Exception)new FileNotFoundException("未找到资源文件（" + Path + ")");
					IsLoaded = true;
				}
				else if (ModBase.EndsWithF(Path, ".litematic", IgnoreCase: true) || ModBase.EndsWithF(Path, ".nbt", IgnoreCase: true) || ModBase.EndsWithF(Path, ".schem", IgnoreCase: true) || ModBase.EndsWithF(Path, ".schematic", IgnoreCase: true))
				{
					_Name = ModBase.GetFileNameWithoutExtentionFromPath(Path);
					IsLoaded = true;
				}
				else
				{
					Load();
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, $"加载基本信息失败：{Path}");
				ProjectData.ClearProjectError();
			}
		}

		public void LoadNbtDataIfNeeded()
		{
			try
			{
				if (!_nbtDataLoaded)
				{
					if (ModBase.EndsWithF(Path, ".litematic", IgnoreCase: true))
					{
						LoadLitematicNbtData();
					}
					else if (ModBase.EndsWithF(Path, ".nbt", IgnoreCase: true))
					{
						LoadStructureNbtData();
					}
					else if (ModBase.EndsWithF(Path, ".schem", IgnoreCase: true))
					{
						LoadSchemNbtData();
					}
					else if (ModBase.EndsWithF(Path, ".schematic", IgnoreCase: true))
					{
						LoadSchematicNbtData();
					}
					_nbtDataLoaded = true;
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, $"延迟加载NBT数据失败：{Path}");
				ProjectData.ClearProjectError();
			}
		}

		public void Load(bool ForceReload = false)
		{
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Expected O, but got Unknown
			//IL_0219: Expected O, but got Unknown
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Expected O, but got Unknown
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Expected O, but got Unknown
			//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Expected O, but got Unknown
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Expected O, but got Unknown
			if (IsLoaded && !ForceReload)
			{
				return;
			}
			Init();
			if (Path.Length < 2)
			{
				_FileUnavailableReason = (System.Exception)new FileNotFoundException("错误的资源文件路径（" + (Path ?? "null") + "）");
				IsLoaded = true;
				return;
			}
			if (IsFolder)
			{
				if (!Directory.Exists(ActualPath))
				{
					_FileUnavailableReason = (System.Exception)new DirectoryNotFoundException("未找到文件夹（" + ActualPath + "）");
					IsLoaded = true;
				}
				else
				{
					IsLoaded = true;
				}
				return;
			}
			if (!File.Exists(Path))
			{
				_FileUnavailableReason = (System.Exception)new FileNotFoundException("未找到资源文件（" + Path + "）");
				IsLoaded = true;
				return;
			}
			if (ModBase.EndsWithF(Path, ".litematic", IgnoreCase: true) || ModBase.EndsWithF(Path, ".nbt", IgnoreCase: true) || ModBase.EndsWithF(Path, ".schem", IgnoreCase: true) || ModBase.EndsWithF(Path, ".schematic", IgnoreCase: true))
			{
				try
				{
					_Name = ModBase.GetFileNameWithoutExtentionFromPath(Path);
					if (ModBase.EndsWithF(Path, ".litematic", IgnoreCase: true))
					{
						LoadLitematicNbtData();
					}
					else if (ModBase.EndsWithF(Path, ".schem", IgnoreCase: true) || ModBase.EndsWithF(Path, ".schematic", IgnoreCase: true))
					{
						if (ModBase.EndsWithF(Path, ".schem", IgnoreCase: true))
						{
							LoadSchemNbtData();
						}
						else
						{
							LoadSchematicNbtData();
						}
					}
					else if (ModBase.EndsWithF(Path, ".nbt", IgnoreCase: true))
					{
						LoadStructureNbtData();
					}
					_nbtDataLoaded = true;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "投影文件信息获取失败（" + Path + "）", ModBase.LogLevel.Developer);
					_FileUnavailableReason = ex2;
					ProjectData.ClearProjectError();
				}
				IsLoaded = true;
				return;
			}
			ZipArchive val = null;
			try
			{
				val = new ZipArchive((Stream)new FileStream(Path, (FileMode)3));
				LookupMetadata(val);
			}
			catch (UnauthorizedAccessException val2)
			{
				ProjectData.SetProjectError((System.Exception)val2);
				UnauthorizedAccessException val3 = val2;
				ModBase.Log((System.Exception)(object)val3, "资源文件由于无权限无法打开（" + Path + "）", ModBase.LogLevel.Developer);
				_FileUnavailableReason = (System.Exception)new UnauthorizedAccessException("没有读取此文件的权限，请尝试右键以管理员身份运行 PCL", (System.Exception)(object)val3);
				ProjectData.ClearProjectError();
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "资源文件无法打开（" + Path + "）", ModBase.LogLevel.Developer);
				_FileUnavailableReason = ex4;
				ProjectData.ClearProjectError();
			}
			finally
			{
				if (val != null)
				{
					val.Dispose();
				}
			}
			IsLoaded = true;
		}

		private void LookupMetadata(ZipArchive Jar)
		{
			//IL_098e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f31: Unknown result type (might be due to invalid IL or missing references)
			//IL_0f36: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c0c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c11: Unknown result type (might be due to invalid IL or missing references)
			//IL_09f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c17: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c1c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bd5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0bda: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d03: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d08: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d46: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d4b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d21: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d26: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d64: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d69: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d89: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d8e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d97: Unknown result type (might be due to invalid IL or missing references)
			//IL_0d9c: Unknown result type (might be due to invalid IL or missing references)
			checked
			{
				try
				{
					ZipArchiveEntry entry = Jar.GetEntry("mcmod.info");
					string text = null;
					if (entry != null)
					{
						text = ModBase.ReadFile(entry.Open());
						if (text.Length < 15)
						{
							text = null;
						}
					}
					if (text != null)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(ModBase.GetJson(text));
						JObject jObject = ((!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(objectValue, (System.Type)null, "Type", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)JTokenType.Array, false)) ? ((JObject)NewLateBinding.LateIndexGet(NewLateBinding.LateIndexGet(objectValue, new object[] { "modList" }, (string[])null), new object[] { 0 }, (string[])null)) : ((JObject)NewLateBinding.LateIndexGet(objectValue, new object[] { 0 }, (string[])null)));
						Name = (string?)jObject["name"];
						Description = (string?)jObject["description"];
						Version = (string?)jObject["version"];
						Url = (string?)jObject["url"];
						ModId = (string?)jObject["modid"];
						JArray jArray = (JArray)jObject["authorList"];
						if (jArray != null)
						{
							List<string> val = new List<string>();
							System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
							try
							{
								enumerator = jArray.GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator).MoveNext())
								{
									JToken current = enumerator.Current;
									val.Add(current.ToString());
								}
							}
							finally
							{
								((System.IDisposable)enumerator)?.Dispose();
							}
							if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val))
							{
								Authors = ModBase.Join((System.Collections.IEnumerable)val, ", ");
							}
						}
						string text2 = (string?)jObject["logoFile"];
						if (text2 != null)
						{
							ZipArchiveEntry entry2 = Jar.GetEntry(text2);
							if (entry2 != null)
							{
								string stringMD = ModBase.GetStringMD5(entry2.Length.ToString() + entry2.CompressedLength + Path);
								Logo = $"{ModBase.PathTemp}MyImage\\{stringMD}.png";
								Stream val2 = entry2.Open();
								try
								{
									FileStream val3 = File.Create(Logo);
									try
									{
										val2.CopyTo((Stream)(object)val3);
									}
									finally
									{
										((System.IDisposable)val3)?.Dispose();
									}
								}
								finally
								{
									((System.IDisposable)val2)?.Dispose();
								}
							}
						}
						JArray jArray2 = (JArray)jObject["requiredMods"];
						if (jArray2 != null)
						{
							System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
							try
							{
								enumerator2 = jArray2.GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator2).MoveNext())
								{
									string text3 = (string?)enumerator2.Current;
									if (!string.IsNullOrEmpty(text3))
									{
										text3 = text3.Substring(ModBase.IndexOfF(text3, ":") + 1);
										if (text3.Contains("@"))
										{
											AddDependency(text3.Split("@", (StringSplitOptions)0)[0], text3.Split("@", (StringSplitOptions)0)[1]);
										}
										else
										{
											AddDependency(text3);
										}
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator2)?.Dispose();
							}
						}
						jArray2 = (JArray)jObject["dependancies"];
						if (jArray2 != null)
						{
							System.Collections.Generic.IEnumerator<JToken> enumerator3 = default(System.Collections.Generic.IEnumerator<JToken>);
							try
							{
								enumerator3 = jArray2.GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator3).MoveNext())
								{
									string text4 = (string?)enumerator3.Current;
									if (!string.IsNullOrEmpty(text4))
									{
										text4 = text4.Substring(ModBase.IndexOfF(text4, ":") + 1);
										if (text4.Contains("@"))
										{
											AddDependency(text4.Split("@", (StringSplitOptions)0)[0], text4.Split("@", (StringSplitOptions)0)[1]);
										}
										else
										{
											AddDependency(text4);
										}
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator3)?.Dispose();
							}
						}
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "读取 mcmod.info 时出现未知错误（" + Path + "）", ModBase.LogLevel.Developer);
					ProjectData.ClearProjectError();
				}
				try
				{
					ZipArchiveEntry entry3 = Jar.GetEntry("fabric.mod.json");
					string text5 = null;
					if (entry3 != null)
					{
						text5 = ModBase.ReadFile(entry3.Open(), Encoding.UTF8);
						if (!text5.Contains("schemaVersion"))
						{
							text5 = null;
						}
					}
					if (text5 != null)
					{
						JObject jObject2 = (JObject)ModBase.GetJson(text5);
						if (jObject2.ContainsKey("name"))
						{
							Name = (string?)jObject2["name"];
						}
						if (jObject2.ContainsKey("version"))
						{
							Version = (string?)jObject2["version"];
						}
						if (jObject2.ContainsKey("description"))
						{
							Description = (string?)jObject2["description"];
						}
						if (jObject2.ContainsKey("id"))
						{
							ModId = (string?)jObject2["id"];
						}
						if (jObject2.ContainsKey("contact"))
						{
							Url = (string?)(jObject2["contact"]["homepage"] ?? ((JToken)""));
						}
						JArray jArray3 = (JArray)jObject2["authors"];
						if (jArray3 != null)
						{
							List<string> val4 = new List<string>();
							System.Collections.Generic.IEnumerator<JToken> enumerator4 = default(System.Collections.Generic.IEnumerator<JToken>);
							try
							{
								enumerator4 = jArray3.GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator4).MoveNext())
								{
									JToken current2 = enumerator4.Current;
									val4.Add(current2.ToString());
								}
							}
							finally
							{
								((System.IDisposable)enumerator4)?.Dispose();
							}
							if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val4))
							{
								Authors = ModBase.Join((System.Collections.IEnumerable)val4, ", ");
							}
						}
						if (jObject2.ContainsKey("icon"))
						{
							string text6 = (string?)jObject2["icon"];
							if (text6 != null)
							{
								ZipArchiveEntry entry4 = Jar.GetEntry(text6);
								if (entry4 != null)
								{
									string stringMD2 = ModBase.GetStringMD5(entry4.Length.ToString() + entry4.CompressedLength + Path);
									Logo = $"{ModBase.PathTemp}MyImage\\{stringMD2}.png";
									Stream val5 = entry4.Open();
									try
									{
										FileStream val6 = File.Create(Logo);
										try
										{
											val5.CopyTo((Stream)(object)val6);
										}
										finally
										{
											((System.IDisposable)val6)?.Dispose();
										}
									}
									finally
									{
										((System.IDisposable)val5)?.Dispose();
									}
								}
							}
						}
						goto IL_1428;
					}
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, "读取 fabric.mod.json 时出现未知错误（" + Path + "）", ModBase.LogLevel.Developer);
					ProjectData.ClearProjectError();
				}
				try
				{
					ZipArchiveEntry entry5 = Jar.GetEntry("quilt.mod.json");
					string text7 = null;
					if (entry5 != null)
					{
						text7 = ModBase.ReadFile(entry5.Open(), Encoding.UTF8);
						if (!text7.Contains("schema_version"))
						{
							text7 = null;
						}
					}
					if (text7 != null)
					{
						JObject jObject3 = (JObject)NewLateBinding.LateIndexGet(ModBase.GetJson(text7), new object[] { "quilt_loader" }, (string[])null);
						if (jObject3.ContainsKey("id"))
						{
							ModId = (string?)jObject3["id"];
						}
						if (jObject3.ContainsKey("version"))
						{
							Version = (string?)jObject3["version"];
						}
						if (jObject3.ContainsKey("metadata"))
						{
							JObject jObject4 = (JObject)jObject3["metadata"];
							if (jObject4.ContainsKey("name"))
							{
								Name = (string?)jObject4["name"];
							}
							if (jObject4.ContainsKey("description"))
							{
								Description = (string?)jObject4["description"];
							}
							if (jObject4.ContainsKey("contact"))
							{
								Url = (string?)(jObject4["contact"]["homepage"] ?? ((JToken)""));
							}
						}
						if (jObject3.ContainsKey("icon"))
						{
							string text8 = (string?)jObject3["icon"];
							if (text8 != null)
							{
								ZipArchiveEntry entry6 = Jar.GetEntry(text8);
								if (entry6 != null)
								{
									string stringMD3 = ModBase.GetStringMD5(entry6.Length.ToString() + entry6.CompressedLength + Path);
									Logo = $"{ModBase.PathTemp}MyImage\\{stringMD3}.png";
									Stream val7 = entry6.Open();
									try
									{
										FileStream val8 = File.Create(Logo);
										try
										{
											val7.CopyTo((Stream)(object)val8);
										}
										finally
										{
											((System.IDisposable)val8)?.Dispose();
										}
									}
									finally
									{
										((System.IDisposable)val7)?.Dispose();
									}
								}
							}
						}
						goto IL_1428;
					}
				}
				catch (System.Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					System.Exception ex6 = ex5;
					ModBase.Log(ex6, "读取 quilt.mod.json 时出现未知错误（" + Path + "）", ModBase.LogLevel.Developer);
					ProjectData.ClearProjectError();
				}
				try
				{
					ZipArchiveEntry entry7 = Jar.GetEntry("META-INF/mods.toml");
					string text9 = null;
					if (entry7 != null)
					{
						text9 = ModBase.ReadFile(entry7.Open());
						if (text9.Length < 15)
						{
							text9 = null;
						}
					}
					if (text9 != null)
					{
						List<string> val9 = new List<string>();
						string[] array = text9.Replace("\r\n", "\n").Replace("\r", "\n").Split("\n", (StringSplitOptions)0);
						for (int i = 0; i < array.Length; i++)
						{
							string text10 = array[i];
							if (!ModBase.StartsWithF(text10, "#"))
							{
								if (text10.Contains("#"))
								{
									text10 = text10.Substring(0, ModBase.IndexOfF(text10, "#"));
								}
								string text11 = text10;
								char[] array2 = new char[] { '\x01', '\x00', '\x06', '\x00', '\x04', '\x00', '\x03', '\x00', '\x05', '\x00' };
								text10 = text11.Trim(array2);
								if (Enumerable.Any<char>((System.Collections.Generic.IEnumerable<char>)text10))
								{
									val9.Add(text10);
								}
							}
						}
						List<KeyValuePair<string, Dictionary<string, object>>> obj = new List<KeyValuePair<string, Dictionary<string, object>>>();
						obj.Add(new KeyValuePair<string, Dictionary<string, object>>("", new Dictionary<string, object>()));
						List<KeyValuePair<string, Dictionary<string, object>>> val10 = obj;
						int num = val9.Count - 1;
						int num2 = 0;
						System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, Dictionary<string, object>>> enumerator5 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, Dictionary<string, object>>>);
						System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, Dictionary<string, object>>> enumerator6 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, Dictionary<string, object>>>);
						while (true)
						{
							if (num2 <= num)
							{
								string text12 = val9[num2];
								if (ModBase.StartsWithF(text12, "[") && ModBase.EndsWithF(text12, "]"))
								{
									string text13 = text12.Trim("[]".ToCharArray());
									val10.Add(new KeyValuePair<string, Dictionary<string, object>>(text13, new Dictionary<string, object>()));
								}
								else
								{
									if (!text12.Contains("="))
									{
										break;
									}
									string text14 = text12.Substring(0, ModBase.IndexOfF(text12, "="));
char[] array3 = new char[] { ' ', '\t', '\u3000' };
									string text15 = text14.TrimEnd(array3);
									string text16 = text12.Substring(ModBase.IndexOfF(text12, "=") + 1);
									char[] array4 = new char[] { (char)1, (char)6, (char)4, (char)3, (char)5 };
									string text17 = text16.TrimStart(array4);
									object obj2;
									if (ModBase.StartsWithF(text17, "\"") && ModBase.EndsWithF(text17, "\""))
									{
										obj2 = text17.Trim('"');
									}
									else if (!ModBase.StartsWithF(text17, "'''"))
									{
										obj2 = ((Operators.CompareString(text17.ToLower(), "true", false) == 0 || Operators.CompareString(text17.ToLower(), "false", false) == 0) ? ((object)(Operators.CompareString(text17.ToLower(), "true", false) == 0)) : ((Operators.CompareString(ModBase.Val(text17).ToString(), text17, false) != 0) ? text17 : ((object)ModBase.Val(text17))));
									}
									else
									{
										List<string> obj3 = new List<string>();
										obj3.Add(text17.TrimStart('\''));
										List<string> val11 = obj3;
										if (ModBase.EndsWithF(val11[0], "'''"))
										{
											val11[0] = val11[0].TrimEnd('\'');
										}
										else
										{
											while (num2 < val9.Count - 1)
											{
												num2++;
												string text18 = val9[num2];
												if (ModBase.EndsWithF(text18, "'''"))
												{
													val11.Add(text18.TrimEnd('\''));
													break;
												}
												val11.Add(text18);
											}
										}
										obj2 = ModBase.Join((System.Collections.IEnumerable)val11, "\n").Trim('\n').Replace("\n", "\r\n");
									}
									Enumerable.Last<KeyValuePair<string, Dictionary<string, object>>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, Dictionary<string, object>>>)val10).Value[text15] = RuntimeHelpers.GetObjectValue(obj2);
								}
								num2++;
								continue;
							}
							Dictionary<string, object> val12 = null;
							try
							{
								enumerator5 = val10.GetEnumerator();
								while (enumerator5.MoveNext())
								{
									KeyValuePair<string, Dictionary<string, object>> current3 = enumerator5.Current;
									if (Operators.CompareString(current3.Key, "mods", false) == 0)
									{
										val12 = current3.Value;
										break;
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator5).Dispose();
							}
							if (val12 == null || !val12.ContainsKey("modId"))
							{
								break;
							}
							ModId = Conversions.ToString(val12["modId"]);
							if (_ModId == null)
							{
								break;
							}
							if (val12.ContainsKey("displayName"))
							{
								Name = Conversions.ToString(val12["displayName"]);
							}
							if (val12.ContainsKey("description"))
							{
								Description = Conversions.ToString(val12["description"]);
							}
							if (val12.ContainsKey("version"))
							{
								Version = Conversions.ToString(val12["version"]);
							}
							if (val10[0].Value.ContainsKey("displayURL"))
							{
								Url = Conversions.ToString(val10[0].Value["displayURL"]);
							}
							if (val10[0].Value.ContainsKey("authors"))
							{
								Authors = Conversions.ToString(val10[0].Value["authors"]);
							}
							try
							{
								enumerator6 = val10.GetEnumerator();
								while (enumerator6.MoveNext())
								{
									KeyValuePair<string, Dictionary<string, object>> current4 = enumerator6.Current;
									if (Operators.CompareString(current4.Key.ToLower(), $"dependencies.{ModId.ToLower()}", false) == 0)
									{
										Dictionary<string, object> value = current4.Value;
										if (Conversions.ToBoolean((object)(value.ContainsKey("modId") && value.ContainsKey("mandatory") && Conversions.ToBoolean(value["mandatory"]) && value.ContainsKey("side") && Operators.CompareString(value["side"].ToString().ToLower(), "server", false) != 0)))
										{
											AddDependency(Conversions.ToString(value["modId"]), Conversions.ToString(value.ContainsKey("versionRange") ? value["versionRange"] : null));
										}
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator6).Dispose();
							}
							goto IL_1428;
						}
					}
				}
				catch (System.Exception ex7)
				{
					ProjectData.SetProjectError(ex7);
					System.Exception ex8 = ex7;
					ModBase.Log(ex8, "读取 mods.toml 时出现未知错误（" + Path + "）", ModBase.LogLevel.Developer);
					ProjectData.ClearProjectError();
				}
				try
				{
					ZipArchiveEntry entry8 = Jar.GetEntry("META-INF/fml_cache_annotation.json");
					string text19 = null;
					if (entry8 != null)
					{
						text19 = ModBase.ReadFile(entry8.Open(), Encoding.UTF8);
						if (!text19.Contains("Lnet/minecraftforge/fml/common/Mod;"))
						{
							text19 = null;
						}
					}
					JObject jObject6;
					if (text19 != null)
					{
						JObject jObject5 = (JObject)ModBase.GetJson(text19);
						jObject6 = null;
						System.Collections.Generic.IEnumerator<KeyValuePair<string, JToken>> enumerator7 = default(System.Collections.Generic.IEnumerator<KeyValuePair<string, JToken>>);
						try
						{
							enumerator7 = jObject5.GetEnumerator();
							System.Collections.Generic.IEnumerator<JToken> enumerator8 = default(System.Collections.Generic.IEnumerator<JToken>);
							while (((System.Collections.IEnumerator)enumerator7).MoveNext())
							{
								JArray jArray4 = (JArray)enumerator7.Current.Value["annotations"];
								if (jArray4 == null)
								{
									continue;
								}
								try
								{
									enumerator8 = jArray4.GetEnumerator();
									while (((System.Collections.IEnumerator)enumerator8).MoveNext())
									{
										JToken current5 = enumerator8.Current;
										if (Operators.CompareString((string?)(current5["name"] ?? ((JToken)"")), "Lnet/minecraftforge/fml/common/Mod;", false) != 0)
										{
											continue;
										}
										jObject6 = (JObject)current5["values"];
										goto IL_0fdf;
									}
								}
								finally
								{
									((System.IDisposable)enumerator8)?.Dispose();
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator7)?.Dispose();
						}
					}
					goto end_IL_0ecf;
					IL_0fdf:
					if (jObject6.ContainsKey("useMetadata") && Operators.CompareString((jObject6["useMetadata"]["value"] ?? ((JToken)"")).ToString().ToLower(), "true", false) == 0)
					{
						string text20 = (string?)jObject6["modid"]["value"];
						if (text20 != null)
						{
							text20 = ModBase.RegexSeek(text20.ToLower(), "[0-9a-z_]+", (RegexOptions)0);
							if (text20 != null && Operators.CompareString(text20.ToLower(), "name", false) != 0 && Enumerable.Count<char>((System.Collections.Generic.IEnumerable<char>)text20) > 1 && Operators.CompareString(ModBase.Val(text20).ToString(), text20, false) != 0 && !PossibleModId.Contains(text20))
							{
								PossibleModId.Add(text20);
							}
						}
					}
					else
					{
						if (jObject6.ContainsKey("name"))
						{
							Name = (string?)jObject6["name"]["value"];
						}
						if (jObject6.ContainsKey("version"))
						{
							Version = (string?)jObject6["version"]["value"];
						}
						if (jObject6.ContainsKey("modid"))
						{
							ModId = (string?)jObject6["modid"]["value"];
						}
						if (!jObject6.ContainsKey("serverSideOnly") || !jObject6["serverSideOnly"]["value"].ToObject<bool>())
						{
							string text21 = (string?)(((jObject6["acceptedMinecraftVersions"] != null) ? jObject6["acceptedMinecraftVersions"]["value"] : ((JToken)"")) ?? ((JToken)""));
							if (Operators.CompareString(text21, "", false) != 0)
							{
								AddDependency("minecraft", text21);
							}
							string text22 = (string?)(((jObject6["dependencies"] != null) ? jObject6["dependencies"]["value"] : ((JToken)"")) ?? ((JToken)""));
							if (Operators.CompareString(text22, "", false) != 0)
							{
								string[] array5 = text22.Split(";", (StringSplitOptions)0);
								for (int j = 0; j < array5.Length; j++)
								{
									string text23 = array5[j];
									if (Operators.CompareString(text23, "", false) != 0 && ModBase.StartsWithF(text23, "required-"))
									{
										text23 = text23.Substring(ModBase.IndexOfF(text23, ":") + 1);
										if (text23.Contains("@"))
										{
											AddDependency(text23.Split("@", (StringSplitOptions)0)[0], text23.Split("@", (StringSplitOptions)0)[1]);
										}
										else
										{
											AddDependency(text23);
										}
									}
								}
							}
						}
					}
					end_IL_0ecf:;
				}
				catch (System.Exception ex9)
				{
					ProjectData.SetProjectError(ex9);
					System.Exception ex10 = ex9;
					ModBase.Log(ex10, "读取 fml_cache_annotation.json 时出现未知错误（" + Path + "）");
					ProjectData.ClearProjectError();
				}
				try
				{
					ZipArchiveEntry entry9 = Jar.GetEntry("pack.png");
					if (entry9 != null)
					{
						try
						{
							Logo = ModBase.PathTemp + "MyImage\\" + ModBase.GetStringMD5(entry9.Length.ToString() + entry9.CompressedLength + Path) + ".png";
							Stream val13 = entry9.Open();
							try
							{
								FileStream val14 = File.Create(Logo);
								try
								{
									val13.CopyTo((Stream)(object)val14);
								}
								finally
								{
									((System.IDisposable)val14)?.Dispose();
								}
							}
							finally
							{
								((System.IDisposable)val13)?.Dispose();
							}
							ModBase.Log("成功提取资源包图标：" + Path, ModBase.LogLevel.Debug);
						}
						catch (System.Exception ex11)
						{
							ProjectData.SetProjectError(ex11);
							System.Exception ex12 = ex11;
							ModBase.Log(ex12, "提取 pack.png 图标失败（" + Path + "）", ModBase.LogLevel.Developer);
							ProjectData.ClearProjectError();
						}
					}
				}
				catch (System.Exception ex13)
				{
					ProjectData.SetProjectError(ex13);
					System.Exception ex14 = ex13;
					ModBase.Log(ex14, "识别资源包图标时出现未知错误（" + Path + "）", ModBase.LogLevel.Developer);
					ProjectData.ClearProjectError();
				}
				goto IL_1428;
			}
			IL_1428:
			if (Operators.CompareString(_Version, "version", false) == 0)
			{
				try
				{
					ZipArchiveEntry entry10 = Jar.GetEntry("META-INF/MANIFEST.MF");
					if (entry10 != null)
					{
						string text24 = ModBase.ReadFile(entry10.Open()).Replace(" :", ":").Replace(": ", ":");
						if (text24.Contains("Implementation-Version:"))
						{
							text24 = text24.Substring(checked(ModBase.IndexOfF(text24, "Implementation-Version:") + Enumerable.Count<char>((System.Collections.Generic.IEnumerable<char>)"Implementation-Version:")));
							text24 = text24.Substring(0, text24.IndexOfAny("\r\n".ToCharArray())).Trim();
							Version = text24;
						}
					}
				}
				catch (System.Exception ex15)
				{
					ProjectData.SetProjectError(ex15);
					System.Exception ex16 = ex15;
					ModBase.Log("获取 META-INF 中的版本信息失败（" + Path + "）", ModBase.LogLevel.Developer);
					Version = null;
					ProjectData.ClearProjectError();
				}
			}
			if (_Version != null && !_Version.Contains(".") && !_Version.Contains("-"))
			{
				Version = null;
			}
		}

		public JObject ToJson()
		{
			JObject jObject = new JObject();
			if ((object)Comp != null)
			{
				jObject.Add("Comp", Comp.ToJson());
			}
			jObject.Add("ChangelogUrls", new JArray(ChangelogUrls));
			jObject.Add("CompLoaded", CompLoaded);
			if (CompFile != null)
			{
				jObject.Add("CompFile", CompFile.ToJson());
			}
			if (UpdateFile != null)
			{
				jObject.Add("UpdateFile", UpdateFile.ToJson());
			}
			return jObject;
		}

		public void FromJson(JObject Json)
		{
			CompLoaded = (bool)Json["CompLoaded"];
			if (Json.ContainsKey("Comp"))
			{
				Comp = new ModComp.CompProject((JObject)Json["Comp"]);
			}
			if (Json.ContainsKey("ChangelogUrls"))
			{
				ChangelogUrls = Json["ChangelogUrls"].ToObject<List<string>>();
			}
			if (Json.ContainsKey("CompFile"))
			{
				CompFile = new ModComp.CompFile((JObject)Json["CompFile"], ModComp.CompType.Mod);
			}
			if (Json.ContainsKey("UpdateFile"))
			{
				UpdateFile = new ModComp.CompFile((JObject)Json["UpdateFile"], ModComp.CompType.Mod);
			}
		}

		public virtual string ToString()
		{
			return $"{State} - {Path}";
		}

		public virtual bool Equals(object obj)
		{
			if (obj is LocalCompFile localCompFile)
			{
				return Operators.CompareString(Path, localCompFile.Path, false) == 0;
			}
			return false;
		}

		public bool IsPresetMod()
		{
			if (!Enumerable.Any<KeyValuePair<string, string>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, string>>)Dependencies) && Name != null)
			{
				if (!Name.ToLower().Contains("core"))
				{
					return Name.ToLower().Contains("lib");
				}
				return true;
			}
			return false;
		}

		public static object IsModFile(string Path)
		{
			if (Path == null || !Path.Contains("."))
			{
				return false;
			}
			Path = Path.ToLower();
			if (ModBase.EndsWithF(Path, ".jar", IgnoreCase: true) || ModBase.EndsWithF(Path, ".zip", IgnoreCase: true) || ModBase.EndsWithF(Path, ".litemod", IgnoreCase: true) || ModBase.EndsWithF(Path, ".jar.disabled", IgnoreCase: true) || ModBase.EndsWithF(Path, ".zip.disabled", IgnoreCase: true) || ModBase.EndsWithF(Path, ".litemod.disabled", IgnoreCase: true) || ModBase.EndsWithF(Path, ".jar.old", IgnoreCase: true) || ModBase.EndsWithF(Path, ".zip.old", IgnoreCase: true) || ModBase.EndsWithF(Path, ".litemod.old", IgnoreCase: true))
			{
				return true;
			}
			return false;
		}

		public static object IsCompFile(string Path, ModComp.CompType CompType)
		{
			if (Path == null || !Path.Contains("."))
			{
				return false;
			}
			Path = Path.ToLower();
			switch (CompType)
			{
			case ModComp.CompType.Mod:
				return IsModFile(Path);
			case ModComp.CompType.ResourcePack:
			case ModComp.CompType.Shader:
				return ModBase.EndsWithF(Path, ".zip", IgnoreCase: true);
			case ModComp.CompType.Schematic:
				return ModBase.EndsWithF(Path, ".litematic", IgnoreCase: true) || ModBase.EndsWithF(Path, ".nbt", IgnoreCase: true) || ModBase.EndsWithF(Path, ".schematic", IgnoreCase: true) || ModBase.EndsWithF(Path, ".schem", IgnoreCase: true);
			default:
				return false;
			}
		}

		public string GetLogo()
		{
			if ((object)Comp != null && Comp.LogoUrl != null)
			{
				return Comp.LogoUrl;
			}
			if (Logo != null)
			{
				return Logo;
			}
			if (IsFolder)
			{
				return "pack://application:,,,/images/Icons/Folder.png";
			}
			return ModBase.PathImage + "Icons/NoIcon.png";
		}

		private void LoadLitematicNbtData()
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			try
			{
				ModBase.Log($"开始读取 Litematic NBT 数据：{Path}", ModBase.LogLevel.Debug);
				FileStream val = new FileStream(Path, (FileMode)3, (FileAccess)1, (FileShare)1);
				try
				{
					NbtFile val2 = new NbtFile();
					val2.LoadFromStream((Stream)(object)val, (NbtCompression)0);
					NbtInt val3 = (NbtInt)val2.RootTag.Get("Version");
					if (val3 != null)
					{
						_litematicVersion = val3.Value;
					}
					NbtCompound val4 = val2.RootTag.Get<NbtCompound>("Metadata");
					if (val4 != null)
					{
						ModBase.Log("找到 Litematic Metadata 节点", ModBase.LogLevel.Debug);
						NbtString val5 = val4.Get<NbtString>("Name");
						if (val5 != null && !string.IsNullOrWhiteSpace(val5.Value) && Operators.CompareString(val5.Value, "Unnamed", false) != 0)
						{
							_litematicOriginalName = val5.Value;
						}
						NbtString val6 = val4.Get<NbtString>("Description");
						if (val6 != null && !string.IsNullOrWhiteSpace(val6.Value))
						{
							_Description = val6.Value;
						}
						NbtString val7 = val4.Get<NbtString>("Author");
						if (val7 != null && !string.IsNullOrWhiteSpace(val7.Value))
						{
							_Authors = val7.Value;
						}
						NbtLong val8 = val4.Get<NbtLong>("TimeCreated");
						if (val8 != null)
						{
							_litematicTimeCreated = val8.Value;
						}
						NbtLong val9 = val4.Get<NbtLong>("TimeModified");
						if (val9 != null)
						{
							_litematicTimeModified = val9.Value;
						}
						NbtCompound val10 = val4.Get<NbtCompound>("EnclosingSize");
						if (val10 != null)
						{
							NbtInt val11 = val10.Get<NbtInt>("x");
							NbtInt val12 = val10.Get<NbtInt>("y");
							NbtInt val13 = val10.Get<NbtInt>("z");
							if (val11 != null && val12 != null && val13 != null)
							{
								_litematicEnclosingSize = $"{val11.Value} × {val12.Value} × {val13.Value}";
							}
						}
						NbtInt val14 = val4.Get<NbtInt>("RegionCount");
						if (val14 != null)
						{
							_litematicRegionCount = val14.Value;
						}
						NbtInt val15 = val4.Get<NbtInt>("TotalBlocks");
						if (val15 != null)
						{
							_litematicTotalBlocks = val15.Value;
						}
						NbtInt val16 = val4.Get<NbtInt>("TotalVolume");
						if (val16 != null)
						{
							_litematicTotalVolume = val16.Value;
						}
					}
					else
					{
						ModBase.Log("未找到 Litematic Metadata 节点", ModBase.LogLevel.Debug);
					}
				}
				finally
				{
					((System.IDisposable)val)?.Dispose();
				}
				ModBase.Log("Litematic NBT 数据读取完成", ModBase.LogLevel.Debug);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "读取 Litematic NBT 数据时出错（" + Path + "）");
				ProjectData.ClearProjectError();
			}
		}

		private void LoadSchemNbtData()
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				ModBase.Log($"开始读取 Schem NBT 数据：{Path}", ModBase.LogLevel.Debug);
				FileStream val = new FileStream(Path, (FileMode)3, (FileAccess)1, (FileShare)1);
				try
				{
					NbtFile val2 = new NbtFile();
					val2.LoadFromStream((Stream)(object)val, (NbtCompression)0);
					NbtInt val3 = val2.RootTag.Get<NbtInt>("Version");
					if (val3 != null)
					{
						_spongeVersion = val3.Value;
					}
					NbtInt val4 = val2.RootTag.Get<NbtInt>("DataVersion");
					if (val4 != null)
					{
						_structureDataVersion = val4.Value;
					}
					NbtShort val5 = val2.RootTag.Get<NbtShort>("Width");
					NbtShort val6 = val2.RootTag.Get<NbtShort>("Height");
					NbtShort val7 = val2.RootTag.Get<NbtShort>("Length");
					if (val5 != null && val6 != null && val7 != null)
					{
						_litematicEnclosingSize = $"{val5.Value} × {val6.Value} × {val7.Value}";
						_litematicTotalVolume = (int)checked((short)unchecked(checked((short)unchecked(val5.Value * val6.Value)) * val7.Value));
						_litematicTotalBlocks = _litematicTotalVolume;
					}
					if (val2.RootTag.Get<NbtCompound>("Palette") != null)
					{
						_litematicRegionCount = 1;
					}
					NbtCompound val8 = val2.RootTag.Get<NbtCompound>("Metadata");
					if (val8 != null)
					{
						NbtString val9 = val8.Get<NbtString>("Name");
						if (val9 != null && !string.IsNullOrWhiteSpace(val9.Value))
						{
							_schemOriginalName = val9.Value;
						}
						NbtString val10 = val8.Get<NbtString>("Author");
						if (val10 != null && !string.IsNullOrWhiteSpace(val10.Value))
						{
							_structureAuthor = val10.Value;
							if (_Authors == null)
							{
								_Authors = _structureAuthor;
							}
						}
					}
				}
				finally
				{
					((System.IDisposable)val)?.Dispose();
				}
				ModBase.Log("Schem NBT 数据读取完成", ModBase.LogLevel.Debug);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "读取 Schem NBT 数据时出错（" + Path + "）");
				ProjectData.ClearProjectError();
			}
		}

		private void LoadSchematicNbtData()
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				ModBase.Log($"开始读取 Schematic NBT 数据：{Path}", ModBase.LogLevel.Debug);
				FileStream val = new FileStream(Path, (FileMode)3, (FileAccess)1, (FileShare)1);
				try
				{
					NbtFile val2 = new NbtFile();
					val2.LoadFromStream((Stream)(object)val, (NbtCompression)0);
					NbtShort val3 = val2.RootTag.Get<NbtShort>("Width");
					NbtShort val4 = val2.RootTag.Get<NbtShort>("Height");
					NbtShort val5 = val2.RootTag.Get<NbtShort>("Length");
					if (val3 != null && val4 != null && val5 != null)
					{
						_litematicEnclosingSize = $"{val3.Value} × {val4.Value} × {val5.Value}";
						_litematicTotalVolume = (int)checked((short)unchecked(checked((short)unchecked(val3.Value * val4.Value)) * val5.Value));
					}
					NbtString val6 = val2.RootTag.Get<NbtString>("Materials");
					if (val6 != null)
					{
						ModBase.Log($"Schematic 材料类型：{val6.Value}", ModBase.LogLevel.Debug);
					}
					ModBase.Log("Schematic NBT 数据读取完成", ModBase.LogLevel.Debug);
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
				ModBase.Log(ex2, "读取 Schematic NBT 数据时出错（" + Path + "）");
				ProjectData.ClearProjectError();
			}
		}

		private void LoadStructureNbtData()
		{
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				ModBase.Log($"开始读取 NBT 结构文件数据：{Path}", ModBase.LogLevel.Debug);
				FileStream val = new FileStream(Path, (FileMode)3, (FileAccess)1, (FileShare)1);
				try
				{
					NbtFile val2 = new NbtFile();
					val2.LoadFromStream((Stream)(object)val, (NbtCompression)0);
					NbtString val3 = val2.RootTag.Get<NbtString>("author");
					if (val3 != null && !string.IsNullOrWhiteSpace(val3.Value))
					{
						_structureAuthor = val3.Value;
						if (_Authors == null)
						{
							_Authors = _structureAuthor;
						}
					}
					NbtList val4 = val2.RootTag.Get<NbtList>("size");
					if (val4 != null)
					{
						NbtTag[] array = val4.ToArray();
						if (array.Length >= 3)
						{
							int[] array2 = Enumerable.ToArray<int>(Enumerable.Select<NbtTag, int>(Enumerable.Take<NbtTag>((System.Collections.Generic.IEnumerable<NbtTag>)array, 3), (Func<NbtTag, int>)([SpecialName] (NbtTag e) => e.IntValue)));
							_litematicEnclosingSize = $"{array2[0]} × {array2[1]} × {array2[2]}";
							_litematicTotalVolume = checked(array2[0] * array2[1] * array2[2]);
						}
					}
					NbtList val5 = val2.RootTag.Get<NbtList>("blocks");
					if (val5 != null)
					{
						_litematicTotalBlocks = Enumerable.Count<NbtTag>(Enumerable.Where<NbtTag>((System.Collections.Generic.IEnumerable<NbtTag>)val5, (Func<NbtTag, bool>)([SpecialName] (NbtTag x) => (int)x.TagType == 10)));
					}
					if (val2.RootTag.Get<NbtList>("palette") != null)
					{
						_litematicRegionCount = 1;
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
				ModBase.Log(ex2, "读取 NBT 结构文件数据时出错（" + Path + "）");
				ProjectData.ClearProjectError();
			}
		}
	}

	public class CompLocalLoaderData
	{
		public ModMinecraft.McInstance GameVersion;

		public List<ModComp.CompLoaderType> Loaders;

		public PageInstanceCompResource Frm;

		public string CompPath;

		public ModComp.CompType CompType;

		public KeyValuePair<List<LocalCompFile>, JObject> DetailInfo;
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<LocalCompFile, bool> _0024I6_002D4;

		public static Func<LocalCompFile, bool> _0024I6_002D5;

		public static ModBase.ComparisonBoolean<LocalCompFile> _0024I6_002D6;

		public static Func<LocalCompFile, string> _0024I8_002D1;

		public static Func<LocalCompFile, string> _0024I8_002D3;

		public static Func<KeyValuePair<string, List<LocalCompFile>>, System.Collections.Generic.IEnumerable<string>> _0024I8_002D2;

		public static Func<LocalCompFile, bool> _0024I8_002D5;

		public static Action _0024I8_002D6;

		public static Action _0024I8_002D7;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal bool _Lambda_0024__6_002D4(LocalCompFile m)
		{
			return (object)m.Comp == null;
		}

		[SpecialName]
		internal bool _Lambda_0024__6_002D5(LocalCompFile m)
		{
			return (object)m.Comp != null;
		}

		[SpecialName]
		internal bool _Lambda_0024__6_002D6(LocalCompFile Left, LocalCompFile Right)
		{
			if (Left.State == LocalCompFile.LocalFileStatus.Unavailable != (Right.State == LocalCompFile.LocalFileStatus.Unavailable))
			{
				return Left.State == LocalCompFile.LocalFileStatus.Unavailable;
			}
			return ~Right.FileName.CompareTo(Left.FileName) != 0;
		}

		[SpecialName]
		internal string _Lambda_0024__8_002D1(LocalCompFile m)
		{
			return m.ModrinthHash;
		}

		[SpecialName]
		internal System.Collections.Generic.IEnumerable<string> _Lambda_0024__8_002D2(KeyValuePair<string, List<LocalCompFile>> l)
		{
			return Enumerable.Select<LocalCompFile, string>((System.Collections.Generic.IEnumerable<LocalCompFile>)l.Value, (Func<LocalCompFile, string>)([SpecialName] (LocalCompFile m) => m.ModrinthHash));
		}

		[SpecialName]
		internal string _Lambda_0024__8_002D3(LocalCompFile m)
		{
			return m.ModrinthHash;
		}

		[SpecialName]
		internal bool _Lambda_0024__8_002D5(LocalCompFile m)
		{
			return (object)m.Comp != null;
		}

		[SpecialName]
		internal void _Lambda_0024__8_002D6()
		{
			ModMain.FrmInstanceMod?.RefreshUI();
		}

		[SpecialName]
		internal void _Lambda_0024__8_002D7()
		{
			ModMain.FrmInstanceMod?.RefreshBars();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__13_002D0
	{
		public string _0024VB_0024Local_lowerFilePath;

		public LocalCompFile _0024VB_0024Local_localComp;

		public _Closure_0024__13_002D0(_Closure_0024__13_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_lowerFilePath = arg0._0024VB_0024Local_lowerFilePath;
				_0024VB_0024Local_localComp = arg0._0024VB_0024Local_localComp;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(string keyword)
		{
			return _0024VB_0024Local_lowerFilePath.Contains(keyword);
		}

		[SpecialName]
		internal bool _Lambda_0024__1(string modId)
		{
			return Operators.CompareString(_0024VB_0024Local_localComp.ModId, modId, false) == 0;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D0
	{
		public ModLoader.LoaderTask<CompLocalLoaderData, List<LocalCompFile>> _0024VB_0024Local_Loader;

		public _Closure_0024__6_002D0(_Closure_0024__6_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			if (_0024VB_0024Local_Loader.Input.Frm != null)
			{
				_0024VB_0024Local_Loader.Input.Frm.Load.ShowProgress = false;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			if (_0024VB_0024Local_Loader.Input.Frm != null)
			{
				_0024VB_0024Local_Loader.Input.Frm.Load.Text = "正在更新资源";
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			if (_0024VB_0024Local_Loader.Input.Frm != null)
			{
				_0024VB_0024Local_Loader.Input.Frm.Load.Text = "正在加载资源列表";
			}
		}

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			if (_0024VB_0024Local_Loader.Input.Frm != null)
			{
				_0024VB_0024Local_Loader.Input.Frm.Load.ShowProgress = true;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__8_002D0
	{
		public List<LocalCompFile> _0024VB_0024Local_Mods;

		public ModLoader.LoaderTask<CompLocalLoaderData, int> _0024VB_0024Local_Loader;

		public Thread _0024VB_0024Local_CurrentThread;

		public List<ModComp.CompLoaderType> _0024VB_0024Local_ModLoaders;

		public string _0024VB_0024Local_McInstance;

		public bool _0024VB_0024Local_IsFailed;

		public int _0024VB_0024Local_EndedThreadCount;

		public _Closure_0024__8_002D0(_Closure_0024__8_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Mods = arg0._0024VB_0024Local_Mods;
				_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
				_0024VB_0024Local_CurrentThread = arg0._0024VB_0024Local_CurrentThread;
				_0024VB_0024Local_ModLoaders = arg0._0024VB_0024Local_ModLoaders;
				_0024VB_0024Local_McInstance = arg0._0024VB_0024Local_McInstance;
				_0024VB_0024Local_IsFailed = arg0._0024VB_0024Local_IsFailed;
				_0024VB_0024Local_EndedThreadCount = arg0._0024VB_0024Local_EndedThreadCount;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_036b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			checked
			{
				try
				{
					List<string> list = Enumerable.ToList<string>(Enumerable.Select<LocalCompFile, string>((System.Collections.Generic.IEnumerable<LocalCompFile>)_0024VB_0024Local_Mods, (Func<LocalCompFile, string>)([SpecialName] (LocalCompFile m) => m.ModrinthHash)));
					JObject jObject = (JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files", "POST", string.Format("{{\"hashes\": [\"{0}\"], \"algorithm\": \"sha1\"}}", (object)ModBase.Join((System.Collections.IEnumerable)list, "\",\"")), "application/json"));
					ModBase.Log($"[Mod] 从 Modrinth 获取到 {jObject.Count} 个本地 Mod 的对应信息");
					if (jObject.Count == 0)
					{
						return;
					}
					Dictionary<string, List<LocalCompFile>> val = new Dictionary<string, List<LocalCompFile>>();
					System.Collections.Generic.IEnumerator<LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
					try
					{
						enumerator = _0024VB_0024Local_Mods.GetEnumerator();
						while (enumerator.MoveNext())
						{
							LocalCompFile current = enumerator.Current;
							if (jObject.ContainsKey(current.ModrinthHash) && !((string?)jObject[current.ModrinthHash]["files"][0]["hashes"]["sha1"] != current.ModrinthHash))
							{
								string text = jObject[current.ModrinthHash]["project_id"].ToString();
								if (ModComp.CompProjectCache.ContainsKey(text) && (object)current.Comp == null)
								{
									current.Comp = ModComp.CompProjectCache[text];
								}
								if (!val.ContainsKey(text))
								{
									val[text] = new List<LocalCompFile>();
								}
								val[text].Add(current);
								ModComp.CompFile compFile = new ModComp.CompFile((JObject)jObject[current.ModrinthHash], ModComp.CompType.Mod);
								if (current.CompFile == null || System.DateTime.Compare(current.CompFile.ReleaseDate, compFile.ReleaseDate) < 0)
								{
									current.CompFile = compFile;
								}
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator).Dispose();
					}
					if (_0024VB_0024Local_Loader.IsAbortedWithThread(_0024VB_0024Local_CurrentThread))
					{
						return;
					}
					ModBase.Log($"[Mod] 需要从 Modrinth 获取 {val.Count} 个本地 Mod 的工程信息");
					if (!Enumerable.Any<KeyValuePair<string, List<LocalCompFile>>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, List<LocalCompFile>>>)val))
					{
						return;
					}
					JArray jArray = (JArray)ModBase.GetJson(ModDownload.DlModRequest(string.Format("https://api.modrinth.com/v2/projects?ids=[\"{0}\"]", (object)ModBase.Join((System.Collections.IEnumerable)val.Keys, "\",\"")), "GET", "", "application/json"));
					System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
					try
					{
						enumerator2 = jArray.GetEnumerator();
						System.Collections.Generic.IEnumerator<LocalCompFile> enumerator3 = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
						while (((System.Collections.IEnumerator)enumerator2).MoveNext())
						{
							JToken current2 = enumerator2.Current;
							ModComp.CompProject compProject = new ModComp.CompProject((JObject)current2);
							try
							{
								enumerator3 = val[compProject.Id].GetEnumerator();
								while (enumerator3.MoveNext())
								{
									enumerator3.Current.Comp = compProject;
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
						((System.IDisposable)enumerator2)?.Dispose();
					}
					ModBase.Log("[Mod] 已从 Modrinth 获取本地 Mod 信息，继续获取更新信息");
					JObject jObject2 = (JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files/update", "POST", string.Format("{{\"hashes\": [\"{0}\"], \"algorithm\": \"sha1\", \n                    \"loaders\": [\"{1}\"],\"game_versions\": [\"{2}\"]}}", (object)ModBase.Join((System.Collections.IEnumerable)Enumerable.SelectMany<KeyValuePair<string, List<LocalCompFile>>, string>((System.Collections.Generic.IEnumerable<KeyValuePair<string, List<LocalCompFile>>>)val, (Func<KeyValuePair<string, List<LocalCompFile>>, System.Collections.Generic.IEnumerable<string>>)([SpecialName] (KeyValuePair<string, List<LocalCompFile>> l) => Enumerable.Select<LocalCompFile, string>((System.Collections.Generic.IEnumerable<LocalCompFile>)l.Value, (Func<LocalCompFile, string>)([SpecialName] (LocalCompFile m) => m.ModrinthHash)))), "\",\""), (object)ModBase.Join((System.Collections.IEnumerable)_0024VB_0024Local_ModLoaders, "\",\"").ToLower(), (object)_0024VB_0024Local_McInstance), "application/json"));
					System.Collections.Generic.IEnumerator<LocalCompFile> enumerator4 = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
					try
					{
						enumerator4 = _0024VB_0024Local_Mods.GetEnumerator();
						while (enumerator4.MoveNext())
						{
							LocalCompFile current3 = enumerator4.Current;
							if (!jObject2.ContainsKey(current3.ModrinthHash) || current3.CompFile == null)
							{
								continue;
							}
							ModComp.CompFile compFile2 = new ModComp.CompFile((JObject)jObject2[current3.ModrinthHash], ModComp.CompType.Mod);
							if (!compFile2.Available)
							{
								continue;
							}
							if (ModBase.ModeDebug)
							{
								ModBase.Log($"[Mod] 本地文件 {current3.CompFile.FileName} 在 Modrinth 上的最新版为 {compFile2.FileName}");
							}
							if (System.DateTime.Compare(current3.CompFile.ReleaseDate, compFile2.ReleaseDate) < 0 && Operators.CompareString(current3.CompFile.Hash, compFile2.Hash, false) != 0)
							{
								if (current3.UpdateFile != null && Operators.CompareString(compFile2.Hash, current3.UpdateFile.Hash, false) == 0)
								{
									current3.ChangelogUrls.Add(string.Format("https://modrinth.com/mod/{0}/changelog?g={1}", (object)jObject2[current3.ModrinthHash]["project_id"], (object)_0024VB_0024Local_McInstance));
									compFile2.DownloadUrls.AddRange((System.Collections.Generic.IEnumerable<string>)current3.UpdateFile.DownloadUrls);
									current3.UpdateFile = compFile2;
								}
								else if (current3.UpdateFile == null || System.DateTime.Compare(compFile2.ReleaseDate, current3.UpdateFile.ReleaseDate) >= 0)
								{
									List<string> obj = new List<string>();
									obj.Add(string.Format("https://modrinth.com/mod/{0}/changelog?g={1}", (object)jObject2[current3.ModrinthHash]["project_id"], (object)_0024VB_0024Local_McInstance));
									current3.ChangelogUrls = obj;
									current3.UpdateFile = compFile2;
								}
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator4).Dispose();
					}
					ModBase.Log("[Mod] 从 Modrinth 获取本地 Mod 信息结束");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "从 Modrinth 获取本地 Mod 信息失败");
					_0024VB_0024Local_IsFailed = true;
					ProjectData.ClearProjectError();
				}
				finally
				{
					_0024VB_0024Local_EndedThreadCount++;
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__4()
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0318: Unknown result type (might be due to invalid IL or missing references)
			//IL_031d: Unknown result type (might be due to invalid IL or missing references)
			//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_05af: Unknown result type (might be due to invalid IL or missing references)
			//IL_0625: Unknown result type (might be due to invalid IL or missing references)
			//IL_062a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0633: Unknown result type (might be due to invalid IL or missing references)
			//IL_0638: Unknown result type (might be due to invalid IL or missing references)
			//IL_045d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0462: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				List<uint> val = new List<uint>();
				System.Collections.Generic.IEnumerator<LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
				try
				{
					enumerator = _0024VB_0024Local_Mods.GetEnumerator();
					while (enumerator.MoveNext())
					{
						LocalCompFile current = enumerator.Current;
						val.Add(current.CurseForgeHash);
						if (_0024VB_0024Local_Loader.IsAbortedWithThread(_0024VB_0024Local_CurrentThread))
						{
							return;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				JContainer jContainer = (JContainer)((JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/fingerprints/432", "POST", string.Format("{{\"fingerprints\": [{0}]}}", (object)ModBase.Join((System.Collections.IEnumerable)val, ",")), "application/json")))["data"]["exactMatches"];
				ModBase.Log($"[Mod] 从 CurseForge 获取到 {jContainer.Count} 个本地 Mod 的对应信息");
				if (!Enumerable.Any<JToken>((System.Collections.Generic.IEnumerable<JToken>)jContainer))
				{
					return;
				}
				Dictionary<int, List<LocalCompFile>> val2 = new Dictionary<int, List<LocalCompFile>>();
				System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)jContainer).GetEnumerator();
					System.Collections.Generic.IEnumerator<LocalCompFile> enumerator3 = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
					while (((System.Collections.IEnumerator)enumerator2).MoveNext())
					{
						JToken current2 = enumerator2.Current;
						string text = current2["id"].ToString();
						uint num = (uint)current2["file"]["fileFingerprint"];
						try
						{
							enumerator3 = _0024VB_0024Local_Mods.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								LocalCompFile current3 = enumerator3.Current;
								if (current3.CurseForgeHash == num)
								{
									if (ModComp.CompProjectCache.ContainsKey(text) && (object)current3.Comp == null)
									{
										current3.Comp = ModComp.CompProjectCache[text];
									}
									if (!val2.ContainsKey(Conversions.ToInteger(text)))
									{
										val2[Conversions.ToInteger(text)] = new List<LocalCompFile>();
									}
									val2[Conversions.ToInteger(text)].Add(current3);
									ModComp.CompFile compFile = new ModComp.CompFile((JObject)current2["file"], ModComp.CompType.Mod);
									if (current3.CompFile == null || System.DateTime.Compare(current3.CompFile.ReleaseDate, compFile.ReleaseDate) < 0)
									{
										current3.CompFile = compFile;
									}
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
					((System.IDisposable)enumerator2)?.Dispose();
				}
				if (_0024VB_0024Local_Loader.IsAbortedWithThread(_0024VB_0024Local_CurrentThread))
				{
					return;
				}
				ModBase.Log($"[Mod] 需要从 CurseForge 获取 {val2.Count} 个本地 Mod 的工程信息");
				if (!Enumerable.Any<KeyValuePair<int, List<LocalCompFile>>>((System.Collections.Generic.IEnumerable<KeyValuePair<int, List<LocalCompFile>>>)val2))
				{
					return;
				}
				JToken jToken = ((JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/mods", "POST", string.Format("{{\"modIds\": [{0}]}}", (object)ModBase.Join((System.Collections.IEnumerable)val2.Keys, ",")), "application/json")))["data"];
				Dictionary<int, List<LocalCompFile>> val3 = new Dictionary<int, List<LocalCompFile>>();
				Dictionary<int, string> val4 = new Dictionary<int, string>();
				System.Collections.Generic.IEnumerator<JToken> enumerator4 = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator4 = ((System.Collections.Generic.IEnumerable<JToken>)jToken).GetEnumerator();
					System.Collections.Generic.IEnumerator<LocalCompFile> enumerator5 = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
					System.Collections.Generic.IEnumerator<JToken> enumerator6 = default(System.Collections.Generic.IEnumerator<JToken>);
					System.Collections.Generic.IEnumerator<int> enumerator7 = default(System.Collections.Generic.IEnumerator<int>);
					while (((System.Collections.IEnumerator)enumerator4).MoveNext())
					{
						JToken current4 = enumerator4.Current;
						if (current4["isAvailable"] != null && !current4["isAvailable"].ToObject<bool>())
						{
							continue;
						}
						ModComp.CompProject compProject = new ModComp.CompProject((JObject)current4);
						try
						{
							enumerator5 = val2[Conversions.ToInteger(compProject.Id)].GetEnumerator();
							while (enumerator5.MoveNext())
							{
								LocalCompFile current5 = enumerator5.Current;
								if ((object)current5.Comp != null && !current5.Comp.FromCurseForge)
								{
									current5.Comp = current5.Comp;
								}
								else
								{
									current5.Comp = compProject;
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator5).Dispose();
						}
						if (_0024VB_0024Local_ModLoaders.Count != 1)
						{
							continue;
						}
						string text2 = null;
						List<int> val5 = new List<int>();
						try
						{
							enumerator6 = ((System.Collections.Generic.IEnumerable<JToken>)current4["latestFilesIndexes"]).GetEnumerator();
							while (((System.Collections.IEnumerator)enumerator6).MoveNext())
							{
								JToken current6 = enumerator6.Current;
								if (current6["modLoader"] == null || Enumerable.Single<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)_0024VB_0024Local_ModLoaders) != (ModComp.CompLoaderType)current6["modLoader"].ToObject<int>())
								{
									continue;
								}
								string text3 = (string?)current6["gameVersion"];
								if (Operators.CompareString(text3, _0024VB_0024Local_McInstance, false) == 0 && (text2 == null || ModMinecraft.VersionSortInteger(text2, text3) <= -1))
								{
									if (Operators.CompareString(text2, text3, false) != 0)
									{
										text2 = text3;
										val5.Clear();
									}
									val5.Add(current6["fileId"].ToObject<int>());
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator6)?.Dispose();
						}
						try
						{
							enumerator7 = val5.GetEnumerator();
							while (enumerator7.MoveNext())
							{
								int current7 = enumerator7.Current;
								if (!val3.ContainsKey(current7))
								{
									val3[current7] = new List<LocalCompFile>();
								}
								val3[current7].AddRange((System.Collections.Generic.IEnumerable<LocalCompFile>)val2[Conversions.ToInteger(compProject.Id)]);
								val4[current7] = compProject.Slug;
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
					((System.IDisposable)enumerator4)?.Dispose();
				}
				ModBase.Log($"[Mod] 已从 CurseForge 获取本地 Mod 信息，需要获取 {val3.Count} 个用于检查更新的文件信息");
				if (!Enumerable.Any<KeyValuePair<int, List<LocalCompFile>>>((System.Collections.Generic.IEnumerable<KeyValuePair<int, List<LocalCompFile>>>)val3))
				{
					return;
				}
				JToken jToken2 = ((JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/mods/files", "POST", string.Format("{{\"fileIds\": [{0}]}}", (object)ModBase.Join((System.Collections.IEnumerable)val3.Keys, ",")), "application/json")))["data"];
				Dictionary<LocalCompFile, ModComp.CompFile> val6 = new Dictionary<LocalCompFile, ModComp.CompFile>();
				System.Collections.Generic.IEnumerator<JToken> enumerator8 = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator8 = ((System.Collections.Generic.IEnumerable<JToken>)jToken2).GetEnumerator();
					System.Collections.Generic.IEnumerator<LocalCompFile> enumerator9 = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
					while (((System.Collections.IEnumerator)enumerator8).MoveNext())
					{
						JToken current8 = enumerator8.Current;
						ModComp.CompFile compFile2 = new ModComp.CompFile((JObject)current8, ModComp.CompType.Mod);
						if (!compFile2.Available)
						{
							continue;
						}
						try
						{
							enumerator9 = val3[Conversions.ToInteger(compFile2.Id)].GetEnumerator();
							while (enumerator9.MoveNext())
							{
								LocalCompFile current9 = enumerator9.Current;
								if (!val6.ContainsKey(current9) || System.DateTime.Compare(val6[current9].ReleaseDate, compFile2.ReleaseDate) < 0)
								{
									val6[current9] = compFile2;
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator9).Dispose();
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator8)?.Dispose();
				}
				System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<LocalCompFile, ModComp.CompFile>> enumerator10 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<LocalCompFile, ModComp.CompFile>>);
				try
				{
					enumerator10 = val6.GetEnumerator();
					while (enumerator10.MoveNext())
					{
						KeyValuePair<LocalCompFile, ModComp.CompFile> current10 = enumerator10.Current;
						LocalCompFile key = current10.Key;
						ModComp.CompFile value = current10.Value;
						if (ModBase.ModeDebug)
						{
							ModBase.Log($"[Mod] 本地文件 {key.CompFile.FileName} 在 CurseForge 上的最新版为 {value.FileName}");
						}
						if (System.DateTime.Compare(key.CompFile.ReleaseDate, value.ReleaseDate) < 0 && Operators.CompareString(key.CompFile.Hash, value.Hash, false) != 0)
						{
							if (key.UpdateFile != null && Operators.CompareString(value.Hash, key.UpdateFile.Hash, false) == 0)
							{
								key.ChangelogUrls.Add($"https://www.curseforge.com/minecraft/mc-mods/{val4[Conversions.ToInteger(value.Id)]}/files/{value.Id}");
								key.UpdateFile.DownloadUrls.AddRange((System.Collections.Generic.IEnumerable<string>)value.DownloadUrls);
							}
							else if (key.UpdateFile == null || System.DateTime.Compare(value.ReleaseDate, key.UpdateFile.ReleaseDate) > 0)
							{
								List<string> obj = new List<string>();
								obj.Add($"https://www.curseforge.com/minecraft/mc-mods/{val4[Conversions.ToInteger(value.Id)]}/files/{value.Id}");
								key.ChangelogUrls = obj;
								key.UpdateFile = value;
							}
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator10).Dispose();
				}
				ModBase.Log("[Mod] 从 CurseForge 获取 Mod 更新信息结束");
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "从 CurseForge 获取本地 Mod 信息失败");
				_0024VB_0024Local_IsFailed = true;
				ProjectData.ClearProjectError();
			}
			finally
			{
				checked
				{
					_0024VB_0024Local_EndedThreadCount++;
				}
			}
		}
	}

	private const int LocalModCacheVersion = 7;

	public static ModLoader.LoaderTask<CompLocalLoaderData, List<LocalCompFile>> CompResourceListLoader = new ModLoader.LoaderTask<CompLocalLoaderData, List<LocalCompFile>>("Comp Resource List Loader", CompResourceListLoad, null, (ThreadPriority)2);

	public static ModLoader.LoaderTask<CompLocalLoaderData, int> CompUpdateDetailLoader = new ModLoader.LoaderTask<CompLocalLoaderData, int>("Comp List Detail Loader", CompUpdateDetailLoad, null, (ThreadPriority)2);

	private static readonly Regex RegexIsJarFile = new Regex("\\.jar(\\.disabled)?$");

	private static string GetFolderDescription(string FolderPath)
	{
		string result;
		try
		{
			result = (Directory.Exists(FolderPath) ? "文件夹" : "空文件夹");
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, $"获取文件夹描述失败：{FolderPath}");
			result = "文件夹";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private static void CompResourceListLoad(ModLoader.LoaderTask<CompLocalLoaderData, List<LocalCompFile>> Loader)
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Expected O, but got Unknown
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_0603: Unknown result type (might be due to invalid IL or missing references)
		//IL_060b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Unknown result type (might be due to invalid IL or missing references)
		//IL_073c: Unknown result type (might be due to invalid IL or missing references)
		_Closure_0024__6_002D0 arg = default(_Closure_0024__6_002D0);
		_Closure_0024__6_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__6_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader = Loader;
		try
		{
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Frm != null)
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Frm.Load.ShowProgress = false;
				}
			}));
			if (PageInstanceCompResource.UpdatingVersions.Contains(CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.CompPath))
			{
				ModBase.Log("[Mod] 等待资源更新完成后才能继续加载资源列表：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.CompPath);
				try
				{
					ModBase.RunInUiWait((Action)([SpecialName] () =>
					{
						if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Frm != null)
						{
							CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Frm.Load.Text = "正在更新资源";
						}
					}));
					while (PageInstanceCompResource.UpdatingVersions.Contains(CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.CompPath))
					{
						if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.IsAborted)
						{
							return;
						}
						Thread.Sleep(100);
					}
				}
				finally
				{
					ModBase.RunInUiWait((Action)([SpecialName] () =>
					{
						if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Frm != null)
						{
							CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Frm.Load.Text = "正在加载资源列表";
						}
					}));
				}
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Frm.LoaderRun(ModLoader.LoaderFolderRunType.UpdateOnly);
			}
			List<LocalCompFile> val = new List<LocalCompFile>();
			if (Directory.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.CompPath))
			{
				string text = CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.CompPath.ToLower();
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.CompType == ModComp.CompType.Schematic)
				{
					string text2 = "";
					if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Frm != null)
					{
						text2 = CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Frm.CurrentFolderPath;
					}
					string text3 = (string.IsNullOrEmpty(text2) ? CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.CompPath : text2);
					try
					{
						DirectoryInfo val2 = new DirectoryInfo(text3);
						System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
						try
						{
							enumerator = val2.EnumerateDirectories("*", (SearchOption)1).GetEnumerator();
							while (((System.Collections.IEnumerator)enumerator).MoveNext())
							{
								DirectoryInfo current = enumerator.Current;
								val.Add(new LocalCompFile(((FileSystemInfo)current).FullName + "\\__FOLDER__"));
							}
						}
						finally
						{
							((System.IDisposable)enumerator)?.Dispose();
						}
						System.Collections.Generic.IEnumerator<FileInfo> enumerator2 = default(System.Collections.Generic.IEnumerator<FileInfo>);
						try
						{
							enumerator2 = val2.EnumerateFiles("*", (SearchOption)1).GetEnumerator();
							while (((System.Collections.IEnumerator)enumerator2).MoveNext())
							{
								FileInfo current2 = enumerator2.Current;
								try
								{
									if (Conversions.ToBoolean(LocalCompFile.IsCompFile(((FileSystemInfo)current2).FullName, CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.CompType)))
									{
										val.Add(new LocalCompFile(((FileSystemInfo)current2).FullName));
									}
								}
								catch (System.Exception ex)
								{
									ProjectData.SetProjectError(ex);
									System.Exception ex2 = ex;
									ModBase.Log(ex2, $"处理文件失败：{((FileSystemInfo)current2).FullName}");
									ProjectData.ClearProjectError();
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
						ModBase.Log(ex4, $"枚举文件失败：{text3}");
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					try
					{
						System.Collections.Generic.IEnumerator<FileInfo> enumerator3 = default(System.Collections.Generic.IEnumerator<FileInfo>);
						try
						{
							enumerator3 = ModBase.EnumerateFiles(CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.CompPath).GetEnumerator();
							while (((System.Collections.IEnumerator)enumerator3).MoveNext())
							{
								FileInfo current3 = enumerator3.Current;
								try
								{
									if ((Operators.CompareString(current3.DirectoryName.ToLower() + "\\", text, false) == 0 || ((object)PageInstanceLeft.Instance != null && PageInstanceLeft.Instance.Version.HasForge && PageInstanceLeft.Instance.Version.McCodeMain < 13 && Operators.CompareString(current3.Directory.Name, $"1.{PageInstanceLeft.Instance.Version.McCodeMain}.{PageInstanceLeft.Instance.Version.McCodeSub}", false) == 0)) && Conversions.ToBoolean(LocalCompFile.IsCompFile(((FileSystemInfo)current3).FullName, CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.CompType)))
									{
										val.Add(new LocalCompFile(((FileSystemInfo)current3).FullName));
									}
								}
								catch (System.Exception ex5)
								{
									ProjectData.SetProjectError(ex5);
									System.Exception ex6 = ex5;
									ModBase.Log(ex6, $"处理文件失败：{((FileSystemInfo)current3).FullName}");
									ProjectData.ClearProjectError();
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator3)?.Dispose();
						}
					}
					catch (System.Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						System.Exception ex8 = ex7;
						ModBase.Log(ex8, $"枚举文件夹失败：{CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.CompPath}");
						ProjectData.ClearProjectError();
					}
				}
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Progress = 0.05;
			if (val.Count > 50)
			{
				ModBase.RunInUi((Action)([SpecialName] () =>
				{
					if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Frm != null)
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Frm.Load.ShowProgress = true;
					}
				}));
			}
			string filePath = ModBase.PathTemp + "Cache\\LocalComp.json";
			JObject jObject = new JObject();
			try
			{
				string text4 = ModBase.ReadFile(filePath);
				if (!string.IsNullOrWhiteSpace(text4))
				{
					jObject = (JObject)ModBase.GetJson(text4);
					if (!jObject.ContainsKey("version") || jObject["version"].ToObject<int>() != 7)
					{
						ModBase.Log("[Mod] 本地 Mod 信息缓存版本已过期，将弃用这些缓存信息", ModBase.LogLevel.Debug);
						jObject = new JObject();
					}
				}
			}
			catch (System.Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				System.Exception ex10 = ex9;
				ModBase.Log(ex10, "读取本地 Mod 信息缓存失败，已重置");
				jObject = new JObject();
				ProjectData.ClearProjectError();
			}
			jObject["version"] = 7;
			List<LocalCompFile> val3 = new List<LocalCompFile>();
			System.Collections.Generic.IEnumerator<LocalCompFile> enumerator4 = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
			try
			{
				enumerator4 = val.GetEnumerator();
				while (enumerator4.MoveNext())
				{
					LocalCompFile current4 = enumerator4.Current;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Progress += 0.94 / (double)val.Count;
					if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.IsAborted)
					{
						return;
					}
					if (current4.IsFolder)
					{
						continue;
					}
					if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.CompType == ModComp.CompType.Schematic)
					{
						current4.LoadBasicInfo();
					}
					else
					{
						current4.Load();
					}
					if (current4.State == LocalCompFile.LocalFileStatus.Unavailable)
					{
						continue;
					}
					string propertyName = current4.ModrinthHash + CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.GameVersion.Version.McName + ModBase.Join((System.Collections.IEnumerable)CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Loaders, "");
					if (jObject.ContainsKey(propertyName))
					{
						current4.FromJson((JObject)jObject[propertyName]);
						if (current4.CompLoaded && System.DateTime.Now - jObject[propertyName]["Comp"]["CacheTime"].ToObject<System.DateTime>() < new TimeSpan(6, 0, 0))
						{
							continue;
						}
					}
					val3.Add(current4);
				}
			}
			finally
			{
				((System.IDisposable)enumerator4).Dispose();
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Progress = 0.99;
			ModBase.Log($"[Mod] 共有 {val.Count} 个 Mod，其中 {Enumerable.Count<LocalCompFile>(Enumerable.Where<LocalCompFile>((System.Collections.Generic.IEnumerable<LocalCompFile>)val3, (Func<LocalCompFile, bool>)([SpecialName] (LocalCompFile m) => (object)m.Comp == null)))} 个需要联网获取信息，{Enumerable.Count<LocalCompFile>(Enumerable.Where<LocalCompFile>((System.Collections.Generic.IEnumerable<LocalCompFile>)val3, (Func<LocalCompFile, bool>)([SpecialName] (LocalCompFile m) => (object)m.Comp != null)))} 个需要更新信息");
			val = ModBase.Sort((System.Collections.Generic.IList<LocalCompFile>)val, [SpecialName] (LocalCompFile Left, LocalCompFile Right) => (Left.State == LocalCompFile.LocalFileStatus.Unavailable != (Right.State == LocalCompFile.LocalFileStatus.Unavailable)) ? (Left.State == LocalCompFile.LocalFileStatus.Unavailable) : (~Right.FileName.CompareTo(Left.FileName) != 0));
			if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.IsAborted)
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Output = val;
				if (Enumerable.Any<LocalCompFile>((System.Collections.Generic.IEnumerable<LocalCompFile>)val3))
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.DetailInfo = new KeyValuePair<List<LocalCompFile>, JObject>(val3, jObject);
					CompUpdateDetailLoader.Start(CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input, IsForceRestart: true);
				}
			}
		}
		catch (System.Exception ex11)
		{
			ProjectData.SetProjectError(ex11);
			System.Exception ex12 = ex11;
			ModBase.Log(ex12, "Mod 列表加载失败");
			throw;
		}
	}

	private static void CompUpdateDetailLoad(ModLoader.LoaderTask<CompLocalLoaderData, int> Loader)
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Expected O, but got Unknown
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		_Closure_0024__8_002D0 arg = default(_Closure_0024__8_002D0);
		_Closure_0024__8_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__8_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader = Loader;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Mods = CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.DetailInfo.Key;
		JObject value = CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.DetailInfo.Value;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ModLoaders = CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Loaders;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance = CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.GameVersion.Version.McName;
		ModBase.Log(string.Format("[Mod] 目标加载器：{0}，版本：{1}", (object)ModBase.Join((System.Collections.IEnumerable)CS_0024_003C_003E8__locals0._0024VB_0024Local_ModLoaders, "/"), (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance));
		CS_0024_003C_003E8__locals0._0024VB_0024Local_EndedThreadCount = 0;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_IsFailed = false;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_CurrentThread = Thread.CurrentThread;
		checked
		{
			ModBase.RunInNewThread((Action)([SpecialName] () =>
			{
				//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
				//IL_0294: Unknown result type (might be due to invalid IL or missing references)
				//IL_0299: Unknown result type (might be due to invalid IL or missing references)
				//IL_036b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0370: Unknown result type (might be due to invalid IL or missing references)
				try
				{
					List<string> list = Enumerable.ToList<string>(Enumerable.Select<LocalCompFile, string>((System.Collections.Generic.IEnumerable<LocalCompFile>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Mods, (Func<LocalCompFile, string>)([SpecialName] (LocalCompFile m) => m.ModrinthHash)));
					JObject jObject = (JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files", "POST", string.Format("{{\"hashes\": [\"{0}\"], \"algorithm\": \"sha1\"}}", (object)ModBase.Join((System.Collections.IEnumerable)list, "\",\"")), "application/json"));
					ModBase.Log($"[Mod] 从 Modrinth 获取到 {jObject.Count} 个本地 Mod 的对应信息");
					if (jObject.Count != 0)
					{
						Dictionary<string, List<LocalCompFile>> val9 = new Dictionary<string, List<LocalCompFile>>();
						System.Collections.Generic.IEnumerator<LocalCompFile> enumerator12 = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
						try
						{
							enumerator12 = CS_0024_003C_003E8__locals0._0024VB_0024Local_Mods.GetEnumerator();
							while (enumerator12.MoveNext())
							{
								LocalCompFile current12 = enumerator12.Current;
								if (jObject.ContainsKey(current12.ModrinthHash) && !((string?)jObject[current12.ModrinthHash]["files"][0]["hashes"]["sha1"] != current12.ModrinthHash))
								{
									string text4 = jObject[current12.ModrinthHash]["project_id"].ToString();
									if (ModComp.CompProjectCache.ContainsKey(text4) && (object)current12.Comp == null)
									{
										current12.Comp = ModComp.CompProjectCache[text4];
									}
									if (!val9.ContainsKey(text4))
									{
										val9[text4] = new List<LocalCompFile>();
									}
									val9[text4].Add(current12);
									ModComp.CompFile compFile3 = new ModComp.CompFile((JObject)jObject[current12.ModrinthHash], ModComp.CompType.Mod);
									if (current12.CompFile == null || System.DateTime.Compare(current12.CompFile.ReleaseDate, compFile3.ReleaseDate) < 0)
									{
										current12.CompFile = compFile3;
									}
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator12).Dispose();
						}
						if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.IsAbortedWithThread(CS_0024_003C_003E8__locals0._0024VB_0024Local_CurrentThread))
						{
							ModBase.Log($"[Mod] 需要从 Modrinth 获取 {val9.Count} 个本地 Mod 的工程信息");
							if (Enumerable.Any<KeyValuePair<string, List<LocalCompFile>>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, List<LocalCompFile>>>)val9))
							{
								JArray jArray = (JArray)ModBase.GetJson(ModDownload.DlModRequest(string.Format("https://api.modrinth.com/v2/projects?ids=[\"{0}\"]", (object)ModBase.Join((System.Collections.IEnumerable)val9.Keys, "\",\"")), "GET", "", "application/json"));
								System.Collections.Generic.IEnumerator<JToken> enumerator13 = default(System.Collections.Generic.IEnumerator<JToken>);
								try
								{
									enumerator13 = jArray.GetEnumerator();
									System.Collections.Generic.IEnumerator<LocalCompFile> enumerator14 = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
									while (((System.Collections.IEnumerator)enumerator13).MoveNext())
									{
										JToken current13 = enumerator13.Current;
										ModComp.CompProject compProject2 = new ModComp.CompProject((JObject)current13);
										try
										{
											enumerator14 = val9[compProject2.Id].GetEnumerator();
											while (enumerator14.MoveNext())
											{
												enumerator14.Current.Comp = compProject2;
											}
										}
										finally
										{
											((System.IDisposable)enumerator14).Dispose();
										}
									}
								}
								finally
								{
									((System.IDisposable)enumerator13)?.Dispose();
								}
								ModBase.Log("[Mod] 已从 Modrinth 获取本地 Mod 信息，继续获取更新信息");
								JObject jObject2 = (JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.modrinth.com/v2/version_files/update", "POST", string.Format("{{\"hashes\": [\"{0}\"], \"algorithm\": \"sha1\", \n                    \"loaders\": [\"{1}\"],\"game_versions\": [\"{2}\"]}}", (object)ModBase.Join((System.Collections.IEnumerable)Enumerable.SelectMany<KeyValuePair<string, List<LocalCompFile>>, string>((System.Collections.Generic.IEnumerable<KeyValuePair<string, List<LocalCompFile>>>)val9, (Func<KeyValuePair<string, List<LocalCompFile>>, System.Collections.Generic.IEnumerable<string>>)([SpecialName] (KeyValuePair<string, List<LocalCompFile>> l) => Enumerable.Select<LocalCompFile, string>((System.Collections.Generic.IEnumerable<LocalCompFile>)l.Value, (Func<LocalCompFile, string>)([SpecialName] (LocalCompFile m) => m.ModrinthHash)))), "\",\""), (object)ModBase.Join((System.Collections.IEnumerable)CS_0024_003C_003E8__locals0._0024VB_0024Local_ModLoaders, "\",\"").ToLower(), (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance), "application/json"));
								System.Collections.Generic.IEnumerator<LocalCompFile> enumerator15 = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
								try
								{
									enumerator15 = CS_0024_003C_003E8__locals0._0024VB_0024Local_Mods.GetEnumerator();
									while (enumerator15.MoveNext())
									{
										LocalCompFile current14 = enumerator15.Current;
										if (jObject2.ContainsKey(current14.ModrinthHash) && current14.CompFile != null)
										{
											ModComp.CompFile compFile4 = new ModComp.CompFile((JObject)jObject2[current14.ModrinthHash], ModComp.CompType.Mod);
											if (compFile4.Available)
											{
												if (ModBase.ModeDebug)
												{
													ModBase.Log($"[Mod] 本地文件 {current14.CompFile.FileName} 在 Modrinth 上的最新版为 {compFile4.FileName}");
												}
												if (System.DateTime.Compare(current14.CompFile.ReleaseDate, compFile4.ReleaseDate) < 0 && Operators.CompareString(current14.CompFile.Hash, compFile4.Hash, false) != 0)
												{
													if (current14.UpdateFile != null && Operators.CompareString(compFile4.Hash, current14.UpdateFile.Hash, false) == 0)
													{
														current14.ChangelogUrls.Add(string.Format("https://modrinth.com/mod/{0}/changelog?g={1}", (object)jObject2[current14.ModrinthHash]["project_id"], (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance));
														compFile4.DownloadUrls.AddRange((System.Collections.Generic.IEnumerable<string>)current14.UpdateFile.DownloadUrls);
														current14.UpdateFile = compFile4;
													}
													else if (current14.UpdateFile == null || System.DateTime.Compare(compFile4.ReleaseDate, current14.UpdateFile.ReleaseDate) >= 0)
													{
														List<string> obj2 = new List<string>();
														obj2.Add(string.Format("https://modrinth.com/mod/{0}/changelog?g={1}", (object)jObject2[current14.ModrinthHash]["project_id"], (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance));
														current14.ChangelogUrls = obj2;
														current14.UpdateFile = compFile4;
													}
												}
											}
										}
									}
								}
								finally
								{
									((System.IDisposable)enumerator15).Dispose();
								}
								ModBase.Log("[Mod] 从 Modrinth 获取本地 Mod 信息结束");
							}
						}
					}
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, "从 Modrinth 获取本地 Mod 信息失败");
					CS_0024_003C_003E8__locals0._0024VB_0024Local_IsFailed = true;
					ProjectData.ClearProjectError();
				}
				finally
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_EndedThreadCount++;
				}
			}), "Mod List Detail Loader Modrinth", (ThreadPriority)2);
			ModBase.RunInNewThread((Action)([SpecialName] () =>
			{
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				//IL_0129: Unknown result type (might be due to invalid IL or missing references)
				//IL_012e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0318: Unknown result type (might be due to invalid IL or missing references)
				//IL_031d: Unknown result type (might be due to invalid IL or missing references)
				//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
				//IL_05af: Unknown result type (might be due to invalid IL or missing references)
				//IL_0625: Unknown result type (might be due to invalid IL or missing references)
				//IL_062a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0633: Unknown result type (might be due to invalid IL or missing references)
				//IL_0638: Unknown result type (might be due to invalid IL or missing references)
				//IL_045d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0462: Unknown result type (might be due to invalid IL or missing references)
				try
				{
					List<uint> val3 = new List<uint>();
					System.Collections.Generic.IEnumerator<LocalCompFile> enumerator2 = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
					try
					{
						enumerator2 = CS_0024_003C_003E8__locals0._0024VB_0024Local_Mods.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							LocalCompFile current2 = enumerator2.Current;
							val3.Add(current2.CurseForgeHash);
							if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.IsAbortedWithThread(CS_0024_003C_003E8__locals0._0024VB_0024Local_CurrentThread))
							{
								return;
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator2).Dispose();
					}
					JContainer jContainer = (JContainer)((JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/fingerprints/432", "POST", string.Format("{{\"fingerprints\": [{0}]}}", (object)ModBase.Join((System.Collections.IEnumerable)val3, ",")), "application/json")))["data"]["exactMatches"];
					ModBase.Log($"[Mod] 从 CurseForge 获取到 {jContainer.Count} 个本地 Mod 的对应信息");
					if (Enumerable.Any<JToken>((System.Collections.Generic.IEnumerable<JToken>)jContainer))
					{
						Dictionary<int, List<LocalCompFile>> val4 = new Dictionary<int, List<LocalCompFile>>();
						System.Collections.Generic.IEnumerator<JToken> enumerator3 = default(System.Collections.Generic.IEnumerator<JToken>);
						try
						{
							enumerator3 = ((System.Collections.Generic.IEnumerable<JToken>)jContainer).GetEnumerator();
							System.Collections.Generic.IEnumerator<LocalCompFile> enumerator4 = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
							while (((System.Collections.IEnumerator)enumerator3).MoveNext())
							{
								JToken current3 = enumerator3.Current;
								string text = current3["id"].ToString();
								uint num = (uint)current3["file"]["fileFingerprint"];
								try
								{
									enumerator4 = CS_0024_003C_003E8__locals0._0024VB_0024Local_Mods.GetEnumerator();
									while (enumerator4.MoveNext())
									{
										LocalCompFile current4 = enumerator4.Current;
										if (current4.CurseForgeHash == num)
										{
											if (ModComp.CompProjectCache.ContainsKey(text) && (object)current4.Comp == null)
											{
												current4.Comp = ModComp.CompProjectCache[text];
											}
											if (!val4.ContainsKey(Conversions.ToInteger(text)))
											{
												val4[Conversions.ToInteger(text)] = new List<LocalCompFile>();
											}
											val4[Conversions.ToInteger(text)].Add(current4);
											ModComp.CompFile compFile = new ModComp.CompFile((JObject)current3["file"], ModComp.CompType.Mod);
											if (current4.CompFile == null || System.DateTime.Compare(current4.CompFile.ReleaseDate, compFile.ReleaseDate) < 0)
											{
												current4.CompFile = compFile;
											}
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
						if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.IsAbortedWithThread(CS_0024_003C_003E8__locals0._0024VB_0024Local_CurrentThread))
						{
							ModBase.Log($"[Mod] 需要从 CurseForge 获取 {val4.Count} 个本地 Mod 的工程信息");
							if (Enumerable.Any<KeyValuePair<int, List<LocalCompFile>>>((System.Collections.Generic.IEnumerable<KeyValuePair<int, List<LocalCompFile>>>)val4))
							{
								JToken jToken = ((JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/mods", "POST", string.Format("{{\"modIds\": [{0}]}}", (object)ModBase.Join((System.Collections.IEnumerable)val4.Keys, ",")), "application/json")))["data"];
								Dictionary<int, List<LocalCompFile>> val5 = new Dictionary<int, List<LocalCompFile>>();
								Dictionary<int, string> val6 = new Dictionary<int, string>();
								System.Collections.Generic.IEnumerator<JToken> enumerator5 = default(System.Collections.Generic.IEnumerator<JToken>);
								try
								{
									enumerator5 = ((System.Collections.Generic.IEnumerable<JToken>)jToken).GetEnumerator();
									System.Collections.Generic.IEnumerator<LocalCompFile> enumerator6 = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
									System.Collections.Generic.IEnumerator<JToken> enumerator7 = default(System.Collections.Generic.IEnumerator<JToken>);
									System.Collections.Generic.IEnumerator<int> enumerator8 = default(System.Collections.Generic.IEnumerator<int>);
									while (((System.Collections.IEnumerator)enumerator5).MoveNext())
									{
										JToken current5 = enumerator5.Current;
										if (current5["isAvailable"] == null || current5["isAvailable"].ToObject<bool>())
										{
											ModComp.CompProject compProject = new ModComp.CompProject((JObject)current5);
											try
											{
												enumerator6 = val4[Conversions.ToInteger(compProject.Id)].GetEnumerator();
												while (enumerator6.MoveNext())
												{
													LocalCompFile current6 = enumerator6.Current;
													if ((object)current6.Comp != null && !current6.Comp.FromCurseForge)
													{
														current6.Comp = current6.Comp;
													}
													else
													{
														current6.Comp = compProject;
													}
												}
											}
											finally
											{
												((System.IDisposable)enumerator6).Dispose();
											}
											if (CS_0024_003C_003E8__locals0._0024VB_0024Local_ModLoaders.Count == 1)
											{
												string text2 = null;
												List<int> val7 = new List<int>();
												try
												{
													enumerator7 = ((System.Collections.Generic.IEnumerable<JToken>)current5["latestFilesIndexes"]).GetEnumerator();
													while (((System.Collections.IEnumerator)enumerator7).MoveNext())
													{
														JToken current7 = enumerator7.Current;
														if (current7["modLoader"] != null && Enumerable.Single<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)CS_0024_003C_003E8__locals0._0024VB_0024Local_ModLoaders) == unchecked((ModComp.CompLoaderType)current7["modLoader"].ToObject<int>()))
														{
															string text3 = (string?)current7["gameVersion"];
															if (Operators.CompareString(text3, CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance, false) == 0 && (text2 == null || ModMinecraft.VersionSortInteger(text2, text3) <= -1))
															{
																if (Operators.CompareString(text2, text3, false) != 0)
																{
																	text2 = text3;
																	val7.Clear();
																}
																val7.Add(current7["fileId"].ToObject<int>());
															}
														}
													}
												}
												finally
												{
													((System.IDisposable)enumerator7)?.Dispose();
												}
												try
												{
													enumerator8 = val7.GetEnumerator();
													while (enumerator8.MoveNext())
													{
														int current8 = enumerator8.Current;
														if (!val5.ContainsKey(current8))
														{
															val5[current8] = new List<LocalCompFile>();
														}
														val5[current8].AddRange((System.Collections.Generic.IEnumerable<LocalCompFile>)val4[Conversions.ToInteger(compProject.Id)]);
														val6[current8] = compProject.Slug;
													}
												}
												finally
												{
													((System.IDisposable)enumerator8).Dispose();
												}
											}
										}
									}
								}
								finally
								{
									((System.IDisposable)enumerator5)?.Dispose();
								}
								ModBase.Log($"[Mod] 已从 CurseForge 获取本地 Mod 信息，需要获取 {val5.Count} 个用于检查更新的文件信息");
								if (Enumerable.Any<KeyValuePair<int, List<LocalCompFile>>>((System.Collections.Generic.IEnumerable<KeyValuePair<int, List<LocalCompFile>>>)val5))
								{
									JToken jToken2 = ((JObject)ModBase.GetJson(ModDownload.DlModRequest("https://api.curseforge.com/v1/mods/files", "POST", string.Format("{{\"fileIds\": [{0}]}}", (object)ModBase.Join((System.Collections.IEnumerable)val5.Keys, ",")), "application/json")))["data"];
									Dictionary<LocalCompFile, ModComp.CompFile> val8 = new Dictionary<LocalCompFile, ModComp.CompFile>();
									System.Collections.Generic.IEnumerator<JToken> enumerator9 = default(System.Collections.Generic.IEnumerator<JToken>);
									try
									{
										enumerator9 = ((System.Collections.Generic.IEnumerable<JToken>)jToken2).GetEnumerator();
										System.Collections.Generic.IEnumerator<LocalCompFile> enumerator10 = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
										while (((System.Collections.IEnumerator)enumerator9).MoveNext())
										{
											JToken current9 = enumerator9.Current;
											ModComp.CompFile compFile2 = new ModComp.CompFile((JObject)current9, ModComp.CompType.Mod);
											if (compFile2.Available)
											{
												try
												{
													enumerator10 = val5[Conversions.ToInteger(compFile2.Id)].GetEnumerator();
													while (enumerator10.MoveNext())
													{
														LocalCompFile current10 = enumerator10.Current;
														if (!val8.ContainsKey(current10) || System.DateTime.Compare(val8[current10].ReleaseDate, compFile2.ReleaseDate) < 0)
														{
															val8[current10] = compFile2;
														}
													}
												}
												finally
												{
													((System.IDisposable)enumerator10).Dispose();
												}
											}
										}
									}
									finally
									{
										((System.IDisposable)enumerator9)?.Dispose();
									}
									System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<LocalCompFile, ModComp.CompFile>> enumerator11 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<LocalCompFile, ModComp.CompFile>>);
									try
									{
										enumerator11 = val8.GetEnumerator();
										while (enumerator11.MoveNext())
										{
											KeyValuePair<LocalCompFile, ModComp.CompFile> current11 = enumerator11.Current;
											LocalCompFile key = current11.Key;
											ModComp.CompFile value2 = current11.Value;
											if (ModBase.ModeDebug)
											{
												ModBase.Log($"[Mod] 本地文件 {key.CompFile.FileName} 在 CurseForge 上的最新版为 {value2.FileName}");
											}
											if (System.DateTime.Compare(key.CompFile.ReleaseDate, value2.ReleaseDate) < 0 && Operators.CompareString(key.CompFile.Hash, value2.Hash, false) != 0)
											{
												if (key.UpdateFile != null && Operators.CompareString(value2.Hash, key.UpdateFile.Hash, false) == 0)
												{
													key.ChangelogUrls.Add($"https://www.curseforge.com/minecraft/mc-mods/{val6[Conversions.ToInteger(value2.Id)]}/files/{value2.Id}");
													key.UpdateFile.DownloadUrls.AddRange((System.Collections.Generic.IEnumerable<string>)value2.DownloadUrls);
												}
												else if (key.UpdateFile == null || System.DateTime.Compare(value2.ReleaseDate, key.UpdateFile.ReleaseDate) > 0)
												{
													List<string> obj = new List<string>();
													obj.Add($"https://www.curseforge.com/minecraft/mc-mods/{val6[Conversions.ToInteger(value2.Id)]}/files/{value2.Id}");
													key.ChangelogUrls = obj;
													key.UpdateFile = value2;
												}
											}
										}
									}
									finally
									{
										((System.IDisposable)enumerator11).Dispose();
									}
									ModBase.Log("[Mod] 从 CurseForge 获取 Mod 更新信息结束");
								}
							}
						}
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "从 CurseForge 获取本地 Mod 信息失败");
					CS_0024_003C_003E8__locals0._0024VB_0024Local_IsFailed = true;
					ProjectData.ClearProjectError();
				}
				finally
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_EndedThreadCount++;
				}
			}), "Mod List Detail Loader CurseForge", (ThreadPriority)2);
			System.Collections.Generic.IEnumerator<LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<LocalCompFile>);
			while (true)
			{
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_EndedThreadCount != 2)
				{
					if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.IsAborted)
					{
						Thread.Sleep(10);
						continue;
					}
					break;
				}
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Mods = Enumerable.ToList<LocalCompFile>(Enumerable.Where<LocalCompFile>((System.Collections.Generic.IEnumerable<LocalCompFile>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Mods, (Func<LocalCompFile, bool>)([SpecialName] (LocalCompFile m) => (object)m.Comp != null)));
				ModBase.Log($"[Mod] 联网获取本地 Mod 信息完成，为 {CS_0024_003C_003E8__locals0._0024VB_0024Local_Mods.Count} 个 Mod 更新缓存");
				if (!Enumerable.Any<LocalCompFile>((System.Collections.Generic.IEnumerable<LocalCompFile>)CS_0024_003C_003E8__locals0._0024VB_0024Local_Mods))
				{
					break;
				}
				try
				{
					enumerator = CS_0024_003C_003E8__locals0._0024VB_0024Local_Mods.GetEnumerator();
					while (enumerator.MoveNext())
					{
						LocalCompFile current = enumerator.Current;
						current.CompLoaded = !CS_0024_003C_003E8__locals0._0024VB_0024Local_IsFailed;
						value[current.ModrinthHash + CS_0024_003C_003E8__locals0._0024VB_0024Local_McInstance + ModBase.Join((System.Collections.IEnumerable)CS_0024_003C_003E8__locals0._0024VB_0024Local_ModLoaders, "")] = current.ToJson();
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				ModBase.WriteFile(ModBase.PathTemp + "Cache\\LocalComp.json", value.ToString(ModBase.ModeDebug ? Formatting.Indented : Formatting.None));
				PageInstanceCompResource frmInstanceMod = ModMain.FrmInstanceMod;
				if (frmInstanceMod != null && frmInstanceMod.Filter == PageInstanceCompResource.FilterType.CanUpdate)
				{
					object action;
					if (_Closure_0024__._0024I8_002D6 != null)
					{
						action = _Closure_0024__._0024I8_002D6;
					}
					else
					{
						Action val = [SpecialName] () =>
						{
							ModMain.FrmInstanceMod?.RefreshUI();
						};
						_Closure_0024__._0024I8_002D6 = val;
						action = (object)val;
					}
					ModBase.RunInUi((Action)action);
					break;
				}
				object action2;
				if (_Closure_0024__._0024I8_002D7 != null)
				{
					action2 = _Closure_0024__._0024I8_002D7;
				}
				else
				{
					Action val2 = [SpecialName] () =>
					{
						ModMain.FrmInstanceMod?.RefreshBars();
					};
					_Closure_0024__._0024I8_002D7 = val2;
					action2 = (object)val2;
				}
				ModBase.RunInUi((Action)action2);
				break;
			}
		}
	}

	public static List<ModComp.CompLoaderType> GetCurrentVersionModLoader()
	{
		List<ModComp.CompLoaderType> val = new List<ModComp.CompLoaderType>();
		if (PageInstanceLeft.Instance.Version.HasForge)
		{
			val.Add(ModComp.CompLoaderType.Forge);
		}
		if (PageInstanceLeft.Instance.Version.HasNeoForge)
		{
			val.Add(ModComp.CompLoaderType.NeoForge);
		}
		if (PageInstanceLeft.Instance.Version.HasFabric)
		{
			val.Add(ModComp.CompLoaderType.Fabric);
		}
		if (PageInstanceLeft.Instance.Version.HasQuilt)
		{
			val.AddRange((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)new ModComp.CompLoaderType[2]
			{
				ModComp.CompLoaderType.Fabric,
				ModComp.CompLoaderType.Quilt
			});
		}
		if (PageInstanceLeft.Instance.Version.HasLiteLoader)
		{
			val.Add(ModComp.CompLoaderType.LiteLoader);
		}
		if (!Enumerable.Any<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)val))
		{
ModComp.CompLoaderType[] array = new ModComp.CompLoaderType[] { (ModComp.CompLoaderType)1, (ModComp.CompLoaderType)6, (ModComp.CompLoaderType)4, (ModComp.CompLoaderType)3, (ModComp.CompLoaderType)5 };
			val.AddRange((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)array);
		}
		return val;
	}

	public static string GetPathNameByCompType(ModComp.CompType TheType)
	{
		return TheType switch
		{
			ModComp.CompType.Mod => "mods", 
			ModComp.CompType.ResourcePack => "resourcepacks", 
			ModComp.CompType.Shader => "shaderpacks", 
			ModComp.CompType.Schematic => "schematics", 
			ModComp.CompType.World => "saves", 
			_ => "Nothing", 
		};
	}

	public static LocalCompFile GetModLocalCompByKeywords(ModMinecraft.McInstance instance, string modId, string mainKeyword, params string[] keywords)
	{
		if (modId == null)
		{
			return null;
		}
		return GetModLocalCompByKeywords(instance, new string[] { modId }, mainKeyword, keywords);
	}

	public static LocalCompFile GetModLocalCompByKeywords(ModMinecraft.McInstance instance, string[] modIds, string mainKeyword, params string[] keywords)
	{
		if (!instance.Modable)
		{
			return null;
		}
		string text = $"{instance.Path}mods";
		if (!Directory.Exists(text))
		{
			return null;
		}
		System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator = Directory.EnumerateFiles(text, $"*{mainKeyword}*").GetEnumerator();
			_Closure_0024__13_002D0 closure_0024__13_002D = default(_Closure_0024__13_002D0);
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				string current = enumerator.Current;
				closure_0024__13_002D = new _Closure_0024__13_002D0(closure_0024__13_002D);
				closure_0024__13_002D._0024VB_0024Local_lowerFilePath = current.ToLower();
				if (RegexIsJarFile.IsMatch(closure_0024__13_002D._0024VB_0024Local_lowerFilePath) && !((keywords.Length > 0) & !Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)keywords, (Func<string, bool>)closure_0024__13_002D._Lambda_0024__0)))
				{
					closure_0024__13_002D._0024VB_0024Local_localComp = new LocalCompFile(current);
					closure_0024__13_002D._0024VB_0024Local_localComp.Load();
					if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)modIds, (Func<string, bool>)closure_0024__13_002D._Lambda_0024__1))
					{
						return closure_0024__13_002D._0024VB_0024Local_localComp;
					}
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		return null;
	}
}
