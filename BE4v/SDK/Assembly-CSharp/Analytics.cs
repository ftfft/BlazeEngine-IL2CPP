using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using VRC.SDKBase;

public class Analytics : MonoBehaviour
{
    public Analytics(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetField(VRCInputMethod_Class.Instance_Class) != null);
}