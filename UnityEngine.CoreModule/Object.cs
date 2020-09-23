using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    unsafe public class Object : IL2Base
    {
        public Object(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Method methodGetInstantiate = null;
        public static T Instantiate<T>(T original, Transform parent) where T : IL2Base  => Instantiate(original.ptr.MonoCast<Object>(), parent, false).ptr.MonoCast<T>();
        public static Object Instantiate(Object original, Transform parent) => Instantiate(original, parent, false);
        public static T Instantiate<T>(Object original, Transform parent, bool instantiateInWorldSpace) => Instantiate(original, parent, instantiateInWorldSpace).ptr.MonoCast<T>();
        public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace)
        {
            if (methodGetInstantiate == null)
            {
                methodGetInstantiate = Instance_Class.GetMethods()
                    .Where(x => x.Name == "Instantiate"
                        && x.GetParameters().Length == 3
                        && x.GetReturnType().Name == "UnityEngine.Object")
                    .First(x => x.GetParameters()[2].typeName == "System.Boolean");
                if (methodGetInstantiate == null)
                    return null;
            }

            IL2Object result = methodGetInstantiate.Invoke(new IntPtr[] { original.ptr, parent.ptr, new IntPtr(&instantiateInWorldSpace) });
            if (result == null)
                return null;

            return result.ptr.MonoCast<Object>();
        }

        private static IL2Method methodFindObjectsOfType = null;
        public static T FindObjectOfType<T>() => FindObjectOfType(typeof(T)).ptr.MonoCast<T>();
        public static T[] FindObjectsOfType<T>()
        {
            Object[] objs = FindObjectsOfType(typeof(T));
            T[] result = new T[objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                result[i] = objs[i].ptr.MonoCast<T>();
            }
            return result;
        }

        public static Object FindObjectOfType(Type type) => FindObjectsOfType(type)[0];
        public static Object[] FindObjectsOfType(Type type)
        {
            if (methodFindObjectsOfType == null)
            {
                methodFindObjectsOfType = Instance_Class.GetMethod("FindObjectsOfType", x => x.GetParameters().Length == 1);
                if (methodFindObjectsOfType == null)
                    return null;
            }

            IntPtr IntPtrType = Execute.find_typeof_to_type(type);
            if (IntPtrType == IntPtr.Zero)
                return null;

            IL2Object obj = null;
            obj = methodFindObjectsOfType.Invoke(new IntPtr[] { IntPtrType });
            if (obj == null)
                return null;

            IntPtr[] ptrs = obj.UnboxArray();
            Object[] result = new Object[ptrs.Length];
            for (int i = 0; i < ptrs.Length; i++)
                result[i] = ptrs[i].MonoCast<Object>();

            return result;
        }

        private static IL2Method methodDestroy = null;
        public void Destroy() => Destroy(0f);
        public void Destroy(float time) => Destroy(this, time);
        public static void Destroy(Object obj) => Destroy(obj, 0f);
        public static void Destroy(Object obj, float time)
        {
            if (methodDestroy == null)
            {
                methodDestroy = Instance_Class.GetMethod("Destroy", m => m.GetParameters().Length == 2);
                if (methodDestroy == null)
                    return;
            }
            if (obj == null || time < 0)
                return;

            methodDestroy.Invoke(new IntPtr[] { obj.ptr, new IntPtr(&time) });
        }

        private static IL2Method methodFindObjectFromInstanceID = null;
        public static Object FindObjectFromInstanceID(int instanceID)
        {
            if (methodFindObjectFromInstanceID == null)
            {
                methodFindObjectFromInstanceID = Instance_Class.GetMethod("FindObjectFromInstanceID");
                if (methodFindObjectFromInstanceID == null)
                    return null;
            }

            IL2Object result = methodFindObjectFromInstanceID.Invoke(new IntPtr[] { new IntPtr(&instanceID) });
            if (result == null)
                return null;

            return result.ptr.MonoCast<Object>();
        }

        private static IL2Method methodDontDestroyOnLoad = null;
        public static void DontDestroyOnLoad(Object target)
        {
            if (methodDontDestroyOnLoad == null)
            {
                methodDontDestroyOnLoad = Instance_Class.GetMethod("DontDestroyOnLoad");
                if (methodDontDestroyOnLoad == null)
                    return;
            }
            if (target.ptr == IntPtr.Zero)
                return;

            methodDontDestroyOnLoad.Invoke(new IntPtr[] { target.ptr });
        }

        private static IL2Property propertyName = null;
        public string name
        {
            get
            {
                if(propertyName == null)
                {
                    propertyName = Instance_Class.GetProperty("name");
                    if (propertyName == null)
                        return null;
                }

                IL2Object result = null;
                result = propertyName.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return null;

                return result.UnboxString();
            }
            set
            {
                if (propertyName == null)
                {
                    propertyName = Instance_Class.GetProperty("name");
                    if (propertyName == null)
                        return;
                }

                propertyName.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }


        private static IL2Method methodToString = null;
        public override string ToString()
        {
            if (methodToString == null)
            {
                methodToString = Instance_Class.GetMethod("ToString");
                if (methodToString == null)
                    return null;
            }

            IL2Object result = methodToString.Invoke(ptr);
            if (result == null)
                return null;

            return result.UnboxString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Object))
                return false;
            return ((Object)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Object", "UnityEngine");
    }
}
