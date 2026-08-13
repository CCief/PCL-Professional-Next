using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Shell;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Utils;

namespace PCL;

[StandardModule]
public sealed class ModLoader
{
	public abstract class LoaderBase : ILoadingTrigger
	{
		public delegate void OnStateChangedThreadEventHandler(LoaderBase Loader, ModBase.LoadState NewState, ModBase.LoadState OldState);

		public delegate void OnStateChangedUiEventHandler(LoaderBase Loader, ModBase.LoadState NewState, ModBase.LoadState OldState);

		public delegate void PreviewFinishEventHandler(LoaderBase Loader);

		public int Uuid;

		public string Name;

		public readonly object LockState;

		public LoaderBase Parent;

		[CompilerGenerated]
		private OnStateChangedThreadEventHandler OnStateChangedThreadEvent;

		public bool HasOnStateChangedThread;

		[CompilerGenerated]
		private OnStateChangedUiEventHandler OnStateChangedUiEvent;

		[CompilerGenerated]
		private PreviewFinishEventHandler PreviewFinishEvent;

		private ModBase.LoadState _State;

		private MyLoading.MyLoadingState _LoadingState;

		[CompilerGenerated]
		private ILoadingTrigger.LoadingStateChangedEventHandler LoadingStateChangedEvent;

		public bool Block;

		public bool Show;

		public bool IsForceRestarting;

		private double _Progress;

		[CompilerGenerated]
		private ILoadingTrigger.ProgressChangedEventHandler ProgressChangedEvent;

		public const string WaitForExitTimeoutMessage = "等待加载器执行超时。";

		[field: CompilerGenerated]
		public bool IsLoader
		{
			[CompilerGenerated]
			get;
		}

		public LoaderBase RealParent
		{
			get
			{
				LoaderBase loaderBase;
				try
				{
					loaderBase = Parent;
					while (loaderBase != null && loaderBase.Parent != null)
					{
						loaderBase = loaderBase.Parent;
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "获取父加载器失败（" + Name + "）", ModBase.LogLevel.Feedback);
					loaderBase = null;
					ProjectData.ClearProjectError();
				}
				return loaderBase;
			}
		}

		public Action<LoaderBase> OnStateChanged
		{
			set
			{
				OnStateChangedUi += [SpecialName] (LoaderBase Loader, ModBase.LoadState NewState, ModBase.LoadState OldState) =>
				{
					value.Invoke(Loader);
				};
			}
		}

		public ModBase.LoadState State
		{
			get
			{
				return _State;
			}
			set
			{
				//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
				//IL_00bd: Expected O, but got Unknown
				//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d6: Expected O, but got Unknown
				if (_State == value)
				{
					return;
				}
				ModBase.LoadState state = _State;
				if (Conversions.ToBoolean((object)(value == ModBase.LoadState.Finished && Conversions.ToBoolean(ModBase.Setup.Get("SystemDebugDelay")))))
				{
					Thread.Sleep(RandomUtils.NextInt(100, 2000));
				}
				_State = value;
				ModBase.Log("[Loader] 加载器 " + Name + " 状态改变：" + ModBase.GetStringFromEnum(value));
				ModBase.RunInUi((Action)([SpecialName] () =>
				{
					switch (value)
					{
					case ModBase.LoadState.Loading:
						LoadingState = MyLoading.MyLoadingState.Run;
						break;
					case ModBase.LoadState.Failed:
						LoadingState = MyLoading.MyLoadingState.Error;
						break;
					default:
						LoadingState = MyLoading.MyLoadingState.Stop;
						break;
					}
					OnStateChangedUiEvent?.Invoke(this, value, state);
				}));
				if (HasOnStateChangedThread)
				{
					ModBase.RunInThread((Action)([SpecialName] () =>
					{
						OnStateChangedThreadEvent?.Invoke(this, value, state);
					}));
				}
			}
		}

		public MyLoading.MyLoadingState LoadingState
		{
			get
			{
				return _LoadingState;
			}
			set
			{
				if (_LoadingState != value)
				{
					MyLoading.MyLoadingState loadingState = _LoadingState;
					_LoadingState = value;
					LoadingStateChangedEvent?.Invoke(value, loadingState);
				}
			}
		}

		[field: CompilerGenerated]
		public System.Exception Error
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public virtual double Progress
		{
			get
			{
				return State switch
				{
					ModBase.LoadState.Waiting => 0.0, 
					ModBase.LoadState.Loading => (_Progress == -1.0) ? 0.02 : _Progress, 
					_ => 1.0, 
				};
			}
			set
			{
				if (_Progress != value)
				{
					double progress = _Progress;
					_Progress = value;
					ProgressChangedEvent?.Invoke(value, progress);
				}
			}
		}

