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
using Newtonsoft.Json.Linq;

namespace PCL;

[DesignerGenerated]
public class PageDownloadClient : MyPageRight, IComponentConnector
{
	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Func<JObject, System.DateTime> _0024I3_002D0;

		public static VB_0024AnonymousDelegate_15<StackPanel> _0024I3_002D1;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal System.DateTime _Lambda_0024__3_002D0(JObject v)
		{
			return v["releaseTime"].Value<System.DateTime>();
		}

		[SpecialName]
		internal void _Lambda_0024__3_002D1(StackPanel Stack)
		{
			foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(item);
				((Panel)Stack).Children.Add((UIElement)(object)ModDownloadLib.McDownloadListItem((JObject)objectValue, ModDownloadLib.McDownloadMenuSave, IsSaveOnly: true));
			}
		}
	}

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

	public PageDownloadClient()
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
		PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanBack, null, ModDownload.DlClientListLoader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
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
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0815: Unknown result type (might be due to invalid IL or missing references)
		//IL_081a: Unknown result type (might be due to invalid IL or missing references)
		//IL_083f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0849: Unknown result type (might be due to invalid IL or missing references)
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_0863: Unknown result type (might be due to invalid IL or missing references)
		//IL_086d: Expected O, but got Unknown
		//IL_086d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0876: Expected O, but got Unknown
		//IL_08dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0959: Unknown result type (might be due to invalid IL or missing references)
		//IL_0965: Unknown result type (might be due to invalid IL or missing references)
		//IL_096a: Unknown result type (might be due to invalid IL or missing references)
		//IL_098f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0999: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bd: Expected O, but got Unknown
		//IL_09bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cc: Expected O, but got Unknown
		checked
		{
			try
			{
				Dictionary<string, List<JObject>> obj = new Dictionary<string, List<JObject>>();
				obj.Add("正式版", new List<JObject>());
				obj.Add("预览版", new List<JObject>());
				obj.Add("远古版", new List<JObject>());
				obj.Add("愚人节版", new List<JObject>());
				Dictionary<string, List<JObject>> val = obj;
				JArray jArray = (JArray)ModDownload.DlClientListLoader.Output.Value["versions"];
				System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator = jArray.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						JObject jObject = (JObject)enumerator.Current;
						string text;
						switch ((string?)jObject["type"])
						{
						case "release":
							text = "正式版";
							break;
						case "snapshot":
						case "pending":
							text = "预览版";
							if (jObject["id"].ToString().StartsWith("1.") && !jObject["id"].ToString().ToLower().Contains("combat") && !jObject["id"].ToString().ToLower().Contains("rc") && !jObject["id"].ToString().ToLower().Contains("experimental") && !jObject["id"].ToString().ToLower().Equals("1.2") && !jObject["id"].ToString().ToLower().Contains("pre"))
							{
								text = "正式版";
								jObject["type"] = "release";
							}
							switch (jObject["id"].ToString().ToLower())
							{
							case "2point0_blue":
							case "2point0_red":
							case "2point0_purple":
							case "2.0_blue":
							case "2.0_red":
							case "2.0_purple":
							case "2.0":
								text = "愚人节版";
								jObject["id"] = jObject["id"].ToString().Replace("point", ".");
								jObject["type"] = "special";
								jObject.Add("lore", ModMinecraft.GetMcFoolName((string?)jObject["id"]));
								break;
							case "20w14infinite":
							case "20w14∞":
								text = "愚人节版";
								jObject["id"] = "20w14∞";
								jObject["type"] = "special";
								jObject.Add("lore", ModMinecraft.GetMcFoolName((string?)jObject["id"]));
								break;
							case "3d shareware v1.34":
							case "1.rv-pre1":
							case "15w14a":
							case "22w13oneblockatatime":
							case "23w13a_or_b":
							case "24w14potato":
							case "25w14craftmine":
								text = "愚人节版";
								jObject["type"] = "special";
								jObject.Add("lore", ModMinecraft.GetMcFoolName((string?)jObject["id"]));
								break;
							default:
							{
								System.DateTime dateTime = jObject["releaseTime"].Value<System.DateTime>().ToUniversalTime().AddHours(2.0);
								if (dateTime.Month == 4 && dateTime.Day == 1)
								{
									text = "愚人节版";
									jObject["type"] = "special";
								}
								break;
							}
							}
							break;
						case "special":
							text = "愚人节版";
							break;
						default:
							// 日历版本号即使上游 type 字段异常，也不应落进「远古版」
							text = PCLVerCompat.IsCal(jObject["id"].ToString()) ? "正式版" : "远古版";
							break;
						}
						val[text].Add(jObject);
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				int num = val.Keys.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					val[Enumerable.ElementAtOrDefault<string>((System.Collections.Generic.IEnumerable<string>)val.Keys, i)] = Enumerable.ToList<JObject>((System.Collections.Generic.IEnumerable<JObject>)Enumerable.OrderByDescending<JObject, System.DateTime>((System.Collections.Generic.IEnumerable<JObject>)Enumerable.ElementAtOrDefault<List<JObject>>((System.Collections.Generic.IEnumerable<List<JObject>>)val.Values, i), (_Closure_0024__._0024I3_002D0 == null) ? (_Closure_0024__._0024I3_002D0 = [SpecialName] (JObject v) => v["releaseTime"].Value<System.DateTime>()) : _Closure_0024__._0024I3_002D0));
				}
				((Panel)PanMain).Children.Clear();
				MyCard obj2 = new MyCard
				{
					Title = "最新版本"
				};
				((FrameworkElement)obj2).Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
				MyCard myCard = obj2;
				List<JObject> val2 = new List<JObject>();
				JObject jObject2 = (JObject)val["正式版"][0].DeepClone();
				jObject2["lore"] = "最新正式版，发布于 " + jObject2["releaseTime"].Value<System.DateTime>().ToString("yyyy'/'MM'/'dd HH':'mm");
				val2.Add(jObject2);
				if (System.DateTime.Compare(val["正式版"][0]["releaseTime"].Value<System.DateTime>(), val["预览版"][0]["releaseTime"].Value<System.DateTime>()) < 0)
				{
					JObject jObject3 = (JObject)val["预览版"][0].DeepClone();
					jObject3["lore"] = "最新预览版，发布于 " + jObject3["releaseTime"].Value<System.DateTime>().ToString("yyyy'/'MM'/'dd HH':'mm");
					val2.Add(jObject3);
				}
				StackPanel Stack2 = new StackPanel
				{
					Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
					VerticalAlignment = (VerticalAlignment)0,
					RenderTransform = (Transform)new TranslateTransform(0.0, 0.0),
					Tag = val2
				};
				VB_0024AnonymousDelegate_15<StackPanel> vB_0024AnonymousDelegate_ = [SpecialName] (StackPanel Stack) =>
				{
					foreach (object item in (System.Collections.IEnumerable)((FrameworkElement)Stack).Tag)
					{
						object objectValue = RuntimeHelpers.GetObjectValue(item);
						((Panel)Stack).Children.Add((UIElement)(object)ModDownloadLib.McDownloadListItem((JObject)objectValue, ModDownloadLib.McDownloadMenuSave, IsSaveOnly: true));
					}
				};
				VB_0024AnonymousDelegate_15<StackPanel> vB_0024AnonymousDelegate_2 = vB_0024AnonymousDelegate_;
				MyCard.StackInstall(ref Stack2, (vB_0024AnonymousDelegate_2 == null) ? null : new Action<StackPanel>(vB_0024AnonymousDelegate_2.Invoke));
				((Panel)myCard).Children.Add((UIElement)(object)Stack2);
				((Panel)PanMain).Children.Add((UIElement)(object)myCard);
				System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<JObject>>> enumerator2 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, List<JObject>>>);
				try
				{
					enumerator2 = val.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						KeyValuePair<string, List<JObject>> current = enumerator2.Current;
						if (Enumerable.Any<JObject>((System.Collections.Generic.IEnumerable<JObject>)current.Value))
						{
							MyCard obj3 = new MyCard
							{
								Title = current.Key + " (" + Conversions.ToString(current.Value.Count) + ")"
							};
							((FrameworkElement)obj3).Margin = new Thickness(0.0, 0.0, 0.0, 15.0);
							MyCard myCard2 = obj3;
							StackPanel val3 = new StackPanel
							{
								Margin = new Thickness(20.0, 40.0, 18.0, 0.0),
								VerticalAlignment = (VerticalAlignment)0,
								RenderTransform = (Transform)new TranslateTransform(0.0, 0.0),
								Tag = current.Value
							};
							((Panel)myCard2).Children.Add((UIElement)(object)val3);
							myCard2.SwapControl = val3;
							vB_0024AnonymousDelegate_2 = vB_0024AnonymousDelegate_;
							myCard2.InstallMethod = ((vB_0024AnonymousDelegate_2 == null) ? null : new Action<StackPanel>(vB_0024AnonymousDelegate_2.Invoke));
							myCard2.IsSwapped = true;
							((Panel)PanMain).Children.Add((UIElement)(object)myCard2);
						}
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
				ModBase.Log(ex2, "可视化 MC 版本列表出错", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void DownloadStart(MyListItem sender, object e)
	{
		ModDownloadLib.McDownloadClient(ModNet.NetPreDownloadBehaviour.HintWhileExists, sender.Title, NewLateBinding.LateIndexGet(((FrameworkElement)sender).Tag, new object[] { "url" }, (string[])null).ToString());
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagedownload/pagedownloadclient.xaml", (UriKind)2);
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
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanMain = (StackPanel)target;
			break;
		case 3:
			PanLoad = (MyCard)target;
			break;
		case 4:
			Load = (MyLoading)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
