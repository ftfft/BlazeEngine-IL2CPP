using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using IL2Photon.Pun;
using VRC.SDKBase;

public abstract class VRCNetworkBehaviour : MonoBehaviourPun
{
    public VRCNetworkBehaviour(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public new PhotonView photonView
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(photonView));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == PhotonView.Instance_Class.FullName)).Name = nameof(photonView);

            return property?.GetGetMethod().Invoke(ptr)?.unbox<PhotonView>();
        }
    }

    public VRC_EventHandler EventHandler
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(EventHandler));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == VRC_EventHandler.Instance_Class.FullName)).Name = nameof(EventHandler);

            return property?.GetGetMethod().Invoke(ptr)?.unbox<VRC_EventHandler>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("VRCNetworkBehaviour");
}