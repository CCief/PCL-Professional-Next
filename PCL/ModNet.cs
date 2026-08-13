using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Net;
using PCL.Core.Utils;

namespace PCL;

[StandardModule]
public sealed class ModNet
{
	public class HttpRequestFailedException : HttpRequestException
	{
		[field: CompilerGenerated]
		public HttpStatusCode StatusCode
		{
			[CompilerGenerated]
			get;
		}

		[field: CompilerGenerated]
		public string ReasonPhrase
		{
			[CompilerGenerated]
			get;
		}

		[field: CompilerGenerated]
		public HttpResponseMessage Response
		{
			[CompilerGenerated]
			get;
		}

		[field: CompilerGenerated]
		public string WebResponse
		{
			[CompilerGenerated]
			get;
		}

		public HttpRequestFailedException(HttpResponseMessage response, string webResponse = null)
			: base($"HTTP 响应失败: {response.ReasonPhrase} ({(int)response.StatusCode})")
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected I4, but got Unknown
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			Response = response;
			StatusCode = response.StatusCode;
			ReasonPhrase = response.ReasonPhrase;
			WebResponse = webResponse;
		}
	}

	public class HttpWebException : WebException
	{
		[field: CompilerGenerated]
		public HttpRequestFailedException InnerHttpException
		{
			[CompilerGenerated]
			get;
		}

		public HttpStatusCode StatusCode => InnerHttpException.StatusCode;

		public HttpWebException(string message, HttpRequestFailedException ex)
			: base(message, (System.Exception)(object)ex)
		{
			InnerHttpException = ex;
		}
	}

	public class ResponsedWebException : WebException
	{
		[field: CompilerGenerated]
		public string Response
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public ResponsedWebException(string Message, string Response, System.Exception InnerException)
			: base(Message, InnerException)
		{
			this.Response = Response;
		}
	}

	public class NetSource
	{
		public int Id;

		public string Url;

		public int FailCount;

		public System.Exception Ex;

		public NetThread Thread;

		public bool IsFailed;

		public virtual string ToString()
		{
			return Url;
		}
	}

	public enum NetState
	{
		WaitForCheck = -1,
		WaitForDownload,
		Connect,
		Get,
		Download,
		Merge,
		WaitForCopy,
		Finish,
		Error
	}

	public enum NetPreDownloadBehaviour
	{
		HintWhileExists,
		ExitWhileExistsOrDownloading,
		IgnoreCheck
	}

	public class NetThread : System.Collections.Generic.IEnumerable<NetThread>
	{
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine_5_get_Next : System.Collections.Generic.IEnumerable<NetThread>, System.Collections.IEnumerable, System.Collections.Generic.IEnumerator<NetThread>, System.IDisposable, System.Collections.IEnumerator
		{
			public int _0024State;

			public NetThread _0024Current;

			public int _0024InitialThreadId;

			internal NetThread _0024VB_0024Me;

			internal NetThread _0024VB_0024ResumableLocal_CurrentChain_00240;

			public NetThread Current => _0024Current;

			object System.Collections.IEnumerator.Current => _0024Current;

			public VB_0024StateMachine_5_get_Next(int _0024State)
			{
				this._0024State = _0024State;
				_0024InitialThreadId = Environment.CurrentManagedThreadId;
			}

			private void Dispose()
			{
				_0024State = -2;
			}

			void System.IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Dispose
				this.Dispose();
			}

			[CompilerGenerated]
			private bool MoveNext()
			{
				switch (_0024State)
				{
				default:
					return false;
				case 0:
				{
					int num = (_0024State = -1);
					_0024VB_0024ResumableLocal_CurrentChain_00240 = _0024VB_0024Me;
					break;
				}
				case 1:
				{
					int num = (_0024State = -1);
					_0024VB_0024ResumableLocal_CurrentChain_00240 = _0024VB_0024ResumableLocal_CurrentChain_00240.NextThread;
					break;
				}
				}
				if (_0024VB_0024ResumableLocal_CurrentChain_00240 != null)
				{
					_0024Current = _0024VB_0024ResumableLocal_CurrentChain_00240;
					int num = (_0024State = 1);
					return true;
				}
				return false;
			}

			bool System.Collections.IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private System.Collections.Generic.IEnumerator<NetThread> GetEnumerator()
			{
				VB_0024StateMachine_5_get_Next result;
				if (_0024State == -2 && _0024InitialThreadId == Environment.CurrentManagedThreadId)
				{
					_0024State = 0;
					result = this;
				}
				else
				{
					result = new VB_0024StateMachine_5_get_Next(0)
					{
						_0024VB_0024Me = _0024VB_0024Me
					};
				}
				return result;
			}

			System.Collections.Generic.IEnumerator<NetThread> System.Collections.Generic.IEnumerable<NetThread>.GetEnumerator()
			{
				//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
				return this.GetEnumerator();
			}

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return (System.Collections.IEnumerator)GetEnumerator();
			}

			private void Reset()
			{
				//IL_0000: Unknown result type (might be due to invalid IL or missing references)
				throw new NotSupportedException();
			}

			void System.Collections.IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in Reset
				this.Reset();
			}
		}

		public NetFile Task;

		public Thread Thread;

		public NetThread NextThread;

		public int Uuid;

		public string Temp;

		public long DownloadStart;

		public long DownloadDone;

		private long SpeedLastTime;

		private long SpeedLastDone;

		private long _Speed;

		public long InitTime;

		public long LastReceiveTime;

		public NetState State;

		public NetSource Source;

		private System.Collections.Generic.IEnumerable<NetThread> Next => new VB_0024StateMachine_5_get_Next(-2)
		{
			_0024VB_0024Me = this
		};

		public bool IsFirstThread
		{
			get
			{
				if (DownloadStart == 0L)
				{
					return Task.FileSize == -2;
				}
				return false;
			}
		}

		public long DownloadEnd
		{
			get
			{
				object lockChain = Task.LockChain;
				ObjectFlowControl.CheckForSyncLockOnValueType(lockChain);
				bool flag = false;
				checked
				{
					try
					{
						Monitor.Enter(lockChain, ref flag);
						if (NextThread == null)
						{
							if (Task.IsUnknownSize)
							{
								return 5368709120L;
							}
							return Task.FileSize - 1;
						}
						return NextThread.DownloadStart - 1;
					}
					finally
					{
						if (flag)
						{
							Monitor.Exit(lockChain);
						}
					}
				}
			}
		}

		public long DownloadUndone => checked(DownloadEnd - (DownloadStart + DownloadDone) + 1);

		public long Speed
		{
			get
			{
				checked
				{
					if (TimeUtils.GetTimeTick() - SpeedLastTime > 200)
					{
						long num = TimeUtils.GetTimeTick() - SpeedLastTime;
						_Speed = (long)Math.Round((double)(DownloadDone - SpeedLastDone) / ((double)num / 1000.0));
						SpeedLastDone = DownloadDone;
						SpeedLastTime += num;
					}
					return _Speed;
				}
			}
		}

		public bool IsEnded
		{
			get
			{
				if (State != NetState.Finish)
				{
					return State == NetState.Error;
				}
				return true;
			}
		}

		public NetThread()
		{
			DownloadDone = 0L;
			SpeedLastTime = TimeUtils.GetTimeTick();
			SpeedLastDone = 0L;
			_Speed = 0L;
			InitTime = TimeUtils.GetTimeTick();
			LastReceiveTime = -1L;
			State = NetState.WaitForDownload;
		}

		public System.Collections.Generic.IEnumerator<NetThread> GetEnumerator()
		{
			return Next.GetEnumerator();
		}

		System.Collections.Generic.IEnumerator<NetThread> System.Collections.Generic.IEnumerable<NetThread>.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetEnumerator
			return this.GetEnumerator();
		}

		private System.Collections.IEnumerator IEnumerable_GetEnumerator()
		{
			return (System.Collections.IEnumerator)Next.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			//ILSpy generated this explicit interface implementation from .override directive in IEnumerable_GetEnumerator
			return this.IEnumerable_GetEnumerator();
		}
	}

	public class NetFile
	{
		public ModBase.SafeList<LoaderDownload> Tasks;

		public ModBase.SafeList<NetSource> Sources;

		private int FirstThreadSource;

		public ModBase.SafeList<NetSource> SourcesOnce;

		public string LocalPath;

		public string LocalName;

		public NetState State;

		public List<System.Exception> Ex;

		public NetThread Threads;

		public long FileSize;

		public bool IsUnknownSize;

		private Queue<byte> SmailFileCache;

		public long DownloadDone;

		private readonly object LockDone;

		public ModBase.FileChecker Check;

		public bool UseBrowserUserAgent;

		public bool AllowMuiltThread;

		public string CustomUserAgent;

		private long SpeedLastTime;

		private long SpeedLastDone;

		private long _Speed;

		public bool IsCopy;

		private int ConnectCount;

		private long ConnectTime;

		private const long FilePieceLimit = 262144L;

		public readonly object LockCount;

		public readonly object LockState;

		public readonly object LockChain;

		public readonly object LockSource;

		public readonly int Uuid;

		public bool IsNoSplit
		{
			get
			{
				if (!IsUnknownSize)
				{
					return FileSize < 262144;
				}
				return true;
			}
		}

		public long Speed
		{
			get
			{
				checked
				{
					if (TimeUtils.GetTimeTick() - SpeedLastTime > 200)
					{
						long num = TimeUtils.GetTimeTick() - SpeedLastTime;
						_Speed = (long)Math.Round((double)(DownloadDone - SpeedLastDone) / ((double)num / 1000.0));
						SpeedLastDone = DownloadDone;
						SpeedLastTime += num;
					}
					return _Speed;
				}
			}
		}

		public double Progress
		{
			get
			{
				switch (State)
				{
				case NetState.WaitForCheck:
					return 0.0;
				case NetState.WaitForCopy:
					return 0.2;
				case NetState.WaitForDownload:
					return 0.01;
				case NetState.Connect:
					return 0.02;
				case NetState.Get:
					return 0.04;
				case NetState.Download:
				{
					double num = (IsUnknownSize ? 0.5 : ((double)DownloadDone / (double)Math.Max(FileSize, 1L)));
					num = 1.0 - Math.Pow(1.0 - num, 0.9);
					return num * 0.93 + 0.05;
				}
				case NetState.Merge:
					return 0.99;
				case NetState.Finish:
				case NetState.Error:
					return 1.0;
				default:
					return 0.5;
				}
			}
		}

		private int ConnectAverage
		{
			get
			{
				object lockCount = LockCount;
				ObjectFlowControl.CheckForSyncLockOnValueType(lockCount);
				bool flag = false;
				try
				{
					Monitor.Enter(lockCount, ref flag);
					return checked((int)Math.Round((ConnectCount == 0) ? (-1.0) : ((double)ConnectTime / (double)ConnectCount)));
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(lockCount);
					}
				}
			}
		}

		private NetSource GetSource(int Id = 0)
		{
			if (Id >= ((List<NetSource>)Sources).Count || Id < 0)
			{
				Id = 0;
			}
			object lockSource = LockSource;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockSource);
			bool flag = false;
			try
			{
				Monitor.Enter(lockSource, ref flag);
				if (!IsSourceFailed(AllowOnceSource: false))
				{
					NetSource netSource = ((List<NetSource>)Sources)[Id];
					while (netSource.IsFailed)
					{
						Id = checked(Id + 1);
						if (Id >= ((List<NetSource>)Sources).Count)
						{
							Id = 0;
						}
						netSource = ((List<NetSource>)Sources)[Id];
					}
					return netSource;
				}
				if (Enumerable.Any<NetSource>((System.Collections.Generic.IEnumerable<NetSource>)SourcesOnce))
				{
					return ((List<NetSource>)SourcesOnce)[0];
				}
				return null;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(lockSource);
				}
			}
		}

		public bool IsSourceFailed(bool AllowOnceSource = true)
		{
			if (AllowOnceSource && Enumerable.Any<NetSource>((System.Collections.Generic.IEnumerable<NetSource>)SourcesOnce))
			{
				return false;
			}
			object lockSource = LockSource;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockSource);
			bool flag = false;
			try
			{
				Monitor.Enter(lockSource, ref flag);
				System.Collections.Generic.IEnumerator<NetSource> enumerator = default(System.Collections.Generic.IEnumerator<NetSource>);
				try
				{
					enumerator = Sources.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						if (!enumerator.Current.IsFailed)
						{
							return false;
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
				if (flag)
				{
					Monitor.Exit(lockSource);
				}
			}
			return true;
		}

		public virtual bool Equals(object obj)
		{
			if (obj is NetFile netFile)
			{
				return Uuid == netFile.Uuid;
			}
			return false;
		}

		public NetFile(System.Collections.Generic.IEnumerable<string> Urls, string LocalPath, ModBase.FileChecker Check = null, bool UseBrowserUserAgent = false, string CustomUserAgent = "")
		{
			Tasks = new ModBase.SafeList<LoaderDownload>();
			FirstThreadSource = 0;
			SourcesOnce = new ModBase.SafeList<NetSource>();
			this.LocalPath = null;
			LocalName = null;
			State = NetState.WaitForCheck;
			Ex = new List<System.Exception>();
			FileSize = -2L;
			IsUnknownSize = false;
			DownloadDone = 0L;
			LockDone = RuntimeHelpers.GetObjectValue(new object());
			AllowMuiltThread = true;
			this.CustomUserAgent = "";
			SpeedLastTime = TimeUtils.GetTimeTick();
			SpeedLastDone = 0L;
			_Speed = 0L;
			IsCopy = false;
			ConnectCount = 0;
			ConnectTime = 0L;
			LockCount = RuntimeHelpers.GetObjectValue(new object());
			LockState = RuntimeHelpers.GetObjectValue(new object());
			LockChain = RuntimeHelpers.GetObjectValue(new object());
			LockSource = RuntimeHelpers.GetObjectValue(new object());
			Uuid = ModBase.GetUuid();
			List<NetSource> val = new List<NetSource>();
			int num = 0;
			Urls = Enumerable.ToArray<string>(Enumerable.Distinct<string>(Urls));
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = Urls.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					string current = enumerator.Current;
					val.Add(new NetSource
					{
						FailCount = 0,
						Url = Conversions.ToString(ModSecret.SecretCdnSign(current.Replace("\r", "").Replace("\n", "").Trim())),
						Id = num,
						IsFailed = false,
						Ex = null
					});
					num = checked(num + 1);
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			Sources = new ModBase.SafeList<NetSource>((System.Collections.Generic.IEnumerable<NetSource>)val);
			this.LocalPath = LocalPath;
			this.Check = Check;
			this.UseBrowserUserAgent = UseBrowserUserAgent;
			this.CustomUserAgent = CustomUserAgent;
			LocalName = ModBase.GetFileNameFromPath(LocalPath);
		}

		public NetThread TryBeginThread()
		{
			//IL_0344: Unknown result type (might be due to invalid IL or missing references)
			//IL_034e: Expected O, but got Unknown
			//IL_0349: Unknown result type (might be due to invalid IL or missing references)
			//IL_034e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0386: Unknown result type (might be due to invalid IL or missing references)
			//IL_038e: Expected O, but got Unknown
			checked
			{
				NetThread result;
				try
				{
					Thread val;
					NetThread netThread;
					if (NetTaskThreadCount >= NetTaskThreadLimit || IsSourceFailed() || (IsNoSplit && Threads != null && Threads.State != NetState.Error))
					{
						result = null;
					}
					else if (State >= NetState.Merge || State == NetState.WaitForCheck)
					{
						result = null;
					}
					else
					{
						object lockState = LockState;
						ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
						bool flag = false;
						try
						{
							Monitor.Enter(lockState, ref flag);
							if (State < NetState.Connect)
							{
								State = NetState.Connect;
							}
						}
						finally
						{
							if (flag)
							{
								Monitor.Exit(lockState);
							}
						}
						NetSource netSource = null;
						object lockChain = LockChain;
						ObjectFlowControl.CheckForSyncLockOnValueType(lockChain);
						bool flag2 = false;
						try
						{
							Monitor.Enter(lockChain, ref flag2);
							if (IsNoSplit)
							{
								goto IL_00f0;
							}
							if (!IsSourceFailed(AllowOnceSource: false))
							{
								goto IL_0159;
							}
							if (((List<NetSource>)SourcesOnce)[0].Thread == null || ((List<NetSource>)SourcesOnce)[0].Thread.State == NetState.Error)
							{
								goto IL_00f0;
							}
							result = null;
							goto end_IL_00a0;
							IL_00f0:
							SmailFileCache = null;
							Threads = null;
							NetManager.DownloadDone -= DownloadDone;
							object lockDone = LockDone;
							ObjectFlowControl.CheckForSyncLockOnValueType(lockDone);
							bool flag3 = false;
							try
							{
								Monitor.Enter(lockDone, ref flag3);
								DownloadDone = 0L;
							}
							finally
							{
								if (flag3)
								{
									Monitor.Exit(lockDone);
								}
							}
							SpeedLastDone = 0L;
							State = NetState.Get;
							goto IL_0159;
							IL_02f3:
							long num;
							if ((num > FileSize && FileSize >= 0 && !IsUnknownSize) || num < 0 || Information.IsNothing((object)netSource))
							{
								result = null;
							}
							else
							{
								int uuid = ModBase.GetUuid();
								if (Enumerable.Any<LoaderDownload>((System.Collections.Generic.IEnumerable<LoaderDownload>)Tasks))
								{
									val = new Thread((ParameterizedThreadStart)([SpecialName] [CompilerGenerated] (object a0) =>
									{
										Thread((NetThread)a0);
									}))
									{
										Name = $"NetTask {((List<LoaderDownload>)Tasks)[0].Uuid}/{Uuid} Download {uuid}#",
										Priority = (ThreadPriority)1
									};
									netThread = new NetThread
									{
										Uuid = uuid,
										DownloadStart = num,
										Thread = val,
										Source = netSource,
										Task = this,
										State = NetState.WaitForDownload
									};
									if (netThread.IsFirstThread || Threads == null)
									{
										Threads = netThread;
									}
									else
									{
										NetThread netThread2 = Threads;
										while (netThread2.DownloadEnd <= num)
										{
											netThread2 = netThread2.NextThread;
										}
										netThread.NextThread = netThread2.NextThread;
										netThread2.NextThread = netThread;
									}
									goto IL_041d;
								}
								result = null;
							}
							goto end_IL_00a0;
							IL_0159:
							if (Threads == null)
							{
								num = 0L;
								netSource = GetSource(FirstThreadSource);
								FirstThreadSource = netSource.Id + 1;
								goto IL_02f3;
							}
							System.Collections.Generic.IEnumerator<NetThread> enumerator = default(System.Collections.Generic.IEnumerator<NetThread>);
							try
							{
								enumerator = Threads.GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator).MoveNext())
								{
									NetThread current = enumerator.Current;
									if (current.State != NetState.Error || current.DownloadUndone <= 0)
									{
										continue;
									}
									num = current.DownloadStart + current.DownloadDone;
									netSource = GetSource(current.Source.Id + 1);
									goto IL_02f3;
								}
							}
							finally
							{
								((System.IDisposable)enumerator)?.Dispose();
							}
							string url = GetSource().Url;
							if (!AllowMuiltThread || url.Contains("pcl2-server") || url.Contains("bmclapi") || url.Contains("github.com") || url.Contains("optifine.net") || url.Contains("modrinth") || url.Contains("gitcode"))
							{
								result = null;
							}
							else
							{
								NetThread netThread3 = Threads;
								System.Collections.Generic.IEnumerator<NetThread> enumerator2 = default(System.Collections.Generic.IEnumerator<NetThread>);
								try
								{
									enumerator2 = Threads.GetEnumerator();
									while (((System.Collections.IEnumerator)enumerator2).MoveNext())
									{
										NetThread current2 = enumerator2.Current;
										if (current2.DownloadUndone > netThread3.DownloadUndone)
										{
											netThread3 = current2;
										}
									}
								}
								finally
								{
									((System.IDisposable)enumerator2)?.Dispose();
								}
								if (netThread3 != null && netThread3.DownloadUndone >= 262144)
								{
									num = (long)Math.Round((double)netThread3.DownloadEnd - (double)netThread3.DownloadUndone * 0.4);
									netSource = GetSource();
									goto IL_02f3;
								}
								result = null;
							}
							end_IL_00a0:;
						}
						finally
						{
							if (flag2)
							{
								Monitor.Exit(lockChain);
							}
						}
					}
					goto end_IL_0000;
					IL_041d:
					object netTaskThreadCountLock = NetTaskThreadCountLock;
					ObjectFlowControl.CheckForSyncLockOnValueType(netTaskThreadCountLock);
					bool flag4 = false;
					try
					{
						Monitor.Enter(netTaskThreadCountLock, ref flag4);
						NetTaskThreadCount++;
					}
					finally
					{
						if (flag4)
						{
							Monitor.Exit(netTaskThreadCountLock);
						}
					}
					object lockSource = LockSource;
					ObjectFlowControl.CheckForSyncLockOnValueType(lockSource);
					bool flag5 = false;
					try
					{
						Monitor.Enter(lockSource, ref flag5);
						if (IsSourceFailed(AllowOnceSource: false))
						{
							((List<NetSource>)SourcesOnce)[0].Thread = netThread;
						}
					}
					finally
					{
						if (flag5)
						{
							Monitor.Exit(lockSource);
						}
					}
					val.Start((object)netThread);
					result = netThread;
					end_IL_0000:;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "尝试开始下载线程失败（" + (LocalName ?? "Nothing") + "）", ModBase.LogLevel.Hint);
					result = null;
					ProjectData.ClearProjectError();
				}
				return result;
			}
		}

		private void Thread(NetThread Info)
		{
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Expected O, but got Unknown
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Expected O, but got Unknown
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Expected O, but got Unknown
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0c95: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ad: Expected O, but got Unknown
			//IL_058f: Unknown result type (might be due to invalid IL or missing references)
			//IL_09fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_09c4: Unknown result type (might be due to invalid IL or missing references)
			if (ModBase.ModeDebug || Info.DownloadStart == 0L)
			{
				ModBase.Log(string.Concat(new string[8]
				{
					"[Download] ",
					LocalName,
					" ",
					Conversions.ToString(Info.Uuid),
					"#：开始，起始点 ",
					Conversions.ToString(Info.DownloadStart),
					"，",
					Info.Source.Url
				}));
			}
			Stream val = null;
			checked
			{
				int num = Math.Min(Math.Max(ConnectAverage, 6000) * (1 + Info.Source.FailCount), 25000);
				long num2 = 0L;
				Info.State = NetState.Connect;
				try
				{
					int num3 = 0;
					if (!((List<NetSource>)SourcesOnce).Contains(Info.Source) || ((object)Info).Equals((object)Info.Source.Thread))
					{
						HttpRequestMessage Client = new HttpRequestMessage(HttpMethod.Get, Info.Source.Url);
						ModSecret.SecretHeadersSign(Info.Source.Url, ref Client, UseBrowserUserAgent, CustomUserAgent);
						if (!Info.IsFirstThread || Info.DownloadStart != 0L)
						{
							Client.Headers.Range = unchecked(new RangeHeaderValue((long?)Info.DownloadStart, (long?)null));
						}
						CancellationTokenSource val2 = new CancellationTokenSource();
						try
						{
							val2.CancelAfter(num);
							HttpResponseMessage result = NetworkService.GetClient().SendAsync(Client, (HttpCompletionOption)1, val2.Token).Result;
							try
							{
								EnsureSuccessStatusCode(result);
								if (State != NetState.Error)
								{
									string originalString = result.RequestMessage.RequestUri.OriginalString;
									if (Operators.CompareString(originalString, Info.Source.Url, false) != 0)
									{
										ModBase.Log($"[Download] {LocalName} {Info.Uuid}#：重定向至 {originalString}");
										Info.Source.Url = originalString;
									}
									num2 = result.Content.Headers.ContentLength.GetValueOrDefault(-1L);
									if (num2 == -1)
									{
										if (FileSize > 1)
										{
											if (Info.DownloadStart != 0L)
											{
												ModBase.Log($"[Download] {LocalName} {Info.Uuid}#：ContentLength 返回了 -1，无法确定是否支持分段下载，视作不支持");
												goto IL_04f3;
											}
											ModBase.Log($"[Download] {LocalName} {Info.Uuid}#：文件大小未知，但已从其他下载源获取，不作处理");
										}
										else
										{
											FileSize = -1L;
											IsUnknownSize = true;
											ModBase.Log($"[Download] {LocalName} {Info.Uuid}#：文件大小未知");
										}
									}
									else
									{
										if (num2 < 0)
										{
											throw new System.Exception("获取片大小失败，结果为 " + Conversions.ToString(num2) + "。");
										}
										if (Info.IsFirstThread)
										{
											if (Check != null)
											{
												if (num2 < Check.MinSize && Check.MinSize > 0)
												{
													throw new System.Exception($"文件大小不足，获取结果为 {num2}，要求至少为 {Check.MinSize}。");
												}
												if (num2 != Check.ActualSize && Check.ActualSize > 0)
												{
													throw new System.Exception($"文件大小不一致，获取结果为 {num2}，要求必须为 {Check.ActualSize}。");
												}
											}
											FileSize = num2;
											IsUnknownSize = false;
											ModBase.Log(string.Format("[Download] {0} {1}#：文件大小 {2}（{3}）", new object[4]
											{
												LocalName,
												Info.Uuid,
												num2,
												ModBase.GetString(num2)
											}));
											if (num2 > 52428800)
											{
												DriveInfo[] drives = DriveInfo.GetDrives();
												foreach (DriveInfo val3 in drives)
												{
													string text = Enumerable.First<char>((System.Collections.Generic.IEnumerable<char>)val3.Name).ToString();
													double num4 = (ModBase.StartsWithF(ModBase.PathTemp, text) ? ((double)num2 * 1.1) : 0.0) + (double)(ModBase.StartsWithF(LocalPath, text) ? (num2 + 5242880) : 0);
													if ((double)val3.TotalFreeSpace < num4)
													{
														throw new System.Exception(string.Concat(new string[7]
														{
															text,
															" 盘空间不足，无法进行下载。\r\n需要至少 ",
															ModBase.GetString((long)Math.Round(num4)),
															" 空间，但当前仅剩余 ",
															ModBase.GetString(val3.TotalFreeSpace),
															"。",
															ModBase.StartsWithF(ModBase.PathTemp, text) ? "\r\n\r\n下载时需要与文件同等大小的空间存放缓存，你可以在设置中调整缓存文件夹的位置。" : ""
														}));
													}
												}
											}
										}
										else
										{
											if (FileSize < 0)
											{
												throw new System.Exception("非首线程运行时，尚未获取文件大小");
											}
											if (Info.DownloadStart > 0 && num2 == FileSize)
											{
												goto IL_04f3;
											}
											if (FileSize - Info.DownloadStart != num2)
											{
												throw new WebException(string.Format("获取到的分段大小不一致：Range 起始于 {0}，预期 ContentLength 为 {1}，返回 ContentLength 为 {2}，总文件大小 {3}", new object[4]
												{
													Info.DownloadStart,
													FileSize - Info.DownloadStart,
													num2,
													FileSize
												}));
											}
										}
									}
									Info.State = NetState.Get;
									object lockState = LockState;
									ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
									bool flag = false;
									try
									{
										Monitor.Enter(lockState, ref flag);
										if (State < NetState.Get)
										{
											State = NetState.Get;
										}
									}
									finally
									{
										if (flag)
										{
											Monitor.Exit(lockState);
										}
									}
									if (IsNoSplit)
									{
										Info.Temp = null;
										SmailFileCache = new Queue<byte>();
									}
									else
									{
										Info.Temp = string.Format("{0}Download\\{1}_{2}_{3}.tmp", new object[4]
										{
											ModBase.PathTemp,
											Uuid,
											Info.Uuid,
											RandomUtils.NextInt(0, 999999)
										});
										val = (Stream)new FileStream(Info.Temp, (FileMode)2, (FileAccess)2, (FileShare)1);
									}
									Stream result2 = result.Content.ReadAsStreamAsync().Result;
									try
									{
										if (Conversions.ToBoolean(ModBase.Setup.Get("SystemDebugDelay")))
										{
											System.Threading.Thread.Sleep(RandomUtils.NextInt(50, 3000));
										}
										byte[] array = new byte[16385];
										num3 = result2.Read(array, 0, 16384);
										System.Collections.Generic.IEnumerator<LoaderDownload> enumerator = default(System.Collections.Generic.IEnumerator<LoaderDownload>);
										while ((IsUnknownSize || Info.DownloadUndone > 0) && num3 > 0 && !ModBase.IsProgramEnded && State < NetState.Merge && (!Info.Source.IsFailed || ((object)Info).Equals((object)Info.Source.Thread)))
										{
											while (NetTaskSpeedLimitHigh > 0 && NetTaskSpeedLimitLeft <= 0)
											{
												System.Threading.Thread.Sleep(8);
											}
											int num5 = (int)(IsUnknownSize ? num3 : Math.Min(unchecked((long)num3), Info.DownloadUndone));
											object netTaskSpeedLimitLeftLock = NetTaskSpeedLimitLeftLock;
											ObjectFlowControl.CheckForSyncLockOnValueType(netTaskSpeedLimitLeftLock);
											bool flag2 = false;
											try
											{
												Monitor.Enter(netTaskSpeedLimitLeftLock, ref flag2);
												if (NetTaskSpeedLimitHigh > 0)
												{
													NetTaskSpeedLimitLeft -= num5;
												}
											}
											finally
											{
												if (flag2)
												{
													Monitor.Exit(netTaskSpeedLimitLeftLock);
												}
											}
											long num6 = TimeUtils.GetTimeTick() - Info.LastReceiveTime;
											if (num6 > 1000000)
											{
												num6 = 1L;
											}
											if (num5 > 0)
											{
												if (Info.DownloadDone == 0L)
												{
													Info.State = NetState.Download;
													object lockState2 = LockState;
													ObjectFlowControl.CheckForSyncLockOnValueType(lockState2);
													bool flag3 = false;
													try
													{
														Monitor.Enter(lockState2, ref flag3);
														if (State < NetState.Download)
														{
															State = NetState.Download;
														}
													}
													finally
													{
														if (flag3)
														{
															Monitor.Exit(lockState2);
														}
													}
													object lockCount = LockCount;
													ObjectFlowControl.CheckForSyncLockOnValueType(lockCount);
													bool flag4 = false;
													try
													{
														Monitor.Enter(lockCount, ref flag4);
														ConnectCount++;
														ConnectTime += TimeUtils.GetTimeTick() - Info.InitTime;
													}
													finally
													{
														if (flag4)
														{
															Monitor.Exit(lockCount);
														}
													}
												}
												object lockCount2 = LockCount;
												ObjectFlowControl.CheckForSyncLockOnValueType(lockCount2);
												bool flag5 = false;
												try
												{
													Monitor.Enter(lockCount2, ref flag5);
													Info.Source.FailCount = 0;
													try
													{
														enumerator = Tasks.GetEnumerator();
														while (((System.Collections.IEnumerator)enumerator).MoveNext())
														{
															enumerator.Current.FailCount = 0;
														}
													}
													finally
													{
														((System.IDisposable)enumerator)?.Dispose();
													}
												}
												finally
												{
													if (flag5)
													{
														Monitor.Exit(lockCount2);
													}
												}
												NetManager.DownloadDone += num5;
												object lockDone = LockDone;
												ObjectFlowControl.CheckForSyncLockOnValueType(lockDone);
												bool flag6 = false;
												try
												{
													Monitor.Enter(lockDone, ref flag6);
													DownloadDone += num5;
												}
												finally
												{
													if (flag6)
													{
														Monitor.Exit(lockDone);
													}
												}
												Info.DownloadDone += num5;
												if (IsNoSplit)
												{
													if (Enumerable.Count<byte>((System.Collections.Generic.IEnumerable<byte>)array) == num5)
													{
														byte[] array2 = array;
														foreach (byte b in array2)
														{
															SmailFileCache.Enqueue(b);
														}
													}
													else
													{
														int num7 = num5 - 1;
														for (int k = 0; k <= num7; k++)
														{
															SmailFileCache.Enqueue(array[k]);
														}
													}
												}
												else
												{
													val.Write(array, 0, num5);
												}
												if (num6 > 1500 && num6 > num5)
												{
													throw new TimeoutException(string.Concat(new string[5]
													{
														"由于速度过慢断开链接，下载 ",
														Conversions.ToString(num5),
														" B，消耗 ",
														Conversions.ToString(num6),
														" ms。"
													}));
												}
												Info.LastReceiveTime = TimeUtils.GetTimeTick();
												if (Info.DownloadUndone == 0L && !IsUnknownSize)
												{
													break;
												}
											}
											else if (Info.LastReceiveTime > 0 && num6 > num)
											{
												throw new TimeoutException("操作超时，无数据。");
											}
											num3 = result2.Read(array, 0, 16384);
										}
									}
									finally
									{
										((System.IDisposable)result2)?.Dispose();
									}
								}
								goto end_IL_0172;
								IL_04f3:
								object lockSource = LockSource;
								ObjectFlowControl.CheckForSyncLockOnValueType(lockSource);
								bool flag7 = false;
								try
								{
									Monitor.Enter(lockSource, ref flag7);
									if (!((List<NetSource>)SourcesOnce).Contains(Info.Source))
									{
										((List<NetSource>)SourcesOnce).Add(Info.Source);
										goto IL_0545;
									}
								}
								finally
								{
									if (flag7)
									{
										Monitor.Exit(lockSource);
									}
								}
								goto end_IL_0172;
								IL_0545:
								throw new WebException(string.Format("该下载源不支持分段下载：Range 起始于 {0}，预期 ContentLength 为 {1}，返回 ContentLength 为 {2}，总文件大小 {3}", new object[4]
								{
									Info.DownloadStart,
									FileSize - Info.DownloadStart,
									num2,
									FileSize
								}));
								end_IL_0172:;
							}
							finally
							{
								((System.IDisposable)result)?.Dispose();
							}
						}
						finally
						{
							((System.IDisposable)val2)?.Dispose();
						}
					}
					if (State == NetState.Error || Info.Source.IsFailed || (Info.DownloadUndone > 0 && !IsUnknownSize))
					{
						Info.State = NetState.Error;
						ModBase.Log($"[Download] {LocalName} {Info.Uuid}#：中断");
						return;
					}
					if (num3 == 0 && Info.DownloadUndone > 0 && !IsUnknownSize)
					{
						throw new System.Exception($"返回的 ContentLength 过多：ContentLength 为 {num2}，但获取到的总数据量仅为 {Info.DownloadDone}（全文件总数据量 {DownloadDone}）");
					}
					Info.State = NetState.Finish;
					if (ModBase.ModeDebug)
					{
						ModBase.Log($"[Download] {LocalName} {Info.Uuid}#：完成，已下载 {Info.DownloadDone}");
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					object lockCount3 = LockCount;
					ObjectFlowControl.CheckForSyncLockOnValueType(lockCount3);
					bool flag8 = false;
					try
					{
						Monitor.Enter(lockCount3, ref flag8);
						Info.Source.FailCount++;
						System.Collections.Generic.IEnumerator<LoaderDownload> enumerator2 = default(System.Collections.Generic.IEnumerator<LoaderDownload>);
						try
						{
							enumerator2 = Tasks.GetEnumerator();
							while (((System.Collections.IEnumerator)enumerator2).MoveNext())
							{
								enumerator2.Current.FailCount++;
							}
						}
						finally
						{
							((System.IDisposable)enumerator2)?.Dispose();
						}
					}
					finally
					{
						if (flag8)
						{
							Monitor.Exit(lockCount3);
						}
					}
					string text2 = ex2.ToString().ToLower().Replace(" ", "");
					bool flag9 = text2.Contains("由于连接方在一段时间后没有正确答复或连接的主机没有反应") || text2.Contains("超时") || text2.Contains("timeout") || text2.Contains("timedout") || ex2.GetType() == typeof(TimeoutException) || ex2.GetType() == typeof(TaskCanceledException) || (ex2.GetType() == typeof(AggregateException) && Enumerable.Any<System.Exception>((System.Collections.Generic.IEnumerable<System.Exception>)((AggregateException)ex2).InnerExceptions, (Func<System.Exception, bool>)([SpecialName] (System.Exception x) => x.GetType() == typeof(TaskCanceledException) || x.GetType() == typeof(TimeoutException))));
					ModBase.Log(string.Concat(new string[5]
					{
						"[Download] ",
						LocalName,
						" ",
						Conversions.ToString(Info.Uuid),
						flag9 ? ("#：超时（" + Conversions.ToString((double)num * 0.001) + "s）") : ("#：出错，" + ex2.ToString())
					}));
					Info.State = NetState.Error;
					Info.Source.Ex = ex2;
					if (ex2.Message.Contains("该下载源不支持") || ex2.Message.Contains("未能解析") || ex2.Message.Contains("404 (") || ex2.Message.Contains("502 (") || ex2.Message.Contains("无返回数据") || ex2.Message.Contains("空间不足") || ex2.Message.Contains("获取到的分段大小不一致") || (ex2.Message.Contains("403 (") && !ModBase.ContainsF(Info.Source.Url, "bmclapi")) || ((double)Info.Source.FailCount >= ModBase.MathClamp(NetTaskThreadLimit, 5.0, 30.0) && DownloadDone < 1) || Info.Source.FailCount > NetTaskThreadLimit + 2)
					{
						bool flag10 = false;
						object lockSource2 = LockSource;
						ObjectFlowControl.CheckForSyncLockOnValueType(lockSource2);
						bool flag11 = false;
						try
						{
							Monitor.Enter(lockSource2, ref flag11);
							if (Info.Source.Thread != null && ((object)Info.Source.Thread).Equals((object)Info))
							{
								((List<NetSource>)SourcesOnce).RemoveAt(0);
								goto IL_0ec2;
							}
							if (!Info.Source.IsFailed)
							{
								goto IL_0ec2;
							}
							goto end_IL_0e7e;
							IL_0ec2:
							Info.Source.IsFailed = true;
							flag10 = true;
							end_IL_0e7e:;
						}
						finally
						{
							if (flag11)
							{
								Monitor.Exit(lockSource2);
							}
						}
						if (flag10)
						{
							ModBase.Log(string.Format("[Download] {0} {1}#：下载源被禁用（{2}）：{3}", new object[4]
							{
								LocalName,
								Info.Uuid,
								Info.Source.Id,
								Info.Source.Url
							}));
							ModBase.Log(ex2, "下载源 " + Conversions.ToString(Info.Source.Id) + " 已被禁用", (ex2.Message.Contains("不支持分段下载") || ex2.Message.Contains("(404)") || ex2.Message.Contains("(416)")) ? ModBase.LogLevel.Developer : ModBase.LogLevel.Debug);
							if (IsSourceFailed())
							{
								ModBase.Log("[Download] 文件 " + LocalName + " 已无可用下载源");
								System.Exception raiseEx = null;
								object lockSource3 = LockSource;
								ObjectFlowControl.CheckForSyncLockOnValueType(lockSource3);
								bool flag12 = false;
								try
								{
									Monitor.Enter(lockSource3, ref flag12);
									System.Collections.Generic.IEnumerator<NetSource> enumerator3 = default(System.Collections.Generic.IEnumerator<NetSource>);
									try
									{
										enumerator3 = Sources.GetEnumerator();
										while (((System.Collections.IEnumerator)enumerator3).MoveNext())
										{
											NetSource current = enumerator3.Current;
											ModBase.Log("[Download] 已禁用的下载源：" + current.Url);
											if (current.Ex != null)
											{
												raiseEx = current.Ex;
												ModBase.Log(current.Ex, "下载源禁用原因", ModBase.LogLevel.Developer);
											}
										}
									}
									finally
									{
										((System.IDisposable)enumerator3)?.Dispose();
									}
								}
								finally
								{
									if (flag12)
									{
										Monitor.Exit(lockSource3);
									}
								}
								Fail(raiseEx);
							}
							else if (ex2.Message.Contains("空间不足"))
							{
								Fail(ex2);
							}
						}
					}
					if (FileSize == -2)
					{
						object lockChain = LockChain;
						ObjectFlowControl.CheckForSyncLockOnValueType(lockChain);
						bool flag13 = false;
						try
						{
							Monitor.Enter(lockChain, ref flag13);
							Threads = null;
						}
						finally
						{
							if (flag13)
							{
								Monitor.Exit(lockChain);
							}
						}
					}
					ProjectData.ClearProjectError();
				}
				finally
				{
					if (val != null)
					{
						val.Dispose();
					}
					object netTaskThreadCountLock = NetTaskThreadCountLock;
					ObjectFlowControl.CheckForSyncLockOnValueType(netTaskThreadCountLock);
					bool flag14 = false;
					try
					{
						Monitor.Enter(netTaskThreadCountLock, ref flag14);
						NetTaskThreadCount--;
					}
					finally
					{
						if (flag14)
						{
							Monitor.Exit(netTaskThreadCountLock);
						}
					}
					if (((FileSize >= 0 && DownloadDone >= FileSize) || (FileSize == -1 && DownloadDone > 0)) && State < NetState.Merge)
					{
						Merge();
					}
				}
			}
		}

		private string GetFileNameFromResponse(HttpResponseMessage response)
		{
			return response.Content.Headers.ContentDisposition.FileName;
		}

		private void Merge()
		{
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected O, but got Unknown
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Expected O, but got Unknown
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Expected O, but got Unknown
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Expected O, but got Unknown
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Expected O, but got Unknown
			object lockState = LockState;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
			bool flag = false;
			try
			{
				Monitor.Enter(lockState, ref flag);
				if (State >= NetState.Merge)
				{
					return;
				}
				State = NetState.Merge;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(lockState);
				}
			}
			int num = 0;
			Stream val = null;
			BinaryWriter val2 = null;
			checked
			{
				System.Collections.Generic.IEnumerator<NetThread> enumerator = default(System.Collections.Generic.IEnumerator<NetThread>);
				System.Collections.Generic.IEnumerator<NetThread> enumerator2 = default(System.Collections.Generic.IEnumerator<NetThread>);
				System.Collections.Generic.IEnumerator<NetThread> enumerator3 = default(System.Collections.Generic.IEnumerator<NetThread>);
				while (true)
				{
					try
					{
						object lockChain = LockChain;
						ObjectFlowControl.CheckForSyncLockOnValueType(lockChain);
						bool flag2 = false;
						try
						{
							Monitor.Enter(lockChain, ref flag2);
							if (File.Exists(LocalPath))
							{
								File.Delete(LocalPath);
							}
							Directory.CreateDirectory(ModBase.GetPathFromFullPath(LocalPath));
							if (IsNoSplit)
							{
								if (ModBase.ModeDebug)
								{
									ModBase.Log($"[Download] {LocalName}：下载结束，从缓存输出文件，长度：" + Conversions.ToString(SmailFileCache.Count));
								}
								val = (Stream)new FileStream(LocalPath, (FileMode)2);
								val2 = new BinaryWriter(val);
								val2.Write(SmailFileCache.ToArray());
								val2.Dispose();
								val2 = null;
								val.Dispose();
								val = null;
							}
							else if (Threads.DownloadDone == DownloadDone && Threads.Temp != null)
							{
								if (ModBase.ModeDebug)
								{
									ModBase.Log($"[Download] {LocalName}：下载结束，仅有一个文件，无需合并");
								}
								ModBase.CopyFile(Threads.Temp, LocalPath);
							}
							else
							{
								if (ModBase.ModeDebug)
								{
									ModBase.Log($"[Download] {LocalName}：下载结束，开始合并文件");
								}
								val = (Stream)new FileStream(LocalPath, (FileMode)2);
								val2 = new BinaryWriter(val);
								try
								{
									enumerator = Threads.GetEnumerator();
									while (((System.Collections.IEnumerator)enumerator).MoveNext())
									{
										NetThread current = enumerator.Current;
										if (current.DownloadDone == 0L || current.Temp == null)
										{
											continue;
										}
										FileStream val3 = new FileStream(current.Temp, (FileMode)3, (FileAccess)1, (FileShare)1);
										try
										{
											BinaryReader val4 = new BinaryReader((Stream)(object)val3);
											try
											{
												val2.Write(val4.ReadBytes((int)current.DownloadDone));
											}
											finally
											{
												((System.IDisposable)val4)?.Dispose();
											}
										}
										finally
										{
											((System.IDisposable)val3)?.Dispose();
										}
									}
								}
								finally
								{
									((System.IDisposable)enumerator)?.Dispose();
								}
								val2.Dispose();
								val2 = null;
								val.Dispose();
								val = null;
							}
							if (!IsUnknownSize && Check != null)
							{
								if (Check.ActualSize == -1)
								{
									Check.ActualSize = FileSize;
								}
								else if (Check.ActualSize != FileSize)
								{
									throw new System.Exception($"文件大小不一致：任务要求为 {Check.ActualSize} B，网络获取结果为 {FileSize}B");
								}
							}
							string text = Check?.Check(LocalPath);
							if (text != null)
							{
								ModBase.Log($"[Download] {LocalName} 文件校验失败，下载线程细节：");
								try
								{
									enumerator2 = Threads.GetEnumerator();
									while (((System.Collections.IEnumerator)enumerator2).MoveNext())
									{
										NetThread current2 = enumerator2.Current;
										ModBase.Log(string.Format("[Download]     {0}#，状态 {1}，范围 {2}~{3}，完成 {4}，剩余 {5}", new object[6]
										{
											current2.Uuid,
											ModBase.GetStringFromEnum(current2.State),
											current2.DownloadStart,
											current2.DownloadStart + current2.DownloadDone,
											current2.DownloadDone,
											current2.DownloadUndone
										}));
									}
								}
								finally
								{
									((System.IDisposable)enumerator2)?.Dispose();
								}
								throw new System.Exception(text);
							}
							if (IsNoSplit)
							{
								SmailFileCache = null;
							}
							else
							{
								try
								{
									enumerator3 = Threads.GetEnumerator();
									while (((System.Collections.IEnumerator)enumerator3).MoveNext())
									{
										NetThread current3 = enumerator3.Current;
										if (current3.Temp != null)
										{
											File.Delete(current3.Temp);
										}
									}
								}
								finally
								{
									((System.IDisposable)enumerator3)?.Dispose();
								}
							}
							Finish();
							break;
						}
						finally
						{
							if (flag2)
							{
								Monitor.Exit(lockChain);
							}
						}
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "合并文件出错（" + LocalName + "）");
						if (val != null)
						{
							val.Dispose();
							val = null;
						}
						if (val2 != null)
						{
							val2.Dispose();
							val2 = null;
						}
						if (num <= 3)
						{
							System.Threading.Thread.Sleep(RandomUtils.NextInt(500, 1000));
							num++;
							ProjectData.ClearProjectError();
							continue;
						}
						Fail(ex2);
						ProjectData.ClearProjectError();
						break;
					}
				}
			}
		}

		private void Fail(System.Exception RaiseEx = null)
		{
			object lockState = LockState;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
			bool flag = false;
			try
			{
				Monitor.Enter(lockState, ref flag);
				if (State >= NetState.Finish)
				{
					return;
				}
				if (RaiseEx != null)
				{
					Ex.Add(RaiseEx);
				}
				State = NetState.Error;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(lockState);
				}
			}
			InterruptAndDelete();
			System.Collections.Generic.IEnumerator<LoaderDownload> enumerator = default(System.Collections.Generic.IEnumerator<LoaderDownload>);
			try
			{
				enumerator = Tasks.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					enumerator.Current.OnFileFail(this);
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
		}

		public void Abort(LoaderDownload CausedByTask)
		{
			((List<LoaderDownload>)Tasks).Remove(CausedByTask);
			if (Enumerable.Any<LoaderDownload>((System.Collections.Generic.IEnumerable<LoaderDownload>)Tasks))
			{
				return;
			}
			object lockState = LockState;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
			bool flag = false;
			try
			{
				Monitor.Enter(lockState, ref flag);
				if (State >= NetState.Finish)
				{
					return;
				}
				State = NetState.Error;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(lockState);
				}
			}
			InterruptAndDelete();
		}

		private void InterruptAndDelete()
		{
			if (File.Exists(LocalPath))
			{
				File.Delete(LocalPath);
			}
			object lockRemain = NetManager.LockRemain;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockRemain);
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(lockRemain, ref flag);
					NetManager.FileRemain--;
					ModBase.Log($"[Download] {LocalName}：状态 {State}，剩余文件 {NetManager.FileRemain}");
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(lockRemain);
					}
				}
			}
		}

		public void Finish(bool PrintLog = true)
		{
			object lockState = LockState;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
			bool flag = false;
			try
			{
				Monitor.Enter(lockState, ref flag);
				if (State >= NetState.Finish)
				{
					return;
				}
				State = NetState.Finish;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(lockState);
				}
			}
			object lockRemain = NetManager.LockRemain;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockRemain);
			bool flag2 = false;
			checked
			{
				try
				{
					Monitor.Enter(lockRemain, ref flag2);
					NetManager.FileRemain--;
					if (PrintLog)
					{
						ModBase.Log("[Download] " + LocalName + "：已完成，剩余文件 " + Conversions.ToString(NetManager.FileRemain));
					}
				}
				finally
				{
					if (flag2)
					{
						Monitor.Exit(lockRemain);
					}
				}
				System.Collections.Generic.IEnumerator<LoaderDownload> enumerator = default(System.Collections.Generic.IEnumerator<LoaderDownload>);
				try
				{
					enumerator = Tasks.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						enumerator.Current.OnFileFinish(this);
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
			}
		}
	}

	public class LoaderDownload : ModLoader.LoaderBase
	{
		[CompilerGenerated]
		internal sealed class _Closure_0024__13_002D0
		{
			public List<NetFile> _0024VB_0024Local_FilesToRun;

			public _Closure_0024__13_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

			public _Closure_0024__13_002D0(_Closure_0024__13_002D0 arg0)
			{
				if (arg0 != null)
				{
					_0024VB_0024Local_FilesToRun = arg0._0024VB_0024Local_FilesToRun;
				}
			}

			[SpecialName]
			internal void _Lambda_0024__1()
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.StartCopy(_0024VB_0024Local_FilesToRun, _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_FoldersFinal);
			}
		}

		[CompilerGenerated]
		internal sealed class _Closure_0024__13_002D1
		{
			public List<string> _0024VB_0024Local_FoldersFinal;

			public LoaderDownload _0024VB_0024Me;

			public _Closure_0024__13_002D1(_Closure_0024__13_002D1 arg0)
			{
				if (arg0 != null)
				{
					_0024VB_0024Local_FoldersFinal = arg0._0024VB_0024Local_FoldersFinal;
				}
			}
		}

		[CompilerGenerated]
		internal sealed class _Closure_0024__13_002D2
		{
			public List<NetFile> _0024VB_0024Local_FilesToRun;

			public _Closure_0024__13_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_3;

			public _Closure_0024__13_002D2(_Closure_0024__13_002D2 arg0)
			{
				if (arg0 != null)
				{
					_0024VB_0024Local_FilesToRun = arg0._0024VB_0024Local_FilesToRun;
				}
			}

			[SpecialName]
			internal void _Lambda_0024__2()
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.StartCopy(_0024VB_0024Local_FilesToRun, _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_FoldersFinal);
			}
		}

		public ModBase.SafeList<NetFile> Files;

		private int FileRemain;

		private readonly object FileRemainLock;

		private double _Progress;

		private int _FailCount;

		public override double Progress
		{
			get
			{
				if (base.State >= ModBase.LoadState.Finished)
				{
					return 1.0;
				}
				if (!Enumerable.Any<NetFile>((System.Collections.Generic.IEnumerable<NetFile>)Files))
				{
					return 0.0;
				}
				return _Progress;
			}
			set
			{
				throw new System.Exception("文件下载不允许指定进度");
			}
		}

		public int FailCount
		{
			get
			{
				return _FailCount;
			}
			set
			{
				_FailCount = value;
				if (base.State != ModBase.LoadState.Loading || !((double)value >= Math.Min(10000.0, Math.Max((double)FileRemain * 5.5, (double)NetTaskThreadLimit * 5.5 + 3.0))))
				{
					return;
				}
				ModBase.Log("[Download] 由于同加载器中失败次数过多引发强制失败：连续失败了 " + Conversions.ToString(value) + " 次", ModBase.LogLevel.Debug);
				List<System.Exception> val = new List<System.Exception>();
				System.Collections.Generic.IEnumerator<NetFile> enumerator = default(System.Collections.Generic.IEnumerator<NetFile>);
				try
				{
					enumerator = Files.GetEnumerator();
					System.Collections.Generic.IEnumerator<NetSource> enumerator2 = default(System.Collections.Generic.IEnumerator<NetSource>);
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						NetFile current = enumerator.Current;
						try
						{
							enumerator2 = current.Sources.GetEnumerator();
							while (((System.Collections.IEnumerator)enumerator2).MoveNext())
							{
								NetSource current2 = enumerator2.Current;
								if (current2.Ex != null)
								{
									val.Add(current2.Ex);
									if (val.Count > 10)
									{
										goto end_IL_00df;
									}
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator2)?.Dispose();
						}
						continue;
						end_IL_00df:
						break;
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				OnFail(val);
			}
		}

		public void RefreshStat()
		{
			double num = 0.0;
			double num2 = 0.0;
			System.Collections.Generic.IEnumerator<NetFile> enumerator = default(System.Collections.Generic.IEnumerator<NetFile>);
			try
			{
				enumerator = Files.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					NetFile current = enumerator.Current;
					if (current.IsCopy)
					{
						num += current.Progress * 0.2;
						num2 += 0.2;
					}
					else
					{
						num += current.Progress;
						num2 += 1.0;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			if (num2 > 0.0 && !double.IsNaN(num2))
			{
				num /= num2;
			}
			_Progress = num;
		}

		public LoaderDownload(string Name, List<NetFile> FileTasks)
		{
			FileRemainLock = RuntimeHelpers.GetObjectValue(new object());
			_Progress = 0.0;
			_FailCount = 0;
			base.Name = Name;
			Files = new ModBase.SafeList<NetFile>((System.Collections.Generic.IEnumerable<NetFile>)FileTasks);
		}

		public override void Start(object Input = null, bool IsForceRestart = false)
		{
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Expected O, but got Unknown
			if (Input != null)
			{
				Files = new ModBase.SafeList<NetFile>((System.Collections.Generic.IEnumerable<NetFile>)Input);
			}
			ModBase.SafeList<NetFile> safeList = new ModBase.SafeList<NetFile>();
			checked
			{
				int num = ((List<NetFile>)Files).Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = i + 1;
					int num3 = ((List<NetFile>)Files).Count - 1;
					int num4 = num2;
					while (true)
					{
						if (num4 <= num3)
						{
							if (Operators.CompareString(((List<NetFile>)Files)[i].LocalPath, ((List<NetFile>)Files)[num4].LocalPath, false) == 0)
							{
								break;
							}
							num4++;
							continue;
						}
						((List<NetFile>)safeList).Add(((List<NetFile>)Files)[i]);
						break;
					}
				}
				Files = safeList;
				object fileRemainLock = FileRemainLock;
				ObjectFlowControl.CheckForSyncLockOnValueType(fileRemainLock);
				bool flag = false;
				try
				{
					Monitor.Enter(fileRemainLock, ref flag);
					System.Collections.Generic.IEnumerator<NetFile> enumerator = default(System.Collections.Generic.IEnumerator<NetFile>);
					try
					{
						enumerator = Files.GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator).MoveNext())
						{
							if (enumerator.Current.State != NetState.Finish)
							{
								FileRemain++;
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
					if (flag)
					{
						Monitor.Exit(fileRemainLock);
					}
				}
				base.State = ModBase.LoadState.Loading;
				ModBase.RunInNewThread((Action)([SpecialName] [CompilerGenerated] () =>
				{
					//IL_004b: Unknown result type (might be due to invalid IL or missing references)
					//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
					//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
					//IL_009a: Unknown result type (might be due to invalid IL or missing references)
					//IL_00a4: Expected O, but got Unknown
					//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
					//IL_02df: Unknown result type (might be due to invalid IL or missing references)
					//IL_02ff: Expected O, but got Unknown
					//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
					//IL_0357: Unknown result type (might be due to invalid IL or missing references)
					//IL_0377: Expected O, but got Unknown
					//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
					//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
					//IL_0121: Unknown result type (might be due to invalid IL or missing references)
					//IL_0114: Unknown result type (might be due to invalid IL or missing references)
					try
					{
						_Closure_0024__13_002D1 arg = new _Closure_0024__13_002D1(null);
						arg._0024VB_0024Me = this;
						if (!Enumerable.Any<NetFile>((System.Collections.Generic.IEnumerable<NetFile>)Files))
						{
							OnFinish();
						}
						else
						{
							System.Collections.Generic.IEnumerator<NetFile> enumerator2 = default(System.Collections.Generic.IEnumerator<NetFile>);
							try
							{
								enumerator2 = Files.GetEnumerator();
								System.Collections.Generic.IEnumerator<NetSource> enumerator3 = default(System.Collections.Generic.IEnumerator<NetSource>);
								while (((System.Collections.IEnumerator)enumerator2).MoveNext())
								{
									NetFile current = enumerator2.Current;
									if (current == null)
									{
										throw new ArgumentException("存在空文件请求！");
									}
									try
									{
										enumerator3 = current.Sources.GetEnumerator();
										while (((System.Collections.IEnumerator)enumerator3).MoveNext())
										{
											NetSource current2 = enumerator3.Current;
											if (!ModBase.StartsWithF(current2.Url, "https://", IgnoreCase: true) && !ModBase.StartsWithF(current2.Url, "http://", IgnoreCase: true))
											{
												current2.Ex = (System.Exception)new ArgumentException("输入的下载链接不正确！");
												current2.IsFailed = true;
											}
										}
									}
									finally
									{
										((System.IDisposable)enumerator3)?.Dispose();
									}
									if (current.IsSourceFailed())
									{
										throw new ArgumentException("输入的下载链接不正确！");
									}
									if (!current.LocalPath.ToLower().Contains(":\\"))
									{
										throw new ArgumentException("输入的本地文件地址不正确！");
									}
									if (ModBase.EndsWithF(current.LocalPath, "\\"))
									{
										throw new ArgumentException("请输入含文件名的完整文件路径！");
									}
									string fullName = ((FileSystemInfo)new FileInfo(current.LocalPath).Directory).FullName;
									if (!Directory.Exists(fullName))
									{
										Directory.CreateDirectory(fullName);
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator2)?.Dispose();
							}
							NetManager.Start(this);
							List<string> val = new List<string>();
							arg._0024VB_0024Local_FoldersFinal = new List<string>();
							if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("SystemDebugSkipCopy"))))
							{
								val.Add(Environment.GetFolderPath((System.Environment.SpecialFolder)26) + "\\.minecraft\\");
								System.Collections.Generic.IEnumerator<ModMinecraft.McFolder> enumerator4 = default(System.Collections.Generic.IEnumerator<ModMinecraft.McFolder>);
								try
								{
									enumerator4 = ModMinecraft.McFolderList.GetEnumerator();
									while (enumerator4.MoveNext())
									{
										ModMinecraft.McFolder current3 = enumerator4.Current;
										val.Add(current3.Path);
									}
								}
								finally
								{
									((System.IDisposable)enumerator4).Dispose();
								}
								val = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val));
								System.Collections.Generic.IEnumerator<string> enumerator5 = default(System.Collections.Generic.IEnumerator<string>);
								try
								{
									enumerator5 = val.GetEnumerator();
									while (enumerator5.MoveNext())
									{
										string current4 = enumerator5.Current;
										if (Operators.CompareString(current4, ModMinecraft.PathMcFolder, false) != 0 && Directory.Exists(current4))
										{
											arg._0024VB_0024Local_FoldersFinal.Add(current4);
										}
									}
								}
								finally
								{
									((System.IDisposable)enumerator5).Dispose();
								}
							}
							int num5 = (int)Math.Round(Math.Max(5.0, (double)((List<NetFile>)Files).Count / 10.0 + 1.0));
							List<NetFile> val2 = new List<NetFile>();
							System.Collections.Generic.IEnumerator<NetFile> enumerator6 = default(System.Collections.Generic.IEnumerator<NetFile>);
							try
							{
								enumerator6 = Files.GetEnumerator();
								_Closure_0024__13_002D0 closure_0024__13_002D = default(_Closure_0024__13_002D0);
								while (((System.Collections.IEnumerator)enumerator6).MoveNext())
								{
									NetFile current5 = enumerator6.Current;
									val2.Add(current5);
									if (val2.Count == num5)
									{
										closure_0024__13_002D = new _Closure_0024__13_002D0(closure_0024__13_002D);
										closure_0024__13_002D._0024VB_0024NonLocal__0024VB_0024Closure_2 = arg;
										closure_0024__13_002D._0024VB_0024Local_FilesToRun = new List<NetFile>();
										closure_0024__13_002D._0024VB_0024Local_FilesToRun.AddRange((System.Collections.Generic.IEnumerable<NetFile>)val2);
										ModBase.RunInNewThread(new Action(closure_0024__13_002D._Lambda_0024__1), "NetTask FileCopy " + Conversions.ToString(Uuid), (ThreadPriority)2);
										val2.Clear();
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator6)?.Dispose();
							}
							if (Enumerable.Any<NetFile>((System.Collections.Generic.IEnumerable<NetFile>)val2))
							{
								_Closure_0024__13_002D2 arg2 = default(_Closure_0024__13_002D2);
								_Closure_0024__13_002D2 CS_0024_003C_003E8__locals0 = new _Closure_0024__13_002D2(null);
								CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3 = arg;
								CS_0024_003C_003E8__locals0._0024VB_0024Local_FilesToRun = new List<NetFile>();
								CS_0024_003C_003E8__locals0._0024VB_0024Local_FilesToRun.AddRange((System.Collections.Generic.IEnumerable<NetFile>)val2);
								ModBase.RunInNewThread((Action)([SpecialName] () =>
								{
									CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Me.StartCopy(CS_0024_003C_003E8__locals0._0024VB_0024Local_FilesToRun, CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_FoldersFinal);
								}), "NetTask FileCopy " + Conversions.ToString(Uuid), (ThreadPriority)2);
								val2.Clear();
							}
						}
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						List<System.Exception> obj = new List<System.Exception>();
						obj.Add(ex2);
						OnFail(obj);
						ProjectData.ClearProjectError();
					}
				}), "NetTask " + Conversions.ToString(Uuid) + " Main", (ThreadPriority)2);
			}
		}

		private void StartCopy(List<NetFile> Files, List<string> FolderList)
		{
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log($"[Download] 检查线程分配文件数：{Files.Count}，线程名：{Thread.CurrentThread.Name}");
				}
				List<KeyValuePair<NetFile, string>> val = new List<KeyValuePair<NetFile, string>>();
				System.Collections.Generic.IEnumerator<NetFile> enumerator = default(System.Collections.Generic.IEnumerator<NetFile>);
				try
				{
					enumerator = Files.GetEnumerator();
					System.Collections.Generic.IEnumerator<string> enumerator2 = default(System.Collections.Generic.IEnumerator<string>);
					while (enumerator.MoveNext())
					{
						NetFile current = enumerator.Current;
						string text = null;
						if (current.Check != null && ModMinecraft.McFolderList != null && ModMinecraft.PathMcFolder != null && current.Check.CanUseExistsFile && ModBase.StartsWithF(current.LocalPath, ModMinecraft.PathMcFolder))
						{
							string text2 = current.LocalPath.Replace(ModMinecraft.PathMcFolder, "");
							try
							{
								enumerator2 = FolderList.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									string text3 = enumerator2.Current + text2;
									if (current.Check.Check(text3) == null)
									{
										text = text3;
										break;
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator2).Dispose();
							}
						}
						object lockState = LockState;
						ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
						bool flag = false;
						try
						{
							Monitor.Enter(lockState, ref flag);
							if (text != null)
							{
								current.State = NetState.WaitForCopy;
								current.IsCopy = true;
								val.Add(new KeyValuePair<NetFile, string>(current, text));
							}
							else
							{
								current.State = NetState.WaitForDownload;
								current.IsCopy = false;
							}
						}
						finally
						{
							if (flag)
							{
								Monitor.Exit(lockState);
							}
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<NetFile, string>> enumerator3 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<NetFile, string>>);
				try
				{
					enumerator3 = val.GetEnumerator();
					while (enumerator3.MoveNext())
					{
						KeyValuePair<NetFile, string> current2 = enumerator3.Current;
						NetFile key = current2.Key;
						object lockState2 = LockState;
						ObjectFlowControl.CheckForSyncLockOnValueType(lockState2);
						bool flag2 = false;
						try
						{
							Monitor.Enter(lockState2, ref flag2);
							if (key.State > NetState.WaitForCopy)
							{
								break;
							}
						}
						finally
						{
							if (flag2)
							{
								Monitor.Exit(lockState2);
							}
						}
						string value = current2.Value;
						int num = 0;
						while (true)
						{
							try
							{
								ModBase.Log("[Download] 复制已存在的文件（" + value + "）");
								ModBase.CopyFile(value, key.LocalPath);
								key.Finish(PrintLog: false);
							}
							catch (System.Exception ex)
							{
								ProjectData.SetProjectError(ex);
								System.Exception ex2 = ex;
								num = checked(num + 1);
								ModBase.Log(ex2, $"复制已存在的文件失败，重试第 {num} 次（{value} -> {key.LocalPath}）");
								if (num < 3)
								{
									Thread.Sleep(200);
									ProjectData.ClearProjectError();
									continue;
								}
								key.State = NetState.WaitForDownload;
								key.IsCopy = false;
								ProjectData.ClearProjectError();
							}
							break;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator3).Dispose();
				}
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "下载已存在文件查找失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}

		public void OnFileFinish(NetFile File)
		{
			object fileRemainLock = FileRemainLock;
			ObjectFlowControl.CheckForSyncLockOnValueType(fileRemainLock);
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(fileRemainLock, ref flag);
					FileRemain--;
					if (FileRemain > 0)
					{
						return;
					}
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(fileRemainLock);
					}
				}
				OnFinish();
			}
		}

		public void OnFinish()
		{
			RaisePreviewFinish();
			object lockState = LockState;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
			bool flag = false;
			try
			{
				Monitor.Enter(lockState, ref flag);
				if (base.State <= ModBase.LoadState.Loading)
				{
					base.State = ModBase.LoadState.Finished;
				}
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(lockState);
				}
			}
		}

		public void OnFileFail(NetFile File)
		{
			System.Collections.Generic.IEnumerator<NetSource> enumerator = default(System.Collections.Generic.IEnumerator<NetSource>);
			try
			{
				enumerator = File.Sources.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					NetSource current = enumerator.Current;
					if (!Information.IsNothing((object)current.Ex))
					{
						File.Ex.Add(current.Ex);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			OnFail(File.Ex);
		}

		public void OnFail(List<System.Exception> ExList)
		{
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			object lockState = LockState;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
			bool flag = false;
			try
			{
				Monitor.Enter(lockState, ref flag);
				if (base.State > ModBase.LoadState.Loading)
				{
					return;
				}
				if (ExList == null || !Enumerable.Any<System.Exception>((System.Collections.Generic.IEnumerable<System.Exception>)ExList))
				{
					List<System.Exception> obj = new List<System.Exception>();
					obj.Add(new System.Exception("未知错误！"));
					ExList = obj;
				}
				List<System.Exception> val = Enumerable.ToList<System.Exception>(Enumerable.Where<System.Exception>((System.Collections.Generic.IEnumerable<System.Exception>)ExList, (Func<System.Exception, bool>)([SpecialName] (System.Exception e) => !e.Message.Contains("404 ("))));
				base.Error = (Enumerable.Any<System.Exception>((System.Collections.Generic.IEnumerable<System.Exception>)val) ? val[0] : ExList[0]);
				System.Collections.Generic.IEnumerator<NetFile> enumerator = default(System.Collections.Generic.IEnumerator<NetFile>);
				try
				{
					enumerator = Files.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						NetFile current = enumerator.Current;
						if (current.State == NetState.Error)
						{
							base.Error = new System.Exception("文件下载失败：" + current.LocalPath + "\r\n" + ModBase.Join((System.Collections.IEnumerable)Enumerable.Select<NetSource, string>((System.Collections.Generic.IEnumerable<NetSource>)current.Sources, (Func<NetSource, string>)([SpecialName] (NetSource s) => (s.Ex != null) ? (s.Ex.Message + "（" + s.Url + "）") : s.Url)), "\r\n"), base.Error);
							break;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				base.State = ModBase.LoadState.Failed;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(lockState);
				}
			}
			System.Collections.Generic.IEnumerator<NetFile> enumerator2 = default(System.Collections.Generic.IEnumerator<NetFile>);
			try
			{
				enumerator2 = Files.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator2).MoveNext())
				{
					NetFile current2 = enumerator2.Current;
					if (current2.State < NetState.Merge)
					{
						current2.State = NetState.Error;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator2)?.Dispose();
			}
			List<string> val2 = new List<string>();
			System.Collections.Generic.IEnumerator<System.Exception> enumerator3 = default(System.Collections.Generic.IEnumerator<System.Exception>);
			try
			{
				enumerator3 = ExList.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					System.Exception current3 = enumerator3.Current;
					val2.Add(current3.Message);
				}
			}
			finally
			{
				((System.IDisposable)enumerator3).Dispose();
			}
			ModBase.Log("[Download] " + ModBase.Join((System.Collections.IEnumerable)(object)Enumerable.ToArray<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val2)), "\r\n"));
		}

		public override void Abort()
		{
			object lockState = LockState;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
			bool flag = false;
			try
			{
				Monitor.Enter(lockState, ref flag);
				if (base.State >= ModBase.LoadState.Finished)
				{
					return;
				}
				base.State = ModBase.LoadState.Aborted;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(lockState);
				}
			}
			ModBase.Log("[Download] " + Name + " 已取消！");
			System.Collections.Generic.IEnumerator<NetFile> enumerator = default(System.Collections.Generic.IEnumerator<NetFile>);
			try
			{
				enumerator = Files.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					enumerator.Current.Abort(this);
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
		}
	}

	public class LoaderDownloadUnc : ModLoader.LoaderBase
	{
		public string Unc;

		public string SavePath;

		private Thread DlThread;

		public LoaderDownloadUnc(string Name, Tuple<string, string> File)
		{
			base.Name = Name;
			Unc = File.Item1;
			SavePath = File.Item2;
		}

		public override void Start(object Input = null, bool IsForceRestart = false)
		{
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Expected O, but got Unknown
			if (Input != null)
			{
				Unc = Conversions.ToString(NewLateBinding.LateGet(Input, (System.Type)null, "Item1", new object[0], (string[])null, (System.Type[])null, (bool[])null));
				SavePath = Conversions.ToString(NewLateBinding.LateGet(Input, (System.Type)null, "Item2", new object[0], (string[])null, (System.Type[])null, (bool[])null));
			}
			base.State = ModBase.LoadState.Loading;
			Directory.CreateDirectory(ModBase.GetPathFromFullPath(SavePath));
			DlThread = ModBase.RunInNewThread(new Action(DownloadThread), "Download UNC File", (ThreadPriority)2);
		}

		private void DownloadThread()
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected O, but got Unknown
			//IL_00fd: Expected O, but got Unknown
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Expected O, but got Unknown
			try
			{
				long length = new FileInfo(Unc).Length;
				long num = 0L;
				string text = ModBase.PathTemp + Conversions.ToString(Uuid) + "\\" + ModBase.GetFileNameFromPath(SavePath);
				Directory.CreateDirectory(ModBase.GetPathFromFullPath(text));
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				FileStream val = new FileStream(Unc, (FileMode)3, (FileAccess)1);
				try
				{
					FileStream val2 = new FileStream(text, (FileMode)2, (FileAccess)2);
					try
					{
						byte[] array = new byte[81921];
						int num2;
						do
						{
							num2 = val.Read(array, 0, array.Length);
							val2.Write(array, 0, num2);
							num = checked(num + num2);
							Progress = (double)num / (double)length;
						}
						while (num2 > 0 && base.State == ModBase.LoadState.Loading);
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
				if (base.State <= ModBase.LoadState.Loading)
				{
					ModBase.CopyFile(text, SavePath);
					if (base.State == ModBase.LoadState.Loading)
					{
						base.State = ModBase.LoadState.Finished;
					}
				}
			}
			catch (ThreadAbortException val3)
			{
				ProjectData.SetProjectError((System.Exception)val3);
				ThreadAbortException val4 = val3;
				ProjectData.ClearProjectError();
			}
		}

		public override void Abort()
		{
			if (base.State < ModBase.LoadState.Finished)
			{
				base.State = ModBase.LoadState.Aborted;
				ModBase.Log("[Download] " + Name + " 已取消！");
			}
		}
	}

	public class NetManagerClass
	{
		[CompilerGenerated]
		internal sealed class _Closure_0024__17_002D0
		{
			public VB_0024AnonymousDelegate_4<int> _0024VB_0024Local_ThreadStarter;

			public _Closure_0024__17_002D0(_Closure_0024__17_002D0 arg0)
			{
				if (arg0 != null)
				{
					_0024VB_0024Local_ThreadStarter = arg0._0024VB_0024Local_ThreadStarter;
				}
			}

			[SpecialName]
			internal void _Lambda_0024__1()
			{
				_0024VB_0024Local_ThreadStarter(0);
			}

			[SpecialName]
			internal void _Lambda_0024__2()
			{
				_0024VB_0024Local_ThreadStarter(1);
			}
		}

		public Dictionary<string, NetFile> Files;

		public readonly object LockFiles;

		public ModBase.SafeList<LoaderDownload> Tasks;

		private long _DownloadDone;

		private readonly object LockDone;

		public int FileRemain;

		public readonly object LockRemain;

		private long SpeedLastDone;

		private List<long> SpeedLast;

		public long Speed;

		public readonly int Uuid;

		private long RefreshStatLast;

		private bool IsManagerStarted;

		private bool IsDownloadCacheCleared;

		public long DownloadDone
		{
			get
			{
				return _DownloadDone;
			}
			set
			{
				object lockDone = LockDone;
				ObjectFlowControl.CheckForSyncLockOnValueType(lockDone);
				bool flag = false;
				try
				{
					Monitor.Enter(lockDone, ref flag);
					_DownloadDone = value;
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(lockDone);
					}
				}
			}
		}

		public NetManagerClass()
		{
			Files = new Dictionary<string, NetFile>();
			LockFiles = RuntimeHelpers.GetObjectValue(new object());
			Tasks = new ModBase.SafeList<LoaderDownload>();
			_DownloadDone = 0L;
			LockDone = RuntimeHelpers.GetObjectValue(new object());
			FileRemain = 0;
			LockRemain = RuntimeHelpers.GetObjectValue(new object());
			SpeedLastDone = 0L;
			SpeedLast = new List<long>();
			Speed = 0L;
			Uuid = ModBase.GetUuid();
			IsManagerStarted = false;
			IsDownloadCacheCleared = false;
		}

		private void RefreshStat()
		{
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			checked
			{
				try
				{
					long num = TimeUtils.GetTimeTick() - RefreshStatLast;
					if (num == 0L)
					{
						return;
					}
					RefreshStatLast += num;
					double num2 = Math.Max(0.0, (double)(DownloadDone - SpeedLastDone) / ((double)num / 1000.0));
					SpeedLast.Insert(0, (long)Math.Round(num2));
					if (SpeedLast.Count >= 31)
					{
						SpeedLast.RemoveAt(30);
					}
					SpeedLastDone = DownloadDone;
					long num3 = 0L;
					long num4 = 0L;
					int num5 = SpeedLast.Count;
					System.Collections.Generic.IEnumerator<long> enumerator = default(System.Collections.Generic.IEnumerator<long>);
					try
					{
						enumerator = SpeedLast.GetEnumerator();
						while (enumerator.MoveNext())
						{
							long current = enumerator.Current;
							num3 += current * num5;
							num4 += num5;
							num5--;
						}
					}
					finally
					{
						((System.IDisposable)enumerator).Dispose();
					}
					Speed = (long)Math.Round((num4 > 0) ? ((double)num3 / (double)num4) : 0.0);
					long num6 = 0L;
					if (SpeedLast.Count >= 10)
					{
						num6 = (long)Math.Round(Enumerable.Average(Enumerable.Take<long>((System.Collections.Generic.IEnumerable<long>)SpeedLast, 10)) * 0.85);
					}
					if (num6 > NetTaskSpeedLimitLow)
					{
						NetTaskSpeedLimitLow = num6;
						ModBase.Log("[Download] 速度下限已提升到 " + ModBase.GetString(num6));
					}
					System.Collections.Generic.IEnumerator<LoaderDownload> enumerator2 = default(System.Collections.Generic.IEnumerator<LoaderDownload>);
					try
					{
						enumerator2 = Tasks.GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator2).MoveNext())
						{
							enumerator2.Current.RefreshStat();
						}
					}
					finally
					{
						((System.IDisposable)enumerator2)?.Dispose();
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "刷新下载公开属性失败");
					ProjectData.ClearProjectError();
				}
			}
		}

		private void StartManager()
		{
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			_Closure_0024__17_002D0 arg = default(_Closure_0024__17_002D0);
			_Closure_0024__17_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__17_002D0(null);
			if (IsManagerStarted)
			{
				return;
			}
			IsManagerStarted = true;
			checked
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_ThreadStarter = [SpecialName] [CompilerGenerated] (int Id) =>
				{
					//IL_006d: Unknown result type (might be due to invalid IL or missing references)
					//IL_0072: Unknown result type (might be due to invalid IL or missing references)
					//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
					//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
					//IL_0145: Unknown result type (might be due to invalid IL or missing references)
					//IL_014a: Unknown result type (might be due to invalid IL or missing references)
					//IL_0186: Unknown result type (might be due to invalid IL or missing references)
					//IL_018b: Unknown result type (might be due to invalid IL or missing references)
					try
					{
						System.Collections.Generic.IEnumerator<NetFile> enumerator = default(System.Collections.Generic.IEnumerator<NetFile>);
						System.Collections.Generic.IEnumerator<NetFile> enumerator2 = default(System.Collections.Generic.IEnumerator<NetFile>);
						System.Collections.Generic.IEnumerator<NetFile> enumerator3 = default(System.Collections.Generic.IEnumerator<NetFile>);
						System.Collections.Generic.IEnumerator<NetThread> enumerator4 = default(System.Collections.Generic.IEnumerator<NetThread>);
						while (true)
						{
							IL_0000:
							Thread.Sleep(20);
							object lockFiles = LockFiles;
							ObjectFlowControl.CheckForSyncLockOnValueType(lockFiles);
							bool flag = false;
							List<NetFile> val;
							try
							{
								Monitor.Enter(lockFiles, ref flag);
								if (Id == 0 && FileRemain == 0 && Enumerable.Any<KeyValuePair<string, NetFile>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, NetFile>>)Files))
								{
									Files.Clear();
								}
								val = Enumerable.ToList<NetFile>((System.Collections.Generic.IEnumerable<NetFile>)Files.Values);
							}
							finally
							{
								if (flag)
								{
									Monitor.Exit(lockFiles);
								}
							}
							List<NetFile> val2 = new List<NetFile>();
							List<NetFile> val3 = new List<NetFile>();
							try
							{
								enumerator = val.GetEnumerator();
								while (enumerator.MoveNext())
								{
									NetFile current = enumerator.Current;
									if (unchecked(current.Uuid % 2) != Id)
									{
										if (current.State == NetState.WaitForDownload)
										{
											val2.Add(current);
										}
										else if (current.State < NetState.Merge)
										{
											val3.Add(current);
										}
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator).Dispose();
							}
							try
							{
								enumerator2 = val2.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									NetFile current2 = enumerator2.Current;
									if (NetTaskThreadCount >= NetTaskThreadLimit)
									{
										goto IL_0000;
									}
									NetThread netThread = current2.TryBeginThread();
									if (netThread != null && netThread.Source.Url.Contains("bmclapi"))
									{
										Thread.Sleep(30);
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator2).Dispose();
							}
							if (Speed < NetTaskSpeedLimitLow)
							{
								try
								{
									enumerator3 = val3.GetEnumerator();
									while (enumerator3.MoveNext())
									{
										NetFile current3 = enumerator3.Current;
										if (NetTaskThreadCount >= NetTaskThreadLimit)
										{
											break;
										}
										int num2 = 0;
										int num3 = 0;
										if (current3.Threads != null)
										{
											try
											{
												enumerator4 = Enumerable.ToList<NetThread>((System.Collections.Generic.IEnumerable<NetThread>)current3.Threads).GetEnumerator();
												while (enumerator4.MoveNext())
												{
													NetThread current4 = enumerator4.Current;
													if (current4.State < NetState.Download)
													{
														num2++;
													}
													else if (current4.State == NetState.Download)
													{
														num3++;
													}
												}
											}
											finally
											{
												((System.IDisposable)enumerator4).Dispose();
											}
										}
										if (num2 <= num3)
										{
											NetThread netThread2 = current3.TryBeginThread();
											if (netThread2 != null && netThread2.Source.Url.Contains("bmclapi"))
											{
												Thread.Sleep(30);
											}
										}
									}
								}
								finally
								{
									((System.IDisposable)enumerator3).Dispose();
								}
							}
						}
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						ModBase.Log(ex4, $"任务管理启动线程 {Id} 出错", ModBase.LogLevel.Critical);
						ProjectData.ClearProjectError();
					}
				};
				ModBase.RunInNewThread((Action)([SpecialName] () =>
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_ThreadStarter(0);
				}), "NetManager ThreadStarter 0", (ThreadPriority)2);
				ModBase.RunInNewThread((Action)([SpecialName] () =>
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_ThreadStarter(1);
				}), "NetManager ThreadStarter 1", (ThreadPriority)2);
				ModBase.RunInNewThread((Action)([SpecialName] [CompilerGenerated] () =>
				{
					try
					{
						NetTaskSpeedLimitLeftLast = TimeUtils.GetTimeTick();
						while (true)
						{
							long timeTick = TimeUtils.GetTimeTick();
							long num = timeTick;
							if (NetTaskSpeedLimitHigh > 0)
							{
								NetTaskSpeedLimitLeft = (long)Math.Round((double)NetTaskSpeedLimitHigh / 1000.0 * (double)(timeTick - NetTaskSpeedLimitLeftLast));
							}
							NetTaskSpeedLimitLeftLast = timeTick;
							RefreshStat();
							while (TimeUtils.GetTimeTick() - num < 80)
							{
								Thread.Sleep(10);
							}
						}
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "任务管理刷新线程出错", ModBase.LogLevel.Critical);
						ProjectData.ClearProjectError();
					}
				}), "NetManager StatRefresher", (ThreadPriority)2);
			}
		}

		public void Start(LoaderDownload Task)
		{
			StartManager();
			if (!IsDownloadCacheCleared)
			{
				try
				{
					ModBase.DeleteDirectory(ModBase.PathTemp + "Download");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "清理下载缓存失败");
					ProjectData.ClearProjectError();
				}
				IsDownloadCacheCleared = true;
			}
			Directory.CreateDirectory(ModBase.PathTemp + "Download");
			object lockFiles = LockFiles;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockFiles);
			bool flag = false;
			checked
			{
				try
				{
					Monitor.Enter(lockFiles, ref flag);
					int num = ((List<NetFile>)Task.Files).Count - 1;
					for (int i = 0; i <= num; i++)
					{
						NetFile netFile = ((List<NetFile>)Task.Files)[i];
						if (Files.ContainsKey(netFile.LocalPath))
						{
							if (Files[netFile.LocalPath].State >= NetState.Finish)
							{
								((List<LoaderDownload>)netFile.Tasks).Add(Task);
								Files[netFile.LocalPath] = netFile;
								object lockRemain = LockRemain;
								ObjectFlowControl.CheckForSyncLockOnValueType(lockRemain);
								bool flag2 = false;
								try
								{
									Monitor.Enter(lockRemain, ref flag2);
									FileRemain++;
									if (ModBase.ModeDebug)
									{
										ModBase.Log("[Download] " + netFile.LocalName + "：已替换列表，剩余文件 " + Conversions.ToString(FileRemain));
									}
								}
								finally
								{
									if (flag2)
									{
										Monitor.Exit(lockRemain);
									}
								}
							}
							else
							{
								netFile = Files[netFile.LocalPath];
								((List<LoaderDownload>)netFile.Tasks).Add(Task);
							}
						}
						else
						{
							((List<LoaderDownload>)netFile.Tasks).Add(Task);
							Files.Add(netFile.LocalPath, netFile);
							object lockRemain2 = LockRemain;
							ObjectFlowControl.CheckForSyncLockOnValueType(lockRemain2);
							bool flag3 = false;
							try
							{
								Monitor.Enter(lockRemain2, ref flag3);
								FileRemain++;
								if (ModBase.ModeDebug)
								{
									ModBase.Log("[Download] " + netFile.LocalName + "：已加入列表，剩余文件 " + Conversions.ToString(FileRemain));
								}
							}
							finally
							{
								if (flag3)
								{
									Monitor.Exit(lockRemain2);
								}
							}
						}
						((List<NetFile>)Task.Files)[i] = netFile;
					}
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(lockFiles);
					}
				}
				((List<LoaderDownload>)Tasks).Add(Task);
			}
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_10_NetDownloadByClient : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_Url;

		internal string _0024VB_0024Local_LocalFile;

		internal bool _0024VB_0024Local_UseBrowserUserAgent;

		internal FileStream _0024VB_0024ResumableLocal_fileStream_00240;

		internal Stream _0024VB_0024ResumableLocal_httpStream_00241;

		internal HttpResponseMessage _0024VB_0024ResumableLocal_response_00242;

		internal HttpRequestMessage _0024VB_0024ResumableLocal_request_00243;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<Stream> _0024A1;

		internal TaskAwaiter _0024A2;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0342: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Expected O, but got Unknown
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Expected O, but got Unknown
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if ((uint)(num - -5) > 2u && (uint)num > 2u)
				{
					ModBase.Log("[Net] 直接下载文件：" + _0024VB_0024Local_Url);
				}
				TaskCanceledException val2 = default(TaskCanceledException);
				try
				{
					if ((uint)(num - -5) > 2u && (uint)num > 2u)
					{
						Directory.CreateDirectory(ModBase.GetPathFromFullPath(_0024VB_0024Local_LocalFile));
						if (File.Exists(_0024VB_0024Local_LocalFile))
						{
							File.Delete(_0024VB_0024Local_LocalFile);
						}
						_0024VB_0024ResumableLocal_request_00243 = new HttpRequestMessage(HttpMethod.Get, _0024VB_0024Local_Url);
					}
					try
					{
						HttpResponseMessage result;
						TaskAwaiter<HttpResponseMessage> awaiter;
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return;
						default:
						{
							string url = _0024VB_0024Local_Url;
							HttpRequestMessage Client = _0024VB_0024ResumableLocal_request_00243;
							ModSecret.SecretHeadersSign(url, ref Client, _0024VB_0024Local_UseBrowserUserAgent);
							awaiter = NetworkService.GetClient().SendAsync(_0024VB_0024ResumableLocal_request_00243, (HttpCompletionOption)1).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = awaiter;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_10_NetDownloadByClient>(ref awaiter, ref _this);
								return;
							}
							goto IL_0135;
						}
						case 0:
							num = (_0024State = -1);
							awaiter = _0024A0;
							_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
							goto IL_0135;
						case -5:
						case -4:
						case 1:
						case 2:
							break;
							IL_0135:
							result = awaiter.GetResult();
							awaiter = default(TaskAwaiter<HttpResponseMessage>);
							_0024VB_0024ResumableLocal_response_00242 = result;
							break;
						}
						try
						{
							TaskAwaiter<Stream> awaiter2;
							if (num <= -4)
							{
								if (num != -5)
								{
									if (num != -4)
									{
										goto IL_017a;
									}
									num = (_0024State = -1);
									return;
								}
							}
							else
							{
								if (num == 1)
								{
									num = (_0024State = -1);
									awaiter2 = _0024A1;
									_0024A1 = default(TaskAwaiter<Stream>);
									goto IL_01e3;
								}
								if (num != 2)
								{
									goto IL_017a;
								}
							}
							goto IL_01f9;
							IL_017a:
							EnsureSuccessStatusCode(_0024VB_0024ResumableLocal_response_00242);
							awaiter2 = _0024VB_0024ResumableLocal_response_00242.Content.ReadAsStreamAsync().GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_0024State = 1);
								_0024A1 = awaiter2;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<Stream>, VB_0024StateMachine_10_NetDownloadByClient>(ref awaiter2, ref _this);
								return;
							}
							goto IL_01e3;
							IL_01f9:
							try
							{
								if (num != -5 && num != 2)
								{
									_0024VB_0024ResumableLocal_fileStream_00240 = new FileStream(_0024VB_0024Local_LocalFile, (FileMode)2);
								}
								try
								{
									TaskAwaiter val;
									switch (num)
									{
									case -5:
										num = (_0024State = -1);
										return;
									default:
										val = _0024VB_0024ResumableLocal_httpStream_00241.CopyToAsync((Stream)(object)_0024VB_0024ResumableLocal_fileStream_00240).GetAwaiter();
										if (!val.IsCompleted)
										{
											num = (_0024State = 2);
											_0024A2 = val;
											_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_10_NetDownloadByClient>(ref val, ref _this);
											return;
										}
										break;
									case 2:
										num = (_0024State = -1);
										val = _0024A2;
										_0024A2 = default(TaskAwaiter);
										break;
									}
									val.GetResult();
									val = default(TaskAwaiter);
								}
								finally
								{
									if (num < 0 && _0024VB_0024ResumableLocal_fileStream_00240 != null)
									{
										((System.IDisposable)_0024VB_0024ResumableLocal_fileStream_00240).Dispose();
									}
								}
							}
							finally
							{
								if (num < 0 && _0024VB_0024ResumableLocal_httpStream_00241 != null)
								{
									((System.IDisposable)_0024VB_0024ResumableLocal_httpStream_00241).Dispose();
								}
							}
							goto end_IL_014b;
							IL_01e3:
							Stream result2 = awaiter2.GetResult();
							awaiter2 = default(TaskAwaiter<Stream>);
							_0024VB_0024ResumableLocal_httpStream_00241 = result2;
							goto IL_01f9;
							end_IL_014b:;
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_response_00242 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_response_00242).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_request_00243 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_request_00243).Dispose();
						}
					}
				}
				catch (System.Exception obj) when (((Func<bool>)delegate
				{
					// Could not convert BlockContainer to single expression
					object obj2 = ((obj is TaskCanceledException) ? obj : null);
					System.Runtime.CompilerServices.Unsafe.SkipInit(out int result3);
					if (obj2 == null)
					{
						result3 = 0;
					}
					else
					{
						ProjectData.SetProjectError((System.Exception)obj2);
						val2 = (TaskCanceledException)obj2;
						result3 = ((((System.Exception)(object)val2).InnerException == null) ? 1 : 0);
					}
					return (byte)result3 != 0;
				}).Invoke())
				{
					throw new TimeoutException($"下载超时（{_0024VB_0024Local_Url}）", (System.Exception)(object)val2);
				}
				catch (HttpRequestFailedException ex)
				{
					ProjectData.SetProjectError((System.Exception)(object)ex);
					HttpRequestFailedException ex2 = ex;
					throw new HttpWebException($"下载失败：{((System.Exception)(object)ex2).Message}（{_0024VB_0024Local_Url}）", ex2);
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					if (File.Exists(_0024VB_0024Local_LocalFile))
					{
						File.Delete(_0024VB_0024Local_LocalFile);
					}
					throw new WebException($"下载失败：{ex4.Message}（{_0024VB_0024Local_Url}）", ex4);
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

	public const string NetDownloadEnd = ".PCLDownloading";

	public static int NetTaskThreadLimit;

	public static long NetTaskSpeedLimitLow = 262144L;

	public static long NetTaskSpeedLimitHigh = -1L;

	public static long NetTaskSpeedLimitLeft = -1L;

	private static readonly object NetTaskSpeedLimitLeftLock = RuntimeHelpers.GetObjectValue(new object());

	private static long NetTaskSpeedLimitLeftLast;

	public static int NetTaskThreadCount = 0;

	private static readonly object NetTaskThreadCountLock = RuntimeHelpers.GetObjectValue(new object());

	public static NetManagerClass NetManager = new NetManagerClass();

	public static int Ping(string Ip, int Timeout = 10000, bool MakeLog = true)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		PingReply val;
		int result;
		try
		{
			val = new Ping().Send(Ip);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			if (MakeLog)
			{
				ModBase.Log("[Net] Ping " + Ip + " 失败：" + ex2.Message);
			}
			result = -1;
			ProjectData.ClearProjectError();
			goto IL_00b7;
		}
		if ((int)val.Status == 0)
		{
			if (MakeLog)
			{
				ModBase.Log(string.Concat(new string[5]
				{
					"[Net] Ping ",
					Ip,
					" 结束：",
					Conversions.ToString(val.RoundtripTime),
					"ms"
				}));
			}
			result = checked((int)val.RoundtripTime);
		}
		else
		{
			if (MakeLog)
			{
				ModBase.Log("[Net] Ping " + Ip + " 失败");
			}
			result = -1;
		}
		goto IL_00b7;
		IL_00b7:
		return result;
	}

	private static void EnsureSuccessStatusCode(HttpResponseMessage response)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (!response.IsSuccessStatusCode)
		{
			string result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
			HttpContent content = response.Content;
			if (content != null)
			{
				content.Dispose();
			}
			throw new HttpRequestFailedException(response, result);
		}
	}

	public static object NetGetCodeByRequestRetry(string Url, Encoding Encode = null, string Accept = "", bool IsJson = false, string BackupUrl = null, bool UseBrowserUserAgent = false)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_008e: Expected O, but got Unknown
		int num = 0;
		System.Exception ex = null;
		long timeTick = TimeUtils.GetTimeTick();
		checked
		{
			while (num <= 3)
			{
				num++;
				try
				{
					switch (num)
					{
					case 0:
						return NetGetCodeByRequestOnce(Url, Encode, 10000, IsJson, Accept, UseBrowserUserAgent);
					case 1:
						Thread.Sleep(500);
						return NetGetCodeByRequestOnce(BackupUrl ?? Url, Encode, 30000, IsJson, Accept, UseBrowserUserAgent);
					default:
						if (TimeUtils.GetTimeTick() - timeTick > 5500)
						{
							Thread.Sleep(500);
							return NetGetCodeByRequestOnce(BackupUrl ?? Url, Encode, 4000, IsJson, Accept, UseBrowserUserAgent);
						}
						throw ex;
					}
				}
				catch (ThreadInterruptedException val)
				{
					ProjectData.SetProjectError((System.Exception)val);
					ThreadInterruptedException val2 = val;
					throw;
				}
				catch (System.Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					System.Exception ex3 = ex2;
					ex = ex3;
					ProjectData.ClearProjectError();
				}
			}
			throw ex;
		}
	}

	public static object NetGetCodeByRequestOnce(string Url, Encoding Encode = null, int Timeout = 30000, bool IsJson = false, string Accept = "", bool UseBrowserUserAgent = false)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_015c: Expected O, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		if (ModBase.RunInUi() && !Url.Contains("//127."))
		{
			throw new System.Exception("在 UI 线程执行了网络请求");
		}
		try
		{
			Url = Conversions.ToString(ModSecret.SecretCdnSign(Url));
			ModBase.Log(string.Format("[Net] 获取网络结果：{0}，超时 {1}ms{2}", (object)Url, (object)Timeout, (object)(IsJson ? "，要求 Json" : "")));
			CancellationTokenSource val = new CancellationTokenSource();
			try
			{
				val.CancelAfter(Timeout);
				HttpRequestMessage val2 = new HttpRequestMessage(HttpMethod.Get, Url);
				try
				{
					val2.Headers.Accept.ParseAdd(Accept);
					string url = Url;
					HttpRequestMessage Client = val2;
					ModSecret.SecretHeadersSign(url, ref Client, UseBrowserUserAgent);
					HttpResponseMessage result = NetworkService.GetClient().SendAsync(val2, (HttpCompletionOption)1, val.Token).Result;
					try
					{
						EnsureSuccessStatusCode(result);
						if (Encode == null)
						{
							Encode = Encoding.UTF8;
						}
						Stream result2 = result.Content.ReadAsStreamAsync().Result;
						try
						{
							StreamReader val3 = new StreamReader(result2, Encode);
							try
							{
								string text = val3.ReadToEnd();
								if (string.IsNullOrEmpty(text))
								{
									throw new WebException("获取结果失败，内容为空（" + Url + "）");
								}
								return IsJson ? ModBase.GetJson(text) : text;
							}
							finally
							{
								((System.IDisposable)val3)?.Dispose();
							}
						}
						finally
						{
							((System.IDisposable)result2)?.Dispose();
						}
					}
					finally
					{
						((System.IDisposable)result)?.Dispose();
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
		catch (TaskCanceledException val4)
		{
			ProjectData.SetProjectError((System.Exception)val4);
			TaskCanceledException val5 = val4;
			throw new TimeoutException("连接服务器超时（" + Url + "）", (System.Exception)(object)val5);
		}
		catch (HttpRequestFailedException ex)
		{
			ProjectData.SetProjectError((System.Exception)(object)ex);
			HttpRequestFailedException ex2 = ex;
			throw new HttpWebException(string.Concat(new string[5]
			{
				"获取结果失败，",
				((System.Exception)(object)ex2).Message,
				"（",
				Url,
				"）"
			}), ex2);
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			throw new WebException(string.Concat(new string[] { "获取结果失败，", ex4.Message, "（", Url, "）" }), ex4);
		}
	}

	public static string NetGetCodeByLoader(string Url, int Timeout = 45000, bool IsJson = false, bool UseBrowserUserAgent = false)
	{
		string text = ModMain.RequestTaskTempFolder() + "download.txt";
		string name = "源码获取 " + Conversions.ToString(ModBase.GetUuid()) + "#";
		List<NetFile> val = new List<NetFile>();
		val.Add(new NetFile(new string[] { Url }, text, new ModBase.FileChecker(-1L, -1L)
		{
			IsJson = IsJson
		}, UseBrowserUserAgent));
		LoaderDownload loaderDownload = new LoaderDownload(name, val);
		try
		{
			loaderDownload.WaitForExitTime(Timeout, null, "连接服务器超时（" + Url + "）");
			string result = ModBase.ReadFile(text);
			File.Delete(text);
			return result;
		}
		finally
		{
			loaderDownload.Abort();
		}
	}

	public static string NetGetCodeByLoader(System.Collections.Generic.IEnumerable<string> Urls, int Timeout = 45000, bool IsJson = false, bool UseBrowserUserAgent = false)
	{
		string text = ModMain.RequestTaskTempFolder() + "download.txt";
		string name = "源码获取 " + Conversions.ToString(ModBase.GetUuid()) + "#";
		List<NetFile> obj = new List<NetFile>();
		obj.Add(new NetFile(Urls, text, new ModBase.FileChecker(-1L, -1L)
		{
			IsJson = IsJson
		}, UseBrowserUserAgent));
		LoaderDownload loaderDownload = new LoaderDownload(name, obj);
		try
		{
			loaderDownload.WaitForExitTime(Timeout, null, "连接服务器超时（第一下载源：" + Enumerable.First<string>(Urls) + "）");
			string result = ModBase.ReadFile(text);
			File.Delete(text);
			return result;
		}
		finally
		{
			loaderDownload.Abort();
		}
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_10_NetDownloadByClient))]
	public static System.Threading.Tasks.Task NetDownloadByClient(string Url, string LocalFile, bool UseBrowserUserAgent = false)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_10_NetDownloadByClient vB_0024StateMachine_10_NetDownloadByClient = default(VB_0024StateMachine_10_NetDownloadByClient);
		vB_0024StateMachine_10_NetDownloadByClient._0024VB_0024Local_Url = Url;
		vB_0024StateMachine_10_NetDownloadByClient._0024VB_0024Local_LocalFile = LocalFile;
		vB_0024StateMachine_10_NetDownloadByClient._0024VB_0024Local_UseBrowserUserAgent = UseBrowserUserAgent;
		vB_0024StateMachine_10_NetDownloadByClient._0024State = -1;
		vB_0024StateMachine_10_NetDownloadByClient._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_10_NetDownloadByClient._0024Builder.Start<VB_0024StateMachine_10_NetDownloadByClient>(ref vB_0024StateMachine_10_NetDownloadByClient);
		return vB_0024StateMachine_10_NetDownloadByClient._0024Builder.Task;
	}

	public static void NetDownloadByLoader(string Url, string LocalFile, ModLoader.LoaderBase LoaderToSyncProgress = null, ModBase.FileChecker Check = null, bool UseBrowserUserAgent = false)
	{
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		string name = "文件下载 " + Conversions.ToString(ModBase.GetUuid()) + "#";
		List<NetFile> val = new List<NetFile>();
		val.Add(new NetFile(new string[] { Url }, LocalFile, Check, UseBrowserUserAgent));
		LoaderDownload loaderDownload = new LoaderDownload(name, val);
		try
		{
			loaderDownload.WaitForExit(null, LoaderToSyncProgress);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new WebException($"多线程直接下载文件失败（{Url}）", ex2);
		}
		finally
		{
			loaderDownload.Abort();
		}
	}

	public static void NetDownloadByLoader(System.Collections.Generic.IEnumerable<string> Urls, string LocalFile, ModLoader.LoaderBase LoaderToSyncProgress = null, ModBase.FileChecker Check = null, bool UseBrowserUserAgent = false)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		string name = "文件下载 " + Conversions.ToString(ModBase.GetUuid()) + "#";
		List<NetFile> obj = new List<NetFile>();
		obj.Add(new NetFile(Urls, LocalFile, Check, UseBrowserUserAgent));
		LoaderDownload loaderDownload = new LoaderDownload(name, obj);
		try
		{
			loaderDownload.WaitForExit(null, LoaderToSyncProgress);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new WebException("多线程直接下载文件失败（第一下载源：" + Enumerable.First<string>(Urls) + "）", ex2);
		}
		finally
		{
			loaderDownload.Abort();
		}
	}

	public static string NetRequestRetry(string Url, string Method, object Data, string ContentType, bool DontRetryOnRefused = true, Dictionary<string, string> Headers = null)
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00a0: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected I4, but got Unknown
		int num = 0;
		System.Exception ex = null;
		long timeTick = TimeUtils.GetTimeTick();
		while (num <= 3)
		{
			num = checked(num + 1);
			try
			{
				switch (num)
				{
				case 0:
					return NetRequestOnce(Url, Method, RuntimeHelpers.GetObjectValue(Data), ContentType, 15000, Headers);
				case 1:
					Thread.Sleep(500);
					return NetRequestOnce(Url, Method, RuntimeHelpers.GetObjectValue(Data), ContentType, 25000, Headers);
				default:
					if (checked(TimeUtils.GetTimeTick() - timeTick) > 5500)
					{
						Thread.Sleep(500);
						return NetRequestOnce(Url, Method, RuntimeHelpers.GetObjectValue(Data), ContentType, 4000, Headers);
					}
					throw ex;
				}
			}
			catch (ThreadInterruptedException val)
			{
				ProjectData.SetProjectError((System.Exception)val);
				ThreadInterruptedException val2 = val;
				throw;
			}
			catch (System.Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				System.Exception ex3 = ex2;
				if (ex3.InnerException != null && ex3.InnerException is HttpRequestFailedException && ModBase.StartsWithF(((int)((HttpRequestFailedException)(object)ex3.InnerException).StatusCode).ToString(), "4") && DontRetryOnRefused)
				{
					throw;
				}
				ex = ex3;
				ModBase.Log(ex3, $"[Net] 网络请求第 {num} 次失败（{Url}）");
				ProjectData.ClearProjectError();
			}
		}
		throw ex;
	}

	public static string NetRequestOnce(string Url, string Method, object Data, string ContentType, int Timeout = 25000, Dictionary<string, string> Headers = null, bool MakeLog = true, bool UseBrowserUserAgent = false)
	{
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d7: Expected O, but got Unknown
		//IL_02d9: Expected O, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		if (ModBase.RunInUi() && !Url.Contains("//127."))
		{
			throw new System.Exception("在 UI 线程执行了网络请求");
		}
		Url = Conversions.ToString(ModSecret.SecretCdnSign(Url));
		if (MakeLog)
		{
			ModBase.Log(string.Concat(new string[6]
			{
				"[Net] 发起网络请求（",
				Method,
				"，",
				Url,
				"），最大超时 ",
				Conversions.ToString(Timeout)
			}));
		}
		try
		{
			CancellationTokenSource val = new CancellationTokenSource();
			try
			{
				val.CancelAfter(Timeout);
				HttpMethod val2 = HttpMethod.Get;
				switch (Method.ToUpper())
				{
				case "POST":
					val2 = HttpMethod.Post;
					break;
				case "PUT":
					val2 = HttpMethod.Put;
					break;
				case "DELETE":
					val2 = HttpMethod.Delete;
					break;
				case "HEAD":
					val2 = HttpMethod.Head;
					break;
				case "OPTIONS":
					val2 = HttpMethod.Options;
					break;
				}
				HttpRequestMessage val3 = new HttpRequestMessage(val2, Url);
				try
				{
					string url = Url;
					HttpRequestMessage Client = val3;
					ModSecret.SecretHeadersSign(url, ref Client, UseBrowserUserAgent);
					if (Enumerable.Contains<HttpMethod>((System.Collections.Generic.IEnumerable<HttpMethod>)(object)new HttpMethod[2]
					{
						HttpMethod.Post,
						HttpMethod.Put
					}, val2) && !Information.IsNothing(RuntimeHelpers.GetObjectValue(Data)))
					{
						if (Data is byte[])
						{
							val3.Content = (HttpContent)new ByteArrayContent((byte[])Data);
						}
						else if (Data is string)
						{
							val3.Content = (HttpContent)new StringContent(Conversions.ToString(Data), Encoding.UTF8, ContentType);
						}
						else
						{
							if (!Data.GetType().IsSubclassOf(typeof(HttpContent)))
							{
								throw new ArgumentException("Data 参数类型不支持");
							}
							val3.Content = (HttpContent)Data;
						}
					}
					if (Headers != null)
					{
						System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>>);
						try
						{
							enumerator = Headers.GetEnumerator();
							while (enumerator.MoveNext())
							{
								KeyValuePair<string, string> current = enumerator.Current;
								if (!string.IsNullOrWhiteSpace(current.Key) && !string.IsNullOrWhiteSpace(current.Value))
								{
									if (((HttpHeaders)val3.Headers).Contains(current.Key))
									{
										((HttpHeaders)val3.Headers).Remove(current.Key);
									}
									((HttpHeaders)val3.Headers).Add(current.Key, current.Value);
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator).Dispose();
						}
					}
					HttpResponseMessage result = NetworkService.GetClient().SendAsync(val3, (HttpCompletionOption)1, val.Token).Result;
					try
					{
						EnsureSuccessStatusCode(result);
						Stream result2 = result.Content.ReadAsStreamAsync().Result;
						try
						{
							StreamReader val4 = new StreamReader(result2, Encoding.UTF8);
							try
							{
								return val4.ReadToEnd();
							}
							finally
							{
								((System.IDisposable)val4)?.Dispose();
							}
						}
						finally
						{
							((System.IDisposable)result2)?.Dispose();
						}
					}
					finally
					{
						((System.IDisposable)result)?.Dispose();
					}
				}
				finally
				{
					((System.IDisposable)val3)?.Dispose();
				}
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
		}
		catch (ThreadInterruptedException val5)
		{
			ProjectData.SetProjectError((System.Exception)val5);
			ThreadInterruptedException val6 = val5;
			throw;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			WebException val7 = ((ex2 is HttpRequestFailedException) ? new HttpWebException("网络请求失败（" + Url + "）", (HttpRequestFailedException)(object)ex2) : new WebException("网络请求失败（" + Url + "）", ex2));
			if (MakeLog)
			{
				ModBase.Log((System.Exception)(object)val7, "NetRequestOnce 请求失败", ModBase.LogLevel.Developer);
			}
			throw val7;
		}
	}

	public static bool HasDownloadingTask(bool IgnoreCustomDownload = false)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
		try
		{
			enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
			while (enumerator.MoveNext())
			{
				ModLoader.LoaderBase current = enumerator.Current;
				if (current.Show && current.State == ModBase.LoadState.Loading && (!IgnoreCustomDownload || !current.Name.ToString().Contains("自定义下载")))
				{
					return true;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		return false;
	}
}
