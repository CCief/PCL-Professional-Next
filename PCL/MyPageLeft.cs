using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class MyPageLeft : Grid
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__8_002D0
	{
		public FrameworkElement _0024VB_0024Local_Element;

		public MyPageLeft _0024VB_0024Me;

		public _Closure_0024__8_002D0(_Closure_0024__8_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Element = arg0._0024VB_0024Local_Element;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			((MyListItem)(object)_0024VB_0024Local_Element).IsMouseOverAnimationEnabled = true;
			((MyListItem)(object)_0024VB_0024Local_Element).RefreshColor(_0024VB_0024Me, new EventArgs());
		}
	}

	private int Uuid;

	private bool _animatedControlNullWarned;

	public static DependencyProperty AnimatedControlProperty = DependencyProperty.Register("AnimatedControl", typeof(FrameworkElement), typeof(MyPageLeft));

	public FrameworkElement AnimatedControl
	{
		get
		{
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			object objectValue = RuntimeHelpers.GetObjectValue(base.GetValue(AnimatedControlProperty));
			if (objectValue == null && !_animatedControlNullWarned)
			{
				_animatedControlNullWarned = true;
				ModBase.Log($"[MyPageLeft] 获取到 AnimatedControl(来自 {((FrameworkElement)this).Name}) 的值为 null", ModBase.LogLevel.Debug);
			}
			return (FrameworkElement)objectValue;
		}
		set
		{
			base.SetValue(AnimatedControlProperty, (object)value);
		}
	}

	public MyPageLeft()
	{
		Uuid = ModBase.GetUuid();
		_animatedControlNullWarned = false;
	}

	public void TriggerShowAnimation()
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Invalid comparison between Unknown and I4
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected O, but got Unknown
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		if (AnimatedControl == null)
		{
			if (!(((UIElement)this).RenderTransform is ScaleTransform))
			{
				((UIElement)this).RenderTransform = (Transform)new ScaleTransform(0.96, 0.96);
				((UIElement)this).RenderTransformOrigin = new Point(0.5, 0.5);
			}
			((UIElement)this).Opacity = 0.0;
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
			{
				ModAnimation.AaScaleTransform(this, 1.0 - ((ScaleTransform)((UIElement)this).RenderTransform).ScaleX, 400, 0, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)),
				ModAnimation.AaOpacity(this, 1.0, 100)
			}, "PageLeft PageChange " + Conversions.ToString(Uuid));
			return;
		}
		List<ModAnimation.AniData> val = new List<ModAnimation.AniData>();
		int num = 0;
		int num2 = 0;
		System.Collections.Generic.IEnumerator<FrameworkElement> enumerator = default(System.Collections.Generic.IEnumerator<FrameworkElement>);
		try
		{
			enumerator = GetAllAnimControls(IgnoreInvisibility: true).GetEnumerator();
			_Closure_0024__8_002D0 closure_0024__8_002D = default(_Closure_0024__8_002D0);
			while (enumerator.MoveNext())
			{
				closure_0024__8_002D = new _Closure_0024__8_002D0(closure_0024__8_002D);
				closure_0024__8_002D._0024VB_0024Me = this;
				closure_0024__8_002D._0024VB_0024Local_Element = enumerator.Current;
				if ((int)((UIElement)closure_0024__8_002D._0024VB_0024Local_Element).Visibility == 2)
				{
					((UIElement)closure_0024__8_002D._0024VB_0024Local_Element).Opacity = 1.0;
					((UIElement)closure_0024__8_002D._0024VB_0024Local_Element).RenderTransform = (Transform)new TranslateTransform(0.0, 0.0);
					if (closure_0024__8_002D._0024VB_0024Local_Element is MyListItem)
					{
						((MyListItem)(object)closure_0024__8_002D._0024VB_0024Local_Element).IsMouseOverAnimationEnabled = true;
					}
					continue;
				}
				((UIElement)closure_0024__8_002D._0024VB_0024Local_Element).Opacity = 0.0;
				((UIElement)closure_0024__8_002D._0024VB_0024Local_Element).RenderTransform = (Transform)new TranslateTransform(-25.0, 0.0);
				if (closure_0024__8_002D._0024VB_0024Local_Element is MyListItem)
				{
					((MyListItem)(object)closure_0024__8_002D._0024VB_0024Local_Element).IsMouseOverAnimationEnabled = false;
				}
				val.Add(ModAnimation.AaOpacity(closure_0024__8_002D._0024VB_0024Local_Element, (closure_0024__8_002D._0024VB_0024Local_Element is TextBlock) ? 0.6 : 1.0, 100, num2, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)));
				val.Add(ModAnimation.AaTranslateX(closure_0024__8_002D._0024VB_0024Local_Element, 5.0, 200, num2, new ModAnimation.AniEaseOutFluent()));
				val.Add(ModAnimation.AaTranslateX(closure_0024__8_002D._0024VB_0024Local_Element, 20.0, 300, num2, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)));
				checked
				{
					if (closure_0024__8_002D._0024VB_0024Local_Element is MyListItem)
					{
						val.Add(ModAnimation.AaCode(new ThreadStart(closure_0024__8_002D._Lambda_0024__0), num2 + 280));
					}
					num2 += Math.Max(15 - num, 7) * 2;
					num++;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		ModAnimation.AniStart((System.Collections.IList)val, "PageLeft PageChange " + Conversions.ToString(Uuid));
	}

	public void TriggerHideAnimation()
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		if (AnimatedControl == null)
		{
			if (!(((UIElement)this).RenderTransform is ScaleTransform))
			{
				((UIElement)this).RenderTransform = (Transform)new ScaleTransform(1.0, 1.0);
				((UIElement)this).RenderTransformOrigin = new Point(0.5, 0.5);
			}
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
			{
				ModAnimation.AaScaleTransform(this, 0.95 - ((ScaleTransform)((UIElement)this).RenderTransform).ScaleX, 110, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)),
				ModAnimation.AaOpacity(this, 0.0 - ((UIElement)this).Opacity, 80, 30)
			}, "PageLeft PageChange " + Conversions.ToString(Uuid));
			return;
		}
		List<ModAnimation.AniData> val = new List<ModAnimation.AniData>();
		int num = 0;
		List<FrameworkElement> allAnimControls = GetAllAnimControls();
		checked
		{
			System.Collections.Generic.IEnumerator<FrameworkElement> enumerator = default(System.Collections.Generic.IEnumerator<FrameworkElement>);
			try
			{
				enumerator = allAnimControls.GetEnumerator();
				while (enumerator.MoveNext())
				{
					FrameworkElement current = enumerator.Current;
					val.Add(ModAnimation.AaOpacity(current, 0.0 - ((UIElement)current).Opacity, 50, (int)Math.Round(70.0 / (double)allAnimControls.Count * (double)num)));
					val.Add(ModAnimation.AaTranslateX(current, -6.0, 50, (int)Math.Round(70.0 / (double)allAnimControls.Count * (double)num)));
					num++;
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			ModAnimation.AniStart((System.Collections.IList)val, "PageLeft PageChange " + Conversions.ToString(Uuid));
		}
	}

	private List<FrameworkElement> GetAllAnimControls(bool IgnoreInvisibility = false)
	{
		List<FrameworkElement> AllControls = new List<FrameworkElement>();
		GetAllAnimControls(AnimatedControl, ref AllControls, IgnoreInvisibility);
		return AllControls;
	}

	private void GetAllAnimControls(FrameworkElement Element, ref List<FrameworkElement> AllControls, bool IgnoreInvisibility)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		if (!IgnoreInvisibility && (int)((UIElement)Element).Visibility == 2)
		{
			return;
		}
		if (Element is MyTextButton)
		{
			AllControls.Add(Element);
			return;
		}
		if (Element is MyListItem)
		{
			AllControls.Add(Element);
			return;
		}
		if (Element is ContentControl)
		{
			GetAllAnimControls((FrameworkElement)((ContentControl)Element).Content, ref AllControls, IgnoreInvisibility);
			return;
		}
		if (Element is Panel)
		{
			foreach (FrameworkElement child in ((Panel)Element).Children)
			{
				FrameworkElement element = child;
				GetAllAnimControls(element, ref AllControls, IgnoreInvisibility);
			}
			return;
		}
		AllControls.Add(Element);
	}
}
