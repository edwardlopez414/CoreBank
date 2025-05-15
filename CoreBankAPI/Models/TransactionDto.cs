namespace CoreBankAPI.Models
{
    public class TransactionDto
    {
        public string? Identifier { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}
