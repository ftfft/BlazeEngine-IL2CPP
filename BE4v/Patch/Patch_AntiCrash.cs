using System;
using System.Linq;
using BE4v.SDK;
using BE4v.SDK.CPP2IL;
using SharpDisasm.Udis86;
using UnityEngine;
using VRC.Core;
using TMPro;

namespace BE4v.Patch
{
    public delegate IntPtr _TMP_MaterialManager_GetMaterialForRendering(IntPtr graphic, IntPtr baseMaterial);
    public delegate IntPtr _VRCAvatarManager_SwitchAvatar(IntPtr instance, IntPtr apiAvatar, float scale = 1f);
    public static class Patch_AntiCrash
    {
        public static string[] blockedAvtr = new string[]
        {
            "avtr_4104e354-4ca5-4a2f-8fd7-1ab5711b7843",
            "avtr_13787bee-7f25-4d37-9c51-510d419b5484",
            "avtr_006e843a-c849-4973-8fd8-56285ea37b1d",
            "avtr_4a963b1b-42e1-4a9c-ab29-cf45e6f646b8",
            "avtr_ad897367-c6ee-4ef6-8af8-c90d45e2cb9e",
            "avtr_ff16af4a-c3cf-4a7b-aaf3-c532d3f2ee14",
            "avtr_d0c68735-44df-480c-b368-97f9b01d71b9",
            "avtr_059de223-ba9f-447b-9f70-07a138e7528f",
            "avtr_49744928-9fc4-4c87-b34b-60b9611d210e",
            "avtr_a4b26812-0ab3-48c7-a2e4-10e4b6aaebba",
            "avtr_9a21aff8-e1f9-461b-8969-b9d1dde9d1cf",
            "avtr_bbef3872-06ba-405d-a1d1-e1b15d035f1d",
            "avtr_e45dcd04-99e1-4123-83c0-2b4168ab7017",
            "avtr_ebdc0946-b435-41b7-9e17-e74a0fca379a",
            "avtr_966e46d7-c8f5-450b-9a10-e428d63c2c03",
            "avtr_33939c5a-24e3-475f-a321-49dd01cfd5da",
            "avtr_4104e354-4ca5-4a2f-8fd7-1ab5711b7843",
            "avtr_d7f94133-adbe-43f6-b7ba-5bd8b4393c4c",
            "avtr_b246f080-284a-4342-bc57-41de634cddc9",
            "avtr_966e46d7-c8f5-450b-9a10-e428d63c2c03"
        };

