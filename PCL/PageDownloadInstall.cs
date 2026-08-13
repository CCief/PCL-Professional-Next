using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace PCL;

[DesignerGenerated]
public class PageDownloadInstall : MyPageRight, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<JObject, System.DateTime> _0024I53_002D0;

		public static MyListItem.ClickEventHandler _0024I53_002D2;

		public static VB_0024AnonymousDelegate_15<StackPanel> _0024I53_002D1;

		public static VB_0024AnonymousDelegate_8 _0024I53_002D3;

		public static MyListItem.ClickEventHandler _0024IR53_002D4;

		public static ModBase.ComparisonBoolean<ModDownload.DlOptiFineListEntry> _0024I58_002D0;

		public static Func<ModDownload.DlForgeVersionEntry, Version> _0024I68_002D1;

		public static Action<StackPanel> _0024I83_002D0;

		public static Func<ModComp.CompFile, System.DateTime> _0024I90_002D0;

		public static Action<StackPanel> _0024I95_002D0;

		public static Func<ModComp.CompFile, System.DateTime> _0024I102_002D0;

		public static Action<StackPanel> _0024I107_002D0;

		public static ModBase.ComparisonBoolean<ModComp.CompFile> _0024I114_002D0;

		public static Func<ModComp.CompFile, System.DateTime> _0024I121_002D0;

		public static Action<StackPanel> _0024I126_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal System.DateTime _Lambda_0024__53_002D0(JObject j)
		{
			return j["releaseTime"].Value<System.DateTime>();
		}

		[SpecialName]
		internal void _Lambda_0024__53_002D1(StackPanel Stack)
		{
			foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				((Panel)Stack).Children.Add((UIElement)(object)ModDownloadLib.McDownloadListItem((JObject)objectValue, (_0024I53_002D2 == null) ? (_0024I53_002D2 = [SpecialName] (object sender, MouseButtonEventArgs e) =>
				{
					ModMain.FrmDownloadInstall.MinecraftSelected((MyListItem)sender, e);
				}) : _0024I53_002D2, IsSaveOnly: false));
			}
		}

		[SpecialName]
		internal void _Lambda_0024__53_002D2(object sender, MouseButtonEventArgs e)
		{
			ModMain.FrmDownloadInstall.MinecraftSelected((MyListItem)sender, e);
		}

		[SpecialName]
		internal void _Lambda_0024__R53_002D4(object a0, MouseButtonEventArgs a1)
		{
			((VB_0024AnonymousDelegate_8)([SpecialName] () =>
			{
			}))();
		}

		[SpecialName]
		internal void _Lambda_0024__53_002D3()
		{
		}

		[SpecialName]
		internal bool _Lambda_0024__58_002D0(ModDownload.DlOptiFineListEntry Left, ModDownload.DlOptiFineListEntry Right)
		{
			if (!Left.IsPreview && Right.IsPreview)
			{
				return true;
			}
			if (Left.IsPreview && !Right.IsPreview)
			{
				return false;
			}
			return ModMinecraft.VersionSortBoolean(Left.NameDisplay, Right.NameDisplay);
		}

		[SpecialName]
		internal Version _Lambda_0024__68_002D1(ModDownload.DlForgeVersionEntry v)
		{
			return v.Version;
		}

		[SpecialName]
		internal void _Lambda_0024__83_002D0(StackPanel Stack)
		{
			_Closure_0024__R83_002D12 closure_0024__R83_002D = default(_Closure_0024__R83_002D12);
			foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				UIElementCollection children = ((Panel)Stack).Children;
				JObject entry = (JObject)objectValue;
				closure_0024__R83_002D = new _Closure_0024__R83_002D12(closure_0024__R83_002D)
				{
					_0024VB_0024NonLocal_2 = ModMain.FrmDownloadInstall
				};
				children.Add((UIElement)(object)ModDownloadLib.FabricDownloadListItem(entry, closure_0024__R83_002D._Lambda_0024__R14));
			}
		}

		[SpecialName]
		internal System.DateTime _Lambda_0024__90_002D0(ModComp.CompFile v)
		{
			return v.ReleaseDate;
		}

		[SpecialName]
		internal void _Lambda_0024__95_002D0(StackPanel Stack)
		{
			_Closure_0024__R95_002D15 closure_0024__R95_002D = default(_Closure_0024__R95_002D15);
			foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				UIElementCollection children = ((Panel)Stack).Children;
				JObject entry = (JObject)objectValue;
				closure_0024__R95_002D = new _Closure_0024__R95_002D15(closure_0024__R95_002D)
				{
					_0024VB_0024NonLocal_2 = ModMain.FrmDownloadInstall
				};
				children.Add((UIElement)(object)ModDownloadLib.LegacyFabricDownloadListItem(entry, closure_0024__R95_002D._Lambda_0024__R17));
			}
		}

		[SpecialName]
		internal System.DateTime _Lambda_0024__102_002D0(ModComp.CompFile v)
		{
			return v.ReleaseDate;
		}

		[SpecialName]
		internal void _Lambda_0024__107_002D0(StackPanel Stack)
		{
			_Closure_0024__R107_002D18 closure_0024__R107_002D = default(_Closure_0024__R107_002D18);
			foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				UIElementCollection children = ((Panel)Stack).Children;
				JObject entry = (JObject)objectValue;
				closure_0024__R107_002D = new _Closure_0024__R107_002D18(closure_0024__R107_002D)
				{
					_0024VB_0024NonLocal_2 = ModMain.FrmDownloadInstall
				};
				children.Add((UIElement)(object)ModDownloadLib.QuiltDownloadListItem(entry, closure_0024__R107_002D._Lambda_0024__R20));
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__114_002D0(ModComp.CompFile a, ModComp.CompFile b)
		{
			return System.DateTime.Compare(a.ReleaseDate, b.ReleaseDate) > 0;
		}

		[SpecialName]
		internal System.DateTime _Lambda_0024__121_002D0(ModComp.CompFile v)
		{
			return v.ReleaseDate;
		}

		[SpecialName]
		internal void _Lambda_0024__126_002D0(StackPanel Stack)
		{
			_Closure_0024__R126_002D22 closure_0024__R126_002D = default(_Closure_0024__R126_002D22);
			foreach (JObject item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
			{
				UIElementCollection children = ((Panel)Stack).Children;
				closure_0024__R126_002D = new _Closure_0024__R126_002D22(closure_0024__R126_002D)
				{
					_0024VB_0024NonLocal_2 = ModMain.FrmDownloadInstall
				};
				children.Add((UIElement)(object)ModDownloadLib.LabyModDownloadListItem(item, closure_0024__R126_002D._Lambda_0024__R24));
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__R107_002D18
	{
		public PageDownloadInstall _0024VB_0024NonLocal_2;

		public _Closure_0024__R107_002D18(_Closure_0024__R107_002D18 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024NonLocal_2 = arg0._0024VB_0024NonLocal_2;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R20(object a0, MouseButtonEventArgs a1)
		{
			_0024VB_0024NonLocal_2.Quilt_Selected((MyListItem)a0, (EventArgs)(object)a1);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__R126_002D22
	{
		public PageDownloadInstall _0024VB_0024NonLocal_2;

		public _Closure_0024__R126_002D22(_Closure_0024__R126_002D22 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024NonLocal_2 = arg0._0024VB_0024NonLocal_2;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R24(object a0, MouseButtonEventArgs a1)
		{
			_0024VB_0024NonLocal_2.LabyMod_Selected((MyListItem)a0, (EventArgs)(object)a1);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__R83_002D12
	{
		public PageDownloadInstall _0024VB_0024NonLocal_2;

		public _Closure_0024__R83_002D12(_Closure_0024__R83_002D12 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024NonLocal_2 = arg0._0024VB_0024NonLocal_2;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R14(object a0, MouseButtonEventArgs a1)
		{
			_0024VB_0024NonLocal_2.Fabric_Selected((MyListItem)a0, (EventArgs)(object)a1);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__R95_002D15
	{
		public PageDownloadInstall _0024VB_0024NonLocal_2;

		public _Closure_0024__R95_002D15(_Closure_0024__R95_002D15 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024NonLocal_2 = arg0._0024VB_0024NonLocal_2;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R17(object a0, MouseButtonEventArgs a1)
		{
			_0024VB_0024NonLocal_2.LegacyFabric_Selected((MyListItem)a0, (EventArgs)(object)a1);
		}
	}

	private bool IsLoad;

	public bool IsInSelectPage;

	private bool IsFirstLoaded;

	private string SelectedMinecraftId;

	private string SelectedMinecraftJsonUrl;

	private string SelectedMinecraftIcon;

	private ModDownload.DlOptiFineListEntry SelectedOptiFine;

	private string SelectedLoaderName;

	private string SelectedAPIName;

	private ModDownload.DlLiteLoaderListEntry SelectedLiteLoader;

	private ModDownload.DlForgeVersionEntry SelectedForge;

	private ModDownload.DlCleanroomListEntry SelectedCleanroom;

	private ModDownload.DlNeoForgeListEntry SelectedNeoForge;

	private string SelectedFabric;

	private ModComp.CompFile SelectedFabricApi;

	private string SelectedLegacyFabric;

	private ModComp.CompFile SelectedLegacyFabricApi;

	private string SelectedQuilt;

	private ModComp.CompFile SelectedQSL;

	private string SelectedLabyModChannel;

	private string SelectedLabyModCommitRef;

	private string SelectedLabyModVersion;

	private ModComp.CompFile SelectedOptiFabric;

	private bool IsReloading;

	private bool IsSelectNameEdited;

	private bool IsSelectNameChanging;

	public static string McVersionWaitingForSelect = null;

	private bool AutoSelectedFabricApi;

	private bool AutoSelectedLegacyFabricApi;

	private bool AutoSelectedQSL;

	private bool AutoSelectedOptiFabric;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnBack")]
	private MyIconButton _BtnBack;

	[CompilerGenerated]
	[AccessedThroughProperty("TextSelectName")]
	private MyTextBox _TextSelectName;

	[CompilerGenerated]
	[AccessedThroughProperty("CardForge")]
	private MyCard _CardForge;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnForgeClear")]
	private Grid _BtnForgeClear;

	[CompilerGenerated]
	[AccessedThroughProperty("CardCleanroom")]
	private MyCard _CardCleanroom;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnCleanroomClear")]
	private Grid _BtnCleanroomClear;

	[CompilerGenerated]
	[AccessedThroughProperty("CardNeoForge")]
	private MyCard _CardNeoForge;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnNeoForgeClear")]
	private Grid _BtnNeoForgeClear;

	[CompilerGenerated]
	[AccessedThroughProperty("CardFabric")]
	private MyCard _CardFabric;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnFabricClear")]
	private Grid _BtnFabricClear;

	[CompilerGenerated]
	[AccessedThroughProperty("CardLegacyFabric")]
	private MyCard _CardLegacyFabric;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnLegacyFabricClear")]
	private Grid _BtnLegacyFabricClear;

	[CompilerGenerated]
	[AccessedThroughProperty("CardFabricApi")]
	private MyCard _CardFabricApi;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnFabricApiClear")]
	private Grid _BtnFabricApiClear;

	[CompilerGenerated]
	[AccessedThroughProperty("CardLegacyFabricApi")]
	private MyCard _CardLegacyFabricApi;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnLegacyFabricApiClear")]
	private Grid _BtnLegacyFabricApiClear;

	[CompilerGenerated]
	[AccessedThroughProperty("CardQuilt")]
	private MyCard _CardQuilt;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnQuiltClear")]
	private Grid _BtnQuiltClear;

	[CompilerGenerated]
	[AccessedThroughProperty("CardQSL")]
	private MyCard _CardQSL;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnQSLClear")]
	private Grid _BtnQSLClear;

	[CompilerGenerated]
	[AccessedThroughProperty("CardLabyMod")]
	private MyCard _CardLabyMod;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnLabyModClear")]
	private Grid _BtnLabyModClear;

	[CompilerGenerated]
	[AccessedThroughProperty("CardOptiFine")]
	private MyCard _CardOptiFine;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnOptiFineClear")]
	private Grid _BtnOptiFineClear;

	[CompilerGenerated]
	[AccessedThroughProperty("CardOptiFabric")]
	private MyCard _CardOptiFabric;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnOptiFabricClear")]
	private Grid _BtnOptiFabricClear;

	[CompilerGenerated]
	[AccessedThroughProperty("CardLiteLoader")]
	private MyCard _CardLiteLoader;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnLiteLoaderClear")]
	private Grid _BtnLiteLoaderClear;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnStart")]
	private MyExtraTextButton _BtnStart;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadOptiFine")]
	private MyLoading _LoadOptiFine;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadForge")]
	private MyLoading _LoadForge;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadNeoForge")]
	private MyLoading _LoadNeoForge;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadCleanroom")]
	private MyLoading _LoadCleanroom;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadLiteLoader")]
	private MyLoading _LoadLiteLoader;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadFabric")]
	private MyLoading _LoadFabric;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadLegacyFabric")]
	private MyLoading _LoadLegacyFabric;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadFabricApi")]
	private MyLoading _LoadFabricApi;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadLegacyFabricApi")]
	private MyLoading _LoadLegacyFabricApi;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadQuilt")]
	private MyLoading _LoadQuilt;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadQSL")]
	private MyLoading _LoadQSL;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadLabyMod")]
	private MyLoading _LoadLabyMod;

	[CompilerGenerated]
	[AccessedThroughProperty("LoadOptiFabric")]
	private MyLoading _LoadOptiFabric;

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
	[field: AccessedThroughProperty("PanInner")]
	internal virtual Grid PanInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanMinecraft")]
	internal virtual StackPanel PanMinecraft
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanSelect")]
	internal virtual StackPanel PanSelect
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconButton BtnBack
	{
		[CompilerGenerated]
		get
		{
			return _BtnBack;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				ExitSelectPage();
			};
			MyIconButton btnBack = _BtnBack;
			if (btnBack != null)
			{
				btnBack.Click -= obj;
			}
			_BtnBack = value;
			btnBack = _BtnBack;
			if (btnBack != null)
			{
				btnBack.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgLogo")]
	internal virtual MyImage ImgLogo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyTextBox TextSelectName
	{
		[CompilerGenerated]
		get
		{
			return _TextSelectName;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			TextChangedEventHandler val = new TextChangedEventHandler(TextSelectName_TextChanged);
			MyTextBox.ValidateChangedEventHandler obj = TextSelectName_ValidateChanged;
			KeyEventHandler val2 = new KeyEventHandler(TextSelectName_KeyDown);
			MyTextBox textSelectName = _TextSelectName;
			if (textSelectName != null)
			{
				((TextBoxBase)textSelectName).TextChanged -= val;
				MyTextBox.ValidateChanged -= obj;
				((UIElement)textSelectName).KeyDown -= val2;
			}
			_TextSelectName = value;
			textSelectName = _TextSelectName;
			if (textSelectName != null)
			{
				((TextBoxBase)textSelectName).TextChanged += val;
				MyTextBox.ValidateChanged += obj;
				((UIElement)textSelectName).KeyDown += val2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintFabricAPI")]
	internal virtual MyHint HintFabricAPI
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintLegacyFabricAPI")]
	internal virtual MyHint HintLegacyFabricAPI
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintOptiFabric")]
	internal virtual MyHint HintOptiFabric
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintOptiFabricOld")]
	internal virtual MyHint HintOptiFabricOld
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintLegacyOptiFabric")]
	internal virtual MyHint HintLegacyOptiFabric
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintModOptiFine")]
	internal virtual MyHint HintModOptiFine
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintQSL")]
	internal virtual MyHint HintQSL
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintQuiltFabricAPI")]
	internal virtual MyHint HintQuiltFabricAPI
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardForge
	{
		[CompilerGenerated]
		get
		{
			return _CardForge;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				SelectReload();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardForge_PreviewSwap;
			MyCard cardForge = _CardForge;
			if (cardForge != null)
			{
				cardForge.Swap -= obj;
				cardForge.PreviewSwap -= obj2;
			}
			_CardForge = value;
			cardForge = _CardForge;
			if (cardForge != null)
			{
				cardForge.Swap += obj;
				cardForge.PreviewSwap += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanForge")]
	internal virtual StackPanel PanForge
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanForgeInfo")]
	internal virtual Grid PanForgeInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgForge")]
	internal virtual Image ImgForge
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabForge")]
	internal virtual TextBlock LabForge
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid BtnForgeClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnForgeClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(Forge_Clear);
			Grid btnForgeClear = _BtnForgeClear;
			if (btnForgeClear != null)
			{
				((UIElement)btnForgeClear).MouseLeftButtonUp -= val;
			}
			_BtnForgeClear = value;
			btnForgeClear = _BtnForgeClear;
			if (btnForgeClear != null)
			{
				((UIElement)btnForgeClear).MouseLeftButtonUp += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnForgeClearInner")]
	internal virtual Path BtnForgeClearInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardCleanroom
	{
		[CompilerGenerated]
		get
		{
			return _CardCleanroom;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				SelectReload();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardCleanroom_PreviewSwap;
			MyCard cardCleanroom = _CardCleanroom;
			if (cardCleanroom != null)
			{
				cardCleanroom.Swap -= obj;
				cardCleanroom.PreviewSwap -= obj2;
			}
			_CardCleanroom = value;
			cardCleanroom = _CardCleanroom;
			if (cardCleanroom != null)
			{
				cardCleanroom.Swap += obj;
				cardCleanroom.PreviewSwap += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanCleanroom")]
	internal virtual StackPanel PanCleanroom
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanCleanroomInfo")]
	internal virtual Grid PanCleanroomInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgCleanroom")]
	internal virtual Image ImgCleanroom
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabCleanroom")]
	internal virtual TextBlock LabCleanroom
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid BtnCleanroomClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnCleanroomClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(Cleanroom_Clear);
			Grid btnCleanroomClear = _BtnCleanroomClear;
			if (btnCleanroomClear != null)
			{
				((UIElement)btnCleanroomClear).MouseLeftButtonUp -= val;
			}
			_BtnCleanroomClear = value;
			btnCleanroomClear = _BtnCleanroomClear;
			if (btnCleanroomClear != null)
			{
				((UIElement)btnCleanroomClear).MouseLeftButtonUp += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnCleanroomClearInner")]
	internal virtual Path BtnCleanroomClearInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardNeoForge
	{
		[CompilerGenerated]
		get
		{
			return _CardNeoForge;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				SelectReload();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardNeoForge_PreviewSwap;
			MyCard cardNeoForge = _CardNeoForge;
			if (cardNeoForge != null)
			{
				cardNeoForge.Swap -= obj;
				cardNeoForge.PreviewSwap -= obj2;
			}
			_CardNeoForge = value;
			cardNeoForge = _CardNeoForge;
			if (cardNeoForge != null)
			{
				cardNeoForge.Swap += obj;
				cardNeoForge.PreviewSwap += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanNeoForge")]
	internal virtual StackPanel PanNeoForge
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanNeoForgeInfo")]
	internal virtual Grid PanNeoForgeInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgNeoForge")]
	internal virtual Image ImgNeoForge
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabNeoForge")]
	internal virtual TextBlock LabNeoForge
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid BtnNeoForgeClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnNeoForgeClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(NeoForge_Clear);
			Grid btnNeoForgeClear = _BtnNeoForgeClear;
			if (btnNeoForgeClear != null)
			{
				((UIElement)btnNeoForgeClear).MouseLeftButtonUp -= val;
			}
			_BtnNeoForgeClear = value;
			btnNeoForgeClear = _BtnNeoForgeClear;
			if (btnNeoForgeClear != null)
			{
				((UIElement)btnNeoForgeClear).MouseLeftButtonUp += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnNeoForgeClearInner")]
	internal virtual Path BtnNeoForgeClearInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardFabric
	{
		[CompilerGenerated]
		get
		{
			return _CardFabric;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				SelectReload();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardFabric_PreviewSwap;
			MyCard cardFabric = _CardFabric;
			if (cardFabric != null)
			{
				cardFabric.Swap -= obj;
				cardFabric.PreviewSwap -= obj2;
			}
			_CardFabric = value;
			cardFabric = _CardFabric;
			if (cardFabric != null)
			{
				cardFabric.Swap += obj;
				cardFabric.PreviewSwap += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanFabric")]
	internal virtual StackPanel PanFabric
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanFabricInfo")]
	internal virtual Grid PanFabricInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgFabric")]
	internal virtual Image ImgFabric
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabFabric")]
	internal virtual TextBlock LabFabric
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid BtnFabricClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnFabricClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(Fabric_Clear);
			Grid btnFabricClear = _BtnFabricClear;
			if (btnFabricClear != null)
			{
				((UIElement)btnFabricClear).MouseLeftButtonUp -= val;
			}
			_BtnFabricClear = value;
			btnFabricClear = _BtnFabricClear;
			if (btnFabricClear != null)
			{
				((UIElement)btnFabricClear).MouseLeftButtonUp += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnFabricClearInner")]
	internal virtual Path BtnFabricClearInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardLegacyFabric
	{
		[CompilerGenerated]
		get
		{
			return _CardLegacyFabric;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCard.PreviewSwapEventHandler obj = CardLegacyFabric_PreviewSwap;
			MyCard cardLegacyFabric = _CardLegacyFabric;
			if (cardLegacyFabric != null)
			{
				cardLegacyFabric.PreviewSwap -= obj;
			}
			_CardLegacyFabric = value;
			cardLegacyFabric = _CardLegacyFabric;
			if (cardLegacyFabric != null)
			{
				cardLegacyFabric.PreviewSwap += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLegacyFabric")]
	internal virtual StackPanel PanLegacyFabric
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLegacyFabricInfo")]
	internal virtual Grid PanLegacyFabricInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgLegacyFabric")]
	internal virtual Image ImgLegacyFabric
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLegacyFabric")]
	internal virtual TextBlock LabLegacyFabric
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid BtnLegacyFabricClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnLegacyFabricClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(LegacyFabric_Clear);
			Grid btnLegacyFabricClear = _BtnLegacyFabricClear;
			if (btnLegacyFabricClear != null)
			{
				((UIElement)btnLegacyFabricClear).MouseLeftButtonUp -= val;
			}
			_BtnLegacyFabricClear = value;
			btnLegacyFabricClear = _BtnLegacyFabricClear;
			if (btnLegacyFabricClear != null)
			{
				((UIElement)btnLegacyFabricClear).MouseLeftButtonUp += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnLegacyFabricClearInner")]
	internal virtual Path BtnLegacyFabricClearInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardFabricApi
	{
		[CompilerGenerated]
		get
		{
			return _CardFabricApi;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				SelectReload();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardFabricApi_PreviewSwap;
			MyCard cardFabricApi = _CardFabricApi;
			if (cardFabricApi != null)
			{
				cardFabricApi.Swap -= obj;
				cardFabricApi.PreviewSwap -= obj2;
			}
			_CardFabricApi = value;
			cardFabricApi = _CardFabricApi;
			if (cardFabricApi != null)
			{
				cardFabricApi.Swap += obj;
				cardFabricApi.PreviewSwap += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanFabricApi")]
	internal virtual StackPanel PanFabricApi
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanFabricApiInfo")]
	internal virtual Grid PanFabricApiInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgFabricApi")]
	internal virtual Image ImgFabricApi
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabFabricApi")]
	internal virtual TextBlock LabFabricApi
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid BtnFabricApiClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnFabricApiClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(FabricApi_Clear);
			Grid btnFabricApiClear = _BtnFabricApiClear;
			if (btnFabricApiClear != null)
			{
				((UIElement)btnFabricApiClear).MouseLeftButtonUp -= val;
			}
			_BtnFabricApiClear = value;
			btnFabricApiClear = _BtnFabricApiClear;
			if (btnFabricApiClear != null)
			{
				((UIElement)btnFabricApiClear).MouseLeftButtonUp += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnFabricApiClearInner")]
	internal virtual Path BtnFabricApiClearInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardLegacyFabricApi
	{
		[CompilerGenerated]
		get
		{
			return _CardLegacyFabricApi;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCard.PreviewSwapEventHandler obj = CardLegacyFabricApi_PreviewSwap;
			MyCard cardLegacyFabricApi = _CardLegacyFabricApi;
			if (cardLegacyFabricApi != null)
			{
				cardLegacyFabricApi.PreviewSwap -= obj;
			}
			_CardLegacyFabricApi = value;
			cardLegacyFabricApi = _CardLegacyFabricApi;
			if (cardLegacyFabricApi != null)
			{
				cardLegacyFabricApi.PreviewSwap += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLegacyFabricApi")]
	internal virtual StackPanel PanLegacyFabricApi
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLegacyFabricApiInfo")]
	internal virtual Grid PanLegacyFabricApiInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgLegacyFabricApi")]
	internal virtual Image ImgLegacyFabricApi
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLegacyFabricApi")]
	internal virtual TextBlock LabLegacyFabricApi
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid BtnLegacyFabricApiClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnLegacyFabricApiClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(LegacyFabricApi_Clear);
			Grid btnLegacyFabricApiClear = _BtnLegacyFabricApiClear;
			if (btnLegacyFabricApiClear != null)
			{
				((UIElement)btnLegacyFabricApiClear).MouseLeftButtonUp -= val;
			}
			_BtnLegacyFabricApiClear = value;
			btnLegacyFabricApiClear = _BtnLegacyFabricApiClear;
			if (btnLegacyFabricApiClear != null)
			{
				((UIElement)btnLegacyFabricApiClear).MouseLeftButtonUp += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnLegacyFabricApiClearInner")]
	internal virtual Path BtnLegacyFabricApiClearInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardQuilt
	{
		[CompilerGenerated]
		get
		{
			return _CardQuilt;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				SelectReload();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardQuilt_PreviewSwap;
			MyCard cardQuilt = _CardQuilt;
			if (cardQuilt != null)
			{
				cardQuilt.Swap -= obj;
				cardQuilt.PreviewSwap -= obj2;
			}
			_CardQuilt = value;
			cardQuilt = _CardQuilt;
			if (cardQuilt != null)
			{
				cardQuilt.Swap += obj;
				cardQuilt.PreviewSwap += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanQuilt")]
	internal virtual StackPanel PanQuilt
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanQuiltInfo")]
	internal virtual Grid PanQuiltInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgQuilt")]
	internal virtual Image ImgQuilt
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabQuilt")]
	internal virtual TextBlock LabQuilt
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid BtnQuiltClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnQuiltClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(Quilt_Clear);
			Grid btnQuiltClear = _BtnQuiltClear;
			if (btnQuiltClear != null)
			{
				((UIElement)btnQuiltClear).MouseLeftButtonUp -= val;
			}
			_BtnQuiltClear = value;
			btnQuiltClear = _BtnQuiltClear;
			if (btnQuiltClear != null)
			{
				((UIElement)btnQuiltClear).MouseLeftButtonUp += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnQuiltClearInner")]
	internal virtual Path BtnQuiltClearInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardQSL
	{
		[CompilerGenerated]
		get
		{
			return _CardQSL;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				SelectReload();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardQSL_PreviewSwap;
			MyCard cardQSL = _CardQSL;
			if (cardQSL != null)
			{
				cardQSL.Swap -= obj;
				cardQSL.PreviewSwap -= obj2;
			}
			_CardQSL = value;
			cardQSL = _CardQSL;
			if (cardQSL != null)
			{
				cardQSL.Swap += obj;
				cardQSL.PreviewSwap += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanQSL")]
	internal virtual StackPanel PanQSL
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanQSLInfo")]
	internal virtual Grid PanQSLInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgQSL")]
	internal virtual Image ImgQSL
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabQSL")]
	internal virtual TextBlock LabQSL
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid BtnQSLClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnQSLClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(QSL_Clear);
			Grid btnQSLClear = _BtnQSLClear;
			if (btnQSLClear != null)
			{
				((UIElement)btnQSLClear).MouseLeftButtonUp -= val;
			}
			_BtnQSLClear = value;
			btnQSLClear = _BtnQSLClear;
			if (btnQSLClear != null)
			{
				((UIElement)btnQSLClear).MouseLeftButtonUp += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnQSLClearInner")]
	internal virtual Path BtnQSLClearInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardLabyMod
	{
		[CompilerGenerated]
		get
		{
			return _CardLabyMod;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				SelectReload();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardLabyMod_PreviewSwap;
			MyCard cardLabyMod = _CardLabyMod;
			if (cardLabyMod != null)
			{
				cardLabyMod.Swap -= obj;
				cardLabyMod.PreviewSwap -= obj2;
			}
			_CardLabyMod = value;
			cardLabyMod = _CardLabyMod;
			if (cardLabyMod != null)
			{
				cardLabyMod.Swap += obj;
				cardLabyMod.PreviewSwap += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLabyMod")]
	internal virtual StackPanel PanLabyMod
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLabyModInfo")]
	internal virtual Grid PanLabyModInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgLabyMod")]
	internal virtual Image ImgLabyMod
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLabyMod")]
	internal virtual TextBlock LabLabyMod
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid BtnLabyModClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnLabyModClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(LabyMod_Clear);
			Grid btnLabyModClear = _BtnLabyModClear;
			if (btnLabyModClear != null)
			{
				((UIElement)btnLabyModClear).MouseLeftButtonUp -= val;
			}
			_BtnLabyModClear = value;
			btnLabyModClear = _BtnLabyModClear;
			if (btnLabyModClear != null)
			{
				((UIElement)btnLabyModClear).MouseLeftButtonUp += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnLabyModClearInner")]
	internal virtual Path BtnLabyModClearInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardOptiFine
	{
		[CompilerGenerated]
		get
		{
			return _CardOptiFine;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				SelectReload();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardOptiFine_PreviewSwap;
			MyCard cardOptiFine = _CardOptiFine;
			if (cardOptiFine != null)
			{
				cardOptiFine.Swap -= obj;
				cardOptiFine.PreviewSwap -= obj2;
			}
			_CardOptiFine = value;
			cardOptiFine = _CardOptiFine;
			if (cardOptiFine != null)
			{
				cardOptiFine.Swap += obj;
				cardOptiFine.PreviewSwap += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanOptiFine")]
	internal virtual StackPanel PanOptiFine
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanOptiFineInfo")]
	internal virtual Grid PanOptiFineInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgOptiFine")]
	internal virtual Image ImgOptiFine
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabOptiFine")]
	internal virtual TextBlock LabOptiFine
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid BtnOptiFineClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnOptiFineClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(OptiFine_Clear);
			Grid btnOptiFineClear = _BtnOptiFineClear;
			if (btnOptiFineClear != null)
			{
				((UIElement)btnOptiFineClear).MouseLeftButtonUp -= val;
			}
			_BtnOptiFineClear = value;
			btnOptiFineClear = _BtnOptiFineClear;
			if (btnOptiFineClear != null)
			{
				((UIElement)btnOptiFineClear).MouseLeftButtonUp += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnOptiFineClearInner")]
	internal virtual Path BtnOptiFineClearInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardOptiFabric
	{
		[CompilerGenerated]
		get
		{
			return _CardOptiFabric;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				SelectReload();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardOptiFabric_PreviewSwap;
			MyCard cardOptiFabric = _CardOptiFabric;
			if (cardOptiFabric != null)
			{
				cardOptiFabric.Swap -= obj;
				cardOptiFabric.PreviewSwap -= obj2;
			}
			_CardOptiFabric = value;
			cardOptiFabric = _CardOptiFabric;
			if (cardOptiFabric != null)
			{
				cardOptiFabric.Swap += obj;
				cardOptiFabric.PreviewSwap += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanOptiFabric")]
	internal virtual StackPanel PanOptiFabric
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanOptiFabricInfo")]
	internal virtual Grid PanOptiFabricInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgOptiFabric")]
	internal virtual Image ImgOptiFabric
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabOptiFabric")]
	internal virtual TextBlock LabOptiFabric
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid BtnOptiFabricClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnOptiFabricClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(OptiFabric_Clear);
			Grid btnOptiFabricClear = _BtnOptiFabricClear;
			if (btnOptiFabricClear != null)
			{
				((UIElement)btnOptiFabricClear).MouseLeftButtonUp -= val;
			}
			_BtnOptiFabricClear = value;
			btnOptiFabricClear = _BtnOptiFabricClear;
			if (btnOptiFabricClear != null)
			{
				((UIElement)btnOptiFabricClear).MouseLeftButtonUp += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnOptiFabricClearInner")]
	internal virtual Path BtnOptiFabricClearInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCard CardLiteLoader
	{
		[CompilerGenerated]
		get
		{
			return _CardLiteLoader;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCard.SwapEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				SelectReload();
			};
			MyCard.PreviewSwapEventHandler obj2 = CardLiteLoader_PreviewSwap;
			MyCard cardLiteLoader = _CardLiteLoader;
			if (cardLiteLoader != null)
			{
				cardLiteLoader.Swap -= obj;
				cardLiteLoader.PreviewSwap -= obj2;
			}
			_CardLiteLoader = value;
			cardLiteLoader = _CardLiteLoader;
			if (cardLiteLoader != null)
			{
				cardLiteLoader.Swap += obj;
				cardLiteLoader.PreviewSwap += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLiteLoader")]
	internal virtual StackPanel PanLiteLoader
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLiteLoaderInfo")]
	internal virtual Grid PanLiteLoaderInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgLiteLoader")]
	internal virtual Image ImgLiteLoader
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLiteLoader")]
	internal virtual TextBlock LabLiteLoader
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid BtnLiteLoaderClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnLiteLoaderClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(LiteLoader_Clear);
			Grid btnLiteLoaderClear = _BtnLiteLoaderClear;
			if (btnLiteLoaderClear != null)
			{
				((UIElement)btnLiteLoaderClear).MouseLeftButtonUp -= val;
			}
			_BtnLiteLoaderClear = value;
			btnLiteLoaderClear = _BtnLiteLoaderClear;
			if (btnLiteLoaderClear != null)
			{
				((UIElement)btnLiteLoaderClear).MouseLeftButtonUp += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnLiteLoaderClearInner")]
	internal virtual Path BtnLiteLoaderClearInner
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyExtraTextButton BtnStart
	{
		[CompilerGenerated]
		get
		{
			return _BtnStart;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyExtraTextButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnStart_Click();
			};
			MyExtraTextButton btnStart = _BtnStart;
			if (btnStart != null)
			{
				btnStart.Click -= obj;
			}
			_BtnStart = value;
			btnStart = _BtnStart;
			if (btnStart != null)
			{
				btnStart.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLoad")]
	internal virtual MyCard PanLoad
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LoadMinecraft")]
	internal virtual MyLoading LoadMinecraft
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyLoading LoadOptiFine
	{
		[CompilerGenerated]
		get
		{
			return _LoadOptiFine;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				SelectReload();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				OptiFine_Loaded();
			};
			MyLoading loadOptiFine = _LoadOptiFine;
			if (loadOptiFine != null)
			{
				loadOptiFine.StateChanged -= obj;
				loadOptiFine.StateChanged -= obj2;
			}
			_LoadOptiFine = value;
			loadOptiFine = _LoadOptiFine;
			if (loadOptiFine != null)
			{
				loadOptiFine.StateChanged += obj;
				loadOptiFine.StateChanged += obj2;
			}
		}
	}

	internal virtual MyLoading LoadForge
	{
		[CompilerGenerated]
		get
		{
			return _LoadForge;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				SelectReload();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				Forge_Loaded();
			};
			MyLoading loadForge = _LoadForge;
			if (loadForge != null)
			{
				loadForge.StateChanged -= obj;
				loadForge.StateChanged -= obj2;
			}
			_LoadForge = value;
			loadForge = _LoadForge;
			if (loadForge != null)
			{
				loadForge.StateChanged += obj;
				loadForge.StateChanged += obj2;
			}
		}
	}

	internal virtual MyLoading LoadNeoForge
	{
		[CompilerGenerated]
		get
		{
			return _LoadNeoForge;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				SelectReload();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				NeoForge_Loaded();
			};
			MyLoading loadNeoForge = _LoadNeoForge;
			if (loadNeoForge != null)
			{
				loadNeoForge.StateChanged -= obj;
				loadNeoForge.StateChanged -= obj2;
			}
			_LoadNeoForge = value;
			loadNeoForge = _LoadNeoForge;
			if (loadNeoForge != null)
			{
				loadNeoForge.StateChanged += obj;
				loadNeoForge.StateChanged += obj2;
			}
		}
	}

	internal virtual MyLoading LoadCleanroom
	{
		[CompilerGenerated]
		get
		{
			return _LoadCleanroom;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				SelectReload();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				Cleanroom_Loaded();
			};
			MyLoading loadCleanroom = _LoadCleanroom;
			if (loadCleanroom != null)
			{
				loadCleanroom.StateChanged -= obj;
				loadCleanroom.StateChanged -= obj2;
			}
			_LoadCleanroom = value;
			loadCleanroom = _LoadCleanroom;
			if (loadCleanroom != null)
			{
				loadCleanroom.StateChanged += obj;
				loadCleanroom.StateChanged += obj2;
			}
		}
	}

	internal virtual MyLoading LoadLiteLoader
	{
		[CompilerGenerated]
		get
		{
			return _LoadLiteLoader;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				SelectReload();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				LiteLoader_Loaded();
			};
			MyLoading loadLiteLoader = _LoadLiteLoader;
			if (loadLiteLoader != null)
			{
				loadLiteLoader.StateChanged -= obj;
				loadLiteLoader.StateChanged -= obj2;
			}
			_LoadLiteLoader = value;
			loadLiteLoader = _LoadLiteLoader;
			if (loadLiteLoader != null)
			{
				loadLiteLoader.StateChanged += obj;
				loadLiteLoader.StateChanged += obj2;
			}
		}
	}

	internal virtual MyLoading LoadFabric
	{
		[CompilerGenerated]
		get
		{
			return _LoadFabric;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				SelectReload();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				Fabric_Loaded();
			};
			MyLoading loadFabric = _LoadFabric;
			if (loadFabric != null)
			{
				loadFabric.StateChanged -= obj;
				loadFabric.StateChanged -= obj2;
			}
			_LoadFabric = value;
			loadFabric = _LoadFabric;
			if (loadFabric != null)
			{
				loadFabric.StateChanged += obj;
				loadFabric.StateChanged += obj2;
			}
		}
	}

	internal virtual MyLoading LoadLegacyFabric
	{
		[CompilerGenerated]
		get
		{
			return _LoadLegacyFabric;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				LegacyFabric_Loaded();
			};
			MyLoading loadLegacyFabric = _LoadLegacyFabric;
			if (loadLegacyFabric != null)
			{
				loadLegacyFabric.StateChanged -= obj;
			}
			_LoadLegacyFabric = value;
			loadLegacyFabric = _LoadLegacyFabric;
			if (loadLegacyFabric != null)
			{
				loadLegacyFabric.StateChanged += obj;
			}
		}
	}

	internal virtual MyLoading LoadFabricApi
	{
		[CompilerGenerated]
		get
		{
			return _LoadFabricApi;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				SelectReload();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				FabricApi_Loaded();
			};
			MyLoading loadFabricApi = _LoadFabricApi;
			if (loadFabricApi != null)
			{
				loadFabricApi.StateChanged -= obj;
				loadFabricApi.StateChanged -= obj2;
			}
			_LoadFabricApi = value;
			loadFabricApi = _LoadFabricApi;
			if (loadFabricApi != null)
			{
				loadFabricApi.StateChanged += obj;
				loadFabricApi.StateChanged += obj2;
			}
		}
	}

	internal virtual MyLoading LoadLegacyFabricApi
	{
		[CompilerGenerated]
		get
		{
			return _LoadLegacyFabricApi;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				LegacyFabricApi_Loaded();
			};
			MyLoading loadLegacyFabricApi = _LoadLegacyFabricApi;
			if (loadLegacyFabricApi != null)
			{
				loadLegacyFabricApi.StateChanged -= obj;
			}
			_LoadLegacyFabricApi = value;
			loadLegacyFabricApi = _LoadLegacyFabricApi;
			if (loadLegacyFabricApi != null)
			{
				loadLegacyFabricApi.StateChanged += obj;
			}
		}
	}

	internal virtual MyLoading LoadQuilt
	{
		[CompilerGenerated]
		get
		{
			return _LoadQuilt;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				SelectReload();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				Quilt_Loaded();
			};
			MyLoading loadQuilt = _LoadQuilt;
			if (loadQuilt != null)
			{
				loadQuilt.StateChanged -= obj;
				loadQuilt.StateChanged -= obj2;
			}
			_LoadQuilt = value;
			loadQuilt = _LoadQuilt;
			if (loadQuilt != null)
			{
				loadQuilt.StateChanged += obj;
				loadQuilt.StateChanged += obj2;
			}
		}
	}

	internal virtual MyLoading LoadQSL
	{
		[CompilerGenerated]
		get
		{
			return _LoadQSL;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				SelectReload();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				QSL_Loaded();
			};
			MyLoading loadQSL = _LoadQSL;
			if (loadQSL != null)
			{
				loadQSL.StateChanged -= obj;
				loadQSL.StateChanged -= obj2;
			}
			_LoadQSL = value;
			loadQSL = _LoadQSL;
			if (loadQSL != null)
			{
				loadQSL.StateChanged += obj;
				loadQSL.StateChanged += obj2;
			}
		}
	}

	internal virtual MyLoading LoadLabyMod
	{
		[CompilerGenerated]
		get
		{
			return _LoadLabyMod;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				SelectReload();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				LabyMod_Loaded();
			};
			MyLoading loadLabyMod = _LoadLabyMod;
			if (loadLabyMod != null)
			{
				loadLabyMod.StateChanged -= obj;
				loadLabyMod.StateChanged -= obj2;
			}
			_LoadLabyMod = value;
			loadLabyMod = _LoadLabyMod;
			if (loadLabyMod != null)
			{
				loadLabyMod.StateChanged += obj;
				loadLabyMod.StateChanged += obj2;
			}
		}
	}

	internal virtual MyLoading LoadOptiFabric
	{
		[CompilerGenerated]
		get
		{
			return _LoadOptiFabric;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				SelectReload();
			};
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				OptiFabric_Loaded();
			};
			MyLoading loadOptiFabric = _LoadOptiFabric;
			if (loadOptiFabric != null)
			{
				loadOptiFabric.StateChanged -= obj;
				loadOptiFabric.StateChanged -= obj2;
			}
			_LoadOptiFabric = value;
			loadOptiFabric = _LoadOptiFabric;
			if (loadOptiFabric != null)
			{
				loadOptiFabric.StateChanged += obj;
				loadOptiFabric.StateChanged += obj2;
			}
		}
	}

	public PageDownloadInstall()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Initialized += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			LoaderInit();
		});
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Init();
		});
		IsLoad = false;
		IsInSelectPage = false;
		IsFirstLoaded = false;
		SelectedOptiFine = null;
		SelectedLoaderName = null;
		SelectedAPIName = null;
		SelectedLiteLoader = null;
		SelectedForge = null;
		SelectedCleanroom = null;
		SelectedNeoForge = null;
		SelectedFabric = null;
		SelectedFabricApi = null;
		SelectedLegacyFabric = null;
		SelectedLegacyFabricApi = null;
		SelectedQuilt = null;
		SelectedQSL = null;
		SelectedLabyModChannel = null;
		SelectedLabyModCommitRef = null;
		SelectedLabyModVersion = null;
		SelectedOptiFabric = null;
		IsReloading = false;
		IsSelectNameEdited = false;
		IsSelectNameChanging = false;
		AutoSelectedFabricApi = false;
		AutoSelectedLegacyFabricApi = false;
		AutoSelectedQSL = false;
		AutoSelectedOptiFabric = false;
		InitializeComponent();
	}

	private void LoaderInit()
	{
		DisabledPageAnimControls.Add((FrameworkElement)(object)BtnStart);
		PageLoaderInit(LoadMinecraft, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanAllBack, null, ModDownload.DlClientListLoader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
		{
			LoadMinecraft_OnFinish();
		});
	}

	private void Init()
	{
		QuickDownloadHack.EnsureMcFolder();
		((ScrollViewer)PanBack).ScrollToHome();
		ModDownload.DlOptiFineListLoader.Start();
		ModDownload.DlLiteLoaderListLoader.Start();
		ModDownload.DlFabricListLoader.Start();
		ModDownload.DlQuiltListLoader.Start();
		ModDownload.DlNeoForgeListLoader.Start();
		ModDownload.DlCleanroomListLoader.Start();
		ModDownload.DlLabyModListLoader.Start();
		ModDownload.DlLegacyFabricListLoader.Start();
		MyTextBox textSelectName = TextSelectName;
		Collection<Validate> obj = new Collection<Validate>();
		obj.Add((Validate)new ValidateFolderName(ModMinecraft.PathMcFolder + "versions"));
		textSelectName.ValidateRules = obj;
		TextSelectName.Validate();
		SelectReload();
		if (!IsLoad)
		{
			IsLoad = true;
			ModDownloadLib.McDownloadForgeRecommendedRefresh();
			LoadOptiFine.State = ModDownload.DlOptiFineListLoader;
			LoadLiteLoader.State = ModDownload.DlLiteLoaderListLoader;
			LoadFabric.State = ModDownload.DlFabricListLoader;
			LoadFabricApi.State = ModDownload.DlFabricApiLoader;
			LoadQuilt.State = ModDownload.DlQuiltListLoader;
			LoadQSL.State = ModDownload.DlQSLLoader;
			LoadNeoForge.State = ModDownload.DlNeoForgeListLoader;
			LoadCleanroom.State = ModDownload.DlCleanroomListLoader;
			LoadOptiFabric.State = ModDownload.DlOptiFabricLoader;
			LoadLabyMod.State = ModDownload.DlLabyModListLoader;
			LoadLegacyFabric.State = ModDownload.DlLegacyFabricListLoader;
			LoadLegacyFabricApi.State = ModDownload.DlLegacyFabricApiLoader;
		}
	}

	private void EnterSelectPage()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Expected O, but got Unknown
		if (IsInSelectPage)
		{
			return;
		}
		IsInSelectPage = true;
		((FrameworkElement)PanInner).Margin = new Thickness(25.0, 10.0, 25.0, 40.0);
		AutoSelectedFabricApi = false;
		AutoSelectedQSL = false;
		AutoSelectedOptiFabric = false;
		IsSelectNameEdited = false;
		((UIElement)PanSelect).Visibility = (Visibility)0;
		((UIElement)PanSelect).IsHitTestVisible = true;
		((UIElement)PanMinecraft).IsHitTestVisible = false;
		((UIElement)PanBack).IsHitTestVisible = false;
		((ScrollViewer)PanBack).ScrollToHome();
		DisabledPageAnimControls.Remove((FrameworkElement)(object)BtnStart);
		BtnStart.Show = true;
		CardOptiFine.IsSwapped = true;
		CardLiteLoader.IsSwapped = true;
		CardForge.IsSwapped = true;
		CardNeoForge.IsSwapped = true;
		CardCleanroom.IsSwapped = true;
		CardFabric.IsSwapped = true;
		CardFabricApi.IsSwapped = true;
		CardQuilt.IsSwapped = true;
		CardQSL.IsSwapped = true;
		CardOptiFabric.IsSwapped = true;
		CardLabyMod.IsSwapped = true;
		if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("HintInstallBack"))))
		{
			ModBase.Setup.Set("HintInstallBack", true);
			ModMain.Hint("点击 Minecraft 项即可返回游戏主版本选择页面！");
		}
		System.Collections.Generic.IEnumerator<FrameworkElement> enumerator = default(System.Collections.Generic.IEnumerator<FrameworkElement>);
		try
		{
			enumerator = GetAllAnimControls((FrameworkElement)(object)PanSelect).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				FrameworkElement current = enumerator.Current;
				((UIElement)current).Opacity = 1.0;
				if (((UIElement)current).RenderTransform == null || ((UIElement)current).RenderTransform is TranslateTransform)
				{
					((UIElement)current).RenderTransform = (Transform)new TranslateTransform();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		if (PCLVerCompat.StartsWithVer2(SelectedMinecraftId, "1."))
		{
			ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = new ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>("DlForgeVersion " + SelectedMinecraftId, ModDownload.DlForgeVersionMain, null, (ThreadPriority)2);
			LoadForge.State = loaderTask;
			loaderTask.Start(SelectedMinecraftId);
		}
		ModDownload.DlFabricApiLoader.Start();
		ModDownload.DlQSLLoader.Start();
		ModDownload.DlLegacyFabricApiLoader.Start();
		ModDownload.DlOptiFabricLoader.Start();
		ModDownload.DlLabyModListLoader.Start();
		ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[6]
		{
			ModAnimation.AaOpacity(PanMinecraft, 0.0 - ((UIElement)PanMinecraft).Opacity, 70, 10),
			ModAnimation.AaTranslateX(PanMinecraft, -50.0 - ((TranslateTransform)((UIElement)PanMinecraft).RenderTransform).X, 90, 10),
			ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
			{
				((ScrollViewer)PanBack).ScrollToHome();
				TextSelectName.Validate();
				OptiFine_Loaded();
				LiteLoader_Loaded();
				Forge_Loaded();
				NeoForge_Loaded();
				Cleanroom_Loaded();
				Fabric_Loaded();
				LegacyFabric_Loaded();
				FabricApi_Loaded();
				LegacyFabricApi_Loaded();
				Quilt_Loaded();
				QSL_Loaded();
				OptiFabric_Loaded();
				LabyMod_Loaded();
				SelectReload();
				((UIElement)PanMinecraft).Visibility = (Visibility)2;
			}), 0, After: true),
			ModAnimation.AaOpacity(PanSelect, 1.0 - ((UIElement)PanSelect).Opacity, 70, 100),
			ModAnimation.AaTranslateX(PanSelect, 0.0 - ((TranslateTransform)((UIElement)PanSelect).RenderTransform).X, 160, 100, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.ExtraStrong)),
			ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
			{
				//IL_002e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0033: Unknown result type (might be due to invalid IL or missing references)
				//IL_0044: Unknown result type (might be due to invalid IL or missing references)
				//IL_0050: Expected O, but got Unknown
				//IL_0061: Unknown result type (might be due to invalid IL or missing references)
				//IL_0066: Unknown result type (might be due to invalid IL or missing references)
				//IL_0077: Unknown result type (might be due to invalid IL or missing references)
				//IL_0083: Expected O, but got Unknown
				//IL_0094: Unknown result type (might be due to invalid IL or missing references)
				//IL_0099: Unknown result type (might be due to invalid IL or missing references)
				//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b6: Expected O, but got Unknown
				//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
				//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
				//IL_00e9: Expected O, but got Unknown
				//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
				//IL_0110: Unknown result type (might be due to invalid IL or missing references)
				//IL_011c: Expected O, but got Unknown
				//IL_012d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0132: Unknown result type (might be due to invalid IL or missing references)
				//IL_0143: Unknown result type (might be due to invalid IL or missing references)
				//IL_014f: Expected O, but got Unknown
				//IL_0160: Unknown result type (might be due to invalid IL or missing references)
				//IL_0165: Unknown result type (might be due to invalid IL or missing references)
				//IL_0176: Unknown result type (might be due to invalid IL or missing references)
				//IL_0182: Expected O, but got Unknown
				//IL_0193: Unknown result type (might be due to invalid IL or missing references)
				//IL_0198: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
				//IL_01b5: Expected O, but got Unknown
				//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
				//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
				//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
				//IL_01e8: Expected O, but got Unknown
				//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
				//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
				//IL_020f: Unknown result type (might be due to invalid IL or missing references)
				//IL_021b: Expected O, but got Unknown
				//IL_022c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0231: Unknown result type (might be due to invalid IL or missing references)
				//IL_0242: Unknown result type (might be due to invalid IL or missing references)
				//IL_024e: Expected O, but got Unknown
				//IL_025f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0264: Unknown result type (might be due to invalid IL or missing references)
				//IL_0275: Unknown result type (might be due to invalid IL or missing references)
				//IL_0281: Expected O, but got Unknown
				//IL_0292: Unknown result type (might be due to invalid IL or missing references)
				//IL_0297: Unknown result type (might be due to invalid IL or missing references)
				//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
				//IL_02b4: Expected O, but got Unknown
				((UIElement)PanBack).IsHitTestVisible = true;
				if (!IsFirstLoaded)
				{
					IsFirstLoaded = true;
					((FrameworkElement)BtnOptiFineClearInner).SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
					{
						Source = CardOptiFine.MainTextBlock,
						Mode = (BindingMode)1
					});
					((FrameworkElement)BtnLiteLoaderClearInner).SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
					{
						Source = CardLiteLoader.MainTextBlock,
						Mode = (BindingMode)1
					});
					((FrameworkElement)BtnForgeClearInner).SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
					{
						Source = CardForge.MainTextBlock,
						Mode = (BindingMode)1
					});
					((FrameworkElement)BtnNeoForgeClearInner).SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
					{
						Source = CardNeoForge.MainTextBlock,
						Mode = (BindingMode)1
					});
					((FrameworkElement)BtnCleanroomClearInner).SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
					{
						Source = CardCleanroom.MainTextBlock,
						Mode = (BindingMode)1
					});
					((FrameworkElement)BtnFabricClearInner).SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
					{
						Source = CardFabric.MainTextBlock,
						Mode = (BindingMode)1
					});
					((FrameworkElement)BtnLegacyFabricClearInner).SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
					{
						Source = CardLegacyFabric.MainTextBlock,
						Mode = (BindingMode)1
					});
					((FrameworkElement)BtnFabricApiClearInner).SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
					{
						Source = CardFabricApi.MainTextBlock,
						Mode = (BindingMode)1
					});
					((FrameworkElement)BtnLegacyFabricApiClearInner).SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
					{
						Source = CardLegacyFabricApi.MainTextBlock,
						Mode = (BindingMode)1
					});
					((FrameworkElement)BtnQuiltClearInner).SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
					{
						Source = CardQuilt.MainTextBlock,
						Mode = (BindingMode)1
					});
					((FrameworkElement)BtnQSLClearInner).SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
					{
						Source = CardQSL.MainTextBlock,
						Mode = (BindingMode)1
					});
					((FrameworkElement)BtnLabyModClearInner).SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
					{
						Source = CardLabyMod.MainTextBlock,
						Mode = (BindingMode)1
					});
					((FrameworkElement)BtnOptiFabricClearInner).SetBinding(Shape.FillProperty, (BindingBase)new Binding("Foreground")
					{
						Source = CardOptiFabric.MainTextBlock,
						Mode = (BindingMode)1
					});
				}
			}), 0, After: true)
		}, "FrmDownloadInstall SelectPageSwitch", RefreshTime: true);
	}

	public void ExitSelectPage()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected O, but got Unknown
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		if (IsInSelectPage)
		{
			IsInSelectPage = false;
			((FrameworkElement)PanInner).Margin = new Thickness(25.0, 10.0, 25.0, 25.0);
			DisabledPageAnimControls.Add((FrameworkElement)(object)BtnStart);
			BtnStart.Show = false;
			SelectClear();
			((UIElement)PanMinecraft).Visibility = (Visibility)0;
			((UIElement)PanSelect).IsHitTestVisible = false;
			((UIElement)PanMinecraft).IsHitTestVisible = true;
			((UIElement)PanBack).IsHitTestVisible = false;
			((ScrollViewer)PanBack).ScrollToHome();
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[6]
			{
				ModAnimation.AaOpacity(PanSelect, 0.0 - ((UIElement)PanSelect).Opacity, 70, 10),
				ModAnimation.AaTranslateX(PanSelect, 50.0 - ((TranslateTransform)((UIElement)PanSelect).RenderTransform).X, 90, 10),
				ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
				{
					((ScrollViewer)PanBack).ScrollToHome();
				}), 0, After: true),
				ModAnimation.AaOpacity(PanMinecraft, 1.0 - ((UIElement)PanMinecraft).Opacity, 70, 100),
				ModAnimation.AaTranslateX(PanMinecraft, 0.0 - ((TranslateTransform)((UIElement)PanMinecraft).RenderTransform).X, 160, 100, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.ExtraStrong)),
				ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
				{
					((UIElement)PanSelect).Visibility = (Visibility)2;
					((UIElement)PanBack).IsHitTestVisible = true;
				}), 0, After: true)
			}, "FrmDownloadInstall SelectPageSwitch");
		}
	}

	public void MinecraftSelected(MyListItem sender, MouseButtonEventArgs e)
	{
		SelectedMinecraftId = sender.Title;
		SelectedMinecraftJsonUrl = NewLateBinding.LateIndexGet(((FrameworkElement)sender).Tag, new object[] { "url" }, (string[])null).ToString();
		SelectedMinecraftIcon = sender.Logo;
		EnterSelectPage();
	}

	private void SetOptiFineInfoShow(string IsShow)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!Operators.ConditionalCompareObjectEqual(((FrameworkElement)PanOptiFineInfo).Tag, (object)IsShow, false))
		{
			((FrameworkElement)PanOptiFineInfo).Tag = IsShow;
			if (Operators.CompareString(IsShow, "True", false) == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanOptiFineInfo, 0.0 - ((TranslateTransform)((UIElement)PanOptiFineInfo).RenderTransform).Y, 200, 100, new ModAnimation.AniEaseOutFluent()),
					ModAnimation.AaOpacity(PanOptiFineInfo, 1.0 - ((UIElement)PanOptiFineInfo).Opacity, 80, 90)
				}, "SetOptiFineInfoShow");
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanOptiFineInfo, 6.0 - ((TranslateTransform)((UIElement)PanOptiFineInfo).RenderTransform).Y, 120),
					ModAnimation.AaOpacity(PanOptiFineInfo, 0.0 - ((UIElement)PanOptiFineInfo).Opacity, 50)
				}, "SetOptiFineInfoShow");
			}
		}
	}

	private void SetLiteLoaderInfoShow(string IsShow)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!Operators.ConditionalCompareObjectEqual(((FrameworkElement)PanLiteLoaderInfo).Tag, (object)IsShow, false))
		{
			((FrameworkElement)PanLiteLoaderInfo).Tag = IsShow;
			if (Operators.CompareString(IsShow, "True", false) == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanLiteLoaderInfo, 0.0 - ((TranslateTransform)((UIElement)PanLiteLoaderInfo).RenderTransform).Y, 200, 100, new ModAnimation.AniEaseOutFluent()),
					ModAnimation.AaOpacity(PanLiteLoaderInfo, 1.0 - ((UIElement)PanLiteLoaderInfo).Opacity, 80, 90)
				}, "SetLiteLoaderInfoShow");
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanLiteLoaderInfo, 6.0 - ((TranslateTransform)((UIElement)PanLiteLoaderInfo).RenderTransform).Y, 120),
					ModAnimation.AaOpacity(PanLiteLoaderInfo, 0.0 - ((UIElement)PanLiteLoaderInfo).Opacity, 50)
				}, "SetLiteLoaderInfoShow");
			}
		}
	}

	private void SetForgeInfoShow(string IsShow)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!Operators.ConditionalCompareObjectEqual(((FrameworkElement)PanForgeInfo).Tag, (object)IsShow, false))
		{
			((FrameworkElement)PanForgeInfo).Tag = IsShow;
			if (Operators.CompareString(IsShow, "True", false) == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanForgeInfo, 0.0 - ((TranslateTransform)((UIElement)PanForgeInfo).RenderTransform).Y, 200, 100, new ModAnimation.AniEaseOutFluent()),
					ModAnimation.AaOpacity(PanForgeInfo, 1.0 - ((UIElement)PanForgeInfo).Opacity, 80, 90)
				}, "SetForgeInfoShow");
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanForgeInfo, 6.0 - ((TranslateTransform)((UIElement)PanForgeInfo).RenderTransform).Y, 120),
					ModAnimation.AaOpacity(PanForgeInfo, 0.0 - ((UIElement)PanForgeInfo).Opacity, 50)
				}, "SetForgeInfoShow");
			}
		}
	}

	private void SetCleanroomInfoShow(string IsShow)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!Operators.ConditionalCompareObjectEqual(((FrameworkElement)PanCleanroomInfo).Tag, (object)IsShow, false))
		{
			((FrameworkElement)PanCleanroomInfo).Tag = IsShow;
			if (Operators.CompareString(IsShow, "True", false) == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanCleanroomInfo, 0.0 - ((TranslateTransform)((UIElement)PanCleanroomInfo).RenderTransform).Y, 270, 100, new ModAnimation.AniEaseOutBack()),
					ModAnimation.AaOpacity(PanCleanroomInfo, 1.0 - ((UIElement)PanCleanroomInfo).Opacity, 100, 90)
				}, "SetCleanroomInfoShow");
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanCleanroomInfo, 6.0 - ((TranslateTransform)((UIElement)PanCleanroomInfo).RenderTransform).Y, 200),
					ModAnimation.AaOpacity(PanCleanroomInfo, 0.0 - ((UIElement)PanCleanroomInfo).Opacity, 100)
				}, "SetCleanroomInfoShow");
			}
		}
	}

	private void SetNeoForgeInfoShow(string IsShow)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!Operators.ConditionalCompareObjectEqual(((FrameworkElement)PanNeoForgeInfo).Tag, (object)IsShow, false))
		{
			((FrameworkElement)PanNeoForgeInfo).Tag = IsShow;
			if (Operators.CompareString(IsShow, "True", false) == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanNeoForgeInfo, 0.0 - ((TranslateTransform)((UIElement)PanNeoForgeInfo).RenderTransform).Y, 200, 100, new ModAnimation.AniEaseOutFluent()),
					ModAnimation.AaOpacity(PanNeoForgeInfo, 1.0 - ((UIElement)PanNeoForgeInfo).Opacity, 80, 90)
				}, "SetNeoForgeInfoShow");
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanNeoForgeInfo, 6.0 - ((TranslateTransform)((UIElement)PanNeoForgeInfo).RenderTransform).Y, 120),
					ModAnimation.AaOpacity(PanNeoForgeInfo, 0.0 - ((UIElement)PanNeoForgeInfo).Opacity, 50)
				}, "SetNeoForgeInfoShow");
			}
		}
	}

	private void SetFabricInfoShow(string IsShow)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!Operators.ConditionalCompareObjectEqual(((FrameworkElement)PanFabricInfo).Tag, (object)IsShow, false))
		{
			((FrameworkElement)PanFabricInfo).Tag = IsShow;
			if (Operators.CompareString(IsShow, "True", false) == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanFabricInfo, 0.0 - ((TranslateTransform)((UIElement)PanFabricInfo).RenderTransform).Y, 200, 100, new ModAnimation.AniEaseOutFluent()),
					ModAnimation.AaOpacity(PanFabricInfo, 1.0 - ((UIElement)PanFabricInfo).Opacity, 80, 90)
				}, "SetFabricInfoShow");
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanFabricInfo, 6.0 - ((TranslateTransform)((UIElement)PanFabricInfo).RenderTransform).Y, 120),
					ModAnimation.AaOpacity(PanFabricInfo, 0.0 - ((UIElement)PanFabricInfo).Opacity, 50)
				}, "SetFabricInfoShow");
			}
		}
	}

	private void SetFabricApiInfoShow(string IsShow)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!Operators.ConditionalCompareObjectEqual(((FrameworkElement)PanFabricApiInfo).Tag, (object)IsShow, false))
		{
			((FrameworkElement)PanFabricApiInfo).Tag = IsShow;
			if (Operators.CompareString(IsShow, "True", false) == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanFabricApiInfo, 0.0 - ((TranslateTransform)((UIElement)PanFabricApiInfo).RenderTransform).Y, 200, 100, new ModAnimation.AniEaseOutFluent()),
					ModAnimation.AaOpacity(PanFabricApiInfo, 1.0 - ((UIElement)PanFabricApiInfo).Opacity, 80, 90)
				}, "SetFabricApiInfoShow");
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanFabricApiInfo, 6.0 - ((TranslateTransform)((UIElement)PanFabricApiInfo).RenderTransform).Y, 120),
					ModAnimation.AaOpacity(PanFabricApiInfo, 0.0 - ((UIElement)PanFabricApiInfo).Opacity, 50)
				}, "SetFabricApiInfoShow");
			}
		}
	}

	private void SetLegacyFabricInfoShow(string IsShow)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!Operators.ConditionalCompareObjectEqual(((FrameworkElement)PanLegacyFabricInfo).Tag, (object)IsShow, false))
		{
			((FrameworkElement)PanLegacyFabricInfo).Tag = IsShow;
			if (Operators.CompareString(IsShow, "True", false) == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanLegacyFabricInfo, 0.0 - ((TranslateTransform)((UIElement)PanLegacyFabricInfo).RenderTransform).Y, 200, 100, new ModAnimation.AniEaseOutFluent()),
					ModAnimation.AaOpacity(PanLegacyFabricInfo, 1.0 - ((UIElement)PanLegacyFabricInfo).Opacity, 80, 90)
				}, "SetLegacyFabricInfoShow");
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanLegacyFabricInfo, 6.0 - ((TranslateTransform)((UIElement)PanLegacyFabricInfo).RenderTransform).Y, 120),
					ModAnimation.AaOpacity(PanLegacyFabricInfo, 0.0 - ((UIElement)PanLegacyFabricInfo).Opacity, 50)
				}, "SetLegacyFabricInfoShow");
			}
		}
	}

	private void SetLegacyFabricApiInfoShow(string IsShow)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!Operators.ConditionalCompareObjectEqual(((FrameworkElement)PanLegacyFabricApiInfo).Tag, (object)IsShow, false))
		{
			((FrameworkElement)PanLegacyFabricApiInfo).Tag = IsShow;
			if (Operators.CompareString(IsShow, "True", false) == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanLegacyFabricApiInfo, 0.0 - ((TranslateTransform)((UIElement)PanLegacyFabricApiInfo).RenderTransform).Y, 200, 100, new ModAnimation.AniEaseOutFluent()),
					ModAnimation.AaOpacity(PanLegacyFabricApiInfo, 1.0 - ((UIElement)PanLegacyFabricApiInfo).Opacity, 80, 90)
				}, "SetFabricApiInfoShow");
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanLegacyFabricApiInfo, 6.0 - ((TranslateTransform)((UIElement)PanLegacyFabricApiInfo).RenderTransform).Y, 120),
					ModAnimation.AaOpacity(PanLegacyFabricApiInfo, 0.0 - ((UIElement)PanLegacyFabricApiInfo).Opacity, 50)
				}, "SetFabricApiInfoShow");
			}
		}
	}

	private void SetQuiltInfoShow(string IsShow)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!Operators.ConditionalCompareObjectEqual(((FrameworkElement)PanQuiltInfo).Tag, (object)IsShow, false))
		{
			((FrameworkElement)PanQuiltInfo).Tag = IsShow;
			if (Operators.CompareString(IsShow, "True", false) == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanQuiltInfo, 0.0 - ((TranslateTransform)((UIElement)PanQuiltInfo).RenderTransform).Y, 270, 100, new ModAnimation.AniEaseOutBack()),
					ModAnimation.AaOpacity(PanQuiltInfo, 1.0 - ((UIElement)PanQuiltInfo).Opacity, 100, 90)
				}, "SetQuiltInfoShow");
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanQuiltInfo, 6.0 - ((TranslateTransform)((UIElement)PanQuiltInfo).RenderTransform).Y, 200),
					ModAnimation.AaOpacity(PanQuiltInfo, 0.0 - ((UIElement)PanQuiltInfo).Opacity, 100)
				}, "SetQuiltInfoShow");
			}
		}
	}

	private void SetQSLInfoShow(string IsShow)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!Operators.ConditionalCompareObjectEqual(((FrameworkElement)PanQSLInfo).Tag, (object)IsShow, false))
		{
			((FrameworkElement)PanQSLInfo).Tag = IsShow;
			if (Operators.CompareString(IsShow, "True", false) == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanQSLInfo, 0.0 - ((TranslateTransform)((UIElement)PanQSLInfo).RenderTransform).Y, 270, 100, new ModAnimation.AniEaseOutBack()),
					ModAnimation.AaOpacity(PanQSLInfo, 1.0 - ((UIElement)PanQSLInfo).Opacity, 100, 90)
				}, "SetQSLInfoShow");
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanQSLInfo, 6.0 - ((TranslateTransform)((UIElement)PanQSLInfo).RenderTransform).Y, 200),
					ModAnimation.AaOpacity(PanQSLInfo, 0.0 - ((UIElement)PanQSLInfo).Opacity, 100)
				}, "SetQSLInfoShow");
			}
		}
	}

	private void SetLabyModInfoShow(string IsShow)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!Operators.ConditionalCompareObjectEqual(((FrameworkElement)PanLabyModInfo).Tag, (object)IsShow, false))
		{
			((FrameworkElement)PanLabyModInfo).Tag = IsShow;
			if (Operators.CompareString(IsShow, "True", false) == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanLabyModInfo, 0.0 - ((TranslateTransform)((UIElement)PanLabyModInfo).RenderTransform).Y, 270, 100, new ModAnimation.AniEaseOutBack()),
					ModAnimation.AaOpacity(PanLabyModInfo, 1.0 - ((UIElement)PanLabyModInfo).Opacity, 100, 90)
				}, "SetLabyModInfoShow");
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanLabyModInfo, 6.0 - ((TranslateTransform)((UIElement)PanLabyModInfo).RenderTransform).Y, 200),
					ModAnimation.AaOpacity(PanLabyModInfo, 0.0 - ((UIElement)PanLabyModInfo).Opacity, 100)
				}, "SetLabyModInfoShow");
			}
		}
	}

	private void SetOptiFabricInfoShow(string IsShow)
	{
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (!Operators.ConditionalCompareObjectEqual(((FrameworkElement)PanOptiFabricInfo).Tag, (object)IsShow, false))
		{
			((FrameworkElement)PanOptiFabricInfo).Tag = IsShow;
			if (Operators.CompareString(IsShow, "True", false) == 0)
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanOptiFabricInfo, 0.0 - ((TranslateTransform)((UIElement)PanOptiFabricInfo).RenderTransform).Y, 200, 100, new ModAnimation.AniEaseOutFluent()),
					ModAnimation.AaOpacity(PanOptiFabricInfo, 1.0 - ((UIElement)PanOptiFabricInfo).Opacity, 80, 90)
				}, "SetOptiFabricInfoShow");
			}
			else
			{
				ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[2]
				{
					ModAnimation.AaTranslateY(PanOptiFabricInfo, 6.0 - ((TranslateTransform)((UIElement)PanOptiFabricInfo).RenderTransform).Y, 120),
					ModAnimation.AaOpacity(PanOptiFabricInfo, 0.0 - ((UIElement)PanOptiFabricInfo).Opacity, 50)
				}, "SetOptiFabricInfoShow");
			}
		}
	}

	private void SelectReload()
	{
		//IL_0f7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f83: Unknown result type (might be due to invalid IL or missing references)
		if (SelectedMinecraftId == null || IsReloading)
		{
			return;
		}
		IsReloading = true;
		SelectNameUpdate();
		ImgLogo.Source = GetSelectLogo();
		string text = LoadOptiFineGetError();
		((UIElement)CardOptiFine.MainSwap).Visibility = (Visibility)((text != null) ? 2 : 0);
		if (text != null)
		{
			CardOptiFine.IsSwapped = true;
		}
		SetOptiFineInfoShow(Conversions.ToString(CardOptiFine.IsSwapped));
		if (SelectedOptiFine == null)
		{
			((UIElement)BtnOptiFineClear).Visibility = (Visibility)2;
			((UIElement)ImgOptiFine).Visibility = (Visibility)2;
			LabOptiFine.Text = text ?? "可以添加";
			LabOptiFine.Foreground = ModSecret.ColorGray4;
		}
		else
		{
			((UIElement)BtnOptiFineClear).Visibility = (Visibility)0;
			((UIElement)ImgOptiFine).Visibility = (Visibility)0;
			LabOptiFine.Text = SelectedOptiFine.NameDisplay.Replace(SelectedMinecraftId + " ", "");
			LabOptiFine.Foreground = ModSecret.ColorGray1;
		}
		if (!SelectedMinecraftId.Contains("1.") || ModBase.Val(SelectedMinecraftId.Split(".", (StringSplitOptions)0)[1]) > 12.0)
		{
			((UIElement)CardLiteLoader).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)CardLiteLoader).Visibility = (Visibility)0;
			string text2 = LoadLiteLoaderGetError();
			((UIElement)CardLiteLoader.MainSwap).Visibility = (Visibility)((text2 != null) ? 2 : 0);
			if (text2 != null)
			{
				CardLiteLoader.IsSwapped = true;
			}
			SetLiteLoaderInfoShow(Conversions.ToString(CardLiteLoader.IsSwapped));
			if (SelectedLiteLoader == null)
			{
				((UIElement)BtnLiteLoaderClear).Visibility = (Visibility)2;
				((UIElement)ImgLiteLoader).Visibility = (Visibility)2;
				LabLiteLoader.Text = text2 ?? "可以添加";
				LabLiteLoader.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				((UIElement)BtnLiteLoaderClear).Visibility = (Visibility)0;
				((UIElement)ImgLiteLoader).Visibility = (Visibility)0;
				LabLiteLoader.Text = SelectedLiteLoader.Inherit;
				LabLiteLoader.Foreground = ModSecret.ColorGray1;
			}
		}
		string text3 = LoadForgeGetError();
		((UIElement)CardForge.MainSwap).Visibility = (Visibility)((text3 != null) ? 2 : 0);
		if (text3 != null)
		{
			CardForge.IsSwapped = true;
		}
		SetForgeInfoShow(Conversions.ToString(CardForge.IsSwapped));
		if (SelectedForge == null)
		{
			((UIElement)BtnForgeClear).Visibility = (Visibility)2;
			((UIElement)ImgForge).Visibility = (Visibility)2;
			LabForge.Text = text3 ?? "可以添加";
			LabForge.Foreground = ModSecret.ColorGray4;
		}
		else
		{
			((UIElement)BtnForgeClear).Visibility = (Visibility)0;
			((UIElement)ImgForge).Visibility = (Visibility)0;
			LabForge.Text = SelectedForge.VersionName;
			LabForge.Foreground = ModSecret.ColorGray1;
		}
		if (Operators.CompareString(SelectedMinecraftId, "1.12.2", false) == 0)
		{
			((UIElement)CardCleanroom).Visibility = (Visibility)0;
			string text4 = LoadCleanroomGetError();
			((UIElement)CardCleanroom.MainSwap).Visibility = (Visibility)((text4 != null) ? 2 : 0);
			if (text4 != null)
			{
				CardCleanroom.IsSwapped = true;
			}
			SetCleanroomInfoShow(Conversions.ToString(CardCleanroom.IsSwapped));
			if (SelectedCleanroom == null)
			{
				((UIElement)BtnCleanroomClear).Visibility = (Visibility)2;
				((UIElement)ImgCleanroom).Visibility = (Visibility)2;
				LabCleanroom.Text = text4 ?? "可以添加";
				LabCleanroom.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				((UIElement)BtnCleanroomClear).Visibility = (Visibility)0;
				((UIElement)ImgCleanroom).Visibility = (Visibility)0;
				LabCleanroom.Text = SelectedCleanroom.VersionName;
				LabCleanroom.Foreground = ModSecret.ColorGray1;
			}
		}
		else
		{
			((UIElement)CardCleanroom).Visibility = (Visibility)2;
		}
		if (!SelectedMinecraftId.Contains("1.") || ModBase.Val(SelectedMinecraftId.Split(".", (StringSplitOptions)0)[1]) <= 19.0)
		{
			((UIElement)CardNeoForge).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)CardNeoForge).Visibility = (Visibility)0;
			string text5 = LoadNeoForgeGetError();
			((UIElement)CardNeoForge.MainSwap).Visibility = (Visibility)((text5 != null) ? 2 : 0);
			if (text5 != null)
			{
				CardNeoForge.IsSwapped = true;
			}
			SetNeoForgeInfoShow(Conversions.ToString(CardNeoForge.IsSwapped));
			if (SelectedNeoForge == null)
			{
				((UIElement)BtnNeoForgeClear).Visibility = (Visibility)2;
				((UIElement)ImgNeoForge).Visibility = (Visibility)2;
				LabNeoForge.Text = text5 ?? "可以添加";
				LabNeoForge.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				((UIElement)BtnNeoForgeClear).Visibility = (Visibility)0;
				((UIElement)ImgNeoForge).Visibility = (Visibility)0;
				LabNeoForge.Text = SelectedNeoForge.VersionName;
				LabNeoForge.Foreground = ModSecret.ColorGray1;
			}
		}
		if (SelectedMinecraftId.Contains("1.") && ModBase.Val(SelectedMinecraftId.Split(".", (StringSplitOptions)0)[1]) <= 13.0)
		{
			((UIElement)CardFabric).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)CardFabric).Visibility = (Visibility)0;
			string text6 = LoadFabricGetError();
			((UIElement)CardFabric.MainSwap).Visibility = (Visibility)((text6 != null) ? 2 : 0);
			if (text6 != null)
			{
				CardFabric.IsSwapped = true;
			}
			SetFabricInfoShow(Conversions.ToString(CardFabric.IsSwapped));
			if (SelectedFabric == null)
			{
				((UIElement)BtnFabricClear).Visibility = (Visibility)2;
				((UIElement)ImgFabric).Visibility = (Visibility)2;
				LabFabric.Text = text6 ?? "可以添加";
				LabFabric.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				((UIElement)BtnFabricClear).Visibility = (Visibility)0;
				((UIElement)ImgFabric).Visibility = (Visibility)0;
				LabFabric.Text = SelectedFabric.Replace("+build", "");
				LabFabric.Foreground = ModSecret.ColorGray1;
			}
		}
		if (SelectedFabric == null && SelectedQuilt == null)
		{
			((UIElement)CardFabricApi).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)CardFabricApi).Visibility = (Visibility)0;
			string text7 = LoadFabricApiGetError();
			((UIElement)CardFabricApi.MainSwap).Visibility = (Visibility)((text7 != null) ? 2 : 0);
			if (text7 != null || (SelectedFabric == null && SelectedQuilt == null))
			{
				CardFabricApi.IsSwapped = true;
			}
			SetFabricApiInfoShow(Conversions.ToString(CardFabricApi.IsSwapped));
			if (SelectedFabricApi == null)
			{
				((UIElement)BtnFabricApiClear).Visibility = (Visibility)2;
				((UIElement)ImgFabricApi).Visibility = (Visibility)2;
				LabFabricApi.Text = text7 ?? "可以添加";
				LabFabricApi.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				((UIElement)BtnFabricApiClear).Visibility = (Visibility)0;
				((UIElement)ImgFabricApi).Visibility = (Visibility)0;
				LabFabricApi.Text = Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)SelectedFabricApi.DisplayName.Split("]", (StringSplitOptions)0)[1].Replace("Fabric API ", "").Replace(" build ", ".").Split("+", (StringSplitOptions)0)).Trim();
				LabFabricApi.Foreground = ModSecret.ColorGray1;
			}
		}
		if (SelectedMinecraftId.Contains("1.") && ModBase.Val(SelectedMinecraftId.Split(".", (StringSplitOptions)0)[1]) > 13.0)
		{
			((UIElement)CardLegacyFabric).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)CardLegacyFabric).Visibility = (Visibility)0;
			string text8 = LoadLegacyFabricGetError();
			((UIElement)CardLegacyFabric.MainSwap).Visibility = (Visibility)((text8 != null) ? 2 : 0);
			if (text8 != null)
			{
				CardLegacyFabric.IsSwapped = true;
			}
			SetLegacyFabricInfoShow(Conversions.ToString(CardLegacyFabric.IsSwapped));
			if (SelectedLegacyFabric == null)
			{
				((UIElement)BtnLegacyFabricClear).Visibility = (Visibility)2;
				((UIElement)ImgLegacyFabric).Visibility = (Visibility)2;
				LabLegacyFabric.Text = text8 ?? "可以添加";
				LabLegacyFabric.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				((UIElement)BtnLegacyFabricClear).Visibility = (Visibility)0;
				((UIElement)ImgLegacyFabric).Visibility = (Visibility)0;
				LabLegacyFabric.Text = SelectedLegacyFabric.Replace("+build", "");
				LabLegacyFabric.Foreground = ModSecret.ColorGray1;
			}
		}
		if (SelectedLegacyFabric == null && SelectedQuilt == null)
		{
			((UIElement)CardLegacyFabricApi).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)CardLegacyFabricApi).Visibility = (Visibility)0;
			string text9 = LoadLegacyFabricApiGetError();
			((UIElement)CardLegacyFabricApi.MainSwap).Visibility = (Visibility)((text9 != null) ? 2 : 0);
			if (text9 != null || (SelectedLegacyFabric == null && SelectedQuilt == null))
			{
				CardLegacyFabricApi.IsSwapped = true;
			}
			SetLegacyFabricApiInfoShow(Conversions.ToString(CardLegacyFabricApi.IsSwapped));
			if (SelectedLegacyFabricApi == null)
			{
				((UIElement)BtnLegacyFabricApiClear).Visibility = (Visibility)2;
				((UIElement)ImgLegacyFabricApi).Visibility = (Visibility)2;
				LabLegacyFabricApi.Text = text9 ?? "可以添加";
				LabLegacyFabricApi.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				((UIElement)BtnLegacyFabricApiClear).Visibility = (Visibility)0;
				((UIElement)ImgLegacyFabricApi).Visibility = (Visibility)0;
				LabLegacyFabricApi.Text = SelectedLegacyFabricApi.DisplayName.Replace("Legacy Fabric API ", "");
				LabLegacyFabricApi.Foreground = ModSecret.ColorGray1;
			}
		}
		if (SelectedMinecraftId.Contains("1.") && ModBase.Val(SelectedMinecraftId.Split(".", (StringSplitOptions)0)[1]) <= 14.0 && !SelectedMinecraftId.Contains("1.14.4"))
		{
			((UIElement)CardQuilt).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)CardQuilt).Visibility = (Visibility)0;
			string text10 = LoadQuiltGetError();
			((UIElement)CardQuilt.MainSwap).Visibility = (Visibility)((text10 != null) ? 2 : 0);
			if (text10 != null)
			{
				CardQuilt.IsSwapped = true;
			}
			SetQuiltInfoShow(Conversions.ToString(CardQuilt.IsSwapped));
			if (SelectedQuilt == null)
			{
				((UIElement)BtnQuiltClear).Visibility = (Visibility)2;
				((UIElement)ImgQuilt).Visibility = (Visibility)2;
				LabQuilt.Text = text10 ?? "可以添加";
				LabQuilt.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				((UIElement)BtnQuiltClear).Visibility = (Visibility)0;
				((UIElement)ImgQuilt).Visibility = (Visibility)0;
				LabQuilt.Text = SelectedQuilt.Replace("+build", "");
				LabQuilt.Foreground = ModSecret.ColorGray1;
			}
		}
		if (SelectedQuilt == null)
		{
			((UIElement)CardQSL).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)CardQSL).Visibility = (Visibility)0;
			string text11 = LoadQSLGetError();
			((UIElement)CardQSL.MainSwap).Visibility = (Visibility)((text11 != null) ? 2 : 0);
			if (text11 != null || SelectedQuilt == null)
			{
				CardQSL.IsSwapped = true;
			}
			SetQSLInfoShow(Conversions.ToString(CardQSL.IsSwapped));
			if (SelectedQSL == null)
			{
				((UIElement)BtnQSLClear).Visibility = (Visibility)2;
				((UIElement)ImgQSL).Visibility = (Visibility)2;
				LabQSL.Text = text11 ?? "可以添加";
				LabQSL.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				((UIElement)BtnQSLClear).Visibility = (Visibility)0;
				((UIElement)ImgQSL).Visibility = (Visibility)0;
				LabQSL.Text = SelectedQSL.DisplayName.Split("]", (StringSplitOptions)0)[1].Trim();
				LabQSL.Foreground = ModSecret.ColorGray1;
			}
		}
		if (SelectedMinecraftId.Contains("1.") && ModBase.Val(SelectedMinecraftId.Split(".", (StringSplitOptions)0)[1]) < 8.0)
		{
			((UIElement)CardLabyMod).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)CardLabyMod).Visibility = (Visibility)0;
			string text12 = LoadLabyModGetError();
			((UIElement)CardLabyMod.MainSwap).Visibility = (Visibility)((text12 != null) ? 2 : 0);
			if (text12 != null)
			{
				CardLabyMod.IsSwapped = true;
			}
			SetLabyModInfoShow(Conversions.ToString(CardLabyMod.IsSwapped));
			if (SelectedLabyModVersion == null)
			{
				((UIElement)BtnLabyModClear).Visibility = (Visibility)2;
				((UIElement)ImgLabyMod).Visibility = (Visibility)2;
				LabLabyMod.Text = text12 ?? "可以添加";
				LabLabyMod.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				((UIElement)BtnLabyModClear).Visibility = (Visibility)0;
				((UIElement)ImgLabyMod).Visibility = (Visibility)0;
				LabLabyMod.Text = SelectedLabyModVersion;
				LabLabyMod.Foreground = ModSecret.ColorGray1;
			}
		}
		if (SelectedFabric == null || SelectedOptiFine == null)
		{
			((UIElement)CardOptiFabric).Visibility = (Visibility)2;
		}
		else
		{
			((UIElement)CardOptiFabric).Visibility = (Visibility)0;
			string text13 = LoadOptiFabricGetError();
			((UIElement)CardOptiFabric.MainSwap).Visibility = (Visibility)((text13 != null) ? 2 : 0);
			if (text13 != null || SelectedFabric == null)
			{
				CardOptiFabric.IsSwapped = true;
			}
			SetOptiFabricInfoShow(Conversions.ToString(CardOptiFabric.IsSwapped));
			if (SelectedOptiFabric == null)
			{
				((UIElement)BtnOptiFabricClear).Visibility = (Visibility)2;
				((UIElement)ImgOptiFabric).Visibility = (Visibility)2;
				LabOptiFabric.Text = text13 ?? "可以添加";
				LabOptiFabric.Foreground = ModSecret.ColorGray4;
			}
			else
			{
				((UIElement)BtnOptiFabricClear).Visibility = (Visibility)0;
				((UIElement)ImgOptiFabric).Visibility = (Visibility)0;
				LabOptiFabric.Text = SelectedOptiFabric.DisplayName.ToLower().Replace("optifabric-", "").Replace(".jar", "")
					.Trim()
					.TrimStart('v');
				LabOptiFabric.Foreground = ModSecret.ColorGray1;
			}
		}
		if (SelectedFabric != null && SelectedFabricApi == null)
		{
			((UIElement)HintFabricAPI).Visibility = (Visibility)0;
		}
		else
		{
			((UIElement)HintFabricAPI).Visibility = (Visibility)2;
		}
		if (SelectedLegacyFabric != null && SelectedLegacyFabricApi == null)
		{
			((UIElement)HintLegacyFabricAPI).Visibility = (Visibility)0;
		}
		else
		{
			((UIElement)HintLegacyFabricAPI).Visibility = (Visibility)2;
		}
		if (SelectedQuilt != null && SelectedQSL == null && SelectedFabricApi == null)
		{
			((UIElement)HintQSL).Visibility = (Visibility)0;
		}
		else
		{
			((UIElement)HintQSL).Visibility = (Visibility)2;
		}
		if (SelectedQuilt != null && SelectedFabricApi != null && ModDownload.DlQSLLoader.Output != null)
		{
			System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
			try
			{
				enumerator = ModDownload.DlQSLLoader.Output.GetEnumerator();
				while (enumerator.MoveNext())
				{
					if (IsSuitableQSL(enumerator.Current.GameVersions, SelectedMinecraftId))
					{
						((UIElement)HintQuiltFabricAPI).Visibility = (Visibility)0;
						break;
					}
					((UIElement)HintQuiltFabricAPI).Visibility = (Visibility)2;
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		else
		{
			((UIElement)HintQuiltFabricAPI).Visibility = (Visibility)2;
		}
		if (((SelectedFabric != null) | (SelectedLegacyFabric != null)) && SelectedOptiFine != null && SelectedOptiFabric == null)
		{
			if (SelectedMinecraftId.StartsWith("1.14") || SelectedMinecraftId.StartsWith("1.15"))
			{
				((UIElement)HintOptiFabric).Visibility = (Visibility)2;
				((UIElement)HintLegacyOptiFabric).Visibility = (Visibility)2;
				((UIElement)HintOptiFabricOld).Visibility = (Visibility)0;
			}
			else if (SelectedLegacyFabric != null)
			{
				((UIElement)HintOptiFabric).Visibility = (Visibility)2;
				((UIElement)HintLegacyOptiFabric).Visibility = (Visibility)0;
				((UIElement)HintOptiFabricOld).Visibility = (Visibility)2;
			}
			else
			{
				((UIElement)HintOptiFabric).Visibility = (Visibility)0;
				((UIElement)HintOptiFabricOld).Visibility = (Visibility)2;
				((UIElement)HintLegacyOptiFabric).Visibility = (Visibility)2;
			}
		}
		else
		{
			((UIElement)HintOptiFabric).Visibility = (Visibility)2;
			((UIElement)HintOptiFabricOld).Visibility = (Visibility)2;
			((UIElement)HintLegacyOptiFabric).Visibility = (Visibility)2;
		}
		if (SelectedMinecraftId.Contains("1.") && ModBase.Val(SelectedMinecraftId.Split(".", (StringSplitOptions)0)[1]) >= 16.0 && SelectedOptiFine != null && (SelectedForge != null || SelectedFabric != null))
		{
			((UIElement)HintModOptiFine).Visibility = (Visibility)0;
		}
		else
		{
			((UIElement)HintModOptiFine).Visibility = (Visibility)2;
		}
		IsReloading = false;
	}

	private void SelectClear()
	{
		SelectedMinecraftId = null;
		SelectedMinecraftJsonUrl = null;
		SelectedMinecraftIcon = null;
		SelectedOptiFine = null;
		SelectedLiteLoader = null;
		SelectedLoaderName = null;
		SelectedAPIName = null;
		SelectedForge = null;
		SelectedNeoForge = null;
		SelectedCleanroom = null;
		SelectedFabric = null;
		SelectedFabricApi = null;
		SelectedQuilt = null;
		SelectedQSL = null;
		SelectedOptiFabric = null;
		SelectedLabyModCommitRef = null;
		SelectedLabyModVersion = null;
		SelectedLabyModChannel = null;
		SelectedLegacyFabric = null;
		SelectedLegacyFabricApi = null;
	}

	private string GetSelectLogo()
	{
		if (SelectedFabric != null)
		{
			return "pack://application:,,,/images/Blocks/Fabric.png";
		}
		if (SelectedLegacyFabric != null)
		{
			return "pack://application:,,,/images/Blocks/Fabric.png";
		}
		if (SelectedForge != null)
		{
			return "pack://application:,,,/images/Blocks/Anvil.png";
		}
		if (SelectedNeoForge != null)
		{
			return "pack://application:,,,/images/Blocks/NeoForge.png";
		}
		if (SelectedLiteLoader != null)
		{
			return "pack://application:,,,/images/Blocks/Egg.png";
		}
		if (SelectedOptiFine != null)
		{
			return "pack://application:,,,/images/Blocks/GrassPath.png";
		}
		if (SelectedQuilt != null)
		{
			return "pack://application:,,,/images/Blocks/Quilt.png";
		}
		if (SelectedCleanroom != null)
		{
			return "pack://application:,,,/images/Blocks/Cleanroom.png";
		}
		if (SelectedLabyModVersion != null)
		{
			return "pack://application:,,,/images/Blocks/LabyMod.png";
		}
		return SelectedMinecraftIcon;
	}

	private string GetSelectName()
	{
		string text = SelectedMinecraftId;
		if (SelectedFabric != null)
		{
			text = text + "-Fabric_" + SelectedFabric.Replace("+build", "");
		}
		if (SelectedLegacyFabric != null)
		{
			text = text + "-LegacyFabric_" + SelectedLegacyFabric;
		}
		if (SelectedQuilt != null)
		{
			text = text + "-Quilt_" + SelectedQuilt;
		}
		if (SelectedLabyModVersion != null)
		{
			text = text + "-LabyMod_" + SelectedLabyModVersion.Replace(" 稳定版", "_Production").Replace(" 快照版", "_Snapshot");
		}
		if (SelectedForge != null)
		{
			text = text + "-Forge_" + SelectedForge.VersionName;
		}
		if (SelectedNeoForge != null)
		{
			text = text + "-NeoForge_" + SelectedNeoForge.VersionName;
		}
		if (SelectedCleanroom != null)
		{
			text = text + "-Cleanroom_" + SelectedCleanroom.VersionName;
		}
		if (SelectedLiteLoader != null)
		{
			text += "-LiteLoader";
		}
		if (SelectedOptiFine != null)
		{
			text = text + "-OptiFine_" + SelectedOptiFine.NameDisplay.Replace(SelectedMinecraftId + " ", "").Replace(" ", "_");
		}
		return text;
	}

	private void SelectNameUpdate()
	{
		if (!IsSelectNameEdited && !IsSelectNameChanging)
		{
			IsSelectNameChanging = true;
			((TextBox)TextSelectName).Text = GetSelectName();
			IsSelectNameChanging = false;
		}
	}

	private void TextSelectName_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (!IsSelectNameChanging)
		{
			IsSelectNameEdited = true;
			SelectReload();
		}
	}

	private void TextSelectName_ValidateChanged(object sender, EventArgs e)
	{
		((UIElement)BtnStart).IsEnabled = TextSelectName.IsValidated;
	}

	private void LoadMinecraft_OnFinish()
	{
		//IL_05f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_080b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0815: Expected O, but got Unknown
		//IL_0815: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Expected O, but got Unknown
		//IL_0884: Unknown result type (might be due to invalid IL or missing references)
		//IL_0889: Unknown result type (might be due to invalid IL or missing references)
		//IL_0892: Unknown result type (might be due to invalid IL or missing references)
		//IL_0897: Unknown result type (might be due to invalid IL or missing references)
		//IL_0901: Unknown result type (might be due to invalid IL or missing references)
		//IL_090d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Unknown result type (might be due to invalid IL or missing references)
		//IL_0937: Unknown result type (might be due to invalid IL or missing references)
		//IL_0941: Unknown result type (might be due to invalid IL or missing references)
		//IL_0948: Unknown result type (might be due to invalid IL or missing references)
		//IL_095b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0965: Expected O, but got Unknown
		//IL_0965: Unknown result type (might be due to invalid IL or missing references)
		//IL_0974: Expected O, but got Unknown
		ExitSelectPage();
		try
		{
			Dictionary<string, List<JObject>> obj = new Dictionary<string, List<JObject>>();
			obj.Add("正式版", new List<JObject>());
			obj.Add("预览版", new List<JObject>());
			obj.Add("远古版", new List<JObject>());
			obj.Add("愚人节版", new List<JObject>());
			Dictionary<string, List<JObject>> val = obj;
			JArray jArray = (JArray)ModDownload.DlClientListLoader.Output.Value["versions"];
			System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator = jArray.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					JObject jObject = (JObject)enumerator.Current;
					string text = jObject["type"].ToString();
					string text2 = jObject["id"].ToString().ToLower();
					switch (text)
					{
					case "release":
						text = "正式版";
						break;
					case "snapshot":
					case "pending":
						text = "预览版";
						if (text2.StartsWith("1.") && !text2.Contains("combat") && !text2.Contains("rc") && !text2.Contains("experimental") && !text2.Equals("1.2") && !text2.Contains("pre"))
						{
							text = "正式版";
							jObject["type"] = "release";
						}
						switch (jObject["id"].ToString().ToLower())
						{
						case "2point0_blue":
						case "2point0_red":
						case "2point0_purple":
						case "2.0_blue":
						case "2.0_red":
						case "2.0_purple":
						case "2.0":
							text = "愚人节版";
							jObject["id"] = jObject["id"].ToString().Replace("point", ".");
							jObject["type"] = "special";
							jObject.Add("lore", ModMinecraft.GetMcFoolName((string?)jObject["id"]));
							break;
						case "20w14infinite":
						case "20w14∞":
							text = "愚人节版";
							jObject["id"] = "20w14∞";
							jObject["type"] = "special";
							jObject.Add("lore", ModMinecraft.GetMcFoolName((string?)jObject["id"]));
							break;
						case "3d shareware v1.34":
						case "1.rv-pre1":
						case "15w14a":
						case "22w13oneblockatatime":
						case "23w13a_or_b":
						case "24w14potato":
						case "25w14craftmine":
							text = "愚人节版";
							jObject["type"] = "special";
							jObject.Add("lore", ModMinecraft.GetMcFoolName((string?)jObject["id"]));
							break;
						default:
						{
							System.DateTime dateTime = jObject["releaseTime"].Value<System.DateTime>().ToUniversalTime().AddHours(2.0);
							if (dateTime.Month == 4 && dateTime.Day == 1)
							{
								text = "愚人节版";
								jObject["type"] = "special";
							}
							break;
						}
						}
						break;
					case "special":
						text = "愚人节版";
						break;
					default:
						text = "远古版";
						break;
					}
					val[text].Add(jObject);
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<JObject>>> enumerator2 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<JObject>>>);
			try
			{
				enumerator2 = Enumerable.ToList<KeyValuePair<string, List<JObject>>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, List<JObject>>>)val).GetEnumerator();
				while (enumerator2.MoveNext())
				{
					KeyValuePair<string, List<JObject>> current = enumerator2.Current;
					val[current.Key] = Enumerable.ToList<JObject>((System.Collections.Generic.IEnumerable<JObject>)Enumerable.OrderByDescending<JObject, System.DateTime>((System.Collections.Generic.IEnumerable<JObject>)current.Value, (_Closure_0024__._0024I53_002D0 == null) ? (_Closure_0024__._0024I53_002D0 = [SpecialName] (JObject j) => j["releaseTime"].Value<System.DateTime>()) : _Closure_0024__._0024I53_002D0));
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			((Panel)PanMinecraft).Children.Clear();
			MyCard obj2 = new MyCard
			{
				Title = "最新版本"
			};
			((FrameworkElement)obj2).Margin = new Thickness(0.0, 15.0, 0.0, 15.0);
			MyCard myCard = obj2;
			List<JObject> val2 = new List<JObject>();
			JObject jObject2 = (JObject)val["正式版"][0].DeepClone();
			jObject2["lore"] = "最新正式版，发布于 " + jObject2["releaseTime"].Value<System.DateTime>().ToString("yyyy'/'MM'/'dd HH':'mm");
			val2.Add(jObject2);
			if (System.DateTime.Compare(val["正式版"][0]["releaseTime"].Value<System.DateTime>(), val["预览版"][0]["releaseTime"].Value<System.DateTime>()) < 0)
			{
				JObject jObject3 = (JObject)val["预览版"][0].DeepClone();
				jObject3["lore"] = "最新预览版，发布于 " + jObject3["releaseTime"].Value<System.DateTime>().ToString("yyyy'/'MM'/'dd HH':'mm");
				val2.Add(jObject3);
			}
			StackPanel Stack2 = new StackPanel
			{
				Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
				VerticalAlignment = (VerticalAlignment)0,
				RenderTransform = (Transform)new TranslateTransform(0.0, 0.0),
				Tag = val2
			};
			VB_0024AnonymousDelegate_15<StackPanel> vB_0024AnonymousDelegate_ = [SpecialName] (StackPanel Stack) =>
			{
				foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					((Panel)Stack).Children.Add((UIElement)(object)ModDownloadLib.McDownloadListItem((JObject)objectValue, (_Closure_0024__._0024I53_002D2 == null) ? (_Closure_0024__._0024I53_002D2 = [SpecialName] (object sender, MouseButtonEventArgs e) =>
					{
						ModMain.FrmDownloadInstall.MinecraftSelected((MyListItem)sender, e);
					}) : _Closure_0024__._0024I53_002D2, IsSaveOnly: false));
				}
			};
			VB_0024AnonymousDelegate_15<StackPanel> vB_0024AnonymousDelegate_2 = vB_0024AnonymousDelegate_;
			MyCard.StackInstall(ref Stack2, (vB_0024AnonymousDelegate_2 == null) ? null : new Action<StackPanel>(vB_0024AnonymousDelegate_2.Invoke));
			((Panel)myCard).Children.Add((UIElement)(object)Stack2);
			((Panel)PanMinecraft).Children.Insert(0, (UIElement)(object)myCard);
			System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<JObject>>> enumerator3 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<JObject>>>);
			try
			{
				enumerator3 = val.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					KeyValuePair<string, List<JObject>> current2 = enumerator3.Current;
					if (Enumerable.Any<JObject>((System.Collections.Generic.IEnumerable<JObject>)current2.Value))
					{
						MyCard obj3 = new MyCard
						{
							Title = current2.Key + " (" + Conversions.ToString(current2.Value.Count) + ")"
						};
						((FrameworkElement)obj3).Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
						MyCard myCard2 = obj3;
						StackPanel val3 = new StackPanel
						{
							Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
							VerticalAlignment = (VerticalAlignment)0,
							RenderTransform = (Transform)new TranslateTransform(0.0, 0.0),
							Tag = current2.Value
						};
						((Panel)myCard2).Children.Add((UIElement)(object)val3);
						myCard2.SwapControl = val3;
						vB_0024AnonymousDelegate_2 = vB_0024AnonymousDelegate_;
						myCard2.InstallMethod = ((vB_0024AnonymousDelegate_2 == null) ? null : new Action<StackPanel>(vB_0024AnonymousDelegate_2.Invoke));
						myCard2.IsSwapped = true;
						((Panel)PanMinecraft).Children.Add((UIElement)(object)myCard2);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator3).Dispose();
			}
			if (McVersionWaitingForSelect == null)
			{
				return;
			}
			ModBase.Log("[Download] 自动选择 MC 版本：" + McVersionWaitingForSelect);
			System.Collections.Generic.IEnumerator<JToken> enumerator4 = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator4 = jArray.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator4).MoveNext())
				{
					JObject jObject4 = (JObject)enumerator4.Current;
					if (Operators.CompareString(jObject4["id"].ToString(), McVersionWaitingForSelect, false) == 0)
					{
						MyListItem sender2 = ModDownloadLib.McDownloadListItem(jObject4, [SpecialName] (object a0, MouseButtonEventArgs a1) =>
						{
							((VB_0024AnonymousDelegate_8)([SpecialName] () =>
							{
							}))();
						}, IsSaveOnly: false);
						MinecraftSelected(sender2, null);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator4)?.Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private string LoadOptiFineGetError()
	{
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(SelectedLoaderName, "NeoForge", false) == 0 || Operators.CompareString(SelectedLoaderName, "Quilt", false) == 0 || Operators.CompareString(SelectedLoaderName, "LabyMod", false) == 0)
		{
			return $"与 {SelectedLoaderName} 不兼容";
		}
		if (LoadOptiFine == null || LoadOptiFine.State.LoadingState == MyLoading.MyLoadingState.Run)
		{
			return "加载中……";
		}
		if (LoadOptiFine.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			return Conversions.ToString(Operators.ConcatenateObject((object)"获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet((object)LoadOptiFine.State, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		}
		if (SelectedCleanroom != null)
		{
			return "与 Cleanroom 不兼容";
		}
		if (Operators.CompareString(SelectedLoaderName, "Forge", false) == 0 && ModMinecraft.VersionSortInteger(SelectedMinecraftId, "1.13") >= 0 && ModMinecraft.VersionSortInteger("1.14.3", SelectedMinecraftId) >= 0)
		{
			return "与 Forge 不兼容";
		}
		if (SelectedFabric != null && ModMinecraft.VersionSortInteger(SelectedMinecraftId, "1.20.4") > 0)
		{
			return "与 Fabric 不兼容";
		}
		bool flag = false;
		bool flag2 = false;
		System.Collections.Generic.IEnumerator<ModDownload.DlOptiFineListEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModDownload.DlOptiFineListEntry>);
		try
		{
			enumerator = ModDownload.DlOptiFineListLoader.Output.Value.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ModDownload.DlOptiFineListEntry current = enumerator.Current;
				if (current.NameDisplay.StartsWith(SelectedMinecraftId + " "))
				{
					flag = true;
					if (SelectedForge == null)
					{
						return null;
					}
					if (Conversions.ToBoolean(IsOptiFineSuitForForge(current, SelectedForge)))
					{
						return null;
					}
					if (current.RequiredForgeVersion != null)
					{
						flag2 = true;
					}
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		if (!flag)
		{
			return "不可用";
		}
		if (flag2)
		{
			return "仅兼容特定版本的 Forge";
		}
		return "与 Forge 不兼容";
	}

	private object IsOptiFineSuitForForge(ModDownload.DlOptiFineListEntry OptiFine, ModDownload.DlForgeVersionEntry Forge)
	{
		if (Operators.CompareString(Forge.Inherit, OptiFine.Inherit, false) != 0)
		{
			return false;
		}
		if (OptiFine.RequiredForgeVersion == null)
		{
			return false;
		}
		if (string.IsNullOrWhiteSpace(OptiFine.RequiredForgeVersion))
		{
			return true;
		}
		if (OptiFine.RequiredForgeVersion.Contains("."))
		{
			return ModMinecraft.VersionSortInteger(Forge.Version.ToString(), OptiFine.RequiredForgeVersion) == 0;
		}
		return (double)Forge.Version.Revision == Conversions.ToDouble(OptiFine.RequiredForgeVersion);
	}

	private void CardOptiFine_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadOptiFineGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void OptiFine_Loaded()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (ModDownload.DlOptiFineListLoader.State != ModBase.LoadState.Finished)
			{
				return;
			}
			List<ModDownload.DlOptiFineListEntry> val = new List<ModDownload.DlOptiFineListEntry>();
			System.Collections.Generic.IEnumerator<ModDownload.DlOptiFineListEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModDownload.DlOptiFineListEntry>);
			try
			{
				enumerator = ModDownload.DlOptiFineListLoader.Output.Value.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModDownload.DlOptiFineListEntry current = enumerator.Current;
					if (!Conversions.ToBoolean((object)(SelectedForge != null && Conversions.ToBoolean(Operators.NotObject(IsOptiFineSuitForForge(current, SelectedForge))))) && current.NameDisplay.StartsWith(SelectedMinecraftId + " "))
					{
						val.Add(current);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			if (!Enumerable.Any<ModDownload.DlOptiFineListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlOptiFineListEntry>)val))
			{
				return;
			}
			ModBase.Sort((System.Collections.Generic.IList<ModDownload.DlOptiFineListEntry>)val, [SpecialName] (ModDownload.DlOptiFineListEntry Left, ModDownload.DlOptiFineListEntry Right) =>
			{
				if (!Left.IsPreview && Right.IsPreview)
				{
					return true;
				}
				return (!Left.IsPreview || Right.IsPreview) && ModMinecraft.VersionSortBoolean(Left.NameDisplay, Right.NameDisplay);
			});
			((Panel)PanOptiFine).Children.Clear();
			System.Collections.Generic.IEnumerator<ModDownload.DlOptiFineListEntry> enumerator2 = default(System.Collections.Generic.IEnumerator<ModDownload.DlOptiFineListEntry>);
			try
			{
				enumerator2 = val.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ModDownload.DlOptiFineListEntry current2 = enumerator2.Current;
					((Panel)PanOptiFine).Children.Add((UIElement)(object)ModDownloadLib.OptiFineDownloadListItem(current2, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
					{
						OptiFine_Selected((MyListItem)a0, (EventArgs)(object)a1);
					}, IsSaveOnly: false));
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化 OptiFine 安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void OptiFine_Selected(MyListItem sender, EventArgs e)
	{
		SelectedOptiFine = (ModDownload.DlOptiFineListEntry)((FrameworkElement)sender).Tag;
		if (Conversions.ToBoolean((object)(SelectedForge != null && Conversions.ToBoolean(Operators.NotObject(IsOptiFineSuitForForge(SelectedOptiFine, SelectedForge))))))
		{
			SelectedForge = null;
		}
		OptiFabric_Loaded();
		Forge_Loaded();
		NeoForge_Loaded();
		CardOptiFine.IsSwapped = true;
		SelectReload();
	}

	private void OptiFine_Clear(object sender, MouseButtonEventArgs e)
	{
		SelectedOptiFine = null;
		SelectedOptiFabric = null;
		AutoSelectedOptiFabric = false;
		CardOptiFine.IsSwapped = true;
		((RoutedEventArgs)e).Handled = true;
		Forge_Loaded();
		NeoForge_Loaded();
		SelectReload();
	}

	private string LoadLiteLoaderGetError()
	{
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		if (SelectedLegacyFabric != null)
		{
			return "与 LiteLoader 不兼容";
		}
		if (!SelectedMinecraftId.Contains("1.") || ModBase.Val(SelectedMinecraftId.Split(".", (StringSplitOptions)0)[1]) > 12.0)
		{
			return "不可用";
		}
		if (LoadLiteLoader == null || LoadLiteLoader.State.LoadingState == MyLoading.MyLoadingState.Run)
		{
			return "加载中……";
		}
		if (LoadLiteLoader.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			return Conversions.ToString(Operators.ConcatenateObject((object)"获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet((object)LoadLiteLoader.State, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		}
		System.Collections.Generic.IEnumerator<ModDownload.DlLiteLoaderListEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModDownload.DlLiteLoaderListEntry>);
		try
		{
			enumerator = ModDownload.DlLiteLoaderListLoader.Output.Value.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (Operators.CompareString(enumerator.Current.Inherit, SelectedMinecraftId, false) == 0)
				{
					return null;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		return "不可用";
	}

	private void CardLiteLoader_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadLiteLoaderGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void LiteLoader_Loaded()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (ModDownload.DlLiteLoaderListLoader.State != ModBase.LoadState.Finished)
			{
				return;
			}
			List<ModDownload.DlLiteLoaderListEntry> val = new List<ModDownload.DlLiteLoaderListEntry>();
			System.Collections.Generic.IEnumerator<ModDownload.DlLiteLoaderListEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModDownload.DlLiteLoaderListEntry>);
			try
			{
				enumerator = ModDownload.DlLiteLoaderListLoader.Output.Value.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModDownload.DlLiteLoaderListEntry current = enumerator.Current;
					if (Operators.CompareString(current.Inherit, SelectedMinecraftId, false) == 0)
					{
						val.Add(current);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			if (!Enumerable.Any<ModDownload.DlLiteLoaderListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlLiteLoaderListEntry>)val))
			{
				return;
			}
			((Panel)PanLiteLoader).Children.Clear();
			System.Collections.Generic.IEnumerator<ModDownload.DlLiteLoaderListEntry> enumerator2 = default(System.Collections.Generic.IEnumerator<ModDownload.DlLiteLoaderListEntry>);
			try
			{
				enumerator2 = val.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ModDownload.DlLiteLoaderListEntry current2 = enumerator2.Current;
					((Panel)PanLiteLoader).Children.Add((UIElement)(object)ModDownloadLib.LiteLoaderDownloadListItem(current2, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
					{
						LiteLoader_Selected((MyListItem)a0, (EventArgs)(object)a1);
					}, IsSaveOnly: false));
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化 LiteLoader 安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void LiteLoader_Selected(MyListItem sender, EventArgs e)
	{
		SelectedLiteLoader = (ModDownload.DlLiteLoaderListEntry)((FrameworkElement)sender).Tag;
		CardLiteLoader.IsSwapped = true;
		SelectReload();
	}

	private void LiteLoader_Clear(object sender, MouseButtonEventArgs e)
	{
		SelectedLiteLoader = null;
		CardLiteLoader.IsSwapped = true;
		((RoutedEventArgs)e).Handled = true;
		SelectReload();
	}

	private string LoadForgeGetError()
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		if (!PCLVerCompat.StartsWithVer2(SelectedMinecraftId, "1."))
		{
			return "不可用";
		}
		if (!LoadForge.State.IsLoader)
		{
			return "加载中……";
		}
		ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = (ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)LoadForge.State;
		if (Operators.CompareString(SelectedMinecraftId, loaderTask.Input, false) != 0)
		{
			return "加载中……";
		}
		if (loaderTask.State == ModBase.LoadState.Loading)
		{
			return "加载中……";
		}
		if (loaderTask.State == ModBase.LoadState.Failed)
		{
			string message = loaderTask.Error.Message;
			if (message.Contains("不可用"))
			{
				return "不可用";
			}
			return "获取版本列表失败：" + message;
		}
		if (loaderTask.State != ModBase.LoadState.Finished)
		{
			return "获取版本列表失败：未知错误，状态为 " + ModBase.GetStringFromEnum(loaderTask.State);
		}
		bool flag = false;
		System.Collections.Generic.IEnumerator<ModDownload.DlForgeVersionEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModDownload.DlForgeVersionEntry>);
		try
		{
			enumerator = loaderTask.Output.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ModDownload.DlForgeVersionEntry current = enumerator.Current;
				if (Operators.CompareString(current.Category, "universal", false) != 0 && Operators.CompareString(current.Category, "client", false) != 0)
				{
					if (SelectedLoaderName != null && SelectedLoaderName != "Forge")
					{
						return $"与 {SelectedLoaderName} 不兼容";
					}
					if (SelectedOptiFine != null && ModMinecraft.VersionSortInteger(SelectedMinecraftId, "1.13") >= 0 && ModMinecraft.VersionSortInteger("1.14.3", SelectedMinecraftId) >= 0)
					{
						return "与 OptiFine 不兼容";
					}
					if (!Conversions.ToBoolean((object)(SelectedOptiFine != null && Conversions.ToBoolean(Operators.NotObject(IsOptiFineSuitForForge(SelectedOptiFine, current))))))
					{
						return null;
					}
					flag = true;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		return flag ? "与 OptiFine 不兼容" : "该版本不支持自动安装";
	}

	private void CardForge_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadForgeGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void Forge_Loaded()
	{
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!LoadForge.State.IsLoader)
			{
				return;
			}
			ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>> loaderTask = (ModLoader.LoaderTask<string, List<ModDownload.DlForgeVersionEntry>>)LoadForge.State;
			if (Operators.CompareString(SelectedMinecraftId, loaderTask.Input, false) != 0 || loaderTask.State != ModBase.LoadState.Finished)
			{
				return;
			}
			List<ModDownload.DlForgeVersionEntry> val = Enumerable.ToList<ModDownload.DlForgeVersionEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlForgeVersionEntry>)loaderTask.Output);
			if (!Enumerable.Any<ModDownload.DlForgeVersionEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlForgeVersionEntry>)loaderTask.Output))
			{
				return;
			}
			((Panel)PanForge).Children.Clear();
			val = Enumerable.ToList<ModDownload.DlForgeVersionEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlForgeVersionEntry>)Enumerable.OrderByDescending<ModDownload.DlForgeVersionEntry, Version>(Enumerable.Where<ModDownload.DlForgeVersionEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlForgeVersionEntry>)val, (Func<ModDownload.DlForgeVersionEntry, bool>)([SpecialName] [CompilerGenerated] (ModDownload.DlForgeVersionEntry v) =>
			{
				if (Operators.CompareString(v.Category, "universal", false) == 0 || Operators.CompareString(v.Category, "client", false) == 0)
				{
					return false;
				}
				return !Conversions.ToBoolean((object)(SelectedOptiFine != null && Conversions.ToBoolean(Operators.NotObject(IsOptiFineSuitForForge(SelectedOptiFine, v)))));
			})), (Func<ModDownload.DlForgeVersionEntry, Version>)([SpecialName] (ModDownload.DlForgeVersionEntry v) => v.Version)));
			ModDownloadLib.ForgeDownloadListItemPreload(PanForge, val, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				Forge_Selected((MyListItem)a0, (EventArgs)(object)a1);
			}, IsSaveOnly: false);
			System.Collections.Generic.IEnumerator<ModDownload.DlForgeVersionEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModDownload.DlForgeVersionEntry>);
			try
			{
				enumerator = val.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModDownload.DlForgeVersionEntry current = enumerator.Current;
					((Panel)PanForge).Children.Add((UIElement)(object)ModDownloadLib.ForgeDownloadListItem(current, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
					{
						Forge_Selected((MyListItem)a0, (EventArgs)(object)a1);
					}, IsSaveOnly: false));
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
			ModBase.Log(ex2, "可视化 Forge 安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void Forge_Selected(MyListItem sender, EventArgs e)
	{
		SelectedForge = (ModDownload.DlForgeVersionEntry)((FrameworkElement)sender).Tag;
		SelectedLoaderName = "Forge";
		CardForge.IsSwapped = true;
		if (Conversions.ToBoolean((object)(SelectedOptiFine != null && Conversions.ToBoolean(Operators.NotObject(IsOptiFineSuitForForge(SelectedOptiFine, SelectedForge))))))
		{
			SelectedOptiFine = null;
		}
		OptiFine_Loaded();
		SelectReload();
	}

	private void Forge_Clear(object sender, MouseButtonEventArgs e)
	{
		SelectedForge = null;
		SelectedLoaderName = null;
		CardForge.IsSwapped = true;
		((RoutedEventArgs)e).Handled = true;
		OptiFine_Loaded();
		SelectReload();
	}

	private string LoadNeoForgeGetError()
	{
		if (!PCLVerCompat.StartsWithVer2(SelectedMinecraftId, "1."))
		{
			return "不可用";
		}
		if (SelectedOptiFine != null)
		{
			return "与 OptiFine 不兼容";
		}
		if (SelectedLoaderName != null && SelectedLoaderName != "NeoForge")
		{
			return $"与 {SelectedLoaderName} 不兼容";
		}
		if (LoadNeoForge == null || LoadNeoForge.State.LoadingState == MyLoading.MyLoadingState.Run)
		{
			return "加载中……";
		}
		if (LoadNeoForge.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			return Conversions.ToString(Operators.ConcatenateObject((object)"获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet((object)LoadNeoForge.State, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		}
		if (Enumerable.Any<ModDownload.DlNeoForgeListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlNeoForgeListEntry>)ModDownload.DlNeoForgeListLoader.Output.Value, (Func<ModDownload.DlNeoForgeListEntry, bool>)([SpecialName] [CompilerGenerated] (ModDownload.DlNeoForgeListEntry v) => Operators.CompareString(v.Inherit, SelectedMinecraftId, false) == 0)))
		{
			return null;
		}
		return "不可用";
	}

	private void CardNeoForge_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadNeoForgeGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void NeoForge_Loaded()
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (ModDownload.DlNeoForgeListLoader.State != ModBase.LoadState.Finished)
			{
				return;
			}
			List<ModDownload.DlNeoForgeListEntry> val = Enumerable.ToList<ModDownload.DlNeoForgeListEntry>(Enumerable.Where<ModDownload.DlNeoForgeListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlNeoForgeListEntry>)ModDownload.DlNeoForgeListLoader.Output.Value, (Func<ModDownload.DlNeoForgeListEntry, bool>)([SpecialName] [CompilerGenerated] (ModDownload.DlNeoForgeListEntry v) => Operators.CompareString(v.Inherit, SelectedMinecraftId, false) == 0)));
			if (!Enumerable.Any<ModDownload.DlNeoForgeListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlNeoForgeListEntry>)val))
			{
				return;
			}
			((Panel)PanNeoForge).Children.Clear();
			ModDownloadLib.NeoForgeDownloadListItemPreload(PanNeoForge, val, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				NeoForge_Selected((MyListItem)a0, (EventArgs)(object)a1);
			}, IsSaveOnly: false);
			System.Collections.Generic.IEnumerator<ModDownload.DlNeoForgeListEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModDownload.DlNeoForgeListEntry>);
			try
			{
				enumerator = val.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModDownload.DlNeoForgeListEntry current = enumerator.Current;
					((Panel)PanNeoForge).Children.Add((UIElement)(object)ModDownloadLib.NeoForgeDownloadListItem(current, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
					{
						NeoForge_Selected((MyListItem)a0, (EventArgs)(object)a1);
					}, IsSaveOnly: false));
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
			ModBase.Log(ex2, "可视化 NeoForge 安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void NeoForge_Selected(MyListItem sender, EventArgs e)
	{
		SelectedNeoForge = (ModDownload.DlNeoForgeListEntry)((FrameworkElement)sender).Tag;
		SelectedLoaderName = "NeoForge";
		CardNeoForge.IsSwapped = true;
		OptiFine_Loaded();
		SelectReload();
	}

	private void NeoForge_Clear(object sender, MouseButtonEventArgs e)
	{
		SelectedNeoForge = null;
		SelectedLoaderName = null;
		CardNeoForge.IsSwapped = true;
		((RoutedEventArgs)e).Handled = true;
		OptiFine_Loaded();
		SelectReload();
	}

	private string LoadCleanroomGetError()
	{
		if (!PCLVerCompat.StartsWithVer2(SelectedMinecraftId, "1."))
		{
			return "没有可用版本";
		}
		if (SelectedOptiFine != null)
		{
			return "与 OptiFine 不兼容";
		}
		if (SelectedLoaderName != null && SelectedLoaderName != "Cleanroom")
		{
			return $"与 {SelectedLoaderName} 不兼容";
		}
		if (LoadCleanroom == null || LoadCleanroom.State.LoadingState == MyLoading.MyLoadingState.Run)
		{
			return "正在获取版本列表……";
		}
		if (LoadCleanroom.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			return Conversions.ToString(Operators.ConcatenateObject((object)"获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet((object)LoadCleanroom.State, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		}
		return null;
	}

	private void CardCleanroom_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadCleanroomGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void Cleanroom_Loaded()
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (ModDownload.DlCleanroomListLoader.State != ModBase.LoadState.Finished)
			{
				return;
			}
			List<ModDownload.DlCleanroomListEntry> val = Enumerable.ToList<ModDownload.DlCleanroomListEntry>(Enumerable.Where<ModDownload.DlCleanroomListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlCleanroomListEntry>)ModDownload.DlCleanroomListLoader.Output.Value, (Func<ModDownload.DlCleanroomListEntry, bool>)([SpecialName] [CompilerGenerated] (ModDownload.DlCleanroomListEntry v) => Operators.CompareString(v.Inherit, SelectedMinecraftId, false) == 0)));
			if (!Enumerable.Any<ModDownload.DlCleanroomListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlCleanroomListEntry>)val))
			{
				return;
			}
			((Panel)PanCleanroom).Children.Clear();
			ModDownloadLib.CleanroomDownloadListItemPreload(PanCleanroom, val, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				Cleanroom_Selected((MyListItem)a0, (EventArgs)(object)a1);
			}, IsSaveOnly: false);
			System.Collections.Generic.IEnumerator<ModDownload.DlCleanroomListEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModDownload.DlCleanroomListEntry>);
			try
			{
				enumerator = val.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModDownload.DlCleanroomListEntry current = enumerator.Current;
					((Panel)PanCleanroom).Children.Add((UIElement)(object)ModDownloadLib.CleanroomDownloadListItem(current, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
					{
						Cleanroom_Selected((MyListItem)a0, (EventArgs)(object)a1);
					}, IsSaveOnly: false));
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
			ModBase.Log(ex2, "可视化 Cleanroom 安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void Cleanroom_Selected(MyListItem sender, EventArgs e)
	{
		SelectedCleanroom = (ModDownload.DlCleanroomListEntry)((FrameworkElement)sender).Tag;
		SelectedLoaderName = "Cleanroom";
		CardCleanroom.IsSwapped = true;
		OptiFine_Loaded();
		SelectReload();
	}

	private void Cleanroom_Clear(object sender, MouseButtonEventArgs e)
	{
		SelectedCleanroom = null;
		SelectedLoaderName = null;
		CardCleanroom.IsSwapped = true;
		((RoutedEventArgs)e).Handled = true;
		OptiFine_Loaded();
		SelectReload();
	}

	private string LoadFabricGetError()
	{
		if (LoadFabric == null || LoadFabric.State.LoadingState == MyLoading.MyLoadingState.Run)
		{
			return "加载中……";
		}
		if (LoadFabric.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			return Conversions.ToString(Operators.ConcatenateObject((object)"获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet((object)LoadFabric.State, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		}
		if (SelectedOptiFine != null && ModMinecraft.VersionSortInteger(SelectedMinecraftId, "1.20.4") > 0)
		{
			return "与 OptiFine 不兼容";
		}
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator = ((System.Collections.Generic.IEnumerable<JToken>)ModDownload.DlFabricListLoader.Output.Value["game"]).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				if (Operators.CompareString(((JObject)enumerator.Current)["version"].ToString(), SelectedMinecraftId.Replace("∞", "infinite").Replace("Combat Test 7c", "1.16_combat-3"), false) == 0)
				{
					if (SelectedLoaderName != null && SelectedLoaderName != "Fabric")
					{
						return $"与 {SelectedLoaderName} 不兼容";
					}
					return null;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		return "不可用";
	}

	private void CardFabric_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadFabricGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void Fabric_Loaded()
	{
		try
		{
			if (ModDownload.DlFabricListLoader.State != ModBase.LoadState.Finished)
			{
				return;
			}
			JArray jArray = (JArray)ModDownload.DlFabricListLoader.Output.Value["loader"];
			if (!Enumerable.Any<JToken>((System.Collections.Generic.IEnumerable<JToken>)jArray))
			{
				return;
			}
			((Panel)PanFabric).Children.Clear();
			((FrameworkElement)PanFabric).Tag = jArray;
			CardFabric.SwapControl = PanFabric;
			CardFabric.InstallMethod = [SpecialName] (StackPanel Stack) =>
			{
				_Closure_0024__R83_002D12 closure_0024__R83_002D = default(_Closure_0024__R83_002D12);
				foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					UIElementCollection children = ((Panel)Stack).Children;
					JObject entry = (JObject)objectValue;
					closure_0024__R83_002D = new _Closure_0024__R83_002D12(closure_0024__R83_002D);
					closure_0024__R83_002D._0024VB_0024NonLocal_2 = ModMain.FrmDownloadInstall;
					children.Add((UIElement)(object)ModDownloadLib.FabricDownloadListItem(entry, closure_0024__R83_002D._Lambda_0024__R14));
				}
			};
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化 Fabric 安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public void Fabric_Selected(MyListItem sender, EventArgs e)
	{
		SelectedFabric = NewLateBinding.LateIndexGet(((FrameworkElement)sender).Tag, new object[] { "version" }, (string[])null).ToString();
		SelectedLoaderName = "Fabric";
		FabricApi_Loaded();
		OptiFabric_Loaded();
		CardFabric.IsSwapped = true;
		SelectReload();
	}

	private void Fabric_Clear(object sender, MouseButtonEventArgs e)
	{
		SelectedFabric = null;
		SelectedFabricApi = null;
		AutoSelectedFabricApi = false;
		SelectedOptiFabric = null;
		AutoSelectedOptiFabric = false;
		SelectedLoaderName = null;
		SelectedAPIName = null;
		CardFabric.IsSwapped = true;
		((RoutedEventArgs)e).Handled = true;
		SelectReload();
	}

	public static bool IsSuitableFabricApi(string DisplayName, string MinecraftVersion)
	{
		checked
		{
			bool result;
			try
			{
				if (DisplayName == null || MinecraftVersion == null)
				{
					result = false;
				}
				else
				{
					DisplayName = DisplayName.ToLower();
					MinecraftVersion = MinecraftVersion.Replace("∞", "infinite").Replace("Combat Test 7c", "1.16_combat-3").ToLower();
					if (DisplayName.StartsWith("[" + MinecraftVersion + "]"))
					{
						result = true;
					}
					else if (!DisplayName.Contains("/") || !DisplayName.Contains("]"))
					{
						result = false;
					}
					else
					{
						string[] array = ModBase.BeforeFirst(DisplayName, "]").TrimStart('[').Split("/", (StringSplitOptions)0);
						int num = 0;
						while (true)
						{
							if (num < array.Length)
							{
								if (Operators.CompareString(array[num], MinecraftVersion, false) == 0)
								{
									result = true;
									break;
								}
								num++;
								continue;
							}
							List<string> val = ModBase.RegexSearch(ModBase.BeforeFirst(DisplayName, "]"), "[a-z/]+|[0-9/]+", (RegexOptions)0);
							List<string> val2 = ModBase.RegexSearch(ModBase.BeforeFirst(MinecraftVersion, "]"), "[a-z/]+|[0-9/]+", (RegexOptions)0);
							int num2 = 0;
							while (true)
							{
								if (val.Count - 1 < num2 && val2.Count - 1 < num2)
								{
									result = true;
									break;
								}
								string text = ((val.Count - 1 < num2) ? "-1" : val[num2]);
								string text2 = ((val2.Count - 1 < num2) ? "-1" : val2[num2]);
								if (!text.Contains("/"))
								{
									if (Operators.CompareString(text, text2, false) != 0)
									{
										result = false;
										break;
									}
								}
								else if (!text.Contains(text2))
								{
									result = false;
									break;
								}
								num2++;
							}
							break;
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, string.Concat(new string[] { "判断 Fabric API 版本适配性出错（", DisplayName, ", ", MinecraftVersion, "）" }));
				result = false;
				ProjectData.ClearProjectError();
			}
			return result;
		}
	}

	private string LoadFabricApiGetError()
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		if (LoadFabricApi == null || LoadFabricApi.State.LoadingState == MyLoading.MyLoadingState.Run)
		{
			return "加载中……";
		}
		if (LoadFabricApi.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			return Conversions.ToString(Operators.ConcatenateObject((object)"获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet((object)LoadFabricApi.State, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		}
		if (SelectedAPIName != null && SelectedAPIName != "Fabric API")
		{
			return $"与 {SelectedAPIName} 不兼容";
		}
		if (ModDownload.DlFabricApiLoader.Output == null)
		{
			if (SelectedFabric == null && SelectedQuilt == null)
			{
				return "需要安装 Fabric / Quilt";
			}
			return "加载中……";
		}
		System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
		try
		{
			enumerator = ModDownload.DlFabricApiLoader.Output.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (IsSuitableFabricApi(enumerator.Current.DisplayName, SelectedMinecraftId))
				{
					if (SelectedFabric == null && SelectedQuilt == null)
					{
						return "需要安装 Fabric / Quilt";
					}
					return null;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		return "不可用";
	}

	private void CardFabricApi_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadFabricApiGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void FabricApi_Loaded()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (ModDownload.DlFabricApiLoader.State != ModBase.LoadState.Finished || SelectedMinecraftId == null || (SelectedFabric == null && SelectedQuilt == null))
			{
				return;
			}
			List<ModComp.CompFile> val = new List<ModComp.CompFile>();
			System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
			try
			{
				enumerator = ModDownload.DlFabricApiLoader.Output.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModComp.CompFile current = enumerator.Current;
					if (IsSuitableFabricApi(current.DisplayName, SelectedMinecraftId))
					{
						if (!current.DisplayName.StartsWith("["))
						{
							ModBase.Log("[Download] 已特判修改 Fabric API 显示名：" + current.DisplayName, ModBase.LogLevel.Debug);
							current.DisplayName = "[" + SelectedMinecraftId + "] " + current.DisplayName;
						}
						val.Add(current);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			if (!Enumerable.Any<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)val))
			{
				return;
			}
			val = Enumerable.ToList<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)Enumerable.OrderByDescending<ModComp.CompFile, System.DateTime>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)val, (Func<ModComp.CompFile, System.DateTime>)([SpecialName] (ModComp.CompFile v) => v.ReleaseDate)));
			((Panel)PanFabricApi).Children.Clear();
			System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator2 = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
			try
			{
				enumerator2 = val.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ModComp.CompFile current2 = enumerator2.Current;
					if (IsSuitableFabricApi(current2.DisplayName, SelectedMinecraftId))
					{
						((Panel)PanFabricApi).Children.Add((UIElement)(object)ModDownloadLib.FabricApiDownloadListItem(current2, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
						{
							FabricApi_Selected((MyListItem)a0, (EventArgs)(object)a1);
						}));
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			if ((!AutoSelectedFabricApi && SelectedQuilt == null) || (SelectedQuilt != null && LoadQSLGetError() == "没有可用版本"))
			{
				AutoSelectedFabricApi = true;
				ModBase.Log($"[Download] 已自动选择 Fabric API：{((MyListItem)(object)((Panel)PanFabricApi).Children[0]).Title}");
				FabricApi_Selected((MyListItem)(object)((Panel)PanFabricApi).Children[0], null);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化 Fabric API 安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void FabricApi_Selected(MyListItem sender, EventArgs e)
	{
		SelectedFabricApi = (ModComp.CompFile)((FrameworkElement)sender).Tag;
		SelectedAPIName = "Fabric API";
		CardFabricApi.IsSwapped = true;
		SelectReload();
	}

	private void FabricApi_Clear(object sender, MouseButtonEventArgs e)
	{
		SelectedFabricApi = null;
		SelectedAPIName = null;
		CardFabricApi.IsSwapped = true;
		((RoutedEventArgs)e).Handled = true;
		SelectReload();
	}

	private string LoadLegacyFabricGetError()
	{
		if (LoadLegacyFabric == null || LoadLegacyFabric.State.LoadingState == MyLoading.MyLoadingState.Run)
		{
			return "加载中……";
		}
		if (LoadLegacyFabric.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			return Conversions.ToString(Operators.ConcatenateObject((object)"获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet((object)LoadLegacyFabric.State, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		}
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator = ((System.Collections.Generic.IEnumerable<JToken>)ModDownload.DlLegacyFabricListLoader.Output.Value["game"]).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				if (Operators.CompareString(((JObject)enumerator.Current)["version"].ToString(), SelectedMinecraftId, false) == 0)
				{
					if (SelectedLiteLoader != null)
					{
						return "与 LiteLoader 不兼容";
					}
					if (SelectedLoaderName != null && SelectedLoaderName != "LegacyFabric")
					{
						return $"与 {SelectedLoaderName} 不兼容";
					}
					return null;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		return "不可用";
	}

	private void CardLegacyFabric_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadLegacyFabricGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void LegacyFabric_Loaded()
	{
		try
		{
			if (ModDownload.DlLegacyFabricListLoader.State != ModBase.LoadState.Finished)
			{
				return;
			}
			JArray jArray = (JArray)ModDownload.DlLegacyFabricListLoader.Output.Value["loader"];
			if (!Enumerable.Any<JToken>((System.Collections.Generic.IEnumerable<JToken>)jArray))
			{
				return;
			}
			((Panel)PanLegacyFabric).Children.Clear();
			((FrameworkElement)PanLegacyFabric).Tag = jArray;
			CardLegacyFabric.SwapControl = PanLegacyFabric;
			CardLegacyFabric.InstallMethod = [SpecialName] (StackPanel Stack) =>
			{
				_Closure_0024__R95_002D15 closure_0024__R95_002D = default(_Closure_0024__R95_002D15);
				foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					UIElementCollection children = ((Panel)Stack).Children;
					JObject entry = (JObject)objectValue;
					closure_0024__R95_002D = new _Closure_0024__R95_002D15(closure_0024__R95_002D);
					closure_0024__R95_002D._0024VB_0024NonLocal_2 = ModMain.FrmDownloadInstall;
					children.Add((UIElement)(object)ModDownloadLib.LegacyFabricDownloadListItem(entry, closure_0024__R95_002D._Lambda_0024__R17));
				}
			};
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化 LegacyFabric 安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public void LegacyFabric_Selected(MyListItem sender, EventArgs e)
	{
		SelectedLegacyFabric = NewLateBinding.LateIndexGet(((FrameworkElement)sender).Tag, new object[] { "version" }, (string[])null).ToString();
		SelectedLoaderName = "LegacyFabric";
		LegacyFabricApi_Loaded();
		CardLegacyFabric.IsSwapped = true;
		SelectReload();
	}

	private void LegacyFabric_Clear(object sender, MouseButtonEventArgs e)
	{
		SelectedLegacyFabric = null;
		SelectedLegacyFabricApi = null;
		AutoSelectedLegacyFabricApi = false;
		SelectedLoaderName = null;
		SelectedAPIName = null;
		CardLegacyFabric.IsSwapped = true;
		((RoutedEventArgs)e).Handled = true;
		SelectReload();
	}

	public static bool IsSuitableLegacyFabricApi(List<string> SupportVersions, string MinecraftVersion)
	{
		bool result;
		try
		{
			result = (SupportVersions.Contains(MinecraftVersion) ? true : false);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, string.Concat(new string[5]
			{
				"判断 Legacy Fabric API 版本适配性出错（",
				((object)SupportVersions).ToString(),
				", ",
				MinecraftVersion,
				"）"
			}));
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private string LoadLegacyFabricApiGetError()
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		if (LoadLegacyFabricApi == null || LoadLegacyFabricApi.State.LoadingState == MyLoading.MyLoadingState.Run)
		{
			return "加载中……";
		}
		if (LoadLegacyFabricApi.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			return Conversions.ToString(Operators.ConcatenateObject((object)"获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet((object)LoadLegacyFabricApi.State, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		}
		if (SelectedAPIName != null && SelectedAPIName != "Legacy Fabric API")
		{
			return $"与 {SelectedAPIName} 不兼容";
		}
		if (ModDownload.DlLegacyFabricApiLoader.Output == null)
		{
			if (SelectedLegacyFabric == null)
			{
				return "需要安装 LegacyFabric";
			}
			return "加载中……";
		}
		System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
		try
		{
			enumerator = ModDownload.DlLegacyFabricApiLoader.Output.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (IsSuitableLegacyFabricApi(enumerator.Current.GameVersions, SelectedMinecraftId))
				{
					if (SelectedLegacyFabric == null)
					{
						return "需要安装 LegacyFabric";
					}
					return null;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		return "不可用";
	}

	private void CardLegacyFabricApi_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadLegacyFabricApiGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void LegacyFabricApi_Loaded()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (ModDownload.DlLegacyFabricApiLoader.State != ModBase.LoadState.Finished || SelectedMinecraftId == null || (SelectedLegacyFabric == null && SelectedQuilt == null))
			{
				return;
			}
			List<ModComp.CompFile> val = new List<ModComp.CompFile>();
			System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
			try
			{
				enumerator = ModDownload.DlLegacyFabricApiLoader.Output.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModComp.CompFile current = enumerator.Current;
					if (IsSuitableLegacyFabricApi(current.GameVersions, SelectedMinecraftId))
					{
						val.Add(current);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			if (!Enumerable.Any<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)val))
			{
				return;
			}
			val = Enumerable.ToList<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)Enumerable.OrderByDescending<ModComp.CompFile, System.DateTime>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)val, (Func<ModComp.CompFile, System.DateTime>)([SpecialName] (ModComp.CompFile v) => v.ReleaseDate)));
			((Panel)PanLegacyFabricApi).Children.Clear();
			System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator2 = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
			try
			{
				enumerator2 = val.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ModComp.CompFile current2 = enumerator2.Current;
					if (IsSuitableLegacyFabricApi(current2.GameVersions, SelectedMinecraftId))
					{
						((Panel)PanLegacyFabricApi).Children.Add((UIElement)(object)ModDownloadLib.LegacyFabricApiDownloadListItem(current2, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
						{
							LegacyFabricApi_Selected((MyListItem)a0, (EventArgs)(object)a1);
						}));
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			if ((!AutoSelectedLegacyFabricApi && SelectedQuilt == null) || (SelectedQuilt != null && LoadQSLGetError() == "没有可用版本"))
			{
				AutoSelectedLegacyFabricApi = true;
				ModBase.Log($"[Download] 已自动选择 Legacy Fabric API：{((MyListItem)(object)((Panel)PanLegacyFabricApi).Children[0]).Title}");
				LegacyFabricApi_Selected((MyListItem)(object)((Panel)PanLegacyFabricApi).Children[0], null);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化 Legacy Fabric API 安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void LegacyFabricApi_Selected(MyListItem sender, EventArgs e)
	{
		SelectedLegacyFabricApi = (ModComp.CompFile)((FrameworkElement)sender).Tag;
		SelectedAPIName = "Legacy Fabric API";
		CardLegacyFabricApi.IsSwapped = true;
		SelectReload();
	}

	private void LegacyFabricApi_Clear(object sender, MouseButtonEventArgs e)
	{
		SelectedLegacyFabricApi = null;
		SelectedAPIName = null;
		CardLegacyFabricApi.IsSwapped = true;
		((RoutedEventArgs)e).Handled = true;
		SelectReload();
	}

	private string LoadQuiltGetError()
	{
		if (LoadQuilt == null || LoadQuilt.State.LoadingState == MyLoading.MyLoadingState.Run)
		{
			return "加载中……";
		}
		if (LoadQuilt.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			return Conversions.ToString(Operators.ConcatenateObject((object)"获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet((object)LoadQuilt.State, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		}
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator = ((System.Collections.Generic.IEnumerable<JToken>)ModDownload.DlQuiltListLoader.Output.Value["game"]).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				if (Operators.CompareString(((JObject)enumerator.Current)["version"].ToString(), SelectedMinecraftId.Replace("∞", "infinite").Replace("Combat Test 7c", "1.16_combat-3"), false) == 0)
				{
					if (SelectedOptiFine != null)
					{
						return "与 OptiFine 不兼容";
					}
					if (SelectedLoaderName != null && SelectedLoaderName != "Quilt")
					{
						return $"与 {SelectedLoaderName} 不兼容";
					}
					return null;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		return "不可用";
	}

	private void CardQuilt_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadQuiltGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void Quilt_Loaded()
	{
		try
		{
			if (ModDownload.DlQuiltListLoader.State != ModBase.LoadState.Finished)
			{
				return;
			}
			JArray jArray = (JArray)ModDownload.DlQuiltListLoader.Output.Value["loader"];
			if (!Enumerable.Any<JToken>((System.Collections.Generic.IEnumerable<JToken>)jArray))
			{
				return;
			}
			((Panel)PanQuilt).Children.Clear();
			((FrameworkElement)PanQuilt).Tag = jArray;
			CardQuilt.SwapControl = PanQuilt;
			CardQuilt.InstallMethod = [SpecialName] (StackPanel Stack) =>
			{
				_Closure_0024__R107_002D18 closure_0024__R107_002D = default(_Closure_0024__R107_002D18);
				foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
				{
					object objectValue = RuntimeHelpers.GetObjectValue(item);
					UIElementCollection children = ((Panel)Stack).Children;
					JObject entry = (JObject)objectValue;
					closure_0024__R107_002D = new _Closure_0024__R107_002D18(closure_0024__R107_002D);
					closure_0024__R107_002D._0024VB_0024NonLocal_2 = ModMain.FrmDownloadInstall;
					children.Add((UIElement)(object)ModDownloadLib.QuiltDownloadListItem(entry, closure_0024__R107_002D._Lambda_0024__R20));
				}
			};
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化 Quilt 安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public void Quilt_Selected(MyListItem sender, EventArgs e)
	{
		SelectedQuilt = NewLateBinding.LateIndexGet(((FrameworkElement)sender).Tag, new object[] { "version" }, (string[])null).ToString();
		SelectedLoaderName = "Quilt";
		FabricApi_Loaded();
		QSL_Loaded();
		CardQuilt.IsSwapped = true;
		SelectReload();
	}

	private void Quilt_Clear(object sender, MouseButtonEventArgs e)
	{
		SelectedQuilt = null;
		SelectedQSL = null;
		SelectedFabricApi = null;
		SelectedLoaderName = null;
		SelectedAPIName = null;
		CardQuilt.IsSwapped = true;
		((RoutedEventArgs)e).Handled = true;
		SelectReload();
	}

	public static bool IsSuitableQSL(List<string> SupportVersions, string MinecraftVersion)
	{
		bool result;
		try
		{
			result = (SupportVersions.Contains(MinecraftVersion) ? true : false);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, string.Concat(new string[5]
			{
				"判断 QSL 版本适配性出错（",
				((object)SupportVersions).ToString(),
				", ",
				MinecraftVersion,
				"）"
			}));
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private string LoadQSLGetError()
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		if (LoadQSL == null || LoadQSL.State.LoadingState == MyLoading.MyLoadingState.Run)
		{
			return "正在获取版本列表……";
		}
		if (LoadQSL.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			return Conversions.ToString(Operators.ConcatenateObject((object)"获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet((object)LoadQSL.State, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		}
		if (SelectedAPIName != null && SelectedAPIName != "QFAPI / QSL")
		{
			return $"与 {SelectedAPIName} 不兼容";
		}
		if (ModDownload.DlQSLLoader.Output == null)
		{
			if (SelectedQuilt == null)
			{
				return "需要安装 Quilt";
			}
			return "正在获取版本列表……";
		}
		System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
		try
		{
			enumerator = ModDownload.DlQSLLoader.Output.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (IsSuitableQSL(enumerator.Current.GameVersions, SelectedMinecraftId))
				{
					if (SelectedQuilt == null)
					{
						return "需要安装 Quilt";
					}
					return null;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		return "没有可用版本";
	}

	private void CardQSL_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadQSLGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void QSL_Loaded()
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (ModDownload.DlQSLLoader.State != ModBase.LoadState.Finished || SelectedMinecraftId == null || SelectedQuilt == null)
			{
				return;
			}
			List<ModComp.CompFile> val = new List<ModComp.CompFile>();
			System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
			try
			{
				enumerator = ModDownload.DlQSLLoader.Output.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModComp.CompFile current = enumerator.Current;
					if (IsSuitableQSL(current.GameVersions, SelectedMinecraftId))
					{
						if (!current.DisplayName.StartsWith("["))
						{
							ModBase.Log("[Download] 已特判修改 QSL 显示名：" + current.DisplayName, ModBase.LogLevel.Debug);
							current.DisplayName = "[" + SelectedMinecraftId + "] " + current.DisplayName;
						}
						val.Add(current);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			if (!Enumerable.Any<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)val))
			{
				return;
			}
			val = ModBase.Sort((System.Collections.Generic.IList<ModComp.CompFile>)val, [SpecialName] (ModComp.CompFile a, ModComp.CompFile b) => System.DateTime.Compare(a.ReleaseDate, b.ReleaseDate) > 0);
			((Panel)PanQSL).Children.Clear();
			System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator2 = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
			try
			{
				enumerator2 = val.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ModComp.CompFile current2 = enumerator2.Current;
					if (IsSuitableQSL(current2.GameVersions, SelectedMinecraftId))
					{
						((Panel)PanQSL).Children.Add((UIElement)(object)ModDownloadLib.QSLDownloadListItem(current2, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
						{
							QSL_Selected((MyListItem)a0, (EventArgs)(object)a1);
						}));
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			if (!AutoSelectedQSL)
			{
				AutoSelectedQSL = true;
				ModBase.Log($"[Download] 已自动选择 QSL：{((MyListItem)(object)((Panel)PanQSL).Children[0]).Title}");
				QSL_Selected((MyListItem)(object)((Panel)PanQSL).Children[0], null);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化 QSL 安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void QSL_Selected(MyListItem sender, EventArgs e)
	{
		SelectedQSL = (ModComp.CompFile)((FrameworkElement)sender).Tag;
		SelectedAPIName = "QFAPI / QSL";
		CardQSL.IsSwapped = true;
		SelectReload();
	}

	private void QSL_Clear(object sender, MouseButtonEventArgs e)
	{
		SelectedQSL = null;
		SelectedAPIName = null;
		CardQSL.IsSwapped = true;
		((RoutedEventArgs)e).Handled = true;
		SelectReload();
	}

	private bool IsSuitableOptiFabric(ModComp.CompFile ModFile, string MinecraftVersion)
	{
		bool result;
		try
		{
			result = MinecraftVersion != null && ModFile.GameVersions.Contains(MinecraftVersion);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "判断 OptiFabric 版本适配性出错（" + MinecraftVersion + "）");
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private string LoadOptiFabricGetError()
	{
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		if (SelectedMinecraftId.StartsWith("1.14") || SelectedMinecraftId.StartsWith("1.15"))
		{
			return "不兼容老版本 Fabric，请手动下载 OptiFabric Origins";
		}
		if (LoadOptiFabric == null || LoadOptiFabric.State.LoadingState == MyLoading.MyLoadingState.Run)
		{
			return "加载中……";
		}
		if (LoadOptiFabric.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			return Conversions.ToString(Operators.ConcatenateObject((object)"获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet((object)LoadOptiFabric.State, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		}
		if (ModDownload.DlOptiFabricLoader.Output == null)
		{
			if (SelectedFabric == null && SelectedOptiFine == null)
			{
				return "需要安装 OptiFine 与 Fabric";
			}
			if (SelectedFabric == null)
			{
				return "需要安装 Fabric";
			}
			if (SelectedOptiFine == null)
			{
				return "需要安装 OptiFine";
			}
			return "加载中……";
		}
		System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
		try
		{
			enumerator = ModDownload.DlOptiFabricLoader.Output.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ModComp.CompFile current = enumerator.Current;
				if (IsSuitableOptiFabric(current, SelectedMinecraftId))
				{
					if (SelectedFabric == null && SelectedOptiFine == null)
					{
						return "需要安装 OptiFine 与 Fabric";
					}
					if (SelectedFabric == null)
					{
						return "需要安装 Fabric";
					}
					if (SelectedOptiFine == null)
					{
						return "需要安装 OptiFine";
					}
					return null;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		return "不可用";
	}

	private void CardOptiFabric_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadOptiFabricGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void OptiFabric_Loaded()
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (ModDownload.DlOptiFabricLoader.State != ModBase.LoadState.Finished || SelectedMinecraftId == null || SelectedFabric == null || SelectedOptiFine == null)
			{
				return;
			}
			List<ModComp.CompFile> val = new List<ModComp.CompFile>();
			System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
			try
			{
				enumerator = ModDownload.DlOptiFabricLoader.Output.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModComp.CompFile current = enumerator.Current;
					if (IsSuitableOptiFabric(current, SelectedMinecraftId))
					{
						val.Add(current);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			if (!Enumerable.Any<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)val))
			{
				return;
			}
			val = Enumerable.ToList<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)Enumerable.OrderByDescending<ModComp.CompFile, System.DateTime>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)val, (Func<ModComp.CompFile, System.DateTime>)([SpecialName] (ModComp.CompFile v) => v.ReleaseDate)));
			((Panel)PanOptiFabric).Children.Clear();
			System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator2 = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
			try
			{
				enumerator2 = val.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ModComp.CompFile current2 = enumerator2.Current;
					if (IsSuitableOptiFabric(current2, SelectedMinecraftId))
					{
						((Panel)PanOptiFabric).Children.Add((UIElement)(object)ModDownloadLib.OptiFabricDownloadListItem(current2, [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
						{
							OptiFabric_Selected((MyListItem)a0, (EventArgs)(object)a1);
						}));
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			if (!AutoSelectedOptiFabric && !SelectedMinecraftId.StartsWith("1.14") && !SelectedMinecraftId.StartsWith("1.15"))
			{
				AutoSelectedOptiFabric = true;
				ModBase.Log($"[Download] 已自动选择 OptiFabric：{((MyListItem)(object)((Panel)PanOptiFabric).Children[0]).Title}");
				OptiFabric_Selected((MyListItem)(object)((Panel)PanOptiFabric).Children[0], null);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化 OptiFabric 安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void OptiFabric_Selected(MyListItem sender, EventArgs e)
	{
		SelectedOptiFabric = (ModComp.CompFile)((FrameworkElement)sender).Tag;
		CardOptiFabric.IsSwapped = true;
		SelectReload();
	}

	private void OptiFabric_Clear(object sender, MouseButtonEventArgs e)
	{
		SelectedOptiFabric = null;
		CardOptiFabric.IsSwapped = true;
		((RoutedEventArgs)e).Handled = true;
		SelectReload();
	}

	private string LoadLabyModGetError()
	{
		if (LoadLabyMod == null || LoadLabyMod.State.LoadingState == MyLoading.MyLoadingState.Run)
		{
			return "加载中……";
		}
		if (LoadLabyMod.State.LoadingState == MyLoading.MyLoadingState.Error)
		{
			return Conversions.ToString(Operators.ConcatenateObject((object)"获取版本列表失败：", NewLateBinding.LateGet(NewLateBinding.LateGet((object)LoadLabyMod.State, (System.Type)null, "Error", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Message", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		}
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator = ((System.Collections.Generic.IEnumerable<JToken>)ModDownload.DlLabyModListLoader.Output.Value["production"]["minecraftVersions"]).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				if (Operators.CompareString(((JObject)enumerator.Current)["version"].ToString(), SelectedMinecraftId, false) == 0)
				{
					if (SelectedOptiFine != null)
					{
						return "与 OptiFine 不兼容";
					}
					if (SelectedLoaderName != null && SelectedLoaderName != "LabyMod")
					{
						return $"与 {SelectedLoaderName} 不兼容";
					}
					return null;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)ModDownload.DlLabyModListLoader.Output.Value["snapshot"]["minecraftVersions"]).GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator2).MoveNext())
			{
				if (Operators.CompareString(((JObject)enumerator2.Current)["version"].ToString(), SelectedMinecraftId, false) == 0)
				{
					if (SelectedOptiFine != null)
					{
						return "与 OptiFine 不兼容";
					}
					if (SelectedLoaderName != null && SelectedLoaderName != "LabyMod")
					{
						return $"与 {SelectedLoaderName} 不兼容";
					}
					return null;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator2)?.Dispose();
		}
		return "不可用";
	}

	private void CardLabyMod_PreviewSwap(object sender, ModBase.RouteEventArgs e)
	{
		if (LoadLabyModGetError() != null)
		{
			e.Handled = true;
		}
	}

	private void LabyMod_Loaded()
	{
		try
		{
			if (LoadLabyMod.State.LoadingState == MyLoading.MyLoadingState.Run)
			{
				return;
			}
			JObject value = ModDownload.DlLabyModListLoader.Output.Value;
			if (value == null || value["production"] == null || value["snapshot"] == null)
			{
				return;
			}
			JArray jArray = new JArray();
			System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator = ((System.Collections.Generic.IEnumerable<JToken>)value["production"]["minecraftVersions"]).GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					if (Operators.CompareString(((JObject)enumerator.Current)["version"].ToString(), SelectedMinecraftId, false) == 0)
					{
						JObject jObject = new JObject();
						jObject.Add("version", value["production"]["labyModVersion"]);
						jObject.Add("channel", "production");
						jObject.Add("commitReference", value["production"]["commitReference"]);
						jArray.Add(jObject);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)value["snapshot"]["minecraftVersions"]).GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator2).MoveNext())
				{
					if (Operators.CompareString(((JObject)enumerator2.Current)["version"].ToString(), SelectedMinecraftId, false) == 0)
					{
						JObject jObject2 = new JObject();
						jObject2.Add("version", value["production"]["labyModVersion"]);
						jObject2.Add("channel", "snapshot");
						jObject2.Add("commitReference", value["snapshot"]["commitReference"]);
						jArray.Add(jObject2);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator2)?.Dispose();
			}
			((Panel)PanLabyMod).Children.Clear();
			((FrameworkElement)PanLabyMod).Tag = jArray;
			CardLabyMod.SwapControl = PanLabyMod;
			CardLabyMod.InstallMethod = [SpecialName] (StackPanel Stack) =>
			{
				_Closure_0024__R126_002D22 closure_0024__R126_002D = default(_Closure_0024__R126_002D22);
				foreach (JObject item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
				{
					UIElementCollection children = ((Panel)Stack).Children;
					closure_0024__R126_002D = new _Closure_0024__R126_002D22(closure_0024__R126_002D);
					closure_0024__R126_002D._0024VB_0024NonLocal_2 = ModMain.FrmDownloadInstall;
					children.Add((UIElement)(object)ModDownloadLib.LabyModDownloadListItem(item, closure_0024__R126_002D._Lambda_0024__R24));
				}
			};
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化 LabyMod 安装版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public void LabyMod_Selected(MyListItem sender, EventArgs e)
	{
		SelectedLabyModChannel = NewLateBinding.LateIndexGet(((FrameworkElement)sender).Tag, new object[] { "channel" }, (string[])null).ToString();
		SelectedLabyModCommitRef = NewLateBinding.LateIndexGet(((FrameworkElement)sender).Tag, new object[] { "commitReference" }, (string[])null).ToString();
		SelectedLabyModVersion = NewLateBinding.LateIndexGet(((FrameworkElement)sender).Tag, new object[] { "version" }, (string[])null).ToString() + ((Operators.CompareString(SelectedLabyModChannel, "snapshot", false) == 0) ? " 快照版" : " 稳定版");
		SelectedLoaderName = "LabyMod";
		CardLabyMod.IsSwapped = true;
		SelectReload();
	}

	private void LabyMod_Clear(object sender, MouseButtonEventArgs e)
	{
		SelectedLabyModCommitRef = null;
		SelectedLabyModVersion = null;
		SelectedLabyModChannel = null;
		SelectedLoaderName = null;
		SelectedAPIName = null;
		CardLabyMod.IsSwapped = true;
		((RoutedEventArgs)e).Handled = true;
		SelectReload();
	}

	private void TextSelectName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6 && ((UIElement)BtnStart).IsEnabled)
		{
			BtnStart_Click();
		}
	}

	private void BtnStart_Click()
	{
		if (SelectedLoaderName == null || (!Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("LaunchArgumentIndieV2"), (object)0, false) && !Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("LaunchArgumentIndieV2"), (object)2, false)) || ModMain.MyMsgBox("你尚未开启版本隔离，多个 MC 实例会共用同一个 Mod 文件夹。\r\n因此，游戏可能会因为读取到与当前实例不符的 Mod 而崩溃。\r\n推荐先在 设置 → 启动选项 → 默认版本隔离 中开启版本隔离！", "版本隔离提示", "取消下载", "继续") != 1)
		{
			string text = ((TextBox)TextSelectName).Text;
			if (ModDownloadLib.McInstall(new ModDownloadLib.McInstallRequest
			{
				TargetInstanceName = text,
				TargetInstanceFolder = $"{ModMinecraft.PathMcFolder}versions\\{text}\\",
				MinecraftJson = SelectedMinecraftJsonUrl,
				MinecraftName = SelectedMinecraftId,
				OptiFineEntry = SelectedOptiFine,
				ForgeEntry = SelectedForge,
				NeoForgeEntry = SelectedNeoForge,
				CleanroomEntry = SelectedCleanroom,
				FabricVersion = SelectedFabric,
				FabricApi = SelectedFabricApi,
				QuiltVersion = SelectedQuilt,
				QSL = SelectedQSL,
				OptiFabric = SelectedOptiFabric,
				LiteLoaderEntry = SelectedLiteLoader,
				LabyModChannel = SelectedLabyModChannel,
				LabyModCommitRef = SelectedLabyModCommitRef,
				LegacyFabricVersion = SelectedLegacyFabric,
				LegacyFabricApi = SelectedLegacyFabricApi
			}))
			{
				ExitSelectPage();
			}
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagedownload/pagedownloadinstall.xaml", (UriKind)2);
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
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
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Expected O, but got Unknown
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected O, but got Unknown
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Expected O, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected O, but got Unknown
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected O, but got Unknown
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Expected O, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Expected O, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Expected O, but got Unknown
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Expected O, but got Unknown
		//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected O, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected O, but got Unknown
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Expected O, but got Unknown
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected O, but got Unknown
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f9: Expected O, but got Unknown
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Expected O, but got Unknown
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Expected O, but got Unknown
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Expected O, but got Unknown
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Expected O, but got Unknown
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Expected O, but got Unknown
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0477: Expected O, but got Unknown
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected O, but got Unknown
		//IL_04a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Expected O, but got Unknown
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Expected O, but got Unknown
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d1: Expected O, but got Unknown
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e3: Expected O, but got Unknown
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f5: Expected O, but got Unknown
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0507: Expected O, but got Unknown
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_052b: Expected O, but got Unknown
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Expected O, but got Unknown
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_054f: Expected O, but got Unknown
		//IL_0557: Unknown result type (might be due to invalid IL or missing references)
		//IL_0561: Expected O, but got Unknown
		//IL_0569: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Expected O, but got Unknown
		//IL_057b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0585: Expected O, but got Unknown
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a9: Expected O, but got Unknown
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Expected O, but got Unknown
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cd: Expected O, but got Unknown
		//IL_05d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_05df: Expected O, but got Unknown
		//IL_05e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f1: Expected O, but got Unknown
		//IL_05f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0603: Expected O, but got Unknown
		//IL_061d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0627: Expected O, but got Unknown
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Expected O, but got Unknown
		//IL_0641: Unknown result type (might be due to invalid IL or missing references)
		//IL_064b: Expected O, but got Unknown
		//IL_0653: Unknown result type (might be due to invalid IL or missing references)
		//IL_065d: Expected O, but got Unknown
		//IL_0665: Unknown result type (might be due to invalid IL or missing references)
		//IL_066f: Expected O, but got Unknown
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_0681: Expected O, but got Unknown
		//IL_069b: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a5: Expected O, but got Unknown
		//IL_06ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Expected O, but got Unknown
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c9: Expected O, but got Unknown
		//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06db: Expected O, but got Unknown
		//IL_06e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ed: Expected O, but got Unknown
		//IL_06f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ff: Expected O, but got Unknown
		//IL_0719: Unknown result type (might be due to invalid IL or missing references)
		//IL_0723: Expected O, but got Unknown
		//IL_072b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0735: Expected O, but got Unknown
		//IL_073d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0747: Expected O, but got Unknown
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Expected O, but got Unknown
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_076b: Expected O, but got Unknown
		//IL_0773: Unknown result type (might be due to invalid IL or missing references)
		//IL_077d: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanAllBack = (Grid)target;
			break;
		case 2:
			PanBack = (MyScrollViewer)target;
			break;
		case 3:
			PanInner = (Grid)target;
			break;
		case 4:
			PanMinecraft = (StackPanel)target;
			break;
		case 5:
			PanSelect = (StackPanel)target;
			break;
		case 6:
			BtnBack = (MyIconButton)target;
			break;
		case 7:
			ImgLogo = (MyImage)target;
			break;
		case 8:
			TextSelectName = (MyTextBox)target;
			break;
		case 9:
			HintFabricAPI = (MyHint)target;
			break;
		case 10:
			HintLegacyFabricAPI = (MyHint)target;
			break;
		case 11:
			HintOptiFabric = (MyHint)target;
			break;
		case 12:
			HintOptiFabricOld = (MyHint)target;
			break;
		case 13:
			HintLegacyOptiFabric = (MyHint)target;
			break;
		case 14:
			HintModOptiFine = (MyHint)target;
			break;
		case 15:
			HintQSL = (MyHint)target;
			break;
		case 16:
			HintQuiltFabricAPI = (MyHint)target;
			break;
		case 17:
			CardForge = (MyCard)target;
			break;
		case 18:
			PanForge = (StackPanel)target;
			break;
		case 19:
			PanForgeInfo = (Grid)target;
			break;
		case 20:
			ImgForge = (Image)target;
			break;
		case 21:
			LabForge = (TextBlock)target;
			break;
		case 22:
			BtnForgeClear = (Grid)target;
			break;
		case 23:
			BtnForgeClearInner = (Path)target;
			break;
		case 24:
			CardCleanroom = (MyCard)target;
			break;
		case 25:
			PanCleanroom = (StackPanel)target;
			break;
		case 26:
			PanCleanroomInfo = (Grid)target;
			break;
		case 27:
			ImgCleanroom = (Image)target;
			break;
		case 28:
			LabCleanroom = (TextBlock)target;
			break;
		case 29:
			BtnCleanroomClear = (Grid)target;
			break;
		case 30:
			BtnCleanroomClearInner = (Path)target;
			break;
		case 31:
			CardNeoForge = (MyCard)target;
			break;
		case 32:
			PanNeoForge = (StackPanel)target;
			break;
		case 33:
			PanNeoForgeInfo = (Grid)target;
			break;
		case 34:
			ImgNeoForge = (Image)target;
			break;
		case 35:
			LabNeoForge = (TextBlock)target;
			break;
		case 36:
			BtnNeoForgeClear = (Grid)target;
			break;
		case 37:
			BtnNeoForgeClearInner = (Path)target;
			break;
		case 38:
			CardFabric = (MyCard)target;
			break;
		case 39:
			PanFabric = (StackPanel)target;
			break;
		case 40:
			PanFabricInfo = (Grid)target;
			break;
		case 41:
			ImgFabric = (Image)target;
			break;
		case 42:
			LabFabric = (TextBlock)target;
			break;
		case 43:
			BtnFabricClear = (Grid)target;
			break;
		case 44:
			BtnFabricClearInner = (Path)target;
			break;
		case 45:
			CardLegacyFabric = (MyCard)target;
			break;
		case 46:
			PanLegacyFabric = (StackPanel)target;
			break;
		case 47:
			PanLegacyFabricInfo = (Grid)target;
			break;
		case 48:
			ImgLegacyFabric = (Image)target;
			break;
		case 49:
			LabLegacyFabric = (TextBlock)target;
			break;
		case 50:
			BtnLegacyFabricClear = (Grid)target;
			break;
		case 51:
			BtnLegacyFabricClearInner = (Path)target;
			break;
		case 52:
			CardFabricApi = (MyCard)target;
			break;
		case 53:
			PanFabricApi = (StackPanel)target;
			break;
		case 54:
			PanFabricApiInfo = (Grid)target;
			break;
		case 55:
			ImgFabricApi = (Image)target;
			break;
		case 56:
			LabFabricApi = (TextBlock)target;
			break;
		case 57:
			BtnFabricApiClear = (Grid)target;
			break;
		case 58:
			BtnFabricApiClearInner = (Path)target;
			break;
		case 59:
			CardLegacyFabricApi = (MyCard)target;
			break;
		case 60:
			PanLegacyFabricApi = (StackPanel)target;
			break;
		case 61:
			PanLegacyFabricApiInfo = (Grid)target;
			break;
		case 62:
			ImgLegacyFabricApi = (Image)target;
			break;
		case 63:
			LabLegacyFabricApi = (TextBlock)target;
			break;
		case 64:
			BtnLegacyFabricApiClear = (Grid)target;
			break;
		case 65:
			BtnLegacyFabricApiClearInner = (Path)target;
			break;
		case 66:
			CardQuilt = (MyCard)target;
			break;
		case 67:
			PanQuilt = (StackPanel)target;
			break;
		case 68:
			PanQuiltInfo = (Grid)target;
			break;
		case 69:
			ImgQuilt = (Image)target;
			break;
		case 70:
			LabQuilt = (TextBlock)target;
			break;
		case 71:
			BtnQuiltClear = (Grid)target;
			break;
		case 72:
			BtnQuiltClearInner = (Path)target;
			break;
		case 73:
			CardQSL = (MyCard)target;
			break;
		case 74:
			PanQSL = (StackPanel)target;
			break;
		case 75:
			PanQSLInfo = (Grid)target;
			break;
		case 76:
			ImgQSL = (Image)target;
			break;
		case 77:
			LabQSL = (TextBlock)target;
			break;
		case 78:
			BtnQSLClear = (Grid)target;
			break;
		case 79:
			BtnQSLClearInner = (Path)target;
			break;
		case 80:
			CardLabyMod = (MyCard)target;
			break;
		case 81:
			PanLabyMod = (StackPanel)target;
			break;
		case 82:
			PanLabyModInfo = (Grid)target;
			break;
		case 83:
			ImgLabyMod = (Image)target;
			break;
		case 84:
			LabLabyMod = (TextBlock)target;
			break;
		case 85:
			BtnLabyModClear = (Grid)target;
			break;
		case 86:
			BtnLabyModClearInner = (Path)target;
			break;
		case 87:
			CardOptiFine = (MyCard)target;
			break;
		case 88:
			PanOptiFine = (StackPanel)target;
			break;
		case 89:
			PanOptiFineInfo = (Grid)target;
			break;
		case 90:
			ImgOptiFine = (Image)target;
			break;
		case 91:
			LabOptiFine = (TextBlock)target;
			break;
		case 92:
			BtnOptiFineClear = (Grid)target;
			break;
		case 93:
			BtnOptiFineClearInner = (Path)target;
			break;
		case 94:
			CardOptiFabric = (MyCard)target;
			break;
		case 95:
			PanOptiFabric = (StackPanel)target;
			break;
		case 96:
			PanOptiFabricInfo = (Grid)target;
			break;
		case 97:
			ImgOptiFabric = (Image)target;
			break;
		case 98:
			LabOptiFabric = (TextBlock)target;
			break;
		case 99:
			BtnOptiFabricClear = (Grid)target;
			break;
		case 100:
			BtnOptiFabricClearInner = (Path)target;
			break;
		case 101:
			CardLiteLoader = (MyCard)target;
			break;
		case 102:
			PanLiteLoader = (StackPanel)target;
			break;
		case 103:
			PanLiteLoaderInfo = (Grid)target;
			break;
		case 104:
			ImgLiteLoader = (Image)target;
			break;
		case 105:
			LabLiteLoader = (TextBlock)target;
			break;
		case 106:
			BtnLiteLoaderClear = (Grid)target;
			break;
		case 107:
			BtnLiteLoaderClearInner = (Path)target;
			break;
		case 108:
			BtnStart = (MyExtraTextButton)target;
			break;
		case 109:
			PanLoad = (MyCard)target;
			break;
		case 110:
			LoadMinecraft = (MyLoading)target;
			break;
		case 111:
			LoadOptiFine = (MyLoading)target;
			break;
		case 112:
			LoadForge = (MyLoading)target;
			break;
		case 113:
			LoadNeoForge = (MyLoading)target;
			break;
		case 114:
			LoadCleanroom = (MyLoading)target;
			break;
		case 115:
			LoadLiteLoader = (MyLoading)target;
			break;
		case 116:
			LoadFabric = (MyLoading)target;
			break;
		case 117:
			LoadLegacyFabric = (MyLoading)target;
			break;
		case 118:
			LoadFabricApi = (MyLoading)target;
			break;
		case 119:
			LoadLegacyFabricApi = (MyLoading)target;
			break;
		case 120:
			LoadQuilt = (MyLoading)target;
			break;
		case 121:
			LoadQSL = (MyLoading)target;
			break;
		case 122:
			LoadLabyMod = (MyLoading)target;
			break;
		case 123:
			LoadOptiFabric = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
