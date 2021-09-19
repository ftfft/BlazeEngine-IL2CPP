using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using IL2Photon.Pun;

public abstract class VRCNetworkBehaviour : MonoBehaviourPun
{
    public VRCNetworkBehaviour(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = VRCPlayer.Instance_Class.BaseType;
}