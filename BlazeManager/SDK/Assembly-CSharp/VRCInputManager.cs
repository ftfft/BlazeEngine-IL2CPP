using System;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

public class VRCInputManager : MonoBehaviour
{
    public VRCInputManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Field fieldMicLvlVR = null;
    public static float MicLevelVR
    {
        get
        {
            if (fieldMicLvlVR == null)
            {
                fieldMicLvlVR = Instance_Class.GetField(x => x.Token == 0x40);
                if (fieldMicLvlVR == null)
                    return 0f;
            }

            return fieldMicLvlVR.GetValue().Unbox<float>();
        }
        set
        {
            if (fieldMicLvlVR == null)
            {
                fieldMicLvlVR = Instance_Class.GetField(x => x.Token == 0x40);
                if (fieldMicLvlVR == null)
                    return;
            }

            fieldMicLvlVR.SetValue(value.MonoCast());
        }
    }
    

    private static IL2Field fieldMicLvlDesc = null;
    public static float MicLevelDesc
    {
        get
        {
            if (fieldMicLvlDesc == null)
            {
                fieldMicLvlDesc = Instance_Class.GetField(x => x.Token == 0x40);
                if (fieldMicLvlDesc == null)
                    return 0f;
            }

            return fieldMicLvlDesc.GetValue().Unbox<float>();
        }
        set
        {
            if (fieldMicLvlDesc == null)
            {
                fieldMicLvlDesc = Instance_Class.GetField(x => x.Token == 0x40);
                if (fieldMicLvlDesc == null)
                    return;
            }

            fieldMicLvlDesc.SetValue(value.MonoCast());
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCInputManager");
}