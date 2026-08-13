using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Utils;

namespace PCL;

[StandardModule]
public sealed class ModAnimation
{
	public class AniGroupEntry
	{
		public List<AniData> Data;

		public long StartTick;

		public int Uuid;

		public AniGroupEntry()
		{
			Uuid = ModBase.GetUuid();
		}
	}

	public struct AniData
	{
		public AniType TypeMain;

		public AniTypeSub TypeSub;

		public int TimeTotal;

		public int TimeFinished;

		public double TimePercent;

		public bool IsAfter;

		public AniEase Ease;

		public object Obj;

		public object Value;

		public object ValueLast;

		public string ToString()
		{
			return string.Concat(new string[9]
			{
				ModBase.GetStringFromEnum(TypeMain),
				" | ",
				Conversions.ToString(TimeFinished),
				"/",
				Conversions.ToString(TimeTotal),
				"(",
				Conversions.ToString(Math.Round(TimePercent * 100.0)),
				"%)",
				(Obj == null) ? "" : string.Concat(new string[5]
				{
					" | ",
					Obj.ToString(),
					"(",
					((MemberInfo)Obj.GetType()).Name,
					")"
				})
			});
		}
	}

	public enum AniType
	{
		Number,
		Color,
		Scale,
		TextAppear,
		Code,
		ScaleTransform,
		RotateTransform
	}

	public enum AniTypeSub
	{
		X,
		Y,
		Width,
		Height,
		Opacity,
		Value,
		Radius,
		BorderThickness,
		StrokeThickness,
		TranslateX,
		TranslateY,
		Double,
		DoubleParam,
		GridLengthWidth
	}

	public enum AniEasePower
	{
		Weak = 2,
		Middle,
		Strong,
		ExtraStrong
	}

	public abstract class AniEase
	{
		public abstract double GetValue(double t);

		public virtual double GetDelta(double t1, double t0)
		{
			return GetValue(t1) - GetValue(t0);
		}
	}

	public class AniEaseInout : AniEase
	{
		private readonly AniEase EaseIn;

		private readonly AniEase EaseOut;

		private readonly double EaseInPercent;

		public AniEaseInout(AniEase EaseIn, AniEase EaseOut, double EaseInPercent = 0.5)
		{
			this.EaseIn = EaseIn;
			this.EaseOut = EaseOut;
			this.EaseInPercent = EaseInPercent;
		}

		public override double GetValue(double t)
		{
			if (t < EaseInPercent)
			{
				return EaseInPercent * EaseIn.GetValue(t / EaseInPercent);
			}
			return (1.0 - EaseInPercent) * EaseOut.GetValue((t - EaseInPercent) / (1.0 - EaseInPercent)) + EaseInPercent;
		}
	}

	public class AniEaseLinear : AniEase
	{
		public override double GetValue(double t)
		{
			return ModBase.MathClamp(t, 0.0, 1.0);
		}

		public override double GetDelta(double t1, double t0)
		{
			return ModBase.MathClamp(t1, 0.0, 1.0) - ModBase.MathClamp(t0, 0.0, 1.0);
		}
	}

	public class AniEaseInFluent : AniEase
	{
		private readonly AniEasePower p;

		public AniEaseInFluent(AniEasePower Power = AniEasePower.Middle)
		{
			p = Power;
		}

		public override double GetValue(double t)
		{
			return Math.Pow(ModBase.MathClamp(t, 0.0, 1.0), (double)p);
		}
	}

	public class AniEaseOutFluent : AniEase
	{
		private readonly AniEasePower p;

		public AniEaseOutFluent(AniEasePower Power = AniEasePower.Middle)
		{
			p = Power;
		}

		public override double GetValue(double t)
		{
			return 1.0 - Math.Pow(ModBase.MathClamp(1.0 - t, 0.0, 1.0), (double)p);
		}
	}

	public class AniEaseInoutFluent : AniEase
	{
		private AniEaseInout Ease;

		public AniEaseInoutFluent(AniEasePower Power = AniEasePower.Middle, double Middle = 0.5)
		{
			Ease = new AniEaseInout(new AniEaseInFluent(Power), new AniEaseOutFluent(Power), Middle);
		}

		public override double GetValue(double t)
		{
			return Ease.GetValue(t);
		}
	}

	public class AniEaseOutFluentWithInitial : AniEase
	{
		private readonly double alpha;

		public AniEaseOutFluentWithInitial(double InitialPixelPerSecond, double TotalSecond, double TotalDistance)
		{
			double num = InitialPixelPerSecond * TotalSecond / TotalDistance;
			alpha = num - 1.0;
			if (alpha < 0.0)
			{
				alpha = 0.0;
			}
		}

		public override double GetValue(double percent)
		{
			double num = ModBase.MathClamp(percent, 0.0, 1.0);
			if (alpha == 0.0)
			{
				return num;
			}
			return (alpha + 1.0) * num / (1.0 + alpha * num);
		}
	}

	public class AniEaseInBack : AniEase
	{
		private readonly double p;

		public AniEaseInBack(AniEasePower Power = AniEasePower.Middle)
		{
			p = 3.0 - (double)Power * 0.5;
		}

		public override double GetValue(double t)
		{
			t = ModBase.MathClamp(t, 0.0, 1.0);
			return Math.Pow(t, p) * Math.Cos(4.71238898038469 * (1.0 - t));
		}
	}

	public class AniEaseOutBack : AniEase
	{
		private readonly double p;

		public AniEaseOutBack(AniEasePower Power = AniEasePower.Middle)
		{
			p = 3.0 - (double)Power * 0.5;
		}

