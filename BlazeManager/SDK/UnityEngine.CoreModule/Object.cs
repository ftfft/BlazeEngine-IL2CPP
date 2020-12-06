using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

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
        public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace)
        {
            return Instance_Class.GetMethod(nameof(Instantiate),
                x => x.GetParameters().Length == 3
                && x.GetParameters()[2].ReturnType.Name == typeof(bool).FullName
                && x.ReturnType.Name == Instance_Class.FullName).Invoke(new IntPtr[] { original.ptr, parent.ptr, instantiateInWorldSpace.MonoCast() })?.MonoCast<Object>();
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
            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            return Instance_Class.GetMethod(nameof(FindObjectsOfType), x => x.GetParameters().Length == 1).Invoke(new IntPtr[] { typeObject.ptr }).unbox_ToArray<Object>();
        }

        public void Destroy() => Destroy(this, 0f);
        public void Destroy(float time) => Destroy(this, time);
        public static void Destroy(Object obj) => Destroy(obj, 0f);
        public static void Destroy(Object obj, float time)
        {
            if (obj == null || time < 0)
                return;

            Instance_Class.GetMethod(nameof(Destroy), m => m.GetParameters().Length == 2).Invoke(new IntPtr[] { obj.ptr, time.MonoCast() });
        }

        public static Object FindObjectFromInstanceID(int instanceID) => FindObjectFromInstanceID(instanceID.MonoCast());
        public static Object FindObjectFromInstanceID(IntPtr instanceID)
        {
            return Instance_Class.GetMethod(nameof(FindObjectFromInstanceID)).Invoke(new IntPtr[] { instanceID })?.MonoCast<Object>();
        }

        public static void DontDestroyOnLoad(Object target)
        {
            Instance_Class.GetMethod(nameof(DontDestroyOnLoad)).Invoke(new IntPtr[] { target.ptr });
        }

        public string name
        {
            get => Instance_Class.GetProperty(nameof(name)).GetGetMethod().Invoke(ptr)?.unbox_ToString().ToString();
            set => Instance_Class.GetProperty(nameof(name)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }

        public new IL2String ToString()
        {
            return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.unbox_ToString();
        }

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Object", "UnityEngine");
    }
}
