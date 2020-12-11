using System;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

public class UiToggleButton : MonoBehaviour
{
	public UiToggleButton(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public void Awake()
    {
		Instance_Class.GetMethod(nameof(Awake)).Invoke(ptr);
	}

	public void SetToggleToOn(bool statusButton, bool disabledButton = false)
	{
		toggledOn = disabledButton;
		Awake();

		if (disabledButton)
		{
			statusButton = false;
		}
		if (null != this.disabledButton)
		{
			this.disabledButton.SetActive(statusButton);
		}
		if (null != toggledOnButton)
		{
			toggledOnButton.SetActive(statusButton);
		}
		if (null != toggledOffButton)
		{
			toggledOffButton.SetActive(!statusButton);
		}
	}

	public bool toggledOn
	{
        get => Instance_Class.GetField(nameof(toggledOn)).GetValue(ptr).unbox_Unmanaged<bool>();
        set => Instance_Class.GetField(nameof(toggledOn)).SetValue(ptr, value.MonoCast());
	}
	
	public GameObject toggledOnButton
	{
		get => Instance_Class.GetField(nameof(toggledOnButton)).GetValue(ptr)?.unbox<GameObject>();
		set => Instance_Class.GetField(nameof(toggledOnButton)).SetValue(ptr, (value == null) ? IntPtr.Zero : value.ptr);
	}
	
	public GameObject toggledOffButton
	{
		get => Instance_Class.GetField(nameof(toggledOffButton)).GetValue(ptr)?.unbox<GameObject>();
		set => Instance_Class.GetField(nameof(toggledOffButton)).SetValue(ptr, (value == null) ? IntPtr.Zero : value.ptr);
	}
	
	public GameObject disabledButton
	{
		get => Instance_Class.GetField(nameof(disabledButton)).GetValue(ptr)?.unbox<GameObject>();
		set => Instance_Class.GetField(nameof(disabledButton)).SetValue(ptr, (value == null) ? IntPtr.Zero : value.ptr);
	}

	public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("UiToggleButton");
}