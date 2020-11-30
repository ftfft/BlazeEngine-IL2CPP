using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlazeTools;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using ExitGames.Client.Photon;
using Photon.Realtime;

public class RaiseEventOptions : IL2Base
{
    public RaiseEventOptions(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    public static IL2Method constructRaiseEventOptions = null;
    public RaiseEventOptions() : base(IntPtr.Zero)
    {
        if (constructRaiseEventOptions == null)
        {
            constructRaiseEventOptions = Instance_Class.GetMethod(".ctor");
            if (constructRaiseEventOptions == null)
                return;
        }

        ptr = IL2Import.il2cpp_object_new(Instance_Class.ptr);
        constructRaiseEventOptions.Invoke(ptr);
    }

    private static IL2Field fieldCachingOption = null;
    public EventCaching CachingOption
    {
        get
        {
            if (fieldCachingOption == null)
            {
                fieldCachingOption = Instance_Class.GetFields().First(x => x.Token == 0x10);
                if (fieldCachingOption == null)
                    return 0;
            }
            return (EventCaching)fieldCachingOption.GetValue(ptr).MonoCast<int>();
        }
        set
        {
            if (fieldCachingOption == null)
            {
                fieldCachingOption = Instance_Class.GetFields().First(x => x.Token == 0x10);
                if (fieldCachingOption == null)
                    return;
            }
            fieldCachingOption.SetValue(ptr, value.MonoCast());
        }
    }

    private static IL2Field fieldInterestGroup = null;
    public byte InterestGroup
    {
        get
        {
            if (fieldInterestGroup == null)
            {
                fieldInterestGroup = Instance_Class.GetFields().First(x => x.Token == 0x11);
                if (fieldInterestGroup == null)
                    return 0;
            }
            return fieldInterestGroup.GetValue(ptr).MonoCast<byte>();
        }
        set
        {
            if (fieldInterestGroup == null)
            {
                fieldInterestGroup = Instance_Class.GetFields().First(x => x.Token == 0x11);
                if (fieldInterestGroup == null)
                    return;
            }
            fieldInterestGroup.SetValue(ptr, value.MonoCast());
        }
    }

    private static IL2Field fieldTargetActors = null;
    unsafe public int[] TargetActors
    {
        get
        {
            if (fieldTargetActors == null)
            {
                fieldTargetActors = Instance_Class.GetFields().First(x => x.Token == 0x18);
                if (fieldTargetActors == null)
                    return null;
            }

            IL2Object obj = fieldTargetActors.GetValue(ptr);
            if (obj == null)
                return new int[0];
            return Execute.IntPtrToArray<int>(obj.ptr, *((uint*)obj.ptr + 3));

        }
        set
        {
            if (fieldTargetActors == null)
            {
                fieldTargetActors = Instance_Class.GetFields().First(x => x.Token == 0x18);
                if (fieldTargetActors == null)
                    return;
            }

            IntPtr[] arrayPtr = new IntPtr[value.Length];
            for (int i = 0; i < value.Length; i++)
                arrayPtr[i] = IL2Import.CreateNewObject(value[i], IL2SystemClass.Int32);

            fieldTargetActors.SetValue(ptr, arrayPtr.ArrayToIntPtr(IL2SystemClass.Int32));
        }
    }
    unsafe public IntPtr[] TargetActorts_Pointer
    {
        get
        {
            if (fieldTargetActors == null)
            {
                fieldTargetActors = Instance_Class.GetFields().First(x => x.Token == 0x18);
                if (fieldTargetActors == null)
                    return null;
            }

            IL2Object obj = fieldTargetActors.GetValue(ptr);
            if (obj == null)
                return new IntPtr[0];
            return obj.UnboxArray();

        }
        set
        {
            if (fieldTargetActors == null)
            {
                fieldTargetActors = Instance_Class.GetFields().First(x => x.Token == 0x18);
                if (fieldTargetActors == null)
                    return;
            }

            IntPtr[] arrayPtr = new IntPtr[value.Length];
            for (int i = 0; i < value.Length; i++)
                arrayPtr[i] = IL2Import.CreateNewObject(value[i], IL2SystemClass.Int32);

            fieldTargetActors.SetValue(ptr, arrayPtr.ArrayToIntPtr(IL2SystemClass.Int32));
        }
    }

    private static IL2Field fieldReceivers = null;
    public ReceiverGroup Receivers
    {
        get
        {
            if (fieldReceivers == null)
            {
                fieldReceivers = Instance_Class.GetFields().First(x => x.Token == 0x20);
                if (fieldReceivers == null)
                    return 0;
            }
            return (ReceiverGroup)fieldReceivers.GetValue(ptr).MonoCast<int>();
        }
        set
        {
            if (fieldReceivers == null)
            {
                fieldReceivers = Instance_Class.GetFields().First(x => x.Token == 0x20);
                if (fieldReceivers == null)
                    return;
            }
            fieldReceivers.SetValue(ptr, value.MonoCast());
        }
    }
    public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass(LoadBalancingClient.Instance_Class?.GetMethods(x => x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == "System.Byte").First().GetParameters()[2].ReturnType.Name);
}
