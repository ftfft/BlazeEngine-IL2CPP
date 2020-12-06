using System;
using System.Runtime.InteropServices;

namespace BlazeIL.il2cpp
{
    unsafe public class IL2Field : IL2Base
    {
        internal IL2Field(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        private string szName;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(szName))
                    szName = Marshal.PtrToStringAnsi(IL2Import.il2cpp_field_get_name(ptr));
                return szName;
            }
            set => szName = value;
        }
        public IL2ReturnType ReturnType => new IL2ReturnType(IL2Import.il2cpp_field_get_type(ptr));
        public int Token => IL2Import.il2cpp_field_get_offset(ptr);

        public IL2BindingFlags Flags
        {
            get
            {
                uint flags = 0;
                return (IL2BindingFlags)IL2Import.il2cpp_field_get_flags(ptr, ref flags);
            }
        }
        public bool HasFlag(IL2BindingFlags flag) => ((Flags & flag) != 0);

        public bool IsStatic => HasFlag(IL2BindingFlags.FIELD_STATIC);
        public bool IsPrivate => HasFlag(IL2BindingFlags.FIELD_PRIVATE);
        public bool IsPublic => HasFlag(IL2BindingFlags.FIELD_PUBLIC);

        public bool Instance => IsStatic && ReturnType.Name == ReflectedType.FullName;
        public IL2Type ReflectedType => new IL2Type(IL2Import.il2cpp_field_get_parent(ptr));

        public bool HasAttribute(IL2Type klass)
        {
            if (klass == null) return false;
            return IL2Import.il2cpp_field_has_attribute(ptr, klass.ptr);
        }

        public IL2Object GetValue() => GetValue(IntPtr.Zero);
        public IL2Object GetValue(IntPtr obj)
        {
            IntPtr returnval = IntPtr.Zero;
            if (HasFlag(IL2BindingFlags.FIELD_STATIC))
                returnval = IL2Import.il2cpp_field_get_value_object(ptr, IntPtr.Zero);
            else
                returnval = IL2Import.il2cpp_field_get_value_object(ptr, obj);
            if (returnval != IntPtr.Zero)
                return new IL2Object(returnval, ReturnType);
            return null;
        }
        public void SetValue(IntPtr value) => SetValue(IntPtr.Zero, value);
        public void SetValue(IntPtr obj, IntPtr value)
        {
            if (HasFlag(IL2BindingFlags.FIELD_STATIC))
                IL2Import.il2cpp_field_static_set_value(ptr, value);
            else
                IL2Import.il2cpp_field_set_value(obj, ptr, value);
        }
    }
}
