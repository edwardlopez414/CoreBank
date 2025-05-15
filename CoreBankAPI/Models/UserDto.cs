namespace CoreBankAPI.Models
{
    public class UserDto
    {
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? LastName2 { get; set; }
        public string? Idtype { get; set; }
        public string? Idnumber { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Gender { get; set; }
        public int Income { get; set; }
    }
}
