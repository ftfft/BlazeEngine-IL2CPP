using BE4v.SDK.CPP2IL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class InteractivePlayer : MonoBehaviour
{
    public InteractivePlayer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().First(x => x.GetFields().Length == 2 && x.GetFields()[0].ReturnType.Name == x.GetFields()[1].ReturnType.Name && x.GetMethod("Awake") != null && x.GetMethod("Update") != null);
}
