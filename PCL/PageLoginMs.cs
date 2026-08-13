using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageLoginMs : StackPanel, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action _0024I1_002D0;

		public static Action _0024I2_002D2;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__1_002D0()
		{
			ModMain.FrmLaunchLeft.RefreshPage(Anim: true);
		}

		[SpecialName]
		internal void _Lambda_0024__2_002D2()
		{
			ModMain.FrmLaunchLeft.RefreshPage(Anim: true);
		}
	}

	[CompilerGenerated]
	[AccessedThroughProperty("BtnLogin")]
	private MyButton _BtnLogin;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnBack")]
	private MyTextButton _BtnBack;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanEmpty")]
	internal virtual Grid PanEmpty
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
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

	internal virtual MyTextButton BtnBack
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
			MyTextButton.ClickEventHandler obj = BtnBack_Click;
			MyTextButton btnBack = _BtnBack;
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

	public PageLoginMs()
	{
		InitializeComponent();
	}

	private void BtnBack_Click(object sender, EventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I1_002D0 != null)
		{
			action = _Closure_0024__._0024I1_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				ModMain.FrmLaunchLeft.RefreshPage(Anim: true);
			};
			_Closure_0024__._0024I1_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
	}

	private void BtnLogin_Click(object sender, EventArgs e)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		((UIElement)BtnLogin).IsEnabled = false;
		((UIElement)BtnBack).Visibility = (Visibility)2;
		BtnLogin.Text = "0%";
		ModBase.RunInNewThread((Action)([SpecialName] [CompilerGenerated] () =>
		{
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_00cd: Expected O, but got Unknown
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Expected O, but got Unknown
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			try
			{
				ModProfile.SelectedProfile = null;
				ModLaunch.McLoginMsLoader.Start(ModProfile.GetLoginData(ModLaunch.McLoginType.Ms), IsForceRestart: true);
				while (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Loading)
				{
					ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
					{
						BtnLogin.Text = Conversions.ToString(Math.Round(ModLaunch.McLoginMsLoader.Progress * 100.0)) + "%";
					}));
					Thread.Sleep(50);
				}
				if (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Finished)
				{
					object action;
					if (_Closure_0024__._0024I2_002D2 != null)
					{
						action = _Closure_0024__._0024I2_002D2;
					}
					else
					{
						Action val = [SpecialName] () =>
						{
							ModMain.FrmLaunchLeft.RefreshPage(Anim: true);
						};
						_Closure_0024__._0024I2_002D2 = val;
						action = (object)val;
					}
					ModBase.RunInUi((Action)action);
					return;
				}
				if (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Aborted)
				{
					throw new ThreadInterruptedException();
				}
				if (ModLaunch.McLoginMsLoader.Error == null)
				{
					throw new System.Exception("未知错误！");
				}
				throw new System.Exception(ModLaunch.McLoginMsLoader.Error.Message, ModLaunch.McLoginMsLoader.Error);
			}
			catch (ThreadInterruptedException val2)
			{
				ProjectData.SetProjectError((System.Exception)val2);
				ThreadInterruptedException val3 = val2;
				ModMain.Hint("已取消登录！");
				ProjectData.ClearProjectError();
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
					else if (ex2 is AuthenticationException && ModBase.ContainsF(ex2.Message, "SSL/TLS"))
					{
						ModBase.Log(ex2, "正版登录验证失败，请考虑在 [设置 → 其他] 中关闭 [在正版登录时验证 SSL 证书]，然后再试。\r\n\r\n原始错误信息：", ModBase.LogLevel.Msgbox);
					}
					else
					{
						ModBase.Log(ex2, "正版登录尝试失败", ModBase.LogLevel.Msgbox);
					}
				}
				ProjectData.ClearProjectError();
			}
			finally
			{
				ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
				{
					((UIElement)BtnLogin).IsEnabled = true;
					((UIElement)BtnBack).Visibility = (Visibility)0;
					BtnLogin.Text = "登录";
				}));
			}
		}), "Ms Login", (ThreadPriority)2);
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelaunch/pageloginms.xaml", (UriKind)2);
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
		switch (connectionId)
		{
		case 1:
			PanEmpty = (Grid)target;
			break;
		case 2:
			BtnLogin = (MyButton)target;
			break;
		case 3:
			BtnBack = (MyTextButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
