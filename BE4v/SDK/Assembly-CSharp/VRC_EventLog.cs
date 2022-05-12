using System;
using System.Linq;
using UnityEngine;
using VRC.SDKBase;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

public class VRC_EventLog : VRCNetworkBehaviour
{
    static VRC_EventLog()
    {
        Instance_Class = Assembler.list["acs"].GetClasses()
            .FirstOrDefault(
                x =>
                    x.BaseType == VRCNetworkBehaviour.Instance_Class
                 && x.GetMethod("OnApplicationQuit") != null
                 && x.GetNestedTypes().Length == 3
                 && x.GetNestedTypes().FirstOrDefault(
                    y => y.GetField(
                        f => f.ReturnType.Name == "VRC.SDKBase.VRC_EventHandler.VrcBroadcastType"
                        ) != null
                    ) != null
            );
    }

    public VRC_EventLog(IntPtr ptr) : base(ptr) => base.ptr = ptr;


    public class EventLogEntry : IL2Base
    {
        static EventLogEntry()
        {
            Instance_Class = VRC_EventLog.Instance_Class.GetNestedTypes().FirstOrDefault(
                x => x.GetField(y => y.ReturnType.Name == "VRC.SDKBase.VRC_EventHandler.VrcBroadcastType") != null
            );
        }

        public EventLogEntry(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public EventLogEntry() : base(IntPtr.Zero)
        {
            ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
            Instance_Class.GetMethod(".ctor").Invoke(ptr);
        }

        unsafe public string ObjectPath
        {
            get
            {
                IL2Property property = Instance_Class.GetProperty(nameof(ObjectPath));
                if (property == null)
                {
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName)).Name = nameof(ObjectPath);
                    if (property == null)
                        return null;
                }
                IL2Object obj = property.GetGetMethod().Invoke(ptr);
                if (obj == null)
                    return null;

                return obj.GetValue<string>();
            }
            set
            {
                IL2Property property = Instance_Class.GetProperty(nameof(ObjectPath));
                if (property == null)
                {
                    (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName)).Name = nameof(ObjectPath);
                    if (property == null)
                        return;
                }
                property.GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
            }
        }

        unsafe public int instigatorPhotonId
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(instigatorPhotonId));
                if (field == null)
                {
                    (field = Instance_Class.GetFields(x => x.IsPrivate && x.ReturnType.Name == typeof(int).FullName).Skip(1).FirstOrDefault()).Name = nameof(instigatorPhotonId);
                    if (field == null)
                        return default;
                }
                IL2Object obj = field.GetValue(ptr);
                if (obj == null)
                    return default;

                return obj.GetValuе<int>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(instigatorPhotonId));
                if (field == null)
                {
                    (field = Instance_Class.GetFields(x => x.IsPrivate && x.ReturnType.Name == typeof(int).FullName).Skip(1).FirstOrDefault()).Name = nameof(instigatorPhotonId);
                    if (field == null)
                        return;
                }
                field.SetValue(ptr, new IntPtr(&value));
            }
        }

        unsafe public VRC_EventHandler.VrcEvent theEvent
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(theEvent));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.IsPrivate && x.ReturnType.Name == VRC_EventHandler.VrcEvent.Instance_Class.FullName)).Name = nameof(theEvent);
                    if (field == null)
                        return default;
                }
                IL2Object obj = field.GetValue(ptr);
                if (obj == null)
                    return null;

                return obj.GetValue<VRC_EventHandler.VrcEvent>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(theEvent));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.IsPrivate && x.ReturnType.Name == VRC_EventHandler.VrcEvent.Instance_Class.FullName)).Name = nameof(theEvent);
                    if (field == null)
                        return;
                }
                field.SetValue(ptr, value == null ? IntPtr.Zero : value.ptr);
            }
        }


        public static IL2Class Instance_Class;
    }

    public static new IL2Class Instance_Class;
}