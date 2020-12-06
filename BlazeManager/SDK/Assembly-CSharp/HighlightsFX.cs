using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using SharpDisasm;
using SharpDisasm.Udis86;

public class HighlightsFX : PostEffectsBase
{
    public HighlightsFX(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static HighlightsFX Instance
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(Instance));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.Instance)).Name = nameof(Instance);
            return property?.GetGetMethod().Invoke()?.unbox<HighlightsFX>();
        }
    }

    public void EnableOutline(Renderer renderer, bool isEnabled)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(EnableOutline));
        if (method == null)
            (method = Instance_Class.GetMethod(x => !x.IsStatic && x.GetParameters().Length == 2)).Name = nameof(EnableOutline);

        method?.Invoke(ptr, new IntPtr[] { renderer.ptr, isEnabled.MonoCast() });
    }

    public Material m_Material
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(m_Material));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == Material.Instance_Class.FullName)).Name = nameof(m_Material);
            return field?.GetValue(ptr)?.unbox<Material>();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(m_Material));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == Material.Instance_Class.FullName)).Name = nameof(m_Material);
            field?.SetValue(ptr, value.ptr);
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("HighlightsFX");
}