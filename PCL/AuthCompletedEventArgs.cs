using System;
using System.Runtime.CompilerServices;

namespace PCL;

public class AuthCompletedEventArgs : EventArgs
{
	[field: CompilerGenerated]
	public bool Success
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public string Cookies
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public string FinalUrl
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public string Token
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}
}
