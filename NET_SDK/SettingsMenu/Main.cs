using System;
using System.Collections.Generic;
using System.Linq;
using NET_SDK;
using NET_SDK.Reflection;

namespace NET_SDK.SettingsMenu
{
    internal static class Main
    {
        private static IL2CPP_Class Resources;
        private static IL2CPP_Method Resources_FindObjectsOfTypeAll;

        private static IL2CPP_Class GameObject;
        private static IL2CPP_Method GameObject_ctor;
        private static IL2CPP_Method GameObject_Internal_CreateGameObject;
        private static IL2CPP_Method GameObject_AddComponent;
        private static IL2CPP_Method GameObject_GetComponent;
        private static IL2CPP_Method GameObject_GetComponentInChildren;
        private static IL2CPP_Method GameObject_Find;
        private static IL2CPP_Method GameObject_get_transform;

        private static IL2CPP_Class Transform;
        private static IL2CPP_Method Transform_get_parent;
        private static IL2CPP_Method Transform_SetParent;
        private static IL2CPP_Method Transform_get_localPosition;
        private static IL2CPP_Method Transform_set_localPosition;

        private static IL2CPP_Class Component;
        private static IL2CPP_Method Component_get_gameObject;

        private static IL2CPP_Class RectTransform;
        private static IL2CPP_Method RectTransform_get_sizeDelta;
        private static IL2CPP_Method RectTransform_set_sizeDelta;

        private static IL2CPP_Class Button;

        private static IL2CPP_Class VRCUiPage;
        private static IL2CPP_Field VRCUiPage_screenType;
        private static IL2CPP_Field VRCUiPage_displayName;

        private static IL2CPP_Class VRCUiPageHeader;

        private static IL2CPP_Class VRCUiPageSettings;
        private static IL2CPP_Field VRCUiPageSettings_advancedButton;

        private static IL2CPP_Object HeaderPage;

