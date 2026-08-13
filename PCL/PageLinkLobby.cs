using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Newtonsoft.Json.Linq;
using PCL.Core.Link;

namespace PCL;

[DesignerGenerated]
public class PageLinkLobby : MyPageRight, IComponentConnector
{
	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_19_PageLinkLobby_Loaded : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal RoutedEventArgs _0024VB_0024Local_e;

		internal PageLinkLobby _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02af: Unknown result type (might be due to invalid IL or missing references)
			//IL_0368: Unknown result type (might be due to invalid IL or missing references)
			//IL_036d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Unknown result type (might be due to invalid IL or missing references)
			//IL_042b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0430: Unknown result type (might be due to invalid IL or missing references)
			//IL_0438: Unknown result type (might be due to invalid IL or missing references)
			//IL_0496: Unknown result type (might be due to invalid IL or missing references)
			//IL_049b: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0458: Unknown result type (might be due to invalid IL or missing references)
			//IL_045d: Unknown result type (might be due to invalid IL or missing references)
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_032f: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_0384: Unknown result type (might be due to invalid IL or missing references)
			//IL_0447: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d3: Expected O, but got Unknown
			//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0508: Unknown result type (might be due to invalid IL or missing references)
			//IL_0512: Expected O, but got Unknown
			//IL_0472: Unknown result type (might be due to invalid IL or missing references)
			//IL_0474: Unknown result type (might be due to invalid IL or missing references)
			//IL_0344: Unknown result type (might be due to invalid IL or missing references)
			//IL_0346: Unknown result type (might be due to invalid IL or missing references)
			//IL_0407: Unknown result type (might be due to invalid IL or missing references)
			//IL_0409: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_0269: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val6;
				TaskAwaiter val5;
				TaskAwaiter val4;
				TaskAwaiter val3;
				TaskAwaiter val2;
				TaskAwaiter val;
				string text;
				object objectValue2;
				object objectValue3;
				string text2;
				object objectValue4;
				switch (num)
				{
				default:
					_0024VB_0024Me.RefreshUi();
					if (LinkProviderRegistry.GetState(_0024VB_0024Me.Provider.Kind).IsLoggedIn)
					{
						switch (_0024VB_0024Me.Provider.Kind)
						{
						case LinkProviderKind.OpenFrp:
							break;
						case LinkProviderKind.MeFrp:
							goto IL_0134;
						case LinkProviderKind.Natfrp:
							goto IL_0210;
						case LinkProviderKind.XhFrp:
							goto IL_02c9;
						case LinkProviderKind.Stellarfrp:
							goto IL_038f;
						default:
							goto IL_044d;
						}
						object objectValue = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkOpenFrpCookies"));
						if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue))))
						{
							_0024VB_0024Me.Log("页面加载：开始自动刷新用户信息...");
							val6 = _0024VB_0024Me.GetOpenFrpUserInfoAsync(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue))).GetAwaiter();
							if (!val6.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = val6;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_19_PageLinkLobby_Loaded>(ref val6, ref _this);
								return;
							}
							goto IL_0120;
						}
					}
					goto IL_044d;
				case 0:
					num = (_0024State = -1);
					val6 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_0120;
				case 1:
					num = (_0024State = -1);
					val5 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_01fc;
				case 2:
					num = (_0024State = -1);
					val4 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_02b5;
				case 3:
					num = (_0024State = -1);
					val3 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_037b;
				case 4:
					num = (_0024State = -1);
					val2 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_043e;
				case 5:
					{
						num = (_0024State = -1);
						val = _0024A0;
						_0024A0 = default(TaskAwaiter);
						break;
					}
					IL_037b:
					val3.GetResult();
					val3 = default(TaskAwaiter);
					goto IL_044d;
					IL_038f:
					text = "";
					try
					{
						text = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkStellarfrpToken")));
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						text = "";
						ProjectData.ClearProjectError();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						_0024VB_0024Me.Log("页面加载：开始自动刷新 Stellarfrp 用户信息...");
						val2 = _0024VB_0024Me.GetStellarfrpUserInfoAsync(text).GetAwaiter();
						if (!val2.IsCompleted)
						{
							num = (_0024State = 4);
							_0024A0 = val2;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_19_PageLinkLobby_Loaded>(ref val2, ref _this);
							return;
						}
						goto IL_043e;
					}
					goto IL_044d;
					IL_02b5:
					val4.GetResult();
					val4 = default(TaskAwaiter);
					goto IL_044d;
					IL_0134:
					objectValue2 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkMeFrpToken"));
					objectValue3 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkMeFrpCookies"));
					if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue2))))
					{
						_0024VB_0024Me.Log("页面加载：开始自动刷新用户信息...");
						val5 = _0024VB_0024Me.GetMeFrpUserInfoAsync(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue3)), Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue2))).GetAwaiter();
						if (!val5.IsCompleted)
						{
							num = (_0024State = 1);
							_0024A0 = val5;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_19_PageLinkLobby_Loaded>(ref val5, ref _this);
							return;
						}
						goto IL_01fc;
					}
					goto IL_044d;
					IL_0120:
					val6.GetResult();
					val6 = default(TaskAwaiter);
					goto IL_044d;
					IL_043e:
					val2.GetResult();
					val2 = default(TaskAwaiter);
					goto IL_044d;
					IL_02c9:
					text2 = "";
					try
					{
						text2 = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkXhFrpToken")));
					}
					catch (System.Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						text2 = "";
						ProjectData.ClearProjectError();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						_0024VB_0024Me.Log("页面加载：开始自动刷新 星穿月联 用户信息...");
						val3 = _0024VB_0024Me.GetXhfrpUserInfoAsync(text2).GetAwaiter();
						if (!val3.IsCompleted)
						{
							num = (_0024State = 3);
							_0024A0 = val3;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_19_PageLinkLobby_Loaded>(ref val3, ref _this);
							return;
						}
						goto IL_037b;
					}
					goto IL_044d;
					IL_044d:
					val = _0024VB_0024Me.LoadTunnelsAsync().GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 5);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_19_PageLinkLobby_Loaded>(ref val, ref _this);
						return;
					}
					break;
					IL_01fc:
					val5.GetResult();
					val5 = default(TaskAwaiter);
					goto IL_044d;
					IL_0210:
					objectValue4 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkNaidRefreshToken"));
					if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue4))))
					{
						_0024VB_0024Me.Log("页面加载：开始自动刷新用户信息...");
						val4 = _0024VB_0024Me.GetNatfrpUserInfoByToken(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue4))).GetAwaiter();
						if (!val4.IsCompleted)
						{
							num = (_0024State = 2);
							_0024A0 = val4;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_19_PageLinkLobby_Loaded>(ref val4, ref _this);
							return;
						}
						goto IL_02b5;
					}
					goto IL_044d;
				}
				val.GetResult();
				val = default(TaskAwaiter);
				_0024VB_0024Me.StartBroadcastListener();
				_0024VB_0024Me._timer = new DispatcherTimer();
				_0024VB_0024Me._timer.Interval = TimeSpan.FromSeconds(1.0);
				_0024VB_0024Me._timer.Tick += new EventHandler(_0024VB_0024Me.OnTimerTick);
				_0024VB_0024Me._timer.Start();
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
	internal sealed class VB_0024StateMachine_25_UpdateRunningLatency : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal PageLinkLobby _0024VB_0024Me;

		internal _Closure_0024__25_002D0 _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;

		internal TaskAwaiter<int> _0024A0;

		internal _Closure_0024__25_002D0 _0024U1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Expected O, but got Unknown
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter<int> awaiter;
				if (num == 0)
				{
					num = (_0024State = -1);
					awaiter = _0024A0;
					_0024A0 = default(TaskAwaiter<int>);
					goto IL_00cf;
				}
				if (!string.IsNullOrWhiteSpace(_0024VB_0024Me._serverAddr) && _0024VB_0024Me._serverPort > 0)
				{
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240 = new _Closure_0024__25_002D0();
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Me = _0024VB_0024Me;
					_0024U1 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;
					awaiter = _0024VB_0024Me.TcpPingAsync(_0024VB_0024Me._serverAddr, _0024VB_0024Me._serverPort, 3000).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = awaiter;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, VB_0024StateMachine_25_UpdateRunningLatency>(ref awaiter, ref _this);
						return;
					}
					goto IL_00cf;
				}
				goto end_IL_0007;
				IL_00cf:
				_Closure_0024__25_002D0 closure_0024__25_002D = _0024U1;
				int result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<int>);
				closure_0024__25_002D._0024VB_0024Local_latency = result;
				_0024U1 = null;
				((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
				{
					if (_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_latency > 0)
					{
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Me.LabRunningLatency.Text = $"延迟: {_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_latency} ms";
					}
					else
					{
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Me.LabRunningLatency.Text = "延迟: 超时";
					}
				}));
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
	internal sealed class VB_0024StateMachine_26_ClearMeFrpLocalStorageAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal PageLinkLobby _0024VB_0024Me;

		internal _Closure_0024__26_002D0 _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;

		internal EventHandler<CoreWebView2NavigationCompletedEventArgs> _0024VB_0024ResumableLocal_handler_00241;

		internal Panel _0024VB_0024ResumableLocal_host_00242;

		internal TaskAwaiter _0024A0;

		internal TaskAwaiter<System.Threading.Tasks.Task> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Expected O, but got Unknown
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					TaskAwaiter val;
					TaskAwaiter<System.Threading.Tasks.Task> awaiter;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240 = new _Closure_0024__26_002D0();
						_0024VB_0024ResumableLocal_host_00242 = (Panel)(object)_0024VB_0024Me.PanLogin;
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview = new WebView2
						{
							Visibility = (Visibility)2,
							Width = 0.0,
							Height = 0.0
						};
						_0024VB_0024Me.SetWebView2UserDataFolder(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview);
						if (_0024VB_0024ResumableLocal_host_00242 != null)
						{
							_0024VB_0024ResumableLocal_host_00242.Children.Add((UIElement)(object)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview);
						}
						val = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.EnsureCoreWebView2Async((CoreWebView2Environment)null, (CoreWebView2ControllerOptions)null).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_26_ClearMeFrpLocalStorageAsync>(ref val, ref _this);
							return;
						}
						goto IL_0129;
					case 0:
						num = (_0024State = -1);
						val = _0024A0;
						_0024A0 = default(TaskAwaiter);
						goto IL_0129;
					case 1:
						{
							num = (_0024State = -1);
							awaiter = _0024A1;
							_0024A1 = default(TaskAwaiter<System.Threading.Tasks.Task>);
							break;
						}
						IL_0129:
						val.GetResult();
						val = default(TaskAwaiter);
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_tcs = new TaskCompletionSource<bool>();
						_0024VB_0024ResumableLocal_handler_00241 = null;
						_0024VB_0024ResumableLocal_handler_00241 = [SpecialName] [AsyncStateMachine(typeof(_Closure_0024__26_002D0.VB_0024StateMachine___Lambda_0024__0))] (object s, CoreWebView2NavigationCompletedEventArgs e) =>
						{
							//IL_002a: Unknown result type (might be due to invalid IL or missing references)
							//IL_002f: Unknown result type (might be due to invalid IL or missing references)
							_Closure_0024__26_002D0.VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(_Closure_0024__26_002D0.VB_0024StateMachine___Lambda_0024__0);
							vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__26_002D0 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;
							vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_s = s;
							vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_e = e;
							vB_0024StateMachine___Lambda_0024__._0024State = -1;
							vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncVoidMethodBuilder.Create();
							vB_0024StateMachine___Lambda_0024__._0024Builder.Start<_Closure_0024__26_002D0.VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
						};
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.NavigationCompleted += _0024VB_0024ResumableLocal_handler_00241;
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.Source = new Uri("https://www.mefrp.com/");
						awaiter = System.Threading.Tasks.Task.WhenAny((System.Threading.Tasks.Task)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_tcs.Task, System.Threading.Tasks.Task.Delay(5000)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 1);
							_0024A1 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<System.Threading.Tasks.Task>, VB_0024StateMachine_26_ClearMeFrpLocalStorageAsync>(ref awaiter, ref _this);
							return;
						}
						break;
					}
					awaiter.GetResult();
					awaiter = default(TaskAwaiter<System.Threading.Tasks.Task>);
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.NavigationCompleted -= _0024VB_0024ResumableLocal_handler_00241;
					try
					{
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.Stop();
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					if (_0024VB_0024ResumableLocal_host_00242 != null)
					{
						_0024VB_0024ResumableLocal_host_00242.Children.Remove((UIElement)(object)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview);
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"MeFrp 清理 localStorage 失败：{ex2.Message}");
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_27_ClearNatfrpCookiesAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal PageLinkLobby _0024VB_0024Me;

		internal _Closure_0024__27_002D0 _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;

		internal EventHandler<CoreWebView2NavigationCompletedEventArgs> _0024VB_0024ResumableLocal_handler_00241;

		internal Panel _0024VB_0024ResumableLocal_host_00242;

		internal TaskAwaiter _0024A0;

		internal TaskAwaiter<System.Threading.Tasks.Task> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Expected O, but got Unknown
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					TaskAwaiter val;
					TaskAwaiter<System.Threading.Tasks.Task> awaiter;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240 = new _Closure_0024__27_002D0(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240);
						_0024VB_0024ResumableLocal_host_00242 = (Panel)(object)_0024VB_0024Me.PanLogin;
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview = new WebView2
						{
							Visibility = (Visibility)2,
							Width = 0.0,
							Height = 0.0
						};
						_0024VB_0024Me.SetWebView2UserDataFolder(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview);
						if (_0024VB_0024ResumableLocal_host_00242 != null)
						{
							_0024VB_0024ResumableLocal_host_00242.Children.Add((UIElement)(object)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview);
						}
						val = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.EnsureCoreWebView2Async((CoreWebView2Environment)null, (CoreWebView2ControllerOptions)null).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_27_ClearNatfrpCookiesAsync>(ref val, ref _this);
							return;
						}
						goto IL_012f;
					case 0:
						num = (_0024State = -1);
						val = _0024A0;
						_0024A0 = default(TaskAwaiter);
						goto IL_012f;
					case 1:
						{
							num = (_0024State = -1);
							awaiter = _0024A1;
							_0024A1 = default(TaskAwaiter<System.Threading.Tasks.Task>);
							break;
						}
						IL_012f:
						val.GetResult();
						val = default(TaskAwaiter);
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_tcs = new TaskCompletionSource<bool>();
						_0024VB_0024ResumableLocal_handler_00241 = null;
						_0024VB_0024ResumableLocal_handler_00241 = [SpecialName] [AsyncStateMachine(typeof(_Closure_0024__27_002D0.VB_0024StateMachine___Lambda_0024__0))] (object s, CoreWebView2NavigationCompletedEventArgs e) =>
						{
							//IL_002a: Unknown result type (might be due to invalid IL or missing references)
							//IL_002f: Unknown result type (might be due to invalid IL or missing references)
							_Closure_0024__27_002D0.VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(_Closure_0024__27_002D0.VB_0024StateMachine___Lambda_0024__0);
							vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__27_002D0 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;
							vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_s = s;
							vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_e = e;
							vB_0024StateMachine___Lambda_0024__._0024State = -1;
							vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncVoidMethodBuilder.Create();
							vB_0024StateMachine___Lambda_0024__._0024Builder.Start<_Closure_0024__27_002D0.VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
						};
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.NavigationCompleted += _0024VB_0024ResumableLocal_handler_00241;
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.Source = new Uri("https://www.natfrp.com/");
						awaiter = System.Threading.Tasks.Task.WhenAny((System.Threading.Tasks.Task)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_tcs.Task, System.Threading.Tasks.Task.Delay(5000)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 1);
							_0024A1 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<System.Threading.Tasks.Task>, VB_0024StateMachine_27_ClearNatfrpCookiesAsync>(ref awaiter, ref _this);
							return;
						}
						break;
					}
					awaiter.GetResult();
					awaiter = default(TaskAwaiter<System.Threading.Tasks.Task>);
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.NavigationCompleted -= _0024VB_0024ResumableLocal_handler_00241;
					try
					{
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.Stop();
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					if (_0024VB_0024ResumableLocal_host_00242 != null)
					{
						_0024VB_0024ResumableLocal_host_00242.Children.Remove((UIElement)(object)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview);
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"Natfrp 清理 Cookie 失败：{ex2.Message}");
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_28_StartClick : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal MouseButtonEventArgs _0024VB_0024Local_e;

		internal PageLinkLobby _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_029b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0354: Unknown result type (might be due to invalid IL or missing references)
			//IL_0359: Unknown result type (might be due to invalid IL or missing references)
			//IL_0361: Unknown result type (might be due to invalid IL or missing references)
			//IL_041a: Unknown result type (might be due to invalid IL or missing references)
			//IL_041f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0427: Unknown result type (might be due to invalid IL or missing references)
			//IL_04da: Unknown result type (might be due to invalid IL or missing references)
			//IL_04df: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_049f: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			//IL_0436: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0316: Unknown result type (might be due to invalid IL or missing references)
			//IL_031b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_0330: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				ProxyInfo proxyInfo;
				int num2 = default(int);
				TaskAwaiter val5;
				TaskAwaiter val4;
				TaskAwaiter val3;
				TaskAwaiter val2;
				TaskAwaiter val;
				string text2;
				object objectValue;
				object objectValue2;
				string cookieHeader;
				string cookieValue;
				string text3;
				object objectValue3;
				switch (num)
				{
				default:
					if (((Selector)_0024VB_0024Me.ComboTunnel).SelectedIndex < 0)
					{
						ModMain.Hint("请先选择一个隧道！", ModMain.HintType.Critical);
					}
					else if (ModLink.FrpcPrecheck())
					{
						proxyInfo = (ProxyInfo)NewLateBinding.LateGet(RuntimeHelpers.GetObjectValue(((Selector)_0024VB_0024Me.ComboTunnel).SelectedItem), (System.Type)null, "Proxy", new object[0], (string[])null, (System.Type[])null, (bool[])null);
						if (!string.IsNullOrWhiteSpace(_0024VB_0024Me.ComboRoom.Text))
						{
							string text = _0024VB_0024Me.ComboRoom.Text;
							Match val6 = Regex.Match(text, "\\((\\d+)\\)");
							if (((Group)val6).Success)
							{
								num2 = int.Parse(((Capture)val6.Groups[1]).Value);
							}
							else if (!int.TryParse(text, out num2))
							{
								num2 = proxyInfo.LocalPort;
							}
						}
						else
						{
							num2 = proxyInfo.LocalPort;
						}
						_0024VB_0024Me.Log($"准备启动隧道: {proxyInfo.ProxyName}, 本地端口: {num2}");
						switch (_0024VB_0024Me.Provider.Kind)
						{
						case LinkProviderKind.OpenFrp:
							goto IL_0145;
						case LinkProviderKind.MeFrp:
							goto IL_0209;
						case LinkProviderKind.Natfrp:
							goto IL_02c2;
						case LinkProviderKind.XhFrp:
							goto IL_037b;
						case LinkProviderKind.Stellarfrp:
							goto IL_0441;
						}
					}
					goto end_IL_0007;
				case 0:
					num = (_0024State = -1);
					val5 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_01f5;
				case 1:
					num = (_0024State = -1);
					val4 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_02ae;
				case 2:
					num = (_0024State = -1);
					val3 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_0367;
				case 3:
					num = (_0024State = -1);
					val2 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_042d;
				case 4:
					{
						num = (_0024State = -1);
						val = _0024A0;
						_0024A0 = default(TaskAwaiter);
						break;
					}
					IL_0441:
					text2 = "";
					try
					{
						text2 = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkStellarfrpToken")));
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						text2 = "";
						ProjectData.ClearProjectError();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						val = _0024VB_0024Me.StartStellarfrpcTunnel(proxyInfo, num2, text2).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 4);
							_0024A0 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_28_StartClick>(ref val, ref _this);
							return;
						}
						break;
					}
					ModMain.Hint("未找到 Stellarfrp Token，请重新登录！", ModMain.HintType.Critical);
					goto end_IL_0007;
					IL_0209:
					objectValue = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkMeFrpToken"));
					if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue))))
					{
						val4 = _0024VB_0024Me.StartMeFrpcTunnel(proxyInfo, num2, Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue))).GetAwaiter();
						if (!val4.IsCompleted)
						{
							num = (_0024State = 1);
							_0024A0 = val4;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_28_StartClick>(ref val4, ref _this);
							return;
						}
						goto IL_02ae;
					}
					ModMain.Hint("未找到 MeFrp Token，请重新登录！", ModMain.HintType.Critical);
					goto end_IL_0007;
					IL_042d:
					val2.GetResult();
					val2 = default(TaskAwaiter);
					goto end_IL_0007;
					IL_02ae:
					val4.GetResult();
					val4 = default(TaskAwaiter);
					goto end_IL_0007;
					IL_0145:
					objectValue2 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkOpenFrpCookies"));
					cookieHeader = _0024VB_0024Me.ConvertCookieTextToHeader(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue2)));
					cookieValue = _0024VB_0024Me.GetCookieValue(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue2)), "authorization");
					val5 = _0024VB_0024Me.StartFrpcTunnel(proxyInfo, num2, cookieHeader, cookieValue).GetAwaiter();
					if (!val5.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val5;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_28_StartClick>(ref val5, ref _this);
						return;
					}
					goto IL_01f5;
					IL_01f5:
					val5.GetResult();
					val5 = default(TaskAwaiter);
					goto end_IL_0007;
					IL_0367:
					val3.GetResult();
					val3 = default(TaskAwaiter);
					goto end_IL_0007;
					IL_037b:
					text3 = "";
					try
					{
						text3 = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkXhFrpToken")));
					}
					catch (System.Exception projectError2)
					{
						ProjectData.SetProjectError(projectError2);
						text3 = "";
						ProjectData.ClearProjectError();
					}
					if (!string.IsNullOrWhiteSpace(text3))
					{
						val2 = _0024VB_0024Me.StartXhfrpcTunnel(proxyInfo, num2, text3).GetAwaiter();
						if (!val2.IsCompleted)
						{
							num = (_0024State = 3);
							_0024A0 = val2;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_28_StartClick>(ref val2, ref _this);
							return;
						}
						goto IL_042d;
					}
					ModMain.Hint("未找到 星穿月联 Token，请重新登录！", ModMain.HintType.Critical);
					goto end_IL_0007;
					IL_02c2:
					objectValue3 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkNaidRefreshToken"));
					if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue3))))
					{
						val3 = _0024VB_0024Me.StartNatfrpcTunnel(proxyInfo, num2, Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue3))).GetAwaiter();
						if (!val3.IsCompleted)
						{
							num = (_0024State = 2);
							_0024A0 = val3;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_28_StartClick>(ref val3, ref _this);
							return;
						}
						goto IL_0367;
					}
					ModMain.Hint("未找到 Natfrp Token，请重新登录！", ModMain.HintType.Critical);
					goto end_IL_0007;
				}
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
	internal sealed class VB_0024StateMachine_32_LogoutClick : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal EventArgs _0024VB_0024Local_e;

		internal PageLinkLobby _0024VB_0024Me;

		internal HttpClient _0024VB_0024ResumableLocal_client_00240;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0540: Unknown result type (might be due to invalid IL or missing references)
			//IL_0546: Expected O, but got Unknown
			//IL_0548: Expected O, but got Unknown
			//IL_05d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_05dd: Expected O, but got Unknown
			//IL_05df: Expected O, but got Unknown
			//IL_066e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0674: Expected O, but got Unknown
			//IL_0676: Expected O, but got Unknown
			//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0320: Unknown result type (might be due to invalid IL or missing references)
			//IL_0325: Unknown result type (might be due to invalid IL or missing references)
			//IL_032d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_041d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0422: Unknown result type (might be due to invalid IL or missing references)
			//IL_042a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0362: Unknown result type (might be due to invalid IL or missing references)
			//IL_0367: Unknown result type (might be due to invalid IL or missing references)
			//IL_03df: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_033c: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0439: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_027c: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_037c: Unknown result type (might be due to invalid IL or missing references)
			//IL_037e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Expected O, but got Unknown
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if ((uint)(num - -4) > 1u && (uint)num > 4u)
				{
					_0024VB_0024Me.Log("开始退出登录...");
				}
				try
				{
					string text2 = default(string);
					string cookieValue = default(string);
					TaskAwaiter val4;
					TaskAwaiter val3;
					TaskAwaiter val2;
					TaskAwaiter val;
					string text;
					switch (num)
					{
					case -4:
						num = (_0024State = -1);
						return;
					default:
						text = "";
						switch (_0024VB_0024Me.Provider.Kind)
						{
						case LinkProviderKind.OpenFrp:
							goto IL_0098;
						case LinkProviderKind.MeFrp:
							goto IL_0247;
						case LinkProviderKind.Natfrp:
							goto IL_02c7;
						case LinkProviderKind.XhFrp:
							goto IL_0347;
						case LinkProviderKind.Stellarfrp:
							goto IL_03c4;
						}
						goto end_IL_0023;
					case -3:
					case 0:
						try
						{
							TaskAwaiter<HttpResponseMessage> awaiter;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
							{
								_0024VB_0024ResumableLocal_client_00240.Timeout = TimeSpan.FromSeconds(10.0);
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00240.DefaultRequestHeaders).Add("Cookie", text2);
								if (!string.IsNullOrWhiteSpace(cookieValue))
								{
									((HttpHeaders)_0024VB_0024ResumableLocal_client_00240.DefaultRequestHeaders).Add("authorization", cookieValue);
								}
								StringContent val5 = new StringContent("{}", Encoding.UTF8, "application/json");
								awaiter = _0024VB_0024ResumableLocal_client_00240.PostAsync("https://console.openfrp.net/web/frp/api/logout", (HttpContent)(object)val5).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_32_LogoutClick>(ref awaiter, ref _this);
									return;
								}
								break;
							}
							case 0:
								num = (_0024State = -1);
								awaiter = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								break;
							}
							HttpResponseMessage result = awaiter.GetResult();
							awaiter = default(TaskAwaiter<HttpResponseMessage>);
							HttpResponseMessage val6 = result;
							if (val6.IsSuccessStatusCode)
							{
								_0024VB_0024Me.Log("登出请求成功");
							}
							else
							{
								_0024VB_0024Me.Log($"登出请求失败：{val6.StatusCode}");
							}
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00240 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00240).Dispose();
							}
						}
						goto end_IL_0023;
					case 1:
						num = (_0024State = -1);
						val4 = _0024A1;
						_0024A1 = default(TaskAwaiter);
						goto IL_02b3;
					case 2:
						num = (_0024State = -1);
						val3 = _0024A1;
						_0024A1 = default(TaskAwaiter);
						goto IL_0333;
					case 3:
						num = (_0024State = -1);
						val2 = _0024A1;
						_0024A1 = default(TaskAwaiter);
						goto IL_03b3;
					case 4:
						{
							num = (_0024State = -1);
							val = _0024A1;
							_0024A1 = default(TaskAwaiter);
							break;
						}
						IL_03c4:
						_0024VB_0024Me.Log("Stellarfrp 退出登录（清理本地数据与 localStorage）");
						val = _0024VB_0024Me.ClearStellarfrpLocalStorageAsync().GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 4);
							_0024A1 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_32_LogoutClick>(ref val, ref _this);
							return;
						}
						break;
						IL_02b3:
						val4.GetResult();
						val4 = default(TaskAwaiter);
						goto end_IL_0023;
						IL_0347:
						_0024VB_0024Me.Log("星穿月联 退出登录（清理本地数据与 localStorage）");
						val2 = _0024VB_0024Me.ClearXhfrpLocalStorageAsync().GetAwaiter();
						if (!val2.IsCompleted)
						{
							num = (_0024State = 3);
							_0024A1 = val2;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_32_LogoutClick>(ref val2, ref _this);
							return;
						}
						goto IL_03b3;
						IL_0098:
						text = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkOpenFrpCookies")));
						if (!string.IsNullOrWhiteSpace(text))
						{
							text2 = _0024VB_0024Me.ConvertCookieTextToHeader(text);
							cookieValue = _0024VB_0024Me.GetCookieValue(text, "authorization");
							_0024VB_0024Me.Log("正在向 OpenFRP 发送登出请求...");
							_0024VB_0024ResumableLocal_client_00240 = new HttpClient();
							goto case -3;
						}
						goto end_IL_0023;
						IL_03b3:
						val2.GetResult();
						val2 = default(TaskAwaiter);
						goto end_IL_0023;
						IL_02c7:
						_0024VB_0024Me.Log("Natfrp 退出登录（清理本地数据与 Cookie）");
						val3 = _0024VB_0024Me.ClearNatfrpCookiesAsync().GetAwaiter();
						if (!val3.IsCompleted)
						{
							num = (_0024State = 2);
							_0024A1 = val3;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_32_LogoutClick>(ref val3, ref _this);
							return;
						}
						goto IL_0333;
						IL_0333:
						val3.GetResult();
						val3 = default(TaskAwaiter);
						goto end_IL_0023;
						IL_0247:
						_0024VB_0024Me.Log("MeFrp 退出登录（清理本地数据与 localStorage）");
						val4 = _0024VB_0024Me.ClearMeFrpLocalStorageAsync().GetAwaiter();
						if (!val4.IsCompleted)
						{
							num = (_0024State = 1);
							_0024A1 = val4;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_32_LogoutClick>(ref val4, ref _this);
							return;
						}
						goto IL_02b3;
					}
					val.GetResult();
					val = default(TaskAwaiter);
					end_IL_0023:;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"登出请求出错：{ex2.Message}");
					ProjectData.ClearProjectError();
				}
				switch (_0024VB_0024Me.Provider.Kind)
				{
				case LinkProviderKind.OpenFrp:
					ModBase.Setup.Set("LinkOpenFrpCookies", "");
					break;
				case LinkProviderKind.MeFrp:
					ModBase.Setup.Set("LinkMeFrpCookies", "");
					ModBase.Setup.Set("LinkMeFrpToken", "");
					_0024VB_0024Me.Log("已清除 MeFrp Token 和 Cookies");
					break;
				case LinkProviderKind.Natfrp:
					ModBase.Setup.Set("LinkNatfrpCookies", "");
					ModBase.Setup.Set("LinkNaidRefreshToken", "");
					try
					{
						ModBase.Setup.Set("LinkNatfrpUser", "");
					}
					catch (KeyNotFoundException val9)
					{
						ProjectData.SetProjectError((System.Exception)val9);
						KeyNotFoundException val10 = val9;
						ProjectData.ClearProjectError();
					}
					_0024VB_0024Me.Log("已清除 Natfrp Token 和 Cookies");
					break;
				case LinkProviderKind.XhFrp:
					try
					{
						ModBase.Setup.Set("LinkXhFrpCookies", "");
						ModBase.Setup.Set("LinkXhFrpToken", "");
					}
					catch (System.Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						System.Exception ex6 = ex5;
						_0024VB_0024Me.Log($"清除 LinkXhFrp 配置失败: {ex6.Message}");
						ProjectData.ClearProjectError();
					}
					try
					{
						ModBase.Setup.Set("LinkXhFrpUser", "");
					}
					catch (KeyNotFoundException val11)
					{
						ProjectData.SetProjectError((System.Exception)val11);
						KeyNotFoundException val12 = val11;
						ProjectData.ClearProjectError();
					}
					_0024VB_0024Me.Log("已清除 星穿月联 Token 和 Cookies");
					break;
				case LinkProviderKind.Stellarfrp:
					try
					{
						ModBase.Setup.Set("LinkStellarfrpCookies", "");
						ModBase.Setup.Set("LinkStellarfrpToken", "");
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						_0024VB_0024Me.Log($"清除 LinkStellarfrp 配置失败: {ex4.Message}");
						ProjectData.ClearProjectError();
					}
					try
					{
						ModBase.Setup.Set("LinkStellarfrpUser", "");
					}
					catch (KeyNotFoundException val7)
					{
						ProjectData.SetProjectError((System.Exception)val7);
						KeyNotFoundException val8 = val7;
						ProjectData.ClearProjectError();
					}
					_0024VB_0024Me.Log("已清除 Stellarfrp Token 和 Cookies");
					break;
				}
				_0024VB_0024Me.Log("已清除本地数据");
				LinkProviderRegistry.SignOut(_0024VB_0024Me.Provider.Kind);
				_0024VB_0024Me._isRunning = false;
				((ItemsControl)_0024VB_0024Me.ComboTunnel).ItemsSource = null;
				((Selector)_0024VB_0024Me.ComboTunnel).SelectedIndex = -1;
				_0024VB_0024Me.RefreshUi();
				ModMain.Hint("已退出登录", ModMain.HintType.Finish);
				_0024VB_0024Me.Log("退出登录完成");
			}
			catch (System.Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				System.Exception exception = ex7;
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
	internal sealed class VB_0024StateMachine_35_OnAuthCompleted : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal AuthCompletedEventArgs _0024VB_0024Local_e;

		internal PageLinkLobby _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02af: Unknown result type (might be due to invalid IL or missing references)
			//IL_0393: Unknown result type (might be due to invalid IL or missing references)
			//IL_0398: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0572: Unknown result type (might be due to invalid IL or missing references)
			//IL_0577: Unknown result type (might be due to invalid IL or missing references)
			//IL_057f: Unknown result type (might be due to invalid IL or missing references)
			//IL_074e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0753: Unknown result type (might be due to invalid IL or missing references)
			//IL_075b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0534: Unknown result type (might be due to invalid IL or missing references)
			//IL_0539: Unknown result type (might be due to invalid IL or missing references)
			//IL_0713: Unknown result type (might be due to invalid IL or missing references)
			//IL_0718: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_02be: Unknown result type (might be due to invalid IL or missing references)
			//IL_03af: Unknown result type (might be due to invalid IL or missing references)
			//IL_058e: Unknown result type (might be due to invalid IL or missing references)
			//IL_076a: Unknown result type (might be due to invalid IL or missing references)
			//IL_054e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0550: Unknown result type (might be due to invalid IL or missing references)
			//IL_072d: Unknown result type (might be due to invalid IL or missing references)
			//IL_072f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0355: Unknown result type (might be due to invalid IL or missing references)
			//IL_035a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_036f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0371: Unknown result type (might be due to invalid IL or missing references)
			//IL_0267: Unknown result type (might be due to invalid IL or missing references)
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val5;
				TaskAwaiter val4;
				TaskAwaiter val3;
				TaskAwaiter val2;
				TaskAwaiter val;
				string text;
				string text2;
				switch (num)
				{
				default:
					if (_0024VB_0024Local_e.Success)
					{
						_0024VB_0024Me.Log($"登录窗口已完成，开始处理 {_0024VB_0024Me.Provider.Name} 登录...");
						switch (_0024VB_0024Me.Provider.Kind)
						{
						case LinkProviderKind.OpenFrp:
							goto IL_0088;
						case LinkProviderKind.MeFrp:
							goto IL_0176;
						case LinkProviderKind.Natfrp:
							goto IL_02d9;
						case LinkProviderKind.XhFrp:
							goto IL_03ca;
						case LinkProviderKind.Stellarfrp:
							goto IL_05a9;
						}
					}
					goto end_IL_0007;
				case 0:
					num = (_0024State = -1);
					val5 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_0152;
				case 1:
					num = (_0024State = -1);
					val4 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_02b5;
				case 2:
					num = (_0024State = -1);
					val3 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_03a6;
				case 3:
					num = (_0024State = -1);
					val2 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_0585;
				case 4:
					{
						num = (_0024State = -1);
						val = _0024A0;
						_0024A0 = default(TaskAwaiter);
						break;
					}
					IL_03a6:
					val3.GetResult();
					val3 = default(TaskAwaiter);
					_0024VB_0024Me.Log("Natfrp 用户信息获取流程已完成");
					goto end_IL_0007;
					IL_05a9:
					_0024VB_0024Me.Log("保存 Stellarfrp Cookies...");
					try
					{
						ModBase.Setup.Set("LinkStellarfrpCookies", _0024VB_0024Local_e.Cookies);
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						_0024VB_0024Me.Log($"保存 LinkStellarfrpCookies 失败: {ex2.Message}");
						ProjectData.ClearProjectError();
					}
					text = _0024VB_0024Local_e.Token;
					if (string.IsNullOrWhiteSpace(text))
					{
						text = _0024VB_0024Me.ExtractTokenFromCookiesSafe(_0024VB_0024Local_e.Cookies);
						if (!string.IsNullOrWhiteSpace(text))
						{
							_0024VB_0024Me.Log("兜底：从 Cookies 中提取到了 Stellarfrp Token");
						}
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						_0024VB_0024Me.Log($"Stellarfrp Token 存在，长度: {text.Length}");
						try
						{
							ModBase.Setup.Set("LinkStellarfrpToken", text);
						}
						catch (System.Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							System.Exception ex4 = ex3;
							_0024VB_0024Me.Log($"保存 LinkStellarfrpToken 失败: {ex4.Message}");
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						_0024VB_0024Me.Log("警告：Stellarfrp Token 为空");
					}
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "pending", "正在获取...");
					_0024VB_0024Me.RefreshUi();
					_0024VB_0024Me.Log("开始异步获取 Stellarfrp 用户信息...");
					val = _0024VB_0024Me.GetStellarfrpUserInfoAsync(text ?? "").GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 4);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_35_OnAuthCompleted>(ref val, ref _this);
						return;
					}
					break;
					IL_0152:
					val5.GetResult();
					val5 = default(TaskAwaiter);
					_0024VB_0024Me.Log("用户信息获取流程已完成");
					goto end_IL_0007;
					IL_03ca:
					_0024VB_0024Me.Log("保存 星穿月联 Cookies...");
					try
					{
						ModBase.Setup.Set("LinkXhFrpCookies", _0024VB_0024Local_e.Cookies);
					}
					catch (System.Exception ex5)
					{
						ProjectData.SetProjectError(ex5);
						System.Exception ex6 = ex5;
						_0024VB_0024Me.Log($"保存 LinkXhFrpCookies 失败: {ex6.Message}");
						ProjectData.ClearProjectError();
					}
					text2 = _0024VB_0024Local_e.Token;
					if (string.IsNullOrWhiteSpace(text2))
					{
						text2 = _0024VB_0024Me.ExtractTokenFromCookiesSafe(_0024VB_0024Local_e.Cookies);
						if (!string.IsNullOrWhiteSpace(text2))
						{
							_0024VB_0024Me.Log("兜底：从 Cookies 中提取到了 XhFrp Token");
						}
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						_0024VB_0024Me.Log($"星穿月联 Token 存在，长度: {text2.Length}");
						try
						{
							ModBase.Setup.Set("LinkXhFrpToken", text2);
						}
						catch (System.Exception ex7)
						{
							ProjectData.SetProjectError(ex7);
							System.Exception ex8 = ex7;
							_0024VB_0024Me.Log($"保存 LinkXhFrpToken 失败: {ex8.Message}");
							ProjectData.ClearProjectError();
						}
					}
					else
					{
						_0024VB_0024Me.Log("警告：星穿月联 Token 为空");
					}
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "pending", "正在获取...");
					_0024VB_0024Me.RefreshUi();
					_0024VB_0024Me.Log("开始异步获取 星穿月联 用户信息...");
					val2 = _0024VB_0024Me.GetXhfrpUserInfoAsync(text2 ?? "").GetAwaiter();
					if (!val2.IsCompleted)
					{
						num = (_0024State = 3);
						_0024A0 = val2;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_35_OnAuthCompleted>(ref val2, ref _this);
						return;
					}
					goto IL_0585;
					IL_02b5:
					val4.GetResult();
					val4 = default(TaskAwaiter);
					_0024VB_0024Me.Log("用户信息获取流程已完成");
					goto end_IL_0007;
					IL_02d9:
					_0024VB_0024Me.Log("保存 Natfrp Cookies...");
					ModBase.Setup.Set("LinkNatfrpCookies", _0024VB_0024Local_e.Cookies);
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "pending", "正在获取...");
					_0024VB_0024Me.RefreshUi();
					_0024VB_0024Me.Log("开始异步获取 Natfrp 用户信息...");
					val3 = _0024VB_0024Me.GetNatfrpUserInfoAsync(_0024VB_0024Local_e.Cookies).GetAwaiter();
					if (!val3.IsCompleted)
					{
						num = (_0024State = 2);
						_0024A0 = val3;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_35_OnAuthCompleted>(ref val3, ref _this);
						return;
					}
					goto IL_03a6;
					IL_0585:
					val2.GetResult();
					val2 = default(TaskAwaiter);
					_0024VB_0024Me.Log("星穿月联 用户信息获取流程已完成");
					goto end_IL_0007;
					IL_0176:
					_0024VB_0024Me.Log("保存 MeFrp Cookies...");
					ModBase.Setup.Set("LinkMeFrpCookies", _0024VB_0024Local_e.Cookies);
					if (!string.IsNullOrWhiteSpace(_0024VB_0024Local_e.Token))
					{
						_0024VB_0024Me.Log($"MeFrp Token 存在，长度: {_0024VB_0024Local_e.Token.Length}");
						ModBase.Setup.Set("LinkMeFrpToken", _0024VB_0024Local_e.Token);
					}
					else
					{
						_0024VB_0024Me.Log("警告：MeFrp Token 为空");
					}
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "pending", "正在获取...");
					_0024VB_0024Me.RefreshUi();
					_0024VB_0024Me.Log("开始异步获取用户信息...");
					val4 = _0024VB_0024Me.GetMeFrpUserInfoAsync(_0024VB_0024Local_e.Cookies, _0024VB_0024Local_e.Token).GetAwaiter();
					if (!val4.IsCompleted)
					{
						num = (_0024State = 1);
						_0024A0 = val4;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_35_OnAuthCompleted>(ref val4, ref _this);
						return;
					}
					goto IL_02b5;
					IL_0088:
					_0024VB_0024Me.Log("保存 OpenFRP Cookies...");
					ModBase.Setup.Set("LinkOpenFrpCookies", _0024VB_0024Local_e.Cookies);
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "pending", "正在获取...");
					_0024VB_0024Me.RefreshUi();
					_0024VB_0024Me.Log("开始异步获取用户信息...");
					val5 = _0024VB_0024Me.GetOpenFrpUserInfoAsync(_0024VB_0024Local_e.Cookies).GetAwaiter();
					if (!val5.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val5;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_35_OnAuthCompleted>(ref val5, ref _this);
						return;
					}
					goto IL_0152;
				}
				val.GetResult();
				val = default(TaskAwaiter);
				_0024VB_0024Me.Log("Stellarfrp 用户信息获取流程已完成");
				end_IL_0007:;
			}
			catch (System.Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				System.Exception exception = ex9;
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
	internal sealed class VB_0024StateMachine_37_LoadTunnelsAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal PageLinkLobby _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_0290: Unknown result type (might be due to invalid IL or missing references)
			//IL_033e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0343: Unknown result type (might be due to invalid IL or missing references)
			//IL_034b: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0406: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Unknown result type (might be due to invalid IL or missing references)
			//IL_035a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0415: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0300: Unknown result type (might be due to invalid IL or missing references)
			//IL_0305: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0476: Unknown result type (might be due to invalid IL or missing references)
			//IL_047b: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0261: Unknown result type (might be due to invalid IL or missing references)
			//IL_031a: Unknown result type (might be due to invalid IL or missing references)
			//IL_031c: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0490: Unknown result type (might be due to invalid IL or missing references)
			//IL_0492: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3 && (uint)num > 4u && !LinkProviderRegistry.GetState(_0024VB_0024Me.Provider.Kind).IsLoggedIn)
				{
					_0024VB_0024Me.Log("未登录，跳过隧道加载");
				}
				else
				{
					try
					{
						string text;
						TaskAwaiter val5;
						TaskAwaiter val4;
						TaskAwaiter val3;
						TaskAwaiter val2;
						TaskAwaiter val;
						string cookieValue;
						string cookieHeader;
						object objectValue;
						object objectValue2;
						object objectValue3;
						object objectValue4;
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return;
						default:
							_0024VB_0024Me.Log("页面加载：开始获取隧道列表...");
							text = "";
							switch (_0024VB_0024Me.Provider.Kind)
							{
							case LinkProviderKind.OpenFrp:
								text = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkOpenFrpCookies")));
								break;
							case LinkProviderKind.MeFrp:
								text = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkMeFrpCookies")));
								break;
							case LinkProviderKind.Natfrp:
								text = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkNatfrpCookies")));
								break;
							}
							if (_0024VB_0024Me.Provider.Kind != LinkProviderKind.Natfrp && string.IsNullOrWhiteSpace(text))
							{
								_0024VB_0024Me.Log("未找到已保存的Cookie");
								break;
							}
							switch (_0024VB_0024Me.Provider.Kind)
							{
							case LinkProviderKind.OpenFrp:
								goto IL_016f;
							case LinkProviderKind.MeFrp:
								goto IL_0204;
							case LinkProviderKind.Natfrp:
								goto IL_02bf;
							case LinkProviderKind.XhFrp:
								goto IL_037a;
							case LinkProviderKind.Stellarfrp:
								goto IL_0435;
							}
							break;
						case 0:
							num = (_0024State = -1);
							val5 = _0024A0;
							_0024A0 = default(TaskAwaiter);
							goto IL_01f0;
						case 1:
							num = (_0024State = -1);
							val4 = _0024A0;
							_0024A0 = default(TaskAwaiter);
							goto IL_0296;
						case 2:
							num = (_0024State = -1);
							val3 = _0024A0;
							_0024A0 = default(TaskAwaiter);
							goto IL_0351;
						case 3:
							num = (_0024State = -1);
							val2 = _0024A0;
							_0024A0 = default(TaskAwaiter);
							goto IL_040c;
						case 4:
							{
								num = (_0024State = -1);
								val = _0024A0;
								_0024A0 = default(TaskAwaiter);
								goto IL_04c7;
							}
							IL_016f:
							cookieValue = _0024VB_0024Me.GetCookieValue(text, "authorization");
							cookieHeader = _0024VB_0024Me.ConvertCookieTextToHeader(text);
							val5 = _0024VB_0024Me.GetUserProxiesAsync(cookieHeader, cookieValue).GetAwaiter();
							if (!val5.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = val5;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_37_LoadTunnelsAsync>(ref val5, ref _this);
								return;
							}
							goto IL_01f0;
							IL_0204:
							objectValue = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkMeFrpToken"));
							if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue))))
							{
								val4 = _0024VB_0024Me.GetMeFrpProxiesAsync(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue))).GetAwaiter();
								if (!val4.IsCompleted)
								{
									num = (_0024State = 1);
									_0024A0 = val4;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_37_LoadTunnelsAsync>(ref val4, ref _this);
									return;
								}
								goto IL_0296;
							}
							_0024VB_0024Me.Log("错误：MeFrp Token 为空");
							break;
							IL_02bf:
							objectValue2 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkNaidRefreshToken"));
							if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue2))))
							{
								val3 = _0024VB_0024Me.GetNatfrpTunnelsAsync(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue2))).GetAwaiter();
								if (!val3.IsCompleted)
								{
									num = (_0024State = 2);
									_0024A0 = val3;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_37_LoadTunnelsAsync>(ref val3, ref _this);
									return;
								}
								goto IL_0351;
							}
							_0024VB_0024Me.Log("错误：Natfrp Token 为空");
							break;
							IL_040c:
							val2.GetResult();
							val2 = default(TaskAwaiter);
							break;
							IL_0435:
							objectValue3 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkStellarfrpToken"));
							if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue3))))
							{
								val = _0024VB_0024Me.GetStellarfrpProxiesAsync(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue3))).GetAwaiter();
								if (!val.IsCompleted)
								{
									num = (_0024State = 4);
									_0024A0 = val;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_37_LoadTunnelsAsync>(ref val, ref _this);
									return;
								}
								goto IL_04c7;
							}
							_0024VB_0024Me.Log("错误：Stellarfrp Token 为空");
							break;
							IL_01f0:
							val5.GetResult();
							val5 = default(TaskAwaiter);
							break;
							IL_0351:
							val3.GetResult();
							val3 = default(TaskAwaiter);
							break;
							IL_04c7:
							val.GetResult();
							val = default(TaskAwaiter);
							break;
							IL_037a:
							objectValue4 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkXhFrpToken"));
							if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue4))))
							{
								val2 = _0024VB_0024Me.GetXhfrpProxiesAsync(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue4))).GetAwaiter();
								if (!val2.IsCompleted)
								{
									num = (_0024State = 3);
									_0024A0 = val2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_37_LoadTunnelsAsync>(ref val2, ref _this);
									return;
								}
								goto IL_040c;
							}
							_0024VB_0024Me.Log("错误：星穿月联 Token 为空");
							break;
							IL_0296:
							val4.GetResult();
							val4 = default(TaskAwaiter);
							break;
						}
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						_0024VB_0024Me.Log($"加载隧道列表失败: {ex2.Message}");
						ProjectData.ClearProjectError();
					}
				}
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
	internal sealed class VB_0024StateMachine_43_RefreshTunnelsClick : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal EventArgs _0024VB_0024Local_e;

		internal PageLinkLobby _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_039b: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_046f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0474: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0489: Unknown result type (might be due to invalid IL or missing references)
			//IL_048b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0305: Unknown result type (might be due to invalid IL or missing references)
			//IL_030a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0312: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_03de: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0321: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 4;
				}
				try
				{
					TaskAwaiter val5;
					TaskAwaiter val4;
					TaskAwaiter val3;
					TaskAwaiter val2;
					TaskAwaiter val;
					string text;
					object objectValue2;
					object objectValue3;
					string text2;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
					{
						_0024VB_0024Me.Log("开始刷新隧道列表...");
						ModMain.Hint("正在刷新隧道列表...");
						LinkProviderRegistry.GetState(_0024VB_0024Me.Provider.Kind);
						switch (_0024VB_0024Me.Provider.Kind)
						{
						case LinkProviderKind.OpenFrp:
							break;
						case LinkProviderKind.MeFrp:
							goto IL_019e;
						case LinkProviderKind.Natfrp:
							goto IL_0265;
						case LinkProviderKind.XhFrp:
							goto IL_032c;
						case LinkProviderKind.Stellarfrp:
							goto IL_0400;
						default:
							goto end_IL_0015;
						}
						object objectValue = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkOpenFrpCookies"));
						if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue))))
						{
							string cookieValue = _0024VB_0024Me.GetCookieValue(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue)), "authorization");
							string cookieHeader = _0024VB_0024Me.ConvertCookieTextToHeader(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue)));
							val5 = _0024VB_0024Me.GetUserProxiesAsync(cookieHeader, cookieValue).GetAwaiter();
							if (!val5.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = val5;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_43_RefreshTunnelsClick>(ref val5, ref _this);
								return;
							}
							goto IL_018a;
						}
						_0024VB_0024Me.Log("未找到已保存的Cookie，无法刷新");
						ModMain.Hint("请先登录！", ModMain.HintType.Critical);
						goto end_IL_0011;
					}
					case 0:
						num = (_0024State = -1);
						val5 = _0024A0;
						_0024A0 = default(TaskAwaiter);
						goto IL_018a;
					case 1:
						num = (_0024State = -1);
						val4 = _0024A0;
						_0024A0 = default(TaskAwaiter);
						goto IL_0251;
					case 2:
						num = (_0024State = -1);
						val3 = _0024A0;
						_0024A0 = default(TaskAwaiter);
						goto IL_0318;
					case 3:
						num = (_0024State = -1);
						val2 = _0024A0;
						_0024A0 = default(TaskAwaiter);
						goto IL_03ec;
					case 4:
						{
							num = (_0024State = -1);
							val = _0024A0;
							_0024A0 = default(TaskAwaiter);
							goto IL_04c0;
						}
						IL_0400:
						text = "";
						try
						{
							text = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkStellarfrpToken")));
						}
						catch (System.Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							text = "";
							ProjectData.ClearProjectError();
						}
						if (!string.IsNullOrWhiteSpace(text))
						{
							val = _0024VB_0024Me.GetStellarfrpProxiesAsync(text).GetAwaiter();
							if (!val.IsCompleted)
							{
								num = (_0024State = 4);
								_0024A0 = val;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_43_RefreshTunnelsClick>(ref val, ref _this);
								return;
							}
							goto IL_04c0;
						}
						_0024VB_0024Me.Log("未找到已保存的 Token，无法刷新");
						ModMain.Hint("请先登录！", ModMain.HintType.Critical);
						goto end_IL_0011;
						IL_03ec:
						val2.GetResult();
						val2 = default(TaskAwaiter);
						break;
						IL_0265:
						objectValue2 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkNaidRefreshToken"));
						if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue2))))
						{
							val3 = _0024VB_0024Me.GetNatfrpTunnelsAsync(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue2))).GetAwaiter();
							if (!val3.IsCompleted)
							{
								num = (_0024State = 2);
								_0024A0 = val3;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_43_RefreshTunnelsClick>(ref val3, ref _this);
								return;
							}
							goto IL_0318;
						}
						_0024VB_0024Me.Log("未找到已保存的 Token，无法刷新");
						ModMain.Hint("请先登录！", ModMain.HintType.Critical);
						goto end_IL_0011;
						IL_0318:
						val3.GetResult();
						val3 = default(TaskAwaiter);
						break;
						IL_019e:
						objectValue3 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkMeFrpToken"));
						if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue3))))
						{
							val4 = _0024VB_0024Me.GetMeFrpProxiesAsync(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue3))).GetAwaiter();
							if (!val4.IsCompleted)
							{
								num = (_0024State = 1);
								_0024A0 = val4;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_43_RefreshTunnelsClick>(ref val4, ref _this);
								return;
							}
							goto IL_0251;
						}
						_0024VB_0024Me.Log("未找到已保存的 Token，无法刷新");
						ModMain.Hint("请先登录！", ModMain.HintType.Critical);
						goto end_IL_0011;
						IL_04c0:
						val.GetResult();
						val = default(TaskAwaiter);
						break;
						IL_032c:
						text2 = "";
						try
						{
							text2 = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkXhFrpToken")));
						}
						catch (System.Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							text2 = "";
							ProjectData.ClearProjectError();
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							val2 = _0024VB_0024Me.GetXhfrpProxiesAsync(text2).GetAwaiter();
							if (!val2.IsCompleted)
							{
								num = (_0024State = 3);
								_0024A0 = val2;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_43_RefreshTunnelsClick>(ref val2, ref _this);
								return;
							}
							goto IL_03ec;
						}
						_0024VB_0024Me.Log("未找到已保存的 Token，无法刷新");
						ModMain.Hint("请先登录！", ModMain.HintType.Critical);
						goto end_IL_0011;
						IL_0251:
						val4.GetResult();
						val4 = default(TaskAwaiter);
						break;
						IL_018a:
						val5.GetResult();
						val5 = default(TaskAwaiter);
						break;
						end_IL_0015:
						break;
					}
					if (LinkProviderRegistry.GetState(_0024VB_0024Me.Provider.Kind).IsLoggedIn)
					{
						ModMain.Hint("隧道列表已刷新！", ModMain.HintType.Finish);
					}
					end_IL_0011:;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"刷新隧道列表失败: {ex2.Message}");
					ModMain.Hint("刷新失败，请重新登录！", ModMain.HintType.Critical);
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_44_RefreshUserInfoClick : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal EventArgs _0024VB_0024Local_e;

		internal PageLinkLobby _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_036e: Unknown result type (might be due to invalid IL or missing references)
			//IL_043d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0442: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0383: Unknown result type (might be due to invalid IL or missing references)
			//IL_0385: Unknown result type (might be due to invalid IL or missing references)
			//IL_0497: Unknown result type (might be due to invalid IL or missing references)
			//IL_0457: Unknown result type (might be due to invalid IL or missing references)
			//IL_0459: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_047b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0480: Unknown result type (might be due to invalid IL or missing references)
			//IL_0488: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_02af: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 4;
				}
				try
				{
					TaskAwaiter val5;
					TaskAwaiter val4;
					TaskAwaiter val3;
					TaskAwaiter val2;
					TaskAwaiter val;
					string text2;
					object objectValue;
					object objectValue2;
					string text;
					string text3;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						_0024VB_0024Me.Log("开始刷新用户信息...");
						ModMain.Hint("正在刷新用户信息...");
						text = "";
						switch (_0024VB_0024Me.Provider.Kind)
						{
						case LinkProviderKind.OpenFrp:
							break;
						case LinkProviderKind.MeFrp:
							goto IL_0150;
						case LinkProviderKind.Natfrp:
							goto IL_0233;
						case LinkProviderKind.XhFrp:
							goto IL_02fa;
						case LinkProviderKind.Stellarfrp:
							goto IL_03ce;
						default:
							goto end_IL_0015;
						}
						text = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkOpenFrpCookies")));
						if (!string.IsNullOrWhiteSpace(text))
						{
							val5 = _0024VB_0024Me.GetOpenFrpUserInfoAsync(text).GetAwaiter();
							if (!val5.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = val5;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_44_RefreshUserInfoClick>(ref val5, ref _this);
								return;
							}
							goto IL_013c;
						}
						_0024VB_0024Me.Log("未找到已保存的Cookie，无法刷新");
						ModMain.Hint("请先登录！", ModMain.HintType.Critical);
						goto end_IL_0011;
					case 0:
						num = (_0024State = -1);
						val5 = _0024A0;
						_0024A0 = default(TaskAwaiter);
						goto IL_013c;
					case 1:
						num = (_0024State = -1);
						val4 = _0024A0;
						_0024A0 = default(TaskAwaiter);
						goto IL_021f;
					case 2:
						num = (_0024State = -1);
						val3 = _0024A0;
						_0024A0 = default(TaskAwaiter);
						goto IL_02e6;
					case 3:
						num = (_0024State = -1);
						val2 = _0024A0;
						_0024A0 = default(TaskAwaiter);
						goto IL_03ba;
					case 4:
						{
							num = (_0024State = -1);
							val = _0024A0;
							_0024A0 = default(TaskAwaiter);
							goto IL_048e;
						}
						IL_03ce:
						text2 = "";
						try
						{
							text2 = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkStellarfrpToken")));
						}
						catch (System.Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							text2 = "";
							ProjectData.ClearProjectError();
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							val = _0024VB_0024Me.GetStellarfrpUserInfoAsync(text2).GetAwaiter();
							if (!val.IsCompleted)
							{
								num = (_0024State = 4);
								_0024A0 = val;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_44_RefreshUserInfoClick>(ref val, ref _this);
								return;
							}
							goto IL_048e;
						}
						_0024VB_0024Me.Log("未找到已保存的 Token，无法刷新");
						ModMain.Hint("请先登录！", ModMain.HintType.Critical);
						goto end_IL_0011;
						IL_03ba:
						val2.GetResult();
						val2 = default(TaskAwaiter);
						break;
						IL_0233:
						objectValue = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkNaidRefreshToken"));
						if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue))))
						{
							val3 = _0024VB_0024Me.GetNatfrpUserInfoByToken(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue))).GetAwaiter();
							if (!val3.IsCompleted)
							{
								num = (_0024State = 2);
								_0024A0 = val3;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_44_RefreshUserInfoClick>(ref val3, ref _this);
								return;
							}
							goto IL_02e6;
						}
						_0024VB_0024Me.Log("未找到已保存的 Token，无法刷新");
						ModMain.Hint("请先登录！", ModMain.HintType.Critical);
						goto end_IL_0011;
						IL_02e6:
						val3.GetResult();
						val3 = default(TaskAwaiter);
						break;
						IL_0150:
						objectValue2 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkMeFrpToken"));
						text = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkMeFrpCookies")));
						if (!string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue2))))
						{
							val4 = _0024VB_0024Me.GetMeFrpUserInfoAsync(text, Conversions.ToString(RuntimeHelpers.GetObjectValue(objectValue2))).GetAwaiter();
							if (!val4.IsCompleted)
							{
								num = (_0024State = 1);
								_0024A0 = val4;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_44_RefreshUserInfoClick>(ref val4, ref _this);
								return;
							}
							goto IL_021f;
						}
						_0024VB_0024Me.Log("未找到已保存的 Token，无法刷新");
						ModMain.Hint("请先登录！", ModMain.HintType.Critical);
						goto end_IL_0011;
						IL_048e:
						val.GetResult();
						val = default(TaskAwaiter);
						break;
						IL_02fa:
						text3 = "";
						try
						{
							text3 = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkXhFrpToken")));
						}
						catch (System.Exception projectError2)
						{
							ProjectData.SetProjectError(projectError2);
							text3 = "";
							ProjectData.ClearProjectError();
						}
						if (!string.IsNullOrWhiteSpace(text3))
						{
							val2 = _0024VB_0024Me.GetXhfrpUserInfoAsync(text3).GetAwaiter();
							if (!val2.IsCompleted)
							{
								num = (_0024State = 3);
								_0024A0 = val2;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_44_RefreshUserInfoClick>(ref val2, ref _this);
								return;
							}
							goto IL_03ba;
						}
						_0024VB_0024Me.Log("未找到已保存的 Token，无法刷新");
						ModMain.Hint("请先登录！", ModMain.HintType.Critical);
						goto end_IL_0011;
						IL_021f:
						val4.GetResult();
						val4 = default(TaskAwaiter);
						break;
						IL_013c:
						val5.GetResult();
						val5 = default(TaskAwaiter);
						break;
						end_IL_0015:
						break;
					}
					ModMain.Hint("用户信息已刷新！", ModMain.HintType.Finish);
					end_IL_0011:;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"刷新用户信息失败: {ex2.Message}");
					ModMain.Hint("刷新失败，请重新登录！", ModMain.HintType.Critical);
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_46_GetOpenFrpUserInfoAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_cookieText;

		internal PageLinkLobby _0024VB_0024Me;

		internal string _0024VB_0024ResumableLocal_cookieHeader_00240;

		internal string _0024VB_0024ResumableLocal_authorization_00241;

		internal HttpResponseMessage _0024VB_0024ResumableLocal_response_00242;

		internal HttpClient _0024VB_0024ResumableLocal_client_00243;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00244;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		internal TaskAwaiter _0024A2;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_07ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_07b2: Expected O, but got Unknown
			//IL_07b4: Expected O, but got Unknown
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Expected O, but got Unknown
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0355: Unknown result type (might be due to invalid IL or missing references)
			//IL_035a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0362: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_06cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0258: Unknown result type (might be due to invalid IL or missing references)
			//IL_025e: Expected O, but got Unknown
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0371: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_06de: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			//IL_0684: Unknown result type (might be due to invalid IL or missing references)
			//IL_0689: Unknown result type (might be due to invalid IL or missing references)
			//IL_0317: Unknown result type (might be due to invalid IL or missing references)
			//IL_031c: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Expected O, but got Unknown
			//IL_069e: Unknown result type (might be due to invalid IL or missing references)
			//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0331: Unknown result type (might be due to invalid IL or missing references)
			//IL_0333: Unknown result type (might be due to invalid IL or missing references)
			//IL_0589: Unknown result type (might be due to invalid IL or missing references)
			//IL_058e: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3 && (uint)num > 3u)
				{
					_0024VB_0024Me.Log("===== 开始获取 OpenFRP 用户信息 =====");
				}
				try
				{
					if (num == -3 || (uint)num <= 3u)
					{
						goto IL_018d;
					}
					if (!string.IsNullOrWhiteSpace(_0024VB_0024Local_cookieText))
					{
						_0024VB_0024Me.Log($"Cookie 内容长度：{_0024VB_0024Local_cookieText.Length}");
						_0024VB_0024ResumableLocal_authorization_00241 = _0024VB_0024Me.GetCookieValue(_0024VB_0024Local_cookieText, "authorization");
						if (string.IsNullOrWhiteSpace(_0024VB_0024ResumableLocal_authorization_00241))
						{
							_0024VB_0024Me.Log("警告：未找到 authorization Cookie");
						}
						else
						{
							_0024VB_0024Me.Log($"提取到 authorization: {_0024VB_0024ResumableLocal_authorization_00241.Substring(0, Math.Min(20, _0024VB_0024ResumableLocal_authorization_00241.Length))}...");
						}
						_0024VB_0024ResumableLocal_cookieHeader_00240 = _0024VB_0024Me.ConvertCookieTextToHeader(_0024VB_0024Local_cookieText);
						_0024VB_0024Me.Log(string.Format("Cookie Header: {0}", (object)((_0024VB_0024ResumableLocal_cookieHeader_00240.Length > 100) ? (_0024VB_0024ResumableLocal_cookieHeader_00240.Substring(0, 100) + "...") : _0024VB_0024ResumableLocal_cookieHeader_00240)));
						_0024VB_0024Me.Log("正在向 OpenFRP 请求用户信息...");
						_0024VB_0024ResumableLocal_handler_00244 = new HttpClientHandler
						{
							UseCookies = false
						};
						goto IL_018d;
					}
					_0024VB_0024Me.Log("错误：Cookie文本为空");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "Cookie错误");
					_0024VB_0024Me.RefreshUi();
					goto end_IL_0021;
					IL_018d:
					try
					{
						if (num != -3 && (uint)num > 3u)
						{
							_0024VB_0024ResumableLocal_client_00243 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00244);
						}
						try
						{
							TaskAwaiter val;
							string result;
							TaskAwaiter<string> awaiter2;
							string text;
							JObject jObject;
							JToken? jToken;
							string text4;
							HttpResponseMessage result2;
							TaskAwaiter<HttpResponseMessage> awaiter3;
							TaskAwaiter<string> awaiter;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
							{
								_0024VB_0024ResumableLocal_client_00243.Timeout = TimeSpan.FromSeconds(10.0);
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00243.DefaultRequestHeaders).Add("Cookie", _0024VB_0024ResumableLocal_cookieHeader_00240);
								if (!string.IsNullOrWhiteSpace(_0024VB_0024ResumableLocal_authorization_00241))
								{
									((HttpHeaders)_0024VB_0024ResumableLocal_client_00243.DefaultRequestHeaders).Add("authorization", _0024VB_0024ResumableLocal_authorization_00241);
									_0024VB_0024Me.Log("已添加 authorization header");
								}
								StringContent val2 = new StringContent("{}", Encoding.UTF8, "application/json");
								awaiter3 = _0024VB_0024ResumableLocal_client_00243.PostAsync("https://console.openfrp.net/web/frp/api/getUserInfo", (HttpContent)(object)val2).GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter3;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_46_GetOpenFrpUserInfoAsync>(ref awaiter3, ref _this);
									return;
								}
								goto IL_02bd;
							}
							case 0:
								num = (_0024State = -1);
								awaiter3 = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								goto IL_02bd;
							case 1:
								num = (_0024State = -1);
								awaiter2 = _0024A1;
								_0024A1 = default(TaskAwaiter<string>);
								goto IL_0368;
							case 2:
								num = (_0024State = -1);
								val = _0024A2;
								_0024A2 = default(TaskAwaiter);
								goto IL_05da;
							case 3:
								{
									num = (_0024State = -1);
									awaiter = _0024A1;
									_0024A1 = default(TaskAwaiter<string>);
									break;
								}
								IL_05da:
								val.GetResult();
								val = default(TaskAwaiter);
								goto end_IL_01a8;
								IL_0368:
								result = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<string>);
								text = result;
								_0024VB_0024Me.Log(string.Format("响应内容：{0}", (object)((text.Length > 200) ? (text.Substring(0, 200) + "...") : text)));
								jObject = JObject.Parse(text);
								jToken = jObject["flag"];
								if (jToken != null && jToken.Value<bool>())
								{
									JToken jToken2 = jObject["data"];
									string text2 = jToken2["username"]?.ToString();
									string token = jToken2["token"]?.ToString();
									long? num2 = jToken2["traffic"]?.Value<long>();
									string text3 = jToken2["friendlyGroup"]?.ToString();
									int? num3 = jToken2["proxies"]?.Value<int>();
									LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, token, text2);
									_0024VB_0024Me._username = text2;
									_0024VB_0024Me._trafficGB = ((double?)num2 / 1024.0).Value;
									_0024VB_0024Me._friendlyGroup = text3 ?? "未知";
									_0024VB_0024Me._proxiesCount = num3.GetValueOrDefault();
									_0024VB_0024Me.Log($"登录成功！用户：{text2}，剩余流量：{_0024VB_0024Me._trafficGB:F2} GB");
									_0024VB_0024Me.UpdateUserInfoUI();
									_0024VB_0024Me.RefreshUi();
									val = _0024VB_0024Me.GetUserProxiesAsync(_0024VB_0024ResumableLocal_cookieHeader_00240, _0024VB_0024ResumableLocal_authorization_00241).GetAwaiter();
									if (!val.IsCompleted)
									{
										num = (_0024State = 2);
										_0024A2 = val;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_46_GetOpenFrpUserInfoAsync>(ref val, ref _this);
										return;
									}
									goto IL_05da;
								}
								_0024VB_0024Me.Log("API 返回失败{authorization}");
								text4 = jObject["msg"]?.ToString();
								_0024VB_0024Me.Log($"API 返回失败：{text4}");
								_0024VB_0024Me.Log($"完整响应：{text}");
								LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "API错误");
								_0024VB_0024Me.RefreshUi();
								goto end_IL_01a8;
								IL_02bd:
								result2 = awaiter3.GetResult();
								awaiter3 = default(TaskAwaiter<HttpResponseMessage>);
								_0024VB_0024ResumableLocal_response_00242 = result2;
								_0024VB_0024Me.Log($"收到响应：{_0024VB_0024ResumableLocal_response_00242.StatusCode}");
								if (_0024VB_0024ResumableLocal_response_00242.IsSuccessStatusCode)
								{
									awaiter2 = _0024VB_0024ResumableLocal_response_00242.Content.ReadAsStringAsync().GetAwaiter();
									if (!awaiter2.IsCompleted)
									{
										num = (_0024State = 1);
										_0024A1 = awaiter2;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_46_GetOpenFrpUserInfoAsync>(ref awaiter2, ref _this);
										return;
									}
									goto IL_0368;
								}
								awaiter = _0024VB_0024ResumableLocal_response_00242.Content.ReadAsStringAsync().GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 3);
									_0024A1 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_46_GetOpenFrpUserInfoAsync>(ref awaiter, ref _this);
									return;
								}
								break;
							}
							string result3 = awaiter.GetResult();
							awaiter = default(TaskAwaiter<string>);
							string text5 = result3;
							_0024VB_0024Me.Log($"HTTP 请求失败：{_0024VB_0024ResumableLocal_response_00242.StatusCode}");
							_0024VB_0024Me.Log(string.Format("错误详情：{0}", (object)((text5.Length > 200) ? (text5.Substring(0, 200) + "...") : text5)));
							LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "请求失败");
							_0024VB_0024Me.RefreshUi();
							end_IL_01a8:;
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00243 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00243).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00244 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00244).Dispose();
						}
					}
					end_IL_0021:;
				}
				catch (TaskCanceledException val3)
				{
					ProjectData.SetProjectError((System.Exception)val3);
					TaskCanceledException val4 = val3;
					_0024VB_0024Me.Log("请求超时（10秒）");
					_0024VB_0024Me.Log($"超时详情：{((System.Exception)(object)val4).Message}");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "timeout", "请求超时");
					_0024VB_0024Me.RefreshUi();
					ProjectData.ClearProjectError();
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"发生错误：{((MemberInfo)ex2.GetType()).Name}");
					_0024VB_0024Me.Log($"错误消息：{ex2.Message}");
					if (ex2.InnerException != null)
					{
						_0024VB_0024Me.Log($"内部错误：{ex2.InnerException.Message}");
					}
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "网络错误");
					_0024VB_0024Me.RefreshUi();
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_50_GetMeFrpUserInfoAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_cookieText;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal HttpResponseMessage _0024VB_0024ResumableLocal_response_00240;

		internal HttpClient _0024VB_0024ResumableLocal_client_00241;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00242;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		internal TaskAwaiter _0024A2;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0803: Unknown result type (might be due to invalid IL or missing references)
			//IL_0809: Expected O, but got Unknown
			//IL_080b: Expected O, but got Unknown
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Expected O, but got Unknown
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_028f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_029c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0521: Unknown result type (might be due to invalid IL or missing references)
			//IL_0526: Unknown result type (might be due to invalid IL or missing references)
			//IL_052e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0719: Unknown result type (might be due to invalid IL or missing references)
			//IL_071e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0726: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Expected O, but got Unknown
			//IL_0201: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_053d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0735: Unknown result type (might be due to invalid IL or missing references)
			//IL_074e: Unknown result type (might be due to invalid IL or missing references)
			//IL_026b: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0652: Unknown result type (might be due to invalid IL or missing references)
			//IL_065c: Invalid comparison between Unknown and I4
			//IL_06db: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3 && (uint)num > 3u)
				{
					_0024VB_0024Me.Log("===== 开始获取 MeFrp 用户信息 =====");
				}
				try
				{
					if (num == -3 || (uint)num <= 3u)
					{
						goto IL_010b;
					}
					if (!string.IsNullOrWhiteSpace(_0024VB_0024Local_token))
					{
						_0024VB_0024Me.Log($"Token 内容长度：{_0024VB_0024Local_token.Length}");
						string text = _0024VB_0024Me.ConvertCookieTextToHeader(_0024VB_0024Local_cookieText);
						_0024VB_0024Me.Log(string.Format("Cookie Header: {0}", (object)((text.Length > 100) ? (text.Substring(0, 100) + "...") : text)));
						_0024VB_0024Me.Log("正在向 MeFrp 请求用户信息...");
						_0024VB_0024ResumableLocal_handler_00242 = new HttpClientHandler
						{
							UseCookies = false
						};
						goto IL_010b;
					}
					_0024VB_0024Me.Log("错误：Token 为空");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "Token错误");
					_0024VB_0024Me.RefreshUi();
					goto end_IL_0021;
					IL_010b:
					try
					{
						if (num != -3 && (uint)num > 3u)
						{
							_0024VB_0024ResumableLocal_client_00241 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00242);
						}
						try
						{
							TaskAwaiter val;
							HttpResponseMessage result;
							TaskAwaiter<HttpResponseMessage> awaiter3;
							string result2;
							TaskAwaiter<string> awaiter2;
							string text2;
							TaskAwaiter<string> awaiter;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
								_0024VB_0024ResumableLocal_client_00241.Timeout = TimeSpan.FromSeconds(10.0);
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00241.DefaultRequestHeaders).Add("Authorization", $"Bearer {_0024VB_0024Local_token}");
								awaiter3 = _0024VB_0024ResumableLocal_client_00241.GetAsync("https://api.mefrp.com/api/auth/user/info").GetAwaiter();
								if (!awaiter3.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter3;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_50_GetMeFrpUserInfoAsync>(ref awaiter3, ref _this);
									return;
								}
								goto IL_01f7;
							case 0:
								num = (_0024State = -1);
								awaiter3 = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								goto IL_01f7;
							case 1:
								num = (_0024State = -1);
								awaiter2 = _0024A1;
								_0024A1 = default(TaskAwaiter<string>);
								goto IL_02a2;
							case 2:
								num = (_0024State = -1);
								val = _0024A2;
								_0024A2 = default(TaskAwaiter);
								goto IL_0534;
							case 3:
								{
									num = (_0024State = -1);
									awaiter = _0024A1;
									_0024A1 = default(TaskAwaiter<string>);
									break;
								}
								IL_01f7:
								result = awaiter3.GetResult();
								awaiter3 = default(TaskAwaiter<HttpResponseMessage>);
								_0024VB_0024ResumableLocal_response_00240 = result;
								_0024VB_0024Me.Log("发送请求获取节点名称1列表");
								_0024VB_0024Me.Log($"收到响应：{_0024VB_0024ResumableLocal_response_00240.StatusCode}");
								awaiter2 = _0024VB_0024ResumableLocal_response_00240.Content.ReadAsStringAsync().GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 1);
									_0024A1 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_50_GetMeFrpUserInfoAsync>(ref awaiter2, ref _this);
									return;
								}
								goto IL_02a2;
								IL_0534:
								val.GetResult();
								val = default(TaskAwaiter);
								goto end_IL_0126;
								IL_02a2:
								result2 = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<string>);
								text2 = result2;
								_0024VB_0024Me.Log(string.Format("响应内容：{0}", (object)((text2.Length > 200) ? (text2.Substring(0, 200) + "...") : text2)));
								if (_0024VB_0024ResumableLocal_response_00240.IsSuccessStatusCode)
								{
									JObject jObject = JObject.Parse(text2);
									JToken? jToken = jObject["code"];
									if (jToken != null && jToken.Value<int>() == 200)
									{
										JToken jToken2 = jObject["data"];
										string text3 = jToken2["username"]?.ToString();
										string text4 = jToken2["email"]?.ToString();
										long? num2 = jToken2["traffic"]?.Value<long>();
										string text5 = jToken2["friendlyGroup"]?.ToString();
										int? num3 = jToken2["usedProxies"]?.Value<int>();
										JToken? jToken3 = jToken2["isRealname"];
										if (jToken3 != null)
										{
											new bool?(jToken3.Value<bool>());
										}
										LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, _0024VB_0024Local_token, text3 ?? text4);
										_0024VB_0024Me._username = text3 ?? text4;
										_0024VB_0024Me._trafficGB = (num2.HasValue ? ((double)num2.Value / 1024.0) : 0.0);
										_0024VB_0024Me._friendlyGroup = text5 ?? "未知";
										_0024VB_0024Me._proxiesCount = num3.GetValueOrDefault();
										_0024VB_0024Me.Log($"登录成功！用户：{_0024VB_0024Me._username}，剩余流量：{_0024VB_0024Me._trafficGB:F2} GB，权限组：{_0024VB_0024Me._friendlyGroup}");
										_0024VB_0024Me.UpdateUserInfoUI();
										_0024VB_0024Me.RefreshUi();
										val = _0024VB_0024Me.GetMeFrpProxiesAsync(_0024VB_0024Local_token).GetAwaiter();
										if (!val.IsCompleted)
										{
											num = (_0024State = 2);
											_0024A2 = val;
											_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_50_GetMeFrpUserInfoAsync>(ref val, ref _this);
											return;
										}
										goto IL_0534;
									}
									string text6 = jObject["message"]?.ToString();
									_0024VB_0024Me.Log($"API 返回失败：{text6}");
									_0024VB_0024Me.Log($"完整响应：{text2}");
									JToken? jToken4 = jObject["code"];
									if (jToken4 != null && jToken4.Value<int>() == 401)
									{
										_0024VB_0024Me.Log("Token 无效，自动退出登录");
										ModBase.Setup.Set("LinkMeFrpCookies", "");
										ModBase.Setup.Set("LinkMeFrpToken", "");
										LinkProviderRegistry.SignOut(_0024VB_0024Me.Provider.Kind);
										_0024VB_0024Me.RefreshUi();
										ModMain.Hint("登录已过期，请重新登录！", ModMain.HintType.Critical);
									}
									else
									{
										LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "API错误");
										_0024VB_0024Me.RefreshUi();
									}
								}
								else
								{
									if ((int)_0024VB_0024ResumableLocal_response_00240.StatusCode != 401)
									{
										awaiter = _0024VB_0024ResumableLocal_response_00240.Content.ReadAsStringAsync().GetAwaiter();
										if (!awaiter.IsCompleted)
										{
											num = (_0024State = 3);
											_0024A1 = awaiter;
											_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_50_GetMeFrpUserInfoAsync>(ref awaiter, ref _this);
											return;
										}
										break;
									}
									_0024VB_0024Me.Log("Token 无效（401），自动退出登录");
									ModBase.Setup.Set("LinkMeFrpCookies", "");
									ModBase.Setup.Set("LinkMeFrpToken", "");
									LinkProviderRegistry.SignOut(_0024VB_0024Me.Provider.Kind);
									_0024VB_0024Me.RefreshUi();
									ModMain.Hint("登录已过期，请重新登录！", ModMain.HintType.Critical);
								}
								goto end_IL_0126;
							}
							string result3 = awaiter.GetResult();
							awaiter = default(TaskAwaiter<string>);
							string text7 = result3;
							_0024VB_0024Me.Log($"HTTP 请求失败：{_0024VB_0024ResumableLocal_response_00240.StatusCode}");
							_0024VB_0024Me.Log(string.Format("错误详情：{0}", (object)((text7.Length > 200) ? (text7.Substring(0, 200) + "...") : text7)));
							LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "请求失败");
							_0024VB_0024Me.RefreshUi();
							end_IL_0126:;
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00241 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00241).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00242 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00242).Dispose();
						}
					}
					end_IL_0021:;
				}
				catch (TaskCanceledException val2)
				{
					ProjectData.SetProjectError((System.Exception)val2);
					TaskCanceledException val3 = val2;
					_0024VB_0024Me.Log("请求超时（10秒）");
					_0024VB_0024Me.Log($"超时详情：{((System.Exception)(object)val3).Message}");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "timeout", "请求超时");
					_0024VB_0024Me.RefreshUi();
					ProjectData.ClearProjectError();
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"发生错误：{((MemberInfo)ex2.GetType()).Name}");
					_0024VB_0024Me.Log($"错误消息：{ex2.Message}");
					if (ex2.InnerException != null)
					{
						_0024VB_0024Me.Log($"内部错误：{ex2.InnerException.Message}");
					}
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "网络错误");
					_0024VB_0024Me.RefreshUi();
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_51_GetMeFrpProxiesAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal System.Collections.Generic.IEnumerator<JToken> _0024S0;

		internal List<ProxyInfo> _0024VB_0024ResumableLocal_proxies_00241;

		internal HttpClient _0024VB_0024ResumableLocal_client_00242;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00243;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		internal TaskAwaiter _0024A2;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Unknown result type (might be due to invalid IL or missing references)
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_0558: Unknown result type (might be due to invalid IL or missing references)
			//IL_055d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0565: Unknown result type (might be due to invalid IL or missing references)
			//IL_05c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Invalid comparison between Unknown and I4
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Unknown result type (might be due to invalid IL or missing references)
			//IL_0574: Unknown result type (might be due to invalid IL or missing references)
			//IL_058b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0590: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Expected O, but got Unknown
			//IL_05a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_063e: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Expected O, but got Unknown
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Unknown result type (might be due to invalid IL or missing references)
			//IL_051a: Unknown result type (might be due to invalid IL or missing references)
			//IL_051f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0534: Unknown result type (might be due to invalid IL or missing references)
			//IL_0536: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 3;
				}
				try
				{
					if (num != -3 && (uint)num > 3u)
					{
						_0024VB_0024Me.Log("===== 开始获取 MeFrp 隧道列表 =====");
						_0024VB_0024ResumableLocal_handler_00243 = new HttpClientHandler
						{
							UseCookies = false
						};
					}
					try
					{
						if (num != -3 && (uint)num > 3u)
						{
							_0024VB_0024ResumableLocal_client_00242 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00243);
						}
						try
						{
							TaskAwaiter val2;
							TaskAwaiter val;
							HttpResponseMessage result;
							TaskAwaiter<HttpResponseMessage> awaiter2;
							HttpResponseMessage val3;
							string result2;
							TaskAwaiter<string> awaiter;
							string text;
							JObject jObject;
							JToken? jToken;
							string text3;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
								_0024VB_0024ResumableLocal_client_00242.Timeout = TimeSpan.FromSeconds(10.0);
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00242.DefaultRequestHeaders).Add("Authorization", $"Bearer {_0024VB_0024Local_token}");
								awaiter2 = _0024VB_0024ResumableLocal_client_00242.GetAsync("https://api.mefrp.com/api/auth/proxy/list").GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_51_GetMeFrpProxiesAsync>(ref awaiter2, ref _this);
									return;
								}
								goto IL_0129;
							case 0:
								num = (_0024State = -1);
								awaiter2 = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								goto IL_0129;
							case 1:
								num = (_0024State = -1);
								awaiter = _0024A1;
								_0024A1 = default(TaskAwaiter<string>);
								goto IL_025b;
							case 2:
								num = (_0024State = -1);
								val2 = _0024A2;
								_0024A2 = default(TaskAwaiter);
								goto IL_056b;
							case 3:
								{
									num = (_0024State = -1);
									val = _0024A2;
									_0024A2 = default(TaskAwaiter);
									goto IL_05dc;
								}
								IL_056b:
								val2.GetResult();
								val2 = default(TaskAwaiter);
								val = _0024VB_0024Me.TestMeFrpProxiesLatencyAsync(_0024VB_0024ResumableLocal_proxies_00241).GetAwaiter();
								if (!val.IsCompleted)
								{
									num = (_0024State = 3);
									_0024A2 = val;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_51_GetMeFrpProxiesAsync>(ref val, ref _this);
									return;
								}
								goto IL_05dc;
								IL_0129:
								result = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
								val3 = result;
								if ((int)val3.StatusCode == 401)
								{
									_0024VB_0024Me.Log("Token 无效（401），自动退出登录");
									ModBase.Setup.Set("LinkMeFrpCookies", "");
									ModBase.Setup.Set("LinkMeFrpToken", "");
									LinkProviderRegistry.SignOut(_0024VB_0024Me.Provider.Kind);
									((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] [CompilerGenerated] () =>
									{
										_0024VB_0024Me.RefreshUi();
									}));
									Dispatcher dispatcher = ((DispatcherObject)_0024VB_0024Me).Dispatcher;
									object obj;
									if (_Closure_0024__._0024I51_002D1 != null)
									{
										obj = _Closure_0024__._0024I51_002D1;
									}
									else
									{
										Action val4 = [SpecialName] () =>
										{
											ModMain.Hint("登录已过期，请重新登录！", ModMain.HintType.Critical);
										};
										_Closure_0024__._0024I51_002D1 = val4;
										obj = (object)val4;
									}
									dispatcher.Invoke((Action)obj);
									break;
								}
								if (val3.IsSuccessStatusCode)
								{
									awaiter = val3.Content.ReadAsStringAsync().GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_0024State = 1);
										_0024A1 = awaiter;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_51_GetMeFrpProxiesAsync>(ref awaiter, ref _this);
										return;
									}
									goto IL_025b;
								}
								_0024VB_0024Me.Log($"HTTP 请求失败：{val3.StatusCode}");
								break;
								IL_025b:
								result2 = awaiter.GetResult();
								awaiter = default(TaskAwaiter<string>);
								text = result2;
								_0024VB_0024Me.Log(string.Format("隧道列表响应: {0}", (object)((text.Length > 200) ? (text.Substring(0, 200) + "...") : text)));
								jObject = JObject.Parse(text);
								jToken = jObject["code"];
								if (jToken != null && jToken.Value<int>() == 200)
								{
									JToken jToken2 = jObject["data"];
									_0024VB_0024ResumableLocal_proxies_00241 = new List<ProxyInfo>();
									try
									{
										_0024S0 = ((System.Collections.Generic.IEnumerable<JToken>)jToken2).GetEnumerator();
										while (((System.Collections.IEnumerator)_0024S0).MoveNext())
										{
											JToken current = _0024S0.Current;
											string text2 = current["proxyType"]?.ToString();
											if (Operators.CompareString(text2, "tcp", false) == 0)
											{
												ProxyInfo proxyInfo = new ProxyInfo
												{
													ProxyId = (current["proxyId"]?.Value<int>()).Value,
													ProxyName = current["proxyName"]?.ToString(),
													ProxyType = text2,
													RemotePort = (current["remotePort"]?.Value<int>()).Value,
													NodeId = (current["nodeId"]?.Value<int>()).Value,
													IsOnline = (current["isOnline"]?.Value<bool>()).Value
												};
												_0024VB_0024ResumableLocal_proxies_00241.Add(proxyInfo);
												_0024VB_0024Me.Log($"找到TCP隧道: {proxyInfo.ProxyName} (ID: {proxyInfo.ProxyId}, RemotePort: {proxyInfo.RemotePort})");
											}
										}
									}
									finally
									{
										if (num < 0 && _0024S0 != null)
										{
											((System.IDisposable)_0024S0)?.Dispose();
										}
									}
									_0024VB_0024Me._proxiesCount = _0024VB_0024ResumableLocal_proxies_00241.Count;
									_0024VB_0024Me.UpdateUserInfoUI();
									_0024VB_0024Me.Log($"共找到 {_0024VB_0024ResumableLocal_proxies_00241.Count} 个TCP隧道");
									if (_0024VB_0024ResumableLocal_proxies_00241.Count > 0)
									{
										val2 = _0024VB_0024Me.GetMeFrpNodeNamesAsync(_0024VB_0024Local_token, _0024VB_0024ResumableLocal_proxies_00241).GetAwaiter();
										if (!val2.IsCompleted)
										{
											num = (_0024State = 2);
											_0024A2 = val2;
											_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_51_GetMeFrpProxiesAsync>(ref val2, ref _this);
											return;
										}
										goto IL_056b;
									}
									_0024VB_0024Me.Log("没有可用的TCP隧道");
									break;
								}
								text3 = jObject["message"]?.ToString();
								_0024VB_0024Me.Log($"API 返回失败：{text3}");
								break;
								IL_05dc:
								val.GetResult();
								val = default(TaskAwaiter);
								break;
							}
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00242 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00242).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00243 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00243).Dispose();
						}
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"获取隧道列表出错：{ex2.Message}");
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_52_GetMeFrpNodeNamesAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_token;

		internal List<ProxyInfo> _0024VB_0024Local_proxies;

		internal PageLinkLobby _0024VB_0024Me;

		internal System.Collections.Generic.IEnumerator<JToken> _0024S0;

		internal System.Collections.Generic.IEnumerator<ProxyInfo> _0024S1;

		internal HttpClient _0024VB_0024ResumableLocal_client_00242;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00243;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0336: Unknown result type (might be due to invalid IL or missing references)
			//IL_033b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0368: Unknown result type (might be due to invalid IL or missing references)
			//IL_036d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0371: Unknown result type (might be due to invalid IL or missing references)
			//IL_037f: Unknown result type (might be due to invalid IL or missing references)
			//IL_02da: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					if (num != -3 && (uint)num > 1u)
					{
						_0024VB_0024Me.Log("===== 开始获取 MeFrp 节点名称 =====");
						_0024VB_0024ResumableLocal_handler_00243 = new HttpClientHandler
						{
							UseCookies = false
						};
					}
					try
					{
						if (num != -3 && (uint)num > 1u)
						{
							_0024VB_0024ResumableLocal_client_00242 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00243);
						}
						try
						{
							HttpResponseMessage result;
							TaskAwaiter<HttpResponseMessage> awaiter2;
							HttpResponseMessage val;
							TaskAwaiter<string> awaiter;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
								_0024VB_0024ResumableLocal_client_00242.Timeout = TimeSpan.FromSeconds(10.0);
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00242.DefaultRequestHeaders).Add("Authorization", $"Bearer {_0024VB_0024Local_token}");
								awaiter2 = _0024VB_0024ResumableLocal_client_00242.GetAsync("https://api.mefrp.com/api/auth/node/nameList").GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_52_GetMeFrpNodeNamesAsync>(ref awaiter2, ref _this);
									return;
								}
								goto IL_0121;
							case 0:
								num = (_0024State = -1);
								awaiter2 = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								goto IL_0121;
							case 1:
								{
									num = (_0024State = -1);
									awaiter = _0024A1;
									_0024A1 = default(TaskAwaiter<string>);
									break;
								}
								IL_0121:
								result = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
								val = result;
								_0024VB_0024Me.Log("发送请求获取节点名称列表");
								if (val.IsSuccessStatusCode)
								{
									awaiter = val.Content.ReadAsStringAsync().GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_0024State = 1);
										_0024A1 = awaiter;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_52_GetMeFrpNodeNamesAsync>(ref awaiter, ref _this);
										return;
									}
									break;
								}
								goto end_IL_0058;
							}
							string result2 = awaiter.GetResult();
							awaiter = default(TaskAwaiter<string>);
							string text = result2;
							_0024VB_0024Me.Log(string.Format("节点列表响应: {0}", (object)((text.Length > 200) ? (text.Substring(0, 200) + "...") : text)));
							JObject jObject = JObject.Parse(text);
							JToken? jToken = jObject["code"];
							if (jToken != null && jToken.Value<int>() == 200)
							{
								JToken jToken2 = jObject["data"];
								Dictionary<int, ValueTuple<string, string>> val2 = new Dictionary<int, ValueTuple<string, string>>();
								try
								{
									_0024S0 = ((System.Collections.Generic.IEnumerable<JToken>)jToken2).GetEnumerator();
									while (((System.Collections.IEnumerator)_0024S0).MoveNext())
									{
										JToken current = _0024S0.Current;
										int? num2 = current["nodeId"]?.Value<int>();
										string text2 = current["name"]?.ToString();
										string text3 = current["hostname"]?.ToString()?.Trim();
										if (num2.HasValue && !string.IsNullOrWhiteSpace(text2))
										{
											val2[num2.Value] = new ValueTuple<string, string>(text2, text3);
											_0024VB_0024Me.Log($"节点 {num2}: {text2} ({text3})");
										}
									}
								}
								finally
								{
									if (num < 0 && _0024S0 != null)
									{
										((System.IDisposable)_0024S0)?.Dispose();
									}
								}
								try
								{
									_0024S1 = _0024VB_0024Local_proxies.GetEnumerator();
									while (_0024S1.MoveNext())
									{
										ProxyInfo current2 = _0024S1.Current;
										if (val2.ContainsKey(current2.NodeId))
										{
											ValueTuple<string, string> val3 = val2[current2.NodeId];
											current2.NodeName = val3.Item1;
											current2.ConnectAddress = val3.Item2;
											_0024VB_0024Me.Log($"隧道 {current2.ProxyName} 使用节点: {current2.NodeName} ({current2.ConnectAddress})");
										}
									}
								}
								finally
								{
									if (num < 0)
									{
										((System.IDisposable)_0024S1).Dispose();
									}
								}
							}
							end_IL_0058:;
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00242 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00242).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00243 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00243).Dispose();
						}
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"获取节点名称出错：{ex2.Message}");
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal List<ProxyInfo> _0024VB_0024Local_proxies;

		internal PageLinkLobby _0024VB_0024Me;

		internal System.Collections.Generic.IEnumerator<ProxyInfo> _0024S0;

		internal _Closure_0024__53_002D1 _0024VB_0024ResumableLocal__0024VB_0024Closure__00241;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Expected O, but got Unknown
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
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
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00241 = new _Closure_0024__53_002D1(_0024VB_0024ResumableLocal__0024VB_0024Closure__00241);
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Me = _0024VB_0024Me;
						_0024VB_0024Me.Log("===== 开始测试 MeFrp 隧道延迟 =====");
						List<System.Threading.Tasks.Task> val2 = new List<System.Threading.Tasks.Task>();
						try
						{
							_0024S0 = _0024VB_0024Local_proxies.GetEnumerator();
							_Closure_0024__53_002D0 closure_0024__53_002D = default(_Closure_0024__53_002D0);
							while (_0024S0.MoveNext())
							{
								closure_0024__53_002D = new _Closure_0024__53_002D0(closure_0024__53_002D)
								{
									_0024VB_0024NonLocal__0024VB_0024Closure_2 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241,
									_0024VB_0024Local_proxy = _0024S0.Current
								};
								val2.Add(System.Threading.Tasks.Task.Run((Func<System.Threading.Tasks.Task>)closure_0024__53_002D._Lambda_0024__0));
							}
						}
						finally
						{
							if (num < 0)
							{
								((System.IDisposable)_0024S0)?.Dispose();
							}
						}
						val = System.Threading.Tasks.Task.WhenAll((System.Collections.Generic.IEnumerable<System.Threading.Tasks.Task>)val2).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync>(ref val, ref _this);
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
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_sortedProxies = Enumerable.ToList<ProxyInfo>((System.Collections.Generic.IEnumerable<ProxyInfo>)Enumerable.OrderBy<ProxyInfo, int>((System.Collections.Generic.IEnumerable<ProxyInfo>)_0024VB_0024Local_proxies, (Func<ProxyInfo, int>)([SpecialName] (ProxyInfo p) => (p.Latency <= 0) ? 2147483647 : p.Latency)));
					((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
					{
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						//IL_0011: Unknown result type (might be due to invalid IL or missing references)
						List<TunnelItem> val3 = new List<TunnelItem>();
						System.Collections.Generic.IEnumerator<ProxyInfo> enumerator = default(System.Collections.Generic.IEnumerator<ProxyInfo>);
						try
						{
							enumerator = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_sortedProxies.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ProxyInfo current = enumerator.Current;
								val3.Add(new TunnelItem
								{
									Proxy = current,
									DisplayText = $"{current.ProxyName} [{current.NodeName}] - 端口 {current.RemotePort}" + ((current.Latency > 0) ? $" ({current.Latency}ms)" : " (超时)")
								});
							}
						}
						finally
						{
							((System.IDisposable)enumerator).Dispose();
						}
						((ItemsControl)_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Me.ComboTunnel).ItemsSource = (System.Collections.IEnumerable)val3;
						((ItemsControl)_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Me.ComboTunnel).DisplayMemberPath = "DisplayText";
						if (val3.Count > 0)
						{
							((Selector)_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Me.ComboTunnel).SelectedIndex = 0;
						}
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Me.Log($"已加载 {val3.Count} 个隧道到列表");
					}));
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"测试延迟出错：{ex2.Message}");
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_54_ClearXhfrpLocalStorageAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal PageLinkLobby _0024VB_0024Me;

		internal _Closure_0024__54_002D0 _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;

		internal EventHandler<CoreWebView2NavigationCompletedEventArgs> _0024VB_0024ResumableLocal_handler_00241;

		internal Panel _0024VB_0024ResumableLocal_host_00242;

		internal TaskAwaiter _0024A0;

		internal TaskAwaiter<System.Threading.Tasks.Task> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Expected O, but got Unknown
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					TaskAwaiter val;
					TaskAwaiter<System.Threading.Tasks.Task> awaiter;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240 = new _Closure_0024__54_002D0();
						_0024VB_0024ResumableLocal_host_00242 = (Panel)(object)_0024VB_0024Me.PanLogin;
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview = new WebView2
						{
							Visibility = (Visibility)2,
							Width = 0.0,
							Height = 0.0
						};
						_0024VB_0024Me.SetWebView2UserDataFolder(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview);
						if (_0024VB_0024ResumableLocal_host_00242 != null)
						{
							_0024VB_0024ResumableLocal_host_00242.Children.Add((UIElement)(object)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview);
						}
						val = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.EnsureCoreWebView2Async((CoreWebView2Environment)null, (CoreWebView2ControllerOptions)null).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_54_ClearXhfrpLocalStorageAsync>(ref val, ref _this);
							return;
						}
						goto IL_0129;
					case 0:
						num = (_0024State = -1);
						val = _0024A0;
						_0024A0 = default(TaskAwaiter);
						goto IL_0129;
					case 1:
						{
							num = (_0024State = -1);
							awaiter = _0024A1;
							_0024A1 = default(TaskAwaiter<System.Threading.Tasks.Task>);
							break;
						}
						IL_0129:
						val.GetResult();
						val = default(TaskAwaiter);
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_tcs = new TaskCompletionSource<bool>();
						_0024VB_0024ResumableLocal_handler_00241 = null;
						_0024VB_0024ResumableLocal_handler_00241 = [SpecialName] [AsyncStateMachine(typeof(_Closure_0024__54_002D0.VB_0024StateMachine___Lambda_0024__0))] (object s, CoreWebView2NavigationCompletedEventArgs e) =>
						{
							//IL_002a: Unknown result type (might be due to invalid IL or missing references)
							//IL_002f: Unknown result type (might be due to invalid IL or missing references)
							_Closure_0024__54_002D0.VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(_Closure_0024__54_002D0.VB_0024StateMachine___Lambda_0024__0);
							vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__54_002D0 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;
							vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_s = s;
							vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_e = e;
							vB_0024StateMachine___Lambda_0024__._0024State = -1;
							vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncVoidMethodBuilder.Create();
							vB_0024StateMachine___Lambda_0024__._0024Builder.Start<_Closure_0024__54_002D0.VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
						};
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.NavigationCompleted += _0024VB_0024ResumableLocal_handler_00241;
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.Source = new Uri("https://console.xhfrp.xhuzim.top/");
						awaiter = System.Threading.Tasks.Task.WhenAny((System.Threading.Tasks.Task)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_tcs.Task, System.Threading.Tasks.Task.Delay(5000)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 1);
							_0024A1 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<System.Threading.Tasks.Task>, VB_0024StateMachine_54_ClearXhfrpLocalStorageAsync>(ref awaiter, ref _this);
							return;
						}
						break;
					}
					awaiter.GetResult();
					awaiter = default(TaskAwaiter<System.Threading.Tasks.Task>);
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.NavigationCompleted -= _0024VB_0024ResumableLocal_handler_00241;
					try
					{
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.Stop();
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					if (_0024VB_0024ResumableLocal_host_00242 != null)
					{
						_0024VB_0024ResumableLocal_host_00242.Children.Remove((UIElement)(object)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview);
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"星穿月联 清理 localStorage 失败：{ex2.Message}");
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal PageLinkLobby _0024VB_0024Me;

		internal _Closure_0024__55_002D0 _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;

		internal EventHandler<CoreWebView2NavigationCompletedEventArgs> _0024VB_0024ResumableLocal_handler_00241;

		internal Panel _0024VB_0024ResumableLocal_host_00242;

		internal TaskAwaiter _0024A0;

		internal TaskAwaiter<System.Threading.Tasks.Task> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Expected O, but got Unknown
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					TaskAwaiter val;
					TaskAwaiter<System.Threading.Tasks.Task> awaiter;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240 = new _Closure_0024__55_002D0();
						_0024VB_0024ResumableLocal_host_00242 = (Panel)(object)_0024VB_0024Me.PanLogin;
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview = new WebView2
						{
							Visibility = (Visibility)2,
							Width = 0.0,
							Height = 0.0
						};
						_0024VB_0024Me.SetWebView2UserDataFolder(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview);
						if (_0024VB_0024ResumableLocal_host_00242 != null)
						{
							_0024VB_0024ResumableLocal_host_00242.Children.Add((UIElement)(object)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview);
						}
						val = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.EnsureCoreWebView2Async((CoreWebView2Environment)null, (CoreWebView2ControllerOptions)null).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync>(ref val, ref _this);
							return;
						}
						goto IL_0129;
					case 0:
						num = (_0024State = -1);
						val = _0024A0;
						_0024A0 = default(TaskAwaiter);
						goto IL_0129;
					case 1:
						{
							num = (_0024State = -1);
							awaiter = _0024A1;
							_0024A1 = default(TaskAwaiter<System.Threading.Tasks.Task>);
							break;
						}
						IL_0129:
						val.GetResult();
						val = default(TaskAwaiter);
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_tcs = new TaskCompletionSource<bool>();
						_0024VB_0024ResumableLocal_handler_00241 = null;
						_0024VB_0024ResumableLocal_handler_00241 = [SpecialName] [AsyncStateMachine(typeof(_Closure_0024__55_002D0.VB_0024StateMachine___Lambda_0024__0))] (object s, CoreWebView2NavigationCompletedEventArgs e) =>
						{
							//IL_002a: Unknown result type (might be due to invalid IL or missing references)
							//IL_002f: Unknown result type (might be due to invalid IL or missing references)
							_Closure_0024__55_002D0.VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(_Closure_0024__55_002D0.VB_0024StateMachine___Lambda_0024__0);
							vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__55_002D0 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;
							vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_s = s;
							vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_e = e;
							vB_0024StateMachine___Lambda_0024__._0024State = -1;
							vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncVoidMethodBuilder.Create();
							vB_0024StateMachine___Lambda_0024__._0024Builder.Start<_Closure_0024__55_002D0.VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
						};
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.NavigationCompleted += _0024VB_0024ResumableLocal_handler_00241;
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.Source = new Uri("https://console.stellarfrp.top/");
						awaiter = System.Threading.Tasks.Task.WhenAny((System.Threading.Tasks.Task)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_tcs.Task, System.Threading.Tasks.Task.Delay(5000)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 1);
							_0024A1 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<System.Threading.Tasks.Task>, VB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync>(ref awaiter, ref _this);
							return;
						}
						break;
					}
					awaiter.GetResult();
					awaiter = default(TaskAwaiter<System.Threading.Tasks.Task>);
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.NavigationCompleted -= _0024VB_0024ResumableLocal_handler_00241;
					try
					{
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview.Stop();
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					if (_0024VB_0024ResumableLocal_host_00242 != null)
					{
						_0024VB_0024ResumableLocal_host_00242.Children.Remove((UIElement)(object)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_webview);
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"Stellarfrp 清理 localStorage 失败：{ex2.Message}");
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_56_GetStellarfrpUserInfoAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal string _0024VB_0024ResumableLocal_url_00240;

		internal HttpResponseMessage _0024VB_0024ResumableLocal_response_00241;

		internal HttpClient _0024VB_0024ResumableLocal_client_00242;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00243;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		internal TaskAwaiter _0024A2;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_06da: Expected O, but got Unknown
			//IL_06dc: Expected O, but got Unknown
			//IL_04af: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0509: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Expected O, but got Unknown
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Expected O, but got Unknown
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0201: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_056b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0575: Invalid comparison between Unknown and I4
			//IL_0603: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3 && (uint)num > 2u)
				{
					_0024VB_0024Me.Log("===== 开始获取 Stellarfrp 用户信息 =====");
				}
				try
				{
					if (num == -3 || (uint)num <= 2u)
					{
						goto IL_00a4;
					}
					if (!string.IsNullOrWhiteSpace(_0024VB_0024Local_token))
					{
						_0024VB_0024Me.Log($"Token 内容长度：{_0024VB_0024Local_token}");
						_0024VB_0024ResumableLocal_handler_00243 = new HttpClientHandler
						{
							UseCookies = false
						};
						goto IL_00a4;
					}
					_0024VB_0024Me.Log("错误：Token 为空");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "Token错误");
					_0024VB_0024Me.RefreshUi();
					goto end_IL_0021;
					IL_00a4:
					try
					{
						if (num != -3 && (uint)num > 2u)
						{
							_0024VB_0024ResumableLocal_client_00242 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00243);
						}
						try
						{
							if (num != -3 && (uint)num > 2u)
							{
								_0024VB_0024ResumableLocal_client_00242.Timeout = TimeSpan.FromSeconds(10.0);
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00242.DefaultRequestHeaders).Add("authorization", _0024VB_0024Local_token);
								_0024VB_0024ResumableLocal_url_00240 = "https://api.stellarfrp.top/api/v1/users/info";
							}
							try
							{
								TaskAwaiter val;
								HttpResponseMessage result;
								TaskAwaiter<HttpResponseMessage> awaiter2;
								string result2;
								TaskAwaiter<string> awaiter;
								string text;
								switch (num)
								{
								case -3:
									num = (_0024State = -1);
									return;
								default:
									awaiter2 = _0024VB_0024ResumableLocal_client_00242.GetAsync(_0024VB_0024ResumableLocal_url_00240).GetAwaiter();
									if (!awaiter2.IsCompleted)
									{
										num = (_0024State = 0);
										_0024A0 = awaiter2;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_56_GetStellarfrpUserInfoAsync>(ref awaiter2, ref _this);
										return;
									}
									goto IL_0198;
								case 0:
									num = (_0024State = -1);
									awaiter2 = _0024A0;
									_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
									goto IL_0198;
								case 1:
									num = (_0024State = -1);
									awaiter = _0024A1;
									_0024A1 = default(TaskAwaiter<string>);
									goto IL_0236;
								case 2:
									{
										num = (_0024State = -1);
										val = _0024A2;
										_0024A2 = default(TaskAwaiter);
										goto IL_0500;
									}
									IL_0500:
									val.GetResult();
									val = default(TaskAwaiter);
									break;
									IL_0198:
									result = awaiter2.GetResult();
									awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
									_0024VB_0024ResumableLocal_response_00241 = result;
									_0024VB_0024Me.Log($"请求 {_0024VB_0024ResumableLocal_url_00240} 返回：{_0024VB_0024ResumableLocal_response_00241.StatusCode}");
									awaiter = _0024VB_0024ResumableLocal_response_00241.Content.ReadAsStringAsync().GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_0024State = 1);
										_0024A1 = awaiter;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_56_GetStellarfrpUserInfoAsync>(ref awaiter, ref _this);
										return;
									}
									goto IL_0236;
									IL_0236:
									result2 = awaiter.GetResult();
									awaiter = default(TaskAwaiter<string>);
									text = result2;
									_0024VB_0024Me.Log(string.Format("响应内容：{0}", (object)((text.Length > 200) ? (text.Substring(0, 200) + "...") : text)));
									if (_0024VB_0024ResumableLocal_response_00241.IsSuccessStatusCode)
									{
										JObject jObject = JObject.Parse(text);
										JToken? jToken = jObject["code"];
										if (jToken != null && jToken.Value<int>() == 200)
										{
											JToken jToken2 = jObject["data"];
											string text2 = jToken2["Username"]?.ToString();
											long? num2 = jToken2["Traffic"]?.Value<long>();
											string text3 = jToken2["GroupName"]?.ToString();
											string text4 = jToken2["Tunnels"]?.ToString();
											LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, _0024VB_0024Local_token, text2 ?? "用户");
											_0024VB_0024Me._username = text2 ?? "用户";
											_0024VB_0024Me._friendlyGroup = text3 ?? "未知";
											if (num2.HasValue)
											{
												_0024VB_0024Me._trafficGB = (double)num2.Value / 1024.0 / 1024.0 / 1024.0;
											}
											else
											{
												_0024VB_0024Me._trafficGB = 0.0;
											}
											try
											{
												string[] array = (string.IsNullOrWhiteSpace(text4) ? null : text4.Split(new char[] { '/' }, (StringSplitOptions)1));
												if (array != null && array.Length > 0)
												{
													int.TryParse(array[0], out _0024VB_0024Me._proxiesCount);
												}
												else
												{
													_0024VB_0024Me._proxiesCount = 0;
												}
											}
											catch (System.Exception projectError)
											{
												ProjectData.SetProjectError(projectError);
												_0024VB_0024Me._proxiesCount = 0;
												ProjectData.ClearProjectError();
											}
											_0024VB_0024Me.Log($"登录成功！用户：{_0024VB_0024Me._username}，剩余流量：{_0024VB_0024Me._trafficGB:F2} GB，权限组：{_0024VB_0024Me._friendlyGroup}");
											_0024VB_0024Me.UpdateUserInfoUI();
											_0024VB_0024Me.RefreshUi();
											val = _0024VB_0024Me.GetStellarfrpProxiesAsync(_0024VB_0024Local_token).GetAwaiter();
											if (!val.IsCompleted)
											{
												num = (_0024State = 2);
												_0024A2 = val;
												_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_56_GetStellarfrpUserInfoAsync>(ref val, ref _this);
												return;
											}
											goto IL_0500;
										}
										_0024VB_0024Me.Log(string.Format("API 返回失败：{0} - {1}", (object)jObject["msg"], (object)text));
										LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "API错误");
										_0024VB_0024Me.RefreshUi();
										break;
									}
									if ((int)_0024VB_0024ResumableLocal_response_00241.StatusCode == 401)
									{
										_0024VB_0024Me.Log("Token 无效（401），自动退出登录");
										try
										{
											ModBase.Setup.Set("LinkStellarfrpCookies", "");
											ModBase.Setup.Set("LinkStellarfrpToken", "");
										}
										catch (System.Exception projectError2)
										{
											ProjectData.SetProjectError(projectError2);
											ProjectData.ClearProjectError();
										}
										LinkProviderRegistry.SignOut(_0024VB_0024Me.Provider.Kind);
										_0024VB_0024Me.RefreshUi();
										ModMain.Hint("登录已过期，请重新登录！", ModMain.HintType.Critical);
									}
									else
									{
										_0024VB_0024Me.Log($"HTTP 请求失败：{_0024VB_0024ResumableLocal_response_00241.StatusCode}");
										LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "请求失败");
										_0024VB_0024Me.RefreshUi();
									}
									break;
								}
							}
							catch (System.Exception ex)
							{
								ProjectData.SetProjectError(ex);
								System.Exception ex2 = ex;
								_0024VB_0024Me.Log($"请求 {_0024VB_0024ResumableLocal_url_00240} 失败：{ex2.Message}");
								LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "网络错误");
								_0024VB_0024Me.RefreshUi();
								ProjectData.ClearProjectError();
							}
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00242 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00242).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00243 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00243).Dispose();
						}
					}
					end_IL_0021:;
				}
				catch (TaskCanceledException val2)
				{
					ProjectData.SetProjectError((System.Exception)val2);
					TaskCanceledException val3 = val2;
					_0024VB_0024Me.Log("请求超时（10秒）");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "timeout", "请求超时");
					_0024VB_0024Me.RefreshUi();
					ProjectData.ClearProjectError();
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					_0024VB_0024Me.Log($"发生错误：{((MemberInfo)ex4.GetType()).Name}");
					_0024VB_0024Me.Log($"错误消息：{ex4.Message}");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "网络错误");
					_0024VB_0024Me.RefreshUi();
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
	internal sealed class VB_0024StateMachine_57_GetStellarfrpProxiesAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal string _0024VB_0024ResumableLocal_url_00240;

		internal _Closure_0024__57_002D0 _0024VB_0024ResumableLocal__0024VB_0024Closure__00241;

		internal System.Collections.Generic.IEnumerator<JToken> _0024S2;

		internal HttpClient _0024VB_0024ResumableLocal_client_00243;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00244;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_054b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0555: Expected O, but got Unknown
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0563: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					if (num != -3 && (uint)num > 1u)
					{
						_0024VB_0024Me.Log("===== 开始获取 Stellarfrp 隧道列表 =====");
						_0024VB_0024ResumableLocal_handler_00244 = new HttpClientHandler
						{
							UseCookies = false
						};
					}
					try
					{
						if (num != -3 && (uint)num > 1u)
						{
							_0024VB_0024ResumableLocal_client_00243 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00244);
						}
						try
						{
							HttpResponseMessage result;
							TaskAwaiter<HttpResponseMessage> awaiter2;
							HttpResponseMessage val;
							string result2;
							TaskAwaiter<string> awaiter;
							string text;
							JToken jToken;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
								_0024VB_0024ResumableLocal_client_00243.Timeout = TimeSpan.FromSeconds(10.0);
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00243.DefaultRequestHeaders).Add("authorization", _0024VB_0024Local_token);
								_0024VB_0024ResumableLocal_url_00240 = "https://api.stellarfrp.top/api/v1/proxy/get?page=1&page_size=100";
								awaiter2 = _0024VB_0024ResumableLocal_client_00243.GetAsync(_0024VB_0024ResumableLocal_url_00240).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_57_GetStellarfrpProxiesAsync>(ref awaiter2, ref _this);
									return;
								}
								goto IL_0123;
							case 0:
								num = (_0024State = -1);
								awaiter2 = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								goto IL_0123;
							case 1:
								{
									num = (_0024State = -1);
									awaiter = _0024A1;
									_0024A1 = default(TaskAwaiter<string>);
									goto IL_01e2;
								}
								IL_0123:
								result = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
								val = result;
								_0024VB_0024Me.Log($"请求 {_0024VB_0024ResumableLocal_url_00240} 返回：{val.StatusCode}");
								if (val.IsSuccessStatusCode)
								{
									_0024VB_0024ResumableLocal__0024VB_0024Closure__00241 = new _Closure_0024__57_002D0(_0024VB_0024ResumableLocal__0024VB_0024Closure__00241);
									_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Me = _0024VB_0024Me;
									awaiter = val.Content.ReadAsStringAsync().GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_0024State = 1);
										_0024A1 = awaiter;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_57_GetStellarfrpProxiesAsync>(ref awaiter, ref _this);
										return;
									}
									goto IL_01e2;
								}
								_0024VB_0024Me.Log($"获取 隧道列表失败：{val.StatusCode}");
								break;
								IL_01e2:
								result2 = awaiter.GetResult();
								awaiter = default(TaskAwaiter<string>);
								text = result2;
								_0024VB_0024Me.Log(string.Format("隧道响应: {0}", (object)((text.Length > 200) ? (text.Substring(0, 200) + "...") : text)));
								jToken = JObject.Parse(text)["tunnel"];
								_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_proxies = new List<ProxyInfo>();
								if (jToken != null)
								{
									try
									{
										_0024S2 = ((System.Collections.Generic.IEnumerable<JToken>)jToken).GetEnumerator();
										while (((System.Collections.IEnumerator)_0024S2).MoveNext())
										{
											JProperty jProperty = (JProperty)_0024S2.Current;
											try
											{
												string name = jProperty.Name;
												JObject jObject = (JObject)jProperty.Value;
												ProxyInfo proxyInfo = new ProxyInfo
												{
													ProxyId = (jObject["Id"]?.Value<int>() ?? int.Parse(name)),
													ProxyName = (jObject["ProxyName"]?.ToString() ?? jObject["ProxyName"]?.ToString()),
													RemotePort = (jObject["RemotePort"]?.Value<int>() ?? 0),
													LocalPort = (jObject["LocalPort"]?.Value<int>() ?? 0),
													NodeId = (jObject["NodeId"]?.Value<int>() ?? 0),
													NodeName = (jObject["NodeName"]?.ToString() ?? ""),
													ProxyType = (jObject["ProxyType"]?.ToString() ?? jObject["Type"]?.ToString())
												};
												string text2 = jObject["Status"]?.ToString();
												proxyInfo.IsOnline = !string.Equals(text2, "offline", (StringComparison)5);
												string text3 = jObject["Link"]?.ToString();
												if (!string.IsNullOrWhiteSpace(text3))
												{
													proxyInfo.ConnectAddress = text3.Split(new char[] { ':' }, (StringSplitOptions)1)[0];
												}
												proxyInfo.ConfigText = jObject["data"]?.ToString() ?? "";
												if (string.IsNullOrWhiteSpace(proxyInfo.ConnectAddress) && !string.IsNullOrWhiteSpace(proxyInfo.ConfigText))
												{
													Match val2 = Regex.Match(proxyInfo.ConfigText, "serverAddr\\s*=\\s*\"(?<host>[^\"]+)\"");
													if (((Group)val2).Success)
													{
														proxyInfo.ConnectAddress = ((Capture)val2.Groups["host"]).Value;
													}
												}
												_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_proxies.Add(proxyInfo);
											}
											catch (System.Exception ex)
											{
												ProjectData.SetProjectError(ex);
												System.Exception ex2 = ex;
												_0024VB_0024Me.Log($"解析隧道项失败: {ex2.Message}");
												ProjectData.ClearProjectError();
											}
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
								_0024VB_0024Me._proxiesCount = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_proxies.Count;
								_0024VB_0024Me.UpdateUserInfoUI();
								((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
								{
									//IL_000c: Unknown result type (might be due to invalid IL or missing references)
									//IL_0011: Unknown result type (might be due to invalid IL or missing references)
									List<TunnelItem> val3 = new List<TunnelItem>();
									System.Collections.Generic.IEnumerator<ProxyInfo> enumerator = default(System.Collections.Generic.IEnumerator<ProxyInfo>);
									try
									{
										enumerator = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_proxies.GetEnumerator();
										while (enumerator.MoveNext())
										{
											ProxyInfo current = enumerator.Current;
											val3.Add(new TunnelItem
											{
												Proxy = current,
												DisplayText = $"{current.ProxyName} - 端口 {current.RemotePort}"
											});
										}
									}
									finally
									{
										((System.IDisposable)enumerator).Dispose();
									}
									((ItemsControl)_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Me.ComboTunnel).ItemsSource = (System.Collections.IEnumerable)val3;
									((ItemsControl)_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Me.ComboTunnel).DisplayMemberPath = "DisplayText";
									if (val3.Count > 0)
									{
										((Selector)_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Me.ComboTunnel).SelectedIndex = 0;
									}
								}));
								break;
							}
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00243 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00243).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00244 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00244).Dispose();
						}
					}
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					_0024VB_0024Me.Log($"获取 Stellarfrp 隧道列表失败：{ex4.Message}");
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
	internal sealed class VB_0024StateMachine_58_GetStellarfrpProxyConfigAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder<string> _0024Builder;

		internal int _0024VB_0024Local_proxyId;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal string _0024VB_0024ResumableLocal_url_00240;

		internal System.Collections.Generic.IEnumerator<JToken> _0024S1;

		internal HttpClient _0024VB_0024ResumableLocal_client_00242;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00243;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			string result3;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					if (num != -3 && (uint)num > 1u)
					{
						_0024VB_0024ResumableLocal_handler_00243 = new HttpClientHandler
						{
							UseCookies = false
						};
					}
					try
					{
						if (num != -3 && (uint)num > 1u)
						{
							_0024VB_0024ResumableLocal_client_00242 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00243);
						}
						try
						{
							HttpResponseMessage result;
							TaskAwaiter<HttpResponseMessage> awaiter2;
							HttpResponseMessage val;
							string result2;
							TaskAwaiter<string> awaiter;
							JToken jToken;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
								_0024VB_0024ResumableLocal_client_00242.Timeout = TimeSpan.FromSeconds(10.0);
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00242.DefaultRequestHeaders).Add("authorization", _0024VB_0024Local_token);
								_0024VB_0024ResumableLocal_url_00240 = "https://api.stellarfrp.top/api/v1/proxy/get?page=1&page_size=100";
								awaiter2 = _0024VB_0024ResumableLocal_client_00242.GetAsync(_0024VB_0024ResumableLocal_url_00240).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_58_GetStellarfrpProxyConfigAsync>(ref awaiter2, ref _this);
									return;
								}
								goto IL_0113;
							case 0:
								num = (_0024State = -1);
								awaiter2 = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								goto IL_0113;
							case 1:
								{
									num = (_0024State = -1);
									awaiter = _0024A1;
									_0024A1 = default(TaskAwaiter<string>);
									goto IL_01b0;
								}
								IL_0113:
								result = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
								val = result;
								_0024VB_0024Me.Log($"请求 {_0024VB_0024ResumableLocal_url_00240} 返回：{val.StatusCode}");
								if (val.IsSuccessStatusCode)
								{
									awaiter = val.Content.ReadAsStringAsync().GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_0024State = 1);
										_0024A1 = awaiter;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_58_GetStellarfrpProxyConfigAsync>(ref awaiter, ref _this);
										return;
									}
									goto IL_01b0;
								}
								_0024VB_0024Me.Log($"获取 隧道配置失败：{val.StatusCode}");
								break;
								IL_01b0:
								result2 = awaiter.GetResult();
								awaiter = default(TaskAwaiter<string>);
								jToken = JObject.Parse(result2)["tunnel"];
								if (object.ReferenceEquals((object)jToken, (object)null))
								{
									break;
								}
								try
								{
									_0024S1 = ((System.Collections.Generic.IEnumerable<JToken>)jToken).GetEnumerator();
									while (((System.Collections.IEnumerator)_0024S1).MoveNext())
									{
										JProperty jProperty = (JProperty)_0024S1.Current;
										try
										{
											string name = jProperty.Name;
											JObject jObject = (JObject)jProperty.Value;
											if ((jObject["Id"]?.Value<int>() ?? int.Parse(name)) != _0024VB_0024Local_proxyId)
											{
												goto end_IL_0201;
											}
											result3 = jObject["data"]?.ToString() ?? "";
											goto end_IL_0007;
											end_IL_0201:;
										}
										catch (System.Exception ex)
										{
											ProjectData.SetProjectError(ex);
											System.Exception ex2 = ex;
											ProjectData.ClearProjectError();
										}
									}
								}
								finally
								{
									if (num < 0 && _0024S1 != null)
									{
										((System.IDisposable)_0024S1).Dispose();
									}
								}
								break;
							}
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00242 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00242).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00243 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00243).Dispose();
						}
					}
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					_0024VB_0024Me.Log($"获取 Stellarfrp 配置失败：{ex4.Message}");
					ProjectData.ClearProjectError();
				}
				result3 = "";
				end_IL_0007:;
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
			_0024Builder.SetResult(result3);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_59_StartStellarfrpcTunnel : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal ProxyInfo _0024VB_0024Local_proxy;

		internal int _0024VB_0024Local_localPort;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal TaskAwaiter<string> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Expected O, but got Unknown
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Expected O, but got Unknown
			//IL_025e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Expected O, but got Unknown
			//IL_027f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Expected O, but got Unknown
			int num = _0024State;
			try
			{
				if (num != -3)
				{
				}
				try
				{
					TaskAwaiter<string> awaiter;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						_0024VB_0024Me.Log("===== 开始启动 Stellarfrp 隧道 =====");
						awaiter = _0024VB_0024Me.GetStellarfrpProxyConfigAsync(_0024VB_0024Local_proxy.ProxyId, _0024VB_0024Local_token).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_59_StartStellarfrpcTunnel>(ref awaiter, ref _this);
							return;
						}
						break;
					case 0:
						num = (_0024State = -1);
						awaiter = _0024A0;
						_0024A0 = default(TaskAwaiter<string>);
						break;
					}
					string result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<string>);
					string text = result;
					if (string.IsNullOrWhiteSpace(text))
					{
						_0024VB_0024Me.Log("获取 Stellarfrp 配置失败");
						ModMain.Hint("获取配置失败！", ModMain.HintType.Critical);
					}
					else
					{
						string text2 = _0024VB_0024Me.ModifyTomlConfig(text, _0024VB_0024Local_proxy.ProxyName, _0024VB_0024Local_localPort);
						if (string.IsNullOrWhiteSpace(text2))
						{
							_0024VB_0024Me.Log("解析 Stellarfrp 配置失败，使用原始配置");
							text2 = text;
						}
						string text3 = text2;
						_0024VB_0024Me.ExtractServerInfo(text3);
						string text4 = Path.Combine(ModBase.PathAppdata, "PCL", "Frpc", "Configs");
						if (!Directory.Exists(text4))
						{
							Directory.CreateDirectory(text4);
						}
						string text5 = Path.Combine(text4, $"{_0024VB_0024Local_proxy.ProxyName}_{System.DateTime.Now:yyyyMMddHHmmss}.toml");
						UTF8Encoding val = new UTF8Encoding(false);
						File.WriteAllText(text5, text3, (Encoding)(object)val);
						_0024VB_0024Me.Log($"配置文件已保存: {text5}");
						string frpcPath = ModLink.GetFrpcPath();
						_0024VB_0024Me._frpcProcess = new Process();
						_0024VB_0024Me._frpcProcess.StartInfo.FileName = frpcPath;
						_0024VB_0024Me._frpcProcess.StartInfo.Arguments = $"-c \"{text5}\"";
						_0024VB_0024Me._frpcProcess.StartInfo.UseShellExecute = false;
						_0024VB_0024Me._frpcProcess.StartInfo.RedirectStandardOutput = true;
						_0024VB_0024Me._frpcProcess.StartInfo.RedirectStandardError = true;
						_0024VB_0024Me._frpcProcess.StartInfo.CreateNoWindow = true;
						_0024VB_0024Me._frpcProcess.OutputDataReceived += (DataReceivedEventHandler)([SpecialName] [CompilerGenerated] (object s, DataReceivedEventArgs e) =>
						{
							//IL_0033: Unknown result type (might be due to invalid IL or missing references)
							//IL_003d: Expected O, but got Unknown
							_Closure_0024__59_002D0 CS_0024_003C_003E8__locals1 = new _Closure_0024__59_002D0
							{
								_0024VB_0024Me = _0024VB_0024Me,
								_0024VB_0024Local_e = e
							};
							if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1._0024VB_0024Local_e.Data))
							{
								((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
								{
									CS_0024_003C_003E8__locals1._0024VB_0024Me.Log($"[Frpc] {CS_0024_003C_003E8__locals1._0024VB_0024Local_e.Data}");
								}));
							}
						});
						_0024VB_0024Me._frpcProcess.ErrorDataReceived += (DataReceivedEventHandler)([SpecialName] [CompilerGenerated] (object s, DataReceivedEventArgs e) =>
						{
							//IL_0033: Unknown result type (might be due to invalid IL or missing references)
							//IL_003d: Expected O, but got Unknown
							_Closure_0024__59_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__59_002D1
							{
								_0024VB_0024Me = _0024VB_0024Me,
								_0024VB_0024Local_e = e
							};
							if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0._0024VB_0024Local_e.Data))
							{
								((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
								{
									CS_0024_003C_003E8__locals0._0024VB_0024Me.Log($"[Frpc错误] {CS_0024_003C_003E8__locals0._0024VB_0024Local_e.Data}");
								}));
							}
						});
						_0024VB_0024Me._frpcProcess.Start();
						_0024VB_0024Me._frpcProcess.BeginOutputReadLine();
						_0024VB_0024Me._frpcProcess.BeginErrorReadLine();
						_0024VB_0024Me._isRunning = true;
						_0024VB_0024Me._startTime = System.DateTime.Now;
						if (!string.IsNullOrWhiteSpace(_0024VB_0024Me._serverAddr) && _0024VB_0024Local_proxy.RemotePort > 0)
						{
							((TextBox)_0024VB_0024Me.TextAddress).Text = $"{_0024VB_0024Me._serverAddr}:{_0024VB_0024Local_proxy.RemotePort}";
						}
						else
						{
							((TextBox)_0024VB_0024Me.TextAddress).Text = _0024VB_0024Local_proxy.RemotePort.ToString();
						}
						_0024VB_0024Me.Log("Stellarfrp 隧道启动成功！");
						ModMain.Hint("联机已启动！", ModMain.HintType.Finish);
						_0024VB_0024Me.RefreshUi();
						_0024VB_0024Me.CleanupOldConfigFiles(text4, 5);
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"启动 Stellarfrp 隧道失败：{ex2.Message}");
					ModMain.Hint("启动隧道失败！", ModMain.HintType.Critical);
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_60_GetXhfrpUserInfoAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal string _0024VB_0024ResumableLocal_url_00240;

		internal HttpResponseMessage _0024VB_0024ResumableLocal_response_00241;

		internal HttpClient _0024VB_0024ResumableLocal_client_00242;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00243;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		internal TaskAwaiter _0024A2;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_06da: Expected O, but got Unknown
			//IL_06dc: Expected O, but got Unknown
			//IL_04af: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0509: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Expected O, but got Unknown
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Expected O, but got Unknown
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0201: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_056b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0575: Invalid comparison between Unknown and I4
			//IL_0603: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3 && (uint)num > 2u)
				{
					_0024VB_0024Me.Log("===== 开始获取 星穿月联 用户信息 =====");
				}
				try
				{
					if (num == -3 || (uint)num <= 2u)
					{
						goto IL_00a4;
					}
					if (!string.IsNullOrWhiteSpace(_0024VB_0024Local_token))
					{
						_0024VB_0024Me.Log($"Token 内容长度：{_0024VB_0024Local_token}");
						_0024VB_0024ResumableLocal_handler_00243 = new HttpClientHandler
						{
							UseCookies = false
						};
						goto IL_00a4;
					}
					_0024VB_0024Me.Log("错误：Token 为空");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "Token错误");
					_0024VB_0024Me.RefreshUi();
					goto end_IL_0021;
					IL_00a4:
					try
					{
						if (num != -3 && (uint)num > 2u)
						{
							_0024VB_0024ResumableLocal_client_00242 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00243);
						}
						try
						{
							if (num != -3 && (uint)num > 2u)
							{
								_0024VB_0024ResumableLocal_client_00242.Timeout = TimeSpan.FromSeconds(10.0);
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00242.DefaultRequestHeaders).Add("authorization", _0024VB_0024Local_token);
								_0024VB_0024ResumableLocal_url_00240 = "https://console.frp.api.xhuzim.top/api/v1/users/info";
							}
							try
							{
								TaskAwaiter val;
								HttpResponseMessage result;
								TaskAwaiter<HttpResponseMessage> awaiter2;
								string result2;
								TaskAwaiter<string> awaiter;
								string text;
								switch (num)
								{
								case -3:
									num = (_0024State = -1);
									return;
								default:
									awaiter2 = _0024VB_0024ResumableLocal_client_00242.GetAsync(_0024VB_0024ResumableLocal_url_00240).GetAwaiter();
									if (!awaiter2.IsCompleted)
									{
										num = (_0024State = 0);
										_0024A0 = awaiter2;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_60_GetXhfrpUserInfoAsync>(ref awaiter2, ref _this);
										return;
									}
									goto IL_0198;
								case 0:
									num = (_0024State = -1);
									awaiter2 = _0024A0;
									_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
									goto IL_0198;
								case 1:
									num = (_0024State = -1);
									awaiter = _0024A1;
									_0024A1 = default(TaskAwaiter<string>);
									goto IL_0236;
								case 2:
									{
										num = (_0024State = -1);
										val = _0024A2;
										_0024A2 = default(TaskAwaiter);
										goto IL_0500;
									}
									IL_0500:
									val.GetResult();
									val = default(TaskAwaiter);
									break;
									IL_0198:
									result = awaiter2.GetResult();
									awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
									_0024VB_0024ResumableLocal_response_00241 = result;
									_0024VB_0024Me.Log($"请求 {_0024VB_0024ResumableLocal_url_00240} 返回：{_0024VB_0024ResumableLocal_response_00241.StatusCode}");
									awaiter = _0024VB_0024ResumableLocal_response_00241.Content.ReadAsStringAsync().GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_0024State = 1);
										_0024A1 = awaiter;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_60_GetXhfrpUserInfoAsync>(ref awaiter, ref _this);
										return;
									}
									goto IL_0236;
									IL_0236:
									result2 = awaiter.GetResult();
									awaiter = default(TaskAwaiter<string>);
									text = result2;
									_0024VB_0024Me.Log(string.Format("响应内容：{0}", (object)((text.Length > 200) ? (text.Substring(0, 200) + "...") : text)));
									if (_0024VB_0024ResumableLocal_response_00241.IsSuccessStatusCode)
									{
										JObject jObject = JObject.Parse(text);
										JToken? jToken = jObject["code"];
										if (jToken != null && jToken.Value<int>() == 200)
										{
											JToken jToken2 = jObject["data"];
											string text2 = jToken2["Username"]?.ToString();
											long? num2 = jToken2["Traffic"]?.Value<long>();
											string text3 = jToken2["GroupName"]?.ToString();
											string text4 = jToken2["Tunnels"]?.ToString();
											LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, _0024VB_0024Local_token, text2 ?? "用户");
											_0024VB_0024Me._username = text2 ?? "用户";
											_0024VB_0024Me._friendlyGroup = text3 ?? "未知";
											if (num2.HasValue)
											{
												_0024VB_0024Me._trafficGB = (double)num2.Value / 1024.0 / 1024.0 / 1024.0;
											}
											else
											{
												_0024VB_0024Me._trafficGB = 0.0;
											}
											try
											{
												string[] array = (string.IsNullOrWhiteSpace(text4) ? null : text4.Split(new char[] { '/' }, (StringSplitOptions)1));
												if (array != null && array.Length > 0)
												{
													int.TryParse(array[0], out _0024VB_0024Me._proxiesCount);
												}
												else
												{
													_0024VB_0024Me._proxiesCount = 0;
												}
											}
											catch (System.Exception projectError)
											{
												ProjectData.SetProjectError(projectError);
												_0024VB_0024Me._proxiesCount = 0;
												ProjectData.ClearProjectError();
											}
											_0024VB_0024Me.Log($"登录成功！用户：{_0024VB_0024Me._username}，剩余流量：{_0024VB_0024Me._trafficGB:F2} GB，权限组：{_0024VB_0024Me._friendlyGroup}");
											_0024VB_0024Me.UpdateUserInfoUI();
											_0024VB_0024Me.RefreshUi();
											val = _0024VB_0024Me.GetXhfrpProxiesAsync(_0024VB_0024Local_token).GetAwaiter();
											if (!val.IsCompleted)
											{
												num = (_0024State = 2);
												_0024A2 = val;
												_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_60_GetXhfrpUserInfoAsync>(ref val, ref _this);
												return;
											}
											goto IL_0500;
										}
										_0024VB_0024Me.Log(string.Format("API 返回失败：{0} - {1}", (object)jObject["msg"], (object)text));
										LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "API错误");
										_0024VB_0024Me.RefreshUi();
										break;
									}
									if ((int)_0024VB_0024ResumableLocal_response_00241.StatusCode == 401)
									{
										_0024VB_0024Me.Log("Token 无效（401），自动退出登录");
										try
										{
											ModBase.Setup.Set("LinkXhFrpCookies", "");
											ModBase.Setup.Set("LinkXhFrpToken", "");
										}
										catch (System.Exception projectError2)
										{
											ProjectData.SetProjectError(projectError2);
											ProjectData.ClearProjectError();
										}
										LinkProviderRegistry.SignOut(_0024VB_0024Me.Provider.Kind);
										_0024VB_0024Me.RefreshUi();
										ModMain.Hint("登录已过期，请重新登录！", ModMain.HintType.Critical);
									}
									else
									{
										_0024VB_0024Me.Log($"HTTP 请求失败：{_0024VB_0024ResumableLocal_response_00241.StatusCode}");
										LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "请求失败");
										_0024VB_0024Me.RefreshUi();
									}
									break;
								}
							}
							catch (System.Exception ex)
							{
								ProjectData.SetProjectError(ex);
								System.Exception ex2 = ex;
								_0024VB_0024Me.Log($"请求 {_0024VB_0024ResumableLocal_url_00240} 失败：{ex2.Message}");
								LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "网络错误");
								_0024VB_0024Me.RefreshUi();
								ProjectData.ClearProjectError();
							}
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00242 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00242).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00243 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00243).Dispose();
						}
					}
					end_IL_0021:;
				}
				catch (TaskCanceledException val2)
				{
					ProjectData.SetProjectError((System.Exception)val2);
					TaskCanceledException val3 = val2;
					_0024VB_0024Me.Log("请求超时（10秒）");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "timeout", "请求超时");
					_0024VB_0024Me.RefreshUi();
					ProjectData.ClearProjectError();
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					_0024VB_0024Me.Log($"发生错误：{((MemberInfo)ex4.GetType()).Name}");
					_0024VB_0024Me.Log($"错误消息：{ex4.Message}");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "网络错误");
					_0024VB_0024Me.RefreshUi();
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
	internal sealed class VB_0024StateMachine_61_GetXhfrpProxiesAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal string _0024VB_0024ResumableLocal_url_00240;

		internal _Closure_0024__61_002D0 _0024VB_0024ResumableLocal__0024VB_0024Closure__00241;

		internal System.Collections.Generic.IEnumerator<JToken> _0024S2;

		internal HttpClient _0024VB_0024ResumableLocal_client_00243;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00244;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_054b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0555: Expected O, but got Unknown
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0563: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					if (num != -3 && (uint)num > 1u)
					{
						_0024VB_0024Me.Log("===== 开始获取 星穿月联 隧道列表 =====");
						_0024VB_0024ResumableLocal_handler_00244 = new HttpClientHandler
						{
							UseCookies = false
						};
					}
					try
					{
						if (num != -3 && (uint)num > 1u)
						{
							_0024VB_0024ResumableLocal_client_00243 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00244);
						}
						try
						{
							HttpResponseMessage result;
							TaskAwaiter<HttpResponseMessage> awaiter2;
							HttpResponseMessage val;
							string result2;
							TaskAwaiter<string> awaiter;
							string text;
							JToken jToken;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
								_0024VB_0024ResumableLocal_client_00243.Timeout = TimeSpan.FromSeconds(10.0);
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00243.DefaultRequestHeaders).Add("authorization", _0024VB_0024Local_token);
								_0024VB_0024ResumableLocal_url_00240 = "https://console.frp.api.xhuzim.top/api/v1/proxy/get?page=1&page_size=100";
								awaiter2 = _0024VB_0024ResumableLocal_client_00243.GetAsync(_0024VB_0024ResumableLocal_url_00240).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_61_GetXhfrpProxiesAsync>(ref awaiter2, ref _this);
									return;
								}
								goto IL_0123;
							case 0:
								num = (_0024State = -1);
								awaiter2 = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								goto IL_0123;
							case 1:
								{
									num = (_0024State = -1);
									awaiter = _0024A1;
									_0024A1 = default(TaskAwaiter<string>);
									goto IL_01e2;
								}
								IL_0123:
								result = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
								val = result;
								_0024VB_0024Me.Log($"请求 {_0024VB_0024ResumableLocal_url_00240} 返回：{val.StatusCode}");
								if (val.IsSuccessStatusCode)
								{
									_0024VB_0024ResumableLocal__0024VB_0024Closure__00241 = new _Closure_0024__61_002D0(_0024VB_0024ResumableLocal__0024VB_0024Closure__00241);
									_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Me = _0024VB_0024Me;
									awaiter = val.Content.ReadAsStringAsync().GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_0024State = 1);
										_0024A1 = awaiter;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_61_GetXhfrpProxiesAsync>(ref awaiter, ref _this);
										return;
									}
									goto IL_01e2;
								}
								_0024VB_0024Me.Log($"获取 隧道列表失败：{val.StatusCode}");
								break;
								IL_01e2:
								result2 = awaiter.GetResult();
								awaiter = default(TaskAwaiter<string>);
								text = result2;
								_0024VB_0024Me.Log(string.Format("隧道响应: {0}", (object)((text.Length > 200) ? (text.Substring(0, 200) + "...") : text)));
								jToken = JObject.Parse(text)["tunnel"];
								_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_proxies = new List<ProxyInfo>();
								if (jToken != null)
								{
									try
									{
										_0024S2 = ((System.Collections.Generic.IEnumerable<JToken>)jToken).GetEnumerator();
										while (((System.Collections.IEnumerator)_0024S2).MoveNext())
										{
											JProperty jProperty = (JProperty)_0024S2.Current;
											try
											{
												string name = jProperty.Name;
												JObject jObject = (JObject)jProperty.Value;
												ProxyInfo proxyInfo = new ProxyInfo
												{
													ProxyId = (jObject["Id"]?.Value<int>() ?? int.Parse(name)),
													ProxyName = (jObject["ProxyName"]?.ToString() ?? jObject["ProxyName"]?.ToString()),
													RemotePort = (jObject["RemotePort"]?.Value<int>() ?? 0),
													LocalPort = (jObject["LocalPort"]?.Value<int>() ?? 0),
													NodeId = (jObject["NodeId"]?.Value<int>() ?? 0),
													NodeName = (jObject["NodeName"]?.ToString() ?? ""),
													ProxyType = (jObject["ProxyType"]?.ToString() ?? jObject["Type"]?.ToString())
												};
												string text2 = jObject["Status"]?.ToString();
												proxyInfo.IsOnline = !string.Equals(text2, "offline", (StringComparison)5);
												string text3 = jObject["Link"]?.ToString();
												if (!string.IsNullOrWhiteSpace(text3))
												{
													proxyInfo.ConnectAddress = text3.Split(new char[] { ':' }, (StringSplitOptions)1)[0];
												}
												proxyInfo.ConfigText = jObject["data"]?.ToString() ?? "";
												if (string.IsNullOrWhiteSpace(proxyInfo.ConnectAddress) && !string.IsNullOrWhiteSpace(proxyInfo.ConfigText))
												{
													Match val2 = Regex.Match(proxyInfo.ConfigText, "serverAddr\\s*=\\s*\"(?<host>[^\"]+)\"");
													if (((Group)val2).Success)
													{
														proxyInfo.ConnectAddress = ((Capture)val2.Groups["host"]).Value;
													}
												}
												_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_proxies.Add(proxyInfo);
											}
											catch (System.Exception ex)
											{
												ProjectData.SetProjectError(ex);
												System.Exception ex2 = ex;
												_0024VB_0024Me.Log($"解析隧道项失败: {ex2.Message}");
												ProjectData.ClearProjectError();
											}
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
								_0024VB_0024Me._proxiesCount = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_proxies.Count;
								_0024VB_0024Me.UpdateUserInfoUI();
								((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
								{
									//IL_000c: Unknown result type (might be due to invalid IL or missing references)
									//IL_0011: Unknown result type (might be due to invalid IL or missing references)
									List<TunnelItem> val3 = new List<TunnelItem>();
									System.Collections.Generic.IEnumerator<ProxyInfo> enumerator = default(System.Collections.Generic.IEnumerator<ProxyInfo>);
									try
									{
										enumerator = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_proxies.GetEnumerator();
										while (enumerator.MoveNext())
										{
											ProxyInfo current = enumerator.Current;
											val3.Add(new TunnelItem
											{
												Proxy = current,
												DisplayText = $"{current.ProxyName} - 端口 {current.RemotePort}"
											});
										}
									}
									finally
									{
										((System.IDisposable)enumerator).Dispose();
									}
									((ItemsControl)_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Me.ComboTunnel).ItemsSource = (System.Collections.IEnumerable)val3;
									((ItemsControl)_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Me.ComboTunnel).DisplayMemberPath = "DisplayText";
									if (val3.Count > 0)
									{
										((Selector)_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Me.ComboTunnel).SelectedIndex = 0;
									}
								}));
								break;
							}
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00243 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00243).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00244 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00244).Dispose();
						}
					}
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					_0024VB_0024Me.Log($"获取 星穿月联 隧道列表失败：{ex4.Message}");
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
	internal sealed class VB_0024StateMachine_62_GetXhfrpProxyConfigAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder<string> _0024Builder;

		internal int _0024VB_0024Local_proxyId;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal string _0024VB_0024ResumableLocal_url_00240;

		internal System.Collections.Generic.IEnumerator<JToken> _0024S1;

		internal HttpClient _0024VB_0024ResumableLocal_client_00242;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00243;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			string result3;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					if (num != -3 && (uint)num > 1u)
					{
						_0024VB_0024ResumableLocal_handler_00243 = new HttpClientHandler
						{
							UseCookies = false
						};
					}
					try
					{
						if (num != -3 && (uint)num > 1u)
						{
							_0024VB_0024ResumableLocal_client_00242 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00243);
						}
						try
						{
							HttpResponseMessage result;
							TaskAwaiter<HttpResponseMessage> awaiter2;
							HttpResponseMessage val;
							string result2;
							TaskAwaiter<string> awaiter;
							JToken jToken;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
								_0024VB_0024ResumableLocal_client_00242.Timeout = TimeSpan.FromSeconds(10.0);
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00242.DefaultRequestHeaders).Add("authorization", _0024VB_0024Local_token);
								_0024VB_0024ResumableLocal_url_00240 = "https://console.frp.api.xhuzim.top/api/v1/proxy/get?page=1&page_size=100";
								awaiter2 = _0024VB_0024ResumableLocal_client_00242.GetAsync(_0024VB_0024ResumableLocal_url_00240).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_62_GetXhfrpProxyConfigAsync>(ref awaiter2, ref _this);
									return;
								}
								goto IL_0113;
							case 0:
								num = (_0024State = -1);
								awaiter2 = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								goto IL_0113;
							case 1:
								{
									num = (_0024State = -1);
									awaiter = _0024A1;
									_0024A1 = default(TaskAwaiter<string>);
									goto IL_01b0;
								}
								IL_0113:
								result = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
								val = result;
								_0024VB_0024Me.Log($"请求 {_0024VB_0024ResumableLocal_url_00240} 返回：{val.StatusCode}");
								if (val.IsSuccessStatusCode)
								{
									awaiter = val.Content.ReadAsStringAsync().GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_0024State = 1);
										_0024A1 = awaiter;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_62_GetXhfrpProxyConfigAsync>(ref awaiter, ref _this);
										return;
									}
									goto IL_01b0;
								}
								_0024VB_0024Me.Log($"获取 隧道配置失败：{val.StatusCode}");
								break;
								IL_01b0:
								result2 = awaiter.GetResult();
								awaiter = default(TaskAwaiter<string>);
								jToken = JObject.Parse(result2)["tunnel"];
								if (object.ReferenceEquals((object)jToken, (object)null))
								{
									break;
								}
								try
								{
									_0024S1 = ((System.Collections.Generic.IEnumerable<JToken>)jToken).GetEnumerator();
									while (((System.Collections.IEnumerator)_0024S1).MoveNext())
									{
										JProperty jProperty = (JProperty)_0024S1.Current;
										try
										{
											string name = jProperty.Name;
											JObject jObject = (JObject)jProperty.Value;
											if ((jObject["Id"]?.Value<int>() ?? int.Parse(name)) != _0024VB_0024Local_proxyId)
											{
												goto end_IL_0201;
											}
											result3 = jObject["data"]?.ToString() ?? "";
											goto end_IL_0007;
											end_IL_0201:;
										}
										catch (System.Exception ex)
										{
											ProjectData.SetProjectError(ex);
											System.Exception ex2 = ex;
											ProjectData.ClearProjectError();
										}
									}
								}
								finally
								{
									if (num < 0 && _0024S1 != null)
									{
										((System.IDisposable)_0024S1).Dispose();
									}
								}
								break;
							}
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00242 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00242).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00243 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00243).Dispose();
						}
					}
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					_0024VB_0024Me.Log($"获取 星穿月联 配置失败：{ex4.Message}");
					ProjectData.ClearProjectError();
				}
				result3 = "";
				end_IL_0007:;
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
			_0024Builder.SetResult(result3);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_63_StartXhfrpcTunnel : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal ProxyInfo _0024VB_0024Local_proxy;

		internal int _0024VB_0024Local_localPort;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal TaskAwaiter<string> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Expected O, but got Unknown
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Expected O, but got Unknown
			//IL_025e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Expected O, but got Unknown
			//IL_027f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Expected O, but got Unknown
			int num = _0024State;
			try
			{
				if (num != -3)
				{
				}
				try
				{
					TaskAwaiter<string> awaiter;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						_0024VB_0024Me.Log("===== 开始启动 星穿月联 隧道 =====");
						awaiter = _0024VB_0024Me.GetXhfrpProxyConfigAsync(_0024VB_0024Local_proxy.ProxyId, _0024VB_0024Local_token).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_63_StartXhfrpcTunnel>(ref awaiter, ref _this);
							return;
						}
						break;
					case 0:
						num = (_0024State = -1);
						awaiter = _0024A0;
						_0024A0 = default(TaskAwaiter<string>);
						break;
					}
					string result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<string>);
					string text = result;
					if (string.IsNullOrWhiteSpace(text))
					{
						_0024VB_0024Me.Log("获取 星穿月联 配置失败");
						ModMain.Hint("获取配置失败！", ModMain.HintType.Critical);
					}
					else
					{
						string text2 = _0024VB_0024Me.ModifyTomlConfig(text, _0024VB_0024Local_proxy.ProxyName, _0024VB_0024Local_localPort);
						if (string.IsNullOrWhiteSpace(text2))
						{
							_0024VB_0024Me.Log("解析 星穿月联 配置失败，使用原始配置");
							text2 = text;
						}
						string text3 = text2;
						_0024VB_0024Me.ExtractServerInfo(text3);
						string text4 = Path.Combine(ModBase.PathAppdata, "PCL", "Frpc", "Configs");
						if (!Directory.Exists(text4))
						{
							Directory.CreateDirectory(text4);
						}
						string text5 = Path.Combine(text4, $"{_0024VB_0024Local_proxy.ProxyName}_{System.DateTime.Now:yyyyMMddHHmmss}.toml");
						UTF8Encoding val = new UTF8Encoding(false);
						File.WriteAllText(text5, text3, (Encoding)(object)val);
						_0024VB_0024Me.Log($"配置文件已保存: {text5}");
						string frpcPath = ModLink.GetFrpcPath();
						_0024VB_0024Me._frpcProcess = new Process();
						_0024VB_0024Me._frpcProcess.StartInfo.FileName = frpcPath;
						_0024VB_0024Me._frpcProcess.StartInfo.Arguments = $"-c \"{text5}\"";
						_0024VB_0024Me._frpcProcess.StartInfo.UseShellExecute = false;
						_0024VB_0024Me._frpcProcess.StartInfo.RedirectStandardOutput = true;
						_0024VB_0024Me._frpcProcess.StartInfo.RedirectStandardError = true;
						_0024VB_0024Me._frpcProcess.StartInfo.CreateNoWindow = true;
						_0024VB_0024Me._frpcProcess.OutputDataReceived += (DataReceivedEventHandler)([SpecialName] [CompilerGenerated] (object s, DataReceivedEventArgs e) =>
						{
							//IL_0033: Unknown result type (might be due to invalid IL or missing references)
							//IL_003d: Expected O, but got Unknown
							_Closure_0024__63_002D0 CS_0024_003C_003E8__locals1 = new _Closure_0024__63_002D0
							{
								_0024VB_0024Me = _0024VB_0024Me,
								_0024VB_0024Local_e = e
							};
							if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1._0024VB_0024Local_e.Data))
							{
								((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
								{
									CS_0024_003C_003E8__locals1._0024VB_0024Me.Log($"[Frpc] {CS_0024_003C_003E8__locals1._0024VB_0024Local_e.Data}");
								}));
							}
						});
						_0024VB_0024Me._frpcProcess.ErrorDataReceived += (DataReceivedEventHandler)([SpecialName] [CompilerGenerated] (object s, DataReceivedEventArgs e) =>
						{
							//IL_0033: Unknown result type (might be due to invalid IL or missing references)
							//IL_003d: Expected O, but got Unknown
							_Closure_0024__63_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__63_002D1
							{
								_0024VB_0024Me = _0024VB_0024Me,
								_0024VB_0024Local_e = e
							};
							if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0._0024VB_0024Local_e.Data))
							{
								((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
								{
									CS_0024_003C_003E8__locals0._0024VB_0024Me.Log($"[Frpc错误] {CS_0024_003C_003E8__locals0._0024VB_0024Local_e.Data}");
								}));
							}
						});
						_0024VB_0024Me._frpcProcess.Start();
						_0024VB_0024Me._frpcProcess.BeginOutputReadLine();
						_0024VB_0024Me._frpcProcess.BeginErrorReadLine();
						_0024VB_0024Me._isRunning = true;
						_0024VB_0024Me._startTime = System.DateTime.Now;
						if (!string.IsNullOrWhiteSpace(_0024VB_0024Me._serverAddr) && _0024VB_0024Local_proxy.RemotePort > 0)
						{
							((TextBox)_0024VB_0024Me.TextAddress).Text = $"{_0024VB_0024Me._serverAddr}:{_0024VB_0024Local_proxy.RemotePort}";
						}
						else
						{
							((TextBox)_0024VB_0024Me.TextAddress).Text = _0024VB_0024Local_proxy.RemotePort.ToString();
						}
						_0024VB_0024Me.Log("星穿月联 隧道启动成功！");
						ModMain.Hint("联机已启动！", ModMain.HintType.Finish);
						_0024VB_0024Me.RefreshUi();
						_0024VB_0024Me.CleanupOldConfigFiles(text4, 5);
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"启动 星穿月联 隧道失败：{ex2.Message}");
					ModMain.Hint("启动隧道失败！", ModMain.HintType.Critical);
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_64_GetNatfrpUserInfoAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_cookieText;

		internal PageLinkLobby _0024VB_0024Me;

		internal HttpResponseMessage _0024VB_0024ResumableLocal_response_00240;

		internal string _0024VB_0024ResumableLocal_filteredCookies_00241;

		internal HttpClient _0024VB_0024ResumableLocal_client_00242;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00243;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		internal TaskAwaiter _0024A2;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0498: Unknown result type (might be due to invalid IL or missing references)
			//IL_049e: Expected O, but got Unknown
			//IL_04a0: Expected O, but got Unknown
			//IL_04ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0524: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Expected O, but got Unknown
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0508: Unknown result type (might be due to invalid IL or missing references)
			//IL_050d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0515: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 2;
				}
				try
				{
					string text = default(string);
					if (num == -3 || (uint)num <= 2u)
					{
						goto IL_00ce;
					}
					_0024VB_0024Me.Log("===== 开始获取 Natfrp 用户信息 =====");
					if (!string.IsNullOrWhiteSpace(_0024VB_0024Local_cookieText))
					{
						_0024VB_0024ResumableLocal_filteredCookies_00241 = _0024VB_0024Me.FilterNatfrpCookies(_0024VB_0024Local_cookieText);
						text = _0024VB_0024Me.ConvertCookieTextToHeader(_0024VB_0024ResumableLocal_filteredCookies_00241);
						_0024VB_0024Me.Log($"Cookie Header: {text}");
						_0024VB_0024ResumableLocal_handler_00243 = new HttpClientHandler
						{
							UseCookies = false
						};
						goto IL_00ce;
					}
					_0024VB_0024Me.Log("错误：Natfrp Cookie 为空");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "Cookie错误");
					_0024VB_0024Me.RefreshUi();
					goto end_IL_0011;
					IL_00ce:
					try
					{
						if (num != -3 && (uint)num > 2u)
						{
							_0024VB_0024ResumableLocal_client_00242 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00243);
						}
						try
						{
							TaskAwaiter val;
							HttpResponseMessage result;
							TaskAwaiter<HttpResponseMessage> awaiter2;
							string result2;
							TaskAwaiter<string> awaiter;
							string text2;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
								_0024VB_0024ResumableLocal_client_00242.Timeout = TimeSpan.FromSeconds(10.0);
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00242.DefaultRequestHeaders).Add("Cookie", text);
								awaiter2 = _0024VB_0024ResumableLocal_client_00242.GetAsync("https://www.natfrp.com/cgi/v4/user/info").GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_64_GetNatfrpUserInfoAsync>(ref awaiter2, ref _this);
									return;
								}
								goto IL_01a7;
							case 0:
								num = (_0024State = -1);
								awaiter2 = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								goto IL_01a7;
							case 1:
								num = (_0024State = -1);
								awaiter = _0024A1;
								_0024A1 = default(TaskAwaiter<string>);
								goto IL_0242;
							case 2:
								{
									num = (_0024State = -1);
									val = _0024A2;
									_0024A2 = default(TaskAwaiter);
									goto IL_051b;
								}
								IL_051b:
								val.GetResult();
								val = default(TaskAwaiter);
								break;
								IL_01a7:
								result = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
								_0024VB_0024ResumableLocal_response_00240 = result;
								_0024VB_0024Me.Log($"收到响应：{_0024VB_0024ResumableLocal_response_00240.StatusCode}");
								awaiter = _0024VB_0024ResumableLocal_response_00240.Content.ReadAsStringAsync().GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 1);
									_0024A1 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_64_GetNatfrpUserInfoAsync>(ref awaiter, ref _this);
									return;
								}
								goto IL_0242;
								IL_0242:
								result2 = awaiter.GetResult();
								awaiter = default(TaskAwaiter<string>);
								text2 = result2;
								_0024VB_0024Me.Log(string.Format("响应内容：{0}", (object)((text2.Length > 200) ? (text2.Substring(0, 200) + "...") : text2)));
								if (_0024VB_0024ResumableLocal_response_00240.IsSuccessStatusCode)
								{
									JObject jObject = JObject.Parse(text2);
									string username = jObject["name"]?.ToString();
									string text3 = jObject["token"]?.ToString();
									string text4 = jObject["group"]?["name"]?.ToString();
									int? num2 = jObject["tunnels"]?.Value<int>();
									double trafficGB = 0.0;
									JToken jToken = jObject["traffic"];
									if (jToken != null && Enumerable.Count<JToken>((System.Collections.Generic.IEnumerable<JToken>)jToken) >= 2)
									{
										long? num3 = jToken[1]?.Value<long>();
										if (num3.HasValue)
										{
											trafficGB = (double)num3.Value / 1024.0 / 1024.0 / 1024.0;
										}
									}
									if (string.IsNullOrWhiteSpace(text3))
									{
										_0024VB_0024Me.Log("错误：Natfrp 返回的 token 为空");
										LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "Token错误");
										_0024VB_0024Me.RefreshUi();
										break;
									}
									ModBase.Setup.Set("LinkNatfrpCookies", _0024VB_0024ResumableLocal_filteredCookies_00241);
									ModBase.Setup.Set("LinkNaidRefreshToken", text3);
									LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, text3, username);
									_0024VB_0024Me._username = username;
									_0024VB_0024Me._friendlyGroup = text4 ?? "未知";
									_0024VB_0024Me._trafficGB = trafficGB;
									_0024VB_0024Me._proxiesCount = num2.GetValueOrDefault();
									try
									{
										ModBase.Setup.Set("LinkNatfrpUser", _0024VB_0024Me._username);
									}
									catch (KeyNotFoundException val2)
									{
										ProjectData.SetProjectError((System.Exception)val2);
										KeyNotFoundException val3 = val2;
										ProjectData.ClearProjectError();
									}
									_0024VB_0024Me.UpdateUserInfoUI();
									_0024VB_0024Me.RefreshUi();
									val = _0024VB_0024Me.GetNatfrpTunnelsAsync(text3).GetAwaiter();
									if (!val.IsCompleted)
									{
										num = (_0024State = 2);
										_0024A2 = val;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_64_GetNatfrpUserInfoAsync>(ref val, ref _this);
										return;
									}
									goto IL_051b;
								}
								_0024VB_0024Me.Log("Natfrp 用户信息请求失败");
								LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "请求失败");
								_0024VB_0024Me.RefreshUi();
								break;
							}
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00242 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00242).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00243 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00243).Dispose();
						}
					}
					end_IL_0011:;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"Natfrp 用户信息获取失败：{ex2.Message}");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "网络错误");
					_0024VB_0024Me.RefreshUi();
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_65_GetNatfrpUserInfoByToken : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal HttpResponseMessage _0024VB_0024ResumableLocal_response_00240;

		internal HttpClient _0024VB_0024ResumableLocal_client_00241;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00242;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c9: Expected O, but got Unknown
			//IL_03cb: Expected O, but got Unknown
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					if (num == -3 || (uint)num <= 1u)
					{
						goto IL_0089;
					}
					_0024VB_0024Me.Log("===== 通过 Token 获取 Natfrp 用户信息 =====");
					if (!string.IsNullOrWhiteSpace(_0024VB_0024Local_token))
					{
						_0024VB_0024ResumableLocal_handler_00242 = new HttpClientHandler
						{
							UseCookies = false
						};
						goto IL_0089;
					}
					_0024VB_0024Me.Log("错误：Natfrp Token 为空");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "Token错误");
					_0024VB_0024Me.RefreshUi();
					goto end_IL_0011;
					IL_0089:
					try
					{
						if (num != -3 && (uint)num > 1u)
						{
							_0024VB_0024ResumableLocal_client_00241 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00242);
						}
						try
						{
							HttpResponseMessage result;
							TaskAwaiter<HttpResponseMessage> awaiter2;
							TaskAwaiter<string> awaiter;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
							{
								_0024VB_0024ResumableLocal_client_00241.Timeout = TimeSpan.FromSeconds(10.0);
								string text = $"https://api.natfrp.com/v4/user/info?token={Uri.EscapeDataString(_0024VB_0024Local_token)}";
								awaiter2 = _0024VB_0024ResumableLocal_client_00241.GetAsync(text).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_65_GetNatfrpUserInfoByToken>(ref awaiter2, ref _this);
									return;
								}
								goto IL_015a;
							}
							case 0:
								num = (_0024State = -1);
								awaiter2 = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								goto IL_015a;
							case 1:
								{
									num = (_0024State = -1);
									awaiter = _0024A1;
									_0024A1 = default(TaskAwaiter<string>);
									break;
								}
								IL_015a:
								result = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
								_0024VB_0024ResumableLocal_response_00240 = result;
								_0024VB_0024Me.Log($"收到响应：{_0024VB_0024ResumableLocal_response_00240.StatusCode}");
								awaiter = _0024VB_0024ResumableLocal_response_00240.Content.ReadAsStringAsync().GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 1);
									_0024A1 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_65_GetNatfrpUserInfoByToken>(ref awaiter, ref _this);
									return;
								}
								break;
							}
							string result2 = awaiter.GetResult();
							awaiter = default(TaskAwaiter<string>);
							string text2 = result2;
							_0024VB_0024Me.Log(string.Format("响应内容：{0}", (object)((text2.Length > 200) ? (text2.Substring(0, 200) + "...") : text2)));
							if (_0024VB_0024ResumableLocal_response_00240.IsSuccessStatusCode)
							{
								JObject jObject = JObject.Parse(text2);
								string username = jObject["name"]?.ToString();
								string text3 = jObject["group"]?["name"]?.ToString();
								int? num2 = jObject["tunnels"]?.Value<int>();
								double trafficGB = 0.0;
								JToken jToken = jObject["traffic"];
								if (jToken != null && Enumerable.Count<JToken>((System.Collections.Generic.IEnumerable<JToken>)jToken) >= 2)
								{
									long? num3 = jToken[1]?.Value<long>();
									if (num3.HasValue)
									{
										trafficGB = (double)num3.Value / 1024.0 / 1024.0 / 1024.0;
									}
								}
								LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, _0024VB_0024Local_token, username);
								_0024VB_0024Me._username = username;
								_0024VB_0024Me._friendlyGroup = text3 ?? "未知";
								_0024VB_0024Me._trafficGB = trafficGB;
								_0024VB_0024Me._proxiesCount = num2.GetValueOrDefault();
								try
								{
									ModBase.Setup.Set("LinkNatfrpUser", _0024VB_0024Me._username);
								}
								catch (KeyNotFoundException val)
								{
									ProjectData.SetProjectError((System.Exception)val);
									KeyNotFoundException val2 = val;
									ProjectData.ClearProjectError();
								}
								_0024VB_0024Me.UpdateUserInfoUI();
								_0024VB_0024Me.RefreshUi();
							}
							else
							{
								_0024VB_0024Me.Log("Natfrp 用户信息请求失败");
								LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "请求失败");
								_0024VB_0024Me.RefreshUi();
							}
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00241 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00241).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00242 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00242).Dispose();
						}
					}
					end_IL_0011:;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"Natfrp 用户信息获取失败：{ex2.Message}");
					LinkProviderRegistry.MarkLoggedIn(_0024VB_0024Me.Provider.Kind, "error", "网络错误");
					_0024VB_0024Me.RefreshUi();
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_66_GetNatfrpTunnelsAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal _Closure_0024__66_002D0 _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;

		internal System.Collections.Generic.IEnumerator<JToken> _0024S1;

		internal HttpClient _0024VB_0024ResumableLocal_client_00242;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00243;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_042c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Unknown result type (might be due to invalid IL or missing references)
			//IL_0414: Unknown result type (might be due to invalid IL or missing references)
			//IL_041e: Expected O, but got Unknown
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					if (num != -3 && (uint)num > 1u)
					{
						_0024VB_0024Me.Log("===== 开始获取 Natfrp 隧道列表 =====");
						_0024VB_0024ResumableLocal_handler_00243 = new HttpClientHandler
						{
							UseCookies = false
						};
					}
					try
					{
						if (num != -3 && (uint)num > 1u)
						{
							_0024VB_0024ResumableLocal_client_00242 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00243);
						}
						try
						{
							HttpResponseMessage result;
							TaskAwaiter<HttpResponseMessage> awaiter2;
							HttpResponseMessage val;
							string result2;
							TaskAwaiter<string> awaiter;
							string text2;
							JArray jArray;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
							{
								_0024VB_0024ResumableLocal_client_00242.Timeout = TimeSpan.FromSeconds(10.0);
								string text = $"https://api.natfrp.com/v4/tunnels?token={Uri.EscapeDataString(_0024VB_0024Local_token)}";
								awaiter2 = _0024VB_0024ResumableLocal_client_00242.GetAsync(text).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_66_GetNatfrpTunnelsAsync>(ref awaiter2, ref _this);
									return;
								}
								goto IL_010e;
							}
							case 0:
								num = (_0024State = -1);
								awaiter2 = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								goto IL_010e;
							case 1:
								{
									num = (_0024State = -1);
									awaiter = _0024A1;
									_0024A1 = default(TaskAwaiter<string>);
									goto IL_01c7;
								}
								IL_010e:
								result = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
								val = result;
								_0024VB_0024Me.Log($"收到响应：{val.StatusCode}");
								if (val.IsSuccessStatusCode)
								{
									_0024VB_0024ResumableLocal__0024VB_0024Closure__00240 = new _Closure_0024__66_002D0(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240);
									_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Me = _0024VB_0024Me;
									awaiter = val.Content.ReadAsStringAsync().GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_0024State = 1);
										_0024A1 = awaiter;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_66_GetNatfrpTunnelsAsync>(ref awaiter, ref _this);
										return;
									}
									goto IL_01c7;
								}
								_0024VB_0024Me.Log($"Natfrp 隧道列表请求失败：{val.StatusCode}");
								break;
								IL_01c7:
								result2 = awaiter.GetResult();
								awaiter = default(TaskAwaiter<string>);
								text2 = result2;
								_0024VB_0024Me.Log(string.Format("隧道列表响应: {0}", (object)((text2.Length > 200) ? (text2.Substring(0, 200) + "...") : text2)));
								jArray = JArray.Parse(text2);
								_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_proxies = new List<ProxyInfo>();
								try
								{
									_0024S1 = jArray.GetEnumerator();
									while (((System.Collections.IEnumerator)_0024S1).MoveNext())
									{
										JToken current = _0024S1.Current;
										int remotePort = 0;
										int.TryParse(current["remote"]?.ToString(), out remotePort);
										ProxyInfo proxyInfo = new ProxyInfo
										{
											ProxyId = (current["id"]?.Value<int>()).Value,
											ProxyName = current["name"]?.ToString(),
											NodeId = (current["node"]?.Value<int>()).Value,
											ProxyType = current["type"]?.ToString(),
											IsOnline = (current["online"]?.Value<bool>()).Value,
											RemotePort = remotePort,
											LocalPort = (current["local_port"]?.Value<int>()).Value
										};
										_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_proxies.Add(proxyInfo);
									}
								}
								finally
								{
									if (num < 0 && _0024S1 != null)
									{
										((System.IDisposable)_0024S1).Dispose();
									}
								}
								_0024VB_0024Me._proxiesCount = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_proxies.Count;
								_0024VB_0024Me.UpdateUserInfoUI();
								((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
								{
									//IL_000c: Unknown result type (might be due to invalid IL or missing references)
									//IL_0011: Unknown result type (might be due to invalid IL or missing references)
									List<TunnelItem> val2 = new List<TunnelItem>();
									System.Collections.Generic.IEnumerator<ProxyInfo> enumerator = default(System.Collections.Generic.IEnumerator<ProxyInfo>);
									try
									{
										enumerator = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_proxies.GetEnumerator();
										while (enumerator.MoveNext())
										{
											ProxyInfo current2 = enumerator.Current;
											val2.Add(new TunnelItem
											{
												Proxy = current2,
												DisplayText = $"{current2.ProxyName} - 端口 {current2.RemotePort}"
											});
										}
									}
									finally
									{
										((System.IDisposable)enumerator).Dispose();
									}
									((ItemsControl)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Me.ComboTunnel).ItemsSource = (System.Collections.IEnumerable)val2;
									((ItemsControl)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Me.ComboTunnel).DisplayMemberPath = "DisplayText";
									if (val2.Count > 0)
									{
										((Selector)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Me.ComboTunnel).SelectedIndex = 0;
									}
								}));
								break;
							}
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00242 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00242).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00243 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00243).Dispose();
						}
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"获取 Natfrp 隧道列表失败：{ex2.Message}");
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_67_GetNatfrpProxyConfigAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder<string> _0024Builder;

		internal int _0024VB_0024Local_proxyId;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal HttpClient _0024VB_0024ResumableLocal_client_00240;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00241;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			string result3;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					if (num != -3 && (uint)num > 1u)
					{
						_0024VB_0024ResumableLocal_handler_00241 = new HttpClientHandler
						{
							UseCookies = false
						};
					}
					try
					{
						if (num != -3 && (uint)num > 1u)
						{
							_0024VB_0024ResumableLocal_client_00240 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00241);
						}
						try
						{
							HttpResponseMessage result;
							TaskAwaiter<HttpResponseMessage> awaiter2;
							HttpResponseMessage val2;
							string result2;
							TaskAwaiter<string> awaiter;
							string text2;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
							{
								_0024VB_0024ResumableLocal_client_00240.Timeout = TimeSpan.FromSeconds(10.0);
								string text = $"https://api.natfrp.com/v4/tunnel/config?token={Uri.EscapeDataString(_0024VB_0024Local_token)}";
								Dictionary<string, string> obj = new Dictionary<string, string>();
								obj.Add("query", _0024VB_0024Local_proxyId.ToString());
								obj.Add("frpc", "0.59.0");
								FormUrlEncodedContent val = new FormUrlEncodedContent((System.Collections.Generic.IEnumerable<KeyValuePair<string, string>>)obj);
								awaiter2 = _0024VB_0024ResumableLocal_client_00240.PostAsync(text, (HttpContent)(object)val).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_67_GetNatfrpProxyConfigAsync>(ref awaiter2, ref _this);
									return;
								}
								goto IL_0133;
							}
							case 0:
								num = (_0024State = -1);
								awaiter2 = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								goto IL_0133;
							case 1:
								{
									num = (_0024State = -1);
									awaiter = _0024A1;
									_0024A1 = default(TaskAwaiter<string>);
									goto IL_01ce;
								}
								IL_0133:
								result = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
								val2 = result;
								_0024VB_0024Me.Log($"Natfrp 配置响应：{val2.StatusCode}");
								if (val2.IsSuccessStatusCode)
								{
									awaiter = val2.Content.ReadAsStringAsync().GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_0024State = 1);
										_0024A1 = awaiter;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_67_GetNatfrpProxyConfigAsync>(ref awaiter, ref _this);
										return;
									}
									goto IL_01ce;
								}
								_0024VB_0024Me.Log("Natfrp 配置请求失败");
								goto end_IL_0048;
								IL_01ce:
								result2 = awaiter.GetResult();
								awaiter = default(TaskAwaiter<string>);
								text2 = result2;
								if (!string.IsNullOrWhiteSpace(text2))
								{
									_0024VB_0024Me.Log("Natfrp 配置获取成功（已保留原样）");
									result3 = text2;
									break;
								}
								_0024VB_0024Me.Log("Natfrp 配置为空");
								goto end_IL_0048;
							}
							goto end_IL_0007;
							end_IL_0048:;
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00240 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00240).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00241 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00241).Dispose();
						}
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"获取 Natfrp 配置出错：{ex2.Message}");
					ProjectData.ClearProjectError();
				}
				result3 = "";
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
			_0024Builder.SetResult(result3);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_68_StartNatfrpcTunnel : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal ProxyInfo _0024VB_0024Local_proxy;

		internal int _0024VB_0024Local_localPort;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal TaskAwaiter<string> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Expected O, but got Unknown
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Expected O, but got Unknown
			//IL_025e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Expected O, but got Unknown
			//IL_027f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Expected O, but got Unknown
			int num = _0024State;
			try
			{
				if (num != -3)
				{
				}
				try
				{
					TaskAwaiter<string> awaiter;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						_0024VB_0024Me.Log("===== 开始启动 Natfrp 隧道 =====");
						awaiter = _0024VB_0024Me.GetNatfrpProxyConfigAsync(_0024VB_0024Local_proxy.ProxyId, _0024VB_0024Local_token).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_68_StartNatfrpcTunnel>(ref awaiter, ref _this);
							return;
						}
						break;
					case 0:
						num = (_0024State = -1);
						awaiter = _0024A0;
						_0024A0 = default(TaskAwaiter<string>);
						break;
					}
					string result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<string>);
					string text = result;
					if (string.IsNullOrWhiteSpace(text))
					{
						_0024VB_0024Me.Log("获取 Natfrp 配置失败");
						ModMain.Hint("获取配置失败！", ModMain.HintType.Critical);
					}
					else
					{
						string text2 = _0024VB_0024Me.ModifyTomlConfig(text, _0024VB_0024Local_proxy.ProxyName, _0024VB_0024Local_localPort);
						if (string.IsNullOrWhiteSpace(text2))
						{
							_0024VB_0024Me.Log("解析 Natfrp 配置失败，使用原始配置");
							text2 = text;
						}
						string text3 = text2;
						_0024VB_0024Me.ExtractServerInfo(text3);
						string text4 = Path.Combine(ModBase.PathAppdata, "PCL", "Frpc", "Configs");
						if (!Directory.Exists(text4))
						{
							Directory.CreateDirectory(text4);
						}
						string text5 = Path.Combine(text4, $"{_0024VB_0024Local_proxy.ProxyName}_{System.DateTime.Now:yyyyMMddHHmmss}.toml");
						UTF8Encoding val = new UTF8Encoding(false);
						File.WriteAllText(text5, text3, (Encoding)(object)val);
						_0024VB_0024Me.Log($"配置文件已保存: {text5}");
						string frpcPath = ModLink.GetFrpcPath();
						_0024VB_0024Me._frpcProcess = new Process();
						_0024VB_0024Me._frpcProcess.StartInfo.FileName = frpcPath;
						_0024VB_0024Me._frpcProcess.StartInfo.Arguments = $"-c \"{text5}\"";
						_0024VB_0024Me._frpcProcess.StartInfo.UseShellExecute = false;
						_0024VB_0024Me._frpcProcess.StartInfo.RedirectStandardOutput = true;
						_0024VB_0024Me._frpcProcess.StartInfo.RedirectStandardError = true;
						_0024VB_0024Me._frpcProcess.StartInfo.CreateNoWindow = true;
						_0024VB_0024Me._frpcProcess.OutputDataReceived += (DataReceivedEventHandler)([SpecialName] [CompilerGenerated] (object s, DataReceivedEventArgs e) =>
						{
							//IL_0033: Unknown result type (might be due to invalid IL or missing references)
							//IL_003d: Expected O, but got Unknown
							_Closure_0024__68_002D0 CS_0024_003C_003E8__locals1 = new _Closure_0024__68_002D0
							{
								_0024VB_0024Me = _0024VB_0024Me,
								_0024VB_0024Local_e = e
							};
							if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1._0024VB_0024Local_e.Data))
							{
								((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
								{
									CS_0024_003C_003E8__locals1._0024VB_0024Me.Log($"[Frpc] {CS_0024_003C_003E8__locals1._0024VB_0024Local_e.Data}");
								}));
							}
						});
						_0024VB_0024Me._frpcProcess.ErrorDataReceived += (DataReceivedEventHandler)([SpecialName] [CompilerGenerated] (object s, DataReceivedEventArgs e) =>
						{
							//IL_0033: Unknown result type (might be due to invalid IL or missing references)
							//IL_003d: Expected O, but got Unknown
							_Closure_0024__68_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__68_002D1
							{
								_0024VB_0024Me = _0024VB_0024Me,
								_0024VB_0024Local_e = e
							};
							if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0._0024VB_0024Local_e.Data))
							{
								((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
								{
									CS_0024_003C_003E8__locals0._0024VB_0024Me.Log($"[Frpc错误] {CS_0024_003C_003E8__locals0._0024VB_0024Local_e.Data}");
								}));
							}
						});
						_0024VB_0024Me._frpcProcess.Start();
						_0024VB_0024Me._frpcProcess.BeginOutputReadLine();
						_0024VB_0024Me._frpcProcess.BeginErrorReadLine();
						_0024VB_0024Me._isRunning = true;
						_0024VB_0024Me._startTime = System.DateTime.Now;
						if (!string.IsNullOrWhiteSpace(_0024VB_0024Me._serverAddr) && _0024VB_0024Local_proxy.RemotePort > 0)
						{
							((TextBox)_0024VB_0024Me.TextAddress).Text = $"{_0024VB_0024Me._serverAddr}:{_0024VB_0024Local_proxy.RemotePort}";
						}
						else
						{
							((TextBox)_0024VB_0024Me.TextAddress).Text = _0024VB_0024Local_proxy.RemotePort.ToString();
						}
						_0024VB_0024Me.Log("Natfrp 隧道启动成功！");
						ModMain.Hint("联机已启动！", ModMain.HintType.Finish);
						_0024VB_0024Me.RefreshUi();
						_0024VB_0024Me.CleanupOldConfigFiles(text4, 5);
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"启动 Natfrp 隧道失败：{ex2.Message}");
					ModMain.Hint("启动隧道失败！", ModMain.HintType.Critical);
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_69_GetUserProxiesAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_cookieHeader;

		internal string _0024VB_0024Local_authorization;

		internal PageLinkLobby _0024VB_0024Me;

		internal System.Collections.Generic.IEnumerator<JToken> _0024S0;

		internal HttpClient _0024VB_0024ResumableLocal_client_00241;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		internal TaskAwaiter _0024A2;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0501: Unknown result type (might be due to invalid IL or missing references)
			//IL_0506: Unknown result type (might be due to invalid IL or missing references)
			//IL_050e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_051d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0554: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b1: Expected O, but got Unknown
			//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_04df: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3)
				{
					_ = 2;
				}
				try
				{
					if (num != -3 && (uint)num > 2u)
					{
						_0024VB_0024Me.Log("===== 开始获取隧道列表 =====");
						_0024VB_0024ResumableLocal_client_00241 = new HttpClient();
					}
					try
					{
						TaskAwaiter val;
						string result;
						TaskAwaiter<string> awaiter;
						JObject jObject;
						JToken? jToken;
						HttpResponseMessage result2;
						TaskAwaiter<HttpResponseMessage> awaiter2;
						HttpResponseMessage val3;
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return;
						default:
						{
							_0024VB_0024ResumableLocal_client_00241.Timeout = TimeSpan.FromSeconds(10.0);
							((HttpHeaders)_0024VB_0024ResumableLocal_client_00241.DefaultRequestHeaders).Add("Cookie", _0024VB_0024Local_cookieHeader);
							if (!string.IsNullOrWhiteSpace(_0024VB_0024Local_authorization))
							{
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00241.DefaultRequestHeaders).Add("authorization", _0024VB_0024Local_authorization);
							}
							StringContent val2 = new StringContent("{}", Encoding.UTF8, "application/json");
							awaiter2 = _0024VB_0024ResumableLocal_client_00241.PostAsync("https://console.openfrp.net/web/frp/api/getUserProxies", (HttpContent)(object)val2).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = awaiter2;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_69_GetUserProxiesAsync>(ref awaiter2, ref _this);
								return;
							}
							goto IL_0137;
						}
						case 0:
							num = (_0024State = -1);
							awaiter2 = _0024A0;
							_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
							goto IL_0137;
						case 1:
							num = (_0024State = -1);
							awaiter = _0024A1;
							_0024A1 = default(TaskAwaiter<string>);
							goto IL_01ae;
						case 2:
							{
								num = (_0024State = -1);
								val = _0024A2;
								_0024A2 = default(TaskAwaiter);
								goto IL_0514;
							}
							IL_0514:
							val.GetResult();
							val = default(TaskAwaiter);
							break;
							IL_01ae:
							result = awaiter.GetResult();
							awaiter = default(TaskAwaiter<string>);
							jObject = JObject.Parse(result);
							jToken = jObject["flag"];
							if (jToken != null && jToken.Value<bool>())
							{
								_Closure_0024__69_002D0 arg = default(_Closure_0024__69_002D0);
								_Closure_0024__69_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__69_002D0(null)
								{
									_0024VB_0024Me = _0024VB_0024Me
								};
								JToken jToken2 = jObject["data"]["list"];
								CS_0024_003C_003E8__locals0._0024VB_0024Local_proxies = new List<ProxyInfo>();
								try
								{
									_0024S0 = ((System.Collections.Generic.IEnumerable<JToken>)jToken2).GetEnumerator();
									while (((System.Collections.IEnumerator)_0024S0).MoveNext())
									{
										JToken current = _0024S0.Current;
										string text = current["proxyType"]?.ToString();
										bool? flag = current["proxyProtocolVersion"]?.Value<bool>();
										if (Operators.CompareString(text, "tcp", false) == 0 && (!flag).GetValueOrDefault())
										{
											CS_0024_003C_003E8__locals0._0024VB_0024Local_proxies.Add(new ProxyInfo
											{
												Id = (current["id"]?.Value<int>()).Value,
												ProxyName = current["proxyName"]?.ToString(),
												FriendlyNode = current["friendlyNode"]?.ToString(),
												RemotePort = (current["remotePort"]?.Value<int>()).Value,
												LocalPort = (current["localPort"]?.Value<int>()).Value,
												Nid = (current["nid"]?.Value<int>()).Value,
												ConnectAddress = current["connectAddress"]?.ToString(),
												Online = (current["online"]?.Value<bool>()).Value
											});
										}
									}
								}
								finally
								{
									if (num < 0 && _0024S0 != null)
									{
										((System.IDisposable)_0024S0)?.Dispose();
									}
								}
								_0024VB_0024Me.Log($"找到 {CS_0024_003C_003E8__locals0._0024VB_0024Local_proxies.Count} 个有效隧道");
								((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
								{
									List<VB_0024AnonymousType_0<string, ProxyInfo>> val4 = Enumerable.ToList<VB_0024AnonymousType_0<string, ProxyInfo>>(Enumerable.Select<ProxyInfo, VB_0024AnonymousType_0<string, ProxyInfo>>((System.Collections.Generic.IEnumerable<ProxyInfo>)CS_0024_003C_003E8__locals0._0024VB_0024Local_proxies, (Func<ProxyInfo, VB_0024AnonymousType_0<string, ProxyInfo>>)([SpecialName] (ProxyInfo p) => new VB_0024AnonymousType_0<string, ProxyInfo>($"{p.FriendlyNode} - {p.ProxyName} ({p.RemotePort}) [测试中...]", p))));
									((ItemsControl)CS_0024_003C_003E8__locals0._0024VB_0024Me.ComboTunnel).ItemsSource = (System.Collections.IEnumerable)val4;
									if (val4.Count > 0)
									{
										((Selector)CS_0024_003C_003E8__locals0._0024VB_0024Me.ComboTunnel).SelectedIndex = 0;
									}
								}));
								val = _0024VB_0024Me.TestProxiesLatencyAsync(CS_0024_003C_003E8__locals0._0024VB_0024Local_proxies).GetAwaiter();
								if (!val.IsCompleted)
								{
									num = (_0024State = 2);
									_0024A2 = val;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_69_GetUserProxiesAsync>(ref val, ref _this);
									return;
								}
								goto IL_0514;
							}
							_0024VB_0024Me.Log(string.Format("获取隧道列表失败：{0}", (object)jObject["msg"]));
							break;
							IL_0137:
							result2 = awaiter2.GetResult();
							awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
							val3 = result2;
							if (val3.IsSuccessStatusCode)
							{
								awaiter = val3.Content.ReadAsStringAsync().GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 1);
									_0024A1 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_69_GetUserProxiesAsync>(ref awaiter, ref _this);
									return;
								}
								goto IL_01ae;
							}
							_0024VB_0024Me.Log($"请求隧道列表失败：{val3.StatusCode}");
							break;
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_client_00241 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_client_00241).Dispose();
						}
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"获取隧道列表出错：{ex2.Message}");
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_70_TcpPingAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder<int> _0024Builder;

		internal string _0024VB_0024Local_host;

		internal int _0024VB_0024Local_port;

		internal int _0024VB_0024Local_timeout;

		internal PageLinkLobby _0024VB_0024Me;

		internal Stopwatch _0024VB_0024ResumableLocal_sw_00240;

		internal System.Threading.Tasks.Task _0024VB_0024ResumableLocal_connectTask_00241;

		internal TcpClient _0024VB_0024ResumableLocal_client_00242;

		internal TaskAwaiter<System.Threading.Tasks.Task> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			int result2;
			try
			{
				if (num != -3)
				{
				}
				try
				{
					TaskAwaiter<System.Threading.Tasks.Task> awaiter;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
					{
						_0024VB_0024ResumableLocal_client_00242 = new TcpClient();
						_0024VB_0024ResumableLocal_sw_00240 = Stopwatch.StartNew();
						_0024VB_0024ResumableLocal_connectTask_00241 = _0024VB_0024ResumableLocal_client_00242.ConnectAsync(_0024VB_0024Local_host, _0024VB_0024Local_port);
						System.Threading.Tasks.Task task = System.Threading.Tasks.Task.Delay(_0024VB_0024Local_timeout);
						awaiter = System.Threading.Tasks.Task.WhenAny(_0024VB_0024ResumableLocal_connectTask_00241, task).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<System.Threading.Tasks.Task>, VB_0024StateMachine_70_TcpPingAsync>(ref awaiter, ref _this);
							return;
						}
						break;
					}
					case 0:
						num = (_0024State = -1);
						awaiter = _0024A0;
						_0024A0 = default(TaskAwaiter<System.Threading.Tasks.Task>);
						break;
					}
					System.Threading.Tasks.Task result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<System.Threading.Tasks.Task>);
					_0024VB_0024ResumableLocal_sw_00240.Stop();
					if (result == _0024VB_0024ResumableLocal_connectTask_00241 && !_0024VB_0024ResumableLocal_connectTask_00241.IsFaulted)
					{
						_0024VB_0024ResumableLocal_client_00242.Close();
						result2 = checked((int)_0024VB_0024ResumableLocal_sw_00240.ElapsedMilliseconds);
					}
					else
					{
						_0024VB_0024ResumableLocal_client_00242.Close();
						result2 = -1;
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					result2 = -1;
					ProjectData.ClearProjectError();
				}
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
			_0024Builder.SetResult(result2);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_71_TestProxiesLatencyAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal List<ProxyInfo> _0024VB_0024Local_proxies;

		internal PageLinkLobby _0024VB_0024Me;

		internal _Closure_0024__71_002D1 _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;

		internal System.Collections.Generic.IEnumerator<ProxyInfo> _0024S1;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Expected O, but got Unknown
			int num = _0024State;
			try
			{
				if (num != -3 && num != 0)
				{
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240 = new _Closure_0024__71_002D1(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240);
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Me = _0024VB_0024Me;
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_proxies = _0024VB_0024Local_proxies;
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
						_0024VB_0024Me.Log("开始测试隧道延迟...");
						_Closure_0024__71_002D0 arg = default(_Closure_0024__71_002D0);
						val = System.Threading.Tasks.Task.WhenAll(Enumerable.ToArray<System.Threading.Tasks.Task>(Enumerable.Select<ProxyInfo, System.Threading.Tasks.Task>((System.Collections.Generic.IEnumerable<ProxyInfo>)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_proxies, (Func<ProxyInfo, System.Threading.Tasks.Task>)([SpecialName] [CompilerGenerated] (ProxyInfo proxy) => System.Threading.Tasks.Task.Run((Func<System.Threading.Tasks.Task>)new _Closure_0024__71_002D0(null)
						{
							_0024VB_0024Me = _0024VB_0024Me,
							_0024VB_0024Local_proxy = proxy
						}._Lambda_0024__1))))).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_71_TestProxiesLatencyAsync>(ref val, ref _this);
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
					try
					{
						_0024S1 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_proxies.GetEnumerator();
						while (_0024S1.MoveNext())
						{
							ProxyInfo current = _0024S1.Current;
							_0024VB_0024Me.Log(string.Format("{0} - {1}: {2}", (object)current.FriendlyNode, (object)current.ProxyName, (object)((current.Latency > 0) ? (Conversions.ToString(current.Latency) + "ms") : "超时")));
						}
					}
					finally
					{
						if (num < 0)
						{
							((System.IDisposable)_0024S1).Dispose();
						}
					}
					((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
					{
						List<VB_0024AnonymousType_0<string, ProxyInfo>> val2 = Enumerable.ToList<VB_0024AnonymousType_0<string, ProxyInfo>>(Enumerable.Select<ProxyInfo, VB_0024AnonymousType_0<string, ProxyInfo>>((System.Collections.Generic.IEnumerable<ProxyInfo>)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_proxies, (Func<ProxyInfo, VB_0024AnonymousType_0<string, ProxyInfo>>)([SpecialName] (ProxyInfo p) => new VB_0024AnonymousType_0<string, ProxyInfo>(string.Format("{0} - {1} ({2}) [{3}]", new object[4]
						{
							p.FriendlyNode,
							p.ProxyName,
							p.RemotePort,
							(p.Latency > 0) ? (Conversions.ToString(p.Latency) + "ms") : "超时"
						}), p))));
						((ItemsControl)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Me.ComboTunnel).ItemsSource = (System.Collections.IEnumerable)val2;
						if (val2.Count > 0 && ((Selector)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Me.ComboTunnel).SelectedIndex < 0)
						{
							((Selector)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Me.ComboTunnel).SelectedIndex = 0;
						}
					}));
					_0024VB_0024Me.Log("延迟测试完成");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"测试延迟出错: {ex2.Message}");
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_73_StartFrpcTunnel : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal ProxyInfo _0024VB_0024Local_proxy;

		internal int _0024VB_0024Local_localPort;

		internal string _0024VB_0024Local_cookieHeader;

		internal string _0024VB_0024Local_authorization;

		internal PageLinkLobby _0024VB_0024Me;

		internal TaskAwaiter<string> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Expected O, but got Unknown
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Expected O, but got Unknown
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Expected O, but got Unknown
			//IL_028e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0298: Expected O, but got Unknown
			int num = _0024State;
			try
			{
				if (num != -3)
				{
				}
				try
				{
					TaskAwaiter<string> awaiter;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						_0024VB_0024Me.Log("===== 开始启动 Frpc 隧道 =====");
						awaiter = _0024VB_0024Me.GetNodeConfAsync(_0024VB_0024Local_proxy.Nid, _0024VB_0024Local_cookieHeader, _0024VB_0024Local_authorization).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_73_StartFrpcTunnel>(ref awaiter, ref _this);
							return;
						}
						break;
					case 0:
						num = (_0024State = -1);
						awaiter = _0024A0;
						_0024A0 = default(TaskAwaiter<string>);
						break;
					}
					string result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<string>);
					string text = result;
					if (string.IsNullOrWhiteSpace(text))
					{
						_0024VB_0024Me.Log("获取节点配置失败");
						ModMain.Hint("获取节点配置失败！", ModMain.HintType.Critical);
					}
					else
					{
						string text2 = _0024VB_0024Me.ModifyTomlConfig(text, _0024VB_0024Local_proxy.ProxyName, _0024VB_0024Local_localPort);
						if (string.IsNullOrWhiteSpace(text2))
						{
							_0024VB_0024Me.Log("修改配置文件失败");
							ModMain.Hint("配置文件处理失败！", ModMain.HintType.Critical);
						}
						else
						{
							_0024VB_0024Me.ExtractServerInfo(text2);
							string text3 = Path.Combine(ModBase.PathAppdata, "PCL", "Frpc", "Configs");
							if (!Directory.Exists(text3))
							{
								Directory.CreateDirectory(text3);
							}
							string text4 = Path.Combine(text3, $"{_0024VB_0024Local_proxy.ProxyName}_{System.DateTime.Now:yyyyMMddHHmmss}.toml");
							UTF8Encoding val = new UTF8Encoding(false);
							File.WriteAllText(text4, text2, (Encoding)(object)val);
							_0024VB_0024Me.Log($"配置文件已保存: {text4}");
							string frpcPath = ModLink.GetFrpcPath();
							_0024VB_0024Me._frpcProcess = new Process();
							_0024VB_0024Me._frpcProcess.StartInfo.FileName = frpcPath;
							_0024VB_0024Me._frpcProcess.StartInfo.Arguments = $"-c \"{text4}\"";
							_0024VB_0024Me._frpcProcess.StartInfo.UseShellExecute = false;
							_0024VB_0024Me._frpcProcess.StartInfo.RedirectStandardOutput = true;
							_0024VB_0024Me._frpcProcess.StartInfo.RedirectStandardError = true;
							_0024VB_0024Me._frpcProcess.StartInfo.CreateNoWindow = true;
							_0024VB_0024Me._frpcProcess.OutputDataReceived += (DataReceivedEventHandler)([SpecialName] [CompilerGenerated] (object s, DataReceivedEventArgs e) =>
							{
								//IL_0033: Unknown result type (might be due to invalid IL or missing references)
								//IL_003d: Expected O, but got Unknown
								_Closure_0024__73_002D0 CS_0024_003C_003E8__locals1 = new _Closure_0024__73_002D0
								{
									_0024VB_0024Me = _0024VB_0024Me,
									_0024VB_0024Local_e = e
								};
								if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1._0024VB_0024Local_e.Data))
								{
									((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
									{
										CS_0024_003C_003E8__locals1._0024VB_0024Me.Log($"[Frpc] {CS_0024_003C_003E8__locals1._0024VB_0024Local_e.Data}");
									}));
								}
							});
							_0024VB_0024Me._frpcProcess.ErrorDataReceived += (DataReceivedEventHandler)([SpecialName] [CompilerGenerated] (object s, DataReceivedEventArgs e) =>
							{
								//IL_0033: Unknown result type (might be due to invalid IL or missing references)
								//IL_003d: Expected O, but got Unknown
								_Closure_0024__73_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__73_002D1
								{
									_0024VB_0024Me = _0024VB_0024Me,
									_0024VB_0024Local_e = e
								};
								if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0._0024VB_0024Local_e.Data))
								{
									((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
									{
										CS_0024_003C_003E8__locals0._0024VB_0024Me.Log($"[Frpc错误] {CS_0024_003C_003E8__locals0._0024VB_0024Local_e.Data}");
									}));
								}
							});
							_0024VB_0024Me._frpcProcess.Start();
							_0024VB_0024Me._frpcProcess.BeginOutputReadLine();
							_0024VB_0024Me._frpcProcess.BeginErrorReadLine();
							_0024VB_0024Me._isRunning = true;
							_0024VB_0024Me._startTime = System.DateTime.Now;
							((TextBox)_0024VB_0024Me.TextAddress).Text = _0024VB_0024Local_proxy.ConnectAddress;
							_0024VB_0024Me.Log("Frpc 隧道启动成功！");
							ModMain.Hint("联机已启动！", ModMain.HintType.Finish);
							_0024VB_0024Me.RefreshUi();
							_0024VB_0024Me.CleanupOldConfigFiles(text3, 5);
						}
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"启动Frpc隧道失败：{ex2.Message}");
					ModMain.Hint("启动隧道失败！", ModMain.HintType.Critical);
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine_74_GetNodeConfAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder<string> _0024Builder;

		internal int _0024VB_0024Local_nid;

		internal string _0024VB_0024Local_cookieHeader;

		internal string _0024VB_0024Local_authorization;

		internal PageLinkLobby _0024VB_0024Me;

		internal HttpClient _0024VB_0024ResumableLocal_client_00240;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected O, but got Unknown
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Expected O, but got Unknown
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			string result2;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					if (num != -3 && (uint)num > 1u)
					{
						_0024VB_0024Me.Log($"正在获取节点 {_0024VB_0024Local_nid} 的配置...");
						_0024VB_0024ResumableLocal_client_00240 = new HttpClient();
					}
					try
					{
						string result;
						TaskAwaiter<string> awaiter;
						JObject jObject;
						JToken? jToken;
						HttpResponseMessage result3;
						TaskAwaiter<HttpResponseMessage> awaiter2;
						HttpResponseMessage val2;
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return;
						default:
						{
							_0024VB_0024ResumableLocal_client_00240.Timeout = TimeSpan.FromSeconds(10.0);
							((HttpHeaders)_0024VB_0024ResumableLocal_client_00240.DefaultRequestHeaders).Add("Cookie", _0024VB_0024Local_cookieHeader);
							if (!string.IsNullOrWhiteSpace(_0024VB_0024Local_authorization))
							{
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00240.DefaultRequestHeaders).Add("authorization", _0024VB_0024Local_authorization);
							}
							string text = $"{{\"node_id\":{_0024VB_0024Local_nid}}}";
							StringContent val = new StringContent(text, Encoding.UTF8, "application/json");
							awaiter2 = _0024VB_0024ResumableLocal_client_00240.PostAsync("https://console.openfrp.net/web/frp/api/getNodeConf", (HttpContent)(object)val).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = awaiter2;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_74_GetNodeConfAsync>(ref awaiter2, ref _this);
								return;
							}
							goto IL_0158;
						}
						case 0:
							num = (_0024State = -1);
							awaiter2 = _0024A0;
							_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
							goto IL_0158;
						case 1:
							{
								num = (_0024State = -1);
								awaiter = _0024A1;
								_0024A1 = default(TaskAwaiter<string>);
								goto IL_01d2;
							}
							IL_01d2:
							result = awaiter.GetResult();
							awaiter = default(TaskAwaiter<string>);
							jObject = JObject.Parse(result);
							jToken = jObject["flag"];
							if (jToken != null && jToken.Value<bool>())
							{
								string obj = jObject["data"]?.ToString();
								_0024VB_0024Me.Log("节点配置获取成功");
								result2 = obj;
								break;
							}
							_0024VB_0024Me.Log(string.Format("获取节点配置失败：{0}", (object)jObject["msg"]));
							goto end_IL_0046;
							IL_0158:
							result3 = awaiter2.GetResult();
							awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
							val2 = result3;
							if (val2.IsSuccessStatusCode)
							{
								awaiter = val2.Content.ReadAsStringAsync().GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 1);
									_0024A1 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_74_GetNodeConfAsync>(ref awaiter, ref _this);
									return;
								}
								goto IL_01d2;
							}
							_0024VB_0024Me.Log($"请求节点配置失败：{val2.StatusCode}");
							goto end_IL_0046;
						}
						goto end_IL_0007;
						end_IL_0046:;
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_client_00240 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_client_00240).Dispose();
						}
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"获取节点配置出错：{ex2.Message}");
					ProjectData.ClearProjectError();
				}
				result2 = "";
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
			_0024Builder.SetResult(result2);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_75_GetMeFrpProxyConfigAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder<string> _0024Builder;

		internal int _0024VB_0024Local_proxyId;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal HttpClient _0024VB_0024ResumableLocal_client_00240;

		internal HttpClientHandler _0024VB_0024ResumableLocal_handler_00241;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<string> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Expected O, but got Unknown
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Expected O, but got Unknown
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			string result3;
			try
			{
				if (num != -3)
				{
					_ = 1;
				}
				try
				{
					if (num != -3 && (uint)num > 1u)
					{
						_0024VB_0024Me.Log($"正在获取 MeFrp 隧道 {_0024VB_0024Local_proxyId} 的配置...");
						_0024VB_0024ResumableLocal_handler_00241 = new HttpClientHandler
						{
							UseCookies = false
						};
					}
					try
					{
						if (num != -3 && (uint)num > 1u)
						{
							_0024VB_0024ResumableLocal_client_00240 = new HttpClient((HttpMessageHandler)(object)_0024VB_0024ResumableLocal_handler_00241);
						}
						try
						{
							HttpResponseMessage result;
							TaskAwaiter<HttpResponseMessage> awaiter2;
							HttpResponseMessage val2;
							string result2;
							TaskAwaiter<string> awaiter;
							JObject jObject;
							JToken? jToken;
							switch (num)
							{
							case -3:
								num = (_0024State = -1);
								return;
							default:
							{
								_0024VB_0024ResumableLocal_client_00240.Timeout = TimeSpan.FromSeconds(10.0);
								((HttpHeaders)_0024VB_0024ResumableLocal_client_00240.DefaultRequestHeaders).Add("Authorization", $"Bearer {_0024VB_0024Local_token}");
								string text = $"{{\"proxyId\":{_0024VB_0024Local_proxyId},\"format\":\"toml\"}}";
								StringContent val = new StringContent(text, Encoding.UTF8, "application/json");
								awaiter2 = _0024VB_0024ResumableLocal_client_00240.PostAsync("https://api.mefrp.com/api/auth/proxy/config", (HttpContent)(object)val).GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_75_GetMeFrpProxyConfigAsync>(ref awaiter2, ref _this);
									return;
								}
								goto IL_015c;
							}
							case 0:
								num = (_0024State = -1);
								awaiter2 = _0024A0;
								_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
								goto IL_015c;
							case 1:
								{
									num = (_0024State = -1);
									awaiter = _0024A1;
									_0024A1 = default(TaskAwaiter<string>);
									goto IL_01d6;
								}
								IL_015c:
								result = awaiter2.GetResult();
								awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
								val2 = result;
								if (val2.IsSuccessStatusCode)
								{
									awaiter = val2.Content.ReadAsStringAsync().GetAwaiter();
									if (!awaiter.IsCompleted)
									{
										num = (_0024State = 1);
										_0024A1 = awaiter;
										_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_75_GetMeFrpProxyConfigAsync>(ref awaiter, ref _this);
										return;
									}
									goto IL_01d6;
								}
								_0024VB_0024Me.Log($"请求 MeFrp 配置失败：{val2.StatusCode}");
								goto end_IL_0068;
								IL_01d6:
								result2 = awaiter.GetResult();
								awaiter = default(TaskAwaiter<string>);
								jObject = JObject.Parse(result2);
								jToken = jObject["code"];
								if (jToken != null && jToken.Value<int>() == 200)
								{
									JToken jToken2 = jObject["data"];
									string obj = jToken2["config"]?.ToString();
									_0024VB_0024Me.Log("MeFrp 配置获取成功");
									result3 = obj;
									break;
								}
								_0024VB_0024Me.Log(string.Format("获取 MeFrp 配置失败：{0}", (object)jObject["message"]));
								goto end_IL_0068;
							}
							goto end_IL_0007;
							end_IL_0068:;
						}
						finally
						{
							if (num < 0 && _0024VB_0024ResumableLocal_client_00240 != null)
							{
								((System.IDisposable)_0024VB_0024ResumableLocal_client_00240).Dispose();
							}
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_handler_00241 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_handler_00241).Dispose();
						}
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"获取 MeFrp 配置出错：{ex2.Message}");
					ProjectData.ClearProjectError();
				}
				result3 = "";
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
			_0024Builder.SetResult(result3);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_76_StartMeFrpcTunnel : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal ProxyInfo _0024VB_0024Local_proxy;

		internal int _0024VB_0024Local_localPort;

		internal string _0024VB_0024Local_token;

		internal PageLinkLobby _0024VB_0024Me;

		internal TaskAwaiter<string> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Expected O, but got Unknown
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Expected O, but got Unknown
			//IL_025e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Expected O, but got Unknown
			//IL_027f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Expected O, but got Unknown
			int num = _0024State;
			try
			{
				if (num != -3)
				{
				}
				try
				{
					TaskAwaiter<string> awaiter;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						_0024VB_0024Me.Log("===== 开始启动 MeFrp 隧道 =====");
						awaiter = _0024VB_0024Me.GetMeFrpProxyConfigAsync(_0024VB_0024Local_proxy.ProxyId, _0024VB_0024Local_token).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_76_StartMeFrpcTunnel>(ref awaiter, ref _this);
							return;
						}
						break;
					case 0:
						num = (_0024State = -1);
						awaiter = _0024A0;
						_0024A0 = default(TaskAwaiter<string>);
						break;
					}
					string result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<string>);
					string text = result;
					if (string.IsNullOrWhiteSpace(text))
					{
						_0024VB_0024Me.Log("获取 MeFrp 配置失败");
						ModMain.Hint("获取配置失败！", ModMain.HintType.Critical);
					}
					else
					{
						string text2 = _0024VB_0024Me.ModifyTomlConfig(text, _0024VB_0024Local_proxy.ProxyName, _0024VB_0024Local_localPort);
						if (string.IsNullOrWhiteSpace(text2))
						{
							_0024VB_0024Me.Log("解析 MeFrp 配置失败，使用原始配置");
							text2 = text;
						}
						string text3 = text2;
						_0024VB_0024Me.ExtractServerInfo(text3);
						string text4 = Path.Combine(ModBase.PathAppdata, "PCL", "Frpc", "Configs");
						if (!Directory.Exists(text4))
						{
							Directory.CreateDirectory(text4);
						}
						string text5 = Path.Combine(text4, $"{_0024VB_0024Local_proxy.ProxyName}_{System.DateTime.Now:yyyyMMddHHmmss}.toml");
						UTF8Encoding val = new UTF8Encoding(false);
						File.WriteAllText(text5, text3, (Encoding)(object)val);
						_0024VB_0024Me.Log($"配置文件已保存: {text5}");
						string frpcPath = ModLink.GetFrpcPath();
						_0024VB_0024Me._frpcProcess = new Process();
						_0024VB_0024Me._frpcProcess.StartInfo.FileName = frpcPath;
						_0024VB_0024Me._frpcProcess.StartInfo.Arguments = $"-c \"{text5}\"";
						_0024VB_0024Me._frpcProcess.StartInfo.UseShellExecute = false;
						_0024VB_0024Me._frpcProcess.StartInfo.RedirectStandardOutput = true;
						_0024VB_0024Me._frpcProcess.StartInfo.RedirectStandardError = true;
						_0024VB_0024Me._frpcProcess.StartInfo.CreateNoWindow = true;
						_0024VB_0024Me._frpcProcess.OutputDataReceived += (DataReceivedEventHandler)([SpecialName] [CompilerGenerated] (object s, DataReceivedEventArgs e) =>
						{
							//IL_0033: Unknown result type (might be due to invalid IL or missing references)
							//IL_003d: Expected O, but got Unknown
							_Closure_0024__76_002D0 CS_0024_003C_003E8__locals1 = new _Closure_0024__76_002D0
							{
								_0024VB_0024Me = _0024VB_0024Me,
								_0024VB_0024Local_e = e
							};
							if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1._0024VB_0024Local_e.Data))
							{
								((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
								{
									CS_0024_003C_003E8__locals1._0024VB_0024Me.Log($"[Frpc] {CS_0024_003C_003E8__locals1._0024VB_0024Local_e.Data}");
								}));
							}
						});
						_0024VB_0024Me._frpcProcess.ErrorDataReceived += (DataReceivedEventHandler)([SpecialName] [CompilerGenerated] (object s, DataReceivedEventArgs e) =>
						{
							//IL_0033: Unknown result type (might be due to invalid IL or missing references)
							//IL_003d: Expected O, but got Unknown
							_Closure_0024__76_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__76_002D1
							{
								_0024VB_0024Me = _0024VB_0024Me,
								_0024VB_0024Local_e = e
							};
							if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0._0024VB_0024Local_e.Data))
							{
								((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
								{
									CS_0024_003C_003E8__locals0._0024VB_0024Me.Log($"[Frpc错误] {CS_0024_003C_003E8__locals0._0024VB_0024Local_e.Data}");
								}));
							}
						});
						_0024VB_0024Me._frpcProcess.Start();
						_0024VB_0024Me._frpcProcess.BeginOutputReadLine();
						_0024VB_0024Me._frpcProcess.BeginErrorReadLine();
						_0024VB_0024Me._isRunning = true;
						_0024VB_0024Me._startTime = System.DateTime.Now;
						((TextBox)_0024VB_0024Me.TextAddress).Text = $"{_0024VB_0024Local_proxy.ConnectAddress}:{_0024VB_0024Local_proxy.RemotePort}";
						_0024VB_0024Me.Log("MeFrp 隧道启动成功！");
						ModMain.Hint("联机已启动！", ModMain.HintType.Finish);
						_0024VB_0024Me.RefreshUi();
						_0024VB_0024Me.CleanupOldConfigFiles(text4, 5);
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Me.Log($"启动 MeFrp 隧道失败：{ex2.Message}");
					ModMain.Hint("启动隧道失败！", ModMain.HintType.Critical);
					ProjectData.ClearProjectError();
				}
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
	internal sealed class VB_0024StateMachine___Lambda_0024__24_002D0 : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal PageLinkLobby _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_004e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num != 0)
				{
					val = _0024VB_0024Me.UpdateRunningLatency().GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine___Lambda_0024__24_002D0>(ref val, ref _this);
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

	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<string, bool> _0024I47_002D0;

		public static Func<string, string> _0024I49_002D0;

		public static Action _0024I51_002D1;

		public static Func<ProxyInfo, int> _0024I53_002D1;

		public static Func<ProxyInfo, VB_0024AnonymousType_0<string, ProxyInfo>> _0024I69_002D1;

		public static Func<ProxyInfo, VB_0024AnonymousType_0<string, ProxyInfo>> _0024I71_002D3;

		public static Func<string, System.DateTime> _0024I79_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal bool _Lambda_0024__47_002D0(string l)
		{
			string text = l.ToLowerInvariant();
			if (!text.Contains("www.natfrp.com"))
			{
				return text.Contains("domain=.natfrp.com");
			}
			return true;
		}

		[SpecialName]
		internal string _Lambda_0024__49_002D0(string l)
		{
			return l.Split('=', (StringSplitOptions)0)[0];
		}

		[SpecialName]
		internal void _Lambda_0024__51_002D1()
		{
			ModMain.Hint("登录已过期，请重新登录！", ModMain.HintType.Critical);
		}

		[SpecialName]
		internal int _Lambda_0024__53_002D1(ProxyInfo p)
		{
			if (p.Latency <= 0)
			{
				return 2147483647;
			}
			return p.Latency;
		}

		[SpecialName]
		internal VB_0024AnonymousType_0<string, ProxyInfo> _Lambda_0024__69_002D1(ProxyInfo p)
		{
			return new VB_0024AnonymousType_0<string, ProxyInfo>($"{p.FriendlyNode} - {p.ProxyName} ({p.RemotePort}) [测试中...]", p);
		}

		[SpecialName]
		internal VB_0024AnonymousType_0<string, ProxyInfo> _Lambda_0024__71_002D3(ProxyInfo p)
		{
			return new VB_0024AnonymousType_0<string, ProxyInfo>(string.Format("{0} - {1} ({2}) [{3}]", new object[4]
			{
				p.FriendlyNode,
				p.ProxyName,
				p.RemotePort,
				(p.Latency > 0) ? (Conversions.ToString(p.Latency) + "ms") : "超时"
			}), p);
		}

		[SpecialName]
		internal System.DateTime _Lambda_0024__79_002D0(string f)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return ((FileSystemInfo)new FileInfo(f)).CreationTime;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__25_002D0
	{
		public int _0024VB_0024Local_latency;

		public PageLinkLobby _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			if (_0024VB_0024Local_latency > 0)
			{
				_0024VB_0024Me.LabRunningLatency.Text = $"延迟: {_0024VB_0024Local_latency} ms";
			}
			else
			{
				_0024VB_0024Me.LabRunningLatency.Text = "延迟: 超时";
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__26_002D0
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine___Lambda_0024__0 : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncVoidMethodBuilder _0024Builder;

			internal object _0024VB_0024Local_s;

			internal CoreWebView2NavigationCompletedEventArgs _0024VB_0024Local_e;

			internal _Closure_0024__26_002D0 _0024VB_0024NonLocal__Closure_0024__26_002D0;

			internal TaskAwaiter<string> _0024A0;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_008f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0094: Unknown result type (might be due to invalid IL or missing references)
				//IL_009b: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
				//IL_0053: Unknown result type (might be due to invalid IL or missing references)
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_006c: Unknown result type (might be due to invalid IL or missing references)
				//IL_006d: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				try
				{
					if (num != -3)
					{
					}
					try
					{
						TaskAwaiter<string> awaiter;
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return;
						default:
							if (_0024VB_0024NonLocal__Closure_0024__26_002D0._0024VB_0024Local_webview.CoreWebView2 != null)
							{
								awaiter = _0024VB_0024NonLocal__Closure_0024__26_002D0._0024VB_0024Local_webview.CoreWebView2.ExecuteScriptAsync("localStorage.removeItem('token');").GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine___Lambda_0024__0>(ref awaiter, ref _this);
									return;
								}
								break;
							}
							goto end_IL_000f;
						case 0:
							num = (_0024State = -1);
							awaiter = _0024A0;
							_0024A0 = default(TaskAwaiter<string>);
							break;
						}
						awaiter.GetResult();
						awaiter = default(TaskAwaiter<string>);
						end_IL_000f:;
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					_0024VB_0024NonLocal__Closure_0024__26_002D0._0024VB_0024Local_tcs.TrySetResult(true);
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

		public WebView2 _0024VB_0024Local_webview;

		public TaskCompletionSource<bool> _0024VB_0024Local_tcs;

		[SpecialName]
		[AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__0))]
		internal void _Lambda_0024__0(object s, CoreWebView2NavigationCompletedEventArgs e)
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__26_002D0 = this;
			vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_s = s;
			vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_e = e;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncVoidMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__27_002D0
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine___Lambda_0024__0 : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncVoidMethodBuilder _0024Builder;

			internal object _0024VB_0024Local_s;

			internal CoreWebView2NavigationCompletedEventArgs _0024VB_0024Local_e;

			internal _Closure_0024__27_002D0 _0024VB_0024NonLocal__Closure_0024__27_002D0;

			internal CoreWebView2CookieManager _0024VB_0024ResumableLocal_cookieManager_00240;

			internal System.Collections.Generic.IEnumerator<CoreWebView2Cookie> _0024S1;

			internal System.Collections.Generic.IEnumerator<CoreWebView2Cookie> _0024S2;

			internal TaskAwaiter<List<CoreWebView2Cookie>> _0024A0;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
				//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
				//IL_0177: Unknown result type (might be due to invalid IL or missing references)
				//IL_017c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0184: Unknown result type (might be due to invalid IL or missing references)
				//IL_007e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0083: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
				//IL_0193: Unknown result type (might be due to invalid IL or missing references)
				//IL_0097: Unknown result type (might be due to invalid IL or missing references)
				//IL_0098: Unknown result type (might be due to invalid IL or missing references)
				//IL_00de: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
				//IL_019c: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
				//IL_0139: Unknown result type (might be due to invalid IL or missing references)
				//IL_013e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0153: Unknown result type (might be due to invalid IL or missing references)
				//IL_0155: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				try
				{
					if (num != -3)
					{
						_ = 1;
					}
					try
					{
						List<CoreWebView2Cookie> result;
						TaskAwaiter<List<CoreWebView2Cookie>> awaiter2;
						List<CoreWebView2Cookie> val;
						TaskAwaiter<List<CoreWebView2Cookie>> awaiter;
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return;
						default:
							if (_0024VB_0024NonLocal__Closure_0024__27_002D0._0024VB_0024Local_webview.CoreWebView2 != null)
							{
								_0024VB_0024ResumableLocal_cookieManager_00240 = _0024VB_0024NonLocal__Closure_0024__27_002D0._0024VB_0024Local_webview.CoreWebView2.CookieManager;
								awaiter2 = _0024VB_0024ResumableLocal_cookieManager_00240.GetCookiesAsync("https://www.natfrp.com").GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<CoreWebView2Cookie>>, VB_0024StateMachine___Lambda_0024__0>(ref awaiter2, ref _this);
									return;
								}
								goto IL_00cc;
							}
							goto end_IL_0011;
						case 0:
							num = (_0024State = -1);
							awaiter2 = _0024A0;
							_0024A0 = default(TaskAwaiter<List<CoreWebView2Cookie>>);
							goto IL_00cc;
						case 1:
							{
								num = (_0024State = -1);
								awaiter = _0024A0;
								_0024A0 = default(TaskAwaiter<List<CoreWebView2Cookie>>);
								break;
							}
							IL_00cc:
							result = awaiter2.GetResult();
							awaiter2 = default(TaskAwaiter<List<CoreWebView2Cookie>>);
							val = result;
							try
							{
								_0024S1 = val.GetEnumerator();
								while (_0024S1.MoveNext())
								{
									CoreWebView2Cookie current = _0024S1.Current;
									_0024VB_0024ResumableLocal_cookieManager_00240.DeleteCookie(current);
								}
							}
							finally
							{
								if (num < 0)
								{
									((System.IDisposable)_0024S1).Dispose();
								}
							}
							awaiter = _0024VB_0024ResumableLocal_cookieManager_00240.GetCookiesAsync("https://openid.13a.com").GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_0024State = 1);
								_0024A0 = awaiter;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<CoreWebView2Cookie>>, VB_0024StateMachine___Lambda_0024__0>(ref awaiter, ref _this);
								return;
							}
							break;
						}
						List<CoreWebView2Cookie> result2 = awaiter.GetResult();
						awaiter = default(TaskAwaiter<List<CoreWebView2Cookie>>);
						List<CoreWebView2Cookie> val2 = result2;
						try
						{
							_0024S2 = val2.GetEnumerator();
							while (_0024S2.MoveNext())
							{
								CoreWebView2Cookie current2 = _0024S2.Current;
								_0024VB_0024ResumableLocal_cookieManager_00240.DeleteCookie(current2);
							}
						}
						finally
						{
							if (num < 0)
							{
								((System.IDisposable)_0024S2).Dispose();
							}
						}
						end_IL_0011:;
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					_0024VB_0024NonLocal__Closure_0024__27_002D0._0024VB_0024Local_tcs.TrySetResult(true);
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

		public WebView2 _0024VB_0024Local_webview;

		public TaskCompletionSource<bool> _0024VB_0024Local_tcs;

		public _Closure_0024__27_002D0(_Closure_0024__27_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_webview = arg0._0024VB_0024Local_webview;
				_0024VB_0024Local_tcs = arg0._0024VB_0024Local_tcs;
			}
		}

		[SpecialName]
		[AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__0))]
		internal void _Lambda_0024__0(object s, CoreWebView2NavigationCompletedEventArgs e)
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__27_002D0 = this;
			vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_s = s;
			vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_e = e;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncVoidMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__53_002D0
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine___Lambda_0024__0 : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncTaskMethodBuilder _0024Builder;

			internal _Closure_0024__53_002D0 _0024VB_0024NonLocal__Closure_0024__53_002D0;

			internal TaskAwaiter<int> _0024A0;

			internal ProxyInfo _0024U1;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
				//IL_0064: Unknown result type (might be due to invalid IL or missing references)
				//IL_0069: Unknown result type (might be due to invalid IL or missing references)
				//IL_007d: Unknown result type (might be due to invalid IL or missing references)
				//IL_007e: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				try
				{
					TaskAwaiter<int> awaiter;
					if (num == 0)
					{
						num = (_0024State = -1);
						awaiter = _0024A0;
						_0024A0 = default(TaskAwaiter<int>);
						goto IL_00b2;
					}
					if (!string.IsNullOrWhiteSpace(_0024VB_0024NonLocal__Closure_0024__53_002D0._0024VB_0024Local_proxy.ConnectAddress))
					{
						_0024U1 = _0024VB_0024NonLocal__Closure_0024__53_002D0._0024VB_0024Local_proxy;
						awaiter = _0024VB_0024NonLocal__Closure_0024__53_002D0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.TcpPingAsync(_0024VB_0024NonLocal__Closure_0024__53_002D0._0024VB_0024Local_proxy.ConnectAddress, 80, 3000).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, VB_0024StateMachine___Lambda_0024__0>(ref awaiter, ref _this);
							return;
						}
						goto IL_00b2;
					}
					goto end_IL_0007;
					IL_00b2:
					ProxyInfo proxyInfo = _0024U1;
					int result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<int>);
					proxyInfo.Latency = result;
					_0024U1 = null;
					if (_0024VB_0024NonLocal__Closure_0024__53_002D0._0024VB_0024Local_proxy.Latency > 0)
					{
						_0024VB_0024NonLocal__Closure_0024__53_002D0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.Log($"隧道 {_0024VB_0024NonLocal__Closure_0024__53_002D0._0024VB_0024Local_proxy.ProxyName} 延迟: {_0024VB_0024NonLocal__Closure_0024__53_002D0._0024VB_0024Local_proxy.Latency}ms");
					}
					else
					{
						_0024VB_0024NonLocal__Closure_0024__53_002D0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.Log($"隧道 {_0024VB_0024NonLocal__Closure_0024__53_002D0._0024VB_0024Local_proxy.ProxyName} 延迟测试失败");
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

		public ProxyInfo _0024VB_0024Local_proxy;

		public _Closure_0024__53_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__53_002D0(_Closure_0024__53_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_proxy = arg0._0024VB_0024Local_proxy;
			}
		}

		[SpecialName]
		[AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__0))]
		internal System.Threading.Tasks.Task _Lambda_0024__0()
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__53_002D0 = this;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
			return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__53_002D1
	{
		public List<ProxyInfo> _0024VB_0024Local_sortedProxies;

		public PageLinkLobby _0024VB_0024Me;

		public _Closure_0024__53_002D1(_Closure_0024__53_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_sortedProxies = arg0._0024VB_0024Local_sortedProxies;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			List<TunnelItem> val = new List<TunnelItem>();
			System.Collections.Generic.IEnumerator<ProxyInfo> enumerator = default(System.Collections.Generic.IEnumerator<ProxyInfo>);
			try
			{
				enumerator = _0024VB_0024Local_sortedProxies.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ProxyInfo current = enumerator.Current;
					val.Add(new TunnelItem
					{
						Proxy = current,
						DisplayText = $"{current.ProxyName} [{current.NodeName}] - 端口 {current.RemotePort}" + ((current.Latency > 0) ? $" ({current.Latency}ms)" : " (超时)")
					});
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			((ItemsControl)_0024VB_0024Me.ComboTunnel).ItemsSource = (System.Collections.IEnumerable)val;
			((ItemsControl)_0024VB_0024Me.ComboTunnel).DisplayMemberPath = "DisplayText";
			if (val.Count > 0)
			{
				((Selector)_0024VB_0024Me.ComboTunnel).SelectedIndex = 0;
			}
			_0024VB_0024Me.Log($"已加载 {val.Count} 个隧道到列表");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__54_002D0
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine___Lambda_0024__0 : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncVoidMethodBuilder _0024Builder;

			internal object _0024VB_0024Local_s;

			internal CoreWebView2NavigationCompletedEventArgs _0024VB_0024Local_e;

			internal _Closure_0024__54_002D0 _0024VB_0024NonLocal__Closure_0024__54_002D0;

			internal TaskAwaiter<string> _0024A0;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_008f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0094: Unknown result type (might be due to invalid IL or missing references)
				//IL_009b: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
				//IL_0053: Unknown result type (might be due to invalid IL or missing references)
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_006c: Unknown result type (might be due to invalid IL or missing references)
				//IL_006d: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				try
				{
					if (num != -3)
					{
					}
					try
					{
						TaskAwaiter<string> awaiter;
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return;
						default:
							if (_0024VB_0024NonLocal__Closure_0024__54_002D0._0024VB_0024Local_webview.CoreWebView2 != null)
							{
								awaiter = _0024VB_0024NonLocal__Closure_0024__54_002D0._0024VB_0024Local_webview.CoreWebView2.ExecuteScriptAsync("localStorage.removeItem('token'); localStorage.removeItem('access_token'); localStorage.removeItem('accessToken');").GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine___Lambda_0024__0>(ref awaiter, ref _this);
									return;
								}
								break;
							}
							goto end_IL_000f;
						case 0:
							num = (_0024State = -1);
							awaiter = _0024A0;
							_0024A0 = default(TaskAwaiter<string>);
							break;
						}
						awaiter.GetResult();
						awaiter = default(TaskAwaiter<string>);
						end_IL_000f:;
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					_0024VB_0024NonLocal__Closure_0024__54_002D0._0024VB_0024Local_tcs.TrySetResult(true);
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

		public WebView2 _0024VB_0024Local_webview;

		public TaskCompletionSource<bool> _0024VB_0024Local_tcs;

		[SpecialName]
		[AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__0))]
		internal void _Lambda_0024__0(object s, CoreWebView2NavigationCompletedEventArgs e)
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__54_002D0 = this;
			vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_s = s;
			vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_e = e;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncVoidMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__55_002D0
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine___Lambda_0024__0 : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncVoidMethodBuilder _0024Builder;

			internal object _0024VB_0024Local_s;

			internal CoreWebView2NavigationCompletedEventArgs _0024VB_0024Local_e;

			internal _Closure_0024__55_002D0 _0024VB_0024NonLocal__Closure_0024__55_002D0;

			internal TaskAwaiter<string> _0024A0;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_008f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0094: Unknown result type (might be due to invalid IL or missing references)
				//IL_009b: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
				//IL_0053: Unknown result type (might be due to invalid IL or missing references)
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_006c: Unknown result type (might be due to invalid IL or missing references)
				//IL_006d: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				try
				{
					if (num != -3)
					{
					}
					try
					{
						TaskAwaiter<string> awaiter;
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return;
						default:
							if (_0024VB_0024NonLocal__Closure_0024__55_002D0._0024VB_0024Local_webview.CoreWebView2 != null)
							{
								awaiter = _0024VB_0024NonLocal__Closure_0024__55_002D0._0024VB_0024Local_webview.CoreWebView2.ExecuteScriptAsync("localStorage.removeItem('token'); localStorage.removeItem('access_token'); localStorage.removeItem('accessToken');").GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine___Lambda_0024__0>(ref awaiter, ref _this);
									return;
								}
								break;
							}
							goto end_IL_000f;
						case 0:
							num = (_0024State = -1);
							awaiter = _0024A0;
							_0024A0 = default(TaskAwaiter<string>);
							break;
						}
						awaiter.GetResult();
						awaiter = default(TaskAwaiter<string>);
						end_IL_000f:;
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					_0024VB_0024NonLocal__Closure_0024__55_002D0._0024VB_0024Local_tcs.TrySetResult(true);
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

		public WebView2 _0024VB_0024Local_webview;

		public TaskCompletionSource<bool> _0024VB_0024Local_tcs;

		[SpecialName]
		[AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__0))]
		internal void _Lambda_0024__0(object s, CoreWebView2NavigationCompletedEventArgs e)
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__55_002D0 = this;
			vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_s = s;
			vB_0024StateMachine___Lambda_0024__._0024VB_0024Local_e = e;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncVoidMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__57_002D0
	{
		public List<ProxyInfo> _0024VB_0024Local_proxies;

		public PageLinkLobby _0024VB_0024Me;

		public _Closure_0024__57_002D0(_Closure_0024__57_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_proxies = arg0._0024VB_0024Local_proxies;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			List<TunnelItem> val = new List<TunnelItem>();
			System.Collections.Generic.IEnumerator<ProxyInfo> enumerator = default(System.Collections.Generic.IEnumerator<ProxyInfo>);
			try
			{
				enumerator = _0024VB_0024Local_proxies.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ProxyInfo current = enumerator.Current;
					val.Add(new TunnelItem
					{
						Proxy = current,
						DisplayText = $"{current.ProxyName} - 端口 {current.RemotePort}"
					});
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			((ItemsControl)_0024VB_0024Me.ComboTunnel).ItemsSource = (System.Collections.IEnumerable)val;
			((ItemsControl)_0024VB_0024Me.ComboTunnel).DisplayMemberPath = "DisplayText";
			if (val.Count > 0)
			{
				((Selector)_0024VB_0024Me.ComboTunnel).SelectedIndex = 0;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__59_002D0
	{
		public DataReceivedEventArgs _0024VB_0024Local_e;

		public PageLinkLobby _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			_0024VB_0024Me.Log($"[Frpc] {_0024VB_0024Local_e.Data}");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__59_002D1
	{
		public DataReceivedEventArgs _0024VB_0024Local_e;

		public PageLinkLobby _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			_0024VB_0024Me.Log($"[Frpc错误] {_0024VB_0024Local_e.Data}");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__61_002D0
	{
		public List<ProxyInfo> _0024VB_0024Local_proxies;

		public PageLinkLobby _0024VB_0024Me;

		public _Closure_0024__61_002D0(_Closure_0024__61_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_proxies = arg0._0024VB_0024Local_proxies;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			List<TunnelItem> val = new List<TunnelItem>();
			System.Collections.Generic.IEnumerator<ProxyInfo> enumerator = default(System.Collections.Generic.IEnumerator<ProxyInfo>);
			try
			{
				enumerator = _0024VB_0024Local_proxies.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ProxyInfo current = enumerator.Current;
					val.Add(new TunnelItem
					{
						Proxy = current,
						DisplayText = $"{current.ProxyName} - 端口 {current.RemotePort}"
					});
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			((ItemsControl)_0024VB_0024Me.ComboTunnel).ItemsSource = (System.Collections.IEnumerable)val;
			((ItemsControl)_0024VB_0024Me.ComboTunnel).DisplayMemberPath = "DisplayText";
			if (val.Count > 0)
			{
				((Selector)_0024VB_0024Me.ComboTunnel).SelectedIndex = 0;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__63_002D0
	{
		public DataReceivedEventArgs _0024VB_0024Local_e;

		public PageLinkLobby _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			_0024VB_0024Me.Log($"[Frpc] {_0024VB_0024Local_e.Data}");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__63_002D1
	{
		public DataReceivedEventArgs _0024VB_0024Local_e;

		public PageLinkLobby _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			_0024VB_0024Me.Log($"[Frpc错误] {_0024VB_0024Local_e.Data}");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__66_002D0
	{
		public List<ProxyInfo> _0024VB_0024Local_proxies;

		public PageLinkLobby _0024VB_0024Me;

		public _Closure_0024__66_002D0(_Closure_0024__66_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_proxies = arg0._0024VB_0024Local_proxies;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			List<TunnelItem> val = new List<TunnelItem>();
			System.Collections.Generic.IEnumerator<ProxyInfo> enumerator = default(System.Collections.Generic.IEnumerator<ProxyInfo>);
			try
			{
				enumerator = _0024VB_0024Local_proxies.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ProxyInfo current = enumerator.Current;
					val.Add(new TunnelItem
					{
						Proxy = current,
						DisplayText = $"{current.ProxyName} - 端口 {current.RemotePort}"
					});
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			((ItemsControl)_0024VB_0024Me.ComboTunnel).ItemsSource = (System.Collections.IEnumerable)val;
			((ItemsControl)_0024VB_0024Me.ComboTunnel).DisplayMemberPath = "DisplayText";
			if (val.Count > 0)
			{
				((Selector)_0024VB_0024Me.ComboTunnel).SelectedIndex = 0;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__68_002D0
	{
		public DataReceivedEventArgs _0024VB_0024Local_e;

		public PageLinkLobby _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			_0024VB_0024Me.Log($"[Frpc] {_0024VB_0024Local_e.Data}");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__68_002D1
	{
		public DataReceivedEventArgs _0024VB_0024Local_e;

		public PageLinkLobby _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			_0024VB_0024Me.Log($"[Frpc错误] {_0024VB_0024Local_e.Data}");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__69_002D0
	{
		public List<ProxyInfo> _0024VB_0024Local_proxies;

		public PageLinkLobby _0024VB_0024Me;

		public _Closure_0024__69_002D0(_Closure_0024__69_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_proxies = arg0._0024VB_0024Local_proxies;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			List<VB_0024AnonymousType_0<string, ProxyInfo>> val = Enumerable.ToList<VB_0024AnonymousType_0<string, ProxyInfo>>(Enumerable.Select<ProxyInfo, VB_0024AnonymousType_0<string, ProxyInfo>>((System.Collections.Generic.IEnumerable<ProxyInfo>)_0024VB_0024Local_proxies, (Func<ProxyInfo, VB_0024AnonymousType_0<string, ProxyInfo>>)([SpecialName] (ProxyInfo p) => new VB_0024AnonymousType_0<string, ProxyInfo>($"{p.FriendlyNode} - {p.ProxyName} ({p.RemotePort}) [测试中...]", p))));
			((ItemsControl)_0024VB_0024Me.ComboTunnel).ItemsSource = (System.Collections.IEnumerable)val;
			if (val.Count > 0)
			{
				((Selector)_0024VB_0024Me.ComboTunnel).SelectedIndex = 0;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__71_002D0
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine___Lambda_0024__1 : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncTaskMethodBuilder _0024Builder;

			internal _Closure_0024__71_002D0 _0024VB_0024NonLocal__Closure_0024__71_002D0;

			internal TaskAwaiter<int> _0024A0;

			internal ProxyInfo _0024U1;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
				//IL_0084: Unknown result type (might be due to invalid IL or missing references)
				//IL_0089: Unknown result type (might be due to invalid IL or missing references)
				//IL_009e: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				try
				{
					TaskAwaiter<int> awaiter;
					if (num == 0)
					{
						num = (_0024State = -1);
						awaiter = _0024A0;
						_0024A0 = default(TaskAwaiter<int>);
						goto IL_00d2;
					}
					if (!string.IsNullOrWhiteSpace(_0024VB_0024NonLocal__Closure_0024__71_002D0._0024VB_0024Local_proxy.ConnectAddress))
					{
						string[] array = _0024VB_0024NonLocal__Closure_0024__71_002D0._0024VB_0024Local_proxy.ConnectAddress.Split(':', (StringSplitOptions)0);
						if (array.Length == 2)
						{
							string host = array[0];
							int port = default(int);
							if (int.TryParse(array[1], out port))
							{
								_0024U1 = _0024VB_0024NonLocal__Closure_0024__71_002D0._0024VB_0024Local_proxy;
								awaiter = _0024VB_0024NonLocal__Closure_0024__71_002D0._0024VB_0024Me.TcpPingAsync(host, port, 3000).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<int>, VB_0024StateMachine___Lambda_0024__1>(ref awaiter, ref _this);
									return;
								}
								goto IL_00d2;
							}
						}
					}
					goto end_IL_0007;
					IL_00d2:
					ProxyInfo proxyInfo = _0024U1;
					int result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<int>);
					proxyInfo.Latency = result;
					_0024U1 = null;
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

		public ProxyInfo _0024VB_0024Local_proxy;

		public PageLinkLobby _0024VB_0024Me;

		public _Closure_0024__71_002D0(_Closure_0024__71_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_proxy = arg0._0024VB_0024Local_proxy;
			}
		}

		[SpecialName]
		[AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__1))]
		internal System.Threading.Tasks.Task _Lambda_0024__1()
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__1 vB_0024StateMachine___Lambda_0024__ = default(VB_0024StateMachine___Lambda_0024__1);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__71_002D0 = this;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<VB_0024StateMachine___Lambda_0024__1>(ref vB_0024StateMachine___Lambda_0024__);
			return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__71_002D1
	{
		public List<ProxyInfo> _0024VB_0024Local_proxies;

		public PageLinkLobby _0024VB_0024Me;

		public _Closure_0024__71_002D1(_Closure_0024__71_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_proxies = arg0._0024VB_0024Local_proxies;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			List<VB_0024AnonymousType_0<string, ProxyInfo>> val = Enumerable.ToList<VB_0024AnonymousType_0<string, ProxyInfo>>(Enumerable.Select<ProxyInfo, VB_0024AnonymousType_0<string, ProxyInfo>>((System.Collections.Generic.IEnumerable<ProxyInfo>)_0024VB_0024Local_proxies, (Func<ProxyInfo, VB_0024AnonymousType_0<string, ProxyInfo>>)([SpecialName] (ProxyInfo p) => new VB_0024AnonymousType_0<string, ProxyInfo>(string.Format("{0} - {1} ({2}) [{3}]", new object[4]
			{
				p.FriendlyNode,
				p.ProxyName,
				p.RemotePort,
				(p.Latency > 0) ? (Conversions.ToString(p.Latency) + "ms") : "超时"
			}), p))));
			((ItemsControl)_0024VB_0024Me.ComboTunnel).ItemsSource = (System.Collections.IEnumerable)val;
			if (val.Count > 0 && ((Selector)_0024VB_0024Me.ComboTunnel).SelectedIndex < 0)
			{
				((Selector)_0024VB_0024Me.ComboTunnel).SelectedIndex = 0;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__73_002D0
	{
		public DataReceivedEventArgs _0024VB_0024Local_e;

		public PageLinkLobby _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			_0024VB_0024Me.Log($"[Frpc] {_0024VB_0024Local_e.Data}");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__73_002D1
	{
		public DataReceivedEventArgs _0024VB_0024Local_e;

		public PageLinkLobby _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			_0024VB_0024Me.Log($"[Frpc错误] {_0024VB_0024Local_e.Data}");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__76_002D0
	{
		public DataReceivedEventArgs _0024VB_0024Local_e;

		public PageLinkLobby _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			_0024VB_0024Me.Log($"[Frpc] {_0024VB_0024Local_e.Data}");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__76_002D1
	{
		public DataReceivedEventArgs _0024VB_0024Local_e;

		public PageLinkLobby _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			_0024VB_0024Me.Log($"[Frpc错误] {_0024VB_0024Local_e.Data}");
		}
	}

	private bool _isRunning;

	private System.DateTime _startTime;

	private DispatcherTimer _timer;

	private BroadcastListener _broadcastListener;

	private ObservableCollection<string> _rooms;

	private string _username;

	private double _trafficGB;

	private string _friendlyGroup;

	private int _proxiesCount;

	private string _serverAddr;

	private int _serverPort;

	private System.DateTime _lastLatencyUpdate;

	private Process _frpcProcess;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	public LinkProviderDescriptor Provider
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanScroll")]
	internal new virtual MyScrollViewer PanScroll
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLogin")]
	internal virtual Grid PanLogin
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnLogin")]
	internal virtual MyButton BtnLogin
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnRegister")]
	internal virtual MyButton BtnRegister
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanMain")]
	internal virtual StackPanel PanMain
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabProviderName")]
	internal virtual TextBlock LabProviderName
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabUsername")]
	internal virtual TextBlock LabUsername
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabTraffic")]
	internal virtual TextBlock LabTraffic
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabGroup")]
	internal virtual TextBlock LabGroup
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabProxies")]
	internal virtual TextBlock LabProxies
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanConfig")]
	internal virtual StackPanel PanConfig
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ComboTunnel")]
	internal virtual MyComboBox ComboTunnel
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ComboRoom")]
	internal virtual MyComboBox ComboRoom
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnStart")]
	internal virtual MyButton BtnStart
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnCreateTunnel")]
	internal virtual MyButton BtnCreateTunnel
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanRunning")]
	internal virtual StackPanel PanRunning
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabRunningTime")]
	internal virtual TextBlock LabRunningTime
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabRunningLatency")]
	internal virtual TextBlock LabRunningLatency
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextAddress")]
	internal virtual MyTextBox TextAddress
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnCopy")]
	internal virtual MyButton BtnCopy
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnStop")]
	internal virtual MyButton BtnStop
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextLog")]
	internal virtual TextBox TextLog
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageLinkLobby()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageLinkLobby_Loaded);
		((FrameworkElement)this).Unloaded += new RoutedEventHandler(PageLinkLobby_Unloaded);
		Provider = LinkProviderRegistry.GetProvider(LinkProviderKind.OpenFrp);
		_isRunning = false;
		_rooms = new ObservableCollection<string>();
		_username = "";
		_trafficGB = 0.0;
		_friendlyGroup = "";
		_proxiesCount = 0;
		_serverAddr = "";
		_serverPort = 0;
		_lastLatencyUpdate = System.DateTime.MinValue;
		_frpcProcess = null;
		InitializeComponent();
	}

	private string PrepareWebView2UserDataFolder()
	{
		string text = Path.Combine(ModBase.PathAppdata, "PCL", "WebView2");
		Directory.CreateDirectory(text);
		return text;
	}

	private void SetWebView2UserDataFolder(WebView2 view)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		if (view != null)
		{
			try
			{
				view.CreationProperties = new CoreWebView2CreationProperties
				{
					UserDataFolder = PrepareWebView2UserDataFolder()
				};
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				Log($"配置 WebView2 数据目录失败: {ex2.Message}");
				ProjectData.ClearProjectError();
			}
		}
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_19_PageLinkLobby_Loaded))]
	private void PageLinkLobby_Loaded(object sender, RoutedEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_19_PageLinkLobby_Loaded vB_0024StateMachine_19_PageLinkLobby_Loaded = default(VB_0024StateMachine_19_PageLinkLobby_Loaded);
		vB_0024StateMachine_19_PageLinkLobby_Loaded._0024VB_0024Me = this;
		vB_0024StateMachine_19_PageLinkLobby_Loaded._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_19_PageLinkLobby_Loaded._0024VB_0024Local_e = e;
		vB_0024StateMachine_19_PageLinkLobby_Loaded._0024State = -1;
		vB_0024StateMachine_19_PageLinkLobby_Loaded._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_19_PageLinkLobby_Loaded._0024Builder.Start<VB_0024StateMachine_19_PageLinkLobby_Loaded>(ref vB_0024StateMachine_19_PageLinkLobby_Loaded);
	}

	private void PageLinkLobby_Unloaded(object sender, RoutedEventArgs e)
	{
		StopBroadcastListener();
		if (_timer != null)
		{
			_timer.Stop();
			_timer = null;
		}
	}

	public void Reload()
	{
		RefreshUi();
	}

	private void RefreshUi()
	{
		LinkProviderState state = LinkProviderRegistry.GetState(Provider.Kind);
		if (state.IsLoggedIn)
		{
			((UIElement)PanLogin).Visibility = (Visibility)2;
			((UIElement)PanMain).Visibility = (Visibility)0;
			LabProviderName.Text = Provider.Name;
			LabUsername.Text = (state.IsLoggedIn ? state.Username : "调试模式");
			((UIElement)PanConfig).Visibility = (Visibility)(_isRunning ? 2 : 0);
			((UIElement)PanRunning).Visibility = (Visibility)((!_isRunning) ? 2 : 0);
		}
		else
		{
			((UIElement)PanLogin).Visibility = (Visibility)0;
			((UIElement)PanMain).Visibility = (Visibility)2;
		}
	}

	private void UpdateUserInfoUI()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		((DispatcherObject)this).Dispatcher.Invoke((Action)([SpecialName] [CompilerGenerated] () =>
		{
			LabTraffic.Text = $"{_trafficGB:F2} GB";
			LabGroup.Text = _friendlyGroup;
			LabProxies.Text = $"{_proxiesCount} 个";
		}));
	}

	private void OnTimerTick(object sender, EventArgs e)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		if (!_isRunning)
		{
			return;
		}
		TimeSpan val = System.DateTime.Now - _startTime;
		LabRunningTime.Text = val.ToString("hh\\:mm\\:ss");
		TimeSpan val2 = System.DateTime.Now - _lastLatencyUpdate;
		if (val2.TotalSeconds >= 5.0)
		{
			_lastLatencyUpdate = System.DateTime.Now;
			System.Threading.Tasks.Task.Run((Func<System.Threading.Tasks.Task>)([SpecialName] [CompilerGenerated] [AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__24_002D0))] () =>
			{
				//IL_001a: Unknown result type (might be due to invalid IL or missing references)
				//IL_001f: Unknown result type (might be due to invalid IL or missing references)
				VB_0024StateMachine___Lambda_0024__24_002D0 vB_0024StateMachine___Lambda_0024__24_002D = default(VB_0024StateMachine___Lambda_0024__24_002D0);
				vB_0024StateMachine___Lambda_0024__24_002D._0024VB_0024Me = this;
				vB_0024StateMachine___Lambda_0024__24_002D._0024State = -1;
				vB_0024StateMachine___Lambda_0024__24_002D._0024Builder = AsyncTaskMethodBuilder.Create();
				vB_0024StateMachine___Lambda_0024__24_002D._0024Builder.Start<VB_0024StateMachine___Lambda_0024__24_002D0>(ref vB_0024StateMachine___Lambda_0024__24_002D);
				return vB_0024StateMachine___Lambda_0024__24_002D._0024Builder.Task;
			}));
		}
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_25_UpdateRunningLatency))]
	private System.Threading.Tasks.Task UpdateRunningLatency()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_25_UpdateRunningLatency vB_0024StateMachine_25_UpdateRunningLatency = default(VB_0024StateMachine_25_UpdateRunningLatency);
		vB_0024StateMachine_25_UpdateRunningLatency._0024VB_0024Me = this;
		vB_0024StateMachine_25_UpdateRunningLatency._0024State = -1;
		vB_0024StateMachine_25_UpdateRunningLatency._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_25_UpdateRunningLatency._0024Builder.Start<VB_0024StateMachine_25_UpdateRunningLatency>(ref vB_0024StateMachine_25_UpdateRunningLatency);
		return vB_0024StateMachine_25_UpdateRunningLatency._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_26_ClearMeFrpLocalStorageAsync))]
	private System.Threading.Tasks.Task ClearMeFrpLocalStorageAsync()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_26_ClearMeFrpLocalStorageAsync vB_0024StateMachine_26_ClearMeFrpLocalStorageAsync = default(VB_0024StateMachine_26_ClearMeFrpLocalStorageAsync);
		vB_0024StateMachine_26_ClearMeFrpLocalStorageAsync._0024VB_0024Me = this;
		vB_0024StateMachine_26_ClearMeFrpLocalStorageAsync._0024State = -1;
		vB_0024StateMachine_26_ClearMeFrpLocalStorageAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_26_ClearMeFrpLocalStorageAsync._0024Builder.Start<VB_0024StateMachine_26_ClearMeFrpLocalStorageAsync>(ref vB_0024StateMachine_26_ClearMeFrpLocalStorageAsync);
		return vB_0024StateMachine_26_ClearMeFrpLocalStorageAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_27_ClearNatfrpCookiesAsync))]
	private System.Threading.Tasks.Task ClearNatfrpCookiesAsync()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_27_ClearNatfrpCookiesAsync vB_0024StateMachine_27_ClearNatfrpCookiesAsync = default(VB_0024StateMachine_27_ClearNatfrpCookiesAsync);
		vB_0024StateMachine_27_ClearNatfrpCookiesAsync._0024VB_0024Me = this;
		vB_0024StateMachine_27_ClearNatfrpCookiesAsync._0024State = -1;
		vB_0024StateMachine_27_ClearNatfrpCookiesAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_27_ClearNatfrpCookiesAsync._0024Builder.Start<VB_0024StateMachine_27_ClearNatfrpCookiesAsync>(ref vB_0024StateMachine_27_ClearNatfrpCookiesAsync);
		return vB_0024StateMachine_27_ClearNatfrpCookiesAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_28_StartClick))]
	private void StartClick(object sender, MouseButtonEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_28_StartClick vB_0024StateMachine_28_StartClick = default(VB_0024StateMachine_28_StartClick);
		vB_0024StateMachine_28_StartClick._0024VB_0024Me = this;
		vB_0024StateMachine_28_StartClick._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_28_StartClick._0024VB_0024Local_e = e;
		vB_0024StateMachine_28_StartClick._0024State = -1;
		vB_0024StateMachine_28_StartClick._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_28_StartClick._0024Builder.Start<VB_0024StateMachine_28_StartClick>(ref vB_0024StateMachine_28_StartClick);
	}

	private void StopClick(object sender, MouseButtonEventArgs e)
	{
		_isRunning = false;
		if (_frpcProcess != null && !_frpcProcess.HasExited)
		{
			try
			{
				_frpcProcess.Kill();
				_frpcProcess.WaitForExit(3000);
				Log("Frpc 进程已停止");
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				Log($"停止 Frpc 进程失败：{ex2.Message}");
				ProjectData.ClearProjectError();
			}
		}
		Log("联机已停止。");
		RefreshUi();
	}

	private void CreateTunnelClick(object sender, MouseButtonEventArgs e)
	{
		ModBase.OpenWebsite(Provider.CreateTunnelUrl);
	}

	private void CopyAddressClick(object sender, MouseButtonEventArgs e)
	{
		ModBase.ClipboardSet(((TextBox)TextAddress).Text);
		ModMain.Hint("地址已复制到剪贴板！", ModMain.HintType.Finish);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_32_LogoutClick))]
	private void LogoutClick(object sender, EventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_32_LogoutClick vB_0024StateMachine_32_LogoutClick = default(VB_0024StateMachine_32_LogoutClick);
		vB_0024StateMachine_32_LogoutClick._0024VB_0024Me = this;
		vB_0024StateMachine_32_LogoutClick._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_32_LogoutClick._0024VB_0024Local_e = e;
		vB_0024StateMachine_32_LogoutClick._0024State = -1;
		vB_0024StateMachine_32_LogoutClick._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_32_LogoutClick._0024Builder.Start<VB_0024StateMachine_32_LogoutClick>(ref vB_0024StateMachine_32_LogoutClick);
	}

	private void LoginClick(object sender, MouseButtonEventArgs e)
	{
		Log($"打开登录窗口: Provider={Provider.Name}, LoginUrl={Provider.LoginUrl}, SuccessKeyword={Provider.SuccessKeyword}");
		MyAuthWindow myAuthWindow = new MyAuthWindow();
		((Window)myAuthWindow).Title = $"{Provider.Name} 登录";
		myAuthWindow.LoginUrl = (string.IsNullOrWhiteSpace(Provider.LoginUrl) ? Provider.DashboardUrl : Provider.LoginUrl);
		myAuthWindow.SuccessKeyword = Provider.SuccessKeyword;
		((Window)myAuthWindow).Owner = (Window)(object)ModMain.FrmMain;
		myAuthWindow.AuthCompleted += OnAuthCompleted;
		((Window)myAuthWindow).Show();
	}

	private void RegisterClick(object sender, MouseButtonEventArgs e)
	{
		ModBase.OpenWebsite(Provider.DashboardUrl);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_35_OnAuthCompleted))]
	private void OnAuthCompleted(object sender, AuthCompletedEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_35_OnAuthCompleted vB_0024StateMachine_35_OnAuthCompleted = default(VB_0024StateMachine_35_OnAuthCompleted);
		vB_0024StateMachine_35_OnAuthCompleted._0024VB_0024Me = this;
		vB_0024StateMachine_35_OnAuthCompleted._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_35_OnAuthCompleted._0024VB_0024Local_e = e;
		vB_0024StateMachine_35_OnAuthCompleted._0024State = -1;
		vB_0024StateMachine_35_OnAuthCompleted._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_35_OnAuthCompleted._0024Builder.Start<VB_0024StateMachine_35_OnAuthCompleted>(ref vB_0024StateMachine_35_OnAuthCompleted);
	}

	private string ExtractTokenFromCookiesSafe(string cookies)
	{
		if (string.IsNullOrWhiteSpace(cookies))
		{
			return "";
		}
		checked
		{
			try
			{
				string[] array = cookies.Replace("\r", "").Split(new string[] { "\n" }, (StringSplitOptions)1);
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					int num = text.IndexOf(';');
					if (num >= 0)
					{
						text = text.Substring(0, num);
					}
					int num2 = text.IndexOf('=');
					if (num2 > 0)
					{
						string text2 = text.Substring(0, num2).Trim();
						string result = text.Substring(num2 + 1);
						if (text2.Equals("authorization", (StringComparison)5) || text2.Equals("token", (StringComparison)5))
						{
							return result;
						}
					}
				}
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			return "";
		}
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_37_LoadTunnelsAsync))]
	private System.Threading.Tasks.Task LoadTunnelsAsync()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_37_LoadTunnelsAsync vB_0024StateMachine_37_LoadTunnelsAsync = default(VB_0024StateMachine_37_LoadTunnelsAsync);
		vB_0024StateMachine_37_LoadTunnelsAsync._0024VB_0024Me = this;
		vB_0024StateMachine_37_LoadTunnelsAsync._0024State = -1;
		vB_0024StateMachine_37_LoadTunnelsAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_37_LoadTunnelsAsync._0024Builder.Start<VB_0024StateMachine_37_LoadTunnelsAsync>(ref vB_0024StateMachine_37_LoadTunnelsAsync);
		return vB_0024StateMachine_37_LoadTunnelsAsync._0024Builder.Task;
	}

	private void StartBroadcastListener()
	{
		try
		{
			_broadcastListener = new BroadcastListener();
			_broadcastListener.OnReceive += OnBroadcastReceive;
			_broadcastListener.Start();
			((ItemsControl)ComboRoom).ItemsSource = (System.Collections.IEnumerable)_rooms;
			if (((Collection<string>)(object)_rooms).Count == 0)
			{
				ComboRoom.Text = "未发现房间，可手动输入端口号";
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			Log($"广播监听启动失败: {ex2.Message}");
			ComboRoom.Text = "监听失败，请手动输入端口号";
			ProjectData.ClearProjectError();
		}
	}

	private void StopBroadcastListener()
	{
		if (_broadcastListener != null)
		{
			_broadcastListener.Dispose();
			_broadcastListener = null;
		}
	}

	private void OnBroadcastReceive(BroadcastRecord record, IPEndPoint endpoint)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		((DispatcherObject)this).Dispatcher.Invoke((Action)([SpecialName] () =>
		{
			string text = $"{record.Desc} ({endpoint.Port})";
			if (!((Collection<string>)(object)_rooms).Contains(text))
			{
				((Collection<string>)(object)_rooms).Add(text);
				if (((Selector)ComboRoom).SelectedIndex < 0)
				{
					((Selector)ComboRoom).SelectedIndex = 0;
					ComboRoom.Text = text;
				}
				Log($"发现房间: {text}");
			}
		}));
	}

	private void RefreshRooms()
	{
		((Collection<string>)(object)_rooms).Clear();
		ComboRoom.Text = "正在搜索房间...";
		Log("手动刷新房间列表");
		System.Threading.Tasks.Task.Delay(2000).ContinueWith((Action<System.Threading.Tasks.Task>)([SpecialName] [CompilerGenerated] (System.Threading.Tasks.Task a0) =>
		{
			_Lambda_0024__41_002D0();
		}));
	}

	private void RefreshRoomsClick(object sender, EventArgs e)
	{
		RefreshRooms();
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_43_RefreshTunnelsClick))]
	private void RefreshTunnelsClick(object sender, EventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_43_RefreshTunnelsClick vB_0024StateMachine_43_RefreshTunnelsClick = default(VB_0024StateMachine_43_RefreshTunnelsClick);
		vB_0024StateMachine_43_RefreshTunnelsClick._0024VB_0024Me = this;
		vB_0024StateMachine_43_RefreshTunnelsClick._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_43_RefreshTunnelsClick._0024VB_0024Local_e = e;
		vB_0024StateMachine_43_RefreshTunnelsClick._0024State = -1;
		vB_0024StateMachine_43_RefreshTunnelsClick._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_43_RefreshTunnelsClick._0024Builder.Start<VB_0024StateMachine_43_RefreshTunnelsClick>(ref vB_0024StateMachine_43_RefreshTunnelsClick);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_44_RefreshUserInfoClick))]
	private void RefreshUserInfoClick(object sender, EventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_44_RefreshUserInfoClick vB_0024StateMachine_44_RefreshUserInfoClick = default(VB_0024StateMachine_44_RefreshUserInfoClick);
		vB_0024StateMachine_44_RefreshUserInfoClick._0024VB_0024Me = this;
		vB_0024StateMachine_44_RefreshUserInfoClick._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_44_RefreshUserInfoClick._0024VB_0024Local_e = e;
		vB_0024StateMachine_44_RefreshUserInfoClick._0024State = -1;
		vB_0024StateMachine_44_RefreshUserInfoClick._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_44_RefreshUserInfoClick._0024Builder.Start<VB_0024StateMachine_44_RefreshUserInfoClick>(ref vB_0024StateMachine_44_RefreshUserInfoClick);
	}

	private void Log(string text)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		ModBase.Log(text);
		((DispatcherObject)this).Dispatcher.Invoke((Action)([SpecialName] () =>
		{
			((TextBoxBase)TextLog).AppendText($"[{System.DateTime.Now:HH:mm:ss}] {text}{Environment.NewLine}");
			((TextBoxBase)TextLog).ScrollToEnd();
		}));
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_46_GetOpenFrpUserInfoAsync))]
	private System.Threading.Tasks.Task GetOpenFrpUserInfoAsync(string cookieText)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_46_GetOpenFrpUserInfoAsync vB_0024StateMachine_46_GetOpenFrpUserInfoAsync = default(VB_0024StateMachine_46_GetOpenFrpUserInfoAsync);
		vB_0024StateMachine_46_GetOpenFrpUserInfoAsync._0024VB_0024Me = this;
		vB_0024StateMachine_46_GetOpenFrpUserInfoAsync._0024VB_0024Local_cookieText = cookieText;
		vB_0024StateMachine_46_GetOpenFrpUserInfoAsync._0024State = -1;
		vB_0024StateMachine_46_GetOpenFrpUserInfoAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_46_GetOpenFrpUserInfoAsync._0024Builder.Start<VB_0024StateMachine_46_GetOpenFrpUserInfoAsync>(ref vB_0024StateMachine_46_GetOpenFrpUserInfoAsync);
		return vB_0024StateMachine_46_GetOpenFrpUserInfoAsync._0024Builder.Task;
	}

	private string FilterNatfrpCookies(string cookieText)
	{
		if (string.IsNullOrWhiteSpace(cookieText))
		{
			return "";
		}
		System.Collections.Generic.IEnumerable<string> enumerable = Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)cookieText.Split(new string[] { Environment.NewLine }, (StringSplitOptions)1), (Func<string, bool>)([SpecialName] (string l) =>
		{
			string text = l.ToLowerInvariant();
			return text.Contains("www.natfrp.com") || text.Contains("domain=.natfrp.com");
		}));
		return string.Join(Environment.NewLine, enumerable);
	}

	private string ConvertCookieTextToHeader(string cookieText)
	{
		if (string.IsNullOrWhiteSpace(cookieText))
		{
			return "";
		}
		string[] array = cookieText.Split(new string[] { Environment.NewLine }, (StringSplitOptions)1);
		List<string> val = new List<string>();
		string[] array2 = array;
		for (int i = 0; i < array2.Length; i = checked(i + 1))
		{
			string[] array3 = array2[i].Split(';', (StringSplitOptions)0);
			if (array3.Length > 0 && array3[0].Contains("="))
			{
				val.Add(array3[0].Trim());
			}
		}
		return string.Join("; ", (System.Collections.Generic.IEnumerable<string>)val);
	}

	private string GetCookieValue(string cookieText, string cookieName)
	{
		if (string.IsNullOrWhiteSpace(cookieText))
		{
			Log("GetCookieValue: Cookie文本为空");
			return "";
		}
		Log($"GetCookieValue: 查找 '{cookieName}'，Cookie行数：{cookieText.Split(new string[] { Environment.NewLine }, (StringSplitOptions)1).Length}");
		string[] array = cookieText.Split(new string[] { Environment.NewLine }, (StringSplitOptions)1);
		string[] array2 = array;
		foreach (string text in array2)
		{
			if (text.StartsWith(cookieName + "="))
			{
				string[] array3 = text.Split(';', (StringSplitOptions)0);
				if (array3.Length > 0)
				{
					string text2 = array3[0].Substring(checked(cookieName.Length + 1));
					Log($"GetCookieValue: 找到 '{cookieName}' = '{text2.Substring(0, Math.Min(20, text2.Length))}...'");
					return text2;
				}
			}
		}
		Log($"GetCookieValue: 未找到 '{cookieName}'");
		Log(string.Format("可用的Cookie: {0}", (object)string.Join(", ", Enumerable.Take<string>(Enumerable.Select<string, string>((System.Collections.Generic.IEnumerable<string>)array, (Func<string, string>)([SpecialName] (string l) => l.Split('=', (StringSplitOptions)0)[0])), 10))));
		return "";
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_50_GetMeFrpUserInfoAsync))]
	private System.Threading.Tasks.Task GetMeFrpUserInfoAsync(string cookieText, string token)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_50_GetMeFrpUserInfoAsync vB_0024StateMachine_50_GetMeFrpUserInfoAsync = default(VB_0024StateMachine_50_GetMeFrpUserInfoAsync);
		vB_0024StateMachine_50_GetMeFrpUserInfoAsync._0024VB_0024Me = this;
		vB_0024StateMachine_50_GetMeFrpUserInfoAsync._0024VB_0024Local_cookieText = cookieText;
		vB_0024StateMachine_50_GetMeFrpUserInfoAsync._0024VB_0024Local_token = token;
		vB_0024StateMachine_50_GetMeFrpUserInfoAsync._0024State = -1;
		vB_0024StateMachine_50_GetMeFrpUserInfoAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_50_GetMeFrpUserInfoAsync._0024Builder.Start<VB_0024StateMachine_50_GetMeFrpUserInfoAsync>(ref vB_0024StateMachine_50_GetMeFrpUserInfoAsync);
		return vB_0024StateMachine_50_GetMeFrpUserInfoAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_51_GetMeFrpProxiesAsync))]
	private System.Threading.Tasks.Task GetMeFrpProxiesAsync(string token)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_51_GetMeFrpProxiesAsync vB_0024StateMachine_51_GetMeFrpProxiesAsync = default(VB_0024StateMachine_51_GetMeFrpProxiesAsync);
		vB_0024StateMachine_51_GetMeFrpProxiesAsync._0024VB_0024Me = this;
		vB_0024StateMachine_51_GetMeFrpProxiesAsync._0024VB_0024Local_token = token;
		vB_0024StateMachine_51_GetMeFrpProxiesAsync._0024State = -1;
		vB_0024StateMachine_51_GetMeFrpProxiesAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_51_GetMeFrpProxiesAsync._0024Builder.Start<VB_0024StateMachine_51_GetMeFrpProxiesAsync>(ref vB_0024StateMachine_51_GetMeFrpProxiesAsync);
		return vB_0024StateMachine_51_GetMeFrpProxiesAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_52_GetMeFrpNodeNamesAsync))]
	private System.Threading.Tasks.Task GetMeFrpNodeNamesAsync(string token, List<ProxyInfo> proxies)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_52_GetMeFrpNodeNamesAsync vB_0024StateMachine_52_GetMeFrpNodeNamesAsync = default(VB_0024StateMachine_52_GetMeFrpNodeNamesAsync);
		vB_0024StateMachine_52_GetMeFrpNodeNamesAsync._0024VB_0024Me = this;
		vB_0024StateMachine_52_GetMeFrpNodeNamesAsync._0024VB_0024Local_token = token;
		vB_0024StateMachine_52_GetMeFrpNodeNamesAsync._0024VB_0024Local_proxies = proxies;
		vB_0024StateMachine_52_GetMeFrpNodeNamesAsync._0024State = -1;
		vB_0024StateMachine_52_GetMeFrpNodeNamesAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_52_GetMeFrpNodeNamesAsync._0024Builder.Start<VB_0024StateMachine_52_GetMeFrpNodeNamesAsync>(ref vB_0024StateMachine_52_GetMeFrpNodeNamesAsync);
		return vB_0024StateMachine_52_GetMeFrpNodeNamesAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync))]
	private System.Threading.Tasks.Task TestMeFrpProxiesLatencyAsync(List<ProxyInfo> proxies)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync vB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync = default(VB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync);
		vB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync._0024VB_0024Me = this;
		vB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync._0024VB_0024Local_proxies = proxies;
		vB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync._0024State = -1;
		vB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync._0024Builder.Start<VB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync>(ref vB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync);
		return vB_0024StateMachine_53_TestMeFrpProxiesLatencyAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_54_ClearXhfrpLocalStorageAsync))]
	private System.Threading.Tasks.Task ClearXhfrpLocalStorageAsync()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_54_ClearXhfrpLocalStorageAsync vB_0024StateMachine_54_ClearXhfrpLocalStorageAsync = default(VB_0024StateMachine_54_ClearXhfrpLocalStorageAsync);
		vB_0024StateMachine_54_ClearXhfrpLocalStorageAsync._0024VB_0024Me = this;
		vB_0024StateMachine_54_ClearXhfrpLocalStorageAsync._0024State = -1;
		vB_0024StateMachine_54_ClearXhfrpLocalStorageAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_54_ClearXhfrpLocalStorageAsync._0024Builder.Start<VB_0024StateMachine_54_ClearXhfrpLocalStorageAsync>(ref vB_0024StateMachine_54_ClearXhfrpLocalStorageAsync);
		return vB_0024StateMachine_54_ClearXhfrpLocalStorageAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync))]
	private System.Threading.Tasks.Task ClearStellarfrpLocalStorageAsync()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync vB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync = default(VB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync);
		vB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync._0024VB_0024Me = this;
		vB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync._0024State = -1;
		vB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync._0024Builder.Start<VB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync>(ref vB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync);
		return vB_0024StateMachine_55_ClearStellarfrpLocalStorageAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_56_GetStellarfrpUserInfoAsync))]
	private System.Threading.Tasks.Task GetStellarfrpUserInfoAsync(string token)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_56_GetStellarfrpUserInfoAsync vB_0024StateMachine_56_GetStellarfrpUserInfoAsync = default(VB_0024StateMachine_56_GetStellarfrpUserInfoAsync);
		vB_0024StateMachine_56_GetStellarfrpUserInfoAsync._0024VB_0024Me = this;
		vB_0024StateMachine_56_GetStellarfrpUserInfoAsync._0024VB_0024Local_token = token;
		vB_0024StateMachine_56_GetStellarfrpUserInfoAsync._0024State = -1;
		vB_0024StateMachine_56_GetStellarfrpUserInfoAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_56_GetStellarfrpUserInfoAsync._0024Builder.Start<VB_0024StateMachine_56_GetStellarfrpUserInfoAsync>(ref vB_0024StateMachine_56_GetStellarfrpUserInfoAsync);
		return vB_0024StateMachine_56_GetStellarfrpUserInfoAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_57_GetStellarfrpProxiesAsync))]
	private System.Threading.Tasks.Task GetStellarfrpProxiesAsync(string token)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_57_GetStellarfrpProxiesAsync vB_0024StateMachine_57_GetStellarfrpProxiesAsync = default(VB_0024StateMachine_57_GetStellarfrpProxiesAsync);
		vB_0024StateMachine_57_GetStellarfrpProxiesAsync._0024VB_0024Me = this;
		vB_0024StateMachine_57_GetStellarfrpProxiesAsync._0024VB_0024Local_token = token;
		vB_0024StateMachine_57_GetStellarfrpProxiesAsync._0024State = -1;
		vB_0024StateMachine_57_GetStellarfrpProxiesAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_57_GetStellarfrpProxiesAsync._0024Builder.Start<VB_0024StateMachine_57_GetStellarfrpProxiesAsync>(ref vB_0024StateMachine_57_GetStellarfrpProxiesAsync);
		return vB_0024StateMachine_57_GetStellarfrpProxiesAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_58_GetStellarfrpProxyConfigAsync))]
	private async System.Threading.Tasks.Task<string> GetStellarfrpProxyConfigAsync(int proxyId, string token)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			HttpClientHandler val = new HttpClientHandler
			{
				UseCookies = false
			};
			try
			{
				HttpClient val2 = new HttpClient((HttpMessageHandler)(object)val);
				try
				{
					val2.Timeout = TimeSpan.FromSeconds(10.0);
					((HttpHeaders)val2.DefaultRequestHeaders).Add("authorization", token);
					string text = "https://api.stellarfrp.top/api/v1/proxy/get?page=1&page_size=100";
					HttpResponseMessage val3 = await val2.GetAsync(text);
					Log($"请求 {text} 返回：{val3.StatusCode}");
					if (val3.IsSuccessStatusCode)
					{
						JToken jToken = JObject.Parse(await val3.Content.ReadAsStringAsync())["tunnel"];
						if (!object.ReferenceEquals((object)jToken, (object)null))
						{
							System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
							try
							{
								enumerator = ((System.Collections.Generic.IEnumerable<JToken>)jToken).GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator).MoveNext())
								{
									JProperty jProperty = (JProperty)enumerator.Current;
									try
									{
										string name = jProperty.Name;
										JObject jObject = (JObject)jProperty.Value;
										if ((jObject["Id"]?.Value<int>() ?? int.Parse(name)) == proxyId)
										{
											return jObject["data"]?.ToString() ?? "";
										}
									}
									catch (System.Exception projectError)
									{
										ProjectData.SetProjectError(projectError);
										ProjectData.ClearProjectError();
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator)?.Dispose();
							}
						}
					}
					else
					{
						Log($"获取 隧道配置失败：{val3.StatusCode}");
					}
				}
				finally
				{
					((System.IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			Log($"获取 Stellarfrp 配置失败：{ex2.Message}");
			ProjectData.ClearProjectError();
		}
		return "";
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_59_StartStellarfrpcTunnel))]
	private System.Threading.Tasks.Task StartStellarfrpcTunnel(ProxyInfo proxy, int localPort, string token)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_59_StartStellarfrpcTunnel vB_0024StateMachine_59_StartStellarfrpcTunnel = default(VB_0024StateMachine_59_StartStellarfrpcTunnel);
		vB_0024StateMachine_59_StartStellarfrpcTunnel._0024VB_0024Me = this;
		vB_0024StateMachine_59_StartStellarfrpcTunnel._0024VB_0024Local_proxy = proxy;
		vB_0024StateMachine_59_StartStellarfrpcTunnel._0024VB_0024Local_localPort = localPort;
		vB_0024StateMachine_59_StartStellarfrpcTunnel._0024VB_0024Local_token = token;
		vB_0024StateMachine_59_StartStellarfrpcTunnel._0024State = -1;
		vB_0024StateMachine_59_StartStellarfrpcTunnel._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_59_StartStellarfrpcTunnel._0024Builder.Start<VB_0024StateMachine_59_StartStellarfrpcTunnel>(ref vB_0024StateMachine_59_StartStellarfrpcTunnel);
		return vB_0024StateMachine_59_StartStellarfrpcTunnel._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_60_GetXhfrpUserInfoAsync))]
	private System.Threading.Tasks.Task GetXhfrpUserInfoAsync(string token)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_60_GetXhfrpUserInfoAsync vB_0024StateMachine_60_GetXhfrpUserInfoAsync = default(VB_0024StateMachine_60_GetXhfrpUserInfoAsync);
		vB_0024StateMachine_60_GetXhfrpUserInfoAsync._0024VB_0024Me = this;
		vB_0024StateMachine_60_GetXhfrpUserInfoAsync._0024VB_0024Local_token = token;
		vB_0024StateMachine_60_GetXhfrpUserInfoAsync._0024State = -1;
		vB_0024StateMachine_60_GetXhfrpUserInfoAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_60_GetXhfrpUserInfoAsync._0024Builder.Start<VB_0024StateMachine_60_GetXhfrpUserInfoAsync>(ref vB_0024StateMachine_60_GetXhfrpUserInfoAsync);
		return vB_0024StateMachine_60_GetXhfrpUserInfoAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_61_GetXhfrpProxiesAsync))]
	private System.Threading.Tasks.Task GetXhfrpProxiesAsync(string token)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_61_GetXhfrpProxiesAsync vB_0024StateMachine_61_GetXhfrpProxiesAsync = default(VB_0024StateMachine_61_GetXhfrpProxiesAsync);
		vB_0024StateMachine_61_GetXhfrpProxiesAsync._0024VB_0024Me = this;
		vB_0024StateMachine_61_GetXhfrpProxiesAsync._0024VB_0024Local_token = token;
		vB_0024StateMachine_61_GetXhfrpProxiesAsync._0024State = -1;
		vB_0024StateMachine_61_GetXhfrpProxiesAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_61_GetXhfrpProxiesAsync._0024Builder.Start<VB_0024StateMachine_61_GetXhfrpProxiesAsync>(ref vB_0024StateMachine_61_GetXhfrpProxiesAsync);
		return vB_0024StateMachine_61_GetXhfrpProxiesAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_62_GetXhfrpProxyConfigAsync))]
	private async System.Threading.Tasks.Task<string> GetXhfrpProxyConfigAsync(int proxyId, string token)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			HttpClientHandler val = new HttpClientHandler
			{
				UseCookies = false
			};
			try
			{
				HttpClient val2 = new HttpClient((HttpMessageHandler)(object)val);
				try
				{
					val2.Timeout = TimeSpan.FromSeconds(10.0);
					((HttpHeaders)val2.DefaultRequestHeaders).Add("authorization", token);
					string text = "https://console.frp.api.xhuzim.top/api/v1/proxy/get?page=1&page_size=100";
					HttpResponseMessage val3 = await val2.GetAsync(text);
					Log($"请求 {text} 返回：{val3.StatusCode}");
					if (val3.IsSuccessStatusCode)
					{
						JToken jToken = JObject.Parse(await val3.Content.ReadAsStringAsync())["tunnel"];
						if (!object.ReferenceEquals((object)jToken, (object)null))
						{
							System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
							try
							{
								enumerator = ((System.Collections.Generic.IEnumerable<JToken>)jToken).GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator).MoveNext())
								{
									JProperty jProperty = (JProperty)enumerator.Current;
									try
									{
										string name = jProperty.Name;
										JObject jObject = (JObject)jProperty.Value;
										if ((jObject["Id"]?.Value<int>() ?? int.Parse(name)) == proxyId)
										{
											return jObject["data"]?.ToString() ?? "";
										}
									}
									catch (System.Exception projectError)
									{
										ProjectData.SetProjectError(projectError);
										ProjectData.ClearProjectError();
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator)?.Dispose();
							}
						}
					}
					else
					{
						Log($"获取 隧道配置失败：{val3.StatusCode}");
					}
				}
				finally
				{
					((System.IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			Log($"获取 星穿月联 配置失败：{ex2.Message}");
			ProjectData.ClearProjectError();
		}
		return "";
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_63_StartXhfrpcTunnel))]
	private System.Threading.Tasks.Task StartXhfrpcTunnel(ProxyInfo proxy, int localPort, string token)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_63_StartXhfrpcTunnel vB_0024StateMachine_63_StartXhfrpcTunnel = default(VB_0024StateMachine_63_StartXhfrpcTunnel);
		vB_0024StateMachine_63_StartXhfrpcTunnel._0024VB_0024Me = this;
		vB_0024StateMachine_63_StartXhfrpcTunnel._0024VB_0024Local_proxy = proxy;
		vB_0024StateMachine_63_StartXhfrpcTunnel._0024VB_0024Local_localPort = localPort;
		vB_0024StateMachine_63_StartXhfrpcTunnel._0024VB_0024Local_token = token;
		vB_0024StateMachine_63_StartXhfrpcTunnel._0024State = -1;
		vB_0024StateMachine_63_StartXhfrpcTunnel._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_63_StartXhfrpcTunnel._0024Builder.Start<VB_0024StateMachine_63_StartXhfrpcTunnel>(ref vB_0024StateMachine_63_StartXhfrpcTunnel);
		return vB_0024StateMachine_63_StartXhfrpcTunnel._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_64_GetNatfrpUserInfoAsync))]
	private System.Threading.Tasks.Task GetNatfrpUserInfoAsync(string cookieText)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_64_GetNatfrpUserInfoAsync vB_0024StateMachine_64_GetNatfrpUserInfoAsync = default(VB_0024StateMachine_64_GetNatfrpUserInfoAsync);
		vB_0024StateMachine_64_GetNatfrpUserInfoAsync._0024VB_0024Me = this;
		vB_0024StateMachine_64_GetNatfrpUserInfoAsync._0024VB_0024Local_cookieText = cookieText;
		vB_0024StateMachine_64_GetNatfrpUserInfoAsync._0024State = -1;
		vB_0024StateMachine_64_GetNatfrpUserInfoAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_64_GetNatfrpUserInfoAsync._0024Builder.Start<VB_0024StateMachine_64_GetNatfrpUserInfoAsync>(ref vB_0024StateMachine_64_GetNatfrpUserInfoAsync);
		return vB_0024StateMachine_64_GetNatfrpUserInfoAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_65_GetNatfrpUserInfoByToken))]
	private System.Threading.Tasks.Task GetNatfrpUserInfoByToken(string token)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_65_GetNatfrpUserInfoByToken vB_0024StateMachine_65_GetNatfrpUserInfoByToken = default(VB_0024StateMachine_65_GetNatfrpUserInfoByToken);
		vB_0024StateMachine_65_GetNatfrpUserInfoByToken._0024VB_0024Me = this;
		vB_0024StateMachine_65_GetNatfrpUserInfoByToken._0024VB_0024Local_token = token;
		vB_0024StateMachine_65_GetNatfrpUserInfoByToken._0024State = -1;
		vB_0024StateMachine_65_GetNatfrpUserInfoByToken._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_65_GetNatfrpUserInfoByToken._0024Builder.Start<VB_0024StateMachine_65_GetNatfrpUserInfoByToken>(ref vB_0024StateMachine_65_GetNatfrpUserInfoByToken);
		return vB_0024StateMachine_65_GetNatfrpUserInfoByToken._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_66_GetNatfrpTunnelsAsync))]
	private System.Threading.Tasks.Task GetNatfrpTunnelsAsync(string token)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_66_GetNatfrpTunnelsAsync vB_0024StateMachine_66_GetNatfrpTunnelsAsync = default(VB_0024StateMachine_66_GetNatfrpTunnelsAsync);
		vB_0024StateMachine_66_GetNatfrpTunnelsAsync._0024VB_0024Me = this;
		vB_0024StateMachine_66_GetNatfrpTunnelsAsync._0024VB_0024Local_token = token;
		vB_0024StateMachine_66_GetNatfrpTunnelsAsync._0024State = -1;
		vB_0024StateMachine_66_GetNatfrpTunnelsAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_66_GetNatfrpTunnelsAsync._0024Builder.Start<VB_0024StateMachine_66_GetNatfrpTunnelsAsync>(ref vB_0024StateMachine_66_GetNatfrpTunnelsAsync);
		return vB_0024StateMachine_66_GetNatfrpTunnelsAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_67_GetNatfrpProxyConfigAsync))]
	private async System.Threading.Tasks.Task<string> GetNatfrpProxyConfigAsync(int proxyId, string token)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			HttpClientHandler val = new HttpClientHandler
			{
				UseCookies = false
			};
			try
			{
				HttpClient val2 = new HttpClient((HttpMessageHandler)(object)val);
				try
				{
					val2.Timeout = TimeSpan.FromSeconds(10.0);
					string text = $"https://api.natfrp.com/v4/tunnel/config?token={Uri.EscapeDataString(token)}";
					Dictionary<string, string> obj = new Dictionary<string, string>();
					obj.Add("query", proxyId.ToString());
					obj.Add("frpc", "0.59.0");
					FormUrlEncodedContent val3 = new FormUrlEncodedContent((System.Collections.Generic.IEnumerable<KeyValuePair<string, string>>)obj);
					HttpResponseMessage val4 = await val2.PostAsync(text, (HttpContent)(object)val3);
					Log($"Natfrp 配置响应：{val4.StatusCode}");
					if (val4.IsSuccessStatusCode)
					{
						string text2 = await val4.Content.ReadAsStringAsync();
						if (!string.IsNullOrWhiteSpace(text2))
						{
							Log("Natfrp 配置获取成功（已保留原样）");
							return text2;
						}
						Log("Natfrp 配置为空");
					}
					else
					{
						Log("Natfrp 配置请求失败");
					}
				}
				finally
				{
					((System.IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			Log($"获取 Natfrp 配置出错：{ex2.Message}");
			ProjectData.ClearProjectError();
		}
		return "";
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_68_StartNatfrpcTunnel))]
	private System.Threading.Tasks.Task StartNatfrpcTunnel(ProxyInfo proxy, int localPort, string token)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_68_StartNatfrpcTunnel vB_0024StateMachine_68_StartNatfrpcTunnel = default(VB_0024StateMachine_68_StartNatfrpcTunnel);
		vB_0024StateMachine_68_StartNatfrpcTunnel._0024VB_0024Me = this;
		vB_0024StateMachine_68_StartNatfrpcTunnel._0024VB_0024Local_proxy = proxy;
		vB_0024StateMachine_68_StartNatfrpcTunnel._0024VB_0024Local_localPort = localPort;
		vB_0024StateMachine_68_StartNatfrpcTunnel._0024VB_0024Local_token = token;
		vB_0024StateMachine_68_StartNatfrpcTunnel._0024State = -1;
		vB_0024StateMachine_68_StartNatfrpcTunnel._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_68_StartNatfrpcTunnel._0024Builder.Start<VB_0024StateMachine_68_StartNatfrpcTunnel>(ref vB_0024StateMachine_68_StartNatfrpcTunnel);
		return vB_0024StateMachine_68_StartNatfrpcTunnel._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_69_GetUserProxiesAsync))]
	private System.Threading.Tasks.Task GetUserProxiesAsync(string cookieHeader, string authorization)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_69_GetUserProxiesAsync vB_0024StateMachine_69_GetUserProxiesAsync = default(VB_0024StateMachine_69_GetUserProxiesAsync);
		vB_0024StateMachine_69_GetUserProxiesAsync._0024VB_0024Me = this;
		vB_0024StateMachine_69_GetUserProxiesAsync._0024VB_0024Local_cookieHeader = cookieHeader;
		vB_0024StateMachine_69_GetUserProxiesAsync._0024VB_0024Local_authorization = authorization;
		vB_0024StateMachine_69_GetUserProxiesAsync._0024State = -1;
		vB_0024StateMachine_69_GetUserProxiesAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_69_GetUserProxiesAsync._0024Builder.Start<VB_0024StateMachine_69_GetUserProxiesAsync>(ref vB_0024StateMachine_69_GetUserProxiesAsync);
		return vB_0024StateMachine_69_GetUserProxiesAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_70_TcpPingAsync))]
	private async System.Threading.Tasks.Task<int> TcpPingAsync(string host, int port, int timeout)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			TcpClient val = new TcpClient();
			Stopwatch val2 = Stopwatch.StartNew();
			System.Threading.Tasks.Task task = val.ConnectAsync(host, port);
			System.Threading.Tasks.Task task2 = System.Threading.Tasks.Task.Delay(timeout);
			System.Threading.Tasks.Task obj = await System.Threading.Tasks.Task.WhenAny(task, task2);
			val2.Stop();
			if (obj == task && !task.IsFaulted)
			{
				val.Close();
				return checked((int)val2.ElapsedMilliseconds);
			}
			val.Close();
			return -1;
		}
		catch (System.Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			int result = -1;
			ProjectData.ClearProjectError();
			return result;
		}
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_71_TestProxiesLatencyAsync))]
	private System.Threading.Tasks.Task TestProxiesLatencyAsync(List<ProxyInfo> proxies)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_71_TestProxiesLatencyAsync vB_0024StateMachine_71_TestProxiesLatencyAsync = default(VB_0024StateMachine_71_TestProxiesLatencyAsync);
		vB_0024StateMachine_71_TestProxiesLatencyAsync._0024VB_0024Me = this;
		vB_0024StateMachine_71_TestProxiesLatencyAsync._0024VB_0024Local_proxies = proxies;
		vB_0024StateMachine_71_TestProxiesLatencyAsync._0024State = -1;
		vB_0024StateMachine_71_TestProxiesLatencyAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_71_TestProxiesLatencyAsync._0024Builder.Start<VB_0024StateMachine_71_TestProxiesLatencyAsync>(ref vB_0024StateMachine_71_TestProxiesLatencyAsync);
		return vB_0024StateMachine_71_TestProxiesLatencyAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_73_StartFrpcTunnel))]
	private System.Threading.Tasks.Task StartFrpcTunnel(ProxyInfo proxy, int localPort, string cookieHeader, string authorization)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_73_StartFrpcTunnel vB_0024StateMachine_73_StartFrpcTunnel = default(VB_0024StateMachine_73_StartFrpcTunnel);
		vB_0024StateMachine_73_StartFrpcTunnel._0024VB_0024Me = this;
		vB_0024StateMachine_73_StartFrpcTunnel._0024VB_0024Local_proxy = proxy;
		vB_0024StateMachine_73_StartFrpcTunnel._0024VB_0024Local_localPort = localPort;
		vB_0024StateMachine_73_StartFrpcTunnel._0024VB_0024Local_cookieHeader = cookieHeader;
		vB_0024StateMachine_73_StartFrpcTunnel._0024VB_0024Local_authorization = authorization;
		vB_0024StateMachine_73_StartFrpcTunnel._0024State = -1;
		vB_0024StateMachine_73_StartFrpcTunnel._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_73_StartFrpcTunnel._0024Builder.Start<VB_0024StateMachine_73_StartFrpcTunnel>(ref vB_0024StateMachine_73_StartFrpcTunnel);
		return vB_0024StateMachine_73_StartFrpcTunnel._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_74_GetNodeConfAsync))]
	private async System.Threading.Tasks.Task<string> GetNodeConfAsync(int nid, string cookieHeader, string authorization)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Log($"正在获取节点 {nid} 的配置...");
			HttpClient val = new HttpClient();
			try
			{
				val.Timeout = TimeSpan.FromSeconds(10.0);
				((HttpHeaders)val.DefaultRequestHeaders).Add("Cookie", cookieHeader);
				if (!string.IsNullOrWhiteSpace(authorization))
				{
					((HttpHeaders)val.DefaultRequestHeaders).Add("authorization", authorization);
				}
				string text = $"{{\"node_id\":{nid}}}";
				StringContent val2 = new StringContent(text, Encoding.UTF8, "application/json");
				HttpResponseMessage val3 = await val.PostAsync("https://console.openfrp.net/web/frp/api/getNodeConf", (HttpContent)(object)val2);
				if (val3.IsSuccessStatusCode)
				{
					JObject jObject = JObject.Parse(await val3.Content.ReadAsStringAsync());
					if (jObject["flag"]?.Value<bool>() ?? false)
					{
						string result = jObject["data"]?.ToString();
						Log("节点配置获取成功");
						return result;
					}
					Log(string.Format("获取节点配置失败：{0}", (object)jObject["msg"]));
				}
				else
				{
					Log($"请求节点配置失败：{val3.StatusCode}");
				}
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			Log($"获取节点配置出错：{ex2.Message}");
			ProjectData.ClearProjectError();
		}
		return "";
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_75_GetMeFrpProxyConfigAsync))]
	private async System.Threading.Tasks.Task<string> GetMeFrpProxyConfigAsync(int proxyId, string token)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Log($"正在获取 MeFrp 隧道 {proxyId} 的配置...");
			HttpClientHandler val = new HttpClientHandler
			{
				UseCookies = false
			};
			try
			{
				HttpClient val2 = new HttpClient((HttpMessageHandler)(object)val);
				try
				{
					val2.Timeout = TimeSpan.FromSeconds(10.0);
					((HttpHeaders)val2.DefaultRequestHeaders).Add("Authorization", $"Bearer {token}");
					string text = $"{{\"proxyId\":{proxyId},\"format\":\"toml\"}}";
					StringContent val3 = new StringContent(text, Encoding.UTF8, "application/json");
					HttpResponseMessage val4 = await val2.PostAsync("https://api.mefrp.com/api/auth/proxy/config", (HttpContent)(object)val3);
					if (val4.IsSuccessStatusCode)
					{
						JObject jObject = JObject.Parse(await val4.Content.ReadAsStringAsync());
						JToken? jToken = jObject["code"];
						if (jToken != null && jToken.Value<int>() == 200)
						{
							JToken jToken2 = jObject["data"];
							string result = jToken2["config"]?.ToString();
							Log("MeFrp 配置获取成功");
							return result;
						}
						Log(string.Format("获取 MeFrp 配置失败：{0}", (object)jObject["message"]));
					}
					else
					{
						Log($"请求 MeFrp 配置失败：{val4.StatusCode}");
					}
				}
				finally
				{
					((System.IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			Log($"获取 MeFrp 配置出错：{ex2.Message}");
			ProjectData.ClearProjectError();
		}
		return "";
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_76_StartMeFrpcTunnel))]
	private System.Threading.Tasks.Task StartMeFrpcTunnel(ProxyInfo proxy, int localPort, string token)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_76_StartMeFrpcTunnel vB_0024StateMachine_76_StartMeFrpcTunnel = default(VB_0024StateMachine_76_StartMeFrpcTunnel);
		vB_0024StateMachine_76_StartMeFrpcTunnel._0024VB_0024Me = this;
		vB_0024StateMachine_76_StartMeFrpcTunnel._0024VB_0024Local_proxy = proxy;
		vB_0024StateMachine_76_StartMeFrpcTunnel._0024VB_0024Local_localPort = localPort;
		vB_0024StateMachine_76_StartMeFrpcTunnel._0024VB_0024Local_token = token;
		vB_0024StateMachine_76_StartMeFrpcTunnel._0024State = -1;
		vB_0024StateMachine_76_StartMeFrpcTunnel._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_76_StartMeFrpcTunnel._0024Builder.Start<VB_0024StateMachine_76_StartMeFrpcTunnel>(ref vB_0024StateMachine_76_StartMeFrpcTunnel);
		return vB_0024StateMachine_76_StartMeFrpcTunnel._0024Builder.Task;
	}

	private string ModifyTomlConfig(string tomlText, string proxyName, int localPort)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		string result;
		try
		{
			string[] array = tomlText.Split(new string[] { "\n", "\r\n" }, (StringSplitOptions)0);
			StringBuilder val = new StringBuilder();
			bool flag = false;
			string[] array2 = array;
			foreach (string text in array2)
			{
				string text2 = text.Trim();
				if (text2.StartsWith("[[proxies]]"))
				{
					flag = true;
				}
				else if (flag)
				{
					if (text2.StartsWith("[["))
					{
						flag = false;
						val.AppendLine(text);
					}
					else if (text2.StartsWith("name = "))
					{
						Match val2 = Regex.Match(text2, "name\\s*=\\s*['\"]([^'\"]*)['\"]");
						if (((Group)val2).Success && Operators.CompareString(((Capture)val2.Groups[1]).Value, proxyName, false) != 0)
						{
						}
					}
				}
				else
				{
					val.AppendLine(text);
				}
			}
			List<string> val3 = new List<string>();
			flag = false;
			bool flag2 = false;
			string[] array3 = array;
			foreach (string text3 in array3)
			{
				string text4 = text3.Trim();
				if (text4.StartsWith("[[proxies]]"))
				{
					flag = true;
					flag2 = false;
				}
				else
				{
					if (!flag)
					{
						continue;
					}
					if (text4.StartsWith("[["))
					{
						flag = false;
					}
					else if (text4.StartsWith("name = "))
					{
						Match val4 = Regex.Match(text4, "name\\s*=\\s*['\"]([^'\"]*)['\"]");
						if (((Group)val4).Success && Operators.CompareString(((Capture)val4.Groups[1]).Value, proxyName, false) == 0)
						{
							flag2 = true;
							val3.Add(text3);
						}
					}
					else
					{
						if (!flag2)
						{
							continue;
						}
						if (text4.Contains("=") && !text4.StartsWith("#"))
						{
							int num = text4.IndexOf("=");
							string text5 = text4.Substring(0, num).Trim();
							if (Operators.CompareString(text5, "autoTLS", false) == 0)
							{
								Log("已过滤 autoTLS 配置项");
								continue;
							}
							if (Operators.CompareString(text5, "localPort", false) == 0)
							{
								val3.Add($"localPort = {localPort}");
								continue;
							}
						}
						val3.Add(text3);
					}
				}
			}
			if (val3.Count == 0)
			{
				Log($"未找到名为 {proxyName} 的proxy配置");
				result = "";
			}
			else
			{
				val.AppendLine();
				val.AppendLine("[[proxies]]");
				System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
				try
				{
					enumerator = val3.GetEnumerator();
					while (enumerator.MoveNext())
					{
						string current = enumerator.Current;
						val.AppendLine(current);
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				result = val.ToString();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			Log($"修改TOML配置失败：{ex2.Message}");
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void ExtractServerInfo(string tomlText)
	{
		try
		{
			string[] array = tomlText.Split(new string[] { "\n", "\r\n" }, (StringSplitOptions)1);
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				string text = array[i].Trim();
				Match val = Regex.Match(text, "serverAddr\\s*=\\s*['\"]?([^'\"\\s]+)['\"]?");
				if (((Group)val).Success)
				{
					_serverAddr = ((Capture)val.Groups[1]).Value;
					Log($"提取到 serverAddr: {_serverAddr}");
					continue;
				}
				Match val2 = Regex.Match(text, "serverPort\\s*=\\s*(\\d+)");
				if (((Group)val2).Success && int.TryParse(((Capture)val2.Groups[1]).Value, out _serverPort))
				{
					Log($"提取到 serverPort: {_serverPort}");
				}
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			Log($"提取服务器信息失败: {ex2.Message}");
			ProjectData.ClearProjectError();
		}
	}

	private void CleanupOldConfigFiles(string configDir, int keepCount)
	{
		checked
		{
			try
			{
				if (!Directory.Exists(configDir))
				{
					return;
				}
				string[] files = Directory.GetFiles(configDir, "*.toml");
				if (files.Length <= keepCount)
				{
					Log($"配置文件数量: {files.Length}，无需清理");
					return;
				}
				string[] array = Enumerable.ToArray<string>((System.Collections.Generic.IEnumerable<string>)Enumerable.OrderByDescending<string, System.DateTime>((System.Collections.Generic.IEnumerable<string>)files, (Func<string, System.DateTime>)([SpecialName] (string f) => ((FileSystemInfo)new FileInfo(f)).CreationTime)));
				int num = 0;
				int num2 = array.Length - 1;
				for (int i = keepCount; i <= num2; i++)
				{
					try
					{
						File.Delete(array[i]);
						num++;
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						Log($"删除配置文件失败: {Path.GetFileName(array[i])}");
						ProjectData.ClearProjectError();
					}
				}
				Log($"已清理 {num} 个旧配置文件，保留最新的 {keepCount} 个");
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				Log($"清理配置文件失败: {ex4.Message}");
				ProjectData.ClearProjectError();
			}
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelink/pagelinklobby.xaml", (UriKind)2);
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
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanScroll = (MyScrollViewer)target;
			break;
		case 2:
			PanLogin = (Grid)target;
			break;
		case 3:
			BtnLogin = (MyButton)target;
			break;
		case 4:
			BtnRegister = (MyButton)target;
			break;
		case 5:
			PanMain = (StackPanel)target;
			break;
		case 6:
			LabProviderName = (TextBlock)target;
			break;
		case 7:
			LabUsername = (TextBlock)target;
			break;
		case 8:
			LabTraffic = (TextBlock)target;
			break;
		case 9:
			LabGroup = (TextBlock)target;
			break;
		case 10:
			LabProxies = (TextBlock)target;
			break;
		case 11:
			PanConfig = (StackPanel)target;
			break;
		case 12:
			ComboTunnel = (MyComboBox)target;
			break;
		case 13:
			ComboRoom = (MyComboBox)target;
			break;
		case 14:
			BtnStart = (MyButton)target;
			break;
		case 15:
			BtnCreateTunnel = (MyButton)target;
			break;
		case 16:
			PanRunning = (StackPanel)target;
			break;
		case 17:
			LabRunningTime = (TextBlock)target;
			break;
		case 18:
			LabRunningLatency = (TextBlock)target;
			break;
		case 19:
			TextAddress = (MyTextBox)target;
			break;
		case 20:
			BtnCopy = (MyButton)target;
			break;
		case 21:
			BtnStop = (MyButton)target;
			break;
		case 22:
			TextLog = (TextBox)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__41_002D0()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		((DispatcherObject)this).Dispatcher.Invoke((Action)([SpecialName] [CompilerGenerated] () =>
		{
			if (((Collection<string>)(object)_rooms).Count == 0)
			{
				ComboRoom.Text = "未发现房间，可手动输入端口号";
			}
		}));
	}
}
