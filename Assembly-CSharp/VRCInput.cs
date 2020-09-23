using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using BlazeIL.il2cpp;
using UnityEngine;
using VRC.Core;

unsafe public class VRCInput : IL2Base
{
    public VRCInput(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    private static IL2Property propertyName = null;
    public string name
    {
        get
        {
            if (propertyName == null)
            {
                propertyName = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "System.String");
                if (propertyName == null)
                    return string.Empty;
            }
            return propertyName.GetGetMethod().Invoke(ptr).UnboxString();
        }
    }

    public bool down
    {
        get
        {
            return bValue && !bValuePrev;
        }
    }

    public bool up
    {
        get
        {
            return !bValue && bValuePrev;
        }
    }

    public bool button
    {
        get
        {
            return bValue;
        }
    }

    public void Reset()
    {
        if (!bValue)
        {
            timePressed = 0f;
        }
        bValuePrev = bValue;
        bValue = false;
        fValue = 0f;
    }


    private static IL2Field fieldTimePressed = null;
    public float timePressed
    {
        get
        {
            if (fieldTimePressed == null)
            {
                fieldTimePressed = Instance_Class.GetFields().First(x => x.token == 0x18);
                if (fieldTimePressed == null)
                    return default;
            }

            IL2Object result = fieldTimePressed.GetValue(ptr);
            if (result == null)
                return default;

            return *(float*)result.Unbox();
        }
        set
        {
            if (fieldTimePressed == null)
            {
                fieldTimePressed = Instance_Class.GetFields().First(x => x.token == 0x18);
                if (fieldTimePressed == null)
                    return;
            }
            fieldTimePressed.SetValue(ptr, new IntPtr(&value));
        }
    }
    
    private static IL2Field fieldLastDownTime = null;
    public float lastDownTime
    {
        get
        {
            if (fieldLastDownTime == null)
            {
                fieldLastDownTime = Instance_Class.GetFields().First(x => x.token == 0x28);
                if (fieldLastDownTime == null)
                    return default;
            }

            IL2Object result = fieldLastDownTime.GetValue(ptr);
            if (result == null)
                return default;

            return *(float*)result.Unbox();
        }
        set
        {
            if (fieldLastDownTime == null)
            {
                fieldLastDownTime = Instance_Class.GetFields().First(x => x.token == 0x28);
                if (fieldLastDownTime == null)
                    return;
            }
            fieldLastDownTime.SetValue(ptr, new IntPtr(&value));
        }
    }
    
    private static IL2Field fieldLastUpTime = null;
    public float lastUpTime
    {
        get
        {
            if (fieldLastUpTime == null)
            {
                fieldLastUpTime = Instance_Class.GetFields().First(x => x.token == 0x2C);
                if (fieldLastUpTime == null)
                    return default;
            }

            IL2Object result = fieldLastUpTime.GetValue(ptr);
            if (result == null)
                return default;

            return *(float*)result.Unbox();
        }
        set
        {
            if (fieldLastUpTime == null)
            {
                fieldLastUpTime = Instance_Class.GetFields().First(x => x.token == 0x2C);
                if (fieldLastUpTime == null)
                    return;
            }
            fieldLastUpTime.SetValue(ptr, new IntPtr(&value));
        }
    }
    
    private static IL2Field fieldFValue = null;
    public float fValue
    {
        get
        {
            if (fieldFValue == null)
            {
                fieldFValue = Instance_Class.GetFields().First(x => x.token == 0x30);
                if (fieldFValue == null)
                    return default;
            }

            IL2Object result = fieldFValue.GetValue(ptr);
            if (result == null)
                return default;

            return *(float*)result.Unbox();
        }
        set
        {
            if (fieldFValue == null)
            {
                fieldFValue = Instance_Class.GetFields().First(x => x.token == 0x30);
                if (fieldFValue == null)
                    return;
            }
            fieldLastUpTime.SetValue(ptr, new IntPtr(&value));
        }
    }

    // 0x34
    private static IL2Field fieldValue = null;
    public bool bValue
    {
        get
        {
            if (fieldValue == null)
            {
                fieldValue = Instance_Class.GetFields().First(x => x.token == 0x34);
                if (fieldValue == null)
                    return default;
            }

            IL2Object result = fieldValue.GetValue(ptr);
            if (result == null)
                return default;

            return *(bool*)result.Unbox();
        }
        set
        {
            if (fieldValue == null)
            {
                fieldValue = Instance_Class.GetFields().First(x => x.token == 0x34);
                if (fieldValue == null)
                    return;
            }
            fieldValue.SetValue(ptr, new IntPtr(&value));
        }
    }

    private static IL2Field fieldValuePrev = null;
    public bool bValuePrev
    {
        get
        {
            if (fieldValuePrev == null)
            {
                fieldValuePrev = Instance_Class.GetFields().First(x => x.token == 0x35);
                if (fieldValuePrev == null)
                    return false;
            }

            IL2Object result = fieldValuePrev.GetValue(ptr);
            if (result == null)
                return default;

            return *(bool*)result.Unbox();
        }
        set
        {
            if (fieldValuePrev == null)
            {
                fieldValuePrev = Instance_Class.GetFields().First(x => x.token == 0x35);
                if (fieldValuePrev == null)
                    return;
            }
            fieldValuePrev.SetValue(ptr, new IntPtr(&value));

        }
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(VRCInput))
            return false;
        return ((VRCInput)obj).ptr == ptr;
    }

    public override int GetHashCode() =>
        ptr.GetHashCode();

    public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass(PlayerModComponentJump.Instance_Class.GetFields().First(x => x.GetReturnType().Name.Length > 64).GetReturnType().Name);
}