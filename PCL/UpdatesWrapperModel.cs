using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Utils;

namespace PCL;

public class UpdatesWrapperModel : IUpdateSource
{
	private System.Collections.Generic.IEnumerable<IUpdateSource> _sources;

	private IUpdateSource _versionSource;

	private IUpdateSource _announcementSource;

	public string SourceName
	{
		get
		{
			return _versionSource?.SourceName ?? "";
		}
		set
		{
			if (_versionSource != null)
			{
				_versionSource.SourceName = value;
			}
		}
	}

	public UpdatesWrapperModel(System.Collections.Generic.IEnumerable<IUpdateSource> sources)
	{
		_sources = sources;
	}

	public bool IsAvailable()
	{
		return Enumerable.Any<IUpdateSource>(_sources, (Func<IUpdateSource, bool>)([SpecialName] (IUpdateSource x) => x.IsAvailable()));
	}

	bool IUpdateSource.IsAvailable()
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsAvailable
		return this.IsAvailable();
	}

	public bool RefreshCache()
	{
		System.Collections.Generic.IEnumerator<IUpdateSource> enumerator = default(System.Collections.Generic.IEnumerator<IUpdateSource>);
		try
		{
			enumerator = _sources.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				IUpdateSource current = enumerator.Current;
				try
				{
					current.RefreshCache();
					_versionSource = current;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, $"[Update] {current.SourceName} 暂不可用");
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
		return _versionSource != null;
	}

	bool IUpdateSource.RefreshCache()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RefreshCache
		return this.RefreshCache();
	}

	public VersionDataModel GetLatestVersion(UpdateChannel channel, UpdateArch arch)
	{
		System.Collections.Generic.IEnumerator<IUpdateSource> enumerator = default(System.Collections.Generic.IEnumerator<IUpdateSource>);
		try
		{
			enumerator = _sources.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				IUpdateSource current = enumerator.Current;
				try
				{
					if (_versionSource != null)
					{
						try
						{
							return _versionSource.GetLatestVersion(channel, arch);
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							ModBase.Log(ex2, $"[Update] 缓存的版本源 {_versionSource.SourceName} 不可用");
							ProjectData.ClearProjectError();
						}
					}
					VersionDataModel latestVersion = current.GetLatestVersion(channel, arch);
					_versionSource = current;
					return latestVersion;
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, $"[Update] {current.SourceName} 无法获取最新版本信息");
					ProjectData.ClearProjectError();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		ModBase.Log("[Update] 错误！所有的版本源都无法使用！");
		throw new System.Exception("获取版本信息失败");
	}

	VersionDataModel IUpdateSource.GetLatestVersion(UpdateChannel channel, UpdateArch arch)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetLatestVersion
		return this.GetLatestVersion(channel, arch);
	}

	public bool IsLatest(UpdateChannel channel, UpdateArch arch, SemVer currentVersion, int currentVersionCode)
	{
		System.Collections.Generic.IEnumerator<IUpdateSource> enumerator = default(System.Collections.Generic.IEnumerator<IUpdateSource>);
		try
		{
			enumerator = _sources.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				IUpdateSource current = enumerator.Current;
				try
				{
					if (_versionSource != null)
					{
						try
						{
							return _versionSource.IsLatest(channel, arch, currentVersion, currentVersionCode);
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							ModBase.Log(ex2, $"[Update] 缓存的版本源 {_versionSource.SourceName} 不可用");
							ProjectData.ClearProjectError();
						}
					}
					bool result = current.IsLatest(channel, arch, currentVersion, currentVersionCode);
					_versionSource = current;
					return result;
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, $"[Update] {current.SourceName} 无法获取最新版本信息");
					ProjectData.ClearProjectError();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		ModBase.Log("[Update] 错误！所有的版本源都无法使用！");
		throw new System.Exception("获取版本信息失败");
	}

	bool IUpdateSource.IsLatest(UpdateChannel channel, UpdateArch arch, SemVer currentVersion, int currentVersionCode)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsLatest
		return this.IsLatest(channel, arch, currentVersion, currentVersionCode);
	}

	public VersionAnnouncementDataModel GetAnnouncementList()
	{
		System.Collections.Generic.IEnumerator<IUpdateSource> enumerator = default(System.Collections.Generic.IEnumerator<IUpdateSource>);
		try
		{
			enumerator = _sources.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				IUpdateSource current = enumerator.Current;
				try
				{
					if (_announcementSource != null)
					{
						try
						{
							return _announcementSource.GetAnnouncementList();
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							ModBase.Log(ex2, $"[Update] 缓存的公告源 {_announcementSource.SourceName} 不可用");
							ProjectData.ClearProjectError();
						}
					}
					VersionAnnouncementDataModel announcementList = current.GetAnnouncementList();
					_announcementSource = current;
					return announcementList;
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, $"[Update] {current.SourceName} 无法获取最新公告信息");
					ProjectData.ClearProjectError();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		ModBase.Log("[Update] 错误！所有的公告源都无法使用！");
		throw new System.Exception("获取公告信息失败");
	}

	VersionAnnouncementDataModel IUpdateSource.GetAnnouncementList()
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetAnnouncementList
		return this.GetAnnouncementList();
	}

	public List<ModLoader.LoaderBase> GetDownloadLoader(UpdateChannel channel, UpdateArch arch, string output)
	{
		System.Collections.Generic.IEnumerator<IUpdateSource> enumerator = default(System.Collections.Generic.IEnumerator<IUpdateSource>);
		try
		{
			enumerator = _sources.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				IUpdateSource current = enumerator.Current;
				try
				{
					if (_versionSource != null)
					{
						try
						{
							return _versionSource.GetDownloadLoader(channel, arch, output);
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							ModBase.Log(ex2, $"[Update] 缓存的版本源 {_versionSource.SourceName} 不可用");
							ProjectData.ClearProjectError();
						}
					}
					List<ModLoader.LoaderBase> downloadLoader = current.GetDownloadLoader(channel, arch, output);
					_versionSource = current;
					return downloadLoader;
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, $"[Update] {current.SourceName} 无法获取最新版本信息");
					ProjectData.ClearProjectError();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		ModBase.Log("[Update] 错误！所有的版本源都无法使用！");
		throw new System.Exception("获取版本信息失败");
	}

	List<ModLoader.LoaderBase> IUpdateSource.GetDownloadLoader(UpdateChannel channel, UpdateArch arch, string output)
	{
		//ILSpy generated this explicit interface implementation from .override directive in GetDownloadLoader
		return this.GetDownloadLoader(channel, arch, output);
	}
}
