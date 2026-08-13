using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace PCL;

public class ValidateHttpOrUnc : Validate
{
	[field: CompilerGenerated]
	public bool AllowsNullOrEmpty
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public ValidateHttpOrUnc()
	{
		AllowsNullOrEmpty = false;
	}

	public ValidateHttpOrUnc(bool AllowsNullOrEmpty = false)
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
		if (ModBase.EndsWithF(Str, "/") || ModBase.EndsWithF(Str, "\\"))
		{
			Str = Str.Substring(0, checked(Str.Length - 1));
		}
		if (!ModBase.RegexCheck(Str, "^(http[s]?)\\://", (RegexOptions)0) && !ModBase.StartsWithF(Str, "\\\\"))
		{
			return "输入的网址无效！";
		}
		return "";
	}
}
