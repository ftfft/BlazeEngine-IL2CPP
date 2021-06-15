using System;
using BE4v.SDK.CPP2IL;
using VRC.Core;
using UnityEngine;

namespace Transmtn.DTO.Notifications
{
    public class Notification : IL2Base
    {
        public Notification(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static IL2Class Instance_Class = Assembler.list["Transmtn"].GetClass("Notification", "Transmtn.DTO.Notifications");
    }
}