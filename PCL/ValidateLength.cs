using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace PCL;

public class ValidateLength : Validate
{
	[field: CompilerGenerated]
	public int Min
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public int Max
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public ValidateLength()
	{
		Min = 0;
		Max = 2147483647;
	}

	public ValidateLength(int Min, int Max = 2147483647)
	{
		this.Min = 0;
		this.Max = 2147483647;
		this.Min = Min;
		this.Max = Max;
	}

	public override string ValidateText(string Str)
	{
		if (Strings.Len(Str) != Max && Max == Min)
		{
			return $"长度必须为 {Max} 个字符！";
		}
		if (Strings.Len(Str) > Max)
		{
			return $"长度最长为 {Max} 个字符！";
		}
		if (Strings.Len(Str) < Min)
		{
			return $"长度至少需 {Min} 个字符！";
		}
		return "";
	}
}
