using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Minecraft;
using PCL.Core.Utils.OS;

namespace PCL;

[DesignerGenerated]
public class PageInstanceSetup : MyPageRight, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action _0024I24_002D1;

		public static Action _0024I24_002D0;

		public static SelectionChangedEventHandler _0024IR50_002D2;

		public static RoutedEventHandler _0024IR54_002D3;

		public static MyCheckBox.ChangeEventHandler _0024IR58_002D4;

		public static RoutedEventHandler _0024IR62_002D6;

		public static IMyRadio.CheckEventHandler _0024IR78_002D8;

		public static IMyRadio.CheckEventHandler _0024IR82_002D10;

		public static IMyRadio.CheckEventHandler _0024IR86_002D12;

		public static MySlider.ChangeEventHandler _0024IR90_002D14;

		public static SelectionChangedEventHandler _0024IR94_002D16;

		public static RoutedEventHandler _0024IR174_002D21;

		public static RoutedEventHandler _0024IR182_002D24;

		public static RoutedEventHandler _0024IR190_002D26;

		public static RoutedEventHandler _0024IR194_002D27;

		public static RoutedEventHandler _0024IR194_002D28;

		public static RoutedEventHandler _0024IR218_002D32;

		public static RoutedEventHandler _0024IR222_002D33;

		public static RoutedEventHandler _0024IR226_002D34;

		public static MyCheckBox.ChangeEventHandler _0024IR230_002D35;

		public static MyCheckBox.ChangeEventHandler _0024IR234_002D36;

		public static MyCheckBox.ChangeEventHandler _0024IR238_002D37;

		public static MyCheckBox.ChangeEventHandler _0024IR242_002D38;

		public static MyCheckBox.ChangeEventHandler _0024IR246_002D39;

		public static MyCheckBox.ChangeEventHandler _0024IR250_002D40;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__24_002D0()
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			Thread.Sleep(150);
			object action;
			if (_0024I24_002D1 != null)
			{
				action = _0024I24_002D1;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					ModMain.FrmLaunchLeft.RefreshPage(Anim: true, ModLaunch.McLoginType.Auth);
				};
				_0024I24_002D1 = val;
				action = (object)val;
			}
			ModBase.RunInUi((Action)action);
		}

		[SpecialName]
		internal void _Lambda_0024__24_002D1()
		{
			ModMain.FrmLaunchLeft.RefreshPage(Anim: true, ModLaunch.McLoginType.Auth);
		}

		[SpecialName]
		internal void _Lambda_0024__R50_002D2(object a0, SelectionChangedEventArgs a1)
		{
			CheckBoxLikeComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R54_002D3(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R58_002D4(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R62_002D6(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R78_002D8(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R82_002D10(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R86_002D12(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R90_002D14(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R94_002D16(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R174_002D21(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R182_002D24(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R190_002D26(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R194_002D27(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R194_002D28(object a0, RoutedEventArgs a1)
		{
			TextServerEnter_Change((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R218_002D32(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R222_002D33(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R226_002D34(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R230_002D35(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R234_002D36(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R238_002D37(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R242_002D38(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R246_002D39(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R250_002D40(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}
	}

	private bool IsLoaded;

	private int RamTextLeft;

	private int RamTextRight;

	private int ComboServerLoginLast;

	private bool IsReverting;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboArgumentIndieV2")]
	private MyComboBox _ComboArgumentIndieV2;

	[CompilerGenerated]
	[AccessedThroughProperty("TextArgumentTitle")]
	private MyTextBox _TextArgumentTitle;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckArgumentTitleEmpty")]
	private MyCheckBox _CheckArgumentTitleEmpty;

	[CompilerGenerated]
	[AccessedThroughProperty("TextArgumentInfo")]
	private MyTextBox _TextArgumentInfo;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboArgumentJava")]
	private MyComboBox _ComboArgumentJava;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioRamType2")]
	private MyRadioBox _RadioRamType2;

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
	[AccessedThroughProperty("ComboRamOptimize")]
	private MyComboBox _ComboRamOptimize;

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
	[AccessedThroughProperty("ComboServerLoginRequire")]
	private MyComboBox _ComboServerLoginRequire;

	[CompilerGenerated]
	[AccessedThroughProperty("TextServerAuthServer")]
	private MyTextBox _TextServerAuthServer;

	[CompilerGenerated]
	[AccessedThroughProperty("TextServerAuthRegister")]
	private MyTextBox _TextServerAuthRegister;

	[CompilerGenerated]
	[AccessedThroughProperty("TextServerAuthName")]
	private MyTextBox _TextServerAuthName;

	[CompilerGenerated]
	[AccessedThroughProperty("TextServerEnter")]
	private MyTextBox _TextServerEnter;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnServerAuthLittle")]
	private MyButton _BtnServerAuthLittle;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnServerAuthLock")]
	private MyButton _BtnServerAuthLock;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnServerNewProfile")]
	private MyButton _BtnServerNewProfile;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboAdvanceRenderer")]
	private MyComboBox _ComboAdvanceRenderer;

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
	[AccessedThroughProperty("CheckAdvanceJava")]
	private MyCheckBox _CheckAdvanceJava;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckAdvanceAssetsV2")]
	private MyCheckBox _CheckAdvanceAssetsV2;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckAdvanceDisableJLW")]
	private MyCheckBox _CheckAdvanceDisableJLW;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckAdvanceUseProxyV2")]
	private MyCheckBox _CheckAdvanceUseProxyV2;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckAdvanceDisableRW")]
	private MyCheckBox _CheckAdvanceDisableRW;

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
			if (_Closure_0024__._0024IR50_002D2 != null)
			{
				obj = _Closure_0024__._0024IR50_002D2;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					CheckBoxLikeComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR50_002D2 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			SelectionChangedEventHandler val3 = new SelectionChangedEventHandler(ComboArgumentIndieV2_SelectionChanged);
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
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR54_002D3 != null)
			{
				obj = _Closure_0024__._0024IR54_002D3;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR54_002D3 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			TextChangedEventHandler val2 = new TextChangedEventHandler(TextArgumentTitle_TextChanged);
			MyTextBox textArgumentTitle = _TextArgumentTitle;
			if (textArgumentTitle != null)
			{
				textArgumentTitle.ValidatedTextChanged -= value2;
				((TextBoxBase)textArgumentTitle).TextChanged -= val2;
			}
			_TextArgumentTitle = value;
			textArgumentTitle = _TextArgumentTitle;
			if (textArgumentTitle != null)
			{
				textArgumentTitle.ValidatedTextChanged += value2;
				((TextBoxBase)textArgumentTitle).TextChanged += val2;
			}
		}
	}

	internal virtual MyCheckBox CheckArgumentTitleEmpty
	{
		[CompilerGenerated]
		get
		{
			return _CheckArgumentTitleEmpty;
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
				CheckArgumentTitleEmpty_Change((MyCheckBox)a0, a1);
			};
			MyCheckBox checkArgumentTitleEmpty = _CheckArgumentTitleEmpty;
			if (checkArgumentTitleEmpty != null)
			{
				checkArgumentTitleEmpty.Change -= obj;
				checkArgumentTitleEmpty.Change -= obj2;
			}
			_CheckArgumentTitleEmpty = value;
			checkArgumentTitleEmpty = _CheckArgumentTitleEmpty;
			if (checkArgumentTitleEmpty != null)
			{
				checkArgumentTitleEmpty.Change += obj;
				checkArgumentTitleEmpty.Change += obj2;
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
			if (_Closure_0024__._0024IR62_002D6 != null)
			{
				obj = _Closure_0024__._0024IR62_002D6;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR62_002D6 = val;
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

	internal virtual MyComboBox ComboArgumentJava
	{
		[CompilerGenerated]
		get
		{
			return _ComboArgumentJava;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler val = new EventHandler(ComboArgumentJava_DropDownOpened);
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, SelectionChangedEventArgs a1) =>
			{
				JavaSelectionUpdate();
			});
			MyComboBox comboArgumentJava = _ComboArgumentJava;
			if (comboArgumentJava != null)
			{
				((ComboBox)comboArgumentJava).DropDownOpened -= val;
				((Selector)comboArgumentJava).SelectionChanged -= val2;
			}
			_ComboArgumentJava = value;
			comboArgumentJava = _ComboArgumentJava;
			if (comboArgumentJava != null)
			{
				((ComboBox)comboArgumentJava).DropDownOpened += val;
				((Selector)comboArgumentJava).SelectionChanged += val2;
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

	internal virtual MyRadioBox RadioRamType2
	{
		[CompilerGenerated]
		get
		{
			return _RadioRamType2;
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
			MyRadioBox radioRamType = _RadioRamType2;
			if (radioRamType != null)
			{
				radioRamType.Check -= obj;
				radioRamType.Check -= obj2;
			}
			_RadioRamType2 = value;
			radioRamType = _RadioRamType2;
			if (radioRamType != null)
			{
				radioRamType.Check += obj;
				radioRamType.Check += obj2;
			}
		}
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

	internal virtual MyComboBox ComboRamOptimize
	{
		[CompilerGenerated]
		get
		{
			return _ComboRamOptimize;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR94_002D16 != null)
			{
				obj = _Closure_0024__._0024IR94_002D16;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR94_002D16 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			MyComboBox comboRamOptimize = _ComboRamOptimize;
			if (comboRamOptimize != null)
			{
				((Selector)comboRamOptimize).SelectionChanged -= val2;
			}
			_ComboRamOptimize = value;
			comboRamOptimize = _ComboRamOptimize;
			if (comboRamOptimize != null)
			{
				((Selector)comboRamOptimize).SelectionChanged += val2;
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

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardServer")]
	internal virtual MyCard CardServer
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintServerLoginLock")]
	internal virtual MyHint HintServerLoginLock
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabServerAuthServerSecurityVerify")]
	internal virtual MyHint LabServerAuthServerSecurityVerify
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabServerAuthServerSecurity")]
	internal virtual MyHint LabServerAuthServerSecurity
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabServerAuthServerSecurityCL")]
	internal virtual TextBlock LabServerAuthServerSecurityCL
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyComboBox ComboServerLoginRequire
	{
		[CompilerGenerated]
		get
		{
			return _ComboServerLoginRequire;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SelectionChangedEventHandler val = (SelectionChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, SelectionChangedEventArgs a1) =>
			{
				ComboServerLogin_Changed();
			});
			MyComboBox comboServerLoginRequire = _ComboServerLoginRequire;
			if (comboServerLoginRequire != null)
			{
				((Selector)comboServerLoginRequire).SelectionChanged -= val;
			}
			_ComboServerLoginRequire = value;
			comboServerLoginRequire = _ComboServerLoginRequire;
			if (comboServerLoginRequire != null)
			{
				((Selector)comboServerLoginRequire).SelectionChanged += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabServerAuthServer")]
	internal virtual TextBlock LabServerAuthServer
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyTextBox TextServerAuthServer
	{
		[CompilerGenerated]
		get
		{
			return _TextServerAuthServer;
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
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR174_002D21 != null)
			{
				obj = _Closure_0024__._0024IR174_002D21;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR174_002D21 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			RoutedEventHandler value3 = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				ComboServerLogin_Changed();
			});
			RoutedEventHandler val2 = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				TextServerAuthServer_MouseLeave();
			});
			MyTextBox textServerAuthServer = _TextServerAuthServer;
			if (textServerAuthServer != null)
			{
				textServerAuthServer.ValidatedTextChanged -= value2;
				textServerAuthServer.ValidatedTextChanged -= value3;
				((UIElement)textServerAuthServer).LostFocus -= val2;
			}
			_TextServerAuthServer = value;
			textServerAuthServer = _TextServerAuthServer;
			if (textServerAuthServer != null)
			{
				textServerAuthServer.ValidatedTextChanged += value2;
				textServerAuthServer.ValidatedTextChanged += value3;
				((UIElement)textServerAuthServer).LostFocus += val2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabServerAuthRegister")]
	internal virtual TextBlock LabServerAuthRegister
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyTextBox TextServerAuthRegister
	{
		[CompilerGenerated]
		get
		{
			return _TextServerAuthRegister;
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
			if (_Closure_0024__._0024IR182_002D24 != null)
			{
				obj = _Closure_0024__._0024IR182_002D24;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR182_002D24 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			RoutedEventHandler value3 = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				ComboServerLogin_Changed();
			});
			MyTextBox textServerAuthRegister = _TextServerAuthRegister;
			if (textServerAuthRegister != null)
			{
				textServerAuthRegister.ValidatedTextChanged -= value2;
				textServerAuthRegister.ValidatedTextChanged -= value3;
			}
			_TextServerAuthRegister = value;
			textServerAuthRegister = _TextServerAuthRegister;
			if (textServerAuthRegister != null)
			{
				textServerAuthRegister.ValidatedTextChanged += value2;
				textServerAuthRegister.ValidatedTextChanged += value3;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabServerAuthName")]
	internal virtual TextBlock LabServerAuthName
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyTextBox TextServerAuthName
	{
		[CompilerGenerated]
		get
		{
			return _TextServerAuthName;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR190_002D26 != null)
			{
				obj = _Closure_0024__._0024IR190_002D26;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR190_002D26 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			MyTextBox textServerAuthName = _TextServerAuthName;
			if (textServerAuthName != null)
			{
				textServerAuthName.ValidatedTextChanged -= value2;
			}
			_TextServerAuthName = value;
			textServerAuthName = _TextServerAuthName;
			if (textServerAuthName != null)
			{
				textServerAuthName.ValidatedTextChanged += value2;
			}
		}
	}

	internal virtual MyTextBox TextServerEnter
	{
		[CompilerGenerated]
		get
		{
			return _TextServerEnter;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR194_002D27 != null)
			{
				obj = _Closure_0024__._0024IR194_002D27;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR194_002D27 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			object obj2;
			if (_Closure_0024__._0024IR194_002D28 != null)
			{
				obj2 = _Closure_0024__._0024IR194_002D28;
			}
			else
			{
				RoutedEventHandler val2 = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextServerEnter_Change((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR194_002D28 = val2;
				obj2 = (object)val2;
			}
			RoutedEventHandler val3 = (RoutedEventHandler)obj2;
			MyTextBox textServerEnter = _TextServerEnter;
			if (textServerEnter != null)
			{
				textServerEnter.ValidatedTextChanged -= value2;
				((UIElement)textServerEnter).LostFocus -= val3;
			}
			_TextServerEnter = value;
			textServerEnter = _TextServerEnter;
			if (textServerEnter != null)
			{
				textServerEnter.ValidatedTextChanged += value2;
				((UIElement)textServerEnter).LostFocus += val3;
			}
		}
	}

	internal virtual MyButton BtnServerAuthLittle
	{
		[CompilerGenerated]
		get
		{
			return _BtnServerAuthLittle;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnServerAuthLittle_Click;
			MyButton btnServerAuthLittle = _BtnServerAuthLittle;
			if (btnServerAuthLittle != null)
			{
				btnServerAuthLittle.Click -= obj;
			}
			_BtnServerAuthLittle = value;
			btnServerAuthLittle = _BtnServerAuthLittle;
			if (btnServerAuthLittle != null)
			{
				btnServerAuthLittle.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnServerAuthLock
	{
		[CompilerGenerated]
		get
		{
			return _BtnServerAuthLock;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnServerAuthLock_Click();
			};
			MyButton btnServerAuthLock = _BtnServerAuthLock;
			if (btnServerAuthLock != null)
			{
				btnServerAuthLock.Click -= obj;
			}
			_BtnServerAuthLock = value;
			btnServerAuthLock = _BtnServerAuthLock;
			if (btnServerAuthLock != null)
			{
				btnServerAuthLock.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnServerNewProfile
	{
		[CompilerGenerated]
		get
		{
			return _BtnServerNewProfile;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnServerNewProfile_Click();
			};
			MyButton btnServerNewProfile = _BtnServerNewProfile;
			if (btnServerNewProfile != null)
			{
				btnServerNewProfile.Click -= obj;
			}
			_BtnServerNewProfile = value;
			btnServerNewProfile = _BtnServerNewProfile;
			if (btnServerNewProfile != null)
			{
				btnServerNewProfile.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardAdvance")]
	internal virtual MyCard CardAdvance
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
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
			object obj;
			if (_Closure_0024__._0024IR218_002D32 != null)
			{
				obj = _Closure_0024__._0024IR218_002D32;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR218_002D32 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			MyTextBox textAdvanceJvm = _TextAdvanceJvm;
			if (textAdvanceJvm != null)
			{
				textAdvanceJvm.ValidatedTextChanged -= value2;
			}
			_TextAdvanceJvm = value;
			textAdvanceJvm = _TextAdvanceJvm;
			if (textAdvanceJvm != null)
			{
				textAdvanceJvm.ValidatedTextChanged += value2;
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
			if (_Closure_0024__._0024IR222_002D33 != null)
			{
				obj = _Closure_0024__._0024IR222_002D33;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR222_002D33 = val;
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
			if (_Closure_0024__._0024IR226_002D34 != null)
			{
				obj = _Closure_0024__._0024IR226_002D34;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR226_002D34 = val;
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

	internal virtual MyCheckBox CheckAdvanceJava
	{
		[CompilerGenerated]
		get
		{
			return _CheckAdvanceJava;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkAdvanceJava = _CheckAdvanceJava;
			if (checkAdvanceJava != null)
			{
				checkAdvanceJava.Change -= obj;
			}
			_CheckAdvanceJava = value;
			checkAdvanceJava = _CheckAdvanceJava;
			if (checkAdvanceJava != null)
			{
				checkAdvanceJava.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckAdvanceAssetsV2
	{
		[CompilerGenerated]
		get
		{
			return _CheckAdvanceAssetsV2;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkAdvanceAssetsV = _CheckAdvanceAssetsV2;
			if (checkAdvanceAssetsV != null)
			{
				checkAdvanceAssetsV.Change -= obj;
			}
			_CheckAdvanceAssetsV2 = value;
			checkAdvanceAssetsV = _CheckAdvanceAssetsV2;
			if (checkAdvanceAssetsV != null)
			{
				checkAdvanceAssetsV.Change += obj;
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

	internal virtual MyCheckBox CheckAdvanceUseProxyV2
	{
		[CompilerGenerated]
		get
		{
			return _CheckAdvanceUseProxyV2;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkAdvanceUseProxyV = _CheckAdvanceUseProxyV2;
			if (checkAdvanceUseProxyV != null)
			{
				checkAdvanceUseProxyV.Change -= obj;
			}
			_CheckAdvanceUseProxyV2 = value;
			checkAdvanceUseProxyV = _CheckAdvanceUseProxyV2;
			if (checkAdvanceUseProxyV != null)
			{
				checkAdvanceUseProxyV.Change += obj;
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

	public PageInstanceSetup()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageSetupSystem_Loaded);
		IsLoaded = false;
		RamTextLeft = 2;
		RamTextRight = 1;
		IsReverting = false;
		InitializeComponent();
	}

	private void PageSetupSystem_Loaded(object sender, RoutedEventArgs e)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		((ScrollViewer)PanBack).ScrollToHome();
		RefreshRam(ShowAnim: false);
		checked
		{
			ModAnimation.AniControlEnabled++;
			Reload();
			ModAnimation.AniControlEnabled--;
			if (!IsLoaded)
			{
				IsLoaded = true;
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
		try
		{
			((TextBox)TextArgumentTitle).Text = Conversions.ToString(ModBase.Setup.Get("VersionArgumentTitle", PageInstanceLeft.Instance));
			CheckArgumentTitleEmpty.Checked = (bool?)ModBase.Setup.Get("VersionArgumentTitleEmpty", PageInstanceLeft.Instance);
			((TextBox)TextArgumentInfo).Text = Conversions.ToString(ModBase.Setup.Get("VersionArgumentInfo", PageInstanceLeft.Instance));
			_ = PageInstanceLeft.Instance.PathIndie;
			((Selector)ComboArgumentIndieV2).SelectedIndex = ((!Conversions.ToBoolean(ModBase.Setup.Get("VersionArgumentIndieV2", PageInstanceLeft.Instance))) ? 1 : 0);
			((UIElement)CheckArgumentTitleEmpty).Visibility = (Visibility)((((TextBox)TextArgumentTitle).Text.Length > 0) ? 2 : 0);
			TextArgumentTitle.HintText = (CheckArgumentTitleEmpty.Checked.GetValueOrDefault() ? "默认" : "跟随全局设置");
			RefreshJavaComboBox();
			((MyRadioBox)base.FindName(Conversions.ToString(Operators.ConcatenateObject((object)"RadioRamType", ModBase.Setup.Load("VersionRamType", forceReload: false, PageInstanceLeft.Instance))))).Checked = true;
			SliderRamCustom.Value = Conversions.ToInteger(ModBase.Setup.Get("VersionRamCustom", PageInstanceLeft.Instance));
			((Selector)ComboRamOptimize).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("VersionRamOptimize", PageInstanceLeft.Instance));
			((TextBox)TextServerEnter).Text = Conversions.ToString(ModBase.Setup.Get("VersionServerEnter", PageInstanceLeft.Instance));
			((Selector)ComboServerLoginRequire).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("VersionServerLoginRequire", PageInstanceLeft.Instance));
			ComboServerLoginLast = ((Selector)ComboServerLoginRequire).SelectedIndex;
			ServerLogin(((Selector)ComboServerLoginRequire).SelectedIndex);
			((TextBox)TextServerAuthServer).Text = Conversions.ToString(ModBase.Setup.Get("VersionServerAuthServer", PageInstanceLeft.Instance));
			((TextBox)TextServerAuthName).Text = Conversions.ToString(ModBase.Setup.Get("VersionServerAuthName", PageInstanceLeft.Instance));
			((TextBox)TextServerAuthRegister).Text = Conversions.ToString(ModBase.Setup.Get("VersionServerAuthRegister", PageInstanceLeft.Instance));
			((Selector)ComboAdvanceRenderer).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("VersionAdvanceRenderer", PageInstanceLeft.Instance));
			((TextBox)TextAdvanceJvm).Text = Conversions.ToString(ModBase.Setup.Get("VersionAdvanceJvm", PageInstanceLeft.Instance));
			((TextBox)TextAdvanceGame).Text = Conversions.ToString(ModBase.Setup.Get("VersionAdvanceGame", PageInstanceLeft.Instance));
			((TextBox)TextAdvanceRun).Text = Conversions.ToString(ModBase.Setup.Get("VersionAdvanceRun", PageInstanceLeft.Instance));
			CheckAdvanceRunWait.Checked = (bool?)ModBase.Setup.Get("VersionAdvanceRunWait", PageInstanceLeft.Instance);
			if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("VersionAdvanceAssets", PageInstanceLeft.Instance), (object)2, false))
			{
				ModBase.Log("[Setup] 已迁移老版本的关闭文件校验设置");
				ModBase.Setup.Reset("VersionAdvanceAssets", forceReload: false, PageInstanceLeft.Instance);
				ModBase.Setup.Set("VersionAdvanceAssetsV2", true, forceReload: false, PageInstanceLeft.Instance);
			}
			CheckAdvanceAssetsV2.Checked = (bool?)ModBase.Setup.Get("VersionAdvanceAssetsV2", PageInstanceLeft.Instance);
			CheckAdvanceUseProxyV2.Checked = (bool?)ModBase.Setup.Get("VersionAdvanceUseProxyV2", PageInstanceLeft.Instance);
			CheckAdvanceJava.Checked = (bool?)ModBase.Setup.Get("VersionAdvanceJava", PageInstanceLeft.Instance);
			if (ModBase.IsArm64System)
			{
				CheckAdvanceDisableJLW.Checked = true;
				((UIElement)CheckAdvanceDisableJLW).IsEnabled = false;
				((FrameworkElement)CheckAdvanceDisableJLW).ToolTip = "在启动游戏时不使用 Java Wrapper 进行包装。&#xa;由于系统为 ARM64 架构，Java Wrapper 已被强制禁用。";
			}
			else
			{
				CheckAdvanceDisableJLW.Checked = (bool?)ModBase.Setup.Get("VersionAdvanceDisableJLW", PageInstanceLeft.Instance);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "重载实例独立设置时出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public void Reset()
	{
		try
		{
			if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("VersionServerLoginLock", PageInstanceLeft.Instance))))
			{
				ModBase.Setup.Reset("VersionServerLoginRequire", forceReload: false, PageInstanceLeft.Instance);
				ModBase.Setup.Reset("VersionServerAuthServer", forceReload: false, PageInstanceLeft.Instance);
				ModBase.Setup.Reset("VersionServerAuthRegister", forceReload: false, PageInstanceLeft.Instance);
				ModBase.Setup.Reset("VersionServerAuthName", forceReload: false, PageInstanceLeft.Instance);
			}
			ModBase.Setup.Reset("VersionServerEnter", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionArgumentTitle", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionArgumentInfo", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionArgumentIndieV2", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionRamType", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionRamCustom", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionRamOptimize", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionAdvanceJvm", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionAdvanceGame", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionAdvanceAssets", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionAdvanceAssetsV2", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionAdvanceJava", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionAdvanceDisableJlw", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionAdvanceRun", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionAdvanceRunWait", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionAdvanceDisableJLW", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionAdvanceUseProxyV2", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionAdvanceRenderer", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Setup.Reset("VersionArgumentJavaSelect", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Log("[Setup] 已初始化实例独立设置");
			ModMain.Hint("已初始化实例独立设置！", ModMain.HintType.Finish, Log: false);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "初始化实例独立设置失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
		Reload();
	}

	private static void RadioBoxChange(MyRadioBox sender, object e)
	{
		string[] array = ((FrameworkElement)sender).Tag.ToString().Split("/", (StringSplitOptions)0);
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(array[0], int.Parse(array[1]), forceReload: false, PageInstanceLeft.Instance);
		}
	}

	private static void TextBoxChange(MyTextBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), ((TextBox)sender).Text, forceReload: false, PageInstanceLeft.Instance);
		}
	}

	private static void SliderChange(MySlider sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), sender.Value, forceReload: false, PageInstanceLeft.Instance);
		}
	}

	private static void ComboChange(MyComboBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), ((Selector)sender).SelectedIndex, forceReload: false, PageInstanceLeft.Instance);
		}
	}

	private static void CheckBoxLikeComboChange(MyComboBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), ((Selector)sender).SelectedIndex == 0, forceReload: false, PageInstanceLeft.Instance);
		}
	}

	private static void CheckBoxChange(MyCheckBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), sender.Checked, forceReload: false, PageInstanceLeft.Instance);
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
		//IL_041e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (LabRamGame != null && LabRamUsed != null && !(ModMain.FrmMain.PageCurrent != FormMain.PageType.InstanceSetup) && ModMain.FrmInstanceLeft.PageID == FormMain.PageSubType.DownloadInstall)
			{
				double num = Math.Round(GetRam(PageInstanceLeft.Instance), 5);
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
				((UIElement)LabRamWarn).Visibility = (Visibility)((num != 1.0 || ModJava.IsGameSet64BitJava(PageInstanceLeft.Instance) || ModBase.Is32BitSystem || !Enumerable.Any<JavaInfo>((System.Collections.Generic.IEnumerable<JavaInfo>)ModJava.Javas.JavaList)) ? 2 : 0);
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
					ModAnimation.AniStart((System.Collections.IList)(object)array, "VersionSetup Ram Grid");
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
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
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
				}, "VersionSetup Ram TextLeft");
				break;
			case 1:
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
				{
					ModAnimation.AaOpacity(LabRamUsed, 1.0 - ((UIElement)LabRamUsed).Opacity, 100),
					ModAnimation.AaOpacity(LabRamTotal, 0.0 - ((UIElement)LabRamTotal).Opacity, 100),
					ModAnimation.AaOpacity(LabRamUsedTitle, 0.7 - ((UIElement)LabRamUsedTitle).Opacity, 100)
				}, "VersionSetup Ram TextLeft");
				break;
			case 2:
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
				{
					ModAnimation.AaOpacity(LabRamUsed, 1.0 - ((UIElement)LabRamUsed).Opacity, 100),
					ModAnimation.AaOpacity(LabRamTotal, 1.0 - ((UIElement)LabRamTotal).Opacity, 100),
					ModAnimation.AaOpacity(LabRamUsedTitle, 0.7 - ((UIElement)LabRamUsedTitle).Opacity, 100)
				}, "VersionSetup Ram TextLeft");
				break;
			}
		}
		int num2 = ((!(actualWidth2 < actualWidth3 + 2.0 + actualWidth) && !(actualWidth2 < actualWidth6 + 2.0 + actualWidth)) ? 1 : 0);
		Thickness margin;
		if (num2 == 0)
		{
			if (ModAnimation.AniControlEnabled == 0 && (RamTextRight != num2 || ModAnimation.AniIsRun("VersionSetup Ram TextRight")))
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
				ModAnimation.AniStart((System.Collections.IList)(object)array, "VersionSetup Ram TextRight");
			}
			else
			{
				((FrameworkElement)LabRamGame).Margin = new Thickness(actualWidth2 - actualWidth3, 3.0, 0.0, 0.0);
				((FrameworkElement)LabRamGameTitle).Margin = new Thickness(actualWidth2 - actualWidth6, 0.0, 0.0, 5.0);
			}
		}
		else if (ModAnimation.AniControlEnabled == 0 && (RamTextRight != num2 || ModAnimation.AniIsRun("VersionSetup Ram TextRight")))
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
			ModAnimation.AniStart((System.Collections.IList)(object)array2, "VersionSetup Ram TextRight");
		}
		else
		{
			((FrameworkElement)LabRamGame).Margin = new Thickness(2.0 + actualWidth, 3.0, 0.0, 0.0);
			((FrameworkElement)LabRamGameTitle).Margin = new Thickness(2.0 + actualWidth, 0.0, 0.0, 5.0);
		}
		RamTextRight = num2;
	}

	public static double GetRam(ModMinecraft.McInstance Version, bool? Is32BitJava = null)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("VersionRamType", Version), (object)2, false))
		{
			return PageSetupLaunch.GetRam(Version, UseVersionJavaSetup: true, Is32BitJava);
		}
		double num8 = default(double);
		if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("VersionRamType", Version), (object)0, false))
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
			int num9 = Conversions.ToInteger(ModBase.Setup.Get("VersionRamCustom", Version));
			num8 = ((num9 <= 12) ? ((double)num9 * 0.1 + 0.3) : checked((num9 <= 25) ? ((double)(num9 - 12) * 0.5 + 1.5) : ((num9 > 33) ? ((double)((num9 - 33) * 2 + 16)) : ((double)((num9 - 25) * 1 + 8)))));
		}
		if (Is32BitJava ?? (!ModJava.IsGameSet64BitJava(PageInstanceLeft.Instance)))
		{
			num8 = Math.Min(1.0, num8);
		}
		return num8;
	}

	private void ComboServerLogin_Changed()
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ServerLogin(((Selector)ComboServerLoginRequire).SelectedIndex);
			if (TextServerAuthServer.IsValidated)
			{
				((UIElement)BtnServerAuthLock).IsEnabled = true;
			}
			else
			{
				((UIElement)BtnServerAuthLock).IsEnabled = false;
			}
			if (((((Selector)ComboServerLoginRequire).SelectedIndex != 2 && ((Selector)ComboServerLoginRequire).SelectedIndex != 3) || TextServerAuthServer.IsValidated) && ComboServerLoginLast != ((Selector)ComboServerLoginRequire).SelectedIndex)
			{
				ComboServerLoginLast = ((Selector)ComboServerLoginRequire).SelectedIndex;
				ComboChange(ComboServerLoginRequire, null);
			}
		}
	}

	private void TextServerAuthServer_MouseLeave()
	{
		if (string.IsNullOrWhiteSpace(((TextBox)TextServerAuthServer).Text))
		{
			return;
		}
		if (!ModBase.EndsWithF(((TextBox)TextServerAuthServer).Text, "/api/yggdrasil/") && !ModBase.EndsWithF(((TextBox)TextServerAuthServer).Text, "/api/yggdrasil"))
		{
			if (ModBase.EndsWithF(((TextBox)TextServerAuthServer).Text, "/"))
			{
				((TextBox)TextServerAuthServer).Text = ((TextBox)TextServerAuthServer).Text + "api/yggdrasil";
				ModMain.Hint("已自动格式化验证服务器地址！");
			}
			else
			{
				((TextBox)TextServerAuthServer).Text = ((TextBox)TextServerAuthServer).Text + "/api/yggdrasil";
				ModMain.Hint("已自动格式化验证服务器地址！");
			}
		}
		if (ModBase.EndsWithF(((TextBox)TextServerAuthServer).Text, "/api/yggdrasil/"))
		{
			((TextBox)TextServerAuthServer).Text = ModBase.BeforeLast(((TextBox)TextServerAuthServer).Text, "/");
			ModMain.Hint("已自动格式化验证服务器地址！");
		}
		ComboServerLoginLast = ((Selector)ComboServerLoginRequire).SelectedIndex;
		ComboChange(ComboServerLoginRequire, null);
	}

	public void ServerLogin(int Type)
	{
		((UIElement)LabServerAuthName).Visibility = (Visibility)((Type != 2 && Type != 3) ? 2 : 0);
		((UIElement)TextServerAuthName).Visibility = (Visibility)((Type != 2 && Type != 3) ? 2 : 0);
		((UIElement)LabServerAuthRegister).Visibility = (Visibility)((Type != 2 && Type != 3) ? 2 : 0);
		((UIElement)TextServerAuthRegister).Visibility = (Visibility)((Type != 2 && Type != 3) ? 2 : 0);
		((UIElement)LabServerAuthServer).Visibility = (Visibility)((Type != 2 && Type != 3) ? 2 : 0);
		((UIElement)TextServerAuthServer).Visibility = (Visibility)((Type != 2 && Type != 3) ? 2 : 0);
		((UIElement)BtnServerAuthLittle).Visibility = (Visibility)((Type != 2 && Type != 3) ? 2 : 0);
		((UIElement)BtnServerNewProfile).Visibility = (Visibility)((Type != 2 && Type != 3) ? 2 : 0);
		if (Type == 0 || Type == 1)
		{
			((UIElement)BtnServerAuthLock).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)BtnServerAuthLock).Visibility = (Visibility)0;
		}
		if (Conversions.ToBoolean(ModBase.Setup.Get("VersionServerLoginLock", PageInstanceLeft.Instance)))
		{
			((UIElement)HintServerLoginLock).Visibility = (Visibility)0;
			((UIElement)ComboServerLoginRequire).IsEnabled = false;
			((UIElement)TextServerAuthServer).IsEnabled = false;
			((UIElement)TextServerAuthName).IsEnabled = false;
			((UIElement)TextServerAuthRegister).IsEnabled = false;
			((UIElement)BtnServerAuthLittle).IsEnabled = false;
		}
		else
		{
			((UIElement)HintServerLoginLock).Visibility = (Visibility)2;
			((UIElement)ComboServerLoginRequire).IsEnabled = true;
			((UIElement)TextServerAuthServer).IsEnabled = true;
			((UIElement)TextServerAuthName).IsEnabled = true;
			((UIElement)TextServerAuthRegister).IsEnabled = true;
			((UIElement)BtnServerAuthLittle).IsEnabled = true;
		}
		CardServer.TriggerForceResize();
		if (Type != 2 && Type != 3)
		{
			((UIElement)LabServerAuthServerSecurity).Visibility = (Visibility)2;
			((UIElement)LabServerAuthServerSecurityCL).Visibility = (Visibility)2;
			((UIElement)LabServerAuthServerSecurityVerify).Visibility = (Visibility)2;
		}
		else if (ModBase.StartsWithF(((TextBox)TextServerAuthServer).Text, "https://"))
		{
			((UIElement)LabServerAuthServerSecurity).Visibility = (Visibility)2;
			((UIElement)LabServerAuthServerSecurityVerify).Visibility = (Visibility)0;
			((UIElement)LabServerAuthServerSecurityCL).Visibility = (Visibility)0;
		}
		else if (ModBase.StartsWithF(((TextBox)TextServerAuthServer).Text, "http://"))
		{
			((UIElement)LabServerAuthServerSecurity).Visibility = (Visibility)0;
			((UIElement)LabServerAuthServerSecurityCL).Visibility = (Visibility)0;
			((UIElement)LabServerAuthServerSecurityVerify).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)LabServerAuthServerSecurity).Visibility = (Visibility)2;
			((UIElement)LabServerAuthServerSecurityVerify).Visibility = (Visibility)2;
			((UIElement)LabServerAuthServerSecurityCL).Visibility = (Visibility)2;
		}
	}

	private void BtnServerAuthLittle_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(((TextBox)TextServerAuthServer).Text, "", false) == 0 || Operators.CompareString(((TextBox)TextServerAuthServer).Text, "https://littleskin.cn/api/yggdrasil", false) == 0 || ModMain.MyMsgBox("即将把第三方登录设置覆盖为 LittleSkin 登录。\r\n除非你是服主，或者服主要求你这样做，否则请不要继续。\r\n\r\n是否确实需要覆盖当前设置？", "设置覆盖确认", "继续", "取消") != 2)
		{
			((TextBox)TextServerAuthServer).Text = "https://littleskin.cn/api/yggdrasil";
			((TextBox)TextServerAuthRegister).Text = "https://littleskin.cn/auth/register";
			((TextBox)TextServerAuthName).Text = "LittleSkin 登录";
		}
	}

	private void BtnServerAuthLock_Click()
	{
		if (ModMain.MyMsgBox(string.Format("你正在选择锁定此实例的验证方式。锁定之后，将无法再更改此实例的验证方式要求，启动此实例将必须使用指定的验证方式。{0}此功能可能会帮助一些服主吧。{1}是否继续？", (object)"\r\n", (object)"\r\n"), "锁定验证方式确认", "确定", "取消", "", IsWarn: true) == 1)
		{
			ModBase.Setup.Set("VersionServerLoginLock", true, forceReload: false, PageInstanceLeft.Instance);
			Reload();
		}
	}

	private void BtnServerNewProfile_Click()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		ModMain.FrmMain.PageChange(new FormMain.PageStackData
		{
			Page = FormMain.PageType.Launch
		});
		PageLoginAuth.DraggedAuthServer = ((TextBox)TextServerAuthServer).Text;
		object action;
		if (_Closure_0024__._0024I24_002D0 != null)
		{
			action = _Closure_0024__._0024I24_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				//IL_0023: Unknown result type (might be due to invalid IL or missing references)
				//IL_0028: Unknown result type (might be due to invalid IL or missing references)
				//IL_002e: Expected O, but got Unknown
				Thread.Sleep(150);
				object action2;
				if (_Closure_0024__._0024I24_002D1 != null)
				{
					action2 = _Closure_0024__._0024I24_002D1;
				}
				else
				{
					Action val2 = [SpecialName] () =>
					{
						ModMain.FrmLaunchLeft.RefreshPage(Anim: true, ModLaunch.McLoginType.Auth);
					};
					_Closure_0024__._0024I24_002D1 = val2;
					action2 = (object)val2;
				}
				ModBase.RunInUi((Action)action2);
			};
			_Closure_0024__._0024I24_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInNewThread((Action)action, null, (ThreadPriority)2);
	}

	private static void TextServerEnter_Change(MyTextBox sender, object e)
	{
		((TextBox)sender).Text = ((TextBox)sender).Text.Replace("：", ":");
	}

	public void RefreshJavaComboBox()
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Expected O, but got Unknown
		if (ComboArgumentJava == null)
		{
			return;
		}
		((ItemsControl)ComboArgumentJava).Items.Clear();
		ItemCollection items = ((ItemsControl)ComboArgumentJava).Items;
		MyComboBoxItem myComboBoxItem = new MyComboBoxItem();
		((ContentControl)myComboBoxItem).Content = "跟随全局设置";
		((FrameworkElement)myComboBoxItem).Tag = "使用全局设置";
		items.Add((object)myComboBoxItem);
		ItemCollection items2 = ((ItemsControl)ComboArgumentJava).Items;
		MyComboBoxItem myComboBoxItem2 = new MyComboBoxItem();
		((ContentControl)myComboBoxItem2).Content = "自动选择合适的 Java";
		((FrameworkElement)myComboBoxItem2).Tag = "自动选择";
		items2.Add((object)myComboBoxItem2);
		MyComboBoxItem myComboBoxItem3 = null;
		string text = Conversions.ToString(ModBase.Setup.Get("VersionArgumentJavaSelect", PageInstanceLeft.Instance));
		try
		{
			System.Collections.Generic.IEnumerator<JavaInfo> enumerator = default(System.Collections.Generic.IEnumerator<JavaInfo>);
			try
			{
				enumerator = ModJava.Javas.JavaList.GetEnumerator();
				while (enumerator.MoveNext())
				{
					JavaInfo current = enumerator.Current;
					MyComboBoxItem myComboBoxItem4 = new MyComboBoxItem();
					((ContentControl)myComboBoxItem4).Content = current.ToString();
					((FrameworkElement)myComboBoxItem4).ToolTip = current.JavaFolder;
					((FrameworkElement)myComboBoxItem4).Tag = current;
					MyComboBoxItem myComboBoxItem5 = myComboBoxItem4;
					ToolTipService.SetHorizontalOffset((DependencyObject)(object)myComboBoxItem5, 400.0);
					((ItemsControl)ComboArgumentJava).Items.Add((object)myComboBoxItem5);
					switch (text)
					{
					case null:
					case "":
					case "使用全局设置":
						continue;
					}
					if (Operators.CompareString(text, current.JavaExePath, false) == 0)
					{
						myComboBoxItem3 = myComboBoxItem5;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Setup.Set("VersionArgumentJavaSelect", "使用全局设置", forceReload: false, PageInstanceLeft.Instance);
			ModBase.Log(ex2, "更新实例设置 Java 下拉框失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
		if (myComboBoxItem3 == null && Enumerable.Any<JavaInfo>((System.Collections.Generic.IEnumerable<JavaInfo>)ModJava.Javas.JavaList))
		{
			myComboBoxItem3 = ((Operators.CompareString(text, "", false) != 0) ? ((MyComboBoxItem)((ItemsControl)ComboArgumentJava).Items[0]) : ((MyComboBoxItem)((ItemsControl)ComboArgumentJava).Items[1]));
		}
		((Selector)ComboArgumentJava).SelectedItem = myComboBoxItem3;
		if (myComboBoxItem3 == null)
		{
			((ItemsControl)ComboArgumentJava).Items.Clear();
			((ItemsControl)ComboArgumentJava).Items.Add((object)new ComboBoxItem
			{
				Content = "未找到可用的 Java",
				IsSelected = true
			});
		}
		RefreshRam(ShowAnim: true);
	}

	private void ComboArgumentJava_DropDownOpened(object sender, EventArgs e)
	{
		if (((Selector)ComboArgumentJava).SelectedItem == null || Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(((ItemsControl)ComboArgumentJava).Items[0], (System.Type)null, "Content", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"未找到可用的 Java", false) || Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(((ItemsControl)ComboArgumentJava).Items[0], (System.Type)null, "Content", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)"加载中……", false))
		{
			((ComboBox)ComboArgumentJava).IsDropDownOpen = false;
		}
	}

	private void JavaSelectionUpdate()
	{
		if (ModAnimation.AniControlEnabled == 0 && ((Selector)ComboArgumentJava).SelectedItem != null && NewLateBinding.LateGet(((Selector)ComboArgumentJava).SelectedItem, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) != null)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(((Selector)ComboArgumentJava).SelectedItem, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null));
			if ("使用全局设置".Equals(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				ModBase.Setup.Set("VersionArgumentJavaSelect", "使用全局设置", forceReload: false, PageInstanceLeft.Instance);
				ModBase.Log("[Java] 修改实例 Java 选择设置：跟随全局设置");
			}
			else if ("自动选择".Equals(RuntimeHelpers.GetObjectValue(objectValue)))
			{
				ModBase.Setup.Set("VersionArgumentJavaSelect", "", forceReload: false, PageInstanceLeft.Instance);
				ModBase.Log("[Java] 修改实例 Java 选择设置：自动选择");
			}
			else
			{
				ModBase.Setup.Set("VersionArgumentJavaSelect", ((JavaInfo)objectValue).JavaExePath, forceReload: false, PageInstanceLeft.Instance);
				ModBase.Log("[Java] 修改实例 Java 选择设置：" + objectValue.ToString());
			}
			RefreshRam(ShowAnim: true);
		}
	}

	private void ComboArgumentIndieV2_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (ModAnimation.AniControlEnabled == 0 && !IsReverting && ModMain.MyMsgBox("调整版本隔离后，你可能得把游戏存档、Mod 等文件手动迁移到新的游戏文件夹中。\r\n如果修改后发现存档消失，把这项设置改回来就能恢复。\r\n如果你不会迁移存档，不建议修改这项设置！", "警告", "我知道我在做什么", "取消", "", IsWarn: true) == 2)
		{
			IsReverting = true;
			((Selector)ComboArgumentIndieV2).SelectedItem = RuntimeHelpers.GetObjectValue(e.RemovedItems[0]);
			IsReverting = false;
		}
	}

	private void CheckArgumentTitleEmpty_Change(MyCheckBox sender, object e)
	{
		TextArgumentTitle.HintText = (CheckArgumentTitleEmpty.Checked.GetValueOrDefault() ? "默认" : "跟随全局设置");
	}

	private void TextArgumentTitle_TextChanged(object sender, TextChangedEventArgs e)
	{
		((UIElement)CheckArgumentTitleEmpty).Visibility = (Visibility)((((TextBox)TextArgumentTitle).Text.Length > 0) ? 2 : 0);
	}

	private void TextAdvanceRun_TextChanged(object sender, TextChangedEventArgs e)
	{
		((UIElement)CheckAdvanceRunWait).Visibility = (Visibility)((Operators.CompareString(((TextBox)TextAdvanceRun).Text, "", false) == 0) ? 2 : 0);
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
				ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), ((Selector)sender).SelectedIndex, forceReload: false, PageInstanceLeft.Instance);
				ModBase.Setup.Set("HintRenderer", true);
			}
		}
		else
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), ((Selector)sender).SelectedIndex, forceReload: false, PageInstanceLeft.Instance);
		}
	}

	private void BtnSwitch_Click(object sender, MouseButtonEventArgs e)
	{
		ModMain.FrmMain.PageChange(FormMain.PageType.Setup);
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/pageinstancesetup.xaml", (UriKind)2);
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
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
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
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
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
			CheckArgumentTitleEmpty = (MyCheckBox)target;
			break;
		case 7:
			TextArgumentInfo = (MyTextBox)target;
			break;
		case 8:
			ComboArgumentJava = (MyComboBox)target;
			break;
		case 9:
			LabRamWarn = (MyHint)target;
			break;
		case 10:
			HintRamTooHigh = (MyHint)target;
			break;
		case 11:
			RadioRamType2 = (MyRadioBox)target;
			break;
		case 12:
			RadioRamType0 = (MyRadioBox)target;
			break;
		case 13:
			RadioRamType1 = (MyRadioBox)target;
			break;
		case 14:
			SliderRamCustom = (MySlider)target;
			break;
		case 15:
			ComboRamOptimize = (MyComboBox)target;
			break;
		case 16:
			PanRamDisplay = (Grid)target;
			break;
		case 17:
			ColumnRamUsed = (ColumnDefinition)target;
			break;
		case 18:
			ColumnRamGame = (ColumnDefinition)target;
			break;
		case 19:
			ColumnRamEmpty = (ColumnDefinition)target;
			break;
		case 20:
			RectRamUsed = (Rectangle)target;
			break;
		case 21:
			RectRamGame = (Rectangle)target;
			break;
		case 22:
			RectRamEmpty = (Rectangle)target;
			break;
		case 23:
			LabRamUsedTitle = (TextBlock)target;
			break;
		case 24:
			LabRamGameTitle = (TextBlock)target;
			break;
		case 25:
			LabRamUsed = (TextBlock)target;
			break;
		case 26:
			LabRamTotal = (TextBlock)target;
			break;
		case 27:
			LabRamGame = (TextBlock)target;
			break;
		case 28:
			CardServer = (MyCard)target;
			break;
		case 29:
			HintServerLoginLock = (MyHint)target;
			break;
		case 30:
			LabServerAuthServerSecurityVerify = (MyHint)target;
			break;
		case 31:
			LabServerAuthServerSecurity = (MyHint)target;
			break;
		case 32:
			LabServerAuthServerSecurityCL = (TextBlock)target;
			break;
		case 33:
			ComboServerLoginRequire = (MyComboBox)target;
			break;
		case 34:
			LabServerAuthServer = (TextBlock)target;
			break;
		case 35:
			TextServerAuthServer = (MyTextBox)target;
			break;
		case 36:
			LabServerAuthRegister = (TextBlock)target;
			break;
		case 37:
			TextServerAuthRegister = (MyTextBox)target;
			break;
		case 38:
			LabServerAuthName = (TextBlock)target;
			break;
		case 39:
			TextServerAuthName = (MyTextBox)target;
			break;
		case 40:
			TextServerEnter = (MyTextBox)target;
			break;
		case 41:
			BtnServerAuthLittle = (MyButton)target;
			break;
		case 42:
			BtnServerAuthLock = (MyButton)target;
			break;
		case 43:
			BtnServerNewProfile = (MyButton)target;
			break;
		case 44:
			CardAdvance = (MyCard)target;
			break;
		case 45:
			ComboAdvanceRenderer = (MyComboBox)target;
			break;
		case 46:
			TextAdvanceJvm = (MyTextBox)target;
			break;
		case 47:
			TextAdvanceGame = (MyTextBox)target;
			break;
		case 48:
			TextAdvanceRun = (MyTextBox)target;
			break;
		case 49:
			CheckAdvanceRunWait = (MyCheckBox)target;
			break;
		case 50:
			CheckAdvanceJava = (MyCheckBox)target;
			break;
		case 51:
			CheckAdvanceAssetsV2 = (MyCheckBox)target;
			break;
		case 52:
			CheckAdvanceDisableJLW = (MyCheckBox)target;
			break;
		case 53:
			CheckAdvanceUseProxyV2 = (MyCheckBox)target;
			break;
		case 54:
			CheckAdvanceDisableRW = (MyCheckBox)target;
			break;
		case 55:
			BtnSwitch = (MyExtraTextButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
