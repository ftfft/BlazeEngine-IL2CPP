using System;
using System.Linq;
using BlazeIL;
using BlazeIL.il2cpp;
using BlazeIL.il2reflection;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using SharpDisasm;
using SharpDisasm.Udis86;

public class VRCPlayer : Component
{
    public VRCPlayer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    private static IL2Field fieldInstance = null;
    public static VRCPlayer Instance
    {
        get
        {
            if (fieldInstance == null)
            {
                fieldInstance = Instance_Class.GetFields().First(x => x.ReturnType.Name == Instance_Class.FullName && x.HasFlag(IL2BindingFlags.FIELD_STATIC));
                if (fieldInstance == null)
                    return null;
            }

            return fieldInstance.GetValue()?.Unbox<VRCPlayer>();
        }
    }

    /*
    public bool HasTag(string tag)
    {
        return !string.IsNullOrEmpty(tag) && this.tags != null && this.tags.Contains(tag);
    }
    */
    public static SocialRank GetSocialRank(APIUser apiuser)
    {
        if (apiuser == null) return SocialRank.None;
        if (apiuser.hasVIPAccess || apiuser.hasModerationPowers)
            return SocialRank.VRChatTeam;

        if (apiuser.HasTag("system_probable_troll"))
            return SocialRank.Nuisance;

        if (apiuser.HasTag("system_legend"))
            return SocialRank.Legend;

        if (apiuser.HasTag("system_trust_legend"))
            return SocialRank.VeteranUser;

        if (apiuser.HasTag("system_trust_veteran"))
            return SocialRank.TrustedUser;

        if (apiuser.HasTag("system_trust_trusted"))
            return SocialRank.KnownUser;

        if (apiuser.HasTag("system_trust_known"))
            return SocialRank.User;

        if (apiuser.HasTag("system_trust_basic"))
            return SocialRank.NewUser;

        return SocialRank.Visitor;
    }


    private static IL2Method methodRefresh_Properties = null;
    public static void Refresh_Properties()
    {
        if (methodRefresh_Properties == null)
        {
            unsafe
            {
                IL2Method[] iL2Methods = Instance_Class.GetMethods(x => x.ReturnType.Name == "System.Void" && x.HasFlag(IL2BindingFlags.METHOD_STATIC) && x.HasFlag(IL2BindingFlags.METHOD_PRIVATE));
                foreach (var method in iL2Methods)
                {
                    var disasm = new Disassembler(*(IntPtr*)method.ptr, 0x1000, ArchitectureMode.x86_64, unchecked((ulong)(*(IntPtr*)method.ptr).ToInt64()), true, Vendor.Intel);
                    var instructions = disasm.Disassemble().TakeWhile(x => x.Mnemonic != ud_mnemonic_code.UD_Iint3);
                    if (instructions.Count() > 400)
                    {
                        methodRefresh_Properties = method;
                        break;
                    }
                }

            }
            if (methodRefresh_Properties == null)
                return;
        }
        methodRefresh_Properties.Invoke();
    }

    // For Safety mode
    private static IL2Field fieldVRCInput = null;
    public VRCInput vrcInput
    {
        get
        {
            if (fieldVRCInput == null)
            {
                fieldVRCInput = Instance_Class.GetFields().First(x => x.ReturnType.Name == VRCInput.Instance_Class.FullName);
                if (fieldVRCInput == null)
                    return null;
            }

            return fieldVRCInput.GetValue(ptr)?.Unbox<VRCInput>();
        }
    }
    
