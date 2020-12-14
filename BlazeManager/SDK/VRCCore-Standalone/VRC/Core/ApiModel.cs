using System;
using System.Collections.Generic;
using UnityEngine.Events;
using BlazeIL;
using BlazeIL.il2cpp;

namespace VRC.Core
{
    public class ApiModel : IL2Base
    {
        public ApiModel(IntPtr ptr) : base(ptr) => base.ptr = ptr;

        public string id
        {
            get => Instance_Class.GetProperty(nameof(id)).GetGetMethod().Invoke(ptr)?.unbox_ToString().ToString();
            set => Instance_Class.GetProperty(nameof(id)).GetSetMethod().Invoke(ptr, new IntPtr[] { new IL2String(value).ptr });
        }    
    
        public bool Populated
        {
            get => Instance_Class.GetProperty(nameof(Populated)).GetGetMethod().Invoke(ptr).unbox_Unmanaged<bool>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="onSuccess">Action "ApiContainer"</param>
        /// <param name="onFailure">Action "ApiContainer"</param>
        /// <param name="parameters"></param>
        /// <param name="disableCache"></param>
        public void Fetch(Action<IntPtr> onSuccess = null, Action<IntPtr> onFailure = null, Dictionary<string, object> parameters = null, bool disableCache = false)
        {
            IntPtr ptrSuccess = IntPtr.Zero;
            if (onSuccess != null)
                ptrSuccess = _UnityAction.CreateDelegate(onSuccess, IntPtr.Zero, BlazeTools.IL2SystemClass.action_1);
            IntPtr ptrFailure = IntPtr.Zero;
            if (onFailure != null)
                ptrFailure = _UnityAction.CreateDelegate(onFailure, IntPtr.Zero, BlazeTools.IL2SystemClass.action_1);

            Instance_Class.GetMethod(nameof(Fetch)).Invoke(ptr, new IntPtr[] { ptrSuccess, ptrFailure, IntPtr.Zero, disableCache.MonoCast() });
        }

        public static IL2Type Instance_Class = Assemblies.a[LangTransfer.values[cAssemblies.offset + (long)eAssemblies.vrccorestandalone]].GetClass("ApiModel", "VRC.Core");
    }
}