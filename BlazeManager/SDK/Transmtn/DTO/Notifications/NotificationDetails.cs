using System;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2generic;

namespace Transmtn.DTO.Notifications
{
	public sealed class NotificationDetails : IL2Dictionary<string, string>
	{
		public NotificationDetails() : base(IntPtr.Zero)
		{
			ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
			Instance_Class.GetConstructor().Invoke(ptr);
		}

		public NotificationDetails(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		public new IL2String ToString()
		{
			return Instance_Class.GetMethod(nameof(ToString)).Invoke(ptr)?.unbox_ToString();
		}

		public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.transmtn]].GetClass("NotificationDetails", "Transmtn.DTO.Notifications");
	}
}
