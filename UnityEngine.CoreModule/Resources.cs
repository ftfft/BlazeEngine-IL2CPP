#if (DEBUG)
using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    unsafe public sealed class Resources
    {
        private static IL2Method methodFindObjectsOfTypeAll = null;
        public static T[] FindObjectsOfTypeAll<T>()
        {
            Object[] objects = FindObjectsOfTypeAll(typeof(T));
            T[] result = new T[objects.Length];
            for (int i = 0; i < objects.Length; i++)
            {
                result[i] = objects[i].MonoCast<T>();
            }
            return result;
        }
        public static Object[] FindObjectsOfTypeAll(Type type)
        {
            if (methodFindObjectsOfTypeAll == null)
            {
                methodFindObjectsOfTypeAll = Instance_Class.GetMethods()
                    .Where(x => x.Name == "FindObjectsOfTypeAll")
                    .First(x => x.GetReturnType().Name == "UnityEngine.Object[]");
                if (methodFindObjectsOfTypeAll == null)
                    return null;
            }

            IntPtr IntPtrType = Execute.find_typeof_to_type(type);
            if (IntPtrType == IntPtr.Zero || IntPtrType == null)
                return null;

            IL2Object obj = methodFindObjectsOfTypeAll.Invoke(new IntPtr[] { IntPtrType });
            if (obj == null)
                return null;

            IntPtr[] ptrs = obj.UnboxArray();
            Object[] result = new Object[ptrs.Length];
            for (int i = 0; i < ptrs.Length; i++)
                result[i] = ptrs[i].MonoCast<Object>();
            return result;
        }

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Resources", "UnityEngine");
    }
}
#endif
