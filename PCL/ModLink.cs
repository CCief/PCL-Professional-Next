using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.Core.IO;
using PCL.Core.Link;
using PCL.Core.Link.EasyTier;
using PCL.Core.Link.Lobby;
using PCL.Core.Link.Natayark;
using PCL.Core.Utils.OS;

namespace PCL;

[StandardModule]
public sealed class ModLink
{
	public class PortFinder
	{
		public struct MIB_TCPROW_OWNER_PID
		{
			public int dwState;

			public int dwLocalAddr;

			public int dwLocalPort;

			public int dwRemoteAddr;

			public int dwRemotePort;

			public int dwOwningPid;
		}

		[DllImport("iphlpapi.dll", SetLastError = true)]
		public static extern int GetExtendedTcpTable(nint pTcpTable, ref int dwOutBufLen, bool bOrder, int ulAf, int TableClass, int reserved);

		public static List<int> GetProcessPort(int dwProcessId)
		{
			List<int> val = new List<int>();
			nint zero = System.IntPtr.Zero;
			int dwOutBufLen = 0;
			if (dwProcessId == 0)
			{
				return val;
			}
			int extendedTcpTable = GetExtendedTcpTable(System.IntPtr.Zero, ref dwOutBufLen, bOrder: true, 2, 3, 0);
			if (extendedTcpTable != 0 && extendedTcpTable != 122)
			{
				return val;
			}
			zero = Marshal.AllocHGlobal(dwOutBufLen);
			try
			{
				if (GetExtendedTcpTable(zero, ref dwOutBufLen, bOrder: true, 2, 3, 0) != 0)
				{
					return val;
				}
				nint num = zero;
				int num2 = Marshal.ReadInt32((System.IntPtr)num);
				num = System.IntPtr.Add((System.IntPtr)num, 4);
				int num3 = checked(num2 - 1);
				for (int i = 0; i <= num3; i = checked(i + 1))
				{
					MIB_TCPROW_OWNER_PID mIB_TCPROW_OWNER_PID = Marshal.PtrToStructure<MIB_TCPROW_OWNER_PID>((System.IntPtr)num);
					if (mIB_TCPROW_OWNER_PID.dwOwningPid == dwProcessId)
					{
						val.Add((mIB_TCPROW_OWNER_PID.dwLocalPort >> 8) | ((mIB_TCPROW_OWNER_PID.dwLocalPort & 0xFF) << 8));
					}
					num = System.IntPtr.Add((System.IntPtr)num, Marshal.SizeOf<MIB_TCPROW_OWNER_PID>());
				}
			}
			finally
			{
				Marshal.FreeHGlobal((System.IntPtr)zero);
			}
			return val;
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_2_MCInstanceFinding : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder<List<Tuple<int, McPingResult, string>>> _0024Builder;

		internal System.Collections.Generic.IEnumerator<string> _0024S0;

		internal System.Collections.Generic.IEnumerator<int> _0024S1;

		internal System.Collections.Generic.IEnumerator<string> _0024S2;

		internal _Closure_0024__2_002D1 _0024VB_0024ResumableLocal__0024VB_0024Closure__00243;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0263: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_027f: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			List<Tuple<int, McPingResult, string>> _0024VB_0024Local_res;
			try
			{
				List<string> val = default(List<string>);
				if (num != -3 && num != 0)
				{
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00243 = new _Closure_0024__2_002D1(_0024VB_0024ResumableLocal__0024VB_0024Closure__00243);
					val = new List<string>();
					List<string> val2 = new List<string>();
					val2.Add("java");
					val2.Add("javaw");
					try
					{
						_0024S0 = val2.GetEnumerator();
						while (_0024S0.MoveNext())
						{
							string current = _0024S0.Current;
							Process[] processesByName = Process.GetProcessesByName(current);
							ModBase.Log($"[MCDetect] 找到 {current} 进程 {processesByName.Length} 个");
							if (processesByName != null && processesByName.Length != 0)
							{
								Process[] array = processesByName;
								foreach (Process val3 in array)
								{
									ModBase.Log("[MCDetect] 检测到 Java 进程，PID: " + val3.Id);
									val.Add(val3.Id.ToString());
								}
							}
						}
					}
					finally
					{
						if (num < 0)
						{
							((System.IDisposable)_0024S0)?.Dispose();
						}
					}
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00243._0024VB_0024Local_res = new List<Tuple<int, McPingResult, string>>();
				}
				try
				{
					TaskAwaiter val4;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val))
						{
							List<Tuple<int, int>> val5 = new List<Tuple<int, int>>();
							try
							{
								_0024S2 = val.GetEnumerator();
								while (_0024S2.MoveNext())
								{
									string current2 = _0024S2.Current;
									List<Tuple<int, int>> val6 = new List<Tuple<int, int>>();
									List<int> processPort = PortFinder.GetProcessPort(int.Parse(current2));
									try
									{
										_0024S1 = processPort.GetEnumerator();
										while (_0024S1.MoveNext())
										{
											int current3 = _0024S1.Current;
											val6.Add(new Tuple<int, int>(current3, Conversions.ToInteger(current2)));
										}
									}
									finally
									{
										if (num < 0)
										{
											((System.IDisposable)_0024S1).Dispose();
										}
									}
									val5.AddRange((System.Collections.Generic.IEnumerable<Tuple<int, int>>)val6);
								}
							}
							finally
							{
								if (num < 0)
								{
									((System.IDisposable)_0024S2).Dispose();
								}
							}
							ModBase.Log($"[MCDetect] 获取到端口数量 {val5.Count}");
							_Closure_0024__2_002D0 arg = default(_Closure_0024__2_002D0);
							val4 = System.Threading.Tasks.Task.WhenAll(Enumerable.ToArray<System.Threading.Tasks.Task>(Enumerable.Select<Tuple<int, int>, System.Threading.Tasks.Task>((System.Collections.Generic.IEnumerable<Tuple<int, int>>)val5, (Func<Tuple<int, int>, System.Threading.Tasks.Task>)([SpecialName] (Tuple<int, int> lookup) => System.Threading.Tasks.Task.Run((Func<System.Threading.Tasks.Task>)new _Closure_0024__2_002D0(null)
							{
								_0024VB_0024NonLocal__0024VB_0024Closure_2 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00243,
								_0024VB_0024Local_lookup = lookup
							}._Lambda_0024__1))))).GetAwaiter();
							if (!val4.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = val4;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_2_MCInstanceFinding>(ref val4, ref _this);
								return;
							}
							break;
						}
						_0024VB_0024Local_res = _0024VB_0024ResumableLocal__0024VB_0024Closure__00243._0024VB_0024Local_res;
						goto end_IL_0007;
					case 0:
						num = (_0024State = -1);
						val4 = _0024A0;
						_0024A0 = default(TaskAwaiter);
						break;
					}
					val4.GetResult();
					val4 = default(TaskAwaiter);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "[MCDetect] 获取端口信息错误");
					ProjectData.ClearProjectError();
				}
				_0024VB_0024Local_res = _0024VB_0024ResumableLocal__0024VB_0024Closure__00243._0024VB_0024Local_res;
				end_IL_0007:;
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception exception = ex3;
				_0024State = -2;
				_0024Builder.SetException(exception);
				ProjectData.ClearProjectError();
				return;
			}
			num = (_0024State = -2);
			_0024Builder.SetResult(_0024VB_0024Local_res);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__17_002D0
	{
		public string _0024VB_0024Local_arch;

		public string _0024VB_0024Local_DlTargetPath;

		public VB_0024AnonymousDelegate_8 _0024I1;

		public Action<ModLoader.LoaderTask<int, int>> _0024IR8;

		public VB_0024AnonymousDelegate_8 _0024I2;

		public Action<ModLoader.LoaderTask<int, int>> _0024IR9;

		public _Closure_0024__17_002D0(_Closure_0024__17_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_arch = arg0._0024VB_0024Local_arch;
				_0024VB_0024Local_DlTargetPath = arg0._0024VB_0024Local_DlTargetPath;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			try
			{
				List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
				List<string> val2 = new List<string>();
				val2.Add(string.Format("https://cdn.gh-proxy.org/https://github.com/AllesUgo/Minecraft-Speed-Proxy/releases/download/v{0}/minecraftspeedproxy-win-{1}.zip", (object)"3.1.3", (object)_0024VB_0024Local_arch));
				val2.Add(string.Format("https://gh-proxy.org/https://github.com/AllesUgo/Minecraft-Speed-Proxy/releases/download/v{0}/minecraftspeedproxy-win-{1}.zip", (object)"3.1.3", (object)_0024VB_0024Local_arch));
				val2.Add(string.Format("https://edgeone.gh-proxy.org/https://github.com/AllesUgo/Minecraft-Speed-Proxy/releases/download/v{0}/minecraftspeedproxy-win-{1}.zip", (object)"3.1.3", (object)_0024VB_0024Local_arch));
				val2.Add(string.Format("https://github.com/AllesUgo/Minecraft-Speed-Proxy/releases/download/v{0}/minecraftspeedproxy-win-{1}.zip", (object)"3.1.3", (object)_0024VB_0024Local_arch));
				List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
				obj.Add(new ModNet.NetFile(val2.ToArray(), _0024VB_0024Local_DlTargetPath, new ModBase.FileChecker(65536L, -1L)));
				val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载代理程序", obj)
				{
					ProgressWeight = 15.0
				});
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("解压文件", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					((VB_0024AnonymousDelegate_8)([SpecialName] () =>
					{
						string text = Path.Combine(ModBase.ExePath, "PCL", "LinkProxy");
						if (!Directory.Exists(text))
						{
							Directory.CreateDirectory(text);
						}
						ZipArchive val3 = ZipFile.OpenRead(_0024VB_0024Local_DlTargetPath);
						try
						{
							System.Collections.Generic.IEnumerator<ZipArchiveEntry> enumerator = default(System.Collections.Generic.IEnumerator<ZipArchiveEntry>);
							try
							{
								enumerator = val3.Entries.GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator).MoveNext())
								{
									ZipArchiveEntry current = enumerator.Current;
									if (current.Name.Equals("minecraftspeedproxy.exe", (StringComparison)5))
									{
										string text2 = Path.Combine(text, "minecraftspeedproxy.exe");
										ZipFileExtensions.ExtractToFile(current, text2, true);
										ModBase.Log($"[Link] 代理程序已安装到: {text2}");
										break;
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator)?.Dispose();
							}
						}
						finally
						{
							((System.IDisposable)val3)?.Dispose();
						}
					}))();
				}, null, (ThreadPriority)2)
				{
					Block = true
				});
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("清理缓存", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					((VB_0024AnonymousDelegate_8)([SpecialName] () =>
					{
						File.Delete(_0024VB_0024Local_DlTargetPath);
					}))();
				}, null, (ThreadPriority)2));
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("刷新界面", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					((VB_0024AnonymousDelegate_8)([SpecialName] () =>
					{
						ModMain.Hint("代理程序下载完成！", ModMain.HintType.Finish);
					}))();
				}, null, (ThreadPriority)2)
				{
					Show = false
				});
				DlProxyLoader = new ModLoader.LoaderCombo<JObject>("代理程序初始化", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
				DlProxyLoader.Start();
				ModLoader.LoaderTaskbarAdd(DlProxyLoader);
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
				ModMain.FrmMain.BtnExtraDownload.Ribble();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "[Link] 下载代理程序失败", ModBase.LogLevel.Hint);
				ModMain.Hint("下载代理程序失败，请检查网络连接", ModMain.HintType.Critical);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R8(ModLoader.LoaderTask<int, int> a0)
		{
			((VB_0024AnonymousDelegate_8)([SpecialName] () =>
			{
				string text = Path.Combine(ModBase.ExePath, "PCL", "LinkProxy");
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				ZipArchive val = ZipFile.OpenRead(_0024VB_0024Local_DlTargetPath);
				try
				{
					System.Collections.Generic.IEnumerator<ZipArchiveEntry> enumerator = default(System.Collections.Generic.IEnumerator<ZipArchiveEntry>);
					try
					{
						enumerator = val.Entries.GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator).MoveNext())
						{
							ZipArchiveEntry current = enumerator.Current;
							if (current.Name.Equals("minecraftspeedproxy.exe", (StringComparison)5))
							{
								string text2 = Path.Combine(text, "minecraftspeedproxy.exe");
								ZipFileExtensions.ExtractToFile(current, text2, true);
								ModBase.Log($"[Link] 代理程序已安装到: {text2}");
								break;
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator)?.Dispose();
					}
				}
				finally
				{
					((System.IDisposable)val)?.Dispose();
				}
			}))();
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			string text = Path.Combine(ModBase.ExePath, "PCL", "LinkProxy");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			ZipArchive val = ZipFile.OpenRead(_0024VB_0024Local_DlTargetPath);
			try
			{
				System.Collections.Generic.IEnumerator<ZipArchiveEntry> enumerator = default(System.Collections.Generic.IEnumerator<ZipArchiveEntry>);
				try
				{
					enumerator = val.Entries.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						ZipArchiveEntry current = enumerator.Current;
						if (current.Name.Equals("minecraftspeedproxy.exe", (StringComparison)5))
						{
							string text2 = Path.Combine(text, "minecraftspeedproxy.exe");
							ZipFileExtensions.ExtractToFile(current, text2, true);
							ModBase.Log($"[Link] 代理程序已安装到: {text2}");
							break;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R9(ModLoader.LoaderTask<int, int> a0)
		{
			((VB_0024AnonymousDelegate_8)([SpecialName] () =>
			{
				File.Delete(_0024VB_0024Local_DlTargetPath);
			}))();
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			File.Delete(_0024VB_0024Local_DlTargetPath);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__2_002D0
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine___Lambda_0024__1 : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncTaskMethodBuilder _0024Builder;

			internal _Closure_0024__2_002D0 _0024VB_0024NonLocal__Closure_0024__2_002D0;

			internal McPing _0024VB_0024ResumableLocal_test_00240;

			internal TaskAwaiter<McPingResult> _0024A0;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_0244: Unknown result type (might be due to invalid IL or missing references)
				//IL_0249: Unknown result type (might be due to invalid IL or missing references)
				//IL_0251: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
				//IL_0260: Unknown result type (might be due to invalid IL or missing references)
				//IL_0206: Unknown result type (might be due to invalid IL or missing references)
				//IL_020b: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
				//IL_009a: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
				//IL_0220: Unknown result type (might be due to invalid IL or missing references)
				//IL_0222: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				try
				{
					if ((uint)(num - -4) > 1u && (uint)num > 1u)
					{
						ModBase.Log($"[MCDetect] 找到疑似端口，开始验证：{_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_lookup}");
						_0024VB_0024ResumableLocal_test_00240 = new McPing("127.0.0.1", _0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_lookup.Item1, 3000);
					}
					try
					{
						switch (num)
						{
						default:
							try
							{
								TaskAwaiter<McPingResult> awaiter;
								switch (num)
								{
								case -3:
									num = (_0024State = -1);
									return;
								default:
									awaiter = _0024VB_0024ResumableLocal_test_00240.PingAsync().GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_0024State = 0);
										_0024A0 = awaiter;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<McPingResult>, VB_0024StateMachine___Lambda_0024__1>(ref awaiter, ref _this);
										return;
									}
									break;
								case 0:
									num = (_0024State = -1);
									awaiter = _0024A0;
									_0024A0 = default(TaskAwaiter<McPingResult>);
									break;
								}
								McPingResult result = awaiter.GetResult();
								awaiter = default(TaskAwaiter<McPingResult>);
								McPingResult mcPingResult = result;
								string launcherBrand = GetLauncherBrand(_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_lookup.Item2);
								if (string.IsNullOrWhiteSpace(mcPingResult.Version.Name))
								{
									goto end_IL_007a;
								}
								ModBase.Log($"[MCDetect] 端口 {_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_lookup} 为有效 Minecraft 世界");
								_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_res.Add(new Tuple<int, McPingResult, string>(_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_lookup.Item1, mcPingResult, launcherBrand));
								goto end_IL_0058;
								end_IL_007a:;
							}
							catch (System.Exception ex)
							{
								ProjectData.SetProjectError(ex);
								System.Exception ex2 = ex;
								if (ex2.InnerException is ObjectDisposedException)
								{
									ModBase.Log($"[McDetect] {_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_lookup} 验证超时，已强制断开连接，将尝试旧版检测");
								}
								else
								{
									ModBase.Log(ex2, $"[McDetect] {_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_lookup} 验证出错，将尝试旧版检测");
								}
								ProjectData.ClearProjectError();
							}
							break;
						case -4:
						case 1:
							break;
						}
						try
						{
							TaskAwaiter<McPingResult> awaiter2;
							switch (num)
							{
							case -4:
								num = (_0024State = -1);
								return;
							default:
								awaiter2 = _0024VB_0024ResumableLocal_test_00240.PingOldAsync().GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 1);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<McPingResult>, VB_0024StateMachine___Lambda_0024__1>(ref awaiter2, ref _this);
									return;
								}
								break;
							case 1:
								num = (_0024State = -1);
								awaiter2 = _0024A0;
								_0024A0 = default(TaskAwaiter<McPingResult>);
								break;
							}
							McPingResult result2 = awaiter2.GetResult();
							awaiter2 = default(TaskAwaiter<McPingResult>);
							McPingResult mcPingResult = result2;
							if (!string.IsNullOrWhiteSpace(mcPingResult.Version.Name))
							{
								ModBase.Log($"[MCDetect] 端口 {_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_lookup} 为有效 Minecraft 世界");
								_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_res.Add(new Tuple<int, McPingResult, string>(_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_lookup.Item1, mcPingResult, string.Empty));
							}
						}
						catch (System.Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							System.Exception ex4 = ex3;
							if (ex4.InnerException is ObjectDisposedException)
							{
								ModBase.Log($"[McDetect] {_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_lookup} 验证超时，已强制断开连接");
							}
							else
							{
								ModBase.Log(ex4, $"[McDetect] {_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_lookup} 验证出错");
							}
							ProjectData.ClearProjectError();
						}
						end_IL_0058:;
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_test_00240 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_test_00240).Dispose();
						}
					}
				}
				catch (System.Exception ex5)
				{
					ProjectData.SetProjectError(ex5);
					System.Exception exception = ex5;
					_0024State = -2;
					_0024Builder.SetException(exception);
					ProjectData.ClearProjectError();
					return;
				}
				num = (_0024State = -2);
				_0024Builder.SetResult();
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_0024Builder.SetStateMachine(stateMachine);
			}
		}

		public Tuple<int, int> _0024VB_0024Local_lookup;

		public _Closure_0024__2_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__2_002D0(_Closure_0024__2_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_lookup = arg0._0024VB_0024Local_lookup;
			}
		}

		[SpecialName]
		[AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__1))]
		internal System.Threading.Tasks.Task _Lambda_0024__1()
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__1 vB_0024StateMachine___Lambda_0024__ = default(VB_0024StateMachine___Lambda_0024__1);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__2_002D0 = this;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<VB_0024StateMachine___Lambda_0024__1>(ref vB_0024StateMachine___Lambda_0024__);
			return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__2_002D1
	{
		public List<Tuple<int, McPingResult, string>> _0024VB_0024Local_res;

		public _Closure_0024__2_002D1(_Closure_0024__2_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_res = arg0._0024VB_0024Local_res;
			}
		}

		[SpecialName]
		internal System.Threading.Tasks.Task _Lambda_0024__0(Tuple<int, int> lookup)
		{
			_Closure_0024__2_002D0 arg = default(_Closure_0024__2_002D0);
			return System.Threading.Tasks.Task.Run((Func<System.Threading.Tasks.Task>)new _Closure_0024__2_002D0(null)
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_2 = this,
				_0024VB_0024Local_lookup = lookup
			}._Lambda_0024__1);
		}
	}

	public static ModLoader.LoaderCombo<JObject> DlEasyTierLoader = null;

	public static ModLoader.LoaderCombo<JObject> DlFrpcLoader = null;

	private const string FrpcVersion = "0.65.0";

	public static ModLoader.LoaderCombo<JObject> DlProxyLoader = null;

	private const string ProxyVersion = "3.1.3";

	[AsyncStateMachine(typeof(VB_0024StateMachine_2_MCInstanceFinding))]
	public static async System.Threading.Tasks.Task<List<Tuple<int, McPingResult, string>>> MCInstanceFinding()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		_Closure_0024__2_002D1 arg = default(_Closure_0024__2_002D1);
		_Closure_0024__2_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__2_002D1(null);
		List<string> val = new List<string>();
		List<string> val2 = new List<string>();
		val2.Add("java");
		val2.Add("javaw");
		System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator = val2.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				Process[] processesByName = Process.GetProcessesByName(current);
				ModBase.Log($"[MCDetect] 找到 {current} 进程 {processesByName.Length} 个");
				if (processesByName != null && processesByName.Length != 0)
				{
					Process[] array = processesByName;
					foreach (Process val3 in array)
					{
						ModBase.Log("[MCDetect] 检测到 Java 进程，PID: " + val3.Id);
						val.Add(val3.Id.ToString());
					}
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_res = new List<Tuple<int, McPingResult, string>>();
		try
		{
			if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val))
			{
				return CS_0024_003C_003E8__locals0._0024VB_0024Local_res;
			}
			List<Tuple<int, int>> val4 = new List<Tuple<int, int>>();
			System.Collections.Generic.IEnumerator<string> enumerator2 = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator2 = val.GetEnumerator();
				System.Collections.Generic.IEnumerator<int> enumerator3 = default(System.Collections.Generic.IEnumerator<int>);
				while (enumerator2.MoveNext())
				{
					string current2 = enumerator2.Current;
					List<Tuple<int, int>> val5 = new List<Tuple<int, int>>();
					List<int> processPort = PortFinder.GetProcessPort(int.Parse(current2));
					try
					{
						enumerator3 = processPort.GetEnumerator();
						while (enumerator3.MoveNext())
						{
							int current3 = enumerator3.Current;
							val5.Add(new Tuple<int, int>(current3, Conversions.ToInteger(current2)));
						}
					}
					finally
					{
						((System.IDisposable)enumerator3).Dispose();
					}
					val4.AddRange((System.Collections.Generic.IEnumerable<Tuple<int, int>>)val5);
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			ModBase.Log($"[MCDetect] 获取到端口数量 {val4.Count}");
			await System.Threading.Tasks.Task.WhenAll(Enumerable.ToArray<System.Threading.Tasks.Task>(Enumerable.Select<Tuple<int, int>, System.Threading.Tasks.Task>((System.Collections.Generic.IEnumerable<Tuple<int, int>>)val4, (Func<Tuple<int, int>, System.Threading.Tasks.Task>)([SpecialName] (Tuple<int, int> lookup) =>
			{
				_Closure_0024__2_002D0 arg2 = default(_Closure_0024__2_002D0);
				_Closure_0024__2_002D0 CS_0024_003C_003E8__locals1 = new _Closure_0024__2_002D0(null);
				CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals0;
				CS_0024_003C_003E8__locals1._0024VB_0024Local_lookup = lookup;
				return System.Threading.Tasks.Task.Run((Func<System.Threading.Tasks.Task>)([SpecialName] [AsyncStateMachine(typeof(_Closure_0024__2_002D0.VB_0024StateMachine___Lambda_0024__1))] () =>
				{
					//IL_001a: Unknown result type (might be due to invalid IL or missing references)
					//IL_001f: Unknown result type (might be due to invalid IL or missing references)
					_Closure_0024__2_002D0.VB_0024StateMachine___Lambda_0024__1 vB_0024StateMachine___Lambda_0024__ = default(_Closure_0024__2_002D0.VB_0024StateMachine___Lambda_0024__1);
					vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__2_002D0 = CS_0024_003C_003E8__locals1;
					vB_0024StateMachine___Lambda_0024__._0024State = -1;
					vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
					vB_0024StateMachine___Lambda_0024__._0024Builder.Start<_Closure_0024__2_002D0.VB_0024StateMachine___Lambda_0024__1>(ref vB_0024StateMachine___Lambda_0024__);
					return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
				}));
			}))));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "[MCDetect] 获取端口信息错误");
			ProjectData.ClearProjectError();
		}
		return CS_0024_003C_003E8__locals0._0024VB_0024Local_res;
	}

	public static string GetLauncherBrand(int pid)
	{
		string result;
		try
		{
			string commandLine = ProcessInterop.GetCommandLine(pid);
			result = ((!commandLine.Contains("-Dminecraft.launcher.brand=")) ? ModBase.BeforeFirst(ModBase.AfterFirst(commandLine, "--versionType "), "-").TrimEnd(new char[] { '\'', ' ' }) : ModBase.BeforeFirst(ModBase.AfterFirst(commandLine, "-Dminecraft.launcher.brand="), "-").TrimEnd(new char[] { '\'', ' ' }));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, $"[MCDetect] 检测 PID {pid} 进程的启动参数失败");
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static object DownloadEasyTier(bool LaunchAfterDownload = false, bool isHost = false, string boardcastDesc = null)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		string text = ModBase.PathTemp + string.Format("EasyTier\\EasyTier-{0}.zip", (object)"2.4.5");
		ModBase.RunInNewThread((Action)([SpecialName] () =>
		{
			try
			{
				List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
				List<string> val2 = new List<string>();
				val2.Add(string.Format("https://pclpro.mtr.qzz.io/github/static/easytier/easytier-windows-{0}-v{1}.zip", (object)(ModBase.IsArm64System ? "arm64" : "x86_64"), (object)"2.4.5"));
				val2.Add(string.Format("https://github.com/PCL-Community/PCL2_CE_Server/raw/main/static/easytier/easytier-windows-{0}-v{1}.zip", (object)(ModBase.IsArm64System ? "arm64" : "x86_64"), (object)"2.4.5"));
				List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
				obj.Add(new ModNet.NetFile(val2.ToArray(), text, new ModBase.FileChecker(65536L, -1L)));
				val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 EasyTier", obj)
				{
					ProgressWeight = 15.0
				});
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("解压文件", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					((VB_0024AnonymousDelegate_8)([SpecialName] () =>
					{
						ModBase.ExtractFile(text, Path.Combine(FileService.LocalDataPath, "EasyTier", "2.4.5"));
					}))();
				}, null, (ThreadPriority)2)
				{
					Block = true
				});
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("清理缓存与冗余组件", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					((VB_0024AnonymousDelegate_8)([SpecialName] () =>
					{
						File.Delete(text);
						CleanupEasyTierCache();
					}))();
				}, null, (ThreadPriority)2));
				if (LaunchAfterDownload)
				{
					val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("启动大厅", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
					{
						((VB_0024AnonymousDelegate_8)([SpecialName] () =>
						{
							LobbyController.Launch(isHost, (ModProfile.SelectedProfile != null) ? ModProfile.SelectedProfile.Username : "");
						}))();
					}, null, (ThreadPriority)2));
				}
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("刷新界面", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					((VB_0024AnonymousDelegate_8)([SpecialName] () =>
					{
						ModMain.Hint("联机组件下载完成！", ModMain.HintType.Finish);
					}))();
				}, null, (ThreadPriority)2)
				{
					Show = false
				});
				DlEasyTierLoader = new ModLoader.LoaderCombo<JObject>("大厅初始化", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
				DlEasyTierLoader.Start();
				ModLoader.LoaderTaskbarAdd(DlEasyTierLoader);
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
				ModMain.FrmMain.BtnExtraDownload.Ribble();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "[Link] 下载 EasyTier 依赖文件失败", ModBase.LogLevel.Hint);
				ModMain.Hint("下载 EasyTier 依赖文件失败，请检查网络连接", ModMain.HintType.Critical);
				ProjectData.ClearProjectError();
			}
		}), null, (ThreadPriority)2);
		return 0;
	}

	private static void CleanupEasyTierCache()
	{
		string[] directories = Directory.GetDirectories(Path.Combine(FileService.LocalDataPath, "EasyTier"));
		foreach (string text in directories)
		{
			if (!Path.GetFileName(text).Equals("2.4.5"))
			{
				try
				{
					Directory.Delete(text, true);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "[Link] 清理旧版本 EasyTier 出错");
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	public static string GetFrpcPath()
	{
		return Path.Combine(ModBase.ExePath, "PCL", "Frpc", "frpc.exe");
	}

	public static bool CheckFrpcExists()
	{
		return File.Exists(GetFrpcPath());
	}

	public static int DownloadFrpc(bool LaunchAfterDownload = false)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		string text = (ModBase.IsArm64System ? "arm64" : "amd64");
		string text2 = ModBase.PathTemp + string.Format("Frpc\\frp_{0}_windows_{1}.zip", (object)"0.65.0", (object)text);
		ModBase.RunInNewThread((Action)([SpecialName] () =>
		{
			try
			{
				List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
				List<string> val2 = new List<string>();
				val2.Add(string.Format("https://cdn.gh-proxy.org/https://github.com/fatedier/frp/releases/download/v{0}/frp_{1}_windows_{2}.zip", (object)"0.65.0", (object)"0.65.0", (object)text));
				val2.Add(string.Format("https://gh-proxy.org/https://github.com/fatedier/frp/releases/download/v{0}/frp_{1}_windows_{2}.zip", (object)"0.65.0", (object)"0.65.0", (object)text));
				val2.Add(string.Format("https://edgeone.gh-proxy.org/https://github.com/fatedier/frp/releases/download/v{0}/frp_{1}_windows_{2}.zip", (object)"0.65.0", (object)"0.65.0", (object)text));
				val2.Add(string.Format("https://github.com/fatedier/frp/releases/download/v{0}/frp_{1}_windows_{2}.zip", (object)"0.65.0", (object)"0.65.0", (object)text));
				List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
				obj.Add(new ModNet.NetFile(val2.ToArray(), text2, new ModBase.FileChecker(65536L, -1L)));
				val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载 Frpc", obj)
				{
					ProgressWeight = 15.0
				});
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("解压文件", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					((VB_0024AnonymousDelegate_8)([SpecialName] () =>
					{
						string text4 = Path.Combine(ModBase.PathTemp, "Frpc", "Extract");
						ModBase.ExtractFile(text2, text4);
						string text5 = Path.Combine(text4, string.Format("frp_{0}_windows_{1}", (object)"0.65.0", (object)text), "frpc.exe");
						string text6 = Path.Combine(ModBase.ExePath, "PCL", "Frpc");
						string text7 = Path.Combine(text6, "frpc.exe");
						if (!Directory.Exists(text6))
						{
							Directory.CreateDirectory(text6);
						}
						if (File.Exists(text5))
						{
							File.Copy(text5, text7, true);
							ModBase.Log($"[Link] Frpc 已安装到: {text7}");
							return;
						}
						throw new System.Exception($"找不到 frpc.exe: {text5}");
					}))();
				}, null, (ThreadPriority)2)
				{
					Block = true
				});
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("清理缓存", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					((VB_0024AnonymousDelegate_8)([SpecialName] () =>
					{
						File.Delete(text2);
						string text3 = Path.Combine(ModBase.PathTemp, "Frpc", "Extract");
						if (Directory.Exists(text3))
						{
							Directory.Delete(text3, true);
						}
					}))();
				}, null, (ThreadPriority)2));
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("刷新界面", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					((VB_0024AnonymousDelegate_8)([SpecialName] () =>
					{
						ModMain.Hint("Frpc 下载完成！", ModMain.HintType.Finish);
					}))();
				}, null, (ThreadPriority)2)
				{
					Show = false
				});
				DlFrpcLoader = new ModLoader.LoaderCombo<JObject>("Frpc 初始化", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
				DlFrpcLoader.Start();
				ModLoader.LoaderTaskbarAdd(DlFrpcLoader);
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
				ModMain.FrmMain.BtnExtraDownload.Ribble();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "[Link] 下载 Frpc 失败", ModBase.LogLevel.Hint);
				ModMain.Hint("下载 Frpc 失败，请检查网络连接", ModMain.HintType.Critical);
				ProjectData.ClearProjectError();
			}
		}), null, (ThreadPriority)2);
		return 0;
	}

	public static bool FrpcPrecheck()
	{
		if (!CheckFrpcExists())
		{
			ModBase.Log("[Link] Frpc 不存在，开始下载");
			ModMain.Hint("正在下载 Frpc 组件，请稍后...");
			DownloadFrpc();
			return false;
		}
		if (DlFrpcLoader != null)
		{
			if (DlFrpcLoader.State == ModBase.LoadState.Loading)
			{
				ModMain.Hint("Frpc 尚未下载完成，请等待其下载完成后再试！");
				return false;
			}
			if (DlFrpcLoader.State == ModBase.LoadState.Failed || DlFrpcLoader.State == ModBase.LoadState.Aborted)
			{
				ModMain.Hint("正在下载 Frpc，请稍后...");
				DownloadFrpc();
				return false;
			}
		}
		return true;
	}

	public static string GetProxyPath()
	{
		return Path.Combine(ModBase.ExePath, "PCL", "LinkProxy", "minecraftspeedproxy.exe");
	}

	public static bool CheckProxyExists()
	{
		return File.Exists(GetProxyPath());
	}

	public static int DownloadProxy(bool LaunchAfterDownload = false)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		_Closure_0024__17_002D0 arg = default(_Closure_0024__17_002D0);
		_Closure_0024__17_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__17_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_arch = (Environment.Is64BitOperatingSystem ? "x64" : "x86");
		CS_0024_003C_003E8__locals0._0024VB_0024Local_DlTargetPath = ModBase.PathTemp + $"LinkProxy\\minecraftspeedproxy-win-{CS_0024_003C_003E8__locals0._0024VB_0024Local_arch}.zip";
		ModBase.RunInNewThread((Action)([SpecialName] () =>
		{
			try
			{
				List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
				List<string> val2 = new List<string>();
				val2.Add(string.Format("https://cdn.gh-proxy.org/https://github.com/AllesUgo/Minecraft-Speed-Proxy/releases/download/v{0}/minecraftspeedproxy-win-{1}.zip", (object)"3.1.3", (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_arch));
				val2.Add(string.Format("https://gh-proxy.org/https://github.com/AllesUgo/Minecraft-Speed-Proxy/releases/download/v{0}/minecraftspeedproxy-win-{1}.zip", (object)"3.1.3", (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_arch));
				val2.Add(string.Format("https://edgeone.gh-proxy.org/https://github.com/AllesUgo/Minecraft-Speed-Proxy/releases/download/v{0}/minecraftspeedproxy-win-{1}.zip", (object)"3.1.3", (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_arch));
				val2.Add(string.Format("https://github.com/AllesUgo/Minecraft-Speed-Proxy/releases/download/v{0}/minecraftspeedproxy-win-{1}.zip", (object)"3.1.3", (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_arch));
				List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
				obj.Add(new ModNet.NetFile(val2.ToArray(), CS_0024_003C_003E8__locals0._0024VB_0024Local_DlTargetPath, new ModBase.FileChecker(65536L, -1L)));
				val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载代理程序", obj)
				{
					ProgressWeight = 15.0
				});
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("解压文件", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					((VB_0024AnonymousDelegate_8)([SpecialName] () =>
					{
						string text = Path.Combine(ModBase.ExePath, "PCL", "LinkProxy");
						if (!Directory.Exists(text))
						{
							Directory.CreateDirectory(text);
						}
						ZipArchive val3 = ZipFile.OpenRead(CS_0024_003C_003E8__locals0._0024VB_0024Local_DlTargetPath);
						try
						{
							System.Collections.Generic.IEnumerator<ZipArchiveEntry> enumerator = default(System.Collections.Generic.IEnumerator<ZipArchiveEntry>);
							try
							{
								enumerator = val3.Entries.GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator).MoveNext())
								{
									ZipArchiveEntry current = enumerator.Current;
									if (current.Name.Equals("minecraftspeedproxy.exe", (StringComparison)5))
									{
										string text2 = Path.Combine(text, "minecraftspeedproxy.exe");
										ZipFileExtensions.ExtractToFile(current, text2, true);
										ModBase.Log($"[Link] 代理程序已安装到: {text2}");
										break;
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator)?.Dispose();
							}
						}
						finally
						{
							((System.IDisposable)val3)?.Dispose();
						}
					}))();
				}, null, (ThreadPriority)2)
				{
					Block = true
				});
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("清理缓存", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					((VB_0024AnonymousDelegate_8)([SpecialName] () =>
					{
						File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_DlTargetPath);
					}))();
				}, null, (ThreadPriority)2));
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("刷新界面", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					((VB_0024AnonymousDelegate_8)([SpecialName] () =>
					{
						ModMain.Hint("代理程序下载完成！", ModMain.HintType.Finish);
					}))();
				}, null, (ThreadPriority)2)
				{
					Show = false
				});
				DlProxyLoader = new ModLoader.LoaderCombo<JObject>("代理程序初始化", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
				DlProxyLoader.Start();
				ModLoader.LoaderTaskbarAdd(DlProxyLoader);
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
				ModMain.FrmMain.BtnExtraDownload.Ribble();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "[Link] 下载代理程序失败", ModBase.LogLevel.Hint);
				ModMain.Hint("下载代理程序失败，请检查网络连接", ModMain.HintType.Critical);
				ProjectData.ClearProjectError();
			}
		}), null, (ThreadPriority)2);
		return 0;
	}

	public static bool ProxyPrecheck()
	{
		if (!CheckProxyExists())
		{
			ModBase.Log("[Link] 代理程序不存在，开始下载");
			ModMain.Hint("正在下载代理程序，请稍后...");
			DownloadProxy();
			return false;
		}
		if (DlProxyLoader != null)
		{
			if (DlProxyLoader.State == ModBase.LoadState.Loading)
			{
				ModMain.Hint("代理程序尚未下载完成，请等待其下载完成后再试！");
				return false;
			}
			if (DlProxyLoader.State == ModBase.LoadState.Failed || DlProxyLoader.State == ModBase.LoadState.Aborted)
			{
				ModMain.Hint("正在下载代理程序，请稍后...");
				DownloadProxy();
				return false;
			}
		}
		return true;
	}

	public static bool LobbyPrecheck()
	{
		bool result;
		if (!LobbyInfoProvider.IsLobbyAvailable)
		{
			ModMain.Hint("大厅功能暂不可用，请稍后再试", ModMain.HintType.Critical);
			result = false;
		}
		else if (ModProfile.SelectedProfile != null && ModProfile.SelectedProfile.Username.Contains("|"))
		{
			ModMain.Hint("MC 玩家 ID 不可包含分隔符 (|) ！");
			result = false;
		}
		else
		{
			if (!LobbyInfoProvider.RequiresLogin)
			{
				goto IL_0162;
			}
			if (string.IsNullOrWhiteSpace(Conversions.ToString(ModBase.Setup.Get("LinkNaidRefreshToken"))))
			{
				ModMain.Hint("请先前往联机设置并登录至 Natayark Network 再进行联机！", ModMain.HintType.Critical);
				result = false;
			}
			else
			{
				try
				{
					NatayarkProfileManager.GetNaidData(Conversions.ToString(ModBase.Setup.Get("LinkNaidRefreshToken")), isRefresh: true);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log("[Link] 刷新 Natayark ID 信息失败，需要重新登录");
					ModMain.Hint("请重新登录 Natayark Network 账号再试！", ModMain.HintType.Critical);
					result = false;
					ProjectData.ClearProjectError();
					goto IL_0219;
				}
				int num = 0;
				while (string.IsNullOrWhiteSpace(NatayarkProfileManager.NaidProfile.Username) && num <= 30)
				{
					Thread.Sleep(500);
					num = checked(num + 1);
				}
				if (string.IsNullOrWhiteSpace(NatayarkProfileManager.NaidProfile.Username))
				{
					ModMain.Hint("尝试获取 Natayark ID 信息失败", ModMain.HintType.Critical);
					result = false;
				}
				else if (LobbyInfoProvider.RequiresRealName && !NatayarkProfileManager.NaidProfile.IsRealNamed)
				{
					ModMain.Hint("请先前往 Natayark 账户中心进行实名验证再尝试操作！", ModMain.HintType.Critical);
					result = false;
				}
				else
				{
					if (NatayarkProfileManager.NaidProfile.Status == 0)
					{
						goto IL_0162;
					}
					ModMain.Hint("你的 Natayark Network 账号状态异常，可能已被封禁！", ModMain.HintType.Critical);
					result = false;
				}
			}
		}
		goto IL_0219;
		IL_0217:
		result = true;
		goto IL_0219;
		IL_0162:
		if (string.IsNullOrWhiteSpace(Conversions.ToString(ModBase.Setup.Get("LinkUsername"))) && string.IsNullOrWhiteSpace(NatayarkProfileManager.NaidProfile.Username))
		{
			ModMain.Hint("请先前往设置输入一个用户名，或登录至 Natayark Network 再进行联机！", ModMain.HintType.Critical);
			result = false;
		}
		else if (ETController.Precheck() == 1)
		{
			ModMain.Hint("正在下载联机依赖组件，请稍后...");
			DownloadEasyTier();
			result = false;
		}
		else
		{
			if (DlEasyTierLoader == null)
			{
				goto IL_0217;
			}
			if (DlEasyTierLoader.State == ModBase.LoadState.Loading)
			{
				ModMain.Hint("EasyTier 尚未下载完成，请等待其下载完成后再试！");
				result = false;
			}
			else
			{
				if (DlEasyTierLoader.State != ModBase.LoadState.Failed && DlEasyTierLoader.State != ModBase.LoadState.Aborted)
				{
					goto IL_0217;
				}
				ModMain.Hint("正在下载 EasyTier，请稍后...");
				DownloadEasyTier();
				result = false;
			}
		}
		goto IL_0219;
		IL_0219:
		return result;
	}
}
