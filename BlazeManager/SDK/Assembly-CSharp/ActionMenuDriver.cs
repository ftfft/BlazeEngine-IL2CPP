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
            if (!properties.ContainsKey(nameof(Instance)))
            {
                properties.Add(nameof(Instance), Instance_Class.GetProperty(x => x.Instance));
                if (!properties.ContainsKey(nameof(Instance)))
                    return null;
            }
            IL2Object result = properties[nameof(Instance)].GetGetMethod().Invoke();
            if (result == null)
                return null;

            return result.unbox<ActionMenuDriver>();
        }
    }

    public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
    public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
    public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("ActionMenuDriver");
}
