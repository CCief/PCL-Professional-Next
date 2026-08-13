using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic.CompilerServices;
using NAudio;
using NAudio.Wave;
using PCL.Core.Utils;

namespace PCL;

[StandardModule]
public sealed class ModMusic
{
	public enum MusicStates
	{
		Stop,
		Play,
		Pause
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action _0024I5_002D0;

		public static Action _0024I13_002D0;

		public static Action _0024I14_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__5_002D0()
		{
			try
			{
				if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)MusicAllList))
				{
					ModMain.FrmMain.BtnExtraMusic.Show = false;
				}
				else
				{
					ModMain.FrmMain.BtnExtraMusic.Show = true;
					string text;
					if (MusicState == MusicStates.Pause)
					{
						ModMain.FrmMain.BtnExtraMusic.Logo = "M803.904 463.936a55.168 55.168 0 0 1 0 96.128l-463.616 264.448C302.848 845.888 256 819.136 256 776.448V247.616c0-42.752 46.848-69.44 84.288-48.064l463.616 264.384z";
						ModMain.FrmMain.BtnExtraMusic.LogoScale = 0.8;
						text = "已暂停：" + ModBase.GetFileNameWithoutExtentionFromPath(MusicCurrent);
						text = ((MusicAllList.Count <= 1) ? (text + "\r\n左键恢复播放，右键重新从头播放。") : (text + "\r\n左键恢复播放，右键播放下一曲。"));
					}
					else
					{
						ModMain.FrmMain.BtnExtraMusic.Logo = "M348.293565 716.53287V254.797913c0-41.672348 28.004174-78.358261 68.919652-90.37913L815.994435 40.826435c62.775652-18.610087 125.907478 26.579478 125.907478 89.933913v539.158261c8.013913 42.25113-8.94887 89.177043-47.014956 127.109565a232.848696 232.848696 0 0 1-170.785392 65.758609c-61.885217-2.938435-111.081739-33.435826-129.113043-80.050087-18.031304-46.614261-2.137043-102.177391 41.672348-145.853218a232.848696 232.848696 0 0 1 170.785391-65.80313c21.014261 1.024 40.514783 5.164522 57.878261 12.065391V233.338435c0-12.109913-10.551652-20.034783-20.569044-20.034783a24.620522 24.620522 0 0 0-5.787826 0.934957L439.785739 338.18713a19.545043 19.545043 0 0 0-14.825739 19.144348v438.984348H423.846957c11.53113 43.987478-5.164522 94.208-45.412174 134.322087a232.848696 232.848696 0 0 1-170.785392 65.758609c-61.885217-2.938435-111.081739-33.435826-129.113043-80.050087-18.031304-46.614261-2.137043-102.177391 41.672348-145.853218a232.848696 232.848696 0 0 1 170.785391-65.80313c20.791652 1.024 40.069565 5.075478 57.299478 11.842783z";
						ModMain.FrmMain.BtnExtraMusic.LogoScale = 1.0;
						text = "正在播放：" + ModBase.GetFileNameWithoutExtentionFromPath(MusicCurrent);
						text = ((MusicAllList.Count <= 1) ? (text + "\r\n左键暂停，右键重新从头播放。") : (text + "\r\n左键暂停，右键播放下一曲。"));
					}
					((FrameworkElement)ModMain.FrmMain.BtnExtraMusic).ToolTip = text;
					ToolTipService.SetVerticalOffset((DependencyObject)(object)ModMain.FrmMain.BtnExtraMusic, (double)(text.Contains("\n") ? 10 : 16));
				}
				if (ModMain.FrmSetupUI != null)
				{
					ModMain.FrmSetupUI.MusicRefreshUI();
				}
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "刷新背景音乐 UI 失败", ModBase.LogLevel.Feedback);
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__13_002D0()
		{
			ModBase.Log("[Music] 已暂停播放");
			object musicNAudio = MusicNAudio;
			if (musicNAudio != null)
			{
				NewLateBinding.LateCall(musicNAudio, (System.Type)null, "Pause", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
			}
			MusicRefreshUI();
		}

		[SpecialName]
		internal void _Lambda_0024__14_002D0()
		{
			ModBase.Log("[Music] 已恢复播放");
			try
			{
				object musicNAudio = MusicNAudio;
				if (musicNAudio != null)
				{
					NewLateBinding.LateCall(musicNAudio, (System.Type)null, "Play", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
				}
			}
			catch (System.Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				object musicNAudio2 = MusicNAudio;
				if (musicNAudio2 != null)
				{
					NewLateBinding.LateCall(musicNAudio2, (System.Type)null, "Stop", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
				}
				object musicNAudio3 = MusicNAudio;
				if (musicNAudio3 != null)
				{
					NewLateBinding.LateCall(musicNAudio3, (System.Type)null, "Play", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
				}
				ProjectData.ClearProjectError();
			}
			MusicRefreshUI();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__17_002D0
	{
		public double _0024VB_0024Local_Percent;

		public _Closure_0024__17_002D0(_Closure_0024__17_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_Percent = arg0._0024VB_0024Local_Percent;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			ModMain.FrmMain.BtnExtraMusic.Progress = _0024VB_0024Local_Percent;
		}
	}

	public static List<string> MusicWaitingList = null;

	public static List<string> MusicAllList = null;

	public static object MusicNAudio = null;

	private static string MusicCurrent = "";

	public static MusicStates MusicState
	{
		get
		{
			if (MusicNAudio == null)
			{
				return MusicStates.Stop;
			}
			object obj = NewLateBinding.LateGet(MusicNAudio, (System.Type)null, "PlaybackState", new object[0], (string[])null, (System.Type[])null, (bool[])null);
			if (Operators.ConditionalCompareObjectEqual(obj, (object)0, false))
			{
				return MusicStates.Stop;
			}
			if (Operators.ConditionalCompareObjectEqual(obj, (object)2, false))
			{
				return MusicStates.Pause;
			}
			return MusicStates.Play;
		}
	}

	private static void MusicListInit(bool ForceReload, string PreventFirst = null)
	{
		if (ForceReload)
		{
			MusicAllList = null;
		}
		try
		{
			if (MusicAllList == null)
			{
				MusicAllList = new List<string>();
				Directory.CreateDirectory(ModBase.ExePath + "PCL\\Musics\\");
				System.Collections.Generic.IEnumerator<FileInfo> enumerator = default(System.Collections.Generic.IEnumerator<FileInfo>);
				try
				{
					enumerator = ModBase.EnumerateFiles(ModBase.ExePath + "PCL\\Musics\\").GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						FileInfo current = enumerator.Current;
						string text = ((FileSystemInfo)current).Extension.ToLower();
						if (!Enumerable.Contains<string>((System.Collections.Generic.IEnumerable<string>)new string[] { ".ini", ".jpg", ".txt", ".cfg", ".lrc", ".db", ".png" }, text))
						{
							MusicAllList.Add(((FileSystemInfo)current).FullName);
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
			}
			MusicWaitingList = (List<string>)(Conversions.ToBoolean(ModBase.Setup.Get("UiMusicRandom")) ? ((object)RandomUtils.Shuffle((System.Collections.Generic.IList<string>)new List<string>((System.Collections.Generic.IEnumerable<string>)MusicAllList))) : ((object)new List<string>((System.Collections.Generic.IEnumerable<string>)MusicAllList)));
			if (PreventFirst != null && Operators.CompareString(Enumerable.FirstOrDefault<string>((System.Collections.Generic.IEnumerable<string>)MusicWaitingList), PreventFirst, false) == 0)
			{
				MusicWaitingList.RemoveAt(0);
				MusicWaitingList.Add(PreventFirst);
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "初始化音乐列表失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static string DequeueNextMusicAddress()
	{
		if (MusicAllList == null || !Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)MusicAllList) || !Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)MusicWaitingList))
		{
			MusicListInit(ForceReload: false);
		}
		string text;
		if (Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)MusicWaitingList))
		{
			text = MusicWaitingList[0];
			MusicWaitingList.RemoveAt(0);
		}
		else
		{
			text = null;
		}
		if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)MusicWaitingList))
		{
			MusicListInit(ForceReload: false, text);
		}
		return text;
	}

	private static void MusicRefreshUI()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I5_002D0 != null)
		{
			action = _Closure_0024__._0024I5_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				try
				{
					if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)MusicAllList))
					{
						ModMain.FrmMain.BtnExtraMusic.Show = false;
					}
					else
					{
						ModMain.FrmMain.BtnExtraMusic.Show = true;
						string text;
						if (MusicState == MusicStates.Pause)
						{
							ModMain.FrmMain.BtnExtraMusic.Logo = "M803.904 463.936a55.168 55.168 0 0 1 0 96.128l-463.616 264.448C302.848 845.888 256 819.136 256 776.448V247.616c0-42.752 46.848-69.44 84.288-48.064l463.616 264.384z";
							ModMain.FrmMain.BtnExtraMusic.LogoScale = 0.8;
							text = "已暂停：" + ModBase.GetFileNameWithoutExtentionFromPath(MusicCurrent);
							text = ((MusicAllList.Count <= 1) ? (text + "\r\n左键恢复播放，右键重新从头播放。") : (text + "\r\n左键恢复播放，右键播放下一曲。"));
						}
						else
						{
							ModMain.FrmMain.BtnExtraMusic.Logo = "M348.293565 716.53287V254.797913c0-41.672348 28.004174-78.358261 68.919652-90.37913L815.994435 40.826435c62.775652-18.610087 125.907478 26.579478 125.907478 89.933913v539.158261c8.013913 42.25113-8.94887 89.177043-47.014956 127.109565a232.848696 232.848696 0 0 1-170.785392 65.758609c-61.885217-2.938435-111.081739-33.435826-129.113043-80.050087-18.031304-46.614261-2.137043-102.177391 41.672348-145.853218a232.848696 232.848696 0 0 1 170.785391-65.80313c21.014261 1.024 40.514783 5.164522 57.878261 12.065391V233.338435c0-12.109913-10.551652-20.034783-20.569044-20.034783a24.620522 24.620522 0 0 0-5.787826 0.934957L439.785739 338.18713a19.545043 19.545043 0 0 0-14.825739 19.144348v438.984348H423.846957c11.53113 43.987478-5.164522 94.208-45.412174 134.322087a232.848696 232.848696 0 0 1-170.785392 65.758609c-61.885217-2.938435-111.081739-33.435826-129.113043-80.050087-18.031304-46.614261-2.137043-102.177391 41.672348-145.853218a232.848696 232.848696 0 0 1 170.785391-65.80313c20.791652 1.024 40.069565 5.075478 57.299478 11.842783z";
							ModMain.FrmMain.BtnExtraMusic.LogoScale = 1.0;
							text = "正在播放：" + ModBase.GetFileNameWithoutExtentionFromPath(MusicCurrent);
							text = ((MusicAllList.Count <= 1) ? (text + "\r\n左键暂停，右键重新从头播放。") : (text + "\r\n左键暂停，右键播放下一曲。"));
						}
						((FrameworkElement)ModMain.FrmMain.BtnExtraMusic).ToolTip = text;
						ToolTipService.SetVerticalOffset((DependencyObject)(object)ModMain.FrmMain.BtnExtraMusic, (double)(text.Contains("\n") ? 10 : 16));
					}
					if (ModMain.FrmSetupUI != null)
					{
						ModMain.FrmSetupUI.MusicRefreshUI();
					}
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "刷新背景音乐 UI 失败", ModBase.LogLevel.Feedback);
					ProjectData.ClearProjectError();
				}
			};
			_Closure_0024__._0024I5_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
	}

	public static void MusicControlPause()
	{
		if (MusicNAudio == null)
		{
			ModMain.Hint("音乐播放尚未开始！", ModMain.HintType.Critical);
			return;
		}
		switch (MusicState)
		{
		case MusicStates.Pause:
			MusicResume();
			break;
		case MusicStates.Play:
			MusicPause();
			break;
		default:
			ModBase.Log("[Music] 音乐目前为停止状态，已强制尝试开始播放", ModBase.LogLevel.Debug);
			MusicRefreshPlay(ShowHint: false);
			break;
		}
	}

	public static void MusicControlNext()
	{
		if (MusicAllList.Count == 1)
		{
			MusicStartPlay(MusicCurrent);
			ModMain.Hint("重新播放：" + ModBase.GetFileNameFromPath(MusicCurrent), ModMain.HintType.Finish);
		}
		else
		{
			string text = DequeueNextMusicAddress();
			if (text == null)
			{
				ModMain.Hint("没有可以播放的音乐！", ModMain.HintType.Critical);
			}
			else
			{
				MusicStartPlay(text);
				ModMain.Hint("正在播放：" + ModBase.GetFileNameFromPath(text), ModMain.HintType.Finish);
			}
		}
		MusicRefreshUI();
	}

	public static void MusicRefreshPlay(bool ShowHint, bool IsFirstLoad = false)
	{
		try
		{
			MusicListInit(ForceReload: true);
			if (!Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)MusicAllList))
			{
				if (MusicNAudio == null)
				{
					if (ShowHint)
					{
						ModMain.Hint("未检测到可用的背景音乐！", ModMain.HintType.Critical);
					}
				}
				else
				{
					MusicNAudio = null;
					if (ShowHint)
					{
						ModMain.Hint("背景音乐已清除！", ModMain.HintType.Finish);
					}
				}
			}
			else
			{
				string text = DequeueNextMusicAddress();
				if (text == null)
				{
					if (ShowHint)
					{
						ModMain.Hint("没有可以播放的音乐！", ModMain.HintType.Critical);
					}
				}
				else
				{
					try
					{
						MusicStartPlay(text, IsFirstLoad);
						if (ShowHint)
						{
							ModMain.Hint("背景音乐已刷新：" + ModBase.GetFileNameFromPath(text), ModMain.HintType.Finish, Log: false);
						}
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
			}
			MusicRefreshUI();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "刷新背景音乐播放失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	private static void MusicStartPlay(string Address, bool IsFirstLoad = false)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		if (Address != null)
		{
			ModBase.Log("[Music] 播放开始：" + Address);
			MusicCurrent = Address;
			ModBase.RunInNewThread((Action)([SpecialName] () =>
			{
				MusicLoop(IsFirstLoad);
			}), "Music", (ThreadPriority)1);
		}
	}

	public static bool MusicPause()
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		if (MusicState == MusicStates.Play)
		{
			object action;
			if (_Closure_0024__._0024I13_002D0 != null)
			{
				action = _Closure_0024__._0024I13_002D0;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					ModBase.Log("[Music] 已暂停播放");
					object musicNAudio = MusicNAudio;
					if (musicNAudio != null)
					{
						NewLateBinding.LateCall(musicNAudio, (System.Type)null, "Pause", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
					}
					MusicRefreshUI();
				};
				_Closure_0024__._0024I13_002D0 = val;
				action = (object)val;
			}
			ModBase.RunInThread((Action)action);
			return true;
		}
		ModBase.Log($"[Music] 无需暂停播放，当前状态为 {MusicState}");
		return false;
	}

	public static bool MusicResume()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		if (MusicState == MusicStates.Play || !Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)MusicAllList))
		{
			ModBase.Log($"[Music] 无需继续播放，当前状态为 {MusicState}");
			return false;
		}
		object action;
		if (_Closure_0024__._0024I14_002D0 != null)
		{
			action = _Closure_0024__._0024I14_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				ModBase.Log("[Music] 已恢复播放");
				try
				{
					object musicNAudio = MusicNAudio;
					if (musicNAudio != null)
					{
						NewLateBinding.LateCall(musicNAudio, (System.Type)null, "Play", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
					}
				}
				catch (System.Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					object musicNAudio2 = MusicNAudio;
					if (musicNAudio2 != null)
					{
						NewLateBinding.LateCall(musicNAudio2, (System.Type)null, "Stop", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
					}
					object musicNAudio3 = MusicNAudio;
					if (musicNAudio3 != null)
					{
						NewLateBinding.LateCall(musicNAudio3, (System.Type)null, "Play", new object[0], (string[])null, (System.Type[])null, (bool[])null, true);
					}
					ProjectData.ClearProjectError();
				}
				MusicRefreshUI();
			};
			_Closure_0024__._0024I14_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInThread((Action)action);
		return true;
	}

	private static void MusicLoop(bool IsFirstLoad = false)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected O, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected O, but got Unknown
		WaveOutEvent val = null;
		WaveStream val2 = null;
		try
		{
			val = (WaveOutEvent)(MusicNAudio = (object)new WaveOutEvent());
			val.DeviceNumber = -1;
			val2 = (WaveStream)(object)new AudioFileReader(MusicCurrent);
			val.Init((IWaveProvider)(object)val2);
			val.Play();
			if (Conversions.ToBoolean((object)(IsFirstLoad && Conversions.ToBoolean(Operators.NotObject(ModBase.Setup.Get("UiMusicAuto"))))))
			{
				val.Pause();
			}
			MusicRefreshUI();
			int num = 0;
			_Closure_0024__17_002D0 closure_0024__17_002D = default(_Closure_0024__17_002D0);
			while (((object)val).Equals(RuntimeHelpers.GetObjectValue(MusicNAudio)) && (int)val.PlaybackState != 0)
			{
				closure_0024__17_002D = new _Closure_0024__17_002D0(closure_0024__17_002D);
				if (Operators.ConditionalCompareObjectNotEqual(ModBase.Setup.Get("UiMusicVolume"), (object)num, false))
				{
					num = Conversions.ToInteger(ModBase.Setup.Get("UiMusicVolume"));
					val.Volume = (float)((double)num / 1000.0);
				}
				_Closure_0024__17_002D0 closure_0024__17_002D2 = closure_0024__17_002D;
				TimeSpan val3 = val2.CurrentTime;
				double totalMilliseconds = val3.TotalMilliseconds;
				val3 = val2.TotalTime;
				closure_0024__17_002D2._0024VB_0024Local_Percent = totalMilliseconds / val3.TotalMilliseconds;
				ModBase.RunInUi(new Action(closure_0024__17_002D._Lambda_0024__0));
				Thread.Sleep(100);
			}
			if ((int)val.PlaybackState == 0 && Enumerable.Any<string>((System.Collections.Generic.IEnumerable<string>)MusicAllList))
			{
				MusicStartPlay(DequeueNextMusicAddress());
			}
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "播放音乐出现内部错误（" + MusicCurrent + "）", ModBase.LogLevel.Developer);
			if (ex2 is MmException && ex2.Message.Contains("AlreadyAllocated"))
			{
				ModMain.Hint("你的音频设备正被其他程序占用。请在关闭占用的程序后重启 PCL，才能恢复音乐播放功能！", ModMain.HintType.Critical);
				Thread.Sleep(1000000000);
			}
			if (ex2 is MmException && (ex2.Message.Contains("NoDriver") || ex2.Message.Contains("BadDeviceId")))
			{
				ModMain.Hint("由于音频设备变更，音乐播放功能在重启 PCL 后才能恢复！", ModMain.HintType.Critical);
				Thread.Sleep(1000000000);
			}
			if (ex2.Message.Contains("Got a frame at sample rate") || ex2.Message.Contains("does not support changes to"))
			{
				ModMain.Hint("播放音乐失败（" + ModBase.GetFileNameFromPath(MusicCurrent) + "）：PCL 不支持播放音频属性在中途发生变化的音乐", ModMain.HintType.Critical);
			}
			else if ((!ModBase.EndsWithF(MusicCurrent, ".wav", IgnoreCase: true) && !ModBase.EndsWithF(MusicCurrent, ".mp3", IgnoreCase: true) && !ModBase.EndsWithF(MusicCurrent, ".flac", IgnoreCase: true)) || ex2.Message.Contains("0xC00D36C4"))
			{
				ModMain.Hint("播放音乐失败（" + ModBase.GetFileNameFromPath(MusicCurrent) + "）：PCL 可能不支持此音乐格式，请将格式转换为 .wav、.mp3 或 .flac 后再试", ModMain.HintType.Critical);
			}
			else
			{
				ModBase.Log(ex2, "播放音乐失败（" + ModBase.GetFileNameFromPath(MusicCurrent) + "）", ModBase.LogLevel.Hint);
			}
			MusicAllList.Remove(MusicCurrent);
			MusicWaitingList.Remove(MusicCurrent);
			MusicRefreshUI();
			Thread.Sleep(2000);
			if (ex2 is FileNotFoundException)
			{
				MusicRefreshPlay(ShowHint: true, IsFirstLoad);
			}
			else
			{
				MusicStartPlay(DequeueNextMusicAddress(), IsFirstLoad);
			}
			ProjectData.ClearProjectError();
		}
		finally
		{
			if (val != null)
			{
				val.Dispose();
			}
			if (val2 != null)
			{
				((Stream)val2).Dispose();
			}
			MusicRefreshUI();
		}
	}
}