		public override double GetValue(double t)
		{
			t = ModBase.MathClamp(t, 0.0, 1.0);
			return 1.0 - Math.Pow(1.0 - t, p) * Math.Cos(4.71238898038469 * t);
		}
	}

	public class AniEaseInCar : AniEase
	{
		private AniEaseInout Ease;

		public AniEaseInCar(double Middle = 0.7, AniEasePower Power = AniEasePower.Middle)
		{
			Ease = new AniEaseInout(new AniEaseInBack(Power), new AniEaseOutFluent(Power), Middle);
		}

		public override double GetValue(double t)
		{
			return Ease.GetValue(t);
		}
	}

	public class AniEaseOutCar : AniEase
	{
		private AniEaseInout Ease;

		public AniEaseOutCar(double Middle = 0.3, AniEasePower Power = AniEasePower.Middle)
		{
			Ease = new AniEaseInout(new AniEaseInFluent(Power), new AniEaseOutBack(Power), Middle);
		}

		public override double GetValue(double t)
		{
			return Ease.GetValue(t);
		}
	}

	public class AniEaseInElastic : AniEase
	{
		private readonly int p;

		public AniEaseInElastic(AniEasePower Power = AniEasePower.Middle)
		{
			p = (int)checked(Power + 4);
		}

		public override double GetValue(double t)
		{
			t = ModBase.MathClamp(t, 0.0, 1.0);
			return Math.Pow(t, (double)checked(p - 1) * 0.25) * Math.Cos(((double)p - 3.5) * Math.PI * Math.Pow(1.0 - t, 1.5));
		}
	}

	public class AniEaseOutElastic : AniEase
	{
		private readonly int p;

		public AniEaseOutElastic(AniEasePower Power = AniEasePower.Middle)
		{
			p = (int)checked(Power + 4);
		}

