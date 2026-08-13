using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.UI;
using PCL.Core.UI.Controls;

namespace PCL;

[DesignerGenerated]
public class ServerCard : MyCard, IComponentConnector
{
	public class ResultEventArgs : EventArgs
	{
		[field: CompilerGenerated]
		public string Param1
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string Param2
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public ResultEventArgs(string param1, string param2)
		{
			Param1 = param1;
			Param2 = param2;
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_13_UpdateServerUi : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal ServerCard _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
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
					goto IL_00ac;
				}
				if (_0024VB_0024Me.Server != null)
				{
					_0024VB_0024Me.ServerName.Text = _0024VB_0024Me.Server.Name;
					val = ImageLoaderHelper.SetServerLogoAsync(_0024VB_0024Me.Server.Icon, _0024VB_0024Me.ServerIcon).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_13_UpdateServerUi>(ref val, ref _this);
						return;
					}
					goto IL_00ac;
				}
				goto end_IL_0007;
				IL_00ac:
				val.GetResult();
				val = default(TaskAwaiter);
				if (_0024VB_0024Me.Server.Status == ServerStatus.Online)
				{
					_0024VB_0024Me._manager.SetSelectedIconByName(_0024VB_0024Me.GetSignalIcon(_0024VB_0024Me.Server.Ping));
					((FrameworkElement)_0024VB_0024Me.Signal).ToolTip = _0024VB_0024Me.Server.Ping + "ms";
					ToolTipService.SetInitialShowDelay((DependencyObject)(object)_0024VB_0024Me.Signal, 0);
					ToolTipService.SetBetweenShowDelay((DependencyObject)(object)_0024VB_0024Me.Signal, 50);
					ToolTipService.SetPlacement((DependencyObject)(object)_0024VB_0024Me.Signal, (PlacementMode)10);
					if (_0024VB_0024Me.Server.PlayerCount != 0 && _0024VB_0024Me.Server.MaxPlayers != 0)
					{
						_0024VB_0024Me.ServerPlayer.Text = $"{_0024VB_0024Me.Server.PlayerCount} / {_0024VB_0024Me.Server.MaxPlayers}";
					}
					else
					{
						_0024VB_0024Me.ServerPlayer.Text = "???";
					}
					((UIElement)_0024VB_0024Me.ServerMotD).Visibility = (Visibility)2;
					_0024VB_0024Me.MotdRenderer.RenderMotd(_0024VB_0024Me.Server.Description, ThemeHelper.IsDarkMode());
					_0024VB_0024Me.MotdRenderer.RenderCanvas();
				}
				else if (_0024VB_0024Me.Server.Status == ServerStatus.Pinging)
				{
					_0024VB_0024Me._manager.SetSelectedIconByName("loading");
					_0024VB_0024Me.MotdRenderer.ClearCanvas();
					_0024VB_0024Me.ServerPlayer.Text = "正在连接";
					_0024VB_0024Me.ServerMotD.Text = "正在连接...";
					((UIElement)_0024VB_0024Me.ServerMotD).Visibility = (Visibility)0;
				}
				else if (_0024VB_0024Me.Server.Status == ServerStatus.Offline)
				{
					_0024VB_0024Me._manager.SetSelectedIconByName("signal_offline");
					_0024VB_0024Me.MotdRenderer.ClearCanvas();
					_0024VB_0024Me.ServerPlayer.Text = "离线";
					_0024VB_0024Me.ServerMotD.Text = "服务器离线";
					((UIElement)_0024VB_0024Me.ServerMotD).Visibility = (Visibility)0;
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
	internal sealed class VB_0024StateMachine_15_RefreshServerStatus : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal bool _0024VB_0024Local_withHint;

		internal CancellationToken _0024VB_0024Local_token;

		internal ServerCard _0024VB_0024Me;

		internal TaskAwaiter<MinecraftServerInfo> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter<MinecraftServerInfo> awaiter;
				if (num != 0)
				{
					if (_0024VB_0024Local_withHint)
					{
						ModMain.Hint($"正在刷新服务器 {_0024VB_0024Me.Server.Name} 的状态...");
					}
					_0024VB_0024Me.Server.Status = ServerStatus.Pinging;
					ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
					{
						_0024VB_0024Me.UpdateServerUi();
					}));
					awaiter = PageInstanceServer.PingServer(_0024VB_0024Me.Server, _0024VB_0024Local_token).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = awaiter;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<MinecraftServerInfo>, VB_0024StateMachine_15_RefreshServerStatus>(ref awaiter, ref _this);
						return;
					}
				}
				else
				{
					num = (_0024State = -1);
					awaiter = _0024A0;
					_0024A0 = default(TaskAwaiter<MinecraftServerInfo>);
				}
				MinecraftServerInfo result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<MinecraftServerInfo>);
				MinecraftServerInfo serverInfo = result;
				_0024VB_0024Me.UpdateServerInfo(serverInfo);
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
	internal sealed class VB_0024StateMachine_18_BtnRefresh_Click : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal RoutedEventArgs _0024VB_0024Local_e;

		internal ServerCard _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num != 0)
				{
					val = System.Threading.Tasks.Task.Run((Func<System.Threading.Tasks.Task>)([SpecialName] [CompilerGenerated] [AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__18_002D0))] () =>
					{
						//IL_001a: Unknown result type (might be due to invalid IL or missing references)
						//IL_001f: Unknown result type (might be due to invalid IL or missing references)
						VB_0024StateMachine___Lambda_0024__18_002D0 vB_0024StateMachine___Lambda_0024__18_002D = default(VB_0024StateMachine___Lambda_0024__18_002D0);
						vB_0024StateMachine___Lambda_0024__18_002D._0024VB_0024Me = _0024VB_0024Me;
						vB_0024StateMachine___Lambda_0024__18_002D._0024State = -1;
						vB_0024StateMachine___Lambda_0024__18_002D._0024Builder = AsyncTaskMethodBuilder.Create();
						vB_0024StateMachine___Lambda_0024__18_002D._0024Builder.Start<VB_0024StateMachine___Lambda_0024__18_002D0>(ref vB_0024StateMachine___Lambda_0024__18_002D);
						return vB_0024StateMachine___Lambda_0024__18_002D._0024Builder.Task;
					})).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_18_BtnRefresh_Click>(ref val, ref _this);
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

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine___Lambda_0024__18_002D0 : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal ServerCard _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num != 0)
				{
					val = _0024VB_0024Me.RefreshServerStatus(withHint: true).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine___Lambda_0024__18_002D0>(ref val, ref _this);
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

	public MinecraftServerInfo Server;

	private readonly IconManager _manager;

	[CompilerGenerated]
	private EventHandler RemoveServerEvent;

	[CompilerGenerated]
	private EventHandler EditServerEvent;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSetting")]
	private MyIconButton _BtnSetting;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual Grid PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ServerIcon")]
	internal virtual Image ServerIcon
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ServerName")]
	internal virtual TextBlock ServerName
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("Signal")]
	internal virtual ContentPresenter Signal
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ServerPlayer")]
	internal virtual TextBlock ServerPlayer
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("MotdRenderer")]
	internal virtual MotdRenderer MotdRenderer
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ServerMotD")]
	internal virtual TextBlock ServerMotD
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconButton BtnSetting
	{
		[CompilerGenerated]
		get
		{
			return _BtnSetting;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Expected O, but got Unknown
				BtnSkin_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
			};
			MyIconButton btnSetting = _BtnSetting;
			if (btnSetting != null)
			{
				btnSetting.Click -= obj;
			}
			_BtnSetting = value;
			btnSetting = _BtnSetting;
			if (btnSetting != null)
			{
				btnSetting.Click += obj;
			}
		}
	}

	public event EventHandler RemoveServer
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			EventHandler val = RemoveServerEvent;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)System.Delegate.Combine((System.Delegate)(object)val2, (System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref RemoveServerEvent, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			EventHandler val = RemoveServerEvent;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)System.Delegate.Remove((System.Delegate)(object)val2, (System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref RemoveServerEvent, val3, val2);
			}
			while (val != val2);
		}
	}

	public event EventHandler EditServer
	{
		[CompilerGenerated]
		add
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			EventHandler val = EditServerEvent;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)System.Delegate.Combine((System.Delegate)(object)val2, (System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref EditServerEvent, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Expected O, but got Unknown
			EventHandler val = EditServerEvent;
			EventHandler val2;
			do
			{
				val2 = val;
				EventHandler val3 = (EventHandler)System.Delegate.Remove((System.Delegate)(object)val2, (System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler>(ref EditServerEvent, val3, val2);
			}
			while (val != val2);
		}
	}

	public ServerCard()
	{
		InitializeComponent();
		((FrameworkElement)this).DataContext = new IconManager();
		_manager = ((FrameworkElement)this).DataContext as IconManager;
		_manager.AddIconFromXaml("signal_1", "<Viewbox xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Width=\"20\" Height=\"20\"><Canvas UseLayoutRounding=\"False\" Width=\"1024.0\" Height=\"1024.0\"><Canvas.Clip><RectangleGeometry Rect=\"0.0,0.0,1024.0,1024.0\"/></Canvas.Clip><Canvas UseLayoutRounding=\"False\"><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"234.666667\" Canvas.Top=\"610.56\" Width=\"80.853333\" Height=\"127.04\" Fill=\"#ff00ff21\"/></Canvas><Canvas UseLayoutRounding=\"False\"><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"353.066667\" Canvas.Top=\"541.226667\" Width=\"80.853333\" Height=\"196.373333\" Fill=\"#ff888888\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"471.445333\" Canvas.Top=\"460.373333\" Width=\"80.896\" Height=\"277.226667\" Fill=\"#ff888888\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"589.866667\" Canvas.Top=\"379.52\" Width=\"80.853333\" Height=\"358.08\" Fill=\"#ff888888\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"708.266667\" Canvas.Top=\"298.666667\" Width=\"80.853333\" Height=\"438.933333\" Fill=\"#ff888888\"/></Canvas></Canvas></Viewbox>");
		_manager.AddIconFromXaml("signal_2", "<Viewbox xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Width=\"20\" Height=\"20\"><Canvas UseLayoutRounding=\"False\" Width=\"1024.0\" Height=\"1024.0\"><Canvas.Clip><RectangleGeometry Rect=\"0.0,0.0,1024.0,1024.0\"/></Canvas.Clip><Canvas UseLayoutRounding=\"False\"><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"234.666667\" Canvas.Top=\"610.56\" Width=\"80.853333\" Height=\"127.04\" Fill=\"#ff00ff21\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"353.066667\" Canvas.Top=\"541.226667\" Width=\"80.853333\" Height=\"196.373333\" Fill=\"#ff00ff21\"/></Canvas><Canvas UseLayoutRounding=\"False\"><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"471.445333\" Canvas.Top=\"460.373333\" Width=\"80.896\" Height=\"277.226667\" Fill=\"#ff888888\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"589.866667\" Canvas.Top=\"379.52\" Width=\"80.853333\" Height=\"358.08\" Fill=\"#ff888888\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"708.266667\" Canvas.Top=\"298.666667\" Width=\"80.853333\" Height=\"438.933333\" Fill=\"#ff888888\"/></Canvas></Canvas></Viewbox>");
		_manager.AddIconFromXaml("signal_3", "<Viewbox Width=\"20\" Height=\"20\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Canvas UseLayoutRounding=\"False\" Width=\"1024.0\" Height=\"1024.0\"><Canvas.Clip><RectangleGeometry Rect=\"0.0,0.0,1024.0,1024.0\"/></Canvas.Clip><Canvas UseLayoutRounding=\"False\"><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"234.666667\" Canvas.Top=\"610.56\" Width=\"80.853333\" Height=\"127.04\" Fill=\"#ff00ff21\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"353.066667\" Canvas.Top=\"541.226667\" Width=\"80.853333\" Height=\"196.373333\" Fill=\"#ff00ff21\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"471.445333\" Canvas.Top=\"460.373333\" Width=\"80.896\" Height=\"277.226667\" Fill=\"#ff00ff21\"/></Canvas><Canvas UseLayoutRounding=\"False\"><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"589.866667\" Canvas.Top=\"379.52\" Width=\"80.853333\" Height=\"358.08\" Fill=\"#ff888888\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"708.266667\" Canvas.Top=\"298.666667\" Width=\"80.853333\" Height=\"438.933333\" Fill=\"#ff888888\"/></Canvas></Canvas></Viewbox>");
		_manager.AddIconFromXaml("signal_4", "<Viewbox xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Width=\"20\" Height=\"20\"><Canvas UseLayoutRounding=\"False\" Width=\"1024.0\" Height=\"1024.0\"><Canvas.Clip><RectangleGeometry Rect=\"0.0,0.0,1024.0,1024.0\"/></Canvas.Clip><Canvas UseLayoutRounding=\"False\"><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"234.666667\" Canvas.Top=\"610.56\" Width=\"80.853333\" Height=\"127.04\" Fill=\"#ff00ff21\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"353.066667\" Canvas.Top=\"541.226667\" Width=\"80.853333\" Height=\"196.373333\" Fill=\"#ff00ff21\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"471.445333\" Canvas.Top=\"460.373333\" Width=\"80.896\" Height=\"277.226667\" Fill=\"#ff00ff21\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"589.866667\" Canvas.Top=\"379.52\" Width=\"80.853333\" Height=\"358.08\" Fill=\"#ff00ff21\"/></Canvas><Canvas UseLayoutRounding=\"False\"><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"708.266667\" Canvas.Top=\"298.666667\" Width=\"80.853333\" Height=\"438.933333\" Fill=\"#ff888888\"/></Canvas></Canvas></Viewbox>");
		_manager.AddIconFromXaml("signal_5", "<Viewbox Width=\"20\" Height=\"20\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Canvas UseLayoutRounding=\"False\" Width=\"1024.0\" Height=\"1024.0\"><Canvas.Clip><RectangleGeometry Rect=\"0.0,0.0,1024.0,1024.0\"/></Canvas.Clip><Canvas UseLayoutRounding=\"False\"><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"234.666667\" Canvas.Top=\"610.56\" Width=\"80.853333\" Height=\"127.04\" Fill=\"#ff00ff21\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"353.066667\" Canvas.Top=\"541.226667\" Width=\"80.853333\" Height=\"196.373333\" Fill=\"#ff00ff21\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"471.445333\" Canvas.Top=\"460.373333\" Width=\"80.896\" Height=\"277.226667\" Fill=\"#ff00ff21\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"589.866667\" Canvas.Top=\"379.52\" Width=\"80.853333\" Height=\"358.08\" Fill=\"#ff00ff21\"/><Rectangle RadiusX=\"0.0\" RadiusY=\"0.0\" Canvas.Left=\"708.266667\" Canvas.Top=\"298.666667\" Width=\"80.853333\" Height=\"438.933333\" Fill=\"#ff00ff21\"/></Canvas></Canvas></Viewbox>");
		_manager.AddIconFromXaml("signal_offline", "<Viewbox xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Width=\"14\" Height=\"14\" Margin=\"3\"><Canvas UseLayoutRounding=\"False\" Width=\"1280.0\" Height=\"1024.0\"><Canvas.Clip><RectangleGeometry Rect=\"0.0,0.0,1280.0,1024.0\"/></Canvas.Clip><Path Fill=\"#ff000000\"><Path.Data><PathGeometry Figures=\"M 317.63 349.235 l -67.951 -67.951 l -67.95 67.95 c -18.964 18.964 -48.988 18.964 -67.951 0 c -18.963 -18.962 -18.963 -48.987 0 -67.95 l 67.95 -67.95 l -66.37 -67.951 c -18.963 -18.963 -18.963 -48.988 0 -67.95 c 18.963 -18.964 48.988 -18.964 67.95 0 l 67.951 67.95 l 67.95 -67.95 c 18.964 -18.964 48.989 -18.964 67.951 0 c 18.963 18.962 18.963 48.987 0 67.95 l -67.95 67.95 l 67.95 67.951 c 18.963 18.963 18.963 48.988 0 67.95 c -9.481 9.482 -20.543 14.223 -33.185 14.223 c -14.222 0 -26.864 -6.321 -36.345 -14.222 z M 216.494 752.198 h -48.988 c -26.864 0 -48.987 26.864 -48.987 60.049 v 120.099 c 0 33.185 22.123 60.05 48.987 60.05 h 48.988 c 26.864 0 48.987 -26.865 48.987 -60.05 v -120.1 c 0 -33.184 -22.123 -60.048 -48.987 -60.048 z M 516.74 512 h -48.988 c -26.864 0 -48.988 26.864 -48.988 60.05 v 360.296 c 0 33.185 22.124 60.05 48.988 60.05 h 48.988 c 26.864 0 48.987 -26.865 48.987 -60.05 V 572.049 c 0 -33.185 -22.123 -60.049 -48.987 -60.049 z m 300.247 -240.198 H 768 c -26.864 0 -48.988 26.865 -48.988 60.05 v 600.494 c 0 33.185 22.124 60.05 48.988 60.05 h 48.988 c 26.864 0 48.987 -26.865 48.987 -60.05 V 331.852 c 0 -33.185 -22.123 -60.05 -48.987 -60.05 z m 300.247 -240.197 h -48.988 c -26.864 0 -48.988 26.864 -48.988 60.05 v 840.69 c 0 33.186 22.124 60.05 48.988 60.05 h 48.988 c 26.864 0 48.987 -26.864 48.987 -60.05 V 91.656 c -1.58 -33.186 -22.123 -60.05 -48.987 -60.05 z\" FillRule=\"Nonzero\"/></Path.Data></Path></Canvas></Viewbox>");
		_manager.AddIconFromXaml("loading", "<Viewbox xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" Width=\"20\" Height=\"20\"><Canvas UseLayoutRounding=\"False\" Width=\"1024.0\" Height=\"1024.0\"><Canvas.Clip><RectangleGeometry Rect=\"0.0,0.0,1024.0,1024.0\"/></Canvas.Clip><Path Fill=\"#ff000000\"><Path.Data><PathGeometry Figures=\"M 256 490.667 a 64 64 0 1 1 -128 0 a 64 64 0 0 1 128 0 z m -42.6667 0 a 21.3333 21.3333 0 1 0 -42.6667 0 a 21.3333 21.3333 0 0 0 42.6667 0 z m 384 0 a 106.667 106.667 0 1 1 -213.376 -0.042667 A 106.667 106.667 0 0 1 597.333 490.667 z m -42.6667 0 a 64 64 0 1 0 -128.043 0.042666 A 64 64 0 0 0 554.667 490.667 z m 298.667 0 a 64 64 0 1 1 -128 0 a 64 64 0 0 1 128 0 z m -42.6667 0 a 21.3333 21.3333 0 1 0 -42.6667 0 a 21.3333 21.3333 0 0 0 42.6667 0 z\" FillRule=\"Nonzero\"/></Path.Data></Path></Canvas></Viewbox>");
	}

	private void BtnSkin_Click(object sender, RoutedEventArgs e)
	{
		((FrameworkElement)BtnSetting).ContextMenu.IsOpen = true;
	}

	public void UpdateServerInfo(MinecraftServerInfo serverInfo)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		Server = serverInfo;
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			UpdateServerUi();
		}));
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_13_UpdateServerUi))]
	private void UpdateServerUi()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_13_UpdateServerUi vB_0024StateMachine_13_UpdateServerUi = default(VB_0024StateMachine_13_UpdateServerUi);
		vB_0024StateMachine_13_UpdateServerUi._0024VB_0024Me = this;
		vB_0024StateMachine_13_UpdateServerUi._0024State = -1;
		vB_0024StateMachine_13_UpdateServerUi._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_13_UpdateServerUi._0024Builder.Start<VB_0024StateMachine_13_UpdateServerUi>(ref vB_0024StateMachine_13_UpdateServerUi);
	}

	private string GetSignalIcon(int ping)
	{
		if (ping >= 0 && ping <= 99)
		{
			return "signal_5";
		}
		if (ping >= 100 && ping <= 299)
		{
			return "signal_4";
		}
		if (ping >= 300 && ping <= 599)
		{
			return "signal_3";
		}
		if (ping >= 600 && ping <= 999)
		{
			return "signal_2";
		}
		return "signal_1";
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_15_RefreshServerStatus))]
	public System.Threading.Tasks.Task RefreshServerStatus(bool withHint, CancellationToken token = default(CancellationToken))
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_15_RefreshServerStatus vB_0024StateMachine_15_RefreshServerStatus = default(VB_0024StateMachine_15_RefreshServerStatus);
		vB_0024StateMachine_15_RefreshServerStatus._0024VB_0024Me = this;
		vB_0024StateMachine_15_RefreshServerStatus._0024VB_0024Local_withHint = withHint;
		vB_0024StateMachine_15_RefreshServerStatus._0024VB_0024Local_token = token;
		vB_0024StateMachine_15_RefreshServerStatus._0024State = -1;
		vB_0024StateMachine_15_RefreshServerStatus._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_15_RefreshServerStatus._0024Builder.Start<VB_0024StateMachine_15_RefreshServerStatus>(ref vB_0024StateMachine_15_RefreshServerStatus);
		return vB_0024StateMachine_15_RefreshServerStatus._0024Builder.Task;
	}

	private void BtnConnect_Click(object sender, EventArgs e)
	{
		try
		{
			ModLaunch.McLaunchStart(new ModLaunch.McLaunchOptions
			{
				ServerIp = Server.Address
			});
			ModMain.FrmMain.PageChange(new FormMain.PageStackData
			{
				Page = FormMain.PageType.Launch
			});
			ModMain.Hint($"正在连接到服务器 {Server.Name}...");
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "启动服务器失败", ModBase.LogLevel.Feedback);
			ModMain.Hint("启动服务器失败：" + ex2.Message, ModMain.HintType.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnCopy_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			Clipboard.SetText(Server.Address);
			ModMain.Hint($"已复制服务器地址：{Server.Address}", ModMain.HintType.Finish);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "复制服务器地址失败");
			ModMain.Hint("复制服务器地址失败", ModMain.HintType.Critical);
			ProjectData.ClearProjectError();
		}
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_18_BtnRefresh_Click))]
	private void BtnRefresh_Click(object sender, RoutedEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_18_BtnRefresh_Click vB_0024StateMachine_18_BtnRefresh_Click = default(VB_0024StateMachine_18_BtnRefresh_Click);
		vB_0024StateMachine_18_BtnRefresh_Click._0024VB_0024Me = this;
		vB_0024StateMachine_18_BtnRefresh_Click._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_18_BtnRefresh_Click._0024VB_0024Local_e = e;
		vB_0024StateMachine_18_BtnRefresh_Click._0024State = -1;
		vB_0024StateMachine_18_BtnRefresh_Click._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_18_BtnRefresh_Click._0024Builder.Start<VB_0024StateMachine_18_BtnRefresh_Click>(ref vB_0024StateMachine_18_BtnRefresh_Click);
	}

	private void BtnEdit_Click(object sender, RoutedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ValueTuple<string, string, bool> serverInfo = PageInstanceServer.GetServerInfo(Server);
			if (serverInfo.Item3)
			{
				EventHandler editServerEvent = EditServerEvent;
				if (editServerEvent != null)
				{
					editServerEvent.Invoke((object)this, (EventArgs)(object)new ResultEventArgs(serverInfo.Item1, serverInfo.Item2));
				}
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModMain.Hint("编辑服务器信息失败：" + ex2.Message, ModMain.HintType.Critical);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnRemove_Click(object sender, RoutedEventArgs e)
	{
		if (ModMain.MyMsgBox(string.Concat(new string[] { "你确定要移除服务器 ", Server.Name, " 吗？\r\n'", Server.Address, "' 将从您的列表中移除，包括游戏内列表，且无法恢复。" }), "移除服务器确认", "确认", "取消") == 1)
		{
			EventHandler removeServerEvent = RemoveServerEvent;
			if (removeServerEvent != null)
			{
				removeServerEvent.Invoke((object)this, EventArgs.Empty);
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/servercard.xaml", (UriKind)2);
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
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (Grid)target;
			break;
		case 2:
			ServerIcon = (Image)target;
			break;
		case 3:
			ServerName = (TextBlock)target;
			break;
		case 4:
			Signal = (ContentPresenter)target;
			break;
		case 5:
			ServerPlayer = (TextBlock)target;
			break;
		case 6:
			MotdRenderer = (MotdRenderer)target;
			break;
		case 7:
			ServerMotD = (TextBlock)target;
			break;
		case 8:
			BtnSetting = (MyIconButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
