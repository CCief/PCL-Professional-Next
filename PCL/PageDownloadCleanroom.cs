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
public class PageDownloadCleanroom : MyPageRight, IComponentConnector
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

	public PageDownloadCleanroom()
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
		PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanMain, (FrameworkElement)(object)CardTip, ModDownload.DlCleanroomListLoader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
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
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		try
		{
			Dictionary<string, List<ModDownload.DlCleanroomListEntry>> val = Enumerable.ToDictionary<IGrouping<string, ModDownload.DlCleanroomListEntry>, string, List<ModDownload.DlCleanroomListEntry>>((System.Collections.Generic.IEnumerable<IGrouping<string, ModDownload.DlCleanroomListEntry>>)Enumerable.OrderByDescending<IGrouping<string, ModDownload.DlCleanroomListEntry>, string>(Enumerable.GroupBy<ModDownload.DlCleanroomListEntry, string>((System.Collections.Generic.IEnumerable<ModDownload.DlCleanroomListEntry>)ModDownload.DlCleanroomListLoader.Output.Value, (Func<ModDownload.DlCleanroomListEntry, string>)([SpecialName] (ModDownload.DlCleanroomListEntry d) => d.Inherit)), (Func<IGrouping<string, ModDownload.DlCleanroomListEntry>, string>)([SpecialName] (IGrouping<string, ModDownload.DlCleanroomListEntry> g) => g.Key)), (Func<IGrouping<string, ModDownload.DlCleanroomListEntry>, string>)([SpecialName] (IGrouping<string, ModDownload.DlCleanroomListEntry> g) => g.Key), (Func<IGrouping<string, ModDownload.DlCleanroomListEntry>, List<ModDownload.DlCleanroomListEntry>>)([SpecialName] (IGrouping<string, ModDownload.DlCleanroomListEntry> g) => Enumerable.ToList<ModDownload.DlCleanroomListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlCleanroomListEntry>)g)));
			((Panel)PanMain).Children.Clear();
			System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<ModDownload.DlCleanroomListEntry>>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<ModDownload.DlCleanroomListEntry>>>);
			try
			{
				enumerator = val.GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, List<ModDownload.DlCleanroomListEntry>> current = enumerator.Current;
					if (!Enumerable.Any<ModDownload.DlCleanroomListEntry>((System.Collections.Generic.IEnumerable<ModDownload.DlCleanroomListEntry>)current.Value))
					{
						continue;
					}
					MyCard obj = new MyCard
					{
						Title = current.Key + " (" + Conversions.ToString(current.Value.Count) + ")"
					};
					((FrameworkElement)obj).Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
					MyCard myCard = obj;
					StackPanel val2 = new StackPanel
					{
						Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
						VerticalAlignment = (VerticalAlignment)0,
						RenderTransform = (Transform)new TranslateTransform(0.0, 0.0),
						Tag = current.Value
					};
					((Panel)myCard).Children.Add((UIElement)(object)val2);
					myCard.SwapControl = val2;
					myCard.IsSwapped = true;
					myCard.InstallMethod = [SpecialName] (StackPanel Stack) =>
					{
						foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(item);
							((Panel)Stack).Children.Add((UIElement)(object)ModDownloadLib.CleanroomDownloadListItem((ModDownload.DlCleanroomListEntry)objectValue, ModDownloadLib.CleanroomSave_Click, IsSaveOnly: true));
						}
					};
					((Panel)PanMain).Children.Add((UIElement)(object)myCard);
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
			ModBase.Log(ex2, "可视化 Cleanroom 版本列表出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnWeb_Click(object sender, EventArgs e)
	{
		ModBase.OpenWebsite("https://cleanroommc.com/zh/");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagedownload/pagedownloadcleanroom.xaml", (UriKind)2);
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
