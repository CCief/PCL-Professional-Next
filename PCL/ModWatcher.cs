using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Logging;

namespace PCL;

[StandardModule]
public sealed class ModWatcher
{
	public class LogOutputEventArgs : EventArgs
	{
		public string LogText;

		public SolidColorBrush Color;

		public LogOutputEventArgs(string LogText, SolidColorBrush Color)
		{
			this.LogText = LogText;
			this.Color = Color;
		}
	}

	private enum GameLogLevel
	{
		Debug,
		Info,
		Warn,
		Error,
		Fatal
	}

	public class Watcher
	{
		public delegate void GameExitEventHandler();

		public enum MinecraftState
		{
			Loading,
			Running,
			Crashed,
			Ended,
			Canceled
		}

		public delegate void LogOutputEventHandler(Watcher sender, LogOutputEventArgs e);

		private delegate void EnumWindowsSub(nint hwnd, int lParam);

		[CompilerGenerated]
		internal sealed class _Closure_0024__6_002D0
		{
			public string _0024VB_0024Local_WindowTitle;

			public ModLoader.LoaderTask<Process, int> _0024VB_0024Local_Loader;

			public Watcher _0024VB_0024Me;

			public _Closure_0024__6_002D0(_Closure_0024__6_002D0 arg0)
			{
				if (arg0 != null)
				{
					_0024VB_0024Local_WindowTitle = arg0._0024VB_0024Local_WindowTitle;
					_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
				}
			}

			[SpecialName]
			internal void _Lambda_0024__0()
			{
				try
				{
					while (_0024VB_0024Me.State != MinecraftState.Ended && _0024VB_0024Me.State != MinecraftState.Crashed && _0024VB_0024Me.State != MinecraftState.Canceled && _0024VB_0024Local_Loader.State != ModBase.LoadState.Aborted)
					{
						_0024VB_0024Me.TimerWindow();
						_0024VB_0024Me.TimerLog();
						int num = 1;
						do
						{
							if (_0024VB_0024Me.IsWindowFinished && _0024VB_0024Me.IsWindowAppeared && Operators.CompareString(_0024VB_0024Local_WindowTitle, "", false) != 0 && _0024VB_0024Me.State == MinecraftState.Running && !_0024VB_0024Me.GameProcess.HasExited)
							{
								string text = _0024VB_0024Local_WindowTitle.Replace("{date}", System.DateTime.Now.ToString("yyyy/M/d")).Replace("{time}", System.DateTime.Now.ToString("HH:mm:ss"));
								int hWnd = (int)(System.IntPtr)_0024VB_0024Me.WindowHandle;
								string str = new string(text.ToCharArray());
								SetWindowText(hWnd, ref str);
							}
							Thread.Sleep(64);
							num = checked(num + 1);
						}
						while (num <= 3);
					}
					_0024VB_0024Me.WatcherLog("Minecraft 日志监控已退出");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "Minecraft 日志监控主循环出错", ModBase.LogLevel.Feedback);
					_0024VB_0024Me.State = MinecraftState.Ended;
					ProjectData.ClearProjectError();
				}
			}
		}

		public Process GameProcess;

		public ModMinecraft.McInstance Version;

		private string WindowTitle;

		private int PID;

		public string JStackPath;

		public ModLoader.LoaderTask<Process, int> Loader;

		[CompilerGenerated]
		private GameExitEventHandler GameExitEvent;

		private MinecraftState _State;

		public List<string> WaitingLog;

		private readonly object WaitingLogLock;

		private bool RealTime;

		public List<string> FullLog;

		private GameLogLevel LastLevel;

		public uint CountFatal;

		public uint CountError;

		public uint CountWarn;

		public uint CountInfo;

		public uint CountDebug;

		[CompilerGenerated]
		private LogOutputEventHandler LogOutputEvent;

		public Queue<string> LatestLog;

		private int LogProgress;

		private bool IsWindowAppeared;

		private bool IsWindowFinished;

		private nint WindowHandle;

		public MinecraftState State
		{
			get
			{
				return _State;
			}
			set
			{
				if (_State != value)
				{
					_State = value;
					WatcherStateChanged();
				}
			}
		}

		public bool RealTimeLog => RealTime;

