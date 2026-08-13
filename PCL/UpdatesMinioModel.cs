using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.Core.Utils;
using PCL.Core.Utils.Diff;

namespace PCL;

public class UpdatesMinioModel : IUpdateSource
{
	private class MinioUpdateModel
	{
		[field: CompilerGenerated]
		public List<MinioUpdateAsset> assets
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}
	}

	private class MinioUpdateAsset
	{
		[field: CompilerGenerated]
		public string file_name
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public MinioUpdateAssetVersionInfo version
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string upd_time
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public List<string> downloads
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public List<string> patches
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string sha256
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string changelog
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}
	}

	private class MinioUpdateAssetVersionInfo
	{
		[field: CompilerGenerated]
		public string channel
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string name
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public int code
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__16_002D0
	{
		public UpdateChannel _0024VB_0024Local_channel;

		public UpdateArch _0024VB_0024Local_arch;

		public bool _0024VB_0024Local_patchUpdate;

		public string _0024VB_0024Local_tempPath;

		public string _0024VB_0024Local_output;

		public UpdatesMinioModel _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__0(ModLoader.LoaderTask<int, List<ModNet.NetFile>> load)
		{
			string channelName = _0024VB_0024Me.GetChannelName(_0024VB_0024Local_channel, _0024VB_0024Local_arch);
			JToken remoteInfoByName = _0024VB_0024Me.GetRemoteInfoByName($"updates-{channelName}", "updates/");
			MinioUpdateAsset minioUpdateAsset = ((remoteInfoByName != null) ? Enumerable.FirstOrDefault<MinioUpdateAsset>((System.Collections.Generic.IEnumerable<MinioUpdateAsset>)remoteInfoByName.ToObject<MinioUpdateModel>().assets) : null);
			if (minioUpdateAsset == null)
			{
				throw new System.Exception("No assets can download!");
			}
			string fileSHA = ModBase.GetFileSHA256(ModBase.ExePathWithName);
			string sha = minioUpdateAsset.sha256;
			string text = $"{fileSHA}_{sha}.patch";
			if (minioUpdateAsset.patches.Contains(text))
			{
				_0024VB_0024Local_patchUpdate = true;
				_0024VB_0024Local_tempPath += text;
				List<ModNet.NetFile> val = new List<ModNet.NetFile>();
				val.Add(new ModNet.NetFile(new string[] { $"{_0024VB_0024Me._baseUrl}static/patch/{text}" }, _0024VB_0024Local_tempPath));
				load.Output = val;
			}
			else
			{
				_0024VB_0024Local_patchUpdate = false;
				_0024VB_0024Local_tempPath += $"{minioUpdateAsset.sha256}.bin";
				List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
				obj.Add(new ModNet.NetFile((System.Collections.Generic.IEnumerable<string>)RandomUtils.Shuffle((System.Collections.Generic.IList<string>)minioUpdateAsset.downloads), _0024VB_0024Local_tempPath));
				load.Output = obj;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R1(ModLoader.LoaderTask<string, int> a0)
		{
			_Lambda_0024__1();
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Expected O, but got Unknown
			if (_0024VB_0024Local_patchUpdate)
			{
				byte[] result = new BsDiff().ApplyAsync(ModBase.ReadFileBytes(ModBase.ExePathWithName), ModBase.ReadFileBytes(_0024VB_0024Local_tempPath)).GetAwaiter().GetResult();
				ModBase.WriteFile(_0024VB_0024Local_output, result);
				return;
			}
			FileStream val = new FileStream(_0024VB_0024Local_tempPath, (FileMode)3, (FileAccess)1, (FileShare)1);
			try
			{
				ZipArchive val2 = new ZipArchive((Stream)(object)val);
				try
				{
					ZipArchiveEntry val3 = Enumerable.FirstOrDefault<ZipArchiveEntry>(Enumerable.Where<ZipArchiveEntry>((System.Collections.Generic.IEnumerable<ZipArchiveEntry>)val2.Entries, (Func<ZipArchiveEntry, bool>)([SpecialName] (ZipArchiveEntry x) => x.Name.Contains("PCL Pro-N.exe"))));
					if (val3 == null)
					{
						val3 = Enumerable.FirstOrDefault<ZipArchiveEntry>(Enumerable.Where<ZipArchiveEntry>((System.Collections.Generic.IEnumerable<ZipArchiveEntry>)val2.Entries, (Func<ZipArchiveEntry, bool>)([SpecialName] (ZipArchiveEntry x) => x.Name.Contains("Plain Craft Launcher"))));
					}
					if (val3 == null)
					{
						val3 = Enumerable.FirstOrDefault<ZipArchiveEntry>(Enumerable.Where<ZipArchiveEntry>((System.Collections.Generic.IEnumerable<ZipArchiveEntry>)val2.Entries, (Func<ZipArchiveEntry, bool>)([SpecialName] (ZipArchiveEntry x) => x.Name.Contains("Launcher"))));
					}
					if (val3 == null)
					{
						val3 = Enumerable.FirstOrDefault<ZipArchiveEntry>(Enumerable.Where<ZipArchiveEntry>((System.Collections.Generic.IEnumerable<ZipArchiveEntry>)val2.Entries, (Func<ZipArchiveEntry, bool>)([SpecialName] (ZipArchiveEntry x) => x.Name.Contains(".exe"))));
					}
					if (val3 == null)
					{
						throw new System.Exception("找不到更新文件");
					}
					ZipFileExtensions.ExtractToFile(val3, _0024VB_0024Local_output, true);
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
		}
	}

	private string _baseUrl;

	private Dictionary<string, string> _remoteCache;

	[field: CompilerGenerated]
	public string SourceName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public UpdatesMinioModel(string BaseUrl, string Name = "Minio")
	{
		_baseUrl = BaseUrl;
		SourceName = Name;
	}

	public bool IsAvailable()
	{
		return !string.IsNullOrWhiteSpace(_baseUrl);
	}

	bool IUpdateSource.IsAvailable()
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsAvailable
		return this.IsAvailable();
	}

	public bool RefreshCache()
	{
		JToken jToken = JToken.Parse(Conversions.ToString(ModNet.NetGetCodeByRequestRetry($"{_baseUrl}apiv2/cache.json")));
		_remoteCache = jToken.ToObject<Dictionary<string, string>>();
		return true;
	}

	bool IUpdateSource.RefreshCache()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RefreshCache
		return this.RefreshCache();
	}

	public VersionDataModel GetLatestVersion(UpdateChannel channel, UpdateArch arch)
	{
		if (_remoteCache == null)
		{
			RefreshCache();
		}
		return GetChannelInfo(channel, arch);
	}

	VersionDataModel IUpdateSource.GetLatestVersion(UpdateChannel channel, UpdateArch arch)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetLatestVersion
		return this.GetLatestVersion(channel, arch);
	}

	public bool IsLatest(UpdateChannel channel, UpdateArch arch, SemVer currentVersion, int currentVersionCode)
	{
		if (_remoteCache == null)
		{
			RefreshCache();
		}
		VersionDataModel channelInfo = GetChannelInfo(channel, arch);
		return currentVersionCode >= channelInfo.VersionCode;
	}

	bool IUpdateSource.IsLatest(UpdateChannel channel, UpdateArch arch, SemVer currentVersion, int currentVersionCode)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsLatest
		return this.IsLatest(channel, arch, currentVersion, currentVersionCode);
	}

	public VersionAnnouncementDataModel GetAnnouncementList()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (_remoteCache == null)
		{
			RefreshCache();
		}
		return GetRemoteInfoByName("announcement")?.ToObject<VersionAnnouncementDataModel>() ?? throw new NullReferenceException("Can not get remote announcement info!");
	}

	VersionAnnouncementDataModel IUpdateSource.GetAnnouncementList()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnnouncementList
		return this.GetAnnouncementList();
	}

	private VersionDataModel GetChannelInfo(UpdateChannel channel, UpdateArch arch)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		string channelName = GetChannelName(channel, arch);
		JToken remoteInfoByName = GetRemoteInfoByName($"updates-{channelName}", "updates/");
		MinioUpdateAsset minioUpdateAsset = ((remoteInfoByName != null) ? Enumerable.FirstOrDefault<MinioUpdateAsset>((System.Collections.Generic.IEnumerable<MinioUpdateAsset>)remoteInfoByName.ToObject<MinioUpdateModel>().assets) : null);
		if (minioUpdateAsset == null)
		{
			throw new NullReferenceException("Can not get remote update info!");
		}
		return new VersionDataModel
		{
			VersionName = minioUpdateAsset.version.name,
			VersionCode = minioUpdateAsset.version.code,
			SHA256 = minioUpdateAsset.sha256,
			Source = SourceName,
			Changelog = minioUpdateAsset.changelog
		};
	}

	private JToken GetRemoteInfoByName(string name, string path = "")
	{
		string text = Path.Combine(ModBase.PathTemp, "Cache", "Update", $"{name}.json");
		JToken result;
		if (IsCacheValid($"{name}.json", _remoteCache[name]))
		{
			result = JToken.Parse(ModBase.ReadFile(text));
		}
		else
		{
			object objectValue = RuntimeHelpers.GetObjectValue(ModNet.NetGetCodeByRequestRetry($"{_baseUrl}apiv2/{path}{name}.json"));
			result = JToken.Parse(Conversions.ToString(objectValue));
			System.Type typeFromHandle = typeof(ModBase);
			object[] obj = new object[] { text, objectValue };
			object[] array = obj;
			bool[] obj2 = new bool[] { true, true };
			bool[] array2 = obj2;
			NewLateBinding.LateCall((object)null, typeFromHandle, "WriteFile", obj, (string[])null, (System.Type[])null, obj2, true);
			if (array2[0])
			{
				text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
			}
			if (array2[1])
			{
				objectValue = RuntimeHelpers.GetObjectValue(array[1]);
			}
		}
		return result;
	}

	private bool IsCacheValid(string path, string hash)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		string text = Path.Combine(ModBase.PathTemp, "Cache", "Update", path);
		FileInfo val = new FileInfo(text);
		if (val.Exists)
		{
			TimeSpan val2 = System.DateTime.Now - ((FileSystemInfo)val).LastWriteTime;
			if (val2.Hours < 1)
			{
				return Operators.CompareString(ModBase.GetFileMD5(text), hash, false) == 0;
			}
		}
		return false;
	}

	private string GetChannelName(UpdateChannel channel, UpdateArch arch)
	{
		string empty = string.Empty;
		empty = channel switch
		{
			UpdateChannel.stable => empty + "sr", 
			UpdateChannel.beta => empty + "fr", 
			_ => empty + "sr", 
		};
		return arch switch
		{
			UpdateArch.x64 => empty + "x64", 
			UpdateArch.arm64 => empty + "arm64", 
			_ => empty + "x64", 
		};
	}

	public List<ModLoader.LoaderBase> GetDownloadLoader(UpdateChannel channel, UpdateArch arch, string output)
	{
		_Closure_0024__16_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__16_002D0();
		CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_channel = channel;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_arch = arch;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_output = output;
		if (_remoteCache == null)
		{
			RefreshCache();
		}
		List<ModLoader.LoaderBase> obj = new List<ModLoader.LoaderBase>();
		CS_0024_003C_003E8__locals0._0024VB_0024Local_patchUpdate = true;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_tempPath = $"{ModBase.PathTemp}Cache\\Update\\Download\\";
		obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, List<ModNet.NetFile>>("获取版本信息", [SpecialName] (ModLoader.LoaderTask<int, List<ModNet.NetFile>> load) =>
		{
			string channelName = CS_0024_003C_003E8__locals0._0024VB_0024Me.GetChannelName(CS_0024_003C_003E8__locals0._0024VB_0024Local_channel, CS_0024_003C_003E8__locals0._0024VB_0024Local_arch);
			JToken remoteInfoByName = CS_0024_003C_003E8__locals0._0024VB_0024Me.GetRemoteInfoByName($"updates-{channelName}", "updates/");
			MinioUpdateAsset minioUpdateAsset = ((remoteInfoByName != null) ? Enumerable.FirstOrDefault<MinioUpdateAsset>((System.Collections.Generic.IEnumerable<MinioUpdateAsset>)remoteInfoByName.ToObject<MinioUpdateModel>().assets) : null);
			if (minioUpdateAsset == null)
			{
				throw new System.Exception("No assets can download!");
			}
			string fileSHA = ModBase.GetFileSHA256(ModBase.ExePathWithName);
			string sha = minioUpdateAsset.sha256;
			string text = $"{fileSHA}_{sha}.patch";
			if (minioUpdateAsset.patches.Contains(text))
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_patchUpdate = true;
				CS_0024_003C_003E8__locals0._0024VB_0024Local_tempPath += text;
				List<ModNet.NetFile> val = new List<ModNet.NetFile>();
				val.Add(new ModNet.NetFile(new string[] { $"{CS_0024_003C_003E8__locals0._0024VB_0024Me._baseUrl}static/patch/{text}" }, CS_0024_003C_003E8__locals0._0024VB_0024Local_tempPath));
				load.Output = val;
			}
			else
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_patchUpdate = false;
				CS_0024_003C_003E8__locals0._0024VB_0024Local_tempPath += $"{minioUpdateAsset.sha256}.bin";
				List<ModNet.NetFile> obj2 = new List<ModNet.NetFile>();
				obj2.Add(new ModNet.NetFile((System.Collections.Generic.IEnumerable<string>)RandomUtils.Shuffle((System.Collections.Generic.IList<string>)minioUpdateAsset.downloads), CS_0024_003C_003E8__locals0._0024VB_0024Local_tempPath));
				load.Output = obj2;
			}
		}, null, (ThreadPriority)2));
		obj.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载文件", new List<ModNet.NetFile>()));
		obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<string, int>("应用文件", [SpecialName] (ModLoader.LoaderTask<string, int> a0) =>
		{
			CS_0024_003C_003E8__locals0._Lambda_0024__1();
		}, null, (ThreadPriority)2));
		return obj;
	}

	List<ModLoader.LoaderBase> IUpdateSource.GetDownloadLoader(UpdateChannel channel, UpdateArch arch, string output)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDownloadLoader
		return this.GetDownloadLoader(channel, arch, output);
	}
}
