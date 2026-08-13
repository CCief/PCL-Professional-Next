using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.Core.Utils;

namespace PCL;

public class UpdatesMirrorChyanModel : IUpdateSource
{
	private const string MirrorChyanBaseUrl = "https://mirrorchyan.com/api/resources/{cid}/latest?cdk={cdk}&os=win&arch={arch}&channel={channel}";

	private const string MyCid = "PCL2-CE";

	[field: CompilerGenerated]
	public string SourceName
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public UpdatesMirrorChyanModel()
	{
		SourceName = "MirrorChyan";
	}

	public bool IsAvailable()
	{
		return !string.IsNullOrWhiteSpace(Conversions.ToString(ModBase.Setup.Get("SystemMirrorChyanKey")));
	}

	bool IUpdateSource.IsAvailable()
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsAvailable
		return this.IsAvailable();
	}

	public VersionDataModel GetLatestVersion(UpdateChannel channel, UpdateArch arch)
	{
		JObject obj = (JObject)ModNet.NetGetCodeByRequestRetry(GetUrl(channel, arch), null, "", IsJson: true);
		if ((int)obj["code"] != 0)
		{
			throw new System.Exception("Mirror 酱获取数据不成功");
		}
		JToken jToken = obj["data"];
		string text = jToken["url"]?.ToString();
		if (jToken != null && string.IsNullOrWhiteSpace(text))
		{
			throw new System.Exception("无效 CDK");
		}
		return new VersionDataModel
		{
			Source = SourceName,
			VersionCode = (int)jToken["version_number"],
			VersionName = (string?)jToken["version_name"],
			SHA256 = (string?)jToken["sha256"],
			Changelog = (string?)jToken["release_note"]
		};
	}

	VersionDataModel IUpdateSource.GetLatestVersion(UpdateChannel channel, UpdateArch arch)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetLatestVersion
		return this.GetLatestVersion(channel, arch);
	}

	public bool RefreshCache()
	{
		return true;
	}

	bool IUpdateSource.RefreshCache()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RefreshCache
		return this.RefreshCache();
	}

	public bool IsLatest(UpdateChannel channel, UpdateArch arch, SemVer currentVersion, int currentVersionCode)
	{
		VersionDataModel latestVersion = GetLatestVersion(channel, arch);
		return currentVersion >= SemVer.Parse(latestVersion.VersionName);
	}

	bool IUpdateSource.IsLatest(UpdateChannel channel, UpdateArch arch, SemVer currentVersion, int currentVersionCode)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsLatest
		return this.IsLatest(channel, arch, currentVersion, currentVersionCode);
	}

	public VersionAnnouncementDataModel GetAnnouncementList()
	{
		throw new System.Exception("Mirror 酱无公告系统");
	}

	VersionAnnouncementDataModel IUpdateSource.GetAnnouncementList()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnnouncementList
		return this.GetAnnouncementList();
	}

	public List<ModLoader.LoaderBase> GetDownloadLoader(UpdateChannel channel, UpdateArch arch, string output)
	{
		List<ModLoader.LoaderBase> obj = new List<ModLoader.LoaderBase>();
		obj.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, List<ModNet.NetFile>>("获取下载信息", [SpecialName] (ModLoader.LoaderTask<int, List<ModNet.NetFile>> load) =>
		{
			JObject jObject = (JObject)ModNet.NetGetCodeByRequestRetry(GetUrl(channel, arch), null, "", IsJson: true);
			string text = jObject["data"]["url"]?.ToString();
			if (text == null)
			{
				throw new System.Exception("Mirror 酱下载源不可用");
			}
			List<ModNet.NetFile> val = new List<ModNet.NetFile>();
			val.Add(new ModNet.NetFile(new string[] { text }, output));
			load.Output = val;
		}, null, (ThreadPriority)2));
		obj.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载更新文件", new List<ModNet.NetFile>()));
		return obj;
	}

	List<ModLoader.LoaderBase> IUpdateSource.GetDownloadLoader(UpdateChannel channel, UpdateArch arch, string output)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDownloadLoader
		return this.GetDownloadLoader(channel, arch, output);
	}

	private string GetUrl(UpdateChannel channel, UpdateArch arch)
	{
		string text = Conversions.ToString(ModBase.Setup.Get("SystemMirrorChyanKey"));
		return "https://mirrorchyan.com/api/resources/{cid}/latest?cdk={cdk}&os=win&arch={arch}&channel={channel}".Replace("{cid}", "PCL2-CE").Replace("{cdk}", text).Replace("{arch}", ((System.Enum)arch).ToString())
			.Replace("{channel}", ((System.Enum)channel).ToString());
	}
}
