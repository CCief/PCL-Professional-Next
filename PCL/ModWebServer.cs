using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Link.Natayark;
using PCL.Core.Net;

namespace PCL;

[StandardModule]
public sealed class ModWebServer
{
	[Serializable]
	public class OAuthCompleteStatus
	{
		[field: CompilerGenerated]
		public bool success
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string username
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string message
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string stacktrace
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public OAuthCompleteStatus()
		{
			success = false;
		}

		public static OAuthCompleteStatus Complete(string username)
		{
			return new OAuthCompleteStatus
			{
				success = true,
				username = username
			};
		}

		public static OAuthCompleteStatus Failed(string message, System.Exception ex = null)
		{
			OAuthCompleteStatus oAuthCompleteStatus = new OAuthCompleteStatus();
			oAuthCompleteStatus.success = false;
			oAuthCompleteStatus.message = message;
			oAuthCompleteStatus.stacktrace = ex?.ToString();
			return oAuthCompleteStatus;
		}
	}

	public delegate OAuthCompleteStatus OAuthComplete(bool success, IDictionary<string, string> parameters, string content);

	[CompilerGenerated]
	internal sealed class _Closure_0024__10_002D0
	{
		public ushort _0024VB_0024Local_port;

		public _Closure_0024__10_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public Predicate<IPEndPoint> _0024I1;

