using System;
using System.Runtime.InteropServices;

namespace NET_SDK.NetDomain
{
    // [ComImport, Guid("F20A83EB-FB00-454B-9D88-132F7EC693D7"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComImport, Guid("E86B87C8-5FC2-442E-A2AB-EAB2E594FEAE"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
    internal interface INetDomain
    {
        void Initialize();
        void OnApplicationStart();
    }
    internal sealed class DomainManager : AppDomainManager, INetDomain
    {
        public DomainManager() { }
        public override void InitializeNewDomain(AppDomainSetup appDomainInfo) { InitializationFlags = AppDomainManagerInitializationOptions.RegisterWithHost; }

        public void Initialize() => ModLoader.Main.Initialize();
        public void OnApplicationStart() => ModLoader.Main.OnApplicationStart();
    }
}
