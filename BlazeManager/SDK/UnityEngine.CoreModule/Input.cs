using System;
using BlazeIL;
using BlazeIL.il2cpp;

namespace UnityEngine
{
    public static class Input
    {
        public static float GetAxis(string axisName)
        {
            return Instance_Class.GetMethod(nameof(GetAxis)).Invoke(new IntPtr[] { new IL2String(axisName).ptr }).unbox_Unmanaged<float>();
        }

        public static bool GetKey(KeyCode key)
        {
            return Instance_Class.GetMethod("GetKeyInt").Invoke(new IntPtr[] { key.MonoCast() }).unbox_Unmanaged<bool>();
        }


        public static bool GetKeyDown(KeyCode key)
        {
            return Instance_Class.GetMethod("GetKeyDownInt").Invoke(new IntPtr[] { key.MonoCast() }).unbox_Unmanaged<bool>();
        }

        public static bool GetKeyUp(KeyCode key)
        {
            return Instance_Class.GetMethod("GetKeyUpInt").Invoke(new IntPtr[] { key.MonoCast() }).unbox_Unmanaged<bool>();
        }
        
        public static bool GetButtonDown(string buttonName)
        {
            return Instance_Class.GetMethod(nameof(GetButtonDown)).Invoke(new IntPtr[] { new IL2String(buttonName).ptr }).unbox_Unmanaged<bool>();
        }

        public static Vector3 mousePosition
        {
            get => Instance_Class.GetProperty(nameof(mousePosition)).GetGetMethod().Invoke().unbox_Unmanaged<Vector3>();
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unityenginecoremodule]].GetClass("Input", "UnityEngine");
    }
}
