using System;
using UnityEngine;
using BlazeIL.il2cpp;

namespace VRC.UI
{
    unsafe public class PageAvatar : Component
    {
        public PageAvatar(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;


        private static IL2Field fieldAvatar = null;
        public SimpleAvatarPedestal avatar
        {
            get
            {
                if (!Execute.CheckOrSetField("avatar", Instance_Class, ref fieldAvatar))
                    return default;

                IL2Object result = fieldAvatar.GetValue(ptr);
                if (result == null)
                    return default;

                return result.MonoCast<SimpleAvatarPedestal>();
            }
            set
            {
                if (!Execute.CheckOrSetField("avatar", Instance_Class, ref fieldAvatar))
                    return;

                fieldAvatar.SetValue(ptr, value.ptr);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(PageAvatar))
                return false;
            return ((PageAvatar)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PageAvatar", "VRC.UI");
    }
}