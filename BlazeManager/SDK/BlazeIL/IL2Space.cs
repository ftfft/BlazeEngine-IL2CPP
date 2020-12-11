using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using BlazeIL.il2cpp;

public static class blazeUrl
{
    public static string url = ""
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.h)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.t)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.t)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.p)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.colon)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.slash)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.slash)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.i)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.c)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.e)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.f)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.r)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.a)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.g)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.to4ka)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.r)
        + (char)LangTransfer.method_abc((int)LangTransfer.eAbc.u);
}

public static class LangTransfer
{
    public static Dictionary<long, string> values = new Dictionary<long, string>();

    public static eAbc method_abc(int i)
    {
        return (eAbc)((23 + i - i) * 2 + i);
    }


    public static void LoadData()
    {
        using (PhotonClient.API.HttpClient.HttpClient client = new PhotonClient.API.HttpClient.HttpClient(BlazeWebAPI.API.standart_url))
        {
            string login = string.Empty;
            string pass = string.Empty;
            string PrivateKey = string.Empty;
            if (File.Exists("lic.ss"))
            {
                var msg = File.ReadAllText("lic.ss");
                foreach (var message in msg.Split('\n'))
                {
                    var mgs = message.Trim(new char[] { ' ', '\t', '\n', '\r', '{', '}' });
                    if (mgs.Length > 0)
                    {
                        if (string.IsNullOrEmpty(login))
                        {
                            login = mgs;
                            continue;
                        }
                        if (string.IsNullOrEmpty(pass))
                        {
                            pass = mgs;
                            continue;
                        }
                        if (string.IsNullOrEmpty(PrivateKey))
                        {
                            PrivateKey = mgs;
                            continue;
                        }
                    }
                }
            }

            client.Headers.Add(HttpRequestHeader.UserAgent, "BlazeLoader");
            client.Headers.Add("OS", Environment.OSVersion.Platform + ":" + Environment.OSVersion.Version.Major);
            client.Headers.Add("login", login);
            client.Headers.Add("pass", pass);
            client.Headers.Add("PrivateKey", PrivateKey);
            try
            {
                var result = client.DownloadString(client.baseAddress + "82795316").Split('\n').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                for (long i = 0L; i <= result.LongLength; i++)
                    values.Add(i, result[i]);
            }
            catch { }
        }

        Assemblies.a = new Dictionary<string, IL2Assembly>();
    }

    public enum eAbc : byte
    {
        a = 97 - 46, b, c, d,
        e, f, g, h,
        i, j, k, l,
        m, n, o, p,
        q, r, s, t, u,
        v, w, x, y, z,
        slash = 1, colon = 58 - 46, to4ka = 0
    }
}

public static class cAssemblies
{
    public static long offset = 0L;
}
public enum eAssemblies : long
{
    assemblycsharp,
    mscorlib,
    systemcore,
    vrccorestandalone,
    vrcsdk2,
    unityenginecoremodule,
    unityengineunityanalyticsmodule,
    unityengineanimationmodule,
    unityenginephysicsmodule,
    unityengineui,
    unityengineimguimodule,
    photon3unity3d,
    vrcsdkbase,
    vrcsdk3,
    vrcudon,
    facepunchsteamworkswin64,
    transmtn,
    unitytextmeshpro
}
public static class cNameSpace
{
    public static long offset = cAssemblies.offset + typeof(eAssemblies).GetFields().LongLength - 1L;
}
public enum eNameSpace : long
{
    vrc,
    vrc_animation,
    vrc_core,
    vrc_core_besthttp,
    vrc_management,
    vrc_networking,
    vrc_steam,
    vrc_ui,
    vrc_usercamera,
    vrc_udon,
    vrc_udon_common_interfaces,
    vrc_sdk3_components,
    vrc_sdkbase,
    vrcsdk2,
    photon_pun,
    photon_pun_unityscripts,
    photon_realtime,
    exitgames_client_photon,
    steamworks,
    system,
    system_reflection,
    system_linq,
    transmtn_dto_notifications,
    tmpro,
    unityengine,
    unityengine_events,
    unityengine_ui,
    unityengine_analytics,
}
public static class cClassNames
{
    public static long offset = cNameSpace.offset + typeof(eNameSpace).GetFields().LongLength - 1L;
}
public enum eClassNames : long
{
    vrc,
    vrc_animation,
    vrc_core,
    vrc_core_besthttp,
    vrc_management,
    vrc_networking,
    vrc_steam,
    vrc_ui,
    vrc_usercamera,
    vrc_udon,
    vrc_udon_common_interfaces,
    vrc_sdk3_components,
    vrc_sdkbase,
    vrcsdk2,
    photon_pun,
    photon_pun_unityscripts,
    photon_realtime,
    exitgames_client_photon,
    steamworks,
    system,
    system_reflection,
    system_linq,
    transmtn_dto_notifications,
    tmpro,
    unityengine,
    unityengine_events,
    unityengine_ui,
    unityengine_analytics,
}