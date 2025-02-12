namespace MoneyTrackerApp.Controllers.Models
{
    public class FinanceRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Withdrawal { get; set; }
        public int Deposit { get; set; }
        public int Balance { get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
