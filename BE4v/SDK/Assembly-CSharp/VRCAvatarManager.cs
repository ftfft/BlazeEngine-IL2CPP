using System;
using UnityEngine;
using System.Linq;
using BE4v.SDK.CPP2IL;
using VRC.SDK3.Avatars.Components;

public class VRCAvatarManager : MonoBehaviour
{
    public VRCAvatarManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

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

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetField(VRCAvatarDescriptor.Instance_Class) != null);
}
