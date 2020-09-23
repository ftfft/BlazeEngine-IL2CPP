using System;
using System.Linq;
using BlazeIL.il2cpp;
using UnityEngine;
using VRC.Core;

namespace VRC
{
    unsafe public class Player : Component
    {
        public Player(IntPtr ptrNew) : base(ptrNew) =>
            ptr = ptrNew;

        private static IL2Property propertyGetInstance = null;
        public static Player Instance
        {
            get
            {
                if (propertyGetInstance == null)
                {
                    propertyGetInstance = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "VRC.Player");
                    if (propertyGetInstance == null)
                        return null;
                }

                IL2Object result = null;
                result = propertyGetInstance.GetGetMethod().Invoke();
                if (result == null)
                    return null;

                return result.MonoCast<Player>();
            }
        }

        private static IL2Property propertyApiPlayer = null;
        public VRCSDK2.VRC_PlayerApi apiPlayer
        {
            get
            {
                if (propertyApiPlayer == null)
                {
                    propertyApiPlayer = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "VRCSDK2.VRC_PlayerApi");
                    if (propertyApiPlayer == null)
                        return null;
                }

                IL2Object result = null;
                result = propertyApiPlayer.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return null;

                return result.MonoCast<VRCSDK2.VRC_PlayerApi>();
            }
        }

        private static IL2Property propertyApiuser = null;
        public APIUser apiuser
        {
            get
            {
                if (propertyApiuser == null)
                {
                    propertyApiuser = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "VRC.Core.APIUser");
                    if (propertyApiuser == null)
                        return null;
                }

                IL2Object result = null;
                result = propertyApiuser.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return null;

                return result.MonoCast<APIUser>();
            }
        }

        private static IL2Property propertyPlayerNet = null;
        public IntPtr PlayerNet
        {
            get
            {
                if (propertyPlayerNet == null)
                {
                    propertyPlayerNet = Instance_Class.GetProperties().First(x => x.GetGetMethod().GetReturnType().Name == "PlayerNet");
                    if (propertyPlayerNet == null)
                        return IntPtr.Zero;
                }

                IL2Object result = null;
                result = propertyPlayerNet.GetGetMethod().Invoke(ptr);
                if (result == null)
                    return IntPtr.Zero;

                return result.ptr;
            }
        }

        private static IL2Field fieldPhotonPlayer = null;
        public PhotonPlayer photonPlayer
        {
            get
            {
                if (fieldPhotonPlayer == null)
                {
                    fieldPhotonPlayer = Instance_Class.GetFields().First(x => x.GetReturnType().Name == PhotonPlayer.Instance_Class.Name);
                    if (fieldPhotonPlayer == null)
                        return null;
                }

                IL2Object result = fieldPhotonPlayer.GetValue(ptr);
                if (result == null)
                    return null;
                
                return result.MonoCast<PhotonPlayer>();
            }
        }

        private static IL2Field fieldVrcPlayer = null;
        public VRCPlayer vrcPlayer
        {
            get
            {
                if (fieldVrcPlayer == null)
                {
                    fieldVrcPlayer = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "VRCPlayer");
                    if (fieldVrcPlayer == null)
                        return null;
                }

                IL2Object result = null;
                result = fieldVrcPlayer.GetValue(ptr);
                if (result == null)
                    return null;

                return result.MonoCast<VRCPlayer>(); ;
            }
        }

        private static IL2Field fieldUSpeaker = null;
        public USpeaker uSpeaker
        {
            get
            {
                if (fieldUSpeaker == null)
                {
                    fieldUSpeaker = Instance_Class.GetFields().First(x => x.GetReturnType().Name == "USpeaker");
                    if (fieldUSpeaker == null)
                        return null;
                }

                IL2Object result = fieldUSpeaker.GetValue(ptr);
                if (result == null)
                    return null;

                return result.MonoCast<USpeaker>();
            }
        }

        public static IL2Method methodApplyMute = null;
        public void ApplyMute(bool status)
        {
            if (methodApplyMute == null)
                return;

            methodApplyMute.Invoke(ptr, new IntPtr(&status));
        }

        public static IL2Method methodApplyBlock = null;
        public void ApplyBlock(bool status)
        {
            if (methodApplyBlock == null)
                return;

            methodApplyBlock.Invoke(ptr, new IntPtr(&status));
        }

        private static IL2Method methodToString = null;
        public override string ToString()
        {
            if (methodToString == null)
            {
                methodToString = Instance_Class.GetMethod("ToString");
                if (methodToString == null)
                    return null;
            }

            IL2Object result = null;
            result = methodToString.Invoke(ptr);
            if (result == null)
                return null;

            return result.UnboxString();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Player))
                return false;
            return ((Player)obj).ptr == ptr;
        }

        public override int GetHashCode() =>
            ptr.GetHashCode();

        public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("Player", "VRC");
    }
}
