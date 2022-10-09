using EmailValidation;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class CheckEmail:ICheckEmail
    {
        public bool CheckValidEmail(Customer_Model customerModel)
        {
            var IsValidEmail = EmailValidator.Validate(customerModel.Email);
            return IsValidEmail;
        }
    }
}
