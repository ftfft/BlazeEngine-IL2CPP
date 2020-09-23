using System;
using System.Linq;
using System.Runtime.InteropServices;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    unsafe public class Physics
    {
        private static IL2Property propertyGravity = null;
        public static Vector3 gravity
        {
            get
            {
                if(propertyGravity == null)
                {
                    propertyGravity = Instance_Class.GetProperty("gravity");
                    if (propertyGravity == null)
                        return default;
                }

                IL2Object result = null;
                result = propertyGravity.GetGetMethod().Invoke();
                if (result == null)
                    return default;

                return *(Vector3*)result.Unbox();
            }
            set
            {
                if (propertyGravity == null)
                {
                    propertyGravity = Instance_Class.GetProperty("gravity");
                    if (propertyGravity == null)
                        return;
                }

                propertyGravity.GetSetMethod().Invoke(new IntPtr[] { new IntPtr(&value) });
            }
        }

        private static IL2Method RayCastMini = null;
        public static bool Raycast(Ray ray, out RaycastHit hitInfo)
        {
            if(RayCastMini == null)
            {
                RayCastMini = Instance_Class.GetMethods()
                    .Where(x => x.Name == "Raycast" && x.GetParameters().Length == 2)
                    .First(x => IL2Import.il2cpp_type_get_name(x.GetParameters()[1].ptr) == "UnityEngine.RaycastHit&");

                if (RayCastMini == null)
                {
                    hitInfo = new RaycastHit();
                    return default;
                }
            }

            fixed (RaycastHit* hitInfoPtr = &hitInfo)
            {
                IL2Object result = null;
                result = RayCastMini.Invoke(new IntPtr[] { new IntPtr(&ray), new IntPtr(hitInfoPtr) });
                if (result == null)
                    return default;

                return *(bool*)result.Unbox();
            }
        }

        public static IL2Type Instance_Class = Assemblies.a["UnityEngine.PhysicsModule"].GetClass("Physics", "UnityEngine");
    }
}
