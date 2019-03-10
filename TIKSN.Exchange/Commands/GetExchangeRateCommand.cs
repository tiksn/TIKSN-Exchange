using Microsoft.Extensions.DependencyInjection;
using System;
using System.Management.Automation;
using System.Threading;
using System.Threading.Tasks;
using TIKSN.Finance;
using TIKSN.Finance.ForeignExchange;
using TIKSN.Globalization;
using TIKSN.Time;

namespace TIKSN.Exchange.Commands
{
    [Cmdlet(VerbsCommon.Get, "ExchangeRate")]
    public class GetExchangeRateCommand : Command
    {
        [Parameter(Mandatory = false)]
        public DateTimeOffset? AsOn { get; set; }

        [Parameter(Mandatory = true)]
        public string BaseCurrency { get; set; }

        [Parameter(Mandatory = true)]
        public string CounterCurrency { get; set; }

        protected override async Task ProcessRecordAsync(CancellationToken cancellationToken)
        {
            var timeProvider = ServiceProvider.GetRequiredService<ITimeProvider>();
            var exchangeRateService = ServiceProvider.GetRequiredService<IExchangeRateService>();
            var currencyFactory = ServiceProvider.GetRequiredService<ICurrencyFactory>();
            var pair = new CurrencyPair(currencyFactory.Create(BaseCurrency), currencyFactory.Create(CounterCurrency));

            var exchangeDate = AsOn.HasValue ? AsOn.Value : timeProvider.GetCurrentTime();

            var rate = await exchangeRateService.GetExchangeRateAsync(pair, exchangeDate, cancellationToken);

            WriteObject(rate);
        }
    }
}