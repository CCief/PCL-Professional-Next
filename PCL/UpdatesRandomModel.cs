using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Core.Utils;

namespace PCL;

public class UpdatesRandomModel : IUpdateSource
{
	private System.Collections.Generic.IEnumerable<IUpdateSource> _sources;

	private int _randIndex;

	public string SourceName
	{
		get
		{
			return Enumerable.ElementAt<IUpdateSource>(_sources, _randIndex).SourceName;
		}
		set
		{
			Enumerable.ElementAt<IUpdateSource>(_sources, _randIndex).SourceName = value;
		}
	}

	public UpdatesRandomModel(System.Collections.Generic.IEnumerable<IUpdateSource> Sources)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		_sources = Sources;
		Random val = new Random(System.DateTime.Now.Millisecond);
		_randIndex = val.Next(0, checked(Enumerable.Count<IUpdateSource>(_sources) - 1));
	}

	public bool IsAvailable()
	{
		return Enumerable.ElementAt<IUpdateSource>(_sources, _randIndex).IsAvailable();
	}

	bool IUpdateSource.IsAvailable()
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsAvailable
		return this.IsAvailable();
	}

	public bool RefreshCache()
	{
		return Enumerable.ElementAt<IUpdateSource>(_sources, _randIndex).RefreshCache();
	}

	bool IUpdateSource.RefreshCache()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RefreshCache
		return this.RefreshCache();
	}

	public VersionDataModel GetLatestVersion(UpdateChannel channel, UpdateArch arch)
	{
		return Enumerable.ElementAt<IUpdateSource>(_sources, _randIndex).GetLatestVersion(channel, arch);
	}

	VersionDataModel IUpdateSource.GetLatestVersion(UpdateChannel channel, UpdateArch arch)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetLatestVersion
		return this.GetLatestVersion(channel, arch);
	}

	public bool IsLatest(UpdateChannel channel, UpdateArch arch, SemVer currentVersion, int currentVersionCode)
	{
		return Enumerable.ElementAt<IUpdateSource>(_sources, _randIndex).IsLatest(channel, arch, currentVersion, currentVersionCode);
	}

	bool IUpdateSource.IsLatest(UpdateChannel channel, UpdateArch arch, SemVer currentVersion, int currentVersionCode)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsLatest
		return this.IsLatest(channel, arch, currentVersion, currentVersionCode);
	}

	public VersionAnnouncementDataModel GetAnnouncementList()
	{
		return Enumerable.ElementAt<IUpdateSource>(_sources, _randIndex).GetAnnouncementList();
	}

	VersionAnnouncementDataModel IUpdateSource.GetAnnouncementList()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnnouncementList
		return this.GetAnnouncementList();
	}

	public List<ModLoader.LoaderBase> GetDownloadLoader(UpdateChannel channel, UpdateArch arch, string output)
	{
		return Enumerable.ElementAt<IUpdateSource>(_sources, _randIndex).GetDownloadLoader(channel, arch, output);
	}

	List<ModLoader.LoaderBase> IUpdateSource.GetDownloadLoader(UpdateChannel channel, UpdateArch arch, string output)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDownloadLoader
		return this.GetDownloadLoader(channel, arch, output);
	}
}
