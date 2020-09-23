using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;

unsafe public class VRCPlayer : Component
{
    public VRCPlayer(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;


    public static VRCPlayer Instance => VRC.Player.Instance.vrcPlayer;

    // For Safety mode
    private static IL2Field fieldVRCInput = null;
    public VRCInput vrcInput
    {
        get
        {
            if (fieldVRCInput == null)
            {
                fieldVRCInput = Instance_Class.GetFields().First(x => x.GetReturnType().Name == VRCInput.Instance_Class.Name);
                if (fieldVRCInput == null)
                    return null;
            }

            IL2Object result = fieldVRCInput.GetValue(ptr);
            if (result == null)
                return null;

            return result.MonoCast<VRCInput>();
        }
    }

    private static IL2Field fieldUSpeaker = null;
    public USpeaker uSpeaker
    {
        get
        {
            if (fieldUSpeaker == null)
            {
                fieldUSpeaker = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "USpeaker");
                if (fieldUSpeaker == null)
                    return null;
            }

            IL2Object result = fieldUSpeaker.GetValue(ptr);
            if (result == null)
                return null;

            return result.MonoCast<USpeaker>();
        }
    }

    private static IL2Field fieldPlayerSelector = null;
    public PlayerSelector playerSelector
    {
        get
        {
            if (fieldPlayerSelector == null)
            {
                fieldPlayerSelector = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "PlayerSelector");
                if (fieldPlayerSelector == null)
                    return null;
            }

            IL2Object result = fieldPlayerSelector.GetValue(ptr);
            if (result == null)
                return null;

            return result.MonoCast<PlayerSelector>();
        }
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(VRCPlayer))
            return false;
        return ((VRCPlayer)obj).ptr == ptr;
    }

    public override int GetHashCode() =>
        ptr.GetHashCode();

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCPlayer");
}