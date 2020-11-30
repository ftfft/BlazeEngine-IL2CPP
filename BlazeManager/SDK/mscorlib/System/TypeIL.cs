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

        public static IL2Method methodToString;
        public override string ToString()
        {
            if (methodToString == null)
            {
                methodToString = Instance_Class.GetMethod("ToString");
                if (methodToString == null)
                    return null;
            }

            IL2Object @object = null;
            @object = methodToString.Invoke(ptr);
            if (@object == null)
                return null;

            return new IL2String(@object.ptr).ToString();
        }

        public static IL2Type Instance_Class = Assemblies.a["mscorlib"].GetClass("Type", "System");
    }
}
