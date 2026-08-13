using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageLogLeft : MyPageLeft, IComponentConnector
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__9_002D0
	{
		public ModWatcher.LogOutputEventArgs _0024VB_0024Local_e;

		public PageLogLeft _0024VB_0024Me;

		public _Closure_0024__9_002D0(_Closure_0024__9_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_e = arg0._0024VB_0024Local_e;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__9_002D1
	{
		public Thickness _0024VB_0024Local_Margin;

		public int _0024VB_0024Local_Uuid;

		public _Closure_0024__9_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__9_002D1(_Closure_0024__9_002D1 arg0)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			if (arg0 != null)
			{
				_0024VB_0024Local_Margin = arg0._0024VB_0024Local_Margin;
				_0024VB_0024Local_Uuid = arg0._0024VB_0024Local_Uuid;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Expected O, but got Unknown
			Paragraph val = new Paragraph((Inline)new Run(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_e.LogText))
			{
				Foreground = (Brush)(object)_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_e.Color,
				Margin = _0024VB_0024Local_Margin
			};
			((TextElementCollection<Block>)(object)_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.FlowDocuments[_0024VB_0024Local_Uuid].Blocks).Add((Block)(object)val);
			ulong num = Conversions.ToULong(ModBase.Setup.Get("SystemMaxLog"));
			switch (num)
			{
			case 0uL:
			case 1uL:
			case 2uL:
			case 3uL:
			case 4uL:
			case 5uL:
				num = Convert.ToUInt64(decimal.Add(decimal.Multiply(new decimal(num), 10m), 50m));
				break;
			case 6uL:
			case 7uL:
			case 8uL:
			case 9uL:
			case 10uL:
			case 11uL:
			case 12uL:
			case 13uL:
				num = Convert.ToUInt64(decimal.Subtract(decimal.Multiply(new decimal(num), 50m), 150m));
				break;
			case 14uL:
			case 15uL:
			case 16uL:
			case 17uL:
			case 18uL:
			case 19uL:
			case 20uL:
			case 21uL:
			case 22uL:
			case 23uL:
			case 24uL:
			case 25uL:
			case 26uL:
			case 27uL:
			case 28uL:
				num = Convert.ToUInt64(decimal.Subtract(decimal.Multiply(new decimal(num), 100m), 800m));
				break;
			default:
				num = 18446744073709551615uL;
				break;
			}
			while (decimal.Compare(new decimal(((TextElementCollection<Block>)(object)_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.FlowDocuments[_0024VB_0024Local_Uuid].Blocks).Count), new decimal(num)) > 0)
			{
				((TextElementCollection<Block>)(object)_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.FlowDocuments[_0024VB_0024Local_Uuid].Blocks).Remove(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.FlowDocuments[_0024VB_0024Local_Uuid].Blocks.FirstBlock);
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__R8_002D0
	{
		public PageLogLeft _0024VB_0024NonLocal_2;

		public _Closure_0024__R8_002D0(_Closure_0024__R8_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024NonLocal_2 = arg0._0024VB_0024NonLocal_2;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R2(object a0, EventArgs a1)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			_0024VB_0024NonLocal_2.Remove_Click(RuntimeHelpers.GetObjectValue(a0), (RoutedEventArgs)a1);
		}
	}

	public List<KeyValuePair<int, ModWatcher.Watcher>> ShownLogs;

	public Dictionary<int, FlowDocument> FlowDocuments;

	public int CurrentUuid;

	public ModWatcher.Watcher CurrentLog;

	public int IsLoading;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanList")]
	internal virtual StackPanel PanList
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageLogLeft()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageLogLeft_Loaded);
		((FrameworkElement)this).Unloaded += new RoutedEventHandler(PageLogLeft_Unloaded);
		ShownLogs = new List<KeyValuePair<int, ModWatcher.Watcher>>();
		FlowDocuments = new Dictionary<int, FlowDocument>();
		IsLoading = 0;
		InitializeComponent();
	}

	private void PageLogLeft_Loaded(object sender, RoutedEventArgs e)
	{
		Reload();
		ModMain.FrmMain.BtnExtraLog.ShowRefresh();
	}

	private void PageLogLeft_Unloaded(object sender, RoutedEventArgs e)
	{
		ModMain.FrmMain.BtnExtraLog.ShowRefresh();
	}

	private void Reload()
	{
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (ShownLogs.Count == 0)
			{
				ModMain.FrmMain.PageChange((FormMain.PageType)ModMain.FrmMain.PageCurrentSub);
				return;
			}
			checked
			{
				IsLoading++;
				((Panel)ModMain.FrmLogLeft.PanList).Children.Clear();
				((Panel)ModMain.FrmLogLeft.PanList).Children.Add((UIElement)new TextBlock
				{
					Text = "测试实例列表",
					Margin = new Thickness(13.0, 18.0, 5.0, 4.0),
					Opacity = 0.6,
					FontSize = 12.0
				});
				System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int, ModWatcher.Watcher>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int, ModWatcher.Watcher>>);
				try
				{
					enumerator = ShownLogs.GetEnumerator();
					_Closure_0024__R8_002D0 closure_0024__R8_002D = default(_Closure_0024__R8_002D0);
					while (enumerator.MoveNext())
					{
						KeyValuePair<int, ModWatcher.Watcher> current = enumerator.Current;
						int key = current.Key;
						ModMinecraft.McInstance version = current.Value.Version;
						Process gameProcess = current.Value.GameProcess;
						MyListItem obj = new MyListItem
						{
							IsScaleAnimationEnabled = false,
							Type = MyListItem.CheckType.RadioBox,
							MinPaddingRight = 30,
							Title = version.Name,
							Info = $"{version.Version} - {gameProcess.StartTime:HH:mm:ss}"
						};
						((FrameworkElement)obj).Height = 40.0;
						((FrameworkElement)obj).Tag = key;
						MyListItem myListItem = obj;
						myListItem.Changed += ModMain.FrmLogLeft.Version_Change;
						MyIconButton myIconButton = new MyIconButton
						{
							Logo = "M520.192 0C408.43 0 317.44 82.87 313.563 186.734H52.736c-29.038 0-52.663 21.943-52.663 49.079s23.625 49.152 52.663 49.152h58.075v550.473c0 103.35 75.118 187.757 167.717 187.757h472.43c92.599 0 167.716-83.894 167.716-187.757V285.477h52.59c29.038 0 52.59-21.943 52.663-49.08-0.073-27.135-23.625-49.151-52.663-49.151H726.235C723.237 83.017 631.955 0 520.192 0zM404.846 177.957c3.803-50.03 50.176-89.015 107.447-89.015 57.197 0 103.57 38.985 106.788 89.015H404.92zM284.379 933.669c-33.353 0-69.997-39.351-69.997-95.525v-549.01H833.39v549.522c0 56.247-36.645 95.525-69.998 95.525H284.379v-0.512z M357.23 800.695a48.274 48.274 0 0 0 47.616-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.69 49.006V751.69c0 27.282 20.846 49.006 47.617 49.006z m166.62 0a48.274 48.274 0 0 0 47.688-49.006V471.7a48.274 48.274 0 0 0-47.689-49.08 48.274 48.274 0 0 0-47.543 49.006V751.69c0 27.282 21.431 49.006 47.543 49.006z m142.92 0a48.274 48.274 0 0 0 47.543-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.616 49.006V751.69c0 27.282 20.773 49.006 47.543 49.006z",
							LogoScale = 1.1
						};
						closure_0024__R8_002D = new _Closure_0024__R8_002D0(closure_0024__R8_002D);
						closure_0024__R8_002D._0024VB_0024NonLocal_2 = ModMain.FrmLogLeft;
						myIconButton.Click += closure_0024__R8_002D._Lambda_0024__R2;
						myListItem.Buttons = new MyIconButton[] { myIconButton };
						if (key == CurrentUuid)
						{
							myListItem.Checked = true;
						}
						((Panel)ModMain.FrmLogLeft.PanList).Children.Add((UIElement)(object)myListItem);
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("HintMaxLog"))))
				{
					ModBase.Setup.Set("HintMaxLog", true);
					ModMain.Hint("实时日志默认只保留 500 行，你可以在 实时日志行数 设置中修改！");
				}
				IsLoading--;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "构建游戏实时日志 UI 出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void OnLogOutput(ModWatcher.Watcher sender, ModWatcher.LogOutputEventArgs e)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		_Closure_0024__9_002D0 arg = new _Closure_0024__9_002D0(null);
		arg._0024VB_0024Me = this;
		arg._0024VB_0024Local_e = e;
		System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int, ModWatcher.Watcher>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int, ModWatcher.Watcher>>);
		try
		{
			enumerator = ShownLogs.GetEnumerator();
			_Closure_0024__9_002D1 arg2 = default(_Closure_0024__9_002D1);
			while (enumerator.MoveNext())
			{
				KeyValuePair<int, ModWatcher.Watcher> current = enumerator.Current;
				if (current.Value.GameProcess.Id != sender.GameProcess.Id)
				{
					continue;
				}
				_Closure_0024__9_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__9_002D1(null);
				CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2 = arg;
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Uuid = current.Key;
				if (current.Value.GameProcess.HasExited)
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Margin = new Thickness(0.0, 12.0, 0.0, 0.0);
				}
				else
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Margin = new Thickness(0.0);
				}
				ModBase.RunInUi((Action)([SpecialName] () =>
				{
					//IL_0010: Unknown result type (might be due to invalid IL or missing references)
					//IL_001a: Expected O, but got Unknown
					//IL_0015: Unknown result type (might be due to invalid IL or missing references)
					//IL_001a: Unknown result type (might be due to invalid IL or missing references)
					//IL_0030: Unknown result type (might be due to invalid IL or missing references)
					//IL_0032: Unknown result type (might be due to invalid IL or missing references)
					//IL_003d: Expected O, but got Unknown
					Paragraph val = new Paragraph((Inline)new Run(CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_e.LogText))
					{
						Foreground = (Brush)(object)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_e.Color,
						Margin = CS_0024_003C_003E8__locals0._0024VB_0024Local_Margin
					};
					((TextElementCollection<Block>)(object)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.FlowDocuments[CS_0024_003C_003E8__locals0._0024VB_0024Local_Uuid].Blocks).Add((Block)(object)val);
					ulong num = Conversions.ToULong(ModBase.Setup.Get("SystemMaxLog"));
					switch (num)
					{
					case 0uL:
					case 1uL:
					case 2uL:
					case 3uL:
					case 4uL:
					case 5uL:
						num = Convert.ToUInt64(decimal.Add(decimal.Multiply(new decimal(num), 10m), 50m));
						break;
					case 6uL:
					case 7uL:
					case 8uL:
					case 9uL:
					case 10uL:
					case 11uL:
					case 12uL:
					case 13uL:
						num = Convert.ToUInt64(decimal.Subtract(decimal.Multiply(new decimal(num), 50m), 150m));
						break;
					case 14uL:
					case 15uL:
					case 16uL:
					case 17uL:
					case 18uL:
					case 19uL:
					case 20uL:
					case 21uL:
					case 22uL:
					case 23uL:
					case 24uL:
					case 25uL:
					case 26uL:
					case 27uL:
					case 28uL:
						num = Convert.ToUInt64(decimal.Subtract(decimal.Multiply(new decimal(num), 100m), 800m));
						break;
					default:
						num = 18446744073709551615uL;
						break;
					}
					while (decimal.Compare(new decimal(((TextElementCollection<Block>)(object)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.FlowDocuments[CS_0024_003C_003E8__locals0._0024VB_0024Local_Uuid].Blocks).Count), new decimal(num)) > 0)
					{
						((TextElementCollection<Block>)(object)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.FlowDocuments[CS_0024_003C_003E8__locals0._0024VB_0024Local_Uuid].Blocks).Remove(CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.FlowDocuments[CS_0024_003C_003E8__locals0._0024VB_0024Local_Uuid].Blocks.FirstBlock);
					}
				}));
				break;
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	public void Add(ModWatcher.Watcher watcher)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		int uuid = ModBase.GetUuid();
		ShownLogs.Add(new KeyValuePair<int, ModWatcher.Watcher>(uuid, watcher));
		watcher.LogOutput += OnLogOutput;
		ModBase.RunInUi((Action)([SpecialName] () =>
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Expected O, but got Unknown
			FlowDocuments.Add(uuid, new FlowDocument());
		}));
		SelectionChange(uuid);
		ModMain.FrmMain.BtnExtraLog.ShowRefresh();
	}

	public void SelectionChange(int Uuid)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (IsLoading > 0)
		{
			return;
		}
		if (Uuid <= 0)
		{
			CurrentUuid = -1;
			CurrentLog = null;
		}
		else
		{
			System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int, ModWatcher.Watcher>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<int, ModWatcher.Watcher>>);
			try
			{
				enumerator = ShownLogs.GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, ModWatcher.Watcher> current = enumerator.Current;
					if (current.Key == Uuid)
					{
						CurrentUuid = Uuid;
						CurrentLog = current.Value;
						break;
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			ModMain.FrmLogRight.Reload();
			Reload();
		}));
	}

	public void RemoveItem(int Uuid)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			int num = ShownLogs.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				KeyValuePair<int, ModWatcher.Watcher> val = ShownLogs[i];
				if (val.Key != Uuid)
				{
					continue;
				}
				ShownLogs.RemoveAt(i);
				if (CurrentUuid == val.Key)
				{
					if (ShownLogs.Count == 0)
					{
						SelectionChange(-1);
						break;
					}
					SelectionChange(ShownLogs[Enumerable.Max((System.Collections.Generic.IEnumerable<int>)new int[2]
					{
						Enumerable.Min((System.Collections.Generic.IEnumerable<int>)new int[2]
						{
							i,
							ShownLogs.Count - 1
						}),
						0
					})].Key);
				}
				else
				{
					ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
					{
						ModMain.FrmLogRight.Reload();
						Reload();
					}));
				}
				break;
			}
			ModMain.FrmMain.BtnExtraLog.ShowRefresh();
		}
	}

	public void Remove_Click(object sender, RoutedEventArgs e)
	{
		RemoveItem(Conversions.ToInteger(((FrameworkElement)(MyListItem)(object)((FrameworkElement)(MyIconButton)sender).Parent).Tag));
	}

	public void Version_Change(object sender, ModBase.RouteEventArgs e)
	{
		SelectionChange(Conversions.ToInteger(((FrameworkElement)(MyListItem)sender).Tag));
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelogleft.xaml", (UriKind)2);
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
		if (connectionId == 1)
		{
			PanList = (StackPanel)target;
		}
		else
		{
			_contentLoaded = true;
		}
	}
}
