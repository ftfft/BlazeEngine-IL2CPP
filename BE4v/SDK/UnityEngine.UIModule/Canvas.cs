using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
    public sealed class Canvas : Behaviour
    {
        public Canvas(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public Canvas() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor").Invoke(ptr);
        }

		unsafe public RenderMode renderMode
		{
            get => Instance_Class.GetProperty(nameof(renderMode)).GetGetMethod().Invoke(ptr).GetValuе<RenderMode>();
            set => Instance_Class.GetProperty(nameof(renderMode)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public bool pixelPerfect
		{
            get => Instance_Class.GetProperty(nameof(pixelPerfect)).GetGetMethod().Invoke(ptr).GetValuе<bool>();
            set => Instance_Class.GetProperty(nameof(pixelPerfect)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }

		unsafe public int sortingOrder
		{
            get => Instance_Class.GetProperty(nameof(sortingOrder)).GetGetMethod().Invoke(ptr).GetValuе<int>();
            set => Instance_Class.GetProperty(nameof(sortingOrder)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
        }

        public static new IL2Class Instance_Class = Assembler.list["UnityEngine.UIModule"].GetClass("Canvas", "UnityEngine");
    }
}
