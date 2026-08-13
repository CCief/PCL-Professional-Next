using System.Runtime.CompilerServices;

namespace PCL;

public class ExportOption
{
	[field: CompilerGenerated]
	public string Title
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
	public string Rules
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public string ShowRules
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public bool DefaultChecked
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public bool RequireModLoader
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public bool RequireOptiFine
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public bool RequireModLoaderOrOptiFine
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public ExportOption()
	{
		RequireModLoader = false;
		RequireOptiFine = false;
		RequireModLoaderOrOptiFine = false;
	}
}
