using System;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using VRC.Core;
using BE4v;
using BE4v.Utils;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using BE4v.SDK.IL2Dumper;
using VRC.UI.Core;


namespace VRC.UI.Elements
{
    public class MenuStateController : MonoBehaviour
    {
        static MenuStateController()
        {
            try
            {
                // ------------------ [ Find By PushPage ] args:
                // contentIndex or pageName
                // uiContext
                // clearPageStack
                // inPlace
                // 
                IL2Method showTabContent = Instance_Class.GetMethod("ShowTabContent");
                var instruction = showTabContent.GetDisassembler(0x100).Disassemble().FirstOrDefault(x => x.Mnemonic == SharpDisasm.Udis86.ud_mnemonic_code.UD_Icall);
                IntPtr addr = new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);
                IL2Method method = null;
                unsafe
                {
                    method = Instance_Class.GetMethod(x => *(IntPtr*)x.ptr == addr);
                }
                if (method != null)
                {
                    string methodName = method.Name;
                    foreach(var m in Instance_Class.GetMethods(x => x.Name == methodName))
                    {
                        m.Name = nameof(PushPage);
                    }
                }
            }
            catch
            {
                "Failed find!".RedPrefix("MenuStateController::PushPage");
            }
        }

        public MenuStateController(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public unsafe void PushPage(string pageName, UIContext uiContext = null, bool clearPageStack = false, bool inPlace = false)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(PushPage), x => x.GetParameters()[0].ReturnType.Name == typeof(string).FullName);
            if (method == null)
            {
                "Not found function!".RedPrefix("MenuStateController::PushPage");
                return;
            }

            IntPtr uiContextPtr = IntPtr.Zero;
            if (uiContext != null)
                uiContextPtr = uiContext.ptr;

            method.Invoke(ptr, new IntPtr[] { new IL2String(pageName).ptr, uiContextPtr, new IntPtr(&clearPageStack), new IntPtr(&inPlace) });
        }
        
        public unsafe void PushPage(int contentIndex, UIContext uiContext = null, bool clearPageStack = false, bool inPlace = false)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(PushPage), x => x.GetParameters()[0].ReturnType.Name == typeof(string).FullName);
            if (method == null)
            {
                "Not found function!".RedPrefix("MenuStateController::PushPage");
                return;
            }

            IntPtr uiContextPtr = IntPtr.Zero;
            if (uiContext != null)
                uiContextPtr = uiContext.ptr;

            method.Invoke(ptr, new IntPtr[] { new IntPtr(&contentIndex), uiContextPtr, new IntPtr(&clearPageStack), new IntPtr(&inPlace) });
        }


        public unsafe UIPage[] menuRootPages
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(menuRootPages));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == UIPage.Instance_Class.FullName + "[]")).Name = nameof(menuRootPages);
                    if (field == null)
                        return null;
                }
                return field.GetValue(ptr).UnboxArray<UIPage>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(menuRootPages));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == UIPage.Instance_Class.FullName + "[]")).Name = nameof(menuRootPages);
                    if (field == null)
                        return;
                }
                field.SetValue(ptr, value.Select(x => x.ptr).ArrayToIntPtr(UIPage.Instance_Class));
            }
        }

        public unsafe IL2Dictionary<string, UIPage> _uiPages
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(_uiPages));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith("System.Collections.Generic.Dictionary"))).Name = nameof(_uiPages);
                    if (field == null)
                        return null;
                }
                return new IL2Dictionary<string, UIPage>(field.GetValue(ptr).ptr);
            }
            set
            {

                IL2Field field = Instance_Class.GetField(nameof(_uiPages));
                if (field == null)
                {
                    (field = Instance_Class.GetField(x => x.ReturnType.Name.StartsWith("System.Collections.Generic.Dictionary"))).Name = nameof(_uiPages);
                    if (field == null)
                        return;
                }
                field.SetValue(ptr, value.ptr);
            }
        }

        public static new IL2Class Instance_Class = Assembler.list["VRC.UI.Elements"].GetClasses().FirstOrDefault(y => y.FullName == UIMenu.Instance_Class.GetProperties().FirstOrDefault(x => x.GetSetMethod() == null).GetGetMethod().ReturnType.Name);
    }
}