		[field: CompilerGenerated]
		public double ProgressWeight
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public event OnStateChangedThreadEventHandler OnStateChangedThread
		{
			[CompilerGenerated]
			add
			{
				OnStateChangedThreadEventHandler onStateChangedThreadEventHandler = OnStateChangedThreadEvent;
				OnStateChangedThreadEventHandler onStateChangedThreadEventHandler2;
				do
				{
					onStateChangedThreadEventHandler2 = onStateChangedThreadEventHandler;
					OnStateChangedThreadEventHandler onStateChangedThreadEventHandler3 = (OnStateChangedThreadEventHandler)System.Delegate.Combine((System.Delegate)onStateChangedThreadEventHandler2, (System.Delegate)value);
					onStateChangedThreadEventHandler = Interlocked.CompareExchange<OnStateChangedThreadEventHandler>(ref OnStateChangedThreadEvent, onStateChangedThreadEventHandler3, onStateChangedThreadEventHandler2);
				}
				while (onStateChangedThreadEventHandler != onStateChangedThreadEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				OnStateChangedThreadEventHandler onStateChangedThreadEventHandler = OnStateChangedThreadEvent;
				OnStateChangedThreadEventHandler onStateChangedThreadEventHandler2;
				do
				{
					onStateChangedThreadEventHandler2 = onStateChangedThreadEventHandler;
					OnStateChangedThreadEventHandler onStateChangedThreadEventHandler3 = (OnStateChangedThreadEventHandler)System.Delegate.Remove((System.Delegate)onStateChangedThreadEventHandler2, (System.Delegate)value);
					onStateChangedThreadEventHandler = Interlocked.CompareExchange<OnStateChangedThreadEventHandler>(ref OnStateChangedThreadEvent, onStateChangedThreadEventHandler3, onStateChangedThreadEventHandler2);
				}
				while (onStateChangedThreadEventHandler != onStateChangedThreadEventHandler2);
			}
		}

		public event OnStateChangedUiEventHandler OnStateChangedUi
		{
			[CompilerGenerated]
			add
			{
				OnStateChangedUiEventHandler onStateChangedUiEventHandler = OnStateChangedUiEvent;
				OnStateChangedUiEventHandler onStateChangedUiEventHandler2;
				do
				{
					onStateChangedUiEventHandler2 = onStateChangedUiEventHandler;
					OnStateChangedUiEventHandler onStateChangedUiEventHandler3 = (OnStateChangedUiEventHandler)System.Delegate.Combine((System.Delegate)onStateChangedUiEventHandler2, (System.Delegate)value);
					onStateChangedUiEventHandler = Interlocked.CompareExchange<OnStateChangedUiEventHandler>(ref OnStateChangedUiEvent, onStateChangedUiEventHandler3, onStateChangedUiEventHandler2);
				}
				while (onStateChangedUiEventHandler != onStateChangedUiEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				OnStateChangedUiEventHandler onStateChangedUiEventHandler = OnStateChangedUiEvent;
				OnStateChangedUiEventHandler onStateChangedUiEventHandler2;
				do
				{
					onStateChangedUiEventHandler2 = onStateChangedUiEventHandler;
					OnStateChangedUiEventHandler onStateChangedUiEventHandler3 = (OnStateChangedUiEventHandler)System.Delegate.Remove((System.Delegate)onStateChangedUiEventHandler2, (System.Delegate)value);
					onStateChangedUiEventHandler = Interlocked.CompareExchange<OnStateChangedUiEventHandler>(ref OnStateChangedUiEvent, onStateChangedUiEventHandler3, onStateChangedUiEventHandler2);
				}
				while (onStateChangedUiEventHandler != onStateChangedUiEventHandler2);
			}
		}

		public event PreviewFinishEventHandler PreviewFinish
		{
			[CompilerGenerated]
			add
			{
				PreviewFinishEventHandler previewFinishEventHandler = PreviewFinishEvent;
				PreviewFinishEventHandler previewFinishEventHandler2;
				do
				{
					previewFinishEventHandler2 = previewFinishEventHandler;
					PreviewFinishEventHandler previewFinishEventHandler3 = (PreviewFinishEventHandler)System.Delegate.Combine((System.Delegate)previewFinishEventHandler2, (System.Delegate)value);
					previewFinishEventHandler = Interlocked.CompareExchange<PreviewFinishEventHandler>(ref PreviewFinishEvent, previewFinishEventHandler3, previewFinishEventHandler2);
				}
				while (previewFinishEventHandler != previewFinishEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				PreviewFinishEventHandler previewFinishEventHandler = PreviewFinishEvent;
				PreviewFinishEventHandler previewFinishEventHandler2;
				do
				{
					previewFinishEventHandler2 = previewFinishEventHandler;
					PreviewFinishEventHandler previewFinishEventHandler3 = (PreviewFinishEventHandler)System.Delegate.Remove((System.Delegate)previewFinishEventHandler2, (System.Delegate)value);
					previewFinishEventHandler = Interlocked.CompareExchange<PreviewFinishEventHandler>(ref PreviewFinishEvent, previewFinishEventHandler3, previewFinishEventHandler2);
				}
				while (previewFinishEventHandler != previewFinishEventHandler2);
			}
		}

		public event ILoadingTrigger.LoadingStateChangedEventHandler LoadingStateChanged
		{
			[CompilerGenerated]
			add
			{
				ILoadingTrigger.LoadingStateChangedEventHandler loadingStateChangedEventHandler = LoadingStateChangedEvent;
				ILoadingTrigger.LoadingStateChangedEventHandler loadingStateChangedEventHandler2;
				do
				{
					loadingStateChangedEventHandler2 = loadingStateChangedEventHandler;
					ILoadingTrigger.LoadingStateChangedEventHandler loadingStateChangedEventHandler3 = (ILoadingTrigger.LoadingStateChangedEventHandler)System.Delegate.Combine((System.Delegate)loadingStateChangedEventHandler2, (System.Delegate)value);
					loadingStateChangedEventHandler = Interlocked.CompareExchange<ILoadingTrigger.LoadingStateChangedEventHandler>(ref LoadingStateChangedEvent, loadingStateChangedEventHandler3, loadingStateChangedEventHandler2);
				}
				while (loadingStateChangedEventHandler != loadingStateChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ILoadingTrigger.LoadingStateChangedEventHandler loadingStateChangedEventHandler = LoadingStateChangedEvent;
				ILoadingTrigger.LoadingStateChangedEventHandler loadingStateChangedEventHandler2;
				do
				{
					loadingStateChangedEventHandler2 = loadingStateChangedEventHandler;
					ILoadingTrigger.LoadingStateChangedEventHandler loadingStateChangedEventHandler3 = (ILoadingTrigger.LoadingStateChangedEventHandler)System.Delegate.Remove((System.Delegate)loadingStateChangedEventHandler2, (System.Delegate)value);
					loadingStateChangedEventHandler = Interlocked.CompareExchange<ILoadingTrigger.LoadingStateChangedEventHandler>(ref LoadingStateChangedEvent, loadingStateChangedEventHandler3, loadingStateChangedEventHandler2);
				}
				while (loadingStateChangedEventHandler != loadingStateChangedEventHandler2);
			}
		}

		public event ILoadingTrigger.ProgressChangedEventHandler ProgressChanged
		{
			[CompilerGenerated]
			add
			{
				ILoadingTrigger.ProgressChangedEventHandler progressChangedEventHandler = ProgressChangedEvent;
				ILoadingTrigger.ProgressChangedEventHandler progressChangedEventHandler2;
				do
				{
					progressChangedEventHandler2 = progressChangedEventHandler;
					ILoadingTrigger.ProgressChangedEventHandler progressChangedEventHandler3 = (ILoadingTrigger.ProgressChangedEventHandler)System.Delegate.Combine((System.Delegate)progressChangedEventHandler2, (System.Delegate)value);
					progressChangedEventHandler = Interlocked.CompareExchange<ILoadingTrigger.ProgressChangedEventHandler>(ref ProgressChangedEvent, progressChangedEventHandler3, progressChangedEventHandler2);
				}
				while (progressChangedEventHandler != progressChangedEventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				ILoadingTrigger.ProgressChangedEventHandler progressChangedEventHandler = ProgressChangedEvent;
				ILoadingTrigger.ProgressChangedEventHandler progressChangedEventHandler2;
				do
				{
					progressChangedEventHandler2 = progressChangedEventHandler;
					ILoadingTrigger.ProgressChangedEventHandler progressChangedEventHandler3 = (ILoadingTrigger.ProgressChangedEventHandler)System.Delegate.Remove((System.Delegate)progressChangedEventHandler2, (System.Delegate)value);
					progressChangedEventHandler = Interlocked.CompareExchange<ILoadingTrigger.ProgressChangedEventHandler>(ref ProgressChangedEvent, progressChangedEventHandler3, progressChangedEventHandler2);
				}
				while (progressChangedEventHandler != progressChangedEventHandler2);
			}
		}

		protected LoaderBase()
		{
			IsLoader = true;
			Uuid = ModBase.GetUuid();
			Name = "未命名任务 " + Conversions.ToString(Uuid) + "#";
			LockState = RuntimeHelpers.GetObjectValue(new object());
			Parent = null;
			HasOnStateChangedThread = false;
			_State = ModBase.LoadState.Waiting;
			_LoadingState = MyLoading.MyLoadingState.Stop;
			Error = null;
			Block = true;
			Show = true;
			IsForceRestarting = false;
			_Progress = -1.0;
			ProgressWeight = 1.0;
		}

		public virtual void InitParent(LoaderBase Parent)
		{
			this.Parent = Parent;
		}

		protected void RaisePreviewFinish()
		{
			PreviewFinishEvent?.Invoke(this);
		}

		public abstract void Start(object Input = null, bool IsForceRestart = false);

		public abstract void Abort();

		public void WaitForExit(object Input = null, LoaderBase LoaderToSyncProgress = null, bool IsForceRestart = false)
		{
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			Start(RuntimeHelpers.GetObjectValue(Input), IsForceRestart);
			while (State == ModBase.LoadState.Loading)
			{
				if (LoaderToSyncProgress != null)
				{
					LoaderToSyncProgress.Progress = Progress;
				}
				Thread.Sleep(10);
			}
			if (State != ModBase.LoadState.Finished)
			{
				if (State == ModBase.LoadState.Aborted)
				{
					throw new ThreadInterruptedException("加载器执行已中断。");
				}
				if (Information.IsNothing((object)Error))
				{
					throw new System.Exception("未知错误！");
				}
				throw new System.Exception(Error.Message, Error);
			}
		}

		public void WaitForExitTime(int Timeout, object Input = null, string TimeoutMessage = "等待加载器执行超时。", object LoaderToSyncProgress = null, bool IsForceRestart = false)
		{
			//IL_0049: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			Start(RuntimeHelpers.GetObjectValue(Input), IsForceRestart);
			while (State == ModBase.LoadState.Loading)
			{
				if (LoaderToSyncProgress != null)
				{
					NewLateBinding.LateSet(LoaderToSyncProgress, (System.Type)null, "Progress", new object[] { Progress }, (string[])null, (System.Type[])null);
				}
				Thread.Sleep(10);
				Timeout = checked(Timeout - 10);
				if (Timeout < 0)
				{
					throw new TimeoutException(TimeoutMessage);
				}
			}
			if (State != ModBase.LoadState.Finished)
			{
				if (State == ModBase.LoadState.Aborted)
				{
					throw new ThreadInterruptedException("加载器执行已中断。");
				}
				if (Information.IsNothing((object)Error))
				{
					throw new System.Exception("未知错误！");
				}
				throw Error;
			}
		}

		public virtual bool Equals(object obj)
		{
			if (obj is LoaderBase loaderBase)
			{
				return Uuid == loaderBase.Uuid;
			}
			return false;
		}
	}

	public class LoaderTask<InputType, OutputType> : LoaderBase
	{
		protected internal ThreadPriority ThreadPriority;

		protected internal Action<LoaderTask<InputType, OutputType>> LoadDelegate;

		protected internal Func<object> InputDelegate;

		public int ReloadTimeout;

		public long LastFinishedTime;

		public Thread LastRunningThread;

		public InputType Input;

		public OutputType Output;

		public bool IsAborted => IsAbortedWithThread(Thread.CurrentThread);

		public bool IsAbortedWithThread(Thread Thread)
		{
			if (LastRunningThread != null && object.ReferenceEquals((object)Thread, (object)LastRunningThread))
			{
				return base.State == ModBase.LoadState.Aborted;
			}
			return true;
		}

		public InputType StartGetInput(InputType Input = default(InputType), Func<object> InputDelegate = null)
		{
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			if (InputDelegate == null)
			{
				InputDelegate = this.InputDelegate;
			}
			InputType val = default(InputType);
			if (Input == null)
			{
				goto IL_0076;
			}
			if (val != null)
			{
				InputType reference = Input;
				InputType val2 = default(InputType);
				if (val2 == null)
				{
				}
				if (((object)reference).Equals((object)val))
				{
					goto IL_0076;
				}
			}
			goto IL_008f;
			IL_0076:
			if (InputDelegate != null)
			{
				ModBase.RunInUiWait((Action)([SpecialName] () =>
				{
					Input = Conversions.ToGenericParameter<InputType>(InputDelegate.Invoke());
				}));
			}
			goto IL_008f;
			IL_008f:
			return Input;
		}

		public bool ShouldStart(ref object Input, bool IsForceRestart = false, bool IgnoreReloadTimeout = false)
		{
			try
			{
				Input = StartGetInput(Conversions.ToGenericParameter<InputType>(Input));
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "加载输入获取失败（" + Name + "）", ModBase.LogLevel.Hint);
				base.Error = ex2;
				object lockState = LockState;
				ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
				bool flag = false;
				try
				{
					Monitor.Enter(lockState, ref flag);
					base.State = ModBase.LoadState.Failed;
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(lockState);
					}
				}
				ProjectData.ClearProjectError();
			}
			if (IsForceRestart)
			{
				return true;
			}
			if (Input == null != (this.Input == null) || (Input != null && !Input.Equals((object)this.Input)))
			{
				return true;
			}
			if ((base.State == ModBase.LoadState.Loading || base.State == ModBase.LoadState.Finished) && (IgnoreReloadTimeout || ReloadTimeout == -1 || LastFinishedTime == 0L || checked(TimeUtils.GetTimeTick() - LastFinishedTime) < ReloadTimeout))
			{
				return false;
			}
			return true;
		}

		public override void Start(object Input = null, bool IsForceRestart = false)
		{
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Expected O, but got Unknown
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Expected O, but got Unknown
			if (!ShouldStart(ref Input, IsForceRestart))
			{
				return;
			}
			if (base.State == ModBase.LoadState.Loading)
			{
				TriggerThreadAbort();
			}
			this.Input = Conversions.ToGenericParameter<InputType>(Input);
			object lockState = LockState;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
			bool flag = false;
			try
			{
				Monitor.Enter(lockState, ref flag);
				base.State = ModBase.LoadState.Loading;
				Progress = -1.0;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(lockState);
				}
			}
			LastRunningThread = new Thread((ThreadStart)([SpecialName] () =>
			{
				//IL_01be: Unknown result type (might be due to invalid IL or missing references)
				//IL_01c4: Expected O, but got Unknown
				//IL_01c5: Expected O, but got Unknown
				try
				{
					IsForceRestarting = IsForceRestart;
					if (ModBase.ModeDebug)
					{
						ModBase.Log(string.Format("[Loader] 加载线程 {0} ({1}) 已{2}启动", (object)Name, (object)Thread.CurrentThread.ManagedThreadId, (object)(IsForceRestarting ? "强制" : "")));
					}
					((Action<LoaderTask<InputType, OutputType>>)(object)LoadDelegate).Invoke((LoaderTask<InputType, OutputType>)(object)this);
					if (IsAborted)
					{
						ModBase.Log($"[Loader] 加载线程 {Name} ({Thread.CurrentThread.ManagedThreadId}) 已中断但线程正常运行至结束，输出被弃用（最新线程：{((LastRunningThread == null) ? (-1) : LastRunningThread.ManagedThreadId)}）", ModBase.LogLevel.Developer);
					}
					else
					{
						if (ModBase.ModeDebug)
						{
							ModBase.Log($"[Loader] 加载线程 {Name} ({Thread.CurrentThread.ManagedThreadId}) 已完成");
						}
						RaisePreviewFinish();
						base.State = ModBase.LoadState.Finished;
						LastFinishedTime = TimeUtils.GetTimeTick();
					}
				}
				catch (ModBase.CancelledException ex)
				{
					ProjectData.SetProjectError((System.Exception)ex);
					ModBase.CancelledException ex2 = ex;
					if (ModBase.ModeDebug)
					{
						ModBase.Log(ex2, $"加载线程 {Name} ({Thread.CurrentThread.ManagedThreadId}) 已触发取消中断，已完成 {Math.Round(Progress * 100.0)}%");
					}
					if (!IsAborted)
					{
						base.State = ModBase.LoadState.Aborted;
					}
					ProjectData.ClearProjectError();
				}
				catch (ThreadInterruptedException val)
				{
					ProjectData.SetProjectError((System.Exception)val);
					ThreadInterruptedException ex3 = val;
					if (ModBase.ModeDebug)
					{
						ModBase.Log((System.Exception)(object)ex3, $"加载线程 {Name} ({Thread.CurrentThread.ManagedThreadId}) 已触发线程中断，已完成 {Math.Round(Progress * 100.0)}%");
					}
					if (!IsAborted)
					{
						base.State = ModBase.LoadState.Aborted;
					}
					ProjectData.ClearProjectError();
				}
				catch (System.Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					System.Exception ex5 = ex4;
					if (IsAborted)
					{
						ProjectData.ClearProjectError();
					}
					else
					{
						ModBase.Log(ex5, $"加载线程 {Name} ({Thread.CurrentThread.ManagedThreadId}) 出错，已完成 {Math.Round(Progress * 100.0)}%", ModBase.LogLevel.Developer);
						base.Error = ex5;
						base.State = ModBase.LoadState.Failed;
						ProjectData.ClearProjectError();
					}
				}
			}))
			{
				Name = Name,
				Priority = ThreadPriority
			};
			LastRunningThread.Start();
		}

		public override void Abort()
		{
			if (base.State != ModBase.LoadState.Loading)
			{
				return;
			}
			object lockState = LockState;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
			bool flag = false;
			try
			{
				Monitor.Enter(lockState, ref flag);
				base.State = ModBase.LoadState.Aborted;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(lockState);
				}
			}
			TriggerThreadAbort();
		}

		private void TriggerThreadAbort()
		{
			if (LastRunningThread != null)
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log($"[Loader] 加载线程 {Name} ({LastRunningThread.ManagedThreadId}) 已中断");
				}
				if (LastRunningThread.IsAlive)
				{
					LastRunningThread.Interrupt();
				}
				LastRunningThread = null;
			}
		}