		public _Closure_0024__10_002D0(_Closure_0024__10_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_port = arg0._0024VB_0024Local_port;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__1(IPEndPoint i)
		{
			return i.Port == _0024VB_0024Local_port;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__10_002D1
	{
		public string _0024VB_0024Local_serviceName;

		public OAuthComplete _0024VB_0024Local_completeCallback;

		public string _0024VB_0024Local_url;

		public _Closure_0024__10_002D1(_Closure_0024__10_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_serviceName = arg0._0024VB_0024Local_serviceName;
				_0024VB_0024Local_completeCallback = arg0._0024VB_0024Local_completeCallback;
				_0024VB_0024Local_url = arg0._0024VB_0024Local_url;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Expected O, but got Unknown
			//IL_00ec: Expected O, but got Unknown
			_Closure_0024__10_002D0 arg = new _Closure_0024__10_002D0(null)
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_2 = this
			};
			checked
			{
				lock (_webServers)
				{
					_Closure_0024__10_002D2 arg2 = default(_Closure_0024__10_002D2);
					_Closure_0024__10_002D2 CS_0024_003C_003E8__locals0 = new _Closure_0024__10_002D2(null);
					CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3 = arg;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_server = null;
					CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port = 29992;
					do
					{
						if (!System.Array.Exists<IPEndPoint>(IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners(), (Predicate<IPEndPoint>)([SpecialName] (IPEndPoint i) => i.Port == CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port)))
						{
							ModBase.Log($"[OAuth] {_0024VB_0024Local_serviceName}: 尝试在 {CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port} 端口初始化 Web 服务端");
							try
							{
								CS_0024_003C_003E8__locals0._0024VB_0024Local_server = new RoutedWebServer($"127.0.0.1:{CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port}");
							}
							catch (HttpListenerException val)
							{
								ProjectData.SetProjectError((System.Exception)val);
								HttpListenerException val2 = val;
								if (((Win32Exception)val2).NativeErrorCode == -2147467259)
								{
									ProjectData.ClearProjectError();
									goto IL_0130;
								}
								throw;
							}
							ModBase.Log($"[OAuth] {_0024VB_0024Local_serviceName}: 已开始监听 {CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port} 端口，正在初始化路由");
							break;
						}
						goto IL_0130;
						IL_0130:
						CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port = (ushort)unchecked((uint)(CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port + 1));
					}
					while (unchecked((uint)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port) <= 30992u);
					if (CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port > 30992)
					{
						string text = "29992 ~ 30992 范围内没有任何可用端口号";
						_0024VB_0024Local_completeCallback(success: false, null, text);
						ModBase.Log($"[OAuth] {_0024VB_0024Local_serviceName}: {text}");
						return;
					}
					CS_0024_003C_003E8__locals0._0024VB_0024Local_status = null;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_callbackParameters = null;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_callbackContent = null;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_redirect = RoutedResponse.Redirect("/complete", (HttpStatusCode)302);
					CS_0024_003C_003E8__locals0._0024VB_0024Local_server.Route("/callback", [SpecialName] (string path, HttpListenerRequest request) =>
					{
						//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
						//IL_00cb: Expected O, but got Unknown
						Dictionary<string, string> val3 = new Dictionary<string, string>();
						string query = request.Url.Query;
						int num = query.IndexOf('?');
						RoutedResponse _0024VB_0024Local_redirect;
						if (num != -1 && query.Length > num)
						{
							try
							{
								string[] array = query.Substring(num + 1).Split('&', (StringSplitOptions)0);
								char[] array2 = new char[] { '=' };
								string[] array3 = array;
								for (int j = 0; j < array3.Length; j++)
								{
									string[] array4 = array3[j].Split(array2, 2);
									val3[array4[0]] = array4[1];
								}
							}
							catch (System.Exception ex3)
							{
								ProjectData.SetProjectError(ex3);
								System.Exception ex4 = ex3;
								CS_0024_003C_003E8__locals0._0024VB_0024Local_status = OAuthCompleteStatus.Failed("回调参数解析出错", ex4);
								_0024VB_0024Local_redirect = CS_0024_003C_003E8__locals0._0024VB_0024Local_redirect;
								ProjectData.ClearProjectError();
								goto IL_0117;
							}
						}
						CS_0024_003C_003E8__locals0._0024VB_0024Local_callbackParameters = (IDictionary<string, string>)(object)val3;
						if (request.HasEntityBody)
						{
							try
							{
								StreamReader val4 = new StreamReader(request.InputStream, request.ContentEncoding);
								try
								{
									CS_0024_003C_003E8__locals0._0024VB_0024Local_callbackContent = val4.ReadToEnd();
								}
								finally
								{
									((System.IDisposable)val4)?.Dispose();
								}
							}
							catch (System.Exception ex5)
							{
								ProjectData.SetProjectError(ex5);
								System.Exception ex6 = ex5;
								CS_0024_003C_003E8__locals0._0024VB_0024Local_status = OAuthCompleteStatus.Failed("读取回调内容出错", ex6);
								_0024VB_0024Local_redirect = CS_0024_003C_003E8__locals0._0024VB_0024Local_redirect;
								ProjectData.ClearProjectError();
								goto IL_0117;
							}
						}
						_0024VB_0024Local_redirect = CS_0024_003C_003E8__locals0._0024VB_0024Local_redirect;
						goto IL_0117;
						IL_0117:
						return _0024VB_0024Local_redirect;
					});
					CS_0024_003C_003E8__locals0._0024VB_0024Local_server.Route("/status", [SpecialName] () =>
					{
						if (CS_0024_003C_003E8__locals0._0024VB_0024Local_callbackParameters == null)
						{
							return RoutedResponse.NotFound;
						}
						CS_0024_003C_003E8__locals0._0024VB_0024Local_server.StopResponse();
						try
						{
							if (CS_0024_003C_003E8__locals0._0024VB_0024Local_status == null)
							{
								CS_0024_003C_003E8__locals0._0024VB_0024Local_status = CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_completeCallback(success: true, CS_0024_003C_003E8__locals0._0024VB_0024Local_callbackParameters, CS_0024_003C_003E8__locals0._0024VB_0024Local_callbackContent);
							}
							else if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_status.success)
							{
								ModBase.Log(string.Format("[OAuth] {0}: {1}{2}{3}", new object[4]
								{
									CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_serviceName,
									CS_0024_003C_003E8__locals0._0024VB_0024Local_status.message,
									"\r\n",
									CS_0024_003C_003E8__locals0._0024VB_0024Local_status.stacktrace
								}));
								CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_completeCallback(success: false, null, CS_0024_003C_003E8__locals0._0024VB_0024Local_status.message);
							}
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							CS_0024_003C_003E8__locals0._0024VB_0024Local_status = OAuthCompleteStatus.Failed("处理回调出错", ex2);
							ProjectData.ClearProjectError();
						}
						return RoutedResponse.Json(CS_0024_003C_003E8__locals0._0024VB_0024Local_status);
					});
					CS_0024_003C_003E8__locals0._0024VB_0024Local_server.Route("/assets/background", [SpecialName] () => string.IsNullOrWhiteSpace(PicAddress) ? RoutedResponse.NotFound : RoutedResponse.Input((Stream)new FileStream(PicAddress, (FileMode)3, (FileAccess)1, (FileShare)0, 16384, true)));
					CS_0024_003C_003E8__locals0._0024VB_0024Local_server.Route("/assets/icon", [SpecialName] () => RoutedResponse.Input(ModBase.GetResourceStream("Images/icon.ico")));
					CS_0024_003C_003E8__locals0._0024VB_0024Local_server.Route("/complete", [SpecialName] () => RoutedResponse.Input(ModBase.GetResourceStream("Resources/oauth-complete.html"), "text/html"));
					string name = $"oauth/{_0024VB_0024Local_serviceName}";
					if (DisposeWebServer(name))
					{
						ModBase.Log("[OAuth] 已关闭先前认证服务服务端");
					}
					StartWebServer(name, CS_0024_003C_003E8__locals0._0024VB_0024Local_server);
					ModBase.Log($"[OAuth] {_0024VB_0024Local_serviceName}: 初始化完成，开始响应 HTTP 请求");
				}
				ModBase.OpenWebsite(_0024VB_0024Local_url.Replace("%r", $"http://localhost:{arg._0024VB_0024Local_port}/callback"));
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__10_002D2
	{
		public OAuthCompleteStatus _0024VB_0024Local_status;

		public RoutedResponse _0024VB_0024Local_redirect;

		public IDictionary<string, string> _0024VB_0024Local_callbackParameters;

		public string _0024VB_0024Local_callbackContent;

		public RoutedWebServer _0024VB_0024Local_server;

		public _Closure_0024__10_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_3;

		public _Closure_0024__10_002D2(_Closure_0024__10_002D2 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_status = arg0._0024VB_0024Local_status;
				_0024VB_0024Local_redirect = arg0._0024VB_0024Local_redirect;
				_0024VB_0024Local_callbackParameters = arg0._0024VB_0024Local_callbackParameters;
				_0024VB_0024Local_callbackContent = arg0._0024VB_0024Local_callbackContent;
				_0024VB_0024Local_server = arg0._0024VB_0024Local_server;
			}
		}

		[SpecialName]
		internal RoutedResponse _Lambda_0024__2(string path, HttpListenerRequest request)
		{
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Expected O, but got Unknown
			Dictionary<string, string> val = new Dictionary<string, string>();
			string query = request.Url.Query;
			int num = query.IndexOf('?');
			RoutedResponse result;
			checked
			{
				if (num != -1 && query.Length > num)
				{
					try
					{
						string[] array = query.Substring(num + 1).Split('&', (StringSplitOptions)0);
						char[] array2 = new char[] { '=' };
						string[] array3 = array;
						for (int i = 0; i < array3.Length; i++)
						{
							string[] array4 = array3[i].Split(array2, 2);
							val[array4[0]] = array4[1];
						}
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						_0024VB_0024Local_status = OAuthCompleteStatus.Failed("回调参数解析出错", ex2);
						result = _0024VB_0024Local_redirect;
						ProjectData.ClearProjectError();
						goto IL_0117;
					}
				}
				_0024VB_0024Local_callbackParameters = (IDictionary<string, string>)(object)val;
				if (request.HasEntityBody)
				{
					try
					{
						StreamReader val2 = new StreamReader(request.InputStream, request.ContentEncoding);
						try
						{
							_0024VB_0024Local_callbackContent = val2.ReadToEnd();
						}
						finally
						{
							((System.IDisposable)val2)?.Dispose();
						}
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						_0024VB_0024Local_status = OAuthCompleteStatus.Failed("读取回调内容出错", ex4);
						result = _0024VB_0024Local_redirect;
						ProjectData.ClearProjectError();
						goto IL_0117;
					}
				}
				result = _0024VB_0024Local_redirect;
				goto IL_0117;
			}
			IL_0117:
			return result;
		}

		[SpecialName]
		internal RoutedResponse _Lambda_0024__3()
		{
			if (_0024VB_0024Local_callbackParameters == null)
			{
				return RoutedResponse.NotFound;
			}
			_0024VB_0024Local_server.StopResponse();
			try
			{
				if (_0024VB_0024Local_status == null)
				{
					_0024VB_0024Local_status = _0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_completeCallback(success: true, _0024VB_0024Local_callbackParameters, _0024VB_0024Local_callbackContent);
				}
				else if (!_0024VB_0024Local_status.success)
				{
					ModBase.Log(string.Format("[OAuth] {0}: {1}{2}{3}", new object[4]
					{
						_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_serviceName,
						_0024VB_0024Local_status.message,
						"\r\n",
						_0024VB_0024Local_status.stacktrace
					}));
					_0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_completeCallback(success: false, null, _0024VB_0024Local_status.message);
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				_0024VB_0024Local_status = OAuthCompleteStatus.Failed("处理回调出错", ex2);
				ProjectData.ClearProjectError();
			}
			return RoutedResponse.Json(_0024VB_0024Local_status);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__2_002D0
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine___Lambda_0024__0 : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncTaskMethodBuilder _0024Builder;

			internal _Closure_0024__2_002D0 _0024VB_0024NonLocal__Closure_0024__2_002D0;

			internal TaskAwaiter _0024A0;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_0094: Unknown result type (might be due to invalid IL or missing references)
				//IL_0099: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00af: Unknown result type (might be due to invalid IL or missing references)
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0071: Unknown result type (might be due to invalid IL or missing references)
				//IL_0072: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				try
				{
					if (num != -3 && num != 0)
					{
						ModBase.Log($"[WebServer] 服务端 '{_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_name}' 已启动");
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
							val = _0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_server.StartResponseAsync().GetAwaiter();
							if (!val.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = val;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine___Lambda_0024__0>(ref val, ref _this);
								return;
							}
							break;
						case 0:
							num = (_0024State = -1);
							val = _0024A0;
							_0024A0 = default(TaskAwaiter);
							break;
						}
						val.GetResult();
						val = default(TaskAwaiter);
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, $"[WebServer] 服务端 '{_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_name}' 运行出错");
						ProjectData.ClearProjectError();
					}
					_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_server.Dispose();
					ModBase.Log($"[WebServer] 服务端 '{_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_name}' 已停止");
					object webServers = _webServers;
					bool flag = false;
					try
					{
						Monitor.Enter(webServers, ref flag);
						_webServers.Remove(_0024VB_0024NonLocal__Closure_0024__2_002D0._0024VB_0024Local_name);
					}
					finally
					{
						if (num < 0 && flag)
						{
							Monitor.Exit(webServers);
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

		public string _0024VB_0024Local_name;

		public WebServer _0024VB_0024Local_server;

		[SpecialName]
		[AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__0))]
		internal System.Threading.Tasks.Task _Lambda_0024__0()
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__2_002D0 = this;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
			return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
		}
	}

	private static Dictionary<string, WebServer> _webServers = new Dictionary<string, WebServer>();

	private static object ChangeLock = RuntimeHelpers.GetObjectValue(new object());

	private static string PicAddress;

	public static bool StartWebServer(string name, WebServer server)
	{
		_Closure_0024__2_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__2_002D0();
		CS_0024_003C_003E8__locals0._0024VB_0024Local_name = name;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_server = server;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_name = CS_0024_003C_003E8__locals0._0024VB_0024Local_name.ToLowerInvariant();
		lock (_webServers)
		{
			if (_webServers.ContainsKey(CS_0024_003C_003E8__locals0._0024VB_0024Local_name))
			{
				return false;
			}
			_webServers[CS_0024_003C_003E8__locals0._0024VB_0024Local_name] = CS_0024_003C_003E8__locals0._0024VB_0024Local_server;
		}
		System.Threading.Tasks.Task.Run((Func<System.Threading.Tasks.Task>)([SpecialName] [AsyncStateMachine(typeof(_Closure_0024__2_002D0.VB_0024StateMachine___Lambda_0024__0))] () =>
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			_Closure_0024__2_002D0.VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(_Closure_0024__2_002D0.VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__2_002D0 = CS_0024_003C_003E8__locals0;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<_Closure_0024__2_002D0.VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
			return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
		}));
		return true;
	}

	public static bool IsWebServerRunning(string name)
	{
		name = name.ToLowerInvariant();
		return _webServers.ContainsKey(name);
	}

	public static bool DisposeWebServer(string name)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0043: Expected O, but got Unknown
		name = name.ToLowerInvariant();
		bool result;
		lock (_webServers)
		{
			if (!_webServers.ContainsKey(name))
			{
				result = false;
			}
			else
			{
				try
				{
					_webServers[name].Dispose();
				}
				catch (ObjectDisposedException val)
				{
					ProjectData.SetProjectError((System.Exception)val);
					ObjectDisposedException val2 = val;
					result = false;
					ProjectData.ClearProjectError();
					goto end_IL_0010;
				}
				_webServers.Remove(name);
				result = true;
			}
			end_IL_0010:;
		}
		return result;
	}

	public static object BackgroundPicChangeCallback(string Pic)
	{
		object changeLock = ChangeLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(changeLock);
		bool flag = false;
		try
		{
			Monitor.Enter(changeLock, ref flag);
			PicAddress = Pic;
			return true;
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(changeLock);
			}
		}
	}

