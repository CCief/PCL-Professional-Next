using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace PCL;

[DesignerGenerated]
public class PageLinkJoin : MyPageRight, IComponentConnector
{
	private Process proxyProcess;

	private Timer logUpdateTimer;

	private int CurrentLocalPort;

	private string CurrentAddress;

	private string CurrentLogDir;

	private static Process SshProcess;

	private UdpClient udpClient;

	private Timer broadcastTimer;

	private bool isGameRunning;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnJoin")]
	private MyButton _BtnJoin;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnCopyAddress")]
	private MyButton _BtnCopyAddress;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnRefreshLog")]
	private MyButton _BtnRefreshLog;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnCopyLog")]
	private MyButton _BtnCopyLog;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnOpenLogFolder")]
	private MyButton _BtnOpenLogFolder;

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
	[field: AccessedThroughProperty("TextAddress")]
	internal virtual MyTextBox TextAddress
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnJoin
	{
		[CompilerGenerated]
		get
		{
			return _BtnJoin;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnJoin_Click;
			MyButton btnJoin = _BtnJoin;
			if (btnJoin != null)
			{
				btnJoin.Click -= obj;
			}
			_BtnJoin = value;
			btnJoin = _BtnJoin;
			if (btnJoin != null)
			{
				btnJoin.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnCopyAddress
	{
		[CompilerGenerated]
		get
		{
			return _BtnCopyAddress;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnCopyAddress_Click;
			MyButton btnCopyAddress = _BtnCopyAddress;
			if (btnCopyAddress != null)
			{
				btnCopyAddress.Click -= obj;
			}
			_BtnCopyAddress = value;
			btnCopyAddress = _BtnCopyAddress;
			if (btnCopyAddress != null)
			{
				btnCopyAddress.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnRefreshLog
	{
		[CompilerGenerated]
		get
		{
			return _BtnRefreshLog;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnRefreshLog_Click;
			MyButton btnRefreshLog = _BtnRefreshLog;
			if (btnRefreshLog != null)
			{
				btnRefreshLog.Click -= obj;
			}
			_BtnRefreshLog = value;
			btnRefreshLog = _BtnRefreshLog;
			if (btnRefreshLog != null)
			{
				btnRefreshLog.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnCopyLog
	{
		[CompilerGenerated]
		get
		{
			return _BtnCopyLog;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnCopyLog_Click;
			MyButton btnCopyLog = _BtnCopyLog;
			if (btnCopyLog != null)
			{
				btnCopyLog.Click -= obj;
			}
			_BtnCopyLog = value;
			btnCopyLog = _BtnCopyLog;
			if (btnCopyLog != null)
			{
				btnCopyLog.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnOpenLogFolder
	{
		[CompilerGenerated]
		get
		{
			return _BtnOpenLogFolder;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnOpenLogFolder_Click;
			MyButton btnOpenLogFolder = _BtnOpenLogFolder;
			if (btnOpenLogFolder != null)
			{
				btnOpenLogFolder.Click -= obj;
			}
			_BtnOpenLogFolder = value;
			btnOpenLogFolder = _BtnOpenLogFolder;
			if (btnOpenLogFolder != null)
			{
				btnOpenLogFolder.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextLog")]
	internal virtual TextBox TextLog
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageLinkJoin()
	{
		proxyProcess = null;
		logUpdateTimer = null;
		CurrentLocalPort = 0;
		CurrentAddress = "";
		CurrentLogDir = "";
		udpClient = null;
		broadcastTimer = null;
		isGameRunning = false;
		InitializeComponent();
	}

	private void BtnJoin_Click(object sender, RoutedEventArgs e)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected O, but got Unknown
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected O, but got Unknown
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Expected O, but got Unknown
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Expected O, but got Unknown
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Expected O, but got Unknown
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037f: Expected O, but got Unknown
		try
		{
			if (isGameRunning)
			{
				StopGame();
				return;
			}
			CurrentAddress = ((TextBox)TextAddress).Text.Trim();
			if (string.IsNullOrEmpty(CurrentAddress))
			{
				ModMain.MyMsgBox("请输入连接地址！");
				return;
			}
			Random val = new Random();
			CurrentLocalPort = val.Next(25000, 35000);
			int num = 25565;
			string text;
			if (CurrentAddress.Contains(":"))
			{
				string[] array = CurrentAddress.Split(':', (StringSplitOptions)0);
				text = array[0];
				if (array.Length <= 1 || !int.TryParse(array[1], out num))
				{
					num = 25565;
				}
			}
			else
			{
				text = CurrentAddress;
			}
			if (ModLink.ProxyPrecheck())
			{
				string text2 = Path.Combine(ModBase.ExePath, "PCL", "LinkProxy");
				Directory.CreateDirectory(text2);
				string text3 = Path.Combine(text2, "config.json");
				Dictionary<string, object> obj = new Dictionary<string, object>();
				obj.Add("Version", (object)"1.1");
				obj.Add("LocalAddress", (object)"::");
				obj.Add("LocalPort", (object)CurrentLocalPort);
				obj.Add("Address", (object)text);
				obj.Add("RemotePort", (object)num);
				obj.Add("MaxPlayer", (object)(-1));
				obj.Add("MotdPath", (object)"");
				obj.Add("DefaultEnableWhitelist", (object)false);
				obj.Add("WhiteBlcakListPath", (object)"./WhiteBlackList.json");
				obj.Add("AllowInput", (object)false);
				obj.Add("ShowOnlinePlayerNumber", (object)true);
				obj.Add("LogDir", (object)"./logs");
				obj.Add("ShowLogLevel", (object)0);
				obj.Add("SaveLogLevel", (object)0);
				obj.Add("WebAPIEnable", (object)false);
				obj.Add("WebAPIAddress", (object)"127.0.0.1");
				obj.Add("WebAPIPort", (object)20220);
				obj.Add("WebAPIPassword", (object)"admin");
				Dictionary<string, object> value = obj;
				File.WriteAllText(text3, JsonConvert.SerializeObject(value, Formatting.Indented), (Encoding)new UTF8Encoding(false));
				((UIElement)TextAddress).IsEnabled = false;
				((UIElement)BtnCopyAddress).IsEnabled = false;
				BtnJoin.Text = "结束进程";
				StartUdpBroadcast();
				isGameRunning = true;
				Log($"开始连接，本地端口：{CurrentLocalPort}");
				Log($"连接地址：{CurrentAddress}");
				Log("正在发送UDP广播到 224.0.2.60:4445...");
				string proxyPath = ModLink.GetProxyPath();
				ProcessStartInfo val2 = new ProcessStartInfo();
				val2.FileName = proxyPath;
				val2.Arguments = "-c config.json";
				val2.WorkingDirectory = text2;
				val2.RedirectStandardOutput = true;
				val2.RedirectStandardError = true;
				val2.UseShellExecute = false;
				val2.CreateNoWindow = true;
				val2.StandardOutputEncoding = Encoding.UTF8;
				val2.StandardErrorEncoding = Encoding.UTF8;
				SshProcess = new Process();
				SshProcess.StartInfo = val2;
				SshProcess.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
				SshProcess.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
				SshProcess.EnableRaisingEvents = true;
				SshProcess.Exited += new EventHandler(OnSshExited);
				SshProcess.Start();
				SshProcess.BeginOutputReadLine();
				SshProcess.BeginErrorReadLine();
				Log($"代理进程已启动: {proxyPath} -c config.json");
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			Log("启动失败: " + ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private void OutputHandler(object sender, DataReceivedEventArgs e)
	{
		if (!string.IsNullOrEmpty(e.Data))
		{
			Log(e.Data);
		}
	}

	private void OnSshExited(object sender, EventArgs e)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		((DispatcherObject)this).Dispatcher.Invoke((Action)([SpecialName] [CompilerGenerated] () =>
		{
			if (SshProcess != null)
			{
				Log("SSH 进程已退出");
				StopGame();
			}
		}));
	}

	private void StopProxy()
	{
		try
		{
			if (proxyProcess != null && !proxyProcess.HasExited)
			{
				proxyProcess.Kill();
				((Component)proxyProcess).Dispose();
				proxyProcess = null;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void BtnCopyLog_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			ModMain.MyMsgBox("暂无日志内容可复制");
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModMain.MyMsgBox($"复制失败：{ex2.Message}", "错误");
			ProjectData.ClearProjectError();
		}
	}

	private void BtnRefreshLog_Click(object sender, RoutedEventArgs e)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		try
		{
			string latestLogPath = GetLatestLogPath();
			if (string.IsNullOrEmpty(latestLogPath))
			{
				TextLog.Text = "暂无日志文件";
				return;
			}
			FileStream val = new FileStream(latestLogPath, (FileMode)3, (FileAccess)1, (FileShare)3);
			string text;
			try
			{
				StreamReader val2 = new StreamReader((Stream)(object)val, (Encoding)new UTF8Encoding(false));
				try
				{
					text = val2.ReadToEnd();
				}
				finally
				{
					((System.IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
			TextLog.Text = text;
			((TextBoxBase)TextLog).ScrollToEnd();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModMain.MyMsgBox($"读取日志失败：{ex2.Message}", "错误");
			ProjectData.ClearProjectError();
		}
	}

	private void BtnOpenLogFolder_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			string text = ((string.IsNullOrEmpty(CurrentLogDir) || !Directory.Exists(CurrentLogDir)) ? Path.Combine(ModBase.ExePath, "PCL", "LinkProxy", "logs") : CurrentLogDir);
			Directory.CreateDirectory(text);
			Process.Start("explorer.exe", text);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModMain.MyMsgBox($"打开文件夹失败：{ex2.Message}", "错误");
			ProjectData.ClearProjectError();
		}
	}

	private void BtnCopyAddress_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			if (Clipboard.ContainsText())
			{
				string text = Clipboard.GetText().Trim();
				if (!string.IsNullOrEmpty(text))
				{
					((TextBox)TextAddress).Text = text;
				}
				else
				{
					ModMain.MyMsgBox("剪贴板内容为空！");
				}
			}
			else
			{
				ModMain.MyMsgBox("剪贴板中没有文本内容！");
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModMain.MyMsgBox($"粘贴失败：{ex2.Message}", "错误");
			ProjectData.ClearProjectError();
		}
	}

	private string GetLatestLogPath()
	{
		string text = ((string.IsNullOrEmpty(CurrentLogDir) || !Directory.Exists(CurrentLogDir)) ? Path.Combine(ModBase.ExePath, "PCL", "LinkProxy", "logs") : CurrentLogDir);
		Directory.CreateDirectory(text);
		string result = null;
		System.DateTime dateTime = System.DateTime.MinValue;
		string[] files = Directory.GetFiles(text);
		foreach (string text2 in files)
		{
			System.DateTime lastWriteTimeUtc = File.GetLastWriteTimeUtc(text2);
			if (System.DateTime.Compare(lastWriteTimeUtc, dateTime) > 0)
			{
				dateTime = lastWriteTimeUtc;
				result = text2;
			}
		}
		return result;
	}

	private void StartUdpBroadcast()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		try
		{
			udpClient = new UdpClient();
			udpClient.EnableBroadcast = true;
			broadcastTimer = new Timer(new TimerCallback(SendBroadcast), (object)null, 0, 2000);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			Log($"启动UDP广播失败：{ex2.Message}");
			ProjectData.ClearProjectError();
		}
	}

	private void SendBroadcast(object state)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		try
		{
			string text = $"[MOTD]PCL Pro-N - {CurrentAddress}[/MOTD][AD]{CurrentLocalPort}[/AD]";
			byte[] bytes = Encoding.UTF8.GetBytes(text);
			IPEndPoint val = new IPEndPoint(IPAddress.Parse("224.0.2.60"), 4445);
			udpClient.Send(bytes, bytes.Length, val);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	private void StopGame()
	{
		try
		{
			if (broadcastTimer != null)
			{
				broadcastTimer.Dispose();
				broadcastTimer = null;
			}
		}
		catch (System.Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		try
		{
			if (udpClient != null)
			{
				udpClient.Close();
				udpClient = null;
			}
		}
		catch (System.Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		try
		{
			if (SshProcess != null)
			{
				if (!SshProcess.HasExited)
				{
					SshProcess.Kill();
				}
				((Component)SshProcess).Dispose();
				SshProcess = null;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		try
		{
			((UIElement)TextAddress).IsEnabled = true;
			((UIElement)BtnCopyAddress).IsEnabled = true;
			BtnJoin.Text = "加入游戏";
			isGameRunning = false;
			Log("进程已结束");
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			Log($"停止失败：{ex4.Message}");
			ProjectData.ClearProjectError();
		}
	}

	private void Log(string text)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		((DispatcherObject)this).Dispatcher.Invoke((Action)([SpecialName] () =>
		{
			((TextBoxBase)TextLog).AppendText(text + Environment.NewLine);
			((TextBoxBase)TextLog).ScrollToEnd();
		}));
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelink/pagelinkjoin.xaml", (UriKind)2);
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
			TextAddress = (MyTextBox)target;
			break;
		case 4:
			BtnJoin = (MyButton)target;
			break;
		case 5:
			BtnCopyAddress = (MyButton)target;
			break;
		case 6:
			BtnRefreshLog = (MyButton)target;
			break;
		case 7:
			BtnCopyLog = (MyButton)target;
			break;
		case 8:
			BtnOpenLogFolder = (MyButton)target;
			break;
		case 9:
			TextLog = (TextBox)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
