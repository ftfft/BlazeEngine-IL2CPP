using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace IL2Photon.Pun.UtilityScripts
{
    public class PhotonLagSimulationGui : MonoBehaviour
    {
        public PhotonLagSimulationGui(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        // public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetProperties(y => y.GetGetMethod()?.ReturnType?.Name == IL2ExitGames.Client.Photon.PhotonPeer.Instance_Class.FullName).Length == 1);
    }
}
