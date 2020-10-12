using System;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace ExitGames.Client.Photon
{
    public class Hashtable : IL2Base
    {
        public Hashtable(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Property propertyItem = null;
        public IntPtr this[IntPtr key]
        {
            get
            {
                if (propertyItem == null)
                {
                    propertyItem = Instance_Class.GetProperty("Item");
                    if (propertyItem == null)
                        return IntPtr.Zero;
                }

                IL2Object @object = propertyItem.GetGetMethod().Invoke(ptr, new IntPtr[] { key });
                if (@object == null)
                    return IntPtr.Zero;

                return @object.ptr;
            }
            set
            {
                if (propertyItem == null)
                {
                    propertyItem = Instance_Class.GetProperty("Item");
                    if (propertyItem == null)
                        return;
                }

                propertyItem.GetSetMethod().Invoke(ptr, new IntPtr[] { key, value });
            }
        }

//        public new IEnumerator<DictionaryEntry> GetEnumerator()
//        {
//            return new DictionaryEntryEnumerator(((IDictionary)this).GetEnumerator());
//        }

        static IL2Method methodToString = null;
        public override string ToString()
        {
            IntPtr ptr = ToString_Pointer();
            if (ptr == IntPtr.Zero)
                return null;

            return ptr.MonoCast<string>();
        }
        public IntPtr ToString_Pointer()
        {
            if (!IL2Get.Method("ToString", Instance_Class, ref methodToString))
                return default;

            IL2Object @object = methodToString.Invoke(ptr);
            if (@object == null)
                return IntPtr.Zero;
            
            return @object.ptr;
        }

        //        public object Clone()
        //        {
        //            return new Dictionary<object, object>(this);
        //        }

        public static IL2Type Instance_Class = Assemblies.a["Photon3Unity3D"].GetClass("Hashtable", "ExitGames.Client.Photon");
    }
}