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

public class QuickMenu : MonoBehaviour
{
    public QuickMenu(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static QuickMenu Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperties().First(x => x.Instance)).Name = nameof(Instance);
            return property?.GetGetMethod().Invoke()?.unbox<QuickMenu>();
        }
    }

    public APIUser SelectedUser
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(SelectedUser));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == APIUser.Instance_Class.FullName)).Name = nameof(SelectedUser);

            return property?.GetGetMethod().Invoke(ptr)?.unbox<APIUser>();
        }
        set
        {
            IL2Property property = Instance_Class.GetProperty(nameof(SelectedUser));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == APIUser.Instance_Class.FullName)).Name = nameof(SelectedUser);

            property?.GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
        }
    }
    
    private static IL2Method m_SetMenuIndex()
    {
        IL2Method method = Instance_Class.GetMethod(nameof(SetMenuIndex));
        if (method == null)
        {
            method = VRCUiAvatarStatsPanel.Instance_Class.GetMethod("BackPressed");
            unsafe
            {
                var disassembler = disasm.GetDisassembler(method, 0x128);
                var instructions = disassembler.Disassemble().Where(x => ILCode.IsJump(x));
                foreach (var instruction in instructions)
                {
                    IntPtr addr = ILCode.GetPointer(instruction);
                    method = Instance_Class.GetMethod(x => *(IntPtr*)x.ptr == addr && !x.IsStatic && x.GetParameters().Length == 1);
                    if (method != null)
                    {
                        method.Name = nameof(SetMenuIndex);
                        break;
                    }
                }
            }
        }
        return method;
    }
    public void SetMenuIndex(int Index)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(SetMenuIndex));
        if (method == null)
            method = m_SetMenuIndex();

        method?.Invoke(ptr, new IntPtr[] { Index.MonoCast() });
    }

    private static IL2Field f_currentMenu()
    {
        IL2Field field = Instance_Class.GetField(nameof(_currentMenu));
        if (field == null)
        {
            unsafe
            {
                var disassembler = disasm.GetDisassembler(m_SetMenuIndex(), 0x128);
                var instructions = disassembler.Disassemble();
                int iCount = 0;
                foreach(var instruction in instructions)
                {
                    if (instruction.ToString().StartsWith("mov "))
                    {
                        if (++iCount == 3)
                        {
                            var resultToken = Convert.ToInt32(instruction.ToString().Split('+').LastOrDefault().Replace("]", ""), 16);
                            field = Instance_Class.GetField(x => x.Token == resultToken);
                            break;
                        }
                    }
                    else
                        iCount = 0;
                }
            }
        }
        return field;
    }

    public GameObject _currentMenu
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(_currentMenu));
            if (field == null)
                (field = f_currentMenu()).Name = nameof(_currentMenu);
            return field?.GetValue(ptr)?.unbox<GameObject>();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(_currentMenu));
            if (field == null)
                (field = f_currentMenu()).Name = nameof(_currentMenu);
            field?.SetValue(ptr, value.ptr);
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClass("QuickMenu");
}
