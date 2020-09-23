using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using BlazeIL.il2cpp;

public class USpeakPhotonSender3D : Component
{
    public USpeakPhotonSender3D(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Field fieldUSpeaker = null;
    public USpeaker uSpeaker
    {
        get
        {
            if (fieldUSpeaker == null)
            {
                fieldUSpeaker = Instance_Class.GetFields().First(x => x.ReturnType.Name == USpeaker.Instance_Class.FullName);
                if (fieldUSpeaker == null)
                    return null;
            }
            return fieldUSpeaker.GetValue(ptr)?.MonoCast<USpeaker>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("USpeakPhotonSender3D");
}