	public static bool StartOAuthWaitingCallback(string serviceName, string url, OAuthComplete completeCallback)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		_Closure_0024__10_002D1 arg = default(_Closure_0024__10_002D1);
		_Closure_0024__10_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__10_002D1(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_serviceName = serviceName;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_url = url;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_completeCallback = completeCallback;
		if (IsWebServerRunning(CS_0024_003C_003E8__locals0._0024VB_0024Local_serviceName))
		{
			return false;
		}
		checked
		{
			ModBase.RunInNewThread((Action)([SpecialName] () =>
			{
				//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ea: Expected O, but got Unknown
				//IL_00ec: Expected O, but got Unknown
				_Closure_0024__10_002D0 arg2 = new _Closure_0024__10_002D0(null);
				arg2._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals0;
				lock (_webServers)
				{
					_Closure_0024__10_002D2 arg3 = default(_Closure_0024__10_002D2);
					_Closure_0024__10_002D2 CS_0024_003C_003E8__locals1 = new _Closure_0024__10_002D2(null);
					CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3 = arg2;
					CS_0024_003C_003E8__locals1._0024VB_0024Local_server = null;
					CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port = 29992;
					do
					{
						if (!System.Array.Exists<IPEndPoint>(IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners(), (Predicate<IPEndPoint>)([SpecialName] (IPEndPoint i) => i.Port == CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port)))
						{
							ModBase.Log($"[OAuth] {CS_0024_003C_003E8__locals0._0024VB_0024Local_serviceName}: 尝试在 {CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port} 端口初始化 Web 服务端");
							try
							{
								CS_0024_003C_003E8__locals1._0024VB_0024Local_server = new RoutedWebServer($"127.0.0.1:{CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port}");
							}
							catch (HttpListenerException val)
							{
								ProjectData.SetProjectError((System.Exception)val);
								HttpListenerException val2 = val;
								if (((Win32Exception)val2).NativeErrorCode != -2147467259)
								{
									throw;
								}
								ProjectData.ClearProjectError();
								goto IL_0130;
							}
							ModBase.Log($"[OAuth] {CS_0024_003C_003E8__locals0._0024VB_0024Local_serviceName}: 已开始监听 {CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port} 端口，正在初始化路由");
							break;
						}
						goto IL_0130;
						IL_0130:
						CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port = (ushort)unchecked((uint)(CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port + 1));
					}
					while (unchecked((uint)CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port) <= 30992u);
					if (CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024Local_port > 30992)
					{
						string text = "29992 ~ 30992 范围内没有任何可用端口号";
						CS_0024_003C_003E8__locals0._0024VB_0024Local_completeCallback(success: false, null, text);
						ModBase.Log($"[OAuth] {CS_0024_003C_003E8__locals0._0024VB_0024Local_serviceName}: {text}");
						return;
					}
					CS_0024_003C_003E8__locals1._0024VB_0024Local_status = null;
					CS_0024_003C_003E8__locals1._0024VB_0024Local_callbackParameters = null;
					CS_0024_003C_003E8__locals1._0024VB_0024Local_callbackContent = null;
					CS_0024_003C_003E8__locals1._0024VB_0024Local_redirect = RoutedResponse.Redirect("/complete", (HttpStatusCode)302);
					CS_0024_003C_003E8__locals1._0024VB_0024Local_server.Route("/callback", [SpecialName] (string path, HttpListenerRequest request) =>
					{
						//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
						//IL_00cb: Expected O, but got Unknown
						Dictionary<string, string> val3 = new Dictionary<string, string>();
						string query = request.Url.Query;
						int num = query.IndexOf('?');
						RoutedResponse _0024VB_0024Local_redirect;
						if (num != -1 && query.Length > num)
						{
							try
							{
								string[] array = query.Substring(num + 1).Split('&', (StringSplitOptions)0);
								char[] array2 = new char[] { '=' };
								string[] array3 = array;
								for (int j = 0; j < array3.Length; j++)
								{
									string[] array4 = array3[j].Split(array2, 2);
									val3[array4[0]] = array4[1];
								}
							}
							catch (System.Exception ex3)
							{
								ProjectData.SetProjectError(ex3);
								System.Exception ex4 = ex3;
								CS_0024_003C_003E8__locals1._0024VB_0024Local_status = OAuthCompleteStatus.Failed("回调参数解析出错", ex4);
								_0024VB_0024Local_redirect = CS_0024_003C_003E8__locals1._0024VB_0024Local_redirect;
								ProjectData.ClearProjectError();
								goto IL_0117;
							}
						}
						CS_0024_003C_003E8__locals1._0024VB_0024Local_callbackParameters = (IDictionary<string, string>)(object)val3;
						if (request.HasEntityBody)
						{
							try
							{
								StreamReader val4 = new StreamReader(request.InputStream, request.ContentEncoding);
								try
								{
									CS_0024_003C_003E8__locals1._0024VB_0024Local_callbackContent = val4.ReadToEnd();
								}
								finally
								{
									((System.IDisposable)val4)?.Dispose();
								}
							}
							catch (System.Exception ex5)
							{
								ProjectData.SetProjectError(ex5);
								System.Exception ex6 = ex5;
								CS_0024_003C_003E8__locals1._0024VB_0024Local_status = OAuthCompleteStatus.Failed("读取回调内容出错", ex6);
								_0024VB_0024Local_redirect = CS_0024_003C_003E8__locals1._0024VB_0024Local_redirect;
								ProjectData.ClearProjectError();
								goto IL_0117;
							}
						}
						_0024VB_0024Local_redirect = CS_0024_003C_003E8__locals1._0024VB_0024Local_redirect;
						goto IL_0117;
						IL_0117:
						return _0024VB_0024Local_redirect;
					});
					CS_0024_003C_003E8__locals1._0024VB_0024Local_server.Route("/status", [SpecialName] () =>
					{
						if (CS_0024_003C_003E8__locals1._0024VB_0024Local_callbackParameters == null)
						{
							return RoutedResponse.NotFound;
						}
						CS_0024_003C_003E8__locals1._0024VB_0024Local_server.StopResponse();
						try
						{
							if (CS_0024_003C_003E8__locals1._0024VB_0024Local_status == null)
							{
								CS_0024_003C_003E8__locals1._0024VB_0024Local_status = CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_completeCallback(success: true, CS_0024_003C_003E8__locals1._0024VB_0024Local_callbackParameters, CS_0024_003C_003E8__locals1._0024VB_0024Local_callbackContent);
							}
							else if (!CS_0024_003C_003E8__locals1._0024VB_0024Local_status.success)
							{
								ModBase.Log(string.Format("[OAuth] {0}: {1}{2}{3}", new object[4]
								{
									CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_serviceName,
									CS_0024_003C_003E8__locals1._0024VB_0024Local_status.message,
									"\r\n",
									CS_0024_003C_003E8__locals1._0024VB_0024Local_status.stacktrace
								}));
								CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_3._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_completeCallback(success: false, null, CS_0024_003C_003E8__locals1._0024VB_0024Local_status.message);
							}
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							CS_0024_003C_003E8__locals1._0024VB_0024Local_status = OAuthCompleteStatus.Failed("处理回调出错", ex2);
							ProjectData.ClearProjectError();
						}
						return RoutedResponse.Json(CS_0024_003C_003E8__locals1._0024VB_0024Local_status);
					});
					CS_0024_003C_003E8__locals1._0024VB_0024Local_server.Route("/assets/background", [SpecialName] () => string.IsNullOrWhiteSpace(PicAddress) ? RoutedResponse.NotFound : RoutedResponse.Input((Stream)new FileStream(PicAddress, (FileMode)3, (FileAccess)1, (FileShare)0, 16384, true)));
					CS_0024_003C_003E8__locals1._0024VB_0024Local_server.Route("/assets/icon", [SpecialName] () => RoutedResponse.Input(ModBase.GetResourceStream("Images/icon.ico")));
					CS_0024_003C_003E8__locals1._0024VB_0024Local_server.Route("/complete", [SpecialName] () => RoutedResponse.Input(ModBase.GetResourceStream("Resources/oauth-complete.html"), "text/html"));
					string name = $"oauth/{CS_0024_003C_003E8__locals0._0024VB_0024Local_serviceName}";
					if (DisposeWebServer(name))
					{
						ModBase.Log("[OAuth] 已关闭先前认证服务服务端");
					}
					StartWebServer(name, CS_0024_003C_003E8__locals1._0024VB_0024Local_server);
					ModBase.Log($"[OAuth] {CS_0024_003C_003E8__locals0._0024VB_0024Local_serviceName}: 初始化完成，开始响应 HTTP 请求");
				}
				ModBase.OpenWebsite(CS_0024_003C_003E8__locals0._0024VB_0024Local_url.Replace("%r", $"http://localhost:{arg2._0024VB_0024Local_port}/callback"));
			}), $"CallbackWebServerLoading/{CS_0024_003C_003E8__locals0._0024VB_0024Local_serviceName}", (ThreadPriority)2);
			return true;
		}
	}

