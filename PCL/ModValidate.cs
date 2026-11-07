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
			// 无校验规则时应视为「校验通过」，不能把输入文本本身当作错误提示返回。
			// 早期 IL 注入把此处改成 return Text，导致任何未带规则的输入框
			// 把用户输入原样显示在错误行上、并禁用确定按钮。
			return "";
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