    private static IL2Property propertyShouldUpdate = null;
    public bool ShouldUpdate
    {
        get
        {
            if (propertyShouldUpdate == null)
            {
                propertyShouldUpdate = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == typeof(bool).FullName);
                if (propertyShouldUpdate == null)
                    return false;
            }

            return propertyShouldUpdate.GetGetMethod().Invoke(ptr).Unbox<bool>();
        }
    }

    private static IL2Field fieldPlayerSelector = null;
    public PlayerSelector playerSelector
    {
        get
        {
            if (fieldPlayerSelector == null)
            {
                fieldPlayerSelector = Instance_Class.GetFields().First(x => x.ReturnType.Name == PlayerSelector.Instance_Class.FullName);
                if (fieldPlayerSelector == null)
                    return null;
            }

            return fieldPlayerSelector.GetValue(ptr)?.Unbox<PlayerSelector>();
        }
    }
    
    private static IL2Field fieldAvatarGameObject = null;
    public GameObject avatarGameObject
    {
        get
        {
            if (fieldAvatarGameObject == null)
            {
                fieldAvatarGameObject = Instance_Class.GetFields().First(x => x.ReturnType.Name == GameObject.Instance_Class.FullName);
                if (fieldAvatarGameObject == null)
                    return null;
            }

            return fieldAvatarGameObject.GetValue(ptr)?.Unbox<GameObject>();
        }
    }

    private static IL2Field fieldAvatarAnimator = null;
    public Animator avatarAnimator
    {
        get
        {
            if (fieldAvatarAnimator == null)
            {
                fieldAvatarAnimator = Instance_Class.GetFields().First(x => x.ReturnType.Name == Animator.Instance_Class.FullName);
                if (fieldAvatarAnimator == null)
                    return null;
            }

            return fieldAvatarAnimator.GetValue(ptr)?.Unbox<Animator>();
        }
    }

    private static IL2Field fieldVipPlate = null;
    public VRCUiShadowPlate vipPlate
    {
        get
        {
            if (!IL2Get.Field("vipPlate", Instance_Class, ref fieldVipPlate))
                return default;

            return fieldVipPlate.GetValue(ptr).Unbox<VRCUiShadowPlate>();
        }
    }

    /*
     * [~] Property:
     * VRC.Player [+]
     * VRC.Core.ApiAvatar [+]
     * VRCAvatarManager
     * ulong (naverno steamid)
     * PlayerAudioManager
     * PlayerNet
     * USpeaker
     * VRC.SDKBase.VRCPlayerApi
     */

    private static IL2Property propertyPlayer = null;
    public Player player
    {
        get
        {
            if (propertyPlayer == null)
            {
                propertyPlayer = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == Player.Instance_Class.FullName);
                if (propertyPlayer == null)
                    return default;
            }

            return propertyPlayer.GetGetMethod().Invoke(ptr)?.Unbox<Player>();
        }
    }
    
    private static IL2Property propertyApiAvatar = null;
    public ApiAvatar apiAvatar
    {
        get
        {
            if (propertyApiAvatar == null)
            {
                propertyApiAvatar = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == ApiAvatar.Instance_Class.FullName);
                if (propertyApiAvatar == null)
                    return default;
            }

            return propertyApiAvatar.GetGetMethod().Invoke(ptr)?.Unbox<ApiAvatar>();
        }
    }

    // * VRCAvatarManager
    // * ulong (naverno steamid)
    // * PlayerAudioManager

    private static IL2Property propertyPlayerNet = null;
    public PlayerNet playerNet
    {
        get
        {
            if (propertyPlayerNet == null)
            {
                propertyPlayerNet = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == PlayerNet.Instance_Class.FullName);
                if (propertyPlayerNet == null)
                    return default;
            }

            return propertyPlayerNet.GetGetMethod().Invoke(ptr)?.Unbox<PlayerNet>();
        }
    }
    

    private static IL2Property propertyUSpeaker = null;
    public USpeaker uSpeaker
    {
        get
        {
            if (propertyUSpeaker == null)
            {
                propertyUSpeaker = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == USpeaker.Instance_Class.FullName);
                if (propertyUSpeaker == null)
                    return default;
            }

            return propertyUSpeaker.GetGetMethod().Invoke(ptr)?.Unbox<USpeaker>();
        }
    }
    

    private static IL2Property propertyVRCPlayerApi = null;
    public VRCPlayerApi vrcPlayerApi
    {
        get
        {
            if (propertyVRCPlayerApi == null)
            {
                propertyVRCPlayerApi = Instance_Class.GetProperties().First(x => x.GetGetMethod().ReturnType.Name == VRCPlayerApi.Instance_Class.FullName);
                if (propertyVRCPlayerApi == null)
                    return default;
            }

            return propertyVRCPlayerApi.GetGetMethod().Invoke(ptr)?.Unbox<VRCPlayerApi>();
        }
    }

    public void TeleportRPC(Vector3 vector, Quaternion quaternion, VRC_SceneDescriptor.SpawnOrientation spawnOrientation)
    {
        Network.RPC(VRCSDK2.VRC_EventHandler.VrcTargetType.TargetPlayer, gameObject, "TeleportRPC", new IntPtr[] {
            IL2Import.CreateNewObject(vector, BlazeTools.IL2SystemClass.vector3),
            IL2Import.CreateNewObject(quaternion, BlazeTools.IL2SystemClass.vector3),
            IL2Import.CreateNewObject(spawnOrientation, BlazeTools.IL2SystemClass.spawnOrientation)
        });
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCPlayer");
}