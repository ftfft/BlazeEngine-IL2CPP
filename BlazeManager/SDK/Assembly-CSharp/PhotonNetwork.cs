using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

public static class PhotonNetwork
{
    private static IL2Field fieldPhotonPeer = null;
    public static NetworkingPeer networkingPeer
    {
        get
        {
            if (fieldPhotonPeer == null)
            {
                fieldPhotonPeer = Instance_Class.GetFields().First(x => x.ReturnType.Name == NetworkingPeer.Instance_Class.FullName);
                if (fieldPhotonPeer == null)
                    return null;
            }
            return fieldPhotonPeer.GetValue()?.MonoCast<NetworkingPeer>();
        }
    }

    public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClasses().First(x => x.GetFields().Where(y => y.ReturnType.Name == "Photon.Pun.ServerSettings").Count() == 1);
}
