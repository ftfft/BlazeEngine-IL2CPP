using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;

public class VRCInput : IL2Base
{
    public VRCInput(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public string name
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(name));
            if (property == null)
                (property = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == typeof(string).FullName)).Name = nameof(name);
            return property.GetGetMethod().Invoke(ptr)?.unbox_ToString().ToString();
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
                fieldTimePressed = Instance_Class.GetFields().First(x => x.Token == 0x18);
                if (fieldTimePressed == null)
                    return default;
            }

            return fieldTimePressed.GetValue(ptr).Unbox<float>();
        }
        set
        {
            if (fieldTimePressed == null)
            {
                fieldTimePressed = Instance_Class.GetFields().First(x => x.Token == 0x18);
                if (fieldTimePressed == null)
                    return;
            }
            fieldTimePressed.SetValue(ptr, value.MonoCast());
        }
    }
    
    private static IL2Field fieldLastDownTime = null;
    public float lastDownTime
    {
        get
        {
            if (fieldLastDownTime == null)
            {
                fieldLastDownTime = Instance_Class.GetFields().First(x => x.Token == 0x28);
                if (fieldLastDownTime == null)
                    return default;
            }

            return fieldLastDownTime.GetValue(ptr).Unbox<float>();
        }
        set
        {
            if (fieldLastDownTime == null)
            {
                fieldLastDownTime = Instance_Class.GetFields().First(x => x.Token == 0x28);
                if (fieldLastDownTime == null)
                    return;
            }
            fieldLastDownTime.SetValue(ptr, value.MonoCast());
        }
    }
    
    private static IL2Field fieldLastUpTime = null;
    public float lastUpTime
    {
        get
        {
            if (fieldLastUpTime == null)
            {
                fieldLastUpTime = Instance_Class.GetFields().First(x => x.Token == 0x2C);
                if (fieldLastUpTime == null)
                    return default;
            }

            return fieldLastUpTime.GetValue(ptr).Unbox<float>();
        }
        set
        {
            if (fieldLastUpTime == null)
            {
                fieldLastUpTime = Instance_Class.GetFields().First(x => x.Token == 0x2C);
                if (fieldLastUpTime == null)
                    return;
            }
            fieldLastUpTime.SetValue(ptr, value.MonoCast());
        }
    }
    
    private static IL2Field fieldFValue = null;
    public float fValue
    {
        get
        {
            if (fieldFValue == null)
            {
                fieldFValue = Instance_Class.GetFields().First(x => x.Token == 0x30);
                if (fieldFValue == null)
                    return default;
            }

            return fieldFValue.GetValue(ptr).Unbox<float>();
        }
        set
        {
            if (fieldFValue == null)
            {
                fieldFValue = Instance_Class.GetFields().First(x => x.Token == 0x30);
                if (fieldFValue == null)
                    return;
            }
            fieldLastUpTime.SetValue(ptr, value.MonoCast());
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
                fieldValue = Instance_Class.GetFields().First(x => x.ReturnType.Name == typeof(bool).FullName);
                if (fieldValue == null)
                    return default;
            }

            return fieldValue.GetValue(ptr).Unbox<bool>();
        }
        set
        {
            if (fieldValue == null)
            {
                fieldValue = Instance_Class.GetFields().First(x => x.ReturnType.Name == typeof(bool).FullName);
                if (fieldValue == null)
                    return;
            }
            fieldValue.SetValue(ptr, value.MonoCast());
        }
    }

    private static IL2Field fieldValuePrev = null;
    public bool bValuePrev
    {
        get
        {
            if (fieldValuePrev == null)
            {
                fieldValuePrev = Instance_Class.GetFields().Last(x => x.ReturnType.Name == typeof(bool).FullName);
                if (fieldValuePrev == null)
                    return false;
            }

            return fieldValuePrev.GetValue(ptr).Unbox<bool>();
        }
        set
        {
            if (fieldValuePrev == null)
            {
                fieldValuePrev = Instance_Class.GetFields().Last(x => x.ReturnType.Name == typeof(bool).FullName);
                if (fieldValuePrev == null)
                    return;
            }
            fieldValuePrev.SetValue(ptr, value.MonoCast());

        }
    }

    public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass(LocomotionInputController.Instance_Class.GetFields().First(x => x.ReturnType.Name.Length > 64).ReturnType.Name);
}