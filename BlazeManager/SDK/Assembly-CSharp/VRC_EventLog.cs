using System;
using System.Linq;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;
using VRC.SDKBase;

public class VRC_EventLog : MonoBehaviour
{
    public VRC_EventLog(IntPtr ptr) : base(ptr) => base.ptr = ptr;


    public class EventReplicator : MonoBehaviour
    {
        public EventReplicator(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public static new IL2Type Instance_Class = VRC_EventLog.Instance_Class.GetNestedType("EventReplicator");
    }

    public class VrcEvent : IL2Base
    {
        public VrcEvent(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        private static IL2Method constructVrcEvent = null;
        public VrcEvent() : base(IntPtr.Zero)
        {
            if (constructVrcEvent == null)
            {
                constructVrcEvent = Instance_Class.GetMethod(".ctor");
                if (constructVrcEvent == null)
                    return;
            }

            ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
            constructVrcEvent.Invoke(ptr);
        }

        public VRC_EventHandler.VrcEvent vrcEvent
        {
            get
            {
                if (!fields.ContainsKey(nameof(vrcEvent)))
                {
                    fields.Add(nameof(vrcEvent), Instance_Class.GetField(x => x.ReturnType.Name == VRC_EventHandler.VrcEvent.Instance_Class.FullName));
                    if (!fields.ContainsKey(nameof(vrcEvent)))
                        return null;
                }
                return fields[nameof(vrcEvent)].GetValue(ptr)?.unbox<VRC_EventHandler.VrcEvent>();
            }
            set
            {
                if (!fields.ContainsKey(nameof(vrcEvent)))
                {
                    fields.Add(nameof(vrcEvent), Instance_Class.GetField(x => x.ReturnType.Name == VRC_EventHandler.VrcEvent.Instance_Class.FullName));
                    if (!fields.ContainsKey(nameof(vrcEvent)))
                        return;
                }
                fields[nameof(vrcEvent)].SetValue(ptr, value.ptr);
            }
        }

        public VRC_EventHandler.VrcBroadcastType vrcBroadcastType
        {
            get
            {
                if (!fields.ContainsKey(nameof(vrcBroadcastType)))
                {
                    fields.Add(nameof(vrcBroadcastType), Instance_Class.GetField(x => x.ReturnType.Name == VRC_EventHandler.Instance_Class.FullName + ".VrcBroadcastType"));
                    if (!fields.ContainsKey(nameof(vrcBroadcastType)))
                        return default;
                }
                return fields[nameof(vrcBroadcastType)].GetValue(ptr).unbox_Unmanaged<VRC_EventHandler.VrcBroadcastType>();
            }
            set
            {
                if (!fields.ContainsKey(nameof(vrcBroadcastType)))
                {
                    fields.Add(nameof(vrcBroadcastType), Instance_Class.GetField(x => x.ReturnType.Name == VRC_EventHandler.Instance_Class.FullName + ".VrcBroadcastType"));
                    if (!fields.ContainsKey(nameof(vrcBroadcastType)))
                        return;
                }
                fields[nameof(vrcBroadcastType)].SetValue(ptr, value.MonoCast());
            }
        }

        private static IL2Field[] fieldsInt = null;
        public int vrcInt
        {
            set
            {
                if (fieldsInt == null)
                {
                    fieldsInt = Instance_Class.GetFields(x => x.ReturnType.Name == typeof(int).FullName);
                    if (fieldsInt == null)
                        return;
                }
                foreach(var field in fieldsInt)
                {
                    field.SetValue(ptr, value.MonoCast());
                }
            }
        }
        
        private static IL2Field[] fieldsLong = null;
        public long vrcLong
        {
            set
            {
                if (fieldsLong == null)
                {
                    fieldsLong = Instance_Class.GetFields(x => x.ReturnType.Name == typeof(long).FullName);
                    if (fieldsLong == null)
                        return;
                }
                foreach(var field in fieldsLong)
                {
                    field.SetValue(ptr, value.MonoCast());
                }
            }
        }
        
        private static IL2Field[] fieldsFloat = null;
        public float vrcFloat
        {
            set
            {
                if (fieldsFloat == null)
                {
                    fieldsFloat = Instance_Class.GetFields(x => x.ReturnType.Name == typeof(float).FullName);
                    if (fieldsFloat == null)
                        return;
                }
                foreach(var field in fieldsFloat)
                {
                    field.SetValue(ptr, value.MonoCast());
                }
            }
        }


        public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
        public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
        public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

        public static IL2Type Instance_Class = VRC_EventLog.Instance_Class.GetNestedTypes().First(x => x.GetFields().Length > 5);
    }


    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRC_EventLog");
}