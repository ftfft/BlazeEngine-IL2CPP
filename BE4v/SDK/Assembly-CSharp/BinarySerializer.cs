﻿using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using UnityEngine;

public class BinarySerializer : IL2Base
{
    static BinarySerializer()
    {
        Instance_Class = Assembler.list["acs"].GetClasses()
            .FirstOrDefault(x => x.GetNestedTypes()
                .FirstOrDefault(y => y.GetField("SERIALIZABLE_CONTAINER") != null) != null);
    }

    public BinarySerializer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    unsafe public int bytePos
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(bytePos));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(int).FullName)).Name = nameof(bytePos);
                if (field == null)
                    return default;
            }
            return field.GetValue(ptr).GetValuе<int>();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(bytePos));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(int).FullName)).Name = nameof(bytePos);
                if (field == null)
                    return;
            }
            field.SetValue(ptr, new IntPtr(&value));
        }
    }

    public IL2Array<byte> decBuffer
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(decBuffer));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith(typeof(byte).FullName))).Name = nameof(decBuffer);
                if (field == null)
                    return null;
            }
            IL2Object result = field.GetValue(ptr);
            if (result == null)
                return null;

            return new IL2Array<byte>(result.ptr);
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(decBuffer));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith(typeof(byte).FullName))).Name = nameof(decBuffer);
                if (field == null)
                    return;
            }
            field.SetValue(ptr, value.ptr);
        }
    }

    private static BinarySerializer serializer
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(serializer));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.Instance)).Name = nameof(serializer);
                if (field == null)
                    return null;
            }
            return field.GetValue().GetValue<BinarySerializer>();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(serializer));
            if (field == null)
            {
                (field = Instance_Class.GetField(x => x.Instance)).Name = nameof(serializer);
                if (field == null)
                    return;
            }
            field.SetValue(value == null ? IntPtr.Zero : value.ptr);
        }
    }

    public enum TypeCode : byte
	{
		NULL = 1,
		BYTE,
		DOUBLE,
		FLOAT,
		INT,
		SHORT,
		LONG,
		BOOL,
		STRING,
		OBJECT_ARRAY,
		TYPE_ARRAY,
		VECTOR2 = 100,
		VECTOR3,
		VECTOR4,
		QUATERNION,
		COLOR,
		COLOR32,
		EVENTLOG_ENTRY,
		PLAYER_VIDEO_ENTRY,
		STREAM_VIDEO_ENTRY,
		DATA_ELEMENT,
		SERIALIZABLE_BEHAVIOR,
		SERIALIZABLE_CONTAINER,
		GAMEOBJECT,
		TRANSFORM
	}

	public static IL2Class Instance_Class;
}