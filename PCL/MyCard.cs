using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.UI.Controls;

namespace PCL;

public class MyCard : Grid
{
	public delegate void PreviewSwapEventHandler(object sender, ModBase.RouteEventArgs e);

	public delegate void SwapEventHandler(object sender, ModBase.RouteEventArgs e);

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_28__ThemeChanged : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal bool _0024VB_0024Local_e;

		internal MyCard _0024VB_0024Me;

		internal SolidColorBrush _0024VB_0024ResumableLocal_bgBrush_00240;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num != 0)
				{
					_0024VB_0024ResumableLocal_bgBrush_00240 = (SolidColorBrush)Application.Current.Resources[(object)"ColorBrushSemiWhite"];
					_0024VB_0024Me.IsThemeChanging = true;
					ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaColor((FrameworkElement)(object)_0024VB_0024Me.MainBorder, Border.BackgroundProperty, new ModBase.MyColor(_0024VB_0024ResumableLocal_bgBrush_00240) - ((Border)_0024VB_0024Me.MainBorder).Background, 300) }, "MyCard Theme " + Conversions.ToString(_0024VB_0024Me.Uuid));
					val = System.Threading.Tasks.Task.Delay(300).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_28__ThemeChanged>(ref val, ref _this);
						return;
					}
				}
				else
				{
					num = (_0024State = -1);
					val = _0024A0;
					_0024A0 = default(TaskAwaiter);
				}
				val.GetResult();
				val = default(TaskAwaiter);
				((Border)_0024VB_0024Me.MainBorder).Background = (Brush)(object)_0024VB_0024ResumableLocal_bgBrush_00240;
				_0024VB_0024Me.IsThemeChanging = false;
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception exception = ex;
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

	private readonly Grid MainGrid;

	private readonly BlurBorder MainBorder;

	private bool IsThemeChanging;

	private TextBlock _MainTextBlock;

	private Path _MainSwap;

	public int Uuid;

	public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(MyCard), new PropertyMetadata((object)""));

	private bool IsLoad;

	private const double DropShadowIdleOpacity = 0.07;

	private const double DropShadowHoverOpacity = 0.4;

	private bool IsHeightAnimating;

	private double ActualUsedHeight;

	public object SwapControl;

	private bool _IsSwapped;

	private bool IsMouseDown;

	[CompilerGenerated]
	private PreviewSwapEventHandler PreviewSwapEvent;

	[CompilerGenerated]
	private SwapEventHandler SwapEvent;

	public const int SwapedHeight = 40;

	[field: CompilerGenerated]
	public MyDropShadow MainChrome
	{
		[CompilerGenerated]
		get;
	}

	public UIElement BorderChild
	{
		get
		{
			return ((Decorator)MainBorder).Child;
		}
		set
		{
			((Decorator)MainBorder).Child = value;
		}
	}

	public TextBlock MainTextBlock
	{
		get
		{
			Init();
			return _MainTextBlock;
		}
		set
		{
			_MainTextBlock = value;
		}
	}

	public Path MainSwap
	{
		get
		{
			Init();
			return _MainSwap;
		}
		set
		{
			_MainSwap = value;
		}
	}

	public InlineCollection Inlines => MainTextBlock.Inlines;

	public CornerRadius CornerRadius
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return MainChrome.CornerRadius;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			MainChrome.CornerRadius = value;
			((Border)MainBorder).CornerRadius = value;
		}
	}

	public string Title
	{
		get
		{
			return Conversions.ToString(base.GetValue(TitleProperty));
		}
		set
		{
			base.SetValue(TitleProperty, (object)value);
			if (_MainTextBlock != null)
			{
				MainTextBlock.Text = value;
			}
		}
	}

	[field: CompilerGenerated]
	public bool HasMouseAnimation
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public bool UseAnimation
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public bool CanSwap
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public Action<StackPanel> InstallMethod
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public bool IsSwapped
	{
		get
		{
			return _IsSwapped;
		}
		set
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			if (_IsSwapped == value)
			{
				return;
			}
			_IsSwapped = value;
			if (SwapControl != null)
			{
				if (!IsSwapped && SwapControl is StackPanel)
				{
					ref object swapControl = ref SwapControl;
					StackPanel Stack = (StackPanel)swapControl;
					StackInstall(ref Stack, InstallMethod);
					swapControl = Stack;
				}
				if (((FrameworkElement)this).IsLoaded)
				{
					NewLateBinding.LateSet(SwapControl, (System.Type)null, "Visibility", new object[] { (object)(Visibility)0 }, (string[])null, (System.Type[])null);
					TriggerForceResize();
					ModAnimation.AniStart(ModAnimation.AaRotateTransform(MainSwap, (double)((!_IsSwapped) ? 180 : (SwapLogoRight ? 270 : 0)) - ((RotateTransform)((UIElement)MainSwap).RenderTransform).Angle, 250, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.ExtraStrong)), "MyCard Swap " + Conversions.ToString(Uuid), RefreshTime: true);
				}
			}
		}
	}

	[Obsolete("请使用 IsSwapped 属性，IsSwaped 存在拼写错误")]
	public bool IsSwaped
	{
		get
		{
			return IsSwapped;
		}
		set
		{
			IsSwapped = value;
		}
	}

	[field: CompilerGenerated]
	public bool SwapLogoRight
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public event PreviewSwapEventHandler PreviewSwap
	{
		[CompilerGenerated]
		add
		{
			PreviewSwapEventHandler previewSwapEventHandler = PreviewSwapEvent;
			PreviewSwapEventHandler previewSwapEventHandler2;
			do
			{
				previewSwapEventHandler2 = previewSwapEventHandler;
				PreviewSwapEventHandler previewSwapEventHandler3 = (PreviewSwapEventHandler)System.Delegate.Combine((System.Delegate)previewSwapEventHandler2, (System.Delegate)value);
				previewSwapEventHandler = Interlocked.CompareExchange<PreviewSwapEventHandler>(ref PreviewSwapEvent, previewSwapEventHandler3, previewSwapEventHandler2);
			}
			while (previewSwapEventHandler != previewSwapEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			PreviewSwapEventHandler previewSwapEventHandler = PreviewSwapEvent;
			PreviewSwapEventHandler previewSwapEventHandler2;
			do
			{
				previewSwapEventHandler2 = previewSwapEventHandler;
				PreviewSwapEventHandler previewSwapEventHandler3 = (PreviewSwapEventHandler)System.Delegate.Remove((System.Delegate)previewSwapEventHandler2, (System.Delegate)value);
				previewSwapEventHandler = Interlocked.CompareExchange<PreviewSwapEventHandler>(ref PreviewSwapEvent, previewSwapEventHandler3, previewSwapEventHandler2);
			}
			while (previewSwapEventHandler != previewSwapEventHandler2);
		}
	}

	public event SwapEventHandler Swap
	{
		[CompilerGenerated]
		add
		{
			SwapEventHandler swapEventHandler = SwapEvent;
			SwapEventHandler swapEventHandler2;
			do
			{
				swapEventHandler2 = swapEventHandler;
				SwapEventHandler swapEventHandler3 = (SwapEventHandler)System.Delegate.Combine((System.Delegate)swapEventHandler2, (System.Delegate)value);
				swapEventHandler = Interlocked.CompareExchange<SwapEventHandler>(ref SwapEvent, swapEventHandler3, swapEventHandler2);
			}
			while (swapEventHandler != swapEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			SwapEventHandler swapEventHandler = SwapEvent;
			SwapEventHandler swapEventHandler2;
			do
			{
				swapEventHandler2 = swapEventHandler;
				SwapEventHandler swapEventHandler3 = (SwapEventHandler)System.Delegate.Remove((System.Delegate)swapEventHandler2, (System.Delegate)value);
				swapEventHandler = Interlocked.CompareExchange<SwapEventHandler>(ref SwapEvent, swapEventHandler3, swapEventHandler2);
			}
			while (swapEventHandler != swapEventHandler2);
		}
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_28__ThemeChanged))]
	private void _ThemeChanged(object sender, bool e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_28__ThemeChanged vB_0024StateMachine_28__ThemeChanged = default(VB_0024StateMachine_28__ThemeChanged);
		vB_0024StateMachine_28__ThemeChanged._0024VB_0024Me = this;
		vB_0024StateMachine_28__ThemeChanged._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_28__ThemeChanged._0024VB_0024Local_e = e;
		vB_0024StateMachine_28__ThemeChanged._0024State = -1;
		vB_0024StateMachine_28__ThemeChanged._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_28__ThemeChanged._0024Builder.Start<VB_0024StateMachine_28__ThemeChanged>(ref vB_0024StateMachine_28__ThemeChanged);
	}

	public MyCard()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
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
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Init();
		});
		((FrameworkElement)this).Unloaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Dispose();
		});
		((UIElement)this).MouseEnter += new MouseEventHandler(MyCard_MouseEnter);
		((UIElement)this).MouseLeave += new MouseEventHandler(MyCard_MouseLeave);
		((FrameworkElement)this).SizeChanged += new SizeChangedEventHandler(MySizeChanged);
		((UIElement)this).MouseLeftButtonDown += new MouseButtonEventHandler(MyCard_MouseLeftButtonDown);
		((UIElement)this).MouseLeftButtonUp += new MouseButtonEventHandler(MyCard_MouseLeftButtonUp);
		((UIElement)this).MouseLeave += new MouseEventHandler(MyCard_MouseLeave_Swap);
		IsThemeChanging = false;
		Uuid = ModBase.GetUuid();
		IsLoad = false;
		HasMouseAnimation = true;
		UseAnimation = true;
		IsHeightAnimating = false;
		CanSwap = false;
		_IsSwapped = false;
		SwapLogoRight = false;
		IsMouseDown = false;
		MyDropShadow myDropShadow = new MyDropShadow();
		((FrameworkElement)myDropShadow).Margin = new Thickness(-3.0, -3.0, -3.0, -3.0 - ModBase.GetWPFSize(1.0));
		myDropShadow.ShadowRadius = 3.0;
		((UIElement)myDropShadow).Opacity = 0.07;
		myDropShadow.CornerRadius = new CornerRadius(5.0);
		MainChrome = myDropShadow;
		((FrameworkElement)MainChrome).SetResourceReference(MyDropShadow.ColorProperty, (object)"ColorObject1");
		((Panel)this).Children.Insert(0, (UIElement)(object)MainChrome);
		BlurBorder blurBorder = new BlurBorder();
		((Border)blurBorder).CornerRadius = new CornerRadius(5.0);
		((UIElement)blurBorder).IsHitTestVisible = false;
		MainBorder = blurBorder;
		((Panel)this).Children.Insert(1, (UIElement)(object)MainBorder);
		MainGrid = new Grid();
		((Panel)this).Children.Add((UIElement)(object)MainGrid);
	}

	private void Init()
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Expected O, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected O, but got Unknown
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		if (IsLoad)
		{
			return;
		}
		IsLoad = true;
		ModSecret.ThemeChanged += _ThemeChanged;
		if (MainTextBlock == null)
		{
			MainTextBlock = new TextBlock
			{
				HorizontalAlignment = (HorizontalAlignment)0,
				VerticalAlignment = (VerticalAlignment)0,
				Margin = new Thickness(15.0, 12.0, 0.0, 0.0),
				FontWeight = FontWeights.Bold,
				FontSize = 13.0,
				IsHitTestVisible = false
			};
			((FrameworkElement)MainTextBlock).SetResourceReference(TextBlock.ForegroundProperty, (object)"ColorBrush1");
			((FrameworkElement)MainTextBlock).SetBinding(TextBlock.TextProperty, (BindingBase)new Binding("Title")
			{
				Source = this,
				Mode = (BindingMode)1
			});
			((Panel)MainGrid).Children.Add((UIElement)(object)MainTextBlock);
		}
		if (CanSwap || SwapControl != null)
		{
			if (SwapControl == null && ((Panel)this).Children.Count > 3)
			{
				SwapControl = ((Panel)this).Children[3];
			}
			MainSwap = new Path
			{
				HorizontalAlignment = (HorizontalAlignment)2,
				Stretch = (Stretch)2,
				Height = 6.0,
				Width = 10.0,
				VerticalAlignment = (VerticalAlignment)0,
				Margin = new Thickness(0.0, 17.0, 16.0, 0.0),
				Data = (Geometry)((TypeConverter)new GeometryConverter()).ConvertFromString("M2,4 l-2,2 10,10 10,-10 -2,-2 -8,8 -8,-8 z"),
				RenderTransform = (Transform)new RotateTransform(180.0),
				RenderTransformOrigin = new Point(0.5, 0.5)
			};
			((FrameworkElement)MainSwap).SetResourceReference(Shape.FillProperty, (object)"ColorBrush1");
			((Panel)MainGrid).Children.Add((UIElement)(object)MainSwap);
		}
		((Border)MainBorder).Background = (Brush)Application.Current.Resources[(object)"ColorBrushSemiWhite"];
		if (IsSwapped && SwapControl != null)
		{
			((UIElement)MainSwap).RenderTransform = (Transform)new RotateTransform((double)(SwapLogoRight ? 270 : 0));
			bool useAnimation = UseAnimation;
			UseAnimation = false;
			((FrameworkElement)this).Height = 40.0;
			ModAnimation.AniStop("MyCard Height " + Conversions.ToString(Uuid));
			IsHeightAnimating = false;
			ModBase.RunInUi((Action)([SpecialName] () =>
			{
				UseAnimation = useAnimation;
			}), ForceWaitUntilLoaded: true);
		}
	}

	private void Dispose()
	{
		if (((FrameworkElement)this).Parent == null)
		{
			ModSecret.ThemeChanged -= _ThemeChanged;
		}
	}

	public void StackInstall()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		ref object swapControl = ref SwapControl;
		StackPanel Stack = (StackPanel)swapControl;
		StackInstall(ref Stack, InstallMethod);
		swapControl = Stack;
		TriggerForceResize();
	}

	public static void StackInstall(ref StackPanel Stack, Action<StackPanel> InstallMethod)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		if (((FrameworkElement)Stack).Tag != null)
		{
			try
			{
				InstallMethod.Invoke(Stack);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "[MyCard] InstallMethod 调用失败");
				ProjectData.ClearProjectError();
			}
			((Panel)Stack).Children.Add((UIElement)new FrameworkElement
			{
				Height = 18.0
			});
			((FrameworkElement)Stack).Tag = null;
		}
	}

	private void MyCard_MouseEnter(object sender, MouseEventArgs e)
	{
		if (HasMouseAnimation)
		{
			List<ModAnimation.AniData> val = new List<ModAnimation.AniData>();
			if (!Information.IsNothing((object)MainTextBlock))
			{
				val.Add(ModAnimation.AaColor((FrameworkElement)(object)MainTextBlock, TextBlock.ForegroundProperty, "ColorBrush2", 90));
			}
			if (!Information.IsNothing((object)MainSwap))
			{
				val.Add(ModAnimation.AaColor((FrameworkElement)(object)MainSwap, Shape.FillProperty, "ColorBrush2", 90));
			}
			val.AddRange((System.Collections.Generic.IEnumerable<ModAnimation.AniData>)new ModAnimation.AniData[2]
			{
				ModAnimation.AaColor((FrameworkElement)(object)MainChrome, MyDropShadow.ColorProperty, "ColorObject4", 90),
				ModAnimation.AaOpacity(MainChrome, 0.4 - ((UIElement)MainChrome).Opacity, 90)
			});
			if (!IsThemeChanging)
			{
				ModAnimation.AniStart((System.Collections.IList)val, "MyCard Mouse " + Conversions.ToString(Uuid));
			}
		}
	}

	private void MyCard_MouseLeave(object sender, MouseEventArgs e)
	{
		if (HasMouseAnimation)
		{
			List<ModAnimation.AniData> val = new List<ModAnimation.AniData>();
			if (!Information.IsNothing((object)MainTextBlock))
			{
				val.Add(ModAnimation.AaColor((FrameworkElement)(object)MainTextBlock, TextBlock.ForegroundProperty, "ColorBrush1", 90));
			}
			if (!Information.IsNothing((object)MainSwap))
			{
				val.Add(ModAnimation.AaColor((FrameworkElement)(object)MainSwap, Shape.FillProperty, "ColorBrush1", 90));
			}
			val.AddRange((System.Collections.Generic.IEnumerable<ModAnimation.AniData>)new ModAnimation.AniData[2]
			{
				ModAnimation.AaColor((FrameworkElement)(object)MainChrome, MyDropShadow.ColorProperty, "ColorObject1", 90),
				ModAnimation.AaOpacity(MainChrome, 0.07 - ((UIElement)MainChrome).Opacity, 90)
			});
			if (!IsThemeChanging)
			{
				ModAnimation.AniStart((System.Collections.IList)val, "MyCard Mouse " + Conversions.ToString(Uuid));
			}
		}
	}

	private void MySizeChanged(object sender, SizeChangedEventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		if (UseAnimation)
		{
			Size val;
			double num;
			if (!IsSwapped)
			{
				val = e.NewSize;
				num = val.Height;
			}
			else
			{
				num = 40.0;
			}
			val = e.PreviousSize;
			double num2 = num - val.Height;
			val = e.PreviousSize;
			if (val.Height != 0.0 && !IsHeightAnimating && !(Math.Abs(num2) < 1.0) && ((FrameworkElement)this).ActualHeight != 0.0)
			{
				val = e.PreviousSize;
				StartHeightAnimation(num2, val.Height, IsLoadAnimation: false);
			}
		}
	}

	private void StartHeightAnimation(double Delta, double PreviousHeight, bool IsLoadAnimation)
	{
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		if (IsHeightAnimating || ModMain.FrmMain == null)
		{
			return;
		}
		List<ModAnimation.AniData> val = new List<ModAnimation.AniData>();
		double num = Math.Abs(Delta);
		checked
		{
			if (num <= 800.0)
			{
				val.Add(ModAnimation.AaHeight(this, Delta, 150, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.ExtraStrong)));
			}
			else
			{
				int num2 = default(int);
				int num3;
				int num4;
				if (Delta < 0.0 && num - (double)num2 > 500.0)
				{
					num2 = 200;
					num3 = 150;
					num4 = (int)Math.Round((num - (double)num2) / 0.1);
				}
				else if (Delta > 0.0 && num - (double)num2 > 3000.0)
				{
					num4 = 5000;
					num2 = (int)Math.Round(num - (double)num4 * 0.3);
					num3 = 400;
				}
				else
				{
					num2 = 150;
					num3 = 200;
					num4 = 4000;
				}
				val.Add(ModAnimation.AaHeight(this, (num - (double)num2) * (double)Math.Sign(Delta), (int)Math.Round((num - (double)num2) / (double)num4 * 1000.0)));
				val.Add(ModAnimation.AaHeight(this, num2 * Math.Sign(Delta), num3, 0, new ModAnimation.AniEaseOutFluentWithInitial(num4, (double)num3 / 1000.0, num2), After: true));
			}
			val.Add(ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
			{
				IsHeightAnimating = false;
				((FrameworkElement)this).Height = ActualUsedHeight;
				if (IsSwapped && SwapControl != null)
				{
					NewLateBinding.LateSet(SwapControl, (System.Type)null, "Visibility", new object[] { (object)(Visibility)2 }, (string[])null, (System.Type[])null);
				}
			}), 0, After: true));
			ModAnimation.AniStart((System.Collections.IList)val, "MyCard Height " + Conversions.ToString(Uuid));
			IsHeightAnimating = true;
			ActualUsedHeight = (IsSwapped ? 40.0 : ((FrameworkElement)this).Height);
			((FrameworkElement)this).Height = PreviousHeight;
		}
	}

	public void TriggerForceResize()
	{
		((FrameworkElement)this).Height = (IsSwapped ? 40.0 : (0.0 / 0.0));
		ModAnimation.AniStop("MyCard Height " + Conversions.ToString(Uuid));
		IsHeightAnimating = false;
	}

	private void MyCard_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		Point position = Mouse.GetPosition((IInputElement)(object)this);
		double y = position.Y;
		if (IsSwapped || (SwapControl != null && !(y > (double)(IsSwapped ? 40 : 34)) && (y != 0.0 || ((UIElement)this).IsMouseDirectlyOver)))
		{
			IsMouseDown = true;
		}
	}

	private void MyCard_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		if (!IsMouseDown)
		{
			return;
		}
		IsMouseDown = false;
		Point position = Mouse.GetPosition((IInputElement)(object)this);
		double y = position.Y;
		if (IsSwapped || (SwapControl != null && !(y > (double)(IsSwapped ? 40 : 34)) && (y != 0.0 || ((UIElement)this).IsMouseDirectlyOver)))
		{
			ModBase.RouteEventArgs routeEventArgs = new ModBase.RouteEventArgs(RaiseByMouse: true);
			PreviewSwapEvent?.Invoke(this, routeEventArgs);
			if (routeEventArgs.Handled)
			{
				IsMouseDown = false;
				return;
			}
			IsSwapped = !IsSwapped;
			ModBase.Log("[Control] " + (IsSwapped ? "折叠卡片" : "展开卡片") + ((Title == null) ? "" : ("：" + Title)));
			SwapEvent?.Invoke(this, routeEventArgs);
		}
	}

	private void MyCard_MouseLeave_Swap(object sender, MouseEventArgs e)
	{
		IsMouseDown = false;
	}
}
