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

    private static IL2Field fieldLocalGain = null;
    public static float LocalGain
    {
        get
        {
            if (fieldLocalGain == null)
            {
                fieldLocalGain = Instance_Class.GetField(x => x.Token == 0x4);
                if (fieldLocalGain == null)
                    return 0f;
            }

            return fieldLocalGain.GetValue().Unbox<float>();
        }
        set
        {
            if (fieldLocalGain == null)
            {
                fieldLocalGain = Instance_Class.GetField(x => x.Token == 0x4);
                if (fieldLocalGain == null)
                    return;
            }

            fieldLocalGain.SetValue(value.MonoCast());
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("USpeaker");
}