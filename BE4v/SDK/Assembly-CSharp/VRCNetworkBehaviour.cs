using System;
using System.Linq;
using IL2CPP_Core.Objects;
using IL2Photon.Pun;

public abstract class VRCNetworkBehaviour : MonoBehaviourPun
{
    public VRCNetworkBehaviour(IntPtr ptr) : base(ptr) { }

    public static new IL2Class Instance_Class = VRCPlayer.Instance_Class.BaseType;
}