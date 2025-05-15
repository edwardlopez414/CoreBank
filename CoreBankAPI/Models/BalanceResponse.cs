namespace CoreBankAPI.Models
{
    public class BalanceResponse
    {
        public string? identifier { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public string? Currency { get; set; }
        public bool Isactive { get; set; }
        public DateTime Registered { get; set; }
    }
}
