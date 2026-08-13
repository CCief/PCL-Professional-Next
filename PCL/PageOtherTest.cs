using FileSystem = Microsoft.VisualBasic.FileIO.FileSystem;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Win32;
using PCL.Core.App;
using PCL.Core.IO;
using PCL.Core.Net;
using PCL.Core.UI;
using PCL.Core.Utils.OS;
using PCL.Core.Utils.Secret;

namespace PCL;

[DesignerGenerated]
public class PageOtherTest : MyPageRight, IComponentConnector
{
	[StructLayout(LayoutKind.Sequential)]
	private class TokenPrivileges
	{
		public int PrivilegeCount;

		public LUID Luid;

		public int Attributes;

		public TokenPrivileges()
		{
			PrivilegeCount = 1;
		}
	}

	private struct LUID
	{
		public int LowPart;

		public int HighPart;
	}

	public struct SYSTEM_FILECACHE_INFORMATION
	{
		public nuint CurrentSize;

		public nuint PeakSize;

		public uint PageFaultCount;

		public nuint MinimumWorkingSet;

		public nuint MaximumWorkingSet;

		public nuint CurrentSizeIncludingTransitionInPages;

		public nuint PeakSizeIncludingTransitionInPages;

		public uint TransitionRePurposeCount;

		public uint Flags;
	}

	public struct MEMORY_COMBINE_INFORMATION_EX
	{
		public nint Handle;

		public nuint PagesCombined;

		public uint Flags;
	}

	private struct ThemeEntry
	{
		public string Raw;

		public int? Number;
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_46_BtnAchievementPreview_Click : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal MouseButtonEventArgs _0024VB_0024Local_e;

