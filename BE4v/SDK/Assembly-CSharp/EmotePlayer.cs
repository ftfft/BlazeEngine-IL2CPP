using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using UnityEngine;

public class EmotePlayer : MonoBehaviour
{
    public EmotePlayer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod("CancelRPC") != null);
}