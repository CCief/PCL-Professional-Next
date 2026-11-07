using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using PCL.Core.Utils;

namespace PCL;

[StandardModule]
public sealed class ModMain
{
	public enum HintType
	{
		Info,
		Finish,
		Critical
	}

	private struct HintMessage
	{
		public string Text;

		public HintType Type;

		public bool Log;
	}

	public class MyMsgBoxConverter
	{
		public MyMsgBoxType Type;

		public string Title;

		public string Text;

		public object Content;

		public object AuthUrl;

		public Collection<Validate> ValidateRules;

		public string HintText;

		public bool HighLight;

		public string Button1;

		public string Button2;

		public string Button3;

		public Action Button1Action;

		public Action Button2Action;

		public Action Button3Action;

		public bool IsWarn;

		public bool ForceWait;

		public DispatcherFrame WaitFrame;

		public bool IsExited;

		public object Result;

		public MyMsgBoxConverter()
		{
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Expected O, but got Unknown
			AuthUrl = "https://login.microsoftonline.com/consumers/oauth2/v2.0/token";
			HintText = "";
			Button1 = "确定";
			Button2 = "";
			Button3 = "";
			Button1Action = null;
			Button2Action = null;
			Button3Action = null;
			IsWarn = false;
			ForceWait = false;
			WaitFrame = new DispatcherFrame(true);
			IsExited = false;
		}
	}

	public enum MyMsgBoxType
	{
		Text,
		Select,
		Input,
		Login,
		Markdown
	}

	public class HelpEntry
	{
		public string RawPath;

		public string Title;

		public string Desc;

		public string Search;

		public List<string> Types;

		public string Logo;

		public bool ShowInSearch;

		public bool ShowInPublic;

		public bool ShowInSnapshot;

		public bool IsEvent;

		public string EventType;

		public string EventData;

		public string XamlContent;

		public HelpEntry(string FilePath)
		{
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			Logo = null;
			ShowInSearch = true;
			ShowInPublic = true;
			ShowInSnapshot = true;
			RawPath = FilePath;
			JObject jObject = (JObject)ModBase.GetJson(HelpArgumentReplace(ModBase.ReadFile(FilePath)));
			if (jObject == null)
			{
				throw new FileNotFoundException("未找到帮助文件：" + FilePath, FilePath);
			}
			if (jObject["Title"] != null)
			{
				Title = (string?)jObject["Title"];
				Desc = (string?)(jObject["Description"] ?? ((JToken)""));
				Search = (string?)(jObject["Keywords"] ?? ((JToken)""));
				Logo = (string?)jObject["Logo"];
				ShowInSearch = (bool)(jObject["ShowInSearch"] ?? ((JToken)ShowInSearch));
				ShowInPublic = (bool)(jObject["ShowInPublic"] ?? ((JToken)ShowInPublic));
				ShowInSnapshot = (bool)(jObject["ShowInSnapshot"] ?? ((JToken)ShowInSnapshot));
				Types = new List<string>();
				foreach (object item in (System.Collections.IEnumerable)(jObject["Types"] ?? ModBase.GetJson("[]")))
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					Types.Add(Conversions.ToString(objectValue));
				}
				if (((bool?)(jObject["IsEvent"] ?? ((JToken)false))).GetValueOrDefault())
				{
					EventType = (string?)jObject["EventType"];
					if (EventType == null)
					{
						throw new ArgumentException("未找到 EventType 项");
					}
					EventData = (string?)(jObject["EventData"] ?? ((JToken)""));
					IsEvent = true;
				}
				else
				{
					string text = FilePath.ToLower().Replace(".json", ".xaml");
					if (!File.Exists(text))
					{
						throw new FileNotFoundException("未找到帮助条目 .json 对应的 .xaml 文件（" + text + "）");
					}
					XamlContent = ModBase.ReadFile(text);
					IsEvent = false;
				}
				return;
			}
			throw new ArgumentException("未找到 Title 项");
		}

		public MyListItem ToListItem()
		{
			return SetToListItem(new MyListItem());
		}

		public MyListItem SetToListItem(MyListItem Item)
		{
			string text = ((!IsEvent) ? (ModBase.PathImage + "Blocks/Grass.png") : ((Operators.CompareString(EventType, "弹出窗口", false) != 0) ? (ModBase.PathImage + "Blocks/CommandBlock.png") : (ModBase.PathImage + "Blocks/GrassPath.png")));
			((UIElement)Item).SnapsToDevicePixels = true;
			Item.Title = Title;
			Item.Info = Desc;
			Item.Logo = Logo ?? text;
			((FrameworkElement)Item).Height = 42.0;
			Item.Type = MyListItem.CheckType.Clickable;
			((FrameworkElement)Item).Tag = this;
			Item.EventType = null;
			Item.EventData = null;
			Item.Click += [SpecialName] (object sender, MouseButtonEventArgs e) =>
			{
				PageOtherHelp.OnItemClick((HelpEntry)NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null));
			};
			return Item;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static VB_0024AnonymousDelegate_0<string> _0024I91_002D0;

		public static MatchEvaluator _0024IR91_002D1;

		public static VB_0024AnonymousDelegate_0<string> _0024I91_002D1;

		public static MatchEvaluator _0024IR91_002D2;

		public static Action _0024I111_002D0;

		public static Action _0024I112_002D0;

		public static Action _0024I112_002D1;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal string _Lambda_0024__R91_002D1(Match a0)
		{
			return ((VB_0024AnonymousDelegate_0<string>)([SpecialName] () => ModBase.EscapeXML(PageOtherTest.GetRandomHint())))();
		}

		[SpecialName]
		internal string _Lambda_0024__91_002D0()
		{
			return ModBase.EscapeXML(PageOtherTest.GetRandomHint());
		}

		[SpecialName]
		internal string _Lambda_0024__R91_002D2(Match a0)
		{
			return ((VB_0024AnonymousDelegate_0<string>)([SpecialName] () => ModBase.EscapeXML(PageOtherTest.GetRandomCave())))();
		}

		[SpecialName]
		internal string _Lambda_0024__91_002D1()
		{
			return ModBase.EscapeXML(PageOtherTest.GetRandomCave());
		}

