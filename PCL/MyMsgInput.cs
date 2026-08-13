using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class MyMsgInput : Grid, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static ThreadStart _0024I4_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__4_002D0()
		{
			if (!Enumerable.Any<ModMain.MyMsgBoxConverter>((System.Collections.Generic.IEnumerable<ModMain.MyMsgBoxConverter>)ModMain.WaitingMyMsgBox))
			{
				ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ModMain.FrmMain.PanMsgBackground, Border.BackgroundProperty, new ModBase.MyColor(0.0, 0.0, 0.0, 0.0) - ((Border)ModMain.FrmMain.PanMsgBackground).Background, 200, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)));
			}
		}
	}

	private readonly ModMain.MyMsgBoxConverter MyConverter;

	private readonly int Uuid;

	[CompilerGenerated]
	[AccessedThroughProperty("PanBorder")]
	private Border _PanBorder;

	[CompilerGenerated]
	[AccessedThroughProperty("LabTitle")]
	private TextBlock _LabTitle;

	[CompilerGenerated]
	[AccessedThroughProperty("TextArea")]
	private MyTextBox _TextArea;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn1")]
	private MyButton _Btn1;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn2")]
	private MyButton _Btn2;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TransformRotate")]
	internal virtual RotateTransform TransformRotate
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TransformPos")]
	internal virtual TranslateTransform TransformPos
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Border PanBorder
	{
		[CompilerGenerated]
		get
		{
			return _PanBorder;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(Drag);
			Border panBorder = _PanBorder;
			if (panBorder != null)
			{
				((UIElement)panBorder).MouseLeftButtonDown -= val;
			}
			_PanBorder = value;
			panBorder = _PanBorder;
			if (panBorder != null)
			{
				((UIElement)panBorder).MouseLeftButtonDown += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("EffectShadow")]
	internal virtual DropShadowEffect EffectShadow
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanMain")]
	internal virtual Grid PanMain
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual TextBlock LabTitle
	{
		[CompilerGenerated]
		get
		{
			return _LabTitle;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(Drag);
			TextBlock labTitle = _LabTitle;
			if (labTitle != null)
			{
				((UIElement)labTitle).MouseLeftButtonDown -= val;
			}
			_LabTitle = value;
			labTitle = _LabTitle;
			if (labTitle != null)
			{
				((UIElement)labTitle).MouseLeftButtonDown += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ShapeLine")]
	internal virtual Rectangle ShapeLine
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanText")]
	internal virtual MyScrollViewer PanText
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabText")]
	internal virtual TextBlock LabText
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyTextBox TextArea
	{
		[CompilerGenerated]
		get
		{
			return _TextArea;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyTextBox.ValidateChangedEventHandler obj = TextCaption_ValidateChanged;
			if (_TextArea != null)
			{
				MyTextBox.ValidateChanged -= obj;
			}
			_TextArea = value;
			if (_TextArea != null)
			{
				MyTextBox.ValidateChanged += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBtn")]
	internal virtual StackPanel PanBtn
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public virtual MyButton Btn1
	{
		[CompilerGenerated]
		get
		{
			return _Btn1;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				Btn1_Click();
			};
			MyButton btn = _Btn1;
			if (btn != null)
			{
				btn.Click -= obj;
			}
			_Btn1 = value;
			btn = _Btn1;
			if (btn != null)
			{
				btn.Click += obj;
			}
		}
	}

	public virtual MyButton Btn2
	{
		[CompilerGenerated]
		get
		{
			return _Btn2;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				Btn2_Click();
			};
			MyButton btn = _Btn2;
			if (btn != null)
			{
				btn.Click -= obj;
			}
			_Btn2 = value;
			btn = _Btn2;
			if (btn != null)
			{
				btn.Click += obj;
			}
		}
	}

	public MyMsgInput(ModMain.MyMsgBoxConverter Converter)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(Load);
		Uuid = ModBase.GetUuid();
		try
		{
			InitializeComponent();
			((FrameworkElement)Btn1).Name = ((FrameworkElement)Btn1).Name + Conversions.ToString(ModBase.GetUuid());
			((FrameworkElement)Btn2).Name = ((FrameworkElement)Btn2).Name + Conversions.ToString(ModBase.GetUuid());
			MyConverter = Converter;
			LabTitle.Text = Converter.Title;
			LabText.Text = Converter.Text;
			((UIElement)PanText).Visibility = (Visibility)((Operators.CompareString(Converter.Text, "", false) == 0) ? 2 : 0);
			((TextBox)TextArea).Text = Conversions.ToString(Converter.Content);
			TextArea.HintText = Converter.HintText;
			TextArea.ValidateRules = Converter.ValidateRules;
			Btn1.Text = Converter.Button1;
			if (Converter.IsWarn)
			{
				Btn1.ColorType = MyButton.ColorState.Red;
				((FrameworkElement)LabTitle).SetResourceReference(TextBlock.ForegroundProperty, (object)"ColorBrushRedLight");
			}
			Btn2.Text = Converter.Button2;
			((UIElement)Btn2).Visibility = (Visibility)((Operators.CompareString(Converter.Button2, "", false) == 0) ? 2 : 0);
			((Shape)ShapeLine).StrokeThickness = ModBase.GetWPFSize(1.0);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "输入弹窗初始化失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private void Load(object sender, EventArgs e)
	{
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		try
		{
			if (((UIElement)Btn2).IsVisible && Btn1.ColorType != MyButton.ColorState.Red)
			{
				Btn1.ColorType = MyButton.ColorState.Highlight;
			}
			((UIElement)TextArea).Focus();
			((TextBox)TextArea).SelectionStart = ((TextBox)TextArea).Text.Length;
			((UIElement)this).Opacity = 0.0;
			ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ModMain.FrmMain.PanMsgBackground, Border.BackgroundProperty, (MyConverter.IsWarn ? new ModBase.MyColor(140.0, 80.0, 0.0, 0.0) : new ModBase.MyColor(90.0, 0.0, 0.0, 0.0)) - ((Border)ModMain.FrmMain.PanMsgBackground).Background, 200), "PanMsgBackground Background");
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
			{
				ModAnimation.AaOpacity(this, 1.0, 120, 60),
				ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] [CompilerGenerated] (object i) =>
				{
					TranslateTransform transformPos;
					(transformPos = TransformPos).Y = Conversions.ToDouble(Operators.AddObject((object)transformPos.Y, i));
				}), 0.0 - TransformPos.Y, 300, 60, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)),
				ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] [CompilerGenerated] (object i) =>
				{
					RotateTransform transformRotate;
					(transformRotate = TransformRotate).Angle = Conversions.ToDouble(Operators.AddObject((object)transformRotate.Angle, i));
				}), 0.0 - TransformRotate.Angle, 300, 60, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak))
			}, "MyMsgBox " + Conversions.ToString(Uuid));
			ModBase.Log("[Control] 输入弹窗：" + LabTitle.Text);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "输入弹窗加载失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private void Close()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		MyConverter.WaitFrame.Continue = false;
		ComponentDispatcher.PopModal();
		ModAnimation.AniData[] array = new ModAnimation.AniData[5];
		object code;
		if (_Closure_0024__._0024I4_002D0 != null)
		{
			code = _Closure_0024__._0024I4_002D0;
		}
		else
		{
			ThreadStart val = [SpecialName] () =>
			{
				if (!Enumerable.Any<ModMain.MyMsgBoxConverter>((System.Collections.Generic.IEnumerable<ModMain.MyMsgBoxConverter>)ModMain.WaitingMyMsgBox))
				{
					ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ModMain.FrmMain.PanMsgBackground, Border.BackgroundProperty, new ModBase.MyColor(0.0, 0.0, 0.0, 0.0) - ((Border)ModMain.FrmMain.PanMsgBackground).Background, 200, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)));
				}
			};
			_Closure_0024__._0024I4_002D0 = val;
			code = (object)val;
		}
		array[0] = ModAnimation.AaCode((ThreadStart)code, 30);
		array[1] = ModAnimation.AaOpacity(this, 0.0 - ((UIElement)this).Opacity, 80, 20);
		array[2] = ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] [CompilerGenerated] (object i) =>
		{
			TranslateTransform transformPos;
			(transformPos = TransformPos).Y = Conversions.ToDouble(Operators.AddObject((object)transformPos.Y, i));
		}), 20.0 - TransformPos.Y, 150, 0, new ModAnimation.AniEaseOutFluent());
		array[3] = ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] [CompilerGenerated] (object i) =>
		{
			RotateTransform transformRotate;
			(transformRotate = TransformRotate).Angle = Conversions.ToDouble(Operators.AddObject((object)transformRotate.Angle, i));
		}), 6.0 - TransformRotate.Angle, 150, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak));
		array[4] = ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((Panel)(Grid)((FrameworkElement)this).Parent).Children.Remove((UIElement)(object)this);
		}), 0, After: true);
		ModAnimation.AniStart((System.Collections.IList)(object)array, "MyMsgBox " + Conversions.ToString(Uuid));
	}

	public void Btn1_Click()
	{
		TextArea.Validate();
		if (!MyConverter.IsExited && TextArea.IsValidated)
		{
			MyConverter.IsExited = true;
			MyConverter.Result = ((TextBox)TextArea).Text;
			Close();
		}
	}

	public void Btn2_Click()
	{
		if (!MyConverter.IsExited)
		{
			MyConverter.IsExited = true;
			MyConverter.Result = null;
			Close();
		}
	}

	private void TextCaption_ValidateChanged(object sender, EventArgs e)
	{
		((UIElement)Btn1).IsEnabled = TextArea.IsValidated;
	}

	private void Drag(object sender, MouseButtonEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Point position = ((MouseEventArgs)e).GetPosition((IInputElement)(object)ShapeLine);
		if (position.Y <= 2.0)
		{
			((Window)ModMain.FrmMain).DragMove();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/controls/mymsg/mymsginput.xaml", (UriKind)2);
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
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			TransformRotate = (RotateTransform)target;
			break;
		case 2:
			TransformPos = (TranslateTransform)target;
			break;
		case 3:
			PanBorder = (Border)target;
			break;
		case 4:
			EffectShadow = (DropShadowEffect)target;
			break;
		case 5:
			PanMain = (Grid)target;
			break;
		case 6:
			LabTitle = (TextBlock)target;
			break;
		case 7:
			ShapeLine = (Rectangle)target;
			break;
		case 8:
			PanText = (MyScrollViewer)target;
			break;
		case 9:
			LabText = (TextBlock)target;
			break;
		case 10:
			TextArea = (MyTextBox)target;
			break;
		case 11:
			PanBtn = (StackPanel)target;
			break;
		case 12:
			Btn1 = (MyButton)target;
			break;
		case 13:
			Btn2 = (MyButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
