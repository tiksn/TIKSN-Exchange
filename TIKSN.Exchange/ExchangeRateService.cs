using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using TIKSN.Data;
using TIKSN.Finance.ForeignExchange;
using TIKSN.Finance.ForeignExchange.Bank;
using TIKSN.Finance.ForeignExchange.Cumulative;
using TIKSN.Finance.ForeignExchange.Data;
using TIKSN.Globalization;
using TIKSN.Localization;
using TIKSN.Time;

namespace TIKSN.Exchange
{
    public sealed class ExchangeRateService : ExchangeRateServiceBase
    {
        public ExchangeRateService(
            ILogger<ExchangeRateServiceBase> logger,
            IStringLocalizer stringLocalizer,
            ICurrencyFactory currencyFactory,
            IRegionFactory regionFactory,
            IExchangeRateRepository exchangeRateRepository,
            IForeignExchangeRepository foreignExchangeRepository,
            IUnitOfWorkFactory unitOfWorkFactory,
            ITimeProvider timeProvider,
            Random random) : base(logger, stringLocalizer, currencyFactory, regionFactory, exchangeRateRepository, foreignExchangeRepository, unitOfWorkFactory, random)
        {
            AddBatchProvider(
                4066,
                new BankOfCanada(currencyFactory, timeProvider),
                LocalizationKeys.Key734344590,
                LocalizationKeys.Key734344590,
                "CA",
                TimeSpan.FromHours(12));

            AddIndividualProvider(
                4416,
                new BankOfEngland(currencyFactory, regionFactory, timeProvider),
                LocalizationKeys.Key758955736,
                LocalizationKeys.Key758955736,
                "GB",
                TimeSpan.FromHours(12));

            AddBatchProvider(
                8598,
                new BankOfRussia(currencyFactory, timeProvider),
                LocalizationKeys.Key937230874,
                LocalizationKeys.Key466192205,
                "RU",
                TimeSpan.FromHours(24));

            AddBatchProvider(
                1252,
                new NationalBankOfUkraine(_currencyFactory),
                LocalizationKeys.Key344909065,
                LocalizationKeys.Key344909065,
                "UA",
                TimeSpan.FromHours(24));

            AddBatchProvider(
                7740,
                new MyCurrencyDotNet(_currencyFactory, _regionFactory, timeProvider),
                LocalizationKeys.Key633405189,
                LocalizationKeys.Key611756663,
                "001",
                TimeSpan.FromHours(12));

            //AddIndividualProvider(
            //    3752,
            //    new CurrencyConverterApiDotCom(_currencyFactory, timeProvider),
            //    LocalizationKeys.Key692585112,
            //    LocalizationKeys.Key692585112,
            //    "001",
            //    TimeSpan.FromHours(12));
        }
    }
}