using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;
using VRC.Core;
namespace VRC.UI
{
    public class PageUserInfo : MonoBehaviour
    {
        public PageUserInfo(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Field fUser;
        public APIUser user
        {
            get
            {
                if (fUser == null)
                {
                    fUser = Instance_Class.GetField("user");
                    if (fUser == null)
                        return null;
                }
                return fUser.GetValue(ptr)?.MonoCast<APIUser>();
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PageUserInfo", "VRC.UI");
    }
}