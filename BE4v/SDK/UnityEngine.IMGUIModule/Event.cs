using System;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace UnityEngine
{
	public sealed class Event : IL2Base
	{
		public Event(IntPtr ptr) : base(ptr) => base.ptr = ptr;
		public static Event current
		{
			get => Instance_Class.GetProperty(nameof(current)).GetGetMethod().Invoke().GetValue<Event>();
			set => Instance_Class.GetProperty(nameof(current)).GetSetMethod().Invoke(new IntPtr[] { value == null ? IntPtr.Zero : value.ptr });
		}

		unsafe public EventType type
		{
			get => Instance_Class.GetProperty(nameof(type)).GetGetMethod().Invoke(ptr).GetValuе<EventType>();
			set => Instance_Class.GetProperty(nameof(type)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		public static IL2Class Instance_Class = Assembler.list["UnityEngine.IMGUI"].GetClass("Event", "UnityEngine");
	}
}
