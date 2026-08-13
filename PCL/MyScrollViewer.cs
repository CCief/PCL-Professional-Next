using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class MyScrollViewer : ScrollViewer
{
	private double RealOffset;

	public MyScrollBar ScrollBar;

	[field: CompilerGenerated]
	public double DeltaMult
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public MyScrollViewer()
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
		((UIElement)this).PreviewMouseWheel += new MouseWheelEventHandler(MyScrollViewer_PreviewMouseWheel);
		((ScrollViewer)this).ScrollChanged += new ScrollChangedEventHandler(MyScrollViewer_ScrollChanged);
		((UIElement)this).IsVisibleChanged += new DependencyPropertyChangedEventHandler(MyScrollViewer_IsVisibleChanged);
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Load();
		});
		((UIElement)this).PreviewGotKeyboardFocus += new KeyboardFocusChangedEventHandler(MyScrollViewer_PreviewGotKeyboardFocus);
		DeltaMult = 1.0;
	}

	private void MyScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		if (e.Delta == 0 || ((FrameworkElement)this).ActualHeight == 0.0 || ((ScrollViewer)this).ScrollableHeight == 0.0)
		{
			return;
		}
		System.Type type = ((RoutedEventArgs)e).Source.GetType();
		if (NewLateBinding.LateGet(((ContentControl)this).Content, (System.Type)null, "TemplatedParent", new object[0], (string[])null, (System.Type[])null, (bool[])null) == null && ((typeof(ComboBox).IsAssignableFrom(type) && ((ComboBox)((RoutedEventArgs)e).Source).IsDropDownOpen) || (typeof(TextBox).IsAssignableFrom(type) && ((TextBoxBase)(TextBox)((RoutedEventArgs)e).Source).AcceptsReturn) || typeof(ComboBoxItem).IsAssignableFrom(type) || ((RoutedEventArgs)e).Source is CheckBox))
		{
			return;
		}
		((RoutedEventArgs)e).Handled = true;
		PerformVerticalOffsetDelta(checked(-e.Delta));
		System.Collections.Generic.IEnumerator<Border> enumerator = default(System.Collections.Generic.IEnumerator<Border>);
		try
		{
			enumerator = Application.ShowingTooltips.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ModAnimation.AniStart(ModAnimation.AaOpacity(enumerator.Current, -1.0, 100), $"Hide Tooltip {ModBase.GetUuid()}");
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	public void PerformVerticalOffsetDelta(double Delta)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		ModAnimation.AniStart(ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] [CompilerGenerated] (object a0) =>
		{
			_Lambda_0024__7_002D0(Conversions.ToDouble(a0));
		}), Delta * DeltaMult, 300, 0, new ModAnimation.AniEaseOutFluent((ModAnimation.AniEasePower)6)));
	}

	private void MyScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
	{
		RealOffset = ((ScrollViewer)this).VerticalOffset;
		if (ModMain.FrmMain != null && (e.VerticalChange != 0.0 || e.ViewportHeightChange != 0.0))
		{
			ModMain.FrmMain.BtnExtraBack.ShowRefresh();
		}
	}

	private void MyScrollViewer_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		ModMain.FrmMain.BtnExtraBack.ShowRefresh();
	}

	private void Load()
	{
		ScrollBar = (MyScrollBar)(object)base.GetTemplateChild("PART_VerticalScrollBar");
	}

	private void MyScrollViewer_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
	{
		if (e.NewFocus != null && e.NewFocus is MySlider)
		{
			((RoutedEventArgs)e).Handled = true;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__7_002D0(double AnimDelta)
	{
		RealOffset = ModBase.MathClamp(RealOffset + AnimDelta, 0.0, ((ScrollViewer)this).ExtentHeight - ((FrameworkElement)this).ActualHeight);
		base.ScrollToVerticalOffset(RealOffset);
	}
}
