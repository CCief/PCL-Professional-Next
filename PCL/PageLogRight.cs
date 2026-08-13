using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.UI;

namespace PCL;

[DesignerGenerated]
public class PageLogRight : MyPageRight, IComponentConnector
{
	public Run LabDebug;

	public Run LabInfo;

	public Run LabWarn;

	public Run LabError;

	public Run LabFatal;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnOperationExport")]
	private MyIconTextButton _BtnOperationExport;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnOperationClear")]
	private MyIconTextButton _BtnOperationClear;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnOperationKill")]
	private MyIconTextButton _BtnOperationKill;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnOperationExportStackDump")]
	private MyIconTextButton _BtnOperationExportStackDump;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderMaxLog")]
	private MySlider _SliderMaxLog;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanAllBack")]
	internal virtual Grid PanAllBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLogCard")]
	internal virtual MyCard PanLogCard
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

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
	[field: AccessedThroughProperty("PanLog")]
	internal virtual RichTextBox PanLog
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardOperation")]
	internal virtual MyCard CardOperation
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("OperationsContainer")]
	internal virtual StackPanel OperationsContainer
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CheckAutoScroll")]
	internal virtual MyCheckBox CheckAutoScroll
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconTextButton BtnOperationExport
	{
		[CompilerGenerated]
		get
		{
			return _BtnOperationExport;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnOperationExport_Click;
			MyIconTextButton btnOperationExport = _BtnOperationExport;
			if (btnOperationExport != null)
			{
				btnOperationExport.Click -= obj;
			}
			_BtnOperationExport = value;
			btnOperationExport = _BtnOperationExport;
			if (btnOperationExport != null)
			{
				btnOperationExport.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnOperationClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnOperationClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnOperationClear_Click;
			MyIconTextButton btnOperationClear = _BtnOperationClear;
			if (btnOperationClear != null)
			{
				btnOperationClear.Click -= obj;
			}
			_BtnOperationClear = value;
			btnOperationClear = _BtnOperationClear;
			if (btnOperationClear != null)
			{
				btnOperationClear.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnOperationKill
	{
		[CompilerGenerated]
		get
		{
			return _BtnOperationKill;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnOperationKill_Click;
			MyIconTextButton btnOperationKill = _BtnOperationKill;
			if (btnOperationKill != null)
			{
				btnOperationKill.Click -= obj;
			}
			_BtnOperationKill = value;
			btnOperationKill = _BtnOperationKill;
			if (btnOperationKill != null)
			{
				btnOperationKill.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnOperationExportStackDump
	{
		[CompilerGenerated]
		get
		{
			return _BtnOperationExportStackDump;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnOperationExportStackDump_Click;
			MyIconTextButton btnOperationExportStackDump = _BtnOperationExportStackDump;
			if (btnOperationExportStackDump != null)
			{
				btnOperationExportStackDump.Click -= obj;
			}
			_BtnOperationExportStackDump = value;
			btnOperationExportStackDump = _BtnOperationExportStackDump;
			if (btnOperationExportStackDump != null)
			{
				btnOperationExportStackDump.Click += obj;
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
			MySlider.ChangeEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				SliderMaxLog_ValueChanged((MySlider)a0, a1);
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

	public PageLogRight()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Initialized += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			Init();
		});
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageLogRight_Loaded);
		LabDebug = null;
		LabInfo = null;
		LabWarn = null;
		LabError = null;
		LabFatal = null;
		InitializeComponent();
	}

	public void Init()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_0073: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e0: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_013f: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected O, but got Unknown
		//IL_019e: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		//IL_01fd: Expected O, but got Unknown
		((TextElementCollection<Inline>)(object)PanLogCard.Inlines).Clear();
		((TextElementCollection<Inline>)(object)PanLogCard.Inlines).Add((Inline)new Run("实时日志"));
		((TextElementCollection<Inline>)(object)PanLogCard.Inlines).Add((Inline)new Run(" | "));
		LabDebug = new Run("0 Debug")
		{
			Foreground = (Brush)Application.Current.Resources[(object)"ColorBrushDebug"]
		};
		((TextElementCollection<Inline>)(object)PanLogCard.Inlines).Add((Inline)(object)LabDebug);
		((TextElementCollection<Inline>)(object)PanLogCard.Inlines).Add((Inline)new Run(" | "));
		LabInfo = new Run("0 Info")
		{
			Foreground = (Brush)Application.Current.Resources[(object)(ModSecret.IsDarkMode ? "ColorBrushInfoDark" : "ColorBrushInfo")]
		};
		((TextElementCollection<Inline>)(object)PanLogCard.Inlines).Add((Inline)(object)LabInfo);
		((TextElementCollection<Inline>)(object)PanLogCard.Inlines).Add((Inline)new Run(" | "));
		LabWarn = new Run("0 Warn")
		{
			Foreground = (Brush)Application.Current.Resources[(object)"ColorBrushWarn"]
		};
		((TextElementCollection<Inline>)(object)PanLogCard.Inlines).Add((Inline)(object)LabWarn);
		((TextElementCollection<Inline>)(object)PanLogCard.Inlines).Add((Inline)new Run(" | "));
		LabError = new Run("0 Error")
		{
			Foreground = (Brush)Application.Current.Resources[(object)"ColorBrushError"]
		};
		((TextElementCollection<Inline>)(object)PanLogCard.Inlines).Add((Inline)(object)LabError);
		((TextElementCollection<Inline>)(object)PanLogCard.Inlines).Add((Inline)new Run(" | "));
		LabFatal = new Run("0 Fatal")
		{
			Foreground = (Brush)Application.Current.Resources[(object)"ColorBrushFatal"]
		};
		((TextElementCollection<Inline>)(object)PanLogCard.Inlines).Add((Inline)(object)LabFatal);
	}

	private void PageLogRight_Loaded(object sender, RoutedEventArgs e)
	{
		checked
		{
			ModAnimation.AniControlEnabled++;
			Reload();
			ModAnimation.AniControlEnabled--;
		}
	}

	public void Reload()
	{
		if (ModMain.FrmLogLeft.CurrentLog == null || ModMain.FrmLogLeft.CurrentUuid <= 0 || ModMain.FrmLogLeft.ShownLogs.Count == 0)
		{
			ModMain.FrmMain.PageChange(ModMain.FrmMain.PageCurrent);
			return;
		}
		((UIElement)PanAllBack).Visibility = (Visibility)0;
		((UIElement)CardOperation).Visibility = (Visibility)0;
		((UIElement)BtnOperationKill).IsEnabled = !ModMain.FrmLogLeft.CurrentLog.GameProcess.HasExited;
		((UIElement)BtnOperationExportStackDump).IsEnabled = !ModMain.FrmLogLeft.CurrentLog.GameProcess.HasExited & !string.IsNullOrWhiteSpace(ModMain.FrmLogLeft.CurrentLog.JStackPath);
		SliderMaxLog.Value = Conversions.ToInteger(ModBase.Setup.Get("SystemMaxLog"));
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
		PanLog.Document = ModMain.FrmLogLeft.FlowDocuments[ModMain.FrmLogLeft.CurrentUuid];
		ModMain.FrmLogLeft.CurrentLog.LogOutput += OnLogOutput;
		ModMain.FrmLogLeft.CurrentLog.GameExit += OnGameExit;
		RefreshLabText();
	}

	private void RefreshLabText()
	{
		LabFatal.Text = $"{ModMain.FrmLogLeft.CurrentLog.CountFatal} Fatal";
		LabError.Text = $"{ModMain.FrmLogLeft.CurrentLog.CountError} Error";
		LabWarn.Text = $"{ModMain.FrmLogLeft.CurrentLog.CountWarn} Warn";
		LabInfo.Text = $"{ModMain.FrmLogLeft.CurrentLog.CountInfo} Info";
		LabDebug.Text = $"{ModMain.FrmLogLeft.CurrentLog.CountDebug} Debug";
	}

	private void OnLogOutput(ModWatcher.Watcher sender, ModWatcher.LogOutputEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			if (ModMain.FrmLogLeft.CurrentLog != null)
			{
				if (CheckAutoScroll.Checked.GetValueOrDefault())
				{
					((ScrollViewer)PanBack).ScrollToBottom();
				}
				RefreshLabText();
			}
		}));
	}

	private void BtnOperationClear_Click(object sender, ModBase.RouteEventArgs e)
	{
		((TextElementCollection<Block>)(object)ModMain.FrmLogLeft.FlowDocuments[ModMain.FrmLogLeft.CurrentUuid].Blocks).Clear();
	}

	private void BtnOperationExport_Click(object sender, ModBase.RouteEventArgs e)
	{
		string text = SystemDialogs.SelectSaveFile("选择导出位置", $"游戏日志 - {ModMain.FrmLogLeft.CurrentLog.Version.Name}.log", "游戏日志(*.log)|*.log");
		if (text.Length >= 3)
		{
			File.WriteAllLines(text, (System.Collections.Generic.IEnumerable<string>)ModMain.FrmLogLeft.CurrentLog.FullLog);
			ModMain.Hint("日志已导出！", ModMain.HintType.Finish);
			ModBase.OpenExplorer(text);
		}
	}

	private void BtnOperationKill_Click(object sender, ModBase.RouteEventArgs e)
	{
		if (ModMain.FrmLogLeft.CurrentLog.State <= ModWatcher.Watcher.MinecraftState.Running)
		{
			ModMain.FrmLogLeft.CurrentLog.Kill();
			ModMain.Hint($"已关闭游戏 {ModMain.FrmLogLeft.CurrentLog.Version.Name}！", ModMain.HintType.Finish);
		}
	}

	private void BtnOperationExportStackDump_Click(object sender, ModBase.RouteEventArgs e)
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		string text = SystemDialogs.SelectSaveFile("选择导出位置", string.Format("游戏运行栈 - {0}.log", (object)System.DateTime.Now.ToString("G").Replace("/", "-").Replace(":", ".")
			.Replace(" ", "_")), "游戏运行栈(*.log)|*.log");
		if (text.Length < 3)
		{
			return;
		}
		ModMain.Hint("正在导出运行栈，请稍等（可能需要 15 秒 ~ 1 分钟）");
		((UIElement)BtnOperationExportStackDump).IsEnabled = false;
		ModBase.RunInNewThread((Action)([SpecialName] () =>
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			List<string> val = ModMain.FrmLogLeft.CurrentLog.ExportStackDump(text);
			File.WriteAllLines(text, (System.Collections.Generic.IEnumerable<string>)val);
			ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
			{
				ModMain.Hint("运行栈已导出！", ModMain.HintType.Finish);
				((UIElement)BtnOperationExportStackDump).IsEnabled = true;
			}));
			ModBase.OpenExplorer(text);
		}), null, (ThreadPriority)2);
	}

	private void OnGameExit()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			((UIElement)BtnOperationKill).IsEnabled = false;
		}));
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			((UIElement)BtnOperationExportStackDump).IsEnabled = false;
		}));
	}

	private void SliderMaxLog_ValueChanged(MySlider sender, bool user)
	{
		ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), sender.Value);
		if (ModMain.FrmSetupSystem != null)
		{
			ModMain.FrmSetupSystem.SliderMaxLog.Value = sender.Value;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelogright.xaml", (UriKind)2);
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
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanAllBack = (Grid)target;
			break;
		case 2:
			PanLogCard = (MyCard)target;
			break;
		case 3:
			PanBack = (MyScrollViewer)target;
			break;
		case 4:
			PanLog = (RichTextBox)target;
			break;
		case 5:
			CardOperation = (MyCard)target;
			break;
		case 6:
			OperationsContainer = (StackPanel)target;
			break;
		case 7:
			CheckAutoScroll = (MyCheckBox)target;
			break;
		case 8:
			BtnOperationExport = (MyIconTextButton)target;
			break;
		case 9:
			BtnOperationClear = (MyIconTextButton)target;
			break;
		case 10:
			BtnOperationKill = (MyIconTextButton)target;
			break;
		case 11:
			BtnOperationExportStackDump = (MyIconTextButton)target;
			break;
		case 12:
			SliderMaxLog = (MySlider)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
