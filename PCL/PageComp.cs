using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[ContentProperty("SearchTags")]
[DesignerGenerated]
public class PageComp : MyScrollViewer, IComponentConnector
{
	public static readonly DependencyProperty SupportCurseForgeProperty = DependencyProperty.Register("SupportCurseForge", typeof(bool), typeof(PageComp), new PropertyMetadata((object)true));

	public static readonly DependencyProperty SupportModrinthProperty = DependencyProperty.Register("SupportModrinth", typeof(bool), typeof(PageComp), new PropertyMetadata((object)true));

	private string _TypeName;

	private string _TypeNameSpaced;

	private ModComp.CompType _Type;

	public static ModMinecraft.McInstance TargetVersion = null;

	public ModLoader.LoaderTask<ModComp.CompProjectRequest, int> Loader;

	private bool IsLoaderInited;

	public ModComp.CompProjectStorage Storage;

	public const int PageSize = 40;

	public int Page;

	[CompilerGenerated]
	[AccessedThroughProperty("PanSearchBox")]
	private MySearchBox _PanSearchBox;

	[CompilerGenerated]
	[AccessedThroughProperty("TextSearchVersion")]
	private MyComboBox _TextSearchVersion;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSearchReset")]
	private MyIconButton _BtnSearchReset;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSearchInstallModPack")]
	private MyIconButton _BtnSearchInstallModPack;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnPageFirst")]
	private MyIconButton _BtnPageFirst;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnPageLeft")]
	private MyIconButton _BtnPageLeft;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnPageRight")]
	private MyIconButton _BtnPageRight;

	[CompilerGenerated]
	[AccessedThroughProperty("Load")]
	private MyLoading _Load;

	private bool _contentLoaded;

	public ItemCollection SearchTags => ((ItemsControl)ComboSearchTag).Items;

	public bool SupportCurseForge
	{
		get
		{
			return Conversions.ToBoolean(base.GetValue(SupportCurseForgeProperty));
		}
		set
		{
			base.SetValue(SupportCurseForgeProperty, (object)value);
		}
	}

	public bool SupportModrinth
	{
		get
		{
			return Conversions.ToBoolean(base.GetValue(SupportModrinthProperty));
		}
		set
		{
			base.SetValue(SupportModrinthProperty, (object)value);
		}
	}

	public string TypeName
	{
		get
		{
			return _TypeName;
		}
		set
		{
			if (Operators.CompareString(_TypeName, value, false) != 0)
			{
				_TypeName = value;
				Loader.Name = $"社区资源获取：{value}";
			}
		}
	}

	public string TypeNameSpaced
	{
		get
		{
			return _TypeNameSpaced;
		}
		set
		{
			if (Operators.CompareString(_TypeNameSpaced, value, false) != 0)
			{
				_TypeNameSpaced = value;
				PanSearchBox.HintText = $"搜索{value}";
				Load.Text = $"正在获取{value}列表";
			}
		}
	}

