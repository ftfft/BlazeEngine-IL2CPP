using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BlazeTools;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace System
{
    public class TypeIL : IL2Base
    {
        public TypeIL(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public new IL2String ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.unbox_ToString();
        }

        public static IL2Type Instance_Class = Assemblies.a["mscorlib"].GetClass("Type", "System");
    }
}
