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
public class PageDownloadOptiFine : MyPageRight, IComponentConnector
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

	public PageDownloadOptiFine()
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
		PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanMain, (FrameworkElement)(object)CardTip, ModDownload.DlOptiFineListLoader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
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
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Expected O, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Expected O, but got Unknown
		try
		{
			Dictionary<string, List<ModDownload.DlOptiFineListEntry>> val = new Dictionary<string, List<ModDownload.DlOptiFineListEntry>>();
			val.Add("快照版本", new List<ModDownload.DlOptiFineListEntry>());
			int num = 50;
			do
			{
				val.Add("1." + Conversions.ToString(num), new List<ModDownload.DlOptiFineListEntry>());
				num = checked(num + -1);
			}
			while (num >= 0);
			System.Collections.Generic.IEnumerator<ModDownload.DlOptiFineListEntry> enumerator = default(System.Collections.Generic.IEnumerator<ModDownload.DlOptiFineListEntry>);
			try
			{
				enumerator = ModDownload.DlOptiFineListLoader.Output.Value.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModDownload.DlOptiFineListEntry current = enumerator.Current;
					if (PCLVerCompat.StartsWithVer2(current.Inherit, "1."))
					{
						string text = "1." + current.NameDisplay.Split(".", (StringSplitOptions)0)[1].Split(" ", (StringSplitOptions)0)[0];
						if (val.ContainsKey(text))
						{
							val[text].Add(current);
						}
						else
						{
							val["快照版本"].Add(current);
						}
					}
					else
					{
						val["快照版本"].Add(current);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			((Panel)PanMain).Children.Clear();
			System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<ModDownload.DlOptiFineListEntry>>> enumerator2 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<ModDownload.DlOptiFineListEntry>>>);
			try
			{
				enumerator2 = val.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					KeyValuePair<string, List<ModDownload.DlOptiFineListEntry>> current2 = enumerator2.Current;
					if (!Enumerable.Any<ModDownload.DlOptiFineListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlOptiFineListEntry>)current2.Value))
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
						((FrameworkElement)Stack).Tag = ModBase.Sort((System.Collections.Generic.IList<ModDownload.DlOptiFineListEntry>)(List<ModDownload.DlOptiFineListEntry>)((FrameworkElement)Stack).Tag, [SpecialName] (ModDownload.DlOptiFineListEntry a, ModDownload.DlOptiFineListEntry b) => ModMinecraft.VersionSortBoolean(a.NameDisplay, b.NameDisplay));
						foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(item);
							((Panel)Stack).Children.Add((UIElement)(object)ModDownloadLib.OptiFineDownloadListItem((ModDownload.DlOptiFineListEntry)objectValue, ModDownloadLib.OptiFineSave_Click, IsSaveOnly: true));
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
			ModBase.Log(ex2, "可视化 OptiFine 版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnWeb_Click(object sender, EventArgs e)
	{
		ModBase.OpenWebsite("https://www.optifine.net/");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagedownload/pagedownloadoptifine.xaml", (UriKind)2);
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
