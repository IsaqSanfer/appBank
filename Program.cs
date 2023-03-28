using appBank.Entities;

var account = new BankAccount("<name>", 1000);
Console.WriteLine($"A conta {account.NumberAccount} foi criada para {account.OwnerAccount} com R${account.BalanceAccount} de saldo inicial.");