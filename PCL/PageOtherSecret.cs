using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[StandardModule]
internal sealed class PageOtherSecret
{
	private static string StrFill(string str, string code, int length)
	{
		if (str.Length > length)
		{
			return str.Substring(0, length);
		}
		checked
		{
			int num = length - str.Length;
			string text = "";
			int num2 = num - 1;
			for (int i = 0; i <= num2; i++)
			{
				text += code;
			}
			return text + str;
		}
	}

	private static string SecretKeyGet(string key)
	{
		if (string.IsNullOrEmpty(key))
		{
			return "@;$ Abv2";
		}
		return StrFill(ModBase.GetHash(key).ToString(), "X", 8).Substring(0, 8);
	}

	public static string DesEncrypt(string plain, string identify)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		string result;
		try
		{
			string text = SecretKeyGet("PCL" + identify);
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			byte[] bytes2 = Encoding.UTF8.GetBytes("95168702");
			DES val = DES.Create();
			try
			{
				val.Key = bytes;
				((SymmetricAlgorithm)val).IV = bytes2;
				((SymmetricAlgorithm)val).Mode = (CipherMode)1;
				((SymmetricAlgorithm)val).Padding = (PaddingMode)2;
				MemoryStream val2 = new MemoryStream();
				try
				{
					CryptoStream val3 = new CryptoStream((Stream)(object)val2, ((SymmetricAlgorithm)val).CreateEncryptor(), (CryptoStreamMode)1);
					try
					{
						byte[] bytes3 = Encoding.UTF8.GetBytes(plain);
						val3.Write(bytes3, 0, bytes3.Length);
						val3.FlushFinalBlock();
						result = Convert.ToBase64String(val2.ToArray());
					}
					finally
					{
						((System.IDisposable)val3)?.Dispose();
					}
				}
				finally
				{
					((System.IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "DES 加密失败", ModBase.LogLevel.Hint);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}
}
