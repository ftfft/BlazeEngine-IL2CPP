using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public unsafe sealed class GameObject : Object
    {
        public GameObject(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Method methodCreatePremetive = null;
        public static GameObject CreatePrimitive(PrimitiveType type)
        {
            if (methodCreatePremetive == null)
            {
                methodCreatePremetive = Instance_Class.GetMethod("CreatePrimitive");
                if (methodCreatePremetive == null)
                    return null;
            }

            IL2Object result = null;
            result = methodCreatePremetive.Invoke(new IntPtr[] { new IntPtr(&type) });
            if (result == null)
                return null;

            return result.ptr.MonoCast<GameObject>();
        }

        public T GetComponent<T>() => GetComponent(typeof(T)).ptr.MonoCast<T>();
        public Component GetComponent(Type type)
        {
            Component[] result = null;
            result = GetComponents(type);
            if (result == null)
                return null;

            return result[0];
        }

        private static IL2Method methodGetComponentByName = null;
        public Component GetComponent(string type)
        {
            if (methodGetComponentByName == null)
            {
                methodGetComponentByName = Instance_Class.GetMethod("GetComponentByName");
                if (methodGetComponentByName == null)
                    return null;
            }

            IL2Object result = null;
            result = methodGetComponentByName.Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(type) });
            if (result == null)
                return null;

            return result.ptr.MonoCast<Component>();
        }

        private static IL2Method methodGetComponentInChildren = null;
        public T GetComponentInChildren<T>() => GetComponentInChildren(typeof(T)).ptr.MonoCast<T>();
        public T GetComponentInChildren<T>(bool includeInactive) => GetComponentInChildren(typeof(T), includeInactive).ptr.MonoCast<T>();
        public Component GetComponentInChildren(Type type) => GetComponentInChildren(type, false);
        public Component GetComponentInChildren(Type type, bool includeInactive)
        {
            if (methodGetComponentInChildren == null)
            {
                methodGetComponentInChildren = Instance_Class.GetMethod("GetComponentInChildren", x => x.GetParameters().Length == 2);
                if (methodGetComponentInChildren == null)
                    return null;
            }

            IntPtr IntPtrType = Execute.find_typeof_to_type(type);
            if (IntPtrType == IntPtr.Zero)
                return null;

            IL2Object result = null;
            result = methodGetComponentInChildren.Invoke(ptr, new IntPtr[] { IntPtrType, new IntPtr(&includeInactive) });
            if (result == null)
                return null;

            return result.ptr.MonoCast<Component>();
        }

        private static IL2Method methodGetComponentsByType = null;
        public T[] GetComponents<T>()
        {
            Component[] components = GetComponents(typeof(T));

            T[] result = new T[components.Length];
            for (int i = 0; i < components.Length; i++)
                result[i] = components[i].ptr.MonoCast<T>();

            return result;
        }
        public Component[] GetComponents(Type type)
        {
            if (methodGetComponentsByType == null)
            {
                methodGetComponentsByType = Instance_Class.GetMethods()
                    .Where(x => x.Name == "GetComponents" && x.GetParameters().Length == 1)
                    .First(x => IL2Import.il2cpp_type_get_name(x.GetReturnType().ptr) == "UnityEngine.Component[]");
                if (methodGetComponentsByType == null)
                    return null;
            }

            IntPtr IntPtrType = Execute.find_typeof_to_type(type);
            if (IntPtrType == IntPtr.Zero)
                return null;

            IL2Object obj = null;
            obj = methodGetComponentsByType.Invoke(ptr, new IntPtr[] { IntPtrType });
            if (obj == null)
                return null;

            IntPtr[] ptrs = obj.ptr.IntPtrToArray();
            Component[] result = new Component[ptrs.Length];
            for (int i = 0; i < ptrs.Length; i++)
                result[i] = ptrs[i].MonoCast<Component>();

            return result;
        }

        private static IL2Method methodGetComponentsInChildren = null;
        public T[] GetComponentsInChildren<T>() => GetComponentsInChildren<T>(false);
        public T[] GetComponentsInChildren<T>(bool includeInactive)
        {
            Component[] components = GetComponentsInChildren(typeof(T), includeInactive);
            T[] result = new T[components.Length];
            for (int i = 0; i<components.Length; i++)
                result[i] = components[i].ptr.MonoCast<T>();

            return result;
        }
        public Component[] GetComponentsInChildren(Type type) => GetComponentsInChildren(type, false);
        public Component[] GetComponentsInChildren(Type type, bool includeInactive)
        {
            if (methodGetComponentsInChildren == null)
            {
                methodGetComponentsInChildren = Instance_Class.GetMethods()
                    .Where(x => x.Name == "GetComponentsInChildren")
                    .Where(x => x.GetParameters().Length == 2)
                    .First(x => x.GetReturnType().Name == "UnityEngine.Component[]");
                if (methodGetComponentsInChildren == null)
                    return null;
            }
            if (ptr == IntPtr.Zero)
                return null;

            IntPtr IntPtrType = Execute.find_typeof_to_type(type);
            if (IntPtrType == IntPtr.Zero)
                return null;

            var result = methodGetComponentsInChildren.Invoke(ptr, new IntPtr[] { IntPtrType, new IntPtr(&includeInactive) });
            if (result == null)
                return null;

            IntPtr[] ptrs = result.ptr.IntPtrToArray();
            Component[] components = new Component[ptrs.Length];
            for (int i = 0; i < ptrs.Length; i++)
                components[i] = ptrs[i].MonoCast<Component>();

            return components;
        }

        private static IL2Method methodFindWithTag = null;
        public static GameObject FindWithTag(string tag)
        {
            if (methodFindWithTag == null)
            {
                methodFindWithTag = Instance_Class.GetMethod("FindWithTag");
                if (methodFindWithTag == null)
                    return null;
            }

            IL2Object result = null;
            result = methodFindWithTag.Invoke(new IntPtr[] { IL2Import.StringToIntPtr(tag) });
            if (result == null)
                return null;

            return result.ptr.MonoCast<GameObject>();
        }

        private static IL2Property propertyTransform = null;
        public Transform transform
        {
            get
            {
                if (propertyTransform == null)
                {
                    propertyTransform = Instance_Class.GetProperty("transform");
                    if (propertyTransform == null)
                        return null;
                }

                IL2Object result = null;
                result = propertyTransform.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return null;

                return result.ptr.MonoCast<Transform>();
            }
        }

        private static IL2Property propertyLayer = null;
        public int layer
        {
            get
            {
                if (propertyLayer == null)
                {
                    propertyLayer = Instance_Class.GetProperty("layer");
                    if (propertyLayer == null)
                        return -1;
                }

                IL2Object result = null;
                result = propertyLayer.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return -1;

                return *(int*)result.Unbox();
            }
            set
            {
                if (propertyLayer == null)
                {
                    propertyLayer = Instance_Class.GetProperty("layer");
                    if (propertyLayer == null)
                        return;
                }

                propertyLayer.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
            }
        }

        private static IL2Property propertyActive = null;
        public bool active
        {
            get
            {
                if (propertyActive == null)
                {
                    propertyActive = Instance_Class.GetProperty("active");
                    if (propertyActive == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyActive.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(bool*)result.Unbox();
            }
            set
            {
                if (propertyActive == null)
                {
                    propertyActive = Instance_Class.GetProperty("active");
                    if (propertyActive == null)
                        return;
                }

                propertyActive.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
            }
        }

        private static IL2Method methodSetActive = null;
        public void SetActive(bool value)
        {
            if (methodSetActive == null)
            {
                methodSetActive = Instance_Class.GetMethod("SetActive");
                if (methodSetActive == null)
                    return;
            }

            methodSetActive.Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }

        private static IL2Property propertyActiveSelf = null;
        public bool activeSelf
        {
            get
            {
                if (propertyActiveSelf == null)
                {
                    propertyActiveSelf = Instance_Class.GetProperty("activeSelf");
                    if (propertyActiveSelf == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyActiveSelf.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;
                
                return *(bool*)result.Unbox();
            }
        }

        private static IL2Property propertyActiveInHierarchy = null;
        public bool activeInHierarchy
        {
            get
            {
                if (propertyActiveInHierarchy == null)
                {
                    propertyActiveInHierarchy = Instance_Class.GetProperty("activeInHierarchy");
                    if (propertyActiveInHierarchy == null)
                        return default;
                }

                IL2Object result = propertyActiveInHierarchy.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(bool*)result.Unbox();
            }
        }

        private static IL2Method methodSetActiveRecursively = null;
        public void SetActiveRecursively(bool value)
        {
            if (methodSetActiveRecursively == null)
            {
                methodSetActiveRecursively = Instance_Class.GetMethod("SetActiveRecursively");
                if (methodSetActiveRecursively == null)
                    return;
            }

            methodSetActiveRecursively.Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }

        private static IL2Property propertyIsStatic = null;
        public bool isStatic
        {
            get
            {
                if (propertyIsStatic == null)
                {
                    propertyIsStatic = Instance_Class.GetProperty("isStatic");
                    if (propertyIsStatic == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyIsStatic.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(bool*)result.Unbox();
            }
            set
            {
                if (propertyIsStatic == null)
                {
                    propertyIsStatic = Instance_Class.GetProperty("isStatic");
                    if (propertyIsStatic == null)
                        return;
                }

                propertyIsStatic.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
            }
        }

        private static IL2Property propertyTag = null;
        public string tag
        {
            get
            {
                if (propertyTag == null)
                {
                    propertyTag = Instance_Class.GetProperty("tag");
                    if (propertyTag == null)
                        return null;
                }

                IL2Object result = null;
                result = propertyTag.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return null;

                return result.UnboxString();
            }
            set
            {
                if (propertyTag == null)
                {
                    propertyTag = Instance_Class.GetProperty("tag");
                    if (propertyTag == null)
                        return;
                }

                propertyTag.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }

        public GameObject gameObject
        {
            get => this;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(GameObject))
                return false;
            return ((GameObject)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("GameObject", "UnityEngine");
    }
}