        unsafe internal static void OnUIManagerInit()
        {
            if (Resources == null)
                Resources = SDK.GetClass("UnityEngine.Resources");
            if (Resources == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.Resources");
                return;
            }

            if (Resources_FindObjectsOfTypeAll == null)
                Resources_FindObjectsOfTypeAll = Resources.GetMethod("FindObjectsOfTypeAll");
            if (Resources_FindObjectsOfTypeAll == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.Resources::FindObjectsOfTypeAll");
                return;
            }

            if (GameObject == null)
                GameObject = SDK.GetClass("UnityEngine.GameObject");
            if (GameObject == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.GameObject");
                return;
            }

            if (GameObject_ctor == null)
                GameObject_ctor = GameObject.GetMethods().First(x => (x.Name.Equals(".ctor") && (x.GetParameterCount() == 2)));
            if (GameObject_ctor == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.GameObject::.ctor");
                return;
            }

            if (GameObject_Internal_CreateGameObject == null)
                GameObject_Internal_CreateGameObject = GameObject.GetMethod("Internal_CreateGameObject");
            if (GameObject_Internal_CreateGameObject == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.GameObject::Internal_CreateGameObject");
                return;
            }

            if (GameObject_AddComponent == null)
                GameObject_AddComponent = GameObject.GetMethods().First(x => (x.Name.Equals("AddComponent") && IL2CPP.il2cpp_type_get_name(x.GetReturnType().Ptr).Equals("UnityEngine.Component") && (x.GetParameterCount() == 1) && IL2CPP.il2cpp_type_get_name(x.GetParameters()[0].Ptr).Equals("System.Type")));
            if (GameObject_AddComponent == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.GameObject::AddComponent");
                return;
            }

            if (GameObject_GetComponent == null)
                GameObject_GetComponent = GameObject.GetMethods().First(x => (x.Name.Equals("GetComponent") && IL2CPP.il2cpp_type_get_name(x.GetReturnType().Ptr).Equals("UnityEngine.Component") && (x.GetParameterCount() == 1) && IL2CPP.il2cpp_type_get_name(x.GetParameters()[0].Ptr).Equals("System.Type")));
            if (GameObject_GetComponent == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.GameObject::GetComponent");
                return;
            }

            if (GameObject_GetComponentInChildren == null)
                GameObject_GetComponentInChildren = GameObject.GetMethods().First(x => (x.Name.Equals("GetComponentInChildren") && IL2CPP.il2cpp_type_get_name(x.GetReturnType().Ptr).Equals("UnityEngine.Component") && (x.GetParameterCount() == 1) && IL2CPP.il2cpp_type_get_name(x.GetParameters()[0].Ptr).Equals("System.Type")));
            if (GameObject_GetComponentInChildren == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.GameObject::GetComponentInChildren");
                return;
            }

            if (GameObject_Find == null)
                GameObject_Find = GameObject.GetMethod("Find");
            if (GameObject_Find == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.GameObject::Find");
                return;
            }

            if (GameObject_get_transform == null)
                GameObject_get_transform = GameObject.GetMethod("get_transform");
            if (GameObject_get_transform == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.GameObject::get_transform");
                return;
            }

            if (Transform == null)
                Transform = SDK.GetClass("UnityEngine.Transform");
            if (Transform == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.Transform");
                return;
            }

            if (Transform_SetParent == null)
                Transform_SetParent = Transform.GetMethod("SetParent");
            if (Transform_SetParent == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.Transform::SetParent");
                return;
            }

            if (Transform_get_parent == null)
                Transform_get_parent = Transform.GetMethod("get_parent");
            if (Transform_get_parent == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.Transform::get_parent");
                return;
            }

            if (Transform_get_localPosition == null)
                Transform_get_localPosition = Transform.GetMethod("get_localPosition");
            if (Transform_get_localPosition == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.RectTransform::get_localPosition");
                return;
            }

            if (Transform_set_localPosition == null)
                Transform_set_localPosition = Transform.GetMethod("set_localPosition");
            if (Transform_set_localPosition == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.Transform::set_localPosition");
                return;
            }

            if (RectTransform == null)
                RectTransform = SDK.GetClass("UnityEngine.RectTransform");
            if (RectTransform == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.RectTransform");
                return;
            }

            if (RectTransform_get_sizeDelta == null)
                RectTransform_get_sizeDelta = RectTransform.GetMethod("get_sizeDelta");
            if (RectTransform_get_sizeDelta == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.RectTransform::get_sizeDelta");
                return;
            }

            if (RectTransform_set_sizeDelta == null)
                RectTransform_set_sizeDelta = RectTransform.GetMethod("set_sizeDelta");
            if (RectTransform_set_sizeDelta == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.RectTransform::set_sizeDelta");
                return;
            }

            if (Component == null)
                Component = SDK.GetClass("UnityEngine.Component");
            if (Component == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.Component");
                return;
            }

            if (Component_get_gameObject == null)
                Component_get_gameObject = Component.GetMethod("get_gameObject");
            if (Component_get_gameObject == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.Component::get_gameObject");
                return;
            }

            if (Button == null)
                Button = SDK.GetClass("UnityEngine.UI.Button");
            if (Button == null)
            {
                Logger.LogError("Couldn't Find UnityEngine.UI.Button");
                return;
            }

            if (VRCUiPage == null)
                VRCUiPage = SDK.GetClass("VRCUiPage");
            if (VRCUiPage == null)
            {
                Logger.LogError("Couldn't Find VRCUiPage");
                return;
            }

            if (VRCUiPage_screenType == null)
                VRCUiPage_screenType = VRCUiPage.GetField("screenType");
            if (VRCUiPage_screenType == null)
            {
                Logger.LogError("Couldn't Find VRCUiPage::screenType");
                return;
            }

            if (VRCUiPage_displayName == null)
                VRCUiPage_displayName = VRCUiPage.GetField("displayName");
            if (VRCUiPage_displayName == null)
            {
                Logger.LogError("Couldn't Find VRCUiPage::displayName");
                return;
            }

            if (VRCUiPageHeader == null)
                VRCUiPageHeader = SDK.GetClass("VRCUiPageHeader");
            if (VRCUiPageHeader == null)
            {
                Logger.LogError("Couldn't Find VRCUiPageHeader");
                return;
            }

            if (VRCUiPageSettings == null)
                VRCUiPageSettings = SDK.GetClass("VRCUiPageSettings");
            if (VRCUiPageSettings == null)
            {
                Logger.LogError("Couldn't Find VRCUiPageSettings");
                return;
            }

            if (VRCUiPageSettings_advancedButton == null)
                VRCUiPageSettings_advancedButton = VRCUiPageSettings.GetField("advancedButton");
            if (VRCUiPageSettings_advancedButton == null)
            {
                Logger.LogError("Couldn't Find VRCUiPageSettings::advancedButton");
                return;
            }

            IL2CPP_Object HeaderObj = GameObject_Find.Invoke(null, IL2CPP.StringToIntPtr("UserInterface/MenuContent/Backdrop/Header"));
            if (HeaderObj == null)
            {
                Logger.LogError("HeaderObj = null");
                return;
            }

            if (HeaderPage == null)
                HeaderPage = GameObject_GetComponent.Invoke(HeaderObj.Ptr, IL2CPP.il2cpp_type_get_object(IL2CPP.il2cpp_class_get_type(VRCUiPageHeader.Ptr)));
            if (HeaderPage == null)
            {
                Logger.LogError("HeaderPage = null");
                return;
            }

            IL2CPP_Object AvatarScreenObj = GameObject_Find.Invoke(null, IL2CPP.StringToIntPtr("UserInterface/MenuContent/Screens/Avatar"));
            if (AvatarScreenObj == null)
            {
                Logger.LogError("AvatarScreenObj = null");
                return;
            }

            IL2CPP_Object AvatarScreen_VRCUiPage = GameObject_GetComponent.Invoke(AvatarScreenObj.Ptr, IL2CPP.il2cpp_type_get_object(IL2CPP.il2cpp_class_get_type(VRCUiPage.Ptr)));
            if (AvatarScreen_VRCUiPage == null)
            {
                Logger.LogError("AvatarScreen_VRCUiPage = null");
                return;
            }

            IntPtr goObj = IL2CPP.il2cpp_object_new(GameObject.Ptr);
            if (goObj == IntPtr.Zero)
            {
                Logger.LogError("HeaderPage = IntPtr.Zero");
                return;
            }

            GameObject_Internal_CreateGameObject.Invoke(null, goObj, IL2CPP.StringToIntPtr("Mod_Settings"));
            
            IL2CPP_Object go_transform = GameObject_AddComponent.Invoke(goObj, IL2CPP.il2cpp_type_get_object(IL2CPP.il2cpp_class_get_type(RectTransform.Ptr)));
            if (go_transform == null)
            {
                Logger.LogError("go_transform = null");
                return;
            }

            IL2CPP_Object AvatarScreen_Transform = GameObject_get_transform.Invoke(AvatarScreenObj.Ptr);
            if (AvatarScreen_Transform == null)
            {
                Logger.LogError("AvatarScreen_Transform = null");
                return;
            }

            IL2CPP_Object AvatarScreen_Parent = Transform_get_parent.Invoke(AvatarScreen_Transform.Ptr);
            if (AvatarScreen_Parent == null)
            {
                Logger.LogError("AvatarScreen_Parent = null");
                return;
            }

            Transform_SetParent.Invoke(go_transform.Ptr, AvatarScreen_Parent.Ptr);

            IL2CPP_Object go_VRCUiPage = GameObject_AddComponent.Invoke(goObj, IL2CPP.il2cpp_type_get_object(IL2CPP.il2cpp_class_get_type(VRCUiPage.Ptr)));
            if (go_VRCUiPage == null)
            {
                Logger.LogError("go_VRCUiPage = null");
                return;
            }

            IL2CPP_Object AvatarScreen_VRCUiPage_screenType = VRCUiPage_screenType.GetValue(AvatarScreen_VRCUiPage.Ptr);
            if (AvatarScreen_VRCUiPage_screenType == null)
            {
                Logger.LogError("AvatarScreen_VRCUiPage_screenType = null");
                return;
            }

            VRCUiPage_screenType.SetValue(go_VRCUiPage.Ptr, AvatarScreen_VRCUiPage_screenType.Ptr);
            VRCUiPage_displayName.SetValue(go_VRCUiPage.Ptr, IL2CPP.StringToIntPtr("Mod Settings"));

            IL2CPP_Object SettingsPageArray = Resources_FindObjectsOfTypeAll.Invoke(IntPtr.Zero, IL2CPP.il2cpp_type_get_object(IL2CPP.il2cpp_class_get_type(VRCUiPageSettings.Ptr)));
            if (SettingsPageArray == null)
            {
                Logger.LogError("SettingsPageArray = null");
                return;
            }

            IntPtr[] SettingsPageArrayPtrs = IL2CPP.IntPtrToArray(SettingsPageArray.Ptr);
            IntPtr SettingsPage = SettingsPageArrayPtrs[0];
            if (SettingsPage == IntPtr.Zero)
            {
                Logger.LogError("SettingsPage = IntPtr.Zero");
                return;
            }

            IL2CPP_Object SettingsPage_AdvancedSettingsButton = VRCUiPageSettings_advancedButton.GetValue(SettingsPage);
            if (SettingsPage_AdvancedSettingsButton == null)
            {
                Logger.LogError("SettingsPage_AdvancedSettingsButton = null");
                return;
            }

            IL2CPP_Object SettingsPage_AdvancedSettingsButton_GameObject = Component_get_gameObject.Invoke(SettingsPage_AdvancedSettingsButton.Ptr);
            if (SettingsPage_AdvancedSettingsButton_GameObject == null)
            {
                Logger.LogError("SettingsPage_AdvancedSettingsButton_GameObject = null");
                return;
            }

            IL2CPP_Object SettingsPage_AdvancedSettingsButton_RectTransform = GameObject_GetComponent.Invoke(SettingsPage_AdvancedSettingsButton_GameObject.Ptr, IL2CPP.il2cpp_type_get_object(IL2CPP.il2cpp_class_get_type(RectTransform.Ptr)));
            if (SettingsPage_AdvancedSettingsButton_RectTransform == null)
            {
                Logger.LogError("SettingsPage_AdvancedSettingsButton_RectTransform = null");
                return;
            }

            IL2CPP_Object SettingsPage_AdvancedSettingsButton_RectTransform_SizeDelta = RectTransform_get_sizeDelta.Invoke(SettingsPage_AdvancedSettingsButton_RectTransform.Ptr);
            if (SettingsPage_AdvancedSettingsButton_RectTransform_SizeDelta == null)
            {
                Logger.LogError("SettingsPage_AdvancedSettingsButton_RectTransform_SizeDelta = null");
                return;
            }

            Internal.Vector2 oldSizeDelta = *(Internal.Vector2*)SettingsPage_AdvancedSettingsButton_RectTransform_SizeDelta.Unbox();
            Internal.Vector2 newSizeDelta = new Internal.Vector2((oldSizeDelta.x - 100), oldSizeDelta.y);
            //RectTransform_set_sizeDelta.Invoke(SettingsPage_AdvancedSettingsButton_RectTransform.Ptr, newSizeDelta);

            IL2CPP_Object SettingsPage_AdvancedSettingsButton_RectTransform_LocalPosition = Transform_get_localPosition.Invoke(SettingsPage_AdvancedSettingsButton_RectTransform.Ptr);
            if (SettingsPage_AdvancedSettingsButton_RectTransform_LocalPosition == null)
            {
                Logger.LogError("SettingsPage_AdvancedSettingsButton_RectTransform_SizeDelta = null");
                return;
            }

            Internal.Vector3 oldLocalPosition = *(Internal.Vector3*)SettingsPage_AdvancedSettingsButton_RectTransform_LocalPosition.Unbox();
            Internal.Vector3 newLocalPosition = new Internal.Vector3((oldLocalPosition.x + 100), oldLocalPosition.y, oldLocalPosition.z);
            //Transform_set_localPosition.Invoke(SettingsPage_AdvancedSettingsButton_RectTransform.Ptr, newLocalPosition);


        }
    }
}
