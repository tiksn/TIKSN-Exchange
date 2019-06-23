using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using TIKSN.Data;
using TIKSN.Data.LiteDB;
using TIKSN.DependencyInjection;
using TIKSN.Exchange.Commands;
using TIKSN.Finance.ForeignExchange;
using TIKSN.Finance.ForeignExchange.Data;
using TIKSN.Finance.ForeignExchange.Data.LiteDB;

namespace TIKSN.Exchange
{
    public class CompositionRootSetup : AutofacCompositionRootSetupBase
    {
        public CompositionRootSetup(IConfigurationRoot configurationRoot) : base(configurationRoot)
        {
        }

        protected override void ConfigureContainerBuilder(ContainerBuilder builder)
        {
            builder.RegisterType<ExchangeRateRepository>().As<IExchangeRateRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ForeignExchangeRepository>().As<IForeignExchangeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DatabaseProvider>().As<ILiteDbDatabaseProvider>().SingleInstance();
            builder.RegisterType<UnitOfWorkFactory>().As<IUnitOfWorkFactory>().InstancePerLifetimeScope();
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