using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using SearchOption = System.IO.SearchOption;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using FileSystem = Microsoft.VisualBasic.FileIO.FileSystem;
using PCL.Core.App;

namespace PCL;

[DesignerGenerated]
public class PageInstanceScreenshot : MyPageRight, IRefreshable, IComponentConnector
{
	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_10_RequireAppend : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal PageInstanceScreenshot _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num == 0)
				{
					num = (_0024State = -1);
					val = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_00a9;
				}
				if (!_0024VB_0024Me._AppendLock && ((ScrollViewer)_0024VB_0024Me.PanBack).VerticalOffset + ((ScrollViewer)_0024VB_0024Me.PanBack).ViewportHeight >= ((ScrollViewer)_0024VB_0024Me.PanBack).ExtentHeight)
				{
					val = _0024VB_0024Me.ListAppend().GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_10_RequireAppend>(ref val, ref _this);
						return;
					}
					goto IL_00a9;
				}
				goto end_IL_0007;
				IL_00a9:
				val.GetResult();
				val = default(TaskAwaiter);
				end_IL_0007:;
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

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_13_ListAppend : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal int _0024VB_0024Local_Count;

		internal int _0024VB_0024Local_Offset;

		internal PageInstanceScreenshot _0024VB_0024Me;

		internal Image _0024VB_0024ResumableLocal_image_00240;

		internal _Closure_0024__13_002D0 _0024VB_0024ResumableLocal__0024VB_0024Closure__00241;

		internal Grid _0024VB_0024ResumableLocal_grid_00242;

		internal MyCard _0024VB_0024ResumableLocal_myCard_00243;

		internal int _0024VB_0024ResumableLocal_j_00244;

		internal int _0024S5;

		internal TaskAwaiter<BitmapImage> _0024A0;

		internal Image _0024U1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0307: Unknown result type (might be due to invalid IL or missing references)
			//IL_030c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0314: Unknown result type (might be due to invalid IL or missing references)
			//IL_0329: Unknown result type (might be due to invalid IL or missing references)
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_0373: Expected O, but got Unknown
			//IL_0396: Unknown result type (might be due to invalid IL or missing references)
			//IL_039c: Expected O, but got Unknown
			//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Expected O, but got Unknown
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_025e: Expected O, but got Unknown
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0278: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Expected O, but got Unknown
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_029c: Expected O, but got Unknown
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Expected O, but got Unknown
			//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			checked
			{
				try
				{
					if (num == -3 || num == 0)
					{
						goto IL_012a;
					}
					_0024VB_0024Me._AppendLock = true;
					if (_0024VB_0024Local_Offset != -1)
					{
						_0024VB_0024Me._Offset = _0024VB_0024Local_Offset;
						goto IL_0089;
					}
					if (_0024VB_0024Me._Offset * _0024VB_0024Local_Count <= _0024VB_0024Me.FileList.Count)
					{
						_0024VB_0024Local_Offset = _0024VB_0024Me._Offset + 1;
						_0024VB_0024Me._Offset++;
						goto IL_0089;
					}
					goto end_IL_0007;
					IL_0089:
					if (_0024VB_0024Local_Count * _0024VB_0024Local_Offset <= _0024VB_0024Me.FileList.Count)
					{
						int num2 = _0024VB_0024Local_Count * _0024VB_0024Local_Offset;
						_0024S5 = _0024VB_0024Local_Count * (_0024VB_0024Local_Offset + 1) - 1;
						_0024VB_0024ResumableLocal_j_00244 = num2;
						goto IL_05e1;
					}
					goto end_IL_0007;
					IL_05e1:
					if (_0024VB_0024ResumableLocal_j_00244 <= _0024S5)
					{
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00241 = new _Closure_0024__13_002D0(_0024VB_0024ResumableLocal__0024VB_0024Closure__00241);
						if (_0024VB_0024ResumableLocal_j_00244 < _0024VB_0024Me.FileList.Count)
						{
							_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_i = Enumerable.ElementAt<string>((System.Collections.Generic.IEnumerable<string>)_0024VB_0024Me.FileList, _0024VB_0024ResumableLocal_j_00244);
							goto IL_012a;
						}
					}
					_0024VB_0024Me._AppendLock = false;
					goto end_IL_0007;
					IL_012a:
					try
					{
						TaskAwaiter<BitmapImage> awaiter;
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return;
						default:
							if (File.Exists(_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_i) && !((System.Enum)File.GetAttributes(_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_i)).HasFlag((System.Enum)(object)(FileAttributes)2) && new FileInfo(_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_i).Length != 0L)
							{
								MyCard myCard = new MyCard();
								((FrameworkElement)myCard).Height = 0.0 / 0.0;
								((FrameworkElement)myCard).Width = 0.0 / 0.0;
								((FrameworkElement)myCard).Margin = new Thickness(7.0);
								((FrameworkElement)myCard).Tag = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_i;
								((FrameworkElement)myCard).ToolTip = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_i.Replace(_0024VB_0024Me.ScreenshotPath, "");
								_0024VB_0024ResumableLocal_myCard_00243 = myCard;
								_0024VB_0024ResumableLocal_grid_00242 = new Grid();
								((Panel)_0024VB_0024ResumableLocal_myCard_00243).Children.Add((UIElement)(object)_0024VB_0024ResumableLocal_grid_00242);
								_0024VB_0024ResumableLocal_grid_00242.RowDefinitions.Add(new RowDefinition
								{
									Height = new GridLength(9.0)
								});
								_0024VB_0024ResumableLocal_grid_00242.RowDefinitions.Add(new RowDefinition
								{
									Height = new GridLength(120.0)
								});
								_0024VB_0024ResumableLocal_grid_00242.RowDefinitions.Add(new RowDefinition());
								_0024VB_0024ResumableLocal_image_00240 = new Image();
								_0024U1 = _0024VB_0024ResumableLocal_image_00240;
								awaiter = System.Threading.Tasks.Task.Run<BitmapImage>((Func<BitmapImage>)([SpecialName] () =>
								{
									//IL_0000: Unknown result type (might be due to invalid IL or missing references)
									//IL_0006: Expected O, but got Unknown
									//IL_0010: Unknown result type (might be due to invalid IL or missing references)
									//IL_0016: Expected O, but got Unknown
									BitmapImage val2 = new BitmapImage();
									string _0024VB_0024Local_i = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_i;
									FileStream val3 = new FileStream(_0024VB_0024Local_i, (FileMode)3, (FileAccess)1);
									try
									{
										val2.BeginInit();
										val2.DecodePixelHeight = 200;
										val2.DecodePixelWidth = 400;
										val2.CacheOption = (BitmapCacheOption)1;
										val2.StreamSource = (Stream)(object)val3;
										val2.EndInit();
										((Freezable)val2).Freeze();
										return val2;
									}
									finally
									{
										((System.IDisposable)val3)?.Dispose();
									}
								})).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<BitmapImage>, VB_0024StateMachine_13_ListAppend>(ref awaiter, ref _this);
									return;
								}
								break;
							}
							goto end_IL_012a;
						case 0:
							num = (_0024State = -1);
							awaiter = _0024A0;
							_0024A0 = default(TaskAwaiter<BitmapImage>);
							break;
						}
						Image obj = _0024U1;
						BitmapImage result = awaiter.GetResult();
						awaiter = default(TaskAwaiter<BitmapImage>);
						obj.Source = (ImageSource)(object)result;
						_0024U1 = null;
						_0024VB_0024ResumableLocal_image_00240.Stretch = (Stretch)2;
						((FrameworkElement)_0024VB_0024ResumableLocal_image_00240).Cursor = Cursors.Hand;
						((UIElement)_0024VB_0024ResumableLocal_image_00240).MouseLeftButtonDown += (MouseButtonEventHandler)([SpecialName] (object sender, MouseButtonEventArgs e) =>
						{
							try
							{
								Basics.OpenPath(_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_i);
							}
							catch (System.Exception ex4)
							{
								ProjectData.SetProjectError(ex4);
								System.Exception ex5 = ex4;
								ModBase.Log(ex5, "打开截图失败！", ModBase.LogLevel.Hint);
								ProjectData.ClearProjectError();
							}
						});
						Grid.SetRow((UIElement)(object)_0024VB_0024ResumableLocal_image_00240, 1);
						((Panel)_0024VB_0024ResumableLocal_grid_00242).Children.Add((UIElement)(object)_0024VB_0024ResumableLocal_image_00240);
						StackPanel val = new StackPanel();
						val.Orientation = (Orientation)0;
						((FrameworkElement)val).HorizontalAlignment = (HorizontalAlignment)1;
						((FrameworkElement)val).Margin = new Thickness(3.0, 5.0, 3.0, 5.0);
						Grid.SetRow((UIElement)(object)val, 2);
						((Panel)_0024VB_0024ResumableLocal_grid_00242).Children.Add((UIElement)(object)val);
						MyIconTextButton myIconTextButton = new MyIconTextButton();
						((FrameworkElement)myIconTextButton).Name = "BtnOpen";
						myIconTextButton.Text = "打开";
						myIconTextButton.LogoScale = 0.8;
						myIconTextButton.Logo = "M889.018182 418.909091H884.363636V316.509091a93.090909 93.090909 0 0 0-99.607272-89.832727h-302.545455l-93.090909-76.334546A46.545455 46.545455 0 0 0 358.865455 139.636364H146.152727A93.090909 93.090909 0 0 0 46.545455 229.469091V837.818182a46.545455 46.545455 0 0 0 46.545454 46.545454 46.545455 46.545455 0 0 0 16.756364-3.258181 109.381818 109.381818 0 0 0 25.134545 3.258181h586.472727a85.178182 85.178182 0 0 0 87.04-63.301818l163.374546-302.545454a46.545455 46.545455 0 0 0 5.585454-21.876364A82.385455 82.385455 0 0 0 889.018182 418.909091z m-744.727273-186.181818h198.283636l93.09091 76.334545a46.545455 46.545455 0 0 0 29.323636 10.705455h319.301818a12.101818 12.101818 0 0 1 6.516364 0V418.909091H302.545455a85.178182 85.178182 0 0 0-87.04 63.301818L139.636364 622.778182V232.727273a19.549091 19.549091 0 0 1 6.516363 0z m578.094546 552.029091a27.461818 27.461818 0 0 0-2.792728 6.516363H154.530909l147.083636-272.290909a27.461818 27.461818 0 0 0 2.792728-6.981818h565.061818z";
						((FrameworkElement)myIconTextButton).Tag = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_i;
						MyIconTextButton myIconTextButton2 = myIconTextButton;
						myIconTextButton2.Click += [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
						{
							_0024VB_0024Me.btnOpen_Click((MyIconTextButton)a0, (EventArgs)(object)a1);
						};
						((Panel)val).Children.Add((UIElement)(object)myIconTextButton2);
						MyIconTextButton myIconTextButton3 = new MyIconTextButton();
						((FrameworkElement)myIconTextButton3).Name = "BtnDelete";
						myIconTextButton3.Text = "删除";
						myIconTextButton3.LogoScale = 0.8;
						myIconTextButton3.Logo = "M520.192 0C408.43 0 317.44 82.87 313.563 186.734H52.736c-29.038 0-52.663 21.943-52.663 49.079s23.625 49.152 52.663 49.152h58.075v550.473c0 103.35 75.118 187.757 167.717 187.757h472.43c92.599 0 167.716-83.894 167.716-187.757V285.477h52.59c29.038 0 52.59-21.943 52.663-49.08-0.073-27.135-23.625-49.151-52.663-49.151H726.235C723.237 83.017 631.955 0 520.192 0zM404.846 177.957c3.803-50.03 50.176-89.015 107.447-89.015 57.197 0 103.57 38.985 106.788 89.015H404.92zM284.379 933.669c-33.353 0-69.997-39.351-69.997-95.525v-549.01H833.39v549.522c0 56.247-36.645 95.525-69.998 95.525H284.379v-0.512z M357.23 800.695a48.274 48.274 0 0 0 47.616-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.69 49.006V751.69c0 27.282 20.846 49.006 47.617 49.006z m166.62 0a48.274 48.274 0 0 0 47.688-49.006V471.7a48.274 48.274 0 0 0-47.689-49.08 48.274 48.274 0 0 0-47.543 49.006V751.69c0 27.282 21.431 49.006 47.543 49.006z m142.92 0a48.274 48.274 0 0 0 47.543-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.616 49.006V751.69c0 27.282 20.773 49.006 47.543 49.006z";
						((FrameworkElement)myIconTextButton3).Tag = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_i;
						MyIconTextButton myIconTextButton4 = myIconTextButton3;
						myIconTextButton4.Click += [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
						{
							_0024VB_0024Me.btnDelete_Click((MyIconTextButton)a0, (EventArgs)(object)a1);
						};
						((Panel)val).Children.Add((UIElement)(object)myIconTextButton4);
						MyIconTextButton myIconTextButton5 = new MyIconTextButton();
						((FrameworkElement)myIconTextButton5).Name = "BtnCopy";
						myIconTextButton5.Text = "复制";
						myIconTextButton5.LogoScale = 0.8;
						myIconTextButton5.Logo = "M394.666667 106.666667h448a74.666667 74.666667 0 0 1 74.666666 74.666666v448a74.666667 74.666667 0 0 1-74.666666 74.666667H394.666667a74.666667 74.666667 0 0 1-74.666667-74.666667V181.333333a74.666667 74.666667 0 0 1 74.666667-74.666666z m0 64a10.666667 10.666667 0 0 0-10.666667 10.666666v448a10.666667 10.666667 0 0 0 10.666667 10.666667h448a10.666667 10.666667 0 0 0 10.666666-10.666667V181.333333a10.666667 10.666667 0 0 0-10.666666-10.666666H394.666667z m245.333333 597.333333a32 32 0 0 1 64 0v74.666667a74.666667 74.666667 0 0 1-74.666667 74.666666H181.333333a74.666667 74.666667 0 0 1-74.666666-74.666666V394.666667a74.666667 74.666667 0 0 1 74.666666-74.666667h74.666667a32 32 0 0 1 0 64h-74.666667a10.666667 10.666667 0 0 0-10.666666 10.666667v448a10.666667 10.666667 0 0 0 10.666666 10.666666h448a10.666667 10.666667 0 0 0 10.666667-10.666666v-74.666667z";
						((FrameworkElement)myIconTextButton5).Tag = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_i;
						MyIconTextButton myIconTextButton6 = myIconTextButton5;
						myIconTextButton6.Click += [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
						{
							_0024VB_0024Me.btnCopy_Click((MyIconTextButton)a0, (EventArgs)(object)a1);
						};
						((Panel)val).Children.Add((UIElement)(object)myIconTextButton6);
						((Panel)_0024VB_0024Me.PanList).Children.Add((UIElement)(object)_0024VB_0024ResumableLocal_myCard_00243);
						((UIElement)_0024VB_0024ResumableLocal_myCard_00243).Opacity = 0.0;
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[] { ModAnimation.AaOpacity(_0024VB_0024ResumableLocal_myCard_00243, 1.0, 200) });
						end_IL_012a:;
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, $"[Screenshot] 创建 {_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_i} 截图预览失败，图像可能损坏");
						ProjectData.ClearProjectError();
					}
					_0024VB_0024ResumableLocal_j_00244++;
					goto IL_05e1;
					end_IL_0007:;
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception exception = ex3;
					_0024State = -2;
					_0024Builder.SetException(exception);
					ProjectData.ClearProjectError();
					return;
				}
				num = (_0024State = -2);
				_0024Builder.SetResult();
			}
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_2_Refresh : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num != 0)
				{
					if (ModMain.FrmInstanceScreenshot == null)
					{
						goto IL_0078;
					}
					val = ModMain.FrmInstanceScreenshot.Reload().GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_2_Refresh>(ref val, ref _this);
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
				goto IL_0078;
				IL_0078:
				ModMain.FrmInstanceLeft.ItemScreenshot.Checked = true;
				ModMain.Hint("正在刷新……", ModMain.HintType.Info, Log: false);
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

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_4_PageSetupLaunch_Loaded : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal RoutedEventArgs _0024VB_0024Local_e;

		internal PageInstanceScreenshot _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num != 0)
				{
					((ScrollViewer)_0024VB_0024Me.PanBack).ScrollToHome();
					_0024VB_0024Me.ScreenshotPath = PageInstanceLeft.Instance.PathIndie + "screenshots\\";
					if (!Directory.Exists(_0024VB_0024Me.ScreenshotPath))
					{
						Directory.CreateDirectory(_0024VB_0024Me.ScreenshotPath);
					}
					val = _0024VB_0024Me.Reload().GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_4_PageSetupLaunch_Loaded>(ref val, ref _this);
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
				if (!_0024VB_0024Me.IsLoad)
				{
					_0024VB_0024Me.IsLoad = true;
				}
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

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_7_Reload : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal PageInstanceScreenshot _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			checked
			{
				try
				{
					TaskAwaiter val;
					if (num != 0)
					{
						ModAnimation.AniControlEnabled++;
						((ScrollViewer)_0024VB_0024Me.PanBack).ScrollToHome();
						val = _0024VB_0024Me.LoadFileList().GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_7_Reload>(ref val, ref _this);
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
					ModAnimation.AniControlEnabled--;
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
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_9_LoadFileList : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal PageInstanceScreenshot _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num == 0)
				{
					num = (_0024State = -1);
					val = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_0206;
				}
				_Closure_0024__9_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__9_002D0();
				ModBase.Log("[Screenshot] 刷新截图文件");
				_0024VB_0024Me.FileList.Clear();
				if (Directory.Exists(_0024VB_0024Me.ScreenshotPath))
				{
					_0024VB_0024Me.FileList = Enumerable.ToList<string>(Directory.EnumerateFiles(_0024VB_0024Me.ScreenshotPath, "*", (SearchOption)0));
				}
				CS_0024_003C_003E8__locals0._0024VB_0024Local_AllowedSuffix = new string[] { ".png", ".jpg", ".jpeg", ".bmp", ".webp", ".tiff" };
				_0024VB_0024Me.FileList = Enumerable.ToList<string>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)_0024VB_0024Me.FileList, (Func<string, bool>)([SpecialName] (string e) => Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0._0024VB_0024Local_AllowedSuffix, ((FileSystemInfo)new FileInfo(e)).Extension.ToLower()))));
				((Panel)_0024VB_0024Me.PanList).Children.Clear();
				_0024VB_0024Me.RefreshTip();
				_0024VB_0024Me.FileList = Enumerable.ToList<string>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)_0024VB_0024Me.FileList, (Func<string, bool>)([SpecialName] (string e) => !ModBase.ContainsF(e, "\\debug\\"))));
				ModBase.Sort((System.Collections.Generic.IList<string>)_0024VB_0024Me.FileList, [SpecialName] (string a, string b) => System.DateTime.Compare(((FileSystemInfo)new FileInfo(a)).CreationTime, ((FileSystemInfo)new FileInfo(b)).CreationTime) > 0);
				ModBase.Log("[Screenshot] 共发现 " + Conversions.ToString(_0024VB_0024Me.FileList.Count) + " 个截图文件");
				if (_0024VB_0024Me.FileList.Count != 0)
				{
					val = _0024VB_0024Me.ListAppend(20, 0).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_9_LoadFileList>(ref val, ref _this);
						return;
					}
					goto IL_0206;
				}
				goto end_IL_0007;
				IL_0206:
				val.GetResult();
				val = default(TaskAwaiter);
				end_IL_0007:;
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

	[CompilerGenerated]
	internal sealed class _Closure_0024__13_002D0
	{
		public string _0024VB_0024Local_i;

		public _Closure_0024__13_002D0(_Closure_0024__13_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_i = arg0._0024VB_0024Local_i;
			}
		}

		[SpecialName]
		internal BitmapImage _Lambda_0024__0()
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Expected O, but got Unknown
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			BitmapImage val = new BitmapImage();
			string text = _0024VB_0024Local_i;
			FileStream val2 = new FileStream(text, (FileMode)3, (FileAccess)1);
			try
			{
				val.BeginInit();
				val.DecodePixelHeight = 200;
				val.DecodePixelWidth = 400;
				val.CacheOption = (BitmapCacheOption)1;
				val.StreamSource = (Stream)(object)val2;
				val.EndInit();
				((Freezable)val).Freeze();
				return val;
			}
			finally
			{
				((System.IDisposable)val2)?.Dispose();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1(object sender, MouseButtonEventArgs e)
		{
			try
			{
				Basics.OpenPath(_0024VB_0024Local_i);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "打开截图失败！", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__9_002D0
	{
		public string[] _0024VB_0024Local_AllowedSuffix;

		[SpecialName]
		internal bool _Lambda_0024__0(string e)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)_0024VB_0024Local_AllowedSuffix, ((FileSystemInfo)new FileInfo(e)).Extension.ToLower());
		}
	}

	private bool IsLoad;

	private List<string> FileList;

	private string ScreenshotPath;

	private bool _AppendLock;

	private int _Offset;

	[CompilerGenerated]
	[AccessedThroughProperty("PanBack")]
	private MyScrollViewer _PanBack;

	private bool _contentLoaded;

	internal virtual MyScrollViewer PanBack
	{
		[CompilerGenerated]
		get
		{
			return _PanBack;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			ScrollChangedEventHandler val = (ScrollChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, ScrollChangedEventArgs a1) =>
			{
				RequireAppend();
			});
			MyScrollViewer panBack = _PanBack;
			if (panBack != null)
			{
				((ScrollViewer)panBack).ScrollChanged -= val;
			}
			_PanBack = value;
			panBack = _PanBack;
			if (panBack != null)
			{
				((ScrollViewer)panBack).ScrollChanged += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanNoPic")]
	internal virtual MyCard PanNoPic
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanContent")]
	internal virtual StackPanel PanContent
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanList")]
	internal virtual WrapPanel PanList
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageInstanceScreenshot()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageSetupLaunch_Loaded);
		IsLoad = false;
		FileList = new List<string>();
		_AppendLock = false;
		_Offset = 0;
		InitializeComponent();
	}

	private void RefreshSelf()
	{
		Refresh();
	}

	void IRefreshable.Refresh()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RefreshSelf
		this.RefreshSelf();
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_2_Refresh))]
	public static void Refresh()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_2_Refresh vB_0024StateMachine_2_Refresh = default(VB_0024StateMachine_2_Refresh);
		vB_0024StateMachine_2_Refresh._0024State = -1;
		vB_0024StateMachine_2_Refresh._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_2_Refresh._0024Builder.Start<VB_0024StateMachine_2_Refresh>(ref vB_0024StateMachine_2_Refresh);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_4_PageSetupLaunch_Loaded))]
	private void PageSetupLaunch_Loaded(object sender, RoutedEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_4_PageSetupLaunch_Loaded vB_0024StateMachine_4_PageSetupLaunch_Loaded = default(VB_0024StateMachine_4_PageSetupLaunch_Loaded);
		vB_0024StateMachine_4_PageSetupLaunch_Loaded._0024VB_0024Me = this;
		vB_0024StateMachine_4_PageSetupLaunch_Loaded._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_4_PageSetupLaunch_Loaded._0024VB_0024Local_e = e;
		vB_0024StateMachine_4_PageSetupLaunch_Loaded._0024State = -1;
		vB_0024StateMachine_4_PageSetupLaunch_Loaded._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_4_PageSetupLaunch_Loaded._0024Builder.Start<VB_0024StateMachine_4_PageSetupLaunch_Loaded>(ref vB_0024StateMachine_4_PageSetupLaunch_Loaded);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_7_Reload))]
	public System.Threading.Tasks.Task Reload()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_7_Reload vB_0024StateMachine_7_Reload = default(VB_0024StateMachine_7_Reload);
		vB_0024StateMachine_7_Reload._0024VB_0024Me = this;
		vB_0024StateMachine_7_Reload._0024State = -1;
		vB_0024StateMachine_7_Reload._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_7_Reload._0024Builder.Start<VB_0024StateMachine_7_Reload>(ref vB_0024StateMachine_7_Reload);
		return vB_0024StateMachine_7_Reload._0024Builder.Task;
	}

	private void RefreshTip()
	{
		if (FileList.Count.Equals(0))
		{
			((UIElement)PanNoPic).Visibility = (Visibility)0;
			((UIElement)PanContent).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)PanNoPic).Visibility = (Visibility)2;
			((UIElement)PanContent).Visibility = (Visibility)0;
		}
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_9_LoadFileList))]
	private System.Threading.Tasks.Task LoadFileList()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_9_LoadFileList vB_0024StateMachine_9_LoadFileList = default(VB_0024StateMachine_9_LoadFileList);
		vB_0024StateMachine_9_LoadFileList._0024VB_0024Me = this;
		vB_0024StateMachine_9_LoadFileList._0024State = -1;
		vB_0024StateMachine_9_LoadFileList._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_9_LoadFileList._0024Builder.Start<VB_0024StateMachine_9_LoadFileList>(ref vB_0024StateMachine_9_LoadFileList);
		return vB_0024StateMachine_9_LoadFileList._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_10_RequireAppend))]
	private void RequireAppend()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_10_RequireAppend vB_0024StateMachine_10_RequireAppend = default(VB_0024StateMachine_10_RequireAppend);
		vB_0024StateMachine_10_RequireAppend._0024VB_0024Me = this;
		vB_0024StateMachine_10_RequireAppend._0024State = -1;
		vB_0024StateMachine_10_RequireAppend._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_10_RequireAppend._0024Builder.Start<VB_0024StateMachine_10_RequireAppend>(ref vB_0024StateMachine_10_RequireAppend);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_13_ListAppend))]
	private System.Threading.Tasks.Task ListAppend(int Count = 20, int Offset = -1)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_13_ListAppend vB_0024StateMachine_13_ListAppend = default(VB_0024StateMachine_13_ListAppend);
		vB_0024StateMachine_13_ListAppend._0024VB_0024Me = this;
		vB_0024StateMachine_13_ListAppend._0024VB_0024Local_Count = Count;
		vB_0024StateMachine_13_ListAppend._0024VB_0024Local_Offset = Offset;
		vB_0024StateMachine_13_ListAppend._0024State = -1;
		vB_0024StateMachine_13_ListAppend._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_13_ListAppend._0024Builder.Start<VB_0024StateMachine_13_ListAppend>(ref vB_0024StateMachine_13_ListAppend);
		return vB_0024StateMachine_13_ListAppend._0024Builder.Task;
	}

	private void RemoveItem(string Path)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		try
		{
			foreach (object child in ((Panel)PanList).Children)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(child);
				if (((FrameworkElement)(MyCard)objectValue).Tag.Equals((object)Path))
				{
					((Panel)PanList).Children.Remove((UIElement)objectValue);
					break;
				}
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "未能找到对应 UI");
			ProjectData.ClearProjectError();
		}
	}

	private string GetPathFromSender(MyIconTextButton sender)
	{
		return Conversions.ToString(((FrameworkElement)sender).Tag);
	}

	private void btnOpen_Click(MyIconTextButton sender, EventArgs e)
	{
		ModBase.OpenExplorer(GetPathFromSender(sender));
	}

	private void btnDelete_Click(MyIconTextButton sender, EventArgs e)
	{
		string pathFromSender = GetPathFromSender(sender);
		RemoveItem(pathFromSender);
		try
		{
			FileSystem.DeleteFile(pathFromSender, (UIOption)2, (RecycleOption)3);
			ModMain.Hint("已将截图移至回收站！");
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "删除截图失败！", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private void btnCopy_Click(MyIconTextButton sender, EventArgs e)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		string pathFromSender = GetPathFromSender(sender);
		if (File.Exists(pathFromSender))
		{
			int num = 0;
			while (num <= 5)
			{
				try
				{
					ModBase.Log("[Screenshot] 尝试复制" + pathFromSender + "到剪贴板");
					Clipboard.SetImage((BitmapSource)new BitmapImage(new Uri(pathFromSender)));
					ModMain.Hint("已复制截图到剪贴板！");
					num = 6;
					return;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					num = checked(num + 1);
					ModBase.Log(ex2, $"[Screenshot]第 {num} 次复制尝试失败");
					ProjectData.ClearProjectError();
				}
			}
			ModMain.Hint("截图复制失败！", ModMain.HintType.Critical);
		}
		else
		{
			ModMain.Hint("截图文件不存在！");
		}
	}

	private void BtnOpenFolder_Click(object sender, MouseButtonEventArgs e)
	{
		if (!Directory.Exists(ScreenshotPath))
		{
			Directory.CreateDirectory(ScreenshotPath);
		}
		ModBase.OpenExplorer(ScreenshotPath);
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/pageinstancescreenshot.xaml", (UriKind)2);
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanNoPic = (MyCard)target;
			break;
		case 3:
			PanContent = (StackPanel)target;
			break;
		case 4:
			PanList = (WrapPanel)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
