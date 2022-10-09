using WebApi.Models;

namespace WebApi.Repositories
{
    public interface ICheckBankAccountNumber
    {
        public bool CheckValidBankAccountNumber(Customer_Model customerModel);
    }
}
