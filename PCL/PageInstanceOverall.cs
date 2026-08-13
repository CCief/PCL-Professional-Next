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
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualBasic.FileIO;
using FileSystem = Microsoft.VisualBasic.FileIO.FileSystem;
using Newtonsoft.Json.Linq;
using PCL.Core.App;
using PCL.Core.Minecraft;
using PCL.Core.UI;

namespace PCL;

[DesignerGenerated]
public class PageInstanceOverall : MyPageRight, IComponentConnector
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__18_002D0
	{
		public ModLoader.LoaderCombo<string> _0024VB_0024Local_Loader;

		public _Closure_0024__18_002D0(_Closure_0024__18_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R3(ModLoader.LoaderBase a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			switch (_0024VB_0024Local_Loader.State)
			{
			case ModBase.LoadState.Finished:
				ModMain.Hint(_0024VB_0024Local_Loader.Name + "成功！", ModMain.HintType.Finish);
				break;
			case ModBase.LoadState.Failed:
				ModMain.Hint(_0024VB_0024Local_Loader.Name + "失败：" + _0024VB_0024Local_Loader.Error.Message, ModMain.HintType.Critical);
				break;
			case ModBase.LoadState.Aborted:
				ModMain.Hint(_0024VB_0024Local_Loader.Name + "已取消！");
				break;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__7_002D0
	{
		public List<ModComp.CompProject> _0024VB_0024Local_compProjects;

		public PageInstanceOverall _0024VB_0024Me;

		public _Closure_0024__7_002D0(_Closure_0024__7_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_compProjects = arg0._0024VB_0024Local_compProjects;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			_0024VB_0024Me.ModpackCompItem = Enumerable.First<ModComp.CompProject>((System.Collections.Generic.IEnumerable<ModComp.CompProject>)_0024VB_0024Local_compProjects).ToCompItem(ShowMcVersionDesc: false, ShowLoaderDesc: false);
			((FrameworkElement)_0024VB_0024Me.ModpackCompItem).Tag = Enumerable.First<ModComp.CompProject>((System.Collections.Generic.IEnumerable<ModComp.CompProject>)_0024VB_0024Local_compProjects);
		}
	}

	private bool IsLoad;

	public MyListItem ItemVersion;

	private ModLoader.LoaderCombo<int> InstanceInfoLoader;

	private MyCompItem ModpackCompItem;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboDisplayLogo")]
	private MyComboBox _ComboDisplayLogo;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboDisplayType")]
	private MyComboBox _ComboDisplayType;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnDisplayRename")]
	private MyButton _BtnDisplayRename;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnDisplayDesc")]
	private MyButton _BtnDisplayDesc;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnDisplayStar")]
	private MyButton _BtnDisplayStar;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnFolderVersion")]
	private MyButton _BtnFolderVersion;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnFolderSaves")]
	private MyButton _BtnFolderSaves;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnFolderMods")]
	private MyButton _BtnFolderMods;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnManageScript")]
	private MyButton _BtnManageScript;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnManageTest")]
	private MyButton _BtnManageTest;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnManageCheck")]
	private MyButton _BtnManageCheck;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnManageRestore")]
	private MyButton _BtnManageRestore;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnManageDelete")]
	private MyButton _BtnManageDelete;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnManagePatch")]
	private MyButton _BtnManagePatch;

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
	[field: AccessedThroughProperty("PanDisplayItem")]
	internal virtual Grid PanDisplayItem
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanInfo")]
	internal virtual StackPanel PanInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanDisplay")]
	internal virtual MyCard PanDisplay
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanDisplayIcon")]
	internal virtual Grid PanDisplayIcon
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyComboBox ComboDisplayLogo
	{
		[CompilerGenerated]
		get
		{
			return _ComboDisplayLogo;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SelectionChangedEventHandler val = new SelectionChangedEventHandler(ComboDisplayLogo_SelectionChanged);
			MyComboBox comboDisplayLogo = _ComboDisplayLogo;
			if (comboDisplayLogo != null)
			{
				((Selector)comboDisplayLogo).SelectionChanged -= val;
			}
			_ComboDisplayLogo = value;
			comboDisplayLogo = _ComboDisplayLogo;
			if (comboDisplayLogo != null)
			{
				((Selector)comboDisplayLogo).SelectionChanged += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ItemDisplayLogoCustom")]
	internal virtual MyComboBoxItem ItemDisplayLogoCustom
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyComboBox ComboDisplayType
	{
		[CompilerGenerated]
		get
		{
			return _ComboDisplayType;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SelectionChangedEventHandler val = new SelectionChangedEventHandler(ComboDisplayType_SelectionChanged);
			MyComboBox comboDisplayType = _ComboDisplayType;
			if (comboDisplayType != null)
			{
				((Selector)comboDisplayType).SelectionChanged -= val;
			}
			_ComboDisplayType = value;
			comboDisplayType = _ComboDisplayType;
			if (comboDisplayType != null)
			{
				((Selector)comboDisplayType).SelectionChanged += val;
			}
		}
	}

	internal virtual MyButton BtnDisplayRename
	{
		[CompilerGenerated]
		get
		{
			return _BtnDisplayRename;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnDisplayRename_Click;
			MyButton btnDisplayRename = _BtnDisplayRename;
			if (btnDisplayRename != null)
			{
				btnDisplayRename.Click -= obj;
			}
			_BtnDisplayRename = value;
			btnDisplayRename = _BtnDisplayRename;
			if (btnDisplayRename != null)
			{
				btnDisplayRename.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnDisplayDesc
	{
		[CompilerGenerated]
		get
		{
			return _BtnDisplayDesc;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnDisplayDesc_Click;
			MyButton btnDisplayDesc = _BtnDisplayDesc;
			if (btnDisplayDesc != null)
			{
				btnDisplayDesc.Click -= obj;
			}
			_BtnDisplayDesc = value;
			btnDisplayDesc = _BtnDisplayDesc;
			if (btnDisplayDesc != null)
			{
				btnDisplayDesc.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnDisplayStar
	{
		[CompilerGenerated]
		get
		{
			return _BtnDisplayStar;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnDisplayStar_Click;
			MyButton btnDisplayStar = _BtnDisplayStar;
			if (btnDisplayStar != null)
			{
				btnDisplayStar.Click -= obj;
			}
			_BtnDisplayStar = value;
			btnDisplayStar = _BtnDisplayStar;
			if (btnDisplayStar != null)
			{
				btnDisplayStar.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanFolder")]
	internal virtual MyCard PanFolder
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnFolderVersion
	{
		[CompilerGenerated]
		get
		{
			return _BtnFolderVersion;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnFolderVersion_Click();
			};
			MyButton btnFolderVersion = _BtnFolderVersion;
			if (btnFolderVersion != null)
			{
				btnFolderVersion.Click -= obj;
			}
			_BtnFolderVersion = value;
			btnFolderVersion = _BtnFolderVersion;
			if (btnFolderVersion != null)
			{
				btnFolderVersion.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnFolderSaves
	{
		[CompilerGenerated]
		get
		{
			return _BtnFolderSaves;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnFolderSaves_Click();
			};
			MyButton btnFolderSaves = _BtnFolderSaves;
			if (btnFolderSaves != null)
			{
				btnFolderSaves.Click -= obj;
			}
			_BtnFolderSaves = value;
			btnFolderSaves = _BtnFolderSaves;
			if (btnFolderSaves != null)
			{
				btnFolderSaves.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnFolderMods
	{
		[CompilerGenerated]
		get
		{
			return _BtnFolderMods;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnFolderMods_Click();
			};
			MyButton btnFolderMods = _BtnFolderMods;
			if (btnFolderMods != null)
			{
				btnFolderMods.Click -= obj;
			}
			_BtnFolderMods = value;
			btnFolderMods = _BtnFolderMods;
			if (btnFolderMods != null)
			{
				btnFolderMods.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanManage")]
	internal virtual MyCard PanManage
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnManageScript
	{
		[CompilerGenerated]
		get
		{
			return _BtnManageScript;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnManageScript_Click();
			};
			MyButton btnManageScript = _BtnManageScript;
			if (btnManageScript != null)
			{
				btnManageScript.Click -= obj;
			}
			_BtnManageScript = value;
			btnManageScript = _BtnManageScript;
			if (btnManageScript != null)
			{
				btnManageScript.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnManageTest
	{
		[CompilerGenerated]
		get
		{
			return _BtnManageTest;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageTest_Click;
			MyButton btnManageTest = _BtnManageTest;
			if (btnManageTest != null)
			{
				btnManageTest.Click -= obj;
			}
			_BtnManageTest = value;
			btnManageTest = _BtnManageTest;
			if (btnManageTest != null)
			{
				btnManageTest.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnManageCheck
	{
		[CompilerGenerated]
		get
		{
			return _BtnManageCheck;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageCheck_Click;
			MyButton btnManageCheck = _BtnManageCheck;
			if (btnManageCheck != null)
			{
				btnManageCheck.Click -= obj;
			}
			_BtnManageCheck = value;
			btnManageCheck = _BtnManageCheck;
			if (btnManageCheck != null)
			{
				btnManageCheck.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnManageRestore
	{
		[CompilerGenerated]
		get
		{
			return _BtnManageRestore;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageRestore_Click;
			MyButton btnManageRestore = _BtnManageRestore;
			if (btnManageRestore != null)
			{
				btnManageRestore.Click -= obj;
			}
			_BtnManageRestore = value;
			btnManageRestore = _BtnManageRestore;
			if (btnManageRestore != null)
			{
				btnManageRestore.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnManageDelete
	{
		[CompilerGenerated]
		get
		{
			return _BtnManageDelete;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageDelete_Click;
			MyButton btnManageDelete = _BtnManageDelete;
			if (btnManageDelete != null)
			{
				btnManageDelete.Click -= obj;
			}
			_BtnManageDelete = value;
			btnManageDelete = _BtnManageDelete;
			if (btnManageDelete != null)
			{
				btnManageDelete.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnManagePatch
	{
		[CompilerGenerated]
		get
		{
			return _BtnManagePatch;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManagePatch_Click;
			MyButton btnManagePatch = _BtnManagePatch;
			if (btnManagePatch != null)
			{
				btnManagePatch.Click -= obj;
			}
			_BtnManagePatch = value;
			btnManagePatch = _BtnManagePatch;
			if (btnManagePatch != null)
			{
				btnManagePatch.Click += obj;
			}
		}
	}

	public PageInstanceOverall()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageSetupLaunch_Loaded);
		IsLoad = false;
		InitializeComponent();
	}

	private void PageSetupLaunch_Loaded(object sender, RoutedEventArgs e)
	{
		((ScrollViewer)PanBack).ScrollToHome();
		((FrameworkElement)ItemDisplayLogoCustom).Tag = "PCL\\Logo.png";
		Reload();
		if (!IsLoad)
		{
			IsLoad = true;
			PanDisplay.TriggerForceResize();
		}
	}

	private void Reload()
	{
		checked
		{
			ModAnimation.AniControlEnabled++;
			ModMinecraft.McInstance instance = PageInstanceLeft.Instance;
			((Selector)ComboDisplayType).SelectedIndex = Config.Instance.CardType[instance.Path];
			BtnDisplayStar.Text = (instance.IsStar ? "从收藏夹中移除" : "加入收藏夹");
			((UIElement)BtnFolderMods).Visibility = (Visibility)((!instance.Modable) ? 2 : 0);
			((Panel)PanDisplayItem).Children.Clear();
			ItemVersion = PageSelectRight.McVersionListItem(instance);
			((UIElement)ItemVersion).IsHitTestVisible = false;
			((Panel)PanDisplayItem).Children.Add((UIElement)(object)ItemVersion);
			ModMain.FrmMain.PageNameRefresh();
			GetInstanceInfo();
			((Selector)ComboDisplayLogo).SelectedIndex = 0;
			string text = Config.Instance.LogoPath[instance.Path];
			if (Config.Instance.IsLogoCustom[instance.Path])
			{
				foreach (MyComboBoxItem item in (System.Collections.IEnumerable)((ItemsControl)ComboDisplayLogo).Items)
				{
					if (Operators.ConditionalCompareObjectEqual(((FrameworkElement)item).Tag, (object)text, false) || (Operators.ConditionalCompareObjectEqual(((FrameworkElement)item).Tag, (object)"PCL\\Logo.png", false) && text.EndsWith("PCL\\Logo.png")))
					{
						((Selector)ComboDisplayLogo).SelectedItem = item;
						break;
					}
				}
			}
			ModAnimation.AniControlEnabled--;
		}
	}

	private void GetInstanceInfo()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		ModpackCompItem = null;
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			((Panel)PanInfo).Children.Clear();
			UIElementCollection children = ((Panel)PanInfo).Children;
			MyLoading obj = new MyLoading
			{
				Text = "正在获取信息"
			};
			((FrameworkElement)obj).Margin = new Thickness(0.0, 0.0, 0.0, 10.0);
			children.Add((UIElement)(object)obj);
		}));
		List<ModLoader.LoaderBase> val = new List<ModLoader.LoaderBase>();
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("获取可能的整合包信息", [SpecialName] [CompilerGenerated] (ModLoader.LoaderTask<int, int> a0) =>
		{
			_Lambda_0024__7_002D1();
		}, null, (ThreadPriority)2)
		{
			Block = true
		});
		val.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("获取实例信息", [SpecialName] [CompilerGenerated] (ModLoader.LoaderTask<int, int> a0) =>
		{
			_Lambda_0024__7_002D3();
		}, null, (ThreadPriority)2));
		InstanceInfoLoader = new ModLoader.LoaderCombo<int>("Instance Info Loader", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val)
		{
			Show = false
		};
		InstanceInfoLoader.Start();
	}

	private void ComboDisplayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (!IsLoad || ModAnimation.AniControlEnabled != 0)
		{
			return;
		}
		if (((Selector)ComboDisplayType).SelectedIndex != 1)
		{
			try
			{
				Config.Instance.CardType[PageInstanceLeft.Instance.Path] = ((Selector)ComboDisplayType).SelectedIndex;
				PageInstanceLeft.Instance.DisplayType = (ModMinecraft.McInstanceCardType)Config.Instance.CardType[PageInstanceLeft.Instance.Path];
				ModMain.FrmInstanceLeft.RefreshModDisabled();
				ModBase.WriteIni(ModMinecraft.PathMcFolder + "PCL.ini", "InstanceCache", "");
				ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "修改实例分类失败（" + PageInstanceLeft.Instance.Name + "）", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
			Reload();
			return;
		}
		try
		{
			if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("HintHide"))))
			{
				if (ModMain.MyMsgBox("确认要从实例列表中隐藏该实例吗？隐藏该实例后，它将不再出现于 PCL 显示的实例列表中。\r\n此后，在实例列表页面按下 F11 才可以查看被隐藏的实例。", "隐藏实例提示", "确定", "取消") != 1)
				{
					((Selector)ComboDisplayType).SelectedIndex = 0;
					return;
				}
				ModBase.Setup.Set("HintHide", true);
			}
			Config.Instance.CardType[PageInstanceLeft.Instance.Path] = 1;
			ModBase.WriteIni(ModMinecraft.PathMcFolder + "PCL.ini", "InstanceCache", "");
			ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			ModBase.Log(ex4, "隐藏实例 " + PageInstanceLeft.Instance.Name + " 失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnDisplayDesc_Click(object sender, EventArgs e)
	{
		try
		{
			string text = Config.Instance.CustomInfo[PageInstanceLeft.Instance.Path];
			string text2 = ModMain.MyMsgBoxInput("更改描述", "修改实例的描述文本，留空则使用 PCL 的默认描述。", text, new Collection<Validate>(), "默认描述");
			if (text2 != null && Operators.CompareString(text, text2, false) != 0)
			{
				Config.Instance.CustomInfo[PageInstanceLeft.Instance.Path] = text2;
			}
			PageInstanceLeft.Instance = new ModMinecraft.McInstance(PageInstanceLeft.Instance.Name).Load();
			Reload();
			ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "实例 " + PageInstanceLeft.Instance.Name + " 描述更改失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnDisplayRename_Click(object sender, EventArgs e)
	{
		try
		{
			string name = PageInstanceLeft.Instance.Name;
			string path = PageInstanceLeft.Instance.Path;
			Collection<Validate> obj = new Collection<Validate>();
			obj.Add((Validate)new ValidateFolderName(ModMinecraft.PathMcFolder + "versions", UseMinecraftCharCheck: true, IgnoreCase: false));
			string text = ModMain.MyMsgBoxInput("重命名实例", "", name, obj);
			if (string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			string text2 = ModMinecraft.PathMcFolder + "versions\\" + text + "\\";
			string text3 = text + "_temp";
			string text4 = ModMinecraft.PathMcFolder + "versions\\" + text3 + "\\";
			bool flag = Operators.CompareString(text.ToLower(), name.ToLower(), false) == 0;
			JObject jObject;
			try
			{
				jObject = (JObject)ModBase.GetJson(ModBase.ReadFile(PageInstanceLeft.Instance.Path + PageInstanceLeft.Instance.Name + ".json"));
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "重命名读取 Json 时失败");
				jObject = PageInstanceLeft.Instance.JsonObject;
				ProjectData.ClearProjectError();
			}
			FileSystem.RenameDirectory(path, text3);
			FileSystem.RenameDirectory(text4, text);
			ModBase.IniClearCache(PageInstanceLeft.Instance.PathIndie + "options.txt");
			if (Directory.Exists($"{text2}{name}-natives"))
			{
				if (flag)
				{
					FileSystem.RenameDirectory($"{text2}{name}-natives", $"{name}natives_temp");
					FileSystem.RenameDirectory($"{text2}{name}-natives_temp", $"{text}-natives");
				}
				else
				{
					ModBase.DeleteDirectory($"{text2}{text}-natives");
					FileSystem.RenameDirectory($"{text2}{name}-natives", $"{text}-natives");
				}
			}
			if (File.Exists($"{text2}{name}.jar"))
			{
				if (flag)
				{
					FileSystem.RenameFile($"{text2}{name}.jar", $"{name}_temp.jar");
					FileSystem.RenameFile($"{text2}{name}_temp.jar", $"{text}.jar");
				}
				else
				{
					File.Delete($"{text2}{text}.jar");
					FileSystem.RenameFile($"{text2}{name}.jar", $"{text}.jar");
				}
			}
			if (File.Exists(text2 + "PCL\\Setup.ini"))
			{
				ModBase.WriteFile(text2 + "PCL\\Setup.ini", ModBase.ReadFile(text2 + "PCL\\Setup.ini").Replace(path, text2));
			}
			if (Operators.CompareString(ModBase.ReadIni(ModMinecraft.PathMcFolder + "PCL.ini", "Version"), name, false) == 0)
			{
				ModBase.WriteIni(ModMinecraft.PathMcFolder + "PCL.ini", "Version", text);
			}
			try
			{
				jObject["id"] = text;
				ModBase.WriteFile(text2 + text + ".json", jObject.ToString());
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "重命名实例 Json 失败");
				ProjectData.ClearProjectError();
			}
			ModMain.Hint("重命名成功！", ModMain.HintType.Finish);
			PageInstanceLeft.Instance = new ModMinecraft.McInstance(text).Load();
			if (!Information.IsNothing((object)ModMinecraft.McInstanceCurrent) && ModMinecraft.McInstanceCurrent.Equals(PageInstanceLeft.Instance))
			{
				ModBase.WriteIni(ModMinecraft.PathMcFolder + "PCL.ini", "Version", text);
			}
			Reload();
			ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
		}
		catch (System.Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			System.Exception ex6 = ex5;
			ModBase.Log(ex6, "重命名实例失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void ComboDisplayLogo_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (!IsLoad || ModAnimation.AniControlEnabled != 0)
		{
			return;
		}
		try
		{
			if (((Selector)ComboDisplayLogo).SelectedItem == ItemDisplayLogoCustom)
			{
				string text = SystemDialogs.SelectFile("常用图片文件(*.png;*.jpg;*.gif)|*.png;*.jpg;*.gif", "选择图片");
				if (Operators.CompareString(text, "", false) == 0)
				{
					Reload();
					return;
				}
				ModBase.CopyFile(text, PageInstanceLeft.Instance.Path + "PCL\\Logo.png");
			}
			else
			{
				File.Delete(PageInstanceLeft.Instance.Path + "PCL\\Logo.png");
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "更改自定义实例图标失败（" + PageInstanceLeft.Instance.Name + "）", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
		try
		{
			string text2 = Conversions.ToString(NewLateBinding.LateGet(((Selector)ComboDisplayLogo).SelectedItem, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null));
			Config.Instance.LogoPath[PageInstanceLeft.Instance.Path] = text2;
			Config.Instance.IsLogoCustom[PageInstanceLeft.Instance.Path] = Operators.CompareString(text2, "", false) != 0;
			ModBase.WriteIni(ModMinecraft.PathMcFolder + "PCL.ini", "InstanceCache", "");
			PageInstanceLeft.Instance = new ModMinecraft.McInstance(PageInstanceLeft.Instance.Name).Load();
			Reload();
			ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			ModBase.Log(ex4, "更改实例图标失败（" + PageInstanceLeft.Instance.Name + "）", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnDisplayStar_Click(object sender, EventArgs e)
	{
		try
		{
			Config.Instance.Starred[PageInstanceLeft.Instance.Path] = !PageInstanceLeft.Instance.IsStar;
			PageInstanceLeft.Instance = new ModMinecraft.McInstance(PageInstanceLeft.Instance.Name).Load();
			Reload();
			ModMinecraft.McInstanceListForceRefresh = true;
			ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "实例 " + PageInstanceLeft.Instance.Name + " 收藏状态更改失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnFolderVersion_Click()
	{
		OpenVersionFolder(PageInstanceLeft.Instance);
	}

	public static void OpenVersionFolder(ModMinecraft.McInstance Version)
	{
		ModBase.OpenExplorer(Version.Path);
	}

	private void BtnFolderSaves_Click()
	{
		string text = PageInstanceLeft.Instance.PathIndie + "saves\\";
		Directory.CreateDirectory(text);
		ModBase.OpenExplorer(text);
	}

	private void BtnFolderMods_Click()
	{
		string text = PageInstanceLeft.Instance.PathIndie + "mods\\";
		Directory.CreateDirectory(text);
		ModBase.OpenExplorer(text);
	}

	private void BtnManageScript_Click()
	{
		try
		{
			string text = SystemDialogs.SelectSaveFile("选择脚本保存位置", "启动 " + PageInstanceLeft.Instance.Name + ".bat", "批处理文件(*.bat)|*.bat");
			if (Operators.CompareString(text, "", false) == 0)
			{
				return;
			}
			if (ModLaunch.McLaunchLoader.State == ModBase.LoadState.Loading)
			{
				ModMain.Hint("请在当前启动任务结束后再试！", ModMain.HintType.Critical);
			}
			else if (ModLaunch.McLaunchStart(new ModLaunch.McLaunchOptions
			{
				SaveBatch = text,
				Version = PageInstanceLeft.Instance
			}))
			{
				if (ModProfile.SelectedProfile.Type == ModLaunch.McLoginType.Legacy)
				{
					ModMain.Hint("正在导出启动脚本……");
				}
				else
				{
					ModMain.Hint("正在导出启动脚本……（注意，使用脚本启动可能会导致登录失效！）");
				}
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "导出启动脚本失败（" + PageInstanceLeft.Instance.Name + "）", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnManageCheck_Click(object sender, EventArgs e)
	{
		try
		{
			_Closure_0024__18_002D0 arg = default(_Closure_0024__18_002D0);
			_Closure_0024__18_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__18_002D0(null);
			if (Conversions.ToBoolean(ModMinecraft.ShouldIgnoreFileCheck(PageInstanceLeft.Instance)))
			{
				ModMain.Hint("请先关闭 [实例设置 → 设置 → 高级启动选项 → 关闭文件校验]，然后再尝试补全文件！");
				return;
			}
			System.Collections.Generic.IEnumerator<ModLoader.LoaderBase> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderBase>);
			try
			{
				enumerator = ModLoader.LoaderTaskbar.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					if (Operators.CompareString(enumerator.Current.Name, PageInstanceLeft.Instance.Name + " 文件补全", false) == 0)
					{
						ModMain.Hint("正在处理中，请稍候！", ModMain.HintType.Critical);
						return;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader = new ModLoader.LoaderCombo<string>(PageInstanceLeft.Instance.Name + " 文件补全", (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)ModDownload.DlClientFix(PageInstanceLeft.Instance, CheckAssetsHash: true, ModDownload.AssetsIndexExistsBehaviour.AlwaysDownload));
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.OnStateChanged = [SpecialName] (ModLoader.LoaderBase a0) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__0();
			};
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Start(PageInstanceLeft.Instance.Name);
			ModLoader.LoaderTaskbarAdd(CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "尝试补全文件失败（" + PageInstanceLeft.Instance.Name + "）", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnManageRestore_Click(object sender, EventArgs e)
	{
		try
		{
			ModMinecraft.McInstanceInfo version = PageInstanceLeft.Instance.Version;
			if (version.McCodeMain != 99 && ModMinecraft.VersionSortInteger(version.McName, "1.5.2") == -1 && version.HasForge)
			{
				ModMain.Hint("该实例暂不支持重置！");
			}
			else if (ModMain.MyMsgBox("你确定要重置实例 " + PageInstanceLeft.Instance.Name + " 吗？\r\nPCL 将会尝试重新从互联网获取此实例的资源文件信息，并重新执行自动安装。", "实例重置确认", "确认", "取消") != 2)
			{
				ModBase.CopyFile(PageInstanceLeft.Instance.Path + PageInstanceLeft.Instance.Name + ".json", PageInstanceLeft.Instance.Path + "PCLInstallBackups\\" + PageInstanceLeft.Instance.Name + ".json");
				ModBase.CopyFile(PageInstanceLeft.Instance.Path + PageInstanceLeft.Instance.Name + ".jar", PageInstanceLeft.Instance.Path + "PCLInstallBackups\\" + PageInstanceLeft.Instance.Name + ".jar");
				if (ModDownloadLib.McInstall(new ModDownloadLib.McInstallRequest
				{
					TargetInstanceName = PageInstanceLeft.Instance.Name,
					TargetInstanceFolder = $"{ModMinecraft.PathMcFolder}versions\\{PageInstanceLeft.Instance.Name}\\",
					MinecraftName = version.McName,
					OptiFineEntry = (version.HasOptiFine ? new ModDownload.DlOptiFineListEntry
					{
						Inherit = version.McName,
						NameDisplay = version.McName + " " + version.OptiFineVersion
					} : null),
					ForgeEntry = (version.HasForge ? new ModDownload.DlForgeVersionEntry(version.ForgeVersion, null, version.McName)
					{
						Category = "installer"
					} : null),
					ForgeVersion = (version.HasForge ? version.ForgeVersion : null),
					NeoForgeVersion = (version.HasNeoForge ? version.NeoForgeVersion : null),
					CleanroomVersion = (version.HasCleanroom ? version.CleanroomVersion : null),
					FabricVersion = (version.HasFabric ? version.FabricVersion : null),
					QuiltVersion = (version.HasQuilt ? version.QuiltVersion : null),
					LiteLoaderEntry = (version.HasLiteLoader ? new ModDownload.DlLiteLoaderListEntry
					{
						Inherit = version.McName
					} : null),
					LegacyFabricVersion = (version.HasLegacyFabric ? version.LegacyFabricVersion : null)
				}, "重置"))
				{
					ModMain.FrmMain.PageChange(new FormMain.PageStackData
					{
						Page = FormMain.PageType.Launch
					});
				}
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "重置实例 " + PageInstanceLeft.Instance.Name + " 失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnManageTest_Click(object sender, MouseButtonEventArgs e)
	{
		try
		{
			ModLaunch.McLaunchStart(new ModLaunch.McLaunchOptions
			{
				Version = PageInstanceLeft.Instance,
				Test = true
			});
			ModMain.FrmMain.PageChange(FormMain.PageType.Launch);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "测试游戏失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnManageDelete_Click(object sender, EventArgs e)
	{
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_015c: Expected O, but got Unknown
		try
		{
			bool flag = Keyboard.IsKeyDown((Key)116) || Keyboard.IsKeyDown((Key)117);
			bool flag2 = PageInstanceLeft.Instance.State != 0 && Operators.CompareString(PageInstanceLeft.Instance.PathIndie, ModMinecraft.PathMcFolder, false) != 0;
			switch (ModMain.MyMsgBox(string.Format("你确定要{0}删除实例 {1} 吗？", (object)(flag ? "永久" : ""), (object)PageInstanceLeft.Instance.Name) + (flag2 ? "\r\n由于该实例开启了版本隔离，删除时该实例对应的存档、资源包、Mod 等文件也将被一并删除！" : ""), "实例删除确认", "确定", "取消", "", flag2 || flag))
			{
			case 1:
				ModBase.IniClearCache(PageInstanceLeft.Instance.PathIndie + "options.txt");
				if (flag)
				{
					ModBase.DeleteDirectory(PageInstanceLeft.Instance.Path);
					ModMain.Hint("实例 " + PageInstanceLeft.Instance.Name + " 已永久删除！", ModMain.HintType.Finish);
				}
				else
				{
					FileSystem.DeleteDirectory(PageInstanceLeft.Instance.Path, (UIOption)2, (RecycleOption)3);
					ModMain.Hint("实例 " + PageInstanceLeft.Instance.Name + " 已删除到回收站！", ModMain.HintType.Finish);
				}
				break;
			case 2:
				return;
			}
			ModLoader.LoaderFolderRun(ModMinecraft.McInstanceListLoader, ModMinecraft.PathMcFolder, ModLoader.LoaderFolderRunType.ForceRun, 1, "versions\\");
			ModMain.FrmMain.PageBack();
		}
		catch (OperationCanceledException val)
		{
			ProjectData.SetProjectError((System.Exception)val);
			OperationCanceledException ex = val;
			ModBase.Log((System.Exception)(object)ex, "删除实例 " + PageInstanceLeft.Instance.Name + " 被主动取消");
			ProjectData.ClearProjectError();
		}
		catch (System.Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			System.Exception ex3 = ex2;
			ModBase.Log(ex3, "删除实例 " + PageInstanceLeft.Instance.Name + " 失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnManagePatch_Click(object sender, EventArgs e)
	{
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		int num = ModMain.MyMsgBox(string.Format("你确定要对 {0} 的核心文件进行修补吗？ {1}修补游戏核心可能导致游戏崩溃等问题。{2}在修补核心后，文件校验会自动关闭。", (object)PageInstanceLeft.Instance.Name, (object)"\r\n", (object)"\r\n"), "修补提示", "确定", "取消");
		if (num != 1)
		{
			_ = 2;
			return;
		}
		string text = SystemDialogs.SelectFile("压缩文件(*.jar;*.zip)|*.jar;*.zip", "选择用于修补核心的文件");
		if (!((text == null) | string.IsNullOrWhiteSpace(text)))
		{
			ModMain.Hint("正在修补游戏核心，这可能需要一段时间");
			ModBase.RunInNewThread((Action)([SpecialName] () =>
			{
				new GameCore(PageInstanceLeft.Instance.Path + PageInstanceLeft.Instance.Name + ".jar").AddToCore(text);
				ModMain.Hint("修补游戏核心成功", ModMain.HintType.Finish);
				ModBase.Setup.Set("VersionAdvanceAssetsV2", true, forceReload: false, PageInstanceLeft.Instance);
			}), null, (ThreadPriority)2);
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/pageinstanceoverall.xaml", (UriKind)2);
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
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanMain = (StackPanel)target;
			break;
		case 3:
			PanDisplayItem = (Grid)target;
			break;
		case 4:
			PanInfo = (StackPanel)target;
			break;
		case 5:
			PanDisplay = (MyCard)target;
			break;
		case 6:
			PanDisplayIcon = (Grid)target;
			break;
		case 7:
			ComboDisplayLogo = (MyComboBox)target;
			break;
		case 8:
			ItemDisplayLogoCustom = (MyComboBoxItem)target;
			break;
		case 9:
			ComboDisplayType = (MyComboBox)target;
			break;
		case 10:
			BtnDisplayRename = (MyButton)target;
			break;
		case 11:
			BtnDisplayDesc = (MyButton)target;
			break;
		case 12:
			BtnDisplayStar = (MyButton)target;
			break;
		case 13:
			PanFolder = (MyCard)target;
			break;
		case 14:
			BtnFolderVersion = (MyButton)target;
			break;
		case 15:
			BtnFolderSaves = (MyButton)target;
			break;
		case 16:
			BtnFolderMods = (MyButton)target;
			break;
		case 17:
			PanManage = (MyCard)target;
			break;
		case 18:
			BtnManageScript = (MyButton)target;
			break;
		case 19:
			BtnManageTest = (MyButton)target;
			break;
		case 20:
			BtnManageCheck = (MyButton)target;
			break;
		case 21:
			BtnManageRestore = (MyButton)target;
			break;
		case 22:
			BtnManageDelete = (MyButton)target;
			break;
		case 23:
			BtnManagePatch = (MyButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__7_002D1()
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		if (string.IsNullOrWhiteSpace(Config.Instance.ModpackId[PageInstanceLeft.Instance.Path]))
		{
			return;
		}
		_Closure_0024__7_002D0 arg = default(_Closure_0024__7_002D0);
		_Closure_0024__7_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__7_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
		_Closure_0024__7_002D0 closure_0024__7_002D = CS_0024_003C_003E8__locals0;
		List<string> obj = new List<string>();
		obj.Add(Config.Instance.ModpackId[PageInstanceLeft.Instance.Path]);
		closure_0024__7_002D._0024VB_0024Local_compProjects = ModComp.CompRequest.GetCompProjectsByIds(obj);
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_compProjects.Count != 0)
		{
			ModBase.RunInUi((Action)([SpecialName] () =>
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Me.ModpackCompItem = Enumerable.First<ModComp.CompProject>((System.Collections.Generic.IEnumerable<ModComp.CompProject>)CS_0024_003C_003E8__locals0._0024VB_0024Local_compProjects).ToCompItem(ShowMcVersionDesc: false, ShowLoaderDesc: false);
				((FrameworkElement)CS_0024_003C_003E8__locals0._0024VB_0024Me.ModpackCompItem).Tag = Enumerable.First<ModComp.CompProject>((System.Collections.Generic.IEnumerable<ModComp.CompProject>)CS_0024_003C_003E8__locals0._0024VB_0024Local_compProjects);
			}));
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__7_002D3()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			//IL_030d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0312: Unknown result type (might be due to invalid IL or missing references)
			//IL_0337: Unknown result type (might be due to invalid IL or missing references)
			//IL_0342: Expected O, but got Unknown
			//IL_0343: Unknown result type (might be due to invalid IL or missing references)
			//IL_0348: Unknown result type (might be due to invalid IL or missing references)
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_036e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0382: Expected O, but got Unknown
			//IL_03d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e0: Expected O, but got Unknown
			ModMinecraft.McInstance instance = PageInstanceLeft.Instance;
			ModMinecraft.McInstanceInfo version = instance.Version;
			List<MyListItem> val = new List<MyListItem>();
			if (Config.Instance.LaunchCount[instance.Path] == 0)
			{
				val.Add(new MyListItem
				{
					Title = "启动次数",
					Info = "从未启动",
					Logo = "pack://application:,,,/images/Blocks/RedstoneLampOff.png"
				});
			}
			else
			{
				val.Add(new MyListItem
				{
					Title = "启动次数",
					Info = "已启动 " + Config.Instance.LaunchCount[instance.Path] + " 次",
					Logo = "pack://application:,,,/images/Blocks/RedstoneLampOn.png"
				});
			}
			if (!string.IsNullOrWhiteSpace(Config.Instance.ModpackVersion[instance.Path]))
			{
				val.Add(new MyListItem
				{
					Title = "整合包版本",
					Info = Config.Instance.ModpackVersion[instance.Path],
					Logo = "pack://application:,,,/images/Blocks/CommandBlock.png"
				});
			}
			val.Add(new MyListItem
			{
				Title = "Minecraft",
				Info = version.McName,
				Logo = "pack://application:,,,/images/Blocks/Grass.png"
			});
			if (version.HasForge)
			{
				val.Add(new MyListItem
				{
					Title = "Forge",
					Info = version.ForgeVersion,
					Logo = "pack://application:,,,/images/Blocks/Anvil.png"
				});
			}
			if (version.HasNeoForge)
			{
				val.Add(new MyListItem
				{
					Title = "NeoForge",
					Info = version.NeoForgeVersion,
					Logo = "pack://application:,,,/images/Blocks/NeoForge.png"
				});
			}
			if (version.HasCleanroom)
			{
				val.Add(new MyListItem
				{
					Title = "Cleanroom",
					Info = version.CleanroomVersion,
					Logo = "pack://application:,,,/images/Blocks/Cleanroom.png"
				});
			}
			if (version.HasFabric)
			{
				val.Add(new MyListItem
				{
					Title = "Fabric",
					Info = version.FabricVersion,
					Logo = "pack://application:,,,/images/Blocks/Fabric.png"
				});
			}
			if (version.HasQuilt)
			{
				val.Add(new MyListItem
				{
					Title = "Quilt",
					Info = version.QuiltVersion,
					Logo = "pack://application:,,,/images/Blocks/Quilt.png"
				});
			}
			if (version.HasOptiFine)
			{
				val.Add(new MyListItem
				{
					Title = "OptiFine",
					Info = version.OptiFineVersion,
					Logo = "pack://application:,,,/images/Blocks/GrassPath.png"
				});
			}
			if (version.HasLiteLoader)
			{
				val.Add(new MyListItem
				{
					Title = "LiteLoader",
					Info = "已安装",
					Logo = "pack://application:,,,/images/Blocks/Egg.png"
				});
			}
			if (version.HasLegacyFabric)
			{
				val.Add(new MyListItem
				{
					Title = "Legacy Fabric",
					Info = version.LegacyFabricVersion,
					Logo = "pack://application:,,,/images/Blocks/Fabric.png"
				});
			}
			if (version.HasLabyMod)
			{
				val.Add(new MyListItem
				{
					Title = "LabyMod",
					Info = version.LabyModVersion,
					Logo = "pack://application:,,,/images/Blocks/LabyMod.png"
				});
			}
			WrapPanel val2 = new WrapPanel
			{
				Margin = new Thickness(0.0, -5.0, -20.0, 7.0)
			};
			System.Collections.Generic.IEnumerator<MyListItem> enumerator = default(System.Collections.Generic.IEnumerator<MyListItem>);
			try
			{
				enumerator = val.GetEnumerator();
				while (enumerator.MoveNext())
				{
					MyListItem current = enumerator.Current;
					((Panel)val2).Children.Add((UIElement)(object)current);
					((Panel)val2).Children.Add((UIElement)new TextBlock
					{
						Width = 2.0
					});
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			((Panel)PanInfo).Children.Clear();
			if (ModpackCompItem != null)
			{
				((Panel)PanInfo).Children.Add((UIElement)(object)ModpackCompItem);
				((Panel)PanInfo).Children.Add((UIElement)new TextBlock());
			}
			((Panel)PanInfo).Children.Add((UIElement)(object)val2);
		}));
	}
}
