using System;
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