using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using UnityEngine;

namespace VRC.UserCamera
{
    public class CameraInteractable : MonoBehaviour
    {
        public CameraInteractable(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("OnPickupUseDown") != null);
    }
}
