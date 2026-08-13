using Microsoft.VisualBasic;

namespace PCL;

public class ValidateNullable : Validate
{
	public override string ValidateText(string Str)
	{
		if (Information.IsNothing((object)Str) || string.IsNullOrEmpty(Str))
		{
			return null;
		}
		return "";
	}
}
