using System.Runtime.CompilerServices;

namespace PCL;

public class MinecraftServerInfo
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
	public string Address
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public int Port
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public ServerStatus Status
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public int PlayerCount
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public int MaxPlayers
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public string Description
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public string Version
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public int Ping
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public string Icon
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public MinecraftServerInfo()
	{
		Port = 25565;
		Status = ServerStatus.Unknown;
		PlayerCount = 0;
		MaxPlayers = 0;
		Description = "";
		Version = "";
		Ping = 0;
		Icon = "";
	}
}
