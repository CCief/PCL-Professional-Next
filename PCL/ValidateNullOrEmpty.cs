using Microsoft.VisualBasic;

namespace PCL;

public class ValidateNullOrEmpty : Validate
{
	public override string ValidateText(string Str)
	{
		if (Information.IsNothing((object)Str) || string.IsNullOrEmpty(Str))
		{
			return "输入内容不能为空！";
		}
		return "";
	}
}
