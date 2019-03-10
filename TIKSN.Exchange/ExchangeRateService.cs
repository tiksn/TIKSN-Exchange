using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using TIKSN.Data;
using TIKSN.Finance.ForeignExchange;
using TIKSN.Finance.ForeignExchange.Data;
using TIKSN.Globalization;

namespace TIKSN.Exchange
{
    public class ExchangeRateService : ExchangeRateServiceBase
    {
        public ExchangeRateService(ILogger<ExchangeRateServiceBase> logger, IStringLocalizer stringLocalizer, ICurrencyFactory currencyFactory, IRegionFactory regionFactory, IExchangeRateRepository exchangeRateRepository, IForeignExchangeRepository foreignExchangeRepository, IUnitOfWorkFactory unitOfWorkFactory, Random random) : base(logger, stringLocalizer, currencyFactory, regionFactory, exchangeRateRepository, foreignExchangeRepository, unitOfWorkFactory, random)
        {
        }
    }
}