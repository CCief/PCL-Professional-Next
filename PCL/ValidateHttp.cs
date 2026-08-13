using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace PCL;

public class ValidateHttp : Validate
{
	[field: CompilerGenerated]
	public bool AllowsNullOrEmpty
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public ValidateHttp()
	{
		AllowsNullOrEmpty = false;
	}

	public ValidateHttp(bool AllowsNullOrEmpty = false)
	{
		this.AllowsNullOrEmpty = false;
		this.AllowsNullOrEmpty = AllowsNullOrEmpty;
	}

	public override string ValidateText(string Str)
	{
		if (AllowsNullOrEmpty && string.IsNullOrEmpty(Str))
		{
			return "";
		}
		if (ModBase.EndsWithF(Str, "/"))
		{
			Str = Str.Substring(0, checked(Str.Length - 1));
		}
		if (!ModBase.RegexCheck(Str, "^(http[s]?)\\://", (RegexOptions)0))
		{
			return "输入的网址无效！";
		}
		return "";
	}
}
