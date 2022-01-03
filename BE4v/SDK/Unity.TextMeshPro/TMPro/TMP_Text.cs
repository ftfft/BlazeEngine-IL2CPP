using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using BE4v.SDK.CPP2IL;

namespace TMPro
{
    public abstract class TMP_Text : Graphic
    {
        public TMP_Text(IntPtr ptr) : base(ptr) => base.ptr = ptr;

		unsafe public new Color color
		{
			get => Instance_Class.GetProperty(nameof(color)).GetGetMethod().Invoke(ptr).GetValuе<Color>();
			set => Instance_Class.GetProperty(nameof(color)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public string text
		{
			get => Instance_Class.GetProperty(nameof(text)).GetGetMethod().Invoke(ptr).GetValue<string>();
			set => Instance_Class.GetProperty(nameof(text)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
		}

		public static new IL2Class Instance_Class = Assembler.list["Unity.TextMeshPro"].GetClass("TMP_Text", "TMPro");
    }
}
