using System;
using System.Linq;
using UnityEngine;
using BlazeIL.il2cpp;
using VRC.Core;

namespace VRC
{
    public class SimpleAvatarPedestal : MonoBehaviour
    {
        public SimpleAvatarPedestal(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public ApiAvatar apiAvatar
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(apiAvatar));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == ApiAvatar.Instance_Class.FullName)).Name = nameof(apiAvatar);
                return field?.GetValue(ptr)?.unbox<ApiAvatar>();
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("SimpleAvatarPedestal", "VRC");
    }
}