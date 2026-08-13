using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Utils;
using PCL.Core.Utils.Exts;

namespace PCL;

[DesignerGenerated]
public class MyLocalCompItem : Grid, IComponentConnector
{
	public delegate void ClickEventHandler(object sender, MouseButtonEventArgs e);

	public class SwipeSelect
	{
		private bool _Swiping;

		[field: CompilerGenerated]
		public int Start
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public int End
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public bool Swiping
		{
			get
			{
				return _Swiping;
			}
			set
			{
				_Swiping = value;
				((UIElement)TargetFrm.CardSelect).IsHitTestVisible = !value;
			}
		}

		[field: CompilerGenerated]
		public bool SwipeToState
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		[field: CompilerGenerated]
		public PageInstanceCompResource TargetFrm
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public SwipeSelect()
		{
			_Swiping = false;
		}
	}

	public delegate void CheckEventHandler(object sender, ModBase.RouteEventArgs e);

	public delegate void ChangedEventHandler(object sender, ModBase.RouteEventArgs e);

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine___Lambda_0024__64_002D0 : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal MyLocalCompItem _0024VB_0024Me;

		internal string _0024VB_0024ResumableLocal_DescFileName_00240;

		internal TaskAwaiter<KeyValuePair<string, string>> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0246: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0262: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Unknown result type (might be due to invalid IL or missing references)
			//IL_0389: Unknown result type (might be due to invalid IL or missing references)
			//IL_038e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0396: Unknown result type (might be due to invalid IL or missing references)
			//IL_039e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_034b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0350: Unknown result type (might be due to invalid IL or missing references)
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0365: Unknown result type (might be due to invalid IL or missing references)
			//IL_0367: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Unknown result type (might be due to invalid IL or missing references)
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_05cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0617: Unknown result type (might be due to invalid IL or missing references)
			//IL_0621: Unknown result type (might be due to invalid IL or missing references)
			//IL_0628: Unknown result type (might be due to invalid IL or missing references)
			//IL_062f: Unknown result type (might be due to invalid IL or missing references)
			//IL_063b: Expected O, but got Unknown
			int num = _0024State;
			try
			{
				string text;
				TaskAwaiter<KeyValuePair<string, string>> awaiter;
				if (num != 0)
				{
					TaskAwaiter<KeyValuePair<string, string>> awaiter2;
					if (num != 1)
					{
						_Closure_0024__64_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__64_002D0();
						if (_0024VB_0024Me.Entry.CanUpdate)
						{
							((UIElement)_0024VB_0024Me.BtnUpdate).Visibility = (Visibility)0;
							((FrameworkElement)_0024VB_0024Me.BtnUpdate).ToolTip = string.Format("{0}{1}点击以更新，右键查看更新日志。", (object)_0024VB_0024Me.GetUpdateCompareDescription(), (object)"\r\n");
						}
						else
						{
							((UIElement)_0024VB_0024Me.BtnUpdate).Visibility = (Visibility)2;
						}
						if (_0024VB_0024Me.Entry.IsFolder)
						{
							_0024VB_0024ResumableLocal_DescFileName_00240 = _0024VB_0024Me.Entry.Name;
						}
						else
						{
							switch (_0024VB_0024Me.Entry.State)
							{
							case ModLocalComp.LocalCompFile.LocalFileStatus.Fine:
								_0024VB_0024ResumableLocal_DescFileName_00240 = ModBase.GetFileNameWithoutExtentionFromPath(_0024VB_0024Me.Entry.Path);
								break;
							case ModLocalComp.LocalCompFile.LocalFileStatus.Disabled:
								_0024VB_0024ResumableLocal_DescFileName_00240 = ModBase.GetFileNameWithoutExtentionFromPath(_0024VB_0024Me.Entry.Path.Replace(".disabled", "").Replace(".old", ""));
								break;
							default:
								_0024VB_0024ResumableLocal_DescFileName_00240 = ModBase.GetFileNameFromPath(_0024VB_0024Me.Entry.Path);
								break;
							}
						}
						CS_0024_003C_003E8__locals0._0024VB_0024Local_compTemp = _0024VB_0024Me.Entry.Comp;
						if (_0024VB_0024Me.Entry.IsFolder)
						{
							_0024VB_0024Me.Title = _0024VB_0024Me.Entry.Name;
							text = _0024VB_0024Me.Entry.Description;
							goto IL_0410;
						}
						if (Operators.ConditionalCompareObjectEqual(ModBase.Setup.Get("ToolModLocalNameStyle"), (object)1, false))
						{
							_0024VB_0024Me.Title = _0024VB_0024ResumableLocal_DescFileName_00240;
							_0024VB_0024Me.SubTitle = "";
							if ((object)_0024VB_0024Me.Entry.Comp == null)
							{
								text = _0024VB_0024Me.Entry.Name;
								goto IL_027e;
							}
							awaiter = System.Threading.Tasks.Task.Run<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>>)([SpecialName] () => CS_0024_003C_003E8__locals0._0024VB_0024Local_compTemp.GetControlTitle(HasModLoaderDescription: false))).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = awaiter;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<KeyValuePair<string, string>>, VB_0024StateMachine___Lambda_0024__64_002D0>(ref awaiter, ref _this);
								return;
							}
							goto IL_0259;
						}
						if ((object)_0024VB_0024Me.Entry.Comp == null)
						{
							_0024VB_0024Me.Title = _0024VB_0024Me.Entry.Name;
							_0024VB_0024Me.SubTitle = ((_0024VB_0024Me.Entry.Version == null) ? "" : ("  |  " + _0024VB_0024Me.Entry.Version));
							goto IL_0409;
						}
						awaiter2 = System.Threading.Tasks.Task.Run<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>>)([SpecialName] () => CS_0024_003C_003E8__locals0._0024VB_0024Local_compTemp.GetControlTitle(HasModLoaderDescription: false))).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_0024State = 1);
							_0024A0 = awaiter2;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<KeyValuePair<string, string>>, VB_0024StateMachine___Lambda_0024__64_002D0>(ref awaiter2, ref _this);
							return;
						}
					}
					else
					{
						num = (_0024State = -1);
						awaiter2 = _0024A0;
						_0024A0 = default(TaskAwaiter<KeyValuePair<string, string>>);
					}
					KeyValuePair<string, string> result = awaiter2.GetResult();
					awaiter2 = default(TaskAwaiter<KeyValuePair<string, string>>);
					KeyValuePair<string, string> val = result;
					_0024VB_0024Me.Title = val.Key;
					_0024VB_0024Me.SubTitle = val.Value + ((_0024VB_0024Me.Entry.Version == null) ? "" : ("  |  " + _0024VB_0024Me.Entry.Version));
					goto IL_0409;
				}
				num = (_0024State = -1);
				awaiter = _0024A0;
				_0024A0 = default(TaskAwaiter<KeyValuePair<string, string>>);
				goto IL_0259;
				IL_027e:
				text = text.Replace("  |  ", " / ");
				if (_0024VB_0024Me.Entry.Version != null)
				{
					text += $" ({_0024VB_0024Me.Entry.Version})";
				}
				goto IL_0410;
				IL_0409:
				text = _0024VB_0024ResumableLocal_DescFileName_00240;
				goto IL_0410;
				IL_0410:
				if ((object)_0024VB_0024Me.Entry.Comp != null)
				{
					text = text + ": " + _0024VB_0024Me.Entry.Comp.Description.Replace("\r", "").Replace("\n", "");
				}
				else if (_0024VB_0024Me.Entry.Description != null)
				{
					text = text + ": " + _0024VB_0024Me.Entry.Description.Replace("\r", "").Replace("\n", "");
				}
				else if (!_0024VB_0024Me.Entry.IsFileAvailable)
				{
					text += ": 存在错误，无法获取信息";
				}
				_0024VB_0024Me.Description = text;
				if (_0024VB_0024Me.Checked)
				{
					((FrameworkElement)_0024VB_0024Me.LabTitle).SetResourceReference(TextBlock.ForegroundProperty, (object)((_0024VB_0024Me.Entry.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine) ? "ColorBrush2" : "ColorBrush5"));
				}
				else
				{
					((FrameworkElement)_0024VB_0024Me.LabTitle).SetResourceReference(TextBlock.ForegroundProperty, (object)((_0024VB_0024Me.Entry.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine) ? "ColorBrush1" : "ColorBrushGray4"));
				}
				_0024VB_0024Me.Logo = _0024VB_0024Me.Entry.GetLogo();
				if (_0024VB_0024Me.Entry.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine)
				{
					if (_0024VB_0024Me.ImgState != null)
					{
						((Panel)_0024VB_0024Me).Children.Remove((UIElement)(object)_0024VB_0024Me.ImgState);
						_0024VB_0024Me.ImgState = null;
					}
				}
				else
				{
					if (_0024VB_0024Me.ImgState == null)
					{
						_0024VB_0024Me.ImgState = new Image
						{
							Width = 20.0,
							Height = 20.0,
							Margin = new Thickness(0.0, 0.0, -5.0, -3.0),
							IsHitTestVisible = false,
							HorizontalAlignment = (HorizontalAlignment)2,
							VerticalAlignment = (VerticalAlignment)2
						};
						RenderOptions.SetBitmapScalingMode((DependencyObject)(object)_0024VB_0024Me.ImgState, (BitmapScalingMode)2);
						Grid.SetColumn((UIElement)(object)_0024VB_0024Me.ImgState, 1);
						Grid.SetRow((UIElement)(object)_0024VB_0024Me.ImgState, 1);
						Grid.SetRowSpan((UIElement)(object)_0024VB_0024Me.ImgState, 2);
						((Panel)_0024VB_0024Me).Children.Add((UIElement)(object)_0024VB_0024Me.ImgState);
					}
					_0024VB_0024Me.ImgState.Source = new MyBitmap(ModBase.PathImage + $"Icons/{_0024VB_0024Me.Entry.State}.png");
				}
				if (_0024VB_0024Me.Entry.IsFolder)
				{
					MyLocalCompItem myLocalCompItem = _0024VB_0024Me;
					List<string> obj = new List<string>();
					obj.Add("文件夹");
					myLocalCompItem.Tags = obj;
				}
				else if ((object)_0024VB_0024Me.Entry.Comp != null)
				{
					_0024VB_0024Me.Tags = _0024VB_0024Me.Entry.Comp.Tags;
				}
				goto end_IL_0007;
				IL_0259:
				KeyValuePair<string, string> result2 = awaiter.GetResult();
				awaiter = default(TaskAwaiter<KeyValuePair<string, string>>);
				KeyValuePair<string, string> val2 = result2;
				text = val2.Key + val2.Value;
				goto IL_027e;
				end_IL_0007:;
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

	[CompilerGenerated]
	internal sealed class _Closure_0024__64_002D0
	{
		public ModComp.CompProject _0024VB_0024Local_compTemp;

		[SpecialName]
		internal KeyValuePair<string, string> _Lambda_0024__1()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return _0024VB_0024Local_compTemp.GetControlTitle(HasModLoaderDescription: false);
		}

		[SpecialName]
		internal KeyValuePair<string, string> _Lambda_0024__2()
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			return _0024VB_0024Local_compTemp.GetControlTitle(HasModLoaderDescription: false);
		}
	}

	public int Uuid;

	private string _Title;

	[CompilerGenerated]
	private ClickEventHandler ClickEvent;

	private bool IsMouseDown;

	[CompilerGenerated]
	private CheckEventHandler CheckEvent;

	[CompilerGenerated]
	private ChangedEventHandler ChangedEvent;

	private bool _Checked;

	private Image ImgState;

	private Border _RectBack;

	public Action<MyLocalCompItem, EventArgs> ButtonHandler;

	public FrameworkElement ButtonStack;

	private System.Collections.Generic.IEnumerable<MyIconButton> _Buttons;

	private Border _RectCheck;

	[CompilerGenerated]
	[AccessedThroughProperty("PanTitle")]
	private Grid _PanTitle;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnUpdate")]
	private MyIconButton _BtnUpdate;

	private bool _contentLoaded;

	public string Logo
	{
		get
		{
			return PathLogo.Source;
		}
		set
		{
			PathLogo.Source = value;
		}
	}

	public string Title
	{
		get
		{
			return _Title;
		}
		set
		{
			string title = value;
			switch (Entry.State)
			{
			case ModLocalComp.LocalCompFile.LocalFileStatus.Fine:
				LabTitle.TextDecorations = null;
				break;
			case ModLocalComp.LocalCompFile.LocalFileStatus.Disabled:
				LabTitle.TextDecorations = TextDecorations.Strikethrough;
				break;
			case ModLocalComp.LocalCompFile.LocalFileStatus.Unavailable:
				LabTitle.TextDecorations = TextDecorations.Strikethrough;
				value += " [错误]";
				break;
			}
			if (Operators.CompareString(LabTitle.Text, value, false) != 0)
			{
				LabTitle.Text = value;
				_Title = title;
			}
		}
	}

	public string SubTitle
	{
		get
		{
			TextBlock labSubtitle = LabSubtitle;
			return ((labSubtitle != null) ? labSubtitle.Text : null) ?? "";
		}
		set
		{
			if (Operators.CompareString(LabSubtitle.Text, value, false) != 0)
			{
				LabSubtitle.Text = value;
				((UIElement)LabSubtitle).Visibility = (Visibility)((Operators.CompareString(value, "", false) == 0) ? 2 : 0);
			}
		}
	}

	public string Description
	{
		get
		{
			return LabInfo.Text;
		}
		set
		{
			if (Operators.CompareString(LabInfo.Text, value, false) != 0)
			{
				LabInfo.Text = value;
			}
		}
	}

	public List<string> Tags
	{
		set
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Expected O, but got Unknown
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Expected O, but got Unknown
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Expected O, but got Unknown
			((Panel)PanTags).Children.Clear();
			((UIElement)PanTags).Visibility = (Visibility)((!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)value)) ? 2 : 0);
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = value.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					Border val = new Border
					{
						Background = (Brush)new SolidColorBrush(Color.FromArgb((byte)12, (byte)0, (byte)0, (byte)0)),
						Padding = new Thickness(3.0, 1.0, 3.0, 1.0),
						CornerRadius = new CornerRadius(3.0),
						Margin = new Thickness(0.0, 0.0, 3.0, 0.0),
						SnapsToDevicePixels = true,
						UseLayoutRounding = false
					};
					TextBlock child = new TextBlock
					{
						Text = current,
						Foreground = (Brush)new SolidColorBrush(ModSecret.IsDarkMode ? Color.FromArgb((byte)88, (byte)255, (byte)255, (byte)255) : Color.FromArgb((byte)88, (byte)136, (byte)136, (byte)136)),
						FontSize = 11.0
					};
					((Decorator)val).Child = (UIElement)(object)child;
					((Panel)PanTags).Children.Add((UIElement)(object)val);
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
	}

	public ModLocalComp.LocalCompFile Entry
	{
		get
		{
			return (ModLocalComp.LocalCompFile)((FrameworkElement)this).Tag;
		}
		set
		{
			((FrameworkElement)this).Tag = value;
		}
	}

	[field: CompilerGenerated]
	public SwipeSelect CurrentSwipe
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public bool Checked
	{
		get
		{
			return _Checked;
		}
		set
		{
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				bool @checked = _Checked;
				if (value == _Checked)
				{
					return;
				}
				_Checked = value;
				ModBase.RouteEventArgs routeEventArgs = new ModBase.RouteEventArgs();
				if (((FrameworkElement)this).IsInitialized)
				{
					ChangedEvent?.Invoke(this, routeEventArgs);
					if (routeEventArgs.Handled)
					{
						_Checked = @checked;
						return;
					}
				}
				if (value)
				{
					ModBase.RouteEventArgs routeEventArgs2 = new ModBase.RouteEventArgs();
					CheckEvent?.Invoke(this, routeEventArgs2);
					if (routeEventArgs2.Handled)
					{
						return;
					}
				}
				if (((FrameworkElement)(object)this).IsVisibleInWindow((Window)(object)ModMain.FrmMain))
				{
					List<ModAnimation.AniData> val = new List<ModAnimation.AniData>();
					if (Checked)
					{
						double num = 32.0 - ((FrameworkElement)RectCheck).ActualHeight;
						val.Add(ModAnimation.AaHeight(RectCheck, num * 0.4, 200, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)));
						val.Add(ModAnimation.AaHeight(RectCheck, num * 0.6, 300, 0, new ModAnimation.AniEaseOutBack(ModAnimation.AniEasePower.Weak)));
						val.Add(ModAnimation.AaOpacity(RectCheck, 1.0 - ((UIElement)RectCheck).Opacity, 30));
						((FrameworkElement)RectCheck).VerticalAlignment = (VerticalAlignment)1;
						((FrameworkElement)RectCheck).Margin = new Thickness(-3.0, 0.0, 0.0, 0.0);
						val.Add(ModAnimation.AaColor((FrameworkElement)(object)LabTitle, TextBlock.ForegroundProperty, (Entry.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine) ? "ColorBrush2" : "ColorBrush5", 200));
					}
					else
					{
						val.Add(ModAnimation.AaHeight(RectCheck, 0.0 - ((FrameworkElement)RectCheck).ActualHeight, 120, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)));
						val.Add(ModAnimation.AaOpacity(RectCheck, 0.0 - ((UIElement)RectCheck).Opacity, 70, 40));
						((FrameworkElement)RectCheck).VerticalAlignment = (VerticalAlignment)1;
						val.Add(ModAnimation.AaColor((FrameworkElement)(object)LabTitle, TextBlock.ForegroundProperty, (LabTitle.TextDecorations == null) ? "ColorBrush1" : "ColorBrushGray4", 120));
					}
					ModAnimation.AniStart((System.Collections.IList)val, "MyLocalCompItem Checked " + Conversions.ToString(Uuid));
				}
				else
				{
					((FrameworkElement)RectCheck).VerticalAlignment = (VerticalAlignment)1;
					((FrameworkElement)RectCheck).Margin = new Thickness(-3.0, 0.0, 0.0, 0.0);
					if (Checked)
					{
						((FrameworkElement)RectCheck).Height = 32.0;
						((UIElement)RectCheck).Opacity = 1.0;
						((FrameworkElement)LabTitle).SetResourceReference(TextBlock.ForegroundProperty, (object)((Entry.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine) ? "ColorBrush2" : "ColorBrush5"));
					}
					else
					{
						((FrameworkElement)RectCheck).Height = 0.0;
						((UIElement)RectCheck).Opacity = 0.0;
						((FrameworkElement)LabTitle).SetResourceReference(TextBlock.ForegroundProperty, (object)((Entry.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine) ? "ColorBrush1" : "ColorBrushGray4"));
					}
					ModAnimation.AniStop("MyLocalCompItem Checked " + Conversions.ToString(Uuid));
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "设置 Checked 失败");
				ProjectData.ClearProjectError();
			}
		}
	}

	public Border RectBack
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			if (_RectBack == null)
			{
				Border val = new Border
				{
					Name = "RectBack",
					CornerRadius = new CornerRadius(3.0),
					RenderTransform = (Transform)new ScaleTransform(0.8, 0.8),
					RenderTransformOrigin = new Point(0.5, 0.5),
					BorderThickness = new Thickness(ModBase.GetWPFSize(1.0)),
					SnapsToDevicePixels = true,
					IsHitTestVisible = false,
					Opacity = 0.0
				};
				((FrameworkElement)val).SetResourceReference(Border.BackgroundProperty, (object)"ColorBrush7");
				((FrameworkElement)val).SetResourceReference(Border.BorderBrushProperty, (object)"ColorBrush6");
				Grid.SetColumnSpan((UIElement)(object)val, 999);
				Grid.SetRowSpan((UIElement)(object)val, 999);
				((Panel)this).Children.Insert(0, (UIElement)(object)val);
				_RectBack = val;
			}
			return _RectBack;
		}
	}

	public System.Collections.Generic.IEnumerable<MyIconButton> Buttons
	{
		get
		{
			return _Buttons;
		}
		set
		{
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Expected O, but got Unknown
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			_Buttons = value;
			if (ButtonStack != null)
			{
				((Panel)this).Children.Remove((UIElement)(object)ButtonStack);
				ButtonStack = null;
			}
			if (!Enumerable.Any<MyIconButton>(value))
			{
				return;
			}
			ButtonStack = (FrameworkElement)new StackPanel
			{
				Opacity = 0.0,
				Margin = new Thickness(0.0, 0.0, 5.0, 0.0),
				SnapsToDevicePixels = false,
				Orientation = (Orientation)0,
				HorizontalAlignment = (HorizontalAlignment)2,
				VerticalAlignment = (VerticalAlignment)1,
				UseLayoutRounding = false
			};
			Grid.SetColumnSpan((UIElement)(object)ButtonStack, 10);
			Grid.SetRowSpan((UIElement)(object)ButtonStack, 10);
			System.Collections.Generic.IEnumerator<MyIconButton> enumerator = default(System.Collections.Generic.IEnumerator<MyIconButton>);
			try
			{
				enumerator = value.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					MyIconButton current = enumerator.Current;
					if (((FrameworkElement)current).Height.Equals(0.0 / 0.0))
					{
						((FrameworkElement)current).Height = 25.0;
					}
					if (((FrameworkElement)current).Width.Equals(0.0 / 0.0))
					{
						((FrameworkElement)current).Width = 25.0;
					}
					((Panel)(StackPanel)ButtonStack).Children.Add((UIElement)(object)current);
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			((Panel)this).Children.Add((UIElement)(object)ButtonStack);
		}
	}

	public Border RectCheck
	{
		get
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Expected O, but got Unknown
			if (_RectCheck == null)
			{
				_RectCheck = new Border
				{
					Width = 5.0,
					Height = (Checked ? (0.0 / 0.0) : 0.0),
					CornerRadius = new CornerRadius(2.0, 2.0, 2.0, 2.0),
					VerticalAlignment = (VerticalAlignment)((!Checked) ? 1 : 3),
					HorizontalAlignment = (HorizontalAlignment)0,
					UseLayoutRounding = false,
					SnapsToDevicePixels = false,
					Margin = (Checked ? new Thickness(-3.0, 6.0, 0.0, 6.0) : new Thickness(-3.0, 0.0, 0.0, 0.0))
				};
				((FrameworkElement)_RectCheck).SetResourceReference(Border.BackgroundProperty, (object)"ColorBrush3");
				Grid.SetRowSpan((UIElement)(object)_RectCheck, 10);
				((Panel)this).Children.Add((UIElement)(object)_RectCheck);
			}
			return _RectCheck;
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanBack")]
	internal virtual MyLocalCompItem PanBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnPaddingRight")]
	internal virtual ColumnDefinition ColumnPaddingRight
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PathLogo")]
	internal virtual MyImage PathLogo
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual Grid PanTitle
	{
		[CompilerGenerated]
		get
		{
			return _PanTitle;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SizeChangedEventHandler val = (SizeChangedEventHandler)([SpecialName] [CompilerGenerated] (object a0, SizeChangedEventArgs a1) =>
			{
				PanTitle_SizeChanged();
			});
			Grid panTitle = _PanTitle;
			if (panTitle != null)
			{
				((FrameworkElement)panTitle).SizeChanged -= val;
			}
			_PanTitle = value;
			panTitle = _PanTitle;
			if (panTitle != null)
			{
				((FrameworkElement)panTitle).SizeChanged += val;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnTitle")]
	internal virtual ColumnDefinition ColumnTitle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnSubtitle")]
	internal virtual ColumnDefinition ColumnSubtitle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("ColumnExtend")]
	internal virtual ColumnDefinition ColumnExtend
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabTitle")]
	internal virtual TextBlock LabTitle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabSubtitle")]
	internal virtual TextBlock LabSubtitle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconButton BtnUpdate
	{
		[CompilerGenerated]
		get
		{
			return _BtnUpdate;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			MouseButtonEventHandler val = new MouseButtonEventHandler(BtnUpdate_PreviewMouseRightButtonUp);
			MyIconButton.ClickEventHandler obj = BtnUpdate_Click;
			MyIconButton btnUpdate = _BtnUpdate;
			if (btnUpdate != null)
			{
				((UIElement)btnUpdate).PreviewMouseRightButtonUp -= val;
				btnUpdate.Click -= obj;
			}
			_BtnUpdate = value;
			btnUpdate = _BtnUpdate;
			if (btnUpdate != null)
			{
				((UIElement)btnUpdate).PreviewMouseRightButtonUp += val;
				btnUpdate.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanTags")]
	internal virtual StackPanel PanTags
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabInfo")]
	internal virtual TextBlock LabInfo
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

	public event CheckEventHandler Check
	{
		[CompilerGenerated]
		add
		{
			CheckEventHandler checkEventHandler = CheckEvent;
			CheckEventHandler checkEventHandler2;
			do
			{
				checkEventHandler2 = checkEventHandler;
				CheckEventHandler checkEventHandler3 = (CheckEventHandler)System.Delegate.Combine((System.Delegate)checkEventHandler2, (System.Delegate)value);
				checkEventHandler = Interlocked.CompareExchange<CheckEventHandler>(ref CheckEvent, checkEventHandler3, checkEventHandler2);
			}
			while (checkEventHandler != checkEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CheckEventHandler checkEventHandler = CheckEvent;
			CheckEventHandler checkEventHandler2;
			do
			{
				checkEventHandler2 = checkEventHandler;
				CheckEventHandler checkEventHandler3 = (CheckEventHandler)System.Delegate.Remove((System.Delegate)checkEventHandler2, (System.Delegate)value);
				checkEventHandler = Interlocked.CompareExchange<CheckEventHandler>(ref CheckEvent, checkEventHandler3, checkEventHandler2);
			}
			while (checkEventHandler != checkEventHandler2);
		}
	}

	public event ChangedEventHandler Changed
	{
		[CompilerGenerated]
		add
		{
			ChangedEventHandler changedEventHandler = ChangedEvent;
			ChangedEventHandler changedEventHandler2;
			do
			{
				changedEventHandler2 = changedEventHandler;
				ChangedEventHandler changedEventHandler3 = (ChangedEventHandler)System.Delegate.Combine((System.Delegate)changedEventHandler2, (System.Delegate)value);
				changedEventHandler = Interlocked.CompareExchange<ChangedEventHandler>(ref ChangedEvent, changedEventHandler3, changedEventHandler2);
			}
			while (changedEventHandler != changedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			ChangedEventHandler changedEventHandler = ChangedEvent;
			ChangedEventHandler changedEventHandler2;
			do
			{
				changedEventHandler2 = changedEventHandler;
				ChangedEventHandler changedEventHandler3 = (ChangedEventHandler)System.Delegate.Remove((System.Delegate)changedEventHandler2, (System.Delegate)value);
				changedEventHandler = Interlocked.CompareExchange<ChangedEventHandler>(ref ChangedEvent, changedEventHandler3, changedEventHandler2);
			}
			while (changedEventHandler != changedEventHandler2);
		}
	}

	public MyLocalCompItem()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		((UIElement)this).PreviewMouseLeftButtonUp += new MouseButtonEventHandler(Button_MouseUp);
		((UIElement)this).PreviewMouseLeftButtonDown += new MouseButtonEventHandler(Button_MouseDown);
		((UIElement)this).MouseLeave += new MouseEventHandler(Button_MouseLeave);
		((UIElement)this).PreviewMouseLeftButtonUp += new MouseButtonEventHandler(Button_MouseLeave);
		((UIElement)this).MouseLeftButtonDown += new MouseButtonEventHandler(Button_MouseSwipeStart);
		((UIElement)this).MouseEnter += new MouseEventHandler(Button_MouseSwipe);
		((UIElement)this).MouseLeave += new MouseEventHandler(Button_MouseSwipe);
		((UIElement)this).MouseLeftButtonUp += new MouseButtonEventHandler(Button_MouseSwipe);
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			Refresh();
		});
		((UIElement)this).MouseEnter += new MouseEventHandler(RefreshColor);
		((UIElement)this).MouseLeave += new MouseEventHandler(RefreshColor);
		((UIElement)this).MouseLeftButtonDown += new MouseButtonEventHandler(RefreshColor);
		((UIElement)this).MouseLeftButtonUp += new MouseButtonEventHandler(RefreshColor);
		Changed += RefreshColor;
		Uuid = ModBase.GetUuid();
		IsMouseDown = false;
		_Checked = false;
		_RectBack = null;
		InitializeComponent();
	}

	private void Button_MouseUp(object sender, MouseButtonEventArgs e)
	{
		if (IsMouseDown)
		{
			ClickEvent?.Invoke(RuntimeHelpers.GetObjectValue(sender), e);
			if (!((RoutedEventArgs)e).Handled)
			{
				ModBase.Log("[Control] 按下本地 Mod 列表项：" + LabTitle.Text);
			}
		}
	}

	private void Button_MouseDown(object sender, MouseButtonEventArgs e)
	{
		if (((UIElement)this).IsMouseDirectlyOver)
		{
			IsMouseDown = true;
			if (ButtonStack != null)
			{
				((UIElement)ButtonStack).IsHitTestVisible = false;
			}
		}
	}

	private void Button_MouseLeave(object sender, object e)
	{
		IsMouseDown = false;
		if (ButtonStack != null)
		{
			((UIElement)ButtonStack).IsHitTestVisible = true;
		}
	}

	private void Button_MouseSwipeStart(object sender, object e)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		if (((FrameworkElement)this).Parent != null)
		{
			int num = ((Panel)(StackPanel)((FrameworkElement)this).Parent).Children.IndexOf((UIElement)(object)this);
			CurrentSwipe.Start = num;
			CurrentSwipe.End = num;
			CurrentSwipe.Swiping = true;
			CurrentSwipe.SwipeToState = !Checked;
		}
	}

	private void Button_MouseSwipe(object sender, object e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		if (((FrameworkElement)this).Parent == null)
		{
			return;
		}
		if ((int)Mouse.LeftButton != 1 || !(Mouse.DirectlyOver is MyLocalCompItem))
		{
			CurrentSwipe.Swiping = false;
			return;
		}
		UIElementCollection children = ((Panel)(StackPanel)((FrameworkElement)this).Parent).Children;
		int num = children.IndexOf((UIElement)(object)this);
		checked
		{
			CurrentSwipe.Start = (int)Math.Round(ModBase.MathClamp(Math.Min(CurrentSwipe.Start, num), 0.0, children.Count - 1));
			CurrentSwipe.End = (int)Math.Round(ModBase.MathClamp(Math.Max(CurrentSwipe.End, num), 0.0, children.Count - 1));
			if (CurrentSwipe.Start != CurrentSwipe.End)
			{
				int start = CurrentSwipe.Start;
				int end = CurrentSwipe.End;
				for (int i = start; i <= end; i++)
				{
					MyLocalCompItem obj = (MyLocalCompItem)(object)children[i];
					obj.InitLate(obj, (EventArgs)e);
					obj.Checked = CurrentSwipe.SwipeToState;
				}
			}
		}
	}

	private string GetUpdateCompareDescription()
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		string text = Entry.CompFile.FileName.Replace(".jar", "");
		string text2 = Entry.UpdateFile.FileName.Replace(".jar", "");
		List<string> val = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)text.Split('-', (StringSplitOptions)0));
		List<string> val2 = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)text2.Split('-', (StringSplitOptions)0));
		bool flag = false;
		System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
		try
		{
			enumerator = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)val).GetEnumerator();
			while (enumerator.MoveNext())
			{
				string current = enumerator.Current;
				if (val2.Contains(current))
				{
					val.Remove(current);
					val2.Remove(current);
					flag = true;
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
		if (flag && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val) && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2))
		{
			text = ModBase.Join((System.Collections.IEnumerable)val, "-");
			text2 = ModBase.Join((System.Collections.IEnumerable)val2, "-");
			Entry._Version = text;
		}
		return string.Format("当前版本：{0}（{1}）{2}最新版本：{3}（{4}）", new object[5]
		{
			text,
			TimeUtils.GetTimeSpanString(Entry.CompFile.ReleaseDate - System.DateTime.Now, isShortForm: false),
			"\r\n",
			text2,
			TimeUtils.GetTimeSpanString(Entry.UpdateFile.ReleaseDate - System.DateTime.Now, isShortForm: false)
		});
	}

	public void Refresh()
	{
		((DispatcherObject)this).Dispatcher.BeginInvoke((System.Delegate)(VB_0024AnonymousDelegate_0<System.Threading.Tasks.Task>)([SpecialName] [CompilerGenerated] [AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__64_002D0))] () =>
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__64_002D0 vB_0024StateMachine___Lambda_0024__64_002D = default(VB_0024StateMachine___Lambda_0024__64_002D0);
			vB_0024StateMachine___Lambda_0024__64_002D._0024VB_0024Me = this;
			vB_0024StateMachine___Lambda_0024__64_002D._0024State = -1;
			vB_0024StateMachine___Lambda_0024__64_002D._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__64_002D._0024Builder.Start<VB_0024StateMachine___Lambda_0024__64_002D0>(ref vB_0024StateMachine___Lambda_0024__64_002D);
			return vB_0024StateMachine___Lambda_0024__64_002D._0024Builder.Task;
		}), new object[0]);
	}

	public void RefreshColor(object sender, EventArgs e)
	{
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		InitLate(RuntimeHelpers.GetObjectValue(sender), e);
		int num = (((UIElement)this).IsMouseOver ? 120 : 180);
		List<ModAnimation.AniData> val = new List<ModAnimation.AniData>();
		checked
		{
			if (ButtonStack != null)
			{
				GridLength width;
				if (((UIElement)this).IsMouseOver)
				{
					val.Add(ModAnimation.AaOpacity(ButtonStack, 1.0 - ((UIElement)ButtonStack).Opacity, (int)Math.Round((double)num * 0.7), (int)Math.Round((double)num * 0.3)));
					ParameterizedThreadStart val2 = [SpecialName] [CompilerGenerated] (object i) =>
					{
						//IL_002d: Unknown result type (might be due to invalid IL or missing references)
						//IL_0032: Unknown result type (might be due to invalid IL or missing references)
						//IL_0053: Unknown result type (might be due to invalid IL or missing references)
						ColumnDefinition columnPaddingRight2 = ColumnPaddingRight;
						System.Type typeFromHandle2 = typeof(Math);
						object[] obj2 = new object[] { 0, null };
						GridLength width3 = ColumnPaddingRight.Width;
						obj2[1] = Operators.AddObject((object)width3.Value, i);
						columnPaddingRight2.Width = new GridLength(Conversions.ToDouble(NewLateBinding.LateGet((object)null, typeFromHandle2, "Max", obj2, (string[])null, (System.Type[])null, (bool[])null)));
					};
					double num2 = 5 + Enumerable.Count<MyIconButton>(Buttons) * 25;
					width = ColumnPaddingRight.Width;
					val.Add(ModAnimation.AaDouble(val2, num2 - width.Value, (int)Math.Round((double)num * 0.3), (int)Math.Round((double)num * 0.7)));
				}
				else
				{
					val.Add(ModAnimation.AaOpacity(ButtonStack, 0.0 - ((UIElement)ButtonStack).Opacity, (int)Math.Round((double)num * 0.4)));
					ParameterizedThreadStart val3 = [SpecialName] [CompilerGenerated] (object i) =>
					{
						//IL_002d: Unknown result type (might be due to invalid IL or missing references)
						//IL_0032: Unknown result type (might be due to invalid IL or missing references)
						//IL_0053: Unknown result type (might be due to invalid IL or missing references)
						ColumnDefinition columnPaddingRight = ColumnPaddingRight;
						System.Type typeFromHandle = typeof(Math);
						object[] obj = new object[] { 0, null };
						GridLength width2 = ColumnPaddingRight.Width;
						obj[1] = Operators.AddObject((object)width2.Value, i);
						columnPaddingRight.Width = new GridLength(Conversions.ToDouble(NewLateBinding.LateGet((object)null, typeFromHandle, "Max", obj, (string[])null, (System.Type[])null, (bool[])null)));
					};
					width = ColumnPaddingRight.Width;
					val.Add(ModAnimation.AaDouble(val3, 4.0 - width.Value, (int)Math.Round((double)num * 0.4)));
				}
			}
			if (((UIElement)this).IsMouseOver || Checked)
			{
				val.AddRange((System.Collections.Generic.IEnumerable<ModAnimation.AniData>)new ModAnimation.AniData[2]
				{
					ModAnimation.AaColor((FrameworkElement)(object)RectBack, Border.BackgroundProperty, IsMouseDown ? "ColorBrush6" : "ColorBrushBg1", num),
					ModAnimation.AaOpacity(RectBack, 1.0 - ((UIElement)RectBack).Opacity, num, 0, new ModAnimation.AniEaseOutFluent())
				});
				if (IsMouseDown)
				{
					val.Add(ModAnimation.AaScaleTransform(RectBack, 0.996 - ((ScaleTransform)((UIElement)RectBack).RenderTransform).ScaleX, (int)Math.Round((double)num * 1.2), 0, new ModAnimation.AniEaseOutFluent()));
				}
				else
				{
					val.Add(ModAnimation.AaScaleTransform(RectBack, 1.0 - ((ScaleTransform)((UIElement)RectBack).RenderTransform).ScaleX, (int)Math.Round((double)num * 1.2), 0, new ModAnimation.AniEaseOutFluent()));
				}
			}
			else
			{
				val.AddRange((System.Collections.Generic.IEnumerable<ModAnimation.AniData>)new ModAnimation.AniData[3]
				{
					ModAnimation.AaOpacity(RectBack, 0.0 - ((UIElement)RectBack).Opacity, num),
					ModAnimation.AaScaleTransform(RectBack, 0.996 - ((ScaleTransform)((UIElement)RectBack).RenderTransform).ScaleX, num, 0, new ModAnimation.AniEaseOutFluent()),
					ModAnimation.AaScaleTransform(RectBack, -0.196, 1, 0, null, After: true)
				});
			}
			ModAnimation.AniStart((System.Collections.IList)val, "LocalModItem Color " + Conversions.ToString(Uuid));
		}
	}

	private void InitLate(object sender, EventArgs e)
	{
		if (ButtonHandler != null)
		{
			ButtonHandler.Invoke((MyLocalCompItem)sender, e);
			ButtonHandler = null;
		}
	}

	private void BtnUpdate_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
	{
		((RoutedEventArgs)e).Handled = true;
		ShowUpdateLog();
	}

	private void ShowUpdateLog()
	{
		string text = Enumerable.FirstOrDefault<string>((System.Collections.Generic.IEnumerable<string>)Entry.ChangelogUrls, (Func<string, bool>)([SpecialName] (string x) => x.Contains("curseforge.com")));
		string text2 = Enumerable.FirstOrDefault<string>((System.Collections.Generic.IEnumerable<string>)Entry.ChangelogUrls, (Func<string, bool>)([SpecialName] (string x) => x.Contains("modrinth.com")));
		if (text == null || text2 == null)
		{
			ModBase.OpenWebsite(Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)Entry.ChangelogUrls));
			return;
		}
		switch (ModMain.MyMsgBox("要在哪个网站上查看更新日志？", "查看更新日志", "Modrinth", "CurseForge", "取消"))
		{
		case 1:
			ModBase.OpenWebsite(text2);
			break;
		case 2:
			ModBase.OpenWebsite(text);
			break;
		}
	}

	private void BtnUpdate_Click(object sender, EventArgs e)
	{
		switch (ModMain.MyMsgBox(string.Format("是否要更新 {0}？{1}{2}{3}", new object[4]
		{
			Entry.Name,
			"\r\n",
			"\r\n",
			GetUpdateCompareDescription()
		}), "更新确认", "更新", "查看更新日志", "取消"))
		{
		case 1:
			switch (Entry.Comp.Type)
			{
			case ModComp.CompType.Mod:
				ModMain.FrmInstanceMod.UpdateResource(new ModLocalComp.LocalCompFile[] { Entry });
				break;
			case ModComp.CompType.ResourcePack:
				ModMain.FrmInstanceResourcePack.UpdateResource(new ModLocalComp.LocalCompFile[] { Entry });
				break;
			case ModComp.CompType.Shader:
				ModMain.FrmInstanceShader.UpdateResource(new ModLocalComp.LocalCompFile[] { Entry });
				break;
			case ModComp.CompType.ModPack:
				break;
			}
			break;
		case 2:
			ShowUpdateLog();
			break;
		case 3:
			break;
		}
	}

	private void PanTitle_SizeChanged()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Invalid comparison between Unknown and I4
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Invalid comparison between Unknown and I4
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		GridLength width = ColumnExtend.Width;
		int num;
		if (!width.IsStar)
		{
			width = ColumnTitle.Width;
			num = ((!width.IsStar) ? 1 : 2);
		}
		else
		{
			num = 0;
		}
		int num2 = default(int);
		switch (num)
		{
		case 0:
			if (ColumnExtend.ActualWidth < 0.5)
			{
				num2 = (((int)((UIElement)LabSubtitle).Visibility != 2) ? 1 : 2);
				goto default;
			}
			break;
		case 1:
			if (ColumnSubtitle.ActualWidth < 0.5)
			{
				num2 = 2;
			}
			else
			{
				if (LabSubtitle.IsTextTrimmed())
				{
					break;
				}
				num2 = 0;
			}
			goto default;
		case 2:
			if (!LabTitle.IsTextTrimmed())
			{
				num2 = (((int)((UIElement)LabSubtitle).Visibility != 2) ? 1 : 0);
				goto default;
			}
			break;
		default:
			switch (num2)
			{
			case 0:
				ColumnTitle.Width = GridLength.Auto;
				ColumnSubtitle.Width = GridLength.Auto;
				ColumnExtend.Width = new GridLength(1.0, (GridUnitType)2);
				break;
			case 1:
				ColumnTitle.Width = GridLength.Auto;
				ColumnSubtitle.Width = new GridLength(1.0, (GridUnitType)2);
				ColumnExtend.Width = new GridLength(0.0, (GridUnitType)1);
				break;
			case 2:
				ColumnTitle.Width = new GridLength(1.0, (GridUnitType)2);
				ColumnSubtitle.Width = new GridLength(0.0, (GridUnitType)1);
				ColumnExtend.Width = new GridLength(0.0, (GridUnitType)1);
				break;
			}
			break;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/mylocalmoditem.xaml", (UriKind)2);
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
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyLocalCompItem)target;
			break;
		case 2:
			ColumnPaddingRight = (ColumnDefinition)target;
			break;
		case 3:
			PathLogo = (MyImage)target;
			break;
		case 4:
			PanTitle = (Grid)target;
			break;
		case 5:
			ColumnTitle = (ColumnDefinition)target;
			break;
		case 6:
			ColumnSubtitle = (ColumnDefinition)target;
			break;
		case 7:
			ColumnExtend = (ColumnDefinition)target;
			break;
		case 8:
			LabTitle = (TextBlock)target;
			break;
		case 9:
			LabSubtitle = (TextBlock)target;
			break;
		case 10:
			BtnUpdate = (MyIconButton)target;
			break;
		case 11:
			PanTags = (StackPanel)target;
			break;
		case 12:
			LabInfo = (TextBlock)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