	public ModComp.CompType PageType
	{
		get
		{
			return _Type;
		}
		set
		{
			if (_Type != value)
			{
				_Type = value;
				((UIElement)BtnSearchInstallModPack).Visibility = (Visibility)((value != ModComp.CompType.ModPack) ? 2 : 0);
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanAlways")]
	internal virtual StackPanel PanAlways
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MySearchBox PanSearchBox
	{
		[CompilerGenerated]
		get
		{
			return _PanSearchBox;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MySearchBox.SearchEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				StartNewSearch();
			};
			KeyEventHandler val = new KeyEventHandler(EnterTrigger);
			MySearchBox panSearchBox = _PanSearchBox;
			if (panSearchBox != null)
			{
				panSearchBox.Search -= obj;
				((UIElement)panSearchBox).KeyDown -= val;
			}
			_PanSearchBox = value;
			panSearchBox = _PanSearchBox;
			if (panSearchBox != null)
			{
				panSearchBox.Search += obj;
				((UIElement)panSearchBox).KeyDown += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabSource")]
	internal virtual TextBlock LabSource
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ComboSearchSource")]
	internal virtual MyComboBox ComboSearchSource
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabTag")]
	internal virtual TextBlock LabTag
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ComboSearchTag")]
	internal virtual MyComboBox ComboSearchTag
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabSort")]
	internal virtual TextBlock LabSort
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ComboSearchSort")]
	internal virtual MyComboBox ComboSearchSort
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyComboBox TextSearchVersion
	{
		[CompilerGenerated]
		get
		{
			return _TextSearchVersion;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(EnterTrigger);
			MyComboBox textSearchVersion = _TextSearchVersion;
			if (textSearchVersion != null)
			{
				((UIElement)textSearchVersion).KeyDown -= val;
			}
			_TextSearchVersion = value;
			textSearchVersion = _TextSearchVersion;
			if (textSearchVersion != null)
			{
				((UIElement)textSearchVersion).KeyDown += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLoader")]
	internal virtual TextBlock LabLoader
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ComboSearchLoader")]
	internal virtual MyComboBox ComboSearchLoader
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ComboSearchShaderLoader")]
	internal virtual MyComboBox ComboSearchShaderLoader
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconButton BtnSearchReset
	{
		[CompilerGenerated]
		get
		{
			return _BtnSearchReset;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				ResetFilter();
			};
			MyIconButton btnSearchReset = _BtnSearchReset;
			if (btnSearchReset != null)
			{
				btnSearchReset.Click -= obj;
			}
			_BtnSearchReset = value;
			btnSearchReset = _BtnSearchReset;
			if (btnSearchReset != null)
			{
				btnSearchReset.Click += obj;
			}
		}
	}

	internal virtual MyIconButton BtnSearchInstallModPack
	{
		[CompilerGenerated]
		get
		{
			return _BtnSearchInstallModPack;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = BtnSearchInstallModPack_Click;
			MyIconButton btnSearchInstallModPack = _BtnSearchInstallModPack;
			if (btnSearchInstallModPack != null)
			{
				btnSearchInstallModPack.Click -= obj;
			}
			_BtnSearchInstallModPack = value;
			btnSearchInstallModPack = _BtnSearchInstallModPack;
			if (btnSearchInstallModPack != null)
			{
				btnSearchInstallModPack.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanContent")]
	internal virtual StackPanel PanContent
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintError")]
	internal virtual MyHint HintError
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardProjects")]
	internal virtual MyCard CardProjects
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanProjects")]
	internal virtual StackPanel PanProjects
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardPages")]
	internal virtual MyCard CardPages
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconButton BtnPageFirst
	{
		[CompilerGenerated]
		get
		{
			return _BtnPageFirst;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Expected O, but got Unknown
				BtnPageFirst_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
			};
			MyIconButton btnPageFirst = _BtnPageFirst;
			if (btnPageFirst != null)
			{
				btnPageFirst.Click -= obj;
			}
			_BtnPageFirst = value;
			btnPageFirst = _BtnPageFirst;
			if (btnPageFirst != null)
			{
				btnPageFirst.Click += obj;
			}
		}
	}

	internal virtual MyIconButton BtnPageLeft
	{
		[CompilerGenerated]
		get
		{
			return _BtnPageLeft;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Expected O, but got Unknown
				BtnPageLeft_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
			};
			MyIconButton btnPageLeft = _BtnPageLeft;
			if (btnPageLeft != null)
			{
				btnPageLeft.Click -= obj;
			}
			_BtnPageLeft = value;
			btnPageLeft = _BtnPageLeft;
			if (btnPageLeft != null)
			{
				btnPageLeft.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabPage")]
	internal virtual TextBlock LabPage
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconButton BtnPageRight
	{
		[CompilerGenerated]
		get
		{
			return _BtnPageRight;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Expected O, but got Unknown
				BtnPageRight_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
			};
			MyIconButton btnPageRight = _BtnPageRight;
			if (btnPageRight != null)
			{
				btnPageRight.Click -= obj;
			}
			_BtnPageRight = value;
			btnPageRight = _BtnPageRight;
			if (btnPageRight != null)
			{
				btnPageRight.Click += obj;
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

	public PageComp()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageCompControls_Inited);
		((UIElement)this).IsVisibleChanged += new DependencyPropertyChangedEventHandler(PageComp_IsVisibleChanged);
		_TypeName = "";
		_TypeNameSpaced = "";
		_Type = ModComp.CompType.Any;
		Loader = new ModLoader.LoaderTask<ModComp.CompProjectRequest, int>("社区资源获取：XXX", ModComp.CompProjectsGet, LoaderInput, (ThreadPriority)2)
		{
			ReloadTimeout = 60000
		};
		IsLoaderInited = false;
		Storage = new ModComp.CompProjectStorage();
		Page = 0;
		InitializeComponent();
	}

	private void PageCompControls_Inited(object sender, EventArgs e)
	{
		if ((object)TargetVersion != null)
		{
			ResetFilter();
			TextSearchVersion.Text = TargetVersion.Version.McName;
			VB_0024AnonymousDelegate_14<string, MyComboBoxItem> vB_0024AnonymousDelegate_ = [SpecialName] [CompilerGenerated] (string Name) =>
			{
				foreach (MyComboBoxItem item in (System.Collections.IEnumerable)((ItemsControl)ComboSearchLoader).Items)
				{
					if (Operators.ConditionalCompareObjectEqual(((ContentControl)item).Content, (object)Name, false))
					{
						return item;
					}
				}
				return (MyComboBoxItem)((ItemsControl)ComboSearchLoader).Items[0];
			};
			if (TargetVersion.Version.HasForge)
			{
				((Selector)ComboSearchLoader).SelectedItem = vB_0024AnonymousDelegate_("Forge");
			}
			else if (TargetVersion.Version.HasFabric)
			{
				((Selector)ComboSearchLoader).SelectedItem = vB_0024AnonymousDelegate_("Fabric");
			}
			else if (TargetVersion.Version.HasNeoForge)
			{
				((Selector)ComboSearchLoader).SelectedItem = vB_0024AnonymousDelegate_("NeoForge");
			}
			else if (TargetVersion.Version.HasQuilt)
			{
				((Selector)ComboSearchLoader).SelectedItem = vB_0024AnonymousDelegate_("Quilt");
			}
			TargetVersion = null;
			if (IsLoaderInited)
			{
				StartNewSearch();
			}
			base.ScrollToHome();
		}
		if (!IsLoaderInited)
		{
			IsLoaderInited = true;
			((MyPageRight)(object)((FrameworkElement)this).Parent).PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanContent, (FrameworkElement)(object)PanAlways, Loader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
			{
				Load_OnFinish();
			}, LoaderInput);
			if (ModDownloadLib.McVersionHighest == -1)
			{
				ModDownloadLib.McVersionHighest = Math.Max(ModDownloadLib.McVersionHighest, PCLVerCompat.VerToInt(((ContentControl)(MyComboBoxItem)((ItemsControl)TextSearchVersion).Items[1]).Content.ToString()));
			}
			if (PageType == ModComp.CompType.Shader)
			{
				((UIElement)LabLoader).Visibility = (Visibility)0;
				((UIElement)ComboSearchLoader).Visibility = (Visibility)2;
				((UIElement)ComboSearchShaderLoader).Visibility = (Visibility)0;
			}
			else if (PageType == ModComp.CompType.Mod || PageType == ModComp.CompType.ModPack)
			{
				((UIElement)LabLoader).Visibility = (Visibility)0;
				((UIElement)ComboSearchLoader).Visibility = (Visibility)0;
				((UIElement)ComboSearchShaderLoader).Visibility = (Visibility)2;
			}
			else
			{
				((UIElement)LabLoader).Visibility = (Visibility)2;
				((UIElement)ComboSearchLoader).Visibility = (Visibility)2;
				((UIElement)ComboSearchShaderLoader).Visibility = (Visibility)2;
				QuickDownloadHack.SetupCheckBoxes(this);
			}
		}
	}

	private void PageComp_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		QuickDownloadHack.SetupCheckBoxes(this);
		if (((UIElement)this).IsVisible)
		{
			RefreshAllFavoriteStatus();
		}
	}

	private ModComp.CompProjectRequest LoaderInput()
	{
		ModComp.CompProjectRequest compProjectRequest = new ModComp.CompProjectRequest(PageType, Storage, checked((Page + 1) * 40));
		string text = ((Operators.CompareString(TextSearchVersion.Text, "全部 (也可自行输入)", false) == 0) ? null : ((TextSearchVersion.Text.Contains(".") || TextSearchVersion.Text.Contains("w")) ? TextSearchVersion.Text : null));
		ModComp.CompLoaderType compLoaderType = ModComp.CompLoaderType.Any;
		if (PageType == ModComp.CompType.Mod || PageType == ModComp.CompType.ModPack)
		{
			compLoaderType = (ModComp.CompLoaderType)checked((int)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(((Selector)ComboSearchLoader).SelectedItem, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)))));
			if (text != null && text.Contains(".") && PCLVerCompat.VerToDouble(text) < 14.0 && compLoaderType == ModComp.CompLoaderType.Forge)
			{
				compLoaderType = ModComp.CompLoaderType.Any;
			}
		}
		ModComp.CompProjectRequest compProjectRequest2 = compProjectRequest;
		compProjectRequest2.SearchText = PanSearchBox.Text;
		compProjectRequest2.GameVersion = text;
		ModComp.CompProjectRequest compProjectRequest3 = compProjectRequest2;
		object tag;
		if (PageType != ModComp.CompType.Shader)
		{
			object selectedItem = ((Selector)ComboSearchTag).SelectedItem;
			tag = ((selectedItem == null) ? null : NewLateBinding.LateGet(selectedItem, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)?.ToString());
		}
		else
		{
			object selectedItem2 = ((Selector)ComboSearchShaderLoader).SelectedItem;
			if (!string.IsNullOrEmpty((selectedItem2 == null) ? null : NewLateBinding.LateGet(selectedItem2, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)?.ToString()))
			{
				object selectedItem3 = ((Selector)ComboSearchTag).SelectedItem;
				string obj = ((selectedItem3 == null) ? null : NewLateBinding.LateGet(selectedItem3, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)?.ToString());
				object selectedItem4 = ((Selector)ComboSearchShaderLoader).SelectedItem;
				tag = obj + ((selectedItem4 == null) ? null : NewLateBinding.LateGet(selectedItem4, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)?.ToString());
			}
			else
			{
				object selectedItem5 = ((Selector)ComboSearchTag).SelectedItem;
				tag = ((selectedItem5 == null) ? null : NewLateBinding.LateGet(selectedItem5, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)?.ToString());
			}
		}
		compProjectRequest3.Tag = (string)tag;
		compProjectRequest2.ModLoader = (ModComp.CompLoaderType)checked((int)Math.Round((PageType == ModComp.CompType.Mod || PageType == ModComp.CompType.ModPack) ? ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(((Selector)ComboSearchLoader).SelectedItem, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null))) : 0.0));
		compProjectRequest2.Source = (ModComp.CompSourceType)checked((int)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(((Selector)ComboSearchSource).SelectedItem, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)))));
		compProjectRequest2.Sort = (ModComp.CompSortType)checked((int)Math.Round(ModBase.Val(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(((Selector)ComboSearchSort).SelectedItem, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)))));
		compProjectRequest2 = null;
		return compProjectRequest;
	}

