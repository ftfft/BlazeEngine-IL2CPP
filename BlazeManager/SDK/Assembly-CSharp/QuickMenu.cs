using System;
using System.Linq;
using System.Collections.Generic;
using BlazeIL.il2cpp;
using BlazeIL.cpp2il;
using BlazeIL.cpp2il.IL;
using BlazeIL.il2ch;
using UnityEngine;
using VRC.Core;
using BlazeIL;
using SharpDisasm;
using SharpDisasm.Udis86;

public class QuickMenu : Component
{
    public QuickMenu(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Property propertyInstance = null;
    public static QuickMenu Instance
    {
        get
        {
            if (propertyInstance == null)
            {
                propertyInstance = Instance_Class.GetProperties().First(x => x.Instance);
                if (propertyInstance == null)
                    return null;
            }

            return propertyInstance.GetGetMethod().Invoke()?.Unbox<QuickMenu>();
        }
    }

    private static IL2Method methodOnClickMenu_PlayAudio = null;
    public void OnClickMenu_PlayAudio()
    {
        if (methodOnClickMenu_PlayAudio == null)
        {
            methodOnClickMenu_PlayAudio = Instance_Class.GetMethods().First(x =>
                x.HasAttribute(BlazeTools.IL2SystemClass.compilerGenerated) &&
                x.GetParameters().Length == 0 &&
                !x.IsStatic
            );
            if (methodOnClickMenu_PlayAudio == null)
                return;
        }
        methodOnClickMenu_PlayAudio.Invoke(ptr);
    }

    private static IL2Property propertySelectedUser = null;
    public APIUser SelectedUser
    {
        get
        {
            if (propertySelectedUser == null)
            {
                propertySelectedUser = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == APIUser.Instance_Class.FullName);
                if (propertySelectedUser == null)
                    return null;
            }

            return propertySelectedUser.GetGetMethod().Invoke(ptr)?.Unbox<APIUser>();
        }
        set
        {
            if (propertySelectedUser == null)
            {
                propertySelectedUser = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == APIUser.Instance_Class.FullName);
                if (propertySelectedUser == null)
                    return;
            }

            propertySelectedUser.GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
        }
    }
    
    private static IL2Method methodSetMenuIndex = null;
    public void SetMenuIndex(int Index)
    {
        if (methodSetMenuIndex == null)
        {
            IL2Method method = VRCUiAvatarStatsPanel.Instance_Class.GetMethod("BackPressed");
            unsafe
            {
                var disassembler = disasm.GetDisassembler(method, 0x128);
                var instructions = disassembler.Disassemble().Where(x => ILCode.IsJump(x));
                foreach (var instruction in instructions)
                {
                    try
                    {

                        IntPtr addr = ILCode.GetPointer(instruction);
                        methodSetMenuIndex = Instance_Class.GetMethods().Where(x => !x.IsStatic && x.GetParameters().Length == 1).FirstOrDefault(x => *(IntPtr*)x.ptr == addr);
                        if (methodSetMenuIndex != null)
                            break;
                    }
                    catch
                    {
                    }
                }
            }
            if (methodSetMenuIndex == null)
                return;
        }

        methodSetMenuIndex.Invoke(ptr, new IntPtr[] { Index.MonoCast() });
    }

    private static IL2Field fieldCurrentMenu = null;
    public GameObject _currentMenu
    {
        get
        {
            if (fieldCurrentMenu == null)
            {
                fieldCurrentMenu = Instance_Class.GetFields().First(x => x.Token == 0xF0);
                if (fieldCurrentMenu == null)
                    return null;
            }
            return fieldCurrentMenu.GetValue(ptr)?.Unbox<GameObject>();
        }
        set
        {
            if (fieldCurrentMenu == null)
            {
                fieldCurrentMenu = Instance_Class.GetFields().First(x => x.Token == 0xF0);
                if (fieldCurrentMenu == null)
                    return;
            }
            fieldCurrentMenu.SetValue(ptr, value.ptr);
        }
    }

    public static Dictionary<string, IL2Property> properties = new Dictionary<string, IL2Property>();
    public static Dictionary<string, IL2Method> methods = new Dictionary<string, IL2Method>();
    public static Dictionary<string, IL2Field> fields = new Dictionary<string, IL2Field>();

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("QuickMenu");
}
