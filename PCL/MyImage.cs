using System;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Net;
using PCL.Core.Utils;

namespace PCL;

public class MyImage : Image
{
	[CompilerGenerated]
	internal sealed class _Closure_0024__22_002D0
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine___Lambda_0024__0 : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncTaskMethodBuilder _0024Builder;

			internal _Closure_0024__22_002D0 _0024VB_0024NonLocal__Closure_0024__22_002D0;

			internal TaskAwaiter<MyBitmap> _0024A0;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
				//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
				//IL_007e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0083: Unknown result type (might be due to invalid IL or missing references)
				//IL_0097: Unknown result type (might be due to invalid IL or missing references)
				//IL_0098: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				try
				{
					if (num != -3)
					{
					}
					try
					{
						MyBitmap myBitmap;
						if (num != -3)
						{
							TaskAwaiter<MyBitmap> awaiter;
							if (num != 0)
							{
								if (_0024VB_0024NonLocal__Closure_0024__22_002D0._0024VB_0024Local_value == null)
								{
									myBitmap = null;
									goto IL_00dc;
								}
								awaiter = System.Threading.Tasks.Task.Run<MyBitmap>((Func<MyBitmap>)([SpecialName] () => new MyBitmap(_0024VB_0024NonLocal__Closure_0024__22_002D0._0024VB_0024Local_value))).GetAwaiter();
								if (!awaiter.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = awaiter;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<MyBitmap>, VB_0024StateMachine___Lambda_0024__0>(ref awaiter, ref _this);
									return;
								}
							}
							else
							{
								num = (_0024State = -1);
								awaiter = _0024A0;
								_0024A0 = default(TaskAwaiter<MyBitmap>);
							}
							MyBitmap result = awaiter.GetResult();
							awaiter = default(TaskAwaiter<MyBitmap>);
							myBitmap = result;
							goto IL_00dc;
						}
						num = (_0024State = -1);
						return;
						IL_00dc:
						MyBitmap myBitmap2 = myBitmap;
						((Image)_0024VB_0024NonLocal__Closure_0024__22_002D0._0024VB_0024Me).Source = myBitmap2;
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, $"加载图片失败（{_0024VB_0024NonLocal__Closure_0024__22_002D0._0024VB_0024Local_value}）");
						try
						{
							if (ModBase.StartsWithF(_0024VB_0024NonLocal__Closure_0024__22_002D0._0024VB_0024Local_value, ModBase.PathTemp) && File.Exists(_0024VB_0024NonLocal__Closure_0024__22_002D0._0024VB_0024Local_value))
							{
								File.Delete(_0024VB_0024NonLocal__Closure_0024__22_002D0._0024VB_0024Local_value);
							}
						}
						catch (System.Exception projectError)
						{
							ProjectData.SetProjectError(projectError);
							ProjectData.ClearProjectError();
						}
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

		public string _0024VB_0024Local_value;

		public MyImage _0024VB_0024Me;

		public Func<MyBitmap> _0024I1;

		[SpecialName]
		[AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__0))]
		internal System.Threading.Tasks.Task _Lambda_0024__0()
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__22_002D0 = this;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
			return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
		}

		[SpecialName]
		internal MyBitmap _Lambda_0024__1()
		{
			return new MyBitmap(_0024VB_0024Local_value);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__24_002D0
	{
		public string _0024VB_0024Local_TempPath;

		public string _0024VB_0024Local_Url;

		public bool _0024VB_0024Local_EnableCache;

		public bool _0024VB_0024Local_Retried;

		public FileInfo _0024VB_0024Local_TempFile;

		public MyImage _0024VB_0024Me;

		public Action _0024I1;

		public _Closure_0024__24_002D0(_Closure_0024__24_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_TempPath = arg0._0024VB_0024Local_TempPath;
				_0024VB_0024Local_Url = arg0._0024VB_0024Local_Url;
				_0024VB_0024Local_EnableCache = arg0._0024VB_0024Local_EnableCache;
				_0024VB_0024Local_Retried = arg0._0024VB_0024Local_Retried;
				_0024VB_0024Local_TempFile = arg0._0024VB_0024Local_TempFile;
			}
		}

		[MethodImpl(72)]
		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Expected O, but got Unknown
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Expected O, but got Unknown
			//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Expected O, but got Unknown
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Expected O, but got Unknown
			//IL_0170: Expected O, but got Unknown
			_Closure_0024__24_002D1 arg = default(_Closure_0024__24_002D1);
			_Closure_0024__24_002D1 CS_0024_003C_003E8__locals0 = new _Closure_0024__24_002D1(null)
			{
				_0024VB_0024NonLocal__0024VB_0024Closure_2 = this,
				_0024VB_0024Local_TempDownloadingPath = null
			};
			while (true)
			{
				try
				{
					_0024VB_0024Me.ActualSource = _0024VB_0024Me.LoadingSource;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_TempDownloadingPath = _0024VB_0024Local_TempPath + Conversions.ToString(RandomUtils.NextInt(0, 10000000));
					Directory.CreateDirectory(ModBase.GetPathFromFullPath(_0024VB_0024Local_TempPath));
					HttpRequestMessage val = new HttpRequestMessage(HttpMethod.Get, _0024VB_0024Local_Url);
					try
					{
						FileStream val2 = new FileStream(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempDownloadingPath, (FileMode)2);
						try
						{
							HttpResponseMessage result = NetworkService.GetClient().SendAsync(val).Result;
							try
							{
								result.EnsureSuccessStatusCode();
								byte[] result2 = result.Content.ReadAsByteArrayAsync().Result;
								val2.Write(result2, 0, result2.Length);
							}
							finally
							{
								((System.IDisposable)result)?.Dispose();
							}
						}
						finally
						{
							((System.IDisposable)val2)?.Dispose();
						}
					}
					finally
					{
						((System.IDisposable)val)?.Dispose();
					}
					if (Operators.CompareString(_0024VB_0024Local_Url, _0024VB_0024Me.Source, false) != 0 && Operators.CompareString(_0024VB_0024Local_Url, _0024VB_0024Me.FallbackSource, false) != 0)
					{
						File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempDownloadingPath);
					}
					else if (_0024VB_0024Local_EnableCache)
					{
						if (File.Exists(_0024VB_0024Local_TempPath))
						{
							File.Delete(_0024VB_0024Local_TempPath);
						}
						FileSystem.Rename(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempDownloadingPath, _0024VB_0024Local_TempPath);
						Action action;
						if (_0024I1 != null)
						{
							action = _0024I1;
						}
						else
						{
							Action val3 = [SpecialName] () =>
							{
								_0024VB_0024Me.ActualSource = _0024VB_0024Local_TempPath;
							};
							Action val4 = val3;
							_0024I1 = val3;
							action = val4;
						}
						ModBase.RunInUi(action);
					}
					else
					{
						ModBase.RunInUiWait((Action)([SpecialName] () =>
						{
							CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.ActualSource = CS_0024_003C_003E8__locals0._0024VB_0024Local_TempDownloadingPath;
						}));
						File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempDownloadingPath);
					}
					break;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					try
					{
						if (_0024VB_0024Local_TempPath != null)
						{
							File.Delete(_0024VB_0024Local_TempPath);
						}
						if (CS_0024_003C_003E8__locals0._0024VB_0024Local_TempDownloadingPath != null)
						{
							File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempDownloadingPath);
						}
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					if (!_0024VB_0024Local_Retried)
					{
						ModBase.Log(ex2, $"下载图片可重试地失败（{_0024VB_0024Local_Url}）", ModBase.LogLevel.Developer);
						_0024VB_0024Local_Retried = true;
						_0024VB_0024Local_Url = _0024VB_0024Me.FallbackSource ?? _0024VB_0024Me.Source;
						if (_0024VB_0024Local_Url == null)
						{
							_0024VB_0024Me.ActualSource = null;
							ProjectData.ClearProjectError();
							break;
						}
						if (!ModBase.StartsWithF(_0024VB_0024Local_Url, "http"))
						{
							_0024VB_0024Me.ActualSource = _0024VB_0024Local_Url;
							ProjectData.ClearProjectError();
							break;
						}
						_0024VB_0024Local_TempPath = GetTempPath(_0024VB_0024Local_Url);
						_0024VB_0024Local_TempFile = new FileInfo(_0024VB_0024Local_TempPath);
						if (_0024VB_0024Local_EnableCache && _0024VB_0024Local_TempFile.Exists)
						{
							_0024VB_0024Me.ActualSource = _0024VB_0024Local_TempPath;
							if (System.DateTime.Now - ((FileSystemInfo)_0024VB_0024Local_TempFile).CreationTime < _0024VB_0024Me.FileCacheExpiredTime)
							{
								ProjectData.ClearProjectError();
								break;
							}
						}
						if (Operators.CompareString(_0024VB_0024Me.Source, _0024VB_0024Local_Url, false) == 0)
						{
							Thread.Sleep(1000);
						}
						ProjectData.ClearProjectError();
						continue;
					}
					ModBase.Log(ex2, $"下载图片失败（{_0024VB_0024Local_Url}）", ModBase.LogLevel.Hint);
					ProjectData.ClearProjectError();
					break;
				}
			}
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			_0024VB_0024Me.ActualSource = _0024VB_0024Local_TempPath;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__24_002D1
	{
		public string _0024VB_0024Local_TempDownloadingPath;

		public _Closure_0024__24_002D0 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__24_002D1(_Closure_0024__24_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_TempDownloadingPath = arg0._0024VB_0024Local_TempDownloadingPath;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			_0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.ActualSource = _0024VB_0024Local_TempDownloadingPath;
		}
	}

	public TimeSpan FileCacheExpiredTime;

	public static readonly DependencyProperty EnableCacheProperty = DependencyProperty.Register("EnableCache", typeof(bool), typeof(MyImage), new PropertyMetadata((object)true));

	private string _Source;

	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(string), typeof(MyImage), new PropertyMetadata((PropertyChangedCallback)([SpecialName] (DependencyObject sender, DependencyPropertyChangedEventArgs e) =>
	{
		if (sender != null)
		{
			((MyImage)(object)sender).Source = e.NewValue.ToString();
		}
	})));

	private string _FallbackSource;

	private string _LoadingSource;

	private string _ActualSource;

	public bool EnableCache
	{
		get
		{
			return Conversions.ToBoolean(base.GetValue(EnableCacheProperty));
		}
		set
		{
			base.SetValue(EnableCacheProperty, (object)value);
		}
	}

	public string Source
	{
		get
		{
			return _Source;
		}
		set
		{
			if (Operators.CompareString(value, "", false) == 0)
			{
				value = null;
			}
			if (Operators.CompareString(_Source, value, false) != 0)
			{
				_Source = value;
				if (((FrameworkElement)this).IsInitialized)
				{
					Load();
				}
			}
		}
	}

	public string FallbackSource
	{
		get
		{
			return _FallbackSource;
		}
		set
		{
			_FallbackSource = value;
		}
	}

	public string LoadingSource
	{
		get
		{
			return _LoadingSource;
		}
		set
		{
			_LoadingSource = value;
		}
	}

	public string ActualSource
	{
		get
		{
			return _ActualSource;
		}
		set
		{
			_Closure_0024__22_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__22_002D0();
			CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_value = value;
			if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_value, "", false) == 0)
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_value = null;
			}
			if (Operators.CompareString(_ActualSource, CS_0024_003C_003E8__locals0._0024VB_0024Local_value, false) != 0)
			{
				_ActualSource = CS_0024_003C_003E8__locals0._0024VB_0024Local_value;
				((DispatcherObject)this).Dispatcher.BeginInvoke((System.Delegate)(VB_0024AnonymousDelegate_0<System.Threading.Tasks.Task>)([SpecialName] [AsyncStateMachine(typeof(_Closure_0024__22_002D0.VB_0024StateMachine___Lambda_0024__0))] () =>
				{
					//IL_001a: Unknown result type (might be due to invalid IL or missing references)
					//IL_001f: Unknown result type (might be due to invalid IL or missing references)
					_Closure_0024__22_002D0.VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(_Closure_0024__22_002D0.VB_0024StateMachine___Lambda_0024__0);
					vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__22_002D0 = CS_0024_003C_003E8__locals0;
					vB_0024StateMachine___Lambda_0024__._0024State = -1;
					vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
					vB_0024StateMachine___Lambda_0024__._0024Builder.Start<_Closure_0024__22_002D0.VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
					return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
				}), new object[0]);
			}
		}
	}

	public MyImage()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		((FrameworkElement)this).Initialized += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
		{
			Load();
		});
		FileCacheExpiredTime = new TimeSpan(7, 0, 0, 0);
		_Source = "";
		_FallbackSource = null;
		_LoadingSource = "pack://application:,,,/images/Icons/NoIcon.png";
		_ActualSource = null;
	}

	private void Load()
	{
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		_Closure_0024__24_002D0 arg = default(_Closure_0024__24_002D0);
		_Closure_0024__24_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__24_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Me = this;
		if (Source == null)
		{
			ActualSource = null;
			return;
		}
		if (!ModBase.StartsWithF(Source, "http"))
		{
			ActualSource = Source;
			return;
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Url = Source;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_Retried = false;
		CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath = GetTempPath(CS_0024_003C_003E8__locals0._0024VB_0024Local_Url);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_TempFile = new FileInfo(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_EnableCache = EnableCache;
		if (CS_0024_003C_003E8__locals0._0024VB_0024Local_EnableCache && CS_0024_003C_003E8__locals0._0024VB_0024Local_TempFile.Exists)
		{
			ActualSource = CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath;
			if (System.DateTime.Now - ((FileSystemInfo)CS_0024_003C_003E8__locals0._0024VB_0024Local_TempFile).LastWriteTime < FileCacheExpiredTime)
			{
				return;
			}
		}
		ModBase.RunInNewThread((Action)([MethodImpl(72)] [SpecialName] () =>
		{
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Expected O, but got Unknown
			//IL_028a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Expected O, but got Unknown
			//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Expected O, but got Unknown
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Expected O, but got Unknown
			//IL_0170: Expected O, but got Unknown
			_Closure_0024__24_002D1 arg2 = default(_Closure_0024__24_002D1);
			_Closure_0024__24_002D1 CS_0024_003C_003E8__locals1 = new _Closure_0024__24_002D1(null);
			CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2 = CS_0024_003C_003E8__locals0;
			CS_0024_003C_003E8__locals1._0024VB_0024Local_TempDownloadingPath = null;
			while (true)
			{
				try
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Me.ActualSource = CS_0024_003C_003E8__locals0._0024VB_0024Me.LoadingSource;
					CS_0024_003C_003E8__locals1._0024VB_0024Local_TempDownloadingPath = CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath + Conversions.ToString(RandomUtils.NextInt(0, 10000000));
					Directory.CreateDirectory(ModBase.GetPathFromFullPath(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath));
					HttpRequestMessage val = new HttpRequestMessage(HttpMethod.Get, CS_0024_003C_003E8__locals0._0024VB_0024Local_Url);
					try
					{
						FileStream val2 = new FileStream(CS_0024_003C_003E8__locals1._0024VB_0024Local_TempDownloadingPath, (FileMode)2);
						try
						{
							HttpResponseMessage result = NetworkService.GetClient().SendAsync(val).Result;
							try
							{
								result.EnsureSuccessStatusCode();
								byte[] result2 = result.Content.ReadAsByteArrayAsync().Result;
								val2.Write(result2, 0, result2.Length);
							}
							finally
							{
								((System.IDisposable)result)?.Dispose();
							}
						}
						finally
						{
							((System.IDisposable)val2)?.Dispose();
						}
					}
					finally
					{
						((System.IDisposable)val)?.Dispose();
					}
					if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_Url, CS_0024_003C_003E8__locals0._0024VB_0024Me.Source, false) != 0 && Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Local_Url, CS_0024_003C_003E8__locals0._0024VB_0024Me.FallbackSource, false) != 0)
					{
						File.Delete(CS_0024_003C_003E8__locals1._0024VB_0024Local_TempDownloadingPath);
					}
					else if (CS_0024_003C_003E8__locals0._0024VB_0024Local_EnableCache)
					{
						if (File.Exists(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath))
						{
							File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath);
						}
						FileSystem.Rename(CS_0024_003C_003E8__locals1._0024VB_0024Local_TempDownloadingPath, CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath);
						Action action;
						if (CS_0024_003C_003E8__locals0._0024I1 != null)
						{
							action = CS_0024_003C_003E8__locals0._0024I1;
						}
						else
						{
							Action val3 = [SpecialName] () =>
							{
								CS_0024_003C_003E8__locals0._0024VB_0024Me.ActualSource = CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath;
							};
							Action val4 = val3;
							CS_0024_003C_003E8__locals0._0024I1 = val3;
							action = val4;
						}
						ModBase.RunInUi(action);
					}
					else
					{
						ModBase.RunInUiWait((Action)([SpecialName] () =>
						{
							CS_0024_003C_003E8__locals1._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Me.ActualSource = CS_0024_003C_003E8__locals1._0024VB_0024Local_TempDownloadingPath;
						}));
						File.Delete(CS_0024_003C_003E8__locals1._0024VB_0024Local_TempDownloadingPath);
					}
					break;
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					try
					{
						if (CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath != null)
						{
							File.Delete(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath);
						}
						if (CS_0024_003C_003E8__locals1._0024VB_0024Local_TempDownloadingPath != null)
						{
							File.Delete(CS_0024_003C_003E8__locals1._0024VB_0024Local_TempDownloadingPath);
						}
					}
					catch (System.Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
					if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Retried)
					{
						ModBase.Log(ex2, $"下载图片失败（{CS_0024_003C_003E8__locals0._0024VB_0024Local_Url}）", ModBase.LogLevel.Hint);
						ProjectData.ClearProjectError();
						break;
					}
					ModBase.Log(ex2, $"下载图片可重试地失败（{CS_0024_003C_003E8__locals0._0024VB_0024Local_Url}）", ModBase.LogLevel.Developer);
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Retried = true;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_Url = CS_0024_003C_003E8__locals0._0024VB_0024Me.FallbackSource ?? CS_0024_003C_003E8__locals0._0024VB_0024Me.Source;
					if (CS_0024_003C_003E8__locals0._0024VB_0024Local_Url == null)
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Me.ActualSource = null;
						ProjectData.ClearProjectError();
						break;
					}
					if (!ModBase.StartsWithF(CS_0024_003C_003E8__locals0._0024VB_0024Local_Url, "http"))
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Me.ActualSource = CS_0024_003C_003E8__locals0._0024VB_0024Local_Url;
						ProjectData.ClearProjectError();
						break;
					}
					CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath = GetTempPath(CS_0024_003C_003E8__locals0._0024VB_0024Local_Url);
					CS_0024_003C_003E8__locals0._0024VB_0024Local_TempFile = new FileInfo(CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath);
					if (CS_0024_003C_003E8__locals0._0024VB_0024Local_EnableCache && CS_0024_003C_003E8__locals0._0024VB_0024Local_TempFile.Exists)
					{
						CS_0024_003C_003E8__locals0._0024VB_0024Me.ActualSource = CS_0024_003C_003E8__locals0._0024VB_0024Local_TempPath;
						if (System.DateTime.Now - ((FileSystemInfo)CS_0024_003C_003E8__locals0._0024VB_0024Local_TempFile).CreationTime < CS_0024_003C_003E8__locals0._0024VB_0024Me.FileCacheExpiredTime)
						{
							ProjectData.ClearProjectError();
							break;
						}
					}
					if (Operators.CompareString(CS_0024_003C_003E8__locals0._0024VB_0024Me.Source, CS_0024_003C_003E8__locals0._0024VB_0024Local_Url, false) == 0)
					{
						Thread.Sleep(1000);
					}
					ProjectData.ClearProjectError();
				}
			}
		}), "MyImage PicLoader " + Conversions.ToString(ModBase.GetUuid()) + "#", (ThreadPriority)1);
	}

	public static string GetTempPath(string Url)
	{
		return $"{ModBase.PathTemp}MyImage\\{ModBase.GetHash(Url)}.png";
	}
}
