using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace IL2ExitGames.Client.Photon
{
    public class Hashtable : IL2Base
    {
        public Hashtable(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public IntPtr this[IntPtr key]
        {
            get
            {
                IL2Object result = Instance_Class.GetProperty("Item").GetGetMethod().Invoke(ptr, new IntPtr[] { key });
                return (result == null) ? IntPtr.Zero : result.ptr;
            }
            set => Instance_Class.GetProperty("Item").GetSetMethod().Invoke(ptr, new IntPtr[] { key, value });
        }

//        public new IEnumerator<DictionaryEntry> GetEnumerator()
//        {
//            return new DictionaryEntryEnumerator(((IDictionary)this).GetEnumerator());
//        }

        public new IL2String ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.unbox_ToString();
        }

        //        public object Clone()
        //        {
        //            return new Dictionary<object, object>(this);
        //        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.photon3unity3d]].GetClass("Hashtable", "ExitGames.Client.Photon");
    }
}