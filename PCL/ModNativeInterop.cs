using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using PCL.Core.App;
using PCL.Core.IO;
using PCL.Core.Utils;

namespace PCL;

[StandardModule]
public sealed class ModNativeInterop
{
	private class RPCLauncherInfo
	{
		public class LauncherVersion
		{
			public string name;

			public string commit;

			public string branch;

			public string branch_code;

			public string upstream;

			public LauncherVersion()
			{
				name = "2.13.3";
				commit = ModBase.CommitHash;
				branch = "Publish";
				branch_code = "0";
				upstream = "2.10.5";
			}
		}

		public string path;

		public string config_path;

		public long window;

		public LauncherVersion version;

		public RPCLauncherInfo()
		{
			path = ModBase.ExePathWithName;
			config_path = ModBase.PathAppdataConfig;
			window = ((System.IntPtr)ModBase.FrmHandle).ToInt64();
			version = new LauncherVersion();
		}
	}

	private class RPCLogOpenRequest
	{
		public string id;

		public int client;

		public int timeout;

		public RPCLogOpenRequest()
		{
			timeout = 5;
		}
	}

	private class RPCLogInfoResponse
	{
		public class LauncherLog
		{
			public string id;

			public int pending;

			public LauncherLog()
			{
				id = "launcher";
				pending = PendingLauncherLogs.Count;
			}
		}

		public class MinecraftLog
		{
			public string id;

			public int pending;

			public string name;

			public string version;

			public ModWatcher.Watcher.MinecraftState state;

			public bool realtime;

			public static MinecraftLog[] GenerateLogInfo()
			{
				//IL_0028: Unknown result type (might be due to invalid IL or missing references)
				//IL_002d: Unknown result type (might be due to invalid IL or missing references)
				LastUpdatedWatchers.Clear();
				if (!ModWatcher.HasRunningMinecraft)
				{
					return new MinecraftLog[0];
				}
				List<MinecraftLog> val = new List<MinecraftLog>();
				System.Collections.Generic.IEnumerator<ModWatcher.Watcher> enumerator = default(System.Collections.Generic.IEnumerator<ModWatcher.Watcher>);
				try
				{
					enumerator = ModWatcher.McWatcherList.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ModWatcher.Watcher current = enumerator.Current;
						string text = $"mc@{current.GameProcess.Id}";
						LastUpdatedWatchers[text] = current;
						ModWatcher.Watcher.MinecraftState minecraftState = current.State;
						int count = current.FullLog.Count;
						bool realTimeLog = current.RealTimeLog;
						ModMinecraft.McInstance mcInstance = current.Version;
						string text2 = mcInstance.Name;
						string text3 = mcInstance.Version.McInstance.ToString();
						val.Add(new MinecraftLog
						{
							id = text,
							name = text2,
							pending = count,
							realtime = realTimeLog,
							state = minecraftState,
							version = text3
						});
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				return val.ToArray();
			}
		}

		public LauncherLog launcher;

		public MinecraftLog[] minecraft;

		public RPCLogInfoResponse()
		{
			launcher = new LauncherLog();
			minecraft = MinecraftLog.GenerateLogInfo();
		}
	}

	private const string LogPipePrefix = "PCLCE_LOG@";

	private static readonly RpcProperty[] PredefinedProperties = new RpcProperty[2]
	{
		new RpcProperty("version", [SpecialName] () => "2.13.3"),
		new RpcProperty("branch", [SpecialName] () => "Publish")
	};

	private static readonly List<string> PendingLauncherLogs = new List<string>();

	private static readonly Dictionary<string, ModWatcher.Watcher> LastUpdatedWatchers = new Dictionary<string, ModWatcher.Watcher>();

	private static readonly HashSet<string> OpenLogPipes = new HashSet<string>();

	private static Formatting JsonIndent(bool indent)
	{
		if (!indent)
		{
			return Formatting.None;
		}
		return Formatting.Indented;
	}

	private static RpcResponse _InfoCallback(string argument, string content, bool indent)
	{
		string content2 = JsonConvert.SerializeObject(new RPCLauncherInfo(), JsonIndent(indent));
		return RpcResponse.Success(RpcResponseType.Json, content2);
	}

	public static void PrintLog(string line)
	{
		PendingLauncherLogs.Add(line);
	}

	private static bool LogPipeCallback(StreamReader reader, StreamWriter writer, RPCLogOpenRequest request)
	{
		return false;
	}

	private static RpcResponse _LogCallback(string argument, string content, bool indent)
	{
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		RpcResponse result;
		if (argument == null)
		{
			result = RpcResponse.Err("请求参数过少");
		}
		else
		{
			argument = argument.ToLowerInvariant();
			if (Operators.CompareString(argument, "info", false) == 0)
			{
				string content2 = JsonConvert.SerializeObject(new RPCLogInfoResponse(), JsonIndent(indent));
				result = RpcResponse.Success(RpcResponseType.Json, content2);
			}
			else if (Operators.CompareString(argument, "open", false) == 0)
			{
				RPCLogOpenRequest rPCLogOpenRequest;
				Process processById;
				try
				{
					rPCLogOpenRequest = JsonConvert.DeserializeObject<RPCLogOpenRequest>(content);
					processById = Process.GetProcessById(rPCLogOpenRequest.client);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					string content3 = ((ex2 is ArgumentException && !(ex2 is ArgumentNullException)) ? "进程 ID 不存在" : "JSON 解析出错");
					ModBase.Log(ex2, "[PipeRPC] log: 日志管道请求错误");
					result = RpcResponse.Err(content3);
					ProjectData.ClearProjectError();
					goto IL_01bf;
				}
				string id = rPCLogOpenRequest.id;
				if (Operators.CompareString(id, "launcher", false) != 0 && !LastUpdatedWatchers.ContainsKey(id))
				{
					result = RpcResponse.Err("日志 ID 不存在");
				}
				else if (OpenLogPipes.Contains(id))
				{
					result = RpcResponse.Err("日志 ID 正在使用");
				}
				else
				{
					string text = "PCLCE_LOG@" + Conversions.ToString(RandomUtils.NextInt(10000, 99999));
					OpenLogPipes.Add(id);
					PipeComm.StartPipeServer($"Log({id})", text, [SpecialName] (StreamReader r, StreamWriter w, Process c) => LogPipeCallback(r, w, rPCLogOpenRequest), (Action)([SpecialName] () =>
					{
						OpenLogPipes.Remove(id);
					}), stopWhenException: true, new int[] { processById.Id });
					result = RpcResponse.Success(RpcResponseType.Text, text, "pipe_name");
				}
			}
			else
			{
				result = RpcResponse.Err("请求参数只能是 info 或 open");
			}
		}
		goto IL_01bf;
		IL_01bf:
		return result;
	}

	private static void AddPredefinedFunctions()
	{
		RpcService.AddFunction("info", _InfoCallback);
		RpcService.AddFunction("log", _LogCallback);
	}

	private static void Start()
	{
		ModBase.Log("[RPC] 正在加载预设 RPC 属性");
		RpcProperty[] predefinedProperties = PredefinedProperties;
		for (int i = 0; i < predefinedProperties.Length; i = checked(i + 1))
		{
			RpcService.AddProperty(predefinedProperties[i]);
		}
		ModBase.Log("[RPC] 正在加载预设 RPC 函数");
		AddPredefinedFunctions();
	}

	public static void StartEchoPipe()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		ModBase.RunInNewThread(new Action(Start), "RPC-Loading", (ThreadPriority)2);
	}
}
