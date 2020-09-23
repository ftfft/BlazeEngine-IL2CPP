using System;
using UnityEngine;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;

public class PortalInternal : MonoBehaviour
{
    public PortalInternal(IntPtr ptr) : base(ptr) => base.ptr = ptr;


    private static IL2Method methodOnDestroy = null;
    public void OnDestroy()
    {
        if (!IL2Get.Method("OnDestroy", Instance_Class, ref methodOnDestroy))
            return;

        methodOnDestroy.Invoke(ptr);
    }
    private static IL2Method methodSetTimerRPC = null;
    public void SetTimerRPC(float timer, VRC.Player player)
    {
        if (!IL2Get.Method("SetTimerRPC", Instance_Class, ref methodSetTimerRPC))
            return;

        methodSetTimerRPC.Invoke(ptr, new IntPtr[] { timer.MonoCast(), player.ptr });
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("PortalInternal");
}