		[SpecialName]
		internal void _Lambda_0024__111_002D0()
		{
			if (!FrmMain.Hidden)
			{
				if (((Window)FrmMain).Top < -9000.0)
				{
					((Window)FrmMain).Top = 100.0;
				}
				if (((Window)FrmMain).Left < -9000.0)
				{
					((Window)FrmMain).Left = 100.0;
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__112_002D0()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			try
			{
				while (true)
				{
					ModBase.RunInUiWait(new Action(TimerMain));
					Thread.Sleep(49);
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "程序主时钟出错", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__112_002D1()
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			try
			{
				int tickCount = Environment.TickCount;
				while (true)
				{
					if (tickCount != Environment.TickCount)
					{
						tickCount = Environment.TickCount;
						ModBase.RunInUiWait(new Action(TimerFool));
					}
					Thread.Sleep(1);
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "愚人节主时钟出错", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__5_002D0
	{
		public double _0024VB_0024Local_Percent;

		public Border _0024VB_0024Local_DoubleStack;

		public ModBase.MyColor _0024VB_0024Local_TargetColor0;

		public ModBase.MyColor _0024VB_0024Local_TargetColor1;

		public _Closure_0024__5_002D0(_Closure_0024__5_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Percent = arg0._0024VB_0024Local_Percent;
				_0024VB_0024Local_DoubleStack = arg0._0024VB_0024Local_DoubleStack;
				_0024VB_0024Local_TargetColor0 = arg0._0024VB_0024Local_TargetColor0;
				_0024VB_0024Local_TargetColor1 = arg0._0024VB_0024Local_TargetColor1;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0(object i)
		{
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			_0024VB_0024Local_Percent = Conversions.ToDouble(Operators.AddObject((object)_0024VB_0024Local_Percent, i));
			LinearGradientBrush val = (LinearGradientBrush)_0024VB_0024Local_DoubleStack.Background;
			((GradientBrush)val).GradientStops[0].Color = _0024VB_0024Local_TargetColor0 * _0024VB_0024Local_Percent + new ModBase.MyColor(255.0, 255.0, 255.0) * (1.0 - _0024VB_0024Local_Percent);
			((GradientBrush)val).GradientStops[1].Color = _0024VB_0024Local_TargetColor1 * _0024VB_0024Local_Percent + new ModBase.MyColor(255.0, 255.0, 255.0) * (1.0 - _0024VB_0024Local_Percent);
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			NewLateBinding.LateIndexSetComplex(((FrameworkElement)_0024VB_0024Local_DoubleStack).Tag, new object[] { 0, false }, (string[])null, false, true);
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			((Panel)FrmMain.PanHint).Children.Remove((UIElement)(object)_0024VB_0024Local_DoubleStack);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__5_002D1
	{
		public Border _0024VB_0024Local_NewHintControl;

		public _Closure_0024__5_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__5_002D1(_Closure_0024__5_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_NewHintControl = arg0._0024VB_0024Local_NewHintControl;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__3(object i)
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Percent = Conversions.ToDouble(Operators.AddObject((object)_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Percent, i));
			LinearGradientBrush val = (LinearGradientBrush)_0024VB_0024Local_NewHintControl.Background;
			((GradientBrush)val).GradientStops[0].Color = _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_TargetColor0 * _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Percent + new ModBase.MyColor(255.0, 255.0, 255.0) * (1.0 - _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Percent);
			((GradientBrush)val).GradientStops[1].Color = _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_TargetColor1 * _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Percent + new ModBase.MyColor(255.0, 255.0, 255.0) * (1.0 - _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Percent);
		}

		[SpecialName]
		internal void _Lambda_0024__4()
		{
			NewLateBinding.LateIndexSetComplex(((FrameworkElement)_0024VB_0024Local_NewHintControl).Tag, new object[] { 0, false }, (string[])null, false, true);
		}

		[SpecialName]
		internal void _Lambda_0024__5()
		{
			((Panel)FrmMain.PanHint).Children.Remove((UIElement)(object)_0024VB_0024Local_NewHintControl);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D0
	{
		public Border _0024VB_0024Local_Control;

		public _Closure_0024__6_002D0(_Closure_0024__6_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Control = arg0._0024VB_0024Local_Control;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			NewLateBinding.LateIndexSetComplex(((FrameworkElement)_0024VB_0024Local_Control).Tag, new object[] { 0, false }, (string[])null, false, true);
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			((Panel)FrmMain.PanHint).Children.Remove((UIElement)(object)_0024VB_0024Local_Control);
		}
	}

	private static ModBase.SafeList<HintMessage> HintWaiting = HintWaiting ?? new ModBase.SafeList<HintMessage>();

	public static List<MyMsgBoxConverter> WaitingMyMsgBox = WaitingMyMsgBox ?? new List<MyMsgBoxConverter>();

	public static FormMain FrmMain;

	public static SplashScreen FrmStart;

	public static PageLaunchLeft FrmLaunchLeft;

	public static PageLaunchRight FrmLaunchRight;

	public static PageLogLeft FrmLogLeft;

	public static PageLogRight FrmLogRight;

	public static PageSelectLeft FrmSelectLeft;

	public static PageSelectRight FrmSelectRight;

	public static PageSpeedLeft FrmSpeedLeft;

	public static PageSpeedRight FrmSpeedRight;

	public static PageLink FrmLink;

	public static PageLinkLobby FrmLinkLobby;

	public static PageLinkJoin FrmLinkJoin;

	public static PageLinkSetup FrmSetupLink;

	public static PageLinkQA FrmLinkHelp;

	public static PageLinkFeedback FrmLinkFeedback;

	public static PageDownloadLeft FrmDownloadLeft;

	public static PageDownloadInstall FrmDownloadInstall;

	public static PageDownloadClient FrmDownloadClient;

	public static PageDownloadOptiFine FrmDownloadOptiFine;

	public static PageDownloadLiteLoader FrmDownloadLiteLoader;

	public static PageDownloadForge FrmDownloadForge;

	public static PageDownloadNeoForge FrmDownloadNeoForge;

	public static PageDownloadCleanroom FrmDownloadCleanroom;

	public static PageDownloadFabric FrmDownloadFabric;

	public static PageDownloadQuilt FrmDownloadQuilt;

	public static PageDownloadLabyMod FrmDownloadLabyMod;

	public static PageDownloadLegacyFabric FrmDownloadLegacyFabric;

	public static PageDownloadMod FrmDownloadMod;

	public static PageDownloadPack FrmDownloadPack;

	public static PageDownloadDataPack FrmDownloadDataPack;

	public static PageDownloadShader FrmDownloadShader;

	public static PageDownloadResourcePack FrmDownloadResourcePack;

	public static PageDownloadWorld FrmDownloadWorld;

	public static PageDownloadSchematic FrmDownloadSchematic;

	public static PageDownloadCompFavorites FrmDownloadCompFavorites;

	public static PageSetupLeft FrmSetupLeft;

	public static PageSetupLaunch FrmSetupLaunch;

	public static PageSetupUI FrmSetupUI;

	public static PageSetupSystem FrmSetupSystem;

	public static PageSetupJava FrmSetupJava;

	public static PageHomepageMarket FrmHomePageMarket;

	public static PageOtherLeft FrmOtherLeft;

	public static PageOtherHelp FrmOtherHelp;

	public static PageOtherAbout FrmOtherAbout;

	public static PageOtherTest FrmOtherTest;

	public static PageOtherFeedback FrmOtherFeedback;

	public static PageOtherVote FrmOtherVote;

	public static PageOtherLog FrmOtherLog;

	public static PageLoginAuth FrmLoginAuth;

	public static PageLoginMs FrmLoginMs;

	public static PageLoginProfile FrmLoginProfile;

	public static PageLoginProfileSkin FrmLoginProfileSkin;

	public static PageLoginOffline FrmLoginOffline;

	public static PageInstanceLeft FrmInstanceLeft;

	public static PageInstanceOverall FrmInstanceOverall;

	public static PageInstanceCompResource FrmInstanceMod;

	public static PageInstanceModDisabled FrmInstanceModDisabled;

	public static PageInstanceScreenshot FrmInstanceScreenshot;

	public static PageInstanceSaves FrmInstanceSaves;

	public static PageInstanceCompResource FrmInstanceShader;

	public static PageInstanceCompResource FrmInstanceSchematic;

	public static PageInstanceCompResource FrmInstanceResourcePack;

	public static PageInstanceSetup FrmInstanceSetup;

	public static PageInstanceInstall FrmInstanceInstall;

	public static PageInstanceExport FrmInstanceExport;

	public static PageInstanceServer FrmInstanceServer;

	public static PageInstanceSavesLeft FrmInstanceSavesLeft;

	public static PageInstanceSavesInfo FrmInstanceSavesInfo;

	public static PageInstanceSavesBackup FrmInstanceSavesBackup;

	public static PageDownloadCompDetail FrmDownloadCompDetail;

	public static ModLoader.LoaderTask<int, List<HelpEntry>> HelpLoader = new ModLoader.LoaderTask<int, List<HelpEntry>>("Help Page", HelpLoad, null, (ThreadPriority)1);

	private static readonly object HelpLoadLock = RuntimeHelpers.GetObjectValue(new object());

	public static bool IsAprilEnabled = System.DateTime.Now.Month == 4 && System.DateTime.Now.Day == 1;

	public static bool IsAprilGiveup = false;

	private static Vector AprilSpeed = new Vector(0.0, 0.0);

	private static int AprilIdieCount = 0;

	private static Point AprilMousePosLast = new Point(0.0, 0.0);

	private static int AprilDistance = 0;

	private static bool IsTaskTempCleared = false;

	private static bool IsTaskTempClearing = false;

	public static object DragControl = null;

	private static int Timer4Count = 0;

	private static int Timer150Count = 0;

	public static void Hint(string Text, HintType Type = HintType.Info, bool Log = true)
	{
		if (HintWaiting == null)
		{
			HintWaiting = new ModBase.SafeList<HintMessage>();
		}
		((List<HintMessage>)HintWaiting).Add(new HintMessage
		{
			Text = (Text ?? ""),
			Type = Type,
			Log = Log
		});
	}

	private static void HintTick()
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Expected O, but got Unknown
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Unknown result type (might be due to invalid IL or missing references)
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		//IL_063e: Expected O, but got Unknown
		//IL_069c: Unknown result type (might be due to invalid IL or missing references)
		//IL_06aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b4: Expected O, but got Unknown
		//IL_06b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Expected O, but got Unknown
		//IL_06c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cc: Expected O, but got Unknown
		//IL_06d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0725: Unknown result type (might be due to invalid IL or missing references)
		//IL_074a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Expected O, but got Unknown
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Expected O, but got Unknown
		//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b1: Expected O, but got Unknown
		//IL_0858: Unknown result type (might be due to invalid IL or missing references)
		//IL_0874: Expected O, but got Unknown
		//IL_0960: Unknown result type (might be due to invalid IL or missing references)
		//IL_0973: Expected O, but got Unknown
		//IL_09a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b4: Expected O, but got Unknown
		checked
		{
			try
			{
				if (!Enumerable.Any<HintMessage>((System.Collections.Generic.IEnumerable<HintMessage>)HintWaiting))
				{
					return;
				}
				_Closure_0024__5_002D0 closure_0024__5_002D = default(_Closure_0024__5_002D0);
				_Closure_0024__5_002D1 closure_0024__5_002D2 = default(_Closure_0024__5_002D1);
				while (Enumerable.Any<HintMessage>((System.Collections.Generic.IEnumerable<HintMessage>)HintWaiting))
				{
					closure_0024__5_002D = new _Closure_0024__5_002D0(closure_0024__5_002D);
					HintMessage hintMessage = ((List<HintMessage>)HintWaiting)[0];
					hintMessage.Text = hintMessage.Text.Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ");
					if (((Panel)FrmMain.PanHint).Children.Count < 20)
					{
						closure_0024__5_002D._0024VB_0024Local_DoubleStack = null;
						foreach (Border child in ((Panel)FrmMain.PanHint).Children)
						{
							Border val = child;
							if (Conversions.ToBoolean((object)(Conversions.ToBoolean(NewLateBinding.LateIndexGet(((FrameworkElement)val).Tag, new object[] { 0 }, (string[])null)) && Operators.CompareString(((TextBlock)((Decorator)val).Child).Text, hintMessage.Text, false) == 0)))
							{
								closure_0024__5_002D._0024VB_0024Local_DoubleStack = val;
							}
						}
						closure_0024__5_002D._0024VB_0024Local_Percent = 0.3;
						switch (hintMessage.Type)
						{
						case HintType.Info:
							closure_0024__5_002D._0024VB_0024Local_TargetColor0 = new ModBase.MyColor(215.0, 37.0, 155.0, 252.0);
							closure_0024__5_002D._0024VB_0024Local_TargetColor1 = new ModBase.MyColor(215.0, 10.0, 142.0, 252.0);
							break;
						case HintType.Finish:
							closure_0024__5_002D._0024VB_0024Local_TargetColor0 = new ModBase.MyColor(215.0, 33.0, 177.0, 33.0);
							closure_0024__5_002D._0024VB_0024Local_TargetColor1 = new ModBase.MyColor(215.0, 29.0, 160.0, 29.0);
							break;
						default:
							closure_0024__5_002D._0024VB_0024Local_TargetColor0 = new ModBase.MyColor(215.0, 255.0, 53.0, 11.0);
							closure_0024__5_002D._0024VB_0024Local_TargetColor1 = new ModBase.MyColor(215.0, 255.0, 43.0, 0.0);
							break;
						}
						if (!Information.IsNothing((object)closure_0024__5_002D._0024VB_0024Local_DoubleStack))
						{
							if (!ModAnimation.AniIsRun(Conversions.ToString(Operators.ConcatenateObject((object)"Hint Show ", NewLateBinding.LateIndexGet(((FrameworkElement)closure_0024__5_002D._0024VB_0024Local_DoubleStack).Tag, new object[] { 1 }, (string[])null)))))
							{
								ModAnimation.AniStop(Conversions.ToString(Operators.ConcatenateObject((object)"Hint Hide ", NewLateBinding.LateIndexGet(((FrameworkElement)closure_0024__5_002D._0024VB_0024Local_DoubleStack).Tag, new object[] { 1 }, (string[])null))));
								double num = (800.0 + ModBase.MathClamp(hintMessage.Text.Length, 5.0, 23.0) * 180.0) * ModAnimation.AniSpeed;
								ModAnimation.AniData[] array = new ModAnimation.AniData[10];
								Border _0024VB_0024Local_DoubleStack = closure_0024__5_002D._0024VB_0024Local_DoubleStack;
								Thickness margin = ((FrameworkElement)closure_0024__5_002D._0024VB_0024Local_DoubleStack).Margin;
								array[0] = ModAnimation.AaX(_0024VB_0024Local_DoubleStack, -12.0 - margin.Left, 50, 0, new ModAnimation.AniEaseOutFluent());
								array[1] = ModAnimation.AaX(closure_0024__5_002D._0024VB_0024Local_DoubleStack, -8.0, 50, 50, new ModAnimation.AniEaseInFluent());
								array[2] = ModAnimation.AaX(closure_0024__5_002D._0024VB_0024Local_DoubleStack, 8.0, 50, 100, new ModAnimation.AniEaseOutFluent());
								array[3] = ModAnimation.AaX(closure_0024__5_002D._0024VB_0024Local_DoubleStack, -8.0, 50, 150, new ModAnimation.AniEaseInFluent());
								array[4] = ModAnimation.AaDouble(new ParameterizedThreadStart(closure_0024__5_002D._Lambda_0024__0), 0.7, 250);
								array[5] = ModAnimation.AaX(closure_0024__5_002D._0024VB_0024Local_DoubleStack, -50.0, 200, (int)Math.Round(num), new ModAnimation.AniEaseInFluent());
								array[6] = ModAnimation.AaOpacity(closure_0024__5_002D._0024VB_0024Local_DoubleStack, -1.0, 150, (int)Math.Round(num));
								array[7] = ModAnimation.AaCode(new ThreadStart(closure_0024__5_002D._Lambda_0024__1), (int)Math.Round(num));
								array[8] = ModAnimation.AaHeight(closure_0024__5_002D._0024VB_0024Local_DoubleStack, -26.0, 100, 0, new ModAnimation.AniEaseOutFluent(), After: true);
								array[9] = ModAnimation.AaCode(new ThreadStart(closure_0024__5_002D._Lambda_0024__2), 0, After: true);
								ModAnimation.AniStart((System.Collections.IList)(object)array, Conversions.ToString(Operators.ConcatenateObject((object)"Hint Hide ", NewLateBinding.LateIndexGet(((FrameworkElement)closure_0024__5_002D._0024VB_0024Local_DoubleStack).Tag, new object[] { 1 }, (string[])null))));
							}
						}
						else
						{
							closure_0024__5_002D2 = new _Closure_0024__5_002D1(closure_0024__5_002D2);
							closure_0024__5_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2 = closure_0024__5_002D;
							_Closure_0024__5_002D1 closure_0024__5_002D3 = closure_0024__5_002D2;
							Border val2 = new Border();
							((FrameworkElement)val2).Tag = new object[2]
							{
								true,
								ModBase.GetUuid()
							};
							((FrameworkElement)val2).Margin = new Thickness(-70.0, 0.0, 20.0, 0.0);
							((UIElement)val2).Opacity = 0.0;
							((FrameworkElement)val2).Height = 0.0;
							((FrameworkElement)val2).HorizontalAlignment = (HorizontalAlignment)0;
							val2.CornerRadius = new CornerRadius(0.0, 6.0, 6.0, 0.0);
							closure_0024__5_002D3._0024VB_0024Local_NewHintControl = val2;
							Border _0024VB_0024Local_NewHintControl = closure_0024__5_002D2._0024VB_0024Local_NewHintControl;
							List<GradientStop> obj = new List<GradientStop>();
							obj.Add(new GradientStop((Color)(closure_0024__5_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_TargetColor0 * closure_0024__5_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Percent + new ModBase.MyColor(255.0, 255.0, 255.0) * (1.0 - closure_0024__5_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Percent)), 0.0));
							obj.Add(new GradientStop((Color)(closure_0024__5_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_TargetColor1 * closure_0024__5_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Percent + new ModBase.MyColor(255.0, 255.0, 255.0) * (1.0 - closure_0024__5_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_Percent)), 1.0));
							_0024VB_0024Local_NewHintControl.Background = (Brush)new LinearGradientBrush(new GradientStopCollection((System.Collections.Generic.IEnumerable<GradientStop>)obj), 90.0);
							((Decorator)closure_0024__5_002D2._0024VB_0024Local_NewHintControl).Child = (UIElement)new TextBlock
							{
								TextTrimming = (TextTrimming)1,
								FontSize = 13.0,
								Text = hintMessage.Text,
								Foreground = new ModBase.MyColor(255.0, 255.0, 255.0),
								Margin = new Thickness(33.0, 5.0, 8.0, 5.0)
							};
							((Panel)FrmMain.PanHint).Children.Add((UIElement)(object)closure_0024__5_002D2._0024VB_0024Local_NewHintControl);
							List<ModAnimation.AniData> val3 = new List<ModAnimation.AniData>();
							if (((Panel)FrmMain.PanHint).Children.Count > 1)
							{
								val3.Add(ModAnimation.AaHeight(closure_0024__5_002D2._0024VB_0024Local_NewHintControl, 26.0, 150, 0, new ModAnimation.AniEaseOutFluent()));
							}
							else
							{
								((FrameworkElement)closure_0024__5_002D2._0024VB_0024Local_NewHintControl).Height = 26.0;
							}
							val3.AddRange((System.Collections.Generic.IEnumerable<ModAnimation.AniData>)new ModAnimation.AniData[4]
							{
								ModAnimation.AaX(closure_0024__5_002D2._0024VB_0024Local_NewHintControl, 30.0, 400, 0, new ModAnimation.AniEaseOutElastic(ModAnimation.AniEasePower.Weak)),
								ModAnimation.AaX(closure_0024__5_002D2._0024VB_0024Local_NewHintControl, 20.0, 200, 0, new ModAnimation.AniEaseOutFluent()),
								ModAnimation.AaOpacity(closure_0024__5_002D2._0024VB_0024Local_NewHintControl, 1.0, 100),
								ModAnimation.AaDouble(new ParameterizedThreadStart(closure_0024__5_002D2._Lambda_0024__3), 0.7, 250, 100)
							});
							ModAnimation.AniStart((System.Collections.IList)val3, Conversions.ToString(Operators.ConcatenateObject((object)"Hint Show ", NewLateBinding.LateIndexGet(((FrameworkElement)closure_0024__5_002D2._0024VB_0024Local_NewHintControl).Tag, new object[] { 1 }, (string[])null))));
							double num2 = (800.0 + ModBase.MathClamp(hintMessage.Text.Length, 5.0, 23.0) * 180.0) * ModAnimation.AniSpeed;
							ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[5]
							{
								ModAnimation.AaX(closure_0024__5_002D2._0024VB_0024Local_NewHintControl, -50.0, 200, (int)Math.Round(num2), new ModAnimation.AniEaseInFluent()),
								ModAnimation.AaOpacity(closure_0024__5_002D2._0024VB_0024Local_NewHintControl, -1.0, 150, (int)Math.Round(num2)),
								ModAnimation.AaCode(new ThreadStart(closure_0024__5_002D2._Lambda_0024__4), (int)Math.Round(num2)),
								ModAnimation.AaHeight(closure_0024__5_002D2._0024VB_0024Local_NewHintControl, -26.0, 100, 0, new ModAnimation.AniEaseOutFluent(), After: true),
								ModAnimation.AaCode(new ThreadStart(closure_0024__5_002D2._Lambda_0024__5), 0, After: true)
							}, Conversions.ToString(Operators.ConcatenateObject((object)"Hint Hide ", NewLateBinding.LateIndexGet(((FrameworkElement)closure_0024__5_002D2._0024VB_0024Local_NewHintControl).Tag, new object[] { 1 }, (string[])null))));
						}
					}
					if (hintMessage.Log)
					{
						ModBase.Log("[UI] 弹出提示：" + hintMessage.Text);
					}
					((List<HintMessage>)HintWaiting).RemoveAt(0);
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "显示弹出提示失败", ModBase.LogLevel.Normal);
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void HideAllHint()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		System.Collections.IEnumerator enumerator = ((Panel)FrmMain.PanHint).Children.GetEnumerator();
		try
		{
			_Closure_0024__6_002D0 closure_0024__6_002D = default(_Closure_0024__6_002D0);
			while (enumerator.MoveNext())
			{
				closure_0024__6_002D = new _Closure_0024__6_002D0(closure_0024__6_002D);
				closure_0024__6_002D._0024VB_0024Local_Control = (Border)enumerator.Current;
				((UIElement)closure_0024__6_002D._0024VB_0024Local_Control).IsHitTestVisible = false;
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[5]
				{
					ModAnimation.AaX(closure_0024__6_002D._0024VB_0024Local_Control, -50.0, 200, 0, new ModAnimation.AniEaseInFluent()),
					ModAnimation.AaOpacity(closure_0024__6_002D._0024VB_0024Local_Control, -1.0, 150, 0, new ModAnimation.AniEaseInFluent()),
					ModAnimation.AaCode(new ThreadStart(closure_0024__6_002D._Lambda_0024__0)),
					ModAnimation.AaHeight(closure_0024__6_002D._0024VB_0024Local_Control, -26.0, 100, 0, new ModAnimation.AniEaseOutFluent(), After: true),
					ModAnimation.AaCode(new ThreadStart(closure_0024__6_002D._Lambda_0024__1), 0, After: true)
				}, Conversions.ToString(Operators.ConcatenateObject((object)"Hint Hide ", NewLateBinding.LateIndexGet(((FrameworkElement)closure_0024__6_002D._0024VB_0024Local_Control).Tag, new object[] { 1 }, (string[])null))));
			}
		}
		finally
		{
			System.IDisposable disposable = enumerator as System.IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
	}

	public static int MyMsgBox(string Caption, string Title = "提示", string Button1 = "确定", string Button2 = "", string Button3 = "", bool IsWarn = false, bool HighLight = true, bool ForceWait = false, Action Button1Action = null, Action Button2Action = null, Action Button3Action = null)
	{
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Invalid comparison between Unknown and I4
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Invalid comparison between Unknown and I4
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Invalid comparison between Unknown and I4
		MyMsgBoxConverter myMsgBoxConverter = new MyMsgBoxConverter
		{
			// 普通弹框一律使用纯文本样式；输入框只由 MyMsgBoxInput 显式创建。
			// （早期 IL 注入把此处的枚举方向写反，导致纯提示框变成输入框。）
			Type = MyMsgBoxType.Text,
			Button1 = Button1,
			Button2 = Button2,
			Button3 = Button3,
			Text = Caption,
			IsWarn = IsWarn,
			Title = Title,
			HighLight = HighLight,
			ForceWait = true,
			Button1Action = Button1Action,
			Button2Action = Button2Action,
			Button3Action = Button3Action
		};
		WaitingMyMsgBox.Add(myMsgBoxConverter);
		if (ModBase.RunInUi())
		{
			MyMsgBoxTick();
		}
		if (Button2.Length > 0 || ForceWait)
		{
			if (FrmMain == null || (FrmMain.PanMsg == null && ModBase.RunInUi()))
			{
				WaitingMyMsgBox.Remove(myMsgBoxConverter);
				if (Button2.Length > 0)
				{
					MsgBoxResult val = Interaction.MsgBox((object)Caption, (MsgBoxStyle)checked(((Button3.Length > 0) ? 3 : 4) + (IsWarn ? 16 : 32)), (object)Title);
					if ((int)val != 2)
					{
						if ((int)val != 6)
						{
							if ((int)val == 7)
							{
								myMsgBoxConverter.Result = 2;
							}
						}
						else
						{
							myMsgBoxConverter.Result = 1;
						}
					}
					else
					{
						myMsgBoxConverter.Result = 3;
					}
				}
				else
				{
					Interaction.MsgBox((object)Caption, (MsgBoxStyle)checked(0 + (IsWarn ? 16 : 32)), (object)Title);
					myMsgBoxConverter.Result = 1;
				}
				ModBase.Log(string.Concat(new string[] { "[Control] 主窗体加载完成前出现意料外的等待弹窗：", Button1, ",", Button2, ",", Button3 }), ModBase.LogLevel.Debug);
			}
			else
			{
				try
				{
					FrmMain.DragStop();
					ComponentDispatcher.PushModal();
					Dispatcher.PushFrame(myMsgBoxConverter.WaitFrame);
				}
				finally
				{
					ComponentDispatcher.PopModal();
				}
			}
			ModBase.Log(Conversions.ToString(Operators.ConcatenateObject((object)"[Control] 普通弹框返回：", myMsgBoxConverter.Result ?? "null")));
			return Conversions.ToInteger(myMsgBoxConverter.Result);
		}
		return 1;
	}

	public static int MyMsgBoxMarkdown(string Caption, string Title = "提示", string Button1 = "确定", string Button2 = "", string Button3 = "", bool IsWarn = false, bool HighLight = true, bool ForceWait = false, Action Button1Action = null, Action Button2Action = null, Action Button3Action = null)
	{
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Invalid comparison between Unknown and I4
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Invalid comparison between Unknown and I4
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Invalid comparison between Unknown and I4
		MyMsgBoxConverter myMsgBoxConverter = new MyMsgBoxConverter
		{
			Type = MyMsgBoxType.Markdown,
			Button1 = Button1,
			Button2 = Button2,
			Button3 = Button3,
			Text = Caption,
			IsWarn = IsWarn,
			Title = Title,
			HighLight = HighLight,
			ForceWait = true,
			Button1Action = Button1Action,
			Button2Action = Button2Action,
			Button3Action = Button3Action
		};
		WaitingMyMsgBox.Add(myMsgBoxConverter);
		if (ModBase.RunInUi())
		{
			MyMsgBoxTick();
		}
		if (Button2.Length > 0 || ForceWait)
		{
			if (FrmMain == null || (FrmMain.PanMsg == null && ModBase.RunInUi()))
			{
				WaitingMyMsgBox.Remove(myMsgBoxConverter);
				if (Button2.Length > 0)
				{
					MsgBoxResult val = Interaction.MsgBox((object)Caption, (MsgBoxStyle)checked(((Button3.Length > 0) ? 3 : 4) + (IsWarn ? 16 : 32)), (object)Title);
					if ((int)val != 2)
					{
						if ((int)val != 6)
						{
							if ((int)val == 7)
							{
								myMsgBoxConverter.Result = 2;
							}
						}
						else
						{
							myMsgBoxConverter.Result = 1;
						}
					}
					else
					{
						myMsgBoxConverter.Result = 3;
					}
				}
				else
				{
					Interaction.MsgBox((object)Caption, (MsgBoxStyle)checked(0 + (IsWarn ? 16 : 32)), (object)Title);
					myMsgBoxConverter.Result = 1;
				}
				ModBase.Log(string.Concat(new string[] { "[Control] 主窗体加载完成前出现意料外的等待弹窗：", Button1, ",", Button2, ",", Button3 }), ModBase.LogLevel.Debug);
			}
			else
			{
				try
				{
					FrmMain.DragStop();
					ComponentDispatcher.PushModal();
					Dispatcher.PushFrame(myMsgBoxConverter.WaitFrame);
				}
				finally
				{
					ComponentDispatcher.PopModal();
				}
			}
			ModBase.Log(Conversions.ToString(Operators.ConcatenateObject((object)"[Control] 普通弹框返回：", myMsgBoxConverter.Result ?? "null")));
			return Conversions.ToInteger(myMsgBoxConverter.Result);
		}
		return 1;
	}

	public static string MyMsgBoxInput(string Title, string Text = "", string DefaultInput = "", Collection<Validate> ValidateRules = null, string HintText = "", string Button1 = "确定", string Button2 = "取消", bool IsWarn = false)
	{
		MyMsgBoxConverter myMsgBoxConverter = new MyMsgBoxConverter
		{
			Text = Text,
			HintText = HintText,
			Type = MyMsgBoxType.Input,
			ValidateRules = (ValidateRules ?? new Collection<Validate>()),
			Button1 = Button1,
			Button2 = Button2,
			Content = DefaultInput,
			IsWarn = IsWarn,
			Title = Title
		};
		WaitingMyMsgBox.Add(myMsgBoxConverter);
		try
		{
			if (FrmMain != null)
			{
				FrmMain.DragStop();
			}
			ComponentDispatcher.PushModal();
			Dispatcher.PushFrame(myMsgBoxConverter.WaitFrame);
		}
		finally
		{
			ComponentDispatcher.PopModal();
		}
		ModBase.Log(Conversions.ToString(Operators.ConcatenateObject((object)"[Control] 输入弹框返回：", myMsgBoxConverter.Result ?? "null")));
		return Conversions.ToString(myMsgBoxConverter.Result);
	}

	public static int? MyMsgBoxSelect(List<IMyRadio> Selections, string Title = "提示", string Button1 = "确定", string Button2 = "", bool IsWarn = false)
	{
		MyMsgBoxConverter myMsgBoxConverter = new MyMsgBoxConverter
		{
			Type = MyMsgBoxType.Select,
			Button1 = Button1,
			Button2 = Button2,
			Content = Selections,
			IsWarn = IsWarn,
			Title = Title
		};
		WaitingMyMsgBox.Add(myMsgBoxConverter);
		try
		{
			if (FrmMain != null)
			{
				FrmMain.DragStop();
			}
			ComponentDispatcher.PushModal();
			Dispatcher.PushFrame(myMsgBoxConverter.WaitFrame);
		}
		finally
		{
			ComponentDispatcher.PopModal();
		}
		ModBase.Log(Conversions.ToString(Operators.ConcatenateObject((object)"[Control] 选择弹框返回：", myMsgBoxConverter.Result ?? "null")));
		return (int?)myMsgBoxConverter.Result;
	}

	public static void MyMsgBoxTick()
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Invalid comparison between Unknown and I4
		try
		{
			if (FrmMain == null || FrmMain.PanMsg == null || (int)((Window)FrmMain).WindowState == 1)
			{
				return;
			}
			if (((Panel)FrmMain.PanMsg).Children.Count > 0)
			{
				((UIElement)FrmMain.PanMsgBackground).Visibility = (Visibility)0;
			}
			else if (Enumerable.Any<MyMsgBoxConverter>((System.Collections.Generic.IEnumerable<MyMsgBoxConverter>)WaitingMyMsgBox))
			{
				((UIElement)FrmMain.PanMsgBackground).Visibility = (Visibility)0;
				switch (WaitingMyMsgBox[0].Type)
				{
				case MyMsgBoxType.Input:
					((Panel)FrmMain.PanMsg).Children.Add((UIElement)(object)new MyMsgInput(WaitingMyMsgBox[0]));
					break;
				case MyMsgBoxType.Select:
					((Panel)FrmMain.PanMsg).Children.Add((UIElement)(object)new MyMsgSelect(WaitingMyMsgBox[0]));
					break;
				case MyMsgBoxType.Text:
					((Panel)FrmMain.PanMsg).Children.Add((UIElement)(object)new MyMsgText(WaitingMyMsgBox[0]));
					break;
				case MyMsgBoxType.Login:
					((Panel)FrmMain.PanMsg).Children.Add((UIElement)(object)new MyMsgLogin(WaitingMyMsgBox[0]));
					break;
				case MyMsgBoxType.Markdown:
					((Panel)FrmMain.PanMsg).Children.Add((UIElement)(object)new MyMsgMarkdown(WaitingMyMsgBox[0]));
					break;
				}
				WaitingMyMsgBox.RemoveAt(0);
			}
			else if ((int)((UIElement)FrmMain.PanMsgBackground).Visibility != 2)
			{
				((UIElement)FrmMain.PanMsgBackground).Visibility = (Visibility)2;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "处理等待中的弹窗失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static void HelpLoad(ModLoader.LoaderTask<int, List<HelpEntry>> Loader)
	{
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		object helpLoadLock = HelpLoadLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(helpLoadLock);
		bool flag = false;
		try
		{
			Monitor.Enter(helpLoadLock, ref flag);
			try
			{
				HelpExtract();
				List<string> val = new List<string>();
				try
				{
					List<string> val2 = new List<string>();
					if (Directory.Exists(ModBase.ExePath + "PCL\\Help\\"))
					{
						System.Collections.Generic.IEnumerator<FileInfo> enumerator = default(System.Collections.Generic.IEnumerator<FileInfo>);
						try
						{
							enumerator = ModBase.EnumerateFiles(ModBase.ExePath + "PCL\\Help\\").GetEnumerator();
							while (((System.Collections.IEnumerator)enumerator).MoveNext())
							{
								FileInfo current = enumerator.Current;
								string text = ((FileSystemInfo)current).Extension.ToLower();
								if (Operators.CompareString(text, ".helpignore", false) != 0)
								{
									if (Operators.CompareString(text, ".json", false) == 0)
									{
										val.Add(((FileSystemInfo)current).FullName);
									}
									continue;
								}
								ModBase.Log("[Help] 发现 .helpignore 文件：" + ((FileSystemInfo)current).FullName);
								string[] array = ModBase.ReadFile(((FileSystemInfo)current).FullName).Split("\r\n".ToCharArray());
								for (int i = 0; i < array.Length; i = checked(i + 1))
								{
									string text2 = ModBase.BeforeFirst(array[i], "#").Trim();
									if (!string.IsNullOrWhiteSpace(text2))
									{
										val2.Add(text2);
										if (ModBase.ModeDebug)
										{
											ModBase.Log("[Help]  > " + text2);
										}
									}
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator)?.Dispose();
						}
					}
					ModBase.Log("[Help] 已扫描 PCL 文件夹下的帮助文件，目前总计 " + Conversions.ToString(val.Count) + " 条");
					System.Collections.Generic.IEnumerator<FileInfo> enumerator2 = default(System.Collections.Generic.IEnumerator<FileInfo>);
					try
					{
						enumerator2 = ModBase.EnumerateFiles(ModBase.PathHelpFolder).GetEnumerator();
						System.Collections.Generic.IEnumerator<string> enumerator3 = default(System.Collections.Generic.IEnumerator<string>);
						while (((System.Collections.IEnumerator)enumerator2).MoveNext())
						{
							FileInfo current2 = enumerator2.Current;
							if (Operators.CompareString(((FileSystemInfo)current2).Extension.ToLower(), ".json", false) != 0 || ((FileSystemInfo)current2.Directory).FullName.Replace(ModBase.PathHelpFolder.TrimEnd('\\'), "").Contains("\\."))
							{
								continue;
							}
							string text3 = ((FileSystemInfo)current2).FullName.Replace(ModBase.PathHelpFolder.TrimEnd('\\'), "");
							try
							{
								enumerator3 = val2.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									string current3 = enumerator3.Current;
									if (!ModBase.RegexCheck(text3, current3, (RegexOptions)0))
									{
										continue;
									}
									if (ModBase.ModeDebug)
									{
										ModBase.Log("[Help] 已忽略 " + text3 + "：" + current3);
									}
									goto IL_0278;
								}
							}
							finally
							{
								((System.IDisposable)enumerator3).Dispose();
							}
							val.Add(((FileSystemInfo)current2).FullName);
							IL_0278:;
						}
					}
					finally
					{
						((System.IDisposable)enumerator2)?.Dispose();
					}
					ModBase.Log("[Help] 已扫描缓存文件夹下的帮助文件，目前总计 " + Conversions.ToString(val.Count) + " 条");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "检查帮助文件夹失败", ModBase.LogLevel.Msgbox);
					ProjectData.ClearProjectError();
				}
				if (Loader.IsAborted)
				{
					return;
				}
				List<HelpEntry> val3 = new List<HelpEntry>();
				System.Collections.Generic.IEnumerator<string> enumerator4 = default(System.Collections.Generic.IEnumerator<string>);
				try
				{
					enumerator4 = val.GetEnumerator();
					while (enumerator4.MoveNext())
					{
						string current4 = enumerator4.Current;
						try
						{
							HelpEntry helpEntry = new HelpEntry(current4);
							val3.Add(helpEntry);
							if (ModBase.ModeDebug)
							{
								ModBase.Log("[Help] 已加载的帮助条目：" + helpEntry.Title + " ← " + current4);
							}
						}
						catch (System.Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							System.Exception ex4 = ex3;
							ModBase.Log(ex4, "初始化帮助条目失败（" + current4 + "）", ModBase.LogLevel.Msgbox);
							ProjectData.ClearProjectError();
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator4).Dispose();
				}
				if (!Enumerable.Any<HelpEntry>((System.Collections.Generic.IEnumerable<HelpEntry>)val3))
				{
					throw new System.Exception("未找到可用的帮助；若不需要帮助页面，可以在 设置 → 个性化 → 功能隐藏 中将其隐藏");
				}
				if (!Loader.IsAborted)
				{
					Loader.Output = val3;
				}
			}
			catch (System.Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				System.Exception ex6 = ex5;
				ModBase.Log(ex6, "帮助列表初始化失败");
				throw;
			}
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(helpLoadLock);
			}
		}
	}

	public static void HelpExtract()
	{
		ModBase.DeleteDirectory(ModBase.PathTemp + "CE\\Help");
		Directory.CreateDirectory(ModBase.PathTemp + "CE\\Help");
		ModBase.WriteFile(ModBase.PathTemp + "CE\\Cache\\Help.zip", ModBase.GetResourceStream("Resources/Help.zip"));
		ModBase.ExtractFile(ModBase.PathTemp + "CE\\Cache\\Help.zip", ModBase.PathTemp + "CE\\Help", Encoding.UTF8);
		ModBase.Log("[Help] 已解压内置帮助文件，目前状态：" + Conversions.ToString(File.Exists(ModBase.PathTemp + "CE\\Help\\启动器\\备份设置.xaml")), ModBase.LogLevel.Debug);
	}

	public static string HelpArgumentReplace(string Xaml)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		string allContents = Xaml.Replace("{path}", ModBase.EscapeXML(ModBase.ExePath));
		object replaceTo;
		if (_Closure_0024__._0024IR91_002D1 != null)
		{
			replaceTo = _Closure_0024__._0024IR91_002D1;
		}
		else
		{
			MatchEvaluator val = [SpecialName] (Match a0) => ((VB_0024AnonymousDelegate_0<string>)([SpecialName] () => ModBase.EscapeXML(PageOtherTest.GetRandomHint())))();
			_Closure_0024__._0024IR91_002D1 = val;
			replaceTo = (object)val;
		}
		string allContents2 = ModBase.RegexReplaceEach(allContents, "\\{hint\\}", (MatchEvaluator)replaceTo, (RegexOptions)0);
		object replaceTo2;
		if (_Closure_0024__._0024IR91_002D2 != null)
		{
			replaceTo2 = _Closure_0024__._0024IR91_002D2;
		}
		else
		{
			MatchEvaluator val2 = [SpecialName] (Match a0) => ((VB_0024AnonymousDelegate_0<string>)([SpecialName] () => ModBase.EscapeXML(PageOtherTest.GetRandomCave())))();
			_Closure_0024__._0024IR91_002D2 = val2;
			replaceTo2 = (object)val2;
		}
		return ModBase.RegexReplaceEach(allContents2, "\\{cave\\}", (MatchEvaluator)replaceTo2, (RegexOptions)0);
	}

	private static void TimerFool()
	{
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0714: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0720: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				if (FrmLaunchLeft == null || FrmLaunchLeft.AprilPosTrans == null || FrmMain.lastMouseArg == null || IsAprilGiveup || FrmMain.PageCurrent != FormMain.PageType.Launch || ModAnimation.AniControlEnabled != 0 || !((FrameworkElement)FrmLaunchLeft.BtnLaunch).IsLoaded)
				{
					return;
				}
				Point position = FrmMain.lastMouseArg.GetPosition((IInputElement)(object)FrmMain);
				if (position == AprilMousePosLast)
				{
					AprilIdieCount++;
				}
				else
				{
					AprilMousePosLast = position;
					AprilIdieCount = 0;
				}
				double num = ((FrameworkElement)FrmLaunchLeft.BtnLaunch).ActualWidth / 2.0;
				double num2 = ((FrameworkElement)FrmLaunchLeft.BtnLaunch).ActualHeight / 2.0;
				Vector val = (Vector)(FrmMain.lastMouseArg.GetPosition((IInputElement)(object)FrmLaunchLeft.BtnLaunch) - new Vector(num, num2));
				Vector val2 = new Vector(val.X, val.Y);
				val2.Normalize();
				Vector val3 = -val2;
				Vector val4 = new Vector(Math.Max(0.0, Math.Abs(val.X) - num), Math.Max(0.0, Math.Abs(val.Y) - num2));
				double length = val4.Length;
				double num3 = Math.Sin((double)Timer150Count / 37.5 * Math.PI);
				Vector val5 = Math.Max(0.0, num3 * 0.25 - 0.65 - Math.Log((length + 0.4) / 200.0)) * val3;
				if (AprilIdieCount >= 320)
				{
					Vector val6 = (Vector)(FrmMain.lastMouseArg.GetPosition((IInputElement)(object)FrmMain.PanMain) - new Vector(num, ((FrameworkElement)FrmMain.PanMain).ActualHeight - num2 * 3.0));
					Vector val7 = new Vector(FrmLaunchLeft.AprilPosTrans.X, FrmLaunchLeft.AprilPosTrans.Y);
					if (val6.Length > 250.0 && val7.Length > 0.4)
					{
						val5 -= val7 * 0.0005;
						val7.Normalize();
						val5 -= val7 * 0.15;
					}
				}
				Point val8 = ((UIElement)FrmLaunchLeft.BtnLaunch).TranslatePoint(new Point(0.0, 0.0), (UIElement)(object)FrmMain.PanForm);
				TranslateTransform aprilPosTrans;
				if (val8.X < (0.0 - num) * 2.0)
				{
					(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).X = aprilPosTrans.X + (((FrameworkElement)FrmMain.PanForm).ActualWidth + num * 2.0);
					AprilSpeed.X = AprilSpeed.X - 80.0;
					if (val8.Y < 0.0)
					{
						(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).Y = aprilPosTrans.Y + num2 * 2.5;
					}
					else if (val8.Y > ((FrameworkElement)FrmMain.PanForm).ActualHeight - num2 * 2.0)
					{
						(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).Y = aprilPosTrans.Y - num2 * 2.5;
					}
				}
				else if (val8.X > ((FrameworkElement)FrmMain.PanForm).ActualWidth)
				{
					(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).X = aprilPosTrans.X - (((FrameworkElement)FrmMain.PanForm).ActualWidth + num * 2.0);
					AprilSpeed.X = AprilSpeed.X + 80.0;
					if (val8.Y < 0.0)
					{
						(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).Y = aprilPosTrans.Y + num2 * 2.5;
					}
					else if (val8.Y > ((FrameworkElement)FrmMain.PanForm).ActualHeight - num2 * 2.0)
					{
						(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).Y = aprilPosTrans.Y - num2 * 2.5;
					}
				}
				else if (val8.Y < (0.0 - num2) * 2.0)
				{
					(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).Y = aprilPosTrans.Y + (((FrameworkElement)FrmMain.PanForm).ActualHeight + num2 * 2.0);
					AprilSpeed.Y = AprilSpeed.Y - 25.0;
					if (val8.X < 0.0)
					{
						(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).X = aprilPosTrans.X + num * 2.0;
					}
					else if (val8.X > ((FrameworkElement)FrmMain.PanForm).ActualWidth - num * 2.0)
					{
						(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).X = aprilPosTrans.X - num * 2.0;
					}
				}
				else if (val8.Y > ((FrameworkElement)FrmMain.PanForm).ActualHeight)
				{
					(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).Y = aprilPosTrans.Y - (((FrameworkElement)FrmMain.PanForm).ActualHeight + num2 * 2.0);
					AprilSpeed.Y = AprilSpeed.Y + 25.0;
					if (val8.X < 0.0)
					{
						(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).X = aprilPosTrans.X + num * 2.0;
					}
					else if (val8.X > ((FrameworkElement)FrmMain.PanForm).ActualWidth - num * 2.0)
					{
						(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).X = aprilPosTrans.X - num * 2.0;
					}
				}
				AprilSpeed = AprilSpeed * 0.8 + val5;
				double num4 = Math.Min(60.0, AprilSpeed.Length);
				if (num4 < 0.01)
				{
					return;
				}
				AprilSpeed.Normalize();
				AprilSpeed *= num4;
				AprilDistance = (int)Math.Round((double)AprilDistance + num4);
				(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).X = aprilPosTrans.X + AprilSpeed.X;
				(aprilPosTrans = FrmLaunchLeft.AprilPosTrans).Y = aprilPosTrans.Y + AprilSpeed.Y;
				FrmLaunchLeft.AprilScaleTrans.ScaleX = ModBase.MathClamp(1.0 - (Math.Abs(val3.X) - Math.Abs(val3.Y)) * (num4 / 160.0), 0.2, 1.8);
				FrmLaunchLeft.AprilScaleTrans.ScaleY = ModBase.MathClamp(1.0 - (Math.Abs(val3.Y) - Math.Abs(val3.X)) * (num4 / 100.0), 0.2, 1.8);
				if (AprilDistance > 4000)
				{
					AprilDistance = -4000;
					switch (RandomUtils.NextInt(0, 3))
					{
					case 0:
						Hint("放弃吧！只需要点一下右下角的小白旗……");
						break;
					case 1:
						Hint("看到右下角的那面小白旗了吗？");
						break;
					case 2:
						Hint("这里建议点一下右下角的小白旗投降呢.jpg");
						break;
					case 3:
						Hint("右下角的小白旗永远等着你……");
						break;
					}
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "愚人节移动出错", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void ShowWindowToTop(nint Handle)
	{
		try
		{
			PostMessage(Handle, 6402u, 0L, 0L);
			SetForegroundWindow(Handle);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "设置窗口置顶失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "FindWindowA", ExactSpelling = true, SetLastError = true)]
	public static extern nint FindWindow([MarshalAs(34)] ref string ClassName, [MarshalAs(34)] ref string WindowName);

	[DllImport("user32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	public static extern int SetForegroundWindow(nint hWnd);

	[DllImport("user32", CharSet = CharSet.Ansi, EntryPoint = "PostMessageA", ExactSpelling = true, SetLastError = true)]
	private static extern bool PostMessage(nint hWnd, uint msg, long wParam, long lParam);

	public static void SetGPUPreference(string Executeable, bool WantHighPerformance = true)
	{
		bool flag = false;
		RegistryKey val = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\DirectX\\UserGpuPreferences", false);
		try
		{
			if (val != null)
			{
				if (Operators.CompareString("GpuPreference=2;", RuntimeHelpers.GetObjectValue(val.GetValue(Executeable))?.ToString(), false) == 0)
				{
					flag = true;
				}
			}
			else
			{
				ModBase.Log("[System] 需要创建显卡设置的父级键");
				Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\DirectX\\UserGpuPreferences");
			}
		}
		finally
		{
			((System.IDisposable)val)?.Dispose();
		}
		ModBase.Log($"[System] 当前程序 ({Executeable}) 的显卡设置为高性能: {flag}");
		if (flag ^ WantHighPerformance)
		{
			RegistryKey val2 = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\DirectX\\UserGpuPreferences", true);
			try
			{
				val2.SetValue(Executeable, (object)(WantHighPerformance ? "GpuPreference=2;" : "GpuPreference=0;"));
				ModBase.Log($"[System] 已调整程序 ({Executeable}) 显卡设置: {WantHighPerformance}");
			}
			finally
			{
				((System.IDisposable)val2)?.Dispose();
			}
		}
	}

	public static void TryClearTaskTemp()
	{
		if (!IsTaskTempCleared)
		{
			IsTaskTempCleared = true;
			IsTaskTempClearing = true;
			try
			{
				ModBase.Log("[System] 开始清理任务缓存文件夹");
				ModBase.DeleteDirectory($"{ModBase.OsDrive}ProgramData\\PCL\\TaskTemp\\");
				ModBase.DeleteDirectory($"{ModBase.PathTemp}TaskTemp\\");
				ModBase.Log("[System] 已清理任务缓存文件夹");
				return;
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "清理任务缓存文件夹失败");
				ProjectData.ClearProjectError();
				return;
			}
			finally
			{
				IsTaskTempClearing = false;
			}
		}
		if (IsTaskTempClearing)
		{
			while (IsTaskTempClearing)
			{
				Thread.Sleep(1);
			}
		}
	}

	public static string RequestTaskTempFolder(bool RequireNonSpace = false)
	{
		TryClearTaskTemp();
		string text;
		try
		{
			text = $"{ModBase.PathTemp}TaskTemp\\{ModBase.GetUuid()}-{RandomUtils.NextInt(0, 1000000)}\\";
			if (!RequireNonSpace || !text.Contains(" "))
			{
				Directory.CreateDirectory(text);
				ModBase.CheckPermissionWithException(text);
				return text;
			}
		}
		catch (System.Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		text = $"{ModBase.OsDrive}ProgramData\\PCL\\TaskTemp\\{ModBase.GetUuid()}-{RandomUtils.NextInt(0, 1000000)}\\";
		Directory.CreateDirectory(text);
		ModBase.CheckPermission(text);
		return text;
	}

	private static void TimerMain()
	{
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		try
		{
			HintTick();
			MyMsgBoxTick();
			FrmMain.DragTick();
			ModLoader.LoaderTaskbarProgressRefresh();
			if (ModSecret.ThemeDontClick == 2)
			{
				ModSecret.ThemeRefresh();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "短程主时钟执行异常", ModBase.LogLevel.Critical);
			ProjectData.ClearProjectError();
		}
		checked
		{
			Timer4Count++;
			if (Timer4Count == 4)
			{
				Timer4Count = 0;
				try
				{
					if (ModSecret.ThemeNow == 12)
					{
						ModSecret.ThemeRefresh();
					}
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, "中程主时钟执行异常");
					ProjectData.ClearProjectError();
				}
			}
			Timer150Count++;
			if (Timer150Count != 150)
			{
				return;
			}
			Timer150Count = 0;
			try
			{
				if (FrmMain.BtnExtraApril_ShowCheck() && AprilDistance != 0)
				{
					FrmMain.BtnExtraApril.Ribble();
				}
				object action;
				if (_Closure_0024__._0024I111_002D0 != null)
				{
					action = _Closure_0024__._0024I111_002D0;
				}
				else
				{
					Action val = [SpecialName] () =>
					{
						if (!FrmMain.Hidden)
						{
							if (((Window)FrmMain).Top < -9000.0)
							{
								((Window)FrmMain).Top = 100.0;
							}
							if (((Window)FrmMain).Left < -9000.0)
							{
								((Window)FrmMain).Left = 100.0;
							}
						}
					};
					_Closure_0024__._0024I111_002D0 = val;
					action = (object)val;
				}
				ModBase.RunInUi((Action)action);
			}
			catch (System.Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				System.Exception ex6 = ex5;
				ModBase.Log(ex6, "长程主时钟执行异常", ModBase.LogLevel.Critical);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void TimerMainStart()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I112_002D0 != null)
		{
			action = _Closure_0024__._0024I112_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_0011: Expected O, but got Unknown
				try
				{
					while (true)
					{
						ModBase.RunInUiWait(new Action(TimerMain));
						Thread.Sleep(49);
					}
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, "程序主时钟出错", ModBase.LogLevel.Feedback);
					ProjectData.ClearProjectError();
				}
			};
			_Closure_0024__._0024I112_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInNewThread((Action)action, "Timer Main", (ThreadPriority)2);
		if (!IsAprilEnabled)
		{
			return;
		}
		object action2;
		if (_Closure_0024__._0024I112_002D1 != null)
		{
			action2 = _Closure_0024__._0024I112_002D1;
		}
		else
		{
			Action val2 = [SpecialName] () =>
			{
				//IL_001b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0025: Expected O, but got Unknown
				try
				{
					int tickCount = Environment.TickCount;
					while (true)
					{
						if (tickCount != Environment.TickCount)
						{
							tickCount = Environment.TickCount;
							ModBase.RunInUiWait(new Action(TimerFool));
						}
						Thread.Sleep(1);
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "愚人节主时钟出错", ModBase.LogLevel.Feedback);
					ProjectData.ClearProjectError();
				}
			};
			_Closure_0024__._0024I112_002D1 = val2;
			action2 = (object)val2;
		}
		ModBase.RunInNewThread((Action)action2, "Timer Main Fool", (ThreadPriority)2);
	}
}
