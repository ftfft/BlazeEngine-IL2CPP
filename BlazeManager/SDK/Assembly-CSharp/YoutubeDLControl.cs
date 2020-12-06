using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;

public class YoutubeDLControl : MonoBehaviour
{
    public YoutubeDLControl(IntPtr ptr) : base(ptr) => base.ptr = ptr;


    public static YoutubeDLControl Instance
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(Instance));
            if (field == null)
                (field = Instance_Class.GetFields().First(x => x.Instance)).Name = nameof(Instance);
            return field.GetValue()?.unbox<YoutubeDLControl>();
        }
    }

    public string YoutubeDLVersion
    {
        get => Instance_Class.GetField(nameof(YoutubeDLVersion)).GetValue(ptr)?.unbox_ToString().ToString();
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("YoutubeDLControl");
}