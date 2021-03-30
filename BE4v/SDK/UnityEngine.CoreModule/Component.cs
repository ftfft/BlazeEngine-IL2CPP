using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;


namespace UnityEngine
{
    public class Component : Object
    {
        public Component(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public Transform transform
        {
            get => Instance_Class.GetProperty(nameof(transform)).GetGetMethod().Invoke(ptr)?.GetValue<Transform>();
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

        public GameObject gameObject
        {
            get => Instance_Class.GetProperty(nameof(gameObject)).GetGetMethod().Invoke(ptr)?.GetValue<GameObject>();
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Component", "UnityEngine");
    }
}
