using FileSystem = Microsoft.VisualBasic.FileIO.FileSystem;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.UI;

namespace PCL;

[DesignerGenerated]
public class PageDownloadCompDetail : MyPageRight, IComponentConnector
{
	private class CardSorter : IComparer<string>
	{
		public string Topmost;

		public int Compare(string x, string y)
		{
			if (Operators.CompareString(x, y, false) == 0)
			{
				return 0;
			}
			if (Operators.CompareString(x, Topmost, false) == 0)
			{
				return -1;
			}
			if (Operators.CompareString(y, Topmost, false) == 0)
			{
				return 1;
			}
			bool flag = ModBase.EndsWithF(x, "版本");
			bool flag2 = ModBase.EndsWithF(y, "版本");
			if (flag && flag2)
			{
				return string.Compare(x, y, (StringComparison)4);
			}
			if (flag)
			{
				return 1;
			}
			if (flag2)
			{
				return -1;
			}
			checked
			{
				int num = -ModMinecraft.VersionSortInteger(x.Replace(ModBase.BeforeFirst(x, " ") + " ", ""), y.Replace(ModBase.BeforeFirst(y, " ") + " ", ""));
				if (num != 0)
				{
					return num;
				}
				return -ModMinecraft.VersionSortInteger(x, y);
			}
		}

