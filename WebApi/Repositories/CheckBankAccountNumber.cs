using System.Text.RegularExpressions;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class CheckBankAccountNumber:ICheckBankAccountNumber
    {
        public bool CheckValidBankAccountNumber(Customer_Model customerModel)
        {
            string regex = @"^[0-9]{16,20}$";
            var IsValidBankAccount = Regex.IsMatch(customerModel.BankAccountNumber, regex);
            return IsValidBankAccount;

        }
    }
}
