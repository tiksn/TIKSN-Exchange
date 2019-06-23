using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using TIKSN.Configuration;

namespace TIKSN.Exchange
{
    public class ConfigurationRootSetup : ConfigurationRootSetupBase
    {
        protected override void SetupConfiguration(IConfigurationBuilder builder)
        {
            base.SetupConfiguration(builder);

            builder.AddInMemoryCollection(new Dictionary<string, string>
            {
                { ConfigurationPath.Combine("ConnectionStrings", ConnectionStringNames.MainConnectionString), "Filename=database.db"}
            });
        }
    }
}