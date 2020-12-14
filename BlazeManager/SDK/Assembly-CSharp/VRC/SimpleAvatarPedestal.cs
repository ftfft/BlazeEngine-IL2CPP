using System;
using System.Linq;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;
using VRC.Core;

namespace VRC
{
    public class SimpleAvatarPedestal : MonoBehaviour
    {
        public SimpleAvatarPedestal(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public SimpleAvatarPedestal() : base(IntPtr.Zero)
        {
            ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetConstructor().Invoke(ptr);
        }
        public ApiAvatar apiAvatar
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(apiAvatar));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == ApiAvatar.Instance_Class.FullName)).Name = nameof(apiAvatar);
                return field?.GetValue(ptr)?.unbox<ApiAvatar>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(apiAvatar));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == ApiAvatar.Instance_Class.FullName)).Name = nameof(apiAvatar);
                field?.SetValue(ptr, (value == null) ? IntPtr.Zero : value.ptr);
            }
        }

        public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("SimpleAvatarPedestal", "VRC");
    }
}