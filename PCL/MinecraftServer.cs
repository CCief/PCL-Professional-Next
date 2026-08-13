using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Link;
using PCL.Core.Minecraft;
using PCL.Core.UI;
using PCL.Core.UI.Controls;

namespace PCL;

[DesignerGenerated]
public class MinecraftServer : Grid, IComponentConnector
{
	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_8_UpdateServerInfoAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_address;

		internal MinecraftServer _0024VB_0024Me;

		internal McPingResult _0024VB_0024ResumableLocal_ret_00240;

		internal McPing _0024VB_0024ResumableLocal_query_00241;

		internal TaskAwaiter<ValueTuple<string, int>> _0024A0;

		internal TaskAwaiter<McPingResult> _0024A1;

		internal TaskAwaiter _0024A2;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_01da: Unknown result type (might be due to invalid IL or missing references)
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_027c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if ((uint)(num - -4) <= 1u || (uint)num <= 2u)
				{
					goto IL_00a4;
				}
				if (_0024VB_0024Local_address != null)
				{
					_0024VB_0024Local_address = _0024VB_0024Local_address.Replace("：", ":");
					_0024VB_0024Me.LabServerDesc.Foreground = (Brush)(object)Brushes.White;
					_0024VB_0024Me.LabServerDesc.Text = "查询中...";
					_0024VB_0024Me.LabServerPlayer.Text = "-/-";
					((FrameworkElement)_0024VB_0024Me.LabServerPlayer).ToolTip = null;
					ImageLoaderHelper.SetFallbackImage(_0024VB_0024Me.ImgServerLogo, "pack://application:,,,/Plain Craft Launcher 2;component/Images/Icons/DefaultServer.png");
					goto IL_00a4;
				}
				goto end_IL_0007;
				IL_00a4:
				try
				{
					ValueTuple<string, int> result;
					TaskAwaiter<ValueTuple<string, int>> awaiter;
					ValueTuple<string, int> val;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						awaiter = ServerAddressResolver.GetReachableAddressAsync(_0024VB_0024Local_address).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<ValueTuple<string, int>>, VB_0024StateMachine_8_UpdateServerInfoAsync>(ref awaiter, ref _this);
							return;
						}
						goto IL_013b;
					case 0:
						num = (_0024State = -1);
						awaiter = _0024A0;
						_0024A0 = default(TaskAwaiter<ValueTuple<string, int>>);
						goto IL_013b;
					case -4:
					case 1:
					case 2:
						break;
						IL_013b:
						result = awaiter.GetResult();
						awaiter = default(TaskAwaiter<ValueTuple<string, int>>);
						val = result;
						_0024VB_0024ResumableLocal_query_00241 = new McPing(val.Item1, val.Item2);
						break;
					}
					try
					{
						TaskAwaiter val2;
						if (num != -4)
						{
							TaskAwaiter<McPingResult> awaiter2;
							if (num != 1)
							{
								if (num == 2)
								{
									num = (_0024State = -1);
									val2 = _0024A2;
									_0024A2 = default(TaskAwaiter);
									goto IL_0282;
								}
								awaiter2 = _0024VB_0024ResumableLocal_query_00241.PingAsync().GetAwaiter();
								if (!awaiter2.IsCompleted)
								{
									num = (_0024State = 1);
									_0024A1 = awaiter2;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<McPingResult>, VB_0024StateMachine_8_UpdateServerInfoAsync>(ref awaiter2, ref _this);
									return;
								}
							}
							else
							{
								num = (_0024State = -1);
								awaiter2 = _0024A1;
								_0024A1 = default(TaskAwaiter<McPingResult>);
							}
							McPingResult result2 = awaiter2.GetResult();
							awaiter2 = default(TaskAwaiter<McPingResult>);
							_0024VB_0024ResumableLocal_ret_00240 = result2;
							if ((object)_0024VB_0024ResumableLocal_ret_00240 == null)
							{
								throw new System.Exception("未返回服务器信息");
							}
							val2 = ImageLoaderHelper.SetServerLogoAsync(_0024VB_0024ResumableLocal_ret_00240.Favicon, _0024VB_0024Me.ImgServerLogo).GetAwaiter();
							if (!val2.IsCompleted)
							{
								num = (_0024State = 2);
								_0024A2 = val2;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_8_UpdateServerInfoAsync>(ref val2, ref _this);
								return;
							}
							goto IL_0282;
						}
						num = (_0024State = -1);
						return;
						IL_0282:
						val2.GetResult();
						val2 = default(TaskAwaiter);
						_0024VB_0024Me.UpdateServerStatus(_0024VB_0024ResumableLocal_ret_00240);
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_query_00241 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_query_00241).Dispose();
						}
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "[MinecraftServer] 信息查询失败");
					_0024VB_0024Me.LabServerDesc.Text = $"无法连接: {ex2.Message}";
					_0024VB_0024Me.LabServerDesc.Foreground = (Brush)(object)Brushes.Red;
					ImageLoaderHelper.SetFallbackImage(_0024VB_0024Me.ImgServerLogo, "pack://application:,,,/Plain Craft Launcher 2;component/Images/Icons/DefaultServer.png");
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

	private const string FallbackImageUri = "pack://application:,,,/Plain Craft Launcher 2;component/Images/Icons/DefaultServer.png";

	private static readonly DependencyProperty AddressProperty = DependencyProperty.Register("Address", typeof(string), typeof(MinecraftServer), new PropertyMetadata((object)string.Empty, new PropertyChangedCallback(OnAddressChanged)));

	private bool _contentLoaded;

	public string Address
	{
		get
		{
			return Conversions.ToString(base.GetValue(AddressProperty));
		}
		set
		{
			base.SetValue(AddressProperty, (object)value);
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgServerLogo")]
	internal virtual Image ImgServerLogo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabServerDesc")]
	internal virtual TextBlock LabServerDesc
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
	[field: AccessedThroughProperty("LabServerPlayer")]
	internal virtual TextBlock LabServerPlayer
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public MinecraftServer()
	{
		InitializeComponent();
	}

	private static void OnAddressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		MinecraftServer minecraftServer = (MinecraftServer)(object)d;
		((DispatcherObject)d).Dispatcher.BeginInvoke((System.Delegate)(VB_0024AnonymousDelegate_0<System.Threading.Tasks.Task>)([SpecialName] () => minecraftServer.UpdateServerInfoAsync(e.NewValue?.ToString())), new object[0]);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_8_UpdateServerInfoAsync))]
	public System.Threading.Tasks.Task UpdateServerInfoAsync(string address)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_8_UpdateServerInfoAsync vB_0024StateMachine_8_UpdateServerInfoAsync = default(VB_0024StateMachine_8_UpdateServerInfoAsync);
		vB_0024StateMachine_8_UpdateServerInfoAsync._0024VB_0024Me = this;
		vB_0024StateMachine_8_UpdateServerInfoAsync._0024VB_0024Local_address = address;
		vB_0024StateMachine_8_UpdateServerInfoAsync._0024State = -1;
		vB_0024StateMachine_8_UpdateServerInfoAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_8_UpdateServerInfoAsync._0024Builder.Start<VB_0024StateMachine_8_UpdateServerInfoAsync>(ref vB_0024StateMachine_8_UpdateServerInfoAsync);
		return vB_0024StateMachine_8_UpdateServerInfoAsync._0024Builder.Task;
	}

	private void UpdateServerStatus(McPingResult ret)
	{
		string text = ((ret.Latency < 150) ? "a" : ((ret.Latency < 400) ? "6" : "c"));
		LabServerDesc.Text = "Minecraft 服务器";
		MotdRenderer.RenderMotd(ret.Description, isDarkMode: false);
		MotdRenderer.RenderCanvas();
		ModStyle.MinecraftFormatter.SetColorfulTextLab(string.Format("{0}/{1}{2}§{3}{4}ms", new object[5]
		{
			ret.Players.Online,
			ret.Players.Max,
			"\r\n",
			text,
			ret.Latency
		}), LabServerPlayer, isDarkMode: false);
		List<McPingPlayerSampleResult> samples = ret.Players.Samples;
		if (samples != null && Enumerable.Any<McPingPlayerSampleResult>((System.Collections.Generic.IEnumerable<McPingPlayerSampleResult>)samples))
		{
			((FrameworkElement)LabServerPlayer).ToolTip = string.Join("\r\n", Enumerable.Select<McPingPlayerSampleResult, string>((System.Collections.Generic.IEnumerable<McPingPlayerSampleResult>)ret.Players.Samples, (Func<McPingPlayerSampleResult, string>)([SpecialName] (McPingPlayerSampleResult x) => x.Name)));
			ToolTipService.SetPlacement((DependencyObject)(object)LabServerPlayer, (PlacementMode)7);
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/minecraftserver.xaml", (UriKind)2);
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
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			ImgServerLogo = (Image)target;
			break;
		case 2:
			LabServerDesc = (TextBlock)target;
			break;
		case 3:
			MotdRenderer = (MotdRenderer)target;
			break;
		case 4:
			LabServerPlayer = (TextBlock)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
