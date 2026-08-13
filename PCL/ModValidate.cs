using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[StandardModule]
public sealed class ModValidate
{
	public static string Validate(string Text, System.Collections.Generic.IEnumerable<Validate> ValidateRules)
	{
		if (ValidateRules == null)
		{
			return Text;
		}
		string text = "";
		System.Collections.Generic.IEnumerator<Validate> enumerator = default(System.Collections.Generic.IEnumerator<Validate>);
		try
		{
			enumerator = ValidateRules.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				text = enumerator.Current.ValidateText(Text);
				if (text == null)
				{
					return "";
				}
				if (Operators.CompareString(text, "", false) != 0)
				{
					return text;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		return text;
	}
}
