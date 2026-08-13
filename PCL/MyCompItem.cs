using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class MyCompItem : Grid, IComponentConnector
{
	public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

	public int Uuid;

	[CompilerGenerated]
	private ClickEventHandler ClickEvent;

	private bool IsMouseDown;

	private Border _RectBack;

	private string StateLast;

	[CompilerGenerated]
	[AccessedThroughProperty("LabInfo")]
	private TextBlock _LabInfo;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnDelete")]
	private MyIconButton _BtnDelete;

	private bool _contentLoaded;

	public string Logo
	{
		get
		{
			return PathLogo.Source;
		}
		set
		{
			PathLogo.Source = value;
		}
	}

	public string Title
	{
		get
		{
			return LabTitle.Text;
		}
		set
		{
			if (Operators.CompareString(LabTitle.Text, value, false) != 0)
			{
				LabTitle.Text = value;
			}
		}
	}

	public string SubTitle
	{
		get
		{
			TextBlock labTitleRaw = LabTitleRaw;
			return ((labTitleRaw != null) ? labTitleRaw.Text : null) ?? "";
		}
		set
		{
			if (Operators.CompareString(LabTitleRaw.Text, value, false) != 0)
			{
				LabTitleRaw.Text = value;
				((UIElement)LabTitleRaw).Visibility = (Visibility)((Operators.CompareString(value, "", false) == 0) ? 2 : 0);
			}
		}
	}

	public string Description
	{
		get
		{
			return LabInfo.Text;
		}
		set
		{
			if (Operators.CompareString(LabInfo.Text, value, false) != 0)
			{
				LabInfo.Text = value;
			}
		}
	}

	public List<string> Tags
	{
		set
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Expected O, but got Unknown
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Expected O, but got Unknown
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Expected O, but got Unknown
			((Panel)PanTags).Children.Clear();
			((UIElement)PanTags).Visibility = (Visibility)((!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)value)) ? 2 : 0);
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = value.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					Border val = new Border
					{
						Background = (Brush)new SolidColorBrush(Color.FromArgb((byte)17, (byte)0, (byte)0, (byte)0)),
						Padding = new Thickness(3.0, 1.0, 3.0, 1.0),
						CornerRadius = new CornerRadius(3.0),
						Margin = new Thickness(0.0, 0.0, 3.0, 0.0),
						SnapsToDevicePixels = true,
						UseLayoutRounding = false
					};
					TextBlock child = new TextBlock
					{
						Text = current,
						Foreground = (Brush)new SolidColorBrush(Color.FromRgb((byte)134, (byte)134, (byte)134)),
						FontSize = 11.0
					};
					((Decorator)val).Child = (UIElement)(object)child;
					((Panel)PanTags).Children.Add((UIElement)(object)val);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
	}

	public bool ShowFavoriteBtn
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Invalid comparison between Unknown and I4
			return (int)((UIElement)PanButtons).Visibility == 0;
		}
		set
		{
			((UIElement)PanButtons).Visibility = (Visibility)((!value) ? 2 : 0);
		}
	}

	public Border RectBack
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			if (_RectBack == null)
			{
				Border val = new Border
				{
					Name = "RectBack",
					CornerRadius = new CornerRadius(3.0),
					RenderTransform = (Transform)new ScaleTransform(0.8, 0.8),
					RenderTransformOrigin = new Point(0.5, 0.5),
					BorderThickness = new Thickness(ModBase.GetWPFSize(1.0)),
					SnapsToDevicePixels = true,
					IsHitTestVisible = false,
					Opacity = 0.0
				};
				((FrameworkElement)val).SetResourceReference(Border.BackgroundProperty, (object)"ColorBrush7");
				((FrameworkElement)val).SetResourceReference(Border.BorderBrushProperty, (object)"ColorBrush6");
				Grid.SetColumnSpan((UIElement)(object)val, 999);
				Grid.SetRowSpan((UIElement)(object)val, 999);
				((Panel)this).Children.Insert(0, (UIElement)(object)val);
				_RectBack = val;
			}
			return _RectBack;
		}
	}

	[field: CompilerGenerated]
	public bool CanInteraction
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual MyCompItem PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PathLogo")]
	internal virtual MyImage PathLogo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabTitle")]
	internal virtual TextBlock LabTitle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabTitleRaw")]
	internal virtual TextBlock LabTitleRaw
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanTags")]
	internal virtual StackPanel PanTags
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual TextBlock LabInfo
	{
		[CompilerGenerated]
		get
		{
			return _LabInfo;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseEventHandler val = new MouseEventHandler(LabInfo_MouseEnter);
			TextBlock labInfo = _LabInfo;
			if (labInfo != null)
			{
				((UIElement)labInfo).MouseEnter -= val;
			}
			_LabInfo = value;
			labInfo = _LabInfo;
			if (labInfo != null)
			{
				((UIElement)labInfo).MouseEnter += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ToolTipInfo")]
	internal virtual ToolTip ToolTipInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnVersion1")]
	internal virtual ColumnDefinition ColumnVersion1
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnVersion2")]
	internal virtual ColumnDefinition ColumnVersion2
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnVersion3")]
	internal virtual ColumnDefinition ColumnVersion3
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnTime1")]
	internal virtual ColumnDefinition ColumnTime1
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnTime2")]
	internal virtual ColumnDefinition ColumnTime2
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnTime3")]
	internal virtual ColumnDefinition ColumnTime3
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PathVersion")]
	internal virtual Path PathVersion
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabVersion")]
	internal virtual TextBlock LabVersion
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PathDownload")]
	internal virtual Path PathDownload
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabDownload")]
	internal virtual TextBlock LabDownload
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PathTime")]
	internal virtual Path PathTime
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabTime")]
	internal virtual TextBlock LabTime
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PathSource")]
	internal virtual Path PathSource
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
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
	[field: AccessedThroughProperty("PanButtons")]
	internal virtual StackPanel PanButtons
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconButton BtnDelete
	{
		[CompilerGenerated]
		get
		{
			return _BtnDelete;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconButton.ClickEventHandler obj = BtnDelete_Click;
			MyIconButton btnDelete = _BtnDelete;
			if (btnDelete != null)
			{
				btnDelete.Click -= obj;
			}
			_BtnDelete = value;
			btnDelete = _BtnDelete;
			if (btnDelete != null)
			{
				btnDelete.Click += obj;
			}
		}
	}

	public event ClickEventHandler Click
	{
		[CompilerGenerated]
		add
		{
			ClickEventHandler clickEventHandler = ClickEvent;
			ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				ClickEventHandler clickEventHandler3 = (ClickEventHandler)System.Delegate.Combine((System.Delegate)clickEventHandler2, (System.Delegate)value);
				clickEventHandler = Interlocked.CompareExchange<ClickEventHandler>(ref ClickEvent, clickEventHandler3, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ClickEventHandler clickEventHandler = ClickEvent;
			ClickEventHandler clickEventHandler2;
			do
			{
				clickEventHandler2 = clickEventHandler;
				ClickEventHandler clickEventHandler3 = (ClickEventHandler)System.Delegate.Remove((System.Delegate)clickEventHandler2, (System.Delegate)value);
				clickEventHandler = Interlocked.CompareExchange<ClickEventHandler>(ref ClickEvent, clickEventHandler3, clickEventHandler2);
			}
			while (clickEventHandler != clickEventHandler2);
		}
	}

	public MyCompItem()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		Click += [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
		{
			MyCompItem_Click((MyCompItem)a0, (EventArgs)(object)a1);
		};
		((UIElement)this).PreviewMouseLeftButtonUp += new MouseButtonEventHandler(Button_MouseUp);
		((UIElement)this).PreviewMouseLeftButtonDown += new MouseButtonEventHandler(Button_MouseDown);
		((UIElement)this).MouseLeave += new MouseEventHandler(Button_MouseLeave);
		((UIElement)this).PreviewMouseLeftButtonUp += new MouseButtonEventHandler(Button_MouseLeave);
		((UIElement)this).MouseEnter += new MouseEventHandler(RefreshColor);
		((UIElement)this).MouseLeave += new MouseEventHandler(RefreshColor);
		((UIElement)this).MouseLeftButtonDown += new MouseButtonEventHandler(RefreshColor);
		((UIElement)this).MouseLeftButtonUp += new MouseButtonEventHandler(RefreshColor);
		Uuid = ModBase.GetUuid();
		IsMouseDown = false;
		_RectBack = null;
		CanInteraction = true;
		InitializeComponent();
	}

	private void LabInfo_MouseEnter(object sender, MouseEventArgs e)
	{
		if (IsTextTrimmed(LabInfo))
		{
			((ContentControl)ToolTipInfo).Content = LabInfo.Text;
			((FrameworkElement)ToolTipInfo).Width = ((FrameworkElement)LabInfo).ActualWidth + 25.0;
			((FrameworkElement)LabInfo).ToolTip = ToolTipInfo;
		}
		else
		{
			((FrameworkElement)LabInfo).ToolTip = null;
		}
	}

	private bool IsTextTrimmed(TextBlock textBlock)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		Typeface val = new Typeface(textBlock.FontFamily, textBlock.FontStyle, textBlock.FontWeight, textBlock.FontStretch);
		return new FormattedText(textBlock.Text, Thread.CurrentThread.CurrentCulture, ((FrameworkElement)textBlock).FlowDirection, val, textBlock.FontSize, textBlock.Foreground, (double)ModBase.DPI).Width > ((FrameworkElement)textBlock).ActualWidth;
	}

	public void RefreshFavoriteStatus()
	{
		if (((FrameworkElement)this).Tag is ModComp.CompProject)
		{
			ModComp.CompProject compProject = (ModComp.CompProject)((FrameworkElement)this).Tag;
			ShowFavoriteBtn = ModComp.CompFavorites.IsFavourite(compProject.Id);
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected O, but got Unknown
		//IL_0045: Expected O, but got Unknown
		if (((UIElement)PanButtons).Opacity > 0.0 && ((FrameworkElement)this).Tag is ModComp.CompProject)
		{
			ModComp.CompFavorites.ShowMenu((ModComp.CompProject)((FrameworkElement)this).Tag, (UIElement)sender, (Action)([SpecialName] [CompilerGenerated] () =>
			{
				RefreshFavoriteStatus();
			}));
		}
	}

	private void MyCompItem_Click(MyCompItem sender, EventArgs e)
	{
		if (QuickDownloadHack.IsQuickDownload())
		{
			QuickDownloadHack.QuickDownload(sender);
			return;
		}
		List<string> val = new List<string>();
		if (ModMain.FrmMain.PageCurrent.Page == FormMain.PageType.CompDetail)
		{
			foreach (MyCard child in ((Panel)ModMain.FrmDownloadCompDetail.PanResults).Children)
			{
				if (Operators.CompareString(child.Title, "", false) != 0 && !child.IsSwapped)
				{
					val.Add(child.Title);
				}
			}
			ModBase.Log("[Comp] 记录当前已展开的卡片：" + string.Join("、", (System.Collections.Generic.IEnumerable<string>)val));
			NewLateBinding.LateIndexSet(ModMain.FrmMain.PageCurrent.Additional, new object[] { 1, val }, (string[])null);
		}
		string text = null;
		ModComp.CompLoaderType compLoaderType = ModComp.CompLoaderType.Any;
		ModComp.CompType compType = default(ModComp.CompType);
		if (ModMain.FrmMain.PageCurrent.Page == FormMain.PageType.Download)
		{
			if (ModMain.FrmMain.PageCurrentSub == FormMain.PageSubType.DownloadCompFavorites)
			{
				text = "";
				compLoaderType = ModComp.CompLoaderType.Any;
			}
			else
			{
				switch (ModMain.FrmMain.PageCurrentSub)
				{
				case FormMain.PageSubType.DownloadMod:
					compType = ModComp.CompType.Mod;
					text = ModMain.FrmDownloadMod.Content.Loader.Input.GameVersion;
					compLoaderType = ModMain.FrmDownloadMod.Content.Loader.Input.ModLoader;
					break;
				case FormMain.PageSubType.DownloadPack:
					compType = ModComp.CompType.ModPack;
					text = ModMain.FrmDownloadPack.Content.Loader.Input.GameVersion;
					break;
				case FormMain.PageSubType.DownloadDataPack:
					compType = ModComp.CompType.DataPack;
					text = ModMain.FrmDownloadDataPack.Content.Loader.Input.GameVersion;
					break;
				case FormMain.PageSubType.DownloadResourcePack:
					compType = ModComp.CompType.ResourcePack;
					text = ModMain.FrmDownloadResourcePack.Content.Loader.Input.GameVersion;
					break;
				case FormMain.PageSubType.DownloadShader:
					compType = ModComp.CompType.Shader;
					text = ModMain.FrmDownloadShader.Content.Loader.Input.GameVersion;
					break;
				case FormMain.PageSubType.DownloadWorld:
					compType = ModComp.CompType.World;
					text = ModMain.FrmDownloadWorld.Content.Loader.Input.GameVersion;
					break;
				}
			}
		}
		else if (ModMain.FrmMain.PageCurrent.Page == FormMain.PageType.InstanceSetup)
		{
			compType = ModComp.CompType.ModPack;
		}
		else
		{
			compType = ModComp.CompType.Any;
			text = Conversions.ToString(NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[] { 2 }, (string[])null));
			compLoaderType = (ModComp.CompLoaderType)Conversions.ToInteger(NewLateBinding.LateIndexGet(ModMain.FrmMain.PageCurrent.Additional, new object[] { 3 }, (string[])null));
		}
		ModMain.FrmMain.PageChange(new FormMain.PageStackData
		{
			Page = FormMain.PageType.CompDetail,
			Additional = new object[5]
			{
				((FrameworkElement)sender).Tag,
				new List<string>(),
				text,
				compLoaderType,
				compType
			}
		});
	}

	private void Button_MouseUp(object sender, MouseButtonEventArgs e)
	{
		if (IsMouseDown)
		{
			ClickEvent?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	private void Button_MouseDown(object sender, MouseButtonEventArgs e)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		if (!CanInteraction)
		{
			return;
		}
		Point position = ((MouseEventArgs)e).GetPosition((IInputElement)(object)this);
		bool flag = false;
		if ((int)((UIElement)PanButtons).Visibility == 0)
		{
			Rect val = default(Rect);
			val = new(((UIElement)BtnDelete).TranslatePoint(new Point(0.0, 0.0), (UIElement)(object)this), ((UIElement)BtnDelete).RenderSize);
			flag = val.Contains(position);
		}
		if (!flag)
		{
			bool flag2 = false;
			if ((int)((UIElement)LabInfo).Visibility == 0)
			{
				Rect val2 = default(Rect);
				val2 = new(((UIElement)LabInfo).TranslatePoint(new Point(0.0, 0.0), (UIElement)(object)this), ((UIElement)LabInfo).RenderSize);
				flag2 = val2.Contains(position);
			}
			if (((UIElement)this).IsMouseDirectlyOver || flag2)
			{
				IsMouseDown = true;
			}
		}
	}

	private void Button_MouseLeave(object sender, object e)
	{
		IsMouseDown = false;
	}

	public void RefreshColor(object sender, EventArgs e)
	{
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		if (!CanInteraction)
		{
			return;
		}
		string text;
		int num;
		if (((UIElement)this).IsMouseOver)
		{
			if (IsMouseDown)
			{
				text = "MouseDown";
				num = 120;
			}
			else
			{
				text = "MouseOver";
				num = 120;
			}
		}
		else
		{
			text = "Idle";
			num = 180;
		}
		if (Operators.CompareString(StateLast, text, false) == 0)
		{
			return;
		}
		StateLast = text;
		checked
		{
			if (((FrameworkElement)this).IsLoaded && ModAnimation.AniControlEnabled == 0)
			{
				List<ModAnimation.AniData> val = new List<ModAnimation.AniData>();
				if (((UIElement)this).IsMouseOver)
				{
					if (PanButtons != null && ShowFavoriteBtn)
					{
						val.Add(ModAnimation.AaOpacity(PanButtons, 1.0 - ((UIElement)PanButtons).Opacity, (int)Math.Round((double)num * 0.35), (int)Math.Round((double)num * 0.15)));
					}
					val.AddRange((System.Collections.Generic.IEnumerable<ModAnimation.AniData>)new ModAnimation.AniData[2]
					{
						ModAnimation.AaColor((FrameworkElement)(object)RectBack, Border.BackgroundProperty, IsMouseDown ? "ColorBrush6" : "ColorBrushBg1", num),
						ModAnimation.AaOpacity(RectBack, 1.0 - ((UIElement)RectBack).Opacity, num, 0, new ModAnimation.AniEaseOutFluent())
					});
					if (IsMouseDown)
					{
						val.Add(ModAnimation.AaScaleTransform(RectBack, 0.996 - ((ScaleTransform)((UIElement)RectBack).RenderTransform).ScaleX, (int)Math.Round((double)num * 1.2), 0, new ModAnimation.AniEaseOutFluent()));
					}
					else
					{
						val.Add(ModAnimation.AaScaleTransform(RectBack, 1.0 - ((ScaleTransform)((UIElement)RectBack).RenderTransform).ScaleX, (int)Math.Round((double)num * 1.2), 0, new ModAnimation.AniEaseOutFluent()));
					}
				}
				else
				{
					if (PanButtons != null && ShowFavoriteBtn)
					{
						val.Add(ModAnimation.AaOpacity(PanButtons, 0.0 - ((UIElement)PanButtons).Opacity, (int)Math.Round((double)num * 0.4)));
					}
					val.AddRange((System.Collections.Generic.IEnumerable<ModAnimation.AniData>)new ModAnimation.AniData[4]
					{
						ModAnimation.AaOpacity(RectBack, 0.0 - ((UIElement)RectBack).Opacity, num),
						ModAnimation.AaColor((FrameworkElement)(object)RectBack, Border.BackgroundProperty, IsMouseDown ? "ColorBrush6" : "ColorBrush7", num),
						ModAnimation.AaScaleTransform(RectBack, 0.996 - ((ScaleTransform)((UIElement)RectBack).RenderTransform).ScaleX, num, 0, new ModAnimation.AniEaseOutFluent()),
						ModAnimation.AaScaleTransform(RectBack, -0.196, 1, 0, null, After: true)
					});
				}
				ModAnimation.AniStart((System.Collections.IList)val, "CompItem Color " + Conversions.ToString(Uuid));
			}
			else
			{
				ModAnimation.AniStop("CompItem Color " + Conversions.ToString(Uuid));
				if (_RectBack != null)
				{
					((UIElement)RectBack).Opacity = 0.0;
				}
				if (PanButtons != null)
				{
					((UIElement)PanButtons).Opacity = 0.0;
				}
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagedownload/comp/mycompitem.xaml", (UriKind)2);
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
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
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
		switch (connectionId)
		{
		case 1:
			PanBack = (MyCompItem)target;
			break;
		case 2:
			PathLogo = (MyImage)target;
			break;
		case 3:
			LabTitle = (TextBlock)target;
			break;
		case 4:
			LabTitleRaw = (TextBlock)target;
			break;
		case 5:
			PanTags = (StackPanel)target;
			break;
		case 6:
			LabInfo = (TextBlock)target;
			break;
		case 7:
			ToolTipInfo = (ToolTip)target;
			break;
		case 8:
			ColumnVersion1 = (ColumnDefinition)target;
			break;
		case 9:
			ColumnVersion2 = (ColumnDefinition)target;
			break;
		case 10:
			ColumnVersion3 = (ColumnDefinition)target;
			break;
		case 11:
			ColumnTime1 = (ColumnDefinition)target;
			break;
		case 12:
			ColumnTime2 = (ColumnDefinition)target;
			break;
		case 13:
			ColumnTime3 = (ColumnDefinition)target;
			break;
		case 14:
			PathVersion = (Path)target;
			break;
		case 15:
			LabVersion = (TextBlock)target;
			break;
		case 16:
			PathDownload = (Path)target;
			break;
		case 17:
			LabDownload = (TextBlock)target;
			break;
		case 18:
			PathTime = (Path)target;
			break;
		case 19:
			LabTime = (TextBlock)target;
			break;
		case 20:
			PathSource = (Path)target;
			break;
		case 21:
			LabSource = (TextBlock)target;
			break;
		case 22:
			PanButtons = (StackPanel)target;
			break;
		case 23:
			BtnDelete = (MyIconButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
