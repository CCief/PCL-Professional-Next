using System;
using System.IO;
using System.Text;
using fNbt;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Utils;

namespace PCL;

[StandardModule]
public sealed class ModWorld
{
	public class McWorld
	{
		public string SavePath;

		public string VersionName;

		public string VersionId;

		public string LevelDatPath
		{
			get
			{
				if (!File.Exists(SavePath + "level.dat"))
				{
					return SavePath + "level.dat_old";
				}
				return SavePath + "level.dat";
			}
		}

		public McWorld(string SavePath)
		{
			if (!ModBase.EndsWithF(SavePath, "\\"))
			{
				SavePath += "\\";
			}
			this.SavePath = SavePath;
		}

		public bool Read()
		{
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			bool result;
			try
			{
				ModBase.Log($"[World] 读取存档：{SavePath}");
				if (!File.Exists(LevelDatPath))
				{
					ModBase.Log("[World] 存档没有 level.dat 文件，读取失败");
					result = false;
				}
				else
				{
					FileStream val = new FileStream(LevelDatPath, (FileMode)3, (FileAccess)1, (FileShare)1);
					try
					{
						NbtFile val2 = new NbtFile();
						val2.LoadFromStream((Stream)(object)val, (NbtCompression)0);
						NbtCompound val3 = val2.RootTag.Get<NbtCompound>("Version");
						if (val3 != null)
						{
							VersionName = val3.Get<NbtString>("Name").Value;
							VersionId = Conversions.ToString(val3.Get<NbtInt>("Id").Value);
							goto end_IL_004e;
						}
						ModBase.Log("[World] Version 标签存在问题，读取失败");
						result = false;
						goto end_IL_0000;
						end_IL_004e:;
					}
					finally
					{
						((System.IDisposable)val)?.Dispose();
					}
					result = true;
				}
				end_IL_0000:;
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "读取存档时出错");
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	public static void ReadWorld(string SavePath)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		if (File.Exists(SavePath))
		{
			string text = $"{ModBase.PathTemp}Cache\\{RandomUtils.NextInt(0, 10000000)}\\";
			if (Directory.Exists(text))
			{
				ModBase.DeleteDirectory(text);
			}
			ModBase.ExtractFile(SavePath, text);
			SavePath = text;
		}
		McWorld mcWorld = new McWorld(SavePath);
		if (!File.Exists(mcWorld.LevelDatPath))
		{
			throw new System.Exception("无效的 Minecraft 存档");
		}
		if (!mcWorld.Read())
		{
			ModMain.Hint("存档文件可能已损坏，无法读取！", ModMain.HintType.Critical);
			throw new ModBase.CancelledException();
		}
		StringBuilder val = new StringBuilder();
		if (mcWorld.VersionName != null)
		{
			val.AppendLine($"存档版本：{mcWorld.VersionName}");
		}
		if (mcWorld.VersionId != null)
		{
			val.AppendLine($"存档数据版本：{mcWorld.VersionId}");
		}
		if (val.Length == 0)
		{
			val.AppendLine("无法获取存档的版本信息，存档版本可能低于 15w32a（对应正式版 1.9）！");
		}
		ModMain.MyMsgBox(val.ToString(), "存档版本信息");
	}
}
