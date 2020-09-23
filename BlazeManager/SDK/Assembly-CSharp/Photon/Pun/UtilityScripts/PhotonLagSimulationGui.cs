using System;
using UnityEngine;
using BlazeIL.il2cpp;

namespace Photon.Pun.UtilityScripts
{
    public class PhotonLagSimulationGui : MonoBehaviour
    {
        public PhotonLagSimulationGui(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PhotonLagSimulationGui", "Photon.Pun.UtilityScripts");
    }
}
