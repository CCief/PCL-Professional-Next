using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PCL;

[DesignerGenerated]
public class MyAuthWindow : Window, IComponentConnector
{
	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_24_CheckWebView2Runtime : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal RoutedEventArgs _0024VB_0024Local_e;

		internal MyAuthWindow _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Expected O, but got Unknown
			//IL_0065: Expected O, but got Unknown
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num == 0)
				{
					num = (_0024State = -1);
					val = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_01d5;
				}
				((FrameworkElement)_0024VB_0024Me).Loaded -= new RoutedEventHandler(_0024VB_0024Me.CheckWebView2Runtime);
				string text = null;
				try
				{
					text = CoreWebView2Environment.GetAvailableBrowserVersionString((string)null);
					_0024VB_0024Me._isWebView2Available = !string.IsNullOrEmpty(text);
					ModBase.Log($"检测到 WebView2 运行时版本: {text}");
				}
				catch (WebView2RuntimeNotFoundException val2)
				{
					ProjectData.SetProjectError((System.Exception)val2);
					WebView2RuntimeNotFoundException ex = val2;
					ModBase.Log((System.Exception)(object)ex, "未检测到 WebView2 运行时 (WebView2RuntimeNotFoundException)");
					_0024VB_0024Me._isWebView2Available = false;
					ProjectData.ClearProjectError();
				}
				catch (System.Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					System.Exception ex3 = ex2;
					ModBase.Log(ex3, $"检测 WebView2 运行时时发生错误: {((MemberInfo)ex3.GetType()).Name}");
					_0024VB_0024Me._isWebView2Available = false;
					ProjectData.ClearProjectError();
				}
				if (_0024VB_0024Me._isWebView2Available)
				{
					((UIElement)_0024VB_0024Me).Visibility = (Visibility)0;
					val = _0024VB_0024Me.InitializeWebView2().GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_24_CheckWebView2Runtime>(ref val, ref _this);
						return;
					}
					goto IL_01d5;
				}
				if (ModMain.MyMsgBox(string.Format("未检测到 WebView2 运行时{0}{1}需要安装 Microsoft Edge WebView2 Runtime 才能使用登录功能。{2}{3}是否前往下载页面？", new object[] { "\r\n", "\r\n", "\r\n", "\r\n" }), "缺少 WebView2 运行时", "前往下载", "取消") == -1)
				{
					try
					{
						ModBase.OpenWebsite("https://go.microsoft.com/fwlink/p/?LinkId=2124703");
						ModBase.Log("已尝试打开 WebView2 下载页面");
					}
					catch (System.Exception ex4)
					{
						ProjectData.SetProjectError(ex4);
						System.Exception ex5 = ex4;
						ModBase.Log(ex5, "打开 WebView2 下载页面失败");
						ProjectData.ClearProjectError();
					}
				}
				((Window)_0024VB_0024Me).Close();
				goto end_IL_0007;
				IL_01d5:
				val.GetResult();
				val = default(TaskAwaiter);
				end_IL_0007:;
			}
			catch (System.Exception ex6)
			{
				ProjectData.SetProjectError(ex6);
				System.Exception exception = ex6;
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
	internal sealed class VB_0024StateMachine_25_InitializeWebView2 : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal MyAuthWindow _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Expected O, but got Unknown
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Expected O, but got Unknown
			int num = _0024State;
			try
			{
				if (num != -3)
				{
				}
				try
				{
					TaskAwaiter val;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
					{
						string text = Path.Combine(ModBase.PathAppdata, "PCL", "WebView2");
						Directory.CreateDirectory(text);
						_0024VB_0024Me.AuthWebView.CreationProperties = new CoreWebView2CreationProperties
						{
							UserDataFolder = text
						};
						val = _0024VB_0024Me.AuthWebView.EnsureCoreWebView2Async((CoreWebView2Environment)null, (CoreWebView2ControllerOptions)null).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_25_InitializeWebView2>(ref val, ref _this);
							return;
						}
						break;
					}
					case 0:
						num = (_0024State = -1);
						val = _0024A0;
						_0024A0 = default(TaskAwaiter);
						break;
					}
					val.GetResult();
					val = default(TaskAwaiter);
					_0024VB_0024Me.AuthWebView.NavigationCompleted += _0024VB_0024Me.HandleNavigationCompleted;
					_0024VB_0024Me.AuthWebView.NavigationStarting += [SpecialName] (object s, CoreWebView2NavigationStartingEventArgs ev) =>
					{
						ModBase.Log($"AuthWebView 导航开始: {ev.Uri}");
					};
					ModBase.Log($"MyAuthWindow: LoginUrl='{_0024VB_0024Me.LoginUrl}' SuccessKeyword='{_0024VB_0024Me.SuccessKeyword}'");
					_0024VB_0024Me._loadedAt = System.DateTime.Now;
					if (!string.IsNullOrEmpty(_0024VB_0024Me.LoginUrl))
					{
						try
						{
							Uri val2 = new Uri(_0024VB_0024Me.LoginUrl);
							ModBase.Log($"设置 WebView 源: {val2.AbsoluteUri}");
							_0024VB_0024Me.AuthWebView.Source = val2;
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							ModBase.Log(ex2, $"设置 AuthWebView 源失败：{_0024VB_0024Me.LoginUrl}");
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						ModBase.Log("警告：LoginUrl 为空，未能导航登录页面");
					}
					_0024VB_0024Me._urlCheckTimer = new DispatcherTimer();
					_0024VB_0024Me._urlCheckTimer.Interval = TimeSpan.FromMilliseconds(500.0);
					_0024VB_0024Me._urlCheckTimer.Tick += new EventHandler(_0024VB_0024Me.CheckUrlChange);
					_0024VB_0024Me._urlCheckTimer.Start();
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, "初始化登录窗口 WebView 失败");
					((Window)_0024VB_0024Me).Close();
					ProjectData.ClearProjectError();
				}
			}
			catch (System.Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				System.Exception exception = ex5;
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
	internal sealed class VB_0024StateMachine_26_CheckUrlChange : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal EventArgs _0024VB_0024Local_e;

		internal MyAuthWindow _0024VB_0024Me;

		internal string _0024VB_0024ResumableLocal_currentUrl_00240;

		internal TaskAwaiter<string> _0024A0;

		internal TaskAwaiter _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Unknown result type (might be due to invalid IL or missing references)
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0201: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num == -3 || (uint)num <= 2u)
				{
					goto IL_0063;
				}
				if (!_0024VB_0024Me.IsSuccess)
				{
					if (System.DateTime.Compare(_0024VB_0024Me._loadedAt, System.DateTime.MinValue) == 0)
					{
						goto IL_0063;
					}
					TimeSpan val = System.DateTime.Now - _0024VB_0024Me._loadedAt;
					if (!(val.TotalSeconds < 3.0))
					{
						goto IL_0063;
					}
				}
				goto end_IL_0007;
				IL_0063:
				try
				{
					TaskAwaiter val2;
					string result;
					TaskAwaiter<string> awaiter2;
					TaskAwaiter<string> awaiter;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						if (_0024VB_0024Me.AuthWebView.CoreWebView2 != null)
						{
							awaiter2 = _0024VB_0024Me.AuthWebView.CoreWebView2.ExecuteScriptAsync("window.location.href").GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = awaiter2;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_26_CheckUrlChange>(ref awaiter2, ref _this);
								return;
							}
							goto IL_0111;
						}
						goto end_IL_0063;
					case 0:
						num = (_0024State = -1);
						awaiter2 = _0024A0;
						_0024A0 = default(TaskAwaiter<string>);
						goto IL_0111;
					case 1:
						num = (_0024State = -1);
						val2 = _0024A1;
						_0024A1 = default(TaskAwaiter);
						goto IL_01c7;
					case 2:
						{
							num = (_0024State = -1);
							awaiter = _0024A0;
							_0024A0 = default(TaskAwaiter<string>);
							break;
						}
						IL_01c7:
						val2.GetResult();
						val2 = default(TaskAwaiter);
						awaiter = _0024VB_0024Me.TryGetTokenAsync(_0024VB_0024ResumableLocal_currentUrl_00240).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 2);
							_0024A0 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_26_CheckUrlChange>(ref awaiter, ref _this);
							return;
						}
						break;
						IL_0111:
						result = awaiter2.GetResult();
						awaiter2 = default(TaskAwaiter<string>);
						_0024VB_0024ResumableLocal_currentUrl_00240 = result;
						_0024VB_0024ResumableLocal_currentUrl_00240 = _0024VB_0024ResumableLocal_currentUrl_00240.Trim('"');
						if (_0024VB_0024Me.IsSuccessUrl(_0024VB_0024ResumableLocal_currentUrl_00240))
						{
							_0024VB_0024Me._urlCheckTimer.Stop();
							_0024VB_0024Me.IsSuccess = true;
							val2 = _0024VB_0024Me.SaveAllCookiesAsync().GetAwaiter();
							if (!val2.IsCompleted)
							{
								num = (_0024State = 1);
								_0024A1 = val2;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_26_CheckUrlChange>(ref val2, ref _this);
								return;
							}
							goto IL_01c7;
						}
						goto end_IL_0063;
					}
					string result2 = awaiter.GetResult();
					awaiter = default(TaskAwaiter<string>);
					string token = result2;
					_0024VB_0024Me.AuthCompletedEvent?.Invoke((object)_0024VB_0024Me, new AuthCompletedEventArgs
					{
						Success = true,
						Cookies = _0024VB_0024Me.ResultCookies,
						FinalUrl = _0024VB_0024ResumableLocal_currentUrl_00240,
						Token = token
					});
					((Window)_0024VB_0024Me).Close();
					end_IL_0063:;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ProjectData.ClearProjectError();
				}
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

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_27_HandleNavigationCompleted : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal CoreWebView2NavigationCompletedEventArgs _0024VB_0024Local_e;

		internal MyAuthWindow _0024VB_0024Me;

		internal Uri _0024VB_0024ResumableLocal_current_00240;

		internal TaskAwaiter _0024A0;

		internal TaskAwaiter<string> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num == 0)
				{
					num = (_0024State = -1);
					val = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_0159;
				}
				TaskAwaiter<string> awaiter;
				if (num == 1)
				{
					num = (_0024State = -1);
					awaiter = _0024A1;
					_0024A1 = default(TaskAwaiter<string>);
					goto IL_01cf;
				}
				ModBase.Log($"AuthWebView 导航完成: IsSuccess={_0024VB_0024Local_e.IsSuccess}, WebErrorStatus={_0024VB_0024Local_e.WebErrorStatus}");
				if (!_0024VB_0024Me.IsSuccess)
				{
					if (System.DateTime.Compare(_0024VB_0024Me._loadedAt, System.DateTime.MinValue) == 0)
					{
						goto IL_009b;
					}
					TimeSpan val2 = System.DateTime.Now - _0024VB_0024Me._loadedAt;
					if (!(val2.TotalSeconds < 3.0))
					{
						goto IL_009b;
					}
				}
				goto end_IL_0007;
				IL_01cf:
				string result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<string>);
				string token = result;
				_0024VB_0024Me.AuthCompletedEvent?.Invoke((object)_0024VB_0024Me, new AuthCompletedEventArgs
				{
					Success = true,
					Cookies = _0024VB_0024Me.ResultCookies,
					FinalUrl = _0024VB_0024ResumableLocal_current_00240.AbsoluteUri,
					Token = token
				});
				((Window)_0024VB_0024Me).Close();
				goto end_IL_0007;
				IL_0159:
				val.GetResult();
				val = default(TaskAwaiter);
				awaiter = _0024VB_0024Me.TryGetTokenAsync(_0024VB_0024ResumableLocal_current_00240.AbsoluteUri).GetAwaiter();
				if (!awaiter.IsCompleted)
				{
					num = (_0024State = 1);
					_0024A1 = awaiter;
					_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_27_HandleNavigationCompleted>(ref awaiter, ref _this);
					return;
				}
				goto IL_01cf;
				IL_009b:
				_0024VB_0024ResumableLocal_current_00240 = _0024VB_0024Me.AuthWebView.Source;
				if (_0024VB_0024ResumableLocal_current_00240 != null && _0024VB_0024Me.IsSuccessUrl(_0024VB_0024ResumableLocal_current_00240.AbsoluteUri))
				{
					if (_0024VB_0024Me._urlCheckTimer != null)
					{
						_0024VB_0024Me._urlCheckTimer.Stop();
					}
					_0024VB_0024Me.IsSuccess = true;
					val = _0024VB_0024Me.SaveAllCookiesAsync().GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_27_HandleNavigationCompleted>(ref val, ref _this);
						return;
					}
					goto IL_0159;
				}
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
	internal sealed class VB_0024StateMachine_28_TryGetTokenAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder<string> _0024Builder;

		internal string _0024VB_0024Local_currentUrl;

		internal MyAuthWindow _0024VB_0024Me;

		internal string[] _0024VB_0024ResumableLocal_fallbackKeys_00240;

		internal string[] _0024VB_0024ResumableLocal_primaryKeys_00241;

		internal string _0024VB_0024ResumableLocal_token_00242;

		internal TaskAwaiter<string> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Unknown result type (might be due to invalid IL or missing references)
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_02af: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0354: Unknown result type (might be due to invalid IL or missing references)
			//IL_0359: Unknown result type (might be due to invalid IL or missing references)
			//IL_0361: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			//IL_0316: Unknown result type (might be due to invalid IL or missing references)
			//IL_031b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_0330: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			string result;
			try
			{
				if ((uint)(num - -4) <= 1u || (uint)num <= 4u)
				{
					goto IL_0084;
				}
				_0024VB_0024ResumableLocal_token_00242 = "";
				if (_0024VB_0024Me.AuthWebView.CoreWebView2 != null)
				{
					_0024VB_0024ResumableLocal_primaryKeys_00241 = new string[] { "token", "Token" };
					_0024VB_0024ResumableLocal_fallbackKeys_00240 = new string[] { "authorization", "Authorization", "access_token", "accessToken" };
					goto IL_0084;
				}
				result = _0024VB_0024ResumableLocal_token_00242;
				goto end_IL_0007;
				IL_0084:
				checked
				{
					try
					{
						string result2;
						TaskAwaiter<string> awaiter2;
						string result3;
						TaskAwaiter<string> awaiter4;
						string result4;
						TaskAwaiter<string> awaiter3;
						string result5;
						TaskAwaiter<string> awaiter;
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return;
						default:
							awaiter4 = _0024VB_0024Me.TryReadStorageTokenAsync("localStorage", _0024VB_0024ResumableLocal_primaryKeys_00241).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = awaiter4;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_28_TryGetTokenAsync>(ref awaiter4, ref _this);
								return;
							}
							goto IL_0125;
						case 0:
							num = (_0024State = -1);
							awaiter4 = _0024A0;
							_0024A0 = default(TaskAwaiter<string>);
							goto IL_0125;
						case 1:
							num = (_0024State = -1);
							awaiter3 = _0024A0;
							_0024A0 = default(TaskAwaiter<string>);
							goto IL_01ab;
						case 2:
							num = (_0024State = -1);
							awaiter2 = _0024A0;
							_0024A0 = default(TaskAwaiter<string>);
							goto IL_0234;
						case 3:
							num = (_0024State = -1);
							awaiter = _0024A0;
							_0024A0 = default(TaskAwaiter<string>);
							goto IL_02bd;
						case -4:
						case 4:
							break;
							IL_0234:
							result2 = awaiter2.GetResult();
							awaiter2 = default(TaskAwaiter<string>);
							_0024VB_0024ResumableLocal_token_00242 = result2;
							goto IL_0249;
							IL_0125:
							result3 = awaiter4.GetResult();
							awaiter4 = default(TaskAwaiter<string>);
							_0024VB_0024ResumableLocal_token_00242 = result3;
							if (string.IsNullOrWhiteSpace(_0024VB_0024ResumableLocal_token_00242))
							{
								awaiter3 = _0024VB_0024Me.TryReadStorageTokenAsync("localStorage", _0024VB_0024ResumableLocal_fallbackKeys_00240).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_0024State = 1);
									_0024A0 = awaiter3;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_28_TryGetTokenAsync>(ref awaiter3, ref _this);
									return;
								}
								goto IL_01ab;
							}
							goto IL_01c0;
							IL_0249:
							if (string.IsNullOrWhiteSpace(_0024VB_0024ResumableLocal_token_00242))
							{
								awaiter = _0024VB_0024Me.TryReadStorageTokenAsync("sessionStorage", _0024VB_0024ResumableLocal_fallbackKeys_00240).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 3);
									_0024A0 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_28_TryGetTokenAsync>(ref awaiter, ref _this);
									return;
								}
								goto IL_02bd;
							}
							goto IL_02d2;
							IL_02d2:
							if (string.IsNullOrWhiteSpace(_0024VB_0024ResumableLocal_token_00242))
							{
								break;
							}
							goto end_IL_0084;
							IL_01ab:
							result4 = awaiter3.GetResult();
							awaiter3 = default(TaskAwaiter<string>);
							_0024VB_0024ResumableLocal_token_00242 = result4;
							goto IL_01c0;
							IL_01c0:
							if (string.IsNullOrWhiteSpace(_0024VB_0024ResumableLocal_token_00242))
							{
								awaiter2 = _0024VB_0024Me.TryReadStorageTokenAsync("sessionStorage", _0024VB_0024ResumableLocal_primaryKeys_00241).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 2);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_28_TryGetTokenAsync>(ref awaiter2, ref _this);
									return;
								}
								goto IL_0234;
							}
							goto IL_0249;
							IL_02bd:
							result5 = awaiter.GetResult();
							awaiter = default(TaskAwaiter<string>);
							_0024VB_0024ResumableLocal_token_00242 = result5;
							goto IL_02d2;
						}
						try
						{
							TaskAwaiter<string> awaiter5;
							switch (num)
							{
							case -4:
								num = (_0024State = -1);
								return;
							default:
								awaiter5 = _0024VB_0024Me.AuthWebView.CoreWebView2.ExecuteScriptAsync("document.cookie").GetAwaiter();
								if (!awaiter5.IsCompleted)
								{
									num = (_0024State = 4);
									_0024A0 = awaiter5;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_28_TryGetTokenAsync>(ref awaiter5, ref _this);
									return;
								}
								break;
							case 4:
								num = (_0024State = -1);
								awaiter5 = _0024A0;
								_0024A0 = default(TaskAwaiter<string>);
								break;
							}
							string result6 = awaiter5.GetResult();
							awaiter5 = default(TaskAwaiter<string>);
							string raw = result6;
							string text = _0024VB_0024Me.NormalizeWebView2JsResult(raw);
							if (!string.IsNullOrEmpty(text))
							{
								string[] array = text.Split(';', (StringSplitOptions)0);
								for (int i = 0; i < array.Length; i++)
								{
									string text2 = array[i].Trim();
									string[] array2 = Enumerable.ToArray<string>(Enumerable.Concat<string>((System.Collections.Generic.IEnumerable<string>)_0024VB_0024ResumableLocal_primaryKeys_00241, (System.Collections.Generic.IEnumerable<string>)_0024VB_0024ResumableLocal_fallbackKeys_00240));
									foreach (string text3 in array2)
									{
										if (text2.StartsWith(text3 + "=", (StringComparison)5))
										{
											_0024VB_0024ResumableLocal_token_00242 = text2.Substring(text3.Length + 1);
											break;
										}
									}
									if (!string.IsNullOrWhiteSpace(_0024VB_0024ResumableLocal_token_00242))
									{
										break;
									}
								}
							}
						}
						catch (System.Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
						end_IL_0084:;
					}
					catch (System.Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						ProjectData.ClearProjectError();
					}
					result = _0024VB_0024ResumableLocal_token_00242 ?? "";
				}
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
			_0024Builder.SetResult(result);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_29_TryReadStorageTokenAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder<string> _0024Builder;

		internal string _0024VB_0024Local_storageName;

		internal string[] _0024VB_0024Local_keys;

		internal MyAuthWindow _0024VB_0024Me;

		internal string[] _0024S0;

		internal int _0024S1;

		internal System.Collections.Generic.IEnumerator<JProperty> _0024S2;

		internal TaskAwaiter<string> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			checked
			{
				string result;
				try
				{
					string text2 = default(string);
					switch (num)
					{
					default:
					{
						string text = "";
						if (_0024VB_0024Me.AuthWebView.CoreWebView2 != null)
						{
							_0024S0 = _0024VB_0024Local_keys;
							_0024S1 = 0;
							goto IL_015d;
						}
						result = text;
						goto end_IL_0007;
					}
					case -3:
					case 0:
						try
						{
							TaskAwaiter<string> awaiter;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
							{
								string text3 = $"{_0024VB_0024Local_storageName}.getItem('{text2}')";
								awaiter = _0024VB_0024Me.AuthWebView.CoreWebView2.ExecuteScriptAsync(text3).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_29_TryReadStorageTokenAsync>(ref awaiter, ref _this);
									return;
								}
								break;
							}
							case 0:
								num = (_0024State = -1);
								awaiter = _0024A0;
								_0024A0 = default(TaskAwaiter<string>);
								break;
							}
							string result2 = awaiter.GetResult();
							awaiter = default(TaskAwaiter<string>);
							string raw = result2;
							string v = _0024VB_0024Me.NormalizeWebView2JsResult(raw);
							string text4 = _0024VB_0024Me.ExtractTokenFromStorageValue(v);
							if (string.IsNullOrWhiteSpace(text4))
							{
								goto end_IL_006e;
							}
							result = text4;
							goto end_IL_0007;
							end_IL_006e:;
						}
						catch (System.Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
						_0024S1++;
						goto IL_015d;
					case -4:
					case 1:
						break;
						IL_015d:
						if (_0024S1 >= _0024S0.Length)
						{
							break;
						}
						text2 = _0024S0[_0024S1];
						goto case -3;
					}
					try
					{
						TaskAwaiter<string> awaiter2;
						switch (num)
						{
						case -4:
							num = (_0024State = -1);
							return;
						default:
						{
							string text5 = $"(function(){{var s={_0024VB_0024Local_storageName}; var out={{}}; for (var i=0;i<s.length;i++){{var k=s.key(i); out[k]=s.getItem(k);}} return JSON.stringify(out);}})()";
							awaiter2 = _0024VB_0024Me.AuthWebView.CoreWebView2.ExecuteScriptAsync(text5).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_0024State = 1);
								_0024A0 = awaiter2;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_29_TryReadStorageTokenAsync>(ref awaiter2, ref _this);
								return;
							}
							break;
						}
						case 1:
							num = (_0024State = -1);
							awaiter2 = _0024A0;
							_0024A0 = default(TaskAwaiter<string>);
							break;
						}
						string result3 = awaiter2.GetResult();
						awaiter2 = default(TaskAwaiter<string>);
						string raw2 = result3;
						string text6 = _0024VB_0024Me.NormalizeWebView2JsResult(raw2);
						if (!string.IsNullOrWhiteSpace(text6) && Operators.CompareString(text6, "null", false) != 0)
						{
							JObject jObject = JObject.Parse(text6);
							try
							{
								_0024S2 = jObject.Properties().GetEnumerator();
								while (((System.Collections.IEnumerator)_0024S2).MoveNext())
								{
									JProperty current = _0024S2.Current;
									string text7 = _0024VB_0024Me.ExtractTokenFromStorageValue(current.Value?.ToString() ?? "");
									if (string.IsNullOrWhiteSpace(text7))
									{
										continue;
									}
									result = text7;
									goto end_IL_0007;
								}
							}
							finally
							{
								if (num < 0 && _0024S2 != null)
								{
									((System.IDisposable)_0024S2).Dispose();
								}
							}
						}
					}
					catch (System.Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						ProjectData.ClearProjectError();
					}
					result = "";
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
				_0024Builder.SetResult(result);
			}
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_34_SaveCookiesAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal MyAuthWindow _0024VB_0024Me;

		internal System.Collections.Generic.IEnumerator<CoreWebView2Cookie> _0024S0;

		internal TaskAwaiter<List<CoreWebView2Cookie>> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Expected O, but got Unknown
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter<List<CoreWebView2Cookie>> awaiter;
				if (num == 0)
				{
					num = (_0024State = -1);
					awaiter = _0024A0;
					_0024A0 = default(TaskAwaiter<List<CoreWebView2Cookie>>);
					goto IL_00aa;
				}
				if (_0024VB_0024Me.AuthWebView.CoreWebView2 != null)
				{
					Uri source = _0024VB_0024Me.AuthWebView.Source;
					if (source != null)
					{
						awaiter = _0024VB_0024Me.AuthWebView.CoreWebView2.CookieManager.GetCookiesAsync(source.AbsoluteUri).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<CoreWebView2Cookie>>, VB_0024StateMachine_34_SaveCookiesAsync>(ref awaiter, ref _this);
							return;
						}
						goto IL_00aa;
					}
				}
				goto end_IL_0007;
				IL_00aa:
				List<CoreWebView2Cookie> result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<List<CoreWebView2Cookie>>);
				List<CoreWebView2Cookie> val = result;
				StringBuilder val2 = new StringBuilder();
				try
				{
					_0024S0 = val.GetEnumerator();
					while (_0024S0.MoveNext())
					{
						CoreWebView2Cookie current = _0024S0.Current;
						val2.Append(current.Name).Append("=").Append(current.Value);
						val2.Append("; domain=").Append(current.Domain);
						val2.Append("; path=").Append(current.Path);
						if (System.DateTime.Compare(current.Expires, System.DateTime.MinValue) > 0)
						{
							val2.Append("; expires=").Append(current.Expires.ToUniversalTime().ToString("u"));
						}
						if (current.IsSecure)
						{
							val2.Append("; secure");
						}
						if (current.IsHttpOnly)
						{
							val2.Append("; httponly");
						}
						val2.AppendLine();
					}
				}
				finally
				{
					if (num < 0)
					{
						((System.IDisposable)_0024S0)?.Dispose();
					}
				}
				_0024VB_0024Me.ResultCookies = val2.ToString().TrimEnd();
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
	internal sealed class VB_0024StateMachine_35_SaveAllCookiesAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal MyAuthWindow _0024VB_0024Me;

		internal System.Collections.Generic.IEnumerator<CoreWebView2Cookie> _0024S0;

		internal TaskAwaiter<List<CoreWebView2Cookie>> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter<List<CoreWebView2Cookie>> awaiter;
				if (num == 0)
				{
					num = (_0024State = -1);
					awaiter = _0024A0;
					_0024A0 = default(TaskAwaiter<List<CoreWebView2Cookie>>);
					goto IL_008c;
				}
				if (_0024VB_0024Me.AuthWebView.CoreWebView2 != null)
				{
					awaiter = _0024VB_0024Me.AuthWebView.CoreWebView2.CookieManager.GetCookiesAsync("").GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = awaiter;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<CoreWebView2Cookie>>, VB_0024StateMachine_35_SaveAllCookiesAsync>(ref awaiter, ref _this);
						return;
					}
					goto IL_008c;
				}
				goto end_IL_0007;
				IL_008c:
				List<CoreWebView2Cookie> result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<List<CoreWebView2Cookie>>);
				List<CoreWebView2Cookie> val = result;
				StringBuilder val2 = new StringBuilder();
				try
				{
					_0024S0 = val.GetEnumerator();
					while (_0024S0.MoveNext())
					{
						CoreWebView2Cookie current = _0024S0.Current;
						val2.Append(current.Name).Append("=").Append(current.Value);
						val2.Append("; domain=").Append(current.Domain);
						val2.Append("; path=").Append(current.Path);
						if (System.DateTime.Compare(current.Expires, System.DateTime.MinValue) > 0)
						{
							val2.Append("; expires=").Append(current.Expires.ToUniversalTime().ToString("u"));
						}
						if (current.IsSecure)
						{
							val2.Append("; secure");
						}
						if (current.IsHttpOnly)
						{
							val2.Append("; httponly");
						}
						val2.AppendLine();
					}
				}
				finally
				{
					if (num < 0)
					{
						((System.IDisposable)_0024S0)?.Dispose();
					}
				}
				_0024VB_0024Me.ResultCookies = val2.ToString().TrimEnd();
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

	private bool _isWebView2Available;

	private DispatcherTimer _urlCheckTimer;

	private System.DateTime _loadedAt;

	[CompilerGenerated]
	private EventHandler<AuthCompletedEventArgs> AuthCompletedEvent;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	public string LoginUrl
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public string SuccessKeyword
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public string ResultCookies
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	public bool IsSuccess
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("AuthWebView")]
	internal virtual WebView2 AuthWebView
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public event EventHandler<AuthCompletedEventArgs> AuthCompleted
	{
		[CompilerGenerated]
		add
		{
			EventHandler<AuthCompletedEventArgs> val = AuthCompletedEvent;
			EventHandler<AuthCompletedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<AuthCompletedEventArgs> val3 = (EventHandler<AuthCompletedEventArgs>)(object)System.Delegate.Combine((System.Delegate)(object)val2, (System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<AuthCompletedEventArgs>>(ref AuthCompletedEvent, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<AuthCompletedEventArgs> val = AuthCompletedEvent;
			EventHandler<AuthCompletedEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<AuthCompletedEventArgs> val3 = (EventHandler<AuthCompletedEventArgs>)(object)System.Delegate.Remove((System.Delegate)(object)val2, (System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<AuthCompletedEventArgs>>(ref AuthCompletedEvent, val3, val2);
			}
			while (val != val2);
		}
	}

	public MyAuthWindow()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		((Window)this).Closing += new CancelEventHandler(MyAuthWindow_Closing);
		ResultCookies = "";
		IsSuccess = false;
		_isWebView2Available = false;
		_loadedAt = System.DateTime.MinValue;
		InitializeComponent();
		((UIElement)this).Visibility = (Visibility)1;
		((FrameworkElement)this).Loaded += new RoutedEventHandler(CheckWebView2Runtime);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_24_CheckWebView2Runtime))]
	private void CheckWebView2Runtime(object sender, RoutedEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_24_CheckWebView2Runtime vB_0024StateMachine_24_CheckWebView2Runtime = default(VB_0024StateMachine_24_CheckWebView2Runtime);
		vB_0024StateMachine_24_CheckWebView2Runtime._0024VB_0024Me = this;
		vB_0024StateMachine_24_CheckWebView2Runtime._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_24_CheckWebView2Runtime._0024VB_0024Local_e = e;
		vB_0024StateMachine_24_CheckWebView2Runtime._0024State = -1;
		vB_0024StateMachine_24_CheckWebView2Runtime._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_24_CheckWebView2Runtime._0024Builder.Start<VB_0024StateMachine_24_CheckWebView2Runtime>(ref vB_0024StateMachine_24_CheckWebView2Runtime);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_25_InitializeWebView2))]
	private System.Threading.Tasks.Task InitializeWebView2()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_25_InitializeWebView2 vB_0024StateMachine_25_InitializeWebView = default(VB_0024StateMachine_25_InitializeWebView2);
		vB_0024StateMachine_25_InitializeWebView._0024VB_0024Me = this;
		vB_0024StateMachine_25_InitializeWebView._0024State = -1;
		vB_0024StateMachine_25_InitializeWebView._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_25_InitializeWebView._0024Builder.Start<VB_0024StateMachine_25_InitializeWebView2>(ref vB_0024StateMachine_25_InitializeWebView);
		return vB_0024StateMachine_25_InitializeWebView._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_26_CheckUrlChange))]
	private void CheckUrlChange(object sender, EventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_26_CheckUrlChange vB_0024StateMachine_26_CheckUrlChange = default(VB_0024StateMachine_26_CheckUrlChange);
		vB_0024StateMachine_26_CheckUrlChange._0024VB_0024Me = this;
		vB_0024StateMachine_26_CheckUrlChange._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_26_CheckUrlChange._0024VB_0024Local_e = e;
		vB_0024StateMachine_26_CheckUrlChange._0024State = -1;
		vB_0024StateMachine_26_CheckUrlChange._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_26_CheckUrlChange._0024Builder.Start<VB_0024StateMachine_26_CheckUrlChange>(ref vB_0024StateMachine_26_CheckUrlChange);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_27_HandleNavigationCompleted))]
	private void HandleNavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_27_HandleNavigationCompleted vB_0024StateMachine_27_HandleNavigationCompleted = default(VB_0024StateMachine_27_HandleNavigationCompleted);
		vB_0024StateMachine_27_HandleNavigationCompleted._0024VB_0024Me = this;
		vB_0024StateMachine_27_HandleNavigationCompleted._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_27_HandleNavigationCompleted._0024VB_0024Local_e = e;
		vB_0024StateMachine_27_HandleNavigationCompleted._0024State = -1;
		vB_0024StateMachine_27_HandleNavigationCompleted._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_27_HandleNavigationCompleted._0024Builder.Start<VB_0024StateMachine_27_HandleNavigationCompleted>(ref vB_0024StateMachine_27_HandleNavigationCompleted);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_28_TryGetTokenAsync))]
	private async System.Threading.Tasks.Task<string> TryGetTokenAsync(string currentUrl)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		if (AuthWebView.CoreWebView2 == null)
		{
			return text;
		}
		string[] array = new string[] { "token", "Token" };
		string[] array2 = new string[] { "authorization", "Authorization", "access_token", "accessToken" };
		checked
		{
			try
			{
				text = await TryReadStorageTokenAsync("localStorage", array);
				if (string.IsNullOrWhiteSpace(text))
				{
					text = await TryReadStorageTokenAsync("localStorage", array2);
				}
				if (string.IsNullOrWhiteSpace(text))
				{
					text = await TryReadStorageTokenAsync("sessionStorage", array);
				}
				if (string.IsNullOrWhiteSpace(text))
				{
					text = await TryReadStorageTokenAsync("sessionStorage", array2);
				}
				if (string.IsNullOrWhiteSpace(text))
				{
					try
					{
						string text2 = NormalizeWebView2JsResult(await AuthWebView.CoreWebView2.ExecuteScriptAsync("document.cookie"));
						if (!string.IsNullOrEmpty(text2))
						{
							string[] array3 = text2.Split(';', (StringSplitOptions)0);
							for (int i = 0; i < array3.Length; i++)
							{
								string text3 = array3[i].Trim();
								string[] array4 = Enumerable.ToArray<string>(Enumerable.Concat<string>((System.Collections.Generic.IEnumerable<string>)array, (System.Collections.Generic.IEnumerable<string>)array2));
								foreach (string text4 in array4)
								{
									if (text3.StartsWith(text4 + "=", (StringComparison)5))
									{
										text = text3.Substring(text4.Length + 1);
										break;
									}
								}
								if (!string.IsNullOrWhiteSpace(text))
								{
									break;
								}
							}
						}
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			catch (System.Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
			return text ?? "";
		}
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_29_TryReadStorageTokenAsync))]
	private async System.Threading.Tasks.Task<string> TryReadStorageTokenAsync(string storageName, string[] keys)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		if (AuthWebView.CoreWebView2 == null)
		{
			return result;
		}
		foreach (string text in keys)
		{
			try
			{
				string text2 = $"{storageName}.getItem('{text}')";
				string v = NormalizeWebView2JsResult(await AuthWebView.CoreWebView2.ExecuteScriptAsync(text2));
				string text3 = ExtractTokenFromStorageValue(v);
				if (!string.IsNullOrWhiteSpace(text3))
				{
					return text3;
				}
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		try
		{
			string text4 = $"(function(){{var s={storageName}; var out={{}}; for (var i=0;i<s.length;i++){{var k=s.key(i); out[k]=s.getItem(k);}} return JSON.stringify(out);}})()";
			string text5 = NormalizeWebView2JsResult(await AuthWebView.CoreWebView2.ExecuteScriptAsync(text4));
			if (!string.IsNullOrWhiteSpace(text5) && Operators.CompareString(text5, "null", false) != 0)
			{
				JObject jObject = JObject.Parse(text5);
				System.Collections.Generic.IEnumerator<JProperty> enumerator = default(System.Collections.Generic.IEnumerator<JProperty>);
				try
				{
					enumerator = jObject.Properties().GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						JProperty current = enumerator.Current;
						string text6 = ExtractTokenFromStorageValue(current.Value?.ToString() ?? "");
						if (!string.IsNullOrWhiteSpace(text6))
						{
							return text6;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
			}
		}
		catch (System.Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		return "";
	}

	private void SetWebView2UserDataFolder(WebView2 view, string folderName)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		if (view != null)
		{
			try
			{
				string text = Path.Combine(ModBase.PathAppdata, "PCL", "WebView2", folderName);
				Directory.CreateDirectory(text);
				view.CreationProperties = new CoreWebView2CreationProperties
				{
					UserDataFolder = text
				};
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, $"配置 WebView2 用户数据目录失败：{folderName}");
				ProjectData.ClearProjectError();
			}
		}
	}

	private string NormalizeWebView2JsResult(string raw)
	{
		string text = (raw ?? "").Trim();
		if (string.IsNullOrWhiteSpace(text))
		{
			return "";
		}
		if (string.Equals(text, "null", (StringComparison)5))
		{
			return "";
		}
		try
		{
			if (text.Length >= 2 && text[0] == '"' && text[checked(text.Length - 1)] == '"')
			{
				return JsonConvert.DeserializeObject<string>(text);
			}
		}
		catch (System.Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		return text;
	}

	private string ExtractTokenFromStorageValue(string v)
	{
		if (string.IsNullOrWhiteSpace(v))
		{
			return "";
		}
		string text = v.Trim();
		if (string.Equals(text, "null", (StringComparison)5))
		{
			return "";
		}
		if (text.StartsWith("{") && text.EndsWith("}"))
		{
			try
			{
				JObject jObject = JObject.Parse(text);
				string[] array = new string[] { "token", "Token", "authorization", "Authorization", "access_token", "accessToken" };
				foreach (string propertyName in array)
				{
					JToken jToken = jObject[propertyName];
					if (jToken != null)
					{
						string text2 = jToken.ToString();
						if (!string.IsNullOrWhiteSpace(text2) && !string.Equals(text2, "null", (StringComparison)5))
						{
							return text2;
						}
					}
				}
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
		}
		return text;
	}

	private bool IsSuccessUrl(string url)
	{
		if (string.IsNullOrWhiteSpace(SuccessKeyword) || string.IsNullOrWhiteSpace(url))
		{
			return false;
		}
		if (Operators.CompareString(SuccessKeyword, "/user/", false) == 0 && url.IndexOf("/user/login", (StringComparison)5) >= 0)
		{
			return false;
		}
		return url.IndexOf(SuccessKeyword, (StringComparison)5) >= 0;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_34_SaveCookiesAsync))]
	private System.Threading.Tasks.Task SaveCookiesAsync()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_34_SaveCookiesAsync vB_0024StateMachine_34_SaveCookiesAsync = default(VB_0024StateMachine_34_SaveCookiesAsync);
		vB_0024StateMachine_34_SaveCookiesAsync._0024VB_0024Me = this;
		vB_0024StateMachine_34_SaveCookiesAsync._0024State = -1;
		vB_0024StateMachine_34_SaveCookiesAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_34_SaveCookiesAsync._0024Builder.Start<VB_0024StateMachine_34_SaveCookiesAsync>(ref vB_0024StateMachine_34_SaveCookiesAsync);
		return vB_0024StateMachine_34_SaveCookiesAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_35_SaveAllCookiesAsync))]
	private System.Threading.Tasks.Task SaveAllCookiesAsync()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_35_SaveAllCookiesAsync vB_0024StateMachine_35_SaveAllCookiesAsync = default(VB_0024StateMachine_35_SaveAllCookiesAsync);
		vB_0024StateMachine_35_SaveAllCookiesAsync._0024VB_0024Me = this;
		vB_0024StateMachine_35_SaveAllCookiesAsync._0024State = -1;
		vB_0024StateMachine_35_SaveAllCookiesAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_35_SaveAllCookiesAsync._0024Builder.Start<VB_0024StateMachine_35_SaveAllCookiesAsync>(ref vB_0024StateMachine_35_SaveAllCookiesAsync);
		return vB_0024StateMachine_35_SaveAllCookiesAsync._0024Builder.Task;
	}

	private void MyAuthWindow_Closing(object sender, CancelEventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		try
		{
			if (_urlCheckTimer != null)
			{
				_urlCheckTimer.Stop();
				_urlCheckTimer.Tick -= new EventHandler(CheckUrlChange);
			}
			if (AuthWebView.CoreWebView2 != null)
			{
				AuthWebView.CoreWebView2.Stop();
			}
			if (!IsSuccess)
			{
				AuthCompletedEvent?.Invoke((object)this, new AuthCompletedEventArgs
				{
					Success = false,
					Cookies = "",
					FinalUrl = ""
				});
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "关闭登录窗口时出错");
			ProjectData.ClearProjectError();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/myauthwindow.xaml", (UriKind)2);
			Application.LoadComponent((object)this, val);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.6.0")]
	[EditorBrowsable(/*Could not decode attribute arguments.*/)]
	void IComponentConnector.Connect(int connectionId, object target)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		if (connectionId == 1)
		{
			AuthWebView = (WebView2)target;
		}
		else
		{
			_contentLoaded = true;
		}
	}
}
