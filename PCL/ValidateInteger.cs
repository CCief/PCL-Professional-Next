using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class ValidateInteger : Validate
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

	public ValidateInteger()
	{
		Max = 2147483647;
	}

	public ValidateInteger(int Min, int Max)
	{
		this.Max = 2147483647;
		this.Min = Min;
		this.Max = Max;
	}

	public override string ValidateText(string Str)
	{
		if (Str.Length > 9)
		{
			return "请输入一个大小合理的数字！";
		}
		if (Operators.CompareString(checked((int)Math.Round(ModBase.Val(Str))).ToString(), Str, false) != 0)
		{
			return "请输入一个整数！";
		}
		if (ModBase.Val(Str) > (double)Max)
		{
			return "不可超过 " + Conversions.ToString(Max) + "！";
		}
		if (ModBase.Val(Str) < (double)Min)
		{
			return "不可低于 " + Conversions.ToString(Min) + "！";
		}
		return "";
	}
}
