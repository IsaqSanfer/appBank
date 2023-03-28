using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBank.Entities;
//Uma conta bancária simples, raiz
internal class BankAccount
{
    private static int accountNumberSeed = 1004270000;
    public string NumberAccount { get; }
    public string OwnerAccount { get; set; }
    public decimal BalanceAccount
    {
        get
        {
            decimal balance = 0;
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }

    public BankAccount(string name, decimal initialBalance)
    {
        //BalanceAccount = initialBalance;
        NumberAccount = accountNumberSeed.ToString();
        accountNumberSeed++;
        OwnerAccount = name;
        MakeDeposit(initialBalance, DateTime.Now, "Balanço inicial.");
    }

    private List<Transaction> allTransactions = new List<Transaction>();
    public void MakeDeposit(decimal amount, DateTime date, string note) 
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "O valor do depósito precisa ser positivo.");
        }
        var deposit = new Transaction(amount, date, note);
        allTransactions.Add(deposit);
    }
    public void MakeWithdrawal(decimal amount, DateTime date, string note) 
    {
        if (amount < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "O valor do saque precisa ser positivo.");
        }
        if (BalanceAccount - amount < 0)
        {
            throw new InvalidOperationException("Não há saldo suficiente para a operação de saque.");
        }
        var withdrawal = new Transaction(-amount, date, note);
        allTransactions.Add(withdrawal);
    }

    public string GetAccountHistory()
    {
        var report = new System.Text.StringBuilder();

        decimal balance = 0;
        report.AppendLine("Date\t\tAmount\tBalanceAccount\tNote");
        foreach (var item in allTransactions)
        {
            balance += item.Amount;
            report.AppendLine($"{item.DateTransaction.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
        }
        return report.ToString();
    }

    //método para executar as ações dos diferentes tipos de contas
    public virtual void PerformMonthEndTransactions() { }
}
