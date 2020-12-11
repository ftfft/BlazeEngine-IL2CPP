using System;
using System.Linq;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;

public class ObjectInstantiatorHandle : MonoBehaviour
{
    public ObjectInstantiatorHandle(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public ObjectInstantiator Instantiator
	{
		get
		{
			IL2Field field = Instance_Class.GetField(nameof(Instantiator));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == ObjectInstantiator.Instance_Class.FullName)).Name = nameof(Instantiator); ;
			return field?.GetValue(ptr)?.unbox<ObjectInstantiator>();
		}
		set
		{
			IL2Field field = Instance_Class.GetField(nameof(Instantiator));
			if (field == null)
				(field = Instance_Class.GetField(x => x.ReturnType.Name == ObjectInstantiator.Instance_Class.FullName)).Name = nameof(Instantiator);
			field?.SetValue(ptr, value.ptr);
		}
	}

	private static IL2Field fieldLocalID = null;
	public int? LocalID
	{
		get
		{
			if (fieldLocalID == null)
			{
				fieldLocalID = Instance_Class.GetField(x => x.ReturnType.Name == typeof(int?).FullName);
				if (fieldLocalID == null)
					return null;
			}
			IL2Object result = fieldLocalID.GetValue(ptr);
			if (result == null)
				return null;

			return result.MonoCast<int>();
		}
		set
		{
			if (fieldLocalID == null)
			{
				fieldLocalID = Instance_Class.GetField(x => x.ReturnType.Name == typeof(int?).FullName);
				if (fieldLocalID == null)
					return;
			}
			fieldLocalID.SetValue(ptr, value.Value.MonoCast());
		}
	}

	public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("ObjectInstantiatorHandle");
}
