using System;
using TIKSN.PowerShell;

namespace TIKSN.Exchange.Commands
{
    public abstract class Command : CommandBase
    {
        private static readonly Lazy<IServiceProvider> rootServiceProvider = new Lazy<IServiceProvider>(CreateRootServiceProvider, false);

        protected override IServiceProvider GetServiceProvider()
        {
            return rootServiceProvider.Value;
        }

        private static IServiceProvider CreateRootServiceProvider()
        {
            var configurationRootSetup = new ConfigurationRootSetup();
            var configurationRoot = configurationRootSetup.GetConfigurationRoot();
            var compositionRootSetup = new CompositionRootSetup(configurationRoot);
            return compositionRootSetup.CreateServiceProvider();
        }
    }
}