using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

public class ObjectInstantiator : MonoBehaviour
{
    public ObjectInstantiator(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static string[] adminOnlyPrefabs
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(adminOnlyPrefabs));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(string[]).FullName && x.GetValue().GetValue<string>().Length == 1)).Name = nameof(adminOnlyPrefabs);
            return field?.GetValue().UnboxArray<string>();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(adminOnlyPrefabs));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(string[]).FullName && x.GetValue().GetValue<string>().Length == 1)).Name = nameof(adminOnlyPrefabs);
            field?.SetValue(IntPtr.Zero, value.Select(x => new IL2String(x).ptr).ArrayToIntPtr(IL2SystemClass.String));
        }
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByMethodName("_InstantiateObject");
}
