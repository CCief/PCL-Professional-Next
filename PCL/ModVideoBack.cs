using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace PCL;

[StandardModule]
public sealed class ModVideoBack
{
	public class BooleanEventArgs : EventArgs
	{
		[field: CompilerGenerated]
		public bool Value
		{
			[CompilerGenerated]
			get;
			[CompilerGenerated]
			set;
		}

		public BooleanEventArgs(bool value)
		{
			Value = value;
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action _0024I18_002D0;

		public static Action _0024I19_002D0;

		public static Action _0024I21_002D0;

		public static Action _0024I22_002D0;

		public static Action _0024I23_002D0;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__18_002D0()
		{
			if (IsGaming)
			{
				if (ForcePlay)
				{
					if (!Information.IsNothing((object)ModMain.FrmSetupUI))
					{
						((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = true;
					}
				}
				else if (!Information.IsNothing((object)ModMain.FrmSetupUI))
				{
					((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = false;
				}
			}
			else if (!Information.IsNothing((object)ModMain.FrmSetupUI))
			{
				((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = true;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__19_002D0()
		{
			if (IsGaming)
			{
				if (ForcePlay)
				{
					if (!Information.IsNothing((object)ModMain.FrmSetupUI))
					{
						((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = true;
					}
				}
				else if (!Information.IsNothing((object)ModMain.FrmSetupUI))
				{
					((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = false;
				}
			}
			else if (!Information.IsNothing((object)ModMain.FrmSetupUI))
			{
				((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = true;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__21_002D0()
		{
			if (((ModMain.FrmMain.VideoBack.Source != null) & !IsMinimized) && (!IsGaming | ForcePlay))
			{
				try
				{
					ModMain.FrmMain.VideoBack.Play();
					ModBase.Log("[UI] 已开始视频背景播放");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "[UI] 开始视频背景播放失败");
					ProjectData.ClearProjectError();
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__22_002D0()
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				ModMain.FrmMain.VideoBack.Source = null;
				ModMain.FrmMain.VideoBack.Stop();
				ModMain.FrmMain.VideoBack.Position = TimeSpan.Zero;
				ModBase.Log("[UI] 已停止视频背景播放");
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ModBase.Log(ex2, "[UI] 停止视频背景播放失败");
				ProjectData.ClearProjectError();
			}
		}

		[SpecialName]
		internal void _Lambda_0024__23_002D0()
		{
			if (IsMinimized)
			{
				if (ModMain.FrmMain.VideoBack.Source != null)
				{
					try
					{
						ModMain.FrmMain.VideoBack.Pause();
						ModBase.Log("[UI] 已暂停视频背景播放");
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "[UI] 暂停视频背景播放失败");
						ProjectData.ClearProjectError();
					}
				}
			}
			else
			{
				if (ForcePlay || ModMain.FrmMain.VideoBack.Source == null)
				{
					return;
				}
				try
				{
					if (!Information.IsNothing((object)ModMain.FrmSetupUI))
					{
						((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = false;
					}
					ModMain.FrmMain.VideoBack.Pause();
					ModBase.Log("[UI] 已暂停视频背景播放");
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ModBase.Log(ex4, "[UI] 暂停视频背景播放失败");
					ProjectData.ClearProjectError();
				}
			}
		}
	}

	[CompilerGenerated]
	private static EventHandler<BooleanEventArgs> GamingStateChangedEvent;

	[CompilerGenerated]
	private static EventHandler<BooleanEventArgs> ForcePlayChangedEvent;

	private static bool _isGaming = false;

	private static bool _forcePlay = false;

	public static bool IsMinimized = false;

	public static bool IsGaming
	{
		get
		{
			return _isGaming;
		}
		set
		{
			if (_isGaming != value)
			{
				_isGaming = value;
				GamingStateChangedEvent?.Invoke((object)null, new BooleanEventArgs(value));
			}
		}
	}

	public static bool ForcePlay
	{
		get
		{
			return _forcePlay;
		}
		set
		{
			if (_forcePlay != value)
			{
				_forcePlay = value;
				ForcePlayChangedEvent?.Invoke((object)null, new BooleanEventArgs(value));
			}
		}
	}

	public static event EventHandler<BooleanEventArgs> GamingStateChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<BooleanEventArgs> val = GamingStateChangedEvent;
			EventHandler<BooleanEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<BooleanEventArgs> val3 = (EventHandler<BooleanEventArgs>)(object)System.Delegate.Combine((System.Delegate)(object)val2, (System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<BooleanEventArgs>>(ref GamingStateChangedEvent, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<BooleanEventArgs> val = GamingStateChangedEvent;
			EventHandler<BooleanEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<BooleanEventArgs> val3 = (EventHandler<BooleanEventArgs>)(object)System.Delegate.Remove((System.Delegate)(object)val2, (System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<BooleanEventArgs>>(ref GamingStateChangedEvent, val3, val2);
			}
			while (val != val2);
		}
	}

	public static event EventHandler<BooleanEventArgs> ForcePlayChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<BooleanEventArgs> val = ForcePlayChangedEvent;
			EventHandler<BooleanEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<BooleanEventArgs> val3 = (EventHandler<BooleanEventArgs>)(object)System.Delegate.Combine((System.Delegate)(object)val2, (System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<BooleanEventArgs>>(ref ForcePlayChangedEvent, val3, val2);
			}
			while (val != val2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<BooleanEventArgs> val = ForcePlayChangedEvent;
			EventHandler<BooleanEventArgs> val2;
			do
			{
				val2 = val;
				EventHandler<BooleanEventArgs> val3 = (EventHandler<BooleanEventArgs>)(object)System.Delegate.Remove((System.Delegate)(object)val2, (System.Delegate)(object)value);
				val = Interlocked.CompareExchange<EventHandler<BooleanEventArgs>>(ref ForcePlayChangedEvent, val3, val2);
			}
			while (val != val2);
		}
	}

	public static void OnGamingStateChanged(object sender, BooleanEventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I18_002D0 != null)
		{
			action = _Closure_0024__._0024I18_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				if (IsGaming)
				{
					if (ForcePlay)
					{
						if (!Information.IsNothing((object)ModMain.FrmSetupUI))
						{
							((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = true;
						}
					}
					else if (!Information.IsNothing((object)ModMain.FrmSetupUI))
					{
						((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = false;
					}
				}
				else if (!Information.IsNothing((object)ModMain.FrmSetupUI))
				{
					((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = true;
				}
			};
			_Closure_0024__._0024I18_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
	}

	public static void OnForcePlayChanged(object sender, BooleanEventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I19_002D0 != null)
		{
			action = _Closure_0024__._0024I19_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				if (IsGaming)
				{
					if (ForcePlay)
					{
						if (!Information.IsNothing((object)ModMain.FrmSetupUI))
						{
							((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = true;
						}
					}
					else if (!Information.IsNothing((object)ModMain.FrmSetupUI))
					{
						((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = false;
					}
				}
				else if (!Information.IsNothing((object)ModMain.FrmSetupUI))
				{
					((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = true;
				}
			};
			_Closure_0024__._0024I19_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
	}

	public static void VideoPlay()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I21_002D0 != null)
		{
			action = _Closure_0024__._0024I21_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				if (((ModMain.FrmMain.VideoBack.Source != null) & !IsMinimized) && (!IsGaming | ForcePlay))
				{
					try
					{
						ModMain.FrmMain.VideoBack.Play();
						ModBase.Log("[UI] 已开始视频背景播放");
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, "[UI] 开始视频背景播放失败");
						ProjectData.ClearProjectError();
					}
				}
			};
			_Closure_0024__._0024I21_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
	}

	public static void VideoStop()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I22_002D0 != null)
		{
			action = _Closure_0024__._0024I22_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				//IL_0029: Unknown result type (might be due to invalid IL or missing references)
				try
				{
					ModMain.FrmMain.VideoBack.Source = null;
					ModMain.FrmMain.VideoBack.Stop();
					ModMain.FrmMain.VideoBack.Position = TimeSpan.Zero;
					ModBase.Log("[UI] 已停止视频背景播放");
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "[UI] 停止视频背景播放失败");
					ProjectData.ClearProjectError();
				}
			};
			_Closure_0024__._0024I22_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
	}

	public static void VideoPause()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		object action;
		if (_Closure_0024__._0024I23_002D0 != null)
		{
			action = _Closure_0024__._0024I23_002D0;
		}
		else
		{
			Action val = [SpecialName] () =>
			{
				if (IsMinimized)
				{
					if (ModMain.FrmMain.VideoBack.Source != null)
					{
						try
						{
							ModMain.FrmMain.VideoBack.Pause();
							ModBase.Log("[UI] 已暂停视频背景播放");
						}
						catch (System.Exception ex)
						{
							ProjectData.SetProjectError(ex);
							System.Exception ex2 = ex;
							ModBase.Log(ex2, "[UI] 暂停视频背景播放失败");
							ProjectData.ClearProjectError();
						}
					}
				}
				else if (!ForcePlay && ModMain.FrmMain.VideoBack.Source != null)
				{
					try
					{
						if (!Information.IsNothing((object)ModMain.FrmSetupUI))
						{
							((UIElement)ModMain.FrmSetupUI.BtnBackgroundRefresh).IsEnabled = false;
						}
						ModMain.FrmMain.VideoBack.Pause();
						ModBase.Log("[UI] 已暂停视频背景播放");
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						ModBase.Log(ex4, "[UI] 暂停视频背景播放失败");
						ProjectData.ClearProjectError();
					}
				}
			};
			_Closure_0024__._0024I23_002D0 = val;
			action = (object)val;
		}
		ModBase.RunInUi((Action)action);
	}
}
