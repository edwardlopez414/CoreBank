using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBankAPI.Data
{
    public class AccoutDta
    {
        [Key]
        public int Id { get; set; }
        public string? identifier { get; set; }
        [ForeignKey("UserDta")]
        public int UserId { get; set; }
        public string? Currency { get; set; }
        public decimal Balance { get; set; }
        public DateTime Registered { get; set; }
        public bool Isactive { get; set; }
        public UserDta User { get; set; }
        public List<TransactionDta> Transactions { get; set; } = new();
    }
}
