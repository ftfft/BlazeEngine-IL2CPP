using UnityEngine;
using BE4v.Mods.Core;

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
                VRCUiPopupManager.Instance.ShowUnityInputPopupWithCancel("Search avatar", "", UnityEngine.UI.InputField.InputType.Standard, false, "Search avatar", (a, b, c) => { ("Arg1" + a + "Arg2" + b + "Arg3" + c).RedPrefix("Test"); }, null, "Enter avatar name");
            }
        }
    }
}
