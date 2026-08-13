using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Minecraft;
using PCL.Core.UI;

namespace PCL;

[DesignerGenerated]
public class PageSetupJava : MyPageRight, IComponentConnector
{
	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_8_BtnAdd_Click : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal ModBase.RouteEventArgs _0024VB_0024Local_e;

		internal PageSetupJava _0024VB_0024Me;

		internal _Closure_0024__8_002D0 _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Expected O, but got Unknown
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num == 0)
				{
					num = (_0024State = -1);
					val = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_00e9;
				}
				_0024VB_0024ResumableLocal__0024VB_0024Closure__00240 = new _Closure_0024__8_002D0();
				_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_ret = SystemDialogs.SelectFile("Java 程序(java.exe)|java.exe", "选择 Java 程序");
				if (!string.IsNullOrEmpty(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_ret) && File.Exists(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_ret))
				{
					if (!JavaService.JavaManager.HasJava(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_ret))
					{
						val = System.Threading.Tasks.Task.Run((Action)([SpecialName] () =>
						{
							JavaService.JavaManager.Add(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_ret);
						})).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_8_BtnAdd_Click>(ref val, ref _this);
							return;
						}
						goto IL_00e9;
					}
					ModMain.Hint("Java 已经存在，不用再次添加……");
				}
				goto end_IL_0007;
				IL_00e9:
				val.GetResult();
				val = default(TaskAwaiter);
				if (JavaService.JavaManager.HasJava(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_ret))
				{
					ModMain.Hint("已添加 Java！", ModMain.HintType.Finish);
					_0024VB_0024Me.JavaPageLoader.Start(true, IsForceRestart: true);
				}
				else
				{
					ModMain.Hint("未能成功将 Java 加入列表中", ModMain.HintType.Critical);
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

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D0
	{
		public JavaInfo _0024VB_0024Local_J;

		public string _0024VB_0024Local_VersionTypeDesc;

		public string _0024VB_0024Local_DisplayBits;

		public string _0024VB_0024Local_DisplayBrand;

		public MyListItem _0024VB_0024Local_Item;

		public MyIconButton _0024VB_0024Local_BtnEnableSwitch;

		public VB_0024AnonymousDelegate_23<bool> _0024VB_0024Local_UpdateEnableStyle;

		public Func<JavaInfo, bool> _0024I6;

		public _Closure_0024__6_002D0(_Closure_0024__6_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_J = arg0._0024VB_0024Local_J;
				_0024VB_0024Local_VersionTypeDesc = arg0._0024VB_0024Local_VersionTypeDesc;
				_0024VB_0024Local_DisplayBits = arg0._0024VB_0024Local_DisplayBits;
				_0024VB_0024Local_DisplayBrand = arg0._0024VB_0024Local_DisplayBrand;
				_0024VB_0024Local_Item = arg0._0024VB_0024Local_Item;
				_0024VB_0024Local_BtnEnableSwitch = arg0._0024VB_0024Local_BtnEnableSwitch;
				_0024VB_0024Local_UpdateEnableStyle = arg0._0024VB_0024Local_UpdateEnableStyle;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1(object sender, ModBase.RouteEventArgs e)
		{
			if (_0024VB_0024Local_J.IsEnabled)
			{
				ModBase.Setup.Set("LaunchArgumentJavaSelect", _0024VB_0024Local_J.JavaExePath);
				return;
			}
			ModMain.Hint("请先启用此 Java 后再选择其作为默认 Java");
			e.Handled = true;
		}

		[SpecialName]
		internal void _Lambda_0024__R2(object a0, EventArgs a1)
		{
			_Lambda_0024__2();
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			ModBase.OpenExplorer(_0024VB_0024Local_J.JavaFolder);
		}

		[SpecialName]
		internal void _Lambda_0024__R3(object a0, EventArgs a1)
		{
			_Lambda_0024__3();
		}

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			ModMain.MyMsgBox(string.Concat(new string[9]
			{
				$"类型: {_0024VB_0024Local_VersionTypeDesc}",
				"\r\n",
				$"版本: {_0024VB_0024Local_J.Version.ToString()}",
				"\r\n",
				$"架构: {((System.Enum)_0024VB_0024Local_J.JavaArch).ToString()} ({_0024VB_0024Local_DisplayBits})",
				"\r\n",
				$"品牌: {_0024VB_0024Local_DisplayBrand}",
				"\r\n",
				$"位置: {_0024VB_0024Local_J.JavaFolder}"
			}), "Java 信息");
		}

		[SpecialName]
		internal void _Lambda_0024__4(bool IsCurEnable)
		{
			if (IsCurEnable)
			{
				_0024VB_0024Local_Item.LabTitle.TextDecorations = null;
				_0024VB_0024Local_Item.LabTitle.Foreground = (Brush)(object)ModSecret.DynamicColors.Color1Brush;
				_0024VB_0024Local_BtnEnableSwitch.Logo = "M508 990.4c-261.6 0-474.4-212-474.4-474.4S246.4 41.6 508 41.6s474.4 212 474.4 474.4S769.6 990.4 508 990.4zM508 136.8c-209.6 0-379.2 169.6-379.2 379.2 0 209.6 169.6 379.2 379.2 379.2s379.2-169.6 379.2-379.2C887.2 306.4 717.6 136.8 508 136.8zM697.6 563.2 318.4 563.2c-26.4 0-47.2-21.6-47.2-47.2 0-26.4 21.6-47.2 47.2-47.2l379.2 0c26.4 0 47.2 21.6 47.2 47.2C744.8 542.4 724 563.2 697.6 563.2z";
				((FrameworkElement)_0024VB_0024Local_BtnEnableSwitch).ToolTip = "禁用此 Java";
			}
			else
			{
				_0024VB_0024Local_Item.LabTitle.TextDecorations = TextDecorations.Strikethrough;
				_0024VB_0024Local_Item.LabTitle.Foreground = ModSecret.ColorGray4;
				_0024VB_0024Local_BtnEnableSwitch.Logo = "M512 0a512 512 0 1 0 512 512A512 512 0 0 0 512 0z m0 921.6a409.6 409.6 0 1 1 409.6-409.6 409.6 409.6 0 0 1-409.6 409.6z M716.8 339.968l-256 253.44L328.192 460.8A51.2 51.2 0 0 0 256 532.992l168.448 168.96a51.2 51.2 0 0 0 72.704 0l289.28-289.792A51.2 51.2 0 0 0 716.8 339.968z";
				((FrameworkElement)_0024VB_0024Local_BtnEnableSwitch).ToolTip = "启用此 Java";
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R4(object a0, EventArgs a1)
		{
			_Lambda_0024__5();
		}

		[SpecialName]
		internal void _Lambda_0024__5()
		{
			try
			{
				JavaInfo javaInfo = Enumerable.First<JavaInfo>(Enumerable.Where<JavaInfo>((System.Collections.Generic.IEnumerable<JavaInfo>)ModJava.Javas.JavaList, (Func<JavaInfo, bool>)([SpecialName] (JavaInfo x) => Operators.CompareString(x.JavaExePath, _0024VB_0024Local_J.JavaExePath, false) == 0)));
				if (javaInfo.IsEnabled && Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("LaunchArgumentJavaSelect"), (object)javaInfo.JavaExePath, false))
				{
					ModMain.Hint("请先取消选择此 Java 作为默认 Java 后再禁用");
					return;
				}
				javaInfo.IsEnabled = !javaInfo.IsEnabled;
				_0024VB_0024Local_UpdateEnableStyle(javaInfo.IsEnabled);
				JavaService.SaveToConfig();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "调整 Java 启用状态失败", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__6(JavaInfo x)
		{
			return Operators.CompareString(x.JavaExePath, _0024VB_0024Local_J.JavaExePath, false) == 0;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__8_002D0
	{
		public string _0024VB_0024Local_ret;

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			JavaService.JavaManager.Add(_0024VB_0024Local_ret);
		}
	}

	private bool IsLoad;

	private ModLoader.LoaderTask<bool, List<JavaInfo>> JavaPageLoader;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnAdd")]
	private MyIconTextButton _BtnAdd;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnRefresh")]
	private MyIconTextButton _BtnRefresh;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual MyScrollViewer PanBack
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

	internal virtual MyIconTextButton BtnAdd
	{
		[CompilerGenerated]
		get
		{
			return _BtnAdd;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnAdd_Click(RuntimeHelpers.GetObjectValue(a0), a1);
			};
			MyIconTextButton btnAdd = _BtnAdd;
			if (btnAdd != null)
			{
				btnAdd.Click -= obj;
			}
			_BtnAdd = value;
			btnAdd = _BtnAdd;
			if (btnAdd != null)
			{
				btnAdd.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnRefresh
	{
		[CompilerGenerated]
		get
		{
			return _BtnRefresh;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnRefresh_Click;
			MyIconTextButton btnRefresh = _BtnRefresh;
			if (btnRefresh != null)
			{
				btnRefresh.Click -= obj;
			}
			_BtnRefresh = value;
			btnRefresh = _BtnRefresh;
			if (btnRefresh != null)
			{
				btnRefresh.Click += obj;
			}
		}
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
	[field: AccessedThroughProperty("CardLoad")]
	internal virtual MyCard CardLoad
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLoad")]
	internal virtual MyLoading PanLoad
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageSetupJava()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageSetupLaunch_Loaded);
		IsLoad = false;
		JavaPageLoader = new ModLoader.LoaderTask<bool, List<JavaInfo>>("JavaPageLoader", Load_GetJavaList, null, (ThreadPriority)2);
		InitializeComponent();
	}

	private void PageSetupLaunch_Loaded(object sender, RoutedEventArgs e)
	{
		PageLoaderInit(PanLoad, (FrameworkElement)(object)CardLoad, (FrameworkElement)(object)PanMain, null, JavaPageLoader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
		{
			OnLoadFinished();
		}, Load_Input);
	}

	private object Load_Input()
	{
		return false;
	}

	private void Load_GetJavaList(ModLoader.LoaderTask<bool, List<JavaInfo>> loader)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if (loader.Input)
		{
			TaskAwaiter awaiter = JavaService.JavaManager.ScanJavaAsync().GetAwaiter();
			awaiter.GetResult();
		}
		loader.Output = ModJava.Javas.JavaList;
	}

	private void OnLoadFinished()
	{
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		VB_0024AnonymousDelegate_12<JavaInfo, MyListItem> vB_0024AnonymousDelegate_ = [SpecialName] (JavaInfo J) =>
		{
			_Closure_0024__6_002D0 arg = default(_Closure_0024__6_002D0);
			_Closure_0024__6_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__6_002D0(null);
			CS_0024_003C_003E8__locals0._0024VB_0024Local_J = J;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Item = new MyListItem();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionTypeDesc = (CS_0024_003C_003E8__locals0._0024VB_0024Local_J.IsJre ? "JRE" : "JDK");
			string text = CS_0024_003C_003E8__locals0._0024VB_0024Local_J.JavaMajorVersion.ToString();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Item.Title = $"{CS_0024_003C_003E8__locals0._0024VB_0024Local_VersionTypeDesc} {text}";
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Item.Info = CS_0024_003C_003E8__locals0._0024VB_0024Local_J.JavaFolder;
			List<string> val = new List<string>();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_DisplayBits = (CS_0024_003C_003E8__locals0._0024VB_0024Local_J.Is64Bit ? "64 Bit" : "32 Bit");
			val.Add(CS_0024_003C_003E8__locals0._0024VB_0024Local_DisplayBits);
			CS_0024_003C_003E8__locals0._0024VB_0024Local_DisplayBrand = ((System.Enum)CS_0024_003C_003E8__locals0._0024VB_0024Local_J.Brand).ToString();
			val.Add(CS_0024_003C_003E8__locals0._0024VB_0024Local_DisplayBrand);
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Item.Tags = val;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Item.Type = MyListItem.CheckType.RadioBox;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Item.Check += [SpecialName] (object sender, ModBase.RouteEventArgs e) =>
			{
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_J.IsEnabled)
				{
					ModBase.Setup.Set("LaunchArgumentJavaSelect", CS_0024_003C_003E8__locals0._0024VB_0024Local_J.JavaExePath);
				}
				else
				{
					ModMain.Hint("请先启用此 Java 后再选择其作为默认 Java");
					e.Handled = true;
				}
			};
			MyIconButton myIconButton = new MyIconButton
			{
				Logo = "M889.018182 418.909091H884.363636V316.509091a93.090909 93.090909 0 0 0-99.607272-89.832727h-302.545455l-93.090909-76.334546A46.545455 46.545455 0 0 0 358.865455 139.636364H146.152727A93.090909 93.090909 0 0 0 46.545455 229.469091V837.818182a46.545455 46.545455 0 0 0 46.545454 46.545454 46.545455 46.545455 0 0 0 16.756364-3.258181 109.381818 109.381818 0 0 0 25.134545 3.258181h586.472727a85.178182 85.178182 0 0 0 87.04-63.301818l163.374546-302.545454a46.545455 46.545455 0 0 0 5.585454-21.876364A82.385455 82.385455 0 0 0 889.018182 418.909091z m-744.727273-186.181818h198.283636l93.09091 76.334545a46.545455 46.545455 0 0 0 29.323636 10.705455h319.301818a12.101818 12.101818 0 0 1 6.516364 0V418.909091H302.545455a85.178182 85.178182 0 0 0-87.04 63.301818L139.636364 622.778182V232.727273a19.549091 19.549091 0 0 1 6.516363 0z m578.094546 552.029091a27.461818 27.461818 0 0 0-2.792728 6.516363H154.530909l147.083636-272.290909a27.461818 27.461818 0 0 0 2.792728-6.981818h565.061818z"
			};
			((FrameworkElement)myIconButton).ToolTip = "打开";
			myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__2();
			};
			MyIconButton myIconButton2 = new MyIconButton
			{
				Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
			};
			((FrameworkElement)myIconButton2).ToolTip = "详细信息";
			myIconButton2.Click += [SpecialName] (object a0, EventArgs a1) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__3();
			};
			CS_0024_003C_003E8__locals0._0024VB_0024Local_BtnEnableSwitch = new MyIconButton();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Item.Buttons = new MyIconButton[] { myIconButton, myIconButton2, CS_0024_003C_003E8__locals0._0024VB_0024Local_BtnEnableSwitch };
			CS_0024_003C_003E8__locals0._0024VB_0024Local_UpdateEnableStyle = [SpecialName] (bool IsCurEnable) =>
			{
				if (IsCurEnable)
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Item.LabTitle.TextDecorations = null;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Item.LabTitle.Foreground = (Brush)(object)ModSecret.DynamicColors.Color1Brush;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_BtnEnableSwitch.Logo = "M508 990.4c-261.6 0-474.4-212-474.4-474.4S246.4 41.6 508 41.6s474.4 212 474.4 474.4S769.6 990.4 508 990.4zM508 136.8c-209.6 0-379.2 169.6-379.2 379.2 0 209.6 169.6 379.2 379.2 379.2s379.2-169.6 379.2-379.2C887.2 306.4 717.6 136.8 508 136.8zM697.6 563.2 318.4 563.2c-26.4 0-47.2-21.6-47.2-47.2 0-26.4 21.6-47.2 47.2-47.2l379.2 0c26.4 0 47.2 21.6 47.2 47.2C744.8 542.4 724 563.2 697.6 563.2z";
					((FrameworkElement)CS_0024_003C_003E8__locals0._0024VB_0024Local_BtnEnableSwitch).ToolTip = "禁用此 Java";
				}
				else
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Item.LabTitle.TextDecorations = TextDecorations.Strikethrough;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Item.LabTitle.Foreground = ModSecret.ColorGray4;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_BtnEnableSwitch.Logo = "M512 0a512 512 0 1 0 512 512A512 512 0 0 0 512 0z m0 921.6a409.6 409.6 0 1 1 409.6-409.6 409.6 409.6 0 0 1-409.6 409.6z M716.8 339.968l-256 253.44L328.192 460.8A51.2 51.2 0 0 0 256 532.992l168.448 168.96a51.2 51.2 0 0 0 72.704 0l289.28-289.792A51.2 51.2 0 0 0 716.8 339.968z";
					((FrameworkElement)CS_0024_003C_003E8__locals0._0024VB_0024Local_BtnEnableSwitch).ToolTip = "启用此 Java";
				}
			};
			CS_0024_003C_003E8__locals0._0024VB_0024Local_BtnEnableSwitch.Click += [SpecialName] (object a0, EventArgs a1) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__5();
			};
			CS_0024_003C_003E8__locals0._0024VB_0024Local_UpdateEnableStyle(CS_0024_003C_003E8__locals0._0024VB_0024Local_J.IsEnabled);
			return CS_0024_003C_003E8__locals0._0024VB_0024Local_Item;
		};
		((Panel)PanContent).Children.Clear();
		MyListItem myListItem = new MyListItem
		{
			Type = MyListItem.CheckType.RadioBox,
			Title = "自动选择",
			Info = "Java 选择自动挡，依据游戏需要自动选择合适的 Java"
		};
		myListItem.Check += [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
		{
			((VB_0024AnonymousDelegate_8)([SpecialName] () =>
			{
				ModBase.Setup.Set("LaunchArgumentJavaSelect", "");
			}))();
		};
		((Panel)PanContent).Children.Add((UIElement)(object)myListItem);
		object objectValue = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LaunchArgumentJavaSelect"));
		System.Collections.Generic.IEnumerator<JavaInfo> enumerator = default(System.Collections.Generic.IEnumerator<JavaInfo>);
		try
		{
			enumerator = ModJava.Javas.JavaList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				JavaInfo current = enumerator.Current;
				MyListItem myListItem2 = vB_0024AnonymousDelegate_(current);
				((Panel)PanContent).Children.Add((UIElement)(object)myListItem2);
				if (Operators.ConditionalCompareObjectEqual((object)current.JavaExePath, objectValue, false))
				{
					myListItem2.SetChecked(value: true, user: false, anime: false);
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		if (string.IsNullOrEmpty(Conversions.ToString(objectValue)))
		{
			myListItem.SetChecked(value: true, user: false, anime: false);
		}
	}

	private void BtnRefresh_Click(object sender, ModBase.RouteEventArgs e)
	{
		JavaPageLoader.Start(true, IsForceRestart: true);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_8_BtnAdd_Click))]
	private System.Threading.Tasks.Task BtnAdd_Click(object sender, ModBase.RouteEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_8_BtnAdd_Click vB_0024StateMachine_8_BtnAdd_Click = default(VB_0024StateMachine_8_BtnAdd_Click);
		vB_0024StateMachine_8_BtnAdd_Click._0024VB_0024Me = this;
		vB_0024StateMachine_8_BtnAdd_Click._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_8_BtnAdd_Click._0024VB_0024Local_e = e;
		vB_0024StateMachine_8_BtnAdd_Click._0024State = -1;
		vB_0024StateMachine_8_BtnAdd_Click._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_8_BtnAdd_Click._0024Builder.Start<VB_0024StateMachine_8_BtnAdd_Click>(ref vB_0024StateMachine_8_BtnAdd_Click);
		return vB_0024StateMachine_8_BtnAdd_Click._0024Builder.Task;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagesetup/pagesetupjava.xaml", (UriKind)2);
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
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanMain = (StackPanel)target;
			break;
		case 3:
			BtnAdd = (MyIconTextButton)target;
			break;
		case 4:
			BtnRefresh = (MyIconTextButton)target;
			break;
		case 5:
			PanContent = (StackPanel)target;
			break;
		case 6:
			CardLoad = (MyCard)target;
			break;
		case 7:
			PanLoad = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
