using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using VRC;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2generic;
using BlazeIL.il2reflection;

public class ActionMenuDriver : MonoBehaviour
{
	public ActionMenuDriver(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public static ActionMenuDriver Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property?.GetGetMethod().Invoke()?.unbox<ActionMenuDriver>();
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("ActionMenuDriver");
}
