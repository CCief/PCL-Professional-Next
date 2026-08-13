using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Net;

namespace PCL;

[DesignerGenerated]
public class PageOtherVote : MyPageRight, IComponentConnector
{
	public class Vote
	{
		[field: CompilerGenerated]
		public string Title
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
		public System.DateTime Time
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string VoteText
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__7_002D0
	{
		public Vote _0024VB_0024Local_item;

		public _Closure_0024__7_002D0(_Closure_0024__7_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_item = arg0._0024VB_0024Local_item;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R3(object a0, MouseButtonEventArgs a1)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			ModBase.OpenWebsite(_0024VB_0024Local_item.Url);
		}
	}

	private bool IsLoaded;

	public ModLoader.LoaderTask<int, List<Vote>> Loader;

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

	public PageOtherVote()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageOtherFeedback_Loaded);
		IsLoaded = false;
		Loader = new ModLoader.LoaderTask<int, List<Vote>>("VoteList", VoteListGet, LoaderInput, (ThreadPriority)2);
		InitializeComponent();
	}

	private void PageOtherFeedback_Loaded(object sender, RoutedEventArgs e)
	{
		PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanContent, (FrameworkElement)(object)PanInfo, Loader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
		{
			LoadList();
		}, [SpecialName] [CompilerGenerated] () => LoaderInput());
		((ScrollViewer)PanBack).ScrollToHome();
		if (!IsLoaded)
		{
			IsLoaded = true;
		}
	}

	private int LoaderInput()
	{
		return 0;
	}

	public void VoteListGet(ModLoader.LoaderTask<int, List<Vote>> Task)
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		string text;
		using (HttpResponseHandler httpResponseHandler = HttpRequestBuilder.Create("https://github.com/Meloong-Git/PCL/discussions/categories/%E5%8A%9F%E8%83%BD%E6%8A%95%E7%A5%A8?discussions_q=is%3Aopen+category%3A%E5%8A%9F%E8%83%BD%E6%8A%95%E7%A5%A8+sort%3Atop", HttpMethod.Get).SendAsync(throwIfNotSuccess: true).Result)
		{
			text = httpResponseHandler.AsStringContent();
		}
		if (text == null)
		{
			throw new System.Exception("空内容");
		}
		string text2 = "<div class=\"d-flex flex-auto flex-items-start\">(.*?)<svg aria-hidden=\"true\" height=\"16\" viewBox=\"0 0 16 16\" version=\"1.1\" width=\"16\" data-view-component=\"true\" class=\"octicon octicon-comment color-fg-muted mr-1\">";
		MatchCollection val = Regex.Matches(text, text2, (RegexOptions)16);
		List<string> val2 = new List<string>();
		foreach (Match item in val)
		{
			Match val3 = item;
			if (((Group)val3).Success)
			{
				val2.Add(((Capture)val3.Groups[1]).Value);
			}
		}
		List<Vote> val4 = new List<Vote>();
		System.Collections.Generic.IEnumerator<string> enumerator2 = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator2 = val2.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				string current = enumerator2.Current;
				Vote vote = new Vote();
				text2 = "<a[^>]*?\\bdata-hovercard-type=\"discussion\"[^>]*?href=\"(.*?)\"[^>]*?>(.*?)</a>";
				Match val5 = Regex.Match(current, text2, (RegexOptions)16);
				if (((Group)val5).Success)
				{
					vote.Title = ((Capture)val5.Groups[2]).Value.Trim();
					vote.Url = "https://github.com" + ((Capture)val5.Groups[1]).Value;
				}
				text2 = "<relative-time datetime=\"(.*?)\" class=\"no-wrap\"";
				val5 = Regex.Match(current, text2, (RegexOptions)16);
				if (((Group)val5).Success)
				{
					vote.Time = System.DateTime.Parse(((Capture)val5.Groups[1]).Value).ToLocalTime();
				}
				text2 = "aria-label=\"Upvote: (\\d+)\"";
				val5 = Regex.Match(current, text2);
				if (((Group)val5).Success)
				{
					vote.VoteText = ((Capture)val5.Groups[1]).Value.Trim();
				}
				else
				{
					vote.VoteText = "?";
				}
				val4.Add(vote);
			}
		}
		finally
		{
			((System.IDisposable)enumerator2).Dispose();
		}
		Task.Output = val4;
	}

	public void LoadList()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		((Panel)PanList).Children.Clear();
		System.Collections.Generic.IEnumerator<Vote> enumerator = default(System.Collections.Generic.IEnumerator<Vote>);
		try
		{
			enumerator = Loader.Output.GetEnumerator();
			_Closure_0024__7_002D0 closure_0024__7_002D = default(_Closure_0024__7_002D0);
			while (enumerator.MoveNext())
			{
				closure_0024__7_002D = new _Closure_0024__7_002D0(closure_0024__7_002D);
				closure_0024__7_002D._0024VB_0024Local_item = enumerator.Current;
				MyListItem myListItem = new MyListItem
				{
					Type = MyListItem.CheckType.Clickable,
					Title = closure_0024__7_002D._0024VB_0024Local_item.VoteText + " 票 | " + closure_0024__7_002D._0024VB_0024Local_item.Title,
					Info = closure_0024__7_002D._0024VB_0024Local_item.Time.ToString()
				};
				myListItem.Click += closure_0024__7_002D._Lambda_0024__R3;
				((Panel)PanList).Children.Add((UIElement)(object)myListItem);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	private void Vote_Click(object sender, MouseButtonEventArgs e)
	{
		PageOtherLeft.TryVote();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageother/pageothervote.xaml", (UriKind)2);
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
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
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
			PanContent = (MyCard)target;
			break;
		case 6:
			PanList = (StackPanel)target;
			break;
		case 7:
			PanLoad = (MyCard)target;
			break;
		case 8:
			Load = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
