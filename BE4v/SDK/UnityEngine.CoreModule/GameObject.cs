using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using System;
using System.Linq;

namespace UnityEngine
{
    public sealed class GameObject : Object
    {
        public GameObject(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public GameObject(string name) : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor", x => x.GetParameters().Length == 1).Invoke(ptr, new IntPtr[] { new IL2String(name).ptr });
        }

        public Component AddComponent(Type type)
        {
            IntPtr typeObject = type.IL2Typeof();
            if (typeObject == IntPtr.Zero)
                return null;

            return Instance_Class.GetMethod(nameof(AddComponent), m => m.GetParameters().Length == 1).Invoke(ptr, new IntPtr[] { typeObject })?.GetValue<Component>();
        }
        public T AddComponent<T>() where T : Component => AddComponent(typeof(T))?.MonoCast<T>();

        unsafe public static GameObject CreatePrimitive(PrimitiveType type)
        {
            return Instance_Class.GetMethod(nameof(CreatePrimitive)).Invoke(new IntPtr[] { new IntPtr(&type) })?.GetValue<GameObject>();
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

        public Component GetComponent(string type)
        {
            return Instance_Class.GetMethod("GetComponentByName").Invoke(ptr, new IntPtr[] { new IL2String(type).ptr })?.GetValue<Component>();
        }

        public T GetComponentInChildren<T>() => GetComponentInChildren(typeof(T)).MonoCast<T>();
        public T GetComponentInChildren<T>(bool includeInactive) => GetComponentInChildren(typeof(T), includeInactive).MonoCast<T>();
        public Component GetComponentInChildren(Type type) => GetComponentInChildren(type, false);
        unsafe public Component GetComponentInChildren(Type type, bool includeInactive)
        {
            IntPtr typeObject = type.IL2Typeof();
            if (typeObject == IntPtr.Zero)
                return null;

            return Instance_Class.GetMethod(nameof(GetComponentInChildren), x => x.GetParameters().Length == 2).Invoke(ptr, new IntPtr[] { typeObject, new IntPtr(&includeInactive) })?.MonoCast<Component>();
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
            IntPtr typeObject = type.IL2Typeof();
            if (typeObject == IntPtr.Zero)
                return null;

            IL2Object result = Instance_Class.GetMethod(nameof(GetComponents), x => x.GetParameters().Length == 1 && x.ReturnType.Name.EndsWith("[]")).Invoke(ptr, new IntPtr[] { typeObject });
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
        unsafe public Component[] GetComponentsInChildren(Type type, bool includeInactive)
        {
            IntPtr typeObject = type.IL2Typeof();
            if (typeObject == IntPtr.Zero)
                return null;

            IL2Object result = Instance_Class.GetMethod(nameof(GetComponentsInChildren), x => x.GetParameters().Length == 2 && x.ReturnType.Name.EndsWith("[]")).Invoke(ptr, new IntPtr[] { typeObject, new IntPtr(&includeInactive) });
            if (result != null)
                return result.UnboxArray<Component>();

            return new Component[0];
        }

        public static GameObject FindWithTag(string tag)
        {
            return Instance_Class.GetMethod(nameof(FindWithTag)).Invoke(new IntPtr[] { new IL2String(tag).ptr })?.GetValue<GameObject>();
        }
        

        public static GameObject Find(string name)
        {
            return Instance_Class.GetMethod(nameof(Find)).Invoke(new IntPtr[] { new IL2String(name).ptr })?.GetValue<GameObject>();
        }

        public Transform transform
        {
            get => Instance_Class.GetProperty(nameof(transform)).GetGetMethod().Invoke(ptr)?.GetValue<Transform>();
        }

        unsafe public int layer
        {
            get => Instance_Class.GetProperty(nameof(layer)).GetGetMethod().Invoke(ptr).GetValuå<int>();
            set => Instance_Class.GetProperty(nameof(layer)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public bool active
        {
            get => Instance_Class.GetProperty(nameof(active)).GetGetMethod().Invoke(ptr).GetValuå<bool>();
            set => Instance_Class.GetProperty(nameof(active)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public void SetActive(bool value)
        {
            IntPtr ptrValue = new IntPtr(&value);
            Instance_Class.GetMethod(nameof(SetActive)).Invoke(ptr, new IntPtr[] { ptrValue });
        }

        public bool activeSelf
        {
            get => Instance_Class.GetProperty(nameof(activeSelf)).GetGetMethod().Invoke(ptr).GetValuå<bool>();
        }

        public bool activeInHierarchy
        {
            get => Instance_Class.GetProperty(nameof(activeInHierarchy)).GetGetMethod().Invoke(ptr).GetValuå<bool>();
        }

        unsafe public void SetActiveRecursively(bool value)
        {
            Instance_Class.GetMethod(nameof(SetActiveRecursively)).Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }

        unsafe public bool isStatic
        {
            get => Instance_Class.GetProperty(nameof(isStatic)).GetGetMethod().Invoke(ptr).GetValuå<bool>();
            set => Instance_Class.GetProperty(nameof(isStatic)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }

        public string tag
        {
            get => Instance_Class.GetProperty(nameof(tag)).GetGetMethod().Invoke(ptr)?.GetValue<string>();
            set => Instance_Class.GetProperty(nameof(tag)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }

        public GameObject gameObject
        {
            get => Instance_Class.GetProperty(nameof(gameObject)).GetGetMethod().Invoke(ptr)?.GetValue<GameObject>();
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("GameObject", "UnityEngine");
    }
}
