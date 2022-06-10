using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;

namespace VRC.Networking.Tween
{
    public class PositionEvent : IL2Base
    {
        public PositionEvent(IntPtr ptr) : base(ptr) => base.ptr = ptr;


        unsafe public Vector3 Velocity
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(Velocity));
                if (field == null)
                    (field = Instance_Class.GetFields().FirstOrDefault(x => x.ReturnType.Name == typeof(Vector3).FullName)).Name = nameof(Velocity);
                return field?.GetValue(ptr)?.GetValuе<Vector3>() ?? default;
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(Velocity));
                if (field == null)
                    (field = Instance_Class.GetFields().FirstOrDefault(x => x.ReturnType.Name == typeof(Vector3).FullName)).Name = nameof(Velocity);
                field?.SetValue(ptr, new IntPtr(&value));
            }
        }
        unsafe public Vector3 Position
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(Position));
                if (field == null)
                    (field = Instance_Class.GetFields().LastOrDefault(x => x.ReturnType.Name == typeof(Vector3).FullName)).Name = nameof(Position);
                return field?.GetValue(ptr)?.GetValuе<Vector3>() ?? default;
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(Position));
                if (field == null)
                    (field = Instance_Class.GetFields().LastOrDefault(x => x.ReturnType.Name == typeof(Vector3).FullName)).Name = nameof(Position);
                field?.SetValue(ptr, new IntPtr(&value));
            }
        }


        public static IL2Class Instance_Class = Assembler.list["acs"].GetClass(SyncPhysics.Instance_Class.GetMethod("ApplyEvent").GetParameters()[0].ReturnType.Name);
    }
}