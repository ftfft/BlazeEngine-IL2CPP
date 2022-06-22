using System;
using IL2CPP_Core.Objects;

namespace System.Collections.Generic
{
    unsafe public class IL2List : IL2Object
    {
        public IL2List(IntPtr ptr) : base(ptr) { }

        public void Clear()
        {
            Instance_Class.GetMethod(nameof(Clear)).Invoke(this, ex: false);
        }

        public static IL2Class Instance_Class = IL2CPP.AssemblyList["mscorlib"].GetClass("List`1", "System.Collections.Generic");
    }
    unsafe public class IL2List<T> : IL2List
    {
        public IL2List(IntPtr ptr) : base(ptr) { }

        private static IL2Method methodAdd = null;
        public void IL2Add(IntPtr item)
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
        public bool IL2Contains(IntPtr item)
        {
            if (methodContainsObject == null)
            {
                methodContainsObject = Instance_Class.GetMethod("Contains", x => x.GetParameters()[0].ReturnType.Name != typeof(object).FullName);
                if (methodContainsObject == null)
                    return false;
            }
            return methodContainsObject.Invoke(ptr, new IntPtr[] { item, methodContainsObject.ptr }).GetValuе<bool>();
        }

        private static IL2Method methodRemove = null;
        public bool IL2Remove(IntPtr item)
        {
            if (methodRemove == null)
            {
                methodRemove = Instance_Class.GetMethod("Remove", x => x.ReturnType.Name == typeof(bool).FullName);
                if (methodRemove == null)
                    return false;
            }
            return methodRemove.Invoke(ptr, new IntPtr[] { item, methodRemove.ptr }).GetValuе<bool>();
        }

        private static IL2Method methodToArray = null;
        public T[] IL2ToArray()
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

        public static new IL2Class Instance_Class = IL2List.Instance_Class.MakeGenericType(new Type[] { typeof(T) });
    }
}
