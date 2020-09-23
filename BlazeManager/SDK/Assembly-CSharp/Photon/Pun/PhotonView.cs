using System;
using System.Linq;
using UnityEngine;
using BlazeIL.il2cpp;

namespace Photon.Pun
{
    public class PhotonView : Component
    {
        public PhotonView(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public int viewIdField
        {
            get
            {
                if (f_viewIdField == null)
                {
                    f_viewIdField = Instance_Class.GetField("viewIdField");
                    if (f_viewIdField == null)
                        return default;
                }
                return f_viewIdField.GetValue(ptr).Unbox<int>();
            }
        }

        private static IL2Field f_viewIdField;

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PhotonView", "Photon.Pun");
    }
}
