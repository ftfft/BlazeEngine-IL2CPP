using System;
using BE4v.SDK.CPP2IL;

namespace IL2ExitGames.Client.Photon
{
    public class PhotonPeer : IL2Base
    {
        public PhotonPeer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static IL2Class Instance_Class = Assembler.list["Photon"].GetClass("PhotonPeer", "ExitGames.Client.Photon");
    }
}