        public static void Start()
        {
            /*
            try
            {
                IL2Method method = VRCAvatarManager.Instance_Class.GetMethod(x => x.ReturnType.Name == "Cysharp.Threading.Tasks.UniTask<" + typeof(bool).FullName + ">" && x.GetParameters().Length == 2 && x.IsPublic);
                if (method == null)
                    throw new Exception();

                method.Name = "SwitchAvatar";

                var patch = new IL2Patch(method, (_VRCAvatarManager_SwitchAvatar)VRCAvatarManager_SwitchAvatar);
                _VRCAvatarManager_SwitchAvatar = patch.CreateDelegate<_VRCAvatarManager_SwitchAvatar>();
                "AntiCrash (1)".GreenPrefix(TMessage.SuccessPatch);
            }
            catch (Exception ex)
            {
                "AntiCrash (1)".RedPrefix(TMessage.BadPatch);
                Console.WriteLine(ex.ToString());
            }
            // --------------
            /* AntiCrash
            System.NullReferenceException: Object reference not set to an instance of an object.
              at TMPro.TMP_MaterialManager.GetMaterialForRendering (UnityEngine.UI.MaskableGraphic graphic, UnityEngine.Material baseMaterial) [0x00000] in <00000000000000000000000000000000>:0 
              at ǅǄǅǄǅǄǅǅǅǄǅǄǅǄǅǄǅǄǄǅǅǄǅǄǅǅǅǄǄǄǅǅǅǄǄǅǅǄǅǄǄǄǅǅǅǄǅ+ǄǅǄǄǅǅǅǅǅǅǅǅǅǅǅǅǅǅǅǄǄǅǅǅǄǅǄǅǄǅǅǅǄǄǄǅǅǄǅǅǄǅǅǄǅǄǅ.<FixComponents>b__1 () [0x00000] in <00000000000000000000000000000000>:0 
              at System.Func`1[TResult].Invoke () [0x00000] in <00000000000000000000000000000000>:0 
              at ǅǄǅǄǅǄǅǅǅǄǅǄǅǄǅǄǅǄǄǅǅǄǅǄǅǅǅǄǄǄǅǅǅǄǄǅǅǄǅǄǄǄǅǅǅǄǅ.LateUpdate () [0x00000] in <00000000000000000000000000000000>:0 
            */
            // --------------
            /*
            try
            {
                IL2Method method = TMPro.TMP_MaterialManager.Instance_Class.GetMethod("GetMaterialForRendering");

                var patch = new IL2Patch(method, (_TMP_MaterialManager_GetMaterialForRendering)TMP_MaterialManager_GetMaterialForRendering);
                _dTMP_MaterialManager_GetMaterialForRendering = patch.CreateDelegate<_TMP_MaterialManager_GetMaterialForRendering>();
                "AntiCrash  (2)".GreenPrefix(TMessage.SuccessPatch);
            }
            catch (Exception ex)
            {
                "AntiCrash (2)".RedPrefix(TMessage.BadPatch);
                Console.WriteLine(ex.ToString());
            }
            */
        }

        private static IntPtr VRCAvatarManager_SwitchAvatar(IntPtr instance, IntPtr apiAvatar, float scale = 1f)
        {
            // Logger
            /*
            Console.WriteLine("/ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ /");
            Console.WriteLine("AvatarID: " + avatar?.id);
            Console.WriteLine("AvatarName: " + avatar?.name);
            Console.WriteLine("/ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ /");
            if (UserUtils.blockedAvatars?.Contains(avatar?.id) == true)
            {
                return false;
            }
            */
            IntPtr result = IntPtr.Zero;
            try
            {
                if (apiAvatar != IntPtr.Zero)
                {
                    ApiAvatar avatar = new ApiAvatar(apiAvatar);
                    if (!blockedAvtr.Contains(avatar.id))
                    {
                        result = _VRCAvatarManager_SwitchAvatar(instance,
                            apiAvatar,
                            scale
                        );
                    }
                    /*
                    if (Mods.Mod_Console.isLog)
                    {
                        Console.WriteLine("/ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ /");
                        Console.WriteLine("AvatarID: " + avatar.id);
                        Console.WriteLine("AvatarName: " + avatar.name);
                        Console.WriteLine("/ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ /");
                    }
                    */
                }
            }
            catch
            {
                if (apiAvatar != IntPtr.Zero)
                {
                    ApiAvatar avatar = new ApiAvatar(apiAvatar);
                    /*
                    if (Mods.Mod_Console.isLog)
                    {
                        Console.WriteLine("/ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ / BAD LOAD");
                        Console.WriteLine("AvatarID: " + avatar.id);
                        Console.WriteLine("AvatarName: " + avatar.name);
                        Console.WriteLine("/ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ /");
                    }
                    */
                }
            }
            return result;
        }
        private static IntPtr TMP_MaterialManager_GetMaterialForRendering(IntPtr graphic, IntPtr baseMaterial)
        {
            if (graphic == IntPtr.Zero && baseMaterial != IntPtr.Zero)
            {
                return baseMaterial;
            }
            IntPtr result = IntPtr.Zero;
            try
            {
                result = _dTMP_MaterialManager_GetMaterialForRendering.Invoke(graphic, baseMaterial);
            }
            catch
            {
            }
            return result;
        }

        public static _VRCAvatarManager_SwitchAvatar _VRCAvatarManager_SwitchAvatar;
        public static _TMP_MaterialManager_GetMaterialForRendering _dTMP_MaterialManager_GetMaterialForRendering;
    }
}
