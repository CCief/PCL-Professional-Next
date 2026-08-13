using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.App.Configuration;
using PCL.Core.UI;
using PCL.Core.Utils.Exts;

namespace PCL;

[DesignerGenerated]
public class PageSetupSystem : MyPageRight, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static VB_0024AnonymousDelegate_22<object, object> _0024I11_002D0;

		public static VB_0024AnonymousDelegate_22<object, object> _0024I11_002D1;

		public static VB_0024AnonymousDelegate_22<object, object> _0024I11_002D2;

		public static VB_0024AnonymousDelegate_22<object, string> _0024I11_002D3;

		public static VB_0024AnonymousDelegate_22<object, object> _0024I11_002D4;

		public static SelectionChangedEventHandler _0024IR35_002D1;

		public static SelectionChangedEventHandler _0024IR39_002D2;

		public static MySlider.ChangeEventHandler _0024IR43_002D3;

		public static MySlider.ChangeEventHandler _0024IR47_002D4;

		public static MyCheckBox.ChangeEventHandler _0024IR51_002D5;

		public static MyCheckBox.ChangeEventHandler _0024IR55_002D6;

		public static SelectionChangedEventHandler _0024IR59_002D7;

		public static SelectionChangedEventHandler _0024IR63_002D8;

		public static SelectionChangedEventHandler _0024IR67_002D9;

		public static MyCheckBox.ChangeEventHandler _0024IR71_002D10;

		public static MyCheckBox.ChangeEventHandler _0024IR75_002D11;

		public static MyCheckBox.ChangeEventHandler _0024IR79_002D12;

		public static MyCheckBox.ChangeEventHandler _0024IR83_002D13;

		public static MyCheckBox.ChangeEventHandler _0024IR87_002D14;

		public static SelectionChangedEventHandler _0024IR91_002D15;

		public static SelectionChangedEventHandler _0024IR95_002D16;

		public static SelectionChangedEventHandler _0024IR99_002D17;

		public static RoutedEventHandler _0024IR103_002D18;

		public static MySlider.ChangeEventHandler _0024IR107_002D19;

		public static MySlider.ChangeEventHandler _0024IR111_002D20;

		public static MyCheckBox.ChangeEventHandler _0024IR115_002D21;

		public static IMyRadio.CheckEventHandler _0024IR131_002D22;

		public static IMyRadio.CheckEventHandler _0024IR135_002D23;

		public static IMyRadio.CheckEventHandler _0024IR139_002D24;

		public static IMyRadio.CheckEventHandler _0024IR167_002D25;

		public static IMyRadio.CheckEventHandler _0024IR171_002D26;

		public static IMyRadio.CheckEventHandler _0024IR179_002D27;

		public static IMyRadio.CheckEventHandler _0024IR183_002D28;

		public static MySlider.ChangeEventHandler _0024IR211_002D29;

		public static MyCheckBox.ChangeEventHandler _0024IR215_002D30;

		public static MyCheckBox.ChangeEventHandler _0024IR219_002D31;

		public static MyCheckBox.ChangeEventHandler _0024IR223_002D33;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal object _Lambda_0024__11_002D0(object v)
		{
			return Operators.AddObject(v, (object)1);
		}

		[SpecialName]
		internal object _Lambda_0024__11_002D1(object v)
		{
			if (Operators.ConditionalCompareObjectLessEqual(v, (object)14, false))
			{
				return Operators.ConcatenateObject(Operators.MultiplyObject(Operators.AddObject(v, (object)1), (object)0.1), (object)" M/s");
			}
			if (Operators.ConditionalCompareObjectLessEqual(v, (object)31, false))
			{
				return Operators.ConcatenateObject(Operators.MultiplyObject(Operators.SubtractObject(v, (object)11), (object)0.5), (object)" M/s");
			}
			if (Operators.ConditionalCompareObjectLessEqual(v, (object)41, false))
			{
				return Operators.ConcatenateObject(Operators.SubtractObject(v, (object)21), (object)" M/s");
			}
			return "无限制";
		}

		[SpecialName]
		internal object _Lambda_0024__11_002D2(object v)
		{
			if (!Operators.ConditionalCompareObjectGreater(v, (object)29, false))
			{
				return Operators.ConcatenateObject(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
				{
					Operators.AddObject(Operators.DivideObject(v, (object)10), (object)0.1),
					1
				}, (string[])null, (System.Type[])null, (bool[])null), (object)"x");
			}
			return "关闭";
		}

		[SpecialName]
		internal string _Lambda_0024__11_002D3(object v)
		{
			return $"{Operators.AddObject(v, (object)1)} FPS";
		}

		[SpecialName]
		internal object _Lambda_0024__11_002D4(object v)
		{
			if (Operators.ConditionalCompareObjectLessEqual(v, (object)5, false))
			{
				return Operators.AddObject(Operators.MultiplyObject(v, (object)10), (object)50);
			}
			if (Operators.ConditionalCompareObjectLessEqual(v, (object)13, false))
			{
				return Operators.SubtractObject(Operators.MultiplyObject(v, (object)50), (object)150);
			}
			if (Operators.ConditionalCompareObjectLessEqual(v, (object)28, false))
			{
				return Operators.SubtractObject(Operators.MultiplyObject(v, (object)100), (object)800);
			}
			return "无限制";
		}

		[SpecialName]
		internal void _Lambda_0024__R35_002D1(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R39_002D2(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R43_002D3(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R47_002D4(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R51_002D5(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R55_002D6(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R59_002D7(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R63_002D8(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R67_002D9(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R71_002D10(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R75_002D11(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R79_002D12(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R83_002D13(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R87_002D14(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R91_002D15(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R95_002D16(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R99_002D17(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R103_002D18(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R107_002D19(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R111_002D20(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R115_002D21(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R131_002D22(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R135_002D23(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R139_002D24(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R167_002D25(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R171_002D26(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R179_002D27(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R183_002D28(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R211_002D29(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R215_002D30(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R219_002D31(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R223_002D33(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}
	}

	private bool IsLoaded;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboDownloadSource")]
	private MyComboBox _ComboDownloadSource;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboDownloadVersion")]
	private MyComboBox _ComboDownloadVersion;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderDownloadThread")]
	private MySlider _SliderDownloadThread;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderDownloadSpeed")]
	private MySlider _SliderDownloadSpeed;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckDownloadAutoSelectVersion")]
	private MyCheckBox _CheckDownloadAutoSelectVersion;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckFixAuthlib")]
	private MyCheckBox _CheckFixAuthlib;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboDownloadMod")]
	private MyComboBox _ComboDownloadMod;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboDownloadTranslateV2")]
	private MyComboBox _ComboDownloadTranslateV2;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboModLocalNameStyle")]
	private MyComboBox _ComboModLocalNameStyle;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckDownloadIgnoreQuilt")]
	private MyCheckBox _CheckDownloadIgnoreQuilt;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckDownloadClipboard")]
	private MyCheckBox _CheckDownloadClipboard;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckUpdateRelease")]
	private MyCheckBox _CheckUpdateRelease;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckUpdateSnapshot")]
	private MyCheckBox _CheckUpdateSnapshot;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHelpChinese")]
	private MyCheckBox _CheckHelpChinese;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboSystemUpdate")]
	private MyComboBox _ComboSystemUpdate;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboSystemUpdateBranch")]
	private MyComboBox _ComboSystemUpdateBranch;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboSystemActivity")]
	private MyComboBox _ComboSystemActivity;

	[CompilerGenerated]
	[AccessedThroughProperty("TextSystemCache")]
	private MyTextBox _TextSystemCache;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderAniFPS")]
	private MySlider _SliderAniFPS;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderMaxLog")]
	private MySlider _SliderMaxLog;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckSystemDisableHardwareAcceleration")]
	private MyCheckBox _CheckSystemDisableHardwareAcceleration;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSystemUpdate")]
	private MyButton _BtnSystemUpdate;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSystemSettingExp")]
	private MyButton _BtnSystemSettingExp;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSystemSettingImp")]
	private MyButton _BtnSystemSettingImp;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioHttpProxyType0")]
	private MyRadioBox _RadioHttpProxyType0;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioHttpProxyType1")]
	private MyRadioBox _RadioHttpProxyType1;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioHttpProxyType2")]
	private MyRadioBox _RadioHttpProxyType2;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnApplyHttpProxy")]
	private MyButton _BtnApplyHttpProxy;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioMsApiType0")]
	private MyRadioBox _RadioMsApiType0;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioMsApiType1")]
	private MyRadioBox _RadioMsApiType1;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioCfApiType0")]
	private MyRadioBox _RadioCfApiType0;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioCfApiType1")]
	private MyRadioBox _RadioCfApiType1;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnApplyApiKeys")]
	private MyButton _BtnApplyApiKeys;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnGetMsClientId")]
	private MyButton _BtnGetMsClientId;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnGetCfApiKey")]
	private MyButton _BtnGetCfApiKey;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderDebugAnim")]
	private MySlider _SliderDebugAnim;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckDebugSkipCopy")]
	private MyCheckBox _CheckDebugSkipCopy;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckDebugMode")]
	private MyCheckBox _CheckDebugMode;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckDebugDelay")]
	private MyCheckBox _CheckDebugDelay;

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

	internal virtual MyComboBox ComboDownloadSource
	{
		[CompilerGenerated]
		get
		{
			return _ComboDownloadSource;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR35_002D1 != null)
			{
				obj = _Closure_0024__._0024IR35_002D1;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR35_002D1 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			MyComboBox comboDownloadSource = _ComboDownloadSource;
			if (comboDownloadSource != null)
			{
				((Selector)comboDownloadSource).SelectionChanged -= val2;
			}
			_ComboDownloadSource = value;
			comboDownloadSource = _ComboDownloadSource;
			if (comboDownloadSource != null)
			{
				((Selector)comboDownloadSource).SelectionChanged += val2;
			}
		}
	}

	internal virtual MyComboBox ComboDownloadVersion
	{
		[CompilerGenerated]
		get
		{
			return _ComboDownloadVersion;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR39_002D2 != null)
			{
				obj = _Closure_0024__._0024IR39_002D2;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR39_002D2 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			MyComboBox comboDownloadVersion = _ComboDownloadVersion;
			if (comboDownloadVersion != null)
			{
				((Selector)comboDownloadVersion).SelectionChanged -= val2;
			}
			_ComboDownloadVersion = value;
			comboDownloadVersion = _ComboDownloadVersion;
			if (comboDownloadVersion != null)
			{
				((Selector)comboDownloadVersion).SelectionChanged += val2;
			}
		}
	}

	internal virtual MySlider SliderDownloadThread
	{
		[CompilerGenerated]
		get
		{
			return _SliderDownloadThread;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				SliderChange((MySlider)a0, a1);
			};
			MySlider.PreviewChangeEventHandler obj2 = SliderDownloadThread_PreviewChange;
			MySlider sliderDownloadThread = _SliderDownloadThread;
			if (sliderDownloadThread != null)
			{
				sliderDownloadThread.Change -= obj;
				sliderDownloadThread.PreviewChange -= obj2;
			}
			_SliderDownloadThread = value;
			sliderDownloadThread = _SliderDownloadThread;
			if (sliderDownloadThread != null)
			{
				sliderDownloadThread.Change += obj;
				sliderDownloadThread.PreviewChange += obj2;
			}
		}
	}

	internal virtual MySlider SliderDownloadSpeed
	{
		[CompilerGenerated]
		get
		{
			return _SliderDownloadSpeed;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				SliderChange((MySlider)a0, a1);
			};
			MySlider sliderDownloadSpeed = _SliderDownloadSpeed;
			if (sliderDownloadSpeed != null)
			{
				sliderDownloadSpeed.Change -= obj;
			}
			_SliderDownloadSpeed = value;
			sliderDownloadSpeed = _SliderDownloadSpeed;
			if (sliderDownloadSpeed != null)
			{
				sliderDownloadSpeed.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckDownloadAutoSelectVersion
	{
		[CompilerGenerated]
		get
		{
			return _CheckDownloadAutoSelectVersion;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkDownloadAutoSelectVersion = _CheckDownloadAutoSelectVersion;
			if (checkDownloadAutoSelectVersion != null)
			{
				checkDownloadAutoSelectVersion.Change -= obj;
			}
			_CheckDownloadAutoSelectVersion = value;
			checkDownloadAutoSelectVersion = _CheckDownloadAutoSelectVersion;
			if (checkDownloadAutoSelectVersion != null)
			{
				checkDownloadAutoSelectVersion.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckFixAuthlib
	{
		[CompilerGenerated]
		get
		{
			return _CheckFixAuthlib;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkFixAuthlib = _CheckFixAuthlib;
			if (checkFixAuthlib != null)
			{
				checkFixAuthlib.Change -= obj;
			}
			_CheckFixAuthlib = value;
			checkFixAuthlib = _CheckFixAuthlib;
			if (checkFixAuthlib != null)
			{
				checkFixAuthlib.Change += obj;
			}
		}
	}

	internal virtual MyComboBox ComboDownloadMod
	{
		[CompilerGenerated]
		get
		{
			return _ComboDownloadMod;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR59_002D7 != null)
			{
				obj = _Closure_0024__._0024IR59_002D7;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR59_002D7 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			MyComboBox comboDownloadMod = _ComboDownloadMod;
			if (comboDownloadMod != null)
			{
				((Selector)comboDownloadMod).SelectionChanged -= val2;
			}
			_ComboDownloadMod = value;
			comboDownloadMod = _ComboDownloadMod;
			if (comboDownloadMod != null)
			{
				((Selector)comboDownloadMod).SelectionChanged += val2;
			}
		}
	}

	internal virtual MyComboBox ComboDownloadTranslateV2
	{
		[CompilerGenerated]
		get
		{
			return _ComboDownloadTranslateV2;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR63_002D8 != null)
			{
				obj = _Closure_0024__._0024IR63_002D8;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR63_002D8 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			MyComboBox comboDownloadTranslateV = _ComboDownloadTranslateV2;
			if (comboDownloadTranslateV != null)
			{
				((Selector)comboDownloadTranslateV).SelectionChanged -= val2;
			}
			_ComboDownloadTranslateV2 = value;
			comboDownloadTranslateV = _ComboDownloadTranslateV2;
			if (comboDownloadTranslateV != null)
			{
				((Selector)comboDownloadTranslateV).SelectionChanged += val2;
			}
		}
	}

	internal virtual MyComboBox ComboModLocalNameStyle
	{
		[CompilerGenerated]
		get
		{
			return _ComboModLocalNameStyle;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR67_002D9 != null)
			{
				obj = _Closure_0024__._0024IR67_002D9;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR67_002D9 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			MyComboBox comboModLocalNameStyle = _ComboModLocalNameStyle;
			if (comboModLocalNameStyle != null)
			{
				((Selector)comboModLocalNameStyle).SelectionChanged -= val2;
			}
			_ComboModLocalNameStyle = value;
			comboModLocalNameStyle = _ComboModLocalNameStyle;
			if (comboModLocalNameStyle != null)
			{
				((Selector)comboModLocalNameStyle).SelectionChanged += val2;
			}
		}
	}

	internal virtual MyCheckBox CheckDownloadIgnoreQuilt
	{
		[CompilerGenerated]
		get
		{
			return _CheckDownloadIgnoreQuilt;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkDownloadIgnoreQuilt = _CheckDownloadIgnoreQuilt;
			if (checkDownloadIgnoreQuilt != null)
			{
				checkDownloadIgnoreQuilt.Change -= obj;
			}
			_CheckDownloadIgnoreQuilt = value;
			checkDownloadIgnoreQuilt = _CheckDownloadIgnoreQuilt;
			if (checkDownloadIgnoreQuilt != null)
			{
				checkDownloadIgnoreQuilt.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckDownloadClipboard
	{
		[CompilerGenerated]
		get
		{
			return _CheckDownloadClipboard;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkDownloadClipboard = _CheckDownloadClipboard;
			if (checkDownloadClipboard != null)
			{
				checkDownloadClipboard.Change -= obj;
			}
			_CheckDownloadClipboard = value;
			checkDownloadClipboard = _CheckDownloadClipboard;
			if (checkDownloadClipboard != null)
			{
				checkDownloadClipboard.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckUpdateRelease
	{
		[CompilerGenerated]
		get
		{
			return _CheckUpdateRelease;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkUpdateRelease = _CheckUpdateRelease;
			if (checkUpdateRelease != null)
			{
				checkUpdateRelease.Change -= obj;
			}
			_CheckUpdateRelease = value;
			checkUpdateRelease = _CheckUpdateRelease;
			if (checkUpdateRelease != null)
			{
				checkUpdateRelease.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckUpdateSnapshot
	{
		[CompilerGenerated]
		get
		{
			return _CheckUpdateSnapshot;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkUpdateSnapshot = _CheckUpdateSnapshot;
			if (checkUpdateSnapshot != null)
			{
				checkUpdateSnapshot.Change -= obj;
			}
			_CheckUpdateSnapshot = value;
			checkUpdateSnapshot = _CheckUpdateSnapshot;
			if (checkUpdateSnapshot != null)
			{
				checkUpdateSnapshot.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckHelpChinese
	{
		[CompilerGenerated]
		get
		{
			return _CheckHelpChinese;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHelpChinese = _CheckHelpChinese;
			if (checkHelpChinese != null)
			{
				checkHelpChinese.Change -= obj;
			}
			_CheckHelpChinese = value;
			checkHelpChinese = _CheckHelpChinese;
			if (checkHelpChinese != null)
			{
				checkHelpChinese.Change += obj;
			}
		}
	}

	internal virtual MyComboBox ComboSystemUpdate
	{
		[CompilerGenerated]
		get
		{
			return _ComboSystemUpdate;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR91_002D15 != null)
			{
				obj = _Closure_0024__._0024IR91_002D15;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR91_002D15 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			SelectionChangedEventHandler val3 = new SelectionChangedEventHandler(ComboSystemUpdate_SelectionChanged);
			MyComboBox comboSystemUpdate = _ComboSystemUpdate;
			if (comboSystemUpdate != null)
			{
				((Selector)comboSystemUpdate).SelectionChanged -= val2;
				((Selector)comboSystemUpdate).SelectionChanged -= val3;
			}
			_ComboSystemUpdate = value;
			comboSystemUpdate = _ComboSystemUpdate;
			if (comboSystemUpdate != null)
			{
				((Selector)comboSystemUpdate).SelectionChanged += val2;
				((Selector)comboSystemUpdate).SelectionChanged += val3;
			}
		}
	}

	internal virtual MyComboBox ComboSystemUpdateBranch
	{
		[CompilerGenerated]
		get
		{
			return _ComboSystemUpdateBranch;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR95_002D16 != null)
			{
				obj = _Closure_0024__._0024IR95_002D16;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR95_002D16 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			SelectionChangedEventHandler val3 = new SelectionChangedEventHandler(ComboSystemUpdateBranch_SelectionChanged);
			MyComboBox comboSystemUpdateBranch = _ComboSystemUpdateBranch;
			if (comboSystemUpdateBranch != null)
			{
				((Selector)comboSystemUpdateBranch).SelectionChanged -= val2;
				((Selector)comboSystemUpdateBranch).SelectionChanged -= val3;
			}
			_ComboSystemUpdateBranch = value;
			comboSystemUpdateBranch = _ComboSystemUpdateBranch;
			if (comboSystemUpdateBranch != null)
			{
				((Selector)comboSystemUpdateBranch).SelectionChanged += val2;
				((Selector)comboSystemUpdateBranch).SelectionChanged += val3;
			}
		}
	}

	internal virtual MyComboBox ComboSystemActivity
	{
		[CompilerGenerated]
		get
		{
			return _ComboSystemActivity;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR99_002D17 != null)
			{
				obj = _Closure_0024__._0024IR99_002D17;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR99_002D17 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			SelectionChangedEventHandler val3 = new SelectionChangedEventHandler(ComboSystemActivity_SelectionChanged);
			MyComboBox comboSystemActivity = _ComboSystemActivity;
			if (comboSystemActivity != null)
			{
				((Selector)comboSystemActivity).SelectionChanged -= val2;
				((Selector)comboSystemActivity).SelectionChanged -= val3;
			}
			_ComboSystemActivity = value;
			comboSystemActivity = _ComboSystemActivity;
			if (comboSystemActivity != null)
			{
				((Selector)comboSystemActivity).SelectionChanged += val2;
				((Selector)comboSystemActivity).SelectionChanged += val3;
			}
		}
	}

	internal virtual MyTextBox TextSystemCache
	{
		[CompilerGenerated]
		get
		{
			return _TextSystemCache;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR103_002D18 != null)
			{
				obj = _Closure_0024__._0024IR103_002D18;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR103_002D18 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			MyTextBox textSystemCache = _TextSystemCache;
			if (textSystemCache != null)
			{
				textSystemCache.ValidatedTextChanged -= value2;
			}
			_TextSystemCache = value;
			textSystemCache = _TextSystemCache;
			if (textSystemCache != null)
			{
				textSystemCache.ValidatedTextChanged += value2;
			}
		}
	}

	internal virtual MySlider SliderAniFPS
	{
		[CompilerGenerated]
		get
		{
			return _SliderAniFPS;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				SliderChange((MySlider)a0, a1);
			};
			MySlider sliderAniFPS = _SliderAniFPS;
			if (sliderAniFPS != null)
			{
				sliderAniFPS.Change -= obj;
			}
			_SliderAniFPS = value;
			sliderAniFPS = _SliderAniFPS;
			if (sliderAniFPS != null)
			{
				sliderAniFPS.Change += obj;
			}
		}
	}

	internal virtual MySlider SliderMaxLog
	{
		[CompilerGenerated]
		get
		{
			return _SliderMaxLog;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				SliderChange((MySlider)a0, a1);
			};
			MySlider sliderMaxLog = _SliderMaxLog;
			if (sliderMaxLog != null)
			{
				sliderMaxLog.Change -= obj;
			}
			_SliderMaxLog = value;
			sliderMaxLog = _SliderMaxLog;
			if (sliderMaxLog != null)
			{
				sliderMaxLog.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckSystemDisableHardwareAcceleration
	{
		[CompilerGenerated]
		get
		{
			return _CheckSystemDisableHardwareAcceleration;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = Check_DisableHardwareAcceleration;
			MyCheckBox checkSystemDisableHardwareAcceleration = _CheckSystemDisableHardwareAcceleration;
			if (checkSystemDisableHardwareAcceleration != null)
			{
				checkSystemDisableHardwareAcceleration.Change -= obj;
				checkSystemDisableHardwareAcceleration.Change -= obj2;
			}
			_CheckSystemDisableHardwareAcceleration = value;
			checkSystemDisableHardwareAcceleration = _CheckSystemDisableHardwareAcceleration;
			if (checkSystemDisableHardwareAcceleration != null)
			{
				checkSystemDisableHardwareAcceleration.Change += obj;
				checkSystemDisableHardwareAcceleration.Change += obj2;
			}
		}
	}

	internal virtual MyButton BtnSystemUpdate
	{
		[CompilerGenerated]
		get
		{
			return _BtnSystemUpdate;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnSystemUpdate_Click;
			MyButton btnSystemUpdate = _BtnSystemUpdate;
			if (btnSystemUpdate != null)
			{
				btnSystemUpdate.Click -= obj;
			}
			_BtnSystemUpdate = value;
			btnSystemUpdate = _BtnSystemUpdate;
			if (btnSystemUpdate != null)
			{
				btnSystemUpdate.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnSystemSettingExp
	{
		[CompilerGenerated]
		get
		{
			return _BtnSystemSettingExp;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnSystemSettingExp_Click;
			MyButton btnSystemSettingExp = _BtnSystemSettingExp;
			if (btnSystemSettingExp != null)
			{
				btnSystemSettingExp.Click -= obj;
			}
			_BtnSystemSettingExp = value;
			btnSystemSettingExp = _BtnSystemSettingExp;
			if (btnSystemSettingExp != null)
			{
				btnSystemSettingExp.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnSystemSettingImp
	{
		[CompilerGenerated]
		get
		{
			return _BtnSystemSettingImp;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnSystemSettingImp_Click;
			MyButton btnSystemSettingImp = _BtnSystemSettingImp;
			if (btnSystemSettingImp != null)
			{
				btnSystemSettingImp.Click -= obj;
			}
			_BtnSystemSettingImp = value;
			btnSystemSettingImp = _BtnSystemSettingImp;
			if (btnSystemSettingImp != null)
			{
				btnSystemSettingImp.Click += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioHttpProxyType0
	{
		[CompilerGenerated]
		get
		{
			return _RadioHttpProxyType0;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioHttpProxyType = _RadioHttpProxyType0;
			if (radioHttpProxyType != null)
			{
				radioHttpProxyType.Check -= obj;
			}
			_RadioHttpProxyType0 = value;
			radioHttpProxyType = _RadioHttpProxyType0;
			if (radioHttpProxyType != null)
			{
				radioHttpProxyType.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioHttpProxyType1
	{
		[CompilerGenerated]
		get
		{
			return _RadioHttpProxyType1;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioHttpProxyType = _RadioHttpProxyType1;
			if (radioHttpProxyType != null)
			{
				radioHttpProxyType.Check -= obj;
			}
			_RadioHttpProxyType1 = value;
			radioHttpProxyType = _RadioHttpProxyType1;
			if (radioHttpProxyType != null)
			{
				radioHttpProxyType.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioHttpProxyType2
	{
		[CompilerGenerated]
		get
		{
			return _RadioHttpProxyType2;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioHttpProxyType = _RadioHttpProxyType2;
			if (radioHttpProxyType != null)
			{
				radioHttpProxyType.Check -= obj;
			}
			_RadioHttpProxyType2 = value;
			radioHttpProxyType = _RadioHttpProxyType2;
			if (radioHttpProxyType != null)
			{
				radioHttpProxyType.Check += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HttpProxyCustom")]
	internal virtual Grid HttpProxyCustom
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextSystemHttpProxy")]
	internal virtual MyTextBox TextSystemHttpProxy
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextSystemHttpProxyCustomUsername")]
	internal virtual MyTextBox TextSystemHttpProxyCustomUsername
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextSystemHttpProxyCustomPassword")]
	internal virtual MyTextBox TextSystemHttpProxyCustomPassword
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnApplyHttpProxy
	{
		[CompilerGenerated]
		get
		{
			return _BtnApplyHttpProxy;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = ApplyHttpProxyBtn_OnClicked;
			MyButton btnApplyHttpProxy = _BtnApplyHttpProxy;
			if (btnApplyHttpProxy != null)
			{
				btnApplyHttpProxy.Click -= obj;
			}
			_BtnApplyHttpProxy = value;
			btnApplyHttpProxy = _BtnApplyHttpProxy;
			if (btnApplyHttpProxy != null)
			{
				btnApplyHttpProxy.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardApiKeys")]
	internal virtual MyCard CardApiKeys
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyRadioBox RadioMsApiType0
	{
		[CompilerGenerated]
		get
		{
			return _RadioMsApiType0;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioMsApiType = _RadioMsApiType0;
			if (radioMsApiType != null)
			{
				radioMsApiType.Check -= obj;
			}
			_RadioMsApiType0 = value;
			radioMsApiType = _RadioMsApiType0;
			if (radioMsApiType != null)
			{
				radioMsApiType.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioMsApiType1
	{
		[CompilerGenerated]
		get
		{
			return _RadioMsApiType1;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioMsApiType = _RadioMsApiType1;
			if (radioMsApiType != null)
			{
				radioMsApiType.Check -= obj;
			}
			_RadioMsApiType1 = value;
			radioMsApiType = _RadioMsApiType1;
			if (radioMsApiType != null)
			{
				radioMsApiType.Check += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextMsClientId")]
	internal virtual MyTextBox TextMsClientId
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyRadioBox RadioCfApiType0
	{
		[CompilerGenerated]
		get
		{
			return _RadioCfApiType0;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioCfApiType = _RadioCfApiType0;
			if (radioCfApiType != null)
			{
				radioCfApiType.Check -= obj;
			}
			_RadioCfApiType0 = value;
			radioCfApiType = _RadioCfApiType0;
			if (radioCfApiType != null)
			{
				radioCfApiType.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioCfApiType1
	{
		[CompilerGenerated]
		get
		{
			return _RadioCfApiType1;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioCfApiType = _RadioCfApiType1;
			if (radioCfApiType != null)
			{
				radioCfApiType.Check -= obj;
			}
			_RadioCfApiType1 = value;
			radioCfApiType = _RadioCfApiType1;
			if (radioCfApiType != null)
			{
				radioCfApiType.Check += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextCfApiKey")]
	internal virtual MyTextBox TextCfApiKey
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnApplyApiKeys
	{
		[CompilerGenerated]
		get
		{
			return _BtnApplyApiKeys;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnApplyApiKeys_Click;
			MyButton btnApplyApiKeys = _BtnApplyApiKeys;
			if (btnApplyApiKeys != null)
			{
				btnApplyApiKeys.Click -= obj;
			}
			_BtnApplyApiKeys = value;
			btnApplyApiKeys = _BtnApplyApiKeys;
			if (btnApplyApiKeys != null)
			{
				btnApplyApiKeys.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnGetMsClientId
	{
		[CompilerGenerated]
		get
		{
			return _BtnGetMsClientId;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnGetMsClientId_Click;
			MyButton btnGetMsClientId = _BtnGetMsClientId;
			if (btnGetMsClientId != null)
			{
				btnGetMsClientId.Click -= obj;
			}
			_BtnGetMsClientId = value;
			btnGetMsClientId = _BtnGetMsClientId;
			if (btnGetMsClientId != null)
			{
				btnGetMsClientId.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnGetCfApiKey
	{
		[CompilerGenerated]
		get
		{
			return _BtnGetCfApiKey;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnGetCfApiKey_Click;
			MyButton btnGetCfApiKey = _BtnGetCfApiKey;
			if (btnGetCfApiKey != null)
			{
				btnGetCfApiKey.Click -= obj;
			}
			_BtnGetCfApiKey = value;
			btnGetCfApiKey = _BtnGetCfApiKey;
			if (btnGetCfApiKey != null)
			{
				btnGetCfApiKey.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardDebug")]
	internal virtual MyCard CardDebug
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanDebugAnim")]
	internal virtual Grid PanDebugAnim
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MySlider SliderDebugAnim
	{
		[CompilerGenerated]
		get
		{
			return _SliderDebugAnim;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				SliderChange((MySlider)a0, a1);
			};
			MySlider sliderDebugAnim = _SliderDebugAnim;
			if (sliderDebugAnim != null)
			{
				sliderDebugAnim.Change -= obj;
			}
			_SliderDebugAnim = value;
			sliderDebugAnim = _SliderDebugAnim;
			if (sliderDebugAnim != null)
			{
				sliderDebugAnim.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckDebugSkipCopy
	{
		[CompilerGenerated]
		get
		{
			return _CheckDebugSkipCopy;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkDebugSkipCopy = _CheckDebugSkipCopy;
			if (checkDebugSkipCopy != null)
			{
				checkDebugSkipCopy.Change -= obj;
			}
			_CheckDebugSkipCopy = value;
			checkDebugSkipCopy = _CheckDebugSkipCopy;
			if (checkDebugSkipCopy != null)
			{
				checkDebugSkipCopy.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckDebugMode
	{
		[CompilerGenerated]
		get
		{
			return _CheckDebugMode;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				CheckDebugMode_Change();
			};
			MyCheckBox checkDebugMode = _CheckDebugMode;
			if (checkDebugMode != null)
			{
				checkDebugMode.Change -= obj;
				checkDebugMode.Change -= obj2;
			}
			_CheckDebugMode = value;
			checkDebugMode = _CheckDebugMode;
			if (checkDebugMode != null)
			{
				checkDebugMode.Change += obj;
				checkDebugMode.Change += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckDebugDelay
	{
		[CompilerGenerated]
		get
		{
			return _CheckDebugDelay;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkDebugDelay = _CheckDebugDelay;
			if (checkDebugDelay != null)
			{
				checkDebugDelay.Change -= obj;
			}
			_CheckDebugDelay = value;
			checkDebugDelay = _CheckDebugDelay;
			if (checkDebugDelay != null)
			{
				checkDebugDelay.Change += obj;
			}
		}
	}

	public PageSetupSystem()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageSetupSystem_Loaded);
		IsLoaded = false;
		InitializeComponent();
	}

	private void PageSetupSystem_Loaded(object sender, RoutedEventArgs e)
	{
		((ScrollViewer)PanBack).ScrollToHome();
		checked
		{
			if (!IsLoaded)
			{
				IsLoaded = true;
				ModAnimation.AniControlEnabled++;
				Reload();
				SliderLoad();
				ModAnimation.AniControlEnabled--;
			}
		}
	}

	public void Reload()
	{
		SliderDownloadThread.Value = Conversions.ToInteger(ModBase.Setup.Get("ToolDownloadThread"));
		SliderDownloadSpeed.Value = Conversions.ToInteger(ModBase.Setup.Get("ToolDownloadSpeed"));
		((Selector)ComboDownloadSource).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("ToolDownloadSource"));
		((Selector)ComboDownloadVersion).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("ToolDownloadVersion"));
		CheckDownloadAutoSelectVersion.Checked = (bool?)ModBase.Setup.Get("ToolDownloadAutoSelectVersion");
		CheckFixAuthlib.Checked = (bool?)ModBase.Setup.Get("ToolFixAuthlib");
		((Selector)ComboDownloadTranslateV2).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("ToolDownloadTranslateV2"));
		((Selector)ComboDownloadMod).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("ToolDownloadMod"));
		((Selector)ComboModLocalNameStyle).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("ToolModLocalNameStyle"));
		CheckDownloadIgnoreQuilt.Checked = (bool?)ModBase.Setup.Get("ToolDownloadIgnoreQuilt");
		CheckDownloadClipboard.Checked = (bool?)ModBase.Setup.Get("ToolDownloadClipboard");
		CheckUpdateRelease.Checked = (bool?)ModBase.Setup.Get("ToolUpdateRelease");
		CheckUpdateSnapshot.Checked = (bool?)ModBase.Setup.Get("ToolUpdateSnapshot");
		CheckHelpChinese.Checked = (bool?)ModBase.Setup.Get("ToolHelpChinese");
		((Selector)ComboSystemUpdate).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("SystemSystemUpdate"));
		((Selector)ComboSystemUpdateBranch).SelectedIndex = 0;
		((UIElement)ComboSystemUpdateBranch).IsEnabled = false;
		ModBase.Setup.Set("SystemSystemUpdateBranch", 0);
		((Selector)ComboSystemActivity).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("SystemSystemActivity"));
		((TextBox)TextSystemCache).Text = Conversions.ToString(ModBase.Setup.Get("SystemSystemCache"));
		CheckSystemDisableHardwareAcceleration.Checked = (bool?)ModBase.Setup.Get("SystemDisableHardwareAcceleration");
		SliderAniFPS.Value = Conversions.ToInteger(ModBase.Setup.Get("UiAniFPS"));
		SliderMaxLog.Value = Conversions.ToInteger(ModBase.Setup.Get("SystemMaxLog"));
		((TextBox)TextSystemHttpProxy).Text = Conversions.ToString(ModBase.Setup.Get("SystemHttpProxy"));
		((TextBox)TextSystemHttpProxyCustomUsername).Text = Conversions.ToString(ModBase.Setup.Get("SystemHttpProxyCustomUsername"));
		((TextBox)TextSystemHttpProxyCustomPassword).Text = Conversions.ToString(ModBase.Setup.Get("SystemHttpProxyCustomPassword"));
		((MyRadioBox)base.FindName(string.Format("RadioHttpProxyType{0}", RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("SystemHttpProxyType"))))).SetChecked(value: true, user: false);
		CheckDebugMode.Checked = (bool?)ModBase.Setup.Get("SystemDebugMode");
		SliderDebugAnim.Value = Conversions.ToInteger(ModBase.Setup.Get("SystemDebugAnim"));
		CheckDebugDelay.Checked = (bool?)ModBase.Setup.Get("SystemDebugDelay");
		CheckDebugSkipCopy.Checked = (bool?)ModBase.Setup.Get("SystemDebugSkipCopy");
		((MyRadioBox)base.FindName(string.Format("RadioMsApiType{0}", RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("SystemMsApiType"))))).SetChecked(value: true, user: false);
		((TextBox)TextMsClientId).Text = Conversions.ToString(ModBase.Setup.Get("SystemMsClientId") ?? "");
		((MyRadioBox)base.FindName(string.Format("RadioCfApiType{0}", RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("SystemCfApiType"))))).SetChecked(value: true, user: false);
		((TextBox)TextCfApiKey).Text = Conversions.ToString(ModBase.Setup.Get("SystemCfApiKey") ?? "");
	}

	public void Reset()
	{
		try
		{
			ModBase.Setup.Reset("ToolDownloadThread");
			ModBase.Setup.Reset("ToolDownloadSpeed");
			ModBase.Setup.Reset("ToolDownloadSource");
			ModBase.Setup.Reset("ToolDownloadVersion");
			ModBase.Setup.Reset("ToolDownloadTranslateV2");
			ModBase.Setup.Reset("ToolDownloadIgnoreQuilt");
			ModBase.Setup.Reset("ToolDownloadClipboard");
			ModBase.Setup.Reset("ToolDownloadMod");
			ModBase.Setup.Reset("ToolDownloadAutoSelectVersion");
			ModBase.Setup.Reset("ToolFixAuthlib");
			ModBase.Setup.Reset("ToolModLocalNameStyle");
			ModBase.Setup.Reset("ToolUpdateRelease");
			ModBase.Setup.Reset("ToolUpdateSnapshot");
			ModBase.Setup.Reset("ToolHelpChinese");
			ModBase.Setup.Reset("SystemDebugMode");
			ModBase.Setup.Reset("SystemDebugAnim");
			ModBase.Setup.Reset("SystemDebugDelay");
			ModBase.Setup.Reset("SystemDebugSkipCopy");
			ModBase.Setup.Reset("SystemSystemCache");
			ModBase.Setup.Reset("SystemSystemUpdate");
			ModBase.Setup.Reset("SystemSystemActivity");
			ModBase.Setup.Reset("SystemDisableHardwareAcceleration");
			ModBase.Setup.Reset("SystemHttpProxy");
			ModBase.Setup.Reset("SystemHttpProxyType");
			ModBase.Setup.Reset("SystemHttpProxyCustomUsername");
			ModBase.Setup.Reset("SystemHttpProxyCustomPassword");
			ModBase.Setup.Reset("SystemUseDefaultProxy");
			ModBase.Setup.Reset("UiAniFPS");
			ModBase.Setup.Reset("SystemMsApiType");
			ModBase.Setup.Reset("SystemMsClientId");
			ModBase.Setup.Reset("SystemCfApiType");
			ModBase.Setup.Reset("SystemCfApiKey");
			ModBase.Log("[Setup] 已初始化启动器页设置");
			ModMain.Hint("已初始化启动器页设置！", ModMain.HintType.Finish, Log: false);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "初始化启动器页设置失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
		Reload();
	}

	private static void CheckBoxChange(MyCheckBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), sender.Checked);
		}
	}

	private static void SliderChange(MySlider sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), sender.Value);
		}
	}

	private static void ComboChange(MyComboBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), ((Selector)sender).SelectedIndex);
		}
	}

	private static void TextBoxChange(MyTextBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), ((TextBox)sender).Text);
		}
	}

	private static void RadioBoxChange(MyRadioBox sender, object e)
	{
		string[] array = ((FrameworkElement)sender).Tag.ToString().Split("/", (StringSplitOptions)0);
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(array[0], int.Parse(array[1]));
		}
	}

	private void ApplyHttpProxyBtn_OnClicked(object sender, MouseButtonEventArgs e)
	{
		ModBase.Setup.Set("SystemHttpProxy", ((TextBox)TextSystemHttpProxy).Text);
		ModBase.Setup.Set("SystemHttpProxyCustomPassword", ((TextBox)TextSystemHttpProxyCustomPassword).Text);
		ModBase.Setup.Set("SystemHttpProxyCustomUsername", ((TextBox)TextSystemHttpProxyCustomUsername).Text);
	}

	private void SliderLoad()
	{
		SliderDownloadThread.GetHintText = (VB_0024AnonymousDelegate_22<object, object>)([SpecialName] (object v) => Operators.AddObject(v, (object)1));
		SliderDownloadSpeed.GetHintText = (VB_0024AnonymousDelegate_22<object, object>)([SpecialName] (object v) =>
		{
			if (Operators.ConditionalCompareObjectLessEqual(v, (object)14, false))
			{
				return Operators.ConcatenateObject(Operators.MultiplyObject(Operators.AddObject(v, (object)1), (object)0.1), (object)" M/s");
			}
			if (Operators.ConditionalCompareObjectLessEqual(v, (object)31, false))
			{
				return Operators.ConcatenateObject(Operators.MultiplyObject(Operators.SubtractObject(v, (object)11), (object)0.5), (object)" M/s");
			}
			return Operators.ConditionalCompareObjectLessEqual(v, (object)41, false) ? Operators.ConcatenateObject(Operators.SubtractObject(v, (object)21), (object)" M/s") : "无限制";
		});
		SliderDebugAnim.GetHintText = (VB_0024AnonymousDelegate_22<object, object>)([SpecialName] (object v) => (!Operators.ConditionalCompareObjectGreater(v, (object)29, false)) ? Operators.ConcatenateObject(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
		{
			Operators.AddObject(Operators.DivideObject(v, (object)10), (object)0.1),
			1
		}, (string[])null, (System.Type[])null, (bool[])null), (object)"x") : "关闭");
		SliderAniFPS.GetHintText = (VB_0024AnonymousDelegate_22<object, string>)([SpecialName] (object v) => $"{Operators.AddObject(v, (object)1)} FPS");
		SliderMaxLog.GetHintText = (VB_0024AnonymousDelegate_22<object, object>)([SpecialName] (object v) =>
		{
			if (Operators.ConditionalCompareObjectLessEqual(v, (object)5, false))
			{
				return Operators.AddObject(Operators.MultiplyObject(v, (object)10), (object)50);
			}
			if (Operators.ConditionalCompareObjectLessEqual(v, (object)13, false))
			{
				return Operators.SubtractObject(Operators.MultiplyObject(v, (object)50), (object)150);
			}
			return Operators.ConditionalCompareObjectLessEqual(v, (object)28, false) ? Operators.SubtractObject(Operators.MultiplyObject(v, (object)100), (object)800) : "无限制";
		});
	}

	private void SliderDownloadThread_PreviewChange(object sender, ModBase.RouteEventArgs e)
	{
		if (SliderDownloadThread.Value >= 100 && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("HintDownloadThread"))))
		{
			ModBase.Setup.Set("HintDownloadThread", true);
			ModMain.MyMsgBox("如果设置过多的下载线程，可能会导致下载时出现非常严重的卡顿。\r\n一般设置 64 线程即可满足大多数下载需求，除非你知道你在干什么，否则不建议设置更多的线程数！", "警告", "我知道了", "", "", IsWarn: true);
		}
	}

	private void Check_DisableHardwareAcceleration(object sender, bool user)
	{
		ModMain.Hint("此项变更将在重启 PCL 后生效");
	}

	private void CheckDebugMode_Change()
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModMain.Hint("部分调试信息将在刷新或启动器重启后切换显示！", ModMain.HintType.Info, Log: false);
		}
	}

	private void ComboSystemActivity_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (ModAnimation.AniControlEnabled == 0 && ((Selector)ComboSystemActivity).SelectedIndex == 2 && ModMain.MyMsgBox("若选择此项，即使在将来出现严重问题时，你也无法获取相关通知。\r\n例如，如果发现某个版本游戏存在严重 Bug，你可能就会因为无法得到通知而导致无法预知的后果。\r\n\r\n一般选择 仅在有重要通知时显示公告 就可以让你尽量不受打扰了。\r\n除非你在制作服务器整合包，或时常手动更新启动器，否则极度不推荐选择此项！", "警告", "我知道我在做什么", "取消", "", IsWarn: true) == 2)
		{
			((Selector)ComboSystemActivity).SelectedItem = RuntimeHelpers.GetObjectValue(e.RemovedItems[0]);
		}
	}

	private void ComboSystemUpdate_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (ModAnimation.AniControlEnabled == 0 && ((Selector)ComboSystemUpdate).SelectedIndex == 3 && ModMain.MyMsgBox("若选择此项，即使在启动器将来出现严重问题时，你也无法获取更新并获得修复。\r\n例如，如果官方修改了登录方式，从而导致现有启动器无法登录，你可能就会因为无法更新而无法开始游戏。\r\n\r\n一般选择 仅在有重大漏洞更新时显示提示 就可以让你尽量不受打扰了。\r\n除非你在制作服务器整合包，或时常手动更新启动器，否则极度不推荐选择此项！", "警告", "我知道我在做什么", "取消", "", IsWarn: true) == 2)
		{
			((Selector)ComboSystemUpdate).SelectedItem = RuntimeHelpers.GetObjectValue(e.RemovedItems[0]);
		}
	}

	private void ComboSystemUpdateBranch_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (ModAnimation.AniControlEnabled == 0 && ((Selector)ComboSystemUpdateBranch).SelectedIndex == 1)
		{
			if (ModMain.MyMsgBox("你正在切换启动器更新通道到 Fast Ring。\r\nFast Ring 可以提供下个版本更新内容的预览，但可能会包含未经充分测试的功能，稳定性欠佳。\r\n\r\n在升级到 Fast Ring 版本后，只能手动重新下载启动器来切换回 Slow Ring。\r\n该选项仅推荐具有一定基础知识和能力的用户选择。如果你正在制作整合包，请使用 Slow Ring！", "继续之前...", "我已知晓", "取消", "", IsWarn: true) == 2)
			{
				((Selector)ComboSystemUpdateBranch).SelectedItem = RuntimeHelpers.GetObjectValue(e.RemovedItems[0]);
			}
			else
			{
				ModSecret.UpdateCheckByButton();
			}
		}
	}

	private void BtnSystemUpdate_Click(object sender, EventArgs e)
	{
		ModSecret.UpdateCheckByButton();
	}

	public static bool? IsLauncherNewest()
	{
		bool? result;
		try
		{
			return ModSecret.IsVerisonLatest();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "确认启动器更新失败", ModBase.LogLevel.Feedback);
			result = null;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void BtnApplyApiKeys_Click(object sender, MouseButtonEventArgs e)
	{
		ModBase.Setup.Set("SystemMsClientId", ((TextBox)TextMsClientId).Text);
		ModBase.Setup.Set("SystemCfApiKey", ((TextBox)TextCfApiKey).Text);
		ModMain.Hint("API 设置已保存，部分更改将在重启后生效！", ModMain.HintType.Finish);
	}

	private void BtnGetMsClientId_Click(object sender, MouseButtonEventArgs e)
	{
		ModBase.OpenWebsite("https://portal.azure.com/");
	}

	private void BtnGetCfApiKey_Click(object sender, MouseButtonEventArgs e)
	{
		ModBase.OpenWebsite("https://console.curseforge.com/");
	}

	private void BtnSystemSettingExp_Click(object sender, MouseButtonEventArgs e)
	{
		string text = SystemDialogs.SelectSaveFile("选择保存位置", "PCL 全局配置.json", "PCL 配置文件(*.json)|*.json", ModBase.ExePath);
		if (!text.IsNullOrWhiteSpace())
		{
			File.Copy(ConfigService.SharedConfigPath, text, true);
			ModMain.Hint("配置导出成功！", ModMain.HintType.Finish);
			ModBase.OpenExplorer(text);
		}
	}

	private void BtnSystemSettingImp_Click(object sender, MouseButtonEventArgs e)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		string text = SystemDialogs.SelectFile("PCL 配置文件(*.json)|*.json", "选择配置文件");
		if (!text.IsNullOrWhiteSpace())
		{
			File.Copy(text, ConfigService.SharedConfigPath, true);
			ModMain.MyMsgBox("配置导入成功！请重启 PCL 以应用配置……", "提示", "重启", "", "", IsWarn: false, HighLight: true, ForceWait: true);
			Process.Start(new ProcessStartInfo(ModBase.ExePathWithName));
			FormMain.EndProgramForce();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagesetup/pagesetupsystem.xaml", (UriKind)2);
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
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanMain = (StackPanel)target;
			break;
		case 3:
			ComboDownloadSource = (MyComboBox)target;
			break;
		case 4:
			ComboDownloadVersion = (MyComboBox)target;
			break;
		case 5:
			SliderDownloadThread = (MySlider)target;
			break;
		case 6:
			SliderDownloadSpeed = (MySlider)target;
			break;
		case 7:
			CheckDownloadAutoSelectVersion = (MyCheckBox)target;
			break;
		case 8:
			CheckFixAuthlib = (MyCheckBox)target;
			break;
		case 9:
			ComboDownloadMod = (MyComboBox)target;
			break;
		case 10:
			ComboDownloadTranslateV2 = (MyComboBox)target;
			break;
		case 11:
			ComboModLocalNameStyle = (MyComboBox)target;
			break;
		case 12:
			CheckDownloadIgnoreQuilt = (MyCheckBox)target;
			break;
		case 13:
			CheckDownloadClipboard = (MyCheckBox)target;
			break;
		case 14:
			CheckUpdateRelease = (MyCheckBox)target;
			break;
		case 15:
			CheckUpdateSnapshot = (MyCheckBox)target;
			break;
		case 16:
			CheckHelpChinese = (MyCheckBox)target;
			break;
		case 17:
			ComboSystemUpdate = (MyComboBox)target;
			break;
		case 18:
			ComboSystemUpdateBranch = (MyComboBox)target;
			break;
		case 19:
			ComboSystemActivity = (MyComboBox)target;
			break;
		case 20:
			TextSystemCache = (MyTextBox)target;
			break;
		case 21:
			SliderAniFPS = (MySlider)target;
			break;
		case 22:
			SliderMaxLog = (MySlider)target;
			break;
		case 23:
			CheckSystemDisableHardwareAcceleration = (MyCheckBox)target;
			break;
		case 24:
			BtnSystemUpdate = (MyButton)target;
			break;
		case 25:
			BtnSystemSettingExp = (MyButton)target;
			break;
		case 26:
			BtnSystemSettingImp = (MyButton)target;
			break;
		case 27:
			RadioHttpProxyType0 = (MyRadioBox)target;
			break;
		case 28:
			RadioHttpProxyType1 = (MyRadioBox)target;
			break;
		case 29:
			RadioHttpProxyType2 = (MyRadioBox)target;
			break;
		case 30:
			HttpProxyCustom = (Grid)target;
			break;
		case 31:
			TextSystemHttpProxy = (MyTextBox)target;
			break;
		case 32:
			TextSystemHttpProxyCustomUsername = (MyTextBox)target;
			break;
		case 33:
			TextSystemHttpProxyCustomPassword = (MyTextBox)target;
			break;
		case 34:
			BtnApplyHttpProxy = (MyButton)target;
			break;
		case 35:
			CardApiKeys = (MyCard)target;
			break;
		case 36:
			RadioMsApiType0 = (MyRadioBox)target;
			break;
		case 37:
			RadioMsApiType1 = (MyRadioBox)target;
			break;
		case 38:
			TextMsClientId = (MyTextBox)target;
			break;
		case 39:
			RadioCfApiType0 = (MyRadioBox)target;
			break;
		case 40:
			RadioCfApiType1 = (MyRadioBox)target;
			break;
		case 41:
			TextCfApiKey = (MyTextBox)target;
			break;
		case 42:
			BtnApplyApiKeys = (MyButton)target;
			break;
		case 43:
			BtnGetMsClientId = (MyButton)target;
			break;
		case 44:
			BtnGetCfApiKey = (MyButton)target;
			break;
		case 45:
			CardDebug = (MyCard)target;
			break;
		case 46:
			PanDebugAnim = (Grid)target;
			break;
		case 47:
			SliderDebugAnim = (MySlider)target;
			break;
		case 48:
			CheckDebugSkipCopy = (MyCheckBox)target;
			break;
		case 49:
			CheckDebugMode = (MyCheckBox)target;
			break;
		case 50:
			CheckDebugDelay = (MyCheckBox)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
