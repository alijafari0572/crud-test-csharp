using WebApi.Models;

namespace WebApi.Repositories
{
    public interface ICheckPhonenumber
    {
        public bool CheckValidPhoneNumber(Customer_Model customerModel);
    }
}
