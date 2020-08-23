using Newtonsoft.Json;
using System;

namespace Householder.Server.Models
{
    public class Expense
    {
        [JsonProperty("id")]
        public int ID { get; }
        [JsonProperty("payee")]
        public Resident Payee { get; }
        [JsonProperty("amount")]
        public double Amount { get; }
        [JsonProperty("date")]
        public DateTime Date { get; }
        [JsonProperty("note")]
        public string Note { get; }
        [JsonProperty("status")]
        public ExpenseStatus Status { get; }

        public Expense(Resident payee, double amount, DateTime date, string note, ExpenseStatus status)
        {
            ID = -1;
            Payee = payee;
            Amount = amount;
            Date = date;
            Note = note;
            Status = status;
        }

        [JsonConstructor]
        public Expense(int id, Resident payee, double amount, DateTime date, string note, ExpenseStatus status)
        {
            ID = id;
            Payee = payee;
            Amount = amount;
            Date = date;
            Note = note;
            Status = status;
        }
    }
}