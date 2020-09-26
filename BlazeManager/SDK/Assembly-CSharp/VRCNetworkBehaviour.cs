using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using Photon.Pun;
using VRC.SDKBase;

public abstract class VRCNetworkBehaviour : MonoBehaviourPun
{
    public VRCNetworkBehaviour(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Property propertyPhotonView = null;
    public new PhotonView photonView
    {
        get
        {
            if (propertyPhotonView == null)
            {
                propertyPhotonView = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == PhotonView.Instance_Class.FullName);
                if (propertyPhotonView == null)
                    return default;
            }

            return propertyPhotonView.GetGetMethod().Invoke(ptr)?.Unbox<PhotonView>();
        }
    }

    private static IL2Property propertyVRC_EventHandler = null;
    public VRC_EventHandler eventHandler
    {
        get
        {
            if (propertyVRC_EventHandler == null)
            {
                propertyVRC_EventHandler = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == VRC_EventHandler.Instance_Class.FullName);
                if (propertyVRC_EventHandler == null)
                    return default;
            }

            return propertyVRC_EventHandler.GetGetMethod().Invoke(ptr)?.Unbox<VRC_EventHandler>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCNetworkBehaviour");
}