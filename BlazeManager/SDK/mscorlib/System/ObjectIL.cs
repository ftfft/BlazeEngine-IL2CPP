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
    public class ObjectIL : IL2Base
    {
        public ObjectIL(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Method methodGetTypeIL;
        public TypeIL GetTypeIL()
        {
            if (methodGetTypeIL == null)
            {
                methodGetTypeIL = Instance_Class.GetMethod("GetType");
                if (methodGetTypeIL == null)
                    return null;
            }

            IL2Object @object = null;
            @object = methodGetTypeIL.Invoke(ptr);
            if (@object == null)
                return null;

            return @object.unbox<TypeIL>();
        }

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


        public static IL2Type Instance_Class = Assemblies.a["mscorlib"].GetClass("Object", "System");
    }
}
