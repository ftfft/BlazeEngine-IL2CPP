using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using BE4v.SDK.CPP2IL;

// UnnamedClass->UnnamedClass2->MonoBehaviour
public class PlayerModComponentHealth : MonoBehaviour
{
    public PlayerModComponentHealth(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass("PlayerModComponentHealth");
}