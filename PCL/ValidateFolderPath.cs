using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;

namespace PCL;

public class ValidateFolderPath : Validate
{
	[field: CompilerGenerated]
	public bool UseMinecraftCharCheck
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public ValidateFolderPath()
	{
		UseMinecraftCharCheck = true;
	}

	public ValidateFolderPath(bool UseMinecraftCharCheck)
	{
		this.UseMinecraftCharCheck = true;
		this.UseMinecraftCharCheck = UseMinecraftCharCheck;
	}

	public override string ValidateText(string Str)
	{
		Str = Str.Replace("/", "\\");
		if (!ModBase.EndsWithF(Str.TrimEnd('\\'), ":"))
		{
			Str = Str.TrimEnd('\\');
		}
		string text = new ValidateNullOrWhiteSpace().ValidateText(Str);
		if (Operators.CompareString(text, "", false) != 0)
		{
			return text;
		}
		text = new ValidateLength(1, 254).ValidateText(Str);
		if (Operators.CompareString(text, "", false) != 0)
		{
			return text;
		}
		if (!ModBase.StartsWithF(Str, "\\\\Mac\\"))
		{
			System.Collections.Generic.IEnumerator<DriveInfo> enumerator = default(System.Collections.Generic.IEnumerator<DriveInfo>);
			try
			{
				enumerator = FileSystem.Drives.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					DriveInfo current = enumerator.Current;
					if (Operators.CompareString(Str.ToUpper(), current.Name, false) == 0)
					{
						return "";
					}
					if (!ModBase.StartsWithF(Str, current.Name, IgnoreCase: true))
					{
						continue;
					}
					goto IL_00eb;
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			return "文件夹路径头存在错误！";
		}
		goto IL_00eb;
		IL_00eb:
		int num = ((!ModBase.StartsWithF(Str, "\\\\Mac\\")) ? 1 : 2);
		checked
		{
			int num2 = Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)Str.Split("\\", (StringSplitOptions)0)) - 1;
			for (int i = num; i <= num2; i++)
			{
				string str = Str.Split("\\", (StringSplitOptions)0)[i];
				if (Operators.CompareString(new ValidateNullOrWhiteSpace().ValidateText(str), "", false) != 0)
				{
					return "文件夹路径存在错误！";
				}
				string text2 = new ValidateExcept((System.Collections.IEnumerable)(new string(System.IO.Path.GetInvalidFileNameChars()) + (UseMinecraftCharCheck ? "!;" : "")), "路径中存在无效字符！").ValidateText(str);
				if (Operators.CompareString(text2, "", false) != 0)
				{
					return text2;
				}
				if (ModBase.StartsWithF(str, " "))
				{
					return "文件夹名不能以空格开头！";
				}
				if (ModBase.EndsWithF(str, " "))
				{
					return "文件夹名不能以空格结尾！";
				}
				if (ModBase.EndsWithF(str, "."))
				{
					return "文件夹名不能以小数点结尾！";
				}
				string text3 = new ValidateExceptSame((System.Collections.IEnumerable)(object)new string[25]
				{
					"CON", "PRN", "AUX", "CLOCK$", "NUL", "COM0", "COM1", "COM2", "COM3", "COM4",
					"COM5", "COM6", "COM7", "COM8", "COM9", "LPT0", "LPT1", "LPT2", "LPT3", "LPT4",
					"LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
				}, "文件夹名不可为 %！").ValidateText(str);
				if (Operators.CompareString(text3, "", false) != 0)
				{
					return text3;
				}
				if (ModBase.RegexCheck(Str, ".{2,}~\\d", (RegexOptions)0))
				{
					return "文件夹名不能包含这一特殊格式！";
				}
			}
			return "";
		}
	}
}
