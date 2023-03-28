using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBank.Entities;
internal class Transaction
{
    public decimal Amount { get; }
    public DateTime DateTransaction { get; }
    public string Notes { get; }

    public Transaction(decimal amount, DateTime dateTransaction, string note)
    {
        Amount = amount;
        DateTransaction = dateTransaction;
        Notes = note;
    }
}
