using System;
using BlazeIL;
using BlazeIL.il2cpp;
using VRC.SDKBase;

public class VRC_EventDispatcherRFC : IL2Base
{
    public VRC_EventDispatcherRFC(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public VRC_EventDispatcherRFC() : base(IntPtr.Zero)
    {
        ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
        Instance_Class.GetConstructor().Invoke(ptr);
    }

    public void TriggerEvent(VRC_EventHandler handler, VRC_EventHandler.VrcEvent e, VRC_EventHandler.VrcBroadcastType broadcast, int instagatorId, float fastForward)
    {
        Instance_Class.GetMethod("TriggerEvent").Invoke(ptr, new IntPtr[] { handler.ptr, e.ptr, broadcast.MonoCast(), instagatorId.MonoCast(), fastForward.MonoCast() });
    }

    public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRC_EventDispatcherRFC");
}
