using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using UnityEngine;

public class F3DShotgun : MonoBehaviour
{
    public F3DShotgun(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByMethodName("OnParticleCollision");
}