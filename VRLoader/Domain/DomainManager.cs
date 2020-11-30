using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRCLoader;

namespace VRCLoader.Domain
{
    internal sealed class DomainManager : AppDomainManager, INetDomain
    {
        public DomainManager() { }
        public override void InitializeNewDomain(AppDomainSetup appDomainInfo) { InitializationFlags = AppDomainManagerInitializationOptions.RegisterWithHost; }

        public void Initialize() => VRCLoader.Load();
        public void OnApplicationStart() => VRCLoader._self.Start();
    }
}
