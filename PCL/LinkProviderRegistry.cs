using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using PCL.Core.Link.Natayark;

namespace PCL;

[StandardModule]
public sealed class LinkProviderRegistry
{
	private static readonly Dictionary<LinkProviderKind, LinkProviderDescriptor> ProviderMap;

	static LinkProviderRegistry()
	{
		Dictionary<LinkProviderKind, LinkProviderDescriptor> obj = new Dictionary<LinkProviderKind, LinkProviderDescriptor>();
		obj.Add(LinkProviderKind.OpenFrp, new LinkProviderDescriptor
		{
			Kind = LinkProviderKind.OpenFrp,
			Name = "OpenFrp",
			Description = "OpenFrp 控制台登录后即可同步已有隧道与配置信息。",
			LoginUrl = "https://console.openfrp.net/login",
			SuccessKeyword = "/dashboard",
			DashboardUrl = "https://console.openfrp.net/dashboard",
			CreateTunnelUrl = "https://console.openfrp.net/create-proxies"
		});
		obj.Add(LinkProviderKind.MeFrp, new LinkProviderDescriptor
		{
			Kind = LinkProviderKind.MeFrp,
			Name = "MeFrp",
			Description = "ME Frp 幻缘映射",
			LoginUrl = "https://www.mefrp.com/auth/pwd-login",
			SuccessKeyword = "/dashboard/home",
			DashboardUrl = "https://www.mefrp.com/dashboard/home",
			CreateTunnelUrl = "https://www.mefrp.com/home/proxies"
		});
		obj.Add(LinkProviderKind.Natfrp, new LinkProviderDescriptor
		{
			Kind = LinkProviderKind.Natfrp,
			Name = "SakuraFrp",
			Description = "SAKURA FRP",
			LoginUrl = "https://www.natfrp.com/user/login",
			SuccessKeyword = "/user/",
			DashboardUrl = "https://www.natfrp.com/user/",
			CreateTunnelUrl = "https://www.natfrp.com/user/tunnel/create"
		});
		obj.Add(LinkProviderKind.XhFrp, new LinkProviderDescriptor
		{
			Kind = LinkProviderKind.XhFrp,
			Name = "星穿月联",
			Description = "星穿月联 提供商",
			LoginUrl = "https://console.xhfrp.xhuzim.top/login",
			SuccessKeyword = "/dashboard",
			DashboardUrl = "https://console.xhfrp.xhuzim.top/dashboard",
			CreateTunnelUrl = "https://console.xhfrp.xhuzim.top/tunnels/create"
		});
		obj.Add(LinkProviderKind.Stellarfrp, new LinkProviderDescriptor
		{
			Kind = LinkProviderKind.Stellarfrp,
			Name = "Stellarfrp",
			Description = "Stellarfrp 提供商",
			LoginUrl = "https://console.stellarfrp.top/login",
			SuccessKeyword = "/dashboard",
			DashboardUrl = "https://console.stellarfrp.top/dashboard",
			CreateTunnelUrl = "https://console.stellarfrp.top/tunnels/create"
		});
		ProviderMap = obj;
	}

