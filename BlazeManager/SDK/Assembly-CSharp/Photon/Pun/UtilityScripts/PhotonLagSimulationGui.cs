using System;
using UnityEngine;
using BlazeIL.il2cpp;

namespace IL2Photon.Pun.UtilityScripts
{
    public class PhotonLagSimulationGui : MonoBehaviour
    {
        public PhotonLagSimulationGui(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("PhotonLagSimulationGui", "Photon.Pun.UtilityScripts");
    }
}