	private void Load_OnFinish()
	{
		checked
		{
			try
			{
				ModBase.Log($"[Comp] 开始可视化{TypeNameSpaced}列表，已储藏 {Storage.Results.Count} 个结果，当前在第 {Page + 1} 页");
				((Panel)PanProjects).Children.Clear();
				int num = Math.Min(Page * 40, Storage.Results.Count - 1);
				int num2 = Math.Min((Page + 1) * 40 - 1, Storage.Results.Count - 1);
				for (int i = num; i <= num2; i++)
				{
					((Panel)PanProjects).Children.Add((UIElement)(object)Storage.Results[i].ToCompItem(Loader.Input.GameVersion == null, Loader.Input.ModLoader == ModComp.CompLoaderType.Any && (PageType == ModComp.CompType.Mod || PageType == ModComp.CompType.ModPack)));
				}
				((UIElement)CardPages).Visibility = (Visibility)((Storage.Results.Count <= 40 && Storage.CurseForgeOffset >= Storage.CurseForgeTotal && Storage.ModrinthOffset >= Storage.ModrinthTotal) ? 2 : 0);
				LabPage.Text = Conversions.ToString(Page + 1);
				((UIElement)BtnPageFirst).IsEnabled = Page > 1;
				((UIElement)BtnPageFirst).Opacity = ((Page > 1) ? 1.0 : 0.2);
				((UIElement)BtnPageLeft).IsEnabled = Page > 0;
				((UIElement)BtnPageLeft).Opacity = ((Page > 0) ? 1.0 : 0.2);
				bool flag = Storage.Results.Count > 40 * (Page + 1) || Storage.CurseForgeOffset < Storage.CurseForgeTotal || Storage.ModrinthOffset < Storage.ModrinthTotal;
				((UIElement)BtnPageRight).IsEnabled = flag;
				((UIElement)BtnPageRight).Opacity = (flag ? 1.0 : 0.2);
				if (Storage.ErrorMessage == null)
				{
					((UIElement)HintError).Visibility = (Visibility)2;
				}
				else
				{
					((UIElement)HintError).Visibility = (Visibility)0;
					HintError.Text = Storage.ErrorMessage;
				}
				base.ScrollToTop();
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, $"可视化{TypeNameSpaced}列表出错", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void Load_State(object sender, MyLoading.MyLoadingState state, MyLoading.MyLoadingState oldState)
	{
		ModBase.LoadState state2 = Loader.State;
		if (state2 == ModBase.LoadState.Failed)
		{
			string text = "";
			if (Loader.Error != null)
			{
				text = Loader.Error.Message;
			}
			if (text.Contains("不是有效的 json 文件"))
			{
				ModBase.Log($"[Download] 下载的{TypeNameSpaced}列表 json 文件损坏，已自动重试", ModBase.LogLevel.Debug);
				((MyPageRight)(object)((FrameworkElement)this).Parent).PageLoaderRestart();
			}
		}
	}

	private void BtnPageFirst_Click(object sender, RoutedEventArgs e)
	{
		ChangePage(0);
	}

	private void BtnPageLeft_Click(object sender, RoutedEventArgs e)
	{
		ChangePage(checked(Page - 1));
	}

	private void BtnPageRight_Click(object sender, RoutedEventArgs e)
	{
		ChangePage(checked(Page + 1));
	}

	private void ChangePage(int NewPage)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		((UIElement)CardPages).IsEnabled = false;
		Page = NewPage;
		ModMain.FrmMain.BackToTop();
		ModBase.Log($"[Download] {TypeName}：切换到第 {checked(Page + 1)} 页");
		ModBase.RunInThread((Action)([SpecialName] [CompilerGenerated] () =>
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Expected O, but got Unknown
			Thread.Sleep(100);
			ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
			{
				((UIElement)CardPages).IsEnabled = true;
			}));
			Loader.Start();
		}));
	}

	private void StartNewSearch()
	{
		Page = 0;
		ModLoader.LoaderTask<ModComp.CompProjectRequest, int> loader = Loader;
		object Input = LoaderInput();
		if (loader.ShouldStart(ref Input))
		{
			Storage = new ModComp.CompProjectStorage();
		}
		Loader.Start();
	}

	private void EnterTrigger(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6)
		{
			StartNewSearch();
		}
	}

	private void ResetFilter()
	{
		PanSearchBox.Text = "";
		TextSearchVersion.Text = "全部 (也可自行输入)";
		((Selector)TextSearchVersion).SelectedIndex = 0;
		((Selector)ComboSearchSource).SelectedIndex = 0;
		((Selector)ComboSearchTag).SelectedIndex = 0;
		((Selector)ComboSearchLoader).SelectedIndex = 0;
		((Selector)ComboSearchShaderLoader).SelectedIndex = 0;
		((Selector)ComboSearchSort).SelectedIndex = 0;
		Loader.LastFinishedTime = 0L;
	}

	private void BtnSearchInstallModPack_Click(object sender, EventArgs e)
	{
		ModModpack.ModpackInstall();
	}

	public void RefreshAllFavoriteStatus()
	{
		try
		{
			foreach (object child in ((Panel)PanProjects).Children)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(child);
				if (objectValue is MyCompItem)
				{
					((MyCompItem)objectValue).RefreshFavoriteStatus();
				}
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "刷新收藏状态时出错");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagedownload/comp/pagecomp.xaml", (UriKind)2);
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
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanAlways = (StackPanel)target;
			break;
		case 2:
			PanSearchBox = (MySearchBox)target;
			break;
		case 3:
			LabSource = (TextBlock)target;
			break;
		case 4:
			ComboSearchSource = (MyComboBox)target;
			break;
		case 5:
			LabTag = (TextBlock)target;
			break;
		case 6:
			ComboSearchTag = (MyComboBox)target;
			break;
		case 7:
			LabSort = (TextBlock)target;
			break;
		case 8:
			ComboSearchSort = (MyComboBox)target;
			break;
		case 9:
			TextSearchVersion = (MyComboBox)target;
			break;
		case 10:
			LabLoader = (TextBlock)target;
			break;
		case 11:
			ComboSearchLoader = (MyComboBox)target;
			break;
		case 12:
			ComboSearchShaderLoader = (MyComboBox)target;
			break;
		case 13:
			BtnSearchReset = (MyIconButton)target;
			break;
		case 14:
			BtnSearchInstallModPack = (MyIconButton)target;
			break;
		case 15:
			PanContent = (StackPanel)target;
			break;
		case 16:
			HintError = (MyHint)target;
			break;
		case 17:
			CardProjects = (MyCard)target;
			break;
		case 18:
			PanProjects = (StackPanel)target;
			break;
		case 19:
			CardPages = (MyCard)target;
			break;
		case 20:
			BtnPageFirst = (MyIconButton)target;
			break;
		case 21:
			BtnPageLeft = (MyIconButton)target;
			break;
		case 22:
			LabPage = (TextBlock)target;
			break;
		case 23:
			BtnPageRight = (MyIconButton)target;
			break;
		case 24:
			PanLoad = (MyCard)target;
			break;
		case 25:
			Load = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}

	public void PreloadStart()
	{
	}
}
