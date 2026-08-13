using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Minecraft;
using PCL.Core.Utils.OS;

namespace PCL;

[DesignerGenerated]
public class PageSetupLaunch : MyPageRight, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static SelectionChangedEventHandler _0024IR41_002D2;

		public static RoutedEventHandler _0024IR45_002D3;

		public static RoutedEventHandler _0024IR49_002D4;

		public static SelectionChangedEventHandler _0024IR53_002D5;

		public static SelectionChangedEventHandler _0024IR57_002D6;

		public static SelectionChangedEventHandler _0024IR65_002D7;

		public static RoutedEventHandler _0024IR69_002D9;

		public static RoutedEventHandler _0024IR77_002D10;

		public static SelectionChangedEventHandler _0024IR81_002D11;

		public static SelectionChangedEventHandler _0024IR85_002D12;

		public static IMyRadio.CheckEventHandler _0024IR101_002D13;

		public static IMyRadio.CheckEventHandler _0024IR105_002D15;

		public static MySlider.ChangeEventHandler _0024IR109_002D17;

		public static MyCheckBox.ChangeEventHandler _0024IR113_002D19;

		public static RoutedEventHandler _0024IR173_002D25;

		public static RoutedEventHandler _0024IR177_002D27;

		public static RoutedEventHandler _0024IR181_002D28;

		public static MyCheckBox.ChangeEventHandler _0024IR185_002D29;

		public static MyCheckBox.ChangeEventHandler _0024IR189_002D30;

		public static MyCheckBox.ChangeEventHandler _0024IR193_002D31;

		public static MyCheckBox.ChangeEventHandler _0024IR197_002D32;

		public static MyCheckBox.ChangeEventHandler _0024IR201_002D33;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__R41_002D2(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R45_002D3(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R49_002D4(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R53_002D5(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R57_002D6(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R65_002D7(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R69_002D9(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R77_002D10(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R81_002D11(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R85_002D12(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R101_002D13(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R105_002D15(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R109_002D17(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R113_002D19(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R173_002D25(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R177_002D27(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R181_002D28(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R185_002D29(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R189_002D30(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R193_002D31(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R197_002D32(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R201_002D33(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}
	}

	private bool IsLoad;

	private int RamTextLeft;

	private int RamTextRight;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboArgumentIndieV2")]
	private MyComboBox _ComboArgumentIndieV2;

	[CompilerGenerated]
	[AccessedThroughProperty("TextArgumentTitle")]
	private MyTextBox _TextArgumentTitle;

	[CompilerGenerated]
	[AccessedThroughProperty("TextArgumentInfo")]
	private MyTextBox _TextArgumentInfo;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboArgumentVisibie")]
	private MyComboBox _ComboArgumentVisibie;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboArgumentPriority")]
	private MyComboBox _ComboArgumentPriority;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboArgumentWindowType")]
	private MyComboBox _ComboArgumentWindowType;

	[CompilerGenerated]
	[AccessedThroughProperty("TextArgumentWindowWidth")]
	private MyTextBox _TextArgumentWindowWidth;

	[CompilerGenerated]
	[AccessedThroughProperty("TextArgumentWindowHeight")]
	private MyTextBox _TextArgumentWindowHeight;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboMsAuthType")]
	private MyComboBox _ComboMsAuthType;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboPreferredIpStack")]
	private MyComboBox _ComboPreferredIpStack;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnGotoJavaManage")]
	private MyIconTextButton _BtnGotoJavaManage;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioRamType0")]
	private MyRadioBox _RadioRamType0;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioRamType1")]
	private MyRadioBox _RadioRamType1;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderRamCustom")]
	private MySlider _SliderRamCustom;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckArgumentRam")]
	private MyCheckBox _CheckArgumentRam;

	[CompilerGenerated]
	[AccessedThroughProperty("RectRamGame")]
	private Rectangle _RectRamGame;

	[CompilerGenerated]
	[AccessedThroughProperty("RectRamEmpty")]
	private Rectangle _RectRamEmpty;

	[CompilerGenerated]
	[AccessedThroughProperty("LabRamGame")]
	private TextBlock _LabRamGame;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboAdvanceRenderer")]
	private MyComboBox _ComboAdvanceRenderer;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnAdvanceJvmReset")]
	private MyIconButton _BtnAdvanceJvmReset;

	[CompilerGenerated]
	[AccessedThroughProperty("TextAdvanceJvm")]
	private MyTextBox _TextAdvanceJvm;

	[CompilerGenerated]
	[AccessedThroughProperty("TextAdvanceGame")]
	private MyTextBox _TextAdvanceGame;

	[CompilerGenerated]
	[AccessedThroughProperty("TextAdvanceRun")]
	private MyTextBox _TextAdvanceRun;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckAdvanceRunWait")]
	private MyCheckBox _CheckAdvanceRunWait;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckAdvanceDisableJLW")]
	private MyCheckBox _CheckAdvanceDisableJLW;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckAdvanceDisableRW")]
	private MyCheckBox _CheckAdvanceDisableRW;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckAdvanceGraphicCard")]
	private MyCheckBox _CheckAdvanceGraphicCard;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckAdvanceNoJavaw")]
	private MyCheckBox _CheckAdvanceNoJavaw;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSwitch")]
	private MyExtraTextButton _BtnSwitch;

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
	[field: AccessedThroughProperty("CardArgument")]
	internal virtual MyCard CardArgument
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyComboBox ComboArgumentIndieV2
	{
		[CompilerGenerated]
		get
		{
			return _ComboArgumentIndieV2;
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
			if (_Closure_0024__._0024IR41_002D2 != null)
			{
				obj = _Closure_0024__._0024IR41_002D2;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR41_002D2 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			SelectionChangedEventHandler val3 = new SelectionChangedEventHandler(ComboArgumentIndie_SelectionChanged);
			MyComboBox comboArgumentIndieV = _ComboArgumentIndieV2;
			if (comboArgumentIndieV != null)
			{
				((Selector)comboArgumentIndieV).SelectionChanged -= val2;
				((Selector)comboArgumentIndieV).SelectionChanged -= val3;
			}
			_ComboArgumentIndieV2 = value;
			comboArgumentIndieV = _ComboArgumentIndieV2;
			if (comboArgumentIndieV != null)
			{
				((Selector)comboArgumentIndieV).SelectionChanged += val2;
				((Selector)comboArgumentIndieV).SelectionChanged += val3;
			}
		}
	}

	internal virtual MyTextBox TextArgumentTitle
	{
		[CompilerGenerated]
		get
		{
			return _TextArgumentTitle;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR45_002D3 != null)
			{
				obj = _Closure_0024__._0024IR45_002D3;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR45_002D3 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			MyTextBox textArgumentTitle = _TextArgumentTitle;
			if (textArgumentTitle != null)
			{
				textArgumentTitle.ValidatedTextChanged -= value2;
			}
			_TextArgumentTitle = value;
			textArgumentTitle = _TextArgumentTitle;
			if (textArgumentTitle != null)
			{
				textArgumentTitle.ValidatedTextChanged += value2;
			}
		}
	}

	internal virtual MyTextBox TextArgumentInfo
	{
		[CompilerGenerated]
		get
		{
			return _TextArgumentInfo;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR49_002D4 != null)
			{
				obj = _Closure_0024__._0024IR49_002D4;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR49_002D4 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			MyTextBox textArgumentInfo = _TextArgumentInfo;
			if (textArgumentInfo != null)
			{
				textArgumentInfo.ValidatedTextChanged -= value2;
			}
			_TextArgumentInfo = value;
			textArgumentInfo = _TextArgumentInfo;
			if (textArgumentInfo != null)
			{
				textArgumentInfo.ValidatedTextChanged += value2;
			}
		}
	}

	internal virtual MyComboBox ComboArgumentVisibie
	{
		[CompilerGenerated]
		get
		{
			return _ComboArgumentVisibie;
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
			if (_Closure_0024__._0024IR53_002D5 != null)
			{
				obj = _Closure_0024__._0024IR53_002D5;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR53_002D5 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			SelectionChangedEventHandler val3 = new SelectionChangedEventHandler(ComboArgumentVisibie_SizeChanged);
			MyComboBox comboArgumentVisibie = _ComboArgumentVisibie;
			if (comboArgumentVisibie != null)
			{
				((Selector)comboArgumentVisibie).SelectionChanged -= val2;
				((Selector)comboArgumentVisibie).SelectionChanged -= val3;
			}
			_ComboArgumentVisibie = value;
			comboArgumentVisibie = _ComboArgumentVisibie;
			if (comboArgumentVisibie != null)
			{
				((Selector)comboArgumentVisibie).SelectionChanged += val2;
				((Selector)comboArgumentVisibie).SelectionChanged += val3;
			}
		}
	}

	internal virtual MyComboBox ComboArgumentPriority
	{
		[CompilerGenerated]
		get
		{
			return _ComboArgumentPriority;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR57_002D6 != null)
			{
				obj = _Closure_0024__._0024IR57_002D6;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR57_002D6 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			MyComboBox comboArgumentPriority = _ComboArgumentPriority;
			if (comboArgumentPriority != null)
			{
				((Selector)comboArgumentPriority).SelectionChanged -= val2;
			}
			_ComboArgumentPriority = value;
			comboArgumentPriority = _ComboArgumentPriority;
			if (comboArgumentPriority != null)
			{
				((Selector)comboArgumentPriority).SelectionChanged += val2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanArgumentWindow")]
	internal virtual Grid PanArgumentWindow
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyComboBox ComboArgumentWindowType
	{
		[CompilerGenerated]
		get
		{
			return _ComboArgumentWindowType;
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
			if (_Closure_0024__._0024IR65_002D7 != null)
			{
				obj = _Closure_0024__._0024IR65_002D7;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR65_002D7 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			SelectionChangedEventHandler val3 = (SelectionChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, SelectionChangedEventArgs a1) =>
			{
				WindowTypeUIRefresh();
			});
			MyComboBox comboArgumentWindowType = _ComboArgumentWindowType;
			if (comboArgumentWindowType != null)
			{
				((Selector)comboArgumentWindowType).SelectionChanged -= val2;
				((Selector)comboArgumentWindowType).SelectionChanged -= val3;
			}
			_ComboArgumentWindowType = value;
			comboArgumentWindowType = _ComboArgumentWindowType;
			if (comboArgumentWindowType != null)
			{
				((Selector)comboArgumentWindowType).SelectionChanged += val2;
				((Selector)comboArgumentWindowType).SelectionChanged += val3;
			}
		}
	}

	internal virtual MyTextBox TextArgumentWindowWidth
	{
		[CompilerGenerated]
		get
		{
			return _TextArgumentWindowWidth;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR69_002D9 != null)
			{
				obj = _Closure_0024__._0024IR69_002D9;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR69_002D9 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			MyTextBox textArgumentWindowWidth = _TextArgumentWindowWidth;
			if (textArgumentWindowWidth != null)
			{
				textArgumentWindowWidth.ValidatedTextChanged -= value2;
			}
			_TextArgumentWindowWidth = value;
			textArgumentWindowWidth = _TextArgumentWindowWidth;
			if (textArgumentWindowWidth != null)
			{
				textArgumentWindowWidth.ValidatedTextChanged += value2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabArgumentWindowMiddle")]
	internal virtual TextBlock LabArgumentWindowMiddle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyTextBox TextArgumentWindowHeight
	{
		[CompilerGenerated]
		get
		{
			return _TextArgumentWindowHeight;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR77_002D10 != null)
			{
				obj = _Closure_0024__._0024IR77_002D10;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR77_002D10 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			MyTextBox textArgumentWindowHeight = _TextArgumentWindowHeight;
			if (textArgumentWindowHeight != null)
			{
				textArgumentWindowHeight.ValidatedTextChanged -= value2;
			}
			_TextArgumentWindowHeight = value;
			textArgumentWindowHeight = _TextArgumentWindowHeight;
			if (textArgumentWindowHeight != null)
			{
				textArgumentWindowHeight.ValidatedTextChanged += value2;
			}
		}
	}

	internal virtual MyComboBox ComboMsAuthType
	{
		[CompilerGenerated]
		get
		{
			return _ComboMsAuthType;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR81_002D11 != null)
			{
				obj = _Closure_0024__._0024IR81_002D11;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR81_002D11 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			MyComboBox comboMsAuthType = _ComboMsAuthType;
			if (comboMsAuthType != null)
			{
				((Selector)comboMsAuthType).SelectionChanged -= val2;
			}
			_ComboMsAuthType = value;
			comboMsAuthType = _ComboMsAuthType;
			if (comboMsAuthType != null)
			{
				((Selector)comboMsAuthType).SelectionChanged += val2;
			}
		}
	}

	internal virtual MyComboBox ComboPreferredIpStack
	{
		[CompilerGenerated]
		get
		{
			return _ComboPreferredIpStack;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR85_002D12 != null)
			{
				obj = _Closure_0024__._0024IR85_002D12;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR85_002D12 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			MyComboBox comboPreferredIpStack = _ComboPreferredIpStack;
			if (comboPreferredIpStack != null)
			{
				((Selector)comboPreferredIpStack).SelectionChanged -= val2;
			}
			_ComboPreferredIpStack = value;
			comboPreferredIpStack = _ComboPreferredIpStack;
			if (comboPreferredIpStack != null)
			{
				((Selector)comboPreferredIpStack).SelectionChanged += val2;
			}
		}
	}

	internal virtual MyIconTextButton BtnGotoJavaManage
	{
		[CompilerGenerated]
		get
		{
			return _BtnGotoJavaManage;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnJavaManage_Click;
			MyIconTextButton btnGotoJavaManage = _BtnGotoJavaManage;
			if (btnGotoJavaManage != null)
			{
				btnGotoJavaManage.Click -= obj;
			}
			_BtnGotoJavaManage = value;
			btnGotoJavaManage = _BtnGotoJavaManage;
			if (btnGotoJavaManage != null)
			{
				btnGotoJavaManage.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabRamWarn")]
	internal virtual MyHint LabRamWarn
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintRamTooHigh")]
	internal virtual MyHint HintRamTooHigh
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyRadioBox RadioRamType0
	{
		[CompilerGenerated]
		get
		{
			return _RadioRamType0;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			IMyRadio.CheckEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RefreshRam();
			};
			MyRadioBox radioRamType = _RadioRamType0;
			if (radioRamType != null)
			{
				radioRamType.Check -= obj;
				radioRamType.Check -= obj2;
			}
			_RadioRamType0 = value;
			radioRamType = _RadioRamType0;
			if (radioRamType != null)
			{
				radioRamType.Check += obj;
				radioRamType.Check += obj2;
			}
		}
	}

	internal virtual MyRadioBox RadioRamType1
	{
		[CompilerGenerated]
		get
		{
			return _RadioRamType1;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			IMyRadio.CheckEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RefreshRam();
			};
			MyRadioBox radioRamType = _RadioRamType1;
			if (radioRamType != null)
			{
				radioRamType.Check -= obj;
				radioRamType.Check -= obj2;
			}
			_RadioRamType1 = value;
			radioRamType = _RadioRamType1;
			if (radioRamType != null)
			{
				radioRamType.Check += obj;
				radioRamType.Check += obj2;
			}
		}
	}

	internal virtual MySlider SliderRamCustom
	{
		[CompilerGenerated]
		get
		{
			return _SliderRamCustom;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				SliderChange((MySlider)a0, a1);
			};
			MySlider.ChangeEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				RefreshRam();
			};
			MySlider sliderRamCustom = _SliderRamCustom;
			if (sliderRamCustom != null)
			{
				sliderRamCustom.Change -= obj;
				sliderRamCustom.Change -= obj2;
			}
			_SliderRamCustom = value;
			sliderRamCustom = _SliderRamCustom;
			if (sliderRamCustom != null)
			{
				sliderRamCustom.Change += obj;
				sliderRamCustom.Change += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckArgumentRam
	{
		[CompilerGenerated]
		get
		{
			return _CheckArgumentRam;
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
				CheckArgumentRam_Change();
			};
			MyCheckBox checkArgumentRam = _CheckArgumentRam;
			if (checkArgumentRam != null)
			{
				checkArgumentRam.Change -= obj;
				checkArgumentRam.Change -= obj2;
			}
			_CheckArgumentRam = value;
			checkArgumentRam = _CheckArgumentRam;
			if (checkArgumentRam != null)
			{
				checkArgumentRam.Change += obj;
				checkArgumentRam.Change += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanRamDisplay")]
	internal virtual Grid PanRamDisplay
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnRamUsed")]
	internal virtual ColumnDefinition ColumnRamUsed
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnRamGame")]
	internal virtual ColumnDefinition ColumnRamGame
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnRamEmpty")]
	internal virtual ColumnDefinition ColumnRamEmpty
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("RectRamUsed")]
	internal virtual Rectangle RectRamUsed
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Rectangle RectRamGame
	{
		[CompilerGenerated]
		get
		{
			return _RectRamGame;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SizeChangedEventHandler val = (SizeChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, SizeChangedEventArgs a1) =>
			{
				RefreshRamText();
			});
			Rectangle rectRamGame = _RectRamGame;
			if (rectRamGame != null)
			{
				((FrameworkElement)rectRamGame).SizeChanged -= val;
			}
			_RectRamGame = value;
			rectRamGame = _RectRamGame;
			if (rectRamGame != null)
			{
				((FrameworkElement)rectRamGame).SizeChanged += val;
			}
		}
	}

	internal virtual Rectangle RectRamEmpty
	{
		[CompilerGenerated]
		get
		{
			return _RectRamEmpty;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SizeChangedEventHandler val = (SizeChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, SizeChangedEventArgs a1) =>
			{
				RefreshRamText();
			});
			Rectangle rectRamEmpty = _RectRamEmpty;
			if (rectRamEmpty != null)
			{
				((FrameworkElement)rectRamEmpty).SizeChanged -= val;
			}
			_RectRamEmpty = value;
			rectRamEmpty = _RectRamEmpty;
			if (rectRamEmpty != null)
			{
				((FrameworkElement)rectRamEmpty).SizeChanged += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabRamUsedTitle")]
	internal virtual TextBlock LabRamUsedTitle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabRamGameTitle")]
	internal virtual TextBlock LabRamGameTitle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabRamUsed")]
	internal virtual TextBlock LabRamUsed
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabRamTotal")]
	internal virtual TextBlock LabRamTotal
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual TextBlock LabRamGame
	{
		[CompilerGenerated]
		get
		{
			return _LabRamGame;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SizeChangedEventHandler val = (SizeChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, SizeChangedEventArgs a1) =>
			{
				RefreshRamText();
			});
			TextBlock labRamGame = _LabRamGame;
			if (labRamGame != null)
			{
				((FrameworkElement)labRamGame).SizeChanged -= val;
			}
			_LabRamGame = value;
			labRamGame = _LabRamGame;
			if (labRamGame != null)
			{
				((FrameworkElement)labRamGame).SizeChanged += val;
			}
		}
	}

	internal virtual MyComboBox ComboAdvanceRenderer
	{
		[CompilerGenerated]
		get
		{
			return _ComboAdvanceRenderer;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SelectionChangedEventHandler val = (SelectionChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, SelectionChangedEventArgs a1) =>
			{
				ComboAdvanceRenderer_SelectionChanged((MyComboBox)a0, a1);
			});
			MyComboBox comboAdvanceRenderer = _ComboAdvanceRenderer;
			if (comboAdvanceRenderer != null)
			{
				((Selector)comboAdvanceRenderer).SelectionChanged -= val;
			}
			_ComboAdvanceRenderer = value;
			comboAdvanceRenderer = _ComboAdvanceRenderer;
			if (comboAdvanceRenderer != null)
			{
				((Selector)comboAdvanceRenderer).SelectionChanged += val;
			}
		}
	}

	internal virtual MyIconButton BtnAdvanceJvmReset
	{
		[CompilerGenerated]
		get
		{
			return _BtnAdvanceJvmReset;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = BtnAdvanceJvmReset_Click;
			MyIconButton btnAdvanceJvmReset = _BtnAdvanceJvmReset;
			if (btnAdvanceJvmReset != null)
			{
				btnAdvanceJvmReset.Click -= obj;
			}
			_BtnAdvanceJvmReset = value;
			btnAdvanceJvmReset = _BtnAdvanceJvmReset;
			if (btnAdvanceJvmReset != null)
			{
				btnAdvanceJvmReset.Click += obj;
			}
		}
	}

	internal virtual MyTextBox TextAdvanceJvm
	{
		[CompilerGenerated]
		get
		{
			return _TextAdvanceJvm;
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
			if (_Closure_0024__._0024IR173_002D25 != null)
			{
				obj = _Closure_0024__._0024IR173_002D25;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR173_002D25 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			RoutedEventHandler value3 = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				TextAdvanceJvm_TextChanged();
			});
			MyTextBox textAdvanceJvm = _TextAdvanceJvm;
			if (textAdvanceJvm != null)
			{
				textAdvanceJvm.ValidatedTextChanged -= value2;
				textAdvanceJvm.ValidatedTextChanged -= value3;
			}
			_TextAdvanceJvm = value;
			textAdvanceJvm = _TextAdvanceJvm;
			if (textAdvanceJvm != null)
			{
				textAdvanceJvm.ValidatedTextChanged += value2;
				textAdvanceJvm.ValidatedTextChanged += value3;
			}
		}
	}

	internal virtual MyTextBox TextAdvanceGame
	{
		[CompilerGenerated]
		get
		{
			return _TextAdvanceGame;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR177_002D27 != null)
			{
				obj = _Closure_0024__._0024IR177_002D27;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR177_002D27 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			MyTextBox textAdvanceGame = _TextAdvanceGame;
			if (textAdvanceGame != null)
			{
				textAdvanceGame.ValidatedTextChanged -= value2;
			}
			_TextAdvanceGame = value;
			textAdvanceGame = _TextAdvanceGame;
			if (textAdvanceGame != null)
			{
				textAdvanceGame.ValidatedTextChanged += value2;
			}
		}
	}

	internal virtual MyTextBox TextAdvanceRun
	{
		[CompilerGenerated]
		get
		{
			return _TextAdvanceRun;
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
			if (_Closure_0024__._0024IR181_002D28 != null)
			{
				obj = _Closure_0024__._0024IR181_002D28;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR181_002D28 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			TextChangedEventHandler val2 = new TextChangedEventHandler(TextAdvanceRun_TextChanged);
			MyTextBox textAdvanceRun = _TextAdvanceRun;
			if (textAdvanceRun != null)
			{
				textAdvanceRun.ValidatedTextChanged -= value2;
				((TextBoxBase)textAdvanceRun).TextChanged -= val2;
			}
			_TextAdvanceRun = value;
			textAdvanceRun = _TextAdvanceRun;
			if (textAdvanceRun != null)
			{
				textAdvanceRun.ValidatedTextChanged += value2;
				((TextBoxBase)textAdvanceRun).TextChanged += val2;
			}
		}
	}

	internal virtual MyCheckBox CheckAdvanceRunWait
	{
		[CompilerGenerated]
		get
		{
			return _CheckAdvanceRunWait;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkAdvanceRunWait = _CheckAdvanceRunWait;
			if (checkAdvanceRunWait != null)
			{
				checkAdvanceRunWait.Change -= obj;
			}
			_CheckAdvanceRunWait = value;
			checkAdvanceRunWait = _CheckAdvanceRunWait;
			if (checkAdvanceRunWait != null)
			{
				checkAdvanceRunWait.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckAdvanceDisableJLW
	{
		[CompilerGenerated]
		get
		{
			return _CheckAdvanceDisableJLW;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkAdvanceDisableJLW = _CheckAdvanceDisableJLW;
			if (checkAdvanceDisableJLW != null)
			{
				checkAdvanceDisableJLW.Change -= obj;
			}
			_CheckAdvanceDisableJLW = value;
			checkAdvanceDisableJLW = _CheckAdvanceDisableJLW;
			if (checkAdvanceDisableJLW != null)
			{
				checkAdvanceDisableJLW.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckAdvanceDisableRW
	{
		[CompilerGenerated]
		get
		{
			return _CheckAdvanceDisableRW;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkAdvanceDisableRW = _CheckAdvanceDisableRW;
			if (checkAdvanceDisableRW != null)
			{
				checkAdvanceDisableRW.Change -= obj;
			}
			_CheckAdvanceDisableRW = value;
			checkAdvanceDisableRW = _CheckAdvanceDisableRW;
			if (checkAdvanceDisableRW != null)
			{
				checkAdvanceDisableRW.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckAdvanceGraphicCard
	{
		[CompilerGenerated]
		get
		{
			return _CheckAdvanceGraphicCard;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkAdvanceGraphicCard = _CheckAdvanceGraphicCard;
			if (checkAdvanceGraphicCard != null)
			{
				checkAdvanceGraphicCard.Change -= obj;
			}
			_CheckAdvanceGraphicCard = value;
			checkAdvanceGraphicCard = _CheckAdvanceGraphicCard;
			if (checkAdvanceGraphicCard != null)
			{
				checkAdvanceGraphicCard.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckAdvanceNoJavaw
	{
		[CompilerGenerated]
		get
		{
			return _CheckAdvanceNoJavaw;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkAdvanceNoJavaw = _CheckAdvanceNoJavaw;
			if (checkAdvanceNoJavaw != null)
			{
				checkAdvanceNoJavaw.Change -= obj;
			}
			_CheckAdvanceNoJavaw = value;
			checkAdvanceNoJavaw = _CheckAdvanceNoJavaw;
			if (checkAdvanceNoJavaw != null)
			{
				checkAdvanceNoJavaw.Change += obj;
			}
		}
	}

	internal virtual MyExtraTextButton BtnSwitch
	{
		[CompilerGenerated]
		get
		{
			return _BtnSwitch;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyExtraTextButton.ClickEventHandler obj = BtnSwitch_Click;
			MyExtraTextButton btnSwitch = _BtnSwitch;
			if (btnSwitch != null)
			{
				btnSwitch.Click -= obj;
			}
			_BtnSwitch = value;
			btnSwitch = _BtnSwitch;
			if (btnSwitch != null)
			{
				btnSwitch.Click += obj;
			}
		}
	}

	public PageSetupLaunch()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageSetupLaunch_Loaded);
		IsLoad = false;
		RamTextLeft = 2;
		RamTextRight = 1;
		InitializeComponent();
	}

	private void PageSetupLaunch_Loaded(object sender, RoutedEventArgs e)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		((ScrollViewer)PanBack).ScrollToHome();
		RefreshRam(ShowAnim: false);
		if ((object)ModMinecraft.McInstanceCurrent == null)
		{
			((UIElement)BtnSwitch).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)BtnSwitch).Visibility = (Visibility)0;
		}
		checked
		{
			if (!IsLoad)
			{
				IsLoad = true;
				ModAnimation.AniControlEnabled++;
				Reload();
				ModAnimation.AniControlEnabled--;
				DispatcherTimer val = new DispatcherTimer
				{
					Interval = new TimeSpan(0, 0, 0, 1)
				};
				val.Tick += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
				{
					RefreshRam();
				});
				val.Start();
			}
		}
	}

	public void Reload()
	{
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_0310: Expected O, but got Unknown
		try
		{
			((TextBox)TextArgumentTitle).Text = Conversions.ToString(ModBase.Setup.Get("LaunchArgumentTitle"));
			((TextBox)TextArgumentInfo).Text = Conversions.ToString(ModBase.Setup.Get("LaunchArgumentInfo"));
			((Selector)ComboArgumentIndieV2).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("LaunchArgumentIndieV2"));
			((Selector)ComboArgumentVisibie).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("LaunchArgumentVisible"));
			((Selector)ComboArgumentPriority).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("LaunchArgumentPriority"));
			((Selector)ComboArgumentWindowType).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("LaunchArgumentWindowType"));
			((TextBox)TextArgumentWindowWidth).Text = Conversions.ToString(ModBase.Setup.Get("LaunchArgumentWindowWidth"));
			((TextBox)TextArgumentWindowHeight).Text = Conversions.ToString(ModBase.Setup.Get("LaunchArgumentWindowHeight"));
			CheckArgumentRam.Checked = (bool?)ModBase.Setup.Get("LaunchArgumentRam");
			((Selector)ComboMsAuthType).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("LoginMsAuthType"));
			((Selector)ComboPreferredIpStack).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("LaunchPreferredIpStack"));
			((MyRadioBox)base.FindName(Conversions.ToString(Operators.ConcatenateObject((object)"RadioRamType", ModBase.Setup.Load("LaunchRamType"))))).Checked = true;
			SliderRamCustom.Value = Conversions.ToInteger(ModBase.Setup.Get("LaunchRamCustom"));
			((Selector)ComboAdvanceRenderer).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("LaunchAdvanceRenderer"));
			((TextBox)TextAdvanceJvm).Text = Conversions.ToString(ModBase.Setup.Get("LaunchAdvanceJvm"));
			((TextBox)TextAdvanceGame).Text = Conversions.ToString(ModBase.Setup.Get("LaunchAdvanceGame"));
			((TextBox)TextAdvanceRun).Text = Conversions.ToString(ModBase.Setup.Get("LaunchAdvanceRun"));
			CheckAdvanceRunWait.Checked = (bool?)ModBase.Setup.Get("LaunchAdvanceRunWait");
			CheckAdvanceDisableRW.Checked = (bool?)ModBase.Setup.Get("LaunchAdvanceDisableRW");
			CheckAdvanceGraphicCard.Checked = (bool?)ModBase.Setup.Get("LaunchAdvanceGraphicCard");
			CheckAdvanceNoJavaw.Checked = (bool?)ModBase.Setup.Get("LaunchAdvanceNoJavaw");
			if (ModBase.IsArm64System)
			{
				CheckAdvanceDisableJLW.Checked = true;
				((UIElement)CheckAdvanceDisableJLW).IsEnabled = false;
				((FrameworkElement)CheckAdvanceDisableJLW).ToolTip = "在启动游戏时不使用 Java Wrapper 进行包装。&#xa;由于系统为 ARM64 架构，Java Wrapper 已被强制禁用。";
			}
			else
			{
				CheckAdvanceDisableJLW.Checked = (bool?)ModBase.Setup.Get("LaunchAdvanceDisableJLW");
			}
		}
		catch (NullReferenceException val)
		{
			ProjectData.SetProjectError((System.Exception)val);
			NullReferenceException ex = val;
			ModBase.Log((System.Exception)(object)ex, "启动设置项存在异常，已被自动重置", ModBase.LogLevel.Msgbox);
			Reset();
			ProjectData.ClearProjectError();
		}
		catch (System.Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			System.Exception ex3 = ex2;
			ModBase.Log(ex3, "重载启动设置时出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public void Reset()
	{
		try
		{
			ModBase.Setup.Reset("LaunchArgumentTitle");
			ModBase.Setup.Reset("LaunchArgumentInfo");
			ModBase.Setup.Reset("LaunchArgumentIndieV2");
			ModBase.Setup.Reset("LaunchArgumentVisible");
			ModBase.Setup.Reset("LaunchArgumentWindowType");
			ModBase.Setup.Reset("LaunchArgumentWindowWidth");
			ModBase.Setup.Reset("LaunchArgumentWindowHeight");
			ModBase.Setup.Reset("LaunchArgumentPriority");
			ModBase.Setup.Reset("LaunchPreferredIpStack");
			ModBase.Setup.Reset("LaunchArgumentRam");
			ModBase.Setup.Reset("LaunchRamType");
			ModBase.Setup.Reset("LaunchRamCustom");
			ModBase.Setup.Reset("LaunchAdvanceJvm");
			ModBase.Setup.Reset("LaunchAdvanceGame");
			ModBase.Setup.Reset("LaunchAdvanceRun");
			ModBase.Setup.Reset("LaunchAdvanceRunWait");
			ModBase.Setup.Reset("LaunchAdvanceDisableJLW");
			ModBase.Setup.Reset("LaunchAdvanceGraphicCard");
			ModBase.Setup.Reset("LaunchAdvanceNoJavaw");
			ModBase.Setup.Reset("LoginMsAuthType");
			ModBase.Setup.Reset("LaunchArgumentJavaUser");
			ModBase.Setup.Reset("LaunchArgumentJavaSelect");
			ModBase.Setup.Reset("LaunchAdvanceRenderer");
			ModBase.Log("[Setup] 已初始化启动设置");
			ModMain.Hint("已初始化启动设置！", ModMain.HintType.Finish, Log: false);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "初始化启动设置失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
		Reload();
	}

	private static void RadioBoxChange(MyRadioBox sender, object e)
	{
		string[] array = ((FrameworkElement)sender).Tag.ToString().Split("/", (StringSplitOptions)0);
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(array[0], int.Parse(array[1]));
		}
	}

	private static void TextBoxChange(MyTextBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), ((TextBox)sender).Text);
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

	private static void CheckBoxChange(MyCheckBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), sender.Checked);
		}
	}

	public void RamType(int Type)
	{
		if (SliderRamCustom != null)
		{
			((UIElement)SliderRamCustom).IsEnabled = Type == 1;
		}
	}

	public void RefreshRam(bool ShowAnim)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (LabRamGame != null && LabRamUsed != null && !(ModMain.FrmMain.PageCurrent != FormMain.PageType.Setup) && ModMain.FrmSetupLeft.PageID == FormMain.PageSubType.Default)
			{
				double num = Math.Round(GetRam(ModMinecraft.McInstanceCurrent, UseVersionJavaSetup: false), 5);
				ValueTuple<ulong, ulong> physicalMemoryBytes = KernelInterop.GetPhysicalMemoryBytes();
				double num2 = Math.Round((double)physicalMemoryBytes.Item1 / 1024.0 / 1024.0 / 1024.0, 1);
				double num3 = Math.Round((double)physicalMemoryBytes.Item2 / 1024.0 / 1024.0 / 1024.0, 1);
				double num4 = Math.Round(Math.Min(num, num3), 5);
				double num5 = Math.Round(num2 - num3, 5);
				double num6 = Math.Round(ModBase.MathClamp(num2 - num5 - num, 0.0, 1000.0), 1);
				if (num2 <= 1.5)
				{
					SliderRamCustom.MaxValue = (int)Math.Round(Math.Max(Math.Floor((num2 - 0.3) / 0.1), 1.0));
				}
				else if (num2 <= 8.0)
				{
					SliderRamCustom.MaxValue = (int)Math.Round(Math.Floor((num2 - 1.5) / 0.5) + 12.0);
				}
				else if (num2 <= 16.0)
				{
					SliderRamCustom.MaxValue = (int)Math.Round(Math.Floor((num2 - 8.0) / 1.0) + 25.0);
				}
				else
				{
					SliderRamCustom.MaxValue = (int)Math.Round(Math.Floor((num2 - 16.0) / 2.0) + 33.0);
				}
				LabRamGame.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((num == Math.Floor(num)) ? (Conversions.ToString(num) + ".0") : ((object)num), (object)" GB"), (num != num4) ? Operators.ConcatenateObject(Operators.ConcatenateObject((object)" (可用 ", (num4 == Math.Floor(num4)) ? (Conversions.ToString(num4) + ".0") : ((object)num4)), (object)" GB)") : ""));
				LabRamUsed.Text = Conversions.ToString(Operators.ConcatenateObject((num5 == Math.Floor(num5)) ? (Conversions.ToString(num5) + ".0") : ((object)num5), (object)" GB"));
				LabRamTotal.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)" / ", (num2 == Math.Floor(num2)) ? (Conversions.ToString(num2) + ".0") : ((object)num2)), (object)" GB"));
				((UIElement)LabRamWarn).Visibility = (Visibility)((num != 1.0 || ModJava.IsGameSet64BitJava() || ModBase.Is32BitSystem || !Enumerable.Any<JavaInfo>((System.Collections.Generic.IEnumerable<JavaInfo>)ModJava.Javas.JavaList)) ? 2 : 0);
				((UIElement)HintRamTooHigh).Visibility = (Visibility)((!(num / num2 > 0.75)) ? 2 : 0);
				if (ShowAnim)
				{
					ModAnimation.AniData[] array = new ModAnimation.AniData[3];
					ColumnDefinition columnRamUsed = ColumnRamUsed;
					GridLength width = ColumnRamUsed.Width;
					array[0] = ModAnimation.AaGridLengthWidth(columnRamUsed, num5 - width.Value, 800, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong));
					ColumnDefinition columnRamGame = ColumnRamGame;
					width = ColumnRamGame.Width;
					array[1] = ModAnimation.AaGridLengthWidth(columnRamGame, num4 - width.Value, 800, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong));
					ColumnDefinition columnRamEmpty = ColumnRamEmpty;
					width = ColumnRamEmpty.Width;
					array[2] = ModAnimation.AaGridLengthWidth(columnRamEmpty, num6 - width.Value, 800, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Strong));
					ModAnimation.AniStart((System.Collections.IList)(object)array, "SetupLaunch Ram Grid");
				}
				else
				{
					ColumnRamUsed.Width = new GridLength(num5, (GridUnitType)2);
					ColumnRamGame.Width = new GridLength(num4, (GridUnitType)2);
					ColumnRamEmpty.Width = new GridLength(num6, (GridUnitType)2);
				}
			}
		}
	}

	private void RefreshRam()
	{
		RefreshRam(ShowAnim: true);
	}

	private void RefreshRamText()
	{
		//IL_0483: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		double actualWidth = ((FrameworkElement)RectRamUsed).ActualWidth;
		double actualWidth2 = ((FrameworkElement)PanRamDisplay).ActualWidth;
		double actualWidth3 = ((FrameworkElement)LabRamGame).ActualWidth;
		double actualWidth4 = ((FrameworkElement)LabRamUsed).ActualWidth;
		double actualWidth5 = ((FrameworkElement)LabRamTotal).ActualWidth;
		double actualWidth6 = ((FrameworkElement)LabRamGameTitle).ActualWidth;
		double actualWidth7 = ((FrameworkElement)LabRamUsedTitle).ActualWidth;
		int num = ((!(actualWidth - 30.0 < actualWidth4) && !(actualWidth - 30.0 < actualWidth7)) ? ((actualWidth - 25.0 < actualWidth4 + actualWidth5) ? 1 : 2) : 0);
		if (RamTextLeft != num)
		{
			RamTextLeft = num;
			switch (num)
			{
			case 0:
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
				{
					ModAnimation.AaOpacity(LabRamUsed, 0.0 - ((UIElement)LabRamUsed).Opacity, 100),
					ModAnimation.AaOpacity(LabRamTotal, 0.0 - ((UIElement)LabRamTotal).Opacity, 100),
					ModAnimation.AaOpacity(LabRamUsedTitle, 0.0 - ((UIElement)LabRamUsedTitle).Opacity, 100)
				}, "SetupLaunch Ram TextLeft");
				break;
			case 1:
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
				{
					ModAnimation.AaOpacity(LabRamUsed, 1.0 - ((UIElement)LabRamUsed).Opacity, 100),
					ModAnimation.AaOpacity(LabRamTotal, 0.0 - ((UIElement)LabRamTotal).Opacity, 100),
					ModAnimation.AaOpacity(LabRamUsedTitle, 0.7 - ((UIElement)LabRamUsedTitle).Opacity, 100)
				}, "SetupLaunch Ram TextLeft");
				break;
			case 2:
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
				{
					ModAnimation.AaOpacity(LabRamUsed, 1.0 - ((UIElement)LabRamUsed).Opacity, 100),
					ModAnimation.AaOpacity(LabRamTotal, 1.0 - ((UIElement)LabRamTotal).Opacity, 100),
					ModAnimation.AaOpacity(LabRamUsedTitle, 0.7 - ((UIElement)LabRamUsedTitle).Opacity, 100)
				}, "SetupLaunch Ram TextLeft");
				break;
			}
		}
		int num2 = ((!(actualWidth2 < actualWidth3 + 2.0 + actualWidth) && !(actualWidth2 < actualWidth6 + 2.0 + actualWidth)) ? 1 : 0);
		Thickness margin;
		if (num2 == 0)
		{
			if (ModAnimation.AniControlEnabled == 0 && (RamTextRight != num2 || ModAnimation.AniIsRun("SetupLaunch Ram TextRight")))
			{
				ModAnimation.AniData[] array = new ModAnimation.AniData[2];
				TextBlock labRamGame = LabRamGame;
				double num3 = actualWidth2 - actualWidth3;
				margin = ((FrameworkElement)LabRamGame).Margin;
				array[0] = ModAnimation.AaX(labRamGame, num3 - margin.Left, 100, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak));
				TextBlock labRamGameTitle = LabRamGameTitle;
				double num4 = actualWidth2 - actualWidth6;
				margin = ((FrameworkElement)LabRamGameTitle).Margin;
				array[1] = ModAnimation.AaX(labRamGameTitle, num4 - margin.Left, 100, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak));
				ModAnimation.AniStart((System.Collections.IList)(object)array, "SetupLaunch Ram TextRight");
			}
			else
			{
				ModAnimation.AniStop("SetupLaunch Ram TextRight");
				((FrameworkElement)LabRamGame).Margin = new Thickness(actualWidth2 - actualWidth3, 3.0, 0.0, 0.0);
				((FrameworkElement)LabRamGameTitle).Margin = new Thickness(actualWidth2 - actualWidth6, 0.0, 0.0, 5.0);
			}
		}
		else if (ModAnimation.AniControlEnabled == 0 && (RamTextRight != num2 || ModAnimation.AniIsRun("SetupLaunch Ram TextRight")))
		{
			ModAnimation.AniData[] array2 = new ModAnimation.AniData[2];
			TextBlock labRamGame2 = LabRamGame;
			double num5 = 2.0 + actualWidth;
			margin = ((FrameworkElement)LabRamGame).Margin;
			array2[0] = ModAnimation.AaX(labRamGame2, num5 - margin.Left, 100, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak));
			TextBlock labRamGameTitle2 = LabRamGameTitle;
			double num6 = 2.0 + actualWidth;
			margin = ((FrameworkElement)LabRamGameTitle).Margin;
			array2[1] = ModAnimation.AaX(labRamGameTitle2, num6 - margin.Left, 100, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak));
			ModAnimation.AniStart((System.Collections.IList)(object)array2, "SetupLaunch Ram TextRight");
		}
		else
		{
			ModAnimation.AniStop("SetupLaunch Ram TextRight");
			((FrameworkElement)LabRamGame).Margin = new Thickness(2.0 + actualWidth, 3.0, 0.0, 0.0);
			((FrameworkElement)LabRamGameTitle).Margin = new Thickness(2.0 + actualWidth, 0.0, 0.0, 5.0);
		}
		RamTextRight = num2;
	}

	public static double GetRam(ModMinecraft.McInstance Version, bool UseVersionJavaSetup, bool? Is32BitJava = null)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		double num8 = default(double);
		if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("LaunchRamType"), (object)0, false))
		{
			double num = Math.Round((double)KernelInterop.GetAvailablePhysicalMemoryBytes() / 1024.0 / 1024.0 / 1024.0 * 10.0) / 10.0;
			if ((object)Version != null && !Version.IsLoaded)
			{
				Version.Load();
			}
			double num3;
			double num4;
			double num5;
			double num6;
			if ((object)Version != null && Version.Modable)
			{
				DirectoryInfo val = new DirectoryInfo(Version.PathIndie + "mods\\");
				int num2 = (val.Exists ? val.GetFiles().Length : 0);
				num3 = 0.5 + (double)num2 / 150.0;
				num4 = 1.5 + (double)num2 / 90.0;
				num5 = 2.7 + (double)num2 / 50.0;
				num6 = 4.5 + (double)num2 / 25.0;
			}
			else if ((object)Version != null && Version.Version.HasOptiFine)
			{
				num3 = 0.5;
				num4 = 1.5;
				num5 = 3.0;
				num6 = 5.0;
			}
			else
			{
				num3 = 0.5;
				num4 = 1.5;
				num5 = 2.5;
				num6 = 4.0;
			}
			double num7 = num4;
			num8 += Math.Min(num, num7);
			num -= num7;
			if (!(num < 0.1))
			{
				num7 = num5 - num4;
				num8 += Math.Min(num * 0.7, num7);
				num -= num7 / 0.7;
				if (!(num < 0.1))
				{
					num7 = num6 - num5;
					num8 += Math.Min(num * 0.4, num7);
					num -= num7 / 0.4;
					if (!(num < 0.1))
					{
						num7 = num6;
						num8 += Math.Min(num * 0.15, num7);
						num -= num7 / 0.15;
						_ = 0.1;
					}
				}
			}
			num8 = Math.Round(Math.Max(num8, num3), 1);
		}
		else
		{
			int num9 = Conversions.ToInteger(ModBase.Setup.Get("LaunchRamCustom"));
			num8 = ((num9 <= 12) ? ((double)num9 * 0.1 + 0.3) : checked((num9 <= 25) ? ((double)(num9 - 12) * 0.5 + 1.5) : ((num9 > 33) ? ((double)((num9 - 33) * 2 + 16)) : ((double)((num9 - 25) * 1 + 8)))));
		}
		if (Is32BitJava ?? (!ModJava.IsGameSet64BitJava(UseVersionJavaSetup ? Version : null)))
		{
			num8 = Math.Min(1.0, num8);
		}
		return num8;
	}

	private void WindowTypeUIRefresh()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		if (ComboArgumentWindowType != null)
		{
			if (((Selector)ComboArgumentWindowType).SelectedIndex == 3 && LabArgumentWindowMiddle != null && (int)((UIElement)LabArgumentWindowMiddle).Visibility == 2)
			{
				((UIElement)LabArgumentWindowMiddle).Visibility = (Visibility)0;
				((UIElement)TextArgumentWindowHeight).Visibility = (Visibility)0;
				((UIElement)TextArgumentWindowWidth).Visibility = (Visibility)0;
			}
			else if (((Selector)ComboArgumentWindowType).SelectedIndex != 3 && LabArgumentWindowMiddle != null && (int)((UIElement)LabArgumentWindowMiddle).Visibility == 0)
			{
				((UIElement)LabArgumentWindowMiddle).Visibility = (Visibility)2;
				((UIElement)TextArgumentWindowHeight).Visibility = (Visibility)2;
				((UIElement)TextArgumentWindowWidth).Visibility = (Visibility)2;
			}
		}
	}

	private void ComboArgumentVisibie_SizeChanged(object sender, SelectionChangedEventArgs e)
	{
		if (ModAnimation.AniControlEnabled == 0 && ((Selector)ComboArgumentVisibie).SelectedIndex == 0 && ModMain.MyMsgBox("若在游戏启动后立即关闭启动器，崩溃检测、更改游戏标题等功能将失效。\r\n如果想保留这些功能，可以选择让启动器在游戏启动后隐藏，游戏退出后自动关闭。", "提醒", "继续", "取消") == 2)
		{
			((Selector)ComboArgumentVisibie).SelectedItem = RuntimeHelpers.GetObjectValue(e.RemovedItems[0]);
		}
	}

	private void CheckArgumentRam_Change()
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			bool? @checked = CheckArgumentRam.Checked;
			if (!((!@checked) ?? @checked).GetValueOrDefault() && ModMain.MyMsgBox("内存优化会显著延长启动耗时，建议仅在内存不足时开启。\r\n如果你在使用机械硬盘，这还可能导致一小段时间的严重卡顿。" + (ProcessInterop.IsAdmin() ? "" : string.Format("{0}{1}每次启动游戏，PCL 都需要申请管理员权限以进行内存优化。{2}若想自动授予权限，可以右键 PCL，打开 属性 → 兼容性 → 以管理员身份运行此程序。", (object)"\r\n", (object)"\r\n", (object)"\r\n")), "提醒", "确定", "取消") == 2)
			{
				CheckArgumentRam.Checked = false;
			}
		}
	}

	private void ComboArgumentIndie_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModMain.MyMsgBox("默认策略只会对今后新安装的实例生效。\r\n已有实例的隔离策略需要在它的设置中调整。");
		}
	}

	private void BtnJavaManage_Click(object sender, ModBase.RouteEventArgs e)
	{
		ModMain.FrmMain.PageChange(new FormMain.PageStackData
		{
			Page = FormMain.PageType.SetupJava
		});
	}

	private void TextAdvanceRun_TextChanged(object sender, TextChangedEventArgs e)
	{
		((UIElement)CheckAdvanceRunWait).Visibility = (Visibility)((Operators.CompareString(((TextBox)TextAdvanceRun).Text, "", false) == 0) ? 2 : 0);
	}

	private void TextAdvanceJvm_TextChanged()
	{
		((UIElement)BtnAdvanceJvmReset).Visibility = (Visibility)(Operators.ConditionalCompareObjectEqual((object)((TextBox)TextAdvanceJvm).Text, ModBase.Setup.GetDefault("LaunchAdvanceJvm"), false) ? 1 : 0);
	}

	private void BtnAdvanceJvmReset_Click(object sender, EventArgs e)
	{
		ModBase.Setup.Reset("LaunchAdvanceJvm");
		Reload();
	}

	private void ComboAdvanceRenderer_SelectionChanged(MyComboBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled != 0)
		{
			return;
		}
		if (Conversions.ToBoolean((object)(Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("HintRenderer"))) && ((Selector)ComboAdvanceRenderer).SelectedIndex != 0)))
		{
			if (ModMain.MyMsgBox("修改此项会严重影响游戏的稳定性与性能。如果你不知道你在做什么，不要修改此选项！\r\n你确定要继续修改吗？", "警告", "我知道我在做什么", "取消", "", IsWarn: true) == 2)
			{
				((Selector)ComboAdvanceRenderer).SelectedItem = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(e, (System.Type)null, "RemovedItems", new object[] { 0 }, (string[])null, (System.Type[])null, (bool[])null));
			}
			else
			{
				ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), ((Selector)sender).SelectedIndex);
				ModBase.Setup.Set("HintRenderer", true);
			}
		}
		else
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), ((Selector)sender).SelectedIndex);
		}
	}

	private void BtnSwitch_Click(object sender, MouseButtonEventArgs e)
	{
		ModMinecraft.McInstanceCurrent.Load();
		PageInstanceLeft.Instance = ModMinecraft.McInstanceCurrent;
		ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSetup, FormMain.PageSubType.DownloadInstall);
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagesetup/pagesetuplaunch.xaml", (UriKind)2);
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
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanMain = (StackPanel)target;
			break;
		case 3:
			CardArgument = (MyCard)target;
			break;
		case 4:
			ComboArgumentIndieV2 = (MyComboBox)target;
			break;
		case 5:
			TextArgumentTitle = (MyTextBox)target;
			break;
		case 6:
			TextArgumentInfo = (MyTextBox)target;
			break;
		case 7:
			ComboArgumentVisibie = (MyComboBox)target;
			break;
		case 8:
			ComboArgumentPriority = (MyComboBox)target;
			break;
		case 9:
			PanArgumentWindow = (Grid)target;
			break;
		case 10:
			ComboArgumentWindowType = (MyComboBox)target;
			break;
		case 11:
			TextArgumentWindowWidth = (MyTextBox)target;
			break;
		case 12:
			LabArgumentWindowMiddle = (TextBlock)target;
			break;
		case 13:
			TextArgumentWindowHeight = (MyTextBox)target;
			break;
		case 14:
			ComboMsAuthType = (MyComboBox)target;
			break;
		case 15:
			ComboPreferredIpStack = (MyComboBox)target;
			break;
		case 16:
			BtnGotoJavaManage = (MyIconTextButton)target;
			break;
		case 17:
			LabRamWarn = (MyHint)target;
			break;
		case 18:
			HintRamTooHigh = (MyHint)target;
			break;
		case 19:
			RadioRamType0 = (MyRadioBox)target;
			break;
		case 20:
			RadioRamType1 = (MyRadioBox)target;
			break;
		case 21:
			SliderRamCustom = (MySlider)target;
			break;
		case 22:
			CheckArgumentRam = (MyCheckBox)target;
			break;
		case 23:
			PanRamDisplay = (Grid)target;
			break;
		case 24:
			ColumnRamUsed = (ColumnDefinition)target;
			break;
		case 25:
			ColumnRamGame = (ColumnDefinition)target;
			break;
		case 26:
			ColumnRamEmpty = (ColumnDefinition)target;
			break;
		case 27:
			RectRamUsed = (Rectangle)target;
			break;
		case 28:
			RectRamGame = (Rectangle)target;
			break;
		case 29:
			RectRamEmpty = (Rectangle)target;
			break;
		case 30:
			LabRamUsedTitle = (TextBlock)target;
			break;
		case 31:
			LabRamGameTitle = (TextBlock)target;
			break;
		case 32:
			LabRamUsed = (TextBlock)target;
			break;
		case 33:
			LabRamTotal = (TextBlock)target;
			break;
		case 34:
			LabRamGame = (TextBlock)target;
			break;
		case 35:
			ComboAdvanceRenderer = (MyComboBox)target;
			break;
		case 36:
			BtnAdvanceJvmReset = (MyIconButton)target;
			break;
		case 37:
			TextAdvanceJvm = (MyTextBox)target;
			break;
		case 38:
			TextAdvanceGame = (MyTextBox)target;
			break;
		case 39:
			TextAdvanceRun = (MyTextBox)target;
			break;
		case 40:
			CheckAdvanceRunWait = (MyCheckBox)target;
			break;
		case 41:
			CheckAdvanceDisableJLW = (MyCheckBox)target;
			break;
		case 42:
			CheckAdvanceDisableRW = (MyCheckBox)target;
			break;
		case 43:
			CheckAdvanceGraphicCard = (MyCheckBox)target;
			break;
		case 44:
			CheckAdvanceNoJavaw = (MyCheckBox)target;
			break;
		case 45:
			BtnSwitch = (MyExtraTextButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
