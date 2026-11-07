using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.App;
using PCL.Core.Link.Lobby;
using PCL.Core.Logging;
using PCL.Core.UI.Controls;
using PCL.Core.Utils;
using PCL.Core.Utils.OS;
using Path = System.Windows.Shapes.Path;

namespace PCL;

[DesignerGenerated]
public class FormMain : Window, IComponentConnector
{
	public enum PageType
	{
		Launch,
		Download,
		Link,
		Setup,
		Other,
		InstanceSelect,
		TaskManager,
		InstanceSetup,
		CompDetail,
		HelpDetail,
		GameLog,
		SetupJava,
		VersionSaves,
		HomePageMarket
	}

	public enum PageSubType
	{
		Default = 0,
		DownloadInstall = 1,
		DownloadMod = 2,
		DownloadPack = 3,
		DownloadDataPack = 4,
		DownloadResourcePack = 5,
		DownloadShader = 6,
		DownloadWorld = 7,
		DownloadSchematic = 8,
		DownloadCompFavorites = 9,
		SetupLaunch = 0,
		SetupUI = 1,
		SetupSystem = 2,
		SetupLink = 3,
		LinkJoin = 0,
		LinkOpenFrp = 1,
		LinkMeFrp = 2,
		LinkNatfrp = 3,
		LinkXhFrp = 4,
		LinkStellarfrp = 5,
		LinkLobby = 3,
		LinkSetup = 6,
		LinkHelp = 7,
		LinkFeedback = 8,
		OtherHelp = 0,
		OtherAbout = 1,
		OtherTest = 2,
		OtherFeedback = 3,
		OtherVote = 4,
		OtherLog = 5,
		VersionOverall = 0,
		VersionSetup = 1,
		VersionExport = 2,
		VersionWorld = 3,
		VersionScreenshot = 4,
		VersionMod = 5,
		VersionModDisabled = 6,
		VersionResourcePack = 7,
		VersionShader = 8,
		VersionSchematic = 9,
		VersionInstall = 10,
		VersionServer = 11,
		VersionSavesInfo = 0,
		VersionSavesBackup = 1
	}

	public class PageStackData
	{
		public PageType Page;

		public object Additional;

		public virtual bool Equals(object other)
		{
			if (other == null)
			{
				return false;
			}
			if (other is PageStackData)
			{
				PageStackData pageStackData = (PageStackData)other;
				if (Page != pageStackData.Page)
				{
					return false;
				}
				if (Additional == null)
				{
					return pageStackData.Additional == null;
				}
				return pageStackData.Additional != null && Additional.Equals(RuntimeHelpers.GetObjectValue(pageStackData.Additional));
			}
			if (other is int)
			{
				if (Operators.ConditionalCompareObjectNotEqual((object)Page, other, false))
				{
					return false;
				}
				return Additional == null;
			}
			return false;
		}

		public static bool operator ==(PageStackData left, PageStackData right)
		{
			return EqualityComparer<PageStackData>.Default.Equals(left, right);
		}

		public static bool operator !=(PageStackData left, PageStackData right)
		{
			return !(left == right);
		}

		public static implicit operator PageStackData(PageType Value)
		{
			return new PageStackData
			{
				Page = Value
			};
		}

