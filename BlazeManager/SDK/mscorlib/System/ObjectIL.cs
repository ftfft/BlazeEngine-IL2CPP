using System;
using BlazeIL.il2cpp;

namespace System
{
    public class ObjectIL : IL2Base
    {
        public ObjectIL(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public TypeIL GetTypeIL()
        {
            return Instance_Class.GetMethod("GetType").Invoke(ptr).unbox<TypeIL>();
        }

        public new IL2String ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.unbox_ToString();
        }


        public static IL2Type Instance_Class = Assemblies.a["mscorlib"].GetClass("Object", "System");
    }
}
