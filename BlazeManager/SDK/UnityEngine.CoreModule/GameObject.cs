using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
    public sealed class GameObject : Object
    {
        public GameObject(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public Component AddComponent(Type type)
        {
            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            return Instance_Class.GetMethod(nameof(AddComponent), m => m.GetParameters().Length == 1).Invoke(ptr, new IntPtr[] { typeObject.ptr })?.unbox<Component>();
        }

        public T AddComponent<T>() where T : Component => AddComponent(typeof(T))?.MonoCast<T>();

        public static GameObject CreatePrimitive(PrimitiveType type)
        {
            return Instance_Class.GetMethod(nameof(CreatePrimitive)).Invoke(new IntPtr[] { type.MonoCast() })?.unbox<GameObject>();
        }

        public T GetOrAddComponent<T>() where T : Component
        {
            Component component = GetComponent(typeof(T));
            if (component == null)
                component = AddComponent(typeof(T));
            return component?.MonoCast<T>();
        }
        public T GetComponent<T>() where T : Component => GetComponent(typeof(T))?.MonoCast<T>();
        public Component GetComponent(Type type)
        {
            Component[] components = GetComponents(type);

            if (components != null)
                if (components.Length > 0)
                    return components[0];

            return null;
        }

        private static IL2Method methodGetComponentByName = null;
        public Component GetComponent(string type)
        {
            if (!IL2Get.Method("GetComponentByName", Instance_Class, ref methodGetComponentByName))
                return null;

            return methodGetComponentByName.Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(type) })?.Unbox<Component>();
        }

        public T GetComponentInChildren<T>() => GetComponentInChildren(typeof(T)).MonoCast<T>();
        public T GetComponentInChildren<T>(bool includeInactive) => GetComponentInChildren(typeof(T), includeInactive).MonoCast<T>();
        public Component GetComponentInChildren(Type type) => GetComponentInChildren(type, false);
        public Component GetComponentInChildren(Type type, bool includeInactive)
        {
            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            return Instance_Class.GetMethod(nameof(GetComponentInChildren), x => x.GetParameters().Length == 2).Invoke(ptr, new IntPtr[] { typeObject.ptr, includeInactive.MonoCast() })?.MonoCast<Component>();
        }

        public T[] GetComponents<T>()
        {
            Component[] components = GetComponents(typeof(T));
            if (components == null || components.Length < 1)
                return new T[0];

            T[] ts = new T[components.Length];
            for (int i = 0; i < components.Length; i++)
            {
                ts[i] = components[i].MonoCast<T>();
            }
            return ts;
        }
        public Component[] GetComponents(Type type)
        {
            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            IL2Object result = Instance_Class.GetMethod(nameof(GetComponents), x => x.GetParameters().Length == 1 && x.ReturnType.Name.EndsWith("[]")).Invoke(ptr, new IntPtr[] { typeObject.ptr });
            if (result != null)
                return result.UnboxArray<Component>();

            return new Component[0];
        }

        public T[] GetComponentsInChildren<T>() => GetComponentsInChildren<T>(false);
        public T[] GetComponentsInChildren<T>(bool includeInactive)
        {
            Component[] components = GetComponentsInChildren(typeof(T), includeInactive);
            if (components == null || components.Length < 1)
                return new T[0];

            T[] ts = new T[components.Length];
            for (int i = 0; i < components.Length; i++)
            {
                ts[i] = components[i].MonoCast<T>();
            }
            return ts;
        }
        public Component[] GetComponentsInChildren(Type type) => GetComponentsInChildren(type, false);
        public Component[] GetComponentsInChildren(Type type, bool includeInactive)
        {
            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            IL2Object result = Instance_Class.GetMethod(nameof(GetComponentsInChildren), x => x.GetParameters().Length == 2 && x.ReturnType.Name.EndsWith("[]")).Invoke(ptr, new IntPtr[] { typeObject.ptr, includeInactive.MonoCast() });
            if (result != null)
                return result.UnboxArray<Component>();

            return new Component[0];
        }

        public static GameObject FindWithTag(string tag)
        {
            return Instance_Class.GetMethod(nameof(FindWithTag)).Invoke(new IntPtr[] { new IL2String(tag).ptr })?.unbox<GameObject>();
        }
        

        public static GameObject Find(string name)
        {
            return Instance_Class.GetMethod(nameof(Find)).Invoke(new IntPtr[] { new IL2String(name).ptr })?.unbox<GameObject>();
        }

        public Transform transform
        {
            get => Instance_Class.GetProperty(nameof(transform)).GetGetMethod().Invoke(ptr)?.unbox<Transform>();
        }

        public int layer
        {
            get => Instance_Class.GetProperty(nameof(layer)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<int>();
            set => Instance_Class.GetProperty(nameof(layer)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public bool active
        {
            get => Instance_Class.GetProperty(nameof(active)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
            set => Instance_Class.GetProperty(nameof(active)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public void SetActive(bool value)
        {
            Instance_Class.GetMethod(nameof(SetActive)).Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public bool activeSelf
        {
            get => Instance_Class.GetProperty(nameof(activeSelf)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        public bool activeInHierarchy
        {
            get => Instance_Class.GetProperty(nameof(activeInHierarchy)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        public void SetActiveRecursively(bool value)
        {
            Instance_Class.GetMethod(nameof(SetActiveRecursively)).Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public bool isStatic
        {
            get => Instance_Class.GetProperty(nameof(isStatic)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
            set => Instance_Class.GetProperty(nameof(isStatic)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public string tag
        {
            get => Instance_Class.GetProperty(nameof(tag)).GetGetMethod().Invoke(ptr)?.unbox_ToString().ToString();
            set => Instance_Class.GetProperty(nameof(tag)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }

        public GameObject gameObject
        {
            get => Instance_Class.GetProperty(nameof(gameObject)).GetGetMethod().Invoke(ptr)?.unbox<GameObject>();
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("GameObject", "UnityEngine");
    }
}
