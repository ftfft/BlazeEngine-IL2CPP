using System;
using System.Linq;
using UnityEngine;
using VRC.SDKBase;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

public class VRC_XZ_CHTO_ZA_CLASS : MonoBehaviour
{
    static VRC_XZ_CHTO_ZA_CLASS()
    {
        Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetNestedTypes().FirstOrDefault(y => y.GetMethod("<RemoveEventsIf>b__0") != null) != null);
        if (Instance_Class == null)
        {
            "RANDOM_CLASS::Instance_Class not found!".RedPrefix("WARNING!");
        }
    }

    public VRC_XZ_CHTO_ZA_CLASS(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class;

    public class XZ_CLASS_NUMBER_2 : IL2Base
    {
        public XZ_CLASS_NUMBER_2(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public XZ_CLASS_NUMBER_2() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor").Invoke(ptr);
        }


        public static IL2Class Instance_Class = VRC_XZ_CHTO_ZA_CLASS.Instance_Class.GetNestedTypes().FirstOrDefault(x => x.GetMethod("ToString") != null);
    }
}