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
public class PageLinkSetup : MyPageRight, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
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
			ModMain.FrmLink.ApplyProviderVisibility();
			ModBase.Log("ApplyProviderVisibility 调用完成");
		}
	}

	private bool IsLoaded;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckEnableOpenFrp")]
	private MyCheckBox _CheckEnableOpenFrp;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckEnableMeFrp")]
	private MyCheckBox _CheckEnableMeFrp;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckEnableNatfrp")]
	private MyCheckBox _CheckEnableNatfrp;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckEnableXhFrp")]
	private MyCheckBox _CheckEnableXhFrp;

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

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardProviders")]
	internal virtual MyCard CardProviders
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCheckBox CheckEnableOpenFrp
	{
		[CompilerGenerated]
		get
		{
			return _CheckEnableOpenFrp;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				CheckEnableOpenFrp_Change((MyCheckBox)a0, a1);
			};
			MyCheckBox checkEnableOpenFrp = _CheckEnableOpenFrp;
			if (checkEnableOpenFrp != null)
			{
				checkEnableOpenFrp.Change -= obj;
			}
			_CheckEnableOpenFrp = value;
			checkEnableOpenFrp = _CheckEnableOpenFrp;
			if (checkEnableOpenFrp != null)
			{
				checkEnableOpenFrp.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckEnableMeFrp
	{
		[CompilerGenerated]
		get
		{
			return _CheckEnableMeFrp;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				CheckEnableMeFrp_Change((MyCheckBox)a0, a1);
			};
			MyCheckBox checkEnableMeFrp = _CheckEnableMeFrp;
			if (checkEnableMeFrp != null)
			{
				checkEnableMeFrp.Change -= obj;
			}
			_CheckEnableMeFrp = value;
			checkEnableMeFrp = _CheckEnableMeFrp;
			if (checkEnableMeFrp != null)
			{
				checkEnableMeFrp.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckEnableNatfrp
	{
		[CompilerGenerated]
		get
		{
			return _CheckEnableNatfrp;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				CheckEnableNatfrp_Change((MyCheckBox)a0, a1);
			};
			MyCheckBox checkEnableNatfrp = _CheckEnableNatfrp;
			if (checkEnableNatfrp != null)
			{
				checkEnableNatfrp.Change -= obj;
			}
			_CheckEnableNatfrp = value;
			checkEnableNatfrp = _CheckEnableNatfrp;
			if (checkEnableNatfrp != null)
			{
				checkEnableNatfrp.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckEnableXhFrp
	{
		[CompilerGenerated]
		get
		{
			return _CheckEnableXhFrp;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				CheckEnableXhFrp_Change((MyCheckBox)a0, a1);
			};
			MyCheckBox checkEnableXhFrp = _CheckEnableXhFrp;
			if (checkEnableXhFrp != null)
			{
				checkEnableXhFrp.Change -= obj;
			}
			_CheckEnableXhFrp = value;
			checkEnableXhFrp = _CheckEnableXhFrp;
			if (checkEnableXhFrp != null)
			{
				checkEnableXhFrp.Change += obj;
			}
		}
	}

	public PageLinkSetup()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageSetupLink_Loaded);
		IsLoaded = false;
		InitializeComponent();
	}

	private void PageSetupLink_Loaded(object sender, RoutedEventArgs e)
	{
		if (!IsLoaded)
		{
			IsLoaded = true;
			LoadSettings();
		}
	}

	private void LoadSettings()
	{
		try
		{
			CheckEnableOpenFrp.Checked = (bool?)(ModBase.Setup.Get("LinkEnableOpenFrp") ?? ((object)true));
			CheckEnableMeFrp.Checked = (bool?)(ModBase.Setup.Get("LinkEnableMeFrp") ?? ((object)true));
			CheckEnableNatfrp.Checked = (bool?)(ModBase.Setup.Get("LinkEnableNatfrp") ?? ((object)true));
			CheckEnableXhFrp.Checked = (bool?)(ModBase.Setup.Get("LinkEnableXhFrp") ?? ((object)true));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "加载联机设置失败");
			ProjectData.ClearProjectError();
		}
	}

	private void CheckEnableOpenFrp_Change(MyCheckBox sender, object e)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		if (!IsLoaded)
		{
			ModBase.Log("OpenFrp Change 事件触发，但页面未加载完成");
			return;
		}
		bool value = CheckEnableOpenFrp.Checked.Value;
		ModBase.Log($"OpenFrp 可见性变更: {value}");
		ModBase.Setup.Set("LinkEnableOpenFrp", value);
		ModBase.Log($"已保存设置 LinkEnableOpenFrp = {value}");
		if (ModMain.FrmLink != null)
		{
			((UIElement)ModMain.FrmLink.ItemOpenFrp).Visibility = (Visibility)((!value) ? 2 : 0);
			ModBase.Log($"已设置 ItemOpenFrp.Visibility = {((UIElement)ModMain.FrmLink.ItemOpenFrp).Visibility}");
		}
		string text = (value ? "显示" : "隐藏");
		ModMain.Hint($"OpenFrp 供应商已设置为{text}", ModMain.HintType.Finish);
	}

	private void CheckEnableMeFrp_Change(MyCheckBox sender, object e)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		if (!IsLoaded)
		{
			ModBase.Log("MeFrp Change 事件触发，但页面未加载完成");
			return;
		}
		bool value = CheckEnableMeFrp.Checked.Value;
		ModBase.Log($"MeFrp 可见性变更: {value}");
		ModBase.Setup.Set("LinkEnableMeFrp", value);
		ModBase.Log($"已保存设置 LinkEnableMeFrp = {value}");
		if (ModMain.FrmLink != null)
		{
			((UIElement)ModMain.FrmLink.ItemMeFrp).Visibility = (Visibility)((!value) ? 2 : 0);
			ModBase.Log($"已设置 ItemMeFrp.Visibility = {((UIElement)ModMain.FrmLink.ItemMeFrp).Visibility}");
		}
		string text = (value ? "显示" : "隐藏");
		ModMain.Hint($"MeFrp 供应商已设置为{text}", ModMain.HintType.Finish);
	}

	private void CheckEnableNatfrp_Change(MyCheckBox sender, object e)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		if (!IsLoaded)
		{
			ModBase.Log("Natfrp Change 事件触发，但页面未加载完成");
			return;
		}
		bool value = CheckEnableNatfrp.Checked.Value;
		ModBase.Log($"SAKURA FRP 可见性变更: {value}");
		ModBase.Setup.Set("LinkEnableNatfrp", value);
		ModBase.Log($"已保存设置 LinkEnableNatfrp = {value}");
		if (ModMain.FrmLink != null)
		{
			((UIElement)ModMain.FrmLink.ItemNatfrp).Visibility = (Visibility)((!value) ? 2 : 0);
			ModBase.Log($"已设置 ItemNatfrp.Visibility = {((UIElement)ModMain.FrmLink.ItemNatfrp).Visibility}");
		}
		string text = (value ? "显示" : "隐藏");
		ModMain.Hint($"SAKURA FRP 供应商已设置为{text}", ModMain.HintType.Finish);
	}

	private void CheckEnableXhFrp_Change(MyCheckBox sender, object e)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		if (!IsLoaded)
		{
			ModBase.Log("XhFrp Change 事件触发，但页面未加载完成");
			return;
		}
		bool value = CheckEnableXhFrp.Checked.Value;
		ModBase.Log($"星穿月联 可见性变更: {value}");
		ModBase.Setup.Set("LinkEnableXhFrp", value);
		ModBase.Log($"已保存设置 LinkEnableXhFrp = {value}");
		if (ModMain.FrmLink != null)
		{
			((UIElement)ModMain.FrmLink.ItemXhFrp).Visibility = (Visibility)((!value) ? 2 : 0);
			ModBase.Log($"已设置 ItemXhFrp.Visibility = {((UIElement)ModMain.FrmLink.ItemXhFrp).Visibility}");
		}
		string text = (value ? "显示" : "隐藏");
		ModMain.Hint($"星穿月联 供应商已设置为{text}", ModMain.HintType.Finish);
	}

	private void ApplyProviderVisibility()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		try
		{
			ModBase.Log("尝试应用供应商可见性...");
			if (ModMain.FrmLink != null)
			{
				ModBase.Log("FrmLink 存在，调用 ApplyProviderVisibility");
				object action;
				if (_Closure_0024__._0024I8_002D0 != null)
				{
					action = _Closure_0024__._0024I8_002D0;
				}
				else
				{
					Action val = [SpecialName] () =>
					{
						ModMain.FrmLink.ApplyProviderVisibility();
						ModBase.Log("ApplyProviderVisibility 调用完成");
					};
					_Closure_0024__._0024I8_002D0 = val;
					action = (object)val;
				}
				ModBase.RunInUi((Action)action);
			}
			else
			{
				ModBase.Log("警告：FrmLink 为 Nothing，无法应用可见性");
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "应用供应商可见性失败");
			ProjectData.ClearProjectError();
		}
	}

	public void Reset()
	{
		try
		{
			ModBase.Setup.Reset("LinkEnableOpenFrp");
			ModBase.Setup.Reset("LinkEnableMeFrp");
			ModBase.Setup.Reset("LinkEnableNatfrp");
			ModBase.Setup.Reset("LinkEnableXhFrp");
			LoadSettings();
			ApplyProviderVisibility();
			ModMain.Hint("联机设置已重置！", ModMain.HintType.Finish);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "重置联机设置失败");
			ProjectData.ClearProjectError();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelink/pagelinksetup.xaml", (UriKind)2);
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
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanMain = (StackPanel)target;
			break;
		case 3:
			CardProviders = (MyCard)target;
			break;
		case 4:
			CheckEnableOpenFrp = (MyCheckBox)target;
			break;
		case 5:
			CheckEnableMeFrp = (MyCheckBox)target;
			break;
		case 6:
			CheckEnableNatfrp = (MyCheckBox)target;
			break;
		case 7:
			CheckEnableXhFrp = (MyCheckBox)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
