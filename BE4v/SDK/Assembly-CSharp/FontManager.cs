using System;
using System.Linq;
using UnityEngine;
using BE4v.SDK.CPP2IL;
using TMPro;

public class FontManager : MonoBehaviour
{
    public FontManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public static FontManager Instance
	{
		get
		{
			IL2Property property = Instance_Class.GetProperty(nameof(Instance));
			if (property == null)
				(property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
			return property?.GetGetMethod()?.Invoke().GetValue<FontManager>();
		}
	}
	
	public TMP_FontAsset[] DynamicFonts
	{
		get
		{
			IL2Field field = Instance_Class.GetField(nameof(DynamicFonts));
			if (field == null)
				(field = Instance_Class.GetField(y => y.ReturnType.Name.StartsWith(TMP_FontAsset.Instance_Class.FullName))).Name = nameof(DynamicFonts);
			return field?.GetValue(ptr).UnboxArray<TMP_FontAsset>();
		}
		set
		{
			IL2Field field = Instance_Class.GetField(nameof(DynamicFonts));
			if (field == null)
				(field = Instance_Class.GetField(y => y.ReturnType.Name.StartsWith(TMP_FontAsset.Instance_Class.FullName))).Name = nameof(DynamicFonts);
			
			// field?.SetValue(ptr, );
		}
	}


	public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetField(y => y.ReturnType.Name.StartsWith(TMP_FontAsset.Instance_Class.FullName)) != null);
}