using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class MinecraftServerQuery : Grid, IComponentConnector
{
	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_1_BtnServerQuery_Click : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal MouseButtonEventArgs _0024VB_0024Local_e;

		internal MinecraftServerQuery _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num != 0)
				{
					val = _0024VB_0024Me.PanMcServer.UpdateServerInfoAsync(((TextBox)_0024VB_0024Me.LabServerIp).Text).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_1_BtnServerQuery_Click>(ref val, ref _this);
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
				((UIElement)_0024VB_0024Me.ServerInfo).Visibility = (Visibility)0;
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
	[AccessedThroughProperty("BtnServerQuery")]
	private MyButton _BtnServerQuery;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabServerIp")]
	internal virtual MyTextBox LabServerIp
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnServerQuery
	{
		[CompilerGenerated]
		get
		{
			return _BtnServerQuery;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnServerQuery_Click(RuntimeHelpers.GetObjectValue(a0), a1);
			};
			MyButton btnServerQuery = _BtnServerQuery;
			if (btnServerQuery != null)
			{
				btnServerQuery.Click -= obj;
			}
			_BtnServerQuery = value;
			btnServerQuery = _BtnServerQuery;
			if (btnServerQuery != null)
			{
				btnServerQuery.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ServerInfo")]
	internal virtual Border ServerInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanMcServer")]
	internal virtual MinecraftServer PanMcServer
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public MinecraftServerQuery()
	{
		InitializeComponent();
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_1_BtnServerQuery_Click))]
	private System.Threading.Tasks.Task BtnServerQuery_Click(object sender, MouseButtonEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_1_BtnServerQuery_Click vB_0024StateMachine_1_BtnServerQuery_Click = default(VB_0024StateMachine_1_BtnServerQuery_Click);
		vB_0024StateMachine_1_BtnServerQuery_Click._0024VB_0024Me = this;
		vB_0024StateMachine_1_BtnServerQuery_Click._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_1_BtnServerQuery_Click._0024VB_0024Local_e = e;
		vB_0024StateMachine_1_BtnServerQuery_Click._0024State = -1;
		vB_0024StateMachine_1_BtnServerQuery_Click._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_1_BtnServerQuery_Click._0024Builder.Start<VB_0024StateMachine_1_BtnServerQuery_Click>(ref vB_0024StateMachine_1_BtnServerQuery_Click);
		return vB_0024StateMachine_1_BtnServerQuery_Click._0024Builder.Task;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/minecraftserverquery.xaml", (UriKind)2);
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
		switch (connectionId)
		{
		case 1:
			LabServerIp = (MyTextBox)target;
			break;
		case 2:
			BtnServerQuery = (MyButton)target;
			break;
		case 3:
			ServerInfo = (Border)target;
			break;
		case 4:
			PanMcServer = (MinecraftServer)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
