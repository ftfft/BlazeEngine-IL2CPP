using System;
using UnityEngine;
using BE4v.Mods.Core;
using BE4v.SDK.CPP2IL;

namespace BE4v.Mods.Min
{
    public class CameraHeight : IUpdate
    {
        public void Update()
        {
            if (!Threads.isCtrl) return;
            if (!Status.is3thCam)
            {
                float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
                if (mouseWheel > 0.1)
                {
                    Camera.main.transform.localPosition += (Vector3.up * 0.1f);
                }
                else if (mouseWheel < -0.1)
                {
                    Camera.main.transform.localPosition -= (Vector3.up * 0.1f);
                }
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                VRCUiPopupManager.Instance.ShowUnityInputPopupWithCancel("Search avatar", "", UnityEngine.UI.InputField.InputType.Standard, false, "Search avatar", OnSubmit, null, "Enter avatar name");
            }
        }


        unsafe public static void OnSubmit(IntPtr a, IntPtr b, IntPtr c)
        {
            Console.WriteLine(new IL2String(a).ToString());
        }
    }
}
