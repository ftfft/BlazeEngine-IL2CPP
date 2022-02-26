using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

public class GUI_NONAME_CLASS : MonoBehaviour
{
    public GUI_NONAME_CLASS(IntPtr ptr) : base(ptr) => base.ptr = ptr;


    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("OnApplicationFocus") != null && x.GetMethod("OnApplicationPause") != null && x.GetMethod("OnGUI") != null);
}
