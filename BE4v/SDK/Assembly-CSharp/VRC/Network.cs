using BE4v.SDK.CPP2IL;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;
using VRC.SDKBase;

namespace VRC
{
    public static class Network
    {
        unsafe public static DateTime _networkDateTime
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(_networkDateTime));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(DateTime).FullName)).Name = nameof(_networkDateTime);
                return field.GetValue().GetValuå<DateTime>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(_networkDateTime));
                if (field == null)
                    (field = Instance_Class.GetField(x => x.ReturnType.Name == typeof(DateTime).FullName)).Name = nameof(_networkDateTime);
                field?.SetValue(new IntPtr(&value));
            }
        }

        unsafe public static double CalculateServerDeltaTime(double timeInSeconds, double previousTimeInSeconds)
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
            return methodCalculateServerDeltaTime.Invoke(new IntPtr[] { new IntPtr(&timeInSeconds), new IntPtr(&previousTimeInSeconds) }).GetValuå<double>();
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
            return methodGetOwnershipTransferTime.Invoke(new IntPtr[] { go.ptr }).GetValuå<double>();
        }

        /*
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
        */
        unsafe public static GameObject Instantiate(VRC_EventHandler.VrcBroadcastType broadcast, string prefabPathOrDynamicPrefabName, Vector3 position, Quaternion rotation)
        {
            IntPtr result = Instantiate(
                new IntPtr(&broadcast),
                new IL2String(prefabPathOrDynamicPrefabName).ptr,
                new IntPtr(&position),
                new IntPtr(&rotation)
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

        unsafe public static void RPC(VRC_EventHandler.VrcTargetType targetClients, GameObject targetObject, string methodName, IntPtr[] parameters)
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
                new IntPtr(&targetClients),
                targetObject.ptr,
                new IL2String(methodName).ptr,
                parameters.ArrayToIntPtr()
            });
        }

        unsafe public static bool SetOwner(Player player, GameObject obj, Network.OwnershipModificationType modificationType = Network.OwnershipModificationType.Request, bool skipOwnerTest = false)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(SetOwner));
            if (method == null)
                (method = Instance_Class.GetMethods().FirstOrDefault(x => x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == Player.Instance_Class.FullName && x.GetParameters()[1].ReturnType.Name == GameObject.Instance_Class.FullName)).Name = nameof(SetOwner);
            IL2Object result = method.Invoke(new IntPtr[] { player.ptr, obj.ptr, new IntPtr(&modificationType), new IntPtr(&skipOwnerTest) });
            if (result == null)
                return default;

            return result.GetValuå<bool>();
        }

        public static ObjectInstantiator Instantiator
        {
            get
            {
                IL2Field field = Instance_Class.GetField(nameof(Instantiator));
                if (field == null)
                    (field = Instance_Class.GetField(ObjectInstantiator.Instance_Class)).Name = nameof(Instantiator);
                return field.GetValue()?.GetValue<ObjectInstantiator>();
            }
            set
            {
                IL2Field field = Instance_Class.GetField(nameof(Instantiator));
                if (field == null)
                    (field = Instance_Class.GetField(ObjectInstantiator.Instance_Class)).Name = nameof(Instantiator);
                field.SetValue(value.ptr);
            }
        }

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


        public static IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod(y => y.ReturnType.Name == ObjectInstantiator.Instance_Class.FullName) != null && x.BaseType?.FullName != MonoBehaviour.Instance_Class.FullName);
    }
}