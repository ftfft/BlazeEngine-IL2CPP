using System;
using System.Collections.Generic;
using BE4v.SDK.CPP2IL;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;

namespace Transmtn.DTO.Notifications
{
	public sealed class NotificationDetails : IL2Dictionary<string, string>
	{
		public NotificationDetails() : base(IntPtr.Zero)
		{
			ptr = Import.Object.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetMethod(".ctor").Invoke(ptr);
		}

		public NotificationDetails(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		public override string ToString()
		{
			return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.GetValue<string>();
		}

		public static IL2Class Instance_Class = Assembler.list["Transmtn"].GetClass("NotificationDetails", "Transmtn.DTO.Notifications");
	}
}
