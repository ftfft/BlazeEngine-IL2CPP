using System;
using System.Collections;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    unsafe public class Transform : Component, IEnumerable
    {
        public Transform(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyForward = null;
        public Vector3 forward
        {
            get
            {
                if (propertyForward == null)
                {
                    propertyForward = Instance_Class.GetProperty("forward");
                    if (propertyForward == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyForward.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(Vector3*)result.Unbox();
            }
        }

        private static IL2Property propertyRight = null;
        public Vector3 right
        {
            get
            {
                if (propertyRight == null)
                {
                    propertyRight = Instance_Class.GetProperty("right");
                    if (propertyRight == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyRight.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(Vector3*)result.Unbox();
            }
        }

        private static IL2Property propertyPosition = null;
        public Vector3 position
        {
            get
            {
                if (propertyPosition == null)
                {
                    propertyPosition = Instance_Class.GetProperty("position");
                    if (propertyPosition == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyPosition.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(Vector3*)result.Unbox();
            }
            set
            {
                if (propertyPosition == null)
                {
                    propertyPosition = Instance_Class.GetProperty("position");
                    if (propertyPosition == null)
                        return;
                }

                propertyPosition.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
            }
        }

        private static IL2Property propertyLocalPosition = null;
        public Vector3 localPosition
        {
            get
            {
                if (propertyLocalPosition == null)
                {
                    propertyLocalPosition = Instance_Class.GetProperty("localPosition");
                    if (propertyLocalPosition == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyLocalPosition.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;
                
                return *(Vector3*)result.Unbox();
            }
            set
            {
                if (propertyLocalPosition == null)
                {
                    propertyLocalPosition = Instance_Class.GetProperty("localPosition");
                    if (propertyLocalPosition == null)
                        return;
                }

                propertyLocalPosition.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
            }
        }

        private static IL2Property propertyRotation = null;
        public Quaternion rotation
        {
            get
            {
                if (propertyRotation == null)
                {
                    propertyRotation = Instance_Class.GetProperty("rotation");
                    if (propertyRotation == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyRotation.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(Quaternion*)result.Unbox();
            }
            set
            {
                if (propertyRotation == null)
                {
                    propertyRotation = Instance_Class.GetProperty("rotation");
                    if (propertyRotation == null)
                        return;
                }

                propertyRotation.GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
            }
        }

        private static IL2Method methodFind = null;
        public Transform Find(string name)
        {
            if (methodFind == null)
            {
                methodFind = Instance_Class.GetMethod("Find");
                if (methodFind == null)
                    return null;
            }

            IL2Object result = null;
            result = methodFind.Invoke(ptr, new IntPtr[] { IL2Import.StringToIntPtr(name) });
            if (result == null)
                return null;

            return result.ptr.MonoCast<Transform>();
        }

        private static IL2Property propertyChildCount = null;
        public int childCount
        {
            get
            {
                if (propertyChildCount == null)
                {
                    propertyChildCount = Instance_Class.GetProperty("childCount");
                    if (propertyChildCount == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyChildCount.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return default;

                return *(int*)result.Unbox();
            }
        }

        private static IL2Property propertyParent = null;
        public Transform parent
        {
            get
            {
                if (propertyParent == null)
                {
                    propertyParent = Instance_Class.GetProperty("parent");
                    if (propertyParent == null)
                        return null;
                }

                IL2Object result = null;
                result = propertyParent.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return null;

                return result.ptr.MonoCast<Transform>();
            }
            set
            {
                if (propertyParent == null)
                {
                    propertyParent = Instance_Class.GetProperty("parent");
                    if (propertyParent == null)
                        return;
                }

                propertyParent.GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
            }
        }

        private static IL2Method methodGetChild = null;
        public Transform GetChild(int index)
        {
            if (methodGetChild == null)
            {
                methodGetChild = Instance_Class.GetMethod("GetChild");
                if (methodGetChild == null)
                    return null;
            }

            IL2Object result = null;
            result = methodGetChild.Invoke(ptr, new IntPtr[] { new IntPtr(&index) });
            if (result == null)
                return null;

            return result.ptr.MonoCast<Transform>();
        }

        private static IL2Method methodSetSiblingIndex = null;
        public void SetSiblingIndex(int index)
        {
            if (methodSetSiblingIndex == null)
            {
                methodSetSiblingIndex = Instance_Class.GetMethod("SetSiblingIndex");
                if (methodSetSiblingIndex == null)
                    return;
            }

            methodSetSiblingIndex.Invoke(ptr, new IntPtr[] { new IntPtr(&index) });
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

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Transform))
                return false;
            return ((Transform)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["UnityEngine.CoreModule"].GetClass("Transform", "UnityEngine");
    }
}
