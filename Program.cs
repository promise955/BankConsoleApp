using BankConsoleApp;

BankAccount account = new BankAccount("Promise Christopher", 284468);

account.MakeDeposit(100.97979M, DateTime.Now, "Cash deposit");
account.MakeWithdrawal(400.97979M, DateTime.Now, "ATM withdrawl");
account.MakeDeposit(10.97979M, DateTime.Now, "Transfer deposit");

Console.WriteLine($"created account with account Number {account.AccountNumber} and account name {account.AccountName} and balance {account.AccountBalance} successfully.");

Console.WriteLine(account.getTansactionHistory());