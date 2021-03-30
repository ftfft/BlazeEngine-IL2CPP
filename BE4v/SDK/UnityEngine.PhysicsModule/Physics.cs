using System;
using System.Linq;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
    public static class Physics
    {
        public static Vector3 gravity
        {
            get => Instance_Class.GetProperty(nameof(gravity)).GetGetMethod().Invoke().GetValuе<Vector3>();
            set => Instance_Class.GetProperty(nameof(gravity)).GetSetMethod().Invoke(new IntPtr[] { value.MonoCast() });
        }

        private static IL2Method RayCastMini = null;
        public static bool Raycast(Ray ray, out RaycastHit hitInfo)
        {
            if(RayCastMini == null)
            {
                RayCastMini = Instance_Class.GetMethods()
                    .Where(x => x.Name == "Raycast" && x.GetParameters().Length == 2)
                    .First(x => x.GetParameters()[1].ReturnType.Name == "UnityEngine.RaycastHit&");

                if (RayCastMini == null)
                {
                    hitInfo = new RaycastHit();
                    return default;
                }
            }

            unsafe
            {
                fixed (RaycastHit* hitInfoPtr = &hitInfo)
                {
                    return RayCastMini.Invoke(new IntPtr[] { ray.MonoCast(), new IntPtr(hitInfoPtr) }).GetValuе<bool>();
                }
            }
        }

        public static IL2Class Instance_Class = Assembler.list["UnityEngine.PhysicsModule"].GetClass("Physics", "UnityEngine");
    }
}
