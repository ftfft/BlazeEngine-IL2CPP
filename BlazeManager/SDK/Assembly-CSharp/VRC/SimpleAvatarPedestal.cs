using System;
using System.Linq;
using UnityEngine;
using BlazeIL.il2cpp;
using VRC.Core;

namespace VRC
{
    public class SimpleAvatarPedestal : Component
    {
        public SimpleAvatarPedestal(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Field fieldApiAvatar = null;
        public ApiAvatar apiAvatar
        {
            get
            {
                if (fieldApiAvatar == null)
                {
                    fieldApiAvatar = Instance_Class.GetFields().First(x => x.ReturnType.Name == ApiAvatar.Instance_Class.FullName);
                    if (fieldApiAvatar == null)
                        return null;
                }

                return fieldApiAvatar.GetValue(ptr)?.Unbox<ApiAvatar>();
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("SimpleAvatarPedestal", "VRC");
    }
}