	public static void StartNaidAuthorize(Action completeCallback = null)
	{
		StartOAuthWaitingCallback("NatayarkID", $"https://account.naids.com/oauth2/authorize?response_type=code&client_id={ModSecret.NatayarkClientId}&redirect_uri=%r", [SpecialName] (bool success, IDictionary<string, string> parameters, string content) =>
		{
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_0060: Expected O, but got Unknown
			if (!success)
			{
				ModMain.MyMsgBox(content, "提示", "确定", "", "", IsWarn: true);
				Action obj = completeCallback;
				if (obj != null)
				{
					obj.Invoke();
				}
				return (OAuthCompleteStatus)null;
			}
			OAuthCompleteStatus oAuthCompleteStatus = null;
			string token = parameters["code"];
			System.Exception ex = null;
			try
			{
				NatayarkProfileManager.GetNaidDataAsync(token).Wait();
			}
			catch (AggregateException val)
			{
				ProjectData.SetProjectError((System.Exception)val);
				AggregateException val2 = val;
				ex = val2.InnerExceptions[0];
				ProjectData.ClearProjectError();
			}
			oAuthCompleteStatus = ((ex != null) ? OAuthCompleteStatus.Failed("获取用户信息失败，请尝试重新登录", ex) : OAuthCompleteStatus.Complete(NatayarkProfileManager.NaidProfile.Username));
			Action obj2 = completeCallback;
			if (obj2 != null)
			{
				obj2.Invoke();
			}
			return oAuthCompleteStatus;
		});
	}
}
