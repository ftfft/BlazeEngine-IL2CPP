using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

public class VRC_EventLog : MonoBehaviour
{
    public VRC_EventLog(IntPtr ptr) : base(ptr) => base.ptr = ptr;


    public class EventReplicator : MonoBehaviour
    {
        public EventReplicator(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Type Instance_Class = VRC_EventLog.Instance_Class.GetNestedType("EventReplicator");
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRC_EventLog");
}