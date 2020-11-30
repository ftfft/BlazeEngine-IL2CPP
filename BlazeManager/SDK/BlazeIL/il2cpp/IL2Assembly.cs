using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BlazeIL.il2cpp
{
    public class IL2Assembly : IL2Base
    {
        public string Name { get; private set; }
        private List<IL2Type> ClassList = new List<IL2Type>();
        internal IL2Assembly(IntPtr ptr) : base(ptr)
        {
            base.ptr = ptr;
            Name = Path.GetFileNameWithoutExtension(Marshal.PtrToStringAnsi(IL2Import.il2cpp_image_get_name(ptr)));
            if (Assemblies.isObfuscated == "tr")
                Name = Name.GetMD5();

            // Map out Classes
            uint count = IL2Import.il2cpp_image_get_class_count(ptr);
            for (uint i = 0; i < count; i++)
                ClassList.Add(new IL2Type(IL2Import.il2cpp_image_get_class(ptr, i)));
        }
        public IL2Type[] GetClasses() => ClassList.ToArray();
        public IL2Type[] GetClasses(IL2BindingFlags flags) => GetClasses().Where(x => x.HasFlag(flags)).ToArray();
        public IL2Type GetClass(IntPtr ptr) => GetClasses().Where(x => x.ptr == ptr).FirstOrDefault();
        public IL2Type GetClass(string name) => GetClass(name, null);
        public IL2Type GetClass(string name, IL2BindingFlags flags) => GetClass(name, null, flags);
        public IL2Type GetClass(string name, string name_space)
        {
            IL2Type returnval = null;
            foreach (IL2Type type in GetClasses())
            {
                if (type.Name.Equals(name) && (string.IsNullOrEmpty(type.Namespace) || type.Namespace.Equals(name_space)))
                {
                    returnval = type;
                    break;
                }
                else
                {
                    foreach (IL2Type nestedtype in type.GetNestedTypes())
                    {
                        if (nestedtype.Name.Equals(name) && (string.IsNullOrEmpty(nestedtype.Namespace) || nestedtype.Namespace.Equals(name_space)))
                        {
                            returnval = nestedtype;
                            break;
                        }
                    }
                    if (returnval != null)
                        break;
                }
            }
            return returnval;
        }
        public IL2Type GetClass(string name, string name_space, IL2BindingFlags flags)
        {
            IL2Type returnval = null;
            foreach (IL2Type type in GetClasses())
            {
                if (type.Name.Equals(name) && (string.IsNullOrEmpty(type.Namespace) || type.Namespace.Equals(name_space)) && type.HasFlag(flags))
                {
                    returnval = type;
                    break;
                }
                else
                {
                    foreach (IL2Type nestedtype in type.GetNestedTypes())
                    {
                        if (nestedtype.Name.Equals(name) && (string.IsNullOrEmpty(nestedtype.Namespace) || nestedtype.Namespace.Equals(name_space)) && nestedtype.HasFlag(flags))
                        {
                            returnval = nestedtype;
                            break;
                        }
                    }
                    if (returnval != null)
                        break;
                }
            }
            return returnval;
        }
    }
}
