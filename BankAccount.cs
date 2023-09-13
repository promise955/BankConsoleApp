
using System.Text;
namespace BankConsoleApp
{
    internal class BankAccount
    {
        public string AccountNumber { get; }
        public string AccountName { get; set; }

        public decimal AccountBalance
        {
            get
            {

                decimal balance = 0;

                foreach (Transaction _singleTransaction in _transactions)
                {
                    balance += _singleTransaction.Amount;
                }
                return balance;

            }
        }
        private static int AccountNumberSeed = 1234567890;


        private List<Transaction> _transactions = new List<Transaction>();

        public BankAccount(string accountName, decimal initialBalance)
        {
            AccountNumberSeed++;
            AccountNumber = AccountNumberSeed.ToString();
            AccountName = accountName;
            MakeDeposit(initialBalance, DateTime.Now, "Initial deposit");
        }

        public decimal MakeDeposit(decimal amount, DateTime date, string description)
        {

            string status;
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount to deposit must be positive");
                }
                Transaction _deposit = new Transaction(amount, date, description);
                _transactions.Add(_deposit);
                status = "completed successfully";
                Console.WriteLine(status);

            }
            catch (ArgumentOutOfRangeException e)
            {

                status = "Amount to deposit must be positive";
                Console.WriteLine(e.ToString());

            }

            return AccountBalance;
        }




        public decimal MakeWithdrawal(decimal amount, DateTime date, string description)
        {

            string status;
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
                }

                if (AccountBalance - amount < 0)
                {
                    throw new InvalidOperationException("Insufficient funds");
                }

                Transaction _withdrawal = new Transaction(-amount, date, description);
                _transactions.Add(_withdrawal);

                status = "completed successfully";
                Console.WriteLine(status);
            }
            catch (ArgumentOutOfRangeException)
            {

                status = "Amount must be positive";
                Console.WriteLine(status);

            }
            catch (InvalidOperationException)
            {
                Console.WriteLine(new InvalidOperationException("Insufficient funds"));
            }

            return AccountBalance;
        }
        public string getTansactionHistory()
        {
            string status;
            try
            {
                StringBuilder transactionHistory = new StringBuilder();

                transactionHistory.AppendLine("Date\t\t\tAmount\t\tDescription");

                foreach (Transaction item in _transactions)
                {
                    transactionHistory.AppendLine($"{item.Date}\t ${item.Amount}\t\t{item.Description}");
                }

                return transactionHistory.ToString();

            }
            catch (Exception)
            {
                status = "Unable to get report";
                Console.WriteLine(status);
                return status;
            }
        }
    }


}
