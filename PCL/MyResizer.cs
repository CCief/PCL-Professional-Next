using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

public class MyResizer
{
	private delegate void RefreshDelegate();

	private struct POINT
	{
		public int x;

		public int y;

		public POINT(int x, int y)
		{
			this = default(POINT);
			this.x = x;
			this.y = y;
		}
	}

	private struct MINMAXINFO
	{
		public POINT ptReserved;

		public POINT ptMaxSize;

		public POINT ptMaxPosition;

		public POINT ptMinTrackSize;

		public POINT ptMaxTrackSize;
	}

	private struct RECT
	{
		public int left;

		public int top;

		public int right;

		public int bottom;

		public static RECT Empty = default(RECT);

		public int Width => Math.Abs(checked(right - left));

		public int Height => checked(bottom - top);

		public RECT(int left, int top, int right, int bottom)
		{
			this = default(RECT);
			this.left = left;
			this.top = top;
			this.right = right;
			this.bottom = bottom;
		}

		public RECT(RECT rcSrc)
		{
			this = default(RECT);
			left = rcSrc.left;
			top = rcSrc.top;
			right = rcSrc.right;
			bottom = rcSrc.bottom;
		}
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	private class MONITORINFO
	{
		public int cbSize;

		public RECT rcMonitor;

		public RECT rcWork;

		public int dwFlags;

		public MONITORINFO()
		{
			cbSize = Marshal.SizeOf(typeof(MONITORINFO));
			rcMonitor = default(RECT);
			rcWork = default(RECT);
			dwFlags = 0;
		}
	}

	private struct PointAPI
	{
		public int X;

		public int Y;
	}

	private readonly Window target;

	private bool resizeRight;

	private bool resizeLeft;

	private bool resizeUp;

	private bool resizeDown;

	private readonly Dictionary<UIElement, short> leftElements;

	private readonly Dictionary<UIElement, short> rightElements;

	private readonly Dictionary<UIElement, short> upElements;

	private readonly Dictionary<UIElement, short> downElements;

	private PointAPI startMousePoint;

	private Size startWindowSize;

	private POINT startWindowLeftUpPoint;

	private static int workAreaMaxHeight = -1;

	private HwndSource hs;

	public MyResizer(Window target)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		this.target = null;
		resizeRight = false;
		resizeLeft = false;
		resizeUp = false;
		resizeDown = false;
		leftElements = new Dictionary<UIElement, short>();
		rightElements = new Dictionary<UIElement, short>();
		upElements = new Dictionary<UIElement, short>();
		downElements = new Dictionary<UIElement, short>();
		startMousePoint = default(PointAPI);
		startWindowSize = default(Size);
		startWindowLeftUpPoint = default(POINT);
		this.target = target;
		if (Information.IsNothing((object)target))
		{
			throw new System.Exception("Invalid Window handle");
		}
		target.SourceInitialized += new EventHandler(MyMacClass_SourceInitialized);
	}

	private void MyMacClass_SourceInitialized(object sender, EventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		HwndSource reference = hs;
		PresentationSource obj = PresentationSource.FromVisual((Visual)sender);
		reference = (HwndSource)(object)((obj is HwndSource) ? obj : null);
		hs.AddHook(new HwndSourceHook(WndProc));
	}

	private nint WndProc(nint hwnd, int msg, nint wParam, nint lParam, ref bool handled)
	{
		if (msg == 36)
		{
			WmGetMinMaxInfo(hwnd, lParam);
			handled = true;
		}
		return (System.IntPtr)0;
	}

	private static void WmGetMinMaxInfo(nint hwnd, nint lParam)
	{
		object obj = Marshal.PtrToStructure((System.IntPtr)lParam, typeof(MINMAXINFO));
		MINMAXINFO mINMAXINFO = ((obj != null) ? ((MINMAXINFO)obj) : default(MINMAXINFO));
		int flags = 2;
		nint hMonitor = MonitorFromWindow(hwnd, flags);
		if (!((System.IntPtr)hMonitor).Equals(System.IntPtr.Zero))
		{
			MONITORINFO mONITORINFO = new MONITORINFO();
			GetMonitorInfo(hMonitor, mONITORINFO);
			RECT rcWork = mONITORINFO.rcWork;
			RECT rcMonitor = mONITORINFO.rcMonitor;
			checked
			{
				mINMAXINFO.ptMaxPosition.x = Math.Abs(rcWork.left - rcMonitor.left);
				mINMAXINFO.ptMaxPosition.y = Math.Abs(rcWork.top - rcMonitor.top);
				mINMAXINFO.ptMaxSize.y = Math.Abs(rcWork.bottom - rcWork.top);
				workAreaMaxHeight = mINMAXINFO.ptMaxSize.y;
				if (rcWork.Height == rcMonitor.Height)
				{
					mINMAXINFO.ptMaxSize.y -= 2;
				}
			}
		}
		Marshal.StructureToPtr<MINMAXINFO>(mINMAXINFO, (System.IntPtr)lParam, true);
	}

	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern bool GetMonitorInfo(nint hMonitor, MONITORINFO lpmi);

