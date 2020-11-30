using System;
using System.Runtime.InteropServices;

namespace BlazeIL.il2cpp
{
    public class IL2Property : IL2Base
    {
        internal IL2Property(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public string Name
        {
            get
            {
                var result = Marshal.PtrToStringAnsi(IL2Import.il2cpp_property_get_name(ptr));
                if (Assemblies.isObfuscated == "tr")
                    result = result.GetMD5();

                return result;
            }
        }

        public IL2BindingFlags Flags => (IL2BindingFlags)IL2Import.il2cpp_property_get_flags(ptr);
        public bool HasFlag(IL2BindingFlags flag) => ((Flags & flag) != 0);
        public bool Instance => GetGetMethod() != null && GetGetMethod().Instance;

        public IL2Method GetGetMethod()
        {
            if(getMethod == null)
            {
                IntPtr method = IL2Import.il2cpp_property_get_get_method(ptr);
                if (method != IntPtr.Zero)
                    getMethod = new IL2Method(method);
            }
            return getMethod;
        }
        private IL2Method getMethod;
        public IL2Method GetSetMethod()
        {
            if (setMethod == null)
            {
                IntPtr method = IL2Import.il2cpp_property_get_set_method(ptr);
                if (method != IntPtr.Zero)
                    setMethod = new IL2Method(method);
            }
            return setMethod;
        }
        private IL2Method setMethod;

        public bool IsStatic => HasFlag(IL2BindingFlags.METHOD_STATIC);
    }
}