	public static LinkProviderDescriptor GetProvider(LinkProviderKind kind)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (ProviderMap.ContainsKey(kind))
		{
			return ProviderMap[kind];
		}
		throw new ArgumentOutOfRangeException("kind", (object)kind, "未知的联机供应商");
	}

	public static LinkProviderState GetState(LinkProviderKind kind)
	{
		switch (kind)
		{
		case LinkProviderKind.OpenFrp:
		{
			object objectValue3 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkOpenFrpToken"));
			return new LinkProviderState
			{
				IsLoggedIn = !string.IsNullOrWhiteSpace(Conversions.ToString(objectValue3)),
				Username = Conversions.ToString(ModBase.Setup.Get("LinkOpenFrpUser")),
				TokenPreview = Conversions.ToString(objectValue3),
				CookieText = Conversions.ToString(ModBase.Setup.Get("LinkOpenFrpCookies"))
			};
		}
		case LinkProviderKind.MeFrp:
		{
			object objectValue = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkMeFrpToken"));
			return new LinkProviderState
			{
				IsLoggedIn = !string.IsNullOrWhiteSpace(Conversions.ToString(objectValue)),
				Username = Conversions.ToString(ModBase.Setup.Get("LinkMeFrpUser")),
				TokenPreview = Conversions.ToString(objectValue),
				CookieText = Conversions.ToString(ModBase.Setup.Get("LinkMeFrpCookies"))
			};
		}
		case LinkProviderKind.Natfrp:
		{
			object objectValue2 = RuntimeHelpers.GetObjectValue(ModBase.Setup.Get("LinkNaidRefreshToken"));
			string text4 = "";
			string text5 = "";
			try
			{
				text4 = Conversions.ToString(ModBase.Setup.Get("LinkNatfrpUser"));
				text5 = Conversions.ToString(ModBase.Setup.Get("LinkNatfrpCookies"));
			}
			catch (System.Exception ex5)
			{
				ProjectData.SetProjectError(ex5);
				System.Exception ex6 = ex5;
				text4 = "";
				text5 = "";
				ProjectData.ClearProjectError();
			}
			return new LinkProviderState
			{
				IsLoggedIn = !string.IsNullOrWhiteSpace(Conversions.ToString(objectValue2)),
				Username = text4,
				TokenPreview = Conversions.ToString(objectValue2),
				CookieText = text5
			};
		}
		case LinkProviderKind.XhFrp:
		{
			string text6 = "";
			string text7 = "";
			string text8 = "";
			try
			{
				text6 = Conversions.ToString(ModBase.Setup.Get("LinkXhFrpToken"));
			}
			catch (System.Exception ex7)
			{
				ProjectData.SetProjectError(ex7);
				System.Exception ex8 = ex7;
				text6 = "";
				ProjectData.ClearProjectError();
			}
			try
			{
				text7 = Conversions.ToString(ModBase.Setup.Get("LinkXhFrpUser"));
				text8 = Conversions.ToString(ModBase.Setup.Get("LinkXhFrpCookies"));
			}
			catch (System.Exception ex9)
			{
				ProjectData.SetProjectError(ex9);
				System.Exception ex10 = ex9;
				text7 = "";
				text8 = "";
				ProjectData.ClearProjectError();
			}
			return new LinkProviderState
			{
				IsLoggedIn = !string.IsNullOrWhiteSpace(text6),
				Username = text7,
				TokenPreview = text6,
				CookieText = text8
			};
		}
		case LinkProviderKind.Stellarfrp:
		{
			string text = "";
			string text2 = "";
			string text3 = "";
			try
			{
				text = Conversions.ToString(ModBase.Setup.Get("LinkStellarfrpToken"));
			}
			catch (System.Exception ex)
			{
				ProjectData.SetProjectError(ex);
				System.Exception ex2 = ex;
				text = "";
				ProjectData.ClearProjectError();
			}
			try
			{
				text2 = Conversions.ToString(ModBase.Setup.Get("LinkStellarfrpUser"));
				text3 = Conversions.ToString(ModBase.Setup.Get("LinkStellarfrpCookies"));
			}
			catch (System.Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				System.Exception ex4 = ex3;
				text2 = "";
				text3 = "";
				ProjectData.ClearProjectError();
			}
			return new LinkProviderState
			{
				IsLoggedIn = !string.IsNullOrWhiteSpace(text),
				Username = text2,
				TokenPreview = text,
				CookieText = text3
			};
		}
		default:
			return new LinkProviderState
			{
				IsLoggedIn = false
			};
		}
	}

	public static void MarkLoggedIn(LinkProviderKind kind, string token = "", string username = "")
	{
		switch (kind)
		{
		case LinkProviderKind.OpenFrp:
			ModBase.Setup.Set("LinkOpenFrpToken", string.IsNullOrWhiteSpace(token) ? "webview2" : token);
			if (!string.IsNullOrWhiteSpace(username))
			{
				ModBase.Setup.Set("LinkOpenFrpUser", username);
			}
			break;
		case LinkProviderKind.MeFrp:
			ModBase.Setup.Set("LinkMeFrpToken", string.IsNullOrWhiteSpace(token) ? "webview2" : token);
			if (!string.IsNullOrWhiteSpace(username))
			{
				ModBase.Setup.Set("LinkMeFrpUser", username);
			}
			break;
		case LinkProviderKind.Natfrp:
			ModBase.Setup.Set("LinkNaidRefreshToken", string.IsNullOrWhiteSpace(token) ? "webview2" : token);
			break;
		case LinkProviderKind.XhFrp:
			ModBase.Setup.Set("LinkXhFrpToken", string.IsNullOrWhiteSpace(token) ? "webview2" : token);
			if (!string.IsNullOrWhiteSpace(username))
			{
				ModBase.Setup.Set("LinkXhFrpUser", username);
			}
			break;
		case LinkProviderKind.Stellarfrp:
			ModBase.Setup.Set("LinkStellarfrpToken", string.IsNullOrWhiteSpace(token) ? "webview2" : token);
			if (!string.IsNullOrWhiteSpace(username))
			{
				ModBase.Setup.Set("LinkStellarfrpUser", username);
			}
			break;
		}
	}

	public static void SignOut(LinkProviderKind kind)
	{
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		//IL_0106: Expected O, but got Unknown
		switch (kind)
		{
		case LinkProviderKind.OpenFrp:
			ModBase.Setup.Set("LinkOpenFrpToken", "");
			ModBase.Setup.Set("LinkOpenFrpUser", "");
			ModBase.Setup.Set("LinkOpenFrpCookies", "");
			break;
		case LinkProviderKind.MeFrp:
			ModBase.Setup.Set("LinkMeFrpToken", "");
			ModBase.Setup.Set("LinkMeFrpUser", "");
			ModBase.Setup.Set("LinkMeFrpCookies", "");
			break;
		case LinkProviderKind.Natfrp:
			ModBase.Setup.Set("LinkNaidRefreshToken", "");
			ModBase.Setup.Set("LinkNaidRefreshExpiresAt", "");
			ModBase.Setup.Set("LinkNatfrpCookies", "");
			try
			{
				ModBase.Setup.Set("LinkNatfrpUser", "");
			}
			catch (KeyNotFoundException val)
			{
				ProjectData.SetProjectError((System.Exception)val);
				KeyNotFoundException val2 = val;
				ProjectData.ClearProjectError();
			}
			NatayarkProfileManager.NaidProfile.Username = "";
			NatayarkProfileManager.NaidProfile.AccessToken = "";
			NatayarkProfileManager.NaidProfile.RefreshToken = "";
			NatayarkProfileManager.NaidProfile.Status = 0;
			NatayarkProfileManager.NaidProfile.IsRealNamed = false;
			break;
		case LinkProviderKind.XhFrp:
			ModBase.Setup.Set("LinkXhFrpToken", "");
			ModBase.Setup.Set("LinkXhFrpUser", "");
			ModBase.Setup.Set("LinkXhFrpCookies", "");
			break;
		case LinkProviderKind.Stellarfrp:
			ModBase.Setup.Set("LinkStellarfrpToken", "");
			ModBase.Setup.Set("LinkStellarfrpUser", "");
			ModBase.Setup.Set("LinkStellarfrpCookies", "");
			break;
		}
	}
}
