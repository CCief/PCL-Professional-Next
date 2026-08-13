using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.App.Configuration;
using PCL.Core.Net;
using PCL.Core.Utils.OS;

namespace PCL;

public class ModSetup : IConfigScope
{
	public System.Collections.Generic.IEnumerable<string> CheckScope(IReadOnlySet<string> keys)
	{
		return Enumerable.Select<MethodInfo, string>(Enumerable.Where<MethodInfo>((System.Collections.Generic.IEnumerable<MethodInfo>)typeof(ModSetup).GetMethods(), (Func<MethodInfo, bool>)([SpecialName] (MethodInfo method) => keys.Contains(((MemberInfo)method).Name))), (Func<MethodInfo, string>)([SpecialName] (MethodInfo method) => ((MemberInfo)method).Name));
	}

	System.Collections.Generic.IEnumerable<string> IConfigScope.CheckScope(IReadOnlySet<string> keys)
	{
		//ILSpy generated this explicit interface implementation from .override directive in CheckScope
		return this.CheckScope(keys);
	}

	public bool Reset(object argument = null)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotSupportedException();
	}

	bool IConfigScope.Reset(object argument = null)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Reset
		return this.Reset(argument);
	}

	public bool IsDefault(object argument = null)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		throw new NotSupportedException();
	}

	bool IConfigScope.IsDefault(object argument = null)
	{
		//ILSpy generated this explicit interface implementation from .override directive in IsDefault
		return this.IsDefault(argument);
	}

	public ModSetup()
	{
		ConfigService.RegisterObserver(this, new ConfigObserver(ConfigEvent.Changed, OnConfigChanged));
	}

	public void OnConfigChanged(ConfigEventArgs e)
	{
		MethodInfo method = typeof(ModSetup).GetMethod(e.Key);
		if (method != null)
		{
			((MethodBase)method).Invoke((object)this, new object[] { e.Value ?? GetConfigItem(e.Key).DefaultValueNoType });
		}
	}

	private static ConfigItem GetConfigItem(string key)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		ConfigItem item = null;
		if (ConfigService.TryGetConfigItemNoType(key, out item))
		{
			return item;
		}
		throw new KeyNotFoundException($"配置项 '{key}' 不存在");
	}

	public void Set(string key, object value, bool forceReload = false, ModMinecraft.McInstance instance = null)
	{
		GetConfigItem(key).SetValueNoType(RuntimeHelpers.GetObjectValue(value), instance?.Path);
	}

	public object Load(string key, bool forceReload = false, ModMinecraft.McInstance instance = null)
	{
		object objectValue = RuntimeHelpers.GetObjectValue(Get(key, instance));
		MethodInfo method = typeof(ModSetup).GetMethod(key);
		if (method != null)
		{
			((MethodBase)method).Invoke((object)this, new object[] { objectValue });
		}
		return objectValue;
	}

	public object Get(string key, ModMinecraft.McInstance instance = null)
	{
		return GetConfigItem(key).GetValueNoType(instance?.Path);
	}

	public void Reset(string key, bool forceReload = false, ModMinecraft.McInstance instance = null)
	{
		GetConfigItem(key).Reset(instance?.Path);
	}

	public object GetDefault(string key)
	{
		return GetConfigItem(key).DefaultValueNoType;
	}

	public bool IsUnset(string key, ModMinecraft.McInstance instance = null)
	{
		return GetConfigItem(key).IsDefault(instance?.Path);
	}

	public void LaunchInstanceSelect(string Value)
	{
		ModBase.Log("[Setup] 当前选择的 Minecraft 版本：" + Value);
		ModBase.WriteIni(ModMinecraft.PathMcFolder + "PCL.ini", "Version", Information.IsNothing((object)ModMinecraft.McInstanceCurrent) ? "" : ModMinecraft.McInstanceCurrent.Name);
	}

	public void LaunchFolderSelect(string Value)
	{
		ModBase.Log("[Setup] 当前选择的 Minecraft 文件夹：" + Value.ToString().Replace("$", ModBase.ExePath));
		ModMinecraft.PathMcFolder = Value.ToString().Replace("$", ModBase.ExePath);
	}

	public void LaunchRamType(int Type)
	{
		if (ModMain.FrmSetupLaunch != null)
		{
			ModMain.FrmSetupLaunch.RamType(Type);
		}
	}

	public void ToolDownloadThread(int Value)
	{
		ModNet.NetTaskThreadLimit = checked(Value + 1);
	}

	public void ToolDownloadSpeed(int Value)
	{
		checked
		{
			if (Value <= 14)
			{
				ModNet.NetTaskSpeedLimitHigh = (long)Math.Round((double)(Value + 1) * 0.1 * 1024.0 * 1024.0);
			}
			else if (Value <= 31)
			{
				ModNet.NetTaskSpeedLimitHigh = (long)Math.Round((double)(Value - 11) * 0.5 * 1024.0 * 1024.0);
			}
			else if (Value <= 41)
			{
				ModNet.NetTaskSpeedLimitHigh = unchecked((long)checked((Value - 21) * 1024)) * 1024L;
			}
			else
			{
				ModNet.NetTaskSpeedLimitHigh = -1L;
			}
		}
	}

	public void UiLauncherTransparent(int Value)
	{
		((UIElement)ModMain.FrmMain).Opacity = (double)Value / 1000.0 + 0.4;
	}

	public void UiLauncherTheme(int Value)
	{
		ModSecret.ThemeRefresh(Value);
	}

	public void UiBackgroundColorful(bool Value)
	{
		ModSecret.ThemeRefresh();
	}

	public void UiLockWindowSize(bool Value)
	{
		if (Value)
		{
			ModMain.FrmMain.RemoveResizer();
		}
		else
		{
			ModMain.FrmMain.AddResizer();
		}
	}

	public void UiAutoPauseVideo(bool Value)
	{
		if (!Value)
		{
			ModVideoBack.ForcePlay = true;
			ModVideoBack.VideoPlay();
			return;
		}
		ModVideoBack.ForcePlay = false;
		if (ModVideoBack.IsGaming)
		{
			ModVideoBack.VideoPause();
		}
	}

	public void UiBackgroundOpacity(int Value)
	{
		((UIElement)ModMain.FrmMain.ImgBack).Opacity = (double)Value / 1000.0;
	}

	public void UiBackgroundBlur(int Value)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Value == 0)
			{
				((UIElement)ModMain.FrmMain.ImgBack).Effect = null;
			}
			else
			{
				((UIElement)ModMain.FrmMain.ImgBack).Effect = (Effect)new BlurEffect
				{
					Radius = Value + 1
				};
			}
			((FrameworkElement)ModMain.FrmMain.ImgBack).Margin = new Thickness((double)(-(Value + 1)) / 1.8);
		}
	}

	public void UiBackgroundSuit(int Value)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_0431: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_055b: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f0: Unknown result type (might be due to invalid IL or missing references)
		if (!Information.IsNothing((object)((Panel)ModMain.FrmMain.ImgBack).Background))
		{
			double width = ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Width;
			double height = ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Height;
			if (Value == 0)
			{
				Value = ((!(width < ((FrameworkElement)ModMain.FrmMain.PanMain).ActualWidth / 2.0) || !(height < ((FrameworkElement)ModMain.FrmMain.PanMain).ActualHeight / 2.0)) ? 2 : 4);
			}
			((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).TileMode = (TileMode)0;
			((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).Viewport = new Rect(0.0, 0.0, 1.0, 1.0);
			((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ViewportUnits = (BrushMappingMode)1;
			switch (Value)
			{
			case 1:
				((FrameworkElement)ModMain.FrmMain.ImgBack).HorizontalAlignment = (HorizontalAlignment)1;
				((FrameworkElement)ModMain.FrmMain.ImgBack).VerticalAlignment = (VerticalAlignment)1;
				((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).Stretch = (Stretch)0;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Width = ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Width;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Height = ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Height;
				break;
			case 2:
				((FrameworkElement)ModMain.FrmMain.ImgBack).HorizontalAlignment = (HorizontalAlignment)3;
				((FrameworkElement)ModMain.FrmMain.ImgBack).VerticalAlignment = (VerticalAlignment)3;
				((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).Stretch = (Stretch)3;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Width = 0.0 / 0.0;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Height = 0.0 / 0.0;
				break;
			case 3:
				((FrameworkElement)ModMain.FrmMain.ImgBack).HorizontalAlignment = (HorizontalAlignment)3;
				((FrameworkElement)ModMain.FrmMain.ImgBack).VerticalAlignment = (VerticalAlignment)3;
				((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).Stretch = (Stretch)1;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Width = 0.0 / 0.0;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Height = 0.0 / 0.0;
				break;
			case 4:
				((FrameworkElement)ModMain.FrmMain.ImgBack).HorizontalAlignment = (HorizontalAlignment)3;
				((FrameworkElement)ModMain.FrmMain.ImgBack).VerticalAlignment = (VerticalAlignment)3;
				((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).Stretch = (Stretch)0;
				((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).TileMode = (TileMode)4;
				((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).Viewport = new Rect(0.0, 0.0, ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Width, ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Height);
				((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ViewportUnits = (BrushMappingMode)0;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Width = 0.0 / 0.0;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Height = 0.0 / 0.0;
				break;
			case 5:
				((FrameworkElement)ModMain.FrmMain.ImgBack).HorizontalAlignment = (HorizontalAlignment)0;
				((FrameworkElement)ModMain.FrmMain.ImgBack).VerticalAlignment = (VerticalAlignment)0;
				((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).Stretch = (Stretch)0;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Width = ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Width;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Height = ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Height;
				break;
			case 6:
				((FrameworkElement)ModMain.FrmMain.ImgBack).HorizontalAlignment = (HorizontalAlignment)2;
				((FrameworkElement)ModMain.FrmMain.ImgBack).VerticalAlignment = (VerticalAlignment)0;
				((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).Stretch = (Stretch)0;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Width = ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Width;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Height = ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Height;
				break;
			case 7:
				((FrameworkElement)ModMain.FrmMain.ImgBack).HorizontalAlignment = (HorizontalAlignment)0;
				((FrameworkElement)ModMain.FrmMain.ImgBack).VerticalAlignment = (VerticalAlignment)2;
				((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).Stretch = (Stretch)0;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Width = ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Width;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Height = ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Height;
				break;
			case 8:
				((FrameworkElement)ModMain.FrmMain.ImgBack).HorizontalAlignment = (HorizontalAlignment)2;
				((FrameworkElement)ModMain.FrmMain.ImgBack).VerticalAlignment = (VerticalAlignment)2;
				((TileBrush)(ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).Stretch = (Stretch)0;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Width = ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Width;
				((FrameworkElement)ModMain.FrmMain.ImgBack).Height = ((ImageBrush)((Panel)ModMain.FrmMain.ImgBack).Background).ImageSource.Height;
				break;
			}
		}
	}

	public void UiFont(string value)
	{
		try
		{
			ModBase.SetLaunchFont(value);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "字体加载失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	public void UiCustomType(int Value)
	{
		if (ModMain.FrmSetupUI != null)
		{
			switch (Value)
			{
			case 0:
				((UIElement)ModMain.FrmSetupUI.PanCustomPreset).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.PanCustomLocal).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.PanCustomNet).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.HintCustom).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.HintCustomWarn).Visibility = (Visibility)2;
				break;
			case 1:
				((UIElement)ModMain.FrmSetupUI.PanCustomPreset).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.PanCustomLocal).Visibility = (Visibility)0;
				((UIElement)ModMain.FrmSetupUI.PanCustomNet).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.HintCustom).Visibility = (Visibility)0;
				((UIElement)ModMain.FrmSetupUI.HintCustomWarn).Visibility = (Visibility)(Conversions.ToBoolean(ModBase.Setup.Get("HintCustomWarn")) ? 2 : 0);
				ModMain.FrmSetupUI.HintCustom.Text = string.Format("从 PCL 文件夹下的 Custom.xaml 读取主页内容。{0}你可以手动编辑该文件，向主页添加文本、图片、常用网站、快捷启动等功能。", (object)"\r\n");
				ModMain.FrmSetupUI.HintCustom.EventType = "";
				ModMain.FrmSetupUI.HintCustom.EventData = "";
				break;
			case 2:
				((UIElement)ModMain.FrmSetupUI.PanCustomPreset).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.PanCustomLocal).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.PanCustomNet).Visibility = (Visibility)0;
				((UIElement)ModMain.FrmSetupUI.HintCustom).Visibility = (Visibility)0;
				((UIElement)ModMain.FrmSetupUI.HintCustomWarn).Visibility = (Visibility)(Conversions.ToBoolean(ModBase.Setup.Get("HintCustomWarn")) ? 2 : 0);
				ModMain.FrmSetupUI.HintCustom.Text = string.Format("从指定网址联网获取主页内容。服主也可以用于动态更新服务器公告。{0}如果你制作了稳定运行的联网主页，可以点击这条提示投稿，若合格即可加入预设！", (object)"\r\n");
				ModMain.FrmSetupUI.HintCustom.EventType = "打开网页";
				ModMain.FrmSetupUI.HintCustom.EventData = "https://github.com/Meloong-Git/PCL/discussions/2528";
				break;
			case 3:
				((UIElement)ModMain.FrmSetupUI.PanCustomPreset).Visibility = (Visibility)0;
				((UIElement)ModMain.FrmSetupUI.PanCustomLocal).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.PanCustomNet).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.HintCustom).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.HintCustomWarn).Visibility = (Visibility)2;
				break;
			}
			ModMain.FrmSetupUI.CardCustom.TriggerForceResize();
		}
	}

	public void UiDarkMode(int Value)
	{
		switch (Value)
		{
		case 0:
			ModSecret.IsDarkMode = false;
			break;
		case 1:
			ModSecret.IsDarkMode = true;
			break;
		default:
			ModSecret.IsDarkMode = SystemTheme.IsSystemInDarkMode();
			break;
		}
		ModSecret.ThemeRefresh();
	}

	public void UiBlur(bool Value)
	{
		((UIElement)ModMain.FrmSetupUI.PanBlurValue).Visibility = (Visibility)((!Value) ? 2 : 0);
		if (Value)
		{
			UiBlurValue(Conversions.ToInteger(ModBase.Setup.Get("UiBlurValue")));
		}
		else
		{
			UiBlurValue(0);
		}
	}

	public void UiBlurValue(int Value)
	{
		Application.Current.Resources[(object)"BlurRadius"] = (double)Value * 1.0;
	}

	public void UiBlurSamplingRate(int Value)
	{
		Application.Current.Resources[(object)"BlurSamplingRate"] = (double)Value * 0.01;
	}

	public void UiBlurType(int Value)
	{
		Application.Current.Resources[(object)"BlurType"] = (object)(KernelType)Value;
	}

	public void UiLogoType(int Value)
	{
		switch (Value)
		{
		case 0:
			((UIElement)ModMain.FrmMain.ShapeTitleLogo).Visibility = (Visibility)2;
			((UIElement)ModMain.FrmMain.LabTitleLogo).Visibility = (Visibility)2;
			((UIElement)ModMain.FrmMain.ImageTitleLogo).Visibility = (Visibility)2;
			((UIElement)ModMain.FrmMain.ProLogo).Visibility = (Visibility)2;
			if (!Information.IsNothing((object)ModMain.FrmSetupUI))
			{
				((UIElement)ModMain.FrmSetupUI.CheckLogoLeft).Visibility = (Visibility)0;
				((UIElement)ModMain.FrmSetupUI.PanLogoText).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.PanLogoChange).Visibility = (Visibility)2;
			}
			break;
		case 1:
			((UIElement)ModMain.FrmMain.ShapeTitleLogo).Visibility = (Visibility)0;
			((UIElement)ModMain.FrmMain.LabTitleLogo).Visibility = (Visibility)2;
			((UIElement)ModMain.FrmMain.ImageTitleLogo).Visibility = (Visibility)2;
			((UIElement)ModMain.FrmMain.ProLogo).Visibility = (Visibility)0;
			if (!Information.IsNothing((object)ModMain.FrmSetupUI))
			{
				((UIElement)ModMain.FrmSetupUI.CheckLogoLeft).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.PanLogoText).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.PanLogoChange).Visibility = (Visibility)2;
			}
			break;
		case 2:
			((UIElement)ModMain.FrmMain.ShapeTitleLogo).Visibility = (Visibility)2;
			((UIElement)ModMain.FrmMain.LabTitleLogo).Visibility = (Visibility)0;
			((UIElement)ModMain.FrmMain.ImageTitleLogo).Visibility = (Visibility)2;
			((UIElement)ModMain.FrmMain.ProLogo).Visibility = (Visibility)0;
			if (!Information.IsNothing((object)ModMain.FrmSetupUI))
			{
				((UIElement)ModMain.FrmSetupUI.CheckLogoLeft).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.PanLogoText).Visibility = (Visibility)0;
				((UIElement)ModMain.FrmSetupUI.PanLogoChange).Visibility = (Visibility)2;
			}
			ModBase.Setup.Load("UiLogoText", forceReload: true);
			break;
		case 3:
			((UIElement)ModMain.FrmMain.ShapeTitleLogo).Visibility = (Visibility)2;
			((UIElement)ModMain.FrmMain.LabTitleLogo).Visibility = (Visibility)2;
			((UIElement)ModMain.FrmMain.ImageTitleLogo).Visibility = (Visibility)0;
			((UIElement)ModMain.FrmMain.ProLogo).Visibility = (Visibility)0;
			if (!Information.IsNothing((object)ModMain.FrmSetupUI))
			{
				((UIElement)ModMain.FrmSetupUI.CheckLogoLeft).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.PanLogoText).Visibility = (Visibility)2;
				((UIElement)ModMain.FrmSetupUI.PanLogoChange).Visibility = (Visibility)0;
			}
			try
			{
				ModMain.FrmMain.ImageTitleLogo.Source = ModBase.ExePath + "PCL\\Logo.png";
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModMain.FrmMain.ImageTitleLogo.Source = null;
				ModBase.Log(ex2, "显示标题栏图片失败", ModBase.LogLevel.Msgbox);
				ProjectData.ClearProjectError();
			}
			break;
		}
		ModBase.Setup.Load("UiLogoLeft", forceReload: true);
		if (!Information.IsNothing((object)ModMain.FrmSetupUI))
		{
			ModMain.FrmSetupUI.CardLogo.TriggerForceResize();
		}
	}

	public void UiLogoText(string Value)
	{
		ModMain.FrmMain.LabTitleLogo.Text = Value;
	}

	public void UiLogoLeft(bool Value)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		ModMain.FrmMain.PanTitleMain.ColumnDefinitions[0].Width = new GridLength((double)((!Value || !Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("UiLogoType"), (object)0, false)) ? 1 : 0), (GridUnitType)2);
	}

	public void UiHiddenPageLink(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenPageDownload(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenPageSetup(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenPageOther(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenFunctionSelect(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenFunctionModUpdate(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenFunctionHidden(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenSetupLaunch(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenSetupUi(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenSetupSystem(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenOtherHelp(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenOtherFeedback(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenOtherVote(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenOtherAbout(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenOtherTest(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenVersionEdit(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenVersionExport(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenVersionSave(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenVersionScreenshot(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenVersionMod(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenVersionResourcePack(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenVersionShader(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void UiHiddenVersionSchematic(bool Value)
	{
		PageSetupUI.HiddenRefresh();
	}

	public void SystemDebugMode(bool Value)
	{
		ModBase.ModeDebug = Value;
	}

	public void SystemDebugAnim(int Value)
	{
		ModAnimation.AniSpeed = ((Value >= 30) ? 200.0 : ModBase.MathClamp((double)Value * 0.1 + 0.1, 0.1, 3.0));
	}

	public void SystemHttpProxy(string value)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		try
		{
			HttpProxyManager.Instance.CustomProxyAddress = new Uri(value);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public void SystemHttpProxyType(int value)
	{
		HttpProxyManager.Instance.Mode = (HttpProxyManager.ProxyMode)Conversions.ToInteger(System.Enum.Parse(typeof(HttpProxyManager.ProxyMode), Conversions.ToString(value)));
	}

	public void SystemHttpProxyCustomUsername(string value)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		if (!string.IsNullOrEmpty(value))
		{
			string text = Conversions.ToString(ModBase.Setup.Get("SystemHttpProxyCustomPassword"));
			HttpProxyManager.Instance.Credentials = (ICredentials?)new NetworkCredential(value, text);
		}
		else
		{
			HttpProxyManager.Instance.Credentials = null;
		}
	}

	public void SystemHttpProxyCustomPassword(string value)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		string text = Conversions.ToString(ModBase.Setup.Get("SystemHttpProxyCustomUsername"));
		if (!string.IsNullOrEmpty(text))
		{
			HttpProxyManager.Instance.Credentials = (ICredentials?)new NetworkCredential(text, value);
		}
		else
		{
			HttpProxyManager.Instance.Credentials = null;
		}
	}

	public void VersionRamType(int Type)
	{
		if (ModMain.FrmInstanceSetup != null)
		{
			ModMain.FrmInstanceSetup.RamType(Type);
		}
	}

	public void VersionServerLogin(int Type)
	{
		if (ModMain.FrmInstanceSetup != null)
		{
			ModBase.WriteIni(ModMinecraft.PathMcFolder + "PCL.ini", "InstanceCache", "");
			if ((object)PageInstanceLeft.Instance != null)
			{
				PageInstanceLeft.Instance = new ModMinecraft.McInstance(PageInstanceLeft.Instance.Name).Load();
				ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
			}
		}
	}
}
