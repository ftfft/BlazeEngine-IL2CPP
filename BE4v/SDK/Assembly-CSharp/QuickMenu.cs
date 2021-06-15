using System;
using System.Linq;
using UnityEngine;
using VRC.Core;
using BE4v.SDK.CPP2IL;
using UnityEngine.UI;
using System.CodeDom;

public class QuickMenu : MonoBehaviour
{
    public QuickMenu(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    unsafe static QuickMenu()
    {
        Instance_Class = Assembler.list["acs"].GetClasses()
        .FirstOrDefault(x =>
            x.GetProperty(y => y.Instance) != null &&
            x.GetField(APIUser.Instance_Class) != null &&
            x.GetField(VRC.Player.Instance_Class) != null &&
            x.GetFields(y => y.ReturnType.Name == GameObject.Instance_Class.FullName).Length > 9 &&
            x.GetFields(y => y.ReturnType.Name == "UnityEngine.Vector3").Length > 5
        );
        if (Instance_Class == null)
        {
            throw new Exception("[QuickMenu] InstanceClass not found!");
        }
        //
        /* * * SetMenuIndex * * */
        //
        IL2Method method = Instance_Class.GetMethod(nameof(SetMenuIndex));
        if (method == null)
        {
            var instructions = VRCUiAvatarStatsPanel.Instance_Class.GetMethod("BackPressed").GetDisassembler(0x128).Disassemble().Where(x => x.Mnemonic == SharpDisasm.Udis86.ud_mnemonic_code.UD_Ijmp);
            foreach (var instruction in instructions)
            {
                IntPtr addr = new IntPtr((long)instruction.Offset + instruction.Length + instruction.Operands[0].LvalSDWord);
                method = Instance_Class.GetMethod(x => !x.IsStatic && x.GetParameters().Length == 1 && *(IntPtr*)x.ptr == addr);
                if (method != null)
                {
                    method.Name = nameof(SetMenuIndex);
                    break;
                }
            }
        }
        //
        /* * * _currentMenu * * */
        //
        IL2Field field = Instance_Class.GetField(nameof(_currentMenu));
        if (field == null)
        {
            var instructions = Instance_Class.GetMethod(nameof(SetMenuIndex)).GetDisassembler(0x128).Disassemble();
            int iCount = 0;
            foreach (var instruction in instructions)
            {
                if (instruction.Mnemonic == SharpDisasm.Udis86.ud_mnemonic_code.UD_Imov)
                {
                    if (++iCount == 2)
                    {
                        var resultToken = Convert.ToInt32(instruction.ToString().Split('+').LastOrDefault().Replace("]", ""), 16);
                        field = Instance_Class.GetField(x => !x.IsStatic && x.ReturnType.Name == GameObject.Instance_Class.FullName && x.Token == resultToken);
                        if (field != null)
                            field.Name = nameof(_currentMenu);
                        break;
                    }
                }
                else
                    iCount = 0;
            }
        }
    }

    public static QuickMenu Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperties().First(x => x.Instance)).Name = nameof(Instance);
            return property?.GetGetMethod().Invoke()?.GetValue<QuickMenu>();
        }
    }

    public APIUser SelectedUser
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(SelectedUser));
            if (property == null)
                (property = Instance_Class.GetProperty(APIUser.Instance_Class)).Name = nameof(SelectedUser);

            return property?.GetGetMethod().Invoke(ptr)?.GetValue<APIUser>();
        }
        set
        {
            IL2Property property = Instance_Class.GetProperty(nameof(SelectedUser));
            if (property == null)
                (property = Instance_Class.GetProperty(APIUser.Instance_Class)).Name = nameof(SelectedUser);

            property?.GetSetMethod().Invoke(ptr, new IntPtr[] { value.ptr });
        }
    }

    unsafe public void SetMenuIndex(int Index)
    {
        Instance_Class.GetMethod(nameof(SetMenuIndex))?.Invoke(ptr, new IntPtr[] { new IntPtr(&Index) });
    }

    public GameObject _infoBar
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(_infoBar));
            if (field == null)
            {
                GameObject gameObject = transform.Find("_InfoBar")?.gameObject;
                if (gameObject == null) return null;
                (field = Instance_Class.GetField(x => !x.IsStatic && x.ReturnType.Name == GameObject.Instance_Class.FullName && x.GetValue(ptr).GetValue<GameObject>() == gameObject)).Name = nameof(_infoBar);
            }
            return field?.GetValue(ptr)?.GetValue<GameObject>();
        }
    }
    
    public GameObject _currentMenu
    {
        get => Instance_Class.GetField(nameof(_currentMenu))?.GetValue(ptr)?.GetValue<GameObject>();
        set => Instance_Class.GetField(nameof(_currentMenu))?.SetValue(ptr, value?.ptr ?? IntPtr.Zero);
    }

    /*
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
                        if (++iCount == 2)
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
    }*/

    public static void ChangeColorButtons(Color? backgroundColor = null, Color? textColor = null)
    {
        if (backgroundColor == null && textColor == null)
        {
            ChangeColorButtons(Color.green, Color.green);
            return;
        }

        foreach (Transform child in QuickMenu.Instance.transform)
        {
            foreach (Button button in child.gameObject.GetComponentsInChildren<Button>())
            {
                if (backgroundColor != null)
                {
                    foreach (Image background in button.gameObject.GetComponentsInChildren<Image>(true))
                    {
                        background.color = backgroundColor.Value;
                        //buttonBackgroundColor = (Color)backgroundColor;
                    }
                }
                if (textColor != null)
                {
                    foreach (Text text in button.gameObject.GetComponentsInChildren<Text>(true))
                    {
                        text.color = textColor.Value;
                        //StatusBuff.buttonTextColor = (Color)textColor;
                    }
                }
            }
        }
    }
    public static void ChangeColorMenu(Color? backgroundColor = null, Color? textColor = null)
    {
        if (backgroundColor == null && textColor == null)
        {
            ChangeColorMenu(Color.green, Color.green);
            return;
        }

        foreach (Transform child in QuickMenu.Instance.transform)
        {
            if (backgroundColor != null)
            {
                foreach (Image background in child.gameObject.GetComponentsInChildren<Image>(true))
                {
                    background.color = backgroundColor.Value;
                    // Status.colorQuickMenu_Red = (Color)backgroundColor;
                }
            }
            if (textColor != null)
            {
                foreach (Text text in child.gameObject.GetComponentsInChildren<Text>(true))
                {
                    text.color = textColor.Value;
                    // StatusBuff.menuTextColor = (Color)textColor;
                }
            }
        }
    }

    public static new IL2Class Instance_Class;
}
