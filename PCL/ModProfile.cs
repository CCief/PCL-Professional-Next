using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;

namespace PCL;

[StandardModule]
public sealed class ModProfile
{
	public class McProfile
	{
		public ModLaunch.McLoginType Type;

		public string Uuid;

		public string Username;

		public string Server;

		public string ServerName;

		public string AccessToken;

		public string RefreshToken;

		public string Name;

		public string Password;

		public long Expires;

		public string Desc;

		public string ClientToken;

		public string RawJson;

		public string SkinHeadId;

		[Obsolete("暂时弃用，应当使用 AccessToken 与 RefreshToken")]
		public string IdentityId;
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _Closure_0024__
	{
		public static readonly _Closure_0024__ _0024I;

		public static Action _0024I9_002D1;

		public static Action _0024I9_002D2;

		public static Action _0024I9_002D3;

		public static Action _0024I14_002D3;

		static _Closure_0024__()
		{
			_0024I = new _Closure_0024__();
		}

		[SpecialName]
		internal void _Lambda_0024__9_002D1()
		{
			ModMain.FrmLaunchLeft.RefreshPage(Anim: true, ModLaunch.McLoginType.Ms);
		}

		[SpecialName]
		internal void _Lambda_0024__9_002D2()
		{
			ModMain.FrmLaunchLeft.RefreshPage(Anim: true, ModLaunch.McLoginType.Auth);
		}

		[SpecialName]
		internal void _Lambda_0024__9_002D3()
		{
			ModMain.FrmLaunchLeft.RefreshPage(Anim: true, ModLaunch.McLoginType.Legacy);
		}

		[SpecialName]
		internal void _Lambda_0024__14_002D3()
		{
			ModMain.FrmLoginProfile.RefreshProfileList();
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__14_002D0
	{
		public int _0024VB_0024Local_type;

		public string _0024VB_0024Local_outsidePath;

		public _Closure_0024__14_002D0(_Closure_0024__14_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_type = arg0._0024VB_0024Local_type;
				_0024VB_0024Local_outsidePath = arg0._0024VB_0024Local_outsidePath;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			_0024VB_0024Local_type = ModMain.MyMsgBox(string.Format("PCL CE 支持导入 HMCL 的全局账户列表，抑或是导出档案列表至 HMCL 全局账户列表。{0}你想要...？", (object)"\r\n"), "导入 / 导出档案", "导入", "导出", "取消", IsWarn: false, HighLight: true, ForceWait: true);
		}

		[SpecialName]
		internal void _Lambda_0024__1()
		{
			_0024VB_0024Local_type = ModMain.MyMsgBox(string.Format("PCL CE 支持导入 HMCL 的全局账户列表，抑或是导出档案列表至 HMCL 全局账户列表。{0}由于目前 PCL CE 不存在任何可用档案，无法导出档案。", (object)"\r\n"), "导入 / 导出档案", "导入", "取消", "", IsWarn: false, HighLight: true, ForceWait: true);
		}

		[SpecialName]
		internal void _Lambda_0024__2()
		{
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0349: Unknown result type (might be due to invalid IL or missing references)
			//IL_034e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c1: Expected O, but got Unknown
			JArray jArray;
			try
			{
				jArray = JArray.Parse(ModBase.ReadFile(_0024VB_0024Local_outsidePath));
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				jArray = new JArray();
				ProjectData.ClearProjectError();
			}
			List<McProfile> val = new List<McProfile>();
			int num = 0;
			System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator = jArray.GetEnumerator();
				System.Collections.Generic.IEnumerator<McProfile> enumerator2 = default(System.Collections.Generic.IEnumerator<McProfile>);
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					JToken current = enumerator.Current;
					McProfile mcProfile = null;
					bool flag = false;
					if ((string?)current["type"] == "microsoft")
					{
						try
						{
							enumerator2 = ProfileList.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								McProfile current2 = enumerator2.Current;
								if (current2.Type == ModLaunch.McLoginType.Ms && current2.Uuid == (string?)current["uuid"])
								{
									flag = true;
									break;
								}
							}
						}
						finally
						{
							((System.IDisposable)enumerator2).Dispose();
						}
						mcProfile = new McProfile
						{
							Type = ModLaunch.McLoginType.Ms,
							Uuid = (string?)current["uuid"],
							Username = (string?)current["displayName"],
							AccessToken = "",
							Expires = 1743779140286L,
							Desc = "",
							RawJson = "",
							SkinHeadId = ""
						};
						if (!flag)
						{
							val.Add(mcProfile);
						}
					}
					else if ((string?)current["type"] == "authlibInjector")
					{
						mcProfile = new McProfile
						{
							Type = ModLaunch.McLoginType.Auth,
							Uuid = (string?)current["uuid"],
							Username = (string?)current["displayName"],
							AccessToken = "",
							RefreshToken = "",
							Expires = 1743779140286L,
							Server = (string?)current["serverBaseURL"],
							ServerName = "",
							Name = (string?)current["username"],
							Password = "",
							ClientToken = (string?)current["clientToken"],
							Desc = "",
							SkinHeadId = ""
						};
						try
						{
							string serverName = JObject.Parse(Conversions.ToString(ModNet.NetGetCodeByRequestRetry(mcProfile.Server.Replace("/authserver", ""), Encoding.UTF8)))["meta"]["serverName"].ToString();
							mcProfile.ServerName = serverName;
						}
						catch (System.Exception ex3)
						{
							ProjectData.SetProjectError(ex3);
							System.Exception ex4 = ex3;
							ProfileLog("获取服务器名称失败，继续档案添加流程: " + ex4.ToString());
							ProjectData.ClearProjectError();
						}
						val.Add(mcProfile);
					}
					else
					{
						mcProfile = new McProfile
						{
							Type = ModLaunch.McLoginType.Legacy,
							Uuid = (string?)current["uuid"],
							Username = (string?)current["username"],
							Desc = "",
							SkinHeadId = ""
						};
						val.Add(mcProfile);
					}
					num = checked(num + 1);
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			System.Collections.Generic.IEnumerator<McProfile> enumerator3 = default(System.Collections.Generic.IEnumerator<McProfile>);
			try
			{
				enumerator3 = val.GetEnumerator();
				while (enumerator3.MoveNext())
				{
					McProfile current3 = enumerator3.Current;
					ProfileList.Add(current3);
				}
			}
			finally
			{
				((System.IDisposable)enumerator3).Dispose();
			}
			SaveProfile();
			ModMain.Hint($"已导入 {num} 个档案，部分档案可能需要重新验证密码！", ModMain.HintType.Finish);
			object action;
			if (_Closure_0024__._0024I14_002D3 != null)
			{
				action = _Closure_0024__._0024I14_002D3;
			}
			else
			{
				Action val2 = [SpecialName] () =>
				{
					ModMain.FrmLoginProfile.RefreshProfileList();
				};
				_Closure_0024__._0024I14_002D3 = val2;
				action = (object)val2;
			}
			ModBase.RunInUi((Action)action);
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__22_002D0
	{
		public ModMinecraft.McSkinInfo _0024VB_0024Local_skinInfo;

		public _Closure_0024__22_002D0(_Closure_0024__22_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_skinInfo = arg0._0024VB_0024Local_skinInfo;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_00fe: Expected O, but got Unknown
			try
			{
				string text;
				while (true)
				{
					if (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Loading)
					{
						ModLaunch.McLoginMsLoader.WaitForExit();
					}
					if (ModLaunch.McLoginMsLoader.State != ModBase.LoadState.Finished)
					{
						ModLaunch.McLoginMsLoader.WaitForExit(GetLoginData());
					}
					if (ModLaunch.McLoginMsLoader.State != ModBase.LoadState.Finished)
					{
						ModMain.Hint("登录失败，无法更改皮肤！", ModMain.HintType.Critical);
						return;
					}
					string accessToken = SelectedProfile.AccessToken;
					Dictionary<string, string> val = new Dictionary<string, string>();
					val.Add("Authorization", $"Bearer {accessToken}");
					val.Add("Accept", "*/*");
					val.Add("User-Agent", "MojangSharp/0.1");
					MultipartFormDataContent val2 = new MultipartFormDataContent();
					val2.Add((HttpContent)new StringContent(_0024VB_0024Local_skinInfo.IsSlim ? "slim" : "classic"), "variant");
					val2.Add((HttpContent)new ByteArrayContent(ModBase.ReadFileBytes(_0024VB_0024Local_skinInfo.LocalFile)), "file", ModBase.GetFileNameFromPath(_0024VB_0024Local_skinInfo.LocalFile));
					MultipartFormDataContent data = val2;
					text = ModNet.NetRequestRetry("https://api.minecraftservices.com/minecraft/profile/skins", "POST", data, null, DontRetryOnRefused: true, val);
					if (!text.Contains("request requires user authentication"))
					{
						break;
					}
					ModMain.Hint("正在登录，将在登录完成后继续更改皮肤……");
					ModLaunch.McLoginMsLoader.Start(GetLoginData(), IsForceRestart: true);
				}
				if (text.Contains("\"error\""))
				{
					ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject((object)"更改皮肤失败：", NewLateBinding.LateIndexGet(ModBase.GetJson(text), new object[] { "error" }, (string[])null))), ModMain.HintType.Critical);
					return;
				}
				ModBase.Log("[Skin] 皮肤修改返回值：\r\n" + text);
				JObject jObject = (JObject)ModBase.GetJson(text);
				if (jObject.ContainsKey("errorMessage"))
				{
					throw new System.Exception(jObject["errorMessage"].ToString());
				}
				System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator = ((System.Collections.Generic.IEnumerable<JToken>)jObject["skins"]).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						JObject jObject2 = (JObject)enumerator.Current;
						if (Operators.CompareString(jObject2["state"].ToString(), "ACTIVE", false) == 0)
						{
							MySkin.ReloadCache((string?)jObject2["url"]);
							return;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				throw new System.Exception("未知错误（" + text + "）");
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				if (ex2.GetType().Equals(typeof(TaskCanceledException)))
				{
					ModMain.Hint("更改皮肤失败：与 Mojang 皮肤服务器的连接超时，请检查你的网络是否通畅！", ModMain.HintType.Critical);
				}
				else
				{
					ModBase.Log(ex2, "更改皮肤失败", ModBase.LogLevel.Hint);
				}
				ProjectData.ClearProjectError();
			}
			finally
			{
				_isMsSkinChanging = false;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__24_002D0
	{
		public JObject _0024VB_0024Local_gotJson;

		public bool _0024VB_0024Local_finished;

		public _Closure_0024__24_002D1 _0024VB_0024NonLocal__0024VB_0024Closure_2;

		public _Closure_0024__24_002D0(_Closure_0024__24_002D0 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_gotJson = arg0._0024VB_0024Local_gotJson;
				_0024VB_0024Local_finished = arg0._0024VB_0024Local_finished;
			}
		}

		[SpecialName]
		internal void _Lambda_0024__0()
		{
			try
			{
				_0024VB_0024Local_gotJson = (JObject)ModNet.NetGetCodeByRequestRetry("https://api.mojang.com/users/profiles/minecraft/" + _0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_name, null, "", IsJson: true);
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				ProjectData.ClearProjectError();
			}
			finally
			{
				_0024VB_0024Local_finished = true;
			}
		}
	}

	[CompilerGenerated]
	internal sealed class _Closure_0024__24_002D1
	{
		public string _0024VB_0024Local_name;

		public _Closure_0024__24_002D1(_Closure_0024__24_002D1 arg0)
		{
			if (arg0 != null)
			{
				_0024VB_0024Local_name = arg0._0024VB_0024Local_name;
			}
		}
	}

	public static McProfile SelectedProfile = null;

	public static int LastUsedProfile = 0;

	public static List<McProfile> ProfileList = new List<McProfile>();

	public static bool IsCreatingProfile = false;

	private static bool _isMsSkinChanging = false;

	public static void ProfileLog(string content, ModBase.LogLevel level = ModBase.LogLevel.Normal)
	{
		ModBase.Log("[Profile] " + content, level);
	}

	public static void GetProfile()
	{
		ProfileLog("开始获取本地档案");
		ProfileList.Clear();
		try
		{
			if (!Directory.Exists(ModBase.PathAppdataConfig))
			{
				Directory.CreateDirectory(ModBase.PathAppdataConfig);
			}
			string text = Path.Combine(ModBase.PathAppdataConfig, "profiles.json");
			if (!File.Exists(text))
			{
				((Stream)File.Create(text)).Close();
				ModBase.WriteFile(text, "{\"lastUsed\":0,\"profiles\":[]}");
			}
			object obj = ModBase.ReadFile(text);
			if (string.IsNullOrEmpty((string)obj))
			{
				obj = "{}";
			}
			JObject jObject = JObject.Parse((string)obj);
			LastUsedProfile = (int)jObject["lastUsed"];
			JArray jArray = (JArray)jObject["profiles"];
			System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator = jArray.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator).MoveNext())
				{
					JToken current = enumerator.Current;
					McProfile mcProfile = null;
					mcProfile = ((!((string?)current["type"] == "microsoft")) ? ((!((string?)current["type"] == "authlib")) ? new McProfile
					{
						Type = ModLaunch.McLoginType.Legacy,
						Uuid = (string?)current["uuid"],
						Username = (string?)current["username"],
						Desc = (string?)current["desc"],
						SkinHeadId = (string?)current["skinHeadId"]
					} : new McProfile
					{
						Type = ModLaunch.McLoginType.Auth,
						Uuid = (string?)current["uuid"],
						Username = (string?)current["username"],
						AccessToken = ModSecret.SecretDecrypt((string?)current["accessToken"]),
						RefreshToken = ModSecret.SecretDecrypt((string?)current["refreshToken"]),
						Expires = (long)current["expires"],
						Server = (string?)current["server"],
						ServerName = (string?)current["serverName"],
						Name = ModSecret.SecretDecrypt((string?)current["name"]),
						Password = ModSecret.SecretDecrypt((string?)current["password"]),
						ClientToken = ModSecret.SecretDecrypt((string?)current["clientToken"]),
						Desc = (string?)current["desc"],
						SkinHeadId = (string?)current["skinHeadId"]
					}) : new McProfile
					{
						Type = ModLaunch.McLoginType.Ms,
						Uuid = (string?)current["uuid"],
						Username = (string?)current["username"],
						AccessToken = ModSecret.SecretDecrypt((string?)current["accessToken"]),
						RefreshToken = ModSecret.SecretDecrypt((string?)current["refreshToken"]),
						Expires = (long)current["expires"],
						Desc = (string?)current["desc"],
						RawJson = ModSecret.SecretDecrypt((string?)current["rawJson"]),
						SkinHeadId = (string?)current["skinHeadId"]
					});
					ProfileList.Add(mcProfile);
				}
			}
			finally
			{
				((System.IDisposable)enumerator)?.Dispose();
			}
			ProfileLog($"获取到 {ProfileList.Count} 个档案");
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "读取档案列表失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public static void SaveProfile(JArray listJson = null)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			JObject jObject = new JObject();
			if (listJson != null)
			{
				jObject = new JObject
				{
					{ "lastUsed", LastUsedProfile },
					{ "profiles", listJson }
				};
			}
			else
			{
				JArray jArray = new JArray();
				System.Collections.Generic.IEnumerator<McProfile> enumerator = default(System.Collections.Generic.IEnumerator<McProfile>);
				try
				{
					enumerator = ProfileList.GetEnumerator();
					while (enumerator.MoveNext())
					{
						McProfile current = enumerator.Current;
						JObject jObject2 = null;
						jObject2 = ((current.Type != ModLaunch.McLoginType.Ms) ? ((current.Type != ModLaunch.McLoginType.Auth) ? new JObject
						{
							{ "type", "offline" },
							{ "uuid", current.Uuid },
							{ "username", current.Username },
							{ "desc", current.Desc },
							{ "skinHeadId", current.SkinHeadId }
						} : new JObject
						{
							{ "type", "authlib" },
							{ "uuid", current.Uuid },
							{ "username", current.Username },
							{
								"accessToken",
								ModSecret.SecretEncrypt(current.AccessToken)
							},
							{
								"refreshToken",
								ModSecret.SecretEncrypt(current.RefreshToken)
							},
							{ "expires", current.Expires },
							{ "server", current.Server },
							{ "serverName", current.ServerName },
							{
								"name",
								ModSecret.SecretEncrypt(current.Name)
							},
							{
								"password",
								ModSecret.SecretEncrypt(current.Password)
							},
							{
								"clientToken",
								ModSecret.SecretEncrypt(current.ClientToken)
							},
							{ "desc", current.Desc },
							{ "skinHeadId", current.SkinHeadId }
						}) : new JObject
						{
							{ "type", "microsoft" },
							{ "uuid", current.Uuid },
							{ "username", current.Username },
							{
								"accessToken",
								ModSecret.SecretEncrypt(current.AccessToken)
							},
							{
								"refreshToken",
								ModSecret.SecretEncrypt(current.RefreshToken)
							},
							{ "expires", current.Expires },
							{ "desc", current.Desc },
							{
								"rawJson",
								ModSecret.SecretEncrypt(current.RawJson)
							},
							{ "skinHeadId", current.SkinHeadId }
						});
						jArray.Add(jObject2);
					}
				}
				finally
				{
					((System.IDisposable)enumerator).Dispose();
				}
				ProfileLog($"开始保存档案，共 {jArray.Count} 个");
				jObject = new JObject
				{
					{ "lastUsed", LastUsedProfile },
					{ "profiles", jArray }
				};
			}
			ModBase.WriteFile(ModBase.PathAppdataConfig + "profiles.json", jObject.ToString());
			ProfileLog("档案已保存");
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "写入档案列表失败", ModBase.LogLevel.Feedback);
			ProjectData.ClearProjectError();
		}
	}

