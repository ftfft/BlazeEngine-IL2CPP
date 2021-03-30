using System;
using UnityEngine;
using BlazeIL.il2cpp;
using System.Linq;

namespace IL2Photon.Pun.UtilityScripts
{
    public class PhotonLagSimulationGui : MonoBehaviour
    {
        public PhotonLagSimulationGui(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().FirstOrDefault(x => x.GetProperties(y => y.GetGetMethod()?.ReturnType?.Name == IL2ExitGames.Client.Photon.PhotonPeer.Instance_Class.FullName).Length == 1);
    }
}
