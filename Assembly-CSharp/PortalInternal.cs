using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BlazeIL.il2cpp;

public class PortalInternal : Component
{
    public PortalInternal(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PortalInternal");
}
