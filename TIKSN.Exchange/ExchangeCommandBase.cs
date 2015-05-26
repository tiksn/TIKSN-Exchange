
namespace TIKSN.Exchange
{
    public abstract class ExchangeCommandBase : System.Management.Automation.Cmdlet
    {
        [System.Management.Automation.Parameter(Mandatory = true)]
        public string Exchange { get; set; }

        [System.Management.Automation.Parameter(Mandatory = false)]
        public System.DateTime? Date { get; set; }
    }
}
