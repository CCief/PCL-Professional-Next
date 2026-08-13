using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace PCL;

public class MyLoadingStateSimulator : ILoadingTrigger
{
	[CompilerGenerated]
	private ILoadingTrigger.LoadingStateChangedEventHandler LoadingStateChangedEvent;

	[CompilerGenerated]
	private ILoadingTrigger.ProgressChangedEventHandler ProgressChangedEvent;

	[field: CompilerGenerated]
	private MyLoading.MyLoadingState _LoadingState
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
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
	public bool IsLoader
	{
		[CompilerGenerated]
		get;
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

	public MyLoadingStateSimulator()
	{
		_LoadingState = MyLoading.MyLoadingState.Unloaded;
		IsLoader = false;
	}
}
