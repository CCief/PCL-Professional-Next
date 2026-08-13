using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class ValidateFolderName : Validate
{
	private readonly System.Collections.Generic.IEnumerable<DirectoryInfo> PathIgnore;

	private bool IsIgnoreSameName;

	[field: CompilerGenerated]
	public string Path
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

	public ValidateFolderName()
	{
		UseMinecraftCharCheck = true;
		IgnoreCase = true;
		IsIgnoreSameName = false;
	}

	public ValidateFolderName(string Path, bool UseMinecraftCharCheck = true, bool IgnoreCase = true, bool IgnoreSameName = false)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		this.UseMinecraftCharCheck = true;
		this.IgnoreCase = true;
		IsIgnoreSameName = false;
		this.Path = Path;
		this.IgnoreCase = IgnoreCase;
		this.UseMinecraftCharCheck = UseMinecraftCharCheck;
		PathIgnore = new DirectoryInfo(Path).EnumerateDirectories();
		IsIgnoreSameName = IgnoreSameName;
	}

	public override string ValidateText(string Str)
	{
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
				result = "文件夹名不能以空格开头！";
			}
			else if (ModBase.EndsWithF(Str, " "))
			{
				result = "文件夹名不能以空格结尾！";
			}
			else
			{
				text = new ValidateLength(1, 100).ValidateText(Str);
				if (Operators.CompareString(text, "", false) != 0)
				{
					result = text;
				}
				else if (ModBase.EndsWithF(Str, "."))
				{
					result = "文件夹名不能以小数点结尾！";
				}
				else
				{
					string text2 = new ValidateExcept((System.Collections.IEnumerable)(new string(System.IO.Path.GetInvalidFileNameChars()) + (UseMinecraftCharCheck ? "!;" : "")), "文件夹名不可包含 % 字符！").ValidateText(Str);
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
						}, "文件夹名不可为 %！", IgnoreCase: true).ValidateText(Str);
						if (Operators.CompareString(text3, "", false) != 0)
						{
							result = text3;
						}
						else if (ModBase.RegexCheck(Str, ".{2,}~\\d", (RegexOptions)0))
						{
							result = "文件夹名不能包含这一特殊格式！";
						}
						else
						{
							List<string> val = new List<string>();
							if (PathIgnore != null)
							{
								System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
								try
								{
									enumerator = PathIgnore.GetEnumerator();
									while (((System.Collections.IEnumerator)enumerator).MoveNext())
									{
										DirectoryInfo current = enumerator.Current;
										val.Add(current.Name);
									}
								}
								finally
								{
									((System.IDisposable)enumerator)?.Dispose();
								}
							}
							if (IsIgnoreSameName)
							{
								goto IL_027a;
							}
							string text4 = new ValidateExceptSame((System.Collections.IEnumerable)val, "不可与现有文件夹重名！", IgnoreCase).ValidateText(Str);
							if (Operators.CompareString(text4, "", false) == 0)
							{
								goto IL_027a;
							}
							result = text4;
						}
					}
				}
			}
			goto end_IL_0000;
			IL_027a:
			result = "";
			end_IL_0000:;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "检查文件夹名出错");
			result = "错误：" + ex2.Message;
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
