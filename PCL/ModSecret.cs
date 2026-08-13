using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.Core.IO;
using PCL.Core.UI;
using PCL.Core.Utils;
using PCL.Core.Utils.Exts;
using PCL.Core.Utils.OS;
using PCL.Core.Utils.Secret;

namespace PCL;

[StandardModule]
internal sealed class ModSecret
{
	public class ThemeStyleStaticColors
	{
		public readonly Color Gray1;

		public readonly Color Gray2;

		public readonly Color Gray3;

		public readonly Color Gray4;

		public readonly Color Gray5;

		public readonly Color Gray6;

		public readonly Color Gray7;

		public readonly Color Gray8;

		public readonly Color White;

		public readonly Color HalfWhite;

		public readonly Color SemiWhite;

		public readonly Color Transparent;

		public readonly Color Memory;

		public readonly Color Tooltip;

		public readonly Color BackgroundTransparentSidebar;

		public readonly SolidColorBrush Gray1Brush;

		public readonly SolidColorBrush Gray2Brush;

		public readonly SolidColorBrush Gray3Brush;

		public readonly SolidColorBrush Gray4Brush;

		public readonly SolidColorBrush Gray5Brush;

		public readonly SolidColorBrush Gray6Brush;

		public readonly SolidColorBrush Gray7Brush;

		public readonly SolidColorBrush Gray8Brush;

		public readonly SolidColorBrush WhiteBrush;

		public readonly SolidColorBrush HalfWhiteBrush;

		public readonly SolidColorBrush SemiWhiteBrush;

		public readonly SolidColorBrush TransparentBrush;

		public readonly SolidColorBrush MemoryBrush;

		public readonly SolidColorBrush TooltipBrush;

		public readonly SolidColorBrush BackgroundTransparentSidebarBrush;

		public ThemeStyleStaticColors(GrayProfile style)
		{
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Unknown result type (might be due to invalid IL or missing references)
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_0278: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0300: Expected O, but got Unknown
			//IL_0302: Unknown result type (might be due to invalid IL or missing references)
			//IL_0307: Unknown result type (might be due to invalid IL or missing references)
			//IL_0311: Expected O, but got Unknown
			//IL_0313: Unknown result type (might be due to invalid IL or missing references)
			//IL_0318: Unknown result type (might be due to invalid IL or missing references)
			//IL_0322: Expected O, but got Unknown
			//IL_0324: Unknown result type (might be due to invalid IL or missing references)
			//IL_0329: Unknown result type (might be due to invalid IL or missing references)
			//IL_0333: Expected O, but got Unknown
			//IL_0335: Unknown result type (might be due to invalid IL or missing references)
			//IL_033a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0344: Expected O, but got Unknown
			//IL_0346: Unknown result type (might be due to invalid IL or missing references)
			//IL_034b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0355: Expected O, but got Unknown
			//IL_0357: Unknown result type (might be due to invalid IL or missing references)
			//IL_035c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0366: Expected O, but got Unknown
			//IL_0368: Unknown result type (might be due to invalid IL or missing references)
			//IL_036d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0377: Expected O, but got Unknown
			//IL_0379: Unknown result type (might be due to invalid IL or missing references)
			//IL_037e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0388: Expected O, but got Unknown
			//IL_038a: Unknown result type (might be due to invalid IL or missing references)
			//IL_038f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0399: Expected O, but got Unknown
			//IL_039b: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03aa: Expected O, but got Unknown
			//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Expected O, but got Unknown
			//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cc: Expected O, but got Unknown
			//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03dd: Expected O, but got Unknown
			//IL_03df: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ee: Expected O, but got Unknown
			Gray1 = NewColor.FromHSL2(0.0, 0.0, style.L1);
			Gray2 = NewColor.FromHSL2(0.0, 0.0, style.L2);
			Gray3 = NewColor.FromHSL2(0.0, 0.0, style.L3);
			Gray4 = NewColor.FromHSL2(0.0, 0.0, style.L4);
			Gray5 = NewColor.FromHSL2(0.0, 0.0, style.L5);
			Gray6 = NewColor.FromHSL2(0.0, 0.0, style.L6);
			Gray7 = NewColor.FromHSL2(0.0, 0.0, style.L7);
			Gray8 = NewColor.FromHSL2(0.0, 0.0, style.L8);
			White = NewColor.FromHSL2(0.0, 0.0, style.G2);
			HalfWhite = NewColor.FromHSL2(0.0, 0.0, style.G2).Alpha(style.Ahw);
			SemiWhite = NewColor.FromHSL2(0.0, 0.0, style.G2).Alpha(style.Asw);
			Transparent = NewColor.FromHSL2(0.0, 0.0, style.L8).Alpha(style.At);
			Memory = NewColor.FromHSL2(0.0, 0.0, style.G3);
			Tooltip = NewColor.FromHSL2(0.0, 0.0, style.G2).Alpha(style.Atb);
			BackgroundTransparentSidebar = NewColor.FromHSL2(0.0, 0.0, style.G1).Alpha(style.Asb);
			Gray1Brush = new SolidColorBrush(Gray1);
			Gray2Brush = new SolidColorBrush(Gray2);
			Gray3Brush = new SolidColorBrush(Gray3);
			Gray4Brush = new SolidColorBrush(Gray4);
			Gray5Brush = new SolidColorBrush(Gray5);
			Gray6Brush = new SolidColorBrush(Gray6);
			Gray7Brush = new SolidColorBrush(Gray7);
			Gray8Brush = new SolidColorBrush(Gray8);
			WhiteBrush = new SolidColorBrush(White);
			HalfWhiteBrush = new SolidColorBrush(HalfWhite);
			SemiWhiteBrush = new SolidColorBrush(SemiWhite);
			TransparentBrush = new SolidColorBrush(Transparent);
			MemoryBrush = new SolidColorBrush(Memory);
			TooltipBrush = new SolidColorBrush(Tooltip);
			BackgroundTransparentSidebarBrush = new SolidColorBrush(BackgroundTransparentSidebar);
		}
	}

	public class ThemeStyleDynamicColors
	{
		public readonly Color Color1;

		public readonly Color Color2;

		public readonly Color Color3;

		public readonly Color Color4;

		public readonly Color Color5;

		public readonly Color Color6;

		public readonly Color Color7;

		public readonly Color Color8;

		public readonly Color ColorBg0;

		public readonly Color ColorBg1;

		public readonly Color SemiTransparent;

		public readonly SolidColorBrush Color1Brush;

		public readonly SolidColorBrush Color2Brush;

		public readonly SolidColorBrush Color3Brush;

		public readonly SolidColorBrush Color4Brush;

		public readonly SolidColorBrush Color5Brush;

		public readonly SolidColorBrush Color6Brush;

		public readonly SolidColorBrush Color7Brush;

		public readonly SolidColorBrush Color8Brush;

		public readonly SolidColorBrush ColorBg0Brush;

		public readonly SolidColorBrush ColorBg1Brush;

		public readonly SolidColorBrush SemiTransparentBrush;

