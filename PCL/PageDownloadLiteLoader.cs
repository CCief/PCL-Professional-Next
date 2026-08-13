using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageDownloadLiteLoader : MyPageRight, IComponentConnector
{
	[CompilerGenerated]
	[AccessedThroughProperty("BtnWeb")]
	private MyButton _BtnWeb;

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
	[field: AccessedThroughProperty("CardTip")]
	internal virtual MyCard CardTip
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabConnect")]
	internal virtual TextBlock LabConnect
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnWeb
	{
		[CompilerGenerated]
		get
		{
			return _BtnWeb;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnWeb_Click;
			MyButton btnWeb = _BtnWeb;
			if (btnWeb != null)
			{
				btnWeb.Click -= obj;
			}
			_BtnWeb = value;
			btnWeb = _BtnWeb;
			if (btnWeb != null)
			{
				btnWeb.Click += obj;
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

	public PageDownloadLiteLoader()
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
		InitializeComponent();
	}

	private void LoaderInit()
	{
		PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanMain, (FrameworkElement)(object)CardTip, ModDownload.DlLiteLoaderListLoader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
		{
			Load_OnFinish();
		});
	}

	private void Init()
	{
		((ScrollViewer)PanBack).ScrollToHome();
	}

	private void Load_OnFinish()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		try
		{
			Dictionary<string, List<ModDownload.DlLiteLoaderListEntry>> val = new Dictionary<string, List<ModDownload.DlLiteLoaderListEntry>>();
			int num = 30;
			do
			{
				val.Add("1." + Conversions.ToString(num), new List<ModDownload.DlLiteLoaderListEntry>());
				num = checked(num + -1);
			}
			while (num >= 0);
			val.Add("未知版本", new List<ModDownload.DlLiteLoaderListEntry>());
			System.Collections.Generic.IEnumerator<ModDownload.DlLiteLoaderListEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModDownload.DlLiteLoaderListEntry>);
			try
			{
				enumerator = ModDownload.DlLiteLoaderListLoader.Output.Value.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModDownload.DlLiteLoaderListEntry current = enumerator.Current;
					string text = "1." + current.Inherit.Split(".", (StringSplitOptions)0)[1];
					if (val.ContainsKey(text))
					{
						val[text].Add(current);
					}
					else
					{
						val["未知版本"].Add(current);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			((Panel)PanMain).Children.Clear();
			System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<ModDownload.DlLiteLoaderListEntry>>> enumerator2 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<ModDownload.DlLiteLoaderListEntry>>>);
			try
			{
				enumerator2 = val.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					KeyValuePair<string, List<ModDownload.DlLiteLoaderListEntry>> current2 = enumerator2.Current;
					if (!Enumerable.Any<ModDownload.DlLiteLoaderListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlLiteLoaderListEntry>)current2.Value))
					{
						continue;
					}
					MyCard obj = new MyCard
					{
						Title = current2.Key + " (" + Conversions.ToString(current2.Value.Count) + ")"
					};
					((FrameworkElement)obj).Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
					MyCard myCard = obj;
					StackPanel val2 = new StackPanel
					{
						Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
						VerticalAlignment = (VerticalAlignment)0,
						RenderTransform = (Transform)new TranslateTransform(0.0, 0.0),
						Tag = current2.Value
					};
					((Panel)myCard).Children.Add((UIElement)(object)val2);
					myCard.SwapControl = val2;
					myCard.IsSwapped = true;
					myCard.InstallMethod = [SpecialName] (StackPanel Stack) =>
					{
						((FrameworkElement)Stack).Tag = ModBase.Sort((System.Collections.Generic.IList<ModDownload.DlLiteLoaderListEntry>)(List<ModDownload.DlLiteLoaderListEntry>)((FrameworkElement)Stack).Tag, [SpecialName] (ModDownload.DlLiteLoaderListEntry a, ModDownload.DlLiteLoaderListEntry b) => ModMinecraft.VersionSortBoolean(a.Inherit, b.Inherit));
						foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(item);
							((Panel)Stack).Children.Add((UIElement)(object)ModDownloadLib.LiteLoaderDownloadListItem((ModDownload.DlLiteLoaderListEntry)objectValue, ModDownloadLib.LiteLoaderSave_Click, IsSaveOnly: true));
						}
					};
					((Panel)PanMain).Children.Add((UIElement)(object)myCard);
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
			ModBase.Log(ex2, "可视化 LiteLoader 版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public void DownloadStart(MyListItem sender, object e)
	{
		ModDownloadLib.McDownloadLiteLoader((ModDownload.DlLiteLoaderListEntry)((FrameworkElement)sender).Tag);
	}

	private void BtnWeb_Click(object sender, EventArgs e)
	{
		ModBase.OpenWebsite("https://www.liteloader.com");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagedownload/pagedownloadliteloader.xaml", (UriKind)2);
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
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			CardTip = (MyCard)target;
			break;
		case 3:
			LabConnect = (TextBlock)target;
			break;
		case 4:
			BtnWeb = (MyButton)target;
			break;
		case 5:
			PanMain = (StackPanel)target;
			break;
		case 6:
			PanLoad = (MyCard)target;
			break;
		case 7:
			Load = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
