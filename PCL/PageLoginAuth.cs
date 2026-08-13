using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.Core.Minecraft.Yggdrasil;
using PCL.Core.Net;
using PCL.Core.Utils;
using PCL.Core.Utils.Exts;

namespace PCL;

[DesignerGenerated]
public class PageLoginAuth : Grid, IComponentConnector
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__5_002D0
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine___Lambda_0024__0 : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncTaskMethodBuilder _0024Builder;

			internal _Closure_0024__5_002D0 _0024VB_0024NonLocal__Closure_0024__5_002D0;

			internal TaskAwaiter _0024A0;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
				//IL_008f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0094: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				try
				{
					if (num != -3)
					{
					}
					try
					{
						TaskAwaiter val;
						if (num != -3)
						{
							if (num != 0)
							{
								ModProfile.IsCreatingProfile = true;
								ModLaunch.McLoginAuthLoader.Start(_0024VB_0024NonLocal__Closure_0024__5_002D0._0024VB_0024Local_LoginData, IsForceRestart: true);
								goto IL_00ec;
							}
							num = (_0024State = -1);
							val = _0024A0;
							_0024A0 = default(TaskAwaiter);
							goto IL_00dd;
						}
						num = (_0024State = -1);
						return;
						IL_00ec:
						if (ModLaunch.McLoginAuthLoader.State == ModBase.LoadState.Loading)
						{
							_0024VB_0024NonLocal__Closure_0024__5_002D0._0024VB_0024Me.BtnLogin.Text = Conversions.ToString(Math.Round(ModLaunch.McLoginAuthLoader.Progress * 100.0)) + "%";
							val = System.Threading.Tasks.Task.Delay(50).GetAwaiter();
							if (!val.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = val;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine___Lambda_0024__0>(ref val, ref _this);
								return;
							}
							goto IL_00dd;
						}
						if (ModLaunch.McLoginAuthLoader.State == ModBase.LoadState.Finished)
						{
							ModMain.FrmLaunchLeft.RefreshPage(Anim: true);
						}
						else
						{
							if (ModLaunch.McLoginAuthLoader.State != ModBase.LoadState.Aborted)
							{
								if (ModLaunch.McLoginAuthLoader.Error == null)
								{
									throw new System.Exception("未知错误！");
								}
								throw new System.Exception(ModLaunch.McLoginAuthLoader.Error.Message, ModLaunch.McLoginAuthLoader.Error);
							}
							ModMain.Hint("已取消登录！");
						}
						goto end_IL_000f;
						IL_00dd:
						val.GetResult();
						val = default(TaskAwaiter);
						goto IL_00ec;
						end_IL_000f:;
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						if (Operators.CompareString(ex2.Message, "$$", false) != 0)
						{
							if (ex2.Message.StartsWith("$"))
							{
								ModMain.Hint(ex2.Message.TrimStart('$'), ModMain.HintType.Critical);
							}
							else
							{
								ModBase.Log(ex2, "第三方登录尝试失败", ModBase.LogLevel.Msgbox);
							}
						}
						ProjectData.ClearProjectError();
					}
					finally
					{
						if (num < 0)
						{
							ModProfile.IsCreatingProfile = false;
							((UIElement)_0024VB_0024NonLocal__Closure_0024__5_002D0._0024VB_0024Me.BtnLogin).IsEnabled = true;
							((UIElement)_0024VB_0024NonLocal__Closure_0024__5_002D0._0024VB_0024Me.BtnBack).IsEnabled = true;
							_0024VB_0024NonLocal__Closure_0024__5_002D0._0024VB_0024Me.BtnLogin.Text = "登录";
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

		public ModLaunch.McLoginServer _0024VB_0024Local_LoginData;

		public PageLoginAuth _0024VB_0024Me;

		public _Closure_0024__5_002D0(_Closure_0024__5_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_LoginData = arg0._0024VB_0024Local_LoginData;
			}
		}

		[SpecialName]
		[AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__0))]
		internal System.Threading.Tasks.Task _Lambda_0024__0()
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__5_002D0 = this;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
			return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D0
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine___Lambda_0024__0 : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncTaskMethodBuilder _0024Builder;

			internal _Closure_0024__6_002D0 _0024VB_0024NonLocal__Closure_0024__6_002D0;

			internal _Closure_0024__6_002D1 _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;

			internal string _0024VB_0024ResumableLocal_serverUri_00241;

			internal string _0024VB_0024ResumableLocal_serverName_00242;

			internal TaskAwaiter<string> _0024A0;

			internal TaskAwaiter<HttpResponseHandler> _0024A1;

			internal _Closure_0024__6_002D1 _0024U1;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_006f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0074: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
				//IL_0126: Unknown result type (might be due to invalid IL or missing references)
				//IL_012b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0132: Unknown result type (might be due to invalid IL or missing references)
				//IL_0194: Unknown result type (might be due to invalid IL or missing references)
				//IL_0199: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
				//IL_021b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0220: Unknown result type (might be due to invalid IL or missing references)
				//IL_0228: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
				//IL_0088: Unknown result type (might be due to invalid IL or missing references)
				//IL_0089: Unknown result type (might be due to invalid IL or missing references)
				//IL_0141: Unknown result type (might be due to invalid IL or missing references)
				//IL_0158: Unknown result type (might be due to invalid IL or missing references)
				//IL_015d: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
				//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
				//IL_0238: Unknown result type (might be due to invalid IL or missing references)
				//IL_0103: Unknown result type (might be due to invalid IL or missing references)
				//IL_0104: Unknown result type (might be due to invalid IL or missing references)
				//IL_0171: Unknown result type (might be due to invalid IL or missing references)
				//IL_0172: Unknown result type (might be due to invalid IL or missing references)
				//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
				//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				try
				{
					if (num != -3 && (uint)num > 3u)
					{
						_0024VB_0024ResumableLocal_serverUri_00241 = null;
						_0024VB_0024ResumableLocal_serverName_00242 = null;
					}
					try
					{
						string result;
						TaskAwaiter<string> awaiter4;
						_Closure_0024__6_002D1 closure_0024__6_002D;
						string result2;
						TaskAwaiter<string> awaiter2;
						HttpResponseHandler result3;
						TaskAwaiter<HttpResponseHandler> awaiter3;
						TaskAwaiter<string> awaiter;
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return;
						default:
							_0024VB_0024ResumableLocal__0024VB_0024Closure__00240 = new _Closure_0024__6_002D1();
							awaiter4 = ApiLocation.TryRequestAsync(_0024VB_0024NonLocal__Closure_0024__6_002D0._0024VB_0024Local_serverUriInput).GetAwaiter();
							if (!awaiter4.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = awaiter4;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine___Lambda_0024__0>(ref awaiter4, ref _this);
								return;
							}
							goto IL_00bd;
						case 0:
							num = (_0024State = -1);
							awaiter4 = _0024A0;
							_0024A0 = default(TaskAwaiter<string>);
							goto IL_00bd;
						case 1:
							num = (_0024State = -1);
							awaiter3 = _0024A1;
							_0024A1 = default(TaskAwaiter<HttpResponseHandler>);
							goto IL_0138;
						case 2:
							num = (_0024State = -1);
							awaiter2 = _0024A0;
							_0024A0 = default(TaskAwaiter<string>);
							goto IL_01a6;
						case 3:
							{
								num = (_0024State = -1);
								awaiter = _0024A0;
								_0024A0 = default(TaskAwaiter<string>);
								break;
							}
							IL_00bd:
							result = awaiter4.GetResult();
							awaiter4 = default(TaskAwaiter<string>);
							_0024VB_0024ResumableLocal_serverUri_00241 = result;
							awaiter3 = HttpRequestBuilder.Create(_0024VB_0024ResumableLocal_serverUri_00241, HttpMethod.Get).SendAsync().GetAwaiter();
							if (!awaiter3.IsCompleted)
							{
								num = (_0024State = 1);
								_0024A1 = awaiter3;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseHandler>, VB_0024StateMachine___Lambda_0024__0>(ref awaiter3, ref _this);
								return;
							}
							goto IL_0138;
							IL_01a6:
							closure_0024__6_002D = _0024U1;
							result2 = awaiter2.GetResult();
							awaiter2 = default(TaskAwaiter<string>);
							closure_0024__6_002D._0024VB_0024Local_responseText = result2;
							_0024U1 = null;
							awaiter = System.Threading.Tasks.Task.Run<string>((Func<string>)([SpecialName] () => JObject.Parse(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_responseText)["meta"]["serverName"].ToString())).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_0024State = 3);
								_0024A0 = awaiter;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine___Lambda_0024__0>(ref awaiter, ref _this);
								return;
							}
							break;
							IL_0138:
							result3 = awaiter3.GetResult();
							awaiter3 = default(TaskAwaiter<HttpResponseHandler>);
							_0024U1 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;
							awaiter2 = result3.AsStringAsync().GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_0024State = 2);
								_0024A0 = awaiter2;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine___Lambda_0024__0>(ref awaiter2, ref _this);
								return;
							}
							goto IL_01a6;
						}
						string result4 = awaiter.GetResult();
						awaiter = default(TaskAwaiter<string>);
						_0024VB_0024ResumableLocal_serverName_00242 = result4;
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "从服务器获取名称失败");
						ProjectData.ClearProjectError();
					}
					if (_0024VB_0024ResumableLocal_serverUri_00241 != null)
					{
						_0024VB_0024NonLocal__Closure_0024__6_002D0._0024VB_0024Me.TextServer.Text = _0024VB_0024ResumableLocal_serverUri_00241;
					}
					if (_0024VB_0024ResumableLocal_serverName_00242 == null)
					{
						((UIElement)_0024VB_0024NonLocal__Closure_0024__6_002D0._0024VB_0024Me.TextServerName).Visibility = (Visibility)1;
					}
					else
					{
						_0024VB_0024NonLocal__Closure_0024__6_002D0._0024VB_0024Me.TextServerName.Text = "验证服务器: " + _0024VB_0024ResumableLocal_serverName_00242;
						((UIElement)_0024VB_0024NonLocal__Closure_0024__6_002D0._0024VB_0024Me.TextServerName).Visibility = (Visibility)0;
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

		public string _0024VB_0024Local_serverUriInput;

		public PageLoginAuth _0024VB_0024Me;

		[SpecialName]
		[AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__0))]
		internal System.Threading.Tasks.Task _Lambda_0024__0()
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__6_002D0 = this;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
			return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D1
	{
		public string _0024VB_0024Local_responseText;

		[SpecialName]
		internal string _Lambda_0024__1()
		{
			return JObject.Parse(_0024VB_0024Local_responseText)["meta"]["serverName"].ToString();
		}
	}

	public static string DraggedAuthServer = null;

	private static readonly Dictionary<string, string> PredefinedAuthServers;

	[CompilerGenerated]
	[AccessedThroughProperty("TextServer")]
	private MyComboBox _TextServer;

	[CompilerGenerated]
	[AccessedThroughProperty("TextName")]
	private MyTextBox _TextName;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnLink")]
	private MyTextButton _BtnLink;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnBack")]
	private MyButton _BtnBack;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnLogin")]
	private MyButton _BtnLogin;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextServerName")]
	internal virtual TextBlock TextServerName
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnEdit")]
	internal virtual MyIconButton BtnEdit
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnExit")]
	internal virtual MyIconButton BtnExit
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyComboBox TextServer
	{
		[CompilerGenerated]
		get
		{
			return _TextServer;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyboardFocusChangedEventHandler val = (KeyboardFocusChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, KeyboardFocusChangedEventArgs a1) =>
			{
				GetServerName();
			});
			MyComboBox textServer = _TextServer;
			if (textServer != null)
			{
				((UIElement)textServer).LostKeyboardFocus -= val;
			}
			_TextServer = value;
			textServer = _TextServer;
			if (textServer != null)
			{
				((UIElement)textServer).LostKeyboardFocus += val;
			}
		}
	}

	internal virtual MyTextBox TextName
	{
		[CompilerGenerated]
		get
		{
			return _TextName;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			TextChangedEventHandler val = (TextChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, TextChangedEventArgs a1) =>
			{
				ComboName_TextChanged();
			});
			MyTextBox textName = _TextName;
			if (textName != null)
			{
				((TextBoxBase)textName).TextChanged -= val;
			}
			_TextName = value;
			textName = _TextName;
			if (textName != null)
			{
				((TextBoxBase)textName).TextChanged += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextPass")]
	internal virtual PasswordBox TextPass
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyTextButton BtnLink
	{
		[CompilerGenerated]
		get
		{
			return _BtnLink;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyTextButton.ClickEventHandler obj = Btn_Click;
			MyTextButton btnLink = _BtnLink;
			if (btnLink != null)
			{
				btnLink.Click -= obj;
			}
			_BtnLink = value;
			btnLink = _BtnLink;
			if (btnLink != null)
			{
				btnLink.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnBack
	{
		[CompilerGenerated]
		get
		{
			return _BtnBack;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnBack_Click;
			MyButton btnBack = _BtnBack;
			if (btnBack != null)
			{
				btnBack.Click -= obj;
			}
			_BtnBack = value;
			btnBack = _BtnBack;
			if (btnBack != null)
			{
				btnBack.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnLogin
	{
		[CompilerGenerated]
		get
		{
			return _BtnLogin;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnLogin_Click;
			MyButton btnLogin = _BtnLogin;
			if (btnLogin != null)
			{
				btnLogin.Click -= obj;
			}
			_BtnLogin = value;
			btnLogin = _BtnLogin;
			if (btnLogin != null)
			{
				btnLogin.Click += obj;
			}
		}
	}

	static PageLoginAuth()
	{
		Dictionary<string, string> obj = new Dictionary<string, string>();
		obj.Add("预设 - LittleSkin", "https://littleskin.cn/api/yggdrasil");
		obj.Add("自定义", "");
		PredefinedAuthServers = obj;
	}

	public PageLoginAuth()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Reload();
		});
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			ReloadRegisterButton();
		});
		InitializeComponent();
	}

	private void Reload()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		ItemCollection items = ((ItemsControl)TextServer).Items;
		items.Clear();
		System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator = PredefinedAuthServers.Keys.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				MyComboBoxItem myComboBoxItem = new MyComboBoxItem();
				((ContentControl)myComboBoxItem).Content = current;
				items.Add((object)myComboBoxItem);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		if (DraggedAuthServer != null)
		{
			TextServer.Text = DraggedAuthServer;
			DraggedAuthServer = null;
		}
	}

	private void BtnBack_Click(object sender, EventArgs e)
	{
		TextServer.Text = null;
		((TextBox)TextName).Text = null;
		TextPass.Password = null;
		ModMain.FrmLaunchLeft.RefreshPage(Anim: true);
	}

	private void BtnLogin_Click(object sender, EventArgs e)
	{
		_Closure_0024__5_002D0 arg = default(_Closure_0024__5_002D0);
		_Closure_0024__5_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__5_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
		if (string.IsNullOrWhiteSpace(TextServer.Text) || string.IsNullOrWhiteSpace(((TextBox)TextName).Text) || string.IsNullOrWhiteSpace(TextPass.Password))
		{
			ModMain.Hint("验证服务器、用户名与密码均不能为空！", ModMain.HintType.Critical);
			return;
		}
		if (!TextServer.Text.IsMatch(RegexPatterns.HttpUri))
		{
			ModMain.Hint("输入的验证服务器地址无效", ModMain.HintType.Critical);
			return;
		}
		((UIElement)BtnLogin).IsEnabled = false;
		((UIElement)BtnBack).IsEnabled = false;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_LoginData = new ModLaunch.McLoginServer(ModLaunch.McLoginType.Auth)
		{
			BaseUrl = (ModBase.EndsWithF(TextServer.Text, "/") ? (TextServer.Text + "authserver") : (TextServer.Text + "/authserver")),
			UserName = ((TextBox)TextName).Text,
			Password = TextPass.Password,
			Description = "Authlib-Injector",
			Type = ModLaunch.McLoginType.Auth
		};
		((DispatcherObject)this).Dispatcher.BeginInvoke((System.Delegate)(VB_0024AnonymousDelegate_0<System.Threading.Tasks.Task>)([SpecialName] [AsyncStateMachine(typeof(_Closure_0024__5_002D0.VB_0024StateMachine___Lambda_0024__0))] () =>
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			_Closure_0024__5_002D0.VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(_Closure_0024__5_002D0.VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__5_002D0 = CS_0024_003C_003E8__locals0;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<_Closure_0024__5_002D0.VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
			return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
		}), new object[0]);
	}

	private void GetServerName()
	{
		_Closure_0024__6_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__6_002D0();
		CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_serverUriInput = TextServer.Text;
		if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0._0024VB_0024Local_serverUriInput))
		{
			((UIElement)TextServerName).Visibility = (Visibility)1;
			return;
		}
		((DispatcherObject)this).Dispatcher.BeginInvoke((System.Delegate)(VB_0024AnonymousDelegate_0<System.Threading.Tasks.Task>)([SpecialName] [AsyncStateMachine(typeof(_Closure_0024__6_002D0.VB_0024StateMachine___Lambda_0024__0))] () =>
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			_Closure_0024__6_002D0.VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(_Closure_0024__6_002D0.VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__6_002D0 = CS_0024_003C_003E8__locals0;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<_Closure_0024__6_002D0.VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
			return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
		}), new object[0]);
	}

	private void ComboName_TextChanged()
	{
		((ContentControl)BtnLink).Content = ((Operators.CompareString(((TextBox)TextName).Text, "", false) == 0) ? "注册账号" : "找回密码");
	}

	private void Btn_Click(object sender, EventArgs e)
	{
		if (Operators.ConditionalCompareObjectEqual(((ContentControl)BtnLink).Content, (object)"注册账号", false))
		{
			ModBase.OpenWebsite(Conversions.ToString(((object)ModMinecraft.McInstanceCurrent != null) ? ModBase.Setup.Get("VersionServerAuthRegister", ModMinecraft.McInstanceCurrent) : ""));
		}
		else
		{
			ModBase.OpenWebsite(Conversions.ToString(((object)ModMinecraft.McInstanceCurrent != null) ? ModBase.Setup.Get("VersionServerAuthRegister", ModMinecraft.McInstanceCurrent) : "").Replace("/auth/register", "/auth/forgot"));
		}
	}

	private void ReloadRegisterButton()
	{
		string str = Conversions.ToString(((object)ModMinecraft.McInstanceCurrent != null) ? ModBase.Setup.Get("VersionServerAuthRegister", ModMinecraft.McInstanceCurrent) : "");
		((UIElement)BtnLink).Visibility = (Visibility)((!string.IsNullOrEmpty(new ValidateHttp().ValidateText(str))) ? 2 : 0);
	}

	private void TextServer_TextChanged(object sender, TextChangedEventArgs e)
	{
		string text = null;
		PredefinedAuthServers.TryGetValue(TextServer.Text, out text);
		if (text != null)
		{
			TextServer.Text = text;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelaunch/pageloginauth.xaml", (UriKind)2);
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
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			TextServerName = (TextBlock)target;
			break;
		case 2:
			BtnEdit = (MyIconButton)target;
			break;
		case 3:
			BtnExit = (MyIconButton)target;
			break;
		case 4:
			TextServer = (MyComboBox)target;
			break;
		case 5:
			TextName = (MyTextBox)target;
			break;
		case 6:
			TextPass = (PasswordBox)target;
			break;
		case 7:
			BtnLink = (MyTextButton)target;
			break;
		case 8:
			BtnBack = (MyButton)target;
			break;
		case 9:
			BtnLogin = (MyButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