		public ThemeStyleDynamicColors(GrayProfile style, int hue, int sat, int lightAdjust)
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Expected O, but got Unknown
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Expected O, but got Unknown
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Expected O, but got Unknown
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Expected O, but got Unknown
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0237: Expected O, but got Unknown
			//IL_0239: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Expected O, but got Unknown
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Expected O, but got Unknown
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Expected O, but got Unknown
			//IL_026c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_027b: Expected O, but got Unknown
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_028c: Expected O, but got Unknown
			//IL_028e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Expected O, but got Unknown
			double num = (double)sat * style.Sa0;
			double sS = (double)sat * style.Sa1;
			Color1 = NewColor.FromHSL2(hue, num * 0.2, style.L1);
			Color2 = NewColor.FromHSL2(hue, num, AdjustLight(style.L2, lightAdjust, style));
			Color3 = NewColor.FromHSL2(hue, num, AdjustLight(style.L3, lightAdjust, style));
			Color4 = NewColor.FromHSL2(hue, num, AdjustLight(style.L4, lightAdjust, style));
			Color5 = NewColor.FromHSL2(hue, sS, AdjustLight(style.L5, lightAdjust, style));
			Color6 = NewColor.FromHSL2(hue, sS, AdjustLight(style.L6, lightAdjust, style));
			Color7 = NewColor.FromHSL2(hue, sS, AdjustLight(style.L7, lightAdjust, style));
			Color8 = NewColor.FromHSL2(hue, sS, AdjustLight(style.L8, lightAdjust, style));
			ColorBg0 = NewColor.FromHSL2(hue, sat, AdjustLight(style.Lb0, lightAdjust, style));
			ColorBg1 = NewColor.FromHSL2(hue, sat, AdjustLight(style.Lb1, lightAdjust, style)).Alpha(style.Ab);
			SemiTransparent = NewColor.FromHSL2(hue, sat, AdjustLight(style.L8, lightAdjust, style)).Alpha(style.Ast);
			Color1Brush = new SolidColorBrush(Color1);
			Color2Brush = new SolidColorBrush(Color2);
			Color3Brush = new SolidColorBrush(Color3);
			Color4Brush = new SolidColorBrush(Color4);
			Color5Brush = new SolidColorBrush(Color5);
			Color6Brush = new SolidColorBrush(Color6);
			Color7Brush = new SolidColorBrush(Color7);
			Color8Brush = new SolidColorBrush(Color8);
			ColorBg0Brush = new SolidColorBrush(ColorBg0);
			ColorBg1Brush = new SolidColorBrush(ColorBg1);
			SemiTransparentBrush = new SolidColorBrush(SemiTransparent);
		}
	}

	public class GPUInfo
	{
		internal string Name;

		internal long Memory;

		internal string DriverVersion;
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<string, bool> _0024I27_002D0;

		public static Action _0024I91_002D0;

		public static Action _0024I102_002D0;

		public static Action _0024I104_002D1;

		public static VB_0024AnonymousDelegate_8 _0024I105_002D2;

		public static Action<ModLoader.LoaderTask<int, int>> _0024IR105_002D3;

		public static Func<VersionAnnouncementContentModel, string> _0024I110_002D4;

		public static Action _0024I117_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__R0_002D1(ModLoader.LoaderTask<int, int> a0)
		{
			LoadOnlineInfo();
		}

		[SpecialName]
		internal bool _Lambda_0024__27_002D0(string d)
		{
			return d.Contains("-Dlog4j2.formatMsgNoLookups=true");
		}

		[SpecialName]
		internal void _Lambda_0024__91_002D0()
		{
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Expected O, but got Unknown
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Expected O, but got Unknown
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Expected O, but got Unknown
			//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Expected O, but got Unknown
			//IL_077c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0781: Unknown result type (might be due to invalid IL or missing references)
			//IL_0794: Unknown result type (might be due to invalid IL or missing references)
			//IL_079e: Unknown result type (might be due to invalid IL or missing references)
			//IL_07b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_07bc: Expected O, but got Unknown
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Expected O, but got Unknown
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dd: Expected O, but got Unknown
			//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0319: Unknown result type (might be due to invalid IL or missing references)
			//IL_0328: Expected O, but got Unknown
			//IL_061a: Unknown result type (might be due to invalid IL or missing references)
			//IL_061f: Unknown result type (might be due to invalid IL or missing references)
			//IL_062e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0651: Unknown result type (might be due to invalid IL or missing references)
			//IL_0660: Expected O, but got Unknown
			//IL_0667: Unknown result type (might be due to invalid IL or missing references)
			//IL_066c: Unknown result type (might be due to invalid IL or missing references)
			//IL_067b: Unknown result type (might be due to invalid IL or missing references)
			//IL_069d: Unknown result type (might be due to invalid IL or missing references)
			//IL_06ac: Expected O, but got Unknown
			//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_06e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f8: Expected O, but got Unknown
			//IL_06ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0704: Unknown result type (might be due to invalid IL or missing references)
			//IL_0713: Unknown result type (might be due to invalid IL or missing references)
			//IL_0736: Unknown result type (might be due to invalid IL or missing references)
			//IL_0745: Expected O, but got Unknown
			//IL_081e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0828: Unknown result type (might be due to invalid IL or missing references)
			//IL_082d: Unknown result type (might be due to invalid IL or missing references)
			//IL_083c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0868: Unknown result type (might be due to invalid IL or missing references)
			//IL_0877: Expected O, but got Unknown
			//IL_0878: Unknown result type (might be due to invalid IL or missing references)
			//IL_0882: Unknown result type (might be due to invalid IL or missing references)
			//IL_0887: Unknown result type (might be due to invalid IL or missing references)
			//IL_0896: Unknown result type (might be due to invalid IL or missing references)
			//IL_08c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_08d4: Expected O, but got Unknown
			//IL_08d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_08df: Unknown result type (might be due to invalid IL or missing references)
			//IL_08e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_08f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_091f: Unknown result type (might be due to invalid IL or missing references)
			//IL_092e: Expected O, but got Unknown
			//IL_0488: Unknown result type (might be due to invalid IL or missing references)
			//IL_048f: Expected O, but got Unknown
			//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0500: Unknown result type (might be due to invalid IL or missing references)
			//IL_0507: Expected O, but got Unknown
			//IL_0560: Unknown result type (might be due to invalid IL or missing references)
			//IL_0578: Unknown result type (might be due to invalid IL or missing references)
			//IL_057f: Expected O, but got Unknown
			//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_037f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0384: Unknown result type (might be due to invalid IL or missing references)
			//IL_0393: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d5: Expected O, but got Unknown
			//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0410: Unknown result type (might be due to invalid IL or missing references)
			//IL_041f: Expected O, but got Unknown
			//IL_0426: Unknown result type (might be due to invalid IL or missing references)
			//IL_042b: Unknown result type (might be due to invalid IL or missing references)
			//IL_043a: Unknown result type (might be due to invalid IL or missing references)
			//IL_046d: Unknown result type (might be due to invalid IL or missing references)
			//IL_047c: Expected O, but got Unknown
			if (!((FrameworkElement)ModMain.FrmMain).IsLoaded)
			{
				return;
			}
			bool flag = Conversions.ToBoolean(ModBase.Setup.Get("UiAcrylic"));
			ApplyAcrylicEffect();
			bool flag2 = false;
			if (ThemeNow >= 5 && ThemeNow <= 13)
			{
				try
				{
					Uri val = new Uri("pack://application:,,,/Images/Themes/" + Conversions.ToString(ThemeNow) + ".png", (UriKind)1);
					ImageBrush background = new ImageBrush
					{
						ImageSource = (ImageSource)new BitmapImage(val),
						Stretch = (Stretch)3
					};
					((Panel)ModMain.FrmMain.PanTitle).Background = (Brush)(object)background;
					flag2 = true;
					ModBase.Log($"[Theme] 已加载主题 {ThemeNow} 的背景图片", ModBase.LogLevel.Debug);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "加载主题背景图片失败：主题 " + Conversions.ToString(ThemeNow));
					ProjectData.ClearProjectError();
				}
			}
			checked
			{
				if (!flag2)
				{
					LinearGradientBrush val2 = new LinearGradientBrush
					{
						EndPoint = new Point(1.0, 0.0),
						StartPoint = new Point(0.0, 0.0)
					};
					if (ThemeNow == 5)
					{
						((GradientBrush)val2).GradientStops.Add(new GradientStop
						{
							Offset = 0.0,
							Color = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 25.0)
						});
						((GradientBrush)val2).GradientStops.Add(new GradientStop
						{
							Offset = 0.5,
							Color = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 15.0)
						});
						((GradientBrush)val2).GradientStops.Add(new GradientStop
						{
							Offset = 1.0,
							Color = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 25.0)
						});
						((Panel)ModMain.FrmMain.PanTitle).Background = (Brush)(object)val2;
						((Freezable)((Panel)ModMain.FrmMain.PanTitle).Background).Freeze();
					}
					else if (ThemeNow == 15)
					{
						((GradientBrush)val2).GradientStops.Add(new GradientStop
						{
							Offset = 0.0,
							Color = new ModBase.MyColor(122.0, 203.0, 245.0)
						});
						((GradientBrush)val2).GradientStops.Add(new GradientStop
						{
							Offset = 0.5,
							Color = new ModBase.MyColor(255.0, 255.0, 255.0)
						});
						((GradientBrush)val2).GradientStops.Add(new GradientStop
						{
							Offset = 1.0,
							Color = new ModBase.MyColor(234.0, 172.0, 184.0)
						});
						((Panel)ModMain.FrmMain.PanTitle).Background = (Brush)(object)val2;
						((Freezable)((Panel)ModMain.FrmMain.PanTitle).Background).Freeze();
					}
					else if (ThemeNow != 12 && ThemeDontClick != 2)
					{
						if (ColorHueTopbarDelta is int)
						{
							((GradientBrush)val2).GradientStops.Add(new GradientStop
							{
								Offset = 0.0,
								Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.SubtractObject((object)ColorHue, ColorHueTopbarDelta)), ColorSat, 48 + ColorLightAdjust)
							});
							((GradientBrush)val2).GradientStops.Add(new GradientStop
							{
								Offset = 0.5,
								Color = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 54 + ColorLightAdjust)
							});
							((GradientBrush)val2).GradientStops.Add(new GradientStop
							{
								Offset = 1.0,
								Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.AddObject((object)ColorHue, ColorHueTopbarDelta)), ColorSat, 48 + ColorLightAdjust)
							});
						}
						else
						{
							GradientStopCollection gradientStops = ((GradientBrush)val2).GradientStops;
							GradientStop val3 = new GradientStop();
							val3.Offset = 0.0;
							val3.Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.AddObject((object)ColorHue, NewLateBinding.LateIndexGet(ColorHueTopbarDelta, new object[] { 0 }, (string[])null))), ColorSat, 48 + ColorLightAdjust);
							gradientStops.Add(val3);
							GradientStopCollection gradientStops2 = ((GradientBrush)val2).GradientStops;
							val3 = new GradientStop();
							val3.Offset = 0.5;
							val3.Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.AddObject((object)ColorHue, NewLateBinding.LateIndexGet(ColorHueTopbarDelta, new object[] { 1 }, (string[])null))), ColorSat, 54 + ColorLightAdjust);
							gradientStops2.Add(val3);
							GradientStopCollection gradientStops3 = ((GradientBrush)val2).GradientStops;
							val3 = new GradientStop();
							val3.Offset = 1.0;
							val3.Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.AddObject((object)ColorHue, NewLateBinding.LateIndexGet(ColorHueTopbarDelta, new object[] { 2 }, (string[])null))), ColorSat, 48 + ColorLightAdjust);
							gradientStops3.Add(val3);
						}
						((Panel)ModMain.FrmMain.PanTitle).Background = (Brush)(object)val2;
						((Freezable)((Panel)ModMain.FrmMain.PanTitle).Background).Freeze();
					}
					else
					{
						((GradientBrush)val2).GradientStops.Add(new GradientStop
						{
							Offset = 0.0,
							Color = new ModBase.MyColor().FromHSL2(ColorHue - 21, ColorSat, 53 + ColorLightAdjust)
						});
						((GradientBrush)val2).GradientStops.Add(new GradientStop
						{
							Offset = 0.33,
							Color = new ModBase.MyColor().FromHSL2(ColorHue - 7, ColorSat, 47 + ColorLightAdjust)
						});
						((GradientBrush)val2).GradientStops.Add(new GradientStop
						{
							Offset = 0.67,
							Color = new ModBase.MyColor().FromHSL2(ColorHue + 7, ColorSat, 47 + ColorLightAdjust)
						});
						((GradientBrush)val2).GradientStops.Add(new GradientStop
						{
							Offset = 1.0,
							Color = new ModBase.MyColor().FromHSL2(ColorHue + 21, ColorSat, 53 + ColorLightAdjust)
						});
						((Panel)ModMain.FrmMain.PanTitle).Background = (Brush)(object)val2;
					}
				}
				Brush val4 = null;
				if (flag)
				{
					val4 = null;
				}
				else if (Conversions.ToBoolean(ModBase.Setup.Get("UiBackgroundColorful")))
				{
					val4 = (Brush)new LinearGradientBrush
					{
						EndPoint = new Point(0.1, 1.0),
						StartPoint = new Point(0.9, 0.0)
					};
					int num;
					int num2;
					if (ThemeNow == 14 && ColorHueTopbarDelta is int)
					{
						num = Conversions.ToInteger(Operators.AddObject((object)ColorHue, ColorHueTopbarDelta));
						num2 = Conversions.ToInteger(Operators.SubtractObject((object)ColorHue, ColorHueTopbarDelta));
					}
					else
					{
						num = ColorHue - 15;
						num2 = ColorHue + 15;
					}
					((GradientBrush)(LinearGradientBrush)val4).GradientStops.Add(new GradientStop
					{
						Offset = -0.1,
						Color = new ModBase.MyColor().FromHSL2(num, (double)ColorSat * 0.8, GetDarkThemeLight(80.0))
					});
					((GradientBrush)(LinearGradientBrush)val4).GradientStops.Add(new GradientStop
					{
						Offset = 0.4,
						Color = new ModBase.MyColor().FromHSL2(ColorHue, (double)ColorSat * 0.8, GetDarkThemeLight(90.0))
					});
					((GradientBrush)(LinearGradientBrush)val4).GradientStops.Add(new GradientStop
					{
						Offset = 1.1,
						Color = new ModBase.MyColor().FromHSL2(num2, (double)ColorSat * 0.8, GetDarkThemeLight(80.0))
					});
				}
				else
				{
					val4 = new ModBase.MyColor(IsDarkMode ? 20 : 245, IsDarkMode ? 20 : 245, IsDarkMode ? 20 : 245);
				}
				((Panel)ModMain.FrmMain.PanForm).Background = val4;
				if (((Panel)ModMain.FrmMain.PanForm).Background != null)
				{
					((Freezable)((Panel)ModMain.FrmMain.PanForm).Background).Freeze();
				}
				RefreshAllContextMenuThemes();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__102_002D0()
		{
			try
			{
				NoticeUserUpdate();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "[Update] 获取启动器版本信息失败", ModBase.LogLevel.Hint);
				ModMain.Hint("获取启动器版本信息失败，请检查网络连接", ModMain.HintType.Critical);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__104_002D1()
		{
			ModBase.OpenWebsite("https://get.dot.net/8");
		}

		[SpecialName]
		internal void _Lambda_0024__R105_002D3(ModLoader.LoaderTask<int, int> a0)
		{
			((VB_0024AnonymousDelegate_8)([SpecialName] () =>
			{
				UpdateRestart(TriggerRestartAndByEnd: true);
			}))();
		}

		[SpecialName]
		internal void _Lambda_0024__105_002D2()
		{
			UpdateRestart(TriggerRestartAndByEnd: true);
		}

		[SpecialName]
		internal string _Lambda_0024__110_002D4(VersionAnnouncementContentModel x)
		{
			return x.id;
		}

		[SpecialName]
		internal void _Lambda_0024__117_002D0()
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Expected O, but got Unknown
			foreach (Window window in Application.Current.Windows)
			{
				RefreshContextMenusInElement((DependencyObject)window);
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__105_002D0
	{
		public string _0024VB_0024Local_DlTargetPath;

		public bool _0024VB_0024Local_Slient;

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			try
			{
				_Closure_0024__105_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__105_002D1
				{
					_0024VB_0024NonLocal__0024VB_0024Closure_2 = this,
					_0024VB_0024Local_version = RemoteServer.GetLatestVersion(Conversions.ToBoolean(IsUpdBetaChannel) ? UpdateChannel.beta : UpdateChannel.stable, ModBase.IsArm64System ? UpdateArch.arm64 : UpdateArch.x64)
				};
				ModBase.WriteFile($"{ModBase.PathTemp}CEUpdateLog.md", CS_0024_003C_003E8__locals0._0024VB_0024Local_version.Changelog);
				List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
				val.AddRange((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)RemoteServer.GetDownloadLoader(Conversions.ToBoolean(IsUpdBetaChannel) ? UpdateChannel.beta : UpdateChannel.stable, ModBase.IsArm64System ? UpdateArch.arm64 : UpdateArch.x64, _0024VB_0024Local_DlTargetPath));
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("校验更新", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					CS_0024_003C_003E8__locals0._Lambda_0024__1();
				}, null, (ThreadPriority)2));
				if (!_0024VB_0024Local_Slient)
				{
					val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("安装更新", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
					{
						((VB_0024AnonymousDelegate_8)([SpecialName] () =>
						{
							UpdateRestart(TriggerRestartAndByEnd: true);
						}))();
					}, null, (ThreadPriority)2));
				}
				ModLoader.LoaderCombo<JObject> loaderCombo = new ModLoader.LoaderCombo<JObject>("启动器更新", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
				loaderCombo.Start();
				if (_0024VB_0024Local_Slient)
				{
					IsUpdateWaitingRestart = true;
					return;
				}
				ModLoader.LoaderTaskbarAdd(loaderCombo);
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
				ModMain.FrmMain.BtnExtraDownload.Ribble();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "[Update] 下载启动器更新文件失败", ModBase.LogLevel.Hint);
				ModMain.Hint("下载启动器更新文件失败，请检查网络连接", ModMain.HintType.Critical);
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__105_002D1
	{
		public VersionDataModel _0024VB_0024Local_version;

		public _Closure_0024__105_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		[SpecialName]
		internal void _Lambda_0024__R2(ModLoader.LoaderTask<int, int> a0)
		{
			_Lambda_0024__1();
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			string fileSHA = ModBase.GetFileSHA256(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_DlTargetPath);
			if (Operators.CompareString(fileSHA, _0024VB_0024Local_version.SHA256, false) != 0)
			{
				throw new System.Exception($"更新文件 SHA256 不正确，应该为 {_0024VB_0024Local_version.SHA256}，实际为 {fileSHA}");
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__110_002D0
	{
		public List<string> _0024VB_0024Local_ShowedAnnounced;

		public List<VersionAnnouncementContentModel> _0024VB_0024Local_ShowAnnounce;

		public _Closure_0024__110_002D0(_Closure_0024__110_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ShowedAnnounced = arg0._0024VB_0024Local_ShowedAnnounced;
				_0024VB_0024Local_ShowAnnounce = arg0._0024VB_0024Local_ShowAnnounce;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(VersionAnnouncementContentModel x)
		{
			return !_0024VB_0024Local_ShowedAnnounced.Contains(x.id);
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Expected O, but got Unknown
			//IL_00a9: Expected O, but got Unknown
			System.Collections.Generic.IEnumerator<VersionAnnouncementContentModel> enumerator = default(System.Collections.Generic.IEnumerator<VersionAnnouncementContentModel>);
			try
			{
				enumerator = _0024VB_0024Local_ShowAnnounce.GetEnumerator();
				_Closure_0024__110_002D1 closure_0024__110_002D = default(_Closure_0024__110_002D1);
				while (enumerator.MoveNext())
				{
					closure_0024__110_002D = new _Closure_0024__110_002D1(closure_0024__110_002D)
					{
						_0024VB_0024Local_item = enumerator.Current
					};
					ModMain.MyMsgBox(closure_0024__110_002D._0024VB_0024Local_item.detail, closure_0024__110_002D._0024VB_0024Local_item.title, (closure_0024__110_002D._0024VB_0024Local_item.btn1 == null) ? "" : closure_0024__110_002D._0024VB_0024Local_item.btn1.text, (closure_0024__110_002D._0024VB_0024Local_item.btn2 == null) ? "" : closure_0024__110_002D._0024VB_0024Local_item.btn2.text, "关闭", IsWarn: false, HighLight: true, ForceWait: false, new Action(closure_0024__110_002D._Lambda_0024__2), new Action(closure_0024__110_002D._Lambda_0024__3));
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__110_002D1
	{
		public VersionAnnouncementContentModel _0024VB_0024Local_item;

		public _Closure_0024__110_002D1(_Closure_0024__110_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_item = arg0._0024VB_0024Local_item;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			if (_0024VB_0024Local_item.btn1 != null)
			{
				ModEvent.TryStartEvent(_0024VB_0024Local_item.btn1.command, _0024VB_0024Local_item.btn1.command_paramter);
			}
		}

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			if (_0024VB_0024Local_item.btn2 != null)
			{
				ModEvent.TryStartEvent(_0024VB_0024Local_item.btn2.command, _0024VB_0024Local_item.btn2.command_paramter);
			}
		}
	}

	public const string RegFolder = "PCLCE";

	public static readonly string OAuthClientId = EnvironmentInterop.GetSecret("MS_CLIENT_ID", readEnv: true, readEnvDebugOnly: true).ReplaceNullOrEmpty();

	public static readonly string CurseForgeAPIKey = EnvironmentInterop.GetSecret("CURSEFORGE_API_KEY", readEnv: true, readEnvDebugOnly: true).ReplaceNullOrEmpty();

	public static readonly string TelemetryKey = EnvironmentInterop.GetSecret("TELEMETRY_KEY", readEnv: true, readEnvDebugOnly: true).ReplaceNullOrEmpty();

	public static readonly string NatayarkClientId = EnvironmentInterop.GetSecret("NAID_CLIENT_ID", readEnv: true, readEnvDebugOnly: true).ReplaceNullOrEmpty();

	public static readonly string NatayarkClientSecret = EnvironmentInterop.GetSecret("NAID_CLIENT_SECRET", readEnv: true, readEnvDebugOnly: true).ReplaceNullOrEmpty();

	public static readonly string[] LinkServers = EnvironmentInterop.GetSecret("LINK_SERVER_ROOT", readEnv: true, readEnvDebugOnly: true).ReplaceNullOrEmpty().Split("|", (StringSplitOptions)0);

	public const string MsProxyPrefix = "https://pclpro.mtr.qzz.io/ms/";

	public const string CfProxyPrefix = "https://pclpro.mtr.qzz.io/curseforge/";

	private static string _EncryptKeyCache = null;

	private static readonly object _cacheEncryptKeyLock = RuntimeHelpers.GetObjectValue(new object());

	public static bool IsDarkMode = false;

	private const int HighestLight = 95;

	private const int LowestLight = 10;

	private const int LogLightBase = -9;

	private static readonly object LogLightBaseRate = Math.Log(96.0);

	public static int ThemeNow = -1;

	public static int ColorHue = 210;

	public static int ColorSat = 85;

	public static int ColorLightAdjust = 0;

	public static object ColorHueTopbarDelta = 0;

	public static int ThemeDontClick = 0;

	[CompilerGenerated]
	private static EventHandler<bool> ThemeChangedEvent;

	private static readonly int[] HueList;

	private static readonly int[] SatList;

	private static readonly int[] LightList;

	public static bool IsCheckingUpdates;

	public static bool IsUpdateWaitingRestart;

	public static UpdatesWrapperModel RemoteServer;

	public static ModLoader.LoaderTask<int, int> ServerLoader;

	internal static string CPUName;

	internal static List<GPUInfo> GPUs;

	internal static long SystemMemorySize;

	public static string OSInfo;

	public static bool UseMsProxy
	{
		get
		{
			if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("SystemMsApiType"), (object)0, false))
			{
				return false;
			}
			if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("SystemMsApiType"), (object)1, false))
			{
				return string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("SystemMsClientId") ?? "")));
			}
			return true;
		}
	}

	public static string EffectiveOAuthClientId
	{
		get
		{
			if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("SystemMsApiType"), (object)0, false))
			{
				return "c14b0370-8d75-42f8-b329-5b60d39e319f";
			}
			if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("SystemMsApiType"), (object)1, false))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("SystemMsClientId") ?? "");
				if (!string.IsNullOrWhiteSpace(Conversions.ToString(objectValue)))
				{
					return Conversions.ToString(objectValue);
				}
			}
			return OAuthClientId;
		}
	}

	public static bool UseCfProxy
	{
		get
		{
			if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("SystemCfApiType"), (object)0, false))
			{
				return false;
			}
			if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("SystemCfApiType"), (object)1, false))
			{
				return string.IsNullOrWhiteSpace(Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("SystemCfApiKey") ?? "")));
			}
			return true;
		}
	}

	public static string EffectiveCurseForgeAPIKey
	{
		get
		{
			if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("SystemCfApiType"), (object)0, false))
			{
				return "$2a$10$TK3CR9laZ1oUb51B1rXZJ.UQ.bLHZGEZ8Y86nbMacMf1rorvdkBWG";
			}
			if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("SystemCfApiType"), (object)1, false))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("SystemCfApiKey") ?? "");
				if (!string.IsNullOrWhiteSpace(Conversions.ToString(objectValue)))
				{
					return Conversions.ToString(objectValue);
				}
			}
			return CurseForgeAPIKey;
		}
	}

	public static ModBase.MyColor ColorGray1 => StaticColors?.Gray1 ?? LightStaticColors.Gray1;

	public static ModBase.MyColor ColorGray4 => StaticColors?.Gray4 ?? LightStaticColors.Gray4;

	public static ModBase.MyColor ColorGray5 => StaticColors?.Gray5 ?? LightStaticColors.Gray5;

	public static ModBase.MyColor ColorSemiTransparent => DynamicColors.SemiTransparent;

	private static ModBase.MyColor NewColor => new ModBase.MyColor();

	[field: CompilerGenerated]
	public static GrayProfileConfig GrayProfile
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = null;


	[field: CompilerGenerated]
	public static ThemeStyleStaticColors LightStaticColors
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = null;


	[field: CompilerGenerated]
	public static ThemeStyleStaticColors DarkStaticColors
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = null;


	[field: CompilerGenerated]
	public static ThemeStyleStaticColors StaticColors
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = null;


	[field: CompilerGenerated]
	public static ThemeStyleDynamicColors DynamicColors
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	} = null;


	public static object IsUpdBetaChannel => false;

	public static event EventHandler<bool> ThemeChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<bool> val = ThemeChangedEvent;
			EventHandler<bool> val2;
			do
			{
				val2 = val;
				EventHandler<bool> val3 = (EventHandler<bool>)(object)System.Delegate.Combine((System.Delegate)(object)val2, (System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<bool>>(ref ThemeChangedEvent, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<bool> val = ThemeChangedEvent;
			EventHandler<bool> val2;
			do
			{
				val2 = val;
				EventHandler<bool> val3 = (EventHandler<bool>)(object)System.Delegate.Remove((System.Delegate)(object)val2, (System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<bool>>(ref ThemeChangedEvent, val3, val2);
			}
			while (val != val2);
		}
	}

	static ModSecret()
	{
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		int[] array = new int[] { 200, 210, 225 };
		HueList = array;
		int[] array2 = new int[] { 100, 85, 70 };
		SatList = array2;
		LightList = new int[] { 7, 0, -2 };
		IsCheckingUpdates = false;
		IsUpdateWaitingRestart = false;
		RemoteServer = new UpdatesWrapperModel(new IUpdateSource[4]
		{
			new UpdatesMinioModel("https://cdn.gh-proxy.org/https://github.com/PCLPro/PCL2_Pro_Update/raw/main/", "Fastly"),
			new UpdatesMinioModel("https://edgeone.gh-proxy.org/https://github.com/PCLPro/PCL2_Pro_Update/raw/main/", "Edgeone"),
			new UpdatesMinioModel("https://gh-proxy.org/https://github.com/PCLPro/PCL2_Pro_Update/raw/main/", "GHProxy"),
			new UpdatesMinioModel("https://github.com/PCLPro/PCL2_Pro_Update/raw/main/", "GitHub")
		});
		ServerLoader = new ModLoader.LoaderTask<int, int>("PCL 服务", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
		{
			LoadOnlineInfo();
		}, null, (ThreadPriority)1);
		CPUName = null;
		GPUs = new List<GPUInfo>();
		SystemMemorySize = checked((long)Math.Round((double)KernelInterop.GetPhysicalMemoryBytes().Item1 / 1024.0 / 1024.0));
		OSInfo = RuntimeInformation.OSDescription + " " + Environment.OSVersion.Version.ToString();
	}

	public static string GetMsUrl(string originalUrl)
	{
		return originalUrl;
	}

	public static string GetCfUrl(string originalUrl)
	{
		if (UseCfProxy)
		{
			return "https://pclpro.mtr.qzz.io/curseforge/" + originalUrl;
		}
		return originalUrl;
	}

	internal static void SecretOnApplicationStart()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_004d: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		Thread.CurrentThread.Priority = (ThreadPriority)4;
		try
		{
			new FormattedText("", CultureInfo.CurrentCulture, (FlowDirection)0, Enumerable.First<Typeface>((System.Collections.Generic.IEnumerable<Typeface>)Fonts.SystemTypefaces), 96.0, (Brush)new ModBase.MyColor(), (double)ModBase.DPI);
		}
		catch (UriFormatException val)
		{
			ProjectData.SetProjectError((System.Exception)val);
			UriFormatException val2 = val;
			Environment.SetEnvironmentVariable("windir", Environment.GetEnvironmentVariable("SystemRoot"), (EnvironmentVariableTarget)1);
			new FormattedText("", CultureInfo.CurrentCulture, (FlowDirection)0, Enumerable.First<Typeface>((System.Collections.Generic.IEnumerable<Typeface>)Fonts.SystemTypefaces), 96.0, (Brush)new ModBase.MyColor(), (double)ModBase.DPI);
			ProjectData.ClearProjectError();
		}
		string dataPath = FileService.DataPath;
		try
		{
			Directory.CreateDirectory(dataPath);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			Interaction.MsgBox((object)($"PCL 无法创建 PCL 文件夹（{dataPath}），请尝试：" + "\r\n1. 将 PCL 移动到其他文件夹" + (ModBase.StartsWithF(ModBase.ExePath, "C:", IgnoreCase: true) ? "，例如 C 盘和桌面以外的其他位置。" : "。") + "\r\n2. 删除当前目录中的 PCL 文件夹，然后再试。\r\n3. 右键 PCL 选择属性，打开 兼容性 中的 以管理员身份运行此程序。"), (MsgBoxStyle)16, (object)"运行环境错误");
			Environment.Exit(4);
			ProjectData.ClearProjectError();
		}
		if (!ModBase.CheckPermission(ModBase.ExePath + "PCL"))
		{
			Interaction.MsgBox((object)("PCL 没有对当前文件夹的写入权限，请尝试：\r\n1. 将 PCL 移动到其他文件夹" + (ModBase.StartsWithF(ModBase.ExePath, "C:", IgnoreCase: true) ? "，例如 C 盘和桌面以外的其他位置。" : "。") + "\r\n2. 删除当前目录中的 PCL 文件夹，然后再试。\r\n3. 右键 PCL 选择属性，打开 兼容性 中的 以管理员身份运行此程序。"), (MsgBoxStyle)16, (object)"运行环境错误");
			Environment.Exit(4);
		}
		if (Conversions.ToBoolean(ModBase.Setup.Get("UiLauncherCEHint")))
		{
			int num = Conversions.ToInteger(ModBase.Setup.Get("UiLauncherCEHintCount"));
			if (num <= 0)
			{
				ShowCEAnnounce();
				num = 11;
			}
			ModBase.Setup.Set("UiLauncherCEHintCount", checked(num - 1));
		}
	}

	public static void ShowCEAnnounce(bool IsUpdate = false)
	{
		ModMain.MyMsgBox(string.Format("你正在使用来自 PCL-Community 的 PCL 社区版本，遇到问题请不要向官方仓库反馈！\nPCL-Community 及其成员与龙腾猫跃无从属关系，且均不会为您的使用做担保。\n\n如果你是意外下载的社区版，建议下载官方版 PCL 使用。\n\n该版本与官方版本的特性区别：\n- 联网通知：暂时没有，在做了在做了.jpg\n- 主题切换：不会制作，这是需要赞助解锁的纪念性质的功能\n- 百宝箱：部分内容更改和缺失，主线分支没有提供相关内容{0}", (object)(IsUpdate ? string.Format("{0}{1}该提示总会在更新启动器时展示一次。", (object)"\r\n", (object)"\r\n") : "")), "社区版本说明", "我知道了");
	}

	internal static string SecretGetRawCode()
	{
		return Identify.RawCode;
	}

	internal static string SecretGetUniqueAddress()
	{
		return Identify.LaunchId;
	}

	internal static string SecretGetEncryptKey()
	{
		object cacheEncryptKeyLock = _cacheEncryptKeyLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(cacheEncryptKeyLock);
		bool flag = false;
		try
		{
			Monitor.Enter(cacheEncryptKeyLock, ref flag);
			if (_EncryptKeyCache != null)
			{
				return _EncryptKeyCache;
			}
			string text = SecretGetRawCode();
			SHA512 val = SHA512.Create();
			try
			{
				return _EncryptKeyCache = BitConverter.ToString(((HashAlgorithm)val).ComputeHash(Encoding.UTF8.GetBytes(text))).Replace("-", "").Substring(4, 32);
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(cacheEncryptKeyLock);
			}
		}
	}

	internal static void SecretLaunchJvmArgs(ref List<string> DataList)
	{
		string text = Conversions.ToString(ModBase.Setup.Get("VersionAdvanceJvm", ModMinecraft.McInstanceCurrent));
		DataList.Insert(0, Conversions.ToString((Operators.CompareString(text, "", false) == 0) ? ModBase.Setup.Get("LaunchAdvanceJvm") : text));
		object obj = ModBase.Setup.Get("LaunchPreferredIpStack");
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			DataList.Add("-Djava.net.preferIPv4Stack=true");
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)2, false))
		{
			DataList.Add("-Djava.net.preferIPv6Stack=true");
		}
		ModLaunch.McLaunchLog("当前剩余内存：" + Conversions.ToString(Math.Round((double)KernelInterop.GetAvailablePhysicalMemoryBytes() / 1024.0 / 1024.0 / 1024.0 * 10.0) / 10.0) + "G");
		DataList.Add("-Xmn" + Conversions.ToString(Math.Floor(PageInstanceSetup.GetRam(ModMinecraft.McInstanceCurrent) * 1024.0 * 0.15)) + "m");
		DataList.Add("-Xmx" + Conversions.ToString(Math.Floor(PageInstanceSetup.GetRam(ModMinecraft.McInstanceCurrent) * 1024.0)) + "m");
		if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)DataList, (Func<string, bool>)([SpecialName] (string d) => d.Contains("-Dlog4j2.formatMsgNoLookups=true"))))
		{
			DataList.Add("-Dlog4j2.formatMsgNoLookups=true");
		}
	}

	internal static object SecretCdnSign(string UrlWithMark)
	{
		if (!ModBase.EndsWithF(UrlWithMark, "{CDN}"))
		{
			return UrlWithMark;
		}
		return UrlWithMark.Replace("{CDN}", "").Replace(" ", "%20");
	}

	internal static void SecretHeadersSign(string Url, ref HttpRequestMessage Client, bool UseBrowserUserAgent = false, string CustomUserAgent = "")
	{
		Client.Version = HttpVersion.Version20;
		Client.VersionPolicy = (HttpVersionPolicy)0;
		if (Url.Contains("api.curseforge.com") && !UseCfProxy)
		{
			((HttpHeaders)Client.Headers).Add("x-api-key", EffectiveCurseForgeAPIKey);
		}
		string text = ((!string.IsNullOrEmpty(CustomUserAgent)) ? CustomUserAgent : (UseBrowserUserAgent ? string.Format("PCLPro/{0} Mozilla/5.0 AppleWebKit/537.36 (KHTML, like Gecko) Chrome/136.0.0.0 Safari/537.36 Edg/136.0.0.0", (object)"2.13.3.0") : string.Format("PCLPro/{0}", (object)"2.13.3.0")));
		((HttpHeaders)Client.Headers).Add("User-Agent", text);
		((HttpHeaders)Client.Headers).Add("Referer", "https://github.com/PCLPro");
	}

	internal static string SecretDecrptyOld(string SourceString)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		string text = "00000000";
		byte[] bytes = Encoding.UTF8.GetBytes(text);
		byte[] bytes2 = Encoding.UTF8.GetBytes("87160295");
		DES val = DES.Create();
		try
		{
			MemoryStream val2 = new MemoryStream();
			try
			{
				byte[] array = Convert.FromBase64String(SourceString);
				CryptoStream val3 = new CryptoStream((Stream)(object)val2, ((SymmetricAlgorithm)val).CreateDecryptor(bytes, bytes2), (CryptoStreamMode)1);
				try
				{
					val3.Write(array, 0, array.Length);
					val3.FlushFinalBlock();
					return Encoding.UTF8.GetString(val2.ToArray());
				}
				finally
				{
					((System.IDisposable)val3)?.Dispose();
				}
			}
			finally
			{
				((System.IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((System.IDisposable)val)?.Dispose();
		}
	}

	internal static string SecretEncrypt(string SourceString)
	{
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		if (Operators.CompareString(SourceString, "", false) == 0)
		{
			return "";
		}
		if (string.IsNullOrWhiteSpace(SourceString))
		{
			return null;
		}
		string text = SecretGetEncryptKey();
		Aes val = Aes.Create();
		try
		{
			((SymmetricAlgorithm)val).KeySize = 256;
			((SymmetricAlgorithm)val).BlockSize = 128;
			((SymmetricAlgorithm)val).Mode = (CipherMode)1;
			((SymmetricAlgorithm)val).Padding = (PaddingMode)2;
			byte[] array = new byte[32];
			RandomNumberGenerator val2 = RandomNumberGenerator.Create();
			try
			{
				val2.GetBytes(array);
			}
			finally
			{
				((System.IDisposable)val2)?.Dispose();
			}
			Rfc2898DeriveBytes val3 = new Rfc2898DeriveBytes(text, array, 1000, HashAlgorithmName.SHA1);
			try
			{
				((SymmetricAlgorithm)val).Key = val3.GetBytes(((SymmetricAlgorithm)val).KeySize / 8);
				((SymmetricAlgorithm)val).GenerateIV();
			}
			finally
			{
				((System.IDisposable)val3)?.Dispose();
			}
			MemoryStream val4 = new MemoryStream();
			try
			{
				val4.Write(array, 0, array.Length);
				val4.Write(((SymmetricAlgorithm)val).IV, 0, ((SymmetricAlgorithm)val).IV.Length);
				CryptoStream val5 = new CryptoStream((Stream)(object)val4, ((SymmetricAlgorithm)val).CreateEncryptor(), (CryptoStreamMode)1);
				try
				{
					byte[] bytes = Encoding.UTF8.GetBytes(SourceString);
					val5.Write(bytes, 0, bytes.Length);
				}
				finally
				{
					((System.IDisposable)val5)?.Dispose();
				}
				return Convert.ToBase64String(val4.ToArray());
			}
			finally
			{
				((System.IDisposable)val4)?.Dispose();
			}
		}
		finally
		{
			((System.IDisposable)val)?.Dispose();
		}
	}

	internal static string SecretDecrypt(string SourceString)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected O, but got Unknown
		if (Operators.CompareString(SourceString, "", false) == 0)
		{
			return "";
		}
		if (string.IsNullOrWhiteSpace(SourceString))
		{
			return null;
		}
		string text = SecretGetEncryptKey();
		byte[] array = Convert.FromBase64String(SourceString);
		Aes val = Aes.Create();
		checked
		{
			try
			{
				((SymmetricAlgorithm)val).KeySize = 256;
				((SymmetricAlgorithm)val).BlockSize = 128;
				((SymmetricAlgorithm)val).Mode = (CipherMode)1;
				((SymmetricAlgorithm)val).Padding = (PaddingMode)2;
				byte[] array2 = new byte[32];
				System.Array.Copy((System.Array)array, 0, (System.Array)array2, 0, array2.Length);
				byte[] array3 = new byte[unchecked(((SymmetricAlgorithm)val).BlockSize / 8) - 1 + 1];
				System.Array.Copy((System.Array)array, array2.Length, (System.Array)array3, 0, array3.Length);
				((SymmetricAlgorithm)val).IV = array3;
				if (array.Length < array2.Length + array3.Length)
				{
					throw new ArgumentException("加密数据格式无效或已损坏");
				}
				Rfc2898DeriveBytes val2 = new Rfc2898DeriveBytes(text, array2, 1000, HashAlgorithmName.SHA1);
				try
				{
					((SymmetricAlgorithm)val).Key = val2.GetBytes(unchecked(((SymmetricAlgorithm)val).KeySize / 8));
				}
				finally
				{
					((System.IDisposable)val2)?.Dispose();
				}
				int num = array.Length - array2.Length - array3.Length;
				MemoryStream val3 = new MemoryStream(array, array2.Length + array3.Length, num);
				try
				{
					CryptoStream val4 = new CryptoStream((Stream)(object)val3, ((SymmetricAlgorithm)val).CreateDecryptor(), (CryptoStreamMode)0);
					try
					{
						StreamReader val5 = new StreamReader((Stream)(object)val4, Encoding.UTF8);
						try
						{
							return val5.ReadToEnd();
						}
						finally
						{
							((System.IDisposable)val5)?.Dispose();
						}
					}
					finally
					{
						((System.IDisposable)val4)?.Dispose();
					}
				}
				finally
				{
					((System.IDisposable)val3)?.Dispose();
				}
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
		}
	}

	public static int AdjustLight(int origin, int adjust, GrayProfile style = null)
	{
		if (origin < 0)
		{
			return 0;
		}
		if (adjust == 0)
		{
			return origin;
		}
		if (origin > 95 || origin < 10)
		{
			return origin;
		}
		if ((object)style == null)
		{
			style = CurrentProfile();
		}
		checked
		{
			adjust = (int)Math.Round((double)adjust * ((adjust > 0) ? style.LaP : style.LaN));
			object obj = Operators.DivideObject((object)Math.Log((double)(origin + -9)), LogLightBaseRate);
			double num = (double)adjust / 20.0;
			return (int)Math.Round(Math.Exp(Conversions.ToDouble(Operators.MultiplyObject(Operators.AddObject(obj, Operators.MultiplyObject((object)num, (num > 0.0) ? Operators.SubtractObject((object)1, obj) : obj)), LogLightBaseRate))) - -9.0);
		}
	}

	public static GrayProfile CurrentProfile()
	{
		return GrayProfile.CurrentProfile(IsDarkMode);
	}

	public static void RaiseThemeChanged(bool isDarkMode)
	{
		ThemeChangedEvent?.Invoke((object)"", isDarkMode);
	}

	public static void ThemeRefresh(int NewTheme = -1)
	{
		if (NewTheme >= 0)
		{
			ThemeNow = NewTheme;
		}
		ThemeRefreshColor();
		RaiseThemeChanged(IsDarkMode);
		ThemeRefreshMain();
	}

	public static double GetDarkThemeLight(double OriginalLight)
	{
		if (IsDarkMode)
		{
			return OriginalLight * 0.1;
		}
		return OriginalLight;
	}

	private static ValueTuple<int, int, int> GetThemeHSL(int themeId)
	{
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		ValueTuple<int, int, int> result = default(ValueTuple<int, int, int>);
		switch (themeId)
		{
		case 0:
			result = new(210, 85, 0);
			break;
		case 1:
			result = new(175, 80, 0);
			break;
		case 2:
			result = new(110, 70, 0);
			break;
		case 3:
			result = new(45, 75, 5);
			break;
		case 4:
			result = new(25, 60, -2);
			break;
		case 5:
			result = new(210, 20, -5);
			break;
		case 6:
			result = new(330, 70, 3);
			break;
		case 7:
			result = new(270, 75, 2);
			break;
		case 8:
			result = new(210, 85, 0);
			break;
		case 9:
			result = new(180, 75, 0);
			break;
		case 10:
			result = new(0, 80, 5);
			break;
		case 11:
			result = new(210, 85, 0);
			break;
		case 12:
			result = new(210, 85, 0);
			break;
		case 13:
			result = new(50, 85, 8);
			break;
		case 15:
			result = new(200, 80, 0);
			break;
		default:
			result = new(210, 85, 0);
			break;
		}
		return result;
	}

	private static int MapThemeToColorIndex(int themeId, int fallbackIndex)
	{
		switch (themeId)
		{
		case 0:
			return 1;
		case 1:
			return 0;
		case 2:
			return 2;
		case 3:
			return 0;
		case 4:
			return 2;
		case 5:
			return 1;
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
			return 1;
		case 14:
			return fallbackIndex;
		default:
			return fallbackIndex;
		}
	}

	public static void ThemeRefreshColor()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		int num = Conversions.ToInteger((ThemeNow >= 0) ? ((object)ThemeNow) : ModBase.Setup.Get("UiLauncherTheme"));
		if (num >= 0 && num <= 13)
		{
			ValueTuple<int, int, int> themeHSL = GetThemeHSL(num);
			ColorHue = themeHSL.Item1;
			ColorSat = themeHSL.Item2;
			ColorLightAdjust = themeHSL.Item3;
			ColorHueTopbarDelta = 0;
			ModBase.Log(string.Format("[Theme] 应用主题 {0}: Hue={1}, Sat={2}, Light={3}", new object[] { num, ColorHue, ColorSat, ColorLightAdjust }), ModBase.LogLevel.Debug);
		}
		else if (num == 14)
		{
			int num2 = Conversions.ToInteger(IsDarkMode ? ModBase.Setup.Get("UiDarkColor") : ModBase.Setup.Get("UiLightColor"));
			ColorHue = HueList[num2];
			ColorSat = SatList[num2];
			ColorLightAdjust = LightList[num2];
			ColorHueTopbarDelta = 0;
		}
		else
		{
			int num3 = Conversions.ToInteger(IsDarkMode ? ModBase.Setup.Get("UiDarkColor") : ModBase.Setup.Get("UiLightColor"));
			ColorHue = HueList[num3];
			ColorSat = SatList[num3];
			ColorLightAdjust = LightList[num3];
			ColorHueTopbarDelta = 0;
		}
		if ((object)GrayProfile == null)
		{
			AnyType anyType = FileService.WaitForResult(PredefinedFileItems.GrayProfile);
			if (anyType == null)
			{
				ModBase.Log("[Theme] 无法获取灰阶配置", ModBase.LogLevel.Debug);
			}
			else if (anyType.Type.IsSubclassOf(typeof(System.Exception)))
			{
				ModBase.Log(anyType.Value<System.Exception>(), "[Theme] 获取灰阶配置时出错", ModBase.LogLevel.Hint);
			}
			else
			{
				GrayProfile = anyType.Value<GrayProfileConfig>();
			}
			if ((object)GrayProfile == null || !GrayProfile.IsEnabled)
			{
				ModBase.Log("[Theme] 正在使用默认灰阶配置");
				GrayProfile = new GrayProfileConfig
				{
					IsEnabled = true
				};
			}
			else
			{
				ModBase.Log("[Theme] 生效灰阶配置: " + PredefinedFileItems.GrayProfile.TargetPath);
			}
			LightStaticColors = new ThemeStyleStaticColors(GrayProfile.Light);
			DarkStaticColors = new ThemeStyleStaticColors(GrayProfile.Dark);
		}
		ResourceDictionary resources = Application.Current.Resources;
		StaticColors = (IsDarkMode ? DarkStaticColors : LightStaticColors);
		DynamicColors = new ThemeStyleDynamicColors(CurrentProfile(), ColorHue, ColorSat, ColorLightAdjust);
		resources[(object)"ColorObjectGray1"] = StaticColors.Gray1;
		resources[(object)"ColorObjectGray2"] = StaticColors.Gray2;
		resources[(object)"ColorObjectGray3"] = StaticColors.Gray3;
		resources[(object)"ColorObjectGray4"] = StaticColors.Gray4;
		resources[(object)"ColorObjectGray5"] = StaticColors.Gray5;
		resources[(object)"ColorObjectGray6"] = StaticColors.Gray6;
		resources[(object)"ColorObjectGray7"] = StaticColors.Gray7;
		resources[(object)"ColorObjectGray8"] = StaticColors.Gray8;
		resources[(object)"ColorBrushGray1"] = StaticColors.Gray1Brush;
		resources[(object)"ColorBrushGray2"] = StaticColors.Gray2Brush;
		resources[(object)"ColorBrushGray3"] = StaticColors.Gray3Brush;
		resources[(object)"ColorBrushGray4"] = StaticColors.Gray4Brush;
		resources[(object)"ColorBrushGray5"] = StaticColors.Gray5Brush;
		resources[(object)"ColorBrushGray6"] = StaticColors.Gray6Brush;
		resources[(object)"ColorBrushGray7"] = StaticColors.Gray7Brush;
		resources[(object)"ColorBrushGray8"] = StaticColors.Gray8Brush;
		resources[(object)"ColorObject1"] = DynamicColors.Color1;
		resources[(object)"ColorObject2"] = DynamicColors.Color2;
		resources[(object)"ColorObject3"] = DynamicColors.Color3;
		resources[(object)"ColorObject4"] = DynamicColors.Color4;
		resources[(object)"ColorObject5"] = DynamicColors.Color5;
		resources[(object)"ColorObject6"] = DynamicColors.Color6;
		resources[(object)"ColorObject7"] = DynamicColors.Color7;
		resources[(object)"ColorObject8"] = DynamicColors.Color8;
		resources[(object)"ColorObjectBg0"] = DynamicColors.ColorBg0;
		resources[(object)"ColorObjectBg1"] = DynamicColors.ColorBg1;
		resources[(object)"ColorBrush1"] = DynamicColors.Color1Brush;
		resources[(object)"ColorBrush2"] = DynamicColors.Color2Brush;
		resources[(object)"ColorBrush3"] = DynamicColors.Color3Brush;
		resources[(object)"ColorBrush4"] = DynamicColors.Color4Brush;
		resources[(object)"ColorBrush5"] = DynamicColors.Color5Brush;
		resources[(object)"ColorBrush6"] = DynamicColors.Color6Brush;
		resources[(object)"ColorBrush7"] = DynamicColors.Color7Brush;
		resources[(object)"ColorBrush8"] = DynamicColors.Color8Brush;
		resources[(object)"ColorBrushBg0"] = DynamicColors.ColorBg0Brush;
		resources[(object)"ColorBrushBg1"] = DynamicColors.ColorBg1Brush;
		resources[(object)"ColorBrushWhite"] = StaticColors.WhiteBrush;
		resources[(object)"ColorBrushHalfWhite"] = StaticColors.HalfWhiteBrush;
		resources[(object)"ColorBrushSemiWhite"] = StaticColors.SemiWhiteBrush;
		resources[(object)"ColorBrushBackgroundTransparentSidebar"] = StaticColors.BackgroundTransparentSidebarBrush;
		resources[(object)"ColorBrushTransparent"] = StaticColors.TransparentBrush;
		resources[(object)"ColorBrushSemiTransparent"] = DynamicColors.SemiTransparentBrush;
		resources[(object)"ColorBrushToolTip"] = StaticColors.TooltipBrush;
		resources[(object)"ColorBrushMemory"] = StaticColors.MemoryBrush;
		resources[(object)"ColorBrushMsgBox"] = StaticColors.WhiteBrush;
		resources[(object)"ColorBrushMsgBoxText"] = RuntimeHelpers.GetObjectValue(resources[(object)"ColorBrush1"]);
	}

	public static void ThemeRefreshMain()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I91_002D0 != null)
		{
			action = _Closure_0024__._0024I91_002D0;
		}
		else
		{
			Action val = checked([SpecialName] () =>
			{
				//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
				//IL_0109: Unknown result type (might be due to invalid IL or missing references)
				//IL_011c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0128: Expected O, but got Unknown
				//IL_005d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0063: Expected O, but got Unknown
				//IL_0063: Unknown result type (might be due to invalid IL or missing references)
				//IL_0068: Unknown result type (might be due to invalid IL or missing references)
				//IL_006a: Unknown result type (might be due to invalid IL or missing references)
				//IL_0074: Expected O, but got Unknown
				//IL_0074: Unknown result type (might be due to invalid IL or missing references)
				//IL_007d: Expected O, but got Unknown
				//IL_013a: Unknown result type (might be due to invalid IL or missing references)
				//IL_013f: Unknown result type (might be due to invalid IL or missing references)
				//IL_014e: Unknown result type (might be due to invalid IL or missing references)
				//IL_016e: Unknown result type (might be due to invalid IL or missing references)
				//IL_017d: Expected O, but got Unknown
				//IL_0184: Unknown result type (might be due to invalid IL or missing references)
				//IL_0189: Unknown result type (might be due to invalid IL or missing references)
				//IL_0198: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
				//IL_01c7: Expected O, but got Unknown
				//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
				//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
				//IL_0202: Unknown result type (might be due to invalid IL or missing references)
				//IL_0211: Expected O, but got Unknown
				//IL_077c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0781: Unknown result type (might be due to invalid IL or missing references)
				//IL_0794: Unknown result type (might be due to invalid IL or missing references)
				//IL_079e: Unknown result type (might be due to invalid IL or missing references)
				//IL_07b1: Unknown result type (might be due to invalid IL or missing references)
				//IL_07bc: Expected O, but got Unknown
				//IL_024e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0253: Unknown result type (might be due to invalid IL or missing references)
				//IL_0262: Unknown result type (might be due to invalid IL or missing references)
				//IL_0283: Unknown result type (might be due to invalid IL or missing references)
				//IL_0292: Expected O, but got Unknown
				//IL_0299: Unknown result type (might be due to invalid IL or missing references)
				//IL_029e: Unknown result type (might be due to invalid IL or missing references)
				//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
				//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
				//IL_02dd: Expected O, but got Unknown
				//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
				//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
				//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
				//IL_0319: Unknown result type (might be due to invalid IL or missing references)
				//IL_0328: Expected O, but got Unknown
				//IL_061a: Unknown result type (might be due to invalid IL or missing references)
				//IL_061f: Unknown result type (might be due to invalid IL or missing references)
				//IL_062e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0651: Unknown result type (might be due to invalid IL or missing references)
				//IL_0660: Expected O, but got Unknown
				//IL_0667: Unknown result type (might be due to invalid IL or missing references)
				//IL_066c: Unknown result type (might be due to invalid IL or missing references)
				//IL_067b: Unknown result type (might be due to invalid IL or missing references)
				//IL_069d: Unknown result type (might be due to invalid IL or missing references)
				//IL_06ac: Expected O, but got Unknown
				//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
				//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
				//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
				//IL_06e9: Unknown result type (might be due to invalid IL or missing references)
				//IL_06f8: Expected O, but got Unknown
				//IL_06ff: Unknown result type (might be due to invalid IL or missing references)
				//IL_0704: Unknown result type (might be due to invalid IL or missing references)
				//IL_0713: Unknown result type (might be due to invalid IL or missing references)
				//IL_0736: Unknown result type (might be due to invalid IL or missing references)
				//IL_0745: Expected O, but got Unknown
				//IL_081e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0828: Unknown result type (might be due to invalid IL or missing references)
				//IL_082d: Unknown result type (might be due to invalid IL or missing references)
				//IL_083c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0868: Unknown result type (might be due to invalid IL or missing references)
				//IL_0877: Expected O, but got Unknown
				//IL_0878: Unknown result type (might be due to invalid IL or missing references)
				//IL_0882: Unknown result type (might be due to invalid IL or missing references)
				//IL_0887: Unknown result type (might be due to invalid IL or missing references)
				//IL_0896: Unknown result type (might be due to invalid IL or missing references)
				//IL_08c5: Unknown result type (might be due to invalid IL or missing references)
				//IL_08d4: Expected O, but got Unknown
				//IL_08d5: Unknown result type (might be due to invalid IL or missing references)
				//IL_08df: Unknown result type (might be due to invalid IL or missing references)
				//IL_08e4: Unknown result type (might be due to invalid IL or missing references)
				//IL_08f3: Unknown result type (might be due to invalid IL or missing references)
				//IL_091f: Unknown result type (might be due to invalid IL or missing references)
				//IL_092e: Expected O, but got Unknown
				//IL_0488: Unknown result type (might be due to invalid IL or missing references)
				//IL_048f: Expected O, but got Unknown
				//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
				//IL_0500: Unknown result type (might be due to invalid IL or missing references)
				//IL_0507: Expected O, but got Unknown
				//IL_0560: Unknown result type (might be due to invalid IL or missing references)
				//IL_0578: Unknown result type (might be due to invalid IL or missing references)
				//IL_057f: Expected O, but got Unknown
				//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
				//IL_037f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0384: Unknown result type (might be due to invalid IL or missing references)
				//IL_0393: Unknown result type (might be due to invalid IL or missing references)
				//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
				//IL_03d5: Expected O, but got Unknown
				//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
				//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
				//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
				//IL_0410: Unknown result type (might be due to invalid IL or missing references)
				//IL_041f: Expected O, but got Unknown
				//IL_0426: Unknown result type (might be due to invalid IL or missing references)
				//IL_042b: Unknown result type (might be due to invalid IL or missing references)
				//IL_043a: Unknown result type (might be due to invalid IL or missing references)
				//IL_046d: Unknown result type (might be due to invalid IL or missing references)
				//IL_047c: Expected O, but got Unknown
				if (((FrameworkElement)ModMain.FrmMain).IsLoaded)
				{
					bool flag = Conversions.ToBoolean(ModBase.Setup.Get("UiAcrylic"));
					ApplyAcrylicEffect();
					bool flag2 = false;
					if (ThemeNow >= 5 && ThemeNow <= 13)
					{
						try
						{
							Uri val2 = new Uri("pack://application:,,,/Images/Themes/" + Conversions.ToString(ThemeNow) + ".png", (UriKind)1);
							ImageBrush background = new ImageBrush
							{
								ImageSource = (ImageSource)new BitmapImage(val2),
								Stretch = (Stretch)3
							};
							((Panel)ModMain.FrmMain.PanTitle).Background = (Brush)(object)background;
							flag2 = true;
							ModBase.Log($"[Theme] 已加载主题 {ThemeNow} 的背景图片", ModBase.LogLevel.Debug);
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							ModBase.Log(ex2, "加载主题背景图片失败：主题 " + Conversions.ToString(ThemeNow));
							ProjectData.ClearProjectError();
						}
					}
					if (!flag2)
					{
						LinearGradientBrush val3 = new LinearGradientBrush
						{
							EndPoint = new Point(1.0, 0.0),
							StartPoint = new Point(0.0, 0.0)
						};
						if (ThemeNow == 5)
						{
							((GradientBrush)val3).GradientStops.Add(new GradientStop
							{
								Offset = 0.0,
								Color = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 25.0)
							});
							((GradientBrush)val3).GradientStops.Add(new GradientStop
							{
								Offset = 0.5,
								Color = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 15.0)
							});
							((GradientBrush)val3).GradientStops.Add(new GradientStop
							{
								Offset = 1.0,
								Color = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 25.0)
							});
							((Panel)ModMain.FrmMain.PanTitle).Background = (Brush)(object)val3;
							((Freezable)((Panel)ModMain.FrmMain.PanTitle).Background).Freeze();
						}
						else if (ThemeNow == 15)
						{
							((GradientBrush)val3).GradientStops.Add(new GradientStop
							{
								Offset = 0.0,
								Color = new ModBase.MyColor(122.0, 203.0, 245.0)
							});
							((GradientBrush)val3).GradientStops.Add(new GradientStop
							{
								Offset = 0.5,
								Color = new ModBase.MyColor(255.0, 255.0, 255.0)
							});
							((GradientBrush)val3).GradientStops.Add(new GradientStop
							{
								Offset = 1.0,
								Color = new ModBase.MyColor(234.0, 172.0, 184.0)
							});
							((Panel)ModMain.FrmMain.PanTitle).Background = (Brush)(object)val3;
							((Freezable)((Panel)ModMain.FrmMain.PanTitle).Background).Freeze();
						}
						else if (ThemeNow != 12 && ThemeDontClick != 2)
						{
							if (ColorHueTopbarDelta is int)
							{
								((GradientBrush)val3).GradientStops.Add(new GradientStop
								{
									Offset = 0.0,
									Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.SubtractObject((object)ColorHue, ColorHueTopbarDelta)), ColorSat, 48 + ColorLightAdjust)
								});
								((GradientBrush)val3).GradientStops.Add(new GradientStop
								{
									Offset = 0.5,
									Color = new ModBase.MyColor().FromHSL2(ColorHue, ColorSat, 54 + ColorLightAdjust)
								});
								((GradientBrush)val3).GradientStops.Add(new GradientStop
								{
									Offset = 1.0,
									Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.AddObject((object)ColorHue, ColorHueTopbarDelta)), ColorSat, 48 + ColorLightAdjust)
								});
							}
							else
							{
								GradientStopCollection gradientStops = ((GradientBrush)val3).GradientStops;
								GradientStop val4 = new GradientStop();
								val4.Offset = 0.0;
								val4.Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.AddObject((object)ColorHue, NewLateBinding.LateIndexGet(ColorHueTopbarDelta, new object[] { 0 }, (string[])null))), ColorSat, 48 + ColorLightAdjust);
								gradientStops.Add(val4);
								GradientStopCollection gradientStops2 = ((GradientBrush)val3).GradientStops;
								val4 = new GradientStop();
								val4.Offset = 0.5;
								val4.Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.AddObject((object)ColorHue, NewLateBinding.LateIndexGet(ColorHueTopbarDelta, new object[] { 1 }, (string[])null))), ColorSat, 54 + ColorLightAdjust);
								gradientStops2.Add(val4);
								GradientStopCollection gradientStops3 = ((GradientBrush)val3).GradientStops;
								val4 = new GradientStop();
								val4.Offset = 1.0;
								val4.Color = new ModBase.MyColor().FromHSL2(Conversions.ToDouble(Operators.AddObject((object)ColorHue, NewLateBinding.LateIndexGet(ColorHueTopbarDelta, new object[] { 2 }, (string[])null))), ColorSat, 48 + ColorLightAdjust);
								gradientStops3.Add(val4);
							}
							((Panel)ModMain.FrmMain.PanTitle).Background = (Brush)(object)val3;
							((Freezable)((Panel)ModMain.FrmMain.PanTitle).Background).Freeze();
						}
						else
						{
							((GradientBrush)val3).GradientStops.Add(new GradientStop
							{
								Offset = 0.0,
								Color = new ModBase.MyColor().FromHSL2(ColorHue - 21, ColorSat, 53 + ColorLightAdjust)
							});
							((GradientBrush)val3).GradientStops.Add(new GradientStop
							{
								Offset = 0.33,
								Color = new ModBase.MyColor().FromHSL2(ColorHue - 7, ColorSat, 47 + ColorLightAdjust)
							});
							((GradientBrush)val3).GradientStops.Add(new GradientStop
							{
								Offset = 0.67,
								Color = new ModBase.MyColor().FromHSL2(ColorHue + 7, ColorSat, 47 + ColorLightAdjust)
							});
							((GradientBrush)val3).GradientStops.Add(new GradientStop
							{
								Offset = 1.0,
								Color = new ModBase.MyColor().FromHSL2(ColorHue + 21, ColorSat, 53 + ColorLightAdjust)
							});
							((Panel)ModMain.FrmMain.PanTitle).Background = (Brush)(object)val3;
						}
					}
					Brush val5 = null;
					if (flag)
					{
						val5 = null;
					}
					else if (Conversions.ToBoolean(ModBase.Setup.Get("UiBackgroundColorful")))
					{
						val5 = (Brush)new LinearGradientBrush
						{
							EndPoint = new Point(0.1, 1.0),
							StartPoint = new Point(0.9, 0.0)
						};
						int num;
						int num2;
						if (ThemeNow == 14 && ColorHueTopbarDelta is int)
						{
							num = Conversions.ToInteger(Operators.AddObject((object)ColorHue, ColorHueTopbarDelta));
							num2 = Conversions.ToInteger(Operators.SubtractObject((object)ColorHue, ColorHueTopbarDelta));
						}
						else
						{
							num = ColorHue - 15;
							num2 = ColorHue + 15;
						}
						((GradientBrush)(LinearGradientBrush)val5).GradientStops.Add(new GradientStop
						{
							Offset = -0.1,
							Color = new ModBase.MyColor().FromHSL2(num, (double)ColorSat * 0.8, GetDarkThemeLight(80.0))
						});
						((GradientBrush)(LinearGradientBrush)val5).GradientStops.Add(new GradientStop
						{
							Offset = 0.4,
							Color = new ModBase.MyColor().FromHSL2(ColorHue, (double)ColorSat * 0.8, GetDarkThemeLight(90.0))
						});
						((GradientBrush)(LinearGradientBrush)val5).GradientStops.Add(new GradientStop
						{
							Offset = 1.1,
							Color = new ModBase.MyColor().FromHSL2(num2, (double)ColorSat * 0.8, GetDarkThemeLight(80.0))
						});
					}
					else
					{
						val5 = new ModBase.MyColor(IsDarkMode ? 20 : 245, IsDarkMode ? 20 : 245, IsDarkMode ? 20 : 245);
					}
					((Panel)ModMain.FrmMain.PanForm).Background = val5;
					if (((Panel)ModMain.FrmMain.PanForm).Background != null)
					{
						((Freezable)((Panel)ModMain.FrmMain.PanForm).Background).Freeze();
					}
					RefreshAllContextMenuThemes();
				}
			});
			_Closure_0024__._0024I91_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
	}

	internal static void ThemeCheckAll(bool EffectSetup)
	{
	}

	internal static bool ThemeCheckOne(int Id)
	{
		return true;
	}

	internal static bool ThemeUnlock(int Id, bool ShowDoubleHint = true, string UnlockHint = null)
	{
		return false;
	}

	internal static bool ThemeCheckGold(string Code = null)
	{
		return false;
	}

	internal static bool? DonateCodeInput()
	{
		return null;
	}

	public static void UpdateCheckByButton()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		if (IsCheckingUpdates)
		{
			ModMain.Hint("正在检查更新中，请稍后再试……");
			return;
		}
		ModMain.Hint("正在检查版本信息...");
		object action;
		if (_Closure_0024__._0024I102_002D0 != null)
		{
			action = _Closure_0024__._0024I102_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				try
				{
					NoticeUserUpdate();
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "[Update] 获取启动器版本信息失败", ModBase.LogLevel.Hint);
					ModMain.Hint("获取启动器版本信息失败，请检查网络连接", ModMain.HintType.Critical);
					ProjectData.ClearProjectError();
				}
			};
			_Closure_0024__._0024I102_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInNewThread((Action)action, null, (ThreadPriority)2);
	}

	public static bool IsVerisonLatest()
	{
		bool result;
		try
		{
			result = RemoteServer.IsLatest(Conversions.ToBoolean(IsUpdBetaChannel) ? UpdateChannel.beta : UpdateChannel.stable, ModBase.IsArm64System ? UpdateArch.arm64 : UpdateArch.x64, SemVer.Parse("2.13.3"), 413);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "无法获取最新版本信息，请检查网络连接", ModBase.LogLevel.Hint);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	public static void NoticeUserUpdate(bool Silent = false)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		if (!IsVerisonLatest())
		{
			VersionDataModel versionDataModel = null;
			System.Exception ex = null;
			ModBase.RunInNewThread((Action)([SpecialName] () =>
			{
				try
				{
					versionDataModel = RemoteServer.GetLatestVersion(Conversions.ToBoolean(IsUpdBetaChannel) ? UpdateChannel.beta : UpdateChannel.stable, ModBase.IsArm64System ? UpdateArch.arm64 : UpdateArch.x64);
				}
				catch (System.Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					System.Exception ex3 = ex2;
					ex = ex3;
					ProjectData.ClearProjectError();
				}
			}), null, (ThreadPriority)2).Join();
			if (versionDataModel == null)
			{
				ModBase.Log(ex, "[Update] 检查更新失败", ModBase.LogLevel.Msgbox);
			}
			else if (!ModBase.StartsWithF(versionDataModel.VersionName, "2.12.") && !ModBase.ContainsF(ModBase.ShellAndGetOutput("cmd", "/c dotnet --list-runtimes"), "Microsoft.WindowsDesktop.App 8.0.", IgnoreCase: true))
			{
				string caption = string.Format("发现了启动器更新（版本 {0}），但是新版本要求你的电脑安装 .NET 8 才可以运行。{1}你需要先安装 .NET 8，然后前往官网下载新版本启动器。{2}{3}点击下方按钮打开网页，选择 ⌈.NET 桌面运行时⌋ 中的 {4} 选项下载。", new object[5]
				{
					versionDataModel.VersionName,
					"\r\n",
					"\r\n",
					"\r\n",
					ModBase.IsArm64System ? "Arm64" : "x64"
				});
				object button1Action;
				if (_Closure_0024__._0024I104_002D1 != null)
				{
					button1Action = _Closure_0024__._0024I104_002D1;
				}
				else
				{
					Action val = [SpecialName] () =>
					{
						ModBase.OpenWebsite("https://get.dot.net/8");
					};
					_Closure_0024__._0024I104_002D1 = val;
					button1Action = (object)val;
				}
				ModMain.MyMsgBox(caption, "启动器更新 - 缺少运行环境", "下载 .NET 8 运行时", "取消", "", IsWarn: false, HighLight: true, ForceWait: true, (Action)button1Action);
			}
			else if (ModMain.MyMsgBoxMarkdown(string.Format("启动器有新版本可用（{0} -> {1}){2}{3}**更新日志：**{4}{5}{6}{7}请前往官网下载最新版本。", new object[] { "2.13.3", versionDataModel.VersionName, "\r\n", "\r\n", "\r\n", versionDataModel.Changelog, "\r\n", "\r\n" }), "发现新版本", "前往下载", "取消") == 1)
			{
				ModBase.OpenWebsite("https://github.com/PCLPro/PCLPro/releases");
			}
		}
		else if (!Silent)
		{
			ModMain.Hint("启动器已是最新版 2.13.3，无须更新啦！", ModMain.HintType.Finish);
		}
	}

	public static void UpdateStart(bool Slient, string ReceivedKey = null, bool ForceValidated = false)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		string output = ModBase.ExePath + "PCL\\PCL Pro-N.exe";
		object _0024VB_0024NonLocal__0024VB_0024Closure_ = null;
		ModBase.RunInNewThread((Action)([SpecialName] () =>
		{
			try
			{
				_Closure_0024__105_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__105_002D1();
				CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2 = (_Closure_0024__105_002D0)_0024VB_0024NonLocal__0024VB_0024Closure_;
				CS_0024_003C_003E8__locals0._0024VB_0024Local_version = RemoteServer.GetLatestVersion(Conversions.ToBoolean(IsUpdBetaChannel) ? UpdateChannel.beta : UpdateChannel.stable, ModBase.IsArm64System ? UpdateArch.arm64 : UpdateArch.x64);
				ModBase.WriteFile($"{ModBase.PathTemp}CEUpdateLog.md", CS_0024_003C_003E8__locals0._0024VB_0024Local_version.Changelog);
				List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
				val.AddRange((System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)RemoteServer.GetDownloadLoader(Conversions.ToBoolean(IsUpdBetaChannel) ? UpdateChannel.beta : UpdateChannel.stable, ModBase.IsArm64System ? UpdateArch.arm64 : UpdateArch.x64, output));
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("校验更新", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					CS_0024_003C_003E8__locals0._Lambda_0024__1();
				}, null, (ThreadPriority)2));
				if (!Slient)
				{
					val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("安装更新", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
					{
						((VB_0024AnonymousDelegate_8)([SpecialName] () =>
						{
							UpdateRestart(TriggerRestartAndByEnd: true);
						}))();
					}, null, (ThreadPriority)2));
				}
				ModLoader.LoaderCombo<JObject> loaderCombo = new ModLoader.LoaderCombo<JObject>("启动器更新", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
				loaderCombo.Start();
				if (Slient)
				{
					IsUpdateWaitingRestart = true;
				}
				else
				{
					ModLoader.LoaderTaskbarAdd(loaderCombo);
					ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
					ModMain.FrmMain.BtnExtraDownload.Ribble();
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "[Update] 下载启动器更新文件失败", ModBase.LogLevel.Hint);
				ModMain.Hint("下载启动器更新文件失败，请检查网络连接", ModMain.HintType.Critical);
				ProjectData.ClearProjectError();
			}
		}), null, (ThreadPriority)2);
	}

	public static void UpdateRestart(bool TriggerRestartAndByEnd)
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00ab: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		try
		{
			string text = ModBase.ExePath + "PCL\\PCL Pro-N.exe";
			if (!File.Exists(text))
			{
				ModBase.Log("[System] 更新失败：未找到更新文件");
				return;
			}
			string text2 = $"update {Process.GetCurrentProcess().Id} \"{ModBase.ExePathWithName}\" \"{text}\" true";
			ModBase.Log("[System] 更新程序启动，参数：" + text2);
			Process.Start(new ProcessStartInfo(text)
			{
				WindowStyle = (ProcessWindowStyle)1,
				CreateNoWindow = true,
				Arguments = text2
			});
			if (TriggerRestartAndByEnd)
			{
				ModMain.FrmMain.EndProgram(SendWarning: false);
				ModBase.Log("[System] 已由于更新强制结束程序");
			}
		}
		catch (Win32Exception val)
		{
			ProjectData.SetProjectError((System.Exception)val);
			Win32Exception ex = val;
			ModBase.Log((System.Exception)(object)ex, "自动更新时触发 Win32 错误，疑似被拦截");
			if (ModMain.MyMsgBox(string.Format("由于被 Windows 安全中心拦截，或者存在权限问题，导致 PCL 无法更新。{0}请将 PCL 所在文件夹加入白名单，或者手动用 {1}PCL\\PCL Pro-N.exe 替换当前文件！", (object)"\r\n", (object)ModBase.ExePath), "更新失败", "查看帮助", "确定", "", IsWarn: true) == 1)
			{
				ModEvent.TryStartEvent("打开帮助", "启动器/Microsoft Defender 添加排除项.json");
			}
			ProjectData.ClearProjectError();
		}
	}

	public static void UpdateReplace(int ProcessId, string OldFileName, string NewFileName, bool TriggerRestart)
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_008d: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Process processById = Process.GetProcessById(ProcessId);
			if (!processById.HasExited)
			{
				processById.Kill();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		System.Exception ex3 = null;
		int num = 0;
		do
		{
			try
			{
				if (File.Exists(OldFileName))
				{
					File.Delete(OldFileName);
				}
				File.Exists(OldFileName);
			}
			catch (System.Exception ex4)
			{
				ProjectData.SetProjectError(ex4);
				System.Exception ex5 = ex4;
				ex3 = ex5;
				ProjectData.ClearProjectError();
			}
			finally
			{
				Thread.Sleep(500);
			}
			num = checked(num + 1);
		}
		while (num <= 4);
		if (!File.Exists(OldFileName) && File.Exists(NewFileName))
		{
			try
			{
				ModBase.CopyFile(NewFileName, OldFileName);
			}
			catch (UnauthorizedAccessException val)
			{
				ProjectData.SetProjectError((System.Exception)val);
				UnauthorizedAccessException val2 = val;
				Interaction.MsgBox((object)("PCL 更新失败：权限不足。请手动复制 PCL 文件夹下的新版本程序。\r\n若 PCL 位于桌面或 C 盘，你可以尝试将其挪到其他文件夹，这可能可以解决权限问题。\r\n" + ((System.Exception)(object)val2).Message), (MsgBoxStyle)16, (object)"更新失败");
				ProjectData.ClearProjectError();
			}
			catch (System.Exception ex6)
			{
				ProjectData.SetProjectError(ex6);
				System.Exception ex7 = ex6;
				Interaction.MsgBox((object)("PCL 更新失败：无法复制新文件。请手动复制 PCL 文件夹下的新版本程序。\r\n" + ex7.Message), (MsgBoxStyle)16, (object)"更新失败");
				ProjectData.ClearProjectError();
				return;
			}
			if (TriggerRestart)
			{
				try
				{
					Process.Start(OldFileName);
				}
				catch (System.Exception ex8)
				{
					ProjectData.SetProjectError(ex8);
					System.Exception ex9 = ex8;
					Interaction.MsgBox((object)("PCL 更新失败：无法重新启动。\r\n" + ex9.Message), (MsgBoxStyle)16, (object)"更新失败");
					ProjectData.ClearProjectError();
				}
			}
		}
		else if (ex3 is UnauthorizedAccessException)
		{
			Interaction.MsgBox((object)string.Concat(new string[5]
			{
				"由于权限不足，PCL 无法完成更新。请尝试：\r\n",
				(ModBase.StartsWithF(ModBase.ExePath, Environment.GetFolderPath((System.Environment.SpecialFolder)0)) || ModBase.StartsWithF(ModBase.ExePath, Environment.GetFolderPath((System.Environment.SpecialFolder)5))) ? " - 将 PCL 文件移动到桌面、文档以外的文件夹（这或许可以一劳永逸地解决权限问题）\r\n" : "",
				ModBase.StartsWithF(ModBase.ExePath, "C", IgnoreCase: true) ? " - 将 PCL 文件移动到 C 盘以外的文件夹（这或许可以一劳永逸地解决权限问题）\r\n" : "",
				" - 右键以管理员身份运行 PCL\r\n - 手动复制已下载到 PCL 文件夹下的新版本程序，覆盖原程序\r\n\r\n",
				ex3.Message
			}), (MsgBoxStyle)16, (object)"更新失败");
		}
		else
		{
			Interaction.MsgBox((object)("PCL 更新失败：无法删除原文件。请手动复制已下载到 PCL 文件夹下的新版本程序覆盖原程序。\r\n" + ex3.Message), (MsgBoxStyle)16, (object)"更新失败");
		}
	}

	internal static void DownloadLatestPCL(ModLoader.LoaderBase LoaderToSyncProgress = null)
	{
		string text = ModBase.PathTemp + "CE-Latest.exe";
		VersionDataModel latestVersion = RemoteServer.GetLatestVersion(UpdateChannel.stable, ModBase.IsArm64System ? UpdateArch.arm64 : UpdateArch.x64);
		if (latestVersion == null)
		{
			throw new System.Exception("无法获取更新");
		}
		if (File.Exists(text) && Operators.CompareString(ModBase.GetFileSHA256(text), latestVersion.SHA256, false) == 0)
		{
			ModBase.Log("[System] 最新版 PCL 已存在，跳过下载");
			return;
		}
		if (Operators.CompareString(ModBase.GetFileSHA256(ModBase.ExePathWithName), latestVersion.SHA256, false) == 0)
		{
			ModBase.CopyFile(ModBase.ExePathWithName, text);
			return;
		}
		List<ModLoader.LoaderBase> downloadLoader = RemoteServer.GetDownloadLoader(UpdateChannel.stable, ModBase.IsArm64System ? UpdateArch.arm64 : UpdateArch.x64, text);
		ModLoader.LoaderCombo<int> loaderCombo = new ModLoader.LoaderCombo<int>("下载最新稳定版", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)downloadLoader);
		loaderCombo.Start();
		loaderCombo.WaitForExit();
	}

	private static void LoadOnlineInfo()
	{
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		object objectValue = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("SystemSystemUpdate"));
		object objectValue2 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("SystemSystemActivity"));
		object obj = objectValue;
		if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
		{
			if (!IsVerisonLatest())
			{
				UpdateStart(Slient: true);
			}
		}
		else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			NoticeUserUpdate(Silent: true);
		}
		else if (Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)2, false)) || Conversions.ToBoolean(Operators.CompareObjectEqual(obj, (object)3, false)))))
		{
			return;
		}
		if (!Operators.ConditionalCompareObjectLessEqual(objectValue2, (object)1, false))
		{
			return;
		}
		_Closure_0024__110_002D0 arg = default(_Closure_0024__110_002D0);
		_Closure_0024__110_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__110_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowedAnnounced = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)ModBase.Setup.Get("SystemSystemAnnouncement").ToString().Split("|".ToCharArray(), (StringSplitOptions)1));
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowAnnounce = Enumerable.ToList<VersionAnnouncementContentModel>(Enumerable.Where<VersionAnnouncementContentModel>((System.Collections.Generic.IEnumerable<VersionAnnouncementContentModel>)RemoteServer.GetAnnouncementList().content, (Func<VersionAnnouncementContentModel, bool>)([SpecialName] (VersionAnnouncementContentModel x) => !CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowedAnnounced.Contains(x.id))));
		ModBase.Log("[System] 需要展示的公告数量：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowAnnounce.Count);
		ModBase.RunInNewThread((Action)([SpecialName] () =>
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Expected O, but got Unknown
			//IL_00a9: Expected O, but got Unknown
			System.Collections.Generic.IEnumerator<VersionAnnouncementContentModel> enumerator = default(System.Collections.Generic.IEnumerator<VersionAnnouncementContentModel>);
			try
			{
				enumerator = CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowAnnounce.GetEnumerator();
				_Closure_0024__110_002D1 closure_0024__110_002D = default(_Closure_0024__110_002D1);
				while (enumerator.MoveNext())
				{
					closure_0024__110_002D = new _Closure_0024__110_002D1(closure_0024__110_002D);
					closure_0024__110_002D._0024VB_0024Local_item = enumerator.Current;
					ModMain.MyMsgBox(closure_0024__110_002D._0024VB_0024Local_item.detail, closure_0024__110_002D._0024VB_0024Local_item.title, (closure_0024__110_002D._0024VB_0024Local_item.btn1 == null) ? "" : closure_0024__110_002D._0024VB_0024Local_item.btn1.text, (closure_0024__110_002D._0024VB_0024Local_item.btn2 == null) ? "" : closure_0024__110_002D._0024VB_0024Local_item.btn2.text, "关闭", IsWarn: false, HighLight: true, ForceWait: false, new Action(closure_0024__110_002D._Lambda_0024__2), new Action(closure_0024__110_002D._Lambda_0024__3));
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}), null, (ThreadPriority)2);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowedAnnounced.AddRange((System.Collections.Generic.IEnumerable<string>)Enumerable.ToList<string>(Enumerable.Select<VersionAnnouncementContentModel, string>((System.Collections.Generic.IEnumerable<VersionAnnouncementContentModel>)CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowAnnounce, (Func<VersionAnnouncementContentModel, string>)([SpecialName] (VersionAnnouncementContentModel x) => x.id))));
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowedAnnounced = Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowedAnnounced));
		ModBase.Setup.Set("SystemSystemAnnouncement", ModBase.Join((System.Collections.IEnumerable)CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowedAnnounced, "|"));
	}

	internal static void GetSystemInfo()
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		try
		{
			ManagementObjectSearcher val = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
			System.Management.ManagementObjectCollection.ManagementObjectEnumerator enumerator = default(System.Management.ManagementObjectCollection.ManagementObjectEnumerator);
			try
			{
				enumerator = val.Get().GetEnumerator();
				if (enumerator.MoveNext())
				{
					CPUName = ((ManagementBaseObject)(ManagementObject)enumerator.Current)["Name"].ToString().Trim();
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "获取 CPU 信息时出错", ModBase.LogLevel.Normal);
			ProjectData.ClearProjectError();
		}
		try
		{
			ManagementObjectSearcher val2 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");
			System.Management.ManagementObjectCollection.ManagementObjectEnumerator enumerator2 = default(System.Management.ManagementObjectCollection.ManagementObjectEnumerator);
			try
			{
				enumerator2 = val2.Get().GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ManagementObject val3 = (ManagementObject)enumerator2.Current;
					GPUInfo gPUInfo = new GPUInfo();
					if (((ManagementBaseObject)val3)["Name"] != null)
					{
						gPUInfo.Name = Conversions.ToString(((ManagementBaseObject)val3)["Name"]);
					}
					if (((ManagementBaseObject)val3)["AdapterRAM"] != null)
					{
						long memory = Conversions.ToLong(((ManagementBaseObject)val3)["AdapterRAM"]) / 1048576;
						gPUInfo.Memory = memory;
					}
					if (((ManagementBaseObject)val3)["DriverVersion"] != null)
					{
						gPUInfo.DriverVersion = Conversions.ToString(((ManagementBaseObject)val3)["DriverVersion"]);
					}
					GPUs.Add(gPUInfo);
				}
			}
			finally
			{
				((System.IDisposable)enumerator2)?.Dispose();
			}
			ModBase.Log("已获取系统环境信息");
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			ModBase.Log(ex4, "获取 GPU 信息时出错", ModBase.LogLevel.Normal);
			ProjectData.ClearProjectError();
		}
	}

	private static void RefreshAllContextMenuThemes()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		try
		{
			EventManager.RegisterClassHandler(typeof(ContextMenu), ContextMenu.OpenedEvent, (System.Delegate)new RoutedEventHandler(OnContextMenuOpened));
			object action;
			if (_Closure_0024__._0024I117_002D0 != null)
			{
				action = _Closure_0024__._0024I117_002D0;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					//IL_0018: Unknown result type (might be due to invalid IL or missing references)
					//IL_0022: Expected O, but got Unknown
					foreach (Window window in Application.Current.Windows)
					{
						RefreshContextMenusInElement((DependencyObject)window);
					}
				};
				_Closure_0024__._0024I117_002D0 = val;
				action = (object)val;
			}
			ModBase.RunInUi((Action)action);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "刷新ContextMenu主题时出错");
			ProjectData.ClearProjectError();
		}
	}

	private static void OnContextMenuOpened(object sender, RoutedEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (sender is ContextMenu)
			{
				ContextMenu val = (ContextMenu)sender;
				((DependencyObject)val).ClearValue(FrameworkElement.StyleProperty);
				((FrameworkElement)val).UpdateDefaultStyle();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private static void RefreshContextMenusInElement(DependencyObject element)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		if (element == null)
		{
			return;
		}
		checked
		{
			try
			{
				if (element is FrameworkElement)
				{
					FrameworkElement val = (FrameworkElement)element;
					if (val.ContextMenu != null)
					{
						((DependencyObject)val.ContextMenu).ClearValue(FrameworkElement.StyleProperty);
						((FrameworkElement)val.ContextMenu).UpdateDefaultStyle();
					}
				}
				int num = VisualTreeHelper.GetChildrenCount(element) - 1;
				for (int i = 0; i <= num; i++)
				{
					RefreshContextMenusInElement(VisualTreeHelper.GetChild(element, i));
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
		}
	}

	internal static void ApplyAcrylicEffect()
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		try
		{
			if (ModMain.FrmMain == null || !((FrameworkElement)ModMain.FrmMain).IsLoaded)
			{
				return;
			}
			if (Conversions.ToBoolean(ModBase.Setup.Get("UiAcrylic")))
			{
				int num = Conversions.ToInteger(ModBase.Setup.Get("UiAcrylicBlur"));
				double num2 = (double)Conversions.ToInteger(ModBase.Setup.Get("UiAcrylicOpacity")) / 1000.0;
				BlurEffect effect = new BlurEffect
				{
					Radius = num,
					KernelType = (KernelType)0,
					RenderingBias = (RenderingBias)1
				};
				if (ModMain.FrmMain.PanBack != null)
				{
					((UIElement)ModMain.FrmMain.PanBack).Effect = (Effect)(object)effect;
				}
				try
				{
					Border val = (Border)((FrameworkElement)ModMain.FrmMain).FindName("BorderForm");
					if (val != null)
					{
						ModBase.MyColor myColor = new ModBase.MyColor
						{
							A = (int)checked((byte)Math.Round(num2 * 255.0)),
							R = (IsDarkMode ? 40 : 240),
							G = (IsDarkMode ? 40 : 240),
							B = (IsDarkMode ? 40 : 240)
						};
						val.Background = myColor;
						((Freezable)val.Background).Freeze();
					}
					return;
				}
				catch (System.Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (ModMain.FrmMain.PanBack != null)
			{
				((UIElement)ModMain.FrmMain.PanBack).Effect = null;
			}
			try
			{
				Border val2 = (Border)((FrameworkElement)ModMain.FrmMain).FindName("BorderForm");
				if (val2 != null)
				{
					val2.Background = null;
				}
			}
			catch (System.Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ProjectData.ClearProjectError();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "应用亚克力效果失败");
			ProjectData.ClearProjectError();
		}
	}
}
