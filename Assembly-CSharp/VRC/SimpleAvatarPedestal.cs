using System;
using System.Linq;
using UnityEngine;
using BlazeIL.il2cpp;
using VRC.Core;

namespace VRC
{
    unsafe public class SimpleAvatarPedestal : Component
    {
        public SimpleAvatarPedestal(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Field fieldApiAvatar = null;
        public ApiAvatar apiAvatar
        {
            get
            {
                if (fieldApiAvatar == null)
                {
                    fieldApiAvatar = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "VRC.Core.ApiAvatar");
                    if (fieldApiAvatar == null)
                        return null;
                }

                IL2Object result = fieldApiAvatar.GetValue(ptr);
                if (result == null)
                    return null;

                return result.MonoCast<ApiAvatar>();
            }
        }


        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(SimpleAvatarPedestal))
                return false;
            return ((SimpleAvatarPedestal)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("SimpleAvatarPedestal", "VRC");
    }
}