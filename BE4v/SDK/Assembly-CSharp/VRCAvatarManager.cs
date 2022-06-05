using System;
using UnityEngine;
using System.Linq;
using BE4v.SDK.CPP2IL;
using VRC.Core;
using VRC.SDK3.Avatars.Components;

public class VRCAvatarManager : MonoBehaviour
{
    public VRCAvatarManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    static VRCAvatarManager()
    {
        // void ShowImage(ApiAvatar apiAvatar)
        try
        {
            Instance_Class.GetMethod(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ReturnType.Name == ApiAvatar.Instance_Class.FullName).Name = nameof(ShowImage);
        }
        catch { "Function not found".RedPrefix("VRCAvatarManager::ShowImage"); }
    }

    public VRCAvatarDescriptor currentAvatarDescriptorSDK3
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(currentAvatarDescriptorSDK3));
            if (property == null)
                (property = Instance_Class.GetProperty(VRCAvatarDescriptor.Instance_Class)).Name = nameof(currentAvatarDescriptorSDK3);
            return property?.GetGetMethod().Invoke(ptr)?.GetValue<VRCAvatarDescriptor>();
        }
    }

    public void ShowImage(ApiAvatar apiAvatar)
    {
        Instance_Class.GetMethod(nameof(ShowImage)).Invoke(ptr, new IntPtr[] { apiAvatar == null ? IntPtr.Zero : apiAvatar.ptr });
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().First(x => x.GetProperty(VRCAvatarDescriptor.Instance_Class) != null);
}
