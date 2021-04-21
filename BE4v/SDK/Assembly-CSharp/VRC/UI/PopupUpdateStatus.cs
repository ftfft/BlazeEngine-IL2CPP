using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace VRC.UI
{
    public class PopupUpdateStatus : VRCUiPopup
    {
        public PopupUpdateStatus(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("TrimStatusText") != null);
    }
}