		public event GameExitEventHandler GameExit
		{
			[CompilerGenerated]
			add
			{
				GameExitEventHandler gameExitEventHandler = GameExitEvent;
				GameExitEventHandler gameExitEventHandler2;
				do
				{
					gameExitEventHandler2 = gameExitEventHandler;
					GameExitEventHandler gameExitEventHandler3 = (GameExitEventHandler)System.Delegate.Combine((System.Delegate)gameExitEventHandler2, (System.Delegate)value);
					gameExitEventHandler = Interlocked.CompareExchange<GameExitEventHandler>(ref GameExitEvent, gameExitEventHandler3, gameExitEventHandler2);
				}
				while (gameExitEventHandler != gameExitEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				GameExitEventHandler gameExitEventHandler = GameExitEvent;
				GameExitEventHandler gameExitEventHandler2;
				do
				{
					gameExitEventHandler2 = gameExitEventHandler;
					GameExitEventHandler gameExitEventHandler3 = (GameExitEventHandler)System.Delegate.Remove((System.Delegate)gameExitEventHandler2, (System.Delegate)value);
					gameExitEventHandler = Interlocked.CompareExchange<GameExitEventHandler>(ref GameExitEvent, gameExitEventHandler3, gameExitEventHandler2);
				}
				while (gameExitEventHandler != gameExitEventHandler2);
			}
		}

		public event LogOutputEventHandler LogOutput
		{
			[CompilerGenerated]
			add
			{
				LogOutputEventHandler logOutputEventHandler = LogOutputEvent;
				LogOutputEventHandler logOutputEventHandler2;
				do
				{
					logOutputEventHandler2 = logOutputEventHandler;
					LogOutputEventHandler logOutputEventHandler3 = (LogOutputEventHandler)System.Delegate.Combine((System.Delegate)logOutputEventHandler2, (System.Delegate)value);
					logOutputEventHandler = Interlocked.CompareExchange<LogOutputEventHandler>(ref LogOutputEvent, logOutputEventHandler3, logOutputEventHandler2);
				}
				while (logOutputEventHandler != logOutputEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				LogOutputEventHandler logOutputEventHandler = LogOutputEvent;
				LogOutputEventHandler logOutputEventHandler2;
				do
				{
					logOutputEventHandler2 = logOutputEventHandler;
					LogOutputEventHandler logOutputEventHandler3 = (LogOutputEventHandler)System.Delegate.Remove((System.Delegate)logOutputEventHandler2, (System.Delegate)value);
					logOutputEventHandler = Interlocked.CompareExchange<LogOutputEventHandler>(ref LogOutputEvent, logOutputEventHandler3, logOutputEventHandler2);
				}
				while (logOutputEventHandler != logOutputEventHandler2);
			}
		}

		public Watcher(ModLoader.LoaderTask<Process, int> Loader, ModMinecraft.McInstance Version, string WindowTitle, string JStackPath, bool OutputRealTime = false)
		{
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Expected O, but got Unknown
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Expected O, but got Unknown
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Expected O, but got Unknown
			_Closure_0024__6_002D0 arg = default(_Closure_0024__6_002D0);
			_Closure_0024__6_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__6_002D0(null);
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader = Loader;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_WindowTitle = WindowTitle;
			CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
			this.WindowTitle = "";
			_State = MinecraftState.Loading;
			WaitingLog = new List<string>(1000);
			WaitingLogLock = RuntimeHelpers.GetObjectValue(new object());
			FullLog = new List<string>();
			LastLevel = GameLogLevel.Info;
			CountFatal = 0u;
			CountError = 0u;
			CountWarn = 0u;
			CountInfo = 0u;
			CountDebug = 0u;
			LatestLog = new Queue<string>();
			LogProgress = 0;
			IsWindowAppeared = false;
			IsWindowFinished = false;
			this.Loader = CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader;
			this.Version = Version;
			this.WindowTitle = CS_0024_003C_003E8__locals0._0024VB_0024Local_WindowTitle;
			RealTime = OutputRealTime;
			PID = CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input.Id;
			this.JStackPath = JStackPath;
			WatcherLog("开始 Minecraft 日志监控");
			if (Operators.CompareString(this.WindowTitle, "", false) != 0)
			{
				WatcherLog("要求窗口标题：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_WindowTitle);
			}
			List<Watcher> val = new List<Watcher>();
			System.Collections.Generic.IEnumerator<Watcher> enumerator = default(System.Collections.Generic.IEnumerator<Watcher>);
			try
			{
				enumerator = McWatcherList.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Watcher current = enumerator.Current;
					if (current.State != MinecraftState.Crashed && current.State != MinecraftState.Ended && current.State != MinecraftState.Canceled)
					{
						val.Add(current);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			val.Add(this);
			McWatcherList = val;
			WatcherStateChanged();
			GameProcess = CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Input;
			GameProcess.BeginOutputReadLine();
			GameProcess.BeginErrorReadLine();
			GameProcess.OutputDataReceived += new DataReceivedEventHandler(LogReceived);
			GameProcess.ErrorDataReceived += new DataReceivedEventHandler(LogReceived);
			ModBase.RunInNewThread((Action)([SpecialName] () =>
			{
				try
				{
					while (CS_0024_003C_003E8__locals0._0024VB_0024Me.State != MinecraftState.Ended && CS_0024_003C_003E8__locals0._0024VB_0024Me.State != MinecraftState.Crashed && CS_0024_003C_003E8__locals0._0024VB_0024Me.State != MinecraftState.Canceled && CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.State != ModBase.LoadState.Aborted)
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Me.TimerWindow();
						CS_0024_003C_003E8__locals0._0024VB_0024Me.TimerLog();
						int num = 1;
						do
						{
							if (CS_0024_003C_003E8__locals0._0024VB_0024Me.IsWindowFinished && CS_0024_003C_003E8__locals0._0024VB_0024Me.IsWindowAppeared && Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_WindowTitle, "", false) != 0 && CS_0024_003C_003E8__locals0._0024VB_0024Me.State == MinecraftState.Running && !CS_0024_003C_003E8__locals0._0024VB_0024Me.GameProcess.HasExited)
							{
								string text = CS_0024_003C_003E8__locals0._0024VB_0024Local_WindowTitle.Replace("{date}", System.DateTime.Now.ToString("yyyy/M/d")).Replace("{time}", System.DateTime.Now.ToString("HH:mm:ss"));
								int hWnd = (int)(System.IntPtr)CS_0024_003C_003E8__locals0._0024VB_0024Me.WindowHandle;
								string str = new string(text.ToCharArray());
								SetWindowText(hWnd, ref str);
							}
							Thread.Sleep(64);
							num = checked(num + 1);
						}
						while (num <= 3);
					}
					CS_0024_003C_003E8__locals0._0024VB_0024Me.WatcherLog("Minecraft 日志监控已退出");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "Minecraft 日志监控主循环出错", ModBase.LogLevel.Feedback);
					CS_0024_003C_003E8__locals0._0024VB_0024Me.State = MinecraftState.Ended;
					ProjectData.ClearProjectError();
				}
			}), "Minecraft Watcher PID " + Conversions.ToString(PID), (ThreadPriority)2);
		}

		private void LogReceived(object sender, DataReceivedEventArgs e)
		{
			object waitingLogLock = WaitingLogLock;
			ObjectFlowControl.CheckForSyncLockOnValueType(waitingLogLock);
			bool flag = false;
			try
			{
				Monitor.Enter(waitingLogLock, ref flag);
				WaitingLog.Add(e.Data);
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(waitingLogLock);
				}
			}
			if (RealTime)
			{
				LogRealTime(e.Data, ref LastLevel);
				if (e.Data != null)
				{
					FullLog.Add(e.Data);
				}
			}
		}

		private void LogRealTime(string line, ref GameLogLevel level)
		{
			checked
			{
				if (line != null)
				{
					level = ((ModBase.StartsWithF(line, "\tat ") || ModBase.StartsWithF(line, "Caused by: ") || ModBase.StartsWithF(line, "\t... ")) ? level : GetLevel(line, level));
					SolidColorBrush color = GetColor(level);
					switch (level)
					{
					case GameLogLevel.Debug:
					{
						ref uint countDebug = ref CountDebug;
						countDebug = (uint)(unchecked((long)countDebug) + 1L);
						break;
					}
					case GameLogLevel.Info:
					{
						ref uint countInfo = ref CountInfo;
						countInfo = (uint)(unchecked((long)countInfo) + 1L);
						break;
					}
					case GameLogLevel.Warn:
					{
						ref uint countWarn = ref CountWarn;
						countWarn = (uint)(unchecked((long)countWarn) + 1L);
						break;
					}
					case GameLogLevel.Error:
					{
						ref uint countError = ref CountError;
						countError = (uint)(unchecked((long)countError) + 1L);
						break;
					}
					case GameLogLevel.Fatal:
					{
						ref uint countFatal = ref CountFatal;
						countFatal = (uint)(unchecked((long)countFatal) + 1L);
						break;
					}
					}
					LogOutputEvent?.Invoke(this, new LogOutputEventArgs(line, color));
				}
			}
		}

		private void TimerLog()
		{
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				List<string> val = new List<string>();
				object waitingLogLock = WaitingLogLock;
				ObjectFlowControl.CheckForSyncLockOnValueType(waitingLogLock);
				bool flag = false;
				try
				{
					Monitor.Enter(waitingLogLock, ref flag);
					if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)WaitingLog))
					{
						return;
					}
					val = WaitingLog;
					WaitingLog = new List<string>(1000);
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(waitingLogLock);
					}
				}
				System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
				try
				{
					enumerator = val.GetEnumerator();
					while (enumerator.MoveNext())
					{
						string current = enumerator.Current;
						GameLog(current);
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				if (State == MinecraftState.Loading)
				{
					ProgressUpdate();
				}
				if (GameProcess.HasExited)
				{
					WatcherLog("Minecraft 已退出，返回值：" + Conversions.ToString(GameProcess.ExitCode));
					if (RealTime)
					{
						string line = $"Minecraft 已退出，返回值：{GameProcess.ExitCode}";
						GameLogLevel level = GameLogLevel.Info;
						LogRealTime(line, ref level);
					}
					GameExitEvent?.Invoke();
					if (State == MinecraftState.Loading)
					{
						WatcherLog("Minecraft 尚未加载完成，可能已崩溃");
						Crashed();
					}
					else if (GameProcess.ExitCode != 0 && State == MinecraftState.Running && Version.ReleaseTime.Year >= 2012)
					{
						WatcherLog("Minecraft 返回值异常，可能已崩溃");
						Crashed();
					}
					else if (State != MinecraftState.Crashed)
					{
						State = MinecraftState.Ended;
					}
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "输出 Minecraft 日志失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}

		private void GameLog(string Text)
		{
			if (Text == null)
			{
				return;
			}
			Text = Text.Replace("\r\n", "\r").Replace("\n", "\r").Replace("\r", "\r\n");
			LatestLog.Enqueue(Text);
			if (LatestLog.Count >= 501)
			{
				LatestLog.Dequeue();
			}
			if (LogProgress < 1)
			{
				WatcherLog("日志 1/5：已出现日志输出");
				LogProgress = 1;
			}
			if (LogProgress < 2 && Text.Contains("Setting user:"))
			{
				WatcherLog("日志 2/5：游戏用户已设置");
				LogProgress = 2;
			}
			else if (LogProgress < 3 && ModBase.ContainsF(Text, "lwjgl version", IgnoreCase: true))
			{
				WatcherLog("日志 3/5：LWJGL 版本已确认");
				LogProgress = 3;
			}
			else if (LogProgress < 4 && (Text.Contains("OpenAL initialized") || Text.Contains("Starting up SoundSystem")))
			{
				WatcherLog("日志 4/5：OpenAL 已加载");
				LogProgress = 4;
			}
			else if (LogProgress < 5 && ((Text.Contains("Created") && Text.Contains("textures") && Text.Contains("-atlas")) || Text.Contains("Found animation info")))
			{
				WatcherLog("日志 5/5：材质已加载");
				LogProgress = 5;
			}
			if (!Text.Contains("[CHAT]"))
			{
				if (Text.Contains("Someone is closing me!") || Text.Contains("Restarting Minecraft with command"))
				{
					WatcherLog("识别为关闭的 Log：" + Text);
					State = MinecraftState.Ended;
				}
				else if (Text.Contains("Crash report saved to") || Text.Contains("This crash report has been saved to:"))
				{
					WatcherLog("识别为崩溃的 Log：" + Text);
					Crashed();
				}
				else if (Text.Contains("Could not save crash report to"))
				{
					WatcherLog("识别为崩溃的 Log：" + Text);
					Crashed();
				}
				else if (Text.Contains("/ERROR]: Unable to launch") || Text.Contains("An exception was thrown, the game will display an error screen and halt."))
				{
					WatcherLog("识别为崩溃的 Log：" + Text);
					Crashed();
				}
			}
		}

		private void WatcherLog(string Text)
		{
			ModLaunch.McLaunchLog("[" + Conversions.ToString(PID) + "] " + Text);
		}

		private void ProgressUpdate()
		{
			double progress;
			if (IsWindowAppeared || LogProgress >= 4)
			{
				progress = 0.95;
				WatcherLog("Minecraft 加载已完成");
				State = MinecraftState.Running;
			}
			else
			{
				progress = (double)Math.Min(LogProgress, 3) / 3.0 * 0.9;
			}
			Loader.Progress = progress;
		}

		private void TimerWindow()
		{
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_0044: Expected O, but got Unknown
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Expected O, but got Unknown
			try
			{
				if (GameProcess.HasExited || IsWindowFinished)
				{
					return;
				}
				KeyValuePair<nint, string>? val = null;
				try
				{
					val = TryGetMinecraftWindow();
				}
				catch (Win32Exception val2)
				{
					ProjectData.SetProjectError((System.Exception)val2);
					Win32Exception ex = val2;
					ModBase.Log((System.Exception)(object)ex, "由于反作弊或安全软件拦截，PCL 无法操作游戏窗口", ModBase.LogLevel.Hint);
					IsWindowFinished = true;
					ProjectData.ClearProjectError();
				}
				if (!val.HasValue)
				{
					return;
				}
				string value = val.Value.Value;
				nint key = val.Value.Key;
				if (!ModBase.StartsWithF(value, "FML") && !ModBase.StartsWithF(value, "Quilt Loader"))
				{
					WindowHandle = key;
					WatcherLog($"Minecraft 窗口已加载：{value}（{((System.IntPtr)key).ToInt64()}）");
					IsWindowFinished = true;
					if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("LaunchArgumentWindowType"), (object)4, false))
					{
						ModBase.RunInNewThread((Action)([SpecialName] () =>
						{
							try
							{
								Thread.Sleep(2000);
								ShowWindow(WindowHandle, 3u);
								WatcherLog($"已最大化 Minecraft 窗口：{((System.IntPtr)key).ToInt64()}");
							}
							catch (System.Exception ex4)
							{
								ProjectData.SetProjectError(ex4);
								System.Exception ex5 = ex4;
								ModBase.Log(ex5, "最大化 Minecraft 窗口时出现错误");
								ProjectData.ClearProjectError();
							}
						}), "MinecraftWindowMaximize", (ThreadPriority)2);
					}
				}
				else if (!IsWindowAppeared)
				{
					WatcherLog(string.Concat(new string[5]
					{
						"FML 窗口已加载：",
						value,
						"（",
						Conversions.ToString(((System.IntPtr)key).ToInt64()),
						"）"
					}));
				}
				IsWindowAppeared = true;
			}
			catch (System.Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				System.Exception ex3 = ex2;
				ModBase.Log(ex3, "检查 Minecraft 窗口失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}

		private KeyValuePair<nint, string>? TryGetMinecraftWindow()
		{
			KeyValuePair<nint, string>? val = null;
			EnumWindows([SpecialName] (nint hwnd, int lParam) =>
			{
				//IL_0015: Unknown result type (might be due to invalid IL or missing references)
				//IL_001b: Expected O, but got Unknown
				//IL_0067: Unknown result type (might be due to invalid IL or missing references)
				//IL_006d: Expected O, but got Unknown
				//IL_0105: Unknown result type (might be due to invalid IL or missing references)
				if (!val.HasValue)
				{
					StringBuilder val2 = new StringBuilder(512);
					GetClassName((int)(System.IntPtr)hwnd, val2, val2.Capacity);
					switch (val2.ToString())
					{
					case "GLFW30":
					case "LWJGL":
					case "SunAwtFrame":
					{
						val2 = new StringBuilder(512);
						GetWindowText((int)(System.IntPtr)hwnd, val2, val2.Capacity);
						string text = val2.ToString();
						if (ModBase.StartsWithF(text, "FML") || (Operators.CompareString(text, "PopupMessageWindow", false) != 0 && !ModBase.StartsWithF(text, "GLFW")))
						{
							int lpdwProcessId = default(int);
							GetWindowThreadProcessId(hwnd, ref lpdwProcessId);
							try
							{
								if (System.DateTime.Compare(Process.GetProcessById(lpdwProcessId).StartTime, GameProcess.StartTime) < 0)
								{
									break;
								}
							}
							catch (System.Exception ex)
							{
								ProjectData.SetProjectError(ex);
								System.Exception ex2 = ex;
								ModBase.Log(ex2, "枚举 Minecraft 窗口进程失败");
								ProjectData.ClearProjectError();
								break;
							}
							val = new KeyValuePair<nint, string>(hwnd, text);
						}
						break;
					}
					}
				}
			}, 0);
			val = val;
			return val;
		}

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern bool EnumWindows(EnumWindowsSub hWnd, int lParam);

		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "GetClassNameA", ExactSpelling = true, SetLastError = true)]
		private static extern int GetClassName(int hWnd, StringBuilder str, int maxCount);

		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "GetWindowTextA", ExactSpelling = true, SetLastError = true)]
		private static extern int GetWindowText(int hWnd, StringBuilder str, int maxCount);

		[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "SetWindowTextA", ExactSpelling = true, SetLastError = true)]
		private static extern bool SetWindowText(int hWnd, [MarshalAs(34)] ref string str);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern bool ShowWindow(nint hWnd, uint cmdWindow);

		[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
		private static extern int GetWindowThreadProcessId(nint hWnd, ref int lpdwProcessId);

		private void Crashed()
		{
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			if (State == MinecraftState.Crashed || State == MinecraftState.Ended)
			{
				return;
			}
			State = MinecraftState.Crashed;
			WatcherLog("Minecraft 已崩溃，将在 2 秒后开始崩溃分析");
			ModMain.Hint("检测到 Minecraft 出现错误，错误分析已开始……");
			ModBase.FeedbackInfo();
			ModBase.RunInNewThread((Action)([SpecialName] [CompilerGenerated] () =>
			{
				try
				{
					Thread.Sleep(2000);
					WatcherLog("崩溃分析开始");
					CrashAnalyzer crashAnalyzer = new CrashAnalyzer(PID);
					crashAnalyzer.Collect(Version.PathIndie, (System.Collections.Generic.IList<string>)Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)LatestLog));
					crashAnalyzer.Prepare();
					crashAnalyzer.Analyze(Version);
					List<string> obj = new List<string>();
					obj.Add(Version.Path + Version.Name + ".json");
					obj.Add(Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)LogWrapper.CurrentLogger.LogFiles));
					obj.Add(ModBase.ExePath + "PCL\\LatestLaunch.bat");
					crashAnalyzer.Output(IsHandAnalyze: false, obj);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "崩溃分析失败", ModBase.LogLevel.Feedback);
					ProjectData.ClearProjectError();
				}
			}), "Crash Analyzer", (ThreadPriority)2);
		}

		public bool CheckAlive(Process p)
		{
			if (!p.HasExited)
			{
				return true;
			}
			if (System.Array.Exists<Process>(Process.GetProcesses(), (Predicate<Process>)([SpecialName] (Process item) => item.Id == p.Id)))
			{
				return true;
			}
			return false;
		}

		public void Kill()
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			State = MinecraftState.Canceled;
			ModBase.RunInNewThread((Action)([SpecialName] [CompilerGenerated] () =>
			{
				WatcherLog("尝试强制结束 Minecraft 进程");
				try
				{
					if (CheckAlive(GameProcess))
					{
						GameProcess.Kill();
					}
					GameProcess.WaitForExit(5000);
					if (CheckAlive(GameProcess))
					{
						WatcherLog("进程仍未退出，尝试使用 taskkill.exe");
						string text = Process.Start("taskkill.exe", $"/PID {GameProcess.Id} /F /T").StandardOutput.ReadToEnd();
						ModBase.Log($"执行 taskkill.exe 结果: {text}");
						GameProcess.WaitForExit(5000);
						if (CheckAlive(GameProcess))
						{
							WatcherLog("强制结束 Minecraft 进程失败: 等待进程退出超时");
							return;
						}
					}
					WatcherLog("已强制结束 Minecraft 进程");
					if (RealTime)
					{
						string line = $"Minecraft 已退出，返回值：{GameProcess.ExitCode}";
						GameLogLevel level = GameLogLevel.Info;
						LogRealTime(line, ref level);
					}
					GameExitEvent?.Invoke();
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "强制结束 Minecraft 进程失败", ModBase.LogLevel.Hint);
					ProjectData.ClearProjectError();
				}
			}), null, (ThreadPriority)2);
		}

		public List<string> ExportStackDump(string SavePath)
		{
			List<string> val = new List<string>();
			int num = 1;
			do
			{
				val.Add(ModBase.ShellAndGetOutput(JStackPath, "-l -e " + Conversions.ToString(GameProcess.Id)));
				Thread.Sleep(3000);
				num = checked(num + 1);
			}
			while (num <= 3);
			return val;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action _0024I6_002D0;

		public static Action _0024I6_002D1;

		public static Action _0024I6_002D2;

		public static Action _0024I6_002D3;

		public static Action _0024I6_002D4;

		public static Func<string, SolidColorBrush> _0024I9_002D0;

		public static Func<string, SolidColorBrush> _0024I10_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__6_002D0()
		{
			if (ModMusic.MusicResume())
			{
				ModBase.Log("[Music] 已根据设置，在结束后开始音乐播放");
			}
		}

		[SpecialName]
		internal void _Lambda_0024__6_002D1()
		{
			if (ModMusic.MusicPause())
			{
				ModBase.Log("[Music] 已根据设置，在结束后暂停音乐播放");
			}
		}

		[SpecialName]
		internal void _Lambda_0024__6_002D2()
		{
			ModMain.FrmMain.EndProgram(SendWarning: false);
		}

		[SpecialName]
		internal void _Lambda_0024__6_002D3()
		{
			ModMain.FrmMain.Hidden = false;
		}

		[SpecialName]
		internal void _Lambda_0024__6_002D4()
		{
			ModMain.FrmMain.Hidden = false;
		}

		[SpecialName]
		internal SolidColorBrush _Lambda_0024__9_002D0(string name)
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			return (SolidColorBrush)Application.Current.Resources[(object)name];
		}

		[SpecialName]
		internal SolidColorBrush _Lambda_0024__10_002D0(string name)
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			return (SolidColorBrush)Application.Current.Resources[(object)name];
		}
	}

	public static List<Watcher> McWatcherList = new List<Watcher>();

	private static bool IsWatcherRunning = false;

	public static bool HasRunningMinecraft = false;

	private static void WatcherStateChanged()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		bool flag = false;
		bool triggerLauncherShutdown = true;
		System.Collections.Generic.IEnumerator<Watcher> enumerator = default(System.Collections.Generic.IEnumerator<Watcher>);
		try
		{
			enumerator = McWatcherList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				Watcher current = enumerator.Current;
				if (current.State == Watcher.MinecraftState.Loading || current.State == Watcher.MinecraftState.Running)
				{
					flag = true;
					break;
				}
				if (current.State == Watcher.MinecraftState.Crashed || current.State == Watcher.MinecraftState.Canceled)
				{
					triggerLauncherShutdown = false;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		if (IsWatcherRunning != flag)
		{
			IsWatcherRunning = flag;
			if (IsWatcherRunning)
			{
				MinecraftStart();
			}
			else
			{
				MinecraftStop(triggerLauncherShutdown);
			}
		}
	}

	private static void MinecraftStart()
	{
		ModLaunch.McLaunchLog("[全局] 出现运行中的 Minecraft");
		HasRunningMinecraft = true;
		ModMain.FrmMain.BtnExtraShutdown.ShowRefresh();
	}

	private static void MinecraftStop(bool TriggerLauncherShutdown)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		ModLaunch.McLaunchLog("[全局] 已无运行中的 Minecraft");
		HasRunningMinecraft = false;
		ModMain.FrmMain.BtnExtraShutdown.ShowRefresh();
		if (Conversions.ToBoolean(ModBase.Setup.Get("UiMusicStop")))
		{
			object action;
			if (_Closure_0024__._0024I6_002D0 != null)
			{
				action = _Closure_0024__._0024I6_002D0;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					if (ModMusic.MusicResume())
					{
						ModBase.Log("[Music] 已根据设置，在结束后开始音乐播放");
					}
				};
				_Closure_0024__._0024I6_002D0 = val;
				action = (object)val;
			}
			ModBase.RunInUi((Action)action);
		}
		else if (Conversions.ToBoolean(ModBase.Setup.Get("UiMusicStart")))
		{
			object action2;
			if (_Closure_0024__._0024I6_002D1 != null)
			{
				action2 = _Closure_0024__._0024I6_002D1;
			}
			else
			{
				Action val2 = [SpecialName] () =>
				{
					if (ModMusic.MusicPause())
					{
						ModBase.Log("[Music] 已根据设置，在结束后暂停音乐播放");
					}
				};
				_Closure_0024__._0024I6_002D1 = val2;
				action2 = (object)val2;
			}
			ModBase.RunInUi((Action)action2);
		}
		ModVideoBack.IsGaming = false;
		ModVideoBack.VideoPlay();
		object obj = ModBase.Setup.Get("LaunchArgumentVisible");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)2, false))
		{
			if (TriggerLauncherShutdown)
			{
				object action3;
				if (_Closure_0024__._0024I6_002D2 != null)
				{
					action3 = _Closure_0024__._0024I6_002D2;
				}
				else
				{
					Action val3 = [SpecialName] () =>
					{
						ModMain.FrmMain.EndProgram(SendWarning: false);
					};
					_Closure_0024__._0024I6_002D2 = val3;
					action3 = (object)val3;
				}
				ModBase.RunInUi((Action)action3);
				return;
			}
			object action4;
			if (_Closure_0024__._0024I6_002D3 != null)
			{
				action4 = _Closure_0024__._0024I6_002D3;
			}
			else
			{
				Action val4 = [SpecialName] () =>
				{
					ModMain.FrmMain.Hidden = false;
				};
				_Closure_0024__._0024I6_002D3 = val4;
				action4 = (object)val4;
			}
			ModBase.RunInUi((Action)action4);
		}
		else
		{
			if (!Operators.ConditionalCompareObjectEqual(obj, (object)3, false))
			{
				return;
			}
			object action5;
			if (_Closure_0024__._0024I6_002D4 != null)
			{
				action5 = _Closure_0024__._0024I6_002D4;
			}
			else
			{
				Action val5 = [SpecialName] () =>
				{
					ModMain.FrmMain.Hidden = false;
				};
				_Closure_0024__._0024I6_002D4 = val5;
				action5 = (object)val5;
			}
			ModBase.RunInUi((Action)action5);
		}
	}

	private static GameLogLevel GetLevel(string line, GameLogLevel lastLevel)
	{
		if (_Closure_0024__._0024I9_002D0 != null)
		{
			_ = _Closure_0024__._0024I9_002D0;
		}
		else
		{
			_Closure_0024__._0024I9_002D0 = [SpecialName] (string name) => (SolidColorBrush)Application.Current.Resources[(object)name];
		}
		string str = line.Split(": ", (StringSplitOptions)0)[0];
		if (ModBase.ContainsF(str, "FATAL"))
		{
			return GameLogLevel.Fatal;
		}
		if (ModBase.ContainsF(str, "ERROR"))
		{
			return GameLogLevel.Error;
		}
		if (ModBase.ContainsF(str, "WARN"))
		{
			return GameLogLevel.Warn;
		}
		if (ModBase.ContainsF(str, "INFO"))
		{
			return GameLogLevel.Info;
		}
		if (ModBase.ContainsF(str, "DEBUG"))
		{
			return GameLogLevel.Debug;
		}
		if (ModBase.StartsWithF(line, "Exception in thread \""))
		{
			return GameLogLevel.Error;
		}
		if ((ModBase.ContainsF(line, "Exception") || ModBase.ContainsF(line, "Realms authentication error with message ")) && lastLevel >= GameLogLevel.Warn)
		{
			return lastLevel;
		}
		if (ModBase.StartsWithF(line, "\tat ") && lastLevel >= GameLogLevel.Warn)
		{
			return lastLevel;
		}
		return GameLogLevel.Info;
	}

	private static SolidColorBrush GetColor(GameLogLevel level)
	{
		Func<string, SolidColorBrush> val = [SpecialName] (string name) => (SolidColorBrush)Application.Current.Resources[(object)name];
		switch (level)
		{
		case GameLogLevel.Debug:
			return val.Invoke("ColorBrushDebug");
		case GameLogLevel.Info:
			val.Invoke(ModSecret.IsDarkMode ? "ColorBrushInfoDark" : "ColorBrushInfo");
			break;
		case GameLogLevel.Warn:
			return val.Invoke("ColorBrushWarn");
		case GameLogLevel.Error:
			return val.Invoke("ColorBrushError");
		case GameLogLevel.Fatal:
			return val.Invoke("ColorBrushFatal");
		}
		return val.Invoke(ModSecret.IsDarkMode ? "ColorBrushInfoDark" : "ColorBrushInfo");
	}
}
