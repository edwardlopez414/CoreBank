using System.ComponentModel.DataAnnotations;

namespace CoreBankAPI.Data
{
    public class UserDta
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? LastName2 { get; set; }
        public string? Idtype { get; set; }
        public string? Idnumber { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Gender { get; set; }
        public int Income { get; set; }
        public DateTime? Registered { get; set; }
        public bool Isactive { get; set; }
        public AccoutDta account { get; set; }
    }
}
