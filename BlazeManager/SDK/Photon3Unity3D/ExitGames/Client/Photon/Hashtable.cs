using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace ExitGames.Client.Photon
{
    public class Hashtable : IL2Base
    {
        public Hashtable(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public IntPtr this[IntPtr key]
        {
            get => Instance_Class.GetProperty("Item").GetGetMethod().Invoke(ptr, new IntPtr[] { key }).ptr;
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

        public static IL2Type Instance_Class = Assemblies.a["Photon3Unity3D"].GetClass("Hashtable", "ExitGames.Client.Photon");
    }
}