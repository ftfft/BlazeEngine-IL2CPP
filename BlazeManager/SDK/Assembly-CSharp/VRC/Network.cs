using System;
using System.Linq;
using System.Reflection;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;
using VRC.SDKBase;

namespace VRC
{
    public static class Network
    {
        public static int? GetOwnerId(GameObject obj)
        {
            if (!IL2Get.Method(typeof(int?).FullName, Instance_Class, ref methodGetOwnerId, false))
                return null;

            return methodGetOwnerId.Invoke(new IntPtr[] { obj.ptr })?.unbox_Unmanaged<int>();
        }

        public static DateTime GetNetworkDateTime()
        {
            if (!IL2Get.Method(typeof(DateTime).FullName, Instance_Class, ref methodGetNetworkDateTime, false))
                return DateTime.Now;

            return methodGetNetworkDateTime.Invoke().unbox_Unmanaged<DateTime>();
        }

        public static double CalculateServerDeltaTime(double timeInSeconds, double previousTimeInSeconds)
        {
            if (methodCalculateServerDeltaTime == null)
            {
                methodCalculateServerDeltaTime = Instance_Class.GetMethods().First(
                    x =>
                        x.ReturnType.Name == "System.Double" &&
                        x.GetParameters().Length == 2
                );
                if (methodCalculateServerDeltaTime == null)
                    return default;
            }
            return methodCalculateServerDeltaTime.Invoke(IntPtr.Zero, new IntPtr[] { timeInSeconds.MonoCast(), previousTimeInSeconds.MonoCast() }).Unbox<double>();
        }

        public static double GetOwnershipTransferTime(GameObject go)
        {
            if (methodGetOwnershipTransferTime == null)
            {

                methodGetOwnershipTransferTime = Instance_Class.GetMethods().First(
                    x =>
                        x.ReturnType.Name == "System.Double" &&
                        x.GetParameters().Length == 1 &&
                        x.GetParameters()[0].ReturnType.Name == GameObject.Instance_Class.FullName
                );
                if (methodGetOwnershipTransferTime == null)
                    return default;
            }
            return methodGetOwnershipTransferTime.Invoke(IntPtr.Zero, new IntPtr[] { go.ptr }).Unbox<double>();
        }

        public static void TriggerEvent(VRC_EventHandler.VrcEvent e, VRC_EventHandler.VrcBroadcastType broadcast = VRC_EventHandler.VrcBroadcastType.AlwaysUnbuffered, int instagatorId = 0, float fastForward = 0f)
        {
            if (methodTriggerEvent == null)
            {
                methodTriggerEvent = Instance_Class.GetMethods()
                    .Where(x => x.GetParameters().Length == 4)
                    .First(x => x.GetParameters()[0].ReturnType.Name.EndsWith(".VRC_EventHandler.VrcEvent"));
                if (methodTriggerEvent == null)
                    return;
            }
            methodTriggerEvent.Invoke(IntPtr.Zero, new IntPtr[] { e.ptr, broadcast.MonoCast(), instagatorId.MonoCast(), fastForward.MonoCast() });
        }

        public static void SendMessageToChildren(GameObject obj, string message, SendMessageOptions options = SendMessageOptions.RequireReceiver, object value = null)
        {
            if (methodSendMessageToChildren == null)
            {
                methodSendMessageToChildren = Instance_Class.GetMethods().First(
                    x =>
                        x.GetParameters().Length == 4 &&
                        x.GetParameters()[0].ReturnType.Name == GameObject.Instance_Class.FullName &&
                        x.GetParameters()[1].ReturnType.Name == "System.String" &&
                        x.GetParameters()[2].ReturnType.Name == "UnityEngine.SendMessageOptions" &&
                        x.GetParameters()[3].ReturnType.Name == "System.Object" &&
                        x.ReturnType.Name == "System.Void"
                );
                if (methodSendMessageToChildren == null)
                    return;
            }
            methodSendMessageToChildren.Invoke(IntPtr.Zero, new IntPtr[] { obj.ptr, IL2Import.StringToIntPtr(message), options.MonoCast(), IL2Import.ObjectToIntPtr(value) });
        }

        public static GameObject Instantiate(VRC_EventHandler.VrcBroadcastType broadcast, string prefabPathOrDynamicPrefabName, Vector3 position, Quaternion rotation)
        {
            IntPtr result = Instantiate(
                broadcast.MonoCast(),
                IL2Import.StringToIntPtr(prefabPathOrDynamicPrefabName),
                position.MonoCast(),
                rotation.MonoCast()
            );
            if (result == IntPtr.Zero)
                return null;
            
            return result.MonoCast<GameObject>();
        }
        public static IntPtr Instantiate(IntPtr broadcast, IntPtr prefabPathOrDynamicPrefabName, IntPtr position, IntPtr rotation)
        {
            if (methodInstantiate == null)
            {
                methodInstantiate = Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 4 && x.ReturnType.Name == GameObject.Instance_Class.FullName).First();
                if (methodInstantiate == null)
                    return IntPtr.Zero;
            }

            IL2Object result = methodInstantiate.Invoke(IntPtr.Zero, new IntPtr[] {
                broadcast,
                prefabPathOrDynamicPrefabName,
                position,
                rotation
            });
            if (result == null)
                return IntPtr.Zero;

            return result.ptr;
        }

