using System;
using System.CodeDom.Compiler;
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
using System.Windows.Threading;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageSpeedLeft : MyPageLeft, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<ModLoader.LoaderBase, bool> _0024I5_002D0;

		public static Func<ModLoader.LoaderBase, double> _0024I5_002D1;

		public static VB_0024AnonymousDelegate_1<TextBlock, EventArgs> _0024I6_002D0;

		public static MouseButtonEventHandler _0024IR6_002D2;

		public static VB_0024AnonymousDelegate_8 _0024I6_002D2;

		public static ParameterizedThreadStart _0024IR6_002D5;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal bool _Lambda_0024__5_002D0(ModLoader.LoaderBase l)
		{
			return l.Show;
		}

		[SpecialName]
		internal double _Lambda_0024__5_002D1(ModLoader.LoaderBase l)
		{
			return l.Progress;
		}

		[SpecialName]
		internal void _Lambda_0024__R6_002D2(object a0, MouseButtonEventArgs a1)
		{
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			((VB_0024AnonymousDelegate_1<TextBlock, EventArgs>)([SpecialName] (TextBlock sender, EventArgs e) =>
			{
				ModBase.ClipboardSet(sender.Text, ShowSuccessHint: false);
				ModMain.Hint("已复制错误详情！", ModMain.HintType.Finish);
			}))((TextBlock)a0, (EventArgs)(object)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__6_002D0(TextBlock sender, EventArgs e)
		{
			ModBase.ClipboardSet(sender.Text, ShowSuccessHint: false);
			ModMain.Hint("已复制错误详情！", ModMain.HintType.Finish);
		}

		[SpecialName]
		internal void _Lambda_0024__R6_002D5(object a0)
		{
			((VB_0024AnonymousDelegate_8)([SpecialName] () =>
			{
				if (((Panel)ModMain.FrmSpeedRight.PanMain).Children.Count == 0 && ModMain.FrmMain.PageCurrent == FormMain.PageType.TaskManager)
				{
					ModMain.FrmMain.PageBack();
				}
			}))();
		}

		[SpecialName]
		internal void _Lambda_0024__6_002D2()
		{
			if (((Panel)ModMain.FrmSpeedRight.PanMain).Children.Count == 0 && ModMain.FrmMain.PageCurrent == FormMain.PageType.TaskManager)
			{
				ModMain.FrmMain.PageBack();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D0
	{
		public MyCard _0024VB_0024Local_Card;

		public _Closure_0024__6_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__6_002D0(_Closure_0024__6_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Card = arg0._0024VB_0024Local_Card;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R4(object a0, EventArgs a1)
		{
			_Lambda_0024__1((MyIconButton)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__1(MyIconButton sender, EventArgs e)
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Expected O, but got Unknown
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_00d1: Expected O, but got Unknown
			ModAnimation.AniDispose(sender, RemoveFromChildren: false);
			MyCard control = _0024VB_0024Local_Card;
			object callBack;
			if (_Closure_0024__._0024IR6_002D5 != null)
			{
				callBack = _Closure_0024__._0024IR6_002D5;
			}
			else
			{
				ParameterizedThreadStart val = [SpecialName] (object a0) =>
				{
					((VB_0024AnonymousDelegate_8)([SpecialName] () =>
					{
						if (((Panel)ModMain.FrmSpeedRight.PanMain).Children.Count == 0 && ModMain.FrmMain.PageCurrent == FormMain.PageType.TaskManager)
						{
							ModMain.FrmMain.PageBack();
						}
					}))();
				};
				_Closure_0024__._0024IR6_002D5 = val;
				callBack = (object)val;
			}
			ModAnimation.AniDispose(control, RemoveFromChildren: true, (ParameterizedThreadStart)callBack);
			_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.RightCards.Remove(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Loader.Name);
			((List<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar).Remove(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Loader);
			ModBase.Log($"[Taskbar] 关闭任务管理卡片：{_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Loader.Name}，且移出任务列表");
			Action action;
			if (_0024VB_0024NonLocal__0024VB_0024Closure_2._0024I3 != null)
			{
				action = _0024VB_0024NonLocal__0024VB_0024Closure_2._0024I3;
			}
			else
			{
				_Closure_0024__6_002D1 closure_0024__6_002D = _0024VB_0024NonLocal__0024VB_0024Closure_2;
				Action val2 = [SpecialName] () =>
				{
					_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Loader.Abort();
				};
				Action val3 = val2;
				closure_0024__6_002D._0024I3 = val2;
				action = val3;
			}
			ModBase.RunInThread(action);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D1
	{
		public ModLoader.LoaderBase _0024VB_0024Local_Loader;

		public PageSpeedLeft _0024VB_0024Me;

		public Action _0024I3;

		public _Closure_0024__6_002D1(_Closure_0024__6_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			_0024VB_0024Local_Loader.Abort();
		}
	}

	private const int WatcherInterval = 300;

	private bool IsLoad;

	private readonly Dictionary<string, MyCard> RightCards;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabProgress")]
	internal virtual TextBlock LabProgress
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabSpeed")]
	internal virtual TextBlock LabSpeed
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabFile")]
	internal virtual TextBlock LabFile
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabThread")]
	internal virtual TextBlock LabThread
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageSpeedLeft()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(Page_Loaded);
		IsLoad = false;
		RightCards = new Dictionary<string, MyCard>();
		InitializeComponent();
	}

	private void Page_Loaded(object sender, RoutedEventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		Watcher();
		TryReturnToHome();
		if (!IsLoad)
		{
			IsLoad = true;
			DispatcherTimer val = new DispatcherTimer
			{
				Interval = new TimeSpan(0, 0, 0, 0, 300)
			};
			val.Tick += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				Watcher();
			});
			val.Start();
			if (!ModBase.ModeDebug)
			{
				((Grid)this).RowDefinitions[12].Height = new GridLength(0.0);
				((Grid)this).RowDefinitions[13].Height = new GridLength(0.0);
				((Grid)this).RowDefinitions[14].Height = new GridLength(0.0);
				((Grid)this).RowDefinitions[15].Height = new GridLength(0.0);
			}
		}
	}

	private void Watcher()
	{
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		if (!(ModMain.FrmMain.PageCurrent == FormMain.PageType.TaskManager))
		{
			return;
		}
		try
		{
			if (!Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar))
			{
				LabProgress.Text = "100 %";
				LabSpeed.Text = "0 B/s";
				LabFile.Text = "0";
				LabThread.Text = "0 / " + Conversions.ToString(ModNet.NetTaskThreadLimit);
			}
			else
			{
				List<ModLoader.LoaderBase> val = Enumerable.ToList<ModLoader.LoaderBase>(Enumerable.Where<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)ModLoader.LoaderTaskbar, (Func<ModLoader.LoaderBase, bool>)([SpecialName] (ModLoader.LoaderBase l) => l.Show)));
				double num = (Enumerable.Any<ModLoader.LoaderBase>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val) ? ModBase.MathClamp(Enumerable.Average(Enumerable.Select<ModLoader.LoaderBase, double>((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val, (Func<ModLoader.LoaderBase, double>)([SpecialName] (ModLoader.LoaderBase l) => l.Progress))), 0.0, 1.0) : 1.0);
				string text = Conversions.ToString(Math.Floor(num * 100.0)) + "." + ModBase.StrFill(Conversions.ToString(Math.Floor((num * 100.0 - Math.Floor(num * 100.0)) * 100.0)), "0", 2) + " %";
				LabProgress.Text = ((num > 0.999999) ? "100 %" : text);
				LabSpeed.Text = ModBase.GetString(ModNet.NetManager.Speed) + "/s";
				LabFile.Text = Conversions.ToString((ModNet.NetManager.FileRemain < 0) ? "0*" : ((object)ModNet.NetManager.FileRemain));
				LabThread.Text = Conversions.ToString(ModNet.NetTaskThreadCount) + " / " + Conversions.ToString(ModNet.NetTaskThreadLimit);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "任务管理左栏监视出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
		if (ModMain.FrmSpeedRight == null || ModMain.FrmSpeedRight.PanMain == null)
		{
			return;
		}
		try
		{
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModLoader.LoaderBase current = enumerator.Current;
					TaskRefresh(current);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			ModBase.Log(ex4, "任务管理右栏监视出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public void TaskRefresh(ModLoader.LoaderBase Loader)
	{
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0567: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected O, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_037e: Expected O, but got Unknown
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Expected O, but got Unknown
		//IL_07ff: Unknown result type (might be due to invalid IL or missing references)
		_Closure_0024__6_002D1 arg = new _Closure_0024__6_002D1(null);
		arg._0024VB_0024Me = this;
		arg._0024VB_0024Local_Loader = Loader;
		if (arg._0024VB_0024Local_Loader == null || !arg._0024VB_0024Local_Loader.Show)
		{
			return;
		}
		checked
		{
			try
			{
				List<ModLoader.LoaderBase> val = (List<ModLoader.LoaderBase>)NewLateBinding.LateGet((object)arg._0024VB_0024Local_Loader, (System.Type)null, "GetLoaderList", new object[0], (string[])null, (System.Type[])null, (bool[])null);
				if (RightCards.ContainsKey(arg._0024VB_0024Local_Loader.Name))
				{
					Grid val2 = (Grid)(object)RightCards[arg._0024VB_0024Local_Loader.Name];
					double num = arg._0024VB_0024Local_Loader.Progress + (double)arg._0024VB_0024Local_Loader.State;
					if (ModBase.Val(RuntimeHelpers.GetObjectValue(((FrameworkElement)val2).Tag)) == num)
					{
						return;
					}
					((FrameworkElement)val2).Tag = num;
					if (((Panel)val2).Children.Count > 3)
					{
						val2 = (Grid)((Panel)val2).Children[3];
						try
						{
							switch (arg._0024VB_0024Local_Loader.State)
							{
							case ModBase.LoadState.Failed:
							{
								val2.RowDefinitions.Clear();
								((Panel)val2).Children.Clear();
								((Panel)val2).Children.Add((UIElement)ModBase.GetObjectFromXML("<Path xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Stretch=\"Uniform\" Tag=\"Failed\" Data=\"F1 M2.5,0 L0,2.5 7.5,10 0,17.5 2.5,20 10,12.5 17.5,20 20,17.5 12.5,10 20,2.5 17.5,0 10,7.5 2.5,0Z\" Height=\"15\" Width=\"15\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"0\" Fill=\"{DynamicResource ColorBrush3}\" Margin=\"0,1,0,0\" VerticalAlignment=\"Top\"/>"));
								TextBlock val3 = (TextBlock)ModBase.GetObjectFromXML("<TextBlock xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" TextWrapping=\"Wrap\" HorizontalAlignment=\"Left\" ToolTip=\"单击复制错误详情\" Grid.Column=\"1\" Grid.Row=\"0\" Margin=\"0,0,0,5\" />");
								val3.Text = arg._0024VB_0024Local_Loader.Error.ToString();
								object obj;
								if (_Closure_0024__._0024IR6_002D2 != null)
								{
									obj = _Closure_0024__._0024IR6_002D2;
								}
								else
								{
									MouseButtonEventHandler val4 = [SpecialName] (object a0, MouseButtonEventArgs a1) =>
									{
										//IL_0025: Unknown result type (might be due to invalid IL or missing references)
										//IL_0030: Expected O, but got Unknown
										((VB_0024AnonymousDelegate_1<TextBlock, EventArgs>)([SpecialName] (TextBlock sender, EventArgs e) =>
										{
											ModBase.ClipboardSet(sender.Text, ShowSuccessHint: false);
											ModMain.Hint("已复制错误详情！", ModMain.HintType.Finish);
										}))((TextBlock)a0, (EventArgs)(object)a1);
									};
									_Closure_0024__._0024IR6_002D2 = val4;
									obj = (object)val4;
								}
								((UIElement)val3).MouseLeftButtonDown += (MouseButtonEventHandler)obj;
								((Panel)val2).Children.Add((UIElement)(object)val3);
								break;
							}
							case ModBase.LoadState.Finished:
								ModAnimation.AniDispose((MyCard)(object)((FrameworkElement)val2).Parent, RemoveFromChildren: true, (ParameterizedThreadStart)([SpecialName] [CompilerGenerated] (object a0) =>
								{
									TryReturnToHome();
								}));
								break;
							case ModBase.LoadState.Waiting:
							case ModBase.LoadState.Loading:
								try
								{
									if (((Panel)val2).Children.Count < val.Count * 2)
									{
										ModBase.Log($"[Watcher] 刷新任务管理卡片 {arg._0024VB_0024Local_Loader.Name} 失败：卡片中仅有 {((Panel)val2).Children.Count} 个子项，要求至少有 {val.Count * 2} 个子项", ModBase.LogLevel.Debug);
										break;
									}
									int num2 = 0;
									System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
									try
									{
										enumerator = val.GetEnumerator();
										while (enumerator.MoveNext())
										{
											ModLoader.LoaderBase current = enumerator.Current;
											switch (current.State)
											{
											case ModBase.LoadState.Waiting:
												if (Operators.ConditionalCompareObjectNotEqual(((FrameworkElement)((Panel)val2).Children[num2 * 2]).Tag, (object)"Waiting", false))
												{
													((Panel)val2).Children.RemoveAt(num2 * 2);
													((Panel)val2).Children.Insert(num2 * 2, (UIElement)ModBase.GetObjectFromXML("<Path xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:PCL;assembly=Plain Craft Launcher 2\" Stretch=\"Uniform\" Tag=\"Waiting\" Data=\"F1 M5,0 a5,5 360 1 0 0,0.0001 m15,0 a5,5 360 1 0 0,0.0001 m15,0 a5,5 360 1 0 0,0.0001 Z\" Width=\"18\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"" + Conversions.ToString(num2) + "\" Fill=\"{DynamicResource ColorBrush3}\" Margin=\"0,7,0,0\" VerticalAlignment=\"Top\" Height=\"6\"/>"));
												}
												break;
											case ModBase.LoadState.Loading:
												if (Operators.ConditionalCompareObjectNotEqual(((FrameworkElement)((Panel)val2).Children[num2 * 2]).Tag, (object)"Loading", false))
												{
													((Panel)val2).Children.RemoveAt(num2 * 2);
													((Panel)val2).Children.Insert(num2 * 2, (UIElement)ModBase.GetObjectFromXML(string.Concat(new string[5]
													{
														"<TextBlock xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:PCL;assembly=Plain Craft Launcher 2\" Text=\"",
														Conversions.ToString(Math.Floor(current.Progress * 100.0)),
														"%\" Tag=\"Loading\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"",
														Conversions.ToString(num2),
														"\" Foreground=\"{DynamicResource ColorBrush3}\"/>"
													})));
												}
												else
												{
													((TextBlock)((Panel)val2).Children[num2 * 2]).Text = Conversions.ToString(Math.Floor(current.Progress * 100.0)) + "%";
												}
												break;
											case ModBase.LoadState.Finished:
												if (Operators.ConditionalCompareObjectNotEqual(((FrameworkElement)((Panel)val2).Children[num2 * 2]).Tag, (object)"Finished", false))
												{
													((Panel)val2).Children.RemoveAt(num2 * 2);
													((Panel)val2).Children.Insert(num2 * 2, (UIElement)ModBase.GetObjectFromXML("<Path xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:PCL;assembly=Plain Craft Launcher 2\" Stretch=\"Uniform\" Tag=\"Finished\" Data=\"F1 M 23.7501,33.25L 34.8334,44.3333L 52.2499,22.1668L 56.9999,26.9168L 34.8334,53.8333L 19.0001,38L 23.7501,33.25 Z\" Height=\"16\" Width=\"15\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"" + Conversions.ToString(num2) + "\" Fill=\"{DynamicResource ColorBrush3}\" Margin=\"0,3,0,0\" VerticalAlignment=\"Top\"/>"));
												}
												break;
											}
											num2++;
										}
										break;
									}
									finally
									{
										((System.IDisposable)enumerator).Dispose();
									}
								}
								catch (System.Exception ex)
								{
									ProjectData.SetProjectError(ex);
									System.Exception ex2 = ex;
									ModBase.Log(ex2, $"刷新任务管理卡片 {arg._0024VB_0024Local_Loader.Name} 失败", ModBase.LogLevel.Feedback);
									ProjectData.ClearProjectError();
									break;
								}
							}
							return;
						}
						catch (System.Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							System.Exception ex4 = ex3;
							ModBase.Log(ex4, "更新任务管理显示失败（" + ((System.Enum)arg._0024VB_0024Local_Loader.State).ToString() + "）", ModBase.LogLevel.Feedback);
							ProjectData.ClearProjectError();
							return;
						}
					}
					ModBase.Log("[Watcher] 元素不足的卡片：" + arg._0024VB_0024Local_Loader.Name, ModBase.LogLevel.Debug);
				}
				else
				{
					if (arg._0024VB_0024Local_Loader.State == ModBase.LoadState.Aborted || arg._0024VB_0024Local_Loader.State == ModBase.LoadState.Finished)
					{
						return;
					}
					try
					{
						_Closure_0024__6_002D0 arg2 = default(_Closure_0024__6_002D0);
						_Closure_0024__6_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__6_002D0(null);
						CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2 = arg;
						string text = string.Concat(new string[5]
						{
							"\n                        <local:MyCard xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:PCL;assembly=Plain Craft Launcher 2\"\n                            Tag=\"",
							Conversions.ToString(CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Loader.Progress + (double)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Loader.State),
							"\" Title=\"",
							ModBase.EscapeXML(CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Loader.Name),
							"\" Margin=\"0,0,0,15\">\n                            <Grid Margin=\"14,40,15,10\">\n                                <Grid.ColumnDefinitions>\n                                    <ColumnDefinition Width=\"50\"/>\n                                    <ColumnDefinition/>\n                                </Grid.ColumnDefinitions>\n                                <Grid.RowDefinitions>"
						});
						System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator2 = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
						try
						{
							enumerator2 = val.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								_ = enumerator2.Current;
								text += "<RowDefinition Height=\"26\"/>";
							}
						}
						finally
						{
							((System.IDisposable)enumerator2).Dispose();
						}
						text += "</Grid.RowDefinitions>";
						int num3 = 0;
						System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator3 = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
						try
						{
							enumerator3 = val.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								ModLoader.LoaderBase current2 = enumerator3.Current;
								text = current2.State switch
								{
									ModBase.LoadState.Waiting => text + "<Path Stretch=\"Uniform\" Tag=\"Waiting\" Data=\"F1 M5,0 a5,5 360 1 0 0,0.0001 m15,0 a5,5 360 1 0 0,0.0001 m15,0 a5,5 360 1 0 0,0.0001 Z\" Width=\"18\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"" + Conversions.ToString(num3) + "\" Fill=\"{DynamicResource ColorBrush3}\" Margin=\"0,7,0,0\" VerticalAlignment=\"Top\" Height=\"6\"/>", 
									ModBase.LoadState.Loading => string.Concat(new string[6]
									{
										text,
										"<TextBlock Text=\"",
										Conversions.ToString(Math.Floor(current2.Progress * 100.0)),
										"%\" Tag=\"Loading\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"",
										Conversions.ToString(num3),
										"\" Foreground=\"{DynamicResource ColorBrush3}\" />"
									}), 
									ModBase.LoadState.Finished => text + "<Path Stretch=\"Uniform\" Tag=\"Finished\" Data=\"F1 M 23.7501,33.25L 34.8334,44.3333L 52.2499,22.1668L 56.9999,26.9168L 34.8334,53.8333L 19.0001,38L 23.7501,33.25 Z\" Height=\"16\" Width=\"15\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"" + Conversions.ToString(num3) + "\" Fill=\"{DynamicResource ColorBrush3}\" Margin=\"0,3,0,0\" VerticalAlignment=\"Top\"/>", 
									_ => text + "<Path Stretch=\"Uniform\" Tag=\"Failed\" Data=\"F1 M2.5,0 L0,2.5 7.5,10 0,17.5 2.5,20 10,12.5 17.5,20 20,17.5 12.5,10 20,2.5 17.5,0 10,7.5 2.5,0Z\" Height=\"15\" Width=\"15\" HorizontalAlignment=\"Center\" Grid.Column=\"0\" Grid.Row=\"" + Conversions.ToString(num3) + "\" Fill=\"{DynamicResource ColorBrush3}\" Margin=\"0,1,0,0\" VerticalAlignment=\"Top\"/>", 
								};
								text = string.Concat(new string[6]
								{
									text,
									"<TextBlock Text=\"",
									ModBase.EscapeXML(current2.Name),
									"\" HorizontalAlignment=\"Left\" Grid.Column=\"1\" Grid.Row=\"",
									Conversions.ToString(num3),
									"\"/>"
								});
								num3++;
							}
						}
						finally
						{
							((System.IDisposable)enumerator3).Dispose();
						}
						text += "</Grid></local:MyCard>";
						try
						{
							CS_0024_003C_003E8__locals0._0024VB_0024Local_Card = (MyCard)ModBase.GetObjectFromXML(text);
						}
						catch (System.Exception ex5)
						{
							ProjectData.SetProjectError(ex5);
							System.Exception ex6 = ex5;
							ModBase.Log(ex6, "新建任务管理卡片失败");
							ModBase.Log("出错的卡片内容：\r\n" + text);
							throw;
						}
						((Panel)ModMain.FrmSpeedRight.PanMain).Children.Insert(0, (UIElement)(object)CS_0024_003C_003E8__locals0._0024VB_0024Local_Card);
						RightCards.Add(CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Loader.Name, CS_0024_003C_003E8__locals0._0024VB_0024Local_Card);
						ModBase.Log($"[Watcher] 新建任务管理卡片：{CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Loader.Name}");
						MyIconButton myIconButton = new MyIconButton();
						((FrameworkElement)myIconButton).Name = "BtnCancel";
						myIconButton.Logo = "F1 M2,0 L0,2 8,10 0,18 2,20 10,12 18,20 20,18 12,10 20,2 18,0 10,8 2,0Z";
						((FrameworkElement)myIconButton).Height = 20.0;
						((FrameworkElement)myIconButton).Margin = new Thickness(0.0, 10.0, 10.0, 0.0);
						myIconButton.LogoScale = 1.1;
						((FrameworkElement)myIconButton).HorizontalAlignment = (HorizontalAlignment)2;
						((FrameworkElement)myIconButton).VerticalAlignment = (VerticalAlignment)0;
						MyIconButton myIconButton2 = myIconButton;
						((Panel)CS_0024_003C_003E8__locals0._0024VB_0024Local_Card).Children.Add((UIElement)(object)myIconButton2);
						myIconButton2.Click += [SpecialName] (object a0, EventArgs a1) =>
						{
							CS_0024_003C_003E8__locals0._Lambda_0024__1((MyIconButton)a0, a1);
						};
						if (CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Loader.State == ModBase.LoadState.Failed)
						{
							((FrameworkElement)CS_0024_003C_003E8__locals0._0024VB_0024Local_Card).Tag = null;
							TaskRefresh(CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Loader);
						}
						return;
					}
					catch (System.Exception ex7)
					{
						ProjectData.SetProjectError(ex7);
						System.Exception ex8 = ex7;
						ModBase.Log(ex8, "添加任务管理卡片失败", ModBase.LogLevel.Feedback);
						ProjectData.ClearProjectError();
						return;
					}
				}
			}
			catch (System.Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				System.Exception ex10 = ex9;
				ModBase.Log(ex10, "刷新任务管理显示失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void TaskRemove(object Loader)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		if (RightCards.ContainsKey(Conversions.ToString(NewLateBinding.LateGet(Loader, (System.Type)null, "Name", new object[0], (string[])null, (System.Type[])null, (bool[])null))))
		{
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				Grid val = (Grid)(object)RightCards[Conversions.ToString(NewLateBinding.LateGet(Loader, (System.Type)null, "Name", new object[0], (string[])null, (System.Type[])null, (bool[])null))];
				((Panel)ModMain.FrmSpeedRight.PanMain).Children.Remove((UIElement)(object)val);
				RightCards.Remove(Conversions.ToString(NewLateBinding.LateGet(Loader, (System.Type)null, "Name", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
				ModBase.Log(string.Format("[Watcher] 移除任务管理卡片：{0}", RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(Loader, (System.Type)null, "Name", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
			}));
		}
	}

	private void TryReturnToHome()
	{
		if (((Panel)ModMain.FrmSpeedRight.PanMain).Children.Count == 0 && ModMain.FrmMain.PageCurrent == FormMain.PageType.TaskManager)
		{
			ModMain.FrmMain.PageBack();
		}
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagespeedleft.xaml", (UriKind)2);
			Application.LoadComponent((object)this, val);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	internal System.Delegate _CreateDelegate(System.Type delegateType, string handler)
	{
		return System.Delegate.CreateDelegate(delegateType, (object)this, handler);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	[EditorBrowsable(/*Could not decode attribute arguments.*/)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			LabProgress = (TextBlock)target;
			break;
		case 2:
			LabSpeed = (TextBlock)target;
			break;
		case 3:
			LabFile = (TextBlock)target;
			break;
		case 4:
			LabThread = (TextBlock)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
