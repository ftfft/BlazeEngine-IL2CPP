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
    unsafe public class IL2List<T> : IL2List where T : unmanaged
    {
        public IL2List() { }
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
            methodAdd.Invoke(this, new IntPtr[] { item, methodAdd.Pointer });
        }

        public bool Contains(IntPtr item)
        {
            IL2Method method = Instance_Class.GetMethod("Contains", x => x.GetParameters()[0].ReturnType.Name != typeof(object).FullName);
            return method.Invoke<bool>(this, new IntPtr[] { item, method.Pointer }).GetValue();
        }

        private static IL2Method methodRemove = null;
        public bool Remove(IntPtr item)
        {
            IL2Method method = Instance_Class.GetMethod("Remove", x => x.ReturnType.Name == typeof(bool).FullName);
            return method.Invoke<bool>(this, new IntPtr[] { item, method.Pointer }).GetValue();
        }

        private static IL2Method methodToArray = null;
        public T[] ToArray()
        {
            IL2Method method = Instance_Class.GetMethod("ToArray");
            IL2Object result = method.Invoke(this, new IntPtr[] { method.Pointer });
            if (result == null)
                return new T[0];

            return new IL2Array<T>(result.Pointer).ToArray();
        }

        public static new IL2Class Instance_Class = IL2List.Instance_Class.MakeGenericType(new Type[] { typeof(T) });
    }
}
