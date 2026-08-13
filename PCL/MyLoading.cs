using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class MyLoading : Grid, IComponentConnector
{
	public delegate void IsErrorChangedEventHandler(object sender, bool isError);

	public delegate void StateChangedEventHandler(object sender, MyLoadingState newState, MyLoadingState oldState);

	public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

	public enum MyLoadingState
	{
		Unloaded = -1,
		Run,
		Stop,
		Error
	}

	[CompilerGenerated]
	private IsErrorChangedEventHandler IsErrorChangedEvent;

	[CompilerGenerated]
	private StateChangedEventHandler StateChangedEvent;

	[CompilerGenerated]
	private ClickEventHandler ClickEvent;

	private int Uuid;

	public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register("Foreground", typeof(SolidColorBrush), typeof(MyLoading));

	private string _Text;

	private string _TextError;

	[CompilerGenerated]
	[AccessedThroughProperty("_State")]
	private ILoadingTrigger __State;

	private bool IsLooping;

	private bool ErrorAnimationWaiting;

	private bool IsMouseDown;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	public bool AutoRun
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public SolidColorBrush Foreground
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			return (SolidColorBrush)base.GetValue(ForegroundProperty);
		}
		set
		{
			base.SetValue(ForegroundProperty, (object)value);
		}
	}

	[field: CompilerGenerated]
	private bool _ShowProgress
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public bool ShowProgress
	{
		get
		{
			return _ShowProgress;
		}
		set
		{
			if (_ShowProgress != value)
			{
				_ShowProgress = value;
				RefreshText();
			}
		}
	}

	public string Text
	{
		get
		{
			return _Text;
		}
		set
		{
			_Text = value;
			RefreshText();
		}
	}

	public string TextError
	{
		get
		{
			return _TextError;
		}
		set
		{
			_TextError = value;
			RefreshText();
		}
	}

	[field: CompilerGenerated]
	public bool TextErrorInherit
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	protected virtual ILoadingTrigger _State
	{
		[CompilerGenerated]
		get
		{
			return __State;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			ILoadingTrigger.ProgressChangedEventHandler obj = [SpecialName] [CompilerGenerated] (double a0, double a1) =>
			{
				RefreshText();
			};
			ILoadingTrigger.LoadingStateChangedEventHandler obj2 = [SpecialName] [CompilerGenerated] (MyLoadingState a0, MyLoadingState a1) =>
			{
				RefreshState();
			};
			ILoadingTrigger loadingTrigger = __State;
			if (loadingTrigger != null)
			{
				loadingTrigger.ProgressChanged -= obj;
				loadingTrigger.LoadingStateChanged -= obj2;
			}
			__State = value;
			loadingTrigger = __State;
			if (loadingTrigger != null)
			{
				loadingTrigger.ProgressChanged += obj;
				loadingTrigger.LoadingStateChanged += obj2;
			}
		}
	}

	public ILoadingTrigger State
	{
		get
		{
			InitState();
			return _State;
		}
		set
		{
			_State = value;
			RefreshState();
		}
	}

	[field: CompilerGenerated]
	private MyLoadingState _OuterState
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	private MyLoadingState OuterState
	{
		get
		{
			return _OuterState;
		}
		set
		{
			if (_OuterState != value)
			{
				MyLoadingState outerState = _OuterState;
				_OuterState = value;
				StateChangedEvent?.Invoke(this, value, outerState);
				if (outerState == MyLoadingState.Error != (value == MyLoadingState.Error))
				{
					IsErrorChangedEvent?.Invoke(this, value == MyLoadingState.Error);
				}
			}
		}
	}

	[field: CompilerGenerated]
	private MyLoadingState _InnerState
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	private MyLoadingState InnerState
	{
		get
		{
			return _InnerState;
		}
		set
		{
			if (_InnerState != value)
			{
				MyLoadingState innerState = _InnerState;
				_InnerState = value;
				AniLoop();
				if (innerState == MyLoadingState.Error != (value == MyLoadingState.Error))
				{
					ErrorAnimation(this, value == MyLoadingState.Error);
				}
			}
		}
	}

	[field: CompilerGenerated]
	public bool HasAnimation
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual MyLoading PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PathPickaxe")]
	internal virtual Path PathPickaxe
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PathLeft")]
	internal virtual Path PathLeft
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PathRight")]
	internal virtual Path PathRight
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PathError")]
	internal virtual Path PathError
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabText")]
	internal virtual TextBlock LabText
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public event IsErrorChangedEventHandler IsErrorChanged
	{
		[CompilerGenerated]
		add
		{
			IsErrorChangedEventHandler isErrorChangedEventHandler = IsErrorChangedEvent;
			IsErrorChangedEventHandler isErrorChangedEventHandler2;
			do
			{
				isErrorChangedEventHandler2 = isErrorChangedEventHandler;
				IsErrorChangedEventHandler isErrorChangedEventHandler3 = (IsErrorChangedEventHandler)System.Delegate.Combine((System.Delegate)isErrorChangedEventHandler2, (System.Delegate)value);
				isErrorChangedEventHandler = Interlocked.CompareExchange<IsErrorChangedEventHandler>(ref IsErrorChangedEvent, isErrorChangedEventHandler3, isErrorChangedEventHandler2);
			}
			while (isErrorChangedEventHandler != isErrorChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			IsErrorChangedEventHandler isErrorChangedEventHandler = IsErrorChangedEvent;
			IsErrorChangedEventHandler isErrorChangedEventHandler2;
			do
			{
				isErrorChangedEventHandler2 = isErrorChangedEventHandler;
				IsErrorChangedEventHandler isErrorChangedEventHandler3 = (IsErrorChangedEventHandler)System.Delegate.Remove((System.Delegate)isErrorChangedEventHandler2, (System.Delegate)value);
				isErrorChangedEventHandler = Interlocked.CompareExchange<IsErrorChangedEventHandler>(ref IsErrorChangedEvent, isErrorChangedEventHandler3, isErrorChangedEventHandler2);
			}
			while (isErrorChangedEventHandler != isErrorChangedEventHandler2);
		}
	}

	public event StateChangedEventHandler StateChanged
	{
		[CompilerGenerated]
		add
		{
			StateChangedEventHandler stateChangedEventHandler = StateChangedEvent;
			StateChangedEventHandler stateChangedEventHandler2;
			do
			{
				stateChangedEventHandler2 = stateChangedEventHandler;
				StateChangedEventHandler stateChangedEventHandler3 = (StateChangedEventHandler)System.Delegate.Combine((System.Delegate)stateChangedEventHandler2, (System.Delegate)value);
				stateChangedEventHandler = Interlocked.CompareExchange<StateChangedEventHandler>(ref StateChangedEvent, stateChangedEventHandler3, stateChangedEventHandler2);
			}
			while (stateChangedEventHandler != stateChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			StateChangedEventHandler stateChangedEventHandler = StateChangedEvent;
			StateChangedEventHandler stateChangedEventHandler2;
			do
			{
				stateChangedEventHandler2 = stateChangedEventHandler;
				StateChangedEventHandler stateChangedEventHandler3 = (StateChangedEventHandler)System.Delegate.Remove((System.Delegate)stateChangedEventHandler2, (System.Delegate)value);
				stateChangedEventHandler = Interlocked.CompareExchange<StateChangedEventHandler>(ref StateChangedEvent, stateChangedEventHandler3, stateChangedEventHandler2);
			}
			while (stateChangedEventHandler != stateChangedEventHandler2);
		}
	}

	public event ClickEventHandler Click
	{
		[CompilerGenerated]
		add
		{
			ClickEventHandler clickEventHandler = ClickEvent;
			ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				ClickEventHandler clickEventHandler3 = (ClickEventHandler)System.Delegate.Combine((System.Delegate)clickEventHandler2, (System.Delegate)value);
				clickEventHandler = Interlocked.CompareExchange<ClickEventHandler>(ref ClickEvent, clickEventHandler3, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ClickEventHandler clickEventHandler = ClickEvent;
			ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				ClickEventHandler clickEventHandler3 = (ClickEventHandler)System.Delegate.Remove((System.Delegate)clickEventHandler2, (System.Delegate)value);
				clickEventHandler = Interlocked.CompareExchange<ClickEventHandler>(ref ClickEvent, clickEventHandler3, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}
	}

	public MyLoading()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		IsErrorChanged += [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
		{
			RefreshText();
		};
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			RefreshText();
		});
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			InitState();
		});
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			RefreshState();
		});
		((FrameworkElement)this).Unloaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			RefreshState();
		});
		((UIElement)this).MouseLeftButtonUp += new MouseButtonEventHandler(Button_MouseUp);
		((UIElement)this).MouseLeftButtonDown += new MouseButtonEventHandler(Button_MouseDown);
		((UIElement)this).MouseLeave += new MouseEventHandler(Button_MouseLeave);
		((UIElement)this).MouseLeftButtonUp += new MouseButtonEventHandler(Button_MouseLeave);
		AutoRun = true;
		Uuid = ModBase.GetUuid();
		_ShowProgress = false;
		_Text = "加载中";
		_TextError = "加载失败";
		TextErrorInherit = true;
		_OuterState = MyLoadingState.Unloaded;
		_InnerState = MyLoadingState.Unloaded;
		HasAnimation = true;
		IsLooping = false;
		ErrorAnimationWaiting = false;
		IsMouseDown = false;
		InitializeComponent();
		base.SetResourceReference(ForegroundProperty, (object)"ColorBrush3");
	}

	private void RefreshText()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			if (InnerState == MyLoadingState.Error)
			{
				if (TextErrorInherit && State.IsLoader)
				{
					System.Exception ex = (System.Exception)NewLateBinding.LateGet((object)State, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null);
					if (ex == null)
					{
						LabText.Text = "未知错误";
					}
					else
					{
						while (ex.InnerException != null)
						{
							ex = ex.InnerException;
						}
						LabText.Text = Conversions.ToString(ModBase.StrTrim(ex.Message));
						if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "远程主机强迫关闭了", "远程方已关闭传输流", "未能解析此远程名称", "由于目标计算机积极拒绝", "操作已超时", "操作超时", "服务器超时", "连接超时" }, (Func<string, bool>)([SpecialName] [CompilerGenerated] (string s) => LabText.Text.Contains(s))))
						{
							LabText.Text = "网络环境不佳，请稍后重试，或使用 VPN 以改善网络环境";
						}
					}
				}
				else
				{
					LabText.Text = TextError;
				}
			}
			else if (ShowProgress && State.IsLoader)
			{
				LabText.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(Text + " - "), NewLateBinding.LateGet((object)null, typeof(Math), "Floor", new object[] { Operators.MultiplyObject(NewLateBinding.LateGet((object)State, (System.Type)null, "Progress", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)100) }, (string[])null, (System.Type[])null, (bool[])null)), (object)"%"));
			}
			else
			{
				LabText.Text = Text;
			}
		}));
	}

	private void InitState()
	{
		if (_State == null)
		{
			_State = new MyLoadingStateSimulator();
			if (AutoRun)
			{
				_State.LoadingState = MyLoadingState.Run;
			}
		}
	}

	private void RefreshState()
	{
		if (_State.LoadingState == MyLoadingState.Run && !((FrameworkElement)this).IsLoaded)
		{
			InnerState = MyLoadingState.Stop;
		}
		InnerState = _State.LoadingState;
		OuterState = _State.LoadingState;
		AniLoop();
	}

	private void AniLoop()
	{
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		if (HasAnimation && !IsLooping && InnerState == MyLoadingState.Run && !(ModAnimation.AniSpeed > 10.0) && ((FrameworkElement)this).IsLoaded)
		{
			IsLooping = true;
			ErrorAnimationWaiting = true;
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[11]
			{
				ModAnimation.AaRotateTransform(PathPickaxe, -20.0 - ((RotateTransform)((UIElement)PathPickaxe).RenderTransform).Angle, 350, 250, new ModAnimation.AniEaseInBack(ModAnimation.AniEasePower.Weak)),
				ModAnimation.AaRotateTransform(PathPickaxe, 50.0, 900, 0, new ModAnimation.AniEaseOutFluent(), After: true),
				ModAnimation.AaRotateTransform(PathPickaxe, 25.0, 900, 0, new ModAnimation.AniEaseOutElastic(ModAnimation.AniEasePower.Weak)),
				ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
				{
					//IL_003e: Unknown result type (might be due to invalid IL or missing references)
					//IL_0086: Unknown result type (might be due to invalid IL or missing references)
					((UIElement)PathLeft).Opacity = 1.0;
					((FrameworkElement)PathLeft).Margin = new Thickness(7.0, 41.0, 0.0, 0.0);
					((UIElement)PathRight).Opacity = 1.0;
					((FrameworkElement)PathRight).Margin = new Thickness(14.0, 41.0, 0.0, 0.0);
					ErrorAnimationWaiting = false;
				})),
				ModAnimation.AaOpacity(PathLeft, -1.0, 100, 50),
				ModAnimation.AaX(PathLeft, -5.0, 180, 0, new ModAnimation.AniEaseOutFluent()),
				ModAnimation.AaY(PathLeft, -6.0, 180, 0, new ModAnimation.AniEaseOutFluent()),
				ModAnimation.AaOpacity(PathRight, -1.0, 100, 50),
				ModAnimation.AaX(PathRight, 5.0, 180, 0, new ModAnimation.AniEaseOutFluent()),
				ModAnimation.AaY(PathRight, -6.0, 180, 0, new ModAnimation.AniEaseOutFluent()),
				ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
				{
					IsLooping = false;
					AniLoop();
				}), 0, After: true)
			}, "MyLoader Loop " + Conversions.ToString(Uuid) + "/" + Conversions.ToString(ModBase.GetUuid()));
			_ = ShowProgress;
		}
	}

	private void ErrorAnimation(object sender, bool isError)
	{
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		if (isError)
		{
			int num = (ErrorAnimationWaiting ? 400 : 0);
			ModAnimation.AniStart((System.Collections.IList)(object)checked(new ModAnimation.AniData[3]
			{
				ModAnimation.AaColor((FrameworkElement)(object)PanBack, ForegroundProperty, "ColorBrushRedLight", 300),
				ModAnimation.AaOpacity(PathError, 1.0 - ((UIElement)PathError).Opacity, 100, 300 + num),
				ModAnimation.AaScaleTransform(PathError, 1.0 - ((ScaleTransform)((UIElement)PathError).RenderTransform).ScaleX, 400, 300 + num, new ModAnimation.AniEaseOutBack())
			}), "MyLoader Error " + Conversions.ToString(Uuid));
		}
		else
		{
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
			{
				ModAnimation.AaOpacity(PathError, 0.0 - ((UIElement)PathError).Opacity, 100),
				ModAnimation.AaScaleTransform(PathError, 0.5 - ((ScaleTransform)((UIElement)PathError).RenderTransform).ScaleX, 200),
				ModAnimation.AaColor((FrameworkElement)(object)PanBack, ForegroundProperty, "ColorBrush3", 300)
			}, "MyLoader Error " + Conversions.ToString(Uuid));
		}
	}

	private void Button_MouseUp(object sender, MouseButtonEventArgs e)
	{
		ClickEvent?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
	}

	private void Button_MouseDown(object sender, MouseButtonEventArgs e)
	{
		IsMouseDown = true;
	}

	private void Button_MouseLeave(object sender, object e)
	{
		IsMouseDown = false;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	public void InitializeComponent()
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		if (!_contentLoaded)
		{
			_contentLoaded = true;
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/myloading.xaml", (UriKind)2);
			Application.LoadComponent((object)this, val);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	[EditorBrowsable(/*Could not decode attribute arguments.*/)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyLoading)target;
			break;
		case 2:
			PathPickaxe = (Path)target;
			break;
		case 3:
			PathLeft = (Path)target;
			break;
		case 4:
			PathRight = (Path)target;
			break;
		case 5:
			PathError = (Path)target;
			break;
		case 6:
			LabText = (TextBlock)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
