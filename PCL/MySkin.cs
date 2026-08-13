using Image = System.Windows.Controls.Image;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PCL.Core.UI;
using Color = System.Drawing.Color;

namespace PCL;

[DesignerGenerated]
public class MySkin : Grid, IComponentConnector
{
	public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

	[CompilerGenerated]
	internal sealed class _Closure_0024__23_002D0
	{
		public ModLoader.LoaderTask<ModBase.EqualableList<string>, string> _0024VB_0024Local_sender;

		public _Closure_0024__23_002D0(_Closure_0024__23_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_sender = arg0._0024VB_0024Local_sender;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			try
			{
				ModMain.Hint("正在刷新头像……");
				ModBase.Log("[Skin] 正在清空皮肤缓存");
				if (Directory.Exists(ModBase.PathTemp + "Cache\\Skin"))
				{
					ModBase.DeleteDirectory(ModBase.PathTemp + "Cache\\Skin");
				}
				if (Directory.Exists(ModBase.PathTemp + "Cache\\Uuid"))
				{
					ModBase.DeleteDirectory(ModBase.PathTemp + "Cache\\Uuid");
				}
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Skin\\IndexMs.ini");
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Skin\\IndexAuth.ini");
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Uuid\\Mojang.ini");
				ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[] array = ((_0024VB_0024Local_sender == null) ? new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[2]
				{
					PageLaunchLeft.SkinLegacy,
					PageLaunchLeft.SkinMs
				} : new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[1] { _0024VB_0024Local_sender });
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					array[i].WaitForExit(null, null, IsForceRestart: true);
				}
				ModMain.Hint("已刷新头像！", ModMain.HintType.Finish);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "刷新皮肤缓存失败", ModBase.LogLevel.Msgbox);
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__24_002D0
	{
		public string _0024VB_0024Local_SkinAddress;

		public _Closure_0024__24_002D0(_Closure_0024__24_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_SkinAddress = arg0._0024VB_0024Local_SkinAddress;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			try
			{
				ModBase.WriteIni(ModBase.PathTemp + "Cache\\Skin\\IndexMs.ini", ModProfile.SelectedProfile.Uuid, _0024VB_0024Local_SkinAddress);
				ModBase.Log($"[Skin] 已写入皮肤地址缓存 {ModProfile.SelectedProfile.Uuid} -> {_0024VB_0024Local_SkinAddress}");
				ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[] array = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[2]
				{
					PageLaunchLeft.SkinMs,
					PageLaunchLeft.SkinLegacy
				};
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					array[i].WaitForExit(null, null, IsForceRestart: true);
				}
				ModMain.Hint("更改皮肤成功！", ModMain.HintType.Finish);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "更改正版皮肤后刷新皮肤失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__29_002D0
	{
		public JObject _0024VB_0024Local_SkinData;

		public int? _0024VB_0024Local_SelId;

		public _Closure_0024__29_002D0(_Closure_0024__29_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_SkinData = arg0._0024VB_0024Local_SkinData;
				_0024VB_0024Local_SelId = arg0._0024VB_0024Local_SelId;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			try
			{
				Dictionary<string, string> obj = new Dictionary<string, string>();
				obj.Add("Migrator", "迁移者披风");
				obj.Add("MapMaker", "Realms 地图制作者披风");
				obj.Add("Moderator", "Mojira 管理员披风");
				obj.Add("Translator-Chinese", "Crowdin 中文翻译者披风");
				obj.Add("Translator", "Crowdin 翻译者披风");
				obj.Add("Cobalt", "Cobalt 披风");
				obj.Add("Vanilla", "原版披风");
				obj.Add("Minecon2011", "Minecon 2011 参与者披风");
				obj.Add("Minecon2012", "Minecon 2012 参与者披风");
				obj.Add("Minecon2013", "Minecon 2013 参与者披风");
				obj.Add("Minecon2015", "Minecon 2015 参与者披风");
				obj.Add("Minecon2016", "Minecon 2016 参与者披风");
				obj.Add("Cherry Blossom", "樱花披风");
				obj.Add("15th Anniversary", "15 周年纪念披风");
				obj.Add("Purple Heart", "紫色心形披风");
				obj.Add("Follower's", "追随者披风");
				obj.Add("MCC 15th Year", "MCC 15 周年披风");
				obj.Add("Minecraft Experience", "村民救援披风");
				obj.Add("Mojang Office", "Mojang 办公室披风");
				obj.Add("Home", "家园披风");
				obj.Add("Menace", "入侵披风");
				obj.Add("Yearn", "渴望披风");
				obj.Add("Common", "普通披风");
				obj.Add("Pan", "薄煎饼披风");
				obj.Add("Founder's", "创始人披风");
				Dictionary<string, string> val = obj;
				List<IMyRadio> obj2 = new List<IMyRadio>();
				obj2.Add((IMyRadio)new MyListItem
				{
					Title = "无披风",
					Info = "Null"
				});
				List<IMyRadio> val2 = obj2;
				System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator = ((System.Collections.Generic.IEnumerable<JToken>)_0024VB_0024Local_SkinData["capes"]).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						JToken current = enumerator.Current;
						string text = current["alias"].ToString();
						if (val.ContainsKey(text))
						{
							text = val[text];
						}
						bool @checked = current["state"]?.ToString().ToUpper().Equals("ACTIVE") ?? false;
						val2.Add((IMyRadio)new MyListItem
						{
							Title = text,
							Info = current["alias"].ToString(),
							Checked = @checked,
							Type = MyListItem.CheckType.RadioBox,
							Logo = (string?)current["url"],
							LogoScale = 0.8
						});
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				_0024VB_0024Local_SelId = ModMain.MyMsgBoxSelect(val2, "选择披风", "确定", "取消");
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "获取玩家皮肤列表失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	private ClickEventHandler ClickEvent;

	private string _Address;

	public ModLoader.LoaderTask<ModBase.EqualableList<string>, string> Loader;

	private bool IsSkinMouseDown;

	private bool IsChanging;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSkinSave")]
	private MyMenuItem _BtnSkinSave;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSkinRefresh")]
	private MyMenuItem _BtnSkinRefresh;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSkinCape")]
	private MyMenuItem _BtnSkinCape;

	private bool _contentLoaded;

	public string Address
	{
		get
		{
			return _Address;
		}
		set
		{
			_Address = value;
			((FrameworkElement)this).ToolTip = ((Operators.CompareString(_Address, "", false) == 0) ? "加载中" : "点击更换皮肤（右键查看更多选项）");
		}
	}

	public bool HasCape
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Invalid comparison between Unknown and I4
			return (int)((UIElement)BtnSkinCape).Visibility == 2;
		}
		set
		{
			if (value)
			{
				((UIElement)BtnSkinCape).Visibility = (Visibility)0;
			}
			else
			{
				((UIElement)BtnSkinCape).Visibility = (Visibility)2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ShadowSkin")]
	internal virtual DropShadowEffect ShadowSkin
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyMenuItem BtnSkinSave
	{
		[CompilerGenerated]
		get
		{
			return _BtnSkinSave;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			RoutedEventHandler val = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				BtnSkinSave_Click();
			});
			RoutedEventHandler val2 = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				BtnSkinSave_Checked((MyMenuItem)a0, a1);
			});
			MyMenuItem btnSkinSave = _BtnSkinSave;
			if (btnSkinSave != null)
			{
				((MenuItem)btnSkinSave).Click -= val;
				((MenuItem)btnSkinSave).Checked -= val2;
			}
			_BtnSkinSave = value;
			btnSkinSave = _BtnSkinSave;
			if (btnSkinSave != null)
			{
				((MenuItem)btnSkinSave).Click += val;
				((MenuItem)btnSkinSave).Checked += val2;
			}
		}
	}

	internal virtual MyMenuItem BtnSkinRefresh
	{
		[CompilerGenerated]
		get
		{
			return _BtnSkinRefresh;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				RefreshClick();
			});
			MyMenuItem btnSkinRefresh = _BtnSkinRefresh;
			if (btnSkinRefresh != null)
			{
				((MenuItem)btnSkinRefresh).Click -= val;
			}
			_BtnSkinRefresh = value;
			btnSkinRefresh = _BtnSkinRefresh;
			if (btnSkinRefresh != null)
			{
				((MenuItem)btnSkinRefresh).Click += val;
			}
		}
	}

