using System;
using System.Linq;
using UnityEngine;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;

namespace VRC
{
    public class SimpleAvatarPedestal : MonoBehaviour
    {
        public SimpleAvatarPedestal(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public SimpleAvatarPedestal() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor").Invoke(ptr);
        }
        public ApiAvatar apiAvatar
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(apiAvatar));
                if (field == null)
                    (field = Instance_Class.GetField(ApiAvatar.Instance_Class)).Name = nameof(apiAvatar);
                return field?.GetValue(ptr)?.GetValue<ApiAvatar>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(apiAvatar));
                if (field == null)
                    (field = Instance_Class.GetField(ApiAvatar.Instance_Class)).Name = nameof(apiAvatar);
                field?.SetValue(ptr, (value == null) ? IntPtr.Zero : value.ptr);
            }
        }

        public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass(UiAvatarList.Instance_Class.GetFields().First().ReturnType.Name);
    }
}