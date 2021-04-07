using System;
using BE4v.SDK.CPP2IL;

namespace UnityEngine.UI
{
    // Graphic -> UIBehaviour -> MonoBehaviour -> Behaviour -> Component
    public class Graphic : MonoBehaviour
    {
        public Graphic(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        unsafe public Color color
        {
            get => Instance_Class.GetProperty(nameof(color)).GetGetMethod().Invoke(ptr).GetValuе<Color>();
            set => Instance_Class.GetProperty(nameof(color)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UI"].GetClass("Graphic", "UnityEngine.UI");
    }
}