	internal virtual MyMenuItem BtnSkinCape
	{
		[CompilerGenerated]
		get
		{
			return _BtnSkinCape;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler val = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				BtnSkinCape_Click();
			});
			MyMenuItem btnSkinCape = _BtnSkinCape;
			if (btnSkinCape != null)
			{
				((MenuItem)btnSkinCape).Click -= val;
			}
			_BtnSkinCape = value;
			btnSkinCape = _BtnSkinCape;
			if (btnSkinCape != null)
			{
				((MenuItem)btnSkinCape).Click += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgBack")]
	internal virtual System.Windows.Controls.Image ImgBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ImgFore")]
	internal virtual System.Windows.Controls.Image ImgFore
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
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

	public MySkin()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((UIElement)this).MouseEnter += new MouseEventHandler(PanSkin_MouseEnter);
		((UIElement)this).MouseLeave += new MouseEventHandler(PanSkin_MouseLeave);
		((UIElement)this).MouseLeftButtonDown += new MouseButtonEventHandler(PanSkin_MouseLeftButtonDown);
		((UIElement)this).MouseLeftButtonUp += new MouseButtonEventHandler(PanSkin_MouseLeftButtonUp);
		IsSkinMouseDown = false;
		IsChanging = false;
		InitializeComponent();
	}

