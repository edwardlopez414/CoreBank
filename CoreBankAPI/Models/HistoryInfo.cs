namespace CoreBankAPI.Models
{
    public class HistoryInfo
    {
        public string? Account { get; set; }
        public string? Type { get; set; }
        public decimal TransactionAmount { get; set; }
        public DateTime Registered { get; set; }
        public string Descriptio { get; set; }
        public string? Identifier { get; set; }
    }
}