	public static void CreateProfile()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		int? num = null;
		ModBase.RunInUiWait((Action)([SpecialName] () =>
		{
			List<IMyRadio> obj = new List<IMyRadio>();
			obj.Add((IMyRadio)new MyListItem
			{
				Title = "正版验证",
				Type = MyListItem.CheckType.RadioBox,
				Logo = "M511.488256 95.184408c35.310345 22.516742 95.184408 55.78011 167.34033 84.437781 75.738131 29.681159 148.405797 40.93953 191.392304 45.033483v353.615193c0 73.691154-50.662669 164.781609-136.123938 244.101949C649.65917 901.181409 558.568716 942.12094 512 942.12094c-46.568716 0-137.65917-40.93953-222.096952-119.748126C204.441779 742.54073 153.77911 651.450275 153.77911 577.247376v-353.103448c42.474763-4.093953 116.165917-15.352324 191.904048-45.545227 75.226387-30.192904 133.565217-63.456272 165.805098-83.414293M512 0c-4.093953 0-8.187906 1.535232-11.258371 3.582209l-14.84058 10.234882c-1.023488 0.511744-67.550225 47.592204-170.410794 88.531735-100.813593 39.916042-198.556722 41.963018-199.58021 41.963018l-25.075462 0.511744c-10.746627 0.511744-18.934533 8.187906-18.934533 18.422789v414.000999c0 216.97951 286.064968 446.24088 440.09995 446.24088s440.09995-229.261369 440.09995-445.729136V163.758121c0-10.234883-8.69965-18.422789-18.934533-18.422789l-24.563718-0.511744c-1.023488 0-98.766617-2.046977-199.58021-41.963018-103.372314-40.93953-170.410795-88.01999-170.922538-88.531734L523.258371 3.582209c-3.070465-2.558721-7.164418-3.582209-11.258371-3.582209z M743.308346 410.930535l-260.477761 260.477761c-15.864068 15.864068-41.963018 15.864068-57.827087 0l-144.823588-144.823588c-15.864068-15.864068-15.864068-41.963018 0-57.827087 8.187906-8.187906 18.422789-11.770115 29.169415-11.770115 10.234883 0 20.981509 4.093953 29.169416 11.770115l115.654173 115.654173L685.993003 352.591704c15.864068-15.864068 41.963018-15.864068 57.827087 0 15.352324 16.375812 15.352324 42.474763-0.511744 58.338831z"
			});
			obj.Add((IMyRadio)new MyListItem
			{
				Title = "第三方验证",
				Type = MyListItem.CheckType.RadioBox,
				Logo = "M865.004 167.069c-10.794-9.687-24.91-15.085-39.579-15.085-1.383 0-2.629 0-4.013 0.139-0.831 0.139-10.102 0.692-24.771 0.692-24.218 0-71.408-1.522-116.107-12.178-57.708-13.7-124.411-77.083-143.785-89.675-9.687-6.227-21.034-9.41-32.244-9.41-11.21 0-22.42 3.182-32.244 9.41-2.353 1.522-72.1 73.484-140.324 89.675-44.699 10.655-92.72 12.178-116.938 12.178-14.53 0-23.941-0.554-24.771-0.692-1.246-0.139-2.629-0.139-3.875-0.139-14.67 0-28.924 5.396-39.717 15.085-11.763 10.655-18.405 25.325-18.405 40.825v140.048c0 517.846 351.089 584.411 366.034 587.040 3.46 0.554 6.782 0.831 10.241 0.831 3.46 0 6.918-0.276 10.241-0.831 14.946-2.629 368.663-69.33 368.663-587.040v-139.911c0.139-15.5-6.642-30.446-18.405-40.962v0zM825.425 348.080c0 476.883-320.783 531.961-320.783 531.961s-318.291-55.078-318.291-531.961v-140.048c0 0 10.933 0.831 28.785 0.831 30.446 0 81.648-2.214 130.777-13.839 80.403-19.098 158.731-97.564 158.731-97.564s81.787 78.466 162.19 97.564c49.129 11.625 99.501 13.839 129.946 13.839 17.714 0 28.785-0.831 28.785-0.831l-0.139 140.048zM463.405 491.173z M349.925 603.958l66.841-15.085c10.102 54.663 40.962 81.925 92.72 81.925 57.43-1.383 87.045-29.476 88.429-84.14 0-50.373-35.289-75.421-105.728-75.421-17.299 0-30.998 0-40.962 0v-51.757c10.102 0 20.757 0 32.382 0 66.149 0 99.916-25.187 101.3-75.421-1.383-45.945-26.571-69.747-75.421-71.132-48.85 0-77.635 26.571-86.215 79.85l-64.766-15.085c18.683-76.252 70.438-114.308 155.27-114.308 87.738 2.906 134.373 40.962 140.187 114.308-1.383 53.279-30.998 87.738-88.429 103.514 63.244 13.008 97.009 49.542 101.3 110.019-4.29 81.925-56.878 124.411-157.486 127.316-87.461 1.246-140.739-36.811-159.422-114.585z"
			});
			obj.Add((IMyRadio)new MyListItem
			{
				Title = "离线验证",
				Type = MyListItem.CheckType.RadioBox,
				Logo = "M533.293176 788.841412a60.235294 60.235294 0 1 1 85.202824 85.202823l-42.616471 42.586353c-129.355294 129.385412-339.124706 129.385412-468.510117 0-129.385412-129.385412-129.385412-339.124706 0-468.510117l42.586353-42.616471a60.235294 60.235294 0 1 1 85.202823 85.202824l-42.61647 42.586352a210.823529 210.823529 0 1 0 298.164706 298.164706l42.586352-42.61647z m255.548236-255.548236l42.61647-42.586352a210.823529 210.823529 0 1 0-298.164706-298.164706l-42.586352 42.61647a60.235294 60.235294 0 1 1-85.202824-85.202823l42.616471-42.586353c129.355294-129.385412 339.124706-129.385412 468.510117 0 129.385412 129.385412 129.385412 339.124706 0 468.510117l-42.586353 42.616471a60.235294 60.235294 0 1 1-85.202823-85.202824zM192.542118 192.542118a60.235294 60.235294 0 0 1 85.202823 0l553.712941 553.712941a60.235294 60.235294 0 0 1-85.202823 85.202823L192.542118 277.744941a60.235294 60.235294 0 0 1 0-85.202823z"
			});
			List<IMyRadio> selections = obj;
			num = ModMain.MyMsgBoxSelect(selections, "新建档案 - 选择验证类型", "继续", "取消");
		}));
		if (!num.HasValue)
		{
			return;
		}
		IsCreatingProfile = true;
		int? num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 0) : null).GetValueOrDefault())
		{
			object action;
			if (_Closure_0024__._0024I9_002D1 != null)
			{
				action = _Closure_0024__._0024I9_002D1;
			}
			else
			{
				Action val = [SpecialName] () =>
				{
					ModMain.FrmLaunchLeft.RefreshPage(Anim: true, ModLaunch.McLoginType.Ms);
				};
				_Closure_0024__._0024I9_002D1 = val;
				action = (object)val;
			}
			ModBase.RunInUi((Action)action);
			return;
		}
		num2 = num;
		if ((num2.HasValue ? new bool?(num2.GetValueOrDefault() == 1) : null).GetValueOrDefault())
		{
			object action2;
			if (_Closure_0024__._0024I9_002D2 != null)
			{
				action2 = _Closure_0024__._0024I9_002D2;
			}
			else
			{
				Action val2 = [SpecialName] () =>
				{
					ModMain.FrmLaunchLeft.RefreshPage(Anim: true, ModLaunch.McLoginType.Auth);
				};
				_Closure_0024__._0024I9_002D2 = val2;
				action2 = (object)val2;
			}
			ModBase.RunInUi((Action)action2);
			return;
		}
		object action3;
		if (_Closure_0024__._0024I9_002D3 != null)
		{
			action3 = _Closure_0024__._0024I9_002D3;
		}
		else
		{
			Action val3 = [SpecialName] () =>
			{
				ModMain.FrmLaunchLeft.RefreshPage(Anim: true, ModLaunch.McLoginType.Legacy);
			};
			_Closure_0024__._0024I9_002D3 = val3;
			action3 = (object)val3;
		}
		ModBase.RunInUi((Action)action3);
	}

	public static void EditProfileId()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		if (SelectedProfile.Type == ModLaunch.McLoginType.Ms)
		{
			string text = null;
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				string username2 = SelectedProfile.Username;
				Collection<Validate> obj4 = new Collection<Validate>();
				obj4.Add((Validate)new ValidateLength(3, 16));
				obj4.Add((Validate)new ValidateRegex("([A-z]|[0-9]|_)+"));
				text = ModMain.MyMsgBoxInput("输入新的玩家 ID", "玩家 ID 只能每 30 天更改一次名称，请谨慎考虑！", username2, obj4, "3 - 16 个字符，只可以包含大小写字母、数字、下划线", "确认");
			}));
			if (Operators.CompareString(text, (string)null, false) == 0)
			{
				return;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				ModMain.Hint("欲设置的玩家名称为空");
			}
			else
			{
				if (ModMain.MyMsgBox("注意：玩家 ID 只能每 30 天更改一次，请务必谨慎考虑！", "确认修改", "继续修改", "取消", "", IsWarn: true) == 2)
				{
					return;
				}
				ModBase.RunInNewThread((Action)([SpecialName] () =>
				{
					//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
					//IL_01ac: Expected O, but got Unknown
					//IL_01ad: Expected O, but got Unknown
					try
					{
						string url = $"https://api.minecraftservices.com/minecraft/profile/name/{text}/available";
						Dictionary<string, string> obj2 = new Dictionary<string, string>();
						obj2.Add("Authorization", "Bearer " + SelectedProfile.AccessToken);
						JObject jObject = (JObject)ModBase.GetJson(ModNet.NetRequestRetry(url, "GET", null, null, DontRetryOnRefused: true, obj2));
						if ((string?)jObject["status"] == "DUPLICATE")
						{
							ModMain.MyMsgBox("此 ID 已被使用，请换一个 ID。", "ID 修改失败", "确认", "", "", IsWarn: true);
						}
						else if ((string?)jObject["status"] == "NOT_ALLOWED")
						{
							ModMain.MyMsgBox("此 ID 包含了除大小写字母、数字、下划线以外的不合法字符。", "ID 修改失败", "确认", "", "", IsWarn: true);
						}
						else
						{
							string url2 = $"https://api.minecraftservices.com/minecraft/profile/name/{text}";
							Dictionary<string, string> obj3 = new Dictionary<string, string>();
							obj3.Add("Authorization", "Bearer " + SelectedProfile.AccessToken);
							JObject jObject2 = (JObject)ModBase.GetJson(ModNet.NetRequestRetry(url2, "PUT", "", "application/json", DontRetryOnRefused: true, obj3));
							ModMain.Hint(string.Format("玩家 ID 修改成功，当前 ID 为：{0}", (object)jObject2["name"]), ModMain.HintType.Finish);
							ProfileList.Remove(SelectedProfile);
							SelectedProfile.Username = (string?)jObject2["name"];
							ProfileList.Add(SelectedProfile);
							LastUsedProfile = checked(ProfileList.Count - 1);
							ModMain.FrmLaunchLeft.RefreshPage(Anim: true);
							SaveProfile();
						}
					}
					catch (HttpRequestException val)
					{
						ProjectData.SetProjectError((System.Exception)val);
						HttpRequestException val2 = val;
						if (((System.Exception)(object)val2).ToString().Contains("403"))
						{
							ModMain.MyMsgBox("首次更改 ID 后，必须等待 30 天后才能再次修改 ID，你可以前往官网查询具体时间。", "ID 修改失败", "我知道了");
						}
						else
						{
							ModBase.Log((System.Exception)(object)val2, "修改档案 ID 失败", ModBase.LogLevel.Msgbox);
						}
						ProjectData.ClearProjectError();
					}
				}), null, (ThreadPriority)2);
			}
		}
		else if (SelectedProfile.Type == ModLaunch.McLoginType.Auth)
		{
			string server = SelectedProfile.Server;
			ModBase.OpenWebsite(server.ToString().Replace("/api/yggdrasil/authserver" + (ModBase.EndsWithF(server, "/") ? "/" : ""), "/user/profile"));
		}
		else
		{
			string text2 = null;
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				string username = SelectedProfile.Username;
				Collection<Validate> obj = new Collection<Validate>();
				obj.Add((Validate)new ValidateLength(3, 16));
				obj.Add((Validate)new ValidateRegex("([A-z]|[0-9]|_)+"));
				text2 = ModMain.MyMsgBoxInput("输入新的玩家 ID", "", username, obj, "3 - 16 个字符，只可以包含大小写字母、数字、下划线", "确认");
			}));
			if (Operators.CompareString(text2, (string)null, false) != 0)
			{
				EditOfflineUuid(SelectedProfile, GetOfflineUuid(text2));
			}
		}
	}

	public static void EditOfflineUuid(McProfile profile, string uuid = null)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		int num = ProfileList.IndexOf(profile);
		string text;
		if (uuid != null)
		{
			text = uuid;
		}
		else
		{
			int? num2 = null;
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				List<IMyRadio> obj2 = new List<IMyRadio>();
				obj2.Add((IMyRadio)new MyRadioBox
				{
					Text = "行业规范 UUID（推荐）"
				});
				obj2.Add((IMyRadio)new MyRadioBox
				{
					Text = "官方版 PCL UUID（若单人存档的部分信息丢失，可尝试此项）"
				});
				obj2.Add((IMyRadio)new MyRadioBox
				{
					Text = "自定义"
				});
				List<IMyRadio> selections = obj2;
				num2 = ModMain.MyMsgBoxSelect(selections, "新建档案 - 选择 UUID 类型", "继续", "取消");
			}));
			if (!num2.HasValue)
			{
				return;
			}
			switch (num2.Value)
			{
			case 0:
				text = GetOfflineUuid(profile.Username);
				break;
			case 1:
				text = GetOfflineUuid(profile.Username, isSplited: false, isLegacy: true);
				break;
			default:
			{
				string title = $"更改档案 {profile.Username} 的 UUID";
				string uuid2 = profile.Uuid;
				Collection<Validate> obj = new Collection<Validate>();
				obj.Add((Validate)new ValidateLength(32, 32));
				obj.Add((Validate)new ValidateRegex("([A-z]|[0-9]){32}", "UUID 只应该包括英文字母和数字！"));
				text = ModMain.MyMsgBoxInput(title, "", uuid2, obj, "32 位，不含连字符", "继续");
				break;
			}
			}
			if (Operators.CompareString(text, (string)null, false) == 0)
			{
				return;
			}
		}
		ProfileList[num].Uuid = text;
		SelectedProfile = ProfileList[num];
		SaveProfile();
		ModMain.Hint("档案信息已保存！", ModMain.HintType.Finish);
	}

	public static void EditAuthServerName(McProfile profile, string serverName)
	{
		int num = ProfileList.IndexOf(profile);
		ProfileList[num].ServerName = serverName;
		SaveProfile();
		ModMain.Hint("档案信息已保存！", ModMain.HintType.Finish);
	}

	public static void RemoveProfile(McProfile profile)
	{
		ProfileList.Remove(profile);
		LastUsedProfile = 0;
		SaveProfile();
		ModMain.Hint("档案删除成功！", ModMain.HintType.Finish);
	}

	public static void MigrateProfile()
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		_Closure_0024__14_002D0 arg = default(_Closure_0024__14_002D0);
		_Closure_0024__14_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__14_002D0(null);
		CS_0024_003C_003E8__locals0._0024VB_0024Local_type = 3;
		if (Enumerable.Any<McProfile>((System.Collections.Generic.IEnumerable<McProfile>)ProfileList))
		{
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_type = ModMain.MyMsgBox(string.Format("PCL CE 支持导入 HMCL 的全局账户列表，抑或是导出档案列表至 HMCL 全局账户列表。{0}你想要...？", (object)"\r\n"), "导入 / 导出档案", "导入", "导出", "取消", IsWarn: false, HighLight: true, ForceWait: true);
			}));
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_type == 3)
			{
				return;
			}
		}
		else
		{
			ModBase.RunInUiWait((Action)([SpecialName] () =>
			{
				CS_0024_003C_003E8__locals0._0024VB_0024Local_type = ModMain.MyMsgBox(string.Format("PCL CE 支持导入 HMCL 的全局账户列表，抑或是导出档案列表至 HMCL 全局账户列表。{0}由于目前 PCL CE 不存在任何可用档案，无法导出档案。", (object)"\r\n"), "导入 / 导出档案", "导入", "取消", "", IsWarn: false, HighLight: true, ForceWait: true);
			}));
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_type == 2)
			{
				return;
			}
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_outsidePath = Environment.GetFolderPath((System.Environment.SpecialFolder)26) + "\\.hmcl\\accounts.json";
		checked
		{
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_type == 1)
			{
				ModMain.Hint("正在导入，请稍后...");
				ModBase.RunInNewThread((Action)([SpecialName] () =>
				{
					//IL_0071: Unknown result type (might be due to invalid IL or missing references)
					//IL_0076: Unknown result type (might be due to invalid IL or missing references)
					//IL_0349: Unknown result type (might be due to invalid IL or missing references)
					//IL_034e: Unknown result type (might be due to invalid IL or missing references)
					//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
					//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
					//IL_03c1: Expected O, but got Unknown
					JArray jArray3;
					try
					{
						jArray3 = JArray.Parse(ModBase.ReadFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_outsidePath));
					}
					catch (System.Exception ex3)
					{
						ProjectData.SetProjectError(ex3);
						System.Exception ex4 = ex3;
						jArray3 = new JArray();
						ProjectData.ClearProjectError();
					}
					List<McProfile> val = new List<McProfile>();
					int num2 = 0;
					System.Collections.Generic.IEnumerator<JToken> enumerator3 = default(System.Collections.Generic.IEnumerator<JToken>);
					try
					{
						enumerator3 = jArray3.GetEnumerator();
						System.Collections.Generic.IEnumerator<McProfile> enumerator4 = default(System.Collections.Generic.IEnumerator<McProfile>);
						while (((System.Collections.IEnumerator)enumerator3).MoveNext())
						{
							JToken current3 = enumerator3.Current;
							McProfile mcProfile = null;
							bool flag = false;
							if ((string?)current3["type"] == "microsoft")
							{
								try
								{
									enumerator4 = ProfileList.GetEnumerator();
									while (enumerator4.MoveNext())
									{
										McProfile current4 = enumerator4.Current;
										if (current4.Type == ModLaunch.McLoginType.Ms && current4.Uuid == (string?)current3["uuid"])
										{
											flag = true;
											break;
										}
									}
								}
								finally
								{
									((System.IDisposable)enumerator4).Dispose();
								}
								mcProfile = new McProfile
								{
									Type = ModLaunch.McLoginType.Ms,
									Uuid = (string?)current3["uuid"],
									Username = (string?)current3["displayName"],
									AccessToken = "",
									Expires = 1743779140286L,
									Desc = "",
									RawJson = "",
									SkinHeadId = ""
								};
								if (!flag)
								{
									val.Add(mcProfile);
								}
							}
							else if ((string?)current3["type"] == "authlibInjector")
							{
								mcProfile = new McProfile
								{
									Type = ModLaunch.McLoginType.Auth,
									Uuid = (string?)current3["uuid"],
									Username = (string?)current3["displayName"],
									AccessToken = "",
									RefreshToken = "",
									Expires = 1743779140286L,
									Server = (string?)current3["serverBaseURL"],
									ServerName = "",
									Name = (string?)current3["username"],
									Password = "",
									ClientToken = (string?)current3["clientToken"],
									Desc = "",
									SkinHeadId = ""
								};
								try
								{
									string serverName = JObject.Parse(Conversions.ToString(ModNet.NetGetCodeByRequestRetry(mcProfile.Server.Replace("/authserver", ""), Encoding.UTF8)))["meta"]["serverName"].ToString();
									mcProfile.ServerName = serverName;
								}
								catch (System.Exception ex5)
								{
									ProjectData.SetProjectError(ex5);
									System.Exception ex6 = ex5;
									ProfileLog("获取服务器名称失败，继续档案添加流程: " + ex6.ToString());
									ProjectData.ClearProjectError();
								}
								val.Add(mcProfile);
							}
							else
							{
								mcProfile = new McProfile
								{
									Type = ModLaunch.McLoginType.Legacy,
									Uuid = (string?)current3["uuid"],
									Username = (string?)current3["username"],
									Desc = "",
									SkinHeadId = ""
								};
								val.Add(mcProfile);
							}
							num2++;
						}
					}
					finally
					{
						((System.IDisposable)enumerator3)?.Dispose();
					}
					System.Collections.Generic.IEnumerator<McProfile> enumerator5 = default(System.Collections.Generic.IEnumerator<McProfile>);
					try
					{
						enumerator5 = val.GetEnumerator();
						while (enumerator5.MoveNext())
						{
							McProfile current5 = enumerator5.Current;
							ProfileList.Add(current5);
						}
					}
					finally
					{
						((System.IDisposable)enumerator5).Dispose();
					}
					SaveProfile();
					ModMain.Hint($"已导入 {num2} 个档案，部分档案可能需要重新验证密码！", ModMain.HintType.Finish);
					object action;
					if (_Closure_0024__._0024I14_002D3 != null)
					{
						action = _Closure_0024__._0024I14_002D3;
					}
					else
					{
						Action val2 = [SpecialName] () =>
						{
							ModMain.FrmLoginProfile.RefreshProfileList();
						};
						_Closure_0024__._0024I14_002D3 = val2;
						action = (object)val2;
					}
					ModBase.RunInUi((Action)action);
				}), "Profile Import", (ThreadPriority)2);
				return;
			}
			ModMain.Hint("正在导出，请稍后...");
			JArray jArray;
			try
			{
				jArray = JArray.Parse(ModBase.ReadFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_outsidePath));
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				jArray = new JArray();
				ProjectData.ClearProjectError();
			}
			JArray jArray2 = new JArray();
			int num = 0;
			System.Collections.Generic.IEnumerator<McProfile> enumerator = default(System.Collections.Generic.IEnumerator<McProfile>);
			try
			{
				enumerator = ProfileList.GetEnumerator();
				while (enumerator.MoveNext())
				{
					McProfile current = enumerator.Current;
					JObject jObject = null;
					jObject = ((current.Type != ModLaunch.McLoginType.Ms) ? ((current.Type != ModLaunch.McLoginType.Auth) ? new JObject
					{
						{ "uuid", current.Uuid },
						{ "username", current.Username },
						{ "type", "offline" }
					} : new JObject
					{
						{ "serverBaseURL", current.Server },
						{ "clientToken", "" },
						{ "displayName", current.Username },
						{ "accessToken", "" },
						{ "type", "authlibInjector" },
						{ "uuid", current.Uuid },
						{ "username", current.Name }
					}) : new JObject
					{
						{ "uuid", current.Uuid },
						{ "displayName", current.Username },
						{ "tokenType", "Bearer" },
						{ "accessToken", "" },
						{ "refreshToken", "" },
						{ "notAfter", 1743779140286L },
						{ "userid", "" },
						{ "type", "microsoft" }
					});
					jArray2.Add(jObject);
					num++;
				}
			}
			finally
			{
				((System.IDisposable)enumerator).Dispose();
			}
			System.Collections.Generic.IEnumerator<JToken> enumerator2 = default(System.Collections.Generic.IEnumerator<JToken>);
			try
			{
				enumerator2 = jArray2.GetEnumerator();
				while (((System.Collections.IEnumerator)enumerator2).MoveNext())
				{
					JToken current2 = enumerator2.Current;
					jArray.Add(current2);
				}
			}
			finally
			{
				((System.IDisposable)enumerator2)?.Dispose();
			}
			ModBase.WriteFile(CS_0024_003C_003E8__locals0._0024VB_0024Local_outsidePath, jArray.ToString());
			ModMain.Hint($"已导出 {num} 个档案，部分档案可能需要重新验证密码！", ModMain.HintType.Finish);
		}
	}

	public static string GetOfflineUuid(string userName, bool isSplited = false, bool isLegacy = false)
	{
		if (isLegacy)
		{
			string text = ModBase.StrFill(userName.Length.ToString("X"), "0", 16) + ModBase.StrFill(ModBase.GetHash(userName).ToString("X"), "0", 16);
			return string.Concat(new string[5]
			{
				text.Substring(0, 12),
				"3",
				text.Substring(13, 3),
				"9",
				text.Substring(17, 15)
			});
		}
		byte[] array = ((HashAlgorithm)MD5.Create()).ComputeHash(Encoding.UTF8.GetBytes("OfflinePlayer:" + userName));
		checked
		{
			array[6] = (byte)(array[6] & 0xF);
			array[6] = (byte)(array[6] | 0x30);
			array[8] = (byte)(array[8] & 0x3F);
			array[8] = (byte)(array[8] | 0x80);
			Guid val = default(Guid);
			val = new(ToUuidString(array));
			ProfileLog("获取到离线 UUID: " + val.ToString());
			if (isSplited)
			{
				return val.ToString();
			}
			return val.ToString().Replace("-", "");
		}
	}

	private static string ToUuidString(byte[] bytes)
	{
		long num = 0L;
		long num2 = 0L;
		int num3 = 0;
		checked
		{
			do
			{
				num = (num << 8) | (bytes[num3] & 0xFF);
				num3++;
			}
			while (num3 <= 7);
			int num4 = 8;
			do
			{
				num2 = (num2 << 8) | (bytes[num4] & 0xFF);
				num4++;
			}
			while (num4 <= 15);
			return Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Operators.AddObject(Digits(num >> 32, 8), (object)"-"), Digits(num >> 16, 4)), (object)"-"), Digits(num, 4)), (object)"-"), Digits(num2 >> 48, 4)), (object)"-"), Digits(num2, 12)));
		}
	}

	private static object Digits(long val, int digs)
	{
		checked
		{
			long num = 1L << digs * 4;
			return (num | (val & (num - 1))).ToString("X").Substring(1);
		}
	}

	public static object GetProfileInfo(McProfile profile)
	{
		string text = null;
		if (profile.Type != ModLaunch.McLoginType.Auth)
		{
			text = ((profile.Type != ModLaunch.McLoginType.Ms) ? (text + "离线验证") : (text + "正版验证"));
		}
		else
		{
			text += "第三方验证";
			if (!string.IsNullOrWhiteSpace(profile.ServerName))
			{
				text += $" / {profile.ServerName}";
			}
		}
		if (!string.IsNullOrWhiteSpace(profile.Desc))
		{
			text += $"，{profile.Desc}";
		}
		return text;
	}

	public static ModLaunch.McLoginData GetLoginData(ModLaunch.McLoginType targetAuthType = (ModLaunch.McLoginType)0)
	{
		ModLaunch.McLoginType mcLoginType = (ModLaunch.McLoginType)0;
		if (SelectedProfile == null)
		{
			return ((targetAuthType == (ModLaunch.McLoginType)0) ? ModLaunch.McLoginType.Legacy : targetAuthType) switch
			{
				ModLaunch.McLoginType.Auth => new ModLaunch.McLoginServer(ModLaunch.McLoginType.Auth)
				{
					Description = "Authlib-Injector",
					Type = ModLaunch.McLoginType.Auth,
					IsExist = (ModMain.FrmLoginAuth == null)
				}, 
				ModLaunch.McLoginType.Ms => new ModLaunch.McLoginMs(), 
				_ => new ModLaunch.McLoginLegacy(), 
			};
		}
		switch (SelectedProfile.Type)
		{
		case ModLaunch.McLoginType.Auth:
			return new ModLaunch.McLoginServer(ModLaunch.McLoginType.Auth)
			{
				BaseUrl = SelectedProfile.Server,
				UserName = SelectedProfile.Name,
				Password = SelectedProfile.Password,
				Description = "Authlib-Injector",
				Type = ModLaunch.McLoginType.Auth,
				IsExist = (ModMain.FrmLoginAuth == null)
			};
		case ModLaunch.McLoginType.Ms:
			if (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Finished)
			{
				return new ModLaunch.McLoginMs
				{
					OAuthRefreshToken = SelectedProfile.RefreshToken,
					UserName = SelectedProfile.Username,
					AccessToken = SelectedProfile.AccessToken,
					Uuid = SelectedProfile.Uuid,
					ProfileJson = SelectedProfile.RawJson
				};
			}
			return new ModLaunch.McLoginMs
			{
				OAuthRefreshToken = SelectedProfile.RefreshToken,
				UserName = SelectedProfile.Name
			};
		default:
			return new ModLaunch.McLoginLegacy
			{
				UserName = SelectedProfile.Username,
				Uuid = SelectedProfile.Uuid
			};
		}
	}

	public static object IsProfileValid()
	{
		switch (SelectedProfile.Type)
		{
		case ModLaunch.McLoginType.Legacy:
			if (Operators.CompareString(SelectedProfile.Username.Trim(), "", false) == 0)
			{
				return "玩家名不能为空！";
			}
			if (SelectedProfile.Username.Contains("\""))
			{
				return "玩家名不能包含英文引号！";
			}
			if ((object)ModMinecraft.McInstanceCurrent != null && ((ModMinecraft.McInstanceCurrent.Version.McCodeMain == 20 && ModMinecraft.McInstanceCurrent.Version.McCodeSub >= 3) || ModMinecraft.McInstanceCurrent.Version.McCodeMain > 20) && SelectedProfile.Username.Trim().Length > 16)
			{
				return "自 1.20.3 起，玩家名至多只能包含 16 个字符！";
			}
			return "";
		case ModLaunch.McLoginType.Ms:
			return "";
		case ModLaunch.McLoginType.Auth:
			return "";
		default:
			return "未知的验证方式";
		}
	}

	public static void ChangeSkinMs()
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		_Closure_0024__22_002D0 arg = default(_Closure_0024__22_002D0);
		_Closure_0024__22_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__22_002D0(null);
		if (_isMsSkinChanging)
		{
			ModMain.Hint("正在更改皮肤中，请稍候！");
			return;
		}
		if (ModLaunch.McLoginLoader.State == ModBase.LoadState.Failed)
		{
			ModMain.Hint("登录失败，无法更改皮肤！", ModMain.HintType.Critical);
			return;
		}
		CS_0024_003C_003E8__locals0._0024VB_0024Local_skinInfo = ModMinecraft.McSkinSelect();
		if (!CS_0024_003C_003E8__locals0._0024VB_0024Local_skinInfo.IsVaild)
		{
			return;
		}
		ModMain.Hint("正在更改皮肤……");
		_isMsSkinChanging = true;
		ModBase.RunInNewThread((Action)([SpecialName] () =>
		{
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_00fe: Expected O, but got Unknown
			try
			{
				string text;
				while (true)
				{
					if (ModLaunch.McLoginMsLoader.State == ModBase.LoadState.Loading)
					{
						ModLaunch.McLoginMsLoader.WaitForExit();
					}
					if (ModLaunch.McLoginMsLoader.State != ModBase.LoadState.Finished)
					{
						ModLaunch.McLoginMsLoader.WaitForExit(GetLoginData());
					}
					if (ModLaunch.McLoginMsLoader.State != ModBase.LoadState.Finished)
					{
						ModMain.Hint("登录失败，无法更改皮肤！", ModMain.HintType.Critical);
						return;
					}
					string accessToken = SelectedProfile.AccessToken;
					Dictionary<string, string> val = new Dictionary<string, string>();
					val.Add("Authorization", $"Bearer {accessToken}");
					val.Add("Accept", "*/*");
					val.Add("User-Agent", "MojangSharp/0.1");
					MultipartFormDataContent val2 = new MultipartFormDataContent();
					val2.Add((HttpContent)new StringContent(CS_0024_003C_003E8__locals0._0024VB_0024Local_skinInfo.IsSlim ? "slim" : "classic"), "variant");
					val2.Add((HttpContent)new ByteArrayContent(ModBase.ReadFileBytes(CS_0024_003C_003E8__locals0._0024VB_0024Local_skinInfo.LocalFile)), "file", ModBase.GetFileNameFromPath(CS_0024_003C_003E8__locals0._0024VB_0024Local_skinInfo.LocalFile));
					MultipartFormDataContent data = val2;
					text = ModNet.NetRequestRetry("https://api.minecraftservices.com/minecraft/profile/skins", "POST", data, null, DontRetryOnRefused: true, val);
					if (!text.Contains("request requires user authentication"))
					{
						break;
					}
					ModMain.Hint("正在登录，将在登录完成后继续更改皮肤……");
					ModLaunch.McLoginMsLoader.Start(GetLoginData(), IsForceRestart: true);
				}
				if (text.Contains("\"error\""))
				{
					ModMain.Hint(Conversions.ToString(Operators.ConcatenateObject((object)"更改皮肤失败：", NewLateBinding.LateIndexGet(ModBase.GetJson(text), new object[] { "error" }, (string[])null))), ModMain.HintType.Critical);
					return;
				}
				ModBase.Log("[Skin] 皮肤修改返回值：\r\n" + text);
				JObject jObject = (JObject)ModBase.GetJson(text);
				if (jObject.ContainsKey("errorMessage"))
				{
					throw new System.Exception(jObject["errorMessage"].ToString());
				}
				System.Collections.Generic.IEnumerator<JToken> enumerator = default(System.Collections.Generic.IEnumerator<JToken>);
				try
				{
					enumerator = ((System.Collections.Generic.IEnumerable<JToken>)jObject["skins"]).GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						JObject jObject2 = (JObject)enumerator.Current;
						if (Operators.CompareString(jObject2["state"].ToString(), "ACTIVE", false) == 0)
						{
							MySkin.ReloadCache((string?)jObject2["url"]);
							return;
						}
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				throw new System.Exception("未知错误（" + text + "）");
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				if (ex2.GetType().Equals(typeof(TaskCanceledException)))
				{
					ModMain.Hint("更改皮肤失败：与 Mojang 皮肤服务器的连接超时，请检查你的网络是否通畅！", ModMain.HintType.Critical);
				}
				else
				{
					ModBase.Log(ex2, "更改皮肤失败", ModBase.LogLevel.Hint);
				}
				ProjectData.ClearProjectError();
			}
			finally
			{
				_isMsSkinChanging = false;
			}
		}), "Ms Skin Upload", (ThreadPriority)2);
	}

	public static void MigrateOldProfile()
	{
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		ProfileLog("开始从旧版配置迁移档案");
		int num = 0;
		checked
		{
			if (Conversions.ToBoolean(Operators.NotObject(Operators.CompareObjectEqual(ModBase.Setup.Get("LoginMsJson"), (object)"{}", false))))
			{
				JObject jObject = (JObject)ModBase.GetJson(Conversions.ToString(ModBase.Setup.Get("LoginMsJson")));
				ProfileLog($"找到 {jObject.Count} 个旧版正版档案信息");
				System.Collections.Generic.IEnumerator<KeyValuePair<string, JToken>> enumerator = default(System.Collections.Generic.IEnumerator<KeyValuePair<string, JToken>>);
				try
				{
					enumerator = jObject.GetEnumerator();
					while (((System.Collections.IEnumerator)enumerator).MoveNext())
					{
						KeyValuePair<string, JToken> current = enumerator.Current;
						McProfile mcProfile = new McProfile
						{
							Username = current.Key,
							Uuid = Conversions.ToString(McLoginMojangUuid(current.Key, throwOnNotFound: false)),
							Type = ModLaunch.McLoginType.Ms
						};
						ProfileList.Add(mcProfile);
						num++;
					}
				}
				finally
				{
					((System.IDisposable)enumerator)?.Dispose();
				}
				SaveProfile();
				ProfileLog("旧版正版档案迁移完成");
				ModBase.Setup.Reset("LoginMsJson");
			}
			else
			{
				ProfileLog("无旧版正版档案信息");
			}
			if (!string.IsNullOrWhiteSpace(Conversions.ToString(ModBase.Setup.Get("LoginLegacyName"))))
			{
				string[] array = (string[])NewLateBinding.LateGet(ModBase.Setup.Get("LoginLegacyName"), (System.Type)null, "Split", new object[] { "\u00a8" }, (string[])null, (System.Type[])null, (bool[])null);
				ProfileLog($"找到 {Enumerable.Count<string>((System.Collections.Generic.IEnumerable<string>)array)} 个旧版离线档案信息");
				string[] array2 = array;
				foreach (string text in array2)
				{
					McProfile mcProfile2 = new McProfile
					{
						Username = text,
						Uuid = GetOfflineUuid(text, isSplited: false, isLegacy: true),
						Type = ModLaunch.McLoginType.Legacy
					};
					ProfileList.Add(mcProfile2);
					num++;
				}
				SaveProfile();
				ProfileLog("旧版离线档案迁移完成");
				ModBase.Setup.Reset("LoginLegacyName");
			}
			else
			{
				ProfileLog("无旧版离线档案信息");
			}
			if (!string.IsNullOrWhiteSpace(Conversions.ToString(ModBase.Setup.Get("CacheAuthName"))) && !string.IsNullOrWhiteSpace(Conversions.ToString(ModBase.Setup.Get("CacheAuthUuid"))) && !string.IsNullOrWhiteSpace(Conversions.ToString(ModBase.Setup.Get("CacheAuthServerServer"))) && !string.IsNullOrWhiteSpace(Conversions.ToString(ModBase.Setup.Get("CacheAuthUsername"))) && !string.IsNullOrWhiteSpace(Conversions.ToString(ModBase.Setup.Get("CacheAuthPass"))))
			{
				ProfileLog("找到旧版第三方验证档案信息");
				McProfile mcProfile3 = new McProfile
				{
					Username = Conversions.ToString(ModBase.Setup.Get("CacheAuthName")),
					Uuid = Conversions.ToString(ModBase.Setup.Get("CacheAuthUuid")),
					Name = Conversions.ToString(ModBase.Setup.Get("CacheAuthUsername")),
					Password = Conversions.ToString(ModBase.Setup.Get("CacheAuthPass")),
					Server = Conversions.ToString(Operators.ConcatenateObject(ModBase.Setup.Get("CacheAuthServerServer"), (object)"/authserver")),
					Type = ModLaunch.McLoginType.Auth
				};
				ProfileList.Add(mcProfile3);
				SaveProfile();
				ProfileLog("旧版第三方验证档案迁移完成");
				num++;
				ModBase.Setup.Reset("CacheAuthName");
				ModBase.Setup.Reset("CacheAuthUuid");
				ModBase.Setup.Reset("CacheAuthServerServer");
				ModBase.Setup.Reset("CacheAuthUsername");
				ModBase.Setup.Reset("CacheAuthPass");
			}
			else
			{
				ProfileLog("无旧版第三方验证档案信息");
			}
			if (num != 0)
			{
				ModMain.Hint($"已自动从旧版配置文件迁移档案，共迁移了 {num} 个档案");
			}
			ProfileLog("档案迁移结束");
		}
	}

	public static object McLoginMojangUuid(string name, bool throwOnNotFound)
	{
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		_Closure_0024__24_002D1 arg = new _Closure_0024__24_002D1(null);
		arg._0024VB_0024Local_name = name;
		if (arg._0024VB_0024Local_name.Trim().Length == 0)
		{
			return ModBase.StrFill("", "0", 32);
		}
		string text = ModBase.ReadIni(ModBase.PathTemp + "Cache\\Uuid\\Mojang.ini", arg._0024VB_0024Local_name);
		if (Strings.Len(text) == 32)
		{
			return text;
		}
		try
		{
			_Closure_0024__24_002D0 arg2 = default(_Closure_0024__24_002D0);
			_Closure_0024__24_002D0 CS_0024_003C_003E8__locals0 = new _Closure_0024__24_002D0(null);
			CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2 = arg;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_gotJson = null;
			CS_0024_003C_003E8__locals0._0024VB_0024Local_finished = false;
			ModBase.RunInNewThread((Action)([SpecialName] () =>
			{
				try
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_gotJson = (JObject)ModNet.NetGetCodeByRequestRetry("https://api.mojang.com/users/profiles/minecraft/" + CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_name, null, "", IsJson: true);
				}
				catch (System.Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					System.Exception ex4 = ex3;
					ProjectData.ClearProjectError();
				}
				finally
				{
					CS_0024_003C_003E8__locals0._0024VB_0024Local_finished = true;
				}
			}), $"{CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_name} Uuid Get", (ThreadPriority)2);
			while (!CS_0024_003C_003E8__locals0._0024VB_0024Local_finished)
			{
				Thread.Sleep(50);
			}
			if (CS_0024_003C_003E8__locals0._0024VB_0024Local_gotJson == null)
			{
				throw new FileNotFoundException("正版玩家档案不存在（" + CS_0024_003C_003E8__locals0._0024VB_0024NonLocal__0024VB_0024Closure_2._0024VB_0024Local_name + "）");
			}
			text = (string?)(CS_0024_003C_003E8__locals0._0024VB_0024Local_gotJson["id"] ?? ((JToken)""));
		}
		catch (System.Exception ex)
		{
			ProjectData.SetProjectError(ex);
			System.Exception ex2 = ex;
			ModBase.Log(ex2, "从官网获取正版 UUID 失败（" + arg._0024VB_0024Local_name + "）");
			if (throwOnNotFound || Operators.CompareString(((MemberInfo)ex2.GetType()).Name, "FileNotFoundException", false) != 0)
			{
				throw new System.Exception("从官网获取正版 UUID 失败", ex2);
			}
			text = GetOfflineUuid(arg._0024VB_0024Local_name, isSplited: false, isLegacy: true);
			ProjectData.ClearProjectError();
		}
		if (Strings.Len(text) != 32)
		{
			throw new System.Exception("获取的正版 UUID 长度不足（" + text + "）");
		}
		ModBase.WriteIni(ModBase.PathTemp + "Cache\\Uuid\\Mojang.ini", arg._0024VB_0024Local_name, text);
		return text;
	}
}
