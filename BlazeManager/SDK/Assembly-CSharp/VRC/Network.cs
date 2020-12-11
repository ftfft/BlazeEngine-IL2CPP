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
        public static DateTime _networkDateTime
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(_networkDateTime));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(DateTime).FullName)).Name = nameof(_networkDateTime);
                IL2Object result = field?.GetValue();
                if (result == null)
                    return default;
                return result.unbox_Unmanaged<DateTime>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(_networkDateTime));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(DateTime).FullName)).Name = nameof(_networkDateTime);
                field?.SetValue(value.MonoCast());
            }
        }

        public static double CalculateServerDeltaTime(double timeInSeconds, double previousTimeInSeconds)
        {
            if (methodCalculateServerDeltaTime == null)
            {
                methodCalculateServerDeltaTime = Instance_Class.GetMethods().First(
                    x =>
                        x.ReturnType.Name == typeof(double).FullName &&
                        x.GetParameters().Length == 2
                );
                if (methodCalculateServerDeltaTime == null)
                    return default;
            }
            return methodCalculateServerDeltaTime.Invoke(IntPtr.Zero, new IntPtr[] { timeInSeconds.MonoCast(), previousTimeInSeconds.MonoCast() }).unbox_Unmanaged<double>();
        }

        public static double GetOwnershipTransferTime(GameObject go)
        {
            if (methodGetOwnershipTransferTime == null)
            {

                methodGetOwnershipTransferTime = Instance_Class.GetMethods().First(
                    x =>
                        x.ReturnType.Name == typeof(double).FullName &&
                        x.GetParameters().Length == 1 &&
                        x.GetParameters()[0].ReturnType.Name == GameObject.Instance_Class.FullName
                );
                if (methodGetOwnershipTransferTime == null)
                    return default;
            }
            return methodGetOwnershipTransferTime.Invoke(IntPtr.Zero, new IntPtr[] { go.ptr }).unbox_Unmanaged<double>();
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
                        x.GetParameters()[1].ReturnType.Name == typeof(string).FullName &&
                        x.GetParameters()[2].ReturnType.Name == "UnityEngine.SendMessageOptions" &&
                        x.GetParameters()[3].ReturnType.Name == typeof(object).FullName &&
                        x.ReturnType.Name == typeof(void).FullName
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
            
            return new GameObject(result);
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
                        x.GetParameters()[2].ReturnType.Name == typeof(string).FullName &&
                        x.GetParameters()[3].ReturnType.Name == typeof(object[]).FullName
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
                        x.GetParameters()[3].ReturnType.Name == typeof(string).FullName &&
                        x.GetParameters()[4].ReturnType.Name == typeof(byte[]).FullName &&
                        x.ReturnType.Name == typeof(bool).FullName &&
                        x.IsPublic
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
                        x.IsPrivate
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

        private static IL2Method methodSetOwner = null;
        public static bool SetOwner(Player player, GameObject obj, Network.OwnershipModificationType modificationType = Network.OwnershipModificationType.Request, bool skipOwnerTest = false)
        {
            if (methodSetOwner == null)
            {
                methodSetOwner = Instance_Class.GetMethods().FirstOrDefault(x => x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == Player.Instance_Class.FullName && x.GetParameters()[1].ReturnType.Name == GameObject.Instance_Class.FullName);
                if (methodSetOwner == null)
                    return default;
            }
            IL2Object result = methodSetOwner.Invoke(new IntPtr[] { player.ptr, obj.ptr, modificationType.MonoCast(), skipOwnerTest.MonoCast() });
            if (result == null)
                return default;

            return result.unbox_Unmanaged<bool>();
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

        // Token: 0x02000CA2 RID: 3234
        public enum OwnershipModificationType
        {
            Request,
            Collision,
            Pickup,
            Destroy,
            Serialization
        }


        private static IL2Method methodCalculateServerDeltaTime,
                                 methodGetOwnershipTransferTime,
                                 methodTriggerEvent,
                                 methodSendMessageToChildren,
                                 methodInstantiate,
                                 methodRPC,
                                 methodRPCToTargetEncrypt,
                                 methodRPCToTarget;


        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.assemblycsharp]].GetClasses().Where(x => !x.Name.StartsWith("ObjectInstantiator") && !x.HasFlag(IL2BindingFlags.TYPE_INTERFACE)).Where(x => x.GetMethods().Where(y => y.ReturnType.Name == "ObjectInstantiator").Count() > 0).First();
    }
}