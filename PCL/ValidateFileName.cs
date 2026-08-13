using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class ValidateFileName : Validate
{
	[CompilerGenerated]
	private object _RequireParentFolderExists;

	[field: CompilerGenerated]
	public string Name
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public bool UseMinecraftCharCheck
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public bool IgnoreCase
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public string ParentFolder
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public object RequireParentFolderExists
	{
		[CompilerGenerated]
		get
		{
			return _RequireParentFolderExists;
		}
		[CompilerGenerated]
		set
		{
			_RequireParentFolderExists = RuntimeHelpers.GetObjectValue(value);
		}
	}

	public ValidateFileName()
	{
		UseMinecraftCharCheck = true;
		IgnoreCase = true;
		ParentFolder = null;
		RequireParentFolderExists = true;
	}

	public ValidateFileName(string Name, bool UseMinecraftCharCheck = true, bool IgnoreCase = true)
	{
		this.UseMinecraftCharCheck = true;
		this.IgnoreCase = true;
		ParentFolder = null;
		RequireParentFolderExists = true;
		this.Name = Name;
		this.IgnoreCase = IgnoreCase;
		this.UseMinecraftCharCheck = UseMinecraftCharCheck;
	}

	public override string ValidateText(string Str)
	{
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Expected O, but got Unknown
		string result;
		try
		{
			string text = new ValidateNullOrWhiteSpace().ValidateText(Str);
			if (Operators.CompareString(text, "", false) != 0)
			{
				result = text;
			}
			else if (ModBase.StartsWithF(Str, " "))
			{
				result = "文件名不能以空格开头！";
			}
			else if (ModBase.EndsWithF(Str, " "))
			{
				result = "文件名不能以空格结尾！";
			}
			else
			{
				text = new ValidateLength(1, 253).ValidateText(Str + ParentFolder);
				if (Operators.CompareString(text, "", false) != 0)
				{
					result = text;
				}
				else if (ModBase.EndsWithF(Str, "."))
				{
					result = "文件名不能以小数点结尾！";
				}
				else
				{
					string text2 = new ValidateExcept((System.Collections.IEnumerable)(new string(System.IO.Path.GetInvalidFileNameChars()) + (UseMinecraftCharCheck ? "!;" : "")), "文件名不可包含 % 字符！").ValidateText(Str);
					if (Operators.CompareString(text2, "", false) != 0)
					{
						result = text2;
					}
					else
					{
						string text3 = new ValidateExceptSame((System.Collections.IEnumerable)(object)new string[25]
						{
							"CON", "PRN", "AUX", "CLOCK$", "NUL", "COM0", "COM1", "COM2", "COM3", "COM4",
							"COM5", "COM6", "COM7", "COM8", "COM9", "LPT0", "LPT1", "LPT2", "LPT3", "LPT4",
							"LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
						}, "文件名不可为 %！", IgnoreCase: true).ValidateText(Str);
						if (Operators.CompareString(text3, "", false) != 0)
						{
							result = text3;
						}
						else if (ModBase.RegexCheck(Str, ".{2,}~\\d", (RegexOptions)0))
						{
							result = "文件名不能包含这一特殊格式！";
						}
						else
						{
							if (ParentFolder == null)
							{
								goto IL_02a8;
							}
							DirectoryInfo val = new DirectoryInfo(ParentFolder);
							if (val.Exists)
							{
								string text4 = new ValidateExceptSame((System.Collections.IEnumerable)Enumerable.Select<FileInfo, string>(val.EnumerateFiles("*"), (Func<FileInfo, string>)([SpecialName] (FileInfo f) => f.Name)), "不可与现有文件重名！", IgnoreCase).ValidateText(Str);
								if (Operators.CompareString(text4, "", false) == 0)
								{
									goto IL_02a8;
								}
								result = text4;
							}
							else
							{
								if (!Conversions.ToBoolean(RequireParentFolderExists))
								{
									goto IL_02a8;
								}
								result = $"父文件夹不存在：{ParentFolder}";
							}
						}
					}
				}
			}
			goto end_IL_0000;
			IL_02a8:
			result = "";
			end_IL_0000:;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "检查文件名出错");
			result = "错误：" + ex2.Message;
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
