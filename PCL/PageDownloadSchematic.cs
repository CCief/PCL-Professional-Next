using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace PCL;

[DesignerGenerated]
public class PageDownloadSchematic : MyPageRight, IComponentConnector
{
	public class SchematicRequest
	{
		[field: CompilerGenerated]
		public int Begin
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string Filter
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public bool HeatSort
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public int Type
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public SchematicRequest()
		{
			Begin = 0;
			Filter = "";
			HeatSort = false;
			Type = 0;
		}
	}

	public class SchematicInfo
	{
		[field: CompilerGenerated]
		public string Uuid
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public int Type
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public int Heat
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string Author
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string NickName
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string AvatarUrl
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string Size
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string Name
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string Tags
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string Description
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string UpdateTime
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string UploadTime
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public string TypeName => Type switch
		{
			1 => "投影", 
			2 => "NBT", 
			3 => "Schematic", 
			4 => "mcstructure", 
			_ => "未知", 
		};

		public string FileExtension => Type switch
		{
			1 => ".litematic", 
			2 => ".nbt", 
			3 => ".schematic", 
			4 => ".mcstructure", 
			_ => "", 
		};

		public string DownloadUrl => $"https://www.mcschematic.top/api/schematicFile?uuid={Uuid}";

		public string SizeDisplay
		{
			get
			{
				try
				{
					if (string.IsNullOrEmpty(Size) || Operators.CompareString(Size, "null", false) == 0)
					{
						return "未知尺寸";
					}
					object objectValue = RuntimeHelpers.GetObjectValue(ModBase.GetJson(Size));
					if (objectValue != null && Operators.ConditionalCompareObjectGreaterEqual(NewLateBinding.LateGet(objectValue, (System.Type)null, "Count", new object[0], (string[])null, (System.Type[])null, (bool[])null), (object)3, false))
					{
						return $"{RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, new object[] { 0 }, (string[])null))}×{RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, new object[] { 1 }, (string[])null))}×{RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(objectValue, new object[] { 2 }, (string[])null))}";
					}
				}
				catch (System.Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
				return "未知尺寸";
			}
		}

		public MyListItem ToUIItem()
		{
			MyListItem obj = new MyListItem
			{
				Title = Name,
				Info = $"{TypeName} | {SizeDisplay} | 热度 {Heat}" + ((!string.IsNullOrEmpty(NickName)) ? $" | 作者: {NickName}" : "")
			};
			((FrameworkElement)obj).Tag = this;
			obj.Type = MyListItem.CheckType.None;
			MyListItem myListItem = obj;
			if (!string.IsNullOrEmpty(AvatarUrl) && Operators.CompareString(AvatarUrl, "null", false) != 0)
			{
				myListItem.Logo = AvatarUrl;
			}
			else
			{
				myListItem.Logo = ModBase.PathImage + "Blocks/GrassBlock.png";
			}
			return myListItem;
		}
	}

	private const string API_BASE_URL = "https://www.mcschematic.top/api/";

	private const int PAGE_SIZE = 15;

	private int CurrentPage;

	private bool HasMoreData;

	private ModLoader.LoaderTask<SchematicRequest, List<SchematicInfo>> Loader;

	private bool IsLoaderInited;

