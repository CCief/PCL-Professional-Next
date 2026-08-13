using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class ValidateExceptSame : Validate
{
	[field: CompilerGenerated]
	public Collection<string> Excepts
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public string ErrorMessage
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

	public ValidateExceptSame()
	{
		Excepts = new Collection<string>();
		IgnoreCase = false;
	}

	public ValidateExceptSame(Collection<string> Excepts, string ErrorMessage = "输入内容不能为 %", bool IgnoreCase = false)
	{
		this.Excepts = new Collection<string>();
		this.IgnoreCase = false;
		this.Excepts = Excepts;
		this.ErrorMessage = ErrorMessage;
		this.IgnoreCase = IgnoreCase;
	}

	public ValidateExceptSame(System.Collections.IEnumerable Excepts, string ErrorMessage = "输入内容不能为 %", bool IgnoreCase = false)
	{
		this.Excepts = new Collection<string>();
		this.IgnoreCase = false;
		this.Excepts = new Collection<string>();
		foreach (object Except in Excepts)
		{
			string text = Conversions.ToString(Except);
			this.Excepts.Add(text);
		}
		this.ErrorMessage = ErrorMessage;
		this.IgnoreCase = IgnoreCase;
	}

	public override string ValidateText(string Str)
	{
		if (Str == null)
		{
			return ErrorMessage.Replace("%", "null");
		}
		System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator = Excepts.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				string current = enumerator.Current;
				if (IgnoreCase)
				{
					if (Operators.CompareString(Str.ToLower(), current.ToLower(), false) == 0)
					{
						return ErrorMessage.Replace("%", current);
					}
				}
				else if (Str.Equals(current))
				{
					return ErrorMessage.Replace("%", current);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		return "";
	}
}