	[DllImport("User32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern nint MonitorFromWindow(nint handle, int flags);

	private void connectMouseHandlers(UIElement element)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		element.MouseLeftButtonDown += new MouseButtonEventHandler(element_MouseLeftButtonDown);
	}

	public void addResizerRight(UIElement element)
	{
		connectMouseHandlers(element);
		rightElements.Add(element, (short)0);
	}

	public void addResizerLeft(UIElement element)
	{
		connectMouseHandlers(element);
		leftElements.Add(element, (short)0);
	}

	public void addResizerUp(UIElement element)
	{
		connectMouseHandlers(element);
		upElements.Add(element, (short)0);
	}

	public void addResizerDown(UIElement element)
	{
		connectMouseHandlers(element);
		downElements.Add(element, (short)0);
	}

	public void addResizerRightDown(UIElement element)
	{
		connectMouseHandlers(element);
		rightElements.Add(element, (short)0);
		downElements.Add(element, (short)0);
	}

	public void addResizerLeftDown(UIElement element)
	{
		connectMouseHandlers(element);
		leftElements.Add(element, (short)0);
		downElements.Add(element, (short)0);
	}

	public void addResizerRightUp(UIElement element)
	{
		connectMouseHandlers(element);
		rightElements.Add(element, (short)0);
		upElements.Add(element, (short)0);
	}

	public void addResizerLeftUp(UIElement element)
	{
		connectMouseHandlers(element);
		leftElements.Add(element, (short)0);
		upElements.Add(element, (short)0);
	}

	public void removeAllResizers()
	{
		leftElements.Clear();
		rightElements.Clear();
		upElements.Clear();
		downElements.Clear();
	}

	private void element_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		GetCursorPos(out startMousePoint);
		checked
		{
			startMousePoint.X = (int)Math.Round(ModBase.GetWPFSize(startMousePoint.X));
			startMousePoint.Y = (int)Math.Round(ModBase.GetWPFSize(startMousePoint.Y));
			startWindowSize = new Size(((FrameworkElement)target).Width, ((FrameworkElement)target).Height);
			startWindowLeftUpPoint = new POINT((int)Math.Round(target.Left), (int)Math.Round(target.Top));
			UIElement val = (UIElement)sender;
			if (leftElements.ContainsKey(val))
			{
				resizeLeft = true;
			}
			if (rightElements.ContainsKey(val))
			{
				resizeRight = true;
			}
			if (upElements.ContainsKey(val))
			{
				resizeUp = true;
			}
			if (downElements.ContainsKey(val))
			{
				resizeDown = true;
			}
			ModBase.RunInNewThread(new Action(updateSizeLoop), "窗口大小调整检测", (ThreadPriority)2);
		}
	}

