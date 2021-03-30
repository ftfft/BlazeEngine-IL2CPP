using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
    public static class Input
    {
        public static float GetAxis(string axisName)
        {
            return Instance_Class.GetMethod(nameof(GetAxis)).Invoke(new IntPtr[] { new IL2String(axisName).ptr }).GetValuå<float>();
        }

        unsafe public static bool GetKey(KeyCode key)
        {
            IL2Object @object = Instance_Class.GetMethod("GetKeyInt").Invoke(new IntPtr[] { new IntPtr(&key) });
            if (@object != null)
                return @object.GetValuå<bool>();
            return false;
        }


        unsafe public static bool GetKeyDown(KeyCode key)
        {
            IL2Object @object = Instance_Class.GetMethod("GetKeyDownInt").Invoke(new IntPtr[] { new IntPtr(&key) });
            if (@object != null)
                return @object.GetValuå<bool>();
            return false;
        }

        unsafe public static bool GetKeyUp(KeyCode key)
        {
            IL2Object @object = Instance_Class.GetMethod("GetKeyUpInt").Invoke(new IntPtr[] { new IntPtr(&key) });
            if (@object != null)
                return @object.GetValuå<bool>();
            return false;
        }

        public static bool GetButtonDown(string buttonName)
        {
            return Instance_Class.GetMethod(nameof(GetButtonDown)).Invoke(new IntPtr[] { new IL2String(buttonName).ptr }).GetValuå<bool>();
        }

        public static Vector3 mousePosition
        {
            get => Instance_Class.GetProperty(nameof(mousePosition)).GetGetMethod().Invoke().GetValuå<Vector3>();
        }

        public static IL2Class Instance_Class = Assembler.list["UnityEngine.CoreModule"].GetClass("Input", "UnityEngine");
    }
}
