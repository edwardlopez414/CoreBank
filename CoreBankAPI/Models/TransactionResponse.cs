namespace CoreBankAPI.Models
{
    public class TransactionResponse
    {
        public string? Status { get; set; }
        public string? Account { get; set; }
        public decimal BalanceAccount { get; set; }
        public decimal TransactionAmount { get; set; }
        public string? identifier { get; set; }
    }
}
