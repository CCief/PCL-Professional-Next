using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.UI;
using PCL.Core.Utils;
using PCL.Core.Utils.Exts;

namespace PCL;

[DesignerGenerated]
public class PageSetupUI : MyPageRight, IComponentConnector
{
	public class CustomFontProperties
	{
		[field: CompilerGenerated]
		public string Name
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public FontFamily Font
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public string Tag
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine___Lambda_0024__10_002D0 : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal PageSetupUI _0024VB_0024Me;

		internal _Closure_0024__10_002D0 _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;

		internal System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, FontFamily>> _0024S1;

		internal _Closure_0024__10_002D1 _0024VB_0024ResumableLocal__0024VB_0024Closure__00242;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Expected O, but got Unknown
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Expected O, but got Unknown
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num != 0)
				{
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00242 = new _Closure_0024__10_002D1(_0024VB_0024ResumableLocal__0024VB_0024Closure__00242);
					if (((Collection<CustomFontProperties>)(object)_0024VB_0024Me.CustomFontCollection).Count != 0)
					{
						goto IL_01f9;
					}
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240 = new _Closure_0024__10_002D0(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240);
					((UIElement)_0024VB_0024Me.ComboUiFont).IsEnabled = false;
					((Collection<CustomFontProperties>)(object)_0024VB_0024Me.CustomFontCollection).Add(new CustomFontProperties
					{
						Name = "加载中..."
					});
					((Selector)_0024VB_0024Me.ComboUiFont).SelectedIndex = 0;
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_availableFonts = new List<KeyValuePair<string, FontFamily>>();
					val = System.Threading.Tasks.Task.Run((Action)([SpecialName] () =>
					{
						//IL_007b: Unknown result type (might be due to invalid IL or missing references)
						//IL_006e: Unknown result type (might be due to invalid IL or missing references)
						//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
						System.Collections.Generic.IEnumerator<FontFamily> enumerator = default(System.Collections.Generic.IEnumerator<FontFamily>);
						try
						{
							enumerator = ((System.Collections.Generic.IEnumerable<FontFamily>)Fonts.SystemFontFamilies).GetEnumerator();
							System.Collections.Generic.IEnumerator<Typeface> enumerator2 = default(System.Collections.Generic.IEnumerator<Typeface>);
							while (((System.Collections.IEnumerator)enumerator).MoveNext())
							{
								FontFamily current2 = enumerator.Current;
								try
								{
									if (!current2.Source.StartsWith("Global "))
									{
										try
										{
											enumerator2 = ((System.Collections.Generic.IEnumerable<Typeface>)current2.GetTypefaces()).GetEnumerator();
											while (((System.Collections.IEnumerator)enumerator2).MoveNext())
											{
												Typeface current3 = enumerator2.Current;
												GlyphTypeface val2 = null;
												current3.TryGetGlyphTypeface(out val2);
												if (val2 == null)
												{
													throw new NullReferenceException(string.Format("字形 {0} 无法加载", (object)current3.FaceNames.GetForCurrentUiCulture("(unknown)")));
												}
												new GlyphTypeface(val2.FontUri);
											}
										}
										finally
										{
											((System.IDisposable)enumerator2)?.Dispose();
										}
										_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_availableFonts.Add(new KeyValuePair<string, FontFamily>(current2.FamilyNames.GetForCurrentUiCulture(), current2));
									}
								}
								catch (System.Exception ex2)
								{
									ProjectData.SetProjectError(ex2);
									System.Exception ex3 = ex2;
									ModBase.Log(ex3, "发现了一个无法加载的异常的字体：" + current2.Source);
									ProjectData.ClearProjectError();
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator)?.Dispose();
						}
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_availableFonts.Sort((Comparison<KeyValuePair<string, FontFamily>>)([SpecialName] (KeyValuePair<string, FontFamily> l, KeyValuePair<string, FontFamily> r) => string.Compare(l.Key, r.Key)));
					})).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine___Lambda_0024__10_002D0>(ref val, ref _this);
						return;
					}
				}
				else
				{
					num = (_0024State = -1);
					val = _0024A0;
					_0024A0 = default(TaskAwaiter);
				}
				val.GetResult();
				val = default(TaskAwaiter);
				((Collection<CustomFontProperties>)(object)_0024VB_0024Me.CustomFontCollection).Clear();
				((Collection<CustomFontProperties>)(object)_0024VB_0024Me.CustomFontCollection).Add(new CustomFontProperties
				{
					Name = "默认",
					Font = new FontFamily(new Uri("pack://application:,,,/"), "./Resources/#PCL English, Segoe UI, Microsoft YaHei UI"),
					Tag = ""
				});
				try
				{
					_0024S1 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_availableFonts.GetEnumerator();
					while (_0024S1.MoveNext())
					{
						KeyValuePair<string, FontFamily> current = _0024S1.Current;
						((Collection<CustomFontProperties>)(object)_0024VB_0024Me.CustomFontCollection).Add(new CustomFontProperties
						{
							Name = current.Key,
							Font = current.Value,
							Tag = current.Value.Source
						});
					}
				}
				finally
				{
					if (num < 0)
					{
						((System.IDisposable)_0024S1).Dispose();
					}
				}
				((UIElement)_0024VB_0024Me.ComboUiFont).IsEnabled = true;
				goto IL_01f9;
				IL_01f9:
				_0024VB_0024ResumableLocal__0024VB_0024Closure__00242._0024VB_0024Local_targetFont = Conversions.ToString(RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("UiFont")));
				CustomFontProperties customFontProperties = Enumerable.FirstOrDefault<CustomFontProperties>((System.Collections.Generic.IEnumerable<CustomFontProperties>)_0024VB_0024Me.CustomFontCollection, (Func<CustomFontProperties, bool>)([SpecialName] (CustomFontProperties i) => Operators.CompareString(i.Tag, _0024VB_0024ResumableLocal__0024VB_0024Closure__00242._0024VB_0024Local_targetFont, false) == 0));
				if (customFontProperties == null)
				{
					((Selector)_0024VB_0024Me.ComboUiFont).SelectedIndex = 0;
				}
				else
				{
					((Selector)_0024VB_0024Me.ComboUiFont).SelectedItem = customFontProperties;
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception exception = ex;
				_0024State = -2;
				_0024Builder.SetException(exception);
				ProjectData.ClearProjectError();
				return;
			}
			num = (_0024State = -2);
			_0024Builder.SetResult();
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal new sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static RoutedEventHandler _0024IR2_002D1;

		public static Comparison<KeyValuePair<string, FontFamily>> _0024I10_002D2;

		public static Func<FileInfo, bool> _0024I22_002D0;

		public static Func<FileInfo, string> _0024I22_002D1;

		public static EventHandler<ExceptionRoutedEventArgs> _0024I22_002D2;

		public static Action _0024I29_002D1;

		public static Action _0024I29_002D0;

		public static VB_0024AnonymousDelegate_22<object, object> _0024I52_002D0;

		public static VB_0024AnonymousDelegate_22<object, object> _0024I52_002D1;

		public static VB_0024AnonymousDelegate_22<object, object> _0024I52_002D2;

		public static VB_0024AnonymousDelegate_22<object, object> _0024I52_002D3;

		public static VB_0024AnonymousDelegate_24<int, string> _0024I52_002D4;

		public static VB_0024AnonymousDelegate_24<int, string> _0024I52_002D5;

		public static VB_0024AnonymousDelegate_22<object, object> _0024I52_002D6;

		public static VB_0024AnonymousDelegate_22<object, object> _0024I52_002D7;

		public static VB_0024AnonymousDelegate_22<object, object> _0024I52_002D8;

		public static VB_0024AnonymousDelegate_22<object, object> _0024I52_002D9;

		public static MySlider.ChangeEventHandler _0024IR68_002D2;

		public static IMyRadio.CheckEventHandler _0024IR108_002D7;

		public static IMyRadio.CheckEventHandler _0024IR112_002D8;

		public static IMyRadio.CheckEventHandler _0024IR116_002D9;

		public static IMyRadio.CheckEventHandler _0024IR120_002D10;

		public static IMyRadio.CheckEventHandler _0024IR124_002D11;

		public static IMyRadio.CheckEventHandler _0024IR128_002D12;

		public static IMyRadio.CheckEventHandler _0024IR140_002D13;

		public static IMyRadio.CheckEventHandler _0024IR144_002D14;

		public static IMyRadio.CheckEventHandler _0024IR148_002D15;

		public static IMyRadio.CheckEventHandler _0024IR152_002D16;

		public static IMyRadio.CheckEventHandler _0024IR156_002D17;

		public static IMyRadio.CheckEventHandler _0024IR164_002D20;

		public static IMyRadio.CheckEventHandler _0024IR172_002D23;

		public static IMyRadio.CheckEventHandler _0024IR176_002D24;

		public static IMyRadio.CheckEventHandler _0024IR184_002D27;

		public static IMyRadio.CheckEventHandler _0024IR188_002D28;

		public static MyCheckBox.ChangeEventHandler _0024IR192_002D29;

		public static MyCheckBox.ChangeEventHandler _0024IR200_002D30;

		public static MySlider.ChangeEventHandler _0024IR208_002D31;

		public static MyCheckBox.ChangeEventHandler _0024IR216_002D33;

		public static MyCheckBox.ChangeEventHandler _0024IR220_002D34;

		public static MyCheckBox.ChangeEventHandler _0024IR228_002D35;

		public static MySlider.ChangeEventHandler _0024IR236_002D36;

		public static MySlider.ChangeEventHandler _0024IR240_002D37;

		public static SelectionChangedEventHandler _0024IR244_002D38;

		public static SelectionChangedEventHandler _0024IR256_002D39;

		public static MySlider.ChangeEventHandler _0024IR264_002D40;

		public static MySlider.ChangeEventHandler _0024IR272_002D41;

		public static MyCheckBox.ChangeEventHandler _0024IR276_002D42;

		public static MyCheckBox.ChangeEventHandler _0024IR280_002D43;

		public static MySlider.ChangeEventHandler _0024IR308_002D44;

		public static MyCheckBox.ChangeEventHandler _0024IR316_002D45;

		public static MyCheckBox.ChangeEventHandler _0024IR320_002D46;

		public static MyCheckBox.ChangeEventHandler _0024IR324_002D47;

		public static MyCheckBox.ChangeEventHandler _0024IR328_002D49;

		public static MyCheckBox.ChangeEventHandler _0024IR332_002D51;

		public static IMyRadio.CheckEventHandler _0024IR352_002D52;

		public static IMyRadio.CheckEventHandler _0024IR356_002D53;

		public static IMyRadio.CheckEventHandler _0024IR360_002D54;

		public static IMyRadio.CheckEventHandler _0024IR364_002D55;

		public static MyCheckBox.ChangeEventHandler _0024IR368_002D56;

		public static RoutedEventHandler _0024IR376_002D57;

		public static IMyRadio.CheckEventHandler _0024IR396_002D58;

		public static IMyRadio.CheckEventHandler _0024IR400_002D59;

		public static IMyRadio.CheckEventHandler _0024IR404_002D60;

		public static IMyRadio.CheckEventHandler _0024IR408_002D61;

		public static RoutedEventHandler _0024IR440_002D63;

		public static SelectionChangedEventHandler _0024IR448_002D64;

		public static MyCheckBox.ChangeEventHandler _0024IR460_002D65;

		public static MyCheckBox.ChangeEventHandler _0024IR464_002D66;

		public static MyCheckBox.ChangeEventHandler _0024IR468_002D67;

		public static MyCheckBox.ChangeEventHandler _0024IR472_002D69;

		public static MyCheckBox.ChangeEventHandler _0024IR476_002D71;

		public static MyCheckBox.ChangeEventHandler _0024IR480_002D73;

		public static MyCheckBox.ChangeEventHandler _0024IR484_002D75;

		public static MyCheckBox.ChangeEventHandler _0024IR488_002D77;

		public static MyCheckBox.ChangeEventHandler _0024IR492_002D78;

		public static MyCheckBox.ChangeEventHandler _0024IR496_002D79;

		public static MyCheckBox.ChangeEventHandler _0024IR500_002D80;

		public static MyCheckBox.ChangeEventHandler _0024IR504_002D81;

		public static MyCheckBox.ChangeEventHandler _0024IR508_002D82;

		public static MyCheckBox.ChangeEventHandler _0024IR512_002D83;

		public static MyCheckBox.ChangeEventHandler _0024IR516_002D84;

		public static MyCheckBox.ChangeEventHandler _0024IR520_002D85;

		public static MyCheckBox.ChangeEventHandler _0024IR524_002D86;

		public static MyCheckBox.ChangeEventHandler _0024IR528_002D87;

		public static MyCheckBox.ChangeEventHandler _0024IR532_002D88;

		public static MyCheckBox.ChangeEventHandler _0024IR536_002D89;

		public static MyCheckBox.ChangeEventHandler _0024IR540_002D90;

		public static MyCheckBox.ChangeEventHandler _0024IR544_002D91;

		public static MyCheckBox.ChangeEventHandler _0024IR548_002D92;

		public static MyCheckBox.ChangeEventHandler _0024IR552_002D93;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__R2_002D1(object a0, RoutedEventArgs a1)
		{
			HiddenRefresh();
		}

		[SpecialName]
		internal int _Lambda_0024__10_002D2(KeyValuePair<string, FontFamily> l, KeyValuePair<string, FontFamily> r)
		{
			return string.Compare(l.Key, r.Key);
		}

		[SpecialName]
		internal bool _Lambda_0024__22_002D0(FileInfo file)
		{
			if (!((FileSystemInfo)file).Extension.Equals(".ini", (StringComparison)5))
			{
				return !((FileSystemInfo)file).Extension.Equals(".db", (StringComparison)5);
			}
			return false;
		}

		[SpecialName]
		internal string _Lambda_0024__22_002D1(FileInfo file)
		{
			return ((FileSystemInfo)file).FullName;
		}

		[SpecialName]
		internal void _Lambda_0024__22_002D2(object sender, ExceptionRoutedEventArgs e)
		{
			System.Exception errorException = e.ErrorException;
			string text = ModMain.FrmMain.VideoBack.Source.ToString();
			if (ModMain.FrmMain.VideoBack.Source != null)
			{
				ModVideoBack.VideoStop();
				if (errorException.Message.Contains("0xC00D109B"))
				{
					ModBase.Log("刷新背景内容失败，该视频文件可能并非 H.264（AVC） 格式。\r\n你可以尝试使用视频转码工具打开视频文件并设定目标格式为 H.264（AVC） ，然后转码该视频。\r\n文件：" + text, ModBase.LogLevel.Msgbox);
				}
				else
				{
					ModBase.Log(errorException, "刷新背景内容失败（" + text + "）", ModBase.LogLevel.Msgbox);
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__29_002D0()
		{
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Expected O, but got Unknown
			ModMain.Hint("正在删除背景音乐……");
			ModMusic.MusicNAudio = null;
			ModMusic.MusicWaitingList = new List<string>();
			ModMusic.MusicAllList = new List<string>();
			Thread.Sleep(200);
			try
			{
				ModBase.DeleteDirectory(ModBase.ExePath + "PCL\\Musics");
				ModMain.Hint("背景音乐已删除！", ModMain.HintType.Finish);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "删除背景音乐失败", ModBase.LogLevel.Msgbox);
				ProjectData.ClearProjectError();
			}
			try
			{
				Directory.CreateDirectory(ModBase.ExePath + "PCL\\Musics");
				object action;
				if (_0024I29_002D1 != null)
				{
					action = _0024I29_002D1;
				}
				else
				{
					Action val = [SpecialName] () =>
					{
						ModMusic.MusicRefreshPlay(ShowHint: false);
					};
					_0024I29_002D1 = val;
					action = (object)val;
				}
				ModBase.RunInUi((Action)action);
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "重建背景音乐文件夹失败", ModBase.LogLevel.Msgbox);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__29_002D1()
		{
			ModMusic.MusicRefreshPlay(ShowHint: false);
		}

		[SpecialName]
		internal object _Lambda_0024__52_002D0(object v)
		{
			return Operators.ConcatenateObject(NewLateBinding.LateGet((object)null, typeof(Math), "Ceiling", new object[] { Operators.MultiplyObject(v, (object)0.1) }, (string[])null, (System.Type[])null, (bool[])null), (object)"%");
		}

		[SpecialName]
		internal object _Lambda_0024__52_002D1(object v)
		{
			return Operators.ConcatenateObject(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[] { Operators.AddObject((object)40, Operators.MultiplyObject(v, (object)0.1)) }, (string[])null, (System.Type[])null, (bool[])null), (object)"%");
		}

		[SpecialName]
		internal object _Lambda_0024__52_002D2(object v)
		{
			return Operators.ConcatenateObject(v, (object)"°");
		}

		[SpecialName]
		internal object _Lambda_0024__52_002D3(object v)
		{
			return Operators.ConcatenateObject(v, (object)"%");
		}

		[SpecialName]
		internal string _Lambda_0024__52_002D4(int Value)
		{
			checked
			{
				if (Value > 90)
				{
					return "+" + Conversions.ToString(Value - 90);
				}
				if (Value == 90)
				{
					return Conversions.ToString(0);
				}
				return Conversions.ToString(Value - 90);
			}
		}

		[SpecialName]
		internal string _Lambda_0024__52_002D5(int Value)
		{
			checked
			{
				if (Value > 20)
				{
					return "+" + Conversions.ToString(Value - 20);
				}
				if (Value == 20)
				{
					return Conversions.ToString(0);
				}
				return Conversions.ToString(Value - 20);
			}
		}

		[SpecialName]
		internal object _Lambda_0024__52_002D6(object v)
		{
			return Operators.ConcatenateObject(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[] { Operators.MultiplyObject(v, (object)0.1) }, (string[])null, (System.Type[])null, (bool[])null), (object)"%");
		}

		[SpecialName]
		internal object _Lambda_0024__52_002D7(object v)
		{
			return Operators.ConcatenateObject(v, (object)" 像素");
		}

		[SpecialName]
		internal object _Lambda_0024__52_002D8(object v)
		{
			return Operators.ConcatenateObject(v, (object)" 像素");
		}

		[SpecialName]
		internal object _Lambda_0024__52_002D9(object v)
		{
			return Operators.ConcatenateObject(v, (object)"%");
		}

		[SpecialName]
		internal void _Lambda_0024__R68_002D2(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R108_002D7(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R112_002D8(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R116_002D9(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R120_002D10(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R124_002D11(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R128_002D12(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R140_002D13(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R144_002D14(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R148_002D15(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R152_002D16(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R156_002D17(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R164_002D20(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R172_002D23(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R176_002D24(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R184_002D27(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R188_002D28(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R192_002D29(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R200_002D30(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R208_002D31(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R216_002D33(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R220_002D34(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R228_002D35(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R236_002D36(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R240_002D37(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R244_002D38(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R256_002D39(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R264_002D40(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R272_002D41(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R276_002D42(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R280_002D43(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R308_002D44(object a0, bool a1)
		{
			SliderChange((MySlider)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R316_002D45(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R320_002D46(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R324_002D47(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R328_002D49(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R332_002D51(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R352_002D52(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R356_002D53(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R360_002D54(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R364_002D55(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R368_002D56(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R376_002D57(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R396_002D58(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R400_002D59(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R404_002D60(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R408_002D61(object a0, ModBase.RouteEventArgs a1)
		{
			RadioBoxChange((MyRadioBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R440_002D63(object a0, RoutedEventArgs a1)
		{
			TextBoxChange((MyTextBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R448_002D64(object a0, SelectionChangedEventArgs a1)
		{
			ComboChange((MyComboBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R460_002D65(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R464_002D66(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R468_002D67(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R472_002D69(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R476_002D71(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R480_002D73(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R484_002D75(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R488_002D77(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R492_002D78(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R496_002D79(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R500_002D80(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R504_002D81(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R508_002D82(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R512_002D83(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R516_002D84(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R520_002D85(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R524_002D86(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R528_002D87(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R532_002D88(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R536_002D89(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R540_002D90(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R544_002D91(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R548_002D92(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}

		[SpecialName]
		internal void _Lambda_0024__R552_002D93(object a0, bool a1)
		{
			CheckBoxChange((MyCheckBox)a0, a1);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__10_002D0
	{
		public List<KeyValuePair<string, FontFamily>> _0024VB_0024Local_availableFonts;

		public _Closure_0024__10_002D0(_Closure_0024__10_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_availableFonts = arg0._0024VB_0024Local_availableFonts;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			System.Collections.Generic.IEnumerator<FontFamily> enumerator = default(System.Collections.Generic.IEnumerator<FontFamily>);
			try
			{
				enumerator = ((System.Collections.Generic.IEnumerable<FontFamily>)Fonts.SystemFontFamilies).GetEnumerator();
				System.Collections.Generic.IEnumerator<Typeface> enumerator2 = default(System.Collections.Generic.IEnumerator<Typeface>);
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					FontFamily current = enumerator.Current;
					try
					{
						if (current.Source.StartsWith("Global "))
						{
							continue;
						}
						try
						{
							enumerator2 = ((System.Collections.Generic.IEnumerable<Typeface>)current.GetTypefaces()).GetEnumerator();
							while (((System.Collections.IEnumerator)enumerator2).MoveNext())
							{
								Typeface current2 = enumerator2.Current;
								GlyphTypeface val = null;
								current2.TryGetGlyphTypeface(out val);
								if (val == null)
								{
									throw new NullReferenceException(string.Format("字形 {0} 无法加载", (object)current2.FaceNames.GetForCurrentUiCulture("(unknown)")));
								}
								new GlyphTypeface(val.FontUri);
							}
						}
						finally
						{
							((System.IDisposable)enumerator2)?.Dispose();
						}
						_0024VB_0024Local_availableFonts.Add(new KeyValuePair<string, FontFamily>(current.FamilyNames.GetForCurrentUiCulture(), current));
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "发现了一个无法加载的异常的字体：" + current.Source);
						ProjectData.ClearProjectError();
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			_0024VB_0024Local_availableFonts.Sort((Comparison<KeyValuePair<string, FontFamily>>)([SpecialName] (KeyValuePair<string, FontFamily> l, KeyValuePair<string, FontFamily> r) => string.Compare(l.Key, r.Key)));
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__10_002D1
	{
		public string _0024VB_0024Local_targetFont;

		public _Closure_0024__10_002D1(_Closure_0024__10_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_targetFont = arg0._0024VB_0024Local_targetFont;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__3(CustomFontProperties i)
		{
			return Operators.CompareString(i.Tag, _0024VB_0024Local_targetFont, false) == 0;
		}
	}

	public bool IsLoaded;

	private static bool _HiddenForceShow = false;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderLauncherOpacity")]
	private MySlider _SliderLauncherOpacity;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderLauncherHue")]
	private MySlider _SliderLauncherHue;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderLauncherDelta")]
	private MySlider _SliderLauncherDelta;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderLauncherSat")]
	private MySlider _SliderLauncherSat;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderLauncherLight")]
	private MySlider _SliderLauncherLight;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme0")]
	private MyRadioBox _RadioLauncherTheme0;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme1")]
	private MyRadioBox _RadioLauncherTheme1;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme2")]
	private MyRadioBox _RadioLauncherTheme2;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme3")]
	private MyRadioBox _RadioLauncherTheme3;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme4")]
	private MyRadioBox _RadioLauncherTheme4;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme5")]
	private MyRadioBox _RadioLauncherTheme5;

	[CompilerGenerated]
	[AccessedThroughProperty("LabLauncherTheme5Unlock")]
	private TextBlock _LabLauncherTheme5Unlock;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme12")]
	private MyRadioBox _RadioLauncherTheme12;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme6")]
	private MyRadioBox _RadioLauncherTheme6;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme7")]
	private MyRadioBox _RadioLauncherTheme7;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme13")]
	private MyRadioBox _RadioLauncherTheme13;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme8")]
	private MyRadioBox _RadioLauncherTheme8;

	[CompilerGenerated]
	[AccessedThroughProperty("LabLauncherTheme8Copy")]
	private TextBlock _LabLauncherTheme8Copy;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme9")]
	private MyRadioBox _RadioLauncherTheme9;

	[CompilerGenerated]
	[AccessedThroughProperty("LabLauncherTheme9Copy")]
	private TextBlock _LabLauncherTheme9Copy;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme10")]
	private MyRadioBox _RadioLauncherTheme10;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme11")]
	private MyRadioBox _RadioLauncherTheme11;

	[CompilerGenerated]
	[AccessedThroughProperty("LabLauncherTheme11Click")]
	private TextBlock _LabLauncherTheme11Click;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme14")]
	private MyRadioBox _RadioLauncherTheme14;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLauncherTheme15")]
	private MyRadioBox _RadioLauncherTheme15;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckDarkMode")]
	private MyCheckBox _CheckDarkMode;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckAcrylicEnabled")]
	private MyCheckBox _CheckAcrylicEnabled;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderAcrylicOpacity")]
	private MySlider _SliderAcrylicOpacity;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboUiFont")]
	private MyComboBox _ComboUiFont;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckLauncherLogo")]
	private MyCheckBox _CheckLauncherLogo;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckLockWindowSize")]
	private MyCheckBox _CheckLockWindowSize;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckBlur")]
	private MyCheckBox _CheckBlur;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderBlurValue")]
	private MySlider _SliderBlurValue;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderBlurSamplingRate")]
	private MySlider _SliderBlurSamplingRate;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboBlurType")]
	private MyComboBox _ComboBlurType;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboBackgroundSuit")]
	private MyComboBox _ComboBackgroundSuit;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderBackgroundOpacity")]
	private MySlider _SliderBackgroundOpacity;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderBackgroundBlur")]
	private MySlider _SliderBackgroundBlur;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckAutoPauseVideo")]
	private MyCheckBox _CheckAutoPauseVideo;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckBackgroundColorful")]
	private MyCheckBox _CheckBackgroundColorful;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnBackgroundOpen")]
	private MyButton _BtnBackgroundOpen;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnBackgroundRefresh")]
	private MyButton _BtnBackgroundRefresh;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnBackgroundClear")]
	private MyButton _BtnBackgroundClear;

	[CompilerGenerated]
	[AccessedThroughProperty("SliderMusicVolume")]
	private MySlider _SliderMusicVolume;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckMusicRandom")]
	private MyCheckBox _CheckMusicRandom;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckMusicAuto")]
	private MyCheckBox _CheckMusicAuto;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckMusicStart")]
	private MyCheckBox _CheckMusicStart;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckMusicStop")]
	private MyCheckBox _CheckMusicStop;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckMusicSMTC")]
	private MyCheckBox _CheckMusicSMTC;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnMusicOpen")]
	private MyButton _BtnMusicOpen;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnMusicRefresh")]
	private MyButton _BtnMusicRefresh;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnMusicClear")]
	private MyButton _BtnMusicClear;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLogoType0")]
	private MyRadioBox _RadioLogoType0;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLogoType1")]
	private MyRadioBox _RadioLogoType1;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLogoType2")]
	private MyRadioBox _RadioLogoType2;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioLogoType3")]
	private MyRadioBox _RadioLogoType3;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckLogoLeft")]
	private MyCheckBox _CheckLogoLeft;

	[CompilerGenerated]
	[AccessedThroughProperty("TextLogoText")]
	private MyTextBox _TextLogoText;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnLogoChange")]
	private MyButton _BtnLogoChange;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnLogoDelete")]
	private MyButton _BtnLogoDelete;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioCustomType0")]
	private MyRadioBox _RadioCustomType0;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioCustomType3")]
	private MyRadioBox _RadioCustomType3;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioCustomType1")]
	private MyRadioBox _RadioCustomType1;

	[CompilerGenerated]
	[AccessedThroughProperty("RadioCustomType2")]
	private MyRadioBox _RadioCustomType2;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnCustomRefresh")]
	private MyButton _BtnCustomRefresh;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnCustomFile")]
	private MyButton _BtnCustomFile;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnCustomTutorial")]
	private MyButton _BtnCustomTutorial;

	[CompilerGenerated]
	[AccessedThroughProperty("TextCustomNet")]
	private MyTextBox _TextCustomNet;

	[CompilerGenerated]
	[AccessedThroughProperty("ComboCustomPreset")]
	private MyComboBox _ComboCustomPreset;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnGotoHomepageMarket")]
	private MyIconTextButton _BtnGotoHomepageMarket;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenPageDownload")]
	private MyCheckBox _CheckHiddenPageDownload;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenPageLink")]
	private MyCheckBox _CheckHiddenPageLink;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenPageSetup")]
	private MyCheckBox _CheckHiddenPageSetup;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenPageOther")]
	private MyCheckBox _CheckHiddenPageOther;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenSetupLaunch")]
	private MyCheckBox _CheckHiddenSetupLaunch;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenSetupUI")]
	private MyCheckBox _CheckHiddenSetupUI;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenSetupSystem")]
	private MyCheckBox _CheckHiddenSetupSystem;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenOtherHelp")]
	private MyCheckBox _CheckHiddenOtherHelp;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenOtherAbout")]
	private MyCheckBox _CheckHiddenOtherAbout;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenOtherTest")]
	private MyCheckBox _CheckHiddenOtherTest;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenOtherFeedback")]
	private MyCheckBox _CheckHiddenOtherFeedback;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenOtherVote")]
	private MyCheckBox _CheckHiddenOtherVote;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenFunctionSelect")]
	private MyCheckBox _CheckHiddenFunctionSelect;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenFunctionModUpdate")]
	private MyCheckBox _CheckHiddenFunctionModUpdate;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenFunctionHidden")]
	private MyCheckBox _CheckHiddenFunctionHidden;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenVersionEdit")]
	private MyCheckBox _CheckHiddenVersionEdit;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenVersionExport")]
	private MyCheckBox _CheckHiddenVersionExport;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenVersionSave")]
	private MyCheckBox _CheckHiddenVersionSave;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenVersionScreenshot")]
	private MyCheckBox _CheckHiddenVersionScreenshot;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenVersionMod")]
	private MyCheckBox _CheckHiddenVersionMod;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenVersionResourcePack")]
	private MyCheckBox _CheckHiddenVersionResourcePack;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenVersionShader")]
	private MyCheckBox _CheckHiddenVersionShader;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenVersionSchematic")]
	private MyCheckBox _CheckHiddenVersionSchematic;

	[CompilerGenerated]
	[AccessedThroughProperty("CheckHiddenVersionServer")]
	private MyCheckBox _CheckHiddenVersionServer;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	public ObservableCollection<CustomFontProperties> CustomFontCollection
	{
		[CompilerGenerated]
		get;
	}

	public static bool HiddenForceShow
	{
		get
		{
			return _HiddenForceShow;
		}
		set
		{
			_HiddenForceShow = value;
			HiddenRefresh();
		}
	}

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
	[field: AccessedThroughProperty("CardLauncher")]
	internal virtual MyCard CardLauncher
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MySlider SliderLauncherOpacity
	{
		[CompilerGenerated]
		get
		{
			return _SliderLauncherOpacity;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				SliderChange((MySlider)a0, a1);
			};
			MySlider sliderLauncherOpacity = _SliderLauncherOpacity;
			if (sliderLauncherOpacity != null)
			{
				sliderLauncherOpacity.Change -= obj;
			}
			_SliderLauncherOpacity = value;
			sliderLauncherOpacity = _SliderLauncherOpacity;
			if (sliderLauncherOpacity != null)
			{
				sliderLauncherOpacity.Change += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLauncherHue")]
	internal virtual TextBlock LabLauncherHue
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MySlider SliderLauncherHue
	{
		[CompilerGenerated]
		get
		{
			return _SliderLauncherHue;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				HSL_Change();
			};
			MySlider sliderLauncherHue = _SliderLauncherHue;
			if (sliderLauncherHue != null)
			{
				sliderLauncherHue.Change -= obj;
			}
			_SliderLauncherHue = value;
			sliderLauncherHue = _SliderLauncherHue;
			if (sliderLauncherHue != null)
			{
				sliderLauncherHue.Change += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLauncherDelta")]
	internal virtual TextBlock LabLauncherDelta
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MySlider SliderLauncherDelta
	{
		[CompilerGenerated]
		get
		{
			return _SliderLauncherDelta;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				HSL_Change();
			};
			MySlider sliderLauncherDelta = _SliderLauncherDelta;
			if (sliderLauncherDelta != null)
			{
				sliderLauncherDelta.Change -= obj;
			}
			_SliderLauncherDelta = value;
			sliderLauncherDelta = _SliderLauncherDelta;
			if (sliderLauncherDelta != null)
			{
				sliderLauncherDelta.Change += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLauncherSat")]
	internal virtual TextBlock LabLauncherSat
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MySlider SliderLauncherSat
	{
		[CompilerGenerated]
		get
		{
			return _SliderLauncherSat;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				HSL_Change();
			};
			MySlider sliderLauncherSat = _SliderLauncherSat;
			if (sliderLauncherSat != null)
			{
				sliderLauncherSat.Change -= obj;
			}
			_SliderLauncherSat = value;
			sliderLauncherSat = _SliderLauncherSat;
			if (sliderLauncherSat != null)
			{
				sliderLauncherSat.Change += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabLauncherLight")]
	internal virtual TextBlock LabLauncherLight
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MySlider SliderLauncherLight
	{
		[CompilerGenerated]
		get
		{
			return _SliderLauncherLight;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				HSL_Change();
			};
			MySlider sliderLauncherLight = _SliderLauncherLight;
			if (sliderLauncherLight != null)
			{
				sliderLauncherLight.Change -= obj;
			}
			_SliderLauncherLight = value;
			sliderLauncherLight = _SliderLauncherLight;
			if (sliderLauncherLight != null)
			{
				sliderLauncherLight.Change += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLauncherTheme")]
	internal virtual Grid PanLauncherTheme
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyRadioBox RadioLauncherTheme0
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme0;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme0;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
			}
			_RadioLauncherTheme0 = value;
			radioLauncherTheme = _RadioLauncherTheme0;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme1
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme1;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme1;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
			}
			_RadioLauncherTheme1 = value;
			radioLauncherTheme = _RadioLauncherTheme1;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme2
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme2;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme2;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
			}
			_RadioLauncherTheme2 = value;
			radioLauncherTheme = _RadioLauncherTheme2;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme3
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme3;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme3;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
			}
			_RadioLauncherTheme3 = value;
			radioLauncherTheme = _RadioLauncherTheme3;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme4
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme4;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme4;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
			}
			_RadioLauncherTheme4 = value;
			radioLauncherTheme = _RadioLauncherTheme4;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme5
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme5;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme5;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
			}
			_RadioLauncherTheme5 = value;
			radioLauncherTheme = _RadioLauncherTheme5;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("RadioLauncherTheme5Gray")]
	internal virtual MyRadioBox RadioLauncherTheme5Gray
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual TextBlock LabLauncherTheme5Unlock
	{
		[CompilerGenerated]
		get
		{
			return _LabLauncherTheme5Unlock;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(LabLauncherTheme5Unlock_MouseLeftButtonUp);
			TextBlock labLauncherTheme5Unlock = _LabLauncherTheme5Unlock;
			if (labLauncherTheme5Unlock != null)
			{
				((UIElement)labLauncherTheme5Unlock).MouseLeftButtonUp -= val;
			}
			_LabLauncherTheme5Unlock = value;
			labLauncherTheme5Unlock = _LabLauncherTheme5Unlock;
			if (labLauncherTheme5Unlock != null)
			{
				((UIElement)labLauncherTheme5Unlock).MouseLeftButtonUp += val;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme12
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme12;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme12;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
			}
			_RadioLauncherTheme12 = value;
			radioLauncherTheme = _RadioLauncherTheme12;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme6
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme6;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme6;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
			}
			_RadioLauncherTheme6 = value;
			radioLauncherTheme = _RadioLauncherTheme6;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme7
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme7;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme7;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
			}
			_RadioLauncherTheme7 = value;
			radioLauncherTheme = _RadioLauncherTheme7;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme13
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme13;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme13;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
			}
			_RadioLauncherTheme13 = value;
			radioLauncherTheme = _RadioLauncherTheme13;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme8
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme8;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MouseButtonEventHandler val = (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				LabLauncherTheme8Copy_MouseRightButtonUp();
			});
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme8;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
				((UIElement)radioLauncherTheme).MouseRightButtonUp -= val;
			}
			_RadioLauncherTheme8 = value;
			radioLauncherTheme = _RadioLauncherTheme8;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
				((UIElement)radioLauncherTheme).MouseRightButtonUp += val;
			}
		}
	}

	internal virtual TextBlock LabLauncherTheme8Copy
	{
		[CompilerGenerated]
		get
		{
			return _LabLauncherTheme8Copy;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				LabLauncherTheme8Copy_MouseRightButtonUp();
			});
			TextBlock labLauncherTheme8Copy = _LabLauncherTheme8Copy;
			if (labLauncherTheme8Copy != null)
			{
				((UIElement)labLauncherTheme8Copy).MouseRightButtonUp -= val;
			}
			_LabLauncherTheme8Copy = value;
			labLauncherTheme8Copy = _LabLauncherTheme8Copy;
			if (labLauncherTheme8Copy != null)
			{
				((UIElement)labLauncherTheme8Copy).MouseRightButtonUp += val;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme9
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme9;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MouseButtonEventHandler val = (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				LabLauncherTheme9Copy_MouseRightButtonUp();
			});
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme9;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
				((UIElement)radioLauncherTheme).MouseRightButtonUp -= val;
			}
			_RadioLauncherTheme9 = value;
			radioLauncherTheme = _RadioLauncherTheme9;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
				((UIElement)radioLauncherTheme).MouseRightButtonUp += val;
			}
		}
	}

	internal virtual TextBlock LabLauncherTheme9Copy
	{
		[CompilerGenerated]
		get
		{
			return _LabLauncherTheme9Copy;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				LabLauncherTheme9Copy_MouseRightButtonUp();
			});
			TextBlock labLauncherTheme9Copy = _LabLauncherTheme9Copy;
			if (labLauncherTheme9Copy != null)
			{
				((UIElement)labLauncherTheme9Copy).MouseRightButtonUp -= val;
			}
			_LabLauncherTheme9Copy = value;
			labLauncherTheme9Copy = _LabLauncherTheme9Copy;
			if (labLauncherTheme9Copy != null)
			{
				((UIElement)labLauncherTheme9Copy).MouseRightButtonUp += val;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme10
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme10;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme10;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
			}
			_RadioLauncherTheme10 = value;
			radioLauncherTheme = _RadioLauncherTheme10;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme11
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme11;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MouseButtonEventHandler val = (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				LabLauncherTheme11Click_MouseLeftButtonUp();
			});
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme11;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
				((UIElement)radioLauncherTheme).MouseRightButtonUp -= val;
			}
			_RadioLauncherTheme11 = value;
			radioLauncherTheme = _RadioLauncherTheme11;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
				((UIElement)radioLauncherTheme).MouseRightButtonUp += val;
			}
		}
	}

	internal virtual TextBlock LabLauncherTheme11Click
	{
		[CompilerGenerated]
		get
		{
			return _LabLauncherTheme11Click;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = (MouseButtonEventHandler)([SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				LabLauncherTheme11Click_MouseLeftButtonUp();
			});
			TextBlock labLauncherTheme11Click = _LabLauncherTheme11Click;
			if (labLauncherTheme11Click != null)
			{
				((UIElement)labLauncherTheme11Click).MouseLeftButtonUp -= val;
			}
			_LabLauncherTheme11Click = value;
			labLauncherTheme11Click = _LabLauncherTheme11Click;
			if (labLauncherTheme11Click != null)
			{
				((UIElement)labLauncherTheme11Click).MouseLeftButtonUp += val;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme14
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme14;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			IMyRadio.ChangedEventHandler obj2 = RadioLauncherTheme14_Change;
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme14;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
				radioLauncherTheme.Changed -= obj2;
			}
			_RadioLauncherTheme14 = value;
			radioLauncherTheme = _RadioLauncherTheme14;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
				radioLauncherTheme.Changed += obj2;
			}
		}
	}

	internal virtual MyRadioBox RadioLauncherTheme15
	{
		[CompilerGenerated]
		get
		{
			return _RadioLauncherTheme15;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLauncherTheme = _RadioLauncherTheme15;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check -= obj;
			}
			_RadioLauncherTheme15 = value;
			radioLauncherTheme = _RadioLauncherTheme15;
			if (radioLauncherTheme != null)
			{
				radioLauncherTheme.Check += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckDarkMode
	{
		[CompilerGenerated]
		get
		{
			return _CheckDarkMode;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkDarkMode = _CheckDarkMode;
			if (checkDarkMode != null)
			{
				checkDarkMode.Change -= obj;
			}
			_CheckDarkMode = value;
			checkDarkMode = _CheckDarkMode;
			if (checkDarkMode != null)
			{
				checkDarkMode.Change += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanelAcrylic")]
	internal virtual StackPanel PanelAcrylic
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCheckBox CheckAcrylicEnabled
	{
		[CompilerGenerated]
		get
		{
			return _CheckAcrylicEnabled;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkAcrylicEnabled = _CheckAcrylicEnabled;
			if (checkAcrylicEnabled != null)
			{
				checkAcrylicEnabled.Change -= obj;
			}
			_CheckAcrylicEnabled = value;
			checkAcrylicEnabled = _CheckAcrylicEnabled;
			if (checkAcrylicEnabled != null)
			{
				checkAcrylicEnabled.Change += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanAcrylicOpacity")]
	internal virtual Grid PanAcrylicOpacity
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MySlider SliderAcrylicOpacity
	{
		[CompilerGenerated]
		get
		{
			return _SliderAcrylicOpacity;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				SliderChange((MySlider)a0, a1);
			};
			MySlider sliderAcrylicOpacity = _SliderAcrylicOpacity;
			if (sliderAcrylicOpacity != null)
			{
				sliderAcrylicOpacity.Change -= obj;
			}
			_SliderAcrylicOpacity = value;
			sliderAcrylicOpacity = _SliderAcrylicOpacity;
			if (sliderAcrylicOpacity != null)
			{
				sliderAcrylicOpacity.Change += obj;
			}
		}
	}

	internal virtual MyComboBox ComboUiFont
	{
		[CompilerGenerated]
		get
		{
			return _ComboUiFont;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SelectionChangedEventHandler val = (SelectionChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, SelectionChangedEventArgs a1) =>
			{
				ComboFontChange((MyComboBox)a0, a1);
			});
			MyComboBox comboUiFont = _ComboUiFont;
			if (comboUiFont != null)
			{
				((Selector)comboUiFont).SelectionChanged -= val;
			}
			_ComboUiFont = value;
			comboUiFont = _ComboUiFont;
			if (comboUiFont != null)
			{
				((Selector)comboUiFont).SelectionChanged += val;
			}
		}
	}

	internal virtual MyCheckBox CheckLauncherLogo
	{
		[CompilerGenerated]
		get
		{
			return _CheckLauncherLogo;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkLauncherLogo = _CheckLauncherLogo;
			if (checkLauncherLogo != null)
			{
				checkLauncherLogo.Change -= obj;
			}
			_CheckLauncherLogo = value;
			checkLauncherLogo = _CheckLauncherLogo;
			if (checkLauncherLogo != null)
			{
				checkLauncherLogo.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckLockWindowSize
	{
		[CompilerGenerated]
		get
		{
			return _CheckLockWindowSize;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkLockWindowSize = _CheckLockWindowSize;
			if (checkLockWindowSize != null)
			{
				checkLockWindowSize.Change -= obj;
			}
			_CheckLockWindowSize = value;
			checkLockWindowSize = _CheckLockWindowSize;
			if (checkLockWindowSize != null)
			{
				checkLockWindowSize.Change += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanelBlur")]
	internal virtual StackPanel PanelBlur
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCheckBox CheckBlur
	{
		[CompilerGenerated]
		get
		{
			return _CheckBlur;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkBlur = _CheckBlur;
			if (checkBlur != null)
			{
				checkBlur.Change -= obj;
			}
			_CheckBlur = value;
			checkBlur = _CheckBlur;
			if (checkBlur != null)
			{
				checkBlur.Change += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBlurValue")]
	internal virtual Grid PanBlurValue
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MySlider SliderBlurValue
	{
		[CompilerGenerated]
		get
		{
			return _SliderBlurValue;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				SliderChange((MySlider)a0, a1);
			};
			MySlider sliderBlurValue = _SliderBlurValue;
			if (sliderBlurValue != null)
			{
				sliderBlurValue.Change -= obj;
			}
			_SliderBlurValue = value;
			sliderBlurValue = _SliderBlurValue;
			if (sliderBlurValue != null)
			{
				sliderBlurValue.Change += obj;
			}
		}
	}

	internal virtual MySlider SliderBlurSamplingRate
	{
		[CompilerGenerated]
		get
		{
			return _SliderBlurSamplingRate;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				SliderChange((MySlider)a0, a1);
			};
			MySlider sliderBlurSamplingRate = _SliderBlurSamplingRate;
			if (sliderBlurSamplingRate != null)
			{
				sliderBlurSamplingRate.Change -= obj;
			}
			_SliderBlurSamplingRate = value;
			sliderBlurSamplingRate = _SliderBlurSamplingRate;
			if (sliderBlurSamplingRate != null)
			{
				sliderBlurSamplingRate.Change += obj;
			}
		}
	}

	internal virtual MyComboBox ComboBlurType
	{
		[CompilerGenerated]
		get
		{
			return _ComboBlurType;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR244_002D38 != null)
			{
				obj = _Closure_0024__._0024IR244_002D38;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR244_002D38 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			MyComboBox comboBlurType = _ComboBlurType;
			if (comboBlurType != null)
			{
				((Selector)comboBlurType).SelectionChanged -= val2;
			}
			_ComboBlurType = value;
			comboBlurType = _ComboBlurType;
			if (comboBlurType != null)
			{
				((Selector)comboBlurType).SelectionChanged += val2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardBackground")]
	internal virtual MyCard CardBackground
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBackgroundSuit")]
	internal virtual Grid PanBackgroundSuit
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyComboBox ComboBackgroundSuit
	{
		[CompilerGenerated]
		get
		{
			return _ComboBackgroundSuit;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR256_002D39 != null)
			{
				obj = _Closure_0024__._0024IR256_002D39;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR256_002D39 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			MyComboBox comboBackgroundSuit = _ComboBackgroundSuit;
			if (comboBackgroundSuit != null)
			{
				((Selector)comboBackgroundSuit).SelectionChanged -= val2;
			}
			_ComboBackgroundSuit = value;
			comboBackgroundSuit = _ComboBackgroundSuit;
			if (comboBackgroundSuit != null)
			{
				((Selector)comboBackgroundSuit).SelectionChanged += val2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBackgroundOpacity")]
	internal virtual Grid PanBackgroundOpacity
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MySlider SliderBackgroundOpacity
	{
		[CompilerGenerated]
		get
		{
			return _SliderBackgroundOpacity;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				SliderChange((MySlider)a0, a1);
			};
			MySlider sliderBackgroundOpacity = _SliderBackgroundOpacity;
			if (sliderBackgroundOpacity != null)
			{
				sliderBackgroundOpacity.Change -= obj;
			}
			_SliderBackgroundOpacity = value;
			sliderBackgroundOpacity = _SliderBackgroundOpacity;
			if (sliderBackgroundOpacity != null)
			{
				sliderBackgroundOpacity.Change += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBackgroundBlur")]
	internal virtual Grid PanBackgroundBlur
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MySlider SliderBackgroundBlur
	{
		[CompilerGenerated]
		get
		{
			return _SliderBackgroundBlur;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				SliderChange((MySlider)a0, a1);
			};
			MySlider sliderBackgroundBlur = _SliderBackgroundBlur;
			if (sliderBackgroundBlur != null)
			{
				sliderBackgroundBlur.Change -= obj;
			}
			_SliderBackgroundBlur = value;
			sliderBackgroundBlur = _SliderBackgroundBlur;
			if (sliderBackgroundBlur != null)
			{
				sliderBackgroundBlur.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckAutoPauseVideo
	{
		[CompilerGenerated]
		get
		{
			return _CheckAutoPauseVideo;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkAutoPauseVideo = _CheckAutoPauseVideo;
			if (checkAutoPauseVideo != null)
			{
				checkAutoPauseVideo.Change -= obj;
			}
			_CheckAutoPauseVideo = value;
			checkAutoPauseVideo = _CheckAutoPauseVideo;
			if (checkAutoPauseVideo != null)
			{
				checkAutoPauseVideo.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckBackgroundColorful
	{
		[CompilerGenerated]
		get
		{
			return _CheckBackgroundColorful;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkBackgroundColorful = _CheckBackgroundColorful;
			if (checkBackgroundColorful != null)
			{
				checkBackgroundColorful.Change -= obj;
			}
			_CheckBackgroundColorful = value;
			checkBackgroundColorful = _CheckBackgroundColorful;
			if (checkBackgroundColorful != null)
			{
				checkBackgroundColorful.Change += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardBackground2")]
	internal virtual MyCard CardBackground2
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnBackgroundOpen
	{
		[CompilerGenerated]
		get
		{
			return _BtnBackgroundOpen;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnUIBgOpen_Click;
			MyButton btnBackgroundOpen = _BtnBackgroundOpen;
			if (btnBackgroundOpen != null)
			{
				btnBackgroundOpen.Click -= obj;
			}
			_BtnBackgroundOpen = value;
			btnBackgroundOpen = _BtnBackgroundOpen;
			if (btnBackgroundOpen != null)
			{
				btnBackgroundOpen.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnBackgroundRefresh
	{
		[CompilerGenerated]
		get
		{
			return _BtnBackgroundRefresh;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnBackgroundRefresh_Click;
			MyButton btnBackgroundRefresh = _BtnBackgroundRefresh;
			if (btnBackgroundRefresh != null)
			{
				btnBackgroundRefresh.Click -= obj;
			}
			_BtnBackgroundRefresh = value;
			btnBackgroundRefresh = _BtnBackgroundRefresh;
			if (btnBackgroundRefresh != null)
			{
				btnBackgroundRefresh.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnBackgroundClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnBackgroundClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnBackgroundClear_Click;
			MyButton btnBackgroundClear = _BtnBackgroundClear;
			if (btnBackgroundClear != null)
			{
				btnBackgroundClear.Click -= obj;
			}
			_BtnBackgroundClear = value;
			btnBackgroundClear = _BtnBackgroundClear;
			if (btnBackgroundClear != null)
			{
				btnBackgroundClear.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardMusic")]
	internal virtual MyCard CardMusic
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanMusicVolume")]
	internal virtual Grid PanMusicVolume
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MySlider SliderMusicVolume
	{
		[CompilerGenerated]
		get
		{
			return _SliderMusicVolume;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MySlider.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				SliderChange((MySlider)a0, a1);
			};
			MySlider sliderMusicVolume = _SliderMusicVolume;
			if (sliderMusicVolume != null)
			{
				sliderMusicVolume.Change -= obj;
			}
			_SliderMusicVolume = value;
			sliderMusicVolume = _SliderMusicVolume;
			if (sliderMusicVolume != null)
			{
				sliderMusicVolume.Change += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanMusicDetail")]
	internal virtual StackPanel PanMusicDetail
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCheckBox CheckMusicRandom
	{
		[CompilerGenerated]
		get
		{
			return _CheckMusicRandom;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkMusicRandom = _CheckMusicRandom;
			if (checkMusicRandom != null)
			{
				checkMusicRandom.Change -= obj;
			}
			_CheckMusicRandom = value;
			checkMusicRandom = _CheckMusicRandom;
			if (checkMusicRandom != null)
			{
				checkMusicRandom.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckMusicAuto
	{
		[CompilerGenerated]
		get
		{
			return _CheckMusicAuto;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkMusicAuto = _CheckMusicAuto;
			if (checkMusicAuto != null)
			{
				checkMusicAuto.Change -= obj;
			}
			_CheckMusicAuto = value;
			checkMusicAuto = _CheckMusicAuto;
			if (checkMusicAuto != null)
			{
				checkMusicAuto.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckMusicStart
	{
		[CompilerGenerated]
		get
		{
			return _CheckMusicStart;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				CheckMusicStart_Change();
			};
			MyCheckBox checkMusicStart = _CheckMusicStart;
			if (checkMusicStart != null)
			{
				checkMusicStart.Change -= obj;
				checkMusicStart.Change -= obj2;
			}
			_CheckMusicStart = value;
			checkMusicStart = _CheckMusicStart;
			if (checkMusicStart != null)
			{
				checkMusicStart.Change += obj;
				checkMusicStart.Change += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckMusicStop
	{
		[CompilerGenerated]
		get
		{
			return _CheckMusicStop;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				CheckMusicStop_Change();
			};
			MyCheckBox checkMusicStop = _CheckMusicStop;
			if (checkMusicStop != null)
			{
				checkMusicStop.Change -= obj;
				checkMusicStop.Change -= obj2;
			}
			_CheckMusicStop = value;
			checkMusicStop = _CheckMusicStop;
			if (checkMusicStop != null)
			{
				checkMusicStop.Change += obj;
				checkMusicStop.Change += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckMusicSMTC
	{
		[CompilerGenerated]
		get
		{
			return _CheckMusicSMTC;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkMusicSMTC = _CheckMusicSMTC;
			if (checkMusicSMTC != null)
			{
				checkMusicSMTC.Change -= obj;
			}
			_CheckMusicSMTC = value;
			checkMusicSMTC = _CheckMusicSMTC;
			if (checkMusicSMTC != null)
			{
				checkMusicSMTC.Change += obj;
			}
		}
	}

	internal virtual MyButton BtnMusicOpen
	{
		[CompilerGenerated]
		get
		{
			return _BtnMusicOpen;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnMusicOpen_Click;
			MyButton btnMusicOpen = _BtnMusicOpen;
			if (btnMusicOpen != null)
			{
				btnMusicOpen.Click -= obj;
			}
			_BtnMusicOpen = value;
			btnMusicOpen = _BtnMusicOpen;
			if (btnMusicOpen != null)
			{
				btnMusicOpen.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnMusicRefresh
	{
		[CompilerGenerated]
		get
		{
			return _BtnMusicRefresh;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnMusicRefresh_Click;
			MyButton btnMusicRefresh = _BtnMusicRefresh;
			if (btnMusicRefresh != null)
			{
				btnMusicRefresh.Click -= obj;
			}
			_BtnMusicRefresh = value;
			btnMusicRefresh = _BtnMusicRefresh;
			if (btnMusicRefresh != null)
			{
				btnMusicRefresh.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnMusicClear
	{
		[CompilerGenerated]
		get
		{
			return _BtnMusicClear;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnMusicClear_Click;
			MyButton btnMusicClear = _BtnMusicClear;
			if (btnMusicClear != null)
			{
				btnMusicClear.Click -= obj;
			}
			_BtnMusicClear = value;
			btnMusicClear = _BtnMusicClear;
			if (btnMusicClear != null)
			{
				btnMusicClear.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardLogo")]
	internal virtual MyCard CardLogo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyRadioBox RadioLogoType0
	{
		[CompilerGenerated]
		get
		{
			return _RadioLogoType0;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLogoType = _RadioLogoType0;
			if (radioLogoType != null)
			{
				radioLogoType.Check -= obj;
			}
			_RadioLogoType0 = value;
			radioLogoType = _RadioLogoType0;
			if (radioLogoType != null)
			{
				radioLogoType.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioLogoType1
	{
		[CompilerGenerated]
		get
		{
			return _RadioLogoType1;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLogoType = _RadioLogoType1;
			if (radioLogoType != null)
			{
				radioLogoType.Check -= obj;
			}
			_RadioLogoType1 = value;
			radioLogoType = _RadioLogoType1;
			if (radioLogoType != null)
			{
				radioLogoType.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioLogoType2
	{
		[CompilerGenerated]
		get
		{
			return _RadioLogoType2;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioLogoType = _RadioLogoType2;
			if (radioLogoType != null)
			{
				radioLogoType.Check -= obj;
			}
			_RadioLogoType2 = value;
			radioLogoType = _RadioLogoType2;
			if (radioLogoType != null)
			{
				radioLogoType.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioLogoType3
	{
		[CompilerGenerated]
		get
		{
			return _RadioLogoType3;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox.PreviewCheckEventHandler obj2 = RadioLogoType3_Check;
			MyRadioBox radioLogoType = _RadioLogoType3;
			if (radioLogoType != null)
			{
				radioLogoType.Check -= obj;
				radioLogoType.PreviewCheck -= obj2;
			}
			_RadioLogoType3 = value;
			radioLogoType = _RadioLogoType3;
			if (radioLogoType != null)
			{
				radioLogoType.Check += obj;
				radioLogoType.PreviewCheck += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckLogoLeft
	{
		[CompilerGenerated]
		get
		{
			return _CheckLogoLeft;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkLogoLeft = _CheckLogoLeft;
			if (checkLogoLeft != null)
			{
				checkLogoLeft.Change -= obj;
			}
			_CheckLogoLeft = value;
			checkLogoLeft = _CheckLogoLeft;
			if (checkLogoLeft != null)
			{
				checkLogoLeft.Change += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLogoText")]
	internal virtual Grid PanLogoText
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyTextBox TextLogoText
	{
		[CompilerGenerated]
		get
		{
			return _TextLogoText;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR376_002D57 != null)
			{
				obj = _Closure_0024__._0024IR376_002D57;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR376_002D57 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			MyTextBox textLogoText = _TextLogoText;
			if (textLogoText != null)
			{
				textLogoText.ValidatedTextChanged -= value2;
			}
			_TextLogoText = value;
			textLogoText = _TextLogoText;
			if (textLogoText != null)
			{
				textLogoText.ValidatedTextChanged += value2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanLogoChange")]
	internal virtual Grid PanLogoChange
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnLogoChange
	{
		[CompilerGenerated]
		get
		{
			return _BtnLogoChange;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnLogoChange_Click;
			MyButton btnLogoChange = _BtnLogoChange;
			if (btnLogoChange != null)
			{
				btnLogoChange.Click -= obj;
			}
			_BtnLogoChange = value;
			btnLogoChange = _BtnLogoChange;
			if (btnLogoChange != null)
			{
				btnLogoChange.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnLogoDelete
	{
		[CompilerGenerated]
		get
		{
			return _BtnLogoDelete;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnLogoDelete_Click;
			MyButton btnLogoDelete = _BtnLogoDelete;
			if (btnLogoDelete != null)
			{
				btnLogoDelete.Click -= obj;
			}
			_BtnLogoDelete = value;
			btnLogoDelete = _BtnLogoDelete;
			if (btnLogoDelete != null)
			{
				btnLogoDelete.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardCustom")]
	internal virtual MyCard CardCustom
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyRadioBox RadioCustomType0
	{
		[CompilerGenerated]
		get
		{
			return _RadioCustomType0;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioCustomType = _RadioCustomType0;
			if (radioCustomType != null)
			{
				radioCustomType.Check -= obj;
			}
			_RadioCustomType0 = value;
			radioCustomType = _RadioCustomType0;
			if (radioCustomType != null)
			{
				radioCustomType.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioCustomType3
	{
		[CompilerGenerated]
		get
		{
			return _RadioCustomType3;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioCustomType = _RadioCustomType3;
			if (radioCustomType != null)
			{
				radioCustomType.Check -= obj;
			}
			_RadioCustomType3 = value;
			radioCustomType = _RadioCustomType3;
			if (radioCustomType != null)
			{
				radioCustomType.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioCustomType1
	{
		[CompilerGenerated]
		get
		{
			return _RadioCustomType1;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioCustomType = _RadioCustomType1;
			if (radioCustomType != null)
			{
				radioCustomType.Check -= obj;
			}
			_RadioCustomType1 = value;
			radioCustomType = _RadioCustomType1;
			if (radioCustomType != null)
			{
				radioCustomType.Check += obj;
			}
		}
	}

	internal virtual MyRadioBox RadioCustomType2
	{
		[CompilerGenerated]
		get
		{
			return _RadioCustomType2;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			IMyRadio.CheckEventHandler obj = [SpecialName] (object a0, ModBase.RouteEventArgs a1) =>
			{
				RadioBoxChange((MyRadioBox)a0, a1);
			};
			MyRadioBox radioCustomType = _RadioCustomType2;
			if (radioCustomType != null)
			{
				radioCustomType.Check -= obj;
			}
			_RadioCustomType2 = value;
			radioCustomType = _RadioCustomType2;
			if (radioCustomType != null)
			{
				radioCustomType.Check += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintCustom")]
	internal virtual MyHint HintCustom
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("HintCustomWarn")]
	internal virtual MyHint HintCustomWarn
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanCustomLocal")]
	internal virtual Grid PanCustomLocal
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnCustomRefresh
	{
		[CompilerGenerated]
		get
		{
			return _BtnCustomRefresh;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, MouseButtonEventArgs a1) =>
			{
				BtnCustomRefresh_Click();
			};
			MyButton btnCustomRefresh = _BtnCustomRefresh;
			if (btnCustomRefresh != null)
			{
				btnCustomRefresh.Click -= obj;
			}
			_BtnCustomRefresh = value;
			btnCustomRefresh = _BtnCustomRefresh;
			if (btnCustomRefresh != null)
			{
				btnCustomRefresh.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnCustomFile
	{
		[CompilerGenerated]
		get
		{
			return _BtnCustomFile;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnCustomFile_Click;
			MyButton btnCustomFile = _BtnCustomFile;
			if (btnCustomFile != null)
			{
				btnCustomFile.Click -= obj;
			}
			_BtnCustomFile = value;
			btnCustomFile = _BtnCustomFile;
			if (btnCustomFile != null)
			{
				btnCustomFile.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnCustomTutorial
	{
		[CompilerGenerated]
		get
		{
			return _BtnCustomTutorial;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnCustomTutorial_Click;
			MyButton btnCustomTutorial = _BtnCustomTutorial;
			if (btnCustomTutorial != null)
			{
				btnCustomTutorial.Click -= obj;
			}
			_BtnCustomTutorial = value;
			btnCustomTutorial = _BtnCustomTutorial;
			if (btnCustomTutorial != null)
			{
				btnCustomTutorial.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanCustomNet")]
	internal virtual Grid PanCustomNet
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyTextBox TextCustomNet
	{
		[CompilerGenerated]
		get
		{
			return _TextCustomNet;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR440_002D63 != null)
			{
				obj = _Closure_0024__._0024IR440_002D63;
			}
			else
			{
				RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
				{
					TextBoxChange((MyTextBox)a0, a1);
				};
				_Closure_0024__._0024IR440_002D63 = val;
				obj = (object)val;
			}
			RoutedEventHandler value2 = (RoutedEventHandler)obj;
			MyTextBox textCustomNet = _TextCustomNet;
			if (textCustomNet != null)
			{
				textCustomNet.ValidatedTextChanged -= value2;
			}
			_TextCustomNet = value;
			textCustomNet = _TextCustomNet;
			if (textCustomNet != null)
			{
				textCustomNet.ValidatedTextChanged += value2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanCustomPreset")]
	internal virtual Grid PanCustomPreset
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyComboBox ComboCustomPreset
	{
		[CompilerGenerated]
		get
		{
			return _ComboCustomPreset;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			object obj;
			if (_Closure_0024__._0024IR448_002D64 != null)
			{
				obj = _Closure_0024__._0024IR448_002D64;
			}
			else
			{
				SelectionChangedEventHandler val = [SpecialName] (object a0, SelectionChangedEventArgs a1) =>
				{
					ComboChange((MyComboBox)a0, a1);
				};
				_Closure_0024__._0024IR448_002D64 = val;
				obj = (object)val;
			}
			SelectionChangedEventHandler val2 = (SelectionChangedEventHandler)obj;
			MyComboBox comboCustomPreset = _ComboCustomPreset;
			if (comboCustomPreset != null)
			{
				((Selector)comboCustomPreset).SelectionChanged -= val2;
			}
			_ComboCustomPreset = value;
			comboCustomPreset = _ComboCustomPreset;
			if (comboCustomPreset != null)
			{
				((Selector)comboCustomPreset).SelectionChanged += val2;
			}
		}
	}

	internal virtual MyIconTextButton BtnGotoHomepageMarket
	{
		[CompilerGenerated]
		get
		{
			return _BtnGotoHomepageMarket;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnHomepageMarket_Click;
			MyIconTextButton btnGotoHomepageMarket = _BtnGotoHomepageMarket;
			if (btnGotoHomepageMarket != null)
			{
				btnGotoHomepageMarket.Click -= obj;
			}
			_BtnGotoHomepageMarket = value;
			btnGotoHomepageMarket = _BtnGotoHomepageMarket;
			if (btnGotoHomepageMarket != null)
			{
				btnGotoHomepageMarket.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardSwitch")]
	internal virtual MyCard CardSwitch
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyCheckBox CheckHiddenPageDownload
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenPageDownload;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHiddenPageDownload = _CheckHiddenPageDownload;
			if (checkHiddenPageDownload != null)
			{
				checkHiddenPageDownload.Change -= obj;
			}
			_CheckHiddenPageDownload = value;
			checkHiddenPageDownload = _CheckHiddenPageDownload;
			if (checkHiddenPageDownload != null)
			{
				checkHiddenPageDownload.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenPageLink
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenPageLink;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHiddenPageLink = _CheckHiddenPageLink;
			if (checkHiddenPageLink != null)
			{
				checkHiddenPageLink.Change -= obj;
			}
			_CheckHiddenPageLink = value;
			checkHiddenPageLink = _CheckHiddenPageLink;
			if (checkHiddenPageLink != null)
			{
				checkHiddenPageLink.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenPageSetup
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenPageSetup;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				HiddenSetupMain();
			};
			MyCheckBox.ChangeEventHandler obj3 = HiddenHint;
			MyCheckBox checkHiddenPageSetup = _CheckHiddenPageSetup;
			if (checkHiddenPageSetup != null)
			{
				checkHiddenPageSetup.Change -= obj;
				checkHiddenPageSetup.Change -= obj2;
				checkHiddenPageSetup.Change -= obj3;
			}
			_CheckHiddenPageSetup = value;
			checkHiddenPageSetup = _CheckHiddenPageSetup;
			if (checkHiddenPageSetup != null)
			{
				checkHiddenPageSetup.Change += obj;
				checkHiddenPageSetup.Change += obj2;
				checkHiddenPageSetup.Change += obj3;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenPageOther
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenPageOther;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				HiddenOtherMain();
			};
			MyCheckBox checkHiddenPageOther = _CheckHiddenPageOther;
			if (checkHiddenPageOther != null)
			{
				checkHiddenPageOther.Change -= obj;
				checkHiddenPageOther.Change -= obj2;
			}
			_CheckHiddenPageOther = value;
			checkHiddenPageOther = _CheckHiddenPageOther;
			if (checkHiddenPageOther != null)
			{
				checkHiddenPageOther.Change += obj;
				checkHiddenPageOther.Change += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenSetupLaunch
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenSetupLaunch;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				HiddenSetupSub();
			};
			MyCheckBox checkHiddenSetupLaunch = _CheckHiddenSetupLaunch;
			if (checkHiddenSetupLaunch != null)
			{
				checkHiddenSetupLaunch.Change -= obj;
				checkHiddenSetupLaunch.Change -= obj2;
			}
			_CheckHiddenSetupLaunch = value;
			checkHiddenSetupLaunch = _CheckHiddenSetupLaunch;
			if (checkHiddenSetupLaunch != null)
			{
				checkHiddenSetupLaunch.Change += obj;
				checkHiddenSetupLaunch.Change += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenSetupUI
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenSetupUI;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				HiddenSetupSub();
			};
			MyCheckBox.ChangeEventHandler obj3 = HiddenHint;
			MyCheckBox checkHiddenSetupUI = _CheckHiddenSetupUI;
			if (checkHiddenSetupUI != null)
			{
				checkHiddenSetupUI.Change -= obj;
				checkHiddenSetupUI.Change -= obj2;
				checkHiddenSetupUI.Change -= obj3;
			}
			_CheckHiddenSetupUI = value;
			checkHiddenSetupUI = _CheckHiddenSetupUI;
			if (checkHiddenSetupUI != null)
			{
				checkHiddenSetupUI.Change += obj;
				checkHiddenSetupUI.Change += obj2;
				checkHiddenSetupUI.Change += obj3;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenSetupSystem
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenSetupSystem;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				HiddenSetupSub();
			};
			MyCheckBox checkHiddenSetupSystem = _CheckHiddenSetupSystem;
			if (checkHiddenSetupSystem != null)
			{
				checkHiddenSetupSystem.Change -= obj;
				checkHiddenSetupSystem.Change -= obj2;
			}
			_CheckHiddenSetupSystem = value;
			checkHiddenSetupSystem = _CheckHiddenSetupSystem;
			if (checkHiddenSetupSystem != null)
			{
				checkHiddenSetupSystem.Change += obj;
				checkHiddenSetupSystem.Change += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenOtherHelp
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenOtherHelp;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = HiddenOtherSub;
			MyCheckBox checkHiddenOtherHelp = _CheckHiddenOtherHelp;
			if (checkHiddenOtherHelp != null)
			{
				checkHiddenOtherHelp.Change -= obj;
				checkHiddenOtherHelp.Change -= obj2;
			}
			_CheckHiddenOtherHelp = value;
			checkHiddenOtherHelp = _CheckHiddenOtherHelp;
			if (checkHiddenOtherHelp != null)
			{
				checkHiddenOtherHelp.Change += obj;
				checkHiddenOtherHelp.Change += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenOtherAbout
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenOtherAbout;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = HiddenOtherSub;
			MyCheckBox checkHiddenOtherAbout = _CheckHiddenOtherAbout;
			if (checkHiddenOtherAbout != null)
			{
				checkHiddenOtherAbout.Change -= obj;
				checkHiddenOtherAbout.Change -= obj2;
			}
			_CheckHiddenOtherAbout = value;
			checkHiddenOtherAbout = _CheckHiddenOtherAbout;
			if (checkHiddenOtherAbout != null)
			{
				checkHiddenOtherAbout.Change += obj;
				checkHiddenOtherAbout.Change += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenOtherTest
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenOtherTest;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = HiddenOtherSub;
			MyCheckBox checkHiddenOtherTest = _CheckHiddenOtherTest;
			if (checkHiddenOtherTest != null)
			{
				checkHiddenOtherTest.Change -= obj;
				checkHiddenOtherTest.Change -= obj2;
			}
			_CheckHiddenOtherTest = value;
			checkHiddenOtherTest = _CheckHiddenOtherTest;
			if (checkHiddenOtherTest != null)
			{
				checkHiddenOtherTest.Change += obj;
				checkHiddenOtherTest.Change += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenOtherFeedback
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenOtherFeedback;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = HiddenOtherNet;
			MyCheckBox checkHiddenOtherFeedback = _CheckHiddenOtherFeedback;
			if (checkHiddenOtherFeedback != null)
			{
				checkHiddenOtherFeedback.Change -= obj;
				checkHiddenOtherFeedback.Change -= obj2;
			}
			_CheckHiddenOtherFeedback = value;
			checkHiddenOtherFeedback = _CheckHiddenOtherFeedback;
			if (checkHiddenOtherFeedback != null)
			{
				checkHiddenOtherFeedback.Change += obj;
				checkHiddenOtherFeedback.Change += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenOtherVote
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenOtherVote;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = HiddenOtherNet;
			MyCheckBox checkHiddenOtherVote = _CheckHiddenOtherVote;
			if (checkHiddenOtherVote != null)
			{
				checkHiddenOtherVote.Change -= obj;
				checkHiddenOtherVote.Change -= obj2;
			}
			_CheckHiddenOtherVote = value;
			checkHiddenOtherVote = _CheckHiddenOtherVote;
			if (checkHiddenOtherVote != null)
			{
				checkHiddenOtherVote.Change += obj;
				checkHiddenOtherVote.Change += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenFunctionSelect
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenFunctionSelect;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHiddenFunctionSelect = _CheckHiddenFunctionSelect;
			if (checkHiddenFunctionSelect != null)
			{
				checkHiddenFunctionSelect.Change -= obj;
			}
			_CheckHiddenFunctionSelect = value;
			checkHiddenFunctionSelect = _CheckHiddenFunctionSelect;
			if (checkHiddenFunctionSelect != null)
			{
				checkHiddenFunctionSelect.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenFunctionModUpdate
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenFunctionModUpdate;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHiddenFunctionModUpdate = _CheckHiddenFunctionModUpdate;
			if (checkHiddenFunctionModUpdate != null)
			{
				checkHiddenFunctionModUpdate.Change -= obj;
			}
			_CheckHiddenFunctionModUpdate = value;
			checkHiddenFunctionModUpdate = _CheckHiddenFunctionModUpdate;
			if (checkHiddenFunctionModUpdate != null)
			{
				checkHiddenFunctionModUpdate.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenFunctionHidden
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenFunctionHidden;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox.ChangeEventHandler obj2 = HiddenHint;
			MyCheckBox checkHiddenFunctionHidden = _CheckHiddenFunctionHidden;
			if (checkHiddenFunctionHidden != null)
			{
				checkHiddenFunctionHidden.Change -= obj;
				checkHiddenFunctionHidden.Change -= obj2;
			}
			_CheckHiddenFunctionHidden = value;
			checkHiddenFunctionHidden = _CheckHiddenFunctionHidden;
			if (checkHiddenFunctionHidden != null)
			{
				checkHiddenFunctionHidden.Change += obj;
				checkHiddenFunctionHidden.Change += obj2;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenVersionEdit
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenVersionEdit;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHiddenVersionEdit = _CheckHiddenVersionEdit;
			if (checkHiddenVersionEdit != null)
			{
				checkHiddenVersionEdit.Change -= obj;
			}
			_CheckHiddenVersionEdit = value;
			checkHiddenVersionEdit = _CheckHiddenVersionEdit;
			if (checkHiddenVersionEdit != null)
			{
				checkHiddenVersionEdit.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenVersionExport
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenVersionExport;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHiddenVersionExport = _CheckHiddenVersionExport;
			if (checkHiddenVersionExport != null)
			{
				checkHiddenVersionExport.Change -= obj;
			}
			_CheckHiddenVersionExport = value;
			checkHiddenVersionExport = _CheckHiddenVersionExport;
			if (checkHiddenVersionExport != null)
			{
				checkHiddenVersionExport.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenVersionSave
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenVersionSave;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHiddenVersionSave = _CheckHiddenVersionSave;
			if (checkHiddenVersionSave != null)
			{
				checkHiddenVersionSave.Change -= obj;
			}
			_CheckHiddenVersionSave = value;
			checkHiddenVersionSave = _CheckHiddenVersionSave;
			if (checkHiddenVersionSave != null)
			{
				checkHiddenVersionSave.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenVersionScreenshot
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenVersionScreenshot;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHiddenVersionScreenshot = _CheckHiddenVersionScreenshot;
			if (checkHiddenVersionScreenshot != null)
			{
				checkHiddenVersionScreenshot.Change -= obj;
			}
			_CheckHiddenVersionScreenshot = value;
			checkHiddenVersionScreenshot = _CheckHiddenVersionScreenshot;
			if (checkHiddenVersionScreenshot != null)
			{
				checkHiddenVersionScreenshot.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenVersionMod
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenVersionMod;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHiddenVersionMod = _CheckHiddenVersionMod;
			if (checkHiddenVersionMod != null)
			{
				checkHiddenVersionMod.Change -= obj;
			}
			_CheckHiddenVersionMod = value;
			checkHiddenVersionMod = _CheckHiddenVersionMod;
			if (checkHiddenVersionMod != null)
			{
				checkHiddenVersionMod.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenVersionResourcePack
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenVersionResourcePack;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHiddenVersionResourcePack = _CheckHiddenVersionResourcePack;
			if (checkHiddenVersionResourcePack != null)
			{
				checkHiddenVersionResourcePack.Change -= obj;
			}
			_CheckHiddenVersionResourcePack = value;
			checkHiddenVersionResourcePack = _CheckHiddenVersionResourcePack;
			if (checkHiddenVersionResourcePack != null)
			{
				checkHiddenVersionResourcePack.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenVersionShader
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenVersionShader;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHiddenVersionShader = _CheckHiddenVersionShader;
			if (checkHiddenVersionShader != null)
			{
				checkHiddenVersionShader.Change -= obj;
			}
			_CheckHiddenVersionShader = value;
			checkHiddenVersionShader = _CheckHiddenVersionShader;
			if (checkHiddenVersionShader != null)
			{
				checkHiddenVersionShader.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenVersionSchematic
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenVersionSchematic;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHiddenVersionSchematic = _CheckHiddenVersionSchematic;
			if (checkHiddenVersionSchematic != null)
			{
				checkHiddenVersionSchematic.Change -= obj;
			}
			_CheckHiddenVersionSchematic = value;
			checkHiddenVersionSchematic = _CheckHiddenVersionSchematic;
			if (checkHiddenVersionSchematic != null)
			{
				checkHiddenVersionSchematic.Change += obj;
			}
		}
	}

	internal virtual MyCheckBox CheckHiddenVersionServer
	{
		[CompilerGenerated]
		get
		{
			return _CheckHiddenVersionServer;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyCheckBox.ChangeEventHandler obj = [SpecialName] (object a0, bool a1) =>
			{
				CheckBoxChange((MyCheckBox)a0, a1);
			};
			MyCheckBox checkHiddenVersionServer = _CheckHiddenVersionServer;
			if (checkHiddenVersionServer != null)
			{
				checkHiddenVersionServer.Change -= obj;
			}
			_CheckHiddenVersionServer = value;
			checkHiddenVersionServer = _CheckHiddenVersionServer;
			if (checkHiddenVersionServer != null)
			{
				checkHiddenVersionServer.Change += obj;
			}
		}
	}

	public PageSetupUI()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageSetupUI_Loaded);
		object obj;
		if (_Closure_0024__._0024IR2_002D1 != null)
		{
			obj = _Closure_0024__._0024IR2_002D1;
		}
		else
		{
			RoutedEventHandler val = [SpecialName] (object a0, RoutedEventArgs a1) =>
			{
				HiddenRefresh();
			};
			_Closure_0024__._0024IR2_002D1 = val;
			obj = (object)val;
		}
		((FrameworkElement)this).Loaded += (RoutedEventHandler)obj;
		IsLoaded = false;
		CustomFontCollection = new ObservableCollection<CustomFontProperties>();
		InitializeComponent();
	}

	private void PageSetupUI_Loaded(object sender, RoutedEventArgs e)
	{
		((ScrollViewer)PanBack).ScrollToHome();
		ModSecret.ThemeCheckAll(EffectSetup: true);
		UnlockAllThemes();
		if (ModSecret.ThemeDontClick != 0)
		{
			string text = ModSecret.ThemeDontClick switch
			{
				1 => "眼瞎白", 
				2 => "真·滑稽彩", 
				_ => "？？？", 
			};
			foreach (object child in ((Panel)PanLauncherTheme).Children)
			{
				object objectValue = RuntimeHelpers.GetObjectValue(child);
				if (objectValue is MyRadioBox && ((UIElement)(MyRadioBox)objectValue).IsEnabled)
				{
					((MyRadioBox)objectValue).Text = text;
				}
			}
		}
		checked
		{
			ModAnimation.AniControlEnabled++;
			Reload();
			ModAnimation.AniControlEnabled--;
			if (!IsLoaded)
			{
				IsLoaded = true;
				SliderLoad();
				if (!((UIElement)RadioLauncherTheme8).IsEnabled)
				{
					((FrameworkElement)LabLauncherTheme8Copy).ToolTip = "累积赞助达到 ¥23.33 后，在爱发电私信发送【解锁码】以解锁。\r\n右键打开赞助页面，如果觉得 PCL 做得还不错就支持一下吧 =w=！";
				}
				((FrameworkElement)RadioLauncherTheme8).ToolTip = "累积赞助达到 ¥23.33 后，在爱发电私信发送【解锁码】以解锁";
				if (!((UIElement)RadioLauncherTheme9).IsEnabled)
				{
					((FrameworkElement)LabLauncherTheme9Copy).ToolTip = "· 反馈一个 Bug，在标记为 [完成] 后回复识别码要求解锁（右键打开反馈页面）\r\n· 提交一个 Pull Request 或主页预设，在标记为 [完成] 后回复识别码要求解锁";
				}
				((FrameworkElement)RadioLauncherTheme9).ToolTip = "· 反馈一个 Bug，在标记为 [完成] 后回复识别码要求解锁\r\n· 提交一个 Pull Request 或主页预设，在标记为 [完成] 后回复识别码要求解锁";
			}
		}
	}

	private void UnlockAllThemes()
	{
		if (PanLauncherTheme == null)
		{
			return;
		}
		((UIElement)PanLauncherTheme).Visibility = (Visibility)0;
		foreach (object child in ((Panel)PanLauncherTheme).Children)
		{
			object objectValue = RuntimeHelpers.GetObjectValue(child);
			if (objectValue is MyRadioBox)
			{
				MyRadioBox obj = (MyRadioBox)objectValue;
				((UIElement)obj).IsEnabled = true;
				((UIElement)obj).Opacity = 1.0;
			}
		}
		((UIElement)RadioLauncherTheme5Gray).Visibility = (Visibility)2;
		((UIElement)LabLauncherTheme5Unlock).Visibility = (Visibility)2;
		((UIElement)LabLauncherTheme8Copy).Visibility = (Visibility)2;
		((UIElement)LabLauncherTheme9Copy).Visibility = (Visibility)2;
		((UIElement)LabLauncherTheme11Click).Visibility = (Visibility)2;
	}

	private static int MapThemeToColorIndex(int themeId, int fallbackIndex)
	{
		switch (themeId)
		{
		case 0:
			return 1;
		case 1:
			return 0;
		case 2:
			return 2;
		case 3:
			return 0;
		case 4:
			return 2;
		case 5:
			return 1;
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
		case 13:
			return 1;
		case 14:
			return fallbackIndex;
		default:
			return fallbackIndex;
		}
	}

	public void Reload()
	{
		//IL_086b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0871: Expected O, but got Unknown
		//IL_0873: Expected O, but got Unknown
		try
		{
			SliderLauncherOpacity.Value = Conversions.ToInteger(ModBase.Setup.Get("UiLauncherTransparent"));
			SliderLauncherHue.Value = Conversions.ToInteger(ModBase.Setup.Get("UiLauncherHue"));
			SliderLauncherSat.Value = Conversions.ToInteger(ModBase.Setup.Get("UiLauncherSat"));
			SliderLauncherDelta.Value = Conversions.ToInteger(ModBase.Setup.Get("UiLauncherDelta"));
			SliderLauncherLight.Value = Conversions.ToInteger(ModBase.Setup.Get("UiLauncherLight"));
			int num = Conversions.ToInteger(ModBase.Setup.Get("UiLauncherTheme"));
			if (num >= 0 && num <= 15)
			{
				MyRadioBox myRadioBox = (MyRadioBox)base.FindName("RadioLauncherTheme" + Conversions.ToString(num));
				if (myRadioBox != null && ((UIElement)myRadioBox).IsEnabled)
				{
					myRadioBox.Checked = true;
				}
			}
			CheckLauncherLogo.Checked = (bool?)ModBase.Setup.Get("UiLauncherLogo");
			int num2 = Conversions.ToInteger(ModBase.Setup.Get("UiDarkMode"));
			CheckDarkMode.Checked = num2 == 1;
			((DispatcherObject)this).Dispatcher.BeginInvoke((System.Delegate)(VB_0024AnonymousDelegate_0<System.Threading.Tasks.Task>)([SpecialName] [CompilerGenerated] [AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__10_002D0))] () =>
			{
				//IL_001a: Unknown result type (might be due to invalid IL or missing references)
				//IL_001f: Unknown result type (might be due to invalid IL or missing references)
				VB_0024StateMachine___Lambda_0024__10_002D0 vB_0024StateMachine___Lambda_0024__10_002D = default(VB_0024StateMachine___Lambda_0024__10_002D0);
				vB_0024StateMachine___Lambda_0024__10_002D._0024VB_0024Me = this;
				vB_0024StateMachine___Lambda_0024__10_002D._0024State = -1;
				vB_0024StateMachine___Lambda_0024__10_002D._0024Builder = AsyncTaskMethodBuilder.Create();
				vB_0024StateMachine___Lambda_0024__10_002D._0024Builder.Start<VB_0024StateMachine___Lambda_0024__10_002D0>(ref vB_0024StateMachine___Lambda_0024__10_002D);
				return vB_0024StateMachine___Lambda_0024__10_002D._0024Builder.Task;
			}), new object[0]);
			CheckBlur.Checked = (bool?)ModBase.Setup.Get("UiBlur");
			SliderBlurValue.Value = Conversions.ToInteger(ModBase.Setup.Get("UiBlurValue"));
			SliderBlurSamplingRate.Value = Conversions.ToInteger(ModBase.Setup.Get("UiBlurSamplingRate"));
			((Selector)ComboBlurType).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("UiBlurType"));
			((UIElement)PanBlurValue).Visibility = (Visibility)((!CheckBlur.Checked.GetValueOrDefault()) ? 2 : 0);
			CheckLockWindowSize.Checked = (bool?)ModBase.Setup.Get("UiLockWindowSize");
			SliderBackgroundOpacity.Value = Conversions.ToInteger(ModBase.Setup.Get("UiBackgroundOpacity"));
			SliderBackgroundBlur.Value = Conversions.ToInteger(ModBase.Setup.Get("UiBackgroundBlur"));
			((Selector)ComboBackgroundSuit).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("UiBackgroundSuit"));
			CheckBackgroundColorful.Checked = (bool?)ModBase.Setup.Get("UiBackgroundColorful");
			object objectValue = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("UiAutoPauseVideo"));
			CheckAutoPauseVideo.Checked = (bool?)objectValue;
			if (ModVideoBack.IsGaming && Operators.ConditionalCompareObjectEqual(objectValue, (object)true, false))
			{
				((UIElement)BtnBackgroundRefresh).IsEnabled = false;
			}
			BackgroundRefresh(IsHint: false, Refresh: false);
			CheckAcrylicEnabled.Checked = (bool?)ModBase.Setup.Get("UiAcrylic");
			SliderAcrylicOpacity.Value = Conversions.ToInteger(ModBase.Setup.Get("UiAcrylicOpacity"));
			((UIElement)PanAcrylicOpacity).Visibility = (Visibility)((!CheckAcrylicEnabled.Checked.GetValueOrDefault()) ? 2 : 0);
			((MyRadioBox)base.FindName(Conversions.ToString(Operators.ConcatenateObject((object)"RadioLogoType", ModBase.Setup.Get("UiLogoType"))))).Checked = true;
			((UIElement)CheckLogoLeft).Visibility = (Visibility)((!RadioLogoType0.Checked) ? 2 : 0);
			((UIElement)PanLogoText).Visibility = (Visibility)((!RadioLogoType2.Checked) ? 2 : 0);
			((UIElement)PanLogoChange).Visibility = (Visibility)((!RadioLogoType3.Checked) ? 2 : 0);
			((TextBox)TextLogoText).Text = Conversions.ToString(ModBase.Setup.Get("UiLogoText"));
			CheckLogoLeft.Checked = (bool?)ModBase.Setup.Get("UiLogoLeft");
			CheckMusicRandom.Checked = (bool?)ModBase.Setup.Get("UiMusicRandom");
			CheckMusicAuto.Checked = (bool?)ModBase.Setup.Get("UiMusicAuto");
			CheckMusicStop.Checked = (bool?)ModBase.Setup.Get("UiMusicStop");
			CheckMusicStart.Checked = (bool?)ModBase.Setup.Get("UiMusicStart");
			CheckMusicSMTC.Checked = (bool?)ModBase.Setup.Get("UiMusicSMTC");
			SliderMusicVolume.Value = Conversions.ToInteger(ModBase.Setup.Get("UiMusicVolume"));
			MusicRefreshUI();
			try
			{
				((Selector)ComboCustomPreset).SelectedIndex = Conversions.ToInteger(ModBase.Setup.Get("UiCustomPreset"));
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ModBase.Setup.Reset("UiCustomPreset");
				ProjectData.ClearProjectError();
			}
			((MyRadioBox)base.FindName(Conversions.ToString(Operators.ConcatenateObject((object)"RadioCustomType", ModBase.Setup.Load("UiCustomType", forceReload: true))))).Checked = true;
			((TextBox)TextCustomNet).Text = Conversions.ToString(ModBase.Setup.Get("UiCustomNet"));
			CheckHiddenPageDownload.Checked = (bool?)ModBase.Setup.Get("UiHiddenPageDownload");
			CheckHiddenPageLink.Checked = (bool?)ModBase.Setup.Get("UiHiddenPageLink");
			CheckHiddenPageSetup.Checked = (bool?)ModBase.Setup.Get("UiHiddenPageSetup");
			CheckHiddenPageOther.Checked = (bool?)ModBase.Setup.Get("UiHiddenPageOther");
			CheckHiddenFunctionSelect.Checked = (bool?)ModBase.Setup.Get("UiHiddenFunctionSelect");
			CheckHiddenFunctionModUpdate.Checked = (bool?)ModBase.Setup.Get("UiHiddenFunctionModUpdate");
			CheckHiddenFunctionHidden.Checked = (bool?)ModBase.Setup.Get("UiHiddenFunctionHidden");
			CheckHiddenSetupLaunch.Checked = (bool?)ModBase.Setup.Get("UiHiddenSetupLaunch");
			CheckHiddenSetupUI.Checked = (bool?)ModBase.Setup.Get("UiHiddenSetupUi");
			CheckHiddenSetupSystem.Checked = (bool?)ModBase.Setup.Get("UiHiddenSetupSystem");
			CheckHiddenOtherAbout.Checked = (bool?)ModBase.Setup.Get("UiHiddenOtherAbout");
			CheckHiddenOtherFeedback.Checked = (bool?)ModBase.Setup.Get("UiHiddenOtherFeedback");
			CheckHiddenOtherVote.Checked = (bool?)ModBase.Setup.Get("UiHiddenOtherVote");
			CheckHiddenOtherHelp.Checked = (bool?)ModBase.Setup.Get("UiHiddenOtherHelp");
			CheckHiddenOtherTest.Checked = (bool?)ModBase.Setup.Get("UiHiddenOtherTest");
			CheckHiddenVersionEdit.Checked = (bool?)ModBase.Setup.Get("UiHiddenVersionEdit");
			CheckHiddenVersionExport.Checked = (bool?)ModBase.Setup.Get("UiHiddenVersionExport");
			CheckHiddenVersionSave.Checked = (bool?)ModBase.Setup.Get("UiHiddenVersionSave");
			CheckHiddenVersionScreenshot.Checked = (bool?)ModBase.Setup.Get("UiHiddenVersionScreenshot");
			CheckHiddenVersionMod.Checked = (bool?)ModBase.Setup.Get("UiHiddenVersionMod");
			CheckHiddenVersionResourcePack.Checked = (bool?)ModBase.Setup.Get("UiHiddenVersionResourcePack");
			CheckHiddenVersionShader.Checked = (bool?)ModBase.Setup.Get("UiHiddenVersionShader");
			CheckHiddenVersionSchematic.Checked = (bool?)ModBase.Setup.Get("UiHiddenVersionSchematic");
			CheckHiddenVersionServer.Checked = (bool?)ModBase.Setup.Get("UiHiddenVersionServer");
		}
		catch (NullReferenceException val)
		{
			ProjectData.SetProjectError((System.Exception)val);
			NullReferenceException ex = val;
			ModBase.Log((System.Exception)(object)ex, "个性化设置项存在异常，已被自动重置", ModBase.LogLevel.Msgbox);
			Reset();
			ProjectData.ClearProjectError();
		}
		catch (System.Exception ex2)
		{
			ProjectData.SetProjectError(ex2);
			System.Exception ex3 = ex2;
			ModBase.Log(ex3, "重载个性化设置时出错", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public void Reset()
	{
		try
		{
			ModBase.Setup.Reset("UiLauncherTransparent");
			ModBase.Setup.Reset("UiLauncherTheme");
			ModBase.Setup.Reset("UiLauncherLogo");
			ModBase.Setup.Reset("UiLauncherHue");
			ModBase.Setup.Reset("UiLauncherSat");
			ModBase.Setup.Reset("UiLauncherDelta");
			ModBase.Setup.Reset("UiLauncherLight");
			ModBase.Setup.Reset("UiLockWindowSize");
			ModBase.Setup.Reset("UiBlur");
			ModBase.Setup.Reset("UiBlurValue");
			ModBase.Setup.Reset("UiBlurSamplingRate");
			ModBase.Setup.Reset("UiBlurType");
			ModBase.Setup.Reset("UiBackgroundColorful");
			ModBase.Setup.Reset("UiBackgroundOpacity");
			ModBase.Setup.Reset("UiBackgroundBlur");
			ModBase.Setup.Reset("UiBackgroundSuit");
			ModBase.Setup.Reset("UiDarkMode");
			ModBase.Setup.Reset("UiFont");
			ModBase.Setup.Reset("UiLogoType");
			ModBase.Setup.Reset("UiLogoText");
			ModBase.Setup.Reset("UiLogoLeft");
			ModBase.Setup.Reset("UiMusicVolume");
			ModBase.Setup.Reset("UiMusicStop");
			ModBase.Setup.Reset("UiMusicStart");
			ModBase.Setup.Reset("UiMusicRandom");
			ModBase.Setup.Reset("UiMusicSMTC");
			ModBase.Setup.Reset("UiMusicAuto");
			ModBase.Setup.Reset("UiCustomType");
			ModBase.Setup.Reset("UiCustomPreset");
			ModBase.Setup.Reset("UiCustomNet");
			ModBase.Setup.Reset("UiHiddenPageDownload");
			ModBase.Setup.Reset("UiHiddenPageLink");
			ModBase.Setup.Reset("UiHiddenPageSetup");
			ModBase.Setup.Reset("UiHiddenPageOther");
			ModBase.Setup.Reset("UiHiddenFunctionSelect");
			ModBase.Setup.Reset("UiHiddenFunctionModUpdate");
			ModBase.Setup.Reset("UiHiddenFunctionHidden");
			ModBase.Setup.Reset("UiHiddenSetupLaunch");
			ModBase.Setup.Reset("UiHiddenSetupUi");
			ModBase.Setup.Reset("UiHiddenSetupSystem");
			ModBase.Setup.Reset("UiHiddenOtherAbout");
			ModBase.Setup.Reset("UiHiddenOtherFeedback");
			ModBase.Setup.Reset("UiHiddenOtherVote");
			ModBase.Setup.Reset("UiHiddenOtherHelp");
			ModBase.Setup.Reset("UiHiddenOtherTest");
			ModBase.Setup.Reset("UiHiddenVersionEdit");
			ModBase.Setup.Reset("UiHiddenVersionExport");
			ModBase.Setup.Reset("UiHiddenVersionSave");
			ModBase.Setup.Reset("UiHiddenVersionScreenshot");
			ModBase.Setup.Reset("UiHiddenVersionMod");
			ModBase.Setup.Reset("UiHiddenVersionResourcePack");
			ModBase.Setup.Reset("UiHiddenVersionShader");
			ModBase.Setup.Reset("UiHiddenVersionSchematic");
			ModBase.Setup.Reset("UiHiddenVersionServer");
			ModBase.Setup.Reset("UiAutoPauseVideo");
			ModBase.Log("[Setup] 已初始化个性化设置！");
			ModMain.Hint("已初始化个性化设置", ModMain.HintType.Finish, Log: false);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "初始化个性化设置失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
		Reload();
	}

	private static void SliderChange(MySlider sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), sender.Value);
			if (Operators.CompareString(((FrameworkElement)sender).Tag.ToString(), "UiAcrylicOpacity", false) == 0)
			{
				ModSecret.ThemeRefreshMain();
			}
		}
	}

	private static void ComboChange(MyComboBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), ((Selector)sender).SelectedIndex);
		}
	}

	private static void CheckBoxChange(MyCheckBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled != 0)
		{
			return;
		}
		if (Operators.CompareString(((FrameworkElement)sender).Tag.ToString(), "UiDarkMode", false) == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), sender.Checked.GetValueOrDefault() ? 1 : 0);
			ModSecret.ThemeRefresh();
		}
		else if (Operators.CompareString(((FrameworkElement)sender).Tag.ToString(), "UiAcrylic", false) == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), sender.Checked);
			ModSecret.ThemeRefreshMain();
			if (ModMain.FrmSetupUI != null)
			{
				((UIElement)ModMain.FrmSetupUI.PanAcrylicOpacity).Visibility = (Visibility)((!sender.Checked.GetValueOrDefault()) ? 2 : 0);
			}
		}
		else
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), sender.Checked);
		}
	}

	private static void TextBoxChange(MyTextBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			ModBase.Setup.Set(Conversions.ToString(((FrameworkElement)sender).Tag), ((TextBox)sender).Text);
		}
	}

	private static void RadioBoxChange(MyRadioBox sender, object e)
	{
		string[] array = ((FrameworkElement)sender).Tag.ToString().Split("/", (StringSplitOptions)0);
		if (ModAnimation.AniControlEnabled == 0)
		{
			int num = int.Parse(array[1]);
			ModBase.Setup.Set(array[0], num);
			if (Operators.CompareString(array[0], "UiLauncherTheme", false) == 0)
			{
				ModSecret.ThemeRefresh(num);
			}
		}
	}

	private void ComboFontChange(MyComboBox sender, object e)
	{
		if (ModAnimation.AniControlEnabled == 0 && ((UIElement)sender).IsEnabled && NewLateBinding.LateGet(((Selector)sender).SelectedItem, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) != null)
		{
			ModBase.Setup.Set("UiFont", RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(((Selector)sender).SelectedItem, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null)));
		}
	}

	private void BtnUIBgOpen_Click(object sender, EventArgs e)
	{
		ModBase.OpenExplorer(ModBase.ExePath + "PCL\\Pictures\\");
	}

	private void BtnBackgroundRefresh_Click(object sender, EventArgs e)
	{
		BackgroundRefresh(IsHint: true, Refresh: true);
	}

	public void BackgroundRefreshUI(bool Show, int Count)
	{
		if (!Information.IsNothing((object)PanBackgroundOpacity))
		{
			if (Show)
			{
				((UIElement)PanBackgroundOpacity).Visibility = (Visibility)0;
				((UIElement)PanBackgroundBlur).Visibility = (Visibility)0;
				((UIElement)PanBackgroundSuit).Visibility = (Visibility)0;
				((UIElement)BtnBackgroundClear).Visibility = (Visibility)0;
				((UIElement)CheckAutoPauseVideo).Visibility = (Visibility)0;
				CardBackground.Title = "背景图片/视频（" + Conversions.ToString(Count) + " 张）";
			}
			else
			{
				((UIElement)PanBackgroundOpacity).Visibility = (Visibility)2;
				((UIElement)PanBackgroundBlur).Visibility = (Visibility)2;
				((UIElement)PanBackgroundSuit).Visibility = (Visibility)2;
				((UIElement)BtnBackgroundClear).Visibility = (Visibility)2;
				((UIElement)CheckAutoPauseVideo).Visibility = (Visibility)2;
				CardBackground.Title = "背景图片/视频";
			}
			CardBackground.TriggerForceResize();
		}
	}

	private void BtnBackgroundClear_Click(object sender, EventArgs e)
	{
		if (ModMain.MyMsgBox("即将删除背景内容文件夹中的所有文件。\r\n此操作不可撤销，是否确定？", "警告", "确定", "取消", "", IsWarn: true) == 1)
		{
			ModBase.DeleteDirectory(ModBase.ExePath + "PCL\\Pictures");
			BackgroundRefresh(IsHint: false, Refresh: true);
			ModMain.Hint("背景内容已清空！", ModMain.HintType.Finish);
		}
	}

	public static void BackgroundRefresh(bool IsHint, bool Refresh)
	{
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Invalid comparison between Unknown and I4
		try
		{
			Directory.CreateDirectory(ModBase.ExePath + "PCL\\Pictures\\");
			List<string> val = Enumerable.ToList<string>(Enumerable.Select<FileInfo, string>(Enumerable.Where<FileInfo>(ModBase.EnumerateFiles(ModBase.ExePath + "PCL\\Pictures\\"), (Func<FileInfo, bool>)([SpecialName] (FileInfo file) => !((FileSystemInfo)file).Extension.Equals(".ini", (StringComparison)5) && !((FileSystemInfo)file).Extension.Equals(".db", (StringComparison)5))), (Func<FileInfo, string>)([SpecialName] (FileInfo file) => ((FileSystemInfo)file).FullName)));
			EventHandler<ExceptionRoutedEventArgs> val2 = [SpecialName] (object sender, ExceptionRoutedEventArgs e) =>
			{
				System.Exception errorException = e.ErrorException;
				string text2 = ModMain.FrmMain.VideoBack.Source.ToString();
				if (ModMain.FrmMain.VideoBack.Source != null)
				{
					ModVideoBack.VideoStop();
					if (errorException.Message.Contains("0xC00D109B"))
					{
						ModBase.Log("刷新背景内容失败，该视频文件可能并非 H.264（AVC） 格式。\r\n你可以尝试使用视频转码工具打开视频文件并设定目标格式为 H.264（AVC） ，然后转码该视频。\r\n文件：" + text2, ModBase.LogLevel.Msgbox);
					}
					else
					{
						ModBase.Log(errorException, "刷新背景内容失败（" + text2 + "）", ModBase.LogLevel.Msgbox);
					}
				}
			};
			ModMain.FrmMain.VideoBack.MediaFailed -= val2;
			ModVideoBack.GamingStateChanged -= ModVideoBack.OnGamingStateChanged;
			ModVideoBack.ForcePlayChanged -= ModVideoBack.OnForcePlayChanged;
			ModVideoBack.GamingStateChanged += ModVideoBack.OnGamingStateChanged;
			ModVideoBack.ForcePlayChanged += ModVideoBack.OnForcePlayChanged;
			if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("UiAutoPauseVideo"), (object)false, false))
			{
				ModVideoBack.ForcePlay = true;
			}
			if (val.Count == 0)
			{
				if (Refresh)
				{
					if ((int)((UIElement)ModMain.FrmMain.ImgBack).Visibility == 2)
					{
						if (IsHint)
						{
							ModMain.Hint("未检测到可用背景内容！", ModMain.HintType.Critical);
						}
					}
					else
					{
						((UIElement)ModMain.FrmMain.ImgBack).Visibility = (Visibility)2;
						if (IsHint)
						{
							ModMain.Hint("背景内容已清除！", ModMain.HintType.Finish);
						}
					}
				}
				if (!Information.IsNothing((object)ModMain.FrmSetupUI))
				{
					ModMain.FrmSetupUI.BackgroundRefreshUI(Show: false, 0);
				}
				return;
			}
			if (Refresh)
			{
				string text = RandomUtils.PickRandom((System.Collections.Generic.ICollection<string>)val);
				try
				{
					((Panel)ModMain.FrmMain.ImgBack).Background = null;
					ModVideoBack.VideoStop();
					ModBase.Log("[UI] 加载背景内容：" + text);
					((Panel)ModMain.FrmMain.ImgBack).Background = (Brush)(object)(ImageBrush)new MyBitmap(text);
					ModBase.Setup.Load("UiBackgroundSuit", forceReload: true);
					((UIElement)ModMain.FrmMain.ImgBack).Visibility = (Visibility)0;
					if (IsHint)
					{
						ModMain.Hint("背景内容已刷新：" + ModBase.GetFileNameFromPath(text), ModMain.HintType.Finish, Log: false);
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					try
					{
						ModMain.FrmMain.VideoBack.MediaFailed += val2;
						ModBase.Log(ex2, "[UI] 加载背景图片失败" + text);
						ModMain.Hint("图片加载失败，尝试将文件作为视频播放：" + text);
						((UIElement)ModMain.FrmMain.ImgBack).Visibility = (Visibility)0;
						ModMain.FrmMain.VideoBack.Source = new Uri(text, (UriKind)1);
						ModVideoBack.VideoPlay();
						if (IsHint)
						{
							ModMain.Hint("背景内容已刷新：" + ModBase.GetFileNameFromPath(text), ModMain.HintType.Finish, Log: false);
						}
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						ModBase.Log(ex4, "播放背景内容时出现未知错误：");
						ProjectData.ClearProjectError();
					}
					ProjectData.ClearProjectError();
				}
			}
			if (!Information.IsNothing((object)ModMain.FrmSetupUI))
			{
				ModMain.FrmSetupUI.BackgroundRefreshUI(Show: true, val.Count);
			}
		}
		catch (System.Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			System.Exception ex6 = ex5;
			ModBase.Log(ex6, "刷新背景内容时出现未知错误", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnLogoChange_Click(object sender, EventArgs e)
	{
		string text = SystemDialogs.SelectFile("常用图片文件(*.png;*.jpg;*.gif;*.webp)|*.png;*.jpg;*.gif;*.webp", "选择图片");
		if (Operators.CompareString(text, "", false) == 0)
		{
			return;
		}
		try
		{
			File.Delete(ModBase.ExePath + "PCL\\Logo.png");
			ModBase.CopyFile(text, ModBase.ExePath + "PCL\\Logo.png");
			ModMain.FrmMain.ImageTitleLogo.Source = null;
			ModMain.FrmMain.ImageTitleLogo.Source = ModBase.ExePath + "PCL\\Logo.png";
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			if (ex2.Message.Contains("参数无效"))
			{
				ModBase.Log("改变标题栏图片失败，该图片文件可能并非标准格式。\r\n你可以尝试使用画图打开该文件并重新保存，这会让图片变为标准格式。", ModBase.LogLevel.Msgbox);
			}
			else
			{
				ModBase.Log(ex2, "设置标题栏图片失败", ModBase.LogLevel.Msgbox);
			}
			ModMain.FrmMain.ImageTitleLogo.Source = null;
			ProjectData.ClearProjectError();
		}
	}

	private void RadioLogoType3_Check(object sender, ModBase.RouteEventArgs e)
	{
		if (ModAnimation.AniControlEnabled != 0 || !e.RaiseByMouse)
		{
			return;
		}
		while (true)
		{
			if (File.Exists(ModBase.ExePath + "PCL\\Logo.png"))
			{
				try
				{
					ModMain.FrmMain.ImageTitleLogo.Source = null;
					ModMain.FrmMain.ImageTitleLogo.Source = ModBase.ExePath + "PCL\\Logo.png";
					return;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					if (ex2.Message.Contains("参数无效"))
					{
						ModBase.Log("调整标题栏图片失败，该图片文件可能并非标准格式。\r\n你可以尝试使用画图打开该文件并重新保存，这会让图片变为标准格式。", ModBase.LogLevel.Msgbox);
					}
					else
					{
						ModBase.Log(ex2, "调整标题栏图片失败", ModBase.LogLevel.Msgbox);
					}
					ModMain.FrmMain.ImageTitleLogo.Source = null;
					e.Handled = true;
					try
					{
						File.Delete(ModBase.ExePath + "PCL\\Logo.png");
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						ModBase.Log(ex4, "清理错误的标题栏图片失败", ModBase.LogLevel.Msgbox);
						ProjectData.ClearProjectError();
					}
					ProjectData.ClearProjectError();
					return;
				}
			}
			string text = SystemDialogs.SelectFile("常用图片文件(*.png;*.jpg;*.gif;*.webp)|*.png;*.jpg;*.gif;*.webp", "选择图片");
			if (Operators.CompareString(text, "", false) == 0)
			{
				break;
			}
			try
			{
				File.Delete(ModBase.ExePath + "PCL\\Logo.png");
				ModBase.CopyFile(text, ModBase.ExePath + "PCL\\Logo.png");
			}
			catch (System.Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				System.Exception ex6 = ex5;
				ModBase.Log(ex6, "复制标题栏图片失败", ModBase.LogLevel.Msgbox);
				ProjectData.ClearProjectError();
				return;
			}
		}
		ModMain.FrmMain.ImageTitleLogo.Source = null;
		e.Handled = true;
	}

	private void BtnLogoDelete_Click(object sender, EventArgs e)
	{
		try
		{
			File.Delete(ModBase.ExePath + "PCL\\Logo.png");
			RadioLogoType1.SetChecked(value: true, user: true);
			ModMain.Hint("标题栏图片已清空！", ModMain.HintType.Finish);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "清空标题栏图片失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnMusicOpen_Click(object sender, EventArgs e)
	{
		ModBase.OpenExplorer(ModBase.ExePath + "PCL\\Musics\\");
	}

	private void BtnMusicRefresh_Click(object sender, EventArgs e)
	{
		ModMusic.MusicRefreshPlay(ShowHint: true);
	}

	public void MusicRefreshUI()
	{
		if (PanBackgroundOpacity != null)
		{
			if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)ModMusic.MusicAllList))
			{
				((UIElement)PanMusicVolume).Visibility = (Visibility)0;
				((UIElement)PanMusicDetail).Visibility = (Visibility)0;
				((UIElement)BtnMusicClear).Visibility = (Visibility)0;
				CardMusic.Title = "背景音乐（" + Conversions.ToString(Enumerable.Count<FileInfo>(ModBase.EnumerateFiles(ModBase.ExePath + "PCL\\Musics\\"))) + " 首）";
			}
			else
			{
				((UIElement)PanMusicVolume).Visibility = (Visibility)2;
				((UIElement)PanMusicDetail).Visibility = (Visibility)2;
				((UIElement)BtnMusicClear).Visibility = (Visibility)2;
				CardMusic.Title = "背景音乐";
			}
			CardMusic.TriggerForceResize();
		}
	}

	private void BtnMusicClear_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		if (ModMain.MyMsgBox("即将删除背景音乐文件夹中的所有文件。\r\n此操作不可撤销，是否确定？", "警告", "确定", "取消", "", IsWarn: true) != 1)
		{
			return;
		}
		object action;
		if (_Closure_0024__._0024I29_002D0 != null)
		{
			action = _Closure_0024__._0024I29_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
				//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ad: Expected O, but got Unknown
				ModMain.Hint("正在删除背景音乐……");
				ModMusic.MusicNAudio = null;
				ModMusic.MusicWaitingList = new List<string>();
				ModMusic.MusicAllList = new List<string>();
				Thread.Sleep(200);
				try
				{
					ModBase.DeleteDirectory(ModBase.ExePath + "PCL\\Musics");
					ModMain.Hint("背景音乐已删除！", ModMain.HintType.Finish);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "删除背景音乐失败", ModBase.LogLevel.Msgbox);
					ProjectData.ClearProjectError();
				}
				try
				{
					Directory.CreateDirectory(ModBase.ExePath + "PCL\\Musics");
					object action2;
					if (_Closure_0024__._0024I29_002D1 != null)
					{
						action2 = _Closure_0024__._0024I29_002D1;
					}
					else
					{
						Action val2 = [SpecialName] () =>
						{
							ModMusic.MusicRefreshPlay(ShowHint: false);
						};
						_Closure_0024__._0024I29_002D1 = val2;
						action2 = (object)val2;
					}
					ModBase.RunInUi((Action)action2);
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, "重建背景音乐文件夹失败", ModBase.LogLevel.Msgbox);
					ProjectData.ClearProjectError();
				}
			};
			_Closure_0024__._0024I29_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInThread((Action)action);
	}

	private void CheckMusicStart_Change()
	{
		if (ModAnimation.AniControlEnabled == 0 && CheckMusicStart.Checked.GetValueOrDefault())
		{
			CheckMusicStop.Checked = false;
		}
	}

	private void CheckMusicStop_Change()
	{
		if (ModAnimation.AniControlEnabled == 0 && CheckMusicStop.Checked.GetValueOrDefault())
		{
			CheckMusicStart.Checked = false;
		}
	}

	private void BtnCustomFile_Click(object sender, EventArgs e)
	{
		try
		{
			if (!File.Exists(ModBase.ExePath + "PCL\\Custom.xaml") || ModMain.MyMsgBox("当前已存在布局文件，继续生成教学文件将会覆盖现有布局文件！", "覆盖确认", "继续", "取消", "", IsWarn: true) != 2)
			{
				ModBase.WriteFile(ModBase.ExePath + "PCL\\Custom.xaml", ModBase.GetResourceStream("Resources/Custom.xml"));
				ModMain.Hint("教学文件已生成！", ModMain.HintType.Finish);
				ModBase.OpenExplorer(ModBase.ExePath + "PCL\\Custom.xaml");
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "生成教学文件失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnCustomRefresh_Click()
	{
		ModMain.FrmLaunchRight.ForceRefresh();
		ModMain.Hint("已刷新主页！", ModMain.HintType.Finish);
	}

	private void BtnCustomTutorial_Click(object sender, EventArgs e)
	{
		ModMain.MyMsgBox("1. 点击 生成教学文件 按钮，这会在 PCL 文件夹下生成 Custom.xaml 布局文件。\r\n2. 使用记事本等工具打开这个文件并进行修改，修改完记得保存。\r\n3. 点击 刷新主页 按钮，查看主页现在长啥样了。\r\n\r\n你可以在生成教学文件后直接刷新主页，对照着进行修改，更有助于理解。\r\n直接将主页文件拖进 PCL 窗口也可以快捷加载。", "主页自定义教程");
	}

	private void LabLauncherTheme5Unlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
		MyRadioBox radioLauncherTheme5Gray;
		((UIElement)(radioLauncherTheme5Gray = RadioLauncherTheme5Gray)).Opacity = ((UIElement)radioLauncherTheme5Gray).Opacity - 0.23;
		((UIElement)(radioLauncherTheme5Gray = RadioLauncherTheme5)).Opacity = ((UIElement)radioLauncherTheme5Gray).Opacity + 0.23;
		ModAnimation.AniStart((System.Collections.IList)(object)checked(new ModAnimation.AniData[2]
		{
			ModAnimation.AaOpacity(RadioLauncherTheme5Gray, 1.0, (int)Math.Round(1000.0 * ModAnimation.AniSpeed)),
			ModAnimation.AaOpacity(RadioLauncherTheme5, -1.0, (int)Math.Round(1000.0 * ModAnimation.AniSpeed))
		}), "ThemeUnlock");
		if (((UIElement)RadioLauncherTheme5Gray).Opacity < 0.08)
		{
			ModSecret.ThemeUnlock(5, ShowDoubleHint: true, "隐藏主题 玄素黑 已解锁！");
			ModAnimation.AniStop("ThemeUnlock");
			RadioLauncherTheme5.Checked = true;
		}
	}

	private void LabLauncherTheme11Click_MouseLeftButtonUp()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		if (((int)((UIElement)LabLauncherTheme11Click).Visibility == 2 || (((FrameworkElement)LabLauncherTheme11Click).ToolTip ?? "").ToString().Contains("点击")) && ModMain.MyMsgBox("1. 不爬取或攻击相关服务或网站，不盗取相关账号，没有谜题可以或需要以此来解决。\r\n2. 不得篡改或损毁相关公开信息，请尽量让它们保持原状。\r\n3. 在你感到迷茫的时候，看看回声洞可能会给你带来惊喜。\r\n\r\n若违规，可能会被从任意相关群中踢出！", "解密游戏的基本规则", "我知道了", "恕我拒绝") == 1)
		{
			ModMain.MyMsgBox("你需要用自己的智慧来找到下一步的线索……\r\n初始线索：gnp.dorC61\\60\\20\\0202\\moc.x1xa.2s\\\\:sp" + "T".ToLower() + "th", "解密游戏");
		}
	}

	private void LabLauncherTheme8Copy_MouseRightButtonUp()
	{
		ModBase.OpenWebsite("https://afdian.com/a/LTCat");
	}

	private void LabLauncherTheme9Copy_MouseRightButtonUp()
	{
		PageOtherLeft.TryFeedback();
	}

	private void RadioLauncherTheme14_Change(object sender, ModBase.RouteEventArgs e)
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Invalid comparison between Unknown and I4
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		if (RadioLauncherTheme14.Checked)
		{
			if ((int)((UIElement)LabLauncherHue).Visibility == 0)
			{
				return;
			}
			((UIElement)LabLauncherHue).Visibility = (Visibility)0;
			((UIElement)SliderLauncherHue).Visibility = (Visibility)0;
			((UIElement)LabLauncherSat).Visibility = (Visibility)0;
			((UIElement)SliderLauncherSat).Visibility = (Visibility)0;
			((UIElement)LabLauncherDelta).Visibility = (Visibility)0;
			((UIElement)SliderLauncherDelta).Visibility = (Visibility)0;
			((UIElement)LabLauncherLight).Visibility = (Visibility)0;
			((UIElement)SliderLauncherLight).Visibility = (Visibility)0;
		}
		else
		{
			if ((int)((UIElement)LabLauncherHue).Visibility == 2)
			{
				return;
			}
			((UIElement)LabLauncherHue).Visibility = (Visibility)2;
			((UIElement)SliderLauncherHue).Visibility = (Visibility)2;
			((UIElement)LabLauncherSat).Visibility = (Visibility)2;
			((UIElement)SliderLauncherSat).Visibility = (Visibility)2;
			((UIElement)LabLauncherDelta).Visibility = (Visibility)2;
			((UIElement)SliderLauncherDelta).Visibility = (Visibility)2;
			((UIElement)LabLauncherLight).Visibility = (Visibility)2;
			((UIElement)SliderLauncherLight).Visibility = (Visibility)2;
		}
		CardLauncher.TriggerForceResize();
	}

	private void HSL_Change()
	{
		if (ModAnimation.AniControlEnabled == 0 && SliderLauncherSat != null && ((FrameworkElement)SliderLauncherSat).IsLoaded)
		{
			ModSecret.ThemeRefresh();
		}
	}

	public static void HiddenRefresh()
	{
		if (ModMain.FrmMain.PanTitleSelect == null || !((FrameworkElement)ModMain.FrmMain.PanTitleSelect).IsLoaded)
		{
			return;
		}
		checked
		{
			try
			{
				if (Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenPageDownload")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenPageLink")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenPageSetup")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenPageOther")))))
				{
					((UIElement)ModMain.FrmMain.PanTitleSelect).Visibility = (Visibility)2;
				}
				else
				{
					((UIElement)ModMain.FrmMain.PanTitleSelect).Visibility = (Visibility)0;
					((UIElement)ModMain.FrmMain.BtnTitleSelect1).Visibility = (Visibility)(Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenPageDownload")))) ? 2 : 0);
					((UIElement)ModMain.FrmMain.BtnTitleSelect2).Visibility = (Visibility)(Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenPageLink")))) ? 2 : 0);
					((UIElement)ModMain.FrmMain.BtnTitleSelect3).Visibility = (Visibility)(Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenPageSetup")))) ? 2 : 0);
					((UIElement)ModMain.FrmMain.BtnTitleSelect4).Visibility = (Visibility)(Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenPageOther")))) ? 2 : 0);
				}
				ModMain.FrmLaunchLeft.RefreshButtonsUI();
				if (ModMain.FrmSetupUI != null)
				{
					((UIElement)ModMain.FrmSetupUI.CardSwitch).Visibility = (Visibility)(Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenFunctionHidden")))) ? 2 : 0);
				}
				if (ModMain.FrmSetupLeft != null)
				{
					((UIElement)ModMain.FrmSetupLeft.ItemLaunch).Visibility = (Visibility)(Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenSetupLaunch")))) ? 2 : 0);
					((UIElement)ModMain.FrmSetupLeft.ItemUI).Visibility = (Visibility)(Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenSetupUi")))) ? 2 : 0);
					((UIElement)ModMain.FrmSetupLeft.ItemSystem).Visibility = (Visibility)(Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenSetupSystem")))) ? 2 : 0);
					int num = 0;
					if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenSetupLaunch"))))
					{
						num++;
					}
					if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenSetupUi"))))
					{
						num++;
					}
					if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenSetupSystem"))))
					{
						num++;
					}
					((UIElement)ModMain.FrmSetupLeft.PanItem).Visibility = (Visibility)((num < 2 && !HiddenForceShow) ? 2 : 0);
				}
				int num2 = 0;
				if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenOtherHelp"))))
				{
					num2++;
				}
				if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenOtherAbout"))))
				{
					num2++;
				}
				if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenOtherTest"))))
				{
					num2++;
				}
				if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenOtherFeedback"))))
				{
					num2++;
				}
				if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenOtherVote"))))
				{
					num2++;
				}
				if (ModMain.FrmOtherLeft != null)
				{
					((UIElement)ModMain.FrmOtherLeft.ItemHelp).Visibility = (Visibility)(Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherHelp")))) ? 2 : 0);
					((UIElement)ModMain.FrmOtherLeft.ItemFeedback).Visibility = (Visibility)(Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherFeedback")))) ? 2 : 0);
					((UIElement)ModMain.FrmOtherLeft.ItemVote).Visibility = (Visibility)(Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherVote")))) ? 2 : 0);
					((UIElement)ModMain.FrmOtherLeft.ItemAbout).Visibility = (Visibility)(Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherAbout")))) ? 2 : 0);
					((UIElement)ModMain.FrmOtherLeft.ItemTest).Visibility = (Visibility)(Conversions.ToBoolean((object)(!HiddenForceShow && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherTest")))) ? 2 : 0);
					((UIElement)ModMain.FrmOtherLeft.PanItem).Visibility = (Visibility)((num2 < 2 && !HiddenForceShow) ? 2 : 0);
				}
				if (num2 == 1 && !HiddenForceShow)
				{
					if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenOtherHelp"))))
					{
						ModMain.FrmMain.BtnTitleSelect4.Text = "帮助";
					}
					else if (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenOtherAbout"))))
					{
						ModMain.FrmMain.BtnTitleSelect4.Text = "关于";
					}
					else
					{
						ModMain.FrmMain.BtnTitleSelect4.Text = "百宝箱";
					}
				}
				else
				{
					ModMain.FrmMain.BtnTitleSelect4.Text = "更多";
				}
				if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSelect)
				{
					ModMain.FrmSelectRight.BtnEmptyDownload_Loaded();
				}
				if (ModMain.FrmMain.PageCurrent == FormMain.PageType.Launch)
				{
					ModMain.FrmLaunchLeft.RefreshButtonsUI();
				}
				if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup && ModMain.FrmInstanceModDisabled != null)
				{
					ModMain.FrmInstanceModDisabled.BtnDownload_Loaded();
				}
				if (ModMain.FrmSetupUI != null)
				{
					ModMain.FrmSetupUI.CardSwitch.Title = (HiddenForceShow ? "功能隐藏（已暂时关闭，按 F12 以重新启用）" : "功能隐藏");
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "刷新功能隐藏项目失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}
	}

	private void HiddenSetupMain()
	{
		if (CheckHiddenPageSetup.Checked.GetValueOrDefault())
		{
			CheckHiddenSetupLaunch.Checked = true;
			CheckHiddenSetupSystem.Checked = true;
			CheckHiddenSetupUI.Checked = true;
		}
		else if (Conversions.ToBoolean((object)(Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenSetupLaunch")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenSetupUi")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenSetupSystem")))))
		{
			CheckHiddenSetupLaunch.Checked = false;
			CheckHiddenSetupSystem.Checked = false;
			CheckHiddenSetupUI.Checked = false;
		}
	}

	private void HiddenSetupSub()
	{
		if (Conversions.ToBoolean((object)(Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenSetupLaunch")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenSetupUi")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenSetupSystem")))))
		{
			CheckHiddenPageSetup.Checked = true;
		}
		else
		{
			CheckHiddenPageSetup.Checked = false;
		}
	}

	private void HiddenOtherMain()
	{
		if (CheckHiddenPageOther.Checked.GetValueOrDefault())
		{
			CheckHiddenOtherAbout.Checked = true;
			CheckHiddenOtherTest.Checked = true;
			CheckHiddenOtherFeedback.Checked = true;
			CheckHiddenOtherVote.Checked = true;
			CheckHiddenOtherHelp.Checked = true;
		}
		else if (Conversions.ToBoolean((object)(Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherHelp")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherAbout")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherTest")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherVote")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherFeedback")))))
		{
			CheckHiddenOtherAbout.Checked = false;
			CheckHiddenOtherTest.Checked = false;
			CheckHiddenOtherFeedback.Checked = false;
			CheckHiddenOtherVote.Checked = false;
			CheckHiddenOtherHelp.Checked = false;
		}
	}

	private void HiddenOtherSub(object sender, bool user)
	{
		if (Conversions.ToBoolean((object)(Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherHelp")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherAbout")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherTest")))))
		{
			CheckHiddenPageOther.Checked = true;
		}
		else
		{
			CheckHiddenPageOther.Checked = false;
		}
		if (user && Conversions.ToBoolean((object)(Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherHelp")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherAbout")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherTest")))))
		{
			CheckHiddenOtherFeedback.Checked = true;
			CheckHiddenOtherVote.Checked = true;
		}
	}

	private void HiddenOtherNet(object sender, bool user)
	{
		if (user && Conversions.ToBoolean((object)(Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherHelp")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherAbout")) && Conversions.ToBoolean(ModBase.Setup.Get("UiHiddenOtherTest")) && (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenOtherFeedback"))) || Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiHiddenOtherVote")))))))
		{
			CheckHiddenOtherAbout.Checked = false;
			CheckHiddenOtherTest.Checked = false;
			CheckHiddenOtherHelp.Checked = false;
		}
	}

	private void HiddenHint(object sender, bool user)
	{
		if (Conversions.ToBoolean((object)(ModAnimation.AniControlEnabled == 0 && Conversions.ToBoolean(NewLateBinding.LateGet(sender, (System.Type)null, "Checked", new object[0], (string[])null, (System.Type[])null, (bool[])null)))))
		{
			ModMain.Hint("按 F12 即可暂时关闭功能隐藏设置。千万别忘了，要不然设置就改不回来了……");
		}
	}

	private void SliderLoad()
	{
		SliderMusicVolume.GetHintText = (VB_0024AnonymousDelegate_22<object, object>)([SpecialName] (object v) => Operators.ConcatenateObject(NewLateBinding.LateGet((object)null, typeof(Math), "Ceiling", new object[] { Operators.MultiplyObject(v, (object)0.1) }, (string[])null, (System.Type[])null, (bool[])null), (object)"%"));
		SliderLauncherOpacity.GetHintText = (VB_0024AnonymousDelegate_22<object, object>)([SpecialName] (object v) => Operators.ConcatenateObject(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[] { Operators.AddObject((object)40, Operators.MultiplyObject(v, (object)0.1)) }, (string[])null, (System.Type[])null, (bool[])null), (object)"%"));
		SliderLauncherHue.GetHintText = (VB_0024AnonymousDelegate_22<object, object>)([SpecialName] (object v) => Operators.ConcatenateObject(v, (object)"°"));
		SliderLauncherSat.GetHintText = (VB_0024AnonymousDelegate_22<object, object>)([SpecialName] (object v) => Operators.ConcatenateObject(v, (object)"%"));
		checked
		{
			SliderLauncherDelta.GetHintText = (VB_0024AnonymousDelegate_24<int, string>)([SpecialName] (int Value) =>
			{
				if (Value > 90)
				{
					return "+" + Conversions.ToString(Value - 90);
				}
				return (Value == 90) ? Conversions.ToString(0) : Conversions.ToString(Value - 90);
			});
			SliderLauncherLight.GetHintText = (VB_0024AnonymousDelegate_24<int, string>)([SpecialName] (int Value) =>
			{
				if (Value > 20)
				{
					return "+" + Conversions.ToString(Value - 20);
				}
				return (Value == 20) ? Conversions.ToString(0) : Conversions.ToString(Value - 20);
			});
			SliderBackgroundOpacity.GetHintText = (VB_0024AnonymousDelegate_22<object, object>)([SpecialName] (object v) => Operators.ConcatenateObject(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[] { Operators.MultiplyObject(v, (object)0.1) }, (string[])null, (System.Type[])null, (bool[])null), (object)"%"));
			SliderBackgroundBlur.GetHintText = (VB_0024AnonymousDelegate_22<object, object>)([SpecialName] (object v) => Operators.ConcatenateObject(v, (object)" 像素"));
			SliderBlurValue.GetHintText = (VB_0024AnonymousDelegate_22<object, object>)([SpecialName] (object v) => Operators.ConcatenateObject(v, (object)" 像素"));
			SliderBlurSamplingRate.GetHintText = (VB_0024AnonymousDelegate_22<object, object>)([SpecialName] (object v) => Operators.ConcatenateObject(v, (object)"%"));
		}
	}

	private void BtnHomepageMarket_Click(object sender, EventArgs e)
	{
		ModMain.FrmMain.PageChange(new FormMain.PageStackData
		{
			Page = FormMain.PageType.HomePageMarket
		});
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pagesetup/pagesetupui.xaml", (UriKind)2);
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
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Expected O, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected O, but got Unknown
		//IL_0317: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Expected O, but got Unknown
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected O, but got Unknown
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0465: Expected O, but got Unknown
		//IL_047f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected O, but got Unknown
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0597: Expected O, but got Unknown
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Expected O, but got Unknown
		//IL_0665: Unknown result type (might be due to invalid IL or missing references)
		//IL_066f: Expected O, but got Unknown
		//IL_06ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Expected O, but got Unknown
		//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06db: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanMain = (StackPanel)target;
			break;
		case 3:
			CardLauncher = (MyCard)target;
			break;
		case 4:
			SliderLauncherOpacity = (MySlider)target;
			break;
		case 5:
			LabLauncherHue = (TextBlock)target;
			break;
		case 6:
			SliderLauncherHue = (MySlider)target;
			break;
		case 7:
			LabLauncherDelta = (TextBlock)target;
			break;
		case 8:
			SliderLauncherDelta = (MySlider)target;
			break;
		case 9:
			LabLauncherSat = (TextBlock)target;
			break;
		case 10:
			SliderLauncherSat = (MySlider)target;
			break;
		case 11:
			LabLauncherLight = (TextBlock)target;
			break;
		case 12:
			SliderLauncherLight = (MySlider)target;
			break;
		case 13:
			PanLauncherTheme = (Grid)target;
			break;
		case 14:
			RadioLauncherTheme0 = (MyRadioBox)target;
			break;
		case 15:
			RadioLauncherTheme1 = (MyRadioBox)target;
			break;
		case 16:
			RadioLauncherTheme2 = (MyRadioBox)target;
			break;
		case 17:
			RadioLauncherTheme3 = (MyRadioBox)target;
			break;
		case 18:
			RadioLauncherTheme4 = (MyRadioBox)target;
			break;
		case 19:
			RadioLauncherTheme5 = (MyRadioBox)target;
			break;
		case 20:
			RadioLauncherTheme5Gray = (MyRadioBox)target;
			break;
		case 21:
			LabLauncherTheme5Unlock = (TextBlock)target;
			break;
		case 22:
			RadioLauncherTheme12 = (MyRadioBox)target;
			break;
		case 23:
			RadioLauncherTheme6 = (MyRadioBox)target;
			break;
		case 24:
			RadioLauncherTheme7 = (MyRadioBox)target;
			break;
		case 25:
			RadioLauncherTheme13 = (MyRadioBox)target;
			break;
		case 26:
			RadioLauncherTheme8 = (MyRadioBox)target;
			break;
		case 27:
			LabLauncherTheme8Copy = (TextBlock)target;
			break;
		case 28:
			RadioLauncherTheme9 = (MyRadioBox)target;
			break;
		case 29:
			LabLauncherTheme9Copy = (TextBlock)target;
			break;
		case 30:
			RadioLauncherTheme10 = (MyRadioBox)target;
			break;
		case 31:
			RadioLauncherTheme11 = (MyRadioBox)target;
			break;
		case 32:
			LabLauncherTheme11Click = (TextBlock)target;
			break;
		case 33:
			RadioLauncherTheme14 = (MyRadioBox)target;
			break;
		case 34:
			RadioLauncherTheme15 = (MyRadioBox)target;
			break;
		case 35:
			CheckDarkMode = (MyCheckBox)target;
			break;
		case 36:
			PanelAcrylic = (StackPanel)target;
			break;
		case 37:
			CheckAcrylicEnabled = (MyCheckBox)target;
			break;
		case 38:
			PanAcrylicOpacity = (Grid)target;
			break;
		case 39:
			SliderAcrylicOpacity = (MySlider)target;
			break;
		case 40:
			ComboUiFont = (MyComboBox)target;
			break;
		case 41:
			CheckLauncherLogo = (MyCheckBox)target;
			break;
		case 42:
			CheckLockWindowSize = (MyCheckBox)target;
			break;
		case 43:
			PanelBlur = (StackPanel)target;
			break;
		case 44:
			CheckBlur = (MyCheckBox)target;
			break;
		case 45:
			PanBlurValue = (Grid)target;
			break;
		case 46:
			SliderBlurValue = (MySlider)target;
			break;
		case 47:
			SliderBlurSamplingRate = (MySlider)target;
			break;
		case 48:
			ComboBlurType = (MyComboBox)target;
			break;
		case 49:
			CardBackground = (MyCard)target;
			break;
		case 50:
			PanBackgroundSuit = (Grid)target;
			break;
		case 51:
			ComboBackgroundSuit = (MyComboBox)target;
			break;
		case 52:
			PanBackgroundOpacity = (Grid)target;
			break;
		case 53:
			SliderBackgroundOpacity = (MySlider)target;
			break;
		case 54:
			PanBackgroundBlur = (Grid)target;
			break;
		case 55:
			SliderBackgroundBlur = (MySlider)target;
			break;
		case 56:
			CheckAutoPauseVideo = (MyCheckBox)target;
			break;
		case 57:
			CheckBackgroundColorful = (MyCheckBox)target;
			break;
		case 58:
			CardBackground2 = (MyCard)target;
			break;
		case 59:
			BtnBackgroundOpen = (MyButton)target;
			break;
		case 60:
			BtnBackgroundRefresh = (MyButton)target;
			break;
		case 61:
			BtnBackgroundClear = (MyButton)target;
			break;
		case 62:
			CardMusic = (MyCard)target;
			break;
		case 63:
			PanMusicVolume = (Grid)target;
			break;
		case 64:
			SliderMusicVolume = (MySlider)target;
			break;
		case 65:
			PanMusicDetail = (StackPanel)target;
			break;
		case 66:
			CheckMusicRandom = (MyCheckBox)target;
			break;
		case 67:
			CheckMusicAuto = (MyCheckBox)target;
			break;
		case 68:
			CheckMusicStart = (MyCheckBox)target;
			break;
		case 69:
			CheckMusicStop = (MyCheckBox)target;
			break;
		case 70:
			CheckMusicSMTC = (MyCheckBox)target;
			break;
		case 71:
			BtnMusicOpen = (MyButton)target;
			break;
		case 72:
			BtnMusicRefresh = (MyButton)target;
			break;
		case 73:
			BtnMusicClear = (MyButton)target;
			break;
		case 74:
			CardLogo = (MyCard)target;
			break;
		case 75:
			RadioLogoType0 = (MyRadioBox)target;
			break;
		case 76:
			RadioLogoType1 = (MyRadioBox)target;
			break;
		case 77:
			RadioLogoType2 = (MyRadioBox)target;
			break;
		case 78:
			RadioLogoType3 = (MyRadioBox)target;
			break;
		case 79:
			CheckLogoLeft = (MyCheckBox)target;
			break;
		case 80:
			PanLogoText = (Grid)target;
			break;
		case 81:
			TextLogoText = (MyTextBox)target;
			break;
		case 82:
			PanLogoChange = (Grid)target;
			break;
		case 83:
			BtnLogoChange = (MyButton)target;
			break;
		case 84:
			BtnLogoDelete = (MyButton)target;
			break;
		case 85:
			CardCustom = (MyCard)target;
			break;
		case 86:
			RadioCustomType0 = (MyRadioBox)target;
			break;
		case 87:
			RadioCustomType3 = (MyRadioBox)target;
			break;
		case 88:
			RadioCustomType1 = (MyRadioBox)target;
			break;
		case 89:
			RadioCustomType2 = (MyRadioBox)target;
			break;
		case 90:
			HintCustom = (MyHint)target;
			break;
		case 91:
			HintCustomWarn = (MyHint)target;
			break;
		case 92:
			PanCustomLocal = (Grid)target;
			break;
		case 93:
			BtnCustomRefresh = (MyButton)target;
			break;
		case 94:
			BtnCustomFile = (MyButton)target;
			break;
		case 95:
			BtnCustomTutorial = (MyButton)target;
			break;
		case 96:
			PanCustomNet = (Grid)target;
			break;
		case 97:
			TextCustomNet = (MyTextBox)target;
			break;
		case 98:
			PanCustomPreset = (Grid)target;
			break;
		case 99:
			ComboCustomPreset = (MyComboBox)target;
			break;
		case 100:
			BtnGotoHomepageMarket = (MyIconTextButton)target;
			break;
		case 101:
			CardSwitch = (MyCard)target;
			break;
		case 102:
			CheckHiddenPageDownload = (MyCheckBox)target;
			break;
		case 103:
			CheckHiddenPageLink = (MyCheckBox)target;
			break;
		case 104:
			CheckHiddenPageSetup = (MyCheckBox)target;
			break;
		case 105:
			CheckHiddenPageOther = (MyCheckBox)target;
			break;
		case 106:
			CheckHiddenSetupLaunch = (MyCheckBox)target;
			break;
		case 107:
			CheckHiddenSetupUI = (MyCheckBox)target;
			break;
		case 108:
			CheckHiddenSetupSystem = (MyCheckBox)target;
			break;
		case 109:
			CheckHiddenOtherHelp = (MyCheckBox)target;
			break;
		case 110:
			CheckHiddenOtherAbout = (MyCheckBox)target;
			break;
		case 111:
			CheckHiddenOtherTest = (MyCheckBox)target;
			break;
		case 112:
			CheckHiddenOtherFeedback = (MyCheckBox)target;
			break;
		case 113:
			CheckHiddenOtherVote = (MyCheckBox)target;
			break;
		case 114:
			CheckHiddenFunctionSelect = (MyCheckBox)target;
			break;
		case 115:
			CheckHiddenFunctionModUpdate = (MyCheckBox)target;
			break;
		case 116:
			CheckHiddenFunctionHidden = (MyCheckBox)target;
			break;
		case 117:
			CheckHiddenVersionEdit = (MyCheckBox)target;
			break;
		case 118:
			CheckHiddenVersionExport = (MyCheckBox)target;
			break;
		case 119:
			CheckHiddenVersionSave = (MyCheckBox)target;
			break;
		case 120:
			CheckHiddenVersionScreenshot = (MyCheckBox)target;
			break;
		case 121:
			CheckHiddenVersionMod = (MyCheckBox)target;
			break;
		case 122:
			CheckHiddenVersionResourcePack = (MyCheckBox)target;
			break;
		case 123:
			CheckHiddenVersionShader = (MyCheckBox)target;
			break;
		case 124:
			CheckHiddenVersionSchematic = (MyCheckBox)target;
			break;
		case 125:
			CheckHiddenVersionServer = (MyCheckBox)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
