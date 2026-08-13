using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using SearchOption = System.IO.SearchOption;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
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
using Microsoft.VisualBasic.FileIO;
using FileSystem = Microsoft.VisualBasic.FileIO.FileSystem;
using PCL.Core.UI;

namespace PCL;

[DesignerGenerated]
public class PageInstanceCompResource : MyPageRight, IRefreshable, IComponentConnector
{
	public enum FilterType
	{
		All,
		Enabled,
		Disabled,
		CanUpdate,
		Unavailable,
		Duplicate
	}

	public enum SortMethod
	{
		FileName,
		CompName,
		TagNums,
		CreateTime,
		ModFileSize
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine___Lambda_0024__29_002D0 : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal PageInstanceCompResource _0024VB_0024Me;

		internal _Closure_0024__29_002D0 _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;

		internal _Closure_0024__29_002D1 _0024VB_0024ResumableLocal__0024VB_0024Closure__00241;

		internal bool _0024VB_0024ResumableLocal_Selected_00242;

		internal int _0024VB_0024ResumableLocal_NewCount_00243;

		internal TaskAwaiter _0024A0;

		internal TaskAwaiter<List<ModLocalComp.LocalCompFile>> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_0367: Unknown result type (might be due to invalid IL or missing references)
			//IL_036c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0373: Unknown result type (might be due to invalid IL or missing references)
			//IL_0511: Unknown result type (might be due to invalid IL or missing references)
			//IL_0516: Unknown result type (might be due to invalid IL or missing references)
			//IL_051e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_0382: Unknown result type (might be due to invalid IL or missing references)
			//IL_052d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Expected O, but got Unknown
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_066f: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d3: Expected O, but got Unknown
			//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_085c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0868: Expected O, but got Unknown
			//IL_032b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0330: Unknown result type (might be due to invalid IL or missing references)
			//IL_0344: Unknown result type (might be due to invalid IL or missing references)
			//IL_0345: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val2;
				TaskAwaiter val;
				List<ModLocalComp.LocalCompFile> result;
				TaskAwaiter<List<ModLocalComp.LocalCompFile>> awaiter;
				List<ModLocalComp.LocalCompFile> val3;
				switch (num)
				{
				default:
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240 = new _Closure_0024__29_002D0(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240);
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Me = _0024VB_0024Me;
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_AnyCount = 0;
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_EnabledCount = 0;
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_DisabledCount = 0;
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_UpdateCount = 0;
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_UnavalialeCount = 0;
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_ItemSource = Enumerable.ToArray<ModLocalComp.LocalCompFile>(_0024VB_0024Me.IsSearching ? ((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)_0024VB_0024Me.SearchResult) : Enumerable.Select<MyLocalCompItem, ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<MyLocalCompItem>)_0024VB_0024Me.ModItems.Values, (Func<MyLocalCompItem, ModLocalComp.LocalCompFile>)([SpecialName] (MyLocalCompItem i) => i.Entry)));
					val2 = System.Threading.Tasks.Task.Run((Action)checked([SpecialName] () =>
					{
						ModLocalComp.LocalCompFile[] _0024VB_0024Local_ItemSource = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_ItemSource;
						foreach (ModLocalComp.LocalCompFile obj in _0024VB_0024Local_ItemSource)
						{
							_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_AnyCount++;
							if (obj.CanUpdate)
							{
								_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_UpdateCount++;
							}
							if (obj.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine)
							{
								_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_EnabledCount++;
							}
							if (obj.State == ModLocalComp.LocalCompFile.LocalFileStatus.Disabled)
							{
								_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_DisabledCount++;
							}
							if (obj.State == ModLocalComp.LocalCompFile.LocalFileStatus.Unavailable)
							{
								_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_UnavalialeCount++;
							}
						}
					})).GetAwaiter();
					if (!val2.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val2;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine___Lambda_0024__29_002D0>(ref val2, ref _this);
						return;
					}
					goto IL_013e;
				case 0:
					num = (_0024State = -1);
					val2 = _0024A0;
					_0024A0 = default(TaskAwaiter);
					goto IL_013e;
				case 1:
					num = (_0024State = -1);
					awaiter = _0024A1;
					_0024A1 = default(TaskAwaiter<List<ModLocalComp.LocalCompFile>>);
					goto IL_0379;
				case 2:
					{
						num = (_0024State = -1);
						val = _0024A0;
						_0024A0 = default(TaskAwaiter);
						goto IL_0524;
					}
					IL_0379:
					result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<List<ModLocalComp.LocalCompFile>>);
					val3 = result;
					_0024VB_0024Me.BtnFilterDuplicate.Text = $"重复 ({val3.Count})";
					((UIElement)_0024VB_0024Me.BtnFilterDuplicate).Visibility = (Visibility)((_0024VB_0024Me.Filter != FilterType.Duplicate && !Enumerable.Any<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)val3)) ? 2 : 0);
					if (!string.IsNullOrEmpty(_0024VB_0024Me.CurrentFolderPath))
					{
						((UIElement)_0024VB_0024Me.BtnManageBack).Visibility = (Visibility)0;
					}
					else
					{
						((UIElement)_0024VB_0024Me.BtnManageBack).Visibility = (Visibility)2;
					}
					_0024VB_0024ResumableLocal_NewCount_00243 = _0024VB_0024Me.SelectedMods.Count;
					_0024VB_0024ResumableLocal_Selected_00242 = _0024VB_0024ResumableLocal_NewCount_00243 > 0;
					if (_0024VB_0024ResumableLocal_Selected_00242)
					{
						_0024VB_0024Me.LabSelect.Text = $"已选择 {_0024VB_0024ResumableLocal_NewCount_00243} 个文件";
					}
					if (!_0024VB_0024ResumableLocal_Selected_00242)
					{
						break;
					}
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00241 = new _Closure_0024__29_002D1(_0024VB_0024ResumableLocal__0024VB_0024Closure__00241);
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024NonLocal__0024VB_0024Closure_2 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_HasUpdate = false;
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_HasEnabled = false;
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_HasDisabled = false;
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_CanFavoriteAndShare = true;
					val = System.Threading.Tasks.Task.Run((Action)([SpecialName] () =>
					{
						//IL_000a: Unknown result type (might be due to invalid IL or missing references)
						//IL_000f: Unknown result type (might be due to invalid IL or missing references)
						System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
						try
						{
							enumerator = ModLocalComp.CompResourceListLoader.Output.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ModLocalComp.LocalCompFile current = enumerator.Current;
								if (_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.SelectedMods.Contains(current.RawPath))
								{
									if (current.CanUpdate)
									{
										_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_HasUpdate = true;
									}
									if (current.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine)
									{
										_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_HasEnabled = true;
									}
									else if (current.State == ModLocalComp.LocalCompFile.LocalFileStatus.Disabled)
									{
										_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_HasDisabled = true;
									}
									if ((object)current.Comp == null || string.IsNullOrEmpty(current.Comp.Id))
									{
										_0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_CanFavoriteAndShare = false;
									}
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator).Dispose();
						}
					})).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 2);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine___Lambda_0024__29_002D0>(ref val, ref _this);
						return;
					}
					goto IL_0524;
					IL_013e:
					val2.GetResult();
					val2 = default(TaskAwaiter);
					_0024VB_0024Me.BtnFilterAll.Text = (_0024VB_0024Me.IsSearching ? "搜索结果" : "全部") + $" ({_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_AnyCount})";
					_0024VB_0024Me.BtnFilterCanUpdate.Text = $"可更新 ({_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_UpdateCount})";
					((UIElement)_0024VB_0024Me.BtnFilterCanUpdate).Visibility = (Visibility)((_0024VB_0024Me.Filter != FilterType.CanUpdate && _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_UpdateCount <= 0) ? 2 : 0);
					_0024VB_0024Me.BtnFilterEnabled.Text = $"启用 ({_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_EnabledCount})";
					((UIElement)_0024VB_0024Me.BtnFilterEnabled).Visibility = (Visibility)((_0024VB_0024Me.Filter != FilterType.Enabled && (_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_EnabledCount <= 0 || _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_EnabledCount >= _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_AnyCount)) ? 2 : 0);
					_0024VB_0024Me.BtnFilterDisabled.Text = $"禁用 ({_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_DisabledCount})";
					((UIElement)_0024VB_0024Me.BtnFilterDisabled).Visibility = (Visibility)((_0024VB_0024Me.Filter != FilterType.Disabled && _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_DisabledCount <= 0) ? 2 : 0);
					_0024VB_0024Me.BtnFilterError.Text = $"错误 ({_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_UnavalialeCount})";
					((UIElement)_0024VB_0024Me.BtnFilterError).Visibility = (Visibility)((_0024VB_0024Me.Filter != FilterType.Unavailable && _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_UnavalialeCount <= 0) ? 2 : 0);
					awaiter = System.Threading.Tasks.Task.Run<List<ModLocalComp.LocalCompFile>>((Func<List<ModLocalComp.LocalCompFile>>)([SpecialName] () => Enumerable.ToList<ModLocalComp.LocalCompFile>(Enumerable.SelectMany<IGrouping<string, ModLocalComp.LocalCompFile>, ModLocalComp.LocalCompFile>(Enumerable.Where<IGrouping<string, ModLocalComp.LocalCompFile>>(Enumerable.GroupBy<ModLocalComp.LocalCompFile, string>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_ItemSource, (Func<ModLocalComp.LocalCompFile, string>)([SpecialName] (ModLocalComp.LocalCompFile m) => ((object)m.Comp == null) ? ":Nothing:" : m.Comp.Id)), (Func<IGrouping<string, ModLocalComp.LocalCompFile>, bool>)([SpecialName] (IGrouping<string, ModLocalComp.LocalCompFile> g) => Enumerable.Count<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)g) > 1 && (object)Enumerable.First<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)g).Comp != null)), (Func<IGrouping<string, ModLocalComp.LocalCompFile>, System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>>)([SpecialName] (IGrouping<string, ModLocalComp.LocalCompFile> g) => (System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)g))))).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0024State = 1);
						_0024A1 = awaiter;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<List<ModLocalComp.LocalCompFile>>, VB_0024StateMachine___Lambda_0024__29_002D0>(ref awaiter, ref _this);
						return;
					}
					goto IL_0379;
					IL_0524:
					val.GetResult();
					val = default(TaskAwaiter);
					((UIElement)_0024VB_0024Me.BtnSelectDisable).IsEnabled = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_HasEnabled;
					((UIElement)_0024VB_0024Me.BtnSelectEnable).IsEnabled = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_HasDisabled;
					((UIElement)_0024VB_0024Me.BtnSelectUpdate).IsEnabled = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_HasUpdate;
					if (_0024VB_0024Me.CurrentCompType == ModComp.CompType.Schematic)
					{
						((UIElement)_0024VB_0024Me.BtnSelectUpdate).Visibility = (Visibility)2;
						((UIElement)_0024VB_0024Me.BtnSelectFavorites).Visibility = (Visibility)2;
						((UIElement)_0024VB_0024Me.BtnSelectShare).Visibility = (Visibility)2;
					}
					else
					{
						((UIElement)_0024VB_0024Me.BtnSelectUpdate).Visibility = (Visibility)0;
						((UIElement)_0024VB_0024Me.BtnSelectFavorites).Visibility = (Visibility)0;
						((UIElement)_0024VB_0024Me.BtnSelectShare).Visibility = (Visibility)0;
						((UIElement)_0024VB_0024Me.BtnSelectFavorites).IsEnabled = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_CanFavoriteAndShare;
						((UIElement)_0024VB_0024Me.BtnSelectShare).IsEnabled = _0024VB_0024ResumableLocal__0024VB_0024Closure__00241._0024VB_0024Local_CanFavoriteAndShare;
					}
					break;
				}
				if (ModAnimation.AniControlEnabled == 0)
				{
					((FrameworkElement)_0024VB_0024Me.PanListBack).Margin = new Thickness(0.0, 0.0, 0.0, (double)(_0024VB_0024ResumableLocal_Selected_00242 ? 95 : 15));
					if (_0024VB_0024ResumableLocal_Selected_00242)
					{
						if (_0024VB_0024Me.BottomBarShownCount >= _0024VB_0024ResumableLocal_NewCount_00243)
						{
							_0024VB_0024Me.BottomBarShownCount = _0024VB_0024ResumableLocal_NewCount_00243;
						}
						else
						{
							_0024VB_0024Me.BottomBarShownCount = _0024VB_0024ResumableLocal_NewCount_00243;
							((UIElement)_0024VB_0024Me.CardSelect).Visibility = (Visibility)0;
							ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[4]
							{
								ModAnimation.AaOpacity(_0024VB_0024Me.CardSelect, 1.0 - ((UIElement)_0024VB_0024Me.CardSelect).Opacity, 60),
								ModAnimation.AaTranslateY(_0024VB_0024Me.CardSelect, -27.0 - _0024VB_0024Me.TransSelect.Y, 120, 0, new ModAnimation.AniEaseOutFluent(ModAnimation.AniEasePower.Weak)),
								ModAnimation.AaTranslateY(_0024VB_0024Me.CardSelect, 3.0, 150, 120, new ModAnimation.AniEaseInoutFluent(ModAnimation.AniEasePower.Weak)),
								ModAnimation.AaTranslateY(_0024VB_0024Me.CardSelect, -1.0, 90, 270, new ModAnimation.AniEaseInoutFluent(ModAnimation.AniEasePower.Weak))
							}, "Mod Sidebar");
						}
					}
					else if (_0024VB_0024Me.BottomBarShownCount != 0)
					{
						_0024VB_0024Me.BottomBarShownCount = 0;
						ModAnimation.AniStart((System.Collections.IList)(object)new ModAnimation.AniData[3]
						{
							ModAnimation.AaOpacity(_0024VB_0024Me.CardSelect, 0.0 - ((UIElement)_0024VB_0024Me.CardSelect).Opacity, 90),
							ModAnimation.AaTranslateY(_0024VB_0024Me.CardSelect, -10.0 - _0024VB_0024Me.TransSelect.Y, 90, 0, new ModAnimation.AniEaseInFluent(ModAnimation.AniEasePower.Weak)),
							ModAnimation.AaCode((ThreadStart)([SpecialName] [CompilerGenerated] () =>
							{
								((UIElement)_0024VB_0024Me.CardSelect).Visibility = (Visibility)2;
							}), 0, After: true)
						}, "Mod Sidebar");
					}
				}
				else
				{
					ModAnimation.AniStop("Mod Sidebar");
					_0024VB_0024Me.BottomBarShownCount = _0024VB_0024ResumableLocal_NewCount_00243;
					if (_0024VB_0024ResumableLocal_Selected_00242)
					{
						((UIElement)_0024VB_0024Me.CardSelect).Visibility = (Visibility)0;
						((UIElement)_0024VB_0024Me.CardSelect).Opacity = 1.0;
						_0024VB_0024Me.TransSelect.Y = -25.0;
					}
					else
					{
						((UIElement)_0024VB_0024Me.CardSelect).Visibility = (Visibility)2;
						((UIElement)_0024VB_0024Me.CardSelect).Opacity = 0.0;
						_0024VB_0024Me.TransSelect.Y = -10.0;
					}
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

		public static Action _0024I10_002D0;

		public static VB_0024AnonymousDelegate_17<MyLocalCompItem, EventArgs> _0024I27_002D1;

		public static MyLocalCompItem.ClickEventHandler _0024IR27_002D10;

		public static Func<MyLocalCompItem, ModLocalComp.LocalCompFile> _0024I28_002D0;

		public static Func<MyLocalCompItem, ModLocalComp.LocalCompFile> _0024I29_002D1;

		public static Func<ModLocalComp.LocalCompFile, string> _0024I29_002D4;

		public static Func<IGrouping<string, ModLocalComp.LocalCompFile>, bool> _0024I29_002D5;

		public static Func<IGrouping<string, ModLocalComp.LocalCompFile>, System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>> _0024I29_002D6;

		public static VB_0024AnonymousDelegate_18<string, string> _0024I39_002D0;

		public static VB_0024AnonymousDelegate_19<ModLocalComp.LocalCompFile, ModLocalComp.LocalCompFile, int> _0024I63_002D0;

		public static Func<ModLocalComp.LocalCompFile, System.Collections.Generic.IEnumerable<string>> _0024I70_002D0;

		public static Func<string, bool> _0024I70_002D1;

		public static Func<string, ModLocalComp.LocalCompFile> _0024I70_002D2;

		public static Func<ModLocalComp.LocalCompFile, ModComp.CompProject> _0024I72_002D1;

		public static Func<ModLocalComp.LocalCompFile, string> _0024I73_002D1;

		public static Func<FileInfo, bool> _0024I74_002D0;

		public static Func<ModBase.SearchEntry<ModLocalComp.LocalCompFile>, ModLocalComp.LocalCompFile> _0024I88_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__10_002D0()
		{
			ModMain.MyMsgBox("现改为双击文件夹进入子文件夹。", "操作提示", "我知道了");
			ModBase.Setup.Set("UiSchematicFirstTimeHintShown", true);
		}

		[SpecialName]
		internal void _Lambda_0024__R27_002D10(object a0, MouseButtonEventArgs a1)
		{
			((VB_0024AnonymousDelegate_17<MyLocalCompItem, EventArgs>)([SpecialName] (MyLocalCompItem ss, EventArgs ee) =>
			{
				ss.Checked = !ss.Checked;
			}))((MyLocalCompItem)a0, (EventArgs)(object)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__27_002D1(MyLocalCompItem ss, EventArgs ee)
		{
			ss.Checked = !ss.Checked;
		}

		[SpecialName]
		internal ModLocalComp.LocalCompFile _Lambda_0024__28_002D0(MyLocalCompItem i)
		{
			return i.Entry;
		}

		[SpecialName]
		internal ModLocalComp.LocalCompFile _Lambda_0024__29_002D1(MyLocalCompItem i)
		{
			return i.Entry;
		}

		[SpecialName]
		internal string _Lambda_0024__29_002D4(ModLocalComp.LocalCompFile m)
		{
			if ((object)m.Comp == null)
			{
				return ":Nothing:";
			}
			return m.Comp.Id;
		}

		[SpecialName]
		internal bool _Lambda_0024__29_002D5(IGrouping<string, ModLocalComp.LocalCompFile> g)
		{
			if (Enumerable.Count<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)g) > 1)
			{
				return (object)Enumerable.First<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)g).Comp != null;
			}
			return false;
		}

		[SpecialName]
		internal System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile> _Lambda_0024__29_002D6(IGrouping<string, ModLocalComp.LocalCompFile> g)
		{
			return (System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)g;
		}

		[SpecialName]
		internal void _Lambda_0024__39_002D0(string Content, string FileName)
		{
			try
			{
				string text = SystemDialogs.SelectSaveFile("选择保存位置", FileName, "文本文件(*.txt)|*.txt|CSV 文件(*.csv)|*.csv");
				if (!string.IsNullOrWhiteSpace(text))
				{
					File.WriteAllText(text, Content, Encoding.UTF8);
					ModBase.OpenExplorer(text);
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "导出资源信息失败", ModBase.LogLevel.Msgbox);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal int _Lambda_0024__63_002D0(ModLocalComp.LocalCompFile a, ModLocalComp.LocalCompFile b)
		{
			if (a.IsFolder && !b.IsFolder)
			{
				return -1;
			}
			if (!a.IsFolder && b.IsFolder)
			{
				return 1;
			}
			return 0;
		}

		[SpecialName]
		internal System.Collections.Generic.IEnumerable<string> _Lambda_0024__70_002D0(ModLocalComp.LocalCompFile Target)
		{
			if (Target.IsFolder)
			{
				return new string[] { Target.Path };
			}
			if (Target.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine)
			{
				return new string[2]
				{
					Target.Path,
					Target.Path + (File.Exists(Target.Path + ".old") ? ".old" : ".disabled")
				};
			}
			return new string[] { Target.Path, Target.RawPath };
		}

		[SpecialName]
		internal bool _Lambda_0024__70_002D1(string m)
		{
			if (!ModBase.EndsWithF(m, "\\__FOLDER__", IgnoreCase: true))
			{
				return File.Exists(m);
			}
			return Directory.Exists(m.Replace("\\__FOLDER__", ""));
		}

		[SpecialName]
		internal ModLocalComp.LocalCompFile _Lambda_0024__70_002D2(string m)
		{
			return new ModLocalComp.LocalCompFile(m);
		}

		[SpecialName]
		internal ModComp.CompProject _Lambda_0024__72_002D1(ModLocalComp.LocalCompFile i)
		{
			return i.Comp;
		}

		[SpecialName]
		internal string _Lambda_0024__73_002D1(ModLocalComp.LocalCompFile i)
		{
			return i.Comp.Id;
		}

		[SpecialName]
		internal bool _Lambda_0024__74_002D0(FileInfo f)
		{
			return Conversions.ToBoolean(ModLocalComp.LocalCompFile.IsCompFile(((FileSystemInfo)f).FullName, ModComp.CompType.Schematic));
		}

		[SpecialName]
		internal ModLocalComp.LocalCompFile _Lambda_0024__88_002D0(ModBase.SearchEntry<ModLocalComp.LocalCompFile> r)
		{
			return r.Item;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__25_002D0
	{
		public string _0024VB_0024Local_rootPath;

		public PageInstanceCompResource _0024VB_0024Me;

		public _Closure_0024__25_002D0(_Closure_0024__25_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_rootPath = arg0._0024VB_0024Local_rootPath;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(ModLocalComp.LocalCompFile item)
		{
			string text = (item.IsFolder ? item.ActualPath : item.Path);
			DirectoryInfo parent = Directory.GetParent(text);
			string text2 = ((parent != null) ? ((FileSystemInfo)parent).FullName : null);
			if (string.IsNullOrEmpty(_0024VB_0024Me.CurrentFolderPath))
			{
				return text2.Equals(_0024VB_0024Local_rootPath, (StringComparison)5);
			}
			return text2.Equals(_0024VB_0024Me.CurrentFolderPath, (StringComparison)5);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__27_002D0
	{
		public System.DateTime _0024VB_0024Local_lastClickTime;

		public PageInstanceCompResource _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__R9(object a0, MouseButtonEventArgs a1)
		{
			_Lambda_0024__0((MyLocalCompItem)a0, (EventArgs)(object)a1);
		}

		[SpecialName]
		internal void _Lambda_0024__0(MyLocalCompItem ss, EventArgs ee)
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			System.DateTime now = System.DateTime.Now;
			TimeSpan val = now - _0024VB_0024Local_lastClickTime;
			if (val.TotalMilliseconds <= 300.0)
			{
				_0024VB_0024Me.EnterFolderWithCheck(ss.Entry.ActualPath);
			}
			else
			{
				ss.Checked = !ss.Checked;
			}
			_0024VB_0024Local_lastClickTime = now;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__28_002D0
	{
		public Func<ModLocalComp.LocalCompFile, ModLocalComp.LocalCompFile, int> _0024VB_0024Local_sortMethod;

		public _Closure_0024__28_002D0(_Closure_0024__28_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_sortMethod = arg0._0024VB_0024Local_sortMethod;
			}
		}

		[SpecialName]
		internal int _Lambda_0024__2(ModLocalComp.LocalCompFile a, ModLocalComp.LocalCompFile b)
		{
			return _0024VB_0024Local_sortMethod.Invoke(a, b);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__28_002D1
	{
		public List<ModLocalComp.LocalCompFile> _0024VB_0024Local_ShowingMods;

		public _Closure_0024__28_002D1(_Closure_0024__28_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ShowingMods = arg0._0024VB_0024Local_ShowingMods;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__3(string m)
		{
			_Closure_0024__28_002D2 arg = default(_Closure_0024__28_002D2);
			_Closure_0024__28_002D2 CS_0024_003C_003E8__locals0 = new _Closure_0024__28_002D2(null)
			{
				_0024VB_0024Local_m = m
			};
			return Enumerable.Any<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)_0024VB_0024Local_ShowingMods, (Func<ModLocalComp.LocalCompFile, bool>)([SpecialName] (ModLocalComp.LocalCompFile s) => Operators.CompareString(s.RawPath, CS_0024_003C_003E8__locals0._0024VB_0024Local_m, false) == 0));
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__28_002D2
	{
		public string _0024VB_0024Local_m;

		public _Closure_0024__28_002D2(_Closure_0024__28_002D2 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_m = arg0._0024VB_0024Local_m;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__4(ModLocalComp.LocalCompFile s)
		{
			return Operators.CompareString(s.RawPath, _0024VB_0024Local_m, false) == 0;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__29_002D0
	{
		public ModLocalComp.LocalCompFile[] _0024VB_0024Local_ItemSource;

		public int _0024VB_0024Local_AnyCount;

		public int _0024VB_0024Local_UpdateCount;

		public int _0024VB_0024Local_EnabledCount;

		public int _0024VB_0024Local_DisabledCount;

		public int _0024VB_0024Local_UnavalialeCount;

		public PageInstanceCompResource _0024VB_0024Me;

		public _Closure_0024__29_002D0(_Closure_0024__29_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ItemSource = arg0._0024VB_0024Local_ItemSource;
				_0024VB_0024Local_AnyCount = arg0._0024VB_0024Local_AnyCount;
				_0024VB_0024Local_UpdateCount = arg0._0024VB_0024Local_UpdateCount;
				_0024VB_0024Local_EnabledCount = arg0._0024VB_0024Local_EnabledCount;
				_0024VB_0024Local_DisabledCount = arg0._0024VB_0024Local_DisabledCount;
				_0024VB_0024Local_UnavalialeCount = arg0._0024VB_0024Local_UnavalialeCount;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			ModLocalComp.LocalCompFile[] array = _0024VB_0024Local_ItemSource;
			checked
			{
				foreach (ModLocalComp.LocalCompFile obj in array)
				{
					_0024VB_0024Local_AnyCount++;
					if (obj.CanUpdate)
					{
						_0024VB_0024Local_UpdateCount++;
					}
					if (obj.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine)
					{
						_0024VB_0024Local_EnabledCount++;
					}
					if (obj.State == ModLocalComp.LocalCompFile.LocalFileStatus.Disabled)
					{
						_0024VB_0024Local_DisabledCount++;
					}
					if (obj.State == ModLocalComp.LocalCompFile.LocalFileStatus.Unavailable)
					{
						_0024VB_0024Local_UnavalialeCount++;
					}
				}
			}
		}

		[SpecialName]
		internal List<ModLocalComp.LocalCompFile> _Lambda_0024__3()
		{
			return Enumerable.ToList<ModLocalComp.LocalCompFile>(Enumerable.SelectMany<IGrouping<string, ModLocalComp.LocalCompFile>, ModLocalComp.LocalCompFile>(Enumerable.Where<IGrouping<string, ModLocalComp.LocalCompFile>>(Enumerable.GroupBy<ModLocalComp.LocalCompFile, string>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)_0024VB_0024Local_ItemSource, (Func<ModLocalComp.LocalCompFile, string>)([SpecialName] (ModLocalComp.LocalCompFile m) => ((object)m.Comp == null) ? ":Nothing:" : m.Comp.Id)), (Func<IGrouping<string, ModLocalComp.LocalCompFile>, bool>)([SpecialName] (IGrouping<string, ModLocalComp.LocalCompFile> g) => Enumerable.Count<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)g) > 1 && (object)Enumerable.First<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)g).Comp != null)), (Func<IGrouping<string, ModLocalComp.LocalCompFile>, System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>>)([SpecialName] (IGrouping<string, ModLocalComp.LocalCompFile> g) => (System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)g)));
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__29_002D1
	{
		public bool _0024VB_0024Local_HasUpdate;

		public bool _0024VB_0024Local_HasEnabled;

		public bool _0024VB_0024Local_HasDisabled;

		public bool _0024VB_0024Local_CanFavoriteAndShare;

		public _Closure_0024__29_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__29_002D1(_Closure_0024__29_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_HasUpdate = arg0._0024VB_0024Local_HasUpdate;
				_0024VB_0024Local_HasEnabled = arg0._0024VB_0024Local_HasEnabled;
				_0024VB_0024Local_HasDisabled = arg0._0024VB_0024Local_HasDisabled;
				_0024VB_0024Local_CanFavoriteAndShare = arg0._0024VB_0024Local_CanFavoriteAndShare;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__7()
		{
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
			try
			{
				enumerator = ModLocalComp.CompResourceListLoader.Output.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModLocalComp.LocalCompFile current = enumerator.Current;
					if (_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.SelectedMods.Contains(current.RawPath))
					{
						if (current.CanUpdate)
						{
							_0024VB_0024Local_HasUpdate = true;
						}
						if (current.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine)
						{
							_0024VB_0024Local_HasEnabled = true;
						}
						else if (current.State == ModLocalComp.LocalCompFile.LocalFileStatus.Disabled)
						{
							_0024VB_0024Local_HasDisabled = true;
						}
						if ((object)current.Comp == null || string.IsNullOrEmpty(current.Comp.Id))
						{
							_0024VB_0024Local_CanFavoriteAndShare = false;
						}
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__36_002D0
	{
		public string _0024VB_0024Local_Extension;

		public _Closure_0024__36_002D0(_Closure_0024__36_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Extension = arg0._0024VB_0024Local_Extension;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(string t)
		{
			return Operators.CompareString(t, _0024VB_0024Local_Extension, false) == 0;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__37_002D0
	{
		public PageInstanceCompResource _0024VB_0024Local_CurrentForm;

		public _Closure_0024__37_002D0(_Closure_0024__37_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_CurrentForm = arg0._0024VB_0024Local_CurrentForm;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			_0024VB_0024Local_CurrentForm.ReloadCompFileList(ForceReload: true);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__60_002D0
	{
		public SortMethod _0024VB_0024Local_i;

		public PageInstanceCompResource _0024VB_0024Me;

		public _Closure_0024__60_002D0(_Closure_0024__60_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_i = arg0._0024VB_0024Local_i;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R14(object a0, RoutedEventArgs a1)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			_0024VB_0024Me.SetSortMethod(_0024VB_0024Local_i);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__65_002D0
	{
		public ModLocalComp.LocalCompFile _0024VB_0024Local_ModEntity;

		public _Closure_0024__65_002D0(_Closure_0024__65_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ModEntity = arg0._0024VB_0024Local_ModEntity;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__0(MyLocalCompItem i)
		{
			return i.Entry == _0024VB_0024Local_ModEntity;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__68_002D0
	{
		public System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile> _0024VB_0024Local_ModList;

		public _Closure_0024__68_002D0(_Closure_0024__68_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ModList = arg0._0024VB_0024Local_ModList;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__68_002D1
	{
		public Dictionary<string, string> _0024VB_0024Local_FileCopyList;

		public List<string> _0024VB_0024Local_FinishedFileNames;

		public ModLoader.LoaderCombo<System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>> _0024VB_0024Local_Loader;

		public string _0024VB_0024Local_PathMods;

		public _Closure_0024__68_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public Action _0024I2;

		public _Closure_0024__68_002D1(_Closure_0024__68_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_FileCopyList = arg0._0024VB_0024Local_FileCopyList;
				_0024VB_0024Local_FinishedFileNames = arg0._0024VB_0024Local_FinishedFileNames;
				_0024VB_0024Local_Loader = arg0._0024VB_0024Local_Loader;
				_0024VB_0024Local_PathMods = arg0._0024VB_0024Local_PathMods;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R15(ModLoader.LoaderTask<int, int> a0)
		{
			_Lambda_0024__0();
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Expected O, but got Unknown
			//IL_0138: Expected O, but got Unknown
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
				try
				{
					enumerator = _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModList.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						ModLocalComp.LocalCompFile current = enumerator.Current;
						if (File.Exists(current.Path))
						{
							FileSystem.DeleteFile(current.Path, (UIOption)3, (RecycleOption)3);
						}
						else
						{
							ModBase.Log($"[CompUpdate] 未找到更新前的资源文件，跳过对它的删除：{current.Path}", ModBase.LogLevel.Debug);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>> enumerator2 = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>>);
				try
				{
					enumerator2 = _0024VB_0024Local_FileCopyList.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						KeyValuePair<string, string> current2 = enumerator2.Current;
						if (File.Exists(current2.Value))
						{
							FileSystem.DeleteFile(current2.Value, (UIOption)3, (RecycleOption)3);
							ModBase.Log($"[Mod] 更新后的资源文件已存在，将会把它放入回收站：{current2.Value}", ModBase.LogLevel.Debug);
						}
						if (Directory.Exists(ModBase.GetPathFromFullPath(current2.Value)))
						{
							File.Move(current2.Key, current2.Value);
							_0024VB_0024Local_FinishedFileNames.Add(ModBase.GetFileNameFromPath(current2.Value));
						}
						else
						{
							ModBase.Log($"[Mod] 更新后的目标文件夹已被删除：{current2.Value}", ModBase.LogLevel.Debug);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator2).Dispose();
				}
			}
			catch (OperationCanceledException val)
			{
				ProjectData.SetProjectError((System.Exception)val);
				OperationCanceledException ex = val;
				ModBase.Log((System.Exception)(object)ex, "替换旧版资源文件时被主动取消");
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__R16(ModLoader.LoaderBase a0)
		{
			_Lambda_0024__1();
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Expected O, but got Unknown
			//IL_0108: Expected O, but got Unknown
			switch (_0024VB_0024Local_Loader.State)
			{
			default:
				return;
			case ModBase.LoadState.Finished:
				switch (_0024VB_0024Local_FinishedFileNames.Count)
				{
				case 0:
					ModBase.Log("[CompUpdate] 没有资源被成功更新");
					break;
				case 1:
					ModMain.Hint($"已成功更新 {Enumerable.Single<string>((System.Collections.Generic.IEnumerable<string>)_0024VB_0024Local_FinishedFileNames)}！", ModMain.HintType.Finish);
					break;
				default:
					ModMain.Hint($"已成功更新 {_0024VB_0024Local_FinishedFileNames.Count} 个资源！", ModMain.HintType.Finish);
					break;
				}
				break;
			case ModBase.LoadState.Failed:
				ModMain.Hint("资源更新失败：" + _0024VB_0024Local_Loader.Error.Message, ModMain.HintType.Critical);
				break;
			case ModBase.LoadState.Aborted:
				ModMain.Hint("资源更新已中止！");
				break;
			}
			ModBase.Log($"[CompUpdate] 已从正在进行资源更新的文件夹列表移除：{_0024VB_0024Local_PathMods}");
			UpdatingVersions.Remove(_0024VB_0024Local_PathMods);
			Action action;
			if (_0024I2 != null)
			{
				action = _0024I2;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					//IL_0010: Unknown result type (might be due to invalid IL or missing references)
					try
					{
						System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
						try
						{
							enumerator = _0024VB_0024Local_FileCopyList.Keys.GetEnumerator();
							while (enumerator.MoveNext())
							{
								string current = enumerator.Current;
								if (File.Exists(current))
								{
									File.Delete(current);
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator).Dispose();
						}
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "清理资源更新缓存失败");
						ProjectData.ClearProjectError();
					}
				};
				Action val2 = val;
				_0024I2 = val;
				action = val2;
			}
			ModBase.RunInNewThread(action, "Clean Comp Update Cache", (ThreadPriority)1);
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
				try
				{
					enumerator = _0024VB_0024Local_FileCopyList.Keys.GetEnumerator();
					while (enumerator.MoveNext())
					{
						string current = enumerator.Current;
						if (File.Exists(current))
						{
							File.Delete(current);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "清理资源更新缓存失败");
				ProjectData.ClearProjectError();
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__70_002D0
	{
		public ModLocalComp.LocalCompFile _0024VB_0024Local_ModEntity;

		public _Closure_0024__70_002D0(_Closure_0024__70_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_ModEntity = arg0._0024VB_0024Local_ModEntity;
			}
		}

		[SpecialName]
		internal bool _Lambda_0024__3(MyLocalCompItem i)
		{
			return i.Entry.Equals(_0024VB_0024Local_ModEntity);
		}
	}

	private readonly Dictionary<string, ValueTuple<System.DateTime, long>> ModFileInfoCache;

	private ModComp.CompType CurrentCompType;

	private MyLocalCompItem.SwipeSelect CurrentSwipSelect;

	private bool IsLoad;

	public Dictionary<string, MyLocalCompItem> ModItems;

	private int BottomBarShownCount;

	public HashSet<string> SelectedMods;

	private FilterType _Filter;

	private SortMethod CurrentSortMethod;

	private readonly object SortLock;

	public static List<string> UpdatingVersions = new List<string>();

	private List<ModLocalComp.LocalCompFile> SearchResult;

	[CompilerGenerated]
	[AccessedThroughProperty("SearchBox")]
	private MySearchBox _SearchBox;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnManageBack")]
	private MyButton _BtnManageBack;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnManageOpen")]
	private MyButton _BtnManageOpen;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnManageInstall")]
	private MyButton _BtnManageInstall;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnManageDownload")]
	private MyButton _BtnManageDownload;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnManageSelectAll")]
	private MyButton _BtnManageSelectAll;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnManageInfoExport")]
	private MyButton _BtnManageInfoExport;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnFilterAll")]
	private MyRadioButton _BtnFilterAll;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnFilterEnabled")]
	private MyRadioButton _BtnFilterEnabled;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnFilterDisabled")]
	private MyRadioButton _BtnFilterDisabled;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnFilterCanUpdate")]
	private MyRadioButton _BtnFilterCanUpdate;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnFilterError")]
	private MyRadioButton _BtnFilterError;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnFilterDuplicate")]
	private MyRadioButton _BtnFilterDuplicate;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSort")]
	private MyIconTextButton _BtnSort;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnHintBack")]
	private MyButton _BtnHintBack;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnHintInstall")]
	private MyButton _BtnHintInstall;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnHintDownload")]
	private MyButton _BtnHintDownload;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnHintOpen")]
	private MyButton _BtnHintOpen;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSchematicDownloadMod")]
	private MyButton _BtnSchematicDownloadMod;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSchematicVersionSelect")]
	private MyButton _BtnSchematicVersionSelect;

	[CompilerGenerated]
	[AccessedThroughProperty("Load")]
	private MyLoading _Load;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSelectUpdate")]
	private MyIconTextButton _BtnSelectUpdate;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSelectEnable")]
	private MyIconTextButton _BtnSelectEnable;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSelectDisable")]
	private MyIconTextButton _BtnSelectDisable;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSelectFavorites")]
	private MyIconTextButton _BtnSelectFavorites;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSelectShare")]
	private MyIconTextButton _BtnSelectShare;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSelectDelete")]
	private MyIconTextButton _BtnSelectDelete;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSelectCancel")]
	private MyIconTextButton _BtnSelectCancel;

	private bool _contentLoaded;

	[field: CompilerGenerated]
	public string CurrentFolderPath
	{
		[CompilerGenerated]
		get;
		[CompilerGenerated]
		set;
	}

	public FilterType Filter
	{
		get
		{
			return _Filter;
		}
		set
		{
			if (_Filter != value)
			{
				_Filter = value;
				switch (value)
				{
				case FilterType.All:
					BtnFilterAll.Checked = true;
					break;
				case FilterType.Enabled:
					BtnFilterEnabled.Checked = true;
					break;
				case FilterType.Disabled:
					BtnFilterDisabled.Checked = true;
					break;
				case FilterType.CanUpdate:
					BtnFilterCanUpdate.Checked = true;
					break;
				case FilterType.Duplicate:
					BtnFilterDuplicate.Checked = true;
					break;
				default:
					BtnFilterError.Checked = true;
					break;
				}
				RefreshUI();
			}
		}
	}

	public bool IsSearching => !string.IsNullOrWhiteSpace(SearchBox.Text);

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanAllBack")]
	internal virtual Grid PanAllBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
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

	internal virtual MySearchBox SearchBox
	{
		[CompilerGenerated]
		get
		{
			return _SearchBox;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(SearchBox_PreviewKeyDown);
			MySearchBox.TextChangedEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
			{
				SearchRun();
			};
			MySearchBox searchBox = _SearchBox;
			if (searchBox != null)
			{
				((UIElement)searchBox).PreviewKeyDown -= val;
				searchBox.TextChanged -= obj;
			}
			_SearchBox = value;
			searchBox = _SearchBox;
			if (searchBox != null)
			{
				((UIElement)searchBox).PreviewKeyDown += val;
				searchBox.TextChanged += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanManage")]
	internal virtual MyCard PanManage
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnManageBack
	{
		[CompilerGenerated]
		get
		{
			return _BtnManageBack;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageBack_Click;
			MyButton btnManageBack = _BtnManageBack;
			if (btnManageBack != null)
			{
				btnManageBack.Click -= obj;
			}
			_BtnManageBack = value;
			btnManageBack = _BtnManageBack;
			if (btnManageBack != null)
			{
				btnManageBack.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnManageOpen
	{
		[CompilerGenerated]
		get
		{
			return _BtnManageOpen;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageOpen_Click;
			MyButton btnManageOpen = _BtnManageOpen;
			if (btnManageOpen != null)
			{
				btnManageOpen.Click -= obj;
			}
			_BtnManageOpen = value;
			btnManageOpen = _BtnManageOpen;
			if (btnManageOpen != null)
			{
				btnManageOpen.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnManageInstall
	{
		[CompilerGenerated]
		get
		{
			return _BtnManageInstall;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageInstall_Click;
			MyButton btnManageInstall = _BtnManageInstall;
			if (btnManageInstall != null)
			{
				btnManageInstall.Click -= obj;
			}
			_BtnManageInstall = value;
			btnManageInstall = _BtnManageInstall;
			if (btnManageInstall != null)
			{
				btnManageInstall.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnManageDownload
	{
		[CompilerGenerated]
		get
		{
			return _BtnManageDownload;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageDownload_Click;
			MyButton btnManageDownload = _BtnManageDownload;
			if (btnManageDownload != null)
			{
				btnManageDownload.Click -= obj;
			}
			_BtnManageDownload = value;
			btnManageDownload = _BtnManageDownload;
			if (btnManageDownload != null)
			{
				btnManageDownload.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnManageSelectAll
	{
		[CompilerGenerated]
		get
		{
			return _BtnManageSelectAll;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageSelectAll_Click;
			MyButton btnManageSelectAll = _BtnManageSelectAll;
			if (btnManageSelectAll != null)
			{
				btnManageSelectAll.Click -= obj;
			}
			_BtnManageSelectAll = value;
			btnManageSelectAll = _BtnManageSelectAll;
			if (btnManageSelectAll != null)
			{
				btnManageSelectAll.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnManageInfoExport
	{
		[CompilerGenerated]
		get
		{
			return _BtnManageInfoExport;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageInfoExport_Click;
			MyButton btnManageInfoExport = _BtnManageInfoExport;
			if (btnManageInfoExport != null)
			{
				btnManageInfoExport.Click -= obj;
			}
			_BtnManageInfoExport = value;
			btnManageInfoExport = _BtnManageInfoExport;
			if (btnManageInfoExport != null)
			{
				btnManageInfoExport.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnManageCheck")]
	internal virtual MyButton BtnManageCheck
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanListBack")]
	internal virtual MyCard PanListBack
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanFilter")]
	internal virtual StackPanel PanFilter
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyRadioButton BtnFilterAll
	{
		[CompilerGenerated]
		get
		{
			return _BtnFilterAll;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				ChangeFilter((MyRadioButton)a0, a1);
			};
			MyRadioButton btnFilterAll = _BtnFilterAll;
			if (btnFilterAll != null)
			{
				btnFilterAll.Check -= obj;
			}
			_BtnFilterAll = value;
			btnFilterAll = _BtnFilterAll;
			if (btnFilterAll != null)
			{
				btnFilterAll.Check += obj;
			}
		}
	}

	internal virtual MyRadioButton BtnFilterEnabled
	{
		[CompilerGenerated]
		get
		{
			return _BtnFilterEnabled;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				ChangeFilter((MyRadioButton)a0, a1);
			};
			MyRadioButton btnFilterEnabled = _BtnFilterEnabled;
			if (btnFilterEnabled != null)
			{
				btnFilterEnabled.Check -= obj;
			}
			_BtnFilterEnabled = value;
			btnFilterEnabled = _BtnFilterEnabled;
			if (btnFilterEnabled != null)
			{
				btnFilterEnabled.Check += obj;
			}
		}
	}

	internal virtual MyRadioButton BtnFilterDisabled
	{
		[CompilerGenerated]
		get
		{
			return _BtnFilterDisabled;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				ChangeFilter((MyRadioButton)a0, a1);
			};
			MyRadioButton btnFilterDisabled = _BtnFilterDisabled;
			if (btnFilterDisabled != null)
			{
				btnFilterDisabled.Check -= obj;
			}
			_BtnFilterDisabled = value;
			btnFilterDisabled = _BtnFilterDisabled;
			if (btnFilterDisabled != null)
			{
				btnFilterDisabled.Check += obj;
			}
		}
	}

	internal virtual MyRadioButton BtnFilterCanUpdate
	{
		[CompilerGenerated]
		get
		{
			return _BtnFilterCanUpdate;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				ChangeFilter((MyRadioButton)a0, a1);
			};
			MyRadioButton btnFilterCanUpdate = _BtnFilterCanUpdate;
			if (btnFilterCanUpdate != null)
			{
				btnFilterCanUpdate.Check -= obj;
			}
			_BtnFilterCanUpdate = value;
			btnFilterCanUpdate = _BtnFilterCanUpdate;
			if (btnFilterCanUpdate != null)
			{
				btnFilterCanUpdate.Check += obj;
			}
		}
	}

	internal virtual MyRadioButton BtnFilterError
	{
		[CompilerGenerated]
		get
		{
			return _BtnFilterError;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				ChangeFilter((MyRadioButton)a0, a1);
			};
			MyRadioButton btnFilterError = _BtnFilterError;
			if (btnFilterError != null)
			{
				btnFilterError.Check -= obj;
			}
			_BtnFilterError = value;
			btnFilterError = _BtnFilterError;
			if (btnFilterError != null)
			{
				btnFilterError.Check += obj;
			}
		}
	}

	internal virtual MyRadioButton BtnFilterDuplicate
	{
		[CompilerGenerated]
		get
		{
			return _BtnFilterDuplicate;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyRadioButton.CheckEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, bool a1) =>
			{
				ChangeFilter((MyRadioButton)a0, a1);
			};
			MyRadioButton btnFilterDuplicate = _BtnFilterDuplicate;
			if (btnFilterDuplicate != null)
			{
				btnFilterDuplicate.Check -= obj;
			}
			_BtnFilterDuplicate = value;
			btnFilterDuplicate = _BtnFilterDuplicate;
			if (btnFilterDuplicate != null)
			{
				btnFilterDuplicate.Check += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnSort
	{
		[CompilerGenerated]
		get
		{
			return _BtnSort;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnSortClick;
			MyIconTextButton btnSort = _BtnSort;
			if (btnSort != null)
			{
				btnSort.Click -= obj;
			}
			_BtnSort = value;
			btnSort = _BtnSort;
			if (btnSort != null)
			{
				btnSort.Click += obj;
			}
		}
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
	[field: AccessedThroughProperty("PanEmpty")]
	internal virtual MyCard PanEmpty
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TxtEmptyTitle")]
	internal virtual TextBlock TxtEmptyTitle
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TxtEmptyDescription")]
	internal virtual TextBlock TxtEmptyDescription
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnHintBack
	{
		[CompilerGenerated]
		get
		{
			return _BtnHintBack;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnHintBack_Click;
			MyButton btnHintBack = _BtnHintBack;
			if (btnHintBack != null)
			{
				btnHintBack.Click -= obj;
			}
			_BtnHintBack = value;
			btnHintBack = _BtnHintBack;
			if (btnHintBack != null)
			{
				btnHintBack.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnHintInstall
	{
		[CompilerGenerated]
		get
		{
			return _BtnHintInstall;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageInstall_Click;
			MyButton btnHintInstall = _BtnHintInstall;
			if (btnHintInstall != null)
			{
				btnHintInstall.Click -= obj;
			}
			_BtnHintInstall = value;
			btnHintInstall = _BtnHintInstall;
			if (btnHintInstall != null)
			{
				btnHintInstall.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnHintDownload
	{
		[CompilerGenerated]
		get
		{
			return _BtnHintDownload;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageDownload_Click;
			MyButton btnHintDownload = _BtnHintDownload;
			if (btnHintDownload != null)
			{
				btnHintDownload.Click -= obj;
			}
			_BtnHintDownload = value;
			btnHintDownload = _BtnHintDownload;
			if (btnHintDownload != null)
			{
				btnHintDownload.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnHintOpen
	{
		[CompilerGenerated]
		get
		{
			return _BtnHintOpen;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnManageOpen_Click;
			MyButton btnHintOpen = _BtnHintOpen;
			if (btnHintOpen != null)
			{
				btnHintOpen.Click -= obj;
			}
			_BtnHintOpen = value;
			btnHintOpen = _BtnHintOpen;
			if (btnHintOpen != null)
			{
				btnHintOpen.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanSchematicEmpty")]
	internal virtual MyCard PanSchematicEmpty
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnSchematicDownloadMod
	{
		[CompilerGenerated]
		get
		{
			return _BtnSchematicDownloadMod;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnSchematicDownloadMod_Click;
			MyButton btnSchematicDownloadMod = _BtnSchematicDownloadMod;
			if (btnSchematicDownloadMod != null)
			{
				btnSchematicDownloadMod.Click -= obj;
			}
			_BtnSchematicDownloadMod = value;
			btnSchematicDownloadMod = _BtnSchematicDownloadMod;
			if (btnSchematicDownloadMod != null)
			{
				btnSchematicDownloadMod.Click += obj;
			}
		}
	}

	internal virtual MyButton BtnSchematicVersionSelect
	{
		[CompilerGenerated]
		get
		{
			return _BtnSchematicVersionSelect;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyButton.ClickEventHandler obj = BtnSchematicVersionSelect_Click;
			MyButton btnSchematicVersionSelect = _BtnSchematicVersionSelect;
			if (btnSchematicVersionSelect != null)
			{
				btnSchematicVersionSelect.Click -= obj;
			}
			_BtnSchematicVersionSelect = value;
			btnSchematicVersionSelect = _BtnSchematicVersionSelect;
			if (btnSchematicVersionSelect != null)
			{
				btnSchematicVersionSelect.Click += obj;
			}
		}
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

	internal virtual MyLoading Load
	{
		[CompilerGenerated]
		get
		{
			return _Load;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyLoading.ClickEventHandler obj = Load_Click;
			MyLoading.StateChangedEventHandler obj2 = [SpecialName] [CompilerGenerated] (object a0, MyLoading.MyLoadingState a1, MyLoading.MyLoadingState a2) =>
			{
				UnselectedAllWithAnimation();
			};
			MyLoading load = _Load;
			if (load != null)
			{
				load.Click -= obj;
				load.StateChanged -= obj2;
			}
			_Load = value;
			load = _Load;
			if (load != null)
			{
				load.Click += obj;
				load.StateChanged += obj2;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardSelect")]
	internal virtual MyCard CardSelect
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TransSelect")]
	internal virtual TranslateTransform TransSelect
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("LabSelect")]
	internal virtual TextBlock LabSelect
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyIconTextButton BtnSelectUpdate
	{
		[CompilerGenerated]
		get
		{
			return _BtnSelectUpdate;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnSelectUpdate_Click();
			};
			MyIconTextButton btnSelectUpdate = _BtnSelectUpdate;
			if (btnSelectUpdate != null)
			{
				btnSelectUpdate.Click -= obj;
			}
			_BtnSelectUpdate = value;
			btnSelectUpdate = _BtnSelectUpdate;
			if (btnSelectUpdate != null)
			{
				btnSelectUpdate.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnSelectEnable
	{
		[CompilerGenerated]
		get
		{
			return _BtnSelectEnable;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnSelectED_Click((MyIconTextButton)a0, a1);
			};
			MyIconTextButton btnSelectEnable = _BtnSelectEnable;
			if (btnSelectEnable != null)
			{
				btnSelectEnable.Click -= obj;
			}
			_BtnSelectEnable = value;
			btnSelectEnable = _BtnSelectEnable;
			if (btnSelectEnable != null)
			{
				btnSelectEnable.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnSelectDisable
	{
		[CompilerGenerated]
		get
		{
			return _BtnSelectDisable;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnSelectED_Click((MyIconTextButton)a0, a1);
			};
			MyIconTextButton btnSelectDisable = _BtnSelectDisable;
			if (btnSelectDisable != null)
			{
				btnSelectDisable.Click -= obj;
			}
			_BtnSelectDisable = value;
			btnSelectDisable = _BtnSelectDisable;
			if (btnSelectDisable != null)
			{
				btnSelectDisable.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnSelectFavorites
	{
		[CompilerGenerated]
		get
		{
			return _BtnSelectFavorites;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = BtnSelectFavorites_Click;
			MyIconTextButton btnSelectFavorites = _BtnSelectFavorites;
			if (btnSelectFavorites != null)
			{
				btnSelectFavorites.Click -= obj;
			}
			_BtnSelectFavorites = value;
			btnSelectFavorites = _BtnSelectFavorites;
			if (btnSelectFavorites != null)
			{
				btnSelectFavorites.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnSelectShare
	{
		[CompilerGenerated]
		get
		{
			return _BtnSelectShare;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnSelectShare_Click();
			};
			MyIconTextButton btnSelectShare = _BtnSelectShare;
			if (btnSelectShare != null)
			{
				btnSelectShare.Click -= obj;
			}
			_BtnSelectShare = value;
			btnSelectShare = _BtnSelectShare;
			if (btnSelectShare != null)
			{
				btnSelectShare.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnSelectDelete
	{
		[CompilerGenerated]
		get
		{
			return _BtnSelectDelete;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnSelectDelete_Click();
			};
			MyIconTextButton btnSelectDelete = _BtnSelectDelete;
			if (btnSelectDelete != null)
			{
				btnSelectDelete.Click -= obj;
			}
			_BtnSelectDelete = value;
			btnSelectDelete = _BtnSelectDelete;
			if (btnSelectDelete != null)
			{
				btnSelectDelete.Click += obj;
			}
		}
	}

	internal virtual MyIconTextButton BtnSelectCancel
	{
		[CompilerGenerated]
		get
		{
			return _BtnSelectCancel;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyIconTextButton.ClickEventHandler obj = [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
			{
				BtnSelectCancel_Click();
			};
			MyIconTextButton btnSelectCancel = _BtnSelectCancel;
			if (btnSelectCancel != null)
			{
				btnSelectCancel.Click -= obj;
			}
			_BtnSelectCancel = value;
			btnSelectCancel = _BtnSelectCancel;
			if (btnSelectCancel != null)
			{
				btnSelectCancel.Click += obj;
			}
		}
	}

	public PageInstanceCompResource()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		((FrameworkElement)this).Unloaded += new RoutedEventHandler(Page_Unloaded);
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			PageOther_Loaded();
		});
		((FrameworkElement)this).Initialized += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			LoaderInit();
		});
		base.PageExit += UnselectedAllWithAnimation;
		ModFileInfoCache = new Dictionary<string, ValueTuple<System.DateTime, long>>();
		CurrentCompType = ModComp.CompType.Mod;
		IsLoad = false;
		CurrentFolderPath = "";
		ModItems = new Dictionary<string, MyLocalCompItem>();
		BottomBarShownCount = 0;
		SelectedMods = new HashSet<string>();
		_Filter = FilterType.All;
		CurrentSortMethod = SortMethod.CompName;
		SortLock = RuntimeHelpers.GetObjectValue(new object());
		InitializeComponent();
	}

	private ValueTuple<System.DateTime, long> GetModFileInfo(string path)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		ValueTuple<System.DateTime, long> result = default(ValueTuple<System.DateTime, long>);
		if (ModFileInfoCache.TryGetValue(path, out result))
		{
			return result;
		}
		ValueTuple<System.DateTime, long> result2 = default(ValueTuple<System.DateTime, long>);
		try
		{
			FileInfo val = new FileInfo(path);
			ValueTuple<System.DateTime, long> val2 = new ValueTuple<System.DateTime, long>(((FileSystemInfo)val).CreationTime, val.Length);
			if (!ModFileInfoCache.ContainsKey(path))
			{
				ModFileInfoCache.Add(path, val2);
			}
			result2 = val2;
			return result2;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "获取模组信息失败: " + path);
			result2 = new(System.DateTime.MinValue, 0L);
			ProjectData.ClearProjectError();
		}
		return result2;
	}

	private void Page_Unloaded(object sender, RoutedEventArgs e)
	{
		ModFileInfoCache.Clear();
	}

	public PageInstanceCompResource(ModComp.CompType LoadCompType)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		((FrameworkElement)this).Unloaded += new RoutedEventHandler(Page_Unloaded);
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
		{
			PageOther_Loaded();
		});
		((FrameworkElement)this).Initialized += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			LoaderInit();
		});
		base.PageExit += UnselectedAllWithAnimation;
		ModFileInfoCache = new Dictionary<string, ValueTuple<System.DateTime, long>>();
		CurrentCompType = ModComp.CompType.Mod;
		IsLoad = false;
		CurrentFolderPath = "";
		ModItems = new Dictionary<string, MyLocalCompItem>();
		BottomBarShownCount = 0;
		SelectedMods = new HashSet<string>();
		_Filter = FilterType.All;
		CurrentSortMethod = SortMethod.CompName;
		SortLock = RuntimeHelpers.GetObjectValue(new object());
		CurrentCompType = LoadCompType;
		CurrentFolderPath = "";
		CurrentSwipSelect = new MyLocalCompItem.SwipeSelect
		{
			TargetFrm = this
		};
		InitializeComponent();
ModComp.CompType[] array = new ModComp.CompType[] { (ModComp.CompType)3, (ModComp.CompType)2, (ModComp.CompType)6 };
		if (Enumerable.Contains<ModComp.CompType>((System.Collections.Generic.IEnumerable<ModComp.CompType>)array, CurrentCompType))
		{
			((UIElement)BtnSelectEnable).Visibility = (Visibility)2;
			((UIElement)BtnSelectDisable).Visibility = (Visibility)2;
		}
		if (CurrentCompType == ModComp.CompType.Schematic)
		{
			((UIElement)BtnManageDownload).Visibility = (Visibility)2;
			((UIElement)BtnHintDownload).Visibility = (Visibility)2;
		}
	}

	private ModLocalComp.CompLocalLoaderData GetRequireLoaderData()
	{
		ModLocalComp.CompLocalLoaderData compLocalLoaderData = new ModLocalComp.CompLocalLoaderData();
		compLocalLoaderData.GameVersion = PageInstanceLeft.Instance;
		compLocalLoaderData.Frm = this;
		List<ModComp.CompLoaderType> loaders = new List<ModComp.CompLoaderType>();
		switch (CurrentCompType)
		{
		case ModComp.CompType.Mod:
			loaders = ModLocalComp.GetCurrentVersionModLoader();
			break;
		case ModComp.CompType.ResourcePack:
			loaders = Enumerable.ToList<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)new ModComp.CompLoaderType[] { ModComp.CompLoaderType.Minecraft });
			break;
		case ModComp.CompType.Shader:
		{
ModComp.CompLoaderType[] array = new ModComp.CompLoaderType[] { (ModComp.CompLoaderType)10, (ModComp.CompLoaderType)9, (ModComp.CompLoaderType)11, (ModComp.CompLoaderType)8 };
			loaders = Enumerable.ToList<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)array);
			break;
		}
		case ModComp.CompType.Schematic:
			loaders = Enumerable.ToList<ModComp.CompLoaderType>((System.Collections.Generic.IEnumerable<ModComp.CompLoaderType>)new ModComp.CompLoaderType[] { ModComp.CompLoaderType.Minecraft });
			break;
		}
		compLocalLoaderData.Loaders = loaders;
		compLocalLoaderData.CompPath = PageInstanceLeft.Instance.PathIndie + (PageInstanceLeft.Instance.Version.HasLabyMod ? ("labymod-neo\\fabric\\" + PageInstanceLeft.Instance.Version.McName + "\\") : "") + ModLocalComp.GetPathNameByCompType(CurrentCompType) + "\\";
		compLocalLoaderData.CompType = CurrentCompType;
		return compLocalLoaderData;
	}

	public void PageOther_Loaded()
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected O, but got Unknown
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		CurrentFolderPath = string.Empty;
		if (ModMain.FrmMain.PageLast.Page != FormMain.PageType.CompDetail)
		{
			((ScrollViewer)PanBack).ScrollToHome();
		}
		checked
		{
			ModAnimation.AniControlEnabled++;
			SelectedMods.Clear();
			ReloadCompFileList();
			ChangeAllSelected(Value: false);
			ModAnimation.AniControlEnabled--;
			if (IsLoad)
			{
				return;
			}
			IsLoad = true;
			if (Conversions.ToBoolean((object)(CurrentCompType == ModComp.CompType.Schematic && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiSchematicFirstTimeHintShown"))))))
			{
				object action;
				if (_Closure_0024__._0024I10_002D0 != null)
				{
					action = _Closure_0024__._0024I10_002D0;
				}
				else
				{
					Action val = [SpecialName] () =>
					{
						ModMain.MyMsgBox("现改为双击文件夹进入子文件夹。", "操作提示", "我知道了");
						ModBase.Setup.Set("UiSchematicFirstTimeHintShown", true);
					};
					_Closure_0024__._0024I10_002D0 = val;
					action = (object)val;
				}
				ModBase.RunInUi((Action)action, ForceWaitUntilLoaded: true);
			}
			((UIElement)ModMain.FrmMain).KeyDown += new KeyEventHandler(FrmMain_KeyDown);
			foreach (MyRadioButton child in ((Panel)PanFilter).Children)
			{
				((FrameworkElement)child.LabText).Margin = new Thickness(-2.0, 0.0, 8.0, 0.0);
			}
		}
	}

	public void ReloadCompFileList(bool ForceReload = false)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		if (LoaderRun(ForceReload ? ModLoader.LoaderFolderRunType.ForceRun : ModLoader.LoaderFolderRunType.RunOnUpdated))
		{
			ModBase.Log($"[System] 已刷新 {CurrentCompType} 列表");
			ModFileInfoCache.Clear();
			ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
			{
				Filter = FilterType.All;
				((ScrollViewer)PanBack).ScrollToHome();
				SearchBox.Text = "";
			}));
		}
	}

	private void RefreshSelf()
	{
		Refresh(CurrentCompType);
	}

	void IRefreshable.Refresh()
	{
		//ILSpy generated this explicit interface implementation from .override directive in RefreshSelf
		this.RefreshSelf();
	}

	public static void Refresh(ModComp.CompType WhichPage)
	{
		try
		{
			ModComp.CompProjectCache.Clear();
			ModComp.CompFilesCache.Clear();
			File.Delete(ModBase.PathTemp + "Cache\\LocalComp.json");
			ModBase.Log("[CompResource] 由于点击刷新按钮，清理本地工程信息缓存");
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "强制刷新时清理本地工程信息缓存失败");
			ProjectData.ClearProjectError();
		}
		switch (WhichPage)
		{
		case ModComp.CompType.Mod:
			if (ModMain.FrmInstanceMod != null)
			{
				ModMain.FrmInstanceMod.ReloadCompFileList(ForceReload: true);
			}
			ModMain.FrmInstanceLeft.ItemMod.Checked = true;
			break;
		case ModComp.CompType.ResourcePack:
			if (ModMain.FrmInstanceResourcePack != null)
			{
				ModMain.FrmInstanceResourcePack.ReloadCompFileList(ForceReload: true);
			}
			ModMain.FrmInstanceLeft.ItemResourcePack.Checked = true;
			break;
		case ModComp.CompType.Shader:
			if (ModMain.FrmInstanceShader != null)
			{
				ModMain.FrmInstanceShader.ReloadCompFileList(ForceReload: true);
			}
			ModMain.FrmInstanceLeft.ItemShader.Checked = true;
			break;
		case ModComp.CompType.Schematic:
			if (ModMain.FrmInstanceSchematic != null)
			{
				ModMain.FrmInstanceSchematic.ReloadCompFileList(ForceReload: true);
			}
			ModMain.FrmInstanceLeft.ItemSchematic.Checked = true;
			break;
		}
		ModMain.Hint("正在刷新……", ModMain.HintType.Info, Log: false);
	}

	private void LoaderInit()
	{
		PageLoaderInit(Load, (FrameworkElement)(object)PanLoad, (FrameworkElement)(object)PanAllBack, null, ModLocalComp.CompResourceListLoader, [SpecialName] [CompilerGenerated] (ModLoader.LoaderBase a0) =>
		{
			LoadUIFromLoaderOutput();
		}, [SpecialName] [CompilerGenerated] () => CurrentCompType, AutoRun: false);
	}

	private void Load_Click(object sender, MouseButtonEventArgs e)
	{
		if (ModLocalComp.CompResourceListLoader.State == ModBase.LoadState.Failed)
		{
			LoaderRun(ModLoader.LoaderFolderRunType.ForceRun);
		}
	}

	public bool LoaderRun(ModLoader.LoaderFolderRunType Type)
	{
		return ModLoader.LoaderFolderRun(FolderPath: (!string.IsNullOrEmpty(CurrentFolderPath)) ? CurrentFolderPath : (PageInstanceLeft.Instance.PathIndie + (PageInstanceLeft.Instance.Version.HasLabyMod ? ("labymod-neo\\fabric\\" + PageInstanceLeft.Instance.Version.McName + "\\") : "") + ModLocalComp.GetPathNameByCompType(CurrentCompType) + "\\"), Loader: ModLocalComp.CompResourceListLoader, Type: Type, MaxDepth: 0, ExtraPath: "", WaitForExit: false, LoaderInput: GetRequireLoaderData());
	}

	private void EnterFolder(string folderPath)
	{
		try
		{
			if (string.IsNullOrEmpty(folderPath) || !Directory.Exists(folderPath))
			{
				ModMain.Hint("文件夹不存在或已被删除", ModMain.HintType.Critical);
				return;
			}
			CurrentFolderPath = folderPath;
			ModBase.Log($"[原理图] 进入文件夹：{folderPath}");
			ModLoader.LoaderFolderRun(ModLocalComp.CompResourceListLoader, folderPath, ModLoader.LoaderFolderRunType.ForceRun, 0, "", WaitForExit: false, GetRequireLoaderData());
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "进入文件夹失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void EnterFolderWithCheck(string folderPath)
	{
		try
		{
			EnterFolder(folderPath);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "进入文件夹失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void GoBackToParentFolder()
	{
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected O, but got Unknown
		if (string.IsNullOrEmpty(CurrentFolderPath))
		{
			return;
		}
		try
		{
			string text = PageInstanceLeft.Instance.PathIndie + (PageInstanceLeft.Instance.Version.HasLabyMod ? ("labymod-neo\\fabric\\" + PageInstanceLeft.Instance.Version.McName + "\\") : "") + ModLocalComp.GetPathNameByCompType(CurrentCompType) + "\\";
			text = Path.GetFullPath(text.TrimEnd('\\'));
			DirectoryInfo parent = Directory.GetParent(CurrentFolderPath);
			string text2 = ((parent != null) ? ((FileSystemInfo)parent).FullName : null);
			if (text2 == null || text2.Equals(text, (StringComparison)5) || !text2.StartsWith(text + "\\", (StringComparison)5))
			{
				CurrentFolderPath = "";
			}
			else
			{
				CurrentFolderPath = text2;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "路径处理失败");
			CurrentFolderPath = "";
			ProjectData.ClearProjectError();
		}
		ModBase.Log(string.Format("[原理图] 返回上级文件夹：{0}", (object)(string.IsNullOrEmpty(CurrentFolderPath) ? "根目录" : CurrentFolderPath)));
		string folderPath;
		if (string.IsNullOrEmpty(CurrentFolderPath))
		{
			folderPath = PageInstanceLeft.Instance.PathIndie + (PageInstanceLeft.Instance.Version.HasLabyMod ? ("labymod-neo\\fabric\\" + PageInstanceLeft.Instance.Version.McName + "\\") : "") + ModLocalComp.GetPathNameByCompType(CurrentCompType) + "\\";
		}
		else
		{
			folderPath = CurrentFolderPath;
		}
		ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
		{
			((UIElement)BtnManageBack).Visibility = (Visibility)(string.IsNullOrEmpty(CurrentFolderPath) ? 2 : 0);
		}));
		ModBase.RunInUi((Action)([SpecialName] () =>
		{
			ModLoader.LoaderFolderRun(ModLocalComp.CompResourceListLoader, folderPath, ModLoader.LoaderFolderRunType.ForceRun, 0, "", WaitForExit: false, GetRequireLoaderData());
		}), ForceWaitUntilLoaded: true);
	}

	private void LoadUIFromLoaderOutput()
	{
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected O, but got Unknown
		try
		{
			_Closure_0024__25_002D0 arg = default(_Closure_0024__25_002D0);
			_Closure_0024__25_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__25_002D0(null);
			CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
			if (Enumerable.Any<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)ModLocalComp.CompResourceListLoader.Output))
			{
				((UIElement)PanBack).Visibility = (Visibility)0;
				((UIElement)PanEmpty).Visibility = (Visibility)2;
				((UIElement)PanSchematicEmpty).Visibility = (Visibility)2;
				ModItems.Clear();
				CS_0024_003C_003E8__locals0._0024VB_0024Local_rootPath = PageInstanceLeft.Instance.PathIndie + (PageInstanceLeft.Instance.Version.HasLabyMod ? ("labymod-neo\\fabric\\" + PageInstanceLeft.Instance.Version.McName + "\\") : "") + ModLocalComp.GetPathNameByCompType(CurrentCompType) + "\\";
				CS_0024_003C_003E8__locals0._0024VB_0024Local_rootPath = Path.GetFullPath(CS_0024_003C_003E8__locals0._0024VB_0024Local_rootPath.TrimEnd('\\'));
				List<ModLocalComp.LocalCompFile> val = Enumerable.ToList<ModLocalComp.LocalCompFile>(Enumerable.Where<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)ModLocalComp.CompResourceListLoader.Output, (Func<ModLocalComp.LocalCompFile, bool>)([SpecialName] (ModLocalComp.LocalCompFile item) =>
				{
					string text = (item.IsFolder ? item.ActualPath : item.Path);
					DirectoryInfo parent = Directory.GetParent(text);
					string text2 = ((parent != null) ? ((FileSystemInfo)parent).FullName : null);
					return string.IsNullOrEmpty(CS_0024_003C_003E8__locals0._0024VB_0024Me.CurrentFolderPath) ? text2.Equals(CS_0024_003C_003E8__locals0._0024VB_0024Local_rootPath, (StringComparison)5) : text2.Equals(CS_0024_003C_003E8__locals0._0024VB_0024Me.CurrentFolderPath, (StringComparison)5);
				})));
				System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
				try
				{
					enumerator = val.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ModLocalComp.LocalCompFile current = enumerator.Current;
						ModItems[current.RawPath] = BuildLocalCompItem(current);
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
				{
					Filter = FilterType.All;
					SearchBox.Text = "";
					RefreshUI();
					SetSortMethod(SortMethod.CompName);
				}));
				return;
			}
			if (CurrentCompType == ModComp.CompType.Schematic && !Directory.Exists(PageInstanceLeft.Instance.PathIndie + "schematics\\"))
			{
				((UIElement)PanSchematicEmpty).Visibility = (Visibility)0;
				((UIElement)PanEmpty).Visibility = (Visibility)2;
				((UIElement)PanBack).Visibility = (Visibility)2;
				return;
			}
			if (CurrentCompType == ModComp.CompType.Schematic)
			{
				if (!string.IsNullOrEmpty(CurrentFolderPath))
				{
					TxtEmptyTitle.Text = "该文件夹为空";
					TxtEmptyDescription.Text = "你可以从已经下载好的文件安装资源";
				}
				else
				{
					TxtEmptyTitle.Text = "尚未安装资源";
					TxtEmptyDescription.Text = "你可以从已经下载好的文件安装资源。\r\n如果你已经安装了资源，可能是版本隔离设置有误，请在设置中调整版本隔离选项。";
				}
			}
			else
			{
				TxtEmptyTitle.Text = "尚未安装资源";
				TxtEmptyDescription.Text = "你可以下载新的资源，也可以从已经下载好的文件安装资源。\r\n如果你已经安装了资源，可能是版本隔离设置有误，请在设置中调整版本隔离选项。";
			}
			if (!string.IsNullOrEmpty(CurrentFolderPath))
			{
				((UIElement)BtnHintBack).Visibility = (Visibility)0;
			}
			else
			{
				((UIElement)BtnHintBack).Visibility = (Visibility)2;
			}
			((UIElement)PanEmpty).Visibility = (Visibility)0;
			((UIElement)PanBack).Visibility = (Visibility)2;
			((UIElement)PanSchematicEmpty).Visibility = (Visibility)2;
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, $"加载 {CurrentCompType} 列表 UI 失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private MyLocalCompItem BuildLocalCompItem(ModLocalComp.LocalCompFile Entry)
	{
		checked
		{
			try
			{
				ModAnimation.AniControlEnabled++;
				MyLocalCompItem myLocalCompItem = new MyLocalCompItem();
				((UIElement)myLocalCompItem).SnapsToDevicePixels = true;
				myLocalCompItem.Entry = Entry;
				myLocalCompItem.ButtonHandler = BuildLocalCompItemBtnHandler;
				myLocalCompItem.Checked = SelectedMods.Contains(Entry.RawPath);
				MyLocalCompItem myLocalCompItem2 = myLocalCompItem;
				myLocalCompItem2.CurrentSwipe = CurrentSwipSelect;
				myLocalCompItem2.Tags = Entry.Tags;
				MyLocalCompItem myLocalCompItem3 = myLocalCompItem2;
				Entry.OnCompUpdate += [SpecialName] (ModLocalComp.LocalCompFile a0) =>
				{
					myLocalCompItem3.Refresh();
				};
				myLocalCompItem2.Refresh();
				ModAnimation.AniControlEnabled--;
				return myLocalCompItem2;
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModAnimation.AniControlEnabled--;
				ModBase.Log(ex2, $"创建 UI 项失败：{Entry.RawPath}");
				throw;
			}
		}
	}

	private void BuildLocalCompItemBtnHandler(MyLocalCompItem sender, EventArgs e)
	{
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		sender.Changed += [SpecialName] [CompilerGenerated] (object a0, ModBase.RouteEventArgs a1) =>
		{
			CheckChanged((MyLocalCompItem)a0, a1);
		};
		if (sender.Entry.IsFolder)
		{
			_Closure_0024__27_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__27_002D0();
			CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_lastClickTime = System.DateTime.MinValue;
			sender.Click += [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				CS_0024_003C_003E8__locals0._Lambda_0024__0((MyLocalCompItem)a0, (EventArgs)(object)a1);
			};
		}
		else
		{
			sender.Click += [SpecialName] (object a0, MouseButtonEventArgs a1) =>
			{
				((VB_0024AnonymousDelegate_17<MyLocalCompItem, EventArgs>)([SpecialName] (MyLocalCompItem ss, EventArgs ee) =>
				{
					ss.Checked = !ss.Checked;
				}))((MyLocalCompItem)a0, (EventArgs)(object)a1);
			};
		}
		MyIconButton obj = new MyIconButton
		{
			LogoScale = 1.05,
			Logo = "M889.018182 418.909091H884.363636V316.509091a93.090909 93.090909 0 0 0-99.607272-89.832727h-302.545455l-93.090909-76.334546A46.545455 46.545455 0 0 0 358.865455 139.636364H146.152727A93.090909 93.090909 0 0 0 46.545455 229.469091V837.818182a46.545455 46.545455 0 0 0 46.545454 46.545454 46.545455 46.545455 0 0 0 16.756364-3.258181 109.381818 109.381818 0 0 0 25.134545 3.258181h586.472727a85.178182 85.178182 0 0 0 87.04-63.301818l163.374546-302.545454a46.545455 46.545455 0 0 0 5.585454-21.876364A82.385455 82.385455 0 0 0 889.018182 418.909091z m-744.727273-186.181818h198.283636l93.09091 76.334545a46.545455 46.545455 0 0 0 29.323636 10.705455h319.301818a12.101818 12.101818 0 0 1 6.516364 0V418.909091H302.545455a85.178182 85.178182 0 0 0-87.04 63.301818L139.636364 622.778182V232.727273a19.549091 19.549091 0 0 1 6.516363 0z m578.094546 552.029091a27.461818 27.461818 0 0 0-2.792728 6.516363H154.530909l147.083636-272.290909a27.461818 27.461818 0 0 0 2.792728-6.981818h565.061818z"
		};
		((FrameworkElement)obj).Tag = sender;
		MyIconButton myIconButton = obj;
		((FrameworkElement)myIconButton).ToolTip = "打开文件位置";
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton, 2.0);
		myIconButton.Click += [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			Open_Click((MyIconButton)a0, a1);
		};
		MyIconButton obj2 = new MyIconButton
		{
			LogoScale = 1.0,
			Logo = "M512 917.333333c223.861333 0 405.333333-181.472 405.333333-405.333333S735.861333 106.666667 512 106.666667 106.666667 288.138667 106.666667 512s181.472 405.333333 405.333333 405.333333z m0 106.666667C229.226667 1024 0 794.773333 0 512S229.226667 0 512 0s512 229.226667 512 512-229.226667 512-512 512z m-32-597.333333h64a21.333333 21.333333 0 0 1 21.333333 21.333333v320a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333V448a21.333333 21.333333 0 0 1 21.333333-21.333333z m0-192h64a21.333333 21.333333 0 0 1 21.333333 21.333333v64a21.333333 21.333333 0 0 1-21.333333 21.333333h-64a21.333333 21.333333 0 0 1-21.333333-21.333333v-64a21.333333 21.333333 0 0 1 21.333333-21.333333z"
		};
		((FrameworkElement)obj2).Tag = sender;
		MyIconButton myIconButton2 = obj2;
		((FrameworkElement)myIconButton2).ToolTip = "详情";
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton2, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton2, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton2, 2.0);
		myIconButton2.Click += Info_Click;
		((UIElement)sender).MouseRightButtonUp += new MouseButtonEventHandler(Info_Click);
		MyIconButton obj3 = new MyIconButton
		{
			LogoScale = 1.0,
			Logo = "M520.192 0C408.43 0 317.44 82.87 313.563 186.734H52.736c-29.038 0-52.663 21.943-52.663 49.079s23.625 49.152 52.663 49.152h58.075v550.473c0 103.35 75.118 187.757 167.717 187.757h472.43c92.599 0 167.716-83.894 167.716-187.757V285.477h52.59c29.038 0 52.59-21.943 52.663-49.08-0.073-27.135-23.625-49.151-52.663-49.151H726.235C723.237 83.017 631.955 0 520.192 0zM404.846 177.957c3.803-50.03 50.176-89.015 107.447-89.015 57.197 0 103.57 38.985 106.788 89.015H404.92zM284.379 933.669c-33.353 0-69.997-39.351-69.997-95.525v-549.01H833.39v549.522c0 56.247-36.645 95.525-69.998 95.525H284.379v-0.512z M357.23 800.695a48.274 48.274 0 0 0 47.616-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.69 49.006V751.69c0 27.282 20.846 49.006 47.617 49.006z m166.62 0a48.274 48.274 0 0 0 47.688-49.006V471.7a48.274 48.274 0 0 0-47.689-49.08 48.274 48.274 0 0 0-47.543 49.006V751.69c0 27.282 21.431 49.006 47.543 49.006z m142.92 0a48.274 48.274 0 0 0 47.543-49.006V471.7a48.274 48.274 0 0 0-47.543-49.08 48.274 48.274 0 0 0-47.616 49.006V751.69c0 27.282 20.773 49.006 47.543 49.006z"
		};
		((FrameworkElement)obj3).Tag = sender;
		MyIconButton myIconButton3 = obj3;
		((FrameworkElement)myIconButton3).ToolTip = "删除";
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton3, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton3, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton3, 2.0);
		myIconButton3.Click += [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			Delete_Click((MyIconButton)a0, a1);
		};
		if (CurrentCompType != 0 || sender.Entry.State == ModLocalComp.LocalCompFile.LocalFileStatus.Unavailable)
		{
			sender.Buttons = new MyIconButton[] { myIconButton2, myIconButton, myIconButton3 };
			return;
		}
		MyIconButton obj4 = new MyIconButton
		{
			LogoScale = 1.0,
			Logo = ((sender.Entry.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine) ? "M508 990.4c-261.6 0-474.4-212-474.4-474.4S246.4 41.6 508 41.6s474.4 212 474.4 474.4S769.6 990.4 508 990.4zM508 136.8c-209.6 0-379.2 169.6-379.2 379.2 0 209.6 169.6 379.2 379.2 379.2s379.2-169.6 379.2-379.2C887.2 306.4 717.6 136.8 508 136.8zM697.6 563.2 318.4 563.2c-26.4 0-47.2-21.6-47.2-47.2 0-26.4 21.6-47.2 47.2-47.2l379.2 0c26.4 0 47.2 21.6 47.2 47.2C744.8 542.4 724 563.2 697.6 563.2z" : "M512 0a512 512 0 1 0 512 512A512 512 0 0 0 512 0z m0 921.6a409.6 409.6 0 1 1 409.6-409.6 409.6 409.6 0 0 1-409.6 409.6z M716.8 339.968l-256 253.44L328.192 460.8A51.2 51.2 0 0 0 256 532.992l168.448 168.96a51.2 51.2 0 0 0 72.704 0l289.28-289.792A51.2 51.2 0 0 0 716.8 339.968z")
		};
		((FrameworkElement)obj4).Tag = sender;
		MyIconButton myIconButton4 = obj4;
		((FrameworkElement)myIconButton4).ToolTip = ((sender.Entry.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine) ? "禁用" : "启用");
		ToolTipService.SetPlacement((DependencyObject)(object)myIconButton4, (PlacementMode)3);
		ToolTipService.SetVerticalOffset((DependencyObject)(object)myIconButton4, 30.0);
		ToolTipService.SetHorizontalOffset((DependencyObject)(object)myIconButton4, 2.0);
		myIconButton4.Click += [SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			ED_Click((MyIconButton)a0, a1);
		};
		sender.Buttons = new MyIconButton[] { myIconButton2, myIconButton, myIconButton4, myIconButton3 };
	}

	public void RefreshUI()
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		_Closure_0024__28_002D1 arg = default(_Closure_0024__28_002D1);
		_Closure_0024__28_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__28_002D1(null);
		if (PanList == null)
		{
			return;
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowingMods = Enumerable.ToList<ModLocalComp.LocalCompFile>(Enumerable.Where<ModLocalComp.LocalCompFile>(IsSearching ? ((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)SearchResult) : Enumerable.Select<MyLocalCompItem, ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<MyLocalCompItem>)ModItems.Values, (Func<MyLocalCompItem, ModLocalComp.LocalCompFile>)([SpecialName] (MyLocalCompItem i) => i.Entry)), (Func<ModLocalComp.LocalCompFile, bool>)([SpecialName] [CompilerGenerated] (ModLocalComp.LocalCompFile m) => CanPassFilter(m))));
		if (Enumerable.Any<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowingMods))
		{
			_Closure_0024__28_002D0 arg2 = default(_Closure_0024__28_002D0);
			_Closure_0024__28_002D0 CS_0024_003C_003E8__locals1 = new _Closure_0024__28_002D0(null);
			CS_0024_003C_003E8__locals1._0024VB_0024Local_sortMethod = GetSortMethod(CurrentSortMethod);
			CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowingMods.Sort((Comparison<ModLocalComp.LocalCompFile>)([SpecialName] (ModLocalComp.LocalCompFile a, ModLocalComp.LocalCompFile b) => CS_0024_003C_003E8__locals1._0024VB_0024Local_sortMethod.Invoke(a, b)));
		}
		checked
		{
			ModAnimation.AniControlEnabled++;
			if (Enumerable.Any<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowingMods))
			{
				((UIElement)PanList).Visibility = (Visibility)0;
				((Panel)PanList).Children.Clear();
				System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
				try
				{
					enumerator = CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowingMods.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ModLocalComp.LocalCompFile current = enumerator.Current;
						if (ModItems.ContainsKey(current.RawPath))
						{
							MyLocalCompItem myLocalCompItem = ModItems[current.RawPath];
							if (((FrameworkElement)myLocalCompItem).Parent != null)
							{
								((Panel)((FrameworkElement)myLocalCompItem).Parent).Children.Remove((UIElement)(object)myLocalCompItem);
							}
							ModStyle.MinecraftFormatter.SetColorfulTextLab(myLocalCompItem.LabTitle.Text, myLocalCompItem.LabTitle, ThemeHelper.IsDarkMode());
							ModStyle.MinecraftFormatter.SetColorfulTextLab(myLocalCompItem.LabInfo.Text, myLocalCompItem.LabInfo, ThemeHelper.IsDarkMode());
							myLocalCompItem.Checked = SelectedMods.Contains(current.RawPath);
							((Panel)PanList).Children.Add((UIElement)(object)myLocalCompItem);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
			}
			else
			{
				((UIElement)PanList).Visibility = (Visibility)2;
			}
			ModAnimation.AniControlEnabled--;
			SelectedMods = new HashSet<string>(Enumerable.Where<string>((System.Collections.Generic.IEnumerable<string>)SelectedMods, (Func<string, bool>)([SpecialName] (string m) =>
			{
				_Closure_0024__28_002D2 arg3 = default(_Closure_0024__28_002D2);
				_Closure_0024__28_002D2 CS_0024_003C_003E8__locals2 = new _Closure_0024__28_002D2(null);
				CS_0024_003C_003E8__locals2._0024VB_0024Local_m = m;
				return Enumerable.Any<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)CS_0024_003C_003E8__locals0._0024VB_0024Local_ShowingMods, (Func<ModLocalComp.LocalCompFile, bool>)([SpecialName] (ModLocalComp.LocalCompFile s) => Operators.CompareString(s.RawPath, CS_0024_003C_003E8__locals2._0024VB_0024Local_m, false) == 0));
			})));
			RefreshBars();
		}
	}

	public void RefreshBars()
	{
		((DispatcherObject)this).Dispatcher.BeginInvoke((System.Delegate)(VB_0024AnonymousDelegate_0<System.Threading.Tasks.Task>)([SpecialName] [CompilerGenerated] [AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__29_002D0))] () =>
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__29_002D0 vB_0024StateMachine___Lambda_0024__29_002D = default(VB_0024StateMachine___Lambda_0024__29_002D0);
			vB_0024StateMachine___Lambda_0024__29_002D._0024VB_0024Me = this;
			vB_0024StateMachine___Lambda_0024__29_002D._0024State = -1;
			vB_0024StateMachine___Lambda_0024__29_002D._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__29_002D._0024Builder.Start<VB_0024StateMachine___Lambda_0024__29_002D0>(ref vB_0024StateMachine___Lambda_0024__29_002D);
			return vB_0024StateMachine___Lambda_0024__29_002D._0024Builder.Task;
		}), new object[0]);
	}

	private void BtnManageBack_Click(object sender, EventArgs e)
	{
		GoBackToParentFolder();
	}

	private void BtnHintBack_Click(object sender, EventArgs e)
	{
		GoBackToParentFolder();
	}

	private void BtnManageOpen_Click(object sender, EventArgs e)
	{
		try
		{
			string text = ((!string.IsNullOrEmpty(CurrentFolderPath)) ? (CurrentFolderPath.EndsWith("\\") ? CurrentFolderPath : (CurrentFolderPath + "\\")) : (PageInstanceLeft.Instance.PathIndie + (PageInstanceLeft.Instance.Version.HasLabyMod ? ("labymod-neo\\fabric\\" + PageInstanceLeft.Instance.Version.McName + "\\") : "") + ModLocalComp.GetPathNameByCompType(CurrentCompType) + "\\"));
			Directory.CreateDirectory(text);
			ModBase.OpenExplorer(text);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "打开 Mods 文件夹失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private void BtnManageSelectAll_Click(object sender, MouseButtonEventArgs e)
	{
		ChangeAllSelected(SelectedMods.Count < ((Panel)PanList).Children.Count);
	}

	private void BtnManageInstall_Click(object sender, MouseButtonEventArgs e)
	{
		string[] array = null;
		switch (CurrentCompType)
		{
		case ModComp.CompType.Mod:
			array = SystemDialogs.SelectFiles("Mod 文件(*.jar;*.litemod;*.disabled;*.old)|*.jar;*.litemod;*.disabled;*.old", "选择要安装的 Mod");
			break;
		case ModComp.CompType.ResourcePack:
			array = SystemDialogs.SelectFiles("资源包文件(*.zip)|*.zip", "选择要安装的资源包");
			break;
		case ModComp.CompType.Shader:
			array = SystemDialogs.SelectFiles("光影包文件(*.zip)|*.zip", "选择要安装的光影包");
			break;
		case ModComp.CompType.Schematic:
			array = SystemDialogs.SelectFiles("投影原理图文件(*.litematic;*.nbt;*.schematic;*.schem)|*.litematic;*.nbt;*.schematic;*.schem", "选择要安装的投影原理图");
			break;
		}
		if (array != null && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)array))
		{
			InstallCompFiles(array, CurrentCompType, CurrentFolderPath);
		}
	}

	public static bool InstallMods(System.Collections.Generic.IEnumerable<string> FilePathList)
	{
		_Closure_0024__36_002D0 arg = default(_Closure_0024__36_002D0);
		_Closure_0024__36_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__36_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Extension = ModBase.AfterLast(Enumerable.First<string>(FilePathList), ".").ToLower();
		if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)new string[] { "jar", "litemod", "disabled", "old" }, (Func<string, bool>)([SpecialName] (string t) => Operators.CompareString(t, CS_0024_003C_003E8__locals0._0024VB_0024Local_Extension, false) == 0)))
		{
			return false;
		}
		ModBase.Log("[System] 文件为 jar/litemod 格式，尝试作为 Mod 安装");
		if (Enumerable.First<string>(FilePathList).Contains(":\\$RECYCLE.BIN\\"))
		{
			ModMain.Hint("请先将文件从回收站还原，再尝试安装！", ModMain.HintType.Critical);
			return true;
		}
		ModMinecraft.McInstance mcInstance = ModMinecraft.McInstanceCurrent;
		if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup)
		{
			mcInstance = PageInstanceLeft.Instance;
		}
		if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSelect || (object)mcInstance == null || !mcInstance.Modable)
		{
			ModMain.Hint("若要安装 Mod，请先选择一个可以安装 Mod 的实例！");
		}
		else if ((ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup && ModMain.FrmMain.PageCurrentSub == FormMain.PageSubType.DownloadResourcePack) || ModMain.MyMsgBox(string.Format("是否要将这{0}文件作为 Mod 安装到 {1}？", (object)((Enumerable.Count<string>(FilePathList) == 1) ? "个" : "些"), (object)mcInstance.Name), "Mod 安装确认", "确定", "取消") == 1)
		{
			string text = mcInstance.PathIndie + (mcInstance.Version.HasLabyMod ? ("labymod-neo\\fabric\\" + mcInstance.Version.McName + "\\") : "") + "mods\\";
			try
			{
				System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
				try
				{
					enumerator = FilePathList.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						string current = enumerator.Current;
						string text2 = ModBase.GetFileNameFromPath(current).Replace(".disabled", "").Replace(".old", "");
						if (!text2.Contains("."))
						{
							text2 += ".jar";
						}
						ModBase.CopyFile(current, text + text2);
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				if (Enumerable.Count<string>(FilePathList) == 1)
				{
					ModMain.Hint(string.Format("已安装 {0}！", (object)ModBase.GetFileNameFromPath(Enumerable.First<string>(FilePathList)).Replace(".disabled", "").Replace(".old", "")), ModMain.HintType.Finish);
				}
				else
				{
					ModMain.Hint($"已安装 {Enumerable.Count<string>(FilePathList)} 个 Mod！", ModMain.HintType.Finish);
				}
				if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup && ModMain.FrmMain.PageCurrentSub == FormMain.PageSubType.DownloadResourcePack)
				{
					ModLoader.LoaderFolderRun(ModLocalComp.CompResourceListLoader, text, ModLoader.LoaderFolderRunType.ForceRun, 0, "", WaitForExit: false, ModMain.FrmInstanceMod?.GetRequireLoaderData());
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "复制 Mod 文件失败", ModBase.LogLevel.Msgbox);
				ProjectData.ClearProjectError();
			}
		}
		return true;
	}

	public static void InstallCompFiles(System.Collections.Generic.IEnumerable<string> FilePathList, ModComp.CompType CompType, string TargetFolderPath = "")
	{
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Expected O, but got Unknown
		if (!Enumerable.Any<string>(FilePathList))
		{
			return;
		}
		string text = ModBase.AfterLast(Enumerable.First<string>(FilePathList), ".").ToLower();
		string[] array = null;
		string text2 = "";
		string text3 = "";
		if (Enumerable.First<string>(FilePathList).Contains(":\\$RECYCLE.BIN\\"))
		{
			ModMain.Hint("请先将文件从回收站还原，再尝试安装！", ModMain.HintType.Critical);
			return;
		}
		ModMinecraft.McInstance mcInstance = ModMinecraft.McInstanceCurrent;
		if (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup)
		{
			mcInstance = PageInstanceLeft.Instance;
		}
		switch (CompType)
		{
		case ModComp.CompType.Mod:
			array = new string[] { "jar", "litemod", "disabled", "old" };
			text2 = "Mod";
			text3 = ((!string.IsNullOrEmpty(TargetFolderPath)) ? (TargetFolderPath + "\\") : (mcInstance.PathIndie + (mcInstance.Version.HasLabyMod ? ("labymod-neo\\fabric\\" + mcInstance.Version.McName + "\\") : "") + "mods\\"));
			break;
		case ModComp.CompType.ResourcePack:
			array = new string[] { "zip" };
			text2 = "资源包";
			text3 = ((!string.IsNullOrEmpty(TargetFolderPath)) ? (TargetFolderPath + "\\") : (mcInstance.PathIndie + "resourcepacks\\"));
			break;
		case ModComp.CompType.Shader:
			array = new string[] { "zip" };
			text2 = "光影包";
			text3 = ((!string.IsNullOrEmpty(TargetFolderPath)) ? (TargetFolderPath + "\\") : (mcInstance.PathIndie + "shaderpacks\\"));
			break;
		case ModComp.CompType.Schematic:
			array = new string[] { "litematic", "nbt", "schematic", "schem" };
			text2 = "投影原理图";
			text3 = ((!string.IsNullOrEmpty(TargetFolderPath)) ? (TargetFolderPath + "\\") : (mcInstance.PathIndie + "schematics\\"));
			break;
		}
		if (!Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)array, text))
		{
			ModMain.Hint(string.Format("不支持的文件格式：{0}，{1}支持的格式：{2}", (object)text, (object)text2, (object)string.Join(", ", array)), ModMain.HintType.Critical);
			return;
		}
		ModBase.Log($"[System] 文件为 {text} 格式，尝试作为{text2}安装");
		if (CompType == ModComp.CompType.Mod && (ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSelect || (object)mcInstance == null || !mcInstance.Modable))
		{
			ModMain.Hint("若要安装 Mod，请先选择一个可以安装 Mod 的实例！");
			return;
		}
		FormMain.PageSubType pageSubType = FormMain.PageSubType.DownloadResourcePack;
		switch (CompType)
		{
		case ModComp.CompType.Mod:
			pageSubType = FormMain.PageSubType.DownloadResourcePack;
			break;
		case ModComp.CompType.ResourcePack:
			pageSubType = FormMain.PageSubType.DownloadWorld;
			break;
		case ModComp.CompType.Shader:
			pageSubType = FormMain.PageSubType.DownloadSchematic;
			break;
		case ModComp.CompType.Schematic:
			pageSubType = FormMain.PageSubType.DownloadCompFavorites;
			break;
		}
		if ((!(ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup) || ModMain.FrmMain.PageCurrentSub != pageSubType) && ModMain.MyMsgBox(string.Format("是否要将这{0}文件作为{1}安装到 {2}？", (object)((Enumerable.Count<string>(FilePathList) == 1) ? "个" : "些"), (object)text2, (object)mcInstance.Name), $"{text2}安装确认", "确定", "取消") != 1)
		{
			return;
		}
		try
		{
			Directory.CreateDirectory(text3);
			System.Collections.Generic.IEnumerator<string> enumerator = default(System.Collections.Generic.IEnumerator<string>);
			try
			{
				enumerator = FilePathList.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					string current = enumerator.Current;
					string text4 = ModBase.GetFileNameFromPath(current);
					if (CompType == ModComp.CompType.Mod)
					{
						text4 = text4.Replace(".disabled", "").Replace(".old", "");
						if (!text4.Contains("."))
						{
							text4 += ".jar";
						}
					}
					string text5 = text3 + text4;
					if (!File.Exists(text5) || ModMain.MyMsgBox($"已存在同名文件：{text4}，是否要覆盖？", "文件覆盖确认", "覆盖", "取消") == 1)
					{
						ModBase.CopyFile(current, text5);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			if (Enumerable.Count<string>(FilePathList) == 1)
			{
				ModMain.Hint($"已安装 {ModBase.GetFileNameFromPath(Enumerable.First<string>(FilePathList))}！", ModMain.HintType.Finish);
			}
			else
			{
				ModMain.Hint($"已安装 {Enumerable.Count<string>(FilePathList)} 个{text2}！", ModMain.HintType.Finish);
			}
			if (!(ModMain.FrmMain.PageCurrent == FormMain.PageType.InstanceSetup) || ModMain.FrmMain.PageCurrentSub != pageSubType)
			{
				return;
			}
			switch (CompType)
			{
			case ModComp.CompType.Mod:
				if (ModMain.FrmInstanceMod != null)
				{
					ModLoader.LoaderFolderRun(ModLocalComp.CompResourceListLoader, text3, ModLoader.LoaderFolderRunType.ForceRun, 0, "", WaitForExit: false, ModMain.FrmInstanceMod?.GetRequireLoaderData());
				}
				break;
			case ModComp.CompType.ResourcePack:
			case ModComp.CompType.Shader:
			case ModComp.CompType.Schematic:
			{
				_Closure_0024__37_002D0 arg = default(_Closure_0024__37_002D0);
				_Closure_0024__37_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__37_002D0(null);
				CS_0024_003C_003E8__locals0._0024VB_0024Local_CurrentForm = GetCurrentCompResourceForm();
				if (CS_0024_003C_003E8__locals0._0024VB_0024Local_CurrentForm != null)
				{
					ModBase.RunInUi((Action)([SpecialName] () =>
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Local_CurrentForm.ReloadCompFileList(ForceReload: true);
					}));
				}
				break;
			}
			case ModComp.CompType.ModPack:
			case ModComp.CompType.DataPack:
			case ModComp.CompType.Plugin:
				break;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, $"复制{text2}文件失败", ModBase.LogLevel.Msgbox);
			ProjectData.ClearProjectError();
		}
	}

	private static PageInstanceCompResource GetCurrentCompResourceForm()
	{
		return ModMain.FrmMain.PageCurrentSub switch
		{
			FormMain.PageSubType.DownloadResourcePack => ModMain.FrmInstanceMod, 
			FormMain.PageSubType.DownloadWorld => ModMain.FrmInstanceResourcePack, 
			FormMain.PageSubType.DownloadSchematic => ModMain.FrmInstanceShader, 
			FormMain.PageSubType.DownloadCompFavorites => ModMain.FrmInstanceSchematic, 
			_ => null, 
		};
	}

	private void BtnManageInfoExport_Click(object sender, MouseButtonEventArgs e)
	{
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		int num = ModMain.MyMsgBox("TXT 格式：仅导出当前的资源文件名称信息，通常足够他人获取已安装的资源信息\r\nCSV 格式：导出详细的资源信息，包括其文件名，工程的 ID，文件内版本信息等详细信息", "选择导出模式", "TXT 格式", "CSV 格式", "取消");
		VB_0024AnonymousDelegate_18<string, string> vB_0024AnonymousDelegate_ = [SpecialName] (string Content, string FileName) =>
		{
			try
			{
				string text = SystemDialogs.SelectSaveFile("选择保存位置", FileName, "文本文件(*.txt)|*.txt|CSV 文件(*.csv)|*.csv");
				if (!string.IsNullOrWhiteSpace(text))
				{
					File.WriteAllText(text, Content, Encoding.UTF8);
					ModBase.OpenExplorer(text);
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "导出资源信息失败", ModBase.LogLevel.Msgbox);
				ProjectData.ClearProjectError();
			}
		};
		switch (num)
		{
		case 1:
		{
			List<string> val2 = new List<string>();
			System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator2 = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
			try
			{
				enumerator2 = ModLocalComp.CompResourceListLoader.Output.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					ModLocalComp.LocalCompFile current2 = enumerator2.Current;
					val2.Add(current2.FileName);
				}
			}
			finally
			{
				((System.IDisposable)enumerator2).Dispose();
			}
			vB_0024AnonymousDelegate_(ModBase.Join((System.Collections.IEnumerable)val2, "\r\n"), PageInstanceLeft.Instance.Name + "已安装的资源信息.txt");
			break;
		}
		case 2:
		{
			List<string> val = new List<string>();
			val.Add("文件名,资源名称,资源版本,此版本更新时间,Mod ID,对应平台工程 ID,文件大小（字节）,文件路径");
			System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
			try
			{
				enumerator = ModLocalComp.CompResourceListLoader.Output.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ModLocalComp.LocalCompFile current = enumerator.Current;
					val.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", new object[8]
					{
						current.FileName,
						current.Comp?.TranslatedName,
						current.Version,
						current.CompFile?.ReleaseDate,
						current.ModId,
						current.Comp?.Id,
						GetModFileInfo(current.Path).Item2,
						current.Path
					}));
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			vB_0024AnonymousDelegate_(ModBase.Join((System.Collections.IEnumerable)val, "\r\n"), PageInstanceLeft.Instance.Name + "已安装的资源信息.csv");
			break;
		}
		}
	}

	private void BtnManageDownload_Click(object sender, MouseButtonEventArgs e)
	{
		switch (CurrentCompType)
		{
		case ModComp.CompType.Mod:
			ModMain.FrmMain.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadMod);
			break;
		case ModComp.CompType.ResourcePack:
			ModMain.FrmMain.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadResourcePack);
			break;
		case ModComp.CompType.Shader:
			ModMain.FrmMain.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadShader);
			break;
		}
		PageComp.TargetVersion = PageInstanceLeft.Instance;
	}

	private void BtnSchematicDownloadMod_Click(object sender, MouseButtonEventArgs e)
	{
		ModMain.FrmMain.PageChange(FormMain.PageType.Download, FormMain.PageSubType.DownloadMod);
		PageComp.TargetVersion = PageInstanceLeft.Instance;
	}

	private void BtnSchematicVersionSelect_Click(object sender, MouseButtonEventArgs e)
	{
		ModMain.FrmMain.PageChange(FormMain.PageType.Launch);
		ModMain.FrmMain.PageChange(FormMain.PageType.InstanceSelect);
	}

	public void CheckChanged(MyLocalCompItem sender, ModBase.RouteEventArgs e)
	{
		if (ModAnimation.AniControlEnabled == 0)
		{
			string rawPath = sender.Entry.RawPath;
			if (sender.Checked)
			{
				SelectedMods.Add(rawPath);
			}
			else
			{
				SelectedMods.Remove(rawPath);
			}
			RefreshBars();
		}
	}

	private void ChangeAllSelected(bool Value)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			ModAnimation.AniControlEnabled++;
			SelectedMods.Clear();
			System.Collections.Generic.IEnumerator<PCL.MyLocalCompItem> enumerator = default(System.Collections.Generic.IEnumerator<PCL.MyLocalCompItem>);
			try
			{
				enumerator = ModItems.Values.GetEnumerator();
				while (enumerator.MoveNext())
				{
					MyLocalCompItem current = enumerator.Current;
					if (current.Checked = Value && ((Panel)PanList).Children.Contains((UIElement)(object)current))
					{
						SelectedMods.Add(current.Entry.RawPath);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			ModAnimation.AniControlEnabled--;
			RefreshBars();
		}
	}

	private void UnselectedAllWithAnimation()
	{
		int aniControlEnabled = ModAnimation.AniControlEnabled;
		ModAnimation.AniControlEnabled = 0;
		ChangeAllSelected(Value: false);
		checked
		{
			ModAnimation.AniControlEnabled += aniControlEnabled;
		}
	}

	private void FrmMain_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		if (ModMain.FrmMain.PageRight == this && (Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)) && (int)e.Key == 44)
		{
			ChangeAllSelected(Value: true);
		}
	}

	private void SearchBox_PreviewKeyDown(object sender, KeyEventArgs e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Invalid comparison between Unknown and I4
		if (!Enumerable.Any<char>((System.Collections.Generic.IEnumerable<char>)SearchBox.Text) && (Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119)) && (int)e.Key == 44)
		{
			((UIElement)PanBack).Focus();
		}
	}

	private bool CanPassFilter(ModLocalComp.LocalCompFile CheckingMod)
	{
		switch (Filter)
		{
		case FilterType.All:
			return true;
		case FilterType.Enabled:
			return CheckingMod.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine;
		case FilterType.Disabled:
			return CheckingMod.State == ModLocalComp.LocalCompFile.LocalFileStatus.Disabled;
		case FilterType.CanUpdate:
			return CheckingMod.CanUpdate;
		case FilterType.Unavailable:
			return CheckingMod.State == ModLocalComp.LocalCompFile.LocalFileStatus.Unavailable;
		case FilterType.Duplicate:
		{
			List<ModLocalComp.LocalCompFile> val = (IsSearching ? SearchResult : (ModLocalComp.CompResourceListLoader.Output ?? new List<ModLocalComp.LocalCompFile>()));
			return val != null && Enumerable.Count<ModLocalComp.LocalCompFile>(Enumerable.Where<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)val, (Func<ModLocalComp.LocalCompFile, bool>)([SpecialName] (ModLocalComp.LocalCompFile m) => (object)CheckingMod.Comp != null && (object)m.Comp != null && Operators.CompareString(CheckingMod.Comp.Id, m.Comp.Id, false) == 0))) > 1;
		}
		default:
			return false;
		}
	}

	private void ChangeFilter(MyRadioButton sender, bool raiseByMouse)
	{
		Filter = (FilterType)Conversions.ToInteger(((FrameworkElement)sender).Tag);
		RefreshUI();
		DoSort();
	}

	private void SetSortMethod(SortMethod Target)
	{
		CurrentSortMethod = Target;
		BtnSort.Text = $"排序：{GetSortName(Target)}";
		DoSort();
	}

	private string GetSortName(SortMethod Method)
	{
		return Method switch
		{
			SortMethod.FileName => "文件名", 
			SortMethod.CompName => "资源名称", 
			SortMethod.TagNums => "标签数量", 
			SortMethod.CreateTime => "加入时间", 
			SortMethod.ModFileSize => "文件大小", 
			_ => "资源名称", 
		};
	}

	private void BtnSortClick(object sender, ModBase.RouteEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		ContextMenu val = new ContextMenu();
		System.Collections.IEnumerator enumerator = System.Enum.GetValues(typeof(SortMethod)).GetEnumerator();
		try
		{
			_Closure_0024__60_002D0 closure_0024__60_002D = default(_Closure_0024__60_002D0);
			while (enumerator.MoveNext())
			{
				closure_0024__60_002D = new _Closure_0024__60_002D0(closure_0024__60_002D);
				closure_0024__60_002D._0024VB_0024Me = this;
				closure_0024__60_002D._0024VB_0024Local_i = (SortMethod)Conversions.ToInteger(enumerator.Current);
				MyMenuItem myMenuItem = new MyMenuItem();
				((HeaderedItemsControl)myMenuItem).Header = GetSortName(closure_0024__60_002D._0024VB_0024Local_i);
				((MenuItem)myMenuItem).Click += new RoutedEventHandler(closure_0024__60_002D._Lambda_0024__R14);
				((ItemsControl)val).Items.Add((object)myMenuItem);
			}
		}
		finally
		{
			System.IDisposable disposable = enumerator as System.IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
		val.PlacementTarget = (UIElement)sender;
		val.Placement = (PlacementMode)2;
		val.IsOpen = true;
	}

	private void DoSort()
	{
		object sortLock = SortLock;
		ObjectFlowControl.CheckForSyncLockOnValueType(sortLock);
		bool flag = false;
		try
		{
			Monitor.Enter(sortLock, ref flag);
			try
			{
				if (PanList != null && ((Panel)PanList).Children.Count >= 2)
				{
					List<MyLocalCompItem> obj = Enumerable.ToList<MyLocalCompItem>(Enumerable.OfType<MyLocalCompItem>((System.Collections.IEnumerable)((Panel)PanList).Children));
					Func<ModLocalComp.LocalCompFile, ModLocalComp.LocalCompFile, int> sortMethod = GetSortMethod(CurrentSortMethod);
					List<MyLocalCompItem> val = Enumerable.ToList<MyLocalCompItem>(Enumerable.Where<MyLocalCompItem>((System.Collections.Generic.IEnumerable<MyLocalCompItem>)obj, (Func<MyLocalCompItem, bool>)([SpecialName] [CompilerGenerated] (MyLocalCompItem i) => i.Entry == null || (CurrentSortMethod == SortMethod.TagNums && (object)i.Entry.Comp == null && !i.Entry.IsFolder))));
					List<MyLocalCompItem> obj2 = Enumerable.ToList<MyLocalCompItem>(Enumerable.Except<MyLocalCompItem>((System.Collections.Generic.IEnumerable<MyLocalCompItem>)obj, (System.Collections.Generic.IEnumerable<MyLocalCompItem>)val));
					obj2.Sort((Comparison<MyLocalCompItem>)([SpecialName] (MyLocalCompItem x, MyLocalCompItem y) => sortMethod.Invoke(x.Entry, y.Entry)));
					List<MyLocalCompItem> obj3 = Enumerable.ToList<MyLocalCompItem>(Enumerable.Concat<MyLocalCompItem>((System.Collections.Generic.IEnumerable<MyLocalCompItem>)obj2, (System.Collections.Generic.IEnumerable<MyLocalCompItem>)val));
					((Panel)PanList).Children.Clear();
					obj3.ForEach((Action<MyLocalCompItem>)([SpecialName] [CompilerGenerated] (MyLocalCompItem i) =>
					{
						((Panel)PanList).Children.Add((UIElement)(object)i);
					}));
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "执行排序时出错", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
			}
		}
		finally
		{
			if (flag)
			{
				Monitor.Exit(sortLock);
			}
		}
	}

	private Func<ModLocalComp.LocalCompFile, ModLocalComp.LocalCompFile, int> GetSortMethod(SortMethod Method)
	{
		VB_0024AnonymousDelegate_19<ModLocalComp.LocalCompFile, ModLocalComp.LocalCompFile, int> vB_0024AnonymousDelegate_ = [SpecialName] (ModLocalComp.LocalCompFile a, ModLocalComp.LocalCompFile b) =>
		{
			if (a.IsFolder && !b.IsFolder)
			{
				return -1;
			}
			return (!a.IsFolder && b.IsFolder) ? 1 : 0;
		};
		return (Func<ModLocalComp.LocalCompFile, ModLocalComp.LocalCompFile, int>)(Method switch
		{
			SortMethod.FileName => (Func<ModLocalComp.LocalCompFile, ModLocalComp.LocalCompFile, int>)([SpecialName] (ModLocalComp.LocalCompFile a, ModLocalComp.LocalCompFile b) =>
			{
				int num6 = vB_0024AnonymousDelegate_(a, b);
				return (num6 != 0) ? num6 : string.Compare(a.FileName, b.FileName, (StringComparison)5);
			}), 
			SortMethod.CompName => (Func<ModLocalComp.LocalCompFile, ModLocalComp.LocalCompFile, int>)([SpecialName] (ModLocalComp.LocalCompFile a, ModLocalComp.LocalCompFile b) =>
			{
				int num5 = vB_0024AnonymousDelegate_(a, b);
				return (num5 != 0) ? num5 : string.Compare(a.Name, b.Name, (StringComparison)5);
			}), 
			SortMethod.TagNums => (Func<ModLocalComp.LocalCompFile, ModLocalComp.LocalCompFile, int>)([SpecialName] (ModLocalComp.LocalCompFile a, ModLocalComp.LocalCompFile b) =>
			{
				int num4 = vB_0024AnonymousDelegate_(a, b);
				if (num4 != 0)
				{
					return num4;
				}
				if (a.IsFolder && b.IsFolder)
				{
					return string.Compare(a.Name, b.Name, (StringComparison)5);
				}
				if (!a.IsFolder && !b.IsFolder)
				{
					int valueOrDefault = (a.Comp?.Tags?.Count).GetValueOrDefault();
					return (b.Comp?.Tags?.Count).GetValueOrDefault().CompareTo(valueOrDefault);
				}
				return string.Compare(a.Name, b.Name, (StringComparison)5);
			}), 
			SortMethod.CreateTime => (Func<ModLocalComp.LocalCompFile, ModLocalComp.LocalCompFile, int>)([SpecialName] (ModLocalComp.LocalCompFile a, ModLocalComp.LocalCompFile b) =>
			{
				//IL_004d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0060: Unknown result type (might be due to invalid IL or missing references)
				int num3 = vB_0024AnonymousDelegate_(a, b);
				if (num3 != 0)
				{
					return num3;
				}
				string path = (a.IsFolder ? a.ActualPath : a.Path);
				string path2 = (b.IsFolder ? b.ActualPath : b.Path);
				System.DateTime item3 = GetModFileInfo(path).Item1;
				System.DateTime item4 = GetModFileInfo(path2).Item1;
				if (System.DateTime.Compare(item3, System.DateTime.MinValue) == 0 && System.DateTime.Compare(item4, System.DateTime.MinValue) == 0)
				{
					return string.Compare(a.Name, b.Name, (StringComparison)5);
				}
				if (System.DateTime.Compare(item3, System.DateTime.MinValue) == 0)
				{
					return 1;
				}
				return (System.DateTime.Compare(item4, System.DateTime.MinValue) == 0) ? (-1) : item4.CompareTo(item3);
			}), 
			SortMethod.ModFileSize => (Func<ModLocalComp.LocalCompFile, ModLocalComp.LocalCompFile, int>)([SpecialName] (ModLocalComp.LocalCompFile a, ModLocalComp.LocalCompFile b) =>
			{
				//IL_005c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0073: Unknown result type (might be due to invalid IL or missing references)
				int num2 = vB_0024AnonymousDelegate_(a, b);
				if (num2 != 0)
				{
					return num2;
				}
				if (a.IsFolder && b.IsFolder)
				{
					return string.Compare(a.Name, b.Name, (StringComparison)5);
				}
				if (!a.IsFolder && !b.IsFolder)
				{
					long item = GetModFileInfo(a.ActualPath).Item2;
					long item2 = GetModFileInfo(b.ActualPath).Item2;
					if (item == 0L && item2 == 0L)
					{
						return string.Compare(a.Name, b.Name, (StringComparison)5);
					}
					if (item == 0L)
					{
						return 1;
					}
					if (item2 == 0L)
					{
						return -1;
					}
					return item2.CompareTo(item);
				}
				return string.Compare(a.Name, b.Name, (StringComparison)5);
			}), 
			_ => (Func<ModLocalComp.LocalCompFile, ModLocalComp.LocalCompFile, int>)([SpecialName] (ModLocalComp.LocalCompFile a, ModLocalComp.LocalCompFile b) =>
			{
				int num = vB_0024AnonymousDelegate_(a, b);
				return (num != 0) ? num : string.Compare(a.Name, b.Name, (StringComparison)5);
			}), 
		});
	}

	private void BtnSelectED_Click(MyIconTextButton sender, ModBase.RouteEventArgs e)
	{
		EDMods((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)Enumerable.ToList<ModLocalComp.LocalCompFile>(Enumerable.Where<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)ModLocalComp.CompResourceListLoader.Output, (Func<ModLocalComp.LocalCompFile, bool>)([SpecialName] [CompilerGenerated] (ModLocalComp.LocalCompFile m) => SelectedMods.Contains(m.RawPath)))), !((DependencyObject)sender).Equals((object)BtnSelectDisable));
		ChangeAllSelected(Value: false);
	}

	[MethodImpl(72)]
	private void EDMods(System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile> ModList, bool IsEnable)
	{
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_0185: Expected O, but got Unknown
		bool flag = true;
		System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
		try
		{
			enumerator = ModList.GetEnumerator();
			_Closure_0024__65_002D0 closure_0024__65_002D = default(_Closure_0024__65_002D0);
			while (((System.Collections.IEnumerator)enumerator).MoveNext())
			{
				ModLocalComp.LocalCompFile current = enumerator.Current;
				closure_0024__65_002D = new _Closure_0024__65_002D0(closure_0024__65_002D);
				closure_0024__65_002D._0024VB_0024Local_ModEntity = current;
				string text = null;
				if (closure_0024__65_002D._0024VB_0024Local_ModEntity.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine && !IsEnable)
				{
					text = closure_0024__65_002D._0024VB_0024Local_ModEntity.Path + (File.Exists(closure_0024__65_002D._0024VB_0024Local_ModEntity.Path + ".old") ? ".old" : ".disabled");
				}
				else
				{
					if (closure_0024__65_002D._0024VB_0024Local_ModEntity.State != ModLocalComp.LocalCompFile.LocalFileStatus.Disabled || !IsEnable)
					{
						continue;
					}
					text = closure_0024__65_002D._0024VB_0024Local_ModEntity.RawPath;
				}
				try
				{
					if (!File.Exists(text))
					{
						goto IL_015f;
					}
					if (File.Exists(closure_0024__65_002D._0024VB_0024Local_ModEntity.Path))
					{
						if (Operators.CompareString(ModBase.GetFileMD5(closure_0024__65_002D._0024VB_0024Local_ModEntity.Path), ModBase.GetFileMD5(text), false) == 0)
						{
							goto IL_015f;
						}
						ModMain.MyMsgBox(string.Format("目前同时存在启用和禁用的两个 Mod 文件：{0} - {1}{2} - {3}{4}{5}注意，这两个文件的内容并不相同。{6}在手动删除或重命名其中一个文件后，才能继续操作。", new object[7]
						{
							"\r\n",
							text,
							"\r\n",
							closure_0024__65_002D._0024VB_0024Local_ModEntity.Path,
							"\r\n",
							"\r\n",
							"\r\n"
						}), "存在文件冲突");
					}
					else
					{
						ModBase.Log("[Mod] Mod 的状态已被切换", ModBase.LogLevel.Debug);
					}
					goto end_IL_0097;
					IL_015f:
					File.Delete(text);
					FileSystem.RenameFile(closure_0024__65_002D._0024VB_0024Local_ModEntity.Path, text);
					goto IL_01fd;
					end_IL_0097:;
				}
				catch (FileNotFoundException val)
				{
					ProjectData.SetProjectError((System.Exception)val);
					FileNotFoundException ex = val;
					ModBase.Log((System.Exception)(object)ex, string.Format("未找到需要重命名的 Mod（{0}）", (object)(closure_0024__65_002D._0024VB_0024Local_ModEntity.Path ?? "null")), ModBase.LogLevel.Feedback);
					ReloadCompFileList(ForceReload: true);
					ProjectData.ClearProjectError();
					return;
				}
				catch (System.Exception ex2)
				{
					ProjectData.SetProjectError(ex2);
					System.Exception ex3 = ex2;
					ModBase.Log(ex3, string.Format("重命名 Mod 失败（{0}）", (object)(closure_0024__65_002D._0024VB_0024Local_ModEntity.Path ?? "null")));
					flag = false;
					ProjectData.ClearProjectError();
					goto IL_01fd;
				}
				continue;
				IL_01fd:
				ModLocalComp.LocalCompFile localCompFile = new ModLocalComp.LocalCompFile(text);
				localCompFile.FromJson(closure_0024__65_002D._0024VB_0024Local_ModEntity.ToJson());
				if (ModLocalComp.CompResourceListLoader.Output.Contains(closure_0024__65_002D._0024VB_0024Local_ModEntity))
				{
					int num = ModLocalComp.CompResourceListLoader.Output.IndexOf(closure_0024__65_002D._0024VB_0024Local_ModEntity);
					ModLocalComp.CompResourceListLoader.Output.RemoveAt(num);
					ModLocalComp.CompResourceListLoader.Output.Insert(num, localCompFile);
				}
				if (SearchResult != null && SearchResult.Contains(closure_0024__65_002D._0024VB_0024Local_ModEntity))
				{
					int num2 = SearchResult.IndexOf(closure_0024__65_002D._0024VB_0024Local_ModEntity);
					SearchResult.Remove(closure_0024__65_002D._0024VB_0024Local_ModEntity);
					SearchResult.Insert(num2, localCompFile);
				}
				try
				{
					MyLocalCompItem myLocalCompItem = BuildLocalCompItem(localCompFile);
					ModItems[closure_0024__65_002D._0024VB_0024Local_ModEntity.RawPath] = myLocalCompItem;
					int num3 = ((Panel)PanList).Children.IndexOf((UIElement)(object)Enumerable.FirstOrDefault<MyLocalCompItem>(Enumerable.OfType<MyLocalCompItem>((System.Collections.IEnumerable)((Panel)PanList).Children), (Func<MyLocalCompItem, bool>)closure_0024__65_002D._Lambda_0024__0));
					if (num3 != -1)
					{
						((Panel)PanList).Children.RemoveAt(num3);
						((Panel)PanList).Children.Insert(num3, (UIElement)(object)myLocalCompItem);
					}
				}
				catch (System.Exception ex4)
				{
					ProjectData.SetProjectError(ex4);
					System.Exception ex5 = ex4;
					ModBase.Log(ex5, $"更新 UI 列表项失败：{closure_0024__65_002D._0024VB_0024Local_ModEntity.FileName}", ModBase.LogLevel.Hint);
					ProjectData.ClearProjectError();
				}
			}
		}
		finally
		{
			((System.IDisposable)enumerator)?.Dispose();
		}
		if (flag)
		{
			RefreshBars();
		}
		else
		{
			ModMain.Hint("由于文件被占用，Mod 的状态切换失败，请尝试关闭正在运行的游戏后再试！", ModMain.HintType.Critical);
			ReloadCompFileList(ForceReload: true);
		}
		LoaderRun(ModLoader.LoaderFolderRunType.UpdateOnly);
	}

	private void BtnSelectUpdate_Click()
	{
		List<ModLocalComp.LocalCompFile> val = Enumerable.ToList<ModLocalComp.LocalCompFile>(Enumerable.Where<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)ModLocalComp.CompResourceListLoader.Output, (Func<ModLocalComp.LocalCompFile, bool>)([SpecialName] [CompilerGenerated] (ModLocalComp.LocalCompFile m) => SelectedMods.Contains(m.RawPath) && m.CanUpdate)));
		if (Enumerable.Any<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)val))
		{
			UpdateResource((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)val);
			ChangeAllSelected(Value: false);
		}
	}

	public void UpdateResource(System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile> ModList)
	{
		_Closure_0024__68_002D0 arg = new _Closure_0024__68_002D0(null);
		arg._0024VB_0024Local_ModList = ModList;
		if (Conversions.ToBoolean((object)(CurrentCompType == ModComp.CompType.Mod && (Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("HintUpdateMod"))) || Enumerable.Count<ModLocalComp.LocalCompFile>(arg._0024VB_0024Local_ModList) >= 15))))
		{
			if (ModMain.MyMsgBox(string.Format("新版本 Mod 可能不兼容旧存档或者其他 Mod，这可能导致游戏崩溃，甚至永久损坏存档！{0}如果你在游玩整合包，请千万不要自行更新 Mod！{1}{2}在更新前，请先备份存档，并检查 Mod 的更新日志。{3}如果更新后出现问题，你也可以在回收站找回更新前的 Mod。", new object[] { "\r\n", "\r\n", "\r\n", "\r\n" }), "Mod 更新警告", "我已了解风险，继续更新", "取消", "", IsWarn: true) != 1)
			{
				return;
			}
			ModBase.Setup.Set("HintUpdateMod", true);
		}
		checked
		{
			try
			{
				_Closure_0024__68_002D1 arg2 = default(_Closure_0024__68_002D1);
				_Closure_0024__68_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__68_002D1(null);
				CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2 = arg;
				CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModList = (System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)Enumerable.ToList<ModLocalComp.LocalCompFile>(CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModList);
				List<ModNet.NetFile> val = new List<ModNet.NetFile>();
				CS_0024_003C_003E8__locals0._0024VB_0024Local_FileCopyList = new Dictionary<string, string>();
				System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
				try
				{
					enumerator = CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModList.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						ModLocalComp.LocalCompFile current = enumerator.Current;
						ModComp.CompFile updateFile = current.UpdateFile;
						if (updateFile.Available)
						{
							string text = current.CompFile.FileName.Replace(".jar", "").Replace(".old", "").Replace(".disabled", "");
							string text2 = current.UpdateFile.FileName.Replace(".jar", "").Replace(".old", "").Replace(".disabled", "");
							List<string> val2 = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)text.Split('-', (StringSplitOptions)0));
							List<string> val3 = Enumerable.ToList<string>((System.Collections.Generic.IEnumerable<string>)text2.Split('-', (StringSplitOptions)0));
							bool flag = false;
							while (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2) && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val3) && Operators.CompareString(Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)val2), Enumerable.First<string>((System.Collections.Generic.IEnumerable<string>)val3), false) == 0)
							{
								val2.RemoveAt(0);
								val3.RemoveAt(0);
								flag = true;
							}
							while (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2) && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val3) && Operators.CompareString(Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)val2), Enumerable.Last<string>((System.Collections.Generic.IEnumerable<string>)val3), false) == 0)
							{
								val2.RemoveAt(val2.Count - 1);
								val3.RemoveAt(val3.Count - 1);
								flag = true;
							}
							if (flag && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2) && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val3))
							{
								text = ModBase.Join((System.Collections.IEnumerable)val2, "-");
								text2 = ModBase.Join((System.Collections.IEnumerable)val3, "-");
							}
							string text3 = ModBase.PathTemp + "DownloadedComp\\" + current.FileName.Replace(text, text2);
							string text4 = ModBase.GetPathFromFullPath(current.Path) + current.FileName.Replace(text, text2);
							val.Add(updateFile.ToNetFile(text3));
							CS_0024_003C_003E8__locals0._0024VB_0024Local_FileCopyList[text3] = text4;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				List<ModLoader.LoaderBase> val4 = new List<ModLoader.LoaderBase>();
				CS_0024_003C_003E8__locals0._0024VB_0024Local_FinishedFileNames = new List<string>();
				val4.Add((ModLoader.LoaderBase)new ModNet.LoaderDownload("下载新版资源文件", val)
				{
					ProgressWeight = (double)Enumerable.Count<ModLocalComp.LocalCompFile>(CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModList) * 1.5
				});
				val4.Add((ModLoader.LoaderBase)new ModLoader.LoaderTask<int, int>("替换旧版资源文件", [SpecialName] (ModLoader.LoaderTask<int, int> a0) =>
				{
					CS_0024_003C_003E8__locals0._Lambda_0024__0();
				}, null, (ThreadPriority)2));
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader = new ModLoader.LoaderCombo<System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>>("资源更新：" + PageInstanceLeft.Instance.Name, (System.Collections.Generic.IEnumerable<ModLoader.LoaderBase>)val4);
				CS_0024_003C_003E8__locals0._0024VB_0024Local_PathMods = PageInstanceLeft.Instance.PathIndie + (PageInstanceLeft.Instance.Version.HasLabyMod ? ("labymod-neo\\fabric\\" + PageInstanceLeft.Instance.Version.McName + "\\") : "") + ModLocalComp.GetPathNameByCompType(CurrentCompType) + "\\";
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.OnStateChanged = [SpecialName] (ModLoader.LoaderBase a0) =>
				{
					CS_0024_003C_003E8__locals0._Lambda_0024__1();
				};
				ModBase.Log($"[CompUpdate] 开始更新 {Enumerable.Count<ModLocalComp.LocalCompFile>(CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_ModList)} 个资源：{CS_0024_003C_003E8__locals0._0024VB_0024Local_PathMods}");
				UpdatingVersions.Add(CS_0024_003C_003E8__locals0._0024VB_0024Local_PathMods);
				CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader.Start();
				ModLoader.LoaderTaskbarAdd(CS_0024_003C_003E8__locals0._0024VB_0024Local_Loader);
				ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
				ModMain.FrmMain.BtnExtraDownload.Ribble();
				ReloadCompFileList(ForceReload: true);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "初始化资源更新失败");
				ProjectData.ClearProjectError();
			}
		}
	}

	private void BtnSelectDelete_Click()
	{
		DeleteMods(Enumerable.Where<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)ModLocalComp.CompResourceListLoader.Output, (Func<ModLocalComp.LocalCompFile, bool>)([SpecialName] [CompilerGenerated] (ModLocalComp.LocalCompFile m) => SelectedMods.Contains(m.RawPath))));
		ChangeAllSelected(Value: false);
	}

	private void DeleteMods(System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile> ModList)
	{
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0125: Expected O, but got Unknown
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Expected O, but got Unknown
		//IL_0314: Expected O, but got Unknown
		try
		{
			bool flag = true;
			bool flag2 = Keyboard.IsKeyDown((Key)116) || Keyboard.IsKeyDown((Key)117);
			ModList = (System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)Enumerable.ToList<ModLocalComp.LocalCompFile>(Enumerable.Select<string, ModLocalComp.LocalCompFile>(Enumerable.Where<string>(Enumerable.Distinct<string>(Enumerable.SelectMany<ModLocalComp.LocalCompFile, string>(ModList, (Func<ModLocalComp.LocalCompFile, System.Collections.Generic.IEnumerable<string>>)([SpecialName] (ModLocalComp.LocalCompFile Target) =>
			{
				if (Target.IsFolder)
				{
					return new string[] { Target.Path };
				}
				return (Target.State == ModLocalComp.LocalCompFile.LocalFileStatus.Fine) ? new string[2]
				{
					Target.Path,
					Target.Path + (File.Exists(Target.Path + ".old") ? ".old" : ".disabled")
				} : new string[] { Target.Path, Target.RawPath };
			}))), (Func<string, bool>)([SpecialName] (string m) => (!ModBase.EndsWithF(m, "\\__FOLDER__", IgnoreCase: true)) ? File.Exists(m) : Directory.Exists(m.Replace("\\__FOLDER__", "")))), (Func<string, ModLocalComp.LocalCompFile>)([SpecialName] (string m) => new ModLocalComp.LocalCompFile(m))));
			System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
			try
			{
				enumerator = ModList.GetEnumerator();
				_Closure_0024__70_002D0 closure_0024__70_002D = default(_Closure_0024__70_002D0);
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					closure_0024__70_002D = new _Closure_0024__70_002D0(closure_0024__70_002D);
					closure_0024__70_002D._0024VB_0024Local_ModEntity = enumerator.Current;
					try
					{
						if (closure_0024__70_002D._0024VB_0024Local_ModEntity.IsFolder)
						{
							if (flag2)
							{
								Directory.Delete(closure_0024__70_002D._0024VB_0024Local_ModEntity.ActualPath, true);
							}
							else
							{
								FileSystem.DeleteDirectory(closure_0024__70_002D._0024VB_0024Local_ModEntity.ActualPath, (UIOption)3, (RecycleOption)3);
							}
						}
						else if (flag2)
						{
							File.Delete(closure_0024__70_002D._0024VB_0024Local_ModEntity.Path);
						}
						else
						{
							FileSystem.DeleteFile(closure_0024__70_002D._0024VB_0024Local_ModEntity.Path, (UIOption)2, (RecycleOption)3);
						}
					}
					catch (OperationCanceledException val)
					{
						ProjectData.SetProjectError((System.Exception)val);
						OperationCanceledException ex = val;
						ModBase.Log((System.Exception)(object)ex, "删除资源被主动取消");
						ReloadCompFileList(ForceReload: true);
						ProjectData.ClearProjectError();
						return;
					}
					catch (System.Exception ex2)
					{
						ProjectData.SetProjectError(ex2);
						System.Exception ex3 = ex2;
						ModBase.Log(ex3, $"删除资源失败（{closure_0024__70_002D._0024VB_0024Local_ModEntity.Path}）", ModBase.LogLevel.Msgbox);
						flag = false;
						ProjectData.ClearProjectError();
					}
					SelectedMods.Remove(closure_0024__70_002D._0024VB_0024Local_ModEntity.RawPath);
					ModLocalComp.CompResourceListLoader.Output.Remove(closure_0024__70_002D._0024VB_0024Local_ModEntity);
					SearchResult?.Remove(closure_0024__70_002D._0024VB_0024Local_ModEntity);
					ModItems.Remove(closure_0024__70_002D._0024VB_0024Local_ModEntity.RawPath);
					int num = ((Panel)PanList).Children.IndexOf((UIElement)(object)Enumerable.FirstOrDefault<MyLocalCompItem>(Enumerable.OfType<MyLocalCompItem>((System.Collections.IEnumerable)((Panel)PanList).Children), (Func<MyLocalCompItem, bool>)closure_0024__70_002D._Lambda_0024__3));
					if (num >= 0)
					{
						((Panel)PanList).Children.RemoveAt(num);
					}
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			RefreshBars();
			if (!flag)
			{
				ModMain.Hint("由于文件被占用，删除失败，请尝试关闭正在运行的游戏后再试！", ModMain.HintType.Critical);
				ReloadCompFileList(ForceReload: true);
			}
			else if (((Panel)PanList).Children.Count == 0)
			{
				ReloadCompFileList(ForceReload: true);
			}
			else
			{
				RefreshBars();
			}
			if (!flag)
			{
				return;
			}
			if (flag2)
			{
				if (Enumerable.Count<ModLocalComp.LocalCompFile>(ModList) == 1)
				{
					ModMain.Hint($"已彻底删除 {Enumerable.Single<ModLocalComp.LocalCompFile>(ModList).FileName}！", ModMain.HintType.Finish);
				}
				else
				{
					ModMain.Hint($"已彻底删除 {Enumerable.Count<ModLocalComp.LocalCompFile>(ModList)} 个项目！", ModMain.HintType.Finish);
				}
			}
			else if (Enumerable.Count<ModLocalComp.LocalCompFile>(ModList) == 1)
			{
				ModMain.Hint($"已将 {Enumerable.Single<ModLocalComp.LocalCompFile>(ModList).FileName} 删除到回收站！", ModMain.HintType.Finish);
			}
			else
			{
				ModMain.Hint($"已将 {Enumerable.Count<ModLocalComp.LocalCompFile>(ModList)} 个项目删除到回收站！", ModMain.HintType.Finish);
			}
		}
		catch (OperationCanceledException val2)
		{
			ProjectData.SetProjectError((System.Exception)val2);
			OperationCanceledException ex4 = val2;
			ModBase.Log((System.Exception)(object)ex4, "删除资源被主动取消");
			ReloadCompFileList(ForceReload: true);
			ProjectData.ClearProjectError();
		}
		catch (System.Exception ex5)
		{
			ProjectData.SetProjectError(ex5);
			System.Exception ex6 = ex5;
			ModBase.Log(ex6, "删除资源出现未知错误", ModBase.LogLevel.Feedback);
			ReloadCompFileList(ForceReload: true);
			ProjectData.ClearProjectError();
		}
		LoaderRun(ModLoader.LoaderFolderRunType.UpdateOnly);
	}

	private void BtnSelectCancel_Click()
	{
		ChangeAllSelected(Value: false);
	}

	private void BtnSelectFavorites_Click(object sender, ModBase.RouteEventArgs e)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		ModComp.CompFavorites.ShowMenu(Enumerable.ToList<ModComp.CompProject>(Enumerable.Select<ModLocalComp.LocalCompFile, ModComp.CompProject>(Enumerable.Where<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)ModLocalComp.CompResourceListLoader.Output, (Func<ModLocalComp.LocalCompFile, bool>)([SpecialName] [CompilerGenerated] (ModLocalComp.LocalCompFile m) => SelectedMods.Contains(m.RawPath) && (object)m.Comp != null)), (Func<ModLocalComp.LocalCompFile, ModComp.CompProject>)([SpecialName] (ModLocalComp.LocalCompFile i) => i.Comp))), (UIElement)sender);
	}

	private void BtnSelectShare_Click()
	{
		ModBase.ClipboardSet(ModComp.CompFavorites.GetShareCode(Enumerable.ToList<string>(Enumerable.Select<ModLocalComp.LocalCompFile, string>(Enumerable.Where<ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModLocalComp.LocalCompFile>)ModLocalComp.CompResourceListLoader.Output, (Func<ModLocalComp.LocalCompFile, bool>)([SpecialName] [CompilerGenerated] (ModLocalComp.LocalCompFile m) => SelectedMods.Contains(m.RawPath) && (object)m.Comp != null)), (Func<ModLocalComp.LocalCompFile, string>)([SpecialName] (ModLocalComp.LocalCompFile i) => i.Comp.Id)))));
		ChangeAllSelected(Value: false);
	}

	public void Info_Click(object sender, EventArgs e)
	{
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			try
			{
				ModLocalComp.LocalCompFile entry = ((MyLocalCompItem)((sender is MyIconButton) ? NewLateBinding.LateGet(sender, (System.Type)null, "Tag", new object[0], (string[])null, (System.Type[])null, (bool[])null) : sender)).Entry;
				bool flag = PageInstanceLeft.Instance.Version.HasLabyMod && PageInstanceLeft.Instance.Modable;
				if (entry.State == ModLocalComp.LocalCompFile.LocalFileStatus.Unavailable)
				{
					ModMain.MyMsgBox("无法读取此资源的信息。\r\n\r\n详细的错误信息：" + entry.FileUnavailableReason.Message, "资源读取失败");
					return;
				}
				if ((object)entry.Comp != null)
				{
					ModMain.FrmMain.PageChange(new FormMain.PageStackData
					{
						Page = FormMain.PageType.CompDetail,
						Additional = new object[5]
						{
							entry.Comp,
							new List<string>(),
							PageInstanceLeft.Instance.Version.McName,
							PageInstanceLeft.Instance.Version.HasForge ? ModComp.CompLoaderType.Forge : (PageInstanceLeft.Instance.Version.HasNeoForge ? ModComp.CompLoaderType.NeoForge : ((PageInstanceLeft.Instance.Version.HasFabric || flag) ? ModComp.CompLoaderType.Fabric : ModComp.CompLoaderType.Any)),
							CurrentCompType
						}
					});
					return;
				}
				if (ModBase.EndsWithF(entry.Path, ".litematic", IgnoreCase: true) || ModBase.EndsWithF(entry.Path, ".schem", IgnoreCase: true) || ModBase.EndsWithF(entry.Path, ".schematic", IgnoreCase: true) || ModBase.EndsWithF(entry.Path, ".nbt", IgnoreCase: true))
				{
					ShowSchematicInfoAsync(entry);
					return;
				}
				List<string> val = new List<string>();
				if (entry.IsFolder)
				{
					string actualPath = entry.ActualPath;
					if (Directory.Exists(actualPath))
					{
						int num = 0;
						try
						{
							num = CurrentCompType switch
							{
								ModComp.CompType.Schematic => Enumerable.Count<FileInfo>(Enumerable.Where<FileInfo>(new DirectoryInfo(actualPath).EnumerateFiles("*", (SearchOption)1), (Func<FileInfo, bool>)([SpecialName] (FileInfo f) => Conversions.ToBoolean(ModLocalComp.LocalCompFile.IsCompFile(((FileSystemInfo)f).FullName, ModComp.CompType.Schematic))))), 
								ModComp.CompType.Mod => Enumerable.Count<FileInfo>(new DirectoryInfo(actualPath).EnumerateFiles("*.jar", (SearchOption)1)), 
								ModComp.CompType.ResourcePack => Enumerable.Count<FileInfo>(new DirectoryInfo(actualPath).EnumerateFiles("*.zip", (SearchOption)1)), 
								ModComp.CompType.Shader => Enumerable.Count<FileInfo>(new DirectoryInfo(actualPath).EnumerateFiles("*.zip", (SearchOption)1)), 
								_ => Enumerable.Count<FileInfo>(new DirectoryInfo(actualPath).EnumerateFiles("*", (SearchOption)1)), 
							};
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							num = 0;
							ProjectData.ClearProjectError();
						}
						switch (num)
						{
						case 0:
							val.Add("空文件夹\r\n");
							break;
						case 1:
							val.Add("包含 1 个文件\r\n");
							break;
						default:
							val.Add($"包含 {num} 个文件" + "\r\n");
							break;
						}
					}
					else
					{
						val.Add("文件夹不存在\r\n");
					}
					val.Add("路径：" + actualPath);
				}
				else
				{
					if (entry.Description != null)
					{
						val.Add(entry.Description + "\r\n");
					}
					if (entry.Authors != null)
					{
						val.Add("作者：" + entry.Authors);
					}
					val.Add(string.Concat(new string[5]
					{
						"文件：",
						entry.FileName,
						"（",
						ModBase.GetString(GetModFileInfo(entry.Path).Item2),
						"）"
					}));
					if (entry.Version != null)
					{
						val.Add("版本：" + entry.Version);
					}
				}
				if (!entry.IsFolder)
				{
					List<string> val2 = new List<string>();
					if (entry.ModId != null)
					{
						val2.Add("Mod ID：" + entry.ModId);
					}
					if (Enumerable.Any<KeyValuePair<string, string>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, string>>)entry.Dependencies))
					{
						val2.Add("依赖于：");
						System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>>);
						try
						{
							enumerator = entry.Dependencies.GetEnumerator();
							while (enumerator.MoveNext())
							{
								KeyValuePair<string, string> current = enumerator.Current;
								val2.Add(" - " + current.Key + ((current.Value == null) ? "" : ("，版本：" + current.Value)));
							}
						}
						finally
						{
							((System.IDisposable)enumerator).Dispose();
						}
					}
					if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val2))
					{
						val.Add("");
						val.AddRange((System.Collections.Generic.IEnumerable<string>)val2);
					}
				}
				if (entry.IsFolder)
				{
					ModMain.MyMsgBox(ModBase.Join((System.Collections.IEnumerable)val, "\r\n"), entry.Name, "返回");
					return;
				}
				string text = entry.Name.Replace(" ", "+");
				string text2 = text.Substring(0, 1);
				int num2 = Enumerable.Count<char>((System.Collections.Generic.IEnumerable<char>)text) - 1;
				for (int i = 1; i <= num2; i++)
				{
					bool num3 = text[i - 1].ToString().ToLower().Equals(text[i - 1].ToString());
					bool flag2 = text[i].ToString().ToLower().Equals(text[i].ToString());
					if (num3 && !flag2)
					{
						text2 += "+";
					}
					text2 += Conversions.ToString(text[i]);
				}
				text2 = text2.Replace("++", "+").Replace("pti+Fine", "ptiFine");
				if (CurrentCompType == ModComp.CompType.Schematic)
				{
					if (entry.Url == null)
					{
						ModMain.MyMsgBox(ModBase.Join((System.Collections.IEnumerable)val, "\r\n"), entry.Name, "返回");
					}
					else if (ModMain.MyMsgBox(ModBase.Join((System.Collections.IEnumerable)val, "\r\n"), entry.Name, "打开官网", "返回") == 1)
					{
						ModBase.OpenWebsite(entry.Url);
					}
					return;
				}
				if (entry.Url == null)
				{
					if (ModMain.MyMsgBox(ModBase.Join((System.Collections.IEnumerable)val, "\r\n"), entry.Name, "百科搜索", "返回") == 1)
					{
						ModBase.OpenWebsite("https://www.mcmod.cn/s?key=" + text2 + "&site=all&filter=0");
					}
					return;
				}
				switch (ModMain.MyMsgBox(ModBase.Join((System.Collections.IEnumerable)val, "\r\n"), entry.Name, "打开官网", "百科搜索", "返回"))
				{
				case 1:
					ModBase.OpenWebsite(entry.Url);
					break;
				case 2:
					ModBase.OpenWebsite("https://www.mcmod.cn/s?key=" + text2 + "&site=all&filter=0");
					break;
				}
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				ModBase.Log(ex4, "获取资源详情失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}
	}

	public void Open_Click(MyIconButton sender, EventArgs e)
	{
		try
		{
			MyLocalCompItem myLocalCompItem = (MyLocalCompItem)((FrameworkElement)sender).Tag;
			ModBase.OpenExplorer(myLocalCompItem.Entry.IsFolder ? myLocalCompItem.Entry.ActualPath : myLocalCompItem.Entry.Path);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "打开资源文件位置失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public void Delete_Click(MyIconButton sender, EventArgs e)
	{
		MyLocalCompItem myLocalCompItem = (MyLocalCompItem)((FrameworkElement)sender).Tag;
		DeleteMods(new ModLocalComp.LocalCompFile[] { myLocalCompItem.Entry });
	}

	public void ED_Click(MyIconButton sender, EventArgs e)
	{
		MyLocalCompItem myLocalCompItem = (MyLocalCompItem)((FrameworkElement)sender).Tag;
		EDMods(new ModLocalComp.LocalCompFile[] { myLocalCompItem.Entry }, myLocalCompItem.Entry.State == ModLocalComp.LocalCompFile.LocalFileStatus.Disabled);
	}

	private void ShowSchematicInfoAsync(ModLocalComp.LocalCompFile ModEntry)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		ModMain.Hint("正在加载详情....");
		Action val = default(Action);
		ModBase.RunInNewThread((Action)([SpecialName] () =>
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			try
			{
				ModEntry.LoadNbtDataIfNeeded();
				Action action;
				if (val != null)
				{
					action = val;
				}
				else
				{
					Action val2 = [SpecialName] () =>
					{
						//IL_008e: Unknown result type (might be due to invalid IL or missing references)
						try
						{
							List<string> val4 = new List<string>();
							if (ModEntry.Description != null)
							{
								val4.Add(ModEntry.Description + "\r\n");
							}
							if (ModEntry.Authors != null)
							{
								val4.Add("作者：" + ModEntry.Authors);
							}
							val4.Add(string.Concat(new string[5]
							{
								"文件：",
								ModEntry.FileName,
								"（",
								ModBase.GetString(GetModFileInfo(ModEntry.Path).Item2),
								"）"
							}));
							if (ModEntry.Version != null)
							{
								val4.Add("版本：" + ModEntry.Version);
							}
							if (ModBase.EndsWithF(ModEntry.Path, ".litematic", IgnoreCase: true))
							{
								ShowLitematicDetails(val4, ModEntry);
							}
							else if (ModBase.EndsWithF(ModEntry.Path, ".schem", IgnoreCase: true))
							{
								ShowSchemDetails(val4, ModEntry);
							}
							else if (ModBase.EndsWithF(ModEntry.Path, ".schematic", IgnoreCase: true))
							{
								ShowSchematicDetails(val4, ModEntry);
							}
							else if (ModBase.EndsWithF(ModEntry.Path, ".nbt", IgnoreCase: true))
							{
								ShowNbtDetails(val4, ModEntry);
							}
							ShowDebugInfo(val4, ModEntry);
							ShowSchematicDialog(val4, ModEntry);
						}
						catch (System.Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							System.Exception ex4 = ex3;
							ModBase.Log(ex4, "显示原理图详情失败", ModBase.LogLevel.Feedback);
							ProjectData.ClearProjectError();
						}
					};
					Action val3 = val2;
					val = val2;
					action = val3;
				}
				ModBase.RunInUi(action);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "加载原理图 NBT 数据失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}), null, (ThreadPriority)2);
	}

	private void ShowLitematicDetails(List<string> ContentLines, ModLocalComp.LocalCompFile ModEntry)
	{
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		ContentLines.Add("");
		ContentLines.Add("详细信息：");
		if (ModEntry.LitematicOriginalName != null)
		{
			ContentLines.Add("原始名称：" + ModEntry.LitematicOriginalName);
		}
		if (ModEntry.LitematicVersion.HasValue)
		{
			ContentLines.Add("原理图版本：" + Conversions.ToString(ModEntry.LitematicVersion.Value));
		}
		if (ModEntry.LitematicEnclosingSize != null)
		{
			ContentLines.Add("包围盒大小：" + ModEntry.LitematicEnclosingSize);
		}
		if (ModEntry.LitematicTotalBlocks.HasValue)
		{
			ContentLines.Add("总方块数：" + ModEntry.LitematicTotalBlocks.Value.ToString("N0"));
		}
		if (ModEntry.LitematicTotalVolume.HasValue)
		{
			ContentLines.Add("总体积：" + ModEntry.LitematicTotalVolume.Value.ToString("N0"));
		}
		if (ModEntry.LitematicRegionCount.HasValue)
		{
			ContentLines.Add("区域数量：" + Conversions.ToString(ModEntry.LitematicRegionCount.Value));
		}
		DateTimeOffset val;
		if (ModEntry.LitematicTimeCreated.HasValue)
		{
			try
			{
				val = DateTimeOffset.FromUnixTimeMilliseconds(ModEntry.LitematicTimeCreated.Value);
				val = val.ToLocalTime();
				ContentLines.Add("创建时间：" + val.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ContentLines.Add("创建时间：" + Conversions.ToString(ModEntry.LitematicTimeCreated.Value));
				ProjectData.ClearProjectError();
			}
		}
		if (ModEntry.LitematicTimeModified.HasValue)
		{
			try
			{
				val = DateTimeOffset.FromUnixTimeMilliseconds(ModEntry.LitematicTimeModified.Value);
				val = val.ToLocalTime();
				ContentLines.Add("修改时间：" + val.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
			}
			catch (System.Exception projectError2)
			{
				ProjectData.SetProjectError(projectError2);
				ContentLines.Add("修改时间：" + Conversions.ToString(ModEntry.LitematicTimeModified.Value));
				ProjectData.ClearProjectError();
			}
		}
	}

	private void ShowSchemDetails(List<string> ContentLines, ModLocalComp.LocalCompFile ModEntry)
	{
		ContentLines.Add("");
		ContentLines.Add("详细信息：");
		if (ModEntry.SchemOriginalName != null)
		{
			ContentLines.Add("原始名称：" + ModEntry.SchemOriginalName);
		}
		if (ModEntry.StructureGameVersion != null)
		{
			ContentLines.Add("游戏版本：" + ModEntry.StructureGameVersion);
		}
		if (ModEntry.SpongeVersion.HasValue)
		{
			ContentLines.Add("Sponge 版本：" + Conversions.ToString(ModEntry.SpongeVersion.Value));
		}
		if (ModEntry.StructureDataVersion.HasValue)
		{
			ContentLines.Add("数据版本：" + Conversions.ToString(ModEntry.StructureDataVersion.Value));
		}
		if (ModEntry.LitematicEnclosingSize != null)
		{
			ContentLines.Add("包围盒尺寸：" + ModEntry.LitematicEnclosingSize);
		}
		if (ModEntry.LitematicTotalBlocks.HasValue)
		{
			ContentLines.Add("总方块数：" + ModEntry.LitematicTotalBlocks.Value.ToString("N0"));
		}
		if (ModEntry.LitematicTotalVolume.HasValue)
		{
			ContentLines.Add("总体积：" + ModEntry.LitematicTotalVolume.Value.ToString("N0"));
		}
		if (ModEntry.LitematicRegionCount.HasValue)
		{
			ContentLines.Add("区域数量：" + Conversions.ToString(ModEntry.LitematicRegionCount.Value));
		}
		ContentLines.Add("文件类型：Sponge Schematic");
	}

	private void ShowSchematicDetails(List<string> ContentLines, ModLocalComp.LocalCompFile ModEntry)
	{
		ContentLines.Add("");
		ContentLines.Add("详细信息：");
		if (ModEntry.LitematicEnclosingSize != null)
		{
			ContentLines.Add("大小：" + ModEntry.LitematicEnclosingSize);
		}
		if (ModEntry.LitematicTotalBlocks.HasValue)
		{
			ContentLines.Add("总方块数：" + ModEntry.LitematicTotalBlocks.Value.ToString("N0"));
		}
		if (ModEntry.LitematicTotalVolume.HasValue)
		{
			ContentLines.Add("总体积：" + ModEntry.LitematicTotalVolume.Value.ToString("N0"));
		}
		ContentLines.Add("文件类型：MCEdit/WorldEdit Schematic");
	}

	private void ShowNbtDetails(List<string> ContentLines, ModLocalComp.LocalCompFile ModEntry)
	{
		ContentLines.Add("");
		ContentLines.Add("详细信息：");
		if (ModEntry.StructureAuthor != null)
		{
			ContentLines.Add("作者：" + ModEntry.StructureAuthor);
		}
		if (ModEntry.StructureGameVersion != null)
		{
			ContentLines.Add("游戏版本：" + ModEntry.StructureGameVersion);
		}
		if (ModEntry.StructureDataVersion.HasValue)
		{
			ContentLines.Add("数据版本：" + Conversions.ToString(ModEntry.StructureDataVersion.Value));
		}
		if (ModEntry.LitematicEnclosingSize != null)
		{
			ContentLines.Add("包围盒尺寸：" + ModEntry.LitematicEnclosingSize);
		}
		if (ModEntry.LitematicTotalBlocks.HasValue)
		{
			ContentLines.Add("总方块数：" + ModEntry.LitematicTotalBlocks.Value.ToString("N0"));
		}
		if (ModEntry.LitematicTotalVolume.HasValue)
		{
			ContentLines.Add("总体积：" + ModEntry.LitematicTotalVolume.Value.ToString("N0"));
		}
		if (ModEntry.LitematicRegionCount.HasValue)
		{
			ContentLines.Add("区域数量：" + Conversions.ToString(ModEntry.LitematicRegionCount.Value));
		}
		ContentLines.Add("文件类型：原版结构");
	}

	private void ShowDebugInfo(List<string> ContentLines, ModLocalComp.LocalCompFile ModEntry)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		List<string> val = new List<string>();
		if (ModEntry.ModId != null)
		{
			val.Add("Mod ID：" + ModEntry.ModId);
		}
		if (Enumerable.Any<KeyValuePair<string, string>>((System.Collections.Generic.IEnumerable<KeyValuePair<string, string>>)ModEntry.Dependencies))
		{
			val.Add("依赖于：");
			System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>> enumerator = default(System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<string, string>>);
			try
			{
				enumerator = ModEntry.Dependencies.GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, string> current = enumerator.Current;
					val.Add(" - " + current.Key + ((current.Value == null) ? "" : ("，版本：" + current.Value)));
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
		}
		if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)val))
		{
			ContentLines.Add("");
			ContentLines.AddRange((System.Collections.Generic.IEnumerable<string>)val);
		}
	}

	private void ShowSchematicDialog(List<string> ContentLines, ModLocalComp.LocalCompFile ModEntry)
	{
		if (ModEntry.Url == null)
		{
			ModMain.MyMsgBox(ModBase.Join((System.Collections.IEnumerable)ContentLines, "\r\n"), ModEntry.Name, "返回");
		}
		else if (ModMain.MyMsgBox(ModBase.Join((System.Collections.IEnumerable)ContentLines, "\r\n"), ModEntry.Name, "打开官网", "返回") == 1)
		{
			ModBase.OpenWebsite(ModEntry.Url);
		}
	}

	public void SearchRun()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (IsSearching)
			{
				List<ModBase.SearchEntry<ModLocalComp.LocalCompFile>> val = new List<ModBase.SearchEntry<ModLocalComp.LocalCompFile>>();
				System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile> enumerator = default(System.Collections.Generic.IEnumerator<ModLocalComp.LocalCompFile>);
				try
				{
					enumerator = ModLocalComp.CompResourceListLoader.Output.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ModLocalComp.LocalCompFile current = enumerator.Current;
						List<KeyValuePair<string, double>> val2 = new List<KeyValuePair<string, double>>();
						val2.Add(new KeyValuePair<string, double>(current.Name, 1.0));
						val2.Add(new KeyValuePair<string, double>(current.FileName, 1.0));
						if (current.Version != null)
						{
							val2.Add(new KeyValuePair<string, double>(current.Version, 0.2));
						}
						if (current.Description != null && Operators.CompareString(current.Description, "", false) != 0)
						{
							val2.Add(new KeyValuePair<string, double>(current.Description, 0.4));
						}
						if ((object)current.Comp != null)
						{
							if (Operators.CompareString(current.Comp.RawName, current.Name, false) != 0)
							{
								val2.Add(new KeyValuePair<string, double>(current.Comp.RawName, 1.0));
							}
							if (Operators.CompareString(current.Comp.TranslatedName, current.Comp.RawName, false) != 0)
							{
								val2.Add(new KeyValuePair<string, double>(current.Comp.TranslatedName, 1.0));
							}
							if (Operators.CompareString(current.Comp.Description, current.Description, false) != 0)
							{
								val2.Add(new KeyValuePair<string, double>(current.Comp.Description, 0.4));
							}
							val2.Add(new KeyValuePair<string, double>(string.Join("", (System.Collections.Generic.IEnumerable<string>)current.Comp.Tags), 0.2));
						}
						val.Add(new ModBase.SearchEntry<ModLocalComp.LocalCompFile>
						{
							Item = current,
							SearchSource = val2
						});
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				SearchResult = Enumerable.ToList<ModLocalComp.LocalCompFile>(Enumerable.Select<ModBase.SearchEntry<ModLocalComp.LocalCompFile>, ModLocalComp.LocalCompFile>((System.Collections.Generic.IEnumerable<ModBase.SearchEntry<ModLocalComp.LocalCompFile>>)ModBase.Search<ModLocalComp.LocalCompFile>(val, SearchBox.Text, 6, 0.35), (Func<ModBase.SearchEntry<ModLocalComp.LocalCompFile>, ModLocalComp.LocalCompFile>)([SpecialName] (ModBase.SearchEntry<ModLocalComp.LocalCompFile> r) => r.Item)));
			}
			RefreshUI();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "搜索过程中发生异常");
			ProjectData.ClearProjectError();
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/pageinstancecompresource.xaml", (UriKind)2);
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
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanAllBack = (Grid)target;
			break;
		case 2:
			PanBack = (MyScrollViewer)target;
			break;
		case 3:
			PanMain = (StackPanel)target;
			break;
		case 4:
			SearchBox = (MySearchBox)target;
			break;
		case 5:
			PanManage = (MyCard)target;
			break;
		case 6:
			BtnManageBack = (MyButton)target;
			break;
		case 7:
			BtnManageOpen = (MyButton)target;
			break;
		case 8:
			BtnManageInstall = (MyButton)target;
			break;
		case 9:
			BtnManageDownload = (MyButton)target;
			break;
		case 10:
			BtnManageSelectAll = (MyButton)target;
			break;
		case 11:
			BtnManageInfoExport = (MyButton)target;
			break;
		case 12:
			BtnManageCheck = (MyButton)target;
			break;
		case 13:
			PanListBack = (MyCard)target;
			break;
		case 14:
			PanFilter = (StackPanel)target;
			break;
		case 15:
			BtnFilterAll = (MyRadioButton)target;
			break;
		case 16:
			BtnFilterEnabled = (MyRadioButton)target;
			break;
		case 17:
			BtnFilterDisabled = (MyRadioButton)target;
			break;
		case 18:
			BtnFilterCanUpdate = (MyRadioButton)target;
			break;
		case 19:
			BtnFilterError = (MyRadioButton)target;
			break;
		case 20:
			BtnFilterDuplicate = (MyRadioButton)target;
			break;
		case 21:
			BtnSort = (MyIconTextButton)target;
			break;
		case 22:
			PanList = (StackPanel)target;
			break;
		case 23:
			PanEmpty = (MyCard)target;
			break;
		case 24:
			TxtEmptyTitle = (TextBlock)target;
			break;
		case 25:
			TxtEmptyDescription = (TextBlock)target;
			break;
		case 26:
			BtnHintBack = (MyButton)target;
			break;
		case 27:
			BtnHintInstall = (MyButton)target;
			break;
		case 28:
			BtnHintDownload = (MyButton)target;
			break;
		case 29:
			BtnHintOpen = (MyButton)target;
			break;
		case 30:
			PanSchematicEmpty = (MyCard)target;
			break;
		case 31:
			BtnSchematicDownloadMod = (MyButton)target;
			break;
		case 32:
			BtnSchematicVersionSelect = (MyButton)target;
			break;
		case 33:
			PanLoad = (MyCard)target;
			break;
		case 34:
			Load = (MyLoading)target;
			break;
		case 35:
			CardSelect = (MyCard)target;
			break;
		case 36:
			TransSelect = (TranslateTransform)target;
			break;
		case 37:
			LabSelect = (TextBlock)target;
			break;
		case 38:
			BtnSelectUpdate = (MyIconTextButton)target;
			break;
		case 39:
			BtnSelectEnable = (MyIconTextButton)target;
			break;
		case 40:
			BtnSelectDisable = (MyIconTextButton)target;
			break;
		case 41:
			BtnSelectFavorites = (MyIconTextButton)target;
			break;
		case 42:
			BtnSelectShare = (MyIconTextButton)target;
			break;
		case 43:
			BtnSelectDelete = (MyIconTextButton)target;
			break;
		case 44:
			BtnSelectCancel = (MyIconTextButton)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