		internal PageOtherTest _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num != 0)
				{
					string achievementUrl = _0024VB_0024Me.GetAchievementUrl();
					ModBase.Log("[Net] 获取网络结果" + achievementUrl);
					val = _0024VB_0024Me.LoadImageAsync(achievementUrl).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_46_BtnAchievementPreview_Click>(ref val, ref _this);
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

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_47_LoadImageAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_imageUrl;

		internal PageOtherTest _0024VB_0024Me;

		internal _Closure_0024__47_002D1 _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal _Closure_0024__47_002D1 _0024U1;

		internal TaskAwaiter<Stream> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Expected O, but got Unknown
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Invalid comparison between Unknown and I4
			//IL_0116: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Expected O, but got Unknown
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Expected O, but got Unknown
			//IL_0266: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Expected O, but got Unknown
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Unknown result type (might be due to invalid IL or missing references)
			//IL_0248: Expected O, but got Unknown
			int num = _0024State;
			try
			{
				HttpClient client = default(HttpClient);
				if (num != -3 && (uint)num > 1u)
				{
					client = NetworkService.GetClient();
				}
				try
				{
					_Closure_0024__47_002D1 closure_0024__47_002D;
					HttpResponseMessage result;
					TaskAwaiter<HttpResponseMessage> awaiter2;
					Stream result2;
					TaskAwaiter<Stream> awaiter;
					Stream val2;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240 = new _Closure_0024__47_002D1();
						_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Me = _0024VB_0024Me;
						_0024U1 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;
						awaiter2 = client.GetAsync(_0024VB_0024Local_imageUrl).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = awaiter2;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_47_LoadImageAsync>(ref awaiter2, ref _this);
							return;
						}
						goto IL_00cb;
					case 0:
						num = (_0024State = -1);
						awaiter2 = _0024A0;
						_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
						goto IL_00cb;
					case 1:
						{
							num = (_0024State = -1);
							awaiter = _0024A1;
							_0024A1 = default(TaskAwaiter<Stream>);
							goto IL_0167;
						}
						IL_00cb:
						closure_0024__47_002D = _0024U1;
						result = awaiter2.GetResult();
						awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						closure_0024__47_002D._0024VB_0024Local_response = result;
						_0024U1 = null;
						if (_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_response.IsSuccessStatusCode)
						{
							awaiter = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_response.Content.ReadAsStreamAsync().GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_0024State = 1);
								_0024A1 = awaiter;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<Stream>, VB_0024StateMachine_47_LoadImageAsync>(ref awaiter, ref _this);
								return;
							}
							goto IL_0167;
						}
						if ((int)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_response.StatusCode == 404)
						{
							Dispatcher dispatcher = ((DispatcherObject)_0024VB_0024Me).Dispatcher;
							object obj;
							if (_Closure_0024__._0024I47_002D1 != null)
							{
								obj = _Closure_0024__._0024I47_002D1;
							}
							else
							{
								Action val = [SpecialName] () =>
								{
									ModBase.Log("获取成就图片失败（404）");
									ModMain.Hint("获取成就图片失败，请检查文字是否包含特殊字符", ModMain.HintType.Critical);
								};
								_Closure_0024__._0024I47_002D1 = val;
								obj = (object)val;
							}
							dispatcher.Invoke((Action)obj);
						}
						else
						{
							((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
							{
								//IL_000b: Unknown result type (might be due to invalid IL or missing references)
								//IL_0015: Expected I4, but got Unknown
								ModBase.Log("获取成就图片失败（" + Conversions.ToString((int)_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_response.StatusCode) + "）");
							}));
						}
						break;
						IL_0167:
						result2 = awaiter.GetResult();
						awaiter = default(TaskAwaiter<Stream>);
						val2 = result2;
						try
						{
							_Closure_0024__47_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__47_002D0
							{
								_0024VB_0024NonLocal__0024VB_0024Closure_2 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240,
								_0024VB_0024Local_bitmapImage = new BitmapImage()
							};
							CS_0024_003C_003E8__locals0._0024VB_0024Local_bitmapImage.BeginInit();
							CS_0024_003C_003E8__locals0._0024VB_0024Local_bitmapImage.CacheOption = (BitmapCacheOption)1;
							CS_0024_003C_003E8__locals0._0024VB_0024Local_bitmapImage.StreamSource = val2;
							CS_0024_003C_003E8__locals0._0024VB_0024Local_bitmapImage.EndInit();
							((Freezable)CS_0024_003C_003E8__locals0._0024VB_0024Local_bitmapImage).Freeze();
							((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
							{
								CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.AchievementImage.Source = (ImageSource)(object)CS_0024_003C_003E8__locals0._0024VB_0024Local_bitmapImage;
								((UIElement)CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.AchievementImage).Visibility = (Visibility)0;
							}));
						}
						finally
						{
							if (num < 0)
							{
								((System.IDisposable)val2)?.Dispose();
							}
						}
						break;
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					_Closure_0024__47_002D2 CS_0024_003C_003E8__locals1 = new _Closure_0024__47_002D2();
					System.Exception _0024VB_0024Local_ex = ex;
					CS_0024_003C_003E8__locals1._0024VB_0024Local_ex = _0024VB_0024Local_ex;
					((DispatcherObject)_0024VB_0024Me).Dispatcher.Invoke((Action)([SpecialName] () =>
					{
						ModBase.Log(CS_0024_003C_003E8__locals1._0024VB_0024Local_ex, "获取成就图片失败");
					}));
					ProjectData.ClearProjectError();
				}
			}
			catch (System.Exception ex2)
			{
				ProjectData.SetProjectError(ex2);
				System.Exception exception = ex2;
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

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_48_BtnAchievementSave_Click : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal MouseButtonEventArgs _0024VB_0024Local_e;

		internal PageOtherTest _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num != 0)
				{
					string achievementUrl = _0024VB_0024Me.GetAchievementUrl();
					val = _0024VB_0024Me.DownloadImageToLocalAsync(achievementUrl).GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_48_BtnAchievementSave_Click>(ref val, ref _this);
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

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_49_DownloadImageToLocalAsync : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal string _0024VB_0024Local_imageUrl;

		internal PageOtherTest _0024VB_0024Me;

		internal string _0024VB_0024ResumableLocal_savePath_00240;

		internal TaskAwaiter<HttpResponseMessage> _0024A0;

		internal TaskAwaiter<byte[]> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_013e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Invalid comparison between Unknown and I4
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Expected I4, but got Unknown
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				HttpClient client = default(HttpClient);
				if (num != -3 && (uint)num > 1u)
				{
					_0024VB_0024ResumableLocal_savePath_00240 = ModBase.PathTemp + "Download\\" + Conversions.ToString(ModBase.GetHash(_0024VB_0024Local_imageUrl)) + ".png";
					client = NetworkService.GetClient();
				}
				try
				{
					HttpResponseMessage result;
					TaskAwaiter<HttpResponseMessage> awaiter2;
					HttpResponseMessage val;
					byte[] result2;
					TaskAwaiter<byte[]> awaiter;
					byte[] array;
					string text;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						awaiter2 = client.GetAsync(_0024VB_0024Local_imageUrl).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = awaiter2;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<HttpResponseMessage>, VB_0024StateMachine_49_DownloadImageToLocalAsync>(ref awaiter2, ref _this);
							return;
						}
						goto IL_00cd;
					case 0:
						num = (_0024State = -1);
						awaiter2 = _0024A0;
						_0024A0 = default(TaskAwaiter<HttpResponseMessage>);
						goto IL_00cd;
					case 1:
						{
							num = (_0024State = -1);
							awaiter = _0024A1;
							_0024A1 = default(TaskAwaiter<byte[]>);
							goto IL_0144;
						}
						IL_00cd:
						result = awaiter2.GetResult();
						awaiter2 = default(TaskAwaiter<HttpResponseMessage>);
						val = result;
						if (val.IsSuccessStatusCode)
						{
							awaiter = val.Content.ReadAsByteArrayAsync().GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_0024State = 1);
								_0024A1 = awaiter;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<byte[]>, VB_0024StateMachine_49_DownloadImageToLocalAsync>(ref awaiter, ref _this);
								return;
							}
							goto IL_0144;
						}
						if ((int)val.StatusCode == 404)
						{
							ModBase.Log("获取成就图片失败（404）");
							ModMain.Hint("获取成就图片失败，请检查文字是否包含特殊字符", ModMain.HintType.Critical);
						}
						else
						{
							ModBase.Log("获取成就图片失败（" + Conversions.ToString((int)val.StatusCode) + "）");
						}
						break;
						IL_0144:
						result2 = awaiter.GetResult();
						awaiter = default(TaskAwaiter<byte[]>);
						array = result2;
						File.WriteAllBytes(_0024VB_0024ResumableLocal_savePath_00240, array);
						text = SystemDialogs.SelectSaveFile("保存皮肤", ((TextBox)_0024VB_0024Me.AchievementTitleTextBox).Text + ".png", "PNG 图片|*.png");
						if (Operators.CompareString(text, "", false) == 0)
						{
							ModBase.Log("用户取消了保存操作");
							File.Delete(_0024VB_0024ResumableLocal_savePath_00240);
						}
						else
						{
							ModBase.CopyFile(_0024VB_0024ResumableLocal_savePath_00240, text);
							File.Delete(_0024VB_0024ResumableLocal_savePath_00240);
							ModMain.Hint("自定义成就图片已保存！", ModMain.HintType.Finish);
						}
						break;
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "获取成就图片失败");
					ProjectData.ClearProjectError();
				}
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception exception = ex3;
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

		public static Action<ModLoader.LoaderBase> _0024IR6_002D1;

		public static Action _0024I8_002D0;

		public static Action _0024I8_002D2;

		public static Action _0024I8_002D1;

		public static Action _0024I33_002D0;

		public static Action _0024I47_002D1;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__R6_002D1(ModLoader.LoaderBase a0)
		{
			DownloadState((ModLoader.LoaderCombo<int>)a0);
		}

		[SpecialName]
		internal void _Lambda_0024__8_002D0()
		{
			if (!Information.IsNothing((object)ModMain.FrmOtherTest) && !Information.IsNothing((object)ModMain.FrmOtherTest.BtnClear))
			{
				((UIElement)ModMain.FrmOtherTest.BtnClear).IsEnabled = false;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__8_002D1()
		{
			//IL_0464: Unknown result type (might be due to invalid IL or missing references)
			//IL_0469: Unknown result type (might be due to invalid IL or missing references)
			//IL_046f: Expected O, but got Unknown
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Expected O, but got Unknown
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Expected O, but got Unknown
			//IL_0200: Unknown result type (might be due to invalid IL or missing references)
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0404: Expected O, but got Unknown
			checked
			{
				try
				{
					if (!ModWatcher.HasRunningMinecraft && ModLaunch.McLaunchLoader.State != ModBase.LoadState.Loading)
					{
						if (ModNet.HasDownloadingTask())
						{
							ModMain.Hint("请在所有下载任务完成后再来清理吧……");
							return;
						}
						if (!Enumerable.Any<ModMinecraft.McFolder>((System.Collections.Generic.IEnumerable<ModMinecraft.McFolder>)ModMinecraft.McFolderList))
						{
							ModMinecraft.McFolderListLoader.Start();
						}
						ModBase.Log(string.Format("[Test] 当前缓存文件夹：{0}，默认缓存文件夹：{1}", (object)ModBase.PathTemp, (object)Path.Combine(Path.GetTempPath(), "PCL")));
						if (string.Compare(ModBase.PathTemp, Path.Combine(Path.GetTempPath(), "PCL")) == 0)
						{
							if (Operators.ConditionalCompareObjectLessEqual(ModBase.Setup.Get("HintClearRubbish"), (object)2, false))
							{
								if (ModMain.MyMsgBox("即将清理游戏日志、错误报告、缓存等文件。\r\n虽然应该没人往这些地方放重要文件，但还是问一下，是否确认继续？\r\n\r\n在完成清理后，PCL 将自动重启。", "清理确认", "确定", "取消") == 2)
								{
									return;
								}
								ModBase.Setup.Set("HintClearRubbish", Operators.AddObject(ModBase.Setup.Get("HintClearRubbish"), (object)1));
							}
						}
						else if (ModMain.MyMsgBox("即将清理游戏日志、错误报告、缓存等文件。\r\n\r\n你已将缓存文件夹手动修改为：" + ModBase.PathTemp + "\r\n清理过程中，将删除该文件夹中的所有内容，且无法恢复。请确认其中没有除了 PCL 缓存以外的重要文件！\r\n\r\n在完成清理后，PCL 将自动重启。", "清理确认", "确定", "取消") == 2)
						{
							return;
						}
						int num = 0;
						List<DirectoryInfo> val = new List<DirectoryInfo>();
						if (!Enumerable.Any<ModMinecraft.McFolder>((System.Collections.Generic.IEnumerable<ModMinecraft.McFolder>)ModMinecraft.McFolderList))
						{
							ModMinecraft.McFolderListLoader.WaitForExit();
						}
						System.Collections.Generic.IEnumerator<ModMinecraft.McFolder> enumerator = default(System.Collections.Generic.IEnumerator<ModMinecraft.McFolder>);
						try
						{
							enumerator = ModMinecraft.McFolderList.GetEnumerator();
							System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator2 = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
							while (enumerator.MoveNext())
							{
								ModMinecraft.McFolder current = enumerator.Current;
								val.Add(new DirectoryInfo(current.Path));
								DirectoryInfo val2 = new DirectoryInfo(current.Path + "versions");
								if (!val2.Exists)
								{
									continue;
								}
								try
								{
									enumerator2 = val2.EnumerateDirectories().GetEnumerator();
									while (((System.Collections.IEnumerator)enumerator2).MoveNext())
									{
										DirectoryInfo current2 = enumerator2.Current;
										val.Add(current2);
									}
								}
								finally
								{
									((System.IDisposable)enumerator2)?.Dispose();
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator).Dispose();
						}
						System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator3 = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
						try
						{
							enumerator3 = val.GetEnumerator();
							System.Collections.Generic.IEnumerator<FileInfo> enumerator4 = default(System.Collections.Generic.IEnumerator<FileInfo>);
							System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator5 = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
							while (enumerator3.MoveNext())
							{
								DirectoryInfo current3 = enumerator3.Current;
								num += ModBase.DeleteDirectory(((FileSystemInfo)current3).FullName + (((FileSystemInfo)current3).FullName.EndsWith("\\") ? "" : "\\") + "crash-reports\\", IgnoreIssue: true);
								num += ModBase.DeleteDirectory(((FileSystemInfo)current3).FullName + (((FileSystemInfo)current3).FullName.EndsWith("\\") ? "" : "\\") + "logs\\", IgnoreIssue: true);
								try
								{
									enumerator4 = current3.EnumerateFiles("*").GetEnumerator();
									while (((System.Collections.IEnumerator)enumerator4).MoveNext())
									{
										FileInfo current4 = enumerator4.Current;
										if (current4.Name.StartsWith("hs_err_pid") || current4.Name.EndsWith(".log") || Operators.CompareString(current4.Name, "WailaErrorOutput.txt", false) == 0)
										{
											current4.Delete();
											num++;
										}
									}
								}
								finally
								{
									((System.IDisposable)enumerator4)?.Dispose();
								}
								try
								{
									enumerator5 = current3.EnumerateDirectories().GetEnumerator();
									while (((System.Collections.IEnumerator)enumerator5).MoveNext())
									{
										DirectoryInfo current5 = enumerator5.Current;
										if (Operators.CompareString(current5.Name, current5.Name + "-natives", false) == 0 || Operators.CompareString(current5.Name, "natives-windows-x86_64", false) == 0)
										{
											num += ModBase.DeleteDirectory(((FileSystemInfo)current5).FullName, IgnoreIssue: true);
										}
									}
								}
								finally
								{
									((System.IDisposable)enumerator5)?.Dispose();
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator3).Dispose();
						}
						num += ModBase.DeleteDirectory(ModBase.PathTemp, IgnoreIssue: true);
						num += ModBase.DeleteDirectory(ModBase.OsDrive + "ProgramData\\PCL\\", IgnoreIssue: true);
						if (num != 0)
						{
							ModMain.MyMsgBox($"清理了 {num} 个文件！" + "\r\nPCL 即将自动重启……", "缓存已清理", "确定", "", "", IsWarn: false, HighLight: true, ForceWait: true);
							Process.Start(new ProcessStartInfo(ModBase.ExePathWithName));
							FormMain.EndProgramForce();
						}
						else
						{
							ModMain.Hint("没有找到任何可以清理的文件！");
						}
					}
					else
					{
						ModMain.Hint("请先关闭所有运行中的游戏……");
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "清理垃圾失败", ModBase.LogLevel.Hint);
					ProjectData.ClearProjectError();
				}
				finally
				{
					object action;
					if (_0024I8_002D2 != null)
					{
						action = _0024I8_002D2;
					}
					else
					{
						Action val3 = [SpecialName] () =>
						{
							if (!Information.IsNothing((object)ModMain.FrmOtherTest) && !Information.IsNothing((object)ModMain.FrmOtherTest.BtnClear))
							{
								((UIElement)ModMain.FrmOtherTest.BtnClear).IsEnabled = true;
							}
						};
						_0024I8_002D2 = val3;
						action = (object)val3;
					}
					ModBase.RunInUiWait((Action)action);
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__8_002D2()
		{
			if (!Information.IsNothing((object)ModMain.FrmOtherTest) && !Information.IsNothing((object)ModMain.FrmOtherTest.BtnClear))
			{
				((UIElement)ModMain.FrmOtherTest.BtnClear).IsEnabled = true;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__33_002D0()
		{
			MemoryOptimize(ShowHint: true);
		}

		[SpecialName]
		internal void _Lambda_0024__47_002D1()
		{
			ModBase.Log("获取成就图片失败（404）");
			ModMain.Hint("获取成就图片失败，请检查文字是否包含特殊字符", ModMain.HintType.Critical);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__47_002D0
	{
		public BitmapImage _0024VB_0024Local_bitmapImage;

		public _Closure_0024__47_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.AchievementImage.Source = (ImageSource)(object)_0024VB_0024Local_bitmapImage;
			((UIElement)_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.AchievementImage).Visibility = (Visibility)0;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__47_002D1
	{
		public HttpResponseMessage _0024VB_0024Local_response;

		public PageOtherTest _0024VB_0024Me;

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Expected I4, but got Unknown
			ModBase.Log("获取成就图片失败（" + Conversions.ToString((int)_0024VB_0024Local_response.StatusCode) + "）");
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__47_002D2
	{
		public System.Exception _0024VB_0024Local_ex;

		[SpecialName]
		internal void _Lambda_0024__3()
		{
			ModBase.Log(_0024VB_0024Local_ex, "获取成就图片失败");
		}
	}

	private static object IsMemoryOptimizing;

	[CompilerGenerated]
	[AccessedThroughProperty("TextDownloadUrl")]
	private MyTextBox _TextDownloadUrl;

	[CompilerGenerated]
	[AccessedThroughProperty("TextUserAgent")]
	private MyTextBox _TextUserAgent;

	[CompilerGenerated]
	[AccessedThroughProperty("TextDownloadFolder")]
	private MyTextBox _TextDownloadFolder;

	[CompilerGenerated]
	[AccessedThroughProperty("TextDownloadName")]
	private MyTextBox _TextDownloadName;

	[CompilerGenerated]
	[AccessedThroughProperty("BtnSkinSave")]
	private MyButton _BtnSkinSave;

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
	[field: AccessedThroughProperty("BtnClear")]
	internal virtual MyButton BtnClear
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyTextBox TextDownloadUrl
	{
		[CompilerGenerated]
		get
		{
			return _TextDownloadUrl;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyTextBox.ValidateChangedEventHandler obj = TextDownloadUrl_ValidateChanged;
			if (_TextDownloadUrl != null)
			{
				MyTextBox.ValidateChanged -= obj;
			}
			_TextDownloadUrl = value;
			if (_TextDownloadUrl != null)
			{
				MyTextBox.ValidateChanged += obj;
			}
		}
	}

	internal virtual MyTextBox TextUserAgent
	{
		[CompilerGenerated]
		get
		{
			return _TextUserAgent;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler value2 = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				SaveCustomUserAgent();
			});
			MyTextBox textUserAgent = _TextUserAgent;
			if (textUserAgent != null)
			{
				textUserAgent.ValidatedTextChanged -= value2;
			}
			_TextUserAgent = value;
			textUserAgent = _TextUserAgent;
			if (textUserAgent != null)
			{
				textUserAgent.ValidatedTextChanged += value2;
			}
		}
	}

	internal virtual MyTextBox TextDownloadFolder
	{
		[CompilerGenerated]
		get
		{
			return _TextDownloadFolder;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			RoutedEventHandler value2 = (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object a0, RoutedEventArgs a1) =>
			{
				SaveCacheDownloadFolder();
			});
			MyTextBox.ValidateChangedEventHandler obj = TextDownloadFolder_ValidateChanged;
			MyTextBox textDownloadFolder = _TextDownloadFolder;
			if (textDownloadFolder != null)
			{
				textDownloadFolder.ValidatedTextChanged -= value2;
				MyTextBox.ValidateChanged -= obj;
			}
			_TextDownloadFolder = value;
			textDownloadFolder = _TextDownloadFolder;
			if (textDownloadFolder != null)
			{
				textDownloadFolder.ValidatedTextChanged += value2;
				MyTextBox.ValidateChanged += obj;
			}
		}
	}

	internal virtual MyTextBox TextDownloadName
	{
		[CompilerGenerated]
		get
		{
			return _TextDownloadName;
		}
		[MethodImpl(32)]
		[CompilerGenerated]
		set
		{
			MyTextBox.ValidateChangedEventHandler obj = TextDownloadName_ValidateChanged;
			if (_TextDownloadName != null)
			{
				MyTextBox.ValidateChanged -= obj;
			}
			_TextDownloadName = value;
			if (_TextDownloadName != null)
			{
				MyTextBox.ValidateChanged += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnDownloadStart")]
	internal virtual MyButton BtnDownloadStart
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnDownloadOpen")]
	internal virtual MyButton BtnDownloadOpen
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("CardSkin")]
	internal virtual MyCard CardSkin
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("PanSkinID")]
	internal virtual Grid PanSkinID
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("TextSkinID")]
	internal virtual MyTextBox TextSkinID
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	internal virtual MyButton BtnSkinSave
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
			MyButton.ClickEventHandler obj = BtnSkinSave_Click;
			MyButton btnSkinSave = _BtnSkinSave;
			if (btnSkinSave != null)
			{
				btnSkinSave.Click -= obj;
			}
			_BtnSkinSave = value;
			btnSkinSave = _BtnSkinSave;
			if (btnSkinSave != null)
			{
				btnSkinSave.Click += obj;
			}
		}
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("AchievementBlockTextBox")]
	internal virtual MyTextBox AchievementBlockTextBox
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("AchievementTitleTextBox")]
	internal virtual MyTextBox AchievementTitleTextBox
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("AchievementString1TextBox")]
	internal virtual MyTextBox AchievementString1TextBox
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("AchievementString2TextBox")]
	internal virtual MyTextBox AchievementString2TextBox
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnAchievementPreview")]
	internal virtual MyButton BtnAchievementPreview
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("BtnAchievementSave")]
	internal virtual MyButton BtnAchievementSave
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	[field: CompilerGenerated]
	[field: AccessedThroughProperty("AchievementImage")]
	internal virtual Image AchievementImage
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageOtherTest()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += (RoutedEventHandler)([SpecialName] [CompilerGenerated] (object sender, RoutedEventArgs e) =>
		{
			MeLoaded();
		});
		InitializeComponent();
	}

	private void MeLoaded()
	{
		((UIElement)BtnDownloadStart).IsEnabled = false;
		((TextBox)TextDownloadFolder).Text = Conversions.ToString(ModBase.Setup.Get("CacheDownloadFolder"));
		TextDownloadFolder.Validate();
		if (!string.IsNullOrEmpty(TextDownloadFolder.ValidateResult) || string.IsNullOrEmpty(((TextBox)TextDownloadFolder).Text))
		{
			((TextBox)TextDownloadFolder).Text = ModBase.ExePath + "PCL\\MyDownload\\";
		}
		TextDownloadFolder.Validate();
		TextDownloadName.Validate();
		((TextBox)TextUserAgent).Text = Conversions.ToString(ModBase.Setup.Get("ToolDownloadCustomUserAgent"));
	}

	private void StartButtonRefresh()
	{
		((UIElement)BtnDownloadStart).IsEnabled = string.IsNullOrEmpty(TextDownloadFolder.ValidateResult) && string.IsNullOrEmpty(TextDownloadUrl.ValidateResult) && string.IsNullOrEmpty(TextDownloadName.ValidateResult);
		((UIElement)BtnDownloadOpen).IsEnabled = string.IsNullOrEmpty(TextDownloadFolder.ValidateResult);
		((UIElement)BtnAchievementPreview).IsEnabled = string.IsNullOrEmpty(AchievementBlockTextBox.ValidateResult) && string.IsNullOrEmpty(AchievementTitleTextBox.ValidateResult) && string.IsNullOrEmpty(AchievementString1TextBox.ValidateResult);
		((UIElement)BtnAchievementSave).IsEnabled = string.IsNullOrEmpty(AchievementBlockTextBox.ValidateResult) && string.IsNullOrEmpty(AchievementTitleTextBox.ValidateResult) && string.IsNullOrEmpty(AchievementString1TextBox.ValidateResult);
	}

	private void SaveCacheDownloadFolder()
	{
		ModBase.Setup.Set("CacheDownloadFolder", ((TextBox)TextDownloadFolder).Text);
		TextDownloadName.Validate();
	}

	private void SaveCustomUserAgent()
	{
		ModBase.Setup.Set("ToolDownloadCustomUserAgent", ((TextBox)TextUserAgent).Text);
	}

	private static void DownloadState(ModLoader.LoaderCombo<int> Loader)
	{
		try
		{
			switch (Loader.State)
			{
			case ModBase.LoadState.Finished:
				ModMain.Hint(Loader.Name + "完成！", ModMain.HintType.Finish);
				Interaction.Beep();
				break;
			case ModBase.LoadState.Failed:
				ModBase.Log(Loader.Error, Loader.Name + "失败", ModBase.LogLevel.Msgbox);
				Interaction.Beep();
				break;
			case ModBase.LoadState.Aborted:
				ModMain.Hint(Loader.Name + "已取消！");
				break;
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
	}

	public static void StartCustomDownload(string Url, string FileName, string Folder = null, string UserAgent = "")
	{
		try
		{
			if (string.IsNullOrWhiteSpace(Folder))
			{
				Folder = SystemDialogs.SelectSaveFile("选择文件保存位置", FileName);
				if (!Folder.Contains("\\"))
				{
					return;
				}
				if (Folder.EndsWith(FileName))
				{
					Folder = Strings.Mid(Folder, 1, checked(Folder.Length - FileName.Length));
				}
			}
			Folder = Folder.Replace("/", "\\").TrimEnd(new char[] { '\\' }) + "\\";
			try
			{
				Directory.CreateDirectory(Folder);
				ModBase.CheckPermissionWithException(Folder);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "访问文件夹失败（" + Folder + "）", ModBase.LogLevel.Hint);
				ProjectData.ClearProjectError();
				return;
			}
			ModBase.Log("[Download] 自定义下载文件名：" + FileName);
			ModBase.Log("[Download] 自定义下载文件目标：" + Folder);
			int uuid = ModBase.GetUuid();
			ModLoader.LoaderBase loaderBase;
			if (string.IsNullOrEmpty(new ValidateHttp().ValidateText(Url)))
			{
				string name = "自定义下载文件：" + FileName + " ";
				List<ModNet.NetFile> val = new List<ModNet.NetFile>();
				val.Add(new ModNet.NetFile(new string[] { Url }, Folder + FileName, null, UseBrowserUserAgent: true, UserAgent));
				loaderBase = new ModNet.LoaderDownload(name, val);
			}
			else
			{
				loaderBase = new ModNet.LoaderDownloadUnc("自定义下载文件：" + FileName + " ", new Tuple<string, string>(Url, Folder + FileName));
			}
			ModLoader.LoaderCombo<int> loaderCombo = new ModLoader.LoaderCombo<int>("自定义下载 (" + uuid + ") ", new ModLoader.LoaderBase[] { loaderBase });
			loaderCombo.OnStateChanged = [SpecialName] (ModLoader.LoaderBase a0) =>
			{
				DownloadState((ModLoader.LoaderCombo<int>)a0);
			};
			loaderCombo.Start();
			ModLoader.LoaderTaskbarAdd(loaderCombo);
			ModMain.FrmMain.BtnExtraDownload.ShowRefresh();
			ModMain.FrmMain.BtnExtraDownload.Ribble();
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			ModBase.Log(ex4, "开始自定义下载失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public static void Jrrp()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		int num = new Random(GenerateDailySeed()).Next(0, 101);
		string rating = GetRating(num);
		string text = System.DateTime.Now.ToString("yyyy/MM/dd");
		string title = $"今日人品 - {text}";
		if (num >= 60)
		{
			ModMain.MyMsgBox($"你今天的人品值是：{num}！{rating}", title);
		}
		else
		{
			ModMain.MyMsgBox($"你今天的人品值是：{num}... {rating}", title, "确定", "", "", num <= 30);
		}
	}

	public static void RubbishClear()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I8_002D0 != null)
		{
			action = _Closure_0024__._0024I8_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				if (!Information.IsNothing((object)ModMain.FrmOtherTest) && !Information.IsNothing((object)ModMain.FrmOtherTest.BtnClear))
				{
					((UIElement)ModMain.FrmOtherTest.BtnClear).IsEnabled = false;
				}
			};
			_Closure_0024__._0024I8_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
		object action2;
		if (_Closure_0024__._0024I8_002D1 != null)
		{
			action2 = _Closure_0024__._0024I8_002D1;
		}
		else
		{
			Action val2 = checked([SpecialName] () =>
			{
				//IL_0464: Unknown result type (might be due to invalid IL or missing references)
				//IL_0469: Unknown result type (might be due to invalid IL or missing references)
				//IL_046f: Expected O, but got Unknown
				//IL_016c: Unknown result type (might be due to invalid IL or missing references)
				//IL_0171: Unknown result type (might be due to invalid IL or missing references)
				//IL_0183: Unknown result type (might be due to invalid IL or missing references)
				//IL_018d: Expected O, but got Unknown
				//IL_019d: Unknown result type (might be due to invalid IL or missing references)
				//IL_01a4: Expected O, but got Unknown
				//IL_0200: Unknown result type (might be due to invalid IL or missing references)
				//IL_0205: Unknown result type (might be due to invalid IL or missing references)
				//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
				//IL_0404: Expected O, but got Unknown
				try
				{
					if (!ModWatcher.HasRunningMinecraft && ModLaunch.McLaunchLoader.State != ModBase.LoadState.Loading)
					{
						if (ModNet.HasDownloadingTask())
						{
							ModMain.Hint("请在所有下载任务完成后再来清理吧……");
						}
						else
						{
							if (!Enumerable.Any<ModMinecraft.McFolder>((System.Collections.Generic.IEnumerable<ModMinecraft.McFolder>)ModMinecraft.McFolderList))
							{
								ModMinecraft.McFolderListLoader.Start();
							}
							ModBase.Log(string.Format("[Test] 当前缓存文件夹：{0}，默认缓存文件夹：{1}", (object)ModBase.PathTemp, (object)Path.Combine(Path.GetTempPath(), "PCL")));
							if (string.Compare(ModBase.PathTemp, Path.Combine(Path.GetTempPath(), "PCL")) == 0)
							{
								if (Operators.ConditionalCompareObjectLessEqual(ModBase.Setup.Get("HintClearRubbish"), (object)2, false))
								{
									if (ModMain.MyMsgBox("即将清理游戏日志、错误报告、缓存等文件。\r\n虽然应该没人往这些地方放重要文件，但还是问一下，是否确认继续？\r\n\r\n在完成清理后，PCL 将自动重启。", "清理确认", "确定", "取消") == 2)
									{
										return;
									}
									ModBase.Setup.Set("HintClearRubbish", Operators.AddObject(ModBase.Setup.Get("HintClearRubbish"), (object)1));
								}
							}
							else if (ModMain.MyMsgBox("即将清理游戏日志、错误报告、缓存等文件。\r\n\r\n你已将缓存文件夹手动修改为：" + ModBase.PathTemp + "\r\n清理过程中，将删除该文件夹中的所有内容，且无法恢复。请确认其中没有除了 PCL 缓存以外的重要文件！\r\n\r\n在完成清理后，PCL 将自动重启。", "清理确认", "确定", "取消") == 2)
							{
								return;
							}
							int num = 0;
							List<DirectoryInfo> val3 = new List<DirectoryInfo>();
							if (!Enumerable.Any<ModMinecraft.McFolder>((System.Collections.Generic.IEnumerable<ModMinecraft.McFolder>)ModMinecraft.McFolderList))
							{
								ModMinecraft.McFolderListLoader.WaitForExit();
							}
							System.Collections.Generic.IEnumerator<ModMinecraft.McFolder> enumerator = default(System.Collections.Generic.IEnumerator<ModMinecraft.McFolder>);
							try
							{
								enumerator = ModMinecraft.McFolderList.GetEnumerator();
								System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator2 = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
								while (enumerator.MoveNext())
								{
									ModMinecraft.McFolder current = enumerator.Current;
									val3.Add(new DirectoryInfo(current.Path));
									DirectoryInfo val4 = new DirectoryInfo(current.Path + "versions");
									if (val4.Exists)
									{
										try
										{
											enumerator2 = val4.EnumerateDirectories().GetEnumerator();
											while (((System.Collections.IEnumerator)enumerator2).MoveNext())
											{
												DirectoryInfo current2 = enumerator2.Current;
												val3.Add(current2);
											}
										}
										finally
										{
											((System.IDisposable)enumerator2)?.Dispose();
										}
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator).Dispose();
							}
							System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator3 = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
							try
							{
								enumerator3 = val3.GetEnumerator();
								System.Collections.Generic.IEnumerator<FileInfo> enumerator4 = default(System.Collections.Generic.IEnumerator<FileInfo>);
								System.Collections.Generic.IEnumerator<DirectoryInfo> enumerator5 = default(System.Collections.Generic.IEnumerator<DirectoryInfo>);
								while (enumerator3.MoveNext())
								{
									DirectoryInfo current3 = enumerator3.Current;
									num += ModBase.DeleteDirectory(((FileSystemInfo)current3).FullName + (((FileSystemInfo)current3).FullName.EndsWith("\\") ? "" : "\\") + "crash-reports\\", IgnoreIssue: true);
									num += ModBase.DeleteDirectory(((FileSystemInfo)current3).FullName + (((FileSystemInfo)current3).FullName.EndsWith("\\") ? "" : "\\") + "logs\\", IgnoreIssue: true);
									try
									{
										enumerator4 = current3.EnumerateFiles("*").GetEnumerator();
										while (((System.Collections.IEnumerator)enumerator4).MoveNext())
										{
											FileInfo current4 = enumerator4.Current;
											if (current4.Name.StartsWith("hs_err_pid") || current4.Name.EndsWith(".log") || Operators.CompareString(current4.Name, "WailaErrorOutput.txt", false) == 0)
											{
												current4.Delete();
												num++;
											}
										}
									}
									finally
									{
										((System.IDisposable)enumerator4)?.Dispose();
									}
									try
									{
										enumerator5 = current3.EnumerateDirectories().GetEnumerator();
										while (((System.Collections.IEnumerator)enumerator5).MoveNext())
										{
											DirectoryInfo current5 = enumerator5.Current;
											if (Operators.CompareString(current5.Name, current5.Name + "-natives", false) == 0 || Operators.CompareString(current5.Name, "natives-windows-x86_64", false) == 0)
											{
												num += ModBase.DeleteDirectory(((FileSystemInfo)current5).FullName, IgnoreIssue: true);
											}
										}
									}
									finally
									{
										((System.IDisposable)enumerator5)?.Dispose();
									}
								}
							}
							finally
							{
								((System.IDisposable)enumerator3).Dispose();
							}
							num += ModBase.DeleteDirectory(ModBase.PathTemp, IgnoreIssue: true);
							num += ModBase.DeleteDirectory(ModBase.OsDrive + "ProgramData\\PCL\\", IgnoreIssue: true);
							if (num != 0)
							{
								ModMain.MyMsgBox($"清理了 {num} 个文件！" + "\r\nPCL 即将自动重启……", "缓存已清理", "确定", "", "", IsWarn: false, HighLight: true, ForceWait: true);
								Process.Start(new ProcessStartInfo(ModBase.ExePathWithName));
								FormMain.EndProgramForce();
							}
							else
							{
								ModMain.Hint("没有找到任何可以清理的文件！");
							}
						}
					}
					else
					{
						ModMain.Hint("请先关闭所有运行中的游戏……");
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "清理垃圾失败", ModBase.LogLevel.Hint);
					ProjectData.ClearProjectError();
				}
				finally
				{
					object action3;
					if (_Closure_0024__._0024I8_002D2 != null)
					{
						action3 = _Closure_0024__._0024I8_002D2;
					}
					else
					{
						Action val5 = [SpecialName] () =>
						{
							if (!Information.IsNothing((object)ModMain.FrmOtherTest) && !Information.IsNothing((object)ModMain.FrmOtherTest.BtnClear))
							{
								((UIElement)ModMain.FrmOtherTest.BtnClear).IsEnabled = true;
							}
						};
						_Closure_0024__._0024I8_002D2 = val5;
						action3 = (object)val5;
					}
					ModBase.RunInUiWait((Action)action3);
				}
			});
			_Closure_0024__._0024I8_002D1 = val2;
			action2 = (object)val2;
		}
		ModBase.RunInNewThread((Action)action2, "Rubbish Clear", (ThreadPriority)2);
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern nint GetCurrentProcess();

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool CloseHandle(nint handle);

	[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool OpenProcessToken(HandleRef ProcessHandle, int DesiredAccess, out nint TokenHandle);

	[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool LookupPrivilegeValue([MarshalAs(22)] string lpSystemName, [MarshalAs(22)] string lpName, out LUID lpLuid);

	[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool AdjustTokenPrivileges(HandleRef TokenHandle, bool DisableAllPrivileges, TokenPrivileges NewState, int BufferLength, nint PreviousState, nint ReturnLength);

	[DllImport("ntdll.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern uint NtSetSystemInformation(int SystemInformationClass, nint SystemInformation, int SystemInformationLength);

	public static void MemoryOptimize(bool ShowHint)
	{
		if (Conversions.ToBoolean(IsMemoryOptimizing))
		{
			if (ShowHint)
			{
				ModMain.Hint("内存优化尚未结束，请稍等！");
			}
			return;
		}
		IsMemoryOptimizing = true;
		checked
		{
			long num;
			if (ProcessInterop.IsAdmin())
			{
				num = (long)KernelInterop.GetAvailablePhysicalMemoryBytes();
				try
				{
					MemoryOptimizeInternal(ShowHint);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "内存优化失败", ShowHint ? ModBase.LogLevel.Hint : ModBase.LogLevel.Debug);
					ProjectData.ClearProjectError();
					return;
				}
				finally
				{
					IsMemoryOptimizing = false;
				}
				num = Convert.ToInt64(decimal.Subtract(new decimal(KernelInterop.GetAvailablePhysicalMemoryBytes()), new decimal(num)));
			}
			else
			{
				ModBase.Log("[Test] 没有管理员权限，将以命令行方式进行内存优化");
				try
				{
					num = unchecked((long)ProcessInterop.StartAsAdmin("--memory").ExitCode) * 1024L;
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, "命令行形式内存优化失败");
					if (ShowHint)
					{
						ModMain.Hint(string.Concat(new string[5]
						{
							"获取管理员权限失败，请尝试右键 PCL，选择 ",
							Conversions.ToString(ModBase.vbLQ),
							"以管理员身份运行",
							Conversions.ToString(ModBase.vbRQ),
							"！"
						}), ModMain.HintType.Critical);
					}
					ProjectData.ClearProjectError();
					return;
				}
				finally
				{
					IsMemoryOptimizing = false;
				}
				if (num < 0)
				{
					return;
				}
			}
			string @string = ModBase.GetString((long)KernelInterop.GetAvailablePhysicalMemoryBytes());
			ModBase.Log($"[Test] 内存优化完成，可用内存改变量：{ModBase.GetString(num)}，大致剩余内存：{@string}");
			if (num > 0)
			{
				if (ShowHint)
				{
					ModMain.Hint($"内存优化完成，可用内存增加了 {ModBase.GetString((long)Math.Round((double)num * 0.8))}，目前剩余内存 {@string}！", ModMain.HintType.Finish);
				}
			}
			else if (ShowHint)
			{
				ModMain.Hint($"内存优化完成，已经优化到了最佳状态，目前剩余内存 {@string}！");
			}
		}
	}

	public static void MemoryOptimizeInternal(bool ShowHint)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Unknown result type (might be due to invalid IL or missing references)
		if (!ProcessInterop.IsAdmin())
		{
			throw new System.Exception("内存优化功能需要管理员权限！\r\n如果需要自动以管理员身份启动 PCL，可以右键 PCL，打开 属性 → 兼容性 → 以管理员身份运行此程序。");
		}
		ModBase.Log("[Test] 获取内存优化权限");
		try
		{
			nint currentProcess = GetCurrentProcess();
			LUID lpLuid = default(LUID);
			LUID lpLuid2 = default(LUID);
			nint TokenHandle = (System.IntPtr)0;
			if (OpenProcessToken(new HandleRef((object)null, (System.IntPtr)currentProcess), 32, out TokenHandle))
			{
				LookupPrivilegeValue(null, "SeProfileSingleProcessPrivilege", out lpLuid);
				LookupPrivilegeValue(null, "SeIncreaseQuotaPrivilege", out lpLuid2);
				TokenPrivileges tokenPrivileges = new TokenPrivileges();
				tokenPrivileges.Luid = lpLuid;
				tokenPrivileges.Attributes = 2;
				TokenPrivileges tokenPrivileges2 = new TokenPrivileges();
				tokenPrivileges2.Luid = lpLuid2;
				tokenPrivileges2.Attributes = 2;
				AdjustTokenPrivileges(new HandleRef((object)null, (System.IntPtr)TokenHandle), DisableAllPrivileges: false, tokenPrivileges, 0, System.IntPtr.Zero, System.IntPtr.Zero);
				AdjustTokenPrivileges(new HandleRef((object)null, (System.IntPtr)TokenHandle), DisableAllPrivileges: false, tokenPrivileges2, 0, System.IntPtr.Zero, System.IntPtr.Zero);
				CloseHandle(TokenHandle);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			throw new System.Exception($"获取内存优化权限失败（错误代码：{Marshal.GetLastWin32Error()}）");
		}
		if (ShowHint)
		{
			ModMain.Hint("正在进行内存优化……");
		}
		string text = "None";
		try
		{
			text = "MemoryEmptyWorkingSets";
			int num = 2;
			GCHandle val = GCHandle.Alloc((object)num, (GCHandleType)3);
			NtSetSystemInformation(80, val.AddrOfPinnedObject(), Marshal.SizeOf<int>(num));
			val.Free();
			text = "SystemFileCacheInformation";
			SYSTEM_FILECACHE_INFORMATION sYSTEM_FILECACHE_INFORMATION = default(SYSTEM_FILECACHE_INFORMATION);
			sYSTEM_FILECACHE_INFORMATION.MaximumWorkingSet = (System.UIntPtr)4294967295u;
			sYSTEM_FILECACHE_INFORMATION.MinimumWorkingSet = (System.UIntPtr)4294967295u;
			val = GCHandle.Alloc((object)sYSTEM_FILECACHE_INFORMATION, (GCHandleType)3);
			NtSetSystemInformation(81, val.AddrOfPinnedObject(), Marshal.SizeOf<SYSTEM_FILECACHE_INFORMATION>(sYSTEM_FILECACHE_INFORMATION));
			val.Free();
			text = "MemoryFlushModifiedList";
			num = 3;
			val = GCHandle.Alloc((object)num, (GCHandleType)3);
			NtSetSystemInformation(80, val.AddrOfPinnedObject(), Marshal.SizeOf<int>(num));
			val.Free();
			text = "MemoryPurgeStandbyList";
			num = 4;
			val = GCHandle.Alloc((object)num, (GCHandleType)3);
			NtSetSystemInformation(80, val.AddrOfPinnedObject(), Marshal.SizeOf<int>(num));
			val.Free();
			text = "MemoryPurgeLowPriorityStandbyList";
			num = 5;
			val = GCHandle.Alloc((object)num, (GCHandleType)3);
			NtSetSystemInformation(80, val.AddrOfPinnedObject(), Marshal.SizeOf<int>(num));
			val.Free();
			text = "SystemRegistryReconciliationInformation";
			NtSetSystemInformation(155, new System.IntPtr(0), 0);
			text = "SystemCombinePhysicalMemoryInformation";
			MEMORY_COMBINE_INFORMATION_EX mEMORY_COMBINE_INFORMATION_EX = default(MEMORY_COMBINE_INFORMATION_EX);
			val = GCHandle.Alloc((object)mEMORY_COMBINE_INFORMATION_EX, (GCHandleType)3);
			NtSetSystemInformation(130, val.AddrOfPinnedObject(), Marshal.SizeOf<MEMORY_COMBINE_INFORMATION_EX>(mEMORY_COMBINE_INFORMATION_EX));
			val.Free();
		}
		catch (System.Exception ex3)
		{
			ProjectData.SetProjectError(ex3);
			System.Exception ex4 = ex3;
			throw new System.Exception(string.Format("内存优化操作 {0} 失败（错误代码：{1}）", (object)text));
		}
	}

	public static string GetRandomCave()
	{
		return "为便于维护，社区版中不包含百宝箱功能……";
	}

	public static string GetRandomHint()
	{
		return "为便于维护，社区版中不包含百宝箱功能……";
	}

	public static string GetRandomPresetHint()
	{
		return "为便于维护，社区版中不包含百宝箱功能……";
	}

	private void TextDownloadUrl_TextChanged(object sender, TextChangedEventArgs e)
	{
		try
		{
			if (string.IsNullOrEmpty(((TextBox)TextDownloadName).Text) && !string.IsNullOrEmpty(((TextBox)TextDownloadUrl).Text))
			{
				((TextBox)TextDownloadName).Text = ModBase.GetFileNameFromPath(WebUtility.UrlDecode(((TextBox)TextDownloadUrl).Text));
			}
		}
		catch (System.Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private void MyTextButton_Click(object sender, EventArgs e)
	{
		string text = SystemDialogs.SelectFolder();
		if (!string.IsNullOrEmpty(text))
		{
			((TextBox)TextDownloadFolder).Text = text;
		}
	}

	private void BtnDownloadOpen_Click(object sender, MouseButtonEventArgs e)
	{
		try
		{
			string text = ((TextBox)TextDownloadFolder).Text;
			Directory.CreateDirectory(text);
			Basics.OpenPath(text);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "打开下载文件夹失败");
			ProjectData.ClearProjectError();
		}
	}

	private void BtnDownloadStart_Click(object sender, MouseButtonEventArgs e)
	{
		StartCustomDownload(((TextBox)TextDownloadUrl).Text, ((TextBox)TextDownloadName).Text, ((TextBox)TextDownloadFolder).Text, ((TextBox)TextUserAgent).Text);
		((TextBox)TextDownloadUrl).Text = "";
		TextDownloadUrl.Validate();
		TextDownloadUrl.ForceShowAsSuccess();
		((TextBox)TextDownloadName).Text = "";
		TextDownloadName.Validate();
		TextDownloadName.ForceShowAsSuccess();
		StartButtonRefresh();
	}

	private void TextDownloadUrl_ValidateChanged(object sender, EventArgs e)
	{
		StartButtonRefresh();
	}

	private void TextDownloadFolder_ValidateChanged(object sender, EventArgs e)
	{
		StartButtonRefresh();
	}

	private void TextDownloadName_ValidateChanged(object sender, EventArgs e)
	{
		StartButtonRefresh();
	}

	private void BtnClear_Click(object sender, MouseButtonEventArgs e)
	{
		RubbishClear();
	}

	private void BtnMemory_Click(object sender, MouseButtonEventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I33_002D0 != null)
		{
			action = _Closure_0024__._0024I33_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				MemoryOptimize(ShowHint: true);
			};
			_Closure_0024__._0024I33_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInThread((Action)action);
	}

	private void BtnSkinSave_Click(object sender, EventArgs e)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		string text = ((TextBox)TextSkinID).Text;
		ModMain.Hint("正在获取皮肤...");
		ModBase.RunInNewThread((Action)([SpecialName] () =>
		{
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			try
			{
				if (Enumerable.Count<char>((System.Collections.Generic.IEnumerable<char>)text) < 3)
				{
					ModMain.Hint("这不是一个有效的 ID...");
				}
				else
				{
					string text2 = Conversions.ToString(ModProfile.McLoginMojangUuid(text, throwOnNotFound: true));
					text2 = ModMinecraft.McSkinGetAddress(text2, "Mojang");
					text2 = ModMinecraft.McSkinDownload(text2);
					ModBase.RunInUi((Action)([SpecialName] () =>
					{
						string toPath = SystemDialogs.SelectSaveFile("保存皮肤", text + ".png", "皮肤图片文件(*.png)|*.png");
						ModBase.CopyFile(text2, toPath);
						ModMain.Hint($"玩家 {text} 的皮肤已保存！", ModMain.HintType.Finish);
					}));
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				if (ex2.ToString().Contains("429"))
				{
					ModMain.Hint("获取皮肤太过频繁，请 5 分钟之后再试！", ModMain.HintType.Critical);
					ModBase.Log("获取正版皮肤失败（" + text + "）：获取皮肤太过频繁，请 5 分钟后再试！");
				}
				else
				{
					ModBase.Log(ex2, "获取正版皮肤失败（" + text + "）");
				}
				ProjectData.ClearProjectError();
			}
		}), null, (ThreadPriority)2);
	}

	private void BtnLuck_Click(object sender, MouseButtonEventArgs e)
	{
		Jrrp();
	}

	private void BtnThemeUnlock_Click(object sender, MouseButtonEventArgs e)
	{
		try
		{
			string text = ModMain.MyMsgBoxInput("主题解锁", "请输入捐赠版识别码：\r\n\r\n输入识别码后将自动解锁所有主题。(除秋仪金)\r\n留空表示清空所有解锁。");
			if (text != null)
			{
				if (string.IsNullOrWhiteSpace(text))
				{
					WriteThemeUnlockRaw("");
					ModMain.Hint("已清空所有主题解锁！", ModMain.HintType.Finish);
					return;
				}
				string text2 = PageOtherSecret.DesEncrypt("0|1|2|3|4|5|6|7|9|10|11|12|13|14", text);
				ModBase.Log($"unlock: identify {text} cipher {text2}");
				WriteThemeUnlockRaw(text2);
				ModMain.Hint("已使用识别码解锁所有主题！", ModMain.HintType.Finish);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "主题解锁管理失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private string ReadThemeUnlockRaw()
	{
		string result;
		try
		{
			RegistryKey val = Registry.CurrentUser.OpenSubKey("Software\\\\PCLCE", false);
			try
			{
				if (val == null)
				{
					result = "";
				}
				else
				{
					object objectValue = RuntimeHelpers.GetObjectValue(val.GetValue("UiLauncherThemeHide2", (object)""));
					result = ((objectValue == null) ? "" : ((!(objectValue is byte[])) ? TryDecryptThemeValue(objectValue.ToString()) : TryDecryptThemeValue(Encoding.UTF8.GetString((byte[])objectValue))));
				}
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
			ModBase.Log(ex2, "读取主题解锁注册表失败", ModBase.LogLevel.Hint);
			result = "";
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void WriteThemeUnlockRaw(string value)
	{
		try
		{
			RegistryKey val = Registry.CurrentUser.OpenSubKey("Software\\PCL", true);
			if (val == null)
			{
				val = Registry.CurrentUser.CreateSubKey("Software\\PCL");
			}
			val.SetValue("UiLauncherThemeHide2", (object)value, (RegistryValueKind)1);
			val.Close();
			ModBase.Setup.Set("UiLauncherThemeHide2", value);
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "写入主题解锁注册表失败", ModBase.LogLevel.Hint);
			ProjectData.ClearProjectError();
		}
	}

	private string TryDecryptThemeValue(string text)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		try
		{
			string text2 = EncryptHelper.SecretDecrypt(text);
			if (!string.IsNullOrEmpty(text2))
			{
				return text2;
			}
		}
		catch (System.Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		try
		{
			string text3 = EncryptHelper.SecretDecryptOld(text);
			if (!string.IsNullOrEmpty(text3))
			{
				return text3;
			}
		}
		catch (System.Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			ProjectData.ClearProjectError();
		}
		return text;
	}

	private List<ThemeEntry> ParseThemeEntries(string raw)
	{
		List<ThemeEntry> val = new List<ThemeEntry>();
		if (string.IsNullOrWhiteSpace(raw))
		{
			return val;
		}
		string[] array = raw.Split('|', (StringSplitOptions)0);
		int num = default(int);
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			string text = array[i].Trim();
			if (Operators.CompareString(text, "", false) != 0)
			{
				if (int.TryParse(text, out num))
				{
					val.Add(new ThemeEntry
					{
						Raw = text,
						Number = num
					});
				}
				else
				{
					val.Add(new ThemeEntry
					{
						Raw = text,
						Number = null
					});
				}
			}
		}
		return val;
	}

	public static int GenerateDailySeed()
	{
		string text = System.DateTime.Today.ToString("yyyyMMdd");
		string text2 = ModSecret.SecretGetRawCode();
		return (text + text2).GetHashCode();
	}

	public static string GetRating(int luckValue)
	{
		if (luckValue == 100)
		{
			return "100！100！\r\n隐藏主题 欧皇…… 不对，社区版应该没有这玩意……";
		}
		return (luckValue >= 95) ? "差一点就到100了呢..." : ((luckValue >= 90) ? "好评如潮！" : ((luckValue >= 60) ? "还行啦，还行啦" : ((luckValue >= 40) ? "勉强还行吧..." : ((luckValue >= 30) ? "呜..." : ((luckValue >= 10) ? "不会吧！" : "（是百分制哦）")))));
	}

	private void BtnCreateShortcut_Click(object sender, MouseButtonEventArgs e)
	{
		string specialPath = FileService.GetSpecialPath((System.Environment.SpecialFolder)0, "PCL 社区版.lnk");
		string specialPath2 = FileService.GetSpecialPath((System.Environment.SpecialFolder)11, "Programs\\PCL 社区版.lnk");
		int num = ModMain.MyMsgBox("这个快捷方式不会自动移除，在删除/移动启动器前请手动移除快捷方式。\r\n\r\n桌面位置: " + specialPath + "\r\n开始菜单位置: " + specialPath2, "选择快捷方式位置", "取消", "桌面", "开始菜单");
		string shortcut;
		switch (num)
		{
		default:
			shortcut = specialPath2;
			break;
		case 2:
			shortcut = specialPath;
			break;
		case 1:
			return;
		}
		string text = ((num == 2) ? "桌面" : "开始菜单");
		Files.CreateShortcut(shortcut, Basics.ExecutablePath);
		ModMain.Hint("已在" + text + "创建快捷方式", ModMain.HintType.Finish);
	}

	private void BtnLaunchCount_Click(object sender, MouseButtonEventArgs e)
	{
		int num = Conversions.ToInteger(ModBase.Setup.Get("SystemLaunchCount"));
		ModMain.MyMsgBox($"PCL 已经为你启动了 {num} 次游戏了。", "启动次数");
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_46_BtnAchievementPreview_Click))]
	private void BtnAchievementPreview_Click(object sender, MouseButtonEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_46_BtnAchievementPreview_Click vB_0024StateMachine_46_BtnAchievementPreview_Click = default(VB_0024StateMachine_46_BtnAchievementPreview_Click);
		vB_0024StateMachine_46_BtnAchievementPreview_Click._0024VB_0024Me = this;
		vB_0024StateMachine_46_BtnAchievementPreview_Click._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_46_BtnAchievementPreview_Click._0024VB_0024Local_e = e;
		vB_0024StateMachine_46_BtnAchievementPreview_Click._0024State = -1;
		vB_0024StateMachine_46_BtnAchievementPreview_Click._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_46_BtnAchievementPreview_Click._0024Builder.Start<VB_0024StateMachine_46_BtnAchievementPreview_Click>(ref vB_0024StateMachine_46_BtnAchievementPreview_Click);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_47_LoadImageAsync))]
	private System.Threading.Tasks.Task LoadImageAsync(string imageUrl)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_47_LoadImageAsync vB_0024StateMachine_47_LoadImageAsync = default(VB_0024StateMachine_47_LoadImageAsync);
		vB_0024StateMachine_47_LoadImageAsync._0024VB_0024Me = this;
		vB_0024StateMachine_47_LoadImageAsync._0024VB_0024Local_imageUrl = imageUrl;
		vB_0024StateMachine_47_LoadImageAsync._0024State = -1;
		vB_0024StateMachine_47_LoadImageAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_47_LoadImageAsync._0024Builder.Start<VB_0024StateMachine_47_LoadImageAsync>(ref vB_0024StateMachine_47_LoadImageAsync);
		return vB_0024StateMachine_47_LoadImageAsync._0024Builder.Task;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_48_BtnAchievementSave_Click))]
	private void BtnAchievementSave_Click(object sender, MouseButtonEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_48_BtnAchievementSave_Click vB_0024StateMachine_48_BtnAchievementSave_Click = default(VB_0024StateMachine_48_BtnAchievementSave_Click);
		vB_0024StateMachine_48_BtnAchievementSave_Click._0024VB_0024Me = this;
		vB_0024StateMachine_48_BtnAchievementSave_Click._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_48_BtnAchievementSave_Click._0024VB_0024Local_e = e;
		vB_0024StateMachine_48_BtnAchievementSave_Click._0024State = -1;
		vB_0024StateMachine_48_BtnAchievementSave_Click._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_48_BtnAchievementSave_Click._0024Builder.Start<VB_0024StateMachine_48_BtnAchievementSave_Click>(ref vB_0024StateMachine_48_BtnAchievementSave_Click);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_49_DownloadImageToLocalAsync))]
	private System.Threading.Tasks.Task DownloadImageToLocalAsync(string imageUrl)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_49_DownloadImageToLocalAsync vB_0024StateMachine_49_DownloadImageToLocalAsync = default(VB_0024StateMachine_49_DownloadImageToLocalAsync);
		vB_0024StateMachine_49_DownloadImageToLocalAsync._0024VB_0024Me = this;
		vB_0024StateMachine_49_DownloadImageToLocalAsync._0024VB_0024Local_imageUrl = imageUrl;
		vB_0024StateMachine_49_DownloadImageToLocalAsync._0024State = -1;
		vB_0024StateMachine_49_DownloadImageToLocalAsync._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_49_DownloadImageToLocalAsync._0024Builder.Start<VB_0024StateMachine_49_DownloadImageToLocalAsync>(ref vB_0024StateMachine_49_DownloadImageToLocalAsync);
		return vB_0024StateMachine_49_DownloadImageToLocalAsync._0024Builder.Task;
	}

	private string GetAchievementUrl()
	{
		string text = ((TextBox)AchievementBlockTextBox).Text.Trim();
		string text2 = ((TextBox)AchievementTitleTextBox).Text.Replace(" ", "..");
		string text3 = ((TextBox)AchievementString1TextBox).Text.Replace(" ", "..");
		string text4 = ((TextBox)AchievementString2TextBox).Text.Replace(" ", "..");
		string text5 = $"https://minecraft-api.com/api/achivements/{text}/{text2}/{text3}";
		if (!string.IsNullOrEmpty(text4))
		{
			text5 += $"/{text4}";
		}
		return text5;
	}

	private void BtnCrash_Click(object sender, MouseButtonEventArgs e)
	{
		if (Operators.CompareString(ModMain.MyMsgBoxInput("崩溃确认", "你一定是点错了，如果没错请在下方确认", "确认", null, "\"sURe\".ToUpper()", "确定", "取消", IsWarn: true), "SURE", false) == 0)
		{
			throw new System.Exception("手动崩溃");
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageother/pageothertest.xaml", (UriKind)2);
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
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanMain = (StackPanel)target;
			break;
		case 3:
			BtnClear = (MyButton)target;
			break;
		case 4:
			TextDownloadUrl = (MyTextBox)target;
			break;
		case 5:
			TextUserAgent = (MyTextBox)target;
			break;
		case 6:
			TextDownloadFolder = (MyTextBox)target;
			break;
		case 7:
			TextDownloadName = (MyTextBox)target;
			break;
		case 8:
			BtnDownloadStart = (MyButton)target;
			break;
		case 9:
			BtnDownloadOpen = (MyButton)target;
			break;
		case 10:
			CardSkin = (MyCard)target;
			break;
		case 11:
			PanSkinID = (Grid)target;
			break;
		case 12:
			TextSkinID = (MyTextBox)target;
			break;
		case 13:
			BtnSkinSave = (MyButton)target;
			break;
		case 14:
			AchievementBlockTextBox = (MyTextBox)target;
			break;
		case 15:
			AchievementTitleTextBox = (MyTextBox)target;
			break;
		case 16:
			AchievementString1TextBox = (MyTextBox)target;
			break;
		case 17:
			AchievementString2TextBox = (MyTextBox)target;
			break;
		case 18:
			BtnAchievementPreview = (MyButton)target;
			break;
		case 19:
			BtnAchievementSave = (MyButton)target;
			break;
		case 20:
			AchievementImage = (Image)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
