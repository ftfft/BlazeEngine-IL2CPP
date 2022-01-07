using System;
using System.Linq;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
    public class Object : IL2Base
    {
        public Object(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static T Instantiate<T>(T original, Transform parent) where T : Object
        {
            return Instantiate(original.MonoCast<Object>(), parent, false)?.MonoCast<T>();
        }
        public static Object Instantiate(Object original, Transform parent) => Instantiate(original, parent, false);
        public static T Instantiate<T>(Object original, Transform parent, bool instantiateInWorldSpace) where T : Object
        {
            return Instantiate(original, parent, instantiateInWorldSpace)?.MonoCast<T>();
        }
        unsafe public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace)
        {
            return Instance_Class.GetMethod(nameof(Instantiate),
                x => x.GetParameters().Length == 3
                && x.GetParameters()[2].ReturnType.Name == typeof(bool).FullName
                && x.ReturnType.Name == Instance_Class.FullName).Invoke(new IntPtr[] { original.ptr, parent.ptr, new IntPtr(&instantiateInWorldSpace) })?.GetValue<Object>();
        }

        public static T FindObjectOfType<T>() where T : Object
        {
            var result = FindObjectsOfType<T>();
            if (result != null)
                if (result.Length > 0)
                    return result[0];

            return null;
        }

        public static T[] FindObjectsOfType<T>()
        {
            Object[] result = FindObjectsOfType(typeof(T));

            if (result != null)
                if (result.Length > 0)
                    return result.Select(x => x.MonoCast<T>()).ToArray();

            return new T[0];
        }

        public static Object FindObjectOfType(Type type)
        {
            var result = FindObjectsOfType(type);
            if (result != null)
                if (result.Length > 0)
                    return result[0];

            return null;
        }
        public static Object[] FindObjectsOfType(Type type)
        {
            IntPtr typeObject = type.IL2Typeof();
            if (typeObject == IntPtr.Zero)
                return null;

            return Instance_Class.GetMethod(nameof(FindObjectsOfType), x => x.GetParameters().Length == 1).Invoke(new IntPtr[] { typeObject }).UnboxArray<Object>();
        }

        public void Destroy() => Destroy(this, 0f);
        public void Destroy(float time) => Destroy(this, time);
        public static void Destroy(Object obj) => Destroy(obj, 0f);
        unsafe public static void Destroy(Object obj, float time)
        {
            if (obj == null || time < 0)
                return;

            Instance_Class.GetMethod(nameof(Destroy), m => m.GetParameters().Length == 2).Invoke(new IntPtr[] { obj.ptr, new IntPtr(&time) });
        }

        unsafe public static Object FindObjectFromInstanceID(int instanceID)
        {
            return Instance_Class.GetMethod(nameof(FindObjectFromInstanceID)).Invoke(new IntPtr[] { new IntPtr(&instanceID) })?.GetValue<Object>();
        }

        public static void DontDestroyOnLoad(Object target)
        {
            Instance_Class.GetMethod(nameof(DontDestroyOnLoad)).Invoke(new IntPtr[] { target.ptr });
        }
        unsafe public HideFlags hideFlags
        {
            get => Instance_Class.GetProperty(nameof(hideFlags)).GetGetMethod().Invoke(ptr).GetValuå<HideFlags>();
            set => Instance_Class.GetProperty(nameof(hideFlags)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }
        public string name
        {
            get => Instance_Class.GetProperty(nameof(name)).GetGetMethod().Invoke(ptr)?.GetValue<string>();
            set => Instance_Class.GetProperty(nameof(name)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }

        public new string ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.GetValue<string>();
        }

        public static IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Object", "UnityEngine");
    }
}
