using Microsoft.EntityFrameworkCore;
using System;
using TIKSN.Data.EntityFrameworkCore;
using TIKSN.Finance.ForeignExchange.Data.EntityFrameworkCore;

namespace TIKSN.Exchange
{
    public class UnitOfWorkFactory : EntityUnitOfWorkFactoryBase
    {
        public UnitOfWorkFactory(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override DbContext[] GetContexts() => new[] { GetContext<ExchangeRatesContext>() };
    }
}