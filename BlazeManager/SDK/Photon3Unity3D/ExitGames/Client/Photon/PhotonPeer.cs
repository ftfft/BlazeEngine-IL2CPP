using System;
using BlazeIL.il2cpp;

namespace IL2ExitGames.Client.Photon
{
    public class PhotonPeer : IL2Base
    {
        public PhotonPeer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.photon3unity3d]].GetClass("PhotonPeer", "ExitGames.Client.Photon");
    }
}