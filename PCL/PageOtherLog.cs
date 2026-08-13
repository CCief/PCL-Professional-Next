using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.App;
using PCL.Core.Logging;
using PCL.Core.UI;
using PCL.Core.Utils;
using PCL.Core.Utils.Exts;

namespace PCL;

[DesignerGenerated]
public class PageOtherLog : MyPageRight, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Converter<string, string> _0024I5_002D0;

		public static MyListItem.ClickEventHandler _0024I6_002D1;

		public static Predicate<string> _0024I11_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal string _Lambda_0024__5_002D0(string item)
		{
			return Path.GetFullPath(item);
		}

		[SpecialName]
		internal void _Lambda_0024__6_002D1(object sender, MouseButtonEventArgs e)
		{
			Basics.OpenPath(Conversions.ToString(((FrameworkElement)(MyListItem)sender).Tag));
		}

		[SpecialName]
		internal bool _Lambda_0024__11_002D0(string s)
		{
			return s.IsMatch(RegexPatterns.LastPendingLogPath);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__6_002D0
	{
		public string _0024VB_0024Local_fullPath;

		public _Closure_0024__6_002D0(_Closure_0024__6_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_fullPath = arg0._0024VB_0024Local_fullPath;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(string log)
		{
			return log.Equals(_0024VB_0024Local_fullPath);
		}
	}

	private bool _contentLoaded;

	private static string LogDirectory => LogService.Logger.Configuration.StoreFolder;

	private static List<string> CurrentLogs => LogService.Logger.LogFiles.ConvertAll<string>((Converter<string, string>)([SpecialName] (string item) => Path.GetFullPath(item)));

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
	[field: AccessedThroughProperty("PanContent")]
	internal virtual MyCard PanContent
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

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

	public PageOtherLog()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageOtherLog_Loaded);
		InitializeComponent();
	}

	private void PageOtherLog_Loaded(object sender, RoutedEventArgs e)
	{
		((ScrollViewer)PanBack).ScrollToHome();
		LoadList();
		_ = ((FrameworkElement)this).IsLoaded;
	}

	public void LoadList()
	{
		((Panel)PanList).Children.Clear();
		List<string> currentLogs = CurrentLogs;
		string[] files = Directory.GetFiles(LogDirectory);
		checked
		{
			_Closure_0024__6_002D0 closure_0024__6_002D = default(_Closure_0024__6_002D0);
			System.DateTime dateTime = default(System.DateTime);
			foreach (string text in files)
			{
				closure_0024__6_002D = new _Closure_0024__6_002D0(closure_0024__6_002D);
				closure_0024__6_002D._0024VB_0024Local_fullPath = Path.GetFullPath(text);
				string text2 = Path.GetFileName(text);
				if (text2.StartsWith("Launch"))
				{
					text2 = text2.Substring(7, text2.Length - 11);
					if (System.DateTime.TryParseExact(text2, "yyyy-M-d-HHmmssfff", (IFormatProvider)(object)CultureInfo.InvariantCulture, (DateTimeStyles)0, out dateTime))
					{
						text2 = dateTime.ToString("yyyy 年 M 月 d 日 HH:mm:ss.fff");
					}
					if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)currentLogs, (Func<string, bool>)closure_0024__6_002D._Lambda_0024__0))
					{
						text2 += " (当前)";
					}
				}
				else if (text2.StartsWith("LastPending"))
				{
					text2 = text2.Substring(11, text2.Length - 15);
					text2 = ((text2.Length <= 1) ? "临时存储的未输出日志" : ("临时存储的日志 (" + text2.Substring(1) + ")"));
				}
				MyListItem obj = new MyListItem
				{
					Type = MyListItem.CheckType.Clickable,
					Title = text2,
					Info = closure_0024__6_002D._0024VB_0024Local_fullPath
				};
				((FrameworkElement)obj).Tag = closure_0024__6_002D._0024VB_0024Local_fullPath;
				MyListItem myListItem = obj;
				myListItem.Click += ((_Closure_0024__._0024I6_002D1 == null) ? (_Closure_0024__._0024I6_002D1 = [SpecialName] (object sender, MouseButtonEventArgs e) =>
				{
					Basics.OpenPath(Conversions.ToString(((FrameworkElement)(MyListItem)sender).Tag));
				}) : _Closure_0024__._0024I6_002D1);
				((Panel)PanList).Children.Add((UIElement)(object)myListItem);
			}
		}
	}

	private static void ExportLog(System.Collections.Generic.IEnumerable<string> sourceFiles)
	{
		string folderPath = Environment.GetFolderPath((System.Environment.SpecialFolder)0);
		string text = "PCL_CE_Logs_" + System.DateTime.Now.ToString("yyyyMMddHHmmss");
		string text2 = text + ".tmp";
		string fileName = text + ".zip";
		string text3 = SystemDialogs.SelectSaveFile("导出日志文件", fileName, "PCL Pro-N 日志压缩包|*.zip", folderPath);
		if (string.IsNullOrEmpty(text3))
		{
			return;
		}
		try
		{
			Directory.CreateDirectory(text2);
			if (File.Exists(text3))
			{
				File.Delete(text3);
			}
			ZipArchive val = ZipFile.Open(text3, (ZipArchiveMode)1);
			try
			{
				System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
				try
				{
					enumerator = sourceFiles.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						string current = enumerator.Current;
						string fileName2 = Path.GetFileName(current);
						string text4 = Path.Combine(text2, fileName2);
						File.Copy(current, text4);
						ZipFileExtensions.CreateEntryFromFile(val, text4, fileName2, (CompressionLevel)1);
						File.Delete(text4);
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
			ModMain.Hint("日志保存成功！", ModMain.HintType.Finish);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "日志保存失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
		finally
		{
			if (Directory.Exists(text2))
			{
				Directory.Delete(text2);
			}
		}
	}

	private void ButtonOpenDir_OnClick(object sender, MouseButtonEventArgs e)
	{
		Basics.OpenPath(LogDirectory);
	}

	private void ButtonClean_OnClick(object sender, MouseButtonEventArgs e)
	{
		if (ModMain.MyMsgBox("是否删除所有历史日志？", "清理历史日志", "确定", "取消", "", IsWarn: true) != 1)
		{
			return;
		}
		HashSet<string> val = new HashSet<string>((System.Collections.Generic.IEnumerable<string>)CurrentLogs);
		string[] files = Directory.GetFiles(LogDirectory);
		foreach (string text in files)
		{
			if (!val.Contains(text))
			{
				File.Delete(text);
			}
		}
		ModMain.Hint("清理日志文件成功！", ModMain.HintType.Finish);
		LoadList();
	}

	private void ButtonExportAll_OnClick(object sender, MouseButtonEventArgs e)
	{
		ExportLog(Directory.GetFiles(LogDirectory));
	}

	private void ButtonExport_OnClick(object sender, MouseButtonEventArgs e)
	{
		string[] array = System.Array.FindAll<string>(Directory.GetFiles(LogDirectory), (Predicate<string>)([SpecialName] (string s) => s.IsMatch(RegexPatterns.LastPendingLogPath)));
		ExportLog(Enumerable.Concat<string>((System.Collections.Generic.IEnumerable<string>)CurrentLogs, (System.Collections.Generic.IEnumerable<string>)array));
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageother/pageotherlog.xaml", (UriKind)2);
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
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanContent = (MyCard)target;
			break;
		case 3:
			PanList = (StackPanel)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
