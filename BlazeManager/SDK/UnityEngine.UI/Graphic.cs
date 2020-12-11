using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine.UI
{
    // Graphic -> UIBehaviour -> MonoBehaviour -> Behaviour -> Component
    public class Graphic : MonoBehaviour
    {
        public Graphic(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public Color color
        {
            get => Instance_Class.GetProperty(nameof(color)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<Color>();
            set => Instance_Class.GetProperty(nameof(color)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityengineui]].GetClass("Graphic", "UnityEngine.UI");
    }
}
