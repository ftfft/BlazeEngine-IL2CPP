using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using Steamworks;

public class SteamNetworkingSocketInterface : SocketInterface
{
    public SteamNetworkingSocketInterface(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("OnConnecting")?.GetParameters().Length == 2);
}