		public static implicit operator PageType(PageStackData Value)
		{
			return Value.Page;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action _0024I1_002D0;

		public static ThreadStart _0024I4_002D0;

		public static Action _0024I4_002D5;

		public static Action _0024I6_002D0;

		public static Action _0024I10_002D0;

		public static ThreadStart _0024I10_002D6;

		public static Action _0024I28_002D2;

		public static Action _0024I28_002D4;

		public static Action _0024I28_002D5;

		public static Action _0024I28_002D6;

		public static Action _0024I28_002D7;

		public static Action _0024I63_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__1_002D0()
		{
			string text = $"{ModBase.PathTemp}ProUpdateLog.md";
			string caption = ((!File.Exists(text)) ? "欢迎使用呀~" : ModBase.ReadFile(text));
			if (ModMain.MyMsgBoxMarkdown(caption, "PCL Pro-N 已更新至 Publish 2.13.3", "确定", "完整更新日志") == 2)
			{
				ModBase.OpenWebsite("https://github.com/PCLPro/PCLPro/releases");
			}
		}

		[SpecialName]
		internal void _Lambda_0024__4_002D0()
		{
			checked
			{
				ModAnimation.AniControlEnabled--;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__4_002D5()
		{
			ModBase.OpenWebsite("https://shimo.im/docs/rGrd8pY8xWkt6ryW");
		}

		[SpecialName]
		internal void _Lambda_0024__6_002D0()
		{
			ModProfile.MigrateOldProfile();
		}

		[SpecialName]
		internal void _Lambda_0024__10_002D0()
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			ModBase.Log("[System] 正在强行停止任务");
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.Abort();
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__10_002D6()
		{
			EndProgramForce(ModBase.ProcessReturnValues.Success, force: false);
		}

		[SpecialName]
		internal void _Lambda_0024__28_002D2()
		{
			ModBase.Setup.Set("UiCustomType", 1);
			ModMain.FrmLaunchRight.ForceRefresh();
			ModMain.Hint("已加载主页自定义文件！", ModMain.HintType.Finish);
		}

		[SpecialName]
		internal void _Lambda_0024__28_002D4()
		{
			ModMain.FrmInstanceSaves.Reload();
		}

		[SpecialName]
		internal void _Lambda_0024__28_002D5()
		{
			ModMain.FrmInstanceResourcePack.ReloadCompFileList();
		}

		[SpecialName]
		internal void _Lambda_0024__28_002D6()
		{
			ModMain.FrmInstanceShader.ReloadCompFileList();
		}

		[SpecialName]
		internal void _Lambda_0024__28_002D7()
		{
			ModMain.FrmInstanceSchematic.ReloadCompFileList();
		}

		[SpecialName]
		internal void _Lambda_0024__63_002D0()
		{
			if (ModMain.DragControl != null)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(ModMain.DragControl);
				ModMain.DragControl = null;
				NewLateBinding.LateCall(objectValue, (System.Type)null, "DragStop", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__10_002D0
	{
		public ScaleTransform _0024VB_0024Local_TransformScale;

		public TranslateTransform _0024VB_0024Local_TransformPos;

		public RotateTransform _0024VB_0024Local_TransformRotate;

		public _Closure_0024__10_002D0(_Closure_0024__10_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_TransformScale = arg0._0024VB_0024Local_TransformScale;
				_0024VB_0024Local_TransformPos = arg0._0024VB_0024Local_TransformPos;
				_0024VB_0024Local_TransformRotate = arg0._0024VB_0024Local_TransformRotate;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2(object i)
		{
			ScaleTransform val;
			(val = _0024VB_0024Local_TransformScale).ScaleX = Conversions.ToDouble(Operators.AddObject((object)val.ScaleX, i));
			(val = _0024VB_0024Local_TransformScale).ScaleY = Conversions.ToDouble(Operators.AddObject((object)val.ScaleY, i));
		}

		[SpecialName]
		internal void _Lambda_0024__3(object i)
		{
			TranslateTransform val;
			(val = _0024VB_0024Local_TransformPos).Y = Conversions.ToDouble(Operators.AddObject((object)val.Y, i));
		}

		[SpecialName]
		internal void _Lambda_0024__4(object i)
		{
			RotateTransform val;
			(val = _0024VB_0024Local_TransformRotate).Angle = Conversions.ToDouble(Operators.AddObject((object)val.Angle, i));
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__56_002D0
	{
		public string _0024VB_0024Local_PageName;

		public FormMain _0024VB_0024Me;

		public _Closure_0024__56_002D0(_Closure_0024__56_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_PageName = arg0._0024VB_0024Local_PageName;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			_0024VB_0024Me.LabTitleInner.Text = _0024VB_0024Local_PageName;
		}
	}

	private bool IsWindowLoadFinished;

	private static bool IsLogShown = false;

	public bool IsSizeSaveable;

	private object Resizer;

	public bool IsSystemTimeChanged;

	private bool _Hidden;

	public PageStackData PageCurrent;

	public PageStackData PageLast;

	public List<PageStackData> PageStack;

	public MyPageLeft PageLeft;

	public MyPageRight PageRight;

	private bool IsChangingPage;

	public MouseEventArgs lastMouseArg;

	[CompilerGenerated]
	[AccessedThroughProperty("PanBack")]
	private Grid _PanBack;

	[CompilerGenerated]
	[AccessedThroughProperty("PanTitle")]
	private Grid _PanTitle;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnTitleClose")]
	private MyIconButton _BtnTitleClose;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnTitleMin")]
	private MyIconButton _BtnTitleMin;

	[CompilerGenerated]
	[AccessedThroughProperty("PanTitleLeft")]
	private Grid _PanTitleLeft;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnTitleSelect0")]
	private MyRadioButton _BtnTitleSelect0;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnTitleSelect1")]
	private MyRadioButton _BtnTitleSelect1;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnTitleSelect2")]
	private MyRadioButton _BtnTitleSelect2;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnTitleSelect3")]
	private MyRadioButton _BtnTitleSelect3;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnTitleSelect4")]
	private MyRadioButton _BtnTitleSelect4;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnTitleInner")]
	private MyIconButton _BtnTitleInner;

	[CompilerGenerated]
	[AccessedThroughProperty("PanMainLeft")]
	private Border _PanMainLeft;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnExtraBack")]
	private MyExtraButton _BtnExtraBack;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnExtraDownload")]
	private MyExtraButton _BtnExtraDownload;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnExtraApril")]
	private MyExtraButton _BtnExtraApril;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnExtraShutdown")]
	private MyExtraButton _BtnExtraShutdown;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnExtraLog")]
	private MyExtraButton _BtnExtraLog;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnExtraMusic")]
	private MyExtraButton _BtnExtraMusic;

	[CompilerGenerated]
	[AccessedThroughProperty("PanMsg")]
	private Grid _PanMsg;

	private bool _contentLoaded;

	[SpecialName]
	private IDataObject _0024STATIC_0024HandleDrag_002420211C1282E5_0024PrevData;

	[SpecialName]
	private DragDropEffects _0024STATIC_0024HandleDrag_002420211C1282E5_0024PrevEffects;

	public bool Hidden
	{
		get
		{
			return _Hidden;
		}
		set
		{
			if (_Hidden == value)
			{
				return;
			}
			_Hidden = value;
			if (value)
			{
				((Window)this).Left = ((Window)this).Left - 10000.0;
				((Window)this).ShowInTaskbar = false;
				((UIElement)this).Visibility = (Visibility)1;
				ModBase.Log(string.Concat(new string[5]
				{
					"[System] 窗口已隐藏，位置：(",
					Conversions.ToString(((Window)this).Left),
					",",
					Conversions.ToString(((Window)this).Top),
					")"
				}));
			}
			else
			{
				if (((Window)this).Left < -2000.0)
				{
					((Window)this).Left = ((Window)this).Left + 10000.0;
				}
				ShowWindowToTop();
			}
		}
	}

	public PageSubType PageCurrentSub
	{
		get
		{
			PageStackData pageCurrent = PageCurrent;
			if (pageCurrent == PageType.Download)
			{
				if (ModMain.FrmDownloadLeft == null)
				{
					ModMain.FrmDownloadLeft = new PageDownloadLeft();
				}
				return ModMain.FrmDownloadLeft.PageID;
			}
			if (pageCurrent == PageType.Setup)
			{
				if (ModMain.FrmSetupLeft == null)
				{
					ModMain.FrmSetupLeft = new PageSetupLeft();
				}
				return ModMain.FrmSetupLeft.PageID;
			}
			if (pageCurrent == PageType.Other)
			{
				if (ModMain.FrmOtherLeft == null)
				{
					ModMain.FrmOtherLeft = new PageOtherLeft();
				}
				return ModMain.FrmOtherLeft.PageID;
			}
			if (pageCurrent == PageType.InstanceSetup)
			{
				if (ModMain.FrmInstanceLeft == null)
				{
					ModMain.FrmInstanceLeft = new PageInstanceLeft();
				}
				return ModMain.FrmInstanceLeft.PageID;
			}
			return PageSubType.Default;
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("WindMain")]
	internal virtual FormMain WindMain
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid PanBack
	{
		[CompilerGenerated]
		get
		{
			return _PanBack;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseEventHandler val = (MouseEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseEventArgs a1) =>
			{
				DragDoing();
			});
			Grid panBack = _PanBack;
			if (panBack != null)
			{
				((UIElement)panBack).MouseMove -= val;
			}
			_PanBack = value;
			panBack = _PanBack;
			if (panBack != null)
			{
				((UIElement)panBack).MouseMove += val;
			}
		}
	}

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

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ResizerT")]
	internal virtual Rectangle ResizerT
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ResizerB")]
	internal virtual Rectangle ResizerB
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ResizerR")]
	internal virtual Rectangle ResizerR
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ResizerL")]
	internal virtual Rectangle ResizerL
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ResizerLT")]
	internal virtual Rectangle ResizerLT
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ResizerLB")]
	internal virtual Rectangle ResizerLB
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ResizerRB")]
	internal virtual Rectangle ResizerRB
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ResizerRT")]
	internal virtual Rectangle ResizerRT
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BorderForm")]
	internal virtual Border BorderForm
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("RectForm")]
	internal virtual RectangleGeometry RectForm
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanForm")]
	internal virtual Grid PanForm
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgBack")]
	internal virtual Canvas ImgBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("VideoBack")]
	internal virtual MediaElement VideoBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid PanTitle
	{
		[CompilerGenerated]
		get
		{
			return _PanTitle;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(FormDragMove);
			Grid panTitle = _PanTitle;
			if (panTitle != null)
			{
				((UIElement)panTitle).MouseLeftButtonDown -= val;
			}
			_PanTitle = value;
			panTitle = _PanTitle;
			if (panTitle != null)
			{
				((UIElement)panTitle).MouseLeftButtonDown += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgTitle")]
	internal virtual MyImage ImgTitle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconButton BtnTitleClose
	{
		[CompilerGenerated]
		get
		{
			return _BtnTitleClose;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Expected O, but got Unknown
				BtnTitleClose_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
			};
			MyIconButton btnTitleClose = _BtnTitleClose;
			if (btnTitleClose != null)
			{
				btnTitleClose.Click -= obj;
			}
			_BtnTitleClose = value;
			btnTitleClose = _BtnTitleClose;
			if (btnTitleClose != null)
			{
				btnTitleClose.Click += obj;
			}
		}
	}

	internal virtual MyIconButton BtnTitleMin
	{
		[CompilerGenerated]
		get
		{
			return _BtnTitleMin;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				BtnTitleMin_Click();
			};
			MyIconButton btnTitleMin = _BtnTitleMin;
			if (btnTitleMin != null)
			{
				btnTitleMin.Click -= obj;
			}
			_BtnTitleMin = value;
			btnTitleMin = _BtnTitleMin;
			if (btnTitleMin != null)
			{
				btnTitleMin.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanTitleMain")]
	internal virtual Grid PanTitleMain
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid PanTitleLeft
	{
		[CompilerGenerated]
		get
		{
			return _PanTitleLeft;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SizeChangedEventHandler val = (SizeChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, SizeChangedEventArgs a1) =>
			{
				PanTitle_SizeChanged();
			});
			Grid panTitleLeft = _PanTitleLeft;
			if (panTitleLeft != null)
			{
				((FrameworkElement)panTitleLeft).SizeChanged -= val;
			}
			_PanTitleLeft = value;
			panTitleLeft = _PanTitleLeft;
			if (panTitleLeft != null)
			{
				((FrameworkElement)panTitleLeft).SizeChanged += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ShapeTitleLogo")]
	internal virtual Path ShapeTitleLogo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabTitleLogo")]
	internal virtual TextBlock LabTitleLogo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImageTitleLogo")]
	internal virtual MyImage ImageTitleLogo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ProLogo")]
	internal virtual Border ProLogo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanTitleSelect")]
	internal virtual StackPanel PanTitleSelect
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyRadioButton BtnTitleSelect0
	{
		[CompilerGenerated]
		get
		{
			return _BtnTitleSelect0;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				BtnTitleSelect_Click((MyRadioButton)a0, a1);
			};
			MyRadioButton btnTitleSelect = _BtnTitleSelect0;
			if (btnTitleSelect != null)
			{
				btnTitleSelect.Check -= obj;
			}
			_BtnTitleSelect0 = value;
			btnTitleSelect = _BtnTitleSelect0;
			if (btnTitleSelect != null)
			{
				btnTitleSelect.Check += obj;
			}
		}
	}

	internal virtual MyRadioButton BtnTitleSelect1
	{
		[CompilerGenerated]
		get
		{
			return _BtnTitleSelect1;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				BtnTitleSelect_Click((MyRadioButton)a0, a1);
			};
			MyRadioButton btnTitleSelect = _BtnTitleSelect1;
			if (btnTitleSelect != null)
			{
				btnTitleSelect.Check -= obj;
			}
			_BtnTitleSelect1 = value;
			btnTitleSelect = _BtnTitleSelect1;
			if (btnTitleSelect != null)
			{
				btnTitleSelect.Check += obj;
			}
		}
	}

	internal virtual MyRadioButton BtnTitleSelect2
	{
		[CompilerGenerated]
		get
		{
			return _BtnTitleSelect2;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				BtnTitleSelect_Click((MyRadioButton)a0, a1);
			};
			MyRadioButton btnTitleSelect = _BtnTitleSelect2;
			if (btnTitleSelect != null)
			{
				btnTitleSelect.Check -= obj;
			}
			_BtnTitleSelect2 = value;
			btnTitleSelect = _BtnTitleSelect2;
			if (btnTitleSelect != null)
			{
				btnTitleSelect.Check += obj;
			}
		}
	}

	internal virtual MyRadioButton BtnTitleSelect3
	{
		[CompilerGenerated]
		get
		{
			return _BtnTitleSelect3;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				BtnTitleSelect_Click((MyRadioButton)a0, a1);
			};
			MyRadioButton btnTitleSelect = _BtnTitleSelect3;
			if (btnTitleSelect != null)
			{
				btnTitleSelect.Check -= obj;
			}
			_BtnTitleSelect3 = value;
			btnTitleSelect = _BtnTitleSelect3;
			if (btnTitleSelect != null)
			{
				btnTitleSelect.Check += obj;
			}
		}
	}

	internal virtual MyRadioButton BtnTitleSelect4
	{
		[CompilerGenerated]
		get
		{
			return _BtnTitleSelect4;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				BtnTitleSelect_Click((MyRadioButton)a0, a1);
			};
			MyRadioButton btnTitleSelect = _BtnTitleSelect4;
			if (btnTitleSelect != null)
			{
				btnTitleSelect.Check -= obj;
			}
			_BtnTitleSelect4 = value;
			btnTitleSelect = _BtnTitleSelect4;
			if (btnTitleSelect != null)
			{
				btnTitleSelect.Check += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanTitleInner")]
	internal virtual Grid PanTitleInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconButton BtnTitleInner
	{
		[CompilerGenerated]
		get
		{
			return _BtnTitleInner;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				PageBack();
			};
			MyIconButton btnTitleInner = _BtnTitleInner;
			if (btnTitleInner != null)
			{
				btnTitleInner.Click -= obj;
			}
			_BtnTitleInner = value;
			btnTitleInner = _BtnTitleInner;
			if (btnTitleInner != null)
			{
				btnTitleInner.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabTitleInner")]
	internal virtual TextBlock LabTitleInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLeft")]
	internal virtual Grid PanLeft
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("RectLeftBackground")]
	internal virtual BlurBorder RectLeftBackground
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("RectLeftShadow")]
	internal virtual Rectangle RectLeftShadow
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

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanMainRight")]
	internal virtual Border PanMainRight
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Border PanMainLeft
	{
		[CompilerGenerated]
		get
		{
			return _PanMainLeft;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SizeChangedEventHandler val = new SizeChangedEventHandler(PanMainLeft_SizeChanged);
			Border panMainLeft = _PanMainLeft;
			if (panMainLeft != null)
			{
				((FrameworkElement)panMainLeft).SizeChanged -= val;
			}
			_PanMainLeft = value;
			panMainLeft = _PanMainLeft;
			if (panMainLeft != null)
			{
				((FrameworkElement)panMainLeft).SizeChanged += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanHint")]
	internal virtual StackPanel PanHint
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyExtraButton BtnExtraBack
	{
		[CompilerGenerated]
		get
		{
			return _BtnExtraBack;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyExtraButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				BackToTop();
			};
			MyExtraButton btnExtraBack = _BtnExtraBack;
			if (btnExtraBack != null)
			{
				btnExtraBack.Click -= obj;
			}
			_BtnExtraBack = value;
			btnExtraBack = _BtnExtraBack;
			if (btnExtraBack != null)
			{
				btnExtraBack.Click += obj;
			}
		}
	}

	internal virtual MyExtraButton BtnExtraDownload
	{
		[CompilerGenerated]
		get
		{
			return _BtnExtraDownload;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyExtraButton.ClickEventHandler obj = BtnExtraDownload_Click;
			MyExtraButton btnExtraDownload = _BtnExtraDownload;
			if (btnExtraDownload != null)
			{
				btnExtraDownload.Click -= obj;
			}
			_BtnExtraDownload = value;
			btnExtraDownload = _BtnExtraDownload;
			if (btnExtraDownload != null)
			{
				btnExtraDownload.Click += obj;
			}
		}
	}

	internal virtual MyExtraButton BtnExtraApril
	{
		[CompilerGenerated]
		get
		{
			return _BtnExtraApril;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyExtraButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				AprilGiveup();
			};
			MyExtraButton btnExtraApril = _BtnExtraApril;
			if (btnExtraApril != null)
			{
				btnExtraApril.Click -= obj;
			}
			_BtnExtraApril = value;
			btnExtraApril = _BtnExtraApril;
			if (btnExtraApril != null)
			{
				btnExtraApril.Click += obj;
			}
		}
	}

	internal virtual MyExtraButton BtnExtraShutdown
	{
		[CompilerGenerated]
		get
		{
			return _BtnExtraShutdown;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyExtraButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnExtraShutdown_Click();
			};
			MyExtraButton btnExtraShutdown = _BtnExtraShutdown;
			if (btnExtraShutdown != null)
			{
				btnExtraShutdown.Click -= obj;
			}
			_BtnExtraShutdown = value;
			btnExtraShutdown = _BtnExtraShutdown;
			if (btnExtraShutdown != null)
			{
				btnExtraShutdown.Click += obj;
			}
		}
	}

	internal virtual MyExtraButton BtnExtraLog
	{
		[CompilerGenerated]
		get
		{
			return _BtnExtraLog;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyExtraButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnExtraLog_Click();
			};
			MyExtraButton btnExtraLog = _BtnExtraLog;
			if (btnExtraLog != null)
			{
				btnExtraLog.Click -= obj;
			}
			_BtnExtraLog = value;
			btnExtraLog = _BtnExtraLog;
			if (btnExtraLog != null)
			{
				btnExtraLog.Click += obj;
			}
		}
	}

	internal virtual MyExtraButton BtnExtraMusic
	{
		[CompilerGenerated]
		get
		{
			return _BtnExtraMusic;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyExtraButton.ClickEventHandler obj = BtnExtraMusic_Click;
			MyExtraButton.RightClickEventHandler obj2 = BtnExtraMusic_RightClick;
			MyExtraButton btnExtraMusic = _BtnExtraMusic;
			if (btnExtraMusic != null)
			{
				btnExtraMusic.Click -= obj;
				btnExtraMusic.RightClick -= obj2;
			}
			_BtnExtraMusic = value;
			btnExtraMusic = _BtnExtraMusic;
			if (btnExtraMusic != null)
			{
				btnExtraMusic.Click += obj;
				btnExtraMusic.RightClick += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanMsgBackground")]
	internal virtual BlurBorder PanMsgBackground
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid PanMsg
	{
		[CompilerGenerated]
		get
		{
			return _PanMsg;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(FormDragMove);
			Grid panMsg = _PanMsg;
			if (panMsg != null)
			{
				((UIElement)panMsg).MouseLeftButtonDown -= val;
			}
			_PanMsg = value;
			panMsg = _PanMsg;
			if (panMsg != null)
			{
				((UIElement)panMsg).MouseLeftButtonDown += val;
			}
		}
	}

	private void ShowUpdateLog()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I1_002D0 != null)
		{
			action = _Closure_0024__._0024I1_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				string text = $"{ModBase.PathTemp}ProUpdateLog.md";
				string caption = ((!File.Exists(text)) ? "欢迎使用呀~" : ModBase.ReadFile(text));
				if (ModMain.MyMsgBoxMarkdown(caption, "PCL Pro-N 已更新至 Publish 2.13.3", "确定", "完整更新日志") == 2)
				{
					ModBase.OpenWebsite("https://github.com/PCLPro/PCLPro/releases");
				}
			};
			_Closure_0024__._0024I1_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInNewThread((Action)action, "UpdateLog Output", (ThreadPriority)2);
	}

	public FormMain()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Expected O, but got Unknown
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		((Window)this).Closing += new CancelEventHandler(FormMain_Closing);
		((FrameworkElement)this).SizeChanged += (SizeChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, SizeChangedEventArgs a1) =>
		{
			FormMain_SizeChanged();
		});
		((UIElement)this).KeyDown += new KeyEventHandler(FormMain_KeyDown);
		((UIElement)this).MouseDown += new MouseButtonEventHandler(FormMain_MouseDown);
		((Window)this).Activated += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			FormMain_Activated();
		});
		((UIElement)this).Drop += new DragEventHandler(FrmMain_Drop);
		((Window)this).StateChanged += new EventHandler(WindowStateChanged);
		((UIElement)this).MouseMove += new MouseEventHandler(FormMain_MouseMove);
		IsWindowLoadFinished = false;
		IsSizeSaveable = false;
		IsSystemTimeChanged = false;
		_Hidden = false;
		PageCurrent = PageType.Launch;
		PageLast = PageType.Launch;
		PageStack = new List<PageStackData>();
		IsChangingPage = false;
		lastMouseArg = null;
		ModBase.ApplicationStartTick = TimeUtils.GetTimeTick();
		ModSecret.ThemeCheckAll(EffectSetup: false);
		switch (Conversions.ToInteger(ModBase.Setup.Get("UiDarkMode")))
		{
		case 0:
			ModSecret.IsDarkMode = false;
			break;
		case 1:
			ModSecret.IsDarkMode = true;
			break;
		case 2:
			ModSecret.IsDarkMode = SystemTheme.IsSystemInDarkMode();
			break;
		}
		ModSecret.ThemeRefreshColor();
		ModMain.FrmMain = this;
		ModMain.FrmLaunchLeft = new PageLaunchLeft();
		ModMain.FrmLaunchRight = new PageLaunchRight();
		int num = Conversions.ToInteger(ModBase.Setup.Get("SystemLastVersionReg"));
		if (num < 413)
		{
			UpgradeSub(num);
		}
		else if (num > 413)
		{
			DowngradeSub(num);
		}
		if (ModBase.Setup.IsUnset("LaunchArgumentIndieV2"))
		{
			if (!ModBase.Setup.IsUnset("LaunchArgumentIndie"))
			{
				ModBase.Log("[Start] 从老 PCL 迁移版本隔离");
				ModBase.Setup.Set("LaunchArgumentIndieV2", RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LaunchArgumentIndie")));
			}
			else if (!ModBase.Setup.IsUnset("WindowHeight"))
			{
				ModBase.Log("[Start] 从老 PCL 升级，但此前未调整版本隔离，使用老的版本隔离默认值");
				ModBase.Setup.Set("LaunchArgumentIndieV2", RuntimeHelpers.GetObjectValue(ModBase.Setup.GetDefault("LaunchArgumentIndie")));
			}
			else
			{
				ModBase.Log("[Start] 全新的 PCL，使用新的版本隔离默认值");
				ModBase.Setup.Set("LaunchArgumentIndieV2", RuntimeHelpers.GetObjectValue(ModBase.Setup.GetDefault("LaunchArgumentIndieV2")));
			}
		}
		ModBase.Setup.Load("UiLauncherTheme");
		base.AddHandler(DragDrop.DragEnterEvent, (System.Delegate)new DragEventHandler(HandleDrag), true);
		base.AddHandler(DragDrop.DragOverEvent, (System.Delegate)new DragEventHandler(HandleDrag), true);
		InitializeComponent();
		((UIElement)this).Opacity = 0.0;
		try
		{
			((FrameworkElement)this).Height = Conversions.ToDouble(ModBase.Setup.Get("WindowHeight"));
			((FrameworkElement)this).Width = Conversions.ToDouble(ModBase.Setup.Get("WindowWidth"));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "读取窗口默认大小失败", ModBase.LogLevel.Hint);
			((FrameworkElement)this).Height = ((FrameworkElement)this).MinHeight + 100.0;
			((FrameworkElement)this).Width = ((FrameworkElement)this).MinWidth + 100.0;
			ProjectData.ClearProjectError();
		}
		if (!Information.IsNothing((object)((FrameworkElement)ModMain.FrmLaunchLeft).Parent))
		{
			((DependencyObject)ModMain.FrmLaunchLeft).SetValue(ContentPresenter.ContentProperty, (object)null);
		}
		if (!Information.IsNothing((object)((FrameworkElement)ModMain.FrmLaunchRight).Parent))
		{
			((DependencyObject)ModMain.FrmLaunchRight).SetValue(ContentPresenter.ContentProperty, (object)null);
		}
		((Decorator)PanMainLeft).Child = (UIElement)(object)ModMain.FrmLaunchLeft;
		PageLeft = ModMain.FrmLaunchLeft;
		((Decorator)PanMainRight).Child = (UIElement)(object)ModMain.FrmLaunchRight;
		PageRight = ModMain.FrmLaunchRight;
		ModMain.FrmLaunchRight.PageState = MyPageRight.PageStates.ContentStay;
		if (ModBase.ModeDebug)
		{
			ModMain.Hint("[调试模式] PCL 正以调试模式运行，这可能会导致性能下降，若无必要请不要开启！");
		}
		ModMinecraft.McFolderListLoader.Start(0);
		ModBase.Log("[Start] 第二阶段加载用时：" + Conversions.ToString(checked(TimeUtils.GetTimeTick() - ModBase.ApplicationStartTick)) + " ms");
		Lifecycle.When(LifecycleState.WindowCreated, new Action(FormMain_Loaded));
	}

	private void FormMain_Loaded()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected O, but got Unknown
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Expected O, but got Unknown
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected O, but got Unknown
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Expected O, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Expected O, but got Unknown
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Expected O, but got Unknown
		ModMain.MyMsgBox("本项目为社区自发维护的开源分支（Non-official Community Edition），由 SomeBudings（新芽）二次开发并更名为 PCL Pro-N，不代表 PCL Pro-N 原作者龙腾猫跃及 PCL2 官方开发者立场。\n\n软件完全免费，仅供交流学习使用。", "免责声明", "确定", "", "", IsWarn: false, HighLight: false);
		PCLVerCompat.SetProBadge(this);
		ModBase.ApplicationStartTick = TimeUtils.GetTimeTick();
		ModBase.FrmHandle = new WindowInteropHelper((Window)(object)this).Handle;
		ModBase.Setup.Load("UiBackgroundOpacity");
		ModBase.Setup.Load("UiBackgroundBlur");
		ModBase.Setup.Load("UiLogoType");
		ModBase.Setup.Load("UiHiddenPageDownload");
		ModBase.Setup.Load("UiAutoPauseVideo");
		PageSetupUI.BackgroundRefresh(IsHint: false, Refresh: true);
		ModMusic.MusicRefreshPlay(ShowHint: false, IsFirstLoad: true);
		BtnExtraDownload.ShowCheck = BtnExtraDownload_ShowCheck;
		BtnExtraBack.ShowCheck = BtnExtraBack_ShowCheck;
		BtnExtraApril.ShowCheck = BtnExtraApril_ShowCheck;
		BtnExtraShutdown.ShowCheck = BtnExtraShutdown_ShowCheck;
		BtnExtraLog.ShowCheck = BtnExtraLog_ShowCheck;
		BtnExtraApril.ShowRefresh();
		Resizer = new MyResizer((Window)(object)this);
		if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiLockWindowSize"))))
		{
			AddResizer();
		}
		if (RandomUtils.NextInt(1, 1000) == 233)
		{
			ShapeTitleLogo.Data = (Geometry)((TypeConverter)new GeometryConverter()).ConvertFromString("M26,29 v-25 h6 a7,7 180 0 1 0,14 h-6 M83,6.5 a10,11.5 180 1 0 0,18 M48,2.5 v24.5 h13.5");
		}
		ModSecret.ThemeRefresh();
		Application.Current.Resources[(object)"BlurSamplingRate"] = Operators.MultiplyObject(ModBase.Setup.Get("UiBlurSamplingRate"), (object)0.01);
		Application.Current.Resources[(object)"BlurType"] = (object)(KernelType)Conversions.ToInteger(ModBase.Setup.Get("UiBlurType"));
		if (Conversions.ToBoolean(ModBase.Setup.Get("UiBlur")))
		{
			Application.Current.Resources[(object)"BlurRadius"] = Operators.MultiplyObject(ModBase.Setup.Get("UiBlurValue"), (object)1.0);
		}
		else
		{
			Application.Current.Resources[(object)"BlurRadius"] = 0.0;
		}
		((Window)this).Topmost = false;
		checked
		{
			if (ModMain.FrmStart != null)
			{
				ModMain.FrmStart.Close(new TimeSpan(0, 0, 0, 0, (int)Math.Round(400.0 / ModAnimation.AniSpeed)));
			}
			IsSizeSaveable = true;
			ShowWindowToTop();
			((HwndSource)PresentationSource.FromVisual((Visual)(object)this)).AddHook(new HwndSourceHook(WndProc));
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
					ModAnimation.AniControlEnabled--;
				};
				_Closure_0024__._0024I4_002D0 = val;
				code = (object)val;
			}
			array[0] = ModAnimation.AaCode((ThreadStart)code, 50);
			array[1] = ModAnimation.AaOpacity(this, Conversions.ToDouble(Operators.AddObject(Operators.DivideObject(ModBase.Setup.Get("UiLauncherTransparent"), (object)1000), (object)0.4)), 250, 100);
			array[2] = ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] [CompilerGenerated] (object i) =>
			{
				TranslateTransform transformPos;
				(transformPos = TransformPos).Y = Conversions.ToDouble(Operators.AddObject((object)transformPos.Y, i));
			}), 0.0 - TransformPos.Y, 600, 100, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak));
			array[3] = ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] [CompilerGenerated] (object i) =>
			{
				RotateTransform transformRotate;
				(transformRotate = TransformRotate).Angle = Conversions.ToDouble(Operators.AddObject((object)transformRotate.Angle, i));
			}), 0.0 - TransformRotate.Angle, 500, 100, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak));
			array[4] = ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
			{
				((UIElement)PanBack).RenderTransform = null;
				IsWindowLoadFinished = true;
				ModBase.Log($"[System] DPI：{ModBase.DPI}，系统版本：{Environment.OSVersion.VersionString}，PCL 位置：{ModBase.ExePathWithName}");
			}), 0, After: true);
			ModAnimation.AniStart((System.Collections.IList)(object)array, "Form Show");
			ModAnimation.AniStart();
			ModMain.TimerMainStart();
			ModBase.RunInNewThread((Action)([SpecialName] [CompilerGenerated] () =>
			{
				//IL_0053: Unknown result type (might be due to invalid IL or missing references)
				//IL_0058: Unknown result type (might be due to invalid IL or missing references)
				//IL_005e: Expected O, but got Unknown
				//IL_0113: Unknown result type (might be due to invalid IL or missing references)
				//IL_0123: Expected O, but got Unknown
				if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("SystemEula"))))
				{
					object button3Action;
					if (_Closure_0024__._0024I4_002D5 != null)
					{
						button3Action = _Closure_0024__._0024I4_002D5;
					}
					else
					{
						Action val2 = [SpecialName] () =>
						{
							ModBase.OpenWebsite("https://shimo.im/docs/rGrd8pY8xWkt6ryW");
						};
						_Closure_0024__._0024I4_002D5 = val2;
						button3Action = (object)val2;
					}
					switch (ModMain.MyMsgBox("在使用 PCL Pro-N 前，请确定", "协议授权", "我的任何行为均与开发者无关，均为我自愿", "拒绝", "查看用户协议与免责声明", IsWarn: false, HighLight: true, ForceWait: false, null, null, (Action)button3Action))
					{
					case 1:
						ModBase.Setup.Set("SystemEula", true);
						break;
					case 2:
						EndProgram(SendWarning: false);
						break;
					}
				}
				if (ModBase.Setup.IsUnset("SystemTelemetry"))
				{
					ModMain.MyMsgBox("为了保护您的隐私，PCL Pro-N 已禁用遥测功能，不会收集任何数据。", "遥测已禁用");
					ModBase.Setup.Set("SystemTelemetry", false);
				}
				try
				{
					Thread.Sleep(100);
					ModDownload.DlClientListMojangLoader.Start(1);
					RunCountSub();
					ModSecret.ServerLoader.Start(1);
					ModBase.RunInNewThread(new Action(ModMain.TryClearTaskTemp), "TryClearTaskTemp", (ThreadPriority)1);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "初始化加载池运行失败", ModBase.LogLevel.Feedback);
					ProjectData.ClearProjectError();
				}
				try
				{
					if (File.Exists(ModBase.ExePath + "PCL\\PCL Pro-N.exe"))
					{
						File.Delete(ModBase.ExePath + "PCL\\PCL Pro-N.exe");
					}
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, "清理自动更新文件失败");
					ProjectData.ClearProjectError();
				}
				ModBase.GetCoR();
				ModSecret.GetSystemInfo();
			}), "Start Loader", (ThreadPriority)0);
			ModBase.Log("[Start] 第三阶段加载用时：" + Conversions.ToString(TimeUtils.GetTimeTick() - ModBase.ApplicationStartTick) + " ms");
			if (ModMain.FrmDownloadMod == null)
			{
				ModMain.FrmDownloadMod = new PageDownloadMod();
			}
			ModMain.FrmDownloadMod.Content.PreloadStart();
		}
	}

	private void RunCountSub()
	{
	}

	private void UpgradeSub(int LastVersionCode)
	{
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Expected O, but got Unknown
		ModBase.Log("[Start] 版本号从 " + Conversions.ToString(LastVersionCode) + " 升高到 " + Conversions.ToString(413));
		ModBase.Setup.Set("SystemLastVersionReg", 413);
		int num = Conversions.ToInteger(ModBase.Setup.Get("SystemHighestAlphaVersionReg"));
		if (num < 413)
		{
			ModBase.Setup.Set("SystemHighestAlphaVersionReg", 413);
			ModBase.Log("[Start] 最高版本号从 " + Conversions.ToString(num) + " 升高到 " + Conversions.ToString(413));
		}
		if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("LaunchArgumentWindowType"), (object)5, false))
		{
			ModBase.Setup.Set("LaunchArgumentWindowType", 1);
		}
		if (num <= 207)
		{
			List<string> obj = new List<string>();
			obj.Add("2");
			List<string> val = obj;
			val.AddRange((System.Collections.Generic.IEnumerable<string>)new List<string>((System.Collections.Generic.IEnumerable<string>)ModBase.Setup.Get("UiLauncherThemeHide").ToString().Split("|", (StringSplitOptions)0)));
			val.AddRange((System.Collections.Generic.IEnumerable<string>)new List<string>((System.Collections.Generic.IEnumerable<string>)ModBase.Setup.Get("UiLauncherThemeHide2").ToString().Split("|", (StringSplitOptions)0)));
			ModBase.Setup.Set("UiLauncherThemeHide2", ModBase.Join((System.Collections.IEnumerable)Enumerable.ToList<string>(Enumerable.Distinct<string>((System.Collections.Generic.IEnumerable<string>)val)), "|"));
		}
		if (LastVersionCode <= 115 && Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)ModBase.Setup.Get("UiLauncherThemeHide2").ToString().Split("|", (StringSplitOptions)0), "13"))
		{
			List<string> val2 = new List<string>((System.Collections.Generic.IEnumerable<string>)ModBase.Setup.Get("UiLauncherThemeHide2").ToString().Split("|", (StringSplitOptions)0));
			val2.Remove("13");
			ModBase.Setup.Set("UiLauncherThemeHide2", ModBase.Join((System.Collections.IEnumerable)val2, "|"));
			ModMain.MyMsgBox("由于新版 PCL 修改了欧皇彩的解锁方式，你需要重新解锁欧皇彩。\r\n多谢各位的理解啦！", "重新解锁提醒");
		}
		if (LastVersionCode <= 152 && Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)ModBase.Setup.Get("UiLauncherThemeHide2").ToString().Split("|", (StringSplitOptions)0), "12"))
		{
			List<string> val3 = new List<string>((System.Collections.Generic.IEnumerable<string>)ModBase.Setup.Get("UiLauncherThemeHide2").ToString().Split("|", (StringSplitOptions)0));
			val3.Remove("12");
			ModBase.Setup.Set("UiLauncherThemeHide2", ModBase.Join((System.Collections.IEnumerable)val3, "|"));
			ModMain.MyMsgBox("由于新版 PCL 修改了滑稽彩的解锁方式，你需要重新解锁滑稽彩。\r\n多谢各位的理解啦！", "重新解锁提醒");
		}
		if (LastVersionCode <= 161 && File.Exists(ModBase.ExePath + "PCL\\CustomSkin.png") && !File.Exists(ModBase.PathAppdata + "CustomSkin.png"))
		{
			ModBase.CopyFile(ModBase.ExePath + "PCL\\CustomSkin.png", ModBase.PathAppdata + "CustomSkin.png");
			ModBase.Log("[Start] 已移动离线自定义皮肤 (162)");
		}
		if (LastVersionCode <= 263 && File.Exists(ModBase.PathTemp + "CustomSkin.png") && !File.Exists(ModBase.PathAppdata + "CustomSkin.png"))
		{
			ModBase.CopyFile(ModBase.PathTemp + "CustomSkin.png", ModBase.PathAppdata + "CustomSkin.png");
			ModBase.Log("[Start] 已移动离线自定义皮肤 (264)");
		}
		if (LastVersionCode <= 205)
		{
			ModBase.Setup.Set("UiHiddenOtherHelp", false);
			ModBase.Log("[Start] 已解除帮助页面的隐藏");
		}
		if (LastVersionCode <= 368)
		{
			object action;
			if (_Closure_0024__._0024I6_002D0 != null)
			{
				action = _Closure_0024__._0024I6_002D0;
			}
			else
			{
				Action val4 = [SpecialName] () =>
				{
					ModProfile.MigrateOldProfile();
				};
				_Closure_0024__._0024I6_002D0 = val4;
				action = (object)val4;
			}
			ModBase.RunInNewThread((Action)action, null, (ThreadPriority)2);
		}
		if (!ModBase.Setup.IsUnset("ToolDownloadTranslate") && ModBase.Setup.IsUnset("ToolDownloadTranslateV2"))
		{
			ModBase.Setup.Set("ToolDownloadTranslateV2", Operators.AddObject(ModBase.Setup.Get("ToolDownloadTranslate"), (object)1));
			ModBase.Log("[Start] 已从老版本迁移 Mod 命名设置");
		}
		if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiLauncherCEHint"))))
		{
			ModSecret.ShowCEAnnounce(IsUpdate: true);
		}
		if (LastVersionCode > 0 && num < 413)
		{
			ShowUpdateLog();
		}
	}

	private void DowngradeSub(int LastVersionCode)
	{
		ModBase.Log("[Start] 版本号从 " + Conversions.ToString(LastVersionCode) + " 降低到 " + Conversions.ToString(413));
		ModBase.Setup.Set("SystemLastVersionReg", 413);
	}

	protected override void OnSourceInitialized(EventArgs e)
	{
		if (Conversions.ToBoolean(ModBase.Setup.Get("SystemDisableHardwareAcceleration")))
		{
			PresentationSource obj = PresentationSource.FromVisual((Visual)(object)this);
			HwndSource val = (HwndSource)(object)((obj is HwndSource) ? obj : null);
			if (val != null)
			{
				val.CompositionTarget.RenderMode = (RenderMode)1;
			}
		}
		base.OnSourceInitialized(e);
	}

	private void FormMain_Closing(object sender, CancelEventArgs e)
	{
		EndProgram(SendWarning: true);
		e.Cancel = true;
	}

	public void EndProgram(bool SendWarning)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		if (SendWarning && ModNet.HasDownloadingTask())
		{
			if (ModMain.MyMsgBox("还有下载任务尚未完成，是否确定退出？", "提示", "确定", "取消") != 1)
			{
				return;
			}
			object action;
			if (_Closure_0024__._0024I10_002D0 != null)
			{
				action = _Closure_0024__._0024I10_002D0;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					//IL_001a: Unknown result type (might be due to invalid IL or missing references)
					//IL_001f: Unknown result type (might be due to invalid IL or missing references)
					ModBase.Log("[System] 正在强行停止任务");
					System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
					try
					{
						enumerator = ModLoader.LoaderTaskbar.ToList().GetEnumerator();
						while (enumerator.MoveNext())
						{
							enumerator.Current.Abort();
						}
					}
					finally
					{
						((System.IDisposable)enumerator).Dispose();
					}
				};
				_Closure_0024__._0024I10_002D0 = val;
				action = (object)val;
			}
			ModBase.RunInNewThread((Action)action, "强行停止下载任务", (ThreadPriority)2);
		}
		LobbyController.Close();
		ModProfile.SaveProfile();
		ModBase.RunInUiWait((Action)([SpecialName] [CompilerGenerated] () =>
		{
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Expected O, but got Unknown
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Expected O, but got Unknown
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Expected O, but got Unknown
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Expected O, but got Unknown
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_015e: Expected O, but got Unknown
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Expected O, but got Unknown
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Expected O, but got Unknown
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Expected O, but got Unknown
			VideoBack.Stop();
			VideoBack.Source = null;
			VideoBack.Close();
			((UIElement)this).IsHitTestVisible = false;
			if (((UIElement)PanBack).RenderTransform == null)
			{
				_Closure_0024__10_002D0 arg = default(_Closure_0024__10_002D0);
				_Closure_0024__10_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__10_002D0(null);
				CS_0024_003C_003E8__locals0._0024VB_0024Local_TransformPos = new TranslateTransform(0.0, 0.0);
				CS_0024_003C_003E8__locals0._0024VB_0024Local_TransformRotate = new RotateTransform(0.0);
				CS_0024_003C_003E8__locals0._0024VB_0024Local_TransformScale = new ScaleTransform(1.0, 1.0);
				Grid panBack = PanBack;
				TransformGroup val2 = new TransformGroup();
				val2.Children = new TransformCollection((System.Collections.Generic.IEnumerable<Transform>)(object)new Transform[3]
				{
					(Transform)CS_0024_003C_003E8__locals0._0024VB_0024Local_TransformRotate,
					(Transform)CS_0024_003C_003E8__locals0._0024VB_0024Local_TransformPos,
					(Transform)CS_0024_003C_003E8__locals0._0024VB_0024Local_TransformScale
				});
				((UIElement)panBack).RenderTransform = (Transform)(object)val2;
				ModAnimation.AniData[] obj = new ModAnimation.AniData[6]
				{
					ModAnimation.AaOpacity(this, 0.0 - ((UIElement)this).Opacity, 140, 40, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)),
					ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] (object i) =>
					{
						ScaleTransform _0024VB_0024Local_TransformScale;
						(_0024VB_0024Local_TransformScale = CS_0024_003C_003E8__locals0._0024VB_0024Local_TransformScale).ScaleX = Conversions.ToDouble(Operators.AddObject((object)_0024VB_0024Local_TransformScale.ScaleX, i));
						(_0024VB_0024Local_TransformScale = CS_0024_003C_003E8__locals0._0024VB_0024Local_TransformScale).ScaleY = Conversions.ToDouble(Operators.AddObject((object)_0024VB_0024Local_TransformScale.ScaleY, i));
					}), 0.88 - CS_0024_003C_003E8__locals0._0024VB_0024Local_TransformScale.ScaleX, 180),
					ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] (object i) =>
					{
						TranslateTransform _0024VB_0024Local_TransformPos;
						(_0024VB_0024Local_TransformPos = CS_0024_003C_003E8__locals0._0024VB_0024Local_TransformPos).Y = Conversions.ToDouble(Operators.AddObject((object)_0024VB_0024Local_TransformPos.Y, i));
					}), 20.0 - CS_0024_003C_003E8__locals0._0024VB_0024Local_TransformPos.Y, 180, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)),
					ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] (object i) =>
					{
						RotateTransform _0024VB_0024Local_TransformRotate;
						(_0024VB_0024Local_TransformRotate = CS_0024_003C_003E8__locals0._0024VB_0024Local_TransformRotate).Angle = Conversions.ToDouble(Operators.AddObject((object)_0024VB_0024Local_TransformRotate.Angle, i));
					}), 0.6 - CS_0024_003C_003E8__locals0._0024VB_0024Local_TransformRotate.Angle, 180, 0, new ModAnimation.AniEaseInoutFluent(ModAnimation.AniEasePower.Weak)),
					ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
					{
						((UIElement)this).IsHitTestVisible = false;
						((Window)this).Top = -10000.0;
						((Window)this).ShowInTaskbar = false;
					}), 210),
					default(ModAnimation.AniData)
				};
				object code;
				if (_Closure_0024__._0024I10_002D6 != null)
				{
					code = _Closure_0024__._0024I10_002D6;
				}
				else
				{
					ThreadStart val3 = [SpecialName] () =>
					{
						EndProgramForce(ModBase.ProcessReturnValues.Success, force: false);
					};
					_Closure_0024__._0024I10_002D6 = val3;
					code = (object)val3;
				}
				obj[5] = ModAnimation.AaCode((ThreadStart)code, 230);
				ModAnimation.AniStart((System.Collections.IList)(object)obj, "Form Close");
			}
			else
			{
				EndProgramForce(ModBase.ProcessReturnValues.Success, force: false);
			}
			ModBase.Log("[System] 收到关闭指令");
		}));
	}

	public static void EndProgramForce(ModBase.ProcessReturnValues ReturnCode = ModBase.ProcessReturnValues.Success, bool force = true)
	{
		LobbyController.Close();
		ModBase.IsProgramEnded = true;
		checked
		{
			ModAnimation.AniControlEnabled++;
			if (ModSecret.IsUpdateWaitingRestart)
			{
				ModSecret.UpdateRestart(TriggerRestartAndByEnd: false);
			}
			if (ReturnCode == ModBase.ProcessReturnValues.Exception)
			{
				if (!IsLogShown)
				{
					ModBase.FeedbackInfo();
					ModBase.Log("请在 https://github.com/PCLPro/PCLPro/issues 提交错误报告，以便于社区解决此问题！（这也有可能是原版 PCL 的问题）");
					IsLogShown = true;
					ModBase.ShellOnly(Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)LogWrapper.CurrentLogger.LogFiles));
				}
				Thread.Sleep(500);
			}
			ModBase.Log("[System] 程序已退出，返回值：" + ModBase.GetStringFromEnum(ReturnCode));
		}
		Lifecycle.Shutdown((int)ReturnCode, force);
	}

	private void BtnTitleClose_Click(object sender, RoutedEventArgs e)
	{
		EndProgram(SendWarning: true);
	}

	private void FormDragMove(object sender, MouseButtonEventArgs e)
	{
		if (Conversions.ToBoolean(NewLateBinding.LateGet(sender, (System.Type)null, "IsMouseDirectlyOver", new object[0], (string[])null, (System.Type[])null, (bool[])null)))
		{
			base.DragMove();
		}
	}

	private void FormMain_SizeChanged()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Invalid comparison between Unknown and I4
		if (IsSizeSaveable)
		{
			ModBase.Setup.Set("WindowHeight", ((FrameworkElement)this).Height);
			ModBase.Setup.Set("WindowWidth", ((FrameworkElement)this).Width);
		}
		RectForm.Rect = new Rect(0.0, 0.0, ((FrameworkElement)BorderForm).ActualWidth, ((FrameworkElement)BorderForm).ActualHeight);
		((FrameworkElement)PanForm).Width = ((FrameworkElement)BorderForm).ActualWidth + 0.001;
		((FrameworkElement)PanForm).Height = ((FrameworkElement)BorderForm).ActualHeight + 0.001;
		((FrameworkElement)PanMain).Width = ((FrameworkElement)PanForm).Width;
		((FrameworkElement)PanMain).Height = Math.Max(0.0, ((FrameworkElement)PanForm).Height - ((FrameworkElement)PanTitle).ActualHeight);
		((FrameworkElement)VideoBack).Width = ((FrameworkElement)PanForm).Width;
		((FrameworkElement)VideoBack).Height = ((FrameworkElement)PanForm).Height;
		if ((int)((Window)this).WindowState == 2)
		{
			((Window)this).WindowState = (WindowState)0;
		}
	}

	private void PanTitle_SizeChanged()
	{
		if (PanTitleMain.ColumnDefinitions[0].ActualWidth - 30.0 <= 0.0)
		{
			PanTitleLeft.ColumnDefinitions[0].MaxWidth = 0.0;
		}
		else
		{
			PanTitleLeft.ColumnDefinitions[0].MaxWidth = PanTitleMain.ColumnDefinitions[0].ActualWidth - 30.0;
		}
	}

	private void BtnTitleMin_Click()
	{
		((Window)this).WindowState = (WindowState)1;
	}

	public void AddResizer()
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		((Window)this).ResizeMode = (ResizeMode)2;
		object resizer = Resizer;
		object[] obj = new object[] { ResizerB };
		object[] array = obj;
		bool[] obj2 = new bool[] { true };
		bool[] array2 = obj2;
		NewLateBinding.LateCall(resizer, (System.Type)null, "addResizerDown", obj, (string[])null, (System.Type[])null, obj2, true);
		if (array2[0])
		{
			ResizerB = (Rectangle)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(Rectangle));
		}
		NewLateBinding.LateCall(Resizer, (System.Type)null, "addResizerLeft", array = new object[] { ResizerL }, (string[])null, (System.Type[])null, array2 = new bool[] { true }, true);
		if (array2[0])
		{
			ResizerL = (Rectangle)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(Rectangle));
		}
		NewLateBinding.LateCall(Resizer, (System.Type)null, "addResizerLeftDown", array = new object[] { ResizerLB }, (string[])null, (System.Type[])null, array2 = new bool[] { true }, true);
		if (array2[0])
		{
			ResizerLB = (Rectangle)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(Rectangle));
		}
		NewLateBinding.LateCall(Resizer, (System.Type)null, "addResizerLeftUp", array = new object[] { ResizerLT }, (string[])null, (System.Type[])null, array2 = new bool[] { true }, true);
		if (array2[0])
		{
			ResizerLT = (Rectangle)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(Rectangle));
		}
		NewLateBinding.LateCall(Resizer, (System.Type)null, "addResizerRight", array = new object[] { ResizerR }, (string[])null, (System.Type[])null, array2 = new bool[] { true }, true);
		if (array2[0])
		{
			ResizerR = (Rectangle)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(Rectangle));
		}
		NewLateBinding.LateCall(Resizer, (System.Type)null, "addResizerRightDown", array = new object[] { ResizerRB }, (string[])null, (System.Type[])null, array2 = new bool[] { true }, true);
		if (array2[0])
		{
			ResizerRB = (Rectangle)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(Rectangle));
		}
		NewLateBinding.LateCall(Resizer, (System.Type)null, "addResizerRightUp", array = new object[] { ResizerRT }, (string[])null, (System.Type[])null, array2 = new bool[] { true }, true);
		if (array2[0])
		{
			ResizerRT = (Rectangle)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(Rectangle));
		}
		NewLateBinding.LateCall(Resizer, (System.Type)null, "addResizerUp", array = new object[] { ResizerT }, (string[])null, (System.Type[])null, array2 = new bool[] { true }, true);
		if (array2[0])
		{
			ResizerT = (Rectangle)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(Rectangle));
		}
	}

	public void RemoveResizer()
	{
		((Window)this).ResizeMode = (ResizeMode)0;
		NewLateBinding.LateCall(Resizer, (System.Type)null, "removeAllResizers", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
	}

	private void FormMain_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Invalid comparison between Unknown and I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Invalid comparison between Unknown and I4
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Invalid comparison between Unknown and I4
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Invalid comparison between Unknown and I4
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Invalid comparison between Unknown and I4
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Invalid comparison between Unknown and I4
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Invalid comparison between Unknown and I4
		if (e.IsRepeat)
		{
			return;
		}
		if (((Panel)PanMsg).Children.Count > 0)
		{
			if ((int)e.Key == 6)
			{
				NewLateBinding.LateCall((object)((Panel)PanMsg).Children[0], (System.Type)null, "Btn1_Click", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
				return;
			}
			if ((int)e.Key == 13)
			{
				object obj = ((Panel)PanMsg).Children[0];
				if (!(obj is MyMsgInput) && !(obj is MyMsgSelect) && Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (System.Type)null, "Btn3", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Visibility", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)(Visibility)0, false))
				{
					NewLateBinding.LateCall(obj, (System.Type)null, "Btn3_Click", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
				}
				else if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (System.Type)null, "Btn2", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Visibility", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)(Visibility)0, false))
				{
					NewLateBinding.LateCall(obj, (System.Type)null, "Btn2_Click", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
				}
				else
				{
					NewLateBinding.LateCall(obj, (System.Type)null, "Btn1_Click", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
				}
				return;
			}
		}
		if ((int)e.Key == 13)
		{
			TriggerPageBack();
		}
		if ((int)e.Key == 100 && PageCurrent == PageType.InstanceSelect)
		{
			ModMain.FrmSelectRight.ShowHidden = !ModMain.FrmSelectRight.ShowHidden;
			ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
			return;
		}
		if ((int)e.Key == 101)
		{
			PageSetupUI.HiddenForceShow = !PageSetupUI.HiddenForceShow;
			if (PageSetupUI.HiddenForceShow)
			{
				ModMain.Hint("功能隐藏设置已暂时关闭！", ModMain.HintType.Finish);
			}
			else
			{
				ModMain.Hint("功能隐藏设置已重新开启！", ModMain.HintType.Finish);
			}
			PageSetupUI.HiddenRefresh();
			return;
		}
		if ((int)e.Key == 94)
		{
			if (PageLeft is IRefreshable)
			{
				((IRefreshable)PageLeft).Refresh();
			}
			if (PageRight is IRefreshable)
			{
				((IRefreshable)PageRight).Refresh();
			}
			return;
		}
		if ((int)e.Key == 6 && PageCurrent == PageType.Launch)
		{
			if (ModMain.IsAprilEnabled && !ModMain.IsAprilGiveup)
			{
				ModMain.Hint("木大！");
			}
			else
			{
				ModMain.FrmLaunchLeft.LaunchButtonClick();
			}
		}
		if ((int)e.SystemKey == 120 || (int)e.SystemKey == 121)
		{
			((RoutedEventArgs)e).Handled = true;
		}
	}

	private void FormMain_MouseDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Invalid comparison between Unknown and I4
		if (((Panel)ModMain.FrmMain.PanMsg).Children.Count <= 0 && !Enumerable.Any<ModMain.MyMsgBoxConverter>((System.Collections.Generic.IEnumerable<ModMain.MyMsgBoxConverter>)ModMain.WaitingMyMsgBox) && ((int)e.ChangedButton == 3 || (int)e.ChangedButton == 4))
		{
			TriggerPageBack();
		}
	}

	private void TriggerPageBack()
	{
		if (PageCurrent == PageType.Download && PageCurrentSub == PageSubType.DownloadInstall && ModMain.FrmDownloadInstall.IsInSelectPage)
		{
			ModMain.FrmDownloadInstall.ExitSelectPage();
		}
		else if (PageCurrent == PageType.InstanceSetup && PageCurrentSub == PageSubType.VersionInstall && ModMain.FrmInstanceInstall.IsInSelectPage)
		{
			ModMain.FrmInstanceInstall.ExitSelectPage();
		}
		else
		{
			PageBack();
		}
	}

	private void FormMain_Activated()
	{
		try
		{
			if (Conversions.ToBoolean(ModBase.Setup.Get("ToolDownloadClipboard")))
			{
				ModComp.CompClipboard.GetClipboardResource();
			}
			if (PageCurrent == PageType.InstanceSetup && PageCurrentSub == PageSubType.DownloadResourcePack)
			{
				ModMain.FrmInstanceMod.ReloadCompFileList();
			}
			else if (PageCurrent == PageType.InstanceSetup && PageCurrentSub == PageSubType.DownloadWorld)
			{
				if (ModMain.FrmInstanceResourcePack != null)
				{
					ModMain.FrmInstanceResourcePack.ReloadCompFileList();
				}
			}
			else if (PageCurrent == PageType.InstanceSetup && PageCurrentSub == PageSubType.DownloadSchematic)
			{
				if (ModMain.FrmInstanceShader != null)
				{
					ModMain.FrmInstanceShader.ReloadCompFileList();
				}
			}
			else if (PageCurrent == PageType.InstanceSetup && PageCurrentSub == PageSubType.DownloadCompFavorites)
			{
				if (ModMain.FrmInstanceSchematic != null)
				{
					ModMain.FrmInstanceSchematic.ReloadCompFileList();
				}
			}
			else if (PageCurrent == PageType.InstanceSelect)
			{
				ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.RunOnUpdated, 1, "versions\\");
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "切回窗口时出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void HandleDrag(object sender, DragEventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (((RoutedEventArgs)e).Handled && (int)e.Effects != 0)
			{
				return;
			}
			((RoutedEventArgs)e).Handled = true;
			if (e.Data == _0024STATIC_0024HandleDrag_002420211C1282E5_0024PrevData)
			{
				e.Effects = _0024STATIC_0024HandleDrag_002420211C1282E5_0024PrevEffects;
				return;
			}
			e.Effects = (DragDropEffects)0;
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				string str = Conversions.ToString(e.Data.GetData(DataFormats.Text));
				if (ModBase.StartsWithF(str, "authlib-injector:yggdrasil-server:"))
				{
					e.Effects = (DragDropEffects)1;
				}
				else if (ModBase.StartsWithF(str, "file:///"))
				{
					e.Effects = (DragDropEffects)1;
				}
			}
			else if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] array = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (array != null && array.Length > 0)
				{
					e.Effects = (DragDropEffects)4;
				}
			}
			_0024STATIC_0024HandleDrag_002420211C1282E5_0024PrevData = e.Data;
			_0024STATIC_0024HandleDrag_002420211C1282E5_0024PrevEffects = e.Effects;
			ModBase.Log("[System] 设置拖放类型：" + ModBase.GetStringFromEnum((System.Enum)(object)e.Effects));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "处理拖放时出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void FrmMain_Drop(object sender, DragEventArgs e)
	{
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		try
		{
			if (e.Data.GetDataPresent(DataFormats.Text))
			{
				try
				{
					string text = Conversions.ToString(e.Data.GetData(DataFormats.Text));
					ModBase.Log("[System] 接受文本拖拽：" + text);
					if (ModBase.StartsWithF(text, "authlib-injector:yggdrasil-server:"))
					{
						((RoutedEventArgs)e).Handled = true;
						e.Effects = (DragDropEffects)1;
						string text2 = WebUtility.UrlDecode(text.Substring("authlib-injector:yggdrasil-server:".Length));
						ModBase.Log("[System] Authlib 拖拽：" + text2);
						if (!string.IsNullOrEmpty(new ValidateHttp().ValidateText(text2)))
						{
							ModMain.Hint($"输入的 Authlib 验证服务器不符合网址格式（{text2}）！", ModMain.HintType.Critical);
						}
						else if (ModMain.MyMsgBox(string.Format("是否要创建新的第三方验证档案？{0}验证服务器地址：{1}", (object)"\r\n", (object)text2), "创建新的第三方验证档案", "确定", "取消") != 2)
						{
							ModProfile.SelectedProfile = null;
							ModBase.RunInUi((Action)([SpecialName] () =>
							{
								PageLoginAuth.DraggedAuthServer = text2;
								ModMain.FrmLaunchLeft.RefreshPage(Anim: true, ModLaunch.McLoginType.Auth);
							}));
							if (PageCurrent == PageType.InstanceSetup && PageCurrentSub == PageSubType.DownloadInstall)
							{
								ModMain.FrmInstanceSetup.Reload();
							}
						}
					}
					else if (ModBase.StartsWithF(text, "file:///"))
					{
						string text3 = WebUtility.UrlDecode(text).Substring("file:///".Length).Replace("/", "\\");
						((RoutedEventArgs)e).Handled = true;
						e.Effects = (DragDropEffects)1;
						List<string> obj = new List<string>();
						obj.Add(text3);
						FileDrag((System.Collections.Generic.IEnumerable<string>)obj);
					}
					return;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "无法接取文本拖拽事件", ModBase.LogLevel.Developer);
					ProjectData.ClearProjectError();
					return;
				}
			}
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				object objectValue = RuntimeHelpers.GetObjectValue(e.Data.GetData(DataFormats.FileDrop));
				if (objectValue == null)
				{
					ModMain.Hint("请将文件解压后再拖入！", ModMain.HintType.Critical);
					return;
				}
				((RoutedEventArgs)e).Handled = true;
				e.Effects = (DragDropEffects)4;
				FileDrag((System.Collections.Generic.IEnumerable<string>)objectValue);
			}
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			ModBase.Log(ex4, "接取拖拽事件失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void FileDrag(System.Collections.Generic.IEnumerable<string> FilePathList)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		ModBase.RunInNewThread((Action)([SpecialName] () =>
		{
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Expected O, but got Unknown
			//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c5: Expected O, but got Unknown
			//IL_05de: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e9: Expected O, but got Unknown
			//IL_0447: Unknown result type (might be due to invalid IL or missing references)
			//IL_044c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0452: Expected O, but got Unknown
			//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04df: Expected O, but got Unknown
			string text = Enumerable.First<string>(FilePathList);
			ModBase.Log("[System] 接受文件拖拽：" + text + (Enumerable.Any<string>(FilePathList) ? $" 等 {Enumerable.Count<string>(FilePathList)} 个文件" : ""), ModBase.LogLevel.Developer);
			if (Directory.Exists(Enumerable.First<string>(FilePathList)) && !File.Exists(Enumerable.First<string>(FilePathList)))
			{
				ModMain.Hint("请拖入一个文件，而非文件夹！", ModMain.HintType.Critical);
			}
			else if (!File.Exists(Enumerable.First<string>(FilePathList)))
			{
				ModMain.Hint("拖入的文件不存在：" + Enumerable.First<string>(FilePathList), ModMain.HintType.Critical);
			}
			else
			{
				if (Enumerable.Count<string>(FilePathList) > 1)
				{
					string text2 = ModBase.AfterLast(Enumerable.First<string>(FilePathList), ".").ToLower();
					if (!Enumerable.All<string>(FilePathList, (Func<string, bool>)([SpecialName] (string f) => Operators.CompareString(ModBase.AfterLast(f, ".").ToLower(), text2, false) == 0)) || !Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "jar", "litemod", "disabled", "old", "litematic", "nbt", "schematic", "schem" }, text2))
					{
						ModMain.Hint("一次请只拖入相同类型的文件！", ModMain.HintType.Critical);
						return;
					}
				}
				string text3 = ModBase.AfterLast(text, ".").ToLower();
				if (Operators.CompareString(text3, "xaml", false) == 0)
				{
					ModBase.Log("[System] 文件后缀为 XAML，作为主页加载");
					if (!File.Exists(ModBase.ExePath + "PCL\\Custom.xaml") || ModMain.MyMsgBox("已存在一个主页文件，是否要将它覆盖？", "覆盖确认", "覆盖", "取消") != 2)
					{
						ModBase.CopyFile(text, ModBase.ExePath + "PCL\\Custom.xaml");
						object action;
						if (_Closure_0024__._0024I28_002D2 != null)
						{
							action = _Closure_0024__._0024I28_002D2;
						}
						else
						{
							Action val = [SpecialName] () =>
							{
								ModBase.Setup.Set("UiCustomType", 1);
								ModMain.FrmLaunchRight.ForceRefresh();
								ModMain.Hint("已加载主页自定义文件！", ModMain.HintType.Finish);
							};
							_Closure_0024__._0024I28_002D2 = val;
							action = (object)val;
						}
						ModBase.RunInUi((Action)action);
					}
				}
				else if (!PageInstanceCompResource.InstallMods(FilePathList))
				{
					if (Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "litematic", "nbt", "schematic", "schem" }, text3))
					{
						ModBase.Log($"[System] 文件为 {text3} 格式，尝试作为原理图安装");
						string targetFolderPath = null;
						if (PageCurrent == PageType.InstanceSetup && PageCurrentSub == PageSubType.DownloadCompFavorites && ModMain.FrmInstanceSchematic != null && ModMain.FrmInstanceSchematic is PageInstanceCompResource)
						{
							targetFolderPath = ModMain.FrmInstanceSchematic.CurrentFolderPath;
						}
						PageInstanceCompResource.InstallCompFiles(FilePathList, ModComp.CompType.Schematic, targetFolderPath);
					}
					else
					{
						if (PageCurrent == PageType.InstanceSetup && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "zip" }, (Func<string, bool>)([SpecialName] (string i) => Operators.CompareString(i, text3, false) == 0)))
						{
							switch (PageCurrentSub)
							{
							case PageSubType.DownloadPack:
							{
								string text5 = PageInstanceLeft.Instance.PathIndie + "saves\\" + ModBase.GetFileNameWithoutExtentionFromPath(text);
								if (Directory.Exists(text5))
								{
									ModMain.Hint("发现同名文件夹，无法粘贴：" + text5, ModMain.HintType.Critical);
								}
								else
								{
									ModBase.ExtractFile(text, text5);
									ModMain.Hint($"已导入 {ModBase.GetFileNameWithoutExtentionFromPath(text)}", ModMain.HintType.Finish);
									if (ModMain.FrmInstanceSaves != null)
									{
										object action3;
										if (_Closure_0024__._0024I28_002D4 != null)
										{
											action3 = _Closure_0024__._0024I28_002D4;
										}
										else
										{
											Action val3 = [SpecialName] () =>
											{
												ModMain.FrmInstanceSaves.Reload();
											};
											_Closure_0024__._0024I28_002D4 = val3;
											action3 = (object)val3;
										}
										ModBase.RunInUi((Action)action3);
									}
								}
								return;
							}
							case PageSubType.DownloadWorld:
							{
								string text6 = PageInstanceLeft.Instance.PathIndie + "resourcepacks\\" + ModBase.GetFileNameFromPath(text);
								if (File.Exists(text6))
								{
									ModMain.Hint("已存在同名文件：" + text6, ModMain.HintType.Critical);
								}
								else
								{
									ModBase.CopyFile(text, text6);
									ModMain.Hint($"已导入 {ModBase.GetFileNameFromPath(text)}", ModMain.HintType.Finish);
									if (ModMain.FrmInstanceResourcePack != null)
									{
										object action4;
										if (_Closure_0024__._0024I28_002D5 != null)
										{
											action4 = _Closure_0024__._0024I28_002D5;
										}
										else
										{
											Action val4 = [SpecialName] () =>
											{
												ModMain.FrmInstanceResourcePack.ReloadCompFileList();
											};
											_Closure_0024__._0024I28_002D5 = val4;
											action4 = (object)val4;
										}
										ModBase.RunInUi((Action)action4);
									}
								}
								return;
							}
							case PageSubType.DownloadSchematic:
							{
								string text4 = PageInstanceLeft.Instance.PathIndie + "shaderpacks\\" + ModBase.GetFileNameFromPath(text);
								if (File.Exists(text4))
								{
									ModMain.Hint("已存在同名文件：" + text4, ModMain.HintType.Critical);
								}
								else
								{
									ModBase.CopyFile(text, text4);
									ModMain.Hint($"已导入 {ModBase.GetFileNameFromPath(text)}", ModMain.HintType.Finish);
									if (ModMain.FrmInstanceShader != null)
									{
										object action2;
										if (_Closure_0024__._0024I28_002D6 != null)
										{
											action2 = _Closure_0024__._0024I28_002D6;
										}
										else
										{
											Action val2 = [SpecialName] () =>
											{
												ModMain.FrmInstanceShader.ReloadCompFileList();
											};
											_Closure_0024__._0024I28_002D6 = val2;
											action2 = (object)val2;
										}
										ModBase.RunInUi((Action)action2);
									}
								}
								return;
							}
							}
						}
						if (PageCurrent == PageType.InstanceSetup && Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "litematic", "nbt", "schematic", "schem" }, text3) && PageCurrentSub == PageSubType.DownloadCompFavorites)
						{
							string text7 = PageInstanceLeft.Instance.PathIndie + "schematics\\" + ModBase.GetFileNameFromPath(text);
							if (File.Exists(text7))
							{
								ModMain.Hint("已存在同名文件：" + text7, ModMain.HintType.Critical);
							}
							else
							{
								Directory.CreateDirectory(PageInstanceLeft.Instance.PathIndie + "schematics\\");
								ModBase.CopyFile(text, text7);
								ModMain.Hint($"已导入 {ModBase.GetFileNameFromPath(text)}", ModMain.HintType.Finish);
								if (ModMain.FrmInstanceSchematic != null)
								{
									object action5;
									if (_Closure_0024__._0024I28_002D7 != null)
									{
										action5 = _Closure_0024__._0024I28_002D7;
									}
									else
									{
										Action val5 = [SpecialName] () =>
										{
											ModMain.FrmInstanceSchematic.ReloadCompFileList();
										};
										_Closure_0024__._0024I28_002D7 = val5;
										action5 = (object)val5;
									}
									ModBase.RunInUi((Action)action5);
								}
							}
						}
						else
						{
							if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "zip", "rar", "mrpack" }, (Func<string, bool>)([SpecialName] (string t) => Operators.CompareString(t, text3, false) == 0)))
							{
								ModBase.Log("[System] 文件为压缩包，尝试作为整合包安装");
								try
								{
									ModModpack.ModpackInstall(text);
									return;
								}
								catch (ModBase.CancelledException ex)
								{
									ProjectData.SetProjectError((System.Exception)ex);
									ModBase.CancelledException ex2 = ex;
									ProjectData.ClearProjectError();
									return;
								}
								catch (System.Exception ex3)
								{
									ProjectData.SetProjectError(ex3);
									System.Exception ex4 = ex3;
									ProjectData.ClearProjectError();
								}
							}
							if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "zip", "rar" }, (Func<string, bool>)([SpecialName] (string t) => Operators.CompareString(t, text3, false) == 0)))
							{
								ModBase.Log("[System] 文件为压缩包，尝试作为存档分析");
								try
								{
									ModWorld.ReadWorld(text);
									return;
								}
								catch (ModBase.CancelledException ex5)
								{
									ProjectData.SetProjectError((System.Exception)ex5);
									ModBase.CancelledException ex6 = ex5;
									ProjectData.ClearProjectError();
									return;
								}
								catch (System.Exception ex7)
								{
									ProjectData.SetProjectError(ex7);
									System.Exception ex8 = ex7;
									ProjectData.ClearProjectError();
								}
							}
							try
							{
								ModBase.Log("[System] 尝试进行错误报告分析");
								CrashAnalyzer crashAnalyzer = new CrashAnalyzer(ModBase.GetUuid());
								crashAnalyzer.Import(text);
								if (crashAnalyzer.Prepare())
								{
									crashAnalyzer.Analyze();
									crashAnalyzer.Output(IsHandAnalyze: true, new List<string>());
									return;
								}
							}
							catch (System.Exception ex9)
							{
								ProjectData.SetProjectError(ex9);
								System.Exception ex10 = ex9;
								ModBase.Log(ex10, "自主错误报告分析失败", ModBase.LogLevel.Feedback);
								ProjectData.ClearProjectError();
							}
							ModMain.Hint("PCL 无法确定应当执行的文件拖拽操作……");
						}
					}
				}
			}
		}), "文件拖拽", (ThreadPriority)2);
	}

	private nint WndProc(nint hwnd, int msg, nint wParam, nint lParam, ref bool handled)
	{
		switch (msg)
		{
		case 30:
		{
			System.DateTime now = System.DateTime.Now;
			if (System.DateTime.Compare(now.Date, ModBase.ApplicationOpenTime.Date) == 0)
			{
				ModBase.Log("[System] 系统时间微调为：" + now.ToLongDateString() + " " + now.ToLongTimeString());
				IsSystemTimeChanged = false;
			}
			else
			{
				ModBase.Log("[System] 系统时间修改为：" + now.ToLongDateString() + " " + now.ToLongTimeString());
				IsSystemTimeChanged = true;
			}
			break;
		}
		case 6402:
			ModBase.Log("[System] 收到置顶信息：" + Conversions.ToString(((System.IntPtr)hwnd).ToInt64()));
			if (!IsWindowLoadFinished)
			{
				ModBase.Log("[System] 窗口尚未加载完成，忽略置顶请求");
				return System.IntPtr.Zero;
			}
			ShowWindowToTop();
			handled = true;
			break;
		case 26:
			if (Operators.CompareString(Marshal.PtrToStringAuto((System.IntPtr)lParam), "ImmersiveColorSet", false) == 0)
			{
				ModBase.Log($"[System] 系统主题更改，深色模式：{SystemTheme.IsSystemInDarkMode()}");
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(ModBase.Setup.Get("UiDarkMode"), (object)2, false), (object)(ModSecret.IsDarkMode != SystemTheme.IsSystemInDarkMode()))))
				{
					ModSecret.IsDarkMode = SystemTheme.IsSystemInDarkMode();
					ModSecret.ThemeRefresh();
				}
			}
			break;
		}
		return System.IntPtr.Zero;
	}

	protected override void OnActivated(EventArgs e)
	{
		base.OnActivated(e);
		if (Hidden)
		{
			Hidden = false;
		}
	}

	public void ShowWindowToTop()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			((UIElement)this).Visibility = (Visibility)0;
			((Window)this).ShowInTaskbar = true;
			((Window)this).WindowState = (WindowState)0;
			Hidden = false;
			((Window)this).Topmost = true;
			((Window)this).Topmost = false;
			ModMain.SetForegroundWindow(ModBase.FrmHandle);
			base.Focus();
			ModBase.Log(string.Format("[System] 窗口已置顶，位置：({0}, {1}), {2} x {3}", new object[4]
			{
				((Window)this).Left,
				((Window)this).Top,
				((FrameworkElement)this).Width,
				((FrameworkElement)this).Height
			}));
		}));
	}

	private void VideoEnded(object sender, RoutedEventArgs e)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		VideoBack.Position = TimeSpan.Zero;
		VideoBack.Play();
	}

	private void WindowStateChanged(object sender, EventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		WindowState windowState = ((Window)this).WindowState;
		if ((int)windowState != 0)
		{
			if ((int)windowState == 1)
			{
				ModVideoBack.IsMinimized = true;
				ModVideoBack.VideoPause();
			}
		}
		else
		{
			ModVideoBack.IsMinimized = false;
			ModVideoBack.VideoPlay();
		}
	}

	private string PageNameGet(PageStackData Stack)
	{
		return Stack.Page switch
		{
			PageType.InstanceSelect => "实例选择", 
			PageType.TaskManager => "任务管理", 
			PageType.GameLog => "实时日志", 
			PageType.InstanceSetup => "实例设置 - " + (((object)PageInstanceLeft.Instance == null) ? "未知实例" : PageInstanceLeft.Instance.Name), 
			PageType.CompDetail => "资源下载 - " + ((ModComp.CompProject)NewLateBinding.LateIndexGet(Stack.Additional, new object[] { 0 }, (string[])null)).TranslatedName, 
			PageType.HelpDetail => ((ModMain.HelpEntry)NewLateBinding.LateIndexGet(Stack.Additional, new object[] { 0 }, (string[])null)).Title, 
			PageType.SetupJava => "Java 管理", 
			PageType.VersionSaves => $"存档管理 - {ModBase.GetFolderNameFromPath(Conversions.ToString(Stack.Additional))}", 
			PageType.HomePageMarket => "主页市场", 
			_ => "", 
		};
	}

	public void PageNameRefresh(PageStackData Type)
	{
		LabTitleInner.Text = PageNameGet(Type);
	}

	public void PageNameRefresh()
	{
		PageNameRefresh(PageCurrent);
	}

	public void PageChange(PageStackData Stack, PageSubType SubType = PageSubType.Default)
	{
		if (Operators.CompareString(PageNameGet(Stack), "", false) == 0)
		{
			PageChangeExit();
			IsChangingPage = true;
			((MyRadioButton)(object)((Panel)PanTitleSelect).Children[(int)(PageType)Stack]).SetChecked(value: true, user: true, Operators.CompareString(PageNameGet(PageCurrent), "", false) == 0);
			IsChangingPage = false;
			switch (Stack.Page)
			{
			case PageType.Download:
				if (ModMain.FrmDownloadLeft == null)
				{
					ModMain.FrmDownloadLeft = new PageDownloadLeft();
				}
				foreach (object child in ((Panel)ModMain.FrmDownloadLeft.PanItem).Children)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(child);
					if (objectValue.GetType() == typeof(MyListItem) && ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue, (System.Type)null, "tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))) == (double)SubType)
					{
						((MyListItem)objectValue).SetChecked(value: true, user: true, Stack == PageCurrent);
						break;
					}
				}
				break;
			case PageType.Setup:
				if (ModMain.FrmSetupLeft == null)
				{
					ModMain.FrmSetupLeft = new PageSetupLeft();
				}
				((MyListItem)(object)((Panel)ModMain.FrmSetupLeft.PanItem).Children[(int)SubType]).SetChecked(value: true, user: true, Stack == PageCurrent);
				break;
			case PageType.Other:
				if (ModMain.FrmOtherLeft == null)
				{
					ModMain.FrmOtherLeft = new PageOtherLeft();
				}
				((MyListItem)(object)((Panel)ModMain.FrmOtherLeft.PanItem).Children[(int)SubType]).SetChecked(value: true, user: true, Stack == PageCurrent);
				break;
			}
			PageChangeActual(Stack, SubType);
			return;
		}
		switch (Stack.Page)
		{
		case PageType.InstanceSetup:
			if (ModMain.FrmInstanceLeft == null)
			{
				ModMain.FrmInstanceLeft = new PageInstanceLeft();
			}
			foreach (object child2 in ((Panel)ModMain.FrmInstanceLeft.PanItem).Children)
			{
				object objectValue3 = RuntimeHelpers.GetObjectValue(child2);
				if (objectValue3.GetType() == typeof(MyListItem) && ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue3, (System.Type)null, "tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))) == (double)SubType)
				{
					((MyListItem)objectValue3).SetChecked(value: true, user: true, Stack == PageCurrent);
					break;
				}
			}
			break;
		case PageType.VersionSaves:
			if (ModMain.FrmInstanceSavesLeft == null)
			{
				ModMain.FrmInstanceSavesLeft = new PageInstanceSavesLeft();
			}
			foreach (object child3 in ((Panel)ModMain.FrmInstanceSavesLeft.PanItem).Children)
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(child3);
				if (objectValue2.GetType() == typeof(MyListItem) && ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, (System.Type)null, "tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))) == (double)SubType)
				{
					((MyListItem)objectValue2).SetChecked(value: true, user: true, Stack == PageCurrent);
					break;
				}
			}
			break;
		}
		PageChangeActual(Stack, SubType);
	}

	private void BtnTitleSelect_Click(MyRadioButton sender, bool raiseByMouse)
	{
		if (!IsChangingPage)
		{
			PageChangeActual((PageType)checked((int)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(((FrameworkElement)sender).Tag)))));
		}
	}

	public void PageBack()
	{
		if (Enumerable.Any<PageStackData>((System.Collections.Generic.IEnumerable<PageStackData>)PageStack))
		{
			PageChangeActual(PageStack[0]);
		}
		else
		{
			PageChange(PageType.Launch);
		}
	}

	private void PageChangeActual(PageStackData Stack, PageSubType SubType = (PageSubType)(-1))
	{
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Expected O, but got Unknown
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		//IL_03b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Expected O, but got Unknown
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Expected O, but got Unknown
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Expected O, but got Unknown
		if (PageCurrent == Stack && (PageCurrentSub == SubType || SubType == (PageSubType)(-1)))
		{
			return;
		}
		checked
		{
			ModAnimation.AniControlEnabled++;
		}
		try
		{
			_Closure_0024__56_002D0 arg = default(_Closure_0024__56_002D0);
			_Closure_0024__56_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__56_002D0(null);
			CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_PageName = PageNameGet(Stack);
			if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_PageName, "", false) == 0)
			{
				PageChangeExit();
			}
			else if (Enumerable.Any<PageStackData>((System.Collections.Generic.IEnumerable<PageStackData>)PageStack))
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
				{
					ModAnimation.AaOpacity(LabTitleInner, 0.0 - ((UIElement)LabTitleInner).Opacity, 130),
					ModAnimation.AaCode((ThreadStart)([SpecialName] () =>
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Me.LabTitleInner.Text = CS_0024_003C_003E8__locals0._0024VB_0024Local_PageName;
					}), 0, After: true),
					ModAnimation.AaOpacity(LabTitleInner, 1.0, 150, 30)
				}, "FrmMain Titlebar SubLayer");
				if (PageStack.Contains(Stack))
				{
					while (PageStack.Contains(Stack))
					{
						PageStack.RemoveAt(0);
					}
				}
				else
				{
					PageStack.Insert(0, PageCurrent);
				}
			}
			else
			{
				((UIElement)PanTitleInner).Visibility = (Visibility)0;
				((UIElement)PanTitleMain).IsHitTestVisible = false;
				((UIElement)PanTitleInner).IsHitTestVisible = true;
				PageNameRefresh(Stack);
				ModAnimation.AniData[] obj = new ModAnimation.AniData[5]
				{
					ModAnimation.AaOpacity(PanTitleMain, 0.0 - ((UIElement)PanTitleMain).Opacity, 150),
					default(ModAnimation.AniData),
					default(ModAnimation.AniData),
					default(ModAnimation.AniData),
					default(ModAnimation.AniData)
				};
				Grid panTitleMain = PanTitleMain;
				Thickness margin = ((FrameworkElement)PanTitleMain).Margin;
				obj[1] = ModAnimation.AaX(panTitleMain, 12.0 - margin.Left, 150, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak));
				obj[2] = ModAnimation.AaOpacity(PanTitleInner, 1.0 - ((UIElement)PanTitleInner).Opacity, 150, 200);
				Grid panTitleInner = PanTitleInner;
				margin = ((FrameworkElement)PanTitleInner).Margin;
				obj[3] = ModAnimation.AaX(panTitleInner, 0.0 - margin.Left, 350, 200, new ModAnimation.AniEaseOutBack());
				obj[4] = ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
				{
					((UIElement)PanTitleMain).Visibility = (Visibility)2;
				}), 0, After: true);
				ModAnimation.AniStart((System.Collections.IList)(object)obj, "FrmMain Titlebar FirstLayer");
				PageStack.Insert(0, PageCurrent);
			}
			PageLast = PageCurrent;
			PageCurrent = Stack;
			switch (Stack.Page)
			{
			case PageType.Launch:
				PageChangeAnim((FrameworkElement)(object)ModMain.FrmLaunchLeft, (FrameworkElement)(object)ModMain.FrmLaunchRight);
				break;
			case PageType.Download:
				if (ModMain.FrmDownloadLeft == null)
				{
					ModMain.FrmDownloadLeft = new PageDownloadLeft();
				}
				PageChangeAnim((FrameworkElement)(object)ModMain.FrmDownloadLeft, (FrameworkElement)ModMain.FrmDownloadLeft.PageGet(SubType));
				break;
			case PageType.Link:
				if (ModMain.FrmLink == null)
				{
					ModMain.FrmLink = new PageLink();
				}
				PageChangeAnim((FrameworkElement)(object)ModMain.FrmLink, (FrameworkElement)ModMain.FrmLink.PageGet(SubType));
				break;
			case PageType.Setup:
				if (ModMain.FrmSetupLeft == null)
				{
					ModMain.FrmSetupLeft = new PageSetupLeft();
				}
				PageChangeAnim((FrameworkElement)(object)ModMain.FrmSetupLeft, (FrameworkElement)ModMain.FrmSetupLeft.PageGet(SubType));
				break;
			case PageType.SetupJava:
				ModMain.FrmSetupJava = ModMain.FrmSetupJava ?? new PageSetupJava();
				PageChangeAnim((FrameworkElement)(object)new MyPageLeft(), (FrameworkElement)(object)ModMain.FrmSetupJava);
				break;
			case PageType.Other:
				if (ModMain.FrmOtherLeft == null)
				{
					ModMain.FrmOtherLeft = new PageOtherLeft();
				}
				PageChangeAnim((FrameworkElement)(object)ModMain.FrmOtherLeft, (FrameworkElement)ModMain.FrmOtherLeft.PageGet(SubType));
				break;
			case PageType.GameLog:
				if (ModMain.FrmLogLeft == null)
				{
					ModMain.FrmLogLeft = new PageLogLeft();
				}
				if (ModMain.FrmLogLeft == null)
				{
					ModMain.FrmLogRight = new PageLogRight();
				}
				PageChangeAnim((FrameworkElement)(object)ModMain.FrmLogLeft, (FrameworkElement)(object)ModMain.FrmLogRight);
				break;
			case PageType.InstanceSelect:
				if (ModMain.FrmSelectLeft == null)
				{
					ModMain.FrmSelectLeft = new PageSelectLeft();
				}
				if (ModMain.FrmSelectRight == null)
				{
					ModMain.FrmSelectRight = new PageSelectRight();
				}
				PageChangeAnim((FrameworkElement)(object)ModMain.FrmSelectLeft, (FrameworkElement)(object)ModMain.FrmSelectRight);
				break;
			case PageType.TaskManager:
				if (ModMain.FrmSpeedLeft == null)
				{
					ModMain.FrmSpeedLeft = new PageSpeedLeft();
				}
				if (ModMain.FrmSpeedRight == null)
				{
					ModMain.FrmSpeedRight = new PageSpeedRight();
				}
				PageChangeAnim((FrameworkElement)(object)ModMain.FrmSpeedLeft, (FrameworkElement)(object)ModMain.FrmSpeedRight);
				break;
			case PageType.InstanceSetup:
				if (ModMain.FrmInstanceLeft == null)
				{
					ModMain.FrmInstanceLeft = new PageInstanceLeft();
				}
				PageChangeAnim((FrameworkElement)(object)ModMain.FrmInstanceLeft, (FrameworkElement)ModMain.FrmInstanceLeft.PageGet(SubType));
				break;
			case PageType.CompDetail:
				if (ModMain.FrmDownloadCompDetail == null)
				{
					ModMain.FrmDownloadCompDetail = new PageDownloadCompDetail();
				}
				PageChangeAnim((FrameworkElement)(object)new MyPageLeft(), (FrameworkElement)(object)ModMain.FrmDownloadCompDetail);
				break;
			case PageType.HelpDetail:
				PageChangeAnim((FrameworkElement)(object)new MyPageLeft(), (FrameworkElement)NewLateBinding.LateIndexGet(Stack.Additional, new object[] { 1 }, (string[])null));
				break;
			case PageType.VersionSaves:
				if (ModMain.FrmInstanceSavesLeft == null)
				{
					ModMain.FrmInstanceSavesLeft = new PageInstanceSavesLeft();
				}
				PageInstanceSavesLeft.CurrentSave = Conversions.ToString(Stack.Additional);
				PageChangeAnim((FrameworkElement)(object)ModMain.FrmInstanceSavesLeft, (FrameworkElement)ModMain.FrmInstanceSavesLeft.PageGet(SubType));
				break;
			case PageType.HomePageMarket:
				ModMain.FrmHomePageMarket = ModMain.FrmHomePageMarket ?? new PageHomepageMarket();
				PageChangeAnim((FrameworkElement)(object)new MyPageLeft(), (FrameworkElement)(object)ModMain.FrmHomePageMarket);
				break;
			}
			BtnExtraDownload.ShowRefresh();
			BtnExtraApril.ShowRefresh();
			ModBase.Log("[Control] 切换主要页面：" + ModBase.GetStringFromEnum((PageType)Stack) + ", " + Conversions.ToString((int)SubType));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "切换主要页面失败（ID " + Conversions.ToString((int)PageCurrent.Page) + "）", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
		finally
		{
			checked
			{
				ModAnimation.AniControlEnabled--;
			}
		}
	}

	/// <summary>
	/// PCL 原生 WPF bug 修复：页面切换动画中直接执行 Decorator.set_Child 时，
	/// WPF 内部 ChangeLogicalParent → OnInitialized → UpdateStyleProperty → GetRawValue
	/// 可能因"旧子元素未完全卸载就挂载新元素"触发 NullReferenceException，
	/// 并连锁导致布局阶段 Grid.MeasureCellsGroup 崩溃。
	/// 策略：① 先完整卸载旧子元素，再挂载新元素；② 非 UI 线程自动封送；
	/// ③ 异常时延迟到布局空闲重试，保证页面切换永不崩溃。
	/// </summary>
	private static void SafeSetPageChild(System.Windows.Controls.Decorator decorator, System.Windows.UIElement child)
	{
		if (decorator == null) return;
		try
		{
			if (!decorator.Dispatcher.CheckAccess())
			{
				decorator.Dispatcher.Invoke(new Action(() => SafeSetPageChild(decorator, child)));
				return;
			}
			if (ReferenceEquals(decorator.Child, child)) return;
			if (decorator.Child != null)
			{
				// 关键：先完整卸载旧子元素（同步触发一次完整布局失效），
				// 避免 WPF 在"移除旧 + 添加新"合并操作中逻辑树状态交错。
				decorator.Child = null;
			}
			decorator.Child = child;
		}
		catch (Exception)
		{
			// 兜底：延迟到布局空闲时重试挂载，页面切换永不因布局崩溃
			try
			{
				decorator.Dispatcher.BeginInvoke(new Action(() =>
				{
					try
					{
						if (!ReferenceEquals(decorator.Child, child)) decorator.Child = child;
					}
					catch (Exception)
					{
					}
				}), System.Windows.Threading.DispatcherPriority.Loaded);
			}
			catch (Exception)
			{
			}
		}
	}

	private void PageChangeAnim(FrameworkElement TargetLeft, FrameworkElement TargetRight)
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Expected O, but got Unknown
		ModAnimation.AniStop("FrmMain LeftChange");
		ModAnimation.AniStop("PageLeft PageChange");
		checked
		{
			ModAnimation.AniControlEnabled++;
			if (!Information.IsNothing((object)TargetLeft.Parent))
			{
				((DependencyObject)TargetLeft).SetValue(ContentPresenter.ContentProperty, (object)null);
			}
			if (!Information.IsNothing((object)TargetRight) && !Information.IsNothing((object)TargetRight.Parent))
			{
				((DependencyObject)TargetRight).SetValue(ContentPresenter.ContentProperty, (object)null);
			}
			PageLeft = (MyPageLeft)(object)TargetLeft;
			PageRight = (MyPageRight)(object)TargetRight;
			((MyPageLeft)(object)((Decorator)PanMainLeft).Child).TriggerHideAnimation();
			((MyPageRight)(object)((Decorator)PanMainRight).Child).PageOnExit();
			ModAnimation.AniControlEnabled--;
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
			{
				ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
				{
					//IL_0050: Unknown result type (might be due to invalid IL or missing references)
					//IL_005b: Expected O, but got Unknown
					ModAnimation.AniControlEnabled++;
					SafeSetPageChild((Decorator)PanMainLeft, (UIElement)(object)PageLeft);
					((UIElement)PageLeft).Opacity = 0.0;
					PanMainLeft.Background = null;
					ModAnimation.AniControlEnabled--;
					ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
					{
						PanMainLeft_Resize(((FrameworkElement)PanMainLeft).ActualWidth);
					}), ForceWaitUntilLoaded: true);
				}), 110),
				ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
				{
					((UIElement)PageLeft).Opacity = 1.0;
					PageLeft.TriggerShowAnimation();
				}), 30, After: true)
			}, "FrmMain PageChangeLeft");
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
			{
				ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
				{
					//IL_0065: Unknown result type (might be due to invalid IL or missing references)
					//IL_0070: Expected O, but got Unknown
					ModAnimation.AniControlEnabled++;
					((MyPageRight)(object)((Decorator)PanMainRight).Child).PageOnForceExit();
					SafeSetPageChild((Decorator)PanMainRight, (UIElement)(object)PageRight);
					((UIElement)PageRight).Opacity = 0.0;
					PanMainRight.Background = null;
					ModAnimation.AniControlEnabled--;
					ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
					{
						BtnExtraBack.ShowRefresh();
					}), ForceWaitUntilLoaded: true);
				}), 110),
				ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
				{
					((UIElement)PageRight).Opacity = 1.0;
					PageRight.PageOnEnter();
				}), 30, After: true)
			}, "FrmMain PageChangeRight");
		}
	}

	private void PageChangeExit()
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		if (Enumerable.Any<PageStackData>((System.Collections.Generic.IEnumerable<PageStackData>)PageStack))
		{
			((UIElement)PanTitleMain).Visibility = (Visibility)0;
			((UIElement)PanTitleMain).IsHitTestVisible = true;
			((UIElement)PanTitleInner).IsHitTestVisible = false;
			ModAnimation.AniData[] obj = new ModAnimation.AniData[5]
			{
				ModAnimation.AaOpacity(PanTitleInner, 0.0 - ((UIElement)PanTitleInner).Opacity, 150),
				default(ModAnimation.AniData),
				default(ModAnimation.AniData),
				default(ModAnimation.AniData),
				default(ModAnimation.AniData)
			};
			Grid panTitleInner = PanTitleInner;
			Thickness margin = ((FrameworkElement)PanTitleInner).Margin;
			obj[1] = ModAnimation.AaX(panTitleInner, -18.0 - margin.Left, 150, 0, new ModAnimation.AniEaseInFluent());
			obj[2] = ModAnimation.AaOpacity(PanTitleMain, 1.0 - ((UIElement)PanTitleMain).Opacity, 150, 200);
			Grid panTitleMain = PanTitleMain;
			margin = ((FrameworkElement)PanTitleMain).Margin;
			obj[3] = ModAnimation.AaX(panTitleMain, 0.0 - margin.Left, 350, 200, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak));
			obj[4] = ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
			{
				((UIElement)PanTitleInner).Visibility = (Visibility)2;
			}), 0, After: true);
			ModAnimation.AniStart((System.Collections.IList)(object)obj, "FrmMain Titlebar FirstLayer");
			PageStack.Clear();
		}
	}

	private void PanMainLeft_SizeChanged(object sender, SizeChangedEventArgs e)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		if (e.WidthChanged)
		{
			Size newSize = e.NewSize;
			PanMainLeft_Resize(newSize.Width);
		}
	}

	private void PanMainLeft_Resize(double NewWidth)
	{
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		if (Math.Abs(NewWidth - ((FrameworkElement)RectLeftBackground).Width) > 0.1 && ModAnimation.AniControlEnabled == 0)
		{
			if (((UIElement)PanMain).Opacity < 0.1)
			{
				((UIElement)PanMainLeft).IsHitTestVisible = false;
			}
			if (NewWidth > 0.0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
				{
					ModAnimation.AaWidth(RectLeftBackground, NewWidth - ((FrameworkElement)RectLeftBackground).Width, 180, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.ExtraStrong)),
					ModAnimation.AaOpacity(RectLeftShadow, 1.0 - ((UIElement)RectLeftShadow).Opacity, 180),
					ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
					{
						((UIElement)PanMainLeft).IsHitTestVisible = true;
					}), 150)
				}, "FrmMain LeftChange", RefreshTime: true);
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
				{
					ModAnimation.AaWidth(RectLeftBackground, 0.0 - ((FrameworkElement)RectLeftBackground).Width, 180, 0, new ModAnimation.AniEaseOutFluent()),
					ModAnimation.AaOpacity(RectLeftShadow, 0.0 - ((UIElement)RectLeftShadow).Opacity, 180),
					ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
					{
						((UIElement)PanMainLeft).IsHitTestVisible = true;
					}), 150)
				}, "FrmMain LeftChange", RefreshTime: true);
			}
		}
		else
		{
			((FrameworkElement)RectLeftBackground).Width = NewWidth;
			((UIElement)PanMainLeft).IsHitTestVisible = true;
			ModAnimation.AniStop("FrmMain LeftChange");
		}
	}

	public void DragTick()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		if (ModMain.DragControl != null && (int)Mouse.LeftButton != 1)
		{
			DragStop();
		}
	}

	public void DragDoing()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		if (ModMain.DragControl != null)
		{
			if ((int)Mouse.LeftButton == 1)
			{
				NewLateBinding.LateCall(ModMain.DragControl, (System.Type)null, "DragDoing", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
			}
			else
			{
				DragStop();
			}
		}
	}

	public void DragStop()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I63_002D0 != null)
		{
			action = _Closure_0024__._0024I63_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				if (ModMain.DragControl != null)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(ModMain.DragControl);
					ModMain.DragControl = null;
					NewLateBinding.LateCall(objectValue, (System.Type)null, "DragStop", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
				}
			};
			_Closure_0024__._0024I63_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
	}

	private void BtnExtraMusic_Click(object sender, EventArgs e)
	{
		ModMusic.MusicControlPause();
	}

	private void BtnExtraMusic_RightClick(object sender, EventArgs e)
	{
		ModMusic.MusicControlNext();
	}

	private void BtnExtraDownload_Click(object sender, EventArgs e)
	{
		PageChange(PageType.TaskManager);
	}

	private bool BtnExtraDownload_ShowCheck()
	{
		if (ModNet.HasDownloadingTask())
		{
			return !(PageCurrent == PageType.TaskManager);
		}
		return false;
	}

	public void AprilGiveup()
	{
		if (ModMain.IsAprilEnabled && !ModMain.IsAprilGiveup)
		{
			ModMain.Hint("=D", ModMain.HintType.Finish);
			ModMain.IsAprilGiveup = true;
			ModMain.FrmLaunchLeft.AprilScaleTrans.ScaleX = 1.0;
			ModMain.FrmLaunchLeft.AprilScaleTrans.ScaleY = 1.0;
			BtnExtraApril.ShowRefresh();
		}
	}

	public bool BtnExtraApril_ShowCheck()
	{
		if (ModMain.IsAprilEnabled && !ModMain.IsAprilGiveup)
		{
			return PageCurrent == PageType.Launch;
		}
		return false;
	}

	public void BtnExtraShutdown_Click()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (ModLaunch.McLaunchLoaderReal != null)
			{
				ModLaunch.McLaunchLoaderReal.Abort();
			}
			System.Collections.Generic.IEnumerator<ModWatcher.Watcher> enumerator = default(System.Collections.Generic.IEnumerator<ModWatcher.Watcher>);
			try
			{
				enumerator = ModWatcher.McWatcherList.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.Kill();
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			ModMain.Hint("已关闭运行中的 Minecraft！", ModMain.HintType.Finish);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "强制关闭所有 Minecraft 失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public bool BtnExtraShutdown_ShowCheck()
	{
		return ModWatcher.HasRunningMinecraft;
	}

	public void BtnExtraLog_Click()
	{
		PageChange(PageType.GameLog);
	}

	public bool BtnExtraLog_ShowCheck()
	{
		if (ModMain.FrmLogLeft == null || ModMain.FrmLogRight == null || PageCurrent == PageType.GameLog)
		{
			return false;
		}
		return ModMain.FrmLogLeft.ShownLogs.Count > 0;
	}

	public void BackToTop()
	{
		MyScrollViewer myScrollViewer = BtnExtraBack_GetRealChild();
		if (myScrollViewer != null)
		{
			myScrollViewer.PerformVerticalOffsetDelta(0.0 - ((ScrollViewer)myScrollViewer).VerticalOffset);
		}
		else
		{
			ModBase.Log("[UI] 无法返回顶部，未找到合适的 RealScroll", ModBase.LogLevel.Hint);
		}
	}

	private bool BtnExtraBack_ShowCheck()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		MyScrollViewer myScrollViewer = BtnExtraBack_GetRealChild();
		if (myScrollViewer != null && (int)((UIElement)myScrollViewer).Visibility == 0)
		{
			return ((ScrollViewer)myScrollViewer).VerticalOffset > ((FrameworkElement)this).Height + (double)((!BtnExtraBack.Show) ? 700 : 0);
		}
		return false;
	}

	private MyScrollViewer BtnExtraBack_GetRealChild()
	{
		if (((Decorator)PanMainRight).Child == null || !(((Decorator)PanMainRight).Child is MyPageRight))
		{
			return null;
		}
		return ((MyPageRight)(object)((Decorator)PanMainRight).Child).PanScroll;
	}

	private void FormMain_MouseMove(object sender, MouseEventArgs e)
	{
		lastMouseArg = e;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/formmain.xaml", (UriKind)2);
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
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Expected O, but got Unknown
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected O, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Expected O, but got Unknown
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected O, but got Unknown
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Expected O, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Expected O, but got Unknown
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Expected O, but got Unknown
		//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Expected O, but got Unknown
		//IL_030a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			WindMain = (FormMain)target;
			break;
		case 2:
			PanBack = (Grid)target;
			break;
		case 3:
			TransformRotate = (RotateTransform)target;
			break;
		case 4:
			TransformPos = (TranslateTransform)target;
			break;
		case 5:
			ResizerT = (Rectangle)target;
			break;
		case 6:
			ResizerB = (Rectangle)target;
			break;
		case 7:
			ResizerR = (Rectangle)target;
			break;
		case 8:
			ResizerL = (Rectangle)target;
			break;
		case 9:
			ResizerLT = (Rectangle)target;
			break;
		case 10:
			ResizerLB = (Rectangle)target;
			break;
		case 11:
			ResizerRB = (Rectangle)target;
			break;
		case 12:
			ResizerRT = (Rectangle)target;
			break;
		case 13:
			BorderForm = (Border)target;
			break;
		case 14:
			RectForm = (RectangleGeometry)target;
			break;
		case 15:
			PanForm = (Grid)target;
			break;
		case 16:
			ImgBack = (Canvas)target;
			break;
		case 17:
			VideoBack = (MediaElement)target;
			VideoBack.MediaEnded += new RoutedEventHandler(VideoEnded);
			break;
		case 18:
			PanTitle = (Grid)target;
			break;
		case 19:
			ImgTitle = (MyImage)target;
			break;
		case 20:
			BtnTitleClose = (MyIconButton)target;
			break;
		case 21:
			BtnTitleMin = (MyIconButton)target;
			break;
		case 22:
			PanTitleMain = (Grid)target;
			break;
		case 23:
			PanTitleLeft = (Grid)target;
			break;
		case 24:
			ShapeTitleLogo = (Path)target;
			break;
		case 25:
			LabTitleLogo = (TextBlock)target;
			break;
		case 26:
			ImageTitleLogo = (MyImage)target;
			break;
		case 27:
			ProLogo = (Border)target;
			break;
		case 28:
			PanTitleSelect = (StackPanel)target;
			break;
		case 29:
			BtnTitleSelect0 = (MyRadioButton)target;
			break;
		case 30:
			BtnTitleSelect1 = (MyRadioButton)target;
			break;
		case 31:
			BtnTitleSelect2 = (MyRadioButton)target;
			break;
		case 32:
			BtnTitleSelect3 = (MyRadioButton)target;
			break;
		case 33:
			BtnTitleSelect4 = (MyRadioButton)target;
			break;
		case 34:
			PanTitleInner = (Grid)target;
			break;
		case 35:
			BtnTitleInner = (MyIconButton)target;
			break;
		case 36:
			LabTitleInner = (TextBlock)target;
			break;
		case 37:
			PanLeft = (Grid)target;
			break;
		case 38:
			RectLeftBackground = (BlurBorder)target;
			break;
		case 39:
			RectLeftShadow = (Rectangle)target;
			break;
		case 40:
			PanMain = (Grid)target;
			break;
		case 41:
			PanMainRight = (Border)target;
			break;
		case 42:
			PanMainLeft = (Border)target;
			break;
		case 43:
			PanHint = (StackPanel)target;
			break;
		case 44:
			BtnExtraBack = (MyExtraButton)target;
			break;
		case 45:
			BtnExtraDownload = (MyExtraButton)target;
			break;
		case 46:
			BtnExtraApril = (MyExtraButton)target;
			break;
		case 47:
			BtnExtraShutdown = (MyExtraButton)target;
			break;
		case 48:
			BtnExtraLog = (MyExtraButton)target;
			break;
		case 49:
			BtnExtraMusic = (MyExtraButton)target;
			break;
		case 50:
			PanMsgBackground = (BlurBorder)target;
			break;
		case 51:
			PanMsg = (Grid)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
