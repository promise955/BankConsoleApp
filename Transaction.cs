namespace BankConsoleApp
{
    internal class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public string Description { get; set; }
        public Transaction(decimal amount, DateTime date, string description)
        {
            Description = description;
            Amount = amount;
            Date = date;
        }
    }
}
