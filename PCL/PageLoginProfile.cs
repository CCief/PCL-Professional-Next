using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageLoginProfile : Grid, IComponentConnector
{
	public class ProfileItem
	{
		[field: CompilerGenerated]
		public string Info
		{
			[CompilerGenerated]
			get;
		}

		[field: CompilerGenerated]
		public string Logo
		{
			[CompilerGenerated]
			get;
		}

		[field: CompilerGenerated]
		public ModProfile.McProfile Profile
		{
			[CompilerGenerated]
			get;
		}

		public string Username => Profile.Username;

		public ProfileItem(ModProfile.McProfile profile)
		{
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			Profile = profile;
			Info = Conversions.ToString(ModProfile.GetProfileInfo(profile));
			string text = ModBase.PathTemp + $"Cache\\Skin\\Head\\{profile.SkinHeadId}.png";
			if (!File.Exists(text) || new FileInfo(text).Length == 0L)
			{
				text = "M660.338 528.065c63.61-46.825 105.131-121.964 105.131-206.83 0-141.7-115.29-256.987-256.997-256.987-141.706 0-256.998 115.288-256.998 256.987 0 85.901 42.52 161.887 107.456 208.562-152.1 59.92-260.185 207.961-260.185 381.077 0 21.276 17.253 38.53 38.53 38.53 21.278 0 38.53-17.254 38.53-38.53 0-183.426 149.232-332.671 332.667-332.671 1.589 0 3.113-0.207 4.694-0.244 0.8 0.056 1.553 0.244 2.362 0.244 183.434 0 332.664 149.245 332.664 332.671 0 21.276 17.255 38.53 38.533 38.53 21.277 0 38.53-17.254 38.53-38.53 0-174.885-110.354-324.13-264.917-382.809z m-331.803-206.83c0-99.22 80.72-179.927 179.935-179.927s179.937 80.708 179.937 179.927c0 99.203-80.721 179.91-179.937 179.91s-179.935-80.708-179.935-179.91z";
			}
			Logo = text;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action _0024I8_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__8_002D0()
		{
			ModMain.FrmLaunchLeft.RefreshPage(Anim: true);
			((UIElement)ModMain.FrmLaunchLeft.BtnLaunch).IsEnabled = true;
		}
	}

	[CompilerGenerated]
	[AccessedThroughProperty("BtnNew")]
	private MyIconButton _BtnNew;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnPort")]
	private MyIconButton _BtnPort;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	public ObservableCollection<ProfileItem> ProfileCollection
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintSelect")]
	internal virtual MyHint HintSelect
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintCreate")]
	internal virtual MyHint HintCreate
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

	internal virtual MyIconButton BtnNew
	{
		[CompilerGenerated]
		get
		{
			return _BtnNew;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = BtnNew_Click;
			MyIconButton btnNew = _BtnNew;
			if (btnNew != null)
			{
				btnNew.Click -= obj;
			}
			_BtnNew = value;
			btnNew = _BtnNew;
			if (btnNew != null)
			{
				btnNew.Click += obj;
			}
		}
	}

	internal virtual MyIconButton BtnPort
	{
		[CompilerGenerated]
		get
		{
			return _BtnPort;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				BtnPort_Click();
			};
			MyIconButton btnPort = _BtnPort;
			if (btnPort != null)
			{
				btnPort.Click -= obj;
			}
			_BtnPort = value;
			btnPort = _BtnPort;
			if (btnPort != null)
			{
				btnPort.Click += obj;
			}
		}
	}

	public PageLoginProfile()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Reload();
		});
		ProfileCollection = new ObservableCollection<ProfileItem>();
		InitializeComponent();
	}

	public void Reload()
	{
		RefreshProfileList();
		ModMain.FrmLoginProfileSkin = null;
	}

	public void RefreshProfileList()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		ModBase.Log("[Profile] 刷新档案列表");
		((Collection<ProfileItem>)(object)ProfileCollection).Clear();
		ModProfile.GetProfile();
		try
		{
			System.Collections.Generic.IEnumerator<ModProfile.McProfile> enumerator = default(System.Collections.Generic.IEnumerator<ModProfile.McProfile>);
			try
			{
				enumerator = ModProfile.ProfileList.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModProfile.McProfile current = enumerator.Current;
					((Collection<ProfileItem>)(object)ProfileCollection).Add(new ProfileItem(current));
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			ModBase.Log("[Profile] 档案列表刷新完成");
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "读取档案列表失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
		if (!Enumerable.Any<ModProfile.McProfile>((System.Collections.Generic.IEnumerable<ModProfile.McProfile>)ModProfile.ProfileList))
		{
			ModBase.Setup.Set("HintProfileSelect", true);
			((UIElement)HintCreate).Visibility = (Visibility)0;
		}
		else
		{
			((UIElement)HintCreate).Visibility = (Visibility)2;
		}
	}

	private void SelectProfile(object sender, MouseButtonEventArgs e)
	{
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		ModProfile.SelectedProfile = (ModProfile.McProfile)((FrameworkElement)(MyListItem)sender).Tag;
		ModBase.Log(string.Format("[Profile] 选定档案: {0}, 以 {1} 方式验证", RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Username", new object[0], (string[])null, (System.Type[])null, (bool[])null)), RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Type", new object[0], (string[])null, (System.Type[])null, (bool[])null))));
		ModProfile.LastUsedProfile = ModProfile.ProfileList.IndexOf((ModProfile.McProfile)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null));
		ModProfile.SaveProfile();
		ModLaunch.McLoginMsLoader.State = ModBase.LoadState.Waiting;
		ModLaunch.McLoginAuthLoader.State = ModBase.LoadState.Waiting;
		ModLaunch.McLoginLegacyLoader.State = ModBase.LoadState.Waiting;
		object action;
		if (_Closure_0024__._0024I8_002D0 != null)
		{
			action = _Closure_0024__._0024I8_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				ModMain.FrmLaunchLeft.RefreshPage(Anim: true);
				((UIElement)ModMain.FrmLaunchLeft.BtnLaunch).IsEnabled = true;
			};
			_Closure_0024__._0024I8_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
	}

	private void ProfileContMenuBuild(MyListItem sender, EventArgs e)
	{
		MyIconButton obj = new MyIconButton
		{
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj).ToolTip = "更改 UUID";
		((FrameworkElement)obj).Tag = RuntimeHelpers.GetObjectValue(((FrameworkElement)sender).Tag);
		MyIconButton myIconButton = obj;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += EditProfileUuid;
		MyIconButton obj2 = new MyIconButton
		{
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj2).ToolTip = "更改验证服务器名称";
		((FrameworkElement)obj2).Tag = RuntimeHelpers.GetObjectValue(((FrameworkElement)sender).Tag);
		ToolTipService.SetPlacement((DependencyObject)(object)obj2, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)obj2, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)obj2, 2.0);
		obj2.Click += EditProfileServer;
		MyIconButton obj3 = new MyIconButton
		{
			Logo = "M520.192 0C408.43 0 317.44 82.87 313.563 186.734H52.736c-29.038 0-52.663 21.943-52.663 49.079s23.625 49.152 52.663 49.152h58.075v550.473c0 103.35 75.118 187.757 167.717 187.757h472.43c92.599 0 167.716-83.894 167.716-187.757V285.477h52.59c29.038 0 52.59-21.943 52.663-49.08-0.073-27.135-23.625-49.151-52.663-49.151H726.235C723.237 83.017 631.955 0 520.192 0zM404.846 177.957c3.803-50.03 50.176-89.015 107.447-89.015 57.197 0 103.57 38.985 106.788 89.015H404.92zM284.379 933.669c-33.353 0-69.997-39.351-69.997-95.525v-549.01H833.39v549.522c0 56.247-36.645 95.525-69.998 95.525H284.379v-0.512z M357.23 800.695a48.274 48.274 0 0 0 47.616-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.69 49.006V751.69c0 27.282 20.846 49.006 47.617 49.006z m166.62 0a48.274 48.274 0 0 0 47.688-49.006V471.7a48.274 48.274 0 0 0-47.689-49.08 48.274 48.274 0 0 0-47.543 49.006V751.69c0 27.282 21.431 49.006 47.543 49.006z m142.92 0a48.274 48.274 0 0 0 47.543-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.616 49.006V751.69c0 27.282 20.773 49.006 47.543 49.006z"
		};
		((FrameworkElement)obj3).ToolTip = "删除档案";
		((FrameworkElement)obj3).Tag = RuntimeHelpers.GetObjectValue(((FrameworkElement)sender).Tag);
		MyIconButton myIconButton2 = obj3;
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton2, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton2, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton2, 2.0);
		myIconButton2.Click += DeleteProfile;
		if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(((FrameworkElement)sender).Tag, (System.Type)null, "Type", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)0, false))
		{
			sender.Buttons = new MyIconButton[] { myIconButton, myIconButton2 };
		}
		else if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(((FrameworkElement)sender).Tag, (System.Type)null, "Type", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)3, false))
		{
			sender.Buttons = new MyIconButton[] { myIconButton2 };
		}
		else
		{
			sender.Buttons = new MyIconButton[] { myIconButton2 };
		}
	}

	private void BtnNew_Click(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		ModBase.RunInNewThread((Action)([SpecialName] [CompilerGenerated] () =>
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			ModProfile.CreateProfile();
			ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
			{
				RefreshProfileList();
			}));
		}), null, (ThreadPriority)2);
	}

	private void EditProfileUuid(object sender, EventArgs e)
	{
		ModProfile.EditOfflineUuid((ModProfile.McProfile)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null));
	}

	private void EditProfileServer(object sender, EventArgs e)
	{
		string text = ModMain.MyMsgBoxInput("修改验证服务器名称", "请输入新的验证服务器名称", Conversions.ToString(NewLateBinding.LateGet(NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "ServerName", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		if (text != null)
		{
			ModProfile.EditAuthServerName((ModProfile.McProfile)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null), text);
		}
	}

	private void DeleteProfile(object sender, EventArgs e)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		if (ModMain.MyMsgBox(string.Format("你正在选择删除此档案，该操作无法撤销。{0}确定继续？", (object)"\r\n"), "删除档案确认", "继续", "取消", "", IsWarn: true, HighLight: true, ForceWait: true) != 2)
		{
			ModProfile.RemoveProfile((ModProfile.McProfile)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null));
			ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
			{
				RefreshProfileList();
			}));
		}
	}

	private void BtnPort_Click()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		ModProfile.MigrateProfile();
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			RefreshProfileList();
		}));
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelaunch/pageloginprofile.xaml", (UriKind)2);
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
			HintSelect = (MyHint)target;
			break;
		case 2:
			HintCreate = (MyHint)target;
			break;
		case 3:
			PanButtons = (Border)target;
			break;
		case 4:
			BtnNew = (MyIconButton)target;
			break;
		case 5:
			BtnPort = (MyIconButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
