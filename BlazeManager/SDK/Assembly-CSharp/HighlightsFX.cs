using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

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
            return property.GetGetMethod().Invoke()?.unbox<HighlightsFX>();
        }
    }

    public void EnableOutline(Renderer renderer, bool isEnabled)
    {
        IL2Method method = Instance_Class.GetMethod(nameof(EnableOutline));
        if (method == null)
            (method = Instance_Class.GetMethod(x => !x.IsStatic && x.GetParameters().Length == 2)).Name = nameof(EnableOutline);

        method.Invoke(ptr, new IntPtr[] { renderer.ptr, isEnabled.MonoCast() });
    }

    public Material m_Material
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(m_Material));
            if (field == null)
                (field = Instance_Class.GetField(Material.Instance_Class)).Name = nameof(m_Material);
            return field.GetValue(ptr)?.unbox<Material>();
        }
        set
        {
            IL2Field field = Instance_Class.GetField(nameof(m_Material));
            if (field == null)
                (field = Instance_Class.GetField(Material.Instance_Class)).Name = nameof(m_Material);
            field.SetValue(ptr, value.ptr);
        }
    }

    public static new IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().FirstOrDefault(x => x.IsAbstract && x.GetProperty(y => y.Instance) != null && x.GetMethod("OnDestroy") != null && x.GetMethod("Awake") != null && x.GetField(Material.Instance_Class) != null);
}