		public CardSorter(string Topmost = "")
		{
			this.Topmost = "";
			this.Topmost = Topmost ?? "";
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_29_BtnTranslate_Click : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal EventArgs _0024VB_0024Local_e;

		internal PageDownloadCompDetail _0024VB_0024Me;

		internal TaskAwaiter<string> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter<string> awaiter;
				if (num != 0)
				{
					ModMain.Hint($"正在获取 {_0024VB_0024Me.Project.TranslatedName} 的简介译文……");
					awaiter = _0024VB_0024Me.Project.ChineseDescription.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = awaiter;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<string>, VB_0024StateMachine_29_BtnTranslate_Click>(ref awaiter, ref _this);
						return;
					}
				}
				else
				{
					num = (_0024State = -1);
					awaiter = _0024A0;
					_0024A0 = default(TaskAwaiter<string>);
				}
				string result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<string>);
				string text = result;
				if (text != null)
				{
					ModMain.MyMsgBox($"原文：{_0024VB_0024Me.Project.Description}{Environment.NewLine}译文：{text}");
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception exception = ex;
				_0024State = -2;
				_0024Builder.SetException(exception);
				ProjectData.ClearProjectError();
				return;
			}
			num = (_0024State = -2);
			_0024Builder.SetResult();
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[CompilerGenerated]
	internal new sealed class _Closure_0024__20_002D0
	{
		public string _0024VB_0024Local_Target;

		public string _0024VB_0024Local_InstanceName;

		public string _0024VB_0024Local_LogoFileAddress;

		public ModComp.CompFile _0024VB_0024Local_File;

		[SpecialName]
		internal void _Lambda_0024__R8(ModLoader.LoaderTask<int, int> a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			ModModpack.ModpackInstall(_0024VB_0024Local_Target, _0024VB_0024Local_InstanceName, File.Exists(_0024VB_0024Local_LogoFileAddress) ? _0024VB_0024Local_LogoFileAddress : null, _0024VB_0024Local_File.ProjectId);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__21_002D0
	{
		public ModComp.CompFile _0024VB_0024Local_File;

		public List<ModComp.CompLoaderType> _0024VB_0024Local_AllowedLoaders;

		public Func<ModMinecraft.McInstance, bool> _0024VB_0024Local_IsVersionSuitable;

		public string _0024VB_0024Local_SubFolder;

		public string _0024VB_0024Local_Target;

		public string _0024VB_0024Local_TargetPath;

		[SpecialName]
		internal bool _Lambda_0024__0(ModMinecraft.McInstance Version)
		{
			_Closure_0024__21_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__21_002D1
			{
				_0024VB_0024Local_Version = Version
			};
			if ((object)CS_0024_003C_003E8__locals0._0024VB_0024Local_Version == null)
			{
				return false;
			}
			if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_Version.IsLoaded)
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Version.Load();
			}
			if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)_0024VB_0024Local_File.GameVersions, (Func<string, bool>)([SpecialName] (string v) => v.Contains("."))) && !Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)_0024VB_0024Local_File.GameVersions, (Func<string, bool>)([SpecialName] (string v) => v.Contains(".") && Operators.CompareString(v, CS_0024_003C_003E8__locals0._0024VB_0024Local_Version.Version.McName, false) == 0)))
			{
				return false;
			}
			if (!Enumerable.Any<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)_0024VB_0024Local_AllowedLoaders))
			{
				return true;
			}
			return false;
		}

		[SpecialName]
		internal bool _Lambda_0024__4(ModMinecraft.McInstance v)
		{
			return _0024VB_0024Local_IsVersionSuitable.Invoke(v);
		}

		[SpecialName]
		internal DirectoryInfo _Lambda_0024__5(ModMinecraft.McInstance v)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Expected O, but got Unknown
			return new DirectoryInfo($"{v.PathIndie}{_0024VB_0024Local_SubFolder}");
		}

		[SpecialName]
		internal void _Lambda_0024__R9(ModLoader.LoaderTask<int, int> a0)
		{
			_Lambda_0024__8();
		}

		[SpecialName]
		internal void _Lambda_0024__8()
		{
			ModBase.ExtractFile(_0024VB_0024Local_Target, _0024VB_0024Local_TargetPath, Encoding.UTF8);
		}

		[SpecialName]
		internal void _Lambda_0024__R10(ModLoader.LoaderTask<int, int> a0)
		{
			_Lambda_0024__9();
		}

		[SpecialName]
		internal void _Lambda_0024__9()
		{
			File.Delete(_0024VB_0024Local_Target);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__21_002D1
	{
		public ModMinecraft.McInstance _0024VB_0024Local_Version;

		[SpecialName]
		internal bool _Lambda_0024__2(string v)
		{
			if (v.Contains("."))
			{
				return Operators.CompareString(v, _0024VB_0024Local_Version.Version.McName, false) == 0;
			}
			return false;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__R16_002D3
	{
		public PageDownloadCompDetail _0024VB_0024NonLocal_2;

		public _Closure_0024__R16_002D3(_Closure_0024__R16_002D3 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024NonLocal_2 = arg0._0024VB_0024NonLocal_2;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R6(object a0, MouseButtonEventArgs a1)
		{
			_0024VB_0024NonLocal_2.Install_Click((MyListItem)a0, (EventArgs)(object)a1);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__R16_002D4
	{
		public PageDownloadCompDetail _0024VB_0024NonLocal_3;

		public _Closure_0024__R16_002D4(_Closure_0024__R16_002D4 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024NonLocal_3 = arg0._0024VB_0024NonLocal_3;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R7(object a0, MouseButtonEventArgs a1)
		{
			_0024VB_0024NonLocal_3.InstallWorld_Click((MyListItem)a0, (EventArgs)(object)a1);
		}
	}

	private MyCompItem CompItem;

	private ModLoader.LoaderTask<int, List<ModComp.CompFile>> CompFileLoader;

	private ModComp.CompProject Project;

	private string TargetVersion;

	private ModComp.CompLoaderType TargetLoader;

	private ModComp.CompType PageType;

	private string VersionFilter;

	private bool IsMajorVersionFilter;

	private bool IsFirstInit;

	public static Dictionary<ModComp.CompType, string> CachedFolder = new Dictionary<ModComp.CompType, string>();

	[CompilerGenerated]
	[AccessedThroughProperty("BtnIntroWeb")]
	private MyIconTextButton _BtnIntroWeb;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnIntroWiki")]
	private MyIconTextButton _BtnIntroWiki;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnIntroCopy")]
	private MyIconTextButton _BtnIntroCopy;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnIntroLinkCopy")]
	private MyIconTextButton _BtnIntroLinkCopy;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnTranslate")]
	private MyIconTextButton _BtnTranslate;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnFavorites")]
	private MyIconTextButton _BtnFavorites;

	[CompilerGenerated]
	[AccessedThroughProperty("Load")]
	private MyLoading _Load;

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
	[field: AccessedThroughProperty("CardIntro")]
	internal virtual MyCard CardIntro
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanIntro")]
	internal virtual StackPanel PanIntro
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconTextButton BtnIntroWeb
	{
		[CompilerGenerated]
		get
		{
			return _BtnIntroWeb;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnIntroWeb_Click;
			MyIconTextButton btnIntroWeb = _BtnIntroWeb;
			if (btnIntroWeb != null)
			{
				btnIntroWeb.Click -= obj;
			}
			_BtnIntroWeb = value;
			btnIntroWeb = _BtnIntroWeb;
			if (btnIntroWeb != null)
			{
				btnIntroWeb.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnIntroWiki
	{
		[CompilerGenerated]
		get
		{
			return _BtnIntroWiki;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnIntroWiki_Click;
			MyIconTextButton btnIntroWiki = _BtnIntroWiki;
			if (btnIntroWiki != null)
			{
				btnIntroWiki.Click -= obj;
			}
			_BtnIntroWiki = value;
			btnIntroWiki = _BtnIntroWiki;
			if (btnIntroWiki != null)
			{
				btnIntroWiki.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnIntroCopy
	{
		[CompilerGenerated]
		get
		{
			return _BtnIntroCopy;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnIntroCopy_Click;
			MyIconTextButton btnIntroCopy = _BtnIntroCopy;
			if (btnIntroCopy != null)
			{
				btnIntroCopy.Click -= obj;
			}
			_BtnIntroCopy = value;
			btnIntroCopy = _BtnIntroCopy;
			if (btnIntroCopy != null)
			{
				btnIntroCopy.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnIntroLinkCopy
	{
		[CompilerGenerated]
		get
		{
			return _BtnIntroLinkCopy;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnIntroLinkCopy_Click;
			MyIconTextButton btnIntroLinkCopy = _BtnIntroLinkCopy;
			if (btnIntroLinkCopy != null)
			{
				btnIntroLinkCopy.Click -= obj;
			}
			_BtnIntroLinkCopy = value;
			btnIntroLinkCopy = _BtnIntroLinkCopy;
			if (btnIntroLinkCopy != null)
			{
				btnIntroLinkCopy.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnTranslate
	{
		[CompilerGenerated]
		get
		{
			return _BtnTranslate;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnTranslate_Click;
			MyIconTextButton btnTranslate = _BtnTranslate;
			if (btnTranslate != null)
			{
				btnTranslate.Click -= obj;
			}
			_BtnTranslate = value;
			btnTranslate = _BtnTranslate;
			if (btnTranslate != null)
			{
				btnTranslate.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnFavorites
	{
		[CompilerGenerated]
		get
		{
			return _BtnFavorites;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnFavorites_Click;
			MyIconTextButton btnFavorites = _BtnFavorites;
			if (btnFavorites != null)
			{
				btnFavorites.Click -= obj;
			}
			_BtnFavorites = value;
			btnFavorites = _BtnFavorites;
			if (btnFavorites != null)
			{
				btnFavorites.Click += obj;
			}
		}
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
	[field: AccessedThroughProperty("CardFilter")]
	internal virtual MyCard CardFilter
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanFilter")]
	internal virtual StackPanel PanFilter
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanResults")]
	internal virtual StackPanel PanResults
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
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

	internal virtual MyLoading Load
	{
		[CompilerGenerated]
		get
		{
			return _Load;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.StateChangedEventHandler obj = Load_State;
			MyLoading load = _Load;
			if (load != null)
			{
				load.StateChanged -= obj;
			}
			_Load = value;
			load = _Load;
			if (load != null)
			{
				load.StateChanged += obj;
			}
		}
	}

	public PageDownloadCompDetail()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Initialized += new EventHandler(PageDownloadCompDetail_Inited);
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			LoadTargetFromAdditional();
		});
		base.PageEnter += Init;
		CompItem = null;
		CompFileLoader = new ModLoader.LoaderTask<int, List<ModComp.CompFile>>("Comp File", [SpecialName] [CompilerGenerated] (ModLoader.LoaderTask<int, List<ModComp.CompFile>> Task) =>
		{
			LoadTargetFromAdditional();
			List<ModComp.CompFile> output = ModComp.CompFilesGet(Project.Id, Project.FromCurseForge);
			if (!Task.IsAborted)
			{
				Task.Output = output;
			}
		}, null, (ThreadPriority)2);
		IsFirstInit = true;
		InitializeComponent();
	}

	private void PageDownloadCompDetail_Inited(object sender, EventArgs e)
	{
		LoadTargetFromAdditional();
		PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanMain, (FrameworkElement)(object)CardIntro, CompFileLoader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
		{
			Load_OnFinish();
		});
	}

	public void LoadTargetFromAdditional()
	{
		Project = (ModComp.CompProject)NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[] { 0 }, (string[])null);
		TargetVersion = Conversions.ToString(NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[] { 2 }, (string[])null));
		TargetLoader = (ModComp.CompLoaderType)Conversions.ToInteger(NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[] { 3 }, (string[])null));
		PageType = (ModComp.CompType)Conversions.ToInteger(NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[] { 4 }, (string[])null));
	}

	private void Load_State(object sender, MyLoading.MyLoadingState state, MyLoading.MyLoadingState oldState)
	{
		ModBase.LoadState state2 = CompFileLoader.State;
		if (state2 == ModBase.LoadState.Failed)
		{
			string text = "";
			if (CompFileLoader.Error != null)
			{
				text = CompFileLoader.Error.Message;
			}
			if (text.Contains("不是有效的 Json 文件"))
			{
				ModBase.Log("[Comp] 下载的文件 Json 列表损坏，已自动重试", ModBase.LogLevel.Debug);
				PageLoaderRestart();
			}
		}
	}

	private List<ModComp.CompFile> GetResults()
	{
		List<ModComp.CompFile> val = CompFileLoader.Output;
		if (PageType == ModComp.CompType.Any)
		{
			val = Enumerable.ToList<ModComp.CompFile>(Enumerable.Where<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)val, (Func<ModComp.CompFile, bool>)([SpecialName] (ModComp.CompFile r) => r.Type != ModComp.CompType.Plugin)));
		}
		else if (PageType != ModComp.CompType.Shader && PageType != ModComp.CompType.ResourcePack)
		{
			val = Enumerable.ToList<ModComp.CompFile>(Enumerable.Where<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)val, (Func<ModComp.CompFile, bool>)([SpecialName] [CompilerGenerated] (ModComp.CompFile r) => r.Type == PageType)));
		}
		return val;
	}

	private void Load_OnFinish()
	{
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		List<ModComp.CompFile> results = GetResults();
		IsMajorVersionFilter = false;
		List<string> val = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)Enumerable.OrderByDescending<string, string>(Enumerable.Distinct<string>(Enumerable.Select<string, string>(Enumerable.SelectMany<ModComp.CompFile, string>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)results, (Func<ModComp.CompFile, System.Collections.Generic.IEnumerable<string>>)([SpecialName] (ModComp.CompFile v) => (System.Collections.Generic.IEnumerable<string>)v.GameVersions)), (Func<string, string>)([SpecialName] [CompilerGenerated] (string v) => GetGroupedVersionName(v, IsMajorVersionFilter, FoldOldRelease: true)))), (Func<string, string>)([SpecialName] (string s) => s), (IComparer<string>)new ModMinecraft.VersionComparer()));
		if (val.Count >= 9)
		{
			IsMajorVersionFilter = true;
			val = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)Enumerable.OrderByDescending<string, string>(Enumerable.Distinct<string>(Enumerable.Select<string, string>(Enumerable.SelectMany<ModComp.CompFile, string>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)results, (Func<ModComp.CompFile, System.Collections.Generic.IEnumerable<string>>)([SpecialName] (ModComp.CompFile v) => (System.Collections.Generic.IEnumerable<string>)v.GameVersions)), (Func<string, string>)([SpecialName] [CompilerGenerated] (string v) => GetGroupedVersionName(v, IsMajorVersionFilter, FoldOldRelease: true)))), (Func<string, string>)([SpecialName] (string s) => s), (IComparer<string>)new ModMinecraft.VersionComparer()));
		}
		((Panel)PanFilter).Children.Clear();
		if (val.Count < 2)
		{
			((UIElement)CardFilter).Visibility = (Visibility)2;
			VersionFilter = null;
		}
		else
		{
			((UIElement)CardFilter).Visibility = (Visibility)0;
			val.Insert(0, "全部");
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = val.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					MyRadioButton obj = new MyRadioButton
					{
						Text = current
					};
					((FrameworkElement)obj).Margin = new Thickness(2.0, 0.0, 2.0, 0.0);
					obj.ColorType = MyRadioButton.ColorState.Highlight;
					MyRadioButton myRadioButton = obj;
					((FrameworkElement)myRadioButton.LabText).Margin = new Thickness(-2.0, 0.0, 8.0, 0.0);
					myRadioButton.Check += [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
					{
						_Lambda_0024__15_002D6((MyRadioButton)a0, a1);
					};
					((Panel)PanFilter).Children.Add((UIElement)(object)myRadioButton);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			MyRadioButton myRadioButton2 = null;
			if (Operators.CompareString(TargetVersion, "", false) != 0 && Enumerable.FirstOrDefault<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)results, (Func<ModComp.CompFile, bool>)([SpecialName] [CompilerGenerated] (ModComp.CompFile v) => v.GameVersions.Contains(TargetVersion))) != null)
			{
				string groupedVersionName = GetGroupedVersionName(TargetVersion, IsMajorVersionFilter, FoldOldRelease: true);
				foreach (MyRadioButton child in ((Panel)PanFilter).Children)
				{
					if (Operators.CompareString(child.Text, groupedVersionName, false) == 0)
					{
						myRadioButton2 = child;
						break;
					}
				}
			}
			if (myRadioButton2 == null)
			{
				myRadioButton2 = (MyRadioButton)(object)((Panel)PanFilter).Children[0];
			}
			myRadioButton2.Checked = true;
		}
		UpdateFilterResult();
	}

	private void UpdateFilterResult()
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Expected O, but got Unknown
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_0444: Expected O, but got Unknown
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		List<ModComp.CompFile> results = GetResults();
		string text = ((TargetLoader != 0) ? (((System.Enum)TargetLoader).ToString() + " ") : "");
		string text2 = ((Operators.CompareString(TargetVersion, "", false) != 0 || TargetLoader != 0) ? $"所选版本：{text}{TargetVersion}" : "");
		SortedDictionary<string, List<ModComp.CompFile>> val = new SortedDictionary<string, List<ModComp.CompFile>>((IComparer<string>)new CardSorter(text2));
		val.Add("其他版本", new List<ModComp.CompFile>());
		List<int> val2 = new List<int>((System.Collections.Generic.IEnumerable<int>)System.Enum.GetValues(typeof(ModComp.CompLoaderType)));
		System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
		try
		{
			enumerator = results.GetEnumerator();
			System.Collections.Generic.IEnumerator<string> enumerator2 = default(System.Collections.Generic.IEnumerator<string>);
			System.Collections.Generic.IEnumerator<ModComp.CompLoaderType> enumerator3 = default(System.Collections.Generic.IEnumerator<ModComp.CompLoaderType>);
			System.Collections.Generic.IEnumerator<string> enumerator4 = default(System.Collections.Generic.IEnumerator<string>);
			while (enumerator.MoveNext())
			{
				ModComp.CompFile current = enumerator.Current;
				try
				{
					enumerator2 = current.GameVersions.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						string current2 = enumerator2.Current;
						if (VersionFilter != null && Operators.CompareString(GetGroupedVersionName(current2, IsMajorVersionFilter, FoldOldRelease: true), VersionFilter, false) != 0)
						{
							continue;
						}
						string groupedVersionName = GetGroupedVersionName(current2, MajorOnly: false, FoldOldRelease: false);
						List<string> val3 = new List<string>();
						if (Project.ModLoaders.Count > 1 && current.Type == ModComp.CompType.Mod && PCLVerCompat.StartsWithVer2(groupedVersionName, "1."))
						{
							try
							{
								enumerator3 = current.ModLoaders.GetEnumerator();
								while (enumerator3.MoveNext())
								{
									ModComp.CompLoaderType current3 = enumerator3.Current;
									if (!Conversions.ToBoolean((object)(current3 == ModComp.CompLoaderType.Quilt && Conversions.ToBoolean(ModBase.Setup.Get("ToolDownloadIgnoreQuilt")))) && val2.Contains((int)current3))
									{
										val3.Add(((System.Enum)current3).ToString() + " ");
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator3).Dispose();
							}
						}
						if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val3))
						{
							val3.Add("");
						}
						try
						{
							enumerator4 = val3.GetEnumerator();
							while (enumerator4.MoveNext())
							{
								string text3 = enumerator4.Current + groupedVersionName;
								if (!val.ContainsKey(text3))
								{
									val.Add(text3, new List<ModComp.CompFile>());
								}
								if (!val[text3].Contains(current))
								{
									val[text3].Add(current);
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator4).Dispose();
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator2).Dispose();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		if (Operators.CompareString(text2, "", false) != 0 && (VersionFilter == null || ModBase.StartsWithF(GetGroupedVersionName(TargetVersion, IsMajorVersionFilter, FoldOldRelease: true), VersionFilter)))
		{
			val.Add(text2, new List<ModComp.CompFile>());
			System.Collections.Generic.IEnumerator<ModComp.CompFile> enumerator5 = default(System.Collections.Generic.IEnumerator<ModComp.CompFile>);
			try
			{
				enumerator5 = results.GetEnumerator();
				while (enumerator5.MoveNext())
				{
					ModComp.CompFile current4 = enumerator5.Current;
					if (current4.GameVersions.Contains(TargetVersion) && (TargetLoader == ModComp.CompLoaderType.Any || current4.ModLoaders.Contains(TargetLoader)) && (VersionFilter == null || Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)current4.GameVersions, (Func<string, bool>)([SpecialName] [CompilerGenerated] (string v) => Operators.CompareString(GetGroupedVersionName(v, IsMajorVersionFilter, FoldOldRelease: true), VersionFilter, false) == 0))) && !val[text2].Contains(current4))
					{
						val[text2].Add(current4);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator5).Dispose();
			}
		}
		try
		{
			((Panel)PanResults).Children.Clear();
			System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<ModComp.CompFile>>> enumerator6 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<ModComp.CompFile>>>);
			try
			{
				enumerator6 = val.GetEnumerator();
				while (enumerator6.MoveNext())
				{
					KeyValuePair<string, List<ModComp.CompFile>> current5 = enumerator6.Current;
					if (!Enumerable.Any<ModComp.CompFile>((System.Collections.Generic.IEnumerable<ModComp.CompFile>)current5.Value))
					{
						continue;
					}
					MyCard obj = new MyCard
					{
						Title = current5.Key
					};
					((FrameworkElement)obj).Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
					MyCard myCard = obj;
					StackPanel val4 = new StackPanel
					{
						Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
						VerticalAlignment = (VerticalAlignment)0,
						RenderTransform = (Transform)new TranslateTransform(0.0, 0.0),
						Tag = current5.Value
					};
					((Panel)myCard).Children.Add((UIElement)(object)val4);
					myCard.InstallMethod = [SpecialName] [CompilerGenerated] (StackPanel Stack) =>
					{
						((FrameworkElement)Stack).Tag = ModBase.Sort((System.Collections.Generic.IList<ModComp.CompFile>)(List<ModComp.CompFile>)((FrameworkElement)Stack).Tag, [SpecialName] (ModComp.CompFile a, ModComp.CompFile b) => System.DateTime.Compare(a.ReleaseDate, b.ReleaseDate) > 0);
						bool badDisplayName = ModBase.Distinct((System.Collections.Generic.ICollection<ModComp.CompFile>)(List<ModComp.CompFile>)((FrameworkElement)Stack).Tag, [SpecialName] (ModComp.CompFile a, ModComp.CompFile b) => Operators.CompareString(a.DisplayName, b.DisplayName, false) == 0).Count != ((List<ModComp.CompFile>)((FrameworkElement)Stack).Tag).Count;
						if (Project.Type != ModComp.CompType.ModPack)
						{
							if (Project.Type != ModComp.CompType.World)
							{
								ModComp.CompFilesCardPreload(Stack, (List<ModComp.CompFile>)((FrameworkElement)Stack).Tag);
								{
									foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
									{
										object objectValue = RuntimeHelpers.GetObjectValue(item);
										((Panel)Stack).Children.Add((UIElement)(object)((ModComp.CompFile)objectValue).ToListItem(ModMain.FrmDownloadCompDetail.Save_Click, null, badDisplayName));
									}
									return;
								}
							}
							{
								_Closure_0024__R16_002D4 closure_0024__R16_002D = default(_Closure_0024__R16_002D4);
								foreach (object item2 in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
								{
									object objectValue2 = RuntimeHelpers.GetObjectValue(item2);
									UIElementCollection children2 = ((Panel)Stack).Children;
									ModComp.CompFile obj3 = (ModComp.CompFile)objectValue2;
									closure_0024__R16_002D = new _Closure_0024__R16_002D4(closure_0024__R16_002D);
									closure_0024__R16_002D._0024VB_0024NonLocal_3 = ModMain.FrmDownloadCompDetail;
									children2.Add((UIElement)(object)obj3.ToListItem(closure_0024__R16_002D._Lambda_0024__R7, ModMain.FrmDownloadCompDetail.Save_Click, badDisplayName));
								}
								return;
							}
						}
						_Closure_0024__R16_002D3 closure_0024__R16_002D2 = default(_Closure_0024__R16_002D3);
						foreach (object item3 in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
						{
							object objectValue3 = RuntimeHelpers.GetObjectValue(item3);
							UIElementCollection children3 = ((Panel)Stack).Children;
							ModComp.CompFile obj4 = (ModComp.CompFile)objectValue3;
							closure_0024__R16_002D2 = new _Closure_0024__R16_002D3(closure_0024__R16_002D2);
							closure_0024__R16_002D2._0024VB_0024NonLocal_2 = ModMain.FrmDownloadCompDetail;
							children3.Add((UIElement)(object)obj4.ToListItem(closure_0024__R16_002D2._Lambda_0024__R6, ModMain.FrmDownloadCompDetail.Save_Click, badDisplayName));
						}
					};
					myCard.SwapControl = val4;
					((Panel)PanResults).Children.Add((UIElement)(object)myCard);
					if (Operators.CompareString(current5.Key, text2, false) == 0 || (ModMain.FrmMain.PageCurrent.Additional != null && ((List<string>)NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[] { 1 }, (string[])null)).Contains(myCard.Title)))
					{
						myCard.StackInstall();
					}
					else
					{
						myCard.IsSwapped = true;
					}
					if (Operators.CompareString(current5.Key, "其他版本", false) == 0)
					{
						UIElementCollection children = ((Panel)val4).Children;
						MyHint obj2 = new MyHint
						{
							Text = "由于版本信息更新缓慢，可能无法识别刚更新的 MC 版本。几天后即可正常识别。",
							Theme = MyHint.Themes.Yellow
						};
						((FrameworkElement)obj2).Margin = new Thickness(5.0, 0.0, 0.0, 8.0);
						children.Add((UIElement)(object)obj2);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator6).Dispose();
			}
			if (((Panel)PanResults).Children.Count == 1)
			{
				((MyCard)(object)((Panel)PanResults).Children[0]).IsSwapped = false;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "可视化工程下载列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private string GetGroupedVersionName(string Name, bool MajorOnly, bool FoldOldRelease)
	{
		if (Name == null)
		{
			return "其他版本";
		}
		if (Name.Contains("w"))
		{
			return "快照版本";
		}
		if (Name.StartsWith("1.0") || !PCLVerCompat.StartsWithVer2(Name, "1.") || (FoldOldRelease && ModBase.Val(Name.Split(".", (StringSplitOptions)0)[1]) < 10.0))
		{
			return "远古版本";
		}
		return MajorOnly ? ("1." + ModBase.BeforeFirst(Name.Split(".", (StringSplitOptions)0)[1], " ")) : Name;
	}

	private void Init()
	{
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			ModAnimation.AniControlEnabled++;
			Project = (ModComp.CompProject)NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[] { 0 }, (string[])null);
			((ScrollViewer)PanBack).ScrollToHome();
			if (IsFirstInit)
			{
				IsFirstInit = false;
			}
			else
			{
				PageLoaderRestart();
			}
			if (CompItem != null)
			{
				((Panel)PanIntro).Children.Remove((UIElement)(object)CompItem);
			}
			CompItem = Project.ToCompItem(ShowMcVersionDesc: true, ShowLoaderDesc: true);
			CompItem.CanInteraction = false;
			CompItem.ShowFavoriteBtn = false;
			((FrameworkElement)CompItem).Margin = new Thickness(-7.0, -7.0, 0.0, 8.0);
			((Panel)PanIntro).Children.Insert(0, (UIElement)(object)CompItem);
			BtnIntroWeb.Text = (Project.FromCurseForge ? "CurseForge" : "Modrinth");
			((UIElement)BtnIntroWiki).Visibility = (Visibility)((Project.WikiId == 0) ? 2 : 0);
			ModAnimation.AniControlEnabled--;
		}
	}

	public void Install_Click(MyListItem sender, EventArgs e)
	{
		try
		{
			_Closure_0024__20_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__20_002D0();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_File = (ModComp.CompFile)((FrameworkElement)sender).Tag;
			string name = string.Format("{0} 整合包下载：{1} ", (object)(Project.FromCurseForge ? "CurseForge" : "Modrinth"), (object)Project.TranslatedName);
			string text = Project.TranslatedName.Replace(".zip", "").Replace(".rar", "").Replace(".mrpack", "")
				.Replace("\\", "＼")
				.Replace("/", "／")
				.Replace("|", "｜")
				.Replace(":", "：")
				.Replace("<", "＜")
				.Replace(">", "＞")
				.Replace("*", "＊")
				.Replace("?", "？")
				.Replace("\"", "")
				.Replace("： ", "：");
			ValidateFolderName validateFolderName = new ValidateFolderName(ModMinecraft.PathMcFolder + "versions");
			if (Operators.CompareString(validateFolderName.ValidateText(text), "", false) != 0)
			{
				text = "";
			}
			string defaultInput = text;
			Collection<Validate> obj = new Collection<Validate>();
			obj.Add((Validate)validateFolderName);
			CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName = ModMain.MyMsgBoxInput("输入实例名称", "", defaultInput, obj);
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName))
			{
				return;
			}
			List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Target = string.Format("{0}versions\\{1}\\原始整合包.{2}", (object)ModMinecraft.PathMcFolder, (object)CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName, (object)(Project.FromCurseForge ? "zip" : "mrpack"));
			CS_0024_003C_003E8__locals0._0024VB_0024Local_LogoFileAddress = MyImage.GetTempPath(CompItem.Logo);
			List<ModNet.NetFile> obj2 = new List<ModNet.NetFile>();
			obj2.Add(CS_0024_003C_003E8__locals0._0024VB_0024Local_File.ToNetFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_Target));
			val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载整合包文件", obj2)
			{
				ProgressWeight = 10.0,
				Block = true
			});
			val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("准备安装整合包", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__0();
			}, null, (ThreadPriority)2)
			{
				ProgressWeight = 0.1
			});
			ModLoader.LoaderCombo<string> loaderCombo = new ModLoader.LoaderCombo<string>(name, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
			loaderCombo.OnStateChanged = [SpecialName] (ModLoader.LoaderBase MyLoader) =>
			{
				switch (MyLoader.State)
				{
				case ModBase.LoadState.Failed:
					ModMain.Hint(MyLoader.Name + "失败：" + MyLoader.Error.Message, ModMain.HintType.Critical);
					break;
				case ModBase.LoadState.Aborted:
					ModMain.Hint(MyLoader.Name + "已取消！");
					break;
				case ModBase.LoadState.Loading:
					return;
				}
				ModDownloadLib.McInstallFailedClearFolder(MyLoader);
			};
			loaderCombo.Start(ModMinecraft.PathMcFolder + "versions\\" + CS_0024_003C_003E8__locals0._0024VB_0024Local_InstanceName + "\\");
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "下载资源整合包失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public void InstallWorld_Click(MyListItem sender, EventArgs e)
	{
		try
		{
			_Closure_0024__21_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__21_002D0();
			CS_0024_003C_003E8__locals0._0024VB_0024Local_File = (ModComp.CompFile)((FrameworkElement)sender).Tag;
			string name = string.Format("{0} 世界下载：{1} ", (object)(Project.FromCurseForge ? "CurseForge" : "Modrinth"), (object)Project.TranslatedName);
			string text = null;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_SubFolder = "saves\\";
			CS_0024_003C_003E8__locals0._0024VB_0024Local_IsVersionSuitable = null;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_AllowedLoaders = new List<ModComp.CompLoaderType>();
			if (Enumerable.Any<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)CS_0024_003C_003E8__locals0._0024VB_0024Local_File.ModLoaders))
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_AllowedLoaders = CS_0024_003C_003E8__locals0._0024VB_0024Local_File.ModLoaders;
			}
			else if (Enumerable.Any<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)Project.ModLoaders))
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_AllowedLoaders = Project.ModLoaders;
			}
			ModBase.Log("[Comp] 世界要求的加载器种类：" + (Enumerable.Any<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)CS_0024_003C_003E8__locals0._0024VB_0024Local_AllowedLoaders) ? ModBase.Join((System.Collections.IEnumerable)CS_0024_003C_003E8__locals0._0024VB_0024Local_AllowedLoaders, " / ") : "无要求"));
			CS_0024_003C_003E8__locals0._0024VB_0024Local_IsVersionSuitable = [SpecialName] (ModMinecraft.McInstance Version) =>
			{
				if ((object)Version == null)
				{
					return false;
				}
				if (!Version.IsLoaded)
				{
					Version.Load();
				}
				if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0._0024VB_0024Local_File.GameVersions, (Func<string, bool>)([SpecialName] (string v) => v.Contains("."))) && !Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)CS_0024_003C_003E8__locals0._0024VB_0024Local_File.GameVersions, (Func<string, bool>)([SpecialName] (string v) => v.Contains(".") && Operators.CompareString(v, Version.Version.McName, false) == 0)))
				{
					return false;
				}
				return !Enumerable.Any<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)CS_0024_003C_003E8__locals0._0024VB_0024Local_AllowedLoaders);
			};
			if (CachedFolder.ContainsKey(Project.Type) && !string.IsNullOrEmpty(CachedFolder[Project.Type]))
			{
				text = ModBase.GetOrDefault(CachedFolder, Project.Type, ModMinecraft.McInstanceCurrent?.PathIndie ?? ModBase.ExePath);
				ModBase.Log($"[Comp] 使用上次下载时的文件夹作为默认下载位置：{text}");
			}
			else if ((object)ModMinecraft.McInstanceCurrent != null && CS_0024_003C_003E8__locals0._0024VB_0024Local_IsVersionSuitable.Invoke(ModMinecraft.McInstanceCurrent))
			{
				text = $"{ModMinecraft.McInstanceCurrent.PathIndie}{CS_0024_003C_003E8__locals0._0024VB_0024Local_SubFolder}";
				Directory.CreateDirectory(text);
				ModBase.Log($"[Comp] 使用当前实例作为默认下载位置：{text}");
			}
			else
			{
				bool flag = ModMinecraft.McInstanceListLoader.State != ModBase.LoadState.Finished;
				if (flag)
				{
					ModMain.Hint("正在查找适合的游戏实例……");
					ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", WaitForExit: true);
				}
				System.Collections.Generic.IEnumerable<DirectoryInfo> enumerable = Enumerable.Select<ModMinecraft.McInstance, DirectoryInfo>(Enumerable.Where<ModMinecraft.McInstance>(Enumerable.SelectMany<List<ModMinecraft.McInstance>, ModMinecraft.McInstance>((System.Collections.Generic.IEnumerable<List<ModMinecraft.McInstance>>)ModMinecraft.McInstanceList.Values, (Func<List<ModMinecraft.McInstance>, System.Collections.Generic.IEnumerable<ModMinecraft.McInstance>>)([SpecialName] (List<ModMinecraft.McInstance> l) => (System.Collections.Generic.IEnumerable<ModMinecraft.McInstance>)l)), (Func<ModMinecraft.McInstance, bool>)([SpecialName] (ModMinecraft.McInstance v) => CS_0024_003C_003E8__locals0._0024VB_0024Local_IsVersionSuitable.Invoke(v))), (Func<ModMinecraft.McInstance, DirectoryInfo>)([SpecialName] (ModMinecraft.McInstance v) => new DirectoryInfo($"{v.PathIndie}{CS_0024_003C_003E8__locals0._0024VB_0024Local_SubFolder}")));
				if (Enumerable.Any<DirectoryInfo>(enumerable))
				{
					text = ((FileSystemInfo)Enumerable.First<DirectoryInfo>((System.Collections.Generic.IEnumerable<DirectoryInfo>)Enumerable.ThenByDescending<DirectoryInfo, int>(Enumerable.OrderByDescending<DirectoryInfo, System.DateTime>(enumerable, (Func<DirectoryInfo, System.DateTime>)([SpecialName] (DirectoryInfo Dir) => (!Dir.Exists) ? System.DateTime.MinValue : ((FileSystemInfo)Dir).LastWriteTimeUtc)), (Func<DirectoryInfo, int>)([SpecialName] (DirectoryInfo Dir) => (!Dir.Exists) ? (-1) : Dir.GetFiles().Length)))).FullName;
					Directory.CreateDirectory(text);
					ModBase.Log($"[Comp] 使用适合的游戏实例作为默认下载位置：{text}");
				}
				else
				{
					text = ModMinecraft.PathMcFolder;
					if (flag)
					{
						ModMain.Hint("当前 MC 文件夹中没有找到适合此资源文件的实例！");
					}
					else
					{
						ModBase.Log("[Comp] 由于当前实例不兼容，使用当前的 MC 文件夹作为默认下载位置");
					}
				}
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Target = SystemDialogs.SelectSaveFile("选择世界安装位置 (saves 文件夹)", CS_0024_003C_003E8__locals0._0024VB_0024Local_File.FileName, "世界文件|*.zip", text);
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Local_Target))
			{
				List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
				CS_0024_003C_003E8__locals0._0024VB_0024Local_TargetPath = ModBase.BeforeLast(CS_0024_003C_003E8__locals0._0024VB_0024Local_Target, "\\");
				MyImage.GetTempPath(CompItem.Logo);
				List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
				obj.Add(CS_0024_003C_003E8__locals0._0024VB_0024Local_File.ToNetFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_Target));
				val.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载世界文件", obj)
				{
					ProgressWeight = 10.0,
					Block = true
				});
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("安装世界", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					CS_0024_003C_003E8__locals0._Lambda_0024__8();
				}, null, (ThreadPriority)2)
				{
					ProgressWeight = 0.1,
					Block = true
				});
				val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("清理缓存", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					CS_0024_003C_003E8__locals0._Lambda_0024__9();
				}, null, (ThreadPriority)2));
				ModLoader.LoaderCombo<int> loaderCombo = new ModLoader.LoaderCombo<int>(name, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val);
				loaderCombo.OnStateChanged = ModDownloadLib.LoaderStateChangedHintOnly;
				loaderCombo.Start();
				ModLoader.LoaderTaskbarAdd(loaderCombo);
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
				ModMain.FrmMain.BtnExtraDownload.Ribble();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "下载世界资源失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public void Save_Click(object sender, EventArgs e)
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		ModComp.CompFile compFile = (ModComp.CompFile)NewLateBinding.LateGet((sender is MyListItem) ? sender : NewLateBinding.LateGet(sender, (System.Type)null, "Parent", new object[0], (string[])null, (System.Type[])null, (bool[])null), (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null);
		ModBase.RunInNewThread((Action)([SpecialName] () =>
		{
			//IL_0664: Unknown result type (might be due to invalid IL or missing references)
			//IL_066f: Expected O, but got Unknown
			try
			{
				string text = null;
				switch (compFile.Type)
				{
				case ModComp.CompType.ModPack:
					text = "整合包";
					break;
				case ModComp.CompType.Mod:
					text = "Mod ";
					break;
				case ModComp.CompType.ResourcePack:
					text = "资源包";
					break;
				case ModComp.CompType.Shader:
					text = "光影包";
					break;
				case ModComp.CompType.DataPack:
					text = "数据包";
					break;
				case ModComp.CompType.World:
					text = "世界";
					break;
				}
				string text2 = null;
				if (compFile.Type != ModComp.CompType.ModPack)
				{
					string text3 = null;
					switch (Project.Type)
					{
					case ModComp.CompType.Mod:
						text3 = "mods\\";
						break;
					case ModComp.CompType.ResourcePack:
						text3 = "resourcepacks\\";
						break;
					case ModComp.CompType.Shader:
						text3 = "shaderpacks\\";
						break;
					case ModComp.CompType.World:
						text3 = "saves\\";
						break;
					case ModComp.CompType.DataPack:
						text3 = "";
						break;
					}
					Func<ModMinecraft.McInstance, bool> val = null;
					List<ModComp.CompLoaderType> val2 = new List<ModComp.CompLoaderType>();
					if (Enumerable.Any<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)compFile.ModLoaders))
					{
						val2 = compFile.ModLoaders;
					}
					else if (Enumerable.Any<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)Project.ModLoaders))
					{
						val2 = Project.ModLoaders;
					}
					ModBase.Log($"[Comp] {text}要求的加载器种类：" + (Enumerable.Any<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)val2) ? ModBase.Join((System.Collections.IEnumerable)val2, " / ") : "无要求"));
					val = [SpecialName] (ModMinecraft.McInstance Version) =>
					{
						if ((object)Version == null)
						{
							return false;
						}
						if (!Version.IsLoaded)
						{
							Version.Load();
						}
						if ((Project.Type == ModComp.CompType.Mod || Project.Type == ModComp.CompType.DataPack) && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)compFile.GameVersions, (Func<string, bool>)([SpecialName] (string v) => v.Contains("."))) && !Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)compFile.GameVersions, (Func<string, bool>)([SpecialName] (string v) => v.Contains(".") && Operators.CompareString(v, Version.Version.McName, false) == 0)))
						{
							return false;
						}
						if (!Enumerable.Any<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)val2))
						{
							return true;
						}
						if (val2.Contains(ModComp.CompLoaderType.Forge) && Version.Version.HasForge)
						{
							return true;
						}
						if ((val2.Contains(ModComp.CompLoaderType.Fabric) && Version.Version.HasFabric) || Version.Version.HasLegacyFabric)
						{
							return true;
						}
						if (val2.Contains(ModComp.CompLoaderType.NeoForge) && Version.Version.HasNeoForge)
						{
							return true;
						}
						return (val2.Contains(ModComp.CompLoaderType.LiteLoader) && Version.Version.HasLiteLoader) ? true : false;
					};
					if (CachedFolder.ContainsKey(Project.Type) && !string.IsNullOrEmpty(CachedFolder[Project.Type]))
					{
						text2 = ModBase.GetOrDefault(CachedFolder, Project.Type, ModMinecraft.McInstanceCurrent?.PathIndie ?? ModBase.ExePath);
						ModBase.Log($"[Comp] 使用上次下载时的文件夹作为默认下载位置：{text2}");
					}
					else if ((object)ModMinecraft.McInstanceCurrent != null && val.Invoke(ModMinecraft.McInstanceCurrent))
					{
						text2 = $"{ModMinecraft.McInstanceCurrent.PathIndie}{text3}";
						Directory.CreateDirectory(text2);
						ModBase.Log($"[Comp] 使用当前实例作为默认下载位置：{text2}");
					}
					else
					{
						bool flag = ModMinecraft.McInstanceListLoader.State != ModBase.LoadState.Finished;
						if (flag)
						{
							ModMain.Hint("正在查找适合的游戏实例……");
							ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\", WaitForExit: true);
						}
						System.Collections.Generic.IEnumerable<DirectoryInfo> enumerable = Enumerable.Select<ModMinecraft.McInstance, DirectoryInfo>(Enumerable.Where<ModMinecraft.McInstance>(Enumerable.SelectMany<List<ModMinecraft.McInstance>, ModMinecraft.McInstance>((System.Collections.Generic.IEnumerable<List<ModMinecraft.McInstance>>)ModMinecraft.McInstanceList.Values, (Func<List<ModMinecraft.McInstance>, System.Collections.Generic.IEnumerable<ModMinecraft.McInstance>>)([SpecialName] (List<ModMinecraft.McInstance> l) => (System.Collections.Generic.IEnumerable<ModMinecraft.McInstance>)l)), (Func<ModMinecraft.McInstance, bool>)([SpecialName] (ModMinecraft.McInstance v) => val.Invoke(v))), (Func<ModMinecraft.McInstance, DirectoryInfo>)([SpecialName] (ModMinecraft.McInstance v) => new DirectoryInfo($"{v.PathIndie}{text3}")));
						if (Enumerable.Any<DirectoryInfo>(enumerable))
						{
							DirectoryInfo val3 = Enumerable.First<DirectoryInfo>((System.Collections.Generic.IEnumerable<DirectoryInfo>)Enumerable.ThenByDescending<DirectoryInfo, int>(Enumerable.OrderByDescending<DirectoryInfo, System.DateTime>(enumerable, (Func<DirectoryInfo, System.DateTime>)([SpecialName] (DirectoryInfo Dir) => (!Dir.Exists) ? System.DateTime.MinValue : ((FileSystemInfo)Dir).LastWriteTimeUtc)), (Func<DirectoryInfo, int>)([SpecialName] (DirectoryInfo Dir) => (!Dir.Exists) ? (-1) : Dir.GetFiles().Length)));
							text2 = ((FileSystemInfo)val3).FullName;
							Directory.CreateDirectory(text2);
							ModBase.Log($"[Comp] 使用适合的游戏实例作为默认下载位置：{text2}");
						}
						else
						{
							text2 = ModMinecraft.PathMcFolder;
							if (flag)
							{
								ModMain.Hint("当前 MC 文件夹中没有找到适合此资源文件的实例！");
							}
							else
							{
								ModBase.Log("[Comp] 由于当前实例不兼容，使用当前的 MC 文件夹作为默认下载位置");
							}
						}
					}
				}
				string fileName;
				if (Operators.CompareString(Project.TranslatedName, Project.RawName, false) == 0)
				{
					fileName = compFile.FileName;
				}
				else
				{
					string text4 = ModBase.BeforeFirst(ModBase.BeforeFirst(Project.TranslatedName, " ("), " - ").Replace("\\", "＼").Replace("/", "／")
						.Replace("|", "｜")
						.Replace(":", "：")
						.Replace("<", "＜")
						.Replace(">", "＞")
						.Replace("*", "＊")
						.Replace("?", "？")
						.Replace("\"", "")
						.Replace("： ", "：");
					object obj = ModBase.Setup.Get("ToolDownloadTranslateV2");
					if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
					{
						fileName = $"【{text4}】{compFile.FileName}";
					}
					else if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
					{
						fileName = $"[{text4}] {compFile.FileName}";
					}
					else if (Operators.ConditionalCompareObjectEqual(obj, (object)2, false))
					{
						fileName = $"{text4}-{compFile.FileName}";
					}
					else if (Operators.ConditionalCompareObjectEqual(obj, (object)3, false))
					{
						fileName = $"{compFile.FileName}-{text4}";
					}
					else
					{
						fileName = compFile.FileName;
					}
				}
				ModBase.RunInUi((Action)([SpecialName] () =>
				{
					string text5 = SystemDialogs.SelectSaveFile("选择保存位置", fileName, text + "文件|" + ((compFile.Type != 0) ? (compFile.FileName.EndsWith(".mrpack") ? "*.mrpack" : "*.zip") : (compFile.FileName.EndsWith(".litemod") ? "*.litemod" : "*.jar")), text2);
					if (text5.Contains("\\"))
					{
						string name = text + "下载：" + ModBase.GetFileNameWithoutExtentionFromPath(text5) + " ";
						if (Operators.CompareString(text5, text2, false) != 0)
						{
							if (CachedFolder.ContainsKey(Project.Type))
							{
								CachedFolder[Project.Type] = ModBase.GetPathFromFullPath(text5);
							}
							else
							{
								CachedFolder.Add(Project.Type, ModBase.GetPathFromFullPath(text5));
							}
						}
						List<ModLoader.LoaderBase> val4 = new List<ModLoader.LoaderBase>();
						List<ModNet.NetFile> obj2 = new List<ModNet.NetFile>();
						obj2.Add(compFile.ToNetFile(text5));
						val4.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载文件", obj2)
						{
							ProgressWeight = 6.0,
							Block = true
						});
						ModLoader.LoaderCombo<int> loaderCombo = new ModLoader.LoaderCombo<int>(name, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val4);
						loaderCombo.OnStateChanged = ModDownloadLib.LoaderStateChangedHintOnly;
						loaderCombo.Start(1);
						ModLoader.LoaderTaskbarAdd(loaderCombo);
						ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
						ModMain.FrmMain.BtnExtraDownload.Ribble();
					}
				}));
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "保存资源文件失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}), "Download CompDetail Save", (ThreadPriority)2);
	}

	private void BtnIntroWeb_Click(object sender, EventArgs e)
	{
		ModBase.OpenWebsite(Project.Website);
	}

	private void BtnIntroWiki_Click(object sender, EventArgs e)
	{
		ModBase.OpenWebsite("https://www.mcmod.cn/class/" + Conversions.ToString(Project.WikiId) + ".html");
	}

	private void BtnIntroCopy_Click(object sender, EventArgs e)
	{
		ModBase.ClipboardSet(CompItem.LabTitle.Text + CompItem.LabTitleRaw.Text);
	}

	private void BtnFavorites_Click(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		ModComp.CompFavorites.ShowMenu(Project, (UIElement)sender);
	}

	private void BtnIntroLinkCopy_Click(object sender, EventArgs e)
	{
		ModComp.CompClipboard.CurrentText = Project.Website;
		ModBase.ClipboardSet(Project.Website);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_29_BtnTranslate_Click))]
	private void BtnTranslate_Click(object sender, EventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_29_BtnTranslate_Click vB_0024StateMachine_29_BtnTranslate_Click = default(VB_0024StateMachine_29_BtnTranslate_Click);
		vB_0024StateMachine_29_BtnTranslate_Click._0024VB_0024Me = this;
		vB_0024StateMachine_29_BtnTranslate_Click._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_29_BtnTranslate_Click._0024VB_0024Local_e = e;
		vB_0024StateMachine_29_BtnTranslate_Click._0024State = -1;
		vB_0024StateMachine_29_BtnTranslate_Click._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_29_BtnTranslate_Click._0024Builder.Start<VB_0024StateMachine_29_BtnTranslate_Click>(ref vB_0024StateMachine_29_BtnTranslate_Click);
	}

	public void RefreshFavoriteButton()
	{
		try
		{
			if ((object)Project != null && CompItem != null)
			{
				CompItem.RefreshFavoriteStatus();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "刷新收藏按钮状态时出错");
			ProjectData.ClearProjectError();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagedownload/comp/pagedownloadcompdetail.xaml", (UriKind)2);
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			CardIntro = (MyCard)target;
			break;
		case 3:
			PanIntro = (StackPanel)target;
			break;
		case 4:
			BtnIntroWeb = (MyIconTextButton)target;
			break;
		case 5:
			BtnIntroWiki = (MyIconTextButton)target;
			break;
		case 6:
			BtnIntroCopy = (MyIconTextButton)target;
			break;
		case 7:
			BtnIntroLinkCopy = (MyIconTextButton)target;
			break;
		case 8:
			BtnTranslate = (MyIconTextButton)target;
			break;
		case 9:
			BtnFavorites = (MyIconTextButton)target;
			break;
		case 10:
			PanMain = (StackPanel)target;
			break;
		case 11:
			CardFilter = (MyCard)target;
			break;
		case 12:
			PanFilter = (StackPanel)target;
			break;
		case 13:
			PanResults = (StackPanel)target;
			break;
		case 14:
			PanLoad = (MyCard)target;
			break;
		case 15:
			Load = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__15_002D6(MyRadioButton sender, bool raiseByMouse)
	{
		VersionFilter = ((Operators.CompareString(sender.Text, "全部", false) == 0) ? null : sender.Text);
		UpdateFilterResult();
	}
}