	private void updateSizeLoop()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		try
		{
			while (resizeDown || resizeLeft || resizeRight || resizeUp)
			{
				((DispatcherObject)target).Dispatcher.Invoke(new Action(updateSize), (DispatcherPriority)7);
				((DispatcherObject)target).Dispatcher.Invoke(new Action(updateMouseDown), (DispatcherPriority)7);
				Thread.Sleep(0);
			}
		}
		catch (System.Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void updateSize()
	{
		PointAPI lpPoint = default(PointAPI);
		GetCursorPos(out lpPoint);
		checked
		{
			lpPoint.X = (int)Math.Round(ModBase.GetWPFSize(lpPoint.X));
			lpPoint.Y = (int)Math.Round(ModBase.GetWPFSize(lpPoint.Y));
			try
			{
				double num = -1.0;
				double num2 = -1.0;
				double num3 = -10000.0;
				double num4 = -10000.0;
				if (resizeRight)
				{
					if (((FrameworkElement)target).Width != ((FrameworkElement)target).MinWidth)
					{
						num = ((!(startWindowSize.Width - (double)(startMousePoint.X - lpPoint.X) >= ((FrameworkElement)target).MinWidth)) ? ((FrameworkElement)target).MinWidth : (startWindowSize.Width - (double)(startMousePoint.X - lpPoint.X)));
					}
					else if (startMousePoint.X < lpPoint.X)
					{
						num = startWindowSize.Width - (double)(startMousePoint.X - lpPoint.X);
					}
				}
				if (resizeDown)
				{
					if (((FrameworkElement)target).Height != ((FrameworkElement)target).MinHeight)
					{
						num2 = ((!(startWindowSize.Height - (double)(startMousePoint.Y - lpPoint.Y) >= ((FrameworkElement)target).MinHeight)) ? ((FrameworkElement)target).MinHeight : ((workAreaMaxHeight <= 0) ? (startWindowSize.Height - (double)(startMousePoint.Y - lpPoint.Y)) : ((startWindowSize.Height - (double)(startMousePoint.Y - lpPoint.Y) + target.Top <= (double)workAreaMaxHeight) ? (startWindowSize.Height - (double)(startMousePoint.Y - lpPoint.Y)) : ((double)workAreaMaxHeight - target.Top))));
					}
					else if (startMousePoint.Y < lpPoint.Y)
					{
						num2 = ((workAreaMaxHeight <= 0) ? (startWindowSize.Height - (double)(startMousePoint.Y - lpPoint.Y)) : ((startWindowSize.Height - (double)(startMousePoint.Y - lpPoint.Y) + target.Top <= (double)workAreaMaxHeight) ? (startWindowSize.Height - (double)(startMousePoint.Y - lpPoint.Y)) : ((double)workAreaMaxHeight - target.Top)));
					}
				}
				if (resizeLeft)
				{
					if (((FrameworkElement)target).Width == ((FrameworkElement)target).MinWidth)
					{
						if (startMousePoint.X > lpPoint.X)
						{
							num = startWindowSize.Width + (double)startMousePoint.X - (double)lpPoint.X;
							num3 = startWindowLeftUpPoint.x - (startMousePoint.X - lpPoint.X);
						}
						else
						{
							num = ((FrameworkElement)target).MinWidth;
							num3 = (double)startWindowLeftUpPoint.x + startWindowSize.Width - ((FrameworkElement)target).Width;
						}
					}
					else if (startWindowSize.Width + (double)(startMousePoint.X - lpPoint.X) >= ((FrameworkElement)target).MinWidth)
					{
						num = startWindowSize.Width + (double)(startMousePoint.X - lpPoint.X);
						num3 = startWindowLeftUpPoint.x - (startMousePoint.X - lpPoint.X);
					}
					else
					{
						num = ((FrameworkElement)target).MinWidth;
						num3 = (double)startWindowLeftUpPoint.x + startWindowSize.Width - ((FrameworkElement)target).Width;
					}
				}
				if (resizeUp)
				{
					if (((FrameworkElement)target).Height == ((FrameworkElement)target).MinHeight)
					{
						if (startMousePoint.Y > lpPoint.Y)
						{
							num2 = startWindowSize.Height + (double)startMousePoint.Y - (double)lpPoint.Y;
							num4 = startWindowLeftUpPoint.y - (startMousePoint.Y - lpPoint.Y);
						}
						else
						{
							num2 = ((FrameworkElement)target).MinHeight;
							num4 = (double)startWindowLeftUpPoint.y + startWindowSize.Height - ((FrameworkElement)target).Height;
						}
					}
					else if (startWindowSize.Height + (double)(startMousePoint.Y - lpPoint.Y) >= ((FrameworkElement)target).MinHeight)
					{
						num2 = startWindowSize.Height + (double)startMousePoint.Y - (double)lpPoint.Y;
						num4 = startWindowLeftUpPoint.y - (startMousePoint.Y - lpPoint.Y);
					}
					else
					{
						num2 = ((FrameworkElement)target).MinHeight;
						num4 = (double)startWindowLeftUpPoint.y + startWindowSize.Height - ((FrameworkElement)target).Height;
					}
				}
				if (num > 10.0 && Math.Abs(num - ((FrameworkElement)target).Width) > 0.7)
				{
					((FrameworkElement)target).Width = num;
				}
				if (num2 > 10.0 && Math.Abs(num2 - ((FrameworkElement)target).Height) > 0.7)
				{
					((FrameworkElement)target).Height = num2;
				}
				if (num3 > -9999.0 && Math.Abs(num3 - target.Left) > 0.7)
				{
					target.Left = num3;
				}
				if (num4 > -9999.0 && Math.Abs(num4 - target.Top) > 0.7)
				{
					target.Top = num4;
				}
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void updateMouseDown()
	{
		if ((GetAsyncKeyState(1) & 0x8000) == 0)
		{
			resizeRight = false;
			resizeLeft = false;
			resizeUp = false;
			resizeDown = false;
		}
	}

	[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern bool GetCursorPos(out PointAPI lpPoint);

	[DllImport("user32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern short GetAsyncKeyState(int vKey);
}
