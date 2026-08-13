using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using PCL.Core.Utils;

namespace PCL;

[DesignerGenerated]
public class PageOtherFeedback : MyPageRight, IComponentConnector
{
	public class Feedback
	{
		[field: CompilerGenerated]
		public string User
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string Title
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public System.DateTime Time
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string Content
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string Url
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string ID
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public List<string> Tags
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public bool Open
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string Type
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public Feedback()
		{
			Tags = new List<string>();
			Open = true;
		}
	}

	public enum TagID : long
	{
		Processing = 6820804544L,
		WaitingProcess = 6820804546L,
		Completed = 6820804547L,
		Decline = 6820804539L,
		Ignored = 8064650117L,
		Duplicate = 6820804541L,
		Wait = 8743070786L,
		Pause = 8558220235L,
		Upnext = 8550609020L
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__8_002D0
	{
		public Feedback _0024VB_0024Local_item;

		public _Closure_0024__8_002D0(_Closure_0024__8_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_item = arg0._0024VB_0024Local_item;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			int num = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
			{
				$"提交者：{_0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(_0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
				"\r\n",
				$"状态：{_0024VB_0024Local_item.Tags} | 类型：{_0024VB_0024Local_item.Type}",
				"\r\n\r\n",
				$"{_0024VB_0024Local_item.Content}"
			}), $"#{_0024VB_0024Local_item.ID} {_0024VB_0024Local_item.Title}", "确定", "查看详情");
			if (num == 2)
			{
				ModBase.OpenWebsite(_0024VB_0024Local_item.Url);
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1(object sender, RoutedEventArgs e)
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			int num = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
			{
				$"提交者：{_0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(_0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
				"\r\n",
				$"类型：{_0024VB_0024Local_item.Type}",
				"\r\n\r\n",
				$"{_0024VB_0024Local_item.Content}"
			}), $"#{_0024VB_0024Local_item.ID} {_0024VB_0024Local_item.Title}", "确定", "查看详情");
			if (num == 2)
			{
				ModBase.OpenWebsite(_0024VB_0024Local_item.Url);
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2(object sender, RoutedEventArgs e)
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			int num = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
			{
				$"提交者：{_0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(_0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
				"\r\n",
				$"类型：{_0024VB_0024Local_item.Type}",
				"\r\n\r\n",
				$"{_0024VB_0024Local_item.Content}"
			}), $"#{_0024VB_0024Local_item.ID} {_0024VB_0024Local_item.Title}", "确定", "查看详情");
			if (num == 2)
			{
				ModBase.OpenWebsite(_0024VB_0024Local_item.Url);
			}
		}

		[SpecialName]
		internal void _Lambda_0024__3(object sender, RoutedEventArgs e)
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			int num = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
			{
				$"提交者：{_0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(_0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
				"\r\n",
				$"类型：{_0024VB_0024Local_item.Type}",
				"\r\n\r\n",
				$"{_0024VB_0024Local_item.Content}"
			}), $"#{_0024VB_0024Local_item.ID} {_0024VB_0024Local_item.Title}", "确定", "查看详情");
			if (num == 2)
			{
				ModBase.OpenWebsite(_0024VB_0024Local_item.Url);
			}
		}

		[SpecialName]
		internal void _Lambda_0024__4(object sender, RoutedEventArgs e)
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			int num = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
			{
				$"提交者：{_0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(_0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
				"\r\n",
				$"类型：{_0024VB_0024Local_item.Type}",
				"\r\n\r\n",
				$"{_0024VB_0024Local_item.Content}"
			}), $"#{_0024VB_0024Local_item.ID} {_0024VB_0024Local_item.Title}", "确定", "查看详情");
			if (num == 2)
			{
				ModBase.OpenWebsite(_0024VB_0024Local_item.Url);
			}
		}

		[SpecialName]
		internal void _Lambda_0024__5(object sender, RoutedEventArgs e)
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			int num = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
			{
				$"提交者：{_0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(_0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
				"\r\n",
				$"类型：{_0024VB_0024Local_item.Type}",
				"\r\n\r\n",
				$"{_0024VB_0024Local_item.Content}"
			}), $"#{_0024VB_0024Local_item.ID} {_0024VB_0024Local_item.Title}", "确定", "查看详情");
			if (num == 2)
			{
				ModBase.OpenWebsite(_0024VB_0024Local_item.Url);
			}
		}

		[SpecialName]
		internal void _Lambda_0024__6(object sender, RoutedEventArgs e)
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			int num = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
			{
				$"提交者：{_0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(_0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
				"\r\n",
				$"类型：{_0024VB_0024Local_item.Type}",
				"\r\n\r\n",
				$"{_0024VB_0024Local_item.Content}"
			}), $"#{_0024VB_0024Local_item.ID} {_0024VB_0024Local_item.Title}", "确定", "查看详情");
			if (num == 2)
			{
				ModBase.OpenWebsite(_0024VB_0024Local_item.Url);
			}
		}

		[SpecialName]
		internal void _Lambda_0024__7(object sender, RoutedEventArgs e)
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			int num = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
			{
				$"提交者：{_0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(_0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
				"\r\n",
				$"类型：{_0024VB_0024Local_item.Type}",
				"\r\n\r\n",
				$"{_0024VB_0024Local_item.Content}"
			}), $"#{_0024VB_0024Local_item.ID} {_0024VB_0024Local_item.Title}", "确定", "查看详情");
			if (num == 2)
			{
				ModBase.OpenWebsite(_0024VB_0024Local_item.Url);
			}
		}

		[SpecialName]
		internal void _Lambda_0024__8(object sender, RoutedEventArgs e)
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			int num = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
			{
				$"提交者：{_0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(_0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
				"\r\n",
				$"类型：{_0024VB_0024Local_item.Type}",
				"\r\n\r\n",
				$"{_0024VB_0024Local_item.Content}"
			}), $"#{_0024VB_0024Local_item.ID} {_0024VB_0024Local_item.Title}", "确定", "查看详情");
			if (num == 2)
			{
				ModBase.OpenWebsite(_0024VB_0024Local_item.Url);
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__8_002D1
	{
		public string _0024VB_0024Local_StatusDesc;

		public _Closure_0024__8_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__8_002D1(_Closure_0024__8_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_StatusDesc = arg0._0024VB_0024Local_StatusDesc;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R2(object a0, MouseButtonEventArgs a1)
		{
			_Lambda_0024__9();
		}

		[SpecialName]
		internal void _Lambda_0024__9()
		{
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			int num = ModMain.MyMsgBoxMarkdown(string.Format("提交者：{0}（{1}）{2}状态：{3}{4}{5}{6}", new object[7]
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.User,
				TimeUtils.GetTimeSpanString(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false),
				"\r\n",
				_0024VB_0024Local_StatusDesc,
				"\r\n",
				"\r\n",
				_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Content
			}), "#" + _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.ID + " " + _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title, "确定", "查看详情");
			if (num == 2)
			{
				ModBase.OpenWebsite(_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Url);
			}
		}
	}

	private bool IsLoaded;

	public ModLoader.LoaderTask<int, List<Feedback>> Loader;

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
	[field: AccessedThroughProperty("PanInfo")]
	internal virtual MyCard PanInfo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnManageOpen")]
	internal virtual MyButton BtnManageOpen
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
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
	[field: AccessedThroughProperty("PanContentProcessing")]
	internal virtual MyCard PanContentProcessing
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanListProcessing")]
	internal virtual StackPanel PanListProcessing
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanContentWaitingProcess")]
	internal virtual MyCard PanContentWaitingProcess
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanListWaitingProcess")]
	internal virtual StackPanel PanListWaitingProcess
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanContentWait")]
	internal virtual MyCard PanContentWait
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanListWait")]
	internal virtual StackPanel PanListWait
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanContentPause")]
	internal virtual MyCard PanContentPause
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanListPause")]
	internal virtual StackPanel PanListPause
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanContentUpnext")]
	internal virtual MyCard PanContentUpnext
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanListUpnext")]
	internal virtual StackPanel PanListUpnext
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanContentCompleted")]
	internal virtual MyCard PanContentCompleted
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanListCompleted")]
	internal virtual StackPanel PanListCompleted
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanContentDecline")]
	internal virtual MyCard PanContentDecline
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanListDecline")]
	internal virtual StackPanel PanListDecline
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanContentIgnored")]
	internal virtual MyCard PanContentIgnored
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanListIgnored")]
	internal virtual StackPanel PanListIgnored
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

	public PageOtherFeedback()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageOtherFeedback_Loaded);
		IsLoaded = false;
		Loader = new ModLoader.LoaderTask<int, List<Feedback>>("FeedbackList", FeedbackListGet, null, (ThreadPriority)2);
		InitializeComponent();
	}

	private void PageOtherFeedback_Loaded(object sender, RoutedEventArgs e)
	{
		PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanContent, (FrameworkElement)(object)PanInfo, Loader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
		{
			RefreshList();
		});
		((ScrollViewer)PanBack).ScrollToHome();
		if (!IsLoaded)
		{
			IsLoaded = true;
		}
	}

	public void FeedbackListGet(ModLoader.LoaderTask<int, List<Feedback>> Task)
	{
		JArray jArray = (JArray)ModNet.NetGetCodeByRequestRetry("https://api.github.com/repos/PCLPro/PCLPro/issues?state=all&sort=created&per_page=200", null, "", IsJson: true, null, UseBrowserUserAgent: true);
		if (jArray == null)
		{
			throw new System.Exception("无法获取到内容");
		}
		List<Feedback> val = new List<Feedback>();
		System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
		try
		{
			enumerator = jArray.GetEnumerator();
			System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				JObject jObject = (JObject)enumerator.Current;
				Feedback feedback = new Feedback
				{
					Title = jObject["title"].ToString(),
					Url = jObject["html_url"].ToString(),
					Content = jObject["body"].ToString(),
					Time = System.DateTime.Parse(jObject["created_at"].ToString()),
					User = jObject["user"]["login"].ToString(),
					ID = (string?)jObject["number"],
					Open = jObject["state"].ToString().Equals("open")
				};
				string type = "未分类";
				JToken jToken = jObject["type"];
				if (jToken != null && jToken.Type == JTokenType.Object)
				{
					JToken jToken2 = jToken["name"];
					if (jToken2 != null)
					{
						type = jToken2.ToString().ToLower();
					}
				}
				feedback.Type = type;
				JArray jArray2 = (JArray)jObject["labels"];
				try
				{
					enumerator2 = jArray2.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator2).MoveNext())
					{
						JObject jObject2 = (JObject)enumerator2.Current;
						feedback.Tags.Add((string?)jObject2["id"]);
					}
				}
				finally
				{
					((System.IDisposable)enumerator2)?.Dispose();
				}
				val.Add(feedback);
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		Task.Output = val;
	}

	private string AppendTypeToStatus(string status, string typeName)
	{
		if (string.IsNullOrEmpty(typeName))
		{
			return status;
		}
		string text = typeName.ToLower();
		List<string> obj = new List<string>();
		obj.Add("bug");
		obj.Add("崩溃");
		obj.Add("新功能");
		obj.Add("优化");
		obj.Add("未分类");
		obj.Add("网络");
		if (obj.Contains(text))
		{
			return status + "-" + typeName;
		}
		return status;
	}

	public void RefreshList()
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		((Panel)PanListProcessing).Children.Clear();
		((Panel)PanListWaitingProcess).Children.Clear();
		((Panel)PanListWait).Children.Clear();
		((Panel)PanListPause).Children.Clear();
		((Panel)PanListUpnext).Children.Clear();
		((Panel)PanListCompleted).Children.Clear();
		((Panel)PanListDecline).Children.Clear();
		((Panel)PanListIgnored).Children.Clear();
		System.Collections.Generic.IEnumerator<Feedback> enumerator = default(System.Collections.Generic.IEnumerator<Feedback>);
		try
		{
			enumerator = Loader.Output.GetEnumerator();
			_Closure_0024__8_002D0 closure_0024__8_002D = default(_Closure_0024__8_002D0);
			_Closure_0024__8_002D1 closure_0024__8_002D2 = default(_Closure_0024__8_002D1);
			while (enumerator.MoveNext())
			{
				closure_0024__8_002D = new _Closure_0024__8_002D0(closure_0024__8_002D);
				closure_0024__8_002D._0024VB_0024Local_item = enumerator.Current;
				closure_0024__8_002D2 = new _Closure_0024__8_002D1(closure_0024__8_002D2);
				closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2 = closure_0024__8_002D;
				MyListItem myListItem = new MyListItem
				{
					Title = closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title,
					Type = MyListItem.CheckType.Clickable
				};
				closure_0024__8_002D2._0024VB_0024Local_StatusDesc = "???";
				string info = $"{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.User} | {closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Time} | 类型: {closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type}";
				_ = closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2;
				if (closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Tags.Contains(Conversions.ToString(6820804544L)))
				{
					MyListItem myListItem2 = new MyListItem();
					myListItem2.Title = closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title;
					myListItem2.Type = MyListItem.CheckType.Clickable;
					myListItem2.Info = info;
					myListItem2.Logo = ModBase.PathImage + "Blocks/CommandBlock.png";
					myListItem2.Tags = AppendTypeToStatus("处理中", closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type);
					myListItem2.Click += [SpecialName] (object sender, MouseButtonEventArgs e) =>
					{
						//IL_0028: Unknown result type (might be due to invalid IL or missing references)
						int num8 = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
						{
							$"提交者：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
							"\r\n",
							$"类型：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type}",
							"\r\n\r\n",
							$"{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Content}"
						}), $"#{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.ID} {closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title}", "确定", "查看详情");
						if (num8 == 2)
						{
							ModBase.OpenWebsite(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Url);
						}
					};
					((Panel)PanListProcessing).Children.Add((UIElement)(object)myListItem2);
				}
				if (closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Tags.Contains(Conversions.ToString(6820804546L)))
				{
					MyListItem myListItem3 = new MyListItem();
					myListItem3.Title = closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title;
					myListItem3.Type = MyListItem.CheckType.Clickable;
					myListItem3.Info = info;
					myListItem3.Logo = ModBase.PathImage + "Blocks/RedstoneBlock.png";
					myListItem3.Tags = AppendTypeToStatus("等待处理", closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type);
					myListItem3.Click += [SpecialName] (object sender, MouseButtonEventArgs e) =>
					{
						//IL_0028: Unknown result type (might be due to invalid IL or missing references)
						int num7 = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
						{
							$"提交者：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
							"\r\n",
							$"类型：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type}",
							"\r\n\r\n",
							$"{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Content}"
						}), $"#{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.ID} {closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title}", "确定", "查看详情");
						if (num7 == 2)
						{
							ModBase.OpenWebsite(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Url);
						}
					};
					((Panel)PanListWaitingProcess).Children.Add((UIElement)(object)myListItem3);
				}
				if (closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Tags.Contains(Conversions.ToString(8743070786L)))
				{
					MyListItem myListItem4 = new MyListItem();
					myListItem4.Title = closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title;
					myListItem4.Type = MyListItem.CheckType.Clickable;
					myListItem4.Info = info;
					myListItem4.Logo = ModBase.PathImage + "Blocks/Anvil.png";
					myListItem4.Tags = AppendTypeToStatus("已确认，等待社区开发者接管该内容的处理", closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type);
					myListItem4.Click += [SpecialName] (object sender, MouseButtonEventArgs e) =>
					{
						//IL_0028: Unknown result type (might be due to invalid IL or missing references)
						int num6 = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
						{
							$"提交者：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
							"\r\n",
							$"类型：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type}",
							"\r\n\r\n",
							$"{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Content}"
						}), $"#{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.ID} {closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title}", "确定", "查看详情");
						if (num6 == 2)
						{
							ModBase.OpenWebsite(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Url);
						}
					};
					((Panel)PanListWait).Children.Add((UIElement)(object)myListItem4);
				}
				if (closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Tags.Contains(Conversions.ToString(8558220235L)))
				{
					MyListItem myListItem5 = new MyListItem();
					myListItem5.Title = closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title;
					myListItem5.Type = MyListItem.CheckType.Clickable;
					myListItem5.Info = info;
					myListItem5.Logo = ModBase.PathImage + "Blocks/RedstoneLampOff.png";
					myListItem5.Tags = AppendTypeToStatus("近期不计划制作此功能", closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type);
					myListItem5.Click += [SpecialName] (object sender, MouseButtonEventArgs e) =>
					{
						//IL_0028: Unknown result type (might be due to invalid IL or missing references)
						int num5 = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
						{
							$"提交者：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
							"\r\n",
							$"类型：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type}",
							"\r\n\r\n",
							$"{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Content}"
						}), $"#{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.ID} {closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title}", "确定", "查看详情");
						if (num5 == 2)
						{
							ModBase.OpenWebsite(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Url);
						}
					};
					((Panel)PanListPause).Children.Add((UIElement)(object)myListItem5);
				}
				if (closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Tags.Contains(Conversions.ToString(8550609020L)))
				{
					MyListItem myListItem6 = new MyListItem();
					myListItem6.Title = closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title;
					myListItem6.Type = MyListItem.CheckType.Clickable;
					myListItem6.Info = info;
					myListItem6.Logo = ModBase.PathImage + "Blocks/RedstoneLampOn.png";
					myListItem6.Tags = AppendTypeToStatus("即将开工的内容", closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type);
					myListItem6.Click += [SpecialName] (object sender, MouseButtonEventArgs e) =>
					{
						//IL_0028: Unknown result type (might be due to invalid IL or missing references)
						int num4 = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
						{
							$"提交者：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
							"\r\n",
							$"类型：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type}",
							"\r\n\r\n",
							$"{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Content}"
						}), $"#{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.ID} {closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title}", "确定", "查看详情");
						if (num4 == 2)
						{
							ModBase.OpenWebsite(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Url);
						}
					};
					((Panel)PanListUpnext).Children.Add((UIElement)(object)myListItem6);
				}
				if (closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Tags.Contains(Conversions.ToString(6820804547L)))
				{
					MyListItem myListItem7 = new MyListItem();
					myListItem7.Title = closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title;
					myListItem7.Type = MyListItem.CheckType.Clickable;
					myListItem7.Info = info;
					myListItem7.Logo = ModBase.PathImage + "Blocks/Grass.png";
					myListItem7.Tags = AppendTypeToStatus("已完成", closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type);
					myListItem7.Click += [SpecialName] (object sender, MouseButtonEventArgs e) =>
					{
						//IL_0028: Unknown result type (might be due to invalid IL or missing references)
						int num3 = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
						{
							$"提交者：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
							"\r\n",
							$"类型：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type}",
							"\r\n\r\n",
							$"{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Content}"
						}), $"#{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.ID} {closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title}", "确定", "查看详情");
						if (num3 == 2)
						{
							ModBase.OpenWebsite(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Url);
						}
					};
					((Panel)PanListCompleted).Children.Add((UIElement)(object)myListItem7);
				}
				if (closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Tags.Contains(Conversions.ToString(6820804539L)))
				{
					MyListItem myListItem8 = new MyListItem();
					myListItem8.Title = closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title;
					myListItem8.Type = MyListItem.CheckType.Clickable;
					myListItem8.Info = info;
					myListItem8.Logo = ModBase.PathImage + "Blocks/CobbleStone.png";
					myListItem8.Tags = AppendTypeToStatus("已拒绝", closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type);
					myListItem8.Click += [SpecialName] (object sender, MouseButtonEventArgs e) =>
					{
						//IL_0028: Unknown result type (might be due to invalid IL or missing references)
						int num2 = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
						{
							$"提交者：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
							"\r\n",
							$"类型：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type}",
							"\r\n\r\n",
							$"{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Content}"
						}), $"#{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.ID} {closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title}", "确定", "查看详情");
						if (num2 == 2)
						{
							ModBase.OpenWebsite(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Url);
						}
					};
					((Panel)PanListDecline).Children.Add((UIElement)(object)myListItem8);
				}
				if (closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Tags.Contains(Conversions.ToString(8064650117L)))
				{
					MyListItem myListItem9 = new MyListItem();
					myListItem9.Title = closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title;
					myListItem9.Type = MyListItem.CheckType.Clickable;
					myListItem9.Info = info;
					myListItem9.Logo = ModBase.PathImage + "Blocks/CobbleStone.png";
					myListItem9.Tags = AppendTypeToStatus("已忽略", closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type);
					myListItem9.Click += [SpecialName] (object sender, MouseButtonEventArgs e) =>
					{
						//IL_0028: Unknown result type (might be due to invalid IL or missing references)
						int num = ModMain.MyMsgBoxMarkdown(string.Concat(new string[5]
						{
							$"提交者：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.User}（{TimeUtils.GetTimeSpanString(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Time - System.DateTime.Now, isShortForm: false)}）",
							"\r\n",
							$"类型：{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Type}",
							"\r\n\r\n",
							$"{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Content}"
						}), $"#{closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.ID} {closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Title}", "确定", "查看详情");
						if (num == 2)
						{
							ModBase.OpenWebsite(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Url);
						}
					};
					((Panel)PanListIgnored).Children.Add((UIElement)(object)myListItem9);
				}
				myListItem.Info = closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.User + " | " + Conversions.ToString(closure_0024__8_002D2._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_item.Time);
				myListItem.Tags = closure_0024__8_002D2._0024VB_0024Local_StatusDesc;
				myListItem.Click += closure_0024__8_002D2._Lambda_0024__R2;
				if (ModBase.StartsWithF(closure_0024__8_002D2._0024VB_0024Local_StatusDesc, "处理中"))
				{
					((Panel)PanListProcessing).Children.Add((UIElement)(object)myListItem);
				}
				else if (closure_0024__8_002D2._0024VB_0024Local_StatusDesc.Equals("等待处理"))
				{
					((Panel)PanListWaitingProcess).Children.Add((UIElement)(object)myListItem);
				}
				else if (closure_0024__8_002D2._0024VB_0024Local_StatusDesc.Equals("已完成"))
				{
					((Panel)PanListCompleted).Children.Add((UIElement)(object)myListItem);
				}
				else if (closure_0024__8_002D2._0024VB_0024Local_StatusDesc.Equals("已拒绝"))
				{
					((Panel)PanListDecline).Children.Add((UIElement)(object)myListItem);
				}
				else if (closure_0024__8_002D2._0024VB_0024Local_StatusDesc.Equals("已忽略"))
				{
					((Panel)PanListIgnored).Children.Add((UIElement)(object)myListItem);
				}
				else if (closure_0024__8_002D2._0024VB_0024Local_StatusDesc.Equals("已确认，等待社区开发者接管该内容的处理"))
				{
					((Panel)PanListWait).Children.Add((UIElement)(object)myListItem);
				}
				else if (closure_0024__8_002D2._0024VB_0024Local_StatusDesc.Equals("近期不计划制作此功能"))
				{
					((Panel)PanListPause).Children.Add((UIElement)(object)myListItem);
				}
				else if (closure_0024__8_002D2._0024VB_0024Local_StatusDesc.Equals("即将开工的内容"))
				{
					((Panel)PanListUpnext).Children.Add((UIElement)(object)myListItem);
				}
				((UIElement)PanContentDecline).Visibility = (Visibility)(((Panel)PanListDecline).Children.Count.Equals(0) ? 2 : 0);
				((UIElement)PanContentCompleted).Visibility = (Visibility)(((Panel)PanListCompleted).Children.Count.Equals(0) ? 2 : 0);
				((UIElement)PanContentWaitingProcess).Visibility = (Visibility)(((Panel)PanListWaitingProcess).Children.Count.Equals(0) ? 2 : 0);
				((UIElement)PanContentProcessing).Visibility = (Visibility)(((Panel)PanListProcessing).Children.Count.Equals(0) ? 2 : 0);
				((UIElement)PanContentIgnored).Visibility = (Visibility)(((Panel)PanListIgnored).Children.Count.Equals(0) ? 2 : 0);
				((UIElement)PanContentWait).Visibility = (Visibility)(((Panel)PanListWait).Children.Count.Equals(0) ? 2 : 0);
				((UIElement)PanContentPause).Visibility = (Visibility)(((Panel)PanListPause).Children.Count.Equals(0) ? 2 : 0);
				((UIElement)PanContentUpnext).Visibility = (Visibility)(((Panel)PanListUpnext).Children.Count.Equals(0) ? 2 : 0);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	private void Feedback_Click(object sender, MouseButtonEventArgs e)
	{
		PageOtherLeft.TryFeedback();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageother/pageotherfeedback.xaml", (UriKind)2);
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
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanMain = (StackPanel)target;
			break;
		case 3:
			PanInfo = (MyCard)target;
			break;
		case 4:
			BtnManageOpen = (MyButton)target;
			break;
		case 5:
			PanContent = (StackPanel)target;
			break;
		case 6:
			PanContentProcessing = (MyCard)target;
			break;
		case 7:
			PanListProcessing = (StackPanel)target;
			break;
		case 8:
			PanContentWaitingProcess = (MyCard)target;
			break;
		case 9:
			PanListWaitingProcess = (StackPanel)target;
			break;
		case 10:
			PanContentWait = (MyCard)target;
			break;
		case 11:
			PanListWait = (StackPanel)target;
			break;
		case 12:
			PanContentPause = (MyCard)target;
			break;
		case 13:
			PanListPause = (StackPanel)target;
			break;
		case 14:
			PanContentUpnext = (MyCard)target;
			break;
		case 15:
			PanListUpnext = (StackPanel)target;
			break;
		case 16:
			PanContentCompleted = (MyCard)target;
			break;
		case 17:
			PanListCompleted = (StackPanel)target;
			break;
		case 18:
			PanContentDecline = (MyCard)target;
			break;
		case 19:
			PanListDecline = (StackPanel)target;
			break;
		case 20:
			PanContentIgnored = (MyCard)target;
			break;
		case 21:
			PanListIgnored = (StackPanel)target;
			break;
		case 22:
			PanLoad = (MyCard)target;
			break;
		case 23:
			Load = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
