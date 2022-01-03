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
                return field?.GetValue().GetValu�<DateTime>() ?? default(DateTime);
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
            IL2Method method = Instance_Class.GetMethod("CalculateServerDeltaTime");
            if (method == null)
            {
                (method = Instance_Class.GetMethods().First(
                    x =>
                        x.ReturnType.Name == typeof(double).FullName &&
                        x.GetParameters().Length == 2
                )).Name = "CalculateServerDeltaTime";
                if (method == null)
                    return default;
            }
            return method.Invoke(new IntPtr[] { new IntPtr(&timeInSeconds), new IntPtr(&previousTimeInSeconds) }).GetValu�<double>();
        }

        public static double GetOwnershipTransferTime(GameObject go)
        {
            IL2Method method = Instance_Class.GetMethod("GetOwnershipTransferTime");
            if (method == null)
            {

                (method = Instance_Class.GetMethods().First(
                    x =>
                        x.ReturnType.Name == typeof(double).FullName &&
                        x.GetParameters().Length == 1 &&
                        x.GetParameters()[0].ReturnType.Name == GameObject.Instance_Class.FullName
                )).Name = "GetOwnershipTransferTime";
                if (method == null)
                    return default;
            }
            return method.Invoke(new IntPtr[] { go.ptr }).GetValu�<double>();
        }

        unsafe public static GameObject Instantiate(VRC_EventHandler.VrcBroadcastType broadcast, string prefabPathOrDynamicPrefabName, Vector3Ex position, Quaternion rotation)
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
            IL2Method method = Instance_Class.GetMethod("Instantiate", x => x.GetParameters().Length == 4 && x.ReturnType.Name == GameObject.Instance_Class.FullName);
            if (method == null)
            {
                (method = Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 4 && x.ReturnType.Name == GameObject.Instance_Class.FullName).First()).Name = "Instantiate";
                if (method == null)
                    return IntPtr.Zero;
            }

            return method.Invoke(IntPtr.Zero, new IntPtr[] {
                broadcast,
                prefabPathOrDynamicPrefabName,
                position,
                rotation
            })?.ptr ?? IntPtr.Zero;
        }

        unsafe public static void RPC(VRC_EventHandler.VrcTargetType targetClients, GameObject targetObject, string methodName, IntPtr[] parameters)
        {
            IL2Method method = Instance_Class.GetMethod("RPC", x => x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name.EndsWith(".RPC.Destination"));
            if (method == null)
            {
                (method = Instance_Class.GetMethods().Where(x => x.GetParameters().Length == 4 && x.ReturnType.Name == "System.Void").First(
                    x =>
                        x.GetParameters()[0].ReturnType.Name.EndsWith(".RPC.Destination") &&
                        x.GetParameters()[1].ReturnType.Name == GameObject.Instance_Class.FullName &&
                        x.GetParameters()[2].ReturnType.Name == typeof(string).FullName &&
                        x.GetParameters()[3].ReturnType.Name == typeof(object[]).FullName
                )).Name = "RPC";
                if (method == null)
                    return;
            }
            if (targetObject == null)
                return;

            method.Invoke(IntPtr.Zero, new IntPtr[] {
                new IntPtr(&targetClients),
                targetObject.ptr,
                new IL2String(methodName).ptr,
                parameters.ArrayToIntPtr()
            }, ex: true);
        }

        unsafe public static bool SetOwner(Player player, GameObject obj, Network.OwnershipModificationType modificationType = Network.OwnershipModificationType.Request, bool skipOwnerTest = false)
        {
            IL2Method method = Instance_Class.GetMethod(nameof(SetOwner));
            if (method == null)
                (method = Instance_Class.GetMethods().FirstOrDefault(x => x.GetParameters().Length == 4 && x.GetParameters()[0].ReturnType.Name == Player.Instance_Class.FullName && x.GetParameters()[1].ReturnType.Name == GameObject.Instance_Class.FullName)).Name = nameof(SetOwner);
            IL2Object result = method.Invoke(new IntPtr[] { player.ptr, obj.ptr, new IntPtr(&modificationType), new IntPtr(&skipOwnerTest) });
            if (result == null)
                return default;

            return result.GetValu�<bool>();
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

        public static IL2Class Instance_Class = Assembler.list["acs"].GetClasses().FirstOrDefault(x => x.GetMethod(y => y.ReturnType.Name == ObjectInstantiator.Instance_Class.FullName) != null && x.BaseType != MonoBehaviour.Instance_Class);
    }
}