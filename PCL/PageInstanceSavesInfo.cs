using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml.Linq;
using fNbt;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[DesignerGenerated]
public class PageInstanceSavesInfo : MyPageRight, IRefreshable, IComponentConnector
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__8_002D0
	{
		public string _0024VB_0024Local_content;

		public string _0024VB_0024Local_versionName;

		[SpecialName]
		internal void _Lambda_0024__R2(object a0, EventArgs a1)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			try
			{
				ModBase.ClipboardSet(_0024VB_0024Local_content);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "复制到剪贴板失败", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R3(object a0, EventArgs a1)
		{
			_Lambda_0024__1();
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			try
			{
				if (Operators.CompareString(_0024VB_0024Local_versionName, "获取失败", false) == 0)
				{
					ModBase.Log("当前存档版本无法确定，因此无法跳转到 Chunkbase", ModBase.LogLevel.Hint);
					return;
				}
				if (Enumerable.Any<char>((System.Collections.Generic.IEnumerable<char>)_0024VB_0024Local_versionName, (Func<char, bool>)([SpecialName] (char c) => char.IsLetter(c))))
				{
					ModBase.Log($"当前存档版本 '{_0024VB_0024Local_versionName}' 可能是预览版，不受支持，无法跳转到 Chunkbase", ModBase.LogLevel.Hint);
					return;
				}
				_0024VB_0024Local_versionName.Split('.', (StringSplitOptions)0);
				string text = (_0024VB_0024Local_versionName.StartsWith("1.21") ? _0024VB_0024Local_versionName.Replace(".", "_") : ((!_0024VB_0024Local_versionName.Contains(".")) ? _0024VB_0024Local_versionName.Replace(".", "_") : string.Join("_", Enumerable.Take<string>((System.Collections.Generic.IEnumerable<string>)_0024VB_0024Local_versionName.Split('.', (StringSplitOptions)0), 2))));
				ModBase.OpenWebsite($"https://www.chunkbase.com/apps/seed-map#seed={_0024VB_0024Local_content}&platform=java_{text}&dimension=overworld");
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "跳转到 Chunkbase 失败", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
		}
	}

	private XElement levelData;

	private bool _loaded;

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
	[field: AccessedThroughProperty("Hintversion1_9")]
	internal virtual MyHint Hintversion1_9
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("Hintversion1_8")]
	internal virtual MyHint Hintversion1_8
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("Hintversion1_3")]
	internal virtual MyHint Hintversion1_3
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
	internal virtual Grid PanList
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageInstanceSavesInfo()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Init();
		});
		InitializeComponent();
	}

	private void IRefreshable_Refresh()
	{
		Refresh();
	}

	void IRefreshable.Refresh()
	{
		//ILSpy generated this explicit interface implementation from .override directive in IRefreshable_Refresh
		this.IRefreshable_Refresh();
	}

	public void Refresh()
	{
		RefreshInfo();
	}

	private void Init()
	{
		((ScrollViewer)PanBack).ScrollToHome();
		RefreshInfo();
		_loaded = true;
		_ = _loaded;
	}

	private void RefreshInfo()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string text = Path.Combine(PageInstanceSavesLeft.CurrentSave, "level.dat");
			FileStream val = new FileStream(text, (FileMode)3, (FileAccess)1, (FileShare)1);
			try
			{
				NbtFile val2 = new NbtFile();
				val2.LoadFromStream((Stream)(object)val, (NbtCompression)0);
				ClearInfoTable();
				((UIElement)Hintversion1_9).Visibility = (Visibility)2;
				((UIElement)Hintversion1_8).Visibility = (Visibility)2;
				((UIElement)Hintversion1_3).Visibility = (Visibility)2;
				NbtCompound val3 = val2.RootTag.Get<NbtCompound>("Data");
				AddInfoTable("存档名称", val3.Get<NbtString>("LevelName").Value);
				NbtString val4 = null;
				NbtInt val5 = null;
				bool flag = val3.Contains("Difficulty");
				bool flag2 = val3.Contains("allowCommands");
				if (val4 == null)
				{
					if (flag)
					{
						((UIElement)Hintversion1_9).Visibility = (Visibility)0;
						Hintversion1_9.Text = "1.9 以下的版本无法获取存档版本";
					}
					else if (flag2)
					{
						((UIElement)Hintversion1_8).Visibility = (Visibility)0;
						Hintversion1_8.Text = "1.8 以下的版本无法获取存档版本和游戏难度";
					}
					else
					{
						((UIElement)Hintversion1_3).Visibility = (Visibility)0;
						Hintversion1_3.Text = "1.3 以下的版本无法获取存档版本、游戏难度和是否允许作弊";
					}
				}
				else
				{
					AddInfoTable("存档版本", $"{val4.Value} ({val5.Value})");
				}
				NbtLong val6 = null;
				string content = ((!val3.TryGet<NbtLong>("RandomSeed", out val6)) ? val3.Get<NbtCompound>("WorldGenSettings").Get<NbtLong>("seed").Value.ToString() : val6.Value.ToString());
				AddInfoTable("种子", content, isSeed: true, (val4 != null) ? val4.Value : null, allowCopy: true);
				if (flag2)
				{
					int num = int.Parse(Conversions.ToString(val3.Get<NbtByte>("allowCommands").Value));
					string content2 = "获取失败";
					switch (num)
					{
					case 0:
						content2 = "不允许";
						break;
					case 1:
						content2 = "允许";
						break;
					}
					AddInfoTable("是否允许作弊", content2);
				}
				AddInfoTable("最后一次游玩", new System.DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds((double)long.Parse(Conversions.ToString(val3.Get<NbtLong>("LastPlayed").Value))).ToLocalTime().ToString());
				NbtInt val7 = null;
				if (val3.TryGet<NbtInt>("SpawnX", out val7))
				{
					NbtInt val8 = val3.Get<NbtInt>("SpawnY");
					NbtInt val9 = val3.Get<NbtInt>("SpawnZ");
					AddInfoTable("出生点 (X/Y/Z)", $"{val7.Value} / {val8.Value} / {val9.Value}");
				}
				else
				{
					NbtIntArray obj = val3.Get<NbtCompound>("spawn").Get<NbtIntArray>("pos");
					int num2 = obj[0];
					int num3 = obj[1];
					int num4 = obj[2];
					AddInfoTable("出生点 (X/Y/Z)", $"{num2} / {num3} / {num4}");
				}
				string text2 = "获取失败";
				NbtByte val10 = val3.Get<NbtByte>("hardcore");
				text2 = (((double)(int)val10.Value == Conversions.ToDouble("1")) ? "极限模式" : (val3.Get<NbtInt>("GameType").Value switch
				{
					0 => "生存模式", 
					1 => "创造模式", 
					2 => "冒险模式", 
					3 => "旁观模式", 
					_ => "生存模式", 
				}));
				AddInfoTable("游戏模式", text2);
				if (flag)
				{
					NbtByte obj2 = val3.Get<NbtByte>("Difficulty");
					string text3 = "获取失败";
					switch (int.Parse(Conversions.ToString(obj2.Value)))
					{
					case 0:
						text3 = "和平";
						break;
					case 1:
						text3 = "简单";
						break;
					case 2:
						text3 = "普通";
						break;
					case 3:
						text3 = "困难";
						break;
					}
					NbtByte val11 = val3.Get<NbtByte>("DifficultyLocked");
					string text4 = (((val11 != null && (double)(int)val11.Value == Conversions.ToDouble("1")) || (double)(int)val10.Value == Conversions.ToDouble("1")) ? "是" : ((val11 != null) ? "否" : "获取失败"));
					if ((int)((UIElement)Hintversion1_8).Visibility != 0)
					{
						AddInfoTable("困难度", $"{text3} (是否已锁定难度：{text4})");
					}
				}
				TimeSpan val12 = TimeSpan.FromSeconds((double)long.Parse(Conversions.ToString(val3.Get<NbtLong>("Time").Value)) / 20.0);
				string content3 = $"{val12.Days} 天 {val12.Hours} 小时 {val12.Minutes} 分钟";
				AddInfoTable("游戏时长", content3);
				((UIElement)PanContent).Visibility = (Visibility)0;
			}
			finally
			{
				((System.IDisposable)val)?.Dispose();
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "获取存档信息失败", ModBase.LogLevel.Msgbox);
			((UIElement)PanContent).Visibility = (Visibility)2;
			((UIElement)Hintversion1_9).Visibility = (Visibility)2;
			((UIElement)Hintversion1_8).Visibility = (Visibility)2;
			((UIElement)Hintversion1_3).Visibility = (Visibility)2;
			ProjectData.ClearProjectError();
		}
	}

	private void ClearInfoTable()
	{
		((Panel)PanList).Children.Clear();
		PanList.RowDefinitions.Clear();
	}

	private void AddInfoTable(string head, string content, bool isSeed = false, string versionName = null, bool allowCopy = false)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		_Closure_0024__8_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__8_002D0();
		CS_0024_003C_003E8__locals0._0024VB_0024Local_content = content;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_versionName = versionName;
		TextBlock val = new TextBlock
		{
			Text = head,
			Margin = new Thickness(0.0, 3.0, 0.0, 3.0)
		};
		StackPanel val2 = new StackPanel
		{
			Orientation = (Orientation)0
		};
		UIElement val3;
		if (allowCopy)
		{
			MyTextButton obj = new MyTextButton
			{
				Text = CS_0024_003C_003E8__locals0._0024VB_0024Local_content
			};
			((FrameworkElement)obj).Margin = new Thickness(0.0, 3.0, 0.0, 3.0);
			val3 = (UIElement)(object)obj;
			obj.Click += [SpecialName] (object a0, EventArgs a1) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__0();
			};
		}
		else
		{
			val3 = (UIElement)new TextBlock
			{
				Text = CS_0024_003C_003E8__locals0._0024VB_0024Local_content,
				Margin = new Thickness(0.0, 3.0, 0.0, 3.0)
			};
		}
		((Panel)val2).Children.Add(val3);
		if (isSeed && Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_content, "获取失败", false) != 0)
		{
			MyIconButton obj2 = new MyIconButton
			{
				Logo = "M433.230769 74.830769a43.323077 43.323077 0 0 1 0 86.646154l-236.307692 0.157539a35.446154 35.446154 0 0 0-35.446154 35.446153v630.153847a35.446154 35.446154 0 0 0 35.446154 35.446153h630.153846a35.446154 35.446154 0 0 0 35.446154-35.446153V590.769231a43.323077 43.323077 0 1 1 86.646154 0v236.425846a122.092308 122.092308 0 0 1-122.092308 122.092308H196.923077a122.092308 122.092308 0 0 1-122.092308-122.092308v-630.153846a122.092308 122.092308 0 0 1 122.092308-122.092308z m452.923077 0a63.015385 63.015385 0 0 1 63.015385 63.015385V354.461538a43.323077 43.323077 0 0 1-43.323077 43.323077l-4.726154-0.236307A43.323077 43.323077 0 0 1 862.523077 354.461538l-0.039385-131.702153-287.074461 287.15323-90.072616 90.072616a43.323077 43.323077 0 1 1-61.243077-61.243077l90.033231-90.072616 287.113846-287.192615H669.538462a43.323077 43.323077 0 0 1-43.08677-38.596923L626.215385 118.153846A43.323077 43.323077 0 0 1 669.538462 74.830769z"
			};
			((FrameworkElement)obj2).ToolTip = "跳转到 Chunkbase";
			((FrameworkElement)obj2).Width = 24.0;
			((FrameworkElement)obj2).Height = 24.0;
			MyIconButton myIconButton = obj2;
			((Panel)val2).Children.Add((UIElement)(object)myIconButton);
			myIconButton.Click += [SpecialName] (object a0, EventArgs a1) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__1();
			};
		}
		((Panel)PanList).Children.Add((UIElement)(object)val);
		((Panel)PanList).Children.Add((UIElement)(object)val2);
		RowDefinition val4 = new RowDefinition();
		PanList.RowDefinitions.Add(val4);
		int num = PanList.RowDefinitions.IndexOf(val4);
		Grid.SetRow((UIElement)(object)val, num);
		Grid.SetColumn((UIElement)(object)val, 0);
		Grid.SetRow(val3, num);
		Grid.SetColumn(val3, 2);
		Grid.SetRow((UIElement)(object)val2, num);
		Grid.SetColumn((UIElement)(object)val2, 2);
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/pageinstancesaves/pageinstancesavesinfo.xaml", (UriKind)2);
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
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanMain = (StackPanel)target;
			break;
		case 3:
			Hintversion1_9 = (MyHint)target;
			break;
		case 4:
			Hintversion1_8 = (MyHint)target;
			break;
		case 5:
			Hintversion1_3 = (MyHint)target;
			break;
		case 6:
			PanContent = (MyCard)target;
			break;
		case 7:
			PanList = (Grid)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
