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
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.Core.UI.Controls;

namespace PCL;

[DesignerGenerated]
public class MyMsgLogin : Grid, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static ThreadStart _0024I9_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__9_002D0()
		{
			if (!Enumerable.Any<ModMain.MyMsgBoxConverter>((System.Collections.Generic.IEnumerable<ModMain.MyMsgBoxConverter>)ModMain.WaitingMyMsgBox))
			{
				ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ModMain.FrmMain.PanMsgBackground, Border.BackgroundProperty, new ModBase.MyColor(0.0, 0.0, 0.0, 0.0) - ((Border)ModMain.FrmMain.PanMsgBackground).Background, 200, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)));
			}
		}
	}

	private JObject Data;

	private string UserCode;

	private string DeviceCode;

	private string Website;

	private string OAuthUrl;

	private readonly ModMain.MyMsgBoxConverter MyConverter;

	private readonly int Uuid;

	[CompilerGenerated]
	[AccessedThroughProperty("PanBorder")]
	private BlurBorder _PanBorder;

	[CompilerGenerated]
	[AccessedThroughProperty("LabTitle")]
	private TextBlock _LabTitle;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn1")]
	private MyButton _Btn1;

	[CompilerGenerated]
	[AccessedThroughProperty("Btn3")]
	private MyButton _Btn3;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TransformRotate")]
	internal virtual RotateTransform TransformRotate
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TransformPos")]
	internal virtual TranslateTransform TransformPos
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual BlurBorder PanBorder
	{
		[CompilerGenerated]
		get
		{
			return _PanBorder;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(Drag);
			BlurBorder panBorder = _PanBorder;
			if (panBorder != null)
			{
				((UIElement)panBorder).MouseLeftButtonDown -= val;
			}
			_PanBorder = value;
			panBorder = _PanBorder;
			if (panBorder != null)
			{
				((UIElement)panBorder).MouseLeftButtonDown += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("EffectShadow")]
	internal virtual DropShadowEffect EffectShadow
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanMain")]
	internal virtual Grid PanMain
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual TextBlock LabTitle
	{
		[CompilerGenerated]
		get
		{
			return _LabTitle;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(Drag);
			TextBlock labTitle = _LabTitle;
			if (labTitle != null)
			{
				((UIElement)labTitle).MouseLeftButtonDown -= val;
			}
			_LabTitle = value;
			labTitle = _LabTitle;
			if (labTitle != null)
			{
				((UIElement)labTitle).MouseLeftButtonDown += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ShapeLine")]
	internal virtual Rectangle ShapeLine
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanCaption")]
	internal virtual MyScrollViewer PanCaption
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabCaption")]
	internal virtual TextBlock LabCaption
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBtn")]
	internal virtual StackPanel PanBtn
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public virtual MyButton Btn1
	{
		[CompilerGenerated]
		get
		{
			return _Btn1;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				Btn1_Click();
			};
			MyButton btn = _Btn1;
			if (btn != null)
			{
				btn.Click -= obj;
			}
			_Btn1 = value;
			btn = _Btn1;
			if (btn != null)
			{
				btn.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("Btn2")]
	public virtual MyButton Btn2
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public virtual MyButton Btn3
	{
		[CompilerGenerated]
		get
		{
			return _Btn3;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				Btn3_Click();
			};
			MyButton btn = _Btn3;
			if (btn != null)
			{
				btn.Click -= obj;
			}
			_Btn3 = value;
			btn = _Btn3;
			if (btn != null)
			{
				btn.Click += obj;
			}
		}
	}

	public MyMsgLogin(ModMain.MyMsgBoxConverter Converter)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(Load);
		OAuthUrl = "";
		Uuid = ModBase.GetUuid();
		try
		{
			InitializeComponent();
			((FrameworkElement)Btn1).Name = ((FrameworkElement)Btn1).Name + Conversions.ToString(ModBase.GetUuid());
			((FrameworkElement)Btn2).Name = ((FrameworkElement)Btn2).Name + Conversions.ToString(ModBase.GetUuid());
			((FrameworkElement)Btn3).Name = ((FrameworkElement)Btn3).Name + Conversions.ToString(ModBase.GetUuid());
			MyConverter = Converter;
			((Shape)ShapeLine).StrokeThickness = ModBase.GetWPFSize(1.0);
			Data = (JObject)Converter.Content;
			OAuthUrl = Conversions.ToString(Converter.AuthUrl);
			Init();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "正版验证弹窗初始化失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private void Load(object sender, EventArgs e)
	{
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		try
		{
			((UIElement)this).Opacity = 0.0;
			ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ModMain.FrmMain.PanMsgBackground, Border.BackgroundProperty, (MyConverter.IsWarn ? new ModBase.MyColor(140.0, 80.0, 0.0, 0.0) : new ModBase.MyColor(90.0, 0.0, 0.0, 0.0)) - ((Border)ModMain.FrmMain.PanMsgBackground).Background, 200), "PanMsgBackground Background");
			ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
			{
				ModAnimation.AaOpacity(this, 1.0, 120, 60),
				ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] [CompilerGenerated] (object i) =>
				{
					TranslateTransform transformPos;
					(transformPos = TransformPos).Y = Conversions.ToDouble(Operators.AddObject((object)transformPos.Y, i));
				}), 0.0 - TransformPos.Y, 300, 60, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)),
				ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] [CompilerGenerated] (object i) =>
				{
					RotateTransform transformRotate;
					(transformRotate = TransformRotate).Angle = Conversions.ToDouble(Operators.AddObject((object)transformRotate.Angle, i));
				}), 0.0 - TransformRotate.Angle, 300, 60, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak))
			}, "MyMsgBox " + Conversions.ToString(Uuid));
			ModBase.Log("[Control] 正版验证弹窗：" + LabTitle.Text + "\r\n" + LabCaption.Text);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "正版验证弹窗加载失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private void Close()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		ModAnimation.AniData[] array = new ModAnimation.AniData[5];
		object code;
		if (_Closure_0024__._0024I9_002D0 != null)
		{
			code = _Closure_0024__._0024I9_002D0;
		}
		else
		{
			ThreadStart val = [SpecialName] () =>
			{
				if (!Enumerable.Any<ModMain.MyMsgBoxConverter>((System.Collections.Generic.IEnumerable<ModMain.MyMsgBoxConverter>)ModMain.WaitingMyMsgBox))
				{
					ModAnimation.AniStart(ModAnimation.AaColor((FrameworkElement)(object)ModMain.FrmMain.PanMsgBackground, Border.BackgroundProperty, new ModBase.MyColor(0.0, 0.0, 0.0, 0.0) - ((Border)ModMain.FrmMain.PanMsgBackground).Background, 200, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)));
				}
			};
			_Closure_0024__._0024I9_002D0 = val;
			code = (object)val;
		}
		array[0] = ModAnimation.AaCode((ThreadStart)code, 30);
		array[1] = ModAnimation.AaOpacity(this, 0.0 - ((UIElement)this).Opacity, 80, 20);
		array[2] = ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] [CompilerGenerated] (object i) =>
		{
			TranslateTransform transformPos;
			(transformPos = TransformPos).Y = Conversions.ToDouble(Operators.AddObject((object)transformPos.Y, i));
		}), 20.0 - TransformPos.Y, 150, 0, new ModAnimation.AniEaseOutFluent());
		array[3] = ModAnimation.AaDouble((ParameterizedThreadStart)([SpecialName] [CompilerGenerated] (object i) =>
		{
			RotateTransform transformRotate;
			(transformRotate = TransformRotate).Angle = Conversions.ToDouble(Operators.AddObject((object)transformRotate.Angle, i));
		}), 6.0 - TransformRotate.Angle, 150, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak));
		array[4] = ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			((Panel)(Grid)((FrameworkElement)this).Parent).Children.Remove((UIElement)(object)this);
		}), 0, After: true);
		ModAnimation.AniStart((System.Collections.IList)(object)array, "MyMsgBox " + Conversions.ToString(Uuid));
	}

	public void Btn1_Click()
	{
	}

	public void Btn3_Click()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		Finished((object)new ThreadInterruptedException());
	}

	private void Drag(object sender, MouseButtonEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Point position = ((MouseEventArgs)e).GetPosition((IInputElement)(object)ShapeLine);
		if (position.Y <= 2.0)
		{
			((Window)ModMain.FrmMain).DragMove();
		}
	}

	private void Finished(object Result)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		if (!MyConverter.IsExited)
		{
			MyConverter.IsExited = true;
			MyConverter.Result = RuntimeHelpers.GetObjectValue(Result);
			ModBase.RunInUi(new Action(Close));
			Thread.Sleep(200);
			ModMain.FrmMain.ShowWindowToTop();
		}
	}

	private void Init()
	{
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		UserCode = (string?)Data["user_code"];
		DeviceCode = (string?)Data["device_code"];
		ModBase.ClipboardSet(DeviceCode);
		if (Data["verification_uri_complete"] != null)
		{
			Website = (string?)Data["verification_uri_complete"];
			LabCaption.Text = "登录网页将自动开启，授权码将自动填充。\r\n\r\n如果网络环境不佳，网页可能一直加载不出来，届时请使用 VPN 并重试。\r\n" + $"如果没有自动填充，请在页面内粘贴此授权码 {UserCode} （将自动复制）" + "\r\n" + $"你也可以用其他设备打开 {Website} 并输入授权码。";
		}
		else
		{
			Website = (string?)Data["verification_uri"];
			LabCaption.Text = $"登录网页将自动开启，请在网页中输入授权码 {UserCode}（将自动复制）。" + "\r\n\r\n如果网络环境不佳，网页可能一直加载不出来，届时请使用 VPN 并重试。\r\n" + $"你也可以用其他设备打开 {Website} 并输入上述授权码。";
		}
		LabTitle.Text = "登录 Minecraft";
		Btn1.EventData = Website;
		Btn2.EventData = UserCode;
		ModBase.RunInNewThread(new Action(WorkThread), "MyMsgLogin", (ThreadPriority)2);
	}

	private void WorkThread()
	{
		Thread.Sleep(3000);
		if (MyConverter.IsExited)
		{
			return;
		}
		ModBase.OpenWebsite(Website);
		ModBase.ClipboardSet(UserCode);
		checked
		{
			Thread.Sleep((Data["interval"].ToObject<int>() - 1) * 1000);
			int num = 0;
			while (!MyConverter.IsExited)
			{
				try
				{
					JObject jObject = (JObject)ModBase.GetJson(ModNet.NetRequestOnce("https://login.microsoftonline.com/consumers/oauth2/v2.0/token", "POST", string.Concat(new string[5]
					{
						"grant_type=urn:ietf:params:oauth:grant-type:device_code&client_id=",
						ModSecret.EffectiveOAuthClientId,
						"&device_code=",
						DeviceCode,
						"&scope=XboxLive.signin%20offline_access"
					}), "application/x-www-form-urlencoded", 5000 + num * 5000, null, MakeLog: false));
					ModProfile.ProfileLog(string.Format("令牌过期时间：{0} 秒", (object)jObject["expires_in"]));
					ModMain.Hint("网页登录成功！", ModMain.HintType.Finish);
					Finished(new string[2]
					{
						jObject["access_token"].ToString(),
						jObject["refresh_token"].ToString()
					});
					break;
				}
				catch (ModNet.HttpWebException ex)
				{
					ProjectData.SetProjectError((System.Exception)(object)ex);
					ModNet.HttpWebException ex2 = ex;
					string webResponse = ex2.InnerHttpException.WebResponse;
					if (webResponse.Contains("authorization_declined"))
					{
						Finished(new System.Exception("$你拒绝了 PCL 申请的权限……"));
						ProjectData.ClearProjectError();
						break;
					}
					if (webResponse.Contains("expired_token"))
					{
						Finished(new System.Exception("$登录用时太长啦，重新试试吧！"));
						ProjectData.ClearProjectError();
						break;
					}
					if (webResponse.Contains("Account security interrupt"))
					{
						Finished(new System.Exception("$非常抱歉，该账号由于安全问题无法登陆，请前往 Microsoft 账户页获取更多信息。"));
						ProjectData.ClearProjectError();
						break;
					}
					if (webResponse.Contains("service abuse"))
					{
						Finished(new System.Exception("$非常抱歉，该账号已被微软封禁，无法登录。"));
						ProjectData.ClearProjectError();
						break;
					}
					if (webResponse.Contains("AADSTS70000"))
					{
						Finished(new ModBase.RestartException());
						ProjectData.ClearProjectError();
						break;
					}
					if (webResponse.Contains("authorization_pending"))
					{
						Thread.Sleep(2000);
					}
					else
					{
						if (num > 2)
						{
							Finished(new System.Exception("正版验证轮询失败", (System.Exception)(object)ex2));
							ProjectData.ClearProjectError();
							break;
						}
						num++;
						ModBase.Log((System.Exception)(object)ex2, $"正版验证轮询第 {num} 次失败");
						ModBase.Log("原始返回内容: " + webResponse);
						Thread.Sleep(2000);
					}
					ProjectData.ClearProjectError();
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					if (num <= 2)
					{
						num++;
						ModBase.Log(ex4, $"正版验证轮询第 {num} 次失败");
						ModBase.Log(ex4.Message);
						Thread.Sleep(2000);
						ProjectData.ClearProjectError();
						continue;
					}
					Finished(new System.Exception("正版验证轮询失败", ex4));
					ProjectData.ClearProjectError();
					break;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelaunch/mymsglogin.xaml", (UriKind)2);
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
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			TransformRotate = (RotateTransform)target;
			break;
		case 2:
			TransformPos = (TranslateTransform)target;
			break;
		case 3:
			PanBorder = (BlurBorder)target;
			break;
		case 4:
			EffectShadow = (DropShadowEffect)target;
			break;
		case 5:
			PanMain = (Grid)target;
			break;
		case 6:
			LabTitle = (TextBlock)target;
			break;
		case 7:
			ShapeLine = (Rectangle)target;
			break;
		case 8:
			PanCaption = (MyScrollViewer)target;
			break;
		case 9:
			LabCaption = (TextBlock)target;
			break;
		case 10:
			PanBtn = (StackPanel)target;
			break;
		case 11:
			Btn1 = (MyButton)target;
			break;
		case 12:
			Btn2 = (MyButton)target;
			break;
		case 13:
			Btn3 = (MyButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
