using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using BlazeTools;
using BlazeIL;
using BlazeIL.il2cpp;

public class ObjectInstantiator : Component
{
    public ObjectInstantiator(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Field fieldSpawnBlockedList = null;
    public static string[] spawnBlockedList
    {
        get
        {
            if (fieldSpawnBlockedList == null)
            {
                fieldSpawnBlockedList = Instance_Class.GetFields(x => x.ReturnType.Name == "System.String[]").First(x => IL2Import.il2cpp_array_length(x.GetValue().ptr) == 1);
                if (fieldSpawnBlockedList == null)
                    return new string[0];
            }
            return fieldSpawnBlockedList.GetValue().unbox_ToArray_String();
        }
        set
        {
            if (fieldSpawnBlockedList == null)
            {
                fieldSpawnBlockedList = Instance_Class.GetFields(x => x.ReturnType.Name == "System.String[]").First(x => IL2Import.il2cpp_array_length(x.GetValue().ptr) == 1);
                if (fieldSpawnBlockedList == null)
                    return;
            }
            IntPtr[] intPtrs = new IntPtr[value.Length];
            for (int i = 0; i < value.Length; i++)
                intPtrs[i] = IL2Import.StringToIntPtr(value[i]);

            fieldSpawnBlockedList.SetValue(IntPtr.Zero, intPtrs.ArrayToIntPtr(IL2SystemClass.String));
        }
    }


    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("ObjectInstantiator");
}
