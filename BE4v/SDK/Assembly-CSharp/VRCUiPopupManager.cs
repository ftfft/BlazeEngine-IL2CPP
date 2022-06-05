using System;
using System.Linq;
using BE4v.SDK.CPP2IL;
using UnityEngine;
using UnityEngine.UI;

public class VRCUiPopupManager : MonoBehaviour
{
    public VRCUiPopupManager(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    unsafe static VRCUiPopupManager()
    {
        IL2Method method = null;
        IL2Method[] methods = Instance_Class.GetMethods(x =>
            x.ReturnType.Name == typeof(void).FullName
        );
        var instructions = UiInputField.Instance_Class.GetMethod("PressEdit").GetDisassembler(0x256).Disassemble();
        foreach(var instruction in instructions)
        {
            if (instruction.Mnemonic == SharpDisasm.Udis86.ud_mnemonic_code.UD_Icall)
            {
                IntPtr addr = new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);
                if ((method = methods.FirstOrDefault(x => *(IntPtr*)x.ptr == addr)) != null)
                    continue;
            }
        }
        var parameters = method.GetParameters();
        if (parameters.Length != 12)
        {
            "VRCUiPopupManager::ShowUnityInputPopupWithCancel".RedPrefix("Failed");

        }
        else
        {
            method.Name = nameof(ShowUnityInputPopupWithCancel);
        }
        for (int i=0;i< parameters.Length;i++)
        {
            parameters[i].ReturnType.Name.RedPrefix("" + i);
        } 
    }

    public static VRCUiPopupManager Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property.GetGetMethod().Invoke().GetValue<VRCUiPopupManager>();
        }
    }

    unsafe public void ShowAlert(string title, string body, float timeout = 10f)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(ShowAlert));
        if (method == null)
            (method = Instance_Class.GetMethods(x => x.GetParameters().Length == 3 && x.GetParameters()[2].ReturnType.Name == typeof(float).FullName).First(x => x.GetDisassembler().Disassemble().Count() == 1010)).Name = nameof(ShowAlert);
        method.Invoke(ptr, new IntPtr[] { new IL2String(title).ptr, new IL2String(body).ptr, new IntPtr(&timeout) });
    }

    /*
[0] System.String
[1] System.String
[2] UnityEngine.UI.InputField.InputType
[3] System.Boolean
[4] System.String
[5] System.Action<System.String,System.Collections.Generic.List<UnityEngine.KeyCode>,UnityEngine.UI.Text>
[6] System.Action
[7] System.String
[8] System.Boolean
[9] System.Action<VRCUiPopup>
[10] System.Boolean
[11] System.Int32
     */
    unsafe public void ShowUnityInputPopupWithCancel(
        string title,
        string body,
        InputField.InputType inputType,
        bool useNumericKeypad,
        string submitButtonText,
        Action<string, IL2List<KeyCode>, Text> submitButtonAction,
        Action cancelButtonAction,
        string placeholderText = "Enter text....",
        bool hidePopupOnSubmit = true,
        Action<VRCUiPopup> additionalSetup = null,
        bool nanBool = false,
        int nanInt32 = 0
    )
    {
        IL2Method method = Instance_Class.GetMethod(nameof(ShowUnityInputPopupWithCancel));
        if (method == null)
        {
            "Method not found!".RedPrefix("VRCUiPopupManager::ShowUnityInputPopupWithCancel");
            return;
        }
        IL2Delegate _submitButtonAction = null;
        IL2Delegate _cancelButtonAction = null; // IL2Delegate.CreateDelegate(cancelButtonAction);
        IL2Delegate _additionalSetup = null;
        method.Invoke(ptr, new IntPtr[] {
            new IL2String(title).ptr, // string
            new IL2String(body).ptr, //  string
            new IntPtr(&inputType), // InputType : int
            new IntPtr(&useNumericKeypad), // bool
            new IL2String(submitButtonText).ptr, // string
            _submitButtonAction == null ? IntPtr.Zero : _submitButtonAction.ptr, // Action<string, IL2List<KeyCode>, Text>
            _cancelButtonAction == null ? IntPtr.Zero : _cancelButtonAction.ptr, // Action
            new IL2String(placeholderText).ptr, // string Default: "Enter text...."
            new IntPtr(&hidePopupOnSubmit), // bool Default: true
            _additionalSetup == null ? IntPtr.Zero :_additionalSetup.ptr, // Action<VRCUiPopup> Default: null
            new IntPtr(&nanBool), // bool Default: false
            new IntPtr(&nanInt32) // bool Default: 0
        });
    }

    public static new IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FindClass_ByMethodName("ShowControllerBindingsPopup");

    public enum inputStyle
    {
        Javascript,
        Unity
    }
}