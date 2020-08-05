using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Householder.Server.Models
{
    public class Reconciliation
    {
        [JsonProperty("creator")]
        public Resident Creator { get; }
        [JsonProperty("action_date")]
        public DateTime CreationDate { get; }
        [JsonProperty("expenses")]
        public IEnumerable<Expense> Expenses { get; }

        [JsonConstructor]
        public Reconciliation(Resident creator, DateTime creationDate, IEnumerable<Expense> expenses)
        {
            Creator = creator;
            CreationDate = creationDate;
            Expenses = expenses;
        }
    }
}