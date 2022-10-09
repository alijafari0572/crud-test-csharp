using Microsoft.EntityFrameworkCore;

namespace Entities
{
    [Index(nameof(FirstName), IsUnique = true)]
    [Index(nameof(LastName), IsUnique = true)]
    [Index(nameof(DoB), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}