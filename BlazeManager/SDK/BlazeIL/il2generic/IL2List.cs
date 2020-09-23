using System;
using BlazeIL.il2cpp;

namespace BlazeIL.il2generic
{
    unsafe public class IL2List : IL2Base
    {
        public IL2List(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        public static IL2Type Instance_Class = Assemblies.a["mscorlib"].GetClass("List`1", "System.Collections.Generic");
    }
    unsafe public class IL2List<T> : IL2List
    {
        public IL2List(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Method methodAdd = null;
        public void Add(IntPtr item)
        {
            if (methodAdd == null)
            {
                methodAdd = Instance_Class.GetMethod("Add", x => x.ReturnType.Name == typeof(void).FullName);
                if (methodAdd == null)
                    return;
            }
            methodAdd.Invoke(ptr, new IntPtr[] { item, methodAdd.ptr });
        }

        private static IL2Method methodContainsObject = null;
        public bool Contains(IntPtr item)
        {
            if (methodContainsObject == null)
            {
                methodContainsObject = Instance_Class.GetMethod("Contains", x => x.GetParameters()[0].ReturnType.Name != typeof(object).FullName);
                if (methodContainsObject == null)
                    return false;
            }
            return methodContainsObject.Invoke(ptr, new IntPtr[] { item, methodContainsObject.ptr }).MonoCast<bool>();
        }

        private static IL2Method methodRemove = null;
        public bool Remove(IntPtr item)
        {
            if (methodRemove == null)
            {
                methodRemove = Instance_Class.GetMethod("Remove", x => x.ReturnType.Name == typeof(bool).FullName);
                if (methodRemove == null)
                    return false;
            }
            return methodRemove.Invoke(ptr, new IntPtr[] { item, methodRemove.ptr }).MonoCast<bool>();
        }

        private static IL2Method methodToArray = null;
        public T[] ToArray()
        {
            if (methodToArray == null)
            {
                methodToArray = Instance_Class.GetMethod("ToArray");
                if (methodToArray == null)
                    return null;
            }

            IL2Object result = methodToArray.Invoke(ptr, new IntPtr[] { methodToArray.ptr });
            if (result == null)
                return new T[0];

            return result.UnboxArray<T>();
        }

        public static new IL2Type Instance_Class = IL2List.Instance_Class.MakeGenericType(new Type[] { typeof(T) });
    }
}
