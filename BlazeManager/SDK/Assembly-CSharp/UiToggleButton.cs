using System;
using System.Linq;
using System.Collections.Generic;
using SharpDisasm.Udis86;
using BlazeIL;
using BlazeIL.cpp2il;
using BlazeIL.cpp2il.IL;
using BlazeIL.il2reflection;
using BlazeIL.il2generic;
using BlazeIL.il2cpp;
using VRC.Core;
using UnityEngine;

public class UiToggleButton : MonoBehaviour
{
	public UiToggleButton(IntPtr ptr) : base(ptr) => base.ptr = ptr;

	public void Awake()
    {
		if (!methods.ContainsKey(nameof(Awake)))
        {
			methods.Add(nameof(Awake), Instance_Class.GetMethod("Awake"));
			if (!methods.ContainsKey(nameof(Awake)))
				return;
		}
		methods[nameof(Awake)].Invoke(ptr);
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
        get
        {
			if (!fields.ContainsKey(nameof(toggledOn)))
            {
				fields.Add(nameof(toggledOn), Instance_Class.GetField("toggledOn"));
				if (!fields.ContainsKey(nameof(toggledOn)))
					return default;
			}
			return fields[nameof(toggledOn)].GetValue(ptr).unbox_Unmanaged<bool>();
		}
        set
        {
			if (!fields.ContainsKey(nameof(toggledOn)))
            {
				fields.Add(nameof(toggledOn), Instance_Class.GetField("toggledOn"));
				if (!fields.ContainsKey(nameof(toggledOn)))
					return;
			}

			fields[nameof(toggledOn)].SetValue(ptr, value.MonoCast());
		}
	}
	
	public GameObject toggledOnButton
	{
        get
        {
			if (!fields.ContainsKey(nameof(toggledOnButton)))
            {
				fields.Add(nameof(toggledOnButton), Instance_Class.GetField("toggledOnButton"));
				if (!fields.ContainsKey(nameof(toggledOnButton)))
					return null;
			}
			return fields[nameof(toggledOnButton)].GetValue(ptr)?.unbox<GameObject>();
		}
        set
        {
			if (!fields.ContainsKey(nameof(toggledOnButton)))
            {
				fields.Add(nameof(toggledOnButton), Instance_Class.GetField("toggledOnButton"));
				if (!fields.ContainsKey(nameof(toggledOnButton)))
					return;
			}
			if (value == null)
				value = new GameObject(IntPtr.Zero);

			fields[nameof(toggledOnButton)].SetValue(ptr, value.ptr);
		}
	}
	
	public GameObject toggledOffButton
	{
        get
        {
			if (!fields.ContainsKey(nameof(toggledOffButton)))
            {
				fields.Add(nameof(toggledOffButton), Instance_Class.GetField("toggledOffButton"));
				if (!fields.ContainsKey(nameof(toggledOffButton)))
					return null;
			}
			return fields[nameof(toggledOffButton)].GetValue(ptr)?.unbox<GameObject>();
		}
        set
        {
			if (!fields.ContainsKey(nameof(toggledOffButton)))
            {
				fields.Add(nameof(toggledOffButton), Instance_Class.GetField("toggledOffButton"));
				if (!fields.ContainsKey(nameof(toggledOffButton)))
					return;
			}
			if (value == null)
				value = new GameObject(IntPtr.Zero);

			fields[nameof(toggledOffButton)].SetValue(ptr, value.ptr);
		}
	}
	public GameObject disabledButton
	{
        get
        {
			if (!fields.ContainsKey(nameof(disabledButton)))
            {
				fields.Add(nameof(disabledButton), Instance_Class.GetField("disabledButton"));
				if (!fields.ContainsKey(nameof(disabledButton)))
					return null;
			}
			return fields[nameof(disabledButton)].GetValue(ptr)?.unbox<GameObject>();
		}
        set
        {
			if (!fields.ContainsKey(nameof(disabledButton)))
            {
				fields.Add(nameof(disabledButton), Instance_Class.GetField("disabledButton"));
				if (!fields.ContainsKey(nameof(disabledButton)))
					return;
			}
			if (value == null)
				value = new GameObject(IntPtr.Zero);

			fields[nameof(disabledButton)].SetValue(ptr, value.ptr);
		}
	}

	public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
	public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
	public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

	public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("UiToggleButton");
}