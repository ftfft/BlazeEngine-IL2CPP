using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using BE4v.SDK.CPP2IL;

namespace TMPro
{
    public class TMP_Text : Graphic
    {
        public TMP_Text(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		unsafe public new Color color
		{
			get => Instance_Class.GetProperty(nameof(color)).GetGetMethod().Invoke(ptr).GetValuе<Color>();
			set => Instance_Class.GetProperty(nameof(color)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		public static new IL2Class Instance_Class = Assembler.list["Unity.TextMeshPro"].GetClass("TMP_Text", "TMPro");
    }
}
