using System;
using IL2CPP_Core.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro
{
    public abstract class TMP_Text : Graphic
    {
		public TMP_Text(IntPtr ptr) : base(ptr) { }

		unsafe public new Color color
		{
			get => Instance_Class.GetProperty(nameof(color)).GetGetMethod().Invoke<Color>(this).GetValue();
			set => Instance_Class.GetProperty(nameof(color)).GetSetMethod().Invoke(this, new IntPtr[] { new IntPtr(&value) });
		}

		unsafe public string text
		{
			get => Instance_Class.GetProperty(nameof(text)).GetGetMethod().Invoke(this)?.GetValue<IL2String>().ToString();
			set => Instance_Class.GetProperty(nameof(text)).GetSetMethod().Invoke(this, new IntPtr[] { new IL2String(value).Pointer });
		}

		public static new IL2Class Instance_Class = IL2CPP.AssemblyList["Unity.TextMeshPro"].GetClass("TMP_Text", "TMPro");
    }
}
