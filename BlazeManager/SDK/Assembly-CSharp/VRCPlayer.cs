using System;
using System.Linq;
using System.Collections.Generic;
using BlazeIL;
using BlazeIL.il2cpp;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;
using SharpDisasm;
using SharpDisasm.Udis86;

public class VRCPlayer : VRCNetworkBehaviour
{
    public VRCPlayer(IntPtr ptr) : base(ptr) => base.ptr = ptr;

    // <!---------- ---------- ---------->
    // <!---------- PROPERTY'S ---------->
    // <!---------- ---------- ---------->
    public Player player
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(player));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == Player.Instance_Class.FullName)).Name = nameof(player);
            return property?.GetGetMethod().Invoke(ptr)?.unbox<Player>();
        }
    }

    public ApiAvatar AvatarModel
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(AvatarModel));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == ApiAvatar.Instance_Class.FullName)).Name = nameof(AvatarModel);
            return property?.GetGetMethod().Invoke(ptr)?.unbox<ApiAvatar>();
        }
    }

    // * VRCAvatarManager
    // * ulong (naverno steamid)
    // * PlayerAudioManager

    public PlayerNet playerNet
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(playerNet));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == PlayerNet.Instance_Class.FullName)).Name = nameof(playerNet);
            return property.GetGetMethod().Invoke(ptr)?.unbox<PlayerNet>();
        }
    }

    public USpeaker uSpeaker
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(uSpeaker));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == USpeaker.Instance_Class.FullName)).Name = nameof(uSpeaker);
            return property?.GetGetMethod().Invoke(ptr)?.unbox<USpeaker>();
        }
    }

    public VRCPlayerApi apiPlayer
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(apiPlayer));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == VRCPlayerApi.Instance_Class.FullName)).Name = nameof(apiPlayer);
            return property?.GetGetMethod().Invoke(ptr)?.unbox<VRCPlayerApi>();
        }
    }


    // <!---------- ------- ---------->
    // <!---------- FIELD'S ---------->
    // <!---------- ------- ---------->
    public static VRCPlayer Instance
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(Instance));
            if (field == null)
                (field = Instance_Class.GetField(x => x.Instance)).Name = nameof(Instance);
            return field?.GetValue()?.unbox<VRCPlayer>();
        }
    }

    /*
    public bool HasTag(string tag)
    {
        return !string.IsNullOrEmpty(tag) && this.tags != null && this.tags.Contains(tag);
    }
    */

    static VRCPlayer()
    {
        dictUserRank.Add("Nuisance", new IL2String("system_probable_troll"));
        dictUserRank["Nuisance"].Static = true;
        dictUserRank.Add("Legend", new IL2String("system_legend"));
        dictUserRank["Legend"].Static = true;
        dictUserRank.Add("Veteran", new IL2String("system_trust_legend"));
        dictUserRank["Veteran"].Static = true;
        dictUserRank.Add("Trusted user", new IL2String("system_trust_veteran"));
        dictUserRank["Trusted user"].Static = true;
        dictUserRank.Add("Known user", new IL2String("system_trust_trusted"));
        dictUserRank["Known user"].Static = true;
        dictUserRank.Add("User", new IL2String("system_trust_known"));
        dictUserRank["User"].Static = true;
        dictUserRank.Add("New user", new IL2String("system_trust_basic"));
        dictUserRank["New user"].Static = true;
    }
    private static Dictionary<string, IL2String> dictUserRank = new Dictionary<string, IL2String>();
    public static SocialRank GetSocialRank(APIUser apiuser)
    {
        if (apiuser == null) return SocialRank.None;
        if (apiuser.hasVIPAccess || apiuser.hasModerationPowers)
            return SocialRank.VRChatTeam;

        if (apiuser.HasTag(dictUserRank["Nuisance"].ptr))
            return SocialRank.Nuisance;

        if (apiuser.HasTag(dictUserRank["Legend"].ptr))
            return SocialRank.Legend;

        if (apiuser.HasTag(dictUserRank["Veteran"].ptr))
            return SocialRank.VeteranUser;

        if (apiuser.HasTag(dictUserRank["Trusted user"].ptr))
            return SocialRank.TrustedUser;

        if (apiuser.HasTag(dictUserRank["Known user"].ptr))
            return SocialRank.KnownUser;

        if (apiuser.HasTag(dictUserRank["User"].ptr))
            return SocialRank.User;

        if (apiuser.HasTag(dictUserRank["New user"].ptr))
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

    public ulong SteamUserIDULong
    {
        get
        {
            IL2Property property = Instance_Class.GetProperty(nameof(SteamUserIDULong));
            if (property == null)
                (property = Instance_Class.GetProperty(x => x.GetGetMethod().ReturnType.Name == typeof(ulong).FullName)).Name = nameof(SteamUserIDULong);

            IL2Object result = property?.GetGetMethod().Invoke(ptr);
            if (result == null)
                return default;

            return result.unbox_Unmanaged<ulong>();
        }
    }

    public VRCInput inPanic
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(inPanic));
            if (field == null)
                (field = Instance_Class.GetFields().First(x => x.ReturnType.Name == VRCInput.Instance_Class.FullName)).Name = nameof(inPanic);

            return field?.GetValue(ptr)?.unbox<VRCInput>();
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

    public PlayerSelector playerSelector
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(playerSelector));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == PlayerSelector.Instance_Class.FullName)).Name = nameof(playerSelector);

            return field?.GetValue(ptr)?.unbox<PlayerSelector>();
        }
    }
    
    public GameObject avatarGameObject
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(avatarGameObject));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == GameObject.Instance_Class.FullName)).Name = nameof(avatarGameObject);

            return field?.GetValue(ptr)?.unbox<GameObject>();
        }
    }

    public Animator avatarAnimator
    {
        get
        {
            IL2Field field = Instance_Class.GetField(nameof(avatarAnimator));
            if (field == null)
                (field = Instance_Class.GetField(x => x.ReturnType.Name == Animator.Instance_Class.FullName)).Name = nameof(avatarAnimator);

            return field.GetValue(ptr)?.Unbox<Animator>();
        }
    }

    public VRCUiShadowPlate namePlate
    {
        get => Instance_Class.GetField(nameof(namePlate)).GetValue(ptr)?.unbox<VRCUiShadowPlate>();
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


    public void TeleportRPC(Vector3 vector, Quaternion quaternion, VRC_SceneDescriptor.SpawnOrientation spawnOrientation)
    {
        Network.RPC(VRC_EventHandler.VrcTargetType.TargetPlayer, gameObject, "TeleportRPC", new IntPtr[] {
            IL2Import.CreateNewObject(vector, BlazeTools.IL2SystemClass.vector3),
            IL2Import.CreateNewObject(quaternion, BlazeTools.IL2SystemClass.vector3),
            IL2Import.CreateNewObject(spawnOrientation, BlazeTools.IL2SystemClass.spawnOrientation)
        });
    }

    public enum NetworkChange
    {
        Visible = 1,
        ModTag = 2,
        VRMode = 4,
        Status = 8,
        StatusDesc = 16,
        SteamId = 32,
        ShowRank = 64,
        Avatar = 128,
        User = 256
    }

    public static new IL2Type Instance_Class = Assemblies.a["Assembly-CSharp"].GetClass("VRCPlayer");
}