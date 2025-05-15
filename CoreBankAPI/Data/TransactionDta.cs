using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreBankAPI.Data
{
    public class TransactionDta
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AccountDta")]
        public int AccountId { get; set; }
        public string? Type { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime Registered { get; set; }
        public  bool ?  Isreversed { get; set; }
        public AccoutDta Account { get; set; }
        public string? identifier { get; set; }
    }
}
