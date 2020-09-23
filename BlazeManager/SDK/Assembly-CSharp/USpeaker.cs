using System;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

public class USpeaker : Component
{
    public USpeaker(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Field fieldMute = null;
    public bool Mute
    {
        get
        {
            if (fieldMute == null)
            {
                fieldMute = Instance_Class.GetField("Mute");
                if (fieldMute == null)
                    return true;
            }

            return fieldMute.GetValue(ptr).Unbox<bool>();
        }
        set
        {
            if (fieldMute == null)
            {
                fieldMute = Instance_Class.GetField("Mute");
                if (fieldMute == null)
                    return;
            }

            fieldMute.SetValue(ptr, value.MonoCast());
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("USpeaker");
}