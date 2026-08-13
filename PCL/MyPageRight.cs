using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class MyPageRight : AdornerDecorator
{
	public enum PageStates
	{
		Empty,
		LoaderWait,
		LoaderEnter,
		LoaderStayForce,
		LoaderStay,
		LoaderExit,
		ContentEnter,
		ContentStay,
		ContentExit,
		PageExit
	}

	public delegate void PageEnterEventHandler();

	public delegate void PageExitEventHandler();

	[CompilerGenerated]
	internal sealed class _Closure_0024__20_002D0
	{
		public Action<ModLoader.LoaderBase> _0024VB_0024Local_FinishedInvoke;

		public ModLoader.LoaderBase _0024VB_0024Local_RealLoader;

		public MyPageRight _0024VB_0024Me;

		public Action _0024I1;

		public _Closure_0024__20_002D0(_Closure_0024__20_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_FinishedInvoke = arg0._0024VB_0024Local_FinishedInvoke;
				_0024VB_0024Local_RealLoader = arg0._0024VB_0024Local_RealLoader;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R1(ModLoader.LoaderBase a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_004a: Expected O, but got Unknown
			while (_0024VB_0024Me.PageState == PageStates.PageExit || _0024VB_0024Me.PageState == PageStates.ContentExit)
			{
				Thread.Sleep(10);
			}
			Action action;
			if (_0024I1 != null)
			{
				action = _0024I1;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					_0024VB_0024Local_FinishedInvoke.Invoke(_0024VB_0024Local_RealLoader);
				};
				Action val2 = val;
				_0024I1 = val;
				action = val2;
			}
			ModBase.RunInUiWait(action);
			Thread.Sleep(20);
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			_0024VB_0024Local_FinishedInvoke.Invoke(_0024VB_0024Local_RealLoader);
		}

		[SpecialName]
		internal void _Lambda_0024__4()
		{
			_0024VB_0024Local_FinishedInvoke.Invoke(_0024VB_0024Local_RealLoader);
		}

		[SpecialName]
		internal void _Lambda_0024__R2(object a0, MouseButtonEventArgs a1)
		{
			_Lambda_0024__5();
		}

		[SpecialName]
		internal void _Lambda_0024__5()
		{
			if (_0024VB_0024Local_RealLoader.State == ModBase.LoadState.Failed)
			{
				_0024VB_0024Me.PageLoaderRestart();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__20_002D1
	{
		public ModLoader.LoaderBase _0024VB_0024Local_Loader;

		public ModBase.LoadState _0024VB_0024Local_NewState;

		public ModBase.LoadState _0024VB_0024Local_OldState;

		public MyPageRight _0024VB_0024Me;

		public _Closure_0024__20_002D1(_Closure_0024__20_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
				_0024VB_0024Local_NewState = arg0._0024VB_0024Local_NewState;
				_0024VB_0024Local_OldState = arg0._0024VB_0024Local_OldState;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			_0024VB_0024Me.PageLoaderState(_0024VB_0024Local_Loader, _0024VB_0024Local_NewState, _0024VB_0024Local_OldState);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__42_002D0
	{
		public System.Collections.Generic.IEnumerable<FrameworkElement> _0024VB_0024Local_RealElements;

		public MyPageRight _0024VB_0024Me;

		public _Closure_0024__42_002D0(_Closure_0024__42_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_RealElements = arg0._0024VB_0024Local_RealElements;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			System.Collections.Generic.IEnumerator<FrameworkElement> enumerator = default(System.Collections.Generic.IEnumerator<FrameworkElement>);
			try
			{
				enumerator = _0024VB_0024Local_RealElements.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					((UIElement)enumerator.Current).Visibility = (Visibility)2;
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			_0024VB_0024Me.PageOnExitAnimationFinished();
		}
	}

	public int PageUuid;

	private bool _panScrollNullWarned;

	private static object PanScrollProperty = DependencyProperty.Register("PanScroll", typeof(MyScrollViewer), typeof(MyPageRight));

	private PageStates _PageState;

	private ModLoader.LoaderBase PageLoader;

	private object PageLoaderInputInvoke;

	private MyLoading PageLoaderUi;

	private FrameworkElement PanLoader;

	private FrameworkElement PanContent;

	private FrameworkElement PanAlways;

	private bool PageLoaderAutoRun;

	[CompilerGenerated]
	private PageEnterEventHandler PageEnterEvent;

	[CompilerGenerated]
	private PageExitEventHandler PageExitEvent;

	public List<FrameworkElement> DisabledPageAnimControls;

	public MyScrollViewer PanScroll
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Expected O, but got Unknown
			object objectValue = RuntimeHelpers.GetObjectValue(base.GetValue((DependencyProperty)PanScrollProperty));
			if (objectValue == null && !_panScrollNullWarned)
			{
				_panScrollNullWarned = true;
				ModBase.Log($"[MyPageRight] 获取到 PanScroll(来自 {((FrameworkElement)this).Name}) 的值为 null", ModBase.LogLevel.Debug);
			}
			return (MyScrollViewer)objectValue;
		}
		set
		{
			object[] obj = new object[] { PanScrollProperty, value };
			object[] array = obj;
			bool[] obj2 = new bool[] { true, true };
			bool[] array2 = obj2;
			NewLateBinding.LateCall((object)this, (System.Type)null, "SetValue", obj, (string[])null, (System.Type[])null, obj2, true);
			if (array2[0])
			{
				PanScrollProperty = RuntimeHelpers.GetObjectValue(array[0]);
			}
			if (array2[1])
			{
				value = (MyScrollViewer)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(MyScrollViewer));
			}
		}
	}

	public PageStates PageState
	{
		get
		{
			return _PageState;
		}
		set
		{
			if (_PageState != value)
			{
				_PageState = value;
				if (ModBase.ModeDebug)
				{
					ModBase.Log("[UI] 页面状态切换为 " + ModBase.GetStringFromEnum(value));
				}
			}
		}
	}

	public event PageEnterEventHandler PageEnter
	{
		[CompilerGenerated]
		add
		{
			PageEnterEventHandler pageEnterEventHandler = PageEnterEvent;
			PageEnterEventHandler pageEnterEventHandler2;
			do
			{
				pageEnterEventHandler2 = pageEnterEventHandler;
				PageEnterEventHandler pageEnterEventHandler3 = (PageEnterEventHandler)System.Delegate.Combine((System.Delegate)pageEnterEventHandler2, (System.Delegate)value);
				pageEnterEventHandler = Interlocked.CompareExchange<PageEnterEventHandler>(ref PageEnterEvent, pageEnterEventHandler3, pageEnterEventHandler2);
			}
			while (pageEnterEventHandler != pageEnterEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PageEnterEventHandler pageEnterEventHandler = PageEnterEvent;
			PageEnterEventHandler pageEnterEventHandler2;
			do
			{
				pageEnterEventHandler2 = pageEnterEventHandler;
				PageEnterEventHandler pageEnterEventHandler3 = (PageEnterEventHandler)System.Delegate.Remove((System.Delegate)pageEnterEventHandler2, (System.Delegate)value);
				pageEnterEventHandler = Interlocked.CompareExchange<PageEnterEventHandler>(ref PageEnterEvent, pageEnterEventHandler3, pageEnterEventHandler2);
			}
			while (pageEnterEventHandler != pageEnterEventHandler2);
		}
	}

	public event PageExitEventHandler PageExit
	{
		[CompilerGenerated]
		add
		{
			PageExitEventHandler pageExitEventHandler = PageExitEvent;
			PageExitEventHandler pageExitEventHandler2;
			do
			{
				pageExitEventHandler2 = pageExitEventHandler;
				PageExitEventHandler pageExitEventHandler3 = (PageExitEventHandler)System.Delegate.Combine((System.Delegate)pageExitEventHandler2, (System.Delegate)value);
				pageExitEventHandler = Interlocked.CompareExchange<PageExitEventHandler>(ref PageExitEvent, pageExitEventHandler3, pageExitEventHandler2);
			}
			while (pageExitEventHandler != pageExitEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PageExitEventHandler pageExitEventHandler = PageExitEvent;
			PageExitEventHandler pageExitEventHandler2;
			do
			{
				pageExitEventHandler2 = pageExitEventHandler;
				PageExitEventHandler pageExitEventHandler3 = (PageExitEventHandler)System.Delegate.Remove((System.Delegate)pageExitEventHandler2, (System.Delegate)value);
				pageExitEventHandler = Interlocked.CompareExchange<PageExitEventHandler>(ref PageExitEvent, pageExitEventHandler3, pageExitEventHandler2);
			}
			while (pageExitEventHandler != pageExitEventHandler2);
		}
	}

	public MyPageRight()
	{
		PageUuid = ModBase.GetUuid();
		_panScrollNullWarned = false;
		_PageState = PageStates.Empty;
		DisabledPageAnimControls = new List<FrameworkElement>();
	}

	public void PageLoaderInit(MyLoading LoaderUi, FrameworkElement PanLoader, FrameworkElement PanContent, FrameworkElement PanAlways, ModLoader.LoaderBase RealLoader, Action<ModLoader.LoaderBase> FinishedInvoke = null, Func<object> InputInvoke = null, bool AutoRun = true)
	{
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		_Closure_0024__20_002D0 arg = default(_Closure_0024__20_002D0);
		_Closure_0024__20_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__20_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_RealLoader = RealLoader;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_FinishedInvoke = FinishedInvoke;
		this.PanLoader = PanLoader;
		this.PanContent = PanContent;
		this.PanAlways = PanAlways;
		PageLoader = CS_0024_003C_003E8__locals0._0024VB_0024Local_RealLoader;
		PageLoaderUi = LoaderUi;
		PageLoaderInputInvoke = InputInvoke;
		PageLoaderAutoRun = AutoRun;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_FinishedInvoke != null)
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Local_RealLoader.PreviewFinish += [SpecialName] (ModLoader.LoaderBase a0) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__0();
			};
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_RealLoader.OnStateChangedUi += [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase Loader, ModBase.LoadState NewState, ModBase.LoadState OldState) =>
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			_Closure_0024__20_002D1 arg2 = default(_Closure_0024__20_002D1);
			_Closure_0024__20_002D1 CS_0024_003C_003E8__locals1 = new _Closure_0024__20_002D1(null);
			CS_0024_003C_003E8__locals1._0024VB_0024Me = this;
			CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader = Loader;
			CS_0024_003C_003E8__locals1._0024VB_0024Local_NewState = NewState;
			CS_0024_003C_003E8__locals1._0024VB_0024Local_OldState = OldState;
			ModBase.RunInUi((Action)([SpecialName] () =>
			{
				CS_0024_003C_003E8__locals1._0024VB_0024Me.PageLoaderState(CS_0024_003C_003E8__locals1._0024VB_0024Local_Loader, CS_0024_003C_003E8__locals1._0024VB_0024Local_NewState, CS_0024_003C_003E8__locals1._0024VB_0024Local_OldState);
			}));
		};
		((UIElement)PanLoader).Visibility = (Visibility)2;
		((UIElement)PanContent).Visibility = (Visibility)2;
		if (PanAlways != null)
		{
			((UIElement)PanAlways).Visibility = (Visibility)2;
		}
		if (PageLoaderAutoRun)
		{
			if (ModBase.StartsWithF(((MemberInfo)((object)PageLoader).GetType()).Name, "LoaderTask"))
			{
				ModLoader.LoaderBase pageLoader = PageLoader;
				ModLoader.LoaderBase pageLoader2 = PageLoader;
				object[] array = new object[2];
				ref object pageLoaderInputInvoke = ref PageLoaderInputInvoke;
				array[1] = pageLoaderInputInvoke;
				object[] array2 = array;
				bool[] obj = new bool[] { false, true };
				bool[] array3 = obj;
				object obj2 = NewLateBinding.LateGet((object)pageLoader2, (System.Type)null, "StartGetInput", array, (string[])null, (System.Type[])null, obj);
				if (array3[1])
				{
					pageLoaderInputInvoke = RuntimeHelpers.GetObjectValue(array2[1]);
				}
				pageLoader.Start(RuntimeHelpers.GetObjectValue(obj2));
			}
			else
			{
				object obj3 = null;
				if (PageLoaderInputInvoke != null)
				{
					obj3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(PageLoaderInputInvoke, new object[0], (string[])null));
				}
				PageLoader.Start(RuntimeHelpers.GetObjectValue(obj3));
			}
		}
		if (PageLoader.State == ModBase.LoadState.Finished && CS_0024_003C_003E8__locals0._0024VB_0024Local_FinishedInvoke != null)
		{
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_FinishedInvoke.Invoke(CS_0024_003C_003E8__locals0._0024VB_0024Local_RealLoader);
			}));
		}
		PageLoaderUi.State = CS_0024_003C_003E8__locals0._0024VB_0024Local_RealLoader;
		PageLoaderUi.Click += [SpecialName] (object a0, MouseButtonEventArgs a1) =>
		{
			CS_0024_003C_003E8__locals0._Lambda_0024__5();
		};
	}

	public void PageLoaderRestart(object Input = null, bool IsForceRestart = true)
	{
		if (!PageLoaderAutoRun)
		{
			return;
		}
		if (ModBase.StartsWithF(((MemberInfo)((object)PageLoader).GetType()).Name, "LoaderTask"))
		{
			ModLoader.LoaderBase pageLoader = PageLoader;
			ModLoader.LoaderBase pageLoader2 = PageLoader;
			object[] obj = new object[] { Input, null };
			ref object pageLoaderInputInvoke = ref PageLoaderInputInvoke;
			obj[1] = pageLoaderInputInvoke;
			object[] array = obj;
			bool[] obj2 = new bool[] { true, true };
			bool[] array2 = obj2;
			object obj3 = NewLateBinding.LateGet((object)pageLoader2, (System.Type)null, "StartGetInput", obj, (string[])null, (System.Type[])null, obj2);
			if (array2[0])
			{
				Input = RuntimeHelpers.GetObjectValue(array[0]);
			}
			if (array2[1])
			{
				pageLoaderInputInvoke = RuntimeHelpers.GetObjectValue(array[1]);
			}
			pageLoader.Start(RuntimeHelpers.GetObjectValue(obj3), IsForceRestart);
		}
		else
		{
			if (Input == null && PageLoaderInputInvoke != null)
			{
				Input = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(PageLoaderInputInvoke, new object[0], (string[])null));
			}
			PageLoader.Start(RuntimeHelpers.GetObjectValue(Input), IsForceRestart);
		}
	}

	public void PageOnEnter()
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Expected O, but got Unknown
		if (ModBase.ModeDebug)
		{
			ModBase.Log("[UI] 已触发 PageOnEnter");
		}
		PageEnterEvent?.Invoke();
		switch (PageState)
		{
		case PageStates.Empty:
			if (PageLoader == null || PageLoader.State == ModBase.LoadState.Finished || PageLoader.State == ModBase.LoadState.Waiting || PageLoader.State == ModBase.LoadState.Aborted)
			{
				PageState = PageStates.ContentEnter;
				TriggerEnterAnimation(PanAlways, (FrameworkElement)(((object)PanContent) ?? ((object)((AdornerDecorator)this).Child)));
			}
			else if (PageLoader.State == ModBase.LoadState.Loading)
			{
				PageState = PageStates.LoaderWait;
				ModAnimation.AniStart(ModAnimation.AaCode(new ThreadStart(PageOnLoaderWaitFinished), 200), "PageRight PageChange " + Conversions.ToString(PageUuid));
			}
			else
			{
				PageState = PageStates.LoaderEnter;
				TriggerEnterAnimation(PanAlways, PanLoader);
			}
			break;
		case PageStates.ContentExit:
			if (PageLoader == null || PageLoader.State == ModBase.LoadState.Finished || PageLoader.State == ModBase.LoadState.Waiting || PageLoader.State == ModBase.LoadState.Aborted)
			{
				PageState = PageStates.ContentEnter;
				TriggerEnterAnimation((FrameworkElement)(((object)PanContent) ?? ((object)((AdornerDecorator)this).Child)));
			}
			else if (PageLoader.State == ModBase.LoadState.Loading)
			{
				PageState = PageStates.LoaderWait;
				ModAnimation.AniStart(ModAnimation.AaCode(new ThreadStart(PageOnLoaderWaitFinished), 200), "PageRight PageChange " + Conversions.ToString(PageUuid));
			}
			else
			{
				PageState = PageStates.LoaderEnter;
				TriggerEnterAnimation(PanLoader);
			}
			break;
		default:
			throw new System.Exception("在状态为 " + ModBase.GetStringFromEnum(PageState) + " 时触发了 PageOnEnter 事件。");
		case PageStates.ContentEnter:
			break;
		}
	}

	public void PageOnExit()
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		if (ModBase.ModeDebug)
		{
			ModBase.Log("[UI] 已触发 PageOnExit");
		}
		PageExitEvent?.Invoke();
		switch (PageState)
		{
		case PageStates.ContentEnter:
		case PageStates.ContentStay:
			PageState = PageStates.PageExit;
			TriggerExitAnimation(PanAlways, (FrameworkElement)(((object)PanContent) ?? ((object)((AdornerDecorator)this).Child)));
			break;
		case PageStates.LoaderEnter:
		case PageStates.LoaderStayForce:
		case PageStates.LoaderStay:
			PageState = PageStates.PageExit;
			TriggerExitAnimation(PanAlways, PanLoader);
			break;
		case PageStates.LoaderWait:
			PageState = PageStates.PageExit;
			TriggerExitAnimation(PanAlways);
			break;
		case PageStates.LoaderExit:
		case PageStates.ContentExit:
			PageState = PageStates.PageExit;
			if (PanAlways != null)
			{
				TriggerExitAnimation(PanAlways, (FrameworkElement)(((object)PanContent) ?? ((object)((AdornerDecorator)this).Child)));
			}
			break;
		case PageStates.Empty:
		case PageStates.PageExit:
			break;
		}
	}

	public void PageOnForceExit()
	{
		if (PageState == PageStates.Empty)
		{
			return;
		}
		if (ModBase.ModeDebug)
		{
			ModBase.Log("[UI] 已触发 PageOnForceExit");
		}
		PageState = PageStates.Empty;
		ModAnimation.AniStop("PageRight PageChange " + Conversions.ToString(PageUuid));
		if (PageLoader == null)
		{
			((AdornerDecorator)this).Child.Visibility = (Visibility)2;
			return;
		}
		((UIElement)PanContent).Visibility = (Visibility)2;
		((UIElement)PanLoader).Visibility = (Visibility)2;
		if (PanAlways != null)
		{
			((UIElement)PanAlways).Visibility = (Visibility)2;
		}
	}

	public void PageOnContentExit()
	{
		if (ModBase.ModeDebug)
		{
			ModBase.Log("[UI] 已触发 PageOnContentExit");
		}
		if (PageLoader != null && PageLoader.State == ModBase.LoadState.Loading)
		{
			throw new System.Exception("在调用 PageOnContentExit 时，加载器不能为 Loading 状态");
		}
		switch (PageState)
		{
		case PageStates.ContentEnter:
		case PageStates.ContentStay:
			PageState = PageStates.ContentExit;
			TriggerExitAnimation(PanContent);
			break;
		case PageStates.LoaderExit:
			PageState = PageStates.ContentExit;
			break;
		case PageStates.LoaderEnter:
		case PageStates.LoaderStayForce:
		case PageStates.LoaderStay:
			PageState = PageStates.ContentExit;
			TriggerExitAnimation(PanLoader);
			break;
		case PageStates.Empty:
		case PageStates.LoaderWait:
			PageOnEnter();
			break;
		}
	}

	private void PageOnEnterAnimationFinished()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		if (ModBase.ModeDebug)
		{
			ModBase.Log("[UI] 已触发 PageOnEnterAnimationFinished");
		}
		switch (PageState)
		{
		case PageStates.ContentEnter:
			PageState = PageStates.ContentStay;
			break;
		case PageStates.LoaderEnter:
			PageState = PageStates.LoaderStayForce;
			ModAnimation.AniStart(ModAnimation.AaCode(new ThreadStart(PageOnLoaderStayFinished), 400), "PageRight PageChange " + Conversions.ToString(PageUuid));
			break;
		default:
			throw new System.Exception("在状态为 " + ModBase.GetStringFromEnum(PageState) + " 时触发了 PageOnEnterAnimationFinished 事件。");
		}
	}

	private void PageOnExitAnimationFinished()
	{
		if (ModBase.ModeDebug)
		{
			ModBase.Log("[UI] 已触发 PageOnExitAnimationFinished");
		}
		switch (PageState)
		{
		case PageStates.PageExit:
			PageState = PageStates.Empty;
			break;
		case PageStates.ContentExit:
			PageOnEnter();
			break;
		case PageStates.LoaderExit:
			PageState = PageStates.ContentEnter;
			TriggerEnterAnimation(PanContent);
			break;
		default:
			throw new System.Exception("在状态为 " + ModBase.GetStringFromEnum(PageState) + " 时触发了 PageOnExitAnimationFinished 事件。");
		}
	}

	private void PageOnLoaderWaitFinished()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		if (ModBase.ModeDebug)
		{
			ModBase.Log("[UI] 已触发 PageOnLoaderWaitFinished");
		}
		PageStates pageState = PageState;
		if (pageState == PageStates.LoaderWait)
		{
			PageState = PageStates.LoaderEnter;
			if (PanAlways != null && (int)((UIElement)PanAlways).Visibility == 2)
			{
				TriggerEnterAnimation(PanAlways, PanLoader);
			}
			else
			{
				TriggerEnterAnimation(PanLoader);
			}
			return;
		}
		throw new System.Exception("在状态为 " + ModBase.GetStringFromEnum(PageState) + " 时触发了 PageOnLoaderWaitFinished 事件。");
	}

	private void PageOnLoaderStayFinished()
	{
		if (ModBase.ModeDebug)
		{
			ModBase.Log("[UI] 已触发 PageOnLoaderStayFinished");
		}
		PageStates pageState = PageState;
		if (pageState == PageStates.LoaderStayForce)
		{
			if (PageLoader.State == ModBase.LoadState.Finished)
			{
				PageState = PageStates.LoaderExit;
				TriggerExitAnimation(PanLoader);
			}
			else
			{
				PageState = PageStates.LoaderStay;
			}
			return;
		}
		throw new System.Exception("在状态为 " + ModBase.GetStringFromEnum(PageState) + " 时触发了 PageOnLoaderWaitFinished 事件。");
	}

	private void PageLoaderState(object sender, ModBase.LoadState NewState, ModBase.LoadState OldState)
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Invalid comparison between Unknown and I4
		switch (NewState)
		{
		case ModBase.LoadState.Loading:
		case ModBase.LoadState.Failed:
			if (OldState != ModBase.LoadState.Failed && OldState != ModBase.LoadState.Loading)
			{
				if (ModBase.ModeDebug)
				{
					ModBase.Log("[UI] 已触发 PageLoaderState (Start/Refresh)");
				}
				switch (PageState)
				{
				case PageStates.ContentEnter:
				case PageStates.ContentStay:
					PageState = PageStates.ContentExit;
					TriggerExitAnimation(PanContent);
					break;
				case PageStates.LoaderExit:
					PageState = PageStates.ContentExit;
					break;
				}
			}
			break;
		case ModBase.LoadState.Waiting:
		case ModBase.LoadState.Finished:
		case ModBase.LoadState.Aborted:
			if (OldState != ModBase.LoadState.Failed && OldState != ModBase.LoadState.Loading)
			{
				break;
			}
			if (ModBase.ModeDebug)
			{
				ModBase.Log("[UI] 已触发 PageLoaderState (Stop/Abort)");
			}
			switch (PageState)
			{
			case PageStates.LoaderWait:
				PageState = PageStates.ContentEnter;
				if (PanAlways != null && (int)((UIElement)PanAlways).Visibility == 2)
				{
					TriggerEnterAnimation(PanAlways, PanContent);
				}
				else
				{
					TriggerEnterAnimation(PanContent);
				}
				break;
			case PageStates.LoaderStay:
				PageState = PageStates.LoaderExit;
				TriggerExitAnimation(PanLoader);
				break;
			}
			break;
		}
	}

	public void TriggerEnterAnimation(params FrameworkElement[] Elements)
	{
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected O, but got Unknown
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		System.Collections.Generic.IEnumerable<FrameworkElement> enumerable = Enumerable.Where<FrameworkElement>((System.Collections.Generic.IEnumerable<FrameworkElement>)Elements, (Func<FrameworkElement, bool>)([SpecialName] (FrameworkElement e) => e != null));
		System.Collections.Generic.IEnumerator<FrameworkElement> enumerator = default(System.Collections.Generic.IEnumerator<FrameworkElement>);
		try
		{
			enumerator = enumerable.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				((UIElement)enumerator.Current).Visibility = (Visibility)0;
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		List<ModAnimation.AniData> val = new List<ModAnimation.AniData>();
		int num = 0;
		System.Collections.Generic.IEnumerator<FrameworkElement> enumerator2 = default(System.Collections.Generic.IEnumerator<FrameworkElement>);
		try
		{
			enumerator2 = enumerable.GetEnumerator();
			System.Collections.Generic.IEnumerator<FrameworkElement> enumerator3 = default(System.Collections.Generic.IEnumerator<FrameworkElement>);
			System.Collections.Generic.IEnumerator<FrameworkElement> enumerator4 = default(System.Collections.Generic.IEnumerator<FrameworkElement>);
			while (((System.Collections.IEnumerator)enumerator2).MoveNext())
			{
				FrameworkElement current = enumerator2.Current;
				try
				{
					enumerator3 = GetAllAnimControls(current, IgnoreInvisibility: true).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator3).MoveNext())
					{
						FrameworkElement current2 = enumerator3.Current;
						((UIElement)current2).IsHitTestVisible = true;
						if (((UIElement)current2).RenderTransform != null && ((UIElement)current2).RenderTransform is TranslateTransform)
						{
							((UIElement)current2).RenderTransform = null;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator3)?.Dispose();
				}
				try
				{
					enumerator4 = GetAllAnimControls(current).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator4).MoveNext())
					{
						FrameworkElement current3 = enumerator4.Current;
						if (current3 is MyExtraTextButton)
						{
							((MyExtraTextButton)(object)current3).Show = true;
							continue;
						}
						((UIElement)current3).Opacity = 0.0;
						((UIElement)current3).RenderTransform = (Transform)new TranslateTransform(0.0, -16.0);
						val.Add(ModAnimation.AaOpacity(current3, 1.0, 100, num, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)));
						val.Add(ModAnimation.AaTranslateY(current3, 5.0, 250, num, new ModAnimation.AniEaseOutFluent()));
						val.Add(ModAnimation.AaTranslateY(current3, 11.0, 350, num, new ModAnimation.AniEaseOutBack()));
						num = checked(num + 25);
					}
				}
				finally
				{
					((System.IDisposable)enumerator4)?.Dispose();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator2)?.Dispose();
		}
		MyScrollBar firstScrollViewer = GetFirstScrollViewer(enumerable);
		if (firstScrollViewer != null)
		{
			if (!(((UIElement)firstScrollViewer).RenderTransform is TranslateTransform))
			{
				((UIElement)firstScrollViewer).RenderTransform = (Transform)new TranslateTransform(10.0, 0.0);
			}
			val.Add(ModAnimation.AaTranslateX(firstScrollViewer, 0.0 - ((TranslateTransform)((UIElement)firstScrollViewer).RenderTransform).X, 350, 0, new ModAnimation.AniEaseOutFluent()));
		}
		val.Add(ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
		{
			PageOnEnterAnimationFinished();
		}), 0, After: true));
		ModAnimation.AniStart((System.Collections.IList)val, "PageRight PageChange " + Conversions.ToString(PageUuid));
	}

	public void TriggerExitAnimation(params FrameworkElement[] Elements)
	{
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		_Closure_0024__42_002D0 arg = default(_Closure_0024__42_002D0);
		_Closure_0024__42_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__42_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_RealElements = Enumerable.Where<FrameworkElement>((System.Collections.Generic.IEnumerable<FrameworkElement>)Elements, (Func<FrameworkElement, bool>)([SpecialName] (FrameworkElement e) => e != null));
		List<ModAnimation.AniData> val = new List<ModAnimation.AniData>();
		int num = 0;
		System.Collections.Generic.IEnumerator<FrameworkElement> enumerator = default(System.Collections.Generic.IEnumerator<FrameworkElement>);
		try
		{
			enumerator = CS_0024_003C_003E8__locals0._0024VB_0024Local_RealElements.GetEnumerator();
			System.Collections.Generic.IEnumerator<FrameworkElement> enumerator2 = default(System.Collections.Generic.IEnumerator<FrameworkElement>);
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				FrameworkElement current = enumerator.Current;
				try
				{
					enumerator2 = GetAllAnimControls(current).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator2).MoveNext())
					{
						FrameworkElement current2 = enumerator2.Current;
						if (current2 is MyExtraTextButton)
						{
							((MyExtraTextButton)(object)current2).Show = false;
							continue;
						}
						((UIElement)current2).IsHitTestVisible = false;
						val.Add(ModAnimation.AaOpacity(current2, -1.0, 70, num));
						val.Add(ModAnimation.AaTranslateY(current2, -6.0, 70, num));
						num = checked(num + 15);
					}
				}
				finally
				{
					((System.IDisposable)enumerator2)?.Dispose();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		MyScrollBar firstScrollViewer = GetFirstScrollViewer(CS_0024_003C_003E8__locals0._0024VB_0024Local_RealElements);
		if (firstScrollViewer != null)
		{
			if (!(((UIElement)firstScrollViewer).RenderTransform is TranslateTransform))
			{
				((UIElement)firstScrollViewer).RenderTransform = (Transform)new TranslateTransform();
			}
			val.Add(ModAnimation.AaTranslateX(firstScrollViewer, 10.0 - ((TranslateTransform)((UIElement)firstScrollViewer).RenderTransform).X, 90, 0, new ModAnimation.AniEaseInFluent()));
		}
		val.Add(ModAnimation.AaCode((ThreadStart)([SpecialName] () =>
		{
			System.Collections.Generic.IEnumerator<FrameworkElement> enumerator3 = default(System.Collections.Generic.IEnumerator<FrameworkElement>);
			try
			{
				enumerator3 = CS_0024_003C_003E8__locals0._0024VB_0024Local_RealElements.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator3).MoveNext())
				{
					((UIElement)enumerator3.Current).Visibility = (Visibility)2;
				}
			}
			finally
			{
				((System.IDisposable)enumerator3)?.Dispose();
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Me.PageOnExitAnimationFinished();
		}), 0, After: true));
		ModAnimation.AniStart((System.Collections.IList)val, "PageRight PageChange " + Conversions.ToString(PageUuid));
	}

	internal System.Collections.Generic.IEnumerable<FrameworkElement> GetAllAnimControls(FrameworkElement Element, bool IgnoreInvisibility = false)
	{
		List<FrameworkElement> AllControls = new List<FrameworkElement>();
		_GetAllAnimControls(Element, ref AllControls, IgnoreInvisibility);
		return Enumerable.Except<FrameworkElement>((System.Collections.Generic.IEnumerable<FrameworkElement>)AllControls, (System.Collections.Generic.IEnumerable<FrameworkElement>)DisabledPageAnimControls);
	}

	private void _GetAllAnimControls(FrameworkElement Element, ref List<FrameworkElement> AllControls, bool IgnoreInvisibility)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		if (!IgnoreInvisibility && (int)((UIElement)Element).Visibility == 2)
		{
			return;
		}
		if (Element is MyCard || Element is MyHint || Element is MyExtraTextButton || Element is TextBlock || Element is MyTextButton)
		{
			AllControls.Add(Element);
		}
		else if (Element is ContentControl)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(((ContentControl)Element).Content);
			if (objectValue != null && objectValue is FrameworkElement)
			{
				_GetAllAnimControls((FrameworkElement)objectValue, ref AllControls, IgnoreInvisibility);
			}
		}
		else
		{
			if (!(Element is Panel))
			{
				return;
			}
			foreach (object child in ((Panel)Element).Children)
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(child);
				if (objectValue2 is FrameworkElement)
				{
					_GetAllAnimControls((FrameworkElement)objectValue2, ref AllControls, IgnoreInvisibility);
				}
			}
		}
	}

	private MyScrollBar GetFirstScrollViewer(System.Collections.Generic.IEnumerable<FrameworkElement> Elements)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		MyScrollViewer myScrollViewer = null;
		System.Collections.Generic.IEnumerator<FrameworkElement> enumerator = default(System.Collections.Generic.IEnumerator<FrameworkElement>);
		try
		{
			enumerator = Elements.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				FrameworkElement current = enumerator.Current;
				if (current is MyScrollViewer)
				{
					myScrollViewer = (MyScrollViewer)(object)current;
					goto IL_008d;
				}
				foreach (object child in LogicalTreeHelper.GetChildren(current))
				{
					object objectValue = RuntimeHelpers.GetObjectValue(child);
					if (!(objectValue is MyScrollViewer))
					{
						continue;
					}
					myScrollViewer = (MyScrollViewer)objectValue;
					goto IL_008d;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		return null;
		IL_008d:
		if ((int)((ScrollViewer)myScrollViewer).ComputedVerticalScrollBarVisibility != 0)
		{
			return null;
		}
		return myScrollViewer.ScrollBar;
	}
}
