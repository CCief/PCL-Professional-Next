using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageLoginProfileSkin : Grid, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action _0024I9_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__9_002D0()
		{
			ModMain.FrmLaunchLeft.RefreshPage(Anim: true);
			((UIElement)ModMain.FrmLaunchLeft.BtnLaunch).IsEnabled = false;
		}
	}

	[CompilerGenerated]
	[AccessedThroughProperty("PanData")]
	private Grid _PanData;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSkin")]
	private MyIconButton _BtnSkin;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnEdit")]
	private MyIconButton _BtnEdit;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSelect")]
	private MyIconButton _BtnSelect;

	private bool _contentLoaded;

	internal virtual Grid PanData
	{
		[CompilerGenerated]
		get
		{
			return _PanData;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(ShowPanel);
			MouseEventHandler val2 = (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
			{
				HidePanel();
			});
			Grid panData = _PanData;
			if (panData != null)
			{
				((UIElement)panData).MouseEnter -= val;
				((UIElement)panData).MouseLeave -= val2;
			}
			_PanData = value;
			panData = _PanData;
			if (panData != null)
			{
				((UIElement)panData).MouseEnter += val;
				((UIElement)panData).MouseLeave += val2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("Skin")]
	internal virtual MySkin Skin
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextName")]
	internal virtual TextBlock TextName
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextType")]
	internal virtual TextBlock TextType
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanButtons")]
	internal virtual Border PanButtons
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconButton BtnSkin
	{
		[CompilerGenerated]
		get
		{
			return _BtnSkin;
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
			MyIconButton btnSkin = _BtnSkin;
			if (btnSkin != null)
			{
				btnSkin.Click -= obj;
			}
			_BtnSkin = value;
			btnSkin = _BtnSkin;
			if (btnSkin != null)
			{
				btnSkin.Click += obj;
			}
		}
	}

	internal virtual MyIconButton BtnEdit
	{
		[CompilerGenerated]
		get
		{
			return _BtnEdit;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = BtnEdit_Click;
			MyIconButton btnEdit = _BtnEdit;
			if (btnEdit != null)
			{
				btnEdit.Click -= obj;
			}
			_BtnEdit = value;
			btnEdit = _BtnEdit;
			if (btnEdit != null)
			{
				btnEdit.Click += obj;
			}
		}
	}

	internal virtual MyIconButton BtnSelect
	{
		[CompilerGenerated]
		get
		{
			return _BtnSelect;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = ChangeProfile;
			MyIconButton btnSelect = _BtnSelect;
			if (btnSelect != null)
			{
				btnSelect.Click -= obj;
			}
			_BtnSelect = value;
			btnSelect = _BtnSelect;
			if (btnSelect != null)
			{
				btnSelect.Click += obj;
			}
		}
	}

	public PageLoginProfileSkin()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Reload();
		});
		InitializeComponent();
	}

	public void Reload()
	{
		ModBase.Log("[Profile] 刷新档案界面");
		Skin.Clear();
		if (ModProfile.SelectedProfile.Type == ModLaunch.McLoginType.Ms)
		{
			((UIElement)BtnEdit).Visibility = (Visibility)0;
			ModBase.Log("[Profile] 使用正版皮肤加载器");
			Skin.Loader = PageLaunchLeft.SkinMs;
		}
		else if (ModProfile.SelectedProfile.Type == ModLaunch.McLoginType.Auth)
		{
			((UIElement)BtnEdit).Visibility = (Visibility)0;
			ModBase.Log("[Profile] 使用 Authlib 皮肤加载器");
			Skin.Loader = PageLaunchLeft.SkinAuth;
		}
		else
		{
			((UIElement)BtnEdit).Visibility = (Visibility)2;
			ModBase.Log("[Profile] 使用离线皮肤加载器");
			Skin.Loader = PageLaunchLeft.SkinLegacy;
		}
		Skin.Loader.Start(null, IsForceRestart: true);
		TextName.Text = ModProfile.SelectedProfile.Username;
		TextType.Text = Conversions.ToString(ModProfile.GetProfileInfo(ModProfile.SelectedProfile));
	}

	private void ShowPanel(object sender, MouseEventArgs e)
	{
		ModAnimation.AniStart(ModAnimation.AaOpacity(PanButtons, 1.0 - ((UIElement)PanButtons).Opacity, 120), "PageLoginProfileSkin Button");
	}

	private void HidePanel()
	{
		if (!((FrameworkElement)BtnEdit).ContextMenu.IsOpen && !((FrameworkElement)BtnSkin).ContextMenu.IsOpen && !((UIElement)PanData).IsMouseOver)
		{
			ModAnimation.AniStart(ModAnimation.AaOpacity(PanButtons, 0.0 - ((UIElement)PanButtons).Opacity, 120), "PageLoginProfileSkin Button");
		}
	}

	private void MenuAccountOptions_Closed(object sender, RoutedEventArgs e)
	{
		HidePanel();
	}

	private void BtnSkin_Click(object sender, RoutedEventArgs e)
	{
		((FrameworkElement)BtnSkin).ContextMenu.IsOpen = true;
	}

	private void BtnEdit_Click(object sender, EventArgs e)
	{
		((FrameworkElement)BtnEdit).ContextMenu.IsOpen = true;
	}

	private void BtnEditPassword_Click(object sender, RoutedEventArgs e)
	{
		if (ModProfile.SelectedProfile.Type == ModLaunch.McLoginType.Ms)
		{
			ModBase.OpenWebsite("https://account.live.com/password/Change");
		}
		else if (ModProfile.SelectedProfile.Type == ModLaunch.McLoginType.Auth)
		{
			string server = ModProfile.SelectedProfile.Server;
			ModBase.OpenWebsite(server.ToString().Replace("/api/yggdrasil/authserver" + (ModBase.EndsWithF(server, "/") ? "/" : ""), "/user/profile"));
		}
		else
		{
			ModMain.Hint("当前档案不支持修改密码！");
		}
	}

	private void BtnEditName_Click(object sender, RoutedEventArgs e)
	{
		ModProfile.EditProfileId();
	}

	private void ChangeProfile(object sender, EventArgs e)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		ModProfile.SelectedProfile = null;
		object action;
		if (_Closure_0024__._0024I9_002D0 != null)
		{
			action = _Closure_0024__._0024I9_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				ModMain.FrmLaunchLeft.RefreshPage(Anim: true);
				((UIElement)ModMain.FrmLaunchLeft.BtnLaunch).IsEnabled = false;
			};
			_Closure_0024__._0024I9_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
	}

	private void Skin_Click(object sender, RoutedEventArgs e)
	{
		if (ModProfile.SelectedProfile.Type == ModLaunch.McLoginType.Ms)
		{
			ModProfile.ChangeSkinMs();
		}
		else if (ModProfile.SelectedProfile.Type == ModLaunch.McLoginType.Auth)
		{
			ModBase.OpenWebsite(ModBase.BeforeFirst(ModProfile.SelectedProfile.Server, "api/yggdrasil/authserver") + "user/closet");
		}
		else
		{
			ModMain.Hint("当前档案不支持修改皮肤！");
		}
	}

	private void BtnSkinSave_Click(object sender, RoutedEventArgs e)
	{
		Skin.BtnSkinSave_Click();
	}

	private void BtnSkinRefresh_Click(object sender, RoutedEventArgs e)
	{
		Skin.RefreshClick();
	}

	private void BtnSkinCape_Click(object sender, RoutedEventArgs e)
	{
		if (ModProfile.SelectedProfile.Type == ModLaunch.McLoginType.Ms)
		{
			Skin.BtnSkinCape_Click();
		}
		else if (ModProfile.SelectedProfile.Type == ModLaunch.McLoginType.Auth)
		{
			ModBase.OpenWebsite(ModBase.BeforeFirst(ModProfile.SelectedProfile.Server, "api/yggdrasil/authserver") + "user/closet");
		}
		else
		{
			ModMain.Hint("当前档案不支持修改披风！");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelaunch/pageloginprofileskin.xaml", (UriKind)2);
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanData = (Grid)target;
			break;
		case 2:
			Skin = (MySkin)target;
			break;
		case 3:
			TextName = (TextBlock)target;
			break;
		case 4:
			TextType = (TextBlock)target;
			break;
		case 5:
			PanButtons = (Border)target;
			break;
		case 6:
			BtnSkin = (MyIconButton)target;
			break;
		case 7:
			((ContextMenu)target).Closed += new RoutedEventHandler(MenuAccountOptions_Closed);
			break;
		case 8:
			BtnEdit = (MyIconButton)target;
			break;
		case 9:
			((ContextMenu)target).Closed += new RoutedEventHandler(MenuAccountOptions_Closed);
			break;
		case 10:
			BtnSelect = (MyIconButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
