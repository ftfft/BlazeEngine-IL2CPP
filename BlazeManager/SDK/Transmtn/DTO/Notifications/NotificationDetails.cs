using System;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2generic;
using BlazeIL.il2reflection;

namespace Transmtn.DTO.Notifications
{
	public sealed class NotificationDetails : IL2Dictionary<string, string>
	{
		private static IL2Method constructor = null;
		public NotificationDetails() : base(IntPtr.Zero)
		{
			if (constructor == null)
			{
				constructor = Instance_Class.GetMethod(".ctor");
				if (constructor == null)
					throw new Exception("Create construct");
			}

			ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
			constructor.Invoke(ptr);
		}

		public NotificationDetails(IntPtr ptr) : base(ptr) => this.ptr = ptr;

		private static IL2Method methodToString = null;
		public override string ToString()
		{
			if (!IL2Get.Method("ToString", Instance_Class, ref methodToString))
				return null;

			return methodToString.Invoke(ptr)?.Unbox<string>();
		}

		public static new IL2Type Instance_Class = Assemblies.a["Transmtn"].GetClass("NotificationDetails", "Transmtn.DTO.Notifications");
	}
}
