using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBank.Entities;
//Uma conta bancária de ganho de juros que acumula juros no final de cada mês
internal class InterestEarningAccount : BankAccount
{
    //construtor que pode passar argumentos para o construtor de classe base (BankAccount)
    public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
    {
        
    }

    public override void PerformMonthEndTransactions()
    {
        if (BalanceAccount > 500m)
        {
            decimal interest = BalanceAccount * 0.05m;
            MakeDeposit(interest, DateTime.Now, "Aplicação dos rendimentos mensais.");
        }
    }
}

//Obterá um crédito de 2% do saldo final do mês.