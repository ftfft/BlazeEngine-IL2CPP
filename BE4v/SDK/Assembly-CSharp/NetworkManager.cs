using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class NetworkManager : MonoBehaviour
{
    public NetworkManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("OnJoinedRoom") != null && x.GetField(y => y.Instance) != null);
}