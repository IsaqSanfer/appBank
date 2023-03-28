using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appBank.Entities;
//Conta giftcard pré-paga que começa com um único depósito, e só pode ser paga. Ela pode ser preenchida novamente uma vez no início de cada mês.
internal class GiftCardAccount : BankAccount
{
    private readonly decimal _monthlyDeposit = 0m;
    public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
    {
        _monthlyDeposit = monthlyDeposit;
    }

    public override void PerformMonthEndTransactions()
    {
        if(_monthlyDeposit != 0)
        {
            MakeDeposit(_monthlyDeposit, DateTime.Now, "Depósito mensal realizado.");
        }
    }
}

//Pode ser preenchido novamente com um valor especificado uma vez por mês, no último dia do mês.