		public LoaderTask()
		{
			ReloadTimeout = -1;
			LastFinishedTime = 0L;
			LastRunningThread = null;
			Input = default(InputType);
			Output = default(OutputType);
		}

		public LoaderTask(string Name, Action<LoaderTask<InputType, OutputType>> LoadDelegate, Func<InputType> InputDelegate = null, ThreadPriority Priority = ThreadPriority.Normal)
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			ReloadTimeout = -1;
			LastFinishedTime = 0L;
			LastRunningThread = null;
			Input = default(InputType);
			Output = default(OutputType);
			base.Name = Name;
			this.LoadDelegate = LoadDelegate;
			this.InputDelegate = (Func<object>)(object)InputDelegate;
			ThreadPriority = Priority;
		}
	}

	public class LoaderCombo<InputType> : LoaderBase
	{
		public List<LoaderBase> Loaders;

		public InputType Input;

		public override double Progress
		{
			get
			{
				//IL_003c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0041: Unknown result type (might be due to invalid IL or missing references)
				switch (base.State)
				{
				case ModBase.LoadState.Waiting:
					return 0.0;
				case ModBase.LoadState.Loading:
				{
					double num = 0.0;
					double num2 = 0.0;
					System.Collections.Generic.IEnumerator<LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<LoaderBase>);
					try
					{
						enumerator = Loaders.GetEnumerator();
						while (enumerator.MoveNext())
						{
							LoaderBase current = enumerator.Current;
							num += current.ProgressWeight;
							num2 += current.ProgressWeight * current.Progress;
						}
					}
					finally
					{
						((System.IDisposable)enumerator).Dispose();
					}
					if (num == 0.0)
					{
						return 0.0;
					}
					return num2 / num;
				}
				default:
					return 1.0;
				}
			}
			set
			{
				throw new System.Exception("多重加载器不支持设置进度");
			}
		}

		public LoaderCombo(string Name, System.Collections.Generic.IEnumerable<LoaderBase> Loaders)
		{
			this.Loaders = new List<LoaderBase>();
			this.Loaders.Clear();
			System.Collections.Generic.IEnumerator<LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<LoaderBase>);
			try
			{
				enumerator = Loaders.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					LoaderBase current = enumerator.Current;
					if (current != null)
					{
						this.Loaders.Add(current);
						current.OnStateChangedThread += SubTaskStateChanged;
						current.HasOnStateChangedThread = true;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			InitParent(null);
			base.Name = Name;
		}

		public override void InitParent(LoaderBase Parent)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			base.Parent = Parent;
			System.Collections.Generic.IEnumerator<LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<LoaderBase>);
			try
			{
				enumerator = Loaders.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.InitParent(this);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}

		public override void Start(object Input = null, bool IsForceRestart = false)
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			IsForceRestarting = IsForceRestart;
			object lockState = LockState;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
			bool flag = false;
			try
			{
				Monitor.Enter(lockState, ref flag);
				if (base.State == ModBase.LoadState.Loading)
				{
					return;
				}
				base.State = ModBase.LoadState.Loading;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(lockState);
				}
			}
			this.Input = Conversions.ToGenericParameter<InputType>(Input);
			if (IsForceRestart)
			{
				System.Collections.Generic.IEnumerator<LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<LoaderBase>);
				try
				{
					enumerator = Loaders.GetEnumerator();
					while (enumerator.MoveNext())
					{
						enumerator.Current.State = ModBase.LoadState.Waiting;
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
			}
			ModBase.RunInThread(new Action(Update));
		}

		public override void Abort()
		{
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			object lockState = LockState;
			ObjectFlowControl.CheckForSyncLockOnValueType(lockState);
			bool flag = false;
			try
			{
				Monitor.Enter(lockState, ref flag);
				if (base.State != ModBase.LoadState.Loading && base.State != 0)
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
			ModBase.RunInThread((Action)([SpecialName] [CompilerGenerated] () =>
			{
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				System.Collections.Generic.IEnumerator<LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<LoaderBase>);
				try
				{
					enumerator = Loaders.GetEnumerator();
					while (enumerator.MoveNext())
					{
						enumerator.Current.Abort();
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
			}));
		}

		private void SubTaskStateChanged(LoaderBase Loader, ModBase.LoadState NewState, ModBase.LoadState OldState)
		{
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			switch (NewState)
			{
			case ModBase.LoadState.Finished:
				Update();
				return;
			case ModBase.LoadState.Aborted:
				Abort();
				return;
			case ModBase.LoadState.Waiting:
			case ModBase.LoadState.Loading:
				return;
			}
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
				base.Error = new System.Exception(Loader.Name + "失败", Loader.Error);
				base.State = Loader.State;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(lockState);
				}
			}
			System.Collections.Generic.IEnumerator<LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<LoaderBase>);
			try
			{
				enumerator = Loaders.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Loader = enumerator.Current;
					Loader.Abort();
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
		}

		private void Update()
		{
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			if (base.State == ModBase.LoadState.Finished || base.State == ModBase.LoadState.Failed || base.State == ModBase.LoadState.Aborted)
			{
				return;
			}
			bool flag = true;
			bool flag2 = false;
			object obj = Input;
			System.Collections.Generic.IEnumerator<LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<LoaderBase>);
			try
			{
				enumerator = Loaders.GetEnumerator();
				while (enumerator.MoveNext())
				{
					LoaderBase current = enumerator.Current;
					switch (current.State)
					{
					case ModBase.LoadState.Finished:
						if (ModBase.StartsWithF(((MemberInfo)((object)current).GetType()).Name, "LoaderTask"))
						{
							object[] array2 = new object[2];
							array2[1] = ((obj != null && Enumerable.First<System.Type>((System.Collections.Generic.IEnumerable<System.Type>)((object)current).GetType().GenericTypeArguments) == obj.GetType()) ? obj : null);
							array2[0] = true;
							if (Conversions.ToBoolean(NewLateBinding.LateGet((object)current, (System.Type)null, "ShouldStart", array2, new string[] { "IgnoreReloadTimeout" }, (System.Type[])null, (bool[])null)))
							{
								ModBase.Log("[Loader] 由于输入条件变更，重启已完成的加载器 " + current.Name);
								break;
							}
							obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)current, (System.Type)null, "Output", new object[0], (string[])null, (System.Type[])null, (bool[])null));
						}
						if (current.Block && !flag)
						{
							flag2 = true;
						}
						continue;
					case ModBase.LoadState.Loading:
						if (ModBase.StartsWithF(((MemberInfo)((object)current).GetType()).Name, "LoaderTask"))
						{
							object[] array = new object[2];
							array[1] = ((obj != null && Enumerable.First<System.Type>((System.Collections.Generic.IEnumerable<System.Type>)((object)current).GetType().GenericTypeArguments) == obj.GetType()) ? obj : null);
							array[0] = true;
							if (Conversions.ToBoolean(NewLateBinding.LateGet((object)current, (System.Type)null, "ShouldStart", array, new string[] { "IgnoreReloadTimeout" }, (System.Type[])null, (bool[])null)))
							{
								ModBase.Log("[Loader] 由于输入条件变更，重启进行中的加载器 " + current.Name, ModBase.LogLevel.Developer);
								break;
							}
						}
						flag = false;
						flag2 = true;
						continue;
					}
					flag = false;
					if (flag2)
					{
						continue;
					}
					if (obj != null)
					{
						string name = ((MemberInfo)((object)current).GetType()).Name;
						if (ModBase.StartsWithF(name, "LoaderTask") || ModBase.StartsWithF(name, "LoaderCombo"))
						{
							current.Start(RuntimeHelpers.GetObjectValue((Enumerable.First<System.Type>((System.Collections.Generic.IEnumerable<System.Type>)((object)current).GetType().GenericTypeArguments) == obj.GetType()) ? obj : null), IsForceRestarting);
						}
						else
						{
							if (!ModBase.StartsWithF(name, "LoaderDownload"))
							{
								throw new System.Exception("未知的加载器类型（" + name + "）");
							}
							current.Start(RuntimeHelpers.GetObjectValue((obj is List<ModNet.NetFile>) ? obj : null), IsForceRestarting);
						}
					}
					else
					{
						current.Start(null, IsForceRestarting);
					}
					if (current.Block)
					{
						flag2 = true;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			if (flag)
			{
				RaisePreviewFinish();
				base.State = ModBase.LoadState.Finished;
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			}
		}

		public static void GetLoaderList(object Loader, ref List<LoaderBase> List, bool RequireShow = true)
		{
			foreach (object item in (System.Collections.IEnumerable)NewLateBinding.LateGet(Loader, (System.Type)null, "Loaders", new object[0], (string[])null, (System.Type[])null, (bool[])null))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				if (Conversions.ToBoolean((object)(Conversions.ToBoolean(NewLateBinding.LateGet(objectValue, (System.Type)null, "Show", new object[0], (string[])null, (System.Type[])null, (bool[])null)) || !RequireShow)))
				{
					List.Add((LoaderBase)objectValue);
				}
				if (ModBase.StartsWithF(((MemberInfo)objectValue.GetType()).Name, "LoaderCombo"))
				{
					GetLoaderList(RuntimeHelpers.GetObjectValue(objectValue), ref List);
				}
			}
		}

		public void GetLoaderList(ref List<LoaderBase> List, bool RequireShow = true)
		{
			GetLoaderList(this, ref List, RequireShow);
		}

		public List<LoaderBase> GetLoaderList(bool RequireShow = true)
		{
			List<LoaderBase> List = new List<LoaderBase>();
			GetLoaderList(ref List, RequireShow);
			return List;
		}
	}

	private struct LoaderFolderDictionaryEntry
	{
		public System.DateTime? LastCheckTime;

		public string FolderPath;

		public bool Equals(object obj)
		{
			if (!(obj is LoaderFolderDictionaryEntry loaderFolderDictionaryEntry))
			{
				return false;
			}
			return EqualityComparer<System.DateTime?>.Default.Equals(LastCheckTime, loaderFolderDictionaryEntry.LastCheckTime) && Operators.CompareString(FolderPath, loaderFolderDictionaryEntry.FolderPath, false) == 0;
		}
	}

	public enum LoaderFolderRunType
	{
		RunOnUpdated,
		ForceRun,
		UpdateOnly
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<LoaderBase, bool> _0024I8_002D0;

		public static Action _0024I8_002D1;

		public static Func<LoaderBase, double> _0024I9_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal bool _Lambda_0024__8_002D0(LoaderBase l)
		{
			return l.State != ModBase.LoadState.Loading;
		}

		[SpecialName]
		internal void _Lambda_0024__8_002D1()
		{
			ModMain.FrmMain.BtnExtraDownload.Progress = LoaderTaskbarProgress;
		}

		[SpecialName]
		internal double _Lambda_0024__9_002D0(LoaderBase l)
		{
			return l.Progress;
		}
	}

	public static ModBase.SafeList<LoaderBase> LoaderTaskbar = new ModBase.SafeList<LoaderBase>();

	public static double LoaderTaskbarProgress = 0.0;

	private static TaskbarItemProgressState LoaderTaskbarProgressLast = (TaskbarItemProgressState)0;

	private static Dictionary<LoaderBase, LoaderFolderDictionaryEntry> LoaderFolderDictionary = new Dictionary<LoaderBase, LoaderFolderDictionaryEntry>();

	public static void LoaderTaskbarAdd<T>(LoaderCombo<T> Loader)
	{
		if (ModMain.FrmSpeedLeft != null)
		{
			ModMain.FrmSpeedLeft.TaskRemove(Loader);
		}
		((List<LoaderBase>)LoaderTaskbar).Add((LoaderBase)Loader);
		ModBase.Log($"[Taskbar] {Loader.Name} 已加入任务列表");
	}

	public static void LoaderTaskbarProgressRefresh()
	{
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			double num = LoaderTaskbarProgressGet();
			System.Collections.Generic.IEnumerator<LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<LoaderBase>);
			try
			{
				enumerator = LoaderTaskbar.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					LoaderBase current = enumerator.Current;
					if (Enumerable.All<LoaderBase>((System.Collections.Generic.IEnumerable<LoaderBase>)LoaderTaskbar, (Func<LoaderBase, bool>)([SpecialName] (LoaderBase l) => l.State != ModBase.LoadState.Loading)) || current.State == ModBase.LoadState.Waiting || current.State == ModBase.LoadState.Aborted)
					{
						ModMain.FrmSpeedLeft?.TaskRefresh(current);
						((List<LoaderBase>)LoaderTaskbar).Remove(current);
						ModBase.Log($"[Taskbar] {current.Name} 已移出任务列表");
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			if (num <= 0.0 || num >= 1.0 || LoaderTaskbarProgress > num)
			{
				LoaderTaskbarProgress = num;
			}
			else
			{
				LoaderTaskbarProgress = LoaderTaskbarProgress * 0.9 + num * 0.1;
			}
			object action;
			if (_Closure_0024__._0024I8_002D1 != null)
			{
				action = _Closure_0024__._0024I8_002D1;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					ModMain.FrmMain.BtnExtraDownload.Progress = LoaderTaskbarProgress;
				};
				_Closure_0024__._0024I8_002D1 = val;
				action = (object)val;
			}
			ModBase.RunInUi((Action)action);
			TaskbarItemProgressState val2;
			if (!Enumerable.Any<LoaderBase>((System.Collections.Generic.IEnumerable<LoaderBase>)LoaderTaskbar) || LoaderTaskbarProgress == 1.0)
			{
				val2 = (TaskbarItemProgressState)0;
			}
			else if (LoaderTaskbarProgress < 0.015)
			{
				val2 = (TaskbarItemProgressState)1;
			}
			else
			{
				val2 = (TaskbarItemProgressState)2;
				((Window)ModMain.FrmMain).TaskbarItemInfo.ProgressValue = LoaderTaskbarProgress;
			}
			if (LoaderTaskbarProgressLast != val2)
			{
				LoaderTaskbarProgressLast = val2;
				((Window)ModMain.FrmMain).TaskbarItemInfo.ProgressState = val2;
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "刷新任务栏进度显示失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public static double LoaderTaskbarProgressGet()
	{
		double result;
		try
		{
			result = (Enumerable.Any<LoaderBase>((System.Collections.Generic.IEnumerable<LoaderBase>)LoaderTaskbar) ? ModBase.MathClamp(Enumerable.Average(Enumerable.Select<LoaderBase, double>((System.Collections.Generic.IEnumerable<LoaderBase>)LoaderTaskbar, (Func<LoaderBase, double>)([SpecialName] (LoaderBase l) => l.Progress))), 0.0, 1.0) : 1.0);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "获取任务栏进度出错", ModBase.LogLevel.Feedback);
			result = 0.5;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static bool LoaderFolderRun(LoaderBase Loader, string FolderPath, LoaderFolderRunType Type, int MaxDepth = 0, string ExtraPath = "", bool WaitForExit = false, object LoaderInput = null)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		LoaderFolderDictionaryEntry loaderFolderDictionaryEntry = default(LoaderFolderDictionaryEntry);
		loaderFolderDictionaryEntry.FolderPath = FolderPath + ExtraPath;
		loaderFolderDictionaryEntry.LastCheckTime = null;
		try
		{
			DirectoryInfo val = new DirectoryInfo(FolderPath + ExtraPath);
			loaderFolderDictionaryEntry.LastCheckTime = (val.Exists ? new System.DateTime?(GetActualLastWriteTimeUtc(val, MaxDepth)) : ((System.DateTime?)(object)null));
			if (Type == LoaderFolderRunType.RunOnUpdated && LoaderFolderDictionary.ContainsKey(Loader))
			{
				if (val.Exists)
				{
					if (LoaderFolderDictionary[Loader].LastCheckTime.HasValue && ((object)loaderFolderDictionaryEntry).Equals((object)LoaderFolderDictionary[Loader]))
					{
						return false;
					}
				}
				else if (!LoaderFolderDictionary[Loader].LastCheckTime.HasValue)
				{
					return false;
				}
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "文件夹加载器启动检测出错");
			ProjectData.ClearProjectError();
		}
		LoaderFolderDictionary[Loader] = loaderFolderDictionaryEntry;
		if (Type == LoaderFolderRunType.UpdateOnly)
		{
			return false;
		}
		if (WaitForExit)
		{
			Loader.WaitForExit(RuntimeHelpers.GetObjectValue(LoaderInput ?? FolderPath), null, IsForceRestart: true);
		}
		else
		{
			Loader.Start(RuntimeHelpers.GetObjectValue(LoaderInput ?? FolderPath), IsForceRestart: true);
		}
		return true;
	}

	private static System.DateTime GetActualLastWriteTimeUtc(DirectoryInfo FolderInfo, int MaxDepth)
	{
		System.DateTime dateTime = ((FileSystemInfo)FolderInfo).LastWriteTimeUtc;
		if (MaxDepth > 0)
		{
			System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
			try
			{
				enumerator = FolderInfo.EnumerateDirectories().GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					System.DateTime actualLastWriteTimeUtc = GetActualLastWriteTimeUtc(enumerator.Current, checked(MaxDepth - 1));
					if (System.DateTime.Compare(actualLastWriteTimeUtc, dateTime) > 0)
					{
						dateTime = actualLastWriteTimeUtc;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
		}
		return dateTime;
	}
}
