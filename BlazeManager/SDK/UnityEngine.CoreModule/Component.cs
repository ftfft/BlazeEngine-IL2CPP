using System;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

namespace UnityEngine
{
    public class Component : Object
    {
        public Component(IntPtr ptr) : base(ptr) => base.ptr = ptr;

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

        public T GetComponentInChildren<T>() => GetComponentInChildren(typeof(T)).MonoCast<T>();
        public T GetComponentInChildren<T>(bool includeInactive) => GetComponentInChildren(typeof(T), includeInactive).MonoCast<T>();
        public T[] GetComponentsInChildren<T>() => gameObject.GetComponentsInChildren<T>();
        public T[] GetComponentsInChildren<T>(bool includeInactive) => gameObject.GetComponentsInChildren<T>(includeInactive);
        public Component GetComponentInChildren(Type type) => GetComponentInChildren(type, false);
        public Component GetComponentInChildren(Type type, bool includeInactive) => gameObject.GetComponentInChildren(type, includeInactive);
        public Component[] GetComponentsInChildren(Type type) => gameObject.GetComponentsInChildren(type);
        public Component[] GetComponentsInChildren(Type type, bool includeInactive) => gameObject.GetComponentsInChildren(type, includeInactive);
        public T GetComponent<T>() where T : Component => gameObject.GetComponent<T>();
        public T[] GetComponents<T>() => gameObject.GetComponents<T>();
        public Component GetComponent(Type type) => gameObject.GetComponent(type);
        public Component GetComponent(string type) => gameObject.GetComponent(type);
        public Component[] GetComponents(Type type) => gameObject.GetComponents(type);

        public string tag
        {
            get => gameObject.tag;
            set => gameObject.tag = value;
        }

        private static IL2Property propertyGameObject = null;
        public GameObject gameObject
        {
            get
            {
                if (!IL2Get.Property("gameObject", Instance_Class, ref propertyGameObject))
                    return null;

                return propertyGameObject.GetGetMethod().Invoke(ptr)?.Unbox<GameObject>();
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Component", "UnityEngine");
    }
}
