using System;

namespace Householder.Server.Models
{
    public class Expense
    {
        public Resident Payee { get; }
        public double Amount { get; }
        public DateTime Date { get; }
        public string Note { get; }
        
    }
}