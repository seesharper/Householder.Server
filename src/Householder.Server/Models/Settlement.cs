using Newtonsoft.Json;

namespace Householder.Server.Models
{
    public class Settlement
    {
        [JsonProperty("creditor")]
        public Resident Creditor { get; }
        [JsonProperty("debtor")]
        public Resident Debtor { get; }
        [JsonProperty("amount")]
        public double Amount { get; }
        [JsonProperty("status")]
        public SettlementStatus Status { get; }

        [JsonConstructor]
        public Settlement(Resident creditor, Resident debtor, double amount, SettlementStatus status)
        {
            Creditor = creditor;
            Debtor = debtor;
            Amount = amount;
            Status = status;
        }
    }
}