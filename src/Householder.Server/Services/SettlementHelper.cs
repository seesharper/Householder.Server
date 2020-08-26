using System.Linq;
using Householder.Server.Models;
using System.Collections.Generic;
using System;

namespace Householder.Server.Services
{
    public class SettlementBuilder
    {
        private readonly List<Resident> residents;
        private readonly int residentCount;
        private Dictionary<Resident, double> expensesPerResident;
        private List<Expense> expenses;
        private double totalAmount;

        public SettlementBuilder(List<Resident> residents)
        {
            expenses = new List<Expense>();
            expensesPerResident = new Dictionary<Resident, double>();
            this.residents = residents;

            residentCount = residents.Count;

            foreach(Resident r in residents)
            {
                expensesPerResident.Add(r, 0);
            }
        }

        public void AddExpense(Expense expense)
        {
            expenses.Add(expense);
            totalAmount += expense.Amount;
            
            var resident = expense.Payee;

            expensesPerResident[resident] += expense.Amount;
        }

        public void AddExpenses(List<Expense> expenses)
        {
            foreach (Expense e in expenses)
            {
                AddExpense(e);
            }
        }

        public IEnumerable<Settlement> Build()
        {
            List<Settlement> results = new List<Settlement>();

            foreach (Resident resident in residents)
            {
                var spentAmount = expensesPerResident[resident];
                var outstanding = (totalAmount / residentCount) - spentAmount;

                expensesPerResident[resident] = outstanding;
            }

            expensesPerResident = expensesPerResident.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            for (int i = 0; i < expensesPerResident.Count; i++)
            {
                var debtor = expensesPerResident.ElementAt(i).Key;
                if (expensesPerResident[debtor] > 0)
                {
                    for (int j = 0; j < expensesPerResident.Count; j++)
                    {
                        var debt = expensesPerResident[debtor];
                        var creditor = expensesPerResident.ElementAt(j).Key;
                        var credit = expensesPerResident[creditor];
                        if (credit < 0 && debt != 0)
                        {
                            double toPay = Math.Min(Math.Abs(credit), debt);
                            results.Add(new Settlement(creditor, debtor, toPay, SettlementStatus.Pending));
                            expensesPerResident[creditor] += toPay;
                            expensesPerResident[debtor] -= toPay;
                        }
                    }
                }
            }

            return results;
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

        public static void Main(string[] args)
        {
            List<Resident> residents = new List<Resident> 
            {
                new Resident("A"),
                new Resident("B"),
                new Resident("C")
            };

            SettlementBuilder sb = new SettlementBuilder(residents);

            sb.AddExpenses(new List<Expense>
            {
                new Expense(residents[0], 200, DateTime.Now, "help", ExpenseStatus.InProgress),
                new Expense(residents[1], 100, DateTime.Now, "help", ExpenseStatus.InProgress),
            });

            var settlements = sb.Build();

            foreach(var s in settlements)
            {
                Console.WriteLine($"{s.Debtor.Name} owes {s.Creditor.Name} {s.Amount}");
            }
        }
    }
}