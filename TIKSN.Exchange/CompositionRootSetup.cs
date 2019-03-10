using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using TIKSN.DependencyInjection;
using TIKSN.Finance.ForeignExchange;
using TIKSN.Finance.ForeignExchange.Data;
using TIKSN.Finance.ForeignExchange.Data.EntityFrameworkCore;

namespace TIKSN.Exchange
{
    public class CompositionRootSetup : AutofacCompositionRootSetupBase
    {
        private static readonly InMemoryDatabaseRoot inMemoryDatabaseRoot = new InMemoryDatabaseRoot();

        public CompositionRootSetup(IConfigurationRoot configurationRoot) : base(configurationRoot)
        {
        }

        protected override void ConfigureContainerBuilder(ContainerBuilder builder)
        {
            builder.RegisterType<ExchangeRateRepository>().As<IExchangeRateRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ForeignExchangeRepository>().As<IForeignExchangeRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ExchangeRateService>().As<IExchangeRateService>().InstancePerLifetimeScope();
            builder.RegisterType<TextLocalizer>().As<IStringLocalizer>().SingleInstance();
        }

        protected override void ConfigureOptions(IServiceCollection services, IConfigurationRoot configuration)
        {
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ExchangeRatesContext>(options =>
            {
                options.UseInMemoryDatabase("ExchangeRates", inMemoryDatabaseRoot);
            });
        }
    }
}