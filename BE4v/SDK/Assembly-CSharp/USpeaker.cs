using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using UnityEngine;

public class USpeaker : MonoBehaviour
{
    public USpeaker(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.FullName != PlayerModComponentVoice.Instance_Class.FullName && x.GetField(USpeakPhotonSender3D.Instance_Class) != null);
}