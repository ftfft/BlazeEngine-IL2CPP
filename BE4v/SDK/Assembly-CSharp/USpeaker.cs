using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using UnityEngine;

public class USpeaker : MonoBehaviour
{
    public USpeaker(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClass(VRC.Player.Instance_Class.GetField("_USpeaker")?.ReturnType.Name);
}