using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using TIKSN.DependencyInjection;
using TIKSN.Finance.ForeignExchange;

namespace TIKSN.Exchange
{
    public class CompositionRootSetup : AutofacCompositionRootSetupBase
    {
        public CompositionRootSetup(IConfigurationRoot configurationRoot) : base(configurationRoot)
        {
        }

        protected override void ConfigureContainerBuilder(ContainerBuilder builder)
        {
            builder.RegisterType<ExchangeRateService>().As<IExchangeRateService>().InstancePerLifetimeScope();
            builder.RegisterType<TextLocalizer>().As<IStringLocalizer>().SingleInstance();
        }

        protected override void ConfigureOptions(IServiceCollection services, IConfigurationRoot configuration)
        {
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
        }
    }
}