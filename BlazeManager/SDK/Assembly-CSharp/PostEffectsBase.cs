using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;

public class PostEffectsBase : MonoBehaviour
{
    public PostEffectsBase(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PostEffectsBase");
}