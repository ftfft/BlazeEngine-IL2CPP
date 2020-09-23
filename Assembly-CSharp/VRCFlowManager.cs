using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;

unsafe public class VRCFlowManager : Component
{
    public VRCFlowManager(IntPtr ptrNew) : base(ptrNew) =>
        ptr = ptrNew;

    private static IL2Property propertyInstance = null;
    public static VRCFlowManager Instance
    {
        get
        {
            if (propertyInstance == null)
            {
                propertyInstance = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "VRCFlowManager");
                if (propertyInstance == null)
                    return null;
            }

            IL2Object result = null;
            result = propertyInstance.GetGetMethod().Invoke();
            if (result == null)
                return null;

            return result.ptr.MonoCast<VRCFlowManager>();
        }
    }

    private static IL2Method methodEnterWorld = null;
    public void EnterWorld(string WorldId) => EnterWorld(WorldId, null);
    public void EnterWorld(string WorldId, string InstanceID)
    {
        if(methodEnterWorld == null)
        {
            methodEnterWorld = Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 5).First(x => IL2Import.il2cpp_type_get_name(x.GetParameters()[3].ptr) == "System.Action<System.String>");
            if (methodEnterWorld == null)
                return;
        }
        if (ptr == IntPtr.Zero)
            return;

        if(string.IsNullOrEmpty(InstanceID))
        {
            string[] array = WorldId.Split(new char[]
            {
            ':'
            });
            if (array.Length != 2)
                return;

            WorldId = array[0];
            InstanceID = array[1];
        }

        bool arg5 = false;
        methodEnterWorld.Invoke(ptr, new IntPtr[] {
            IL2Import.StringToIntPtr(WorldId),
            IL2Import.il2cpp_string_new_len(InstanceID, InstanceID.Length),
            IL2Import.ObjectToIntPtr(null),
            IL2Import.ObjectToIntPtr(null),
            new IntPtr(&arg5)
        });
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != typeof(VRCFlowManager))
            return false;
        return ((VRCFlowManager)obj).ptr == ptr;
    }

    public override int GetHashCode() =>
        ptr.GetHashCode();

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCFlowManager");
}