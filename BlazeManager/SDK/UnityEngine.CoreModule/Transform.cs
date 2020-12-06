using System;
using System.Collections;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public class Transform : Component, IEnumerable
    {
        public Transform(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public Vector3 forward
        {
            get => Instance_Class.GetProperty(nameof(forward)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<Vector3>();
        }

        public Vector3 right
        {
            get => Instance_Class.GetProperty(nameof(right)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<Vector3>();
        }

        public Vector3 position
        {
            get => Instance_Class.GetProperty(nameof(position)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<Vector3>();
            set => Instance_Class.GetProperty(nameof(position)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public Vector3 localPosition
        {
            get => Instance_Class.GetProperty(nameof(localPosition)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<Vector3>();
            set => Instance_Class.GetProperty(nameof(localPosition)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public Vector3 localEulerAngles
        {
            get => Instance_Class.GetProperty(nameof(localEulerAngles)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<Vector3>();
            set => Instance_Class.GetProperty(nameof(localEulerAngles)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public Quaternion rotation
        {
            get => Instance_Class.GetProperty(nameof(rotation)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<Quaternion>();
            set => Instance_Class.GetProperty(nameof(rotation)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public Vector3 localScale
        {
            get => Instance_Class.GetProperty(nameof(localScale)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<Vector3>();
            set => Instance_Class.GetProperty(nameof(localScale)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public Transform Find(string name)
        {
            return Instance_Class.GetMethod(nameof(Find)).Invoke(ptr, new IntPtr[] { new IL2String(name).ptr })?.unbox<Transform>();
        }

        public void SetParent(Transform transform)
        {
            Instance_Class.GetMethod(nameof(SetParent), x => x.GetParameters().Length == 1).Invoke(ptr, new IntPtr[] { transform.ptr });
        }

        public int childCount
        {
            get => Instance_Class.GetProperty(nameof(childCount)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<int>();
        }

        public Transform parent
        {
            get => Instance_Class.GetProperty(nameof(parent)).GetGetMethod().Invoke(ptr)?.unbox<Transform>();
            set => Instance_Class.GetProperty(nameof(parent)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
        }

        public Transform GetChild(int index)
        {
            return Instance_Class.GetMethod(nameof(GetChild)).Invoke(ptr, new IntPtr[] { index.MonoCast() })?.unbox<Transform>();
        }

        public void SetSiblingIndex(int index)
        {
            Instance_Class.GetMethod(nameof(SetSiblingIndex)).Invoke(ptr, new IntPtr[] { index.MonoCast() });
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        private sealed class Enumerator : IEnumerator
        {
            internal Enumerator(Transform outer)
            {
                this.outer = outer;
            }

            public object Current
            {
                get
                {
                    return outer.GetChild(currentIndex);
                }
            }

            public bool MoveNext()
            {
                int childCount = outer.childCount;
                return ++currentIndex < childCount;
            }

            public void Reset()
            {
                currentIndex = -1;
            }

            private Transform outer;

            private int currentIndex = -1;
        }

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Transform", "UnityEngine");
    }
}
