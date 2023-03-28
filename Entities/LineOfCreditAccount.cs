using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace appBank.Entities;
//Conta que pode ter saldo negativo, mas quando há saldo, há cobrança de juros a cada mês (cheque especial).
internal class LineOfCreditAccount : BankAccount
{
    public override void PerformMonthEndTransactions()
    {
        if (BalanceAccount < 0)
        {
            //Negando o saldo para obter uma taxa de juros positiva
            decimal interest = -BalanceAccount * 0.07m;
            MakeWithdrawal(interest, DateTime.Now, "Cobrança mensal de juros.");
        }
    }
}

//Pode ter um saldo negativo, mas não ser maior em valor absoluto do que o limite de crédito.
//Incorrerá em uma cobrança de juros a cada mês em que o saldo de fim de mês não seja 0.
//Incorrerá em uma taxa em cada saque que ultrapassa o limite de crédito.