	private void PanSkin_MouseEnter(object sender, MouseEventArgs e)
	{
		ModAnimation.AniStart(ModAnimation.AaOpacity(ShadowSkin, 0.8 - ShadowSkin.Opacity, 200, 100), "Skin Shadow");
	}

	private void PanSkin_MouseLeave(object sender, MouseEventArgs e)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		ModAnimation.AniStart(ModAnimation.AaOpacity(ShadowSkin, 0.2 - ShadowSkin.Opacity, 200), "Skin Shadow");
		IsSkinMouseDown = false;
		ModAnimation.AniStart(ModAnimation.AaScaleTransform(this, 1.0 - ((ScaleTransform)((UIElement)this).RenderTransform).ScaleX, 60, 0, new ModAnimation.AniEaseOutFluent()), "Skin Scale");
	}

	private void PanSkin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		IsSkinMouseDown = true;
		ModAnimation.AniStart(ModAnimation.AaScaleTransform(this, 0.9 - ((ScaleTransform)((UIElement)this).RenderTransform).ScaleX, 60, 0, new ModAnimation.AniEaseOutFluent()), "Skin Scale");
	}

	private void PanSkin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		ModAnimation.AniStart(ModAnimation.AaScaleTransform(this, 1.0 - ((ScaleTransform)((UIElement)this).RenderTransform).ScaleX, 60, 0, new ModAnimation.AniEaseOutFluent()), "Skin Scale");
		if (IsSkinMouseDown)
		{
			IsSkinMouseDown = false;
			ClickEvent?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
		}
	}

	public void BtnSkinSave_Click()
	{
		Save(Loader);
	}

	public static void Save(ModLoader.LoaderTask<ModBase.EqualableList<string>, string> Loader)
	{
		string output = Loader.Output;
		if (Loader.State != ModBase.LoadState.Finished)
		{
			ModMain.Hint("皮肤正在获取中，请稍候！", ModMain.HintType.Critical);
			if (Loader.State != ModBase.LoadState.Loading)
			{
				Loader.Start();
			}
			return;
		}
		try
		{
			string text = SystemDialogs.SelectSaveFile("选取保存皮肤的位置", ModBase.GetFileNameFromPath(output), "皮肤图片文件(*.png)|*.png");
			if (text.Contains("\\"))
			{
				File.Delete(text);
				if (output.StartsWith(ModBase.PathImage))
				{
					new MyBitmap(output).Save(text);
				}
				else
				{
					ModBase.CopyFile(output, text);
				}
				ModMain.Hint("皮肤保存成功！", ModMain.HintType.Finish);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "保存皮肤失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnSkinSave_Checked(MyMenuItem sender, RoutedEventArgs e)
	{
		((UIElement)sender).IsEnabled = Operators.CompareString(Address, "", false) == 0;
	}

	public void Load()
	{
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Expected O, but got Unknown
		//IL_041d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Expected O, but got Unknown
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_045a: Expected O, but got Unknown
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected O, but got Unknown
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				Address = Loader.Output;
				if (string.IsNullOrEmpty(Address))
				{
					throw new System.Exception("皮肤加载器 " + Loader.Name + " 没有输出");
				}
				if (!Address.StartsWith(ModBase.PathImage) && !File.Exists(Address))
				{
					throw new FileNotFoundException("皮肤文件未找到", Address);
				}
				MyBitmap myBitmap;
				try
				{
					myBitmap = new MyBitmap(Address);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, $"皮肤文件已损坏：{Address}", ModBase.LogLevel.Hint);
					File.Delete(Address);
					ProjectData.ClearProjectError();
					return;
				}
				((FrameworkElement)ImgBack).Tag = Address;
				int num = (int)Math.Round((double)((System.Drawing.Image)myBitmap.Pic).Width / 64.0);
				if (((System.Drawing.Image)myBitmap.Pic).Width < 32 || ((System.Drawing.Image)myBitmap.Pic).Height < 32)
				{
					ImgFore.Source = null;
					ImgBack.Source = null;
					throw new System.Exception("图片大小不足，长为 " + Conversions.ToString(((System.Drawing.Image)myBitmap.Pic).Height) + "，宽为 " + Conversions.ToString(((System.Drawing.Image)myBitmap.Pic).Width));
				}
				MyBitmap myBitmap2 = null;
				Color pixel;
				if (((System.Drawing.Image)myBitmap.Pic).Width >= 64 && ((System.Drawing.Image)myBitmap.Pic).Height >= 32)
				{
					pixel = myBitmap.Pic.GetPixel(1, 1);
					if (pixel.A != 0)
					{
						pixel = myBitmap.Pic.GetPixel(((System.Drawing.Image)myBitmap.Pic).Width - 1, ((System.Drawing.Image)myBitmap.Pic).Height - 1);
						if (pixel.A != 0)
						{
							pixel = myBitmap.Pic.GetPixel(((System.Drawing.Image)myBitmap.Pic).Width - 2, (int)Math.Round((double)((System.Drawing.Image)myBitmap.Pic).Height / 2.0 - 2.0));
							if (pixel.A != 0 && (!(myBitmap.Pic.GetPixel(1, 1) != myBitmap.Pic.GetPixel(num * 41, num * 9)) || !(myBitmap.Pic.GetPixel(((System.Drawing.Image)myBitmap.Pic).Width - 1, ((System.Drawing.Image)myBitmap.Pic).Height - 1) != myBitmap.Pic.GetPixel(num * 41, num * 9)) || !(myBitmap.Pic.GetPixel(((System.Drawing.Image)myBitmap.Pic).Width - 2, (int)Math.Round((double)((System.Drawing.Image)myBitmap.Pic).Height / 2.0 - 2.0)) != myBitmap.Pic.GetPixel(num * 41, num * 9))))
							{
								ImgFore.Source = null;
								goto IL_0327;
							}
						}
					}
					ImgFore.Source = myBitmap.Clip(num * 40, num * 8, num * 8, num * 8);
					myBitmap2 = myBitmap.Clip(num * 40, num * 8, num * 8, num * 8);
				}
				else
				{
					ImgFore.Source = null;
				}
				goto IL_0327;
				IL_0327:
				ImgBack.Source = myBitmap.Clip(num * 8, num * 8, num * 8, num * 8);
				string text = ModBase.Between(Address, (new string[] { Address.Contains("Images/Skins/") ? "Skins/" : "Skin\\" })[0], ".png");
				string text2 = ModBase.PathTemp + $"Cache\\Skin\\Head\\{text}.png";
				ModProfile.SelectedProfile.SkinHeadId = text;
				ModProfile.SaveProfile();
				if (myBitmap2 == null)
				{
					myBitmap2.Pic = (Bitmap)ScaleToSize(myBitmap.Clip(num * 8, num * 8, num * 8, num * 8), 48, 48);
				}
				else
				{
					myBitmap2 = new MyBitmap
					{
						Pic = new Bitmap(56, 56)
					};
					MyBitmap myBitmap3 = new MyBitmap
					{
						Pic = (Bitmap)ScaleToSize(myBitmap.Clip(num * 40, num * 8, num * 8, num * 8), 56, 56)
					};
					MyBitmap myBitmap4 = new MyBitmap
					{
						Pic = (Bitmap)ScaleToSize(myBitmap.Clip(num * 8, num * 8, num * 8, num * 8), 48, 48)
					};
					int num2 = 0;
					do
					{
						int num3 = 0;
						do
						{
							myBitmap2.Pic.SetPixel(num2 + 4, num3 + 4, myBitmap4.Pic.GetPixel(num2, num3));
							num3++;
						}
						while (num3 <= 47);
						num2++;
					}
					while (num2 <= 47);
					int num4 = 0;
					do
					{
						int num5 = 0;
						do
						{
							pixel = myBitmap3.Pic.GetPixel(num4, num5);
							if (pixel.A != 0)
							{
								myBitmap2.Pic.SetPixel(num4, num5, myBitmap3.Pic.GetPixel(num4, num5));
							}
							num5++;
						}
						while (num5 <= 55);
						num4++;
					}
					while (num4 <= 55);
				}
				if (!Directory.Exists(ModBase.PathTemp + "Cache\\Skin\\Head"))
				{
					Directory.CreateDirectory(ModBase.PathTemp + "Cache\\Skin\\Head");
				}
				if (!File.Exists(text2))
				{
					((Stream)File.Create(text2)).Close();
				}
				myBitmap2.Save(text2);
				ModBase.Log("[Skin] 载入头像成功：" + Loader.Name);
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, string.Concat(new string[5]
				{
					"载入头像失败（",
					Address ?? "null",
					",",
					Loader.Name,
					"）"
				}), ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
		}
	}

	private object ScaleToSize(Bitmap Bitmap, int Width, int Height)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		Bitmap val = new Bitmap(Width, Height);
		Graphics val2 = Graphics.FromImage((System.Drawing.Image)(object)val);
		try
		{
			val2.InterpolationMode = (InterpolationMode)5;
			val2.PixelOffsetMode = (PixelOffsetMode)4;
			val2.DrawImage((System.Drawing.Image)(object)Bitmap, 0, 0, Width, Height);
			return val;
		}
		finally
		{
			((System.IDisposable)val2)?.Dispose();
		}
	}

	public void Clear()
	{
		Address = "";
		ImgFore.Source = null;
		ImgBack.Source = null;
	}

	public void RefreshClick()
	{
		RefreshCache(Loader);
	}

	public static void RefreshCache(ModLoader.LoaderTask<ModBase.EqualableList<string>, string> sender = null)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		_Closure_0024__23_002D0 arg = default(_Closure_0024__23_002D0);
		_Closure_0024__23_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__23_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_sender = sender;
		bool flag = false;
		System.Collections.Generic.IEnumerator<ModLoader.LoaderTask<ModBase.EqualableList<string>, string>> enumerator = default(System.Collections.Generic.IEnumerator<ModLoader.LoaderTask<ModBase.EqualableList<string>, string>>);
		try
		{
			enumerator = PageLaunchLeft.SkinLoaders.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.State == ModBase.LoadState.Loading)
				{
					flag = true;
					break;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		if (ModMain.FrmLaunchLeft != null && flag)
		{
			ModMain.Hint("有正在获取中的皮肤，请稍后再试！");
			return;
		}
		ModBase.RunInThread((Action)([SpecialName] () =>
		{
			try
			{
				ModMain.Hint("正在刷新头像……");
				ModBase.Log("[Skin] 正在清空皮肤缓存");
				if (Directory.Exists(ModBase.PathTemp + "Cache\\Skin"))
				{
					ModBase.DeleteDirectory(ModBase.PathTemp + "Cache\\Skin");
				}
				if (Directory.Exists(ModBase.PathTemp + "Cache\\Uuid"))
				{
					ModBase.DeleteDirectory(ModBase.PathTemp + "Cache\\Uuid");
				}
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Skin\\IndexMs.ini");
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Skin\\IndexAuth.ini");
				ModBase.IniClearCache(ModBase.PathTemp + "Cache\\Uuid\\Mojang.ini");
				ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[] array = ((CS_0024_003C_003E8__locals0._0024VB_0024Local_sender == null) ? new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[2]
				{
					PageLaunchLeft.SkinLegacy,
					PageLaunchLeft.SkinMs
				} : new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[1] { CS_0024_003C_003E8__locals0._0024VB_0024Local_sender });
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					array[i].WaitForExit(null, null, IsForceRestart: true);
				}
				ModMain.Hint("已刷新头像！", ModMain.HintType.Finish);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "刷新皮肤缓存失败", ModBase.LogLevel.Msgbox);
				ProjectData.ClearProjectError();
			}
		}));
	}

	public static void ReloadCache(string SkinAddress)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		_Closure_0024__24_002D0 arg = default(_Closure_0024__24_002D0);
		_Closure_0024__24_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__24_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_SkinAddress = SkinAddress;
		ModBase.RunInThread((Action)([SpecialName] () =>
		{
			try
			{
				ModBase.WriteIni(ModBase.PathTemp + "Cache\\Skin\\IndexMs.ini", ModProfile.SelectedProfile.Uuid, CS_0024_003C_003E8__locals0._0024VB_0024Local_SkinAddress);
				ModBase.Log($"[Skin] 已写入皮肤地址缓存 {ModProfile.SelectedProfile.Uuid} -> {CS_0024_003C_003E8__locals0._0024VB_0024Local_SkinAddress}");
				ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[] array = new ModLoader.LoaderTask<ModBase.EqualableList<string>, string>[2]
				{
					PageLaunchLeft.SkinMs,
					PageLaunchLeft.SkinLegacy
				};
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					array[i].WaitForExit(null, null, IsForceRestart: true);
				}
				ModMain.Hint("更改皮肤成功！", ModMain.HintType.Finish);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "更改正版皮肤后刷新皮肤失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}));
	}

	public void BtnSkinCape_Click()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		if (IsChanging)
		{
			ModMain.Hint("正在更改披风中，请稍候！");
			return;
		}
		if (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Failed)
		{
			ModMain.Hint("登录失败，无法更改披风！", ModMain.HintType.Critical);
			return;
		}
		ModMain.Hint("正在获取披风列表，请稍候……");
		IsChanging = true;
		ModBase.RunInNewThread((Action)([SpecialName] [CompilerGenerated] () =>
		{
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Expected O, but got Unknown
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_015d: Expected O, but got Unknown
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				_Closure_0024__29_002D0 arg = default(_Closure_0024__29_002D0);
				_Closure_0024__29_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__29_002D0(null);
				if (ModLaunch.McLoginMsLoader.State != ModBase.LoadState.Finished)
				{
					ModLaunch.McLoginMsLoader.WaitForExit(ModProfile.GetLoginData());
				}
				if (ModLaunch.McLoginMsLoader.State != ModBase.LoadState.Finished)
				{
					ModMain.Hint("登录失败，无法更改披风！", ModMain.HintType.Critical);
				}
				else
				{
					string accessToken = ModLaunch.McLoginMsLoader.Output.AccessToken;
					_ = ModLaunch.McLoginMsLoader.Output;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_SkinData = (JObject)ModBase.GetJson(ModLaunch.McLoginMsLoader.Output.ProfileJson);
					System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
					try
					{
						enumerator = ((System.Collections.Generic.IEnumerable<JToken>)CS_0024_003C_003E8__locals0._0024VB_0024Local_SkinData["capes"]).GetEnumerator();
						while (((System.Collections.IEnumerator)enumerator).MoveNext())
						{
							JToken current = enumerator.Current;
							if (current["url"] != null)
							{
								string text = string.Format("{0}Cache\\Capes\\{1}.png", (object)ModBase.PathTemp, (object)current["alias"]);
								string text2 = string.Format("{0}Cache\\Capes\\{1}-front.png", (object)ModBase.PathTemp, (object)current["alias"]);
								if (File.Exists(text) && File.Exists(text2))
								{
									current["url"] = text2;
								}
								else
								{
									ModNet.NetDownloadByLoader(current["url"].ToString(), text);
									Rectangle val = new Rectangle(1, 0, 11, 17);
									Bitmap val2 = new Bitmap(val.Width, val.Height);
									System.Drawing.Image val3 = System.Drawing.Image.FromFile(text);
									Graphics.FromImage((System.Drawing.Image)val2).DrawImage(val3, val, val, (GraphicsUnit)2);
									((System.Drawing.Image)val2).Save(text2);
									current["url"] = text2;
								}
							}
						}
					}
					finally
					{
						((System.IDisposable)enumerator)?.Dispose();
					}
					CS_0024_003C_003E8__locals0._0024VB_0024Local_SelId = null;
					ModBase.RunInUiWait((Action)([SpecialName] () =>
					{
						try
						{
							Dictionary<string, string> obj2 = new Dictionary<string, string>();
							obj2.Add("Migrator", "迁移者披风");
							obj2.Add("MapMaker", "Realms 地图制作者披风");
							obj2.Add("Moderator", "Mojira 管理员披风");
							obj2.Add("Translator-Chinese", "Crowdin 中文翻译者披风");
							obj2.Add("Translator", "Crowdin 翻译者披风");
							obj2.Add("Cobalt", "Cobalt 披风");
							obj2.Add("Vanilla", "原版披风");
							obj2.Add("Minecon2011", "Minecon 2011 参与者披风");
							obj2.Add("Minecon2012", "Minecon 2012 参与者披风");
							obj2.Add("Minecon2013", "Minecon 2013 参与者披风");
							obj2.Add("Minecon2015", "Minecon 2015 参与者披风");
							obj2.Add("Minecon2016", "Minecon 2016 参与者披风");
							obj2.Add("Cherry Blossom", "樱花披风");
							obj2.Add("15th Anniversary", "15 周年纪念披风");
							obj2.Add("Purple Heart", "紫色心形披风");
							obj2.Add("Follower's", "追随者披风");
							obj2.Add("MCC 15th Year", "MCC 15 周年披风");
							obj2.Add("Minecraft Experience", "村民救援披风");
							obj2.Add("Mojang Office", "Mojang 办公室披风");
							obj2.Add("Home", "家园披风");
							obj2.Add("Menace", "入侵披风");
							obj2.Add("Yearn", "渴望披风");
							obj2.Add("Common", "普通披风");
							obj2.Add("Pan", "薄煎饼披风");
							obj2.Add("Founder's", "创始人披风");
							Dictionary<string, string> val4 = obj2;
							List<IMyRadio> obj3 = new List<IMyRadio>();
							obj3.Add((IMyRadio)new MyListItem
							{
								Title = "无披风",
								Info = "Null"
							});
							List<IMyRadio> val5 = obj3;
							System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
							try
							{
								enumerator2 = ((System.Collections.Generic.IEnumerable<JToken>)CS_0024_003C_003E8__locals0._0024VB_0024Local_SkinData["capes"]).GetEnumerator();
								while (((System.Collections.IEnumerator)enumerator2).MoveNext())
								{
									JToken current2 = enumerator2.Current;
									string text4 = current2["alias"].ToString();
									if (val4.ContainsKey(text4))
									{
										text4 = val4[text4];
									}
									bool @checked = current2["state"]?.ToString().ToUpper().Equals("ACTIVE") ?? false;
									val5.Add((IMyRadio)new MyListItem
									{
										Title = text4,
										Info = current2["alias"].ToString(),
										Checked = @checked,
										Type = MyListItem.CheckType.RadioBox,
										Logo = (string?)current2["url"],
										LogoScale = 0.8
									});
								}
							}
							finally
							{
								((System.IDisposable)enumerator2)?.Dispose();
							}
							CS_0024_003C_003E8__locals0._0024VB_0024Local_SelId = ModMain.MyMsgBoxSelect(val5, "选择披风", "确定", "取消");
						}
						catch (System.Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							System.Exception ex4 = ex3;
							ModBase.Log(ex4, "获取玩家皮肤列表失败", ModBase.LogLevel.Feedback);
							ProjectData.ClearProjectError();
						}
					}));
					if (CS_0024_003C_003E8__locals0._0024VB_0024Local_SelId.HasValue)
					{
						int? _0024VB_0024Local_SelId = CS_0024_003C_003E8__locals0._0024VB_0024Local_SelId;
						string method = ((_0024VB_0024Local_SelId.HasValue ? new bool?(_0024VB_0024Local_SelId.GetValueOrDefault() == 0) : null).GetValueOrDefault() ? "DELETE" : "PUT");
						_0024VB_0024Local_SelId = CS_0024_003C_003E8__locals0._0024VB_0024Local_SelId;
						string data = ((_0024VB_0024Local_SelId.HasValue ? new bool?(_0024VB_0024Local_SelId.GetValueOrDefault() == 0) : null).GetValueOrDefault() ? "" : new JObject(new JProperty("capeId", CS_0024_003C_003E8__locals0._0024VB_0024Local_SkinData["capes"][checked(CS_0024_003C_003E8__locals0._0024VB_0024Local_SelId - 1)]["id"])).ToString(Formatting.None));
						Dictionary<string, string> obj = new Dictionary<string, string>();
						obj.Add("Authorization", "Bearer " + accessToken);
						string text3 = ModNet.NetRequestRetry("https://api.minecraftservices.com/minecraft/profile/capes/active", method, data, "application/json", DontRetryOnRefused: true, obj);
						if (text3.Contains("\"errorMessage\""))
						{
							ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject((object)"更改披风失败：", NewLateBinding.LateIndexGet(ModBase.GetJson(text3), new object[] { "errorMessage" }, (string[])null))), ModMain.HintType.Critical);
						}
						else
						{
							ModMain.Hint("更改披风成功！等待一段时间后将会生效……", ModMain.HintType.Finish);
						}
					}
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "更改披风失败", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
			finally
			{
				IsChanging = false;
			}
		}), "Cape Change", (ThreadPriority)2);
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagelaunch/myskin.xaml", (UriKind)2);
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
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			ShadowSkin = (DropShadowEffect)target;
			break;
		case 2:
			BtnSkinSave = (MyMenuItem)target;
			break;
		case 3:
			BtnSkinRefresh = (MyMenuItem)target;
			break;
		case 4:
			BtnSkinCape = (MyMenuItem)target;
			break;
		case 5:
			ImgBack = (Image)target;
			break;
		case 6:
			ImgFore = (Image)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