	[CompilerGenerated]
	[AccessedThroughProperty("PanSearchBox")]
	private MySearchBox _PanSearchBox;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSearchReset")]
	private MyIconButton _BtnSearchReset;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnPageFirst")]
	private MyIconButton _BtnPageFirst;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnPageLeft")]
	private MyIconButton _BtnPageLeft;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnPageRight")]
	private MyIconButton _BtnPageRight;

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
			MySearchBox.SearchEventHandler obj = PanSearchBox_Search;
			KeyEventHandler val = new KeyEventHandler(PanSearchBox_KeyDown);
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
	[field: AccessedThroughProperty("ComboSearchType")]
	internal virtual MyComboBox ComboSearchType
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
				//IL_0008: Unknown result type (might be due to invalid IL or missing references)
				//IL_0012: Expected O, but got Unknown
				BtnSearchReset_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
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

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("Load")]
	internal virtual MyLoading Load
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageDownloadSchematic()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageDownloadSchematic_Loaded);
		CurrentPage = 0;
		HasMoreData = true;
		Loader = new ModLoader.LoaderTask<SchematicRequest, List<SchematicInfo>>("蓝图列表获取", LoadSchematics, GetLoaderInput, (ThreadPriority)2)
		{
			ReloadTimeout = 60000
		};
		IsLoaderInited = false;
		InitializeComponent();
	}

	private void PageDownloadSchematic_Loaded(object sender, RoutedEventArgs e)
	{
		if (!IsLoaderInited)
		{
			IsLoaderInited = true;
			((UIElement)PanContent).Visibility = (Visibility)2;
			((UIElement)PanLoad).Visibility = (Visibility)0;
			Loader.PreviewFinish += [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
			{
				Loader_PreviewFinish();
			};
			Load.StateChanged += Load_StateChanged;
			InitPageLoader();
			Loader.Start();
		}
	}

	private void InitPageLoader()
	{
		Loader.OnStateChanged = [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
		{
			_Lambda_0024__10_002D0();
		};
	}

	public void PageLoaderRestart()
	{
		CurrentPage = 0;
		HasMoreData = true;
		Loader.Start();
	}

	private SchematicRequest GetLoaderInput()
	{
		SchematicRequest schematicRequest = new SchematicRequest();
		schematicRequest.Begin = CurrentPage;
		schematicRequest.Filter = PanSearchBox.Text;
		object selectedItem = ((Selector)ComboSearchSort).SelectedItem;
		schematicRequest.HeatSort = Operators.CompareString((selectedItem == null) ? null : NewLateBinding.LateGet(selectedItem, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)?.ToString(), "true", false) == 0;
		object selectedItem2 = ((Selector)ComboSearchType).SelectedItem;
		schematicRequest.Type = Conversions.ToInteger((selectedItem2 == null) ? null : NewLateBinding.LateGet(selectedItem2, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)?.ToString());
		return schematicRequest;
	}

	private void LoadSchematics(ModLoader.LoaderTask<SchematicRequest, List<SchematicInfo>> Task)
	{
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		SchematicRequest input = Task.Input;
		object[] obj = new object[6]
		{
			"https://www.mcschematic.top/api/",
			input.Begin,
			Uri.EscapeDataString(input.Filter),
			input.HeatSort.ToString().ToLower(),
			input.Type,
			null
		};
		DateTimeOffset now = DateTimeOffset.Now;
		obj[5] = now.ToUnixTimeMilliseconds();
		string text = string.Format("{0}schematics?begin={1}&filter={2}&heatSort={3}&type={4}&t={5}", obj);
		ModBase.Log($"[Schematic] 请求蓝图列表: {text}");
		JArray jArray = JArray.Parse(Conversions.ToString(ModNet.NetGetCodeByRequestRetry(text)));
		List<SchematicInfo> val = new List<SchematicInfo>();
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator = jArray.GetEnumerator();
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				JObject jObject = (JObject)enumerator.Current;
				SchematicInfo schematicInfo = new SchematicInfo();
				schematicInfo.Uuid = jObject["uuid"]?.ToString();
				schematicInfo.Type = jObject["type"]?.ToObject<int>() ?? 0;
				schematicInfo.Heat = jObject["heat"]?.ToObject<int>() ?? 0;
				schematicInfo.Author = jObject["author"]?.ToString();
				schematicInfo.NickName = jObject["nickName"]?.ToString();
				schematicInfo.AvatarUrl = jObject["avatarUrl"]?.ToString();
				schematicInfo.Size = jObject["size"]?.ToString();
				schematicInfo.Name = jObject["name"]?.ToString();
				schematicInfo.Tags = jObject["tags"]?.ToString();
				schematicInfo.Description = jObject["description"]?.ToString();
				schematicInfo.UpdateTime = jObject["updateTime"]?.ToString();
				schematicInfo.UploadTime = jObject["uploadTime"]?.ToString();
				SchematicInfo schematicInfo2 = schematicInfo;
				val.Add(schematicInfo2);
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		HasMoreData = val.Count >= 15;
		Task.Output = val;
		ModBase.Log($"[Schematic] 获取到 {val.Count} 个蓝图");
	}

	private void Loader_PreviewFinish()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				((Panel)PanProjects).Children.Clear();
				if (Loader.Output != null && Loader.Output.Count > 0)
				{
					System.Collections.Generic.IEnumerator<SchematicInfo> enumerator = default(System.Collections.Generic.IEnumerator<SchematicInfo>);
					try
					{
						enumerator = Loader.Output.GetEnumerator();
						while (enumerator.MoveNext())
						{
							MyListItem myListItem = enumerator.Current.ToUIItem();
							myListItem.Click += SchematicItem_Click;
							((Panel)PanProjects).Children.Add((UIElement)(object)myListItem);
						}
					}
					finally
					{
						((System.IDisposable)enumerator).Dispose();
					}
					((UIElement)HintError).Visibility = (Visibility)2;
				}
				else
				{
					((UIElement)HintError).Visibility = (Visibility)0;
					HintError.Text = "没有找到符合条件的蓝图";
				}
				UpdatePageButtons();
				((UIElement)PanContent).Visibility = (Visibility)0;
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "蓝图列表可视化出错", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}));
	}

	private void Load_StateChanged(object sender, MyLoading.MyLoadingState state, MyLoading.MyLoadingState oldState)
	{
		ModBase.LoadState state2 = Loader.State;
		if (state2 == ModBase.LoadState.Failed && Loader.Error != null)
		{
			ModBase.Log($"[Schematic] 加载失败: {Loader.Error.Message}", ModBase.LogLevel.Debug);
		}
	}

	private void PanSearchBox_Search(object sender, EventArgs e)
	{
		StartNewSearch();
	}

	private void PanSearchBox_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6)
		{
			StartNewSearch();
		}
	}

	private void StartNewSearch()
	{
		CurrentPage = 0;
		HasMoreData = true;
		Loader.Start();
	}

	private void BtnSearchReset_Click(object sender, RoutedEventArgs e)
	{
		PanSearchBox.Text = "";
		((Selector)ComboSearchType).SelectedIndex = 0;
		((Selector)ComboSearchSort).SelectedIndex = 0;
		Loader.LastFinishedTime = 0L;
	}

	private void UpdatePageButtons()
	{
		((UIElement)CardPages).Visibility = (Visibility)((!HasMoreData && CurrentPage <= 0) ? 2 : 0);
		LabPage.Text = checked(CurrentPage + 1).ToString();
		((UIElement)BtnPageFirst).IsEnabled = CurrentPage > 1;
		((UIElement)BtnPageFirst).Opacity = ((CurrentPage > 1) ? 1.0 : 0.2);
		((UIElement)BtnPageLeft).IsEnabled = CurrentPage > 0;
		((UIElement)BtnPageLeft).Opacity = ((CurrentPage > 0) ? 1.0 : 0.2);
		((UIElement)BtnPageRight).IsEnabled = HasMoreData;
		((UIElement)BtnPageRight).Opacity = (HasMoreData ? 1.0 : 0.2);
	}

	private void BtnPageFirst_Click(object sender, RoutedEventArgs e)
	{
		ChangePage(0);
	}

	private void BtnPageLeft_Click(object sender, RoutedEventArgs e)
	{
		ChangePage(checked(CurrentPage - 1));
	}

	private void BtnPageRight_Click(object sender, RoutedEventArgs e)
	{
		ChangePage(checked(CurrentPage + 1));
	}

	private void ChangePage(int NewPage)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		((UIElement)CardPages).IsEnabled = false;
		CurrentPage = NewPage;
		ModMain.FrmMain.BackToTop();
		ModBase.Log($"[Schematic] 切换到第 {checked(CurrentPage + 1)} 页");
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

	private void SchematicItem_Click(object sender, EventArgs e)
	{
		SchematicInfo schematicInfo = (SchematicInfo)((FrameworkElement)(MyListItem)sender).Tag;
		if (ModMain.MyMsgBox(string.Concat(new string[7]
		{
			string.Format("蓝图名称：{0}{1}", (object)schematicInfo.Name, (object)"\r\n"),
			string.Format("类型：{0}{1}", (object)schematicInfo.TypeName, (object)"\r\n"),
			string.Format("尺寸：{0}{1}", (object)schematicInfo.SizeDisplay, (object)"\r\n"),
			string.Format("热度：{0}{1}", (object)schematicInfo.Heat, (object)"\r\n"),
			string.Format("作者：{0}{1}", (object)schematicInfo.NickName, (object)"\r\n"),
			(!string.IsNullOrEmpty(schematicInfo.Description) && Operators.CompareString(schematicInfo.Description, "null", false) != 0) ? string.Format("描述：{0}{1}", (object)schematicInfo.Description, (object)"\r\n") : "",
			string.Format("{0}是否下载此蓝图？", (object)"\r\n")
		}), "蓝图下载", "下载", "取消") == 1)
		{
			DownloadSchematic(schematicInfo);
		}
	}

	private void DownloadSchematic(SchematicInfo schematic)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		try
		{
			string fileName = SecureFileName(schematic.Name) + schematic.FileExtension;
			string text = "";
			text = (((object)ModMinecraft.McInstanceCurrent == null) ? (ModMinecraft.PathMcFolder + "schematics") : (ModMinecraft.McInstanceCurrent.PathIndie + "schematics"));
			Directory.CreateDirectory(text);
			SaveFileDialog val = new SaveFileDialog
			{
				Title = "保存蓝图文件",
				FileName = fileName,
				InitialDirectory = text,
				Filter = GetFileFilter(schematic.Type),
				DefaultExt = schematic.FileExtension
			};
			if (!(!((CommonDialog)val).ShowDialog()).GetValueOrDefault())
			{
				string fileName2 = ((FileDialog)val).FileName;
				string name = "下载蓝图 " + schematic.Name;
				List<ModNet.NetFile> obj = new List<ModNet.NetFile>();
				obj.Add(new ModNet.NetFile(new string[] { schematic.DownloadUrl }, fileName2, new ModBase.FileChecker(1L, -1L)));
				ModNet.LoaderDownload loaderDownload = new ModNet.LoaderDownload(name, obj);
				loaderDownload.Block = false;
				loaderDownload.Start();
				ModMain.Hint($"蓝图 {schematic.Name} 开始下载...");
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
				ModMain.FrmMain.BtnExtraDownload.Ribble();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "下载蓝图失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private string GetFileFilter(int fileType)
	{
		return fileType switch
		{
			1 => "投影文件 (*.litematic)|*.litematic|所有文件 (*.*)|*.*", 
			2 => "NBT文件 (*.nbt)|*.nbt|所有文件 (*.*)|*.*", 
			3 => "Schematic文件 (*.schematic)|*.schematic|所有文件 (*.*)|*.*", 
			4 => "MC结构文件 (*.mcstructure)|*.mcstructure|所有文件 (*.*)|*.*", 
			_ => "所有文件 (*.*)|*.*", 
		};
	}

	private string SecureFileName(string name)
	{
		char[] invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();
		foreach (char c in invalidFileNameChars)
		{
			name = name.Replace(c, '_');
		}
		return name;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagedownload/comp/pagedownloadschematic.xaml", (UriKind)2);
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
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanAlways = (StackPanel)target;
			break;
		case 3:
			PanSearchBox = (MySearchBox)target;
			break;
		case 4:
			ComboSearchType = (MyComboBox)target;
			break;
		case 5:
			ComboSearchSort = (MyComboBox)target;
			break;
		case 6:
			BtnSearchReset = (MyIconButton)target;
			break;
		case 7:
			PanContent = (StackPanel)target;
			break;
		case 8:
			HintError = (MyHint)target;
			break;
		case 9:
			CardProjects = (MyCard)target;
			break;
		case 10:
			PanProjects = (StackPanel)target;
			break;
		case 11:
			CardPages = (MyCard)target;
			break;
		case 12:
			BtnPageFirst = (MyIconButton)target;
			break;
		case 13:
			BtnPageLeft = (MyIconButton)target;
			break;
		case 14:
			LabPage = (TextBlock)target;
			break;
		case 15:
			BtnPageRight = (MyIconButton)target;
			break;
		case 16:
			PanLoad = (MyCard)target;
			break;
		case 17:
			Load = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}

	[SpecialName]
	[CompilerGenerated]
	private void _Lambda_0024__10_002D0()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			switch (Loader.State)
			{
			case ModBase.LoadState.Loading:
				Load.State = Loader;
				((UIElement)PanLoad).Visibility = (Visibility)0;
				((UIElement)PanContent).Visibility = (Visibility)2;
				break;
			case ModBase.LoadState.Finished:
				Load.State = Loader;
				((UIElement)PanLoad).Visibility = (Visibility)2;
				((UIElement)PanContent).Visibility = (Visibility)0;
				break;
			case ModBase.LoadState.Failed:
				Load.State = Loader;
				((UIElement)PanLoad).Visibility = (Visibility)0;
				((UIElement)PanContent).Visibility = (Visibility)2;
				break;
			}
		}));
	}
}
