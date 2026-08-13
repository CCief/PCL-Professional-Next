using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageLaunchRight : MyPageRight, IRefreshable, IComponentConnector
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__4_002D0
	{
		public string _0024VB_0024Local_Content;

		public PageLaunchRight _0024VB_0024Me;

		public _Closure_0024__4_002D0(_Closure_0024__4_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Content = arg0._0024VB_0024Local_Content;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			_0024VB_0024Me.LoadContent(_0024VB_0024Local_Content);
		}
	}

	private object RefreshLock;

	private ModLoader.LoaderTask<string, int> OnlineLoader;

	private int LoadedContentHash;

	private object LoadContentLock;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnHintClose")]
	private MyIconButton _BtnHintClose;

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
	[field: AccessedThroughProperty("PanCustom")]
	internal virtual StackPanel PanCustom
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanHint")]
	internal virtual MyCard PanHint
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconButton BtnHintClose
	{
		[CompilerGenerated]
		get
		{
			return _BtnHintClose;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = BtnHintClose_Click;
			MyIconButton btnHintClose = _BtnHintClose;
			if (btnHintClose != null)
			{
				btnHintClose.Click -= obj;
			}
			_BtnHintClose = value;
			btnHintClose = _BtnHintClose;
			if (btnHintClose != null)
			{
				btnHintClose.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabHint1")]
	internal virtual TextBlock LabHint1
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabHint2")]
	internal virtual TextBlock LabHint2
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLog")]
	internal virtual MyCard PanLog
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLog")]
	internal virtual TextBlock LabLog
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageLaunchRight()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Init();
		});
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Refresh();
		});
		RefreshLock = RuntimeHelpers.GetObjectValue(new object());
		OnlineLoader = new ModLoader.LoaderTask<string, int>("下载主页", OnlineLoaderSub, null, (ThreadPriority)2)
		{
			ReloadTimeout = 600000
		};
		LoadedContentHash = -1;
		LoadContentLock = RuntimeHelpers.GetObjectValue(new object());
		InitializeComponent();
	}

	private void Init()
	{
		((ScrollViewer)PanBack).ScrollToHome();
		base.PanScroll = PanBack;
		((UIElement)PanLog).Visibility = (Visibility)((!ModBase.ModeDebug) ? 2 : 0);
		((UIElement)PanHint).Visibility = (Visibility)((!Conversions.ToBoolean(ModBase.Setup.Get("UiLauncherCEHint"))) ? 2 : 0);
		LabHint1.Text = "社区版包含未在官方主线版本发布的功能，仅用于尝鲜。请不要向官方仓库反馈社区版的问题哦！";
		LabHint2.Text = "若要永久隐藏此提示，请参阅 README。";
	}

	private void BtnHintClose_Click(object sender, EventArgs e)
	{
		ModAnimation.AniDispose(PanHint, RemoveFromChildren: true);
	}

	private void Refresh()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		ModBase.RunInNewThread((Action)([SpecialName] [CompilerGenerated] () =>
		{
			try
			{
				object refreshLock = RefreshLock;
				ObjectFlowControl.CheckForSyncLockOnValueType(refreshLock);
				bool flag = false;
				try
				{
					Monitor.Enter(refreshLock, ref flag);
					RefreshReal();
				}
				finally
				{
					if (flag)
					{
						Monitor.Exit(refreshLock);
					}
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "加载 PCL 主页自定义信息失败", ModBase.ModeDebug ? ModBase.LogLevel.Msgbox : ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
		}), $"刷新主页 #{ModBase.GetUuid()}", (ThreadPriority)2);
	}

	private void RefreshReal()
	{
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Expected O, but got Unknown
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Expected O, but got Unknown
		_Closure_0024__4_002D0 arg = default(_Closure_0024__4_002D0);
		_Closure_0024__4_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__4_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Content = "";
		object obj = ModBase.Setup.Get("UiCustomType");
		string text;
		if (Operators.ConditionalCompareObjectEqual(obj, (object)1, false))
		{
			ModBase.Log("[Page] 主页自定义数据来源：本地文件");
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Content = ModBase.ReadFile(ModBase.ExePath + "PCL\\Custom.xaml");
		}
		else
		{
			if (Operators.ConditionalCompareObjectEqual(obj, (object)2, false))
			{
				text = Conversions.ToString(ModBase.Setup.Get("UiCustomNet"));
				goto IL_0091;
			}
			if (Operators.ConditionalCompareObjectEqual(obj, (object)3, false))
			{
				object obj2 = ModBase.Setup.Get("UiCustomPreset");
				if (Operators.ConditionalCompareObjectEqual(obj2, (object)0, false))
				{
					ModBase.Log("[Page] 主页预设：你知道吗");
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Content = "\n                            <local:MyCard Title=\"你知道吗？\" Margin=\"0,0,0,15\">\n                                <TextBlock Margin=\"25,38,23,15\" FontSize=\"13.5\" IsHitTestVisible=\"False\" Text=\"{hint}\" TextWrapping=\"Wrap\" Foreground=\"{DynamicResource ColorBrush1}\" />\n                                <local:MyIconButton Height=\"22\" Width=\"22\" Margin=\"9\" VerticalAlignment=\"Top\" HorizontalAlignment=\"Right\" \n                                    EventType=\"刷新主页\" EventData=\"/\"\n                                    Logo=\"M875.52 148.48C783.36 56.32 655.36 0 512 0 291.84 0 107.52 138.24 30.72 332.8l122.88 46.08C204.8 230.4 348.16 128 512 128c107.52 0 199.68 40.96 271.36 112.64L640 384h384V0L875.52 148.48zM512 896c-107.52 0-199.68-40.96-271.36-112.64L384 640H0v384l148.48-148.48C240.64 967.68 368.64 1024 512 1024c220.16 0 404.48-138.24 481.28-332.8L870.4 645.12C819.2 793.6 675.84 896 512 896z\" />\n                            </local:MyCard>";
				}
				else
				{
					if (!Operators.ConditionalCompareObjectEqual(obj2, (object)1, false))
					{
						if (Operators.ConditionalCompareObjectEqual(obj2, (object)2, false))
						{
							ModBase.Log("[Page] 主页预设：Minecraft 新闻");
							text = "https://pcl.mcnews.thestack.top";
						}
						else if (Operators.ConditionalCompareObjectEqual(obj2, (object)3, false))
						{
							ModBase.Log("[Page] 主页预设：简单主页");
							text = "https://pclhomeplazaoss.lingyunawa.top:26994/d/Homepages/MFn233/Custom.xaml";
						}
						else if (Operators.ConditionalCompareObjectEqual(obj2, (object)4, false))
						{
							ModBase.Log("[Page] 主页预设：每日整合包推荐");
							text = "https://pclsub.sodamc.com/";
						}
						else if (Operators.ConditionalCompareObjectEqual(obj2, (object)5, false))
						{
							ModBase.Log("[Page] 主页预设：Minecraft 皮肤推荐");
							text = "https://forgepixel.com/pcl_sub_file";
						}
						else if (Operators.ConditionalCompareObjectEqual(obj2, (object)6, false))
						{
							ModBase.Log("[Page] 主页预设：OpenBMCLAPI 仪表盘 Lite");
							text = "https://pcl-bmcl.milu.ink/";
						}
						else if (Operators.ConditionalCompareObjectEqual(obj2, (object)7, false))
						{
							ModBase.Log("[Page] 主页预设：主页市场");
							text = "https://pclhomeplazaoss.lingyunawa.top:26994/d/Homepages/JingHai-Lingyun/Custom.xaml";
						}
						else if (Operators.ConditionalCompareObjectEqual(obj2, (object)8, false))
						{
							ModBase.Log("[Page] 主页预设：更新日志");
							text = "https://pclhomeplazaoss.lingyunawa.top:26994/d/Homepages/Joker2184/UpdateHomepage.xaml";
						}
						else if (Operators.ConditionalCompareObjectEqual(obj2, (object)9, false))
						{
							ModBase.Log("[Page] 主页预设：PCL 新功能说明书");
							text = "https://raw.gitcode.com/WForst-Breeze/WhatsNewPCL/raw/main/Custom.xaml";
						}
						else if (Operators.ConditionalCompareObjectEqual(obj2, (object)10, false))
						{
							ModBase.Log("[Page] 主页预设：OpenMCIM Dashboard");
							text = "https://files.mcimirror.top/PCL";
						}
						else if (Operators.ConditionalCompareObjectEqual(obj2, (object)11, false))
						{
							ModBase.Log("[Page] 主页预设：杂志主页");
							text = "https://pclhomeplazaoss.lingyunawa.top:26994/d/Homepages/Ext1nguisher/Custom.xaml";
						}
						else if (Operators.ConditionalCompareObjectEqual(obj2, (object)12, false))
						{
							ModBase.Log("[Page] 主页预设：PCL GitHub 仪表盘");
							text = "https://ddf.pcl-community.org/Custom.xaml";
						}
						else
						{
							if (!Operators.ConditionalCompareObjectEqual(obj2, (object)13, false))
							{
								goto IL_03d7;
							}
							ModBase.Log("[Page] 主页预设：PCL Pro-N 公告栏");
							text = "https://s3.pysio.online/pcl2-ce/apiv2/pages/announce.xaml";
						}
						goto IL_0091;
					}
					ModBase.Log("[Page] 主页预设：回声洞");
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Content = "\n                            <local:MyCard Title=\"回声洞\" Margin=\"0,0,0,15\">\n                                <TextBlock Margin=\"25,38,23,15\" FontSize=\"13.5\" IsHitTestVisible=\"False\" Text=\"{cave}\" TextWrapping=\"Wrap\" Foreground=\"{DynamicResource ColorBrush1}\" />\n                                <local:MyIconButton Height=\"22\" Width=\"22\" Margin=\"9\" VerticalAlignment=\"Top\" HorizontalAlignment=\"Right\" \n                                    EventType=\"刷新主页\" EventData=\"/\"\n                                    Logo=\"M875.52 148.48C783.36 56.32 655.36 0 512 0 291.84 0 107.52 138.24 30.72 332.8l122.88 46.08C204.8 230.4 348.16 128 512 128c107.52 0 199.68 40.96 271.36 112.64L640 384h384V0L875.52 148.48zM512 896c-107.52 0-199.68-40.96-271.36-112.64L384 640H0v384l148.48-148.48C240.64 967.68 368.64 1024 512 1024c220.16 0 404.48-138.24 481.28-332.8L870.4 645.12C819.2 793.6 675.84 896 512 896z\" />\n                            </local:MyCard>";
				}
			}
		}
		goto IL_03d7;
		IL_0091:
		if (!string.IsNullOrWhiteSpace(text))
		{
			if (!Operators.ConditionalCompareObjectEqual((object)text, ModBase.Setup.Get("CacheSavedPageUrl"), false) || !File.Exists(ModBase.PathTemp + "Cache\\Custom.xaml"))
			{
				ModBase.Log("[Page] 主页自定义数据来源：联网全新下载");
				ModMain.Hint("正在加载主页……");
				ModBase.RunInUiWait((Action)([SpecialName] [CompilerGenerated] () =>
				{
					LoadContent("");
				}));
				ModBase.Setup.Set("CacheSavedPageVersion", "");
				OnlineLoader.Start(text);
				return;
			}
			ModBase.Log("[Page] 主页自定义数据来源：联网缓存文件");
			CS_0024_003C_003E8__locals0._0024VB_0024Local_Content = ModBase.ReadFile(ModBase.PathTemp + "Cache\\Custom.xaml");
			OnlineLoader.Start(text);
		}
		goto IL_03d7;
		IL_03d7:
		ModBase.RunInUi((Action)([SpecialName] () =>
		{
			CS_0024_003C_003E8__locals0._0024VB_0024Me.LoadContent(CS_0024_003C_003E8__locals0._0024VB_0024Local_Content);
		}));
	}

	private void OnlineLoaderSub(ModLoader.LoaderTask<string, int> Task)
	{
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		string input = Task.Input;
		try
		{
			string text;
			if (input.Contains(".xaml"))
			{
				text = input.Replace(".xaml", ".xaml.ini");
			}
			else
			{
				text = ModBase.BeforeFirst(input, "?");
				if (!text.EndsWith("/"))
				{
					text += "/";
				}
				text += "version";
				if (input.Contains("?"))
				{
					text = text + "?" + ModBase.AfterFirst(input, "?");
				}
			}
			string text2 = "";
			bool flag = true;
			try
			{
				text2 = Conversions.ToString(ModNet.NetGetCodeByRequestOnce(text, null, 10000));
				if (text2.Length > 1000)
				{
					throw new System.Exception($"获取的主页版本过长（{text2.Length} 字符）");
				}
				string text3 = Conversions.ToString(ModBase.Setup.Get("CacheSavedPageVersion"));
				if (Operators.CompareString(text2, "", false) != 0 && Operators.CompareString(text3, "", false) != 0 && Operators.CompareString(text2, text3, false) == 0)
				{
					ModBase.Log($"[Page] 当前缓存的主页已为最新，当前版本：{text2}，检查源：{text}");
					flag = false;
				}
				else
				{
					ModBase.Log($"[Page] 需要下载联网主页，当前版本：{text2}，检查源：{text}");
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "联网获取主页版本失败", ModBase.LogLevel.Developer);
				ModBase.Log($"[Page] 无法检查联网主页版本，将直接下载，检查源：{text}");
				ProjectData.ClearProjectError();
			}
			if (flag)
			{
				string text4 = Conversions.ToString(ModNet.NetGetCodeByRequestRetry(input));
				ModBase.Log($"[Page] 已联网下载主页，内容长度：{text4.Length}，来源：{input}");
				ModBase.Setup.Set("CacheSavedPageUrl", input);
				ModBase.Setup.Set("CacheSavedPageVersion", text2);
				ModBase.WriteFile(ModBase.PathTemp + "Cache\\Custom.xaml", text4);
			}
			ModBase.RunInUi(new Action(Refresh));
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			ModBase.Log(ex4, $"下载主页失败（{input}）", ModBase.ModeDebug ? ModBase.LogLevel.Msgbox : ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	public void ForceRefresh()
	{
		ModBase.Log("[Page] 要求强制刷新主页");
		ClearCache();
		if (ModMain.FrmMain.PageCurrent.Page == FormMain.PageType.Launch)
		{
			((ScrollViewer)PanBack).ScrollToHome();
			Refresh();
		}
		else
		{
			ModMain.FrmMain.PageChange(FormMain.PageType.Launch);
		}
	}

	void IRefreshable.Refresh()
	{
		//ILSpy generated this explicit interface implementation from .override directive in ForceRefresh
		this.ForceRefresh();
	}

	private void ClearCache()
	{
		LoadedContentHash = -1;
		OnlineLoader.Input = "";
		ModBase.Setup.Set("CacheSavedPageUrl", "");
		ModBase.Setup.Set("CacheSavedPageVersion", "");
		ModBase.Log("[Page] 已清空主页缓存");
	}

	private void LoadContent(string Content)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		object loadContentLock = LoadContentLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(loadContentLock);
		bool flag = false;
		try
		{
			Monitor.Enter(loadContentLock, ref flag);
			int hashCode = Content.GetHashCode();
			if (hashCode == LoadedContentHash)
			{
				return;
			}
			LoadedContentHash = hashCode;
			((Panel)PanCustom).Children.Clear();
			if (string.IsNullOrWhiteSpace(Content))
			{
				ModBase.Log("[Page] 实例化：清空主页 UI，来源为空");
				return;
			}
			System.DateTime now = System.DateTime.Now;
			try
			{
				Content = ModMain.HelpArgumentReplace(Content);
				while (Content.Contains("xmlns"))
				{
					Content = ModBase.RegexReplace(Content, "xmlns[^\"']*(\"|')[^\"']*(\"|')", "", (RegexOptions)0).Replace("xmlns", "");
				}
				Content = "<StackPanel xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\" xmlns:sys=\"clr-namespace:System;assembly=System.Runtime\" xmlns:x=\"http://schemas.microsoft.com/winfx/2006/xaml\" xmlns:local=\"clr-namespace:PCL;assembly=Plain Craft Launcher 2\">" + Content + "</StackPanel>";
				ModBase.Log($"[Page] 实例化：加载主页 UI 开始，最终内容长度：{Enumerable.Count<char>((System.Collections.Generic.IEnumerable<char>)Content)}");
				((Panel)PanCustom).Children.Add((UIElement)ModBase.GetObjectFromXML(Content));
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				if (!ModBase.ModeDebug)
				{
					ModBase.Log(ex2, "加载主页界面失败", ModBase.LogLevel.Hint);
					goto IL_017f;
				}
				ModBase.Log(ex2, "加载失败的主页内容：\r\n" + Content);
				if (ModMain.MyMsgBox((ex2 is UnauthorizedAccessException) ? ex2.Message : string.Format("主页内容编写有误，请根据下列错误信息进行检查：{0}{1}", (object)"\r\n", (object)ex2.ToString()), "加载主页界面失败", "重试", "取消") != 1)
				{
					goto IL_017f;
				}
				ProjectData.ClearProjectError();
				goto end_IL_000f;
				IL_017f:
				ProjectData.ClearProjectError();
				return;
			}
			TimeSpan val = System.DateTime.Now - now;
			int milliseconds = val.Milliseconds;
			ModBase.Log($"[Page] 实例化：加载主页 UI 完成，耗时 {milliseconds}ms");
			if (milliseconds > 3000)
			{
				ModMain.Hint($"主页加载过于缓慢（花费了 {Math.Round((double)milliseconds / 1000.0, 1)} 秒），请向主页作者反馈此问题，或暂时停止使用该主页");
			}
			return;
			end_IL_000f:;
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(loadContentLock);
			}
		}
		ForceRefresh();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelaunch/pagelaunchright.xaml", (UriKind)2);
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
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanMain = (StackPanel)target;
			break;
		case 3:
			PanCustom = (StackPanel)target;
			break;
		case 4:
			PanHint = (MyCard)target;
			break;
		case 5:
			BtnHintClose = (MyIconButton)target;
			break;
		case 6:
			LabHint1 = (TextBlock)target;
			break;
		case 7:
			LabHint2 = (TextBlock)target;
			break;
		case 8:
			PanLog = (MyCard)target;
			break;
		case 9:
			LabLog = (TextBlock)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
