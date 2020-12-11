using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using BlazeIL.il2cpp;

public class USpeakPhotonSender3D : MonoBehaviour
{
    public USpeakPhotonSender3D(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public USpeaker spk
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(spk));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == USpeaker.Instance_Class.FullName)).Name = nameof(spk);
            return field?.GetValue(ptr)?.unbox<USpeaker>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("USpeakPhotonSender3D");
}