        public static void RPC(VRC_EventHandler.VrcTargetType targetClients, GameObject targetObject, string methodName, IntPtr[] parameters)
        {
            if (methodRPC == null)
            {
                methodRPC = Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 4 && x.ReturnType.Name == "System.Void").First(
                    x =>
                        x.GetParameters()[0].ReturnType.Name.EndsWith(".RPC.Destination") &&
                        x.GetParameters()[1].ReturnType.Name == GameObject.Instance_Class.FullName &&
                        x.GetParameters()[2].ReturnType.Name == "System.String" &&
                        x.GetParameters()[3].ReturnType.Name == "System.Object[]"
                );
                if (methodRPC == null)
                    return;
            }
            if (targetObject == null)
                return;

            methodRPC.Invoke(IntPtr.Zero, new IntPtr[] {
                targetClients.MonoCast(),
                targetObject.ptr,
                IL2Import.StringToIntPtr(methodName),
                parameters.ArrayToIntPtr()
            });
        }

        public static bool RPC(VRC_EventHandler.VrcTargetType targetClients, Player targetPlayer, GameObject targetObject, string methodName, byte[] parameters)
        {
            if (methodRPCToTargetEncrypt == null)
            {
                methodRPCToTargetEncrypt = Instance_Class.GetMethods().First(
                    x =>
                        x.GetParameters().Length == 5 &&
                        x.GetParameters()[0].ReturnType.Name == Player.Instance_Class.FullName &&
                        x.GetParameters()[1].ReturnType.Name == "VRCSDK2.VRC_EventHandler.VrcTargetType" &&
                        x.GetParameters()[2].ReturnType.Name == GameObject.Instance_Class.FullName &&
                        x.GetParameters()[3].ReturnType.Name == "System.String" &&
                        x.GetParameters()[4].ReturnType.Name == "System.Byte[]" &&
                        x.ReturnType.Name == "System.Boolean" &&
                        x.HasFlag(IL2BindingFlags.METHOD_PUBLIC)
                );
                if (methodRPCToTargetEncrypt == null)
                    return default;
            }
            IntPtr[] pointerArray = new IntPtr[parameters.Length];
            unsafe
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    fixed (byte* pointer = &parameters[i])
                    {
                        pointerArray[i] = new IntPtr(pointer);
                    }
                }
            }
            return default;
            // Not work
            // methodRPCToTargetEncrypt.Invoke(IntPtr.Zero, new IntPtr[] { targetPlayer.ptr, new IntPtr(&targetClients), targetObject.ptr, IL2Import.StringToIntPtr(methodName), Execute.IntPtrArrayToIntPtr(pointerArray) }).Unbox<bool>();
        }

        public static bool RPC(VRC_EventHandler.VrcTargetType targetClients, Player targetPlayer, GameObject targetObject, string methodName, object[] parameters)
        {
            if (methodRPCToTarget == null)
            {
                methodRPCToTarget = Instance_Class.GetMethods().First(
                    x =>
                        x.GetParameters().Length == 5 &&
                        x.GetParameters()[0].ReturnType.Name == Player.Instance_Class.FullName &&
                        x.GetParameters()[1].ReturnType.Name == "VRCSDK2.VRC_EventHandler.VrcTargetType" &&
                        x.GetParameters()[2].ReturnType.Name == GameObject.Instance_Class.FullName &&
                        x.GetParameters()[3].ReturnType.Name == typeof(string).FullName &&
                        x.GetParameters()[4].ReturnType.Name == typeof(object[]).FullName &&
                        x.ReturnType.Name == typeof(bool).FullName &&
                        x.HasFlag(IL2BindingFlags.METHOD_PRIVATE)
                );
                if (methodRPCToTarget == null)
                    return false;
            }
            return false;
            // Not work
            // methodRPCToTarget.Invoke(IntPtr.Zero, new IntPtr[] { targetPlayer.ptr, new IntPtr(&targetClients), targetObject.ptr, IL2Import.StringToIntPtr(methodName), Execute.IntPtrArrayToIntPtr(IL2Import.ObjectArrayToIntPtrArray(parameters)) }).Unbox<bool>();
        }

        public static void sendEventTrigger(VRC_EventHandler.VrcEvent @event, VRC_EventHandler.VrcBroadcastType broadcastType, int iInt, float fFloat = 0f)
        {
        }

        private static IL2Field fieldObjectInstantiator;
        public static ObjectInstantiator Instantiator
        {
            get
            {
                if (!IL2Get.Field(ObjectInstantiator.Instance_Class.FullName, Instance_Class, ref fieldObjectInstantiator, false))
                    return null;

                return fieldObjectInstantiator.GetValue()?.unbox<ObjectInstantiator>();
            }
            set
            {
                if (!IL2Get.Field(ObjectInstantiator.Instance_Class.FullName, Instance_Class, ref fieldObjectInstantiator, false))
                    return;

                fieldObjectInstantiator.SetValue(value.ptr);
            }
        }


        private static IL2Method methodGetOwnerId,
                                 methodGetNetworkDateTime,
                                 methodCalculateServerDeltaTime,
                                 methodGetOwnershipTransferTime,
                                 methodTriggerEvent,
                                 methodSendMessageToChildren,
                                 methodInstantiate,
                                 methodRPC,
                                 methodRPCToTargetEncrypt,
                                 methodRPCToTarget;


        public static IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClasses().Where(x => !x.Name.StartsWith("ObjectInstantiator") && !x.HasFlag(IL2BindingFlags.TYPE_INTERFACE)).Where(x => x.GetMethods().Where(y => y.ReturnType.Name == "ObjectInstantiator").Count() > 0).First();
    }
}