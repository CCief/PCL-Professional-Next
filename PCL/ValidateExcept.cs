using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class ValidateExcept : Validate
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

	public ValidateExcept()
	{
		Excepts = new Collection<string>();
		ErrorMessage = "输入内容不能包含 %";
	}

	public ValidateExcept(Collection<string> Excepts, string ErrorMessage = "输入内容不能包含 %")
	{
		this.Excepts = new Collection<string>();
		this.Excepts = Excepts;
		this.ErrorMessage = ErrorMessage;
	}

	public ValidateExcept(System.Collections.IEnumerable Excepts, string ErrorMessage = "输入内容不能包含 %")
	{
		this.Excepts = new Collection<string>();
		this.Excepts = new Collection<string>();
		this.ErrorMessage = ErrorMessage;
		foreach (object Except in Excepts)
		{
			string text = Conversions.ToString(Except);
			this.Excepts.Add(text);
		}
	}

	public override string ValidateText(string Str)
	{
		System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator = Excepts.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				string current = enumerator.Current;
				if (ModBase.IndexOfF(Str, current, IgnoreCase: true) >= 0)
				{
					if (Information.IsNothing((object)ErrorMessage))
					{
						ErrorMessage = "";
					}
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
