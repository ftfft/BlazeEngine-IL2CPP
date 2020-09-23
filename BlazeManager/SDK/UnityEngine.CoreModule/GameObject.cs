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

        private static IL2Method methodAddComponent = null;
        public Component AddComponent(Type type)
        {
            if (methodAddComponent == null)
            {
                methodAddComponent = Instance_Class.GetMethod("AddComponent", m => m.GetParameters().Length == 1);
                if (methodAddComponent == null)
                    return null;
            }

            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            return methodAddComponent.Invoke(ptr, new IntPtr[] { typeObject.ptr })?.MonoCast<Component>();
        }

        public T AddComponent<T>() where T : Component => AddComponent(typeof(T))?.MonoCast<T>();

        private static IL2Method methodCreatePremetive = null;
        public static GameObject CreatePrimitive(PrimitiveType type)
        {
            if (!IL2Get.Method("CreatePrimitive", Instance_Class, ref methodCreatePremetive))
                return null;

            return methodCreatePremetive.Invoke(new IntPtr[] { type.MonoCast() })?.MonoCast<GameObject>();
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

        private static IL2Method methodGetComponentInChildren = null;
        public T GetComponentInChildren<T>() => GetComponentInChildren(typeof(T)).MonoCast<T>();
        public T GetComponentInChildren<T>(bool includeInactive) => GetComponentInChildren(typeof(T), includeInactive).MonoCast<T>();
        public Component GetComponentInChildren(Type type) => GetComponentInChildren(type, false);
        public Component GetComponentInChildren(Type type, bool includeInactive)
        {
            if (methodGetComponentInChildren == null)
            {
                methodGetComponentInChildren = Instance_Class.GetMethod("GetComponentInChildren", x => x.GetParameters().Length == 2);
                if (methodGetComponentInChildren == null)
                    return null;
            }

            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            return methodGetComponentInChildren.Invoke(ptr, new IntPtr[] { typeObject.ptr, includeInactive.MonoCast() })?.MonoCast<Component>();
        }

        private static IL2Method methodGetComponentsByType = null;
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
            if (methodGetComponentsByType == null)
            {
                methodGetComponentsByType = Instance_Class.GetMethods(x => x.Name == "GetComponents")
                    .First(x => x.GetParameters().Length == 1 && x.ReturnType.Name.EndsWith("[]"));
                if (methodGetComponentsByType == null)
                    return null;
            }

            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            IL2Object result = methodGetComponentsByType.Invoke(ptr, new IntPtr[] { typeObject.ptr });
            if (result != null)
                return result.UnboxArray<Component>();

            return new Component[0];
        }

        private static IL2Method methodGetComponentsInChildren = null;
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
            if (methodGetComponentsInChildren == null)
            {
                methodGetComponentsInChildren = Instance_Class.GetMethods()
                    .Where(x => x.Name == "GetComponentsInChildren")
                    .Where(x => x.GetParameters().Length == 2)
                    .First(x => x.ReturnType.Name.EndsWith("[]"));
                if (methodGetComponentsInChildren == null)
                    return null;
            }

            IL2TypeObject typeObject = IL2GetType.IL2Typeof(type);
            if (typeObject == null)
                return null;

            IL2Object result = methodGetComponentsInChildren.Invoke(ptr, new IntPtr[] { typeObject.ptr, includeInactive.MonoCast() });
            if (result != null)
                return result.UnboxArray<Component>();

            return new Component[0];
        }

        private static IL2Method methodFindWithTag = null;
        public static GameObject FindWithTag(string tag)
        {
            if (!IL2Get.Method("FindWithTag", Instance_Class, ref methodFindWithTag))
                return null;

            return methodFindWithTag.Invoke(new IntPtr[] { IL2Import.StringToIntPtr(tag) })?.MonoCast<GameObject>();
        }
        

        private static IL2Method methodFind = null;
        public static GameObject Find(string name)
        {
            if (!IL2Get.Method("Find", Instance_Class, ref methodFind))
                return null;

            return methodFind.Invoke(new IntPtr[] { IL2Import.StringToIntPtr(name) })?.MonoCast<GameObject>();
        }

        private static IL2Property propertyTransform = null;
        public Transform transform
        {
            get
            {
                if (!IL2Get.Property("transform", Instance_Class, ref propertyTransform))
                    return null;

                return propertyTransform.GetGetMethod().Invoke(ptr)?.Unbox<Transform>();
            }
        }

        private static IL2Property propertyLayer = null;
        public int layer
        {
            get
            {
                if (!IL2Get.Property("layer", Instance_Class, ref propertyLayer))
                    return default;

                return propertyLayer.GetGetMethod().Invoke(ptr).Unbox<int>();
            }
            set
            {
                if (!IL2Get.Property("layer", Instance_Class, ref propertyLayer))
                    return;

                propertyLayer.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Property propertyActive = null;
        public bool active
        {
            get
            {
                if (!IL2Get.Property("active", Instance_Class, ref propertyActive))
                    return default;

                return propertyActive.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
            set
            {
                if (!IL2Get.Property("active", Instance_Class, ref propertyActive))
                    return;

                propertyActive.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Method methodSetActive = null;
        public void SetActive(bool value)
        {
            if (!IL2Get.Method("SetActive", Instance_Class, ref methodSetActive))
                return;

            methodSetActive.Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        private static IL2Property propertyActiveSelf = null;
        public bool activeSelf
        {
            get
            {
                if (!IL2Get.Property("activeSelf", Instance_Class, ref propertyActiveSelf))
                    return default;

                return propertyActiveSelf.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        private static IL2Property propertyActiveInHierarchy = null;
        public bool activeInHierarchy
        {
            get
            {
                if (!IL2Get.Property("activeInHierarchy", Instance_Class, ref propertyActiveInHierarchy))
                    return default;

                return propertyActiveInHierarchy.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
        }

        private static IL2Method methodSetActiveRecursively = null;
        public void SetActiveRecursively(bool value)
        {
            if (!IL2Get.Method("SetActiveRecursively", Instance_Class, ref methodSetActiveRecursively))
                return;

            methodSetActiveRecursively.Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        private static IL2Property propertyIsStatic = null;
        public bool isStatic
        {
            get
            {
                if (!IL2Get.Property("isStatic", Instance_Class, ref propertyIsStatic))
                    return default;

                return propertyIsStatic.GetGetMethod().Invoke(ptr).Unbox<bool>();
            }
            set
            {
                if (!IL2Get.Property("isStatic", Instance_Class, ref propertyIsStatic))
                    return;

                propertyIsStatic.GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
            }
        }

        private static IL2Property propertyTag = null;
        public string tag
        {
            get
            {
                if (!IL2Get.Property("tag", Instance_Class, ref propertyTag))
                    return null;

                return propertyTag.GetGetMethod().Invoke(ptr)?.Unbox<string>();
            }
            set
            {
                if (!IL2Get.Property("tag", Instance_Class, ref propertyTag))
                    return;

                propertyTag.GetSetMethod().Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(value) });
            }
        }

        private static IL2Property propertyGameObject = null;
        public GameObject gameObject
        {
            get
            {
                if (!IL2Get.Property("gameObject", Instance_Class, ref propertyGameObject))
                    return null;

                return propertyGameObject.GetGetMethod().Invoke(ptr)?.MonoCast<GameObject>();
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("GameObject", "UnityEngine");
    }
}
