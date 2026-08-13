using Microsoft.VisualBasic;

namespace PCL;

public class ValidateNullOrWhiteSpace : Validate
{
	public override string ValidateText(string Str)
	{
		if (Information.IsNothing((object)Str) || string.IsNullOrWhiteSpace(Str))
		{
			return "输入内容不能为空！";
		}
		return "";
	}
}
