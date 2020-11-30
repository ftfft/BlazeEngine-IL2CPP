using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRC.Core;
using VRC.SDKBase;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2ch;
using BlazeIL.il2cpp;
using BlazeIL.cpp2il;
using BlazeIL.cpp2il.IL;
using BlazeTools;
using Addons.Mods;
using SharpDisasm;
using SharpDisasm.Udis86;

namespace Addons.Patch
{
    public delegate void _QuickMenu_CloseMenu(IntPtr instance);
    public static class patch_QuickMenu
    {
        public static void Toggle_Enable()
        {
            BlazeManager.SetForPlayer("QuickMenu Close", !BlazeManager.GetForPlayer<bool>("QuickMenu Close"));
            RefreshStatus();
        }

        public static void RefreshStatus()
        {
            bool toggle = BlazeManager.GetForPlayer<bool>("QuickMenu Close");
            BlazeManagerMenu.Main.togglerList["QuickMenu Close"].SetToggleToOn(toggle, false);
        }


        public static void Start()
        {
            /*
            unsafe
            {
                IL2Method m1 = QuickMenu.Instance_Class.GetMethod("Start");
                var disassembler = disasm.GetDisassembler(m1);
                var instructions = disassembler.Disassemble().TakeWhile(x => x.Mnemonic != ud_mnemonic_code.UD_Iint3);
                int i = 0;
                foreach (var instruction in instructions)
                {
                    //System.IO.File.AppendAllText("testt.txt", instruction.ToString() + "\n");
                    try
                    {
                        IntPtr addr = ILCode.GetPointer(instruction);
                        Console.Write(*(byte*)addr.ToPointer() + " ");
                    }
                    catch { Console.WriteLine("bad"); }
                }
            }
            */
            IL2Method method = QuickMenu.Instance_Class.GetMethod("LateUpdate");
            List<IL2Method> methods = new List<IL2Method>();
            try
            {

                unsafe
                {
                    var disassembler = disasm.GetDisassembler(method);
                    var instructions = disassembler.Disassemble().TakeWhile(x => x.Mnemonic != ud_mnemonic_code.UD_Iint3);
                    foreach (var instruction in instructions)
                    {
                        if (!ILCode.IsCall(instruction))
                            continue;

                        try
                        {
                            IntPtr addr = ILCode.GetPointer(instruction);
                            method = QuickMenu.Instance_Class.GetMethods().First(x => *(IntPtr*)x.ptr == addr);

                            if (method.GetParameters().Length != 0 || method.ReturnType.Name != typeof(void).FullName)
                                continue;

                            methods.Add(method);
                        }
                        catch { continue; }
                    }
                }

                foreach (var m in methods.GroupBy(x => x.Name).Where(x => x.Count() > 1).Select(x => x.First()))
                {
                    var patch = IL2Ch.Patch(m, (_QuickMenu_CloseMenu)QuickMenu_CloseMenu);
                    _delegateQuickMenu_CloseMenu = patch.CreateDelegate<_QuickMenu_CloseMenu>();
                    break;
                }

                if (_delegateQuickMenu_CloseMenu == null)
                    throw new Exception();

                ConSole.Success("Patch: CloseQuickMenu");

            }
            catch
            {
                ConSole.Error("Patch: CloseQuickMenu");
            }
        }

        public static void QuickMenu_CloseMenu(IntPtr instance)
        {
            _delegateQuickMenu_CloseMenu.Invoke(instance);
        }

        public static _QuickMenu_CloseMenu _delegateQuickMenu_CloseMenu;
    }
}
