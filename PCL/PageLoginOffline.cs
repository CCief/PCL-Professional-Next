using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageLoginOffline : Grid, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action _0024I1_002D0;

		public static Action _0024I3_002D0;

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
		internal void _Lambda_0024__3_002D0()
		{
			ModMain.FrmLaunchLeft.RefreshPage(Anim: true);
		}
	}

	[CompilerGenerated]
	[AccessedThroughProperty("RadioUuidStandard")]
	private MyRadioBox _RadioUuidStandard;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioUuidLegacy")]
	private MyRadioBox _RadioUuidLegacy;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioUuidCustom")]
	private MyRadioBox _RadioUuidCustom;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnBack")]
	private MyButton _BtnBack;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnLogin")]
	private MyButton _BtnLogin;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextName")]
	internal virtual MyTextBox TextName
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyRadioBox RadioUuidStandard
	{
		[CompilerGenerated]
		get
		{
			return _RadioUuidStandard;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioCustomUuid_Checked();
			};
			MyRadioBox radioUuidStandard = _RadioUuidStandard;
			if (radioUuidStandard != null)
			{
				radioUuidStandard.Check -= obj;
			}
			_RadioUuidStandard = value;
			radioUuidStandard = _RadioUuidStandard;
			if (radioUuidStandard != null)
			{
				radioUuidStandard.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioUuidLegacy
	{
		[CompilerGenerated]
		get
		{
			return _RadioUuidLegacy;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioCustomUuid_Checked();
			};
			MyRadioBox radioUuidLegacy = _RadioUuidLegacy;
			if (radioUuidLegacy != null)
			{
				radioUuidLegacy.Check -= obj;
			}
			_RadioUuidLegacy = value;
			radioUuidLegacy = _RadioUuidLegacy;
			if (radioUuidLegacy != null)
			{
				radioUuidLegacy.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioUuidCustom
	{
		[CompilerGenerated]
		get
		{
			return _RadioUuidCustom;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioCustomUuid_Checked();
			};
			MyRadioBox radioUuidCustom = _RadioUuidCustom;
			if (radioUuidCustom != null)
			{
				radioUuidCustom.Check -= obj;
			}
			_RadioUuidCustom = value;
			radioUuidCustom = _RadioUuidCustom;
			if (radioUuidCustom != null)
			{
				radioUuidCustom.Check += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextUuidTitle")]
	internal virtual TextBlock TextUuidTitle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextUuid")]
	internal virtual MyTextBox TextUuid
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
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

	public PageLoginOffline()
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

	private void RadioCustomUuid_Checked()
	{
		if (RadioUuidCustom.Checked)
		{
			((UIElement)TextUuidTitle).Visibility = (Visibility)0;
			((UIElement)TextUuid).Visibility = (Visibility)0;
		}
		else
		{
			((UIElement)TextUuidTitle).Visibility = (Visibility)2;
			((UIElement)TextUuid).Visibility = (Visibility)2;
		}
	}

	private void BtnLogin_Click(object sender, EventArgs e)
	{
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		string text = ((TextBox)TextName).Text;
		if (Operators.CompareString(new ValidateRegex("^[A-z0-9_]{3,16}$").ValidateText(text), "", false) != 0 && ModMain.MyMsgBox(string.Format("你输入的玩家 ID 不符合标准（3 - 16 位，只可以包含英文字母、数字与下划线），可能导致部分版本的游戏无法启动或发生错误。{0}强烈建议使用规范的玩家 ID！{1}如果你坚持，仍然可以继续创建档案。", (object)"\r\n", (object)"\r\n"), "玩家 ID 不符合规范", "继续", "取消", "", IsWarn: true, HighLight: true, ForceWait: true) == 2)
		{
			return;
		}
		string text2 = null;
		if (!RadioUuidCustom.Checked)
		{
			text2 = ((!RadioUuidLegacy.Checked) ? ModProfile.GetOfflineUuid(text) : ModProfile.GetOfflineUuid(text, isSplited: false, isLegacy: true));
		}
		else
		{
			string text3 = ((TextBox)TextUuid).Text.Replace("-", "");
			string text4 = new ValidateRegex("^[a-fA-F0-9]{32}$").ValidateText(text3);
			if (RadioUuidCustom.Checked && Operators.CompareString(text4, "", false) != 0)
			{
				ModMain.Hint("UUID 不符合要求：" + text4, ModMain.HintType.Critical);
				return;
			}
			text2 = text3;
		}
		ModProfile.McProfile mcProfile = new ModProfile.McProfile
		{
			Type = ModLaunch.McLoginType.Legacy,
			Uuid = text2,
			Username = text,
			Desc = ""
		};
		ModProfile.ProfileList.Add(mcProfile);
		ModProfile.SaveProfile();
		ModProfile.SelectedProfile = mcProfile;
		ModProfile.IsCreatingProfile = false;
		ModMain.Hint("档案新建成功！", ModMain.HintType.Finish);
		object action;
		if (_Closure_0024__._0024I3_002D0 != null)
		{
			action = _Closure_0024__._0024I3_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				ModMain.FrmLaunchLeft.RefreshPage(Anim: true);
			};
			_Closure_0024__._0024I3_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelaunch/pageloginoffline.xaml", (UriKind)2);
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
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			TextName = (MyTextBox)target;
			break;
		case 2:
			RadioUuidStandard = (MyRadioBox)target;
			break;
		case 3:
			RadioUuidLegacy = (MyRadioBox)target;
			break;
		case 4:
			RadioUuidCustom = (MyRadioBox)target;
			break;
		case 5:
			TextUuidTitle = (TextBlock)target;
			break;
		case 6:
			TextUuid = (MyTextBox)target;
			break;
		case 7:
			BtnBack = (MyButton)target;
			break;
		case 8:
			BtnLogin = (MyButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
