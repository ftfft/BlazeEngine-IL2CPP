using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using UnityEngine;

public class USpeaker : MonoBehaviour
{
    public USpeaker(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    unsafe public static float LocalGain
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(LocalGain));
            if (field == null)
                (field = Instance_Class.GetField(x => x.Token == 0x4)).Name = nameof(LocalGain);
            IL2Object result = field.GetValue();
            if (result == null)
                return default;
            return result.GetValuе<float>();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(LocalGain));
            if (field == null)
                (field = Instance_Class.GetField(x => x.Token == 0x4)).Name = nameof(LocalGain);
            field?.SetValue(new IntPtr(&value));
        }
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass(VRC.Player.Instance_Class.GetField("_USpeaker")?.ReturnType.Name);
}