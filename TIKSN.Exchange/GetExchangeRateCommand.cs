
namespace TIKSN.Exchange
{
    [System.Management.Automation.Cmdlet("Get", "ExchangeRate")]
    public class GetExchangeRateCommand : ExchangeCommandBase
    {
        protected override void BeginProcessing()
        {
            this.WriteObject(Date);
        }
    }
}
