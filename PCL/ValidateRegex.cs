using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace PCL;

public class ValidateRegex : Validate
{
	[field: CompilerGenerated]
	public string Regex
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public string ErrorDescription
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public ValidateRegex()
	{
		ErrorDescription = "正则检查失败！";
	}

	public ValidateRegex(string Regex, string ErrorDescription = "正则检查失败！")
	{
		this.ErrorDescription = "正则检查失败！";
		this.Regex = Regex;
		this.ErrorDescription = ErrorDescription;
	}

	public override string ValidateText(string Str)
	{
		if (!ModBase.RegexCheck(Str, Regex, (RegexOptions)0))
		{
			return ErrorDescription;
		}
		return "";
	}
}
