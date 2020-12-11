using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using BlazeIL.il2cpp;
using BlazeIL;

namespace TMPro
{
    public class TMP_Text : Graphic
    {
        public TMP_Text(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		public new Color color
		{
			get => Instance_Class.GetProperty(nameof(color)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<Color>();
			set => Instance_Class.GetProperty(nameof(color)).GetSetMethod().Invoke(ptr, new IntPtr[] { value.MonoCast() });
		}

		public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.unitytextmeshpro]].GetClass("TMP_Text", "TMPro");
    }
}
