#if (DEBUG)
using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace ExitGames.Client.Photon
{
    public class Hashtable : IL2Base
    {
        public Hashtable(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;


        static IL2Property propertyItem = null;
        public object this[object key]
        {
            get
            {
                if (propertyItem == null)
                {
                    propertyItem = Instance_Class.GetProperty("Item");
                    if (propertyItem == null)
                        return null;
                }
                if (ptr == IntPtr.Zero)
                    return null;

                return propertyItem.GetGetMethod().Invoke(ptr, new IntPtr[] { IL2Import.ObjectToIntPtr(key) }).ptr.MonoCast<Hashtable>();
            }
            set
            {
                if (propertyItem == null)
                {
                    propertyItem = Instance_Class.GetProperty("Item");
                    if (propertyItem == null)
                        return;
                }
                if (ptr == IntPtr.Zero)
                    return;

                propertyItem.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.ObjectToIntPtr(key), IL2Import.ObjectToIntPtr(value) });
            }
        }

//        public new IEnumerator<DictionaryEntry> GetEnumerator()
//        {
//            return new DictionaryEntryEnumerator(((IDictionary)this).GetEnumerator());
//        }

        static IL2Method methodToString = null;
        public override string ToString()
        {
            if (methodToString == null)
            {
                methodToString = Instance_Class.GetMethod("ToString");
                if (methodToString == null)
                    return string.Empty;
            }

            if (ptr == IntPtr.Zero)
                return string.Empty;

            var result = methodToString.Invoke(ptr);
            return (result == null) ? string.Empty : result.UnboxString();
        }

        //        public object Clone()
        //        {
        //            return new Dictionary<object, object>(this);
        //        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Hashtable))
                return false;
            return ((Hashtable)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("Hashtable", "ExitGames.Client.Photon");
    }
}
#endif