using Householder.Server.Models;
using Householder.Server.Queries;
using System.Collections.Generic;

namespace Householder.Server.Services
{
    public class SettlementHelper
    {
        private IQueryProcessor queryProcessor;

        public SettlementHelper(IQueryProcessor queryProcessor)
        {
            this.queryProcessor = queryProcessor;
        }

        public IEnumerable<Settlement> GenerateSettlements(IEnumerable<Expense> expenses)
        {
            List<Settlement> result = new List<Settlement>();

            double totalAmount = 0;
            Dictionary<string, double> amountPerResident = new Dictionary<string, double>();

            foreach (Expense e in expenses)
            {
                totalAmount += e.Amount;

                if (!amountPerResident.ContainsKey(e.Payee.Name))
                {
                    amountPerResident.Add(e.Payee.Name, 0);
                }

                amountPerResident[e.Payee.Name] += e.Amount;
            }

            // TODO: This doesn't really work, as we're not setting which resident should receive the payment
            foreach (var resident in amountPerResident.Keys)
            {
                double owedAmount = (totalAmount / amountPerResident.Count) - amountPerResident[resident];

                if (owedAmount > 0)
                {
                    result.Add(new Settlement(new Resident(resident), null, owedAmount, SettlementStatus.Pending));
                }
            }

            return result;
        }
    }
}