using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BlazeTools;
using BlazeIL;
using BlazeIL.il2cpp;

public class ObjectInstantiator : MonoBehaviour
{
    public ObjectInstantiator(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static string[] adminOnlyPrefabs
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(adminOnlyPrefabs));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(string).FullName + "[]" && x.GetValue().unbox_ToArray().Length == 1)).Name = nameof(adminOnlyPrefabs);
            return field?.GetValue().unbox_ToArray_String();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(adminOnlyPrefabs));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(string).FullName + "[]" && x.GetValue().unbox_ToArray().Length == 1)).Name = nameof(adminOnlyPrefabs);
            field?.SetValue(IntPtr.Zero, value.Select(x => new IL2String(x).ptr).ToArray().ArrayToIntPtr(IL2SystemClass.String));
        }
    }


    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("ObjectInstantiator");
}