		public override double GetValue(double t)
		{
			t = 1.0 - ModBase.MathClamp(t, 0.0, 1.0);
			return 1.0 - Math.Pow(t, (double)checked(p - 1) * 0.25) * Math.Cos(((double)p - 3.5) * Math.PI * Math.Pow(1.0 - t, 1.5));
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__61_002D0
	{
		public double _0024VB_0024Local_MinFrameGap;

		public _Closure_0024__61_002D0(_Closure_0024__61_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_MinFrameGap = arg0._0024VB_0024Local_MinFrameGap;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Expected O, but got Unknown
			checked
			{
				try
				{
					ModBase.Log("[Animation] 动画线程开始");
					_Closure_0024__61_002D1 closure_0024__61_002D = default(_Closure_0024__61_002D1);
					while (true)
					{
						closure_0024__61_002D = new _Closure_0024__61_002D1(closure_0024__61_002D)
						{
							_0024VB_0024Local_DeltaTime = (long)Math.Round(ModBase.MathClamp(TimeUtils.GetTimeTick() - AniLastTick, 0.0, 100000.0))
						};
						if ((double)closure_0024__61_002D._0024VB_0024Local_DeltaTime < _0024VB_0024Local_MinFrameGap)
						{
							Thread.Sleep(1);
							continue;
						}
						AniLastTick = TimeUtils.GetTimeTick();
						if (ModBase.ModeDebug)
						{
							if (ModBase.MathClamp(AniLastTick - AniFPSTimer, 0.0, 100000.0) >= 500.0)
							{
								AniFPS = AniFPSCounter;
								AniFPSCounter = 0;
								AniFPSTimer = AniLastTick;
							}
							AniFPSCounter += 2;
						}
						ModBase.RunInUiWait(new Action(closure_0024__61_002D._Lambda_0024__1));
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "动画帧执行失败", ModBase.LogLevel.Critical);
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__61_002D1
	{
		public long _0024VB_0024Local_DeltaTime;

		public _Closure_0024__61_002D1(_Closure_0024__61_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_DeltaTime = arg0._0024VB_0024Local_DeltaTime;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			AniCount = 0;
			checked
			{
				AniTimer((int)Math.Round((double)_0024VB_0024Local_DeltaTime * AniSpeed));
				if (RandomUtils.NextInt(0, 64 * (ModBase.ModeDebug ? 5 : 30)) == 0 && ((AniFPS < 62 && AniFPS > 0) || AniCount > 4 || ModNet.NetManager.FileRemain != 0))
				{
					ModBase.Log(string.Concat(new string[9]
					{
						"[Report] FPS ",
						Conversions.ToString(AniFPS),
						", 动画 ",
						Conversions.ToString(AniCount),
						", 下载中 ",
						Conversions.ToString(ModNet.NetManager.FileRemain),
						"（",
						ModBase.GetString(ModNet.NetManager.Speed),
						"/s）"
					}));
				}
			}
		}
	}

	public static double AniSpeed = 1.0;

	public static Dictionary<string, AniGroupEntry> AniGroups = new Dictionary<string, AniGroupEntry>();

	private static long AniLastTick;

	public static bool AniRunning = false;

	private static int _AniControlEnabled = 0;

	private static readonly object AniControlEnabledLock = RuntimeHelpers.GetObjectValue(new object());

	private static int AniCount = 0;

	private static int AniFPSCounter = 0;

	private static long AniFPSTimer = 0L;

	public static int AniFPS = 0;

	public static int AniControlEnabled
	{
		get
		{
			return _AniControlEnabled;
		}
		set
		{
			object aniControlEnabledLock = AniControlEnabledLock;
			ObjectFlowControl.CheckForSyncLockOnValueType(aniControlEnabledLock);
			bool flag = false;
			try
			{
				Monitor.Enter(aniControlEnabledLock, ref flag);
				_AniControlEnabled = value;
			}
			finally
			{
				if (flag)
				{
					Monitor.Exit(aniControlEnabledLock);
				}
			}
		}
	}

	public static void AniDispose(MyCard Control, bool RemoveFromChildren, ParameterizedThreadStart CallBack = null)
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		if (((UIElement)Control).IsHitTestVisible)
		{
			((UIElement)Control).IsHitTestVisible = false;
			AniStart((System.Collections.IList)(object)new AniData[4]
			{
				AaScaleTransform(Control, -0.08, 200, 0, new AniEaseInFluent()),
				AaOpacity(Control, -1.0, 200, 0, new AniEaseOutFluent()),
				AaHeight(Control, 0.0 - ((FrameworkElement)Control).ActualHeight, 150, 100, new AniEaseOutFluent()),
				AaCode((ThreadStart)([SpecialName] () =>
				{
					if (RemoveFromChildren)
					{
						if (((FrameworkElement)Control).Parent == null)
						{
							return;
						}
						object[] array3;
						bool[] array4;
						NewLateBinding.LateCall(NewLateBinding.LateGet((object)((FrameworkElement)Control).Parent, (System.Type)null, "Children", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Remove", array3 = new object[] { Control }, (string[])null, (System.Type[])null, array4 = new bool[] { true }, true);
						if (array4[0])
						{
							Control = (MyCard)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array3[0]), typeof(MyCard));
						}
					}
					else
					{
						((UIElement)Control).Visibility = (Visibility)2;
					}
					if (CallBack != null)
					{
						CallBack.Invoke((object)Control);
					}
				}), 0, After: true)
			}, "MyCard Dispose " + Conversions.ToString(Control.Uuid));
			return;
		}
		if (RemoveFromChildren)
		{
			if (((FrameworkElement)Control).Parent == null)
			{
				return;
			}
			object[] array;
			bool[] array2;
			NewLateBinding.LateCall(NewLateBinding.LateGet((object)((FrameworkElement)Control).Parent, (System.Type)null, "Children", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Remove", array = new object[] { Control }, (string[])null, (System.Type[])null, array2 = new bool[] { true }, true);
			if (array2[0])
			{
				Control = (MyCard)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(MyCard));
			}
		}
		else
		{
			((UIElement)Control).Visibility = (Visibility)2;
		}
		if (CallBack != null)
		{
			CallBack.Invoke((object)Control);
		}
	}

	public static void AniDispose(MyHint Control, bool RemoveFromChildren, ParameterizedThreadStart CallBack = null)
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		if (!((UIElement)Control).IsHitTestVisible)
		{
			return;
		}
		((UIElement)Control).IsHitTestVisible = false;
		AniStart((System.Collections.IList)(object)new AniData[4]
		{
			AaScaleTransform(Control, -0.08, 200, 0, new AniEaseInFluent()),
			AaOpacity(Control, -1.0, 200, 0, new AniEaseOutFluent()),
			AaHeight(Control, 0.0 - ((FrameworkElement)Control).ActualHeight, 150, 100, new AniEaseOutFluent()),
			AaCode((ThreadStart)([SpecialName] () =>
			{
				if (RemoveFromChildren)
				{
					object obj = NewLateBinding.LateGet((object)((FrameworkElement)Control).Parent, (System.Type)null, "Children", new object[0], (string[])null, (System.Type[])null, (bool[])null);
					object[] obj2 = new object[] { Control };
					object[] array = obj2;
					bool[] obj3 = new bool[] { true };
					bool[] array2 = obj3;
					NewLateBinding.LateCall(obj, (System.Type)null, "Remove", obj2, (string[])null, (System.Type[])null, obj3, true);
					if (array2[0])
					{
						Control = (MyHint)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(MyHint));
					}
				}
				else
				{
					((UIElement)Control).Visibility = (Visibility)2;
				}
				if (CallBack != null)
				{
					CallBack.Invoke((object)Control);
				}
			}), 0, After: true)
		}, "MyCard Dispose " + Conversions.ToString(Control.Uuid));
	}

	public static void AniDispose(MyIconButton Control, bool RemoveFromChildren, ParameterizedThreadStart CallBack = null)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		if (!((UIElement)Control).IsHitTestVisible)
		{
			return;
		}
		((UIElement)Control).IsHitTestVisible = false;
		AniStart((System.Collections.IList)(object)new AniData[2]
		{
			AaScaleTransform(Control, -1.5, 200, 0, new AniEaseInFluent()),
			AaCode((ThreadStart)([SpecialName] () =>
			{
				if (RemoveFromChildren)
				{
					object obj = NewLateBinding.LateGet((object)((FrameworkElement)Control).Parent, (System.Type)null, "Children", new object[0], (string[])null, (System.Type[])null, (bool[])null);
					object[] obj2 = new object[] { Control };
					object[] array = obj2;
					bool[] obj3 = new bool[] { true };
					bool[] array2 = obj3;
					NewLateBinding.LateCall(obj, (System.Type)null, "Remove", obj2, (string[])null, (System.Type[])null, obj3, true);
					if (array2[0])
					{
						Control = (MyIconButton)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(MyIconButton));
					}
				}
				else
				{
					((UIElement)Control).Visibility = (Visibility)2;
				}
				if (CallBack != null)
				{
					CallBack.Invoke((object)Control);
				}
			}), 0, After: true)
		}, "MyIconButton Dispose " + Conversions.ToString(Control.Uuid));
	}

	public static AniData AaX(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.X;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaY(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.Y;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaWidth(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.Width;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaHeight(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.Height;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaOpacity(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.Opacity;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaValue(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.Value;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaRadius(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.Radius;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaBorderThickness(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.BorderThickness;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaStrokeThickness(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.StrokeThickness;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaGridLengthWidth(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.GridLengthWidth;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaDouble(object Obj, DependencyProperty Prop, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.Double;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = new object[] { Obj, Prop, "" };
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaDouble(ParameterizedThreadStart Lambda, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.DoubleParam;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = Lambda;
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaColor(FrameworkElement Obj, DependencyProperty Prop, ModBase.MyColor Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Color;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = new object[] { Obj, Prop, "" };
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		result.ValueLast = new ModBase.MyColor(0.0, 0.0, 0.0, 0.0);
		return result;
	}

	public static AniData AaColor(FrameworkElement Obj, DependencyProperty Prop, string Res, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Color;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = new object[] { Obj, Prop, Res };
		result.Value = new ModBase.MyColor(RuntimeHelpers.GetObjectValue(Application.Current.FindResource((object)Res))) - new ModBase.MyColor(RuntimeHelpers.GetObjectValue(((DependencyObject)Obj).GetValue(Prop)));
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		result.ValueLast = new ModBase.MyColor(0.0, 0.0, 0.0, 0.0);
		return result;
	}

	public static AniData AaScale(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false, bool Absolute = false)
	{
		ModBase.MyRect value = ((!Absolute) ? new ModBase.MyRect(Conversions.ToDouble(Operators.MultiplyObject(Operators.MultiplyObject((object)(-0.5), NewLateBinding.LateGet(Obj, (System.Type)null, "ActualWidth", new object[0], (string[])null, (System.Type[])null, (bool[])null)), (object)Value)), Conversions.ToDouble(Operators.MultiplyObject(Operators.MultiplyObject((object)(-0.5), NewLateBinding.LateGet(Obj, (System.Type)null, "ActualHeight", new object[0], (string[])null, (System.Type[])null, (bool[])null)), (object)Value)), Conversions.ToDouble(Operators.MultiplyObject(NewLateBinding.LateGet(Obj, (System.Type)null, "ActualWidth", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)Value)), Conversions.ToDouble(Operators.MultiplyObject(NewLateBinding.LateGet(Obj, (System.Type)null, "ActualHeight", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)Value))) : new ModBase.MyRect(-0.5 * Value, -0.5 * Value, Value, Value));
		AniData result = default(AniData);
		result.TypeMain = AniType.Scale;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaTextAppear(object Obj, bool Hide = false, bool TimePerText = true, int Time = 70, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.TextAppear;
		result.Ease = Ease ?? new AniEaseLinear();
		checked
		{
			result.TimeTotal = (TimePerText ? (Time * ((Obj is TextBlock) ? NewLateBinding.LateGet(Obj, (System.Type)null, "Text", new object[0], (string[])null, (System.Type[])null, (bool[])null) : NewLateBinding.LateGet(Obj, (System.Type)null, "Context", new object[0], (string[])null, (System.Type[])null, (bool[])null).ToString()).ToString().Length) : Time);
			result.Obj = RuntimeHelpers.GetObjectValue(Obj);
			result.Value = new object[2]
			{
				(Obj is TextBlock) ? NewLateBinding.LateGet(Obj, (System.Type)null, "Text", new object[0], (string[])null, (System.Type[])null, (bool[])null) : NewLateBinding.LateGet(Obj, (System.Type)null, "Context", new object[0], (string[])null, (System.Type[])null, (bool[])null).ToString(),
				Hide
			};
			result.IsAfter = After;
			result.TimeFinished = -Delay;
			return result;
		}
	}

	public static AniData AaCode(ThreadStart Code, int Delay = 0, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Code;
		result.TimeTotal = 1;
		result.Value = Code;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaScaleTransform(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.ScaleTransform;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaRotateTransform(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.RotateTransform;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaTranslateX(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.TranslateX;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static AniData AaTranslateY(object Obj, double Value, int Time = 400, int Delay = 0, AniEase Ease = null, bool After = false)
	{
		AniData result = default(AniData);
		result.TypeMain = AniType.Number;
		result.TypeSub = AniTypeSub.TranslateY;
		result.TimeTotal = Time;
		result.Ease = Ease ?? new AniEaseLinear();
		result.Obj = RuntimeHelpers.GetObjectValue(Obj);
		result.Value = Value;
		result.IsAfter = After;
		result.TimeFinished = checked(-Delay);
		return result;
	}

	public static List<AniData> AaStack(StackPanel Stack, int Time = 100, int Delay = 25)
	{
		List<AniData> val = new List<AniData>();
		int num = 0;
		foreach (object child in ((Panel)Stack).Children)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(child);
			NewLateBinding.LateSet(objectValue, (System.Type)null, "Opacity", new object[] { 0 }, (string[])null, (System.Type[])null);
			val.Add(AaOpacity(RuntimeHelpers.GetObjectValue(objectValue), 1.0, Time, num));
			num = checked(num + Delay);
		}
		return val;
	}

	public static void AniStart(System.Collections.IList AniGroup, string Name = "", bool RefreshTime = false)
	{
		if (RefreshTime)
		{
			AniLastTick = TimeUtils.GetTimeTick();
		}
		AniGroupEntry aniGroupEntry = new AniGroupEntry
		{
			Data = ModBase.GetFullList<AniData>(AniGroup),
			StartTick = TimeUtils.GetTimeTick()
		};
		if (Operators.CompareString(Name, "", false) == 0)
		{
			Name = Conversions.ToString(aniGroupEntry.Uuid);
		}
		else
		{
			AniStop(Name);
		}
		AniGroups.Add(Name, aniGroupEntry);
	}

	public static void AniStart(AniData AniGroup, string Name = "", bool RefreshTime = false)
	{
		List<AniData> obj = new List<AniData>();
		obj.Add(AniGroup);
		AniStart((System.Collections.IList)obj, Name, RefreshTime);
	}

	public static void AniStop(string Name)
	{
		AniGroups.Remove(Name);
	}

	public static bool AniIsRun(string Name)
	{
		return AniGroups.ContainsKey(Name);
	}

	public static void AniStart()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		_Closure_0024__61_002D0 arg = default(_Closure_0024__61_002D0);
		_Closure_0024__61_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__61_002D0(null);
		AniLastTick = TimeUtils.GetTimeTick();
		AniFPSTimer = AniLastTick;
		AniRunning = true;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_MinFrameGap = 1000.0 / ((ModBase.Val(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("UiAniFPS"))) + 1.0) * 2.0);
		ModBase.RunInNewThread((Action)checked([SpecialName] () =>
		{
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Expected O, but got Unknown
			try
			{
				ModBase.Log("[Animation] 动画线程开始");
				_Closure_0024__61_002D1 closure_0024__61_002D = default(_Closure_0024__61_002D1);
				while (true)
				{
					closure_0024__61_002D = new _Closure_0024__61_002D1(closure_0024__61_002D);
					closure_0024__61_002D._0024VB_0024Local_DeltaTime = (long)Math.Round(ModBase.MathClamp(TimeUtils.GetTimeTick() - AniLastTick, 0.0, 100000.0));
					if ((double)closure_0024__61_002D._0024VB_0024Local_DeltaTime < CS_0024_003C_003E8__locals0._0024VB_0024Local_MinFrameGap)
					{
						Thread.Sleep(1);
					}
					else
					{
						AniLastTick = TimeUtils.GetTimeTick();
						if (ModBase.ModeDebug)
						{
							if (ModBase.MathClamp(AniLastTick - AniFPSTimer, 0.0, 100000.0) >= 500.0)
							{
								AniFPS = AniFPSCounter;
								AniFPSCounter = 0;
								AniFPSTimer = AniLastTick;
							}
							AniFPSCounter += 2;
						}
						ModBase.RunInUiWait(new Action(closure_0024__61_002D._Lambda_0024__1));
					}
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "动画帧执行失败", ModBase.LogLevel.Critical);
				ProjectData.ClearProjectError();
			}
		}), "Animation", (ThreadPriority)3);
	}

	public static void AniTimer(int DeltaTick)
	{
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				if ((double)DeltaTick / AniSpeed > 200.0)
				{
					ModBase.Log("[Animation] 两个动画帧间隔 " + Conversions.ToString(DeltaTick) + " ms", ModBase.LogLevel.Developer);
				}
				int num = -1;
				while (num + 1 < AniGroups.Count)
				{
					num++;
					AniGroupEntry aniGroupEntry = Enumerable.ElementAtOrDefault<AniGroupEntry>((System.Collections.Generic.IEnumerable<AniGroupEntry>)AniGroups.Values, num);
					if (aniGroupEntry.StartTick > AniLastTick)
					{
						continue;
					}
					bool flag = true;
					int num2 = 0;
					while (num2 < aniGroupEntry.Data.Count)
					{
						AniData aniData = aniGroupEntry.Data[num2];
						if (!aniData.IsAfter)
						{
							flag = false;
							aniData.TimeFinished += DeltaTick;
							if (aniData.TimeFinished > 0)
							{
								aniData = AniRun(aniData);
								AniCount++;
							}
							if (aniData.TimeFinished >= aniData.TimeTotal)
							{
								if (Conversions.ToBoolean((object)(aniData.TypeMain == AniType.Color && Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(aniData.Obj, new object[] { 2 }, (string[])null), (object)"", false))))))
								{
									object obj = NewLateBinding.LateIndexGet(aniData.Obj, new object[] { 0 }, (string[])null);
									object[] array = new object[2];
									object obj2 = aniData.Obj;
									object[] array2 = new object[1];
									object obj3 = (array2[0] = 1);
									array[0] = NewLateBinding.LateIndexGet(obj2, array2, (string[])null);
									object obj4 = aniData.Obj;
									object[] array3 = new object[1];
									object obj5 = (array3[0] = 2);
									array[1] = NewLateBinding.LateIndexGet(obj4, array3, (string[])null);
									object[] array4 = array;
									bool[] obj6 = new bool[] { true, true };
									bool[] array5 = obj6;
									NewLateBinding.LateCall(obj, (System.Type)null, "SetResourceReference", array, (string[])null, (System.Type[])null, obj6, true);
									if (array5[0])
									{
										NewLateBinding.LateIndexSetComplex(obj2, new object[2]
										{
											obj3,
											array4[0]
										}, (string[])null, true, false);
									}
									if (array5[1])
									{
										NewLateBinding.LateIndexSetComplex(obj4, new object[2]
										{
											obj5,
											array4[1]
										}, (string[])null, true, false);
									}
								}
								aniGroupEntry.Data.RemoveAt(num2);
							}
							else
							{
								aniGroupEntry.Data[num2] = aniData;
								num2++;
							}
						}
						else
						{
							if (!flag)
							{
								break;
							}
							flag = false;
							aniData.IsAfter = false;
							aniGroupEntry.Data[num2] = aniData;
						}
					}
					if (Enumerable.Any<AniData>((System.Collections.Generic.IEnumerable<AniData>)aniGroupEntry.Data))
					{
						continue;
					}
					int num3 = AniGroups.Count - 1;
					for (int i = 0; i <= num3; i++)
					{
						if (Enumerable.ElementAt<KeyValuePair<string, AniGroupEntry>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, AniGroupEntry>>)AniGroups, i).Value.Uuid == aniGroupEntry.Uuid)
						{
							AniGroups.Remove(Enumerable.ElementAt<KeyValuePair<string, AniGroupEntry>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, AniGroupEntry>>)AniGroups, i).Key);
							break;
						}
					}
					num--;
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "动画刻执行失败", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static AniData AniRun(AniData Ani)
	{
		//IL_06f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fe: Expected O, but got Unknown
		//IL_0719: Unknown result type (might be due to invalid IL or missing references)
		//IL_0720: Expected O, but got Unknown
		//IL_07a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ab: Expected O, but got Unknown
		//IL_07d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0811: Unknown result type (might be due to invalid IL or missing references)
		//IL_0816: Unknown result type (might be due to invalid IL or missing references)
		//IL_0851: Unknown result type (might be due to invalid IL or missing references)
		//IL_0856: Unknown result type (might be due to invalid IL or missing references)
		//IL_0891: Unknown result type (might be due to invalid IL or missing references)
		//IL_0896: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb3: Expected O, but got Unknown
		//IL_0ca9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb0: Expected O, but got Unknown
		//IL_0764: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfd: Expected O, but got Unknown
		//IL_0d33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf1: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_05c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected O, but got Unknown
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Expected O, but got Unknown
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Expected O, but got Unknown
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected O, but got Unknown
		checked
		{
			try
			{
				Thickness val3;
				switch (Ani.TypeMain)
				{
				case AniType.Number:
				{
					double num7 = ModBase.MathPercent(0.0, Conversions.ToDouble(Ani.Value), Ani.Ease.GetDelta((double)Ani.TimeFinished / (double)Ani.TimeTotal, Ani.TimePercent));
					if (num7 == 0.0)
					{
						break;
					}
					switch (Ani.TypeSub)
					{
					case AniTypeSub.X:
						ModBase.DeltaLeft((FrameworkElement)Ani.Obj, num7);
						break;
					case AniTypeSub.Y:
						ModBase.DeltaTop((FrameworkElement)Ani.Obj, num7);
						break;
					case AniTypeSub.Opacity:
						NewLateBinding.LateSet(Ani.Obj, (System.Type)null, "Opacity", new object[] { ModBase.MathClamp(Conversions.ToDouble(Operators.AddObject(NewLateBinding.LateGet(Ani.Obj, (System.Type)null, "Opacity", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)num7)), 0.0, 1.0) }, (string[])null, (System.Type[])null);
						break;
					case AniTypeSub.Width:
					{
						FrameworkElement val6 = (FrameworkElement)Ani.Obj;
						val6.Width = Math.Max((double.IsNaN(val6.Width) ? val6.ActualWidth : val6.Width) + num7, 0.0);
						break;
					}
					case AniTypeSub.Height:
					{
						FrameworkElement val10 = (FrameworkElement)Ani.Obj;
						val10.Height = Math.Max((double.IsNaN(val10.Height) ? val10.ActualHeight : val10.Height) + num7, 0.0);
						break;
					}
					case AniTypeSub.Value:
					{
						object obj2 = Ani.Obj;
						NewLateBinding.LateSet(obj2, (System.Type)null, "Value", new object[] { Operators.AddObject(NewLateBinding.LateGet(obj2, (System.Type)null, "Value", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)num7) }, (string[])null, (System.Type[])null);
						break;
					}
					case AniTypeSub.Radius:
					{
						object obj2 = Ani.Obj;
						NewLateBinding.LateSet(obj2, (System.Type)null, "Radius", new object[] { Operators.AddObject(NewLateBinding.LateGet(obj2, (System.Type)null, "Radius", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)num7) }, (string[])null, (System.Type[])null);
						break;
					}
					case AniTypeSub.StrokeThickness:
						NewLateBinding.LateSet(Ani.Obj, (System.Type)null, "StrokeThickness", new object[] { NewLateBinding.LateGet((object)null, typeof(Math), "Max", new object[2]
						{
							Operators.AddObject(NewLateBinding.LateGet(Ani.Obj, (System.Type)null, "StrokeThickness", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)num7),
							0
						}, (string[])null, (System.Type[])null, (bool[])null) }, (string[])null, (System.Type[])null);
						break;
					case AniTypeSub.BorderThickness:
					{
						object obj10 = Ani.Obj;
						object[] array9 = new object[1];
						object obj11 = NewLateBinding.LateGet(Ani.Obj, (System.Type)null, "BorderThickness", new object[0], (string[])null, (System.Type[])null, (bool[])null);
						Thickness val5;
						if (obj11 == null)
						{
							val3 = default(Thickness);
							val5 = val3;
						}
						else
						{
							val5 = (Thickness)obj11;
						}
						val3 = (Thickness)val5;
						array9[0] = (object)new Thickness(val3.Bottom + num7);
						NewLateBinding.LateSet(obj10, (System.Type)null, "BorderThickness", array9, (string[])null, (System.Type[])null);
						break;
					}
					case AniTypeSub.TranslateX:
					{
						if (Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Ani.Obj, (System.Type)null, "RenderTransform", new object[0], (string[])null, (System.Type[])null, (bool[])null))) || !(NewLateBinding.LateGet(Ani.Obj, (System.Type)null, "RenderTransform", new object[0], (string[])null, (System.Type[])null, (bool[])null) is TranslateTransform))
						{
							NewLateBinding.LateSet(Ani.Obj, (System.Type)null, "RenderTransform", new object[] { (object)new TranslateTransform(0.0, 0.0) }, (string[])null, (System.Type[])null);
						}
						TranslateTransform val9 = (TranslateTransform)NewLateBinding.LateGet(Ani.Obj, (System.Type)null, "RenderTransform", new object[0], (string[])null, (System.Type[])null, (bool[])null);
						TranslateTransform val8 = val9;
						val9.X = val8.X + num7;
						break;
					}
					case AniTypeSub.TranslateY:
					{
						if (Information.IsNothing(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Ani.Obj, (System.Type)null, "RenderTransform", new object[0], (string[])null, (System.Type[])null, (bool[])null))) || !(NewLateBinding.LateGet(Ani.Obj, (System.Type)null, "RenderTransform", new object[0], (string[])null, (System.Type[])null, (bool[])null) is TranslateTransform))
						{
							NewLateBinding.LateSet(Ani.Obj, (System.Type)null, "RenderTransform", new object[] { (object)new TranslateTransform(0.0, 0.0) }, (string[])null, (System.Type[])null);
						}
						TranslateTransform val7 = (TranslateTransform)NewLateBinding.LateGet(Ani.Obj, (System.Type)null, "RenderTransform", new object[0], (string[])null, (System.Type[])null, (bool[])null);
						TranslateTransform val8 = val7;
						val7.Y = val8.Y + num7;
						break;
					}
					case AniTypeSub.Double:
					{
						object obj = NewLateBinding.LateIndexGet(Ani.Obj, new object[] { 0 }, (string[])null);
						object[] array = new object[2];
						object obj2 = Ani.Obj;
						object obj3 = obj2;
						object[] array2 = new object[1];
						object obj4 = (array2[0] = 1);
						array[0] = NewLateBinding.LateIndexGet(obj3, array2, (string[])null);
						object obj5 = NewLateBinding.LateIndexGet(Ani.Obj, new object[] { 0 }, (string[])null);
						object[] array3 = new object[1];
						object obj6 = Ani.Obj;
						object[] array4 = new object[1];
						object obj7 = (array4[0] = 1);
						array3[0] = NewLateBinding.LateIndexGet(obj6, array4, (string[])null);
						object[] array5 = array3;
						bool[] obj8 = new bool[] { true };
						bool[] array6 = obj8;
						object obj9 = NewLateBinding.LateGet(obj5, (System.Type)null, "GetValue", array3, (string[])null, (System.Type[])null, obj8);
						if (array6[0])
						{
							NewLateBinding.LateIndexSetComplex(obj6, new object[2]
							{
								obj7,
								array5[0]
							}, (string[])null, true, false);
						}
						array[1] = Operators.AddObject(obj9, (object)num7);
						object[] array7 = array;
						bool[] array8;
						NewLateBinding.LateCall(obj, (System.Type)null, "SetValue", array, (string[])null, (System.Type[])null, array8 = new bool[] { true, false }, true);
						if (array8[0])
						{
							NewLateBinding.LateIndexSetComplex(obj2, new object[2]
							{
								obj4,
								array7[0]
							}, (string[])null, true, false);
						}
						break;
					}
					case AniTypeSub.DoubleParam:
						((ParameterizedThreadStart)Ani.Obj).Invoke((object)num7);
						break;
					case AniTypeSub.GridLengthWidth:
						NewLateBinding.LateSet(Ani.Obj, (System.Type)null, "Width", new object[] { (object)new GridLength(Conversions.ToDouble(NewLateBinding.LateGet((object)null, typeof(Math), "Max", new object[2]
						{
							Operators.AddObject(NewLateBinding.LateGet(NewLateBinding.LateGet(Ani.Obj, (System.Type)null, "Width", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Value", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)num7),
							0
						}, (string[])null, (System.Type[])null, (bool[])null)), (GridUnitType)2) }, (string[])null, (System.Type[])null);
						break;
					}
					break;
				}
				case AniType.Color:
				{
					ModBase.MyColor myColor = ModBase.MathPercent(new ModBase.MyColor(0.0, 0.0, 0.0, 0.0), (ModBase.MyColor)Ani.Value, Ani.Ease.GetDelta((double)Ani.TimeFinished / (double)Ani.TimeTotal, Ani.TimePercent)) + (ModBase.MyColor)Ani.ValueLast;
					FrameworkElement val11 = (FrameworkElement)NewLateBinding.LateIndexGet(Ani.Obj, new object[] { 0 }, (string[])null);
					DependencyProperty val12 = (DependencyProperty)NewLateBinding.LateIndexGet(Ani.Obj, new object[] { 1 }, (string[])null);
					ModBase.MyColor myColor2 = new ModBase.MyColor(RuntimeHelpers.GetObjectValue(((DependencyObject)val11).GetValue(val12))) + myColor;
					((DependencyObject)val11).SetValue(val12, RuntimeHelpers.GetObjectValue((Operators.CompareString(((MemberInfo)val12.PropertyType).Name, "Color", false) == 0) ? ((object)(Color)myColor2) : ((SolidColorBrush)myColor2)));
					Ani.ValueLast = myColor2 - new ModBase.MyColor(RuntimeHelpers.GetObjectValue(((DependencyObject)val11).GetValue(val12)));
					break;
				}
				case AniType.Scale:
				{
					FrameworkElement val2 = (FrameworkElement)Ani.Obj;
					double delta = Ani.Ease.GetDelta((double)Ani.TimeFinished / (double)Ani.TimeTotal, Ani.TimePercent);
					val3 = val2.Margin;
					double num2 = val3.Left + ModBase.MathPercent(0.0, Conversions.ToDouble(NewLateBinding.LateGet(Ani.Value, (System.Type)null, "Left", new object[0], (string[])null, (System.Type[])null, (bool[])null)), delta);
					val3 = val2.Margin;
					double num3 = val3.Top + ModBase.MathPercent(0.0, Conversions.ToDouble(NewLateBinding.LateGet(Ani.Value, (System.Type)null, "Top", new object[0], (string[])null, (System.Type[])null, (bool[])null)), delta);
					val3 = val2.Margin;
					double num4 = val3.Right + ModBase.MathPercent(0.0, Conversions.ToDouble(NewLateBinding.LateGet(Ani.Value, (System.Type)null, "Left", new object[0], (string[])null, (System.Type[])null, (bool[])null)), delta);
					val3 = val2.Margin;
					val2.Margin = new Thickness(num2, num3, num4, val3.Bottom + ModBase.MathPercent(0.0, Conversions.ToDouble(NewLateBinding.LateGet(Ani.Value, (System.Type)null, "Top", new object[0], (string[])null, (System.Type[])null, (bool[])null)), delta));
					val2.Width = Math.Max(val2.Width + ModBase.MathPercent(0.0, Conversions.ToDouble(NewLateBinding.LateGet(Ani.Value, (System.Type)null, "Width", new object[0], (string[])null, (System.Type[])null, (bool[])null)), delta), 0.0);
					val2.Height = Math.Max(val2.Height + ModBase.MathPercent(0.0, Conversions.ToDouble(NewLateBinding.LateGet(Ani.Value, (System.Type)null, "Height", new object[0], (string[])null, (System.Type[])null, (bool[])null)), delta), 0.0);
					break;
				}
				case AniType.TextAppear:
				{
					int num5 = (int)Math.Round((double)(Conversions.ToBoolean(NewLateBinding.LateIndexGet(Ani.Value, new object[] { 1 }, (string[])null)) ? NewLateBinding.LateIndexGet(Ani.Value, new object[] { 0 }, (string[])null).ToString().Length : 0) + Math.Round((double)(NewLateBinding.LateIndexGet(Ani.Value, new object[] { 0 }, (string[])null).ToString().Length * ((!Conversions.ToBoolean(NewLateBinding.LateIndexGet(Ani.Value, new object[] { 1 }, (string[])null))) ? 1 : (-1))) * Ani.Ease.GetDelta((double)Ani.TimeFinished / (double)Ani.TimeTotal, 0.0)));
					string text = Strings.Mid(Conversions.ToString(NewLateBinding.LateIndexGet(Ani.Value, new object[] { 0 }, (string[])null)), 1, num5);
					if (num5 < NewLateBinding.LateIndexGet(Ani.Value, new object[] { 0 }, (string[])null).ToString().Length)
					{
						text = ((Convert.ToInt32(Convert.ToChar(Strings.Mid(Conversions.ToString(NewLateBinding.LateIndexGet(Ani.Value, new object[] { 0 }, (string[])null)), num5 + 1, 1))) < Convert.ToInt32(Convert.ToChar(128))) ? (text + Conversions.ToString(RandomUtils.PickRandom("0123456789./*-+\\[]{};':/?,!@#$%^&*()_+-=qwwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM".ToCharArray()))) : (text + Encoding.GetEncoding("GB18030").GetString(new byte[2]
						{
							(byte)RandomUtils.NextInt(176, 247),
							(byte)RandomUtils.NextInt(161, 249)
						})));
					}
					if (Ani.Obj is TextBlock)
					{
						NewLateBinding.LateSet(Ani.Obj, (System.Type)null, "Text", new object[] { text }, (string[])null, (System.Type[])null);
					}
					else
					{
						NewLateBinding.LateSet(Ani.Obj, (System.Type)null, "Context", new object[] { text }, (string[])null, (System.Type[])null);
					}
					break;
				}
				case AniType.Code:
					((ThreadStart)Ani.Value).Invoke();
					break;
				case AniType.ScaleTransform:
				{
					FrameworkElement val4 = (FrameworkElement)Ani.Obj;
					if (!(((UIElement)val4).RenderTransform is ScaleTransform))
					{
						((UIElement)val4).RenderTransformOrigin = new Point(0.5, 0.5);
						((UIElement)val4).RenderTransform = (Transform)new ScaleTransform(1.0, 1.0);
					}
					double num6 = ModBase.MathPercent(0.0, Conversions.ToDouble(Ani.Value), Ani.Ease.GetDelta((double)Ani.TimeFinished / (double)Ani.TimeTotal, Ani.TimePercent));
					((ScaleTransform)((UIElement)val4).RenderTransform).ScaleX = Math.Max(((ScaleTransform)((UIElement)val4).RenderTransform).ScaleX + num6, 0.0);
					((ScaleTransform)((UIElement)val4).RenderTransform).ScaleY = Math.Max(((ScaleTransform)((UIElement)val4).RenderTransform).ScaleY + num6, 0.0);
					break;
				}
				case AniType.RotateTransform:
				{
					FrameworkElement val = (FrameworkElement)Ani.Obj;
					if (!(((UIElement)val).RenderTransform is RotateTransform))
					{
						((UIElement)val).RenderTransformOrigin = new Point(0.5, 0.5);
						((UIElement)val).RenderTransform = (Transform)new RotateTransform(0.0);
					}
					double num = ModBase.MathPercent(0.0, Conversions.ToDouble(Ani.Value), Ani.Ease.GetDelta((double)Ani.TimeFinished / (double)Ani.TimeTotal, Ani.TimePercent));
					((RotateTransform)((UIElement)val).RenderTransform).Angle = ((RotateTransform)((UIElement)val).RenderTransform).Angle + num;
					break;
				}
				}
				Ani.TimePercent = (double)Ani.TimeFinished / (double)Ani.TimeTotal;
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "执行动画失败：" + ((object)Ani).ToString(), ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
			return Ani;
		}
	}
}
