using System;
using System.CodeDom.Compiler;
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
using System.Windows.Input;
using System.Windows.Markup;
using fNbt;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Link;
using PCL.Core.Minecraft;

namespace PCL;

[DesignerGenerated]
public class PageInstanceServer : MyPageRight, IComponentConnector
{
	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_10_RefreshServers : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal PageInstanceServer _0024VB_0024Me;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Expected O, but got Unknown
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if (num != -3 && num != 0)
				{
					ModBase.Log("刷新服务器列表");
				}
				try
				{
					TaskAwaiter val;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						val = _0024VB_0024Me.LoadServersFromFile().GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_10_RefreshServers>(ref val, ref _this);
							return;
						}
						break;
					case 0:
						num = (_0024State = -1);
						val = _0024A0;
						_0024A0 = default(TaskAwaiter);
						break;
					}
					val.GetResult();
					val = default(TaskAwaiter);
					ModBase.RunInUi((Action)([SpecialName] [CompilerGenerated] () =>
					{
						_0024VB_0024Me.UpdateServerUi();
					}));
					_0024VB_0024Me.PingAllServers();
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					_Closure_0024__10_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__10_002D0();
					System.Exception _0024VB_0024Local_ex = ex;
					CS_0024_003C_003E8__locals0._0024VB_0024Local_ex = _0024VB_0024Local_ex;
					ModBase.Log(CS_0024_003C_003E8__locals0._0024VB_0024Local_ex, "刷新服务器列表失败", ModBase.LogLevel.Feedback);
					ModBase.RunInUi((Action)([SpecialName] () =>
					{
						ModMain.Hint("刷新服务器列表失败：" + CS_0024_003C_003E8__locals0._0024VB_0024Local_ex.Message, ModMain.HintType.Critical);
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
	internal sealed class VB_0024StateMachine_12_BtnAddServer_Click : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal MouseButtonEventArgs _0024VB_0024Local_e;

		internal PageInstanceServer _0024VB_0024Me;

		internal ValueTuple<string, string, bool> _0024VB_0024ResumableLocal_result_00240;

		internal string _0024VB_0024ResumableLocal_serversDatPath_00241;

		internal TaskAwaiter<NbtList> _0024A0;

		internal TaskAwaiter<bool> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0305: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Expected O, but got Unknown
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Expected O, but got Unknown
			//IL_0202: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Expected O, but got Unknown
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Expected O, but got Unknown
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Expected O, but got Unknown
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ad: Expected O, but got Unknown
			//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Expected O, but got Unknown
			//IL_0197: Unknown result type (might be due to invalid IL or missing references)
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter<NbtList> awaiter;
				if (num == 0)
				{
					num = (_0024State = -1);
					awaiter = _0024A0;
					_0024A0 = default(TaskAwaiter<NbtList>);
					goto IL_01ce;
				}
				TaskAwaiter<bool> awaiter2;
				if (num == 1)
				{
					num = (_0024State = -1);
					awaiter2 = _0024A1;
					_0024A1 = default(TaskAwaiter<bool>);
					goto IL_02fb;
				}
				_0024VB_0024ResumableLocal_result_00240 = GetServerInfo(new MinecraftServerInfo
				{
					Name = "Minecraft服务器",
					Address = ""
				});
				object obj;
				if (_0024VB_0024ResumableLocal_result_00240.Item3)
				{
					_Closure_0024__12_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__12_002D0();
					MinecraftServerInfo minecraftServerInfo = new MinecraftServerInfo
					{
						Name = _0024VB_0024ResumableLocal_result_00240.Item1,
						Address = _0024VB_0024ResumableLocal_result_00240.Item2,
						Status = ServerStatus.Unknown
					};
					ServerList.Add(minecraftServerInfo);
					_0024VB_0024Me.RefreshTip();
					CS_0024_003C_003E8__locals0._0024VB_0024Local_serverCard = new ServerCard();
					CS_0024_003C_003E8__locals0._0024VB_0024Local_serverCard.RemoveServer += new EventHandler(_0024VB_0024Me.RemoveServerEvent);
					CS_0024_003C_003E8__locals0._0024VB_0024Local_serverCard.EditServer += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
					{
						_0024VB_0024Me.EditServer(RuntimeHelpers.GetObjectValue(a0), (ServerCard.ResultEventArgs)(object)a1);
					});
					CS_0024_003C_003E8__locals0._0024VB_0024Local_serverCard.UpdateServerInfo(minecraftServerInfo);
					ServerCardList.Add(CS_0024_003C_003E8__locals0._0024VB_0024Local_serverCard);
					((Panel)_0024VB_0024Me.PanServers).Children.Add((UIElement)(object)CS_0024_003C_003E8__locals0._0024VB_0024Local_serverCard);
					System.Threading.Tasks.Task.Run((Func<System.Threading.Tasks.Task>)([SpecialName] [AsyncStateMachine(typeof(_Closure_0024__12_002D0.VB_0024StateMachine___Lambda_0024__0))] () =>
					{
						//IL_001a: Unknown result type (might be due to invalid IL or missing references)
						//IL_001f: Unknown result type (might be due to invalid IL or missing references)
						_Closure_0024__12_002D0.VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(_Closure_0024__12_002D0.VB_0024StateMachine___Lambda_0024__0);
						vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__12_002D0 = CS_0024_003C_003E8__locals0;
						vB_0024StateMachine___Lambda_0024__._0024State = -1;
						vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
						vB_0024StateMachine___Lambda_0024__._0024Builder.Start<_Closure_0024__12_002D0.VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
						return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
					}));
					_0024VB_0024ResumableLocal_serversDatPath_00241 = Path.Combine(PageInstanceLeft.Instance.PathIndie, "servers.dat");
					if (!File.Exists(_0024VB_0024ResumableLocal_serversDatPath_00241))
					{
						obj = (object)new NbtList("servers", (NbtTagType)10);
						_0024VB_0024Me.RefreshTip();
						goto IL_01de;
					}
					awaiter = NbtFileHandler.ReadTagInNbtFileAsync<NbtList>(_0024VB_0024ResumableLocal_serversDatPath_00241, "servers", default(CancellationToken)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = awaiter;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<NbtList>, VB_0024StateMachine_12_BtnAddServer_Click>(ref awaiter, ref _this);
						return;
					}
					goto IL_01ce;
				}
				goto end_IL_0007;
				IL_02fb:
				awaiter2.GetResult();
				awaiter2 = default(TaskAwaiter<bool>);
				goto end_IL_0007;
				IL_01de:
				if (obj != null)
				{
					NbtCompound val = new NbtCompound();
					val["name"] = (NbtTag)new NbtString("name", _0024VB_0024ResumableLocal_result_00240.Item1);
					val["ip"] = (NbtTag)new NbtString("ip", _0024VB_0024ResumableLocal_result_00240.Item2);
					object obj2 = obj;
					object[] obj3 = new object[] { val };
					object[] array = obj3;
					bool[] obj4 = new bool[] { true };
					bool[] array2 = obj4;
					NewLateBinding.LateCall(obj2, (System.Type)null, "Add", obj3, (string[])null, (System.Type[])null, obj4, true);
					if (array2[0])
					{
						val = (NbtCompound)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(NbtCompound));
					}
					awaiter2 = NbtFileHandler.WriteTagInNbtFileAsync((NbtTag)(NbtList)NewLateBinding.LateGet(obj, (System.Type)null, "Clone", new object[0], (string[])null, (System.Type[])null, (bool[])null), _0024VB_0024ResumableLocal_serversDatPath_00241, (NbtCompression)1).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_0024State = 1);
						_0024A1 = awaiter2;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, VB_0024StateMachine_12_BtnAddServer_Click>(ref awaiter2, ref _this);
						return;
					}
					goto IL_02fb;
				}
				goto end_IL_0007;
				IL_01ce:
				NbtList result = awaiter.GetResult();
				awaiter = default(TaskAwaiter<NbtList>);
				obj = result;
				goto IL_01de;
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

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_14_LoadServersFromFile : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder _0024Builder;

		internal PageInstanceServer _0024VB_0024Me;

		internal TaskAwaiter<NbtList> _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				string text = PageInstanceLeft.Instance.PathIndie + "servers.dat";
				if (num == -3 || num == 0)
				{
					goto IL_003a;
				}
				ServerList.Clear();
				if (File.Exists(text))
				{
					goto IL_003a;
				}
				goto end_IL_0007;
				IL_003a:
				try
				{
					TaskAwaiter<NbtList> awaiter;
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						awaiter = NbtFileHandler.ReadTagInNbtFileAsync<NbtList>(text, "servers", default(CancellationToken)).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<NbtList>, VB_0024StateMachine_14_LoadServersFromFile>(ref awaiter, ref _this);
							return;
						}
						break;
					case 0:
						num = (_0024State = -1);
						awaiter = _0024A0;
						_0024A0 = default(TaskAwaiter<NbtList>);
						break;
					}
					NbtList result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<NbtList>);
					NbtList serversList = result;
					_0024VB_0024Me.ParseServersFromNBT(serversList);
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "读取servers.dat文件失败");
					ProjectData.ClearProjectError();
				}
				end_IL_0007:;
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

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_19_PingAllServers : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal PageInstanceServer _0024VB_0024Me;

		internal _Closure_0024__19_002D1 _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;

		internal List<System.Threading.Tasks.Task> _0024VB_0024ResumableLocal_tasks_00241;

		internal _Closure_0024__19_002D0 _0024VB_0024ResumableLocal__0024VB_0024Closure__00242;

		internal System.Collections.Generic.IEnumerator<ServerCard> _0024S3;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			//IL_028f: Expected O, but got Unknown
			//IL_0291: Expected O, but got Unknown
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Expected O, but got Unknown
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Expected O, but got Unknown
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0227: Unknown result type (might be due to invalid IL or missing references)
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				if ((uint)(num - -4) > 1u && (uint)num > 1u)
				{
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240 = new _Closure_0024__19_002D1(_0024VB_0024ResumableLocal__0024VB_0024Closure__00240);
					if (_0024VB_0024Me._cts != null)
					{
						_0024VB_0024Me._cts.Cancel();
						_0024VB_0024Me._cts.Dispose();
					}
					_0024VB_0024Me._cts = new CancellationTokenSource();
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_token = _0024VB_0024Me._cts.Token;
					_0024VB_0024ResumableLocal__0024VB_0024Closure__00240._0024VB_0024Local_semaphore = new SemaphoreSlim(5);
					_0024VB_0024ResumableLocal_tasks_00241 = new List<System.Threading.Tasks.Task>();
				}
				try
				{
					List<ServerCard> val2 = default(List<ServerCard>);
					TaskAwaiter val;
					switch (num)
					{
					case -4:
						num = (_0024State = -1);
						return;
					default:
						val2 = Enumerable.ToList<ServerCard>((System.Collections.Generic.IEnumerable<ServerCard>)ServerCardList);
						goto case -3;
					case -3:
					case 0:
						try
						{
							TaskAwaiter val3;
							if (num != -3)
							{
								if (num != 0)
								{
									_0024S3 = val2.GetEnumerator();
									goto IL_01f4;
								}
								num = (_0024State = -1);
								val3 = _0024A0;
								_0024A0 = default(TaskAwaiter);
								goto IL_01b4;
							}
							num = (_0024State = -1);
							return;
							IL_01f4:
							if (_0024S3.MoveNext())
							{
								ServerCard current = _0024S3.Current;
								_0024VB_0024ResumableLocal__0024VB_0024Closure__00242 = new _Closure_0024__19_002D0(_0024VB_0024ResumableLocal__0024VB_0024Closure__00242);
								_0024VB_0024ResumableLocal__0024VB_0024Closure__00242._0024VB_0024NonLocal__0024VB_0024Closure_2 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00240;
								_0024VB_0024ResumableLocal__0024VB_0024Closure__00242._0024VB_0024Local_currentServer = current;
								val3 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00242._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_semaphore.WaitAsync(_0024VB_0024ResumableLocal__0024VB_0024Closure__00242._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_token).GetAwaiter();
								if (!val3.IsCompleted)
								{
									num = (_0024State = 0);
									_0024A0 = val3;
									_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_19_PingAllServers>(ref val3, ref _this);
									return;
								}
								goto IL_01b4;
							}
							goto end_IL_00db;
							IL_01b4:
							val3.GetResult();
							val3 = default(TaskAwaiter);
							_0024VB_0024ResumableLocal_tasks_00241.Add(System.Threading.Tasks.Task.Run((Func<System.Threading.Tasks.Task>)([SpecialName] [AsyncStateMachine(typeof(_Closure_0024__19_002D0.VB_0024StateMachine___Lambda_0024__0))] () =>
							{
								//IL_001a: Unknown result type (might be due to invalid IL or missing references)
								//IL_001f: Unknown result type (might be due to invalid IL or missing references)
								_Closure_0024__19_002D0.VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(_Closure_0024__19_002D0.VB_0024StateMachine___Lambda_0024__0);
								vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__19_002D0 = _0024VB_0024ResumableLocal__0024VB_0024Closure__00242;
								vB_0024StateMachine___Lambda_0024__._0024State = -1;
								vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
								vB_0024StateMachine___Lambda_0024__._0024Builder.Start<_Closure_0024__19_002D0.VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
								return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
							}), _0024VB_0024ResumableLocal__0024VB_0024Closure__00242._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_token));
							goto IL_01f4;
							end_IL_00db:;
						}
						finally
						{
							if (num < 0)
							{
								((System.IDisposable)_0024S3).Dispose();
							}
						}
						val = System.Threading.Tasks.Task.WhenAll((System.Collections.Generic.IEnumerable<System.Threading.Tasks.Task>)_0024VB_0024ResumableLocal_tasks_00241).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 1);
							_0024A0 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_19_PingAllServers>(ref val, ref _this);
							return;
						}
						break;
					case 1:
						num = (_0024State = -1);
						val = _0024A0;
						_0024A0 = default(TaskAwaiter);
						break;
					}
					val.GetResult();
					val = default(TaskAwaiter);
				}
				catch (OperationCanceledException val4)
				{
					ProjectData.SetProjectError((System.Exception)val4);
					OperationCanceledException val5 = val4;
					ModBase.Log("PingAllServers 被取消", ModBase.LogLevel.Debug);
					ProjectData.ClearProjectError();
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					ModBase.Log(ex2, "PingAllServers 失败");
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

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_20_PingServer : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncTaskMethodBuilder<MinecraftServerInfo> _0024Builder;

		internal MinecraftServerInfo _0024VB_0024Local_server;

		internal CancellationToken _0024VB_0024Local_token;

		internal McPing _0024VB_0024ResumableLocal_query_00240;

		internal TaskAwaiter<ValueTuple<string, int>> _0024A0;

		internal TaskAwaiter<McPingResult> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_0275: Unknown result type (might be due to invalid IL or missing references)
			//IL_027b: Expected O, but got Unknown
			//IL_027d: Expected O, but got Unknown
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			MinecraftServerInfo result3;
			try
			{
				if ((uint)(num - -4) > 1u)
				{
					_ = 1;
				}
				try
				{
					ValueTuple<string, int> result;
					TaskAwaiter<ValueTuple<string, int>> awaiter;
					ValueTuple<string, int> val = default(ValueTuple<string, int>);
					switch (num)
					{
					case -3:
						num = (_0024State = -1);
						return;
					default:
						awaiter = ServerAddressResolver.GetReachableAddressAsync(_0024VB_0024Local_server.Address, _0024VB_0024Local_token).GetAwaiter();
						if (!awaiter.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = awaiter;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<ValueTuple<string, int>>, VB_0024StateMachine_20_PingServer>(ref awaiter, ref _this);
							return;
						}
						goto IL_00a8;
					case 0:
						num = (_0024State = -1);
						awaiter = _0024A0;
						_0024A0 = default(TaskAwaiter<ValueTuple<string, int>>);
						goto IL_00a8;
					case -4:
					case 1:
						break;
						IL_00a8:
						result = awaiter.GetResult();
						awaiter = default(TaskAwaiter<ValueTuple<string, int>>);
						val = result;
						_0024VB_0024ResumableLocal_query_00240 = new McPing(val.Item1, val.Item2);
						break;
					}
					try
					{
						TaskAwaiter<McPingResult> awaiter2;
						switch (num)
						{
						case -4:
							num = (_0024State = -1);
							return;
						default:
							ModBase.Log("Pinging server: " + _0024VB_0024Local_server.Address + ":" + Conversions.ToString(val.Item2));
							awaiter2 = _0024VB_0024ResumableLocal_query_00240.PingAsync(_0024VB_0024Local_token).GetAwaiter();
							if (!awaiter2.IsCompleted)
							{
								num = (_0024State = 1);
								_0024A1 = awaiter2;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<McPingResult>, VB_0024StateMachine_20_PingServer>(ref awaiter2, ref _this);
								return;
							}
							break;
						case 1:
							num = (_0024State = -1);
							awaiter2 = _0024A1;
							_0024A1 = default(TaskAwaiter<McPingResult>);
							break;
						}
						McPingResult result2 = awaiter2.GetResult();
						awaiter2 = default(TaskAwaiter<McPingResult>);
						McPingResult mcPingResult = result2;
						ModBase.Log("Ping result: " + (((object)mcPingResult != null) ? "Success" : "Failed"));
						if ((object)mcPingResult != null)
						{
							_0024VB_0024Local_server.Status = ServerStatus.Online;
							_0024VB_0024Local_server.PlayerCount = mcPingResult.Players.Online;
							_0024VB_0024Local_server.MaxPlayers = mcPingResult.Players.Max;
							_0024VB_0024Local_server.Description = mcPingResult.Description;
							_0024VB_0024Local_server.Version = mcPingResult.Version.Name;
							_0024VB_0024Local_server.Ping = checked((int)mcPingResult.Latency);
							_0024VB_0024Local_server.Icon = mcPingResult.Favicon;
						}
						else
						{
							_0024VB_0024Local_server.Status = ServerStatus.Offline;
						}
					}
					finally
					{
						if (num < 0 && _0024VB_0024ResumableLocal_query_00240 != null)
						{
							((System.IDisposable)_0024VB_0024ResumableLocal_query_00240).Dispose();
						}
					}
				}
				catch (OperationCanceledException val2)
				{
					ProjectData.SetProjectError((System.Exception)val2);
					OperationCanceledException val3 = val2;
					_0024VB_0024Local_server.Status = ServerStatus.Offline;
					ModBase.Log("Ping 服务器被取消: " + _0024VB_0024Local_server.Address, ModBase.LogLevel.Debug);
					ProjectData.ClearProjectError();
				}
				catch (System.Exception ex)
				{
					ProjectData.SetProjectError(ex);
					System.Exception ex2 = ex;
					_0024VB_0024Local_server.Status = ServerStatus.Offline;
					ModBase.Log(ex2, $"Ping 服务器失败: {_0024VB_0024Local_server.Address}:{_0024VB_0024Local_server.Port}");
					ProjectData.ClearProjectError();
				}
				result3 = _0024VB_0024Local_server;
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
			_0024Builder.SetResult(result3);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			_0024Builder.SetStateMachine(stateMachine);
		}
	}

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_6_PageLoaded : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_e;

		internal RoutedEventArgs _0024VB_0024Local_sender;

		internal PageInstanceServer _0024VB_0024Me;

		internal System.Collections.Generic.IEnumerator<MinecraftServerInfo> _0024S0;

		internal TaskAwaiter _0024A0;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				if (num != 0)
				{
					ServerList.Clear();
					ServerCardList.Clear();
					((Panel)_0024VB_0024Me.PanServers).Children.Clear();
					val = _0024VB_0024Me.LoadServersFromFile().GetAwaiter();
					if (!val.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = val;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_6_PageLoaded>(ref val, ref _this);
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
				_0024VB_0024Me.RefreshTip();
				try
				{
					_0024S0 = ServerList.GetEnumerator();
					while (_0024S0.MoveNext())
					{
						MinecraftServerInfo current = _0024S0.Current;
						ServerCard serverCard = new ServerCard();
						serverCard.RemoveServer += new EventHandler(_0024VB_0024Me.RemoveServerEvent);
						serverCard.EditServer += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
						{
							_0024VB_0024Me.EditServer(RuntimeHelpers.GetObjectValue(a0), (ServerCard.ResultEventArgs)(object)a1);
						});
						serverCard.UpdateServerInfo(current);
						ServerCardList.Add(serverCard);
						((Panel)_0024VB_0024Me.PanServers).Children.Add((UIElement)(object)serverCard);
					}
				}
				finally
				{
					if (num < 0)
					{
						((System.IDisposable)_0024S0)?.Dispose();
					}
				}
				_0024VB_0024Me.PingAllServers();
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
	internal sealed class VB_0024StateMachine_8_RemoveServerEvent : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal EventArgs _0024VB_0024Local_e;

		internal PageInstanceServer _0024VB_0024Me;

		internal int _0024VB_0024ResumableLocal_index_00240;

		internal TaskAwaiter<NbtList> _0024A0;

		internal TaskAwaiter<bool> _0024A1;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Expected O, but got Unknown
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f4: Expected O, but got Unknown
			int num = _0024State;
			try
			{
				TaskAwaiter<NbtList> awaiter;
				if (num == 0)
				{
					num = (_0024State = -1);
					awaiter = _0024A0;
					_0024A0 = default(TaskAwaiter<NbtList>);
					goto IL_00c9;
				}
				TaskAwaiter<bool> awaiter2;
				if (num == 1)
				{
					num = (_0024State = -1);
					awaiter2 = _0024A1;
					_0024A1 = default(TaskAwaiter<bool>);
					goto IL_0178;
				}
				_0024VB_0024ResumableLocal_index_00240 = ((Panel)_0024VB_0024Me.PanServers).Children.IndexOf((UIElement)_0024VB_0024Local_sender);
				if (_0024VB_0024ResumableLocal_index_00240 >= 0)
				{
					awaiter = NbtFileHandler.ReadTagInNbtFileAsync<NbtList>(Path.Combine(PageInstanceLeft.Instance.PathIndie, "servers.dat"), "servers", default(CancellationToken)).GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = awaiter;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<NbtList>, VB_0024StateMachine_8_RemoveServerEvent>(ref awaiter, ref _this);
						return;
					}
					goto IL_00c9;
				}
				ModMain.Hint("无法找到服务器在列表中的索引", ModMain.HintType.Critical);
				goto end_IL_0007;
				IL_0178:
				bool result = awaiter2.GetResult();
				awaiter2 = default(TaskAwaiter<bool>);
				if (!result)
				{
					ModMain.Hint("无法写入服务器数据文件", ModMain.HintType.Critical);
				}
				else
				{
					ServerList.RemoveAt(_0024VB_0024ResumableLocal_index_00240);
					ServerCardList.Remove((ServerCard)_0024VB_0024Local_sender);
					if (ServerList.Count == 0)
					{
						_0024VB_0024Me.RefreshTip();
					}
					((Panel)_0024VB_0024Me.PanServers).Children.Remove((UIElement)_0024VB_0024Local_sender);
					ModMain.Hint("服务器已移除", ModMain.HintType.Finish);
				}
				goto end_IL_0007;
				IL_00c9:
				NbtList result2 = awaiter.GetResult();
				awaiter = default(TaskAwaiter<NbtList>);
				NbtList val = result2;
				if (val != null)
				{
					val.RemoveAt(_0024VB_0024ResumableLocal_index_00240);
					awaiter2 = NbtFileHandler.WriteTagInNbtFileAsync((NbtTag)(NbtList)val.Clone(), PageInstanceLeft.Instance.PathIndie + "servers.dat", (NbtCompression)1).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_0024State = 1);
						_0024A1 = awaiter2;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, VB_0024StateMachine_8_RemoveServerEvent>(ref awaiter2, ref _this);
						return;
					}
					goto IL_0178;
				}
				ModMain.Hint("无法读取服务器数据文件", ModMain.HintType.Critical);
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

	[StructLayout(3)]
	[CompilerGenerated]
	internal sealed class VB_0024StateMachine_9_EditServer : IAsyncStateMachine
	{
		public int _0024State;

		public AsyncVoidMethodBuilder _0024Builder;

		internal object _0024VB_0024Local_sender;

		internal ServerCard.ResultEventArgs _0024VB_0024Local_e;

		internal PageInstanceServer _0024VB_0024Me;

		internal TaskAwaiter<NbtList> _0024A0;

		internal TaskAwaiter<bool> _0024A1;

		internal TaskAwaiter _0024A2;

		[CompilerGenerated]
		void IAsyncStateMachine.MoveNext()
		{
			var _this = this;
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0261: Unknown result type (might be due to invalid IL or missing references)
			//IL_0266: Unknown result type (might be due to invalid IL or missing references)
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Expected O, but got Unknown
			//IL_0219: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0226: Unknown result type (might be due to invalid IL or missing references)
			//IL_022b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Expected O, but got Unknown
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Expected O, but got Unknown
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Expected O, but got Unknown
			//IL_016c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			int num = _0024State;
			try
			{
				TaskAwaiter val;
				bool result;
				TaskAwaiter<bool> awaiter;
				NbtList result2;
				TaskAwaiter<NbtList> awaiter2;
				NbtList val2;
				switch (num)
				{
				default:
					awaiter2 = NbtFileHandler.ReadTagInNbtFileAsync<NbtList>(PageInstanceLeft.Instance.PathIndie + "servers.dat", "servers", default(CancellationToken)).GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						num = (_0024State = 0);
						_0024A0 = awaiter2;
						_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<NbtList>, VB_0024StateMachine_9_EditServer>(ref awaiter2, ref _this);
						return;
					}
					goto IL_008f;
				case 0:
					num = (_0024State = -1);
					awaiter2 = _0024A0;
					_0024A0 = default(TaskAwaiter<NbtList>);
					goto IL_008f;
				case 1:
					num = (_0024State = -1);
					awaiter = _0024A1;
					_0024A1 = default(TaskAwaiter<bool>);
					goto IL_01bd;
				case 2:
					{
						num = (_0024State = -1);
						val = _0024A2;
						_0024A2 = default(TaskAwaiter);
						break;
					}
					IL_01bd:
					result = awaiter.GetResult();
					awaiter = default(TaskAwaiter<bool>);
					if (result)
					{
						ServerCard obj = _0024VB_0024Local_sender as ServerCard;
						obj.Server.Name = _0024VB_0024Local_e.Param1;
						obj.Server.Address = _0024VB_0024Local_e.Param2;
						val = obj.RefreshServerStatus(withHint: true).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 2);
							_0024A2 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine_9_EditServer>(ref val, ref _this);
							return;
						}
						break;
					}
					ModMain.Hint("无法写入服务器数据文件", ModMain.HintType.Critical);
					goto end_IL_0007;
					IL_008f:
					result2 = awaiter2.GetResult();
					awaiter2 = default(TaskAwaiter<NbtList>);
					val2 = result2;
					if (val2 == null)
					{
						ModMain.Hint("无法读取服务器数据文件", ModMain.HintType.Critical);
					}
					else
					{
						int num2 = ((Panel)_0024VB_0024Me.PanServers).Children.IndexOf((UIElement)_0024VB_0024Local_sender);
						if (num2 >= 0 && num2 < val2.Count)
						{
							NbtTag obj2 = val2[num2];
							NbtTag obj3 = ((obj2 is NbtCompound) ? obj2 : null);
							((NbtCompound)obj3)["name"] = (NbtTag)new NbtString("name", _0024VB_0024Local_e.Param1);
							((NbtCompound)obj3)["ip"] = (NbtTag)new NbtString("ip", _0024VB_0024Local_e.Param2);
							awaiter = NbtFileHandler.WriteTagInNbtFileAsync((NbtTag)(NbtList)val2.Clone(), PageInstanceLeft.Instance.PathIndie + "servers.dat", (NbtCompression)1).GetAwaiter();
							if (!awaiter.IsCompleted)
							{
								num = (_0024State = 1);
								_0024A1 = awaiter;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter<bool>, VB_0024StateMachine_9_EditServer>(ref awaiter, ref _this);
								return;
							}
							goto IL_01bd;
						}
						ModMain.Hint("无法找到服务器在列表中的索引", ModMain.HintType.Critical);
					}
					goto end_IL_0007;
				}
				val.GetResult();
				val = default(TaskAwaiter);
				ModMain.Hint("服务器信息已更新", ModMain.HintType.Finish);
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
	internal sealed class _Closure_0024__10_002D0
	{
		public System.Exception _0024VB_0024Local_ex;

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			ModMain.Hint("刷新服务器列表失败：" + _0024VB_0024Local_ex.Message, ModMain.HintType.Critical);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__12_002D0
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine___Lambda_0024__0 : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncTaskMethodBuilder _0024Builder;

			internal _Closure_0024__12_002D0 _0024VB_0024NonLocal__Closure_0024__12_002D0;

			internal TaskAwaiter _0024A0;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_005d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0062: Unknown result type (might be due to invalid IL or missing references)
				//IL_0069: Unknown result type (might be due to invalid IL or missing references)
				//IL_0018: Unknown result type (might be due to invalid IL or missing references)
				//IL_001e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0024: Unknown result type (might be due to invalid IL or missing references)
				//IL_0029: Unknown result type (might be due to invalid IL or missing references)
				//IL_0078: Unknown result type (might be due to invalid IL or missing references)
				//IL_003d: Unknown result type (might be due to invalid IL or missing references)
				//IL_003e: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				try
				{
					TaskAwaiter val;
					if (num != 0)
					{
						val = _0024VB_0024NonLocal__Closure_0024__12_002D0._0024VB_0024Local_serverCard.RefreshServerStatus(withHint: false).GetAwaiter();
						if (!val.IsCompleted)
						{
							num = (_0024State = 0);
							_0024A0 = val;
							_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine___Lambda_0024__0>(ref val, ref _this);
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

		public ServerCard _0024VB_0024Local_serverCard;

		[SpecialName]
		[AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__0))]
		internal System.Threading.Tasks.Task _Lambda_0024__0()
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__12_002D0 = this;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
			return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__19_002D0
	{
		[StructLayout(3)]
		[CompilerGenerated]
		internal sealed class VB_0024StateMachine___Lambda_0024__0 : IAsyncStateMachine
		{
			public int _0024State;

			public AsyncTaskMethodBuilder _0024Builder;

			internal _Closure_0024__19_002D0 _0024VB_0024NonLocal__Closure_0024__19_002D0;

			internal TaskAwaiter _0024A0;

			[CompilerGenerated]


			void IAsyncStateMachine.MoveNext()
			{
				var _this = this;
				//IL_0084: Unknown result type (might be due to invalid IL or missing references)
				//IL_0089: Unknown result type (might be due to invalid IL or missing references)
				//IL_0090: Unknown result type (might be due to invalid IL or missing references)
				//IL_009f: Unknown result type (might be due to invalid IL or missing references)
				//IL_003e: Unknown result type (might be due to invalid IL or missing references)
				//IL_0048: Unknown result type (might be due to invalid IL or missing references)
				//IL_004d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0061: Unknown result type (might be due to invalid IL or missing references)
				//IL_0062: Unknown result type (might be due to invalid IL or missing references)
				int num = _0024State;
				try
				{
					if (num != -3)
					{
					}
					try
					{
						TaskAwaiter val;
						switch (num)
						{
						case -3:
							num = (_0024State = -1);
							return;
						default:
							val = _0024VB_0024NonLocal__Closure_0024__19_002D0._0024VB_0024Local_currentServer.RefreshServerStatus(withHint: false, _0024VB_0024NonLocal__Closure_0024__19_002D0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_token).GetAwaiter();
							if (!val.IsCompleted)
							{
								num = (_0024State = 0);
								_0024A0 = val;
								_0024Builder.AwaitUnsafeOnCompleted<TaskAwaiter, VB_0024StateMachine___Lambda_0024__0>(ref val, ref _this);
								return;
							}
							break;
						case 0:
							num = (_0024State = -1);
							val = _0024A0;
							_0024A0 = default(TaskAwaiter);
							break;
						}
						val.GetResult();
						val = default(TaskAwaiter);
					}
					catch (System.Exception ex)
					{
						ProjectData.SetProjectError(ex);
						System.Exception ex2 = ex;
						ModBase.Log(ex2, $"Ping 服务器失败: {_0024VB_0024NonLocal__Closure_0024__19_002D0._0024VB_0024Local_currentServer}");
						ProjectData.ClearProjectError();
					}
					finally
					{
						if (num < 0)
						{
							_0024VB_0024NonLocal__Closure_0024__19_002D0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_semaphore.Release();
						}
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

		public ServerCard _0024VB_0024Local_currentServer;

		public _Closure_0024__19_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__19_002D0(_Closure_0024__19_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_currentServer = arg0._0024VB_0024Local_currentServer;
			}
		}

		[SpecialName]
		[AsyncStateMachine(typeof(VB_0024StateMachine___Lambda_0024__0))]
		internal System.Threading.Tasks.Task _Lambda_0024__0()
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			VB_0024StateMachine___Lambda_0024__0 vB_0024StateMachine___Lambda_0024__ = default(VB_0024StateMachine___Lambda_0024__0);
			vB_0024StateMachine___Lambda_0024__._0024VB_0024NonLocal__Closure_0024__19_002D0 = this;
			vB_0024StateMachine___Lambda_0024__._0024State = -1;
			vB_0024StateMachine___Lambda_0024__._0024Builder = AsyncTaskMethodBuilder.Create();
			vB_0024StateMachine___Lambda_0024__._0024Builder.Start<VB_0024StateMachine___Lambda_0024__0>(ref vB_0024StateMachine___Lambda_0024__);
			return vB_0024StateMachine___Lambda_0024__._0024Builder.Task;
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__19_002D1
	{
		public CancellationToken _0024VB_0024Local_token;

		public SemaphoreSlim _0024VB_0024Local_semaphore;

		public _Closure_0024__19_002D1(_Closure_0024__19_002D1 arg0)
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			if (arg0 != null)
			{
				_0024VB_0024Local_token = arg0._0024VB_0024Local_token;
				_0024VB_0024Local_semaphore = arg0._0024VB_0024Local_semaphore;
			}
		}
	}

	public static readonly List<MinecraftServerInfo> ServerList = new List<MinecraftServerInfo>();

	private static readonly List<ServerCard> ServerCardList = new List<ServerCard>();

	private System.DateTime _lastRefresh;

	private const int DebounceInterval = 2000;

	private CancellationTokenSource _cts;

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
	[field: AccessedThroughProperty("PanNoServer")]
	internal virtual MyCard PanNoServer
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
	[field: AccessedThroughProperty("PanServers")]
	internal virtual StackPanel PanServers
	{
		[CompilerGenerated]
		get;
		[MethodImpl(32)]
		[CompilerGenerated]
		set;
	}

	public PageInstanceServer()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		((FrameworkElement)this).Loaded += new RoutedEventHandler(PageLoaded);
		((UIElement)this).IsVisibleChanged += new DependencyPropertyChangedEventHandler(PageInstanceServer_IsVisibleChanged);
		_lastRefresh = System.DateTime.MinValue;
		_cts = null;
		InitializeComponent();
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_6_PageLoaded))]
	private void PageLoaded(object e, RoutedEventArgs sender)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_6_PageLoaded vB_0024StateMachine_6_PageLoaded = default(VB_0024StateMachine_6_PageLoaded);
		vB_0024StateMachine_6_PageLoaded._0024VB_0024Me = this;
		vB_0024StateMachine_6_PageLoaded._0024VB_0024Local_e = e;
		vB_0024StateMachine_6_PageLoaded._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_6_PageLoaded._0024State = -1;
		vB_0024StateMachine_6_PageLoaded._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_6_PageLoaded._0024Builder.Start<VB_0024StateMachine_6_PageLoaded>(ref vB_0024StateMachine_6_PageLoaded);
	}

	private void PageInstanceServer_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
	{
		if (!((UIElement)this).IsVisible && _cts != null)
		{
			_cts.Cancel();
			_cts.Dispose();
			_cts = null;
		}
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_8_RemoveServerEvent))]
	private void RemoveServerEvent(object sender, EventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_8_RemoveServerEvent vB_0024StateMachine_8_RemoveServerEvent = default(VB_0024StateMachine_8_RemoveServerEvent);
		vB_0024StateMachine_8_RemoveServerEvent._0024VB_0024Me = this;
		vB_0024StateMachine_8_RemoveServerEvent._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_8_RemoveServerEvent._0024VB_0024Local_e = e;
		vB_0024StateMachine_8_RemoveServerEvent._0024State = -1;
		vB_0024StateMachine_8_RemoveServerEvent._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_8_RemoveServerEvent._0024Builder.Start<VB_0024StateMachine_8_RemoveServerEvent>(ref vB_0024StateMachine_8_RemoveServerEvent);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_9_EditServer))]
	private void EditServer(object sender, ServerCard.ResultEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_9_EditServer vB_0024StateMachine_9_EditServer = default(VB_0024StateMachine_9_EditServer);
		vB_0024StateMachine_9_EditServer._0024VB_0024Me = this;
		vB_0024StateMachine_9_EditServer._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_9_EditServer._0024VB_0024Local_e = e;
		vB_0024StateMachine_9_EditServer._0024State = -1;
		vB_0024StateMachine_9_EditServer._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_9_EditServer._0024Builder.Start<VB_0024StateMachine_9_EditServer>(ref vB_0024StateMachine_9_EditServer);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_10_RefreshServers))]
	public void RefreshServers()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_10_RefreshServers vB_0024StateMachine_10_RefreshServers = default(VB_0024StateMachine_10_RefreshServers);
		vB_0024StateMachine_10_RefreshServers._0024VB_0024Me = this;
		vB_0024StateMachine_10_RefreshServers._0024State = -1;
		vB_0024StateMachine_10_RefreshServers._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_10_RefreshServers._0024Builder.Start<VB_0024StateMachine_10_RefreshServers>(ref vB_0024StateMachine_10_RefreshServers);
	}

	private void BtnRefresh_Click(object sender, MouseButtonEventArgs e)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		TimeSpan val = System.DateTime.Now - _lastRefresh;
		if (val.TotalMilliseconds < 2000.0)
		{
			ModMain.Hint("请勿频繁刷新！");
			return;
		}
		_lastRefresh = System.DateTime.Now;
		ModMain.Hint("正在刷新服务器列表，请稍候...");
		try
		{
			RefreshServers();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "刷新服务器列表失败", ModBase.LogLevel.Feedback);
			ModMain.Hint("刷新服务器列表失败：" + ex2.Message, ModMain.HintType.Critical);
			ProjectData.ClearProjectError();
		}
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_12_BtnAddServer_Click))]
	private void BtnAddServer_Click(object sender, MouseButtonEventArgs e)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_12_BtnAddServer_Click vB_0024StateMachine_12_BtnAddServer_Click = default(VB_0024StateMachine_12_BtnAddServer_Click);
		vB_0024StateMachine_12_BtnAddServer_Click._0024VB_0024Me = this;
		vB_0024StateMachine_12_BtnAddServer_Click._0024VB_0024Local_sender = sender;
		vB_0024StateMachine_12_BtnAddServer_Click._0024VB_0024Local_e = e;
		vB_0024StateMachine_12_BtnAddServer_Click._0024State = -1;
		vB_0024StateMachine_12_BtnAddServer_Click._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_12_BtnAddServer_Click._0024Builder.Start<VB_0024StateMachine_12_BtnAddServer_Click>(ref vB_0024StateMachine_12_BtnAddServer_Click);
	}

	public static ValueTuple<string, string, bool> GetServerInfo(MinecraftServerInfo server)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		string name = server.Name;
		Collection<Validate> obj = new Collection<Validate>();
		obj.Add((Validate)new ValidateNullOrWhiteSpace());
		string text = ModMain.MyMsgBoxInput("编辑服务器信息", "请输入新的服务器名称：", name, obj);
		ValueTuple<string, string, bool> result = default(ValueTuple<string, string, bool>);
		if (string.IsNullOrEmpty(text))
		{
			result = new(string.Empty, string.Empty, false);
		}
		else
		{
			string address = server.Address;
			Collection<Validate> obj2 = new Collection<Validate>();
			obj2.Add((Validate)new ValidateNullOrWhiteSpace());
			string text2 = ModMain.MyMsgBoxInput("编辑服务器信息", "请输入新的服务器地址：", address, obj2);
			if (string.IsNullOrEmpty(text2))
			{
				result = new(string.Empty, string.Empty, false);
			}
			else
			{
				result = new(text, text2, true);
			}
		}
		return result;
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_14_LoadServersFromFile))]
	private System.Threading.Tasks.Task LoadServersFromFile()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_14_LoadServersFromFile vB_0024StateMachine_14_LoadServersFromFile = default(VB_0024StateMachine_14_LoadServersFromFile);
		vB_0024StateMachine_14_LoadServersFromFile._0024VB_0024Me = this;
		vB_0024StateMachine_14_LoadServersFromFile._0024State = -1;
		vB_0024StateMachine_14_LoadServersFromFile._0024Builder = AsyncTaskMethodBuilder.Create();
		vB_0024StateMachine_14_LoadServersFromFile._0024Builder.Start<VB_0024StateMachine_14_LoadServersFromFile>(ref vB_0024StateMachine_14_LoadServersFromFile);
		return vB_0024StateMachine_14_LoadServersFromFile._0024Builder.Task;
	}

	private void ParseServersFromNBT(NbtList serversList)
	{
		checked
		{
			if (serversList != null)
			{
				ModBase.Log($"Found {serversList.Count} servers:");
				int num = serversList.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					NbtTag obj = serversList[i];
					NbtCompound val = (NbtCompound)(object)((obj is NbtCompound) ? obj : null);
					if (val != null)
					{
						NbtString obj2 = val.Get<NbtString>("ip");
						string text = ((obj2 != null) ? obj2.Value : null) ?? "Unknown";
						NbtString obj3 = val.Get<NbtString>("name");
						string text2 = ((obj3 != null) ? obj3.Value : null) ?? "Unknown";
						NbtString obj4 = val.Get<NbtString>("icon");
						string icon = ((obj4 != null) ? obj4.Value : null);
						ModBase.Log($"服务器 {i + 1}:");
						ModBase.Log($"  名字: {text2}");
						ModBase.Log($"  IP: {text}");
						ServerList.Add(new MinecraftServerInfo
						{
							Name = text2,
							Address = text,
							Status = ServerStatus.Unknown,
							Icon = icon
						});
					}
				}
			}
			else
			{
				ModBase.Log("No 'servers' list found in servers.dat.");
			}
		}
	}

	private void UpdateServerUi()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		((Panel)PanServers).Children.Clear();
		RefreshTip();
		System.Collections.Generic.IEnumerator<MinecraftServerInfo> enumerator = default(System.Collections.Generic.IEnumerator<MinecraftServerInfo>);
		try
		{
			enumerator = ServerList.GetEnumerator();
			while (enumerator.MoveNext())
			{
				MinecraftServerInfo current = enumerator.Current;
				ServerCard serverCard = new ServerCard();
				serverCard.RemoveServer += new EventHandler(RemoveServerEvent);
				serverCard.EditServer += (EventHandler)([SpecialName] [CompilerGenerated] (object a0, EventArgs a1) =>
				{
					EditServer(RuntimeHelpers.GetObjectValue(a0), (ServerCard.ResultEventArgs)(object)a1);
				});
				serverCard.UpdateServerInfo(current);
				ServerCardList.Add(serverCard);
				((Panel)PanServers).Children.Add((UIElement)(object)serverCard);
			}
		}
		finally
		{
			((System.IDisposable)enumerator).Dispose();
		}
	}

	private void RefreshTip()
	{
		if (ServerList.Count == 0)
		{
			ModBase.Log("没有找到任何服务器");
			((UIElement)PanNoServer).Visibility = (Visibility)0;
			((UIElement)PanContent).Visibility = (Visibility)2;
			((UIElement)PanServers).Visibility = (Visibility)2;
		}
		else
		{
			ModBase.Log("找到服务器列表");
			((UIElement)PanNoServer).Visibility = (Visibility)2;
			((UIElement)PanContent).Visibility = (Visibility)0;
			((UIElement)PanServers).Visibility = (Visibility)0;
		}
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_19_PingAllServers))]
	private void PingAllServers()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		VB_0024StateMachine_19_PingAllServers vB_0024StateMachine_19_PingAllServers = default(VB_0024StateMachine_19_PingAllServers);
		vB_0024StateMachine_19_PingAllServers._0024VB_0024Me = this;
		vB_0024StateMachine_19_PingAllServers._0024State = -1;
		vB_0024StateMachine_19_PingAllServers._0024Builder = AsyncVoidMethodBuilder.Create();
		vB_0024StateMachine_19_PingAllServers._0024Builder.Start<VB_0024StateMachine_19_PingAllServers>(ref vB_0024StateMachine_19_PingAllServers);
	}

	[AsyncStateMachine(typeof(VB_0024StateMachine_20_PingServer))]
	public static async System.Threading.Tasks.Task<MinecraftServerInfo> PingServer(MinecraftServerInfo server, CancellationToken token)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			ValueTuple<string, int> val = await ServerAddressResolver.GetReachableAddressAsync(server.Address, token);
			using McPing mcPing = new McPing(val.Item1, val.Item2);
			ModBase.Log("Pinging server: " + server.Address + ":" + Conversions.ToString(val.Item2));
			McPingResult mcPingResult = await mcPing.PingAsync(token);
			ModBase.Log("Ping result: " + (((object)mcPingResult != null) ? "Success" : "Failed"));
			if ((object)mcPingResult != null)
			{
				server.Status = ServerStatus.Online;
				server.PlayerCount = mcPingResult.Players.Online;
				server.MaxPlayers = mcPingResult.Players.Max;
				server.Description = mcPingResult.Description;
				server.Version = mcPingResult.Version.Name;
				server.Ping = checked((int)mcPingResult.Latency);
				server.Icon = mcPingResult.Favicon;
			}
			else
			{
				server.Status = ServerStatus.Offline;
			}
		}
		catch (OperationCanceledException val2)
		{
			ProjectData.SetProjectError((System.Exception)val2);
			server.Status = ServerStatus.Offline;
			ModBase.Log("Ping 服务器被取消: " + server.Address, ModBase.LogLevel.Debug);
			ProjectData.ClearProjectError();
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			server.Status = ServerStatus.Offline;
			ModBase.Log(ex2, $"Ping 服务器失败: {server.Address}:{server.Port}");
			ProjectData.ClearProjectError();
		}
		return server;
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
			Uri val = new Uri("/Plain Craft Launcher 2;V2.13.3.0;component/pages/pageinstance/pageinstanceserver.xaml", (UriKind)2);
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
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		switch (connectionId)
		{
		case 1:
			PanBack = (MyScrollViewer)target;
			break;
		case 2:
			PanNoServer = (MyCard)target;
			break;
		case 3:
			PanContent = (MyCard)target;
			break;
		case 4:
			PanServers = (StackPanel)target;
			break;
		default:
			_contentLoaded = true;
			break;
		}
	}
}
