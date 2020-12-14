using System;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;
using VRC.Core;

public class VRCAvatarManager : MonoBehaviour
{
    public VRCAvatarManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;
    public bool SwitchAvatar(ApiAvatar apiAvatar, string variations, float scale = 1f)
    {
        IL2Object result = Instance_Class.GetMethod(nameof(SwitchAvatar)).Invoke(ptr, new IntPtr[] { apiAvatar.ptr, new IL2String(variations).ptr, scale.MonoCast(), IntPtr.Zero });
        if (result == null)
            return default;

        return result.unbox_Unmanaged<bool>();
    }

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("VRCAvatarManager");
}