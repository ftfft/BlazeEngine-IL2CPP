using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using UnityEngine;

public abstract class AbstractVRLoadingOverlay : MonoBehaviour
{
    public AbstractVRLoadingOverlay(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetField("worldImageMask") != null);
}