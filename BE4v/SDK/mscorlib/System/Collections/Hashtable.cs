using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace System.Collections
{
    public class IL2Hashtable : IL2Base
    {
        public IL2Hashtable(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public IntPtr this[IntPtr key]
        {
            get => Instance_Class.GetProperty("Item").GetGetMethod().Invoke(ptr, new IntPtr[] { key }).ptr;
            set => Instance_Class.GetProperty("Item").GetSetMethod().Invoke(ptr, new IntPtr[] { key, value });
        }

        //        public new IEnumerator<DictionaryEntry> GetEnumerator()
        //        {
        //            return new DictionaryEntryEnumerator(((IDictionary)this).GetEnumerator());
        //        }

        public new string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.GetValue<string>();
        }

        //        public object Clone()
        //        {
        //            return new Dictionary<object, object>(this);
        //        }

        public static IL2Class Instance_Class = Assembler.list["mscorlib"].GetClass("Hashtable", "System.Collections");
    }
}