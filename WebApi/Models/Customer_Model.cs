using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Customer_Model
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        [MaxLength(12)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}