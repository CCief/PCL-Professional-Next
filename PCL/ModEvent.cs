using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[StandardModule]
public sealed class ModEvent
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action _0024I1_002D1;

		public static Action _0024I1_002D2;

		public static Action _0024I1_002D3;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__1_002D1()
		{
			PageOtherTest.MemoryOptimize(ShowHint: true);
		}

		[SpecialName]
		internal void _Lambda_0024__1_002D2()
		{
			PageOtherTest.RubbishClear();
		}

		[SpecialName]
		internal void _Lambda_0024__1_002D3()
		{
			ModModpack.ModpackInstall();
		}
	}

	public static void TryStartEvent(string Type, string Data)
	{
		if (!string.IsNullOrWhiteSpace(Type))
		{
			string[] data = new string[] { "" };
			if (Data != null)
			{
				data = Data.Split("|", (StringSplitOptions)0);
			}
			StartEvent(Type, data);
		}
	}

	public static void StartEvent(string Type, string[] Data)
	{
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_056f: Expected O, but got Unknown
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Expected O, but got Unknown
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b9: Expected O, but got Unknown
		try
		{
			ModBase.Log("[Control] 执行自定义事件：" + Type + ", " + ModBase.Join((System.Collections.IEnumerable)(object)Data, ", "));
			switch (Type)
			{
			case "打开网页":
				Data[0] = Data[0].Replace("\\", "/");
				if (!Data[0].Contains("://") || ModBase.StartsWithF(Data[0], "file", IgnoreCase: true))
				{
					ModMain.MyMsgBox("EventData 必须为一个网址。\r\n如果想要启动程序，请将 EventType 改为 打开文件。", "事件执行失败");
					break;
				}
				ModMain.Hint("正在开启中，请稍候……");
				ModBase.OpenWebsite(Data[0]);
				break;
			case "打开文件":
			case "打开帮助":
			case "执行命令":
				ModBase.RunInThread((Action)([SpecialName] () =>
				{
					//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
					//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
					//IL_0109: Unknown result type (might be due to invalid IL or missing references)
					//IL_0110: Unknown result type (might be due to invalid IL or missing references)
					//IL_0121: Unknown result type (might be due to invalid IL or missing references)
					//IL_012d: Expected O, but got Unknown
					try
					{
						string[] eventAbsoluteUrls = GetEventAbsoluteUrls(Data[0], Type);
						string text = eventAbsoluteUrls[0];
						string text2 = eventAbsoluteUrls[1];
						ModBase.Log($"[Control] 打开类自定义事件实际路径：{text}，工作目录：{text2}");
						if (Operators.CompareString(Type, "打开帮助", false) == 0)
						{
							PageOtherHelp.EnterHelpPage(text);
						}
						else
						{
							if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("HintCustomCommand"))))
							{
								switch (ModMain.MyMsgBox("即将执行：" + text + ((Data.Length >= 2) ? (" " + Data[1]) : "") + "\r\n请在确认该操作没有安全隐患后继续。", "执行确认", "继续", "继续且今后不再要求确认", "取消"))
								{
								case 2:
									ModBase.Setup.Set("HintCustomCommand", true);
									break;
								case 3:
									return;
								}
							}
							Process.Start(new ProcessStartInfo
							{
								Arguments = ((Data.Length >= 2) ? Data[1] : ""),
								FileName = text,
								WorkingDirectory = ModBase.ShortenPath(text2),
								UseShellExecute = true
							});
						}
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						ModBase.Log(ex4, "执行打开类自定义事件失败", ModBase.LogLevel.Msgbox);
						ProjectData.ClearProjectError();
					}
				}));
				break;
			case "启动游戏":
				if (Operators.CompareString(Data[0], "\\current", false) == 0)
				{
					if ((object)ModMinecraft.McInstanceCurrent == null)
					{
						ModMain.Hint("请先选择一个 Minecraft 实例！", ModMain.HintType.Critical);
						break;
					}
					Data[0] = ModMinecraft.McInstanceCurrent.Name;
				}
				if (ModLaunch.McLaunchStart(new ModLaunch.McLaunchOptions
				{
					ServerIp = ((Data.Length >= 2) ? Data[1] : null),
					Version = new ModMinecraft.McInstance(Data[0])
				}))
				{
					ModMain.Hint("正在启动 " + Data[0] + "……");
				}
				break;
			case "复制文本":
				ModBase.ClipboardSet(ModBase.Join((System.Collections.IEnumerable)(object)Data, "|"));
				break;
			case "刷新主页":
				ModMain.FrmLaunchRight.ForceRefresh();
				if (Operators.CompareString(Data[0], "", false) == 0)
				{
					ModMain.Hint("已刷新主页！", ModMain.HintType.Finish);
				}
				break;
			case "刷新帮助":
				PageOtherLeft.RefreshHelp();
				break;
			case "今日人品":
				PageOtherTest.Jrrp();
				break;
			case "内存优化":
			{
				object action;
				if (_Closure_0024__._0024I1_002D1 != null)
				{
					action = _Closure_0024__._0024I1_002D1;
				}
				else
				{
					Action val = [SpecialName] () =>
					{
						PageOtherTest.MemoryOptimize(ShowHint: true);
					};
					_Closure_0024__._0024I1_002D1 = val;
					action = (object)val;
				}
				ModBase.RunInThread((Action)action);
				break;
			}
			case "清理垃圾":
			{
				object action3;
				if (_Closure_0024__._0024I1_002D2 != null)
				{
					action3 = _Closure_0024__._0024I1_002D2;
				}
				else
				{
					Action val3 = [SpecialName] () =>
					{
						PageOtherTest.RubbishClear();
					};
					_Closure_0024__._0024I1_002D2 = val3;
					action3 = (object)val3;
				}
				ModBase.RunInThread((Action)action3);
				break;
			}
			case "弹出窗口":
				ModMain.MyMsgBox(Data[1].Replace("\\n", "\r\n"), Data[0].Replace("\\n", "\r\n"));
				break;
			case "切换页面":
				ModMain.FrmMain.PageChange((FormMain.PageType)checked((int)Math.Round(ModBase.Val(Data[0]))), (FormMain.PageSubType)checked((int)Math.Round(ModBase.Val(Data[1]))));
				break;
			case "导入整合包":
			case "安装整合包":
			{
				object action2;
				if (_Closure_0024__._0024I1_002D3 != null)
				{
					action2 = _Closure_0024__._0024I1_002D3;
				}
				else
				{
					Action val2 = [SpecialName] () =>
					{
						ModModpack.ModpackInstall();
					};
					_Closure_0024__._0024I1_002D3 = val2;
					action2 = (object)val2;
				}
				ModBase.RunInUi((Action)action2);
				break;
			}
			case "下载文件":
				Data[0] = Data[0].Replace("\\", "/");
				if (!ModBase.StartsWithF(Data[0], "http://", IgnoreCase: true) && !ModBase.StartsWithF(Data[0], "https://", IgnoreCase: true))
				{
					ModMain.MyMsgBox("EventData 必须为以 http:// 或 https:// 开头的网址。\r\nPCL 不支持其他乱七八糟的下载协议。", "事件执行失败");
					break;
				}
				try
				{
					switch (Data.Length)
					{
					case 1:
						PageOtherTest.StartCustomDownload(Data[0], ModBase.GetFileNameFromPath(Data[0]));
						break;
					case 2:
						PageOtherTest.StartCustomDownload(Data[0], Data[1]);
						break;
					default:
						PageOtherTest.StartCustomDownload(Data[0], Data[1], Data[2]);
						break;
					}
					break;
				}
				catch (System.Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					PageOtherTest.StartCustomDownload(Data[0], "未知");
					ProjectData.ClearProjectError();
					break;
				}
			default:
				ModMain.MyMsgBox("未知的事件类型：" + Type + "\r\n请检查事件类型填写是否正确，或者 PCL 是否为最新版本。", "事件执行失败");
				break;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "事件执行失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	public static string[] GetEventAbsoluteUrls(string RelativeUrl, string EventType)
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		if (ModBase.StartsWithF(RelativeUrl, "http", IgnoreCase: true))
		{
			if (ModBase.RunInUi())
			{
				throw new System.Exception("能打开联网帮助页面的 MyListItem 必须手动设置 Title、Info 属性！");
			}
			string fileNameFromPath;
			try
			{
				fileNameFromPath = ModBase.GetFileNameFromPath(RelativeUrl);
				if (!ModBase.EndsWithF(fileNameFromPath, ".json", IgnoreCase: true))
				{
					throw new System.Exception("未指向 .json 后缀的文件");
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				throw new System.Exception("联网帮助页面须指向一个帮助 JSON 文件，并在同路径下包含相应 XAML 文件！\r\n例如：\r\n - https://www.baidu.com/test.json（填写这个路径）\r\n - https://www.baidu.com/test.xaml（同时也需要包含这个文件）", ex2);
			}
			string text = ModMain.RequestTaskTempFolder() + fileNameFromPath;
			ModBase.Log("[Event] 转换网络资源：" + RelativeUrl + " -> " + text);
			try
			{
				TaskAwaiter awaiter = ModNet.NetDownloadByClient(RelativeUrl, text).GetAwaiter();
				awaiter.GetResult();
				awaiter = ModNet.NetDownloadByClient(RelativeUrl.Replace(".json", ".xaml"), text.Replace(".json", ".xaml")).GetAwaiter();
				awaiter.GetResult();
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				throw new System.Exception("下载指定的文件失败！\r\n注意，联网帮助页面须指向一个帮助 JSON 文件，并在同路径下包含相应 XAML 文件！\r\n例如：\r\n - https://www.baidu.com/test.json（填写这个路径）\r\n - https://www.baidu.com/test.xaml（同时也需要包含这个文件）", ex4);
			}
			RelativeUrl = text;
		}
		RelativeUrl = RelativeUrl.Replace("/", "\\").ToLower().TrimStart('\\');
		string text2 = ModBase.ExePath + "PCL";
		ModMain.HelpExtract();
		string text3;
		if (RelativeUrl.Contains(":\\"))
		{
			text3 = RelativeUrl;
			ModBase.Log("[Control] 自定义事件中由绝对路径" + EventType + "：" + text3);
		}
		else if (File.Exists(ModBase.ExePath + "PCL\\" + RelativeUrl))
		{
			text3 = ModBase.ExePath + "PCL\\" + RelativeUrl;
			ModBase.Log("[Control] 自定义事件中由相对 PCL 文件夹的路径" + EventType + "：" + text3);
		}
		else if (File.Exists(ModBase.ExePath + "PCL\\Help\\" + RelativeUrl))
		{
			text3 = ModBase.ExePath + "PCL\\Help\\" + RelativeUrl;
			text2 = ModBase.ExePath + "PCL\\Help\\";
			ModBase.Log("[Control] 自定义事件中由相对 PCL 本地帮助文件夹的路径" + EventType + "：" + text3);
		}
		else if (Operators.CompareString(EventType, "打开帮助", false) == 0 && File.Exists(ModBase.PathHelpFolder + RelativeUrl))
		{
			text3 = ModBase.PathHelpFolder + RelativeUrl;
			text2 = ModBase.PathHelpFolder;
			ModBase.Log("[Control] 自定义事件中由相对 PCL 自带帮助文件夹的路径" + EventType + "：" + text3);
		}
		else
		{
			if (Operators.CompareString(EventType, "打开文件", false) != 0 && Operators.CompareString(EventType, "执行命令", false) != 0)
			{
				throw new FileNotFoundException("未找到 EventData 指向的本地 xaml 文件：" + RelativeUrl, RelativeUrl);
			}
			text3 = RelativeUrl;
			ModBase.Log("[Control] 自定义事件中直接" + EventType + "：" + text3);
		}
		return new string[] { text3, text2 };
	}
}
